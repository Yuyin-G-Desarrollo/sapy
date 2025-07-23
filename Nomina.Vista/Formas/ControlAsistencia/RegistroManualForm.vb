Imports Entidades
Imports Tools

Public Class RegistroManualForm

    Public registroCheckID As New List(Of Integer)
    Public registroCheckNormal As Boolean
    'Public registroCheckAutomatico As Boolean
    Public naveID As Integer
    Public colaboradorID As Integer
    Public noRegistro As Boolean = False
    Public fecha As DateTime
    Public tipo As Int32 = 0
    Public colaboradorNombre As String

    Private Sub RegistroManualForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtpRegistroManual.Format = DateTimePickerFormat.Custom
        dtpRegistroManual.CustomFormat = "HH:mm:ss tt"

        'If registroCheckNormal Then
        '    rbtnNoRegistro.Visible = False
        'End If

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If txtNota.TextLength < 5 Then

            show_message("Advertencia", "Debe justificar el registro manual")

        Else

            If rbtnNormal.Checked Or rbtnRetardoMenor.Checked Or rbtnRetardoMayor.Checked Or rbtnNoRegistro.Checked Or rbtnComida.Checked Then

                Dim registroCheckE As New Entidades.RegistroCheck
                Dim registroCheckBU As New Negocios.RegistroCheckBU
                Dim colaborador As New Colaborador
                Dim nave As New Naves
                Dim excepcion As New RegistroExcepciones
                Dim bandera As Int32 = 0
                Dim fechaCompleta As DateTime

                If noRegistro = True Then
                    bandera = 1
                    fechaCompleta = CDate(fecha + " " + dtpRegistroManual.Value.ToShortTimeString)
                Else
                    bandera = 3
                    fechaCompleta = dtpRegistroManual.Value
                End If



                If rbtnNoRegistro.Checked Then

                    For Each item As Integer In registroCheckID

                        registroCheckE.PId = item
                        nave.PNaveId = naveID
                        registroCheckE.Pregcheck_nave = nave
                        'registroCheckE.PCheck_manual = dtpRegistroManual.Value
                        registroCheckE.PCheck_manual = fechaCompleta
                        colaborador.PColaboradorid = colaboradorID
                        registroCheckE.PCheck_Colaborador = colaborador
                        registroCheckE.PCheck_Tipo = 0
                        registroCheckE.PCheck_Nota = txtNota.Text
                        registroCheckBU.guardar_RegistroCheck(bandera, registroCheckE)
                        enviar_correo(naveID, registroCheckE, "ENVIO_NOTIFICACION_REGISTRO_MANUAL")

                    Next

                Else

                    registroCheckE.PId = registroCheckID.Item(0)
                    nave.PNaveId = naveID
                    registroCheckE.Pregcheck_nave = nave
                    'registroCheckE.PCheck_manual = dtpRegistroManual.Value
                    registroCheckE.PCheck_manual = fechaCompleta
                    colaborador.PColaboradorid = colaboradorID
                    registroCheckE.PCheck_Colaborador = colaborador

                    If rbtnNormal.Checked Then
                        registroCheckE.PCheck_Resultado = 1
                    End If
                    If rbtnRetardoMenor.Checked Then
                        registroCheckE.PCheck_Resultado = 2

                    End If
                    If rbtnRetardoMayor.Checked Then
                        registroCheckE.PCheck_Resultado = 3

                    End If
                    If rbtnComida.Checked Then
                        registroCheckE.PCheck_Resultado = 7
                    End If
                    registroCheckE.PCheck_Tipo = tipo
                    registroCheckE.PCheck_Nota = txtNota.Text
                    registroCheckBU.guardar_RegistroCheck(bandera, registroCheckE)
                    enviar_correo(naveID, registroCheckE, "ENVIO_NOTIFICACION_REGISTRO_MANUAL")

                End If

                Me.Close()
            Else

                show_message("Advertencia", "Debe seleccionar un tipo de registro")

            End If


        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
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

    Private Sub txtNota_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNota.KeyPress
        If Char.IsLetter(e.KeyChar) Then

            e.KeyChar = Char.ToUpper(e.KeyChar)

        End If
    End Sub

    Private Sub enviar_correo(ByVal naveID As Integer, ByVal registro As Entidades.RegistroCheck, ByVal clave As String)

        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String
        Dim correo As New Tools.Correo

        destinatarios = enviosCorreoBU.consulta_destinatarios_email(naveID, clave)

        Dim Email As String = "<html>"
        Email += "<head>"
        Email += "<style type ='" + "text/css" + "'> body {display: block; margin: 8px; background: #FFFFFF;}#header{	position: fixed;	height: 62px;	top: 0;	left: 0;	right: 0;	color: #003366;	font-family: Arial, Helvetica, sans-serif;	font-size: 18px;	font-weight: bold;}#leftcolumn{	float: left;	position: fixed;	width: 2%;	margin: 1%;	padding-top: 3%;	top: 0;	left: 0;	right: 0;}#content{	width: 90%;	position: fixed;	margin: 1% 5%;		padding-top: 3%;	padding-bottom: 1%;}#rightcolumn{	float: right;	width: 5%;	margin: 1%;			padding-top: 3%;}#footer{	position: fixed;	width: 100%;	heigt: 5%;	bottom: 0;	margin: 0;	padding: 0;	color: #FFFFFF;}table.tableizer-table { 	font-family: Arial, Helvetica, sans-serif;	font-size: 9px;} .tableizer-table td {	padding: 4px;	margin: 0px;	border: 1px solid #FFFFFF;	border-color: #FFFFFF;	border: 1px solid #CCCCCC;	width: 200px;} .tableizer-table tr {	padding: 4px;	margin: 0;	color: #003366;	font-weight: bold;	background-color: #transparent; 	opacity: 1;}.tableizer-table th {	background-color: #003366; 	color: #FFFFFF;	font-weight: bold;	height: 30px;	font-size: 10px;}A:link {	text-decoration:none;color:#FFFFFF;} A:visited {	text-decoration:none;color:#FFFFFF;} A:active {	text-decoration:none;color:#FFFFFF;} A:hover {	text-decoration:none;color:#006699;} </style>" +
                                  "</head>" +
                                  "<body>" +
                                   "<div id='" + "wrapper" + "'>" +
                                    "<div id='" + "header" + "'>" +
                                    "<img src='" + "http://grupoyuyin.com.mx/images/SAY170.jpg" + "'style='" + "vertical-align:middle" + "' height='" + "57" + "' widht='" + "125" + "'> Registro Manual " +
                                   "</div>" +
                                    "<div id='" + "leftcolumn" + "'>" +
                                    "</div>" +
                                    "<div id='" + "rightcolumn" + "'>" +
                                    "</div>" + "<div id='" + "content" + "'>" +
                                      "<table id='" + "mi_tabla" + "' class='" + "tableizer-table" + "'>" +
                                       "<thead>" +
                                        "<tr class='" + "tableizer-firstrow" + "'>" +
                                        "<th width ='" + "20%" + "'>Nombre</th>" +
                                        "<th>Fecha</th>" +
                                        "<th width ='" + "7%" + "'>Hora</th>" +
                                        "<th width ='" + "13%" + "'>Capturó</th>" +
                                        "<th width ='" + "15%" + "'>Nota</th>" +
                                        "<th>PyA</th>" +
                                        "<th>CdA</th>" +
                                        "<th width ='" + "10%" + "'>Tipo de registro</th>" +
                                        "</tr>" +
                                       "</thead>" +
                                       "<tbody>" +
                                        "<tr>"
        Email += "<td>" + colaboradorNombre + "</td>"
        ' "<th width ='" + "15%" + "'>Departamento</th>" +
        'Email += "<td>" + registro.PCheck_Colaborador.PIDepartamento.DNombre.ToString + "</td>"
        Email += "<td>" + registro.PCheck_manual.ToShortDateString + "</td>"
        Email += "<td>" + registro.PCheck_manual.ToLongTimeString + "</td>"
        Email += "<td>" + Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString + "</td>"

        Email += "<td>" + registro.PCheck_Nota.ToString + "</td>"

        If registro.PCheck_Resultado = 1 Or registro.PCheck_Resultado = 7 Then
            Email += "<td> Si</td>"
            Email += "<td> Si</td>"
        Else
            Email += "<td> No</td>"
            Email += "<td> No</td>"
        End If

        If registro.PCheck_Resultado = 1 Then
            Email += "<td>Registro a tiempo</td>"
        ElseIf registro.PCheck_Resultado = 2 Then
            Email += "<td>Retardo menor</td>"
        ElseIf registro.PCheck_Resultado = 3 Then
            Email += "<td>Retardo mayor</td>"
        ElseIf registro.PCheck_Resultado = 7 Then
            Email += "<td>Comida</td>"
        Else
            Email += "<td>No registro</td>"
        End If

        Email += "</tr>" +
                            "</tbody>" +
                        "</table>" +
                    "</div>" +
                    "<div id='" + "footer" + "'>" +
                    "</div>" +
                "</div>" +
                "</body>" +
            "</html>"

        correo.EnviarCorreoHtml(destinatarios, "checador@grupoyuyin.com.mx", "Registro Manual", Email)

    End Sub
End Class