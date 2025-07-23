Imports Proveedores.DA
Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Proveedores.BU

Public Class ProductosRegistradosDeLasNavesForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Dim idProducto As Integer = 0
    Public tablaEstatus As New DataTable
    Dim listaEstatus As New ValueList

    Private Sub ProductosRegistradosDeLasNavesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarTablaProductos()
        disenoGrid()
        LlenarListasNaves()
        'llenarComboEstatus()
    End Sub

    Public Sub llenarComboEstatus()
        tablaEstatus.Columns.Add("ID")
        tablaEstatus.Columns.Add("ESTATUS")
        tablaEstatus.Rows.Add("0", "")
        tablaEstatus.Rows.Add("1", "AUTORIZADO")
        tablaEstatus.Rows.Add("2", "NO AUTORIZADO")
        tablaEstatus.Rows.Add("3", "INACTIVO")

        cmbEstatus.DataSource = tablaEstatus
        cmbEstatus.DisplayMember = "ESTATUS"
        cmbEstatus.ValueMember = "ID"

        listaEstatus.ValueListItems.Add("")
        listaEstatus.ValueListItems.Add("AUTORIZADO")
        listaEstatus.ValueListItems.Add("NO AUTORIZADO")
        listaEstatus.ValueListItems.Add("INACTIVO")
    End Sub

    Public Sub LlenarListasNaves()
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub
    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim form As New listaModelosRegistradosNaveForm
        form.lblMensaje.Text = "Seleccione un estilo al para agregar su consumo y fracción"
        form.ShowDialog()
        'If idProducto <> 0 Then
        '    Dim form As New AltaConsumosYFraccionesForm
        '    If grdProductosRegistrados.Rows.Count > 0 Then
        '        If grdProductosRegistrados.ActiveRow.Cells("prod_productoid").Text <> "" Then
        '            form.codigo = grdProductosRegistrados.ActiveRow.Cells("prod_codigo").Text
        '            form.coleccion = grdProductosRegistrados.ActiveRow.Cells("cole_descripcion").Text
        '            form.grupo = grdProductosRegistrados.ActiveRow.Cells("grpo_descripcion").Text
        '            form.tipo = grdProductosRegistrados.ActiveRow.Cells("tica_descripcion").Text
        '            form.aplicacion = grdProductosRegistrados.ActiveRow.Cells("subfamilias").Text
        '            form.temporada = grdProductosRegistrados.ActiveRow.Cells("temp_nombre").Text
        '            form.marca = grdProductosRegistrados.ActiveRow.Cells("marc_descripcion").Text
        '            form.descripcion = grdProductosRegistrados.ActiveRow.Cells("prod_descripcion").Text
        '            form.productoid = grdProductosRegistrados.ActiveRow.Cells("prod_productoid").Text
        '            form.ShowDialog()
        '        End If
        '    Else
        '        objMensaje.mensaje = "Debe seleccionar un modelo de la lista para poder agregar consumos"
        '        objMensaje.ShowDialog()
        '    End If
        'End If
    End Sub

    Private Sub btnCopiar_Click(sender As Object, e As EventArgs) Handles btnCopiar.Click
        Dim form As New ListaDeNavesCopiarConsumoForm
        form.ShowDialog()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim form As New listaModelosRegistradosNaveForm
        form.ShowDialog()
    End Sub
    Public Sub llenarTablaProductos()
        Dim obj As New ConsumosBU
        Dim dtTablaProductos As DataTable
        dtTablaProductos = obj.VerListaProductos
        grdProductosRegistrados.DataSource = dtTablaProductos
    End Sub

    Public Sub disenoGrid()

        With grdProductosRegistrados.DisplayLayout.Bands(0)
            '.Columns("prod_productoid").Hidden = True
            '.Columns("prod_activo").Hidden = True
            '.Columns("prod_foto").Hidden = True
            '.Columns("prod_dibujo").Hidden = True
            '.Columns("grpo_grupoid").Hidden = True
            '.Columns("tica_tipocategoriaid").Hidden = True
            '.Columns("prod_codigo").Header.Caption = "Código"
            '.Columns("marc_descripcion").Header.Caption = "Marca"
            '.Columns("cole_descripcion").Header.Caption = "Colección"
            '.Columns("prod_descripcion").Header.Caption = "Descripción"
            '.Columns("temp_nombre").Header.Caption = "Temporada"
            '.Columns("temp_año").Header.Caption = "Año"
            '.Columns("grpo_descripcion").Header.Caption = "Grupo"
            '.Columns("subfamilias").Header.Caption = "Aplicaciones"
            '.Columns("tica_descripcion").Header.Caption = "Tipo de Producto"
            '.Columns("prod_modelo").Header.Caption = "Modelo"
            '.Columns("tica_descripcion").CellActivation = Activation.NoEdit
            '.Columns("subfamilias").CellActivation = Activation.NoEdit
            '.Columns("prod_codigo").CellActivation = Activation.NoEdit
            '.Columns("marc_descripcion").CellActivation = Activation.NoEdit
            '.Columns("cole_descripcion").CellActivation = Activation.NoEdit
            '.Columns("prod_descripcion").CellActivation = Activation.NoEdit
            '.Columns("temp_nombre").CellActivation = Activation.NoEdit
            '.Columns("temp_año").CellActivation = Activation.NoEdit
            '.Columns("grpo_descripcion").CellActivation = Activation.NoEdit
            '.Columns("prod_modelo").CellActivation = Activation.NoEdit

            '.Columns("prod_codigo").CellAppearance.TextHAlign = HAlign.Right
            '.Columns("prod_modelo").CellAppearance.TextHAlign = HAlign.Right
            '.Columns("temp_año").CellAppearance.TextHAlign = HAlign.Right

            '.Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            '.Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            '.Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            '.Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            For value = 0 To grdProductosRegistrados.Rows.Count - 1
                If grdProductosRegistrados.Rows(value).Cells("Cliente").Text <> "" Then
                    grdProductosRegistrados.Rows(value).Cells("Cliente").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#0174DF")
                End If
            Next

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        'grdProductosRegistrados.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'grdProductosRegistrados.DisplayLayout.Bands(0).Columns("prod_codigo").Width = 100
        'grdProductosRegistrados.DisplayLayout.Bands(0).Columns("marc_descripcion").Width = 100
    End Sub

    Private Sub grdProductosRegistrados_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grdProductosRegistrados.DoubleClickRow
        Dim form As New AltaConsumosYFraccionesForm
        If grdProductosRegistrados.Rows.Count > 0 Then
            If grdProductosRegistrados.ActiveRow.Cells("prod_codigo").Text <> "" Then
                form.codigo = grdProductosRegistrados.ActiveRow.Cells("prod_codigo").Text
                form.coleccion = grdProductosRegistrados.ActiveRow.Cells("cole_descripcion").Text
                form.grupo = grdProductosRegistrados.ActiveRow.Cells("grpo_descripcion").Text
                form.tipo = grdProductosRegistrados.ActiveRow.Cells("tica_descripcion").Text
                form.aplicacion = grdProductosRegistrados.ActiveRow.Cells("subfamilias").Text
                form.temporada = grdProductosRegistrados.ActiveRow.Cells("temp_nombre").Text
                form.marca = grdProductosRegistrados.ActiveRow.Cells("marc_descripcion").Text
                form.descripcion = grdProductosRegistrados.ActiveRow.Cells("prod_descripcion").Text
                form.productoid = grdProductosRegistrados.ActiveRow.Cells("prod_productoid").Text
                form.ShowDialog()
            End If
        End If
    End Sub

    'Private Sub grdProductosRegistrados_Click(sender As Object, e As EventArgs) Handles grdProductosRegistrados.Click
    '    If grdProductosRegistrados.Rows.Count > 0 Then
    '        If grdProductosRegistrados.ActiveRow.Cells("prod_productoid").Text <> "" Then
    '            idProducto = grdProductosRegistrados.ActiveRow.Cells("prod_productoid").Value
    '        End If
    '    End If
    'End Sub

    Private Sub pnlEncabezado_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles pnlEncabezado.Paint

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub btnCambiosGlobales_Click(sender As Object, e As EventArgs) Handles btnCambiosGlobales.Click
        Dim form As New CambioGlobalForm
        form.showdialog()
    End Sub
End Class