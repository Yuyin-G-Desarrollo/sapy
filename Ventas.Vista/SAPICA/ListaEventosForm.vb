Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaEventosForm

    Dim EventoID As Integer = -1
    Dim EventoActivo As Boolean = False
   
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        CargarListadoEventos()
        EventoID = -1
        btnEditar.Enabled = False
        btnAltas.Enabled = True
        EventoActivo = False
    End Sub

    Public Sub CargarListadoEventos()
        Dim objEventoBU As New Negocios.CatalogoEventoBU
        Dim DTListadoEventos As New DataTable
        grdListaClasificacionClientes.DataSource = Nothing
        DTListadoEventos = objEventoBU.ListaEventos(rdoSi.Checked, txtNombreClasificacionCliente.Text)
        grdListaClasificacionClientes.DataSource = DTListadoEventos

        If DTListadoEventos.Rows.Count = 0 Then
            show_message("Aviso", "No se encontro información")
        End If
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then

            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub


    '' botones arriba abajo.
    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grpTiposDeTienda.Height = 39
        grpTiposDeTienda.Top = 126
        
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grpTiposDeTienda.Height = 101
        grpTiposDeTienda.Top = 126
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtNombreClasificacionCliente.Text = String.Empty
        rdoSi.Checked = True
        btnNo.Checked = False        
        EventoID = -1
        btnEditar.Enabled = False
        btnAltas.Enabled = True
        EventoActivo = False
        grdListaClasificacionClientes.DataSource = Nothing
    End Sub

    ''Botón Agregar
    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click        
        Dim FormEventos As New AgregarEditarEventosForm
        Dim ResultadoCierre As DialogResult
        FormEventos.EsEventoActivo = False
        FormEventos.StartPosition = FormStartPosition.CenterScreen

        ResultadoCierre = FormEventos.ShowDialog()
        EventoID = -1
        btnEditar.Enabled = False
        btnAltas.Enabled = True
        EventoActivo = False
        If ResultadoCierre = Windows.Forms.DialogResult.OK Then
            CargarListadoEventos()
        End If

    End Sub

    ''Botón editar
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim FormAgregarEditarEventos As New AgregarEditarEventosForm
        Dim ResultadoCierre As DialogResult
        FormAgregarEditarEventos.EventoID = EventoID
        FormAgregarEditarEventos.EsEventoActivo = EventoActivo
        FormAgregarEditarEventos.StartPosition = FormStartPosition.CenterScreen
        ResultadoCierre = FormAgregarEditarEventos.ShowDialog()
        EventoID = -1
        btnEditar.Enabled = False
        btnAltas.Enabled = True
        EventoActivo = False        
        If ResultadoCierre <> Windows.Forms.DialogResult.Cancel Then
            CargarListadoEventos()
        End If
    End Sub


    Private Sub rdoSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSi.CheckedChanged
        txtNombreClasificacionCliente.Text = String.Empty        
        EventoID = -1
        btnEditar.Enabled = False
        btnAltas.Enabled = True
    End Sub

    Private Sub btnNo_CheckedChanged(sender As Object, e As EventArgs) Handles btnNo.CheckedChanged
        txtNombreClasificacionCliente.Text = String.Empty        
        EventoID = -1
        btnEditar.Enabled = False
        btnAltas.Enabled = True
    End Sub

    Private Sub grdListaClasificacionClientes_BeforeRowCancelUpdate(sender As Object, e As CancelableRowEventArgs) Handles grdListaClasificacionClientes.BeforeRowCancelUpdate
        e.Cancel = True
    End Sub

    Private Sub grdListaClasificacionClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListaClasificacionClientes.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdListaClasificacionClientes_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListaClasificacionClientes.ClickCell
        Dim row As UltraGridRow = grdListaClasificacionClientes.ActiveRow
        If row.IsFilterRow Then Return
        EventoID = CStr(row.Cells(0).Text)
        EventoActivo = CBool(row.Cells(10).Text)
        btnEditar.Enabled = True
    End Sub

    Private Sub grdListaClasificacionClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaClasificacionClientes.InitializeLayout
        With grdListaClasificacionClientes
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            '.DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.Bands(0).Columns(6).Hidden = True
            .DisplayLayout.Bands(0).Columns(6).Width = 30
            .DisplayLayout.Bands(0).Columns(7).Width = 30
            .DisplayLayout.Bands(0).Columns(7).Hidden = True
            .DisplayLayout.Bands(0).Columns(10).Hidden = True            
            .DisplayLayout.Bands(0).Columns(11).Hidden = True
            .DisplayLayout.Bands(0).Columns(12).Hidden = True
            .DisplayLayout.Bands(0).Columns(13).Hidden = True
            .DisplayLayout.Bands(0).Columns(14).Hidden = True            
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            .DisplayLayout.Bands(0).Columns("FInicio").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("FFin").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("FEColeccVigentes").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("FEColeccNuevas").CellActivation = Activation.NoEdit

            .DisplayLayout.Bands(0).Columns("Evento").Width = 180
            .DisplayLayout.Bands(0).Columns("Abreviatura").Width = 150
            .DisplayLayout.Bands(0).Columns("FInicio").Width = 60
            .DisplayLayout.Bands(0).Columns("FFin").Width = 60
        End With
    End Sub

    Private Sub ListaEventosForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Location = New Point(0, 0)

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_EXPSAP_EVENT", "VENT_SAPICA_PPCP") Then
            btnEditar.Visible = False
            btnAltas.Visible = False
            lblAltas.Visible = False
            lblEditar.Visible = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_EXPSAP_EVENT", "VENT_SAPICA_VENTA") Then
            btnEditar.Enabled = False
            btnAltas.Enabled = True
            btnEditar.Visible = True
            btnAltas.Visible = True
            lblAltas.Visible = True
            lblEditar.Visible = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_EXPSAP_EVENT", "VENT_SAPICA_PPCP", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid) Then
            btnEditar.Visible = False
            btnAltas.Visible = False
            lblAltas.Visible = False
            lblEditar.Visible = False

        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_EXPSAP_EVENT", "VENT_SAPICA_VENTA", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid) Then
            btnEditar.Enabled = False
            btnAltas.Enabled = True
            btnEditar.Visible = True
            btnAltas.Visible = True
            lblAltas.Visible = True
            lblEditar.Visible = True
        End If





    End Sub
End Class