Imports System.Data.OleDb
Imports Almacen.Negocios
Imports DevExpress.XtraGrid
Imports Tools
Imports Tools.Utilerias
Imports Infragistics.Documents
Imports DevExpress.XtraGrid.Views.Base

Public Class ImportacionArchivoGuiaForm
    Dim objInstancia As New AdministradorDocumentosBU
    Dim guiasI As Integer = 0
    Dim guiasC As Integer = 0
    Private Sub llenarComboPaqueteria()
        Try
            Dim tabla = objInstancia.ListaMensajerias()
            With cbMensajaeria
                .DataSource = tabla
                .DisplayMember = "Nombre"
                .ValueMember = "ID"
            End With
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Aviso, "No se consultaron bien las mensajerias por favor comunicate con TI")
        End Try
    End Sub

    Private Sub ImportacionArchivoGuiaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboPaqueteria()
    End Sub

    Private Function importarExcel() As DataTable

        Dim myFileDialog As New OpenFileDialog()
        Dim xSheet As String = ""
        Dim listahojas As New List(Of Entidades.SheetsExcel)
        Dim nombrehoja As String
        Dim ds As New DataSet
        Dim da As OleDbDataAdapter
        Dim dt As New DataTable
        Dim conn As OleDbConnection

        With myFileDialog
            .Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            .Title = "Open File"
            .ShowDialog()
        End With

        If myFileDialog.FileName.ToString <> "" Then
            Dim ExcelFile As String = myFileDialog.FileName.ToString

            txtruta.Text = ExcelFile

            Dim xlApp As New Microsoft.Office.Interop.Excel.Application
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet

            xlWorkBook = xlApp.Workbooks.Open(ExcelFile) 'ej "D:\prueba.xls

            If xlWorkBook.Worksheets.Count > 1 Then
                For index = 1 To xlWorkBook.Worksheets.Count
                    Dim hoja As New Entidades.SheetsExcel
                    xlWorkSheet = xlWorkBook.Worksheets(index)
                    hoja.NombreHoja = xlWorkSheet.Name
                    hoja.Numero = index
                    listahojas.Add(hoja)
                Next
                Dim instancia As New HojasExcelForm
                instancia.hojas = listahojas
                instancia.StartPosition = FormStartPosition.CenterParent
                instancia.ShowDialog()
                nombrehoja = instancia.numeroHoja
                If nombrehoja = "" Then
                    Utilerias.show_message(TipoMensaje.Advertencia, "No seleccionaste una hoja")
                    txtruta.Text = ""
                    xlApp.Workbooks.Close()
                    Return dt
                End If
            Else
                Dim xlWorkSheetv2 As Microsoft.Office.Interop.Excel.Worksheet
                xlWorkSheetv2 = xlWorkBook.Worksheets(1)
                nombrehoja = xlWorkSheetv2.Name
            End If

            xlApp.Workbooks.Close()





            conn = New OleDbConnection(
                          "Provider=Microsoft.ACE.OLEDB.12.0;" &
                          "data source=" & ExcelFile & "; " &
                         "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1'")

            Try
                da = New OleDbDataAdapter("SELECT * FROM  [" + nombrehoja + "$]", conn)

                conn.Open()
                da.Fill(dt)

                Return dt

                conn.Close()
            Catch ex As Exception

            Finally
                conn.Close()
            End Try
        Else
            Utilerias.show_message(TipoMensaje.Advertencia, "No seleccionaste un archivo")
            Return dt
        End If
        Return dt
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cbMensajaeria.SelectedValue = 6 Then
            leerInformacionCastores()
        ElseIf cbMensajaeria.SelectedValue = 10 Or cbMensajaeria.SelectedValue = 2 Then
            leerInformacionFedex()
        Else
            leerInformacionEstafeta()
        End If

    End Sub
    Private Sub viewModelos_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles vwguias.CustomDrawCell


        Dim status = vwguias.GetRowCellValue(e.RowHandle, "Status")
        Dim CapturadoA = vwguias.GetRowCellValue(e.RowHandle, "CapturadoA")


        If e.RowHandle >= 0 Then
            If e.Column.FieldName = "Status" Then
                If status = 1 Then
                    e.Appearance.BackColor = Color.Green
                    e.Appearance.ForeColor = Color.Green
                ElseIf status = 2 Then
                    e.Appearance.BackColor = Color.Yellow
                    e.Appearance.ForeColor = Color.Yellow
                Else
                    e.Appearance.BackColor = Color.Red
                    e.Appearance.ForeColor = Color.Red
                End If
            End If

        End If



    End Sub

    Private Sub leerInformacionFedex()
        Dim registros = importarExcel()
        If registros.Rows.Count > 0 Then
            Dim lista As New List(Of Entidades.NumerosGuia)
            Dim listaR As New List(Of Entidades.NumerosGuia)

            If registros.Columns.Contains("Referencia") And registros.Columns.Contains("Numero de Guia") Then

                For Each row In registros.Rows
                    Dim entidad As New Entidades.NumerosGuia

                    If IsNumeric(row.item("Referencia")) Then
                        Dim result = objInstancia.ConsultaExisteEmbarque(row.item("Referencia"), row.item("Numero de Guia"), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "", 0)
                        If result.Rows(0).Item("Existe") = 0 Then
                            entidad.Referencia = row.item("Referencia")
                            entidad.NumeroGuia = row.item("Numero de Guia")
                            entidad.Status = 0
                            entidad.Repetida = 0
                        ElseIf result.Rows(0).Item("Existe") = 1 And result.Rows(0).Item("Capturo") = 1 Then
                            entidad.Referencia = row.item("Referencia")
                            entidad.NumeroGuia = row.item("Numero de Guia")
                            entidad.Status = 1
                            entidad.Repetida = 0
                        ElseIf result.Rows(0).Item("Capturo") = 2 Then
                            entidad.Referencia = row.item("Referencia")
                            entidad.NumeroGuia = row.item("Numero de Guia")
                            entidad.Status = 2
                            entidad.Repetida = 0
                        End If
                    Else
                        entidad.Referencia = 0
                        entidad.NumeroGuia = row.item("Numero de Guia")
                        entidad.Status = 0
                        entidad.Repetida = 0
                    End If
                    lista.Add(entidad)
                    listaR.Add(entidad)

                Next
                grdguias.DataSource = Nothing
                vwguias.Columns.Clear()
                grdguias.DataSource = lista

                GridDesing(lista)
                Utilerias.show_message(TipoMensaje.Exito, "Se capturaron los numeros de guia correctos")
            Else
                Utilerias.show_message(TipoMensaje.Advertencia, "El archivo que ingresaste no pertenece a la paqueteria o es un formato diferente a los anteriores")
            End If
        End If
    End Sub

    Private Sub leerInformacionCastores()
        Dim registros = importarExcel()
        If registros.Rows.Count > 0 Then
            Dim lista As New List(Of Entidades.NumerosGuia)
            Dim listaR As New List(Of Entidades.NumerosGuia)

            If registros.Columns.Contains("Remisión") And registros.Columns.Contains("Guía") And registros.Columns.Contains("Talón") And registros.Columns.Contains("Total") Then
                For Each row In registros.Rows
                    Dim entidad As New Entidades.NumerosGuia
                    Dim remision = row.item("Remisión")
                    Dim guia = row.item("Guía")
                    Dim talon = row.item("Talón")
                    Dim total = row.item("Total")

                    If IsDBNull(remision) Or IsDBNull(guia) Then
                        entidad.Referencia = ""
                        entidad.NumeroGuia = ""
                        entidad.Status = 0
                        entidad.Repetida = 0
                    Else
                        If IsNumeric(row.item("Remisión")) Then
                            Dim result = objInstancia.ConsultaExisteEmbarque(row.item("Remisión"), row.item("Guía"), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, talon, total)
                            If result.Rows(0).Item("Existe") = 0 Then
                                entidad.Referencia = row.item("Remisión")
                                entidad.NumeroGuia = row.item("Guía")
                                entidad.Status = 0
                                entidad.Repetida = 0
                            ElseIf result.Rows(0).Item("Existe") = 1 And result.Rows(0).Item("Capturo") = 1 Then
                                entidad.Referencia = row.item("Remisión")
                                entidad.NumeroGuia = row.item("Guía")
                                entidad.Status = 1
                                entidad.Repetida = 0
                            ElseIf result.Rows(0).Item("Capturo") = 2 Then
                                entidad.Referencia = row.item("Remisión")
                                entidad.NumeroGuia = row.item("Guía")
                                entidad.Status = 2
                                entidad.Repetida = 0
                            End If
                        Else

                            entidad.Referencia = row.item("Remisión")
                            entidad.NumeroGuia = row.item("Guía")
                            entidad.Status = 0
                            entidad.Repetida = 0
                        End If
                        lista.Add(entidad)
                    End If

                Next
                grdguias.DataSource = Nothing
                vwguias.Columns.Clear()
                grdguias.DataSource = lista

                GridDesing(lista)
                Utilerias.show_message(TipoMensaje.Exito, "Se capturaron los numeros de guia correctos")
            Else
                Utilerias.show_message(TipoMensaje.Advertencia, "El archivo que ingresaste no pertenece a la paqueteria o es un formato diferente a los anteriores")
            End If
        End If
    End Sub

    Private Sub leerInformacionEstafeta()
        Dim registros = importarExcel()
        If registros.Rows.Count > 0 Then
            Dim lista As New List(Of Entidades.NumerosGuia)
            Dim listaR As New List(Of Entidades.NumerosGuia)

            If registros.Columns.Contains("Referencia") And registros.Columns.Contains("Num Guia") Then

                For Each row In registros.Rows
                    Dim entidad As New Entidades.NumerosGuia
                    Dim remision = row.item("Referencia")
                    Dim guia = row.item("Num Guia")

                    If IsDBNull(remision) Or IsDBNull(guia) Then
                        entidad.Referencia = ""
                        entidad.NumeroGuia = ""
                        entidad.Status = 0
                        entidad.Repetida = 0
                    Else
                        If IsNumeric(remision) Then
                            Dim result = objInstancia.ConsultaExisteEmbarque(remision, guia, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "", 0)
                            If result.Rows(0).Item("Existe") = 0 Then
                                entidad.Referencia = remision
                                entidad.NumeroGuia = guia
                                entidad.Status = 0
                                entidad.Repetida = 0
                            ElseIf result.Rows(0).Item("Existe") = 1 And result.Rows(0).Item("Capturo") = 1 Then
                                entidad.Referencia = remision
                                entidad.NumeroGuia = guia
                                entidad.Status = 1
                                entidad.Repetida = 0
                            ElseIf result.Rows(0).Item("Capturo") = 2 Then
                                entidad.Referencia = remision
                                entidad.NumeroGuia = guia
                                entidad.Status = 2
                                entidad.Repetida = 0
                            End If
                        Else

                            entidad.Referencia = remision
                            entidad.NumeroGuia = guia
                            entidad.Status = 0
                            entidad.Repetida = 0
                        End If
                        lista.Add(entidad)
                    End If

                Next
                grdguias.DataSource = Nothing
                vwguias.Columns.Clear()
                grdguias.DataSource = lista
                GridDesing(lista)
                Utilerias.show_message(TipoMensaje.Exito, "Se capturaron los numeros de guia correctos")
            Else
                Utilerias.show_message(TipoMensaje.Advertencia, "El archivo que ingresaste no pertenece a la paqueteria o es un formato diferente a los anteriores")
            End If
        End If

    End Sub

    Private Sub GridDesing(lista As List(Of Entidades.NumerosGuia))

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwguias.Columns
            If (col.FieldName <> "Referencia" And col.FieldName <> "NumeroGuia" And col.FieldName <> "Status" And col.FieldName <> "CapturadoA") Then
                DiseñoGrid.EstiloColumna(vwguias, col.FieldName, col.FieldName, False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, False, Nothing, "")
            ElseIf col.FieldName = "Status" Then
                DiseñoGrid.EstiloColumna(vwguias, col.FieldName, " ", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 40, False, Nothing, "")
            ElseIf col.FieldName = "CapturadoA" Then
                DiseñoGrid.EstiloColumna(vwguias, col.FieldName, "Capturado Ant", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 40, False, Nothing, "")

            Else
                DiseñoGrid.EstiloColumna(vwguias, col.FieldName, col.FieldName, True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, False, Nothing, "")

            End If
        Next

        Dim correctas = From v In lista Where v.Status = 1 Or v.Status = 2
        Dim incorrectas = From v In lista Where v.Status = 0
        Dim capturadas = From v In lista Where v.Status = 1

        txtguiasCorrec.Text = correctas.Count
        TextBox5.Text = incorrectas.Count
        txtnumregistros.Text = lista.Count
        txtguiasCaptu.Text = capturadas.Count
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class