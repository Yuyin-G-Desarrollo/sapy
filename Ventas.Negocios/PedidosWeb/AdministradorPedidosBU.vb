Public Class AdministradorPedidosBU

    '' funcion para saber si tiene el permiso para dar de alta pedidos

    Public Function ConsultarPermisoAltaPedidos(ByVal idUsuario As Int32) As DataTable
        Dim objDA As New Datos.AdministradorPedidosDA
        Dim dtPermiso As New DataTable
        dtPermiso = objDA.ConsultarPermisoAltaPedidos(idUsuario)
        Return dtPermiso
    End Function

    ''funcion para validar que un cliente este activo o no
    Public Function validarClienteActivoInactivo(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.AdministradorPedidosDA
        Dim dtCliente As New DataTable

        dtCliente = objDa.validarClienteActivoInactivo(idPedido)
        Return dtCliente
    End Function

    ''funcion que valida que los articulos entren a la lista de precios
    Public Function validarProductosEnLP(ByVal idPedido As Int32, ByVal idListaPrecio As Int32) As DataTable
        Dim objDa As New Datos.AdministradorPedidosDA
        Dim dtDetalles As New DataTable

        dtDetalles = objDa.validarProductosEnLP(idPedido, idListaPrecio)

        Return dtDetalles
    End Function

    '' funcion que verifica si es posible o no cambiar la lista de precios
    Public Function verificarPosiblecambioLP(ByVal idPedido As Int32, ByVal idLista As Int32) As DataTable
        Dim objDa As New Datos.AdministradorPedidosDA
        Dim dtCambioLP As New DataTable

        dtCambioLP = objDa.verificarPosiblecambioLP(idPedido, idLista)

        Return dtCambioLP
    End Function

    ''funcion para obtener el titulo del pedido
    Public Function consultarTituloPedido(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.AdministradorPedidosDA
        Dim dtTitulo As New DataTable

        dtTitulo = objDa.consultarTituloPedido(idPedido)

        Return dtTitulo
    End Function

    ''funcion para recuperar el nombre del cliente sin importar activo 
    Public Function consultarNombreClienteActivo(ByVal idcliente As Int32) As DataTable
        Dim objDa As New Datos.AdministradorPedidosDA
        Dim dtCliente As New DataTable
        dtCliente = objDa.consultarNombreClienteActivo(idcliente)
        Return dtCliente
    End Function

    '' Recupera la lista de rfc del cliente (pedidos web)
    Public Function recuperarRfcClienteAtivoInactivo(ByVal idCliente As Int32) As DataTable
        Dim objDa As New Datos.AdministradorPedidosDA
        Dim dtRfc As New DataTable

        dtRfc = objDa.recuperarRfcClienteAtivoInactivo(idCliente)
        Return dtRfc
    End Function

    ''recupera los agentes asignados al pedido al momento d ela consulta
    Public Function recuperarNombreAgentesConcatenados(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.AdministradorPedidosDA
        Dim dtAgentes As New DataTable

        dtAgentes = objDa.recuperarNombreAgentesConcatenados(idPedido)
        Return dtAgentes
    End Function

    ''recupera las marcas de los agentyes que pertenecen al pedido 
    Public Function recuperarMarcasConcatenadasPedido(ByVal idAgente As String, ByVal idCliente As Int32) As DataTable
        Dim objDa As New Datos.AdministradorPedidosDA
        Dim dtMarcas As New DataTable

        dtMarcas = objDa.recuperarMarcasConcatenadasPedido(idAgente, idCliente)
        Return dtMarcas
    End Function

    ''recupera la consulta de los estatus 
    Public Function consultarEstatusActivos() As DataTable
        Dim objDa As New Datos.AdministradorPedidosDA
        Dim dtEstatus As New DataTable

        dtEstatus = objDa.consultarEstatusActivos()
        Return dtEstatus
    End Function

    ''recupera la lista de los agentes activos
    Public Function recuperarListaAgentesActivos() As DataTable
        Dim objDa As New Datos.AdministradorPedidosDA
        Dim dtAgentes As New DataTable

        dtAgentes = objDa.recuperarListaAgentesActivos()
        Return dtAgentes
    End Function

    '' funcion para actualizar la lista de precios
    Public Sub actualizarFechaProgramacionLP(ByVal idListaPrecio As Int32, ByVal idPedido As Int32, ByVal fechaProgramacion As Date, ByVal usuarioModifico As Int32)
        Dim objDa As New Datos.AdministradorPedidosDA

        objDa.actualizarFechaProgramacionLP(idListaPrecio, idPedido, fechaProgramacion, usuarioModifico)
    End Sub

    ''funcion para consultar la bitacora del pedido
    Public Function consultarBitacoraPedido(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.AdministradorPedidosDA
        Dim dtBitacora As New DataTable

        dtBitacora = objDa.consultarBitacoraPedido(idPedido)
        Return dtBitacora
    End Function

    ''funcion para consultar la lista de los clientes activo o inactivos
    Public Function consultaClientesActivosInactivos(ByVal idUsuario As Int32, ByVal activo As Int32, ByVal TipoComercializadora As String) As DataTable
        Dim objDa As New Datos.AdministradorPedidosDA
        Dim dtClientes As New DataTable
        dtClientes = objDa.consultaClientesActivosInactivos(idUsuario, activo, TipoComercializadora)
        Return dtClientes
    End Function
    ''Solo para SAPICA
    Public Function consultaClientesActivosInactivosSAPICA(ByVal idUsuario As Int32, ByVal activo As Int32) As DataTable
        Dim objDa As New Datos.AdministradorPedidosDA
        Dim dtClientes As New DataTable
        dtClientes = objDa.consultaClientesActivosInactivosSAPICA(idUsuario, activo)
        Return dtClientes
    End Function

    ''funcion para recuperar las listas de precio de un cliente (activa o inactiva)
    Public Function ConsultaListasPreciosClienteActivaInactiva(ByVal idCliente As Int32) As DataTable
        Dim objDa As New Datos.AdministradorPedidosDA
        Dim dtListas As New DataTable
        dtListas = objDa.ConsultaListasPreciosClienteActivaInactiva(idCliente)
        Return dtListas

    End Function

    ''funcion para consultar los detalles del pedido desde el adninistrador
    Public Function consultarDetallesPedidoAdministrador(ByVal idPedido As Int32, ByVal idListaPrecio As Int32, ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdministradorPedidosDA
        Dim dtDetalles As New DataTable
        dtDetalles = objDa.consultarDetallesPedidoAdministrador(idPedido, idListaPrecio, idUsuario)
        Return dtDetalles
    End Function

    ''funcion con la consulta del administrador de pedidos
    Public Function consultaAdministradorPedidos(ByVal idUsuario As Int32, ByVal filtroPedidos As String, ByVal filtroPedidosSicy As String,
                                                 ByVal filtroOrdenCliente As String, ByVal filtroAgentes As String, ByVal filtroClientes As String,
                                                 ByVal filtroEstatus As String, ByVal tipoCondicion As String, ByVal fechaCaptura As Boolean,
                                                 ByVal fechaEntrega As Boolean, ByVal FechaCapturaInicio As String, ByVal FechaCapturaFin As String,
                                                 ByVal fechaEntregaInicio As String, ByVal fechaEntregaFin As String, NaveUsuario As String) As DataTable
        Dim objDa As New Datos.AdministradorPedidosDA
        Dim dtAdministrador As New DataTable

        dtAdministrador = objDa.consultaAdministradorPedidos(idUsuario, filtroPedidos, filtroPedidosSicy, filtroOrdenCliente, filtroAgentes, filtroClientes,
                                                             filtroEstatus, tipoCondicion, fechaCaptura, fechaEntrega, FechaCapturaInicio, FechaCapturaFin,
                                                             fechaEntregaInicio, fechaEntregaFin, NaveUsuario)

        Return dtAdministrador
    End Function

    ''funcion para consultar el perfil del usuario(saber si es agente o no)
    Public Function consultarIdPerfilUsuario(ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdministradorPedidosDA
        Dim dtPerfil As New DataTable

        dtPerfil = objDa.consultarIdPerfilUsuario(idUsuario)

        Return dtPerfil
    End Function
#Region "usuario 112 permisos clientes"
    Public Function consultarIdPerfilCliente(ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdministradorPedidosDA
        Dim dtPerfil As New DataTable

        dtPerfil = objDa.consultarIdPerfilCliente(idUsuario)

        Return dtPerfil
    End Function
#End Region
#Region "REPORTE VENTAS"

    Public Function consultaClientesActivosInactivosRPTVENTAS(ByVal idUsuario As Int32, ByVal activo As Int32, ByVal TipoComercializadora As String) As DataTable
        Dim objDa As New Datos.AdministradorPedidosDA
        Dim dtClientes As New DataTable
        dtClientes = objDa.consultaClientesActivosInactivosRPTVENTAS(idUsuario, activo, TipoComercializadora)
        Return dtClientes
    End Function

    Public Function recuperarListaAgentesActivosrptventas(ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdministradorPedidosDA
        Dim dtAgentes As New DataTable

        dtAgentes = objDa.recuperarListaAgentesActivosrptventas(idUsuario)
        Return dtAgentes
    End Function
#End Region

#Region "Editar pedidos"
    Public Function obtienePedidoSaySicy(ByVal pedidoSicyid As Int32) As DataTable
        Dim dtPedidoSay As New DataTable
        Dim objDa As New Datos.AdministradorPedidosDA

        dtPedidoSay = objDa.obtienePedidoSaySicy(pedidoSicyid)

        Return dtPedidoSay
    End Function

    Public Function validaEditarPedidoUsuario(ByVal pedidoSayid As Int32, ByVal usuarioid As Int32) As DataTable
        Dim dtPermisoEditar As New DataTable
        Dim objDa As New Datos.AdministradorPedidosDA

        dtPermisoEditar = objDa.validaEditarPedidoUsuario(pedidoSayid, usuarioid)

        Return dtPermisoEditar
    End Function

    Public Function validaPedidoExistente(ByVal pedidoSayid As Int32) As DataTable
        Dim dtPedidoExistente As New DataTable
        Dim objDa As New Datos.AdministradorPedidosDA

        dtPedidoExistente = objDa.validaPedidoExistente(pedidoSayid)

        Return dtPedidoExistente
    End Function
#End Region
End Class
