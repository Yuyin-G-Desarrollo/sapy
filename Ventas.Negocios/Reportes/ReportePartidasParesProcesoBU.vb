Public Class ReportePartidasParesProcesoBU

    Public Function consultaDatosPartidas(ByVal Estatus As String, ByVal EnProceso As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ReportePartidasParesProcesoDA
        Dim tabla As New DataTable

        tabla = objDA.consultaDatosPartidas(Estatus, EnProceso)

        Return tabla
    End Function

End Class
