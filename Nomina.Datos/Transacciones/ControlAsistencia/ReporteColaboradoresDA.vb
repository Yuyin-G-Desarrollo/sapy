Imports System.Data.SqlClient

Public Class ReporteColaboradoresDA


    Public Function obtenerListadoColaboradores(tipo_busqueda, idNave) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@tipoBusqueda", tipo_busqueda)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@idNave", idNave)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_ObtieneColaboradores_EntradasSalidas]", listaParametros)
    End Function

    Public Function ObtieneReporteColaboradoresEntradasSalidas(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal FiltroColaboradores As String, ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@FechaInicio", FechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", FechaFin)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@colaboradorIdSAY", FiltroColaboradores)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@naveIdSAY", NaveID)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_Nomina_ReporteEntradasSalidasColaboradores]", listaParametros)
    End Function

End Class
