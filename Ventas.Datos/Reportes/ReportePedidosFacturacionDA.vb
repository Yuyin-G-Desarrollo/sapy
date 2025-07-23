Imports Persistencia
Imports System.Data.SqlClient
Public Class ReportePedidosFacturacionDA

    Public Function consultaReportePedidos(ByVal FechaInicio As String, ByVal FechaTermino As String, ByVal Agentes As String, ByVal Marcas As String, ByVal Semanas As String, ByVal Clientes As String, ByVal TipoReporte As Integer, ByVal ConDetalle As Integer, ByVal Cedis As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicioProgramacion"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaTerminoProgramacion"
        parametro.Value = FechaTermino
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Agentes"
        parametro.Value = Agentes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Marcas"
        parametro.Value = Marcas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Semanas"
        parametro.Value = Semanas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Clientes"
        parametro.Value = Clientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoReporte"
        parametro.Value = TipoReporte
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ConDetalle"
        parametro.Value = ConDetalle
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cedis"
        parametro.Value = Cedis
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_SAY_ReportePedidosFacturados_PorCedis", listaParametros)


    End Function

    Public Function consultaSemanasPedidos(ByVal FechaInicio As String, ByVal FechaTermino As String, ByVal Agentes As String, ByVal Marcas As String, ByVal TipoReporte As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicioProgramacion"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaTerminoProgramacion"
        parametro.Value = FechaTermino
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Agentes"
        parametro.Value = Agentes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Marcas"
        parametro.Value = Marcas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoReporte"
        parametro.Value = TipoReporte
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_SAY_VerSemanasProgramacion", listaParametros)


    End Function

    Public Function consultaReportePedidosV2(ByVal FechaInicio As String, ByVal FechaTermino As String, ByVal Agentes As String, ByVal Marcas As String, ByVal Clientes As String, ByVal Familias As String, ByVal TipoReporte As Integer, ByVal Colecciones As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaTermino"
        parametro.Value = FechaTermino
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Agentes"
        parametro.Value = Agentes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Marcas"
        parametro.Value = Marcas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Clientes"
        parametro.Value = Clientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Familias"
        parametro.Value = Familias
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoReporte"
        parametro.Value = TipoReporte
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ColeccionMarcaID"
        parametro.Value = Colecciones
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_SAY_ReporteGeneralPedidos_Escritorio", listaParametros)


    End Function

    ''' <summary>
    ''' Méotod para mostrar el reporte general de pedidos en base a la fecha de entrega de cliente
    ''' </summary>
    ''' <param name="FechaInicio"></param>
    ''' <param name="FechaTermino"></param>
    ''' <param name="Agentes"></param>
    ''' <param name="Marcas"></param>
    ''' <param name="Clientes"></param>
    ''' <param name="Familias"></param>
    ''' <param name="TipoReporte"></param>
    ''' <param name="Colecciones"></param>
    ''' <returns></returns>
    Public Function consultaReportePedidos_FEntregaCliente(ByVal FechaInicio As String, ByVal FechaTermino As String, ByVal Agentes As String, ByVal Marcas As String, ByVal Clientes As String, ByVal Familias As String, ByVal TipoReporte As Integer, ByVal Colecciones As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaTermino"
        parametro.Value = FechaTermino
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Agentes"
        parametro.Value = Agentes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Marcas"
        parametro.Value = Marcas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Clientes"
        parametro.Value = Clientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Familias"
        parametro.Value = Familias
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoReporte"
        parametro.Value = TipoReporte
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ColeccionMarcaID"
        parametro.Value = Colecciones
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Ventas_SAY_ReporteGeneralPedidos_Escritorio_EntregaCliente_Programacion_v4]", listaParametros)


    End Function


    Public Function obtenerAgentePorColaborador(ByVal ColaboradorId As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ColaboradorId"
        parametro.Value = ColaboradorId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_SAY_ReporteGeneralPedidos_Escritorio_ObtenerAgentePorColaborador", listaParametros)


    End Function

    Public Function InteligenciaComercial_Reportes_Pedidos(ByVal año As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Año"
        parametro.Value = año
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_InteligenciaComercial_Reportes_Pedidos", listaParametros)


    End Function

    Public Function InteligencciaComercial_Reportes_Ventas(ByVal año As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Año"
        parametro.Value = año
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_InteligencciaComercial_Reportes_Ventas", listaParametros)


    End Function

    Public Function InteligencciaComercial_Reportes_Devolucion(ByVal año As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Año"
        parametro.Value = año
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_InteligencciaComercial_Reportes_Devoluciones", listaParametros)


    End Function

    Public Function ConsultarClientesTallas(FechaInicio As String, FechaTermino As String, Cliente As String, FamiliaProyeccion As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaTermino"
        parametro.Value = FechaTermino
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cliente"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@familia"
        parametro.Value = FamiliaProyeccion
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Ventas_SAY_ReporteGeneralPedidos_Escritorio_Consultar_ClientesTallas]", listaParametros)
    End Function

    Public Function ReportePedidosFamiliaGrupo(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal cliente As String, ByVal cedis As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@FechaInicio", fechaInicio)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@FechaFin", fechaFin)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@Cliente", cliente)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@CEDIS", cedis)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_ReportePedidos_FamiliaGrupo2]", listaParametros)

    End Function

    Public Function ObtenerNumeroSemana(ByVal fecha As Date)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@Fecha", fecha)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_ObtenerNumeroSemanaVentas]", listaParametros)
    End Function

    Public Function ReporteDetalladoFcturacion(ByVal anio As Integer)
        Dim persistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter("@AñoEntregaCliente", anio)
        listaParametros.Add(parametro)
        Return persistencia.EjecutarConsultaSP("[Ventas].[SP_InteligenciaComercial_PedidosFacturados]", listaParametros)
    End Function

    Public Function reporteReporteFacturacionObtenerPerfilUsuario(ByVal UsuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IDUsuarioSAY"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)


        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadisticaVentasPorFamilia_VerificarPerfilUsurario", listaParametros)

        Return dtResultadoConsulta

    End Function

End Class
