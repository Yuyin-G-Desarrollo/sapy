Imports System.Data.OleDb
Imports System.IO
Imports System.Threading.Tasks
Imports DevExpress.Export
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Tools

Public Class CalendarioSemanalForm
    Public objInstancia As New Negocios.CatalogosEstadisticaVentasBU
    Dim clone As DataTable
    Private data As DataTable
    Private icanexit As Boolean = True
    Private anioErroneo As Boolean = False
    Private Sub AgregarCalendarioSemanalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized
        Dim anioActual = Date.Now.Year
        cbanio.Items.Add(anioActual - 1)
        cbanio.Items.Add(anioActual)
        For index = 1 To 3

            cbanio.Items.Add(anioActual + index)
        Next
        cbanio.SelectedIndex = 1
        consultarDatos()
    End Sub

    Private Sub consultarDatos()
        Dim datatable = objInstancia.ConsultarCalendarioSemana(cbanio.Text)
        data = datatable
        grdSemanas.DataSource = Nothing
        vwSemanas.Columns.Clear()
        grdSemanas.DataSource = datatable
        If datatable.Rows.Count = 0 Then
            show_message("Advertencia", "No hay datos")
        Else
            DiseñoGridd()
        End If
        icanexit = True
        lblFechaUltimaActualizacion.Text = Date.Now
        Cursor = Cursors.Default
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If vwSemanas.RowCount > 0 Then

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

                exportOptions.SheetName = "DíasSemana"
                exportOptions.ExportType = ExportType.Default

                If ret = Windows.Forms.DialogResult.OK Then
                    If vwSemanas.GroupCount > 0 Then
                        grdSemanas.ExportToXlsx(.SelectedPath + "\Calendario_Semanal_" + fecha_hora + ".xlsx", exportOptions)
                    Else
                        grdSemanas.ExportToXlsx(.SelectedPath + "\Calendario_Semanal_" + fecha_hora + ".xlsx", exportOptions)
                    End If
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "Calendario_Semanal_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Calendario_Semanal_" + fecha_hora + ".xlsx")
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

        importarExcel(grdSemanas)
        icanexit = False
    End Sub
    Sub importarExcel(ByVal tabla As GridControl)
        Dim myFileDialog As New OpenFileDialog()
        Dim xSheet As String = ""
        Dim varAño As Integer = 0


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
                da = New OleDbDataAdapter("SELECT * FROM  [DíasSemana$]", conn)
                conn.Open()
                da.Fill(ds, "MyData")
                dt = ds.Tables("MyData")
                tabla.DataSource = Nothing
                vwSemanas.Columns.Clear()
                tabla.DataSource = dt
                If dt.Rows.Count <> 0 Then
                    varAño = CInt(dt.Rows(0).Item("Año").ToString)
                End If
                DiseñoGridd()
                If varAño <> cbanio.Text Then
                    show_message("Aviso", "Se Cargaron los datos pero no son del mismo año del que esta seleccionado")
                Else
                    show_message("Aviso", "Se Cargaron los datos correctamente")
                End If
            Catch ex As Exception
                show_message("Advertencia", "La hoja no se llama (Días Semana) o tienes el documento abierto intenta cargarlo de nuevo")
            Finally
                conn.Close()
            End Try
        End If

    End Sub

    Private Sub DiseñoGridd()

        DiseñoGrid.DiseñoBaseGrid(vwSemanas)
        vwSemanas.OptionsView.ColumnAutoWidth = True
        vwSemanas.IndicatorWidth = 35
        DiseñoGrid.EstiloColumna(vwSemanas, "Semana", "Semana", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwSemanas, "Año", "Año", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwSemanas.Columns
            If (col.FieldName <> "Laborable" And col.FieldName <> "Mes" And col.FieldName <> "Semana" And col.FieldName <> "Fecha" And col.FieldName <> "Año" And col.FieldName <> "#") Then
                col.OptionsColumn.AllowEdit = False
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                col.Width = 150
                col.DisplayFormat.FormatString = "dddd"
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            ElseIf (col.FieldName = "#") Then
                DiseñoGrid.EstiloColumna(vwSemanas, "#", "", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 200, False, Nothing, "")
            End If
        Next
        lblTotalParesProceso.Text = String.Format("{0:N0}", vwSemanas.DataRowCount)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cursor = Cursors.WaitCursor
        If CInt(cbanio.Text) >= Date.Now.Year Then
            insertarDiasActualizados()
        Else
            show_message("Advertencia", "No puedes modificar dias de años anteriores")
        End If

        Cursor = Cursors.Default
    End Sub
    'Estadistica de ventas'
    Private Sub viewInventario_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs)
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub
    Private Sub insertarDiasActualizados()

        Dim cadena As String = String.Empty
        Dim myDatatView As DataTable


        Try
            myDatatView = CType(grdSemanas.DataSource, DataTable)
            Dim result = formaCadena(myDatatView)
            If result <> "EI" Then
                objInstancia.AgregarCalendarioSemana(result, cbanio.Text)
                consultarDatos()
                show_message("Exito", "Se Insertaron los registros")
                icanexit = True
            Else
                show_message("Advertencia", "Tienes dias con diferente año o los registros no coiciden con el año que seleccionaste")
            End If


        Catch ex As Exception
            show_message("ERROR", "Ocurrio un error comunicate con el departamento de TI para que lo resuelvan Gracias!!" & " " & ex.Message)
        End Try

    End Sub

    Private Function formaCadena(ByVal tabla As DataTable) As String

        Dim cadena As String = String.Empty
        Dim numeroFilas As Integer
        Dim ids As String = String.Empty

        numeroFilas = tabla.Rows.Count
        For index As Integer = 0 To numeroFilas - 1 Step 1
            Dim fecha = tabla.Rows(index).Item("Fecha").ToString() & "-A"
            Dim Dia = tabla.Rows(index).Item("Día").ToString() & "-B"
            Dim Semana = tabla.Rows(index).Item("Semana").ToString() & "-C"
            Dim Anio = tabla.Rows(index).Item("Año").ToString() & "-D"
            Dim Mes = tabla.Rows(index).Item("Mes").ToString() & "-F"
            Dim labora = (If(tabla.Rows(index).Item("Laborable").ToString() = "NO", 0, 1)) & "-G"
            If Anio = cbanio.Text & "-D" Then
                If fecha <> "-A" And Dia <> "-B" And Semana <> "-C" And Anio <> "-D" And Mes <> "-F" And labora <> "-G" Then
                    If cadena = String.Empty Then
                        cadena = cadena & fecha & "," & Dia & "," & Semana & "," & Anio & "," & Mes & "," & labora
                    Else
                        cadena = cadena & "#" & fecha & "," & Dia & "," & Semana & "," & Anio & "," & Mes & "," & labora
                    End If
                End If
            Else
                Return "EI"
            End If
        Next
        Return cadena

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

    'Private Sub vwModelos_CellValueChanged(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles vwSemanas.CellValueChanged
    '    data.Rows(vwSemanas.GetVisibleRowHandle(e.RowHandle)).Item(" ") = 1
    '    data.Rows(e.RowHandle).Item(e.Column.FieldName) = e.Value
    '    UpdateGridDataSource()
    'End Sub

    Private Sub UpdateGridDataSource()
        clone = data
        grdSemanas.BeginInvoke(New MethodInvoker(AddressOf AnonymousMethod1))
        data = clone
    End Sub
    Private Sub AnonymousMethod1()
        grdSemanas.DataSource = clone
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        consultarDatos()
        Cursor = Cursors.Default
    End Sub

    Private Sub AgregarCalendarioSemanalForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If icanexit = False Then
            Dim ventanaConfirmacion As New Tools.ConfirmarForm
            ventanaConfirmacion.mensaje = "Hay datos sin guardar ¿Está seguro que deseas salir?"
            ventanaConfirmacion.ShowDialog()
            If ventanaConfirmacion.DialogResult <> DialogResult.OK Then
                e.Cancel = True
            End If

        End If
    End Sub

    Private Sub vwSemanas_customCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles vwSemanas.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        'If (e.RowHandle = currentView.FocusedRowHandle) Then Return

        Try
            Cursor = Cursors.WaitCursor

            If e.Column.FieldName = "Año" Then
                If e.CellValue <> cbanio.Text Then
                    e.Appearance.ForeColor = Color.Red
                    anioErroneo = True
                Else
                    anioErroneo = False
                End If
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cbanio_TextChanged(sender As Object, e As EventArgs) Handles cbanio.TextChanged
        consultarDatos()
    End Sub
End Class