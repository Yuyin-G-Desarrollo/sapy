Imports Proveedores.DA
Public Class ReporteCostosMaquilasGruposBU
    Public Function ConsultaNavesPorGrupos(ByVal strGrupo As String) As DataTable
        Dim objConsultaNaves As New ReporteCostosMaquilasGruposDA
        Return objConsultaNaves.consultaNavesGrupos(strGrupo)
    End Function
    Public Function ObtenerReportePorNave(ByVal datosNave As Entidades.CostosPorMaquilaNavesGrupos) As DataTable
        Dim objObtenerReporte As New ReporteCostosMaquilasGruposDA
        Return objObtenerReporte.ObtenerReportePorNave(datosNave)
    End Function
    Public Function obtenerEncabezadosTablasReporteNaves(ByVal datosGrupo As Entidades.CostosPorMaquilaNavesGrupos, ByVal tipoReporte As Integer, ByVal spid As Integer) As DataTable
        Dim objDA As New ReporteCostosMaquilasGruposDA
        Dim tabla As New DataTable
        tabla = objDA.obtenerEncabezadosTablasReporteNaves(datosGrupo, tipoReporte, spid)
        Return tabla
    End Function
    Public Function obtenerReporteTotalPorGrupos(ByVal datosGrupo As Entidades.CostosPorMaquilaNavesGrupos) As DataTable
        Dim objObtenerDatos As New ReporteCostosMaquilasGruposDA
        Return objObtenerDatos.obtenerReporteTotalPorGrupos(datosGrupo)
    End Function
    Public Function EliminarEncabezadosReportesGrupos(ByVal datosGrupo As Entidades.CostosPorMaquilaNavesGrupos, ByVal tipoReporte As Integer, ByVal spid As Integer) As String
        Dim objEliminarDatos As New ReporteCostosMaquilasGruposDA
        Dim dtResultado As New DataTable
        dtResultado = objEliminarDatos.EliminarEncabezadosReportes(datosGrupo, tipoReporte, spid)

        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            datosGrupo.cpmMsgResult = dtResultado.Rows(0).Item("mensaje")
        Else
            datosGrupo.cpmMsgResult = Nothing
        End If

        Return datosGrupo.cpmMsgResult
    End Function
    Public Function obtenerReporteGeneral(ByVal datosGrupo As Entidades.CostosPorMaquilaNavesGrupos) As DataTable
        Dim objObtenerDatos As New ReporteCostosMaquilasGruposDA
        Return objObtenerDatos.obtenerReporteCostosGenerales(datosGrupo)
    End Function
End Class
