Imports Tools
Imports Infragistics.Win.UltraWinDock
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTabs
Imports Infragistics.Win.SupportDialogs.FilterUIProvider




Partial Public Class FichaTecnicaClienteForm

    Friend WithEvents gridContacto As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gridClienteRFC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gridClienteRFCCEDIS As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gridDocumentos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gridHorario As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gridPolitica As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gridHistorialValidaciones As Infragistics.Win.UltraWinGrid.UltraGrid

    Public clienteID_Busqueda As Integer
    Public clienteID_Sicy As Integer
    Public alta_cliente As Boolean
    Public AreaOperativa As Integer
    Public claseDocumento As String
    Public cliente_CP As Integer '1 - CLIENTE / 3 - PROSPECTO
    Public rfc_CP As Integer '14 - FACTURA / 13 - REMISION
    Public editando As Boolean
    Public Archivos As New Entidades.ColaboradorExpediente
    Public IdListaPrecioCliente As Integer
    Dim lista_RecuperadA() As String
    Dim VerPanelListaVentas As Boolean ''true para ver, false para ocultar
    Dim Poblacion As Integer
    Dim IdCedis As Integer

    Dim ModoEdicion As Boolean = False
    Dim ModoEdicion_CreditoConbranza As Boolean = False
    Dim ModoEdicion_Almacen As Boolean = False
    Dim ModoEdicion_Etiquetado As Boolean = False
    Dim ModoEdicion_MercaDotecnia As Boolean = False
    Dim Editando_Zapaterias As Boolean = False
    Dim Editando_Mercadotecnia As Boolean = False

    Dim bloquear_ListasDePrecios As Boolean = False

    Dim IdEmpresaVentas As Integer = 0
    'Public AgregarOEditarGrid As Boolean

    Public idcomercializadora As Integer
    Public esLicencia As Boolean

    Public editarMarcaAgenteVentas As Boolean = False

    Private Sub FichaTecnicaClienteForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Normal
        Me.StartPosition = FormStartPosition.CenterParent
        'Me.Top = 0
        'Me.Left = 0

        Me.dockManagerFichaTecnica.UnpinnedTabHoverAction = UnpinnedTabHoverAction.None

        limpiarControles(pnlFormCliente)
        asignaStatusControles(pnlFormCliente, False)
        lblClientePersonaID_Int.Text = "0"
        lblClienteSAYID_Int.Text = "0"
        btnBuscarCliente.Enabled = True
        cboxClienteCliente.Enabled = True
        'cboxClienteCliente.DropDownStyle = ComboBoxStyle.DropDown
        Utilerias.ComboObtenerCEDIS(cboxNaveAlmacen)

        If clienteID_Busqueda > 0 Then
            btnBuscarCliente.PerformClick()
            btnBuscarCliente.Visible = False
        Else
            btnBuscarCliente.Visible = False
            ListaClientes()
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "ALTACLIENTE") Then
            If CInt(lblClientePersonaID_Int.Text) = 0 Then
                btnAgregarCliente.Enabled = True
            Else
                btnAgregarCliente.Enabled = False
            End If
        Else
            btnAgregarCliente.Enabled = False
        End If


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "VER_PANEL_EDITAR_LISTA_VENTA") Then
            VerPanelListaVentas = True
        Else
            VerPanelListaVentas = False
            gboxPrecioValoresdeConfiguracionActual.Visible = False
            gboxPrecioValoresdeConfiguracionAsignar.Visible = False
            cboxPrecioListaNueva.Visible = False
            btnPrecioAsignarListadeVentas.Enabled = False
            btnListadoPreciosPanelPrecio.Enabled = False
        End If


        If rbtnClienteStatusInactivo.Checked Then
            btnEditarCliente.Enabled = False
        Else
            'If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
            '    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCABECERAATN") Then
            '        If CInt(lblClientePersonaID_Int.Text) = 0 Then
            '            btnEditarCliente.Enabled = False
            '        Else
            '            btnEditarCliente.Enabled = True
            '        End If
            '    Else
            '        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
            '            If CInt(lblClientePersonaID_Int.Text) = 0 Then
            '                btnEditarCliente.Enabled = False
            '            Else
            '                btnEditarCliente.Enabled = True
            '            End If
            '        Else
            '            btnEditarCliente.Enabled = False
            '        End If
            '    End If
            'End If
        End If

        If alta_cliente Then
            btnAgregarCliente.PerformClick()
            btnAgregarCliente.Visible = False
            cboxClienteEstatus.SelectedIndex = 0

            'cboxAlmacenAlmacen.SelectedIndex = 0
        Else
            btnAgregarCliente.Visible = False

        End If


        'VALIDACION

        Dim validacionBU As New Framework.Negocios.ValidacionBU
        Dim usuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        If validacionBU.Usuario_Validacion(usuarioID, 3) Then
            btnClienteModificarStatus.Enabled = True
            If rbtnClienteStatusActivo.Checked Then
                lblClienteModificarStatus.Text = "Inactivar"
            End If
        End If

        If idcomercializadora = 82 Then
            Me.dockManagerFichaTecnica.PaneFromControl(Me.pnlMercadotecnia).Minimized = True
            Me.dockManagerFichaTecnica.PaneFromControl(Me.pnlMercadotecnia).Closed = True
        End If

        setPermisos()


    End Sub
    Private Sub setPermisos()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "GBCONTABILIDAD") Then
            gboxVentasContabilidad.Enabled = True
        Else
            gboxVentasContabilidad.Enabled = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "RFCEDITAR") Or
            Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") And
            Not rbtnClienteStatusInactivo.Checked Then
            btnEditarRFC.Enabled = True
        Else
            btnEditarRFC.Enabled = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "RFCALTAS") Then
            btnRFCAltaRFC.Enabled = True
        Else
            btnRFCAltaRFC.Enabled = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "CONTABILIDADEDITAR") And
            Not rbtnClienteStatusInactivo.Checked Then
            btnEditarCobranzaContabilidad.Enabled = True
        Else
            btnEditarCobranzaContabilidad.Enabled = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "PRECIOSEDITAR") Or
            Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") And
            Not rbtnClienteStatusInactivo.Checked Then
            btnEditarPrecio.Enabled = True
        Else
            btnEditarPrecio.Enabled = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "GBAGENTEVENTAS") Then
            gboxVentasVendedores.Enabled = True
        Else
            gboxVentasVendedores.Enabled = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "RFCVINCULAR") Then
            btnRFCVincularTECs.Enabled = True
        Else
            btnRFCVincularTECs.Enabled = False
        End If


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARDATOS") Or
            Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") And
            Not rbtnClienteStatusInactivo.Checked Then
            btnEditarDatos.Enabled = True
        Else
            btnEditarDatos.Enabled = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARVENTAS") Or
            Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") And
            Not rbtnClienteStatusInactivo.Checked Then
            btnEditarVentas.Enabled = True
        Else
            btnEditarVentas.Enabled = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCREDITOCOBRANZA") Or
            Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") And
            Not rbtnClienteStatusInactivo.Checked Then
            btnEditarCobranzaPoliticaPagos.Enabled = True
        Else
            btnEditarCobranzaPoliticaPagos.Enabled = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOBRANZAEVALUACION") Or
            Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") And
            Not rbtnClienteStatusInactivo.Checked Then
            btnEditarCobranzaEvaluacionTecnica.Enabled = True
        Else
            btnEditarCobranzaEvaluacionTecnica.Enabled = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARALMACEN") Or
            Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") And
            Not rbtnClienteStatusInactivo.Checked Then
            btnEditarAlmacen.Enabled = True
        Else
            btnEditarAlmacen.Enabled = False
        End If


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARTIENDASEMBCEDIS") Or
            Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") And
            Not rbtnClienteStatusInactivo.Checked Then
            btnEditarCEDISPersona.Enabled = True
            btnEditarCEDISDomicilio.Enabled = True
            btnEditarCEDISEmbarque.Enabled = True
            btnEditarCEDISMensajeria.Enabled = True
            btnEditarCEDISEmpaque.Enabled = True
        Else
            btnEditarCEDISPersona.Enabled = False
            btnEditarCEDISDomicilio.Enabled = False
            btnEditarCEDISEmbarque.Enabled = False
            btnEditarCEDISMensajeria.Enabled = False
            btnEditarCEDISEmpaque.Enabled = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARETIQUETADO") Or
            Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") And
            Not rbtnClienteStatusInactivo.Checked Then
            btnEditarEtiquetado.Enabled = True
        Else
            btnEditarEtiquetado.Enabled = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARMERCADOCTENIA") Or
            Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") And
            Not rbtnClienteStatusInactivo.Checked Then
            btnEditarMKT.Enabled = True
        Else
            btnEditarMKT.Enabled = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCABECERAATN") Or
            Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") And
            Not rbtnClienteStatusInactivo.Checked Then
            btnEditarCliente.Enabled = True
        Else
            btnEditarCliente.Enabled = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITAR_MAR_AG_VEN") Then
            editarMarcaAgenteVentas = True
        Else
            editarMarcaAgenteVentas = False
        End If

    End Sub
    Private Sub FichaTecnicaClienteForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing


        'Se comentó las lineas para la validación de de archo PDF 

        'If Etiquetas_Especiales = False Then
        '    e.Cancel = True
        '    show_message("Advertencia", "Carga el archivo PDF de etiquetado para poder continuar usando el sistema.")
        'Else
        Me.Cursor = Cursors.WaitCursor
        Dim Bitacora As New Tools.Bitacora
        Bitacora.email_envia = "say_clientes@grupoyuyin.com.mx"
        Bitacora.clave_email = "ENVIO_BITACORA_FTC"
        Bitacora.subject = "Bitacora - Ficha Técnica de Clientes"
        Bitacora.naveID = 43
        Bitacora.RegistroPrincipalID = CInt(lblClienteSAYID_Int.Text)
        Bitacora.TipoNotificacionID = 1
        Bitacora.recuperar_datos_notificacion()
        Me.Cursor = Cursors.Default
        'End If

    End Sub


    Private Sub FichaTecnicaClienteForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

        Dim caracter As Char = e.KeyChar

        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If

        If caracter = "|" Or caracter = "~" Or caracter = "'" Then
            e.Handled = True
        End If

    End Sub

    Private Sub btnClienteModificarStatus_Click(sender As Object, e As EventArgs) Handles btnClienteModificarStatus.Click
        Dim form As New Editar_StatusClienteForm
        form.clienteID_SAY = clienteID_Busqueda
        form.clienteID_SICY = CInt(txtClienteSICYID.Text)
        form.status = rbtnClienteStatusActivo.Checked
        form.WindowState = FormWindowState.Normal
        form.StartPosition = FormStartPosition.CenterScreen
        form.ShowDialog()
        If form.DialogResult = Windows.Forms.DialogResult.OK Then
            If rbtnClienteStatusActivo.Checked Then
                btnClienteModificarStatus.Image = Global.Ventas.Vista.My.Resources.Resources.apagar_32
                lblClienteModificarStatus.Text = "Activar"
            Else
                btnClienteModificarStatus.Image = Global.Ventas.Vista.My.Resources.Resources.encender_32
                lblClienteModificarStatus.Text = "Inactivar"
            End If
            recuperar_datos_Panel_Cliente(CInt(lblClienteSAYID_Int.Text))
        End If

    End Sub

