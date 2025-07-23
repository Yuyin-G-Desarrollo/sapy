Imports Persistencia
Imports System.Data.SqlClient
Public Class CiudadesDA

    Public Function listaCiudadesActivas(ByVal estadoID As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from framework.Ciudades where city_activo='True'"

        If estadoID > 0 Then
            consulta += " and city_estadoid = " + estadoID.ToString
        End If
        consulta += " ORDER BY city_nombre"
        Return objOperaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListaCiudades(ByVal nombre As String, ByVal activo As Boolean, ByVal idestado As Int32, ByVal idpais As Int32) As DataTable

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Framework.Ciudades C join Framework.Estados E on (C.city_estadoid = E.esta_estadoid) join Framework.Paises P on (E.esta_paisid=P.pais_paisid)"
        consulta += " where city_nombre like '%" + nombre.ToString + "%'"
        consulta += " and city_activo ='" + activo.ToString + "'"

        If (idestado > 0) Then
            consulta += " and city_estadoid= " + idestado.ToString
        End If

        If (idpais > 0) Then
            consulta += " and pais_paisid= " + idpais.ToString
        End If
        consulta += " order by city_nombre asc,esta_nombre asc, pais_nombre asc "


        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub AltaCiudad(ByVal Ciudad As Entidades.Ciudades)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "city_nombre"
        parametro.Value = Ciudad.CNombre
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "city_estadoid"
        parametro.Value = Ciudad.CIDEstado.EIDDEstado
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "city_activo"
        parametro.Value = Ciudad.CActivo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "city_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        operaciones.EjecutarSentenciaSP("Framework.SP_altas_ciudades", listaparametros)
    End Sub

    Public Sub EditarCiudad(ByVal Ciudad As Entidades.Ciudades, ByVal Estado As Entidades.Estados)
        Dim opereciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "city_nombre"
        parametro.Value = Ciudad.CNombre
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "city_estadoid"
        parametro.Value = Estado.EIDDEstado
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "city_ciudadid"
        parametro.Value = Ciudad.CciudadId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "city_activo"
        parametro.Value = Ciudad.CActivo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "city_usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        opereciones.EjecutarSentenciaSP("Framework.SP_editar_ciudades", listaparametros)

    End Sub

    Public Function listaCiudadesActivasMayusculas(ByVal estadoID As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select city_ciudadid, LTRIM(RTrim(UPPER(city_nombre))) As city_nombre from framework.Ciudades where city_activo='True'"

        If estadoID > 0 Then
            consulta += " and city_estadoid = " + estadoID.ToString + " ORDER BY city_nombre"
        End If
        Return objOperaciones.EjecutaConsulta(consulta)

    End Function

End Class
