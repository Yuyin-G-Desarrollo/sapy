Public Class SmtpBU

    Public Function buscarSmtp(ByVal user As String) As Entidades.SMTP
        buscarSmtp = New Entidades.SMTP
        Dim smtp As New Datos.SmtpDA
        Dim tabla As New DataTable
        tabla = smtp.BuscaSMTP(user)
        For Each row As DataRow In tabla.Rows
            buscarSmtp.PUser = user
            buscarSmtp.PContrasena = CStr(row("smtp_contrasena"))
            buscarSmtp.PServidor = CStr(row("smtp_servidorsmtp"))
            buscarSmtp.PSsl = CBool(row("smtp_ssl"))
            buscarSmtp.PPuerto = CStr(row("smtp_puerto"))
        Next

    End Function

    Public Function ConsultarSMTPTodos() As List(Of Entidades.SMTP)
        Dim entidad As Entidades.SMTP
        Dim correos As New List(Of Entidades.SMTP)
        Dim smtp As New Datos.SmtpDA
        Dim tabla As New DataTable

        tabla = smtp.ConsultarSMTPTodos()

        For Each row As DataRow In tabla.Rows
            entidad = New Entidades.SMTP
            entidad.PUser = CStr(row("smtp_usuario"))
            entidad.PContrasena = CStr(row("smtp_contrasena"))
            entidad.PServidor = CStr(row("smtp_servidorsmtp"))
            entidad.PSsl = CBool(row("smtp_ssl"))
            entidad.PPuerto = CStr(row("smtp_puerto"))

            correos.Add(entidad)
        Next

        Return correos
    End Function

End Class
