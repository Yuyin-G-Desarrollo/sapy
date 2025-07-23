Imports Tools.Controles
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Partial Public Class FichaTecnicaClienteForm


    Private Sub gboxRFCRFC_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gboxRFCRFC.MouseDoubleClick

        If gboxRFCRFC.Dock = DockStyle.Fill Then
            gboxRFCRFC.Dock = DockStyle.None
        Else
            gboxRFCRFC.Dock = DockStyle.Fill
        End If

    End Sub


    Private Sub rbtnRFCPersonaMoral_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnRFCPersonaMoral.CheckedChanged
        If Not pnlRFCTipoRFC.Enabled Then Return
        Dim dtRegimenFiscal As DataTable
        Dim personaBU As New Framework.Negocios.PersonasBU

        If rbtnRFCPersonaMoral.Checked Then
            dtRegimenFiscal = personaBU.regimenPersonaMoralFisica(False)            
        Else
            dtRegimenFiscal = personaBU.regimenPersonaMoralFisica(True)           
        End If

        If dtRegimenFiscal.Rows.Count > 0 Then
            Dim newRow As DataRow = dtRegimenFiscal.NewRow
            dtRegimenFiscal.Rows.InsertAt(newRow, 0)

            cboxRegimenFis.DataSource = dtRegimenFiscal
            cboxRegimenFis.ValueMember = "idRegimenfiscal"
            cboxRegimenFis.DisplayMember = "Regimen"
        End If
       
    End Sub

    Private Sub rbtnTipoRFCRemision_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnRFCTipoRFCRemision.CheckedChanged
        If Not pnlRFCTipoRFC.Enabled Then Return

        If rbtnRFCTipoRFCRemision.Checked Then
            cboxRFCRFCAFacturar.Enabled = True
        Else
            cboxRFCRFCAFacturar.Enabled = False
        End If
    End Sub

    Private Sub chboxRFCPoblacion_CheckedChanged(sender As Object, e As EventArgs) Handles chboxRFCPoblacion.CheckedChanged

        If chboxRFCPoblacion.CheckState = CheckState.Checked Then
            cboxRFCPoblacion.Enabled = True
        Else
            cboxRFCPoblacion.Enabled = False
        End If

    End Sub

    Private Sub btnGuardarPanelRFC_Click(sender As Object, e As EventArgs) Handles btnGuardarRFC.Click

        If Not cumple_info_obligatoria_Panel_RFC() Then
            Exit Sub
        End If

        If CInt(lblRFCPersonaID_Int.Text) = 0 Then
            Try
                If Not alta_RFC_Framework_Persona() Then
                    Exit Sub
                End If
            Catch ex As Exception
                show_message("Error", "Algo falló en la operación")
                Exit Sub
            End Try
            Try
                If Not editar_RFC_Framework_Persona(1) Then
                    Exit Sub
                End If
            Catch ex As Exception
                show_message("Error", "Algo falló en la operación")
                Exit Sub
            End Try
        Else
            Try
                If Not editar_RFC_Framework_Persona(3) Then
                    Exit Sub
                End If
            Catch ex As Exception
                show_message("Error", "Algo falló en la operación")
                Exit Sub
            End Try
        End If

        Try
            editar_RFC_Cliente_ClienteRFC()
        Catch ex As Exception
            show_message("Error", "Algo falló en la operación")
            Exit Sub
        End Try

        Try
            editar_RFC_Framework_Domicilio()
        Catch ex As Exception
            show_message("Error", "Algo falló en la operación")
            Exit Sub
        End Try

        poblar_gridClienteRFC(CInt(lblClienteSAYID_Int.Text), gridRFCRFC)

        recuperar_datos_Panel_RFC(CInt(lblRFCPersonaID_Int.Text))
        ModoEdicion = False


        Dim personaBU As New Framework.Negocios.PersonasBU
        Dim persona As New DataTable
        persona = personaBU.Datos_TablaPersona(CInt(lblRFCPersonaID_Int.Text))

        If persona.Rows.Count > 0 Then
            ListaRFC_Sicy(cboxRFCSICYID, CInt(txtClienteSICYID.Text), 0, ModoEdicion)
            If IsDBNull(persona.Rows(0).Item("pers_IdSICY")) Then
                cboxRFCSICYID.Text = String.Empty
            Else
                Dim value As String = CStr(persona.Rows(0).Item("pers_IdSICY"))
                cboxRFCSICYID.SelectedValue = CStr(persona.Rows(0).Item("pers_IdSICY"))
            End If

        End If

        ''cboxRFCSICYID.SelectedValue = CInt(lblRFCPersonaID_Int.Text)


        If AreaOperativa = 9 Then
            btnRFCVincularTECs.Enabled = True
            btnRFCAltaRFC.Enabled = True

            ''ACTIVAR LAS FILAS DEL GRID DE CORREOS
            For Each row In gridRFCEmails.Rows
                Dim i As Integer = gridRFCEmails.Rows.Count
                gridRFCEmails.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
                gridRFCEmails.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
            Next

            '' INACTIVAR LAS FILAS DEL GRID TELEFONOS
            For Each row In gridRFCTelefono.Rows
                Dim i As Integer = gridRFCTelefono.Rows.Count
                gridRFCTelefono.DisplayLayout.Rows(row.Index).Activation = Activation.NoEdit
                gridRFCTelefono.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            Next
        End If
    End Sub

    Private Sub btnEditarPanelRFC_Click(sender As Object, e As EventArgs) Handles btnEditarRFC.Click
        Dim grid As DataTable = gridClienteRFC.DataSource
        Dim row As UltraGridRow = gridClienteRFC.ActiveRow

        Me.Cursor = Cursors.WaitCursor

        ModoEdicion = True

        asignaStatusControles(pnlFormRFC, True)

        If CInt(lblRFCPersonaID_Int.Text) = 0 Then
            pnlRFCTipoRFC.Enabled = True
            pnlRFCTipoPersona.Enabled = True
            cboxRFCRFCAFacturar.Enabled = True
        Else
            pnlRFCTipoRFC.Enabled = True
            pnlRFCTipoPersona.Enabled = True
            'pnlRFCTipoPersona.Enabled = False
            cboxRFCRFCAFacturar.Enabled = False
        End If

        Dim rfc_sicyID As Integer
        If IsDBNull(cboxRFCSICYID.SelectedValue) Then
            rfc_sicyID = 0
        Else
            rfc_sicyID = cboxRFCSICYID.SelectedValue
        End If


        cboxRFCSICYID.SelectedValue = rfc_sicyID
        pnlRFCTipoPersona.Enabled = True

        txtRFCCiudadCisy.Enabled = False

        If AreaOperativa = 3 Then
            If row Is Nothing Then Return
            Dim personaID As Integer = CInt(row.Cells(0).Value)

            If personaID = 0 Then Return
            lblContabilidadRFCPersonaID_Int.Text = CStr(personaID)

            recuperar_datos_Panel_Cobranza_Contabilidad(personaID)
            recuperar_datos_Panel_Cobranza_EvalInfoCredito(personaID)

            asignaStatusControles(tpgCobranzaContabilidad, True)
            btnEditarCobranzaContabilidad.Enabled = False
            btnGuardarCobranzaContabilidad.Enabled = True
            btnCancelarCobranzaContabilidad.Enabled = True


        Else
            If Not IsDBNull(row.Cells(0).Value) Then
                recuperar_datos_Panel_RFC(CInt(row.Cells(0).Value))
                asignaStatusControles(pnlFormRFC, True)
                pnlRFCTipoRFC.Enabled = False
                'pnlRFCTipoPersona.Enabled = False

                If rbtnRFCTipoRFCRemision.Checked Then
                    cboxRFCRFCAFacturar.Enabled = True
                Else
                    cboxRFCRFCAFacturar.Enabled = False
                End If

            End If
            If AreaOperativa = 9 Then
                btnRFCVincularTECs.Enabled = True
                btnRFCAltaRFC.Enabled = False


                ''ACTIVAR LAS FILAS DEL GRID DE CORREOS
                For Each row In gridRFCEmails.Rows
                    Dim i As Integer = gridRFCEmails.Rows.Count
                    gridRFCEmails.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
                    gridRFCEmails.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
                Next

                '' INACTIVAR LAS FILAS DEL GRID TELEFONOS
                For Each row In gridRFCTelefono.Rows
                    Dim i As Integer = gridRFCTelefono.Rows.Count
                    gridRFCTelefono.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
                    gridRFCTelefono.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
                Next



            End If

        End If

        ListaRFC_Sicy(cboxRFCSICYID, CInt(txtClienteSICYID.Text), rfc_sicyID, True)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCancelarPanelRFC_Click(sender As Object, e As EventArgs) Handles btnCancelarlRFC.Click
        If Mensajes_Y_Alertas("CONFIRMACION", "Los cambios realizados no se han guardado ¿Desea cancelar los cambios?") Then
            ModoEdicion = False

            recuperar_datos_Panel_RFC(CInt(lblRFCPersonaID_Int.Text))
            CambiarElForeColorControles_Negro(pnlFormRFC)

            If AreaOperativa = 9 Then
                btnRFCVincularTECs.Enabled = True
                btnRFCAltaRFC.Enabled = False

                ''ACTIVAR LAS FILAS DEL GRID DE CORREOS
                For Each row In gridRFCEmails.Rows
                    Dim i As Integer = gridRFCEmails.Rows.Count
                    gridRFCEmails.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
                    gridRFCEmails.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
                Next

                '' INACTIVAR LAS FILAS DEL GRID TELEFONOS
                For Each row In gridRFCTelefono.Rows
                    Dim i As Integer = gridRFCTelefono.Rows.Count
                    gridRFCTelefono.DisplayLayout.Rows(row.Index).Activation = Activation.NoEdit
                    gridRFCTelefono.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                Next

                If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
                    btnEditarRFC.Enabled = True
                    btnRFCAltaRFC.Enabled = True
                    btnRFCVincularTECs.Enabled = True
                Else
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
                        btnEditarRFC.Enabled = True
                        btnRFCAltaRFC.Enabled = True
                        btnRFCVincularTECs.Enabled = True
                    Else
                        btnEditarRFC.Enabled = False
                        btnRFCAltaRFC.Enabled = False
                        btnRFCVincularTECs.Enabled = False

                    End If
                End If

                If IsNothing(gridRFCRFC.ActiveRow) Then
                    btnEditarRFC.Enabled = False
                    btnRFCVincularTECs.Enabled = False
                End If

            End If

        End If

    End Sub

    Public Function cumple_info_obligatoria_Panel_RFC() As Boolean

        '   NOMBRE PERSONA RFC - OBLIGATORIO
        If cboxRFCRamo.SelectedIndex <= 0 Then
            show_message("Advertencia", "Falta información")
            lblRFCRamo.ForeColor = Color.Red
            Return False
        Else
            lblRFCRamo.ForeColor = Color.Black
        End If

        ''   NOMBRE PERSONA RFC - OBLIGATORIO
        'If numRFCPorcentajeAFacturar.Then Then
        '    show_message("Advertencia", "Falta información")
        '    lblRFCRamo.ForeColor = Color.Red
        '    Return False
        'Else
        '    lblRFCRamo.ForeColor = Color.Black
        'End If


        '   NOMBRE PERSONA RFC - OBLIGATORIO
        If txtRFCNombre.TextLength < 1 Then
            show_message("Advertencia", "Falta información")
            lblRFCNombre.ForeColor = Color.Red
            Return False
        Else
            lblRFCNombre.ForeColor = Color.Black
        End If

        '   NOMBRE RAZON SOCIAL RFC - OBLIGATORIO
        If txtRFCRazonSocial.TextLength < 1 Then
            show_message("Advertencia", "Falta información")
            lblRFCRazonSocial.ForeColor = Color.Red
            Return False
        Else
            lblRFCRazonSocial.ForeColor = Color.Black
        End If

        '   CLASIFICACION PERSONA DE RFC - OBLIGATORIO
        If rbtnRFCTipoRFCFactura.Checked Then
            rfc_CP = 14
            lblRFCTipoRFC.ForeColor = Color.Black
        ElseIf rbtnRFCTipoRFCRemision.Checked Then
            rfc_CP = 13
            lblRFCTipoRFC.ForeColor = Color.Black
        Else
            show_message("Advertencia", "Falta información")
            lblRFCTipoRFC.ForeColor = Color.Red
            Return False
        End If

        '14 - FACTURA / 13 - REMISION
        '   CURP PERSONA RFC - OBLIGATORIO PARA REMISION
        'If txtRFCCurp.TextLength < 1 Then
        '    If rfc_CP = 13 Then
        '        show_message("Advertencia", "Falta información")
        '        lblRFCCurp.ForeColor = Color.Red
        '        Return False
        '    Else
        '        lblRFCCurp.ForeColor = Color.Black
        '    End If
        'Else
        '    lblRFCCurp.ForeColor = Color.Black
        'End If

        '14 - FACTURA / 13 - REMISION
        '   RFC PERSONA RFC - OBLIGATORIO PARA RFC
        If txtRFCRFC.TextLength < 1 Then
            If rfc_CP = 14 Then
                show_message("Advertencia", "Falta información")
                lblRFCRFC.ForeColor = Color.Red
                Return False
            Else
                lblRFCRFC.ForeColor = Color.Black
            End If
        Else
            lblRFCRFC.ForeColor = Color.Black
        End If


        'If cboxRFCRFCAFacturar.Enabled Then
        '    If IsDBNull(cboxRFCRFCAFacturar.SelectedValue) Then
        '        If rfc_CP = 13 Then
        '            show_message("Advertencia", "Falta información")
        '            rbtnRFCTipoRFCRemision.ForeColor = Color.Red
        '            Return False
        '        Else
        '            rbtnRFCTipoRFCRemision.ForeColor = Color.Black
        '        End If
        '    Else
        '        If cboxRFCRFCAFacturar.SelectedValue = 0 Then
        '            If rfc_CP = 13 Then
        '                show_message("Advertencia", "Falta información")
        '                rbtnRFCTipoRFCRemision.ForeColor = Color.Red
        '                Return False
        '            Else
        '                rbtnRFCTipoRFCRemision.ForeColor = Color.Black
        '            End If
        '        End If
        '    End If
        'Else
        '    rbtnRFCTipoRFCRemision.ForeColor = Color.Black
        'End If

        '   TIPO DE PERSONA - OBLIGATORIO
        If rbtnRFCPersonaFisica.Checked Then
            lblRFCTipoPersona.ForeColor = Color.Black
        ElseIf rbtnRFCPersonaMoral.Checked Then
            lblRFCTipoPersona.ForeColor = Color.Black
        Else
            show_message("Advertencia", "Debe asignar un tipo de persona")
            lblRFCTipoPersona.ForeColor = Color.Red
            Return False
        End If

        If IsDBNull(cboxRFCSICYID.SelectedValue) Or IsNothing(cboxRFCSICYID.SelectedValue) Then
            show_message("Advertencia", "No existe RFC SICY para relacionar.")
            lblRFCSICYID.ForeColor = Color.Red
            cboxRFCSICYID.ForeColor = Color.Red
            Return False
        Else
            If cboxRFCSICYID.SelectedValue = 0 Then
                show_message("Advertencia", "Falta información")
                cboxRFCSICYID.ForeColor = Color.Red
                lblRFCSICYID.ForeColor = Color.Red
                Return False
            Else
                cboxRFCSICYID.ForeColor = Color.Black
                lblRFCSICYID.ForeColor = Color.Black
            End If
        End If

        '   CALLE - OBLIGATORIO
        If txtRFCCalle.TextLength < 1 Then
            show_message("Advertencia", "Falta información")
            lblRFCCalle.ForeColor = Color.Red
            Return False
        Else
            lblRFCCalle.ForeColor = Color.Black
        End If

        '   DOMICILIO NUMERO EXTERIOR RFC - OBLIGATORIO
        If txtRFCNumeroExterior.TextLength < 1 Then
            show_message("Advertencia", "Falta información")
            lblRFCNumeroExterior.ForeColor = Color.Red
            Return False
        Else
            lblRFCNumeroExterior.ForeColor = Color.Black
        End If

        '   DOMICILIO COLONIA RFC - OBLIGATORIO
        If txtRFCColonia.TextLength < 1 Then
            show_message("Advertencia", "Falta información")
            lblRFCColonia.ForeColor = Color.Red
            Return False
        Else
            lblRFCColonia.ForeColor = Color.Black
        End If

        '   DOMICILIO CODIGO POSTAL RFC - OBLIGATORIO
        If numRFCCodigoPostal.TextLength = 0 Then
            show_message("Advertencia", "Falta información")
            lblRFCCodigoPostal.ForeColor = Color.Red
            Return False
        Else
            lblRFCCodigoPostal.ForeColor = Color.Black
        End If

        '   DOMICILIO PAIS RFC - OBLIGATORIO
        If IsDBNull(cboxRFCPais.SelectedValue) Or IsNothing(cboxRFCPais.SelectedValue) Then
            show_message("Advertencia", "Falta información")
            lblRFCPais.ForeColor = Color.Red
            Return False
        Else
            If cboxRFCPais.SelectedValue = 0 Then
                show_message("Advertencia", "Falta información")
                lblRFCPais.ForeColor = Color.Red
                Return False
            Else
                lblRFCPais.ForeColor = Color.Black
            End If
        End If

        '   DOMICILIO ESTADO RFC - OBLIGATORIO
        Dim Estado As New Entidades.Estados
        If IsDBNull(cboxRFCEstado.SelectedValue) Or IsNothing(cboxRFCEstado.SelectedValue) Then
            show_message("Advertencia", "Falta información")
            lblRFCEstado.ForeColor = Color.Red
            Return False
        Else
            If cboxRFCEstado.SelectedValue = 0 Then
                show_message("Advertencia", "Falta información")
                lblRFCEstado.ForeColor = Color.Red
                Return False
            Else
                lblRFCEstado.ForeColor = Color.Black
            End If
        End If

        '   DOMICILIO CIUDAD RFC - OBLIGATORIO
        If IsDBNull(cboxRFCCiudad.SelectedValue) Or IsNothing(cboxRFCCiudad.SelectedValue) Then
            show_message("Advertencia", "Falta información")
            lblRFCCiudad.ForeColor = Color.Red
            Return False
        Else
            If cboxRFCCiudad.SelectedValue = 0 Then
                show_message("Advertencia", "Falta información")
                lblRFCCiudad.ForeColor = Color.Red
                Return False
            Else
                lblRFCCiudad.ForeColor = Color.Black
            End If
        End If

        If String.IsNullOrEmpty(numRFCCodigoPostal.Text) Then
            show_message("Advertencia", "Falta información")
            lblRFCCodigoPostal.ForeColor = Color.Red
            Return False
        ElseIf LTrim(RTrim(numRFCCodigoPostal.Text)).Length < 5 Then
            show_message("Advertencia", "Código Postal incorrecto")
            lblRFCCodigoPostal.ForeColor = Color.Red
            Return False
        End If

        If pnlRegimen.Enabled = True Then
            If cboxRegimenFis.SelectedIndex > 0 Then
                lblRegimenFiscal.ForeColor = Color.Black
            Else
                show_message("Advertencia", "Falta seleccionar un Régimen Fiscal")
                lblRegimenFiscal.ForeColor = Color.Red
                Return False
            End If
        End If
       

        Return True

    End Function

    Public Function alta_RFC_Framework_Persona() As Boolean

        Dim personaBU As New Framework.Negocios.PersonasBU

        Dim persona As New Entidades.Persona
        Dim tipoPersona As New Entidades.TipoPersona
        Dim clasificacionPersona As New Entidades.ClasificacionPersona
        Dim cliente As New Entidades.Cliente

        cliente.clienteid = CInt(lblClienteSAYID_Int.Text)

        persona.nombre = txtRFCNombre.Text

        If rbtnRFCTipoRFCFactura.Checked Then
            clasificacionPersona.clasificacionpersonaid = 14
            rfc_CP = 14
            lblRFCTipoRFC.ForeColor = Color.Black
        ElseIf rbtnRFCTipoRFCRemision.Checked Then
            clasificacionPersona.clasificacionpersonaid = 13
            rfc_CP = 13
            lblRFCTipoRFC.ForeColor = Color.Black
        End If
        tipoPersona.clasificacionpersona = clasificacionPersona

        If cboxRegimenFis.SelectedIndex > 0 Then
            tipoPersona.regimenFiscalId = cboxRegimenFis.SelectedValue
        End If

        Try
            personaBU.AltaPersona(persona, cliente, Nothing, tipoPersona, 1)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function editar_RFC_Framework_Persona(bandera As Integer) As Boolean

        Dim personaBU As New Framework.Negocios.PersonasBU
        Dim persona As New Entidades.Persona
        Dim email As New Entidades.Email

        persona.personaid = CInt(lblRFCPersonaID_Int.Text)
        persona.nombre = txtRFCNombre.Text
        persona.razonsocial = txtRFCRazonSocial.Text
        persona.CURP = txtRFCCurp.Text
        persona.SicyID = cboxRFCSICYID.SelectedValue
        email.email = txtRFCemail.Text

        If rbtnRFCPersonaFisica.Checked Then
            persona.personafisica = True
        ElseIf rbtnRFCPersonaMoral.Checked Then
            rbtnRFCPersonaFisica.Checked = False
        End If

        If rbtnRFCEstatusActivo.Checked Then
            persona.activo = True
        Else
            persona.activo = False
        End If


        Try
            personaBU.EditarPersona(persona, CInt(lblClienteSAYID_Int.Text), email, bandera)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Sub editar_RFC_Cliente_ClienteRFC()
        ModoEdicion = True

        Dim clientesDatosBU As New Negocios.ClientesDatosBU
        Dim clienteRFC As New Entidades.ClienteRFC
        Dim clienteRFCAFacturar As New Entidades.ClienteRFC
        Dim persona As New Entidades.Persona
        Dim tipoPersona As New Entidades.TipoPersona
        Dim clasificacionPersonas As New Entidades.ClasificacionPersona
        Dim ramo As New Entidades.Ramo
        Dim ruta As New Entidades.Ruta
        Dim incoterm As New Entidades.Incoterms

        persona.personaid = CInt(lblRFCPersonaID_Int.Text)

        If rbtnRFCTipoRFCFactura.Checked Then
            clasificacionPersonas.clasificacionpersonaid = 14
        ElseIf rbtnRFCTipoRFCRemision.Checked Then
            clasificacionPersonas.clasificacionpersonaid = 13
        Else
        End If
        clienteRFC.persona = persona
        clienteRFC.clasificacionpersona = clasificacionPersonas

        If rbtnRFCTipoRFCFactura.Checked Then
            clasificacionPersonas.clasificacionpersonaid = 14
            rfc_CP = 14
            lblRFCTipoRFC.ForeColor = Color.Black
        ElseIf rbtnRFCTipoRFCRemision.Checked Then
            clasificacionPersonas.clasificacionpersonaid = 13
            rfc_CP = 13
            lblRFCTipoRFC.ForeColor = Color.Black
        End If
        tipoPersona.clasificacionpersona = clasificacionPersonas

        If cboxRFCRFCAFacturar.Enabled Then
            If IsDBNull(cboxRFCRFCAFacturar.SelectedValue) Then
                clienteRFCAFacturar.clienterfcid = 0
            Else
                clienteRFCAFacturar.clienterfcid = cboxRFCRFCAFacturar.SelectedValue
            End If
        End If

        clienteRFC.clienterfcafacturar = clienteRFCAFacturar

        If cboxRFCRamo.SelectedIndex < 1 Then
            ramo.ramoid = 0
        Else
            ramo.ramoid = cboxRFCRamo.SelectedValue
            clienteRFC.ramo = ramo
        End If

        'If cboxRFCRuta.SelectedIndex < 1 Then
        'Else
        '    ruta.rutaid = cboxRFCRuta.SelectedValue
        '    clienteRFC.ruta = ruta
        'End If

        If cboxRFCIncoterm.SelectedIndex < 1 Then
        Else
            incoterm.incotermsid = cboxRFCIncoterm.SelectedValue
            clienteRFC.incoterm = incoterm
        End If


        If txtRFCRFC.TextLength < 1 Then
            clienteRFC.RFC = Nothing
        Else
            clienteRFC.RFC = txtRFCRFC.Text
        End If

        clienteRFC.porcentajefacturar = CDec(numRFCPorcentajeAFacturar.Value)
        clienteRFC.porcentajeremisionar = CDec(numRFCPorcentajeARemisionar.Value)
        If txtRFCComentarios.TextLength < 1 Then
            clienteRFC.comentarios = String.Empty
        Else
            clienteRFC.comentarios = txtRFCComentarios.Text
        End If

        If rbtnRFCEstatusActivo.Checked Then
            clienteRFC.activo = True
        ElseIf rbtnRFCEstatusInactivo.Checked Then
            clienteRFC.activo = False
        Else
        End If


        If cboxRegimenFis.SelectedIndex > 0 Then
            tipoPersona.regimenFiscalId = cboxRegimenFis.SelectedValue
        End If


        If persona.personaid = 0 Then
            clientesDatosBU.editarClienteClienteRFC(clienteRFC, tipoPersona, 1)
        Else
            clientesDatosBU.editarClienteClienteRFC(clienteRFC, tipoPersona, 2)
        End If
    End Sub

    Public Sub editar_RFC_Framework_Domicilio()

        Dim datosClienteBU As New Negocios.ClientesDatosBU
        Dim domicilio As New Entidades.Domicilio

        domicilio.calle = txtRFCCalle.Text
        domicilio.numexterior = txtRFCNumeroExterior.Text

        If txtRFCNumeroInterior.TextLength < 1 Then
            domicilio.numinterior = Nothing
        Else
            domicilio.numinterior = txtRFCNumeroInterior.Text
        End If

        domicilio.colonia = txtRFCColonia.Text
        domicilio.cp = numRFCCodigoPostal.Text

        Dim Ciudad As New Entidades.Ciudades
        Ciudad.CciudadId = cboxRFCCiudad.SelectedValue
        domicilio.ciudad = Ciudad

        Dim Estado As New Entidades.Estados
        Estado.EIDDEstado = cboxRFCEstado.SelectedValue
        domicilio.estado = Estado

        Dim Pais As New Entidades.Paises
        Pais.PIDPais = cboxRFCPais.SelectedValue
        domicilio.pais = Pais

        If chboxRFCPoblacion.Checked Then
            Dim Poblacion As New Entidades.Poblacion

            If IsDBNull(cboxRFCPoblacion.SelectedValue) Then
                Poblacion.poblacionid = 0
            Else
                Poblacion.poblacionid = cboxRFCPoblacion.SelectedValue
            End If
            domicilio.poblacion = Poblacion
        Else
            domicilio.poblacion = Nothing
        End If

        Dim Persona As New Entidades.Persona
        Persona.personaid = CInt(lblRFCPersonaID_Int.Text)
        domicilio.persona = Persona

        Dim clasificacionPersona As New Entidades.ClasificacionPersona

        If rbtnRFCTipoRFCFactura.Checked Then
            clasificacionPersona.clasificacionpersonaid = 14
        ElseIf rbtnRFCTipoRFCRemision.Checked Then
            clasificacionPersona.clasificacionpersonaid = 13
        Else
        End If

        domicilio.clasificacionpersona = clasificacionPersona

        If Persona.personaid = 0 Then
            Try
                datosClienteBU.altaDomicilioCliente(domicilio, 2)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            Try
                datosClienteBU.editarDomicilioCliente(domicilio, 1)
            Catch ex As Exception
                Exit Sub
            End Try
        End If

        show_message("Exito", "Datos guardados con éxito")

    End Sub

    Public Sub recuperar_datos_Panel_RFC(personaID As Integer)

        limpiarControles(pnlFormRFC)
        asignaStatusControles(pnlFormRFC, False)
        rbtnRFCEstatusActivo.Checked = True

        'PERSONA
        Dim personaBU As New Framework.Negocios.PersonasBU
        Dim persona As New DataTable
        Dim dtRegimenFiscal As New DataTable
        Dim dtRegimenFiscalId As New DataTable
        persona = personaBU.Datos_TablaPersona(personaID)

        If persona.Rows.Count > 0 Then
            lblRFCPersonaID_Int.Text = CStr(persona.Rows(0).Item("pers_personaid"))
            txtRFCNombre.Text = CStr(persona.Rows(0).Item("pers_nombre"))


            If IsDBNull(persona.Rows(0).Item("pers_CURP")) Then
                txtRFCCurp.Text = String.Empty
            Else
                txtRFCCurp.Text = CStr(persona.Rows(0).Item("pers_CURP"))
            End If

            If IsDBNull(persona.Rows(0).Item("pers_razonsocial")) Then
                txtRFCRazonSocial.Text = String.Empty
            Else
                txtRFCRazonSocial.Text = CStr(persona.Rows(0).Item("pers_razonsocial"))
            End If

            If IsDBNull(persona.Rows(0).Item("empe_email")) Then
                txtRFCemail.Text = String.Empty
            Else
                txtRFCemail.Text = CStr(persona.Rows(0).Item("empe_email"))
            End If


            If IsDBNull(persona.Rows(0).Item("pers_personafisica")) Then
                rbtnRFCPersonaFisica.Checked = False
                rbtnRFCPersonaMoral.Checked = False
            Else
                If CBool(persona.Rows(0).Item("pers_personafisica")) Then
                    rbtnRFCPersonaFisica.Checked = True
                    rbtnRFCPersonaMoral.Checked = False
                Else
                    rbtnRFCPersonaFisica.Checked = False
                    rbtnRFCPersonaMoral.Checked = True
                End If
            End If

            dtRegimenFiscal = personaBU.regimenPersonaMoralFisica(CBool(persona.Rows(0).Item("pers_personafisica")))
            If dtRegimenFiscal.Rows.Count > 0 Then
                Dim newRow As DataRow = dtRegimenFiscal.NewRow
                dtRegimenFiscal.Rows.InsertAt(newRow, 0)
            End If

            cboxRegimenFis.DataSource = dtRegimenFiscal
            cboxRegimenFis.ValueMember = "idRegimenfiscal"
            cboxRegimenFis.DisplayMember = "Regimen"

            dtRegimenFiscalId = personaBU.regimenPersonaMoralFisicaId(personaID)
           
            If Not IsDBNull(dtRegimenFiscalId.Rows(0).Item("crfc_regimenfiscalid")) Then
                cboxRegimenFis.SelectedValue = dtRegimenFiscalId.Rows(0).Item("crfc_regimenfiscalid")
            Else

            End If
           

            If CBool(persona.Rows(0).Item("pers_activo")) Then
                rbtnRFCEstatusActivo.Checked = True
                rbtnRFCEstatusInactivo.Checked = False
            Else
                rbtnRFCEstatusActivo.Checked = False
                rbtnRFCEstatusInactivo.Checked = True
            End If

            ListaRFC_Sicy(cboxRFCSICYID, CInt(txtClienteSICYID.Text), 0, ModoEdicion)
            If IsDBNull(persona.Rows(0).Item("pers_IdSICY")) Then
                cboxRFCSICYID.Text = String.Empty
            Else
                Dim value As String = CStr(persona.Rows(0).Item("pers_IdSICY"))
                cboxRFCSICYID.SelectedValue = CStr(persona.Rows(0).Item("pers_IdSICY"))
            End If
        End If

        'CLIENTE RFC
        Dim clientesDatosBU As New Negocios.ClientesDatosBU
        Dim clienteRFC As New DataTable
        clienteRFC = clientesDatosBU.Datos_TablaClienteRFC(personaID)
        If clienteRFC.Rows.Count > 0 Then
            If IsDBNull(clienteRFC.Rows(0).Item("crfc_clasificacionpersonaid")) Then
                rbtnRFCTipoRFCFactura.Checked = False
                rbtnRFCTipoRFCRemision.Checked = False
            Else
                If CInt(clienteRFC.Rows(0).Item("crfc_clasificacionpersonaid")) = 13 Then
                    pnlRegimen.Enabled = False

                    rbtnRFCTipoRFCRemision.Checked = True
                    rbtnRFCTipoRFCFactura.Checked = False
                ElseIf CInt(clienteRFC.Rows(0).Item("crfc_clasificacionpersonaid")) = 14 Then
                    pnlRegimen.Enabled = True
                    rbtnRFCTipoRFCRemision.Checked = False
                    rbtnRFCTipoRFCFactura.Checked = True
                End If
            End If

            ListaClienteRFCFactura(cboxRFCRFCAFacturar, CInt(lblClienteSAYID_Int.Text))
            cboxRFCRFCAFacturar.Enabled = False
            If IsDBNull(clienteRFC.Rows(0).Item("crfc_clienterfcidafacturar")) Then
                cboxRFCRFCAFacturar.Text = String.Empty
            Else
                cboxRFCRFCAFacturar.SelectedValue = CInt(clienteRFC.Rows(0).Item("crfc_clienterfcidafacturar"))
            End If

            ListaIncoterms(cboxRFCIncoterm)
            If IsDBNull(clienteRFC.Rows(0).Item("crfc_incotermid")) Then
                cboxRFCIncoterm.Text = String.Empty
            Else
                cboxRFCIncoterm.SelectedValue = CInt(clienteRFC.Rows(0).Item("crfc_incotermid"))
            End If

            ListaRamos(cboxRFCRamo)
            If IsDBNull(clienteRFC.Rows(0).Item("crfc_ramoid")) Then
                cboxRFCRamo.Text = String.Empty
            Else
                cboxRFCRamo.SelectedValue = CInt(clienteRFC.Rows(0).Item("crfc_ramoid"))
            End If

            'ListaRutas(cboxRFCRuta)
            'If IsDBNull(clienteRFC.Rows(0).Item("crfc_rutaid")) Then
            '    cboxRFCRuta.Text = String.Empty
            'Else
            '    cboxRFCRuta.SelectedValue = CInt(clienteRFC.Rows(0).Item("crfc_rutaid"))
            'End If

            If IsDBNull(clienteRFC.Rows(0).Item("crfc_RFC")) Then
                txtRFCRFC.Text = String.Empty
            Else
                txtRFCRFC.Text = CStr(clienteRFC.Rows(0).Item("crfc_RFC"))
            End If

            Dim cant As Int16 = 0

            If IsDBNull(clienteRFC.Rows(0).Item("crfc_porcentajefacturar")) Then
                numRFCPorcentajeAFacturar.Value = 1
                numRFCPorcentajeAFacturar.Value = 0
            Else
                numRFCPorcentajeAFacturar.Value = numRFCPorcentajeAFacturar.Value + 1
                cant = CInt(clienteRFC.Rows(0).Item("crfc_porcentajefacturar"))
                numRFCPorcentajeAFacturar.Value = cant
            End If

            'If IsDBNull(clienteRFC.Rows(0).Item("crfc_porcentajeremisionar")) Then
            '    numRFCPorcentajeARemisionar.Value = 0
            'Else
            '    cant = 0
            '    cant = CInt(clienteRFC.Rows(0).Item("crfc_porcentajeremisionar"))
            '    numRFCPorcentajeARemisionar.Value = cant
            'End If

            If IsDBNull(clienteRFC.Rows(0).Item("crfc_comentarios")) Then
                txtRFCComentarios.Text = String.Empty
            Else
                txtRFCComentarios.Text = CStr(clienteRFC.Rows(0).Item("crfc_comentarios"))
            End If

            If CBool(clienteRFC.Rows(0).Item("crfc_activo")) Then
                rbtnRFCEstatusActivo.Checked = True
                rbtnRFCEstatusInactivo.Checked = False
            Else
                rbtnRFCEstatusActivo.Checked = False
                rbtnRFCEstatusInactivo.Checked = True
            End If

        End If

        'DOMICILIO

        Dim domicilio As New DataTable
        Dim DomicilioBU As New Framework.Negocios.DomicilioBU
        domicilio = DomicilioBU.Datos_TablaDomicilioPersona(personaID)

        If domicilio.Rows.Count > 0 Then

            txtRFCCalle.Text = CStr(domicilio.Rows(0).Item("domi_calle"))
            If IsDBNull(domicilio.Rows(0).Item("domi_numinterior")) Then
                txtRFCNumeroInterior.Text = String.Empty
            Else
                txtRFCNumeroInterior.Text = CStr(domicilio.Rows(0).Item("domi_numinterior"))
            End If

            txtRFCNumeroExterior.Text = CStr(domicilio.Rows(0).Item("domi_numexterior"))
            txtRFCColonia.Text = CStr(domicilio.Rows(0).Item("domi_colonia"))
            cboxRFCPais.Text = CStr(domicilio.Rows(0).Item("pais_nombre"))
            ListaPais(cboxRFCPais)
            cboxRFCPais.SelectedValue = CInt(domicilio.Rows(0).Item("pais_paisid"))
            cboxRFCEstado.Text = CStr(domicilio.Rows(0).Item("esta_nombre"))
            ListaEstado(cboxRFCEstado, CInt(cboxRFCPais.SelectedValue))
            cboxRFCEstado.SelectedValue = CInt(domicilio.Rows(0).Item("esta_estadoid"))
            cboxRFCCiudad.Text = CStr(domicilio.Rows(0).Item("city_nombre"))
            ListaCiudad(cboxRFCCiudad, CInt(cboxRFCEstado.SelectedValue))
            cboxRFCCiudad.SelectedValue = CInt(domicilio.Rows(0).Item("city_ciudadid"))
            If IsDBNull(domicilio.Rows(0).Item("domi_cp")) Then
                numRFCCodigoPostal.Text = String.Empty
            Else
                numRFCCodigoPostal.Text = CStr(domicilio.Rows(0).Item("domi_cp"))
            End If

            ListaPoblacion(cboxRFCPoblacion, CInt(cboxDatosCiudad.SelectedValue))

            If IsDBNull(domicilio.Rows(0).Item("pobl_nombre")) Then
                cboxRFCPoblacion.Text = String.Empty
                chboxDatosPoblacion.Checked = False
            Else
                cboxRFCPoblacion.Text = CStr(domicilio.Rows(0).Item("pobl_nombre"))
                cboxRFCPoblacion.SelectedValue = CInt(domicilio.Rows(0).Item("pobl_poblacionid"))
                chboxDatosPoblacion.Checked = True
            End If

            If IsDBNull(domicilio.Rows(0).Item("domi_delegacion")) Then
                txtRFCCiudadCisy.Text = String.Empty
            Else
                txtRFCCiudadCisy.Text = CStr(domicilio.Rows(0).Item("domi_delegacion"))
            End If

        End If

        If rbtnClienteStatusInactivo.Checked Then
            btnEditarRFC.Enabled = False
        Else
            If CInt(lblRFCPersonaID_Int.Text) = 0 Then
                btnEditarRFC.Enabled = False
            Else
                If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
                    btnEditarRFC.Enabled = True
                    btnRFCAltaRFC.Enabled = True
                    btnRFCVincularTECs.Enabled = True
                Else
                    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
                        btnEditarRFC.Enabled = True
                        btnRFCAltaRFC.Enabled = True
                        btnRFCVincularTECs.Enabled = True
                    Else
                        btnEditarRFC.Enabled = False
                        btnRFCAltaRFC.Enabled = False
                        btnRFCVincularTECs.Enabled = False

                    End If
                End If
            End If
        End If

        ''INACTIVAR LAS FILAS DEL GRID DE CORREOS
        For Each row In gridRFCEmails.Selected.Rows
            Dim i As Integer = gridRFCEmails.Rows.Count
            gridRFCEmails.DisplayLayout.Rows(row.Index).Activation = Activation.NoEdit
            gridRFCEmails.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        Next

        '' INACTIVAR LAS FILAS DEL GRID TELEFONOS
        For Each row In gridRFCTelefono.Selected.Rows
            Dim i As Integer = gridRFCTelefono.Rows.Count
            gridRFCTelefono.DisplayLayout.Rows(row.Index).Activation = Activation.NoEdit
            gridRFCTelefono.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        Next

        poblar_gridRFCEmails(personaID)
        poblar_gridRFCTelefono(personaID)

    End Sub

    ''rfc
