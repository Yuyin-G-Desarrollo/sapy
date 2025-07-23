Imports System.Data.SqlClient

Public Class EstadisticoPedidosDA

#Region "Filtros"

    Public Function ListadoParametrosReportes(tipo_busqueda As Integer, idUsuario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Select Case tipo_busqueda
            Case 1

                ' 'consulta = "SELECT col.codr_colaboradorid Parametro,col.codr_nombre + ' ' + col.codr_apellidopaterno + ' '+col.codr_apellidomaterno as Nombre, count(distinct c.clie_clienteid) as Clientes " +
                ' '" from Nomina.Colaborador col " +
                ' '" inner join Cliente.ClienteMarcaFamiliaProyeccionAgente cmae on   col.codr_colaboradorid=cmae.cmfa_colaboradorid_agente" +
                ' '" inner join Cliente.Cliente c on c.clie_clienteid=cmae.cmfa_clienteid " +
                ' '" where cmae.cmfa_activo=1" +
                ' '" group by col.codr_nombre + ' ' + col.codr_apellidopaterno + ' '+col.codr_apellidomaterno,col.codr_colaboradorid" +
                ' '" order by Nombre"
                '-dtResultadoConsulta = objPersistencia.EjecutaConsulta("EXEC Ventas.SP_EstadisticoPedidos_ConsultasFiltros_Agente")
                ' 'dtResultadoConsulta = objPersistencia.EjecutaConsulta(consulta)
                parametro.ParameterName = "@UsuarioId"
                parametro.Value = idUsuario
                listaParametros.Add(parametro)

                dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_EstadisticoPedidos_ConsultasFiltros_Agente", listaParametros)
            Case 2
                parametro.ParameterName = "@UsuarioId"
                parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                listaParametros.Add(parametro)

                dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_EstadisticoPedidos_ConsultasFiltros_Cliente", listaParametros)
            Case 3
                dtResultadoConsulta = objPersistencia.EjecutaConsulta("EXEC Ventas.SP_EstadisticoPedidos_ConsultasFiltros_Marca")
            Case 5
                dtResultadoConsulta = objPersistencia.EjecutaConsulta("exec Ventas.SP_EstadisticoPedidos_ConsultasFiltros_Coleccion")
            Case 7
                'traer los clientes que tiene según agente logueado
                parametro.ParameterName = "@ColaboradorIdSAY"
                parametro.Value = idUsuario
                listaParametros.Add(parametro)

                dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_EstadisticoPedidos_ConsultasFiltros_Cliente_Agente", listaParametros)
            Case 8

                parametro.ParameterName = "@colaboradorId"
                parametro.Value = idUsuario
                listaParametros.Add(parametro)

                dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_EstadisticoPedidos_ConsultasFiltros_Agente_Default", listaParametros)
            Case 9
                'Marca del agente que está logueado
                parametro.ParameterName = "@colaboradorId"
                parametro.Value = idUsuario
                listaParametros.Add(parametro)

                dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_EstadisticoPedidos_ConsultasFiltros_Marca_Agente", listaParametros)

            Case 10
                dtResultadoConsulta = objPersistencia.EjecutaConsulta("EXEC Ventas.SP_EstadisticoPedidos_ConsultasFiltros_Familia")
            Case 11
                dtResultadoConsulta = objPersistencia.EjecutaConsulta("EXEC Ventas.SP_EstadisticoPedidos_ConsultasFiltros_EstatusArticulos")

        End Select

        Return dtResultadoConsulta

    End Function

    Public Function ListadoParametrosReportesClienteAgente(ByVal colaboradorIDSAY As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ColaboradorIdSAY"
        parametro.Value = colaboradorIDSAY
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_EstadisticoPedidos_ConsultasFiltros_Cliente_Agente", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ListadoParametrosReportesColeccionAgente(ByVal colaboradorIDSAY As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Colaborador"
        parametro.Value = colaboradorIDSAY
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_EstadisticoPedidos_ConsultasFiltros_Coleccion_Agente", listaParametros)

        Return dtResultadoConsulta

    End Function

#End Region

#Region "Estadistico Pedidos"

    Public Function reporteEstadisticoPedidos_ConFiltros(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Agente As String, ByVal Marca As String, ByVal Cliente As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgentesIDSay"
        parametro.Value = Agente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MarcasIDSay"
        parametro.Value = Marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClientesIDSay"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadPedidos_EstadPedidos_ConFiltros", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function reporteEstadisticoPedidos_SinFiltros(ByVal FechaInicio As String, ByVal FechaFin As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadPedidos_EstadPedidos_SinFiltros", listaParametros)

        Return dtResultadoConsulta

    End Function

#End Region

#Region "Pedidos Por Agente"

    Public Function reportePedidosAgente_ConFiltros(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Agente As String, ByVal Marca As String, ByVal Cliente As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgentesIDSay"
        parametro.Value = Agente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MarcasIDSay"
        parametro.Value = Marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClientesIDSay"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadPedidos_PorAgente_ConFiltros", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function reportePedidosAgente_SinFiltros(ByVal FechaInicio As String, ByVal FechaFin As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadPedidos_PorAgente_SinFiltros", listaParametros)

        Return dtResultadoConsulta

    End Function

#End Region

#Region "Pedidos Por Cliente"

    Public Function reportePedidosCliente_ConFiltros(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Agente As String, ByVal Marca As String, ByVal Cliente As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgentesIDSay"
        parametro.Value = Agente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MarcasIDSay"
        parametro.Value = Marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClientesIDSay"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadPedidos_PorCliente_ConFiltros", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function reportePedidosCliente_SinFiltros(ByVal FechaInicio As String, ByVal FechaFin As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadPedidos_PorCliente_SinFiltros", listaParametros)

        Return dtResultadoConsulta

    End Function

#End Region

#Region "Pedidos Por Ruta Por Marca"

    Public Function reportePedidosRutaMarca_ConFiltros(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Agente As String, ByVal Marca As String, ByVal Cliente As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgentesIDSay"
        parametro.Value = Agente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MarcasIDSay"
        parametro.Value = Marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClientesIDSay"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadPedidos_PorRuta_ConFiltros", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function reportePedidosRutaMarca_SinFiltros(ByVal FechaInicio As String, ByVal FechaFin As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadPedidos_PorRuta_SinFiltros", listaParametros)

        Return dtResultadoConsulta

    End Function

#End Region

#Region "Encabezados"

    Public Function reporteEstadisticoPedidosObtenerEncabezadosTabla(ByVal Spid As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "spid"
        parametro.Value = Spid
        listaParametros.Add(parametro)


        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadisticoPedidos_SeleccionarEncabezadosReporte", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Sub reporteEstadisticoPedidosLimpiarEncabezadosTabla(ByVal Spid As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "spid"
        parametro.Value = Spid
        listaParametros.Add(parametro)


        objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSay_EstadisticoPedidos_EliminarEncabezadosReporte", listaParametros)

    End Sub

#End Region


    Public Sub bitacoraExportacionExcel(ByVal UsuarioId As Integer, ByVal Exportado_A As String, ByVal Aplicacion As String, ByVal TipoReporte As String, ByVal FechaInicio As String, ByVal FechaFin As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "usuarioid"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "exportado_a"
        parametro.Value = Exportado_A
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "aplicacion"
        parametro.Value = Aplicacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tiporeporte"
        parametro.Value = TipoReporte
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechainicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechafin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("Framework.SP_framework_CreacionBitacoraExportacionArchivo", listaParametros)

    End Sub

    Public Function consultaPerfilUsuario(ByVal usuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@usuarioId"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Perfil_Usuario_Tablero", listaParametros)

        Return dtResultadoConsulta

    End Function

End Class