#Region "OTRAS ACCIONES     "

    'Muestra el form de mensaje
    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
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

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    'Limpiar todos los controles
    Public Sub limpiarControles(ByVal control As Control)
        If TypeOf control Is TextBox Then
            CType(control, TextBox).Text = String.Empty
        End If
        If TypeOf control Is MaskedTextBox Then
            CType(control, MaskedTextBox).Text = String.Empty
        End If
        If TypeOf control Is ComboBox Then
            CType(control, ComboBox).SelectedIndex = -1
        End If
        If TypeOf control Is NumericUpDown Then
            CType(control, NumericUpDown).Value = Decimal.Zero
        End If
        If TypeOf control Is CheckBox Then
            CType(control, CheckBox).Checked = False
        End If
        If TypeOf control Is RadioButton Then
            CType(control, RadioButton).Checked = False
        End If
        If TypeOf control Is DateTimePicker Then
            CType(control, DateTimePicker).Value = DateTimePicker.MinimumDateTime.ToString
        End If
        Dim i As Integer = control.Controls.Count
        For Each ctrl As Control In control.Controls
            limpiarControles(ctrl)
        Next ctrl
    End Sub

    Public Sub CambiarElForeColorControles_Negro(ByVal control As Control)
        If TypeOf control Is TextBox Then
            CType(control, TextBox).ForeColor = Color.Black
        End If
        If TypeOf control Is Label Then
            CType(control, Label).ForeColor = Color.Black
        End If
        If TypeOf control Is MaskedTextBox Then
            CType(control, MaskedTextBox).ForeColor = Color.Black
        End If
        If TypeOf control Is ComboBox Then
            CType(control, ComboBox).ForeColor = Color.Black
        End If

        If TypeOf control Is NumericUpDown Then
            CType(control, NumericUpDown).ForeColor = Color.Black
        End If

        If TypeOf control Is CheckBox Then
            CType(control, CheckBox).ForeColor = Color.Black
        End If

        If TypeOf control Is RadioButton Then
            CType(control, RadioButton).ForeColor = Color.Black
        End If

        If TypeOf control Is DateTimePicker Then
            CType(control, DateTimePicker).ForeColor = Color.Black
        End If


        For Each ctrl As Control In control.Controls
            CambiarElForeColorControles_Negro(ctrl)
        Next ctrl

    End Sub

    Public Sub CambiarElForeColorControles_DodgerBlue(ByVal control As Control)
        If TypeOf control Is TextBox Then
            CType(control, TextBox).ForeColor = Color.DodgerBlue
        End If
        If TypeOf control Is Label Then
            CType(control, Label).ForeColor = Color.DodgerBlue
        End If
        If TypeOf control Is MaskedTextBox Then
            CType(control, MaskedTextBox).ForeColor = Color.DodgerBlue
        End If
        If TypeOf control Is ComboBox Then
            CType(control, ComboBox).ForeColor = Color.DodgerBlue
        End If

        If TypeOf control Is NumericUpDown Then
            CType(control, NumericUpDown).ForeColor = Color.DodgerBlue
        End If

        If TypeOf control Is CheckBox Then
            CType(control, CheckBox).ForeColor = Color.DodgerBlue
        End If

        If TypeOf control Is RadioButton Then
            CType(control, RadioButton).ForeColor = Color.DodgerBlue
        End If

        If TypeOf control Is DateTimePicker Then
            CType(control, DateTimePicker).ForeColor = Color.DodgerBlue
        End If


        For Each ctrl As Control In control.Controls
            CambiarElForeColorControles_DodgerBlue(ctrl)
        Next ctrl

    End Sub


    'Habilita/Desabilita todos los controles
    Public Sub asignaStatusControles(ByVal control As Control, enable As Boolean)

        'If TypeOf control Is Panel Then
        '    If control.Name.Contains("pnlForm") Then
        '        If enable Then
        '            Cursor.Clip = control.RectangleToScreen(control.ClientRectangle)
        '        Else
        '            Cursor.Clip = Nothing
        '        End If
        '    End If
        'End If
        'clienteID_Busqueda
        If TypeOf control Is TextBox Then
            CType(control, TextBox).Enabled = enable
        End If
        If TypeOf control Is MaskedTextBox Then
            CType(control, MaskedTextBox).Enabled = enable
        End If
        If TypeOf control Is ComboBox Then
            CType(control, ComboBox).Enabled = enable
            If enable Then
                CType(control, ComboBox).DropDownStyle = ComboBoxStyle.DropDownList
            Else
                CType(control, ComboBox).DropDownStyle = ComboBoxStyle.Simple
            End If
        End If

        If TypeOf control Is NumericUpDown Then
            CType(control, NumericUpDown).Enabled = enable
        End If

        If TypeOf control Is CheckBox Then
            CType(control, CheckBox).Enabled = enable
        End If

        If TypeOf control Is RadioButton Then
            CType(control, RadioButton).Enabled = enable
            CType(control, RadioButton).TabStop = True
        End If

        If TypeOf control Is DateTimePicker Then
            CType(control, DateTimePicker).Enabled = enable
        End If


        If TypeOf control Is Button Then

            If control.Name.Contains("btnEditar") Then
                CType(control, Button).Enabled = Not enable
            Else
                CType(control, Button).Enabled = enable
            End If

        End If

        For Each ctrl As Control In control.Controls
            asignaStatusControles(ctrl, enable)
        Next ctrl

    End Sub

    'Asigna formato a columnas de ultragrid
    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If
            If col.DataType.Name.ToString.Equals("Boolean") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("DateTime") Then
                col.Style = ColumnStyle.DateTime
            End If

            If col.DataType.Name.ToString.Equals("String") Then
                If col.Header.Caption.Equals("FECHA") Then
                    col.Style = ColumnStyle.DateTime
                ElseIf col.Header.Caption.Equals("TELÉFONO") Then
                    'col.MaskInput = "##-##-##-##-##-##"
                    'col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    'col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("EXTENSIÓN") Then
                    ''col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If

            End If

        Next

    End Sub

    'Envio de correo de validación de Ventas/Cobranza
    Private Sub enviar_correo_validacion(naveID As Integer, clave As String, ListaColaborador As List(Of Integer), validacion As Entidades.Validacion)

        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String
        Dim tipoValidacion As New List(Of Integer)
        Dim correo As New Tools.Correo

        If validacion.validaciontipo.validaciontipoid = 1 Then
            tipoValidacion.Add(1)
        ElseIf validacion.validaciontipo.validaciontipoid = 1 Then
            tipoValidacion.Add(1)
            tipoValidacion.Add(2)
        End If

        destinatarios = enviosCorreoBU.consulta_destinatarios_email(naveID, clave) + "," + enviosCorreoBU.consulta_email_usuario_validacion(tipoValidacion) + "," + enviosCorreoBU.consulta_email_colaborador(ListaColaborador)

        Dim Email As String = "<html>" +
                                      "<head>" +
                                          "<style type ='" + "text/css" + "'> body {display: block; margin: 8px; background: #FFFFFF;color: #003366;	font-family: Arial, Helvetica, sans-serif;	font-size: 18px;	font-weight: bold;}#header{	position: fixed;	height: 62px;	top: 0;	left: 0;	right: 0;	color: #003366;	font-family: Arial, Helvetica, sans-serif;	font-size: 18px;	font-weight: bold;}#leftcolumn{	float: left;	position: fixed;	width: 2%;	margin: 1%;	padding-top: 3%;	top: 0;	left: 0;	right: 0;}#content{	width: 90%;	position: fixed;	margin: 1% 5%;		padding-top: 3%;	padding-bottom: 1%;}#rightcolumn{	float: right;	width: 5%;	margin: 1%;			padding-top: 3%;}#footer{	position: fixed;	width: 100%;	heigt: 5%;	bottom: 0;	margin: 0;	padding: 0;	color: #003366;	font-family: Arial, Helvetica, sans-serif;	font-size: 12px;	font-weight: bold;}table.tableizer-table { 	font-family: Arial, Helvetica, sans-serif;	font-size: 9px;} .tableizer-table td {	padding: 4px;	margin: 0px;	border: 1px solid #FFFFFF;	border-color: #FFFFFF;	border: 1px solid #CCCCCC;	width: 200px;} .tableizer-table tr {	padding: 4px;	margin: 0;	color: #003366;	font-weight: bold;	background-color: #transparent; 	opacity: 1;}.tableizer-table th {	background-color: #003366; 	color: #FFFFFF;	font-weight: bold;	height: 30px;	font-size: 10px;}A:link {	text-decoration:none;color:#FFFFFF;} A:visited {	text-decoration:none;color:#FFFFFF;} A:active {	text-decoration:none;color:#FFFFFF;} A:hover {	text-decoration:none;color:#006699;} </style>" +
                                      "</head>" +
                                      "<body>" +
                                          "<div id='" + "wrapper" + "'>" +
                                              "<div id='" + "header" + "'>" +
                                                  "<img src='" + "http://www.grupoyuyin.com.mx/GRUPO_YUYIN.jpg" + "'style='" + "vertical-align:middle" + "' height='" + "57" + "' widht='" + "125" + "'> Validación de cliente en ficha técnica" +
                                              "</div>" +
                                              "<div id='" + "leftcolumn" + "'>" +
                                              "</div>" +
                                              "<div id='" + "rightcolumn" + "'>" +
                                              "</div>" +
                                              "<div id='" + "content" + "'>"

        If validacion.validaciontipo.validaciontipoid = 1 Then
            Email += "<p>Se ha realizado la validación de Ventas del cliente: " + cboxClienteCliente.Text + "</p>"
        ElseIf validacion.validaciontipo.validaciontipoid = 2 Then
            Email += "<p>Se ha realizado la validación de Cobranza del cliente: " + cboxClienteCliente.Text + "</p>"
        End If

        If validacion.validaciontipo.validaciontipoid = 1 Then
            Email += "<p>Realizado por: " + Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString + "</p>"
        ElseIf validacion.validaciontipo.validaciontipoid = 2 Then
            Email += "<p>Realizado por: " + Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString + "</p>"
        End If

        If validacion.validacionestatus = 1 Then
            Email += "<p>Estatus: Autorizado</p>"
        ElseIf validacion.validacionestatus = 2 Then
            Email += "<p>Estatus: Denegado</p>"
        End If

        Email += "</div>" +
                                              "<div id='" + "footer" + "'>" +
                                                  "<p>Realizado: " + Now.ToLongDateString + " " + Now.ToLongTimeString + "</p>" +
                                              "</div>" +
                                          "</div>" +
                                      "</body>" +
                                  "</html>"

        correo.EnviarCorreoHtml(destinatarios, "say_clientes@grupoyuyin.com.mx", "Validación de Cliente - Ficha Técnica", Email)

    End Sub

