Imports System.Data.SqlClient

Public Class PedidosDA
    '' funcion que inserta el encabezado del pedido
    Public Function InsertarEncabezadoPedido(ByVal encabezadoPedido As Entidades.PedidosWeb, ByVal archivoImportado As Boolean) As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        consulta = <consulta>
                     declare @idPedidoSay int
                     exec Ventas.SP_PedidosWeb_AltaPedidos <%= encabezadoPedido.PClienteIdSay.ToString %> , <%= encabezadoPedido.PColaborador_vendedorId.ToString %>
                     , <%= encabezadoPedido.PListaPreciosId.ToString %>, <%= encabezadoPedido.PRfcId.ToString %>, <%= encabezadoPedido.PRamoId.ToString %>, <%= encabezadoPedido.PTipoPedidoId.ToString %>
                     , <%= encabezadoPedido.PIncial.ToString %>, '<%= encabezadoPedido.POrdenCliente.ToString %>' , <%= encabezadoPedido.PEntregaInmediata %>, '<%= encabezadoPedido.PFechaProgramacion %>'  
                     , '<%= encabezadoPedido.PFechasolicitadaCliente %>', '<%= encabezadoPedido.PRutaPedidoScanneado.ToString %>'
                     , <%= encabezadoPedido.PIntercom.ToString %>, '<%= encabezadoPedido.PObservaciones.ToString %>', <%= encabezadoPedido.PRutaId.ToString %>, <%= encabezadoPedido.PMonedaId.ToString %>
                     ,<%= encabezadoPedido.PUsuarioCreoId.ToString %>,<%= archivoImportado %>,'<%= encabezadoPedido.PSolicitaClienteFecha %>', '<%= encabezadoPedido.PClaveCFDI %>', @idPedidoSay OUTPUT select @idPedidoSay as idPedido
                   </consulta>.Value
        Return persistencia.EjecutaConsulta(consulta)
    End Function

    'funcion que inserta los detalles del pedido (partidas)
    Public Function insertarDetallesPedido(ByVal detallePedido As Entidades.PedidosWebDetalles) As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "PedidoIdSAY"
        parametro.Value = detallePedido.PPedidoIdSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClienteIdSAY"
        parametro.Value = detallePedido.PClienteIdSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProductoEstiloId"
        parametro.Value = detallePedido.PProductoEstiloId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaProgramacion"
        parametro.Value = detallePedido.PFechaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaSolicitadaCliente"
        parametro.Value = detallePedido.PFechaSolicitadaCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Anotacion"
        parametro.Value = detallePedido.PAnotacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TiendaEmbarqueCEDISId"
        parametro.Value = detallePedido.PTiendaEmbarqueCEDISId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ListaPrecioCLienteId"
        parametro.Value = detallePedido.PListaPrecioCLienteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioCreo"
        parametro.Value = detallePedido.PusuarioCreo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "banderaOperacion"
        parametro.Value = detallePedido.PbanderaOperacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cantidad"
        parametro.Value = detallePedido.PCantidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidodetalleid"
        parametro.Value = detallePedido.PPedidodetalleid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoTEC"
        parametro.Value = detallePedido.PPedidoTEC
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoNumeracion"
        parametro.Value = detallePedido.PTipoNumeracion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_AltaPedidosDetalles", listaParametros)
    End Function


    'funcion que inserta el detalle de las tallas 
    Public Sub insertarDetallePorTalla(ByVal pedidoDetalleId As Int32, ByVal productoEstiloId As Int32, ByVal clienteId As Int32,
                                       ByVal talla As String, ByVal cantidad As Int32, ByVal usuarioCreo As Int32, ByVal pdta_pedidodetalleportallaid As Int32,
                                       ByVal tipoOperacion As Int32, ByVal tipoNumeracion As String)

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "PedidoDetalleId"
        parametro.Value = pedidoDetalleId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProductoEstiloId"
        parametro.Value = productoEstiloId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClienteId"
        parametro.Value = clienteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Talla"
        parametro.Value = talla
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cantidad"
        parametro.Value = cantidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioCreo"
        parametro.Value = usuarioCreo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pdta_pedidodetalleportallaid"
        parametro.Value = pdta_pedidodetalleportallaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoOperacion"
        parametro.Value = tipoOperacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoNumeracion"
        parametro.Value = tipoNumeracion
        listaParametros.Add(parametro)

        persistencia.EjecutarSentenciaSP("Ventas.SP_PedidosWeb_AltaPedidosDetallesPorTalla", listaParametros)
    End Sub

    ''funcion para consultar los detalles del pedido
    Public Function consultarDetallesPedido(ByVal idPedido As Int32, ByVal idListaPrecio As Int32, ByVal idUsuario As Int32, ByVal esAPartado As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idListaPrecio"
        parametro.Value = idListaPrecio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EsApartado"
        If esAPartado Then
            parametro.Value = 1
        Else
            parametro.Value = 0
        End If
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Consulta_DetallesPedido", listaParametros)
    End Function

    'funcion para consultar los detalles de la talla
    Public Function consultarDetallesTalla(ByVal extranjero As Int32, ByVal productoEstiloId As Int32, ByVal idTalla As Int32,
                                           ByVal cantidaPares As Int32, ByVal consultaStock As Int32, ByVal idCliente As Int32,
                                           ByVal pedidoDetalle As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim dtTallas As New DataTable

        parametro.ParameterName = "extranjero"
        parametro.Value = extranjero
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProductoEstiloId"
        parametro.Value = productoEstiloId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idTalla"
        parametro.Value = idTalla
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cantidadPares"
        parametro.Value = cantidaPares
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "consultarStock"
        parametro.Value = consultaStock
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idcliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidoDetalle"
        parametro.Value = pedidoDetalle
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Consulta_Tallas_NormalExt_V2", listaParametros)

    End Function


    ''funcion para obtener la consulta del articulo seleccionado en tallas
    Public Function consultaDetalleArticuloTallas(ByVal productoEstiloId As Int32, idListaPrecio As Int32) As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        consulta = <consulta>
                       SELECT (vlp.Marca + ' ' + vlp.Coleccion + ' ' + vlp.ModeloSAY + '   -   ' + vlp.Piel + '   -   ' + vlp.Color) as articulo,
                        vlp.ListaCliente,c.Cliente, vlp.Imagen,CASE c.Moneda WHEN 'DOLARES' THEN vlp.PrecioExtranjero ELSE vlp.Precio END as precio, 
                        vlp.ProductoEstiloID, vlp.IdColeccionSAY, vlp.ModeloSAY, vlp.idListaVentasClientePrecio,vlp.IdFamiliaSAY, vlp.IdMarcaSAY,vlp.IdLineaSAY
                        FROM Ventas.vListaPrecioClienteProductos vlp
                        INNER JOIN Ventas.vListaPrecioCliente c on c.idListaVentasClientePrecio=vlp.idListaVentasClientePrecio
                         WHERE ProductoEstiloID=<%= productoEstiloId.ToString %> AND vlp.idListaVentasClientePrecio=<%= idListaPrecio.ToString %>
                   </consulta>.Value
        Return persistencia.EjecutaConsulta(consulta)
    End Function

    'funcion para saber si alguna de las partidas guardadas es posible copiar su numeracion
    Public Function recuperarConsultaPartidasMismaCorrida(ByVal idPedidoSay As Int32, ByVal idListaPrecio As Int32, ByVal idTalla As Int32, ByVal idPedidoDetalle As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idPedidoSay"
        parametro.Value = idPedidoSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idListaPrecio"
        parametro.Value = idListaPrecio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idTalla"
        parametro.Value = idTalla
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPedidoDetalle"
        parametro.Value = idPedidoDetalle
        listaParametros.Add(parametro)


        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Consulta_Partidas_MismaCorrida", listaParametros)
    End Function

    ''funcion que recupera el detalle del modelo original a copiar
    Public Function recuperarModeloOriginalACopiar(ByVal pedidoDetalleId As Int32) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "pedidoDetalleId"
        parametro.Value = pedidoDetalleId
        listaParametros.Add(parametro)


        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ModeloOriginal_ACopiar", listaParametros)

    End Function

    ''funcion para validar si existen fracciones arancelarias
    Public Function validarFraccionesArancelarias(ByVal productoEstiloId As Int32, ByVal idTalla As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "productoEstiloId"
        parametro.Value = productoEstiloId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idTalla"
        parametro.Value = idTalla
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Validacion_FraccionesArancelarias", listaParametros)
    End Function

    ''funcion para copiar numeracion de tallas de un pedido detalle a otro
    Public Sub copiarNumeracionPedidoDetalles(ByVal idPedidoDetalleOriginal As Int32, ByVal pedidoACopiar As String, ByVal usuarioCreo As Int32)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idPedidoDetalleOriginal"
        parametro.Value = idPedidoDetalleOriginal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidoACopiar"
        parametro.Value = pedidoACopiar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioCreo"
        parametro.Value = usuarioCreo
        listaParametros.Add(parametro)

        persistencia.EjecutarSentenciaSP("Ventas.SP_PedidosWeb_Copiar_NumeracionPartidas", listaParametros)
    End Sub


    ''funcion para consultar el encabezado del pedido 
    Public Function consultarEncabezadoPedido(ByVal idPedidoSay As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idPedidoSay"
        parametro.Value = idPedidoSay
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Consulta_EncabezadoPedido", listaParametros)
    End Function


    ''inicia bloque con consultas del administrador de pedidos

    'consulta general del administrador de pedidos
    Public Function consultaGeneralAdministradorPed(ByVal idCliente As Int32, ByVal idPedidoSay As Int32, ByVal idPedidoSicy As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "clienteid"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidoSay"
        parametro.Value = idPedidoSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidoSicy"
        parametro.Value = idPedidoSicy
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Administrador_ConsultaBasicaGeneral", listaParametros)
    End Function

    ''consulta para verificar que todas las partidas cuenten con tallas
    Public Function validarPartidasConTallas(ByVal idPedidoSay As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idPedidoSay"
        parametro.Value = idPedidoSay
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Valida_PartidasconTallas", listaParametros)
    End Function

    ''consulta para pasar un pedido a sicy 
    Public Function copiarPedidoASicy(ByVal idPedidoSay As Int32, ByVal usuarioId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "PedidoIDSAY"
        parametro.Value = idPedidoSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModificaID"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_EnviarPedidoASICY", listaParametros)
    End Function

    ''consulta del detalle de tallas 
    Public Function consultarDetalleTallasConsulta(ByVal pedidoDetalleId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        '  consulta = <consulta>
        '              SELECT pd.pdet_pedidodetalleid,(pd.pdet_marca + ' ' + pd.pdet_coleccion + ' ' + lp.ModeloSAY + ' ' + pd.pdet_piel + ' ' + pd.pdet_color + ' ' + pd.pdet_corrida ) as articulo,
        '              pd.pdet_cantidadpares,
        '              isnull (pd.pdet_tiponumeracion,'') as tipoNumeracion, pd.pdet_tallaid, pd.pdet_precio, pd.pdet_productoestiloid
        '               FROM Ventas.PedidosDetalles pd 
        'INNER JOIN Ventas.Pedidos p on p.pedi_pedidoid=pd.pdet_pedidoid
        'INNER JOIN Programacion.vProductoEstilos_Todos lp on lp.ProductoEstiloId =pd.pdet_productoestiloid
        'WHERE pd.pdet_pedidodetalleid=<%= pedidoDetalleId.ToString %>
        '             </consulta>.Value

        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametros.ParameterName = "pedidoDetalleId"
        parametros.Value = pedidoDetalleId
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConsultaDetallesTallaEncabezado", listaParametros)
        'Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''sentencia para actualizar el pedido Tec del pedido detalles
    Public Sub actualizarPedidoTecPD(ByVal pedidoDetalleId As Int32, ByVal pedidoTec As String)
        Dim consulta As String
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        consulta = <consulta>
                       UPDATE Ventas.PedidosDetalles SET pdet_pedidotiendaembarquecedis='<%= pedidoTec.ToString %> '
                       WHERE pdet_pedidodetalleid=<%= pedidoDetalleId.ToString %>
                   </consulta>.Value
        persistencia.EjecutaConsulta(consulta)
    End Sub

    ''sentencia para actualizar la anotacion del pedido detalles
    Public Sub actualizarAnotacionPD(ByVal pedidoDetalleId As Int32, ByVal anotacion As String)
        'Dim consulta As String
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametros.ParameterName = "pedidoDetalleId"
        parametros.Value = pedidoDetalleId
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "anotacion"
        parametros.Value = anotacion
        listaParametros.Add(parametros)
        'consulta = <consulta>
        '               UPDATE Ventas.PedidosDetalles SET pdet_anotacion='<%= anotacion.ToString %>' WHERE pdet_pedidodetalleid=<%= pedidoDetalleId.ToString %>
        '           </consulta>.Value
        'persistencia.EjecutaConsulta(consulta)
        persistencia.EjecutarSentenciaSP("Ventas.SP_PedidosWeb_ActualizaAnotacionPedidosDetalles", listaParametros)
    End Sub

    ''funcion con los permisos correspondiente al usuario y al pedido
    Public Function obtenerListaPermisosUsuarioPedido(ByVal idPedidoSay As Int32, ByVal idUsuario As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idPedidoSay"
        parametro.Value = idPedidoSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_HabilitadoBotones_PedidoUsuario", listaParametros)
    End Function

    ''funcion para editar el encabezado del pedido 
    Public Sub editarEncabezadoPedido(ByVal encabezadoPedido As Entidades.PedidosWeb, ByVal idpedidoSay As Int32)
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos



        parametro = New SqlParameter
        parametro.ParameterName = "RamoId"
        parametro.Value = encabezadoPedido.PRamoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Inicial"
        parametro.Value = encabezadoPedido.PIncial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OrdenCliente"
        parametro.Value = encabezadoPedido.POrdenCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EntregaInmediata"
        parametro.Value = encabezadoPedido.PEntregaInmediata
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaSolicitadaCliente"
        parametro.Value = encabezadoPedido.PFechasolicitadaCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RutaPedidoScanneado"
        parametro.Value = encabezadoPedido.PRutaPedidoScanneado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "INCOTERMId"
        parametro.Value = encabezadoPedido.PIntercom
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ObservacionesPedido"
        parametro.Value = encabezadoPedido.PObservaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RutaId"
        parametro.Value = encabezadoPedido.PRutaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MonedaId"
        parametro.Value = encabezadoPedido.PMonedaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioModifico"
        parametro.Value = encabezadoPedido.PUsuarioCreoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdPedidoSAY"
        parametro.Value = idpedidoSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "solicitaCliente"
        parametro.Value = encabezadoPedido.PSolicitaClienteFecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "claveCFDI"
        parametro.Value = encabezadoPedido.PClaveCFDI
        listaParametros.Add(parametro)

        objPersistencia.EjecutarSentenciaSP("[Ventas].[SP_PedidosWeb_EdicionPedidosEncabezado]", listaParametros)
    End Sub


    'funcion para actualizar el Agente del pedido
    Public Sub actualizarAgentePedido(ByVal idAgente As Int32, ByVal idPedidoSay As Int32)
        Dim consulta As String
        Dim objPesistencia As New Persistencia.OperacionesProcedimientos
        consulta = "UPDATE Ventas.Pedidos set pedi_colaboradorid_vendedor=" + idAgente.ToString + " WHERE pedi_pedidoid=" + idPedidoSay.ToString
        objPesistencia.EjecutaConsulta(consulta)
    End Sub

    'funcion para actualizar la fecha de programacion del pedido
    Public Sub actualizarFechaProgramacionPedido(ByVal fechaProgramacion As Date, ByVal idPedidoSay As Int32)
        Dim consulta As String
        Dim objPesistencia As New Persistencia.OperacionesProcedimientos
        consulta = "UPDATE Ventas.Pedidos set pedi_fechaentregaprogramacion='" + fechaProgramacion.ToShortDateString + "' WHERE pedi_pedidoid=" + idPedidoSay.ToString
        objPesistencia.EjecutaConsulta(consulta)
    End Sub

    ''funcion para copiar un pedido completo
    Public Function copiarPedidoCompleto(ByVal PedidoIDSAYOriginal As Int32, ByVal ClienteIdSAY As Int32, ByVal UsuarioModificaID As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "PedidoIDSAYOriginal"
        parametro.Value = PedidoIDSAYOriginal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClienteIdSAY"
        parametro.Value = ClienteIdSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModificaID"
        parametro.Value = UsuarioModificaID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CopiarPedidoCompleto", listaParametros)
    End Function

    ''funcion para descartar un pedido completo 
    Public Function descartarPedidoCompleto(ByVal PedidoIDSAY As Int32, ByVal UsuarioModificaID As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "PedidoIDSAY"
        parametro.Value = PedidoIDSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModificaID"
        parametro.Value = UsuarioModificaID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_DescartarPedido", listaParametros)
    End Function

    ''funcion para validar si un pedido se puede cancelar o no
    Public Function validarPosibleCancelacionPedido(ByVal idPedidoSay As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idPedidoSay"
        parametro.Value = idPedidoSay
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Validar_CancelacionPedido", listaParametros)
    End Function

    ''funcion para consultar los conceptos de cancelacion
    Public Function conceptosCancelaciones() As DataTable
        Dim consulta As String = String.Empty
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        consulta = <consulta>
                     SELECT esta_estatusid, esta_orden,esta_descripcion FROM Framework.Estatus WHERE esta_tipostatus='PEDIDO_CANCELACION' ORDER BY esta_descripcion
                 </consulta>.Value
        Return objPersistencia.EjecutaConsulta(consulta)

    End Function

    ''funcion para cancelar un pedido
    Public Function cancelarPedido(ByVal PedidoIDSAY As Int32, ByVal EstatusCancelacionID As Int32, ByVal UsuarioModificaID As Int32, ByVal RazonCancelacion As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "PedidoIDSAY"
        parametro.Value = PedidoIDSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EstatusCancelacionID"
        parametro.Value = EstatusCancelacionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RazonCancelacion"
        parametro.Value = RazonCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModificaID"
        parametro.Value = UsuarioModificaID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CancelarPedido", listaParametros)

    End Function

    '' funcion para confirmar un pedido
    Public Function confirmarPedido(ByVal PedidoIDSAY As Int32, ByVal usuarioModifico As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "PedidoIDSAY"
        parametro.Value = PedidoIDSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModificaID"
        parametro.Value = usuarioModifico
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConfirmarPedido_2", listaParametros)
    End Function

    '' funcion para copiar renglones del pedido
    Public Function copiarPartidasMismoPedido(ByVal PedidoIDSAY As Int32, ByVal PedidoDetalleID As String, ByVal UsuarioModificaID As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "PedidoIDSAY"
        parametro.Value = PedidoIDSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoDetalleID"
        parametro.Value = PedidoDetalleID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModificaID"
        parametro.Value = UsuarioModificaID
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CopiarPartidas_MismoPedido", listaParametros)
    End Function

    ''funcion para obtener los correos en caso de que cuente con la bandera de enviar correos
    Public Function obtenerCorreosEnvioConfirmacion(ByVal idCliente As Int32, ByVal idMarcas As String, ByVal clave As String, ByVal idPedido As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim pararmetro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        pararmetro.ParameterName = "idCliente"
        pararmetro.Value = idCliente
        listaParametros.Add(pararmetro)

        pararmetro = New SqlParameter
        pararmetro.ParameterName = "idMarcas"
        pararmetro.Value = idMarcas
        listaParametros.Add(pararmetro)

        pararmetro = New SqlParameter
        pararmetro.ParameterName = "clave"
        pararmetro.Value = clave
        listaParametros.Add(pararmetro)

        pararmetro = New SqlParameter
        pararmetro.ParameterName = "idPedido"
        pararmetro.Value = idPedido
        listaParametros.Add(pararmetro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Correos_ConfirmacionPedidos", listaParametros)
    End Function

    ''funcion para consultar la bitacora de las partidas.
    Public Function consultarBitacoraPartidas(ByVal idPedidoDetalleId As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim pararmetro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        pararmetro.ParameterName = "PedidoDetalleID"
        pararmetro.Value = idPedidoDetalleId
        listaParametros.Add(pararmetro)


        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConsultaBitacora_Partidas", listaParametros)
    End Function

    '' funcion para descartar una partida (eliminar renglon)
    Public Function descartarPartidaPedido(ByVal PedidoIDSAY As Int32, ByVal PedidoDetalleID As String, ByVal UsuarioModificaID As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim pararmetro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        pararmetro.ParameterName = "PedidoIDSAY"
        pararmetro.Value = PedidoIDSAY
        listaParametros.Add(pararmetro)

        pararmetro = New SqlParameter
        pararmetro.ParameterName = "PedidoDetalleID"
        pararmetro.Value = PedidoDetalleID
        listaParametros.Add(pararmetro)

        pararmetro = New SqlParameter
        pararmetro.ParameterName = "UsuarioModificaID"
        pararmetro.Value = UsuarioModificaID
        listaParametros.Add(pararmetro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_DescartarPartidas", listaParametros)
    End Function

    ''funcion para obtener el numero de talla por id de talla insertada en la partida del pedido
    Public Function totalTallasPorPedido(ByVal idPedidoSay As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim pararmetro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        pararmetro.ParameterName = "idPedidoSay"
        pararmetro.Value = idPedidoSay
        listaParametros.Add(pararmetro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Partida_MayorNumeroTallas", listaParametros)
    End Function

    ''funcion para obtener los detalles para la consulta del reporte
    Public Function generarConsultaReportePedidosPorTalla(ByVal idPedidoSay As Int32, ByVal idTalla As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim pararmetro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        pararmetro.ParameterName = "idPedidoSay"
        pararmetro.Value = idPedidoSay
        listaParametros.Add(pararmetro)

        pararmetro = New SqlParameter
        pararmetro.ParameterName = "idTalla"
        pararmetro.Value = idTalla
        listaParametros.Add(pararmetro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_GenerarReportePedido", listaParametros)
    End Function

    ''funcion para copiar partidas a otras tiendas
    Public Function copiarPartidasAOtrasTiendas(ByVal ClienteIdSAY As Int32, ByVal PedidoIDSAYOriginal As Int32, ByVal PedidoDetalleID As String,
                                                ByVal PedidoIDSAYDestino As Int32, ByVal TiendaEmbarqueCedisID As String, ByVal UsuarioModificaID As Int32)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim pararmetro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        pararmetro.ParameterName = "ClienteIdSAY"
        pararmetro.Value = ClienteIdSAY
        listaParametros.Add(pararmetro)

        pararmetro = New SqlParameter
        pararmetro.ParameterName = "PedidoIDSAYOriginal"
        pararmetro.Value = PedidoIDSAYOriginal
        listaParametros.Add(pararmetro)

        pararmetro = New SqlParameter
        pararmetro.ParameterName = "PedidoDetalleID"
        pararmetro.Value = PedidoDetalleID
        listaParametros.Add(pararmetro)

        pararmetro = New SqlParameter
        pararmetro.ParameterName = "PedidoIDSAYDestino"
        pararmetro.Value = PedidoIDSAYDestino
        listaParametros.Add(pararmetro)

        pararmetro = New SqlParameter
        pararmetro.ParameterName = "TiendaEmbarqueCedisID"
        pararmetro.Value = TiendaEmbarqueCedisID
        listaParametros.Add(pararmetro)

        pararmetro = New SqlParameter
        pararmetro.ParameterName = "UsuarioModificaID"
        pararmetro.Value = UsuarioModificaID
        listaParametros.Add(pararmetro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CopiarPartidas_OtrasTiendas", listaParametros)
    End Function

    ''funcion para cancelar una partida
    Public Function cancelarPartidaDePedido(ByVal PedidoIDSAY As Int32, ByVal PedidoDetalleID As String, ByVal EstatusCancelacionID As Int32,
                                            ByVal RazonCancelacion As String, ByVal UsuarioModificaID As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim pararmetro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        pararmetro.ParameterName = "PedidoIDSAY"
        pararmetro.Value = PedidoIDSAY
        listaParametros.Add(pararmetro)

        pararmetro = New SqlParameter
        pararmetro.ParameterName = "PedidoDetalleID"
        pararmetro.Value = PedidoDetalleID
        listaParametros.Add(pararmetro)

        pararmetro = New SqlParameter
        pararmetro.ParameterName = "EstatusCancelacionID"
        pararmetro.Value = EstatusCancelacionID
        listaParametros.Add(pararmetro)

        pararmetro = New SqlParameter
        pararmetro.ParameterName = "RazonCancelacion"
        pararmetro.Value = RazonCancelacion
        listaParametros.Add(pararmetro)

        pararmetro = New SqlParameter
        pararmetro.ParameterName = "UsuarioModificaID"
        pararmetro.Value = UsuarioModificaID
        listaParametros.Add(pararmetro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CancelarPartidas", listaParametros)
    End Function

    ''funcion para validar si una docena se puede o no registrar por los codigos amece
    Public Function validacionDocenaNormalConCodigosAmece(ByVal idPedidoDetalleId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim pararmetro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        pararmetro.ParameterName = "pedidoDetalleId"
        pararmetro.Value = idPedidoDetalleId
        listaParametros.Add(pararmetro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ValidaCodigosAmeceCliente", listaParametros)
    End Function

    ''funcion para editar el ramo de un pedido 
    Public Sub editarRamoPedido(ByVal idpedidoSay As Int32, ByVal idRamo As Int32)
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        consulta = <consulta>
                     UPDATE Ventas.Pedidos SET pedi_ramoid=<%= idRamo.ToString %> WHERE pedi_pedidoid=<%= idpedidoSay %>
                   </consulta>.Value
        persistencia.EjecutaConsulta(consulta)
    End Sub

    ''funcion para editar la fecha de programacion de la partidas
    Public Sub editarFechaProgramacionPartida(ByVal idPedidoDetalle As Int32, ByVal fechaProgramacion As Date, ByVal idUsuario As Int32)
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "@fechaProgramacion"
        parametro.Value = fechaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idPedidoDetalle"
        parametro.Value = idPedidoDetalle
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        persistencia.EjecutarSentenciaSP("Ventas.SP_PedidosWebVFE_ActualizaFechaProgramacionPartida", listaParametros)
        'consulta = <consulta>
        '                UPDATE Ventas.PedidosDetalles SET pdet_fechaentregaprogramacion =CAST ('<%= fechaProgramacion.ToShortDateString %>' as date) WHERE pdet_pedidodetalleid=<%= idPedidoDetalle.ToString %>
        '           </consulta>.Value
        'persistencia.EjecutaConsulta(consulta)
    End Sub

    'funcion para actualizar el rfc del pedido
    Public Sub actualizarRFCPedido(ByVal idRFC As Int32, ByVal idPedidoSay As Int32, ByVal UsuarioModificaID As Int32)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim pararmetro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        pararmetro.ParameterName = "idPedidoSay"
        pararmetro.Value = idPedidoSay
        listaParametros.Add(pararmetro)

        pararmetro = New SqlParameter
        pararmetro.ParameterName = "idRfcPedido"
        pararmetro.Value = idRFC
        listaParametros.Add(pararmetro)

        pararmetro = New SqlParameter
        pararmetro.ParameterName = "UsuarioModificaID"
        pararmetro.Value = UsuarioModificaID
        listaParametros.Add(pararmetro)

        persistencia.EjecutarSentenciaSP("Ventas.SP_PedidosWeb_EditarRFCPedido", listaParametros)
    End Sub

    'funcion para actualizar la orden del cliente en el pedido
    Public Sub actualizarOrdenClientePedido(ByVal idPedidoSay As Int32, ByVal ordenCliente As String, ByVal UsuarioModificaID As Int32)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim pararmetro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        pararmetro.ParameterName = "idPedidoSay"
        pararmetro.Value = idPedidoSay
        listaParametros.Add(pararmetro)

        pararmetro = New SqlParameter
        pararmetro.ParameterName = "ordenCliente"
        pararmetro.Value = ordenCliente
        listaParametros.Add(pararmetro)

        pararmetro = New SqlParameter
        pararmetro.ParameterName = "UsuarioModificaID"
        pararmetro.Value = UsuarioModificaID
        listaParametros.Add(pararmetro)

        persistencia.EjecutarSentenciaSP("Ventas.SP_PedidosWeb_EditarOrdenClientePedido", listaParametros)
    End Sub

    ''funcion para consultar los pedidos abiertos de un cliente 
    Public Function consultarPedidosAbiertoMismoCliente(ByVal idCliente As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim pararmetro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        pararmetro.ParameterName = "ClienteIDSAY"
        pararmetro.Value = idCliente
        listaParametros.Add(pararmetro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Consulta_PedidosAbiertos_PorCliente", listaParametros)
    End Function

    ''funcion para saber el rfc del pedido
    Public Function consultarRfcPedido(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.PedidosDA
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = <consulta>
                       SELECT crfc_clienterfcid, 
                    CASE WHEN crfc_clasificacionpersonaid = 14 THEN 'F -' 
                    ELSE CASE WHEN crfc_clasificacionpersonaid = 13 THEN 'R - ' ELSE '? -' END 
                    END + UPPER(pers_nombre) +' ('+crfc_RFC+')' AS 'Persona' FROM Cliente.ClienteRFC 
                    JOIN Framework.Persona ON crfc_personaid = pers_personaid
					JOIN Ventas.Pedidos p on p.pedi_clienterfcid =  crfc_clienterfcid
					 where p.pedi_pedidoid=<%= idPedido.ToString %>
                     and crfc_activo = 1 ORDER BY pers_nombre
                   </consulta>.Value
        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''funcion para actualizar tiendas de varios pedidos detalles
    Public Sub ActualizarTiendasVariosPedidosDetalles(ByVal pedidoDetallesId As String, ByVal tiendaEmbarqueCediId As Int32, ByVal usuarioModificoId As Int32)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "pedidosDetallesId"
        parametro.Value = pedidoDetallesId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idTiendaEmbarque"
        parametro.Value = tiendaEmbarqueCediId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuarioModifico"
        parametro.Value = usuarioModificoId
        listaParametros.Add(parametro)

        persistencia.EjecutarSentenciaSP("Ventas.SP_PedidosWeb_Actualizar_Tienda_PedidosDetalles", listaParametros)
    End Sub

    ''funcion para recuperar los detalles de la cancelacion del pedido
    Public Function consultarDetallesCancelacionPedido(ByVal idPedido As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idPedidoSay"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_DetallesCancelacion_Pedido", listaParametros)
    End Function

    ''funcion para recuperar los detalles del encabezado del pedido en el reporte 
    Public Function generarEncabezadoReporte(ByVal idPedidoSay As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idPedidoSay"
        parametro.Value = idPedidoSay
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_GenerarEncabezado_ReportePedido", listaParametros)
    End Function

    ''funcion para obtener los pares totales por Idtalla en el pedido
    Public Function generarTotalesDetallesReporte(ByVal idPedido As Int32, ByVal idTalla As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idTalla"
        parametro.Value = idTalla
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_GenerarTotalesParesReporte", listaParametros)
    End Function

    ''funcion para consultar el inventario de un detalle del pedido
    Public Function consultarInventarioDetallePedido(ByVal pedidoDetalleId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "PedidoDetalleId"
        parametro.Value = pedidoDetalleId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Consulta_Inventario_PedidoDetalle", listaParametros)
    End Function

    'Funcion para validar el estatus y ver si es posible cancelar y actualizar tienda
    Public Function validarEstatusPedidosDetallesCount(ByVal pedidosDetalles As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "pedidosDetallesID"
        parametro.Value = pedidosDetalles
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ValidacionEstatusPartidas", listaParametros)
    End Function

    ''funcion para actualizar la ruta del pedido escaneado
    Public Sub actualizarRutaPedidoEscaneado(ByVal idPedido As Int32, ByVal ruta As String)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "UPDATE Ventas.Pedidos SET pedi_rutapedidoscanneado='" + ruta.ToString + "' WHERE pedi_pedidoid=" + idPedido.ToString

        persistencia.EjecutaConsulta(consulta)
    End Sub

    'Funcion para validar el estatus y ver si es posible copiar tienda, eliminar renglon
    Public Function validarEstatusPedidosCopiarEliminar(ByVal pedidosDetalles As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "pedidosDetallesID"
        parametro.Value = pedidosDetalles
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ValidacionEstatusCopiarEliminar", listaParametros)
    End Function

    ''consulta de la fecha de programacion propuesta del sistema
    Public Function consultaFechaProgramacionActual() As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = "EXEC Ventas.SP_PedidosWeb_ConsultaFechaProgramacion"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''actualiza entrega inmediata pedidos
    Public Sub actualizaEntregaInmediata(ByVal idPedido As Int32, ByVal entregaInmediata As Boolean, ByVal idUsuario As Int32)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "entregaInmediata"
        parametro.Value = entregaInmediata
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        persistencia.EjecutarSentenciaSP("Ventas.SP_PedidosWeb_ActualizarEntregaInmediata", listaParametros)
    End Sub

    'Agregado para corroborar las fechas confirmables de pedidos
    Public Function ValidarFechasAConfirmarPedidoWeb(ByVal fecha As Date) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "Fecha"
        parametro.Value = fecha
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "FechaSolicitada"
        'parametro.Value = fechaSlta
        'listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "FechaSolicitaCliente"
        'parametro.Value = fechaSolicitaCliente
        'listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_ValidarDiasFestivosNoConfirmablesParaPedidos", listaParametros)
    End Function

    'AGREGADO PARA VALIDAR QUE CUANDO UNA PARTIDA QUE ESTE EN DESCONTINUADO PARA PRODUCCION, NO PERMITA CONFIRMAR HASTA QUE LO PARTE
    Public Function ValidarArticuloDescontinuado(ByVal PedidoId As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaparametros As New List(Of SqlParameter)

        parametro.ParameterName = "PedidoId"
        parametro.Value = PedidoId
        listaparametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConfirmarEstatusProducto_AntesDeConfirmar", listaparametros)

    End Function

    Public Function ValidarExistenciaEnStockCantidades(ByVal productoEstiloId As Int32, ByVal talla As String, ByVal cantidad As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "ProductoStiloId"
        parametro.Value = productoEstiloId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "talla"
        parametro.Value = talla
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CanidadSolicitada"
        parametro.Value = cantidad
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_ValidarTotalStockCantidadSolicitada", listaParametros)
    End Function

#Region "Pakar"
    ''funcion para traer el iddetienda a donde se enviara el pedido
    Public Function IdTiendaEnvio(ByVal idcliente As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idcliente"
        parametro.Value = idcliente
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_IdTiendaEnvio", listaParametros)
    End Function

    ''funcion para traer el iddetienda a donde se enviara el pedido
    Public Function pedidoclientePakarComprobacion(ByVal OrdenCliente As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "OrdenCliente"
        parametro.Value = OrdenCliente
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_pedidoclientePakarComprobacion", listaParametros)
    End Function

#End Region

#Region "codigos cliente"
    Public Function consultarCodigosFaltantes(ByVal idPedido As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "pedidoID"
        parametro.Value = idPedido
        listaParametros.Add(parametro)



        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Consulta_CodigosFaltantes", listaParametros)
    End Function
#End Region

#Region "varias fechas de entrega"
    Public Function permisoEntregaInmediata(ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "@idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebVFE_PermisoFechaEntrega", listaParametros)
    End Function

    ''consulta con el numero de pedidos a generar
    Public Function numeroPedidosADividir(ByVal pedidoid As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idPedido"
        parametro.Value = pedidoid
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebVFE_NumeroPedidosADividir", listaParametros)
    End Function

    ''consulta para dividir los pedidos
    Public Function dividirPedidosPrecaptura(ByVal pedidoId As Int32, ByVal idUsuario As Int32)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "PedidoIDSAY"
        parametro.Value = pedidoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebVFE_DividirPedidoPreCapturado", listaParametros)
    End Function

    ''consulta de los detalles del pedido generado
    Public Function consultaDetallesPedidosGenerados(ByVal pedidosConcatenados As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "pedidosGenerados"
        parametro.Value = pedidosConcatenados
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebVFE_ConsultaDetallePedidosGenerados", listaParametros)
    End Function

    ''consulta con el numero de fechas programacion modificadas
    Public Function numeroFechaProgrModificada(ByVal pedidoid As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idPedido"
        parametro.Value = pedidoid
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebVFE_NumeroFechaProgramacionModificada", listaParametros)
    End Function

    ''actualiza fecha programacion, entrega inmediata
    Public Function actualizaFechaProgrEntregaInmediata(ByVal fechaProgra As Date, ByVal idPedido As Int32, ByVal idUsuario As Int32)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "fechaProgramacion"
        parametro.Value = fechaProgra
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebVFE_ActualizaFechaProgramacionPartidaInmediata", listaParametros)
    End Function

    ''Actualiza la fecha de programaion modificada a la fecha devuelta por el sistema
    Public Function actualizaFechaProgrSistema(ByVal fechaProgra As Date, ByVal idPedido As Int32, ByVal idCliente As Int32, ByVal idUsuario As Int32)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "fechaProgramacionCapturada"
        parametro.Value = fechaProgra
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebVFE_ActualizaFechaProgramacionPartidaSistema", listaParametros)
    End Function

    ''verfica quel pedido no este en sicy
    Public Function verificaExistePedidoSicy(ByVal pedidoId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "pedidoId"
        parametro.Value = pedidoId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebVFE_ValidaPedidoExisteSICY", listaParametros)
    End Function

    ''consulta para dividir los pedidosabiertos
    Public Function dividirPedidosAbiertos(ByVal pedidoId As Int32, ByVal idUsuario As Int32)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "PedidoIDSAY"
        parametro.Value = pedidoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebVFE_DividirPedidoAbierto", listaParametros)
    End Function

    ''consulta para cambiar estatus de pedido
    Public Function ActualizaEstatusPedidoSinDividir(ByVal pedidoId As Int32, ByVal idUsuario As Int32)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idPedido"
        parametro.Value = pedidoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebVFE_ActualizaEstatusAbierto", listaParametros)
    End Function

    ''Actualiza la fecha de programaion modificada a la fecha devuelta por el sistema antes de confirmar
    Public Function actualizaFechaProgrSistemaAntesConfirmar(ByVal fechaProgra As Date, ByVal idPedido As Int32, ByVal idCliente As Int32, ByVal idUsuario As Int32)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "fechaProgramacionCapturada"
        parametro.Value = fechaProgra
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebVFE_ActualizaFechaProgramacionPartidaAntesConfirmar", listaParametros)
    End Function

    ''Envia pedido a sicy en estatus confirmado
    Public Function enviaPedidoSicyConfirmado(ByVal pedidoId As Int32, ByVal idUsuario As Int32)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "PedidoIDSAY"
        parametro.Value = pedidoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModificaID"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebVFE_EnviarPedidoASICYConfirmado", listaParametros)
    End Function

    ''actualiza fecha de programacion
    Public Function actualizaFechaProgramacionEncabezadoPartidas(ByVal pedidoId As Int32, ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "PedidoIDSAY"
        parametro.Value = pedidoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModificaID"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebVFE_ActualizaFechaEncabezadoPartidas", listaParametros)
    End Function
#End Region

End Class
