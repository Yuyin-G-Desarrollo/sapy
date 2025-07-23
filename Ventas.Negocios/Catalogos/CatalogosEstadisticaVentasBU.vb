Public Class CatalogosEstadisticaVentasBU
    Public Function AgregarCalendarioSemana(ByVal cadena As String, ByVal anio As Integer) As DataTable
        Dim objCalendarioSemanal As New Ventas.Datos.CatalogosEstadisticaVentasDA
        Return objCalendarioSemanal.AgregarCalendarioSemana(cadena, anio)
    End Function

    Public Function ConsultarCalendarioSemana(ByVal anio As Integer) As DataTable
        Dim objCalendarioSemanal As New Ventas.Datos.CatalogosEstadisticaVentasDA
        Return objCalendarioSemanal.ConsultarCalendarioSemana(anio)
    End Function

    Public Function ConsultarPProyyeccion(ByVal anio As Integer) As DataTable
        Dim objCalendarioSemanal As New Ventas.Datos.CatalogosEstadisticaVentasDA
        Return objCalendarioSemanal.ConsultarPProyecion(anio)
    End Function

    Public Function AgregarPProduccion(ByVal cadena As String, ByVal anio As Integer) As DataTable
        Dim objCalendarioSemanal As New Ventas.Datos.CatalogosEstadisticaVentasDA
        Return objCalendarioSemanal.AgregarPProduccion(cadena, anio)
    End Function


End Class
