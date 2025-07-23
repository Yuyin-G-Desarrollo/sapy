Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class DetallesTarjetaProduccionSuelas_Form

    Public TarjetasId As String = String.Empty

    Private Sub DetallesTarjetaProduccionSuelas_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim objBu As New Negocios.TarjetaProduccionSuelasBU
        Dim dtResultado As New DataTable
        Dim objMensaje As New AdvertenciaForm

        dtResultado = objBu.ObtenerDetallesTarjetasProduccionSuelas(TarjetasId)

        If dtResultado.Rows.Count() > 0 Then
            grdDetallesTarjeta.DataSource = dtResultado
            diseñoGrid()
        Else
            objMensaje.mensaje = "No hay datos para mostrar."
            objMensaje.ShowDialog()
        End If


    End Sub

    Private Sub MVTarjeta_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles MVDetallesTarjetas.RowStyle
        Dim View As GridView = sender
        If e.RowHandle >= 0 Then
            If (e.RowHandle Mod 2 > 0) Then
                e.Appearance.BackColor = Color.LightSteelBlue
            End If
        End If

    End Sub

    Private Sub MVTarjeta_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles MVDetallesTarjetas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Public Sub diseñoGrid()

        MVDetallesTarjetas.OptionsView.ColumnAutoWidth = False

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In MVDetallesTarjetas.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
            col.Width = 60
        Next

        MVDetallesTarjetas.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVDetallesTarjetas.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatString = "N0"

        MVDetallesTarjetas.Columns.ColumnByFieldName("ID").Width = 100
        MVDetallesTarjetas.Columns.ColumnByFieldName("Consecutivo").Width = 80
        MVDetallesTarjetas.Columns.ColumnByFieldName("No. Agrupado").Width = 80
        MVDetallesTarjetas.Columns.ColumnByFieldName("Artículo").Width = 400
        MVDetallesTarjetas.Columns.ColumnByFieldName("Suela").Width = 400
        MVDetallesTarjetas.Columns.ColumnByFieldName("Consumo").Width = 400

        MVDetallesTarjetas.OptionsView.ShowAutoFilterRow = True
        MVDetallesTarjetas.IndicatorWidth = 35

        MVDetallesTarjetas.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        If IsNothing(MVDetallesTarjetas.Columns("Pares").Summary.FirstOrDefault(Function(x) x.FieldName = "Pares")) = True Then
            MVDetallesTarjetas.Columns("Pares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pares"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            MVDetallesTarjetas.GroupSummary.Add(item)
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If MVDetallesTarjetas.DataRowCount > 0 Then
                nombreReporte = "Produccion_Suelas_DetallesTarjetasProduccion_"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If MVDetallesTarjetas.GroupCount > 0 Then
                            MVDetallesTarjetas.ExportToXlsx(.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                            MVDetallesTarjetas.ExportToXlsx(.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo")
        End Try
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        If (e.RowHandle Mod 2 > 0) Then
            e.Formatting.BackColor = Color.LightSteelBlue
        End If

        e.Handled = True

    End Sub

End Class