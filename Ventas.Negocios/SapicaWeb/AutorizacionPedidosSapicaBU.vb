Public Class AutorizacionPedidosSapicaBU
    ''consulta para saber si el cliente esta bloqueado
    Public Function consultaClienteBloqueado(ByVal idCliente As Int32, ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.AutorizacionPedidosSapicaDA
        Dim dtBloqueo As New DataTable

        dtBloqueo = objDa.consultaClienteBloqueado(idCliente, idPedido)

        Return dtBloqueo
    End Function

    ''consulta de los datos del pedido pantalla autorizacion pedidos
    Public Function consultaDatosPedidoAutorizacion(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.AutorizacionPedidosSapicaDA
        Dim dtDatos As New DataTable

        dtDatos = objDa.consultaDatosPedidoAutorizacion(idPedido)

        Return dtDatos
    End Function

    ''consulta listado de clientes nuevos
    Public Function listadoClientesNuevos(ByVal idEvento As Int32) As DataTable
        Dim objDa As New Datos.AutorizacionPedidosSapicaDA
        Dim dtClientes As New DataTable

        dtClientes = objDa.listadoClientesNuevos(idEvento)

        Return dtClientes
    End Function

    ''validacion para saber si el visitante tiene cliente
    Public Function validacionClienteVisitante(ByVal idVisitante As Int32) As DataTable
        Dim objDa As New Datos.AutorizacionPedidosSapicaDA
        Dim dtVisitante As New DataTable

        dtVisitante = objDa.validacionClienteVisitante(idVisitante)

        Return dtVisitante
    End Function

    ''consulta listado de clientes existentes
    Public Function listadoClientesExistentes() As DataTable
        Dim objDa As New Datos.AutorizacionPedidosSapicaDA
        Dim dtClientes As New DataTable

        dtClientes = objDa.listadoClientesExistentes()

        Return dtClientes
    End Function

    ''Consulta de partidas por autorizar
    Public Function consultaPartidasPorAutorizar(ByVal idPedido As Int32, ByVal idCliente As Int32, ByVal idAgente As Int32,
                                                 ByVal idListaPrecios As Int32) As DataTable
        Dim objDa As New Datos.AutorizacionPedidosSapicaDA
        Dim dtPartidas As New DataTable

        dtPartidas = objDa.consultaPartidasPorAutorizar(idPedido, idCliente, idAgente, idListaPrecios)

        Return dtPartidas
    End Function

    ''consulta de las listas de precios del cliente
    Public Function consultaLPCliente(ByVal idCliente As Int32, ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.AutorizacionPedidosSapicaDA
        Dim dtLista As New DataTable

        dtLista = objDa.consultaLPCliente(idCliente, idPedido)

        Return dtLista
    End Function

    ''consulta para validar los articulos en la lista de precios
    Public Function validaArticulosEnLP(ByVal idPedido As Int32, ByVal idCliente As Int32, ByVal idAgente As Int32,
                                        ByVal idListaPrecios As Int32) As DataTable
        Dim objDa As New Datos.AutorizacionPedidosSapicaDA
        Dim dtValidaLP As New DataTable

        dtValidaLP = objDa.validaArticulosEnLP(idPedido, idCliente, idAgente, idListaPrecios)

        Return dtValidaLP
    End Function


    ''consulta de los pedidos a generar
    Public Function consultaPedidosGenerar(ByVal idPedido As Int32, ByVal idCliente As Int32, ByVal idAgente As Int32, ByVal partidas As String,
                                           ByVal idLista As Int32) As DataTable
        Dim objDa As New Datos.AutorizacionPedidosSapicaDA
        Dim dtPedGenerar As New DataTable

        dtPedGenerar = objDa.consultaPedidosGenerar(idPedido, idCliente, idAgente, partidas, idLista)

        Return dtPedGenerar
    End Function

    ''inserta el encabezado del pedido sapica a pedido normal
    Public Function insertaEncabezadoPedidoSapicaAPedido(ByVal idCliente As Int32, ByVal idAgente As Int32, ByVal idListaPrecios As Int32,
                                                         ByVal idPedido As Int32, ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AutorizacionPedidosSapicaDA
        Dim dtInserta As New DataTable

        dtInserta = objDa.insertaEncabezadoPedidoSapicaAPedido(idCliente, idAgente, idListaPrecios, idPedido, idUsuario)

        Return dtInserta
    End Function

    ''inserta detalles del pedido sapica a pedido normal
    Public Function insertaDetallePedidoSapicaAPedido(ByVal PedidoIdSAY As String, ByVal pedidoIdSapica As Int32, ByVal idPartidaSapica As Int32,
                                                       ByVal Idusuario As Int32) As DataTable

        Dim objDa As New Datos.AutorizacionPedidosSapicaDA
        Dim dtInsertaDet As New DataTable

        dtInsertaDet = objDa.insertaDetallePedidoSapicaAPedido(PedidoIdSAY, pedidoIdSapica, idPartidaSapica, Idusuario)

        Return dtInsertaDet
    End Function

    ''inserta detalles talla del pedido sapica a pedido normal
    Public Function insertaDetalleTallasSapicaAPedido(ByVal PedidoDetalleId As Int32, ByVal idPedidoSapica As Int32, ByVal idPartidaSapica As Int32,
                                                      ByVal ClienteId As Int32, ByVal idUsuario As Int32) As DataTable

        Dim objDa As New Datos.AutorizacionPedidosSapicaDA
        Dim dtInsertaDetTallas As New DataTable

        dtInsertaDetTallas = objDa.insertaDetalleTallasSapicaAPedido(PedidoDetalleId, idPedidoSapica, idPartidaSapica, ClienteId, idUsuario)

        Return dtInsertaDetTallas
    End Function

    ''consulta permiso boton autorizar
    Public Function permisoBotonAutorizar(ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AutorizacionPedidosSapicaDA
        Dim dtPermiso As New DataTable

        dtPermiso = objDa.permisoBotonAutorizar(idUsuario)

        Return dtPermiso
    End Function
End Class
