Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class AltaPersona
    Dim Contactos2, Proveedor2 As TabPage
    Dim IDPersona As Int32
    Dim ClasificacionPersona, TipoPersona As Int32
    Dim Inserto, CamposVacios, CamposEscritos As Boolean
    Dim FechaInicio As Date
    Dim FechaFin As Date
    Dim IDProveedor As Int32
    Dim IdConvenio As Int32
    Dim IdPersonaConvenioa As Int32
    Dim IdEmpresa As Int32
    Dim idEmail As Int32
    Dim indiceEmail As Int32 = -1
    Dim indiceTelefono As Int32 = -1
    Dim indiceDomicilios As Int32 = -1




    Public Property ptipopersona As Int32
        Get
            Return TipoPersona
        End Get
        Set(value As Int32)
            TipoPersona = value
        End Set
    End Property

    Public Property PClasificacionPersona As Int32
        Get
            Return ClasificacionPersona
        End Get
        Set(value As Int32)
            ClasificacionPersona = value
        End Set
    End Property

    Public Property PIDPersona As Int32
        Get
            Return IDPersona
        End Get
        Set(value As Int32)
            IDPersona = value
        End Set
    End Property

    Private Sub AltaPersona_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbTipo = Tools.Controles.ComboClasePersonaCMB(cmbTipo)
        cmbPais = Tools.Controles.ComboPaises(cmbPais)
        cmbTipoFleteMensajeria = Tools.Controles.ComboTipoFlete(cmbTipoFleteMensajeria)
        cmbRazonSocial = COmboEmpresas(cmbRazonSocial)
        If IDPersona > 0 Then
            Try
                cmbTipo.SelectedValue = TipoPersona
                cmbClasificacion.SelectedValue = ClasificacionPersona
                cmbTipo.Enabled = False
                cmbClasificacion.Enabled = False
                poblar_gridDatosContacto(CInt(IDPersona), gridDatosContacto)
                asignar_grid_gridDatosContacto(gridDatosContacto)
                CargarDatosPersona(IDPersona)
                CargarDomicilios(IDPersona)
                CargarDatosProveedor(IDPersona)
                CargarTelefonos(IDPersona)
                CargarEmails(IDPersona)
                Dim objbuProveedor As New Negocios.ProveedorBU
                IDProveedor = objbuProveedor.GetIDProveedorRecienIngresado(IDPersona)
                CargarTipoFleteMensajerias(IDProveedor)
            Catch ex As Exception
            End Try
        Else
            poblar_gridDatosContacto(CInt(IDPersona), gridDatosContacto)
            asignar_grid_gridDatosContacto(gridDatosContacto)
            btnAgregarConvenio.Enabled = False
        End If


        Try
            cmbTipoTelefono = Tools.Controles.ComboTipoTelefonos(cmbTipoTelefono)
        Catch ex As Exception

        End Try

        LlenarTablaConvenios()
        btnActualizar.Enabled = False
    End Sub



    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged
        Try
            cmbClasificacion = Tools.Controles.ComboClasificacionPersona(cmbClasificacion, CInt(cmbTipo.SelectedValue))

            If cmbTipo.Text.Contains("CONTACTO") Or cmbTipo.Text.Contains("PROVEEDOR") Then


                If cmbTipo.Text.Contains("CONTACTO") Then
                    'pnlPrivacidadContactos.Visible = False
                    '  pnlPrivacidadProveedores.Dock = DockStyle.Fill
                    'pnlPrivacidadProveedores.Visible = True

                Else
                    ' pnlPrivacidadProveedores.Visible = False
                    ' pnlPrivacidadContactos.Visible = True
                    ' pnlPrivacidadContactos.Dock = DockStyle.Fill


                End If



                If cmbTipo.Text.Contains("PROVEEDOR") Then
                    '    pnlPrivacidadProveedores.Visible = False
                    '  pnlPrivacidadContactos.Visible = True
                    ' pnlPrivacidadContactos.Dock = DockStyle.Fill
                Else
                    '  pnlPrivacidadContactos.Visible = False
                    '   pnlPrivacidadProveedores.Dock = DockStyle.Fill
                    '  pnlPrivacidadProveedores.Visible = True
                End If

            Else


            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Sub gbxDatosGenerales_Enter(sender As Object, e As EventArgs) Handles gbxDatosGenerales.Enter

    End Sub
    Private Sub btnAñadirDomicilio_Click(sender As Object, e As EventArgs) Handles btnAñadirDomicilio.Click
        Dim valida As Boolean = True

        If txtCalle.Text.Length >= 0 Then
            If txtCalle.Text.Length <= 0 Then
                valida = False
                lblCalle.ForeColor = Color.Red
            Else
                If valida = False Then
                    valida = False
                Else
                    lblCalle.ForeColor = Color.Black
                    valida = True
                End If
            End If
            If txtNoExterior.Text.Length <= 0 Then
                valida = False
                lblNoExterior.ForeColor = Color.Red
            Else
                lblNoExterior.ForeColor = Color.Black
                valida = True
            End If
            If txtColonia.Text.Length <= 0 Then
                valida = False
                lblColonia.ForeColor = Color.Red
            Else
                If valida = False Then
                    valida = False
                Else
                    lblColonia.ForeColor = Color.Black
                    valida = True
                End If
            End If
            If cmbCiudad.SelectedIndex <= 0 Then
                valida = False
                lblCiudad.ForeColor = Color.Red
            Else
                If valida = False Then
                    valida = False
                Else
                    lblCiudad.ForeColor = Color.Black
                    valida = True
                End If
            End If
        End If
        If valida = True Then
            If indiceDomicilios < 0 Then
                grdDomicilios.Rows.Add(txtCalle.Text, txtNoInterior.Text, txtNoExterior.Text, txtColonia.Text, txtCP.Text, _
   cmbPais.Text, cmbEstado.Text, cmbCiudad.Text, cmbPoblacion.Text, True, 0, cmbPais.SelectedValue, cmbEstado.SelectedValue, _
   cmbCiudad.SelectedValue, cmbPoblacion.SelectedValue)
                txtCalle.Text = ""
                txtNoInterior.Text = ""
                txtNoExterior.Text = ""
                txtColonia.Text = ""
                txtCP.Text = ""
                Try
                    cmbPais.SelectedIndex = 0
                Catch ex As Exception

                End Try

                Try
                    cmbEstado.SelectedIndex = 0
                Catch ex As Exception

                End Try

                Try
                    cmbCiudad.SelectedIndex = 0
                Catch ex As Exception

                End Try
                Try
                    cmbPoblacion.SelectedIndex = 0
                Catch ex As Exception

                End Try
            Else
                grdDomicilios.Rows(indiceDomicilios).Cells("ColCalle").Value = txtCalle.Text
                grdDomicilios.Rows(indiceDomicilios).Cells("ColNoInterior").Value = txtNoInterior.Text
                grdDomicilios.Rows(indiceDomicilios).Cells("ColNoExterior").Value = txtNoExterior.Text
                grdDomicilios.Rows(indiceDomicilios).Cells("ColColonia").Value = txtColonia.Text
                grdDomicilios.Rows(indiceDomicilios).Cells("ColCP").Value = txtCP.Text
                grdDomicilios.Rows(indiceDomicilios).Cells("PaisID").Value = cmbPais.SelectedValue
                grdDomicilios.Rows(indiceDomicilios).Cells("EstadoID").Value = cmbEstado.SelectedValue
                grdDomicilios.Rows(indiceDomicilios).Cells("CiudadID").Value = cmbCiudad.SelectedValue
                grdDomicilios.Rows(indiceDomicilios).Cells("PoblacionID").Value = cmbPoblacion.SelectedValue
                grdDomicilios.Rows(indiceDomicilios).Cells("ColActivo").Value = rdoSiActivoDomicilio.Checked
                txtCalle.Text = ""
                txtNoInterior.Text = ""
                txtNoExterior.Text = ""
                txtColonia.Text = ""
                txtCP.Text = ""
                Try
                    cmbPais.SelectedIndex = 0
                Catch ex As Exception

                End Try

                Try
                    cmbEstado.SelectedIndex = 0
                Catch ex As Exception

                End Try

                Try
                    cmbCiudad.SelectedIndex = 0
                Catch ex As Exception

                End Try
                Try
                    cmbPoblacion.SelectedIndex = 0
                Catch ex As Exception

                End Try
                indiceDomicilios = -1
            End If
            End If
           


    End Sub
    Private Sub cmbPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPais.SelectedIndexChanged
        Try
            cmbEstado = Tools.Controles.ComboEstados(cmbEstado, CInt(cmbPais.SelectedValue))
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedIndexChanged
        Try
            cmbCiudad = Tools.Controles.ComboCiudades(cmbCiudad, CInt(cmbEstado.SelectedValue))
        Catch ex As Exception

        End Try

    End Sub
    Private Sub cmbCiudad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCiudad.SelectedIndexChanged
        Try
            cmbPoblacion = Tools.Controles.ComboPoblaciones(cmbPoblacion, CInt(cmbCiudad.SelectedValue))
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnGuardarTodo_Click(sender As Object, e As EventArgs) Handles btnGuardarTodo.Click
        Dim IDPersonaRecienInsetado As Int32
        Dim ClasificacionPersonaID As New Int32
        Cursor = Cursors.WaitCursor

        'actualizamos los datos de los convenios en caso de no haberlo hecho
        If btnActualizar.Enabled = True Then
            VerificarCamposVacios()
            ActualizarConvenios()
            limpiarCampos()
            LlenarTablaConvenios()
        Else
            VerificarCamposEscritos()
            If CamposEscritos = True Then
                VerificarCamposVacios()
            End If

            If ValidacionInformacionPersona() = True And ValidacionProveedores() = True And CamposVacios = False Then
                GuardarInformacionPersona()
                'Obtener id de la clasificacion de la persona
                ClasificacionPersonaID = CInt(cmbClasificacion.SelectedValue)

                'Obtener el id de la ultima persona registrada
                IDPersonaRecienInsetado = GetIDPersona()
                If IDPersona > 0 Then
                    IDPersonaRecienInsetado = IDPersona
                End If
                If ClasificacionPersona > 0 Then
                    ClasificacionPersonaID = ClasificacionPersona
                End If
                'Creo el tipo Persona
                If Inserto = True Then
                    CrearTipoPersona(IDPersonaRecienInsetado, ClasificacionPersonaID)
                End If


                'Guardamos Domicilios de la persona
                GuardarDomiciliosPersona(IDPersonaRecienInsetado, ClasificacionPersonaID)
                'Guardamos Contactos
                GuardarContactos(ClasificacionPersonaID, IDPersonaRecienInsetado)
                'Guardamos informacion del proveedor
                GuardarInformacionProveedor(IDPersonaRecienInsetado, ClasificacionPersonaID)
                'Guardamos Tipos Flete en caso de que sea tipo Mensajeria
                Dim IdProveedor As Int32
                Dim objbuProveedor As New Negocios.ProveedorBU
                IdProveedor = objbuProveedor.GetIDProveedorRecienIngresado(IDPersona)
                GuardarTipoFleteMensajerias(IdProveedor)
                'Guardamos telefonos
                GuardarTelefonos(IDPersonaRecienInsetado, ClasificacionPersonaID)
                'Guardamos Emails
                GuardarEmails(IDPersonaRecienInsetado, ClasificacionPersonaID)
                If CamposEscritos = True Then
                    AgregarConvenio(IdProveedor)
                End If

                Dim Exito As New ExitoForm
                Exito.mensaje = "Guardado Correctamente"
                Exito.ShowDialog()
                Me.Close()
            Else
                Dim Advertencia As New AdvertenciaForm
                Advertencia.mensaje = "Faltan Campos por completar"
                Advertencia.Show()
            End If
        End If


        Cursor = Cursors.Default
    End Sub
