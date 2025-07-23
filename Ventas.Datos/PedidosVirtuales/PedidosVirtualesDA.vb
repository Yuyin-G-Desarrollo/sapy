Imports Persistencia
Imports System.Data.SqlClient

Public Class PedidosVirtualesDA

    Public Function ListaClientes() As List(Of Entidades.Cliente)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim tabla As New DataTable

        ListaClientes = New List(Of Entidades.Cliente)
        tabla = operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Consulta_Clientes]", listaParametros)
        For Each fila As DataRow In tabla.Rows
            Dim cliente As New Entidades.Cliente
            cliente.clienteid = CInt(fila("clie_clienteid"))
            cliente.nombregenerico = CStr(fila("clie_nombregenerico")).ToUpper
            ListaClientes.Add(cliente)
        Next
    End Function

    Public Function ValidarDepartamento(ByVal idUsuario) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Consulta_DepartamentoUsuario]", listaParametros)
    End Function

    Public Function EliminarPartidas(ByVal idUsuario As Int32, ByVal detalle As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@idDetalle"
        parametro.Value = detalle
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Cancela_Partida_PedidoVirtual]", listaParametros)
    End Function

    Public Function ObtenerEncabezado(ByVal idPedido As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Consultar_Encabezado_PV]", listaParametros)
    End Function

    Public Function ObtenerPartida(ByVal idPedido As Int32) As Int32
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim tabla As New DataTable
        Dim partida As Int32

        parametro.ParameterName = "@idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        tabla = operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Consulta_Partida_PedidoVirtual]", listaParametros)
        For Each fila As DataRow In tabla.Rows
            partida = fila("Partida")
        Next
        Return partida
    End Function

    Public Function ListaEstatus() As List(Of Entidades.PedidoVirtual)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim tabla As New DataTable

        ListaEstatus = New List(Of Entidades.PedidoVirtual)
        tabla = operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Consulta_Estatus]", listaParametros)
        For Each fila As DataRow In tabla.Rows
            Dim estatus As New Entidades.PedidoVirtual
            estatus.estatusid = CInt(fila("esta_estatusid"))
            estatus.estatus = CStr(fila("esta_nombre")).ToUpper
            ListaEstatus.Add(estatus)
        Next
    End Function

    Public Function ListaTiposPedidos() As List(Of Entidades.PedidoVirtual)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim tabla As New DataTable

        ListaTiposPedidos = New List(Of Entidades.PedidoVirtual)
        tabla = operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Consulta_TipoPedidos]", listaParametros)
        For Each fila As DataRow In tabla.Rows
            Dim tipo As New Entidades.PedidoVirtual
            tipo.tipoid = CInt(fila("peti_pedidostiposid"))
            tipo.tipo = CStr(fila("peti_descripcion")).ToUpper
            ListaTiposPedidos.Add(tipo)
        Next
    End Function

    Public Function ListaPreciosCliente(ByVal cliente As Int32, ByVal fecha As Date) As Entidades.ListaBase
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim tabla As New DataTable
        Dim lista As New Entidades.ListaBase

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idsay"
        parametro.Value = cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fecha"
        parametro.Value = fecha
        listaParametros.Add(parametro)

        tabla = operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Consulta_ListaPreciosCliente]", listaParametros)
        For Each fila As DataRow In tabla.Rows
            lista.PListaBaseId = CInt(fila("idListaVentasClientePrecio"))
            lista.PListaBaseNombre = CStr(fila("ListaPrecioCliente")).ToUpper & fila("InicioVigencia") & " AL " & fila("FinVigencia") & ")"
            'lista.PVigenciaInicio = fila("InicioVigencia")
            'lista.PVigenciaFin = fila("FinVigencia")
        Next
        Return lista

    End Function

    Public Function ListaMarcasCliente(ByVal lista As Int32) As List(Of Entidades.Marcas)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim tabla As New DataTable

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@lista"
        parametro.Value = lista
        listaParametros.Add(parametro)

        ListaMarcasCliente = New List(Of Entidades.Marcas)
        tabla = operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Consulta_Marcas]", listaParametros)
        For Each fila As DataRow In tabla.Rows
            Dim listaM As New Entidades.Marcas
            listaM.PMarcaId = CInt(fila("IdMarcaSAY"))
            listaM.PDescripcion = CStr(fila("Marca")).ToUpper
            ListaMarcasCliente.Add(listaM)
        Next

    End Function

    Public Function ListaColeccionesMarcas(ByVal marca As Int32, ByVal lista As Int32) As List(Of Entidades.Coleccion)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim tabla As New DataTable
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@marca"
        parametro.Value = marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@lista"
        parametro.Value = lista
        listaParametros.Add(parametro)

        ListaColeccionesMarcas = New List(Of Entidades.Coleccion)
        tabla = operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Consulta_ColeccionesMarcas]", listaParametros)
        For Each fila As DataRow In tabla.Rows
            Dim listaC As New Entidades.Coleccion
            listaC.PColeID = CInt(fila("IdColeccionSAY"))
            listaC.PColeccionDescripcion = CStr(fila("Coleccion")).ToUpper
            ListaColeccionesMarcas.Add(listaC)
        Next

    End Function

    Public Function ListarArticulos(ByVal listaPrecios As Int32, ByVal marca As Int32, ByVal coleccion As Int32, ByVal modelosay As Int32, ByVal modelosicy As Int32, ByVal mostrar As Int32, ByVal tipoPedido As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim tabla As New DataTable
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@idLista"
        parametro.Value = listaPrecios
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Marca"
        parametro.Value = marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = coleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ModeloSAY"
        parametro.Value = modelosay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ModeloSICY"
        parametro.Value = modelosicy
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Mostrar"
        parametro.Value = mostrar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoPedido"
        parametro.Value = tipoPedido
        listaParametros.Add(parametro)

        tabla = operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Consulta_Articulos]", listaParametros)
        Return tabla

    End Function

    Public Function InsertarPedidoVirtual(ByVal tipoPedido As Int32, ByVal estatus As Int32, ByVal orden As String, ByVal cliente As Int32,
                                     ByVal listaPrecios As Int32, ByVal pares As Int32, ByVal observaciones As String, ByVal fechaSolicitud As Date,
                                     ByVal usuario As Int32, ByVal PedidosDetalles As String) As String

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim tabla As New DataTable
        Dim mensaje As String = ""
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoPedido"
        parametro.Value = tipoPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatus"
        parametro.Value = estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@orden"
        parametro.Value = orden
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cliente"
        parametro.Value = cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@listaPrecio"
        parametro.Value = listaPrecios
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Pares"
        parametro.Value = pares
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Observaciones"
        parametro.Value = observaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaSolicitud"
        parametro.Value = fechaSolicitud
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = usuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoDetalles"
        parametro.Value = PedidosDetalles
        listaParametros.Add(parametro)

        tabla = operaciones.EjecutarConsultaSP("[Ventas].SP_PedidosVirtuales_Insert_PedidosVirtuales", listaParametros)

        For Each fila As DataRow In tabla.Rows
            mensaje = fila("mensaje")
        Next

        Return mensaje

    End Function

    Public Function EditarPedidoVirtual(ByVal orden As String, ByVal pedido As Int32, ByVal listaPrecios As Int32,
                                        ByVal pares As Int32, ByVal observaciones As String, ByVal fechaSolicitud As Date,
                                        ByVal usuario As Int32, ByVal fechaProgramacion As Date, ByVal PedidosDetalles As String) As String

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim tabla As New DataTable
        Dim mensaje As String = ""
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@orden"
        parametro.Value = orden
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pedido"
        parametro.Value = pedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@listaPrecio"
        parametro.Value = listaPrecios
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Pares"
        parametro.Value = pares
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Observaciones"
        parametro.Value = observaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaSolicitud"
        parametro.Value = fechaSolicitud
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = usuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaProgramacion"
        parametro.Value = fechaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoDetalles"
        parametro.Value = PedidosDetalles
        listaParametros.Add(parametro)

        tabla = operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Update_PedidosVirtuales]", listaParametros)

        For Each fila As DataRow In tabla.Rows
            mensaje = fila("mensaje")
        Next

        Return mensaje

    End Function

    Public Function ListaPedidosVirtuales(ByVal fechaCapInic As Date, ByVal fechaCapFin As Date, ByVal fechaSolInic As Date, ByVal fechaSolFin As Date,
                                          ByVal fechaProgInic As Date, ByVal fechaProgFin As Date, ByVal cliente As Int32,
                                          ByVal estatus As Int32, ByVal captura As Int32, ByVal solicita As Int32, ByVal programa As Int32, ByVal alerta As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaCapturaInicio"
        parametro.Value = fechaCapInic
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaCapturaFin"
        parametro.Value = fechaCapFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaSolicitadaInicio"
        parametro.Value = fechaSolInic
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaSolicitadaFin"
        parametro.Value = fechaSolFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaProgramacionInicio"
        parametro.Value = fechaProgInic
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaProgramacionFin"
        parametro.Value = fechaProgFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cliente"
        parametro.Value = cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatus"
        parametro.Value = estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@captura"
        parametro.Value = captura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@solicita"
        parametro.Value = solicita
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@programa"
        parametro.Value = programa
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@alerta"
        parametro.Value = alerta
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Consulta_Admin_PedidosVirtuales]", listaParametros)
    End Function

    Public Function ObtenerDetalleArticulos(ByVal pedido As Int32, ByVal tipoPedido As Int32, ByVal listaPrecios As Int32, ByVal estatus As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim tabla As New DataTable
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@idPedido"
        parametro.Value = pedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoPedido"
        parametro.Value = tipoPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idlista"
        parametro.Value = listaPrecios
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatus"
        parametro.Value = estatus
        listaParametros.Add(parametro)

        tabla = operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Consulta_PedidosVirtuales_Articulos]", listaParametros)
        Return tabla

    End Function

    Public Function obtenerBitacora(ByVal isPedido) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@idPedido"
        parametro.Value = isPedido
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Consulta_Bitacora]", listaParametros)
    End Function

    Public Function ConfirmarPedido(ByVal pedido As Int32, ByVal usuario As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@idPedido"
        parametro.Value = pedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = usuario
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Confirmar_Pedido]", listaParametros)
    End Function

    Public Function AutorizarPedido(ByVal pedido As Int32, ByVal usuario As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@idPedido"
        parametro.Value = pedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = usuario
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Autorizar_Pedido]", listaParametros)
    End Function

    Public Function cancelarPedido(ByVal pedido As Int32, ByVal motivo As String, ByVal usuario As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim tabla As New DataTable
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@idPedido"
        parametro.Value = pedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@motivo"
        parametro.Value = motivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = usuario
        listaParametros.Add(parametro)

        tabla = operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Cancelar_Pedido]", listaParametros)
        Return tabla

    End Function

    Public Function obtenerPedidosReales(ByVal cliente As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@cliente"
        parametro.Value = cliente
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Consulta_PedidosReales]", listaParametros)
    End Function

    Public Function vincularPedidoVirtual(ByVal pedidoVirtual As Int32, ByVal pedidoReal As String, ByVal usuario As Int32, ByVal numPedidos As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@Pedidovirtual"
        parametro.Value = pedidoVirtual
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoreal"
        parametro.Value = pedidoReal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = usuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Numpedidos"
        parametro.Value = numPedidos
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Vincular_PedidosVirtuales_Reales]", listaParametros)
    End Function

    Public Function ActualizarPedidoVirtualReal(ByVal pedidoVirtual As Int32, ByVal usuario As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@Pedidovirtual"
        parametro.Value = pedidoVirtual
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = usuario
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Update_PedidoReal]", listaParametros)
    End Function

    Public Function BuscarAgentes(ByVal isPedido As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@pedido"
        parametro.Value = isPedido
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Consulta_AgentesMarcas]", listaParametros)
    End Function

    Public Function convertirPedidoReal(ByVal pedidoVirtual As Int32, ByVal agente As Int32, ByVal usuario As Int32, ByVal registros As Int32, ByVal detalles As String) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoVirtual"
        parametro.Value = pedidoVirtual
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@agente"
        parametro.Value = agente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = usuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@registros"
        parametro.Value = registros
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@detalles"
        parametro.Value = detalles
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Convertir_PedidosVirtuales_Reales]", listaParametros)
    End Function

    Public Function obtenerPedidosRealesConvertidos(ByVal pedido As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidovirtual"
        parametro.Value = pedido
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Consulta_Convertir_PedidosReales]", listaParametros)
    End Function

    Public Function ValidarArticulosImportacion(ByVal listaPrecios As Int32, ByVal marca As String, ByVal coleccion As String, ByVal modelosay As String,
                                                ByVal modelosicy As String, ByVal temporada As String, ByVal estatus As String, ByVal piel As String,
                                                ByVal color As String, ByVal corrida As String, ByVal tipoPedido As Int32) As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim tabla As New DataTable
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@idLista"
        parametro.Value = listaPrecios
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Marca"
        parametro.Value = marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = coleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ModeloSAY"
        parametro.Value = modelosay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ModeloSICY"
        parametro.Value = modelosicy
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Temporada"
        parametro.Value = temporada
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Estatus"
        parametro.Value = estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Piel"
        parametro.Value = piel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Color"
        parametro.Value = color
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = corrida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoPedido"
        parametro.Value = tipoPedido
        listaParametros.Add(parametro)

        tabla = operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosVirtuales_Consulta_Validacion_Articulos_importacion]", listaParametros)
        Return tabla

    End Function

End Class
