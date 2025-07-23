Public Class ReporteDocumentosExcepcionBU

    Public Function ConsultarReportesExcepcion(ByVal FechaDel As String,
                                               ByVal FechaAl As String,
                                               ByVal ClientesIDSay As String,
                                               ByVal IdEmisor As String) As DataTable
        Dim objDA As New Datos.ReporteDocumentosExcepcionDA
        Return objDA.ConsultarReportesExcepcion(FechaDel, FechaAl, ClientesIDSay, IdEmisor)
    End Function

End Class
