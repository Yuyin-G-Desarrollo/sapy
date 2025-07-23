Imports Persistencia
Imports System.Data.SqlClient

Public Class PaisesDA

    Public Function ListaPaises(ByVal nombre As String, ByVal activo As Boolean) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Framework.Paises"
        consulta += " where pais_nombre like '%" + nombre + "%'"
        consulta += " and pais_activo = '" + activo.ToString + "' order by pais_nombre asc"
        Return objOperaciones.EjecutaConsulta(consulta)

    End Function

 
    Public Sub AltaPais(ByVal Paises As Entidades.Paises)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "pais_nombre"
        parametro.Value = Paises.PNombre
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "pais_activo"
        parametro.Value = Paises.PActivo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "pais_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        operaciones.EjecutarSentenciaSP("Framework.SP_agregar_pais", listaparametros)
    End Sub

    Public Sub EditarPais(ByVal Paises As Entidades.Paises)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "pais_paisid"
        parametro.Value = Paises.PIDPais
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pais_nombre"
        parametro.Value = Paises.PNombre
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pais_activo"
        parametro.Value = Paises.PActivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pais_usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        
        operaciones.EjecutarSentenciaSP("Framework.SP_editar_pais", listaparametros)
    End Sub

    Public Function buscarPais(ByVal paisidselect As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutaConsulta("SELECT * FROM Framework.Paises where pais_paisid=" + paisidselect.ToString)
    End Function

    Public Function ListaPaisesMayusculas() As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select pais_paisid, LTRIM(RTrim(UPPER(pais_nombre))) As pais_nombre from Framework.Paises where pais_activo = 1 order by pais_nombre"
        Return objOperaciones.EjecutaConsulta(consulta)

    End Function


End Class