#Region "VALIDACIONES"
    Public Function ValidacionInformacionPersona() As Boolean
        Dim valida As Boolean = True
        If cmbTipo.SelectedIndex > 0 Then
            lblTipo.ForeColor = Color.Black
            If cmbClasificacion.SelectedIndex > 0 Then
                lblClasificacion.ForeColor = Color.Black
                valida = True
                If txtNombrePersona.Text.Length <= 0 Then
                    valida = False
                    lblNombrePersona.ForeColor = Color.Red
                Else
                    valida = True
                    lblNombrePersona.ForeColor = Color.Black
                End If
            Else
                lblClasificacion.ForeColor = Color.Red
                valida = False
                If txtNombrePersona.Text.Length <= 0 Then
                    lblNombrePersona.ForeColor = Color.Red
                End If
            End If
        Else
            lblTipo.ForeColor = Color.Red
            lblNombrePersona.ForeColor = Color.Red
            lblClasificacion.ForeColor = Color.Red
        End If
        Return valida

    End Function
    Public Function ValidacionProveedores() As Boolean
        Dim valida As New Boolean

        If txtNombreProveedor.Text.Length <= 0 Or lblRFCProveedor.Text.Length <= 0 Then
            valida = False
            If txtNombreProveedor.Text.Length <= 0 Then
                lblNombreProveedor.ForeColor = Color.Red
            Else
                lblNombreProveedor.ForeColor = Color.Black
            End If

            If txtRFCProveedor.Text.Length <= 0 Then
                lblRFCProveedor.ForeColor = Color.Red
            Else
                lblRFCProveedor.ForeColor = Color.Black
            End If
        Else
            valida = True

        End If
        Return valida
    End Function
    Private Shared Function EmailValido(strEmail As String) As Boolean
        ' Retorna verdadero si strEmail es un formato de E-mail valido.
        Return System.Text.RegularExpressions.Regex.IsMatch(strEmail, "^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" & "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$")
    End Function
