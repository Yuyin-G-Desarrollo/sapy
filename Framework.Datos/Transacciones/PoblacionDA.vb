Imports Persistencia
Imports System.Data.SqlClient
Imports Entidades
Public Class PoblacionDA

    Public Function ListaPoblacion(ByVal ciudadID As Integer) As DataTable

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT pobl_poblacionid, pobl_nombre FROM Framework.Poblaciones WHERE pobl_activo = 1 "
        If (ciudadID > 0) Then
            consulta += " AND pobl_ciudadid = " + ciudadID.ToString
        End If

        consulta += " ORDER BY pobl_nombre"

        Return objOperaciones.EjecutaConsulta(consulta)

    End Function



    Public Function ConsultaPoblaciones(ByVal PaisID As Int32, ByVal EstadoID As Int32, ByVal Ciudad As Int32, ByVal Nombre As String, ByVal Activo As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "SELECT d.pobl_poblacionid,a.pais_paisid, b.esta_estadoid,c.city_ciudadid,a.pais_nombre, b.esta_nombre, c.city_nombre, d.pobl_nombre, d.pobl_activo from" _
            + " Framework.Paises as a " _
            + " join Framework.Estados as b on (a.pais_paisid = b.esta_paisid) JOIN Framework.Ciudades as c ON (b.esta_estadoid = c.city_estadoid)" _
            + " join Framework.Poblaciones as d ON (c.city_ciudadid= d.pobl_ciudadid) "

        If PaisID > 0 Then
            consulta += " where a.pais_paisid=" + PaisID.ToString
            If EstadoID > 0 Then
                consulta += " and b.esta_estadoid=" + EstadoID.ToString
                If Ciudad > 0 Then
                    consulta += " and c.city_ciudadid=" + Ciudad.ToString
                End If
                consulta += " and pobl_activo='" + Activo.ToString + "'"
            End If
            consulta += " and d.pobl_nombre LIKE '%" + Nombre + "%'"
        Else
            consulta += "where d.pobl_nombre LIKE '%" + Nombre + "%'"
            consulta += " and pobl_activo='" + Activo.ToString + "'"
        End If

        consulta += " order by d.pobl_nombre asc"

        Return operaciones.EjecutaConsulta(consulta)
    End Function




    Public Sub AltaPoblaciones(ByVal Entidad As Entidades.Mensajeria)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        parametro = New SqlParameter
        parametro.ParameterName = "pobl_nombre"
        parametro.Value = Entidad.PNombrePoblacion
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pobl_ciudadid"
        parametro.Value = Entidad.PNombreCiudad
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pobl_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pobl_activo"
        parametro.Value = Entidad.PActivo
        ListaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_AltaPoblacion", ListaParametros)


    End Sub


    Public Sub EditarPoblaciones(ByVal Entidad As Entidades.Mensajeria)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        parametro = New SqlParameter
        parametro.ParameterName = "pobl_nombre"
        parametro.Value = Entidad.PNombrePoblacion
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pobl_ciudadid"
        parametro.Value = Entidad.PNombreCiudad
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pobl_usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pobl_poblacionid"
        parametro.Value = Entidad.PIDCostoMensajeria
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pobl_activo"
        parametro.Value = Entidad.PActivo
        ListaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_EditarPoblacion", ListaParametros)


    End Sub




End Class
