Public Class EstadisticoPedidosBU


    Public Function ListadoParametrosReportes(tipo_busqueda As Integer, idUsuario As Integer) As DataTable
        Dim objDA As New Ventas.Datos.EstadisticoPedidosDA
        Dim tabla As New DataTable
        tabla = objDA.ListadoParametrosReportes(tipo_busqueda, idUsuario)
        Return tabla
    End Function

    Public Function ListadoParametrosReportesClienteAgente(ByVal ColaboradorID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.EstadisticoPedidosDA
        Dim tabla As New DataTable
        tabla = objDA.ListadoParametrosReportesClienteAgente(ColaboradorID)
        Return tabla
    End Function

    Public Function ListadoParametrosReportesColeccionAgente(ByVal colaboradorIDSAY As Integer) As DataTable
        Dim objDA As New Ventas.Datos.EstadisticoPedidosDA
        Dim tabla As New DataTable
        tabla = objDA.ListadoParametrosReportesColeccionAgente(colaboradorIDSAY)
        Return tabla
    End Function

#Region "Tipos Reporte"

    Public Function reporteEstadisticoPedidosConFiltros(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Agente As String, ByVal Marca As String, ByVal Cliente As String, ByVal TipoReporte As Integer) As DataTable
        Dim objDA As New Ventas.Datos.EstadisticoPedidosDA
        Dim tabla As New DataTable

        Select Case TipoReporte
            Case 1
                tabla = objDA.reporteEstadisticoPedidos_ConFiltros(FechaInicio, FechaFin, Agente, Marca, Cliente)
            Case 2
                tabla = objDA.reportePedidosAgente_ConFiltros(FechaInicio, FechaFin, Agente, Marca, Cliente)
            Case 3
                tabla = objDA.reportePedidosCliente_ConFiltros(FechaInicio, FechaFin, Agente, Marca, Cliente)
            Case 4
                tabla = objDA.reportePedidosRutaMarca_ConFiltros(FechaInicio, FechaFin, Agente, Marca, Cliente)
        End Select

        Return tabla

    End Function

    Public Function reporteEstadisticoPedidosSinFiltros(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal TipoReporte As Integer) As DataTable
        Dim objDA As New Ventas.Datos.EstadisticoPedidosDA
        Dim tabla As New DataTable

        Select Case TipoReporte
            Case 1
                tabla = objDA.reporteEstadisticoPedidos_SinFiltros(FechaInicio, FechaFin)
            Case 2
                tabla = objDA.reportePedidosAgente_SinFiltros(FechaInicio, FechaFin)
            Case 3
                tabla = objDA.reportePedidosCliente_SinFiltros(FechaInicio, FechaFin)
            Case 4
                tabla = objDA.reportePedidosRutaMarca_SinFiltros(FechaInicio, FechaFin)
        End Select

        Return tabla

    End Function

#End Region

    Public Function reporteEstadisticoPedidosObtenerEncabezadosTabla(ByVal Spid As Integer) As DataTable
        Dim objDA As New Ventas.Datos.EstadisticoPedidosDA
        Dim tabla As New DataTable
        tabla = objDA.reporteEstadisticoPedidosObtenerEncabezadosTabla(Spid)

        reporteEstadisticoPedidosLimpiarEncabezadosTabla(Spid)

        Return tabla

    End Function

    Public Sub reporteEstadisticoPedidosLimpiarEncabezadosTabla(ByVal Spid As Integer)
        Dim objDA As New Ventas.Datos.EstadisticoPedidosDA
        Dim tabla As New DataTable
        objDA.reporteEstadisticoPedidosLimpiarEncabezadosTabla(Spid)
    End Sub

    Public Sub bitacoraExportacionExcel(ByVal UsuarioId As Integer, ByVal Exportado_A As String, ByVal Aplicacion As String, ByVal TipoReporte As String, ByVal FechaInicio As String, ByVal FechaFin As String)
        Dim objDA As New Ventas.Datos.EstadisticoPedidosDA
        Dim tabla As New DataTable
        objDA.bitacoraExportacionExcel(UsuarioId, Exportado_A, Aplicacion, TipoReporte, FechaInicio, FechaFin)
    End Sub


    Public Function consultaPerfilUsuario(ByVal usuarioId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.EstadisticoPedidosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaPerfilUsuario(usuarioId)

        Return tabla

    End Function

End Class
