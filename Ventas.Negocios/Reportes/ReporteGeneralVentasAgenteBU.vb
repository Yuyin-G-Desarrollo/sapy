Public Class ReporteGeneralVentasAgenteBU

    Public Function obtenerReporteCuatrimestral(ByVal AgenteId As Integer, ByVal FechaDe As Date, ByVal FechaA As Date, ByVal FamiliaId As String) As DataTable
        Dim objVentasDA As New Ventas.Datos.ReporteGeneralVentasAgenteDA
        Dim vTable As New DataTable
        Try
            vTable = objVentasDA.ConsultaReporteCuatrimestral(AgenteId, FechaDe, FechaA, FamiliaId)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                vTable = obtenerReporteCuatrimestral(AgenteId, FechaDe, FechaA, FamiliaId)
            End If
        End Try
        Return vTable
    End Function

    Public Function obtenerEncabezadosReporte(ByVal spid As Integer)
        Dim objVentasDA As New Ventas.Datos.ReporteGeneralVentasAgenteDA
        Dim vTable As New DataTable
        Try
            vTable = objVentasDA.ConsultaEncabezadosReporte(spid)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                vTable = obtenerEncabezadosReporte(spid)
            End If
        End Try
        Return vTable
    End Function

    Public Function obtenerReporteCuatrimestralMensual(ByVal AgenteId As Integer, ByVal FechaDe As Date, ByVal FechaA As Date, ByVal FamiliaId As String) As DataTable
        Dim objVentasDA As New Ventas.Datos.ReporteGeneralVentasAgenteDA
        Dim vTable As New DataTable
        Try
            vTable = objVentasDA.ConsultaReporteCuatrimestralMensual(AgenteId, FechaDe, FechaA, FamiliaId)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                vTable = obtenerReporteCuatrimestralMensual(AgenteId, FechaDe, FechaA, FamiliaId)
            End If
        End Try
        Return vTable
    End Function

    Public Function obtenerReporteResumenRuta(ByVal AgenteId As Integer, ByVal FechaDe As Date, ByVal FechaA As Date, ByVal FamiliaId As String) As DataTable
        Dim objVentasDA As New Ventas.Datos.ReporteGeneralVentasAgenteDA
        Dim vTable As New DataTable
        Try
            vTable = objVentasDA.ConsultaReporteResumenRuta(AgenteId, FechaDe, FechaA, FamiliaId)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                vTable = obtenerReporteResumenRuta(AgenteId, FechaDe, FechaA, FamiliaId)
            End If
        End Try
        Return vTable
    End Function

    Public Function obtenerReporteResumenRutaMensual(ByVal AgenteId As Integer, ByVal FechaDe As Date, ByVal FechaA As Date, ByVal FamiliaId As String) As DataTable
        Dim objVentasDA As New Ventas.Datos.ReporteGeneralVentasAgenteDA
        Dim vTable As New DataTable
        Try
            vTable = objVentasDA.ConsultaReporteResumenRutaMensual(AgenteId, FechaDe, FechaA, FamiliaId)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                vTable = obtenerReporteResumenRutaMensual(AgenteId, FechaDe, FechaA, FamiliaId)
            End If
        End Try
        Return vTable
    End Function
    Public Function obtenerReporteCumplimientoMensual(ByVal AgenteId As Integer, ByVal FechaDe As Date, ByVal FechaA As Date, ByVal FamiliaId As String) As DataTable
        Dim objVentasDA As New Ventas.Datos.ReporteGeneralVentasAgenteDA
        Dim vTable As New DataTable
        Try
            vTable = objVentasDA.ConsultaReporteCumplimientoMensual(AgenteId, FechaDe, FechaA, FamiliaId)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                vTable = obtenerReporteCumplimientoMensual(AgenteId, FechaDe, FechaA, FamiliaId)
            End If
        End Try
        Return vTable
    End Function
    Public Function obtenerReporteCumplimientoMensualRuta(ByVal AgenteId As Integer, ByVal FechaDe As Date, ByVal FechaA As Date, ByVal FamiliaId As String) As DataTable
        Dim objVentasDA As New Ventas.Datos.ReporteGeneralVentasAgenteDA
        Dim vTable As New DataTable
        Try
            vTable = objVentasDA.ConsultaReporteCumplimientoMensualRuta(AgenteId, FechaDe, FechaA, FamiliaId)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                vTable = obtenerReporteCumplimientoMensualRuta(AgenteId, FechaDe, FechaA, FamiliaId)
            End If
        End Try
        Return vTable

    End Function

    Public Function obtenerReporteGeneralPDF(ByVal FechaDe As Date, ByVal FechaA As Date, ByVal pFgTotal As Integer, agentes As String) As DataTable
        Dim objVentasDA As New Ventas.Datos.ReporteGeneralVentasAgenteDA
        Dim vTable As New DataTable
        Try
            vTable = objVentasDA.ConsultaReporteGeneralPDF(FechaDe, FechaA, pFgTotal, agentes)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                vTable = obtenerReporteGeneralPDF(FechaDe, FechaA, pFgTotal, agentes)
            End If
        End Try
        Return vTable
    End Function

    Public Function obtenerReporteGeneralPDFCuatrimestral(ByVal IdAgente As Integer, ByVal FechaDe As Date, ByVal FechaA As Date, ByVal FamiliaId As String) As DataTable
        Dim objVentasDA As New Ventas.Datos.ReporteGeneralVentasAgenteDA
        Dim vTable As New DataTable
        Try
            vTable = objVentasDA.ConsultaReporteGeneralPDFCuatrimestral(IdAgente, FechaDe, FechaA, FamiliaId)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                vTable = obtenerReporteGeneralPDFCuatrimestral(IdAgente, FechaDe, FechaA, FamiliaId)
            End If
        End Try
        Return vTable
    End Function


    Public Function obtenerAgentes(ByVal pIdAgente As Integer) As DataTable
        Dim objVentasDA As New Ventas.Datos.ReporteGeneralVentasAgenteDA
        Dim vTable As New DataTable
        Try
            vTable = objVentasDA.ConsultaAgentes(pIdAgente)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                vTable = obtenerAgentes(pIdAgente)
            End If
        End Try
        Return vTable
    End Function

    Public Function obtenerCuatrimestre(ByVal pFechaDe As Date, ByVal pFechaA As Date) As DataTable
        Dim objVentasDA As New Ventas.Datos.ReporteGeneralVentasAgenteDA
        Dim vTable As New DataTable
        Try
            vTable = objVentasDA.ObtieneCuatrimestre(pFechaDe, pFechaA)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                vTable = obtenerCuatrimestre(pFechaDe, pFechaA)
            End If
        End Try
        Return vTable
    End Function

End Class
