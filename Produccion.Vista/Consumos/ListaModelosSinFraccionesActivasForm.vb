Public Class ListaModelosSinFraccionesActivasForm
    Public tblModelos As New DataTable
    Private Sub ListaModelosSinFraccionesActivasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgModelos.DataSource = Nothing
        If tblModelos.Rows.Count > 0 Then
            dgModelos.DataSource = tblModelos
            disenioGrid()
            ActualizarRegistros()
        End If
    End Sub

    Private Sub disenioGrid()
        dgVModelos.IndicatorWidth = 40
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In dgVModelos.Columns
            col.OptionsColumn.AllowEdit = False
        Next
        Tools.DiseñoGrid.AlternarColorEnFilasTenue(dgVModelos)
        Tools.DiseñoGrid.AjustarAnchoColumnas(dgVModelos)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub ActualizarRegistros()
        lblTotalRegistros.Text = dgVModelos.RowCount
    End Sub

    Private Sub dgVModelos_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles dgVModelos.CustomDrawRowIndicator
        If (e.RowHandle >= 0) Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString
        End If
    End Sub
End Class