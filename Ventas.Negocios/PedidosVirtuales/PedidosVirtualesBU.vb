Public Class PedidosVirtualesBU

    Public Function ListaClientes() As List(Of Entidades.Cliente)
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.ListaClientes()
    End Function

    Public Function ValidarDepartamento(ByVal idUsuario As Int32) As String
        Dim objDA As New Datos.PedidosVirtualesDA
        Dim tabla As DataTable
        Dim departamentos As String = ""

        tabla = objDA.ValidarDepartamento(idUsuario)
        For Each row As DataRow In tabla.Rows
            departamentos += row("perf_perfilid") & ","
        Next
        Return departamentos
    End Function

    Public Function ObtenerEncabezado(ByVal idPedido As Int32) As DataTable
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.ObtenerEncabezado(idPedido)
    End Function

    Public Function ObtenerPartida(ByVal idPedido As Int32) As Int32
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.ObtenerPartida(idPedido)
    End Function

    Public Function EliminarPartidas(ByVal idUsuario As Int32, ByVal detalle As Int32) As DataTable
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.EliminarPartidas(idUsuario, detalle)
    End Function

    Public Function ListaEstatus() As List(Of Entidades.PedidoVirtual)
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.ListaEstatus()
    End Function

    Public Function ListaTiposPedidos() As List(Of Entidades.PedidoVirtual)
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.ListaTiposPedidos()
    End Function

    Public Function ListaPreciosCliente(ByVal cliente As Int32, ByVal fecha As Date) As Entidades.ListaBase
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.ListaPreciosCliente(cliente, fecha)
    End Function

    Public Function ListaMarcasCliente(ByVal lista As Int32) As List(Of Entidades.Marcas)
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.ListaMarcasCliente(lista)
    End Function

    Public Function ListaColeccionesMarcas(ByVal marca As Int32, ByVal lista As Int32) As List(Of Entidades.Coleccion)
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.ListaColeccionesMarcas(marca, lista)
    End Function

    Public Function ObtenerArticulos(ByVal listaPrecios As Int32, ByVal marca As Int32, ByVal coleccion As Int32, ByVal modelosay As Int32, ByVal modelosicy As Int32, ByVal mostrar As Int32, tipoPedido As Int32) As DataTable
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.ListarArticulos(listaPrecios, marca, coleccion, modelosay, modelosicy, mostrar, tipoPedido)
    End Function

    Public Function InsertarPedidoVirtual(ByVal tipoPedido As Int32, ByVal estatus As Int32, ByVal orden As String, ByVal cliente As Int32,
                                     ByVal listaPrecios As Int32, ByVal pares As Int32, ByVal observaciones As String, ByVal fechaSolicitud As Date,
                                     ByVal usuario As Int32, ByVal PedidosDetalles As String) As String
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.InsertarPedidoVirtual(tipoPedido, estatus, orden, cliente, listaPrecios, pares, observaciones, fechaSolicitud, usuario, PedidosDetalles)
    End Function

    Public Function EditarPedidoVirtual(ByVal orden As String, ByVal pedido As Int32,
                                     ByVal listaPrecios As Int32, ByVal pares As Int32, ByVal observaciones As String, ByVal fechaSolicitud As Date,
                                     ByVal usuario As Int32, ByVal fechaProgramacion As Date, ByVal PedidosDetalles As String) As String
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.EditarPedidoVirtual(orden, pedido, listaPrecios, pares, observaciones, fechaSolicitud, usuario, fechaProgramacion, PedidosDetalles)
    End Function

    Public Function ListaPedidosVirtuales(ByVal fechaCapInic As Date, ByVal fechaCapFin As Date, ByVal fechaSolInic As Date, ByVal fechaSolFin As Date,
                                          ByVal fechaProgInic As Date, ByVal fechaProgFin As Date, ByVal alerta As Int32, ByVal cliente As Int32,
                                          ByVal estatus As Int32, ByVal captura As Int32, ByVal solicita As Int32, ByVal programa As Int32) As DataTable
        Dim objDA As New Datos.PedidosVirtualesDA
        Dim tabla As DataTable

        tabla = objDA.ListaPedidosVirtuales(fechaCapInic, fechaCapFin, fechaSolInic, fechaSolFin, fechaProgInic, fechaProgFin, cliente, estatus, captura, solicita, programa, alerta)
        Return tabla
    End Function

    Public Function ObtenerDetalleArticulos(ByVal pedido As Int32, tipoPedido As Int32, ByVal listaPrecios As Int32, ByVal estatus As Int32) As DataTable
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.ObtenerDetalleArticulos(pedido, tipoPedido, listaPrecios, estatus)
    End Function

    Public Function obtenerBitacora(ByVal idPedido As Int32) As DataTable
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.obtenerBitacora(idPedido)
    End Function

    Public Function ConfirmarPedido(ByVal pedido As Int32, ByVal usuario As Int32) As DataTable
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.ConfirmarPedido(pedido, usuario)
    End Function

    Public Function AutorizarPedido(ByVal pedido As Int32, ByVal usuario As Int32) As DataTable
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.AutorizarPedido(pedido, usuario)
    End Function

    Public Function CancelarPedido(ByVal pedido As Int32, ByVal motivo As String, ByVal usuario As Int32) As DataTable
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.cancelarPedido(pedido, motivo, usuario)
    End Function

    Public Function obtenerPedidosReales(ByVal cliente As Int32) As DataTable
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.obtenerPedidosReales(cliente)
    End Function

    Public Function vincularPedidoVirtual(ByVal pedidoVirtual As Int32, ByVal pedidoReal As String, ByVal usuario As Int32, ByVal numPedidos As Int32) As DataTable
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.vincularPedidoVirtual(pedidoVirtual, pedidoReal, usuario, numPedidos)
    End Function

    Public Function ActualizarPedidoVirtualReal(ByVal pedidoVirtual As Int32, ByVal usuario As Int32) As DataTable
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.ActualizarPedidoVirtualReal(pedidoVirtual, usuario)
    End Function

    Public Function BuscarAgentes(ByVal pedidoVirtual As Int32) As DataTable
        Dim objDA As New Datos.PedidosVirtualesDA
        'Dim tabla As DataTable
        'Dim agentes As Int32

        'tabla = objDA.BuscarAgentes(pedidoVirtual)
        'For Each row As DataRow In tabla.Rows
        '    agentes = CInt(row("Agente").ToString)
        'Next
        Return objDA.BuscarAgentes(pedidoVirtual)

    End Function

    Public Function convertirPedidoReal(ByVal pedidoVirtual As Int32, ByVal agente As Int32, ByVal usuario As Int32, ByVal registros As Int32, ByVal detalles As String) As DataTable
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.convertirPedidoReal(pedidoVirtual, agente, usuario, registros, detalles)
    End Function

    Public Function obtenerPedidosRealesConvertidos(ByVal pedidoVirtual As Int32) As String
        Dim objDA As New Datos.PedidosVirtualesDA
        Dim tabla As DataTable
        Dim pedidos As String = ""

        tabla = objDA.obtenerPedidosRealesConvertidos(pedidoVirtual)
        For Each row As DataRow In tabla.Rows
            pedidos += row("pvpr_pedidoid").ToString + ","
        Next
        Return pedidos

    End Function

    Public Function ValidarArticulosImportacion(ByVal listaPrecios As Int32, ByVal marca As String, ByVal coleccion As String, ByVal modelosay As String,
                                                ByVal modelosicy As String, ByVal temporada As String, ByVal estatus As String, ByVal piel As String,
                                                ByVal color As String, ByVal corrida As String, ByVal tipoPedido As Int32) As DataTable
        Dim objDA As New Datos.PedidosVirtualesDA
        Return objDA.ValidarArticulosImportacion(listaPrecios, marca, coleccion, modelosay, modelosicy, temporada, estatus, piel, color, corrida, tipoPedido)
    End Function

End Class
