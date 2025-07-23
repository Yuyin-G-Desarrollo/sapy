Imports Proveedores.BU
Imports Infragistics.Win.UltraWinGrid

Public Class listaProveedoresConsumosForm

    Private Sub listaProveedoresConsumosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarTablaProveedores()
    End Sub

    Public Sub llenarTablaProveedores()
        Dim obj As New ConsumosBU
        Dim dtTablaProductos As DataTable
        dtTablaProductos = obj.listaProveedores
        grdProveedores.DataSource = dtTablaProductos
        diseniogrdProveedores()
    End Sub

    Public Sub diseniogrdProveedores()
        With grdProveedores.DisplayLayout.Bands(0)

            grdProveedores.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With
    End Sub
End Class