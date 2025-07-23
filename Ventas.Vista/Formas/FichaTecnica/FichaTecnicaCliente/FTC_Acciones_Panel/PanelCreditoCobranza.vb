Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools.Controles
Imports Tools

Partial Public Class FichaTecnicaClienteForm


#Region "POLITICA DE PAGOS"
    ''POLITICA DE PAGOS
    Private Sub btnGuardarPanelCobranzaPoliticaPagos_Click(sender As Object, e As EventArgs) Handles btnGuardarCobranzaPoliticaPagos.Click

        Dim cliente As New Entidades.Cliente
        Dim politicaPago As New Entidades.PoliticaPago
        Dim cobranza As New Negocios.PoliticaPagoBU
        Dim formaPago As New Entidades.FormaPago

        cliente.clienteid = CInt(lblClienteSAYID_Int.Text)
        politicaPago.cliente = cliente

        If IsDBNull(cboxCobranzaFormaPago_Old.SelectedValue) Or IsNothing(cboxCobranzaFormaPago_Old.SelectedValue) Then

        Else
            formaPago.formapagoid = cboxCobranzaFormaPago_Old.SelectedValue
            politicaPago.formapago = formaPago
        End If

        politicaPago.plazoreal = numCobranzaPlazoRealDias.Value

        If txtCobranzaNotasCobranza.TextLength < 1 Then
            politicaPago.notascobranza = String.Empty
        Else
            politicaPago.notascobranza = txtCobranzaNotasCobranza.Text
        End If

        If txtCobranzaNotasDevoluciones.TextLength < 1 Then
            politicaPago.notasdevoluciones = String.Empty
        Else
            politicaPago.notasdevoluciones = txtCobranzaNotasDevoluciones.Text
        End If

        politicaPago.proporcionarcuentaremision = chkCobranzaProporcionarCuentaBancariaRemisiones.Checked

        Try
            cobranza.editarPoliticaPago(politicaPago, 1)
            show_message("Exito", "Información guardada con éxito")
        Catch ex As Exception
            show_message("Error", "Algo surgió mal durante el proceso de guardado")
        End Try

        ModoEdicion_CreditoConbranza = False

        recuperar_datos_Panel_Cobranza(CInt(lblClienteSAYID_Int.Text))
        RecuperarInfo_MetodoFormaPago_NotaCredito(CInt(lblClienteSAYID_Int.Text))

        Activar_Inactivar_grids(gridHorario, ModoEdicion_CreditoConbranza)
        Activar_Inactivar_grids(gridDocumentos, ModoEdicion_CreditoConbranza)
        Activar_Inactivar_grids(gridCobranzaFormasPago, ModoEdicion_CreditoConbranza)

        CambiarElForeColorControles_Negro(tpgCobranzaPoliticaPago)
        CambiarElForeColorControles_DodgerBlue(pnlBotonesCobranzaPoliticaPago)
    End Sub

    Private Sub btnEditarPanelCobranzaPoliticaPagos_Click(sender As Object, e As EventArgs) Handles btnEditarCobranzaPoliticaPagos.Click
        ModoEdicion_CreditoConbranza = True

        asignaStatusControles(tpgCobranzaPoliticaPago, True)
        numCobranzaPlazoRealDias.Enabled = False

        Activar_Inactivar_grids(gridHorario, ModoEdicion_CreditoConbranza)
        Activar_Inactivar_grids(gridDocumentos, ModoEdicion_CreditoConbranza)
        Activar_Inactivar_grids(gridCobranzaFormasPago, ModoEdicion_CreditoConbranza)

    End Sub

    Private Sub btnCancelarPanelCobranzaPoliticaPagos_Click(sender As Object, e As EventArgs) Handles btnCancelarCobranzaPoliticaPagos.Click
        If Mensajes_Y_Alertas("CONFIRMACION", "Los cambios realizados no se han guardado ¿Desea cancelar los cambios?") Then
            ModoEdicion_CreditoConbranza = False
            recuperar_datos_Panel_Cobranza(CInt(lblClienteSAYID_Int.Text))
            Activar_Inactivar_grids(gridHorario, ModoEdicion_CreditoConbranza)
            Activar_Inactivar_grids(gridDocumentos, ModoEdicion_CreditoConbranza)
            Activar_Inactivar_grids(gridCobranzaFormasPago, ModoEdicion_CreditoConbranza)
            CambiarElForeColorControles_Negro(tpgCobranzaPoliticaPago)
            CambiarElForeColorControles_DodgerBlue(pnlBotonesCobranzaPoliticaPago)
        End If

    End Sub


#Region "PAGOS Y CONTRARECIBOS"
    ''AGREGA UN NUEVO REGISTRO AL GRID DE PAGOS Y COTNRARECIBOS
    Private Sub btnCC_AgregarPagos_Y_ContraRecibos_Click(sender As Object, e As EventArgs) Handles btnCC_AgregarPagos_Y_ContraRecibos.Click
        Dim grid As DataTable = gridHorario.DataSource
        Dim row As UltraGridRow = gridHorario.ActiveRow

        gridHorario.Focus()
        LimpiarFiltrosGrid(gridHorario)

        grid.Rows.Add(0, "--Selecciona--", 0, "--Selecciona--", 0, String.Empty, CInt(lblClienteSAYID_Int.Text), 1)

        gridHorario.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True
        Try
            gridHorario.ActiveRow.Activation = Activation.AllowEdit
            gridHorario.ActiveCell = gridHorario.ActiveRow.Cells(1)
            gridHorario.ActiveCell.Activation = Activation.AllowEdit
        Catch ex As Exception

        End Try

        gridHorario.PerformAction(UltraGridAction.ToggleCellSel, False, False)
        gridHorario.PerformAction(UltraGridAction.EnterEditMode, False, False)

    End Sub

    Private Sub tabControlPanelCobranza_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles tabControlPanelCobranza.Selecting
        If ModoEdicion_CreditoConbranza = True Then
            Mensajes_Y_Alertas("ADVERTENCIA", "Guarde o cancele los cambios para poder ver el resto de las opciones.")
            e.Cancel = True
        End If
    End Sub

#End Region

#Region "DOCUMENTACION"
    Private Sub btnCC_AgregarDocumento_Click(sender As Object, e As EventArgs) Handles btnCC_AgregarDocumento.Click
        Dim grid As DataTable = gridDocumentos.DataSource
        Dim tipoDocumento As UltraGridColumn = gridDocumentos.DisplayLayout.Bands(0).Columns(3)

        gridDocumentos.Focus()
        LimpiarFiltrosGrid(gridDocumentos)

        grid.Rows.Add(0, 0, "--Selecciona--", 0, CInt(lblClienteSAYID_Int.Text), 0, 0, True)

        gridDocumentos.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True
        'gridDocumentos.DisplayLayout.Rows(grid.Rows.Count - 1).Selected = True

        Try
            gridDocumentos.ActiveRow.Activation = Activation.AllowEdit
            gridDocumentos.ActiveCell = gridDocumentos.ActiveRow.Cells("ACTIVO")
            gridDocumentos.ActiveCell.Selected = True

            gridDocumentos.ActiveCell.Activation = Activation.AllowEdit
        Catch ex As Exception

        End Try

        gridDocumentos.PerformAction(UltraGridAction.ToggleCellSel, False, False)
        gridDocumentos.PerformAction(UltraGridAction.EnterEditMode, False, False)
    End Sub
#End Region

#Region "FORMAS PAGO"

    Private Sub btnCC_AgregarMetodoPago_Click(sender As Object, e As EventArgs) Handles btnCC_AgregarMetodoPago.Click
        Dim grid As DataTable = gridCobranzaFormasPago.DataSource
        Dim row As UltraGridRow = gridCobranzaFormasPago.ActiveRow
        Dim MetodoPago As UltraGridColumn = gridCobranzaFormasPago.DisplayLayout.Bands(0).Columns(2)

        gridCobranzaFormasPago.Focus()
        LimpiarFiltrosGrid(gridCobranzaFormasPago)

        grid.Rows.Add(0, 0, "--Selecciona--", True)

        gridCobranzaFormasPago.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True
        Try
            gridCobranzaFormasPago.ActiveRow.Activation = Activation.AllowEdit
            gridCobranzaFormasPago.ActiveCell = gridCobranzaFormasPago.ActiveRow.Cells(2)
            gridCobranzaFormasPago.ActiveCell.Activation = Activation.AllowEdit
        Catch ex As Exception

        End Try
        gridCobranzaFormasPago.PerformAction(UltraGridAction.ToggleCellSel, False, False)
        gridCobranzaFormasPago.PerformAction(UltraGridAction.EnterEditMode, False, False)
    End Sub

