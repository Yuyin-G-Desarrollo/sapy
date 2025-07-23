Imports System.Data.SqlClient
Imports Entidades
Public Class ReporteCostosMaquilasGruposDA
    Public Function consultaNavesGrupos(ByVal strGrupo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@Grupo"
        parametro.Value = strGrupo
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Proveedor].[SP_ConsultaNavesPertenecientesGrupos]", listaParametros)
    End Function

    Public Function ObtenerReportePorNave(ByVal datosNave As Entidades.CostosPorMaquilaNavesGrupos) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = datosNave.cpmanio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@semanaInicio"
        parametro.Value = datosNave.cpmsemanaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@semanaFinal"
        parametro.Value = datosNave.cpmsemanaFinal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveID"
        parametro.Value = datosNave.cpmIdNave
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Proveedor].[SP_CostosMaquilas_ReporteCostosMaquilasPorNave]", listaParametros)
    End Function

    Public Function obtenerEncabezadosTablasReporteNaves(ByVal datosGrupo As Entidades.CostosPorMaquilaNavesGrupos, ByVal tipoReporte As Integer, ByVal spid As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@grupo"
        parametro.Value = datosGrupo.cpmgrupo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoReporte"
        parametro.Value = tipoReporte
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@spid"
        parametro.Value = spid
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_MaquilaCostos_ConsultaEncabezadosReportes]", listaParametros)

        Return dtResultadoConsulta
    End Function

    Public Function obtenerReporteTotalPorGrupos(ByVal datosGrupo As Entidades.CostosPorMaquilaNavesGrupos) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = datosGrupo.cpmanio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@semanaInicio"
        parametro.Value = datosGrupo.cpmsemanaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@semanaFinal"
        parametro.Value = datosGrupo.cpmsemanaFinal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@grupo"
        parametro.Value = datosGrupo.cpmgrupo
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Proveedor].[SP_CostosMaquilas_ReporteCostosMaquilasPorGrupos]", listaParametros)
    End Function
    Public Function EliminarEncabezadosReportes(ByVal datos As Entidades.CostosPorMaquilaNavesGrupos, ByVal tipoReporte As Int32, ByVal spid As Integer) As DataTable
        Dim objeliminar As New Persistencia.OperacionesProcedimientosSICY
        Dim parametro = New SqlClient.SqlParameter
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@grupo"
        parametro.Value = datos.cpmgrupo
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@tipoReporte"
        parametro.Value = tipoReporte
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@spid"
        parametro.Value = spid
        ListaParametros.Add(parametro)

        Return objeliminar.EjecutarConsultaSP("[Proveedor].[SP_CostosMaquilas_EliminaEncabezadosReportes]", ListaParametros)
    End Function
    Public Function obtenerReporteCostosGenerales(ByVal datosGrupo As Entidades.CostosPorMaquilaNavesGrupos) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = datosGrupo.cpmanio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@semanaInicio"
        parametro.Value = datosGrupo.cpmsemanaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@semanaFinal"
        parametro.Value = datosGrupo.cpmsemanaFinal
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Proveedor].[SP_CostosMaquilas_ReporteCostosMaquilasGeneral]", listaParametros)
    End Function
End Class
