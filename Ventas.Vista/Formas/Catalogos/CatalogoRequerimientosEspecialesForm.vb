Imports Tools

Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid


Public Class CatalogoRequerimientosEspecialesForm

    Dim AgregarOModificar As Boolean
    Dim Activo As Boolean
    Dim IdRequerimiento As Int32
    Dim IdTipo As Int32
    Dim Nombre As String
    Dim Tipo As String


    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbRequerimientosEspeciales.Height = 38
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbRequerimientosEspeciales.Height = 135
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        gridListaRequerimientosEspeciales.DataSource = Nothing
        txtNombreDelRequerimiento.Text = ""

        IdRequerimiento = 0
        IdTipo = 0
        Nombre = ""
        Tipo = ""

    End Sub

    Public Sub LlenarTablaRequerimientos()
        ''Limpiar los datos de la tabla cada vez que presione el boton de buscar y borrar los valores de las variables.
        gridListaRequerimientosEspeciales.DataSource = Nothing
        IdTipo = 0
        IdRequerimiento = 0
        Tipo = ""
        Nombre = ""

        ''Declaracion del objeto para llamar los metodos de la capa de negocios.
        Dim objBU As New Negocios.CatalogoRequerimientosEspecialesBU

        Dim TablaRequerimiento As New DataTable

        ''Asignación de valores a las variables.
        Nombre = txtNombreDelRequerimiento.Text
        Tipo = cboTipoRequerimiento.Text

        If rdoSi.Checked = False Then
            Activo = False
        Else
            Activo = True
        End If

        TablaRequerimiento = objBU.ListaRequeriminetos(Nombre, Tipo, Activo)

        ''Envíamos los datos al metodo de llenar Grid.
        gridListaRequerimientosEspeciales.DataSource = TablaRequerimiento
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        LlenarTablaRequerimientos()
    End Sub

    Private Sub gridListaRequerimientosEspeciales_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridListaRequerimientosEspeciales.InitializeLayout

        With gridListaRequerimientosEspeciales

            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
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


    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        AgregarOModificar = False

        If IdRequerimiento = 0 Or Nombre = "" Or Tipo = "" Then
            Dim FormularioError As New ErroresForm
            FormularioError.mensaje = "Realiza una consulta y selecciona la fila que contenga los datos que deseas modificar antes de dar click en el botón 'Editar'!"
            FormularioError.ShowDialog()
        Else
            Dim formaRequerimientosEspeciales As New AgregarEditarRequerimientosEspecialesForm
            formaRequerimientosEspeciales.IdRequerimiento = IdRequerimiento
            formaRequerimientosEspeciales.IdTipo = IdTipo
            formaRequerimientosEspeciales.AgregarOModificar = AgregarOModificar
            formaRequerimientosEspeciales.Nombre = Nombre
            formaRequerimientosEspeciales.Activo = Activo
            formaRequerimientosEspeciales.Tipo = Tipo
            formaRequerimientosEspeciales.ShowDialog()
            LlenarTablaRequerimientos()

        End If

    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        AgregarOModificar = True

       
        Dim formaRequerimientosEspeciales As New AgregarEditarRequerimientosEspecialesForm
        formaRequerimientosEspeciales.IdRequerimiento = IdRequerimiento
        formaRequerimientosEspeciales.IdTipo = IdTipo
        formaRequerimientosEspeciales.AgregarOModificar = AgregarOModificar
        formaRequerimientosEspeciales.Nombre = Nombre
        formaRequerimientosEspeciales.Activo = Activo
        formaRequerimientosEspeciales.Tipo = Tipo
        formaRequerimientosEspeciales.ShowDialog()
        LlenarTablaRequerimientos()
    End Sub



    Private Sub CatalogoRequerimientosEspecialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        'Llenamos el combo con los datos de los tipos de materiales
        ComboTipoRequerimientos(cboTipoRequerimiento)
        txtNombreDelRequerimiento.MaxLength = 50
    End Sub


    Public Shared Function ComboTipoRequerimientos(ByVal ComboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboTipoRequerimientos = New ComboBox
        ComboTipoRequerimientos = ComboEntrada
        Dim TablaTipos As New List(Of Entidades.TipoRequerimientosEspeciales)
        Dim objRequerimientosBU As New Negocios.CatalogoRequerimientosEspecialesBU
        TablaTipos = objRequerimientosBU.ListaTipoRequerimientos()

        TablaTipos.Insert(0, New Entidades.TipoRequerimientosEspeciales)
        If TablaTipos.Count > 0 Then
            ComboTipoRequerimientos.DataSource = TablaTipos
            ComboTipoRequerimientos.DisplayMember = "PTipo"
            ComboTipoRequerimientos.ValueMember = "PIdTipo"
        End If
        If TablaTipos.Count = 2 Then
            ComboTipoRequerimientos.SelectedIndex = 1
            '  ComboNavesSegunUsuario.Enabled = False
        End If

        If TablaTipos.Count > 2 Then
            ComboTipoRequerimientos.SelectedIndex = 0
        End If

        ComboTipoRequerimientos.DropDownStyle = ComboBoxStyle.DropDownList
    End Function



    Private Sub gridListaRequerimientosEspeciales_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridListaRequerimientosEspeciales.ClickCell
        Dim row As UltraGridRow = gridListaRequerimientosEspeciales.ActiveRow
        If row.IsFilterRow Then Return
        IdRequerimiento = CInt(row.Cells(0).Text)
        Nombre = CStr(row.Cells(1).Text)
        IdTipo = CInt(row.Cells(2).Text)
        Tipo = CStr(row.Cells(3).Text)
        Activo = CBool(row.Cells(4).Value)
    End Sub

    Private Sub gridListaRequerimientosEspeciales_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridListaRequerimientosEspeciales.BeforeRowsDeleted
        e.Cancel = True
    End Sub
End Class