Imports Infragistics.Win.UltraWinGrid
Imports Tools.Controles
Imports Infragistics.Win

Partial Public Class FichaTecnicaClienteForm
    Public idComer As Integer
    Dim modoEdicion_CEDIS As Boolean = False 'TRUE PARA EDITAR, FALSE PARA LECTURA


    Private Sub gpbTiemdaEmbarqueCedis_nvo_DoubleClick(sender As Object, e As EventArgs) Handles gpbTiemdaEmbarqueCedis_nvo.DoubleClick
        If gpbTiemdaEmbarqueCedis_nvo.Dock = DockStyle.Fill Then
            gpbTiemdaEmbarqueCedis_nvo.Dock = DockStyle.None
        Else
            gpbTiemdaEmbarqueCedis_nvo.Dock = DockStyle.Fill
        End If
    End Sub

    Private Sub btnBuscarCEDIS_Click(sender As Object, e As EventArgs) Handles btnBuscarCEDIS.Click
        If Not IsDBNull(cboxCEDISCEDIS.SelectedValue) Then
            recuperar_datos_Panel_CEDIS(CInt(cboxCEDISCEDIS.SelectedValue))
        Else
            Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione el nombre del cliente para poder refrescar la información")
        End If
    End Sub

    Private Sub btnGuardarCEDISPersona_Click(sender As Object, e As EventArgs) Handles btnGuardarCEDISPersona.Click

        Dim PersonasBU As New Framework.Negocios.PersonasBU
        Dim ClientesDatosBU As New Negocios.ClientesDatosBU
        Dim persona As New Entidades.Persona
        Dim cliente As New Entidades.Cliente
        Dim clienteRFC As New Entidades.ClienteRFC
        Dim tipoPersona As New Entidades.TipoPersona
        Dim TEC As New Entidades.TiendaEmbarqueCedis
        Dim clasificacionPersona As New Entidades.ClasificacionPersona
        Dim PermitirGuardar As Boolean = False

        '   CEDIS RFC - OBLIGATORIO
        If IsDBNull(cboxCEDISRFC.SelectedValue) Or IsNothing(cboxCEDISRFC.SelectedValue) Then
            show_message("Advertencia", "Falta información")
            lblCEDISRFC.ForeColor = Color.Red
            Exit Sub
        Else
            If cboxCEDISRFC.SelectedValue = 0 Then
                show_message("Advertencia", "Falta información")
                lblCEDISRFC.ForeColor = Color.Red
                Exit Sub
            Else
                lblCEDISRFC.ForeColor = Color.Black
            End If
        End If

        '   CEDIS NOMBRE - OBLIGATORIO
        If cboxCEDISCEDIS.Text.Length < 1 Then
            show_message("Advertencia", "Falta información")
            lblCEDISCEDIS.ForeColor = Color.Red
            Exit Sub
        Else
            lblCEDISCEDIS.ForeColor = Color.Black
        End If

        'cboxCEDISDistribucionSICY
        If IsDBNull(cboxCEDISDistribucionSICY.SelectedValue) Or IsNothing(cboxCEDISDistribucionSICY.SelectedValue) Then
            show_message("Advertencia", "Falta información")
            lblCEDISDistribucionSICY.ForeColor = Color.Red
            Exit Sub
        Else
            If cboxCEDISDistribucionSICY.SelectedValue = 0 Then
                show_message("Advertencia", "Falta información")
                lblCEDISDistribucionSICY.ForeColor = Color.Red
                Exit Sub
            Else
                lblCEDISDistribucionSICY.ForeColor = Color.Black
            End If
        End If

        cliente.clienteid = CInt(lblClienteSAYID_Int.Text)
        clienteRFC.clienterfcid = cboxCEDISRFC.SelectedValue
        TEC.clienterfc = clienteRFC
        persona.personaid = CInt(lblCEDISPersonaID_Int.Text)
        persona.nombre = cboxCEDISCEDIS.Text
        persona.SicyID = cboxCEDISDistribucionSICY.SelectedValue

        If rbtnTipoPersonaTienda.Checked Then
            clasificacionPersona.clasificacionpersonaid = 15
            gboxTipoPersona.ForeColor = Color.Black
        ElseIf rbtnTipoPersonaEmbarque.Checked Then
            clasificacionPersona.clasificacionpersonaid = 16
            gboxTipoPersona.ForeColor = Color.Black
        ElseIf rbtnTipoPersonaCEDIS.Checked Then
            clasificacionPersona.clasificacionpersonaid = 17
            gboxTipoPersona.ForeColor = Color.Black
        Else
            show_message("Advertencia", "Debe seleccionar un tipo de tienda")
            gboxTipoPersona.ForeColor = Color.Red
            Exit Sub
        End If

        tipoPersona.clasificacionpersona = clasificacionPersona
        If rbtnCedisEstatusActivo.Checked Then
            persona.activo = True
            TEC.activo = True
            lblCedisEstatus.ForeColor = Color.Black
        ElseIf rbtnCEDISEstatusInactivo.Checked Then
            persona.activo = False
            TEC.activo = False
            lblCedisEstatus.ForeColor = Color.Black
        Else
            show_message("Advertencia", "Debe seleccionar un status")
            lblCedisEstatus.ForeColor = Color.Red
            Exit Sub
        End If

        TEC.persona = persona
        ' Validar si la tienda a desactivar se encuentra en un pedido activo
        If TEC.activo = False Then
            If ClientesDatosBU.ExisteTiendaEnPedidosActivos(persona.personaid) = True Then
                PermitirGuardar = False
            Else
                PermitirGuardar = True
            End If
        Else
            PermitirGuardar = True
        End If


        If PermitirGuardar = True Then

            If persona.personaid = 0 Then
                PersonasBU.AltaPersona(persona, cliente, clienteRFC, tipoPersona, 2)
            Else
                PersonasBU.EditarPersona(persona, Nothing, Nothing, 4)
                ClientesDatosBU.editarCedisClienteCEDIS(TEC, tipoPersona, 3)
            End If

            poblar_gridClienteRFCCEDIS(CInt(lblClientePersonaID_Int.Text), gridCEDISCEDIS)


            Dim cedisnombre As String = cboxCEDISCEDIS.Text
            ListaTECClienteRFC(cboxCEDISCEDIS, CInt(cboxCEDISRFC.SelectedValue))
            cboxCEDISCEDIS.SelectedText = cedisnombre
            cboxCEDISCEDIS.Text = cedisnombre

            lblCEDISPersonaID_Int.Text = CStr(cboxCEDISCEDIS.SelectedValue)
            show_message("Exito", "Guardado con éxito")

            btnBuscarCEDIS.Enabled = False

            btnBuscarCEDIS.PerformClick()

            asignaStatusControles(pnlFormCEDIS, False)

            modoEdicion_CEDIS = False
        Else
            Tools.MostrarMensaje(Tools.modMensajes.Mensajes.Warning, "No se puede desactivar la tienda porque esta en un pedido activo.")
        End If

    End Sub

    Private Sub btnEditarCEDISPersona_Click(sender As Object, e As EventArgs) Handles btnEditarCEDISPersona.Click
        modoEdicion_CEDIS = True

        'cabecera
        asignaStatusControles(pnlCEDISPersona, True)
        gboxTipoPersona.Enabled = True
        cboxCEDISCEDIS.DropDownStyle = ComboBoxStyle.Simple
        btnBuscarCEDIS.Enabled = False
        btnEditarCEDISDomicilio.Enabled = True
        btnEditarCEDISEmbarque.Enabled = True
        btnEditarCEDISEmpaque.Enabled = True
        btnEditarCEDISMensajeria.Enabled = True
        btnTEC_AgregarTEC.Enabled = False

        Dim distribucion_sicyID As Integer
        If Not IsDBNull(cboxCEDISDistribucionSICY.SelectedValue) Then
            distribucion_sicyID = cboxCEDISDistribucionSICY.SelectedValue
        End If
        ListaTEC_Sicy(cboxCEDISDistribucionSICY, CInt(txtClienteSICYID.Text), distribucion_sicyID, True)
        cboxCEDISDistribucionSICY.SelectedValue = distribucion_sicyID

    End Sub

    Private Sub btnCancelarCEDISPersona_Click(sender As Object, e As EventArgs) Handles btnCancelarCEDISPersona.Click
        If Mensajes_Y_Alertas("CONFIRMACION", "Los cambios realizados no se han guardado ¿Desea cancelar los cambios?") Then
            'cabecera
            recuperar_datos_Panel_CEDIS(CInt(lblCEDISPersonaID_Int.Text))
            CambiarElForeColorControles_Negro(pnlCEDISPersona)
            CambiarElForeColorControles_DodgerBlue(pnlBotonesCEDIS)

            modoEdicion_CEDIS = False
        End If

    End Sub

    Private Sub btnguardarCedisDomicilio_Click(sender As Object, e As EventArgs) Handles btnGuardarCEDISDomicilio.Click

        '   CALLE - OBLIGATORIO
        If txtCEDISCalle.TextLength < 1 Then
            show_message("Advertencia", "Falta información")
            lblCEDISCalle.ForeColor = Color.Red
            Exit Sub
        Else
            lblCEDISCalle.ForeColor = Color.Black
        End If

        '   DOMICILIO NUMERO EXTERIOR CEDIS - OBLIGATORIO
        If txtCEDISNumeroExterior.TextLength < 1 Then
            show_message("Advertencia", "Falta información")
            lblCEDISNumeroExterior.ForeColor = Color.Red
            Exit Sub
        Else
            lblCEDISNumeroExterior.ForeColor = Color.Black
        End If

        '   DOMICILIO COLONIA CEDIS - OBLIGATORIO
        If txtCEDISColonia.TextLength < 1 Then
            show_message("Advertencia", "Falta información")
            lblCEDISColonia.ForeColor = Color.Red
            Exit Sub
        Else
            lblCEDISColonia.ForeColor = Color.Black
        End If

        '   DOMICILIO CODIGO POSTAL CEDIS - OBLIGATORIO
        If numCedisCodigoPostal.TextLength = 0 Then
            show_message("Advertencia", "Falta información")
            lblCedisCodigoPostal.ForeColor = Color.Red
            Exit Sub
        Else
            lblCedisCodigoPostal.ForeColor = Color.Black
        End If

        '   DOMICILIO PAIS CEDIS - OBLIGATORIO
        If IsDBNull(cboxCEDISPais.SelectedValue) Or IsNothing(cboxCEDISPais.SelectedValue) Then
            show_message("Advertencia", "Falta información")
            lblCEDISPais.ForeColor = Color.Red
            Exit Sub
        Else
            If cboxCEDISPais.SelectedValue = 0 Then
                show_message("Advertencia", "Falta información")
                lblCEDISPais.ForeColor = Color.Red
                Exit Sub
            Else
                lblCEDISPais.ForeColor = Color.Black
            End If
        End If

        '   DOMICILIO ESTADO CEDIS - OBLIGATORIO
        If IsDBNull(cboxCEDISEstado.SelectedValue) Or IsNothing(cboxCEDISEstado.SelectedValue) Then
            show_message("Advertencia", "Falta información")
            lblCEDISEstado.ForeColor = Color.Red
            Exit Sub
        Else
            If cboxCEDISEstado.SelectedValue = 0 Then
                show_message("Advertencia", "Falta información")
                lblCEDISEstado.ForeColor = Color.Red
                Exit Sub
            Else
                lblCEDISEstado.ForeColor = Color.Black
            End If
        End If

        '   DOMICILIO CIUDAD CEDIS - OBLIGATORIO
        If IsDBNull(cboxCEDISCiudad.SelectedValue) Or IsNothing(cboxCEDISCiudad.SelectedValue) Then
            show_message("Advertencia", "Falta información")
            lblCEDISCiudad.ForeColor = Color.Red
            Exit Sub
        Else
            If cboxCEDISCiudad.SelectedValue = 0 Then
                show_message("Advertencia", "Falta información")
                lblCEDISCiudad.ForeColor = Color.Red
                Exit Sub
            Else
                lblCEDISCiudad.ForeColor = Color.Black
            End If
        End If

        Dim datosClienteBU As New Negocios.ClientesDatosBU
        Dim domicilio As New Entidades.Domicilio

        '   DOMICILIO CALLE CEDIS - OBLIGATORIO
        If txtCEDISCalle.TextLength > 1 Then
            domicilio.calle = txtCEDISCalle.Text
        Else
            show_message("Advertencia", "Falta información")
            lblDatosCalle.ForeColor = Color.Red
        End If

        '   DOMICILIO NUMERO EXTERIOR CEDIS - OBLIGATORIO
        If txtCEDISNumeroExterior.TextLength < 1 Then
            show_message("Advertencia", "Falta información")
            lblCEDISNumeroExterior.ForeColor = Color.Red
            Exit Sub
        Else
            domicilio.numexterior = txtCEDISNumeroExterior.Text
            lblCEDISNumeroExterior.ForeColor = Color.Black
        End If

        If txtCEDISNumeroInterior.TextLength < 1 Then
            domicilio.numinterior = Nothing
        Else
            domicilio.numinterior = txtCEDISNumeroInterior.Text
        End If

        '   DOMICILIO CODIGO POSTAL CEDIS - OBLIGATORIO
        If txtCEDISColonia.TextLength < 1 Then
            show_message("Advertencia", "Falta información")
            lblCEDISColonia.ForeColor = Color.Red
            Exit Sub
        Else
            domicilio.colonia = txtCEDISColonia.Text
            lblCEDISColonia.ForeColor = Color.Black
        End If

        '   DOMICILIO CODIGO POSTAL CEDIS- OBLIGATORIO
        If numCedisCodigoPostal.TextLength = 0 Then
            show_message("Advertencia", "Falta información")
            lblCedisCodigoPostal.ForeColor = Color.Red
            Exit Sub
        Else
            domicilio.cp = numCedisCodigoPostal.Text
            lblCedisCodigoPostal.ForeColor = Color.Black
        End If

        Dim Ciudad As New Entidades.Ciudades
        Ciudad.CciudadId = cboxCEDISCiudad.SelectedValue
        domicilio.ciudad = Ciudad

        Dim Estado As New Entidades.Estados
        Estado.EIDDEstado = cboxCEDISEstado.SelectedValue
        domicilio.estado = Estado

        Dim Pais As New Entidades.Paises
        Pais.PIDPais = cboxCEDISPais.SelectedValue
        domicilio.pais = Pais

        If chboxCedisPoblacion.Checked Then
            Dim Poblacion As New Entidades.Poblacion

            If IsDBNull(cboxCedisPoblacion.SelectedValue) Then
                Poblacion.poblacionid = 0
            Else
                Poblacion.poblacionid = cboxCedisPoblacion.SelectedValue
            End If
            domicilio.poblacion = Poblacion
        Else
            domicilio.poblacion = Nothing
        End If

        Dim clasificacionPersona As New Entidades.ClasificacionPersona

        If rbtnTipoPersonaTienda.Checked Then
            clasificacionPersona.clasificacionpersonaid = 15
        ElseIf rbtnTipoPersonaEmbarque.Checked Then
            clasificacionPersona.clasificacionpersonaid = 16
        ElseIf rbtnTipoPersonaCEDIS.Checked Then
            clasificacionPersona.clasificacionpersonaid = 17
        Else
            show_message("Advertencia", "Debe seleccionar un tipo de tienda")
            Exit Sub
        End If

        Dim Persona As New Entidades.Persona
        Persona.personaid = CInt(cboxCEDISCEDIS.SelectedValue)
        domicilio.persona = Persona

        domicilio.clasificacionpersona = clasificacionPersona

        Try
            datosClienteBU.editarDomicilioCliente(domicilio, 1)
        Catch ex As Exception

        End Try
        show_message("Exito", "Guardado con éxito")

        asignaStatusControles(tpgCEDISDomicilio, False)


        poblar_gridClienteRFCCEDIS(CInt(lblClientePersonaID_Int.Text), gridCEDISCEDIS)
        poblar_gridCEDISMensajeria(IdCedis, cboxCEDISCiudad.SelectedValue, 0)

        modoEdicion_CEDIS = False
    End Sub

    Private Sub btnEditarCedisDomicilio_Click(sender As Object, e As EventArgs) Handles btnEditarCEDISDomicilio.Click
        'domicilio
        modoEdicion_CEDIS = True

        asignaStatusControles(tpgCEDISDomicilio, True)

        txtCEDISCiudadSicy.Enabled = False
    End Sub

    Private Sub btnCancelarCedisDomicilio_Click(sender As Object, e As EventArgs) Handles btnCancelarCEDISDomicilio.Click

        If Mensajes_Y_Alertas("CONFIRMACION", "Los cambios realizados no se han guardado ¿Desea cancelar los cambios?") Then
            'domicilio
            asignaStatusControles(tpgCEDISDomicilio, False)
            CambiarElForeColorControles_Negro(tpgCEDISDomicilio)
            CambiarElForeColorControles_DodgerBlue(pnlBotonesCEDISDomicilio)
            modoEdicion_CEDIS = False
        End If
    End Sub

    Private Sub btnGuardarCedisEmbarque_Click(sender As Object, e As EventArgs) Handles btnGuardarCEDISEmbarque.Click

        Dim clientesDatosBU As New Negocios.ClientesDatosBU

        Dim TEC As New Entidades.TiendaEmbarqueCedis
        'Dim clienteRFC As New Entidades.ClienteRFC
        Dim persona As New Entidades.Persona
        Dim clasificacionPersona As New Entidades.ClasificacionPersona
        Dim TipoTienda As New Entidades.TipoTienda
        Dim ramo As New Entidades.Ramo
        Dim tipoFlete As New Entidades.TipoFlete
        Dim tipoValor As New Entidades.TipoValor
        Dim tipoEmpaque As New Entidades.TipoEmpaque
        Dim tamanoEmpaque As New Entidades.TamanoEmpaque

        'clienteRFC.clienterfcid = cboxCEDISRFC.SelectedValue
        'TEC.clienterfc = clienteRFC

        persona.personaid = cboxCEDISCEDIS.SelectedValue
        TEC.persona = persona

        If rbtnTipoPersonaTienda.Checked Then
            clasificacionPersona.clasificacionpersonaid = 15
        ElseIf rbtnTipoPersonaEmbarque.Checked Then
            clasificacionPersona.clasificacionpersonaid = 16
        ElseIf rbtnTipoPersonaCEDIS.Checked Then
            clasificacionPersona.clasificacionpersonaid = 17
        Else
            show_message("Advertencia", "Debe seleccionar un tipo de tienda")
            Exit Sub
        End If

        TEC.clasificacionpersona = clasificacionPersona

        If rbtnCEDISReembarcarSi.Checked Then
            TEC.reembarcar = True
        ElseIf rbtnCEDISReembarcarNo.Checked Then
            TEC.reembarcar = False
        End If

        TEC.reembarcarporcobrar = chboxCEDISReembarcarPorCobrar.CheckState

        If IsDBNull(cboxCEDISRamo.SelectedValue) Or IsNothing(cboxCEDISRamo.SelectedValue) Then
            show_message("Advertencia", "Falta información")
            lblCEDISRamo.ForeColor = Color.Red
            Exit Sub
        Else
            If cboxCEDISRamo.SelectedValue = 0 Then
                show_message("Advertencia", "Falta información")
                lblCEDISRamo.ForeColor = Color.Red
                Exit Sub
            Else
                lblCEDISRamo.ForeColor = Color.Black
            End If
        End If

        If IsDBNull(cboxCEDISTipoTienda.SelectedValue) Or IsNothing(cboxCEDISTipoTienda.SelectedValue) Then
            show_message("Advertencia", "Falta información")
            lblCEDISTipoTienda.ForeColor = Color.Red
            Exit Sub
        Else
            If cboxCEDISTipoTienda.SelectedValue = 0 Then
                show_message("Advertencia", "Falta información")
                lblCEDISTipoTienda.ForeColor = Color.Red
                Exit Sub
            Else
                lblCEDISTipoTienda.ForeColor = Color.Black
            End If
        End If

        ramo.ramoid = cboxCEDISRamo.SelectedValue
        TEC.ramo = ramo

        TipoTienda.tipotiendaid = cboxCEDISTipoTienda.SelectedValue
        TEC.tipotienda = TipoTienda

        TEC.conveniotransportes = txtCEDISConvenio.Text
        TEC.seguro = txtCEDISSeguro.Text
        TEC.poliza = txtCEDISPoliza.Text

        TEC.codigoTienda = txtCodigoTienda.Text

        If Not IsDBNull(cboxCedisTipoValor.SelectedValue) Then
            tipoValor.tipovalorid = cboxCedisTipoValor.SelectedValue
            TEC.tipovalor = tipoValor
        End If


        If rbtnCEDISDeclararValorSi.Checked Then
            TEC.declararvalor = True
        ElseIf rbtnCEDISDeclararValorNo.Checked Then
            TEC.declararvalor = False
        End If

        If rbtnCEDISDeclararValorMonto.Checked Then
            TEC.declararenpesos = True
        ElseIf rbtnCEDISDeclararValorPorcentaje.Checked Then
            TEC.declararenpesos = False
        End If

        TEC.valoradeclarar = CDec(numCEDISValorADeclarar.Value)

        If Not IsDBNull(cboxCEDISTipoFlete.SelectedValue) Then
            tipoFlete.tipofleteid = cboxCEDISTipoFlete.SelectedValue
        End If
        TEC.tipoflete = tipoFlete

        If txtCEDISComentarios.TextLength < 1 Then
            TEC.comentarios = String.Empty
        Else
            TEC.comentarios = txtCEDISComentarios.Text
        End If

        Try
            clientesDatosBU.editarCedisClienteCEDIS(TEC, Nothing, 1)
            show_message("Exito", "Información guardada con éxito")
        Catch ex As Exception

        End Try

        asignaStatusControles(tpgCEDISEmbarque, False)
        poblar_gridClienteRFCCEDIS(CInt(lblClientePersonaID_Int.Text), gridCEDISCEDIS)

        modoEdicion_CEDIS = False
    End Sub

    Private Sub btnEditarCEDISEmbarque_Click(sender As Object, e As EventArgs) Handles btnEditarCEDISEmbarque.Click
        modoEdicion_CEDIS = True

        'embarque
        asignaStatusControles(tpgCEDISEmbarque, True)

    End Sub

    Private Sub btnCancelarCEDISEmbarque_Click(sender As Object, e As EventArgs) Handles btnCancelarCEDISEmbarque.Click
        If Mensajes_Y_Alertas("CONFIRMACION", "Los cambios realizados no se han guardado ¿Desea cancelar los cambios?") Then
            'embarque
            asignaStatusControles(tpgCEDISEmbarque, False)
            CambiarElForeColorControles_Negro(tpgCEDISEmbarque)
            CambiarElForeColorControles_DodgerBlue(pnlBotonesCEDISEmbarque)
            modoEdicion_CEDIS = False
        End If

    End Sub

    Private Sub btnGuardarCEDISMensajeria_Click(sender As Object, e As EventArgs) Handles btnGuardarCEDISMensajeria.Click

        asignaStatusControles(tpgCEDISMensajeria, False)
        gridCEDISMensajeria.AllowDrop = False
        Dim clientesDatosBU As New Negocios.ClientesDatosBU
        Dim bandera As Integer
        Dim prioridad As Integer



        For Each row As UltraGridRow In gridCEDISMensajeria.Rows
            If row.Cells("tecm_prioridad").Text = "" Then
                row.Cells("tecm_prioridad").Value = row.Index + 1
            End If

            Dim tecid As Integer = CInt(lblTECPersonaID_Int.Text)
            Dim mensajeriaid As Integer = CInt(row.Cells(7).Value)


            If row.Index = 0 Then
                bandera = 1
            Else
                bandera = 0
            End If
            If IsDBNull(row.Cells(0).Value) Then
                prioridad = 0
            Else
                prioridad = CInt(row.Cells(0).Value)
            End If
            Try
                clientesDatosBU.EditarPrioridadMensajerias(bandera, prioridad, tecid, mensajeriaid)
            Catch ex As Exception
                show_message("Error", "Algo falló en la operación")
                Exit Sub
            End Try

        Next

        show_message("Exito", "Información guardada con éxito")




        If Not IsDBNull(gridClienteRFCCEDIS.ActiveRow.Cells(7).Value) Then
            poblar_gridCEDISMensajeria(CInt(gridClienteRFCCEDIS.ActiveRow.Cells(1).Value), 0, CInt(gridClienteRFCCEDIS.ActiveRow.Cells(7).Value))
        Else
            poblar_gridCEDISMensajeria(CInt(gridClienteRFCCEDIS.ActiveRow.Cells(1).Value), CInt(gridClienteRFCCEDIS.ActiveRow.Cells(6).Value), 0)
        End If


        modoEdicion_CEDIS = False
    End Sub

    Private Sub btnEditarCEDISMensajeria_Click(sender As Object, e As EventArgs) Handles btnEditarCEDISMensajeria.Click
        modoEdicion_CEDIS = True
        asignaStatusControles(tpgCEDISMensajeria, True)
        gridCEDISMensajeria.AllowDrop = True
    End Sub

    Private Sub btnCancelarCEDISMensajeria_Click(sender As Object, e As EventArgs) Handles btnCancelarCEDISMensajeria.Click
        If Mensajes_Y_Alertas("CONFIRMACION", "Los cambios realizados no se han guardado ¿Desea cancelar los cambios?") Then
            asignaStatusControles(tpgCEDISMensajeria, False)

            Dim row As UltraGridRow = gridClienteRFCCEDIS.ActiveRow

            If row Is Nothing Then Return

            If Not IsDBNull(row.Cells(7).Value) Then
                poblar_gridCEDISMensajeria(CInt(row.Cells(1).Value), 0, CInt(row.Cells(7).Value))
            Else
                poblar_gridCEDISMensajeria(CInt(row.Cells(1).Value), CInt(row.Cells(6).Value), 0)
            End If

            gridRFCTelefono.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

            CambiarElForeColorControles_Negro(tpgCEDISMensajeria)
            CambiarElForeColorControles_DodgerBlue(pnlBotonesCEDISMensajeria)
            modoEdicion_CEDIS = False
        End If

    End Sub

    Private Sub btnGuardarCedisEmpaque_Click(sender As Object, e As EventArgs) Handles btnGuardarCEDISEmpaque.Click

        Dim clientesDatosBU As New Negocios.ClientesDatosBU

        Dim TEC As New Entidades.TiendaEmbarqueCedis
        'Dim clienteRFC As New Entidades.ClienteRFC
        Dim persona As New Entidades.Persona
        Dim clasificacionPersona As New Entidades.ClasificacionPersona
        Dim ramo As New Entidades.Ramo
        Dim tipoFlete As New Entidades.TipoFlete
        Dim tipoValor As New Entidades.TipoValor
        Dim tipoEmpaque As New Entidades.TipoEmpaque
        Dim tamanoEmpaque As New Entidades.TamanoEmpaque

        'clienteRFC.clienterfcid = cboxCEDISRFC.SelectedValue
        'TEC.clienterfc = clienteRFC

        persona.personaid = cboxCEDISCEDIS.SelectedValue
        TEC.persona = persona

        TEC.clasificacionpersona = Nothing



        If Not IsDBNull(cboxCedisTipoEmpaque.SelectedValue) Then
            tipoEmpaque.tipoempaqueid = cboxCedisTipoEmpaque.SelectedValue
            TEC.tipoempaque = tipoEmpaque
        End If

        If Not IsDBNull(cboxCedisTamanoEmpaque.SelectedValue) Then
            tamanoEmpaque.tamanoempaqueid = cboxCedisTamanoEmpaque.SelectedValue
            TEC.tamanoempaque = tamanoEmpaque
        End If




        TEC.maximoparesempaque = CInt(numCedisMaximoPares.Value)
        TEC.minimoparesempaque = CInt(numCedisMinimoPares.Value)

        If String.IsNullOrWhiteSpace(txtCedisNotasSobreEmpaque.Text) Then
            TEC.notasempaque = String.Empty
        Else
            TEC.notasempaque = txtCedisNotasSobreEmpaque.Text
        End If

        Try
            clientesDatosBU.editarCedisClienteCEDIS(TEC, Nothing, 2)
            show_message("Exito", "Información guardada con éxito")
        Catch ex As Exception
            show_message("Error", "Algo surgió mal durante el proceso de guardado")
        End Try

        asignaStatusControles(tpgCEDISEmpaque, False)
        poblar_gridClienteRFCCEDIS(CInt(lblClientePersonaID_Int.Text), gridCEDISCEDIS)
        modoEdicion_CEDIS = False

    End Sub

    Private Sub btnEditarCEDISEmpaque_Click(sender As Object, e As EventArgs) Handles btnEditarCEDISEmpaque.Click
        modoEdicion_CEDIS = True
        'empaque
        asignaStatusControles(tpgCEDISEmpaque, True)

    End Sub

    Private Sub btnCancelarCEDISEmpaque_Click(sender As Object, e As EventArgs) Handles btnCancelarCEDISEmpaque.Click
        If Mensajes_Y_Alertas("CONFIRMACION", "Los cambios realizados no se han guardado ¿Desea cancelar los cambios?") Then
            'empaque
            asignaStatusControles(tpgCEDISEmpaque, False)
            CambiarElForeColorControles_Negro(tpgCEDISEmpaque)
            CambiarElForeColorControles_DodgerBlue(pnlBotonesCEDISEmpaque)
            modoEdicion_CEDIS = False
        End If
    End Sub

    Private Sub chboxCedisPoblacion_CheckedChanged(sender As Object, e As EventArgs) Handles chboxCedisPoblacion.CheckedChanged

        If chboxCedisPoblacion.CheckState = CheckState.Checked Then
            cboxCedisPoblacion.Enabled = True
        Else
            cboxCedisPoblacion.Enabled = False
        End If

    End Sub

    Public Sub recuperar_datos_Panel_CEDIS(personaID As Integer)

        limpiarControles(pnlFormCEDIS)
        asignaStatusControles(pnlFormCEDIS, False)

        cboxCedisPoblacion.Enabled = False
        cboxCedisPoblacion.DropDownStyle = ComboBoxStyle.DropDownList
        cboxCEDISRFC.Enabled = False
        cboxCEDISRFC.DropDownStyle = ComboBoxStyle.DropDownList
        cboxCEDISCEDIS.Enabled = False
        cboxCEDISCEDIS.DropDownStyle = ComboBoxStyle.DropDownList
        'cboxCEDISDistribucionSICY.Enabled = True
        'cboxCEDISDistribucionSICY.DropDownStyle = ComboBoxStyle.DropDownList
        btnBuscarCEDIS.Enabled = True

        btnEditarCEDISPersona.Enabled = False
        btnEditarCEDISDomicilio.Enabled = False
        btnEditarCEDISEmbarque.Enabled = False
        btnEditarCEDISEmpaque.Enabled = False
        btnEditarCEDISMensajeria.Enabled = False

        'CEDIS PERSONA
        Dim ClientesDatosBU As New Negocios.ClientesDatosBU
        Dim TEC As New DataTable

        TEC = ClientesDatosBU.Datos_TablaClienteCEDIS(personaID)

        If TEC.Rows.Count > 0 Then

            lblCEDISPersonaID_Int.Text = CStr(TEC.Rows(0).Item("tiec_personaid"))

            ListaClienteRFC(cboxCEDISRFC, CInt(lblClienteSAYID_Int.Text))
            cboxCEDISRFC.SelectedValue = CInt((TEC.Rows(0).Item("tiec_clienterfcid")))

            ListaTECClienteRFC(cboxCEDISCEDIS, CInt(cboxCEDISRFC.SelectedValue))
            cboxCEDISCEDIS.SelectedValue = CInt((TEC.Rows(0).Item("tiec_personaid")))

            ListaTEC_Sicy(cboxCEDISDistribucionSICY, CInt(txtClienteSICYID.Text), 0, False)
            If Not IsDBNull((TEC.Rows(0).Item("pers_IdSICY"))) Then
                cboxCEDISDistribucionSICY.SelectedValue = CInt((TEC.Rows(0).Item("pers_IdSICY")))
            End If

            If CInt(TEC.Rows(0).Item("tiec_clasificacionpersonaid")) = 15 Then
                rbtnTipoPersonaTienda.Checked = True
                rbtnTipoPersonaEmbarque.Checked = False
                rbtnTipoPersonaCEDIS.Checked = False
            ElseIf CInt(TEC.Rows(0).Item("tiec_clasificacionpersonaid")) = 16 Then
                rbtnTipoPersonaTienda.Checked = False
                rbtnTipoPersonaEmbarque.Checked = True
                rbtnTipoPersonaCEDIS.Checked = False
            ElseIf CInt(TEC.Rows(0).Item("tiec_clasificacionpersonaid")) = 17 Then
                rbtnTipoPersonaTienda.Checked = False
                rbtnTipoPersonaEmbarque.Checked = False
                rbtnTipoPersonaCEDIS.Checked = True
            End If

            If CBool(TEC.Rows(0).Item("tiec_activo")) Then
                rbtnCedisEstatusActivo.Checked = True
                rbtnCEDISEstatusInactivo.Checked = False
            Else
                rbtnCedisEstatusActivo.Checked = False
                rbtnCEDISEstatusInactivo.Checked = True
            End If

            ''CEDIS EMBARQUE
            If IsDBNull(TEC.Rows(0).Item("tiec_reembarcar")) Then
                rbtnCEDISReembarcarSi.Checked = False
                rbtnCEDISReembarcarNo.Checked = False
            Else
                If CBool(TEC.Rows(0).Item("tiec_reembarcar")) Then
                    rbtnCEDISReembarcarSi.Checked = True
                    rbtnCEDISReembarcarNo.Checked = False
                Else
                    rbtnCEDISReembarcarSi.Checked = False
                    rbtnCEDISReembarcarNo.Checked = True
                End If
            End If


            If IsDBNull(TEC.Rows(0).Item("tiec_reembarcarporcobrar")) Then
                chboxCEDISReembarcarPorCobrar.Checked = False
            Else
                chboxCEDISReembarcarPorCobrar.Checked = CBool(TEC.Rows(0).Item("tiec_reembarcarporcobrar"))
            End If

            ListaRamos(cboxCEDISRamo)
            If IsDBNull(TEC.Rows(0).Item("tiec_ramoid")) Then
                cboxCEDISRamo.Text = String.Empty
            Else
                cboxCEDISRamo.SelectedValue = CInt((TEC.Rows(0).Item("tiec_ramoid")))
            End If

            ListaTipoTiendas(cboxCEDISTipoTienda)
            If IsDBNull(TEC.Rows(0).Item("tiec_tipotiendaid")) Then
                cboxCEDISTipoTienda.Text = String.Empty
            Else
                cboxCEDISTipoTienda.SelectedValue = CInt((TEC.Rows(0).Item("tiec_tipotiendaid")))
            End If

            If IsDBNull(TEC.Rows(0).Item("tiec_conveniotransportes")) Then
                txtCEDISConvenio.Text = String.Empty
            Else
                txtCEDISConvenio.Text = CStr((TEC.Rows(0).Item("tiec_conveniotransportes")))
            End If


            If IsDBNull(TEC.Rows(0).Item("tiec_codigotienda")) Then
                txtCodigoTienda.Text = String.Empty
            Else
                txtCodigoTienda.Text = CStr((TEC.Rows(0).Item("tiec_codigotienda")))
            End If


            If IsDBNull(TEC.Rows(0).Item("tiec_seguro")) Then
                txtCEDISSeguro.Text = String.Empty
            Else
                txtCEDISSeguro.Text = CStr(TEC.Rows(0).Item("tiec_seguro"))
            End If

            If IsDBNull(TEC.Rows(0).Item("tiec_poliza")) Then
                txtCEDISPoliza.Text = String.Empty
            Else
                txtCEDISPoliza.Text = CStr(TEC.Rows(0).Item("tiec_poliza"))
            End If

            ListaTipoValor(cboxCedisTipoValor)
            If IsDBNull(TEC.Rows(0).Item("tiec_tipovalorid")) Then
                cboxCedisTipoValor.Text = String.Empty
            Else
                cboxCedisTipoValor.SelectedValue = CInt((TEC.Rows(0).Item("tiec_tipovalorid")))
            End If

            If IsDBNull(TEC.Rows(0).Item("tiec_declararvalor")) Then
                rbtnCEDISDeclararValorSi.Checked = False
                rbtnCEDISDeclararValorNo.Checked = False
            Else
                If CBool(TEC.Rows(0).Item("tiec_declararvalor")) Then
                    rbtnCEDISDeclararValorSi.Checked = True
                    rbtnCEDISDeclararValorNo.Checked = False
                Else
                    rbtnCEDISDeclararValorSi.Checked = False
                    rbtnCEDISDeclararValorNo.Checked = True
                End If
            End If

            If IsDBNull(TEC.Rows(0).Item("tiec_declararenpesos")) Then
                rbtnCEDISDeclararValorMonto.Checked = False
                rbtnCEDISDeclararValorPorcentaje.Checked = False
            Else
                If CBool(TEC.Rows(0).Item("tiec_declararenpesos")) Then
                    rbtnCEDISDeclararValorMonto.Checked = True
                    rbtnCEDISDeclararValorPorcentaje.Checked = False
                Else
                    rbtnCEDISDeclararValorMonto.Checked = False
                    rbtnCEDISDeclararValorPorcentaje.Checked = True
                End If
            End If

            If IsDBNull(TEC.Rows(0).Item("tiec_valoradeclarar")) Then
                numCEDISValorADeclarar.Value = 0
            Else
                numCEDISValorADeclarar.Value = CInt((TEC.Rows(0).Item("tiec_valoradeclarar")))
            End If

            ListaTipoFlete(cboxCEDISTipoFlete)
            If IsDBNull(TEC.Rows(0).Item("tiec_tipofleteid")) Then
                cboxCEDISTipoFlete.Text = String.Empty
            Else
                cboxCEDISTipoFlete.SelectedValue = CInt((TEC.Rows(0).Item("tiec_tipofleteid")))
            End If

            If IsDBNull(TEC.Rows(0).Item("tiec_comentarios")) Then
                txtCEDISComentarios.Text = String.Empty
            Else
                txtCEDISComentarios.Text = CStr(TEC.Rows(0).Item("tiec_comentarios"))
            End If


            ''CEDIS EMPAQUE

            ListaTipoEmpaque(cboxCedisTipoEmpaque)
            If IsDBNull(TEC.Rows(0).Item("tiec_tipoempaqueid")) Then
                cboxCedisTipoEmpaque.Text = String.Empty
            Else
                cboxCedisTipoEmpaque.SelectedValue = CInt((TEC.Rows(0).Item("tiec_tipoempaqueid")))
            End If

            ListaTamanoEmpaque(cboxCedisTamanoEmpaque)
            If IsDBNull(TEC.Rows(0).Item("tiec_tamanoempaqueid")) Then
                cboxCedisTamanoEmpaque.Text = String.Empty
            Else
                cboxCedisTamanoEmpaque.SelectedValue = CInt((TEC.Rows(0).Item("tiec_tamanoempaqueid")))
            End If

            If IsDBNull(TEC.Rows(0).Item("tiec_valoradeclarar")) Then
                numCEDISValorADeclarar.Value = 0
            Else
                numCEDISValorADeclarar.Value = CInt((TEC.Rows(0).Item("tiec_valoradeclarar")))
            End If

            If IsDBNull(TEC.Rows(0).Item("tiec_maximoparesempaque")) Then
                numCedisMaximoPares.Value = 0
            Else
                numCedisMaximoPares.Value = CInt((TEC.Rows(0).Item("tiec_maximoparesempaque")))
            End If

            If IsDBNull(TEC.Rows(0).Item("tiec_minimoparesempaque")) Then
                numCedisMinimoPares.Value = 0
            Else
                numCedisMinimoPares.Value = CInt((TEC.Rows(0).Item("tiec_minimoparesempaque")))
            End If

            If IsDBNull(TEC.Rows(0).Item("tiec_notasempaque")) Then
                txtCedisNotasSobreEmpaque.Text = String.Empty
            Else
                txtCedisNotasSobreEmpaque.Text = CStr((TEC.Rows(0).Item("tiec_notasempaque")))
            End If

        End If


        'CEDIS DOMICILIO

        Dim domicilio As New DataTable
        Dim DomicilioBU As New Framework.Negocios.DomicilioBU
        domicilio = DomicilioBU.Datos_TablaDomicilioPersona(personaID)

        If domicilio.Rows.Count > 0 Then

            txtCEDISCalle.Text = CStr(domicilio.Rows(0).Item("domi_calle"))
            If IsDBNull(domicilio.Rows(0).Item("domi_numinterior")) Then
                txtCEDISNumeroExterior.Text = String.Empty
            Else
                txtCEDISNumeroInterior.Text = CStr(domicilio.Rows(0).Item("domi_numinterior"))
            End If

            txtCEDISNumeroExterior.Text = CStr(domicilio.Rows(0).Item("domi_numexterior"))
            txtCEDISColonia.Text = CStr(domicilio.Rows(0).Item("domi_colonia"))
            cboxCEDISPais.Text = CStr(domicilio.Rows(0).Item("pais_nombre"))

            ListaPais(cboxCEDISPais)
            cboxCEDISPais.SelectedValue = CInt(domicilio.Rows(0).Item("pais_paisid"))

            ListaEstado(cboxCEDISEstado, CInt(cboxCEDISPais.SelectedValue))
            cboxCEDISEstado.SelectedValue = CInt(domicilio.Rows(0).Item("esta_estadoid"))

            ListaCiudad(cboxCEDISCiudad, CInt(cboxCEDISEstado.SelectedValue))
            cboxCEDISCiudad.SelectedValue = CInt(domicilio.Rows(0).Item("city_ciudadid"))

            If IsDBNull(domicilio.Rows(0).Item("domi_cp")) Then
                numCedisCodigoPostal.Text = String.Empty
            Else
                numCedisCodigoPostal.Text = CStr(domicilio.Rows(0).Item("domi_cp"))
            End If

            ListaPoblacion(cboxCedisPoblacion, CInt(cboxCEDISCiudad.SelectedValue))
            If IsDBNull(domicilio.Rows(0).Item("pobl_nombre")) Then
                cboxCedisPoblacion.Text = String.Empty
                chboxCedisPoblacion.Checked = False
                cboxCedisPoblacion.Enabled = False
            Else
                Poblacion = CInt(domicilio.Rows(0).Item("pobl_poblacionid"))
                cboxCedisPoblacion.SelectedValue = CInt(domicilio.Rows(0).Item("pobl_poblacionid"))
                chboxCedisPoblacion.Checked = True
                cboxCedisPoblacion.Enabled = True
            End If

            If IsDBNull(domicilio.Rows(0).Item("domi_delegacion")) Then
                txtCEDISCiudadSicy.Text = String.Empty
            Else
                txtCEDISCiudadSicy.Text = CStr(domicilio.Rows(0).Item("domi_delegacion"))
            End If

        End If

        'If Not Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
        '    If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
        '        btnEditarCEDISPersona.Enabled = False
        '    Else
        '        If CInt(lblCEDISPersonaID_Int.Text) = 0 Then
        '            btnEditarCEDISPersona.Enabled = False
        '        Else
        '            btnEditarCEDISPersona.Enabled = True
        '        End If
        '    End If
        'End If

        cboxCedisPoblacion.Enabled = False

        If rbtnClienteStatusInactivo.Checked Then
            btnEditarCEDISPersona.Enabled = False
        Else
            If CInt(lblCEDISPersonaID_Int.Text) = 0 Then
                btnEditarCEDISPersona.Enabled = False
                If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
                    btnTEC_AgregarTEC.Enabled = True
                ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Or Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARTIENDASEMBCEDIS") Then
                    btnTEC_AgregarTEC.Enabled = True
                Else
                    btnTEC_AgregarTEC.Enabled = False
                End If
            Else
                If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
                    btnEditarCEDISPersona.Enabled = True
                    btnEditarCEDISDomicilio.Enabled = True
                    btnEditarCEDISEmbarque.Enabled = True
                    btnEditarCEDISEmpaque.Enabled = True
                    btnEditarCEDISMensajeria.Enabled = True
                    btnTEC_AgregarTEC.Enabled = True
                Else
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Or Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARTIENDASEMBCEDIS") Then
                        btnEditarCEDISPersona.Enabled = True
                        btnEditarCEDISDomicilio.Enabled = True
                        btnEditarCEDISEmbarque.Enabled = True
                        btnEditarCEDISEmpaque.Enabled = True
                        btnEditarCEDISMensajeria.Enabled = True
                        btnTEC_AgregarTEC.Enabled = True
                    Else
                        btnEditarCEDISPersona.Enabled = False
                        btnEditarCEDISDomicilio.Enabled = False
                        btnEditarCEDISEmbarque.Enabled = False
                        btnEditarCEDISEmpaque.Enabled = False
                        btnEditarCEDISMensajeria.Enabled = False
                        btnTEC_AgregarTEC.Enabled = False
                    End If
                End If
            End If
        End If



    End Sub

    Private Sub tabControlPanelCEDIS_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles tabControlPanelCEDIS.Selecting
        If modoEdicion_CEDIS = True Then
            Mensajes_Y_Alertas("ADVERTENCIA", "Guarde o cancele los cambios para poder ver el resto de las opciones.")
            e.Cancel = True
        End If
    End Sub

    Private Sub btnTEC_AgregarTEC_Click(sender As Object, e As EventArgs) Handles btnTEC_AgregarTEC.Click
        If modoEdicion_CEDIS Then
            Mensajes_Y_Alertas("ADVERTENCIA", "Guarde o cancele los cambios realizados antes de intentar agregar un nuevo CEDIS.")
        Else
            modoEdicion_CEDIS = True

            limpiarControles(pnlCEDIS)
            asignaStatusControles(pnlCEDIS, True)
            lblCEDISPersonaID_Int.Text = 0
            cboxCEDISCEDIS.DropDownStyle = ComboBoxStyle.Simple
            cboxCEDISCEDIS.Text = String.Empty
            rbtnCedisEstatusActivo.Checked = True
            asignaStatusControles(tpgCEDISDomicilio, False)
            asignaStatusControles(tpgCEDISEmbarque, False)
            asignaStatusControles(tpgCEDISEmpaque, False)

            ListaPais(cboxCEDISPais)
            ListaEstado(cboxCEDISEstado, cboxCEDISPais.SelectedValue)
            ListaTEC_Sicy(cboxCEDISDistribucionSICY, CInt(txtClienteSICYID.Text), 0, True)

            btnBuscarCEDIS.Enabled = False
            btnEditarCEDISDomicilio.Enabled = False
            btnEditarCEDISEmbarque.Enabled = False
            btnEditarCEDISEmpaque.Enabled = False
        End If
    End Sub

