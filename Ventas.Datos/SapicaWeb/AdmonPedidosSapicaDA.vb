Imports System.Data.SqlClient

Public Class AdmonPedidosSapicaDA
    ''administrador basico pedidos
    Public Function admonBasicoPedidosSapica() As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Return persistencia.EjecutaConsulta("EXEC Sapica.[SP_PedidosWeb_ConsultaAdmonBasico]")
    End Function

    ''consulta de agentes (alta de pedidos)
    Public Function consultaListadoAgentes(ByVal idVisitante As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idVisitante"
        parametro.Value = idVisitante
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[SAPICA].[SP_PedidosWeb_ListadoAgentes]", listaParametros)
    End Function

    ''consulta lista de precios sapica
    Public Function consultaListaPrecios(ByVal idVisitante As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idVisitante"
        parametro.Value = idVisitante
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.Pedidos_Web_CosultaListaPrecios", listaParametros)
    End Function

    ''consulta lista de precios sapica pantalla productos
    Public Function consultaListaPreciosPantallaProductos(ByVal idVisitante As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idVisitante"
        parametro.Value = idVisitante
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.Pedidos_Web_CosultaListaPreciosPantallaProductos", listaParametros)
    End Function

    ''consulta productos por modelo
    Public Function consultaProductosLPPorModelo(ByVal listaPreciosId As Int32, ByVal modeloSay As String, ByVal modeloSicy As String) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idListaPrecios"
        parametro.Value = listaPreciosId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modeloSay"
        parametro.Value = modeloSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modeloSicy"
        parametro.Value = modeloSicy
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.Pedidos_Web_ConsultaProductosPorModelo", listaParametros)
    End Function

    ''consulta de productos por modelo sustituto
    Public Function consultaProductosModeloSustituto(ByVal listaPreciosId As Int32, ByVal modeloSay As String, ByVal modeloSicy As String) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idListaPrecios"
        parametro.Value = listaPreciosId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modeloSay"
        parametro.Value = modeloSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modeloSicy"
        parametro.Value = modeloSicy
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.Pedidos_Web_ConsultaProductosModeloSustitutos", listaParametros)
    End Function

    ''consulta de productos por coleccion completa
    Public Function consultaProductosPorColeccionCompleta(ByVal listaPreciosId As Int32, ByVal modeloSay As String, ByVal modeloSicy As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idListaPrecio"
        parametro.Value = listaPreciosId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modeloSay"
        parametro.Value = modeloSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modeloSicy"
        parametro.Value = modeloSicy
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.Pedidos_Web_ConsultaProductosColeccionCompleta", listaParametros)
    End Function

    'consulta de productos por marca coleccion
    Public Function consultaProductosPorMarcaColeccion(ByVal listaPreciosId As Int32, ByVal idMarcas As String, ByVal idColeccion As Int32, ByVal coleccion As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idListaPrecio"
        parametro.Value = listaPreciosId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idMarcas"
        parametro.Value = idMarcas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idColeccion"
        parametro.Value = idColeccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "coleccion"
        parametro.Value = coleccion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.Pedidos_Web_ConsultaProductosPorMarcaColeccion", listaParametros)
    End Function


    ''consulta de marcas pantalla productos
    Public Function consultaMarcasPantallaProductos(ByVal idListaPrecios As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idListaPrecios"
        parametro.Value = idListaPrecios
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.Pedidos_Web_ConsultaMarcasPantallaProductos", listaParametros)
    End Function

    ''inserta el encabezado de pedidos sapica
    Public Function insertaEncabezadoPedidosSapica(ByVal visitanteId As Int32, ByVal ordenCliente As String, ByVal colaboradorVendedor As Int32,
                                                   ByVal idListaPrecio As Int32, ByVal observaciones As String, ByVal fechaEntregaCliente As Date,
                                                   ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "visitanteId"
        parametro.Value = visitanteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ordenCliente"
        parametro.Value = ordenCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorVendedor"
        parametro.Value = colaboradorVendedor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idListaPrecio"
        parametro.Value = idListaPrecio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "observaciones"
        parametro.Value = observaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaEntregaCliente"
        parametro.Value = fechaEntregaCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)


        Return persistencia.EjecutarConsultaSP("Sapica.Pedidos_Web_InsertaEncabezadoPedidoSapica", listaParametros)
    End Function

    ''inserta detalles partida pedidos sapica
    Public Function insertaDetallePedidoSapica(ByVal idPedidoSapica As Int32, ByVal preferente As Int32, ByVal productoEstilo As String, ByVal cantidadPares As Int32,
                                               ByVal idListaPrecios As Int32, ByVal fechaEntregaProgramacion As Date, ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idPedidoSapica"
        parametro.Value = idPedidoSapica
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "preferente"
        parametro.Value = preferente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaProgramacion"
        parametro.Value = fechaEntregaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "productoEstilo"
        parametro.Value = productoEstilo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cantidadPares"
        parametro.Value = cantidadPares
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idListaPrecios"
        parametro.Value = idListaPrecios
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaEntregaProgramacion"
        parametro.Value = fechaEntregaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.Pedidos_Web_InsertaPedidosDetallesSapica", listaParametros)
    End Function

    ''consulta detalles pedido
    Public Function consultaDetallesPedidoSapica(ByVal idPedido As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idPedidoSapica"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_ConsultaDetallesPedido", listaParametros)
    End Function

    ''distribucion de tallas en docenas normales
    Public Function calculoDocenasNormalesPedidoDetalle(ByVal pedidoDetallesId As Int32, ByVal cantidad As Int32, ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "pedidoDetallesId"
        parametro.Value = pedidoDetallesId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cantidad"
        parametro.Value = cantidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_CalculoDocenaNormal_Sapica", listaParametros)
    End Function

    ''consulta del detalle del articulo pantalla numeracion
    Public Function consultaDetalleArticuloNumeracion(ByVal pedidoDetalleId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "pedidoDetalleId"
        parametro.Value = pedidoDetalleId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_ConsultaArticuloNumeracion", listaParametros)
    End Function

    ''consulta numeracion por partida pantalla numeracion
    Public Function consultaNumeracionPartida(ByVal pedidoDetalleId As Int32, ByVal consultarStock As Int32, ByVal cantidadPares As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "pedidoDetalleId"
        parametro.Value = pedidoDetalleId
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "consultarStock"
        parametro.Value = consultarStock
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "cantidadPares"
        parametro.Value = cantidadPares
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_ConsultaNumeracion", listaParametros)
    End Function

    ''consulta numero partidas y corridas
    Public Function consultaPartidasCorridas(ByVal pedidoDetalleId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "pedidoDetalleId"
        parametro.Value = pedidoDetalleId
        listaParametros.Add(parametro)


        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_PartidasMismaCorrida", listaParametros)
    End Function

    ''consulta distribucion de corrida en la partida copiar numeracion
    Public Function consultaDistribucionCorridaCopiarNumeracion(ByVal pedidoDetalleId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "pedidoDetalleId"
        parametro.Value = pedidoDetalleId
        listaParametros.Add(parametro)


        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_DistribucionCorridaCopiarNumeracion", listaParametros)
    End Function

    ''consulta lsitado partidas misma corrida copiar numeracion
    Public Function listadoPartidasCorridaCopiarNumeracion(ByVal pedidoDetalleId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "pedidoDetalleId"
        parametro.Value = pedidoDetalleId
        listaParametros.Add(parametro)


        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_ListadoPartidasMismaCorrida", listaParametros)
    End Function

    ''consulta para copiar la numeracion de las partidas
    Public Sub copiarNumeracionPartidasMismaCorrida(ByVal pedidoDetalleIdOriginal As Int32, ByVal pedidosDetallesDestino As Int32,
                                                         ByVal usuariocreo As Int32)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "pedidoDetalleIdOriginal"
        parametro.Value = pedidoDetalleIdOriginal
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "pedidosDetallesDestino"
        parametro.Value = pedidosDetallesDestino
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreo"
        parametro.Value = usuariocreo
        listaParametros.Add(parametro)


        persistencia.EjecutarSentenciaSP("Sapica.SP_PedidosWeb_CopiarNumeracionPartidas", listaParametros)
    End Sub

    ''consulta configuracion del cliente vinculado al visitante
    Public Function consultaConfiguracionCte(ByVal visitanteId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "visitanteId"
        parametro.Value = visitanteId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_ConsultaConfiguracionCte", listaParametros)
    End Function

    ''inserta detalles talla partida pedidos sapica

    Public Sub insertaDetallesTallaPartidas(ByVal pedidoDetalleId As Int32, ByVal cantidad As Int32, ByVal talla As String,
                                                 ByVal pedidoDetalleporTallaId As Int32, ByVal usuarioCreo As Int32, ByVal tipoOperacion As Int32,
                                                 ByVal tipoNumeracion As String)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidoDetalleId"
        parametro.Value = pedidoDetalleId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cantidad"
        parametro.Value = cantidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "talla"
        parametro.Value = talla
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidoDetalleporTallaId"
        parametro.Value = pedidoDetalleporTallaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioCreo"
        parametro.Value = usuarioCreo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoOperacion"
        parametro.Value = tipoOperacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoNumeracion"
        parametro.Value = tipoNumeracion
        listaParametros.Add(parametro)

        persistencia.EjecutarSentenciaSP("Sapica.SP_PedidosWeb_InsertaPedidoDetalle_PorTalla", listaParametros)
    End Sub

    ''funcion para copiar partida pedido
    Public Function copiarRenglonPartidaPedido(ByVal pedidodosDetallesId As String, ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidodosDetallesId"
        parametro.Value = pedidodosDetallesId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_CopiarPartidas", listaParametros)
    End Function

    ''funcion para descartar partidas del pedido
    Public Function descartarPartidaPedido(ByVal pedidosDetallesId As String, ByVal idusuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidosDetallesId"
        parametro.Value = pedidosDetallesId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idusuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_DescartarPartidaPedido", listaParametros)
    End Function

    ''consulta estatus pedido
    Public Function consultaEstatusPedido(ByVal idPedido As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_COnsultaEstatusPedido", listaParametros)
    End Function

    ''consulta para cancelar partidas pedido
    Public Function cancelarPartidaPedido(ByVal pedidosDetallesId As String, ByVal idUsuario As Int32, ByVal motivoCancelacionId As Int32, ByVal motivo As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidoDetallesId"
        parametro.Value = pedidosDetallesId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "motivoCancelacionId"
        parametro.Value = motivoCancelacionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "motivo"
        parametro.Value = motivo
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_CancelarPartidaPedido", listaParametros)
    End Function

    ''consulta encabezado del pedido
    Public Function consultaEncabezadoPedido(ByVal idPedido As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_ConsultaEncabezadoPedido", listaParametros)
    End Function

    ''consulta para edityar observaciones y fecha programacion partida
    Public Function editarObservacionFechaPartida(ByVal pedidoDetalleId As Int32, ByVal observaciones As String,
                                                  ByVal fechaProgramacion As String, ByVal fprogmodif As Boolean, ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidoDetalleId"
        parametro.Value = pedidoDetalleId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "observaciones"
        parametro.Value = observaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacion"
        parametro.Value = fechaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fprogmodif"
        parametro.Value = fprogmodif
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_EditarObservacionFechaPartida", listaParametros)
    End Function

    Public Function editarObservacionPartida(ByVal pedidoDetalleId As Int32, ByVal observaciones As String, ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidoDetalleId"
        parametro.Value = pedidoDetalleId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "observaciones"
        parametro.Value = observaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("SAPICA.SP_PedidosWeb_EditarObservacionPartidaSapica", listaParametros)
    End Function

    ''consulta permisos boton cancelar partida
    Public Function permisoBotonCancelarPartida(ByVal pedidoDetalleId As Int32, ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidoDetalleId"
        parametro.Value = pedidoDetalleId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)


        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_PermisoCancelarPartida", listaParametros)
    End Function

    ''consulta de inventario por partida
    Public Function consultaInventarioPartida(ByVal pedidoDetalleId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidoDetalleId"
        parametro.Value = pedidoDetalleId
        listaParametros.Add(parametro)


        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_ConsultaInventarioDetallePedido", listaParametros)
    End Function

    ''consulta permiso boton confirmar
    Public Function consultaPermisoBotonConfirmar(ByVal idPedido As Int32, ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_PermisoConfirmarPedido", listaParametros)
    End Function

    ''consulta para confirmar un pedido 
    Public Function confirmarPedido(ByVal idPedido As Int32, ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_ConfirmarPedido", listaParametros)
    End Function

    ''consulta para descartar pedido
    Public Function descartarPedido(ByVal idPedido As Int32, ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_DescartarPedido", listaParametros)
    End Function


    ''consulta para cancelar un pedido
    Public Function cancelarPedido(ByVal idPedido As Int32, ByVal idUsuario As Int32, ByVal motivoId As Int32, ByVal motivo As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "motivoId"
        parametro.Value = motivoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "motivo"
        parametro.Value = motivo
        listaParametros.Add(parametro)
        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_CancelarPedido", listaParametros)
    End Function

    ''consulta permiso guardar pedido
    Public Function consultaPermisoBotonGuardarPedido(ByVal idPedido As Int32, ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_PermisoGuardarPedido", listaParametros)
    End Function

    ''consulta para guardar cambios en el pedido
    Public Function guardarCambiosPedido(ByVal idPedido As Int32, ByVal idAgente As Int32, ByVal ordenVisitante As String,
                                         ByVal notasPedido As String, ByVal fechaEntrega As Date, ByVal idUsuario As Int32) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idAgente"
        parametro.Value = idAgente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ordenVisitante"
        parametro.Value = ordenVisitante
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "notasPedido"
        parametro.Value = notasPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaEntrega"
        parametro.Value = fechaEntrega
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)
        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_GuardarPedido", listaParametros)

    End Function

    ''consulta validacion de partidas canceladas
    Public Function consultaValidacionPartidasCanceladas(ByVal idPedido As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_ValidaExistenciaPartidasCanceladas", listaParametros)
    End Function

    ''consulta con el listado de todos los agentwe
    Public Function consultaTodosAgentes() As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = " Exec Sapica.SP_PedidosWeb_ConsultaTodosAgentes"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta encabezado reporte 
    Public Function consultaEncabezadoReportePedido(ByVal idPedido As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_ConsultaEncabezadoReporteSapica", listaParametros)
    End Function

    ''consulta tallas totales en partida
    Public Function consultaTallasTotalesPedido(ByVal idPedido As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_TotalTallasReportePedido", listaParametros)
    End Function


    ''consulta de los detalles de partidas reporte pedido
    Public Function detallesPartidasReportePedido(ByVal idPedido As Int32, ByVal idTalla As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idTalla"
        parametro.Value = idTalla
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_ConsultaDetallesReportePedido", listaParametros)
    End Function

    ''consulta de los totales del reporte de pedidos
    Public Function consultaTotalesReportePedido(ByVal idPedido As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_TotalesReportePedido", listaParametros)
    End Function

    ''consulta totales por partida reporte pedidos
    Public Function detallesPartidasTotalesReportePedido(ByVal idPedido As Int32, ByVal idTalla As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idTalla"
        parametro.Value = idTalla
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_ConsultaDetallesTotalesReportePedido", listaParametros)
    End Function

#Region "Cambios en captura de pedidos SAPICA"

    Public Function consultaTECSCliente(ByVal idVisitante As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idVisitante"
        parametro.Value = idVisitante
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_Pedidos_Web_ConsultaTECSCliente", listaParametros)

    End Function

    Public Sub actualizaTiendaPedidoDetalleSapica(ByVal pedidoDetalleSapicaid As Int32, ByVal idTec As Int32, ByVal usuarioid As Int32)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "pedidoDetalleSapicaId"
        parametro.Value = pedidoDetalleSapicaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idTec"
        parametro.Value = idTec
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioid"
        parametro.Value = usuarioid
        listaParametros.Add(parametro)

        persistencia.EjecutarSentenciaSP("Sapica.SP_Pedidos_Web_ActualizaTECPedidoDetalleSapica", listaParametros)
    End Sub

    Public Function ConsultaPedidosMismoVisitante(ByVal idVisitante As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "visitantesID"
        parametro.Value = idVisitante
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_ConsultaPedidosMismoVisitante", listaParametros)

    End Function

    Public Function ConsultaTecCopiarTiendas(ByVal idVisitante As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idVisitante"
        parametro.Value = idVisitante
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_Pedidos_Web_ConsultaTECSVisitanteCopiarT", listaParametros)

    End Function

    Public Function copiarPartidasOtrasTiendas(ByVal idPedidoOriginal As Int32, ByVal idDetalleOriginal As Int32,
                                               ByVal idPedidoDestino As Int32, ByVal tecsIds As String, ByVal usuarioModifica As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idPedidoOriginal"
        parametro.Value = idPedidoOriginal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idDetalleOriginal"
        parametro.Value = idDetalleOriginal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idpedidoDestino"
        parametro.Value = idPedidoDestino
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TiendaEmbarqueCedisID"
        parametro.Value = tecsIds
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModificaID"
        parametro.Value = usuarioModifica
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_Pedidos_Web_CopiaPartidasTECS", listaParametros)
    End Function

    Public Function copiarPartidasOtrasTiendasObservacion(ByVal idPedidoOriginal As Int32, ByVal idDetalleOriginal As Int32,
                                               ByVal idPedidoDestino As Int32, ByVal observacion As String, ByVal usuarioModifica As Int32) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idPedidoOriginal"
        parametro.Value = idPedidoOriginal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idDetalleOriginal"
        parametro.Value = idDetalleOriginal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idpedidoDestino"
        parametro.Value = idPedidoDestino
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "observacion"
        parametro.Value = observacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModificaID"
        parametro.Value = usuarioModifica
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_Pedidos_Web_CopiaPartidasObservacion", listaParametros)
    End Function

    Public Function copiarPedidoCompleto(ByVal pedidoOriginal As Int32, ByVal usuarioCreoid As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idPedidoOriginal"
        parametro.Value = pedidoOriginal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = usuarioCreoid
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_Pedidos_Web_CopiaPedidoCompleto", listaParametros)
    End Function

    Public Function validaEstatusActualizarPartidas(ByVal pedidosDetalles As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "pedidosDetallesID"
        parametro.Value = pedidosDetalles
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_ValidaEstatusActualizarPartidas", listaParametros)

    End Function

    Public Sub actualizaTiendaPartida(ByVal pedidosDetalles As String, ByVal idTec As Int32, ByVal idUsuario As Int32)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "pedidosDetallesId"
        parametro.Value = pedidosDetalles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idTiendaEmbarque"
        parametro.Value = idTec
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuarioModifico"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        persistencia.EjecutarSentenciaSP("Sapica.SP_PedidosWeb_ActualizaTiendaPedidosDetalles", listaParametros)

    End Sub

    Public Sub actualizaFechaProgramacionPartida(ByVal pedidosDetalleId As String, ByVal fechaProgr As Date, ByVal idUsuario As Int32)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "pedidoDetalleId"
        parametro.Value = pedidosDetalleId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaProgramacion"
        parametro.Value = fechaProgr
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        persistencia.EjecutarSentenciaSP("Sapica.SP_PedidosWeb_EditarFechaProgramacionPartidaSapica", listaParametros)

    End Sub
#End Region

End Class
