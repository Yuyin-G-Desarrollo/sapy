Public Class PedidosBu
    '' funcion que inserta el encabezado del pedido
    Public Function InsertarEncabezadoPedido(ByVal encabezadoPedido As Entidades.PedidosWeb, ByVal archivoImportado As Boolean) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtEncabezado As New DataTable
        dtEncabezado = objDa.InsertarEncabezadoPedido(encabezadoPedido, archivoImportado)
        Return dtEncabezado
    End Function

    'funcion que inserta los detalles del pedido (partidas)
    Public Function insertarDetallesPedido(ByVal detallePedido As Entidades.PedidosWebDetalles) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtDetalle As New DataTable
        dtDetalle = objDa.insertarDetallesPedido(detallePedido)
        Return dtDetalle
    End Function

    'funcion que inserta el detalle de las tallas 
    Public Sub insertarDetallePorTalla(ByVal pedidoDetalleId As Int32, ByVal productoEstiloId As Int32, ByVal clienteId As Int32,
                                       ByVal talla As String, ByVal cantidad As Int32, ByVal usuarioCreo As Int32, ByVal pdta_pedidodetalleportallaid As Int32,
                                       ByVal tipoOperacion As Int32, ByVal tipoNumeracion As String)
        Dim objDa As New Datos.PedidosDA

        objDa.insertarDetallePorTalla(pedidoDetalleId, productoEstiloId, clienteId, talla, cantidad, usuarioCreo, pdta_pedidodetalleportallaid, tipoOperacion, tipoNumeracion)
    End Sub

    ''funcion para consultar los detalles del pedido
    Public Function consultarDetallesPedido(ByVal idPedido As Int32, ByVal idListaPrecio As Int32, ByVal idUsuario As Int32, ByVal esAPartado As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtDetalles As New DataTable
        dtDetalles = objDa.consultarDetallesPedido(idPedido, idListaPrecio, idUsuario, esAPartado)
        Return dtDetalles
    End Function

    'funcion para consultar los detalles de la talla
    Public Function consultarDetallesTalla(ByVal extranjero As Int32, ByVal productoEstiloId As Int32, ByVal idTalla As Int32,
                                           ByVal cantidaPares As Int32, ByVal consultaStock As Int32, ByVal idCliente As Int32,
                                           ByVal pedidoDetalle As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtTallas As New DataTable
        dtTallas = objDa.consultarDetallesTalla(extranjero, productoEstiloId, idTalla, cantidaPares, consultaStock, idCliente, pedidoDetalle)
        Return dtTallas
    End Function

    ''funcion para obtener la consulta del articulo seleccionado en tallas
    Public Function consultaDetalleArticuloTallas(ByVal productoEstiloId As Int32, idListaPrecio As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtArticulo As New DataTable
        dtArticulo = objDa.consultaDetalleArticuloTallas(productoEstiloId, idListaPrecio)
        Return dtArticulo
    End Function

    'funcion para saber si alguna de las partidas guardadas es posible copiar su numeracion
    Public Function recuperarConsultaPartidasMismaCorrida(ByVal idPedidoSay As Int32, ByVal idListaPrecio As Int32, ByVal idTalla As Int32, ByVal idPedidoDetalle As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtPartidasRepetidas As New DataTable
        dtPartidasRepetidas = objDa.recuperarConsultaPartidasMismaCorrida(idPedidoSay, idListaPrecio, idTalla, idPedidoDetalle)
        Return dtPartidasRepetidas
    End Function

    ''funcion que recupera el detalle del modelo original a copiar
    Public Function recuperarModeloOriginalACopiar(ByVal pedidoDetalleId As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtModeloCopiar As New DataTable
        dtModeloCopiar = objDa.recuperarModeloOriginalACopiar(pedidoDetalleId)
        Return dtModeloCopiar
    End Function

    ''funcion para validar si existen fracciones arancelarias
    Public Function validarFraccionesArancelarias(ByVal productoEstiloId As Int32, ByVal idTalla As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtMensaje As New DataTable
        dtMensaje = objDa.validarFraccionesArancelarias(productoEstiloId, idTalla)
        Return dtMensaje
    End Function

    ''funcion para copiar numeracion de tallas de un pedido detalle a otro
    Public Sub copiarNumeracionPedidoDetalles(ByVal idPedidoDetalleOriginal As Int32, ByVal pedidoACopiar As String, ByVal usuarioCreo As Int32)
        Dim objDa As New Datos.PedidosDA
        objDa.copiarNumeracionPedidoDetalles(idPedidoDetalleOriginal, pedidoACopiar, usuarioCreo)
    End Sub


    ''funcion para consultar el encabezado del pedido 
    Public Function consultarEncabezadoPedido(ByVal idPedidoSay As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtencabezado As New DataTable
        dtencabezado = objDa.consultarEncabezadoPedido(idPedidoSay)
        Return dtencabezado
    End Function


    ''inicia bloque con consultas del administrador de pedidos

    'consulta general del administrador de pedidos
    Public Function consultaGeneralAdministradorPed(ByVal idCliente As Int32, ByVal idPedidoSay As Int32, ByVal idPedidoSicy As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtGeneral As New DataTable

        dtGeneral = objDa.consultaGeneralAdministradorPed(idCliente, idPedidoSay, idPedidoSicy)
        Return dtGeneral
    End Function

    ''consulta para verificar que todas las partidas cuenten con tallas
    Public Function validarPartidasConTallas(ByVal idPedidoSay As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtPartidas As New DataTable

        dtPartidas = objDa.validarPartidasConTallas(idPedidoSay)
        Return dtPartidas
    End Function

    ''consulta para pasar un pedido a sicy 
    Public Function copiarPedidoASicy(ByVal idPedidoSay As Int32, ByVal usuarioID As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtDatos As New DataTable

        dtDatos = objDa.copiarPedidoASicy(idPedidoSay, usuarioID)
        Return dtDatos
    End Function

    ''consulta del detalle de tallas 
    Public Function consultarDetalleTallasConsulta(ByVal pedidoDetalleId As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtDetalleTalla As New DataTable
        dtDetalleTalla = objDa.consultarDetalleTallasConsulta(pedidoDetalleId)
        Return dtDetalleTalla
    End Function

    ''sentencia para actualizar el pedido Tec del pedido detalles
    Public Sub actualizarPedidoTecPD(ByVal pedidoDetalleId As Int32, ByVal pedidoTec As String)
        Dim objDa As New Datos.PedidosDA
        objDa.actualizarPedidoTecPD(pedidoDetalleId, pedidoTec)
    End Sub

    ''sentencia para actualizar la anotacion del pedido detalles
    Public Sub actualizarAnotacionPD(ByVal pedidoDetalleId As Int32, ByVal anotacion As String)
        Dim objDa As New Datos.PedidosDA
        objDa.actualizarAnotacionPD(pedidoDetalleId, anotacion)
    End Sub

    ''funcion con los permisos correspondiente al usuario y al pedido
    Public Function obtenerListaPermisosUsuarioPedido(ByVal idPedidoSay As Int32, ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtPermisos As New DataTable
        dtPermisos = objDa.obtenerListaPermisosUsuarioPedido(idPedidoSay, idUsuario)
        Return dtPermisos
    End Function

    ''funcion para editar el encabezado del pedido 
    Public Sub editarEncabezadoPedido(ByVal encabezadoPedido As Entidades.PedidosWeb, ByVal idpedidoSay As Int32)
        Dim objDa As New Datos.PedidosDA
        objDa.editarEncabezadoPedido(encabezadoPedido, idpedidoSay)
    End Sub

    'funcion para actualizar el Agente del pedido
    Public Sub actualizarAgentePedido(ByVal idAgente As Int32, ByVal idPedidoSay As Int32)
        Dim objDa As New Datos.PedidosDA
        objDa.actualizarAgentePedido(idAgente, idPedidoSay)
    End Sub

    'funcion para actualizar la fecha de programacion del pedido
    Public Sub actualizarFechaProgramacionPedido(ByVal fechaProgramacion As Date, ByVal idPedidoSay As Int32)
        Dim objDa As New Datos.PedidosDA
        objDa.actualizarFechaProgramacionPedido(fechaProgramacion, idPedidoSay)
    End Sub

    ''funcion para copiar un pedido completo
    Public Function copiarPedidoCompleto(ByVal PedidoIDSAYOriginal As Int32, ByVal ClienteIdSAY As Int32, ByVal UsuarioModificaID As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtResultados As New DataTable
        dtResultados = objDa.copiarPedidoCompleto(PedidoIDSAYOriginal, ClienteIdSAY, UsuarioModificaID)
        Return dtResultados
    End Function

    ''funcion para descartar un pedido completo 
    Public Function descartarPedidoCompleto(ByVal PedidoIDSAY As Int32, ByVal UsuarioModificaID As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtRDescartar As New DataTable
        dtRDescartar = objDa.descartarPedidoCompleto(PedidoIDSAY, UsuarioModificaID)
        Return dtRDescartar
    End Function

    ''funcion para validar si un pedido se puede cancelar o no
    Public Function validarPosibleCancelacionPedido(ByVal idPedidoSay As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtValidar As New DataTable
        dtValidar = objDa.validarPosibleCancelacionPedido(idPedidoSay)
        Return dtValidar
    End Function

    ''funcion para consultar los conceptos de cancelacion
    Public Function conceptosCancelaciones() As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtConceptos As New DataTable

        dtConceptos = objDa.conceptosCancelaciones
        Return dtConceptos
    End Function

    ''funcion para cancelar un pedido
    Public Function cancelarPedido(ByVal PedidoIDSAY As Int32, ByVal EstatusCancelacionID As Int32, ByVal UsuarioModificaID As Int32, ByVal RazonCancelacion As String) As DataTable
        Dim dtMensaje As New DataTable
        Dim objDa As New Datos.PedidosDA
        dtMensaje = objDa.cancelarPedido(PedidoIDSAY, EstatusCancelacionID, UsuarioModificaID, RazonCancelacion)
        Return dtMensaje
    End Function

    '' funcion para confirmar un pedido
    Public Function confirmarPedido(ByVal idPedidoSay As Int32, ByVal usuarioModifico As Int32) As DataTable
        Dim dtResultados As New DataTable
        Dim objDa As New Datos.PedidosDA
        dtResultados = objDa.confirmarPedido(idPedidoSay, usuarioModifico)
        Return dtResultados
    End Function

    'Funcion para copiar renglones del pedido
    Public Function copiarPartidasMismoPedido(ByVal PedidoIDSAY As Int32, ByVal PedidoDetalleID As String, ByVal UsuarioModificaID As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtRenglon As New DataTable
        dtRenglon = objDa.copiarPartidasMismoPedido(PedidoIDSAY, PedidoDetalleID, UsuarioModificaID)
        Return dtRenglon
    End Function

    ''funcion para obtener los correos en caso de que cuente con la bandera de enviar correos
    Public Function obtenerCorreosEnvioConfirmacion(ByVal idCliente As Int32, ByVal idMarcas As String, ByVal clave As String, ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtCorreos As New DataTable
        dtCorreos = objDa.obtenerCorreosEnvioConfirmacion(idCliente, idMarcas, clave, idPedido)
        Return dtCorreos
    End Function

    ''funcion para consultar la bitacora de las partidas.
    Public Function consultarBitacoraPartidas(ByVal idPedidoDetalleId As String) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtBitacora As New DataTable
        dtBitacora = objDa.consultarBitacoraPartidas(idPedidoDetalleId)
        Return dtBitacora
    End Function

    '' funcion para descartar una partida (eliminar renglon)
    Public Function descartarPartidaPedido(ByVal PedidoIDSAY As Int32, ByVal PedidoDetalleID As String, ByVal UsuarioModificaID As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtResultados As New DataTable
        dtResultados = objDa.descartarPartidaPedido(PedidoIDSAY, PedidoDetalleID, UsuarioModificaID)
        Return dtResultados
    End Function

    ''funcion para obtener el numero de talla por id de talla insertada en la partida del pedido
    Public Function totalTallasPorPedido(ByVal idPedidoSay As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtTotal As New DataTable
        dtTotal = objDa.totalTallasPorPedido(idPedidoSay)
        Return dtTotal
    End Function

    ''funcion para obtener los detalles para la consulta del reporte
    Public Function generarConsultaReportePedidosPorTalla(ByVal idPedidoSay As Int32, ByVal idTalla As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtReporte As New DataTable
        dtReporte = objDa.generarConsultaReportePedidosPorTalla(idPedidoSay, idTalla)
        Return dtReporte
    End Function

    ''funcion para copiar partidas a otras tiendas
    Public Function copiarPartidasAOtrasTiendas(ByVal ClienteIdSAY As Int32, ByVal PedidoIDSAYOriginal As Int32, ByVal PedidoDetalleID As String,
                                                ByVal PedidoIDSAYDestino As Int32, ByVal TiendaEmbarqueCedisID As String, ByVal UsuarioModificaID As Int32)
        Dim objDa As New Datos.PedidosDA
        Dim dtPartidas As New DataTable
        dtPartidas = objDa.copiarPartidasAOtrasTiendas(ClienteIdSAY, PedidoIDSAYOriginal, PedidoDetalleID, PedidoIDSAYDestino, TiendaEmbarqueCedisID, UsuarioModificaID)
        Return dtPartidas
    End Function

    ''funcion para cancelar una partida
    Public Function cancelarPartidaDePedido(ByVal PedidoIDSAY As Int32, ByVal PedidoDetalleID As String, ByVal EstatusCancelacionID As Int32,
                                            ByVal RazonCancelacion As String, ByVal UsuarioModificaID As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtCancelacion As New DataTable
        dtCancelacion = objDa.cancelarPartidaDePedido(PedidoIDSAY, PedidoDetalleID, EstatusCancelacionID, RazonCancelacion, UsuarioModificaID)
        Return dtCancelacion
    End Function

    ''funcion para validar si una docena se puede o no registrar por los codigos amece
    Public Function validacionDocenaNormalConCodigosAmece(ByVal idPedidoDetalleId As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtAmece As New DataTable

        dtAmece = objDa.validacionDocenaNormalConCodigosAmece(idPedidoDetalleId)
        Return dtAmece
    End Function

    ''funcion para editar el ramo de un pedido 
    Public Sub editarRamoPedido(ByVal idpedidoSay As Int32, ByVal idRamo As Int32)
        Dim objDa As New Datos.PedidosDA
        objDa.editarRamoPedido(idpedidoSay, idRamo)
    End Sub

    ''funcion para editar la fecha de programacion de la partidas
    Public Sub editarFechaProgramacionPartida(ByVal idPedidoDetalle As Int32, ByVal fechaProgramacion As Date, ByVal idUsuario As Int32)
        Dim objDa As New Datos.PedidosDA
        objDa.editarFechaProgramacionPartida(idPedidoDetalle, fechaProgramacion, idUsuario)
    End Sub


    'funcion para actualizar el rfc del pedido
    Public Sub actualizarRFCPedido(ByVal idRFC As Int32, ByVal idPedidoSay As Int32, ByVal UsuarioModificaID As Int32)
        Dim objDa As New Datos.PedidosDA
        objDa.actualizarRFCPedido(idRFC, idPedidoSay, UsuarioModificaID)
    End Sub

    'funcion para actualizar la orden del cliente en el pedido
    Public Sub actualizarOrdenClientePedido(ByVal idPedidoSay As Int32, ByVal ordenCliente As String, ByVal UsuarioModificaID As Int32)
        Dim objDa As New Datos.PedidosDA
        objDa.actualizarOrdenClientePedido(idPedidoSay, ordenCliente, UsuarioModificaID)
    End Sub

    ''funcion para consultar los pedidos abiertos de un cliente 
    Public Function consultarPedidosAbiertoMismoCliente(ByVal idCliente As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtPedidos As New DataTable
        dtPedidos = objDa.consultarPedidosAbiertoMismoCliente(idCliente)
        Return dtPedidos
    End Function

    ''funcion para saber el rfc del pedido
    Public Function consultarRfcPedido(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtRFC As New DataTable
        dtRFC = objDa.consultarRfcPedido(idPedido)
        Return dtRFC
    End Function

    ''funcion para actualizar tiendas de varios pedidos detalles
    Public Sub ActualizarTiendasVariosPedidosDetalles(ByVal pedidoDetallesId As String, ByVal tiendaEmbarqueCediId As Int32, ByVal usuarioModificoId As Int32)
        Dim objDa As New Datos.PedidosDA
        objDa.ActualizarTiendasVariosPedidosDetalles(pedidoDetallesId, tiendaEmbarqueCediId, usuarioModificoId)
    End Sub


    ''funcion para recuperar los detalles de la cancelacion del pedido
    Public Function consultarDetallesCancelacionPedido(ByVal idPedido As Int32) As DataTable
        Dim dtDetalles As New DataTable
        Dim objDa As New Datos.PedidosDA
        dtDetalles = objDa.consultarDetallesCancelacionPedido(idPedido)
        Return dtDetalles
    End Function

    ''funcion para recuperar los detalles del encabezado del pedido en el reporte 
    Public Function generarEncabezadoReporte(ByVal idPedido As Int32) As DataTable
        Dim dtEncabezado As New DataTable
        Dim objDa As New Datos.PedidosDA

        dtEncabezado = objDa.generarEncabezadoReporte(idPedido)
        Return dtEncabezado
    End Function

    ''funcion para obtener los pares totales por Idtalla en el pedido
    Public Function generarTotalesDetallesReporte(ByVal idPedido As Int32, ByVal idTalla As Int32) As DataTable
        Dim dtTotales As New DataTable
        Dim objDa As New Datos.PedidosDA
        dtTotales = objDa.generarTotalesDetallesReporte(idPedido, idTalla)
        Return dtTotales
    End Function

    ''funcion para consultar el inventario de un detalle del pedido
    Public Function consultarInventarioDetallePedido(ByVal pedidoDetalleId As Int32) As DataTable
        Dim dtInventario As New DataTable
        Dim objDa As New Datos.PedidosDA

        dtInventario = objDa.consultarInventarioDetallePedido(pedidoDetalleId)
        Return dtInventario
    End Function

    'Funcion para validar el estatus y ver si es posible cancelar y actualizar tienda
    Public Function validarEstatusPedidosDetallesCount(ByVal pedidosDetalles As String) As DataTable
        Dim dtFilas As New DataTable
        Dim objDa As New Datos.PedidosDA

        dtFilas = objDa.validarEstatusPedidosDetallesCount(pedidosDetalles)
        Return dtFilas
    End Function

    ''funcion para actualizar la ruta del pedido escaneado
    Public Sub actualizarRutaPedidoEscaneado(ByVal idPedido As Int32, ByVal ruta As String)
        Dim objDa As New Datos.PedidosDA

        objDa.actualizarRutaPedidoEscaneado(idPedido, ruta)
    End Sub

    'Funcion para validar el estatus y ver si es posible copiar tienda, eliminar renglon
    Public Function validarEstatusPedidosCopiarEliminar(ByVal pedidosDetalles As String) As DataTable
        Dim dtCopiar As New DataTable
        Dim objDa As New Datos.PedidosDA

        dtCopiar = objDa.validarEstatusPedidosCopiarEliminar(pedidosDetalles)
        Return dtCopiar
    End Function

    ''consulta de la fecha de programacion propuesta del sistema
    Public Function consultaFechaProgramacionActual() As DataTable
        Dim dtFecha As New DataTable
        Dim objDa As New Datos.PedidosDA

        dtFecha = objDa.consultaFechaProgramacionActual
        Return dtFecha
    End Function


    ''actualiza entrega inmediata pedidos
    Public Sub actualizaEntregaInmediata(ByVal idPedido As Int32, ByVal entregaInmediata As Boolean, ByVal idUsuario As Int32)
        Dim objDa As New Datos.PedidosDA

        objDa.actualizaEntregaInmediata(idPedido, entregaInmediata, idUsuario)
    End Sub

    'Agregado para corroborar las fechas confirmables de pedidos
    Public Function ValidarFechasAConfirmarPedidoWeb(ByVal fecha) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtResultadoConsulta As New DataTable

        dtResultadoConsulta = objDa.ValidarFechasAConfirmarPedidoWeb(fecha)
        Return dtResultadoConsulta
    End Function

    'AGREGADO PARA VALIDAR QUE CUANDO UNA PARTIDA QUE ESTE EN DESCONTINUADO PARA PRODUCCION, NO PERMITA CONFIRMAR HASTA QUE LO PARTE
    Public Function ValidarArticuloDescontinuado(ByVal PedidoId As Integer) As DataTable
        Dim objDA As New Datos.PedidosDA
        Dim dtResConsulta As New DataTable

        dtResConsulta = objDA.ValidarArticuloDescontinuado(PedidoId)
        Return dtResConsulta
    End Function

    Public Function ValidarExistenciaEnStockCantidades(ByVal productoEstiloId As Int32, ByVal talla As String, ByVal cantidad As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim resultadoConsulta As New DataTable
        resultadoConsulta = objDa.ValidarExistenciaEnStockCantidades(productoEstiloId, talla, cantidad)
        Return resultadoConsulta
    End Function


#Region "Pakar Puebla"
    ''muestra tienda donde se entragara el producto
    Public Function IdTiendaEnvio(ByVal idcliente As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA

        Return objDa.IdTiendaEnvio(idcliente)
    End Function
    ''actualiza entrega inmediata pedidos
    Public Function pedidoclientePakarComprobacion(ByVal OrdenCliente As String) As DataTable

        Dim objDa As New Datos.PedidosDA

        Return objDa.pedidoclientePakarComprobacion(OrdenCliente)
    End Function
#End Region

#Region "codigos faltantes"

    Public Function consultarCodigosFaltantes(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtDetalles As New DataTable
        dtDetalles = objDa.consultarCodigosFaltantes(idPedido)
        Return dtDetalles
    End Function
#End Region

#Region "Varias fechas de entrega"
    Public Function permisoEntregaInmediata(ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim dtPermiso As New DataTable

        dtPermiso = objDa.permisoEntregaInmediata(idUsuario)
        Return dtPermiso
    End Function

    ''consulta con el numero de pedidos a generar
    Public Function numeroPedidosADividir(ByVal pedidoid As Int32) As DataTable
        Dim dtNumeroPedidos As New DataTable
        Dim objDa As New Datos.PedidosDA

        dtNumeroPedidos = objDa.numeroPedidosADividir(pedidoid)

        Return dtNumeroPedidos
    End Function

    ''consulta para dividir los pedidos
    Public Function dividirPedidosPrecaptura(ByVal pedidoId As Int32, ByVal idUsuario As Int32)
        Dim dtdividir As New DataTable
        Dim objDa As New Datos.PedidosDA

        dtdividir = objDa.dividirPedidosPrecaptura(pedidoId, idUsuario)

        Return dtdividir
    End Function

    ''consulta de los detalles del pedido generado
    Public Function consultaDetallesPedidosGenerados(ByVal pedidosConcatenados As String) As DataTable
        Dim dtDetalles As New DataTable
        Dim objDa As New Datos.PedidosDA

        dtDetalles = objDa.consultaDetallesPedidosGenerados(pedidosConcatenados)

        Return dtDetalles
    End Function

    Public Function numeroFechaProgrModificada(ByVal pedidoid As Int32) As DataTable
        Dim dtNumeroFechas As New DataTable
        Dim objDa As New Datos.PedidosDA

        dtNumeroFechas = objDa.numeroFechaProgrModificada(pedidoid)

        Return dtNumeroFechas
    End Function

    ''actualiza fecha programacion, entrega inmediata
    Public Function actualizaFechaProgrEntregaInmediata(ByVal fechaProgra As Date, ByVal idPedido As Int32, ByVal idUsuario As Int32)
        Dim dtActualiza As New DataTable
        Dim objDa As New Datos.PedidosDA

        dtActualiza = objDa.actualizaFechaProgrEntregaInmediata(fechaProgra, idPedido, idUsuario)

        Return dtActualiza
    End Function

    ''Actualiza la fecha de programaion modificada a la fecha devuelta por el sistema
    Public Function actualizaFechaProgrSistema(ByVal fechaProgra As Date, ByVal idPedido As Int32, ByVal idCliente As Int32, ByVal idUsuario As Int32)
        Dim dtActualiza As New DataTable
        Dim objDa As New Datos.PedidosDA

        dtActualiza = objDa.actualizaFechaProgrSistema(fechaProgra, idPedido, idCliente, idUsuario)

        Return dtActualiza
    End Function

    ''verfica quel pedido no este en sicy
    Public Function verificaExistePedidoSicy(ByVal pedidoId As Int32) As DataTable
        Dim dtExiste As New DataTable
        Dim objDa As New Datos.PedidosDA

        dtExiste = objDa.verificaExistePedidoSicy(pedidoId)

        Return dtExiste
    End Function

    ''consulta para dividir los pedidos abiertos
    Public Function dividirPedidosAbiertos(ByVal pedidoId As Int32, ByVal idUsuario As Int32)
        Dim dtdividir As New DataTable
        Dim objDa As New Datos.PedidosDA

        dtdividir = objDa.dividirPedidosAbiertos(pedidoId, idUsuario)

        Return dtdividir
    End Function

    ''consulta para cambiar estatus de pedido
    Public Function ActualizaEstatusPedidoSinDividir(ByVal pedidoId As Int32, ByVal idUsuario As Int32)
        Dim dtEstatus As New DataTable
        Dim objDa As New Datos.PedidosDA

        dtEstatus = objDa.ActualizaEstatusPedidoSinDividir(pedidoId, idUsuario)

        Return dtEstatus
    End Function

    ''Actualiza la fecha de programaion modificada a la fecha devuelta por el sistema
    Public Function actualizaFechaProgrSistemaAntesConfirmar(ByVal fechaProgra As Date, ByVal idPedido As Int32, ByVal idCliente As Int32, ByVal idUsuario As Int32)
        Dim dtActualiza As New DataTable
        Dim objDa As New Datos.PedidosDA

        dtActualiza = objDa.actualizaFechaProgrSistemaAntesConfirmar(fechaProgra, idPedido, idCliente, idUsuario)

        Return dtActualiza
    End Function

    ''Envia pedido a sicy en estatus confirmado
    Public Function enviaPedidoSicyConfirmado(ByVal pedidoId As Int32, ByVal idUsuario As Int32)
        Dim dtEnviaSicy As New DataTable
        Dim objDa As New Datos.PedidosDA

        dtEnviaSicy = objDa.enviaPedidoSicyConfirmado(pedidoId, idUsuario)

        Return dtEnviaSicy
    End Function

    ''actualiza fecha de programacion
    Public Function actualizaFechaProgramacionEncabezadoPartidas(ByVal pedidoId As Int32, ByVal idUsuario As Int32) As DataTable
        Dim dtActualiza As New DataTable
        Dim objDa As New Datos.PedidosDA

        dtActualiza = objDa.actualizaFechaProgramacionEncabezadoPartidas(pedidoId, idUsuario)

        Return dtActualiza
    End Function

#End Region
End Class
