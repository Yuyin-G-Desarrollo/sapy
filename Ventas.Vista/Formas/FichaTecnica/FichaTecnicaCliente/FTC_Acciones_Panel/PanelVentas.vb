Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools.Controles

Partial Public Class FichaTecnicaClienteForm

    Private Sub chboxVentasConfirmarPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chboxVentasConfirmarPedido.CheckedChanged

        If chboxVentasConfirmarPedido.Checked Then
            numVentasHorasConfirmarPedido.Enabled = True
        Else
            numVentasHorasConfirmarPedido.Enabled = False
        End If

    End Sub

    Private Sub nudVentasPorcentajeAFacturar_LostFocus(sender As Object, e As EventArgs) Handles nudVentasPorcentajeAFacturar.LostFocus
        nudVentasPorcentajeADocumentar.Value = 100 - nudVentasPorcentajeAFacturar.Value
    End Sub

    Private Sub nudVentasPorcentajeADocumentar_LostFocus(sender As Object, e As EventArgs) Handles nudVentasPorcentajeADocumentar.LostFocus

        nudVentasPorcentajeAFacturar.Value = 100 - nudVentasPorcentajeADocumentar.Value

    End Sub

    Private Sub btnGuardarPanelVentas_Click(sender As Object, e As EventArgs) Handles btnGuardarVentas.Click

        Try
            If Not editar_Ventas_Cliente_Clientes() Then
                Exit Sub
            End If
        Catch ex As Exception
            show_message("Error", "Algo falló en la operación")
            Exit Sub
        End Try

        Try
            If Not editar_Ventas_Ventas_PoliticaVentas() Then
                Exit Sub
            End If
        Catch ex As Exception
            show_message("Error", "Algo falló en la operación")
            Exit Sub
        End Try

        Try
            If Not alta_Ventas_Cobranza_InfoCliente() Then
                Exit Sub
            End If
        Catch ex As Exception
            show_message("Error", "Algo falló en la operación")
            Exit Sub
        End Try

        show_message("Exito", "Datos guardados con éxito")

        recuperar_datos_Panel_Ventas(CInt(lblClienteSAYID_Int.Text))

        ActivarCeldasGrid(False)
        ModoEdicion = False

    End Sub

    Private Sub ActivarCeldasGrid(ByVal activar_inactivar As Boolean)


        If activar_inactivar = True Then
            ''gridVentasVendedores
            gridVentasVendedores.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
            For Each row In gridVentasVendedores.Rows
                'gridVentasVendedores.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
                gridVentasVendedores.DisplayLayout.Rows(row.Index).Cells("Id").Activation = Activation.NoEdit
                'gridVentasVendedores.DisplayLayout.Rows(row.Index).Cells("MARCA").Activation = Activation.AllowEdit
                'gridVentasVendedores.DisplayLayout.Rows(row.Index).Cells("AGENTE DE VENTAS").Activation = Activation.AllowEdit
                'gridVentasVendedores.DisplayLayout.Rows(row.Index).Cells("EMPRESA").Activation = Activation.AllowEdit
                gridVentasVendedores.DisplayLayout.Rows(row.Index).Cells("CONTACTO").Activation = Activation.NoEdit
                gridVentasVendedores.DisplayLayout.Rows(row.Index).Cells("EMAIL").Activation = Activation.NoEdit
                'gridVentasVendedores.DisplayLayout.Rows(row.Index).Cells("ACTIVO").Activation = Activation.AllowEdit
                ''gridVentasVendedores.ActiveRow.Cells("CONTACTO").Activation = Activation.ActivateOnly
                gridVentasVendedores.DisplayLayout.Rows(row.Index).Cells("BLOQUEO C").Activation = Activation.AllowEdit
            Next

            If editarMarcaAgenteVentas Then
                For Each row In gridVentasVendedores.Rows
                    row.Activation = Activation.AllowEdit
                Next
            End If


            ''gridDocumentos
            gridDocumentos.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
            For Each row In gridDocumentos.Rows
                gridDocumentos.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
                gridDocumentos.DisplayLayout.Rows(row.Index).Cells("docl_numerocopias").Activation = Activation.AllowEdit
                gridDocumentos.DisplayLayout.Rows(row.Index).Cells("tido_nombre").Activation = Activation.AllowEdit
                gridDocumentos.DisplayLayout.Rows(row.Index).Cells("ACTIVO").Activation = Activation.AllowEdit
            Next

        Else
            ''gridVentasVendedores
            If Not IsNothing(gridVentasVendedores.DataSource) Then
                For Each row In gridVentasVendedores.Rows
                    gridVentasVendedores.DisplayLayout.Rows(row.Index).Activation = Activation.ActivateOnly
                    gridVentasVendedores.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                Next
            End If

            If Not IsNothing(gridDocumentos) Then
                For Each row In gridDocumentos.Rows
                    gridDocumentos.DisplayLayout.Rows(row.Index).Activation = Activation.ActivateOnly
                    gridDocumentos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                Next
            End If


            If Not IsNothing(gridPolitica) Then
                '' gridPolitica
                editando_politica = False
                poblar_gridPolitica(editando_politica, CInt(lblClienteSAYID_Int.Text), gridPolitica)
                For Each row In gridPolitica.Rows
                    Dim objBU As New Framework.Negocios.CondicionesBU
                    Dim Catalogo As New DataTable
                    Dim vlCatalogo As New Infragistics.Win.ValueList
                    Dim condicion As Integer
                    condicion = CInt(row.Cells(4).Value)
                    Catalogo = objBU.Datos_TablaCondicionesCatalogoCondicion(condicion, AreaOperativa)
                    For Each fila As DataRow In Catalogo.Rows
                        vlCatalogo.ValueListItems.Add(fila.Item("coca_condicioncatalogoid"), fila.Item("coca_descripcion"))
                    Next
                    row.Cells(7).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
                    row.Cells(7).ValueList = vlCatalogo

                    gridPolitica.DisplayLayout.Rows(row.Index).Activation = Activation.NoEdit
                    gridPolitica.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                Next
            End If
        End If
    End Sub

    Private Sub btnEditarPanelVentas_Click(sender As Object, e As EventArgs) Handles btnEditarVentas.Click

        asignaStatusControles(pnlFormVentas, True)

        nudVentasPorcentajeADocumentar.Enabled = False
        nudVentasPorcentajeAFacturar.Enabled = False

        Dim personaID As Integer = CInt(lblClientePersonaID_Int.Text)
        Dim clienteID As Integer = CInt(lblClienteSAYID_Int.Text)

        If cliente_CP = 1 Then
            ''ActivarFilas
            ActivarCeldasGrid(True)
            ModoEdicion = True

            gboxVentasValidacion.Enabled = False

            Dim validacionBU As New Framework.Negocios.ValidacionBU
            Dim usuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

            If validacionBU.Cliente_Info_Obligatoria_Completa(personaID) Then

                If validacionBU.Usuario_Validacion(usuarioID, 1) Then

                    Dim tabla As New DataTable
                    tabla = validacionBU.Validacion_Cliente(clienteID, 1)

                    If tabla.Rows.Count > 0 Then

                        If CInt(tabla.Rows(0).Item("clie_validacionstatusid_ventas")) = 1 Then
                            gboxVentasValidacion.Enabled = False
                            ListaValidadorVentas(0, 1)
                            cboxVentasValidador.SelectedValue = CInt(tabla.Rows(0).Item("vali_colaboradorid"))

                            dateVentasValidacionFecha.Value = CDate(tabla.Rows(0).Item("clie_validacionfecha_ventas"))

                            txtVentasValidacionComentarios.Text = CStr(tabla.Rows(0).Item("vali_comentario"))

                        ElseIf CInt(tabla.Rows(0).Item("clie_validacionstatusid_ventas")) = 2 Then

                            gboxVentasValidacion.Enabled = True
                            limpiarControles(gboxVentasValidacion)
                            ListaValidadorVentas(usuarioID, 1)
                            cboxVentasValidador.SelectedValue = CInt(tabla.Rows(0).Item("vali_colaboradorid"))
                            cboxVentasValidador.Enabled = False
                            dateVentasValidacionFecha.Value = Now
                            dateVentasValidacionFecha.Enabled = False

                        End If

                    Else

                        gboxVentasValidacion.Enabled = True
                        cboxVentasValidador.Enabled = False
                        limpiarControles(gboxVentasValidacion)
                        ListaValidadorVentas(usuarioID, 1)
                        cboxVentasValidador.Enabled = False
                        dateVentasValidacionFecha.Value = Now
                        dateVentasValidacionFecha.Enabled = False

                    End If

                End If

            End If

        ElseIf cliente_CP = 3 Then
            gboxVentasValidacion.Enabled = False
        End If

        ''PERMISO USO DE CFDI
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARUSOCFDI") Then
            cmbVentasUsoCFDI.Enabled = True
        Else
            cmbVentasUsoCFDI.Enabled = False
        End If

    End Sub

    Private Sub btnCancelarPanelVentas_Click(sender As Object, e As EventArgs) Handles btnCancelarVentas.Click
        If Mensajes_Y_Alertas("CONFIRMACION", "Los cambios realizados no se han guardado ¿Desea cancelar los cambios?") Then
            recuperar_datos_Panel_Ventas(CInt(lblClienteSAYID_Int.Text))

            ActivarCeldasGrid(False)
            ModoEdicion = False

            CambiarElForeColorControles_Negro(pnlFormVentas)
        End If

    End Sub

    Private Sub btnVentasValidacionAutorizar_Click(sender As Object, e As EventArgs) Handles btnVentasValidacionAutorizar.Click

        Try
            If Not alta_Ventas_Ventas_ValidacionCliente(1) Then
                Exit Sub
            End If
        Catch ex As Exception
            show_message("Error", "Algo falló en la operación")
            Exit Sub
        End Try

    End Sub

    Private Sub btnVentasValidacionRechazar_Click(sender As Object, e As EventArgs) Handles btnVentasValidacionRechazar.Click

        Try
            If Not alta_Ventas_Ventas_ValidacionCliente(2) Then
                Exit Sub
            End If
        Catch ex As Exception
            show_message("Error", "Algo falló en la operación")
            Exit Sub
        End Try

    End Sub

    Public Function editar_Ventas_Cliente_Clientes() As Boolean

        Dim clienteBU As New Negocios.ClientesBU
        Dim cliente As New Entidades.Cliente
        Dim empresas As New Entidades.Empresa
        Dim tipoCliente As New Entidades.TipoCliente

        'cliente.comentarios = Nothing

        '   EMPRESA - OBLIGATORIO PARA CLIENTE
        If IsDBNull(cboxVentasEmpresa.SelectedValue) Then
            If cliente_CP = 1 Then
                show_message("Advertencia", "Falta información")
                lblVentasEmpresa.ForeColor = Color.Red
                Return False
            Else
                empresas.Pempr_empresaid = 0
                lblVentasEmpresa.ForeColor = Color.Black
            End If
        Else
            If cboxVentasEmpresa.SelectedValue = 0 Then
                If cliente_CP = 1 Then
                    show_message("Advertencia", "Falta información")
                    lblVentasEmpresa.ForeColor = Color.Red
                    Return False
                Else
                    empresas.Pempr_empresaid = 0
                    lblVentasEmpresa.ForeColor = Color.Black
                End If
            Else
                empresas.Pempr_empresaid = cboxVentasEmpresa.SelectedValue
                lblVentasEmpresa.ForeColor = Color.Black
            End If
        End If

        cliente.empresa = empresas

        '   TIPO CLIENTE - OBLIGATORIO PARA CLIENTE       
        If IsDBNull(cboxVentasTipoCliente.SelectedValue) Then
            If cliente_CP = 1 Then
                show_message("Advertencia", "Falta información")
                lblVentasTipoCliente.ForeColor = Color.Red
                Return False
            Else
                tipoCliente.tipoclienteid = 0
                lblVentasTipoCliente.ForeColor = Color.Black
            End If
        Else
            If cboxVentasTipoCliente.SelectedValue = 0 Then
                If cliente_CP = 1 Then
                    show_message("Advertencia", "Falta información")
                    lblVentasTipoCliente.ForeColor = Color.Red
                    Return False
                Else
                    tipoCliente.tipoclienteid = 0
                    lblVentasTipoCliente.ForeColor = Color.Black
                End If
            Else
                tipoCliente.tipoclienteid = cboxVentasTipoCliente.SelectedValue
                lblVentasTipoCliente.ForeColor = Color.Black
            End If
        End If

        ''valida que uso de CFDI sea obligatorio
        If cmbVentasUsoCFDI.SelectedValue Is Nothing Then
            show_message("Advertencia", "Falta información")
            lblVentasUsoCFDI.ForeColor = Color.Red
            Return False
        Else

            If IsDBNull(cmbVentasUsoCFDI.SelectedValue) Then
                show_message("Advertencia", "Falta información")
                lblVentasUsoCFDI.ForeColor = Color.Red
                Return False
            Else
                If cmbVentasUsoCFDI.SelectedValue = "0" Then
                    show_message("Advertencia", "Falta información")
                    lblVentasUsoCFDI.ForeColor = Color.Red
                    Return False
                Else
                    lblVentasUsoCFDI.ForeColor = Color.Black
                End If
            End If
        End If


        cliente.tipocliente = tipoCliente

        cliente.clienteid = CInt(lblClienteSAYID_Int.Text)

        cliente.PedidoStockWeb = chkPedidoStock.Checked

        cliente.PuedeApartar = chkPuedeApartar.Checked

        Try
            clienteBU.editarCliente(cliente, Nothing, 2, chkPedidosVirtuales.Checked, chkEnviarPedidoEscaneado.Checked)
            ''EDITAR USO DE CFDI
            Dim clienteDatosBu As New Negocios.ClientesDatosBU
            clienteDatosBu.editarUsoCFDICliente(CInt(lblClienteSAYID_Int.Text), cmbVentasUsoCFDI.SelectedValue)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function editar_Ventas_Ventas_PoliticaVentas() As Boolean

        Dim PoliticasVentasBU As New Negocios.VentasPoliticasBU
        Dim PoliticasVentas As New Entidades.PoliticaVenta
        Dim cliente As New Entidades.Cliente

        If txtVentasNotas.TextLength < 1 Then
            PoliticasVentas.notasventas = Nothing
        Else
            PoliticasVentas.notasventas = txtVentasNotas.Text
        End If

        If chboxVentasConfirmarPedido.Checked Then
            PoliticasVentas.confirmarpedido = True
            PoliticasVentas.horasconfirmapedido = CInt(numVentasHorasConfirmarPedido.Value)
        Else
            PoliticasVentas.confirmarpedido = False
            PoliticasVentas.horasconfirmapedido = 0
        End If

        PoliticasVentas.importemaxventa = numVentasImporteMaximo.Value

        cliente.clienteid = cboxClienteCliente.SelectedValue
        PoliticasVentas.cliente = cliente

        If chboxEnviarCorreoConfirmacionPedido.Checked Then
            PoliticasVentas.correoConfirmacionPedido = True
        Else
            PoliticasVentas.correoConfirmacionPedido = False
        End If

        If rbtnApartadoPorPartida.Checked Then
            PoliticasVentas.tipoApartado = 1
        ElseIf rbtnApartadoPorMercancia.Checked Then
            PoliticasVentas.tipoApartado = 2
        End If

        'PoliticasVentas.renglonesFacturar = nudVentasRenglonesFacturar.Value

        'If PoliticasVentas.renglonesFacturar < 0 Then
        '    PoliticasVentas.renglonesFacturar = 0
        'End If

        Try
            PoliticasVentasBU.editarVentasPoliticas(PoliticasVentas, 1)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function alta_Ventas_Cobranza_InfoCliente() As Boolean

        Dim clientesDatosBU As New Negocios.ClientesDatosBU
        Dim InfoClienteCobranza As New Entidades.InformacionClienteCobranza
        Dim cliente As New Entidades.Cliente

        InfoClienteCobranza.facturar = nudVentasPorcentajeAFacturar.Value
        InfoClienteCobranza.documentar = nudVentasPorcentajeADocumentar.Value
        cliente.clienteid = CInt(lblClienteSAYID_Int.Text)
        InfoClienteCobranza.cliente = cliente

        Try
            clientesDatosBU.editarCobranzaInfoCliente(InfoClienteCobranza, 1)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function alta_Ventas_Ventas_ValidacionCliente(validacionStatus As Integer) As Boolean

        Dim clientesBU As New Negocios.ClientesBU
        Dim validacion As New Entidades.Validacion
        Dim validaciontipo As New Entidades.ValidacionTipo
        Dim colaborador As New Entidades.Colaborador
        Dim cliente As New Entidades.Cliente

        If cboxVentasValidador.SelectedValue = 0 Then
            Return False
        Else

            ' @clienteid AS INTEGER
            cliente.clienteid = CInt(lblClienteSAYID_Int.Text)
            validacion.registro = cliente
            ',@colaboradorid AS INTEGER
            colaborador.PColaboradorid = cboxVentasValidador.SelectedValue
            validacion.colaborador = colaborador
            ',@validacionstatusid AS INTEGER
            validacion.validacionestatus = validacionStatus
            ',@validaciontipoid AS INTEGER
            validaciontipo.validaciontipoid = 1 'vati_validaciontipoid	= 1	, vati_nombre = INFORMACIÓN VENTAS EN FICHA TÉCNICA DE CLIENTE                                                      
            validacion.validaciontipo = validaciontipo
            ',@validacionfecha_ventas AS DATETIME
            validacion.fechavalidacion = dateVentasValidacionFecha.Value
            ',@comentario AS VARCHAR(150)
            If txtVentasValidacionComentarios.TextLength < 1 Then
                show_message("Advertencia", "Falta información")
                lblVentasValidacionComentarios.ForeColor = Color.Red
                Return False
            Else
                validacion.comentario = txtVentasValidacionComentarios.Text
                lblVentasValidacionComentarios.ForeColor = Color.Black
            End If

            Try
                clientesBU.AltaValidacionCliente(validacion, 0)
                If validacionStatus = 1 Then
                    show_message("Exito", "Validación de ventas aprobada")

                ElseIf validacionStatus = 2 Then
                    show_message("Exito", "Validación de ventas rechazada")
                End If
                ''Este proceso se efecuta unicamente en COMERCIALIZADOR actualmente
                Dim ListaColaborador As New List(Of Integer)

                'ListaColaborador.Add(cboxClienteVendedor.SelectedValue)
                ListaColaborador.Add(cboxClienteAtnClientes.SelectedValue)

                enviar_correo_validacion(43, "ENVIO_ALTA_VALIDACION_FTC", ListaColaborador, validacion)

                recuperar_datos_Panel_Ventas(CInt(lblClienteSAYID_Int.Text))
                Return True
            Catch ex As Exception
                Return False
            End Try

        End If

    End Function

    Public Sub recuperar_datos_Panel_Ventas(clienteID As Integer)

        limpiarControles(pnlFormVentas)
        asignaStatusControles(pnlFormVentas, False)

        If rbtnClienteStatusInactivo.Checked Then
            btnEditarVentas.Enabled = False
        Else
            If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
                btnEditarVentas.Enabled = True
            Else

                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
                    btnEditarVentas.Enabled = True
                Else
                    btnEditarVentas.Enabled = False
                End If
            End If
        End If

       

        'CLIENTE
        cboxVentasEmpresa.DropDownStyle = ComboBoxStyle.Simple
        cboxVentasTipoCliente.DropDownStyle = ComboBoxStyle.Simple

        Dim clienteBU As New Negocios.ClientesBU
        Dim cliente As New DataTable
        cliente = clienteBU.Datos_TablaCliente(clienteID)
        If cliente.Rows.Count > 0 Then

            If IsDBNull(cliente.Rows(0).Item("clie_empresaid")) Then
                cboxVentasEmpresa.SelectedValue = 0
            Else
                cboxVentasEmpresa.SelectedValue = CInt(cliente.Rows(0).Item("clie_empresaid"))
                IdEmpresaVentas = CInt(cliente.Rows(0).Item("clie_empresaid"))
            End If

            If IsDBNull(cliente.Rows(0).Item("clie_tipoclienteid")) Then
                cboxVentasTipoCliente.SelectedValue = 0
            Else
                cboxVentasTipoCliente.SelectedValue = CInt(cliente.Rows(0).Item("clie_tipoclienteid"))
            End If

            chkPedidoStock.Checked = cliente.Rows(0).Item("clie_pedidostockweb")
            chkPuedeApartar.Checked = cliente.Rows(0).Item("clie_puedeapartarPPCP")
        End If

        'POLITICA VENTA

        Dim VentasPoliticasBU As New Negocios.VentasPoliticasBU
        Dim PoliticasVentas As New DataTable
        PoliticasVentas = VentasPoliticasBU.Datos_TablaPoliticaVenta(clienteID)

        If PoliticasVentas.Rows.Count > 0 Then
            If IsDBNull(PoliticasVentas.Rows(0).Item("pove_notasventas")) Then
                txtVentasNotas.Text = String.Empty
            Else
                txtVentasNotas.Text = CStr(PoliticasVentas.Rows(0).Item("pove_notasventas"))
            End If
            chboxVentasConfirmarPedido.Checked = CBool(PoliticasVentas.Rows(0).Item("pove_confirmarpedido"))
            numVentasHorasConfirmarPedido.Value = CDec(PoliticasVentas.Rows(0).Item("pove_horasconfirmapedido"))
            chboxEnviarCorreoConfirmacionPedido.Checked = CBool(PoliticasVentas.Rows(0).Item("pove_enviarcorreoconfirmacionpedido"))

            If IsDBNull(PoliticasVentas.Rows(0).Item("pove_tipoapartado")) Then
                rbtnApartadoPorPartida.Checked = True
            Else
                If CInt(PoliticasVentas.Rows(0).Item("pove_tipoapartado")) = 1 Then
                    rbtnApartadoPorPartida.Checked = True
                    rbtnApartadoPorMercancia.Checked = False
                Else
                    rbtnApartadoPorMercancia.Checked = True
                    rbtnApartadoPorPartida.Checked = False
                End If
            End If


            'If IsDBNull(PoliticasVentas.Rows(0).Item("pove_importemaxfactura")) Then
            '    numVentasImporteMaximo.Value = Decimal.Zero
            'Else
            '    numVentasImporteMaximo.Value = CDec(PoliticasVentas.Rows(0).Item("pove_importemaxfactura"))
            'End If

            'If IsDBNull(PoliticasVentas.Rows(0).Item("pove_renglonesporfactura")) Then
            '    nudVentasRenglonesFacturar.Value = 0
            'Else
            '    nudVentasRenglonesFacturar.Value = PoliticasVentas.Rows(0).Item("pove_renglonesporfactura")
            'End If

            'txtVentasIncoterm.Text = CStr(PoliticasVentas.Rows(0).Item("pove_incoterm"))
        End If

        'INFO CLIENTES COBRANZA
        Dim clientesDatosBU As New Negocios.ClientesDatosBU
        Dim InfoClienteCobranza As New DataTable
        InfoClienteCobranza = clientesDatosBU.Datos_TablaCobranzaInfoCliente(clienteID)
        If InfoClienteCobranza.Rows.Count > 0 Then

            If IsDBNull(InfoClienteCobranza.Rows(0).Item("iccl_facturar")) Then
                nudVentasPorcentajeAFacturar.Value = Decimal.Zero
            Else
                nudVentasPorcentajeAFacturar.Value = CDec(InfoClienteCobranza.Rows(0).Item("iccl_facturar"))
            End If

            If IsDBNull(InfoClienteCobranza.Rows(0).Item("iccl_documentar")) Then
                nudVentasPorcentajeADocumentar.Value = Decimal.Zero
            Else
                nudVentasPorcentajeADocumentar.Value = CDec(InfoClienteCobranza.Rows(0).Item("iccl_documentar"))
            End If

        End If


        ''INFO CLIENTES VENTAS 
        Dim dtInfoClienteVentas As New DataTable
        dtInfoClienteVentas = clientesDatosBU.RecuperarVentas_InfoCliente(clienteID)
        If dtInfoClienteVentas.Rows.Count > 0 Then
            If Not IsDBNull(dtInfoClienteVentas.Rows(0).Item("ivcl_pedidosvirtuales")) Then
                chkPedidosVirtuales.Checked = dtInfoClienteVentas.Rows(0).Item("ivcl_pedidosvirtuales")
            Else
                chkPedidosVirtuales.Checked = False
            End If

            If Not IsDBNull(dtInfoClienteVentas.Rows(0).Item("ivcl_enviapedidoscanneado")) Then
                chkEnviarPedidoEscaneado.Checked = dtInfoClienteVentas.Rows(0).Item("ivcl_enviapedidoscanneado")
            Else
                chkEnviarPedidoEscaneado.Checked = False
            End If
        End If


        'VALIDACION

        Dim validacionBU As New Framework.Negocios.ValidacionBU
        Dim usuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim tabla As New DataTable
        tabla = validacionBU.Validacion_Cliente(clienteID, 1)
        If tabla.Rows.Count > 0 Then


            gboxVentasValidacion.Enabled = False
            ListaValidadorVentas(0, 1)
            cboxVentasValidador.SelectedValue = CInt(tabla.Rows(0).Item("vali_colaboradorid"))

            dateVentasValidacionFecha.Value = CDate(tabla.Rows(0).Item("vali_fechavalidacion"))

            txtVentasValidacionComentarios.Text = CStr(tabla.Rows(0).Item("vali_comentario"))

            If CInt(tabla.Rows(0).Item("vaes_validacionestatusid")) = 1 Then
                rbtnVentasValidacionStatusAutorizado.Checked = True
                rbtnVentasValidacionStatusRechazado.Checked = False
            ElseIf CInt(tabla.Rows(0).Item("vaes_validacionestatusid")) = 2 Then
                rbtnVentasValidacionStatusAutorizado.Checked = False
                rbtnVentasValidacionStatusRechazado.Checked = True
            End If

        End If

        ''uso CFDI
        Dim dtUsoCfdi As New DataTable
        Dim personaFisica As Int32 = 0
        Dim personaMoral As Int32 = 0
        Dim claveCfdi As String = String.Empty

        If rbtnClientePersonaFisica.Checked = True Then
            personaFisica = 1
            personaMoral = 0
        Else
            personaFisica = 0
            personaMoral = 1
        End If
        dtUsoCfdi = clientesDatosBU.consultaUsoCFDI(personaFisica, personaMoral)

        If dtUsoCfdi.Rows.Count > 0 Then
            cmbVentasUsoCFDI.DataSource = dtUsoCfdi
            cmbVentasUsoCFDI.DisplayMember = "cfus_descripcion"
            cmbVentasUsoCFDI.ValueMember = "cfus_clave_usocfdi"
        End If

        claveCfdi = clientesDatosBU.consultaUsoCFDIPorCliente(clienteID)

        If claveCfdi <> "" Then
            cmbVentasUsoCFDI.SelectedValue = claveCfdi
        End If

    End Sub