#End Region
#Region "Guardar Informacion"
    '------GUARDAR LA INFORMACION GENERAL DE LA PERSONA
    Public Sub GuardarInformacionPersona()
        Dim EntidadPersona As New Entidades.Persona
        Dim OBJBU As New Negocios.PersonasBU

        EntidadPersona.nombre = txtNombrePersona.Text
        Try
            EntidadPersona.apaterno = txtAPaterno.Text
        Catch ex As Exception
            EntidadPersona.apaterno = Nothing
        End Try

        Try
            EntidadPersona.amaterno = txtAMaterno.Text
        Catch ex As Exception
            EntidadPersona.amaterno = Nothing
        End Try

        Try
            EntidadPersona.CURP = txtCurpPersona.Text
        Catch ex As Exception
            EntidadPersona.CURP = Nothing
        End Try
        Try
            EntidadPersona.SicyID = CInt(txtsicyID.Text)
        Catch ex As Exception
            EntidadPersona.SicyID = Nothing
        End Try

        Try
            EntidadPersona.razonsocial = txtRazonSocialPersona.Text
        Catch ex As Exception
            EntidadPersona.razonsocial = Nothing
        End Try

        Try
            EntidadPersona.paginaweb = txtPaginaWeb.Text
        Catch ex As Exception
            EntidadPersona.paginaweb = Nothing
        End Try

        EntidadPersona.fechanacimiento = dtpFechaNacimiento.Value
        If rdoSiPersonaFisica.Checked = True Then
            EntidadPersona.personafisica = True
        Else
            EntidadPersona.personafisica = False
        End If
        If rdoSiActivo.Checked = True Then
            EntidadPersona.activo = True
        Else
            EntidadPersona.activo = False
        End If
        If IDPersona > 0 Then
            EntidadPersona.personaid = IDPersona
            OBJBU.EditarPersonas(EntidadPersona)
        Else
            OBJBU.AltaPersonaGeneral(EntidadPersona)
            Inserto = True
        End If

    End Sub
    '------OBTENEMOS EL ID DE LA PERSONA RECIEN REGISTRADO
    Public Function GetIDPersona() As Int32
        Dim IDPersonaRecienInsetado As Int32
        Dim OBJBU As New Negocios.PersonasBU
        IDPersonaRecienInsetado = 0
        IDPersonaRecienInsetado = OBJBU.GetIDPersonaRecienIngresado()
        Return IDPersonaRecienInsetado
    End Function
    'OBTENEMOS EL ID DEL PROVEEDOR RECIEN INSERTADO
    Public Function GetIDProveedor() As Int32
        Dim IDProveedorRecienInsetado As Int32
        Dim OBJBU As New Negocios.ProveedorBU
        IDProveedorRecienInsetado = 0
        IDProveedorRecienInsetado = OBJBU.GetIDProveedorRecienIngresado(IDPersona)
        Return IDProveedorRecienInsetado
    End Function
    '------CREAMOS EL REGISTRO DEL TIPO PERSONA
    Public Sub CrearTipoPersona(ByVal IDPersona As Int32, ByVal ClasificacionPersonaID As Int32)
        Dim OBJBU As New Negocios.PersonasBU
        Try
            OBJBU.AltaTipoPersona(IDPersona, ClasificacionPersonaID)
        Catch ex As Exception
        End Try
    End Sub
    '------GUARDAMOS LOS DOMICILIOS DE LA PERSONA 
    Public Sub GuardarDomiciliosPersona(ByVal IDPersona As Int32, ByVal ClasificacionPersonaID As Int32)
        Dim objbu As New Negocios.DomicilioBU
        Dim RowIndex As Int32
        Dim EntidadDomicilio As New Entidades.Domicilio
        RowIndex = 0
        For Each row As DataGridViewRow In grdDomicilios.Rows
            EntidadDomicilio = New Entidades.Domicilio
            EntidadDomicilio.calle = CStr(row.Cells("ColCalle").Value)
            EntidadDomicilio.numexterior = CStr(row.Cells("ColNoExterior").Value)
            EntidadDomicilio.numinterior = CStr(row.Cells("ColNoInterior").Value)
            EntidadDomicilio.colonia = CStr(row.Cells("ColColonia").Value)
            Try
                EntidadDomicilio.cp = CStr(row.Cells("ColCP").Value)
            Catch ex As Exception
                EntidadDomicilio.cp = Nothing
            End Try

            Dim EntidadPais As New Entidades.Paises
            Try
                EntidadPais.PIDPais = CInt(row.Cells("PaisID").Value)
            Catch ex As Exception

            End Try

            EntidadDomicilio.pais = EntidadPais
            Dim EntidadEstado As New Entidades.Estados
            Try
                EntidadEstado.EIDDEstado = CInt(row.Cells("EstadoID").Value)
            Catch ex As Exception

            End Try

            EntidadDomicilio.estado = EntidadEstado
            Dim EntidadCiudad As New Entidades.Ciudades
            EntidadCiudad.CciudadId = CInt(row.Cells("CiudadID").Value)
            EntidadDomicilio.ciudad = EntidadCiudad
            Dim EntidadPoblacion As New Entidades.Poblacion
            Try
                EntidadPoblacion.poblacionid = CInt(row.Cells("PoblacionID").Value)
            Catch ex As Exception
                EntidadPoblacion.poblacionid = Nothing
            End Try

            Try
                EntidadDomicilio.delegacion = txtDelegacion.Text
            Catch ex As Exception
                EntidadDomicilio.delegacion = Nothing
            End Try

            EntidadDomicilio.poblacion = EntidadPoblacion
            EntidadDomicilio.activo = CBool(row.Cells("ColActivo").Value)
            EntidadDomicilio.domicilioid = CInt(row.Cells("ColIDDomicilio").Value)
            Dim EntidadPersona As New Entidades.Persona
            EntidadPersona.personaid = IDPersona
            EntidadDomicilio.persona = EntidadPersona
            Dim EntidadClasificacionPersona As New Entidades.ClasificacionPersona
            EntidadClasificacionPersona.clasificacionpersonaid = ClasificacionPersonaID
            EntidadDomicilio.clasificacionpersona = EntidadClasificacionPersona

            If CInt(row.Cells("ColIDDomicilio").Value) = 0 Then
                objbu.AltaDomicilios(EntidadDomicilio)
            Else
                objbu.EditarDomicilios(EntidadDomicilio)
            End If
        Next
    End Sub
    '------GUARDAMOS INFORMACION DE CONTACTOS
    Public Sub GuardarContactos(ByVal ClasificacionPersonaget As Int32, ByVal PersonaID As Int32)


        Dim contactoBU As New Framework.Negocios.ContactosBU
        Dim clasificacionPersona As New Entidades.ClasificacionPersona
        Dim cliente As New Entidades.Cliente
        Dim persona As New Entidades.Persona
        Dim cliente_persona As New Entidades.Persona
        Dim email As New Entidades.Email
        Dim telefono As New Entidades.Telefono
        Dim tipoTelefono As New Entidades.TipoTelefono
        Dim row As UltraGridRow = gridDatosContacto.ActiveRow
        Dim index As Int32
        index = 0

        For Each rowd As Infragistics.Win.UltraWinGrid.UltraGridRow In gridDatosContacto.Rows
            clasificacionPersona.clasificacionpersonaid = CInt(rowd.Cells(1).Column.ValueList.GetValue(gridDatosContacto.Rows(index).Cells(1).Value.ToString, 0))
            persona = New Entidades.Persona

            If String.IsNullOrWhiteSpace(rowd.Cells(2).Value.ToString) Then
                persona.personaid = 0
            Else
                persona.personaid = CInt(rowd.Cells(2).Value)
            End If
            persona.nombre = rowd.Cells(3).Value.ToString

            If String.IsNullOrWhiteSpace(CStr(rowd.Cells(5).Value)) Then
                email.emailpersonasid = 0
            Else
                email.emailpersonasid = CInt(rowd.Cells(4).Value)
            End If
            email.email = rowd.Cells(5).Value.ToString

            If String.IsNullOrWhiteSpace(CStr(rowd.Cells(7).Value)) Then
                telefono.telefonoid = 0
            Else
                telefono.telefonoid = CInt(rowd.Cells(6).Value)
            End If
            telefono.telefono = rowd.Cells(7).Value.ToString

            tipoTelefono.tipotelefonoid = CInt(row.Cells(9).Column.ValueList.GetValue(rowd.Cells(9).Value.ToString, 0))

            cliente_persona.personaid = PersonaID
            Dim ClasificacionCliente As New Entidades.ClasificacionPersona
            ClasificacionCliente.clasificacionpersonaid = ClasificacionPersonaget
            cliente.clasificacionpersona = ClasificacionCliente
            If String.IsNullOrWhiteSpace(CStr(rowd.Cells("tele_extension").Value)) Or rowd.Cells("tele_extension").Value.ToString.Length <= 0 Then
                telefono.extension = ""
            Else
                telefono.extension = CStr(rowd.Cells("tele_extension").Value)
            End If
            persona.activo = True
            telefono.activo = True
            email.activo = True
            ClasificacionCliente.activo = True
            clasificacionPersona.activo = True
            cliente.activo = True
            cliente_persona.activo = True
            If persona.personaid = 0 Then
                contactoBU.AltaContacto(persona, clasificacionPersona, cliente_persona, cliente, email, telefono, tipoTelefono)
            Else
                contactoBU.EditarContacto(0, clasificacionPersona, persona, email, telefono, tipoTelefono)
            End If

        Next
        poblar_gridDatosContacto(PersonaID, gridDatosContacto)



        gridDatosContacto.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    End Sub
    '------GUARDAMOS INFORMACION DE PROVEEDOR
    Public Sub GuardarInformacionProveedor(ByVal Persona As Int32, ByVal ClasificacionPersona As Int32)
        Dim EntidadProveedor As New Entidades.Proveedor
        Dim objbu As New Negocios.ProveedorBU
        EntidadProveedor.pnombregenerico = txtNombreProveedor.Text
        EntidadProveedor.prazonsocial = txtRazonSocialProveedor.Text
        EntidadProveedor.prfc = txtRFCProveedor.Text
        Try
            EntidadProveedor.pclaveyuyincliente = CInt(txtClaveYuyin.Text)
        Catch ex As Exception
            EntidadProveedor.pclaveyuyincliente = Nothing
        End Try

        EntidadProveedor.pusuarioweb = txtUsuarioWeb.Text
        EntidadProveedor.pcontrasenaweb = txtContraseñaWeb.Text
        EntidadProveedor.ppersonaidproveedor = Persona
        EntidadProveedor.pclasificacionpersonaid = ClasificacionPersona
        EntidadProveedor.phorario = txtHorario.Text
        EntidadProveedor.pcomentarios = txtComentarios.Text
        EntidadProveedor.pwebproveedor = txtWebCliente.Text
        EntidadProveedor.pproveedorid = IDProveedor



        If IDPersona > 0 Then
            objbu.EditarProveedor(EntidadProveedor)
        Else
            objbu.AltaProveedor(EntidadProveedor)
        End If

    End Sub
    '------GUARDAR TELEFONOS DE PERSONA
    Public Sub GuardarTelefonos(ByVal PersonaID As Int32, ByVal ClasificacionPersona As Int32)
        Dim EntidadTelefono As New Entidades.Telefono
        Dim objbu As New Negocios.TelefonoBU
        For Each row As DataGridViewRow In grdTelefonos.Rows
            EntidadTelefono.telefono = CStr(row.Cells("ColTelefonoPersona").Value)
            EntidadTelefono.extension = CStr(row.Cells("ColExt").Value)
            Dim tipo_telefono As New Entidades.TipoTelefono
            tipo_telefono.tipotelefonoid = CInt(row.Cells("ColIdTipoTelefono").Value)
            EntidadTelefono.tipotelefono = tipo_telefono
            Dim clasificacion_persona As New Entidades.ClasificacionPersona
            clasificacion_persona.clasificacionpersonaid = ClasificacionPersona
            EntidadTelefono.clasificacionpersona = clasificacion_persona
            Dim persona As New Entidades.Persona
            persona.personaid = PersonaID
            EntidadTelefono.persona = persona
            EntidadTelefono.telefonoid = CInt(row.Cells("ColTelID").Value)
            If EntidadTelefono.telefonoid = 0 Then
                objbu.AltaTelefono(EntidadTelefono)
            Else
                EntidadTelefono.telefonoid = CInt(row.Cells("ColTelID").Value)
                objbu.EditarTelefono(EntidadTelefono)
            End If
        Next
    End Sub
    '------GUARDAR EMAILS
    Public Sub GuardarEmails(ByVal Persona As Int32, ByVal ClasificacionPersona As Int32)
        Dim EntidadEmail As New Entidades.Email
        Dim objbu As New Negocios.EmailBU
        For Each row As DataGridViewRow In grdEmails.Rows
            EntidadEmail.email = CStr(row.Cells("ColEmail").Value)
            Dim persona_entidad As New Entidades.Persona
            persona_entidad.personaid = Persona
            EntidadEmail.persona = persona_entidad
            Dim clasificacion_persona As New Entidades.ClasificacionPersona
            clasificacion_persona.clasificacionpersonaid = ClasificacionPersona
            EntidadEmail.clasificacionpersona = clasificacion_persona
            EntidadEmail.emailpersonasid = CInt(row.Cells("colidEmail").Value)
            If EntidadEmail.emailpersonasid = 0 Then
                objbu.AltaEmail(EntidadEmail)
            Else
                objbu.EditarEmail(EntidadEmail)
            End If
        Next
    End Sub
    'GUARDAR TIPO FLETE MENSAJERIAS
    Public Sub GuardarTipoFleteMensajerias(ByVal IDProveedor As Int32)
        Dim objProveedores As New Negocios.ProveedorBU
        For Each row As DataGridViewRow In grdTiposFleteMensajeria.Rows
            Dim Entidad As New Entidades.TipoFleteMensajeria
            Entidad.tipofleteid = CInt(row.Cells("ColTipoFleteID").Value)
            Entidad.proveedorid = IDProveedor
            Entidad.activo = CBool(row.Cells("ColActivoFlete").Value)
            Entidad.tipofletemensajeriaid = CInt(row.Cells("ID").Value)
            If Entidad.tipofletemensajeriaid > 0 Then
                objProveedores.EditarProveedorTiposFletes(Entidad)
            Else
                objProveedores.AltaProveedorTiposFletes(Entidad)
            End If

        Next
    End Sub
