Imports Persistencia
Imports System.Data.SqlClient

Public Class DomicilioDA

    'Public Function Datos_TablaDomicilioCliente(ByVal clienteID As Integer) As DataTable

    '    Dim operaciones As New Persistencia.OperacionesProcedimientos
    '    Dim consulta As String = "" +
    '                            " SELECT" +
    '                            "   LTRIM(RTRIM(UPPER(domi_calle))) AS domi_calle" +
    '                            " , domi_numexterior" +
    '                            " , domi_numinterior" +
    '                            " , LTRIM(RTRIM(UPPER(domi_colonia))) AS domi_colonia " +
    '                            " , domi_cp" +
    '                            " , city_ciudadid" +
    '                            " , LTRIM(RTRIM(UPPER(city_nombre))) AS city_nombre" +
    '                            " , LTRIM(RTRIM(UPPER(domi_delegacion))) AS domi_delegacion" +
    '                            " , pobl_poblacionid" +
    '                            " , LTRIM(RTRIM(UPPER(pobl_nombre))) AS pobl_nombre" +
    '                            " , esta_estadoid" +
    '                            " , LTRIM(RTRIM(UPPER(esta_nombre))) AS esta_nombre" +
    '                            " , pais_paisid" +
    '                            " , LTRIM(RTRIM(UPPER(pais_nombre))) AS pais_nombre" +
    '                            " FROM Framework.Domicilio" +
    '                            " JOIN Framework.Persona ON pers_personaid = domi_personaid" +
    '                            " JOIN Cliente.Cliente ON clie_personaidcliente = pers_personaid" +
    '                            " LEFT JOIN Framework.Poblaciones ON pobl_poblacionid = domi_poblacionid" +
    '                            " JOIN Framework.Ciudades ON city_ciudadid = domi_ciudadid" +
    '                            " JOIN Framework.Estados ON city_estadoid = esta_estadoid" +
    '                            " JOIN Framework.Paises ON pais_paisid = esta_paisid" +
    '                            " WHERE clie_clienteid = " + clienteID.ToString

    '    Return operaciones.EjecutaConsulta(consulta)

    'End Function

    Public Function Datos_TablaDomicilioPersona(ByVal personaID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT" +
                                "   LTRIM(RTRIM(UPPER(domi_calle))) AS domi_calle" +
                                " , domi_numexterior" +
                                " , domi_numinterior" +
                                " , LTRIM(RTRIM(UPPER(domi_colonia))) AS domi_colonia " +
                                " , domi_cp" +
                                " , city_ciudadid" +
                                " , LTRIM(RTRIM(UPPER(city_nombre))) AS city_nombre" +
                                " , LTRIM(RTRIM(UPPER(domi_delegacion))) AS domi_delegacion" +
                                " , pobl_poblacionid" +
                                " , LTRIM(RTRIM(UPPER(pobl_nombre))) AS pobl_nombre" +
                                " , esta_estadoid" +
                                " , LTRIM(RTRIM(UPPER(esta_nombre))) AS esta_nombre" +
                                " , pais_paisid" +
                                " , LTRIM(RTRIM(UPPER(pais_nombre))) AS pais_nombre" +
                                " , domi_clasificacionpersonaid" +
                                " FROM Framework.Domicilio" +
                                " JOIN Framework.Persona ON pers_personaid = domi_personaid" +
                                " LEFT JOIN Framework.Poblaciones ON pobl_poblacionid = domi_poblacionid" +
                                " JOIN Framework.Ciudades ON city_ciudadid = domi_ciudadid" +
                                " JOIN Framework.Estados ON city_estadoid = esta_estadoid" +
                                " JOIN Framework.Paises ON pais_paisid = esta_paisid" +
                                " WHERE pers_personaid = " + personaID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function





    Public Sub AltaDomicilios(ByVal Domicilio As Entidades.Domicilio)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "domi_calle"
        parametro.Value = Domicilio.calle
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "domi_numinterior"
        If Domicilio.numexterior = Nothing Then
            parametro.Value = Domicilio.numinterior
        Else
            parametro.Value = DBNull.Value
        End If

        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "domi_numexterior"
        parametro.Value = Domicilio.numexterior
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "domi_colonia"
        parametro.Value = Domicilio.colonia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "domi_cp"
        If Domicilio.cp = Nothing Then
            parametro.Value = Domicilio.cp
        Else
            parametro.Value = DBNull.Value
        End If

        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "domi_delegacion"
        If Domicilio.delegacion = Nothing Then
            parametro.Value = Domicilio.delegacion
        Else
            parametro.Value = DBNull.Value
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "domi_ciudadid"
        parametro.Value = Domicilio.ciudad.CciudadId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "domi_poblacionid"
        If Domicilio.poblacion.poblacionid = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Domicilio.poblacion.poblacionid
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "domi_personaid"
        parametro.Value = Domicilio.persona.personaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "domi_clasificacionpersonaid"
        parametro.Value = Domicilio.clasificacionpersona.clasificacionpersonaid
        listaParametros.Add(parametro)

        ',@usuariocreoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "domi_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.AltaDomiciliosPersona", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub


    Public Sub EditarDomicilios(ByVal Domicilio As Entidades.Domicilio)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "domi_calle"
        parametro.Value = Domicilio.calle
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "domi_numinterior"
        If Domicilio.numexterior = Nothing Then
            parametro.Value = DBNull.Value

        Else
            parametro.Value = Domicilio.numinterior
        End If

        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "domi_numexterior"
        parametro.Value = Domicilio.numexterior
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "domi_colonia"
        parametro.Value = Domicilio.colonia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "domi_cp"
        If Domicilio.cp = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Domicilio.cp

        End If

        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "domi_delegacion"
        If Domicilio.delegacion = Nothing Then
            parametro.Value = Domicilio.delegacion
        Else
            parametro.Value = DBNull.Value
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "domi_ciudadid"
        parametro.Value = Domicilio.ciudad.CciudadId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "domi_poblacionid"
        If Domicilio.poblacion.poblacionid = Nothing Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = Domicilio.poblacion.poblacionid
        End If

        listaParametros.Add(parametro)


    

        ',@usuariocreoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "domi_usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "DomicilioID"
        parametro.Value = Domicilio.domicilioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.EditarDomiciliosPersona", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function ListaDomiciliosPersona(ByVal IDPErsona As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos



        Dim consulta = "select * from Framework.Domicilio as a left JOIN Framework.Ciudades as b on a.domi_ciudadid=b.city_ciudadid left JOIN Framework.Estados as c on b.city_estadoid=c.esta_estadoid " +
        "left join Framework.Paises as d on c.esta_paisid = d.pais_paisid left join Framework.Poblaciones as f on a.domi_poblacionid = f.pobl_poblacionid WHERE domi_personaid =" + IDPErsona.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function





End Class
