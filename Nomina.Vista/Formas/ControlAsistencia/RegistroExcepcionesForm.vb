Imports Entidades
Imports Tools

Public Class RegistroExcepcionesForm

    Dim IsPeriodoEditable As Boolean = False

    Private Sub RegistroExcepcionesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        listado_naves()

    End Sub

    Private Sub listado_naves()

        Try

            Controles.ComboNavesSegunUsuario(cboxNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))

        Catch ex As Exception

        End Try

        If cboxNave.SelectedIndex > 0 Then

            listado_periodos_asistencia()

        End If

    End Sub

    Private Sub listado_departamentos()

        Try

            Controles.ComboDepatamentoSegunNave(cboxDepartamento, CInt(cboxNave.SelectedValue.ToString))

            cboxDepartamento.FormatString.ToUpper()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub listado_colaboradores()

        Try

            Controles.ComboColaboradoresSegunDepto(cboxColaborador, CInt(cboxDepartamento.SelectedValue.ToString))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub listado_periodos_asistencia()

        Try

            Controles.ComboPeriodoSegunNaveSegunAsistenciaControlAsistencia(cboxPeriodo, CInt(cboxNave.SelectedValue.ToString))
            Dim ControlDelPeriodoBu As New Negocios.ControlDePeriodoBU
            Dim periodoNominaID As Integer = CInt(ControlDelPeriodoBu.periodoSegunNaveSegunAsistenciaActual(CInt(cboxNave.SelectedValue.ToString)).Rows(0).Item(0).ToString)

            cboxPeriodo.SelectedValue = periodoNominaID
            cboxPeriodo.SelectedItem = cboxPeriodo.SelectedValue
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cboxNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxNave.DropDownClosed

        listado_departamentos()
        listado_periodos_asistencia()

    End Sub

    Private Sub cboxDepartamento_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxDepartamento.DropDownClosed

        listado_colaboradores()

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click


        Dim registroExcepcionBU As New Negocios.RegistroExcepcionesBU
        Dim ControlDePeriodoBU As New Negocios.ControlDePeriodoBU
        Dim listaRegistroExcepcion As New List(Of Entidades.RegistroExcepciones)
        Dim departamentoID, colaboradorID, periodoNomID As Integer
        Dim naveID As Integer

        If cboxNave.SelectedIndex > 0 Then

            naveID = cboxNave.SelectedValue

        End If

        If cboxDepartamento.SelectedIndex > 0 Then

            departamentoID = cboxDepartamento.SelectedValue

        Else

            departamentoID = 0

        End If

        If cboxColaborador.SelectedIndex > 0 Then

            colaboradorID = cboxColaborador.SelectedValue

        Else

            colaboradorID = 0

        End If

        periodoNomID = cboxPeriodo.SelectedValue

        If ControlDePeriodoBU.buscarPeriodoEsActivoAsistencia(periodoNomID) Then
            IsPeriodoEditable = True
        Else
            IsPeriodoEditable = False
        End If


        listaRegistroExcepcion = registroExcepcionBU.consultar_RegistroExcepcionesPeriodo(naveID, periodoNomID, departamentoID, colaboradorID)

        cargar_gridControlExcepciones(listaRegistroExcepcion)

    End Sub

    Public Sub cargar_gridControlExcepciones(ByVal listaRegistroExcepcion As List(Of Entidades.RegistroExcepciones))

        gridControlExcepciones.Rows.Clear()
        Dim i As Integer
        For Each excepcion As Entidades.RegistroExcepciones In listaRegistroExcepcion
            Dim PyA, CdA As Boolean
            Dim tipoExcepcion As String = String.Empty
            Dim estadoExcepcion As String = String.Empty
            Dim registroExcepcionBU As New Negocios.RegistroExcepcionesBU
            Dim horarioID As Integer = registroExcepcionBU.buscar_horarioID(excepcion.Pregexc_colaborador.PColaboradorid)

            'If excepcion.Pregexc_estado_excepcion = 2 Or excepcion.Pregexc_estado_excepcion = 3 Then

            '    PyA = excepcion.Pregexc_motivo.Pexmot_puntualidad_asistencia
            '    CdA = excepcion.Pregexc_motivo.Pexmot_caja_ahorro
            'End If
            'If excepcion.Pregexc_estado_excepcion = 1 Then

            PyA = excepcion.Pregexc_puntualidad_asistencia
            CdA = excepcion.Pregexc_caja_ahorro

            'End If


            If excepcion.Pregexc_tipo_excepcion = 1 Then
                tipoExcepcion = "ENTRADA TARDE"
            End If
            If excepcion.Pregexc_tipo_excepcion = 2 Then
                tipoExcepcion = "SALIDA ANTICIPADA"
            End If
            If excepcion.Pregexc_tipo_excepcion = 3 Then
                tipoExcepcion = "INASISTENCIA"
            End If
            If excepcion.Pregexc_tipo_excepcion = 0 Then
                tipoExcepcion = "--"
            End If

            If excepcion.Pregexc_estado_excepcion = 1 Then
                estadoExcepcion = "PENDIENTE"
            End If

            If excepcion.Pregexc_estado_excepcion = 2 Then
                estadoExcepcion = "APROBADO"
            End If
            If excepcion.Pregexc_estado_excepcion = 3 Then
                estadoExcepcion = "DENEGADO"
            End If


            If IsDBNull(excepcion.Pregexc_usuario_rev) Or IsNothing(excepcion.Pregexc_usuario_rev) Then
                gridControlExcepciones.Rows.Add(excepcion.Pregexc_id,
                                           horarioID,
                                           excepcion.Pregexc_colaborador.PColaboradorid,
                                           excepcion.Pregexc_colaborador.PNombre + " " + excepcion.Pregexc_colaborador.PApaterno + " " + excepcion.Pregexc_colaborador.PAmaterno,
                                           excepcion.Pregexc_departamento.Ddepartamentoid,
                                           excepcion.Pregexc_departamento.DNombre,
                                           excepcion.Pregexc_fecha_inicio.ToShortDateString,
                                           excepcion.Pregexc_fecha_termino.ToShortDateString,
                                           excepcion.Pregexc_hora_inicio.ToLongTimeString,
                                           excepcion.Pregexc_hora_termino.ToLongTimeString,
                                           excepcion.Pregexc_usuario_sol.PUserUsuarioid,
                                           excepcion.Pregexc_usuario_sol.PUserUsername,
                                           excepcion.Pregexc_solicitud_fecha.ToShortDateString,
                                           Nothing,
                                           Nothing,
                                           Nothing,
                                           excepcion.Pregexc_motivo_nota,
                                           PyA,
                                           CdA,
                                           tipoExcepcion,
                                           excepcion.Pregexc_motivo.Pexmot_nombre,
                                           excepcion.Pregexc_estado_excepcion,
                                           estadoExcepcion
                                           )

            Else

                gridControlExcepciones.Rows.Add(excepcion.Pregexc_id,
                                           horarioID,
                                           excepcion.Pregexc_colaborador.PColaboradorid,
                                           excepcion.Pregexc_colaborador.PNombre.ToUpper + " " + excepcion.Pregexc_colaborador.PApaterno.ToUpper + " " + excepcion.Pregexc_colaborador.PAmaterno.ToUpper,
                                           excepcion.Pregexc_departamento.Ddepartamentoid.ToString,
                                           excepcion.Pregexc_departamento.DNombre.ToUpper,
                                           excepcion.Pregexc_fecha_inicio.ToShortDateString,
                                           excepcion.Pregexc_fecha_termino.ToShortDateString,
                                           excepcion.Pregexc_hora_inicio.ToLongTimeString,
                                           excepcion.Pregexc_hora_termino.ToLongTimeString,
                                           excepcion.Pregexc_usuario_sol.PUserUsuarioid,
                                           excepcion.Pregexc_usuario_sol.PUserUsername,
                                           excepcion.Pregexc_solicitud_fecha.ToShortDateString,
                                           excepcion.Pregexc_usuario_rev.PUserUsuarioid,
                                           excepcion.Pregexc_usuario_rev.PUserUsername,
                                           excepcion.Pregexc_revision_fecha.ToShortDateString(),
                                           excepcion.Pregexc_motivo_nota,
                                           PyA,
                                           CdA,
                                           tipoExcepcion,
                                           excepcion.Pregexc_motivo.Pexmot_nombre,
                                           excepcion.Pregexc_estado_excepcion,
                                           estadoExcepcion
                                           )

            End If


            If excepcion.Pregexc_estado_excepcion = 1 Then

                gridControlExcepciones.Rows(i).Cells(17).ReadOnly = False
                gridControlExcepciones.Rows(i).Cells(18).ReadOnly = False
                gridControlExcepciones.Rows(i).DefaultCellStyle.BackColor = Color.LightBlue

            End If
            If excepcion.Pregexc_estado_excepcion = 2 Then

                gridControlExcepciones.Rows(i).Cells(17).ReadOnly = True
                gridControlExcepciones.Rows(i).Cells(18).ReadOnly = True
                gridControlExcepciones.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen


            End If
            If excepcion.Pregexc_estado_excepcion = 3 Then

                gridControlExcepciones.Rows(i).Cells(17).ReadOnly = True
                gridControlExcepciones.Rows(i).Cells(18).ReadOnly = True
                gridControlExcepciones.Rows(i).DefaultCellStyle.BackColor = Color.Salmon


            End If

            i += 1
            'gridControlExcepciones.Rows(i).Cells(17).ToolTipText = "Si esta marcado gana. Si esta desmarcado pierde"
            'gridControlExcepciones.Rows(i).Cells(18).ToolTipText = "Si esta marcado gana. Si esta desmarcado pierde"

        Next

    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click

        Dim RegistroExcepcionAlta As New RegistroExcepcionesAltaForm

        RegistroExcepcionAlta.ShowDialog()

    End Sub

    Public Sub gridControlExcepciones_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gridControlExcepciones.CellMouseClick

        If gridControlExcepciones.CurrentCell.IsInEditMode Then Return

        If e.Button <> Windows.Forms.MouseButtons.Right Then Return

        If IsPeriodoEditable Then

            If gridControlExcepciones.Rows(e.RowIndex).Cells(21).Value = 1 Then

                If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then

                    If gridControlExcepciones.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected Then

                        If IsNothing(gridControlExcepciones.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Or IsDBNull(gridControlExcepciones.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then

                        Else
                            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_CA_REG_EXCEPCION", "APROBAREXCEPCIONES") Then

                                Dim cms = New ContextMenuStrip

                                Dim item1 = cms.Items.Add("Aprobar permiso")
                                item1.Tag = 1
                                AddHandler item1.Click, AddressOf menuChoice

                                Dim item2 = cms.Items.Add("Denegar permiso")
                                item2.Tag = 2
                                AddHandler item2.Click, AddressOf menuChoice

                                cms.Show(Control.MousePosition)

                            Else
                                'MessageBox.Show("NO CUENTA CON PERMISOS SUFIENTES PARA REALIZAR ESTA ACCION")
                                Exit Sub
                            End If

                        End If

                    End If

                End If

            End If

        End If
    End Sub

    Private Sub menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)

        If IsPeriodoEditable Then

            If selection = 1 Then

                'If gridControlExcepciones.Rows(e.RowIndex).Cells(20).Value = 1 Then

                If gridControlExcepciones.CurrentCell.RowIndex >= 0 And gridControlExcepciones.CurrentCell.ColumnIndex >= 4 Then

                    If gridControlExcepciones.CurrentCell.Selected Then

                        'Dim row, col As Integer

                        If IsNothing(gridControlExcepciones.CurrentCell.Value) Or IsDBNull(gridControlExcepciones.CurrentCell.Value) Then

                        Else

                            Dim RegistroExcepcionBU As New Negocios.RegistroExcepcionesBU
                            Try
                                ''AQUI HAY QUE METER LA BANDERA DEL VIGILANTE NOCTURNO 
                                RegistroExcepcionBU.aprobar_RegistroExcepcion(CInt(gridControlExcepciones.Rows(gridControlExcepciones.CurrentCell.RowIndex).Cells(0).Value), _
                                                                              CInt(gridControlExcepciones.Rows(gridControlExcepciones.CurrentCell.RowIndex).Cells(2).Value), _
                                                                              CInt(gridControlExcepciones.Rows(gridControlExcepciones.CurrentCell.RowIndex).Cells(1).Value), _
                                                                              CInt(cboxNave.SelectedValue), _
                                                                              1,
                                                                              CBool(gridControlExcepciones.Rows(gridControlExcepciones.CurrentCell.RowIndex).Cells(17).Value),
                                                                              CBool(gridControlExcepciones.Rows(gridControlExcepciones.CurrentCell.RowIndex).Cells(18).Value)
                                                                              )
                                show_message("Aviso", "Operación en progreso...")

                                enviar_correo(cboxNave.SelectedValue, "ENVIO_NOTIFICACION_SOLICITUD_PERMISO", gridControlExcepciones.Rows(gridControlExcepciones.CurrentCell.RowIndex), 2)

                                show_message("Exito", "Operación realizada con éxito")

                                btnAceptar.PerformClick()

                            Catch ex As Exception
                                show_message("Error", "Algo surgio mal durante la operación")
                            End Try


                            'Dim objRegistroManual As New RegistroManualForm
                            'objRegistroManual.registroCheckID = CInt(gridControlExcepciones.Rows(gridControlExcepciones.CurrentCell.RowIndex).Cells((gridControlExcepciones.CurrentCell.ColumnIndex) - 1).Value)
                            'objRegistroManual.naveID = naveID

                            'objRegistroManual.ShowDialog()

                            'row = CInt(gridControlExcepciones.CurrentCell.RowIndex)
                            'col = CInt(gridControlExcepciones.CurrentCell.ColumnIndex)

                            'btnAceptar.PerformClick()


                            'gridControlExcepciones.Rows(row).Cells(col).Style.BackColor = Color.LightGreen

                        End If

                    End If

                End If
                'End If
            End If

        End If

        If selection = 2 Then

            'If gridControlExcepciones.Rows(e.RowIndex).Cells(20).Value = 1 Then

            If gridControlExcepciones.CurrentCell.RowIndex >= 0 And gridControlExcepciones.CurrentCell.ColumnIndex >= 4 Then

                If gridControlExcepciones.CurrentCell.Selected Then

                    'Dim row, col As Integer

                    If IsNothing(gridControlExcepciones.CurrentCell.Value) Or IsDBNull(gridControlExcepciones.CurrentCell.Value) Then

                    Else

                        Dim RegistroExcepcionBU As New Negocios.RegistroExcepcionesBU
                        Try

                            RegistroExcepcionBU.aprobar_RegistroExcepcion(CInt(gridControlExcepciones.Rows(gridControlExcepciones.CurrentCell.RowIndex).Cells(0).Value), _
                                                                          CInt(gridControlExcepciones.Rows(gridControlExcepciones.CurrentCell.RowIndex).Cells(2).Value), _
                                                                          CInt(gridControlExcepciones.Rows(gridControlExcepciones.CurrentCell.RowIndex).Cells(1).Value), _
                                                                          CInt(cboxNave.SelectedValue), _
                                                                          2,
                                                                          False,
                                                                          False
                                                                          )
                            show_message("Aviso", "Operación en progreso...")

                            enviar_correo(cboxNave.SelectedValue, "ENVIO_NOTIFICACION_SOLICITUD_PERMISO", gridControlExcepciones.Rows(gridControlExcepciones.CurrentCell.RowIndex), 3)

                            show_message("Exito", "Operación realizada con éxito")

                        Catch ex As Exception
                            show_message("Error", "Algo surgio mal durante la operación")
                        End Try


                        'gridControlExcepciones.Rows(row).Cells(col).Style.BackColor = Color.LightGreen

                    End If

                End If

            End If

            'End If

        End If
        'If selection = 2 Then
        '    MessageBox.Show("")
        'End If
        '-- etc

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click

        gridControlExcepciones.Rows.Clear()

    End Sub

    Private Sub enviar_correo(ByVal naveID As Integer, ByVal clave As String, ByVal Rows As DataGridViewRow, ByVal estado As Integer)

        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String
        Dim usuario As New Entidades.Usuarios
        Dim usuarioBU As New Framework.Negocios.UsuariosBU
        Dim correo As New Tools.Correo

        usuario = usuarioBU.buscarUsuario(Rows.Cells(10).Value)

        destinatarios = enviosCorreoBU.consulta_destinatarios_email(naveID, clave) + "," + usuario.PUserEmail

        Dim Email As String = "<html>" +
                                "<head>" +
                                  "<style type ='" + "text/css" + "'> body {display: block; margin: 8px; background: #FFFFFF;}#header{	position: fixed;	height: 62px;	top: 0;	left: 0;	right: 0;	color: #003366;	font-family: Arial, Helvetica, sans-serif;	font-size: 18px;	font-weight: bold;}#leftcolumn{	float: left;	position: fixed;	width: 2%;	margin: 1%;	padding-top: 3%;	top: 0;	left: 0;	right: 0;}#content{	width: 90%;	position: fixed;	margin: 1% 5%;		padding-top: 3%;	padding-bottom: 1%;}#rightcolumn{	float: right;	width: 5%;	margin: 1%;			padding-top: 3%;}#footer{	position: fixed;	width: 100%;	heigt: 5%;	bottom: 0;	margin: 0;	padding: 0;	color: #FFFFFF;}table.tableizer-table { 	font-family: Arial, Helvetica, sans-serif;	font-size: 9px;} .tableizer-table td {	padding: 4px;	margin: 0px;	border: 1px solid #FFFFFF;	border-color: #FFFFFF;	border: 1px solid #CCCCCC;	width: 200px;} .tableizer-table tr {	padding: 4px;	margin: 0;	color: #003366;	font-weight: bold;	background-color: #transparent; 	opacity: 1;}.tableizer-table th {	background-color: #003366; 	color: #FFFFFF;	font-weight: bold;	height: 30px;	font-size: 10px;}A:link {	text-decoration:none;color:#FFFFFF;} A:visited {	text-decoration:none;color:#FFFFFF;} A:active {	text-decoration:none;color:#FFFFFF;} A:hover {	text-decoration:none;color:#006699;} </style>" +
                                  "</head>" +
                                  "<body>" +
                                   "<div id='" + "wrapper" + "'>" +
                                    "<div id='" + "header" + "'>"

        If estado = 2 Then
            Email += "<img src='" + "http://grupoyuyin.com.mx/images/SAY170.jpg" + "'style='" + "vertical-align:middle" + "' height='" + "57" + "' widht='" + "125" + "'> Revisión de permiso: Permiso aprobado "
        End If
        If estado = 3 Then
            Email += "<img src='" + "http://grupoyuyin.com.mx/images/SAY170.jpg" + "'style='" + "vertical-align:middle" + "' height='" + "57" + "' widht='" + "125" + "'> Revisión de permiso: Permiso denegado "
        End If

        Email += "</div>" +
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
                                        "<th width ='" + "13%" + "'>Revisó</th>" +
                                        "<th width ='" + "15%" + "'>Nota</th>" +
                                        "<th>PyA</th>" +
                                        "<th>CdA</th>" +
                                        "<th width ='" + "10%" + "'>Tipo de excepcion</th>" +
                                        "<th width ='" + "15%" + "'>Motivo</th>" +
                                        "</tr>" +
                                       "</thead>" +
                                       "<tbody>" +
                                        "<tr>" +
                                            "<td>" + Rows.Cells(3).Value + "</td>" +
                                            "<td>" + Rows.Cells(5).Value + "</td>" +
                                            "<td>" + Rows.Cells(6).Value + "</td>" +
                                            "<td>" + Rows.Cells(7).Value + "</td>" +
                                            "<td>" + Rows.Cells(8).Value + "</td>" +
                                            "<td>" + Rows.Cells(9).Value + "</td>" +
                                            "<td>" + Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString + "</td>" +
                                            "<td>" + Rows.Cells(16).Value + "</td>"

        If Rows.Cells(17).Value Then
            Email += "<td> Si</td>"
        Else
            Email += "<td> No</td>"
        End If

        If Rows.Cells(18).Value Then
            Email += "<td> Si</td>"
        Else
            Email += "<td> No</td>"
        End If


        Email += "<td>" + Rows.Cells(19).Value + "</td>"


        Email += "<td>" + Rows.Cells(20).Value + "</td>" +
                   "</tr>" +
                "</tbody>" +
                "</table>" +
                       "</div>" +
                       "<div id='" + "footer" + "'>" +
                       "</div>" +
                   "</div>" +
                "</body>" +
                "</html>"

        correo.EnviarCorreoHtml(destinatarios, "checador@grupoyuyin.com.mx", "Revisión de Permiso", Email)

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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        gboxParametros.Height = 45
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        gboxParametros.Height = 121
    End Sub

    Private Sub btnCancelar_Click_1(sender As Object, e As EventArgs)

    End Sub
End Class