Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Drawing
Imports Proveedores.BU

Public Class AltaProveedorForm2

    Public NombreNave As String = String.Empty
    Public ProveedorID As Integer = -1
    Public NaveID As Integer = -1
    Private dage_ProveedorID As Integer = -1
    Dim LimpiarDAtos As Boolean = False
    Dim SeleccionarTipoPersonas As Boolean = False
    Dim InterfazCargaCompleta As Boolean = True
    Dim Dage_ProveedorNoFiscal As Integer = -1
    Dim ProveedorDageNoExiste As Boolean = False
    Dim ProveedorID_Dage_noRalacionado As Integer = -1
    Dim PagoPorParcialidades As Integer = 0


    Private Sub AltaProveedorForm2_Load(sender As Object, e As EventArgs) Handles Me.Load
        InterfazCargaCompleta = False
        CargarNombresComerciales()
        CargarTipoRazonSocial()
        CargarPaises()
        CargarClasificaciones()
        btnGuardar.Enabled = False
        CargarPlazoPago()
        CargarInfoMoneda()
        txtNombreComercial.Enabled = False
        txtRFC.SelectionStart = 0
        HabilitarDeshabilitarControles()
        If ProveedorID <> -1 Then
            lblTitulo.Text = "Edición de Proveedor"
            Me.Text = "Edición de Proveedor"
            CargarInformacionProveedor()
            btnAgregarNombreComercial.Enabled = False
            grdPlazosPago.Enabled = True
            btnGuardar.Enabled = True
            HabilitarControloesedicion()
        Else
            grdPlazosPago.Enabled = False
        End If
        InterfazCargaCompleta = True


    End Sub

    Private Sub LimpiarEtiquetas()
        lblrfc.ForeColor = Color.Black
        lblSicy.ForeColor = Color.Black
        lblRazonSocial.ForeColor = Color.Black
        lblNombre.ForeColor = Color.Black
        lblPaterno.ForeColor = Color.Black
        lblMaterno.ForeColor = Color.Black
        lblPais.ForeColor = Color.Black
        lblEstado.ForeColor = Color.Black
        lblCiudad.ForeColor = Color.Black
        lblColonia.ForeColor = Color.Black
        lblCalle.ForeColor = Color.Black
        lblNumeroExterior.ForeColor = Color.Black
        lblNumeroInterior.ForeColor = Color.Black
        lblCodigoPostal.ForeColor = Color.Black
        lblClasificacion.ForeColor = Color.Black
        lblGiro.ForeColor = Color.Black

    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim AltaProveevdor As New Proveedores.BU.ProveedorBU
        Dim ObjProveedor As New Entidades.DatosProveedor
        Dim DTClasificacionGiro As DataTable
        Dim objPlazoPago As New Entidades.PlazoProveedor
        Dim PlazoPago As Integer = -1
        Dim DtInformacion As DataTable
        Dim PlazoSeleccionado As Integer = 0
        Dim ExisteRazonSocialNoFiscal As Boolean = False
        Dim mensajeConfirmacion As New ConfirmarForm
        Dim DTExisteNaveNombreComercial As DataTable
        Dim DTExisteNAveNombreComercialNoFiscal As DataTable
        Dim objbu As New Proveedores.BU.ProveedorBU
        Dim dage_proveedor As Integer = -1
        Dim MonedaSeleccionada As Integer = 0
        Dim Monedas As String = String.Empty

        If cmbTipoFiscal.Text = "NO FISCAL" Then
            ExisteRazonSocialNoFiscal = BuscarRazonSocialNoFiscal()
            If ExisteRazonSocialNoFiscal = True Then
                DTExisteNaveNombreComercial = objbu.BuscarNaveNombreComercial(NaveID, Dage_ProveedorNoFiscal)
                CargarInformacionProveedor()
                DesactivarCampos()
                cmbNombreComercial.Enabled = False
                cmbTipoFiscal.Enabled = False
                cmbTipoPersona.Enabled = False
                btnAgregarNombreComercial.Enabled = False
                If DTExisteNaveNombreComercial.Rows.Count > 0 Then
                    dage_ProveedorID = DTExisteNaveNombreComercial.Rows(0).Item("dage_proveedorid").ToString()
                    If dage_ProveedorID = -1 Then
                        mensajeConfirmacion.mensaje = "Ya se dio de alta una razón social con el mismo nombre, ¿Desea dar de alta la razón social con la nave?"
                        If mensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                            objbu.InsertarRelacionNaveNombreComercial(Dage_ProveedorNoFiscal, NaveID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                            objbu.ActualizarPaisNombreComercial(Dage_ProveedorNoFiscal, cmbPais.Text.ToString.Trim())
                            btnGuardar.Enabled = False
                            show_message("Exito", "Ya se dio de alta la razon social con la nave")
                        Else
                            btnGuardar.Enabled = False
                            DesactivarCampos()
                        End If
                    Else
                        show_message("Advertencia", "Ya se dio de alta una razón social con el mismo nombre")
                        btnGuardar.Enabled = False
                    End If
                    Return
                End If
            End If
        End If

        If ValidarInformacion() = True Then

            For Each Fila As UltraGridRow In grdMoneda.Rows
                If Fila.Cells(" ").Value = True Then
                    MonedaSeleccionada = MonedaSeleccionada + 1
                End If
            Next

            If MonedaSeleccionada = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "Se debe seleccionar al menos una moneda.")
                Exit Sub
            End If

            For Each Fila As UltraGridRow In grdPlazosPago.Rows
                If Fila.Cells(" ").Value = True Then
                    PlazoSeleccionado = PlazoSeleccionado + 1
                End If
            Next

            If PlazoSeleccionado = 0 Then
                show_message("Advertencia", "Se debe seleccionar al menos un plazo de pago")
            Else
                If cmbTipoFiscal.Text.Trim() = "FISCAL" Then
                    If ValidarNombreRazonSocial() = True Then
                        show_message("Advertencia", "Ya existe una razón social con el mismo nombre")
                        btnGuardar.Enabled = False
                        Return
                    End If
                End If

                If ProveedorID = -1 Then
                    mensajeConfirmacion.mensaje = "¿Está seguro de dar de alta al proveedor?"
                Else
                    mensajeConfirmacion.mensaje = "¿Está seguro de guardar los cambios?"
                End If

                If mensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    ObjProveedor.dage_proveedorid = cmbNombreComercial.SelectedValue
                    ObjProveedor.prov_tiporazonsocial = cmbTipoFiscal.Text.ToString()
                    ObjProveedor.prov_tipofiscal = cmbTipoPersona.Text.ToString()
                    ObjProveedor.prov_rfc = txtRFC.Text.Trim()

                    If cmbTipoFiscal.Text = "FISCAL" Then
                        ObjProveedor.prov_rfcsicy = cmbSICYID.SelectedValue.ToString()
                    Else
                        ObjProveedor.prov_rfcsicy = -1
                    End If

                    ObjProveedor.prov_razonsocial = txtRazonSocial.Text.Trim()
                    ObjProveedor.prov_nombre = txtNombre.Text.Trim()
                    ObjProveedor.prov_apellidopaterno = txtAPaterno.Text.Trim()
                    ObjProveedor.prov_apellidomaterno = txtAMaterno.Text.Trim()
                    ObjProveedor.prov_pais = cmbPais.Text.ToString()
                    ObjProveedor.prov_paisid = cmbPais.SelectedValue.ToString()
                    ObjProveedor.prov_estado = cmbEstado.Text.ToString()
                    ObjProveedor.prov_estadoid = cmbEstado.SelectedValue.ToString()
                    ObjProveedor.prov_ciudad = cmbCiudad.Text.ToString()
                    ObjProveedor.prov_ciudadid = cmbCiudad.SelectedValue.ToString()
                    ObjProveedor.prov_colonia = txtColonia.Text.Trim()
                    ObjProveedor.prov_calle = txtCalle.Text.Trim()
                    ObjProveedor.prov_numeroexterior = txtNumeroExterior.Text.Trim()
                    ObjProveedor.prov_numerointerior = txtNumeroInterior.Text.Trim()
                    ObjProveedor.prov_codigopostal = txtCodigoPostal.Text.Trim()
                    ObjProveedor.prov_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    ObjProveedor.prov_fechacreacion = Date.Now
                    ObjProveedor.prov_fechamodificacion = Date.Now
                    ObjProveedor.prov_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    ObjProveedor.prov_nombregenerico = cmbNombreComercial.Text.Trim()
                    ObjProveedor.prov_activo = rdoSi.Checked

                    DTClasificacionGiro = AltaProveevdor.ObtenerGiro(cmbClasificacion.SelectedValue, cmbGiro.SelectedValue)

                    If cmbTipoFiscal.Text = "NO FISCAL" Then
                        ObjProveedor.prov_razonsocial = ObjProveedor.prov_nombre.Trim() + " " + ObjProveedor.prov_apellidopaterno.Trim + " " + ObjProveedor.prov_apellidomaterno.Trim
                        ObjProveedor.prov_rfc = String.Empty
                        ObjProveedor.prov_rfcsicy = -1

                    Else

                        If cmbTipoPersona.Text.ToString() = "FISICA" Then
                            ObjProveedor.prov_razonsocial = ObjProveedor.prov_nombre.Trim() + " " + ObjProveedor.prov_apellidopaterno.Trim + " " + ObjProveedor.prov_apellidomaterno.Trim
                        Else
                            If cmbTipoRazonSocial.Text <> "" Then
                                ObjProveedor.prov_razonsocial = ObjProveedor.prov_razonsocial.Trim + ", " + cmbTipoRazonSocial.Text.Trim
                            Else
                                ObjProveedor.prov_razonsocial = ObjProveedor.prov_razonsocial.Trim
                            End If

                            ObjProveedor.prov_razonsocial = ObjProveedor.prov_razonsocial.Trim()
                        End If

                    End If


                    If DTClasificacionGiro.Rows.Count > 0 Then
                        ObjProveedor.prov_clasificaciongiroid = DTClasificacionGiro.Rows(0).Item("clag_clasificaciongiroid").ToString()
                    End If
                    ObjProveedor.prov_pagoParcialidades = PagoPorParcialidades


                    If ProveedorID = -1 And ProveedorDageNoExiste = False Then
                        DtInformacion = AltaProveevdor.AltaProveedorDatos(ObjProveedor)
                        If DtInformacion.Rows.Count > 0 Then
                            ProveedorID = DtInformacion.Rows(0).Item("ProveedorID").ToString()
                            For Each fila As UltraGridRow In grdPlazosPago.Rows
                                If fila.Cells(" ").Value = True Then
                                    objPlazoPago.plpa_plazopago = fila.Cells("ID").Value
                                    objPlazoPago.dage_proveedorid = ProveedorID
                                    objPlazoPago.plpr_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                                    AltaProveevdor.AltaProveedorPlazoProveedor(objPlazoPago)
                                Else
                                    objPlazoPago.plpa_plazopago = fila.Cells("ID").Value
                                    objPlazoPago.dage_proveedorid = ProveedorID
                                    objPlazoPago.plpr_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                                    AltaProveevdor.BajaPlazoProveedor(objPlazoPago)
                                End If
                            Next
                        End If

                        Monedas = ObtenerFiltrosGrid(grdMoneda)

                        objbu.InsertarMonedasProveedor(ProveedorID, Monedas)

                        DTExisteNAveNombreComercialNoFiscal = objbu.BuscarNaveNombreComercial(NaveID, cmbNombreComercial.SelectedValue)
                        If DTExisteNAveNombreComercialNoFiscal.Rows.Count > 0 Then
                            dage_ProveedorID = DTExisteNAveNombreComercialNoFiscal.Rows(0).Item("dage_proveedorid").ToString()
                            If dage_ProveedorID < 0 Then
                                objbu.InsertarRelacionNaveNombreComercial(cmbNombreComercial.SelectedValue, NaveID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                            End If
                        End If
                    Else
                        If ProveedorDageNoExiste = True Then
                            ObjProveedor.prov_ProveedorID = ProveedorID_Dage_noRalacionado
                        Else
                            ObjProveedor.prov_ProveedorID = ProveedorID
                        End If

                        Monedas = ObtenerFiltrosGrid(grdMoneda)

                        objbu.InsertarMonedasProveedor(ProveedorID, Monedas)

                        ObjProveedor.prov_fechamodificacion = Date.Now
                        objPlazoPago.plpr_usuariomodifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        DtInformacion = AltaProveevdor.EditarInformacionProveedor2(ObjProveedor)
                        For Each fila As UltraGridRow In grdPlazosPago.Rows
                            If fila.Cells(" ").Value = True Then
                                objPlazoPago.plpa_plazopago = fila.Cells("ID").Value
                                objPlazoPago.dage_proveedorid = ObjProveedor.prov_ProveedorID
                                objPlazoPago.plpr_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                                AltaProveevdor.AltaProveedorPlazoProveedor(objPlazoPago)
                            Else
                                objPlazoPago.plpa_plazopago = fila.Cells("ID").Value
                                objPlazoPago.dage_proveedorid = ObjProveedor.prov_ProveedorID
                                objPlazoPago.plpr_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                                AltaProveevdor.BajaPlazoProveedor(objPlazoPago)
                            End If
                        Next

                        If ProveedorDageNoExiste = True Then
                            DTExisteNAveNombreComercialNoFiscal = objbu.BuscarNaveNombreComercial(NaveID, cmbNombreComercial.SelectedValue)
                            If DTExisteNAveNombreComercialNoFiscal.Rows.Count > 0 Then
                                dage_ProveedorID = DTExisteNAveNombreComercialNoFiscal.Rows(0).Item("dage_proveedorid").ToString()
                                If dage_ProveedorID < 0 Then
                                    objbu.InsertarRelacionNaveNombreComercial(cmbNombreComercial.SelectedValue, NaveID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                                End If
                            End If
                        End If
                    End If

                    objbu.ActualizarPaisNombreComercial(cmbNombreComercial.SelectedValue, cmbPais.Text.ToString.Trim())
                    show_message("Exito", "Se han guardado los cambios")
                    Me.Close()
                End If
            End If

        Else
            show_message("Advertencia", "Faltan datos obligatorios por registrar")
        End If

    End Sub


    Private Sub CargarInformacionProveedor()
        Dim objProveedorBu As New Proveedores.BU.ProveedorBU
        Dim ObjProveedor As New Entidades.DatosProveedor
        Dim DTInformacionClasificacionGiro As DataTable
        Dim DTRFC As DataTable

        SeleccionarTipoPersonas = True
        ObjProveedor = objProveedorBu.ConsultaInformacionProveedor(ProveedorID)

        If IsDBNull(ObjProveedor.prov_tiporazonsocial) = False Then
            cmbTipoFiscal.Text = ""
            cmbTipoFiscal.SelectedText = ObjProveedor.prov_tiporazonsocial
        End If

        If IsDBNull(ObjProveedor.prov_tipofiscal) = False Then
            cmbTipoPersona.SelectedText = ObjProveedor.prov_tipofiscal
        End If

        If IsDBNull(ObjProveedor.prov_razonsocial) = False Then
            txtRazonSocial.Text = ObjProveedor.prov_razonsocial.Trim()
        End If

        If IsDBNull(ObjProveedor.prov_nombre) = False Then
            txtNombre.Text = ObjProveedor.prov_nombre
        End If

        If IsDBNull(ObjProveedor.prov_apellidopaterno) = False Then
            txtAPaterno.Text = ObjProveedor.prov_apellidopaterno
        End If

        If IsDBNull(ObjProveedor.prov_apellidomaterno) = False Then
            txtAMaterno.Text = ObjProveedor.prov_apellidomaterno
        End If

        If IsDBNull(ObjProveedor.prov_paisid) = False Then
            cmbPais.SelectedValue = ObjProveedor.prov_paisid
        End If

        If IsDBNull(ObjProveedor.prov_estadoid) = False Then
            cmbEstado.SelectedValue = ObjProveedor.prov_estadoid
        End If

        If IsDBNull(ObjProveedor.prov_ciudadid) = False Then
            cmbCiudad.SelectedValue = ObjProveedor.prov_ciudadid
        End If

        If IsDBNull(ObjProveedor.prov_colonia) = False Then
            txtColonia.Text = ObjProveedor.prov_colonia
        End If

        If IsDBNull(ObjProveedor.prov_calle) = False Then
            txtCalle.Text = ObjProveedor.prov_calle
        End If

        If IsDBNull(ObjProveedor.prov_numeroexterior) = False Then
            txtNumeroExterior.Text = ObjProveedor.prov_numeroexterior
        End If

        If IsDBNull(ObjProveedor.prov_numerointerior) = False Then
            txtNumeroInterior.Text = ObjProveedor.prov_numerointerior
        End If

        If IsDBNull(ObjProveedor.prov_codigopostal) = False Then
            txtCodigoPostal.Text = ObjProveedor.prov_codigopostal
        End If

        If IsDBNull(ObjProveedor.dage_nombrecomercial) = False Then
            txtNombreComercial.Text = ObjProveedor.dage_nombrecomercial
        End If

        If IsDBNull(ObjProveedor.dage_proveedorid) = False Then
            cmbNombreComercial.SelectedValue = ObjProveedor.dage_proveedorid
        End If

        If IsDBNull(ObjProveedor.dage_proveedorid) = False Then
            dage_ProveedorID = ObjProveedor.dage_proveedorid
        End If


        If IsDBNull(ObjProveedor.dage_proveedorid) = False Then
            dage_ProveedorID = ObjProveedor.dage_proveedorid
        End If

        grdPlazosPago.DataSource = objProveedorBu.ConsultarPlazosPagoProveedor(ProveedorID)
        grdMoneda.DataSource = objProveedorBu.CargarMonedasProveedor(ProveedorID)
        DTInformacionClasificacionGiro = objProveedorBu.ConsultaClasificacionGiroProveedor(ObjProveedor.prov_clasificaciongiroid)


        If cmbTipoPersona.Text.ToString() = "FISICA" Then
            txtRFC.MaxLength = 13
            txtRFC.Mask = "LLLL000000AAA"
        ElseIf cmbTipoPersona.Text.ToString() = "MORAL" Then
            txtRFC.MaxLength = 12
            txtRFC.Mask = "LLL000000AAA"
        End If

        If IsDBNull(ObjProveedor.prov_rfc) = False Then
            txtRFC.Text = ObjProveedor.prov_rfc.Trim()
        End If


        If cmbTipoFiscal.Text = "FISCAL" Then
            If IsDBNull(ObjProveedor.prov_rfcsicy) = False Then

                DTRFC = objProveedorBu.ConsultarProveedorSicy(ObjProveedor.prov_rfcsicy)
                cmbSICYID.DataSource = DTRFC
                cmbSICYID.ValueMember = "IdProveedor"
                cmbSICYID.DisplayMember = "RazonSocial"

                cmbSICYID.SelectedValue = ObjProveedor.prov_rfcsicy
            End If

        End If


        If DTInformacionClasificacionGiro.Rows.Count > 0 Then
            cmbClasificacion.SelectedValue = DTInformacionClasificacionGiro.Rows(0).Item("clag_idcategoria")
            cmbClasificacion.Text = DTInformacionClasificacionGiro.Rows(0).Item("Categoria")

            If cmbClasificacion.Text <> "" Then
                cmbGiro.SelectedValue = DTInformacionClasificacionGiro.Rows(0).Item("clag_giroproveedorid")
                cmbGiro.Text = DTInformacionClasificacionGiro.Rows(0).Item("GiroProveedor")
            End If
        End If

        If ObjProveedor.prov_activo = 1 Then
            rdoSi.Checked = True
            rdoNo.Checked = False
        Else
            rdoSi.Checked = False
            rdoNo.Checked = True
        End If

        If IsDBNull(ObjProveedor.prov_razonsocial) = False Then
            txtRazonSocial.Text = ObtenerTipoRazonSocial(ObjProveedor.prov_razonsocial)
        End If

        If ObjProveedor.prov_pagoParcialidades = 1 Then
            chPagoParcialidades.Checked = True
        End If


        SeleccionarTipoPersonas = True
    End Sub

    Private Sub CargarInformacionProveedor(ByVal dage_ProveedorID As Integer)
        Dim objProveedorBu As New Proveedores.BU.ProveedorBU
        Dim ObjProveedor As New Entidades.DatosProveedor
        Dim DTInformacionClasificacionGiro As DataTable
        Dim DTRFC As DataTable
        Dim indiceTipoPersona As Integer = -1
        ObjProveedor = objProveedorBu.ConsultaInformacionProveedor(dage_ProveedorID)

        If IsDBNull(ObjProveedor.prov_rfc) = False Then
            txtRFC.Text = ObjProveedor.prov_rfc
        End If

        If IsDBNull(ObjProveedor.prov_razonsocial) = False Then
            txtRazonSocial.Text = ObjProveedor.prov_razonsocial.Trim()
        End If

        If IsDBNull(ObjProveedor.prov_nombre) = False Then
            txtNombre.Text = ObjProveedor.prov_nombre
        End If

        If IsDBNull(ObjProveedor.prov_apellidopaterno) = False Then
            txtAPaterno.Text = ObjProveedor.prov_apellidopaterno
        End If

        If IsDBNull(ObjProveedor.prov_apellidomaterno) = False Then
            txtAMaterno.Text = ObjProveedor.prov_apellidomaterno
        End If

        If IsDBNull(ObjProveedor.prov_paisid) = False Then
            cmbPais.SelectedValue = ObjProveedor.prov_paisid
        End If

        If IsDBNull(ObjProveedor.prov_estadoid) = False Then
            cmbEstado.SelectedValue = ObjProveedor.prov_estadoid
        End If

        If IsDBNull(ObjProveedor.prov_ciudadid) = False Then
            cmbCiudad.SelectedValue = ObjProveedor.prov_ciudadid
        End If

        If IsDBNull(ObjProveedor.prov_colonia) = False Then
            txtColonia.Text = ObjProveedor.prov_colonia
        End If

        If IsDBNull(ObjProveedor.prov_calle) = False Then
            txtCalle.Text = ObjProveedor.prov_calle
        End If

        If IsDBNull(ObjProveedor.prov_numeroexterior) = False Then
            txtNumeroExterior.Text = ObjProveedor.prov_numeroexterior
        End If

        If IsDBNull(ObjProveedor.prov_numerointerior) = False Then
            txtNumeroInterior.Text = ObjProveedor.prov_numerointerior
        End If

        If IsDBNull(ObjProveedor.prov_codigopostal) = False Then
            txtCodigoPostal.Text = ObjProveedor.prov_codigopostal
        End If

        If IsDBNull(ObjProveedor.dage_nombrecomercial) = False Then
            txtNombreComercial.Text = ObjProveedor.dage_nombrecomercial
        End If


        If IsDBNull(ObjProveedor.dage_proveedorid) = False Then
            dage_ProveedorID = ObjProveedor.dage_proveedorid
        End If

        cmbNombreComercial.SelectedValue = ObjProveedor.dage_proveedorid

        grdPlazosPago.DataSource = objProveedorBu.ConsultarPlazosPagoProveedor(ObjProveedor.prov_ProveedorID)
        grdMoneda.DataSource = objProveedorBu.CargarMonedasProveedor(ObjProveedor.prov_ProveedorID)
        DTInformacionClasificacionGiro = objProveedorBu.ConsultaClasificacionGiroProveedor(ObjProveedor.prov_clasificaciongiroid)

        If cmbTipoFiscal.Text = "FISCAL" Then
            DTRFC = objProveedorBu.BuscarRFC(txtRFC.Text.Trim())
            cmbSICYID.DataSource = DTRFC
            cmbSICYID.ValueMember = "IdProveedor"
            cmbSICYID.DisplayMember = "RazonSocial"

            cmbSICYID.SelectedValue = ObjProveedor.prov_rfcsicy
        End If

        If DTInformacionClasificacionGiro.Rows.Count > 0 Then
            cmbClasificacion.SelectedValue = DTInformacionClasificacionGiro.Rows(0).Item("clag_idcategoria")
            cmbGiro.SelectedValue = DTInformacionClasificacionGiro.Rows(0).Item("clag_giroproveedorid")
        End If

        If ObjProveedor.prov_activo = 1 Then
            rdoSi.Checked = True
            rdoNo.Checked = False
        Else
            rdoSi.Checked = False
            rdoNo.Checked = True
        End If

        If IsDBNull(ObjProveedor.prov_razonsocial) = False Then
            txtRazonSocial.Text = ObtenerTipoRazonSocial(ObjProveedor.prov_razonsocial)
        End If


    End Sub

    Private Function ObtenerTipoRazonSocial(ByVal RazonSocial As String) As String
        Dim DTTipoRazonSocial As DataTable
        Dim objProveedorBu As New Proveedores.BU.ProveedorBU
        DTTipoRazonSocial = objProveedorBu.ConsultaTiposRazonSocial()

        Dim RazonSocialSinTipo As String = ""

        For Each fila As DataRow In DTTipoRazonSocial.Rows
            If RazonSocial.Contains(fila.Item("tirz_abreviacion")) = True Then
                If RazonSocial.Contains("," + fila.Item("tirz_abreviacion")) = True Then
                    RazonSocialSinTipo = RazonSocial.Replace("," + fila.Item("tirz_abreviacion"), "")
                Else
                    RazonSocialSinTipo = RazonSocial.Replace(fila.Item("tirz_abreviacion"), "")
                End If
                cmbTipoRazonSocial.SelectedText = fila.Item("tirz_abreviacion")
                Return RazonSocialSinTipo
            End If
        Next
        If RazonSocial = RazonSocialSinTipo Then
            cmbTipoRazonSocial.SelectedText = ""
        End If

        Return RazonSocial
    End Function

    Private Sub CargarNombresComerciales(Optional ByVal InsertarVacio As Boolean = True)
        Dim objProveedorBu As New Proveedores.BU.ProveedorBU
        Dim DTNombresComerciales As DataTable

        DTNombresComerciales = objProveedorBu.ConsultaNombresComerciales()
        cmbNombreComercial.DataSource = DTNombresComerciales
        cmbNombreComercial.ValueMember = "dage_proveedorid"
        cmbNombreComercial.DisplayMember = "dage_nombrecomercial"


        Dim dtRow As DataRow = DTNombresComerciales.NewRow
        dtRow("dage_proveedorid") = -1
        dtRow("dage_nombrecomercial") = ""
        dtRow("dage_pais") = ""

        If InsertarVacio = True Then
            DTNombresComerciales.Rows.InsertAt(dtRow, 0)
        End If

        cmbNombreComercial.SelectedIndex = 0
        cmbNombreComercial.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Suggest
        cmbNombreComercial.AutoCompleteSource = AutoCompleteSource.ListItems

    End Sub

    Private Sub CargarTipoRazonSocial()
        Dim objProveedorBu As New Proveedores.BU.ProveedorBU
        Dim DTTipoRazonSocial As DataTable

        DTTipoRazonSocial = objProveedorBu.ConsultaTiposRazonSocial()
        cmbTipoRazonSocial.DataSource = DTTipoRazonSocial
        cmbTipoRazonSocial.ValueMember = "tirz_tiporazonsocialid"
        cmbTipoRazonSocial.DisplayMember = "tirz_abreviacion"


        Dim dtRow As DataRow = DTTipoRazonSocial.NewRow
        dtRow("tirz_tiporazonsocialid") = 0
        dtRow("tirz_abreviacion") = ""
        dtRow("tirz_descripcion") = ""
        DTTipoRazonSocial.Rows.InsertAt(dtRow, 0)

        cmbTipoRazonSocial.SelectedIndex = 0

    End Sub

    Private Sub CargarPaises()
        Dim objProveedorBu As New Proveedores.BU.ProveedorBU
        Dim DTTipoRazonSocial As DataTable

        DTTipoRazonSocial = objProveedorBu.ListaPaises()
        cmbPais.DataSource = DTTipoRazonSocial
        cmbPais.ValueMember = "pais_paisid"
        cmbPais.DisplayMember = "pais_nombre"

        Dim dtRow As DataRow = DTTipoRazonSocial.NewRow
        dtRow("pais_paisid") = 0
        dtRow("pais_nombre") = ""

        DTTipoRazonSocial.Rows.InsertAt(dtRow, 0)

        cmbPais.SelectedIndex = 0
        cmbPais.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Suggest
        cmbPais.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub


    Private Sub CargarEstados(ByVal Pais As Integer)
        Dim objProveedorBu As New Proveedores.BU.ProveedorBU
        Dim DTTipoRazonSocial As DataTable

        DTTipoRazonSocial = objProveedorBu.ListaEstados(Pais)
        cmbEstado.DataSource = DTTipoRazonSocial
        cmbEstado.ValueMember = "esta_estadoid"
        cmbEstado.DisplayMember = "esta_nombre"

        Dim dtRow As DataRow = DTTipoRazonSocial.NewRow
        dtRow("esta_estadoid") = 0
        dtRow("esta_nombre") = ""

        DTTipoRazonSocial.Rows.InsertAt(dtRow, 0)

        cmbEstado.SelectedIndex = 0

        cmbEstado.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Suggest
        cmbEstado.AutoCompleteSource = AutoCompleteSource.ListItems

    End Sub

    Private Sub CargarCiudades(ByVal EstadoD As Integer)
        Dim objProveedorBu As New Proveedores.BU.ProveedorBU
        Dim DTTipoRazonSocial As DataTable

        DTTipoRazonSocial = objProveedorBu.ListaCiudades(EstadoD)
        cmbCiudad.DataSource = DTTipoRazonSocial
        cmbCiudad.ValueMember = "city_ciudadid"
        cmbCiudad.DisplayMember = "city_nombre"

        Dim dtRow As DataRow = DTTipoRazonSocial.NewRow
        dtRow("city_ciudadid") = 0
        dtRow("city_nombre") = ""

        DTTipoRazonSocial.Rows.InsertAt(dtRow, 0)

        cmbCiudad.SelectedIndex = 0

        cmbCiudad.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Suggest
        cmbCiudad.AutoCompleteSource = AutoCompleteSource.ListItems

    End Sub

    Private Sub CargarClasificaciones()
        Dim objProveedorBu As New Proveedores.BU.ProveedorBU
        Dim DTTipoRazonSocial As DataTable

        DTTipoRazonSocial = objProveedorBu.ConsultaClasificaciones(True)
        cmbClasificacion.DataSource = DTTipoRazonSocial
        cmbClasificacion.ValueMember = "cate_idCategoria"
        cmbClasificacion.DisplayMember = "cate_nombre"


        Dim dtRow As DataRow = DTTipoRazonSocial.NewRow
        dtRow("cate_idCategoria") = -1
        dtRow("cate_nombre") = ""

        DTTipoRazonSocial.Rows.InsertAt(dtRow, 0)


        cmbClasificacion.SelectedIndex = 0

        cmbClasificacion.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Suggest
        cmbClasificacion.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Private Sub CargarGiros()
        Dim objProveedorBu As New Proveedores.BU.ProveedorBU
        Dim DTTipoRazonSocial As DataTable

        DTTipoRazonSocial = objProveedorBu.ConsultaGiroClasificacion(cmbClasificacion.SelectedValue)
        cmbGiro.DataSource = DTTipoRazonSocial
        cmbGiro.ValueMember = "girp_giroproveedorid"
        cmbGiro.DisplayMember = "girp_descripcion"

        Dim dtRow As DataRow = DTTipoRazonSocial.NewRow
        dtRow("girp_giroproveedorid") = -1
        dtRow("girp_descripcion") = ""

        DTTipoRazonSocial.Rows.InsertAt(dtRow, 0)


        cmbGiro.SelectedIndex = 0

        cmbGiro.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Suggest
        cmbGiro.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Private Sub CargarPlazoPago()
        Dim objProveedorBu As New Proveedores.BU.ProveedorBU
        Dim DTTipoRazonSocial As DataTable

        gridDisenoPlazoPago(grdPlazosPago)

        DTTipoRazonSocial = objProveedorBu.ListaPlazo(0)
        grdPlazosPago.DataSource = DTTipoRazonSocial

    End Sub

    Private Sub CargarInfoMoneda()
        Dim objBU As New ProveedorBU
        Dim dt As New DataTable
        Dim dtMonedasProveedor As New DataTable

        dtMonedasProveedor = objBU.ObtieneMonedasProveedor()
        grdMoneda.DataSource = dtMonedasProveedor
        grid_diseño(grdMoneda)
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)

        asignaFormato_Columna(grid)

        grid.DisplayLayout.Bands(0).Columns(1).Hidden = True

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("String") Then
                col.CellAppearance.TextHAlign = HAlign.Left
            End If
        Next
    End Sub

    Private Sub grdMoneda_Click(sender As Object, e As EventArgs) Handles grdMoneda.Click
        If Not Me.grdMoneda.ActiveRow.IsDataRow Then Return

        If IsNothing(grdMoneda.ActiveRow) Then Return

        If grdMoneda.ActiveRow.Cells(" ").Value Then

            grdMoneda.ActiveRow.Cells(" ").Value = False
        Else
            grdMoneda.ActiveRow.Cells(" ").Value = True
        End If
    End Sub


    Private Sub cmbPais_LostFocus(sender As Object, e As EventArgs) Handles cmbPais.LostFocus
        If cmbPais.SelectedIndex < 0 Then

            cmbEstado.DataSource = Nothing
            cmbCiudad.DataSource = Nothing

        End If
    End Sub


    Private Sub cmbPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPais.SelectedIndexChanged

        cmbEstado.DataSource = Nothing
        cmbCiudad.DataSource = Nothing

        If cmbPais.SelectedIndex > 0 Then
            CargarEstados(cmbPais.SelectedValue)

        End If

    End Sub

    Private Sub gridDisenoPlazoPago(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText

        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard

        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns


        AgregarColumna(grid, "ID", "ID", True, False, Nothing, 100, , , HAlign.Right)
        AgregarColumna(grid, "PLAZO", "PLAZO", False, True, Nothing, 100)
        AgregarColumna(grid, "DIAS", "DIAS", True, True, Nothing, 100)
        AgregarColumna(grid, "prov_pais", "PAÍS", True, True, Nothing, 100)
        AgregarColumna(grid, "ACTIVO", "ACTIVO", True, True, Nothing, 100)
        AgregarColumna(grid, " ", "Seleccionar", False, False, Nothing, 60)


    End Sub

    Private Sub AgregarColumna(ByRef grid As UltraGrid, ByVal Key As String, ByVal NombreColumna As String, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, ByVal ColorColumna As Color, Optional ByVal Width As Integer = -1, Optional ByVal SumarizarColumna As Boolean = False, Optional ByVal Edicion As Boolean = False, Optional ByVal Alineacion As HAlign = Nothing, Optional ByVal NEgrita As Boolean = False, Optional ByVal EsPorcentaje As Boolean = False, Optional ByVal Tooltip As String = "")
        With grid
            .DisplayLayout.Bands(0).Columns.Add(Key, NombreColumna)
            FormatoColumna(.DisplayLayout.Bands(0).Columns(Key), Ocultar, EsCadena, Width, EsPorcentaje)
            If IsNothing(ColorColumna) Then
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = Color.Black
            Else
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = ColorColumna
            End If
            If SumarizarColumna = True Then
                SumarizarColumnaGrid(grid, Key, "Sumarizar " + Key)
            End If
            If Tooltip <> "" Then
                grid.DisplayLayout.Bands(0).Columns(Key).Header.ToolTipText = Tooltip
            End If

            If IsNothing(Alineacion) = False Then
                .DisplayLayout.Bands(0).Columns(Key).CellAppearance.TextHAlign = Alineacion
            End If
            If NEgrita = True Then
                .DisplayLayout.Bands(0).Columns(Key).CellAppearance.FontData.Bold = DefaultableBoolean.True
            End If


            If Edicion = True Then
                .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.AllowEdit
            Else
                .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.NoEdit
            End If

        End With
    End Sub

    Private Sub FormatoColumna(ByRef columna As UltraGridColumn, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, Optional ByVal Width As Integer = -1, Optional ByVal EsPorcentaje As Boolean = False)
        Dim FormatoNumero As String = "###,###,##0"
        Dim FormatoPorcentaje As String = "##0%"
        columna.Hidden = Ocultar
        If EsCadena = True Then
            columna.CellAppearance.TextHAlign = HAlign.Left
        Else

            If EsPorcentaje = True Then
                columna.Format = FormatoPorcentaje
                columna.CellAppearance.TextHAlign = HAlign.Right
            Else
                columna.Format = FormatoNumero
                columna.CellAppearance.TextHAlign = HAlign.Right
            End If

        End If

        If Width <> -1 Then
            columna.Width = Width
        End If
    End Sub

    Private Sub SumarizarColumnaGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal NombreColumna As String, ByVal Key As String)
        Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns(NombreColumna)
        Dim summary As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add(Key, SummaryType.Sum, columnToSummarize)
        summary.DisplayFormat = "{0:###,###,##0}"
        summary.Appearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
    End Sub



    Private Sub HabilitarDeshabilitarControles()
        Dim EsRFCCorrecto As Boolean = EsRFFCValido()
        Dim EsFiscal As Boolean = False
        Dim Page As TabPage

        If cmbTipoFiscal.SelectedIndex = 0 Then
            cmbTipoPersona.SelectedIndex = 0
            txtRFC.Enabled = False
            txtRFC.Text = String.Empty
            cmbSICYID.Enabled = False
            If cmbSICYID.Items.Count > 0 Then
                cmbSICYID.SelectedIndex = 0
            End If

            txtRazonSocial.Enabled = False
            txtRazonSocial.Text = String.Empty


            cmbTipoRazonSocial.Enabled = False
            If cmbTipoRazonSocial.Items.Count > 0 Then
                cmbTipoRazonSocial.SelectedIndex = 0
            End If

            txtNombre.Enabled = False
            txtNombre.Text = String.Empty

            txtAPaterno.Enabled = False
            txtAPaterno.Text = String.Empty

            txtAMaterno.Enabled = False
            txtAMaterno.Text = String.Empty

            cmbPais.Enabled = False
            If cmbPais.Items.Count > 0 Then
                cmbPais.SelectedIndex = 0
            End If

            cmbEstado.Enabled = False
            If cmbEstado.Items.Count > 0 Then
                cmbEstado.SelectedIndex = 0
            End If

            cmbCiudad.Enabled = False
            If cmbCiudad.Items.Count > 0 Then
                cmbCiudad.SelectedIndex = 0
            End If

            txtColonia.Enabled = False
            txtColonia.Text = String.Empty

            txtCalle.Enabled = False
            txtCalle.Text = String.Empty

            txtNumeroExterior.Enabled = False
            txtNumeroExterior.Text = String.Empty

            txtNumeroInterior.Enabled = False
            txtNumeroInterior.Text = String.Empty

            txtCodigoPostal.Enabled = False
            txtCodigoPostal.Text = String.Empty

            cmbClasificacion.Enabled = False
            If cmbClasificacion.Items.Count > 0 Then
                cmbClasificacion.SelectedIndex = 0
            End If

            cmbGiro.Enabled = False
            If cmbGiro.Items.Count > 0 Then
                cmbGiro.SelectedIndex = 0
            End If

            rdoSi.Enabled = False
            rdoNo.Enabled = False
            chkSeleccionarTodo.Enabled = False

        Else
            If cmbTipoFiscal.SelectedIndex < 0 Then
                EsFiscal = True
            Else
                If cmbTipoFiscal.SelectedItem.ToString() = "FISCAL" Then
                    EsFiscal = True
                    btnGuardar.Enabled = EsRFCCorrecto
                    grdPlazosPago.Enabled = EsRFCCorrecto
                    grdMoneda.Enabled = EsRFCCorrecto
                Else
                    EsFiscal = False
                    btnGuardar.Enabled = True
                    grdPlazosPago.Enabled = True
                    grdMoneda.Enabled = True
                End If
            End If


            If EsFiscal = True Then
                If ProveedorID = -1 Then
                    If EsRFCCorrecto = False Then
                        cmbSICYID.Enabled = False
                        txtRazonSocial.Enabled = False
                        cmbTipoRazonSocial.Enabled = False
                        txtNombre.Enabled = False
                        txtAPaterno.Enabled = False
                        txtAMaterno.Enabled = False
                        cmbPais.Enabled = False
                        cmbEstado.Enabled = False
                        cmbCiudad.Enabled = False
                        txtColonia.Enabled = False
                        txtCalle.Enabled = False
                        txtNumeroExterior.Enabled = False
                        txtNumeroInterior.Enabled = False
                        txtCodigoPostal.Enabled = False
                        cmbClasificacion.Enabled = False
                        cmbGiro.Enabled = False
                        rdoSi.Enabled = False
                        rdoNo.Enabled = False
                        chkSeleccionarTodo.Enabled = False
                    Else
                        cmbSICYID.Enabled = True
                        txtRazonSocial.Enabled = True
                        cmbTipoRazonSocial.Enabled = True
                        txtNombre.Enabled = True
                        txtAPaterno.Enabled = True
                        txtAMaterno.Enabled = True
                        cmbPais.Enabled = True
                        cmbEstado.Enabled = True
                        cmbCiudad.Enabled = True
                        txtColonia.Enabled = True
                        txtCalle.Enabled = True
                        txtNumeroExterior.Enabled = True
                        txtNumeroInterior.Enabled = True
                        txtCodigoPostal.Enabled = True
                        cmbClasificacion.Enabled = True
                        cmbGiro.Enabled = True
                        rdoSi.Enabled = False
                        rdoNo.Enabled = False
                        chkSeleccionarTodo.Enabled = True

                        If cmbTipoPersona.Text.ToString.Trim() = "FISICA" Then
                            cmbTipoRazonSocial.Enabled = False
                            txtRazonSocial.Enabled = False
                            txtNombre.Enabled = True
                            txtAPaterno.Enabled = True
                            txtAMaterno.Enabled = True
                        ElseIf cmbTipoPersona.Text.ToString() = "MORAL" Then
                            cmbTipoRazonSocial.Enabled = True
                            txtRazonSocial.Enabled = True
                            txtNombre.Enabled = False
                            txtAPaterno.Enabled = False
                            txtAMaterno.Enabled = False
                        End If


                    End If


                Else
                    cmbPais.Enabled = True
                    cmbEstado.Enabled = True
                    cmbCiudad.Enabled = True
                    txtColonia.Enabled = True
                    txtCalle.Enabled = True
                    txtNumeroExterior.Enabled = True
                    txtNumeroInterior.Enabled = True
                    txtCodigoPostal.Enabled = True
                    cmbClasificacion.Enabled = True
                    cmbGiro.Enabled = True
                    rdoSi.Enabled = True
                    rdoNo.Enabled = True
                    chkSeleccionarTodo.Enabled = True


                    cmbSICYID.Enabled = False
                    txtRazonSocial.Enabled = False
                    cmbTipoRazonSocial.Enabled = False
                    txtNombre.Enabled = False
                    txtAPaterno.Enabled = False
                    txtAMaterno.Enabled = False
                    cmbNombreComercial.Enabled = False
                    cmbTipoFiscal.Enabled = False
                    cmbTipoPersona.Enabled = False
                    txtRFC.Enabled = False


                End If

            Else
                If ProveedorID = -1 Then
                    cmbSICYID.Enabled = False
                    txtRazonSocial.Enabled = False
                    cmbTipoRazonSocial.Enabled = False
                    txtNombre.Enabled = True
                    txtAPaterno.Enabled = True
                    txtAMaterno.Enabled = True


                    cmbPais.Enabled = True
                    cmbEstado.Enabled = True
                    cmbCiudad.Enabled = True
                    txtColonia.Enabled = True
                    txtCalle.Enabled = True
                    txtNumeroExterior.Enabled = True
                    txtNumeroInterior.Enabled = True
                    txtCodigoPostal.Enabled = True
                    cmbClasificacion.Enabled = True
                    cmbGiro.Enabled = True
                    rdoSi.Enabled = True
                    rdoNo.Enabled = True
                    chkSeleccionarTodo.Enabled = True
                Else
                    cmbPais.Enabled = True
                    cmbEstado.Enabled = True
                    cmbCiudad.Enabled = True
                    txtColonia.Enabled = True
                    txtCalle.Enabled = True
                    txtNumeroExterior.Enabled = True
                    txtNumeroInterior.Enabled = True
                    txtCodigoPostal.Enabled = True
                    cmbClasificacion.Enabled = True
                    cmbGiro.Enabled = True
                    rdoSi.Enabled = True
                    rdoNo.Enabled = True
                    chkSeleccionarTodo.Enabled = True

                    cmbSICYID.Enabled = False
                    txtRazonSocial.Enabled = False
                    cmbTipoRazonSocial.Enabled = False
                    txtNombre.Enabled = False
                    txtAPaterno.Enabled = False
                    txtAMaterno.Enabled = False
                    cmbNombreComercial.Enabled = False
                    cmbTipoFiscal.Enabled = False
                    cmbTipoPersona.Enabled = False
                    txtRFC.Enabled = False
                End If
            End If

        End If

    End Sub


    Private Sub cmbTipoFiscal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoFiscal.SelectedIndexChanged
        If cmbTipoFiscal.Text = "NO FISCAL" Then
            LimpiarDAtos = False
        End If
        LimpiarEtiquetas()
        ProveedorDageNoExiste = False
        If LimpiarDAtos = False Then
            cmbTipoPersona.SelectedIndex = 0
            If cmbTipoFiscal.Text.ToString = "FISCAL" Then
                txtRFC.Enabled = False
                HabilitarDeshabilitarControles()
                cmbTipoPersona.Enabled = True
            ElseIf cmbTipoFiscal.Text.ToString() = "NO FISCAL" Then
                txtRFC.Text = String.Empty
                txtRazonSocial.Text = String.Empty
                cmbTipoRazonSocial.SelectedIndex = 0
                txtRFC.Enabled = False
                HabilitarDeshabilitarControles()
                cmbTipoPersona.SelectedIndex = 0
                cmbTipoPersona.Enabled = False
                If ProveedorID = -1 Then
                    rdoNo.Enabled = False
                    rdoSi.Enabled = False
                End If
            Else
                cmbTipoPersona.Enabled = False
                grdPlazosPago.Enabled = False
                LimpiarInterfaz()
            End If
        End If
        LimpiarDAtos = False
    End Sub


    Private Sub LimpiarInterfaz()
        cmbTipoPersona.SelectedIndex = 0
        txtRFC.Enabled = False
        txtRFC.Text = String.Empty
        cmbSICYID.Enabled = False
        If cmbSICYID.Items.Count > 0 Then
            cmbSICYID.SelectedIndex = 0
        End If

        txtRazonSocial.Enabled = False
        txtRazonSocial.Text = String.Empty


        cmbTipoRazonSocial.Enabled = False
        If cmbTipoRazonSocial.Items.Count > 0 Then
            cmbTipoRazonSocial.SelectedIndex = 0
        End If

        txtNombre.Enabled = False
        txtNombre.Text = String.Empty

        txtAPaterno.Enabled = False
        txtAPaterno.Text = String.Empty

        txtAMaterno.Enabled = False
        txtAMaterno.Text = String.Empty

        cmbPais.Enabled = False
        If cmbPais.Items.Count > 0 Then
            cmbPais.SelectedIndex = 0
        End If

        cmbEstado.Enabled = False
        If cmbEstado.Items.Count > 0 Then
            cmbEstado.SelectedIndex = 0
        End If

        cmbCiudad.Enabled = False
        If cmbCiudad.Items.Count > 0 Then
            cmbCiudad.SelectedIndex = 0
        End If

        txtColonia.Enabled = False
        txtColonia.Text = String.Empty

        txtCalle.Enabled = False
        txtCalle.Text = String.Empty

        txtNumeroExterior.Enabled = False
        txtNumeroExterior.Text = String.Empty

        txtNumeroInterior.Enabled = False
        txtNumeroInterior.Text = String.Empty

        txtCodigoPostal.Enabled = False
        txtCodigoPostal.Text = String.Empty

        cmbClasificacion.Enabled = False
        If cmbClasificacion.Items.Count > 0 Then
            cmbClasificacion.SelectedIndex = 0
        End If

        cmbGiro.Enabled = False
        If cmbGiro.Items.Count > 0 Then
            cmbGiro.SelectedIndex = 0
        End If

        rdoSi.Enabled = False
        rdoNo.Enabled = False
        chkSeleccionarTodo.Enabled = False
    End Sub


    Private Sub LimpiarCampos()
        cmbSICYID.DataSource = Nothing
        txtRazonSocial.Text = String.Empty
        cmbTipoRazonSocial.SelectedIndex = 0
        txtNombre.Text = String.Empty
        txtAPaterno.Text = String.Empty
        txtAMaterno.Text = String.Empty
        cmbPais.SelectedIndex = 0

        If cmbEstado.Items.Count > 0 Then
            cmbEstado.SelectedIndex = 0
        End If

        If cmbCiudad.Items.Count > 0 Then
            cmbCiudad.SelectedIndex = 0
        End If

        txtColonia.Text = String.Empty
        txtCalle.Text = String.Empty
        txtNumeroExterior.Text = String.Empty
        txtNumeroInterior.Text = String.Empty
        txtCodigoPostal.Text = String.Empty
        cmbClasificacion.SelectedIndex = 0
        If cmbGiro.Items.Count > 0 Then
            cmbGiro.SelectedIndex = 0
        End If

        rdoSi.Checked = True
        rdoNo.Checked = False
        For Each fila As UltraGridRow In grdPlazosPago.Rows
            fila.Cells(" ").Value = False
        Next

    End Sub

    Private Sub cmbTipoPersona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoPersona.SelectedIndexChanged
        ProveedorDageNoExiste = False
        If SeleccionarTipoPersonas = False Then

            txtRFC.Text = String.Empty

            If cmbTipoPersona.SelectedIndex = 0 Then
                txtRFC.Enabled = False
                grdPlazosPago.Enabled = False
            Else
                If cmbTipoPersona.SelectedIndex > 0 Then
                    txtRFC.Enabled = True
                End If

                If cmbTipoPersona.Text.ToString() = "FISICA" Then
                    txtRFC.MaxLength = 13
                    txtRFC.Mask = "LLLL000000AAA"
                    cmbTipoRazonSocial.Enabled = False
                    cmbTipoRazonSocial.SelectedIndex = 0
                    txtRazonSocial.Enabled = False
                    If ProveedorID = -1 Then
                        txtRazonSocial.Text = String.Empty
                    End If
                ElseIf cmbTipoPersona.Text.ToString() = "MORAL" Then
                    txtRFC.MaxLength = 12
                    txtRFC.Mask = "LLL000000AAA"
                    If VALIDARFC() = True Then
                        cmbTipoRazonSocial.Enabled = True
                    End If
                End If
            End If


        Else
            If cmbTipoPersona.SelectedIndex = 0 Then
                txtRFC.Enabled = False
            Else
                If cmbTipoPersona.Text.ToString() = "FISICA" Then
                    txtRFC.MaxLength = 13
                    txtRFC.Mask = "LLLL000000AAA"
                    cmbTipoRazonSocial.Enabled = False
                    cmbTipoRazonSocial.SelectedIndex = 0
                Else
                    txtRFC.MaxLength = 12
                    txtRFC.Mask = "LLL000000AAA"
                    If VALIDARFC() = True Then
                        cmbTipoRazonSocial.Enabled = True
                    End If
                End If
            End If


        End If


    End Sub

    Private Function VALIDARFC() As Boolean
        Dim objbu As New Proveedores.BU.ProveedorBU
        Dim DTRFC As DataTable
        Dim DtExisteRFCPRoveedor As DataTable

        If txtRFC.TextLength = txtRFC.Mask.Length Then
            DTRFC = objbu.BuscarRFC(txtRFC.Text.Trim())
            If DTRFC.Rows.Count = 0 Then
                Return False
            Else

                DtExisteRFCPRoveedor = objbu.BuscarExisteRFC(txtRFC.Text.Trim())
                If DtExisteRFCPRoveedor.Rows.Count > 0 Then
                    Return False
                Else
                    Return True
                End If
            End If
        Else
            Return False
        End If
    End Function

    Public Function EsRFFCValido() As Boolean
        Dim objbu As New Proveedores.BU.ProveedorBU
        Dim DTRFC As DataTable
        Dim DtExisteRFCPRoveedor As DataTable
        Dim DTExisteNaveNombreComercial As DataTable
        Dim dage_proveedorid As Integer = -1
        Dim prov_ProveedorID As Integer = -1
        Dim SeRelacionoNave As Boolean = True
        Dim dtRow As DataRow
        ProveedorDageNoExiste = False

        If txtRFC.Text.Length = txtRFC.Mask.Length Then
            DTRFC = objbu.BuscarRFC(txtRFC.Text.Trim()) 'Buscar RFC en sicy
            If DTRFC.Rows.Count = 0 Then
                show_message("Advertencia", "El RFC no esta dado de alta en el SICY")
                Return False
            Else

                DtExisteRFCPRoveedor = objbu.BuscarExisteRFC(txtRFC.Text.Trim()) 'Buscar RFC em SAY

                If DtExisteRFCPRoveedor.Rows.Count > 0 Then
                    LimpiarDAtos = True
                    SeleccionarTipoPersonas = True
                    prov_ProveedorID = DtExisteRFCPRoveedor.Rows(0).Item("prov_proveedorid").ToString()


                    'Si el RFC Existe y no tiene una dage proveedor asociado se habilitara para capturar la informacion
                    If IsDBNull(DtExisteRFCPRoveedor.Rows(0).Item("dage_proveedorid")) = True Or IsNothing(DtExisteRFCPRoveedor.Rows(0).Item("dage_proveedorid")) = True Then
                        ProveedorDageNoExiste = True

                        ProveedorID_Dage_noRalacionado = prov_ProveedorID
                        cmbSICYID.DataSource = DTRFC
                        cmbSICYID.ValueMember = "IdProveedor"
                        cmbSICYID.DisplayMember = "RazonSocial"

                        dtRow = DTRFC.NewRow
                        dtRow("RFC") = ""
                        dtRow("RFCOriginal") = ""
                        dtRow("IdProveedor") = "-1"
                        dtRow("RazonSocial") = ""
                        dtRow("NomComercial") = ""
                        DTRFC.Rows.InsertAt(dtRow, 0)

                        Return True


                    Else
                        'Si el RFC Existe y  tiene una dage proveedor asociado se deshabilitara para capturar la informacion
                        ProveedorDageNoExiste = False
                        CargarInformacionProveedor(prov_ProveedorID)

                        'Si el nombre comercial esta asociado a la nave devuelve  el dage_proveedor
                        ' si no esta asociado devuelve -1
                        DTExisteNaveNombreComercial = objbu.BuscarNaveNombreComercial(NaveID, cmbNombreComercial.SelectedValue)

                        If DTExisteNaveNombreComercial.Rows.Count > 0 Then
                            dage_proveedorid = DTExisteNaveNombreComercial.Rows(0).Item("dage_proveedorid").ToString()

                            If dage_proveedorid > 0 Then
                                show_message("Advertencia", "El RFC ya esta dado de alta")

                            Else


                                Dim mensajeConfirmacion As New ConfirmarForm
                                mensajeConfirmacion.mensaje = "El RFC ya ha sido dado de alta en otra nave  ¿Desea  dar de alta el RFC en la nave " + NombreNave.ToString() + "?"
                                If mensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                                    objbu.InsertarRelacionNaveNombreComercial(cmbNombreComercial.SelectedValue, NaveID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                                    objbu.ActualizarPaisNombreComercial(cmbNombreComercial.SelectedValue, cmbPais.Text.ToString.Trim())
                                    show_message("Exito", "Ya se dio de alta el RFC con la nave " + NombreNave + "")
                                End If


                            End If
                        End If

                        SeleccionarTipoPersonas = False
                        Return False

                    End If

                Else

                    cmbSICYID.DataSource = DTRFC
                    cmbSICYID.ValueMember = "IdProveedor"
                    cmbSICYID.DisplayMember = "RazonSocial"

                    dtRow = DTRFC.NewRow
                    dtRow("RFC") = ""
                    dtRow("RFCOriginal") = ""
                    dtRow("IdProveedor") = "-1"
                    dtRow("RazonSocial") = ""
                    dtRow("NomComercial") = ""
                    DTRFC.Rows.InsertAt(dtRow, 0)
                    cmbSICYID.SelectedIndex = 0
                    Return True
                End If
            End If
        Else
            Return False
        End If

    End Function


    Public Function show_message(ByVal tipo As String, ByVal mensaje As String) As DialogResult
        Dim ResultadoDialogo As DialogResult

        If tipo.ToString.Equals("Advertencia") Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then
            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            ResultadoDialogo = mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            ResultadoDialogo = mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        Return ResultadoDialogo
    End Function


    Private Sub TabControl1_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabControl1.Selecting
        If TabControl1.SelectedIndex = 1 Then
            If ProveedorID = -1 Then
                e.Cancel = True
            Else
                CargarGridProveedoresPorNombreComercial()
                btnGuardar.Visible = False
                lblGuardar.Visible = False
            End If

        Else
            btnGuardar.Visible = True
            lblGuardar.Visible = True
        End If
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub grdPlazosPago_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdPlazosPago.ClickCell
        If e.Cell.IsFilterRowCell = False Then
            If e.Cell.Column.Key = " " Then
                If e.Cell.Value Then
                    e.Cell.Value = False
                Else
                    e.Cell.Value = True
                End If
            End If
        End If
    End Sub

    Public Function ValidarInformacion() As Boolean
        Dim Cumple As Boolean = True
        Dim PlazoSeleccionado As Integer = 0


        If cmbNombreComercial.SelectedIndex = 0 Then
            Cumple = False
            lblNombreComercial.ForeColor = Color.Red
        Else
            lblNombreComercial.ForeColor = Color.Black
        End If

        If cmbTipoFiscal.SelectedIndex = 0 Then
            Cumple = False
            lblTipoFiscal.ForeColor = Color.Red
        Else
            lblTipoFiscal.ForeColor = Color.Black
        End If

        If cmbTipoFiscal.Text.Trim = "FISCAL" Then
            If txtRFC.Text.Trim() = "" Then
                lblrfc.ForeColor = Color.Red
            Else
                lblrfc.ForeColor = Color.Black
            End If

            If cmbTipoPersona.Text.Trim() = "MORAL" Then
                'If cmbTipoRazonSocial.SelectedIndex = 0 Then
                '    Cumple = False
                '    lblTipoRazonSocial.ForeColor = Color.Red
                'Else
                '    lblTipoRazonSocial.ForeColor = Color.Black
                'End If

                If txtRazonSocial.Text.Trim() = "" Then
                    Cumple = False
                    lblRazonSocial.ForeColor = Color.Red
                Else
                    lblRazonSocial.ForeColor = Color.Black
                End If

            ElseIf cmbTipoPersona.Text.Trim() = "FISICA" Then
                If txtNombre.Text.Trim() = "" Then
                    Cumple = False
                    lblNombre.ForeColor = Color.Red
                Else
                    lblNombre.ForeColor = Color.Black
                End If

                If txtAPaterno.Text.Trim() = "" Then
                    Cumple = False
                    lblPaterno.ForeColor = Color.Red
                Else
                    lblPaterno.ForeColor = Color.Black
                End If

            End If


            If cmbTipoPersona.SelectedIndex = 0 Then
                Cumple = False
                lblTipoPersona.ForeColor = Color.Red
            Else
                lblTipoPersona.ForeColor = Color.Black
            End If

        ElseIf cmbTipoFiscal.Text.ToString() = "NO FISCAL" Then
            If txtNombre.Text.Trim() = "" Then
                Cumple = False
                lblNombre.ForeColor = Color.Red
            Else
                lblNombre.ForeColor = Color.Black
            End If

            If txtAPaterno.Text.Trim() = "" Then
                Cumple = False
                lblPaterno.ForeColor = Color.Red
            Else
                lblPaterno.ForeColor = Color.Black
            End If
        End If



        If cmbPais.SelectedIndex = 0 Then
            Cumple = False
            lblPais.ForeColor = Color.Red
        Else
            lblPais.ForeColor = Color.Black
        End If

        If cmbEstado.SelectedIndex = 0 Or cmbEstado.Items.Count = 0 Then
            Cumple = False
            lblEstado.ForeColor = Color.Red
        Else
            lblEstado.ForeColor = Color.Black
        End If

        If cmbCiudad.SelectedIndex = 0 Or cmbCiudad.Items.Count = 0 Then
            Cumple = False
            lblCiudad.ForeColor = Color.Red
        Else
            lblCiudad.ForeColor = Color.Black
        End If


        If txtColonia.Text.Trim() = "" Then
            Cumple = False
            lblColonia.ForeColor = Color.Red
        Else
            lblColonia.ForeColor = Color.Black
        End If


        If txtCalle.Text.Trim() = "" Then
            Cumple = False
            lblCalle.ForeColor = Color.Red
        Else
            lblCalle.ForeColor = Color.Black

        End If

        If txtNumeroExterior.Text.Trim() = "" Then
            Cumple = False
            lblNumeroExterior.ForeColor = Color.Red
        Else
            lblNumeroExterior.ForeColor = Color.Black
        End If

        If txtCodigoPostal.Text.Trim() = "" Then
            Cumple = False
            lblCodigoPostal.ForeColor = Color.Red
        Else
            lblCodigoPostal.ForeColor = Color.Black
        End If

        If cmbClasificacion.SelectedIndex = 0 Then
            Cumple = False
            lblClasificacion.ForeColor = Color.Red
        Else
            lblClasificacion.ForeColor = Color.Black
        End If

        If cmbGiro.SelectedIndex = 0 Then
            Cumple = False
            lblGiro.ForeColor = Color.Red
        Else
            lblGiro.ForeColor = Color.Black
        End If

        Return Cumple

    End Function

    Private Sub btnAgregarNombreComercial_Click(sender As Object, e As EventArgs) Handles btnAgregarNombreComercial.Click
        Dim FormNombreComercial As New AltaNombreComercialForm
        Dim dage As Integer = -1
        FormNombreComercial.NaveID = NaveID
        FormNombreComercial.ShowDialog()

        If FormNombreComercial.DialogResult = Windows.Forms.DialogResult.OK Then
            dage = FormNombreComercial.Dage_ProveedorId
            CargarNombresComerciales(False)
            If dage > 0 Then
                cmbNombreComercial.SelectedValue = dage
            End If
        End If
    End Sub

    Private Sub CargarGridProveedoresPorNombreComercial()
        Dim objbu As New Proveedores.BU.ProveedorBU

        grdNombreComercial.DataSource = Nothing
        gridDisenoProveedores(grdNombreComercial)
        grdNombreComercial.DataSource = objbu.ConsultarProveedoresPorNombreComercial(dage_ProveedorID)

    End Sub


    Private Sub gridDisenoProveedores(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText

        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard

        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns


        AgregarColumna(grid, "prov_proveedorid", "ID", True, False, Nothing, 100, , , HAlign.Right)
        AgregarColumna(grid, "prov_razonsocial", "RAZÓN SOCIAL", False, True, Nothing, 100)
        AgregarColumna(grid, "prov_rfc", "RFC", False, True, Nothing, 100)
        AgregarColumna(grid, "prov_calle", "CALLE", False, True, Nothing, 100)
        AgregarColumna(grid, "prov_numeroexterior", "NÚMERO EXTERIOR", False, True, Nothing, 100, , , HAlign.Right)
        AgregarColumna(grid, "prov_numerointerior", "NÚMERO INTERIOR", False, True, Nothing, 100, , , HAlign.Right)
        AgregarColumna(grid, "prov_colonia", "COLONIA", False, True, Nothing, 100)
        AgregarColumna(grid, "prov_ciudad", "CIUDAD", False, True, Nothing, 100)
        AgregarColumna(grid, "prov_estado", "ESTADO", False, True, Nothing, 100)
        AgregarColumna(grid, "prov_pais", "PAÍS", False, True, Nothing, 100)


    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged

        For Each Fila As UltraGridRow In grdPlazosPago.Rows
            Fila.Cells(" ").Value = chkSeleccionarTodo.Checked
        Next

    End Sub

    Private Sub txtNumeroExterior_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroExterior.KeyPress

        If Not (IsNumeric(e.KeyChar) Or e.KeyChar = ChrW(Keys.Back)) Then
            e.Handled = True
        End If


    End Sub


    Private Sub txtCodigoPostal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoPostal.KeyPress
        If Not (IsNumeric(e.KeyChar) Or e.KeyChar = ChrW(Keys.Back)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub cmbClasificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClasificacion.SelectedIndexChanged

        If cmbClasificacion.SelectedIndex > 0 Then
            CargarGiros()
        End If


    End Sub

    Private Function ValidarNombreRazonSocial() As Boolean
        Dim objbu As New Proveedores.BU.ProveedorBU
        Dim DTInformacionRazonSocial As DataTable
        Dim RazonSocial As String = String.Empty


        If cmbTipoFiscal.Text = "FISCAL" Then
            RazonSocial = txtRazonSocial.Text.Trim() + "," + cmbTipoRazonSocial.Text.Trim()
        ElseIf cmbTipoFiscal.Text = "NO FISCAL" Then
            RazonSocial = txtNombre.Text.Trim() + " " + txtAPaterno.Text.Trim + " " + txtAMaterno.Text.Trim()
        End If

        DTInformacionRazonSocial = objbu.BuscarRazonSocial(RazonSocial.Trim, ProveedorID)

        If DTInformacionRazonSocial.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub txtRFC_Click(sender As Object, e As EventArgs) Handles txtRFC.Click
        txtRFC.SelectionStart = txtRFC.Text.Length
    End Sub


    Private Sub txtRFC_GotFocus(sender As Object, e As EventArgs) Handles txtRFC.GotFocus
        txtRFC.SelectionStart = txtRFC.Text.Length
    End Sub

    Private Sub txtRFC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRFC.KeyPress
        txtRFC.Text = txtRFC.Text.ToUpper()
    End Sub

    Private Sub txtRFC_TextChanged(sender As Object, e As EventArgs) Handles txtRFC.TextChanged
        If SeleccionarTipoPersonas = False Then
            txtRFC.Text.ToUpper()
            LimpiarCampos()
            HabilitarDeshabilitarControles()
        End If
    End Sub


    Private Function ExisteRFC() As Boolean
        Dim objbu As New Proveedores.BU.ProveedorBU
        Dim DTRFC As DataTable
        Dim DtExisteRFCPRoveedor As DataTable

        If txtRFC.TextLength = txtRFC.Mask.Length Then
            DTRFC = objbu.BuscarRFC(txtRFC.Text.Trim())
            If DTRFC.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function

    Private Sub DesactivarCampos()

        cmbTipoPersona.SelectedIndex = 0
        txtRFC.Enabled = False
        cmbSICYID.DataSource = Nothing
        cmbSICYID.Enabled = False
        txtRazonSocial.Enabled = False
        cmbTipoRazonSocial.Enabled = False
        txtNombre.Enabled = False
        txtAPaterno.Enabled = False
        txtAMaterno.Enabled = False
        cmbPais.Enabled = False
        cmbEstado.Enabled = False
        cmbCiudad.Enabled = False
        txtColonia.Enabled = False
        txtCalle.Enabled = False
        txtNumeroExterior.Enabled = False
        txtNumeroInterior.Enabled = False
        txtCodigoPostal.Enabled = False
        cmbClasificacion.Enabled = False
        cmbGiro.Enabled = False
        grdPlazosPago.Enabled = False
        chkSeleccionarTodo.Enabled = False



    End Sub


    'Devuelve true si existe, false no existe
    Private Function BuscarRazonSocialNoFiscal() As Boolean
        Dim objbu As New Proveedores.BU.ProveedorBU
        Dim DTRazonSocial As DataTable

        Dim RazonSocial As String = String.Empty
        RazonSocial = txtNombre.Text.Trim() + " " + txtAPaterno.Text.Trim() + " " + txtAMaterno.Text.Trim()

        RazonSocial = RazonSocial.Trim()

        DTRazonSocial = objbu.BuscarRazonSocialNoFiscal(RazonSocial, ProveedorID)

        If DTRazonSocial.Rows.Count > 0 Then
            Dage_ProveedorNoFiscal = DTRazonSocial.Rows(0).Item("dage_proveedorid").ToString()
            ProveedorID = DTRazonSocial.Rows(0).Item("prov_proveedorid").ToString()
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub txtAMaterno_LostFocus(sender As Object, e As EventArgs) Handles txtAMaterno.LostFocus
        Dim AltaProveevdor As New Proveedores.BU.ProveedorBU
        Dim ObjProveedor As New Entidades.DatosProveedor
        Dim objPlazoPago As New Entidades.PlazoProveedor
        Dim ExisteRazonSocialNoFiscal As Boolean = False
        Dim mensajeConfirmacion As New ConfirmarForm
        Dim DTExisteNaveNombreComercial As DataTable
        Dim objbu As New Proveedores.BU.ProveedorBU

        If cmbTipoFiscal.Text = "NO FISCAL" Then
            ExisteRazonSocialNoFiscal = BuscarRazonSocialNoFiscal()
            If ExisteRazonSocialNoFiscal = True Then

                CargarInformacionProveedor()
                DesactivarCampos()
                cmbNombreComercial.Enabled = False
                cmbTipoFiscal.Enabled = False
                cmbTipoPersona.Enabled = False
                btnAgregarNombreComercial.Enabled = False
                DTExisteNaveNombreComercial = objbu.BuscarNaveNombreComercial(NaveID, Dage_ProveedorNoFiscal)
                If DTExisteNaveNombreComercial.Rows.Count > 0 Then
                    dage_ProveedorID = DTExisteNaveNombreComercial.Rows(0).Item("dage_proveedorid").ToString()
                    If dage_ProveedorID = -1 Then
                        mensajeConfirmacion.mensaje = "Ya se dio de alta una razón social con el mismo nombre, ¿Desea dar de alta la razón social con la nave?"
                        If mensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                            objbu.InsertarRelacionNaveNombreComercial(Dage_ProveedorNoFiscal, NaveID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                            objbu.ActualizarPaisNombreComercial(Dage_ProveedorNoFiscal, cmbPais.Text.ToString.Trim())
                            btnGuardar.Enabled = False
                            show_message("Exito", "Ya se dio de alta la razon social con la nave")
                        Else
                            btnGuardar.Enabled = False
                            DesactivarCampos()
                        End If
                    Else
                        show_message("Advertencia", "Ya se dio de alta una razón social con el mismo nombre")
                        btnGuardar.Enabled = False
                    End If
                    Return
                End If

            End If
        End If


    End Sub


    Private Sub HabilitarControloesedicion()

        Dim EsFiscal As Boolean = False
        Dim Page As TabPage

        If cmbTipoFiscal.SelectedIndex = 0 Then
            cmbTipoPersona.SelectedIndex = 0
            txtRFC.Enabled = False
            txtRFC.Text = String.Empty
            cmbSICYID.Enabled = False
            If cmbSICYID.Items.Count > 0 Then
                cmbSICYID.SelectedIndex = 0
            End If

            txtRazonSocial.Enabled = False
            txtRazonSocial.Text = String.Empty


            cmbTipoRazonSocial.Enabled = False
            If cmbTipoRazonSocial.Items.Count > 0 Then
                cmbTipoRazonSocial.SelectedIndex = 0
            End If

            txtNombre.Enabled = False
            txtNombre.Text = String.Empty

            txtAPaterno.Enabled = False
            txtAPaterno.Text = String.Empty

            txtAMaterno.Enabled = False
            txtAMaterno.Text = String.Empty

            cmbPais.Enabled = False
            If cmbPais.Items.Count > 0 Then
                cmbPais.SelectedIndex = 0
            End If

            cmbEstado.Enabled = False
            If cmbEstado.Items.Count > 0 Then
                cmbEstado.SelectedIndex = 0
            End If

            cmbCiudad.Enabled = False
            If cmbCiudad.Items.Count > 0 Then
                cmbCiudad.SelectedIndex = 0
            End If

            txtColonia.Enabled = False
            txtColonia.Text = String.Empty

            txtCalle.Enabled = False
            txtCalle.Text = String.Empty

            txtNumeroExterior.Enabled = False
            txtNumeroExterior.Text = String.Empty

            txtNumeroInterior.Enabled = False
            txtNumeroInterior.Text = String.Empty

            txtCodigoPostal.Enabled = False
            txtCodigoPostal.Text = String.Empty

            cmbClasificacion.Enabled = False
            If cmbClasificacion.Items.Count > 0 Then
                cmbClasificacion.SelectedIndex = 0
            End If

            cmbGiro.Enabled = False
            If cmbGiro.Items.Count > 0 Then
                cmbGiro.SelectedIndex = 0
            End If

            rdoSi.Enabled = False
            rdoNo.Enabled = False
            chkSeleccionarTodo.Enabled = False

        Else
            If cmbTipoFiscal.SelectedIndex < 0 Then
                EsFiscal = True
            Else
                If cmbTipoFiscal.SelectedItem.ToString() = "FISCAL" Then
                    EsFiscal = True
                    btnGuardar.Enabled = True
                    grdPlazosPago.Enabled = True
                Else
                    EsFiscal = False
                    btnGuardar.Enabled = True
                    grdPlazosPago.Enabled = True
                End If
            End If


            If EsFiscal = True Then
                If ProveedorID = -1 Then
                    cmbSICYID.Enabled = True
                    txtRazonSocial.Enabled = True
                    cmbTipoRazonSocial.Enabled = True
                    txtNombre.Enabled = True
                    txtAPaterno.Enabled = True
                    txtAMaterno.Enabled = True
                    cmbPais.Enabled = True
                    cmbEstado.Enabled = True
                    cmbCiudad.Enabled = True
                    txtColonia.Enabled = True
                    txtCalle.Enabled = True
                    txtNumeroExterior.Enabled = True
                    txtNumeroInterior.Enabled = True
                    txtCodigoPostal.Enabled = True
                    cmbClasificacion.Enabled = True
                    cmbGiro.Enabled = True
                    rdoSi.Enabled = False
                    rdoNo.Enabled = False
                    chkSeleccionarTodo.Enabled = True

                    If cmbTipoPersona.Text.ToString.Trim() = "FISICA" Then
                        cmbTipoRazonSocial.Enabled = False
                        txtRazonSocial.Enabled = False
                        txtNombre.Enabled = True
                        txtAPaterno.Enabled = True
                        txtAMaterno.Enabled = True
                    ElseIf cmbTipoPersona.Text.ToString() = "MORAL" Then
                        cmbTipoRazonSocial.Enabled = True
                        txtRazonSocial.Enabled = True
                        txtNombre.Enabled = False
                        txtAPaterno.Enabled = False
                        txtAMaterno.Enabled = False
                    End If



                Else
                    cmbPais.Enabled = True
                    cmbEstado.Enabled = True
                    cmbCiudad.Enabled = True
                    txtColonia.Enabled = True
                    txtCalle.Enabled = True
                    txtNumeroExterior.Enabled = True
                    txtNumeroInterior.Enabled = True
                    txtCodigoPostal.Enabled = True
                    cmbClasificacion.Enabled = True
                    cmbGiro.Enabled = True
                    rdoSi.Enabled = True
                    rdoNo.Enabled = True
                    chkSeleccionarTodo.Enabled = True


                    cmbSICYID.Enabled = False
                    txtRazonSocial.Enabled = False
                    cmbTipoRazonSocial.Enabled = False
                    txtNombre.Enabled = False
                    txtAPaterno.Enabled = False
                    txtAMaterno.Enabled = False
                    cmbNombreComercial.Enabled = False
                    cmbTipoFiscal.Enabled = False
                    cmbTipoPersona.Enabled = False
                    txtRFC.Enabled = False


                End If

            Else
                If ProveedorID = -1 Then
                    cmbSICYID.Enabled = False
                    txtRazonSocial.Enabled = False
                    cmbTipoRazonSocial.Enabled = False
                    txtNombre.Enabled = True
                    txtAPaterno.Enabled = True
                    txtAMaterno.Enabled = True


                    cmbPais.Enabled = True
                    cmbEstado.Enabled = True
                    cmbCiudad.Enabled = True
                    txtColonia.Enabled = True
                    txtCalle.Enabled = True
                    txtNumeroExterior.Enabled = True
                    txtNumeroInterior.Enabled = True
                    txtCodigoPostal.Enabled = True
                    cmbClasificacion.Enabled = True
                    cmbGiro.Enabled = True
                    rdoSi.Enabled = True
                    rdoNo.Enabled = True
                    chkSeleccionarTodo.Enabled = True
                Else
                    cmbPais.Enabled = True
                    cmbEstado.Enabled = True
                    cmbCiudad.Enabled = True
                    txtColonia.Enabled = True
                    txtCalle.Enabled = True
                    txtNumeroExterior.Enabled = True
                    txtNumeroInterior.Enabled = True
                    txtCodigoPostal.Enabled = True
                    cmbClasificacion.Enabled = True
                    cmbGiro.Enabled = True
                    rdoSi.Enabled = True
                    rdoNo.Enabled = True
                    chkSeleccionarTodo.Enabled = True



                    cmbSICYID.Enabled = False
                    txtRazonSocial.Enabled = False
                    cmbTipoRazonSocial.Enabled = False
                    txtNombre.Enabled = False
                    txtAPaterno.Enabled = False
                    txtAMaterno.Enabled = False
                    cmbNombreComercial.Enabled = False
                    cmbTipoFiscal.Enabled = False
                    cmbTipoPersona.Enabled = False
                    txtRFC.Enabled = False
                End If
            End If

        End If

    End Sub



    Private Sub cmbNombreComercial_TextChanged(sender As Object, e As EventArgs) Handles cmbNombreComercial.TextChanged

        If cmbNombreComercial.DroppedDown = True Then
            cmbNombreComercial.DroppedDown = False
        End If
    End Sub


    Private Sub cmbPais_TextChanged(sender As Object, e As EventArgs) Handles cmbPais.TextChanged
        Dim TextoSeleccionado As String = String.Empty

        Try
            If cmbPais.DroppedDown = True Then
                cmbPais.DroppedDown = False
            End If
        Catch ex As Exception
            Dim ValorError As String = ""
            ValorError = "OCurrio algo"
        End Try


    End Sub

    Private Sub cmbCiudad_TextChanged(sender As Object, e As EventArgs) Handles cmbCiudad.TextChanged
        Dim TextoSeleccionado As String = String.Empty
        Try
            If cmbCiudad.DroppedDown = True Then
                cmbCiudad.DroppedDown = False
            End If
        Catch ex As Exception
            Dim ValorError As String = ""
            ValorError = "OCurrio algo"
        End Try

    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedIndexChanged

        cmbCiudad.DataSource = Nothing

        If cmbEstado.SelectedIndex > 0 Then
            CargarCiudades(cmbEstado.SelectedValue)
        End If

    End Sub

    Private Sub cmbEstado_TextChanged(sender As Object, e As EventArgs) Handles cmbEstado.TextChanged
        Dim TextoSeleccionado As String = String.Empty

        Try
            If cmbEstado.DroppedDown = True Then
                cmbEstado.DroppedDown = False
            End If

        Catch ex As Exception
            Dim ValorError As String = ""
            ValorError = "OCurrio algo"
        End Try

    End Sub


    Private Sub cmbClasificacion_TextChanged(sender As Object, e As EventArgs) Handles cmbClasificacion.TextChanged
        Dim TextoSeleccionado As String = String.Empty
        Try
            If cmbClasificacion.DroppedDown = True Then
                cmbClasificacion.DroppedDown = False
            End If

        Catch ex As Exception
            Dim ValorError As String = ""
            ValorError = "OCurrio algo"
        End Try


    End Sub

    Private Sub cmbGiro_TextChanged(sender As Object, e As EventArgs) Handles cmbGiro.TextChanged
        Dim TextoSeleccionado As String = String.Empty
        Try
            If cmbGiro.DroppedDown = True Then
                cmbGiro.DroppedDown = False
            End If
        Catch ex As Exception
            Dim ValorError As String = ""
            ValorError = "OCurrio algo"

        End Try
    End Sub

    Private Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty
        For Each row As UltraGridRow In grdMoneda.Rows
            If CBool(row.Cells(" ").Value) Then
                If Resultado = "" Then
                    Resultado += "" + Replace(row.Cells(1).Text, ",", "") + ""
                Else
                    Resultado += "," + Replace(row.Cells(1).Text, ",", "") + ""
                End If
            End If
        Next
        Return Resultado
    End Function

    Private Sub chPagoParcialidades_CheckedChanged(sender As Object, e As EventArgs) Handles chPagoParcialidades.CheckedChanged
        If chPagoParcialidades.Checked Then
            PagoPorParcialidades = 1
        Else
            PagoPorParcialidades = 0
        End If
    End Sub
End Class