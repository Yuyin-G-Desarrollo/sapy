Public Class FiltrosReportesBU

    Public Function ConsultarFiltros(tipoFiltro As Integer) As DataTable
        Dim objDA As New FiltrosReportesDA
        Return objDA.ConsultarFiltros(tipoFiltro)
    End Function
End Class
