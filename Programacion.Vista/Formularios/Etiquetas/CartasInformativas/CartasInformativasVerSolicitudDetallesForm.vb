Imports DevExpress.XtraGrid
Imports Programacion.Negocios
Imports Tools

Public Class CartasInformativasVerSolicitudDetallesForm
    Public folio As Integer
    Private Sub CartasInformativasVerSolicitudesDetallesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim obj As New CartasInformativasBU
        Dim tblSolicitudDetalle As New DataTable

        Me.Cursor = Cursors.WaitCursor
        tblSolicitudDetalle = obj.consultaFolioSolicitudDetalle(folio)
        If tblSolicitudDetalle.Rows.Count > 0 Then
            grdSolicitudDetalle.DataSource = tblSolicitudDetalle
            disenioGrid()
            lblTotalRegistros.Text = tblSolicitudDetalle.Rows.Count.ToString("n0")
        Else
            grdVSolicitudDetalle.Columns.Clear()
            'Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Nuevo Mensaje.")
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub disenioGrid()
        Dim gridFormatRule As New GridFormatRule()
        Dim formatConditionRuleExpression As New DevExpress.XtraEditors.FormatConditionRuleExpression()

        grdVSolicitudDetalle.IndicatorWidth = 40
        grdVSolicitudDetalle.BestFitColumns()

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVSolicitudDetalle.Columns
            col.OptionsColumn.AllowEdit = False
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
        Next

        grdVSolicitudDetalle.OptionsView.EnableAppearanceEvenRow = True
        grdVSolicitudDetalle.OptionsView.EnableAppearanceOddRow = True
        grdVSolicitudDetalle.OptionsSelection.EnableAppearanceFocusedCell = True
        grdVSolicitudDetalle.OptionsSelection.EnableAppearanceFocusedRow = True
        grdVSolicitudDetalle.Appearance.SelectedRow.Options.UseBackColor = True
        grdVSolicitudDetalle.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVSolicitudDetalle.Appearance.EvenRow.BackColor = Color.White
        grdVSolicitudDetalle.Appearance.OddRow.BackColor = SystemColors.ActiveCaption
        grdVSolicitudDetalle.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVSolicitudDetalle.Appearance.FocusedRow.ForeColor = Color.White
    End Sub

    Private Sub grdVSolicitudDetalle_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdVSolicitudDetalle.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString + 1
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class