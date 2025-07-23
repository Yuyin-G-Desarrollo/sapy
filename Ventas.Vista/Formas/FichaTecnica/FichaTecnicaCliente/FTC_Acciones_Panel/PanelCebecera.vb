Imports Tools.Controles

Partial Public Class FichaTecnicaClienteForm


    'btnVincularIDSICYCliente

    Private Sub btnVincularIDSICYCliente_Click(sender As Object, e As EventArgs) Handles btnVincularIDSICYCliente.Click
        Dim listado As New ListadoParametroForm
        listado.tipo_busqueda = 2
        'Dim listaParametroID As New List(Of String)
        'listado.listaParametroID = Nothing
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If Not String.IsNullOrEmpty(listado.id_parametros) Then
            txtClienteSICYID.Text = listado.id_parametros
        End If
        'If listado.listParametros.Rows.Count = 0 Then Return
        'gridClientes.DataSource = listado.listParametros
        'With gridClientes
        '    .DisplayLayout.Bands(0).Columns(0).Hidden = True
        '    .DisplayLayout.Bands(0).Columns(1).Hidden = True
        '    .DisplayLayout.Bands(0).Columns(2).Hidden = True

        '    .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Clientes"
        'End With

    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click

        If clienteID_Busqueda > 0 Then
            recuperar_datos_Panel_Cliente(CInt(clienteID_Busqueda))
            If rbtnClienteStatusInactivo.Checked Then
                btnEditarCliente.Enabled = False
            End If
            Exit Sub
        End If

        If cboxClienteCliente.SelectedIndex > 0 Then
            lblClienteSAYID_Int.Text = CStr(cboxClienteCliente.SelectedValue)
            recuperar_datos_Panel_Cliente(CInt(lblClienteSAYID_Int.Text))
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "ALTACLIENTE") Then
                If CInt(lblClientePersonaID_Int.Text) = 0 Then
                    btnAgregarCliente.Enabled = True
                Else
                    btnAgregarCliente.Enabled = False
                End If
            Else
                btnAgregarCliente.Enabled = False
            End If

        Else
            lblClientePersonaID_Int.Text = "0"
            lblClienteSAYID_Int.Text = "0"
            lblClienteFechaAlta_Date.Text = "-"
            lblClienteLogoNombre.Text = "-"
            lblClienteLogoRuta.Text = "-"
            limpiarControles(pnlFormCliente)
            asignaStatusControles(pnlFormCliente, False)
            btnBuscarCliente.Enabled = True

            cboxClienteCliente.Enabled = True
            'cboxClienteCliente.DropDownStyle = ComboBoxStyle.DropDown

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "ALTACLIENTE") Then
                If CInt(lblClientePersonaID_Int.Text) = 0 Then
                    btnAgregarCliente.Enabled = True
                Else
                    btnAgregarCliente.Enabled = False
                End If
            Else
                btnAgregarCliente.Enabled = False
            End If


            If rbtnClienteStatusInactivo.Checked Then
                btnEditarCliente.Enabled = False
            Else
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
            End If


        End If

    End Sub

    Private Sub btnAgregarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarCliente.Click

        limpiarControles(pnlFormCliente)
        asignaStatusControles(pnlFormCliente, True)

        lblClientePersonaID_Int.Text = "0"
        lblClienteSAYID_Int.Text = "0"
        'cboxClienteCliente.DropDownStyle = ComboBoxStyle.DropDown
        rbtnClienteStatusActivo.Checked = True

        ListaVendedor()
        ListaAtnCliente()
        ListaClasificacionCliente()
        ListaRutas(cboxClienteRuta)
        ListaListaDePecios(cboxListaDePreciosEncabezado, 0, False, False)

        cboxListaDePreciosEncabezado.Enabled = False
        btnBuscarCliente.Enabled = False
        btnAgregarCliente.Enabled = False
        txtClienteRanking.Enabled = False
        pnlClienteStatus.Enabled = False
        'pnlClienteTipoPersona.TabStop = True
        'rbtnClientePersonaFisica.TabStop = True
        'rbtnClientePersonaMoral.TabStop = True
        cboxClienteCliente.DropDownStyle = ComboBoxStyle.Simple


    End Sub

    Private Sub btnGuardarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarCliente.Click

        Try
            If Not guardar_Cliente_Cliente() Then
                Exit Sub
            End If
        Catch ex As Exception
            show_message("Error", "Algo surgio mal durante la operación")
            Exit Sub
        End Try

        recuperar_datos_Panel_Cliente(CInt(cboxClienteCliente.SelectedValue))
        CambiarElForeColorControles_Negro(pnlFormCliente)
        CambiarElForeColorControles_DodgerBlue(pnlClienteBotones)
    End Sub


    Private Sub btnEditarCliente_Click(sender As Object, e As EventArgs) Handles btnEditarCliente.Click

        asignaStatusControles(pnlFormCliente, True)
        'cboxClienteCliente.DropDownStyle = ComboBoxStyle.DropDown
        txtClienteRanking.Enabled = False

        If cboxClienteClasificacion.SelectedIndex < 1 Then
            cboxClienteClasificacion.Enabled = True
        Else
            cboxClienteClasificacion.Enabled = False
        End If

        cboxClienteEstatus.Enabled = False
        pnlClienteStatus.Enabled = False
        cboxClienteCliente.DropDownStyle = ComboBoxStyle.Simple

        'pnlClienteTipoPersona.Enabled = False

        If cboxClienteEstatus.Text = "PROSPECTO" Then
            'If lblClienteValidacionDesc.Text = "Validado" Then
            '    cboxClienteEstatus.Enabled = True
            'End If
            cboxClienteEstatus.Enabled = True
        End If

        btnAgregarCliente.Enabled = False
        btnBuscarCliente.Enabled = False
        'btnGuardarCliente.Enabled = False
        'cboxClienteVendedor.Enabled = False
        cboxClienteAtnClientes.Enabled = False

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
            'cboxClienteVendedor.Enabled = True
            cboxClienteAtnClientes.Enabled = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITAR_CLASIFICACION") Then
            cboxClienteClasificacion.Enabled = True
        End If

        cboxListaDePreciosEncabezado.Enabled = False

    End Sub

    Private Sub btnCancelarClienter_Click(sender As Object, e As EventArgs) Handles btnCancelarCliente.Click
        If Mensajes_Y_Alertas("CONFIRMACION", "Los cambios realizados no se han guardado ¿Desea cancelar los cambios?") Then
            recuperar_datos_Panel_Cliente(CInt(lblClienteSAYID_Int.Text))

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "ALTACLIENTE") Then
                If CInt(lblClientePersonaID_Int.Text) = 0 Then
                    btnAgregarCliente.Enabled = True
                Else
                    btnAgregarCliente.Enabled = False
                End If
            Else
                btnAgregarCliente.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnBuscarImagenCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarImagenCliente.Click

        Dim objBU As New Negocios.ClientesBU

        Dim ruta As String

        ofdFichaTecnica.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        'ofdFichaTecnica.Filter = "JPEG, PDF, DOC, DOCX, XLS, XLSX, PNG, GIF|*.pdf;*.jpg; *.doc; *.docx;*.xls; *.png;*.gif"
        ofdFichaTecnica.Filter = "JPEG|*.jpg"
        ofdFichaTecnica.FilterIndex = 3
        ofdFichaTecnica.ShowDialog()
        lblClienteLogoRuta.Text = ofdFichaTecnica.FileName
        ruta = ofdFichaTecnica.FileName


        Dim archivo() As String
        archivo = Split(ruta, "\")

        For n = 0 To UBound(archivo, 1)

            If UBound(archivo) = n Then
                Archivos.PNombreArchivo = archivo(n)

            End If

        Next

        If CInt(lblClienteSAYID_Int.Text) = 0 Then
            Dim num As Integer = objBU.buscarUltimoCliente_mas1()
            lblClienteLogoNombre.Text = num.ToString + ".jpg"
        Else
            lblClienteLogoNombre.Text = lblClienteSAYID_Int.Text + ".jpg"
        End If
        btnBuscarImagenCliente.Text = "OK"

        Try
            imgClienteLogo.Image = Image.FromFile(ruta)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub imgClienteLogo_DoubleClick(sender As Object, e As EventArgs) Handles imgClienteLogo.DoubleClick

        Dim galeriaForm As New GaleriaImagenesForm
        galeriaForm.RutaArchivo = "Ventas/FTC/Cliente_" + lblClienteSAYID_Int.Text + "/Logo/"
        galeriaForm.NombreArchivo = lblClienteSAYID_Int.Text + ".jpg"

        galeriaForm.Show()

    End Sub

    Public Function guardar_Cliente_Cliente() As Boolean

        Dim clienteBU As New Negocios.ClientesBU
        Dim cliente As New Entidades.Cliente
        Dim ruta As New Entidades.Ruta
        Dim atnClientes As New Entidades.Colaborador
        Dim persona As New Entidades.Persona
        Dim tipoPersona As New Entidades.TipoPersona
        Dim clasificacionPersonas As New Entidades.ClasificacionPersona


        cliente.clienteid = CInt(lblClienteSAYID_Int.Text)
        persona.personaid = CInt(lblClientePersonaID_Int.Text)

        '   CLASIFICACION PERSONA DE CLIENTE - OBLIGATORIO PARA AMBOS
        If cboxClienteEstatus.SelectedIndex > -1 Then

            If cboxClienteEstatus.Text.ToUpperInvariant.Equals("PROSPECTO") Then
                cliente.statuscliente = "P"
                clasificacionPersonas.clasificacionpersonaid = 3
                cliente_CP = clasificacionPersonas.clasificacionpersonaid
                cliente.clasificacionpersona = clasificacionPersonas
                '   IDSICY - SOLO OBLIGATORIO PARA CLIENTE
                If String.IsNullOrWhiteSpace(txtClienteSICYID.Text) Then
                    cliente.idsicy = 0
                Else
                    cliente.idsicy = CInt(txtClienteSICYID.Text)
                End If
            ElseIf cboxClienteEstatus.Text.ToUpperInvariant.Equals("CLIENTE") Then
                cliente.statuscliente = "C"
                clasificacionPersonas.clasificacionpersonaid = 1
                cliente_CP = clasificacionPersonas.clasificacionpersonaid
                tipoPersona.clasificacionpersona = clasificacionPersonas
                cliente.clasificacionpersona = clasificacionPersonas
                '   IDSICY - SOLO OBLIGATORIO PARA CLIENTE
                If String.IsNullOrWhiteSpace(txtClienteSICYID.Text) Then
                    show_message("Advertencia", "Falta información")
                    lblClienteSICYID.ForeColor = Color.Red
                    Return False
                Else
                    cliente.idsicy = CInt(txtClienteSICYID.Text)
                    lblClienteSICYID.ForeColor = Color.Black
                End If
            End If
            lblClienteEstatus.ForeColor = Color.Black
        Else
            show_message("Advertencia", "Falta información")
            lblClienteEstatus.ForeColor = Color.Red
            Return False
        End If

        '   CEDIS - OBLIGATORIO?
        If IsDBNull(cboxNaveAlmacen.SelectedValue) Then
            show_message("Advertencia", "Falta información")
            lblNaveAlmacen.ForeColor = Color.Red
            Return False
        Else
            If CInt(cboxNaveAlmacen.SelectedValue) = 0 Then
                show_message("Advertencia", "Falta información")
                lblNaveAlmacen.ForeColor = Color.Red
                Return False
            Else
                cliente.ComercializadoraId = CInt(cboxNaveAlmacen.SelectedValue)
                lblNaveAlmacen.ForeColor = Color.Black
            End If
        End If

        '   NOMBRE COMERCIAL - OBLIGATORIO
        If String.IsNullOrWhiteSpace(cboxClienteCliente.Text) Then
            show_message("Advertencia", "Falta información")
            lblClienteCliente.ForeColor = Color.Red
            Return False
        Else
            cliente.nombregenerico = CStr(cboxClienteCliente.Text)
            lblClienteCliente.ForeColor = Color.Black
        End If

        '   RAZON SOCIAL - OBLIGATORIO
        If String.IsNullOrWhiteSpace(txtClienteRazonSocial.Text) Then
            show_message("Advertencia", "Falta información")
            lblClienteRazonSocial.ForeColor = Color.Red
            Return False
        Else
            cliente.razonsocial = txtClienteRazonSocial.Text
            lblClienteRazonSocial.ForeColor = Color.Black
        End If

        '   CLASIFICACION DE CLIENTE
        If IsDBNull(cboxClienteClasificacion.SelectedValue) Then
            If cliente_CP = 1 Then
                show_message("Advertencia", "Falta información")
                lblClienteClasificacion.ForeColor = Color.Red
                Return False
            ElseIf cliente_CP = 3 Then
                cliente.clasificacioncliente = String.Empty
                lblClienteClasificacion.ForeColor = Color.Black
            End If
        Else
            If cboxClienteClasificacion.SelectedIndex < 1 Then
                If cliente_CP = 1 Then
                    show_message("Advertencia", "Falta información")
                    lblClienteClasificacion.ForeColor = Color.Red
                    Return False
                ElseIf cliente_CP = 3 Then
                    cliente.clasificacioncliente = String.Empty
                    lblClienteClasificacion.ForeColor = Color.Black
                End If
            Else
                cliente.clasificacioncliente = CStr(cboxClienteClasificacion.SelectedValue)
                lblClienteClasificacion.ForeColor = Color.Black
            End If
        End If

        '   RANKING - OBLIGATORIO PARA CLIENTE - SE ASIGNA AUTOMATICAMENTE PARA AMBOS (PROSPECTO Y CLIENTE)
        If String.IsNullOrWhiteSpace(txtClienteRanking.Text) Then
            If cliente_CP = 1 Then
                show_message("Advertencia", "Falta información")
                lblClienteRanking.ForeColor = Color.Red
                Return False
            Else
                cliente.ranking = 0
                lblClienteRanking.ForeColor = Color.Black
            End If
        Else
            cliente.ranking = CInt(txtClienteRanking.Text)
            lblClienteRanking.ForeColor = Color.Black
        End If

        'RUTA -OBLIGATORIO
        If IsDBNull(cboxClienteRuta.SelectedValue) Then
            show_message("Advertencia", "Falta información")
            lblClienteRuta.ForeColor = Color.Red
            Return False
        Else
            If CInt(cboxClienteRuta.SelectedValue) = 0 Then
                show_message("Advertencia", "Falta información")
                lblClienteRuta.ForeColor = Color.Red
                Return False
            Else
                ruta.rutaid = CInt(cboxClienteRuta.SelectedValue)
                cliente.ruta = ruta
                lblClienteRuta.ForeColor = Color.Black
            End If
        End If


        '   ATENCION A CLIENTES - OBLIGATORIO PARA CLIENTE
        If IsDBNull(cboxClienteAtnClientes.SelectedValue) Then
            If cliente_CP = 1 Then
                show_message("Advertencia", "Falta información")
                lblClienteAtnClientes.ForeColor = Color.Red
                Return False
            Else
                atnClientes.PColaboradorid = 0
                cliente.colaborador_atnc = atnClientes
                lblClienteAtnClientes.ForeColor = Color.Black
            End If
        Else
            If CInt(cboxClienteAtnClientes.SelectedValue) = 0 Then
                If cliente_CP = 1 Then
                    show_message("Advertencia", "Falta información")
                    lblClienteAtnClientes.ForeColor = Color.Red
                    Return False
                Else
                    atnClientes.PColaboradorid = CInt(cboxClienteAtnClientes.SelectedValue)
                    cliente.colaborador_atnc = atnClientes
                    lblClienteAtnClientes.ForeColor = Color.Black
                End If
            Else
                atnClientes.PColaboradorid = CInt(cboxClienteAtnClientes.SelectedValue)
                cliente.colaborador_atnc = atnClientes
                lblClienteAtnClientes.ForeColor = Color.Black
            End If


        End If


        '   TIPO PERSONA CLIENTE - OBLIGATORIO
        If rbtnClientePersonaFisica.Checked Then
            persona.personafisica = True
            lblClienteTipoPersona.ForeColor = Color.Black
        ElseIf rbtnClientePersonaMoral.Checked Then
            persona.personafisica = False
            lblClienteTipoPersona.ForeColor = Color.Black
        Else
            show_message("Advertencia", "Falta información")
            lblClienteTipoPersona.ForeColor = Color.Red
            Return False
        End If

        cliente.personacliente = persona

        'meter valor del checkbox en la variable as
        If chkClientePreferente.Checked Then
            cliente.clientepreferente = True
        Else
            cliente.clientepreferente = False
        End If


        If cliente.clienteid = 0 Then
            Try
                clienteBU.AltaCliente(cliente, cboxListaDePreciosEncabezado.SelectedValue)

            Catch ex As Exception
                show_message("Error", "Algo falló en la operación")
                Return False
            End Try
        Else
            Try
                clienteBU.editarCliente(cliente, tipoPersona, 4, True, True)

            Catch ex As Exception
                show_message("Error", "Algo falló en la operación")
                Return False
            End Try
        End If

        Dim objFTP As New Tools.TransferenciaFTP

        If btnBuscarImagenCliente.Text = "OK" Then
            If CInt(lblClienteSAYID_Int.Text) = 0 Then
                Dim num As Integer = clienteBU.buscarUltimoCliente()
                'objFTP.EnviarArchivo(CarpetaDestino, row.Cells(1).Value.ToString + "_" + etiqueta.etiquetaclienteid.ToString + ".jpg")
                Dim RutaArchivo As String = "Ventas/FTC/Cliente_" + num.ToString + "/Logo"
                objFTP.EnviarArchivo(RutaArchivo, lblClienteLogoRuta.Text)
                objFTP.RenombraArchivo(RutaArchivo, Archivos.PNombreArchivo, lblClienteLogoNombre.Text)
            Else
                Dim RutaArchivo As String = "Ventas/FTC/Cliente_" + lblClienteSAYID_Int.Text + "/Logo"
                Try
                    objFTP.BorraArchivo(RutaArchivo, lblClienteLogoNombre.Text)
                Catch ex As Exception

                End Try
                objFTP.EnviarArchivo(RutaArchivo, lblClienteLogoRuta.Text)
                objFTP.RenombraArchivo(RutaArchivo, Archivos.PNombreArchivo, lblClienteLogoNombre.Text)
            End If
        End If

        Dim clienteNombre As String = cboxClienteCliente.Text

        ListaClientes()

        cboxClienteCliente.Text = clienteNombre

        show_message("Exito", "Guardado con éxito")




        Return True

    End Function


    Private Sub recuperar_datos_Panel_Cliente(clienteID As Integer)

        limpiarControles(pnlFormCliente)
        lblClienteSAYID_Int.Text = "0"
        lblClientePersonaID_Int.Text = "0"
        lblClienteLogoNombre.Text = "-"
        lblClienteLogoRuta.Text = "-"
        btnBuscarImagenCliente.Text = "..."
        imgClienteLogo.Image = Nothing
        asignaStatusControles(pnlFormCliente, False)
        btnEditarCliente.Enabled = False

        btnBuscarCliente.Enabled = True
        btnAgregarCliente.Enabled = True
        'cboxClienteCliente.DropDownStyle = ComboBoxStyle.DropDown

        If clienteID > 0 Then

            Dim ClientesBU As New Ventas.Negocios.ClientesBU
            Dim Cliente As New DataTable

            Cliente = ClientesBU.Datos_TablaCliente(clienteID)

            If Cliente.Rows.Count > 0 Then

                ListaClientes()
                cboxClienteCliente.SelectedValue = clienteID

                ListaListaDePecios(cboxListaDePreciosEncabezado, clienteID, False, False)
                cboxListaDePreciosEncabezado.Enabled = True

                lista_RecuperadA = Split(cboxListaDePreciosEncabezado.Text, "|")

                If IsDBNull(Cliente.Rows(0).Item("clie_clienteid")) Then
                    lblClienteSAYID_Int.Text = "0"
                Else
                    lblClienteSAYID_Int.Text = CStr(Cliente.Rows(0).Item("clie_clienteid"))
                End If

                If Cliente.Rows(0).Item("clie_preferente") = 0 Then
                    chkClientePreferente.Checked = False
                Else
                    chkClientePreferente.Checked = True
                End If

                If IsDBNull(Cliente.Rows(0).Item("clie_idsicy")) Then
                    txtClienteSICYID.Text = String.Empty
                Else
                    txtClienteSICYID.Text = CStr(Cliente.Rows(0).Item("clie_idsicy"))
                End If

                If IsDBNull(Cliente.Rows(0).Item("clie_personaidcliente")) Then
                    lblClientePersonaID_Int.Text = "0"
                Else
                    lblClientePersonaID_Int.Text = CStr(Cliente.Rows(0).Item("clie_personaidcliente"))
                End If

                If IsDBNull(Cliente.Rows(0).Item("clie_razonsocial")) Then
                    txtClienteRazonSocial.Text = String.Empty
                Else
                    txtClienteRazonSocial.Text = CStr(Cliente.Rows(0).Item("clie_razonsocial"))
                End If

                If IsDBNull(Cliente.Rows(0).Item("clie_comercializadoraid")) Then
                    cboxNaveAlmacen.SelectedIndex = -1
                Else
                    If CInt(Cliente.Rows(0).Item("clie_comercializadoraid")) = 43 Then
                        cboxNaveAlmacen.SelectedValue = Cliente.Rows(0).Item("clie_comercializadoraid")
                    Else
                        cboxNaveAlmacen.SelectedValue = Cliente.Rows(0).Item("clie_comercializadoraid")
                    End If
                End If

                If IsDBNull(Cliente.Rows(0).Item("clie_clasificacionpersonaid")) Then
                    cboxClienteEstatus.SelectedIndex = -1
                Else
                    If CInt(Cliente.Rows(0).Item("clie_clasificacionpersonaid")) = 1 Then
                        cboxClienteEstatus.SelectedIndex = 0
                        cliente_CP = 1
                        rbtnClienteStatusActivo.Checked = True
                        rbtnClienteStatusInactivo.Checked = False
                        btnClienteModificarStatus.Image = Global.Ventas.Vista.My.Resources.Resources.apagar_32
                    ElseIf CInt(Cliente.Rows(0).Item("clie_clasificacionpersonaid")) = 2 Then
                        cboxClienteEstatus.SelectedIndex = 0
                        cliente_CP = 1
                        rbtnClienteStatusActivo.Checked = False
                        rbtnClienteStatusInactivo.Checked = True
                        btnClienteModificarStatus.Image = Global.Ventas.Vista.My.Resources.Resources.encender_32
                    ElseIf CInt(Cliente.Rows(0).Item("clie_clasificacionpersonaid")) = 3 Then
                        cboxClienteEstatus.SelectedIndex = 1
                        cliente_CP = 3
                        rbtnClienteStatusActivo.Checked = True
                        rbtnClienteStatusInactivo.Checked = False
                        btnClienteModificarStatus.Image = Global.Ventas.Vista.My.Resources.Resources.apagar_32
                    ElseIf CInt(Cliente.Rows(0).Item("clie_clasificacionpersonaid")) = 4 Then
                        cboxClienteEstatus.SelectedIndex = 0
                        cliente_CP = 3
                        rbtnClienteStatusActivo.Checked = False
                        rbtnClienteStatusInactivo.Checked = True
                        btnClienteModificarStatus.Image = Global.Ventas.Vista.My.Resources.Resources.encender_32
                    End If
                End If

                If IsDBNull(Cliente.Rows(0).Item("clas_descripcion")) Then
                    txtDescripcionClasificacion.Text = String.Empty
                Else
                    If Cliente.Rows(0).Item("clie_clienteid") = 763 Then
                        txtDescripcionClasificacion.Text = "COPPEL"
                    ElseIf Cliente.Rows(0).Item("clie_clienteid") = 816 Then
                        txtDescripcionClasificacion.Text = "ANDREA"
                    Else
                        txtDescripcionClasificacion.Text = CStr(Cliente.Rows(0).Item("clas_descripcion"))
                    End If
                End If

                If IsDBNull(Cliente.Rows(0).Item("clie_ranking")) Then
                    txtClienteRanking.Text = String.Empty
                Else
                    txtClienteRanking.Text = CStr(Cliente.Rows(0).Item("clie_ranking"))
                End If

                lblClienteFechaAlta_Date.Text = CDate(Cliente.Rows(0).Item("clie_fechacreacion")).ToShortDateString + " " + _
                                   CDate(Cliente.Rows(0).Item("clie_fechacreacion")).ToLongTimeString

                ListaRutas(cboxClienteRuta)
                If IsDBNull(Cliente.Rows(0).Item("clie_rutaid")) Then
                    cboxClienteRuta.SelectedValue = 0
                Else
                    cboxClienteRuta.SelectedValue = CInt(Cliente.Rows(0).Item("clie_rutaid"))
                End If

                ListaAtnCliente()
                If IsDBNull(Cliente.Rows(0).Item("clie_colaboradorid_atnc")) Then
                    cboxClienteAtnClientes.SelectedValue = 0
                Else
                    cboxClienteAtnClientes.SelectedValue = CInt(Cliente.Rows(0).Item("clie_colaboradorid_atnc"))
                End If



                ListaClasificacionCliente()
                If IsDBNull(Cliente.Rows(0).Item("clie_clasificacionclienteid")) Then
                    cboxClienteClasificacion.SelectedValue = 0
                Else
                    cboxClienteClasificacion.SelectedValue = CStr(Cliente.Rows(0).Item("clie_clasificacionclienteid"))
                End If

            End If

            Dim PersonasBU As New Framework.Negocios.PersonasBU
            Dim persona As New DataTable

            persona = PersonasBU.Datos_TablaPersona(CInt(lblClientePersonaID_Int.Text))

            If persona.Rows.Count > 0 Then

                If CBool(persona.Rows(0).Item("pers_personafisica")) Then
                    rbtnClientePersonaFisica.Checked = True
                    rbtnClientePersonaMoral.Checked = False
                Else
                    rbtnClientePersonaFisica.Checked = False
                    rbtnClientePersonaMoral.Checked = True
                End If

            End If



            Dim validacionBU As New Framework.Negocios.ValidacionBU
            Dim usuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            Dim TipoValidacion As String = ""
            Dim validacionVentas As String = ""
            Dim validacionCobranza As String = ""

            If validacionBU.Cliente_Info_Obligatoria_Completa(CInt(lblClientePersonaID_Int.Text)) Then
                If validacionBU.Usuario_Validacion(usuarioID, 1) Then
                    Dim tabla As New DataTable
                    tabla = validacionBU.Validacion_InformacionCliente(clienteID)
                    If tabla.Rows.Count > 0 Then
                        If CInt(tabla.Rows(0).Item("vali_validaciontipoid")) = 1 Then
                            TipoValidacion = "Ventas "
                            validacionVentas = (tabla.Rows(0).Item("vaes_nombre"))
                        Else
                            TipoValidacion = "Cobranza "
                            validacionCobranza = (tabla.Rows(0).Item("vaes_nombre"))
                        End If
                        lblClienteValidacionDesc.Text = TipoValidacion & tabla.Rows(0).Item("vaes_nombre")
                        If validacionCobranza <> "" And CInt(tabla.Rows(0).Item("vaes_validacionestatusid")) = 1 Then ' AMBAS VALIDACIONES AUTORIZADAS
                            lblClienteValidacionDesc.Text = "AUTORIZADA"
                            lblClienteValidacionDesc.ForeColor = Color.Green
                        ElseIf CInt(tabla.Rows(0).Item("vaes_validacionestatusid")) = 2 Then ' CUALQUIER VALIDACIÓN RECHAZADA
                            lblClienteValidacionDesc.ForeColor = Color.Red
                        Else
                            lblClienteValidacionDesc.ForeColor = Color.Orange
                        End If
                    Else
                        lblClienteValidacionDesc.Text = "Listo para validar"
                        lblClienteValidacionDesc.ForeColor = Color.BlueViolet
                    End If
                Else
                    lblClienteValidacionDesc.Text = "Listo para validar"
                    lblClienteValidacionDesc.ForeColor = Color.BlueViolet
                End If

            Else
                lblClienteValidacionDesc.Text = "Información incompleta"
                lblClienteValidacionDesc.ForeColor = Color.Red
            End If



            ''VALIDACION FICHATECNICAETIQUETADO
            Consultar_Nombre_EtiquetaEspecial()
            ValidarEtiqeutaEspecialAgregada()
            If Etiquetas_Especiales = False Then
                lblAdvertencia_2.Text = "Falta FT de etiquetado"
                lblAdvertencia_2.ForeColor = Color.Red
            Else
                lblAdvertencia_2.Text = ""
            End If

            Dim objFTP As New Tools.TransferenciaFTP
            Try
                Dim Stream As System.IO.Stream
                Dim RutaArchivo As String = "Ventas/FTC/Cliente_" + lblClienteSAYID_Int.Text + "/Logo/"
                lblClienteLogoRuta.Text = RutaArchivo
                lblClienteLogoNombre.Text = lblClienteSAYID_Int.Text + ".jpg"
                Stream = objFTP.StreamFile(RutaArchivo, lblClienteLogoNombre.Text)
                imgClienteLogo.Image = Image.FromStream(Stream)
            Catch ex As Exception
                lblClienteLogoRuta.Text = "-"
                lblClienteLogoNombre.Text = "-"
            End Try

        End If

        If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCABECERAATN") Then
                If clienteID = 0 Then
                    btnEditarCliente.Enabled = False
                Else
                    btnEditarCliente.Enabled = True
                End If
            Else
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
                    If clienteID = 0 Then
                        btnEditarCliente.Enabled = False
                    Else
                        btnEditarCliente.Enabled = True
                    End If
                Else
                    btnEditarCliente.Enabled = False
                End If
            End If
        Else
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
                If clienteID = 0 Then
                    btnEditarCliente.Enabled = False
                Else
                    btnEditarCliente.Enabled = True
                End If
            Else
                btnEditarCliente.Enabled = False
            End If
        End If
    End Sub

End Class
