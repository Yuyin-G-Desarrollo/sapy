Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools
Public Class ReporteDeInventarioForm
    Dim ObjBU As New Negocios.ReporteDeInventarioBU
    Dim clone As DataTable
    Private data As DataTable
    Friend WithEvents viewInspeccion As DevExpress.XtraGrid.Views.Grid.GridView
    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        pgrGenerarDatos.Visible = True
        consultarDatos.RunWorkerAsync()
    End Sub

    Private Sub ReporteDeInventarioForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        btnExportarExcel.Enabled = False
        clone = grdInventario.DataSource
        Control.CheckForIllegalCrossThreadCalls = False
        consultarDatos.RunWorkerAsync()
        'Cursor = Cursors.WaitCursor
        'CargarInventario()
        'Cursor = Cursors.Default
    End Sub

    Private Sub CargarDatosv2()
        Dim DatosInventario = ObjBU.ConsultaDeReporteInventario()
        pgrGenerarDatos.Show()
        Dim entidad = ObjBU.ConsultaDeReporteInventario()
        data = entidad.Datos
        lblTotalPares.Text = String.Format("{0:N0}", DatosInventario.TotalPares)
        lblParesSinPrecio.Text = String.Format("{0:N0}", DatosInventario.ParesSiPrecio)
        If DatosInventario.ParesSiPrecio > 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Hay Articulos con precio en 0 favor de comunicarse con TI")
        End If
        UpdateGridDataSource()
    End Sub

    Private Sub UpdateGridDataSource()
        clone = data.Copy()
        grdInventario.BeginInvoke(New MethodInvoker(AddressOf AnonymousMethod1))
        data = clone
    End Sub

    Private Sub AnonymousMethod1()
        grdInventario.DataSource = clone
    End Sub




    Private Sub CargarInventario()
        Dim DatosInventario = ObjBU.ConsultaDeReporteInventario()
        If IsNothing(DatosInventario.Datos) Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontraron datos.")
            btnExportarExcel.Enabled = False
            grdInventario.DataSource = DatosInventario.Datos
            lblTotalPares.Text = DatosInventario.TotalPares.ToString()
        Else
            grdInventario.DataSource = DatosInventario.Datos
            DiseñoGrid.DiseñoBaseGrid(viewInventario)
            viewInventario.IndicatorWidth = 35
            'viewInventario.OptionsView.ColumnAutoWidth = False
            DiseñoGrid.EstiloColumna(viewInventario, "Clave Producto", "Clave Producto", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInventario, "Marca", "Marca", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInventario, "Colección", "Coleccion", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInventario, "Modelo", "Modelo", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInventario, "Corrida", "Corrida", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, False, 150, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInventario, "Cliente", "Cliente", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 80, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInventario, "Pares", "Pares", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 75, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
            DiseñoGrid.EstiloColumna(viewInventario, "Precio Base", "Precio Base", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 75, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInventario, "Total", "Total", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
            lblTotalPares.Text = String.Format("{0:N0}", DatosInventario.TotalPares)
            lblParesSinPrecio.Text = String.Format("{0:N0}", DatosInventario.ParesSiPrecio)
            If DatosInventario.ParesSiPrecio > 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Hay Articulos con precio en 0 favor de comunicarse con TI")
            End If
            lblFechaUltimaActualizacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()
            btnExportarExcel.Enabled = True
        End If
    End Sub




    Private Sub viewInventario_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewInventario.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub
    Private Sub ExportarExcel()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog


        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                Dim exportOptions = New DevExpress.XtraPrinting.XlsxExportOptionsEx()
                AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then
                    If GridView1.GroupCount > 0 Then
                        grdInventario.ExportToXlsx(.SelectedPath + "\ReporteInventario_" + fecha_hora + ".xlsx", exportOptions)
                    Else
                        grdInventario.ExportToXlsx(.SelectedPath + "\ReporteInventario_" + fecha_hora + ".xlsx", exportOptions)
                    End If
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "Datos_ReporteInventario_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\ReporteInventario_" + fecha_hora + ".xlsx")
                End If
            End With

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

        Dim precioBase As String = viewInventario.GetRowCellValue(e.RowHandle, "Precio Base")


        Try
            If e.RowHandle >= 0 Then
                If e.AreaType <> DevExpress.Export.SheetAreaType.Header Then
                    If precioBase = 0 Then
                        e.Formatting.Font.Color = Color.White
                        e.Formatting.BackColor = Color.Red
                    End If
                End If

            End If

        Catch ex As Exception

        End Try

        e.Handled = True
    End Sub



    Private Sub viewInventario_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles viewInventario.CustomDrawCell

        Dim PrecioBase As Integer = viewInventario.GetRowCellValue(e.RowHandle, "Precio Base")

        Cursor = Cursors.WaitCursor
        Try
            If e.RowHandle >= 0 Then
                If PrecioBase = 0 Then
                    e.Appearance.ForeColor = Color.Red
                    If e.Column.FieldName = "Precio Base" Then
                        If PrecioBase = 0 Then
                            e.Appearance.BackColor = Color.Red
                            e.Appearance.ForeColor = Color.White
                        End If
                    End If
                End If
                If e.Column.FieldName = "Pares" Then
                    e.Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    e.Column.DisplayFormat.FormatString = "N0"
                End If
                If e.Column.FieldName = "Total" Then
                    e.Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    e.Column.DisplayFormat.FormatString = "N0"
                End If

                Cursor = Cursors.Default
            End If

        Catch ex As Exception
            Cursor = Cursors.Default

        End Try
    End Sub
    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Cursor = Cursors.WaitCursor
        ExportarExcel()
        Cursor = Cursors.Default
    End Sub

    Private Sub consultarDatos_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles consultarDatos.DoWork
        CargarDatosv2()
    End Sub

    Private Sub consultarDatos_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles consultarDatos.RunWorkerCompleted
        DiseñoGrid.DiseñoBaseGrid(viewInventario)
        viewInventario.IndicatorWidth = 35
        viewInventario.OptionsView.ColumnAutoWidth = True
        DiseñoGrid.EstiloColumna(viewInventario, "IdTalla", "Pares", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 200, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
        DiseñoGrid.EstiloColumna(viewInventario, "Pares", "Pares", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 100, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
        DiseñoGrid.EstiloColumna(viewInventario, "Total", "Total", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
        DiseñoGrid.EstiloColumna(viewInventario, "Precio Base", "Precio Base", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 120, False, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
        lblFechaUltimaActualizacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()
        btnExportarExcel.Enabled = True
        pgrGenerarDatos.Visible = False

    End Sub
End Class