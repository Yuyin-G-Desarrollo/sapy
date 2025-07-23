Imports DevExpress.XtraGrid
Imports Programacion.Negocios
Imports Tools
Public Class CartasInformativasReporteFoliosForm
    'Cambio

    Private Sub CartasInformativasReporteFoliosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaDel.Value = Date.Now
        dtpFechaAl.Value = Date.Now
        llenarCombo()
    End Sub

    Private Sub llenarCombo()
        cboNaves = Tools.Controles.ComboNavesSegunUsuario(cboNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim obj As New CartasInformativasBU
        Dim tblReporteFolios As New DataTable
        Dim fechaDel As Date = dtpFechaDel.Value
        Dim fechaAl As Date = dtpFechaAl.Value
        Dim detalle As Integer = 0
        Try
            grdReporteFolios.DataSource = Nothing
            grdVWReporteFolios.Columns.Clear()

            Me.Cursor = Cursors.WaitCursor

            If chkDetalle.Checked Then
                detalle = 1
            Else
                detalle = 0
            End If

            tblReporteFolios = obj.ConsultarFoliosAutorizados(cboNaves.SelectedValue, fechaDel, fechaAl, detalle)

            If tblReporteFolios.Rows.Count > 0 Then
                grdReporteFolios.DataSource = tblReporteFolios
                disenioGrid()
                ActualizarRegistrosyFecha()
            Else
                lblTotalRegistros.Text = "0"
                lblActualizacion.Text = Date.Now
                grdVWReporteFolios.Columns.Clear()
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontraron folios en el rago de fecha seleccionado")
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub ActualizarRegistrosyFecha()
        lblTotalRegistros.Text = grdVWReporteFolios.DataRowCount.ToString("n0")
        lblActualizacion.Text = Date.Now
    End Sub

    Private Sub disenioGrid()
        Dim gridFormatRule As New GridFormatRule()
        Dim formatConditionRuleExpression As New DevExpress.XtraEditors.FormatConditionRuleExpression()

        grdVWReporteFolios.IndicatorWidth = 40
        grdVWReporteFolios.BestFitColumns()

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVWReporteFolios.Columns
            col.OptionsColumn.AllowEdit = False
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
        Next

        grdVWReporteFolios.OptionsView.EnableAppearanceEvenRow = True
        grdVWReporteFolios.OptionsView.EnableAppearanceOddRow = True
        grdVWReporteFolios.OptionsSelection.EnableAppearanceFocusedCell = True
        grdVWReporteFolios.OptionsSelection.EnableAppearanceFocusedRow = True
        grdVWReporteFolios.Appearance.SelectedRow.Options.UseBackColor = True
        grdVWReporteFolios.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVWReporteFolios.Appearance.EvenRow.BackColor = Color.White
        grdVWReporteFolios.Appearance.OddRow.BackColor = SystemColors.ActiveCaption
        grdVWReporteFolios.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVWReporteFolios.Appearance.FocusedRow.ForeColor = Color.White

    End Sub

    Private Sub dtpFechaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaDel.ValueChanged
        dtpFechaAl.MinDate = dtpFechaDel.Value
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub grdVWReporteFolios_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdVWReporteFolios.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Tools.Excel.ExportarExcel(grdVWReporteFolios, "Reporte de Folios Cartas Informativas")
    End Sub

End Class