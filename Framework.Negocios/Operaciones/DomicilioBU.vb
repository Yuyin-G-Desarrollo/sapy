Public Class DomicilioBU


    'Public Function Datos_TablaDomicilioCliente(ByVal clienteID As Integer) As DataTable

    '    Dim DomicilioDA As New Datos.DomicilioDA
    '    Return DomicilioDA.Datos_TablaDomicilioCliente(clienteID)

    'End Function


    Public Function Datos_TablaDomicilioPersona(ByVal personaID As Integer) As DataTable

        Dim DomicilioDA As New Datos.DomicilioDA
        Return DomicilioDA.Datos_TablaDomicilioPersona(personaID)

    End Function


    Public Sub AltaDomicilios(ByVal Domicilio As Entidades.Domicilio)
        Dim OBJDA As New Datos.DomicilioDA
        OBJDA.AltaDomicilios(Domicilio)
    End Sub

    Public Sub EditarDomicilios(ByVal Domicilio As Entidades.Domicilio)
        Dim OBJDA As New Datos.DomicilioDA
        OBJDA.EditarDomicilios(Domicilio)
    End Sub

    Public Function ListaDomiciliosPersona(ByVal IDPErsona As Int32) As List(Of Entidades.Domicilio)
        Dim OBDA As New Datos.DomicilioDA
        Dim table As New DataTable
        Dim List As New List(Of Entidades.Domicilio)
        table = OBDA.ListaDomiciliosPersona(IDPErsona)
        For Each row As DataRow In table.Rows
            Dim Domicilio As New Entidades.Domicilio
            Domicilio.domicilioid = CInt(row("domi_domicilioid"))
            Try
                Domicilio.calle = CStr(row("domi_calle"))
            Catch ex As Exception

            End Try
            Try
                Domicilio.numexterior = CStr(row("domi_numexterior"))
            Catch ex As Exception

            End Try
            Try
                Domicilio.numinterior = CStr(row("domi_numinterior"))
            Catch ex As Exception

            End Try
            Try
                Domicilio.colonia = CStr(row("domi_colonia"))
            Catch ex As Exception

            End Try
            Try
                Domicilio.cp = CStr(row("domi_cp"))
            Catch ex As Exception

            End Try
            Try
                Domicilio.delegacion = CStr(row("domi_delegacion"))
            Catch ex As Exception

            End Try
            Try
                Dim Ciudad As New Entidades.Ciudades
                Ciudad.CNombre = CStr(row("city_nombre"))
                Ciudad.CciudadId = CInt(row("domi_ciudadid"))
                Dim Estado As New Entidades.Estados
                Estado.ENombre = CStr(row("esta_nombre"))
                Estado.EIDDEstado = CInt(row("esta_estadoid"))
                Dim Pais As New Entidades.Paises
                Pais.PNombre = CStr(row("pais_nombre"))
                Pais.PIDPais = CInt(row("pais_paisid"))
                Estado.PPais = Pais
                Ciudad.CIDEstado = Estado
                Domicilio.ciudad = Ciudad
            Catch ex As Exception

            End Try
            Try
                Dim Poblacion As New Entidades.Poblacion
                Poblacion.poblacionid = CInt(row("domi_poblacionid"))
                Poblacion.nombre = CStr(row("pobl_nombre"))
                Domicilio.poblacion = Poblacion
            Catch ex As Exception

            End Try
            Try
                Dim Persona As New Entidades.Persona
                Persona.personaid = CInt(row("domi_personaid"))
                Domicilio.persona = Persona
            Catch ex As Exception

            End Try

            Dim ClasificacionPersona As New Entidades.ClasificacionPersona
            ClasificacionPersona.clasificacionpersonaid = CInt(row("domi_clasificacionpersonaid"))
            Domicilio.clasificacionpersona = ClasificacionPersona
            Domicilio.activo = CBool(row("domi_activo"))
            List.Add(Domicilio)
        Next
        Return List
    End Function


End Class
