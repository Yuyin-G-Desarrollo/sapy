Imports System.Xml

Public Class PruebaCorreo_Form
    Private BOTON_ENVIAR1 As Integer = 1
    Private BOTON_ENVIAR2 As Integer = 2
    Private BOTON_ENVIAR3 As Integer = 3
    Private BOTON_ENVIAR4 As Integer = 4
    Private BOTON_ENVIAR5 As Integer = 5
    Private BOTON_ENVIAR6 As Integer = 6
    Private objBU As New Tools.Correo
    Private smtBU As New Framework.Negocios.SmtpBU
    Private plantillaEnviarHacia As String = "b.tecnologia@grupoyuyin.com.mx"
    Private plantillaEnviarDesde As String = "servicioselectronicos@grupoyuyin.com"

    Private Sub btnEnviarCorreo1_Click(sender As Object, e As EventArgs) Handles btnEnviarCorreo1.Click
        Try
            Cursor = Cursors.WaitCursor
            EnviarCorreo(BOTON_ENVIAR1)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.Controles.Mensajes_Y_Alertas(Tools.Mensajes.Warning, "Ha ocurrido un error, no se envio el correo")
        End Try

    End Sub

    Private Sub EnviarCorreo(boton As Integer)
        Dim destinatario As String = String.Empty
        Dim remitente As String = String.Empty
        Dim asunto As String = "Esto es una prubea"
        Dim mensaje As String = String.Empty

        Select Case boton
            Case BOTON_ENVIAR1
                destinatario = txtEnviarHacia1.Text
                remitente = txtEnviarDe1.Text
                mensaje = CargarMensaje(BOTON_ENVIAR1)
            Case BOTON_ENVIAR2
                destinatario = txtEnviarHacia2.Text
                remitente = txtEnviarDe2.Text
                mensaje = CargarMensaje(BOTON_ENVIAR2)
            Case BOTON_ENVIAR3
                destinatario = txtEnviarHacia3.Text
                remitente = txtEnviarDe3.Text
                mensaje = CargarMensaje(BOTON_ENVIAR3)
            Case BOTON_ENVIAR4
                destinatario = txtEnviarHacia4.Text
                remitente = txtEnviarDe4.Text
                mensaje = CargarMensaje(BOTON_ENVIAR4)
            Case BOTON_ENVIAR5
                destinatario = txtEnviarHacia5.Text
                remitente = txtEnviarDe5.Text
                mensaje = CargarMensaje(BOTON_ENVIAR5)
            Case BOTON_ENVIAR6
                destinatario = txtEnviarHacia6.Text
                remitente = txtEnviarDe6.Text
                mensaje = CargarMensaje(BOTON_ENVIAR6)
            Case Else
                MsgBox("Error")
        End Select

        If Not String.IsNullOrEmpty(destinatario) Then
            If Not String.IsNullOrEmpty(remitente) Then
                If Not String.IsNullOrEmpty(mensaje) Then
                    objBU.EnviarCorreoHtml(destinatario, remitente, "Esto es una prueba", mensaje)
                Else
                    MsgBox("No se recuperó el mensaje del correo")
                End If
            Else
                MsgBox("No se encontró el remitente")
            End If
        Else
            MsgBox("No se encontró el destinatario")
        End If
    End Sub

    Private Function CargarMensaje(boton As Integer) As String
        Dim mensaje As New XDocument
        Dim str As String

        mensaje.Add(
            New XElement("html",
            New XElement("body"),
            New XElement("p"), "Esto es una prueba enviada desde el boton Enviar" + boton.ToString)
        )
        'htmlNode = mensaje.CreateElement("html")
        'mensaje.AppendChild(htmlNode)

        'bodyNode = mensaje.CreateElement("body")
        'htmlNode.AppendChild(bodyNode)
        'auxNode = mensaje.CreateElement("p")
        'auxNode.InnerText = "Este es un mensaje enviado desde boton" + boton.ToString
        'bodyNode.AppendChild(auxNode)
        str = mensaje.ToString

        Return str
    End Function

    Private Sub PruebaCorreo_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarPlantillas()
    End Sub

    Private Sub CargarPlantillas()
        txtEnviarDe1.Text = plantillaEnviarDesde
        txtEnviarDe2.Text = plantillaEnviarDesde
        txtEnviarDe3.Text = plantillaEnviarDesde
        txtEnviarDe4.Text = plantillaEnviarDesde
        txtEnviarDe5.Text = plantillaEnviarDesde
        txtEnviarDe6.Text = plantillaEnviarDesde

        txtEnviarHacia1.Text = plantillaEnviarHacia
        txtEnviarHacia2.Text = plantillaEnviarHacia
        txtEnviarHacia3.Text = plantillaEnviarHacia
        txtEnviarHacia4.Text = plantillaEnviarHacia
        txtEnviarHacia5.Text = plantillaEnviarHacia
        txtEnviarHacia6.Text = plantillaEnviarHacia
        txtEnviarHacia1.Text = plantillaEnviarHacia
        txtEnviarHacia1.Text = plantillaEnviarHacia
        txtEnviarHacia1.Text = plantillaEnviarHacia
        txtEnviarDe1.Text = plantillaEnviarDesde
    End Sub

    Private Sub btnEnviarCorreo2_Click(sender As Object, e As EventArgs) Handles btnEnviarCorreo2.Click
        EnviarCorreo(BOTON_ENVIAR2)
    End Sub

    Private Sub btnEnviarCorreo3_Click(sender As Object, e As EventArgs) Handles btnEnviarCorreo3.Click
        EnviarCorreo(BOTON_ENVIAR3)
    End Sub

    Private Sub btnEnviarCorreo4_Click(sender As Object, e As EventArgs) Handles btnEnviarCorreo4.Click
        EnviarCorreo(BOTON_ENVIAR4)
    End Sub

    Private Sub btnEnviarCorreo5_Click(sender As Object, e As EventArgs) Handles btnEnviarCorreo5.Click
        EnviarCorreo(BOTON_ENVIAR5)
    End Sub

    Private Sub btnEnviarCorreo6_Click(sender As Object, e As EventArgs) Handles btnEnviarCorreo6.Click
        EnviarCorreo(BOTON_ENVIAR6)
    End Sub

    Private Sub btnRecuperarCorreos_Click(sender As Object, e As EventArgs) Handles btnRecuperarCorreos.Click
        RecuperarCorreos()
    End Sub

    Private Sub RecuperarCorreos()
        Dim remitentesCorreo As List(Of Entidades.SMTP)
        Dim faltanCorreosIndice As Integer = 0

        remitentesCorreo = smtBU.ConsultarSMTPTodos

        If remitentesCorreo.Count > 0 Then
            For index = 0 To remitentesCorreo.Count - 1
                'control = CType(Me.Controls.Find("txtEnviarDe" + (index + 1).ToString, True)(0), TextBox)

                If Me.Controls.Find("txtEnviarDe" + (index + 1).ToString, True).Count = 0 Then
                    faltanCorreosIndice = index
                    Exit For
                End If

                Me.Controls.Find("txtEnviarDe" + (index + 1).ToString, True)(0).Text = remitentesCorreo(index).PUser
            Next

            If faltanCorreosIndice > 0 Then
                For index = faltanCorreosIndice To remitentesCorreo.Count - 1
                    txtCorreosFaltantes.Text += remitentesCorreo(index).PUser + vbCrLf
                Next
            End If
        End If
    End Sub
End Class
