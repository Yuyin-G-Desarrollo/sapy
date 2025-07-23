Public Class EmailBU
    Public Sub AltaEmail(ByVal Email As Entidades.Email)
        Dim objda As New Datos.EmailDA
        objda.AltaEmail(Email)
    End Sub

    Public Sub EditarEmail(ByVal Email As Entidades.Email)
        Dim objda As New Datos.EmailDA
        objda.EditarEmail(Email)
    End Sub
    Public Function ListaEmails(ByVal IdPersona As Int32) As List(Of Entidades.Email)
        Dim objda As New Datos.EmailDA
        ListaEmails = New List(Of Entidades.Email)
        Dim tabla As New DataTable
        tabla = objda.ListaEmails(IdPersona)
        For Each row As DataRow In tabla.Rows
            Dim email As New Entidades.Email
            email.emailpersonasid = CInt(row("empe_emailpersonasid"))
            email.email = CStr(row("empe_email"))
            Dim persona As New Entidades.Persona
            persona.personaid = CInt(row("empe_personaid"))
            email.persona = persona
            Dim clasificacionpersona As New Entidades.ClasificacionPersona
            clasificacionpersona.clasificacionpersonaid = CInt(row("empe_clasificacionpersonaid"))
            email.clasificacionpersona = clasificacionpersona
            email.activo = CBool(row("empe_activo"))
            ListaEmails.Add(email)
        Next
    End Function
End Class
