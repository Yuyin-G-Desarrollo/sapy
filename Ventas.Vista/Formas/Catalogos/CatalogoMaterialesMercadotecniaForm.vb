Imports Tools

Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class CatalogoMaterialesMercadotecniaForm

    ''VARIABLES PARA LA SELECCION Y EDICION Y ENVIARLE VALORES A EL FORMULARIO DE ALTA Y CAMBIOS
    Dim altasCambios As Boolean
    Dim seleccion As Int32
    Dim idTipo As Int32
    Dim tipo As String
    Dim material As String
    Dim activo As Boolean


    ''Botones arriba y abajo
    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbMaterialesMercadotecnia.Height = 39

    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbMaterialesMercadotecnia.Height = 135

    End Sub

    ''boton buscar para realizar la busqueda

    Public Sub llenarTablaMaterialesMercadotecnia()
        ''Limpiar los datos de la tabla cada vez que presione el boton de buscar y borrar los valores de las variables.
        gridListaMaterialesMercadotecnia.DataSource = Nothing
        idTipo = 0
        seleccion = 0
        tipo = ""
        material = ""

        ''Declaracion del objeto para llamar los metodos de la capa de negocios.
        Dim objBU As New Negocios.CatalogoMaterialesMercadotecniaBU

        Dim tablaMateriales As New DataTable



        ''Asignación de valores a las variables.
        material = txtNombreDelMaterial.Text
        tipo = cboMaterialesMercadotecniaTipo.Text


        If rdoSi.Checked = True Then
            activo = True
        Else
            activo = False
        End If

        tablaMateriales = objBU.ListaMateriales(activo, material, tipo)

        ''Envíamos los datos al metodo de llenar Grid.
        gridListaMaterialesMercadotecnia.DataSource = tablaMateriales
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        llenarTablaMaterialesMercadotecnia()
        seleccion = 0
        idTipo = 0

    End Sub

    ''Darle formato al grid
    Private Sub gridListaMaterialesMercadotecnia_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridListaMaterialesMercadotecnia.InitializeLayout
        With gridListaMaterialesMercadotecnia

            ''Ocultar la primera columna que sera la del Id de tipo
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True

            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        End With
    End Sub

    ''configuracion del botón agregar
    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        altasCambios = True
        Dim formaMaterialesMercadotecnia As New AgregarEditarMaterialesForm
        formaMaterialesMercadotecnia.idMaterial = seleccion
        formaMaterialesMercadotecnia.idTipo = idTipo
        formaMaterialesMercadotecnia.estado = altasCambios
        formaMaterialesMercadotecnia.tipo = tipo
        formaMaterialesMercadotecnia.activo = activo
        formaMaterialesMercadotecnia.material = material
        formaMaterialesMercadotecnia.ShowDialog()
        llenarTablaMaterialesMercadotecnia()

    End Sub

    ''configuracion del botón modificar
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

        If seleccion = 0 And material = "" And tipo = "" Then
            Dim FormularioError As New ErroresForm
            FormularioError.mensaje = "Realiza una consulta y selecciona la fila que contenga los datos que deseas modificar antes de dar click en el botón 'Editar'!"
            FormularioError.ShowDialog()
        Else
            altasCambios = False
            Dim formaMaterialesMercadotecnia As New AgregarEditarMaterialesForm

            formaMaterialesMercadotecnia.idMaterial = seleccion
            formaMaterialesMercadotecnia.idTipo = idTipo
            formaMaterialesMercadotecnia.estado = altasCambios
            formaMaterialesMercadotecnia.tipo = tipo
            formaMaterialesMercadotecnia.activo = activo
            formaMaterialesMercadotecnia.material = material
            formaMaterialesMercadotecnia.ShowDialog()
            llenarTablaMaterialesMercadotecnia()
        End If

    End Sub



    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        gridListaMaterialesMercadotecnia.DataSource = Nothing
        txtNombreDelMaterial.Text = ""
        ComboTipoMateriales(cboMaterialesMercadotecniaTipo)
        seleccion = 0
        material = ""
        tipo = ""


    End Sub


    Private Sub gridListaMaterialesMercadotecnia_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridListaMaterialesMercadotecnia.ClickCell

        Dim row As UltraGridRow = gridListaMaterialesMercadotecnia.ActiveRow
        If row.IsFilterRow Then Return
        seleccion = CInt(row.Cells(0).Text)
        idTipo = CInt(row.Cells(1).Text)
        material = CStr(row.Cells(2).Text)
        tipo = CStr(row.Cells(3).Text)
        activo = CBool(row.Cells(4).Value)

    End Sub


    Private Sub gridListaMaterialesMercadotecnia_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridListaMaterialesMercadotecnia.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub CatalogoMaterialesMercadotecniaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        ComboTipoMateriales(cboMaterialesMercadotecniaTipo)

    End Sub

    ''Funcion que recoge los datos par allenar el combobox
    Public Shared Function ComboTipoMateriales(ByVal ComboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboTipoMateriales = New ComboBox
        ComboTipoMateriales = ComboEntrada
        Dim tablaMateriales As New List(Of Entidades.TipoMaterialesMercadotecnia)
        Dim objMaterialesMercadotecniBU As New Negocios.CatalogoMaterialesMercadotecniaBU
        tablaMateriales = objMaterialesMercadotecniBU.ListaTipoMateriales()

        tablaMateriales.Insert(0, New Entidades.TipoMaterialesMercadotecnia)
        If tablaMateriales.Count > 0 Then
            ComboTipoMateriales.DataSource = tablaMateriales
            ComboTipoMateriales.DisplayMember = "PtipoMaterial"
            ComboTipoMateriales.ValueMember = "PidtipoMaterial"
        End If
        If tablaMateriales.Count = 2 Then
            ComboTipoMateriales.SelectedIndex = 1
            '  ComboNavesSegunUsuario.Enabled = False
        End If

        If tablaMateriales.Count > 2 Then
            ComboTipoMateriales.SelectedIndex = 0
        End If

        ComboTipoMateriales.DropDownStyle = ComboBoxStyle.DropDownList


    End Function
End Class