#Region "MAXIMIZAR GROUPBOX"

    Private Sub gboxVentasContacto_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gboxVentasContacto.MouseDoubleClick
        If gboxVentasContacto.Dock = DockStyle.Fill Then
            gboxVentasContacto.Dock = DockStyle.None
            gboxVentasDocumentos.Visible = True
            gboxVentasVendedores.Visible = True
            gboxVentasPoliticas.Visible = True
            gboxVentasPoliticaVenta.Visible = True
            gboxVentasContabilidad.Visible = True
            gboxVentasNotas.Visible = True
            pnlVentasBotones.Visible = True
            gboxTipoApartado.Visible = True
        Else
            gboxVentasContacto.Dock = DockStyle.Fill
            gboxVentasDocumentos.Visible = False
            gboxVentasVendedores.Visible = False
            gboxVentasPoliticas.Visible = False
            gboxVentasPoliticaVenta.Visible = False
            gboxVentasContabilidad.Visible = False
            gboxVentasNotas.Visible = False
            pnlVentasBotones.Visible = False
            gboxTipoApartado.Visible = False
        End If
    End Sub

    Private Sub gboxVentasDocumentos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gboxVentasDocumentos.MouseDoubleClick
        If gboxVentasDocumentos.Dock = DockStyle.Fill Then
            gboxVentasDocumentos.Dock = DockStyle.None
            gboxVentasContacto.Visible = True
            gboxVentasVendedores.Visible = True
            gboxVentasPoliticaVenta.Visible = True
            gboxVentasContabilidad.Visible = True
            gboxVentasNotas.Visible = True
            pnlVentasBotones.Visible = True
            gboxTipoApartado.Visible = True
        Else
            gboxVentasDocumentos.Dock = DockStyle.Fill
            gboxVentasContacto.Visible = False
            gboxVentasVendedores.Visible = False
            gboxVentasPoliticaVenta.Visible = False
            gboxVentasContabilidad.Visible = False
            gboxVentasNotas.Visible = False
            pnlVentasBotones.Visible = False
            gboxTipoApartado.Visible = False
        End If
    End Sub

    Private Sub gboxVentasVendedores_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gboxVentasVendedores.MouseDoubleClick
        If gboxVentasVendedores.Dock = DockStyle.Fill Then
            gboxVentasVendedores.Dock = DockStyle.None
            gboxVentasContacto.Visible = True
            gboxVentasDocumentos.Visible = True
            gboxVentasPoliticaVenta.Visible = True
            gboxVentasContabilidad.Visible = True
            gboxVentasNotas.Visible = True
            pnlVentasBotones.Visible = True
            gboxTipoApartado.Visible = True
        Else
            gboxVentasVendedores.Dock = DockStyle.Fill
            gboxVentasContacto.Visible = False
            gboxVentasDocumentos.Visible = False
            gboxVentasPoliticaVenta.Visible = False
            gboxVentasContabilidad.Visible = False
            gboxVentasNotas.Visible = False
            pnlVentasBotones.Visible = False
            gboxTipoApartado.Visible = False
        End If
    End Sub

    Private Sub gboxVentasPoliticas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gboxVentasPoliticas.MouseDoubleClick
        If gboxVentasPoliticas.Dock = DockStyle.Fill Then
            gboxVentasPoliticas.Dock = DockStyle.None
            gboxVentasDocumentos.Visible = True
            gboxVentasVendedores.Visible = True
            gboxVentasPoliticaVenta.Visible = True
            gboxVentasContabilidad.Visible = True
            gboxVentasNotas.Visible = True
            pnlVentasBotones.Visible = True
            gboxVentasContacto.Visible = True
            gboxTipoApartado.Visible = True
        Else
            gboxVentasPoliticas.Dock = DockStyle.Fill
            gboxVentasDocumentos.Visible = False
            gboxVentasVendedores.Visible = False
            gboxVentasPoliticaVenta.Visible = False
            gboxVentasContabilidad.Visible = False
            gboxVentasNotas.Visible = False
            pnlVentasBotones.Visible = False
            gboxVentasContacto.Visible = False
            gboxTipoApartado.Visible = False
        End If
    End Sub

    Private Sub gboxVentasValidacionHistorial_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gboxVentasValidacionHistorial.MouseDoubleClick
        If gboxVentasValidacionHistorial.Dock = DockStyle.Fill Then
            gboxVentasValidacionHistorial.Dock = DockStyle.None
            gboxVentasValidacion.Visible = True
        Else
            gboxVentasValidacionHistorial.Dock = DockStyle.Fill
            gboxVentasValidacion.Visible = False
        End If
    End Sub


