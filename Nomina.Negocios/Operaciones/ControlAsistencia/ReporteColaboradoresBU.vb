Imports Nomina.Datos

Public Class ReporteColaboradoresBU

    Public Function obtenerListadoColaboradores(tipo_busqueda, idNave) As DataTable
        Dim objDA As New ReporteColaboradoresDA
        Dim dtColaboradores As New DataTable
        dtColaboradores = objDA.obtenerListadoColaboradores(tipo_busqueda, idNave)
        Return dtColaboradores
    End Function

    Public Function ObtieneReporteColaboradoresEntradasSalidas(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal FiltroColaboradores As String, ByVal NaveID As Integer) As DataTable
        Dim objDA As New ReporteColaboradoresDA
        Dim dtColaboradoresEntradaSalida As New DataTable
        dtColaboradoresEntradaSalida = objDA.ObtieneReporteColaboradoresEntradasSalidas(FechaInicio, FechaFin, FiltroColaboradores, NaveID)
        Return dtColaboradoresEntradaSalida
    End Function

End Class