#Region "Mantener color de fuente azul"
    Private Sub lblVincularTECS_ForeColorChanged(sender As Object, e As EventArgs) Handles lblVincularTECS.ForeColorChanged
        If lblVincularTECS.ForeColor <> Color.DodgerBlue Then
            lblVincularTECS.ForeColor = Color.DodgerBlue
        End If
    End Sub

    Private Sub lblRFCAltaRFC_ForeColorChanged(sender As Object, e As EventArgs) Handles lblRFCAltaRFC.ForeColorChanged
        If lblRFCAltaRFC.ForeColor <> Color.DodgerBlue Then
            lblRFCAltaRFC.ForeColor = Color.DodgerBlue
        End If
    End Sub

    Private Sub lblVincularTecs2_ForeColorChanged(sender As Object, e As EventArgs) Handles lblVincularTecs2.ForeColorChanged
        If lblVincularTecs2.ForeColor <> Color.DodgerBlue Then
            lblVincularTecs2.ForeColor = Color.DodgerBlue
        End If
    End Sub

    Private Sub lblGuardarRFC_ForeColorChanged(sender As Object, e As EventArgs) Handles lblGuardarRFC.ForeColorChanged
        If lblGuardarRFC.ForeColor <> Color.DodgerBlue Then
            lblGuardarRFC.ForeColor = Color.DodgerBlue
        End If
    End Sub

    Private Sub lblEditarRFC_ForeColorChanged(sender As Object, e As EventArgs) Handles lblEditarRFC.ForeColorChanged
        If lblEditarRFC.ForeColor <> Color.DodgerBlue Then
            lblEditarRFC.ForeColor = Color.DodgerBlue
        End If
    End Sub

    Private Sub lblCancelarlRFC_ForeColorChanged(sender As Object, e As EventArgs) Handles lblCancelarlRFC.ForeColorChanged
        If lblCancelarlRFC.ForeColor <> Color.DodgerBlue Then
            lblCancelarlRFC.ForeColor = Color.DodgerBlue
        End If
    End Sub
