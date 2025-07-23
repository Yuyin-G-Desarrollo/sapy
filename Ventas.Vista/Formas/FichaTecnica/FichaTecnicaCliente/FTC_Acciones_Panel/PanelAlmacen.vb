Imports Infragistics.Win.UltraWinGrid
Imports Tools.Controles

Partial Public Class FichaTecnicaClienteForm

    Private Sub btnGuardarPanelAlmacen_Click(sender As Object, e As EventArgs) Handles btnGuardarAlmacen.Click
        Try
            If Not cumple_info_obligatoria_Panel_Almacen() Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        Try
            If Not editar_Almacen_Ventas_PoliticasEmbarque() Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        Try
            If Not editar_Almacen_Ventas_InfoCliente() Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        Try
            If Not editar_Almacen_Ventas_PoliticasVentas() Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        Try
            If Not editar_Almacen_Ventas_RestriccionCliente() Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        show_message("Exito", "Información guardada con éxito")

        ModoEdicion_Almacen = False
        Activar_Inactivar_grids(gridHorario, ModoEdicion_Almacen)
        CambiarElForeColorControles_Negro(pnlFormAlmacen)
        CambiarElForeColorControles_DodgerBlue(pnlBotonesAlmacen)

        recuperar_datos_Panel_Almacen(CInt(lblClienteSAYID_Int.Text))
    End Sub

    Private Sub btnEditarAlmacen_Click(sender As Object, e As EventArgs) Handles btnEditarAlmacen.Click
        ModoEdicion_Almacen = True
        asignaStatusControles(pnlFormAlmacen, True)
        If rdoLoteCompleto.Checked = True Then
            chboxLoteCompletoTienda.Enabled = True
            chboxLoteCompletoModelo.Enabled = True
            chboxLoteCompletoPiel.Enabled = True
            chboxLoteCompletoColor.Enabled = True
            chboxLoteCompletoCorrida.Enabled = True
            chboxLoteCompletoPedido.Enabled = True
            txtAlmacenNotasEmbarque.ReadOnly = True

        Else
            chboxLoteCompletoTienda.Enabled = False
            chboxLoteCompletoModelo.Enabled = False
            chboxLoteCompletoPiel.Enabled = False
            chboxLoteCompletoColor.Enabled = False
            chboxLoteCompletoCorrida.Enabled = False
            chboxLoteCompletoPedido.Enabled = False
            txtAlmacenNotasEmbarque.ReadOnly = False
        End If
        Activar_Inactivar_grids(gridHorario, ModoEdicion_Almacen)
    End Sub

    Private Sub btnCancelarAlmacen_Click(sender As Object, e As EventArgs) Handles btnCancelarAlmacen.Click
        If Mensajes_Y_Alertas("CONFIRMACION", "Los cambios realizados no se han guardado ¿Desea cancelar los cambios?") Then
            ModoEdicion_Almacen = False
            editando_politica = False
            Activar_Inactivar_grids(gridHorario, ModoEdicion_Almacen)
            recuperar_datos_Panel_Almacen(CInt(lblClienteSAYID_Int.Text))
            'asd
            poblar_gridPolitica(editando_politica, CInt(lblClienteSAYID_Int.Text), gridPolitica)
            CambiarElForeColorControles_Negro(pnlFormAlmacen)
            CambiarElForeColorControles_DodgerBlue(pnlBotonesAlmacen)
        End If
    End Sub

    Public Function cumple_info_obligatoria_Panel_Almacen() As Boolean

        '   ALMACEN- OBLIGATORIO PARA CLIENTE
        If IsDBNull(cboxAlmacenAlmacen.SelectedValue) Then
            If cliente_CP = 1 Then
                show_message("Advertencia", "Falta información")
                lblAlmacenAlmacen.ForeColor = Color.Red
                Return False
            Else
                lblAlmacenAlmacen.ForeColor = Color.Black
            End If
        Else
            If cboxAlmacenAlmacen.SelectedValue = 0 Then
                If cliente_CP = 1 Then
                    show_message("Advertencia", "Falta información")
                    lblAlmacenAlmacen.ForeColor = Color.Red
                    Return False
                Else
                    lblAlmacenAlmacen.ForeColor = Color.Black
                End If
            Else
                lblAlmacenAlmacen.ForeColor = Color.Black
            End If
        End If

        '   TIPO EMPAQUE- OBLIGATORIO PARA CLIENTE
        If IsDBNull(cboxAlmacenTipoEmpaque.SelectedValue) Then
            If cliente_CP = 1 Then
                show_message("Advertencia", "Falta información")
                lblAlmacenTipoEmpaque.ForeColor = Color.Red
                Return False
            Else
                lblAlmacenTipoEmpaque.ForeColor = Color.Black
            End If
        Else
            If cboxAlmacenTipoEmpaque.SelectedValue = 0 Then
                If cliente_CP = 1 Then
                    show_message("Advertencia", "Falta información")
                    lblAlmacenTipoEmpaque.ForeColor = Color.Red
                    Return False
                Else
                    lblAlmacenTipoEmpaque.ForeColor = Color.Black
                End If
            Else
                lblAlmacenTipoEmpaque.ForeColor = Color.Black
            End If
        End If

        '   RESTRICCION DE FACTURACION  - OBLIGATORIO PARA CLIENTE
        If IsDBNull(cboxAlmacenRestricciones.SelectedValue) Then
            If cliente_CP = 1 Then
                show_message("Advertencia", "Falta información")
                lblAlmacenRestricciones.ForeColor = Color.Red
                Return False
            Else
                lblAlmacenRestricciones.ForeColor = Color.Black
            End If
        Else
            If cboxAlmacenRestricciones.SelectedValue = 0 Then
                If cliente_CP = 1 Then
                    show_message("Advertencia", "Falta información")
                    lblAlmacenRestricciones.ForeColor = Color.Red
                    Return False
                Else
                    lblAlmacenRestricciones.ForeColor = Color.Black
                End If
            Else
                lblAlmacenRestricciones.ForeColor = Color.Black
            End If
        End If

        If rdoPartidaCompleta.Checked = False And rdoMercanciaDisponible.Checked = False And rdoLoteCompleto.Checked = False Then
            show_message("Advertencia", "Falta información")
            lblFormaEntrega.ForeColor = Color.Red
            Return False
        ElseIf rdoLoteCompleto.Checked = True And chboxLoteCompletoTienda.Checked = False And chboxLoteCompletoModelo.Checked = False And chboxLoteCompletoPiel.Checked = False And chboxLoteCompletoColor.Checked = False And chboxLoteCompletoCorrida.Checked = False And chboxLoteCompletoPedido.Checked = False Then
            show_message("Advertencia", "Falta información, tipo de lote de cliente")
            chboxLoteCompletoTienda.ForeColor = Color.Red
            chboxLoteCompletoModelo.ForeColor = Color.Red
            chboxLoteCompletoPiel.ForeColor = Color.Red
            chboxLoteCompletoColor.ForeColor = Color.Red
            chboxLoteCompletoCorrida.ForeColor = Color.Red
            chboxLoteCompletoPedido.ForeColor = Color.Red
            Return False
        Else
            lblFormaEntrega.ForeColor = Color.Black
            chboxLoteCompletoTienda.ForeColor = Color.Black
            chboxLoteCompletoModelo.ForeColor = Color.Black
            chboxLoteCompletoPiel.ForeColor = Color.Black
            chboxLoteCompletoColor.ForeColor = Color.Black
            chboxLoteCompletoCorrida.ForeColor = Color.Black
            chboxLoteCompletoPedido.ForeColor = Color.Black
        End If
        Return True
    End Function

    Private Function editar_Almacen_Ventas_PoliticasEmbarque() As Boolean

        Dim politicaEmbarqueBU As New Negocios.PoliticaEmbarqueBU

        Dim politicaEmbarque As New Entidades.PoliticaEmbarque
        Dim tipoFleje As New Entidades.TipoFleje
        Dim protectorFleje As New Entidades.ProtectorFleje
        Dim lugarEntrega As New Entidades.LugarEntrega
        Dim cliente As New Entidades.Cliente
        Dim tipoEmpaque As New Entidades.TipoEmpaque

        cliente.clienteid = CInt(lblClienteSAYID_Int.Text)

        If IsDBNull(cboxAlmacenEntregaMercancia.SelectedValue) Or IsNothing(cboxAlmacenEntregaMercancia.SelectedValue) Then
            lugarEntrega.lugarentregaid = 0
        Else
            If cboxAlmacenEntregaMercancia.SelectedValue = 0 Then
                lugarEntrega.lugarentregaid = 0
            Else
                lugarEntrega.lugarentregaid = cboxAlmacenEntregaMercancia.SelectedValue
            End If
        End If

        If IsDBNull(cboxAlmacenTipoFleje.SelectedValue) Or IsNothing(cboxAlmacenTipoFleje.SelectedValue) Then
            tipoFleje.tipoflejeid = 0
        Else
            If cboxAlmacenTipoFleje.SelectedValue = 0 Then
                tipoFleje.tipoflejeid = 0
            Else
                tipoFleje.tipoflejeid = cboxAlmacenTipoFleje.SelectedValue
            End If
        End If

        If IsDBNull(cboxAlmacenProtectorFleje.SelectedValue) Or IsNothing(cboxAlmacenProtectorFleje.SelectedValue) Then
            protectorFleje.protectorflejeid = 0
        Else
            If cboxAlmacenProtectorFleje.SelectedValue = 0 Then
                protectorFleje.protectorflejeid = 0
            Else
                protectorFleje.protectorflejeid = cboxAlmacenProtectorFleje.SelectedValue
            End If
        End If

        If IsDBNull(cboxAlmacenTipoEmpaque.SelectedValue) Or IsNothing(cboxAlmacenTipoEmpaque.SelectedValue) Then
            tipoEmpaque.tipoempaqueid = 0
        Else
            If cboxAlmacenTipoEmpaque.SelectedValue = 0 Then
                tipoEmpaque.tipoempaqueid = 0
            Else
                tipoEmpaque.tipoempaqueid = cboxAlmacenTipoEmpaque.SelectedValue
            End If
        End If


        If IsDBNull(NumUDHorasAnticipacion.Value) Or IsNothing(NumUDHorasAnticipacion.Value) Then
            politicaEmbarque.HorasAnticipacion = 0
        Else
            politicaEmbarque.HorasAnticipacion = CInt(NumUDHorasAnticipacion.Value)
        End If


        politicaEmbarque.lugarentrega = lugarEntrega
        politicaEmbarque.tipofleje = tipoFleje
        politicaEmbarque.protectorfleje = protectorFleje
        politicaEmbarque.cliente = cliente

        'politicaEmbarque.validarcodigoetiqueta = chboxAlmacenValidarCodigoEtiquetas.CheckState
        'politicaEmbarque.etiquetaembarque = chboxAlmacenEtiquetaEmbarque.CheckState
        politicaEmbarque.notasembarque = txtAlmacenNotasEmbarque.Text
        politicaEmbarque.notasVentas = txtAlmacen_NotaVEntas.Text
        politicaEmbarque.tipoempaque = tipoEmpaque
        'politicaEmbarque.HorasAnticipacion = CInt(NumUDHorasAnticipacion.Value)
        politicaEmbarque.CitaParaEntrega = rdoClienteCitaSi.Checked
        politicaEmbarque.DoceneoEspecial = chkDoceneoEspecial.Checked

        If rdoPartidaCompleta.Checked = True Then
            politicaEmbarque.FormaEntregaMercancia = True
        ElseIf rdoMercanciaDisponible.Checked = True Then
            politicaEmbarque.FormaEntregaMercancia = False
        End If


        If rdoLoteCompleto.Checked = True Then
            politicaEmbarque.FormaEntregaMercancia = False
            politicaEmbarque.EntregaLotesCompletos = True
        Else
            politicaEmbarque.EntregaLotesCompletos = False
        End If

        politicaEmbarque.EntregaLotesCompletos_Tienda = chboxLoteCompletoTienda.Checked
        politicaEmbarque.EntregaLotesCompletos_Modelo = chboxLoteCompletoModelo.Checked
        politicaEmbarque.EntregaLotesCompletos_Piel = chboxLoteCompletoPiel.Checked
        politicaEmbarque.EntregaLotesCompletos_Color = chboxLoteCompletoColor.Checked
        politicaEmbarque.EntregaLotesCompletos_Corrida = chboxLoteCompletoCorrida.Checked
        politicaEmbarque.EntregaLotesCompletos_Pedido = chboxLoteCompletoPedido.Checked

        Try
            politicaEmbarqueBU.editarPoliticaEmbarque(politicaEmbarque, 1)
            Return True
        Catch ex As Exception
            show_message("Error", "Algo surgió mal durante el proceso de guardado")
            Return False
        End Try

    End Function

    Private Function editar_Almacen_Ventas_InfoCliente() As Boolean

        Dim infoCliente As New Entidades.InformacionClienteVentas
        Dim almacen As New Entidades.Almacen
        Dim cliente As New Entidades.Cliente
        Dim clienteDatos As New Negocios.ClientesDatosBU

        If IsDBNull(cboxAlmacenAlmacen.SelectedValue) Then
            If cliente_CP = 1 Then
                Return False
            Else
                almacen.almacenid = 0
            End If
        Else
            If cboxAlmacenAlmacen.SelectedValue = 0 Then
                If cliente_CP = 1 Then
                    Return False
                Else
                    almacen.almacenid = 0
                End If
            Else
                almacen.almacenid = cboxAlmacenAlmacen.SelectedValue
            End If
        End If

        cliente.clienteid = cboxClienteCliente.SelectedValue

        infoCliente.almacen = almacen
        infoCliente.cliente = cliente

        Try
            clienteDatos.editarVentasInfoCliente(infoCliente, 3)
            Return True
        Catch ex As Exception
            show_message("Error", "Algo surgió mal durante el proceso de guardado")
            Return False
        End Try

    End Function

    Private Function editar_Almacen_Ventas_PoliticasVentas() As Boolean

        Dim politicaVentas As New Entidades.PoliticaVenta
        Dim unidadVenta As New Entidades.UnidadVenta
        Dim cliente As New Entidades.Cliente

        Dim ventas As New Negocios.VentasPoliticasBU

        If IsDBNull(cboxAlmacenUnidadDeVenta.SelectedValue) Or IsNothing(cboxAlmacenUnidadDeVenta.SelectedValue) Then
            unidadVenta.unidadventaid = 0
        Else
            If cboxAlmacenUnidadDeVenta.SelectedValue = 0 Then
                unidadVenta.unidadventaid = 0
            Else
                unidadVenta.unidadventaid = cboxAlmacenUnidadDeVenta.SelectedValue
            End If
        End If

        cliente.clienteid = cboxClienteCliente.SelectedValue

        ' politicaVentas.validarcodigoetiqueta = chboxAlmacenValidarCodigoEtiquetas.CheckState
        politicaVentas.entregamercanciasinfacturar = CBool(chboxAlmacenPermitirEntrega.CheckState)
        politicaVentas.imprimirdirecciontienda = CBool(chboxAlmacenImprimirDireccionTiendaVentas.CheckState)
        politicaVentas.imprimirocfacturar = CBool(chboxImprimirOrdenCompraFacturar.CheckState)
        politicaVentas.imprimirtiendafacturar = CBool(chboxImprimirTiendaFacturar.CheckState)
        politicaVentas.ventaminima = numAlmacenVentaMinima.Value
        politicaVentas.unidadventa = unidadVenta
        politicaVentas.cliente = cliente
        politicaVentas.notasApartado = txtAlmacenNostasApartado.Text
        politicaVentas.importemaxventa = numVentasImporteMaximo.Value
        politicaVentas.DescripcionEspecialDocumento = chkDescripcionEspecialDocumentos.Checked

        Try
            ventas.editarVentasPoliticas(politicaVentas, 3)
            Return True
        Catch ex As Exception
            show_message("Error", "Algo surgió mal durante el proceso de guardado")
            Return False
        End Try

    End Function

    Private Function editar_Almacen_Ventas_RestriccionCliente() As Boolean

        Dim restriccionCliente As New Entidades.RestriccionCliente
        Dim restriccion As New Entidades.Restriccion
        Dim cliente As New Entidades.Cliente

        Dim restriccionBU As New Negocios.RestriccionesBU

        cliente.clienteid = CInt(lblClienteSAYID_Int.Text)

        If IsDBNull(cboxAlmacenRestricciones.SelectedValue) Then
            If cliente_CP = 1 Then
                Return False
            Else
                restriccion.restriccionid = 0
            End If
        Else
            If cboxAlmacenRestricciones.SelectedValue = 0 Then
                If cliente_CP = 1 Then
                    Return False
                Else
                    restriccion.restriccionid = 0
                End If
            Else
                restriccion.restriccionid = cboxAlmacenRestricciones.SelectedValue
            End If
        End If

        restriccionCliente.cliente = cliente
        restriccionCliente.restriccion = restriccion

        Try
            restriccionBU.editarRestriccionCliente(restriccionCliente, 1)
            Return True
        Catch ex As Exception
            show_message("Error", "Algo surgió mal durante el proceso de guardado")
            Return False
        End Try

    End Function

    Public Sub recuperar_datos_Panel_Almacen(clienteID As Integer)

        limpiarControles(pnlFormAlmacen)
        asignaStatusControles(pnlFormAlmacen, False)

        'If rbtnClienteStatusInactivo.Checked Then
        '    btnEditarCliente.Enabled = False
        'Else
        '    If Not Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
        '        If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
        '            btnEditarAlmacen.Enabled = False
        '        Else
        '            btnEditarAlmacen.Enabled = True
        '        End If
        '    End If
        'End If

        If rbtnClienteStatusInactivo.Checked Then
            btnEditarAlmacen.Enabled = False
        Else
            If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
                btnEditarAlmacen.Enabled = True
            Else
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
                    btnEditarAlmacen.Enabled = True
                Else
                    btnEditarAlmacen.Enabled = False
                End If
            End If
        End If

        txtAlmacenNotasEmbarque.Enabled = True
        txtAlmacenNotasEmbarque.ReadOnly = True

        ''POLITICA EMBARQUE

        Dim politicaEmbarqueBU As New Negocios.PoliticaEmbarqueBU
        Dim politicaEmbarque As New DataTable
        NumUDHorasAnticipacion.Value = 1 'Inicializar Horas de anticipacion
        politicaEmbarque = politicaEmbarqueBU.Datos_TablaPoliticaEmbarque(clienteID)

        If politicaEmbarque.Rows.Count > 0 Then

            ListaLugarEntrega(cboxAlmacenEntregaMercancia)
            If IsDBNull(politicaEmbarque.Rows(0).Item("poem_lugarentregaid")) Then
                cboxAlmacenEntregaMercancia.Text = String.Empty
            Else
                cboxAlmacenEntregaMercancia.SelectedValue = CInt(politicaEmbarque.Rows(0).Item("poem_lugarentregaid"))
            End If

            ListaTipoFleje(cboxAlmacenTipoFleje)
            If IsDBNull(politicaEmbarque.Rows(0).Item("poem_tipoflejeid")) Then
                cboxAlmacenTipoFleje.Text = String.Empty
            Else
                cboxAlmacenTipoFleje.SelectedValue = CInt(politicaEmbarque.Rows(0).Item("poem_tipoflejeid"))
            End If

            ListaProtectorFleje(cboxAlmacenProtectorFleje)
            If IsDBNull(politicaEmbarque.Rows(0).Item("poem_protectorflejeid")) Then
                cboxAlmacenProtectorFleje.Text = String.Empty
            Else
                cboxAlmacenProtectorFleje.SelectedValue = CInt(politicaEmbarque.Rows(0).Item("poem_protectorflejeid"))
            End If

            If IsDBNull(politicaEmbarque.Rows(0).Item("poem_notasembarque")) Then
                txtAlmacenNotasEmbarque.Text = String.Empty
            Else
                txtAlmacenNotasEmbarque.Text = CStr(politicaEmbarque.Rows(0).Item("poem_notasembarque"))
            End If

            If IsDBNull(politicaEmbarque.Rows(0).Item("poem_notasventas")) Then
                txtAlmacen_NotaVEntas.Text = String.Empty
            Else
                txtAlmacen_NotaVEntas.Text = CStr(politicaEmbarque.Rows(0).Item("poem_notasventas"))
            End If

            If IsDBNull(politicaEmbarque.Rows(0).Item("poem_tipoempaqueid")) Then
                cboxAlmacenTipoEmpaque.Text = String.Empty
            Else
                cboxAlmacenTipoEmpaque.SelectedValue = CStr(politicaEmbarque.Rows(0).Item("poem_tipoempaqueid"))
            End If

            If IsDBNull(politicaEmbarque.Rows(0).Item("poem_citaparaentrega")) = False Then
                If CInt(politicaEmbarque.Rows(0).Item("poem_citaparaentrega")) = True Then 'Tiene cita
                    rdoClienteCitaSi.Checked = True
                    rdoClienteCitaNo.Checked = False
                    NumUDHorasAnticipacion.Enabled = True
                Else
                    rdoClienteCitaSi.Checked = False
                    rdoClienteCitaNo.Checked = True
                    NumUDHorasAnticipacion.Enabled = False
                End If
            Else
                rdoClienteCitaSi.Checked = False
                rdoClienteCitaNo.Checked = True
                NumUDHorasAnticipacion.Enabled = False
            End If

            If IsDBNull(politicaEmbarque.Rows(0).Item("poem_horasanticipacion_citaentrega")) = False Then
                NumUDHorasAnticipacion.Value = CInt(politicaEmbarque.Rows(0).Item("poem_horasanticipacion_citaentrega"))
            Else
                NumUDHorasAnticipacion.Value = Decimal.Zero
            End If

            If IsDBNull(politicaEmbarque.Rows(0).Item("poem_DoceneoEspecial")) Then
                chkDoceneoEspecial.Checked = False
            Else
                If CBool(politicaEmbarque.Rows(0).Item("poem_DoceneoEspecial")) = True Then
                    chkDoceneoEspecial.Checked = True
                Else
                    chkDoceneoEspecial.Checked = False
                End If
            End If

            If IsDBNull(politicaEmbarque.Rows(0).Item("poem_entregapartidacompleta")) Then
                rdoPartidaCompleta.Checked = False
                rdoMercanciaDisponible.Checked = False
            Else
                If CBool(politicaEmbarque.Rows(0).Item("poem_entregapartidacompleta")) = True Then
                    rdoPartidaCompleta.Checked = True
                    rdoMercanciaDisponible.Checked = False
                Else
                    rdoPartidaCompleta.Checked = False
                    rdoMercanciaDisponible.Checked = True
                End If
            End If

            'INICIA SECCION DATOS DE LOTE COMPLETO

            chboxLoteCompletoTienda.Checked = False
            chboxLoteCompletoModelo.Checked = False
            chboxLoteCompletoPiel.Checked = False
            chboxLoteCompletoColor.Checked = False
            chboxLoteCompletoCorrida.Checked = False
            chboxLoteCompletoPedido.Checked = False

            If IsDBNull(politicaEmbarque.Rows(0).Item("poem_entregalotecompleto")) Then
                rdoLoteCompleto.Checked = False
            Else
                If CBool(politicaEmbarque.Rows(0).Item("poem_entregalotecompleto")) = True Then
                    rdoPartidaCompleta.Checked = False
                    rdoMercanciaDisponible.Checked = False
                    rdoLoteCompleto.Checked = True

                    If IsDBNull(politicaEmbarque.Rows(0).Item("poem_lote_tienda")) = False Then
                        chboxLoteCompletoTienda.Checked = CBool(politicaEmbarque.Rows(0).Item("poem_lote_tienda"))
                    End If

                    If IsDBNull(politicaEmbarque.Rows(0).Item("poem_lote_modelo")) = False Then
                        chboxLoteCompletoModelo.Checked = CBool(politicaEmbarque.Rows(0).Item("poem_lote_modelo"))
                    End If

                    If IsDBNull(politicaEmbarque.Rows(0).Item("poem_lote_piel")) = False Then
                        chboxLoteCompletoPiel.Checked = CBool(politicaEmbarque.Rows(0).Item("poem_lote_piel"))
                    End If

                    If IsDBNull(politicaEmbarque.Rows(0).Item("poem_lote_color")) = False Then
                        chboxLoteCompletoColor.Checked = CBool(politicaEmbarque.Rows(0).Item("poem_lote_color"))
                    End If

                    If IsDBNull(politicaEmbarque.Rows(0).Item("poem_lote_corrida")) = False Then
                        chboxLoteCompletoCorrida.Checked = CBool(politicaEmbarque.Rows(0).Item("poem_lote_corrida"))
                    End If

                    If IsDBNull(politicaEmbarque.Rows(0).Item("poem_lote_pedido")) = False Then
                        chboxLoteCompletoPedido.Checked = CBool(politicaEmbarque.Rows(0).Item("poem_lote_pedido"))
                    End If

                Else
                    rdoLoteCompleto.Checked = False
                End If
            End If

            'TERMINA SECCION DATOS DE LOTE COMPLETO

        End If


        ''VENTAS INFOCLIENTE

        Dim clienteDatosBU As New Negocios.ClientesDatosBU
        Dim infoClienteVentas As New DataTable
        infoClienteVentas = clienteDatosBU.Datos_TablaVentasInfoCliente(clienteID)

        If infoClienteVentas.Rows.Count > 0 Then

            ListaAlmacen(cboxAlmacenAlmacen)
            If IsDBNull(infoClienteVentas.Rows(0).Item("ivcl_almacenid")) Then
                cboxAlmacenAlmacen.Text = String.Empty
            Else
                cboxAlmacenAlmacen.SelectedValue = CInt(infoClienteVentas.Rows(0).Item("ivcl_almacenid"))
            End If

        End If


        ''POLITICA VENTAS

        Dim ventas As New Negocios.VentasPoliticasBU
        Dim politicaVentas As New DataTable
        politicaVentas = ventas.Datos_TablaPoliticaVenta(clienteID)

        If politicaVentas.Rows.Count > 0 Then

            ListaUnidadDeVenta(cboxAlmacenUnidadDeVenta)
            If IsDBNull(politicaVentas.Rows(0).Item("pove_unidadventaid")) Then
                cboxAlmacenUnidadDeVenta.Text = String.Empty
            Else
                cboxAlmacenUnidadDeVenta.SelectedValue = CInt(politicaVentas.Rows(0).Item("pove_unidadventaid"))
            End If

            'If IsDBNull(politicaVentas.Rows(0).Item("")) Then
            '    cboxAlmacenUnidadDeVenta.Text = String.Empty
            'Else
            '    cboxAlmacenUnidadDeVenta.SelectedValue = CInt(politicaVentas.Rows(0).Item(""))
            'End If

            If IsDBNull(politicaVentas.Rows(0).Item("pove_entregamercanciasinfacturar")) Then
                chboxAlmacenPermitirEntrega.Checked = False
            Else
                If CBool(politicaVentas.Rows(0).Item("pove_entregamercanciasinfacturar")) Then
                    chboxAlmacenPermitirEntrega.Checked = True
                Else
                    chboxAlmacenPermitirEntrega.Checked = False
                End If
            End If

            If IsDBNull(politicaVentas.Rows(0).Item("pove_imprimirdirecciontienda")) Then
                chboxAlmacenImprimirDireccionTiendaVentas.Checked = False
            Else
                If CBool(politicaVentas.Rows(0).Item("pove_imprimirdirecciontienda")) Then
                    chboxAlmacenImprimirDireccionTiendaVentas.Checked = True
                Else
                    chboxAlmacenImprimirDireccionTiendaVentas.Checked = False
                End If
            End If

            If IsDBNull(politicaVentas.Rows(0).Item("pove_imprimirocfacturar")) Then
                chboxImprimirOrdenCompraFacturar.Checked = False
            Else
                If CBool(politicaVentas.Rows(0).Item("pove_imprimirocfacturar")) Then
                    chboxImprimirOrdenCompraFacturar.Checked = True
                Else
                    chboxImprimirOrdenCompraFacturar.Checked = False
                End If
            End If

            If IsDBNull(politicaVentas.Rows(0).Item("pove_imprimirtiendafacturar")) Then
                chboxImprimirTiendaFacturar.Checked = False
            Else
                If CBool(politicaVentas.Rows(0).Item("pove_imprimirtiendafacturar")) Then
                    chboxImprimirTiendaFacturar.Checked = True
                Else
                    chboxImprimirTiendaFacturar.Checked = False
                End If
            End If

            If IsDBNull(politicaVentas.Rows(0).Item("pove_ventaminima")) Then
                numAlmacenVentaMinima.Value = Decimal.Zero
            Else
                If CInt(politicaVentas.Rows(0).Item("pove_ventaminima")) = Decimal.Zero Then
                    numAlmacenVentaMinima.Value = Decimal.Zero
                Else
                    numAlmacenVentaMinima.Value = CInt(politicaVentas.Rows(0).Item("pove_ventaminima"))
                End If
            End If

            If IsDBNull(politicaVentas.Rows(0).Item("pove_notasapartado")) Then
                txtAlmacenNostasApartado.Text = String.Empty
            Else
                txtAlmacenNostasApartado.Text = politicaVentas.Rows(0).Item("pove_notasapartado").ToString()
            End If

            If IsDBNull(politicaVentas.Rows(0).Item("pove_importemaxfactura")) Then
                numVentasImporteMaximo.Value = Decimal.Zero
            Else
                numVentasImporteMaximo.Value = CDec(politicaVentas.Rows(0).Item("pove_importemaxfactura"))
            End If

            If IsDBNull(politicaVentas.Rows(0).Item("pove_descripcionespecialfacturas")) Then
                chkDescripcionEspecialDocumentos.Checked = False
            Else
                chkDescripcionEspecialDocumentos.Checked = CBool(politicaVentas.Rows(0).Item("pove_descripcionespecialfacturas"))
            End If


        End If


        ''RESTRICIONES DE CLIENTE

        Dim restriccion As New DataTable
        Dim RestriccionesBU As New Negocios.RestriccionesBU
        restriccion = RestriccionesBU.Datos_TablaRestriccionesCliente(clienteID)

        If restriccion.Rows.Count > 0 Then

            ListaRestriccionesFacturacion(cboxAlmacenRestricciones)
            If IsDBNull(restriccion.Rows(0).Item("recl_restriccionid")) Then
                cboxAlmacenRestricciones.Text = String.Empty
            Else
                cboxAlmacenRestricciones.SelectedValue = CInt(restriccion.Rows(0).Item("recl_restriccionid"))
            End If

        End If

        ''concatena las marcas guardadas
        Dim objBu As New Negocios.ClientesDatosBU
        Dim dtMarcas As New DataTable

        dtMarcas = objBu.consultaMarcasConcatenadasRestriccionFactura(CInt(lblClienteSAYID_Int.Text))

        If dtMarcas.Rows.Count > 0 Then
            txtMarcasFacturar.Text = dtMarcas.Rows(0).Item("marcas").ToString
        End If

    End Sub

    Private Sub gboxAlmacenPoliticas_MouseDoubleClick(sender As Object, e As EventArgs) Handles gboxAlmacenPoliticas.MouseDoubleClick
        If gboxAlmacenPoliticas.Dock = DockStyle.Fill Then
            gboxAlmacenPoliticas.Dock = DockStyle.None
            gboxAlmacenDiasEntrega.Visible = True
            gboxNotasApartado.Visible = True
        Else
            gboxAlmacenPoliticas.Dock = DockStyle.Fill
            gboxAlmacenDiasEntrega.Visible = False
            gboxNotasApartado.Visible = False
        End If
    End Sub

    Private Sub gboxAlmacenDiasEntrega_MouseDoubleClick(sender As Object, e As EventArgs) Handles gboxAlmacenDiasEntrega.MouseDoubleClick
        If gboxAlmacenDiasEntrega.Dock = DockStyle.Fill Then
            gboxAlmacenDiasEntrega.Dock = DockStyle.None
            gboxAlmacenPoliticas.Visible = True
            gridAlmacenDiasEntrega.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            gridAlmacenDiasEntrega.DisplayLayout.Bands(0).Columns(1).Width = 90
            gridAlmacenDiasEntrega.DisplayLayout.Bands(0).Columns(3).Width = 90
            gridAlmacenDiasEntrega.DisplayLayout.Bands(0).Columns(5).Width = 90
            gridAlmacenDiasEntrega.DisplayLayout.Bands(0).Columns(7).Width = 63
            gboxNotasApartado.Visible = True

        Else
            gboxAlmacenDiasEntrega.Dock = DockStyle.Fill
            gboxAlmacenPoliticas.Visible = False
            gridAlmacenDiasEntrega.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            gboxNotasApartado.Visible = False
        End If
    End Sub


    Private Sub btnAlmacen_EditarPolitica_Click(sender As Object, e As EventArgs) Handles btnAlmacen_EditarPolitica.Click
        btnAlmacen_EditarPolitica.Enabled = False
        IniciarEdicionPoliticas()
    End Sub

    Private Sub btnAlmacen_AgregarHorario_Click(sender As Object, e As EventArgs) Handles btnAlmacen_AgregarHorario.Click
        Dim grid As DataTable = gridHorario.DataSource
        Dim row As UltraGridRow = gridHorario.ActiveRow
        Dim IdValor As Integer = 0


        If AreaOperativa = 1 Then
            Dim vlTipoHorario As New Infragistics.Win.ValueList

            vlTipoHorario = gridHorario.DisplayLayout.Bands(0).Columns(1).ValueList

            For Each item In vlTipoHorario.ValueListItems
                If item.DisplayText = "ENTREGA" Then
                    IdValor = item.DataValue
                End If
            Next

            gridHorario.Focus()
            LimpiarFiltrosGrid(gridHorario)

            grid.Rows.Add(0, IdValor, 0, "--Selecciona--", 0, String.Empty, CInt(lblClienteSAYID_Int.Text), 1)
        Else
            grid.Rows.Add(0, "--Selecciona--", 0, "--Selecciona--", 0, String.Empty, CInt(lblClienteSAYID_Int.Text), 1)
        End If

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

    Private Sub rdoClienteCitaSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdoClienteCitaSi.CheckedChanged
        NumUDHorasAnticipacion.Enabled = True
    End Sub

    Private Sub rdoClienteCitaNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoClienteCitaNo.CheckedChanged
        NumUDHorasAnticipacion.Enabled = False
        NumUDHorasAnticipacion.Value = 0
    End Sub

    Private Sub rdoLoteCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles rdoLoteCompleto.CheckedChanged
        If rdoLoteCompleto.Checked Then
            If rdoLoteCompleto.Enabled = True Then
                chboxLoteCompletoTienda.Enabled = True
                chboxLoteCompletoModelo.Enabled = True
                chboxLoteCompletoPiel.Enabled = True
                chboxLoteCompletoColor.Enabled = True
                chboxLoteCompletoCorrida.Enabled = True
                chboxLoteCompletoPedido.Enabled = True
            Else
                chboxLoteCompletoTienda.Enabled = False
                chboxLoteCompletoModelo.Enabled = False
                chboxLoteCompletoPiel.Enabled = False
                chboxLoteCompletoColor.Enabled = False
                chboxLoteCompletoCorrida.Enabled = False
                chboxLoteCompletoPedido.Enabled = False
            End If
        Else
            chboxLoteCompletoTienda.Enabled = False
            chboxLoteCompletoModelo.Enabled = False
            chboxLoteCompletoPiel.Enabled = False
            chboxLoteCompletoColor.Enabled = False
            chboxLoteCompletoCorrida.Enabled = False
            chboxLoteCompletoPedido.Enabled = False

            chboxLoteCompletoTienda.Checked = False
            chboxLoteCompletoModelo.Checked = False
            chboxLoteCompletoPiel.Checked = False
            chboxLoteCompletoColor.Checked = False
            chboxLoteCompletoCorrida.Checked = False
            chboxLoteCompletoPedido.Checked = False

            chboxLoteCompletoTienda.ForeColor = Color.Black
            chboxLoteCompletoModelo.ForeColor = Color.Black
            chboxLoteCompletoPiel.ForeColor = Color.Black
            chboxLoteCompletoColor.ForeColor = Color.Black
            chboxLoteCompletoCorrida.ForeColor = Color.Black
            chboxLoteCompletoPedido.ForeColor = Color.Black
        End If
    End Sub


    Private Sub btnMarcasFacturar_Click(sender As Object, e As EventArgs) Handles btnMarcasFacturar.Click
        Dim restriccionMarcas As New ListadoMarcasForm

        restriccionMarcas.idCliente = CInt(lblClienteSAYID_Int.Text)

        restriccionMarcas.ShowDialog()

        ''concatena las marcas guardadas
        Dim objBu As New Negocios.ClientesDatosBU
        Dim dtMarcas As New DataTable

        dtMarcas = objBu.consultaMarcasConcatenadasRestriccionFactura(CInt(lblClienteSAYID_Int.Text))

        If dtMarcas.Rows.Count > 0 Then
            txtMarcasFacturar.Text = dtMarcas.Rows(0).Item("marcas").ToString
        End If
    End Sub
End Class
