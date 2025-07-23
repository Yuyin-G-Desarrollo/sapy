Imports System.Data.SqlClient

Public Class AdministradorPedidosDA
    '' funcion para saber si tiene el permiso para dar de alta pedidos

    Public Function ConsultarPermisoAltaPedidos(ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_PermisosBoton_AltaPedidos", listaParametros)
    End Function

    ''funcion para validar que un cliente este activo o no
    Public Function validarClienteActivoInactivo(ByVal idPedido As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ValidarCliente_Activo", listaParametros)
    End Function

    ''funcion que valida que los articulos entren a la lista de precios
    Public Function validarProductosEnLP(ByVal idPedido As Int32, ByVal idListaPrecio As Int32) As DataTable
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

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ValidarArticulosEnLp", listaParametros)
    End Function

    '' funcion que verifica si es posible o no cambiar la lista de precios
    Public Function verificarPosiblecambioLP(ByVal idPedido As Int32, ByVal idLista As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idListaPrecio"
        parametro.Value = idLista
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ValidarPosibleCambioLp", listaParametros)
    End Function

    ''funcion para obtener el titulo del pedido
    Public Function consultarTituloPedido(ByVal idPedido As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConsultaTituloPedido", listaParametros)
    End Function

    ''funcion para recuperar el nombre del cliente sin importar activo 
    Public Function consultarNombreClienteActivo(ByVal idcliente As Int32) As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        consulta = <consulta>
                     SELECT clie_clienteid, clie_nombregenerico FROM Cliente.Cliente WHERE clie_clienteid=<%= idcliente.ToString %>
                   </consulta>.Value
        Return persistencia.EjecutaConsulta(consulta)
    End Function

    '' Recupera la lista de rfc del cliente (pedidos web)
    Public Function recuperarRfcClienteAtivoInactivo(ByVal idCliente As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = <consulta> SELECT crfc_clienterfcid, 
                    CASE WHEN crfc_clasificacionpersonaid = 14 THEN 'F -' 
                    ELSE CASE WHEN crfc_clasificacionpersonaid = 13 THEN 'R - ' ELSE '? -' END 
                    END + UPPER(pers_nombre) +' ('+crfc_RFC+')' AS 'Persona',pers_nombre,crfc_clasificacionpersonaid FROM Cliente.ClienteRFC 
                    JOIN Framework.Persona ON crfc_personaid = pers_personaid where crfc_clienteid = <%= idCliente.ToString %>
                      ORDER BY pers_nombre
                   </consulta>.Value
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''recupera los agentes asignados al pedido al momento d ela consulta
    Public Function recuperarNombreAgentesConcatenados(ByVal idPedido As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Consulta_NombreAgentes", listaParametros)
    End Function

    ''recupera las marcas de los agentyes que pertenecen al pedido 
    Public Function recuperarMarcasConcatenadasPedido(ByVal idAgente As String, ByVal idCliente As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idAgente"
        parametro.Value = idAgente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Consulta_MarcasAsignadasPedidos", listaParametros)
    End Function

    ''recupera la consulta de los estatus 
    Public Function consultarEstatusActivos() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = <consulta>
                       	SELECT esta_estatusid, esta_nombre FROM Framework.Estatus WHERE esta_tipostatus='PEDIDO' AND esta_activo=1 ORDER BY esta_nombre
                   </consulta>.Value
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''recupera la lista de los agentes activos
    Public Function recuperarListaAgentesActivos() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = <consulta>
                        EXEC  [Ventas].[SP_PedidosWeb_Consulta_AgentesActivos]
                   </consulta>.Value

        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    '' funcion para actualizar la lista de precios
    Public Sub actualizarFechaProgramacionLP(ByVal idListaPrecio As Int32, ByVal idPedido As Int32, ByVal fechaProgramacion As Date, ByVal usuarioModifico As Int32)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idListaPrecio"
        parametro.Value = idListaPrecio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaProgramacion"
        parametro.Value = fechaProgramacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioModifico"
        parametro.Value = usuarioModifico
        listaParametros.Add(parametro)

        objPersistencia.EjecutarSentenciaSP("Ventas.SP_PedidosWeb_ActualizarFechaProgramacionLP", listaParametros)
    End Sub

    ''funcion para consultar la bitacora del pedido
    Public Function consultarBitacoraPedido(ByVal idPedido As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Consulta_BitacoraPedido", listaParametros)
    End Function

    ''funcion para consultar la lista de los clientes activo o inactivos
    Public Function consultaClientesActivosInactivos(ByVal idUsuario As Int32, ByVal activo As Int32, ByVal TipoComercializadora As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoComercializadora"
        parametro.Value = TipoComercializadora
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConsultaCLientes_ActivosInactivos_28/10/2020", listaParametros)
    End Function
    ''Solo para SAPICA
    Public Function consultaClientesActivosInactivosSAPICA(ByVal idUsuario As Int32, ByVal activo As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = activo
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConsultaCLientes_ActivosInactivos", listaParametros)
    End Function


    ''funcion para recuperar las listas de precio de un cliente (activa o inactiva)
    Public Function ConsultaListasPreciosClienteActivaInactiva(ByVal idCliente As Int32) As DataTable
        Dim consulta As String = String.Empty
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        consulta = <consulta>
                     SELECT idListaVentas, idListaVentasClientePrecio, idListaBase, ListaBase, ListaPrecioCliente, 'Vigente del '+convert(varchar(10), InicioVigencia , 103)+' al ' +convert(varchar(10), FinVigencia , 103) as vigencia
                        ,convert(varchar(10), InicioVigencia , 103) inicioVigencia, convert(varchar(10), FinVigencia , 103) finVigencia 
						 FROM Ventas.vListaPrecioCliente_Todas WHERE IdSAY= <%= idCliente.ToString %> ORDER BY ListaBase
                   </consulta>.Value
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''funcion para consultar los detalles del pedido desde el adninistrador
    Public Function consultarDetallesPedidoAdministrador(ByVal idPedido As Int32, ByVal idListaPrecio As Int32, ByVal idUsuario As Int32) As DataTable
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
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Consulta_DetallesPedidoAdministrador", listaParametros)
    End Function

    ''funcion con la consulta del administrador de pedidos
    Public Function consultaAdministradorPedidos(ByVal idUsuario As Int32, ByVal filtroPedidos As String, ByVal filtroPedidosSicy As String,
                                                 ByVal filtroOrdenCliente As String, ByVal filtroAgentes As String, ByVal filtroClientes As String,
                                                 ByVal filtroEstatus As String, ByVal tipoCondicion As String, ByVal fechaCaptura As Boolean,
                                                 ByVal fechaEntrega As Boolean, ByVal FechaCapturaInicio As String, ByVal FechaCapturaFin As String,
                                                 ByVal fechaEntregaInicio As String, ByVal fechaEntregaFin As String, NaveUsuario As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "filtroPedidos"
        parametro.Value = filtroPedidos
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "filtroPedidosSicy"
        parametro.Value = filtroPedidosSicy
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "filtroOrdenCliente"
        parametro.Value = filtroOrdenCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "filtroAgentes"
        parametro.Value = filtroAgentes
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "filtroClientes"
        parametro.Value = filtroClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "filtroEstatus"
        parametro.Value = filtroEstatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "tipoCondicion"
        parametro.Value = tipoCondicion
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "fechaCaptura"
        parametro.Value = fechaCaptura
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "fechaEntrega"
        parametro.Value = fechaEntrega
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "FechaCapturaInicio"
        parametro.Value = FechaCapturaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "FechaCapturaFin"
        parametro.Value = FechaCapturaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "fechaEntregaInicio"
        parametro.Value = fechaEntregaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "fechaEntregaFin"
        parametro.Value = fechaEntregaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter()
        parametro.ParameterName = "NavePerteneceusuario"
        parametro.Value = NaveUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConsultaAdministradorPedidos_22102020_2", listaParametros)
    End Function

    ''funcion para consultar el perfil del usuario(saber si es agente o no)
    Public Function consultarIdPerfilUsuario(ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Consulta_PerfilUsuario", listaParametros)
    End Function
#Region "usuario 112 permisos clientes"
    ''funcion para consultar el perfil del usuario(saber si es agente o no)
    Public Function consultarIdPerfilCliente(ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Consulta_PerfilCliente", listaParametros)
    End Function
#End Region
#Region "REPORTE VENTAS"
    Public Function consultaClientesActivosInactivosRPTVENTAS(ByVal idUsuario As Int32, ByVal activo As Int32, ByVal TipoComercializadora As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoComercializadora"
        parametro.Value = TipoComercializadora
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_EstadVtas_ConsultaCLientes_ActivosInactivos_29/10/2020", listaParametros)
    End Function

    Public Function recuperarListaAgentesActivosrptventas(ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_EstadVta_Consulta_AgentesActivos", listaParametros)
    End Function

#End Region

#Region "Editar pedido "
    Public Function obtienePedidoSaySicy(ByVal pedidoSicyid As Int32) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter

        parametros.ParameterName = "pedidoSicyid"
        parametros.Value = pedidoSicyid
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebImp_ObtienePedidoSaySicy", listaParametros)
    End Function

    Public Function validaEditarPedidoUsuario(ByVal pedidoSayid As Int32, ByVal usuarioid As Int32) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter

        parametros.ParameterName = "usuarioid"
        parametros.Value = usuarioid
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "pedidoSayid"
        parametros.Value = pedidoSayid
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebImp_ValidaEditarPedidoUsuario", listaParametros)
    End Function

    Public Function validaPedidoExistente(ByVal pedidoSayid As Int32) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter

        parametros.ParameterName = "pedidoSayid"
        parametros.Value = pedidoSayid
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebImp_ValidaPedidoExistente", listaParametros)
    End Function
#End Region
End Class