#End Region


#Region "ACCIONES GRIDS"


    'COBRANZA DESCUENTOS
    Public Sub poblar_gridCobranzaDescuentos(clienteID As Integer)

        gridCobranzaDescuentos.DataSource = Nothing

        Dim clientesBU As New Negocios.ClientesDatosBU
        Dim motivoDescuento As New DataTable
        Dim lugarDescuento As New DataTable
        Dim descuento As New DataTable

        Dim vlmotivoDescuento As New Infragistics.Win.ValueList
        Dim vllugarDescuento As New Infragistics.Win.ValueList

        descuento = clientesBU.Datos_TablaDescuentosCliente(clienteID, AreaOperativa)

        motivoDescuento = clientesBU.Datos_TablaMotivoDescuento()

        lugarDescuento = clientesBU.Datos_TablaLugarDescuento()

        For Each fila As DataRow In motivoDescuento.Rows
            vlmotivoDescuento.ValueListItems.Add(fila.Item("mode_motivodescuentoid"), fila.Item("mode_nombre"))
        Next

        For Each fila As DataRow In lugarDescuento.Rows
            vllugarDescuento.ValueListItems.Add(fila.Item("lude_lugardescuentoid"), fila.Item("lude_nombre"))
        Next

        gridCobranzaDescuentos.DataSource = descuento
        gridCobranzaDescuentos.DisplayLayout.Bands(0).Columns(2).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        gridCobranzaDescuentos.DisplayLayout.Bands(0).Columns(2).ValueList = vlmotivoDescuento
        gridCobranzaDescuentos.DisplayLayout.Bands(0).Columns(4).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        gridCobranzaDescuentos.DisplayLayout.Bands(0).Columns(4).ValueList = vllugarDescuento

        gridCobranzaDescuentosDiseno(gridCobranzaDescuentos)

    End Sub

    Private Sub gridCobranzaDescuentosDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)


        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(1).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(3).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(9).Hidden = True

        grid.DisplayLayout.Bands(0).Columns(2).Header.Caption = "MOTIVO"
        grid.DisplayLayout.Bands(0).Columns(4).Header.Caption = "LUGAR"
        grid.DisplayLayout.Bands(0).Columns(5).Header.Caption = "%"
        grid.DisplayLayout.Bands(0).Columns(6).Header.Caption = "CANTIDAD"
        grid.DisplayLayout.Bands(0).Columns(6).Style = ColumnStyle.DoublePositive

        grid.DisplayLayout.Bands(0).Columns(7).Header.Caption = "DÍAS"
        grid.DisplayLayout.Bands(0).Columns(8).Header.Caption = "ENCADENADO"

        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No


        Dim ColumnaSumar As UltraGridColumn = gridCobranzaDescuentos.DisplayLayout.Bands(0).Columns(6)
        Dim sumaPares As SummarySettings = gridCobranzaDescuentos.DisplayLayout.Bands(0).Summaries.Add("TOTAL", SummaryType.Sum, ColumnaSumar)
        gridCobranzaDescuentos.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        sumaPares.DisplayFormat = "{0:###,###,###,###0.00}"
        sumaPares.Appearance.TextHAlign = HAlign.Right


    End Sub

    Private Sub gridCobranzaDescuentos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridCobranzaDescuentos.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub gridCobranzaDescuentos_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridCobranzaDescuentos.DoubleClickHeader

        If Me.gridCobranzaDescuentos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.gridCobranzaDescuentos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.gridCobranzaDescuentos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.gridCobranzaDescuentos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.gridCobranzaDescuentos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.gridCobranzaDescuentos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.gridCobranzaDescuentos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If

    End Sub

    Private Sub gridCobranzaDescuentos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridCobranzaDescuentos.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            If gridCobranzaDescuentos.Rows.Count > 0 Then
                Dim NextRowIndex As Integer = gridCobranzaDescuentos.ActiveRow.Index + 1
                Try
                    gridCobranzaDescuentos.DisplayLayout.Rows(NextRowIndex).Activated = True
                    gridCobranzaDescuentos.DisplayLayout.Rows(NextRowIndex).Selected = True
                Catch ex As Exception
                    gridCobranzaDescuentos.ActiveRow.Activated = False
                End Try

            End If
        End If

        If e.KeyChar = ChrW(Keys.Escape) Then

            poblar_gridCobranzaDescuentos(CInt(cboxClienteCliente.SelectedValue))
            gridCobranzaDescuentos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        End If

    End Sub

    Private Sub gridCobranzaDescuentos_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)

        If selection = 1 Then ''AGREGAR NUEVO HORARIO

            Dim grid As DataTable = gridCobranzaDescuentos.DataSource
            Dim row As UltraGridRow = gridCobranzaDescuentos.ActiveRow
            Dim motivoDescuento As UltraGridColumn = gridCobranzaDescuentos.DisplayLayout.Bands(0).Columns(2)
            Dim lugarDescuento As UltraGridColumn = gridCobranzaDescuentos.DisplayLayout.Bands(0).Columns(4)

            If Not IsNothing(row) Then

                grid.Rows.Add(0, 0, motivoDescuento, 0, lugarDescuento, False, Decimal.Zero, 0, False, CInt(cboxClienteCliente.SelectedValue))

                gridCobranzaDescuentos.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True
                Try
                    gridCobranzaDescuentos.ActiveRow.Activation = Activation.AllowEdit
                    gridCobranzaDescuentos.ActiveCell = gridContacto.ActiveRow.Cells(3)
                    gridCobranzaDescuentos.ActiveCell.Activation = Activation.Disabled
                Catch ex As Exception

                End Try


                gridCobranzaDescuentos.PerformAction(UltraGridAction.ToggleCellSel, False, False)
                gridCobranzaDescuentos.PerformAction(UltraGridAction.EnterEditMode, False, False)

            End If

        End If

        If selection = 2 Then ''EDITAR HORARIO ACTUAL

            For Each row In gridCobranzaDescuentos.Selected.Rows
                Dim i As Integer = gridCobranzaDescuentos.Rows.Count

                gridCobranzaDescuentos.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
                gridCobranzaDescuentos.DisplayLayout.Override.CellClickAction = CellClickAction.Edit

            Next

        End If

    End Sub

    Private Sub gridCobranzaDescuentos_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridCobranzaDescuentos.BeforeExitEditMode
        Try
            Dim cellIndex As Integer = gridCobranzaDescuentos.ActiveCell.Column.Index

            If gridCobranzaDescuentos.ActiveRow.DataChanged Then

            Else
                If gridCobranzaDescuentos.ActiveCell.DataChanged Then
                Else
                    If String.IsNullOrWhiteSpace(gridCobranzaDescuentos.ActiveCell.Value) Then
                        poblar_gridCobranzaDescuentos(CInt(cboxClienteCliente.SelectedValue))
                        gridCobranzaDescuentos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                    End If
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gridCobranzaDescuentos_AfterRowActivate(sender As Object, e As EventArgs) Handles gridCobranzaDescuentos.AfterRowActivate
        gridCobranzaDescuentos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        For Each row In gridCobranzaDescuentos.Rows
            row.Activation = Activation.NoEdit
        Next
    End Sub

    Private Sub gridCobranzaDescuentos_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridCobranzaDescuentos.BeforeRowDeactivate

        If gridCobranzaDescuentos.ActiveRow.IsFilterRow Then Return

        If gridCobranzaDescuentos.ActiveRow.DataChanged Then

            Dim descuento As New Entidades.DescuentoCliente
            Dim motidoDescuento As New Entidades.MotivoDescuento
            Dim lugarDescuento As New Entidades.LugarDescuento
            Dim cliente As New Entidades.Cliente
            Dim objBU As New Negocios.ClientesDatosBU

            Dim row As UltraGridRow = gridCobranzaDescuentos.ActiveRow

            descuento.descuentosclienteid = CInt(gridCobranzaDescuentos.ActiveRow.Cells(0).Value)


            motidoDescuento.motivodescuentoid = row.Cells(2).Column.ValueList.GetValue(gridCobranzaDescuentos.ActiveRow.Cells(2).Text, 0)
            descuento.motivodescuento = motidoDescuento
            lugarDescuento.lugardescuentoid = row.Cells(4).Column.ValueList.GetValue(gridCobranzaDescuentos.ActiveRow.Cells(4).Text, 0)
            descuento.lugardescuento = lugarDescuento
            cliente.clienteid = CInt(gridCobranzaDescuentos.ActiveRow.Cells(9).Value)
            descuento.cliente = cliente

            descuento.descuentoenporcentaje = CBool(gridCobranzaDescuentos.ActiveRow.Cells(5).Value)
            descuento.cantidaddescuento = CDec(gridCobranzaDescuentos.ActiveRow.Cells(6).Value)
            descuento.diasplazo = CInt(gridCobranzaDescuentos.ActiveRow.Cells(7).Value)
            descuento.aplicaencadenado = CDec(gridCobranzaDescuentos.ActiveRow.Cells(8).Value)

            If motidoDescuento.motivodescuentoid = Nothing Then
                descuento.activo = False
            Else
                descuento.activo = True
            End If


            If descuento.descuentosclienteid = 0 Then
                objBU.AltaDescuentosCliente(descuento)
            Else
                objBU.EditarDescuentosCliente(descuento)
            End If

            poblar_gridCobranzaDescuentos(CInt(cboxClienteCliente.SelectedValue))

        Else

        End If

        gridCobranzaDescuentos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

    End Sub