#End Region

#Region "Alimentar automaticamente valores de porcentajes a facturar y remisionar"
    Private Sub numRFCPorcentajeARemisionar_EnabledChanged(sender As Object, e As EventArgs) Handles numRFCPorcentajeARemisionar.EnabledChanged
        If numRFCPorcentajeARemisionar.Enabled Then
            numRFCPorcentajeARemisionar.Enabled = False
        End If
    End Sub

    Private Sub numRFCPorcentajeAFacturar_ValueChanged(sender As Object, e As EventArgs) Handles numRFCPorcentajeAFacturar.ValueChanged
        numRFCPorcentajeARemisionar.Value = 100 - numRFCPorcentajeAFacturar.Value
    End Sub

    Private Sub numRFCPorcentajeAFacturar_Leave(sender As Object, e As EventArgs) Handles numRFCPorcentajeAFacturar.Leave
        If numRFCPorcentajeAFacturar.Value = 0 Then
            numRFCPorcentajeAFacturar.Value = numRFCPorcentajeAFacturar.Value + 1
            numRFCPorcentajeAFacturar.Value = numRFCPorcentajeAFacturar.Value - 1
        Else
            numRFCPorcentajeAFacturar.Value = numRFCPorcentajeAFacturar.Value - 1
            numRFCPorcentajeAFacturar.Value = numRFCPorcentajeAFacturar.Value + 1
        End If

    End Sub
