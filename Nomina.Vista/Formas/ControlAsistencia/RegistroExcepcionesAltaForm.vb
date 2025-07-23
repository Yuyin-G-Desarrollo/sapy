Imports Tools

Public Class RegistroExcepcionesAltaForm

    Public RegistroExcepcionesPost As Boolean
    Public RevisionRegistroExcepciones As Boolean
    Private regCheckAutomatico As DateTime
    Public registroCheckID As Integer
    Public naveID As Integer
    Public regCheck As Entidades.RegistroCheck

    Private Sub RegistroExcepcionesAltaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        picboxColaborador.Image = CType(My.Resources.ResourceManager.GetObject("YUMPER1"), Image)
        listado_naves()

        If RegistroExcepcionesPost Then
            registro_excepcion_post(regCheck)
        Else

        End If

        If RevisionRegistroExcepciones Then
            revision_excepcion(regCheck)
        End If

    End Sub

    Private Sub registro_excepcion_post(ByVal regCheck As Entidades.RegistroCheck)

        Dim DetalleHorarioBU As New Negocios.DetalleHorarioBU
        Dim ColaboradorLaboralBU As New Negocios.ColaboradorLaboralBU
        Dim listaDetalleHorarioBU As New List(Of Entidades.DetalleHorario)
        Dim colaboradorLaboral As New Entidades.ColaboradorLaboral
        Dim detalleHorarioE As New Entidades.DetalleHorario

        cboxNave.SelectedValue = regCheck.Pregcheck_nave.PNaveId
        cboxNave.SelectedItem = cboxNave.SelectedValue
        cboxNave.Enabled = False

        listado_departamentos()

        cboxDepartamento.SelectedValue = regCheck.Pregcheck_departamento.Ddepartamentoid
        cboxDepartamento.SelectedItem = cboxDepartamento.SelectedValue
        cboxDepartamento.Enabled = False

        listado_colaboradores()

        cboxColaborador.SelectedValue = regCheck.PCheck_Colaborador.PColaboradorid
        cboxColaborador.SelectedItem = cboxColaborador.SelectedValue
        cboxColaborador.Enabled = False

        Dim ObjArchivosBU As New Nomina.Negocios.EnviodeArchivosBU
        Dim EntidadArchivos As New Entidades.ColaboradorExpediente
        Try
            EntidadArchivos = ObjArchivosBU.CredencialColaborador(cboxColaborador.SelectedValue)
        Catch ex As Exception

        End Try


        Try
            picboxColaborador = Tools.Controles.CargaFotoColaboradorHTTP(picboxColaborador, EntidadArchivos)
        Catch ex As Exception
        End Try


        listado_motivos(cboxNave.SelectedValue)

        colaboradorLaboral = ColaboradorLaboralBU.buscarInformacionLaboral(regCheck.PCheck_Colaborador.PColaboradorid)

        cboxTipoPermiso.Enabled = False

        If Not regCheck.PCheck_normal = Date.MinValue Then
            listaDetalleHorarioBU = DetalleHorarioBU.buscar_InicioFinBloque(colaboradorLaboral.PHorarioId.DHorariosid, regCheck.PCheck_Tipo, regCheck.PCheck_normal.DayOfWeek)
            detalleHorarioE = listaDetalleHorarioBU.Item(listaDetalleHorarioBU.Count - 1)
            dtpFechaInicio.Value = regCheck.PCheck_normal.ToLongDateString
            dtpFechaTermino.Value = regCheck.PCheck_normal.ToLongDateString
            dtpHoraInicio.Value = Date.Parse(detalleHorarioE.DH_InicioBloque)
            dtpHoraFin.Value = Date.Parse(detalleHorarioE.DH_FinBloque)
            regCheckAutomatico = DateTime.Parse(detalleHorarioE.DH_HoraCheck)
        Else

            If Not regCheck.PCheck_automatico = Date.MinValue Then
                listaDetalleHorarioBU = DetalleHorarioBU.buscar_InicioFinBloque(colaboradorLaboral.PHorarioId.DHorariosid, regCheck.PCheck_Tipo, regCheck.PCheck_automatico.DayOfWeek)
                detalleHorarioE = listaDetalleHorarioBU.Item(listaDetalleHorarioBU.Count - 1)
                dtpFechaInicio.Value = regCheck.PCheck_automatico.ToLongDateString
                dtpFechaTermino.Value = regCheck.PCheck_automatico.ToLongDateString
                dtpHoraInicio.Value = Date.Parse(detalleHorarioE.DH_InicioBloque)
                dtpHoraFin.Value = Date.Parse(detalleHorarioE.DH_FinBloque)
                regCheckAutomatico = DateTime.Parse(detalleHorarioE.DH_HoraCheck)
            End If

        End If

        If regCheck.PCheck_Tipo = 1 Then
            chkEntrada.Checked = True
            chkRegreso.Checked = False
        End If
        If regCheck.PCheck_Tipo = 3 Then
            chkEntrada.Checked = False
            chkRegreso.Checked = True
        End If

        grpBloque.Enabled = False

        dtpFechaInicio.Enabled = False
        dtpFechaTermino.Enabled = False
        dtpHoraInicio.Enabled = False
        dtpHoraFin.Enabled = False

    End Sub

    Private Sub revision_excepcion(ByVal regcheck As Entidades.RegistroCheck)

        Dim regExcepcionBu As New Negocios.RegistroExcepcionesBU
        Dim listaRegExcepcion As New List(Of Entidades.RegistroExcepciones)
        Dim DetalleHorarioBU As New Negocios.DetalleHorarioBU
        Dim ColaboradorLaboralBU As New Negocios.ColaboradorLaboralBU
        Dim listaDetalleHorarioBU As New List(Of Entidades.DetalleHorario)
        Dim colaboradorLaboral As New Entidades.ColaboradorLaboral
        Dim detalleHorarioE As New Entidades.DetalleHorario
        Dim regExcepcion As Entidades.RegistroExcepciones
        Dim permisoDepartamental As Boolean

        permisoDepartamental = regExcepcionBu.permiso_Departamental(regcheck.PCheck_Excepcion.Pregexc_id)

        listaRegExcepcion = regExcepcionBu.consultar_RegistroExcepcion(regcheck, permisoDepartamental)
        regExcepcion = listaRegExcepcion.Item(0)

        cboxNave.SelectedValue = regcheck.Pregcheck_nave.PNaveId
        cboxNave.SelectedItem = cboxNave.SelectedValue
        cboxNave.Enabled = False

        listado_departamentos()

        cboxDepartamento.SelectedValue = regcheck.Pregcheck_departamento.Ddepartamentoid
        cboxDepartamento.SelectedItem = cboxDepartamento.SelectedValue
        cboxDepartamento.Enabled = False

        If permisoDepartamental Then

        Else
            listado_colaboradores()
        End If


        cboxColaborador.SelectedValue = regcheck.PCheck_Colaborador.PColaboradorid
        cboxColaborador.SelectedItem = cboxColaborador.SelectedValue
        cboxColaborador.Enabled = False

        Dim ObjArchivosBU As New Nomina.Negocios.EnviodeArchivosBU
        Dim EntidadArchivos As New Entidades.ColaboradorExpediente
        Try
            EntidadArchivos = ObjArchivosBU.CredencialColaborador(cboxColaborador.SelectedValue)
        Catch ex As Exception
        End Try
        Try
            picboxColaborador = Tools.Controles.CargaFotoColaboradorHTTP(picboxColaborador, EntidadArchivos)
        Catch ex As Exception
        End Try


        listado_motivos(cboxNave.SelectedValue)

        cboxMotivoPermiso.SelectedValue = regExcepcion.Pregexc_motivo.Pexmot_id
        cboxMotivoPermiso.SelectedItem = cboxMotivoPermiso.SelectedValue
        cboxMotivoPermiso.Enabled = False

        cboxTipoPermiso.SelectedIndex = regExcepcion.Pregexc_tipo_excepcion - 1
        cboxTipoPermiso.Enabled = False

        dtpFechaInicio.Value = regExcepcion.Pregexc_fecha_inicio.ToLongDateString
        dtpFechaTermino.Value = regExcepcion.Pregexc_fecha_termino.ToLongDateString
        dtpHoraInicio.Value = Date.Parse(regExcepcion.Pregexc_hora_inicio)
        dtpHoraFin.Value = Date.Parse(regExcepcion.Pregexc_hora_termino)

        dtpFechaInicio.Enabled = False
        dtpFechaTermino.Enabled = False
        dtpHoraInicio.Enabled = False
        dtpHoraFin.Enabled = False

        If regExcepcion.Pregexc_caja_ahorro Then
            chboxCajaAhorro.Checked = True
        Else
            chboxCajaAhorro.Checked = False
        End If

        chboxCajaAhorro.Enabled = False

        If regExcepcion.Pregexc_puntualidad_asistencia Then
            chboxPyA.Checked = True
        Else
            chboxPyA.Checked = False
        End If

        chboxPyA.Enabled = False

        txtboxNota.Text = regExcepcion.Pregexc_motivo_nota
        txtboxNota.Enabled = False

        btnGuardar.Visible = False
        lblGuardar.Visible = False

        btnCancelar.Visible = False
        lblCancelar.Visible = False

        If regcheck.PCheck_Tipo = 1 Then
            chkEntrada.Checked = True
            chkRegreso.Checked = False
        End If
        If regcheck.PCheck_Tipo = 3 Then
            chkEntrada.Checked = False
            chkRegreso.Checked = True
        End If

        grpBloque.Enabled = False

    End Sub

    Private Sub listado_naves()

        Try

            Controles.ComboNavesSegunUsuario(cboxNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))

        Catch ex As Exception

        End Try

        If cboxNave.SelectedIndex > 0 Then

            listado_departamentos()
            listado_motivos(cboxNave.SelectedValue)

        End If

    End Sub

    Private Sub listado_departamentos()

        Try

            Controles.ComboDepatamentoSegunNave(cboxDepartamento, CInt(cboxNave.SelectedValue.ToString))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub listado_colaboradores()

        Try

            Controles.ComboColaboradoresSegunDepto(cboxColaborador, CInt(cboxDepartamento.SelectedValue.ToString))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub listado_motivos(ByVal naveID As Integer)

        'Dim objBU As Nomina.Negocios

        'ComboNavesSegunUsuario = New ComboBox
        'ComboNavesSegunUsuario = ComboEntrada
        Dim listaMotivos As New List(Of Entidades.ExcepcionMotivo)
        Dim excepcionMotivoBU As New Nomina.Negocios.ExcepcionMotivoBU
        listaMotivos = excepcionMotivoBU.listaMotivoExcepcion(naveID)

        listaMotivos.Insert(0, New Entidades.ExcepcionMotivo)
        If listaMotivos.Count > 0 Then
            cboxMotivoPermiso.DataSource = listaMotivos
            cboxMotivoPermiso.DisplayMember = "Pexmot_nombre"
            cboxMotivoPermiso.ValueMember = "Pexmot_id"
        End If


    End Sub

    Private Sub cboxNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxNave.DropDownClosed

        listado_departamentos()
        listado_motivos(cboxNave.SelectedValue)

    End Sub

    Private Sub cboxDepartamento_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxDepartamento.DropDownClosed

        listado_colaboradores()

    End Sub

    Private Sub cboxColaborador_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxColaborador.DropDownClosed

        Dim ObjArchivosBU As New Nomina.Negocios.EnviodeArchivosBU
        Dim EntidadArchivos As New Entidades.ColaboradorExpediente
        Try
            EntidadArchivos = ObjArchivosBU.CredencialColaborador(cboxColaborador.SelectedValue)
        Catch ex As Exception

        End Try


        Try
            picboxColaborador = Tools.Controles.CargaFotoColaboradorHTTP(picboxColaborador, EntidadArchivos)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cboxMotivoPermiso_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxMotivoPermiso.DropDownClosed


        If cboxMotivoPermiso.SelectedIndex > 0 Then

            Dim listaMotivos As New List(Of Entidades.ExcepcionMotivo)
            Dim excepcionMotivoBU As New Nomina.Negocios.ExcepcionMotivoBU
            listaMotivos = excepcionMotivoBU.listaIncentivosSegunMotivo(cboxMotivoPermiso.SelectedValue)

            Dim motivo As Entidades.ExcepcionMotivo = listaMotivos.FindLast(Function(c) c.Pexmot_id = cboxMotivoPermiso.SelectedValue)


            If motivo.Pexmot_puntualidad_asistencia Then
                chboxPyA.Checked = True
            Else
                chboxPyA.Checked = False
            End If

            If motivo.Pexmot_caja_ahorro Then
                chboxCajaAhorro.Checked = True
            Else
                chboxCajaAhorro.Checked = False
            End If

        Else
            chboxCajaAhorro.Checked = False
            chboxPyA.Checked = False
        End If

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Dim registroExcepcionBU As New Nomina.Negocios.RegistroExcepcionesBU
        Dim registroExcepcion As New Entidades.RegistroExcepciones
        Dim usuario_solcita As New Entidades.Usuarios
        Dim usuario_revisa As New Entidades.Usuarios
        Dim motivo As New Entidades.ExcepcionMotivo
        Dim colaborador As New Entidades.Colaborador
        Dim departamento As New Entidades.Departamentos
        Dim nave As New Entidades.Naves
        Dim colaboradoresBU As New Negocios.ColaboradoresBU
        Dim velador As Boolean
        Dim mensaje As String

        mensaje = validar_Campos_Vacios()
        If mensaje <> "" Then
            If mensaje.Contains("fechas") Then
                show_message("Advertencia", mensaje) '"Falta información por ingresar")
            Else
                show_message("Advertencia", "Falta información por ingresar: " + Environment.NewLine + mensaje) '"Falta información por ingresar")
            End If

            Return
        End If

        Try
            registroExcepcion.Pregexc_fecha_inicio = DateTime.Parse(dtpFechaInicio.Text.ToString)
            registroExcepcion.Pregexc_fecha_termino = DateTime.Parse(dtpFechaTermino.Text.ToString)
            registroExcepcion.Pregexc_hora_inicio = Date.Parse(dtpHoraInicio.Text.ToString)
            registroExcepcion.Pregexc_hora_termino = Date.Parse(dtpHoraFin.Text.ToString)

            If Not IsDBNull(txtboxNota.Text) Or IsNothing(txtboxNota.Text) Then
                registroExcepcion.Pregexc_motivo_nota = CStr(txtboxNota.Text.ToString) 'POSIBLE NULL
                'Return
            Else
                show_message("Advertencia", "Debe ingresar una nota para la solicitud (Mínimo 10 caracteres).")
                Exit Sub
            End If

            registroExcepcion.Pregexc_puntualidad_asistencia = Boolean.Parse(chboxPyA.Checked)
            registroExcepcion.Pregexc_caja_ahorro = Boolean.Parse(chboxCajaAhorro.Checked)


            If IsNothing(cboxTipoPermiso.SelectedItem) Then
                registroExcepcion.Pregexc_tipo_excepcion = 0
            Else
                If cboxTipoPermiso.SelectedItem.ToString.Equals("ENTRADA TARDE") Then
                    registroExcepcion.Pregexc_tipo_excepcion = 1
                End If
                If cboxTipoPermiso.SelectedItem.ToString.Equals("SALIDA ANTICIPADA") Then
                    registroExcepcion.Pregexc_tipo_excepcion = 2
                End If
                If cboxTipoPermiso.SelectedItem.ToString.Equals("INASISTENCIA") Then
                    registroExcepcion.Pregexc_tipo_excepcion = 3
                End If
            End If

            motivo.Pexmot_id = Integer.Parse(cboxMotivoPermiso.SelectedValue)
            motivo.Pexmot_nombre = CStr(cboxMotivoPermiso.Text.ToString)

            registroExcepcion.Pregexc_motivo = motivo

            registroExcepcion.Pregexc_estado_excepcion = 1


            If cboxColaborador.SelectedIndex > 0 Then
                velador = colaboradoresBU.buscarColaboradorVigilanteNocturno(cboxNave.SelectedValue, cboxColaborador.SelectedValue)
                colaborador.PColaboradorid = Integer.Parse(cboxColaborador.SelectedValue)
                colaborador.PNombre = CStr(cboxColaborador.Text.ToString)
                departamento.Ddepartamentoid = 0
            Else

                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_CA_REG_EXCEPCION", "PERMISODEPARTAMENTO") Then
                    departamento.Ddepartamentoid = Integer.Parse(cboxDepartamento.SelectedValue)
                    departamento.DNombre = CStr(cboxDepartamento.Text.ToString)
                    colaborador.PColaboradorid = 0
                Else
                    show_message("Advertencia", "No cuenta con permisos suficientes para realizar esta acción")
                    Exit Sub
                End If

            End If

            registroExcepcion.Pregexc_colaborador = colaborador
            registroExcepcion.Pregexc_departamento = departamento

            If RegistroExcepcionesPost Then
                regCheck.PRegcheck_Tipos = ""
                registroExcepcionBU.guardar_RegistroExcepcion(registroExcepcion, regCheck, regCheckAutomatico, 1, velador)
                show_message("Aviso", "Solicitud en proceso" + vbNewLine + "Espere un momento...")
                'Dim cursor As Cursor
                Cursor.Current = Cursors.WaitCursor
                colaborador.PNombre = CStr(cboxColaborador.Text.ToString)
                departamento.DNombre = CStr(cboxDepartamento.Text.ToString)
                registroExcepcion.Pregexc_colaborador = colaborador
                registroExcepcion.Pregexc_departamento = departamento
                enviar_correo(cboxNave.SelectedValue, registroExcepcion, "ENVIO_NOTIFICACION_SOLICITUD_PERMISO")

                show_message("Exito", "Guardado con éxito" + vbNewLine + "")
                Cursor.Current = Cursors.Default

                Me.Close()
            Else
                'Dim horaFin As DateTime
                'Dim horaRegistro As DateTime
                'horaRegistro = "2:00 PM"
                'horaFin = dtpHoraFin.Text.ToString
                regCheck = New Entidades.RegistroCheck
                'Dim resul As Int32 = 0
                'resul = DateTime.Compare(horaFin.ToShortTimeString, horaRegistro.ToShortTimeString)
                'If resul < 0 Then
                '    regCheck.PCheck_Tipo = 1
                'Else
                '    regCheck.PCheck_Tipo = 3
                'End If
                regCheck.PCheck_Tipo = 0

                Dim tipos As String = ""
                If chkEntrada.Checked = True And chkRegreso.Checked = True Then
                    tipos = "1,3"
                ElseIf chkRegreso.Checked = True Then
                    tipos = "3"
                ElseIf chkEntrada.Checked = True Then
                    tipos = "1"
                End If
                regCheck.PRegcheck_Tipos = tipos
                nave.PNaveId = cboxNave.SelectedValue
                regCheck.Pregcheck_nave = nave
                registroExcepcionBU.guardar_RegistroExcepcion(registroExcepcion, regCheck, Date.MinValue, 0, velador)
                show_message("Aviso", "Solicitud en proceso" + vbNewLine + "Espere un momento...")
                'Dim cursor As Cursor
                Cursor.Current = Cursors.WaitCursor
                colaborador.PNombre = CStr(cboxColaborador.Text.ToString)
                departamento.DNombre = CStr(cboxDepartamento.Text.ToString)
                registroExcepcion.Pregexc_colaborador = colaborador
                registroExcepcion.Pregexc_departamento = departamento
                enviar_correo(cboxNave.SelectedValue, registroExcepcion, "ENVIO_NOTIFICACION_SOLICITUD_PERMISO")

                show_message("Exito", "Guardado con éxito" + vbNewLine + "")
                Cursor.Current = Cursors.Default

            End If

            cboxNave.SelectedIndex = 0
            cboxDepartamento.SelectedIndex = 0
            cboxColaborador.SelectedIndex = 0
            cboxTipoPermiso.SelectedIndex = -1
            cboxMotivoPermiso.SelectedIndex = 0
            chboxPyA.Checked = False
            chboxCajaAhorro.Checked = False
            txtboxNota.Clear()
            dtpFechaInicio.Text = Now
            dtpFechaTermino.Text = Now
            dtpHoraInicio.Text = Now
            dtpHoraFin.Text = Now
            picboxColaborador.Image = Nothing
            chkEntrada.Checked = False
            chkRegreso.Checked = False

        Catch ex As Exception
            show_message("Error", "Algo surgió mal durante el proceso de guardado" + vbNewLine + "Contacte al administrador")

            Cursor.Current = Cursors.Default
            Exit Sub
        End Try
    End Sub

    Private Function validar_Campos_Vacios() As String ' As Boolean

        If cboxNave.SelectedIndex < 1 Then
            Return "Favor de elegir una nave." 'Return True
        End If

        If cboxDepartamento.SelectedIndex < 1 Then
            Return "Favor de elegir un departamento." 'Return True
        End If

        If RegistroExcepcionesPost Then
        Else

            If cboxTipoPermiso.SelectedIndex < 0 Then
                Return "Favor de elegir un Tipo de Permiso." 'Return True
            End If
        End If

        'If RegistroExcepcionesPost Then
        'Else
        If cboxMotivoPermiso.SelectedIndex < 1 Then
            Return "Favor de elegir un Motivo de Permiso." 'Return True
        End If
        'End If


        If txtboxNota.Text.Length < 5 Then
            Return "Favor de agregar una nota (Mínimo 10 caracteres)." 'Return True
        End If

        If RegistroExcepcionesPost Then
        Else
            If chkEntrada.Checked = False And chkRegreso.Checked = False Then
                Return "Favor de elegir el tipo de Bloque." 'Return True
            End If
        End If

        If dtpFechaInicio.Value > dtpFechaTermino.Value Then
            Return "Verificar que las fechas de incio y fin sean correctas."
        End If

        Return "" 'False
        'If cboxNave.SelectedIndex = 0 Then
        'Else
        'End If

    End Function

    Private Sub enviar_correo(ByVal naveID As Integer, ByVal registroExcepcion As Entidades.RegistroExcepciones, ByVal clave As String)

        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String
        Dim correo As New Tools.Correo

        destinatarios = enviosCorreoBU.consulta_destinatarios_email(naveID, clave)

        Dim Email As String = "<html>" +
                                "<head>" +
                                  "<style type ='" + "text/css" + "'> body {display: block; margin: 8px; background: #FFFFFF;}#header{	position: fixed;	height: 62px;	top: 0;	left: 0;	right: 0;	color: #003366;	font-family: Arial, Helvetica, sans-serif;	font-size: 18px;	font-weight: bold;}#leftcolumn{	float: left;	position: fixed;	width: 2%;	margin: 1%;	padding-top: 3%;	top: 0;	left: 0;	right: 0;}#content{	width: 90%;	position: fixed;	margin: 1% 5%;		padding-top: 3%;	padding-bottom: 1%;}#rightcolumn{	float: right;	width: 5%;	margin: 1%;			padding-top: 3%;}#footer{	position: fixed;	width: 100%;	heigt: 5%;	bottom: 0;	margin: 0;	padding: 0;	color: #FFFFFF;}table.tableizer-table { 	font-family: Arial, Helvetica, sans-serif;	font-size: 9px;} .tableizer-table td {	padding: 4px;	margin: 0px;	border: 1px solid #FFFFFF;	border-color: #FFFFFF;	border: 1px solid #CCCCCC;	width: 200px;} .tableizer-table tr {	padding: 4px;	margin: 0;	color: #003366;	font-weight: bold;	background-color: #transparent; 	opacity: 1;}.tableizer-table th {	background-color: #003366; 	color: #FFFFFF;	font-weight: bold;	height: 30px;	font-size: 10px;}A:link {	text-decoration:none;color:#FFFFFF;} A:visited {	text-decoration:none;color:#FFFFFF;} A:active {	text-decoration:none;color:#FFFFFF;} A:hover {	text-decoration:none;color:#006699;} </style>" +
                                  "</head>" +
                                  "<body>" +
                                   "<div id='" + "wrapper" + "'>" +
                                    "<div id='" + "header" + "'>" +
                                    "<img src='" + "http://grupoyuyin.com.mx/images/SAY170.jpg" + "'style='" + "vertical-align:middle" + "' height='" + "57" + "' widht='" + "125" + "'> Solicitud de Permiso " +
                                   "</div>" +
                                    "<div id='" + "leftcolumn" + "'>" +
                                    "</div>" +
                                    "<div id='" + "rightcolumn" + "'>" +
                                    "</div>" + "<div id='" + "content" + "'>" +
                                      "<table id='" + "mi_tabla" + "' class='" + "tableizer-table" + "'>" +
                                       "<thead>" +
                                        "<tr class='" + "tableizer-firstrow" + "'>" +
                                        "<th width ='" + "20%" + "'>Nombre</th>" +
                                        "<th width ='" + "15%" + "'>Departamento</th>" +
                                        "<th>Fecha Inicio</th>" +
                                        "<th>Fecha Termino</th>" +
                                        "<th width ='" + "7%" + "'>Hora Inicio</th>" +
                                        "<th width ='" + "7%" + "'>Hora Termino</th>" +
                                        "<th width ='" + "13%" + "'>Solicita</th>" +
                                        "<th width ='" + "15%" + "'>Nota</th>" +
                                        "<th>PyA</th>" +
                                        "<th>CdA</th>" +
                                        "<th width ='" + "10%" + "'>Tipo de excepcion</th>" +
                                        "<th width ='" + "15%" + "'>Motivo</th>" +
                                        "</tr>" +
                                       "</thead>" +
                                       "<tbody>" +
                                        "<tr>" +
                                            "<td>" + registroExcepcion.Pregexc_colaborador.PNombre.ToString + "</td>" +
                                            "<td>" + registroExcepcion.Pregexc_departamento.DNombre.ToString + "</td>" +
                                            "<td>" + registroExcepcion.Pregexc_fecha_inicio.ToShortDateString + "</td>" +
                                            "<td>" + registroExcepcion.Pregexc_fecha_termino.ToShortDateString + "</td>" +
                                            "<td>" + registroExcepcion.Pregexc_hora_inicio.ToLongTimeString + "</td>" +
                                            "<td>" + registroExcepcion.Pregexc_hora_termino.ToLongTimeString + "</td>" +
        "<td>" + Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString + "</td>"

        Email += "<td>" + registroExcepcion.Pregexc_motivo_nota.ToString + "</td>"

        If registroExcepcion.Pregexc_puntualidad_asistencia Then
            Email += "<td> Si</td>"
        Else
            Email += "<td> No</td>"
        End If

        If registroExcepcion.Pregexc_caja_ahorro.ToString Then
            Email += "<td> Si</td>"
        Else
            Email += "<td> No</td>"
        End If

        If registroExcepcion.Pregexc_tipo_excepcion = 0 Then
            Email += "<td>Registro de excepción</td>"
        End If
        If registroExcepcion.Pregexc_tipo_excepcion = 1 Then
            Email += "<td> Entrar tarde</td>"
        End If
        If registroExcepcion.Pregexc_tipo_excepcion = 2 Then
            Email += "<td> Salir Temprano</td>"
        End If
        If registroExcepcion.Pregexc_tipo_excepcion = 3 Then
            Email += "<td> Inasistencia</td>"
        End If

        Email += "<td>" + registroExcepcion.Pregexc_motivo.Pexmot_nombre.ToString + "</td>" +
                   "</tr>" +
                "</tbody>" +
                "</table>" +
                       "</div>" +
                       "<div id='" + "footer" + "'>" +
                       "</div>" +
                   "</div>" +
                "</body>" +
                "</html>"

        correo.EnviarCorreoHtml(destinatarios, "checador@grupoyuyin.com.mx", "Solicitud de Permiso", Email)

    End Sub

    Private Sub txtboxNota_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtboxNota.KeyPress
        If Char.IsLetter(e.KeyChar) Then

            e.KeyChar = Char.ToUpper(e.KeyChar)

        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub


End Class