#End Region

#Region "Grids"

#Region "GRID_Documentacion"
    Private Sub btnAgregarDocumentacion_Ventas_Click(sender As Object, e As EventArgs) Handles btnAgregarDocumentacion_Ventas.Click
        Dim grid As DataTable = gridDocumentos.DataSource
        Dim tipoDocumento As UltraGridColumn = gridDocumentos.DisplayLayout.Bands(0).Columns(3)

        gridDocumentos.Focus()
        LimpiarFiltrosGrid(gridDocumentos)

        grid.Rows.Add(0, 0, "--Selecciona--", 0, CInt(lblClienteSAYID_Int.Text), 0, 0, True)

        gridDocumentos.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True
        'gridDocumentos.DisplayLayout.Rows(grid.Rows.Count - 1).Selected = True

        Try
            gridDocumentos.ActiveRow.Activation = Activation.AllowEdit
            If AreaOperativa = 3 Then
                gridDocumentos.ActiveCell = gridDocumentos.ActiveRow.Cells("ACTIVO")
            Else
                gridDocumentos.ActiveCell = gridDocumentos.ActiveRow.Cells("ACTIVO")
                gridDocumentos.ActiveCell.Selected = True
            End If
            gridDocumentos.ActiveCell.Activation = Activation.AllowEdit
        Catch ex As Exception

        End Try

        gridDocumentos.PerformAction(UltraGridAction.ToggleCellSel, False, False)
        gridDocumentos.PerformAction(UltraGridAction.EnterEditMode, False, False)
    End Sub

