Imports System.Data.OleDb
Imports System.IO
Imports DevExpress.Export
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Tools

Public Class ActualizarParesAutorizadosForm
    Public objInstancia As New Negocios.SpeedTrackBU
    Dim clone As DataTable
    Private data As DataTable
    Private exporto As Integer = 0
    Private Sub ActualizarParesAutorizadosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized
        consultarDatos()
    End Sub

    Private Sub consultarDatos()
        Dim datatable = objInstancia.ConsultarModelosActializarParesAutorizados()
        data = datatable
        grdModelos.DataSource = Nothing
        vwModelos.Columns.Clear()
        grdModelos.DataSource = datatable
        If datatable.Rows.Count = 0 Then
            show_message("Advertencia", "No tienes modelos")
        Else
            DiseñoGrid.DiseñoBaseGrid(vwModelos)
            vwModelos.OptionsView.ColumnAutoWidth = False
            vwModelos.IndicatorWidth = 35
            DiseñoGrid.EstiloColumna(vwModelos, " ", "ID", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 200, False, Nothing, "")
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwModelos.Columns
                If (col.FieldName <> "MODELO SAY" And col.FieldName <> "MODELO SICY" And col.FieldName <> "FAMILIA" And col.FieldName <> "PIEL" And col.FieldName <> "COLOR" And col.FieldName <> "PielId" And col.FieldName <> "ColorId" And col.FieldName <> "ProductoId" And col.FieldName <> "ID") Then
                    col.OptionsColumn.AllowEdit = True
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "##,##0"
                    col.Width = 50

                ElseIf col.FieldName <> "PielId" And col.FieldName <> "ColorId" And col.FieldName <> "ProductoId" Then
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
                    col.OptionsColumn.AllowEdit = False
                    col.OptionsColumn.AllowSize = True
                    DiseñoGrid.EstiloColumna(vwModelos, col.FieldName, col.FieldName, True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 200, False, Nothing, "")
                Else
                    DiseñoGrid.EstiloColumna(vwModelos, col.FieldName, col.FieldName, False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 200, False, Nothing, "")
                End If
            Next
        End If

        lblTotalParesProceso.Text = String.Format("{0:N0}", datatable.Rows.Count)
        lblFechaUltimaActualizacion.Text = Date.Now
        Cursor = Cursors.Default
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If vwModelos.RowCount > 0 Then

            ExportarExcel("AutorizacionDePares_")
        Else

            show_message("Advertencia", "No tienes modelos")
        End If
    End Sub
    Private Sub ExportarExcel(ByVal mensaje As String)
        Dim fbdUbicacionArchivo As New FolderBrowserDialog


        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                Dim exportOptions = New XlsxExportOptionsEx()
                AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                exportOptions.ExportType = ExportType.Default

                If ret = Windows.Forms.DialogResult.OK Then
                    If vwModelos.GroupCount > 0 Then
                        grdModelos.ExportToXlsx(.SelectedPath + "\SpeedTrack_ParesA_" + fecha_hora + ".xlsx", exportOptions)
                    Else
                        grdModelos.ExportToXlsx(.SelectedPath + "\SpeedTrack_ParesA_" + fecha_hora + ".xlsx", exportOptions)
                    End If
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "SpeedTrack_ParesA_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\SpeedTrack_ParesA_" + fecha_hora + ".xlsx")
                End If
            End With

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

        ' If e.ColumnFieldName = "15" Then
        ' e.Formatting.FormatType = DevExpress.Utils.FormatType.None
        ' End If
        ' e.Formatting.FormatType = DevExpress.Utils.FormatType.None



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        importarExcel(grdModelos)
        exporto = 1
    End Sub
    Sub importarExcel(ByVal tabla As GridControl)
        Dim myFileDialog As New OpenFileDialog()
        Dim xSheet As String = ""

        If vwModelos.RowCount > 0 Then

            With myFileDialog
                .Filter = "Excel Files |*.xlsx"
                .Title = "Open File"
                .ShowDialog()
            End With
            If myFileDialog.FileName.ToString <> "" Then
                Dim ExcelFile As String = myFileDialog.FileName.ToString

                Dim ds As New DataSet
                Dim da As OleDbDataAdapter
                Dim dt As New DataTable
                Dim conn As OleDbConnection

                ' xSheet = InputBox("Digite el nombre de la Hoja que desea importar", "Complete")
                conn = New OleDbConnection(
                              "Provider=Microsoft.ACE.OLEDB.12.0;" &
                              "data source=" & ExcelFile & "; " &
                             "Extended Properties='Excel 12.0 Xml;HDR=Yes'")

                Try
                    da = New OleDbDataAdapter("SELECT * FROM  [Sheet$]", conn)

                    conn.Open()
                    da.Fill(ds, "MyData")
                    dt = ds.Tables("MyData")

                    tabla.DataSource = Nothing
                    vwModelos.Columns.Clear()

                    tabla.DataSource = dt



                    For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwModelos.Columns
                        If (col.FieldName <> "MODELO SAY" And col.FieldName <> "MODELO SICY" And col.FieldName <> "FAMILIA" And col.FieldName <> "PIEL" And col.FieldName <> "COLOR" And col.FieldName <> "PielId" And col.FieldName <> "ColorId" And col.FieldName <> "ProductoId" And col.FieldName <> "ID") Then
                            col.OptionsColumn.AllowEdit = True
                            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            col.DisplayFormat.FormatString = "##,##0"

                            col.Width = 50

                        ElseIf col.FieldName <> "PielId" And col.FieldName <> "ColorId" And col.FieldName <> "ProductoId" Then
                            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
                            col.OptionsColumn.AllowEdit = False
                            col.OptionsColumn.AllowSize = True
                            DiseñoGrid.EstiloColumna(vwModelos, col.FieldName, col.FieldName, True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 200, False, Nothing, "")
                        Else
                            DiseñoGrid.EstiloColumna(vwModelos, col.FieldName, col.FieldName, False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 200, False, Nothing, "")
                        End If
                    Next
                    tabla.DataMember = "MyData"
                Catch ex As Exception

                Finally
                    conn.Close()
                End Try
            End If
            MsgBox("Se ha cargado la importacion correctamente", MsgBoxStyle.Information, "Importado con exito")
        Else
            show_message("Advertencia", "No tienes modelos")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cursor = Cursors.WaitCursor
        If vwModelos.RowCount > 0 Then

            insertarparesActualizados()
        Else

            show_message("Advertencia", "No tienes modelos")
        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub viewInventario_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwModelos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub
    Private Sub insertarparesActualizados()

        Dim cadena As String = String.Empty
        Dim myDatatView As DataTable


        Try
            myDatatView = CType(grdModelos.DataSource, DataTable)
            Dim result = formaCadena(myDatatView)

            objInstancia.ActualizarParesAutorizados(result(0), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, result(1), exporto)
            ProgressPanel2.Hide()
            show_message("Exito", "Se Insertaron los registros")
        Catch ex As Exception
            show_message("ERROR", "Ocurrio un error comunicate con el departamento de TI para que lo resuelvan Gracias!!" & " " & ex.Message)
        End Try

    End Sub

    Private Function formaCadena(ByVal tabla As DataTable) As String()

        Dim cadena As String = String.Empty
        Dim numeroFilas As Integer
        Dim ids As String = String.Empty
        Dim result(2) As String

        numeroFilas = tabla.Rows.Count
        For index As Integer = 0 To numeroFilas - 1 Step 1
            If exporto = 1 Then
                If cadena = String.Empty Then
                    cadena = tabla.Rows(index).Item("ID").ToString() & "/"
                    ids = tabla.Rows(index).Item("ID").ToString() & ","
                    For index2 As Integer = 15 To 29 Step 1
                        Dim text1 = tabla.Rows(index).Item(index2 & "").ToString()
                        Dim text2 = tabla.Rows(index).Item(index2 & "½").ToString()
                        If text1 = "" Then
                            cadena = cadena & index2 & "-" & "NA" & ","
                        Else
                            cadena = cadena & index2 & "-" & Replace(Replace(text1, ",", ""), ".", "") & ","
                        End If
                        If text2 = "" Then
                            cadena = cadena & index2 & "½-" & "NA" & ","
                        Else
                            cadena = cadena & index2 & "½-" & Replace(Replace(text2, ",", ""), ".", "") & ","
                        End If
                    Next
                Else

                    cadena = cadena & "#" & tabla.Rows(index).Item("ID").ToString() & "/"
                    ids = tabla.Rows(index).Item("ID").ToString() & ","
                    For index2 As Integer = 15 To 29 Step 1
                        Dim text1 = tabla.Rows(index).Item(index2 & "").ToString()
                        Dim text2 = tabla.Rows(index).Item(index2 & "½").ToString()
                        If text1 = "" Then
                            cadena = cadena & index2 & "-" & "NA" & ","
                        Else
                            cadena = cadena & index2 & "-" & Replace(Replace(text1, ",", ""), ".", "") & ","
                        End If
                        If text2 = "" Then
                            cadena = cadena & index2 & "½-" & "NA" & ","
                        Else
                            cadena = cadena & index2 & "½-" & Replace(Replace(text2, ",", ""), ".", "") & ","
                        End If
                    Next

                End If
            Else
                If tabla.Rows(index).Item(" ") = "1" Then
                    If cadena = String.Empty Then
                        cadena = tabla.Rows(index).Item("ID").ToString() & "/"
                        ids = tabla.Rows(index).Item("ID").ToString() & ","
                        For index2 As Integer = 15 To 29 Step 1
                            Dim text1 = tabla.Rows(index).Item(index2 & "").ToString()
                            Dim text2 = tabla.Rows(index).Item(index2 & "½").ToString()
                            If text1 = "" Then
                                cadena = cadena & index2 & "-" & "NA" & ","
                            Else
                                cadena = cadena & index2 & "-" & Replace(Replace(text1, ",", ""), ".", "") & ","
                            End If
                            If text2 = "" Then
                                cadena = cadena & index2 & "½-" & "NA" & ","
                            Else
                                cadena = cadena & index2 & "½-" & Replace(Replace(text2, ",", ""), ".", "") & ","
                            End If
                        Next
                    Else

                        cadena = cadena & "#" & tabla.Rows(index).Item("ID").ToString() & "/"
                        ids = ids & tabla.Rows(index).Item("ID").ToString() & ","
                        For index2 As Integer = 15 To 29 Step 1
                            Dim text1 = tabla.Rows(index).Item(index2 & "").ToString()
                            Dim text2 = tabla.Rows(index).Item(index2 & "½").ToString()
                            If text1 = "" Then
                                cadena = cadena & index2 & "-" & "NA" & ","
                            Else
                                cadena = cadena & index2 & "-" & Replace(Replace(text1, ",", ""), ".", "") & ","
                            End If
                            If text2 = "" Then
                                cadena = cadena & index2 & "½-" & "NA" & ","
                            Else
                                cadena = cadena & index2 & "½-" & Replace(Replace(text2, ",", ""), ".", "") & ","
                            End If
                        Next

                    End If
                End If
            End If
        Next

        result(0) = cadena
        result(1) = ids

        Return result
    End Function

    'Dim vXmlAgrupar As XElement = New XElement("PARES")
    'Private Sub GeneraXml()
    '    Dim vNumFilas As Integer = 0
    '    vNumFilas = vwModelos.DataRowCount


    '    For Index As Integer = 0 To vNumFilas Step 1
    '        If vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(Index), " ") = "1" Then

    '            Dim vNodo As XElement = New XElement("MODELO")
    '            vNodo.Add(New XAttribute("ID", vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(Index), "ID")))
    '            For index2 As Integer = 15 To 29 Step 1
    '                vNodo.Add(New XAttribute("T" & index2, vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(Index), index2 & "")))
    '                vNodo.Add(New XAttribute("T" & index2 & "2", vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(Index), index2 & "½")))
    '            Next
    '            vXmlAgrupar.Add(vNodo)
    '        End If
    '    Next
    'End Sub



    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub vwModelos_CellValueChanged(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles vwModelos.CellValueChanged
        data.Rows(vwModelos.GetVisibleRowHandle(e.RowHandle)).Item(" ") = 1
        data.Rows(e.RowHandle).Item(e.Column.FieldName) = e.Value
        UpdateGridDataSource()
    End Sub

    Private Sub UpdateGridDataSource()
        clone = data
        grdModelos.BeginInvoke(New MethodInvoker(AddressOf AnonymousMethod1))
        data = clone
    End Sub
    Private Sub AnonymousMethod1()
        grdModelos.DataSource = clone
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Cursor = Cursors.WaitCursor
        consultarDatos()
        Cursor = Cursors.Default
    End Sub
End Class