#End Region
#End Region

#Region "CONTABILIDAD"
    ''CONTABILIDADAD
    Private Sub btnGuardarPanelCobranzaContabilidad_Click(sender As Object, e As EventArgs) Handles btnGuardarCobranzaContabilidad.Click
        Dim persona As New Entidades.Persona
        Dim cliente As New Entidades.Cliente
        Dim metodoPago As New Entidades.MetodoPago
        Dim formaPago As New Entidades.FormaPago
        Dim clienteRFC As New Entidades.ClienteRFC
        Dim politicaPago As New Entidades.PoliticaPago
        Dim cobranza As New Negocios.PoliticaPagoBU
        Dim ClientesDatosBU As New Negocios.ClientesDatosBU
        Dim validarCuenta As New Integer

        persona.personaid = CInt(lblContabilidadRFCPersonaID_Int.Text)
        cliente.clienteid = CInt(lblClienteSAYID_Int.Text)
        politicaPago.cliente = cliente
        clienteRFC.persona = persona
        clienteRFC.parcialidades1 = numCobranzaParcialidades1.Value
        clienteRFC.parcialidadesx = numCobranzaParcialidadesX.Value

        If Not IsDBNull(cboxCobranzaFormaPago.SelectedValue) Then
            formaPago.formapagoid = cboxCobranzaFormaPago.SelectedValue
        End If
        clienteRFC.formapago = formaPago

        If Not IsDBNull(cboxCobranzaMetodoPago.SelectedValue) Then
            metodoPago.metodopagoid = cboxCobranzaMetodoPago.SelectedValue
        End If
        'clienteRFC.metodopago = metodoPago
        politicaPago.metodopago = metodoPago

        If numCobranzaCuenta.Text <> String.Empty Then
            Try
                validarCuenta = CInt(numCobranzaCuenta.Text)

                If String.IsNullOrWhiteSpace(numCobranzaCuenta.Text) Then
                    clienteRFC.cuenta = Nothing
                Else
                    clienteRFC.cuenta = numCobranzaCuenta.Text
                End If
            Catch ex As Exception
                show_message("Advertencia", "Debes insertar sólo números en el campo Cuenta.")
                numCobranzaCuenta.Text = String.Empty
                Exit Sub
            End Try
        End If

        Try
            cobranza.editarPoliticaPago(politicaPago, 2)

        Catch ex As Exception
            show_message("Error", "Algo surgió mal durante el proceso de guardado")
        End Try

        Try
            If Not editar_Cobranza_Cliente_ClienteRFC() Then
                Exit Sub
            End If
            ClientesDatosBU.editarClienteClienteRFC(clienteRFC, Nothing, 3)

            show_message("Exito", "Información guardada con éxito")
            recuperar_datos_Panel_Cobranza_Contabilidad(CInt(lblContabilidadRFCPersonaID_Int.Text))
            recuperar_datos_Panel_Cobranza_EvalInfoCredito(CInt(lblContabilidadRFCPersonaID_Int.Text))
            RecuperarInfo_MetodoFormaPago_NotaCredito(CInt(lblClienteSAYID_Int.Text))
        Catch ex As Exception
            show_message("Error", "Algo surgió mal durante el proceso de guardado")
        End Try

        ModoEdicion_CreditoConbranza = False

        CambiarElForeColorControles_Negro(tpgCobranzaContabilidad)
        CambiarElForeColorControles_DodgerBlue(pnlBotonesCobranzaContabilidad)
    End Sub

    Private Sub btnEditarPanelCobranzaContabilidad_Click(sender As Object, e As EventArgs) Handles btnEditarCobranzaContabilidad.Click

        ModoEdicion_CreditoConbranza = True

        asignaStatusControles(tpgCobranzaContabilidad, True)

        'If CInt(lblRFCPersonaID.Text) = 0 Then
        '    pnlRFCTipoRFC.Enabled = True
        '    pnlRFCTipoPersona.Enabled = True
        '    cboxRFCRFCAFacturar.Enabled = True
        'Else
        '    pnlRFCTipoRFC.Enabled = False
        '    pnlRFCTipoPersona.Enabled = False
        '    cboxRFCRFCAFacturar.Enabled = False
        'End If

    End Sub

    Private Sub btnCancelarPanelCobranzaContabilidad_Click(sender As Object, e As EventArgs) Handles btnCancelarCobranzaContabilidad.Click
        If Mensajes_Y_Alertas("CONFIRMACION", "Los cambios realizados no se han guardado ¿Desea cancelar los cambios?") Then
            ModoEdicion_CreditoConbranza = False
            recuperar_datos_Panel_Cobranza_Contabilidad(CInt(lblContabilidadRFCPersonaID_Int.Text))
            CambiarElForeColorControles_Negro(tpgCobranzaContabilidad)
            CambiarElForeColorControles_DodgerBlue(pnlBotonesCobranzaContabilidad)
        End If
    End Sub




#End Region

