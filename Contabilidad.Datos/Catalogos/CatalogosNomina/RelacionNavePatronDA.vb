Imports System.Data.SqlClient

Public Class RelacionNavePatronDA

    Public Function cargarListaPatrones() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "exec Contabilidad.SP_NF_NavePatron_ListaPatrones"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function cargarNavesRelacion(ByVal patronId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "PatronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_NavePatron_RelacionNavePatron", listaParametros)
    End Function

    Public Function editarRelacion(ByVal patronId As Integer, ByVal naveId As Integer, ByVal relacionar As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "PatronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NaveId"
        parametro.Value = naveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Relacionar"
        parametro.Value = relacionar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_NavePatron_Relacionar", listaParametros)
    End Function

End Class
