Imports Proveedores.BU
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class listaModelosRegistradosNaveForm

    Public copiarconsumos = 0

    Private Sub listaModelosRegistradosNaveForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarTablaProductos()
    End Sub

    Public Sub llenarTablaProductos()
        Dim obj As New ConsumosBU
        Dim dtTablaProductos As DataTable
        dtTablaProductos = obj.listaMaterialesConConsumos
        grdModelos.DataSource = dtTablaProductos
        'disenoGrid()
    End Sub

    Public Sub disenoGrid()

        With grdModelos.DisplayLayout.Bands(0)
            .Columns("prod_productoid").Hidden = True
            .Columns("prod_activo").Hidden = True
            .Columns("prod_foto").Hidden = True
            .Columns("prod_dibujo").Hidden = True
            .Columns("grpo_grupoid").Hidden = True
            .Columns("tica_tipocategoriaid").Hidden = True
            .Columns("grpo_grupoid").Hidden = True
            .Columns("tica_descripcion").Hidden = True
            .Columns("grpo_descripcion").Hidden = True
            .Columns("temp_año").Hidden = True
            .Columns("prod_codigo").Header.Caption = "Código"
            .Columns("marc_descripcion").Header.Caption = "Marca"
            .Columns("cole_descripcion").Header.Caption = "Colección"
            .Columns("prod_descripcion").Header.Caption = "Descripción"
            .Columns("temp_nombre").Header.Caption = "Temporada"
            .Columns("temp_año").Header.Caption = "Año"
            .Columns("grpo_descripcion").Header.Caption = "Grupo"
            .Columns("subfamilias").Header.Caption = "Aplicaciones"
            .Columns("tica_descripcion").Header.Caption = "Tipo de Producto"
            .Columns("prod_modelo").Header.Caption = "Modelo"
            .Columns("tica_descripcion").CellActivation = Activation.NoEdit
            .Columns("subfamilias").CellActivation = Activation.NoEdit
            .Columns("prod_codigo").CellActivation = Activation.NoEdit
            .Columns("marc_descripcion").CellActivation = Activation.NoEdit
            .Columns("cole_descripcion").CellActivation = Activation.NoEdit
            .Columns("prod_descripcion").CellActivation = Activation.NoEdit
            .Columns("temp_nombre").CellActivation = Activation.NoEdit
            .Columns("temp_año").CellActivation = Activation.NoEdit
            .Columns("grpo_descripcion").CellActivation = Activation.NoEdit
            .Columns("prod_modelo").CellActivation = Activation.NoEdit

            .Columns("prod_codigo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("prod_modelo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("temp_año").CellAppearance.TextHAlign = HAlign.Right

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdModelos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdModelos.DisplayLayout.Bands(0).Columns("prod_codigo").Width = 100
        grdModelos.DisplayLayout.Bands(0).Columns("marc_descripcion").Width = 100
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        If copiarconsumos = 0 Then
            Dim form As New AltaConsumosYFraccionesForm
            form.ShowDialog()
        Else
            Dim form As New CopiarConsumosFraccionesForm
            form.ShowDialog()
        End If
        
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub grdModelos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdModelos.InitializeLayout

    End Sub
End Class