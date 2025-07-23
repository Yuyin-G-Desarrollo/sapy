Public Class PersonasBU

    Public Sub AltaPersona(ByVal persona As Entidades.Persona, cliente As Entidades.Cliente, clienteRFC As Entidades.ClienteRFC, tipoPersona As Entidades.TipoPersona, bandera As Integer)

        Dim PersonasDA As New Datos.PersonasDA

        PersonasDA.AltaPersona(persona, cliente, clienteRFC, tipoPersona, bandera)

    End Sub
    Public Sub EditarPersona(ByVal persona As Entidades.Persona, clienteID As Integer, email As Entidades.Email, bandera As Integer)

        Dim PersonasDA As New Datos.PersonasDA

        PersonasDA.EditarPersona(persona, clienteID, email, bandera)

    End Sub
    Public Function Datos_TablaPersona(personaID As Integer) As DataTable
        Dim PersonasDA As New Datos.PersonasDA
        Return PersonasDA.Datos_TablaPersona(personaID)
    End Function
    Public Function ClasePersona() As DataTable
        Dim OBJDA As New Datos.PersonasDA
        Return OBJDA.ClasePersona()
    End Function
    Public Function ClasePersonaCMB() As DataTable
        Dim OBJDA As New Datos.PersonasDA
        ClasePersonaCMB = OBJDA.ClasePersonaCMB()
        Return OBJDA.ClasePersonaCMB
    End Function
    Public Function ClasificacionPersona(ByVal idClasePersona As Int32) As DataTable
        Dim OBJDA As New Datos.PersonasDA
        Return OBJDA.ClasificacionPersona(idClasePersona)
    End Function
    Public Sub AltaPersonaGeneral(ByVal persona As Entidades.Persona)
        Dim OBJDA As New Datos.PersonasDA
        OBJDA.AltaPersonaGeneral(persona)
    End Sub
    Public Sub EditarPersonas(ByVal persona As Entidades.Persona)
        Dim OBJDA As New Datos.PersonasDA
        OBJDA.EditarPersonas(persona)
    End Sub
    Public Function GetIDPersonaRecienIngresado() As Int32
        Dim OBJDA As New Datos.PersonasDA
        Dim tabla As New DataTable
        tabla = OBJDA.GetIDPersonaRecienInsertado()
        Dim IdPersona As New Int32
        For Each row As DataRow In tabla.Rows
            IdPersona = CInt(row("pers_personaid"))
        Next
        Return IdPersona
    End Function
    Public Sub AltaTipoPersona(ByVal personaid As Int32, ByVal ClasificacionPersona As Int32)
        Dim OBJDA As New Datos.PersonasDA
        OBJDA.AltaTipoPersona(personaid, ClasificacionPersona)
    End Sub
    Public Function ListaPersonas(ByVal TipoPersona As Int32, ByVal ClasePersona As Int32, ByVal Activo As Boolean) As DataTable
        Dim objDA As New Datos.PersonasDA
        Return objDA.ListaPersonas(TipoPersona, ClasePersona, Activo)
    End Function
    Public Function CargarDatosPersona(ByVal IDPersona As Int32) As Entidades.Persona
        Dim objda As New Datos.PersonasDA
        Dim Table As New DataTable
        Table = objda.CargarDatosPersona(IDPersona)
        Dim Persona As New Entidades.Persona
        For Each row As DataRow In Table.Rows
            Try
                Persona.personaid = CInt(row("pers_personaid"))
            Catch ex As Exception
            End Try
            Try
                Persona.nombre = CStr(row("pers_nombre"))
            Catch ex As Exception
            End Try
            Try
                Persona.apaterno = CStr(row("pers_apaterno"))
            Catch ex As Exception
            End Try
            Try
                Persona.amaterno = CStr(row("pers_amaterno"))
            Catch ex As Exception

            End Try
            Try
                Persona.CURP = CStr(row("pers_CURP"))
            Catch ex As Exception

            End Try

            Try
                Persona.razonsocial = CStr(row("pers_razonsocial"))
            Catch ex As Exception

            End Try
            Try
                Persona.paginaweb = CStr(row("pers_paginaweb"))
            Catch ex As Exception

            End Try


            Try
                Persona.fechanacimiento = CDate(row("pers_fechanacimiento"))
            Catch ex As Exception

            End Try

            Try
                Persona.personafisica = CBool(row("pers_personafisica"))
            Catch ex As Exception

            End Try
            Try
                Persona.activo = CBool(row("pers_activo"))
            Catch ex As Exception

            End Try
            Try
                Persona.SicyID = CInt(row("idSicy"))
            Catch ex As Exception

            End Try


        Next
        Return Persona
    End Function

    Public Function regimenPersonaMoralFisica(tipoPersona As Boolean) As DataTable
        Dim PersonasDA As New Datos.PersonasDA
        Return PersonasDA.regimenPersonaMoralFisica(tipoPersona)
    End Function

    Public Function regimenPersonaMoralFisicaId(personaID As Integer) As DataTable
        Dim PersonasDA As New Datos.PersonasDA
        Return PersonasDA.regimenPersonaMoralFisicaId(personaID)
    End Function
End Class
