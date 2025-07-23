Imports Produccion.Datos
Imports Infragistics.Win.UltraWinGrid
Imports Produccion.Negocios

Public Class InventarioDetalleForm

    Public idProveedor As Integer
    Public idMaterialNave As Integer
    Public precio As Double
    Public fechaInicio As String
    Public fechaFin As String
    Public material As String
    Public proveedor As String
    Public inventarioTotal As Double
    Public totalDinero As Double
    Dim umc As String
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub InventarioDetalleForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarControles()
    End Sub
    Public Sub llenarControles()
        lblMaterial.Text = material
        lblProveedor.Text = proveedor
        'lblInventario.Text = Format(inventarioTotal, "##,##0.00") & " " & umc
        lblPrecio.Text = "$ " & Format(precio, "##,##0.00")
        'lblTotalDinero.Text = "$ " & Format(totalDinero, "##,##0.00")
    End Sub
    Public Sub llenarGrid()
        Dim obj As New InventarioBU
        Dim datos As New DataTable
        datos = obj.getMovimientosMaterial(idProveedor, idMaterialNave, precio, dtpFechaInicio.Value, dtpFechaFinal.Value)
        grdDetalles.DataSource = datos
        Dim entradas As Double = 0.0
        Dim salidas As Double = 0.0
        For Each row As DataRow In datos.Rows
            entradas += row("ENTRADAS")
            salidas += row("SALIDAS")
            umc = row("UMC")
        Next
        inventarioTotal = obj.getTotalInventario(idMaterialNave, idProveedor, precio, dtpFechaFinal.Value)
        lblInventario.Text = Format(inventarioTotal, "##,##0.00") & " " & umc
        lblTotalDinero.Text = "$ " & Format((precio * inventarioTotal), "##,##0.00")
        lblEntradas.Text = Format(entradas, "##,##0.00") & " " & umc
        lblSalidas.Text = Format(salidas, "##,##0.00") & " " & umc
        setDiseño()
    End Sub
    Public Sub setDiseño()
        Try
            With grdDetalles.DisplayLayout.Bands(0)
                .Columns("ENTRADAS").Format = "##,##0.00"
                .Columns("SALIDAS").Format = "##,##0.00"
                .Columns("INVENTARIO INICIAL").Format = "##,##0.00"
                .Columns("MOVIMIENTO").Width = 270
                .Columns("ENTRADAS").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("SALIDAS").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("INVENTARIO INICIAL").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("FECHA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End With
            grdDetalles.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdDetalles.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
            grdDetalles.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdDetalles_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdDetalles.ClickCell
        Try
            grdDetalles.ActiveRow.Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        llenarGrid()
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        If dtpFechaInicio.Value > dtpFechaFinal.Value Then
            dtpFechaInicio.Value = dtpFechaFinal.Value
        End If
    End Sub

    Private Sub dtpFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFinal.ValueChanged
        If dtpFechaFinal.Value < dtpFechaInicio.Value Then
            dtpFechaFinal.Value = dtpFechaInicio.Value
        End If
    End Sub
End Class