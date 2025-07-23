Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win
Imports Proveedores.BU
Imports System.Windows.Forms

Public Class CambioGlobalForm

    Private Sub CambioGlobalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboMarcas()
        ActivarDesactivarBotones()
        llenarComboComponente()
        crearTablaComponentes()
        ActivarDesactivarFracciones()
        crearTablaFracciones()
    End Sub

    Public idnave As Integer
    Public idmodelo As Integer
    Public idEstilo As Integer
    Public codigo As Integer

    Dim renglon As Integer = 0
    Dim tablaFracciones As New DataTable
    Dim tablaConsumos As New DataTable
    Dim DepartamentosLista As New ValueList

    Public Sub ActivarDesactivarBotones()
        If rdoRemplazoMaterial.Checked = True Then
            cmbClasificacion.Enabled = False
            cmbComponente.Enabled = False
            btnProveedor.Enabled = True
            btnMaterial.Enabled = True
            chkBloqueado.Enabled = False
            chkExplosionar.Enabled = False
            chkLotear.Enabled = False
            cmbMarcaBusqueda.Enabled = True
            cmbColeccionBusqueda.Enabled = True
            cmbComponenteBusqueda.Enabled = True
            btnProveedorBuscar.Enabled = True
            pnlConsumos.Visible = False
            btnGuardarConsumo.Visible = False
            lblGuardarConsumo.Visible = False
            lblTitulo2.Visible = True
        End If
        If rdoCambioProveedor.Checked = True Then
            cmbClasificacion.Enabled = False
            cmbComponente.Enabled = False
            btnProveedor.Enabled = True
            btnMaterial.Enabled = True
            chkBloqueado.Enabled = True
            chkExplosionar.Enabled = True
            chkLotear.Enabled = True
            cmbMarcaBusqueda.Enabled = True
            cmbColeccionBusqueda.Enabled = True
            cmbComponenteBusqueda.Enabled = False
            btnProveedorBuscar.Enabled = True
            pnlConsumos.Visible = False
            btnGuardarConsumo.Visible = False
            lblGuardarConsumo.Visible = False
            lblTitulo2.Visible = True
        End If
        If rdoNuevo.Checked = True Then
            cmbClasificacion.Enabled = True
            cmbComponente.Enabled = True
            btnProveedor.Enabled = True
            btnMaterial.Enabled = True
            chkBloqueado.Enabled = True
            chkExplosionar.Enabled = True
            chkLotear.Enabled = True
            cmbMarcaBusqueda.Enabled = True
            cmbColeccionBusqueda.Enabled = True
            cmbComponenteBusqueda.Enabled = False
            btnProveedorBuscar.Enabled = False
            pnlConsumos.Visible = True
            btnGuardarConsumo.Visible = True
            lblGuardarConsumo.Visible = True
            lblTitulo2.Visible = False
        End If
    End Sub

    Public Sub Llenartabla()
        Dim obj As New ConsumosBU
        Dim dtTablaConsumos As DataTable
        dtTablaConsumos = obj.tablaConsumosss
        grdConsumosFracciones.DataSource = dtTablaConsumos
        grdgrdConsumosFracciones2.DataSource = dtTablaConsumos
        diseniogrdConsumos()
    End Sub

    Public Sub llenarComboComponente()
        Dim obj As New ConsumosBU
        Dim lst As DataTable
        lst = obj.listaComponente()
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbComponente.DataSource = lst
            cmbComponente.DisplayMember = "Componente"
            cmbComponente.ValueMember = "ID"
            cmbComponenteBusqueda.DataSource = lst
            cmbComponenteBusqueda.DisplayMember = "Componente"
            cmbComponenteBusqueda.ValueMember = "ID"
        End If
    End Sub

    Public Sub diseniogrdConsumos()
        With grdConsumosFracciones.DisplayLayout.Bands(0)

            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            grdConsumosFracciones.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With
    End Sub

    Public Sub llenarComboMarcas()
        Dim obj As New ConsumosBU
        Dim lst As DataTable
        lst = obj.listaMarcas()
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbMarcaBusqueda.DataSource = lst
            cmbMarcaBusqueda.DisplayMember = "Marca"
            cmbMarcaBusqueda.ValueMember = "ID"
        End If
    End Sub

    Public Sub llenarComboColeccion()
        Dim obj As New ConsumosBU
        Dim lst As DataTable
        lst = obj.listaColecciones(cmbMarcaBusqueda.SelectedValue)
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbColeccionBusqueda.DataSource = lst
            cmbColeccionBusqueda.DisplayMember = "Coleccion"
            cmbColeccionBusqueda.ValueMember = "ID"
        End If
    End Sub

    Public Sub crearTablaComponentes()
        tablaConsumos.Columns.Add("Bloq")
        tablaConsumos.Columns.Add("Explosionar")
        tablaConsumos.Columns.Add("Lotear")
        tablaConsumos.Columns.Add("Componente")
        tablaConsumos.Columns.Add("Clasificación")
        tablaConsumos.Columns.Add("SKU")
        tablaConsumos.Columns.Add("Material")
        tablaConsumos.Columns.Add("Consumo")
        tablaConsumos.Columns.Add("UM Consumo")
        tablaConsumos.Columns.Add("Proveedor")
        tablaConsumos.Columns.Add("Precio Compra")
        tablaConsumos.Columns.Add("UM Proveedor")
        tablaConsumos.Columns.Add("Factor Conversión")
        tablaConsumos.Columns.Add("Precio UM")
        tablaConsumos.Columns.Add("Costo Par")

        grdNuevoConsumo.DataSource = tablaConsumos
        AgregarFilaConsumo()
    End Sub

    Public Sub crearTablaFracciones()
        tablaFracciones.Columns.Add("Departamento")
        tablaFracciones.Columns.Add("Bloq")
        tablaFracciones.Columns.Add("Fracción")
        tablaFracciones.Columns.Add("Costo")
        tablaFracciones.Columns.Add("Pagar")

        grdNuevaFraccion.DataSource = tablaFracciones
        AgregarFilaFraccion()
    End Sub

    Public Sub AgregarFilaConsumo()
        grdNuevoConsumo.DisplayLayout.Bands(0).AddNew()

        grdNuevoConsumo.ActiveRow.Cells("Bloq").Value = False
        grdNuevoConsumo.ActiveRow.Cells("Explosionar").Value = False
        grdNuevoConsumo.ActiveRow.Cells("Lotear").Value = False

        diseniogridConsumos()

        renglon = renglon + 1
    End Sub

    Public Sub AgregarFilaFraccion()
        grdNuevaFraccion.DisplayLayout.Bands(0).AddNew()

        grdNuevaFraccion.ActiveRow.Cells("Bloq").Value = False
        grdNuevaFraccion.ActiveRow.Cells("Pagar").Value = False
        diseniogridFracciones()

        renglon = renglon + 1
    End Sub

    Public Sub diseniogridFracciones()
        ObtenerListaDepartamentos()
        With grdNuevaFraccion.DisplayLayout.Bands(0)
            .Columns("Bloq").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Bloq").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Bloq").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Bloq").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Pagar").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Pagar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Pagar").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Pagar").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Departamento").Style = UltraWinGrid.ColumnStyle.DropDown
            .Columns("Departamento").ValueList = DepartamentosLista

            .Columns("Fracción").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Costo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit

            .Columns("Costo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("Departamento").Width = 50
            .Columns("Bloq").Width = 15
            .Columns("Pagar").Width = 15
            .Columns("Costo").Width = 50
            .Columns("Fracción").Width = 300

            .Columns("Fracción").CharacterCasing = Infragistics.Win.UltraWinGrid.Case.Lower

        End With
        grdNuevaFraccion.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Public Sub diseniogridConsumos()
        'grdNuevoConsumo.DisplayLayout.Bands(0).AddNew()
        With grdNuevoConsumo.DisplayLayout.Bands(0)
            .Columns("Bloq").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Bloq").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Bloq").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Bloq").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Explosionar").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Explosionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Explosionar").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Explosionar").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Lotear").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Lotear").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Lotear").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Lotear").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Componente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Clasificación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("SKU").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Material").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Consumo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("UM Consumo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Proveedor").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Precio Compra").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("UM Proveedor").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Factor Conversión").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Precio UM").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Costo Par").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("Consumo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Precio Compra").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Precio UM").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Costo Par").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("UM Consumo").Header.Caption = "UM" & vbCrLf & "Consumo"
            .Columns("Precio Compra").Header.Caption = "Precio" & vbCrLf & "Compra"
            .Columns("UM Proveedor").Header.Caption = "UM" & vbCrLf & "Proveedor"
            .Columns("Factor Conversión").Header.Caption = "Factor" & vbCrLf & "Conversión"
            .Columns("Precio UM").Header.Caption = "" & vbCrLf & "UM"
            .Columns("Costo Par").Header.Caption = "Costo" & vbCrLf & "Par"

            .Columns("Explosionar").Width = 30
            .Columns("Lotear").Width = 30
            .Columns("Bloq").Width = 30
            .Columns("Componente").Width = 70
            .Columns("Clasificación").Width = 70
            .Columns("SKU").Width = 70
            .Columns("Material").Width = 200
            .Columns("Consumo").Width = 40
            .Columns("UM Consumo").Width = 40
            .Columns("Proveedor").Width = 170
            .Columns("Precio Compra").Width = 40
            .Columns("UM Proveedor").Width = 50
            .Columns("Factor Conversión").Width = 50
            .Columns("Precio UM").Width = 40
            .Columns("Costo Par").Width = 40

            .Columns("Componente").CharacterCasing = Infragistics.Win.UltraWinGrid.Case.Lower
            .Columns("Clasificación").CharacterCasing = Infragistics.Win.UltraWinGrid.Case.Lower
            .Columns("Material").CharacterCasing = Infragistics.Win.UltraWinGrid.Case.Lower
            .Columns("Consumo").CharacterCasing = Infragistics.Win.UltraWinGrid.Case.Lower
            .Columns("Proveedor").CharacterCasing = Infragistics.Win.UltraWinGrid.Case.Lower
            .Columns("UM Consumo").CharacterCasing = Infragistics.Win.UltraWinGrid.Case.Lower

        End With
        grdNuevoConsumo.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Public Sub ActivarDesactivarFracciones()
        If rdoNuevoFraccion.Checked = True Or rdoRemplazoFraccion.Checked = True Then
            pnlFracciones.Visible = True
            btnGuardarFraccion.Visible = True
            lblGuardarFraccion.Visible = True
            lblReemplazaFraccion.Visible = False
            btnRemplazarFraccion.Visible = False
            lblTitulo3.Visible = False
            cmbComponenteBusqueda.Enabled = True
            btnBuscar.Enabled = True
        Else
            pnlFracciones.Visible = False
            btnGuardarFraccion.Visible = False
            lblGuardarFraccion.Visible = False
            lblReemplazaFraccion.Visible = True
            btnRemplazarFraccion.Visible = True
            lblTitulo3.Visible = True
            btnMaterial.Enabled = False

            'grdNuevaFraccion.DataSource = Nothing
        End If
    End Sub

    Private Sub rdoRemplazoMaterial_CheckedChanged(sender As Object, e As EventArgs) Handles rdoRemplazoMaterial.CheckedChanged
        ActivarDesactivarBotones()
        'lblReemplazarConsumo.Text = "Reemplazar" & vbCrLf & "Consumo "
    End Sub

    Private Sub rdoCambioProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCambioProveedor.CheckedChanged
        ActivarDesactivarBotones()
        'lblReemplazarConsumo.Text = "Reemplazar" & vbCrLf & "Proveedor/Precio "
    End Sub

    Private Sub rdoNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoNuevo.CheckedChanged
        ActivarDesactivarBotones()

    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        If chkSeleccionarTodo.Checked = True Then
            For value = 0 To grdConsumosFracciones.Rows.Count - 1
                grdConsumosFracciones.Rows(value).Cells("").Value = 1
            Next
        Else
            For value = 0 To grdConsumosFracciones.Rows.Count - 1
                grdConsumosFracciones.Rows(value).Cells("").Value = 0
            Next
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabCambiosGlobales.SelectedIndexChanged
        If tabCambiosGlobales.SelectedIndex = 0 Then
            grdConsumosFracciones.DataSource = Nothing
            chkSeleccionarTodo.Visible = True
        ElseIf tabCambiosGlobales.SelectedIndex = 1 Then
            grdConsumosFracciones.DataSource = Nothing
            chkSeleccionarTodo.Visible = False
        End If
    End Sub

    Private Sub btnProveedor_Click(sender As Object, e As EventArgs) Handles btnProveedor.Click
        Dim form As New CatalogoProveedoresForm
        form.ShowDialog()
    End Sub

    Private Sub btnMaterial_Click(sender As Object, e As EventArgs) Handles btnMaterial.Click
        Dim form As New ListaMaterialesForm
        form.ShowDialog()
    End Sub

    Private Sub btnProveedorBuscar_Click(sender As Object, e As EventArgs) Handles btnProveedorBuscar.Click
        Dim form As New CatalogoProveedoresForm
        form.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub grdNuevoConsumo_KeyUp(sender As Object, e As KeyEventArgs) Handles grdNuevoConsumo.KeyUp
        Dim VALUE As String
        VALUE = e.KeyData
        If grdNuevoConsumo.ActiveRow.Cells("Material").Text <> "" And VALUE = 13 Then
            AgregarFilaConsumo()
        End If
    End Sub

    Private Sub rdoNuevoFraccion_CheckedChanged(sender As Object, e As EventArgs) Handles rdoNuevoFraccion.CheckedChanged
        ActivarDesactivarFracciones()
    End Sub

    Private Sub rdoRemplazoFraccion_CheckedChanged(sender As Object, e As EventArgs) Handles rdoRemplazoFraccion.CheckedChanged
        ActivarDesactivarFracciones()
    End Sub

    Public Sub ObtenerListaDepartamentos()
        Dim obj As New ConsumosBU
        Dim listaDepartamento As New DataTable
        listaDepartamento = obj.listaDepartamentos()
        If Not listaDepartamento.Rows.Count = 0 Then
            listaDepartamento.Rows.InsertAt(listaDepartamento.NewRow, 0)

            For Each rowDt As DataRow In listaDepartamento.Rows
                If listaDepartamento.Rows.Count > 0 Then
                    DepartamentosLista.ValueListItems.Add(rowDt.Item("ID"), rowDt.Item("Departamento").ToString.ToUpper.Trim)
                End If
            Next
        End If
    End Sub

    Private Sub grdNuevaFraccion_KeyUp(sender As Object, e As KeyEventArgs) Handles grdNuevaFraccion.KeyUp
        Dim VALUE As String
        VALUE = e.KeyData
        If grdNuevaFraccion.ActiveRow.Cells("Fracción").Text <> "" And VALUE = 13 And grdNuevaFraccion.ActiveRow.Cells("Departamento").Text <> "" Then
            AgregarFilaFraccion()
        End If
    End Sub

    Private Sub cmbMarcaBusqueda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarcaBusqueda.SelectedIndexChanged
        Try
            llenarComboColeccion()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Llenartabla()
    End Sub

    Private Sub grdConsumosFracciones_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdConsumosFracciones.InitializeLayout

    End Sub

    Private Sub cbxTodo_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTodo.CheckedChanged
        Dim x = 0
        If cbxTodo.Text = "Seleccionar todo" And x = 0 Then
            For value = 0 To grdConsumosFracciones.Rows.Count - 1
                grdConsumosFracciones.Rows(value).Cells(" ").Value = 1
            Next
            cbxTodo.Text = "Deseleccionar todo"
            x = x + 1
        End If

        If cbxTodo.Text = "Deseleccionar todo" And x = 0 Then
            For value = 0 To grdConsumosFracciones.Rows.Count - 1
                grdConsumosFracciones.Rows(value).Cells(" ").Value = 0
            Next
            cbxTodo.Text = "Seleccionar todo"
            x = x + 1
        End If

    End Sub
End Class