#Region "EVALUACION TECNICA"
    ''EVALUACION TECNICA
    Private Sub btnGuardarPanelCobranzaEvaluacionTecnica_Click(sender As Object, e As EventArgs) Handles btnGuardarCobranzaEvaluacionTecnica.Click

        Dim cliente As New Entidades.Cliente
        Dim infoClienteVentas As New Entidades.InformacionClienteVentas
        Dim infoClienteCobranza As New Entidades.InformacionClienteCobranza
        Dim clientesDatos As New Negocios.ClientesDatosBU
        Dim clientes As New Negocios.ClientesBU

        cliente.clienteid = (CInt(lblClienteSAYID_Int.Text))
        infoClienteVentas.cliente = cliente
        infoClienteCobranza.cliente = cliente

        infoClienteVentas.contactoinicial = CBool(chboxCobranzaContactoInicial.CheckState)
        infoClienteVentas.buscamoscliente = CBool(chboxCobranzaBuscamosCliente.CheckState)
        infoClienteVentas.tienepedidoinicial = CBool(chboxCobranzaTienePedidoInicial.CheckState)
        infoClienteVentas.articulospedidoinicial = txtCobranzaCantidadArticulosAVender.Text


        If dateCobranzaFechaDeEntrega.Value = DateTimePicker.MinimumDateTime Then
            infoClienteVentas.fechaentregapedidoinicial = Date.Now
        Else
            infoClienteVentas.fechaentregapedidoinicial = Date.Parse(dateCobranzaFechaDeEntrega.Value)
        End If

        infoClienteVentas.parespedidoinicial = numCobranzaPares.Value

        'If numCobranzaPlazoDias.Value = Decimal.Zero Then
        '    show_message("Advertencia", "Falta información")
        '    lblCobranzaPlazoDias.ForeColor = Color.Red
        '    Exit Sub
        'Else
        '    infoClienteCobranza.plazo = numCobranzaPlazoDias.Value
        '    lblCobranzaPlazoDias.ForeColor = Color.Black
        'End If
        infoClienteCobranza.plazo = numCobranzaPlazoDias.Text
        infoClienteCobranza.limitecredito = numCobranzaLimiteCredito.Value
        infoClienteCobranza.montocreditoautorizado = numCobranzaMontoCredito.Value

        Try
            clientesDatos.editarVentasInfoCliente(infoClienteVentas, 2)
        Catch ex As Exception
            show_message("Error", "Algo surgió mal durante el proceso de guardado")
            Exit Sub
        End Try

        Try
            clientesDatos.editarCobranzaInfoCliente(infoClienteCobranza, 4)
            ''edita informacion de clave SAT
            Dim objBuSat As New Negocios.ClientesDatosBU
            Dim general As Int32 = 0
            If rdoGeneralSAT.Checked = True Then
                general = 1
            Else
                general = 0
            End If

            objBuSat.actualizaClaveSAT(general, CInt(lblClienteSAYID_Int.Text))

        Catch ex As Exception
            show_message("Error", "Algo surgió mal durante el proceso de guardado")
            Exit Sub
        End Try

        show_message("Exito", "Información guardada con éxito")

        ModoEdicion_CreditoConbranza = False

        recuperar_datos_Panel_Cobranza(CInt(lblClienteSAYID_Int.Text))
        CambiarElForeColorControles_Negro(tpgCobranzaCobranzaEval)
        CambiarElForeColorControles_DodgerBlue(pnlBotonesCobranzaEvalContabilidad)
    End Sub

    Private Sub btnEditarPanelCobranzaEvaluacionTecnica_Click(sender As Object, e As EventArgs) Handles btnEditarCobranzaEvaluacionTecnica.Click
        ModoEdicion_CreditoConbranza = True
        asignaStatusControles(tpgCobranzaCobranzaEval, True)

        Dim personaID As Integer = CInt(lblClientePersonaID_Int.Text)
        Dim clienteID As Integer = CInt(lblClienteSAYID_Int.Text)

        ''consulta clave SAT
        Dim objLCBU As New Negocios.ListaPreciosVentaClienteBU
        Dim clave As String = String.Empty

        clave = objLCBU.consultaClaveSATCliente(clienteID)

        If clave = "DETALLADA" Then
            rdoDetalladaSAT.Checked = True
        Else
            rdoGeneralSAT.Checked = True
        End If

        'habilita o inhabilita plazo días dependiendo del permiso
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARPLAZODIAS") Then
            pnlPlazoDias.Enabled = True
        Else
            pnlPlazoDias.Enabled = False
        End If

        ''habilita o inhabilita clave SAT dependiendo del permiso
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCLAVESAT") Then
            pnlClaveSAT.Enabled = True
        Else
            pnlClaveSAT.Enabled = False
        End If
        If cliente_CP = 1 Then
            gboxCobranzaValidacion.Enabled = False

            Dim validacionBU As New Framework.Negocios.ValidacionBU
            Dim usuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

            If validacionBU.Cliente_Info_Obligatoria_Completa(personaID) Then

                If validacionBU.Usuario_Validacion(usuarioID, 2) Then

                    Dim tabla As New DataTable
                    tabla = validacionBU.Validacion_Cliente(clienteID, 2)

                    If tabla.Rows.Count > 0 Then ''YA CUENTA CON LA VALIDACION DE COBRANZA

                        If CInt(tabla.Rows(0).Item("clie_validacionstatusid_ventas")) = 2 Then ''RECHAZADO EN VENTAS

                            gboxCobranzaValidacion.Enabled = False
                            cboxCobranzaValidador.Enabled = False
                            limpiarControles(gboxCobranzaValidacion)
                            cboxCobranzaValidador.Enabled = False
                            dateCobranzaValidacionFecha.Value = Now
                            dateCobranzaValidacionFecha.Enabled = False

                        ElseIf CInt(tabla.Rows(0).Item("clie_validacionstatusid_ventas")) = 1 Then ''APROBADO EN VENTAS

                            If Not IsDBNull(tabla.Rows(0).Item("clie_validacionstatusid_credcobr")) Then '' CON VALIDACION DE COBRANZA

                                If CInt(tabla.Rows(0).Item("clie_validacionstatusid_credcobr")) = 1 Then ''AUTORIZADO EN COBRANZA

                                    gboxCobranzaValidacion.Enabled = False
                                    ListaValidadorCobranza(0, 2)
                                    cboxCobranzaValidador.SelectedValue = CInt(tabla.Rows(0).Item("vali_colaboradorid"))

                                    dateCobranzaValidacionFecha.Value = CDate(tabla.Rows(0).Item("clie_validacionfecha_credcobr"))

                                    txtCobranzaValidacionComentarios.Text = CStr(tabla.Rows(0).Item("vali_comentario"))

                                ElseIf CInt(tabla.Rows(0).Item("clie_validacionstatusid_credcobr")) = 2 Then ''RECHAZADO EN COBRANZA

                                    gboxCobranzaValidacion.Enabled = True
                                    limpiarControles(gboxCobranzaValidacion)
                                    ListaValidadorCobranza(usuarioID, 2)
                                    cboxCobranzaValidador.SelectedValue = CInt(tabla.Rows(0).Item("vali_colaboradorid"))
                                    cboxCobranzaValidador.Enabled = False
                                    dateCobranzaValidacionFecha.Value = Now
                                    dateCobranzaValidacionFecha.Enabled = False

                                End If
                            Else ''SIN VALIDACION DE COBRANZA

                                gboxCobranzaValidacion.Enabled = True
                                cboxCobranzaValidador.Enabled = False
                                limpiarControles(gboxCobranzaValidacion)
                                ListaValidadorCobranza(usuarioID, 2)
                                cboxCobranzaValidador.Enabled = False
                                dateCobranzaValidacionFecha.Value = Now
                                dateCobranzaValidacionFecha.Enabled = False

                            End If
                        End If

                    Else
                        tabla = validacionBU.Validacion_Cliente(clienteID, 1)
                        If tabla.Rows.Count > 0 Then ''YA CUENTA CON LA VALIDACION DE COBRANZA

                            If CInt(tabla.Rows(0).Item("clie_validacionstatusid_ventas")) = 2 Then ''RECHAZADO EN VENTAS

                                gboxCobranzaValidacion.Enabled = False
                                cboxCobranzaValidador.Enabled = False
                                limpiarControles(gboxCobranzaValidacion)
                                cboxCobranzaValidador.Enabled = False
                                dateCobranzaValidacionFecha.Value = Now
                                dateCobranzaValidacionFecha.Enabled = False

                            ElseIf CInt(tabla.Rows(0).Item("clie_validacionstatusid_ventas")) = 1 Then ''APROBADO EN VENTAS

                                If Not IsDBNull(tabla.Rows(0).Item("clie_validacionstatusid_credcobr")) Then '' CON VALIDACION DE COBRANZA

                                    If CInt(tabla.Rows(0).Item("clie_validacionstatusid_credcobr")) = 1 Then ''AUTORIZADO EN COBRANZA

                                        gboxCobranzaValidacion.Enabled = False
                                        ListaValidadorCobranza(0, 2)
                                        cboxCobranzaValidador.SelectedValue = CInt(tabla.Rows(0).Item("vali_colaboradorid"))

                                        dateCobranzaValidacionFecha.Value = CDate(tabla.Rows(0).Item("clie_validacionfecha_credcobr"))

                                        txtCobranzaValidacionComentarios.Text = CStr(tabla.Rows(0).Item("vali_comentario"))

                                    ElseIf CInt(tabla.Rows(0).Item("clie_validacionstatusid_credcobr")) = 2 Then ''RECHAZADO EN COBRANZA

                                        gboxCobranzaValidacion.Enabled = True
                                        limpiarControles(gboxCobranzaValidacion)
                                        ListaValidadorCobranza(usuarioID, 2)
                                        cboxCobranzaValidador.SelectedValue = CInt(tabla.Rows(0).Item("vali_colaboradorid"))
                                        cboxCobranzaValidador.Enabled = False
                                        dateCobranzaValidacionFecha.Value = Now
                                        dateCobranzaValidacionFecha.Enabled = False

                                    End If
                                Else ''SIN VALIDACION DE COBRANZA

                                    gboxCobranzaValidacion.Enabled = True
                                    cboxCobranzaValidador.Enabled = False
                                    limpiarControles(gboxCobranzaValidacion)
                                    ListaValidadorCobranza(usuarioID, 2)
                                    cboxCobranzaValidador.Enabled = False
                                    dateCobranzaValidacionFecha.Value = Now
                                    dateCobranzaValidacionFecha.Enabled = False

                                End If
                            End If
                        End If

                    End If

                End If
            End If

        ElseIf cliente_CP = 3 Then
            gboxCobranzaValidacion.Enabled = False
        End If


    End Sub

    Private Sub btnCancelarPanelCobranzaEvaluacionTecnica_Click(sender As Object, e As EventArgs) Handles btnCancelarPanelCobranzaEvaluacionTecnica.Click
        If Mensajes_Y_Alertas("CONFIRMACION", "Los cambios realizados no se han guardado ¿Desea cancelar los cambios?") Then
            ModoEdicion_CreditoConbranza = False
            recuperar_datos_Panel_Cobranza(CInt(lblClienteSAYID_Int.Text))
            CambiarElForeColorControles_Negro(tpgCobranzaCobranzaEval)
            CambiarElForeColorControles_DodgerBlue(pnlBotonesCobranzaEvalContabilidad)
        End If

    End Sub