#End Region


    Private Sub btnRFCAltaRFC_Click(sender As Object, e As EventArgs) Handles btnRFCAltaRFC.Click
        Dim grid As DataTable = gridClienteRFC.DataSource
        Dim row As UltraGridRow = gridClienteRFC.ActiveRow

        limpiarControles(pnlFormRFC)
        asignaStatusControles(pnlFormRFC, True)

        pnlRFCTipoRFC.Enabled = True
        pnlRFCTipoPersona.Enabled = True

        If Not pnlRFCTipoRFC.Enabled Then Return

        If rbtnRFCTipoRFCRemision.Checked Then
            cboxRFCRFCAFacturar.Enabled = True
        Else
            cboxRFCRFCAFacturar.Enabled = False
        End If

        rbtnRFCEstatusActivo.Checked = True

        ListaRamos(cboxRFCRamo)
        'ListaRutas(cboxRFCRuta)
        ListaPais(cboxRFCPais)
        ListaEstado(cboxRFCEstado, cboxRFCPais.SelectedValue)
        ListaClienteRFCFactura(cboxRFCRFCAFacturar, CInt(lblClienteSAYID_Int.Text))
        ListaIncoterms(cboxRFCIncoterm)
        ListaRFC_Sicy(cboxRFCSICYID, CInt(txtClienteSICYID.Text), 0, True)

       


        ''RECUPERAR DOMICILIO DEL CLIENTE
        Dim domicilio As New DataTable
        Dim DomicilioBU As New Framework.Negocios.DomicilioBU
        domicilio = DomicilioBU.Datos_TablaDomicilioPersona(CInt(lblClientePersonaID_Int.Text))

        If domicilio.Rows.Count > 0 Then

            txtRFCCalle.Text = CStr(domicilio.Rows(0).Item("domi_calle"))
            If IsDBNull(domicilio.Rows(0).Item("domi_numinterior")) Then
                txtRFCNumeroExterior.Text = String.Empty
            Else
                txtRFCNumeroInterior.Text = CStr(domicilio.Rows(0).Item("domi_numinterior"))
            End If

            txtRFCNumeroExterior.Text = CStr(domicilio.Rows(0).Item("domi_numexterior"))
            txtRFCColonia.Text = CStr(domicilio.Rows(0).Item("domi_colonia"))
            cboxRFCPais.Text = CStr(domicilio.Rows(0).Item("pais_nombre"))

            ListaPais(cboxRFCPais)
            cboxRFCPais.SelectedValue = CInt(domicilio.Rows(0).Item("pais_paisid"))

            ListaEstado(cboxRFCEstado, CInt(cboxRFCPais.SelectedValue))
            cboxRFCEstado.SelectedValue = CInt(domicilio.Rows(0).Item("esta_estadoid"))

            ListaCiudad(cboxRFCCiudad, CInt(cboxRFCEstado.SelectedValue))
            cboxRFCCiudad.SelectedValue = CInt(domicilio.Rows(0).Item("city_ciudadid"))

            If IsDBNull(domicilio.Rows(0).Item("domi_cp")) Then
                numRFCCodigoPostal.Text = String.Empty
            Else
                numRFCCodigoPostal.Text = CStr(domicilio.Rows(0).Item("domi_cp"))
            End If

            ListaPoblacion(cboxRFCPoblacion, CInt(cboxRFCCiudad.SelectedValue))
            If IsDBNull(domicilio.Rows(0).Item("pobl_nombre")) Then
                cboxRFCPoblacion.Text = String.Empty
                chboxRFCPoblacion.Checked = False
            Else
                cboxRFCPoblacion.SelectedValue = CInt(domicilio.Rows(0).Item("pobl_poblacionid"))
                chboxRFCPoblacion.Checked = True
            End If

            cboxRFCPoblacion.Enabled = False

            If IsDBNull(domicilio.Rows(0).Item("domi_delegacion")) Then
                txtRFCCiudadCisy.Text = String.Empty
            Else
                txtRFCCiudadCisy.Text = CStr(domicilio.Rows(0).Item("domi_delegacion"))
            End If

        End If


        lblRFCPersonaID_Int.Text = 0
        ModoEdicion = True
        btnRFCAltaRFC.Enabled = False
        btnRFCVincularTECs.Enabled = False

        gridRFCRFC.ActiveRow = Nothing


    End Sub

    Private Sub btnRFCVincularTECs_Click(sender As Object, e As EventArgs) Handles btnRFCVincularTECs.Click
        Dim grid As DataTable = gridClienteRFC.DataSource
        Dim row As UltraGridRow = gridClienteRFC.ActiveRow

        If IsNothing(gridRFCRFC.ActiveRow) Then

        Else
            If row.IsDataRow Then

                If AreaOperativa <> 9 Then Return

                If gridClienteRFC.ActiveRow Is Nothing Then Return

                Dim personaID As Integer = CInt(row.Cells(0).Value)

                If personaID = 0 Then Return

                Dim vinculacion As New VinculacionTEC_RFC_Form
                vinculacion.rfcID = CInt(row.Cells(1).Value)
                vinculacion.rfc = row.Cells("clpe_nombre").Text + " - " + row.Cells("pers_nombre").Text + " (" + row.Cells("crfc_rfc").Text + ")"
                vinculacion.clienteID = CInt(lblClienteSAYID_Int.Text)
                vinculacion.ClienteNombre = cboxClienteCliente.Text
                vinculacion.ShowDialog()
            Else
                Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione un RFC para poder vincular TECs.")
            End If

        End If
      

    End Sub


    Private Sub txtRFCNombre_Leave(sender As Object, e As EventArgs) Handles txtRFCNombre.Leave
        If lblRFCPersonaID_Int.Text = 0 Then
            txtRFCRazonSocial.Text = txtRFCNombre.Text
        End If

    End Sub

    Private Sub txtRFCCiudadCisy_EnabledChanged(sender As Object, e As EventArgs) Handles txtRFCCiudadCisy.EnabledChanged
        If txtRFCCiudadCisy.Enabled = True Then
            txtRFCCiudadCisy.Enabled = False
        End If
    End Sub