#End Region

#Region "Grid_Ventas_Vendedores"

    Public Sub poblar_gridVentasVendedores(clienteID As Integer)

        gridVentasVendedores.DataSource = Nothing

        Dim ClientesDatosBU As New Negocios.ClientesDatosBU
        Dim ClientesBU As New Negocios.ClientesBU
        Dim marca_vendedor_empresa As New DataTable

        marca_vendedor_empresa = ClientesDatosBU.Datos_TablaVendedoresCliente(clienteID)

        Dim marca As New DataTable
        Dim agente As New DataTable
        Dim empresa As New DataTable
        Dim dtContacto As New DataTable
        Dim dtEmail As New DataTable

        'Dim vlMarca As New ValueList
        'Dim vlAgente As New ValueList
        'Dim vlEmpresa As New ValueList

        'marca = ClientesBU.ListaMarca()
        'agente = ClientesBU.ListaVendedor()
        'empresa = ClientesBU.ListaEmpresa()

        'For Each fila As DataRow In marca.Rows
        '    vlMarca.ValueListItems.Add(fila.Item("marc_marcaid"), fila.Item("marc_descripcion"))
        'Next

        'For Each fila As DataRow In agente.Rows
        '    vlAgente.ValueListItems.Add(fila.Item("codr_colaboradorid"), fila.Item("codr_nombre_completo"))
        'Next

        'For Each fila As DataRow In empresa.Rows
        '    vlEmpresa.ValueListItems.Add(fila.Item("empr_empresaid"), fila.Item("empr_nombre"))
        'Next

        gridVentasVendedores.DataSource = marca_vendedor_empresa
        'gridVentasVendedores.DisplayLayout.Bands(0).Columns(1).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        'gridVentasVendedores.DisplayLayout.Bands(0).Columns(1).ValueList = vlMarca
        'gridVentasVendedores.DisplayLayout.Bands(0).Columns(2).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        'gridVentasVendedores.DisplayLayout.Bands(0).Columns(2).ValueList = vlAgente
        'gridVentasVendedores.DisplayLayout.Bands(0).Columns(3).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        'gridVentasVendedores.DisplayLayout.Bands(0).Columns(3).ValueList = vlEmpresa
        'gridVentasVendedores.DisplayLayout.Bands(0).Columns.Add()

        gridVentasVendedoresDiseno(gridVentasVendedores)
        gridVentasVendedores.DisplayLayout.Bands(0).Columns("BLOQUEO C").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

    End Sub


    Private Sub gridVentasVendedoresDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Bands(0).Columns("ID").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("EMPRESA").Hidden = True

        'asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        For Each row In grid.Rows
            If ModoEdicion = False Then
                row.Activation = Activation.NoEdit
            End If
        Next

        grid.DisplayLayout.Bands(0).Columns("MARCA").Header.Caption = "*MARCA"
        grid.DisplayLayout.Bands(0).Columns("ACTIVO").Header.Caption = "*ACTIVO"
        grid.DisplayLayout.Bands(0).Columns("AGENTE DE VENTAS").Header.Caption = "*AGENTE DE VENTAS"


        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        'If ModoEdicion = True Then
        '    For Each row As UltraGridRow In gridVentasVendedores.Rows
        '        gridVentasVendedores.DisplayLayout.Rows(row.Index).Activation = Activation.NoEdit
        '        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.n
        '        gridVentasVendedores.DisplayLayout.Rows(row.Index).Cells("Id").Activation = Activation.NoEdit
        '        gridVentasVendedores.DisplayLayout.Rows(row.Index).Cells("MARCA").Activation = Activation.NoEdit
        '        gridVentasVendedores.DisplayLayout.Rows(row.Index).Cells("AGENTE DE VENTAS").Activation = Activation.NoEdit
        '        gridVentasVendedores.DisplayLayout.Rows(row.Index).Cells("EMPRESA").Activation = Activation.NoEdit
        '        gridVentasVendedores.DisplayLayout.Rows(row.Index).Cells("CONTACTO").Activation = Activation.NoEdit
        '        gridVentasVendedores.DisplayLayout.Rows(row.Index).Cells("EMAIL").Activation = Activation.NoEdit
        '        gridVentasVendedores.DisplayLayout.Rows(row.Index).Cells("ACTIVO").Activation = Activation.NoEdit
        '    Next
        'Else
        '    For Each row In gridVentasVendedores.Rows
        '        gridVentasVendedores.DisplayLayout.Rows(row.Index).Activation = Activation.ActivateOnly
        '        gridVentasVendedores.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        '    Next
        'End If
    End Sub


    'Private Sub gridVentasVendedores_Enter(sender As Object, e As EventArgs) Handles gridVentasVendedores.Enter
    '    Dim ClientesDatosBU As New Negocios.ClientesDatosBU
    '    Dim ClientesBU As New Negocios.ClientesBU
    '    Dim marca As New DataTable
    '    Dim agente As New DataTable
    '    Dim empresa As New DataTable
    '    Dim vlMarca As New ValueList
    '    Dim vlAgente As New ValueList
    '    Dim vlEmpresa As New ValueList

    '    marca = ClientesBU.ListaMarca()
    '    agente = ClientesBU.ListaVendedor()

    '    For Each fila As DataRow In marca.Rows
    '        vlMarca.ValueListItems.Add(fila.Item("marc_marcaid"), fila.Item("marc_descripcion"))
    '    Next
    '    For Each fila As DataRow In agente.Rows
    '        vlAgente.ValueListItems.Add(fila.Item("codr_colaboradorid"), fila.Item("codr_nombre_completo"))
    '    Next

    '    gridVentasVendedores.DisplayLayout.Bands(0).Columns(1).ValueList = vlMarca
    '    gridVentasVendedores.DisplayLayout.Bands(0).Columns(2).ValueList = vlAgente

    'End Sub


    Private Sub gridVentasVendedores_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridVentasVendedores.DoubleClickHeader

        If Me.gridVentasVendedores.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.gridVentasVendedores.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.gridVentasVendedores.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.gridVentasVendedores.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.gridVentasVendedores.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.gridVentasVendedores.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.gridVentasVendedores.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If

    End Sub


    Private Sub btnAgregarAgente_Marcas_Click(sender As Object, e As EventArgs) Handles btnAgregarAgente_Marcas.Click
        Dim grid As DataTable = gridVentasVendedores.DataSource

        If IdEmpresaVentas > 0 Then

            gridVentasVendedores.Focus()
            LimpiarFiltrosGrid(gridVentasVendedores)

            grid.Rows.Add(0, "--Selecciona--", "--Selecciona--", IdEmpresaVentas, "", "", False)

            gridVentasVendedores.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True
            Try
                'gridVentasVendedores.ActiveRow.Activation = Activation.AllowEdit
                gridVentasVendedores.ActiveCell = gridVentasVendedores.ActiveRow.Cells("MARCA")
                'gridVentasVendedores.ActiveCell.Activation = Activation.AllowEdit
                gridVentasVendedores.ActiveRow.Cells("CONTACTO").Activation = Activation.NoEdit
                gridVentasVendedores.ActiveRow.Cells("EMAIL").Activation = Activation.NoEdit
            Catch ex As Exception

            End Try
            gridVentasVendedores.PerformAction(UltraGridAction.ToggleCellSel, False, False)
            gridVentasVendedores.PerformAction(UltraGridAction.EnterEditMode, False, False)
            gridVentasVendedores.DisplayLayout.Override.CellClickAction = CellClickAction.Edit

        Else
            Mensajes_Y_Alertas("ADVERTENCIA", "No es posible agregar un contacto de ventas cuando no se tiene referencia de la empresa a la que se factura.")
        End If
    End Sub
    ''se comenta ya que no debe de haber ninguna funcionalidad para este grid

    'Private Sub gridVentasVendedores_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridVentasVendedores.KeyPress

    '    If e.KeyChar = ChrW(Keys.Enter) Then

    '        Dim NextRowIndex As Integer = gridVentasVendedores.ActiveRow.Index + 1
    '        Try
    '            gridVentasVendedores.DisplayLayout.Rows(NextRowIndex).Activated = True
    '            gridVentasVendedores.DisplayLayout.Rows(NextRowIndex).Selected = True
    '        Catch ex As Exception
    '            gridVentasVendedores.ActiveRow.Activated = False
    '        End Try

    '    End If

    '    If e.KeyChar = ChrW(Keys.Escape) Then
    '        poblar_gridVentasVendedores(CInt(cboxClienteCliente.SelectedValue))
    '        gridVentasVendedores.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '    End If

    'End Sub


    'Private Sub gridVentasVendedores_AfterCellListCloseUp(sender As Object, e As CellEventArgs) Handles gridVentasVendedores.AfterCellListCloseUp
    '    'SE COMENTA PARA QUITAR VALIDACION DE MARCA YA REGISTRADA

    '    If e.Cell.Column.Key = "AGENTE DE VENTAS" Then
    '        Dim valor As String = e.Cell.Text
    '        Dim i As Integer = gridVentasVendedores.ActiveRow.Index
    '        For Each row In gridVentasVendedores.Rows
    '            For Each cell In row.Cells
    '                If cell.Column.Key = "AGENTE DE VENTAS" Then
    '                    If Not i = row.Index Then
    '                        If valor.Equals(cell.Text) Then
    '                            show_message("Aviso", "El agente seleccionado ya está asignado al cliente y a la marca")
    '                            gridVentasVendedores.Rows(i).Cells("AGENTE DE VENTAS").Value = "--Selecciona--"
    '                            Return
    '                        End If
    '                    End If
    '                End If
    '            Next
    '        Next
    '    End If
    'End Sub


    'Private Sub gridVentasVendedores_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles gridVentasVendedores.BeforeCellUpdate
    '    If gridVentasVendedores.ActiveRow.IsDataRow Then
    '        If e.Cell.Column.ToString = "MARCA" Then
    '            If gridVentasVendedores.ActiveRow.Cells("MARCA").Value = gridVentasVendedores.ActiveRow.Cells("MARCA").Text Then
    '                e.Cancel = True
    '            End If
    '        ElseIf e.Cell.Column.ToString = "AGENTE DE VENTAS" Then
    '            If gridVentasVendedores.ActiveRow.Cells("AGENTE DE VENTAS").Value = gridVentasVendedores.ActiveRow.Cells("AGENTE DE VENTAS").Text Then
    '                e.Cancel = True
    '            End If
    '        End If
    '    End If
    'End Sub


    'Private Function ValidarCamposVaciosGrid_ClientesVendedores() As Boolean
    '    ValidarCamposVaciosGrid_ClientesVendedores = False
    '    If gridVentasVendedores.ActiveRow.Cells("MARCA").Text = "--Selecciona--" And gridVentasVendedores.ActiveRow.Cells("agente de ventas").Text = "--Selecciona--" Then
    '        Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione una marca y un agente de ventas para poder guardar la información del agente de ventas.")
    '        ValidarCamposVaciosGrid_ClientesVendedores = True
    '    ElseIf gridVentasVendedores.ActiveRow.Cells("MARCA").Text = "--Selecciona--" Then
    '        Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione una marca para poder guardar la información del agente de ventas.")
    '        ValidarCamposVaciosGrid_ClientesVendedores = True
    '    ElseIf gridVentasVendedores.ActiveRow.Cells("AGENTE DE VENTAS").Text = "--Selecciona--" Then
    '        Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione una agente de ventas para poder guardar la información del agente de ventas.")
    '        ValidarCamposVaciosGrid_ClientesVendedores = True
    '    End If

    '    Return ValidarCamposVaciosGrid_ClientesVendedores

    'End Function


    'Private Function AgregarEditarClientesVendedores()
    '    If ValidarCamposVaciosGrid_ClientesVendedores() = False Then
    '        If gridVentasVendedores.ActiveRow.DataChanged Then

    '            Dim objBU As New Negocios.ClientesDatosBU

    '            Dim clientemarcaagenteempresaid As Integer
    '            Dim clienteid As Integer
    '            Dim marcaid As Integer
    '            Dim colaboradorid_agente As Integer
    '            Dim empresaid As Integer
    '            Dim activo As Boolean

    '            Dim row As UltraGridRow = gridVentasVendedores.ActiveRow

    '            clientemarcaagenteempresaid = CInt(gridVentasVendedores.ActiveRow.Cells(0).Value)
    '            clienteid = CInt(lblClienteSAYID_Int.Text)
    '            marcaid = row.Cells(1).Column.ValueList.GetValue(gridVentasVendedores.ActiveRow.Cells(1).Text, 0)
    '            colaboradorid_agente = row.Cells(2).Column.ValueList.GetValue(gridVentasVendedores.ActiveRow.Cells(2).Text, 0)
    '            empresaid = row.Cells("EMPRESA").Column.ValueList.GetValue(gridVentasVendedores.ActiveRow.Cells("EMPRESA").Text, 0)
    '            activo = CBool(gridVentasVendedores.ActiveRow.Cells(6).Value)
    '            Try
    '                If clientemarcaagenteempresaid = 0 Then
    '                    If Mensajes_Y_Alertas("CONFIRMACION", "¿Esta seguro que desea agregar este agente de ventas?") Then
    '                        objBU.Alta_ClienteMarcaAgenteEmpresa(clienteid, marcaid, colaboradorid_agente, empresaid)
    '                    End If
    '                Else
    '                    If Mensajes_Y_Alertas("CONFIRMACION", "¿Esta seguro que desea actualizar este agente de ventas?") Then
    '                        objBU.Editar_ClienteMarcaAgenteEmpresa(clientemarcaagenteempresaid, clienteid, marcaid, colaboradorid_agente, empresaid, activo)
    '                    End If
    '                End If

    '            Catch ex As Exception
    '                Mensajes_Y_Alertas("ERROR", "Ocurrio un error inesperado. Error: " + ex.Message)
    '            End Try

    '            poblar_gridVentasVendedores(CInt(cboxClienteCliente.SelectedValue))
    '        End If
    '    End If
    'End Function


    ' Private Sub gridVentasVendedores_MouseClick(sender As Object, e As MouseEventArgs) Handles gridVentasVendedores.MouseClick

    'If rbtnClienteStatusInactivo.Checked Then Return

    'Dim mainElement As UIElement
    'Dim element As UIElement
    'Dim screenPoint As Point
    'Dim clientPoint As Point
    'Dim row As UltraGridRow
    'Dim cell As UltraGridCell

    'mainElement = Me.gridVentasVendedores.DisplayLayout.UIElement
    'screenPoint = Control.MousePosition
    'clientPoint = Me.gridVentasVendedores.PointToClient(screenPoint)
    'element = mainElement.ElementFromPoint(clientPoint)

    'If element Is Nothing Then Return

    'row = element.GetContext(GetType(UltraGridRow))

    'If Not row Is Nothing Then
    '    cell = element.GetContext(GetType(UltraGridCell))

    '    If Not cell Is Nothing Then

    '        If e.Button <> Windows.Forms.MouseButtons.Right Then Return
    '        Dim cms = New ContextMenuStrip

    '        Dim item1 = cms.Items.Add("Nuevo")
    '        item1.Tag = 1
    '        AddHandler item1.Click, AddressOf gridVentasVendedores_menuChoice

    '        Dim item2 = cms.Items.Add("Editar")
    '        item2.Tag = 2
    '        AddHandler item2.Click, AddressOf gridVentasVendedores_menuChoice

    '        If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
    '            cms.Show(Control.MousePosition)
    '        Else
    '            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
    '                cms.Show(Control.MousePosition)
    '            End If
    '        End If

    '    End If
    'End If

    'End Sub


    'Private Sub gridVentasVendedores_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridVentasVendedores.BeforeRowDeactivate
    '    Dim objBU As New Framework.Negocios.ContactosBU
    '    If ModoEdicion = True Then
    '        If gridVentasVendedores.ActiveRow.IsDataRow Then
    '            If gridVentasVendedores.ActiveRow.DataChanged Then
    '                AgregarEditarClientesVendedores()
    '            Else
    '                If ValidarCamposVaciosGrid_ClientesVendedores() Then
    '                    e.Cancel = True
    '                End If

    '            End If
    '        End If
    '    End If
    '    Me.Cursor = Cursors.Default
    'End Sub


    'Private Sub gridVentasVendedores_Leave(sender As Object, e As EventArgs) Handles gridVentasVendedores.Leave
    '    If Not IsNothing(gridVentasVendedores.ActiveRow) Then
    '        If gridVentasVendedores.ActiveRow.IsDataRow Then
    '            If gridVentasVendedores.ActiveRow.DataChanged _
    '                Or gridVentasVendedores.ActiveRow.Cells("MARCA").Text = "--Selecciona--" _
    '                Or gridVentasVendedores.ActiveRow.Cells("AGENTE DE VENTAS").Text = "--Selecciona--" Then
    '                If ValidarCamposVaciosGrid_ClientesVendedores() = True Then
    '                    gridVentasVendedores.Focus()
    '                    Return
    '                End If
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub gridVentasVendedores_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles gridVentasVendedores.BeforeRowUpdate


    'End Sub

    'Private Sub gridVentasVendedores_Enter(sender As Object, e As EventArgs) Handles gridVentasVendedores.Enter
    '    Dim objBU As New Negocios.VentasPoliticasBU
    '    Dim TipoDocumento As New DataTable
    '    Dim vlTipoDocumento As New ValueList

    '    TipoDocumento = objBU.TablaTipoDocumentosSegunClaseDocumento(claseDocumento, AreaOperativa)

    '    For Each fila As DataRow In TipoDocumento.Rows
    '        vlTipoDocumento.ValueListItems.Add(fila.Item("tido_tipodocumentoid"), fila.Item("tido_nombre"))
    '    Next


    '    gridVentasDocumentos.DisplayLayout.Bands(0).Columns(2).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
    '    gridVentasDocumentos.DisplayLayout.Bands(0).Columns(2).ValueList = vlTipoDocumento
    'End Sub


    Private Sub gridVentasVendedores_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridVentasVendedores.BeforeRowsDeleted
        e.Cancel = True
    End Sub

