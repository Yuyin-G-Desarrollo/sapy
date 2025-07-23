Imports Proveedores.BU
Imports Infragistics.Win.UltraWinGrid

Public Class ListaMaterialesForm

    Private Sub ListaMaterialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarTablaProductos()
    End Sub

    Public Sub llenarTablaProductos()
        Dim obj As New ConsumosBU
        Dim dtTablaProductos As DataTable
        dtTablaProductos = obj.listaMateriales
        grdMateriales.DataSource = dtTablaProductos
        diseniogrdMateriales()
    End Sub

    Public Sub diseniogrdMateriales()
        With grdMateriales.DisplayLayout.Bands(0)

            grdMateriales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class