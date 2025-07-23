Imports Infragistics.Win.UltraWinGrid

Public Class listaCoincidenciasForm

    Public lista As New DataTable
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub listaCoincidenciasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdCoincidencias.DataSource = lista
        disenio()
    End Sub

    Public Sub disenio()
        'With grdCoincidencias.DisplayLayout.Bands(0)
        'End With
        grdCoincidencias.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class