#End Region

    Private Sub btnCobranzaValidacionAutorizar_Click(sender As Object, e As EventArgs) Handles btnCobranzaValidacionAutorizar.Click

        Try
            If Not alta_Ventas_Cobranza_ValidacionCliente(1) Then
                Exit Sub
            End If
        Catch ex As Exception

            show_message("Error", "Algo falló en la operación")
            Exit Sub
        End Try

    End Sub

    Private Sub btnCobranzaValidacionRechazar_Click(sender As Object, e As EventArgs) Handles btnCobranzaValidacionRechazar.Click

        Try
            If Not alta_Ventas_Cobranza_ValidacionCliente(2) Then
                Exit Sub
            End If
        Catch ex As Exception
            show_message("Error", "Algo falló en la operación")
            Exit Sub
        End Try

    End Sub

    Public Function alta_Ventas_Cobranza_ValidacionCliente(validacionStatus As Integer) As Boolean

        Dim clientesBU As New Negocios.ClientesBU
        Dim validacion As New Entidades.Validacion
        Dim validaciontipo As New Entidades.ValidacionTipo
        Dim colaborador As New Entidades.Colaborador
        Dim cliente As New Entidades.Cliente

        If cboxCobranzaValidador.SelectedValue = 0 Then
            Return False
        Else

            ' @clienteid AS INTEGER
            cliente.clienteid = CInt(lblClienteSAYID_Int.Text)
            validacion.registro = cliente
            ',@colaboradorid AS INTEGER
            colaborador.PColaboradorid = cboxCobranzaValidador.SelectedValue
            validacion.colaborador = colaborador
            ',@validacionstatusid AS INTEGER
            validacion.validacionestatus = validacionStatus
            ',@validaciontipoid AS INTEGER
            validaciontipo.validaciontipoid = 2 'vati_validaciontipoid	= 2	, vati_nombre = INFORMACIÓN CRÉDITO Y COBRANZA EN FICHA TÉCNICA DE CLIENTE                                          
            validacion.validaciontipo = validaciontipo
            ',@validacionfecha_ventas AS DATETIME
            validacion.fechavalidacion = dateCobranzaValidacionFecha.Value
            ',@comentario AS VARCHAR(150)
            If txtCobranzaValidacionComentarios.TextLength < 1 Then
                show_message("Advertencia", "Falta información")
                lblCobranzaValidacionComentarios.ForeColor = Color.Red
                Return False
            Else
                validacion.comentario = txtCobranzaValidacionComentarios.Text
                lblCobranzaValidacionComentarios.ForeColor = Color.Black
            End If

            Try
                clientesBU.AltaValidacionCliente(validacion, 0)
                If validacionStatus = 1 Then
                    show_message("Exito", "Validación de cobranza aprobada")
                ElseIf validacionStatus = 2 Then
                    show_message("Exito", "Validación de cobranza rechazada")
                End If

                ''Este proceso se efecuta unicamente en COMERCIALIZADOR actualmente
                Dim ListaColaborador As New List(Of Integer)

                'ListaColaborador.Add(cboxClienteVendedor.SelectedValue)
                ListaColaborador.Add(cboxClienteAtnClientes.SelectedValue)

                enviar_correo_validacion(43, "ENVIO_ALTA_VALIDACION_FTC", ListaColaborador, validacion)

                recuperar_datos_Panel_Cobranza(CInt(lblClienteSAYID_Int.Text))
                Return True
            Catch ex As Exception
                Return False
            End Try

        End If

    End Function

    Public Function EditarNotaCredito_Cobranza() As Boolean
        Dim metodoPago As Int16 = 0
        Dim formaPago As Int16 = 0
        Dim clientesDatosBU As New Negocios.ClientesDatosBU

        If IsDBNull(cmbMetodoPagoNotaCreditoCliente.SelectedValue) Or IsNothing(cmbMetodoPagoNotaCreditoCliente.SelectedValue) Then
            'show_message("Advertencia", "Falta información")
            metodoPago = 3
        Else
            metodoPago = cmbMetodoPagoNotaCreditoCliente.SelectedValue
        End If


        If IsDBNull(cmbFormaPagoNotaCreditoCliente.SelectedValue) Or IsNothing(cmbFormaPagoNotaCreditoCliente.SelectedValue) Then
            formaPago = 1
        Else
            formaPago = cmbFormaPagoNotaCreditoCliente.SelectedValue
        End If

        Try
            clientesDatosBU.editarClienteNotaCredito(metodoPago, formaPago, CInt(lblClienteSAYID_Int.Text))
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function editar_Cobranza_Cliente_ClienteRFC() As Boolean
        Dim clientesDatosBU As New Negocios.ClientesDatosBU
        Dim tipoCliente As New Entidades.TipoCliente
        Dim clienteRFC As New Entidades.ClienteRFC
        Dim moneda As New Entidades.Moneda
        Dim tipoIVA As New Entidades.TipoIVA
        Dim persona As New Entidades.Persona

        If IsDBNull(cboxCobranzaContabilidadTipoCliente.SelectedValue) Or IsNothing(cboxCobranzaContabilidadTipoCliente.SelectedValue) Then
            show_message("Advertencia", "Falta información")
            lblCobranzaContabilidadTipoCliente.ForeColor = Color.Red
            Return False
        Else
            If cboxCobranzaContabilidadTipoCliente.SelectedValue = 0 Then
                show_message("Advertencia", "Falta información")
                lblCobranzaContabilidadTipoCliente.ForeColor = Color.Red
                Return False
            Else
                lblCobranzaContabilidadTipoCliente.ForeColor = Color.Black
            End If
        End If

        If IsDBNull(cboxCobranzaContabilidadTipoMoneda.SelectedValue) Or IsNothing(cboxCobranzaContabilidadTipoMoneda.SelectedValue) Then
            show_message("Advertencia", "Falta información")
            lblCobranzaContabilidadTipoMoneda.ForeColor = Color.Red
            Return False
        Else
            If cboxCobranzaContabilidadTipoMoneda.SelectedValue = 0 Then
                show_message("Advertencia", "Falta información")
                lblCobranzaContabilidadTipoMoneda.ForeColor = Color.Red
                Return False
            Else
                lblCobranzaContabilidadTipoMoneda.ForeColor = Color.Black
            End If
        End If

        If IsDBNull(cboxCobranzaContabilidadTipoIVA.SelectedValue) Or IsNothing(cboxCobranzaContabilidadTipoIVA.SelectedValue) Then
            show_message("Advertencia", "Falta información")
            lblCobranzaContabilidadTipoIVA.ForeColor = Color.Red
            Return False
        Else
            If cboxCobranzaContabilidadTipoIVA.SelectedValue = 0 Then
                show_message("Advertencia", "Falta información")
                lblCobranzaContabilidadTipoIVA.ForeColor = Color.Red
                Return False
            Else
                lblCobranzaContabilidadTipoIVA.ForeColor = Color.Black
            End If
        End If

        moneda.monedaid = cboxCobranzaContabilidadTipoMoneda.SelectedValue
        clienteRFC.moneda = moneda

        tipoIVA.tipoivaid = cboxCobranzaContabilidadTipoIVA.SelectedValue
        clienteRFC.tipoiva = tipoIVA

        tipoCliente.tipoclienteid = CInt(cboxCobranzaContabilidadTipoCliente.SelectedValue)
        clienteRFC.tipocliente = tipoCliente

        persona.personaid = CInt(lblContabilidadRFCPersonaID_Int.Text)
        clienteRFC.persona = persona

        If cboxRegimenFis.SelectedIndex > 0 Then
            clienteRFC.regimenFiscalId = cboxRegimenFis.SelectedValue
        End If

        If CInt(lblContabilidadRFCPersonaID_Int.Text) = 0 Then Return False

        Try
            clientesDatosBU.editarClienteClienteRFC(clienteRFC, Nothing, 4)
            EditarNotaCredito_Cobranza()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Sub RecuperarInfo_MetodoFormaPago_NotaCredito(clienteID As Integer)
        Dim InfoClienteCobranza As New DataTable
        Dim clientesDatosBU As New Negocios.ClientesDatosBU

        InfoClienteCobranza = clientesDatosBU.Datos_TablaCobranzaInfoCliente(clienteID)
        If InfoClienteCobranza.Rows.Count > 0 Then
            ''Recupera forma y método de pago referente a las notas de crédito
            If IsDBNull(InfoClienteCobranza.Rows(0).Item("iccl_metodopago_notacredito_formapagoid")) Then
                cmbMetodoPagoNotaCreditoCliente.SelectedValue = 1
            Else
                cmbMetodoPagoNotaCreditoCliente.SelectedValue = CInt(InfoClienteCobranza.Rows(0).Item("iccl_metodopago_notacredito_formapagoid"))
            End If

            If IsDBNull(InfoClienteCobranza.Rows(0).Item("iccl_formapago_notacredito_metodopagoid")) Then
                cmbFormaPagoNotaCreditoCliente.SelectedValue = 1
            Else
                cmbFormaPagoNotaCreditoCliente.SelectedValue = CInt(InfoClienteCobranza.Rows(0).Item("iccl_formapago_notacredito_metodopagoid"))
            End If
        End If
    End Sub

    Public Sub recuperar_datos_Panel_Cobranza(clienteID As Integer)

        limpiarControles(pnlFormCobranza)
        asignaStatusControles(pnlFormCobranza, False)

        'btnEditarPanelCobranzaContabilidad.Enabled = False
        'cboxCobranzaMetodoPago.Enabled = True
        'cboxCobranzaMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList
        'cboxCobranzaFormaPago.Enabled = True
        'cboxCobranzaFormaPago.DropDownStyle = ComboBoxStyle.DropDownList

        'If Not Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
        '    If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
        '        btnEditarCobranzaContabilidad.Enabled = False
        '        btnEditarCobranzaEvaluacionTecnica.Enabled = False
        '        btnEditarCobranzaPoliticaPagos.Enabled = False
        '    Else
        '        btnEditarCobranzaContabilidad.Enabled = True
        '        btnEditarCobranzaEvaluacionTecnica.Enabled = True
        '        btnEditarCobranzaPoliticaPagos.Enabled = True
        '    End If
        'End If

        If rbtnClienteStatusInactivo.Checked Then
            btnEditarCobranzaContabilidad.Enabled = False
            btnEditarCobranzaEvaluacionTecnica.Enabled = False
            btnEditarCobranzaPoliticaPagos.Enabled = False
        Else
            'SI SE REQUIERE QUE EL BOTÓN DE EDITAR APAREZCA PARA LOS USUARIOS QUE TIENEN ASIGNADO ESE CLIENTE QUITAR LOS COMENTARIOS
            'DE LAS SIGUIENTES LINEAS

            'If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
            'btnEditarCobranzaContabilidad.Enabled = True
            'btnEditarCobranzaEvaluacionTecnica.Enabled = True
            'btnEditarCobranzaPoliticaPagos.Enabled = True
            'Else
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
                btnEditarCobranzaContabilidad.Enabled = True
                btnEditarCobranzaEvaluacionTecnica.Enabled = True
                btnEditarCobranzaPoliticaPagos.Enabled = True
                btnEditarNumReferenciaYConvenio.Enabled = True
            Else
                btnEditarCobranzaContabilidad.Enabled = False
                btnEditarCobranzaEvaluacionTecnica.Enabled = False
                btnEditarCobranzaPoliticaPagos.Enabled = False
                btnEditarNumReferenciaYConvenio.Enabled = False
            End If
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITAR_PERIODICIDAD_COBRANZA") Then
                BtnEditarPeriodicidad.Enabled = True
                obtenerPeriodicidaEstadosCuentas()
            End If
            ' End If
        End If

        Dim politicaPago As New DataTable
        Dim infoClienteVentas As New DataTable
        Dim InfoClienteCobranza As New DataTable
        Dim PoliticaPagoBU As New Negocios.PoliticaPagoBU
        Dim clientesDatosBU As New Negocios.ClientesDatosBU

        'POLITICA DE PAGOS
        politicaPago = PoliticaPagoBU.Datos_TablaPoliticaPago(clienteID)
        If politicaPago.Rows.Count > 0 Then


            ListaFormaPago(cboxCobranzaFormaPago_Old)
            If IsDBNull(politicaPago.Rows(0).Item("popa_formapagoid")) Then
                cboxCobranzaFormaPago_Old.SelectedIndex = -1
            Else
                cboxCobranzaFormaPago_Old.SelectedValue = CInt(politicaPago.Rows(0).Item("popa_formapagoid"))
            End If

            If IsDBNull(politicaPago.Rows(0).Item("popa_notascobranza")) Then
                txtCobranzaNotasCobranza.Text = String.Empty
            Else
                txtCobranzaNotasCobranza.Text = CStr(politicaPago.Rows(0).Item("popa_notascobranza"))
            End If

            If IsDBNull(politicaPago.Rows(0).Item("popa_notasdevoluciones")) Then
                txtCobranzaNotasDevoluciones.Text = String.Empty
            Else
                txtCobranzaNotasDevoluciones.Text = CStr(politicaPago.Rows(0).Item("popa_notasdevoluciones"))
            End If

            If IsDBNull(politicaPago.Rows(0).Item("popa_plazoreal")) Then
                numCobranzaPlazoRealDias.Value = Decimal.Zero
            Else
                numCobranzaPlazoRealDias.Value = CDec(politicaPago.Rows(0).Item("popa_plazoreal"))
            End If

            If IsDBNull(politicaPago.Rows(0).Item("popa_proporcionarcuentaremision")) Then
                chkCobranzaProporcionarCuentaBancariaRemisiones.Checked = False
            Else
                chkCobranzaProporcionarCuentaBancariaRemisiones.Checked = CBool(politicaPago.Rows(0).Item("popa_proporcionarcuentaremision"))
            End If
            If IsDBNull(politicaPago.Rows(0).Item("popa_referencia")) Then
                txtnumeroReferencia.Text = String.Empty
            Else
                txtnumeroReferencia.Text = CStr(politicaPago.Rows(0).Item("popa_referencia"))
            End If
            If IsDBNull(politicaPago.Rows(0).Item("popa_convenio")) Then
                txtconvenio.Text = String.Empty
            Else
                txtconvenio.Text = CStr(politicaPago.Rows(0).Item("popa_convenio"))
            End If


        End If

        'INFO CLIENTES VENTAS

        'ListaFormaPago_NotaCredito(cmbFormaPagoNotaCreditoCliente)
        'ListaMetodoPago_NotaCredito(cmbMetodoPagoNotaCreditoCliente)
        infoClienteVentas = clientesDatosBU.Datos_TablaVentasInfoCliente(clienteID)
        If infoClienteVentas.Rows.Count > 0 Then

            If IsDBNull(infoClienteVentas.Rows(0).Item("ivcl_contactoinicial")) Then
                chboxCobranzaContactoInicial.Checked = False
            Else
                chboxCobranzaContactoInicial.Checked = CBool(infoClienteVentas.Rows(0).Item("ivcl_contactoinicial"))
            End If

            If IsDBNull(infoClienteVentas.Rows(0).Item("ivcl_buscamoscliente")) Then
                chboxCobranzaBuscamosCliente.Checked = False
            Else
                chboxCobranzaBuscamosCliente.Checked = CBool(infoClienteVentas.Rows(0).Item("ivcl_buscamoscliente"))
            End If

            If IsDBNull(infoClienteVentas.Rows(0).Item("ivcl_tienepedidoinicial")) Then
                chboxCobranzaTienePedidoInicial.Checked = False
            Else
                chboxCobranzaTienePedidoInicial.Checked = CBool(infoClienteVentas.Rows(0).Item("ivcl_tienepedidoinicial"))
            End If

            If IsDBNull(infoClienteVentas.Rows(0).Item("ivcl_parespedidoinicial")) Then
                numCobranzaPares.Value = Decimal.Zero
            Else
                numCobranzaPares.Value = CDec(infoClienteVentas.Rows(0).Item("ivcl_parespedidoinicial"))
            End If

            If IsDBNull(infoClienteVentas.Rows(0).Item("ivcl_articulospedidoinicial")) Then
                txtCobranzaCantidadArticulosAVender.Text = String.Empty
            Else
                txtCobranzaCantidadArticulosAVender.Text = CStr(infoClienteVentas.Rows(0).Item("ivcl_articulospedidoinicial"))
            End If

            If IsDBNull(infoClienteVentas.Rows(0).Item("ivcl_fechaentregapedidoinicial")) Then
                dateCobranzaFechaDeEntrega.Value = Date.Now
            Else
                dateCobranzaFechaDeEntrega.Value = DateTime.Parse(infoClienteVentas.Rows(0).Item("ivcl_fechaentregapedidoinicial"))
            End If



        End If

        'INFO CLIENTES COBRANZA

        InfoClienteCobranza = clientesDatosBU.Datos_TablaCobranzaInfoCliente(clienteID)
        If InfoClienteCobranza.Rows.Count > 0 Then

            If IsDBNull(InfoClienteCobranza.Rows(0).Item("iccl_plazo")) Then
                numCobranzaPlazoDias.Text = 0
            Else
                If CInt(InfoClienteCobranza.Rows(0).Item("iccl_plazo")) = 0 Then
                    numCobranzaPlazoDias.Text = "0"
                Else
                    numCobranzaPlazoDias.Text = CInt(InfoClienteCobranza.Rows(0).Item("iccl_plazo"))
                End If
            End If

            If IsDBNull(InfoClienteCobranza.Rows(0).Item("iccl_limitecredito")) Then
                numCobranzaLimiteCredito.Value = Decimal.Zero
            Else
                numCobranzaLimiteCredito.Value = CDec(InfoClienteCobranza.Rows(0).Item("iccl_limitecredito"))
            End If

            If IsDBNull(InfoClienteCobranza.Rows(0).Item("iccl_montocreditoautorizado")) Then
                numCobranzaMontoCredito.Value = Decimal.Zero
            Else
                numCobranzaMontoCredito.Value = CDec(InfoClienteCobranza.Rows(0).Item("iccl_montocreditoautorizado"))
            End If

            ''recupera clave SAT
            If InfoClienteCobranza.Rows(0).Item("iccl_clavesat_general") = True Then
                rdoGeneralSAT.Checked = True
            Else
                rdoDetalladaSAT.Checked = True
            End If

            ''Recupera forma y método de pago referente a las notas de crédito
            If IsDBNull(InfoClienteCobranza.Rows(0).Item("iccl_metodopago_notacredito_formapagoid")) Then
                cmbMetodoPagoNotaCreditoCliente.SelectedValue = 1
            Else
                cmbMetodoPagoNotaCreditoCliente.SelectedValue = CInt(InfoClienteCobranza.Rows(0).Item("iccl_metodopago_notacredito_formapagoid"))
            End If

            If IsDBNull(InfoClienteCobranza.Rows(0).Item("iccl_formapago_notacredito_metodopagoid")) Then
                cmbFormaPagoNotaCreditoCliente.SelectedValue = 1
            Else
                cmbFormaPagoNotaCreditoCliente.SelectedValue = CInt(InfoClienteCobranza.Rows(0).Item("iccl_formapago_notacredito_metodopagoid"))
            End If
        End If


        'VALIDACION

        Dim validacionBU As New Framework.Negocios.ValidacionBU
        Dim usuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim tabla As New DataTable
        tabla = validacionBU.Validacion_Cliente(clienteID, 2)
        If tabla.Rows.Count > 0 Then


            gboxCobranzaValidacion.Enabled = False
            ListaValidadorCobranza(0, 2)
            cboxCobranzaValidador.SelectedValue = CInt(tabla.Rows(0).Item("vali_colaboradorid"))

            dateCobranzaValidacionFecha.Value = CDate(tabla.Rows(0).Item("vali_fechavalidacion"))

            txtCobranzaValidacionComentarios.Text = CStr(tabla.Rows(0).Item("vali_comentario"))

            If CInt(tabla.Rows(0).Item("vaes_validacionestatusid")) = 1 Then
                rbtnCobranzaValidacionStatusAutorizado.Checked = True
                rbtnCobranzaValidacionStatusRechazado.Checked = False
            ElseIf CInt(tabla.Rows(0).Item("vaes_validacionestatusid")) = 2 Then
                rbtnCobranzaValidacionStatusAutorizado.Checked = False
                rbtnCobranzaValidacionStatusRechazado.Checked = True
            End If

        End If




    End Sub

    Public Sub recuperar_datos_Panel_Cobranza_Contabilidad(personaID As Integer)

        Dim politicaPago As New DataTable
        Dim PoliticaPagoBU As New Negocios.PoliticaPagoBU

        'POLITICA DE PAGOS
        politicaPago = PoliticaPagoBU.Datos_TablaPoliticaPago(CInt(lblClienteSAYID_Int.Text))
        If politicaPago.Rows.Count > 0 Then
            ListaMetodoPago(cboxCobranzaMetodoPago)
            If IsDBNull(politicaPago.Rows(0).Item("popa_metodopagoid")) Then
                cboxCobranzaMetodoPago.SelectedIndex = -1
            Else
                cboxCobranzaMetodoPago.SelectedValue = CInt(politicaPago.Rows(0).Item("popa_metodopagoid"))
            End If
        End If

        ''COBRANZA RFC
        Dim clientesDatosBU As New Negocios.ClientesDatosBU
        Dim clienteRFC As New DataTable
        clienteRFC = clientesDatosBU.Datos_TablaClienteRFC(personaID)
        If clienteRFC.Rows.Count > 0 Then

            lblCobranzaContabilidadRFC_Int.Text = CStr(clienteRFC.Rows(0).Item("crfc_RFC"))

            If IsDBNull(clienteRFC.Rows(0).Item("crfc_cuenta")) Then
                numCobranzaCuenta.Text = String.Empty
            Else
                numCobranzaCuenta.Text = CStr(clienteRFC.Rows(0).Item("crfc_cuenta"))
            End If

            If IsDBNull(clienteRFC.Rows(0).Item("crfc_parcialidades1")) Then
                numCobranzaParcialidades1.Value = Decimal.Zero
            Else
                numCobranzaParcialidades1.Value = CDec(clienteRFC.Rows(0).Item("crfc_parcialidades1"))
            End If

            If IsDBNull(clienteRFC.Rows(0).Item("crfc_parcialidadesx")) Then
                numCobranzaParcialidadesX.Value = Decimal.Zero
            Else
                numCobranzaParcialidadesX.Value = CDec(clienteRFC.Rows(0).Item("crfc_parcialidadesx"))
            End If

            'ListaMetodoPago(cboxCobranzaMetodoPago)
            'If IsDBNull(clienteRFC.Rows(0).Item("crfc_metodopagoid")) Then
            '    cboxCobranzaMetodoPago.SelectedIndex = -1
            'Else
            '    cboxCobranzaMetodoPago.SelectedValue = CInt(clienteRFC.Rows(0).Item("crfc_metodopagoid"))
            'End If

            ListaFormaPago(cboxCobranzaFormaPago)
            If IsDBNull(clienteRFC.Rows(0).Item("crfc_formapagoid")) Then
                cboxCobranzaFormaPago.SelectedIndex = -1
            Else
                cboxCobranzaFormaPago.SelectedValue = CInt(clienteRFC.Rows(0).Item("crfc_formapagoid"))
            End If

        End If

    End Sub

    Public Sub recuperar_datos_Panel_Cobranza_EvalInfoCredito(personaID As Integer)

        limpiarControles(gboxCobranzaContabilidadClienteRFC)
        asignaStatusControles(gboxCobranzaContabilidadClienteRFC, False)

        ''CLIENTE RFC
        Dim clientesDatosBU As New Ventas.Negocios.ClientesDatosBU
        Dim clienteRFC As New DataTable
        clienteRFC = clientesDatosBU.Datos_TablaClienteRFC(personaID)

        If clienteRFC.Rows.Count > 0 Then

            lblContabilidadRFCPersonaID_Int.Text = CStr(clienteRFC.Rows(0).Item("crfc_personaid"))

            ListaMonedas(cboxCobranzaContabilidadTipoMoneda)
            If IsDBNull(clienteRFC.Rows(0).Item("crfc_monedaid")) Then
                cboxCobranzaContabilidadTipoMoneda.Text = String.Empty
            Else
                cboxCobranzaContabilidadTipoMoneda.SelectedValue = CInt(clienteRFC.Rows(0).Item("crfc_monedaid"))
            End If

            ListaTipoIVA(cboxCobranzaContabilidadTipoIVA)
            If IsDBNull(clienteRFC.Rows(0).Item("crfc_tipoivaid")) Then
                cboxCobranzaContabilidadTipoIVA.Text = String.Empty
            Else
                cboxCobranzaContabilidadTipoIVA.SelectedValue = CInt(clienteRFC.Rows(0).Item("crfc_tipoivaid"))
            End If

            ListaTipoCliente(cboxCobranzaContabilidadTipoCliente)
            If IsDBNull(clienteRFC.Rows(0).Item("crfc_tipoclienteid")) Then
                cboxCobranzaContabilidadTipoCliente.Text = String.Empty
            Else
                cboxCobranzaContabilidadTipoCliente.SelectedValue = CInt(clienteRFC.Rows(0).Item("crfc_tipoclienteid"))
            End If

        End If

    End Sub


