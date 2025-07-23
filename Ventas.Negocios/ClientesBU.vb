Imports Ventas.Datos
Public Class ClientesBU

    Public Function buscarClientesNombreComercial(ByVal ClienteID As Integer) As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.buscarClientesNombreComercial(ClienteID)
    End Function

    Public Function buscarClientesNombreComercialXEstatus(ByVal activo As Boolean) As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.buscarClientesNombreComercialXEstatus(activo)
    End Function

    Public Function buscarUltimoCliente() As Integer
        Dim objDA As New Datos.ClientesDA
        Dim tabla As New DataTable
        tabla = objDA.buscarUltimoCliente()
        Return CInt(tabla.Rows(0).Item(0))
    End Function

    Public Function buscarUltimoCliente_mas1() As Integer
        Dim objDA As New Datos.ClientesDA
        Dim tabla As New DataTable
        tabla = objDA.buscarUltimoCliente_mas1()
        Return CInt(tabla.Rows(0).Item(0))
    End Function

    Public Function ListaVendedor() As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.ListaVendedor()
    End Function

    Public Function ListaAtnClientes() As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.ListaAtnClientes()
    End Function

    Public Function buscarNombreCobradorSegunCliente(ByVal clienteID As Integer) As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.buscarNombreCobradorSegunCliente(clienteID)
    End Function

    Public Function AsignarClasificacionRanking(clasificacion As String) As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.AsignarClasificacionRanking(clasificacion)
    End Function

    Public Function ListaClasificacionCliente() As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.ListaClasificacionCliente()
    End Function

    Public Function Datos_TablaReordenamientoRanking(clasificacion As String, cliente As String) As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.Datos_TablaReordenamientoRanking(clasificacion, cliente)
    End Function

    Public Sub AltaCliente(ByVal cliente As Entidades.Cliente, ByVal ListaPeciosVentaId As Integer)
        Dim guardarClienteDA As New Datos.ClientesDA
        guardarClienteDA.AltaCliente(cliente, ListaPeciosVentaId)
    End Sub

    Public Sub editarCliente(ByVal cliente As Entidades.Cliente, tipoPersona As Entidades.TipoPersona, ByVal bandera As Integer, ByVal PedidoVirtual As Boolean, ByVal PedidoEscaneado As Boolean)
        Dim editarClienteDA As New Datos.ClientesDA
        editarClienteDA.editarCliente(cliente, tipoPersona, bandera, PedidoVirtual, PedidoEscaneado)
    End Sub

    Public Sub editarCliente_Ranking_Sicy(ByVal cliente As Entidades.Cliente, bandera As Integer)
        Dim editarClienteDA As New Datos.ClientesDA
        editarClienteDA.editarCliente_Ranking_Sicy(cliente, bandera)
    End Sub

    Public Function buscarColaboradorValidador(usuarioID As Integer, tipoValidacion As Integer) As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.buscarColaboradorValidador(usuarioID, tipoValidacion)
    End Function

    Public Sub AltaValidacionCliente(validacion As Entidades.Validacion, NuevoClasificacionPersonaID As Integer)
        Dim objDA As New Datos.ClientesDA
        objDA.AltaValidacionCliente(validacion, NuevoClasificacionPersonaID)
    End Sub

    Public Function Datos_TablaCliente(ByVal clienteID As Integer) As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.Datos_TablaCliente(clienteID)
    End Function

    Public Function ListaCliente_Todos(texto As String, load As Boolean, leerTodos As Boolean, usuarioID As Integer, cedis As Integer) As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.ListaCliente_Todos(texto, load, leerTodos, usuarioID, cedis)
    End Function

    Public Function ListaCliente_Cliente(texto As String, leerAsignados As Boolean, usuarioID As Integer, cedis As Integer) As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.ListaCliente_Cliente(texto, leerAsignados, usuarioID, cedis)
    End Function

    Public Function ListaCliente_RFC(texto As String, leerAsignados As Boolean, usuarioID As Integer, cedis As Integer) As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.ListaCliente_RFC(texto, leerAsignados, usuarioID, cedis)
    End Function

    Public Function ListaCliente_TEC(texto As String, leerAsignados As Boolean, usuarioID As Integer, cedis As Integer) As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.ListaCliente_TEC(texto, leerAsignados, usuarioID, cedis)
    End Function

    Public Function ListaCliente_Contacto(texto As String, leerAsignados As Boolean, usuarioID As Integer, cedis As Integer) As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.ListaCliente_Contacto(texto, leerAsignados, usuarioID, cedis)
    End Function

    Public Function ListaCliente_ActualizacionMasiva() As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.ListaCliente_ActualizacionMasiva()
    End Function

    Public Sub Asignacion_Masiva_Atn_Clientes(clienteid As Integer, colaboradorid As Integer)
        Dim objDA As New Datos.ClientesDA
        objDA.Asignacion_Masiva_Atn_Clientes(clienteid, colaboradorid)
    End Sub

    Public Sub Asignacion_Masiva_Atn_Clientes_SICY(clientesicy_id As Integer, colaboradorid As Integer)
        Dim objDA As New Datos.ClientesDA
        objDA.Asignacion_Masiva_Atn_Clientes_SICY(clientesicy_id, colaboradorid)
    End Sub

    Public Sub Asignacion_Masiva_Agente_Ventas(clienteid As Integer, colaboradorid As Integer)
        Dim objDA As New Datos.ClientesDA
        objDA.Asignacion_Masiva_Agente_Ventas(clienteid, colaboradorid)
    End Sub

    Public Sub Asignacion_Masiva_Agente_Ventas_SICY(clientesicy_id As Integer, colaboradorid As Integer)
        Dim objDA As New Datos.ClientesDA
        objDA.Asignacion_Masiva_Agente_Ventas_SICY(clientesicy_id, colaboradorid)
    End Sub

    Public Sub Modificacion_Status_Cliente_SICY(clienteid_sicy As Integer, status_cliente As String)
        Dim objDA As New Datos.ClientesDA
        objDA.Modificacion_Status_Cliente_SICY(clienteid_sicy, status_cliente)
    End Sub

    Public Function ListaMarca() As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.ListaMarca()
    End Function

    Public Function ListaEmpresa() As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.ListaEmpresa()
    End Function


    Public Function ListadoParametroUbicacion(tipo_busqueda As Integer, id_parametros As String) As DataTable
        Dim objbu As New Datos.ClientesDA
        Dim tabla As New DataTable
        tabla = objbu.ListadoParametroUbicacion(tipo_busqueda, id_parametros)
        Return tabla
    End Function

    ''' <summary>
    ''' conecta con la capa de datos para recuperar las listas de precio asignadas a un cliente
    ''' </summary>
    ''' <param name="ClienteID">id del cliente</param>
    ''' <returns>datatable con la información recuperada</returns>
    ''' <remarks></remarks>
    Public Function buscarListasDePreciosDeCliente(ByVal ClienteID As Integer, ByVal NoAsignadas As Boolean, ByVal LVAsignada As Boolean) As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.buscarListasDePreciosDeCliente(ClienteID, NoAsignadas, LVAsignada)
    End Function

    Public Function recuperar_Informacion_Cliente_Para_LP(ByVal IdCliente As Integer) As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.recuperar_Informacion_Cliente_Para_LP(IdCliente)
    End Function

    Public Function verModelosGenerales(ByVal idCliente As Int32) As Boolean
        Dim objDA As New Datos.ClientesDA
        Return objDA.verModelosGenerales(idCliente)
    End Function

    Public Function ValidarListaDePrecios_Aceptada_o_capturada_asignadas(ByVal idCliente As Int32) As Boolean
        Dim objDA As New Datos.ClientesDA
        Dim dtListas As New DataTable

        dtListas = objDA.ValidarListaDePrecios_Aceptada_o_capturada_asignadas(idCliente)

        If dtListas.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function RecuperarInformacion_ListaVEntasClienteCapturada(ByVal IdCLiente As Integer) As DataTable
        Dim objDA As New Datos.ClientesDA
        RecuperarInformacion_ListaVEntasClienteCapturada = objDA.RecuperarInformacion_ListaVEntasClienteCapturada(IdCLiente)
        Return RecuperarInformacion_ListaVEntasClienteCapturada
    End Function

    ''' <summary>
    ''' recupera la lista de los clientes dependiendo del tipo de usuario logeado
    ''' </summary>
    ''' <param name="idUsuario"></param>
    ''' <returns>datatable con la lista de los clientes</returns>
    ''' <remarks></remarks>
    Public Function recuperarListaClientesUsuarioPedidosWeb(ByVal idUsuario As Int32, ByVal TipoComercializadora As String) As DataTable
        Dim objDa As New Datos.ClientesDA
        Dim dtListaClientes As New DataTable
        dtListaClientes = objDa.recuperarListaClientesUsuarioPedidosWeb(idUsuario, TipoComercializadora)
        Return dtListaClientes
    End Function

    '' Recupera la lista de rfc del cliente (pedidos web)
    Public Function recuperarListaRfcClientes(ByVal idCliente As Int32, ByVal PedidoId As Int32) As DataTable
        Dim objDA As New Datos.ClientesDA
        Dim dtListaRfc As New DataTable
        dtListaRfc = objDA.recuperarListaRfcClientes(idCliente, PedidoId)
        Return dtListaRfc
    End Function

    'Recupera la información general del cliente pedidos web
    Public Function cargarInformacionCliente(ByVal idCliente As Int32) As DataTable
        Dim objDA As New Datos.ClientesDA

        cargarInformacionCliente = objDA.cargarInformacionCliente(idCliente)

        Return cargarInformacionCliente
    End Function

    ''Recupera los agentes asignados a cada cliente as
    Public Function recuperarAgentesCliente(ByVal idCliente As Int32, ByVal idUsuario As Int32) As DataTable
        Dim objDA As New Datos.ClientesDA
        Dim dtAgentes As New DataTable
        dtAgentes = objDA.recuperarAgentesCliente(idCliente, idUsuario)
        Return dtAgentes
    End Function

    'Recupera las marcas que vende cada agente para cada cliente (pedidos web)
    Public Function recuperarMarcasAgenteCliente(ByVal idCliente As Int32, ByVal idAgente As String) As DataTable
        Dim objDa As New Datos.ClientesDA
        Dim dtMarcas As New DataTable
        dtMarcas = objDa.recuperarMarcasAgenteCliente(idCliente, idAgente)
        Return dtMarcas
    End Function

    'Recupera los ramos de un cliente (pedidos web)
    Public Function recuperarListaRamosCliente(ByVal idCliente As Int32) As DataTable
        Dim objDa As New Datos.ClientesDA
        Dim dtRamos As New DataTable
        dtRamos = objDa.recuperarListaRamosCliente(idCliente)
        Return dtRamos
    End Function

    ''Recupera la vigencia de la lista de precios del cliente
    Public Function RecuperarFechaVigencia_ListaPrecioCliente(ByVal idCliente As Integer, ByVal fecha As Date)
        Dim objDa As New Datos.ClientesDA
        Dim dtVigencia As New DataTable
        dtVigencia = objDa.RecuperarFechaVigencia_ListaPrecioCliente(idCliente, fecha)
        Return dtVigencia
    End Function

    'Valida si existe una orden del cliente con ese numero
    Public Function recuperarOrdenClientePedido(ByVal idCliente As Int32, ByVal orden As String) As DataTable
        Dim objDa As New Datos.ClientesDA
        Dim dtOrdenCliente As New DataTable
        dtOrdenCliente = objDa.recuperarOrdenClientePedido(idCliente, orden)
        Return dtOrdenCliente
    End Function

    'recupera la lista de clientes por usuario y filtro
    Public Function recuperarListaClientesUsuarioFiltroPedidosWeb(ByVal idUsuario As Int32, ByVal caracter As String) As DataTable
        Dim objDa As New Datos.ClientesDA
        Dim dtListaClientes As New DataTable
        dtListaClientes = objDa.recuperarListaClientesUsuarioFiltroPedidosWeb(idUsuario, caracter)
        Return dtListaClientes
    End Function

    ''recupera los contactos de correo de pedido por agente
    Public Function recuperarContactosPedidoAgente(ByVal idCliente As Int32, ByVal marcasId As String) As DataTable
        Dim objDa As New Datos.ClientesDA
        Dim dtContactosCorreo As New DataTable
        dtContactosCorreo = objDa.recuperarContactosPedidoAgente(idCliente, marcasId)
        Return dtContactosCorreo
    End Function

    ''recupera la consulta de familias asignadas al agente 
    Public Function recuperarFamiliaVentasAsignada(ByVal idCliente As Int32, ByVal idAgente As String) As DataTable
        Dim objDa As New Datos.ClientesDA
        Dim dtFamilias As New DataTable

        dtFamilias = objDa.recuperarFamiliaVentasAsignada(idCliente, idAgente)

        Return dtFamilias
    End Function


    Public Sub actualizarClientesSICY()
        Dim objDa As New Datos.ClientesDA
        objDa.actualizarClientesSICY()
    End Sub

    ''recupera la consulta del cliente para saber si esta bloqueado
    Public Function recuperarInformacionBloqueoCliente(ByVal idCliente As Int32) As DataTable
        Dim dtbloqueo As New DataTable
        Dim objDa As New Datos.ClientesDA

        dtbloqueo = objDa.recuperarInformacionBloqueoCliente(idCliente)

        Return dtbloqueo
    End Function

#Region "uso de cfdi"
    Public Function obtenerTipoPersonaCliente(ByVal clienteid As Int32) As DataTable
        Dim dtTipopersona As New DataTable
        Dim objDa As New ClientesDA

        dtTipopersona = objDa.obtenerTipoPersonaCliente(clienteid)

        Return dtTipopersona
    End Function
#End Region


    Public Function buscarClientesNombreComercial(ByVal Activo As Boolean, ByVal clienteID As Integer, ByVal UsuarioId As Integer) As DataTable
        Dim objDA As New Datos.ClientesDA
        Return objDA.buscarClientesNombreComercial(Activo, clienteID, UsuarioId)
    End Function

    Public Function EditarMarcaAgenteVentasBloqueo(ByVal id As Integer, ByVal cambio As Boolean)
        Dim objDA As New Datos.ClientesDA
        Return objDA.EditarMarcaAgenteVentasBloqueo(id, cambio)
    End Function

End Class
