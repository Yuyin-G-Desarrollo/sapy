Imports Proveedores.BU
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports Entidades
Imports System.Windows.Forms
Imports Persistencia
Imports System.Drawing
Imports System.Net
Imports System.Text.RegularExpressions

Public Class AltaProveedoresForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Dim IDPersona As Int32
    Dim idproveedorNuevo As Int32
    Dim idproveedorNuevoSICY As Int32
    Dim CamposGenerales As Boolean
    Dim CamposRFC As Boolean
    Dim CamposCuenta As Boolean
    Dim Camposcontacto As Boolean

    Public proveedorid As Integer
    Public nombreComercial As String
    Public catego As String
    Public pais As String
    Public giro As String
    Public paginaweb As String
    Public tipodecompra As String
    Public limitedecredito As Double
    Public tiempodeentrega As String
    Public tiempoderespuesta As String
    Public usuariomodifico As Integer
    Public fechamodifico As DateTime
    Public activo As String
    Public nave As Integer
    Public navNombre As String
    Public IDSICY As Integer
    Public numeroCobrador As Integer
    Dim idproveedorCuentaSICY As Integer
    Dim x As Integer = 0
    Public BuscarRFC As Boolean
    Public BuscarCuenta As Boolean
    Public BuscarUsuario As Boolean
    Public BuscarContacto As Boolean
    Public BuscarPlazo As Boolean
    Public BuscarNave As Boolean
    Public actualizar As Integer = 0
    Public accion As Integer = 0
    Public RFCRepetido As Integer = 0
    Public tipoRazon As Integer = 0

    Public consulta = 0

    Private Sub AltaProveedoresForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.TabDatos.TabPages.Remove(Me.ocho)
        Me.TabDatos.TabPages.Remove(Me.nueve)

        Me.TabDatos.Visible = False

        validacionInicial()
        llenarComboPais()
        llenarComboPais2()
        llenarComboGiros()
        llenarComboCategoria()
        llenarComboTipoRazonSocial()
        cmbTipoRazonSocial.SelectedValue = 0
        txtProveedorid.Text = proveedorid
        txtNave.Text = nave
        txtNombreComercial.Text = nombreComercial
        txtPaginaWeb.Text = paginaweb
        cmbGiro.SelectedValue = CInt(giro)
        cmbCategoria.Text = catego
        'CInt(categoria)
        txtTiempoDeRespuesta.Text = tiempoderespuesta
        txtTiempoDeEntrega.Text = tiempodeentrega
        txtLimiteCredito.Text = limitedecredito
        cmbPaisProveedor.Text = pais

        If activo = "SI" Then
            rdoActivoUsuario.Checked = True
            rdoNoActivoUsuario.Checked = False
        Else
            rdoNoActivoUsuario.Checked = True
            rdoActivoUsuario.Checked = False
        End If

        If txtNombreComercial.Text = "" And txtPaginaWeb.Text = "" And cmbGiro.Text = "" Then
            txtProveedorid.Text = idproveedorNuevo
        Else
            pnlDatosGenerales.Enabled = False
            Me.TabDatos.Visible = True
            If pnlDatosGenerales.Enabled = False Then
                btnGuardar.Visible = False
                lblGuardarPrincipal.Visible = False
            End If
        End If

        Dim objbuProveedor As New ProveedorBU
        idproveedorNuevo = CInt(objbuProveedor.GetIDProveedorRecienIngresado(IDPersona)) + 1
        idproveedorNuevoSICY = CInt(objbuProveedor.UltimoIdSicy(IDPersona)) + 1
        idproveedorCuentaSICY = CInt(objbuProveedor.UltimoIdBancoSicy(IDPersona)) + 1

        If txtNombreComercial.Text = "" Then
            txtProveedorid.Text = idproveedorNuevo
        End If

        txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy")

        LlenarTablaUsuariosActivos()
        Try
            diseniogrdUsuarios()
        Catch ex As Exception

        End Try

        LlenarTablaCuentasBancarias()
        Try
            diseniogrdCuentasBancarias()
        Catch ex As Exception

        End Try

        LlenarTablaContactosCobranza()
        Try
            diseniogrdContactosCobranza()
        Catch ex As Exception

        End Try

        LlenarTablaContactosVentas()
        Try
            diseniogrdContactosVentas()
        Catch ex As Exception

        End Try

        LlenarTablaRFC()
        Try
            diseniogrdRFC()
        Catch ex As Exception

        End Try

        LlenarTablaPlazo()
        Try
            diseniogrdPlazo()
        Catch ex As Exception

        End Try

        LlenarNaves()
        Try
            diseniogrdNaves()
        Catch ex As Exception

        End Try

        LlenarTablaNaveProveedor()
        Try
            diseniogrdNavesProveedor()
        Catch ex As Exception

        End Try

        llenarComboBanco()

        Me.TabDatos.TabPages.Remove(Me.ocho)
        Me.TabDatos.TabPages.Remove(Me.nueve)

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "DATOSDERFC") Then
        Else
            Me.TabDatos.TabPages.Remove(Me.dos)
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "DATOSDECUENTABANCARIA") Then
        Else
            Me.TabDatos.TabPages.Remove(Me.tres)
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "DATOSDECONTACTO") Then
        Else
            Me.TabDatos.TabPages.Remove(Me.cinco)
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "SITIOPROVEEDORES") Then
        Else
            Me.TabDatos.TabPages.Remove(Me.siete)
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "PLAZO DE PAGO") Then
        Else
            Me.TabDatos.TabPages.Remove(Me.seis)
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "ASOCIAR NAVE") Then
        Else
            Me.TabDatos.TabPages.Remove(Me.cuatro)
        End If

        If consulta = 1 Then
            btnGuardar2.Enabled = False
            lblGuardar.Enabled = False
            btnLimpiar.Enabled = False
            lblLimpiar.Enabled = False
            lblCampos.Enabled = False
            btnGuardad3.Enabled = False
            lblGuardar2.Enabled = False
            btnLimpiar2.Enabled = False
            lblLimpiar2.Enabled = False
            lblCampos2.Enabled = False
            btnFoto.Enabled = False
            lblAgregarFoto1.Enabled = False
            btnLimpiar3.Enabled = False
            lblLimpiar3.Enabled = False
            btnGuardar4.Enabled = False
            lblGuardar4.Enabled = False
            btnLimpiarCuentas.Enabled = False
            Label18.Enabled = False
            btnGuardarCambios.Enabled = False
            lblGuardarCambios.Enabled = False
            grdPlazo.Enabled = False
            grdPlazoProveedor.Enabled = False
            grdNavesDisponibles.Enabled = False
            grdNavesAsociadas.Enabled = False
        End If

        cmbTipoRazonSocial.SelectedValue = tipoRazon
    End Sub

    Public Sub GuardarProveedor()
        Dim EntidadProveedor As New DatosGenerales
        Dim objbu As New ProveedorBU

        If cmbTipoRazonSocial.SelectedValue <> 0 Then
            EntidadProveedor.dage_nombrecomercial = txtNombreComercial.Text
        Else
            EntidadProveedor.dage_nombrecomercial = txtNombreComercial.Text 
        End If
        If txtPaginaWeb.Text = "" Then
            EntidadProveedor.dage_paginaweb = "-"
        Else
            EntidadProveedor.dage_paginaweb = txtPaginaWeb.Text
        End If
        EntidadProveedor.dage_giro = cmbGiro.SelectedValue
        EntidadProveedor.dage_categoria = cmbCategoria.SelectedValue
        If txtLimiteCredito.Text = 0 Or txtLimiteCredito.Text = "" Then
            EntidadProveedor.dage_limitedecredito = 1
        Else
            EntidadProveedor.dage_limitedecredito = CInt(txtLimiteCredito.Text)
        End If
        If txtTiempoDeRespuesta.TextLength = 0 Or txtTiempoDeRespuesta.Text = "" Then
            EntidadProveedor.dage_tiempoderespuesta = 1
        Else
            EntidadProveedor.dage_tiempoderespuesta = CInt(txtTiempoDeRespuesta.Text)
        End If
        If txtTiempoDeEntrega.TextLength = 0 Or txtTiempoDeEntrega.Text = "" Then
            EntidadProveedor.dage_tiempodeentrega = 1
        Else
            EntidadProveedor.dage_tiempodeentrega = CInt(txtTiempoDeEntrega.Text)
        End If
        EntidadProveedor.dage_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadProveedor.dage_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadProveedor.dage_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadProveedor.dage_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        If rdoProveedorNoActivo.Checked = True Then
            EntidadProveedor.dage_activo = "NO"
        Else
            EntidadProveedor.dage_activo = "SI"
        End If
        EntidadProveedor.dage_pais = cmbPaisProveedor.Text
        EntidadProveedor.dage_paisid = cmbPaisProveedor.SelectedValue
        objbu.AltaProveedorDatosGenerales(EntidadProveedor)
    End Sub

    ''' <summary>
    '''   REPLICACION AL SICY*********************************************************************************************************************************************
    ''' </summary>
    ''' <remarks></remarks>
    ''' 

    Public Sub GuardarProveedorSICY()
        Dim EntidadProveedorSICY As New DatosGeneralesSICY
        Dim objbu As New ProveedorBU

        EntidadProveedorSICY.dage_idProveedorSICY = idproveedorNuevoSICY
        EntidadProveedorSICY.dage_RazonSocial = txtRazonSocial.Text
        EntidadProveedorSICY.dage_NombreComercial = txtNombreComercial.Text
        EntidadProveedorSICY.dage_FechaAlta = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadProveedorSICY.dage_clasificacion = cmbCategoria.SelectedValue
        EntidadProveedorSICY.dage_Tipo = 1
        If txtTiempoDeRespuesta.Text = "" Then
            EntidadProveedorSICY.dage_Tiempo = 1
        Else
            EntidadProveedorSICY.dage_Tiempo = txtTiempoDeRespuesta.Text
        End If
        If txtTiempoDeEntrega.Text = "" Then
            EntidadProveedorSICY.dage_Entregar = 1
        Else
            EntidadProveedorSICY.dage_Entregar = txtTiempoDeEntrega.Text
        End If
        EntidadProveedorSICY.dage_DiasCredito = 1
        If txtLimiteCredito.Text = "" Or txtLimiteCredito.Text = 0 Then
            EntidadProveedorSICY.dage_CreditoLimite = 1
        Else
            EntidadProveedorSICY.dage_CreditoLimite = txtLimiteCredito.Text
        End If
        If rdoProveedorNoActivo.Checked = True Then
            EntidadProveedorSICY.dage_Estatus = "No activo"
        Else
            EntidadProveedorSICY.dage_Estatus = "Activo"
        End If
        EntidadProveedorSICY.dage_DiaPago = "MIERCOLES"
        EntidadProveedorSICY.dage_TipoFactura = 1
        EntidadProveedorSICY.dage_Cadena = 5
        EntidadProveedorSICY.dage_pctFactura = 0
        EntidadProveedorSICY.dage_checarmanual = 1
        EntidadProveedorSICY.dage_NombreRepresentanteLegal = " "
        EntidadProveedorSICY.dage_PuestoRespresentanteLegal = " "
        EntidadProveedorSICY.dage_EmailRepresentanteLegal = " "
        EntidadProveedorSICY.dage_TelRepresentanteLegal = " "
        EntidadProveedorSICY.dage_CobranzaEmail = " "
        EntidadProveedorSICY.dage_VentasEmail = " "
        EntidadProveedorSICY.dage_HoraPago = "16:00"
        EntidadProveedorSICY.dage_ValidarFolio = 1
        EntidadProveedorSICY.dage_TamanoSerie = 4
        EntidadProveedorSICY.dage_Series = " "
        EntidadProveedorSICY.dage_CompletarFolio = 0
        EntidadProveedorSICY.dage_Observaciones = "CAPTURA SAY"
        EntidadProveedorSICY.dage_CaracterCompletar = "#"
        EntidadProveedorSICY.dage_IdCatGiro = cmbGiro.SelectedValue
        If txtRfcRazonSocial.Text = "" Then
            EntidadProveedorSICY.dage_rfc = txtProveedorid.Text + "NORFC" + idproveedorNuevoSICY.ToString
        Else
            EntidadProveedorSICY.dage_rfc = txtRfcRazonSocial.Text
        End If
        EntidadProveedorSICY.prov_NomPagoDoc = txtRazonSocial.Text
        EntidadProveedorSICY.prov_Calle = txtCalle.Text
        EntidadProveedorSICY.dage_IdProveedor = txtProveedorid.Text
        EntidadProveedorSICY.prov_Colonia = txtColonia.Text
        EntidadProveedorSICY.prov_CodPost = txtCodigoPostal.Text
        EntidadProveedorSICY.prov_CURP = txtCurp.Text
        EntidadProveedorSICY.prov_IdCiudad = cmbCiudadRazonSocial.SelectedValue
        objbu.AltaProveedorDatosGeneralesSICY(EntidadProveedorSICY)

    End Sub

    Public Sub GuardarRFCSICY()
        Dim EntidadRFCSICY As New DatosProveedorSICY
        Dim objbu As New ProveedorBU

        EntidadRFCSICY.prov_RazonSocial = txtRazonSocial.Text
        EntidadRFCSICY.prov_NomPagoDoc = txtRazonSocial.Text
        EntidadRFCSICY.prov_Calle = txtCalle.Text
        EntidadRFCSICY.prov_Colonia = txtColonia.Text
        EntidadRFCSICY.prov_CodPost = txtCodigoPostal.Text
        EntidadRFCSICY.prov_RFC = txtRfcRazonSocial.Text
        EntidadRFCSICY.prov_CURP = txtCurp.Text
        EntidadRFCSICY.prov_IdCiudad = cmbCiudadRazonSocial.SelectedValue
        EntidadRFCSICY.prov_NombreRepresentanteLegal = txtRazonSocial.Text
        EntidadRFCSICY.prov_IdProveedor = txtProveedorid.Text
        EntidadRFCSICY.prov_idsicy = idproveedorNuevoSICY
        objbu.AltaRFCSICY(EntidadRFCSICY)

    End Sub

    Public Sub GuardarContactoCobranzaSICY()

        Dim EntidadContactoCobranzaSICY As New DatosContactoSICY
        Dim objbu As New ProveedorBU

        EntidadContactoCobranzaSICY.daco_rutafoto = txtFoto.Text
        EntidadContactoCobranzaSICY.daco_telcobranza = txtTelefonoContacto.Text
        EntidadContactoCobranzaSICY.daco_contactocobranza = txtNombreContacto.Text
        EntidadContactoCobranzaSICY.daco_CobranzaEmail = txtEmailContacto.Text
        EntidadContactoCobranzaSICY.daco_ContactoPagos = txtNombreContacto.Text
        EntidadContactoCobranzaSICY.daco_IdProveedor = txtProveedorid.Text
        objbu.AltaContactoCobranzaSICY(EntidadContactoCobranzaSICY)

    End Sub

    Public Sub GuardarContactoVentasSICY()

        Dim EntidadContactoVentasSICY As New DatosContactoSICY
        Dim objbu As New ProveedorBU

        EntidadContactoVentasSICY.daco_Email = txtEmailContacto.Text
        EntidadContactoVentasSICY.daco_ContactoVentas = txtNombreContacto.Text
        EntidadContactoVentasSICY.daco_telcontact = txtTelefonoContacto.Text
        EntidadContactoVentasSICY.daco_Telefono = txtTelefonoContacto.Text
        EntidadContactoVentasSICY.daco_VentasEmail = txtEmailContacto.Text
        EntidadContactoVentasSICY.daco_IdProveedor = txtProveedorid.Text
        objbu.AltaContactoVentasSICY(EntidadContactoVentasSICY)

    End Sub

    Public Sub GuardarPlazoSICY()

        Dim EntidadPlazoSICY As New PlazoProveedoresSICY
        Dim objbu As New ProveedorBU

        EntidadPlazoSICY.plpr_DiasCredito = grdPlazo.ActiveRow.Cells("DIAS").Text
        EntidadPlazoSICY.plpr_IdProveedor = txtProveedorid.Text
        objbu.AltaPlazoSICY(EntidadPlazoSICY)

    End Sub

    Public Sub GuardarBancoSICY()

        Dim EntidadBancoSICY As New DatosDeCuentaBancariaSICY
        Dim objbu As New ProveedorBU

        EntidadBancoSICY.banc_idBanco = cmbBanco.SelectedValue
        EntidadBancoSICY.banc_tipcta = 2
        EntidadBancoSICY.banc_cuentabco = txtCuenta.Text
        If rdoCuentaNoActiva.Checked = True Then
            EntidadBancoSICY.banc_stCta = "B"
        Else
            EntidadBancoSICY.banc_stCta = "A"
        End If
        EntidadBancoSICY.banc_usualta = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadBancoSICY.banc_fechaalta = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadBancoSICY.banc_usubaja = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        If cmbTipoCuenta.Text = "FISCAL" Then
            EntidadBancoSICY.banc_fiscal = 1
        Else
            EntidadBancoSICY.banc_fiscal = 0
        End If
        EntidadBancoSICY.banc_cuentahabiente = txtCuentahabiente.Text.Trim.Replace("  ", "")
        EntidadBancoSICY.banc_ClabeInterbancaria = txtClabe.Text
        EntidadBancoSICY.banc_SucursalPlaza = txtSucursal.Text + " " + txtPlaza.Text
        EntidadBancoSICY.banc_Predet = 1
        EntidadBancoSICY.banc_idProveedor = txtProveedorid.Text
        EntidadBancoSICY.banc_Email = " "
        EntidadBancoSICY.banc_TelefonoCuenta = " "
        EntidadBancoSICY.banc_id = idproveedorCuentaSICY

        objbu.AltaBancoSICY(EntidadBancoSICY)

    End Sub

    Public Sub GuardarCobradorSICY()

        Dim EntidadesCobradorSICY As New DatosCobradorSICY
        Dim objbu As New ProveedorBU

        EntidadesCobradorSICY.cobr_idproveedor = txtProveedorid.Text
        '*******************************************BUSCAR LOS COBRADORES INSERTADOS Y ASIGNAR UN ID DEACUERDO AL NUMERO DE REGISTROS
        EntidadesCobradorSICY.cobr_idcobrador = numeroCobrador + 1
        '*******************************************
        EntidadesCobradorSICY.cobr_Nombre = txtNombreContacto.Text
        EntidadesCobradorSICY.cobr_Estatus = " "
        EntidadesCobradorSICY.cobr_UsuCreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadesCobradorSICY.cobr_fechacreo = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadesCobradorSICY.cobr_usumod = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadesCobradorSICY.cobr_fecultmov = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadesCobradorSICY.cobr_RutaFoto = txtFoto.Text

        objbu.AltaCobradorSICY(EntidadesCobradorSICY)

    End Sub

    Public Sub BuscarNumeroCobrador()

        Dim EntidadesCobradorSICY As New DatosCobradorSICY
        Dim objbu As New ProveedorBU

        objbu.AltaCobradorSICY(EntidadesCobradorSICY)

    End Sub

    ''' <summary>
    ''' Fin Replicacion a SICY **********************************************************************************************************************************************
    ''' </summary>
    ''' <remarks></remarks>
    ''' 

    Public Sub GuardarUsuario()
        Dim EntidadUsuario As New UsuarioProveedor
        Dim objbu As New ProveedorBU
        EntidadUsuario.dage_nombreUsuario = txtNombreUsuario.Text
        EntidadUsuario.upro_usuario = txtUsuario.Text
        EntidadUsuario.upro_password = txtContraseña.Text
        EntidadUsuario.dage_proveedorid = txtProveedorid.Text
        EntidadUsuario.upro_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadUsuario.upro_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadUsuario.upro_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadUsuario.upro_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        If rdoNoActivoUsuario.Checked = True Then
            EntidadUsuario.upro_activo = "NO"
        Else
            EntidadUsuario.upro_activo = "SI"
        End If
        objbu.AltaProveedorUsuario(EntidadUsuario)
    End Sub

    Public Sub ModificarUsuario()
        Dim EntidadUsuario As New UsuarioProveedor
        Dim objbu As New ProveedorBU
        EntidadUsuario.dage_nombreUsuario = txtNombreUsuario.Text
        EntidadUsuario.upro_usuario = txtUsuario.Text
        EntidadUsuario.upro_password = txtContraseña.Text
        EntidadUsuario.dage_proveedorid = txtProveedorid.Text
        EntidadUsuario.upro_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadUsuario.upro_usuarioproveedorid = CInt(txtIdUsuario.Text)
        If rdoNoActivoUsuario.Checked = True Then
            EntidadUsuario.upro_activo = "NO"
        Else
            EntidadUsuario.upro_activo = "SI"
        End If
        EntidadUsuario.upro_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        objbu.EditarProveedorUsuario(EntidadUsuario)
    End Sub

    Public Sub GuardarContacto()
        Dim EntidadContacto As New DatosContacto
        Dim objbu As New ProveedorBU

        EntidadContacto.daco_nombre = txtNombreContacto.Text
        EntidadContacto.daco_cargo = txtCargoContacto.Text
        EntidadContacto.daco_telefono = txtTelefonoContacto.Text
        EntidadContacto.daco_notificaciondepago = cmbNotificar.Text
        EntidadContacto.daco_email = txtEmailContacto.Text
        EntidadContacto.daco_departamento = cmbDepartamentoContaco.Text
        EntidadContacto.dage_proveedorid = CInt(txtProveedorid.Text)
        EntidadContacto.daco_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadContacto.daco_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadContacto.daco_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadContacto.daco_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadContacto.daco_foto = txtFoto.Text
        If rdoContactoNoActivo.Checked = True Then
            EntidadContacto.daco_activo = "NO"
        Else
            EntidadContacto.daco_activo = "SI"
        End If
        objbu.AltaProveedorDatosContacto(EntidadContacto)
    End Sub

    Public Sub GuardarCuenta()
        Dim EntidadCuenta As New DatosDeCuentaBancaria
        Dim objbu As New ProveedorBU

        EntidadCuenta.dcba_banco = cmbBanco.Text
        EntidadCuenta.dcba_cuenta = txtCuenta.Text
        EntidadCuenta.dcba_clabe = txtClabe.Text
        EntidadCuenta.dcba_cuentahabiente = txtCuentahabiente.Text
        EntidadCuenta.dcba_plaza = txtPlaza.Text
        EntidadCuenta.dcba_sucursal = txtSucursal.Text
        If rdoCuentaPredeterminada.Checked = True Then
            EntidadCuenta.dcba_predeterminada = "SI"
        Else : EntidadCuenta.dcba_predeterminada = "NO"
        End If
        If rdoCuentaActiva.Checked = True Then
            EntidadCuenta.dcba_activa = "SI"
        Else
            EntidadCuenta.dcba_activa = "NO"
        End If
        EntidadCuenta.dcba_fechadealta = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadCuenta.dcba_usuariocreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadCuenta.dage_proveedorid = CInt(txtProveedorid.Text)
        EntidadCuenta.dcba_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadCuenta.dcba_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadCuenta.dcba_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadCuenta.dcba_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadCuenta.dcba_tipodecuenta = cmbTipoCuenta.Text
        EntidadCuenta.dcba_rfc = cmbRfcCuenta.Text
        EntidadCuenta.dage_bancoid = cmbBanco.SelectedValue

        objbu.AltaProveedorCuentaBancaria(EntidadCuenta)
    End Sub

    Public Sub GuardarProveedorRFC()
        Dim EntidadRFC As New DatosProveedor
        Dim objbu As New ProveedorBU

        '--------------------
        If txtRfcRazonSocial.TextLength = 0 Then
            EntidadRFC.prov_rfc = "-"
        Else
            EntidadRFC.prov_rfc = txtRfcRazonSocial.Text
            objbu.BuscarRfcSicy(txtRfcRazonSocial.Text)
        End If

        '--------------------
        If cmbTipoFiscal.Text = "" Then
            EntidadRFC.prov_tiporazonsocial = "-"
        Else
            EntidadRFC.prov_tiporazonsocial = cmbTipoFiscal.Text
        End If
        '-------------
        If cmbTipoDePersona.Text = "" Then
            EntidadRFC.prov_tipofiscal = "-"
        Else
            EntidadRFC.prov_tipofiscal = cmbTipoDePersona.Text
        End If
        '-------------
        If txtCurp.TextLength = 0 Then
            EntidadRFC.prov_curp = "-"
        Else
            EntidadRFC.prov_curp = txtCurp.Text
        End If
        '--------------
        EntidadRFC.prov_colonia = txtColonia.Text
        EntidadRFC.prov_ciudad = cmbCiudadRazonSocial.Text
        EntidadRFC.prov_calle = txtCalle.Text
        EntidadRFC.prov_numeroexterior = txtNumeroExterior.Text
        '-----------------
        If txtNumeroInterior.TextLength = 0 Then
            EntidadRFC.prov_numerointerior = "-"
        Else
            EntidadRFC.prov_numerointerior = txtNumeroInterior.Text
        End If
        '------------
        EntidadRFC.prov_codigopostal = txtCodigoPostal.Text
        EntidadRFC.prov_estado = cmbEstadoRazonSocial.Text
        If rdoSiActivoCompras.Checked = True Then
            EntidadRFC.prov_activoordenesdecompra = "SI"
            EntidadRFC.prov_activocompras = "SI"
        Else
            EntidadRFC.prov_activoordenesdecompra = "NO"
            EntidadRFC.prov_activocompras = "NO"
        End If
        If rdoSiActivoPagos.Checked = True Then
            EntidadRFC.prov_activopagos = "SI"
        Else
            EntidadRFC.prov_activopagos = "NO"
        End If
        '-----------------
        If txtNombre.TextLength = 0 Then
            EntidadRFC.prov_nombre = "-"
        Else
            EntidadRFC.prov_nombre = txtNombre.Text
        End If
        '----------------
        If txtApellidoPaterno.TextLength = 0 Then
            EntidadRFC.prov_apellidopaterno = "-"
        Else
            EntidadRFC.prov_apellidopaterno = txtApellidoPaterno.Text
        End If
        '---------------
        If txtApellidoMaterno.TextLength = 0 Then
            EntidadRFC.prov_apellidomaterno = "-"
        Else
            EntidadRFC.prov_apellidomaterno = txtApellidoMaterno.Text
        End If
        '---------------
        EntidadRFC.dage_proveedorid = txtProveedorid.Text
        '***************************************************************
        '***************************************************************'
        '***************************************************************
        '***************************************************************
        '***************************************************************

        If txtSicy.TextLength = 0 Then
            EntidadRFC.prov_rfcsicy = idproveedorNuevoSICY
        Else
            EntidadRFC.prov_rfcsicy = txtSicy.Text
        End If

        EntidadRFC.prov_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadRFC.prov_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadRFC.prov_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadRFC.prov_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        If txtRazonSocial.TextLength = 0 Then
            EntidadRFC.prov_razonsocial = "-"
        Else
            Dim x = txtRazonSocial.Text + "," + cmbTipoRazonSocial.Text
            EntidadRFC.prov_razonsocial = x.Trim.Replace("  ", "")
        End If

        ' EntidadRFC.prov_personaidproveedor is null
        ' EntidadRFC.prov_clasificacionpersonaid = 0
        'EntidadRFC.prov_activo = "1"
        EntidadRFC.prov_pais = cmbPaisRazonSocial.Text
        EntidadRFC.prov_paisid = cmbPaisRazonSocial.SelectedValue
        EntidadRFC.prov_estadoid = cmbEstadoRazonSocial.SelectedValue
        EntidadRFC.prov_ciudadid = cmbCiudadRazonSocial.SelectedValue

        'objInformacion.mensaje = EntidadRFC.prov_paisid.ToString + "---" + EntidadRFC.prov_estadoid.ToString + "---" + EntidadRFC.prov_ciudadid.ToString
        'objInformacion.ShowDialog()

        objbu.AltaProveedorDatos(EntidadRFC)

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        BuscarPoveedoresRepetidos()
        'If BuscarPoveedoresRepetidos() = True Then
        '    Dim formlarioP As New ListaProveedoresForm
        '    'Me.Close()
        '    formlarioP.actualizar()
        'End If
        'actualizar = 1

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim formlarioP As New CatalogoProveedoresForm
        formlarioP.LlenarTabla()
        formlarioP.disenioGrid()
        Me.Close()
        Me.Dispose()
        actualizar = 1
    End Sub

    Private Sub btnAgregarContacto_Click(sender As Object, e As EventArgs)
        GuardarContacto()
        LlenarTablaContactosVentas()
        Try
            diseniogrdContactosVentas()
        Catch ex As Exception
        End Try
        LlenarTablaContactosCobranza()
        Try
            diseniogrdContactosCobranza()
        Catch ex As Exception
        End Try

    End Sub

    '********************** Validaciones
    Public Function ValidacionDatosGenerales() As Boolean
        Dim validaDG As Boolean = True

        If txtNombreComercial.TextLength = 0 Then
            lblNombreComercial.ForeColor = Drawing.Color.Red
        Else
            lblNombreComercial.ForeColor = Drawing.Color.Black
        End If

        If txtProveedorid.TextLength = 0 Then
            lblProveedorid.ForeColor = Drawing.Color.Red
        Else
            lblProveedorid.ForeColor = Drawing.Color.Black
        End If

        If cmbPaisProveedor.SelectedIndex > 0 Then
            lblPaisProveedor.ForeColor = Drawing.Color.Black
        Else
            lblPaisProveedor.ForeColor = Drawing.Color.Red
        End If

        If cmbCategoria.SelectedIndex > 0 Then
            lblCategoria.ForeColor = Drawing.Color.Black
        Else
            lblCategoria.ForeColor = Drawing.Color.Red
        End If

        If cmbGiro.SelectedIndex > 0 Then
            lblGiro.ForeColor = Drawing.Color.Black
        Else
            lblGiro.ForeColor = Drawing.Color.Red
        End If

        If cmbPaisProveedor.SelectedIndex > 0 Then
            lblGiro.ForeColor = Drawing.Color.Black
        Else
            lblGiro.ForeColor = Drawing.Color.Red
        End If

    End Function

    Public Function validacionInicial() As Boolean
        txtCodigoPostal.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtPaginaWeb.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtNombreComercial.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtTiempoDeEntrega.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtTiempoDeRespuesta.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtCalle.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtColonia.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtCurp.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtRfcRazonSocial.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtNombre.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtApellidoPaterno.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtApellidoMaterno.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtRazonSocial.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtSucursal.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtPlaza.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtCuentahabiente.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtNombreContacto.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtCargoContacto.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtEmailContacto.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtNombreUsuario.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtUsuario.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtContraseña.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtNumeroExterior.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtNumeroInterior.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtCuenta.MaxLength = 20
        txtCurp.MaxLength = 18
        txtClabe.MaxLength = 18
        txtRfcRazonSocial.MaxLength = 14
        txtNumeroExterior.MaxLength = 10
        txtNumeroInterior.MaxLength = 10
        txtCodigoPostal.MaxLength = 5
        txtCuentahabiente.MaxLength = 30
        txtPlaza.MaxLength = 30
        txtSucursal.MaxLength = 30
        txtRazonSocial.MaxLength = 100
        txtColonia.MaxLength = 30
        txtCalle.MaxLength = 30
        txtNombre.MaxLength = 30
        txtApellidoMaterno.MaxLength = 30
        txtApellidoPaterno.MaxLength = 30
        txtNombreComercial.MaxLength = 100
        txtPaginaWeb.MaxLength = 30
        txtTiempoDeRespuesta.MaxLength = 2
        txtNombreContacto.MaxLength = 30
        txtCargoContacto.MaxLength = 30
        txtTelefonoContacto.MaxLength = 15
        txtEmailContacto.MaxLength = 50
        txtUsuario.MaxLength = 30
        txtContraseña.MaxLength = 30
        txtCodigoPostal.MaxLength = 5
    End Function

    Public Function ValidacionDatosProveedor() As Boolean
        Dim validaP As Boolean = True

        If cmbTipoFiscal.SelectedIndex > 0 Then
            lblTipoFiscal.ForeColor = Drawing.Color.Black
        Else
            lblTipoFiscal.ForeColor = Drawing.Color.Red
            validaP = False
        End If

        If cmbTipoDePersona.SelectedIndex > 0 Then
            lblTipoDePersona.ForeColor = Drawing.Color.Black
        Else
            lblTipoDePersona.ForeColor = Drawing.Color.Red
            validaP = False
        End If

        If txtCalle.TextLength = 0 Then
            lblCalle.ForeColor = Drawing.Color.Red
        Else
            lblCalle.ForeColor = Drawing.Color.Black
            validaP = False
        End If

        If txtNumeroExterior.TextLength = 0 Then
            lblNumeroExterior.ForeColor = Drawing.Color.Red
        Else
            lblNumeroExterior.ForeColor = Drawing.Color.Black
            validaP = False
        End If

        If txtColonia.TextLength = 0 Then
            lblColonia.ForeColor = Drawing.Color.Red
        Else
            lblColonia.ForeColor = Drawing.Color.Black
            validaP = False
        End If

        If txtCodigoPostal.TextLength = 0 Then
            lblCodigoPostal.ForeColor = Drawing.Color.Red
        Else
            lblCodigoPostal.ForeColor = Drawing.Color.Black
            validaP = False
        End If

        If cmbCiudadRazonSocial.SelectedIndex > 0 Then
            lblCiudad.ForeColor = Drawing.Color.Red
        Else
            lblCiudad.ForeColor = Drawing.Color.Black
            validaP = False
        End If

        If cmbEstadoRazonSocial.SelectedIndex > 0 Then
            lblEstado.ForeColor = Drawing.Color.Red
        Else
            lblEstado.ForeColor = Drawing.Color.Black
            validaP = False
        End If

        If txtRazonSocial.TextLength = 0 Then
            lblRazonSocial.ForeColor = Drawing.Color.Red
        Else
            lblRazonSocial.ForeColor = Drawing.Color.Black
            validaP = False
        End If

        Return validaP
    End Function

    Public Function ValidacionDatosRFC() As Boolean
        Dim validaDG As Boolean = True

        If txtCalle.TextLength = 0 Then
            lblCalle.ForeColor = Drawing.Color.Red
        Else
            lblCalle.ForeColor = Drawing.Color.Black
        End If

        If txtNumeroExterior.TextLength = 0 Then
            lblNumeroExterior.ForeColor = Drawing.Color.Red
        Else
            lblNumeroExterior.ForeColor = Drawing.Color.Black
        End If

        If txtColonia.TextLength = 0 Then
            lblColonia.ForeColor = Drawing.Color.Red
        Else
            lblColonia.ForeColor = Drawing.Color.Black
        End If

        If txtCodigoPostal.TextLength = 0 Then
            lblCodigoPostal.ForeColor = Drawing.Color.Red
        Else
            lblCodigoPostal.ForeColor = Drawing.Color.Black
        End If

        If cmbPaisRazonSocial.SelectedIndex > 0 Then
            lblPais.ForeColor = Drawing.Color.Black
        Else
            lblPais.ForeColor = Drawing.Color.Red
        End If

        If cmbEstadoRazonSocial.SelectedIndex > 0 Then
            lblEstado.ForeColor = Drawing.Color.Black
        Else
            lblEstado.ForeColor = Drawing.Color.Red
        End If

        If cmbCiudadRazonSocial.SelectedIndex > 0 Then
            lblCiudad.ForeColor = Drawing.Color.Black
        Else
            lblCiudad.ForeColor = Drawing.Color.Red
        End If

        If cmbTipoFiscal.SelectedIndex > 0 Then
            lblTipoFiscal.ForeColor = Drawing.Color.Black
            If cmbTipoFiscal.Text = "FISCAL" Then

                If cmbTipoDePersona.SelectedIndex > 0 Then
                    lblTipoDePersona.ForeColor = Drawing.Color.Black


                    If cmbTipoDePersona.Text = "FISICA" Then
                        If txtNombre.TextLength = 0 Then
                            lblNombre.ForeColor = Drawing.Color.Red
                        Else
                            lblNombre.ForeColor = Drawing.Color.Black
                        End If

                        If txtApellidoPaterno.TextLength = 0 Then
                            lblApellidoPaterno.ForeColor = Drawing.Color.Red
                        Else
                            lblApellidoPaterno.ForeColor = Drawing.Color.Black
                        End If

                        If txtApellidoMaterno.TextLength = 0 Then
                            lblApellidoMaterno.ForeColor = Drawing.Color.Red
                        Else
                            lblApellidoMaterno.ForeColor = Drawing.Color.Black
                        End If

                        If txtRfcRazonSocial.TextLength = 0 Then
                            lblRfcRazonSocial.ForeColor = Drawing.Color.Red
                        Else
                            lblRfcRazonSocial.ForeColor = Drawing.Color.Black
                        End If
                    End If
                Else
                    lblTipoDePersona.ForeColor = Drawing.Color.Red
                    Return False
                End If
            ElseIf cmbTipoFiscal.Text = "NO FISCAL" Then
                If txtCurp.TextLength = 0 Then
                    lblCurp.ForeColor = Drawing.Color.Red
                    Return False
                Else
                    lblCurp.ForeColor = Drawing.Color.Black
                End If
            End If
        Else
            lblTipoFiscal.ForeColor = Drawing.Color.Red
        End If

        If txtCalle.TextLength <> 0 And txtColonia.TextLength <> 0 And txtNumeroExterior.TextLength <> 0 And txtCodigoPostal.TextLength <> 0 And cmbPaisRazonSocial.SelectedIndex <> 0 And cmbCiudadRazonSocial.SelectedIndex <> 0 And cmbEstadoRazonSocial.SelectedIndex <> 0 Then
            Return True
        Else
            Return False
        End If

        Return True
    End Function

    Public Function ValidacionDatosCta() As Boolean
        Dim validaDG As Boolean = True

        'If txtPlaza.TextLength = 0 Then
        '    lblPlaza.ForeColor = Drawing.Color.Red
        'Else
        '    lblPlaza.ForeColor = Drawing.Color.Black
        'End If

        If txtCuenta.TextLength = 0 Then
            lblCuenta.ForeColor = Drawing.Color.Red
        Else
            lblCuenta.ForeColor = Drawing.Color.Black
        End If

        If txtClabe.TextLength = 0 Then
            lblClabe.ForeColor = Drawing.Color.Red
        Else
            lblClabe.ForeColor = Drawing.Color.Black
        End If

        'If txtSucursal.TextLength = 0 Then
        '    lblSucursal.ForeColor = Drawing.Color.Red
        'Else
        '    lblSucursal.ForeColor = Drawing.Color.Black
        'End If

        If txtCuentahabiente.TextLength = 0 Then
            lblCuentahabiente.ForeColor = Drawing.Color.Red
        Else
            lblCuentahabiente.ForeColor = Drawing.Color.Black
        End If

        If cmbTipoCuenta.SelectedIndex > 0 Then
            lblTipoCuenta.ForeColor = Drawing.Color.Black
        Else
            lblTipoCuenta.ForeColor = Drawing.Color.Red
        End If

        If cmbBanco.SelectedIndex > 0 Then
            lblBanco.ForeColor = Drawing.Color.Black
        Else
            lblBanco.ForeColor = Drawing.Color.Red
        End If

        If cmbRfcCuenta.SelectedIndex > 0 Then
            lblRfcCuenta.ForeColor = Drawing.Color.Black
        Else
            lblRfcCuenta.ForeColor = Drawing.Color.Red
        End If

        'If txtPlaza.TextLength <> 0 And txtCuenta.TextLength <> 0 And txtClabe.TextLength <> 0 And txtSucursal.TextLength <> 0 And txtCuentahabiente.TextLength <> 0 And cmbTipoCuenta.SelectedIndex <> 0 And cmbBanco.SelectedIndex <> 0 And cmbRfcCuenta.SelectedIndex <> 0 Then
        If txtCuenta.TextLength <> 0 And txtClabe.TextLength <> 0 And txtCuentahabiente.TextLength <> 0 And cmbTipoCuenta.SelectedIndex <> 0 And cmbBanco.SelectedIndex <> 0 And cmbRfcCuenta.SelectedIndex <> 0 Then

            Return True
        Else
            Return False
        End If

    End Function

    Public Function ValidacionDatosContacto() As Boolean
        Dim validaDG As Boolean = True

        If txtNombreContacto.TextLength = 0 Then
            lblNombreContacto.ForeColor = Drawing.Color.Red
        Else
            lblNombreContacto.ForeColor = Drawing.Color.Black
        End If

        If txtCargoContacto.TextLength = 0 Then
            lblCargoContacto.ForeColor = Drawing.Color.Red
        Else
            lblCargoContacto.ForeColor = Drawing.Color.Black
        End If

        If txtEmailContacto.TextLength = 0 Then
            lblEmailContacto.ForeColor = Drawing.Color.Red
        Else
            lblEmailContacto.ForeColor = Drawing.Color.Black
        End If

        If txtTelefonoContacto.TextLength = 0 Then
            lblTelefonoContacto.ForeColor = Drawing.Color.Red
        Else
            lblTelefonoContacto.ForeColor = Drawing.Color.Black
        End If

        If cmbNotificar.SelectedIndex > 0 Then
            lblNotificarContacto.ForeColor = Drawing.Color.Black
        Else
            lblNotificarContacto.ForeColor = Drawing.Color.Red
        End If

        If cmbDepartamentoContaco.SelectedIndex > 0 Then
            lblDepartamentoContaco.ForeColor = Drawing.Color.Black
        Else
            lblDepartamentoContaco.ForeColor = Drawing.Color.Red
        End If

        If txtNombreContacto.TextLength <> 0 And txtCargoContacto.TextLength <> 0 And txtEmailContacto.TextLength <> 0 And txtTelefonoContacto.TextLength <> 0 And cmbNotificar.SelectedIndex > 0 And cmbDepartamentoContaco.SelectedIndex > 0 Then
            Return True
        Else
            Return False
        End If

        Return True
    End Function

    Public Sub VerificarCamposGenerales()
        If txtNombreComercial.Text = "" Or cmbCategoria.SelectedIndex = -1 Or cmbGiro.SelectedIndex = -1 Then
            CamposGenerales = False
        Else
            CamposGenerales = True
        End If
    End Sub

    '*******************Fin validaciones
    '******** restricciones en txt y cmb
    Private Sub txtLimiteCredito_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtLimiteCredito.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumeroExterior_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumeroInterior_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtCodigoPostal_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtCuenta_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtCuenta.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtClabe_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtClabe.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtTelefonoContacto_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cmbTipoDePersona_SelectionChangeCommitted(sender As Object, e As EventArgs)

        If cmbTipoDePersona.Text = "FISICA" Then
            txtRfcRazonSocial.Enabled = True
            txtNombre.Text = ""
            txtApellidoPaterno.Text = ""
            txtApellidoMaterno.Text = ""
            txtNombre.Enabled = False
            'txtNombre.BackColor = Color.Gray
            txtApellidoPaterno.Enabled = False
            ' txtApellidoPaterno.BackColor = Color.Gray
            txtApellidoMaterno.Enabled = False
            ' txtApellidoMaterno.BackColor = Color.Gray
            txtRazonSocial.Text = ""
            txtNombre.Text = ""
            txtApellidoMaterno.Text = ""
            txtApellidoPaterno.Text = ""
            lblRfcRazonSocial.Text = "*RFC"

        End If
        If cmbTipoDePersona.Text = "MORAL" Then
            txtRazonSocial.Enabled = False
            ' txtRazonSocial.BackColor = Color.Gray
            txtNombre.Text = ""
            txtApellidoPaterno.Text = ""
            txtApellidoMaterno.Text = ""
            txtNombre.Enabled = True
            txtApellidoPaterno.Enabled = True
            txtApellidoMaterno.Enabled = True
            txtRazonSocial.Text = ""
        End If

    End Sub

    Private Sub cmbDepartamentoContaco_SelectionChangeCommitted(sender As Object, e As EventArgs)
        If cmbDepartamentoContaco.Text = "COBRANZA" Then
            lblFotoContacto.Enabled = True
            btnFoto.Enabled = True
            lblAgregarFoto1.Enabled = True
            btnImprimir.Enabled = True
            lblImprimir1.Enabled = True
            lblImprimir2.Enabled = True
            lblFotoContacto.Enabled = True
            picFoto.Enabled = True
        End If
        If cmbDepartamentoContaco.Text = "VENTAS" Then
            lblFotoContacto.Enabled = False
            btnImprimir.Enabled = False
            lblImprimir1.Enabled = False
            lblImprimir2.Enabled = False
            btnFoto.Enabled = False
            lblAgregarFoto1.Enabled = False
            lblFotoContacto.Enabled = False
            picFoto.Enabled = False
        End If
    End Sub

    '*************  llenar ultra grid
    Public Sub LlenarTablaRFC()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtListaRFC As New DataTable
        grdRFC.DataSource = Nothing
        dtListaRFC = objBU.ListaProveedorRFC(txtProveedorid.Text)
        grdRFC.DataSource = dtListaRFC
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub diseniogrdRFC()
        With grdRFC.DisplayLayout.Bands(0)
            .Columns("ID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("RAZON SOCIAL").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("RFC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ID SICY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ACTIVO OC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ACTIVO COMPRAS").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ACTIVO PAGOS").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("CALLE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NUMERO EXTERIOR").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NUMERO INTERIOR").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("COLONIA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("CIUDAD").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ESTADO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("PAIS").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NOMBRE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("APELLIDO PATERNO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("APELLIDO MATERNO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("TIPO FISCAL").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("TIPO RAZON SOCIAL").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("ID").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ID SICY").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("CP").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("IDP").Hidden = True
            .Columns("IDE").Hidden = True
            .Columns("IDC").Hidden = True
            .Columns("AP").Hidden = True
            .Columns("AC").Hidden = True
            .Columns("ACTIVO OC").Hidden = True

            .Columns("ID").Width = 40
            .Columns("NUMERO EXTERIOR").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("NUMERO INTERIOR").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            'grdRFC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With
    End Sub

    Public Sub LlenarNaves()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtListaNaves As New DataTable
        grdNavesDisponibles.DataSource = Nothing
        dtListaNaves = objBU.ListaNaves()
        grdNavesDisponibles.DataSource = dtListaNaves
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub diseniogrdNaves()
        With grdNavesDisponibles.DisplayLayout.Bands(0)
            .Columns("NAVE ID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NOMBRE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ID SICY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("NAVE ID").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ID SICY").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("NAVE ID").Width = 70
            .Columns("NOMBRE").Width = 444
            .Columns("ID SICY").Width = 70
        End With
    End Sub

    Public Sub LlenarTablaPlazo()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtListaRFC As New DataTable
        grdPlazo.DataSource = Nothing
        dtListaRFC = objBU.ListaPlazo(txtProveedorid.Text)
        grdPlazo.DataSource = dtListaRFC
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub diseniogrdPlazo()
        With grdPlazo.DisplayLayout.Bands(0)

            .Columns("ID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("PLAZO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("DIAS").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ACTIVO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("ID").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("DIAS").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ID").Width = 40
            .Columns("PLAZO").Width = 470
            .Columns("DIAS").Width = 50
            .Columns("ACTIVO").Width = 50
        End With

    End Sub

    Public Sub LlenarTablaPlazoProveedor()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable
        grdPlazoProveedor.DataSource = Nothing
        dtLista = objBU.ListaPlazoProveedor(txtProveedorid.Text)
        grdPlazoProveedor.DataSource = dtLista
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub diseniogrdPlazoProveedor()
        With grdPlazoProveedor.DisplayLayout.Bands(0)
            .Columns("ID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("DIAS").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("PLAZO PAGO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("ID").Hidden = True
            .Columns("DIAS").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("PLAZO PAGO").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            .Columns("DIAS").Width = 150
            .Columns("PLAZO PAGO").Width = 222
            .Columns("ID").Width = 40
        End With

    End Sub

    Public Sub LlenarTablaNaveProveedor()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable
        grdNavesAsociadas.DataSource = Nothing
        dtLista = objBU.ListaNavesProveedor(txtProveedorid.Text)
        grdNavesAsociadas.DataSource = dtLista
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub diseniogrdNavesProveedor()
        With grdNavesAsociadas.DisplayLayout.Bands(0)
            '.Columns("ID ASIGNACION").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("ID NAVE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NAVE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("NAVE").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("1").Hidden = True
            .Columns("2").Hidden = True
            .Columns("3").Hidden = True
            .Columns("NAVE").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            grdNavesAsociadas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With

    End Sub

    Public Sub LlenarCuentaBancaria()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable
        grdCuentasBancarias.DataSource = Nothing
        dtLista = objBU.ListaDeCuentasBancarias(txtProveedorid.Text)
        grdCuentasBancarias.DataSource = dtLista
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub diseniogrdCuentasBancarias()
        With grdCuentasBancarias.DisplayLayout.Bands(0)
            .Columns("BANCO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("CUENTA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("CLABE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("CUENTAHABIENTE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("PREDETERMINADA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ACTIVA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("CUENTA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("CLABE").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            'grdCuentasBancarias.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With
    End Sub

    Public Sub LlenarTablaContactosVentas()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtListaContactosVentas As New DataTable
        grdContactoVentas.DataSource = Nothing
        dtListaContactosVentas = objBU.ListaDeContactosVentasCompleta(txtProveedorid.Text)
        grdContactoVentas.DataSource = dtListaContactosVentas
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub LlenarTablaContactosVentas2()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtListaContactosVentas As New DataTable
        grdContactoVentas.DataSource = Nothing
        dtListaContactosVentas = objBU.ListaDeContactosVentasCompleta2(txtProveedorid.Text)
        grdContactoVentas.DataSource = dtListaContactosVentas
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub LlenarTablaContactosCobranza()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtListaContactosCobranza As New DataTable
        grdContactoCobranza.DataSource = Nothing
        dtListaContactosCobranza = objBU.ListaDeContactosCobranzaCompleta(txtProveedorid.Text)
        grdContactoCobranza.DataSource = dtListaContactosCobranza
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub LlenarTablaContactosCobranza2()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtListaContactosCobranza As New DataTable
        grdContactoCobranza.DataSource = Nothing
        dtListaContactosCobranza = objBU.ListaDeContactosCobranzaCompleta2(txtProveedorid.Text)
        grdContactoCobranza.DataSource = dtListaContactosCobranza
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub diseniogrdContactosCobranza()
        With grdContactoCobranza.DisplayLayout.Bands(0)
            .Columns("ID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NOMBRE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("CARGO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("TELEFONO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("EMAIL").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("DEPARTAMENTO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("RUTA FOTO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NOTIFICACION DE PAGO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("ID").Width = 40
            .Columns("ID").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            'grdContactoCobranza.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With
    End Sub

    Public Sub LlenarTablaCuentasBancarias()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtListaCuentas As New DataTable
        grdCuentasBancarias.DataSource = Nothing
        dtListaCuentas = objBU.ListaDeCuentasBancariasCompleta(txtProveedorid.Text)
        grdCuentasBancarias.DataSource = dtListaCuentas
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub LlenarTablaUsuariosProveedor()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtListaUsuarios As New DataTable
        grdUsuarios.DataSource = Nothing
        dtListaUsuarios = objBU.ListaUsuariosSitioProveedor(txtProveedorid.Text)
        grdUsuarios.DataSource = dtListaUsuarios
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub LlenarTablaUsuariosActivos()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtListaContactosVentas As New DataTable
        grdUsuarios.DataSource = Nothing
        dtListaContactosVentas = objBU.ListaDeUsuariosActivos(txtProveedorid.Text)
        grdUsuarios.DataSource = dtListaContactosVentas
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub LlenarTablaUsuariosInactivos()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtListaContactosVentas As New DataTable
        grdUsuarios.DataSource = Nothing
        dtListaContactosVentas = objBU.ListaDeUsuariosInactivos(txtProveedorid.Text)
        grdUsuarios.DataSource = dtListaContactosVentas
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub diseniogrdUsuariosUsuariosProveedor()
        With grdUsuarios.DisplayLayout.Bands(0)
            .Columns("ID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NOMBRE USUARIO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("USUARIO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("PASSWORD").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ACTIVO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("ID").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ID").Width = 40
            .Columns("NOMBRE USUARIO").Width = 310
            .Columns("USUARIO").Width = 3000
            .Columns("PASSWORD").Width = 300
            .Columns("ACTIVO").Width = 50
            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            'grdUsuarios.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With
    End Sub

    Public Sub diseniogrdUsuarios()
        With grdUsuarios.DisplayLayout.Bands(0)
            .Columns("ID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NOMBRE USUARIO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("USUARIO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("PASSWORD").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ACTIVO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("ID").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ID").Width = 40
            .Columns("NOMBRE USUARIO").Width = 150
            .Columns("USUARIO").Width = 100
            .Columns("PASSWORD").Width = 100
            .Columns("ACTIVO").Width = 50
            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            grdUsuarios.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With
    End Sub

    Public Sub diseniogrdContactosVentas()
        With grdContactoVentas.DisplayLayout.Bands(0)
            .Columns("ID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NOMBRE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("CARGO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("TELEFONO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("EMAIL").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("RUTA FOTO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("DEPARTAMENTO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NOTIFICACION DE PAGO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("ID").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            ' grdContactoVentas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With
    End Sub

    '*************************fin llenar grid
    Private Sub grdCuentasBancarias_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs)

        cmbTipoCuenta.Text = grdCuentasBancarias.ActiveRow.Cells("TIPO DE CUENTA").Text
        cmbRfcCuenta.Text = grdCuentasBancarias.ActiveRow.Cells("RFC").Text
        cmbBanco.Text = grdCuentasBancarias.ActiveRow.Cells("BANCO").Text
        txtSucursal.Text = grdCuentasBancarias.ActiveRow.Cells("SUCURSAL").Text
        txtPlaza.Text = grdCuentasBancarias.ActiveRow.Cells("PLAZA").Text
        txtCuenta.Text = grdCuentasBancarias.ActiveRow.Cells("CUENTA").Text
        txtClabe.Text = grdCuentasBancarias.ActiveRow.Cells("CLABE").Text
        txtCuentahabiente.Text = grdCuentasBancarias.ActiveRow.Cells("CUENTAHABIENTE").Text
        txtIdCuenta.Text = grdCuentasBancarias.ActiveRow.Cells("ID").Text
        If grdCuentasBancarias.ActiveRow.Cells("ACTIVA").Text = "s" Then
            rdoCuentaActiva.Checked = True
            rdoCuentaNoActiva.Checked = False
        Else
            rdoCuentaNoActiva.Checked = True
            rdoCuentaActiva.Checked = False
        End If

        If grdCuentasBancarias.ActiveRow.Cells("PREDETERMINADA").Text = "SI" Then
            rdoCuentaPredeterminada.Checked = True
            rdoCuentaNoPredeterminada.Checked = False
        Else
            rdoCuentaPredeterminada.Checked = False
            rdoCuentaNoPredeterminada.Checked = True
        End If

        btnLimpiar2.Visible = True
        lblLimpiar2.Visible = True
        lblCampos2.Visible = True

    End Sub

    Private Sub cmbDepartamentoContaco_TextChanged(sender As Object, e As EventArgs) Handles cmbDepartamentoContaco.TextChanged
        If cmbDepartamentoContaco.Text = "COBRANZA" Then
            lblFotoContacto.Enabled = True
            btnFoto.Enabled = True
            lblAgregarFoto1.Enabled = True
            btnImprimir.Enabled = True
            lblImprimir1.Enabled = True
            lblImprimir2.Enabled = True
            lblFotoContacto.Enabled = True
            picFoto.Enabled = True
            picFoto.Visible = True
        End If
        If cmbDepartamentoContaco.Text = "VENTAS" Then
            lblFotoContacto.Enabled = False
            btnImprimir.Enabled = False
            lblImprimir1.Enabled = False
            lblImprimir2.Enabled = False
            btnFoto.Enabled = False
            lblAgregarFoto1.Enabled = False
            lblFotoContacto.Enabled = False
            picFoto.Enabled = False
            picFoto.Visible = False
        End If
        If cmbDepartamentoContaco.Text = "" Then
            lblFotoContacto.Enabled = False
            btnImprimir.Enabled = False
            lblImprimir1.Enabled = False
            lblImprimir2.Enabled = False
            btnFoto.Enabled = False
            lblAgregarFoto1.Enabled = False
            lblFotoContacto.Enabled = False
            picFoto.Enabled = False
            picFoto.Visible = False
        End If
    End Sub

    Private Sub grdRFC_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs)
        btnLimpiar.Visible = True
        lblLimpiar.Visible = True
        lblCampos.Visible = True

        cmbTipoFiscal.Text = grdRFC.ActiveRow.Cells("TIPO FISCAL").Text
        cmbTipoDePersona.Text = grdRFC.ActiveRow.Cells("TIPO RAZON SOCIAL").Text
        txtCalle.Text = grdRFC.ActiveRow.Cells("CALLE").Text
        txtNumeroInterior.Text = grdRFC.ActiveRow.Cells("NUMERO INTERIOR").Text
        txtNumeroExterior.Text = grdRFC.ActiveRow.Cells("NUMERO EXTERIOR").Text
        txtColonia.Text = grdRFC.ActiveRow.Cells("COLONIA").Text
        'txtCodigoPostal.Text = grdRFC.ActiveRow.Cells(10).Text
        cmbCiudadRazonSocial.Text = grdRFC.ActiveRow.Cells("CIUDAD").Text
        cmbEstadoRazonSocial.Text = grdRFC.ActiveRow.Cells("ESTADO").Text
        cmbPaisRazonSocial.Text = grdRFC.ActiveRow.Cells("PAIS").Text
        'txtCurp.Text = grdRFC.ActiveRow.Cells(4).Text
        txtRfcRazonSocial.Text = grdRFC.ActiveRow.Cells("RFC").Text
        txtCurp.Text = grdRFC.ActiveRow.Cells("CURP").Text
        txtNombre.Text = grdRFC.ActiveRow.Cells("NOMBRE").Text
        txtApellidoPaterno.Text = grdRFC.ActiveRow.Cells("APELLIDO PATERNO").Text
        txtApellidoMaterno.Text = grdRFC.ActiveRow.Cells("APELLIDO MATERNO").Text
        txtRazonSocial.Text = grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text
        txtIdrfc.Text = grdRFC.ActiveRow.Cells("ID").Text
        If grdRFC.ActiveRow.Cells("ACTIVO COMPRAS").Text = "SI" Then
            rdoSiActivoCompras.Checked = True
            rdoNoActivoCompras.Checked = False
        Else
            rdoSiActivoCompras.Checked = False
            rdoNoActivoCompras.Checked = True
        End If
        If grdRFC.ActiveRow.Cells("ACTIVO PAGOS").Text = "SI" Then
            rdoSiActivoPagos.Checked = True
            rdoNoActivoPagos.Checked = False
        Else
            rdoSiActivoPagos.Checked = False
            rdoNoActivoPagos.Checked = True
        End If

    End Sub

    Public Sub limpiarRFC()
        cmbTipoFiscal.SelectedIndex = 0
        cmbTipoDePersona.SelectedIndex = 0
        txtCalle.Text = ""
        txtNumeroExterior.Text = ""
        txtNumeroInterior.Text = ""
        txtColonia.Text = ""
        txtCodigoPostal.Text = ""
        cmbCiudadRazonSocial.Text = ""
        cmbEstadoRazonSocial.Text = ""
        cmbPaisRazonSocial.Text = ""
        txtCurp.Text = ""
        txtRfcRazonSocial.Text = ""
        txtNombre.Text = ""
        txtApellidoMaterno.Text = ""
        txtApellidoPaterno.Text = ""
        txtRazonSocial.Text = ""
        rdoSiActivoPagos.Checked = True
        rdoSiActivoCompras.Checked = True
        cmbTipoFiscal.SelectedIndex = 0
        cmbTipoDePersona.SelectedIndex = 0
        txtIdrfc.Text = ""
        txtSicy.Text = ""
    End Sub

    Public Sub LIMPIAR2()
        cmbTipoCuenta.SelectedIndex = 0
        cmbRfcCuenta.SelectedIndex = 0
        cmbBanco.Text = ""
        txtPlaza.Text = ""
        txtCuenta.Text = ""
        txtClabe.Text = ""
        txtCuentahabiente.Text = ""
        rdoCuentaActiva.Checked = True
        rdoCuentaPredeterminada.Checked = True
        txtIdCuenta.Text = ""
        txtSucursal.Text = ""
    End Sub

    Public Sub LIMPIAR3()
        txtNombreContacto.Text = ""
        txtCargoContacto.Text = ""
        txtTelefonoContacto.Text = ""
        txtEmailContacto.Text = ""
        cmbNotificar.SelectedIndex = 0
        cmbDepartamentoContaco.SelectedIndex = 0
        picFoto.Image = Nothing
        txtIdContacto.Text = ""
        txtSucursal.Text = ""
    End Sub

    Public Sub LIMPIAR4()
        txtNombreUsuario.Text = ""
        txtUsuario.Text = ""
        txtContraseña.Text = ""
        txtIdUsuario.Text = ""
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarRFC()
    End Sub

    Private Sub btnLimpiar2_Click(sender As Object, e As EventArgs) Handles btnLimpiar2.Click
        LIMPIAR2()
    End Sub

    Private Sub btnLimpiar1_Click(sender As Object, e As EventArgs) Handles btnLimpiar3.Click
        LIMPIAR3()
    End Sub

    Public Sub ModificarContacto()
        Dim EntidadContacto As New DatosContacto
        Dim objbu As New ProveedorBU
        EntidadContacto.daco_nombre = txtNombreContacto.Text
        EntidadContacto.daco_cargo = txtCargoContacto.Text
        EntidadContacto.daco_telefono = txtTelefonoContacto.Text
        EntidadContacto.daco_notificaciondepago = cmbNotificar.Text
        EntidadContacto.daco_email = txtEmailContacto.Text
        EntidadContacto.daco_departamento = cmbDepartamentoContaco.Text
        EntidadContacto.daco_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadContacto.daco_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadContacto.daco_foto = txtFoto.Text
        EntidadContacto.daco_datoscontactoid = CInt(txtIdContacto.Text)
        If rdoContactoActivo.Checked = True Then
            EntidadContacto.daco_activo = "SI"
        Else
            EntidadContacto.daco_activo = "NO"
        End If
        objbu.EditarProveedorDatosContacto(EntidadContacto)
    End Sub

    Public Sub GuardarImagen()

        Dim objFTP As New Tools.TransferenciaFTP
        objFTP.EnviarArchivo2("/Administracion/Proveedores", ofdFoto.FileName)

    End Sub

    Private Sub btnFoto_Click(sender As Object, e As EventArgs) Handles btnFoto.Click
        ofdFoto.Filter = "Image Files (JPEG,GIF,BMP,PNG,ICO)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*ico"
        If ofdFoto.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim sr As New System.IO.StreamReader(ofdFoto.FileName)
            picFoto.Image = Drawing.Image.FromFile(ofdFoto.FileName)
            txtFoto.Text = "/Administracion/Proveedores/" + ofdFoto.FileName
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnLimpiarCuentas.Click
        LIMPIAR4()
    End Sub

    Public Sub ModificarCuentaBancaria()
        Dim EntidadCuenta As New DatosDeCuentaBancaria
        Dim objbu As New ProveedorBU
        EntidadCuenta.dcba_banco = cmbBanco.Text
        EntidadCuenta.dcba_cuenta = txtCuenta.Text
        EntidadCuenta.dcba_clabe = txtClabe.Text
        EntidadCuenta.dcba_cuentahabiente = txtCuentahabiente.Text
        EntidadCuenta.dcba_plaza = txtPlaza.Text
        EntidadCuenta.dcba_sucursal = txtSucursal.Text

        If rdoCuentaPredeterminada.Checked = True Then
            EntidadCuenta.dcba_predeterminada = "SI"
        ElseIf rdoCuentaNoPredeterminada.Checked = True Then
            EntidadCuenta.dcba_predeterminada = "NO"

        End If
        If rdoCuentaActiva.Checked = True Then
            EntidadCuenta.dcba_activa = "SI"
        ElseIf rdoCuentaNoActiva.Checked = True Then
            EntidadCuenta.dcba_activa = "NO"
        End If

        EntidadCuenta.dcba_usuariomodifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadCuenta.dcba_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadCuenta.dcba_rfc = cmbRfcCuenta.Text
        EntidadCuenta.dcba_tipodecuenta = cmbTipoCuenta.Text
        EntidadCuenta.dcba_datosdecuentabancariaid = txtIdCuenta.Text
        objbu.EditarProveedorCuentaBancaria(EntidadCuenta)

    End Sub

    Private Sub grdContactoVentas_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs)
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "DATOSDERFC") Then

            txtNombreContacto.Text = grdContactoVentas.ActiveRow.Cells("NOMBRE").Text
            txtCargoContacto.Text = grdContactoVentas.ActiveRow.Cells("CARGO").Text
            txtEmailContacto.Text = grdContactoVentas.ActiveRow.Cells("EMAIL").Text
            cmbNotificar.Text = grdContactoVentas.ActiveRow.Cells("NOTIFICACION DE PAGO").Text
            cmbDepartamentoContaco.Text = grdContactoVentas.ActiveRow.Cells("DEPARTAMENTO").Text
            txtTelefonoContacto.Text = grdContactoVentas.ActiveRow.Cells("TELEFONO").Text
            txtIdContacto.Text = grdContactoVentas.ActiveRow.Cells("ID").Text
            btnGuardar4.Visible = True
            lblGuardar4.Visible = True

        End If

    End Sub

    Private Sub grdUsuarios_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdUsuarios.DoubleClickCell

        If txtIdUsuario.Text <> "" Then

            txtIdUsuario.Text = grdUsuarios.ActiveRow.Cells("ID").Text
            txtNombreUsuario.Text = grdUsuarios.ActiveRow.Cells("NOMBRE USUARIO").Text
            txtUsuario.Text = grdUsuarios.ActiveRow.Cells("USUARIO").Text
            txtContraseña.Text = grdUsuarios.ActiveRow.Cells("PASSWORD").Text
            If grdUsuarios.ActiveRow.Cells("ACTIVO").Text = "SI" Then
                rdoNoActivoUsuario.Checked = False
                rdoActivoUsuario.Checked = True
            Else
                rdoNoActivoUsuario.Checked = True
                rdoActivoUsuario.Checked = False
            End If

            btnGuardarCambios.Visible = True
            lblGuardarCambios.Visible = True
        End If

    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs)
        BuscarContactosRepetidos()
    End Sub

    Private Sub cmbFiscal_SelectedIndexChanged(sender As Object, e As EventArgs)

        If cmbTipoFiscal.Text = "FISCAL" Then
            cmbTipoDePersona.Enabled = True
            lblTipoDePersona.Enabled = True
            txtNombre.Enabled = False
            ' txtNombre.BackColor = Color.Gray
            txtApellidoPaterno.Enabled = False
            ' txtApellidoPaterno.BackColor = Color.Gray
            txtApellidoMaterno.Enabled = False
            ' txtApellidoMaterno.BackColor = Color.Gray
            txtRfcRazonSocial.Enabled = True
            'txtRfcRazonSocial.BackColor = Color.Gray
            txtRfcRazonSocial.Enabled = True
            lblCalle.Text = "*Calle"
            lblColonia.Text = "*Colonia"
            lblNumeroExterior.Text = "*Numero exterior"
            txtCurp.Enabled = False
            'txtCurp.BackColor = Color.Gray
            txtRazonSocial.Text = ""
            txtNombre.Text = ""
            txtApellidoPaterno.Text = ""
            txtApellidoMaterno.Text = ""

        End If
        If cmbTipoFiscal.Text = "NO FISCAL" Then
            cmbTipoDePersona.SelectedIndex = -1
            cmbTipoDePersona.Enabled = False
            ' cmbTipoDePersona.BackColor = Color.Gray
            lblTipoDePersona.Enabled = False
            txtNombre.Enabled = True
            txtApellidoPaterno.Enabled = True
            txtApellidoMaterno.Enabled = True
            txtRfcRazonSocial.Enabled = True
            'txtRfcRazonSocial.BackColor = Color.Gray
            lblCalle.Text = "Calle"
            lblColonia.Text = "Colonia"
            lblNumeroExterior.Text = "Numero exterior"
            txtCurp.Enabled = Enabled
            txtRazonSocial.Text = ""
            txtNombre.Text = ""
            txtApellidoPaterno.Text = ""
            txtApellidoMaterno.Text = ""
        End If
    End Sub

    Private Sub cmbTipoDePersona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoDePersona.SelectedIndexChanged

        If cmbTipoDePersona.Text = "FISICA" Then
            txtNombre.Enabled = True
            txtRfcRazonSocial.MaxLength = 13
            txtApellidoPaterno.Enabled = True
            txtApellidoMaterno.Enabled = True
            txtNombre.Text = ""
            txtApellidoPaterno.Text = ""
            txtApellidoMaterno.Text = ""
            txtRazonSocial.Enabled = False
            cmbTipoRazonSocial.Enabled = False
            '  txtRazonSocial.BackColor = Color.Gray
            txtRazonSocial.Text = ""
            txtRfcRazonSocial.Text = ""
            txtNombre.Text = ""
            txtApellidoMaterno.Text = ""
            txtApellidoPaterno.Text = ""
            txtCurp.Enabled = True
            cmbTipoRazonSocial.SelectedValue = 0
        End If
        If cmbTipoDePersona.Text = "MORAL" Then
            txtNombre.Enabled = False
            txtRfcRazonSocial.MaxLength = 12
            ' txtNombre.BackColor = Color.Gray
            txtApellidoPaterno.Enabled = False
            'txtApellidoPaterno.BackColor = Color.Gray
            txtApellidoMaterno.Enabled = False
            ' txtApellidoMaterno.BackColor = Color.Gray
            txtNombre.Text = ""
            txtRfcRazonSocial.Text = ""
            txtApellidoPaterno.Text = ""
            txtApellidoMaterno.Text = ""
            txtRazonSocial.Enabled = True
            txtRazonSocial.Text = ""
            txtCurp.Enabled = False
            cmbTipoRazonSocial.Enabled = True
            cmbTipoRazonSocial.SelectedValue = 0
        End If
    End Sub

    Private Sub TabDatos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabDatos.SelectedIndexChanged
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "DATOSDERFC") Then
            If txtProveedorid.Text <> "" Then
                LlenarTablaNaveProveedor()
                Try
                    diseniogrdNavesProveedor()
                Catch ex As Exception
                End Try
                LlenarTablaPlazoProveedor()
                Try
                    diseniogrdPlazoProveedor()
                Catch ex As Exception
                End Try
                llenarComboPais2()
            End If
        End If

    End Sub

    Private Sub grdContactoCobranza_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdContactoCobranza.DoubleClickCell
        Dim EntidadArchivos As New Entidades.ColaboradorExpediente

        If txtIdContacto.Text <> "" Then

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "DATOSDERFC") Then
                txtNombreContacto.Text = grdContactoCobranza.ActiveRow.Cells("NOMBRE").Text
                txtCargoContacto.Text = grdContactoCobranza.ActiveRow.Cells("CARGO").Text
                txtEmailContacto.Text = grdContactoCobranza.ActiveRow.Cells("EMAIL").Text
                txtTelefonoContacto.Text = grdContactoCobranza.ActiveRow.Cells("TELEFONO").Text
                txtIdContacto.Text = grdContactoCobranza.ActiveRow.Cells("ID").Text
                cmbNotificar.Text = grdContactoCobranza.ActiveRow.Cells("NOTIFICACION DE PAGO").Text
                cmbDepartamentoContaco.Text = grdContactoCobranza.ActiveRow.Cells("DEPARTAMENTO").Text
                txtFoto.Text = grdContactoCobranza.ActiveRow.Cells("RUTA FOTO").Text
                btnGuardar4.Visible = True
                lblGuardar4.Visible = True

                If grdContactoCobranza.ActiveRow.Cells("ACTIVO").Text = "NO" Then
                    rdoContactoNoActivo.Checked = True
                Else
                    rdoContactoActivo.Checked = True
                End If
                If grdContactoCobranza.ActiveRow.Cells("RUTA FOTO").Text <> "" Then
                    Dim rutaImagen As String
                    Dim nombreImagen As String

                    rutaImagen = grdContactoCobranza.ActiveRow.Cells("RUTA FOTO").Text
                    nombreImagen = rutaImagen.Substring(rutaImagen.LastIndexOf("\") + 1)

                    Try
                        'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                        'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                        Dim objFTP As New Tools.TransferenciaFTP
                        Dim Stream As System.IO.Stream
                        Stream = objFTP.StreamFile("/Administracion/Proveedores/", nombreImagen)
                        picFoto.Image = Image.FromStream(Stream)
                    Catch
                    End Try

                ElseIf grdContactoCobranza.ActiveRow.Cells("RUTA FOTO").Text = "" Then

                    Dim imagen As String = "noimage.jpg"
                    Try
                        'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                        'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                        Dim objFTP As New Tools.TransferenciaFTP
                        Dim Stream As System.IO.Stream
                        Stream = objFTP.StreamFile("/Administracion/Proveedores/", imagen)
                        picFoto.Image = Image.FromStream(Stream)
                    Catch
                    End Try
                End If

            End If
        End If

    End Sub

    'Private Sub AltaProveedoresForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
    '    ' Me.Dispose()
    'End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnAgregarGiro.Click
        Dim form = New AltaGiroProveedorForm
        form.ShowDialog()
    End Sub

    Private Sub cmbGiro_Click(sender As Object, e As EventArgs) Handles cmbGiro.Click
        llenarComboGiros()
    End Sub

    Private Sub cmbPaisRazonSocial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPaisRazonSocial.SelectedIndexChanged
        Try
            cmbEstadoRazonSocial.SelectedValue = 0
        Catch ex As Exception
        End Try
        If cmbPaisRazonSocial.SelectedIndex > 0 Then
            llenarComboEstado()
        End If
    End Sub

    Private Sub cmbEstadoRazonSocial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstadoRazonSocial.SelectedIndexChanged
        Try
            cmbCiudadRazonSocial.SelectedValue = 0
        Catch ex As Exception
        End Try
        If cmbEstadoRazonSocial.SelectedIndex > 0 Then
            llenarComboCiudad()
        End If
    End Sub

    Public Function BuscarRazonSocial()
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable
        Dim objBU2 As New ProveedorBU
        Dim dtLista2 As New DataTable
        Dim id As Integer
        Dim rfc As String
        Dim rfc2 As String
        id = txtProveedorid.Text
        rfc = cmbRfcCuenta.Text
        rfc2 = cmbRfcCuenta.Text.Replace(" "c, String.Empty)
        dtLista = objBU.BuscaRazonSocial(rfc, id)
        dtLista2 = objBU2.BuscaRfcSicyCta(rfc2)
        If dtLista2.Rows.Count <> 0 Then
            txtRfcSicyId.Text = dtLista2.Rows(0).Item(0).ToString
        End If
        If cmbTipoCuenta.Text = "NO FISCAL" Then
            txtCuentahabiente.Text = cmbRfcCuenta.Text
        ElseIf dtLista.Rows.Count = 0 Then
            txtCuentahabiente.Text = ""
        Else
            txtCuentahabiente.Text = dtLista.Rows(0).Item(0).ToString
        End If
    End Function

    Private Sub cmbRfcCuenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRfcCuenta.SelectedIndexChanged
        If cmbRfcCuenta.SelectedIndex > 0 Then
            BuscarRazonSocial()
        End If
    End Sub

    Private Sub rdoActivos_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivos.CheckedChanged
        LlenarTablaContactosCobranza()
        Try
            diseniogrdContactosCobranza()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rdoNoActivos_CheckedChanged(sender As Object, e As EventArgs) Handles rdoNoActivos.CheckedChanged
        LlenarTablaContactosCobranza2()
        Try
            diseniogrdContactosCobranza()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        LlenarTablaContactosVentas()
        Try
            diseniogrdContactosVentas()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        LlenarTablaContactosVentas2()
        Try
            diseniogrdContactosVentas()
        Catch ex As Exception
        End Try

    End Sub

    Public Sub Activarcontacto()
        Dim EntidadContacto As New DatosContacto
        Dim objbu As New ProveedorBU
        EntidadContacto.daco_datoscontactoid = txtIdContacto.Text
        EntidadContacto.daco_activo = "SI"
        EntidadContacto.daco_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadContacto.daco_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        objbu.ActivarContactoProveedor(EntidadContacto)
    End Sub

    Public Sub Desactivarcontacto()
        Dim EntidadContacto As New DatosContacto
        Dim objbu As New ProveedorBU
        EntidadContacto.daco_datoscontactoid = txtIdContacto.Text
        EntidadContacto.daco_activo = "NO"
        EntidadContacto.daco_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadContacto.daco_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        objbu.DesactivarContactoProveedor(EntidadContacto)
    End Sub

    Private Sub grdContactoVentas_ClickCell(sender As Object, e As ClickCellEventArgs)
        txtIdContacto.Text = ""
        txtIdContacto.Text = grdContactoVentas.ActiveRow.Cells(0).Text
        'btnActivar.Visible = True
        'btnDesactivar.Visible = True
        'lblActivar.Visible = True
        'lblDesactivar.Visible = True
    End Sub

    Private Sub grdContactoCobranza_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdContactoCobranza.ClickCell
        txtIdContacto.Text = ""
        txtIdContacto.Text = grdContactoCobranza.ActiveRow.Cells(0).Text
        'btnActivar.Visible = True
        'btnDesactivar.Visible = True
        'lblActivar.Visible = True
        'lblDesactivar.Visible = True
    End Sub

    Public Sub ActivarUsuario()
        Dim EntidadContacto As New UsuarioProveedor
        Dim objbu As New ProveedorBU
        EntidadContacto.upro_usuarioproveedorid = txtIdContacto.Text
        EntidadContacto.upro_activo = "SI"
        EntidadContacto.upro_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ' EntidadContacto.upro_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        objbu.ActivaDesactivaUsuarioProveedor(EntidadContacto)
    End Sub

    Public Sub DesactivarUsuario()
        Dim EntidadContacto As New UsuarioProveedor
        Dim objbu As New ProveedorBU
        EntidadContacto.upro_usuarioproveedorid = txtIdUsuario.Text
        EntidadContacto.upro_activo = "NO"
        EntidadContacto.upro_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ' EntidadContacto.upro_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        objbu.ActivaDesactivaUsuarioProveedor(EntidadContacto)
    End Sub

    Private Sub grdUsuarios_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdUsuarios.ClickCell

        txtIdUsuario.Text = grdUsuarios.ActiveRow.Cells("ID").Text

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        'activos
        LlenarTablaUsuariosActivos()
        Try
            diseniogrdUsuarios()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        'inactivos
        LlenarTablaUsuariosInactivos()
        Try
            diseniogrdUsuarios()
        Catch ex As Exception
        End Try

    End Sub

    Public Sub llenarComboBanco()
        Dim obj As New ProveedorBU
        Dim lsta As DataTable
        lsta = obj.ListaBancos()
        If Not lsta.Rows.Count = 0 Then
            lsta.Rows.InsertAt(lsta.NewRow, 0)
            cmbBanco.DataSource = lsta
            cmbBanco.DisplayMember = "banc_nombre"
            cmbBanco.ValueMember = "banc_bancoid"
        End If
    End Sub

    Public Sub llenarComboPais()
        Dim obj As New ProveedorBU
        Dim lsta As DataTable
        lsta = obj.ListaPaises()
        If Not lsta.Rows.Count = 0 Then
            lsta.Rows.InsertAt(lsta.NewRow, 0)
            cmbPaisProveedor.DataSource = lsta
            cmbPaisProveedor.DisplayMember = "pais_nombre"
            cmbPaisProveedor.ValueMember = "pais_paisid"
        End If
    End Sub

    Public Sub llenarComboCategoria()
        Dim obj As New ProveedorBU
        Dim lsta As DataTable
        lsta = obj.ListaCategorias()
        If Not lsta.Rows.Count = 0 Then
            lsta.Rows.InsertAt(lsta.NewRow, 0)
            cmbCategoria.DataSource = lsta
            cmbCategoria.DisplayMember = "CLASIFICACION"
            cmbCategoria.ValueMember = "ID"
        End If
    End Sub

    Public Sub llenarComboPais2()
        Dim obj As New ProveedorBU
        Dim lsta As DataTable
        lsta = obj.ListaPaises()
        If Not lsta.Rows.Count = 0 Then
            lsta.Rows.InsertAt(lsta.NewRow, 0)
            cmbPaisRazonSocial.DataSource = lsta
            cmbPaisRazonSocial.DisplayMember = "pais_nombre"
            cmbPaisRazonSocial.ValueMember = "pais_paisid"
        End If
    End Sub

    Public Sub llenarComboEstado()
        Dim obj As New ProveedorBU
        Dim lsta As DataTable
        lsta = obj.ListaEstados(cmbPaisRazonSocial.SelectedValue)
        If Not lsta.Rows.Count = 0 Then
            lsta.Rows.InsertAt(lsta.NewRow, 0)
            cmbEstadoRazonSocial.DataSource = lsta
            cmbEstadoRazonSocial.DisplayMember = "esta_nombre"
            cmbEstadoRazonSocial.ValueMember = "esta_estadoid"
        Else
            cmbEstadoRazonSocial.DataSource = Nothing
            cmbCiudadRazonSocial.DataSource = Nothing
        End If
    End Sub



    Public Sub llenarComboCiudad()
        Dim obj As New ProveedorBU
        Dim lsta As DataTable
        lsta = obj.ListaCiudades(cmbEstadoRazonSocial.SelectedValue)
        If Not lsta.Rows.Count = 0 Then
            lsta.Rows.InsertAt(lsta.NewRow, 0)
            cmbCiudadRazonSocial.DataSource = lsta
            cmbCiudadRazonSocial.DisplayMember = "city_nombre"
            cmbCiudadRazonSocial.ValueMember = "city_ciudadid"
        Else
            cmbCiudadRazonSocial.DataSource = Nothing
        End If
    End Sub

    Public Sub llenarComboGiros()
        Dim obj As New ProveedorBU
        Dim lsta As DataTable
        lsta = obj.ListaDeGiros()
        If Not lsta.Rows.Count = 0 Then
            lsta.Rows.InsertAt(lsta.NewRow, 0)
            cmbGiro.DataSource = lsta
            cmbGiro.DisplayMember = "GIRO"
            cmbGiro.ValueMember = "ID"
        End If
    End Sub

    Public Sub llenarComboTipoRazonSocial()
        Dim obj As New ProveedorBU
        Dim lsta As DataTable
        lsta = obj.ListaTiposRFC()
        If Not lsta.Rows.Count = 0 Then
            lsta.Rows.Add(New Object() {0, " "})
            cmbTipoRazonSocial.DataSource = lsta
            cmbTipoRazonSocial.DisplayMember = "Tipo"
            cmbTipoRazonSocial.ValueMember = "ID"
        Else
            cmbTipoRazonSocial.DataSource = Nothing
        End If
    End Sub

    '*************Fin llenar Combos
    '******************************************************************************************************************************
    Public Sub ModificarRFC()
        Dim objMensaje As New AdvertenciaForm
        Dim EntidadRFC As New DatosProveedor
        Dim objbu As New ProveedorBU

        If txtRfcRazonSocial.Text = "" Then
            EntidadRFC.prov_rfc = "-"
        Else
            EntidadRFC.prov_rfc = txtRfcRazonSocial.Text
        End If
        '--------------------
        If cmbTipoFiscal.Visible = True Then
            EntidadRFC.prov_tiporazonsocial = cmbTipoFiscal.Text
        ElseIf cmbTipoFiscal.Text = "" Then
            EntidadRFC.prov_tiporazonsocial = "-"
        Else
            EntidadRFC.prov_tiporazonsocial = cmbTipoFiscal.Text
        End If
        '-------------
        If cmbTipoDePersona.Visible = True Then
            EntidadRFC.prov_tipofiscal = cmbTipoDePersona.Text
        ElseIf cmbTipoDePersona.Text = "" Then
            EntidadRFC.prov_tipofiscal = "-"
        Else
            EntidadRFC.prov_tipofiscal = cmbTipoDePersona.Text
        End If
        '-------------
        If txtCurp.TextLength = 0 Then
            EntidadRFC.prov_curp = "-"
        Else
            EntidadRFC.prov_curp = txtCurp.Text
        End If
        '--------------
        EntidadRFC.prov_colonia = txtColonia.Text
        EntidadRFC.prov_ciudad = cmbCiudadRazonSocial.Text
        EntidadRFC.prov_calle = txtCalle.Text
        EntidadRFC.prov_numeroexterior = txtNumeroExterior.Text
        '-----------------
        If txtNumeroInterior.TextLength = 0 Then
            EntidadRFC.prov_numerointerior = "-"
        Else
            EntidadRFC.prov_numerointerior = txtNumeroInterior.Text
        End If
        '------------
        EntidadRFC.prov_codigopostal = txtCodigoPostal.Text
        EntidadRFC.prov_estado = cmbEstadoRazonSocial.Text

        If rdoNoActivoCompras.Checked = True Then
            EntidadRFC.prov_activoordenesdecompra = "NO"
            EntidadRFC.prov_activocompras = "NO"
        Else
            EntidadRFC.prov_activoordenesdecompra = "SI"
            EntidadRFC.prov_activocompras = "SI"
        End If

        If rdoNoActivoPagos.Checked = True Then
            EntidadRFC.prov_activopagos = "NO"
        Else
            EntidadRFC.prov_activopagos = "SI"
        End If
        '-----------------
        If txtNombre.TextLength = 0 Then
            EntidadRFC.prov_nombre = "-"
        Else
            EntidadRFC.prov_nombre = txtNombre.Text
        End If
        '----------------
        If txtApellidoPaterno.TextLength = 0 Then
            EntidadRFC.prov_apellidopaterno = "-"
        Else
            EntidadRFC.prov_apellidopaterno = txtApellidoPaterno.Text
        End If
        '---------------
        If txtApellidoMaterno.TextLength = 0 Then
            EntidadRFC.prov_apellidomaterno = "-"
        Else
            EntidadRFC.prov_apellidomaterno = txtApellidoMaterno.Text
        End If
        '---------------
        EntidadRFC.prov_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadRFC.prov_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        If txtRazonSocial.Text = "" Then
            EntidadRFC.prov_razonsocial = "-"
        Else
            Dim x = txtRazonSocial.Text + "," + cmbTipoRazonSocial.Text
            EntidadRFC.prov_razonsocial = x.Trim.Replace("  ", "")
        End If
        EntidadRFC.prov_pais = cmbPaisRazonSocial.Text
        EntidadRFC.prov_datosrfcid = txtIdrfc.Text
        objbu.EditarProveedorDatos(EntidadRFC)
    End Sub

    Public Function BuscarNombreORFCCuenta()
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable
        Dim rfc, tipo As String

        rfc = cmbRfcCuenta.SelectedText
        tipo = cmbTipoCuenta.SelectedText

        dtLista = objBU.BuscaContactoRepetido(txtNombreContacto.Text, txtCargoContacto.Text, cmbDepartamentoContaco.Text, txtProveedorid.Text)
        If dtLista.Rows.Count > 0 Then
            objAdvertencia.mensaje = "Ya hay un registro con el minsmo nombre y cargo registrado."
            objAdvertencia.ShowDialog()
        Else
            objConfirmacion.mensaje = "¿Está seguro de realizar este registro?"
            If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then

                GuardarContacto()
                objExito.mensaje = "Contacto registrado con éxito."
                objExito.ShowDialog()
                LlenarTablaContactosCobranza()
                Try
                    diseniogrdContactosCobranza()
                Catch ex As Exception
                End Try
                LlenarTablaContactosVentas()
                Try
                    diseniogrdContactosVentas()
                Catch ex As Exception
                End Try
            End If
        End If
        Return True
    End Function

    Private Sub btnGuardad3_Click(sender As Object, e As EventArgs) Handles btnGuardad3.Click

        If txtIdCuenta.TextLength = 0 Then
            If ValidacionDatosCta() = True Then
                objConfirmacion.mensaje = "¿Está seguro de realizar esté registro?"
                If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ValidacionDatosCta()
                    If ValidacionDatosCta() = True Then
                        GuardarBancoSICY()
                        GuardarCuenta()
                        LlenarTablaCuentasBancarias()
                        Try
                            diseniogrdCuentasBancarias()
                        Catch ex As Exception
                        End Try
                        objExito.mensaje = "Cuenta bancaria registrada con éxito."
                        objExito.ShowDialog()
                        LIMPIAR2()
                    End If
                End If
            Else
                objAdvertencia.mensaje = "Favor de llenar todos los campos."
                objAdvertencia.ShowDialog()
            End If
        End If
        If txtIdCuenta.TextLength <> 0 Then
            Dim objConfirmacion As New Tools.ConfirmarForm
            If ValidacionDatosCta() = True Then
                objConfirmacion.mensaje = "¿Está seguro de realizar estos cambios?"
                If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    If cmbBanco.Text <> "" And txtCuenta.Text <> "" And txtClabe.Text <> "" And txtCuentahabiente.Text <> "" And cmbTipoCuenta.Text <> "" And cmbRfcCuenta.Text <> "" Then
                        ModificarCuentaBancaria()
                        cmbBanco.Text = ""
                        txtSucursal.Text = ""
                        txtPlaza.Text = ""
                        txtCuenta.Text = ""
                        txtClabe.Text = ""
                        txtCuentahabiente.Text = ""
                        cmbTipoCuenta.Text = ""
                        cmbRfcCuenta.Text = 0
                        objExito.mensaje = "Cambios realizados con éxito."
                        objExito.ShowDialog()
                        LlenarTablaCuentasBancarias()
                        Try
                            diseniogrdCuentasBancarias()
                        Catch ex As Exception
                        End Try
                        LIMPIAR2()
                    Else
                        objAdvertencia.mensaje = "Favor de llenar todos los campos."
                        objAdvertencia.ShowDialog()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnGuardar4.Click
        If txtIdContacto.TextLength = 0 Then
            ValidacionDatosContacto()
            If ValidacionDatosContacto() = True Then
                BuscarContactosRepetidos()
            Else
                objAdvertencia.mensaje = "Favor de llenar todos los campos obligatorios."
                objAdvertencia.ShowDialog()
                LlenarTablaContactosCobranza()
                Try
                    diseniogrdContactosCobranza()
                Catch ex As Exception
                End Try
                LlenarTablaContactosVentas()
                Try
                    diseniogrdContactosVentas()
                Catch ex As Exception
                End Try
            End If

        End If

        If txtIdContacto.TextLength > 0 Then
            Dim objMensaje As New AdvertenciaForm
            Dim objConfirmacion As New Tools.ConfirmarForm
            objConfirmacion.StartPosition = FormStartPosition.CenterScreen
            objConfirmacion.mensaje = "¿Está seguro de realizar estos cambios?"
            If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then

                If cmbDepartamentoContaco.Text = "COBRANZA" Then

                    If txtNombreContacto.Text <> "" And txtCargoContacto.Text <> "" And txtTelefonoContacto.Text <> "" And txtEmailContacto.Text <> "" And cmbNotificar.Text <> "" And cmbDepartamentoContaco.Text <> "" And txtFoto.Text <> "" Then
                        ModificarContacto()
                        GuardarImagen()
                        objExito.mensaje = "Cambios realizados con éxito."
                        objExito.ShowDialog()
                        LlenarTablaContactosCobranza()
                        Try
                            diseniogrdContactosCobranza()
                        Catch ex As Exception
                        End Try
                        LlenarTablaContactosVentas()
                        Try
                            diseniogrdContactosVentas()
                        Catch ex As Exception
                        End Try
                        LIMPIAR3()
                    Else
                        objAdvertencia.mensaje = "Favor de llenar todos los campos obligatorios."
                        objAdvertencia.ShowDialog()
                    End If

                ElseIf cmbDepartamentoContaco.Text = "VENTAS" Then

                    If txtNombreContacto.Text <> "" And txtCargoContacto.Text <> "" And txtTelefonoContacto.Text <> "" And txtEmailContacto.Text <> "" And cmbNotificar.Text <> "" And cmbDepartamentoContaco.Text <> "" Then
                        ModificarContacto()
                        GuardarImagen()
                        objExito.mensaje = "Cambios realizados con éxito."
                        objExito.ShowDialog()
                        LlenarTablaContactosCobranza()
                        Try
                            diseniogrdContactosCobranza()
                        Catch ex As Exception
                        End Try
                        LlenarTablaContactosVentas()
                        Try
                            diseniogrdContactosVentas()
                        Catch ex As Exception
                        End Try
                        LIMPIAR3()
                    Else
                        objAdvertencia.mensaje = "Favor de llenar todos los campos obligatorios."
                        objAdvertencia.ShowDialog()
                    End If

                End If

            End If
        End If

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles btnGuardarCambios.Click

        If txtIdUsuario.TextLength = 0 Then
            Dim objMensaje As New AdvertenciaForm
            If txtUsuario.TextLength = 0 Or txtContraseña.TextLength = 0 Or txtNombreUsuario.TextLength = 0 Then
                lblUsuario.ForeColor = Drawing.Color.Red
                lblUsuario.ForeColor = Drawing.Color.Red
                lblContraseña.ForeColor = Drawing.Color.Red
                lblNombreUsuario.ForeColor = Drawing.Color.Red
                objAdvertencia.mensaje = "Favor de llenar todos los campos."
                objAdvertencia.ShowDialog()
            Else
                BuscarUsuariosRepetidos()
                LIMPIAR4()
            End If
        End If

        If txtIdUsuario.TextLength > 0 Then

            Dim objConfirmacion As New Tools.ConfirmarForm
            objConfirmacion.StartPosition = FormStartPosition.CenterScreen
            objConfirmacion.mensaje = "¿Está seguro de realizar estos cambios?"
            If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then

                If txtNombreUsuario.TextLength > 0 And txtUsuario.TextLength > 0 And txtContraseña.TextLength > 0 Then
                    ModificarUsuario()
                    txtNombreUsuario.Text = ""
                    txtUsuario.Text = ""
                    txtContraseña.Text = ""
                    objExito.mensaje = "Los cambios se realizaron con éxito."
                    objExito.ShowDialog()
                    LlenarTablaUsuariosActivos()
                    Try
                        diseniogrdUsuarios()
                    Catch ex As Exception
                    End Try
                    'diseniogrdUsuariosUsuariosProveedor()
                Else
                    objAdvertencia.mensaje = "Favor de llenar todos los campos obligatorios."
                    objAdvertencia.ShowDialog()
                End If
                'ModificarCuentaBancaria()
            End If
        End If
        LIMPIAR4()
    End Sub

    Public Function BuscarUsuariosRepetidos() As Boolean
        Dim objBU As New ProveedorBU
        Dim dtListaRFC As New DataTable
        dtListaRFC = objBU.BuscaUsuarioRepetido(txtNombreUsuario.Text, txtUsuario.Text, txtProveedorid.Text)
        If dtListaRFC.Rows.Count > 0 Then
            objInformacion.mensaje = "Ya hay un registro con ese nombre de usuario registrado"
            objInformacion.ShowDialog()
        Else
            objConfirmacion.mensaje = "¿Está seguro de realizar este registro?"
            If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                GuardarUsuario()
                objExito.mensaje = "Usuario registrado con éxito."
                objExito.ShowDialog()
                LlenarTablaUsuariosActivos()
                Try
                    diseniogrdUsuarios()
                Catch ex As Exception
                End Try
                'diseniogrdUsuariosUsuariosProveedor()
            End If
        End If
        Return True
    End Function

    Public Sub BuscarPoveedoresRepetidos()
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable
        dtLista = objBU.BuscaProveedorRepetido(txtNombreComercial.Text)
        If dtLista.Rows.Count > 0 Then
            objInformacion.mensaje = "Ya hay un proveedore registrado con ese nombre comercial."
            objInformacion.ShowDialog()
        Else
            VerificarCamposGenerales()
            If CamposGenerales = True Then
                objConfirmacion.mensaje = "¿Está seguro de realizar este registro?"
                If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    If txtNombreComercial.TextLength <> 0 And cmbGiro.SelectedIndex > 0 And cmbCategoria.SelectedIndex > 0 And cmbPaisProveedor.SelectedIndex > 0 Then
                        GuardarProveedor()
                        AgregarNave()
                        Dim objExito As New Tools.ExitoForm
                        objExito.mensaje = "Proveedor registrado con éxito."
                        objExito.ShowDialog()
                        accion = 1
                        'ListaProveedoresForm.Refresh()

                        pnlDatosGenerales.Enabled = False
                        btnGuardar.Visible = False
                        lblGuardarPrincipal.Visible = False
                        Me.TabDatos.Visible = True
                    Else
                        objAdvertencia.mensaje = "Favor de llenar todos los campos obligatorios."
                        objAdvertencia.ShowDialog()
                    End If
                End If
            Else
                ValidacionDatosGenerales()
                objAdvertencia.mensaje = "Favor de llenar todos los campos obligatorios."
                objAdvertencia.ShowDialog()
            End If

        End If
        'Return True
    End Sub

    Public Function AgregarNave()

        Dim objBU As New ProveedorBU
        Dim EntidadNave As New NaveProveedor
        EntidadNave.prna_activo = "SI"
        EntidadNave.dage_proveedorid = CInt(txtProveedorid.Text)
        EntidadNave.nave_naveid = txtNave.Text
        EntidadNave.prna_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadNave.prna_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadNave.prna_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadNave.prna_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        objBU.AsignarNave(EntidadNave)

    End Function

    Public Function BuscarPlazoRepetido() As Boolean
        Dim objBU As New ProveedorBU
        Dim dtListaRFC As New DataTable
        Dim id, idproveedor As Integer
        id = grdPlazo.ActiveRow.Cells(0).Text
        idproveedor = txtProveedorid.Text
        dtListaRFC = objBU.BuscaUsuarPlazoRepetido(id, idproveedor)
        If dtListaRFC.Rows.Count > 0 Then
            objInformacion.mensaje = "Ese plazo de pago ya fue asignado"
            objInformacion.ShowDialog()
        Else
            objConfirmacion.mensaje = "¿Está seguro de asignar este plazo de pago al proveedor?"
            If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                objExito.mensaje = "Plazo de pago asignado."
                objExito.ShowDialog()
                Dim idPlazo As Integer
                idPlazo = CInt(grdPlazo.ActiveRow.Cells(0).Text)
                Dim plazo As New PlazoPago
                plazo.plpa_plazopagoid = idPlazo
                plazo.dage_proveedorid = txtProveedorid.Text
                plazo.plpr_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                plazo.plpr_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                plazo.plpr_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
                plazo.plpr_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
                objBU.EditarProveedorPlazoPago(plazo)
                GuardarPlazoSICY()
                LlenarTablaPlazoProveedor()
                Try
                    diseniogrdPlazoProveedor()
                Catch ex As Exception
                End Try
                LlenarTablaUsuariosProveedor()
                Try
                    diseniogrdUsuariosUsuariosProveedor()
                Catch ex As Exception
                End Try
            End If
        End If
        Return True
    End Function

    Public Function BuscarContactosRepetidos() As Boolean
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable
        Dim objBU2 As New ProveedorBU
        Dim dtLista2 As New DataTable
        Dim idProveedor As Integer

        idProveedor = txtProveedorid.Text
        dtLista2 = objBU2.BuscarNumCobrador(idProveedor)
        numeroCobrador = dtLista2.Rows.Count()

        'If txtIdContacto.TextLength <> 0 Then

        dtLista = objBU.BuscaContactoRepetido(txtNombreContacto.Text, txtCargoContacto.Text, cmbDepartamentoContaco.Text, txtProveedorid.Text)
        If dtLista.Rows.Count > 0 Then
            objInformacion.mensaje = "Ya hay un registro igual. Favor de verificar."
            objInformacion.ShowDialog()
        Else
            objConfirmacion.mensaje = "¿Está seguro de realizar este registro?"
            If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If cmbDepartamentoContaco.Text = "COBRANZA" Then
                    GuardarCobradorSICY()
                    GuardarContactoCobranzaSICY()
                    If rdoContactoNoActivo.Checked = True Then
                        rdoContactoNoActivo.Checked = True
                        LlenarTablaContactosCobranza2()
                        Try
                            diseniogrdContactosCobranza()
                        Catch ex As Exception
                        End Try
                    Else
                        rdoContactoActivo.Checked = True
                        LlenarTablaContactosCobranza()
                        Try
                            diseniogrdContactosCobranza()
                        Catch ex As Exception
                        End Try
                    End If
                ElseIf cmbDepartamentoContaco.Text = "VENTAS" Then
                    GuardarContactoVentasSICY()
                    If rdoContactoNoActivo.Checked = True Then
                        rdoContactoNoActivo.Checked = True
                        LlenarTablaContactosVentas2()
                        Try
                            diseniogrdContactosCobranza()
                        Catch ex As Exception
                        End Try
                    Else
                        rdoContactoActivo.Checked = True
                        LlenarTablaContactosVentas()
                        Try
                            diseniogrdContactosCobranza()
                        Catch ex As Exception
                        End Try
                    End If
                End If
                GuardarContacto()
                GuardarImagen()
                objExito.mensaje = "Registro realizado."
                objExito.ShowDialog()
                LlenarTablaContactosCobranza()
                Try
                    diseniogrdContactosCobranza()
                Catch ex As Exception
                End Try
                LlenarTablaContactosVentas()
                Try
                    diseniogrdContactosVentas()
                Catch ex As Exception
                End Try
                LIMPIAR3()
            End If
        End If
        Return True
    End Function

    Private Sub grdPlazo_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdPlazo.DoubleClickCell

        Dim objConfirmacion As New Tools.ConfirmarForm
        Dim objMensaje As New AdvertenciaForm
        Dim id = grdPlazo.ActiveRow.Cells(0).Text

        If id <> "" Then
            BuscarPlazoRepetido()
        End If

    End Sub

    Private Sub grdPlazoProveedor_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdPlazoProveedor.DoubleClickCell
        Dim objConfirmacion As New Tools.ConfirmarForm
        Dim objMensaje As New AdvertenciaForm

        Dim idPlazo As String
        idPlazo = grdPlazoProveedor.ActiveRow.Cells(0).Text
        Dim plazo As New PlazoPago
        Dim objbu As New ProveedorBU

        If idPlazo <> "" Then

            plazo.plpa_plazopagoid = idPlazo
            objConfirmacion.mensaje = "¿Está seguro de quitar este plazo de pago al proveedor?"
            If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                objbu.EliminarPlazo(idPlazo)
                objExito.mensaje = "Se quito el plazo de pago."
                objExito.ShowDialog()
            End If
            LlenarTablaPlazoProveedor()
            Try
                diseniogrdPlazoProveedor()
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub grdNavesDisponibles_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdNavesDisponibles.DoubleClickCell

        Dim objBU As New ProveedorBU
        Dim EntidadNave As New NaveProveedor
        Dim idproveedor As Integer
        Dim naveid As String
        Dim dtLista As New DataTable
        idproveedor = txtProveedorid.Text
        naveid = grdNavesDisponibles.ActiveRow.Cells(0).Text

        If naveid <> "" Then

            dtLista = objBU.BuscaUsuarNaveRepetida(naveid, idproveedor)
            If dtLista.Rows.Count > 0 Then
                objAdvertencia.mensaje = "Esa nave ya fue asignada anteriormente."
                objAdvertencia.ShowDialog()
            Else
                EntidadNave.prna_activo = "SI"
                EntidadNave.dage_proveedorid = CInt(txtProveedorid.Text)
                EntidadNave.nave_naveid = naveid
                EntidadNave.prna_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                EntidadNave.prna_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                EntidadNave.prna_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
                EntidadNave.prna_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")

                objConfirmacion.mensaje = "¿Está seguro de asignar esta nave al proveedor?"
                If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    objBU.AsignarNave(EntidadNave)
                    objExito.mensaje = "Nave asignada con éxito."
                    objExito.ShowDialog()
                    LlenarTablaNaveProveedor()
                    Try
                        diseniogrdNavesProveedor()
                    Catch ex As Exception
                    End Try

                End If
            End If

        End If

    End Sub

    Private Sub btnActivarUsuario_Click(sender As Object, e As EventArgs)
        objConfirmacion.mensaje = "¿Está seguro de activar al usuario?"
        If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ActivarUsuario()
            txtIdUsuario.Text = ""
            objExito.mensaje = "Contacto activado."
            objExito.ShowDialog()
            LlenarTablaUsuariosActivos()
            Try
                diseniogrdUsuariosUsuariosProveedor()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnDesactivarUsuario_Click(sender As Object, e As EventArgs)
        objConfirmacion.mensaje = "¿Está seguro de desactivar al usuario?"
        If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
            DesactivarUsuario()
            txtIdUsuario.Text = ""

            objExito.mensaje = "Contacto desactivado."
            objExito.ShowDialog()
            LlenarTablaUsuariosInactivos()
            Try
                diseniogrdUsuariosUsuariosProveedor()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub grdCuentasBancarias_DoubleClick(sender As Object, e As EventArgs) Handles grdCuentasBancarias.DoubleClick
        txtIdCuenta.Text = grdCuentasBancarias.ActiveRow.Cells("ID").Text

        If txtIdCuenta.Text <> "" Then
            cmbTipoCuenta.Text = grdCuentasBancarias.ActiveRow.Cells("TIPO DE CUENTA").Text
            cmbRfcCuenta.Text = grdCuentasBancarias.ActiveRow.Cells("RFC").Text
            cmbBanco.Text = grdCuentasBancarias.ActiveRow.Cells("BANCO").Text
            txtSucursal.Text = grdCuentasBancarias.ActiveRow.Cells("SUCURSAL").Text
            txtPlaza.Text = grdCuentasBancarias.ActiveRow.Cells("PLAZA").Text
            txtCuenta.Text = grdCuentasBancarias.ActiveRow.Cells("CUENTA").Text
            txtClabe.Text = grdCuentasBancarias.ActiveRow.Cells("CLABE").Text
            txtCuentahabiente.Text = grdCuentasBancarias.ActiveRow.Cells("CUENTAHABIENTE").Text
            txtIdCuenta.Text = grdCuentasBancarias.ActiveRow.Cells("ID").Text
            If grdCuentasBancarias.ActiveRow.Cells("ACTIVA").Text = "SI" Then
                'column().hide=true
                rdoCuentaActiva.Checked = True
                rdoCuentaNoActiva.Checked = False
            Else
                rdoCuentaNoActiva.Checked = True
                rdoCuentaActiva.Checked = False
            End If
            If grdCuentasBancarias.ActiveRow.Cells("PREDETERMINADA").Text = "SI" Then
                rdoCuentaPredeterminada.Checked = True
                rdoCuentaNoPredeterminada.Checked = False
            Else
                rdoCuentaPredeterminada.Checked = False
                rdoCuentaNoPredeterminada.Checked = True
            End If
        End If

    End Sub

    Private Sub btnGuardar2_Click(sender As Object, e As EventArgs) Handles btnGuardar2.Click
        Dim objBU As New ProveedorBU
        Dim tablas As DataTable

        If txtIdrfc.TextLength = 0 Then
            If ValidacionDatosRFC() = True Then
                objConfirmacion.mensaje = "¿Está seguro de realizar esté registro?"
                If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    tablas = objBU.BuscarProveedorSicy(txtNombreComercial.Text)
                    Try
                        If txtSicy.Text = "" Then
                            GuardarProveedorSICY()
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        Try
                            GuardarRFCSICY()
                        Catch ex As Exception

                        End Try


                        GuardarProveedorRFC()
                    Catch ex As Exception
                    End Try
                    objExito.mensaje = "RFC registrado con éxito."
                    objExito.ShowDialog()
                    LlenarTablaRFC()
                    Try
                        diseniogrdRFC()
                    Catch ex As Exception
                    End Try
                    limpiarRFC()
                    cmbTipoFiscal.SelectedIndex = 0
                    cmbTipoDePersona.SelectedIndex = 0
                End If
            Else
                objAdvertencia.mensaje = "Favor de llenar todos los campos obligatorios"
                objAdvertencia.ShowDialog()
            End If
        End If

        If txtIdrfc.TextLength > 0 Then
            If ValidacionDatosRFC() = True Then
                objConfirmacion.mensaje = "¿Está seguro de realizar estos cambios?"
                If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ModificarRFC()
                    objExito.mensaje = "Cambios realizados con éxito."
                    objExito.ShowDialog()
                    rdoSiActivoPagos.Checked = True
                    rdoSiActivoPagos.Checked = True
                    limpiarRFC()
                    LlenarTablaRFC()
                    Try
                        diseniogrdRFC()
                    Catch ex As Exception
                    End Try
                    txtCalle.Text = ""
                    txtNumeroExterior.Text = ""
                    txtNumeroInterior.Text = ""
                    txtColonia.Text = ""
                    txtCodigoPostal.Text = ""
                    cmbCiudadRazonSocial.Text = ""
                    cmbEstadoRazonSocial.Text = ""
                    cmbPaisRazonSocial.Text = ""
                    txtCurp.Text = ""
                    txtNombre.Text = ""
                    txtApellidoPaterno.Text = ""
                    txtApellidoMaterno.Text = ""
                    txtRazonSocial.Text = ""
                End If
            Else
                objAdvertencia.mensaje = "Favor de no dejar campos en blanco."
                objAdvertencia.ShowDialog()
            End If
        End If
    End Sub

    Private Sub cmbTipoFiscal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoFiscal.SelectedIndexChanged
        If cmbTipoFiscal.Text = "FISCAL" Then
            cmbTipoDePersona.SelectedIndex = -1
            cmbTipoDePersona.Enabled = True
            lblTipoDePersona.Enabled = True
            txtNombre.Enabled = False
            ' txtNombre.BackColor = Color.Gray
            txtApellidoPaterno.Enabled = False
            ' txtApellidoPaterno.BackColor = Color.Gray
            txtApellidoMaterno.Enabled = False
            ' txtApellidoMaterno.BackColor = Color.Gray
            txtRfcRazonSocial.Enabled = True
            'txtRfcRazonSocial.BackColor = Color.Gray
            txtRfcRazonSocial.Enabled = True
            txtRazonSocial.Enabled = True
            txtCurp.Visible = True
            lblCalle.Text = "*Calle"
            lblColonia.Text = "*Colonia"
            lblNumeroExterior.Text = "*Numero exterior"
            txtCurp.Enabled = False
            'txtCurp.BackColor = Color.Gray
            txtRazonSocial.Text = ""
            txtNombre.Text = ""
            txtApellidoPaterno.Text = ""
            txtApellidoMaterno.Text = ""
            txtRfcRazonSocial.Enabled = True
        End If
        If cmbTipoFiscal.Text = "NO FISCAL" Then
            cmbTipoDePersona.SelectedIndex = -1
            cmbTipoDePersona.Enabled = False
            'cmbTipoDePersona.BackColor = Color.Gray
            lblTipoDePersona.Enabled = False
            txtNombre.Enabled = True
            txtApellidoPaterno.Enabled = True
            txtApellidoMaterno.Enabled = True
            txtRfcRazonSocial.Enabled = True
            lblRazonSocial.Text = "Razón Social"
            ' txtRfcRazonSocial.BackColor = Color.Gray
            txtRazonSocial.Enabled = False
            ' txtRazonSocial.BackColor = Color.Gray
            txtCurp.Visible = True
            lblCalle.Text = "Calle"
            lblCurp.Text = "*CURP"
            lblColonia.Text = "Colonia"
            lblNumeroExterior.Text = "Numero exterior"
            txtCurp.Enabled = Enabled
            txtRazonSocial.Text = ""
            txtNombre.Text = ""
            txtApellidoPaterno.Text = ""
            txtApellidoMaterno.Text = ""
            txtRfcRazonSocial.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        'BuscarCoincidencias()
    End Sub

    'Private Sub grdRFC_DoubleClickCell_1(sender As Object, e As DoubleClickCellEventArgs) Handles grdRFC.DoubleClickCell

    '    cmbTipoDePersona.Enabled = True
    '    lblTipoDePersona.Enabled = True
    '    Dim n, n2 As Integer

    '    If grdRFC.ActiveRow.Cells("TIPO RAZON SOCIAL").Text = "FISICA" Then
    '        n2 = 1
    '    ElseIf grdRFC.ActiveRow.Cells("TIPO RAZON SOCIAL").Text = "MORAL" Then
    '        n2 = 2
    '    End If
    '    cmbTipoFiscal.SelectedIndex = n2
    '    If grdRFC.ActiveRow.Cells("TIPO FISCAL").Text = "FISCAL" Then
    '        n = 1
    '    ElseIf grdRFC.ActiveRow.Cells("TIPO FISCAL").Text = "NO FISCAL" Then
    '        n = 2
    '    End If
    '    cmbTipoDePersona.SelectedIndex = n
    '    txtCalle.Text = grdRFC.ActiveRow.Cells("CALLE").Text
    '    txtNumeroInterior.Text = grdRFC.ActiveRow.Cells("NUMERO INTERIOR").Text
    '    txtNumeroExterior.Text = grdRFC.ActiveRow.Cells("NUMERO EXTERIOR").Text
    '    txtColonia.Text = grdRFC.ActiveRow.Cells("COLONIA").Text
    '    txtCodigoPostal.Text = grdRFC.ActiveRow.Cells("CP").Text
    '    cmbPaisRazonSocial.SelectedValue = CInt(grdRFC.ActiveRow.Cells("IDP").Text)
    '    cmbEstadoRazonSocial.SelectedValue = CInt(grdRFC.ActiveRow.Cells("IDE").Text)
    '    cmbCiudadRazonSocial.SelectedValue = CInt(grdRFC.ActiveRow.Cells("IDC").Text)
    '    txtRfcRazonSocial.Text = grdRFC.ActiveRow.Cells("RFC").Text
    '    txtCurp.Text = grdRFC.ActiveRow.Cells("CURP").Text
    '    txtNombre.Text = grdRFC.ActiveRow.Cells("NOMBRE").Text
    '    txtApellidoPaterno.Text = grdRFC.ActiveRow.Cells("APELLIDO PATERNO").Text
    '    txtApellidoMaterno.Text = grdRFC.ActiveRow.Cells("APELLIDO MATERNO").Text
    '    txtRazonSocial.Text = grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text
    '    txtIdrfc.Text = grdRFC.ActiveRow.Cells("ID").Text
    '    If grdRFC.ActiveRow.Cells("ACTIVO COMPRAS").Text = "SI" Then
    '        rdoSiActivoCompras.Checked = True
    '        rdoNoActivoCompras.Checked = False
    '    Else
    '        rdoSiActivoCompras.Checked = False
    '        rdoNoActivoCompras.Checked = True
    '    End If
    '    If grdRFC.ActiveRow.Cells("ACTIVO PAGOS").Text = "SI" Then
    '        rdoSiActivoPagos.Checked = True
    '        rdoNoActivoPagos.Checked = False
    '    Else
    '        rdoSiActivoPagos.Checked = False
    '        rdoNoActivoPagos.Checked = True
    '    End If

    'End Sub

    Private Sub txtNombreComercial_Leave(sender As Object, e As EventArgs) Handles txtNombreComercial.Leave
        If txtNombreComercial.TextLength > 3 Then
            Dim busqueda As String = txtNombreComercial.Text.ToUpper.Trim.Replace(" DEL ", " ").Replace(" DE ", " ").Replace(" SA ", " ").Replace(" S.A. ", " ").Replace(" CV ", " ").Replace(" C.V. ", " ").Replace(",", "").Replace(" PARA ", " ").Replace(" Y ", " ").Replace("CV", " ").Replace(" DEL ", " ").Replace(" EL ", " ").Replace(" EN ", " ")
            Dim objBu As New ProveedorBU
            Dim tabla As New DataTable
            Dim tabla2 As New DataTable
            Dim form As New CatalogoCoincidenciasProveedoresForm
            form.busqueda = busqueda
            form.naveid = nave
            form.naveNombre = navNombre
            tabla = objBu.BuscaCoincidenciaNombre(busqueda)
            'tabla2 = objBu.BuscaCoincidenciaNombreDAGE(busqueda)
            If tabla.Rows.Count <> 0 Then
                form.AsignarNave(Me)
                form.Show()
            ElseIf tabla2.Rows.Count <> 0 Then
                form.AsignarNave(Me)
                form.NAVEX = nave
                'form.ShowDialog()
                'If form.ShowDialog = Windows.Forms.DialogResult.Yes Then
                '    Me.Close()
                'End If
                'If form.ShowDialog = Windows.Forms.DialogResult.No Then
                '    Me.Close()
                'End If
                If form.ShowDialog = Windows.Forms.DialogResult.OK Then
                    'Me.Close()
                End If
                'If form.cerrar = 1 Then
                '    Me.Close()
                'End If
            End If
        End If
    End Sub

    Private Sub grdRFC_DoubleClickCell_2(sender As Object, e As DoubleClickCellEventArgs)
        txtIdrfc.Text = grdRFC.ActiveRow.Cells("ID").Text

        If txtIdrfc.Text <> "" Then
            'cmbTipoDePersona.Enabled = True
            'cmbTipoFiscal.Enabled = True
            txtNombreComercial.Text = grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text
            txtCalle.Text = grdRFC.ActiveRow.Cells("CALLE").Text
            txtNumeroInterior.Text = grdRFC.ActiveRow.Cells("NUMERO INTERIOR").Text
            txtNumeroExterior.Text = grdRFC.ActiveRow.Cells("NUMERO EXTERIOR").Text
            txtColonia.Text = grdRFC.ActiveRow.Cells("COLONIA").Text
            txtCodigoPostal.Text = grdRFC.ActiveRow.Cells("CP").Text
            txtRfcRazonSocial.Text = grdRFC.ActiveRow.Cells("RFC").Text
            cmbPaisRazonSocial.SelectedValue = grdRFC.ActiveRow.Cells("IDP").Text
            cmbEstadoRazonSocial.SelectedValue = grdRFC.ActiveRow.Cells("IDE").Text
            cmbCiudadRazonSocial.SelectedValue = grdRFC.ActiveRow.Cells("IDC").Text
            cmbTipoDePersona.Text = grdRFC.ActiveRow.Cells("TIPO RAZON SOCIAL").Text.ToString
            cmbTipoFiscal.Text = grdRFC.ActiveRow.Cells("TIPO FISCAL").Text.ToString
            cmbTipoDePersona.Text = grdRFC.ActiveRow.Cells("TIPO RAZON SOCIAL").Text.ToString
            txtCurp.Text = grdRFC.ActiveRow.Cells("CURP").Text
            Dim RazonS As String
            RazonS = Replace(grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text, "   ", "")
            txtNombreComercial.Text = RazonS
            txtNombreComercial.Text = RazonS
            txtNombreComercial.Text = RazonS
            txtRazonSocial.Text = RazonS
            txtRfcRazonSocial.Text = grdRFC.ActiveRow.Cells("RFC").Text
            txtNombre.Text = grdRFC.ActiveRow.Cells("NOMBRE").Text
            txtApellidoPaterno.Text = grdRFC.ActiveRow.Cells("APELLIDO PATERNO").Text
            txtApellidoMaterno.Text = grdRFC.ActiveRow.Cells("APELLIDO MATERNO").Text
            txtSicy.Text = grdRFC.ActiveRow.Cells("ID SICY").Text
            txtIdrfc.Text = grdRFC.ActiveRow.Cells("ID").Text
            If grdRFC.ActiveRow.Cells("AC").Text = "SI" Then
                rdoSiActivoCompras.Checked = True
                rdoNoActivoCompras.Checked = False
            Else
                rdoSiActivoCompras.Checked = False
                rdoNoActivoCompras.Checked = True
            End If
            If grdRFC.ActiveRow.Cells("AP").Text = "SI" Then
                rdoSiActivoPagos.Checked = True
                rdoNoActivoPagos.Checked = False
            Else
                rdoSiActivoPagos.Checked = False
                rdoNoActivoPagos.Checked = True
            End If
            txtNombreComercial.Text = RazonS
            txtNombreComercial.Text = RazonS
        End If
        'txtNombreComercial.Text = 
    End Sub

    Private Sub grdContactoVentas_ClickCell_1(sender As Object, e As ClickCellEventArgs) Handles grdContactoVentas.ClickCell
        txtIdContacto.Text = ""
        txtIdContacto.Text = grdContactoVentas.ActiveRow.Cells(0).Text
        'btnActivar.Visible = True
        'btnDesactivar.Visible = True
        'lblActivar.Visible = True
        'lblDesactivar.Visible = True
    End Sub

    Private Sub grdNavesAsociadas_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdNavesAsociadas.DoubleClickCell
        Dim id As String
        Dim id2 As Integer
        id = grdNavesAsociadas.ActiveRow.Cells("1").Text
        If id <> "" Then

            id2 = CInt(grdNavesAsociadas.ActiveRow.Cells("1").Text)
            Dim nave As New ProveedorNave
            Dim objbu As New ProveedorBU
            nave.nave_naveid = id2
            objConfirmacion.mensaje = "¿Está seguro de quitar esta nave al proveedor?"
            If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                objbu.EliminarNave(id)
            End If
            LlenarTablaNaveProveedor()
            Try
                diseniogrdNavesProveedor()
            Catch ex As Exception
            End Try

        End If

    End Sub

    Private Sub permitirSoloNumeros(sender As Object, e As KeyPressEventArgs) Handles txtCodigoPostal.KeyPress, txtTiempoDeRespuesta.KeyPress, txtTiempoDeEntrega.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub permitirSoloLetras(sender As Object, e As KeyPressEventArgs) Handles txtColonia.KeyPress, txtCalle.KeyPress, txtNombre.KeyPress, txtApellidoMaterno.KeyPress, txtApellidoPaterno.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cmbTipoCuenta_TextChanged(sender As Object, e As EventArgs) Handles cmbTipoCuenta.TextChanged
        If cmbTipoCuenta.Text = "NO FISCAL" Then

            txtCuentahabiente.Text = ""
            txtCuentahabiente.Enabled = True
            llenarComboRFCNombre()
        ElseIf cmbTipoCuenta.Text = "FISCAL" Then
            txtCuentahabiente.Text = ""
            txtCuentahabiente.Enabled = False
            llenarComboRFC()
            'txtCuentahabiente.BackColor = Color.Gray
        End If
    End Sub

    '******************* llenar combos
    Public Sub llenarComboRFC()
        Dim obj As New ProveedorBU
        Dim lsta As DataTable
        lsta = obj.ListaRFC(txtProveedorid.Text)
        If Not lsta.Rows.Count = 0 Then
            lsta.Rows.InsertAt(lsta.NewRow, 0)
            cmbRfcCuenta.DataSource = lsta
            cmbRfcCuenta.DisplayMember = "prov_rfc"
            cmbRfcCuenta.ValueMember = "prov_rfc"
        End If
    End Sub

    Public Sub llenarComboRFCNombre()
        Dim obj As New ProveedorBU
        Dim lsta As DataTable
        lsta = obj.ListaNombresRFC(txtProveedorid.Text)
        If Not lsta.Rows.Count = 0 Then
            lsta.Rows.InsertAt(lsta.NewRow, 0)
            cmbRfcCuenta.DataSource = lsta
            cmbRfcCuenta.DisplayMember = "prov_razonsocial"
            cmbRfcCuenta.ValueMember = "prov_razonsocial"
        End If
        If cmbRfcCuenta.SelectedIndex > 0 Then
            'txtCuentahabiente.Text = cmbRfcCuenta.Text
        End If
    End Sub

    Private Sub txtRfcRazonSocial_Leave(sender As Object, e As EventArgs) Handles txtRfcRazonSocial.Leave
        Dim form2 As New CatalogoCoincidenciasRFC
        If txtRfcRazonSocial.TextLength <> 0 Then
            If cmbTipoFiscal.Text = "FISCAL" Then
                If txtSicy.TextLength = 0 Then

                    Dim busqueda As String = txtRfcRazonSocial.Text.ToUpper.Trim.Replace("-", " ")
                    'Dim busqueda As String = txtRfcRazonSocial.Text
                    Dim separadores() As String = {"-", " "}
                    Dim objBu As New ProveedorBU
                    Dim tabla As New DataTable

                    Dim form3 As New CatalogoCoincidenciasRFC

                    form2.busqueda = busqueda
                    form2.naveid = nave
                    form2.naveNombre = navNombre
                    tabla = objBu.BuscaCoincidenciaRFC(busqueda)

                    If tabla.Rows.Count <> 0 Then
                        'form2.AsignarNave(Me)
                        'form2.Show()
                        If form2.ShowDialog = Windows.Forms.DialogResult.OK Then
                            txtSicy.Text = form2.ID
                        End If
                        txtSicy.Text = form2.ID
                        If form2.encontrados = 1 Then
                            objAdvertencia.mensaje = "No se puede insertar el RFC" & vbCrLf & busqueda & vbCrLf & "Ya hay un RFC igual capturado en sistema"
                            objAdvertencia.ShowDialog()
                            Me.Close()
                        End If
                    End If

                End If
            End If
        End If
        txtSicy.Text = form2.ID
        If txtRfcRazonSocial.TextLength <> 0 Then
            validarRFC()
        End If
    End Sub

    Private Sub grdContactoVentas_DoubleClickCell_1(sender As Object, e As DoubleClickCellEventArgs) Handles grdContactoVentas.DoubleClickCell
        If txtIdContacto.Text <> "" Then

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV", "DATOSDERFC") Then
                txtNombreContacto.Text = grdContactoVentas.ActiveRow.Cells("NOMBRE").Text
                txtCargoContacto.Text = grdContactoVentas.ActiveRow.Cells("CARGO").Text
                txtEmailContacto.Text = grdContactoVentas.ActiveRow.Cells("EMAIL").Text
                txtTelefonoContacto.Text = grdContactoVentas.ActiveRow.Cells("TELEFONO").Text
                txtIdContacto.Text = grdContactoVentas.ActiveRow.Cells("ID").Text
                cmbNotificar.Text = grdContactoVentas.ActiveRow.Cells("NOTIFICACION DE PAGO").Text
                cmbDepartamentoContaco.Text = grdContactoVentas.ActiveRow.Cells("DEPARTAMENTO").Text
                btnGuardar4.Visible = True
                lblGuardar4.Visible = True

                If grdContactoVentas.ActiveRow.Cells("ACTIVO").Text = "NO" Then
                    rdoContactoNoActivo.Checked = True
                Else
                    rdoContactoActivo.Checked = True
                End If
            End If

        End If
    End Sub

    Private Sub txtApellidoPaterno_Leave(sender As Object, e As EventArgs) Handles txtApellidoPaterno.Leave
        If txtNombre.Text <> "" And txtApellidoPaterno.Text <> "" Then
            If cmbTipoFiscal.Text = "NO FISCAL" Then

                Dim busqueda As String = txtNombre.Text + " " + txtApellidoPaterno.Text

                Dim objBu As New ProveedorBU
                Dim tabla As New DataTable
                Dim form3 As New CatalogoCoincidenciasNombresRFC

                form3.busqueda = busqueda
                form3.naveid = nave
                form3.naveNombre = navNombre
                tabla = objBu.BuscaCoincidenciaNombreRazonSocial(busqueda)

                If tabla.Rows.Count <> 0 Then
                    'form3.AsignarNave(Me)
                    form3.Show()
                End If

            End If
        End If
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        txtRazonSocial.Text = txtNombre.Text + " " + txtApellidoPaterno.Text + " " + txtApellidoMaterno.Text
    End Sub

    Private Sub txtApellidoPaterno_TextChanged(sender As Object, e As EventArgs) Handles txtApellidoPaterno.TextChanged
        txtRazonSocial.Text = txtNombre.Text + " " + txtApellidoPaterno.Text + " " + txtApellidoMaterno.Text
    End Sub

    Private Sub txtApellidoMaterno_TextChanged(sender As Object, e As EventArgs) Handles txtApellidoMaterno.TextChanged
        txtRazonSocial.Text = txtNombre.Text + " " + txtApellidoPaterno.Text + " " + txtApellidoMaterno.Text
    End Sub

    Private Sub grdRFC_DoubleClick(sender As Object, e As EventArgs) Handles grdRFC.DoubleClick

        txtIdrfc.Text = grdRFC.ActiveRow.Cells("ID").Text

        If txtIdrfc.Text <> "" Then
            'cmbTipoDePersona.Enabled = True
            'cmbTipoFiscal.Enabled = True
            txtNombreComercial.Text = grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text
            txtCalle.Text = grdRFC.ActiveRow.Cells("CALLE").Text
            txtNumeroInterior.Text = grdRFC.ActiveRow.Cells("NUMERO INTERIOR").Text
            txtNumeroExterior.Text = grdRFC.ActiveRow.Cells("NUMERO EXTERIOR").Text
            txtColonia.Text = grdRFC.ActiveRow.Cells("COLONIA").Text
            txtCodigoPostal.Text = grdRFC.ActiveRow.Cells("CP").Text
            txtRfcRazonSocial.Text = grdRFC.ActiveRow.Cells("RFC").Text
            cmbPaisRazonSocial.SelectedValue = grdRFC.ActiveRow.Cells("IDP").Text
            cmbEstadoRazonSocial.SelectedValue = grdRFC.ActiveRow.Cells("IDE").Text
            cmbCiudadRazonSocial.SelectedValue = grdRFC.ActiveRow.Cells("IDC").Text
            cmbTipoDePersona.Text = grdRFC.ActiveRow.Cells("TIPO RAZON SOCIAL").Text.ToString
            cmbTipoFiscal.Text = grdRFC.ActiveRow.Cells("TIPO FISCAL").Text.ToString
            cmbTipoDePersona.Text = grdRFC.ActiveRow.Cells("TIPO RAZON SOCIAL").Text.ToString
            txtCurp.Text = grdRFC.ActiveRow.Cells("CURP").Text
            ''''''''''''''''''''''''''''''''''''''''''''''
            If grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text.Contains("S.A. DE C.V.") Or grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text.Contains("SA DE CV") Then
                If grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text.Contains("S.A. DE C.V.") Then
                    txtRazonSocial.Text = grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text.Trim.Replace("S.A. DE C.V.", "")
                ElseIf grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text.Contains("SA DE CV") Then
                    txtRazonSocial.Text = grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text.Trim.Replace("SA DE CV", "")
                End If
                cmbTipoRazonSocial.SelectedValue = 1
            ElseIf nombreComercial.Contains("S. DE R.L. DE C.V.") Then
                txtRazonSocial.Text = grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text.Trim.Replace("S. DE R.L. DE C.V.", "")
                cmbTipoRazonSocial.SelectedValue = 2
            Else
                txtRazonSocial.Text = grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text
                cmbTipoRazonSocial.SelectedValue = 0
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''
            'txtRazonSocial.Text = grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text
            'Dim RazonS As String
            'RazonS = Replace(grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text, "   ", "")
            'txtNombreComercial.Text = RazonS
            'txtNombreComercial.Text = RazonS
            'txtNombreComercial.Text = RazonS
            'txtRazonSocial.Text = RazonS
            txtRfcRazonSocial.Text = grdRFC.ActiveRow.Cells("RFC").Text
            txtNombre.Text = grdRFC.ActiveRow.Cells("NOMBRE").Text
            txtApellidoPaterno.Text = grdRFC.ActiveRow.Cells("APELLIDO PATERNO").Text
            txtApellidoMaterno.Text = grdRFC.ActiveRow.Cells("APELLIDO MATERNO").Text
            txtSicy.Text = grdRFC.ActiveRow.Cells("ID SICY").Text
            txtIdrfc.Text = grdRFC.ActiveRow.Cells("ID").Text
            If grdRFC.ActiveRow.Cells("AC").Text = "SI" Then
                rdoSiActivoCompras.Checked = True
                rdoNoActivoCompras.Checked = False
            Else
                rdoSiActivoCompras.Checked = False
                rdoNoActivoCompras.Checked = True
            End If
            If grdRFC.ActiveRow.Cells("AP").Text = "SI" Then
                rdoSiActivoPagos.Checked = True
                rdoNoActivoPagos.Checked = False
            Else
                rdoSiActivoPagos.Checked = False
                rdoNoActivoPagos.Checked = True
            End If
        End If
        If txtIdrfc.Text <> "" Then
            'cmbTipoDePersona.Enabled = True
            'cmbTipoFiscal.Enabled = True
            ''''''''''''''''''''''''''''''''''''''''''''''
            'If grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text.Contains("S.A. DE C.V.") Then
            '    txtRazonSocial.Text = grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text.Trim.Replace("S.A. DE C.V.", "")
            '    cmbTipoRazonSocial.SelectedValue = 1
            'ElseIf grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text.Contains("S. DE R.L. DE C.V.") Then
            '    txtRazonSocial.Text = grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text.Trim.Replace("S. DE R.L. DE C.V.", "")
            '    cmbTipoRazonSocial.SelectedValue = 2
            'Else
            '    txtRazonSocial.Text = grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text
            '    cmbTipoRazonSocial.SelectedValue = 0
            'End If
            If grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text.Contains("S.A. DE C.V.") Or grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text.Contains("SA DE CV") Then
                If grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text.Contains("S.A. DE C.V.") Then
                    txtRazonSocial.Text = grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text.Trim.Replace("S.A. DE C.V.", "")
                ElseIf grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text.Contains("SA DE CV") Then
                    txtRazonSocial.Text = grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text.Trim.Replace("SA DE CV", "")
                End If
                cmbTipoRazonSocial.SelectedValue = 1
            ElseIf nombreComercial.Contains("S. DE R.L. DE C.V.") Then
                txtRazonSocial.Text = grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text.Trim.Replace("S. DE R.L. DE C.V.", "")
                cmbTipoRazonSocial.SelectedValue = 2
            Else
                txtRazonSocial.Text = grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text
                cmbTipoRazonSocial.SelectedValue = 0
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''
            'txtRazonSocial.Text = grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text
            txtCalle.Text = grdRFC.ActiveRow.Cells("CALLE").Text
            txtNumeroInterior.Text = grdRFC.ActiveRow.Cells("NUMERO INTERIOR").Text
            txtNumeroExterior.Text = grdRFC.ActiveRow.Cells("NUMERO EXTERIOR").Text
            txtColonia.Text = grdRFC.ActiveRow.Cells("COLONIA").Text
            txtCodigoPostal.Text = grdRFC.ActiveRow.Cells("CP").Text
            txtRfcRazonSocial.Text = grdRFC.ActiveRow.Cells("RFC").Text
            cmbPaisRazonSocial.SelectedValue = grdRFC.ActiveRow.Cells("IDP").Text
            cmbEstadoRazonSocial.SelectedValue = grdRFC.ActiveRow.Cells("IDE").Text
            cmbCiudadRazonSocial.SelectedValue = grdRFC.ActiveRow.Cells("IDC").Text
            cmbTipoDePersona.Text = grdRFC.ActiveRow.Cells("TIPO RAZON SOCIAL").Text.ToString
            cmbTipoFiscal.Text = grdRFC.ActiveRow.Cells("TIPO FISCAL").Text.ToString
            cmbTipoDePersona.Text = grdRFC.ActiveRow.Cells("TIPO RAZON SOCIAL").Text.ToString
            txtCurp.Text = grdRFC.ActiveRow.Cells("CURP").Text
            ' txtRazonSocial.Text = grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text
            Dim RazonS As String
            'RazonS = Replace(grdRFC.ActiveRow.Cells("RAZON SOCIAL").Text, "   ", "")
            'txtNombreComercial.Text = RazonS
            'txtNombreComercial.Text = RazonS
            'txtNombreComercial.Text = RazonS
            'txtRazonSocial.Text = RazonS
            txtRfcRazonSocial.Text = grdRFC.ActiveRow.Cells("RFC").Text
            txtNombre.Text = grdRFC.ActiveRow.Cells("NOMBRE").Text
            txtApellidoPaterno.Text = grdRFC.ActiveRow.Cells("APELLIDO PATERNO").Text
            txtApellidoMaterno.Text = grdRFC.ActiveRow.Cells("APELLIDO MATERNO").Text
            txtSicy.Text = grdRFC.ActiveRow.Cells("ID SICY").Text
            txtIdrfc.Text = grdRFC.ActiveRow.Cells("ID").Text
            If grdRFC.ActiveRow.Cells("AC").Text = "SI" Then
                rdoSiActivoCompras.Checked = True
                rdoNoActivoCompras.Checked = False
            Else
                rdoSiActivoCompras.Checked = False
                rdoNoActivoCompras.Checked = True
            End If
            If grdRFC.ActiveRow.Cells("AP").Text = "SI" Then
                rdoSiActivoPagos.Checked = True
                rdoNoActivoPagos.Checked = False
            Else
                rdoSiActivoPagos.Checked = False
                rdoNoActivoPagos.Checked = True
            End If

        End If

    End Sub

        Public Sub validarRFC()
        If cmbTipoDePersona.Text = "FISICA" Then
            If Regex.IsMatch(txtRfcRazonSocial.Text.Trim, "^([A-Z\s]{4})\d{6}([A-Z\w]{3})$") = False Then
                objAdvertencia.mensaje = "RFC de persona fisica no valido"
                objAdvertencia.ShowDialog()
                lblRfcCuenta.ForeColor = Drawing.Color.Red
                txtRfcRazonSocial.Focus()
            End If
        ElseIf cmbTipoDePersona.Text = "MORAL" Then
            If Regex.IsMatch(txtRfcRazonSocial.Text.Trim, "^([A-Z\s]{3})\d{6}([A-Z\w]{3})$") = False Then
                objAdvertencia.mensaje = "RFC de persona moral no valido"
                objAdvertencia.ShowDialog()
                lblRfcCuenta.ForeColor = Drawing.Color.Red
                txtRfcRazonSocial.Focus()
            End If
        End If
    End Sub

    Private Sub textbox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRfcRazonSocial.KeyPress
        Dim x = txtRfcRazonSocial.TextLength + 1
        If cmbTipoDePersona.Text = "FISICA" Then
            If x < 4 Then
                If Char.IsDigit(e.KeyChar) Then
                    e.Handled = True
                End If

            End If
            If x < 4 Then
                If Char.IsDigit(e.KeyChar) Then
                    e.Handled = True
                End If

            End If
            If x > 4 Then
                If Char.IsDigit(e.KeyChar) Then
                    e.Handled = False
                ElseIf Char.IsControl(e.KeyChar) Then
                    e.Handled = False
                ElseIf Char.IsLetter(e.KeyChar) Then
                    e.Handled = True
                End If
                If x > 10 And x < 13 Then
                    If Char.IsLetter(e.KeyChar) Then
                        e.Handled = False
                    ElseIf Char.IsControl(e.KeyChar) Then
                        e.Handled = False
                    ElseIf Char.IsDigit(e.KeyChar) Then
                        e.Handled = False
                    Else
                        e.Handled = True
                    End If
                End If
            ElseIf x <= 4 And x < 10 Or x > 9 Then
                If Char.IsLetter(e.KeyChar) Then
                    e.Handled = False
                ElseIf Char.IsControl(e.KeyChar) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End If
        ElseIf cmbTipoDePersona.Text = "MORAL" Then
            If x <= 3 Then
                If Char.IsDigit(e.KeyChar) Then
                    e.Handled = True
                End If

            End If
            If x <= 3 Then
                If Char.IsDigit(e.KeyChar) Then
                    e.Handled = True
                End If
            End If
            If x > 3 Then
                If Char.IsDigit(e.KeyChar) Then
                    e.Handled = False
                ElseIf Char.IsControl(e.KeyChar) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
                If x >= 3 And x > 9 Then
                    If Char.IsLetter(e.KeyChar) Then
                        e.Handled = False
                    ElseIf Char.IsControl(e.KeyChar) Then
                        e.Handled = False
                    ElseIf Char.IsDigit(e.KeyChar) Then
                        e.Handled = False
                    Else
                        e.Handled = True
                    End If
                End If
            ElseIf x > 3 And x < 10 Or x > 9 Then
                If Char.IsLetter(e.KeyChar) Then
                    e.Handled = False
                ElseIf Char.IsControl(e.KeyChar) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End If
        Else
            If Char.IsLetter(e.KeyChar) Then
                e.Handled = True
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = True
            ElseIf Char.IsDigit(e.KeyChar) Then
                e.Handled = True
            Else
                e.Handled = True
            End If
        End If

        Me.txtRfcRazonSocial.Text = Trim(Replace(Me.txtRfcRazonSocial.Text, "  ", " "))
        txtRfcRazonSocial.Select(txtRfcRazonSocial.Text.Length, 0)
    End Sub

    Private Sub txtRazonSocial_Leave(sender As Object, e As EventArgs) Handles txtRazonSocial.Leave
        If txtRazonSocial.TextLength > 3 Then
            Try
                Dim busqueda As String = txtRazonSocial.Text

                Dim objBu As New ProveedorBU
                Dim tabla As New DataTable
                Dim form3 As New CatalogoCoincidenciasNombresRFC

                form3.busqueda = busqueda
                form3.naveid = nave
                form3.naveNombre = navNombre
                form3.Labeltitulo2.Visible = False
                tabla = objBu.BuscaCoincidenciaRazonSocial(busqueda)
                form3.Variable = 1
                If tabla.Rows.Count <> 0 Then
                    'form3.AsignarNave(Me)
                    form3.Show()
                    txtSicy.Text = form3.idsicy
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class