#End Region

#Region "Grid_Politicas"
    Private Sub btnAgregarPoliticas_Ventas_Click(sender As Object, e As EventArgs) Handles btnAgregarPoliticas_Ventas.Click
        editando_politica = True
        IniciarEdicionPoliticas()
    End Sub

#End Region

#End Region

    Private Sub btnAgregarAgente_Familia_Click(sender As Object, e As EventArgs) Handles btnAgregarAgente_Familia.Click
        Dim marcasFamilia As New AgenteMarcaFamiliaVentasForm
        marcasFamilia.idCliente = CInt(lblClienteSAYID_Int.Text)
        marcasFamilia.ShowDialog()
        poblar_gridVentasVendedores(CInt(lblClienteSAYID_Int.Text))
    End Sub


    'Private Sub gridVentasVendedores_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles gridVentasVendedores.BeforeRowUpdate
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim objBU As New Framework.Negocios.ContactosBU
    '    If gridVentasVendedores.ActiveRow.IsDataRow Then
    '        If gridVentasVendedores.ActiveRow.DataChanged Then
    '            MsgBox("Entró" & gridVentasVendedores.GetRow(sender.GetHashCode).)
    '            'If gridVentasVendedores.ActiveRow.Cells("BLOQUEO C").Value Then
    '            '    '                    Agregar_EditarDocumento()
    '            '    MsgBox("Entró")
    '            'End If
    '        End If
    '    End If
    '    Me.Cursor = Cursors.Default
    'End Sub

    Private Sub gridVentasVendedores_CellChange(sender As Object, e As CellEventArgs) Handles gridVentasVendedores.CellChange
        Me.Cursor = Cursors.WaitCursor
        Dim objBu As New Negocios.ClientesBU

        If editarMarcaAgenteVentas Then
            Dim row As UltraGridRow = gridVentasVendedores.ActiveRow
            If row Is Nothing Then Return

            If gridVentasVendedores.ActiveRow.IsDataRow Then
                If gridVentasVendedores.ActiveRow.DataChanged Then
                    Dim id As Integer
                    Dim cambio As Boolean
                    Dim Mar As String
                    id = row.Cells.Item(0).Value
                    Mar = row.Cells.Item(1).Value.ToString()
                    cambio = CBool(row.Cells.Item(7).Text)
                    'MsgBox("ID " & id.ToString() & " Marca " & Mar & " Cambio " & cambio.ToString())
                    If Mensajes_Y_Alertas("CONFIRMACION", "¿Desea continuar con el cambio?") Then
                        objBu.EditarMarcaAgenteVentasBloqueo(id, cambio)
                    Else
                        poblar_gridVentasVendedores(CInt(lblClienteSAYID_Int.Text))
                    End If
                End If
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

End Class
