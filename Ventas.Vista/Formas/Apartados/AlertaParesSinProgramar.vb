Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class AlertaParesSinProgramar
    Private objNegociosAlerta As Framework.Negocios.AlertasBU
    Private Sub AlertaParesSinProgramar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarGrid()
    End Sub

    Private Sub cargarGrid()
        objNegociosAlerta = New Framework.Negocios.AlertasBU
        Dim dtAlerta As New DataTable
        lblHoraEnvioAlerta.Text = Date.Now.ToString
        Me.Cursor = Cursors.WaitCursor
        Try
            dtAlerta = objNegociosAlerta.alertaParesSinProgramar()
            grdParesTallaPedido.DataSource = dtAlerta
            grdVParesTallaPedido.OptionsView.AllowHtmlDrawHeaders = True
            grdVParesTallaPedido.ColumnPanelRowHeight = 50
            grdVParesTallaPedido.OptionsView.BestFitMaxRowCount = -1
            grdVParesTallaPedido.OptionsView.ColumnAutoWidth = True
            grdVParesTallaPedido.BestFitColumns()
            grdVParesTallaPedido.IndicatorWidth = 30
            grdVParesTallaPedido.OptionsView.EnableAppearanceEvenRow = True
            grdVParesTallaPedido.OptionsView.EnableAppearanceOddRow = True
            grdVParesTallaPedido.OptionsSelection.EnableAppearanceFocusedCell = True
            grdVParesTallaPedido.OptionsSelection.EnableAppearanceFocusedRow = True
            grdVParesTallaPedido.Appearance.SelectedRow.Options.UseBackColor = True
            grdVParesTallaPedido.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)
            grdVParesTallaPedido.Appearance.EvenRow.BackColor = Color.White
            grdVParesTallaPedido.Appearance.OddRow.BackColor = SystemColors.ActiveCaption
            grdVParesTallaPedido.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
            grdVParesTallaPedido.Appearance.FocusedRow.ForeColor = Color.White
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVParesTallaPedido.Columns
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                col.OptionsColumn.AllowEdit = False
            Next
            grdVParesTallaPedido.Columns.ColumnByFieldName("PedidoSAY").Caption = "Pedido" & vbCrLf & "SAY"
            grdVParesTallaPedido.Columns.ColumnByFieldName("PedidoSICY").Caption = "Pedido" & vbCrLf & "SICY"
            grdVParesTallaPedido.Columns.ColumnByFieldName("FProgramación").Caption = "Fecha" & vbCrLf & "Programación"
            grdVParesTallaPedido.Columns.ColumnByFieldName("EstatusPartida").Caption = "Estatus" & vbCrLf & "Partida"
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesPedido").Caption = "Pares" & vbCrLf & "Pedido"
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesApartado").Caption = "Pares" & vbCrLf & "Apartados"
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesCorrectoPorProgramar").Caption = "Pares Correctos" & vbCrLf & "Por Programar"
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesApartadSICY").Caption = "Pares" & vbCrLf & "Apartados SICY"
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesXProgramarSICY").Caption = "Pares" & vbCrLf & "Por Programar SICY"
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesProgramadosReal").Caption = "Pares" & vbCrLf & "Programados Real"
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesPendientes").Caption = "Pares Pendientes" & vbCrLf & "Por Programar"
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesPedido").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesPedido").DisplayFormat.FormatString = "N0"
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesApartado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesApartado").DisplayFormat.FormatString = "N0"
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesCorrectoPorProgramar").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesCorrectoPorProgramar").DisplayFormat.FormatString = "N0"
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesApartadSICY").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesApartadSICY").DisplayFormat.FormatString = "N0"
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesXProgramarSICY").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesXProgramarSICY").DisplayFormat.FormatString = "N0"
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesProgramadosReal").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesProgramadosReal").DisplayFormat.FormatString = "N0"
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesPendientes").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesPendientes").DisplayFormat.FormatString = "N0"
            grdVParesTallaPedido.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesCorrectoPorProgramar").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesCorrectoPorProgramar").SummaryItem.DisplayFormat = "{0:N0}"
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesApartadSICY").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesApartadSICY").SummaryItem.DisplayFormat = "{0:N0}"
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesXProgramarSICY").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesXProgramarSICY").SummaryItem.DisplayFormat = "{0:N0}"
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesProgramadosReal").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesProgramadosReal").SummaryItem.DisplayFormat = "{0:N0}"
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesPendientes").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            grdVParesTallaPedido.Columns.ColumnByFieldName("ParesPendientes").SummaryItem.DisplayFormat = "{0:N0}"
        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            ExportarAExcel(grdVParesTallaPedido, "AlertaParesSinProgramar")
        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try
    End Sub

    Public Sub ExportarAExcel(Grid As DevExpress.XtraGrid.Views.Grid.GridView, NombreArchivo As String)
        'PREGUNTA AL USUARIO DONDE GUARDAR EL ARCHIVO
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
        SaveFileDialog.FilterIndex = 2
        SaveFileDialog.RestoreDirectory = True

        'ASIGNAMOS UN NOMBRE AL ARCHIVO
        SaveFileDialog.FileName = NombreArchivo + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString + ".xlsx"
        If Grid.RowCount > 0 Then
            If SaveFileDialog.ShowDialog = DialogResult.OK Then

                'ESTO ES NECESARIO PARA QUE EL EXCEL NO HAGA QUE TODAS LAS CUADRICULAS SEAN MUY PEQUEÑAS.
                'ESTO EXPORTARÁ TODAS LAS CUADRICULAS ESPACIADAS UNIFORMENTE.
                Grid.OptionsPrint.AutoWidth = False
                Grid.OptionsPrint.UsePrintStyles = False
                'Grid.OptionsPrint.EnableAppearanceEvenRow = True
                'Grid.OptionsPrint.EnableAppearanceOddRow = True
                'Grid.OptionsPrint.PrintHorzLines = False
                'Grid.OptionsPrint.PrintVertLines = False

                'Grid.OptionsPrint.PrintPreview = True

                Dim FileName As String = SaveFileDialog.FileName

                'Dim exportOptions = New DevExpress.XtraPrinting.XlsxExportOptionsEx
                'exportOptions.AllowConditionalFormatting = True
                'exportOptions.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True
                'exportOptions.ExportType = DevExpress.Export.ExportType.DataAware
                DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG
                Grid.ExportToXlsx(FileName)


                Dim msg_Exito As New Tools.ExitoForm
                msg_Exito.mensaje = "Los datos se exportaron correctamente."
                msg_Exito.ShowDialog()
                System.Diagnostics.Process.Start(FileName)
            End If
        Else
            Dim msg_Adv As New Tools.AdvertenciaForm
            msg_Adv.mensaje = "No hay registros para exportar."
            msg_Adv.ShowDialog()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        cargarGrid()
    End Sub

    Private Sub grdVParesTallaPedido_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles grdVParesTallaPedido.CustomDrawCell
        'Dim currentView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)
        If e.Column.FieldName = "ParesPendientes" Then
            e.Appearance.ForeColor = Color.Red
        End If
    End Sub

    Private Sub grdVParesTallaPedido_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdVParesTallaPedido.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

End Class