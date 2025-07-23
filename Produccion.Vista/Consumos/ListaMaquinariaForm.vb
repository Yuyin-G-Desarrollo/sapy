Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid

Public Class ListaMaquinariaForm
    Public idMaquinaria As Integer
    Public descripcionMaquina As String
    Private Sub Maquinaría_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obj As New ConsumosBU
        grdMaquina.DataSource = obj.getMaquinaria
        With grdMaquina.DisplayLayout.Bands(0)
            .Columns("ID").Width = 20
        End With

        grdMaquina.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdMaquina.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    End Sub

    Private Sub grdMaquina_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles grdMaquina.ClickCell
        Try
            grdMaquina.ActiveRow.Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdMaquina_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles grdMaquina.DoubleClickCell
        Try
            idMaquinaria = grdMaquina.ActiveRow.Cells("ID").Value
            descripcionMaquina = grdMaquina.ActiveRow.Cells("Máquina").Value
            Me.Close()
        Catch ex As Exception

        End Try

    End Sub
End Class