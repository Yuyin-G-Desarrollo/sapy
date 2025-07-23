Public Class AdmonPedidosSapicaBU
    Public Function admonBasicoPedidosSapica() As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtAdmon As New DataTable
        dtAdmon = objDa.admonBasicoPedidosSapica()
        Return dtAdmon
    End Function


    ''consulta de agentes (alta de pedidos)
    Public Function consultaListadoAgentes(ByVal idVisitante As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtAgentes As New DataTable

        dtAgentes = objDa.consultaListadoAgentes(idVisitante)
        Return dtAgentes
    End Function


    ''consulta lista de precios sapica
    Public Function consultaListaPrecios(ByVal idVisitante As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtLp As New DataTable

        dtLp = objDa.consultaListaPrecios(idVisitante)
        Return dtLp
    End Function

    ''consulta lista de precios sapica pantalla productos
    Public Function consultaListaPreciosPantallaProductos(ByVal idVisitante As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtLp As New DataTable

        dtLp = objDa.consultaListaPreciosPantallaProductos(idVisitante)
        Return dtLp
    End Function

    ''consulta productos por modelo
    Public Function consultaProductosLPPorModelo(ByVal listaPreciosId As Int32, ByVal modeloSay As String, ByVal modeloSicy As String) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtProductos As New DataTable

        dtProductos = objDa.consultaProductosLPPorModelo(listaPreciosId, modeloSay, modeloSicy)
        Return dtProductos
    End Function

    ''consulta de productos por modelo sustituto
    Public Function consultaProductosModeloSustituto(ByVal listaPreciosId As Int32, ByVal modeloSay As String, ByVal modeloSicy As String) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtProductosSus As New DataTable

        dtProductosSus = objDa.consultaProductosModeloSustituto(listaPreciosId, modeloSay, modeloSicy)

        Return dtProductosSus
    End Function

    ''consulta de productos por coleccion completa
    Public Function consultaProductosPorColeccionCompleta(ByVal listaPreciosId As Int32, ByVal modeloSay As String, ByVal modeloSicy As String) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtProductosCol As New DataTable

        dtProductosCol = objDa.consultaProductosPorColeccionCompleta(listaPreciosId, modeloSay, modeloSicy)

        Return dtProductosCol
    End Function

    'consulta de productos por marca coleccion
    Public Function consultaProductosPorMarcaColeccion(ByVal listaPreciosId As Int32, ByVal idMarcas As String, ByVal idColeccion As Int32, ByVal coleccion As String) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtProductosMC As New DataTable

        dtProductosMC = objDa.consultaProductosPorMarcaColeccion(listaPreciosId, idMarcas, idColeccion, coleccion)

        Return dtProductosMC
    End Function

    ''consulta de marcas pantalla productos
    Public Function consultaMarcasPantallaProductos(ByVal idListaPrecios As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtMarcas As New DataTable

        dtMarcas = objDa.consultaMarcasPantallaProductos(idListaPrecios)

        Return dtMarcas
    End Function

    ''inserta el encabezado de pedidos sapica
    Public Function insertaEncabezadoPedidosSapica(ByVal visitanteId As Int32, ByVal ordenCliente As String, ByVal colaboradorVendedor As Int32,
                                                   ByVal idListaPrecio As Int32, ByVal observaciones As String, ByVal fechaEntregaCliente As Date,
                                                   ByVal idUsuario As Int32) As DataTable

        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtPedido As New DataTable

        dtPedido = objDa.insertaEncabezadoPedidosSapica(visitanteId, ordenCliente, colaboradorVendedor, idListaPrecio, observaciones, fechaEntregaCliente, idUsuario)

        Return dtPedido
    End Function


    ''inserta detalles partida pedidos sapica
    Public Function insertaDetallePedidoSapica(ByVal idPedidoSapica As Int32, ByVal preferente As Int32, ByVal productoEstilo As String, ByVal cantidadPares As Int32,
                                               ByVal idListaPrecios As Int32, ByVal fechaEntregaProgramacion As Date, ByVal idUsuario As Int32) As DataTable

        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtDetalle As New DataTable

        dtDetalle = objDa.insertaDetallePedidoSapica(idPedidoSapica, preferente, productoEstilo, cantidadPares, idListaPrecios, fechaEntregaProgramacion, idUsuario)

        Return dtDetalle
    End Function

    ''consulta detalles pedido
    Public Function consultaDetallesPedidoSapica(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtPedido As New DataTable

        dtPedido = objDa.consultaDetallesPedidoSapica(idPedido)

        Return dtPedido
    End Function

    ''distribucion de tallas en docenas normales
    Public Function calculoDocenasNormalesPedidoDetalle(ByVal pedidoDetallesId As Int32, ByVal cantidad As Int32, ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtDocenas As New DataTable

        dtDocenas = objDa.calculoDocenasNormalesPedidoDetalle(pedidoDetallesId, cantidad, idUsuario)

        Return dtDocenas
    End Function

    ''consulta del detalle del articulo pantalla numeracion
    Public Function consultaDetalleArticuloNumeracion(ByVal pedidoDetalleId As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtArticulo As New DataTable

        dtArticulo = objDa.consultaDetalleArticuloNumeracion(pedidoDetalleId)

        Return dtArticulo
    End Function

    ''consulta numeracion por partida pantalla numeracion
    Public Function consultaNumeracionPartida(ByVal pedidoDetalleId As Int32, ByVal consultarStock As Int32, ByVal cantidadPares As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtNumeracion As New DataTable

        dtNumeracion = objDa.consultaNumeracionPartida(pedidoDetalleId, consultarStock, cantidadPares)

        Return dtNumeracion
    End Function

    ''consulta numero partidas y corridas
    Public Function consultaPartidasCorridas(ByVal pedidoDetalleId As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtPartidas As New DataTable

        dtPartidas = objDa.consultaPartidasCorridas(pedidoDetalleId)

        Return dtPartidas
    End Function

    ''consulta distribucion de corrida en la partida copiar numeracion
    Public Function consultaDistribucionCorridaCopiarNumeracion(ByVal pedidoDetalleId As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtDistribucion As New DataTable

        dtDistribucion = objDa.consultaDistribucionCorridaCopiarNumeracion(pedidoDetalleId)

        Return dtDistribucion
    End Function

    ''consulta lsitado partidas misma corrida copiar numeracion
    Public Function listadoPartidasCorridaCopiarNumeracion(ByVal pedidoDetalleId As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtPartidas As New DataTable

        dtPartidas = objDa.listadoPartidasCorridaCopiarNumeracion(pedidoDetalleId)

        Return dtPartidas
    End Function

    ''consulta para copiar la numeracion de las partidas
    Public Sub copiarNumeracionPartidasMismaCorrida(ByVal pedidoDetalleIdOriginal As Int32, ByVal pedidosDetallesDestino As Int32,
                                                         ByVal usuariocreo As Int32)
        Dim objDa As New Datos.AdmonPedidosSapicaDA

        objDa.copiarNumeracionPartidasMismaCorrida(pedidoDetalleIdOriginal, pedidosDetallesDestino, usuariocreo)
    End Sub

    ''consulta configuracion del cliente vinculado al visitante
    Public Function consultaConfiguracionCte(ByVal visitanteId As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtConfiguracion As New DataTable

        dtConfiguracion = objDa.consultaConfiguracionCte(visitanteId)
        Return dtConfiguracion
    End Function

    ''inserta detalles talla partida pedidos sapica

    Public Sub insertaDetallesTallaPartidas(ByVal pedidoDetalleId As Int32, ByVal cantidad As Int32, ByVal talla As String,
                                                 ByVal pedidoDetalleporTallaId As Int32, ByVal usuarioCreo As Int32, ByVal tipoOperacion As Int32,
                                                 ByVal tipoNumeracion As String)
        Dim objDa As New Datos.AdmonPedidosSapicaDA

        objDa.insertaDetallesTallaPartidas(pedidoDetalleId, cantidad, talla, pedidoDetalleporTallaId, usuarioCreo, tipoOperacion, tipoNumeracion)
    End Sub

    ''funcion para copiar partida pedido
    Public Function copiarRenglonPartidaPedido(ByVal pedidodosDetallesId As String, ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtCopiar As New DataTable
        dtCopiar = objDa.copiarRenglonPartidaPedido(pedidodosDetallesId, idUsuario)
        Return dtCopiar
    End Function

    ''funcion para descartar partidas del pedido
    Public Function descartarPartidaPedido(ByVal pedidosDetallesId As String, ByVal idusuario As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtDescartar As New DataTable
        dtDescartar = objDa.descartarPartidaPedido(pedidosDetallesId, idusuario)

        Return dtDescartar
    End Function


    ''consulta estatus pedido
    Public Function consultaEstatusPedido(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtEstatus As New DataTable
        dtEstatus = objDa.consultaEstatusPedido(idPedido)

        Return dtEstatus
    End Function

    ''consulta para cancelar partidas pedido
    Public Function cancelarPartidaPedido(ByVal pedidosDetallesId As String, ByVal idUsuario As Int32, ByVal motivoCancelacionId As Int32, ByVal motivo As String) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtCancelar As New DataTable
        dtCancelar = objDa.cancelarPartidaPedido(pedidosDetallesId, idUsuario, motivoCancelacionId, motivo)

        Return dtCancelar
    End Function

    ''consulta encabezado del pedido
    Public Function consultaEncabezadoPedido(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtEncabezado As New DataTable
        dtEncabezado = objDa.consultaEncabezadoPedido(idPedido)

        Return dtEncabezado
    End Function

    ''consulta para edityar observaciones y fecha programacion partida
    Public Function editarObservacionFechaPartida(ByVal pedidoDetalleId As Int32, ByVal observaciones As String,
                                                  ByVal fechaProgramacion As String, ByVal fprogmodif As Boolean, ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtEditar As New DataTable
        dtEditar = objDa.editarObservacionFechaPartida(pedidoDetalleId, observaciones, fechaProgramacion, fprogmodif, idUsuario)

        Return dtEditar
    End Function
    ''consultar nueva edicion observacion partida
    Public Function editarObservacionPartida(ByVal pedidoDetalleId As Int32, ByVal observaciones As String, ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtEditar As New DataTable
        dtEditar = objDa.editarObservacionPartida(pedidoDetalleId, observaciones, idUsuario)

        Return dtEditar
    End Function

    ''consulta permisos boton cancelar partida
    Public Function permisoBotonCancelarPartida(ByVal pedidoDetalleId As Int32, ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtPermiso As New DataTable
        dtPermiso = objDa.permisoBotonCancelarPartida(pedidoDetalleId, idUsuario)

        Return dtPermiso
    End Function

    ''consulta de inventario por partida
    Public Function consultaInventarioPartida(ByVal pedidoDetalleId As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtInventario As New DataTable
        dtInventario = objDa.consultaInventarioPartida(pedidoDetalleId)

        Return dtInventario
    End Function

    ''consulta permiso boton confirmar
    Public Function consultaPermisoBotonConfirmar(ByVal idPedido As Int32, ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtPermiso As New DataTable
        dtPermiso = objDa.consultaPermisoBotonConfirmar(idPedido, idUsuario)

        Return dtPermiso
    End Function

    ''consulta para confirmar un pedido 
    Public Function confirmarPedido(ByVal idPedido As Int32, ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtConfirmar As New DataTable
        dtConfirmar = objDa.confirmarPedido(idPedido, idUsuario)

        Return dtConfirmar
    End Function

    ''consulta para descartar pedido
    Public Function descartarPedido(ByVal idPedido As Int32, ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtDescartar As New DataTable
        dtDescartar = objDa.descartarPedido(idPedido, idUsuario)

        Return dtDescartar
    End Function

    ''consulta para cancelar un pedido
    Public Function cancelarPedido(ByVal idPedido As Int32, ByVal idUsuario As Int32, ByVal motivoId As Int32, ByVal motivo As String) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtCancelar As New DataTable
        dtCancelar = objDa.cancelarPedido(idPedido, idUsuario, motivoId, motivo)

        Return dtCancelar
    End Function

    ''consulta permiso guardar pedido
    Public Function consultaPermisoBotonGuardarPedido(ByVal idPedido As Int32, ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtGuardar As New DataTable
        dtGuardar = objDa.consultaPermisoBotonGuardarPedido(idPedido, idUsuario)

        Return dtGuardar
    End Function

    ''consulta para guardar cambios en el pedido
    Public Function guardarCambiosPedido(ByVal idPedido As Int32, ByVal idAgente As Int32, ByVal ordenVisitante As String,
                                         ByVal notasPedido As String, ByVal fechaEntrega As Date, ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtGuardarCambios As New DataTable
        dtGuardarCambios = objDa.guardarCambiosPedido(idPedido, idAgente, ordenVisitante, notasPedido, fechaEntrega, idUsuario)

        Return dtGuardarCambios
    End Function

    ''consulta validacion de partidas canceladas
    Public Function consultaValidacionPartidasCanceladas(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtValidacion As New DataTable
        dtValidacion = objDa.consultaValidacionPartidasCanceladas(idPedido)

        Return dtValidacion
    End Function

    ''consulta con el listado de todos los agentwe
    Public Function consultaTodosAgentes() As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtAgentes As New DataTable
        dtAgentes = objDa.consultaTodosAgentes()

        Return dtAgentes
    End Function

    ''consulta encabezado reporte 
    Public Function consultaEncabezadoReportePedido(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtEncabezado As New DataTable
        dtEncabezado = objDa.consultaEncabezadoReportePedido(idPedido)

        Return dtEncabezado
    End Function

    ''consulta tallas totales en partida
    Public Function consultaTallasTotalesPedido(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtTallas As New DataTable
        dtTallas = objDa.consultaTallasTotalesPedido(idPedido)

        Return dtTallas
    End Function


    ''consulta de los detalles de partidas reporte pedido
    Public Function detallesPartidasReportePedido(ByVal idPedido As Int32, ByVal idTalla As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtDetalles As New DataTable
        dtDetalles = objDa.detallesPartidasReportePedido(idPedido, idTalla)

        Return dtDetalles
    End Function

    ''consulta de los totales del reporte de pedidos
    Public Function consultaTotalesReportePedido(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtTotales As New DataTable
        dtTotales = objDa.consultaTotalesReportePedido(idPedido)

        Return dtTotales
    End Function

    ''consulta totales por partida reporte pedidos
    Public Function detallesPartidasTotalesReportePedido(ByVal idPedido As Int32, ByVal idTalla As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtTotales As New DataTable
        dtTotales = objDa.detallesPartidasTotalesReportePedido(idPedido, idTalla)

        Return dtTotales
    End Function

#Region "Cambios en captura de pedidos SAPICA"

    Public Function consultaTECSCliente(ByVal idVisitante As Int32) As DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        Dim dtTiendas As New DataTable
        dtTiendas = objDa.consultaTECSCliente(idVisitante)

        Return dtTiendas

    End Function

    Public Sub actualizaTiendaPedidoDetalleSapica(ByVal pedidoDetalleSapicaid As Int32, ByVal idTec As Int32, ByVal usuarioid As Int32)
        Dim objDa As New Datos.AdmonPedidosSapicaDA
        objDa.actualizaTiendaPedidoDetalleSapica(pedidoDetalleSapicaid, idTec, usuarioid)

    End Sub

    Public Function ConsultaPedidosMismoVisitante(ByVal idVisitante As Int32) As DataTable
        Dim dtMismoPedido As New DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA

        dtMismoPedido = objDa.ConsultaPedidosMismoVisitante(idVisitante)

        Return dtMismoPedido
    End Function

    Public Function ConsultaTecCopiarTiendas(ByVal idVisitante As Int32) As DataTable
        Dim dtTEC As New DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA

        dtTEC = objDa.ConsultaTecCopiarTiendas(idVisitante)

        Return dtTEC
    End Function

    Public Function copiarPartidasOtrasTiendas(ByVal idPedidoOriginal As Int32, ByVal idDetalleOriginal As Int32,
                                              ByVal idPedidoDestino As Int32, ByVal tecsIds As String, ByVal usuarioModifica As Int32) As DataTable
        Dim dtResul As New DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA

        dtResul = objDa.copiarPartidasOtrasTiendas(idPedidoOriginal, idDetalleOriginal, idPedidoDestino, tecsIds, usuarioModifica)

        Return dtResul
    End Function

    Public Function copiarPartidasOtrasTiendasObservacion(ByVal idPedidoOriginal As Int32, ByVal idDetalleOriginal As Int32,
                                           ByVal idPedidoDestino As Int32, ByVal observacion As String, ByVal usuarioModifica As Int32) As DataTable
        Dim dtResul As New DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA

        dtResul = objda.copiarPartidasOtrasTiendasObservacion(idPedidoOriginal, idDetalleOriginal, idPedidoDestino, observacion, usuarioModifica)

        Return dtResul
    End Function


    Public Function copiarPedidoCompleto(ByVal pedidoOriginal As Int32, ByVal usuarioCreoid As Int32) As DataTable
        Dim dtPedidoNuevo As New DataTable
        Dim objDa As New Datos.AdmonPedidosSapicaDA

        dtPedidoNuevo = objDa.copiarPedidoCompleto(pedidoOriginal, usuarioCreoid)

        Return dtPedidoNuevo
    End Function

    Public Function validaEstatusActualizarPartidas(ByVal pedidosDetalles As String) As DataTable
        Dim dtTot As New DataTable
        Dim objDA As New Datos.AdmonPedidosSapicaDA

        dtTot = objDA.validaEstatusActualizarPartidas(pedidosDetalles)

        Return dtTot
    End Function

    Public Sub actualizaTiendaPartida(ByVal pedidosDetalles As String, ByVal idTec As Int32, ByVal idUsuario As Int32)
        Dim objDa As New Datos.AdmonPedidosSapicaDA

        objDa.actualizaTiendaPartida(pedidosDetalles, idTec, idUsuario)
    End Sub

    Public Sub actualizaFechaProgramacionPartida(ByVal pedidosDetalleId As String, ByVal fechaProgr As Date, ByVal idUsuario As Int32)
        Dim objDa As New Datos.AdmonPedidosSapicaDA

        objDa.actualizaFechaProgramacionPartida(pedidosDetalleId, fechaProgr, idUsuario)
    End Sub
#End Region
End Class