#End Region
#Region "Guardar Contactos"
    Public Sub poblar_gridDatosContacto(PersonaID As Integer, grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim objBU As New Framework.Negocios.ContactosBU
        Dim Contacto, Cargo, TipoTelefono As New DataTable
        Dim vlCargo, vlTipoTelefono As New Infragistics.Win.ValueList




        If grid.Name.Equals("gridCobranzaEvalContacto") Then


        Else
            Contacto = objBU.TablaContactosSinAreaOperativa(PersonaID, 0)
            Cargo = objBU.TablaCargosSinAreaOperativa()
        End If


        TipoTelefono = objBU.TablaTipoTelefonos()

        For Each fila As DataRow In Cargo.Rows
            vlCargo.ValueListItems.Add(fila.Item("clpe_clasificacionpersonaid"), CStr(fila.Item("clpe_nombre")))
        Next

        For Each fila As DataRow In TipoTelefono.Rows
            vlTipoTelefono.ValueListItems.Add(fila.Item("tite_tipotelefonoid"), CStr(fila.Item("tite_nombre")))
        Next

        grid.DataSource = Contacto
        grid.DisplayLayout.Bands(0).Columns(1).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        grid.DisplayLayout.Bands(0).Columns(1).ValueList = vlCargo
        grid.DisplayLayout.Bands(0).Columns(9).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        grid.DisplayLayout.Bands(0).Columns(9).ValueList = vlTipoTelefono
        grid.DisplayLayout.Bands(0).Columns("tele_extension").Header.VisiblePosition = 8
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti

        gridDatosContactoDiseno(grid)

    End Sub
    Private Sub gridDatosContactoDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(2).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(4).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(6).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(8).Hidden = True

        grid.DisplayLayout.Bands(0).Columns(1).Header.Caption = "CARGO"
        grid.DisplayLayout.Bands(0).Columns(3).Header.Caption = "NOMBRE"
        grid.DisplayLayout.Bands(0).Columns(5).Header.Caption = "EMAIL"
        grid.DisplayLayout.Bands(0).Columns(7).Header.Caption = "TELÉFONO"
        grid.DisplayLayout.Bands(0).Columns(9).Header.Caption = "TIPO TELÉFONO"
        grid.DisplayLayout.Bands(0).Columns("tele_extension").Header.Caption = "EXT."

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

    End Sub
    Private Sub asignar_grid_gridDatosContacto(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        gridDatosContacto = grid

    End Sub
    Private Sub gridDatosContacto_MouseClick(sender As Object, e As MouseEventArgs) Handles gridDatosContacto.MouseClick

        Dim mainElement As UIElement
        Dim element As UIElement
        Dim screenPoint As Point
        Dim clientPoint As Point
        Dim row As UltraGridRow
        Dim cell As UltraGridCell

        ' Get the control's main element
        mainElement = Me.gridDatosContacto.DisplayLayout.UIElement

        ' Convert the current mouse position to a point
        ' in client coordinates of the control.
        screenPoint = Control.MousePosition
        clientPoint = Me.gridDatosContacto.PointToClient(screenPoint)

        ' Get the element at that point
        element = mainElement.ElementFromPoint(clientPoint)

        If element Is Nothing Then Return

        Debug.WriteLine("Clicked on an " + element.GetType().ToString())
        Debug.Indent()

        ' Get the row that contains this element.
        row = CType(element.GetContext(GetType(UltraGridRow)), UltraGridRow)

        If Not row Is Nothing Then

            Debug.WriteLine("in row: " + row.Index.ToString())

            ' Get the cell that contains this element.
            cell = CType(element.GetContext(GetType(UltraGridCell)), UltraGridCell)

            If Not cell Is Nothing Then

                If e.Button <> Windows.Forms.MouseButtons.Right Then Return
                'MessageBox.Show("CLICK CLICK    ")
                Dim cms = New ContextMenuStrip
                Dim item1 = cms.Items.Add("Nuevo contacto")
                item1.Tag = 1
                AddHandler item1.Click, AddressOf gridDatosContacto_menuChoice

                Dim item2 = cms.Items.Add("Editar contacto")
                item2.Tag = 2
                AddHandler item2.Click, AddressOf gridDatosContacto_menuChoice

                Dim item3 = cms.Items.Add("Nuevo email")
                item3.Tag = 3
                AddHandler item3.Click, AddressOf gridDatosContacto_menuChoice

                Dim item4 = cms.Items.Add("Nuevo teléfono")
                item4.Tag = 4
                AddHandler item4.Click, AddressOf gridDatosContacto_menuChoice


                cms.Show(Control.MousePosition)

                Debug.WriteLine("in column: " + cell.Column.Key)
                Debug.WriteLine("cell text: " + cell.Text)
            End If
        End If

        ' Walk up the parent element chain and write out a line 
        ' for each parent element.
        While Not element.Parent Is Nothing
            element = element.Parent
            Debug.WriteLine("is a child of an " + element.GetType().ToString())
            Debug.Indent()
        End While

        ' reset the indent level
        Debug.IndentLevel = 0

    End Sub
    Private Sub gridDatosContacto_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)

        If selection = 1 Then ''AGREGAR NUEVO CONTACTO

            Dim grid As DataTable = CType(gridDatosContacto.DataSource, DataTable)
            Dim row As UltraGridRow = gridDatosContacto.ActiveRow
            Dim cargo As UltraGridColumn = gridDatosContacto.DisplayLayout.Bands(0).Columns(1)
            Dim tipoTelefono As UltraGridColumn = gridDatosContacto.DisplayLayout.Bands(0).Columns(9)

            If Not IsNothing(row) Then

                grid.Rows.Add(0, cargo, 0, String.Empty, 0, String.Empty, 0, String.Empty, 0, tipoTelefono)

                gridDatosContacto.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True

                gridDatosContacto.ActiveRow.Activation = Activation.AllowEdit
                gridDatosContacto.ActiveCell = gridDatosContacto.ActiveRow.Cells(1)
                gridDatosContacto.ActiveCell.Activation = Activation.AllowEdit

                gridDatosContacto.PerformAction(UltraGridAction.ToggleCellSel, False, False)
                gridDatosContacto.PerformAction(UltraGridAction.EnterEditMode, False, False)

            End If

        End If

        If selection = 2 Then ''EDITAR CONTACTO ACTUAL

            For Each row In gridDatosContacto.Selected.Rows
                Dim i As Integer = gridDatosContacto.Rows.Count

                gridDatosContacto.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
                gridDatosContacto.DisplayLayout.Override.CellClickAction = CellClickAction.Edit

            Next

        End If

        If selection = 3 Then ''AGREGAR NUEVO EMAIL
            Dim grid As DataTable = CType(gridDatosContacto.DataSource, DataTable)
            Dim row As UltraGridRow = gridDatosContacto.ActiveRow
            Dim cargoID, personaID, emailID, telefonoID, tipoTelefonoID As Integer
            Dim cargo, persona, email, telefono, tipotelefono As String

            If Not IsNothing(row) Then
                cargoID = CInt(row.Cells(0).Value)
                personaID = CInt(row.Cells(2).Value)
                emailID = CInt(row.Cells(4).Value)
                telefonoID = CInt(row.Cells(6).Value)
                tipoTelefonoID = CInt(row.Cells(8).Value)

                cargo = row.Cells(1).Value.ToString
                persona = row.Cells(3).Value.ToString
                email = row.Cells(5).Value.ToString
                telefono = row.Cells(7).Value.ToString
                tipotelefono = row.Cells(9).Value.ToString

                grid.Rows.Add(cargoID, cargo, personaID, persona, 0, String.Empty, telefonoID, telefono, tipoTelefonoID, tipotelefono)

                gridDatosContacto.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True

                gridDatosContacto.ActiveRow.Activation = Activation.AllowEdit
                gridDatosContacto.ActiveCell = gridDatosContacto.ActiveRow.Cells(5)
                gridDatosContacto.ActiveCell.Activation = Activation.AllowEdit

                gridDatosContacto.PerformAction(UltraGridAction.ToggleCellSel, False, False)
                gridDatosContacto.PerformAction(UltraGridAction.EnterEditMode, False, False)

            End If

        End If

        If selection = 4 Then ''AGREGAR NUEVO TELEFONO
            Dim grid As DataTable = CType(gridDatosContacto.DataSource, DataTable)
            Dim row As UltraGridRow = gridDatosContacto.ActiveRow
            Dim cargoID, personaID, emailID, telefonoID, tipoTelefonoID As Integer
            Dim cargo, persona, email, telefono, tipotelefono As String

            If Not IsNothing(row) Then
                cargoID = CInt(row.Cells(0).Value)
                personaID = CInt(row.Cells(2).Value)
                emailID = CInt(row.Cells(4).Value)
                telefonoID = CInt(row.Cells(6).Value)
                tipoTelefonoID = CInt(row.Cells(8).Value)

                cargo = row.Cells(1).Value.ToString
                persona = row.Cells(3).Value.ToString
                email = row.Cells(5).Value.ToString
                telefono = row.Cells(7).Value.ToString
                tipotelefono = row.Cells(9).Value.ToString

                grid.Rows.Add(cargoID, cargo, personaID, persona, emailID, email, 0, String.Empty, tipoTelefonoID, tipotelefono)

                gridDatosContacto.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True

                gridDatosContacto.ActiveRow.Activation = Activation.AllowEdit
                gridDatosContacto.ActiveCell = gridDatosContacto.ActiveRow.Cells(7)
                gridDatosContacto.ActiveCell.Activation = Activation.AllowEdit

                gridDatosContacto.PerformAction(UltraGridAction.ToggleCellSel, False, False)
                gridDatosContacto.PerformAction(UltraGridAction.EnterEditMode, False, False)

            End If

        End If
    End Sub
    Private Sub gridDatosContacto_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridDatosContacto.BeforeExitEditMode
        Try
            Dim cellIndex As Integer = gridDatosContacto.ActiveCell.Column.Index

            If gridDatosContacto.ActiveRow.DataChanged Then

            Else
                If gridDatosContacto.ActiveCell.DataChanged Then
                Else
                    If String.IsNullOrWhiteSpace(CStr(gridDatosContacto.ActiveCell.Value)) Then
                        poblar_gridDatosContacto(CInt(34), gridDatosContacto)
                        gridDatosContacto.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                    End If
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub gridDatosContacto_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridDatosContacto.DoubleClickHeader

        If Me.gridDatosContacto.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.gridDatosContacto.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.gridDatosContacto.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.gridDatosContacto.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.gridDatosContacto.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.gridDatosContacto.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.gridDatosContacto.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If

    End Sub
    Private Sub btnAgregarTelefono_Click(sender As Object, e As EventArgs) Handles btnAgregarTelefono.Click
        Dim valida As Boolean
        If txtTelefono.Text.Length >= 0 And cmbTipoTelefono.SelectedIndex <= 0 Then
            lblTipoTelefono.ForeColor = Color.Red
            If txtTelefono.Text.Length <= 0 Then
                lblTelefono.ForeColor = Color.Red
            Else
                lblTelefono.ForeColor = Color.Black
            End If
            valida = False
        Else
            lblTipoTelefono.ForeColor = Color.Black
            valida = True
        End If




        If valida = True Then


            If indiceTelefono >= 0 Then
                grdTelefonos.Rows(indiceTelefono).Cells("ColTelefonoPersona").Value = txtTelefono.Text
                grdTelefonos.Rows(indiceTelefono).Cells("ColExt").Value = txtExtTelefono.Text
                grdTelefonos.Rows(indiceTelefono).Cells("ColIdTipoTelefono").Value = cmbTipoTelefono.SelectedValue
                grdTelefonos.Rows(indiceTelefono).Cells("ColTipoTelefono").Value = cmbTipoTelefono.Text
                indiceTelefono = -1
            Else
                grdTelefonos.Rows.Add(txtTelefono.Text, txtExtTelefono.Text, cmbTipoTelefono.Text, cmbTipoTelefono.SelectedValue, 0)
            End If
            txtTelefono.Text = ""
            txtExtTelefono.Text = ""
            cmbTipoTelefono.SelectedIndex = 0


        End If


    End Sub
    Private Sub btnQuitarEmail_Click(sender As Object, e As EventArgs) Handles btnQuitarEmail.Click

        If EmailValido(txtEmail.Text) = True Then
            If indiceEmail < 0 Then
                grdEmails.Rows.Add(0, txtEmail.Text)
            Else
                grdEmails.Rows(indiceEmail).Cells("colidEmail").Value = idEmail
                grdEmails.Rows(indiceEmail).Cells("ColEmail").Value = txtEmail.Text
                indiceEmail = -1
                idEmail = 0
                txtEmail.Text = ""
            End If

        Else
            lblEmail.ForeColor = Color.Red
        End If

    End Sub
    Private Sub txtPaginaWeb_TextChanged(sender As Object, e As EventArgs) Handles txtPaginaWeb.TextChanged

    End Sub
    Private Sub AltaPersona_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

#End Region
#Region "Eventos"
    Public Shared Function SoloMayusculas(e As KeyPressEventArgs) As KeyPressEventArgs
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        Return e
    End Function
    Private Sub txtCP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCP.KeyPress
        e = SoloMayusculas(e)
    End Sub
    Private Sub txtsicyID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsicyID.KeyPress
        e = SoloMayusculas(e)
    End Sub
    Private Sub txtClaveYuyin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClaveYuyin.KeyPress
        e = SoloMayusculas(e)
    End Sub
    Private Sub txtExtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExtTelefono.KeyPress
        e = SoloMayusculas(e)
    End Sub
#End Region
#Region "Cargar Datos"
    ''CARGAMOS INFORMACION DE LA PERSONA
    Public Sub CargarDatosPersona(ByVal IDPersona As Int32)
        Dim OBJBU As New Negocios.PersonasBU
        Dim Persona As New Entidades.Persona
        Persona = OBJBU.CargarDatosPersona(IDPersona)
        Try
            txtNombrePersona.Text = Persona.nombre
        Catch ex As Exception
        End Try
        Try
            txtCurpPersona.Text = Persona.CURP
        Catch ex As Exception
        End Try
        Try
            txtRazonSocialPersona.Text = Persona.razonsocial
        Catch ex As Exception
        End Try
        Try
            txtAPaterno.Text = Persona.apaterno
        Catch ex As Exception
        End Try
        Try
            txtAMaterno.Text = Persona.amaterno
        Catch ex As Exception
        End Try
        Try
            txtsicyID.Text = Persona.SicyID.ToString
        Catch ex As Exception
        End Try
        Try
            txtPaginaWeb.Text = Persona.paginaweb
        Catch ex As Exception
        End Try
        Try
            dtpFechaNacimiento.Value = Persona.fechanacimiento
        Catch ex As Exception
        End Try
        Try
            If Persona.personafisica = True Then
                rdoSiPersonaFisica.Checked = True
            Else
                rdoSiPersonaFisica.Checked = False
            End If
        Catch ex As Exception
        End Try
        Try
            If Persona.activo = True Then
                rdoSiActivo.Checked = True
            Else
                rdoNoActivo.Checked = True
            End If
        Catch ex As Exception
        End Try

    End Sub
    ''CARGAMOS LOS DOMICILIOS
    Public Sub CargarDomicilios(ByVal IDPersona As Int32)
        Dim OBJBU As New Negocios.DomicilioBU
        Dim ListaDomicilios As New List(Of Entidades.Domicilio)
        ListaDomicilios = OBJBU.ListaDomiciliosPersona(IDPersona)
        For Each domiclio As Entidades.Domicilio In ListaDomicilios

            Dim celda As DataGridViewCell
            Dim fila As New DataGridViewRow



            celda = New DataGridViewTextBoxCell
            celda.Value = domiclio.calle
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = domiclio.numinterior
            fila.Cells.Add(celda)


            celda = New DataGridViewTextBoxCell
            celda.Value = domiclio.numexterior
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = domiclio.colonia
            fila.Cells.Add(celda)



            celda = New DataGridViewTextBoxCell
            celda.Value = domiclio.cp
            fila.Cells.Add(celda)



            celda = New DataGridViewTextBoxCell
            celda.Value = domiclio.ciudad.CIDEstado.PPais.PNombre
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = domiclio.ciudad.CIDEstado.ENombre
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = domiclio.ciudad.CNombre
            fila.Cells.Add(celda)
            celda = New DataGridViewTextBoxCell
            celda.Value = domiclio.poblacion
            fila.Cells.Add(celda)
            celda = New DataGridViewTextBoxCell
            celda.Value = domiclio.activo
            fila.Cells.Add(celda)
            celda = New DataGridViewTextBoxCell
            celda.Value = domiclio.domicilioid
            fila.Cells.Add(celda)
            celda = New DataGridViewTextBoxCell
            celda.Value = domiclio.ciudad.CIDEstado.PPais.PIDPais
            fila.Cells.Add(celda)
            celda = New DataGridViewTextBoxCell
            celda.Value = domiclio.ciudad.CIDEstado.EIDDEstado
            fila.Cells.Add(celda)
            celda = New DataGridViewTextBoxCell
            celda.Value = domiclio.ciudad.CciudadId
            fila.Cells.Add(celda)
            celda = New DataGridViewTextBoxCell
            Try
                celda.Value = domiclio.poblacion.poblacionid
            Catch ex As Exception
                celda.Value = 0
            End Try

            fila.Cells.Add(celda)




            grdDomicilios.Rows.Add(fila)

        Next

    End Sub
    ''CARGAMOS LOS DATOS DEL PROVEEDOR
    Public Sub CargarDatosProveedor(ByVal idPersona As Int32)
        Dim OBJBU As New Negocios.ProveedorBU
        Dim Proveedor As New Entidades.Proveedor
        Proveedor = OBJBU.DatosProveedor(idPersona)
        txtNombreProveedor.Text = Proveedor.pnombregenerico
        txtRFCProveedor.Text = Proveedor.prfc
        txtComentarios.Text = Proveedor.pcomentarios
        txtUsuarioWeb.Text = Proveedor.pusuarioweb
        txtContraseñaWeb.Text = Proveedor.pcontrasenaweb
        txtRazonSocialProveedor.Text = Proveedor.prazonsocial
        txtClaveYuyin.Text = Proveedor.pclaveyuyincliente.ToString
        txtHorario.Text = Proveedor.phorario
        txtWebCliente.Text = Proveedor.pwebproveedor
        IDProveedor = Proveedor.pproveedorid


    End Sub
    '-- CARGAR TELEFONOS DE LAS PERSONA
    Public Sub CargarTelefonos(ByVal idPersona As Int32)
        Dim objbu As New Negocios.TelefonoBU
        Dim ListaTelefonos As New List(Of Entidades.Telefono)
        ListaTelefonos = objbu.ListaTelefonos(idPersona)
        For Each telefono As Entidades.Telefono In ListaTelefonos
            grdTelefonos.Rows.Add(telefono.telefono, telefono.extension, telefono.tipotelefono.nombre, telefono.tipotelefono.tipotelefonoid, telefono.telefonoid)
        Next

    End Sub
    ''CARGAMOS LAS DIRECCIONES DE EMAIL DEL PROVEEDOR
    Public Sub CargarEmails(ByVal idPersona As Int32)
        Dim OBJBU As New Negocios.EmailBU
        Dim ListaEmail As New List(Of Entidades.Email)
        ListaEmail = OBJBU.ListaEmails(idPersona)
        For Each email As Entidades.Email In ListaEmail
            grdEmails.Rows.Add(email.emailpersonasid, email.email)
        Next
    End Sub
    'CARGAMOS TIPO FLETE MENSAJERIAS
    Public Sub CargarTipoFleteMensajerias(ByVal idProveedor As Int32)
        Dim objbu As New Negocios.ProveedorBU
        Dim ListaTipos As New List(Of Entidades.TipoFleteMensajeria)
        ListaTipos = objbu.ListaTiposFletesProveedor(idProveedor)
        For Each tipo As Entidades.TipoFleteMensajeria In ListaTipos
            grdTiposFleteMensajeria.Rows.Add(tipo.tipofletenombre, tipo.activo, tipo.tipofleteid, tipo.tipofletemensajeriaid)
        Next
    End Sub



#End Region


    Private Sub btnAddTipoFlete_Click(sender As Object, e As EventArgs) Handles btnAddTipoFlete.Click
        If cmbTipoFleteMensajeria.SelectedIndex > 0 Then
            Dim insert As Boolean = True
            For Each row As DataGridViewRow In grdTiposFleteMensajeria.Rows
                If CInt(row.Cells("ColTipoFleteID").Value) = CInt(cmbTipoFleteMensajeria.SelectedValue) Then
                    insert = False
                End If
            Next
            If insert = True Then
                grdTiposFleteMensajeria.Rows.Add(cmbTipoFleteMensajeria.Text, True, cmbTipoFleteMensajeria.SelectedValue)

            End If

        End If

    End Sub




#Region "CONVENIOS"

    ''' <summary>
    ''' LLENA EL GRID CON LA TABLA DE LOS CONVENIOS EXISTENTES
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LlenarTablaConvenios()
        grdListaConvenios.DataSource = Nothing
        Dim objBU As New Negocios.ConveniosBU
        Dim dtListaConvenios As New DataTable
        dtListaConvenios = objBU.listaConvenios(IDProveedor)
        grdListaConvenios.DataSource = dtListaConvenios
    End Sub

    Public Shared Function ComboEmpresas(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        COmboEmpresas = New ComboBox
        COmboEmpresas = comboEntrada
        Dim dtTablaPuestos As New DataTable
        Dim objEmpresasBU As New Framework.Negocios.EmpresasBU
        dtTablaPuestos = objEmpresasBU.listaEmpresas
        dtTablaPuestos.Rows.InsertAt(dtTablaPuestos.NewRow, 0)
        COmboEmpresas.DataSource = dtTablaPuestos
        COmboEmpresas.DisplayMember = "empr_nombre"
        COmboEmpresas.ValueMember = "empr_empresaid"
    End Function

    Private Sub grdListaConvenios_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaConvenios.InitializeLayout
        With grdListaConvenios
            .DisplayLayout.Bands(0).Columns("IdConvenio").Hidden = True
            .DisplayLayout.Bands(0).Columns("IdEmpresa").Hidden = True
            .DisplayLayout.Bands(0).Columns("IdProveedor").Hidden = True
            .DisplayLayout.Bands(0).Columns("Negocioador").Hidden = True
            .DisplayLayout.Bands(0).Columns("Comentarios").Hidden = True
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns 'Ajusta todas las columnas a un tamaño igual.
            .DisplayLayout.Bands(0).Columns(1).Width = 300 'Ajusta la columna indicada a un tamaño manualmente asignado.
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No

            .DisplayLayout.Bands(0).Columns("IdConvenio").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Empresa").CellActivation = Activation.AllowEdit
            .DisplayLayout.Bands(0).Columns("Numero").CellActivation = Activation.AllowEdit
            .DisplayLayout.Bands(0).Columns("Negocioador").CellActivation = Activation.AllowEdit
            .DisplayLayout.Bands(0).Columns("Descripción").CellActivation = Activation.AllowEdit
            .DisplayLayout.Bands(0).Columns("Comentarios").CellActivation = Activation.AllowEdit
            .DisplayLayout.Bands(0).Columns("Activo").CellActivation = Activation.AllowEdit
            .DisplayLayout.Bands(0).Columns("IdEmpresa").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("IdProveedor").CellActivation = Activation.NoEdit
        End With

    End Sub

    ''' <summary>
    ''' VERIFICA QUE NO EXISTAN CAMPOS VACIOS EN LA PESTAÑA DE CONVENIOS
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub VerificarCamposVacios()
        CamposVacios = False
        Dim forma As New AdvertenciaForm

        If cmbRazonSocial.SelectedIndex = 0 Then
            lblEmpresa.ForeColor = Color.Red
            CamposVacios = True
        Else
            lblEmpresa.ForeColor = Color.Black
        End If

        If txtNumConvenio.Text = "" Then
            lblNumConvenio.ForeColor = Color.Red
            CamposVacios = True
        Else
            lblNumConvenio.ForeColor = Color.Black
        End If

        If dtpFechaInicioVigencia.Text = "" Then
            lblVigenciaInicio.ForeColor = Color.Red
            CamposVacios = True
        Else
            lblVigenciaInicio.ForeColor = Color.Black
        End If

        If dtpFechaTerminoVigencia.Text = "" Then
            lblVigenciaFin.ForeColor = Color.Red
            CamposVacios = True
        Else
            lblVigenciaFin.ForeColor = Color.Black
        End If

        If txtNegociador.Text = "" Then
            lblNegocia.ForeColor = Color.Red
            CamposVacios = True
        Else
            lblNegocia.ForeColor = Color.Black
        End If

        If txtDescripcionConvenios.Text = "" Then
            lblDescripcion.ForeColor = Color.Red
            CamposVacios = True
        Else
            lblDescripcion.ForeColor = Color.Black
        End If

        FechaInicio = CDate(dtpFechaInicioVigencia.Text)
        FechaFin = CDate(dtpFechaTerminoVigencia.Text)
        FechaInicio = CDate(dtpFechaInicioVigencia.Text)

        If FechaInicio > FechaFin Then
            CamposVacios = True
        End If

    End Sub


    Public Sub VerificarCamposEscritos()
        Dim forma As New AdvertenciaForm

        If txtNumConvenio.Text <> "" Or txtNegociador.Text <> "" Or txtComentarioConvenios.Text <> "" Or txtDescripcionConvenios.Text <> "" Then
            CamposEscritos = True
        Else
            CamposEscritos = False
        End If
    End Sub


    ''' <summary>
    ''' REALIZA LAS ACCIONES NECESARIAS PARA DAR DE ALTA UN REGISTRO DE CONVENIO NUEVO EN LA TABLA FRAMEWORK.CONVENIOEMPRESAPROVEEDOR
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AgregarConvenio(ByVal IdProveedor As Integer)
        If CamposVacios = False Then
            Dim Convenios As New Entidades.Convenios
            Convenios.PIdProveedor = IdProveedor
            Convenios.PIdEmpresa = CInt(cmbRazonSocial.SelectedValue)
            Convenios.PNumeroConvenio = txtNumConvenio.Text
            Convenios.PFechaSub = CDate(dtpFechaDeSubscripcion.Text)
            Convenios.PFechaInicio = CDate(dtpFechaInicioVigencia.Text)
            Convenios.PFechaFin = CDate(dtpFechaTerminoVigencia.Text)
            Convenios.PNegociador = txtNegociador.Text
            Convenios.PDescripcion = txtDescripcionConvenios.Text
            Convenios.PComentario = txtComentarioConvenios.Text
            If rdoSiConvenio.Checked Then
                Convenios.PActivo = True
            Else
                Convenios.PActivo = False
            End If
            Dim objConveniosBU As New Negocios.ConveniosBU
            objConveniosBU.GuardarConvenio(Convenios)
            Dim FormularioMensaje As New ExitoForm
            FormularioMensaje.mensaje = "Convenio Guardado"
            FormularioMensaje.StartPosition = FormStartPosition.CenterScreen
            FormularioMensaje.ShowDialog()
        Else
            Dim FormularioMensaje As New ErroresForm
            FormularioMensaje.mensaje = "Campos Vacíos"
            FormularioMensaje.StartPosition = FormStartPosition.CenterScreen
            FormularioMensaje.ShowDialog()
        End If
    End Sub

    ''' <summary>
    ''' GUARDA VALORES EN LA CLASE ENTIDADES.CONVENIOS PARA ACTUALIZAR LOS DATOS DE UN REGISTRO DE CONVENIOS.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ActualizarConvenios()
        If CamposVacios = False Then
            Dim Convenios As New Entidades.Convenios
            Convenios.PIdProveedor = IdPersonaConvenioa
            Convenios.PIdConvenio = IdConvenio
            Convenios.PIdEmpresa = CInt(cmbRazonSocial.SelectedValue)
            Convenios.PNumeroConvenio = txtNumConvenio.Text
            Convenios.PFechaSub = CDate(dtpFechaDeSubscripcion.Text)
            Convenios.PFechaInicio = CDate(dtpFechaInicioVigencia.Text)
            Convenios.PFechaFin = CDate(dtpFechaTerminoVigencia.Text)
            Convenios.PNegociador = txtNegociador.Text
            Convenios.PDescripcion = txtDescripcionConvenios.Text
            Convenios.PComentario = txtComentarioConvenios.Text
            If rdoSiConvenio.Checked Then
                Convenios.PActivo = True
            Else
                Convenios.PActivo = False
            End If
            Dim objConveniosBU As New Negocios.ConveniosBU
            objConveniosBU.ActualizarConvenios(Convenios)
            Dim FormularioMensaje As New ExitoForm
            FormularioMensaje.mensaje = "Registro Actualizado"
            FormularioMensaje.ShowDialog()
        Else
            Dim FormularioMensaje As New ErroresForm
            FormularioMensaje.mensaje = "Campos Vacios"
            FormularioMensaje.ShowDialog()
        End If
    End Sub

    ''' <summary>
    ''' VERIFICA SI HAY CAMPOS VACIOS, AGREGA EL CONVENIO Y ACTUALIZA LA LISTA DE CONVENIOS
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub btnAgregarConvenio_Click(sender As Object, e As EventArgs) Handles btnAgregarConvenio.Click
        VerificarCamposVacios()
        AgregarConvenio(IDProveedor)
        LlenarTablaConvenios()
    End Sub

    ''' <summary>
    ''' VERIFICA SI HAY CAMPOS VACIOS, ACTUALIZA EL REGISTRO, LLENA LA LISTA DE CONVENIOS
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        'Actualiza el registro del convenio en caso de que se haya modificado
        VerificarCamposVacios()
        ActualizarConvenios()
        LlenarTablaConvenios()
        limpiarCampos()
        btnAgregarConvenio.Enabled = True
    End Sub

    Private Sub grdListaConvenios_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListaConvenios.ClickCell

        Dim fila As UltraGridRow = grdListaConvenios.ActiveRow
        If fila.IsFilterRow Then Return
        btnActualizar.Enabled = True
        btnAgregarConvenio.Enabled = False
        IdConvenio = CInt(fila.Cells("IdConvenio").Value)
        txtNumConvenio.Text = CStr(fila.Cells("Numero").Value)
        dtpFechaDeSubscripcion.Text = CStr(CDate(fila.Cells("Fecha Subscripcion").Value))
        dtpFechaInicioVigencia.Text = CStr(CDate(fila.Cells("Fecha Inicio").Value))
        dtpFechaTerminoVigencia.Text = CStr(CDate(fila.Cells("Fecha Fin").Value))
        txtNegociador.Text = CStr(fila.Cells("Negocioador").Value)
        txtDescripcionConvenios.Text = CStr(fila.Cells("Descripción").Value)
        txtComentarioConvenios.Text = CStr(fila.Cells("Comentarios").Value)
        cmbRazonSocial.SelectedValue = CInt(fila.Cells("IdEmpresa").Value)
        IdPersonaConvenioa = CInt(fila.Cells("IdProveedor").Value)
        If CBool(fila.Cells("Activo").Value) = True Then
            rdoSiConvenio.Checked = True
        Else
            rdoNoConvenio.Checked = True
        End If
    End Sub

    Private Sub grdListaConvenios_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListaConvenios.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub limpiarCampos()
        cmbRazonSocial.SelectedIndex = 0
        txtNumConvenio.Text = ""
        txtDescripcionConvenios.Text = ""
        txtComentarioConvenios.Text = ""
        txtNegociador.Text = ""
        dtpFechaDeSubscripcion.Value = DateTime.Now
        dtpFechaInicioVigencia.Value = DateTime.Now
        dtpFechaTerminoVigencia.Value = DateTime.Now
        rdoSiConvenio.Checked = True
        btnActualizar.Enabled = False
    End Sub


#End Region




    Private Sub rdoSiConvenio_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSiConvenio.CheckedChanged

    End Sub

    Private Sub rdoNoConvenio_CheckedChanged(sender As Object, e As EventArgs) Handles rdoNoConvenio.CheckedChanged

    End Sub

    Private Sub grdEmails_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdEmails.CellDoubleClick
        If e.RowIndex >= 0 Then
            txtEmail.Text = CStr(grdEmails.Rows(e.RowIndex).Cells("ColEmail").Value)
            txtEmail.Text = txtEmail.Text.Replace(" ", "")
            idEmail = CInt(grdEmails.Rows(e.RowIndex).Cells("colidEmail").Value)
            indiceEmail = e.RowIndex
        End If
    End Sub

    Private Sub grdEmails_DoubleClick(sender As Object, e As EventArgs) Handles grdEmails.DoubleClick

    End Sub

    Private Sub grdTelefonos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdTelefonos.CellDoubleClick
        If e.RowIndex >= 0 Then
            txtTelefono.Text = CStr(grdTelefonos.Rows(e.RowIndex).Cells("ColTelefonoPersona").Value)
            txtExtTelefono.Text = CStr(grdTelefonos.Rows(e.RowIndex).Cells("ColExt").Value)
            cmbTipoTelefono.SelectedValue = CInt(grdTelefonos.Rows(e.RowIndex).Cells("ColIdTipoTelefono").Value)
            indiceTelefono = e.RowIndex
        End If
    End Sub

    Private Sub grdDomicilios_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdDomicilios.CellDoubleClick
        If e.RowIndex >= 0 Then
            txtCalle.Text = CStr(grdDomicilios.Rows(e.RowIndex).Cells("ColCalle").Value)
            txtNoInterior.Text = CStr(grdDomicilios.Rows(e.RowIndex).Cells("ColNoInterior").Value)
            txtNoExterior.Text = CStr(grdDomicilios.Rows(e.RowIndex).Cells("ColNoExterior").Value)
            txtColonia.Text = CStr(grdDomicilios.Rows(e.RowIndex).Cells("ColColonia").Value)
            txtCP.Text = CStr(grdDomicilios.Rows(e.RowIndex).Cells("ColCP").Value)
            cmbPais.Text = CStr(grdDomicilios.Rows(e.RowIndex).Cells("ColPais").Value)
            cmbEstado.Text = CStr(grdDomicilios.Rows(e.RowIndex).Cells("ColEstado").Value)
            cmbCiudad.Text = CStr(grdDomicilios.Rows(e.RowIndex).Cells("ColCiudad").Value)
            Try
                cmbPoblacion.SelectedValue = CStr(grdDomicilios.Rows(e.RowIndex).Cells("PoblacionID").Value)
            Catch ex As Exception

            End Try

            rdoSiActivoDomicilio.Checked = CBool(grdDomicilios.Rows(e.RowIndex).Cells("ColActivo").Value)
            If rdoSiActivoDomicilio.Checked = False Then
                rdoNoActivoDomicilio.Checked = True
            End If
            indiceDomicilios = e.RowIndex
        End If
    End Sub
End Class