#Region "Maximizar_Minimizar Controles"

    Private Sub gboxCobranzaContacto_MouseDoubleClick(sender As Object, e As EventArgs) Handles gboxCobranzaContacto.MouseDoubleClick
        If gboxCobranzaContacto.Dock = DockStyle.Fill Then
            gboxCobranzaContacto.Dock = DockStyle.None
            gboxCobranzaDescuentos.Visible = True
            tabControlPanelCobranza.Visible = True
        Else
            gboxCobranzaContacto.Dock = DockStyle.Fill
            gboxCobranzaDescuentos.Visible = False
            tabControlPanelCobranza.Visible = False
        End If
    End Sub

    Private Sub gboxCobranzaContaRFC_DoubleClick(sender As Object, e As EventArgs) Handles gboxCobranzaContaRFC.DoubleClick
        If gboxCobranzaContaRFC.Dock = DockStyle.Fill Then
            gboxCobranzaContaRFC.Dock = DockStyle.None
            gridCobranzaContaRFC.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            gboxCobranzaContaRFC.Dock = DockStyle.Fill
            gridCobranzaContaRFC.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If
    End Sub

    Private Sub gboxCobranzaDescuentos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gboxCobranzaDescuentos.MouseDoubleClick

        If gboxCobranzaDescuentos.Dock = DockStyle.Fill Then
            gboxCobranzaDescuentos.Dock = DockStyle.None
        Else
            gboxCobranzaDescuentos.Dock = DockStyle.Fill
        End If

    End Sub

    Private Sub gboxCobranzaEvalContacto_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gboxCobranzaEvalContacto.MouseDoubleClick
        If gboxCobranzaEvalContacto.Dock = DockStyle.Fill Then
            gboxCobranzaEvalContacto.Dock = DockStyle.None
            gboxCobranzaValidacion.Visible = True
            gboxCobranzaEvalVentas.Visible = True
            gboxCobranzaEvalInfoCredito.Visible = True
            pnlBotonesCobranzaEvalContabilidad.Visible = True
            gboxCobranzaValidacionHistorial.Visible = True
        Else
            gboxCobranzaEvalContacto.Dock = DockStyle.Fill
            gboxCobranzaValidacion.Visible = False
            gboxCobranzaEvalVentas.Visible = False
            gboxCobranzaEvalInfoCredito.Visible = False
            pnlBotonesCobranzaEvalContabilidad.Visible = False
            gboxCobranzaValidacionHistorial.Visible = False
        End If

    End Sub

    Private Sub gboxCobranzaValidacionHistorial_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gboxCobranzaValidacionHistorial.MouseDoubleClick
        If gboxCobranzaValidacionHistorial.Dock = DockStyle.Fill Then
            gboxCobranzaValidacionHistorial.Dock = DockStyle.None
            gboxCobranzaValidacion.Visible = True
            gboxCobranzaEvalVentas.Visible = True
            gboxCobranzaEvalInfoCredito.Visible = True
            pnlBotonesCobranzaEvalContabilidad.Visible = True
            gboxCobranzaEvalContacto.Visible = True
            gridCobranzaValidacionHistorial.DisplayLayout.AutoFitStyle = AutoFitStyle.None

            For cont = gridCobranzaValidacionHistorial.DisplayLayout.Bands(0).Columns.Count - 1 To 0 Step -1
                gridCobranzaValidacionHistorial.DisplayLayout.Bands(0).Columns(cont).Width = 70
            Next
        Else
            gboxCobranzaValidacionHistorial.Dock = DockStyle.Fill
            gboxCobranzaValidacion.Visible = False
            gboxCobranzaEvalVentas.Visible = False
            gboxCobranzaEvalInfoCredito.Visible = False
            pnlBotonesCobranzaEvalContabilidad.Visible = False
            gboxCobranzaEvalContacto.Visible = False
            gridCobranzaValidacionHistorial.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If
    End Sub


    Private Sub gboxCobranzaContrarecibo_Enter(sender As Object, e As EventArgs) Handles gboxCobranzaContrarecibo.MouseDoubleClick
        If gboxCobranzaContrarecibo.Dock = DockStyle.Fill Then
            gboxCobranzaContrarecibo.Dock = DockStyle.None
            gboxCobranzaDocumentos.Visible = True
            gboxCobranzaFormasPago.Visible = True
            gboxCobranzaCuentasBancarias.Visible = True
        Else
            gboxCobranzaContrarecibo.Dock = DockStyle.Fill
            gboxCobranzaDocumentos.Visible = False
            gboxCobranzaFormasPago.Visible = False
            gboxCobranzaCuentasBancarias.Visible = False
        End If
    End Sub

    Private Sub gboxCobranzaDocumentos_Enter(sender As Object, e As EventArgs) Handles gboxCobranzaDocumentos.MouseDoubleClick
        If gboxCobranzaDocumentos.Dock = DockStyle.Fill Then
            gboxCobranzaDocumentos.Dock = DockStyle.None
            gboxCobranzaFormasPago.Visible = True
            gboxCobranzaContrarecibo.Visible = True
            gboxCobranzaCuentasBancarias.Visible = True
        Else
            gboxCobranzaDocumentos.Dock = DockStyle.Fill
            gboxCobranzaFormasPago.Visible = False
            gboxCobranzaContrarecibo.Visible = False
            gboxCobranzaCuentasBancarias.Visible = False
        End If
    End Sub

    Private Sub gboxCobranzaFormasPago_Enter(sender As Object, e As EventArgs) Handles gboxCobranzaFormasPago.MouseDoubleClick
        If gboxCobranzaFormasPago.Dock = DockStyle.Fill Then
            gboxCobranzaFormasPago.Dock = DockStyle.None
            gboxCobranzaDocumentos.Visible = True
            gboxCobranzaContrarecibo.Visible = True
            gboxCobranzaCuentasBancarias.Visible = True
        Else
            gboxCobranzaFormasPago.Dock = DockStyle.Fill
            gboxCobranzaDocumentos.Visible = False
            gboxCobranzaContrarecibo.Visible = False
            gboxCobranzaCuentasBancarias.Visible = False
        End If
    End Sub