#Region "GRID RFC TELEFONO"

    Private Sub btnRFC_AltaTelefono_Click(sender As Object, e As EventArgs) Handles btnRFC_AltaTelefono.Click
        Dim grid As DataTable = gridRFCTelefono.DataSource
        Dim tipoTelefono As UltraGridColumn = gridRFCTelefono.DisplayLayout.Bands(0).Columns(3)

        gridRFCTelefono.Focus()
        LimpiarFiltrosGrid(gridRFCTelefono)

        grid.Rows.Add(0, String.Empty, String.Empty, 0, "--Selecciona--", CInt(gridRFCRFC.ActiveRow.Cells(0).Value), True)

        gridRFCTelefono.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True
        Try
            gridRFCTelefono.ActiveRow.Activation = Activation.AllowEdit
            gridRFCTelefono.ActiveCell = gridRFCTelefono.ActiveRow.Cells(1)
            gridRFCTelefono.ActiveCell.Activation = Activation.AllowEdit
            gridRFCTelefono.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
        Catch ex As Exception

        End Try

        gridRFCTelefono.PerformAction(UltraGridAction.ToggleCellSel, False, False)
        gridRFCTelefono.PerformAction(UltraGridAction.EnterEditMode, False, False)
        
    End Sub

    Public Sub poblar_gridRFCTelefono(personaID As Integer)

        gridRFCTelefono.DataSource = Nothing

        Dim clientesBU As New Negocios.ClientesDatosBU
        Dim contactosBU As New Framework.Negocios.ContactosBU
        Dim telefonos As New DataTable
        Dim TipoTelefono As New DataTable

        Dim vlTipoTelefono As New Infragistics.Win.ValueList

        telefonos = clientesBU.Datos_ClienteRFCTelefonos(personaID, AreaOperativa)

        TipoTelefono = contactosBU.TablaTipoTelefonos()

        For Each fila As DataRow In TipoTelefono.Rows
            vlTipoTelefono.ValueListItems.Add(fila.Item("tite_tipotelefonoid"), fila.Item("tite_nombre"))
        Next

        gridRFCTelefono.DataSource = telefonos
        gridRFCTelefono.DisplayLayout.Bands(0).Columns(4).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        gridRFCTelefono.DisplayLayout.Bands(0).Columns(4).ValueList = vlTipoTelefono

        gridRFCTelefonoDiseno(gridRFCTelefono)
        gridRFCTelefono.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti

    End Sub

    Private Sub gridRFCTelefonoDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(3).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(5).Hidden = True


        grid.DisplayLayout.Bands(0).Columns(1).Header.Caption = "*TELÉFONO"
        grid.DisplayLayout.Bands(0).Columns(1).Format = "n0"
        grid.DisplayLayout.Bands(0).Columns(1).MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
        grid.DisplayLayout.Bands(0).Columns(1).CellAppearance.TextHAlign = HAlign.Right


        grid.DisplayLayout.Bands(0).Columns(2).Header.Caption = "*EXTENSIÓN"
        grid.DisplayLayout.Bands(0).Columns(2).Format = "n0"
        grid.DisplayLayout.Bands(0).Columns(2).MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
        grid.DisplayLayout.Bands(0).Columns(2).CellAppearance.TextHAlign = HAlign.Right


        grid.DisplayLayout.Bands(0).Columns(4).Header.Caption = "*TIPO TÉLEFONO"
        grid.DisplayLayout.Bands(0).Columns("tele_activo").Header.Caption = "*ACTIVO"

        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        'grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti


        For Each row In grid.Rows
            row.Activation = Activation.AllowEdit
        Next
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.Edit

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Bands(0).Columns("tele_activo").Width = 40
    End Sub

    Private Sub gridRFCTelefono_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridRFCTelefono.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub gridRFCTelefono_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridRFCTelefono.DoubleClickHeader

        If Me.gridRFCTelefono.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.gridRFCTelefono.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.gridRFCTelefono.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.gridRFCTelefono.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.gridRFCTelefono.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.gridRFCTelefono.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.gridRFCTelefono.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If

    End Sub

    Private Sub gridRFCTelefono_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles gridRFCTelefono.BeforeCellUpdate
        If gridRFCTelefono.ActiveRow.IsFilterRow Then Return
        If e.Cell.Column.ToString = "tele_activo" Then
            If gridRFCTelefono.ActiveRow.Cells(0).Text = 0 Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Function ValidarCamposVacios_RFCTelefono() As Boolean
        ValidarCamposVacios_RFCTelefono = False

        Dim Telefono As String = (((((RTrim(LTrim(gridRFCTelefono.ActiveRow.Cells("tele_telefono").Text)).Replace("+", "")).Replace("-", "")).Replace("(", "")).Replace(")", "")).Replace(" ", "")).Replace("_", "")

        If Telefono = "" Then
            Mensajes_Y_Alertas("ADVERTENCIA", "Ingrese un teléfono ó presione ""ESCAPE"" para cancelar esta acción.")
            ValidarCamposVacios_RFCTelefono = True
        ElseIf Telefono.Length < 7 Then
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Agregue un teléfono con un minimo de 7 digitos ó presione ""ESCAPE"" para cancelar esta acción.")
            ValidarCamposVacios_RFCTelefono = True
        ElseIf gridRFCTelefono.ActiveRow.Cells("tite_nombre").Value = "--Selecciona--" Then
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione un tipo de teléfono ó presione ""ESCAPE"" para cancelar esta acción.")
            ValidarCamposVacios_RFCTelefono = True
        End If
        Return ValidarCamposVacios_RFCTelefono
    End Function

    Private Sub gridRFCTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridRFCTelefono.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then

            gridRFCTelefono.ActiveRow.Cells("tele_telefono").Activated = True

            If ValidarCamposVacios_RFCTelefono() Then Return

            Dim NextRowIndex As Integer = gridRFCTelefono.ActiveRow.Index + 1

            Try
                gridRFCTelefono.ActiveRow.Update()
            Catch ex As Exception
                Mensajes_Y_Alertas("ERROR", "Ocurrio un error inesperado al momento de Guardar/Actualizar la informacion del telefono. Error: " + ex.Message)
            End Try

        ElseIf e.KeyChar = ChrW(Keys.Escape) Then
            poblar_gridRFCTelefono(CInt(gridRFCRFC.ActiveRow.Cells(0).Value))
        Else
            If Char.IsNumber(e.KeyChar) = False And (Char.IsLetter(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar)) Then
                e.Handled = True
            Else
                If Char.IsNumber(e.KeyChar) Then

                    If gridRFCTelefono.ActiveRow.Cells("tele_telefono").IsActiveCell Then
                        If gridRFCTelefono.ActiveRow.Cells("tele_telefono").Text.Length = 12 Then
                            e.Handled = True
                        End If
                    ElseIf gridRFCTelefono.ActiveRow.Cells("tele_extension").IsActiveCell Then
                        If gridRFCTelefono.ActiveRow.Cells("tele_extension").Text.Length > 4 Then
                            e.Handled = True
                        End If
                    End If
                End If
            End If
        End If


    End Sub

    Private Sub gridRFCTelefono_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridRFCTelefono.BeforeRowDeactivate
        If gridRFCTelefono.ActiveRow.IsDataRow Then
            If ValidarCamposVacios_RFCTelefono() = True Then
                e.Cancel = True
                Return
            End If
        End If

       

    End Sub

    Private Sub gridRFCTelefono_Leave(sender As Object, e As EventArgs) Handles gridRFCTelefono.Leave
        If Not IsNothing(gridRFCTelefono.ActiveRow) Then
            If gridRFCTelefono.ActiveRow.IsDataRow Then
                If ValidarCamposVacios_RFCTelefono() = True Then
                    gridRFCTelefono.Focus()
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub grdTelefono_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles gridRFCTelefono.BeforeRowUpdate
        Me.Cursor = Cursors.WaitCursor

        If gridRFCTelefono.ActiveRow.IsDataRow Then
            If gridRFCTelefono.ActiveRow.DataChanged Then
                If gridRFCTelefono.ActiveRow.Cells("tite_nombre").Value <> "--Selecciona--" Then
                    Agregar_Editar_RFCTelefono()
                End If
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub gridRFCTelefono_AfterRowActivate(sender As Object, e As EventArgs) Handles gridRFCTelefono.AfterRowActivate
        'gridRFCTelefono.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        'For Each row In gridRFCTelefono.Rows
        '    row.Activation = Activation.NoEdit
        'Next
    End Sub

    Private Sub Agregar_Editar_RFCTelefono()
      
        Dim telefono As New Entidades.Telefono
        Dim tipoTelefono As New Entidades.TipoTelefono
        Dim persona As New Entidades.Persona
        Dim clasificacionPersona As New Entidades.ClasificacionPersona
        Dim objBU As New Negocios.ClientesDatosBU

        Dim row As UltraGridRow = gridRFCTelefono.ActiveRow

        clasificacionPersona.clasificacionpersonaid = CInt(gridRFCRFC.ActiveRow.Cells(1).Value)
        persona.personaid = CInt(gridRFCTelefono.ActiveRow.Cells(5).Value)

        telefono.telefonoid = gridRFCTelefono.ActiveRow.Cells(0).Text

        telefono.activo = gridRFCTelefono.ActiveRow.Cells("tele_activo").Value
        telefono.telefono = gridRFCTelefono.ActiveRow.Cells(1).Text.ToString
            
        If String.IsNullOrWhiteSpace(gridRFCTelefono.ActiveRow.Cells(2).Value.ToString) Then
            telefono.extension = String.Empty
        Else
            telefono.extension = gridRFCTelefono.ActiveRow.Cells(2).Value.ToString
        End If

        tipoTelefono.tipotelefonoid = row.Cells(4).Column.ValueList.GetValue(gridRFCTelefono.ActiveRow.Cells(4).Text, 0)

        If telefono.telefonoid = 0 Then
            If Mensajes_Y_Alertas("CONFIRMACION", "¿Esta seguro que desea agregar este teléfono?.") Then
                objBU.AltaTelefono(persona, clasificacionPersona, telefono, tipoTelefono)
            End If
        Else
            If Mensajes_Y_Alertas("CONFIRMACION", "¿Esta seguro que desea agregar este teléfono?.") Then
                objBU.EditarTelefono(persona, clasificacionPersona, telefono, tipoTelefono)
            End If
        End If

        poblar_gridRFCTelefono(CInt(gridRFCRFC.ActiveRow.Cells(0).Value))
    End Sub

