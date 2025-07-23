Imports Persistencia
Imports System.Data.SqlClient

Public Class EstadosDA

    Public Function ListaEstados(ByVal nombre As String, ByVal activo As Boolean, ByVal paisid As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Framework.Estados join Framework.Paises on esta_paisid= pais_paisid"
        consulta += " where esta_nombre like '%" + nombre + "%'"
        consulta += " and esta_activo = '" + activo.ToString + "'"
        If (paisid > 0) Then
            consulta += " and esta_paisid=" + paisid.ToString
        End If
        consulta += " order by esta_nombre asc"


        Return objOperaciones.EjecutaConsulta(consulta)

    End Function


    Public Sub AltaEstado(ByVal Estados As Entidades.Estados, ByVal Pais As Entidades.Paises)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "esta_nombre"
        parametro.Value = Estados.ENombre
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "esta_activo"
        parametro.Value = Estados.EActivo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "esta_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "esta_paisid"
        parametro.Value = Pais.PIDPais
        listaparametros.Add(parametro)
        operaciones.EjecutarSentenciaSP("Framework.SP_altas_estados", listaparametros)
    End Sub


    Public Sub EditarEstado(ByVal Estado As Entidades.Estados, ByVal Pais As Entidades.Paises)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "esta_nombre"
        parametro.Value = Estado.ENombre
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "esta_estadoid"
        parametro.Value = Estado.EIDDEstado
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "esta_activo"
        parametro.Value = Estado.EActivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "esta_usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        operaciones.EjecutarSentenciaSP("Framework.SP_editar_estados", listaparametros)
    End Sub


    Public Function buscarEstado(ByVal estadoidselect As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutaConsulta("SELECT * FROM Framework.Estados where esta_estadoid=" + estadoidselect.ToString + " order by ORDER BY esta_nombre")
    End Function

    Public Function ListaEstadosPais(ByVal nombre As String, ByVal activo As Boolean, ByVal paisid As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select esta_estadoid, LTRIM(RTrim(UPPER(esta_nombre))) As esta_nombre from Framework.Estados join Framework.Paises on esta_paisid= pais_paisid"
        consulta += " where esta_nombre like '%" + nombre + "%'"
        consulta += " and esta_activo = '" + activo.ToString + "'"
        If (paisid > 0) Then
            consulta += " and esta_paisid=" + paisid.ToString
        End If

        consulta += " order by esta_nombre"

        Return objOperaciones.EjecutaConsulta(consulta)

    End Function


End Class
