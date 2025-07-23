Public Class SeguimientoVentasBU

    Public Function ReportesSeguimientoVentas(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Agente As String, ByVal Marca As String, ByVal Cliente As String, ByVal TipoReporte As Integer, ByVal IdUsuario As Integer, ByVal FactorFrecuenciaCompra As Integer, familia As String) As DataTable
        Dim objDA As New Ventas.Datos.SeguimientoVentasDA
        Dim tabla As New DataTable

        Select Case TipoReporte
            Case 1
                tabla = objDA.ReporteSeguimientoVentasPorAgente(FechaInicio, FechaFin, Agente, Marca, Cliente, IdUsuario, familia)
            Case 2
                tabla = objDA.ReporteSeguimientoVentasFrecuenciaCompra(FechaInicio, FechaFin, Agente, Marca, Cliente, IdUsuario, FactorFrecuenciaCompra, familia)
            Case 3
                tabla = objDA.ReporteSeguimientoVentasPorAgenteResumen(FechaInicio, FechaFin, Agente, Marca, Cliente, IdUsuario, familia)
            Case 4
                tabla = objDA.ReporteSeguimientoFrecuenciaPedidosPorCliente(FechaInicio, FechaFin, Cliente, Agente, Marca, FactorFrecuenciaCompra, familia)
        End Select

        Return tabla

    End Function

    Public Function SeguimientoVentasObtenerEncabezadosTabla(ByVal Spid As Integer) As DataTable
        Dim objDA As New Ventas.Datos.SeguimientoVentasDA
        Dim tabla As New DataTable
        tabla = objDA.SeguimientoVentasObtenerEncabezadosTabla(Spid)

        SeguimientoVentasLimpiarEncabezadosTabla(Spid)

        Return tabla
    End Function

    Public Sub SeguimientoVentasLimpiarEncabezadosTabla(ByVal Spid As Integer)
        Dim objDA As New Ventas.Datos.SeguimientoVentasDA
        objDA.SeguimientoVentasLimpiarEncabezadosTabla(Spid)
    End Sub

   
End Class
