Imports System.Data.SqlClient

Public Class ReporteGeneralVentasAgenteDA

    Public Function ConsultaReporteCuatrimestral(ByVal AgenteId As Integer, ByVal FechaDe As Date, ByVal FechaA As Date, ByVal FamiliasId As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "AgenteId"
        parametro.Value = AgenteId
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaDe"
        parametro.Value = FechaDe
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaA"
        parametro.Value = FechaA
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FamiliasId"
        parametro.Value = FamiliasId
        lstParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_ReporteGeneralVentas_ConsultaReporteCuatrimestral", lstParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ConsultaEncabezadosReporte(ByVal spid As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "spid"
        parametro.Value = spid
        lstParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_ReporteGeneralVentas_ConsultaEncabezadosReporte", lstParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ConsultaReporteCuatrimestralMensual(ByVal AgenteId As Integer, ByVal FechaDe As Date, ByVal FechaA As Date, ByVal FamiliasId As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "AgenteId"
        parametro.Value = AgenteId
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaDe"
        parametro.Value = FechaDe
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaA"
        parametro.Value = FechaA
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FamiliasId"
        parametro.Value = FamiliasId
        lstParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_ReporteGeneralVentas_ConsultaReporteCuatrimestralMensual", lstParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ConsultaReporteResumenRuta(ByVal AgenteId As Integer, ByVal FechaDe As Date, ByVal FechaA As Date, ByVal FamiliasId As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "AgenteId"
        parametro.Value = AgenteId
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaDe"
        parametro.Value = FechaDe
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaA"
        parametro.Value = FechaA
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FamiliasId"
        parametro.Value = FamiliasId
        lstParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_ReporteGeneralVentas_ConsultaReporteResumenRuta", lstParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ConsultaReporteResumenRutaMensual(ByVal AgenteId As Integer, ByVal FechaDe As Date, ByVal FechaA As Date, ByVal FamiliasId As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "AgenteId"
        parametro.Value = AgenteId
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaDe"
        parametro.Value = FechaDe
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaA"
        parametro.Value = FechaA
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FamiliasId"
        parametro.Value = FamiliasId
        lstParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_ReporteGeneralVentas_ConsultaReporteResumenRutaMensual", lstParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ConsultaReporteCumplimientoMensual(ByVal AgenteId As Integer, ByVal FechaDe As Date, ByVal FechaA As Date, ByVal FamiliasId As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "AgenteId"
        parametro.Value = AgenteId
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaDe"
        parametro.Value = FechaDe
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaA"
        parametro.Value = FechaA
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FamiliasId"
        parametro.Value = FamiliasId
        lstParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_ReporteGeneralVentas_ConsultaReporteCumplimientoMensual", lstParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ConsultaReporteCumplimientoMensualRuta(ByVal AgenteId As Integer, ByVal FechaDe As Date, ByVal FechaA As Date, ByVal FamiliasId As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "AgenteId"
        parametro.Value = AgenteId
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaDe"
        parametro.Value = FechaDe
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaA"
        parametro.Value = FechaA
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FamiliasId"
        parametro.Value = FamiliasId
        lstParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_ReporteGeneralVentas_ConsultaReporteCumplimientoMensualRuta", lstParametros)

        Return dtResultadoConsulta

    End Function


    Public Function ConsultaReporteGeneralPDF(ByVal FechaDe As Date, ByVal FechaA As Date, ByVal pFgTotal As Integer, agentes As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaDe"
        parametro.Value = FechaDe
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaA"
        parametro.Value = FechaA
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FgTotal"
        parametro.Value = pFgTotal
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradoridagente"
        parametro.Value = agentes
        lstParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_ReporteGeneralVentas_ConsultaReportePDF_v5", lstParametros)

        Return dtResultadoConsulta

    End Function


    Public Function ConsultaReporteGeneralPDFCuatrimestral(ByVal pIdAgente As Integer, ByVal FechaDe As Date, ByVal FechaA As Date, ByVal FamiliasId As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable
        Dim lstParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "AgenteId"
        parametro.Value = pIdAgente
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaDe"
        parametro.Value = FechaDe
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaA"
        parametro.Value = FechaA
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FamiliasId"
        parametro.Value = FamiliasId
        lstParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_ReporteGeneralVentas_ConsultaReportePDFCuatrimestralAgente", lstParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ConsultaAgentes(ByVal pIdAgente As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdAgente"
        parametro.Value = pIdAgente
        lstParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_ReporteGeneralVentas_ConsultasFiltros_Agente", lstParametros)

        Return dtResultadoConsulta

    End Function


    Public Function ObtieneCuatrimestre(ByVal pFechaDe As Date, pFechaA As Date) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaDe"
        parametro.Value = pFechaDe
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaA"
        parametro.Value = pFechaA
        lstParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_ReporteGeneralVentas_Cuatrimestre", lstParametros)

        Return dtResultadoConsulta

    End Function

End Class
