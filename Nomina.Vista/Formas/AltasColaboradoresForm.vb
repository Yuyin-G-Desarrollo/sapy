Imports System.IO
Imports Framework.Negocios
Imports Tools

Public Class AltasColaboradoresForm
    Public colaboradorId As Int32
    Public colaboradorLaboralId As Int32
    Dim colabororador As New Entidades.Colaborador
    Public SeleccionReferencia As Int32
    Dim archivo As String = ""
    Dim Archivos As New Entidades.ColaboradorExpediente
    Public NNomina As Int32 = 0
    Public LLaboral As Int32 = 0
    Public MMedica As Int32 = 0
    Public AAdicional As Int32 = 0
    Private IDColaboradorfromList As Int32
    Public Credenciales As New Boolean
    Dim IdAcademica As Int32
    Public IndexSeleccionado As Int32 = -1
    Public IndexAcademica As Int32 = -1
    Public SueldoDiario As Boolean = False
    Public CambioSueldo As Int32 = 0
    Dim cambioDeSalario As Boolean = False
    Dim RandGen As New Random

    Public Property PIDcolaboradorfromLis As Int32
        Get
            Return IDColaboradorfromList
        End Get
        Set(ByVal value As Int32)
            IDColaboradorfromList = value
        End Set
    End Property

    Private Sub Colaboradores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If PermisosUsuarioBU.ConsultarPermiso("NOM_COL_CODR", "SUELDO_SEMANALAGUINALDO") Then
            lblSueldoSemanalAguinaldo.Visible = True
            txtSueldoSemanalAguinaldo.Visible = True
        End If

        TbAcademica.Parent = Nothing
        tbReferencias.Parent = Nothing

        InitCombos()
        cmbEstadoCiudad = Tools.Controles.ComboEstadosAnidado(cmbEstadoCiudad, 1)
        cmbEstadoOrigen = Tools.Controles.ComboEstadosAnidado(cmbEstadoOrigen, 1)
        ' cmbPatron = Controles.ComboPatrones(cmbPatron) 'SCDA310120201011
        Dim objBu As New Negocios.ColaboradoresBU
        Dim dtEmpresa As New DataTable

        dtEmpresa = objBu.consultarPatronPorNavesUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If dtEmpresa.Rows.Count > 0 Then
            cmbPatron.DataSource = dtEmpresa
            cmbPatron.DisplayMember = "Patron"
            cmbPatron.ValueMember = "ID"
            cmbPatron.SelectedIndex = 0
        End If

        txtNSS.MaxLength = 12
        cmbBanco = Controles.ComboBancos(cmbBanco)
        PictureBox1.Visible = False
        If colaboradorId <= 0 Then 'Es registro nuevo

        Else 'Es un Update

            cmbNave.Enabled = False 'Se bloquea para cambiar la Nava
            dtpFechaIngreso.Enabled = False 'Se bloque la fecha de ingreso

            Dim col As New Entidades.Colaborador
            Dim objColBu As New Negocios.ColaboradoresBU
            col = objColBu.BuscarColaboradorGeneral(colaboradorId)
            'lblNombre.Text = col.PNombre

            ''valida si ya tiene solicitudes de imss
            validaSolicitudImss(colaboradorId)

            cmbPatron.Enabled = False

        End If

        grdArchivos.ReadOnly = True
        ValidarUpdatesOrInserts(colaboradorId)

        CargarDatosGenerales()
        CargarDatosNomina()
        CargarInformacionLaboral()
        CargarInformacionMedica()
        CargarInformacionAdiconal()
        CargarColaboradorArchivos()
        CargarColaboradorAcademica()
        CargarColaboradorReferencias()
        lblTipo.Visible = False
        lblTipoInfonavit.Visible = False

        If cmbNave.SelectedIndex > 0 Then
            If colaboradorId <= 0 Then
                Dim objPeriodo As New Negocios.ControlDePeriodoBU
                Dim dtidfechaperiodoActual As New DataTable
                Dim entRangoPerdiodo As New Entidades.PeriodosNomina
                Dim fechaperiodoActualInicio As Date = Date.Now
                Dim idPeriodo As Int32 = 0
                dtidfechaperiodoActual = objPeriodo.periodoSegunNaveSegunAsistenciaActual(cmbNave.SelectedValue)
                Try
                    idPeriodo = dtidfechaperiodoActual.Rows(0).Item(0).ToString
                    entRangoPerdiodo = objPeriodo.buscarRangosPeriodoSegunNaveSegunAsistencia(idPeriodo)
                Catch ex As Exception

                End Try
                dtpFechaIngreso.Enabled = True
            End If

        Else
            If colaboradorId <= 0 Then
                dtpFechaIngreso.Enabled = False
            End If
        End If

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'Try
        Dim objColaboradorBU As New Negocios.ColaboradoresBU
        If ValidarCamposGeneral() And
            ValidarCamposNomina() And
            ValidarCamposReal() And
            ValidarCamposLaboral() Then

            GuardarColaboradorGeneral()
            If colaboradorId <= 0 Then
                colaboradorId = objColaboradorBU.BuscarColaboradorId
            Else
            End If
            CambioSueldo = True
            colabororador.PColaboradorid = colaboradorId

            GuardarColaboradorLaboral(colabororador)
            GuardarColaboradorReal(colabororador)
            GuardarColaboradorNomina(colabororador)
            GuardarInformacionMedica(colabororador)
            GuardarInformacionAcademica(colabororador)
            GuardarInformacionFamilia(colabororador)
            GuardarInformacionAcademicaColaborador(colabororador)
            InsertarArchivo(colaboradorId)
            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "Registro Guardado"
            'mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.ShowDialog()
            grdReferencias.Rows.Clear()
            CargarColaboradorReferencias()
            grdAcademica.Rows.Clear()
            CargarColaboradorAcademica()

        Else
            Dim MensajeError As New AdvertenciaForm
            MensajeError.mensaje = "Faltan Campos por llenar"
            MensajeError.MdiParent = Me.MdiParent
            MensajeError.Show()
        End If

    End Sub

    Public Sub InitCombos()
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        Try
            If cmbNave.SelectedValue > 0 Then
                cmbArea = Controles.ComboAreasSegunNaves(cmbArea, cmbNave.SelectedValue)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function ValidarCamposGeneral() As Boolean
        ValidarCamposGeneral = True
        If txtNombreColaborador.Text.Length <= 0 Then
            ValidarCamposGeneral = False
            lblNombreCol.ForeColor = Color.Red
        Else
            lblNombreCol.ForeColor = Color.Black
        End If
        If txtAPaternoColaborador.Text.Length <= 0 Then
            ValidarCamposGeneral = False
            lblPaterno.ForeColor = Color.Red
        Else
            lblPaterno.ForeColor = Color.Black
        End If
        If txtCurp.Text.Length <= 0 Then
            ValidarCamposGeneral = False
            lblCurp.ForeColor = Color.Red
        ElseIf txtCurp.Text.Trim.Length <> 18 Then
            ValidarCamposGeneral = False
            lblCurp.ForeColor = Color.Red
        Else
            lblCurp.ForeColor = Color.Black
        End If
        If txtRfc.Text.Trim.Length <= 0 Then
            ValidarCamposGeneral = False
            lblRfc.ForeColor = Color.Red
        ElseIf txtRfc.Text.Trim.Length <> 13 Then
            ValidarCamposGeneral = False
            lblRfc.ForeColor = Color.Red
        Else
            lblRfc.ForeColor = Color.Black
        End If
        If IsNothing(dtpNacimiento.Value) Then
            ValidarCamposGeneral = False
            lblNacimiento.ForeColor = Color.Red
        Else
            lblNacimiento.ForeColor = Color.Black
        End If
        If cmbEstadoCivil.SelectedIndex <= 0 Then
            ValidarCamposGeneral = False
            lblEdoCivil.ForeColor = Color.Red
        Else
            lblEdoCivil.ForeColor = Color.Black
        End If

        If txtCalleColaborador.Text.Length <= 0 Then
            ValidarCamposGeneral = False
            lblCalle.ForeColor = Color.Red
        Else
            lblCalle.ForeColor = Color.Black
        End If

        If txtNumeroColaborador.Text.Length <= 0 Then
            ValidarCamposGeneral = False
            lblNumero.ForeColor = Color.Red
        Else
            lblNumero.ForeColor = Color.Black
        End If

        If txtColoniaColaborador.Text.Length <= 0 Then
            ValidarCamposGeneral = False
            lblColonia.ForeColor = Color.Red
        Else
            lblColonia.ForeColor = Color.Black
        End If

        If cmbCiudadColaborador.SelectedIndex <= 0 Then
            ValidarCamposGeneral = False
            lblCiudad.ForeColor = Color.Red
        Else
            lblCiudad.ForeColor = Color.Black
        End If

        'cmbCiudadOrigen
        If cmbCiudadOrigen.SelectedIndex <= 0 Then
            ValidarCamposGeneral = False
            lblCiudadOrigen.ForeColor = Color.Red
        Else
            lblCiudadOrigen.ForeColor = Color.Black
        End If

        If txtCPColaborador.Text.Length <= 0 Then
            ValidarCamposGeneral = False
            lblCp.ForeColor = Color.Red
        ElseIf txtCPColaborador.Text.Trim.Length <> 5 Then
            ValidarCamposGeneral = False
            lblCp.ForeColor = Color.Red
        ElseIf Not IsNumeric(txtCPColaborador.Text.Trim) Then
            ValidarCamposGeneral = False
            lblCp.ForeColor = Color.Red
        Else
            lblCp.ForeColor = Color.Black
        End If

        If txtEntreCalles.Text.Length <= 0 Then
            ValidarCamposGeneral = False
            lblEntreCalles.ForeColor = Color.Red
        Else
            lblEntreCalles.ForeColor = Color.Black
        End If

        If txtReferencias.Text.Length <= 0 Then
            ValidarCamposGeneral = False
            txtReferencias.ForeColor = Color.Red
        Else
            txtReferencias.ForeColor = Color.Black
        End If

        If ValidarCamposGeneral = False Then

            If txtCurp.Text.Length < 18 Then
                Dim erroresForm As New AdvertenciaForm
                erroresForm.mensaje = "Capture el Curp COMPLETO"
                erroresForm.MdiParent = Me.MdiParent
                erroresForm.Show()
            ElseIf txtCurp.Text.Length > 18 Then
                Dim erroresForm As New AdvertenciaForm
                erroresForm.mensaje = "El Curp excede los 18 caracteres permitidos para el CURP"
                erroresForm.MdiParent = Me.MdiParent
                erroresForm.Show()
            End If
        End If
        Return ValidarCamposGeneral
    End Function

    Public Function ValidarCamposNomina() As Boolean
        Dim empty As Boolean = True
        Dim valida As Boolean = True

        If cmbFormaPagoFiscal.SelectedIndex > 0 Then
            empty = True
        End If

        If empty = True Then

            If cmbFormaPagoFiscal.SelectedIndex <= 0 Then
                lblFormaPagoFiscal.ForeColor = Color.Red
                valida = False
            Else
                lblFormaPagoFiscal.ForeColor = Color.Black
            End If

        End If
        ValidarCamposNomina = valida

        If ValidarCamposNomina = False Then

        End If
        Return ValidarCamposNomina
    End Function

    Public Function ValidarCamposLaboral() As Boolean
        Dim empty As Boolean = True
        Dim valida As Boolean = True

        If cmbNave.SelectedValue > 0 Then
            empty = True
        End If
        If cmbDepartamento.SelectedIndex > 0 Then
            empty = True
        End If

        If cmbPuesto.SelectedIndex > 0 Then
            empty = True
        End If

        'If rdoHorarioSi.Checked And cmbHorario.SelectedIndex > 0 Then '200920191341 El horario es obligatorio
        If cmbHorario.SelectedIndex > 0 Then
            empty = True
        End If

        If empty = True Then
            If cmbNave.SelectedValue <= 0 Then
                lblNaveLaboral.ForeColor = Color.Red
                valida = False
            Else
                lblNaveLaboral.ForeColor = Color.Black
            End If

            If cmbDepartamento.SelectedIndex <= 0 Then
                lblDepartamentoLaboral.ForeColor = Color.Red
                valida = False
            Else
                lblDepartamentoLaboral.ForeColor = Color.Black
            End If

            If cmbPuesto.SelectedIndex <= 0 Then
                lblPuestoLaboral.ForeColor = Color.Red
                valida = False
            Else
                lblPuestoLaboral.ForeColor = Color.Black
            End If

            'If rdoHorarioSi.Checked And cmbHorario.SelectedIndex <= 0 Then '200920191341 El horario es obligatorio
            If cmbHorario.SelectedIndex <= 0 Then
                lblHorariolaboral.ForeColor = Color.Red
                valida = False
            Else
                lblHorariolaboral.ForeColor = Color.Black
            End If

            If rbLicenciaSi.Checked = True And txtFolioLicencia.Text = "" Then
                lblFolioLicencia.ForeColor = Color.Red
                lblVigencia.ForeColor = Color.Red
                valida = False
            Else
                lblFolioLicencia.ForeColor = Color.Black
            End If
        End If

        ValidarCamposLaboral = valida

        If ValidarCamposLaboral = False Then

        End If
        Return ValidarCamposLaboral
    End Function

    Public Function ValidarCampoMedica() As Boolean
        Dim empty As Boolean = False
        Dim valida As Boolean = True
        If txtTipoSanguineo.SelectedIndex > 0 Then
            empty = True
        End If
        If txtContactoEmergencias.Text.Length > 0 Then
            empty = True
        End If


        If txtTelefonoEmergencias.Text.Length > 0 Then
            empty = True
        End If

        If txtConsideracionesEspeciales.Text.Length > 0 Then
            empty = True
        End If

        ValidarCampoMedica = empty
    End Function

    Public Function ValidarCamposReal() As Boolean
        Dim empty As Boolean = True
        Dim valida As Boolean = True
        If cmbFormaPagoReal.SelectedIndex > 0 Then
            empty = True
        End If

        If cmbTipoNomina.SelectedIndex > 0 Then
            empty = True
        End If

        If txtSueldoReal.Text.Length > 0 Then
            empty = True
        End If

        If empty = True Then
            If cmbFormaPagoReal.SelectedIndex <= 0 Then
                'lblFormaPagoReal.ForeColor = Color.Red
                lblTipoNomina.ForeColor = Color.Red
                valida = False
            Else
                'lblFormaPagoReal.ForeColor = Color.Black
                lblTipoNomina.ForeColor = Color.Black
            End If

            If txtSueldoReal.Text.Length <= 0 Then

                lblSueldoReal.ForeColor = Color.Red
                valida = False
            Else
                lblSueldoReal.ForeColor = Color.Black
            End If
            If cmbTipoNomina.SelectedIndex <= 0 Then
                lblFormaPagoReal.ForeColor = Color.Red
                'lblTipoNomina.ForeColor = Color.Red
                valida = False

            Else
                lblFormaPagoReal.ForeColor = Color.Black
                'lblTipoNomina.ForeColor = Color.Black
            End If


        End If

        ValidarCamposReal = valida
        If ValidarCamposReal = False Then

        End If
        Return ValidarCamposReal
    End Function

    Public Function ValidarFamilia() As Boolean
        Dim empty As Boolean = False
        Dim valida As Boolean = True

        If txtNombreReferencia.Text.Length <= 0 Then
            lblNombreFamilia.ForeColor = Color.Red
            valida = False
        Else
            lblNombreFamilia.ForeColor = Color.Black
        End If

        If cmbParentezcoReferencia.Text.Length <= 0 Then
            lblParentezcoFamilia.ForeColor = Color.Red
            valida = False
        Else
            lblParentezcoFamilia.ForeColor = Color.Black
        End If

        If txtOcupacionReferencia.Text.Length <= 0 Then

            lblOcupacion.ForeColor = Color.Red
            valida = False
        Else
            lblOcupacion.ForeColor = Color.Black
        End If

        ValidarFamilia = valida
        If ValidarFamilia = False Then
            Dim erroresForm As New AdvertenciaForm
            erroresForm.mensaje = "Complete los campos marcados con *"
            erroresForm.MdiParent = Me.MdiParent
            erroresForm.Show()
        End If
        Return ValidarFamilia

    End Function

    Public Function ValidarAcademica()
        Dim empty As Boolean = False
        Dim valida As Boolean = True

        If txtEscuela.Text.Length <= 0 Then
            lbl.ForeColor = Color.Red
            valida = False
        Else
            lbl.ForeColor = Color.Black
        End If

        If txtAnioInicio.Text.Length <= 0 Then

            lblInicio.ForeColor = Color.Red
            valida = False
        Else
            lblInicio.ForeColor = Color.Black
        End If


        If cmbEstado.Text.Length <= 0 Then
            lblEstado.ForeColor = Color.Red
            valida = False

        Else
            lblEstado.ForeColor = Color.Black
        End If

        If cmbGrado.Text.Length <= 0 Then
            lblGrado.ForeColor = Color.Red
            valida = False

        Else
            lblGrado.ForeColor = Color.Black
        End If

        ValidarAcademica = valida
        If ValidarAcademica = False Then
            Dim erroresForm As New AdvertenciaForm
            erroresForm.mensaje = "Complete los campos marcados con *"
            erroresForm.MdiParent = Me.MdiParent
            erroresForm.Show()
        End If
        Return ValidarAcademica
    End Function

    Public Sub GuardarColaboradorGeneral()
        Dim objColaboradorBU As New Negocios.ColaboradoresBU

        Dim ciudad As New Entidades.Ciudades
        ciudad.CciudadId = CInt(cmbCiudadColaborador.SelectedValue)
        Dim ciudadOrigen As New Entidades.Ciudades
        Try
            ciudadOrigen.CciudadId = CInt(cmbCiudadOrigen.SelectedValue)
        Catch ex As Exception

        End Try

        colabororador.PNombre = txtNombreColaborador.Text
        colabororador.PApaterno = txtAPaternoColaborador.Text
        colabororador.PAmaterno = txtAMaternoColaborador.Text
        colabororador.pCurp = txtCurp.Text
        colabororador.PRfc = txtRfc.Text
        colabororador.PFechaNacimiento = dtpNacimiento.Value
        colabororador.PCalle = txtCalleColaborador.Text
        colabororador.Pnumero = txtNumeroColaborador.Text
        colabororador.Pcolonia = txtColoniaColaborador.Text
        colabororador.PCiudad = ciudad
        colabororador.PCiudadOrigen = ciudadOrigen
        colabororador.PCP = txtCPColaborador.Text
        colabororador.PTelefonoCasa = txtTelefonoCasa.Text
        colabororador.PTelefonoCel = txtTelefonoCelular.Text
        colabororador.PEstadoCivil = cmbEstadoCivil.SelectedItem
        colabororador.PEntreCalles = txtEntreCalles.Text
        colabororador.PReferencia = txtReferencias.Text

        colabororador.PEmail = txtEmail.Text
        colabororador.PClaveElector = txtClaveElector.Text
        colabororador.PSexo = cmbSexo.Text
        colabororador.PNombreCorto = txtNombreCorto.Text

        If colaboradorId > 0 Then 'es update
            objColaboradorBU.EditarColaborador(colabororador, colaboradorId)
        Else 'Es insert
            objColaboradorBU.AgregarColaborador(colabororador)
        End If
    End Sub

    Public Sub GuardarInformacionAcademica(ByVal colaboradores As Entidades.Colaborador)

    End Sub

    Public Sub GuardarInformacionMedica(ByVal salud As Entidades.Colaborador)
        Dim Valida As Boolean = True
        If (txtTipoSanguineo.SelectedIndex > 0) _
            Or txtContactoEmergencias.Text.Length > 0 _
            Or txtTelefonoEmergencias.Text.Length > 0 _
            Or txtConsideracionesEspeciales.Text.Length > 0 Then

            Valida = True
        End If

        If Valida = True Then
            Dim objBU As New Negocios.ColaboradorMedicaBU
            Dim medica As New Entidades.ColaboradorMedica
            medica.PColaboradorID = salud
            medica.PTipoSanguineo = txtTipoSanguineo.Text
            medica.PContactoEmergencias = txtContactoEmergencias.Text
            medica.PTelefonoEmergencias = txtTelefonoEmergencias.Text
            medica.PComentarios = txtConsideracionesEspeciales.Text

            If MMedica > 0 Then
                objBU.EditarINFMedica(medica, colaboradorId)
            Else
                objBU.AgregarINFMedica(medica)
            End If

        Else

        End If

    End Sub
    Public Sub GuardarColaboradorLaboral(ByVal col As Entidades.Colaborador)
        Dim valida = False
        Dim laboral As New Entidades.ColaboradorLaboral
        Dim nave As New Entidades.Naves
        Dim depto As New Entidades.Departamentos
        Dim celula As New Entidades.Celulas
        Dim puesto As New Entidades.Puestos
        Dim horario As New Entidades.Horarios
        Dim horario2 As New Entidades.Horarios
        Dim objLaboralBU As New Negocios.ColaboradorLaboralBU
        Dim ObjHistorialHorarios As New Negocios.HistorialSalarioBUvb
        If cmbNave.SelectedValue > 0 Then
            valida = True
            nave.PNaveId = cmbNave.SelectedValue
        Else
            valida = False
        End If

        If cmbArea.SelectedIndex > 0 Then
            valida = True
            laboral.PAreaID = cmbArea.SelectedValue
        Else
            valida = False
        End If
        If cmbDepartamento.SelectedIndex > 0 Then
            valida = True
            depto.Ddepartamentoid = cmbDepartamento.SelectedValue
        Else
            valida = False
        End If
        Try
            If cmbCelula.SelectedIndex > 0 Then
                valida = True
                celula.PCelulaid = cmbCelula.SelectedValue
            End If
        Catch ex As Exception

        End Try


        If cmbPuesto.SelectedIndex > 0 Then
            valida = True
            puesto.Ppuestosid = cmbPuesto.SelectedValue
        Else
            valida = False
        End If

        'If rdoHorarioSi.Checked Then '151020191816 Horario obligatorio

        If cmbHorario.SelectedIndex > 0 Then
            valida = True
            horario.DHorariosid = cmbHorario.SelectedValue
        Else
            valida = False
        End If

        If cmbHorario2.SelectedIndex > 0 Then
            'valida = True
            horario2.DHorariosid = cmbHorario2.SelectedValue
        Else
            'valida = False
        End If
        'Else
        '    valida = True
        'End If


        If valida Then ''Insertar por que hay minimo un campo lleno de la información laboral
            laboral.PNaveId = nave
            laboral.PDepartamentoId = depto
            laboral.PCelula = celula
            laboral.PPuestoId = puesto
            laboral.PHorarioId = horario
            laboral.PHorario2Id = horario2
            laboral.PColaboradorId = col
            laboral.PAreaID = cmbArea.SelectedValue
            laboral.PNIP = txtNIP.Text

            laboral.telefono = txtTelOficina.Text.Trim
            laboral.extencion = txtExtencion.Text.Trim
            If cmbJefeInmediato.SelectedIndex > 0 Then
                laboral.jefeInmediato = cmbJefeInmediato.Text.Trim
                laboral.jefeInmediatoid = cmbJefeInmediato.SelectedValue
            Else
                laboral.jefeInmediato = 0
                laboral.jefeInmediatoid = ""
            End If

            laboral.emailLaboral = txtEmailLaboral.Text.Trim

            If chkHorasExtras.Checked = True Then
                laboral.PGeneraHorasExtras = True
            Else
                laboral.PGeneraHorasExtras = False
            End If

            If rdoHorarioSi.Checked = True Then
                laboral.PCheca = True
            Else
                laboral.PCheca = False
            End If

            If rdoReportesSI.Checked = True Then
                laboral.PReporte = True
            Else
                laboral.PReporte = False
            End If
            If rdoGana.Checked = True Then
                laboral.PGanaIncentivos = True
            Else
                laboral.PGanaIncentivos = False
            End If

            'Nip Externo para Checar con Huella
            If TxtHuellaExterno.Text <> "" Then
                laboral.PhuellaExterno = CInt(TxtHuellaExterno.Text)
            Else
                laboral.PhuellaExterno = 0
            End If

            If rbLicenciaSi.Checked = True Then '' colaborador tiene licencia
                laboral.PTieneLicencia = True
                laboral.PNumLicencia = (txtFolioLicencia.Text)
                laboral.PFechaVigencia = dtpFechaVigente.Value
            Else
                laboral.PTieneLicencia = False
                laboral.PNumLicencia = (txtFolioLicencia.Text)
                laboral.PFechaVigencia = dtpFechaVigente.Value
            End If

            If LLaboral > 0 Then ''es un update de la información
                objLaboralBU.EditarColaboradorLaboral(laboral, colaboradorId)
            Else ''es insert
                objLaboralBU.guardarColaboradorLaboral(laboral)

            End If
            LLaboral = 1

        Else

        End If

    End Sub
    Public Sub GuardarColaboradorNomina(ByVal col As Entidades.Colaborador)

        Dim validacion As Boolean = True

        'If (cmbFormaPagoFiscal.SelectedIndex < 0 _
        '    Or txtSueldoFiscal.Text = "" _
        '    Or txtISR.Text = "" _
        '    Or cmbPatron.SelectedIndex < 0) Then
        '    validacion = False
        'End If
        'If ChkInfonavitSi.Checked = True Then
        '    'If cmbTipoInfonavit.Text = "" Then
        '    '    validacion = False
        '    '    lblTipo.ForeColor = Color.Red
        '    'Else
        '    '    validacion = True
        '    '    lblTipo.ForeColor = Color.Black
        '    'End If
        '    If txtMonto.Text.Length <= 0 Then
        '        validacion = False
        '        lblMonto.ForeColor = Color.Red
        '    Else
        '        validacion = True
        '        lblMonto.ForeColor = Color.Black
        '    End If
        'End If

        If validacion = True Then
            Dim cono As New Entidades.ColaboradorNomina
            cono.PColaborador = col
            'cono.PMontoISR = CDbl(txtISR.Text)
            cono.PFechaAltaImss = dtpFechaAltaSS.Value
            cono.PfechaAltaInfonavit = dtpFechaAltaInfonavit.Value
            If txtSueldoFiscal.Text = "" Then
                cono.PSalario = 0
            Else
                cono.PSalario = CDbl(txtSueldoFiscal.Text)
            End If

            cono.PFormaPago = cmbFormaPagoFiscal.SelectedItem
            cono.PNss = txtNSS.Text

            Dim patron As New Entidades.Patrones
            patron.Ppatronid = cmbPatron.SelectedValue
            cono.PPatron = patron
            cono.PNss = txtNSS.Text
            cono.PCPSAT = txtCPSAT.Text
            Dim objBU As New Negocios.ColaboradorNominaBU
            If ChkInfonavitSi.Checked = True Then
                cono.PInfonavit = True

                'If cmbTipoInfonavit.Text = "PORCENTAJE" Then
                '    cono.PInfonavitTipo = 1
                'ElseIf cmbTipoInfonavit.Text = "SALARIOS MINIMOS" Then
                '    cono.PInfonavitTipo = 2
                'ElseIf cmbTipoInfonavit.Text = "CUOTA FIJA" Then
                '    cono.PInfonavitTipo = 3
                'ElseIf cmbTipoInfonavit.Text = "CONTADORES" Then
                '    cono.PInfonavitTipo = 4
                'End If
                cono.PInfonavitTipo = 4
                cono.PInfonavitMonto = txtMonto.Text
                cono.PfechaAltaInfonavit = dtpFechaAltaInfonavit.Value.ToShortDateString
            Else
                cono.PInfonavit = False
            End If


            If cmbBanco.SelectedIndex > 0 Then

            Else

            End If
            'cono.PSalarioDiario = txtSueldoDiario.Text

            ''Agregado nomina fiscal
            If chkAsegurado.Checked = True Then
                cono.PAsegurado = True
            Else
                cono.PAsegurado = False
            End If

            If chkExterno.Checked = True Then
                cono.PExterno = True
            Else
                cono.PExterno = False
            End If


            If NNomina > 0 Then
                objBU.EditarColaboradorNomina(cono, colaboradorId)
            Else
                objBU.guardarColaboradorNomina(cono, cmbNave.SelectedValue, cmbPuesto.SelectedValue)
            End If
            NNomina = 1
        Else
        End If
    End Sub
    Public Sub GuardarColaboradorReal(ByVal col As Entidades.Colaborador)
        Dim inserta As Boolean = False
        If (cmbTipoNomina.SelectedIndex > 0) _
            Or cmbFormaPagoReal.SelectedIndex > 0 _
            Or txtSueldoReal.Text.Length > 0 Then
            inserta = True
        End If
        If inserta Then
            Dim objBu As New Negocios.ColaboradorRealBU
            Dim real As New Entidades.ColaboradorReal
            Dim ObjHistorialHorarios As New Negocios.HistorialSalarioBUvb
            real.PColaboradorId = col
            real.PTipo = cmbTipoNomina.SelectedItem
            real.PTipoPago = cmbFormaPagoReal.SelectedItem
            real.PFecha = dtpFechaIngreso.Value
            real.PCantidad = txtSueldoReal.Text
            If txtSueldoReal.Text <> txtSueldoRealRespaldo.Text Then
                cambioDeSalario = True
            End If
            real.PNumero = txtCuentaColaboradorReal.Text
            If txtCostoPartida.Text.Length > 0 Then
                real.PCostoFraccion = txtCostoPartida.Text
            End If

            If cmbBanco.SelectedIndex > 0 Then
                real.PBanco = cmbBanco.SelectedValue
            Else
            End If

            If SueldoDiario = True Then
                ObjHistorialHorarios.insertarSalarioDiario(colaboradorId, CDbl(txtSueldoReal.Text))
            End If

            If txtSueldoSemanalAguinaldo.Text <> "" Then
                real.PSueldoSemanalAguinaldo = txtSueldoSemanalAguinaldo.Text
            End If


            If AAdicional > 0 Then
                objBu.EditarColaboradorReal(real, colaboradorId)

            Else
                objBu.GuardarColaboradorReal(real)

                ''Código que agrega las faltas de un colaborador nuevo, de la fecha de ingreso a la fecha de inicio del periodo.

                If cmbNave.SelectedIndex > 0 Then
                    Dim objPeriodo As New Negocios.ControlDePeriodoBU
                    Dim dtidfechaperiodoActual As New DataTable
                    Dim entRangoPerdiodo As New Entidades.PeriodosNomina
                    Dim fechaperiodoActualInicio As Date = Date.Now
                    Dim idPeriodo As Int32 = 0
                    Dim diasDiferencia As Int32 = 0

                    dtidfechaperiodoActual = objPeriodo.periodoSegunNaveSegunAsistenciaActual(cmbNave.SelectedValue)
                    idPeriodo = dtidfechaperiodoActual.Rows(0).Item(0).ToString
                    entRangoPerdiodo = objPeriodo.buscarRangosPeriodoSegunNaveSegunAsistencia(idPeriodo)
                    fechaperiodoActualInicio = entRangoPerdiodo.PFechaInicio

                    diasDiferencia = DateDiff(DateInterval.Day, fechaperiodoActualInicio, dtpFechaIngreso.Value)
                    Dim fechaSeleccion As Date
                    Dim faltas As Int32 = 0
                    Dim cadenaFecha As String = ""

                    fechaSeleccion = dtpFechaIngreso.Value.ToShortDateString
                    fechaSeleccion = DateAdd(DateInterval.Day, -1, fechaSeleccion)

                    For i As Int32 = diasDiferencia - 1 To 0 Step -1
                        faltas = 0

                        cadenaFecha = fechaSeleccion.ToShortDateString + " 23:59:59.000"

                        If DatePart(DateInterval.Weekday, fechaSeleccion).ToString = "1" Then
                            faltas = 0
                        ElseIf DatePart(DateInterval.Weekday, fechaSeleccion).ToString = "7" Then
                            faltas = 1
                            objBu.insertarFaltaColaboradorNuevo(cmbNave.SelectedValue, cadenaFecha, col.PColaboradorid, 1)
                        Else
                            faltas = 2
                            objBu.insertarFaltaColaboradorNuevo(cmbNave.SelectedValue, cadenaFecha, col.PColaboradorid, 1)
                            objBu.insertarFaltaColaboradorNuevo(cmbNave.SelectedValue, cadenaFecha, col.PColaboradorid, 3)
                        End If
                        fechaSeleccion = DateAdd(DateInterval.Day, -1, fechaSeleccion)
                    Next
                End If

                ''Termina registro de faltas

            End If
            AAdicional = 1
        End If
    End Sub
    Private Sub btnCncelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCncelar.Click

        If MessageBox.Show("¿Realmente quiere cerrar la ventana?, los datos capturados se perderan al cerrrar", "Cerrar",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
       = DialogResult.Yes Then

            Me.Close()

        End If




    End Sub
    Private Sub tbGeneral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbGeneral.Click
        'grpNomina.Visible = False
        'MessageBox.Show(tbGeneral.SelectedTab.Name)
        'If (tbGeneral.SelectedTab.Name = "tbFiscal") Then
        '    Dim usuario As New TextDialogForm
        '    usuario.mensaje = "Ingrese su usuario"
        '    If (usuario.ShowDialog = DialogResult.OK) Then
        '        'MessageBox.Show(usuario.txtParam.Text)
        '        'Persistencia = usuario.txtParam.Text
        '    End If

        '    Dim pass As New SecretDialogForm
        '    pass.mensaje = "Ingrese su contraseña"
        '    If pass.ShowDialog = DialogResult.OK Then
        '        'MessageBox.Show(pass.txtParam.Text)
        '    End If
        'End If
        If (tbGeneral.SelectedTab.Name = "tbReferencias") Then

        End If
        If (tbGeneral.SelectedTab.Name = "TbAcademica") Then

        End If
        'If tbGeneral.SelectedIndex = 7 Then
        '    If (colaboradorId <= 0) Then
        '        Dim er As New AdvertenciaForm
        '        er.mensaje = "Debe guardar primero los datos generales del colaborador para poder agregar Archivos."
        '        er.MdiParent = Me.MdiParent
        '        er.Show()
        '        btnAgregarReferencia.Visible = False
        '        lblAgregarReferencia.Visible = False
        '        btnQuitarReferencia.Visible = False
        '        lblQuitarReferencia.Visible = False

        '    End If
        'End If

    End Sub

    Public Sub GuardarInformacionFamilia(ByVal ColaboradorId As Entidades.Colaborador)

        Dim objBU As New Negocios.ColaboradorReferenciasBU

        For vueltas = 0 To grdReferencias.Rows.Count()
            Dim referencias As New Entidades.ColaboradorReferencias
            Try
                If (grdReferencias.Rows(vueltas).Cells(0).Value <> "") Then
                    referencias.PColaboradorId = ColaboradorId
                    referencias.PNombre = grdReferencias.Rows(vueltas).Cells(0).Value
                    referencias.POcupacion = grdReferencias.Rows(vueltas).Cells(1).Value
                    referencias.PParentezco = grdReferencias.Rows(vueltas).Cells(2).Value
                    referencias.PTelefono = grdReferencias.Rows(vueltas).Cells(3).Value
                    'referencias.PFechaNacimiento = grdReferencias.Rows(vueltas).Cells(5).Value
                    SeleccionReferencia = grdReferencias.Rows(vueltas).Cells(4).Value
                    If grdReferencias.Rows(vueltas).Cells(4).Value <= 0 Then

                        objBU.AgregarColaboradorReferenciaId(referencias)

                    Else
                        objBU.EditarColaboradorReferenciaId(SeleccionReferencia, referencias)
                    End If
                End If

            Catch ex As Exception

            End Try
        Next
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarReferencia.Click
        If ValidarFamilia() Then
            If ValidarFamilia() Then


                If txtNombreReferencia.Text <> "" _
                    Or txtOcupacionReferencia.Text <> "" _
                    Or cmbParentezcoReferencia.Text <> "" Then

                    If IndexSeleccionado < 0 Then
                        grdReferencias.Rows.Add(txtNombreReferencia.Text.Trim(), txtOcupacionReferencia.Text.Trim(), cmbParentezcoReferencia.Text.Trim(),
                                            txtTelefonoReferencia.Text.Trim(), 0, dtpFechaNacimientoFamilia.Value.ToShortDateString.Trim(), (DateDiff("y", (CDate(dtpFechaNacimientoFamilia.Value.ToShortDateString)), Today)) \ 365)
                    Else
                        grdReferencias.Rows(IndexSeleccionado).Cells(0).Value = txtNombreReferencia.Text
                        grdReferencias.Rows(IndexSeleccionado).Cells(1).Value = txtOcupacionReferencia.Text
                        grdReferencias.Rows(IndexSeleccionado).Cells(2).Value = cmbParentezcoReferencia.Text

                        grdReferencias.Rows(IndexSeleccionado).Cells(3).Value = txtTelefonoReferencia.Text
                        grdReferencias.Rows(IndexSeleccionado).Cells(4).Value = SeleccionReferencia
                        grdReferencias.Rows(IndexSeleccionado).Cells(5).Value = dtpFechaNacimientoFamilia.Value.ToShortDateString
                        grdReferencias.Rows(IndexSeleccionado).Cells(6).Value = (DateDiff("y", (CDate(grdReferencias.Rows(IndexSeleccionado).Cells(5).Value)), Today)) \ 365
                        IndexSeleccionado = -1
                    End If
                    txtNombreReferencia.Text = ""
                    txtOcupacionReferencia.Text = ""
                    cmbParentezcoReferencia.Text = ""
                    txtTelefonoReferencia.Text = ""
                    cmbParentezcoReferencia.SelectedItem = " "
                    lblAgregarReferencia.Text = "Agregar"
                    dtpFechaNacimientoFamilia.Value = Today
                    'grdReferencias.Rows.Clear()
                    ' CargarColaboradorReferencias()
                End If

            End If

        End If

    End Sub
    Private Sub CargarColaboradorAcademica()

        btnAgregarAcademica.Visible = True
        btnQuitarAcademica.Visible = True
        lblAgregarAcademica.Visible = True
        lblQuitarAcademica.Visible = True
        Dim objBU As New Negocios.ColaboradorAcademicoBU
        Dim lista As New List(Of Entidades.AcademicosColaborador)
        lista = objBU.ListaColaboradorAcademica(colaboradorId)
        For Each Academica As Entidades.AcademicosColaborador In lista
            Dim celda As DataGridViewCell
            Dim fila As New DataGridViewRow


            celda = New DataGridViewTextBoxCell
            celda.Value = Academica.PNombreEscuela
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = Academica.PCarrera
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = Academica.PAnioInicio
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = Academica.PAnioTermino
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = Academica.PEstado
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = Academica.PAcademicaId
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = Academica.PGrado
            fila.Cells.Add(celda)

            grdAcademica.Rows.Add(fila)
        Next




    End Sub
    Private Sub CargarColaboradorReferencias()
        'If (colaboradorId <= 0) Then
        '    Dim er As New AdvertenciaForm
        '    er.mensaje = "Debe guardar primero los datos generales del colaborador para poder agregar referencias."
        '    er.MdiParent = Me.MdiParent
        '    er.Show()
        '    btnAgregarReferencia.Visible = False
        '    lblAgregarReferencia.Visible = False
        '    btnQuitarReferencia.Visible = False
        '    lblQuitarReferencia.Visible = False
        'Else
        btnAgregarReferencia.Visible = True
        lblAgregarReferencia.Visible = True
        btnQuitarReferencia.Visible = True
        lblQuitarReferencia.Visible = True

        Dim objBU As New Negocios.ColaboradorReferenciasBU
        Dim lista As New List(Of Entidades.ColaboradorReferencias)
        lista = objBU.ListaColaboradorReferencias(colaboradorId)
        For Each referencia As Entidades.ColaboradorReferencias In lista
            Dim celda As DataGridViewCell
            Dim fila As New DataGridViewRow


            celda = New DataGridViewTextBoxCell
            celda.Value = referencia.PNombre
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = referencia.POcupacion
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = referencia.PParentezco
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = referencia.PTelefono
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = referencia.PColaboradorReferenciaId
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            If referencia.PFechaNacimiento = CDate("01/01/0001") Then
                celda.Value = " "
            Else
                celda.Value = referencia.PFechaNacimiento.ToShortDateString
            End If

            fila.Cells.Add(celda)



            celda = New DataGridViewTextBoxCell

            If referencia.PFechaNacimiento = CDate("01/01/0001") Then
                celda.Value = " "
            Else
                celda.Value = (DateDiff("y", referencia.PFechaNacimiento.ToShortDateString, Date.Today)) \ 365
            End If


            fila.Cells.Add(celda)
            grdReferencias.Rows.Add(fila)
        Next
        'End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarReferencia.Click


        If MessageBox.Show("¿Realmente quiere Eliminar la Referencia?", "Eliminar",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
         = DialogResult.Yes Then
            Dim objBU As New Negocios.ColaboradorReferenciasBU

            objBU.EliminarColaboradorReferenciaId(SeleccionReferencia)

            grdReferencias.Rows.Clear()
            CargarColaboradorReferencias()
        End If






    End Sub
    Private Sub grdReferencias_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdReferencias.CellClick


    End Sub



    Public Sub GuardarInformacionAcademicaColaborador(ByVal colaborador As Entidades.Colaborador)
        Dim objBU As New Negocios.ColaboradorAcademicoBU
        Dim Academicas As New Entidades.AcademicosColaborador

        For vueltas = 0 To grdAcademica.Rows.Count()
            Try
                Academicas.PColaboradorId = colaborador
                Academicas.PNombreEscuela = grdAcademica.Rows(vueltas).Cells(0).Value
                If grdAcademica.Rows(vueltas).Cells(3).Value Is Nothing Then
                    Academicas.PAnioTermino = 0
                Else
                    Academicas.PAnioTermino = grdAcademica.Rows(vueltas).Cells(3).Value
                End If
                Academicas.PAnioInicio = grdAcademica.Rows(vueltas).Cells(2).Value

                Academicas.PCarrera = grdAcademica.Rows(vueltas).Cells(1).Value
                Academicas.PEstado = grdAcademica.Rows(vueltas).Cells(4).Value
                Academicas.PGrado = grdAcademica.Rows(vueltas).Cells(6).Value

                If grdAcademica.Rows(vueltas).Cells(5).Value <= 0 Then
                    objBU.AgregarInformacionAcademica(Academicas, colaboradorId)
                Else
                    objBU.EditarInformacionAcademica(Academicas, grdAcademica.Rows(vueltas).Cells(5).Value)

                End If


            Catch ex As Exception

            End Try
        Next

    End Sub



    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarAcademica.Click
        If ValidarAcademica() Then


            If txtEscuela.Text <> "" _
        Or txtCarrera.Text <> "" _
        Or txtAnioInicio.Text <> "" _
        Or txtAnioFin.Text <> "" _
        Or cmbEstado.Text <> "" _
        Or cmbGrado.Text <> "" Then

                If IndexAcademica < 0 Then
                    grdAcademica.Rows.Add(txtEscuela.Text.Trim(), txtCarrera.Text.Trim(), txtAnioInicio.Text.Trim(),
                                    txtAnioFin.Text.Trim(), cmbEstado.Text.Trim(), 0, cmbGrado.Text.Trim())
                Else
                    grdAcademica.Rows(IndexAcademica).Cells(0).Value = txtEscuela.Text
                    grdAcademica.Rows(IndexAcademica).Cells(1).Value = txtCarrera.Text
                    grdAcademica.Rows(IndexAcademica).Cells(2).Value = txtAnioInicio.Text

                    grdAcademica.Rows(IndexAcademica).Cells(3).Value = txtAnioFin.Text
                    grdAcademica.Rows(IndexAcademica).Cells(4).Value = cmbEstado.Text
                    grdAcademica.Rows(IndexAcademica).Cells(5).Value = IdAcademica
                    grdAcademica.Rows(IndexAcademica).Cells(6).Value = cmbGrado.Text
                End If












                'Academicas.PColaboradorId = colaborador
                'Academicas.PNombreEscuela = txtEscuela.Text
                'If txtAnioFin.Text = "" Then
                '    Academicas.PAnioTermino = 0
                'Else
                '    Academicas.PAnioTermino = txtAnioFin.Text
                'End If
                'Academicas.PAnioInicio = txtAnioInicio.Text

                'Academicas.PCarrera = txtCarrera.Text
                'Academicas.PEstado = cmbEstado.Text
                'Academicas.PGrado = cmbGrado.Text

                'If IdAcademica <= 0 Then
                '    objBU.AgregarInformacionAcademica(Academicas, colaboradorId)
                'Else
                '    objBU.EditarInformacionAcademica(Academicas, IdAcademica)
                '    IdAcademica = 0
                'End If



                txtEscuela.Text = ""
                txtAnioInicio.Text = ""
                txtAnioFin.Text = ""
                txtCarrera.Text = ""
                cmbEstado.SelectedItem = ""
                cmbGrado.SelectedItem = ""
                lblAgregarAcademica.Text = "  Agregar"
                'grdAcademica.Rows.Clear()
                'CargarColaboradorAcademica()
            End If


        End If





    End Sub
    Private Sub CargarDatosGenerales()

        If colaboradorId > 0 Then
            Dim ObjBU As New Nomina.Negocios.ColaboradorLaboralBU


            Dim Datos As New Entidades.Colaborador
            Datos = ObjBU.BuscarCalaboradorDatos(colaboradorId)
            txtNombreColaborador.Text = Datos.PNombre
            txtAPaternoColaborador.Text = Datos.PApaterno
            txtAMaternoColaborador.Text = Datos.PAmaterno
            txtCurp.Text = Datos.pCurp
            txtRfc.Text = Datos.PRfc
            cmbEstadoCivil.Text = Datos.PEstadoCivil
            txtCalleColaborador.Text = Datos.PCalle
            txtNumeroColaborador.Text = Datos.Pnumero
            txtColoniaColaborador.Text = Datos.Pcolonia
            txtCurp.Text = Datos.pCurp
            txtTelefonoCasa.Text = Datos.PTelefonoCasa
            txtTelefonoCelular.Text = Datos.PTelefonoCel
            txtEmail.Text = Datos.PEmail
            txtCPColaborador.Text = Datos.PCP
            cmbEstadoCiudad.SelectedValue = Datos.PCiudad.CIDEstado.EIDDEstado
            cmbCiudadColaborador.SelectedValue = Datos.PCiudad.CciudadId
            txtEntreCalles.Text = Datos.PEntreCalles
            txtReferencias.Text = Datos.PReferencia

            txtClaveElector.Text = Datos.PClaveElector
            cmbSexo.Text = Datos.PSexo
            dtpNacimiento.Value = Datos.PFechaNacimiento
            txtNombreCorto.Text = Datos.PNombreCorto

            Try
                cmbEstadoOrigen.SelectedValue = Datos.PCiudadOrigen.CIDEstado.EIDDEstado
            Catch ex As Exception

            End Try

            Try
                cmbCiudadOrigen.SelectedValue = Datos.PCiudadOrigen.CciudadId
            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Sub CargarDatosNomina()

        If (NNomina > 0) Then

            Dim ObjBU As New Negocios.ColaboradorNominaBU
            Dim Nomina As New Entidades.ColaboradorNomina
            Dim NominaReal As New Negocios.ColaboradorRealBU
            Dim NominaRealEntidad As New Entidades.ColaboradorReal
            Nomina = ObjBU.buscarColaborarNomina(colaboradorId)
            NominaRealEntidad = NominaReal.BuscarColaboradorReal(colaboradorId)
            txtSueldoFiscal.Text = Nomina.PSalario
            txtISR.Text = Nomina.PMontoISR 'campo isr
            dtpFechaAltaSS.Value = Nomina.PFechaAltaImss

            cmbPatron.SelectedValue = Nomina.PPatron.Ppatronid
            cmbFormaPagoFiscal.Text = Nomina.PFormaPago
            txtNSS.Text = Nomina.PNss
            txtSueldoDiario.Text = Nomina.PSalarioDiario
            txtCPSAT.Text = Nomina.PCPSAT

            If NominaRealEntidad.PSueldoSemanalAguinaldo > 0 Then
                txtSueldoSemanalAguinaldo.Text = NominaRealEntidad.PSueldoSemanalAguinaldo
            End If


            ChkInfonavitSi.Checked = Nomina.PInfonavit

            chkAsegurado.Checked = Nomina.PAsegurado
            chkExterno.Checked = Nomina.PExterno

            If ChkInfonavitSi.Checked = True Then
                lblTipo.Visible = True
                'cmbTipoInfonavit.Visible = True
                lblTipoInfonavit.Visible = True
                lblMonto.Visible = True
                txtMonto.Visible = True
            End If

            'If Nomina.PInfonavitTipo = 1 Then
            '    cmbTipoInfonavit.Text = "Porcentaje"
            'End If
            'If Nomina.PInfonavitTipo = 2 Then
            '    cmbTipoInfonavit.Text = "Salarios Minimos"
            'End If
            'If Nomina.PInfonavitTipo = 3 Then
            '    cmbTipoInfonavit.Text = "Cuota Fija"
            'End If

            'If Nomina.PInfonavitTipo = 4 Then
            '    cmbTipoInfonavit.Text = "Contadores"
            'End If
            Nomina.PInfonavitTipo = 4
            If Nomina.PInfonavitMonto > 0 Then
                txtMonto.Text = Nomina.PInfonavitMonto
            Else

            End If
            Try
                dtpFechaAltaInfonavit.Value = Nomina.PfechaAltaInfonavit
            Catch ex As Exception

            End Try


        End If

    End Sub
    Private Sub CargarInformacionLaboral()


        If (LLaboral > 0) Then

            Dim objBU As New Negocios.ColaboradorLaboralBU
            Dim DatosLaborales As New Entidades.ColaboradorLaboral

            DatosLaborales = objBU.buscarInformacionLaboral(colaboradorId)

            cmbNave.SelectedValue = DatosLaborales.PNaveId.PNaveId
            cmbArea.SelectedValue = DatosLaborales.PAreaID
            cmbDepartamento.SelectedValue = DatosLaborales.PDepartamentoId.Ddepartamentoid
            Try
                If Not DatosLaborales.PCelula Is Nothing Then
                    cmbCelula.SelectedValue = DatosLaborales.PCelula.PCelulaid
                End If
            Catch ex As Exception

            End Try
            Try
                txtTelOficina.Text = DatosLaborales.telefono
                txtExtencion.Text = DatosLaborales.extencion
                txtEmailLaboral.Text = DatosLaborales.emailLaboral
                cmbJefeInmediato.DataSource = objBU.getColaboradoresDepartamento(DatosLaborales.PDepartamentoId.Ddepartamentoid, DatosLaborales.PNaveId.PNaveId)
                cmbJefeInmediato.DisplayMember = "colaborador"
                cmbJefeInmediato.ValueMember = "id"
                cmbJefeInmediato.SelectedValue = DatosLaborales.jefeInmediatoid
                TxtHuellaExterno.Text = DatosLaborales.PhuellaExterno
            Catch ex As Exception

            End Try
            If DatosLaborales.PCheca = True Then
                rdoHorarioSi.Checked = True
            Else
                rdoHorarioNo.Checked = True
            End If
            If DatosLaborales.PReporte = True Then
                rdoReportesSI.Checked = True
            Else
                rdoReportesNo.Checked = True
            End If
            If DatosLaborales.PGanaIncentivos = True Then
                rdoGana.Checked = True
            Else
                rdoNoGana.Checked = True
            End If
            If Not DatosLaborales.PPuestoId Is Nothing Then
                cmbPuesto.SelectedValue = DatosLaborales.PPuestoId.Ppuestosid
            End If

            cmbHorario.SelectedValue = DatosLaborales.PHorarioId.DHorariosid
            If Not IsNothing(DatosLaborales.PHorario2Id) Then
                cmbHorario2.SelectedValue = DatosLaborales.PHorario2Id.DHorariosid
            End If
            txtNIP.Text = DatosLaborales.PNIP
            chkHorasExtras.Checked = DatosLaborales.PGeneraHorasExtras
            txtFolioLicencia.Text = DatosLaborales.PNumLicencia
            If DatosLaborales.PFechaVigencia <> #1/1/0001 12:00:00 AM# Then
                dtpFechaVigente.Value = DatosLaborales.PFechaVigencia
            End If

            If DatosLaborales.PTieneLicencia = True Then
                rbLicenciaSi.Checked = True
            Else
                rbLicenciaNo.Checked = True
                txtFolioLicencia.Enabled = False
                dtpFechaVigente.Enabled = False
            End If
        End If

    End Sub
    Public Sub CargarInformacionMedica()
        If (MMedica > 0) Then
            Dim ObjBU As New Negocios.ColaboradorMedicaBU
            Dim DatosMedicos As New Entidades.ColaboradorMedica
            DatosMedicos = ObjBU.buscarColaborarMedica(colaboradorId)
            txtTipoSanguineo.Text = DatosMedicos.PTipoSanguineo
            txtContactoEmergencias.Text = DatosMedicos.PContactoEmergencias
            txtTelefonoEmergencias.Text = DatosMedicos.PTelefonoEmergencias
            txtConsideracionesEspeciales.Text = DatosMedicos.PComentarios
        End If
    End Sub
    Public Sub CargarInformacionAdiconal()
        If (AAdicional > 0) Then
            Dim ObjBU As New Negocios.ColaboradorRealBU
            Dim DatosReales As New Entidades.ColaboradorReal
            DatosReales = ObjBU.BuscarColaboradorReal(colaboradorId)
            cmbTipoNomina.Text = DatosReales.PTipoPago
            cmbFormaPagoReal.Text = DatosReales.PTipo
            txtSueldoReal.Text = DatosReales.PCantidad
            txtSueldoRealRespaldo.Text = DatosReales.PCantidad
            txtCuentaColaboradorReal.Text = DatosReales.PNumero
            dtpFechaIngreso.Value = DatosReales.PFecha
            cmbBanco.SelectedValue = DatosReales.PBanco
            If DatosReales.PCostoFraccion > 0 Then

                cmbTipoNomina.Text = "POR BANDA"
                txtCostoPartida.Text = DatosReales.PCostoFraccion
            End If
        End If



    End Sub
    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        OPFAbrirArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        OPFAbrirArchivo.Filter = "JPEG, PDF, DOC, DOCX, XLS, XLSX, PNG, GIF|*.pdf;*.jpg; *.doc; *.docx;*.xls; *.png;*.gif"
        OPFAbrirArchivo.FilterIndex = 3
        OPFAbrirArchivo.ShowDialog()
        archivo = OPFAbrirArchivo.FileName

        Dim tabla() As String
        tabla = Split(archivo, "\")

        For n = 0 To UBound(tabla, 1)

            If UBound(tabla) = n Then
                Archivos.PNombreArchivo = tabla(n)

            End If

        Next
    End Sub

    Public Sub InsertarArchivo(ByVal ColaboradorId As Int32)
        Dim RutaTmp As String = String.Empty
        Dim CarpetaDestino As String = "Imagenes/" + ColaboradorId.ToString

        Archivos.PCarpeta = CarpetaDestino

        For vueltas = 0 To grdArchivos.Rows.Count - 1
            Archivos.Ptitulo = grdArchivos.Rows(vueltas).Cells(1).Value
            Archivos.PCredencial = grdArchivos.Rows(vueltas).Cells(3).Value

            If Not IsNothing(grdArchivos.Rows(vueltas).Cells(5).Value) Then
                Dim objEnvioArchivos As New Negocios.EnviodeArchivosBU
                Dim objFTP As New Tools.TransferenciaFTP
                Dim archivo As String = grdArchivos.Rows(vueltas).Cells(5).Value

                objEnvioArchivos.EnvioArchivoBD(Archivos, ColaboradorId, grdArchivos.Rows(vueltas).Cells(0).Value)

                'Si es credencial de colaborador redimensiona la imagen

                'Dim checBoxColoaborador As Boolean = grdArchivos.Rows(vueltas).Cells(3).Value

                ' Console.WriteLine("Valor del checbox:")
                'Console.WriteLine(checBoxColoaborador)




                objFTP.EnviarArchivo(CarpetaDestino, archivo)

                If String.IsNullOrEmpty(RutaTmp) = False AndAlso System.IO.Directory.Exists(RutaTmp) Then
                    System.IO.Directory.Delete(RutaTmp, True)
                End If



            End If

        Next

    End Sub



    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

        If archivo.Length > 0 Then
            Dim validacion As Boolean = False
            For vueltas = 0 To grdArchivos.Rows.Count - 1

                If (grdArchivos.Rows(vueltas).Cells(3).Value = True) Then
                    validacion = True
                End If
            Next

            'If txtTituloArchivo.Text.Length <= 0 Then


            'Else
            If chkCredencial.Checked = True Then
                If validacion = False Then
                    grdArchivos.Rows.Add(Archivos.PNombreArchivo, txtTituloArchivo.Text, "", True, "", archivo)
                    txtTituloArchivo.Text = String.Empty
                    chkCredencial.Checked = False
                    archivo = String.Empty
                    OPFAbrirArchivo.Reset()
                Else
                    Dim Advertencia As New AdvertenciaForm
                    Advertencia.mensaje = "Ya agregó una foto para el colaborador"
                    Advertencia.MdiParent = Me.MdiParent
                    Advertencia.Show()
                    txtTituloArchivo.Text = ""
                End If
            Else
                grdArchivos.Rows.Add(Archivos.PNombreArchivo, txtTituloArchivo.Text, "", False, "", archivo)
                txtTituloArchivo.Text = String.Empty
                chkCredencial.Checked = False
                archivo = String.Empty
                OPFAbrirArchivo.Reset()
            End If


            archivo = ""
            'End If



        Else
            Dim Advertencia As New AdvertenciaForm
            Advertencia.mensaje = "Seleccione el archivo a Enviar"
            Advertencia.MdiParent = Me.MdiParent
            Advertencia.Show()
        End If
        'Dim objBU As New Negocios.EnviodeArchivosBU
        'Dim lista As New List(Of Entidades.ColaboradorExpediente)
        'lista = objBU.ListaColaboradorArchivos(colaboradorId)

        'grdArchivos.Rows.Clear()
        ''grdReferencias
        'CargarColaboradorArchivos()
        'Try
        '    If chkCredencial.Checked = True Then
        '        If Credenciales = False Then

        '            InsertarArchivo()

        '        Else
        '            Dim Advertencia As New AdvertenciaForm
        '            Advertencia.mensaje = "El colaborador ya cuenta con una Credencial"
        '            Advertencia.MdiParent = Me.MdiParent
        '            Advertencia.Show()

        '        End If

        '    Else
        '        InsertarArchivo()
        '    End If
        'Catch ex As Exception
        '    Dim Advertencia As New AdvertenciaForm
        '    Advertencia.mensaje = "Seleccione primero un colaborador"
        '    Advertencia.MdiParent = Me.MdiParent
        '    Advertencia.Show()
        'End Try

        'grdArchivos.Rows.Clear()
        'CargarColaboradorArchivos()





    End Sub
    Public Sub ValidarUpdatesOrInserts(ByVal colaboradorid As Int32)

        Dim ObjNomina As New Negocios.ColaboradorNominaBU
        Dim CountNomina As New Int32
        CountNomina = ObjNomina.ValidacionInsertUpdateNomina(colaboradorid)
        If CountNomina = 0 Then


        Else
            NNomina = 1
        End If

        Dim objLaboral As New Negocios.ColaboradorLaboralBU
        Dim CountLaboral As New Int32
        CountLaboral = objLaboral.ValidarLaboral(colaboradorid)
        If CountLaboral = 0 Then

        Else
            LLaboral = 1
        End If

        Dim ObjMedica As New Negocios.ColaboradorMedicaBU
        Dim CountMedica As Int32
        CountMedica = ObjMedica.ValidarUpdateOrInsertMedica(colaboradorid)
        If CountMedica = 0 Then

        Else
            MMedica = 1
        End If

        Dim ObjReal As New Negocios.ColaboradorRealBU

        Dim CountReal As Int32
        CountReal = ObjReal.ValidarUpdateOrInsertReal(colaboradorid)
        If CountReal = 0 Then
        Else
            AAdicional = 1
        End If


    End Sub
    Private Sub CargarColaboradorArchivos()
        'If (colaboradorId <= 0) Then
        '    Dim er As New AdvertenciaForm
        '    er.mensaje = "Debe guardar primero los datos generales del colaborador para poder agregar Archivos."
        '    er.MdiParent = Me.MdiParent
        '    er.Show()
        '    btnAgregarReferencia.Visible = False
        '    lblAgregarReferencia.Visible = False
        '    btnQuitarReferencia.Visible = False
        '    lblQuitarReferencia.Visible = False
        'Else
        Try

            Dim objBU As New Negocios.EnviodeArchivosBU
            Dim lista As New List(Of Entidades.ColaboradorExpediente)
            lista = objBU.ListaColaboradorArchivos(colaboradorId)
            For Each Archivo As Entidades.ColaboradorExpediente In lista
                Dim celda As DataGridViewCell
                Dim fila As New DataGridViewRow


                celda = New DataGridViewTextBoxCell
                celda.Value = Archivo.PNombreArchivo
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Archivo.Ptitulo
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Archivo.PCarpeta
                fila.Cells.Add(celda)

                celda = New DataGridViewCheckBoxCell
                celda.Value = Archivo.PCredencial
                If Archivo.PCredencial = True Then
                    Credenciales = True
                End If
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Archivo.PArchivoId
                fila.Cells.Add(celda)



                'celda = New DataGridViewTextBoxCell
                'celda.Value = referencia.PColaboradorReferenciaId
                'fila.Cells.Add(celda)

                grdArchivos.Rows.Add(fila)
            Next
        Catch ex As Exception

        End Try
        'End If
    End Sub
    Private Sub grdArchivos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdArchivos.CellDoubleClick



        Dim objTransferencias As New Tools.TransferenciaFTP
        Dim objFTP As New Tools.TransferenciaFTP
        SAVArchivo.RestoreDirectory = True
        SAVArchivo.Title = "Guardar en:"

        SAVArchivo.Filter = "JPEG|*.jpg"

        SAVArchivo.FileName = CStr(grdArchivos.Rows(e.RowIndex).Cells(0).Value)
        Dim tabla() As String
        If SAVArchivo.ShowDialog = Windows.Forms.DialogResult.OK Then

            tabla = Split(SAVArchivo.FileName, "\")
            Dim Rutaguardar As String = ""
            For n = 0 To UBound(tabla, 1)
                If UBound(tabla) = n Then
                Else
                    Rutaguardar += tabla(n) + "\"
                End If
            Next

            Dim Origen As String = ""
            Origen += CStr(grdArchivos.Rows(e.RowIndex).Cells(2).Value)
            objFTP.DescargarArchivo(Origen, Rutaguardar, CStr(grdArchivos.Rows(e.RowIndex).Cells(0).Value))

        End If







    End Sub

    Private Sub txtNombreColaborador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreColaborador.KeyPress
        'If Not Char.IsDigit(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsSymbol(e.KeyChar) Then
        '    e.Handled = True
        'Else
        '    e.Handled = True
        'End If

        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            txtNombreColaborador.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If

    End Sub

    Private Sub txtAPaternoColaborador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAPaternoColaborador.KeyPress
        'If Not Char.IsDigit(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsSymbol(e.KeyChar) Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            txtAPaternoColaborador.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub txtAMaternoColaborador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAMaternoColaborador.KeyPress
        'If Not Char.IsDigit(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsSymbol(e.KeyChar) Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            txtAMaternoColaborador.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub txtCurp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCurp.KeyPress

        If Char.IsSymbol(e.KeyChar) Then
            e.Handled = False

        End If

        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            txtCurp.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub txtRfc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRfc.KeyPress



        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            txtRfc.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub txtCalleColaborador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCalleColaborador.KeyPress

        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            txtCalleColaborador.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub



    Private Sub txtColoniaColaborador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtColoniaColaborador.KeyPress


        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            txtColoniaColaborador.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub txtNSS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNSS.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCuentaColaboradorFiscal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtSueldoFiscal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSueldoFiscal.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtNombreReferencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreReferencia.KeyPress
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            txtNombreReferencia.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub txtEscuela_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEscuela.KeyPress


        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            txtEscuela.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub txtCarrera_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCarrera.KeyPress
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            txtCarrera.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub txtAnioInicio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAnioInicio.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtAnioFin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAnioFin.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtSueldoReal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSueldoReal.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCuentaColaboradorReal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuentaColaboradorReal.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
        If cmbNave.SelectedIndex > 0 Then
            Dim objNavCon As New Negocios.ConfiguracionNaveNominaBU

            If cmbNave.Text = "COMERCIALIZADORA" Or cmbNave.Text = "ARYBA" Or cmbNave.Text = "VILLAGONTI" Then
                TbAcademica.Parent = tbGeneral
                tbReferencias.Parent = tbGeneral
            Else
                TbAcademica.Parent = Nothing
                tbReferencias.Parent = Nothing
            End If

            If cmbNave.Text = "COMERCIALIZADORA" Or cmbNave.Text = "ARYBA" Or cmbNave.Text = "VILLAGONTI" Then 'cmbNave.Text = "JEANS" Or 
                lblGanaIncentivos.Visible = False
                Panel2.Visible = False
                rdoGana.Checked = False
                rdoNoGana.Checked = True
            Else
                lblGanaIncentivos.Visible = True
                Panel2.Visible = True
                rdoGana.Checked = True
                rdoNoGana.Checked = False
            End If

            If PermisosUsuarioBU.ConsultarPermiso("NOM_NVO_CONTROL_ASISTENCIA", "NOM_IMPORTARREGISTROS") Then
                lblHuellaExterno.Visible = True
                TxtHuellaExterno.Visible = True
            Else
                lblHuellaExterno.Visible = False
                TxtHuellaExterno.Visible = False
            End If




            cmbArea = Controles.ComboAreasSegunNaves(cmbArea, cmbNave.SelectedValue)
            cmbArea.SelectedIndex = 0
            If colaboradorId <= 0 Then
                Dim objPeriodo As New Negocios.ControlDePeriodoBU
                Dim dtidfechaperiodoActual As New DataTable
                Dim entRangoPerdiodo As New Entidades.PeriodosNomina
                Dim fechaperiodoActualInicio As Date = Date.Now
                Dim idPeriodo As Int32 = 0
                dtidfechaperiodoActual = objPeriodo.periodoSegunNaveSegunAsistenciaActual(cmbNave.SelectedValue)
                Try
                    idPeriodo = dtidfechaperiodoActual.Rows(0).Item(0).ToString
                    entRangoPerdiodo = objPeriodo.buscarRangosPeriodoSegunNaveSegunAsistencia(idPeriodo)
                    dtpFechaIngreso.MinDate = entRangoPerdiodo.PFechaInicio.ToShortDateString
                Catch ex As Exception
                    dtpFechaIngreso.MinDate = Date.Now
                End Try
                dtpFechaIngreso.Enabled = True
            End If

        Else
            If colaboradorId <= 0 Then
                dtpFechaIngreso.Enabled = False
            End If
        End If
    End Sub


    Private Sub cmbDepartamento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDepartamento.SelectedIndexChanged
        If cmbDepartamento.SelectedIndex > 0 Then
            cmbPuesto = Controles.ComboPuestosSegunDepartamento(cmbPuesto, cmbDepartamento.SelectedValue)
            cmbCelula = Controles.ComboCelulasSegunDepartamento(cmbCelula, cmbDepartamento.SelectedValue)

            Dim objBU As New Nomina.Negocios.ColaboradorLaboralBU
            cmbJefeInmediato.DataSource = objBU.getColaboradoresDepartamento(cmbDepartamento.SelectedValue, cmbNave.SelectedValue)
            cmbJefeInmediato.DisplayMember = "colaborador"
            cmbJefeInmediato.ValueMember = "id"
        Else
            ''If Not cmbPuesto.DataSource Is Nothing Then
            ''    cmbPuesto.SelectedIndex = 0
            ''End If
            ''If Not cmbCelula.DataSource Is Nothing Then
            ''    cmbCelula.SelectedIndex = 0
            ''End If

            cmbPuesto.DataSource = Nothing
            cmbCelula.DataSource = Nothing

        End If
    End Sub


    Private Sub Button1_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarArchivo.Click




        If MessageBox.Show("¿Realmente quiere eliminar el archivo?", "Eliminar",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
        = DialogResult.Yes Then

            For Each row As DataGridViewRow In grdArchivos.SelectedRows
                For Each cell As DataGridViewCell In row.Cells
                    If (cell.OwningColumn.Name = "Id") Then
                        Try
                            Dim objExpedienteBU As New Negocios.EnviodeArchivosBU
                            objExpedienteBU.EliminarArchivoBD(CInt(cell.Value))


                            grdArchivos.Rows.Clear()
                            CargarColaboradorArchivos()
                        Catch ex As Exception
                            'Dim seleccion As Int32
                            'seleccion = grdArchivos.CurrentRow.Index
                            grdArchivos.Rows.RemoveAt(grdArchivos.CurrentRow.Index)
                        End Try


                        Dim exito As New ExitoForm
                        exito.mensaje = "Archivo eliminado"
                        'exito.MdiParent = Me.MdiParent
                        exito.ShowDialog()

                    End If
                    If cell.OwningColumn.Name = "Credencial" Then
                        If cell.Value = True Then
                            Credenciales = False
                        End If
                    End If
                Next
            Next

        End If
    End Sub

    Private Sub btnQuitarAcademica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarAcademica.Click

        If MessageBox.Show("¿Realmente quiere eliminar la informacion?", "Eliminar",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
        = DialogResult.Yes Then

            For Each row As DataGridViewRow In grdAcademica.SelectedRows
                For Each cell As DataGridViewCell In row.Cells
                    If (cell.OwningColumn.Name = "colId") Then
                        Dim objAcademicaBU As New Negocios.ColaboradorAcademicoBU
                        objAcademicaBU.EliminarInformacionAcademica(CInt(cell.Value))

                        grdAcademica.Rows.Clear()
                        CargarColaboradorAcademica()

                        Dim exito As New ExitoForm
                        exito.mensaje = "Registro Eliminado"
                        exito.MdiParent = Me.MdiParent
                        exito.Show()

                    End If
                Next
            Next
        End If
    End Sub

    Private Sub txtCurp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCurp.LostFocus
        If colaboradorId = 0 Then
            Dim objBU As New Negocios.ColaboradoresBU
            Dim valida As String = ""
            valida = objBU.ValidarCurp(txtCurp.Text)
            If valida.Length > 0 Then

                If MessageBox.Show(valida + " ¿Desea ver la informacion?", "Eliminar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                = DialogResult.Yes Then
                    CargarInformacionDeCurpExistente()
                Else
                    PictureBox1.Visible = True
                End If
            End If
        End If

        txtCurp.Text = txtCurp.Text.Replace("-", "")
        txtCurp.Text = txtCurp.Text.Replace(" ", "")
    End Sub


    Public Sub CargarInformacionDeCurpExistente()
        Dim EnviarCurp As New ListaColaboradoresPorCURP
        EnviarCurp.PCurp = txtCurp.Text
        EnviarCurp.MdiParent = MdiParent
        EnviarCurp.Show()
    End Sub

    Private Sub grdReferencias_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdReferencias.CellDoubleClick
        If e.RowIndex >= 0 Then
            If (grdReferencias.Rows(e.RowIndex).Cells(0).Value) <> "" Then
                SeleccionReferencia = grdReferencias.Rows(e.RowIndex).Cells(4).Value
                IndexSeleccionado = e.RowIndex
            End If
        End If
        If e.RowIndex >= 0 Then

            If (grdReferencias.Rows(e.RowIndex).Cells(0).Value) <> "" Then
                SeleccionReferencia = CInt(grdReferencias.Rows(e.RowIndex).Cells(4).Value)
                txtNombreReferencia.Text = CStr(grdReferencias.Rows(e.RowIndex).Cells(0).Value)
                txtOcupacionReferencia.Text = CStr(grdReferencias.Rows(e.RowIndex).Cells(1).Value)
                cmbParentezcoReferencia.Text = CStr(grdReferencias.Rows(e.RowIndex).Cells(2).Value)
                txtTelefonoReferencia.Text = CStr(grdReferencias.Rows(e.RowIndex).Cells(3).Value)
                'dtpFechaNacimientoFamilia.Value = CDate(grdReferencias.Rows(e.RowIndex).Cells(5).Value)
                IndexSeleccionado = e.RowIndex
                lblAgregarReferencia.Text = "  Editar"
            End If
            ' SeleccionReferencia = SeleccionReferencia
        End If


    End Sub




    Private Sub grdAcademica_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAcademica.CellDoubleClick
        If e.RowIndex >= 0 Then

            If grdAcademica.Rows(e.RowIndex).Cells(5).Value > 0 Then
                IndexAcademica = e.RowIndex
                IdAcademica = CInt(grdAcademica.Rows(e.RowIndex).Cells(5).Value)
                txtEscuela.Text = CStr(grdAcademica.Rows(e.RowIndex).Cells(0).Value)
                cmbGrado.Text = CStr(grdAcademica.Rows(e.RowIndex).Cells(6).Value)
                txtCarrera.Text = CStr(grdAcademica.Rows(e.RowIndex).Cells(1).Value)
                txtAnioInicio.Text = CStr(grdAcademica.Rows(e.RowIndex).Cells(2).Value)
                txtAnioFin.Text = CStr(grdAcademica.Rows(e.RowIndex).Cells(3).Value)
                cmbEstado.Text = CStr(grdAcademica.Rows(e.RowIndex).Cells(4).Value)
                lblAgregarAcademica.Text = "  Editar"
            End If


        End If

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        CargarInformacionDeCurpExistente()
    End Sub

    Private Sub btnSaveAndClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAndClose.Click

        Dim objColaboradorBU As New Negocios.ColaboradoresBU
        If ValidarCamposGeneral() And
            ValidarCamposNomina() And
            ValidarCamposReal() And
            ValidarCamposLaboral() Then

            Dim objConfirmar As New Tools.ConfirmarForm
            objConfirmar.mensaje = "¿Esta seguro de guardar los cambios en la información del colaborador?"
            If objConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then



                GuardarColaboradorGeneral()
                If colaboradorId <= 0 Then
                    colaboradorId = objColaboradorBU.BuscarColaboradorId
                Else
                End If

                colabororador.PColaboradorid = colaboradorId

                GuardarColaboradorLaboral(colabororador)
                GuardarColaboradorReal(colabororador)
                GuardarColaboradorNomina(colabororador)

                GuardarInformacionMedica(colabororador)
                GuardarInformacionAcademica(colabororador)
                GuardarInformacionFamilia(colabororador)
                GuardarInformacionAcademicaColaborador(colabororador)
                InsertarArchivo(colaboradorId)
                If cmbNave.SelectedIndex > 0 Then
                    Dim objbulaboral As New Negocios.ColaboradorLaboralBU
                    objbulaboral.ActualizarIdAnual(CInt(cmbNave.SelectedValue))
                End If

                If cambioDeSalario = True And txtSueldoRealRespaldo.ToString.Length > 0 Then
                    enviar_correo(cmbNave.SelectedValue, "NOTIFICACION_CAMBIO_SALARIO_REAL")
                End If

                Dim mensajeExito As New ExitoForm
                mensajeExito.mensaje = "Registro Guardado"
                mensajeExito.ShowDialog()
                Me.Close()

            End If
        Else
            Dim MensajeError As New AdvertenciaForm
            MensajeError.mensaje = "Faltan Campos por llenar. Favor de verifcar que la información sea correcta."
            MensajeError.ShowDialog()
        End If





    End Sub

    Private Sub txtSueldoDiario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSueldoDiario.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtSueldoDiario_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSueldoDiario.LostFocus
        Try
            txtSueldoFiscal.Text = (CDbl(txtSueldoDiario.Text)) * 7
        Catch ex As Exception
            txtSueldoFiscal.Text = ""
        End Try

    End Sub

    Private Sub txtSueldoDiario_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSueldoDiario.TextChanged

    End Sub

    Private Sub cmbArea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.SelectedIndexChanged
        If cmbArea.SelectedIndex > 0 Then
            cmbDepartamento = Controles.ComboDepatamentoSegunArea(cmbDepartamento, cmbArea.SelectedValue)
            cmbHorario = Controles.ComboHorarios(cmbHorario, cmbNave.SelectedValue)
            cmbHorario2 = Controles.ComboHorarios(cmbHorario2, cmbNave.SelectedValue)
        Else
            'If Not cmbDepartamento.DataSource Is Nothing Then
            '    cmbDepartamento.SelectedIndex = 0
            'End If
            'If Not cmbHorario.DataSource Is Nothing Then
            '    cmbHorario.SelectedIndex = 0
            'End If

            'If Not cmbHorario2.DataSource Is Nothing Then
            '    cmbHorario2.SelectedIndex = 0
            'End If
            cmbDepartamento.DataSource = Nothing
            cmbHorario.DataSource = Nothing
            cmbHorario2.DataSource = Nothing

        End If
    End Sub


    Private Sub txtSueldoReal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSueldoReal.TextChanged
        If CambioSueldo > 0 Then
            SueldoDiario = True
        End If
        CambioSueldo = 1
    End Sub

    Private Sub ChkInfonavitSi_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkInfonavitSi.CheckedChanged
        If ChkInfonavitSi.Checked = True Then
            lblTipo.Visible = True
            'cmbTipoInfonavit.Visible = True
            lblTipoInfonavit.Visible = True
            lblMonto.Visible = True
            txtMonto.Visible = True
            lblFechaAltaInfo.Visible = True
            dtpFechaAltaInfonavit.Visible = True
        Else
            lblTipo.Visible = False
            'cmbTipoInfonavit.Visible = False
            lblTipoInfonavit.Visible = False
            lblMonto.Visible = False
            txtMonto.Visible = False
            lblFechaAltaInfo.Visible = False
            dtpFechaAltaInfonavit.Visible = False


        End If
    End Sub

    Private Sub txtNIP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNIP.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtClaveElector_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClaveElector.KeyPress
        If Char.IsLower(e.KeyChar) Then
            txtClaveElector.SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If
    End Sub

    Private Sub cmbTipoNomina_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoNomina.SelectedIndexChanged
        If cmbTipoNomina.Text = "POR BANDA" Then
            lblCostoPartida.Visible = True
            txtCostoPartida.Visible = True
        Else
            lblCostoPartida.Visible = False
            txtCostoPartida.Visible = False
            txtCostoPartida.Text = ""
        End If
    End Sub

    Private Sub txtCostoPartida_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCostoPartida.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtTituloArchivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTituloArchivo.KeyPress
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            txtTituloArchivo.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub


    Private Sub txtOcupacionReferencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOcupacionReferencia.KeyPress
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            txtOcupacionReferencia.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub txtCPColaborador_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCPColaborador.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub cmbEstadoCiudad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstadoCiudad.SelectedIndexChanged
        Try
            cmbCiudadColaborador = Tools.Controles.ComboCiudadesMayusculas(cmbCiudadColaborador, cmbEstadoCiudad.SelectedValue)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbEstadoOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstadoOrigen.SelectedIndexChanged
        Try
            cmbCiudadOrigen = Tools.Controles.ComboCiudadesMayusculas(cmbCiudadOrigen, cmbEstadoOrigen.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub AltasColaboradoresForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
    '    If Char.IsLetter(e.KeyChar) Then

    '        e.KeyChar = Char.ToUpper(e.KeyChar)

    '    End If

    'End Sub


    Private Sub enviar_correo(ByVal naveID As Integer, ByVal clave As String)



        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String
        Dim correo As New Tools.Correo
        Dim fecha As DateTime = Now.Date
        destinatarios = enviosCorreoBU.consulta_destinatarios_email(naveID, clave)

        Dim Email As String = ""
        Email += " <!DOCTYPE html>"
        Email += " <html>  "
        Email += " <head>  "
        Email += " <style> "
        Email += " #Header{"
        Email += " color:#003366;"
        Email += " font-family: Arial, Helvetica, sans-serif;"
        Email += " }"
        Email += " table, th, td { border: 1px solid black; text-align: center; } "
        Email += " th{ background-color:#003366; "
        Email += " color:#FFFFFF; "
        Email += " font-weight:bold;"
        Email += " height:30px;"
        Email += " font-size:10px;"
        Email += " font-family: Arial, Helvetica, sans-serif;"
        Email += " text-align: center; "
        Email += " } "
        Email += " td{ "
        Email += " font-family: Arial, Helvetica, sans-serif; "
        Email += " text-align: center; "
        Email += " color:#003363;"
        Email += " font-size:10px;"
        Email += " font-weight:bold;"
        Email += " } "
        Email += " </style>"
        Email += " <div id='Header'>"
        Email += " <img src='" + "http://grupoyuyin.com.mx/images/SAY170.jpg" + "' height='" + "60" + "' width='" + "60" + "'alt='" + "logo" + "'>"
        Email += " <h1>"
        Email += " <strong>"
        Email += " Sueldo editado."
        Email += " </strong>"
        Email += " </h1>"
        Email += "<h5>Usuario modificó: " + Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString + " <h5>"
        Email += "<h5>Fecha modificación: " + Now.Date.ToLongDateString + "<h5>"
        Email += " </div>"
        Email += " </head>"
        Email += "<body>"
        Email += "<table style='border:1px;'>"
        Email += "<thead>"
        Email += "<tr>"
        Email += "<th>"
        Email += "Colaborador"
        Email += "</th>"
        Email += "<th>"
        Email += "Salario original"
        Email += "</th>"
        Email += "<th>"
        Email += "Salario nuevo"
        Email += "</th>"

        Email += "</tr>"
        Email += "</thead>"
        Email += "<tbody>"


        Email += "<tr>"

        Email += "<td>"
        Email += txtNombreColaborador.Text + " " + txtAPaternoColaborador.Text + " " + txtAMaternoColaborador.Text
        Email += "</td>"

        Email += "<td>$"
        Email += txtSueldoReal.Text
        Email += ".00</td>"

        Email += "<td>$"
        Email += txtSueldoRealRespaldo.Text
        Email += ".00</td>"
        Email += "</tr>"

        Email += "</tbody>"
        Email += "</table>"
        Email += "</body> "
        Email += "</html> "
        correo.EnviarCorreoHtml(destinatarios, "say_nomina@grupoyuyin.com.mx", "Sueldo editado", Email)
    End Sub
    Private Sub btnCalcularCurp_Click(sender As Object, e As EventArgs) Handles btnCalcularCurp.Click
        Dim startInfo As System.Diagnostics.ProcessStartInfo
        Dim pStart As New System.Diagnostics.Process
        startInfo = New System.Diagnostics.ProcessStartInfo("C:\SICY\CalcCURP.exe")

        pStart.StartInfo = startInfo
        pStart.Start()
        pStart.WaitForExit()
        'Shell("C:\SICY\CalcCURP.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub btnCalcularRfc_Click(sender As Object, e As EventArgs) Handles btnCalcularRfc.Click
        Dim startInfo As System.Diagnostics.ProcessStartInfo
        Dim pStart As New System.Diagnostics.Process
        startInfo = New System.Diagnostics.ProcessStartInfo("C:\SICY\CalcRFC.exe")

        pStart.StartInfo = startInfo
        pStart.Start()
        pStart.WaitForExit()
        'Shell("C:\SICY\CalcRFC.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub btnGenerarNip_Click(sender As Object, e As EventArgs) Handles btnGenerarNip.Click
        txtNIP.Text = RandGen.Next(1000, 10000).ToString
    End Sub
    Private Sub btnAccesoDirecto_Click(sender As Object, e As EventArgs) Handles btnAccesoDirecto.Click
        System.Diagnostics.Process.Start("https://serviciosdigitales.imss.gob.mx")
    End Sub

    Public Sub validaSolicitudImss(ByVal colaboradorId As Int32)
        Dim objBu As New Negocios.ColaboradoresBU
        Dim banderaValida As Boolean = False

        banderaValida = objBu.validaSolicitudImss(colaboradorId)

        If banderaValida = True Then
            dtpFechaAltaSS.Enabled = False
            txtSueldoDiario.Enabled = False
            chkAsegurado.Enabled = False
            txtNSS.Enabled = False
            txtISR.Enabled = False
            cmbPatron.Enabled = False
        End If
    End Sub

    Private Sub txtRfc_LostFocus(sender As Object, e As EventArgs) Handles txtRfc.LostFocus
        txtRfc.Text = txtRfc.Text.Replace("-", "")
        txtRfc.Text = txtRfc.Text.Replace(" ", "")
    End Sub

    Private Sub txtSueldoSemanalAguinaldo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSueldoSemanalAguinaldo.KeyPress
        If Not (IsNumeric(e.KeyChar) Or e.KeyChar = ChrW(Keys.Back) Or e.KeyChar = "-" Or e.KeyChar = ")" Or e.KeyChar = "(") Then
            e.Handled = True
        End If
    End Sub
    Private Sub rbLicenciaNo_CheckedChanged(sender As Object, e As EventArgs) Handles rbLicenciaNo.CheckedChanged
        If rbLicenciaNo.Checked = True Then
            txtFolioLicencia.Enabled = False
            dtpFechaVigente.Enabled = False
            lblFolioLicencia.ForeColor = Color.Black
            lblVigencia.ForeColor = Color.Black
        Else
            txtFolioLicencia.Enabled = True
            dtpFechaVigente.Enabled = True
        End If
    End Sub

    Private Sub lblPatron_Click(sender As Object, e As EventArgs) Handles lblPatron.Click

    End Sub

End Class