Public Class TelefonoBU

    Public Sub AltaTelefono(ByVal Telefono As Entidades.Telefono)
        Dim objda As New Datos.TelefonoDA
        objda.AltaTelefono(Telefono)
    End Sub

    Public Sub EditarTelefono(ByVal Telefono As Entidades.Telefono)
        Dim objda As New Datos.TelefonoDA
        objda.EditarTelefono(Telefono)
    End Sub


    Public Function ListaTelefonos(ByVal idPersona As Int32) As List(Of Entidades.Telefono)
        Dim objDA As New Datos.TelefonoDA
        ListaTelefonos = New List(Of Entidades.Telefono)
        Dim Tabla As New DataTable
        Tabla = objDA.ListaTelefonos(idPersona)
        For Each row As DataRow In Tabla.Rows
            Dim Telefono As New Entidades.Telefono
            Telefono.telefonoid = CInt(row("tele_telefonoid"))
            Telefono.telefono = CStr(row("tele_telefono"))
            Telefono.extension = CStr(row("tele_extension"))
            Dim TipoTelefono As New Entidades.TipoTelefono
            TipoTelefono.tipotelefonoid = CInt(row("tele_tipotelefonoid"))
            TipoTelefono.nombre = CStr(row("tite_nombre"))
            Telefono.tipotelefono = TipoTelefono
            Dim Persona As New Entidades.Persona
            Persona.personaid = CInt(row("tele_personaid"))
            Telefono.persona = Persona
            Dim ClasificacionPersona As New Entidades.ClasificacionPersona
            ClasificacionPersona.clasificacionpersonaid = CInt(row("tele_clasificacionpersonaid"))
            Telefono.clasificacionpersona = ClasificacionPersona
            Telefono.activo = CBool(row("tele_activo"))
            ListaTelefonos.Add(Telefono)
        Next
    End Function
End Class
