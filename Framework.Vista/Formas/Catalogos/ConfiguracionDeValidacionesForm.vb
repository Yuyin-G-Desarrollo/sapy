Imports Tools.Controles
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win



Public Class ConfiguracionDeValidacionesForm

    Dim IdUsuario As Integer
    Dim IdNave As Integer
    Dim IdArea As Integer
    Dim IdDepartamento As Integer
    Dim IdColaborador As Integer
    Dim IdTipoValidacion As Integer


    Private Sub ConfiguracionDeValidacionesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        ComboTipoValidacion(cboTipo)
        llenarTablaConfiguracionDeValidaciones()

        IdUsuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ComboNavesSegunUsuario(cboNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        'CargarPermisos()
    End Sub


    ''' <summary>
    ''' Busca si el usuario tiene permisos sobre las acciones de la pantalla
    ''' </summary>
    ''' <remarks></remarks>
    ''Public Sub CargarPermisos()
    '    If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_CAT_CONFVAL", "VENT_CAT_EDIT_CONF") Then
    '        btnAbajo.Visible = False
    '    Else
    '        btnAbajo.Visible = True
    '    End If

    'End Sub


    ''' <summary>
    ''' LLENA UN CONTROL DEL TIPO COMBOBOX CON LA LISTA DE LOS TIPOS DE VALIDACION EXISTENTES
    ''' </summary>
    ''' <param name="ComboEntrada">CONTROL COMBOBOX</param>
    ''' <returns>CONTROL CON LA LISTA DE LOS TIPOS DE VALIDACION EXISTENTE</returns>
    ''' <remarks></remarks>
    Public Function ComboTipoValidacion(ByVal ComboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboTipoValidacion = New ComboBox
        ComboTipoValidacion = ComboEntrada
        Dim TablaTipo As New List(Of Entidades.ListaTipoValidaciones)
        Dim objTipoBU As New Negocios.CatalogoConfiguracionDeValidacionesBU
        TablaTipo = objTipoBU.ListaTipo()

        TablaTipo.Insert(0, New Entidades.ListaTipoValidaciones)
        If TablaTipo.Count > 0 Then
            ComboTipoValidacion.DataSource = TablaTipo
            ComboTipoValidacion.DisplayMember = "PNombre"
            ComboTipoValidacion.ValueMember = "PId"
        End If

    End Function


    Private Sub grdConfiguracionValidaciones_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdConfiguracionValidaciones.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdConfiguracionValidaciones_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdConfiguracionValidaciones.InitializeLayout
        With grdConfiguracionValidaciones
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns 'Ajusta todas las columnas a un tamaño igual.
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            .DisplayLayout.Bands(0).Columns("IDCOLABORADOR").Hidden = True
            .DisplayLayout.Bands(0).Columns("IDDEPARTAMENTO").Hidden = True
            .DisplayLayout.Bands(0).Columns("IDAREA").Hidden = True
            .DisplayLayout.Bands(0).Columns("idNave").Hidden = True
            .DisplayLayout.Bands(0).Columns("IDTIPO").Hidden = True
        End With


    End Sub

    Private Sub grdConfiguracionValidaciones_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdConfiguracionValidaciones.ClickCell
        Dim row As UltraGridRow = grdConfiguracionValidaciones.ActiveRow
        If row.IsFilterRow Then Return
        IdTipoValidacion = CInt(row.Cells("IDTIPO").Text)
        IdNave = CInt(row.Cells("idNave").Text)
        IdDepartamento = CInt(row.Cells("IDDEPARTAMENTO").Text)
        IdArea = CInt(row.Cells("IDAREA").Text)
        IdColaborador = CInt(row.Cells("IDCOLABORADOR").Text)

        ComboTipoValidacion(cboTipo)
        cboTipo.SelectedValue = IdTipoValidacion

        ComboNavesSegunUsuario(cboNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        cboNave.SelectedValue = IdNave

        ComboAreaSegunNave(cboArea, IdNave)
        cboArea.SelectedValue = IdArea

        ComboDepartamentosSegunArea(cboDepartamento, IdArea)
        cboDepartamento.SelectedValue = IdDepartamento

        ComboColaboradoresSegunDepto(cboUsuarioAutorizado, IdDepartamento)
        cboUsuarioAutorizado.SelectedValue = IdColaborador

    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grpParametros.Height = 42
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grpParametros.Height = 299
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        IdUsuario = CInt(cboUsuarioAutorizado.SelectedValue)
        IdTipoValidacion = CInt(cboTipo.SelectedValue)

        If IdUsuario = 0 Then
            Dim FormularioError As New ErroresForm
            FormularioError.mensaje = "Selecciona un usuario para asignarle la validación"
            FormularioError.ShowDialog()
        ElseIf IdTipoValidacion = 0 Then
            Dim FormularioError As New ErroresForm
            FormularioError.mensaje = "Selecciona una validación"
            FormularioError.ShowDialog()
        Else
            Dim objConfValidacionBU As New Negocios.CatalogoConfiguracionDeValidacionesBU
            objConfValidacionBU.EditarConfiguracioDeValidaciones(IdUsuario, IdTipoValidacion)
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Se le asigno la validación al usuario"
            FormaExito.ShowDialog()

            llenarTablaConfiguracionDeValidaciones()
        End If


    End Sub

    Public Sub llenarTablaConfiguracionDeValidaciones()
        grdConfiguracionValidaciones.DataSource = Nothing
        Dim objListaConfiguracionBU As New Negocios.CatalogoConfiguracionDeValidacionesBU
        Dim dtListaConfiguracion As New DataTable
        dtListaConfiguracion = objListaConfiguracionBU.dtListaConfiguracion
        grdConfiguracionValidaciones.DataSource = dtListaConfiguracion
    End Sub

    Private Sub cboDepartamento_DropDownClosed(sender As Object, e As EventArgs) Handles cboDepartamento.DropDownClosed
        If cboDepartamento.SelectedIndex > 0 Then
            IdDepartamento = CInt(cboDepartamento.SelectedValue)
            ComboColaboradoresSegunDepto(cboUsuarioAutorizado, IdDepartamento)
        Else
            IdDepartamento = 0
        End If
    End Sub

    Private Sub cboArea_DropDownClosed(sender As Object, e As EventArgs) Handles cboArea.DropDownClosed
        If CInt(cboArea.SelectedIndex) > 0 Then
            IdArea = CInt(cboArea.SelectedValue)
            ComboDepartamentosSegunArea(cboDepartamento, IdArea)
            cboUsuarioAutorizado.DataSource = Nothing
        Else
            IdArea = 0
        End If
    End Sub

    Private Sub cboNave_DropDownClosed(sender As Object, e As EventArgs) Handles cboNave.DropDownClosed
        IdNave = CInt(cboNave.SelectedValue)
        If CInt(cboNave.SelectedIndex) > 0 Then
            IdNave = CInt(cboNave.SelectedValue)
            ComboAreaSegunNave(cboArea, IdNave)
            cboDepartamento.DataSource = Nothing
            cboUsuarioAutorizado.DataSource = Nothing
        Else
            IdNave = 0
        End If
    End Sub



End Class