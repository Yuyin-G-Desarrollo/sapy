Imports System.Data.SqlClient

Public Class AutorizacionPedidosSapicaDA
    ''consulta para saber si el cliente esta bloqueado
    Public Function consultaClienteBloqueado(ByVal idCliente As Int32, ByVal idPedido As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter()
        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_ConsultaClienteBloqueado", listaParametros)
    End Function

    ''consulta de los datos del pedido pantalla autorizacion pedidos
    Public Function consultaDatosPedidoAutorizacion(ByVal idPedido As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_Aut_ConsultaDatosPedidoAutorizacion", listaParametros)
    End Function

    ''consulta listado de clientes nuevos
    Public Function listadoClientesNuevos(ByVal idEvento As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idEvento"
        parametro.Value = idEvento
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_Aut_ListadoClientesNuevos", listaParametros)
    End Function


    ''validacion para saber si el visitante tiene cliente
    Public Function validacionClienteVisitante(ByVal idVisitante As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idVisitante"
        parametro.Value = idVisitante
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_Aut_ValidacionClientePedidos", listaParametros)
    End Function

    ''consulta listado de clientes existentes
    Public Function listadoClientesExistentes() As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = " EXEC [SAPICA].[SP_PedidosWeb_Aut_ListadoClientesExistentes]"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''Consulta de partidas por autorizar
    Public Function consultaPartidasPorAutorizar(ByVal idPedido As Int32, ByVal idCliente As Int32, ByVal idAgente As Int32,
                                                 ByVal idListaPrecios As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idAgente"
        parametro.Value = idAgente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idListaPrecios"
        parametro.Value = idListaPrecios
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_Aut_ConsultaPartidas", listaParametros)
    End Function

    ''consulta de las listas de precios del cliente
    Public Function consultaLPCliente(ByVal idCliente As Int32, ByVal idPedido As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_Aut_ConsultaLPCliente", listaParametros)
    End Function

    ''consulta para validar los articulos en la lista de precios
    Public Function validaArticulosEnLP(ByVal idPedido As Int32, ByVal idCliente As Int32, ByVal idAgente As Int32,
                                        ByVal idListaPrecios As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idAgente"
        parametro.Value = idAgente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idListaPrecios"
        parametro.Value = idListaPrecios
        listaParametros.Add(parametro)


        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_Aut_ValidaPartidasEnLP", listaParametros)
    End Function

    ''consulta de los pedidos a generar
    Public Function consultaPedidosGenerar(ByVal idPedido As Int32, ByVal idCliente As Int32, ByVal idAgente As Int32, ByVal partidas As String,
                                           ByVal idLista As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idAgente"
        parametro.Value = idAgente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidosDetalles"
        parametro.Value = partidas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idLista"
        parametro.Value = idLista
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_Aut_ConsultaPedidosAGenerar", listaParametros)
    End Function

    ''inserta el encabezado del pedido sapica a pedido normal
    Public Function insertaEncabezadoPedidoSapicaAPedido(ByVal idCliente As Int32, ByVal idAgente As Int32, ByVal idListaPrecios As Int32,
                                                         ByVal idPedido As Int32, ByVal idUsuario As Int32) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idAgente"
        parametro.Value = idAgente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idListaPrecios"
        parametro.Value = idListaPrecios
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_Aut_InsertaEncabezadoSapicaAPedido", listaParametros)
    End Function

    ''inserta detalles del pedido sapica a pedido normal
    Public Function insertaDetallePedidoSapicaAPedido(ByVal PedidoIdSAY As String, ByVal pedidoIdSapica As Int32, ByVal idPartidaSapica As Int32,
                                                       ByVal Idusuario As Int32) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "PedidoIdSAY"
        parametro.Value = PedidoIdSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidoIdSapica"
        parametro.Value = pedidoIdSapica
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPartidaSapica"
        parametro.Value = idPartidaSapica
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Idusuario"
        parametro.Value = Idusuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_Aut_InsertaDetallesSapicaAPedido", listaParametros)
    End Function

    ''inserta detalles talla del pedido sapica a pedido normal
    Public Function insertaDetalleTallasSapicaAPedido(ByVal PedidoDetalleId As Int32, ByVal idPedidoSapica As Int32, ByVal idPartidaSapica As Int32,
                                                      ByVal ClienteId As Int32, ByVal idUsuario As Int32) As DataTable


        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "PedidoDetalleId"
        parametro.Value = PedidoDetalleId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPedidoSapica"
        parametro.Value = idPedidoSapica
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPartidaSapica"
        parametro.Value = idPartidaSapica
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClienteId"
        parametro.Value = ClienteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_Aut_InsertaDetallesTallasSapicaAPedido", listaParametros)
    End Function

    ''consulta permiso boton autorizar
    Public Function permisoBotonAutorizar(ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Sapica.SP_PedidosWeb_Aut_PermisoBotonAutorizacion", listaParametros)
    End Function
End Class
