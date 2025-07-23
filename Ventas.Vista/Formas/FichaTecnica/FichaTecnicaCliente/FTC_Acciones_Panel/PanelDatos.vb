Imports Tools.Controles
Partial Public Class FichaTecnicaClienteForm

    Private Sub gboxDatosContacto_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gboxDatosContacto.MouseDoubleClick

        If gboxDatosContacto.Dock = DockStyle.Fill Then
            gboxDatosContacto.Dock = DockStyle.None
        Else
            gboxDatosContacto.Dock = DockStyle.Fill
        End If

    End Sub

    Private Sub chboxDatosPoblacion_CheckedChanged(sender As Object, e As EventArgs) Handles chboxDatosPoblacion.CheckedChanged

        If chboxDatosPoblacion.Checked Then
            cboxDatosPoblacion.Enabled = True
        Else
            cboxDatosPoblacion.Enabled = False
        End If

    End Sub

    Private Sub btnGuardarPanelDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarDatos.Click


        Try
            If Not editar_Datos_Cliente_Domicilio() Then
                Exit Sub
            End If
        Catch ex As Exception
            show_message("Error", "Algo falló en la operación")
            Exit Sub
        End Try

        Try
            If Not editar_Datos_Clientes_InfoCliente() Then
                Exit Sub
            End If
        Catch
            show_message("Error", "Algo falló en la operación")
            Exit Sub
        End Try
        Try
            If Not editar_Datos_Persona() Then
                Exit Sub
            End If
        Catch ex As Exception
            show_message("Error", "Algo falló en la operación")
            Exit Sub
        End Try
        Try
            If Not editar_Datos_Cliente_Clientes() Then
                Exit Sub
            End If
        Catch ex As Exception
            show_message("Error", "Algo falló en la operación")
            Exit Sub
        End Try

        show_message("Exito", "Datos guardados con éxito")

        recuperar_datos_Panel_Datos(CInt(lblClienteSAYID_Int.Text))

    End Sub

    Private Sub btnEditarPanelDatos_Click(sender As Object, e As EventArgs) Handles btnEditarDatos.Click

        asignaStatusControles(pnlFormDatos, True)

        txtDatosCiudadSicy.Enabled = False

        If chboxDatosPoblacion.Checked Then
            cboxDatosPoblacion.Enabled = True
        Else
            cboxDatosPoblacion.Enabled = False
        End If

    End Sub

    Private Sub btnCancelarPanelDatos_Click(sender As Object, e As EventArgs) Handles btnCancelarDatos.Click
        If Mensajes_Y_Alertas("CONFIRMACION", "Los cambios realizados no se han guardado ¿Desea cancelar los cambios?") Then
            recuperar_datos_Panel_Datos(cboxClienteCliente.SelectedValue)
            CambiarElForeColorControles_Negro(pnlFormDatos)
        End If
    End Sub

    Public Function editar_Datos_Cliente_Domicilio() As Boolean

        Dim datosClienteBU As New Negocios.ClientesDatosBU

        Dim domicilio As New Entidades.Domicilio

        '   CALLE - OBLIGATORIO
        If txtDatosCalle.TextLength < 1 Then
            show_message("Advertencia", "Falta información")
            lblDatosCalle.ForeColor = Color.Red
            Return False
        Else
            domicilio.calle = txtDatosCalle.Text
            lblDatosCalle.ForeColor = Color.Black
        End If

        '   NUMERO EXTERIOR - OBLIGATORIO
        If txtDatosNumExterior.TextLength < 1 Then
            show_message("Advertencia", "Falta información")
            lblDatosNumeroExterior.ForeColor = Color.Red
            Return False
        Else
            domicilio.numexterior = txtDatosNumExterior.Text
            lblDatosNumeroExterior.ForeColor = Color.Black
        End If

        If txtDatosNumInterior.TextLength < 1 Then
            domicilio.numinterior = Nothing
        Else
            domicilio.numinterior = txtDatosNumInterior.Text
        End If

        '   COLONIA - OBLIGATORIO
        If txtDatosColonia.TextLength < 1 Then
            show_message("Advertencia", "Falta información")
            lblDatosColonia.ForeColor = Color.Red
            Return False
        Else
            domicilio.colonia = txtDatosColonia.Text
            lblDatosColonia.ForeColor = Color.Black
        End If

        '   CODIGO POSTAL - OBLIGATORIO
        If String.IsNullOrWhiteSpace(numDatosCodigoPostal.Text) Then
            show_message("Advertencia", "Falta información")
            lblDatosCodigoPostal.ForeColor = Color.Red
            Return False
        Else
            domicilio.cp = numDatosCodigoPostal.Text
            lblDatosCodigoPostal.ForeColor = Color.Black
        End If

        If txtDatosCiudadSicy.TextLength < 1 Then
            domicilio.delegacion = Nothing
        Else
            domicilio.delegacion = txtDatosCiudadSicy.Text
        End If

        Dim Pais As New Entidades.Paises
        If IsDBNull(cboxDatosPais.SelectedValue) Then
            show_message("Advertencia", "Falta información")
            lblDatosPais.ForeColor = Color.Red
            Return False
        Else
            Pais.PIDPais = cboxDatosPais.SelectedValue
            domicilio.pais = Pais
            lblDatosPais.ForeColor = Color.Black
        End If


        Dim Estado As New Entidades.Estados
        If IsDBNull(cboxDatosEstado.SelectedValue) Then
            show_message("Advertencia", "Falta información")
            lblDatosEstado.ForeColor = Color.Red
            Return False
        Else
            Estado.EIDDEstado = cboxDatosEstado.SelectedValue
            domicilio.estado = Estado
            lblDatosEstado.ForeColor = Color.Black
        End If


        Dim Ciudad As New Entidades.Ciudades
        If IsDBNull(cboxDatosCiudad.SelectedValue) Then
            show_message("Advertencia", "Falta información")
            lblDatosCiudad.ForeColor = Color.Red
            Return False
        Else
            Ciudad.CciudadId = cboxDatosCiudad.SelectedValue
            domicilio.ciudad = Ciudad
            lblDatosCiudad.ForeColor = Color.Black
        End If

        If chboxDatosPoblacion.Checked Then
            Dim Poblacion As New Entidades.Poblacion

            If IsDBNull(cboxDatosPoblacion.SelectedValue) Then
                Poblacion.poblacionid = 0
            Else
                Poblacion.poblacionid = cboxDatosPoblacion.SelectedValue
            End If
            domicilio.poblacion = Poblacion
        Else
            domicilio.poblacion = Nothing
        End If

        Dim Persona As New Entidades.Persona
        Persona.personaid = CInt(lblClientePersonaID_Int.Text)
        domicilio.persona = Persona

        Dim clasificacionPersona As New Entidades.ClasificacionPersona
        If cboxClienteEstatus.Text.ToUpperInvariant.Equals("PROSPECTO") Then
            clasificacionPersona.clasificacionpersonaid = 3
            domicilio.clasificacionpersona = clasificacionPersona
        ElseIf cboxClienteEstatus.Text.ToUpperInvariant.Equals("CLIENTE") Then
            clasificacionPersona.clasificacionpersonaid = 1
            domicilio.clasificacionpersona = clasificacionPersona
        End If

        Try
            datosClienteBU.editarDomicilioCliente(domicilio, 2)
            Return True
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    Public Function editar_Datos_Clientes_InfoCliente() As Boolean

        Dim clientesDatosBU As New Negocios.ClientesDatosBU
        Dim clienteInformacion As New Entidades.InformacionClienteVentas
        Dim cliente As New Entidades.Cliente

        If rbtnDatosFestejaAniversarioSi.Checked Then
            clienteInformacion.festejaaniversario = True
        ElseIf rbtnDatosFestejaAniversarioNo.Checked Then
            clienteInformacion.festejaaniversario = False
        End If
        clienteInformacion.fechafundacion = DateTime.Parse(dateDatosFechaFundacion.Value)
        If rbtnDatosFestejaDiasFestivosSi.Checked Then
            clienteInformacion.festejadiasfestivos = True
        ElseIf rbtnDatosFestejaDiasFestivosNo.Checked Then
            clienteInformacion.festejadiasfestivos = False
        End If

        clienteInformacion.capacidadcompratotal = CInt(numDatosCapacidadTotalDeCompraAnual.Value)
        clienteInformacion.capacidadcomprayuyin = numDatosCapacidadYuyin.Value

        clienteInformacion.usuarioproveedor = txtDatosUsuario.Text
        clienteInformacion.contrasenaproveedor = txtDatosContrasena.Text
        clienteInformacion.sitioaccesoproveedor = txtDatosWebProveedor.Text

        cliente.clienteid = cboxClienteCliente.SelectedValue
        clienteInformacion.cliente = cliente

        Try
            clientesDatosBU.editarVentasInfoCliente(clienteInformacion, 1)
            Return True
        Catch
            Return False
        End Try

    End Function

    Public Function editar_Datos_Persona() As Boolean

        Dim personaBU As New Framework.Negocios.PersonasBU
        Dim persona As New Entidades.Persona
        Dim email As New Entidades.Email

        If txtDatosWebGeneral.TextLength < 1 Then
            persona.paginaweb = String.Empty
        Else
            persona.paginaweb = txtDatosWebGeneral.Text
        End If
        Try
            personaBU.EditarPersona(persona, CInt(lblClienteSAYID_Int.Text), Nothing, 2)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function editar_Datos_Cliente_Clientes() As Boolean

        Dim clienteBU As New Negocios.ClientesBU
        Dim cliente As New Entidades.Cliente
        Dim empresas As New Entidades.Empresa
        Dim tipoCliente As New Entidades.TipoCliente

        If txtDatosComentarios.TextLength < 1 Then
            cliente.comentarios = Nothing
        Else
            cliente.comentarios = txtDatosComentarios.Text
        End If

        empresas.Pempr_empresaid = 0
        cliente.empresa = empresas

        tipoCliente.tipoclienteid = 0
        cliente.tipocliente = tipoCliente

        cliente.clienteid = cboxClienteCliente.SelectedValue

        cliente.claveyuyinproveedor = numDatosProveedor.Value

        Try
            clienteBU.editarCliente(cliente, Nothing, 1, True, True)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Sub recuperar_datos_Panel_Datos(clienteID As Integer)

        limpiarControles(pnlFormDatos)
        asignaStatusControles(pnlFormDatos, False)
        txtDatosCiudadSicy.Enabled = False

        If rbtnClienteStatusInactivo.Checked Then
            btnEditarDatos.Enabled = False
        Else
            If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
                btnEditarDatos.Enabled = True
            Else
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
                    btnEditarDatos.Enabled = True
                Else
                    btnEditarDatos.Enabled = False
                End If
            End If
        End If

        'If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
        '    If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
        '        btnEditarDatos.Enabled = False
        '    Else
        '        btnEditarDatos.Enabled = True
        '    End If
        'End If

        ''DOMICILIO

        Dim domicilio As New DataTable
        Dim DomicilioBU As New Framework.Negocios.DomicilioBU
        domicilio = DomicilioBU.Datos_TablaDomicilioPersona(CInt(lblClientePersonaID_Int.Text))

        If domicilio.Rows.Count > 0 Then

            txtDatosCalle.Text = CStr(domicilio.Rows(0).Item("domi_calle"))
            If IsDBNull(domicilio.Rows(0).Item("domi_numinterior")) Then
                txtDatosNumExterior.Text = String.Empty
            Else
                txtDatosNumInterior.Text = CStr(domicilio.Rows(0).Item("domi_numinterior"))
            End If

            txtDatosNumExterior.Text = CStr(domicilio.Rows(0).Item("domi_numexterior"))
            txtDatosColonia.Text = CStr(domicilio.Rows(0).Item("domi_colonia"))
            cboxDatosPais.Text = CStr(domicilio.Rows(0).Item("pais_nombre"))

            ListaPais(cboxDatosPais)
            cboxDatosPais.SelectedValue = CInt(domicilio.Rows(0).Item("pais_paisid"))

            ListaEstado(cboxDatosEstado, CInt(cboxDatosPais.SelectedValue))
            cboxDatosEstado.SelectedValue = CInt(domicilio.Rows(0).Item("esta_estadoid"))

            ListaCiudad(cboxDatosCiudad, CInt(cboxDatosEstado.SelectedValue))
            cboxDatosCiudad.SelectedValue = CInt(domicilio.Rows(0).Item("city_ciudadid"))

            If IsDBNull(domicilio.Rows(0).Item("domi_cp")) Then
                numDatosCodigoPostal.Text = String.Empty
            Else
                numDatosCodigoPostal.Text = CStr(domicilio.Rows(0).Item("domi_cp"))
            End If

            ListaPoblacion(cboxDatosPoblacion, CInt(cboxDatosCiudad.SelectedValue))
            If IsDBNull(domicilio.Rows(0).Item("pobl_nombre")) Then
                cboxDatosPoblacion.Text = String.Empty
                chboxDatosPoblacion.Checked = False
            Else
                cboxDatosPoblacion.SelectedValue = CInt(domicilio.Rows(0).Item("pobl_poblacionid"))
                chboxDatosPoblacion.Checked = True
            End If

            cboxDatosPoblacion.Enabled = False

            If IsDBNull(domicilio.Rows(0).Item("domi_delegacion")) Then
                txtDatosCiudadSicy.Text = String.Empty
            Else
                txtDatosCiudadSicy.Text = CStr(domicilio.Rows(0).Item("domi_delegacion"))
            End If

        End If

        ''INFO CLIENTE

        Dim ClientesDatosBU As New Negocios.ClientesDatosBU
        Dim infoCliente As New DataTable
        infoCliente = ClientesDatosBU.Datos_TablaVentasInfoCliente(clienteID)

        If infoCliente.Rows.Count > 0 Then

            If IsDBNull(infoCliente.Rows(0).Item("ivcl_festejaaniversario")) Then
                rbtnDatosFestejaAniversarioSi.Checked = False
                rbtnDatosFestejaAniversarioNo.Checked = False
            Else
                If CBool(infoCliente.Rows(0).Item("ivcl_festejaaniversario")) Then
                    rbtnDatosFestejaAniversarioSi.Checked = True
                    rbtnDatosFestejaAniversarioNo.Checked = False
                Else
                    rbtnDatosFestejaAniversarioNo.Checked = True
                    rbtnDatosFestejaAniversarioSi.Checked = False
                End If
            End If

            If IsDBNull(infoCliente.Rows(0).Item("ivcl_festejadiasfestivos")) Then
                rbtnDatosFestejaDiasFestivosSi.Checked = False
                rbtnDatosFestejaDiasFestivosNo.Checked = False
            Else
                If CBool(infoCliente.Rows(0).Item("ivcl_festejadiasfestivos")) Then
                    rbtnDatosFestejaDiasFestivosSi.Checked = True
                    rbtnDatosFestejaDiasFestivosNo.Checked = False
                Else
                    rbtnDatosFestejaDiasFestivosNo.Checked = True
                    rbtnDatosFestejaDiasFestivosSi.Checked = False
                End If
            End If


            If IsDBNull(infoCliente.Rows(0).Item("ivcl_fechafundacion")) Then
                dateDatosFechaFundacion.Value = Date.Now
            Else
                dateDatosFechaFundacion.Value = DateTime.Parse(infoCliente.Rows(0).Item("ivcl_fechafundacion"))
            End If

            If IsDBNull(infoCliente.Rows(0).Item("ivcl_capacidadcompratotal")) Then
                numDatosCapacidadTotalDeCompraAnual.Value = Decimal.Zero
            Else
                numDatosCapacidadTotalDeCompraAnual.Value = CInt(infoCliente.Rows(0).Item("ivcl_capacidadcompratotal"))
            End If

            If IsDBNull(infoCliente.Rows(0).Item("ivcl_capacidadcomprayuyin")) Then
                numDatosCapacidadYuyin.Value = Decimal.Zero
            Else
                numDatosCapacidadYuyin.Value = CInt(infoCliente.Rows(0).Item("ivcl_capacidadcomprayuyin"))
            End If

            If IsDBNull(infoCliente.Rows(0).Item("ivcl_sitioaccesoproveedor")) Then
                txtDatosWebProveedor.Text = String.Empty
            Else
                txtDatosWebProveedor.Text = CStr(infoCliente.Rows(0).Item("ivcl_sitioaccesoproveedor"))
            End If


            If IsDBNull(infoCliente.Rows(0).Item("ivcl_usuarioproveedor")) Then
                txtDatosUsuario.Text = String.Empty
            Else
                txtDatosUsuario.Text = CStr(infoCliente.Rows(0).Item("ivcl_usuarioproveedor"))
            End If

            If IsDBNull(infoCliente.Rows(0).Item("ivcl_contrasenaproveedor")) Then
                txtDatosContrasena.Text = String.Empty
            Else
                txtDatosContrasena.Text = CStr(infoCliente.Rows(0).Item("ivcl_contrasenaproveedor"))
            End If

        End If


        ''CLIENTE

        Dim ClientesBU As New Negocios.ClientesBU
        Dim cliente As New DataTable
        cliente = ClientesBU.Datos_TablaCliente(clienteID)
        If cliente.Rows.Count > 0 Then

            If IsDBNull(cliente.Rows(0).Item("clie_claveyuyinproveedor")) Then
                numDatosProveedor.Value = Decimal.Zero
            Else
                numDatosProveedor.Value = CInt(cliente.Rows(0).Item("clie_claveyuyinproveedor"))
            End If

            If IsDBNull(cliente.Rows(0).Item("clie_comentarios")) Then
                txtDatosComentarios.Text = String.Empty
            Else
                txtDatosComentarios.Text = CStr(cliente.Rows(0).Item("clie_comentarios"))
            End If

        End If


        ''PERSONA
        Dim PersonasBU As New Framework.Negocios.PersonasBU
        Dim persona As New DataTable
        persona = PersonasBU.Datos_TablaPersona(CInt(lblClientePersonaID_Int.Text))
        If persona.Rows.Count > 0 Then

            If IsDBNull(persona.Rows(0).Item("pers_paginaweb")) Then
                txtDatosWebGeneral.Text = String.Empty
            Else
                txtDatosWebGeneral.Text = CStr(persona.Rows(0).Item("pers_paginaweb"))
            End If

        End If

        'dockManagerFichaTecnica.EndUpdate()

    End Sub

    Private Sub rbtnDatosFestejaAniversarioNo_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnDatosFestejaAniversarioNo.CheckedChanged
        If rbtnDatosFestejaAniversarioNo.Checked = True Then
            dateDatosFechaFundacion.Visible = False
            lblDatosFechaFundacion.Visible = False
        Else
            dateDatosFechaFundacion.Visible = True
            lblDatosFechaFundacion.Visible = False
        End If

    End Sub

End Class