#End Region


#Region "ACCIONES EN DOCK MANAGER(PESTAÑAS DE AREAS OPERATIVAS)        "

    Private Sub dockManagerFichaTecnica_PaneDisplayed(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinDock.PaneDisplayedEventArgs) Handles dockManagerFichaTecnica.PaneDisplayed
        ModoEdicion = False
        ModoEdicion_Almacen = False
        modoEdicion_CEDIS = False
        ModoEdicion_CreditoConbranza = False
        ModoEdicion_Etiquetado = False
        ModoEdicion_MercaDotecnia = False
        editando = False
        editando_politica = False
        Editando_Zapaterias = False
        Editando_Mercadotecnia = False

        ''DATOS
        If Me.dockManagerFichaTecnica.PaneFromControl(Me.pnlDatos).IsInView Then
            AreaOperativa = 7

            ListaPais(cboxDatosPais)
            Try
                poblar_gridContacto(CInt(lblClientePersonaID_Int.Text), gridDatosContacto)
                asignar_grid_gridContacto(gridDatosContacto)

                recuperar_datos_Panel_Datos(cboxClienteCliente.SelectedValue)

            Catch ex As Exception
            End Try
            cboxDatosPoblacion.Enabled = False
        End If
        ''VENTAS
        If Me.dockManagerFichaTecnica.PaneFromControl(Me.pnlVentas).IsInView Then
            AreaOperativa = 2
            claseDocumento = "E"
            ListaEmpresas()
            ListaTipoCliente(cboxVentasTipoCliente)
            Try
                asignar_grid_gridContacto(gridVentasContacto)
                poblar_gridContacto(CInt(lblClientePersonaID_Int.Text), gridVentasContacto)

                asignar_grid_gridDocumentos(gridVentasDocumentos)
                poblar_gridDocumentos(claseDocumento, CInt(lblClienteSAYID_Int.Text), gridVentasDocumentos)

                asignar_grid_gridHistorialValidaciones(gridVentasValidacionHistorial)
                poblar_gridHistorialValidaciones(CInt(lblClienteSAYID_Int.Text), 1, gridVentasValidacionHistorial)

                poblar_gridVentasVendedores(CInt(lblClienteSAYID_Int.Text))

                asignar_grid_gridPolitica(gridVentasPoliticas)
                poblar_gridPolitica(False, CInt(lblClienteSAYID_Int.Text), gridVentasPoliticas)


                recuperar_datos_Panel_Ventas(CInt(lblClienteSAYID_Int.Text))

            Catch ex As Exception
            End Try

        End If

        ''RFC
        If Me.dockManagerFichaTecnica.PaneFromControl(Me.pnlRFC).IsInView Then
            AreaOperativa = 9

            ListaRamos(cboxRFCRamo)
            'ListaRutas(cboxRFCRuta)
            ListaPais(cboxRFCPais)
            ListaClienteRFCFactura(cboxRFCRFCAFacturar, CInt(lblClienteSAYID_Int.Text))
            ListaIncoterms(cboxRFCIncoterm)
            Try

                recuperar_datos_Panel_RFC(0)
                'poblar_gridClienteRFC(cboxClienteCliente.SelectedValue, gridRFCRFC)
                poblar_gridClienteRFC(CInt(lblClienteSAYID_Int.Text), gridRFCRFC)
                asignar_grid_gridClienteRFC(gridRFCRFC)

                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
                    btnRFCAltaRFC.Enabled = True
                Else
                    btnRFCAltaRFC.Enabled = False
                End If
                cboxRFCRFCAFacturar.Enabled = False

            Catch ex As Exception
            End Try


        End If

        ''CEDIS
        If Me.dockManagerFichaTecnica.PaneFromControl(Me.pnlCEDIS).IsInView Then


            AreaOperativa = 10
            'cabecera
            btnEditarCEDISPersona.Enabled = False
            btnGuardarCEDISPersona.Enabled = False
            btnCancelarCEDISPersona.Enabled = False
            'domicilio
            btnEditarCEDISDomicilio.Enabled = False
            btnGuardarCEDISDomicilio.Enabled = False
            btnCancelarCEDISDomicilio.Enabled = False
            'embarque
            btnEditarCEDISEmbarque.Enabled = False
            btnGuardarCEDISEmbarque.Enabled = False
            btnCancelarCEDISEmbarque.Enabled = False
            'empaque
            btnEditarCEDISEmpaque.Enabled = False
            btnGuardarCEDISEmpaque.Enabled = False
            btnCancelarCEDISEmpaque.Enabled = False

            'mensajeria
            btnEditarCEDISMensajeria.Enabled = False
            btnGuardarCEDISMensajeria.Enabled = False
            btnCancelarCEDISMensajeria.Enabled = False

            'panelTECRamos.Enabled = False
            If idcomercializadora = 43 Then
                btnEditarMKTTECR.Enabled = False
                Me.tabControlPanelCEDIS.TabPages("tpgCEDISRamos").Visible = False
                Me.tabControlPanelCEDIS.TabPages("tpgCEDISRamos").Hide()
                btnEditarMKTTECR.Enabled = False
            End If


            ListaRamos(cboxCEDISRamo)
            ListaTipoTiendas(cboxCEDISTipoTienda)
            ListaPais(cboxCEDISPais)
            ListaTipoFlete(cboxCEDISTipoFlete)
            ListaTipoValor(cboxCedisTipoValor)
            ListaTipoEmpaque(cboxCedisTipoEmpaque)
            ListaTamanoEmpaque(cboxCedisTamanoEmpaque)
            Try
                ListaClienteRFC(cboxCEDISRFC, cboxClienteCliente.SelectedValue)
                poblar_gridClienteRFCCEDIS(CInt(lblClientePersonaID_Int.Text), gridCEDISCEDIS)
                asignar_grid_gridClienteRFCCEDIS(gridCEDISCEDIS)

                poblar_gridMKTRamosTEC(CInt(lblClienteSAYID_Int.Text))

                lblCEDISPersonaID_Int.Text = "0"

                recuperar_datos_Panel_CEDIS(CInt(lblCEDISPersonaID_Int.Text))

            Catch ex As Exception

            End Try
        End If

        'COBRANZA
        If Me.dockManagerFichaTecnica.PaneFromControl(Me.pnlCobranza).IsInView Then
            Dim valoresCombos As New DataTable
            AreaOperativa = 3
            claseDocumento = "C"
            ListaFormaPago(cboxCobranzaFormaPago_Old)
            ListaMetodoPago(cboxCobranzaMetodoPago)
            ListaFormaPago_NotaCredito(cmbFormaPagoNotaCreditoCliente)
            ListaMetodoPago_NotaCredito(cmbMetodoPagoNotaCreditoCliente)

            'hola
            Try
                ModoEdicion_CreditoConbranza = False
                poblar_gridContacto(CInt(lblClientePersonaID_Int.Text), gridCobranzaContacto)
                'seleccionarIDCombos_NotaCredito(cmbMetodoPagoNotaCreditoCliente, cmbFormaPagoNotaCreditoCliente, CInt(lblClienteSAYID_Int.Text))
                asignar_grid_gridClienteRFC(gridCobranzaContaRFC)
                poblar_gridClienteRFC(cboxClienteCliente.SelectedValue, gridCobranzaContaRFC)
                asignar_grid_gridDocumentos(gridCobranzaDocumentos)
                poblar_gridDocumentos(claseDocumento, CInt(lblClienteSAYID_Int.Text), gridCobranzaDocumentos)
                poblar_gridContacto(CInt(lblClientePersonaID_Int.Text), gridCobranzaEvalContacto)
                asignar_grid_gridHorario(gridCobranzaContrarecibo)
                poblar_gridHorario(CInt(lblClienteSAYID_Int.Text), gridCobranzaContrarecibo)
                poblar_gridCobranzaDescuentos(CInt(lblClienteSAYID_Int.Text))
                asignar_grid_gridHistorialValidaciones(gridCobranzaValidacionHistorial)
                poblar_gridHistorialValidaciones(CInt(lblClienteSAYID_Int.Text), 2, gridCobranzaValidacionHistorial)
                asignar_grid_gridCobranzaFormasPago(gridCobranzaFormasPago)
                poblar_gridCobranzaFormasPago(CInt(lblClienteSAYID_Int.Text), gridCobranzaFormasPago)
                recuperar_datos_Panel_Cobranza(CInt(lblClienteSAYID_Int.Text))
                obtenerPeriodicidaEstadosCuentas()
            Catch ex As Exception

            End Try
            gboxCobranzaValidacion.Enabled = False
        End If

        'PRECIO
        If Me.dockManagerFichaTecnica.PaneFromControl(Me.pnlPrecio).IsInView Then
            AreaOperativa = 12
            ListaTipoIVA(cboxPrecioIva)
            ListaMonedas(cboxPrecioMoneda)
            ListaTipoFlete(cboxPrecioFlete)
            ListaClienteNacional_Extranjero(cmbNacionalExtranjero, CInt(lblClienteSAYID_Int.Text))
            If cmbNacionalExtranjero.SelectedValue > 1 Then
                ListaIncoterms(cmbINCOTERM)
                cmbINCOTERM.Visible = True
            Else
                cmbINCOTERM.DataSource = Nothing
                cmbINCOTERM.Visible = False
            End If

            ListaListaDePecios(cboxPrecioListaActual, CInt(LTrim(RTrim(lblClienteSAYID_Int.Text))), False, True) ''Actual
            ListaListaDePecios(cboxPrecioListaNueva, CInt(LTrim(RTrim(lblClienteSAYID_Int.Text))), True, False) ''Nueva
            poblar_gridPrecioDescuento(CInt(lblClienteSAYID_Int.Text))
            Try
                asignaStatusControles(gboxMonedaInformacionConfiguracionListaPrecios, False)
                asignaStatusControles(gboxPrecioDescuentos, False)
                asignaStatusControles(pnlBotonesPrecio, False)
                asignaStatusControles(gboxPrecioListasDeVentas, True)
                asignaStatusControles(gboxPrecioValoresdeConfiguracionActual, False)
                asignaStatusControles(gboxPrecioValoresdeConfiguracionAsignar, False)

                'RECUPERA LOS PARAMETROS DE LA LISTA DE PRECIOS PARA ASIGNARLA A LA SECCION DE LA LISTA 
                Recuperar_Valores_De_Lista_De_Precios(cboxPrecioListaActual.SelectedValue, True)
                grdPrecioDescuentos.Enabled = False
                recuperar_Informacion_Cliente_Para_Configurar_Lista_Precios()

                btnPrecioAsignarListadeVentas.Enabled = False
                btnPrecioAsignarListadeVentas.Enabled = False
                cboxPrecioListaActual.Enabled = False
                cboxPrecioListaActual.Enabled = False

                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
                    btnEditarPrecio.Enabled = True
                    btnListadoPreciosPanelPrecio.Enabled = True
                    cboxPrecioListaNueva.Enabled = True
                Else
                    btnEditarPrecio.Enabled = False
                    btnListadoPreciosPanelPrecio.Enabled = True
                    cboxPrecioListaNueva.Enabled = False
                End If

                'VALIDAMOS SI CUENTA CON LISTAS DE PRECIOS CAPTURADAS O ACEPTADAS PARA DESHABILITAR EL CAMBIO DE MONEDA Y EL CAMBIO DE 
                ValidarPermitirCambioLP_y_Moneda(CInt(cboxPrecioListaActual.SelectedValue), CInt(LTrim(RTrim(lblClienteSAYID_Int.Text))))
                If lista_RecuperadA.Length = 2 Then
                    btnImprimir.Enabled = True
                    btnListadoPreciosPanelPrecio.Enabled = False
                ElseIf lista_RecuperadA.Length < 3 Then
                    btnListadoPreciosPanelPrecio.Enabled = False
                    btnImprimir.Enabled = False
                Else
                    btnPrecioAsignarListadeVentas.Enabled = False
                End If
                chkCalcularConDescuentoAplicado.ForeColor = Color.Black
                txtnota.Text = LlenarDetalleNotaListaPrecio(CInt(cboxPrecioListaActual.SelectedValue), CInt(LTrim(RTrim(lblClienteSAYID_Int.Text))))
                validarPermisosListaVentas()

                Dim objBU As New Negocios.ClientesBU
                bloquear_ListasDePrecios = objBU.ValidarListaDePrecios_Aceptada_o_capturada_asignadas(CInt(LTrim(RTrim(lblClienteSAYID_Int.Text))))


            Catch ex As Exception
                ' Throw ex
            End Try

        End If

        'ALMACEN
        If Me.dockManagerFichaTecnica.PaneFromControl(Me.pnlAlmacen).IsInView Then
            AreaOperativa = 1
            ListaAlmacen(cboxAlmacenAlmacen)
            ListaTipoFleje(cboxAlmacenTipoFleje)
            ListaProtectorFleje(cboxAlmacenProtectorFleje)
            ListaUnidadDeVenta(cboxAlmacenUnidadDeVenta)
            ListaLugarEntrega(cboxAlmacenEntregaMercancia)
            ListaRestriccionesFacturacion(cboxAlmacenRestricciones)
            ListaTipoEmpaque(cboxAlmacenTipoEmpaque)
            'ListaTipoEtiqueta(cboxAlmacenEtiquetaEspecialCliente)
            Try
                editando_politica = False
                asignar_grid_gridPolitica(gridAlmacenPoliticas)
                poblar_gridPolitica(False, CInt(lblClienteSAYID_Int.Text), gridAlmacenPoliticas)

                asignar_grid_gridHorario(gridAlmacenDiasEntrega)
                poblar_gridHorario(CInt(lblClienteSAYID_Int.Text), gridAlmacenDiasEntrega)

                'poblar_gridAlmacenDiasEntrega(CInt(lblClienteSAYID_Int.Text))
                recuperar_datos_Panel_Almacen(CInt(lblClienteSAYID_Int.Text))
            Catch ex As Exception

            End Try
        End If

        ''ETIQUETADO
        If Me.dockManagerFichaTecnica.PaneFromControl(Me.pnlEtiquetado).IsInView Then
            AreaOperativa = 11

            ListaTipoFleje(cboxEtiquetadoTipoFleje)
            ListaProtectorFleje(cboxEtiquetadoProtectorFleje)

            Try
                asignar_grid_gridPolitica(gridEtiquetadoPoliticas)
                poblar_gridPolitica(False, cboxClienteCliente.SelectedValue, gridEtiquetadoPoliticas)
                poblar_gridEtiquetadoEtiquetado(CInt(lblClienteSAYID_Int.Text))
                poblar_gridEtiquetadoReqEspecial(CInt(lblClienteSAYID_Int.Text))
                poblar_gridCorridasExtranjeras(CInt(lblClienteSAYID_Int.Text))
                recuperar_datos_Panel_Etiquetado(CInt(lblClienteSAYID_Int.Text))
                chkCodigosAmece.Enabled = False

                Activar_Inactivar_grids(gridEtiquetadoEtiquetado, ModoEdicion_Etiquetado)
                Activar_Inactivar_grids(gridPolitica, ModoEdicion_Etiquetado)
                Activar_Inactivar_grids(gridEtiquetadoReqEspecial, ModoEdicion_Etiquetado)
                Activar_Inactivar_grids(grdCorridasExtranjeras, ModoEdicion)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

        ''MERCADOTECNIA
        If Me.dockManagerFichaTecnica.PaneFromControl(Me.pnlMercadotecnia).IsInView Then
            AreaOperativa = 5
            ListaNivelSocioEconomico(cboxMKTNivelSocioEconomico)
            Try
                asignar_grid_gridContacto(gridMKTContacto)
                poblar_gridContacto(CInt(lblClientePersonaID_Int.Text), gridMKTContacto)
                poblar_gridMKTTienda(CInt(lblClienteSAYID_Int.Text))
                poblar_gridMKTRamos(CInt(lblClienteSAYID_Int.Text))
                poblar_gridMKTZapaterias(CInt(lblClienteSAYID_Int.Text))
                poblar_gridMKTMaterialMKT(CInt(lblClienteSAYID_Int.Text))
                recuperar_datos_Panel_MKT(CInt(lblClienteSAYID_Int.Text))
            Catch ex As Exception

            End Try
        End If


        setPermisos()
    End Sub

    Private Sub dockManagerFichaTecnica_BeforeShowFlyout(sender As Object, e As CancelableControlPaneEventArgs) Handles dockManagerFichaTecnica.BeforeShowFlyout
        Dim location As DockedLocation = e.Pane.DockAreaPane.DockedLocation
        Dim pane As DockableControlPane = e.Pane

        If IsDBNull(cboxClienteCliente.SelectedValue) Or txtClienteRazonSocial.TextLength < 1 Then
            e.Cancel = True
            Exit Sub
        End If

        ''DATOS
        If pane.Control.Name.ToString = Me.pnlDatos.Name.ToString Then
            If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "READDATOS") Then
                If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "LEERCOMPLETA") Then
                    e.Cancel = True
                    show_message("Advertencia", "No cuenta con permisos" + vbNewLine + "para consultar esta información")
                    Exit Sub
                End If
            End If
        End If

        ''VENTAS
        If pane.Control.Name.ToString = Me.pnlVentas.Name.ToString Then
            If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "READVENTAS") Then
                If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "LEERCOMPLETA") Then
                    e.Cancel = True
                    show_message("Advertencia", "No cuenta con permisos" + vbNewLine + "para consultar esta información")
                    Exit Sub
                End If
            End If
        End If

        ''RFC
        If pane.Control.Name.ToString = Me.pnlRFC.Name.ToString Then
            If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "READRFC") Then
                If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "LEERCOMPLETA") Then
                    e.Cancel = True
                    show_message("Advertencia", "No cuenta con permisos" + vbNewLine + "para consultar esta información")
                    Exit Sub
                End If
            End If
        End If

        ''CEDIS
        If pane.Control.Name.ToString = Me.pnlCEDIS.Name.ToString Then
            If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "READTEC") Then
                If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "LEERCOMPLETA") Then
                    e.Cancel = True
                    show_message("Advertencia", "No cuenta con permisos" + vbNewLine + "para consultar esta información")
                    Exit Sub
                End If
            End If
        End If

        'COBRANZA
        If pane.Control.Name.ToString = Me.pnlCobranza.Name.ToString Then
            If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "READCREDCOBR") Then
                If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "LEERCOMPLETA") Then
                    e.Cancel = True
                    show_message("Advertencia", "No cuenta con permisos" + vbNewLine + "para consultar esta información")
                    Exit Sub
                End If
            End If
        End If

        'PRECIO
        If pane.Control.Name.ToString = Me.pnlPrecio.Name.ToString Then
            If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "READPRECIO") Then
                If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "LEERCOMPLETA") Then
                    e.Cancel = True
                    show_message("Advertencia", "No cuenta con permisos" + vbNewLine + "para consultar esta información")
                    Exit Sub
                End If
            End If
        End If

        'ALMACEN
        If pane.Control.Name.ToString = Me.pnlAlmacen.Name.ToString Then
            If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "READALMACEN") Then
                If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "LEERCOMPLETA") Then
                    e.Cancel = True
                    show_message("Advertencia", "No cuenta con permisos" + vbNewLine + "para consultar esta información")
                    Exit Sub
                End If
            End If
        End If

        ''ETIQUETADO
        If pane.Control.Name.ToString = Me.pnlEtiquetado.Name.ToString Then
            If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "READETIQUETADO") Then
                If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "LEERCOMPLETA") Then
                    e.Cancel = True
                    show_message("Advertencia", "No cuenta con permisos" + vbNewLine + "para consultar esta información")
                    Exit Sub
                End If
            End If
        End If

        ''MERCADOTECNIA
        If pane.Control.Name.ToString = Me.pnlMercadotecnia.Name.ToString Then
            If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "READMERCADOTECNIA") Then
                If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "LEERCOMPLETA") Then
                    e.Cancel = True
                    show_message("Advertencia", "No cuenta con permisos" + vbNewLine + "para consultar esta información")
                    Exit Sub
                End If
            End If

        End If

    End Sub



    Private Sub tabCobranzaEval_MouseEnter(sender As Object, e As EventArgs) Handles tpgCobranzaCobranzaEval.MouseEnter
        Try
            asignar_grid_gridContacto(gridCobranzaEvalContacto)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gboxGridCobranzaContacto_Enter(sender As Object, e As EventArgs) Handles gboxCobranzaContacto.Enter
        Try
            asignar_grid_gridContacto(gridCobranzaContacto)
        Catch ex As Exception
        End Try
    End Sub