#Region "GRID CEDIS_MENSAJERIA"

    'MENSAJERIAS
    Public Sub poblar_gridCEDISMensajeria(cedisID As Integer, ciudadID As Integer, poblacionID As Integer)

        gridCEDISMensajeria.DataSource = Nothing

        Dim objBU As New Negocios.ClientesDatosBU
        Dim mensajeria As New DataTable

        mensajeria = objBU.Datos_ClienteRFCCEDIS_Mensajeria(cedisID, ciudadID, poblacionID)

        gridCEDISMensajeria.DataSource = mensajeria

        gridCEDISMensajeriaDiseno(gridCEDISMensajeria)


        Dim l As Integer = 0
        For Each row As UltraGridRow In gridCEDISMensajeria.Rows
            If LTrim(RTrim(row.Cells("tecm_prioridad").Text)) <> "" Then
                l += 1
            End If
        Next

        If l > 0 Then
            lblTEC_MensajePrioridades.Visible = False
        Else
            lblTEC_MensajePrioridades.Visible = True
        End If
    End Sub

    Private Sub gridCEDISMensajeriaDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Bands(0).Columns(5).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(6).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(7).Hidden = True

        grid.DisplayLayout.Bands(0).Columns(0).Header.Caption = "PRIORIDAD"
        grid.DisplayLayout.Bands(0).Columns(1).Header.Caption = "PROVEEDOR"
        grid.DisplayLayout.Bands(0).Columns(2).Header.Caption = "UNIDAD"
        grid.DisplayLayout.Bands(0).Columns(3).Header.Caption = "COSTO"
        grid.DisplayLayout.Bands(0).Columns(4).Header.Caption = "REEMBARQUE"
        grid.DisplayLayout.Bands(0).Columns(8).Header.Caption = "ACTIVO"

        grid.DisplayLayout.Bands(0).Columns(3).Format = "N2"
        grid.DisplayLayout.Bands(0).Columns(3).MaskInput = "nnn,nnn,nnn.nn"


        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No


    End Sub

    Private Sub gridCEDISMensajeria_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridCEDISMensajeria.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub gridCEDISMensajeria_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridCEDISMensajeria.DoubleClickHeader

        If Me.gridCEDISMensajeria.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.gridCEDISMensajeria.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.gridCEDISMensajeria.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.gridCEDISMensajeria.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.gridCEDISMensajeria.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.gridCEDISMensajeria.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.gridCEDISMensajeria.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If

    End Sub

    Private Sub gridCEDISMensajeria_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridCEDISMensajeria.SelectionDrag

        'If Not Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
        '   If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
        '        gridCEDISMensajeria.DoDragDrop(gridCEDISMensajeria.Selected.Rows, DragDropEffects.Move)
        '    End If
        'End If

        If Not Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Or Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARTIENDASEMBCEDIS") Then
                gridCEDISMensajeria.DoDragDrop(gridCEDISMensajeria.Selected.Rows, DragDropEffects.Move)
            End If
        Else
            gridCEDISMensajeria.DoDragDrop(gridCEDISMensajeria.Selected.Rows, DragDropEffects.Move)
        End If

    End Sub

    Private Sub gridCEDISMensajeria_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles gridCEDISMensajeria.DragOver
        e.Effect = DragDropEffects.Move
        Dim grid As UltraGrid = TryCast(sender, UltraGrid)
        Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

        If pointInGridCoords.Y < 20 Then
            'Scroll up
            Me.gridCEDISMensajeria.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
        ElseIf pointInGridCoords.Y > grid.Height - 20 Then
            'Scroll down
            Me.gridCEDISMensajeria.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
        End If
    End Sub

    Private Sub gridCEDISMensajeria_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles gridCEDISMensajeria.DragDrop
        Dim dropIndex As Integer

        'Get the position on the grid where the dragged row(s) are to be dropped. 
        'get the grid coordinates of the row (the drop zone) 
        Dim uieOver As UIElement = gridCEDISMensajeria.DisplayLayout.UIElement.ElementFromPoint(gridCEDISMensajeria.PointToClient(New Point(e.X, e.Y)))

        'get the row that is the drop zone/or where the dragged row is to be dropped 
        Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

        If ugrOver IsNot Nothing Then
            dropIndex = ugrOver.Index    'index/position of drop zone in grid 

            'get the dragged row(s)which are to be dragged to another position in the grid 
            Dim SelRows As SelectedRowsCollection = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)
            'get the count of selected rows and drop each starting at the dropIndex 
            For Each aRow As UltraGridRow In SelRows
                'move the selected row(s) to the drop zone 
                gridCEDISMensajeria.Rows.Move(aRow, dropIndex)
            Next
            For Each fila As UltraGridRow In gridCEDISMensajeria.Rows

                fila.Cells(0).Value = fila.Index + 1

            Next

        End If
    End Sub

    Private Sub gridCEDISMensajeria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridCEDISMensajeria.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then

            Dim NextRowIndex As Integer = gridCEDISMensajeria.ActiveRow.Index + 1
            Try
                gridCEDISMensajeria.DisplayLayout.Rows(NextRowIndex).Activated = True
                gridCEDISMensajeria.DisplayLayout.Rows(NextRowIndex).Selected = True
            Catch ex As Exception
                gridCEDISMensajeria.ActiveRow.Activated = False
            End Try

        End If

        If e.KeyChar = ChrW(Keys.Escape) Then
            gridCEDISMensajeria.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        End If

    End Sub

    Private Sub gridCEDISMensajeria_MouseClick(sender As Object, e As MouseEventArgs) Handles gridCEDISMensajeria.MouseClick

        If rbtnClienteStatusInactivo.Checked Then Return



        Dim mainElement As UIElement
        Dim element As UIElement
        Dim screenPoint As Point
        Dim clientPoint As Point
        Dim row As UltraGridRow
        Dim cell As UltraGridCell

        mainElement = Me.gridCEDISMensajeria.DisplayLayout.UIElement
        screenPoint = Control.MousePosition
        clientPoint = Me.gridCEDISMensajeria.PointToClient(screenPoint)
        element = mainElement.ElementFromPoint(clientPoint)

        If element Is Nothing Then Return

        row = element.GetContext(GetType(UltraGridRow))

        If Not row Is Nothing Then
            cell = element.GetContext(GetType(UltraGridCell))

            If Not cell Is Nothing Then

                If e.Button <> Windows.Forms.MouseButtons.Right Then Return

                If lblTEC_MensajePrioridades.Visible = True Then Return

                Dim cms = New ContextMenuStrip
                Dim item1 = cms.Items.Add("Retirar prioridad")
                item1.Tag = 1
                AddHandler item1.Click, AddressOf gridCEDISMensajeria_menuChoice

                If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
                    cms.Show(Control.MousePosition)
                Else
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Or Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARTIENDASEMBCEDIS") Then
                        cms.Show(Control.MousePosition)
                    End If
                End If

            End If
        End If

    End Sub

    Private Sub gridCEDISMensajeria_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        Dim grid As DataTable = gridCEDISMensajeria.DataSource
        Dim row As UltraGridRow = gridCEDISMensajeria.ActiveRow
        Dim objClientesDatosBU As New Negocios.ClientesDatosBU

        If selection = 1 Then
            Try
                objClientesDatosBU.Desasignar_Prioridad_CedisMensajeria(CInt(lblTECPersonaID_Int.Text))
                Mensajes_Y_Alertas("EXITO", "Las prioridad de mensajeria ha sido desasignada con exito")
                If Not IsDBNull(gridClienteRFCCEDIS.ActiveRow.Cells(7).Value) Then
                    poblar_gridCEDISMensajeria(CInt(gridClienteRFCCEDIS.ActiveRow.Cells(1).Value), 0, CInt(gridClienteRFCCEDIS.ActiveRow.Cells(7).Value))
                Else
                    poblar_gridCEDISMensajeria(CInt(gridClienteRFCCEDIS.ActiveRow.Cells(1).Value), CInt(gridClienteRFCCEDIS.ActiveRow.Cells(6).Value), 0)
                End If
            Catch ex As Exception
                Mensajes_Y_Alertas("ERROR", "Ocurrio un error inesperado. Error: " + ex.Message)
            End Try
        End If
    End Sub

    Private Sub gridCEDISMensajeria_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridCEDISMensajeria.BeforeExitEditMode
        Try
            Dim cellIndex As Integer = gridCEDISMensajeria.ActiveCell.Column.Index

            If gridCEDISMensajeria.ActiveRow.DataChanged Then

            Else
                If gridCEDISMensajeria.ActiveCell.DataChanged Then
                Else
                    If String.IsNullOrWhiteSpace(gridCEDISMensajeria.ActiveCell.Value) Then
                        gridCEDISMensajeria.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                    End If
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gridCEDISMensajeria_AfterRowActivate(sender As Object, e As EventArgs) Handles gridCEDISMensajeria.AfterRowActivate
        gridCEDISMensajeria.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        For Each row In gridCEDISMensajeria.Rows
            row.Activation = Activation.NoEdit
        Next
    End Sub

    Private Sub gridCEDISMensajeria_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridCEDISMensajeria.BeforeRowDeactivate

        If gridCEDISMensajeria.ActiveRow.DataChanged Then
            Dim row As UltraGridRow = gridCEDISMensajeria.ActiveRow
        Else

        End If

        gridCEDISMensajeria.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

    End Sub


