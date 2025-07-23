Imports DevExpress.Utils

Public Class DevolucionCliente_CapturaGeneral_PartidasPrecioCero
    Public dtDetalles As New DataTable

    Public Sub FormatoGrid()
        bgvPrecioCero.OptionsView.ColumnAutoWidth = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvPrecioCero.Columns
            If col.FieldName <> " " Then
                col.OptionsColumn.AllowEdit = False
                col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            End If
        Next
        bgvPrecioCero.BestFitColumns()
        bgvPrecioCero.IndicatorWidth = 40
        bgvPrecioCero.Columns.ColumnByFieldName(" ").Visible = False
        bgvPrecioCero.Columns.ColumnByFieldName("IdDetalle").Visible = False
    End Sub
    Private Sub DevolucionCliente_CapturaGeneral_PartidasPrecioCero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdPrecioCero.DataSource = dtDetalles
        FormatoGrid()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub bgvPrecioCero_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvPrecioCero.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
End Class