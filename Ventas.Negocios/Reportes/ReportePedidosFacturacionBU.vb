Imports Ventas.Datos
Public Class ReportePedidosFacturacionBU

    Public Function consultaReportePedidos(ByVal FechaInicio As String, ByVal FechaTermino As String, ByVal Agentes As String, ByVal Marcas As String, ByVal Semanas As String, ByVal Clientes As String, ByVal TipoReporte As Integer, ByVal ConDetalle As Integer, ByVal Cedis As Integer) As DataTable
        Dim objDA As New ReportePedidosFacturacionDA
        Return objDA.consultaReportePedidos(FechaInicio, FechaTermino, Agentes, Marcas, Semanas, Clientes, TipoReporte, ConDetalle, Cedis)
    End Function

    Public Function consultaSemanasPedidos(ByVal FechaInicio As String, ByVal FechaTermino As String, ByVal Agentes As String, ByVal Marcas As String, ByVal TipoReporte As Integer) As DataTable
        Dim objDA As New ReportePedidosFacturacionDA
        Return objDA.consultaSemanasPedidos(FechaInicio, FechaTermino, Agentes, Marcas, TipoReporte)
    End Function

    Public Function consultaReportePedidosV2(ByVal FechaInicio As String, ByVal FechaTermino As String, ByVal Agentes As String, ByVal Marcas As String, ByVal Clientes As String, ByVal Familias As String, ByVal TipoReporte As Integer, ByVal Colecciones As String) As DataTable
        Dim objDA As New ReportePedidosFacturacionDA
        Return objDA.consultaReportePedidosV2(FechaInicio, FechaTermino, Agentes, Marcas, Clientes, Familias, TipoReporte, Colecciones)
    End Function

    Public Function ConsultaReportePedidos_FEntregaCliente(ByVal FechaInicio As String, ByVal FechaTermino As String, ByVal Agentes As String, ByVal Marcas As String, ByVal Clientes As String, ByVal Familias As String, ByVal TipoReporte As Integer, ByVal Colecciones As String) As DataTable
        Dim objDA As New ReportePedidosFacturacionDA
        Return objDA.consultaReportePedidos_FEntregaCliente(FechaInicio, FechaTermino, Agentes, Marcas, Clientes, Familias, TipoReporte, Colecciones)
    End Function

    Public Function obtenerAgentePorColaborador(ByVal ColaboradorId As Integer) As DataTable
        Dim objDA As New ReportePedidosFacturacionDA
        Return objDA.obtenerAgentePorColaborador(ColaboradorId)
    End Function

    Public Function InteligenciaComercial_Reportes_Pedidos(ByVal año As Integer) As DataTable
        Dim objDA As New ReportePedidosFacturacionDA
        Return objDA.InteligenciaComercial_Reportes_Pedidos(año)
    End Function

    Public Function InteligencciaComercial_Reportes_Ventas(ByVal año As Integer) As DataTable
        Dim objDA As New ReportePedidosFacturacionDA
        Return objDA.InteligencciaComercial_Reportes_Ventas(año)
    End Function

    Public Function InteligencciaComercial_Reportes_Devolucion(ByVal año As Integer) As DataTable
        Dim objDA As New ReportePedidosFacturacionDA
        Return objDA.InteligencciaComercial_Reportes_Devolucion(año)
    End Function

    Public Function ConsultarClientesTallas(FechaInicio As String, FechaTermino As String, Cliente As String, FamiliaProyeccion As String) As DataTable
        Dim objDA As New ReportePedidosFacturacionDA
        Return objDA.ConsultarClientesTallas(FechaInicio, FechaTermino, Cliente, FamiliaProyeccion)
    End Function
    Public Function ReportePedidosFamiliaGrupo(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal cliente As String, ByVal cedis As Integer)
        Dim objDA As New ReportePedidosFacturacionDA
        Return objDA.ReportePedidosFamiliaGrupo(fechaInicio, fechaFin, cliente, cedis)
    End Function

    Public Function ObtenerNumeroSemana(ByVal fecha As Date)
        Dim objDA As New ReportePedidosFacturacionDA
        Dim semana As Integer
        Dim tbl As New DataTable
        tbl = objDA.ObtenerNumeroSemana(fecha)
        semana = tbl.Rows(0).Item("Semana")
        Return semana
    End Function

    Public Function ReporteDetalladoFcturacion(ByVal anio As Integer)
        Dim obj As New ReportePedidosFacturacionDA
        Return obj.ReporteDetalladoFcturacion(anio)
    End Function

    Public Function reportePedidosFacturacionObtenerPerfilUsuario(ByVal usuarioId As Integer) As DataTable
        Dim objDA As New ReportePedidosFacturacionDA
        Dim tabla As New DataTable
        tabla = objDA.reporteReporteFacturacionObtenerPerfilUsuario(usuarioId)

        Return tabla

    End Function

End Class