#End Region

    Private Sub cboxClienteCliente_Leave(sender As Object, e As EventArgs) Handles cboxClienteCliente.Leave
        If alta_cliente Then
            txtClienteRazonSocial.Text = cboxClienteCliente.Text
        End If
    End Sub
    Private Sub cboxListaDePreciosEncabezado_EnabledChanged(sender As Object, e As EventArgs) Handles cboxListaDePreciosEncabezado.EnabledChanged
        If cboxListaDePreciosEncabezado.Enabled = True Then
            cboxListaDePreciosEncabezado.Enabled = False
        End If
    End Sub

    ''ventas
    Private Sub lblGuardarVentas_ForeColorChanged(sender As Object, e As EventArgs) Handles lblGuardarVentas.ForeColorChanged
        If lblGuardarVentas.ForeColor <> Color.DodgerBlue Then
            lblGuardarVentas.ForeColor = Color.DodgerBlue
        End If
    End Sub
    Private Sub lblEditarVentas_ForeColorChanged(sender As Object, e As EventArgs) Handles lblEditarVentas.ForeColorChanged
        If lblEditarVentas.ForeColor <> Color.DodgerBlue Then
            lblEditarVentas.ForeColor = Color.DodgerBlue
        End If
    End Sub
    Private Sub lblCancelarVentas_ForeColorChanged(sender As Object, e As EventArgs) Handles lblCancelarVentas.ForeColorChanged
        If lblCancelarVentas.ForeColor <> Color.DodgerBlue Then
            lblCancelarVentas.ForeColor = Color.DodgerBlue
        End If
    End Sub

    ''datos
    Private Sub lblGuardarDatos_ForeColorChanged(sender As Object, e As EventArgs) Handles lblGuardarDatos.ForeColorChanged
        If lblGuardarDatos.ForeColor <> Color.DodgerBlue Then
            lblGuardarDatos.ForeColor = Color.DodgerBlue
        End If
    End Sub

    Private Sub lblEditarDatos_ForeColorChanged(sender As Object, e As EventArgs) Handles lblEditarDatos.ForeColorChanged
        If lblEditarDatos.ForeColor <> Color.DodgerBlue Then
            lblEditarDatos.ForeColor = Color.DodgerBlue
        End If
    End Sub

    Private Sub lblCancelarDatos_ForeColorChanged(sender As Object, e As EventArgs) Handles lblCancelarDatos.ForeColorChanged
        If lblCancelarDatos.ForeColor <> Color.DodgerBlue Then
            lblCancelarDatos.ForeColor = Color.DodgerBlue
        End If
    End Sub

    ''ACTIVAR_INACTIVAR CUALQUIER GRID
    Private Sub Activar_Inactivar_grids(ByVal grid As UltraGrid, ByVal Activacion As Boolean)
        If Activacion = True Then
            grid.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
            For Each row In grid.Rows
                row.Activation = Activation.AllowEdit
            Next
        Else
            grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            For Each row In grid.Rows
                row.Activation = Activation.NoEdit
            Next
        End If

        If AreaOperativa = 11 Then
            If Activacion = True Then
                'gridEtiquetadoEtiquetado.DisplayLayout.Bands(0).Columns(6).Style = ColumnStyle.Button
                gridEtiquetadoEtiquetado.DisplayLayout.Bands(0).Columns(6).Style = ColumnStyle.CheckBox
            Else
                'gridEtiquetadoEtiquetado.DisplayLayout.Bands(0).Columns(6).Style = ColumnStyle.FormattedText
                gridEtiquetadoEtiquetado.DisplayLayout.Bands(0).Columns(6).Style = ColumnStyle.CheckBox
            End If
        End If

        If AreaOperativa = 5 Then
            For Each ROW As UltraGridRow In gridMKTTienda.Rows
                ROW.Cells(0).Activation = Activation.ActivateOnly
                ROW.Cells(1).Activation = Activation.ActivateOnly
                ROW.Cells(2).Activation = Activation.ActivateOnly
                ROW.Cells(3).Activation = Activation.ActivateOnly
            Next

            For Each ROW As UltraGridRow In gridMKTRamos.Rows
                ROW.Cells(0).Activation = Activation.ActivateOnly
                ROW.Cells(1).Activation = Activation.ActivateOnly
                ROW.Cells(2).Activation = Activation.ActivateOnly
                ROW.Cells(3).Activation = Activation.ActivateOnly
            Next

            For Each ROW As UltraGridRow In gridMKTZapaterias.Rows
                ROW.Cells(3).Activation = Activation.AllowEdit
                ROW.Cells(3).Style = ColumnStyle.DropDownValidate
            Next
        End If
    End Sub

    Private Sub LimpiarFiltrosGrid(ByVal Grid As UltraGrid)
        For Each band In Grid.DisplayLayout.Bands
            band.ColumnFilters.ClearAllFilters()
        Next
    End Sub

    Private Sub btnPrecioAsignarListadeVentas_EnabledChanged(sender As Object, e As EventArgs) Handles btnPrecioAsignarListadeVentas.EnabledChanged
        If bloquear_ListasDePrecios = True And btnPrecioAsignarListadeVentas.Enabled = True Then
            ' btnPrecioAsignarListadeVentas.Enabled = False
        ElseIf bloquear_ListasDePrecios = True Then
            btnPrecioAsignarListadeVentas.Enabled = False
        End If

    End Sub

End Class