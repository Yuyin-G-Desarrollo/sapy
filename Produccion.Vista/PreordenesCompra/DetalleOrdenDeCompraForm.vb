Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class DetalleOrdenDeCompraForm

    Public OrdenCompra As Integer = 0
    Public nave As Integer = 0
    Public proveedor As Integer = 0

    Private Sub DetalleOrdenDeCompraForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CargarMateriales()
    End Sub

    'Public Sub CargarMateriales()
    '    Dim obj As New PreordenCompraBU
    '    Dim tablas As New DataTable
    '    tablas = obj.ConsultaDetalleOrdenCompra(nave, OrdenCompra)
    '    grdOrdenCompra.DataSource = tablas
    '    diseñoGrid()
    'End Sub

    Public Sub diseñoGrid()
        Me.Cursor = Cursors.WaitCursor

        With grdOrdenCompra.DisplayLayout.Bands(0)
            .Columns("Material").Width = 70
            .Columns("Proveedor").Width = 50
            .Columns("Precio Unitario").Width = 20
            .Columns("Total solicitado").Width = 20
            .Columns("Fecha Solicito").Width = 20
            .Columns("Solicitado").Width = 20

            .Columns("Idmn").Hidden = True
            .Columns("Idp").Hidden = True

            .Columns("Precio Unitario").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total solicitado").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Solicitado").CellAppearance.TextHAlign = HAlign.Right

            .Columns("Material").CellActivation = Activation.NoEdit
            .Columns("Proveedor").CellActivation = Activation.NoEdit
            .Columns("Precio Unitario").CellActivation = Activation.NoEdit
            .Columns("Total solicitado").CellActivation = Activation.NoEdit
            .Columns("Fecha Solicito").CellActivation = Activation.NoEdit
            .Columns("Solicitado").CellActivation = Activation.NoEdit

            .Columns("Precio Unitario").Format = "##,##0.00"
            .Columns("Total solicitado").Format = "##,##0.00"
            .Columns("Solicitado").Format = "##,##0.00"

        End With
        grdOrdenCompra.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdOrdenCompra.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdOrdenCompra.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class