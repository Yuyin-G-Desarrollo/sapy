Imports System.Net

Public Class Correo
    Public Function EnviarCorreoHtml(ByVal _To As String, ByVal From As String, ByVal Asunto As String, ByVal Mensaje As String) As String
        EnviarCorreoHtml = ""
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient

        'BUSCA CONFIGURACION DEL SMTP EN LA BASE DE DATOS SEGUN EL SENDER
        Dim smtpBU As New Framework.Negocios.SmtpBU
        Dim smtp As New Entidades.SMTP
        smtp = smtpBU.buscarSmtp(From)
        If Not IsNothing(smtp) Then
            'CONFIGURACIÓN DEL STMP
            '_SMTP.Credentials = New System.Net.NetworkCredential("cuenta de correo", "contraseña")
            _SMTP.Credentials = New System.Net.NetworkCredential(From, smtp.PContrasena)
            _SMTP.Host = smtp.PServidor
            _SMTP.Port = smtp.PPuerto
            _SMTP.EnableSsl = smtp.PSsl

            Dim listaDestinos() As String = Split(_To, ",")
            Dim LastNonEmpty As Integer = -1
            For i As Integer = 0 To listaDestinos.Length - 1
                If listaDestinos(i) <> "" Then

                    ' CONFIGURACION DEL MENSAJExº
                    _Message.[To].Add(listaDestinos(i)) 'Cuenta de Correo al que se le quiere enviar el e-mail
                    _Message.From = New System.Net.Mail.MailAddress(From, From, System.Text.Encoding.UTF8) 'Quien lo envía
                    _Message.Subject = Asunto 'Sujeto del e-mail
                    _Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
                    _Message.Body = Mensaje 'contenido del mail
                    _Message.BodyEncoding = System.Text.Encoding.UTF8
                    _Message.Priority = System.Net.Mail.MailPriority.Normal
                    _Message.IsBodyHtml = True

                    'ENVIO
                    Try
                        _SMTP.Send(_Message)
                        _Message.[To].Clear()

                        'MessageBox.Show("Mensaje enviado correctamene", "Exito!", MessageBoxButtons.OK)
                    Catch ex As System.Net.Mail.SmtpException
                        'MessageBox.Show(ex.ToString, "Error!", MessageBoxButtons.OK)
                        _Message.[To].Clear()
                    End Try

                    LastNonEmpty += 1
                    listaDestinos(LastNonEmpty) = listaDestinos(i)
                End If
            Next
            ReDim Preserve listaDestinos(LastNonEmpty)




        Else
            EnviarCorreoHtml = "No existe configuracion de smtp para " + From
        End If
    End Function

    Public Function EnviarCorreoHtmlArchivoAdjunto(ByVal _To As String, ByVal From As String, ByVal Asunto As String, ByVal Mensaje As String, ByVal ArchivoAdjunto As System.Net.Mail.Attachment) As String
        EnviarCorreoHtmlArchivoAdjunto = ""

        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient

        'BUSCA CONFIGURACION DEL SMTP EN LA BASE DE DATOS SEGUN EL SENDER
        Dim smtpBU As New Framework.Negocios.SmtpBU
        Dim smtp As New Entidades.SMTP
        smtp = smtpBU.buscarSmtp(From)
        If Not IsNothing(smtp) Then
            'CONFIGURACIÓN DEL STMP
            '_SMTP.Credentials = New System.Net.NetworkCredential("cuenta de correo", "contraseña")
            _SMTP.Credentials = New System.Net.NetworkCredential(From, smtp.PContrasena)
            _SMTP.Host = smtp.PServidor
            _SMTP.Port = smtp.PPuerto
            _SMTP.EnableSsl = smtp.PSsl

            Dim listaDestinos() As String = Split(_To, ",")
            Dim LastNonEmpty As Integer = -1
            For i As Integer = 0 To listaDestinos.Length - 1
                If listaDestinos(i) <> "" Then

                    ' CONFIGURACION DEL MENSAJExº
                    _Message.[To].Add(listaDestinos(i)) 'Cuenta de Correo al que se le quiere enviar el e-mail
                    _Message.From = New System.Net.Mail.MailAddress(From, From, System.Text.Encoding.UTF8) 'Quien lo envía
                    _Message.Subject = Asunto 'Sujeto del e-mail
                    _Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
                    _Message.Body = Mensaje 'contenido del mail
                    _Message.BodyEncoding = System.Text.Encoding.UTF8
                    _Message.Priority = System.Net.Mail.MailPriority.Normal
                    _Message.IsBodyHtml = True
                    If i = 0 Then
                        _Message.Attachments.Add(ArchivoAdjunto)
                    End If


                    'ENVIO
                    Try
                        _SMTP.Send(_Message)
                        _Message.[To].Clear()

                        'MessageBox.Show("Mensaje enviado correctamene", "Exito!", MessageBoxButtons.OK)
                    Catch ex As System.Net.Mail.SmtpException
                        'MessageBox.Show(ex.ToString, "Error!", MessageBoxButtons.OK)
                        _Message.[To].Clear()
                    End Try

                    LastNonEmpty += 1
                    listaDestinos(LastNonEmpty) = listaDestinos(i)
                End If
            Next
            ReDim Preserve listaDestinos(LastNonEmpty)




        Else
            EnviarCorreoHtmlArchivoAdjunto = "No existe configuracion de smtp para " + From
        End If
    End Function

    Public Function EnviarCorreoHtmlVariosArchivosAdjuntos(ByVal _To As String, ByVal From As String, ByVal Asunto As String, ByVal Mensaje As String, ByVal lstArchivosAdjuntos As List(Of System.Net.Mail.Attachment)) As String
        EnviarCorreoHtmlVariosArchivosAdjuntos = ""

        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient

        'BUSCA CONFIGURACION DEL SMTP EN LA BASE DE DATOS SEGUN EL SENDER
        Dim smtpBU As New Framework.Negocios.SmtpBU
        Dim smtp As New Entidades.SMTP
        smtp = smtpBU.buscarSmtp(From)
        If Not IsNothing(smtp) Then
            'CONFIGURACIÓN DEL STMP
            '_SMTP.Credentials = New System.Net.NetworkCredential("cuenta de correo", "contraseña")
            _SMTP.Credentials = New System.Net.NetworkCredential(From, smtp.PContrasena)
            _SMTP.Host = smtp.PServidor
            _SMTP.Port = smtp.PPuerto
            _SMTP.EnableSsl = smtp.PSsl

            Dim listaDestinos() As String = Split(_To, ",")
            Dim LastNonEmpty As Integer = -1
            For i As Integer = 0 To listaDestinos.Length - 1
                If listaDestinos(i) <> "" Then

                    ' CONFIGURACION DEL MENSAJExº
                    _Message.[To].Add(listaDestinos(i)) 'Cuenta de Correo al que se le quiere enviar el e-mail
                    _Message.From = New System.Net.Mail.MailAddress(From, From, System.Text.Encoding.UTF8) 'Quien lo envía
                    _Message.Subject = Asunto 'Sujeto del e-mail
                    _Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
                    _Message.Body = Mensaje 'contenido del mail
                    _Message.BodyEncoding = System.Text.Encoding.UTF8
                    _Message.Priority = System.Net.Mail.MailPriority.Normal
                    _Message.IsBodyHtml = True
                    If i = 0 Then
                        For Each adjunto As System.Net.Mail.Attachment In lstArchivosAdjuntos
                            _Message.Attachments.Add(adjunto)
                        Next
                    End If


                    'ENVIO
                    Try
                        _SMTP.Send(_Message)
                        _Message.[To].Clear()

                        'MessageBox.Show("Mensaje enviado correctamene", "Exito!", MessageBoxButtons.OK)
                    Catch ex As System.Net.Mail.SmtpException
                        'MessageBox.Show(ex.ToString, "Error!", MessageBoxButtons.OK)
                        _Message.[To].Clear()
                    End Try

                    LastNonEmpty += 1
                    listaDestinos(LastNonEmpty) = listaDestinos(i)
                End If
            Next
            ReDim Preserve listaDestinos(LastNonEmpty)




        Else
            EnviarCorreoHtmlVariosArchivosAdjuntos = "No existe configuracion de smtp para " + From
        End If
    End Function

    Public Function EnviarCorreoFacturasHtmlVariosArchivosAdjuntos(ByVal _To As String, ByVal From As String, ByVal Asunto As String, ByVal Mensaje As String, ByVal lstArchivosAdjuntos As List(Of System.Net.Mail.Attachment)) As Entidades.DatosCorreo
        ServicePointManager.SecurityProtocol = 3072 'PROTOCOLO DE CONEXION SEGURA TLS 1.2 (NO BORRAR ATTE: MARCOS)

        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim mDescripError As String = String.Empty
        Dim SeEnvioCorreo As Boolean = False
        Dim entCorreo As New Entidades.DatosCorreo

        'BUSCA CONFIGURACION DEL SMTP EN LA BASE DE DATOS SEGUN EL SENDER
        Dim smtpBU As New Framework.Negocios.SmtpBU
        Dim smtp As New Entidades.SMTP
        smtp = smtpBU.buscarSmtp(From)
        If Not IsNothing(smtp) Then
            'CONFIGURACIÓN DEL STMP
            '_SMTP.Credentials = New System.Net.NetworkCredential("cuenta de correo", "contraseña")
            _SMTP.Credentials = New System.Net.NetworkCredential(From, smtp.PContrasena)
            _SMTP.Host = smtp.PServidor
            _SMTP.Port = smtp.PPuerto
            _SMTP.EnableSsl = smtp.PSsl

            Dim listaDestinos() As String = Split(_To, ";")
            Dim LastNonEmpty As Integer = -1
            For i As Integer = 0 To listaDestinos.Length - 1
                If listaDestinos(i) <> "" Then

                    ' CONFIGURACION DEL MENSAJExº
                    _Message.[To].Add(listaDestinos(i)) 'Cuenta de Correo al que se le quiere enviar el e-mail
                    _Message.From = New System.Net.Mail.MailAddress(From, From, System.Text.Encoding.UTF8) 'Quien lo envía
                    _Message.Subject = Asunto 'Sujeto del e-mail
                    _Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
                    _Message.Body = Mensaje 'contenido del mail
                    _Message.BodyEncoding = System.Text.Encoding.UTF8
                    _Message.Priority = System.Net.Mail.MailPriority.Normal
                    _Message.IsBodyHtml = True
                    If i = 0 Then
                        For Each adjunto As System.Net.Mail.Attachment In lstArchivosAdjuntos
                            _Message.Attachments.Add(adjunto)
                        Next
                    End If


                    'ENVIO
                    Try
                        _SMTP.Send(_Message)
                        _Message.[To].Clear()
                        ' .. si no hubo error
                        If Err.Number = 0 Then
                            SeEnvioCorreo = True
                            mDescripError = mDescripError & "Exito al enviar el correo"
                        ElseIf Err.Number = -2147220973 Then
                            SeEnvioCorreo = False
                            mDescripError = mDescripError & "<->nombre del Servidor incorrecto o número de puerto incorrecto"
                        ElseIf Err.Number = -2147220974 Then
                            SeEnvioCorreo = False
                            mDescripError = mDescripError & "<->El transporte perdió la conexión al servidor"
                        ElseIf Err.Number = -2147220975 Then
                            SeEnvioCorreo = False
                            mDescripError = mDescripError & "<->Error en el nombre de usuario, o en el password"
                        ElseIf Err.Number = -2147220977 Then
                            SeEnvioCorreo = False
                            mDescripError = mDescripError & "<->El servidor rechazó una o más direcciones de destinatarios"
                        ElseIf Err.Number = -2147220980 Then
                            mDescripError = mDescripError & "<->Se requiere al menos un destinatario, pero no se encontró ninguno"
                            SeEnvioCorreo = False
                        Else
                            mDescripError = mDescripError & "<->Error : " & Err.Number & vbNewLine & Err.Description
                            SeEnvioCorreo = False
                        End If

                        entCorreo.CorreoEnviado = SeEnvioCorreo
                        entCorreo.Asunto = Asunto
                        entCorreo.Destinatarios = _To
                        entCorreo.From = From
                        entCorreo.Mensaje = Mensaje
                        entCorreo.DescripcionStatusCorreo = mDescripError

                        'MessageBox.Show("Mensaje enviado correctamene", "Exito!", MessageBoxButtons.OK)
                    Catch ex As System.Net.Mail.SmtpException
                        'MessageBox.Show(ex.ToString, "Error!", MessageBoxButtons.OK)
                        _Message.[To].Clear()

                    Finally
                        entCorreo.CorreoEnviado = SeEnvioCorreo
                        entCorreo.Asunto = Asunto
                        entCorreo.Destinatarios = _To
                        entCorreo.From = From
                        entCorreo.Mensaje = Mensaje
                        entCorreo.DescripcionStatusCorreo = mDescripError
                        _Message.Dispose()
                    End Try

                    LastNonEmpty += 1
                    listaDestinos(LastNonEmpty) = listaDestinos(i)
                End If
            Next
            ReDim Preserve listaDestinos(LastNonEmpty)
        Else
            'EnviarCorreoFacturasHtmlVariosArchivosAdjuntos = "No existe configuracion de smtp para " + From
            SeEnvioCorreo = False
            entCorreo.CorreoEnviado = SeEnvioCorreo
            entCorreo.Asunto = Asunto
            entCorreo.Destinatarios = _To
            entCorreo.From = From
            entCorreo.Mensaje = Mensaje
            entCorreo.DescripcionStatusCorreo = mDescripError
        End If

        Return entCorreo
    End Function


    Public Function EnviarCorreoFacturasHtmlVariosArchivosAdjuntosPruebas(ByVal _To As String, ByVal From As String, ByVal Asunto As String, ByVal Mensaje As String, ByVal lstArchivosAdjuntos As List(Of System.Net.Mail.Attachment)) As Entidades.DatosCorreo
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim mDescripError As String = String.Empty
        Dim SeEnvioCorreo As Boolean = False
        Dim entCorreo As New Entidades.DatosCorreo

        'BUSCA CONFIGURACION DEL SMTP EN LA BASE DE DATOS SEGUN EL SENDER
        Dim smtpBU As New Framework.Negocios.SmtpBU
        Dim smtp As New Entidades.SMTP
        smtp = smtpBU.buscarSmtp("say_muestras@grupoyuyin.com.mx")
        If Not IsNothing(smtp) Then
            'CONFIGURACIÓN DEL STMP
            '_SMTP.Credentials = New System.Net.NetworkCredential("cuenta de correo", "contraseña")
            _SMTP.Credentials = New System.Net.NetworkCredential("say_muestras@grupoyuyin.com.mx", smtp.PContrasena)
            _SMTP.Host = smtp.PServidor
            _SMTP.Port = smtp.PPuerto
            _SMTP.EnableSsl = smtp.PSsl
            ' _SMTP.Timeout = 1000

            Dim listaDestinos() As String = Split(_To, ";")
            Dim LastNonEmpty As Integer = -1
            For i As Integer = 0 To listaDestinos.Length - 1
                If listaDestinos(i) <> "" Then

                    ' CONFIGURACION DEL MENSAJExº
                    _Message.[To].Add(listaDestinos(i)) 'Cuenta de Correo al que se le quiere enviar el e-mail
                    _Message.From = New System.Net.Mail.MailAddress("say_muestras@grupoyuyin.com.mx", "say_muestras@grupoyuyin.com.mx", System.Text.Encoding.UTF8) 'Quien lo envía
                    _Message.Subject = Asunto 'Sujeto del e-mail
                    _Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
                    _Message.Body = Mensaje 'contenido del mail
                    _Message.BodyEncoding = System.Text.Encoding.UTF8
                    _Message.Priority = System.Net.Mail.MailPriority.Normal
                    _Message.IsBodyHtml = True
                    If i = 0 Then
                        For Each adjunto As System.Net.Mail.Attachment In lstArchivosAdjuntos
                            _Message.Attachments.Add(adjunto)
                        Next
                    End If


                    'ENVIO
                    Try
                        _SMTP.Send(_Message)
                        _Message.[To].Clear()
                        ' .. si no hubo error
                        If Err.Number = 0 Then
                            SeEnvioCorreo = True
                            mDescripError = mDescripError & "Exito al enviar el correo"
                        ElseIf Err.Number = -2147220973 Then
                            SeEnvioCorreo = False
                            mDescripError = mDescripError & "<->nombre del Servidor incorrecto o número de puerto incorrecto"
                        ElseIf Err.Number = -2147220974 Then
                            SeEnvioCorreo = False
                            mDescripError = mDescripError & "<->El transporte perdió la conexión al servidor"
                        ElseIf Err.Number = -2147220975 Then
                            SeEnvioCorreo = False
                            mDescripError = mDescripError & "<->Error en el nombre de usuario, o en el password"
                        ElseIf Err.Number = -2147220977 Then
                            SeEnvioCorreo = False
                            mDescripError = mDescripError & "<->El servidor rechazó una o más direcciones de destinatarios"
                        ElseIf Err.Number = -2147220980 Then
                            mDescripError = mDescripError & "<->Se requiere al menos un destinatario, pero no se encontró ninguno"
                            SeEnvioCorreo = False
                        Else
                            mDescripError = mDescripError & "<->Error : " & Err.Number & vbNewLine & Err.Description
                            SeEnvioCorreo = False
                        End If

                        entCorreo.CorreoEnviado = SeEnvioCorreo
                        entCorreo.Asunto = Asunto
                        entCorreo.Destinatarios = _To
                        entCorreo.From = From
                        entCorreo.Mensaje = Mensaje
                        entCorreo.DescripcionStatusCorreo = mDescripError

                        'MessageBox.Show("Mensaje enviado correctamene", "Exito!", MessageBoxButtons.OK)
                    Catch ex As System.Net.Mail.SmtpException
                        'MessageBox.Show(ex.ToString, "Error!", MessageBoxButtons.OK)
                        _Message.[To].Clear()

                    Finally
                        entCorreo.CorreoEnviado = SeEnvioCorreo
                        entCorreo.Asunto = Asunto
                        entCorreo.Destinatarios = _To
                        entCorreo.From = From
                        entCorreo.Mensaje = Mensaje
                        entCorreo.DescripcionStatusCorreo = mDescripError
                    End Try

                    LastNonEmpty += 1
                    listaDestinos(LastNonEmpty) = listaDestinos(i)
                End If
            Next
            ReDim Preserve listaDestinos(LastNonEmpty)
        Else
            'EnviarCorreoFacturasHtmlVariosArchivosAdjuntos = "No existe configuracion de smtp para " + From
            SeEnvioCorreo = False
            entCorreo.CorreoEnviado = SeEnvioCorreo
            entCorreo.Asunto = Asunto
            entCorreo.Destinatarios = _To
            entCorreo.From = From
            entCorreo.Mensaje = Mensaje
            entCorreo.DescripcionStatusCorreo = mDescripError
        End If

        Return entCorreo
    End Function


    Public Function EnviarCorreoFacturasHtmlVariosArchivosAdjuntosPruebas25(ByVal _To As String, ByVal From As String, ByVal Asunto As String, ByVal Mensaje As String, ByVal lstArchivosAdjuntos As List(Of System.Net.Mail.Attachment)) As Entidades.DatosCorreo
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim mDescripError As String = String.Empty
        Dim SeEnvioCorreo As Boolean = False
        Dim entCorreo As New Entidades.DatosCorreo

        'BUSCA CONFIGURACION DEL SMTP EN LA BASE DE DATOS SEGUN EL SENDER
        Dim smtpBU As New Framework.Negocios.SmtpBU
        Dim smtp As New Entidades.SMTP
        smtp = smtpBU.buscarSmtp(From)
        If Not IsNothing(smtp) Then
            'CONFIGURACIÓN DEL STMP
            '_SMTP.Credentials = New System.Net.NetworkCredential("cuenta de correo", "contraseña")
            _SMTP.Credentials = New System.Net.NetworkCredential(From, smtp.PContrasena)
            _SMTP.Host = smtp.PServidor
            _SMTP.Port = "26"
            _SMTP.EnableSsl = False
            ' _SMTP.Timeout = 1000

            Dim listaDestinos() As String = Split(_To, ";")
            Dim LastNonEmpty As Integer = -1
            For i As Integer = 0 To listaDestinos.Length - 1
                If listaDestinos(i) <> "" Then

                    ' CONFIGURACION DEL MENSAJExº
                    _Message.[To].Add(listaDestinos(i)) 'Cuenta de Correo al que se le quiere enviar el e-mail
                    _Message.From = New System.Net.Mail.MailAddress(From, From, System.Text.Encoding.UTF8) 'Quien lo envía
                    _Message.Subject = Asunto 'Sujeto del e-mail
                    _Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
                    _Message.Body = Mensaje 'contenido del mail
                    _Message.BodyEncoding = System.Text.Encoding.UTF8
                    _Message.Priority = System.Net.Mail.MailPriority.Normal
                    _Message.IsBodyHtml = True
                    If i = 0 Then
                        For Each adjunto As System.Net.Mail.Attachment In lstArchivosAdjuntos
                            _Message.Attachments.Add(adjunto)
                        Next
                    End If


                    'ENVIO
                    Try
                        _SMTP.Send(_Message)
                        _Message.[To].Clear()
                        ' .. si no hubo error
                        If Err.Number = 0 Then
                            SeEnvioCorreo = True
                            mDescripError = mDescripError & "Exito al enviar el correo"
                        ElseIf Err.Number = -2147220973 Then
                            SeEnvioCorreo = False
                            mDescripError = mDescripError & "<->nombre del Servidor incorrecto o número de puerto incorrecto"
                        ElseIf Err.Number = -2147220974 Then
                            SeEnvioCorreo = False
                            mDescripError = mDescripError & "<->El transporte perdió la conexión al servidor"
                        ElseIf Err.Number = -2147220975 Then
                            SeEnvioCorreo = False
                            mDescripError = mDescripError & "<->Error en el nombre de usuario, o en el password"
                        ElseIf Err.Number = -2147220977 Then
                            SeEnvioCorreo = False
                            mDescripError = mDescripError & "<->El servidor rechazó una o más direcciones de destinatarios"
                        ElseIf Err.Number = -2147220980 Then
                            mDescripError = mDescripError & "<->Se requiere al menos un destinatario, pero no se encontró ninguno"
                            SeEnvioCorreo = False
                        Else
                            mDescripError = mDescripError & "<->Error : " & Err.Number & vbNewLine & Err.Description
                            SeEnvioCorreo = False
                        End If

                        entCorreo.CorreoEnviado = SeEnvioCorreo
                        entCorreo.Asunto = Asunto
                        entCorreo.Destinatarios = _To
                        entCorreo.From = From
                        entCorreo.Mensaje = Mensaje
                        entCorreo.DescripcionStatusCorreo = mDescripError

                        'MessageBox.Show("Mensaje enviado correctamene", "Exito!", MessageBoxButtons.OK)
                    Catch ex As System.Net.Mail.SmtpException
                        'MessageBox.Show(ex.ToString, "Error!", MessageBoxButtons.OK)
                        _Message.[To].Clear()

                    Finally
                        entCorreo.CorreoEnviado = SeEnvioCorreo
                        entCorreo.Asunto = Asunto
                        entCorreo.Destinatarios = _To
                        entCorreo.From = From
                        entCorreo.Mensaje = Mensaje
                        entCorreo.DescripcionStatusCorreo = mDescripError
                    End Try

                    LastNonEmpty += 1
                    listaDestinos(LastNonEmpty) = listaDestinos(i)
                End If
            Next
            ReDim Preserve listaDestinos(LastNonEmpty)
        Else
            'EnviarCorreoFacturasHtmlVariosArchivosAdjuntos = "No existe configuracion de smtp para " + From
            SeEnvioCorreo = False
            entCorreo.CorreoEnviado = SeEnvioCorreo
            entCorreo.Asunto = Asunto
            entCorreo.Destinatarios = _To
            entCorreo.From = From
            entCorreo.Mensaje = Mensaje
            entCorreo.DescripcionStatusCorreo = mDescripError
        End If

        Return entCorreo
    End Function
    Public Sub enviarcorreoReporteEntrada(nombreArchivo As String, ByVal destino As String, ByVal nave As String, Optional ByVal FEcha As Date = Nothing, Optional ByVal FechaActual As Boolean = True)

        'enviar_correo(NaveID, "ENVIO_DEPOSITO_CUENTAS")               
        Dim archivoAdjunto = New System.Net.Mail.Attachment(nombreArchivo)


        'Dim objBU As New Negocios.RecalculosBU
        'Dim destinatarios As String
        Dim correo As New Tools.Correo
        'destinatarios = objBU.obtieneDestinosCorreo(cmbPatron.SelectedValue)

        If FechaActual = True Then
            FEcha = Date.Now
        End If

        If destino <> "" Then

            Dim Email As String = ""
            Email += "<html>"
            Email &= "<head>"
            Email &= "<style type ='text/css'>" &
                    "body {display:block; margin:8px; background:#FFFFFF;}" &
                    "#header {position:fixed; height:62px; top:0; left:0; right:0; color:#003366; font-family:Arial, Helvetica, sans-serif; font-size:18px; font-weight: bold;}" &
                    "#leftcolumn {float:left; position:fixed; width:2%; margin:1%; padding-top:3%; top:0; left:0; right:0;}" &
                    "#content {width:90%; position:fixed; margin:1% 5%; padding-top:3%; padding-bottom:1%;}" &
                    "#rightcolumn {float:right; width:5%; margin:1%; padding-top:3%;}" &
                    "#footer {position:fixed; width:100%; heigt:5%; bottom:0; margin:0; padding:0; color:#FFFFFF;}" &
                    "table.tableizer-table {font-family:Arial, Helvetica, sans-serif; font-size:9px;} " &
                    ".tableizer-table td {padding:4px; margin:0px; border:1px solid #FFFFFF;	border-color: #FFFFFF; border:1px solid #CCCCCC; width:200px;}" &
                    ".tableizer-table tr {padding: 4px; margin:0; color:#003366; font-weight:bold; background-color:#transparent; opacity:1;}" &
                    ".tableizer-table th {background-color: #003366; color:#FFFFFF; font-weight:bold; height:30px; font-size:10px;}" &
                    "A:link {text-decoration:none; color:#FFFFFF;}" &
                    "A:visited {text-decoration:none; color:#FFFFFF;}" &
                    "A:active {text-decoration:none; color:#FFFFFF;}" &
                    "A:hover {text-decoration:none;color:#006699;} "
            Email &= "</style>"
            Email &= "</head>"
            Email &= "<body>"
            Email &= "<div id='wrapper'>" &
                    "<div id='header'>" &
                    "</div>" &
                    "<div id='leftcolumn'></div>" &
                    "<div id='rightcolumn'></div>"
            Email &= "<div id='content'>" &
                    "<p>A quien corresponda,<p>" &
                    "<p>Se anexa el reporte en PDF de los lotes ingresados al CEDIS del día" & " "
            Email &= ""
            If FechaActual = True Then
                Email &= FEcha.ToString("dd/MM/yyyy") & " a las " & FEcha.ToString("HH:mm:ss") & "</p>" &
                    "<p>Atentamente: Grupo Yuyin.</p>"
            Else
                Email &= FEcha.ToString("dd/MM/yyyy") & "</p>" &
                    "<p>Atentamente: Grupo Yuyin.</p>"
            End If

            Email &= "</div>"
            Email &= "<div id='footer'></div>"
            Email &= "</div>"
            Email &= "</body>"
            Email &= "</html>"

            correo.EnviarCorreoHtmlArchivoAdjunto(destino, "servicioselectronicos@grupoyuyin.com", "Reporte de ingreso de lotes al CEDIS de  " & nave & " " & FEcha, Email, archivoAdjunto)
            archivoAdjunto.Dispose()
        End If
        Try
            My.Computer.FileSystem.DeleteFile(nombreArchivo)
        Catch ex As Exception
        End Try
    End Sub
End Class