#End Region
    Public Sub poblar_gridMKTRamosTEC(clienteID As Integer)
        Dim clientesBU As New Negocios.ClientesDatosBU
        Dim ramo As New DataTable
        Dim cliente As New Entidades.Cliente

        gridMKTRTEC.DataSource = Nothing
        cliente.clienteid = CInt(lblClienteSAYID_Int.Text)
        ramo = clientesBU.Datos_TablaRamoCliente(cliente.clienteid, AreaOperativa, Editando_Mercadotecnia)
        gridMKTRTEC.DataSource = ramo
        gridMKTRamosDiseno(gridMKTRTEC)

        If gridMKTRTEC.Rows.Count > 0 Then
            gridMKTRTEC.Rows(0).Activated = True
        End If
    End Sub

    Private Sub btnEditarMKTTECR_Click(sender As Object, e As EventArgs) Handles btnEditarMKTTECR.Click
        ModoEdicion_MercaDotecnia = True
        panelTECRamos.Enabled = True
        btnEditarMKTTECR.Enabled = True

        'asignaStatusControles(pnlFormMKT, True)
        'btnGaleriaPanelMKT.Enabled = True

        'Activar_Inactivar_grids(gridMKTContacto, ModoEdicion_MercaDotecnia)
        'Activar_Inactivar_grids(gridMKTZapaterias, ModoEdicion_MercaDotecnia)
        'Activar_Inactivar_grids(gridMKTMaterialMKT, ModoEdicion_MercaDotecnia)
        'Activar_Inactivar_grids(gridMKTTienda, False)
        Activar_Inactivar_grids(gridMKTRTEC, False)
    End Sub
    'btnEditarRamosTEC
    'btnMKT_EditarRamos
    'IniciarEdicion_RamosTEC()
    'btnMKT_EditarRamos.Enabled = False
    Private Sub btnEditarRamosTEC_Click(sender As Object, e As EventArgs) Handles btnEditarMKTTECR.Click
        IniciarEdicion_RamosTEC()
        btnMKT_EditarRamos.Enabled = False
        btnGuardarRamosTEC.Enabled = True
        btnCancelarRamosTEC.Enabled = True
        btnEditarMKTTECR.Enabled = False
        'Activar_Inactivar_grids(gridMKTRTEC, True)
    End Sub

    Private Sub IniciarEdicion_RamosTEC()
        Editando_Mercadotecnia = True
        Dim cliente As New Entidades.Cliente
        cliente.clienteid = CInt(lblClienteSAYID_Int.Text)
        'poblar_gridMKTRamosTEC(CInt(lblClienteSAYID_Int.Text))
        poblar_gridMKTRamosTEC(cliente.clienteid)
    End Sub

    Private Sub btnCancelarRamosTEC_Click(sender As Object, e As EventArgs) Handles btnCancelarRamosTEC.Click
        If Mensajes_Y_Alertas("CONFIRMACION", "Los cambios realizados no se han guardado ¿Desea cancelar los cambios?") Then
            ModoEdicion_MercaDotecnia = False
            btnMKT_EditarRamos.Enabled = False
            btnEditarMKTTECR.Enabled = False
            btnGuardarRamosTEC.Enabled = False
            btnCancelarRamosTEC.Enabled = False
            btnEditarMKTTECR.Enabled = True

            recuperar_datos_Panel_MKT(CInt(lblClienteSAYID_Int.Text))
            CambiarElForeColorControles_Negro(pnlFormMKT)
            CambiarElForeColorControles_DodgerBlue(pnlBotonesMKT)
            CambiarElForeColorControles_DodgerBlue(pnlMKT_ZapateriasCiudad)

            'Activar_Inactivar_grids(gridMKTContacto, ModoEdicion_MercaDotecnia)
            'Activar_Inactivar_grids(gridMKTZapaterias, ModoEdicion_MercaDotecnia)
            'Activar_Inactivar_grids(gridMKTMaterialMKT, ModoEdicion_MercaDotecnia)
            'Activar_Inactivar_grids(gridMKTTienda, False)
            Activar_Inactivar_grids(gridMKTRamos, False)

            Editando_Mercadotecnia = False
            poblar_gridMKTRamosTEC(CInt(cboxClienteCliente.SelectedValue))
            'poblar_gridMKTTienda(CInt(cboxClienteCliente.SelectedValue))
        End If


    End Sub

    Private Sub btnGuardarRamosTEC_Click(sender As Object, e As EventArgs) Handles btnGuardarRamosTEC.Click
        Editando_Mercadotecnia = False

        gridMKTRTEC.ActiveRow.Update()

        For Each row As UltraGridRow In gridMKTRTEC.Rows
            Dim ramo As New Entidades.ClienteRamo
            Dim tipoRamo As New Entidades.Ramo
            Dim cliente As New Entidades.Cliente
            Dim objBu As New Negocios.ClientesDatosBU

            tipoRamo.ramoid = row.Cells(1).Value
            ramo.ramo = tipoRamo
            cliente.clienteid = CInt(row.Cells(0).Value)
            ramo.cliente = cliente
            ramo.numtiendasreal = CInt(row.Cells(4).Value)
            ramo.marcaje = CInt(row.Cells(5).Value)

            Try
                objBu.EditarRamoCliente(ramo)
            Catch ex As Exception

            End Try
        Next

        show_message("Exito", "Información guardada con éxito")
        ModoEdicion_MercaDotecnia = False
        Activar_Inactivar_grids(gridMKTRTEC, False)

        poblar_gridMKTRamosTEC(CInt(cboxClienteCliente.SelectedValue))

        btnEditarMKTTECR.Enabled = True
        btnGuardarRamosTEC.Enabled = False
        btnCancelarRamosTEC.Enabled = False

    End Sub

End Class
