Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Tools.modMensajes

Public Class Produccion_Suela_ConcentradoSuela_Form

    Public FechaInicioReporte As String
    Public FechaFinReporte As String
    Public ProveedorSuela As Integer

    Private Sub Produccion_Suela_ConcentradoSuela_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        lblFechaDe.Text = FechaInicioReporte
        lblFechaA.Text = FechaFinReporte

        Cursor = Cursors.WaitCursor

        Dim dtResultadoReporte As New DataTable
        Dim objBU As New Negocios.TarjetaProduccionSuelasBU

        dtResultadoReporte = objBU.ObtenerConcentradoTarjetasProduccionSuelas(FechaInicioReporte, FechaFinReporte, ProveedorSuela)

        grdConcentradoTarjetas.DataSource = dtResultadoReporte

        diseñoGrid()


        Cursor = Cursors.Default

    End Sub

    Private Sub MVTarjeta_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles MVConcentradoSuelas.RowStyle
        Dim View As GridView = sender
        If e.RowHandle >= 0 Then
            If (e.RowHandle Mod 2 > 0) Then
                e.Appearance.BackColor = Color.LightSteelBlue
            End If
        End If

    End Sub

    Private Sub MVTarjeta_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles MVConcentradoSuelas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Public Sub diseñoGrid()

        MVConcentradoSuelas.OptionsView.ColumnAutoWidth = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In MVConcentradoSuelas.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
            col.Width = 60
        Next

        MVConcentradoSuelas.Columns.ColumnByFieldName("Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVConcentradoSuelas.Columns.ColumnByFieldName("Total").DisplayFormat.FormatString = "N0"

        MVConcentradoSuelas.Columns.ColumnByFieldName("Lotes").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVConcentradoSuelas.Columns.ColumnByFieldName("Lotes").DisplayFormat.FormatString = "N0"

        If MVConcentradoSuelas.Columns.Contains(MVConcentradoSuelas.Columns.ColumnByFieldName("#")) Then
            MVConcentradoSuelas.Columns.ColumnByFieldName("#").Width = 80
        End If
        MVConcentradoSuelas.Columns.ColumnByFieldName("Lotes").Width = 100
        MVConcentradoSuelas.Columns.ColumnByFieldName("Consumo").Width = 500
        MVConcentradoSuelas.Columns.ColumnByFieldName("Corrida").Width = 100
        MVConcentradoSuelas.Columns.ColumnByFieldName("Total").Width = 150
        MVConcentradoSuelas.Columns.ColumnByFieldName("Nave").Width = 200

        MVConcentradoSuelas.OptionsView.ShowAutoFilterRow = True
        MVConcentradoSuelas.IndicatorWidth = 35

        MVConcentradoSuelas.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        If IsNothing(MVConcentradoSuelas.Columns("Total").Summary.FirstOrDefault(Function(x) x.FieldName = "Total")) = True Then
            MVConcentradoSuelas.Columns("Total").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Total"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            MVConcentradoSuelas.GroupSummary.Add(item)
        End If
        If IsNothing(MVConcentradoSuelas.Columns("Lotes").Summary.FirstOrDefault(Function(x) x.FieldName = "Lotes")) = True Then
            MVConcentradoSuelas.Columns("Lotes").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Lotes", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Lotes"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            MVConcentradoSuelas.GroupSummary.Add(item)
        End If

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If MVConcentradoSuelas.DataRowCount > 0 Then
                nombreReporte = "Produccion_Suelas_ConcentradoSuela_" + Replace(FechaInicioReporte, "/", "_") + "_" + Replace(FechaFinReporte, "/", "_") + "_"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If MVConcentradoSuelas.GroupCount > 0 Then
                            MVConcentradoSuelas.ExportToXlsx(.SelectedPath + "/" + nombreReporte + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                            MVConcentradoSuelas.ExportToXlsx(.SelectedPath + "/" + nombreReporte + ".xlsx", exportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "/" + nombreReporte + ".xlsx")
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