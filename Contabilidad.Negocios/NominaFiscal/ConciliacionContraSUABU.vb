Public Class ConciliacionContraSUABU
    Dim objDatos As New Datos.ConciliacionContraSUADA

    Public Function listarBimestre() As DataTable
        Return objDatos.listaBimestre()
    End Function

    Public Function obtenerReporteAcumulado(ByVal patronid As Integer, ByVal anio As Integer, ByVal colaboradorIds As String, ByVal nombre As String) As DataTable
        Return objDatos.obtenerReporteAcumulado(patronid, anio, colaboradorIds, nombre)
    End Function

    Public Function obtenerReporteBimestre(ByVal patronid As Integer, ByVal anio As Integer, ByVal bimestre As Integer, ByVal colaboradorIds As String, ByVal nombre As String) As DataTable
        Return objDatos.obtenerReporteBimestre(patronid, anio, bimestre, colaboradorIds, nombre)
    End Function

    Public Function obtenerColumnasEncabezadosReporte(ByVal tiporeporte As String) As DataTable
        Return objDatos.obtenerColumnasEncabezadosReporte(tiporeporte)
    End Function

    Public Function importarLayoutSUA(ByVal strXML As String, ByVal patronid As Integer, ByVal anio As Integer, ByVal bimestre As Integer) As String
        Dim resultado As String = String.Empty
        Dim dtResultados As New DataTable

        dtResultados = objDatos.importarLayoutSUA(strXML, patronid, anio, bimestre)

        If Not dtResultados Is Nothing AndAlso dtResultados.Rows.Count > 0 Then
            resultado = dtResultados.Rows(0).Item(0)
        End If

        Return resultado
    End Function

    Public Function actualizaInformacionBimestre(ByVal strXML As String) As String
        Dim resultado As String = String.Empty
        Dim dtResultados As New DataTable

        dtResultados = objDatos.actualizaDatosConciliacionSUABimestre(strXML)

        If Not dtResultados Is Nothing AndAlso dtResultados.Rows.Count > 0 Then
            resultado = dtResultados.Rows(0).Item(0)
        End If

        Return resultado
    End Function

    Public Function actualizaInformacionAcumulado(ByVal strXML As String) As String
        Dim resultado As String = String.Empty
        Dim dtResultados As New DataTable

        dtResultados = objDatos.actualizaInformacionAcumulado(strXML)

        If Not dtResultados Is Nothing AndAlso dtResultados.Rows.Count > 0 Then
            resultado = dtResultados.Rows(0).Item(0)
        End If

        Return resultado
    End Function

    Public Function validaEstatusAutorizado(ByVal patronid As Integer, ByVal anio As Integer, ByVal bimestre As Integer) As Boolean
        Dim resultado As Boolean = False
        Dim dtResultados As New DataTable

        dtResultados = objDatos.validaEstatusAutorizado(patronid, anio, bimestre)

        If Not dtResultados Is Nothing AndAlso dtResultados.Rows.Count > 0 Then
            resultado = True
        End If

        Return resultado
    End Function

    Public Function autorizarBimestre(ByVal patronid As Integer, ByVal anio As Integer, ByVal bimestre As Integer) As String
        Dim resultado As String = String.Empty
        Dim dtResultados As New DataTable

        dtResultados = objDatos.autorizarBimestre(patronid, anio, bimestre)

        If Not dtResultados Is Nothing AndAlso dtResultados.Rows.Count > 0 Then
            resultado = dtResultados.Rows(0).Item(0)
        End If

        Return resultado
    End Function

    Public Function obtenerEncabezadosReporteImprimr(ByVal patronid As Integer, ByVal bimestre As Integer, ByVal anio As Integer, ByVal reporte As Char) As DataTable
        Return objDatos.obtenerEncabezadosReporteImprimr(patronid, bimestre, anio, reporte)
    End Function

End Class
