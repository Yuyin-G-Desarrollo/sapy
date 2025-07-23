Imports Tools
Imports Infragistics.Win
Imports Infragistics.Win.SupportDialogs.FilterUIProvider
Imports Infragistics.Win.UltraWinGrid

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Data


Public Class CatalogoCondicionesForm
    Public NConteo As Integer
    Dim IdTipo As Int32
    Dim NombreTipo As String
    Dim ActivoTipo As Boolean
    Dim IdCondicion As Int32
    Dim NombreCondicion As String
    Dim ActivoCondicion As Boolean
    Dim IdCondicionCatalog As Int32
    Dim DescripcionCatalogo As String
    Dim OpcionDefaltCatalogo As Boolean
    Dim ActivoCatalogo As Boolean
    Dim IdAreaOperativa As Int32
    Dim Accion As String ' Variable servira para mostrar y ocultar diferentes controles en la ventana de agregar o modificar dependiendo de lo que se modificara o dara de alta(Condicion, Tipo Condicion, Catalogo).
    Dim OpcDefault As Boolean = False

    Dim NuevaCondicion As Boolean = False
    Dim condicionGuardada As Boolean = False
    Dim areaOperativaGuardada As Boolean = False
    Private CanceloAlta As Boolean
    Public Property PCancelo As Boolean
        Get
            Return CanceloAlta
        End Get
        Set(value As Boolean)
            CanceloAlta = value
        End Set
    End Property

    Private Sub CatalogoCondicionesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        llenarListaTipo()
        Poblar_GridCatalogoCondiciones()
    End Sub

    '''<comentario> 
    ''' Realiza el llenado del grid donde se muestran los tipos de condiciones(Politicas).
    '''</comentario> 
    '''<retorno></retorno>
    Public Sub llenarListaTipo()
        grdTipoCondicion.DataSource = Nothing
        Dim objListaTipoBU As New Negocios.CatalogoCondicionesBU
        Dim ListaTipo As New DataTable
        ListaTipo = objListaTipoBU.ListaTipo
        grdTipoCondicion.DataSource = ListaTipo

        grdCatalogoCondicion.DataSource = Nothing
        grdAreaOperativa.DataSource = Nothing
        grdCondicion.DataSource = Nothing

        IdTipo = 0
        NombreTipo = ""

        IdCondicion = 0
        NombreCondicion = ""

        IdCondicionCatalog = 0
        DescripcionCatalogo = ""

        IdAreaOperativa = 0


        btnAltaCondicion.Enabled = False
        btnEditarCondicion.Enabled = False
        btnAltaCondicionCatalogo.Enabled = False
        btnEditarCondicionCatalogo.Enabled = False
        btnGuardarAreaOperativa.Enabled = False
        btnGuardarPolitica.Enabled = False
    End Sub

    '''<comentario> 
    ''' Realiza el llenado del grid donde se muestran las condiciones(Politicas).
    '''</comentario> 
    '''<retorno></retorno>
    Public Sub llenarListaCondicion()
        grdCondicion.DataSource = Nothing
        Dim objListaCondicionBU As New Negocios.CatalogoCondicionesBU
        Dim ListaCondicion As New DataTable
        ListaCondicion = objListaCondicionBU.ListaCondicion(IdTipo)
        grdCondicion.DataSource = ListaCondicion

        btnAltaCondicion.Enabled = True
        btnEditarCondicion.Enabled = True
        btnAltaCondicionCatalogo.Enabled = False
        btnEditarCondicionCatalogo.Enabled = False
        btnGuardarAreaOperativa.Enabled = True
        btnGuardarPolitica.Enabled = True

    End Sub

    '''<comentario> 
    ''' Realiza el llenado del grid donde se muestran los catalogos en los que aplican las condiciones(Politicas).
    '''</comentario> 
    '''<retorno></retorno>
    Public Sub llenarListaCatalogo(ByVal idCondi As Int32)
        grdCatalogoCondicion.DataSource = Nothing

        Dim objListaCatalogoBU As New Negocios.CatalogoCondicionesBU
        Dim ListaCatalogo As New DataTable
        ListaCatalogo = objListaCatalogoBU.ListaCatalogo(idCondi)
        grdCatalogoCondicion.DataSource = ListaCatalogo

        btnAltaCondicionCatalogo.Enabled = True
        btnEditarCondicionCatalogo.Enabled = True
        btnGuardarAreaOperativa.Enabled = True
        btnGuardarPolitica.Enabled = True
    End Sub

    '''<comentario> 
    ''' Realiza el llenado del grid donde se muestran las areas operativas en las que aplican las condciones de condiciones(Politicas).
    '''</comentario> 
    '''<retorno></retorno>
    Public Sub llenarListaAreaOperativa(ByVal idCondi As Int32)
        grdAreaOperativa.DataSource = Nothing

        Dim objListaAreaOperativaBU As New Negocios.CatalogoCondicionesBU
        Dim dtListaAreaOperativa As New DataTable
        dtListaAreaOperativa = objListaAreaOperativaBU.ListaAreasOperativas(idCondi)
        grdAreaOperativa.DataSource = dtListaAreaOperativa

        btnAltaCondicionCatalogo.Enabled = True
        btnEditarCondicionCatalogo.Enabled = True
        btnGuardarAreaOperativa.Enabled = True
        btnGuardarPolitica.Enabled = True
    End Sub


    Private Sub grdTipoCondicion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdTipoCondicion.InitializeLayout
        With grdTipoCondicion
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns 'Ajusta todas las columnas a un tamaño igual.
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        End With
    End Sub

    Private Sub grdTipoCondicion_ClickCell_1(sender As Object, e As ClickCellEventArgs) Handles grdTipoCondicion.ClickCell
        Dim row As UltraGridRow = grdTipoCondicion.ActiveRow
        If row.IsFilterRow Then Return
        IdTipo = CInt(row.Cells("Id").Text)
        NombreTipo = CStr(row.Cells("Tipo").Text)
        ActivoTipo = CBool(row.Cells("Activo").Value)

        llenarListaCondicion()

        IdCondicion = 0
        IdCondicionCatalog = 0
        IdAreaOperativa = 0

        grdCatalogoCondicion.DataSource = Nothing
        grdAreaOperativa.DataSource = Nothing
    End Sub

    Private Sub grdTipoCondicion_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdTipoCondicion.BeforeRowsDeleted
        e.Cancel = True
    End Sub



    Private Sub grdCondicion_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles grdCondicion.InitializeLayout
        With grdCondicion
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns 'Ajusta todas las columnas a un tamaño igual.
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        End With
    End Sub

    Private Sub grdCondicion_ClickCell_1(sender As Object, e As ClickCellEventArgs) Handles grdCondicion.ClickCell

        Dim row As UltraGridRow = grdCondicion.ActiveRow
        If row.IsFilterRow Then Return
        IdCondicion = CInt(row.Cells("Id").Text)
        NombreCondicion = CStr(row.Cells("Nombre").Text)
        ActivoCondicion = CBool(row.Cells("Activo").Value)


        llenarListaCatalogo(IdCondicion)
        llenarListaAreaOperativa(IdCondicion)

        IdCondicionCatalog = 0
        IdAreaOperativa = 0

        btnGuardarPolitica.Enabled = True
        btnGuardarAreaOperativa.Enabled = True
    End Sub

    Private Sub grdCondicion_BeforeRowsDeleted_1(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdCondicion.BeforeRowsDeleted
        e.Cancel = True
    End Sub



    Private Sub grdCatalogoCondicion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCatalogoCondicion.InitializeLayout
        With grdCatalogoCondicion

            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            .DisplayLayout.Bands(0).Columns("Id").Hidden = True
            .DisplayLayout.Bands(0).Columns("Id").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Descripción").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Opción_Default").Style = ColumnStyle.CheckBox
            .DisplayLayout.Bands(0).Columns("Opción_Default").CellActivation = Activation.AllowEdit
            .DisplayLayout.Bands(0).Columns("Activo").CellActivation = Activation.NoEdit

        End With
    End Sub

    Private Sub grdCatalogoCondicion_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdCatalogoCondicion.ClickCell

        Dim row As UltraGridRow = grdCatalogoCondicion.ActiveRow
        If row.IsFilterRow Then Return

        IdCondicionCatalog = CInt(row.Cells("Id").Text)
        DescripcionCatalogo = CStr(row.Cells("Descripción").Text)
        OpcionDefaltCatalogo = CBool(row.Cells("Opción_Default").Value)
        ActivoCatalogo = CBool(row.Cells("Activo").Value)

    End Sub

    Private Sub grdCatalogoCondicion_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdCatalogoCondicion.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdCatalogoCondicion_CellChange(sender As Object, e As CellEventArgs) Handles grdCatalogoCondicion.CellChange
        If (e.Cell.Column.Key = "Opción_Default") Then
            For Each rowP As UltraGridRow In grdCatalogoCondicion.Rows
                rowP.Cells("Opción_Default").Value = False
            Next
            e.Cell().Value = True
        End If
    End Sub



    Private Sub grdAreaOperativa_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAreaOperativa.InitializeLayout
        With grdAreaOperativa
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            .DisplayLayout.Bands(0).Columns("Id").Hidden = True
            .DisplayLayout.Bands(0).Columns("Id").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Área Operativa").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Área Operativa").Width = 200
            .DisplayLayout.Bands(0).Columns("Activo").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Activo").Width = 50
            .DisplayLayout.Bands(0).Columns("Controla?").Style = ColumnStyle.CheckBox
            .DisplayLayout.Bands(0).Columns("Controla?").Width = 60
            .DisplayLayout.Bands(0).Columns("Controla?").CellActivation = Activation.AllowEdit
            .DisplayLayout.Bands(0).Columns(" ").Style = ColumnStyle.CheckBox
            .DisplayLayout.Bands(0).Columns(" ").Width = 15
            .DisplayLayout.Bands(0).Columns(" ").CellActivation = Activation.AllowEdit
        End With
    End Sub

    Private Sub grdAreaOperativa_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdAreaOperativa.ClickCell
        Dim row As UltraGridRow = grdAreaOperativa.ActiveRow
        If row.IsFilterRow Then Return
        IdAreaOperativa = CInt(row.Cells("Id").Text)
    End Sub

    Private Sub grdAreaOperativa_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdAreaOperativa.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdAreaOperativa_CellChange(sender As Object, e As CellEventArgs) Handles grdAreaOperativa.CellChange
        If (e.Cell.Column.Key = "Controla?") Then
            For Each rowP As UltraGridRow In grdAreaOperativa.Rows
                rowP.Cells("Controla?").Value = False
            Next
            e.Cell().Value = True
            For Each rowAO As UltraGridRow In grdAreaOperativa.Rows
                If CBool(rowAO.Cells("Controla?").Value) = True Then
                    rowAO.Cells(" ").Value = True
                End If
            Next
        End If
        If (e.Cell.Column.Key = " ") Then
            For Each rowAO As UltraGridRow In grdAreaOperativa.Rows
                If CBool(rowAO.Cells(" ").Value) = False Then
                    rowAO.Cells("Controla?").Value = False
                End If
            Next
        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grpParametros.Height = 43
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grpParametros.Height = 285
    End Sub

    Private Sub btnAltaTipo_Click(sender As Object, e As EventArgs) Handles btnAltaTipo.Click
        Accion = "Tipo"
        Dim formaTipo As New AgregarEditarCondicionesForm
        formaTipo.accion = Accion
        formaTipo.AgregarOEditar = True
        formaTipo.StartPosition = FormStartPosition.CenterScreen
        formaTipo.ShowDialog()
        llenarListaTipo()
        llenarListaCondicion()
        Poblar_GridCatalogoCondiciones()
    End Sub

    Private Sub btnAltaCondicion_Click(sender As Object, e As EventArgs) Handles btnAltaCondicion.Click
        Accion = "Condicion"

        Dim FormaCondcion As New AgregarEditarCondicionesForm
        FormaCondcion.accion = Accion
        FormaCondcion.AgregarOEditar = True
        FormaCondcion.IdTipo = IdTipo
        FormaCondcion.NombreTipo = NombreTipo
        FormaCondcion.StartPosition = FormStartPosition.CenterScreen
        FormaCondcion.ShowDialog()
        CanceloAlta = FormaCondcion.PSalio
        FormaCondcion.Dispose()
        IdCondicion = 0

        If CanceloAlta = False Then
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Traer mediante una consulta el id y nombre de la nueva condicion que se dio de alta
            Dim objRCondicionBU As New Negocios.CatalogoCondicionesBU
            Dim RecuperarCondicion As New Entidades.CatalogoCondicionesCondicion
            RecuperarCondicion = objRCondicionBU.RecuperarCondicion()

            'Damos de alta una descripcion en el catalogo de condiciones a la nueva condicion creada


            Dim FormaCatalogo As New AgregarEditarCondicionesForm
            With FormaCatalogo
                .accion = "Catalogo"
                .NombreCondicion = RecuperarCondicion.PNombre
                .NombreTipo = NombreTipo
                .IdTipo = IdTipo
                .AgregarOEditar = True
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            End With

            IdCondicion = RecuperarCondicion.PIdCondicion
            NombreCondicion = RecuperarCondicion.PNombre

            'llenamos los grids
            llenarListaCondicion()
            SeleccionarFilaCondicion(IdCondicion)
            llenarListaCatalogo(IdCondicion)
            llenarListaAreaOperativa(IdCondicion)

            Poblar_GridCatalogoCondiciones()
            Me.grdTipoCondicion.Enabled = False
            Me.btnAltaTipo.Enabled = False
            Me.btnEditarTipo.Enabled = False
            buscarCondicion(IdCondicion.ToString)
            Me.grdCondicion.Enabled = False
            Me.btnAltaCondicion.Enabled = False
            Me.btnEditarCondicion.Enabled = False
            Me.btnCancelar.Enabled = False
            Me.btnGuardarPolitica.Enabled = True
            buscarCatalogo(IdCondicionCatalog.ToString)
            Me.ControlBox = False

            NuevaCondicion = True

            SeleccionarFilaCondicion(IdCondicion)


            Dim FormularioAviso As New AvisoForm
            FormularioAviso.mensaje = "Guarda una opción por default en la sección de '3. Catálogo de la Política' y asígnale un Área Operativa para poder continuar usando la aplicación."
            FormularioAviso.StartPosition = FormStartPosition.CenterScreen
            FormularioAviso.ShowDialog()
        End If

    End Sub

    Public Sub buscarCondicion(ByVal IdCondicion As String)
        Dim contGrid As Int32 = 0
        For Each rowData As UltraGridRow In grdCondicion.Rows
            If (rowData.Cells(0) Is IdCondicion) Then
                grdCondicion.Rows(contGrid).Selected = True
            End If
            contGrid = contGrid + 1
        Next
    End Sub

    Public Sub buscarCatalogo(ByVal IdCatalogo As String)
        Dim contGrid As Int32 = 0
        For Each rowData As UltraGridRow In grdCatalogoCondicion.Rows
            If (rowData.Cells(0) Is IdCatalogo) Then
                grdCatalogoCondicion.Rows(contGrid).Selected = True
            End If
            contGrid = contGrid + 1
        Next
    End Sub

    Private Sub btnAltaCondicionCatalogo_Click(sender As Object, e As EventArgs) Handles btnAltaCondicionCatalogo.Click
        Accion = "Catalogo"
        Dim formaTipo As New AgregarEditarCondicionesForm
        formaTipo.accion = Accion
        formaTipo.AgregarOEditar = True
        formaTipo.IdTipo = IdTipo
        formaTipo.IdCondicion = IdCondicion
        formaTipo.NombreCondicion = NombreCondicion
        formaTipo.NombreTipo = NombreTipo
        formaTipo.StartPosition = FormStartPosition.CenterScreen
        formaTipo.ShowDialog()
        llenarListaCatalogo(IdCondicion)
        Me.btnGuardarPolitica.Enabled = True
        Poblar_GridCatalogoCondiciones()

        Dim objRCatalogo As New Negocios.CatalogoCondicionesBU
        Dim RecuperarCatalogo As New Entidades.CatalogoCondicionesCatalogo
        RecuperarCatalogo = objRCatalogo.RecuperarCatalogo()
        IdCondicionCatalog = RecuperarCatalogo.PIdCatalogo
        DescripcionCatalogo = RecuperarCatalogo.PDescripcion
        ActivoCatalogo = RecuperarCatalogo.PActivo

        SeleccionarCatalogoPolitica(IdCondicionCatalog)
    End Sub

    Private Sub btnEditarTipo_Click(sender As Object, e As EventArgs) Handles btnEditarTipo.Click
        If IdTipo = 0 Then
            Dim FormularioError As New AdvertenciaForm
            FormularioError.mensaje = "Selecciona los datos que deseas modificar antes de presionar el botón 'Editar'"
            FormularioError.StartPosition = FormStartPosition.CenterScreen
            FormularioError.ShowDialog()
        Else
            Accion = "Tipo"
            Dim formaTipo As New AgregarEditarCondicionesForm
            formaTipo.accion = Accion
            formaTipo.AgregarOEditar = False
            formaTipo.IdTipo = IdTipo
            formaTipo.NombreTipo = NombreTipo
            formaTipo.ActivoTipo = ActivoTipo
            formaTipo.StartPosition = FormStartPosition.CenterScreen
            formaTipo.ShowDialog()
            llenarListaTipo()
        End If
        IdTipo = 0
        NombreTipo = ""

        Poblar_GridCatalogoCondiciones()
    End Sub

    Private Sub btnEditarCondicion_Click(sender As Object, e As EventArgs) Handles btnEditarCondicion.Click
        If IdCondicion = 0 Then
            Dim FormularioError As New AdvertenciaForm
            FormularioError.mensaje = "Selecciona los datos que deseas modificar antes de presionar el botón 'Editar'"
            FormularioError.StartPosition = FormStartPosition.CenterScreen
            FormularioError.ShowDialog()
        Else
            Accion = "Condicion"
            Dim formaCondicion As New AgregarEditarCondicionesForm
            formaCondicion.accion = Accion
            formaCondicion.AgregarOEditar = False
            formaCondicion.IdCondicion = IdCondicion
            formaCondicion.NombreTipo = NombreTipo
            formaCondicion.NombreCondicion = NombreCondicion
            formaCondicion.IdTipo = IdTipo
            formaCondicion.ActivoCondicion = ActivoCondicion
            formaCondicion.StartPosition = FormStartPosition.CenterScreen
            formaCondicion.ShowDialog()

            IdTipo = formaCondicion.IdTipo
            IdCondicion = formaCondicion.IdCondicion
            formaCondicion.Dispose()

            SeleccionarTipo(IdTipo)
            llenarListaCondicion()
            SeleccionarFilaCondicion(IdCondicion)


            btnAltaCondicionCatalogo.Enabled = True
            btnEditarCondicionCatalogo.Enabled = True

        End If
        Poblar_GridCatalogoCondiciones()
        poblarcombos()

    End Sub

    Private Sub btnEditarCondicionCatalogo_Click(sender As Object, e As EventArgs) Handles btnEditarCondicionCatalogo.Click
        If IdCondicionCatalog = 0 Then
            Dim FormularioError As New AdvertenciaForm
            FormularioError.mensaje = "Selecciona los datos que deseas modificar antes de presionar el botón 'Editar'"
            FormularioError.StartPosition = FormStartPosition.CenterScreen
            FormularioError.ShowDialog()
        Else
            Accion = "Catalogo"
            Dim formaCatalogo As New AgregarEditarCondicionesForm
            formaCatalogo.accion = Accion
            formaCatalogo.AgregarOEditar = False
            formaCatalogo.IdTipo = IdTipo
            formaCatalogo.NombreTipo = NombreTipo
            formaCatalogo.NombreCondicion = NombreCondicion
            formaCatalogo.IdCatalogo = IdCondicionCatalog
            formaCatalogo.DescripcionCatalogo = DescripcionCatalogo
            formaCatalogo.IdCondicion = IdCondicion
            formaCatalogo.ActivoCatalogo = ActivoCatalogo
            formaCatalogo.OpDefault = OpcionDefaltCatalogo
            formaCatalogo.StartPosition = FormStartPosition.CenterScreen
            formaCatalogo.ShowDialog()

            IdTipo = formaCatalogo.IdTipo
            IdCondicion = formaCatalogo.IdCondicion
            formaCatalogo.Dispose()

            SeleccionarTipo(IdTipo)
            llenarListaCondicion()
            SeleccionarFilaCondicion(IdCondicion)

        End If
        llenarListaCatalogo(IdCondicion)
        Poblar_GridCatalogoCondiciones()
        Me.btnGuardarPolitica.Enabled = True

    End Sub



    ''Grid Lista general del catalogo Condiciones 
    Public Sub Poblar_GridCatalogoCondiciones()
        grdListaCatalogoCondiciones.DataSource = Nothing
        Dim CondicionesBU As New Negocios.CatalogoCondicionesBU
        Dim CatalogoCondiciones As New DataTable
        Dim TipoCondicionCatCon As New DataTable
        Dim CondcioncionCatCon As New DataTable
        Dim CatalogoCatCon As New DataTable
        Dim AreaoOperativaCatCon As New DataTable

        Dim VlTipo As New ValueList
        Dim VlCondicion As New ValueList
        Dim vlCatalogo As New ValueList
        Dim vlAreaoperativas As New ValueList

        CatalogoCondiciones = CondicionesBU.ListaCatalogoCondiciones

        With grdListaCatalogoCondiciones
            .DataSource = CatalogoCondiciones
        End With
        GRdListaCatalogoDesign(grdListaCatalogoCondiciones)
        poblarcombos()
    End Sub

    Public Sub poblarcombos()
        Dim nfilas As Integer = 0
        For Each fila1 As UltraGridRow In grdListaCatalogoCondiciones.Rows

            If fila1.Cells("Id_Política").Text <> "" Then
                fila1.Cells("Id_Política").Activation = Activation.NoEdit

                Dim objBU As New Negocios.CatalogoCondicionesBU
                Dim CatalogoCatCon As New DataTable
                Dim AreaoOperativaCatCon As New DataTable
                Dim vlCatalogo As New Infragistics.Win.ValueList
                Dim vlAreaoperativas As New Infragistics.Win.ValueList
                Dim IdCondicionGrid As Integer


                Dim s As String = fila1.Cells("Id_Política").Text

                IdCondicionGrid = CInt(s)

                CatalogoCatCon = objBU.ListaCatalogo(IdCondicionGrid)
                For Each fila As DataRow In CatalogoCatCon.Rows
                    vlCatalogo.ValueListItems.Add(fila.Item("Id"), CStr(fila.Item("Descripción")))
                    nfilas = nfilas + 1
                Next

                AreaoOperativaCatCon = objBU.ListaAreasOperativasConsulta(IdCondicionGrid)
                For Each fila As DataRow In AreaoOperativaCatCon.Rows
                    vlAreaoperativas.ValueListItems.Add(fila.Item("id"), CStr(fila.Item("Área_operativa")))
                Next

                fila1.Cells("Catalogo").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
                fila1.Cells("Catalogo").ValueList = vlCatalogo
                fila1.Cells("Área_Operativa").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
                fila1.Cells("Área_Operativa").ValueList = vlAreaoperativas
            End If
        Next

    End Sub

    Public Sub GRdListaCatalogoDesign(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        With grid
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            .DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .DisplayLayout.Bands(0).Columns("Id").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Tipo").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Política").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Activo").CellActivation = Activation.AllowEdit
            .DisplayLayout.Bands(0).Columns("Id").Hidden = True
            .DisplayLayout.Bands(0).Columns("Id_Política").Hidden = True
            .DisplayLayout.Bands(0).Columns("IdCatalogo").Hidden = True
        End With
    End Sub

    Private Sub grdListaCatalogoCondiciones_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListaCatalogoCondiciones.BeforeRowsDeleted
        e.Cancel = True
    End Sub


    Private Sub btnGuardarPolitica_Click(sender As Object, e As EventArgs) Handles btnGuardarPolitica.Click
        condicionGuardada = True
        condicionGuardada = True  ' esta variable nos permitira cargar el formulario de nuevo cuando el usuario ya haya guardado el area operativa y asignado la nueva politica a todos los clientes

        'primero guardamos el activo, y verificamos que no deje nunguno como null
        If ValidarDefaultSeleccionado() = False Then
            Dim FormularioError As New ErroresForm
            FormularioError.mensaje = "Selecciona una opción por default para poder guardar."
            FormularioError.StartPosition = FormStartPosition.CenterScreen
            FormularioError.ShowDialog()
        ElseIf ValidarDefaultActivo() = False Then
            Dim FormularioError As New ErroresForm
            FormularioError.mensaje = "La opción por default debe ser seleccionada en un campo activo."
            FormularioError.StartPosition = FormStartPosition.CenterScreen
            FormularioError.ShowDialog()
        Else
            Dim editarCatalogo As New Entidades.CatalogoCondicionesCatalogo
            For Each rowA As UltraGridRow In grdCatalogoCondicion.Rows
                editarCatalogo.PIdCatalogo = CInt(rowA.Cells("Id").Value)
                editarCatalogo.PDescripcion = CStr(rowA.Cells("Descripción").Value)
                editarCatalogo.PIdCondicion = IdCondicion
                editarCatalogo.PActivo = CBool(rowA.Cells("Activo").Value)
                editarCatalogo.POpcionDefault = CBool(rowA.Cells("Opción_Default").Value)
                Dim objEditarCatalogo As New Negocios.CatalogoCondicionesBU
                objEditarCatalogo.editarCatalogo(editarCatalogo)
            Next
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Registro Actualizado"
            FormaExito.StartPosition = FormStartPosition.CenterScreen
            FormaExito.ShowDialog()
            llenarListaCatalogo(IdCondicion)
            btnAltaCondicionCatalogo.Enabled = True
            btnAltaCondicionCatalogo.Enabled = True


            ValidarCondicionNoAsignada()

            'Si se agregó una nueva condicion entonces la asignamos a todos los clientes
            If NuevaCondicion = True Or NConteo = 0 Then
                Dim objCondicionesBU As New Negocios.CatalogoCondicionesBU
                objCondicionesBU.AltaCondicionAClientes(IdCondicionCatalog)

                FormaExito.mensaje = "Se asignó la nueva condicion a todos los clientes"
                FormaExito.StartPosition = FormStartPosition.CenterScreen
                FormaExito.ShowDialog()
                NuevaCondicion = False
            End If

            Me.ControlBox = True
            NuevaCondicion = False
            If condicionGuardada And areaOperativaGuardada = True Then
                Me.ControlBox = True
                NuevaCondicion = False
                condicionGuardada = False
                areaOperativaGuardada = False
                grdTipoCondicion.Enabled = True
                grdCondicion.Enabled = True
                btnAltaCondicion.Enabled = True
                btnAltaTipo.Enabled = True
                btnEditarCondicion.Enabled = True
                btnEditarTipo.Enabled = True
                btnCancelar.Enabled = True
            End If
        End If

        Poblar_GridCatalogoCondiciones()

    End Sub


    Private Sub btnGuardarAreaOperativa_Click(sender As Object, e As EventArgs) Handles btnGuardarAreaOperativa.Click
        areaOperativaGuardada = True
        Dim objCatalogoCondicionsBU As New Negocios.CatalogoCondicionesBU
        If ValidarAreaOperativaSeleccionada() = False Then
            Dim FormularioError As New AdvertenciaForm
            FormularioError.mensaje = "Selecciona un Área Operativa para poder guardar."
            FormularioError.StartPosition = FormStartPosition.CenterScreen
            FormularioError.ShowDialog()
        ElseIf ValidarAreaOpControla() = False Then
            Dim FormularioError As New AdvertenciaForm
            FormularioError.mensaje = "Selecciona un Área Operativa que controla la política para poder guardar."
            FormularioError.StartPosition = FormStartPosition.CenterScreen
            FormularioError.ShowDialog()
        ElseIf ValidarControlaSeleccionado() = False Then
            Dim FormularioError As New AdvertenciaForm
            FormularioError.mensaje = "El Área Operativa que controlara la política debe estar seleccionada en la primer columna."
            FormularioError.StartPosition = FormStartPosition.CenterScreen
            FormularioError.ShowDialog()
        Else
            Dim AreaOperativa As New Entidades.CatalogoCondicionesAreaOperativa
            For Each rowAO As UltraGridRow In grdAreaOperativa.Rows
                AreaOperativa.PIdArea = CInt(rowAO.Cells("Id").Value)
                AreaOperativa.PArea = CStr(rowAO.Cells("Área Operativa").Value)
                AreaOperativa.PActivo = CBool(rowAO.Cells(" ").Value)
                AreaOperativa.PControla = CBool(rowAO.Cells("Controla?").Value)
                AreaOperativa.PIdCondicion = IdCondicion

                Dim objAreaOperativaBU As New Negocios.CatalogoCondicionesBU
                objAreaOperativaBU.ActualizarCondicionAreaOperativa(AreaOperativa)
            Next
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Registro Actualizado"
            FormaExito.StartPosition = FormStartPosition.CenterScreen
            FormaExito.ShowDialog()
            llenarListaAreaOperativa(IdCondicion)

            If condicionGuardada = True And areaOperativaGuardada = True Then
                Me.ControlBox = True
                NuevaCondicion = False
                condicionGuardada = False
                areaOperativaGuardada = False
                grdTipoCondicion.Enabled = True
                grdCondicion.Enabled = True
                btnAltaCondicion.Enabled = True
                btnAltaTipo.Enabled = True
                btnEditarCondicion.Enabled = True
                btnEditarTipo.Enabled = True
                btnCancelar.Enabled = True
            End If

        End If

        Poblar_GridCatalogoCondiciones()

    End Sub

    ''' <summary>
    ''' VALIDA QUE EN EL GRID GRDCATALOGOCONDICION SE HAYA SELECCIONADO AL MENOS UN VALOR POR DEFAULT
    ''' </summary>
    ''' <returns>VALOR TRUE Ó FALSE</returns>
    ''' <remarks></remarks>
    Public Function ValidarDefaultSeleccionado() As Boolean
        Dim ContDescripciones As Int32 = 0
        Dim recorre As Int32 = 0
        For Each rowP As UltraGridRow In grdCatalogoCondicion.Rows
            If (rowP.Cells("Id").Value IsNot Nothing) Then
                If (CBool(rowP.Cells("Opción_Default").Value.ToString) = True) Then
                    ContDescripciones = ContDescripciones + 1
                End If
            End If
        Next
        If (ContDescripciones = 0) Then
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' VALIDA QUE EN EL GRID GRDCATALOGOCONDICION SE HAYA SELECCIONADO EL VALOR POR DEFAULT EN UNA OPCION ACTIVA.
    ''' </summary>
    ''' <returns>VALOR TRUE Ó FALSE</returns>
    ''' <remarks></remarks>
    Public Function ValidarDefaultActivo() As Boolean
        Dim ContDescripciones As Int32 = 0
        Dim recorre As Int32 = 0
        For Each rowP As UltraGridRow In grdCatalogoCondicion.Rows
            If (rowP.Cells("Id").Value IsNot Nothing) Then
                If (CBool(rowP.Cells("Opción_Default").Value.ToString) = True) And (CBool(rowP.Cells("Activo").Value.ToString) = True) Then
                    IdCondicionCatalog = CInt(rowP.Cells("Id").Value.ToString)
                    ContDescripciones = ContDescripciones + 1
                End If
            End If
        Next
        If (ContDescripciones = 0) Then
            Return False
        End If
        Return True
    End Function


    ''' <summary>
    ''' VALIDA QUE SE HAYA SELECCIONADO POR LO MENOS UN AREA OPERATIVA EN EL GRID DE AREAS OPERATIVAS
    ''' </summary>
    ''' <returns>VALOR BOOLEAN TRUE Ó FALSE</returns>
    ''' <remarks></remarks>
    Public Function ValidarAreaOperativaSeleccionada() As Boolean
        Dim ContDescripciones As Int32 = 0
        Dim recorre As Int32 = 0
        For Each rowP As UltraGridRow In grdAreaOperativa.Rows
            If (rowP.Cells(0).Value IsNot Nothing) Then
                If (CBool(rowP.Cells(" ").Value.ToString) = True) Then
                    ContDescripciones = ContDescripciones + 1
                End If
            End If
        Next
        If (ContDescripciones = 0) Then
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' VALIDA QUE SE SELECCIONE UN AREA OPERATIVA QUE CONTROLA LA CONDICION.
    ''' </summary>
    ''' <returns>VALOR BOOLEAN</returns>
    ''' <remarks></remarks>
    Public Function ValidarAreaOpControla() As Boolean
        Dim ContDescripciones As Int32 = 0
        Dim recorre As Int32 = 0
        For Each rowP As UltraGridRow In grdAreaOperativa.Rows
            If (rowP.Cells(0).Value IsNot Nothing) Then
                If (CBool(rowP.Cells("Controla?").Value.ToString) = True) Then
                    ContDescripciones = ContDescripciones + 1
                End If
            End If
        Next
        If (ContDescripciones = 0) Then
            Return False
        End If
        Return True
    End Function


    ''' <summary>
    ''' VALIDA QUE EN el ÁREA OPERATIVA A SELECCIONAR COMO CONTROLA ESTE SELECCIONADA EN LA PRIMER COLUMNA PARA A ASIGNARLA A LA POLITICA.
    ''' </summary>
    ''' <returns>VALOR TRUE Ó FALSE</returns>
    ''' <remarks></remarks>
    Public Function ValidarControlaSeleccionado() As Boolean
        Dim ContDescripciones As Int32 = 0
        Dim recorre As Int32 = 0
        For Each rowP As UltraGridRow In grdAreaOperativa.Rows
            If (rowP.Cells("Id").Value IsNot Nothing) Then
                If (CBool(rowP.Cells(" ").Value.ToString) = True) And (CBool(rowP.Cells("Controla?").Value.ToString) = True) Then
                    IdCondicionCatalog = CInt(rowP.Cells("Id").Value.ToString)
                    ContDescripciones = ContDescripciones + 1
                End If
            End If
        Next
        If (ContDescripciones = 0) Then
            Return False
        End If
        Return True
    End Function



    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub




    ''' <summary>
    ''' SELECCIONA LA FILA DE LA ULTIMA CONDICION AGREGADA
    ''' </summary>
    ''' <param name="IdCondicion">ID DE LA CONDICION A BUSCAR</param>
    ''' <remarks></remarks>
    Public Sub SeleccionarFilaCondicion(ByVal IdCondicion As Integer)
        Dim ContDescripciones As Int32 = 0
        Dim recorre As Int32 = 0
        For Each rowP As UltraGridRow In grdCondicion.Rows
            If (CStr(rowP.Cells("Id").Value)) = IdCondicion.ToString Then
                rowP.Selected = True
                IdCondicion = CInt(rowP.Cells("Id").Text)
                NombreCondicion = CStr(rowP.Cells("Nombre").Text)
                ActivoCondicion = CBool(rowP.Cells("Activo").Value)
            End If
        Next
    End Sub

    ''' <summary>
    ''' SELECCIONA LA FILA DEL ULTIMO REGISTRO CONDICIONESCATALOGO QUE SE AGREGO
    ''' </summary>
    ''' <param name="IdCatalogo">ID DEL CATALOGO</param>
    ''' <remarks></remarks>
    Public Sub SeleccionarCatalogoPolitica(ByVal IdCatalogo As Integer)
        Dim ContDescripciones As Int32 = 0
        Dim recorre As Int32 = 0
        For Each rowP As UltraGridRow In grdCatalogoCondicion.Rows
            If (CStr(rowP.Cells("Id").Value)) = IdCatalogo.ToString Then
                rowP.Selected = True
            End If
        Next
    End Sub

    ''' <summary>
    ''' SELECCIONA LA FILA DEL TIPO DE CONDICION CON EL QUE SE ESTA TRABAJANDO
    ''' </summary>
    ''' <param name="IdTipo">ID DEL TIPO DE CONDICION</param>
    ''' <remarks></remarks>
    Public Sub SeleccionarTipo(ByVal IdTipo As Integer)
        Dim ContDescripciones As Int32 = 0
        Dim recorre As Int32 = 0
        For Each rowP As UltraGridRow In grdTipoCondicion.Rows
            If (CStr(rowP.Cells("Id").Value)) = IdTipo.ToString Then
                rowP.Selected = True
                IdTipo = CInt(rowP.Cells("Id").Text)
                NombreTipo = CStr(rowP.Cells("Tipo").Text)
                ActivoTipo = CBool(rowP.Cells("Activo").Value)
            Else
                rowP.Selected = False
            End If
        Next
    End Sub

    Private Sub grdListaCatalogoCondiciones_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdListaCatalogoCondiciones.AfterCellUpdate
        Dim row As UltraGridRow = grdListaCatalogoCondiciones.ActiveRow
        If row.Cells("Activo").IsActiveCell Then
            If MessageBox.Show("¿Esta seguro que desea activar/desactivar esta política?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor

                Dim ContCondicion As Int32 = 0
                Dim recorre As Int32 = 0
                Dim rowP As UltraGridRow = grdListaCatalogoCondiciones.ActiveRow
                IdCondicionCatalog = CInt(rowP.Cells("IdCatalogo").Value.ToString)

                Dim editarCondicion As New Entidades.CatalogoCondicionesCondicion
                editarCondicion.PNombre = CStr(rowP.Cells("Política").Value.ToString)
                editarCondicion.PIdTipo = CInt(rowP.Cells("Id").Value.ToString)
                editarCondicion.PActivo = CBool(rowP.Cells("Activo").Value.ToString)
                editarCondicion.PIdCondicion = CInt(rowP.Cells("Id_Política").Value.ToString)

                Dim objEditarCondicionBU As New Negocios.CatalogoCondicionesBU
                objEditarCondicionBU.editarCondicion(editarCondicion)
                Dim FormaExito As New ExitoForm
               

                Dim objCondicionesBU As New Negocios.CatalogoCondicionesBU
                objCondicionesBU.ActualizarCondicionClientes(IdCondicionCatalog, editarCondicion.PActivo)

                FormaExito.mensaje = "Política ha sido actualizada para los clientes."
                FormaExito.StartPosition = FormStartPosition.CenterScreen
                FormaExito.ShowDialog()
                Me.Cursor = Cursors.Default
                Poblar_GridCatalogoCondiciones()

            Else
                Poblar_GridCatalogoCondiciones()
            End If
        End If
    End Sub


    Public Sub ValidarCondicionNoAsignada()
        NConteo = 0
        Dim objCondicionBU As New Negocios.CondicionesBU
        Dim tabla As New DataTable
        For Each row As UltraGridRow In grdCatalogoCondicion.Rows
            If row.IsFilterRow Then Return
            IdCondicionCatalog = CInt(row.Cells("Id").Text)
            ContarReg()
            NConteo = NConteo + NConteo
        Next
    End Sub

    Public Sub ContarReg()
        Dim conteo As New DataTable
        'If lAgente = String.Empty Then Return
        'Dim NombreAgente As New List(Of Entidades.Colaborador)
        Dim objConteo As New Negocios.CatalogoCondicionesBU
        conteo = objConteo.ConteoCatalogoClientes(IdCondicionCatalog)
        For Each row As DataRow In conteo.Rows
            NConteo = NConteo + CInt(row("Existe"))
        Next
    End Sub

End Class