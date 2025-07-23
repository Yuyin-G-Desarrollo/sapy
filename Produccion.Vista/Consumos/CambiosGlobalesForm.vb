Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win
Imports Entidades
Imports Tools

Public Class CambiosGlobalesForm
    'cqambio
    Public idnave As Integer
    Public idmodelo As Integer
    Public idEstilo As Integer
    Public codigo As String = String.Empty
    Dim idmaterialnave = 0
    Dim idmaterial = 0
    Dim pregunta As New ConfirmarForm
    Dim objadvertencia As New AdvertenciaForm
    Dim objExito As New ExitoForm
    Dim adv As New AdvertenciaForm
    Dim borrar As Boolean = False
    Dim renglon As Integer = 0
    Dim tablaFracciones As New DataTable
    Dim tablaMateriales As New DataTable
    Dim tablaConsumos As New DataTable
    Dim DepartamentosLista As New ValueList

    Dim objMensaje As New AdvertenciaForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Dim listaEstilos As New List(Of Integer)
    Dim listaEstilosNave As New List(Of Integer)
    Dim listaProveedores As New DataTable
    Dim listaMateriales As New DataTable

    Public listaNavesAsignadas As New List(Of Integer)
    Public ListaProveecores As New List(Of Integer)

    Dim idconsumo As Integer = 0
    Dim CargoCompleto As Boolean = False
    Dim ActualizarCeldaCosto As Boolean = False
    Dim FraccionIDSeleccionada As Integer = 0
    Dim ObservacionesFraccionSeleccionada As String = String.Empty
    Dim teclarpuntoCosto As Boolean = True

    Dim vXmlConsumos As XElement = New XElement("Consumos")


    Public Sub ActivarDesactivarBotones()
        If rdoRemplazoMaterial.Checked = True Then
            cmbClasificacion.Enabled = False
            cmbComponente.Enabled = False
            btnProveedor.Enabled = True
            btnMaterial.Enabled = True
            cmbMarcaBusqueda.Enabled = True
            cmbColeccionBusqueda.Enabled = True
            cmbComponenteBusqueda.Enabled = True
            pnlConsumos.Visible = True
            ' btnProveedorBuscar.Enabled = True
            btnGuardarConsumo.Visible = True
            lblGuardarConsumo.Visible = True
            'lblTitulo2.Text = "Reemplazo de material"
            btnBuscar.Enabled = True

        End If
        If rdoCambioProveedor.Checked = True Then
            cmbClasificacion.Enabled = False
            cmbComponente.Enabled = False
            btnProveedor.Enabled = True
            btnMaterial.Enabled = True
            cmbMarcaBusqueda.Enabled = True
            cmbColeccionBusqueda.Enabled = True
            cmbComponenteBusqueda.Enabled = False
            'btnProveedorBuscar.Enabled = True
            pnlConsumos.Visible = False
            btnGuardarConsumo.Visible = False
            lblGuardarConsumo.Visible = False
            lblTitulo2.Text = "Cambio de proveedor"
            btnBuscar.Enabled = True
            btnGuardarConsumo.Visible = True
            lblGuardarConsumo.Visible = True

        End If
        If rdoNuevo.Checked = True Then
            cmbClasificacion.Enabled = True
            cmbComponente.Enabled = True
            btnProveedor.Enabled = True
            btnMaterial.Enabled = True
            cmbMarcaBusqueda.Enabled = True
            cmbColeccionBusqueda.Enabled = True
            cmbComponenteBusqueda.Enabled = False
            'btnProveedorBuscar.Enabled = True
            pnlConsumos.Visible = True
            btnGuardarConsumo.Visible = True
            lblGuardarConsumo.Visible = True
            lblTitulo2.Text = "Agregar consumo"
            btnBuscar.Enabled = True
            btnGuardarConsumo.Visible = True
            lblGuardarConsumo.Visible = True
        End If
    End Sub

    Public Sub llenarComboComponente()
        Dim obj As New ConsumosBU
        Dim lst As DataTable
        lst = obj.listaComponente()
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            'cmbComponente.DataSource = lst
            'cmbComponente.DisplayMember = "ID"
            'cmbComponente.ValueMember = "Componente"
            cmbComponenteBusqueda.DataSource = lst
            cmbComponenteBusqueda.DisplayMember = "Componente"
            cmbComponenteBusqueda.ValueMember = "ID"
        End If
    End Sub

    Public Sub crearTablaComponentes()
        tablaConsumos.Columns.Add("Bloq")
        tablaConsumos.Columns.Add("Explosionar")
        tablaConsumos.Columns.Add("Lotear")
        tablaConsumos.Columns.Add("id componente")
        tablaConsumos.Columns.Add("Componente")
        tablaConsumos.Columns.Add("id clasificación")
        tablaConsumos.Columns.Add("Clasificación")
        tablaConsumos.Columns.Add("SKU")
        tablaConsumos.Columns.Add("id material")
        tablaConsumos.Columns.Add("Material")
        tablaConsumos.Columns.Add("Consumo")
        tablaConsumos.Columns.Add("idUMC")
        tablaConsumos.Columns.Add("idUMProd")
        tablaConsumos.Columns.Add("UMC")
        tablaConsumos.Columns.Add("id proveedor")
        tablaConsumos.Columns.Add("Proveedor")
        tablaConsumos.Columns.Add("Precio Compra")
        tablaConsumos.Columns.Add("UMP")
        tablaConsumos.Columns.Add("Factor Conversión")
        tablaConsumos.Columns.Add("Precio UM")
        tablaConsumos.Columns.Add("Costo Par")

        grdNuevoConsumo.DataSource = tablaConsumos
        AgregarFilaConsumo()
    End Sub

    Public Sub crearTablaFracciones()
        tablaFracciones.Columns.Clear()
        tablaFracciones.Rows.Clear()
        tablaFracciones.Columns.Add("Activo")
        tablaFracciones.Columns.Add("idFraccion")
        tablaFracciones.Columns.Add("idFraccDes")
        tablaFracciones.Columns.Add("Orden")
        tablaFracciones.Columns.Add("Fracción")
        tablaFracciones.Columns.Add("Costo")
        tablaFracciones.Columns.Add("Pagar")
        tablaFracciones.Columns.Add("Sumar Costo")
        tablaFracciones.Columns.Add("Horas")
        tablaFracciones.Columns.Add("Minutos")
        tablaFracciones.Columns.Add("Segundos")
        tablaFracciones.Columns.Add("Sumar Tiempo")
        tablaFracciones.Columns.Add("Maquinaria")
        tablaFracciones.Columns.Add("Observaciones")
        tablaFracciones.Columns.Add("maquinaid")

        grdNuevaFraccion.DataSource = tablaFracciones
        AgregarFilaFraccion()
        CargarListaObservacionesFracciones("")
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

        grdNuevaFraccion.ActiveRow.Cells("Activo").Value = False
        grdNuevaFraccion.ActiveRow.Cells("Pagar").Value = False
        grdNuevaFraccion.ActiveRow.Cells("Sumar Costo").Value = False
        grdNuevaFraccion.ActiveRow.Cells("Sumar Tiempo").Value = False
        diseniogridFracciones()

        renglon = renglon + 1
    End Sub

    Public Sub diseniogridFracciones()
        ObtenerListaDepartamentos()
        With grdNuevaFraccion.DisplayLayout.Bands(0)
            .Columns("Activo").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Activo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Activo").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Activo").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Pagar").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Pagar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Pagar").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Pagar").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Sumar Costo").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Sumar Costo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Sumar Costo").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Sumar Costo").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False



            .Columns("Sumar Tiempo").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Sumar Tiempo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Sumar Tiempo").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Sumar Tiempo").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            '.Columns("Departamento").Style = UltraWinGrid.ColumnStyle.DropDown
            '.Columns("Departamento").ValueList = DepartamentosLista

            .Columns("Fracción").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Costo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Maquinaria").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Costo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Activo").Hidden = True
            .Columns("Activo").Width = 15
            .Columns("Pagar").Width = 30
            .Columns("Costo").Width = 50
            .Columns("Maquinaria").Width = 80
            .Columns("Fracción").Width = 270
            .Columns("Horas").Width = 70
            .Columns("Minutos").Width = 70
            .Columns("Segundos").Width = 70
            .Columns("Orden").Width = 35
            .Columns("Observaciones").Width = 80
            .Columns("Costo").Format = "##,##0.000"


            .Columns("Horas").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Minutos").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Segundos").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Orden").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            'tablaFracciones.Columns.Add("Horas")
            'tablaFracciones.Columns.Add("Minutos")
            'tablaFracciones.Columns.Add("Segundos")

            .Columns("idFraccion").Hidden = True
            .Columns("idFraccDes").Hidden = True
            .Columns("maquinaid").Hidden = True

            .Columns("Fracción").CharacterCasing = Infragistics.Win.UltraWinGrid.Case.Lower

        End With
        grdNuevaFraccion.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdNuevaFraccion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
    End Sub

    Public Sub diseniogridFracciones2()
        ObtenerListaDepartamentos()
        With grdNuevaFraccion.DisplayLayout.Bands(0)
            .Columns("Activo").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Activo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Activo").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Activo").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Pagar").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Pagar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Pagar").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Pagar").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            '.Columns("Departamento").Style = UltraWinGrid.ColumnStyle.DropDown
            '.Columns("Departamento").ValueList = DepartamentosLista

            .Columns("Fracción").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Costo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Maquinaria").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Costo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("Activo").Width = 15
            .Columns("Pagar").Width = 15
            .Columns("Costo").Width = 50
            .Columns("Maquinaria").Width = 50
            .Columns("Fracción").Width = 300

            .Columns("idFraccion").Hidden = True
            .Columns("idFraccDes").Hidden = True


            .Columns("Costo").Format = "##,##0.000"

            .Columns("Fracción").CharacterCasing = Infragistics.Win.UltraWinGrid.Case.Lower

        End With
        grdNuevaFraccion.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdNuevaFraccion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
    End Sub

    Public Sub diseniogridConsumos()
        'grdNuevoConsumo.DisplayLayout.Bands(0).AddNew()
        Dim band As UltraGridBand = Me.grdNuevoConsumo.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
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

            .Columns("Componente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Clasificación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("SKU").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Material").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Consumo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("UMC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Proveedor").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Precio Compra").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("UMP").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Factor Conversión").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Precio UM").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Costo Par").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("Consumo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Precio Compra").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Precio UM").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Costo Par").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("UMC").Header.Caption = "UMC"
            .Columns("Precio Compra").Header.Caption = "Precio" & vbCrLf & "Compra"
            .Columns("UMP").Header.Caption = "UMP"
            .Columns("Factor Conversión").Header.Caption = "Factor" & vbCrLf & "Conversión"
            .Columns("Precio UM").Header.Caption = "" & vbCrLf & "UM"
            .Columns("Costo Par").Header.Caption = "Costo" & vbCrLf & "Par"

            .Columns("Costo Par").Format = "##,##0.000"

            .Columns("Explosionar").Width = 30
            .Columns("Lotear").Width = 30
            .Columns("Bloq").Width = 30
            .Columns("Componente").Width = 70
            .Columns("Clasificación").Width = 70
            .Columns("SKU").Width = 70
            .Columns("Material").Width = 200
            .Columns("Consumo").Width = 40
            .Columns("UMC").Width = 40
            .Columns("Proveedor").Width = 170
            .Columns("Precio Compra").Width = 40
            .Columns("UMP").Width = 50
            .Columns("Factor Conversión").Width = 50
            .Columns("Precio UM").Width = 40
            .Columns("Costo Par").Width = 40

            .Columns("id componente").Hidden = True
            .Columns("id proveedor").Hidden = True
            .Columns("id material").Hidden = True
            .Columns("id clasificación").Hidden = True
            .Columns("idUMProd").Hidden = True
            .Columns("idUMC").Hidden = True

            .Columns("Componente").CharacterCasing = Infragistics.Win.UltraWinGrid.Case.Lower
            .Columns("Clasificación").CharacterCasing = Infragistics.Win.UltraWinGrid.Case.Lower
            .Columns("Material").CharacterCasing = Infragistics.Win.UltraWinGrid.Case.Lower
            .Columns("Consumo").CharacterCasing = Infragistics.Win.UltraWinGrid.Case.Lower
            .Columns("Proveedor").CharacterCasing = Infragistics.Win.UltraWinGrid.Case.Lower
            .Columns("UMC").CharacterCasing = Infragistics.Win.UltraWinGrid.Case.Lower

        End With
        grdNuevoConsumo.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub CambiosGlobalesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim consumo As New ConsumosBU
        Dim NaveDesarrolla As Integer = 0
        ActivarDesactivarBotones()
        llenarComboComponente()
        crearTablaComponentes()
        ActivarDesactivarFracciones()
        crearTablaFracciones()
        crearTablaMateriales()
        llenarcomboMArca()
        llenarComoboMarcas(idnave)
        lblValorFraccionSeleccionada.Text = "-"
        lblValorObservacionesSeleccionada.Text = "-"
        CargoCompleto = True
        rbNuevoMaterial.Checked = True
        If consumo.EsNaveDesarrolla(idnave) = False Then
            tabCambiosGlobales.TabPages(0).Parent = Nothing

        End If
        ConsultaIstorialIncremento(idnave)
        'tabCambiosGlobales.TabPages(1).Parent = Nothing
        'lblReemplazarConsumo.Text = "Nuevo" & vbCrLf & "Consumo "
    End Sub

    Public Sub llenarComoboMarcas(ByVal nave As Integer)
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        lista = obj.listaDeMarcas(nave)
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbMarcaFraccion.DataSource = lista
            cmbMarcaFraccion.DisplayMember = "Marca"
            cmbMarcaFraccion.ValueMember = "ID"
        End If
    End Sub

    Public Sub llenarComboColeccionNaveDesarrolla(ByVal nave As Integer, ByVal marca As Integer)
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        lista = obj.listaColeccionesNaveDesarrolla(nave, marca)
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbColeccionFraccion.DataSource = lista
            cmbColeccionFraccion.DisplayMember = "Coleccion"
            cmbColeccionFraccion.ValueMember = "ID"
        End If
    End Sub


    Public Sub llenarComboColeccionFraccionNaveMarca(ByVal nave As Integer, ByVal marca As Integer)
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        lista = obj.ListadoColeccionFraccionesNaveMarca(nave, FraccionIDSeleccionada, ObservacionesFraccionSeleccionada, marca)
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbColeccionFraccion.DataSource = lista
            cmbColeccionFraccion.DisplayMember = "Colección"
            cmbColeccionFraccion.ValueMember = "ID"
        End If
    End Sub


    Public Sub llenarcomboMArca()
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        lista = obj.listaDeMarcasPNP(idnave)
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbMarcaFraccion.DataSource = lista
            cmbMarcaFraccion.DisplayMember = "Marca"
            cmbMarcaFraccion.ValueMember = "ID"
        End If
    End Sub

    Public Sub llenarComboMarcaFraccionReemplazar()
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        lista = obj.ListadoMarcasFraccionesNave(idnave, FraccionIDSeleccionada, ObservacionesFraccionSeleccionada)
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbMarcaFraccion.DataSource = lista
            cmbMarcaFraccion.DisplayMember = "Marca"
            cmbMarcaFraccion.ValueMember = "ID"
        End If
    End Sub

    Public Sub llenarcomboMArca2()
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        'lista = obj.ListaMArcasArticulosConConsumos()
        lista = obj.listaDeMarcasPNP(idnave)
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbMarca.DataSource = lista
            cmbMarca.DisplayMember = "Marca"
            cmbMarca.ValueMember = "ID"
        End If
    End Sub

    Public Sub llenarcomboMarcaMaterialSeleccionado(ByVal pCmbMarca As ComboBox)
        Dim obj As New catalagosBU
        Dim lista As New DataTable

        If rbCambioMaterial.Checked = True And lblMaterialaveid.Text <> "-" Or rbEliminarMaterial.Checked = True And lblMaterialaveid.Text <> "-" Then
            lista = obj.listaDeMarcasEnMaterialSeleccionado(idnave, lblMaterialaveid.Text)
        Else
            lista = obj.listaDeMarcasEnMaterialSeleccionadoNave(idnave)
        End If

        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            pCmbMarca.DataSource = lista
            pCmbMarca.DisplayMember = "Marca"
            pCmbMarca.ValueMember = "ID"
        End If
    End Sub

    Public Sub llenarcomboColeccion()
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        lista = obj.listaDeColeccionesPNP(idnave, cmbMarca.SelectedValue)
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbColeccion.DataSource = lista
            cmbColeccion.DisplayMember = "Coleccion"
            cmbColeccion.ValueMember = "ID"
        End If
    End Sub

    Public Sub llenarcomboColeccionMaterialSeleccionado(ByVal pCombobox As ComboBox)
        Dim obj As New catalagosBU
        Dim lista As New DataTable

        If rbCambioMaterial.Checked = True Then
            lista = obj.listaDeColeccionesMaterialesSeleccionados(idnave, lblMaterialaveid.Text, cmbMarca.SelectedValue)
        Else
            lista = obj.ObtenerColeccionesNaveMaterialesSeleccionados(idnave, cmbMarcaMaterialNuevo.SelectedValue)
        End If

        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            pCombobox.DataSource = lista
            pCombobox.DisplayMember = "Coleccion"
            pCombobox.ValueMember = "ID"
        End If
    End Sub

    Public Sub llenarcomboColeccion2()
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        'lista = obj.listaDeColeccionesPNP(idnave, cmbMarcaFraccion.SelectedValue)
        lista = obj.ListaColeccionesArticulosConConsumos(cmbMarca.SelectedValue, idnave)
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbColeccionFraccion.DataSource = lista
            cmbColeccionFraccion.DisplayMember = "Coleccion"
            cmbColeccionFraccion.ValueMember = "ID"
        End If
    End Sub

    Public Sub ActivarDesactivarFracciones()
        grdNuevaFraccion.DataSource = tablaFracciones
        grdFracciones.DataSource = Nothing
        If rdoNuevoFraccion.Checked = True Then
            'grdNuevaFraccion.Visible = True
            pnlFracciones.Visible = True
            pnlPrecioCambio.Visible = False
            pnlElimina.Visible = False
            pnlIncrementoGlobal.Visible = False
            pnlFiltroIncremento.Visible = False
            lblTitulo3.Visible = True
            lblTituloFraccion.Text = "Fracción Nueva"
            lblTitulo3.Text = "Artículos a Agregar Fracciones"
            pnlElimina.Visible = False
            txtPorcentajeIncremento.Text = String.Empty
            grdFraccionesIncremento.DataSource = Nothing
            Label2.Visible = True
            lblTitulo3.Visible = True
            cbxTodof.Visible = True
            lblMarcaFraccion.Visible = True
            cmbMarcaFraccion.Visible = True
            lblColeccionFraccion.Visible = True
            cmbColeccionFraccion.Visible = True
            btnMostrarFracciones.Visible = True
            lblMostrarFraccion.Visible = True
            btnLimpiarFracciones.Visible = True
            lblLimpiarFracciones.Visible = True
        ElseIf rdoCambioPrecio.Checked = True Then
            'grdNuevaFraccion.Visible = False
            pnlFracciones.Visible = False
            pnlPrecioCambio.Visible = True
            pnlElimina.Visible = False
            pnlIncrementoGlobal.Visible = False
            pnlFiltroIncremento.Visible = False
            lblTitulo3.Visible = True
            lblTituloFraccion.Text = "Precio Nuevo Fracción"
            lblTitulo3.Text = "Artículos a Modificar Precio Fracciones"
            txtPorcentajeIncremento.Text = String.Empty
            grdFraccionesIncremento.DataSource = Nothing
            Label2.Visible = True
            lblTitulo3.Visible = True
            cbxTodof.Visible = True
            lblMarcaFraccion.Visible = True
            cmbMarcaFraccion.Visible = True
            lblColeccionFraccion.Visible = True
            cmbColeccionFraccion.Visible = True
            btnMostrarFracciones.Visible = True
            lblMostrarFraccion.Visible = True
            btnLimpiarFracciones.Visible = True
            lblLimpiarFracciones.Visible = True
        ElseIf rbEliminarFraccion.Checked = True Then
            'grdNuevaFraccion.Visible = False
            pnlFracciones.Visible = False
            pnlPrecioCambio.Visible = False
            pnlElimina.Visible = True
            pnlIncrementoGlobal.Visible = False
            pnlFiltroIncremento.Visible = False
            lblTitulo3.Visible = True
            lblTituloFraccion.Text = "Eliminar Fracción"
            lblTitulo3.Text = "Artículos a Eliminar Fracciones"
            pnlPrecioCambio.Visible = False
            txtPorcentajeIncremento.Text = String.Empty
            grdFraccionesIncremento.DataSource = Nothing
            Label2.Visible = True
            lblTitulo3.Visible = True
            cbxTodof.Visible = True
            lblMarcaFraccion.Visible = True
            cmbMarcaFraccion.Visible = True
            lblColeccionFraccion.Visible = True
            cmbColeccionFraccion.Visible = True
            btnMostrarFracciones.Visible = True
            lblMostrarFraccion.Visible = True
            btnLimpiarFracciones.Visible = True
            lblLimpiarFracciones.Visible = True
        ElseIf rbtIncrementoGlobal.Checked = True Then
            'grdNuevaFraccion.Visible = False
            pnlFracciones.Visible = False
            pnlPrecioCambio.Visible = False
            pnlElimina.Visible = False
            pnlIncrementoGlobal.Visible = True
            pnlFiltroIncremento.Visible = True
            lblTituloFraccion.Text = "% Incremento Global"
            lblTitulo3.Text = "Fracciones a incrementar"
            Label2.Visible = False
            lblTitulo3.Visible = False
            cbxTodof.Visible = False
            lblMarcaFraccion.Visible = False
            cmbMarcaFraccion.Visible = False
            lblColeccionFraccion.Visible = False
            cmbColeccionFraccion.Visible = False
            btnMostrarFracciones.Visible = False
            lblMostrarFraccion.Visible = False
            btnLimpiarFracciones.Visible = False
            lblLimpiarFracciones.Visible = False
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
            For value = 0 To grdConsumos.Rows.Count - 1
                grdConsumos.Rows(value).Cells("").Value = 1
            Next
        Else
            For value = 0 To grdConsumos.Rows.Count - 1
                grdConsumos.Rows(value).Cells("").Value = 0
            Next
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabCambiosGlobales.SelectedIndexChanged
        If tabCambiosGlobales.SelectedIndex = 0 Then
            grdConsumos.DataSource = Nothing
            chkSeleccionarTodo.Visible = True

        ElseIf tabCambiosGlobales.SelectedIndex = 1 Then
            grdConsumos.DataSource = Nothing
            chkSeleccionarTodo.Visible = False

        End If
    End Sub

    Private Sub btnProveedor_Click(sender As Object, e As EventArgs) Handles btnProveedor.Click
        Dim form As New ListaProveedoresForm
        form.materialNaveid = lblIdMaterialNave.Text
        form.nave = idnave
        form.ShowDialog()
        lblProveedorSeleccionado.Text = form.Provedor
        lblIdProveedor.Text = form.idProveedor
        lblPreciotexto.Text += form.precio.ToString
        lblUMPtexto.Text += form.UMP
        lblIDUMP.Text += form.idUMP.ToString
        lblFactortexto.Text += form.equivalencia.ToString
    End Sub

    Private Sub btnMaterial_Click(sender As Object, e As EventArgs) Handles btnMaterial.Click
        Dim form As New listaMaterialesForm
        form.nave = idnave
        form.clasificacion = lblIdClasificacion.Text
        form.ShowDialog()
        lblIdMaterialNave.Text = form.materialNaveid
        lblMaterialSeleccionado.Text = form.Material
        lblIdMaterial.Text = form.idMaterial
        lblUMC.Text += form.UMC.ToString
        lblsku.Text += form.SKU.ToString
        lblIDUMC.Text += form.idUMC.ToString
        If lblIdMaterialNave.Text <> "-" And lblIdMaterialNave.Text <> "" And lblIdMaterialNave.Text <> "0" Then
            btnProveedor.Visible = True
        End If
        If form.idMaterial = 0 Then
            btnProveedor.Visible = False
            lblProveedorSeleccionado.Text = ""
            lblIdProveedor.Text = ""
            lblUMCtexto.Text = ""
            lblSKUtexto.Text = ""
            lblIDUMC.Text = ""
            lblIdProveedor.Text = ""
            lblPreciotexto.Text = ""
            lblUMPtexto.Text = ""
            lblIDUMC.Text = ""
            lblFactortexto.Text = ""
        End If
    End Sub

    Private Sub btnProveedorBuscar_Click(sender As Object, e As EventArgs)
        Dim form As New ListaProveedoresForm
        form.ShowDialog()
        btnBuscar.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim form As New ListaFraccionesNaveForm
        Dim Fraccion As String = String.Empty
        form.NaveID = idnave
        If form.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FraccionIDSeleccionada = form.FraccionId
            ObservacionesFraccionSeleccionada = form.Observaciones
            Fraccion = form.Fraccion
            lblValorFraccionSeleccionada.Text = Fraccion
            lblValorObservacionesSeleccionada.Text = ObservacionesFraccionSeleccionada
            lblFraccionCambioPrecio.Text = ObservacionesFraccionSeleccionada
            lblIdFraccionCambio.Text = FraccionIDSeleccionada
            llenarComboMarcaFraccionReemplazar()
        Else
            FraccionIDSeleccionada = 0
            ObservacionesFraccionSeleccionada = String.Empty
            lblValorFraccionSeleccionada.Text = "-"
            lblValorObservacionesSeleccionada.Text = "-"
            'cmbMarcaFraccion.DataSource = Nothing
        End If

        lblFraccionCambioPrecio.Text = form.Fraccion
        ' lblIdFraccionCambio.Text = form.id
    End Sub

    Private Sub grdNuevoConsumo_KeyUp(sender As Object, e As KeyEventArgs) Handles grdNuevoConsumo.KeyUp
        Dim VALUE As String
        Dim x, y, a, b As Double
        VALUE = e.KeyData
        If grdNuevoConsumo.ActiveRow.Cells("Material").Text <> "" And VALUE = 13 Then
            AgregarFilaConsumo()
        Else
            Try
                x = grdNuevoConsumo.ActiveRow.Cells("Factor Conversión").Value
                y = grdNuevoConsumo.ActiveRow.Cells("Precio Compra").Value
                grdNuevoConsumo.ActiveRow.Cells("Precio UM").Value = x / y

                a = grdNuevoConsumo.ActiveRow.Cells("Precio UM").Value
                b = grdNuevoConsumo.ActiveRow.Cells("Consumo").Text
                grdNuevoConsumo.ActiveRow.Cells("Costo Par").Value = a * b

            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub rdoNuevoFraccion_CheckedChanged(sender As Object, e As EventArgs) Handles rdoNuevoFraccion.CheckedChanged
        ActivarDesactivarFracciones()
        If rdoNuevoFraccion.Checked = True Then
            llenarcomboMArca()
            cmbColeccionFraccion.DataSource = Nothing
            Label2.Visible = True
        End If

        'If rdoNuevoFraccion.Checked = True Then
        '    grdNuevaFraccion.DataSource = Nothing
        '    crearTablaFracciones()
        '    diseniogridFracciones()
        'End If
    End Sub

    Private Sub rdoRemplazoFraccion_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCambioPrecio.CheckedChanged
        ActivarDesactivarFracciones()
        If rdoCambioPrecio.Checked = True Then
            cmbMarcaFraccion.DataSource = Nothing
            cmbColeccionFraccion.DataSource = Nothing
            FraccionIDSeleccionada = 0
            ObservacionesFraccionSeleccionada = String.Empty
            lblValorFraccionSeleccionada.Text = "-"
            lblValorObservacionesSeleccionada.Text = "-"
            txtCosto.Text = String.Empty
            Label2.Visible = False
        End If
        If rbEliminarFraccion.Checked = True Then
            cmbMarcaFraccion.SelectedValue = 0
            cmbColeccionFraccion.SelectedValue = 0
            grdFracciones.DataSource = Nothing
            cbxTodof.Checked = False
            lblFraccionElimina.Text = "-" 'String.Empty
            lblObservacionElimina.Text = "-" 'String.Empty
            lblValorFraccionSeleccionada.Text = "-"
            lblValorObservacionesSeleccionada.Text = "-"
            txtCosto.Text = String.Empty
        End If
        'If rdoCambioPrecio.Checked = True Then
        '    'grdNuevaFraccion.DataSource = Nothing
        '    crearTablaFracciones()
        '    diseniogridFracciones2()
        'End If
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

    Private Sub grdNuevaFraccion_KeyUp(sender As Object, e As KeyEventArgs) Handles grdNuevoConsumo.KeyUp
        Dim VALUE As String
        VALUE = e.KeyData
        Dim idmaterialnave = 0

        If e.KeyCode = Keys.F1 Then
            Dim a As String = ""
            If Not grdNuevoConsumo.ActiveRow.IsFilterRow Then
                Try
                    If grdNuevoConsumo.ActiveCell.Column.ToString = "Componente" Then
                        'Mostrar ventana de componente
                        Dim form As New ListaComponentesForm
                        form.ShowDialog()
                        grdNuevoConsumo.ActiveRow.Cells("id componente").Value = form.idComponente
                        grdNuevoConsumo.ActiveRow.Cells("Componente").Value = form.Componente
                    End If
                    If grdNuevoConsumo.ActiveCell.Column.ToString = "Clasificación" Then
                        'Mostrar ventana de clasificación
                        Dim form As New ListaClasificacionesForm
                        form.idcomponente = grdNuevoConsumo.ActiveRow.Cells("id componente").Value
                        form.ShowDialog()
                        grdNuevoConsumo.ActiveRow.Cells("id clasificación").Value = form.idClasificacion
                        grdNuevoConsumo.ActiveRow.Cells("Clasificación").Value = form.Clasificacion
                        grdNuevoConsumo.ActiveRow.Cells("id material").Value = 0
                        grdNuevoConsumo.ActiveRow.Cells("Material").Value = ""
                        grdNuevoConsumo.ActiveRow.Cells("SKU").Value = ""
                        grdNuevoConsumo.ActiveRow.Cells("idUMConsumo").Value = 0
                        grdNuevoConsumo.ActiveRow.Cells("UM Consumo").Value = ""
                        grdNuevoConsumo.ActiveRow.Cells("id proveedor").Value = 0
                        grdNuevoConsumo.ActiveRow.Cells("Proveedor").Value = ""
                        grdNuevoConsumo.ActiveRow.Cells("idUMProv").Value = 0
                        grdNuevoConsumo.ActiveRow.Cells("UM Proveedor").Value = ""
                        grdNuevoConsumo.ActiveRow.Cells("Factor Conversión").Value = 0
                        grdNuevoConsumo.ActiveRow.Cells("Precio Compra").Value = 0
                        grdNuevoConsumo.ActiveRow.Cells("Precio UM").Value = 0
                        grdNuevoConsumo.ActiveRow.Cells("Consumo").Value = 0
                        grdNuevoConsumo.ActiveRow.Cells("Costo Par").Value = 0
                    End If
                    If grdNuevoConsumo.ActiveCell.Column.ToString = "SKU" Or grdNuevoConsumo.ActiveCell.Column.ToString = "Material" Then
                        'Mostrar ventana de materiales
                        Dim form As New listaMaterialesForm
                        form.clasificacion = grdNuevoConsumo.ActiveRow.Cells("id clasificación").Value
                        form.nave = idnave
                        form.ShowDialog()
                        grdNuevoConsumo.ActiveRow.Cells("id material").Value = form.idMaterial
                        grdNuevoConsumo.ActiveRow.Cells("Material").Value = form.Material
                        grdNuevoConsumo.ActiveRow.Cells("SKU").Value = form.SKU
                        grdNuevoConsumo.ActiveRow.Cells("idUMConsumo").Value = form.idUMC
                        grdNuevoConsumo.ActiveRow.Cells("UM Consumo").Value = form.UMC
                        grdNuevoConsumo.ActiveRow.Cells("id proveedor").Value = 0
                        grdNuevoConsumo.ActiveRow.Cells("Proveedor").Value = ""
                        grdNuevoConsumo.ActiveRow.Cells("idUMProv").Value = 0
                        grdNuevoConsumo.ActiveRow.Cells("UM Proveedor").Value = ""
                        grdNuevoConsumo.ActiveRow.Cells("Factor Conversión").Value = 0
                        grdNuevoConsumo.ActiveRow.Cells("Precio Compra").Value = 0
                        grdNuevoConsumo.ActiveRow.Cells("Precio UM").Value = 0
                        grdNuevoConsumo.ActiveRow.Cells("Consumo").Value = 0
                        txtaux.Text = form.materialNaveid
                    End If
                    If grdNuevoConsumo.ActiveCell.Column.ToString = "Proveedor" Then
                        'Mostrar ventana de proveedor
                        Dim form As New ListaProveedoresForm
                        form.materialNaveid = txtaux.Text
                        form.nave = idnave
                        form.ShowDialog()
                        grdNuevoConsumo.ActiveRow.Cells("id proveedor").Value = form.idProveedor
                        grdNuevoConsumo.ActiveRow.Cells("Proveedor").Value = form.Provedor
                        grdNuevoConsumo.ActiveRow.Cells("idUMProv").Value = form.idUMP
                        grdNuevoConsumo.ActiveRow.Cells("UM Proveedor").Value = form.UMP
                        grdNuevoConsumo.ActiveRow.Cells("Factor Conversión").Value = form.equivalencia
                        grdNuevoConsumo.ActiveRow.Cells("Precio Compra").Value = form.precio
                        grdNuevoConsumo.ActiveRow.Cells("Precio UM").Value = (form.precio * form.equivalencia)

                        If rdoCambioProveedor.Checked = True Then
                            grdNuevoConsumo.ActiveRow.Cells("Costo Par").Value = grdNuevoConsumo.ActiveRow.Cells("Precio UM").Value * grdNuevoConsumo.ActiveRow.Cells("Consumo").Value
                        End If

                    End If

                Catch ex As Exception
                End Try
            End If

        ElseIf e.KeyCode = Keys.Enter Then
            Try
                If nuevoconsumo() Then
                    grdConsumos.DisplayLayout.Bands(0).AddNew()
                    grdConsumos.ActiveRow.Cells("Editado").Value = 0
                    grdConsumos.ActiveRow.Cells("idConsumo").Value = 0
                    grdConsumos.ActiveRow.Cells("Bloqueado").Value = CBool(False)
                    grdConsumos.ActiveRow.Cells("Explosionar").Value = CBool(False)
                    grdConsumos.ActiveRow.Cells("Lotear").Value = CBool(False)
                Else
                    adv.mensaje = "Todos los campos en los consumos son obligatorios."
                    adv.StartPosition = FormStartPosition.CenterScreen
                    adv.ShowDialog()
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub

    Public Sub calcularTotal()

        Try
            If grdNuevoConsumo.ActiveCell.Column.ToString = "Consumo" Then
                'If grdNuevoConsumo.ActiveRow.Cells("Consumo").Value <> 0 Then
                grdNuevoConsumo.ActiveRow.Cells("Costo Par").Value = grdNuevoConsumo.ActiveRow.Cells("Consumo").Text * grdNuevoConsumo.ActiveRow.Cells("Precio UM").Text
                'End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        'If rdoNuevo.Checked = True Then
        '    If cmbMarcaBusqueda.Text <> "" Then
        'filtrar()
        '    Else
        '    End If
        'End If

        'If cmbMarca.Text <> "" Then
        If rdoRemplazoMaterial.Checked = True Then
            'If cmbMarcaBusqueda.Text <> "" Then
            filtrar2()
            'Else
            'End If
        End If
        'Else
        'objadvertencia.mensaje = "Seleccione una marca"
        'objadvertencia.StartPosition = FormStartPosition.CenterScreen
        'objadvertencia.ShowDialog()
        'lblMarcaConsumos.ForeColor = Drawing.Color.Red
        'End If


        'If rdoCambioProveedor.Checked = True Then
        '    If cmbMarcaBusqueda.Text <> "" And lblProveedorSeleccionado.Text <> "-" And lblProveedorSeleccionado.Text <> "" Then
        '        filtrar3()
        '    Else
        '        objadvertencia.mensaje = "No ha selecciónado proveedor a reemplazar"
        '        objadvertencia.ShowDialog()
        '    End If
        'End If

    End Sub

    Public Sub filtrar()
        Dim obj As New catalagosBU
        Dim marca, coleccion As Integer
        Dim lista As New DataTable
        Dim listaComponentes As New List(Of Integer)
        Dim listaProdEstilo As New List(Of Integer)
        Dim accion As Integer = 0

        Try
            For value = 0 To grdNuevoConsumo.Rows.Count - 1
                listaComponentes.Add(grdNuevoConsumo.Rows(value).Cells("id componente").Value)
            Next
        Catch ex As Exception

        End Try

        If cmbMarcaBusqueda.Text = "" Then
            marca = 0
        Else
            marca = cmbMarcaBusqueda.SelectedValue
        End If
        If cmbColeccionBusqueda.Text = "" Then
            coleccion = 0
        Else
            coleccion = cmbColeccionBusqueda.SelectedValue
        End If
        'obtener lista de productos y sus id consumos
        lista = obj.filtradoCambiosGlobales(idnave, marca, coleccion, listaComponentes, listaProdEstilo, accion)
        Dim x1, x2, y As Integer

        For value = 0 To lista.Rows.Count - 1
            For value2 = 0 To listaComponentes.Count - 1
                x1 = lista.Rows(value).Item("comp")
                x2 = CInt(listaComponentes.Item(value2))
                y = lista.Rows(value).Item("idEstilo")
                If x1 = x2 Then
                    listaProdEstilo.Add(y)
                End If
            Next
        Next
        accion = 1
        lista = obj.filtradoCambiosGlobales2(idnave, marca, coleccion, listaComponentes, listaProdEstilo, accion)

        grdConsumos.DataSource = lista
        disenogrd()
    End Sub

    Public Sub filtrar2()
        Dim obj As New catalagosBU
        Dim marca, coleccion As Integer
        Dim lista As New DataTable
        Dim listaComponentes As New List(Of Integer)
        Dim listaProdEstilo As New List(Of Integer)
        Dim listaMateriales As New List(Of Integer)
        Dim accion As Integer

        'Try
        '    For value = 0 To grdNuevoConsumo.Rows.Count - 1
        '        listaComponentes.Add(grdNuevoConsumo.Rows(value).Cells("id componente").Value)
        '    Next
        '    For value = 0 To grdNuevoConsumo.Rows.Count - 1
        '        listaMateriales.Add(grdNuevoConsumo.Rows(value).Cells("id material").Value)
        '    Next
        'Catch ex As Exception
        'End Try
        If listaComponentes.Count >= 0 Then
            accion = 1
        End If

        If cmbMarca.Text = "" Then
            marca = 0
        Else
            marca = cmbMarca.SelectedValue
        End If
        If cmbColeccion.Text <> "" Then
            coleccion = cmbColeccion.SelectedValue
        Else
            coleccion = 0
        End If
        Dim idclass As Integer = 0
        Dim idmaterial As Integer = 0
        Try

            If lblIdclass.Text <> "-" Then
                idclass = CInt(lblIdclass.Text)
            End If
            If lblIdmaterialremplazarTexto.Text <> "-" Then
                idmaterial = CInt(lblIdmaterialremplazarTexto.Text)
            End If

            lista = obj.filtradoCambiosGlobales3(idnave, lblMaterialaveid.Text, idclass, marca, coleccion, lblidProveedorOriginal.Text)

            If lista.Rows.Count > 0 Then
                grdConsumos.DataSource = lista
            Else
                If rbCambioMaterial.Checked = True Then
                    adv.mensaje = "No hay artículos con el material a reemplazar"
                    adv.StartPosition = FormStartPosition.CenterScreen
                    adv.ShowDialog()
                Else
                    adv.mensaje = "No hay artículos con el material a eliminar"
                    adv.StartPosition = FormStartPosition.CenterScreen
                    adv.ShowDialog()
                End If
            End If
        Catch ex As Exception
        End Try

        Try
            disenogrd()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub filtrar3()
        Dim obj As New catalagosBU
        Dim marca, coleccion As Integer
        Dim lista As New DataTable
        Dim idclasificacion, idmaterialnave, idproveedor As Integer

        marca = cmbMarcaBusqueda.SelectedValue
        If cmbColeccionBusqueda.Text <> "" Then
            coleccion = cmbColeccionBusqueda.SelectedValue
        Else
            coleccion = 0
        End If
        idclasificacion = lblIdClasificacion.Text
        idmaterialnave = lblIdProveedor.Text
        idproveedor = lblIdProveedor.Text

        lista = obj.filtradoCambiosGlobales4(idnave, idclasificacion, idmaterialnave, idproveedor, marca, coleccion)

        grdConsumos.DataSource = lista
        Try
            disenogrd()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub disenogrd()
        Dim band As UltraGridBand = Me.grdConsumos.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2

        With grdConsumos.DisplayLayout.Bands(0)
            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Marca").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("Modelo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Colección").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Codigo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Piel Color").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Corrida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("Asignado a Producción").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Cliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Estatus").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("idEstilo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            If rbNuevoMaterial.Checked = False Then
                .Columns("Total Materiales").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Material").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Componente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Total Materiales").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Total Materiales").Header.Caption = "Total" & vbCrLf & "Materiales"
                .Columns("Total Materiales").Width = 60
                .Columns("Componente").Width = 45
            End If

            .Columns("Codigo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Corrida").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Asignado a Producción").Header.Caption = "Asignado a" & vbCrLf & "Producción"
            .Columns("Estatus").Header.Caption = "  "
            .Columns("Codigo").Header.Caption = "Código"
            .Columns(" ").Width = 10
            .Columns("Marca").Width = 50
            .Columns("Codigo").Width = 50
            .Columns("Colección").Width = 60
            .Columns("Modelo").Width = 80
            .Columns("Corrida").Width = 50
            .Columns("Asignado a Producción").Width = 100
            .Columns("Cliente").Width = 80
            .Columns("Estatus").Width = 10
            .Columns("Piel Color").Width = 60
            .Columns("idEstilo").Hidden = True

            For value = 0 To grdConsumos.Rows.Count - 1
                If grdConsumos.Rows(value).Cells("Estatus").Text = "D" Then
                    grdConsumos.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF00")
                    grdConsumos.Rows(value).Cells("Estatus").Value = ""
                ElseIf grdConsumos.Rows(value).Cells("Estatus").Text = "AD" Then
                    grdConsumos.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#31B404")
                    grdConsumos.Rows(value).Cells("Estatus").Value = ""
                ElseIf grdConsumos.Rows(value).Cells("Estatus").Text = "AP" Then
                    grdConsumos.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E9AFE")
                    grdConsumos.Rows(value).Cells("Estatus").Value = ""
                ElseIf grdConsumos.Rows(value).Cells("Estatus").Text = "I" Then
                    grdConsumos.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#424242")
                    grdConsumos.Rows(value).Cells("Estatus").Value = ""
                ElseIf grdConsumos.Rows(value).Cells("Estatus").Text = "DP" Then
                    grdConsumos.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#DF0101")
                    grdConsumos.Rows(value).Cells("Estatus").Value = ""
                End If
            Next
        End With
        grdConsumos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdConsumos.DisplayLayout.RowSelectorImages.DataChangedImage = Nothing
        grdConsumos.DisplayLayout.RowSelectorImages.ActiveAndDataChangedImage = Nothing
        grdConsumos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    End Sub

    Public Sub disenogrdFracciones()
        Dim band As UltraGridBand = Me.grdFracciones.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2

        With grdFracciones.DisplayLayout.Bands(0)
            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Marca").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Modelo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Colección").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Codigo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Piel Color").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Corrida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("Total Materiales").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Asignado a Producción").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Cliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Estatus").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("idEstilo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Total Fracciones").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Total Fracciones").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("Modelo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("SICY").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left

            .Columns("Codigo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Corrida").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Total Materiales").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("status").Hidden = True
            .Columns("Piel").Hidden = True
            .Columns("Color").Hidden = True
            .Columns("pres_navedesarrollaid").Hidden = True

            .Columns("Total Materiales").Format = "##,##0.00"
            .Columns("Total Fracciones").Format = "##,##0.000"


            .Columns("Total Materiales").Header.Caption = "Total" & vbCrLf & "Materiales"
            .Columns("Asignado a Producción").Header.Caption = "Asignado a" & vbCrLf & "Producción"

            .Columns("Total Fracciones").Header.Caption = "Total" & vbCrLf & "Fracciones"
            .Columns("Marca").Hidden = True
            .Columns("Estatus").Header.Caption = "  "

            .Columns(" ").Width = 10
            .Columns("Marca").Width = 50
            .Columns("Codigo").Width = 30
            .Columns("Colección").Width = 60
            .Columns("Modelo").Width = 50
            .Columns("Corrida").Width = 60
            .Columns("Total Materiales").Width = 40
            .Columns("Asignado a Producción").Width = 100
            .Columns("Cliente").Width = 80
            .Columns("Estatus").Width = 10
            .Columns("Piel Color").Width = 60
            .Columns("Total Fracciones").Width = 60
            .Columns("idEstilo").Hidden = True
            .Columns("SICY").Width = 70


            For value = 0 To grdFracciones.Rows.Count - 1
                If grdFracciones.Rows(value).Cells("Estatus").Text = "D" Then
                    grdFracciones.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF00")
                    grdFracciones.Rows(value).Cells("Estatus").Value = ""
                ElseIf grdFracciones.Rows(value).Cells("Estatus").Text = "AD" Then
                    grdFracciones.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#31B404")
                    grdFracciones.Rows(value).Cells("Estatus").Value = ""
                ElseIf grdFracciones.Rows(value).Cells("Estatus").Text = "AP" Then
                    grdFracciones.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E9AFE")
                    grdFracciones.Rows(value).Cells("Estatus").Value = ""
                ElseIf grdFracciones.Rows(value).Cells("Estatus").Text = "I" Then
                    grdFracciones.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8000")
                    grdFracciones.Rows(value).Cells("Estatus").Value = ""
                ElseIf grdFracciones.Rows(value).Cells("Estatus").Text = "DP" Then
                    grdFracciones.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#DF0101")
                    grdFracciones.Rows(value).Cells("Estatus").Value = ""
                End If
            Next
        End With
        grdFracciones.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdFracciones.DisplayLayout.RowSelectorImages.DataChangedImage = Nothing
        grdFracciones.DisplayLayout.RowSelectorImages.ActiveAndDataChangedImage = Nothing
        grdFracciones.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    End Sub

    Private Sub grdNuevaFraccion_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdNuevaFraccion.AfterCellUpdate
        Dim Valor As Double = 0
        If CargoCompleto = True Then

            If ActualizarCeldaCosto = True Then
                If grdNuevaFraccion.ActiveCell.Column.ToString = "Costo" Then
                    If IsDBNull(e.Cell.Value) = False Then
                        Valor = CDbl(e.Cell.Value)
                        Valor = Math.Round(Valor, 3)
                        ActualizarCeldaCosto = False
                        e.Cell.Value = Valor.ToString("F3")
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub grdNuevaFraccion_CellChange(sender As Object, e As CellEventArgs) Handles grdNuevaFraccion.CellChange
        If CargoCompleto = True Then
            If grdNuevaFraccion.ActiveCell.Column.ToString = "Costo" Then
                ActualizarCeldaCosto = True
            End If
        End If

    End Sub

    Private Sub grdNuevaFraccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdNuevaFraccion.KeyDown

        Try
            If grdNuevaFraccion.ActiveCell.Column.ToString = "Horas" Then
                If e.KeyCode = Windows.Forms.Keys.Enter Then
                    Me.grdNuevaFraccion.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell)
                    Me.grdNuevaFraccion.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            ElseIf grdNuevaFraccion.ActiveCell.Column.ToString = "Minutos" Then
                If e.KeyCode = Windows.Forms.Keys.Enter Then
                    Me.grdNuevaFraccion.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell)
                    Me.grdNuevaFraccion.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            ElseIf grdNuevaFraccion.ActiveCell.Column.ToString = "Costo" Then
                If e.KeyCode = Windows.Forms.Keys.Enter Then
                    grdNuevaFraccion.PerformAction(UltraGridAction.ExitEditMode, False, False)
                    Dim banda As UltraGridBand = grdNuevaFraccion.DisplayLayout.Bands(0)
                    If grdNuevaFraccion.ActiveRow.HasNextSibling(True) Then
                        Dim nextRow As UltraGridRow = grdNuevaFraccion.ActiveRow.GetSibling(SiblingRow.Next, True)
                        grdNuevaFraccion.ActiveCell = nextRow.Cells(grdNuevaFraccion.ActiveCell.Column)
                        e.Handled = True
                        grdNuevaFraccion.PerformAction(UltraGridAction.EnterEditMode, False, False)
                    End If
                End If
            Else
                'grdNuevaFraccion.PerformAction(UltraGridAction.ExitEditMode, False, False)
                'Dim banda As UltraGridBand = grdNuevaFraccion.DisplayLayout.Bands(0)
                'If grdNuevaFraccion.ActiveRow.HasNextSibling(True) Then
                '    Dim nextRow As UltraGridRow = grdNuevaFraccion.ActiveRow.GetSibling(SiblingRow.Next, True)
                '    grdNuevaFraccion.ActiveCell = nextRow.Cells(grdNuevaFraccion.ActiveCell.Column)
                '    e.Handled = True
                '    grdNuevaFraccion.PerformAction(UltraGridAction.EnterEditMode, False, False)
                'End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Up Then
                grdNuevaFraccion.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdNuevaFraccion.DisplayLayout.Bands(0)
                If grdNuevaFraccion.ActiveRow.HasPrevSibling(True) Then
                    Dim nextRow As UltraGridRow = grdNuevaFraccion.ActiveRow.GetSibling(SiblingRow.Previous, True)
                    grdNuevaFraccion.ActiveCell = nextRow.Cells(grdNuevaFraccion.ActiveCell.Column)
                    e.Handled = True
                    grdNuevaFraccion.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Down Then
                grdNuevaFraccion.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdNuevaFraccion.DisplayLayout.Bands(0)
                If grdNuevaFraccion.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdNuevaFraccion.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdNuevaFraccion.ActiveCell = nextRow.Cells(grdNuevaFraccion.ActiveCell.Column)
                    e.Handled = True
                    grdNuevaFraccion.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If grdNuevaFraccion.ActiveCell.Column.ToString = "Observaciones" Then
                'actualizarLista(grdNuevaFraccion.ActiveCell.Value.ToString)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdNuevaFraccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdNuevaFraccion.KeyPress
        Try
            If grdNuevaFraccion.ActiveCell.Column.ToString = "Horas" Then
                If grdNuevaFraccion.Rows.Count > 0 Then
                    Try
                        If Not grdNuevaFraccion.ActiveCell.IsFilterRowCell Then

                            If Char.IsDigit(e.KeyChar) Then
                                If grdNuevaFraccion.ActiveRow.Cells("Horas").Text = "" Then
                                    If e.KeyChar = "0" Or e.KeyChar = "1" Or e.KeyChar = "2" Or e.KeyChar = "3" Or e.KeyChar = "4" Or e.KeyChar = "5" Then
                                        e.Handled = False
                                    Else
                                        e.Handled = True
                                    End If
                                ElseIf grdNuevaFraccion.ActiveRow.Cells("Horas").Text.Length = 1 Then
                                    If grdNuevaFraccion.ActiveRow.Cells("Horas").Text = 0 Then
                                        If e.KeyChar = "0" Or e.KeyChar = "1" Or e.KeyChar = "2" Or e.KeyChar = "3" Or e.KeyChar = "4" Or e.KeyChar = "5" Or
                                             e.KeyChar = "6" Or e.KeyChar = "7" Or e.KeyChar = "8" Or e.KeyChar = "9" Or e.KeyChar = "10" Then
                                            e.Handled = False
                                        Else
                                            e.Handled = True
                                        End If
                                    Else
                                        If Char.IsDigit(e.KeyChar) Then
                                            e.Handled = False
                                        Else
                                            e.Handled = True
                                        End If
                                    End If
                                ElseIf grdNuevaFraccion.ActiveRow.Cells("Horas").Text.Length = 2 Then
                                    e.Handled = True
                                End If
                            ElseIf Char.IsControl(e.KeyChar) Then
                                e.Handled = False
                            ElseIf e.KeyChar = "." Then
                                e.Handled = True
                            Else
                                e.Handled = True
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                End If
            End If

            If grdNuevaFraccion.ActiveCell.Column.ToString = "Minutos" Then
                If grdNuevaFraccion.Rows.Count > 0 Then
                    Try
                        If Not grdNuevaFraccion.ActiveCell.IsFilterRowCell Then

                            If Char.IsDigit(e.KeyChar) Then
                                If grdNuevaFraccion.ActiveRow.Cells("Minutos").Text = "" Then
                                    If e.KeyChar = "0" Or e.KeyChar = "1" Or e.KeyChar = "2" Or e.KeyChar = "3" Or e.KeyChar = "4" Or e.KeyChar = "5" Then
                                        e.Handled = False
                                    Else
                                        e.Handled = True
                                    End If
                                ElseIf grdNuevaFraccion.ActiveRow.Cells("Minutos").Text.Length = 1 Then
                                    If grdNuevaFraccion.ActiveRow.Cells("Minutos").Text = 0 Then
                                        If e.KeyChar = "0" Or e.KeyChar = "1" Or e.KeyChar = "2" Or e.KeyChar = "3" Or e.KeyChar = "4" Or e.KeyChar = "5" Or
                                             e.KeyChar = "6" Or e.KeyChar = "7" Or e.KeyChar = "8" Or e.KeyChar = "9" Or e.KeyChar = "10" Then
                                            e.Handled = False
                                        Else
                                            e.Handled = True
                                        End If
                                    Else
                                        If Char.IsDigit(e.KeyChar) Then
                                            e.Handled = False
                                        Else
                                            e.Handled = True
                                        End If
                                    End If
                                ElseIf grdNuevaFraccion.ActiveRow.Cells("Minutos").Text.Length = 2 Then
                                    e.Handled = True
                                End If
                            ElseIf Char.IsControl(e.KeyChar) Then
                                e.Handled = False
                            ElseIf e.KeyChar = "." Then
                                e.Handled = True
                            Else
                                e.Handled = True
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                End If
            End If

            If grdNuevaFraccion.ActiveCell.Column.ToString = "Segundos" Then
                If grdNuevaFraccion.Rows.Count > 0 Then
                    Try
                        If Not grdNuevaFraccion.ActiveCell.IsFilterRowCell Then

                            If Char.IsDigit(e.KeyChar) Then
                                If grdNuevaFraccion.ActiveRow.Cells("Segundos").Text = "" Then
                                    If e.KeyChar = "0" Or e.KeyChar = "1" Or e.KeyChar = "2" Or e.KeyChar = "3" Or e.KeyChar = "4" Or e.KeyChar = "5" Then
                                        e.Handled = False
                                    Else
                                        e.Handled = True
                                    End If
                                ElseIf grdNuevaFraccion.ActiveRow.Cells("Segundos").Text.Length = 1 Then
                                    If grdNuevaFraccion.ActiveRow.Cells("Segundos").Text = 0 Then
                                        If e.KeyChar = "0" Or e.KeyChar = "1" Or e.KeyChar = "2" Or e.KeyChar = "3" Or e.KeyChar = "4" Or e.KeyChar = "5" Or
                                             e.KeyChar = "6" Or e.KeyChar = "7" Or e.KeyChar = "8" Or e.KeyChar = "9" Or e.KeyChar = "10" Then
                                            e.Handled = False
                                        Else
                                            e.Handled = True
                                        End If
                                    Else
                                        If Char.IsDigit(e.KeyChar) Then
                                            e.Handled = False
                                        Else
                                            e.Handled = True
                                        End If
                                    End If
                                ElseIf grdNuevaFraccion.ActiveRow.Cells("Segundos").Text.Length = 2 Then
                                    e.Handled = True
                                End If
                            ElseIf Char.IsControl(e.KeyChar) Then
                                e.Handled = False
                            ElseIf e.KeyChar = "." Then
                                e.Handled = True
                            Else
                                e.Handled = True
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                End If
            End If
            If grdNuevaFraccion.ActiveCell.Column.ToString = "Orden" Then
                If Char.IsDigit(e.KeyChar) Then
                    e.Handled = False
                ElseIf Char.IsControl(e.KeyChar) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End If
            If grdNuevaFraccion.ActiveCell.Column.ToString = "Observaciones" Then
                If Char.IsDigit(e.KeyChar) Or Char.IsLetter(e.KeyChar) Then
                    e.Handled = False
                ElseIf Char.IsControl(e.KeyChar) Then
                    e.Handled = False
                ElseIf e.KeyChar = "." Or e.KeyChar = "-" Or e.KeyChar = "/" Or e.KeyChar = "#" Then
                    e.Handled = False
                ElseIf e.KeyChar = " " Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End If


        Catch ex As Exception
        End Try


        'If grdConsumos.Rows.Count > 0 Then
        '    Try
        '        If Not grdConsumos.ActiveCell.IsFilterRowCell Then

        '            If Char.IsDigit(e.KeyChar) Then
        '                e.Handled = False
        '            ElseIf Char.IsControl(e.KeyChar) Then
        '                e.Handled = False
        '            ElseIf e.KeyChar = "." Then
        '                e.Handled = False
        '            Else
        '                e.Handled = True
        '            End If
        '        End If
        '    Catch ex As Exception
        '    End Try
        'End If
    End Sub

    Private Sub cmbMarcaBusqueda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarcaBusqueda.SelectedIndexChanged
        Try
            llenarcomboColeccion()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbxTodo_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTodo.CheckedChanged
        Dim x = 0

        If cbxTodo.Text = "Seleccionar todo" And x = 0 Then
            For Each row In grdConsumos.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = True
            Next
            cbxTodo.Text = "Deseleccionar todo"
            x = x + 1
        End If

        If cbxTodo.Text = "Deseleccionar todo" And x = 0 Then
            For Each row In grdConsumos.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = False
            Next
            cbxTodo.Text = "Seleccionar todo"
            x = x + 1
        End If

    End Sub

    Public Sub ReemplazarPrecioFracciones(ByVal productoEstiloid As Integer, ByVal fraccionid As Integer, ByVal precio As Double, ByVal NaveID As Integer, ByVal Observaciones As String)
        Dim obj As New catalagosBU
        obj.ActualizarPrecioFraccion2(productoEstiloid, fraccionid, precio, NaveID, Observaciones, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Public Function ValidarNuevaFraccion() As Boolean
        Dim FraccionValida As Boolean = True


        If grdNuevaFraccion.Rows.Count > 0 Then

            For Each Fila As UltraGridRow In grdNuevaFraccion.Rows

                If IsDBNull(Fila.Cells("idFraccion").Value) = True Then
                    FraccionValida = False
                End If

                If IsDBNull(Fila.Cells("Costo").Value) = True Then
                    FraccionValida = False
                End If

                'tablaFracciones.Columns.Add("Activo")
                'tablaFracciones.Columns.Add("idFraccion")
                'tablaFracciones.Columns.Add("idFraccDes")
                'tablaFracciones.Columns.Add("Orden")
                'tablaFracciones.Columns.Add("Fracción")
                'tablaFracciones.Columns.Add("Costo")
                'tablaFracciones.Columns.Add("Pagar")
                'tablaFracciones.Columns.Add("Sumar Costo")
                'tablaFracciones.Columns.Add("Horas")
                'tablaFracciones.Columns.Add("Minutos")
                'tablaFracciones.Columns.Add("Segundos")
                'tablaFracciones.Columns.Add("Sumar Tiempo")
                'tablaFracciones.Columns.Add("Maquinaria")
                'tablaFracciones.Columns.Add("Observaciones")
                'tablaFracciones.Columns.Add("maquinaid")

            Next

        Else
            FraccionValida = False
        End If

        Return FraccionValida

    End Function

    Public Function BuscarOrdenRepetidoFraccionNueva() As Boolean
        Dim existeRepetido As Boolean = False
        Dim contador As Integer = 0

        For Each FraccionNueva As UltraGridRow In grdNuevaFraccion.Rows
            If IsDBNull(FraccionNueva.Cells("Orden").Value) = False Then
                contador = 0
                For Each FraccionRepetida As UltraGridRow In grdNuevaFraccion.Rows
                    If IsDBNull(FraccionRepetida.Cells("Orden").Value) = False Then

                        If FraccionNueva.Cells("Orden").Value = FraccionRepetida.Cells("Orden").Value Then
                            contador = contador + 1
                        End If
                    End If
                Next
                If contador > 2 Then
                    If existeRepetido <> True Then
                        existeRepetido = True
                    End If
                End If
            End If
        Next

        Return existeRepetido
    End Function

    Private Sub btnGuardarConsumo_Click(sender As Object, e As EventArgs) Handles btnGuardarConsumo.Click
        Dim obj As New catalagosBU
        Dim contadores = 0
        Dim selecciones = 0

        If Me.tabCambiosGlobales.SelectedTab Is Fracciones Then
            Dim ExisteFraccion As Integer = 0
            Dim Fraccion As Fracciones
            Dim objFraccion As New ConsumosBU
            Dim tabla As New DataTable
            Dim Orden As Integer = 0
            Dim TablaFracccinesEstilo As DataTable
            Dim ContadorFraccionSeleccionada As Integer = 0
            If rdoNuevoFraccion.Checked = True Then
                If ValidarNuevaFraccion() = False Then
                    adv.mensaje = "Falta información por cargar de la fracción"
                    adv.StartPosition = FormStartPosition.CenterScreen
                    adv.ShowDialog()
                    Return
                End If

                If BuscarOrdenRepetidoFraccionNueva() = True Then
                    adv.mensaje = "Hay dos fracciones con el mismo orden."
                    adv.StartPosition = FormStartPosition.CenterScreen
                    adv.ShowDialog()
                    Return
                End If


                If grdFracciones.Rows.Count = 0 Then
                    adv.mensaje = "Debe seleccionar un artículo para agregar la Fracción"
                    adv.StartPosition = FormStartPosition.CenterScreen
                    adv.ShowDialog()

                Else
                    Me.Cursor = Cursors.WaitCursor

                    For Each FraccionSeleccionada As UltraGridRow In grdFracciones.Rows
                        If FraccionSeleccionada.Cells(" ").Value Then
                            ContadorFraccionSeleccionada = ContadorFraccionSeleccionada + 1
                        End If
                    Next

                    If ContadorFraccionSeleccionada > 0 Then

                        For Each FraccionSeleccionada As UltraGridRow In grdFracciones.Rows
                            'If grdFracciones.Rows(value).Cells(" ").Value Then
                            If FraccionSeleccionada.Cells(" ").Value Then

                                For Each FraccionNueva As UltraGridRow In grdNuevaFraccion.Rows
                                    tabla = obj.ObtenerFraccionesProductoEstiloNave(FraccionSeleccionada.Cells("idEstilo").Value, idnave, FraccionNueva.Cells("idFraccion").Text, FraccionNueva.Cells("Observaciones").Value.ToString)

                                    If tabla.Rows.Count > 0 Then
                                        ExisteFraccion = ExisteFraccion + 1
                                    Else
                                        Fraccion = New Fracciones

                                        Fraccion.productoEstiloId = FraccionSeleccionada.Cells("idEstilo").Value
                                        Fraccion.frap_fraccionid = FraccionNueva.Cells("idFraccion").Text
                                        Fraccion.fraccionidProd = 0 'Fila.Cells("idFraccDes").Value
                                        Fraccion.frap_precio = FraccionNueva.Cells("Costo").Text
                                        If FraccionNueva.Cells("Pagar").Value = True Then
                                            Fraccion.frap_paga = 1
                                        Else
                                            Fraccion.frap_paga = 0
                                        End If

                                        If FraccionNueva.Cells("Sumar Costo").Value = True Then
                                            Fraccion.sumar_Costo = 1
                                        Else
                                            Fraccion.sumar_Costo = 0
                                        End If

                                        If FraccionNueva.Cells("Sumar Tiempo").Value = True Then
                                            Fraccion.sumar_Tiempo = 1
                                        Else
                                            Fraccion.sumar_Tiempo = 0
                                        End If

                                        'Fraccion.frap_paga = Convert.ToInt32(FraccionNueva.Cells("Pagar").Value)
                                        'Fraccion.sumar_Costo = Convert.ToInt32(FraccionNueva.Cells("Sumar Costo").Value)
                                        'Fraccion.sumar_Tiempo = Convert.ToInt32(FraccionNueva.Cells("Sumar Tiempo").Value)

                                        If FraccionNueva.Cells("Horas").Value.ToString = "" Then
                                            Fraccion.horas_ = 0
                                        Else
                                            Fraccion.horas_ = FraccionNueva.Cells("Horas").Value.ToString
                                        End If
                                        If FraccionNueva.Cells("Minutos").Value.ToString = "" Then
                                            Fraccion.minutos_ = 0
                                        Else
                                            Fraccion.minutos_ = FraccionNueva.Cells("Minutos").Value.ToString
                                        End If
                                        If FraccionNueva.Cells("Segundos").Value.ToString = "" Then
                                            Fraccion.segundos_ = 0
                                        Else
                                            Fraccion.segundos_ = FraccionNueva.Cells("Segundos").Value.ToString
                                        End If
                                        Fraccion.frap_activo = 1

                                        Fraccion.accion = 1

                                        Fraccion.idNave = idnave
                                        Try
                                            Fraccion.observaciones = FraccionNueva.Cells("Observaciones").Value.ToString.ToUpper()
                                        Catch ex As Exception
                                            Fraccion.observaciones = ""
                                        End Try
                                        Try
                                            Fraccion.maquinariaid = FraccionNueva.Cells("maquinaid").Value
                                        Catch ex As Exception
                                            Fraccion.maquinariaid = 0
                                        End Try

                                        TablaFracccinesEstilo = obj.ObtenerFraccionesProductoEstiloNave(FraccionSeleccionada.Cells("idEstilo").Value, idnave)

                                        If IsDBNull(FraccionNueva.Cells("Orden").Value) = True Then
                                            Fraccion.noOrden = TablaFracccinesEstilo.Rows.Count + 1
                                        Else
                                            If grdNuevaFraccion.Rows.Count > 1 Then
                                                Fraccion.noOrden = TablaFracccinesEstilo.Rows.Count + 1
                                            Else
                                                Fraccion.noOrden = FraccionNueva.Cells("Orden").Value
                                            End If


                                            'If tablaFracciones.Rows.Count <= FraccionNueva.Cells("Orden").Value Then
                                            '    Fraccion.noOrden = FraccionNueva.Cells("Orden").Value
                                            '    ActualizarOrdenFracciones(Fraccion.noOrden, FraccionSeleccionada.Cells("idEstilo").Value, idnave)
                                            'Else
                                            '    Fraccion.noOrden = TablaFracccinesEstilo.Rows.Count + 1
                                            'End If
                                        End If

                                        Dim dato As New DataTable
                                        dato = objFraccion.insertFraccionDes(Fraccion)


                                        If Fraccion.fraccionidProd = 0 Then
                                            Try
                                                Fraccion.fraccionidProd = CInt(dato.Rows(0).Item(0).ToString)
                                                objFraccion.inserOrdenamientoFracion(Fraccion)
                                            Catch ex As Exception
                                            End Try
                                        Else
                                            objFraccion.inserOrdenamientoFracion(Fraccion)
                                        End If
                                    End If
                                Next

                                ActualizarOrdenFracciones(0, FraccionSeleccionada.Cells("idEstilo").Value, idnave)

                            End If
                        Next


                        Button2_Click_1(Nothing, Nothing)

                        If ExisteFraccion > 0 Then
                            objExito.mensaje = "Ya existen " + ExisteFraccion.ToString + "  fracciones repetidas en o los artículos seleccionados."
                            objExito.StartPosition = FormStartPosition.CenterScreen
                            objExito.ShowDialog()
                        Else
                            objExito.mensaje = "Se agregaron las fracciones a los  artículos seleccionados"
                            objExito.StartPosition = FormStartPosition.CenterScreen
                            objExito.ShowDialog()
                            btnLimpiarFracciones.PerformClick()

                        End If

                        Me.Cursor = Cursors.Default

                    Else
                        adv.mensaje = "Debe seleccionar un artículo para agregar la Fracción"
                        adv.StartPosition = FormStartPosition.CenterScreen
                        adv.ShowDialog()
                    End If

                End If

            ElseIf rdoCambioPrecio.Checked = True Then

                If txtCosto.Text = "" Then
                    adv.mensaje = "El costo no puede estar vacío."
                    adv.StartPosition = FormStartPosition.CenterScreen
                    adv.ShowDialog()
                    Return
                End If

                If grdFracciones.Rows.Count = 0 Then
                    adv.mensaje = "Debe seleccionar un artículo para cambiar precio a la fracción."
                    adv.StartPosition = FormStartPosition.CenterScreen
                    adv.ShowDialog()

                Else
                    ContadorFraccionSeleccionada = 0
                    For Each FraccionSeleccionada As UltraGridRow In grdFracciones.Rows
                        If FraccionSeleccionada.Cells(" ").Value Then
                            ContadorFraccionSeleccionada = ContadorFraccionSeleccionada + 1
                        End If
                    Next

                    If ContadorFraccionSeleccionada > 0 Then
                        Me.Cursor = Cursors.WaitCursor

                        For Each FilaSeleccionada As UltraGridRow In grdFracciones.Rows
                            If FilaSeleccionada.Cells(" ").Value Then
                                ReemplazarPrecioFracciones(FilaSeleccionada.Cells("idEstilo").Value, FraccionIDSeleccionada, txtCosto.Text, idnave, ObservacionesFraccionSeleccionada)
                            End If
                        Next

                        'grdFracciones.DataSource = Nothing
                        'cmbColeccionFraccion.DataSource = Nothing

                        objExito.mensaje = "Se ha actualizado el costo de la fracción seleccionadas."
                        objExito.StartPosition = FormStartPosition.CenterScreen
                        objExito.ShowDialog()
                        btnLimpiarFracciones.PerformClick()

                    Else
                        adv.mensaje = "Debe seleccionar un artículo para cambiar precio a la fracción."
                        adv.StartPosition = FormStartPosition.CenterScreen
                        adv.ShowDialog()
                    End If

                End If

            Else
                EliminarFraccion()
            End If
        Else

            If rbCambioMaterial.Checked = True Then
                If lblUMNProveedorNuevoTexto.Text <> "-" Then

                    Dim lista As New List(Of Integer)
                    Dim idestilo As Integer = 0
                    Dim objm As New catalagosBU
                    Dim contador = 0
                    Try
                        For valor = 0 To grdConsumos.Rows.Count - 1
                            If grdConsumos.Rows(valor).Cells(" ").Text = 1 Then
                                selecciones = selecciones + 1
                            End If
                        Next
                        If selecciones > 0 Then

                            Dim ArticulosEnProduccion As Integer = 0
                            If lblEstatusMaterial.Text.Trim() <> "P" Then
                                For Each Fila2 As UltraGridRow In grdConsumos.Rows
                                    If Fila2.Cells(" ").Text = 1 Then
                                        If Fila2.Cells("Estatus").Text.Trim() = "AP" Then
                                            ArticulosEnProduccion = ArticulosEnProduccion + 1
                                        End If
                                    End If
                                Next
                            End If

                            If ArticulosEnProduccion > 0 Then
                                adv.mensaje = "El material a reemplzar esta en desarrollo, y algunos articulos seleccionados ya estan en producción. Es necesario primero autorizar el material."
                                adv.StartPosition = FormStartPosition.CenterScreen
                                adv.ShowDialog()

                            Else
                                'New XElement("Consumos")
                                vXmlConsumos = New XElement("Consumos")
                                pregunta.mensaje = "¿Desea reemplazar el material a los artículos seleccionados?"
                                If pregunta.ShowDialog = Windows.Forms.DialogResult.OK Then
                                    For value = 0 To grdConsumos.Rows.Count - 1
                                        If grdConsumos.Rows(value).Cells(" ").Text = 1 Then
                                            ReemplazarConsumosD(grdConsumos.Rows(value).Cells("idEstilo").Value, lblMaterialaveid.Text)
                                            listaEstilos.Add(grdConsumos.Rows(value).Cells("idEstilo").Value)
                                            contador = contador + 1
                                            'BuscarProveedoresMaterialesEnNave()
                                        End If
                                    Next
                                    If contador > 0 Then

                                        objm.ReemplazarMaterialConsumosXml(vXmlConsumos.ToString(), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, chSoloDesarrollo.Checked, idnave)

                                        objExito.mensaje = "Consumo reemplazado con éxito"
                                        objExito.StartPosition = FormStartPosition.CenterScreen
                                        objExito.ShowDialog()
                                        filtrar2()



                                    End If

                                End If
                            End If
                        Else
                            adv.mensaje = "Debe seleccionar el artículo al cual le reemplazara el material"
                            adv.StartPosition = FormStartPosition.CenterScreen
                            adv.ShowDialog()

                        End If

                    Catch ex As Exception
                    End Try

                    Dim listaNaves As New DataTable
                    For value = 0 To listaEstilos.Count - 1
                        listaNaves = obj.listaNavesAsignadasEstilo(listaEstilos.Item(value))
                        For value2 = 0 To listaNaves.Rows.Count - 1
                            listaEstilosNave.Add(listaNaves.Rows(value2).Item("pena_naveid").ToString)
                        Next
                    Next

                Else
                    adv.mensaje = "Debe seleccionar el material actual y el material por el cual va a remplazarlo"
                    adv.StartPosition = FormStartPosition.CenterScreen
                    adv.ShowDialog()
                End If

            ElseIf rbNuevoMaterial.Checked = True Then
                guardarMaterialNuevo()
            ElseIf rbEliminarMaterial.Checked = True Then

                Dim vXmlConsumoss = New XElement("Consumos")
                Dim contador As Integer = 0
                Dim ob As New catalagosBU
                pregunta.mensaje = "¿Desea eliminar el material a los artículos seleccionados?"
                If pregunta.ShowDialog = Windows.Forms.DialogResult.OK Then
                    For value = 0 To grdConsumos.Rows.Count - 1
                        If grdConsumos.Rows(value).Cells(" ").Text = 1 Then

                            Dim vNodo As XElement = New XElement("Consumo")
                            vNodo.Add(New XAttribute("MaterialIdNave", lblMaterialaveid.Text))
                            vNodo.Add(New XAttribute("MaterialId", idmaterial))
                            vNodo.Add(New XAttribute("ProductoEstiloId", grdConsumos.Rows(value).Cells("idEstilo").Value))
                            vXmlConsumoss.Add(vNodo)
                            contador = contador + 1
                        End If
                    Next
                    If contador > 0 Then

                        ob.EliminaMaterialConsumosXml(vXmlConsumoss.ToString(), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        objExito.mensaje = "El material se elimino con exito"
                        objExito.StartPosition = FormStartPosition.CenterScreen
                        objExito.ShowDialog()
                        filtrar2()
                    Else
                        adv.mensaje = "Debe seleccionar el artículo donde se eliminará el material"
                        adv.StartPosition = FormStartPosition.CenterScreen
                        adv.ShowDialog()
                    End If

                End If
            End If



        End If



        '==================================

        'If tabCambiosGlobales.SelectedIndex = 0 Then
        '    If lblUMNProveedorNuevoTexto.Text <> "-" Then
        '        If Me.tabCambiosGlobales.SelectedTab Is Fracciones Then
        '            If rdoNuevoFraccion.Checked = True Then
        '                pregunta.mensaje = "Desea agregar la(s) fracción(es) a los artículos seleccionados?"
        '                If pregunta.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                    'BuscarProveedoresMaterialesEnNave()
        '                    For value = 0 To grdFracciones.Rows.Count - 1
        '                        If grdFracciones.Rows(value).Cells(" ").Value = 1 Then
        '                            Try
        '                                guardarFraccionesDesarrollo(grdFracciones.Rows(value).Cells("idEstilo").Value)
        '                            Catch ex As Exception
        '                            End Try
        '                        End If
        '                    Next
        '                    filtrarProductosParaFracciones(0)
        '                End If
        '            Else
        '                For value = 0 To grdFracciones.Rows.Count - 1
        '                    If grdFracciones.Rows(value).Cells(" ").Value = 1 Then
        '                        Try
        '                            ' ReemplazarPrecioFracciones(grdFracciones.Rows(value).Cells("idEstilo").Value, lblIdFraccion.Text, txtCosto.Text)
        '                            contadores = contadores + 1
        '                            'BuscarProveedoresMaterialesEnNave()
        '                        Catch ex As Exception
        '                        End Try
        '                    End If
        '                Next
        '                If contadores > 0 Then
        '                    objExito.mensaje = "Se reemplazo el costo de la fracción a " & contadores.ToString & " de " & contadores.ToString & " artículos "
        '                    objExito.StartPosition = FormStartPosition.CenterScreen
        '                    objExito.ShowDialog()
        '                    filtrarProductosParaFracciones(0)

        '                    'cmbMarca.SelectedValue = 0
        '                    'cmbColeccion.SelectedValue = 0
        '                    'grdConsumos.DataSource = Nothing
        '                    'lblClasificacionTexto.Text = "-"
        '                    'lblIdclass.Text = "-"
        '                    'lblMaterialTextoTitulo.Text = "-"
        '                    'lblMaterialTexto.Text = "-"
        '                    'lblSKUTextoTitulo.Text = "-"
        '                    'lblProveedorNuevoTexto.Text = "-"
        '                    'lblPrecioNuevotexto.Text = "-"
        '                    'lblUMPNuevoTexto.Text = "-"
        '                    'lblFactorNuevoTexto.Text = "-"
        '                    'lblIdproveedorTexto.Text = "-"
        '                    'lblUMNProveedorNuevoTexto.Text = "-"
        '                    'lblIdmaterialremplazarTexto.Text = "-"
        '                    'lblmaterialremplazartexto.Text = "-"
        '                    'lblskureemplazartexto.Text = "-"
        '                    'btnBuscar2.Visible = False
        '                    'lblClassTexto.Text = "-"
        '                    'lblProveedorReemplazarTexto.Text = "-"
        '                    'lblPrecioReemplazarTexto.Text = "-"
        '                    'lblUMPReemplazarTexto.Text = "-"
        '                    'lblFactorReemplazarTexto.Text = "-"
        '                    'lblClasificacionReemplazarTexto.Text = "-"
        '                    'lblMaterialaveid.Text = "-"
        '                End If
        '            End If

        '        Else
        '            ''Nuevo
        '            'If rdoNuevo.Checked = True Then
        '            '    Dim idestilo As Integer = 0
        '            '    Dim lista As New List(Of Integer)
        '            '    Try
        '            '        pregunta.mensaje = "Desea agregar los consumos a los productos seleccionados?"
        '            '        If pregunta.ShowDialog = Windows.Forms.DialogResult.OK Then
        '            '            For value = 0 To grdConsumos.Rows.Count - 1
        '            '                If grdConsumos.ActiveRow.Cells(" ").Text = 1 Then
        '            '                    guardarConsumosDesarrollo(grdConsumos.Rows(value).Cells("idEstilo").Value, 1, 0)
        '            '                End If 
        '            '            Next
        '            '            objExito.mensaje = "Consumos registrados."
        '            '            objExito.ShowDialog()
        '            '        End If
        '            '    Catch ex As Exception
        '            '    End Try
        '            'End If
        '            ''Reemplazo Material


        '        End If
        '    Else
        '        adv.mensaje = "Debe seleccionar el material actual y el material por el cual va a remplazarlo"
        '        adv.StartPosition = FormStartPosition.CenterScreen
        '        adv.ShowDialog()
        '    End If
        'ElseIf tabCambiosGlobales.SelectedIndex = 1 Then

        'End If

        Me.Cursor = Cursors.Default
    End Sub




    Public Sub ActualizarOrdenFracciones(ByVal PosicionOrden As Integer, ByVal ProductoEstiloId As Integer, ByVal NaveId As Integer)

        Dim obj As New catalagosBU
        Dim DTFraccionOrden As DataTable
        'Dim DTFraccionOrden2 As DataTable
        Dim objFraccion As New ConsumosBU
        Dim Fraccion As New Fracciones
        Dim Fraccionid As Integer = 0
        Dim Orden As Integer = 0
        Dim ContadorOrden As Integer = 0

        Dim DTFraccionesNuevas As New DataTable
        Dim DTFraccionesNuevas2 As New DataTable

        Dim fraccionid2 As Integer = 0
        Dim orden2 As Integer = 0
        Dim incrementoORden As Integer = 0

        DTFraccionOrden = obj.ObtenerFraccionesProductoEstiloNavePorOrden(ProductoEstiloId, NaveId)

        DTFraccionesNuevas.Columns.Add("idFraccion")
        DTFraccionesNuevas.Columns.Add("Orden")
        DTFraccionesNuevas.Columns.Add("Observaciones")

        For Each FilaSeleccionada As UltraGridRow In grdNuevaFraccion.Rows
            DTFraccionesNuevas.Rows.Add(FilaSeleccionada.Cells("idFraccion").Value, FilaSeleccionada.Cells("Orden").Value, FilaSeleccionada.Cells("Observaciones").Value)
        Next



        Dim EsOrdenRepetido As Boolean = False
        ContadorOrden = 0

        For Each Fila As DataRow In DTFraccionOrden.Rows
            fraccionid2 = 0
            orden2 = -1
            ContadorOrden = ContadorOrden + 1

            For Each FilaSeleccionada As DataRow In DTFraccionesNuevas.Rows
                If Fila("FraccionID").ToString = FilaSeleccionada("idFraccion").ToString And Fila("Observaciones").ToString = FilaSeleccionada("Observaciones").ToString Then
                    If IsDBNull(FilaSeleccionada("Orden")) = False Then
                        orden2 = FilaSeleccionada("Orden")
                    End If
                    fraccionid2 = Fila("FraccionID").ToString

                End If
            Next

            If EsOrdenRepetido = True Then



                EsOrdenRepetido = False
            Else

                EsOrdenRepetido = EsRepetido(ContadorOrden, ProductoEstiloId, NaveId)

                If EsOrdenRepetido = True Then

                    If fraccionid2 <> 0 And orden2 <> -1 Then

                        If Fila("FraccionID").ToString <> Fraccionid Then
                            Fraccion = New Fracciones
                            Fraccion.fraccionidProd = Fila("FraccionDesarrolloID").ToString
                            Fraccion.noOrden = ContadorOrden + 1
                            objFraccion.inserOrdenamientoFracion(Fraccion)

                        Else
                            EsOrdenRepetido = False

                        End If



                    Else
                        If ContadorOrden > (Fila("Orden").ToString + incrementoORden) Then
                            Fraccion = New Fracciones
                            Fraccion.fraccionidProd = Fila("FraccionDesarrolloID").ToString
                            Fraccion.noOrden = ContadorOrden
                            objFraccion.inserOrdenamientoFracion(Fraccion)

                        Else
                            ActualizarOrdenCompleto(DTFraccionOrden, ContadorOrden + 1)

                            Fraccion = New Fracciones
                            Fraccion.fraccionidProd = Fila("FraccionDesarrolloID").ToString
                            Fraccion.noOrden = ContadorOrden + 1
                            objFraccion.inserOrdenamientoFracion(Fraccion)
                            incrementoORden = incrementoORden + 1

                        End If


                    End If

                Else
                    Fraccion = New Fracciones
                    Fraccion.fraccionidProd = Fila("FraccionDesarrolloID").ToString
                    Fraccion.noOrden = ContadorOrden
                    objFraccion.inserOrdenamientoFracion(Fraccion)
                End If


            End If



        Next
        '    If fraccionid2 <> 0 And orden2 <> -1 Then

        '        If ContadorOrden = Orden Then

        '            EsOrdenRepetido = EsRepetido(DTFraccionOrden, ContadorOrden)

        '            If Fila("FraccionID").ToString <> Fraccionid Then
        '                Fraccion = New Fracciones
        '                Fraccion.fraccionidProd = Fila("FraccionDesarrolloID").ToString
        '                Fraccion.noOrden = ContadorOrden + 1
        '                objFraccion.inserOrdenamientoFracion(Fraccion)
        '            Else
        '                EsOrdenRepetido = False
        '            End If


        '        Else
        '            If EsOrdenRepetido = False Then
        '                Fraccion = New Fracciones
        '                Fraccion.fraccionidProd = Fila("FraccionDesarrolloID").ToString
        '                Fraccion.noOrden = ContadorOrden
        '                objFraccion.inserOrdenamientoFracion(Fraccion)
        '            Else
        '                EsOrdenRepetido = False
        '            End If



        '        End If

        '    Else

        '        Fraccion = New Fracciones
        '        Fraccion.fraccionidProd = Fila("FraccionDesarrolloID").ToString
        '        Fraccion.noOrden = ContadorOrden
        '        objFraccion.inserOrdenamientoFracion(Fraccion)

        '        EsOrdenRepetido = False
        '    End If







        '    If ContadorOrden = Orden Then
        '        EsOrdenRepetido = EsRepetido(DTFraccionOrden, ContadorOrden)

        '        If Fila("FraccionID").ToString <> Fraccionid Then
        '            Fraccion = New Fracciones
        '            Fraccion.fraccionidProd = Fila("FraccionDesarrolloID").ToString
        '            Fraccion.noOrden = ContadorOrden + 1
        '            objFraccion.inserOrdenamientoFracion(Fraccion)
        '        End If


        '    Else
        '        If EsOrdenRepetido = False Then
        '            Fraccion = New Fracciones
        '            Fraccion.fraccionidProd = Fila("FraccionDesarrolloID").ToString
        '            Fraccion.noOrden = ContadorOrden
        '            objFraccion.inserOrdenamientoFracion(Fraccion)
        '        Else
        '            EsOrdenRepetido = False
        '        End If



        '    End If




        'Next



        'DTFraccionesNuevas2.Columns.Add("idFraccion")
        'DTFraccionesNuevas2.Columns.Add("Orden")

        'For Each FilaSeleccionada As UltraGridRow In grdNuevaFraccion.Rows
        '    DTFraccionesNuevas2.Rows.Add(FilaSeleccionada.Cells("idFraccion").Value, FilaSeleccionada.Cells("Orden").Value)
        'Next


        'Dim dataView As New DataView(DTFraccionesNuevas2)
        'dataView.Sort = "Orden ASC"
        'DTFraccionesNuevas = dataView.ToTable()



        'For Each FilaSeleccionada As DataRow In DTFraccionesNuevas.Rows
        '    Fraccionid = 0
        '    Orden = -1
        '    Fraccionid = FilaSeleccionada("idFraccion")
        '    If IsDBNull(FilaSeleccionada("Orden")) = False Then
        '        Orden = FilaSeleccionada("Orden")
        '    End If
        '    DTFraccionOrden = obj.ObtenerFraccionesProductoEstiloNavePorOrden(ProductoEstiloId, NaveId)
        '    If DTFraccionOrden.Rows.Count > 0 Then

        '        If Orden = -1 Then 'Si no lleva orden insertar al final de la lista de fracciones
        '            'For Each Fila As DataRow In DTFraccionOrden.Rows
        '            '    If Fila("FraccionID").ToString = Fraccionid Then
        '            '        Fraccion = New Fracciones
        '            '        Fraccion.fraccionidProd = Fila("FraccionDesarrolloID").ToString
        '            '        Fraccion.noOrden = DTFraccionOrden.Rows.Count
        '            '        objFraccion.inserOrdenamientoFracion(Fraccion)
        '            '    End If
        '            'Next
        '        Else
        '            Dim EsOrdenRepetido As Boolean = False
        '            ContadorOrden = 0
        '            For Each Fila As DataRow In DTFraccionOrden.Rows
        '                ContadorOrden = ContadorOrden + 1

        '                If ContadorOrden = Orden Then
        '                    EsOrdenRepetido = EsRepetido(DTFraccionOrden, ContadorOrden)

        '                    If Fila("FraccionID").ToString <> Fraccionid Then
        '                        Fraccion = New Fracciones
        '                        Fraccion.fraccionidProd = Fila("FraccionDesarrolloID").ToString
        '                        Fraccion.noOrden = ContadorOrden + 1
        '                        objFraccion.inserOrdenamientoFracion(Fraccion)
        '                    End If


        '                Else
        '                    If EsOrdenRepetido = False Then
        '                        Fraccion = New Fracciones
        '                        Fraccion.fraccionidProd = Fila("FraccionDesarrolloID").ToString
        '                        Fraccion.noOrden = ContadorOrden
        '                        objFraccion.inserOrdenamientoFracion(Fraccion)
        '                    Else
        '                        EsOrdenRepetido = False
        '                    End If



        '                End If




        '                'If Orden > DTFraccionOrden.Rows.Count Then ' si el orden es mas grande que los elementos insertados  asignarle el orden del ultimo elemento mas 1
        '                '    If Fila("FraccionID").ToString = Fraccionid Then
        '                '        Fraccion = New Fracciones
        '                '        Fraccion.fraccionidProd = Fila("FraccionDesarrolloID").ToString
        '                '        Fraccion.noOrden = ContadorOrden
        '                '        objFraccion.inserOrdenamientoFracion(Fraccion)
        '                '    End If
        '                'Else
        '                '    If Fila("Orden").ToString >= Orden Then
        '                '        Fraccion = New Fracciones
        '                '        Fraccion.fraccionidProd = Fila("FraccionDesarrolloID").ToString
        '                '        Fraccion.noOrden = CInt(Fila("Orden").ToString) + 1
        '                '        objFraccion.inserOrdenamientoFracion(Fraccion)
        '                '    End If

        '                'End If

        '            Next

        '        End If

        '    Else

        '        'For Each Fila As DataRow In DTFraccionOrden.Rows

        '        '    If Fila("FraccionID").ToString = Fraccionid Then
        '        '        Fraccion = New Fracciones
        '        '        Fraccion.fraccionidProd = Fila("FraccionDesarrolloID").ToString

        '        '        Fraccion.noOrden = DTFraccionOrden.Rows.Count + 1
        '        '        objFraccion.inserOrdenamientoFracion(Fraccion)
        '        '    End If


        '        'Next

        '        'For Each Fila As DataRow In DTFraccionOrden.Rows
        '        '    If Orden > DTFraccionOrden.Rows.Count Then ' si el orden es mas grande que los elementos insertados  asignarle el orden del ultimo elemento mas 1
        '        '        If Fila("FraccionID").ToString = Fraccionid Then
        '        '            Fraccion = New Fracciones
        '        '            Fraccion.fraccionidProd = Fila("FraccionDesarrolloID").ToString
        '        '            If DTFraccionOrden.Rows.Count = Orden Then
        '        '                Fraccion.noOrden = DTFraccionOrden.Rows.Count
        '        '            Else
        '        '                Fraccion.noOrden = DTFraccionOrden.Rows.Count + 1
        '        '            End If

        '        '            objFraccion.inserOrdenamientoFracion(Fraccion)
        '        '        End If
        '        '    Else
        '        '        If Fila("Orden").ToString >= Orden Then
        '        '            Fraccion = New Fracciones
        '        '            Fraccion.fraccionidProd = Fila("FraccionDesarrolloID").ToString
        '        '            Fraccion.noOrden = CInt(Fila("Orden").ToString) + 1
        '        '            objFraccion.inserOrdenamientoFracion(Fraccion)
        '        '        End If

        '        '    End If

        '        'Next

        '    End If
        'Next



        ''If DTFraccionOrden.Rows.Count > 0 Then
        ''    For Each Fila As DataRow In DTFraccionOrden.Rows
        ''        If Fila("Orden").ToString >= PosicionOrden Then
        ''            Fraccion = New Fracciones
        ''            Fraccion.fraccionidProd = Fila("FraccionDesarrolloID").ToString
        ''            Fraccion.noOrden = CInt(Fila("Orden").ToString) + 1
        ''            objFraccion.inserOrdenamientoFracion(Fraccion)
        ''        End If                
        ''    Next

        ''    'Dim parametro As New SqlParameter
        ''    'parametro.ParameterName = "@fraccionid"
        ''    'parametro.Value = c.fraccionidProd
        ''    'listaparametros.Add(parametro)
        ''    'parametro = New SqlParameter
        ''    'parametro.ParameterName = "@numeroOrden"
        ''    'parametro.Value = c.noOrden
        ''    'listaparametros.Add(parametro)

        ''End If


    End Sub

    Public Sub ActualizarOrdenCompleto(ByVal DtFraccionesORden As DataTable, ByVal Orden As Integer)

        Dim Fraccion As New Fracciones
        Dim objFraccion As New ConsumosBU
        Dim contador As Integer = 0

        For Each Fila As DataRow In DtFraccionesORden.Rows
            If Fila("Orden") >= Orden Then
                Fraccion = New Fracciones
                Fraccion.fraccionidProd = Fila("FraccionDesarrolloID").ToString
                Fraccion.noOrden = CInt(Fila("Orden")) + 1
                objFraccion.inserOrdenamientoFracion(Fraccion)
            End If


        Next



    End Sub

    Public Function EsRepetido(ByVal ORden As Integer, ByVal ProductoEstilo As Integer, ByVal NaveID As Integer) As Boolean
        Dim bandera As Boolean = False
        Dim DTFraccionOrden As DataTable
        Dim obj As New catalagosBU

        DTFraccionOrden = obj.ObtenerFraccionesProductoEstiloNavePorOrden(ProductoEstilo, NaveID)

        Dim contador As Integer = 0
        For Each Fila As DataRow In DTFraccionOrden.Rows
            If Fila("Orden").ToString = ORden Then
                contador = contador + 1
            End If
        Next

        If contador > 1 Then
            bandera = True
        Else
            bandera = False
        End If
        Return bandera
    End Function

    Public Sub ValidarExistenciaProveedorEnNave()
        Dim obj As New catalagosBU
        listaProveedores = obj.listaProveedoresNave(2, 3)

    End Sub

    Public Sub ValidarExistenciaMaterialEnNave()
        Dim obj As New catalagosBU
        listaMateriales = obj.listaMaterialesNave(2, 3)
    End Sub


    Private Sub guardarFraccionesDesarrollo(ByVal productoEstiloId As Integer)
        Dim fraccion As New Fracciones
        Dim obj As New ConsumosBU
        Dim datos As New DataTable
        Dim contador = 0
        Try
            datos = grdNuevaFraccion.DataSource
            Me.Cursor = Cursors.WaitCursor
            For Each row As DataRow In datos.Rows
                Try
                    fraccion = New Fracciones
                    'consumo.bloqueado = CBool(row("Bloqueado"))
                    fraccion.productoEstiloId = productoEstiloId
                    fraccion.frap_fraccionid = row("idFraccion")
                    fraccion.fraccionidProd = row("idFraccDes")
                    If CBool(row("Activo")) Then
                        fraccion.frap_activo = 1
                    Else
                        fraccion.frap_activo = 0
                    End If
                    If row("idFraccDes") = 0 Then
                        fraccion.accion = 1
                    Else
                        fraccion.accion = 2
                    End If
                    Dim x = row("Activo")
                    If row("Activo") = True Then
                        fraccion.frap_activo = 1
                    Else
                        fraccion.frap_activo = 0
                    End If
                    fraccion.frap_precio = row("Costo").ToString
                    obj.insertFraccionDes(fraccion)
                    contador = contador + 1
                Catch ex As Exception
                End Try
            Next
            'If contador > 0 Then
            '    objExito.mensaje = "Se agregaron las Fracciones a" + datos.Rows.Count + "de los " + contador + " artículos seleccionados"
            '    objExito.StartPosition = FormStartPosition.CenterScreen
            '    objExito.ShowDialog()
            'End If
            'getDatosFracciones()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            adv.mensaje = "Surgió algo inesperado: " & ex.Message
            adv.StartPosition = FormStartPosition.CenterScreen
            adv.ShowDialog()
        End Try

    End Sub

    Public Sub actualizarProductos(ByVal ProductoEstilo As Integer)
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        Dim idproveedor, umpid, materialid, productoestiloid As Integer
        Dim factor, preciop As Double
        idproveedor = lblIdProveedor.Text
        materialid = lblIdMaterialNave.Text
        productoestiloid = ProductoEstilo
        umpid = lblIDUMP.Text
        factor = lblFactortexto.Text
        preciop = lblPreciotexto.Text
        lista = obj.actualizarProductos(idproveedor, preciop, umpid, factor, materialid, productoestiloid)

    End Sub

    Private Function nuevoconsumo() As Boolean
        Dim d As New DataTable
        d = grdConsumos.DataSource
        For Each row As DataRow In d.Rows
            Try
                If row("idComponente") = 0 Then
                    Return False
                End If
                If row("idclasificacion") = 0 Then
                    Return False
                End If
                If row("IdMaterial") = 0 Then
                    Return False
                End If
                If row("idUMConsumo") = 0 Then
                    Return False
                End If
                If row("idProveedor") = 0 Then
                    Return False
                End If
                If row("Consumo") <= 0 Then
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        Next

        Return True
    End Function

    Private Sub guardarConsumosDesarrollo(ByVal estilo As Integer, ByVal accion As Integer, ByVal idconsumo As Integer)
        Dim consumo As New Consumo
        Dim obj As New ConsumosBU
        Dim datos As New DataTable
        Try
            datos = grdNuevoConsumo.DataSource
            Me.Cursor = Cursors.WaitCursor
            For Each row As DataRow In datos.Rows
                consumo = New Consumo
                consumo.bloqueado = CBool(row("Bloq"))
                consumo.explosionar = CBool(row("Explosionar"))
                consumo.lotear = CBool(row("Lotear"))
                consumo.componenteid = row("id componente")
                consumo.clasificacionid = row("id clasificación")
                consumo.materialId = row("id material")
                consumo.idconsumo = idconsumo
                consumo.umproduccionid = row("idUMConsumo")
                consumo.proveedorId = row("id proveedor")
                consumo.costopar = row("Costo Par")
                consumo.productoEstiloId = estilo
                consumo.consumo = row("Consumo")
                consumo.umProveedorId = row("idUMProv")
                consumo.precioumproduccion = row("Precio UM")
                consumo.factorconversion = row("Factor Conversión")
                consumo.preciocompra = row("Precio Compra")
                consumo.activo = 1

                consumo.accion = accion

                obj.insertConsumo(consumo)
            Next

            'objExito.mensaje = "Consumos registrados."
            'objExito.ShowDialog()
            Me.Cursor = Cursors.Default
            'grdNuevoConsumo.DataSource = Nothing
            'crearTablaComponentes()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            adv.mensaje = "Surgió algo inesperado: " & ex.Message
            adv.StartPosition = FormStartPosition.CenterScreen
            adv.ShowDialog()
        End Try

    End Sub

    Private Sub ReemplazarConsumoD(ByVal estilo As Integer, ByVal accion As Integer, ByVal idconsumo As Integer)
        Dim consumo As New Consumo
        Dim obj As New ConsumosBU
        Dim datos As New DataTable
        Try
            datos = grdNuevoConsumo.DataSource
            Me.Cursor = Cursors.WaitCursor
            For Each row As DataRow In datos.Rows
                consumo = New Consumo
                consumo.bloqueado = CBool(row("Bloq"))
                consumo.explosionar = CBool(row("Explosionar"))
                consumo.lotear = CBool(row("Lotear"))
                consumo.componenteid = row("id componente")
                consumo.clasificacionid = row("id clasificación")
                consumo.materialId = row("id material")
                consumo.idconsumo = idconsumo
                consumo.umproduccionid = row("idUMConsumo")
                consumo.proveedorId = row("id proveedor")
                consumo.costopar = row("Costo Par")
                consumo.productoEstiloId = estilo
                consumo.consumo = row("Consumo")
                consumo.umProveedorId = row("idUMProv")
                consumo.precioumproduccion = row("Precio UM")
                consumo.factorconversion = row("Factor Conversión")
                consumo.preciocompra = row("Precio Compra")
                consumo.activo = 1
                consumo.accion = accion

                obj.reemplazarConsumo(consumo)
            Next

            'objExito.mensaje = "Consumos registrados."
            'objExito.ShowDialog()
            Me.Cursor = Cursors.Default
            'grdNuevoConsumo.DataSource = Nothing
            'crearTablaComponentes()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            adv.mensaje = "Surgió algo inesperado: " & ex.Message
            adv.StartPosition = FormStartPosition.CenterScreen
            adv.ShowDialog()
        End Try

    End Sub

    Private Sub ReemplazarConsumosD(ByVal estilo As Integer, ByVal material As Integer)
        Dim consumo As New Consumo
        Dim obj As New catalagosBU
        Dim datos As New DataTable
        Try
            datos = grdNuevoConsumo.DataSource
            Me.Cursor = Cursors.WaitCursor

            'consumo = New Consumo

            'consumo.clasificacionid = lblIdclass.Text
            'consumo.materialId = lblIdNaveMaterialNuevo.Text
            'consumo.proveedorId = lblIdproveedorTexto.Text
            'consumo.umProveedorId = lblUMNProveedorNuevoTexto.Text
            'consumo.factorconversion = lblFactorNuevoTexto.Text
            'consumo.preciocompra = lblPrecioNuevotexto.Text
            'consumo.precioumproduccion = lblPrecioNuevotexto.Text / lblFactorNuevoTexto.Text
            'consumo.usuariomodifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            'consumo.fechamodificacion = DateTime.Now
            'consumo.umproduccionid = lblIDUMPNuevo2.Text.Trim()
            'consumo.fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")

            'consumo.productoEstiloId = estilo


            ''==================ANTERIOR========================================
            ''obj.reemplazarMaterialConsumos(consumo, material)

            ''===================MODIFICACION==============================

            'obj.ReemplazarMaterialConsumos2(consumo, material, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)


            Dim vNodo As XElement = New XElement("Consumo")
            vNodo.Add(New XAttribute("ClasificacionId", lblIdclass.Text))
            vNodo.Add(New XAttribute("MaterialIdNuevo", lblIdNaveMaterialNuevo.Text))
            vNodo.Add(New XAttribute("MaterialIdAnterior", material))
            vNodo.Add(New XAttribute("ProveedorID", lblIdproveedorTexto.Text))
            vNodo.Add(New XAttribute("UmProveedorId", lblUMNProveedorNuevoTexto.Text))
            vNodo.Add(New XAttribute("FactorConversor", lblFactorNuevoTexto.Text))
            vNodo.Add(New XAttribute("PrecioCompra", lblPrecioNuevotexto.Text))
            vNodo.Add(New XAttribute("PrecioUmProduccion", lblPrecioNuevotexto.Text / lblFactorNuevoTexto.Text))
            vNodo.Add(New XAttribute("UmProduccionId", lblIDUMPNuevo2.Text))
            vNodo.Add(New XAttribute("ProductoEstiloId", estilo))
            vXmlConsumos.Add(vNodo)


            'objExito.mensaje = "Cambio de material realizado con éxito."
            'objExito.ShowDialog()
            Me.Cursor = Cursors.Default
            'grdNuevoConsumo.DataSource = Nothing
            'crearTablaComponentes()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            adv.mensaje = "Surgió algo inesperado: " & ex.Message
            adv.StartPosition = FormStartPosition.CenterScreen
            adv.ShowDialog()
        End Try

    End Sub

    Private Sub grdNuevoConsumo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdNuevoConsumo.KeyPress
        Try
            If grdNuevoConsumo.ActiveRow.Cells("Consumo").Value <> 0 Then
                grdNuevoConsumo.ActiveRow.Cells("Costo Par").Value = grdNuevoConsumo.ActiveRow.Cells("Consumo").Value * grdNuevoConsumo.ActiveRow.Cells("Precio UM").Value
            End If
        Catch ex As Exception

        End Try
        Try
            If grdNuevoConsumo.ActiveRow.Cells("Consumo").Value <> 0 Then
                grdNuevoConsumo.ActiveRow.Cells("Costo Par").Value = grdNuevoConsumo.ActiveRow.Cells("Consumo").Value * grdNuevoConsumo.ActiveRow.Cells("Precio UM").Value
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
    '    grdNuevaFraccion.DataSource = Nothing
    '    grdConsumos.DataSource = Nothing
    '    crearTablaComponentes()
    'End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub btnClasificacion_Click(sender As Object, e As EventArgs) Handles btnClasificacion.Click
        Dim form As New ListaClasificacionesForm
        form.ShowDialog()
        lblclasificacionbuscar.Text = form.Clasificacion
        lblIdClasificacion.Text = form.idClasificacion
        If lblIdClasificacion.Text <> "-" And lblIdClasificacion.Text <> "" And lblIdClasificacion.Text <> "0" Then
            btnMaterial.Visible = True
        End If
        If form.idClasificacion = 0 Then
            btnProveedor.Visible = False
            btnMaterial.Visible = False
            lblIdProveedor.Text = ""
            lblIdMaterialNave.Text = ""
            lblMaterialSeleccionado.Text = ""
            lblProveedorSeleccionado.Text = ""
            lblIdProveedor.Text = ""
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnBuscar2.Click
        If lblIdmaterialremplazarTexto.Text <> "" Then
            Dim form As New listaMaterialesForm
            form.x = 1
            form.nave = idnave
            form.cambiosglobalesmaterial = 0
            form.MaterialIDReemplazar = lblIdmaterialremplazarTexto.Text
            'form.cambiosglobalesmaterial = lblIdmaterialremplazarTexto.Text
            form.cambiosglobalesProveedor = lblidProveedorOriginal.Text
            form.componente = lblClassTexto.Text
            form.ShowDialog()

            If form.idMaterial = CInt(lblIdmaterialremplazarTexto.Text) And form.idProveedor = CInt(lblidProveedorOriginal.Text) Then
                objadvertencia.mensaje = "El material y proveedor seleccionado es el mismo a remplazar."
                objadvertencia.StartPosition = FormStartPosition.CenterScreen
                objadvertencia.ShowDialog()
            Else
                lblClasificacionTexto.Text = form.Clasificacionx
                lblIdclass.Text = form.idClasificacion
                lblMaterialTextoTitulo.Text = form.Material
                lblMaterialTexto.Text = form.idMaterial
                lblSKUTextoTitulo.Text = form.SKU

                lblProveedorNuevoTexto.Text = form.Provedor
                lblPrecioNuevotexto.Text = form.precio
                lblUMPNuevoTexto.Text = form.UMC
                lblFactorNuevoTexto.Text = form.equivalencia
                lblIdproveedorTexto.Text = form.idProveedor
                lblUMNProveedorNuevoTexto.Text = form.idUMC
                lblIdNaveMaterialNuevo.Text = form.materialNaveid
                lblIDUMPNuevo2.Text = form.idUMP
                lblEstatusMaterial.Text = form.EstatusMAterial
                btnBuscar.Visible = True
                lblBuscar.Visible = True
                btnLimpiar.Visible = True
                lblLimpiar.Visible = True

            End If

            'If form.idMaterial <> CInt(lblIdmaterialremplazarTexto.Text) And form.idProveedor <> CInt(lblidProveedorOriginal.Text) Then
            '    lblClasificacionTexto.Text = form.Clasificacionx
            '    lblIdclass.Text = form.idClasificacion
            '    lblMaterialTextoTitulo.Text = form.Material
            '    lblMaterialTexto.Text = form.idMaterial
            '    lblSKUTextoTitulo.Text = form.SKU

            '    lblProveedorNuevoTexto.Text = form.Provedor
            '    lblPrecioNuevotexto.Text = form.precio
            '    lblUMPNuevoTexto.Text = form.UMC
            '    lblFactorNuevoTexto.Text = form.equivalencia
            '    lblIdproveedorTexto.Text = form.idProveedor
            '    lblUMNProveedorNuevoTexto.Text = form.idUMC
            '    lblIdNaveMaterialNuevo.Text = form.materialNaveid

            '    btnBuscar.Visible = True
            '    lblBuscar.Visible = True
            '    btnLimpiar.Visible = True
            '    lblLimpiar.Visible = True
            'Else
            '    objadvertencia.mensaje = "El material y proveedor seleccionado es el mismo a remplazar."
            '    objadvertencia.StartPosition = FormStartPosition.CenterScreen
            '    objadvertencia.ShowDialog()
            'End If


        Else
            objadvertencia.mensaje = "Seleccione un material a reemplazar"
            objadvertencia.StartPosition = FormStartPosition.CenterScreen
            objadvertencia.ShowDialog()
        End If

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles btnBuscar1.Click
        Dim form As New listaMaterialesForm
        form.x = 2
        form.cambiosglobalesmaterial = 0
        form.nave = idnave
        form.ShowDialog()
        lblidProveedorOriginal.Text = form.idProveedor
        lblIdmaterialremplazarTexto.Text = form.idMaterial
        lblmaterialremplazartexto.Text = form.Material
        lblskureemplazartexto.Text = form.SKU
        btnBuscar2.Visible = True
        lblClassTexto.Text = form.idClasificacion
        lblProveedorReemplazarTexto.Text = form.Provedor
        lblPrecioReemplazarTexto.Text = form.precio
        lblUMPReemplazarTexto.Text = form.UMC

        lblFactorReemplazarTexto.Text = form.equivalencia
        lblClasificacionReemplazarTexto.Text = form.Clasificacionx
        lblMaterialaveid.Text = form.materialNaveid
        'limpiar Material nuevo
        lblClasificacionTexto.Text = "-"
        lblIdclass.Text = "-"
        lblMaterialTextoTitulo.Text = "-"
        lblMaterialTexto.Text = "-"
        lblSKUTextoTitulo.Text = "-"
        lblProveedorNuevoTexto.Text = "-"
        lblPrecioNuevotexto.Text = "-"
        lblUMPNuevoTexto.Text = "-"
        lblFactorNuevoTexto.Text = "-"
        lblIdproveedorTexto.Text = "-"
        lblUMNProveedorNuevoTexto.Text = "-"
        cmbMarca.SelectedValue = 0
        cmbColeccion.SelectedValue = 0
        grdConsumos.DataSource = Nothing
        'lblBuscar2.Visible = True
        'filtrar2()
        Try
            llenarcomboMarcaMaterialSeleccionado(cmbMarca)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cmbMarca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarca.SelectedIndexChanged
        Try
            llenarcomboColeccionMaterialSeleccionado(cmbColeccion)
        Catch ex As Exception
        End Try
        grdConsumos.DataSource = Nothing
        If cmbMarca.Text <> "" Then
            lblMarcaConsumos.ForeColor = Drawing.Color.Black
        Else
            cmbColeccion.DataSource = Nothing
        End If
    End Sub

    Function validarFraccion(idFraccion As Integer) As Boolean
        Dim d As New DataTable
        d = grdNuevaFraccion.DataSource
        For Each row As DataRow In d.Rows
            Try
                If row("idFraccion") <> 0 Then
                    If row("idFraccion") = idFraccion Then
                        Return False
                    End If
                End If
            Catch ex As Exception
            End Try
        Next
        Return True
    End Function

    Private Sub grdNuevaFraccion_KeyUp_1(sender As Object, e As KeyEventArgs) Handles grdNuevaFraccion.KeyUp
        Dim FraccionesCargadasId As String = String.Empty
        If e.KeyCode = Keys.F1 Then
            Dim a As String = ""
            If Not grdNuevaFraccion.ActiveRow.IsFilterRow Then
                Try
                    If grdNuevaFraccion.ActiveCell.Column.ToString = "Fracción" Then
                        'Mostrar ventana de componente
                        Dim obj As New ConsumosBU
                        Dim f As New DataTable
                        Dim form As New listaFraccionesForm

                        For Each fila As UltraGridRow In grdNuevaFraccion.Rows
                            If FraccionesCargadasId = String.Empty Then
                                If IsDBNull(fila.Cells("idFraccion").Value) = False Then
                                    FraccionesCargadasId = fila.Cells("idFraccion").Value
                                End If

                            Else
                                If IsDBNull(fila.Cells("idFraccion").Value) = False Then
                                    FraccionesCargadasId += "," + fila.Cells("idFraccion").Value
                                End If

                            End If


                        Next

                        form.FraccionRepetida = FraccionesCargadasId
                        form.ShowDialog()
                        Dim idFraccion As Integer = 0
                        idFraccion = form.id
                        If form.cerrado = False Then
                            If True Then 'validarFraccion(idFraccion) Then
                                f = obj.getFraccion(idFraccion)
                                For Each row As DataRow In f.Rows
                                    grdNuevaFraccion.ActiveRow.Cells("idFraccion").Value = row("frap_fraccionid")
                                    grdNuevaFraccion.ActiveRow.Cells("idFraccDes").Value = 0
                                    grdNuevaFraccion.ActiveRow.Cells("Fracción").Value = row("frap_descripcion")
                                    grdNuevaFraccion.ActiveRow.Cells("Costo").Value = row("frap_precio")
                                    'grdNuevaFraccion.ActiveRow.Cells("Pagar").Value = Convert.ToInt32(row("frap_paga"))
                                    'grdNuevaFraccion.ActiveRow.Cells("Maquinaria").Value = row("mapr_descripcion")
                                    grdNuevaFraccion.ActiveRow.Cells("Activo").Value = 1

                                    grdNuevaFraccion.ActiveCell = grdNuevaFraccion.ActiveRow.Cells("Costo")
                                    grdNuevaFraccion.PerformAction(UltraGridAction.EnterEditMode, True, True)
                                Next
                            Else
                                adv.mensaje = "Ya existe la fracción para este artículo."
                                adv.StartPosition = FormStartPosition.CenterScreen
                                adv.ShowDialog()
                            End If
                        End If

                    ElseIf grdNuevaFraccion.ActiveCell.Column.ToString = "Maquinaria" Then
                        Dim form As New ListaMaquinariaForm
                        form.ShowDialog()
                        If form.idMaquinaria > 0 Then
                            grdNuevaFraccion.ActiveRow.Cells("Maquinaria").Value = form.descripcionMaquina
                            grdNuevaFraccion.ActiveRow.Cells("maquinaid").Value = form.idMaquinaria
                        End If
                    End If


                Catch ex As Exception
                End Try
            End If

        ElseIf e.KeyCode = Keys.Back Then
            Try
                If grdNuevaFraccion.ActiveRow.Selected = True Then
                    If IsDBNull(grdNuevaFraccion.ActiveRow.Cells("idFraccDes").Value) = True Then
                        borrar = True
                        grdNuevaFraccion.ActiveRow.Delete()

                        If grdNuevaFraccion.Rows.Count = 0 Then
                            grdNuevaFraccion.DisplayLayout.Bands(0).AddNew()
                            grdNuevaFraccion.ActiveRow.Cells("Pagar").Value = False
                            grdNuevaFraccion.ActiveRow.Cells("Sumar Costo").Value = False
                            grdNuevaFraccion.ActiveRow.Cells("Sumar Tiempo").Value = False
                            grdNuevaFraccion.PerformAction(UltraGridAction.EnterEditMode, True, True)
                        End If
                    Else
                        If grdNuevaFraccion.ActiveRow.Cells("idFraccDes").Value = 0 Then
                            borrar = True
                            grdNuevaFraccion.ActiveRow.Delete()

                            If grdNuevaFraccion.Rows.Count = 0 Then
                                grdNuevaFraccion.DisplayLayout.Bands(0).AddNew()
                                grdNuevaFraccion.ActiveRow.Cells("Pagar").Value = False
                                grdNuevaFraccion.ActiveRow.Cells("Sumar Costo").Value = False
                                grdNuevaFraccion.ActiveRow.Cells("Sumar Tiempo").Value = False
                                grdNuevaFraccion.PerformAction(UltraGridAction.EnterEditMode, True, True)
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try

        ElseIf e.KeyCode = Keys.Enter Then
            Try
                Dim comparador As String = ""

                If grdNuevaFraccion.Rows.Count > 0 Then
                    If grdNuevaFraccion.Rows(grdNuevaFraccion.Rows.Count - 1).Cells("Fracción").Text <> "" Then
                        grdNuevaFraccion.DisplayLayout.Bands(0).AddNew()
                        'grdFracciones.ActiveRow.Cells("idFraccion").Value = 0
                        'grdFracciones.ActiveRow.Cells("idFraccDes").Value = 0
                        'grdFracciones.ActiveRow.Cells("Costo").Value = 0
                        grdNuevaFraccion.ActiveRow.Cells("Pagar").Value = False
                        'grdFracciones.ActiveRow.Cells("Activo").Value = 1
                        grdNuevaFraccion.ActiveRow.Cells("Sumar Costo").Value = False
                        grdNuevaFraccion.ActiveRow.Cells("Sumar Tiempo").Value = False
                        'grdFracciones.ActiveRow.Cells("Orden").Value = grdFracciones.Rows.Count
                        'grdFracciones.ActiveCell = grdFracciones.ActiveRow.Cells("Costo")
                        grdNuevaFraccion.PerformAction(UltraGridAction.EnterEditMode, True, True)
                    End If
                End If

            Catch ex As Exception
            End Try

        End If

        'If estatusArticulo.Trim <> "DESCONTINUADO" Then
        '    If estatusArticulo.Trim <> "INACTIVO NAVE" Then
        '        If e.KeyCode = Keys.F1 Then
        '            Dim a As String = ""
        '            If Not grdFracciones.ActiveRow.IsFilterRow Then
        '                Try
        '                    If grdFracciones.ActiveCell.Column.ToString = "Fracción" Then
        '                        'Mostrar ventana de componente
        '                        Dim obj As New ConsumosBU
        '                        Dim f As New DataTable
        '                        Dim form As New listaFraccionesForm
        '                        form.ShowDialog()
        '                        Dim idFraccion As Integer = 0
        '                        idFraccion = form.id
        '                        If form.cerrado = False Then
        '                            If True Then 'validarFraccion(idFraccion) Then
        '                                f = obj.getFraccion(idFraccion)
        '                                For Each row As DataRow In f.Rows
        '                                    grdFracciones.ActiveRow.Cells("idFraccion").Value = row("frap_fraccionid")
        '                                    grdFracciones.ActiveRow.Cells("idFraccDes").Value = 0
        '                                    grdFracciones.ActiveRow.Cells("Fracción").Value = row("frap_descripcion")
        '                                    grdFracciones.ActiveRow.Cells("Costo").Value = row("frap_precio")
        '                                    grdFracciones.ActiveRow.Cells("Pagar").Value = Convert.ToInt32(row("frap_paga"))
        '                                    'grdFracciones.ActiveRow.Cells("Maquinaria").Value = row("mapr_descripcion")
        '                                    grdFracciones.ActiveRow.Cells("Activo").Value = 1

        '                                    grdFracciones.ActiveCell = grdFracciones.ActiveRow.Cells("Costo")
        '                                    grdFracciones.PerformAction(UltraGridAction.EnterEditMode, True, True)
        '                                Next
        '                            Else
        '                                adv.mensaje = "Ya existe la fracción para este artículo."
        '                                adv.StartPosition = FormStartPosition.CenterScreen
        '                                adv.ShowDialog()
        '                            End If
        '                        End If

        '                    ElseIf grdFracciones.ActiveCell.Column.ToString = "Maquinaria" Then
        '                        Dim form As New ListaMaquinariaForm
        '                        form.ShowDialog()
        '                        If form.idMaquinaria > 0 Then
        '                            grdFracciones.ActiveRow.Cells("Maquinaria").Value = form.descripcionMaquina
        '                            grdFracciones.ActiveRow.Cells("maquinaid").Value = form.idMaquinaria
        '                        End If
        '                    End If


        '                Catch ex As Exception
        '                End Try
        '            End If

        '        ElseIf e.KeyCode = Keys.Enter Then
        '            Try
        '                Dim comparador As String = ""

        '                If grdFracciones.Rows(grdFracciones.Rows.Count - 1).Cells("Fracción").Text <> "" Then
        '                    grdFracciones.DisplayLayout.Bands(0).AddNew()
        '                    grdFracciones.ActiveRow.Cells("idFraccion").Value = 0
        '                    grdFracciones.ActiveRow.Cells("idFraccDes").Value = 0
        '                    grdFracciones.ActiveRow.Cells("Costo").Value = 0
        '                    grdFracciones.ActiveRow.Cells("Pagar").Value = False
        '                    grdFracciones.ActiveRow.Cells("Activo").Value = 1
        '                    grdFracciones.ActiveRow.Cells("Sumar Costo").Value = 1
        '                    grdFracciones.ActiveRow.Cells("Sumar Tiempo").Value = 1
        '                    grdFracciones.ActiveRow.Cells("Orden").Value = grdFracciones.Rows.Count
        '                    grdFracciones.ActiveCell = grdFracciones.ActiveRow.Cells("Costo")
        '                    grdFracciones.PerformAction(UltraGridAction.EnterEditMode, True, True)
        '                End If
        '            Catch ex As Exception
        '            End Try
        '            Try
        '                calcularTotales()
        '            Catch ex As Exception
        '            End Try
        '        ElseIf e.KeyCode = Keys.Back Then
        '            Try
        '                If grdFracciones.ActiveRow.Selected = True Then
        '                    If grdFracciones.ActiveRow.Cells("idFraccDes").Value = 0 Then
        '                        borrar = True
        '                        grdFracciones.ActiveRow.Delete()
        '                    End If
        '                End If
        '            Catch ex As Exception
        '            End Try
        '        End If
        '        pintarceldas()
        '    End If


        'End If
        '-*-------------------------------
        'If e.KeyCode = Keys.F1 Then
        '    Dim a As String = ""
        '    If Not grdNuevaFraccion.ActiveRow.IsFilterRow Then
        '        Try
        '            'If grdFracciones.ActiveCell.Column.ToString = "Fracción" Then
        '            'Mostrar ventana de componente
        '            Dim obj As New ConsumosBU
        '            Dim f As New DataTable
        '            Dim form As New listaFraccionesForm
        '            form.ShowDialog()
        '            Dim idFraccion As Integer = 0
        '            idFraccion = form.id
        '            If form.selecciono = True Then
        '                If validarFraccion(idFraccion) Then
        '                    f = obj.getFraccion(idFraccion)
        '                    For Each row As DataRow In f.Rows
        '                        grdNuevaFraccion.ActiveRow.Cells("idFraccion").Value = row("frap_fraccionid")
        '                        grdNuevaFraccion.ActiveRow.Cells("idFraccDes").Value = 0
        '                        grdNuevaFraccion.ActiveRow.Cells("Fracción").Value = row("frap_descripcion")
        '                        grdNuevaFraccion.ActiveRow.Cells("Costo").Value = row("frap_precio")
        '                        If Convert.ToInt32(row("frap_paga")) = 1 Then
        '                            grdNuevaFraccion.ActiveRow.Cells("Pagar").Value = True
        '                        Else
        '                            grdNuevaFraccion.ActiveRow.Cells("Pagar").Value = False
        '                        End If
        '                        grdNuevaFraccion.ActiveRow.Cells("Maquinaria").Value = row("mapr_descripcion")
        '                        grdNuevaFraccion.ActiveRow.Cells("Activo").Value = True
        '                    Next
        '                Else
        '                    adv.mensaje = "Ya existe la fracción para este artículo."
        '                    adv.StartPosition = FormStartPosition.CenterScreen
        '                    adv.ShowDialog()
        '                End If
        '            End If
        '        Catch ex As Exception
        '        End Try
        '    End If

        'ElseIf e.KeyCode = Keys.Enter Then
        '    Try
        '        Dim comparador As String = ""

        '        If grdNuevaFraccion.Rows(grdNuevaFraccion.Rows.Count - 1).Cells("Fracción").Text <> "" Then
        '            grdNuevaFraccion.DisplayLayout.Bands(0).AddNew()
        '            grdNuevaFraccion.ActiveRow.Cells("idFraccion").Value = 0
        '            grdNuevaFraccion.ActiveRow.Cells("idFraccDes").Value = 0
        '            grdNuevaFraccion.ActiveRow.Cells("Costo").Value = 0
        '            grdNuevaFraccion.ActiveRow.Cells("Pagar").Value = 0
        '            grdNuevaFraccion.ActiveRow.Cells("Activo").Value = 1
        '        End If
        '    Catch ex As Exception
        '    End Try
        'ElseIf e.KeyCode = Keys.Back Then
        '    Try
        '        If grdNuevaFraccion.ActiveRow.Selected = True Then
        '            If grdNuevaFraccion.ActiveRow.Cells("idFraccDes").Value = 0 Then
        '                borrar = True
        '                grdNuevaFraccion.ActiveRow.Delete()
        '            End If
        '        End If
        '    Catch ex As Exception
        '    End Try
        'End If

        ''If e.KeyCode = Keys.F1 Then
        ''    Dim a As String = ""
        ''    If Not grdNuevaFraccion.ActiveRow.IsFilterRow Then
        ''        Try
        ''            'If grdFracciones.ActiveCell.Column.ToString = "Fracción" Then
        ''            'Mostrar ventana de componente
        ''            Dim obj As New ConsumosBU
        ''            Dim f As New DataTable
        ''            Dim form As New listaFraccionesForm
        ''            form.ShowDialog()
        ''            Dim idFraccion As Integer = 0
        ''            Dim tamaño As Integer = 0
        ''            tamaño = grdNuevaFraccion.Rows.Count
        ''            idFraccion = form.id
        ''            f = obj.getFraccion(idFraccion)
        ''            'For value = 0 To f.Rows.Count - 1
        ''            grdNuevaFraccion.Rows(tamaño).Cells("idFraccion").Value = f.Rows(0).Item("frap_fraccionid").ToString
        ''            grdNuevaFraccion.Rows(tamaño).Cells("idFraccDes").Value = 0
        ''            grdNuevaFraccion.Rows(tamaño).Cells("Fracción").Value = f.Rows(0).Item("frap_descripcion").ToString
        ''            grdNuevaFraccion.Rows(tamaño).Cells("Costo").Value = f.Rows(0).Item("frap_precio").ToString
        ''            grdNuevaFraccion.Rows(tamaño).Cells("Pagar").Value = Convert.ToInt32(f.Rows(0).Item("frap_paga").ToString)
        ''            grdNuevaFraccion.Rows(tamaño).Cells("Maquinaria").Value = f.Rows(0).Item("mapr_descripcion").ToString
        ''            grdNuevaFraccion.Rows(tamaño).Cells("Activo").Value = 1
        ''            tamaño = tamaño + 1
        ''            ' Next

        ''        Catch ex As Exception
        ''        End Try
        ''    End If

        ''ElseIf e.KeyCode = Keys.Enter Then
        ''    Try

        ''        grdNuevaFraccion.DisplayLayout.Bands(0).AddNew()
        ''        grdNuevaFraccion.ActiveRow.Cells("idFraccion").Value = 0
        ''        grdNuevaFraccion.ActiveRow.Cells("idFraccDes").Value = 0
        ''        grdNuevaFraccion.ActiveRow.Cells("Costo").Value = 0
        ''        grdNuevaFraccion.ActiveRow.Cells("Pagar").Value = False
        ''        grdNuevaFraccion.ActiveRow.Cells("Activo").Value = 1
        ''    Catch ex As Exception

        ''    End Try
        ''ElseIf e.KeyCode = Keys.Back Then
        ''    Try
        ''        If grdNuevaFraccion.ActiveRow.Selected = True Then
        ''            If grdFracciones.ActiveRow.Cells("idFraccDes").Value = 0 Then
        ''                borrar = True
        ''                grdNuevaFraccion.ActiveRow.Delete()
        ''            End If
        ''        End If
        ''    Catch ex As Exception
        ''    End Try

        ''End If

    End Sub

    Public Sub CargarListaObservacionesFracciones(cadena As String)
        Dim obs As New DataTable
        Dim obj As New ConsumosBU
        Dim listobs As New ValueList
        obs = obj.getObservacionesFracciones(cadena)
        For Each row As DataRow In obs.Rows
            listobs.ValueListItems.Add(row("observacionFraccion"))
        Next
        With grdNuevaFraccion.DisplayLayout.Bands(0)
            .Columns("Observaciones").ValueList = listobs
            .Columns("Observaciones").Style = UltraWinGrid.ColumnStyle.DropDown
            .Columns("Observaciones").AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End With
    End Sub

    Public Sub filtrarProductosParaFracciones(ByVal nuevo As Integer)
        Dim obj As New catalagosBU
        Dim marca, coleccion As Integer
        Dim lista As New DataTable
        Dim listaComponentes As New List(Of Integer)
        Dim listaProdEstilo As New List(Of Integer)
        Dim accion As Integer = 0
        Dim fraccion As Integer = 0
        Dim obj2 As New ConsumosBU

        If cmbMarcaFraccion.Text = "" Then
            marca = 0
        Else
            marca = cmbMarcaFraccion.SelectedValue

        End If

        If cmbColeccionFraccion.Text = "" Then
            coleccion = 0
        Else
            coleccion = cmbColeccionFraccion.SelectedValue
        End If

        'If rdoNuevoFraccion.Checked = True Then
        'Else
        '    fraccion = lblIdFraccionCambio.Text
        'End If

        If nuevo = 1 Then
            'obtener lista de productos y sus id consumos
            'lista = obj.filtradoFracciones(idnave, marca, coleccion, fraccion, nuevo)
            lista = obj2.ListadoProductosFraccionesNave(idnave, "", marca, coleccion, 1, FraccionIDSeleccionada, ObservacionesFraccionSeleccionada)


        Else
            If rdoNuevoFraccion.Checked = True Then
                lista = obj2.VerListaProductosImagenFracciones(idnave, "", marca, coleccion, 1)
            End If
        End If


        grdFracciones.DataSource = lista
        disenogrdFracciones()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles btnMostrarFracciones.Click
        ' If cmbMarcaFraccion.Text <> "" Then '24/02/2020
        'Try'24/02/2020
        Cursor = Cursors.WaitCursor
        If rdoNuevoFraccion.Checked = True Then
            filtrarProductosParaFracciones(0)
        Else
            If FraccionIDSeleccionada > 0 Then
                filtrarProductosParaFracciones(1)
            Else
                adv.mensaje = "Seleccione la fracción a cambiar el precio"
                adv.StartPosition = FormStartPosition.CenterScreen
                adv.ShowDialog()
            End If

            'If lblIdFraccionCambio.Text <> "" Then
            '    If lblIdFraccionCambio.Text <> " " Then
            '        filtrarProductosParaFracciones(1)
            '    Else
            '        adv.mensaje = "Seleccione la fracción a cambiar el precio"
            '        adv.StartPosition = FormStartPosition.CenterScreen
            '        adv.ShowDialog()
            '        lblFraccion.ForeColor = Drawing.Color.Red
            '    End If
            'Else
            '    adv.mensaje = "Seleccione una fracción para poder realizar el filtrado"
            '    adv.StartPosition = FormStartPosition.CenterScreen
            '    adv.ShowDialog()
            '    lblFraccion.ForeColor = Drawing.Color.Red
            'End If
        End If

        'Catch ex As Exception '24/02/2020
        'End Try '24/02/2020
        '**24/02/2020
        'Else
        '    objadvertencia.mensaje = "Seleccione un marca"
        '    objadvertencia.StartPosition = FormStartPosition.CenterScreen
        '    objadvertencia.ShowDialog()
        '    lblMarcaFraccion.ForeColor = Drawing.Color.Red
        'End If
        'fin **24/02/2020
        Cursor = Cursors.Default
    End Sub

    Public Sub BuscarProveedoresMaterialesEnNave()
        Dim obj As New catalagosBU
        Dim tabla As New DataTable
        Dim no = 0
        Dim lista As New List(Of Integer)
        Dim listaEstilos As New List(Of Integer)
        Dim tablaProveedor As New DataTable
        Dim tablaMateriales As New DataTable

        For value = 0 To grdConsumos.Rows.Count - 1
            If grdConsumos.Rows(value).Cells(" ").Value = 1 Then
                listaEstilos.Add(grdConsumos.Rows(value).Cells("idEstilo").Value)
            End If
        Next

        For value = 0 To listaEstilos.Count - 1
            tabla = obj.listaNavesAsignadasEstilo(listaEstilos.Item(value))
            For value2 = 0 To tabla.Rows.Count - 1
                lista.Add(tabla.Rows(value2).Item(0))
            Next
        Next

        For value = 0 To lista.Count - 1
            tablaProveedor = obj.listaProveedoresNave(lista.Item(value), lblIdproveedorTexto.Text)
            If tablaProveedor.Rows.Count = 0 Then
                obj.InsertarProveedoresNave(lista.Item(value), lblIdproveedorTexto.Text)
            End If
        Next

        For value = 0 To lista.Count - 1
            tablaMateriales = obj.listaMaterialesNave(lista.Item(value), lblMaterialTexto.Text)
            If tablaMateriales.Rows.Count = 0 Then
                obj.InsertarMaterialesNave(lista.Item(value), lblMaterialTexto.Text)
            End If
        Next

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTodof.CheckedChanged

        Dim x = 0

        If cbxTodof.Text = "Seleccionar todo" And x = 0 Then
            For Each row In grdFracciones.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = True
            Next
            cbxTodof.Text = "Deseleccionar todo"
            x = x + 1
        End If

        If cbxTodof.Text = "Deseleccionar todo" And x = 0 Then
            For Each row In grdFracciones.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = False
            Next
            cbxTodof.Text = "Seleccionar todo"
            x = x + 1
        End If

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        'cmbMarca.SelectedValue = 0
        cmbMarca.DataSource = Nothing
        'cmbColeccion.SelectedValue = 0
        cmbColeccion.DataSource = Nothing
        grdConsumos.DataSource = Nothing
        lblClasificacionTexto.Text = "-"
        lblIdclass.Text = "-"
        lblMaterialTextoTitulo.Text = "-"
        lblMaterialTexto.Text = "-"
        lblSKUTextoTitulo.Text = "-"
        lblProveedorNuevoTexto.Text = "-"
        lblPrecioNuevotexto.Text = "-"
        lblUMPNuevoTexto.Text = "-"
        lblFactorNuevoTexto.Text = "-"
        lblIdproveedorTexto.Text = "-"
        lblUMNProveedorNuevoTexto.Text = "-"
        lblIdmaterialremplazarTexto.Text = "-"
        lblmaterialremplazartexto.Text = "-"
        lblskureemplazartexto.Text = "-"
        btnBuscar2.Visible = False
        lblClassTexto.Text = "-"
        lblProveedorReemplazarTexto.Text = "-"
        lblPrecioReemplazarTexto.Text = "-"
        lblUMPReemplazarTexto.Text = "-"
        lblFactorReemplazarTexto.Text = "-"
        lblClasificacionReemplazarTexto.Text = "-"
        lblMaterialaveid.Text = "-"
    End Sub

    Private Sub btnLimpiarFracciones_Click(sender As Object, e As EventArgs) Handles btnLimpiarFracciones.Click
        cmbMarcaFraccion.SelectedValue = 0
        cmbColeccionFraccion.SelectedValue = 0
        grdFracciones.DataSource = Nothing
        cbxTodof.Checked = False
        lblFraccionElimina.Text = "-" 'String.Empty
        lblObservacionElimina.Text = "-" 'String.Empty
        lblValorFraccionSeleccionada.Text = "-"
        lblValorObservacionesSeleccionada.Text = "-"
        txtCosto.Text = String.Empty
        crearTablaFracciones()


    End Sub

    Private Sub cmbMarcaFraccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarcaFraccion.SelectedIndexChanged
        grdFracciones.DataSource = Nothing
        cmbColeccionFraccion.DataSource = Nothing
        Try
            'ListadoColeccionFraccionesNaveMarca
            If rdoCambioPrecio.Checked = True Or rbEliminarFraccion.Checked = True Then
                llenarComboColeccionFraccionNaveMarca(idnave, cmbMarcaFraccion.SelectedValue)
            Else
                llenarComboColeccionNaveDesarrolla(idnave, cmbMarcaFraccion.SelectedValue)
            End If


        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbColeccionFraccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColeccionFraccion.SelectedIndexChanged
        grdFracciones.DataSource = Nothing
    End Sub

    Private Sub cmbColeccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColeccion.SelectedIndexChanged
        grdConsumos.DataSource = Nothing
    End Sub


    Private Sub grdFracciones_KeyUp(sender As Object, e As KeyEventArgs) Handles grdFracciones.KeyUp

    End Sub

    Private Sub txtCosto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCosto.KeyDown

    End Sub

    Private Sub txtCosto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCosto.KeyPress
        Dim EsDoblePunto As Boolean = False
        Dim EsNumero As Boolean = False
        Dim indice As Integer = 0
        Dim Tamañotexto As Integer = 0
        teclarpuntoCosto = False
        Dim posiciontext As Integer = txtCosto.SelectionStart

        indice = txtCosto.Text.IndexOf(".")
        Tamañotexto = txtCosto.Text.Length
        teclarpuntoCosto = False

        If e.KeyChar = "." Then
            If txtCosto.Text.Contains(".") = True Then
                EsDoblePunto = True
            End If
            teclarpuntoCosto = True
        End If

        If Not (IsNumeric(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = ChrW(Keys.Back)) Then

            e.Handled = True
            EsNumero = False

        Else
            EsNumero = True
            If indice <> -1 Then
                If posiciontext >= indice Then
                    If e.KeyChar <> ChrW(Keys.Back) Then
                        If (Tamañotexto - indice) > 3 Then
                            e.Handled = True
                        End If
                    End If
                End If

            End If

        End If

        If EsNumero = True Then
            If EsDoblePunto = True Then
                e.Handled = True
            End If
        End If



    End Sub

    Private Sub txtCosto_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCosto.KeyUp

        'Dim Costo As Double = 0
        'If teclarpuntoCosto = False Then
        '    If txtCosto.Text <> String.Empty Then
        '        Costo = CDbl(txtCosto.Text)
        '        txtCosto.Text = Convert.ToDouble(Costo.ToString("#0.000")).ToString

        '    End If

        'End If

    End Sub

    Private Sub txtCosto_LostFocus(sender As Object, e As EventArgs) Handles txtCosto.LostFocus

        'Dim Costo As Double = 0
        'If txtCosto.Text <> String.Empty Then
        '    Costo = CDbl(txtCosto.Text)
        '    txtCosto.Text = Math.Round(Costo, 3)
        'End If


    End Sub

    Private Sub rbNuevoMaterial_CheckedChanged(sender As Object, e As EventArgs) Handles rbNuevoMaterial.CheckedChanged
        chSoloDesarrollo.Visible = False
        pnlNuevoMaterial.Visible = True
        pnlCambioMaterial.Visible = False
        cmbMarcaMaterialNuevo.Visible = True
        cmbColeccionMaterialNuevo.Visible = True
        lblLimpiarMaterialNuevo.Visible = True
        lblMostrarMaterialNuevo.Visible = True
        btnMostrarMaterialNuevo.Visible = True
        btnLimpiarMaterialNuevo.Visible = True
        lblMarcaMaterialNuevo.Visible = True
        lblColeccionMaterialNuevo.Visible = True
        pnlEliminarMaterial.Visible = False
        btnLimpiar_Click(Nothing, Nothing)

        llenarcomboMarcaMaterialSeleccionado(cmbMarcaMaterialNuevo)

    End Sub

    Private Sub rbCambioMaterial_CheckedChanged(sender As Object, e As EventArgs) Handles rbCambioMaterial.CheckedChanged
        pnlEliminarMaterial.Visible = False
        pnlCambioMaterial.Visible = True
        pnlNuevoMaterial.Visible = False
        cmbMarcaMaterialNuevo.Visible = False
        cmbColeccionMaterialNuevo.Visible = False
        lblLimpiarMaterialNuevo.Visible = False
        lblMostrarMaterialNuevo.Visible = False
        btnMostrarMaterialNuevo.Visible = False
        btnLimpiarMaterialNuevo.Visible = False
        lblMarcaMaterialNuevo.Visible = False
        lblColeccionMaterialNuevo.Visible = False
        chSoloDesarrollo.Visible = True
        btnLimpiarMaterialNuevo_Click(Nothing, Nothing)

    End Sub

    Public Sub crearTablaMateriales()

        tablaMateriales.Columns.Clear()
        tablaMateriales.Columns.Add("ID")
        tablaMateriales.Columns.Add("IdMaterialNave")
        tablaMateriales.Columns.Add("IdMaterial")
        tablaMateriales.Columns.Add("IdProveedor")
        tablaMateriales.Columns.Add("IdUmProveedor")
        tablaMateriales.Columns.Add("IdUmProduccion")
        tablaMateriales.Columns.Add("IdClasificacion")
        tablaMateriales.Columns.Add("IdComponente")
        tablaMateriales.Columns.Add("Componente")
        tablaMateriales.Columns.Add("Clasificación")
        tablaMateriales.Columns.Add("SKU")
        tablaMateriales.Columns.Add("Material")
        tablaMateriales.Columns.Add("*Consumo")
        tablaMateriales.Columns.Add("Proveedor")
        tablaMateriales.Columns.Add("Precio UMC")
        tablaMateriales.Columns.Add("UMC")
        tablaMateriales.Columns.Add("Factor")


        grdMaterialNuevo.DataSource = tablaMateriales
        grdMaterialNuevo.DisplayLayout.Bands(0).AddNew()
        diseniogridMateriales()

    End Sub

    Private Sub grdMaterialNuevo_KeyUp(sender As Object, e As KeyEventArgs) Handles grdMaterialNuevo.KeyUp
        Dim MaterialesCargadosId As String = String.Empty


        If e.KeyCode = Keys.F1 Then
            Dim a As String = ""
            If Not grdMaterialNuevo.ActiveRow.IsFilterRow Then
                Try

                    If grdMaterialNuevo.ActiveCell.Column.ToString = "Componente" Then
                        Dim form As New ListaComponentesForm
                        form.ShowDialog()

                        If form.idComponente > 0 Then 'Mostrar Clasificación
                            grdMaterialNuevo.ActiveRow.Cells("idComponente").Value = form.idComponente
                            grdMaterialNuevo.ActiveRow.Cells("Componente").Value = form.Componente

                            Dim form3 As New ListaClasificacionesForm
                            form3.idcomponente = grdMaterialNuevo.ActiveRow.Cells("idComponente").Text
                            form3.ShowDialog()
                            grdMaterialNuevo.ActiveRow.Cells("idClasificacion").Value = form3.idClasificacion
                            grdMaterialNuevo.ActiveRow.Cells("Clasificación").Value = form3.Clasificacion
                            grdMaterialNuevo.ActiveRow.Cells("ID").Value = 0
                            grdMaterialNuevo.ActiveRow.Cells("IdMaterialNave").Value = 0
                            grdMaterialNuevo.ActiveRow.Cells("IdMaterial").Value = 0
                            grdMaterialNuevo.ActiveRow.Cells("IdProveedor").Value = 0
                            grdMaterialNuevo.ActiveRow.Cells("IdUmProveedor").Value = 0
                            grdMaterialNuevo.ActiveRow.Cells("IdUmProduccion").Value = 0
                            grdMaterialNuevo.ActiveRow.Cells("SKU").Value = ""
                            grdMaterialNuevo.ActiveRow.Cells("Material").Value = ""
                            grdMaterialNuevo.ActiveRow.Cells("*Consumo").Value = ""
                            grdMaterialNuevo.ActiveRow.Cells("Proveedor").Value = ""
                            grdMaterialNuevo.ActiveRow.Cells("Precio UMC").Value = ""
                            grdMaterialNuevo.ActiveRow.Cells("UMC").Value = ""
                            grdMaterialNuevo.ActiveRow.Cells("Factor").Value = ""
                            If form3.idClasificacion > 0 Then
                                Dim form4 As New listaMaterialesForm
                                form4.clasificacion = grdMaterialNuevo.ActiveRow.Cells("idClasificacion").Value
                                form4.nave = idnave
                                'form4.lista = listaMateriales
                                form4.accion = "Desarrollo"
                                'form4.ProductoEstiloID = productoEstiloId
                                form4.ShowDialog()

                                grdMaterialNuevo.ActiveRow.Cells("ID").Value = form4.idMaterial
                                grdMaterialNuevo.ActiveRow.Cells("IdMaterialNave").Value = form4.materialNaveid
                                grdMaterialNuevo.ActiveRow.Cells("IdMaterial").Value = form4.idMaterial
                                grdMaterialNuevo.ActiveRow.Cells("IdProveedor").Value = form4.idProveedor
                                grdMaterialNuevo.ActiveRow.Cells("IdUmProveedor").Value = form4.idUMC
                                grdMaterialNuevo.ActiveRow.Cells("IdUmProduccion").Value = form4.idUMP
                                grdMaterialNuevo.ActiveRow.Cells("SKU").Value = form4.SKU
                                grdMaterialNuevo.ActiveRow.Cells("Material").Value = form4.Material
                                grdMaterialNuevo.ActiveRow.Cells("*Consumo").Value = 0
                                grdMaterialNuevo.ActiveRow.Cells("Proveedor").Value = form4.Provedor
                                grdMaterialNuevo.ActiveRow.Cells("Precio UMC").Value = form4.precio
                                grdMaterialNuevo.ActiveRow.Cells("UMC").Value = form4.UMC
                                grdMaterialNuevo.ActiveRow.Cells("Factor").Value = form4.equivalencia
                                grdMaterialNuevo.ActiveCell = grdMaterialNuevo.ActiveRow.Cells("*Consumo")
                                grdMaterialNuevo.PerformAction(UltraGridAction.EnterEditMode, True, True)
                            End If

                        End If
                    End If
                    'If grdMaterialNuevo.ActiveCell.Column.ToString = "Material" Then
                    '    'Dim obj As New ConsumosBU
                    '    Dim f As New DataTable
                    '    Dim form2 As New listaMaterialesForm
                    '    form2.nave = idnave
                    '    form2.x = 2
                    '    form2.cambiosglobalesmaterial = 0

                    '    For Each fila As UltraGridRow In grdMaterialNuevo.Rows
                    '        If MaterialesCargadosId = String.Empty Then
                    '            If IsDBNull(fila.Cells("ID").Value) = False Then
                    '                MaterialesCargadosId = fila.Cells("ID").Value
                    '            End If

                    '        Else
                    '            If IsDBNull(fila.Cells("ID").Value) = False Then
                    '                MaterialesCargadosId += "," + fila.Cells("ID").Value
                    '            End If

                    '        End If
                    '    Next

                    '    form2.ShowDialog()

                    '    If MaterialesCargadosId.Contains(form2.idMaterial) = False Then

                    '        Dim idMaterial As Integer = 0
                    '        idMaterial = form2.idMaterial
                    '        grdMaterialNuevo.ActiveRow.Cells("ID").Value = form2.idMaterial
                    '        grdMaterialNuevo.ActiveRow.Cells("IdMaterialNave").Value = form2.materialNaveid
                    '        grdMaterialNuevo.ActiveRow.Cells("IdMaterial").Value = form2.idMaterial
                    '        grdMaterialNuevo.ActiveRow.Cells("IdProveedor").Value = form2.idProveedor
                    '        grdMaterialNuevo.ActiveRow.Cells("IdUmProveedor").Value = form2.idUMC
                    '        grdMaterialNuevo.ActiveRow.Cells("IdUmProduccion").Value = form2.idUMP
                    '        grdMaterialNuevo.ActiveRow.Cells("IdClasificacion").Value = form2.idClasificacion
                    '        grdMaterialNuevo.ActiveRow.Cells("SKU").Value = form2.SKU
                    '        grdMaterialNuevo.ActiveRow.Cells("Material").Value = form2.Material
                    '        grdMaterialNuevo.ActiveRow.Cells("*Consumo").Value = 0
                    '        grdMaterialNuevo.ActiveRow.Cells("Proveedor").Value = form2.Provedor
                    '        grdMaterialNuevo.ActiveRow.Cells("Precio UMC").Value = form2.precio
                    '        grdMaterialNuevo.ActiveRow.Cells("UMC").Value = form2.UMC
                    '        grdMaterialNuevo.ActiveRow.Cells("Factor").Value = form2.equivalencia
                    '        grdMaterialNuevo.ActiveRow.Cells("Clasificación").Value = form2.Clasificacionx
                    '        grdMaterialNuevo.PerformAction(UltraGridAction.EnterEditMode, True, True)
                    '    Else
                    '        Dim mensajeAdvertencia As New AdvertenciaForm
                    '        mensajeAdvertencia.mensaje = "El material ya fue agregado"
                    '        mensajeAdvertencia.ShowDialog()
                    '    End If

                    'End If

                    llenarcomboMarcaMaterialSeleccionado(cmbMarcaMaterialNuevo)

                Catch ex As Exception
                End Try
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            Try
                Dim comparador As String = ""

                If grdMaterialNuevo.Rows.Count > 0 Then
                    If grdMaterialNuevo.Rows(grdMaterialNuevo.Rows.Count - 1).Cells("Componente").Text <> "" Then
                        grdMaterialNuevo.DisplayLayout.Bands(0).AddNew()
                        grdMaterialNuevo.PerformAction(UltraGridAction.EnterEditMode, True, True)
                    End If
                End If

            Catch ex As Exception
            End Try
        End If

    End Sub

    Public Sub diseniogridMateriales()
        With grdMaterialNuevo.DisplayLayout.Bands(0)
            .Columns("ID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("SKU").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Material").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("*Consumo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Proveedor").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Precio UMC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("UMC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Factor").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Clasificación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Componente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("Precio UMC").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Factor").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("*Consumo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("ID").Hidden = True
            .Columns("IdMaterialNave").Hidden = True
            .Columns("IdProveedor").Hidden = True
            .Columns("IdUmProveedor").Hidden = True
            .Columns("IdUmProduccion").Hidden = True
            .Columns("IdClasificacion").Hidden = True
            .Columns("IdMaterial").Hidden = True
            .Columns("IdComponente").Hidden = True

            .Columns("SKU").Width = 70
            .Columns("Material").Width = 130
            .Columns("Proveedor").Width = 130
            .Columns("Precio UMC").Width = 70
            .Columns("UMC").Width = 70
            .Columns("Factor").Width = 70
            .Columns("Clasificación").Width = 100
            .Columns("Componente").Width = 100



            .Columns("Material").CharacterCasing = Infragistics.Win.UltraWinGrid.Case.Lower

        End With

        grdMaterialNuevo.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdMaterialNuevo.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

    End Sub

    Private Sub btnLimpiarMaterialNuevo_Click(sender As Object, e As EventArgs) Handles btnLimpiarMaterialNuevo.Click
        cmbMarcaMaterialNuevo.DataSource = Nothing
        cmbColeccionMaterialNuevo.DataSource = Nothing
        grdConsumos.DataSource = Nothing
    End Sub

    Private Sub cmbMarcaMaterialNuevo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarcaMaterialNuevo.SelectedIndexChanged
        Try
            llenarcomboColeccionMaterialSeleccionado(cmbColeccionMaterialNuevo)
        Catch ex As Exception
        End Try
        grdConsumos.DataSource = Nothing
        If cmbMarcaMaterialNuevo.Text <> "" Then
            lblMarcaMaterialNuevo.ForeColor = Drawing.Color.Black
        Else
            cmbColeccionMaterialNuevo.DataSource = Nothing
        End If
    End Sub

    Private Sub btnMostrarMaterialNuevo_Click(sender As Object, e As EventArgs) Handles btnMostrarMaterialNuevo.Click

        Me.Cursor = Cursors.WaitCursor
        Dim vMateriales As String = String.Empty
        Dim vMarcaId As Integer
        Dim vColeccionId As Integer
        Dim obj As New catalagosBU
        Dim dtResultado As DataTable


        If rbNuevoMaterial.Checked = True Then

            For Each Row As UltraGridRow In grdMaterialNuevo.Rows
                If vMateriales <> Nothing Then
                    vMateriales += ","
                End If
                vMateriales += Row.Cells("IdMaterialNave").Value.ToString()
            Next

            vMarcaId = IIf(cmbMarcaMaterialNuevo.Text = "", 0, cmbMarcaMaterialNuevo.SelectedValue)
            vColeccionId = IIf(cmbColeccionMaterialNuevo.Text = "", 0, cmbColeccionMaterialNuevo.SelectedValue)

            dtResultado = obj.ObtenerArticulosMarcaColeccion(vMarcaId, vColeccionId, idnave, vMateriales)

            If dtResultado.Rows.Count > 0 Then
                grdConsumos.DataSource = dtResultado
                disenogrd()
            Else
                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.mensaje = "No hay datos para mostrar"
                mensajeAdvertencia.ShowDialog()
            End If
        ElseIf rbEliminarMaterial.Checked = True Then
            filtrar2()
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub guardarMaterialNuevo()
        Me.Cursor = Cursors.WaitCursor
        Try

            Dim obj As New catalagosBU
            Dim vXmlMaterialesNuevos As XElement = New XElement("Materiales")
            Dim vMaterialesNuevos As String = String.Empty
            Dim cellIsNothing As Boolean = False

            For Each Row As UltraGridRow In grdMaterialNuevo.Rows
                cellIsNothing = False
                For Each cell In Row.Cells
                    If cell.Value Is Nothing Or cell.Value.ToString() = "" Then
                        cellIsNothing = True
                        Exit For
                    End If
                Next
                If cellIsNothing = False Then
                    Dim vNodo As XElement = New XElement("Material")
                    vNodo.Add(New XAttribute("ClasificacionId", Row.Cells("IdClasificacion").Value.ToString()))
                    vNodo.Add(New XAttribute("IdComponente", Row.Cells("IdComponente").Value.ToString()))
                    vNodo.Add(New XAttribute("MaterialIdNuevo", Row.Cells("IdMaterialNave").Value.ToString()))
                    vNodo.Add(New XAttribute("MaterialId", Row.Cells("IdMaterial").Value.ToString()))
                    vNodo.Add(New XAttribute("ProveedorID", Row.Cells("IdProveedor").Value.ToString()))
                    vNodo.Add(New XAttribute("UmProveedorId", Row.Cells("IdUmProveedor").Value.ToString()))
                    vNodo.Add(New XAttribute("FactorConversor", Row.Cells("Factor").Value.ToString()))
                    vNodo.Add(New XAttribute("PrecioCompra", Row.Cells("Precio UMC").Value.ToString()))
                    vNodo.Add(New XAttribute("PrecioUmProduccion", Row.Cells("Precio UMC").Value.ToString() / Row.Cells("Factor").Value.ToString()))
                    vNodo.Add(New XAttribute("UmProduccionId", Row.Cells("IdUmProduccion").Value.ToString()))
                    vNodo.Add(New XAttribute("Consumo", Row.Cells("*Consumo").Value.ToString()))
                    vXmlMaterialesNuevos.Add(vNodo)
                End If
            Next

            For Each Row As UltraGridRow In grdConsumos.Rows.GetFilteredInNonGroupByRows
                If Row.Cells(" ").Value = True Then
                    If vMaterialesNuevos <> Nothing Then
                        vMaterialesNuevos += ","
                    End If
                    vMaterialesNuevos += Row.Cells("idEstilo").Value.ToString()
                End If
            Next

            If vMaterialesNuevos <> "" Then

                obj.GuardarMaterialesCambiosGlobales(vXmlMaterialesNuevos.ToString(), vMaterialesNuevos, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

                Dim mensajeAdvertencia As New ExitoForm
                mensajeAdvertencia.mensaje = "Datos guardados correctamente"
                mensajeAdvertencia.ShowDialog()
                btnLimpiarMaterialNuevo_Click(Nothing, Nothing)
                Me.Close()
            Else
                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.mensaje = "Seleccione un registro"
                mensajeAdvertencia.ShowDialog()

            End If

        Catch ex As Exception

            Dim mensajeAdvertencia As New ErroresForm
            mensajeAdvertencia.mensaje = ex.Message
            mensajeAdvertencia.ShowDialog()

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub rbEliminarFraccion_CheckedChanged(sender As Object, e As EventArgs) Handles rbEliminarFraccion.CheckedChanged
        ActivarDesactivarFracciones()
    End Sub

    Private Sub btnFraccionEliminar_Click(sender As Object, e As EventArgs) Handles btnFraccionEliminar.Click
        Dim form As New ListaFraccionesNaveForm
        Dim Fraccion As String = String.Empty

        form.NaveID = idnave
        If form.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FraccionIDSeleccionada = form.FraccionId
            ObservacionesFraccionSeleccionada = form.Observaciones
            Fraccion = form.Fraccion
            lblFraccionElimina.Text = Fraccion
            lblObservacionElimina.Text = ObservacionesFraccionSeleccionada
            llenarComboMarcaFraccionReemplazar()
        Else
            FraccionIDSeleccionada = 0
            ObservacionesFraccionSeleccionada = String.Empty
            lblValorFraccionSeleccionada.Text = "-"
            lblValorObservacionesSeleccionada.Text = "-"
            'cmbMarcaFraccion.DataSource = Nothing
        End If
    End Sub

    Private Sub EliminarFraccion()
        Dim obj As New catalagosBU
        Dim vXmlFraccionesEliminar As XElement = New XElement("Fracciones")
        Dim vContador As Integer = 0

        Try
            For Each FilaSeleccionada As UltraGridRow In grdFracciones.Rows
                If FilaSeleccionada.Cells(" ").Value Then
                    Dim vNodo As XElement = New XElement("Fraccion")
                    vNodo.Add(New XAttribute("ProductoEstiloId", FilaSeleccionada.Cells("idEstilo").Value))
                    vXmlFraccionesEliminar.Add(vNodo)
                    vContador = vContador + 1
                End If
            Next

            If vContador = 0 Then
                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.mensaje = "Seleccione un registro"
                mensajeAdvertencia.ShowDialog()
            Else
                obj.EliminarFraccionesGlobales(vXmlFraccionesEliminar.ToString(), FraccionIDSeleccionada, idnave)
                Dim mensajeAdvertencia As New ExitoForm
                mensajeAdvertencia.mensaje = "Datos eliminados correctamente"
                mensajeAdvertencia.ShowDialog()
                '  btnLimpiarMaterialNuevo_Click(Nothing, Nothing) '21/02/2020
                btnLimpiarFracciones.PerformClick()
                '  Me.Close() '21/02/2020
            End If

        Catch ex As Exception

            Dim mensajeAdvertencia As New ErroresForm
            mensajeAdvertencia.mensaje = ex.Message
            mensajeAdvertencia.ShowDialog()

        End Try

    End Sub

    Private Sub btnEliminarMaterial_CheckedChanged(sender As Object, e As EventArgs) Handles rbEliminarMaterial.CheckedChanged

        pnlCambioMaterial.Visible = False
        pnlNuevoMaterial.Visible = False
        pnlEliminarMaterial.Visible = True
        cmbMarcaMaterialNuevo.Visible = True
        cmbColeccionMaterialNuevo.Visible = True
        btnMostrarMaterialNuevo.Visible = True
        btnLimpiarMaterialNuevo.Visible = True
    End Sub

    Private Sub btnBuscarMaterialElim_Click(sender As Object, e As EventArgs) Handles btnBuscarMaterialElim.Click
        Dim form As New listaMaterialesForm
        form.x = 2
        form.cambiosglobalesmaterial = 0
        form.nave = idnave
        form.ShowDialog()
        lblidProveedorOriginal.Text = form.idProveedor
        lblMaterialElim.Text = form.Material
        lblColeccionMaterialNuevo.Visible = True
        lblMarcaMaterialNuevo.Visible = True
        lblProveedorElim.Text = form.Provedor
        idmaterialnave = form.materialNaveid
        lblMaterialaveid.Text = form.materialNaveid
        lblMaterialaveid.Text = form.materialNaveid
        cmbMarca.SelectedValue = 0
        lblIdclass.Text = form.idClasificacion
        cmbColeccion.SelectedValue = 0
        idmaterial = form.idMaterial
        grdConsumos.DataSource = Nothing
        Try
            llenarcomboMarcaMaterialSeleccionado(cmbMarcaMaterialNuevo)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnFraccionesIncremento_Click(sender As Object, e As EventArgs) Handles btnFraccionesIncremento.Click
        Dim listado As New ListaParametrosForm
        listado.tipo_busqueda = 4
        listado.tipo_Nave = 0 'Nave NO es Maquila 

        Dim listaParametroID As New List(Of String)

        For Each row As UltraGridRow In grdFraccionesIncremento.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaPatametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        'LimpiarGridReporte()
        grdFraccionesIncremento.DataSource = listado.listaParametros
        grid_diseño(grdFraccionesIncremento)
        With grdFraccionesIncremento
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Fracciones"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With

    End Sub

    Private Sub txtPorcentajeIncremento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPorcentajeIncremento.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Solo se admite ingresar números enteros."
            mensajeAdvertencia.ShowDialog()
        End If
    End Sub

    Private Sub btnlimFracIncremento_Click(sender As Object, e As EventArgs) Handles btnlimFracIncremento.Click
        grdFraccionesIncremento.DataSource = Nothing
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With
        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next
        asignaFormato_Columna(grid)
    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("String") Then
                col.CellAppearance.TextHAlign = HAlign.Left
            End If
        Next
    End Sub

    Private Sub btnAutorizarProcentIncremento_Click(sender As Object, e As EventArgs) Handles btnAutorizarProcentIncremento.Click
        Dim obj As New ProduccionBU
        Dim listaFracciones As String = String.Empty
        Try
            Me.Cursor = Cursors.WaitCursor
            If txtPorcentajeIncremento.Text = String.Empty Then
                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.mensaje = "Ingrese la cantidad de incremento"
                mensajeAdvertencia.ShowDialog()
            Else
                listaFracciones = Filtro(grdFraccionesIncremento)
                If listaFracciones = String.Empty Then
                    Dim mensajeAdvertencia As New AdvertenciaForm
                    mensajeAdvertencia.mensaje = "Seleccione la fracción a incrementar"
                    mensajeAdvertencia.ShowDialog()
                Else
                    GuardarIncremento(listaFracciones)
                    ConsultaIstorialIncremento(idnave)
                    Dim mensajeExito As New ExitoForm
                    mensajeExito.mensaje = "Se han incrementado correctamente"
                    mensajeExito.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Error " & ex.Message
            mensajeAdvertencia.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Function Filtro(ByVal grid As UltraGrid) As String
        Dim lista As New List(Of Integer)
        For Each row As UltraGridRow In grid.Rows
            If row.Cells(" ").Value Then lista.Add(row.Cells(0).Value)
        Next
        Return String.Join(",", lista).ToString
    End Function


    Private Sub GuardarIncremento(ByVal listafracciones As String)
        Dim obj As New ProduccionBU
        Dim incremento As Double
        Dim usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        incremento = CDbl(txtPorcentajeIncremento.Text)

        obj.GuardarIncrementofracciones(listafracciones, idnave, usuario, incremento)

    End Sub

    Private Sub ConsultaIstorialIncremento(naveid)
        Dim obj As New ProduccionBU
        Dim dtHistorial As New DataTable
        dtHistorial = obj.ConsultaHistorialIncrementoFracciones(naveid)
        If dtHistorial.Rows.Count > 0 Then
            grdHistorial.DataSource = dtHistorial
            DisenioHistorial()
        End If
    End Sub

    Private Sub DisenioHistorial()
        grdVHistorial.IndicatorWidth = 30
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVHistorial.Columns
            If col.FieldName = "Fecha" Then
                col.Width = 80
            End If
            If col.FieldName = "Incremento" Then
                col.Width = 80
                col.Caption = "% Incremento"
            End If
            If col.FieldName = "Usuario" Then
                col.Width = 100
            End If
            If col.FieldName = "Fracción" Then
                col.Width = 200
            End If
            col.OptionsColumn.AllowEdit = False
        Next
        'grdVHistorial.BestFitColumns()

        Tools.DiseñoGrid.AlternarColorEnFilasTenue(grdVHistorial)
    End Sub

    Private Sub grdVHistorial_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdVHistorial.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString + 1
        End If
    End Sub

    Private Sub grdFraccionesIncremento_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFraccionesIncremento.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
End Class
