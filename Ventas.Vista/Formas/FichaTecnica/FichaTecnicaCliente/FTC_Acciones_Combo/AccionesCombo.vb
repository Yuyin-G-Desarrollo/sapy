Partial Class FichaTecnicaClienteForm

    Private Sub cboxClienteCliente_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboxClienteCliente.SelectionChangeCommitted


        If CInt(lblClienteSAYID_Int.Text) = 0 Then Return
        If IsDBNull(cboxClienteCliente.SelectedValue) Then Return

        dockManagerFichaTecnica.FlyIn()

        If IsDBNull(cboxClienteCliente.SelectedValue) Then
            limpiarControles(pnlFormCliente)
            asignaStatusControles(pnlFormCliente, False)
            lblClienteSAYID_Int.Text = "0"
            lblClientePersonaID_Int.Text = "0"

            btnBuscarCliente.Enabled = True

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "ALTACLIENTE") Then
                If CInt(lblClientePersonaID_Int.Text) = 0 Then
                    btnAgregarCliente.Enabled = True
                Else
                    btnAgregarCliente.Enabled = False
                End If
            Else
                btnAgregarCliente.Enabled = False
            End If

            cboxClienteCliente.Enabled = True
            cboxClienteCliente.DropDownStyle = ComboBoxStyle.DropDown


            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCABECERAATN") Then
                If CInt(lblClientePersonaID_Int.Text) = 0 Then
                    btnEditarCliente.Enabled = False
                Else
                    btnEditarCliente.Enabled = True
                End If
            Else
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
                    If CInt(lblClientePersonaID_Int.Text) = 0 Then
                        btnEditarCliente.Enabled = False
                    Else
                        btnEditarCliente.Enabled = True
                    End If
                Else
                    btnEditarCliente.Enabled = False
                End If
            End If

            Return
        End If

        If CInt(cboxClienteCliente.SelectedValue) <> CInt(lblClienteSAYID_Int.Text) Then

            Dim clienteID As Integer = CInt(cboxClienteCliente.SelectedValue)

            limpiarControles(pnlFormCliente)
            asignaStatusControles(pnlFormCliente, False)
            lblClienteSAYID_Int.Text = "0"
            lblClientePersonaID_Int.Text = "0"

            btnBuscarCliente.Enabled = True
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "ALTACLIENTE") Then
                If CInt(lblClientePersonaID_Int.Text) = 0 Then
                    btnAgregarCliente.Enabled = True
                Else
                    btnAgregarCliente.Enabled = False
                End If
            Else
                btnAgregarCliente.Enabled = False
            End If


            cboxClienteCliente.Enabled = True
            cboxClienteCliente.DropDownStyle = ComboBoxStyle.DropDown
            cboxClienteCliente.SelectedValue = CInt(clienteID)

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCABECERAATN") Then
                If CInt(lblClientePersonaID_Int.Text) = 0 Then
                    btnEditarCliente.Enabled = False
                Else
                    btnEditarCliente.Enabled = True
                End If
            Else
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
                    If CInt(lblClientePersonaID_Int.Text) = 0 Then
                        btnEditarCliente.Enabled = False
                    Else
                        btnEditarCliente.Enabled = True
                    End If
                Else
                    btnEditarCliente.Enabled = False
                End If
            End If

            Return
        End If


    End Sub


    Private Sub cboxDatosPais_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboxDatosPais.SelectionChangeCommitted
        ListaEstado(cboxDatosEstado, cboxDatosPais.SelectedValue)
        cboxDatosCiudad.DataSource = Nothing
    End Sub


    Private Sub cboxDatosEstado_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxDatosEstado.SelectionChangeCommitted
        ListaCiudad(cboxDatosCiudad, cboxDatosEstado.SelectedValue)
    End Sub

    Private Sub cboxDatosCiudad_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxDatosCiudad.SelectionChangeCommitted
        Try
            ListaPoblacion(cboxDatosPoblacion, cboxDatosCiudad.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboxRFCPais_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboxRFCPais.SelectionChangeCommitted
        ListaEstado(cboxRFCEstado, cboxRFCPais.SelectedValue)
        cboxRFCCiudad.DataSource = Nothing
    End Sub

    Private Sub cboxRFCEstado_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxRFCEstado.SelectionChangeCommitted
        ListaCiudad(cboxRFCCiudad, cboxRFCEstado.SelectedValue)
    End Sub

    Private Sub cboxRFCCiudad_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxRFCCiudad.SelectionChangeCommitted

        Try
            ListaPoblacion(cboxRFCPoblacion, cboxRFCCiudad.SelectedValue)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cboxCEDISPais_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboxCEDISPais.SelectionChangeCommitted
        ListaEstado(cboxCEDISEstado, cboxCEDISPais.SelectedValue)
        cboxCEDISCiudad.DataSource = Nothing
    End Sub

    Private Sub cboxCEDISEstado_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxCEDISEstado.SelectionChangeCommitted
        ListaCiudad(cboxCEDISCiudad, cboxCEDISEstado.SelectedValue)
    End Sub

    Private Sub cboxCEDISCiudad_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxCEDISCiudad.SelectionChangeCommitted
        ListaPoblacion(cboxCedisPoblacion, cboxCEDISCiudad.SelectedValue)
        show_message("Advertencia", "La prioridad de las mensajerías deberá ser reasignada sí se modifica la ciudad.")
    End Sub

    Private Sub cboxCEDISRFC_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboxCEDISRFC.SelectionChangeCommitted
        If cboxCEDISRFC.SelectedIndex > 0 Then
            'Dim OBJBU As New Ventas.Negocios.ClientesDatosBU
            'Dim dtCedis As New DataTable

            'dtCedis = OBJBU.ListadoTECClienteRFC(cboxCEDISRFC.SelectedValue)

            'If dtCedis.Rows.Count > 0 Then
            '    txtCEDISCEDIS.Text = dtCedis.Rows(0).Item(1)
            'End If
            ListaTECClienteRFC(cboxCEDISCEDIS, CInt(cboxCEDISRFC.SelectedValue))
        End If
    End Sub

    Private Sub cboxCedisPoblacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxCedisPoblacion.SelectedIndexChanged
        If cboxCedisPoblacion.SelectedIndex > 0 Then
            If cboxCedisPoblacion.SelectedValue <> Poblacion Then
                show_message("Advertencia", "La prioridad de las mensajerías deberá ser reasignada sí se modifica la población.")
            End If
        End If

    End Sub

    Private Sub cboxClienteClasificacion_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboxClienteClasificacion.SelectionChangeCommitted

        Dim ClientesBU As New Negocios.ClientesBU
        Dim tabla As New DataTable


        If IsDBNull(cboxClienteClasificacion.SelectedValue) Then Return

        tabla = ClientesBU.AsignarClasificacionRanking(CStr(cboxClienteClasificacion.SelectedValue))

        If tabla.Rows.Count > 0 Then
            txtClienteRanking.Text = CStr(tabla.Rows(0).Item("clas_ranking"))
        End If

    End Sub

    Private Sub cboxClienteEstatus_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboxClienteEstatus.SelectionChangeCommitted

        If cboxClienteEstatus.SelectedIndex > -1 Then
            If cboxClienteEstatus.Text.ToUpperInvariant.Equals("PROSPECTO") Then
                cboxClienteClasificacion.Enabled = False
            ElseIf cboxClienteEstatus.Text.ToUpperInvariant.Equals("CLIENTE") Then
                cboxClienteClasificacion.Enabled = True
            End If
        Else
            cboxClienteClasificacion.Enabled = True
        End If

    End Sub

    Private Sub cboxDatosPais_Enter(sender As Object, e As EventArgs) Handles cboxDatosPais.Enter
        Dim IdPais, IdEstado, IdCiudad As Integer

        If Not IsNothing(cboxDatosEstado.DataSource) Then
            If Not IsNothing(cboxDatosEstado.SelectedValue) Then
                IdEstado = cboxDatosEstado.SelectedValue
            Else
                IdEstado = 0
            End If
        End If
        If Not IsNothing(cboxDatosCiudad.DataSource) Then
            If Not IsNothing(cboxDatosCiudad.SelectedValue) Then
                IdCiudad = cboxDatosCiudad.SelectedValue
            Else
                IdCiudad = 0
            End If
        End If

        If Not IsNothing(cboxDatosPais.DataSource) Then
            If Not IsNothing(cboxDatosPais.SelectedValue) Then
                IdPais = cboxDatosPais.SelectedValue
                ListaPais(cboxDatosPais)

                cboxDatosPais.SelectedValue = CInt(IdPais)

                ListaEstado(cboxDatosEstado, IdPais)
                cboxDatosEstado.SelectedValue = IdEstado

                ListaCiudad(cboxDatosCiudad, IdEstado)
                cboxDatosCiudad.SelectedValue = IdCiudad
            Else
                cboxDatosEstado.DataSource = Nothing
                cboxDatosCiudad.DataSource = Nothing
            End If
        End If

    End Sub

    Private Sub cboxVentasEmpresa_Enter(sender As Object, e As EventArgs) Handles cboxVentasEmpresa.Enter
        Dim IdEmpresa As Integer
        

        If Not IsNothing(cboxVentasEmpresa.DataSource) Then
            If Not IsNothing(cboxVentasEmpresa.SelectedValue) Then
                IdEmpresa = cboxVentasEmpresa.SelectedValue
            Else
                IdEmpresa = 0
            End If
        End If

        ListaEmpresas()
        cboxVentasEmpresa.SelectedValue = IdEmpresa
    End Sub

    Private Sub cboxRFCRFCAFacturar_Enter(sender As Object, e As EventArgs) Handles cboxRFCRFCAFacturar.Enter
        'CLIENTE RFC
        Dim clientesDatosBU As New Negocios.ClientesDatosBU
        Dim clienteRFC As New DataTable
        Dim IdFacturar As Integer

        If Not IsNothing(cboxRFCRFCAFacturar.SelectedValue) Then
            If Not IsDBNull(cboxRFCRFCAFacturar.SelectedValue) Then
                IdFacturar = cboxRFCRFCAFacturar.SelectedValue
            Else
                IdFacturar = 0
            End If
        Else
            IdFacturar = 0
        End If

        If Not IsNothing(gridClienteRFC.ActiveRow) Then
            clienteRFC = clientesDatosBU.Datos_TablaClienteRFC(gridClienteRFC.ActiveRow.Cells(0).Value)

            If clienteRFC.Rows.Count > 0 Then
                ListaClienteRFCFactura(cboxRFCRFCAFacturar, CInt(lblClienteSAYID_Int.Text))
                If IsDBNull(clienteRFC.Rows(0).Item("crfc_clienterfcidafacturar")) Then
                    cboxRFCRFCAFacturar.Text = String.Empty
                Else
                    cboxRFCRFCAFacturar.SelectedValue = CInt(clienteRFC.Rows(0).Item("crfc_clienterfcidafacturar"))
                End If
                cboxRFCRFCAFacturar.SelectedValue = IdFacturar
            End If
        End If
        

    End Sub

    Private Sub cboxRFCRamo_Enter(sender As Object, e As EventArgs) Handles cboxRFCRamo.Enter
        'CLIENTE RFC
        Dim clientesDatosBU As New Negocios.ClientesDatosBU
        Dim clienteRFC As New DataTable
        If Not IsNothing(gridClienteRFC.ActiveRow) Then
            clienteRFC = clientesDatosBU.Datos_TablaClienteRFC(gridClienteRFC.ActiveRow.Cells(0).Value)
            If clienteRFC.Rows.Count > 0 Then

                ListaRamos(cboxRFCRamo)
                If IsDBNull(clienteRFC.Rows(0).Item("crfc_ramoid")) Then
                    cboxRFCRamo.Text = String.Empty
                Else
                    cboxRFCRamo.SelectedValue = CInt(clienteRFC.Rows(0).Item("crfc_ramoid"))
                End If

            End If
        End If
      

    End Sub

    Private Sub cboxRFCSICYID_Enter(sender As Object, e As EventArgs) Handles cboxRFCSICYID.Enter
        'PERSONA
        Dim personaBU As New Framework.Negocios.PersonasBU
        Dim persona As New DataTable
        Dim RFCSICY As Integer

        If Not IsNothing(gridClienteRFC.ActiveRow) Then
            persona = personaBU.Datos_TablaPersona(gridClienteRFC.ActiveRow.Cells(0).Value)

            If IsDBNull(persona.Rows(0).Item("pers_IdSICY")) Then
                RFCSICY = 0
            Else
                RFCSICY = CInt(persona.Rows(0).Item("pers_IdSICY"))
            End If

            If Not IsNothing(cboxRFCSICYID.SelectedValue) Then
                If persona.Rows.Count > 0 Then
                    If ModoEdicion = True Then
                        ListaRFC_Sicy(cboxRFCSICYID, CInt(txtClienteSICYID.Text), RFCSICY, True)
                    Else
                        ListaRFC_Sicy(cboxRFCSICYID, CInt(txtClienteSICYID.Text), RFCSICY, False)
                    End If
                    cboxRFCSICYID.SelectedValue = RFCSICY
                End If
            End If
        Else
            ListaRFC_Sicy(cboxRFCSICYID, CInt(txtClienteSICYID.Text), 0, True)
        End If
        

    End Sub

    Private Sub cboxRFCPais_Enter(sender As Object, e As EventArgs) Handles cboxRFCPais.Enter
        'DOMICILIO
        Dim domicilio As New DataTable
        Dim DomicilioBU As New Framework.Negocios.DomicilioBU
        If IsNothing(gridClienteRFC.ActiveRow) Then Return

        domicilio = DomicilioBU.Datos_TablaDomicilioPersona(gridClienteRFC.ActiveRow.Cells(0).Value)

        If domicilio.Rows.Count > 0 Then
            cboxRFCPais.Text = CStr(domicilio.Rows(0).Item("pais_nombre"))
            ListaPais(cboxRFCPais)
            cboxRFCPais.SelectedValue = CInt(domicilio.Rows(0).Item("pais_paisid"))
        End If
    End Sub

End Class
