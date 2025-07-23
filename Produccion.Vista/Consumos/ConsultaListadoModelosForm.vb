Imports Entidades
Imports Infragistics.Win.UltraWinGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraPrinting
Imports Produccion.Negocios
Imports Infragistics.Documents.Excel

Public Class ConsultaListadoModelosForm
    Public idNave As Integer = 0
    Public UsuarioIngresaID As Integer = 0
    Public IdNaveAlta As Integer = -1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ConsultaListadoModelosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UsuarioIngresaID = SesionUsuario.UsuarioSesion.PUserUsuarioid
        llenarGrid(UsuarioIngresaID)
    End Sub

    Private Sub llenarGrid(ByVal UsuarioID As Integer)
        Dim objBU As New ConsumosBU

        grdModelos.DataSource = objBU.listadoProductosNave(UsuarioID)
        vwReporte.OptionsView.ColumnAutoWidth = True

        Try

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Next

            vwReporte.Columns.ColumnByFieldName("ID").Visible = False
            vwReporte.Columns.ColumnByFieldName("productoEstiloId").Visible = False
            vwReporte.Columns.ColumnByFieldName("ProductoId").Visible = False
            vwReporte.Columns.ColumnByFieldName("EstiloProductoId").Visible = False
            vwReporte.Columns.ColumnByFieldName("idMarca").Visible = False
            vwReporte.Columns.ColumnByFieldName("idColeccion").Visible = False
            vwReporte.Columns.ColumnByFieldName("idPiel").Visible = False
            vwReporte.Columns.ColumnByFieldName("idColor").Visible = False
            vwReporte.Columns.ColumnByFieldName("idCliente").Visible = False
            vwReporte.Columns.ColumnByFieldName("idTalla").Visible = False
            vwReporte.Columns.ColumnByFieldName("Ruta").Visible = False

            vwReporte.Columns.ColumnByFieldName("Nave").OptionsColumn.AllowEdit = False
            vwReporte.Columns.ColumnByFieldName("Codigo").OptionsColumn.AllowEdit = False
            vwReporte.Columns.ColumnByFieldName("Marca").OptionsColumn.AllowEdit = False
            vwReporte.Columns.ColumnByFieldName("Coleccion").OptionsColumn.AllowEdit = False
            vwReporte.Columns.ColumnByFieldName("Modelo").OptionsColumn.AllowEdit = False
            vwReporte.Columns.ColumnByFieldName("ModeloSICY").OptionsColumn.AllowEdit = False
            vwReporte.Columns.ColumnByFieldName("PielColor").OptionsColumn.AllowEdit = False
            vwReporte.Columns.ColumnByFieldName("Corrida").OptionsColumn.AllowEdit = False
            vwReporte.Columns.ColumnByFieldName("Horma").OptionsColumn.AllowEdit = False
            vwReporte.Columns.ColumnByFieldName("Temporada").OptionsColumn.AllowEdit = False
            vwReporte.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowEdit = False

        Catch ex As Exception
        End Try
    End Sub
    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    'ESTA FUNCION ES PARA VERIFICAR QUE EXISTA INFORMACION DESDE EL MDIPARENT
    Public Function verificarInformacion(ByVal UsuarioID As Integer) As Integer
        Dim tbl_ListadoModelos As DataTable
        Dim objBU As New ConsumosBU
        Dim tieneDatos As Integer = 0

        tbl_ListadoModelos = objBU.listadoProductosNave(UsuarioID)

        If tbl_ListadoModelos.Rows.Count > 0 Then
            tieneDatos = 1
        End If
        Return tieneDatos
    End Function

    Private Sub btn_ExportarFracciones_Click(sender As Object, e As EventArgs) Handles btn_ExportarFracciones.Click
        If vwReporte.RowCount > 0 Then
            exportarModelos()
        End If
    End Sub

    Private Sub exportarModelos()
        Dim sfd As New SaveFileDialog
        Dim tablaDatos As DataTable
        Dim workbook As New Infragistics.Documents.Excel.Workbook
        Dim worksheet As Infragistics.Documents.Excel.Worksheet = workbook.Worksheets.Add("Modelos")

        'tbaFracciones = recorrerYgenerarNuevaTablaFracciones()

        sfd.DefaultExt = "xls"
        sfd.Filter = "Excel Files|*.xls"

        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor

                'ultExportGrid.Export(recorrerYgenerarNuevaTablaFracciones(), fileName)

                tablaDatos = recorrerYgenerarNuevaTablaModelos()

                worksheet.Columns.Item(0).Width = 3650
                worksheet.Columns.Item(1).Width = 3650
                worksheet.Columns.Item(2).Width = 2920
                worksheet.Columns.Item(3).Width = 2920
                worksheet.Columns.Item(4).Width = 2920
                worksheet.Columns.Item(5).Width = 2920
                worksheet.Columns.Item(6).Width = 2920
                worksheet.Columns.Item(7).Width = 4650
                worksheet.Columns.Item(8).Width = 2920
                worksheet.Columns.Item(9).Width = 4650
                worksheet.Columns.Item(10).Width = 4650

                Dim inicio As Integer = 0

                worksheet.Rows.Item(inicio).Cells.Item(0).Value = tablaDatos.Columns(0).ColumnName.ToString()
                worksheet.Rows.Item(inicio).Cells.Item(1).Value = tablaDatos.Columns(1).ColumnName.ToString()
                worksheet.Rows.Item(inicio).Cells.Item(2).Value = tablaDatos.Columns(2).ColumnName.ToString()
                worksheet.Rows.Item(inicio).Cells.Item(3).Value = tablaDatos.Columns(3).ColumnName.ToString()
                worksheet.Rows.Item(inicio).Cells.Item(4).Value = tablaDatos.Columns(4).ColumnName.ToString()
                worksheet.Rows.Item(inicio).Cells.Item(5).Value = tablaDatos.Columns(5).ColumnName.ToString()
                worksheet.Rows.Item(inicio).Cells.Item(6).Value = tablaDatos.Columns(6).ColumnName.ToString()
                worksheet.Rows.Item(inicio).Cells.Item(7).Value = tablaDatos.Columns(7).ColumnName.ToString()
                worksheet.Rows.Item(inicio).Cells.Item(8).Value = tablaDatos.Columns(8).ColumnName.ToString()
                worksheet.Rows.Item(inicio).Cells.Item(9).Value = tablaDatos.Columns(9).ColumnName.ToString()
                worksheet.Rows.Item(inicio).Cells.Item(10).Value = tablaDatos.Columns(10).ColumnName.ToString()

                For r As Integer = (0) To tablaDatos.Rows.Count - 1
                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = tablaDatos.Rows(r).Item("Nave").ToString()
                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(1).Value = tablaDatos.Rows(r).Item("Codigo").ToString()
                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = tablaDatos.Rows(r).Item("Marca").ToString()
                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(3).Value = tablaDatos.Rows(r).Item("Coleccion").ToString()
                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(4).Value = tablaDatos.Rows(r).Item("Modelo").ToString()
                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(5).Value = tablaDatos.Rows(r).Item("ModeloSICY").ToString()
                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = tablaDatos.Rows(r).Item("PielColor").ToString()
                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(7).Value = tablaDatos.Rows(r).Item("Corrida").ToString()
                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(8).Value = tablaDatos.Rows(r).Item("Horma").ToString()
                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(9).Value = tablaDatos.Rows(r).Item("Temporada").ToString()
                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(10).Value = tablaDatos.Rows(r).Item("Cliente").ToString()
                Next

                For i As Int16 = inicio To inicio Step 1
                    For j As Int16 = 0 To 10 Step 1
                        worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.LightGray), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                        worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                        worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                        worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                    Next
                Next

                For i As Int16 = 0 To tablaDatos.Rows.Count - 1 Step 1
                    For j As Int16 = 0 To 10 Step 1

                        worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                        worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                        worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                    Next
                Next


                workbook.Save(fileName)

                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()
                Process.Start(fileName)
            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm
                objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Function recorrerYgenerarNuevaTablaModelos()
        Dim tablaModelos As New DataTable
        Dim tablaGridModelos As DataTable

        tablaModelos.Columns.Add("Nave")
        tablaModelos.Columns.Add("Codigo")
        tablaModelos.Columns.Add("Marca")
        tablaModelos.Columns.Add("Coleccion")
        tablaModelos.Columns.Add("Modelo")
        tablaModelos.Columns.Add("ModeloSICY")
        tablaModelos.Columns.Add("PielColor")
        tablaModelos.Columns.Add("Corrida")
        tablaModelos.Columns.Add("Horma")
        tablaModelos.Columns.Add("Temporada")
        tablaModelos.Columns.Add("Cliente")
        tablaGridModelos = grdModelos.DataSource
        For i As Integer = 0 To tablaGridModelos.Rows.Count - 1
            If tablaGridModelos.Rows(i).Item("Nave").ToString() <> "" Then
                tablaModelos.Rows.Add(New Object() {tablaGridModelos.Rows(i).Item("Nave").ToString(), tablaGridModelos.Rows(i).Item("Codigo").ToString(), tablaGridModelos.Rows(i).Item("Marca").ToString(), tablaGridModelos.Rows(i).Item("Coleccion").ToString(), tablaGridModelos.Rows(i).Item("Modelo").ToString(), tablaGridModelos.Rows(i).Item("ModeloSICY").ToString(), tablaGridModelos.Rows(i).Item("PielColor").ToString(), tablaGridModelos.Rows(i).Item("Corrida").ToString(), tablaGridModelos.Rows(i).Item("Horma").ToString(), tablaGridModelos.Rows(i).Item("Temporada").ToString(), tablaGridModelos.Rows(i).Item("Cliente").ToString()})
            End If
        Next
        Return tablaModelos
    End Function

End Class