#End Region

    Private Sub numCobranzaCuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles numCobranzaCuenta.KeyPress
        'If Char.IsControl(e.KeyChar) Then
        '    If Char.IsNumber(e.KeyChar) Then

        '    Else
        '        e.Handled = True
        '    End If
        'Else
        If Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
        Else
            e.Handled = True
        End If
    End Sub


    'Private Sub numCobranzaCuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles numCobranzaCuenta.KeyPress
    '    If Char.IsControl(e.KeyChar) Then
    '        If Char.IsNumber(e.KeyChar) Then
    '        Else
    '            e.Handled = True
    '        End If
    '    ElseIf Char.IsNumber(e.KeyChar) Then
    '    Else
    '        e.Handled = True
    '    End If
    'End Sub


#Region "Numero Referencia Convenio"
    ''Numero Referencia Convenio

    Private Sub btnEditarNumReferenciaYConvenio_Click(sender As Object, e As EventArgs) Handles btnEditarNumReferenciaYConvenio.Click

        txtnumeroReferencia.Enabled = True
        txtconvenio.Enabled = True
        btnguardarNumReferenciaYConvenio.Enabled = True
        btn_cancelarNumReferenciaYConvenio.Enabled = True
        btnEditarNumReferenciaYConvenio.Enabled = False

    End Sub

    Private Sub btn_cancelarNumReferenciaYConvenio_Click(sender As Object, e As EventArgs) Handles btn_cancelarNumReferenciaYConvenio.Click
        Dim PoliticaPagoBU As New Negocios.PoliticaPagoBU
        Dim politicaPago = PoliticaPagoBU.Datos_TablaPoliticaPago(CInt(lblClienteSAYID_Int.Text))

        If IsDBNull(politicaPago.Rows(0).Item("popa_referencia")) Then
            txtnumeroReferencia.Text = String.Empty
        Else
            txtnumeroReferencia.Text = CStr(politicaPago.Rows(0).Item("popa_referencia"))
        End If
        If IsDBNull(politicaPago.Rows(0).Item("popa_convenio")) Then
            txtconvenio.Text = String.Empty
        Else
            txtconvenio.Text = CStr(politicaPago.Rows(0).Item("popa_convenio"))
        End If

        btnEditarNumReferenciaYConvenio.Enabled = True
        btnguardarNumReferenciaYConvenio.Enabled = False
        btn_cancelarNumReferenciaYConvenio.Enabled = False
        txtnumeroReferencia.Enabled = False
        txtconvenio.Enabled = False
    End Sub

    Private Sub btnguardarNumReferenciaYConvenio_Click(sender As Object, e As EventArgs) Handles btnguardarNumReferenciaYConvenio.Click
        Dim PoliticaPagoBU As New Negocios.PoliticaPagoBU
        Dim result = PoliticaPagoBU.editarNumReferenciayConvenio(CInt(lblClienteSAYID_Int.Text), txtnumeroReferencia.Text, txtconvenio.Text)

        If result.Columns.Contains("Error") And result.Columns.Contains("ErrorNumber") Then
            Mensajes_Y_Alertas("Advertencia", result.Rows(0).Item("Error") & result.Rows(0).Item("ErrorNumber"))
        Else
            Mensajes_Y_Alertas("EXITO", "Se agregaron los datos correctamente")
            btnEditarNumReferenciaYConvenio.Enabled = True
            btnguardarNumReferenciaYConvenio.Enabled = False
            btn_cancelarNumReferenciaYConvenio.Enabled = False
            txtnumeroReferencia.Enabled = False
            txtconvenio.Enabled = False
        End If
    End Sub
    Private Sub BtnGurdarPeriodicidad_Click(sender As Object, e As EventArgs) Handles BtnGurdarPeriodicidad.Click
        AltaEditarPeriodicidadCobranza()
    End Sub
    Private Sub AltaEditarPeriodicidadCobranza()
        Dim objPeriodicidad As New Negocios.PoliticaPagoBU
        Dim tipoPeriodicidad As Integer = 0
        Dim mostrarFacturas As Boolean = False
        Dim mostrarRemisiones As Boolean = False
        Try
            If rbtAplicaPagos.Checked = True Then
                tipoPeriodicidad = 1
            ElseIf rbtfinalSemana.Checked = True Then
                tipoPeriodicidad = 2
            ElseIf rbtInicioMes.Checked = True Then
                tipoPeriodicidad = 3
            End If

            If chkMostrarFacturas.Checked = True Then
                mostrarFacturas = 1
            Else
                mostrarFacturas = 0
            End If

            If chkMostrarRemisiones.Checked = True Then
                mostrarRemisiones = 1
            Else
                mostrarRemisiones = 0
            End If

            objPeriodicidad.AltaEditarPeriodicidadCobranza(CInt(txtClienteSICYID.Text), tipoPeriodicidad, mostrarFacturas, mostrarRemisiones)
            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se agrego correctamente la periodicidad")
            FuncionBotones()
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrio un error al guardar la periodicidad")
        End Try
    End Sub
    Private Sub FuncionBotones()
        BtnGurdarPeriodicidad.Enabled = False
        btnCancelarPeriodicidad.Enabled = False
        BtnEditarPeriodicidad.Enabled = True
        rbtNoenviarestados.Enabled = False
        rbtAplicaPagos.Enabled = False
        rbtfinalSemana.Enabled = False
        rbtInicioMes.Enabled = False
        ''chkMostrarFacturas.Checked = False
        ''chkMostrarRemisiones.Checked = False
        chkMostrarFacturas.Enabled = False
        chkMostrarRemisiones.Enabled = False
    End Sub
    Private Sub BtnEditarPeriodicidad_Click(sender As Object, e As EventArgs) Handles BtnEditarPeriodicidad.Click
        rbtNoenviarestados.Enabled = True
        rbtAplicaPagos.Enabled = True
        rbtfinalSemana.Enabled = True
        rbtInicioMes.Enabled = True
        BtnGurdarPeriodicidad.Enabled = True
        btnCancelarPeriodicidad.Enabled = True
        BtnEditarPeriodicidad.Enabled = False
        chkMostrarFacturas.Enabled = True
        chkMostrarRemisiones.Enabled = True
    End Sub
    Private Sub btnCancelarPeriodicidad_Click(sender As Object, e As EventArgs) Handles btnCancelarPeriodicidad.Click
        BtnEditarPeriodicidad.Enabled = True
        BtnGurdarPeriodicidad.Enabled = False
        btnCancelarPeriodicidad.Enabled = False
        rbtAplicaPagos.Checked = False
        rbtfinalSemana.Checked = False
        rbtInicioMes.Checked = False
        rbtNoenviarestados.Enabled = False
        rbtAplicaPagos.Enabled = False
        rbtfinalSemana.Enabled = False
        rbtInicioMes.Enabled = False
        chkMostrarFacturas.Enabled = False
        chkMostrarRemisiones.Enabled = False
        obtenerPeriodicidaEstadosCuentas()
    End Sub
    Private Sub obtenerPeriodicidaEstadosCuentas()
        Dim objObtenerPeriodicidad As New Negocios.PoliticaPagoBU
        Dim dtPeriodicidad As New DataTable
        dtPeriodicidad = objObtenerPeriodicidad.ObtenerPeriodicidadEstadosCuenta(CInt(txtClienteSICYID.Text))
        Try
            Select Case dtPeriodicidad.Rows(0).Item("periodicidad")
                Case 0
                    rbtNoenviarestados.Checked = True
                Case 1
                    rbtAplicaPagos.Checked = True
                Case 2
                    rbtfinalSemana.Checked = True
                Case 3
                    rbtInicioMes.Checked = True
            End Select

            Select Case dtPeriodicidad.Rows(0).Item("mostrarFacturas")
                Case False
                    chkMostrarFacturas.Checked = False
                Case True
                    chkMostrarFacturas.Checked = True
            End Select

            Select Case dtPeriodicidad.Rows(0).Item("mostrarRemisiones")
                Case False
                    chkMostrarRemisiones.Checked = False
                Case True
                    chkMostrarRemisiones.Checked = True
            End Select

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrio un error al obtener la periodicidad")
        End Try

    End Sub
#End Region


End Class