#End Region

#Region "GRID RFC CORREO"

    Private Sub btnRFC_AltaCorreo_Click(sender As Object, e As EventArgs) Handles btnRFC_AltaCorreo.Click
        Dim grid As DataTable = gridRFCEmails.DataSource
        Dim row As UltraGridRow = gridRFCEmails.ActiveRow

        LimpiarFiltrosGrid(gridRFCEmails)
        gridRFCEmails.Focus()

        grid.Rows.Add(0, String.Empty, True)
        gridRFCEmails.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True

        Try
            gridRFCEmails.ActiveRow.Activation = Activation.AllowEdit
            gridRFCEmails.ActiveCell = gridRFCEmails.ActiveRow.Cells(1)
        Catch ex As Exception

        End Try
        gridRFCEmails.PerformAction(UltraGridAction.ToggleCellSel, False, False)
        gridRFCEmails.PerformAction(UltraGridAction.EnterEditMode, False, False)
    End Sub


    'RFC EMAIL
    Public Sub poblar_gridRFCEmails(personaID As Integer)
        gridRFCEmails.DataSource = Nothing

        Dim clientesBU As New Negocios.ClientesDatosBU
        Dim contactosBU As New Framework.Negocios.ContactosBU
        Dim emails As New DataTable

        emails = clientesBU.Datos_ClienteRFCEmails(personaID, AreaOperativa)

        gridRFCEmails.DataSource = emails
        gridRFCEmailsDiseno(gridRFCEmails)
        gridRFCEmails.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
    End Sub

    Private Sub gridRFCEmailsDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(1).Header.Caption = "*CORREO ELECTRÓNICO"
        grid.DisplayLayout.Bands(0).Columns("empe_activo").Header.Caption = "*ACTIVO"


        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

       
            For Each row In grid.Rows
                row.Activation = Activation.AllowEdit
            Next
            grid.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
            grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
       
        grid.DisplayLayout.Bands(0).Columns("empe_activo").Width = 50

    End Sub

    Private Sub gridRFCEmails_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridRFCEmails.DoubleClickHeader

        If Me.gridRFCEmails.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.gridRFCEmails.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.gridRFCEmails.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.gridRFCEmails.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.gridRFCEmails.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.gridRFCEmails.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.gridRFCEmails.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If

    End Sub

    Private Function ValidarCamposVacios_RFCEmail() As Boolean
        ValidarCamposVacios_RFCEmail = False

        If LTrim(RTrim(gridRFCEmails.ActiveRow.Cells(1).Text)) = "" Then
            Mensajes_Y_Alertas("ADVERTENCIA", "Agregue un correo eletrónico ó presione ""ESCAPE"" para cancelar esta acción.")
            ValidarCamposVacios_RFCEmail = True
        End If

        Return ValidarCamposVacios_RFCEmail
    End Function

    Private Sub gridRFCEmails_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridRFCEmails.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim NextRowIndex As Integer = gridRFCEmails.ActiveRow.Index + 1

            If ValidarCamposVacios_RFCEmail() Then
                Return
            Else
                Try
                    gridRFCEmails.DisplayLayout.Rows(NextRowIndex).Activated = True
                    gridRFCEmails.DisplayLayout.Rows(NextRowIndex).Selected = True
                Catch ex As Exception
                    If gridRFCEmails.DisplayLayout.Rows(0).Activated Then
                        gridRFCEmails.DisplayLayout.Rows(0).Activated = False
                        gridRFCEmails.DisplayLayout.Rows(0).Selected = False
                    Else
                        gridRFCEmails.ActiveRow.Activated = False
                    End If
                End Try
            End If
        End If

        If e.KeyChar = ChrW(Keys.Escape) Then
            poblar_gridRFCEmails(CInt(gridRFCRFC.ActiveRow.Cells(0).Value))
        End If

    End Sub

    Private Sub gridRFCEmails_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridRFCEmails.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub gridRFCEmails_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles gridRFCEmails.BeforeCellUpdate
        If gridRFCEmails.ActiveRow.IsFilterRow Then Return
        If e.Cell.Column.ToString = "empe_activo" Then
            If gridRFCEmails.ActiveRow.Cells(0).Value = 0 Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Agregar_Editar_RFC_Correo()
        If Mensajes_Y_Alertas("CONFIRMACION", "¿Esta seguro de guardar este correo electrónico?") Then

            Dim email As New Entidades.Email
            Dim persona As New Entidades.Persona
            Dim clasificacionPersona As New Entidades.ClasificacionPersona
            Dim objBU As New Negocios.ClientesDatosBU
            Dim row As UltraGridRow = gridRFCEmails.ActiveRow

            clasificacionPersona.clasificacionpersonaid = CInt(gridRFCRFC.ActiveRow.Cells(1).Value)
            persona.personaid = CInt(gridRFCRFC.ActiveRow.Cells(0).Value)

            email.emailpersonasid = gridRFCEmails.ActiveRow.Cells("empe_emailpersonasid").Value
            If email.emailpersonasid = 0 Then
                email.activo = True
            Else
                email.activo = CBool(gridRFCEmails.ActiveRow.Cells("empe_activo").Text)
            End If
            email.email = gridRFCEmails.ActiveRow.Cells("empe_email").Value.ToString

            If email.emailpersonasid = 0 Then
                objBU.AltaEmail(persona, clasificacionPersona, email)
            Else
                objBU.EditarEmail(persona, clasificacionPersona, email)

            End If

        End If

        poblar_gridRFCEmails(CInt(gridRFCRFC.ActiveRow.Cells(0).Value))
    End Sub

    Private Sub gridRFCEmails_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridRFCEmails.BeforeRowDeactivate
        If gridRFCEmails.ActiveRow.IsDataRow Then
            If gridRFCEmails.ActiveRow.DataChanged Then
                If ValidarCamposVacios_RFCEmail() = True Then
                    e.Cancel = True
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub gridRFCEmails_Leave(sender As Object, e As EventArgs) Handles gridRFCEmails.Leave
        If Not IsNothing(gridRFCEmails.ActiveRow) Then
            If gridRFCEmails.ActiveRow.IsDataRow Then
                If gridRFCEmails.ActiveRow.DataChanged Or ValidarCamposVacios_RFCEmail() = True Then
                    gridRFCEmails.Focus()
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub gridRFCEmails_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles gridRFCEmails.BeforeRowUpdate
        Me.Cursor = Cursors.WaitCursor
        If gridRFCEmails.ActiveRow.IsDataRow Then
            If gridRFCEmails.ActiveRow.DataChanged Then
                If ValidarCamposVacios_RFCEmail() = False Then
                    Agregar_Editar_RFC_Correo()
                End If
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

#End Region


End Class
