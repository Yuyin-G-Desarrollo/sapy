Imports System.Data.SqlClient

Public Class AdministradorCotizacionesDA
    ''consulta de los documentos de las cotizacionew (administrador cotizaciones)
    Public Function consultaDocumentosAdmonCotizaciones(ByVal idCotizacion As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "IdCotizacion"
        parametro.Value = idCotizacion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_ConsultaDocumentosCotizacion", listaParametros)
    End Function

    ''consulta pagos (administrador cotizaciones)
    Public Function consultaPagosAdmonCotizaciones(ByVal idCotizacion As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "IdCotizacion"
        parametro.Value = idCotizacion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_ConsultaPagosCotizacion", listaParametros)
    End Function

    ''consulta de los datos de la cotizacion seleccionada
    Public Function consultaDatosCotizacionSeleccionada(ByVal idCotizacion As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "IdCotizacion"
        parametro.Value = idCotizacion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_DatosCotizacionSeleccionada", listaParametros)
    End Function

    ''consulta para permisos del boton de pagos de pedidos
    Public Function consultaPermisoBotonPagoTotal(ByVal idCotizacion As Int32, ByVal idUsuario As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idCotizacion"
        parametro.Value = idCotizacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_PermisosBotonPagos", listaParametros)
    End Function

    'consulta del cliente (pantalla registrar pagos)
    Public Function consultaClienteRegistroPago(ByVal idCotizacion As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idCotizacion"
        parametro.Value = idCotizacion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_ConsultaClienteRegistroPago", listaParametros)
    End Function

    ''consulta cuentas bancarias registro pagos
    Public Function consultaCuentasBancariasRegistroPagos(ByVal idCotizacion As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idCotizacion"
        parametro.Value = idCotizacion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_ConsultaCuentasRegistroPagos", listaParametros)
    End Function

    ''consulta tipos de pago (pantalla registrar pagos)
    Public Function consultaTiposPagoRegistroPagos() As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = " EXEC Ventas.SP_PedidosWeb_CotAdmon_ConsultaTipoPagoRegistroPagos"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta de detalles de la cotizacion registro pagos
    Public Function consultaTotalesCotizacionRegistroPagos(ByVal idCotizacion As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idCotizacion"
        parametro.Value = idCotizacion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_ConsultaTotalesRegistroPago", listaParametros)
    End Function

    ''consulta administrador de cotizaciones vista almacen
    Public Function consultaAdministradorCotizacionesAlmacen(ByVal clientes As String, ByVal estatus As String, ByVal pedidosSAY As String,
                                                              ByVal pedidosSICY As String, ByVal ordenesCliente As String, ByVal cotizaciones As String,
                                                              ByVal idUsuario As Int32, ByVal porFechaCaptura As Int32, ByVal fechaInicio As String,
                                                              ByVal fechafin As String, ByVal tipoConsulta As String, NaveUsuario As String) As DataTable

        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "clientes"
        parametro.Value = clientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatus"
        parametro.Value = estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidosSAY"
        parametro.Value = pedidosSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidosSICY"
        parametro.Value = pedidosSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ordenesCliente"
        parametro.Value = ordenesCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cotizaciones"
        parametro.Value = cotizaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "porFechaCaptura"
        parametro.Value = porFechaCaptura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechafin"
        parametro.Value = fechafin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoConsulta"
        parametro.Value = tipoConsulta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoComercializadora"
        parametro.Value = NaveUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_ConsultaAlmacen_26102020", listaParametros)
    End Function

    ''consulta administrador de cotizaciones vista general
    Public Function consultaAdministradorCotizacionesGeneral(ByVal clientes As String, ByVal estatus As String, ByVal pedidosSAY As String,
                                                              ByVal pedidosSICY As String, ByVal ordenesCliente As String, ByVal cotizaciones As String,
                                                              ByVal idUsuario As Int32, ByVal porFechaCaptura As Int32, ByVal fechaInicio As String,
                                                              ByVal fechafin As String, ByVal tipoConsulta As String, NaveUsuario As String) As DataTable

        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "clientes"
        parametro.Value = clientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatus"
        parametro.Value = estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidosSAY"
        parametro.Value = pedidosSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidosSICY"
        parametro.Value = pedidosSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ordenesCliente"
        parametro.Value = ordenesCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cotizaciones"
        parametro.Value = cotizaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "porFechaCaptura"
        parametro.Value = porFechaCaptura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechafin"
        parametro.Value = fechafin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoConsulta"
        parametro.Value = tipoConsulta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoComercializadora"
        parametro.Value = NaveUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_ConsultaGeneral_26102020", listaParametros)
    End Function

    ''consulta para validar la vista que se va a mostrar del administrador  
    Public Function consultaValidarVistaAdministrador(ByVal idUsuario As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_ValidaVistaAdministrador", listaParametros)
    End Function

    ''inserta pago cotizacion
    Public Function insertaEncabezadoPagosCotizacion(ByVal clienteId As Int32, ByVal cuentabancariaId As Int32, ByVal metodoPagoId As Int32,
                                                     ByVal montoPago As Double, ByVal fechaPago As Date, ByVal rutaArchivo As String,
                                                     ByVal pagoValidado As Boolean, ByVal usuarioCreo As Int32) As DataTable

        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "clienteId"
        parametro.Value = clienteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cuentabancariaId"
        parametro.Value = cuentabancariaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "metodoPagoId"
        parametro.Value = metodoPagoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "montoPago"
        parametro.Value = montoPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaPago"
        parametro.Value = fechaPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "rutaArchivo"
        parametro.Value = rutaArchivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagoValidado"
        parametro.Value = pagoValidado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioCreo"
        parametro.Value = usuarioCreo
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_InsertaCotizacionPago", listaParametros)

    End Function

    ''inserta el pago por cotizaciom
    Public Function insertaPagoPorCotizacion(ByVal idPago As Int32, ByVal idCotizacion As Int32, ByVal montoAplicado As Double,
                                             ByVal idUsuario As Int32) As DataTable

        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idPago"
        parametro.Value = idPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCotizacion"
        parametro.Value = idCotizacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "montoAplicado"
        parametro.Value = montoAplicado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_InsertaPagoPorCotizacion", listaParametros)
    End Function

    ''consulta detalles para cancelacion
    Public Function consultaDetallesParaCancelacion(ByVal idCotizacion As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idCotizacion"
        parametro.Value = idCotizacion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConsultaDetallesParaCancelacion", listaParametros)
    End Function

    ''consulta permisos boton cancelar
    Public Function consultaPermisoBotonCancelar(ByVal idCotizacion As Int32, ByVal idUsuario As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idCotizacion"
        parametro.Value = idCotizacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_PermisosBotonCancelar", listaParametros)
    End Function

    ''consulta para cancelar una cotizacion
    Public Function cancelarCotizacion(ByVal idCotizacion As Int32, ByVal motivoCancelacion As String, ByVal idUsuario As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idCotizacion"
        parametro.Value = idCotizacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "motivoCancelacion"
        parametro.Value = motivoCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_CancelarCotizacion", listaParametros)
    End Function

    ''consulta listado de estatus de cotizaciones
    Public Function listadoEstatusCotizaciones() As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = "EXEC Ventas.SP_PedidosWeb_CotAdmon_ListadoEstatusCotizacion"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta monto pendiente total de la cotizacion
    Public Function consultaMontoPendienteCotizacion(ByVal idCotizacion As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idCotizacion"
        parametro.Value = idCotizacion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_ConsultaMontoPendiente", listaParametros)
    End Function

    ''consulta para validar las facturas
    Public Function validacionFacturas(ByVal detallesDocumentos As String, ByVal idUsuario As Int32, ByVal tipoFacturacion As Boolean) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "detallesDocumentos"
        parametro.Value = detallesDocumentos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoFacturacion"
        parametro.Value = tipoFacturacion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_ValidacionFacturacion", listaParametros)
    End Function

    ''consulta para validar los pagos (unicamente cobranza)
    Public Function permisosBotonValidarPagos(ByVal idUsuario As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "IdUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_PermisosBotonValidarPagos", listaParametros)
    End Function

    '' consulta con los permisos administrador de pagos
    Public Function permisosAdministradorPagos(ByVal idUsuario As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "IdUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_PermisosAdministradorPagos", listaParametros)
    End Function

    ''consulta listado cuentas bancarias
    Public Function listadoCuentasBancarias() As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = " EXEC Ventas.SP_PedidosWeb_CotAdmon_ListadoCuentasBancarias"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta de los detalles del pago
    Public Function consultaDetallesPago(ByVal pagoId As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "pagoId"
        parametro.Value = pagoId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_ConsultaDetallesPago", listaParametros)
    End Function

    ''cosnulta detalles del pago seleccionado
    Public Function consultaPagoSeleccionado(ByVal pagoId As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "pagoId"
        parametro.Value = pagoId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_DatosPagoSeleccionado", listaParametros)
    End Function

    ''actualiza la ruta del archivo
    Public Sub actualizaRutaArchivoPago(ByVal pagoId As Int32, ByVal ruta As String)
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "pagoId"
        parametro.Value = pagoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "rutaArchivo"
        parametro.Value = ruta
        listaParametros.Add(parametro)

        persistencia.EjecutarSentenciaSP("Ventas.SP_PedidosWeb_CotAdmon_ActualizaRutaPago", listaParametros)
    End Sub

    ''consulta de las cuentas bancarias por cliente
    Public Function consultaCuentasBancariasPorCliente(ByVal idCliente As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_CuentasBancariasPorCliente", listaParametros)
    End Function

    ''consulta de la empresa por cliente 
    Public Function consultaEmpresaPorCliente(ByVal idCliente As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_ConsultaEmpresaPorCliente", listaParametros)
    End Function

    ''consulta de cotizaciones por cliente
    Public Function consultaCotizacionesPorCliente(ByVal idCliente As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_ConsultaCotizacionesPorCliente", listaParametros)
    End Function

    ''consulta para validar pantalla de registro de pagos 
    Public Function validaPerfilRegistoPagosVariasCotizaciones(ByVal idUsuario As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "IdUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_ValidaPantallaRegistroPagos", listaParametros)
    End Function


    ''consulta tipo de pagos para el area de cobranza
    Public Function consultaTipoPagoCobranzaRegistroPago() As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = " EXEC Ventas.SP_PedidosWeb_CotAdmon_ConsultaTipoPagoCobranzaRegistroPagos"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''validacion de pagos cobranza
    Public Function validacionPagosCobranza(ByVal pagoId As Int32, ByVal pagoValidado As Boolean, ByVal idUsuario As Int32, ByVal cuentaNoFiscal As Integer, ByVal folioFiscalAnticipo As String) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "pagoId"
        parametro.Value = pagoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagoValidado"
        parametro.Value = pagoValidado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cuentaNoFiscal"
        parametro.Value = cuentaNoFiscal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "folioFiscalAnticipo"
        parametro.Value = folioFiscalAnticipo
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_ValidarPagoCobranza", listaParametros)
    End Function

    ''consulta para obtener permiso en boton editar pagos
    Public Function permisoBotonEditarPagos(ByVal idPago As Int32, ByVal idUsuario As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "pagoId"
        parametro.Value = idPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_PermisosBotonEditarPagos", listaParametros)
    End Function

    ''consulta de datos del encabezado del pago al editarlo
    Public Function consultaDatosPagoEditarPago(ByVal pagoId As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "pagoId"
        parametro.Value = pagoId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_ConsultaDatosPagoEdicion", listaParametros)
    End Function

    ''consulta listado cotizaciones de un pago (pantalla editar pago)
    Public Function consultaCotizacionesEdicionPagos(ByVal clienteId As Int32, ByVal pagoId As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "pagoId"
        parametro.Value = pagoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clienteId"
        parametro.Value = clienteId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_ConsultaCotizacionesEditarPago", listaParametros)
    End Function

    ''Editar cotizaciones en pago
    Public Function editarCotizacionesPago(ByVal pagoCotizacionId As Int32, ByVal pagoId As Int32, ByVal idCotizacion As Int32,
                                            ByVal montoAplicado As Double, ByVal idUsuario As Int32, ByVal tipoModificacion As Boolean) As DataTable

        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "pagoCotizacionId"
        parametro.Value = pagoCotizacionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagoId"
        parametro.Value = pagoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCotizacion"
        parametro.Value = idCotizacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "montoAplicado"
        parametro.Value = montoAplicado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoModificacion"
        parametro.Value = tipoModificacion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_EditarCotizaciones", listaParametros)
    End Function

    ''consulta permisos administrador de cotizaciones
    Public Function permisosAdministradorCotizaciones(ByVal idUsuario As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "IdUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_PermisosAdministradorCotizaciones", listaParametros)
    End Function

    ''consulta administrador de pagos
    Public Function consultaAdministradorPagos(ByVal clientes As String, ByVal cuentas As String, ByVal porFechaPago As Int32,
                                               ByVal fechaPagoInicio As String, ByVal fechaPagoFin As String, ByVal porFechaRecepcion As Int32,
                                               ByVal fechaRecepcionInicio As String, ByVal fechaRecepcionFin As String, ByVal idUsuario As Int32,
                                               ByVal tipoConsulta As String, ByVal validadoSI As Int32, ByVal validadoNO As Int32, ByVal idPago As String, NaveUsuario As String) As DataTable

        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "clientes"
        parametro.Value = clientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cuentas"
        parametro.Value = cuentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "porFechaPago"
        parametro.Value = porFechaPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaPagoInicio"
        parametro.Value = fechaPagoInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaPagoFin"
        parametro.Value = fechaPagoFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "porFechaRecepcion"
        parametro.Value = porFechaRecepcion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaRecepcionInicio"
        parametro.Value = fechaRecepcionInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaRecepcionFin"
        parametro.Value = fechaRecepcionFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "validadoSi"
        parametro.Value = validadoSI
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "validadoNo"
        parametro.Value = validadoNO
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoConsulta"
        parametro.Value = tipoConsulta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPago"
        parametro.Value = idPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoComercializadora"
        parametro.Value = NaveUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_CotAdmon_ConsultaAdmPagos_27/10/2020", listaParametros)
    End Function

    ''editar informacion del encabezado del pago
    Public Function editarInformacionEncabezadoPago(ByVal pagoId As Int32, ByVal cuentaBancariaId As Int32, ByVal metodoPagoId As Int32,
                                                    ByVal montoPago As Double, ByVal fechaPago As Date, ByVal pagoValidado As Boolean,
                                                    ByVal IdUsuario As Int32) As DataTable


        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "pagoId"
        parametro.Value = pagoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cuentaBancariaId"
        parametro.Value = cuentaBancariaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "metodoPagoId"
        parametro.Value = metodoPagoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "montoPago"
        parametro.Value = montoPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaPago"
        parametro.Value = fechaPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagoValidado"
        parametro.Value = pagoValidado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdUsuario"
        parametro.Value = IdUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_EditarInformacionPago", listaParametros)
    End Function

    Public Function validaPermisoEliminarPagoACotizacion(ByVal UsuarioId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "@UsuarioConsulta"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosWeb_CotAdmon_PermisosBotonEliminarPagos]", listaParametros)

    End Function

    Public Function EliminarPagosAplicadosSAC(ByVal PagoId As Integer, ByVal UsuarioElimina As Integer, ByVal MotivosEliminacion As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "@PagoId"
        parametro.Value = PagoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioElimina"
        parametro.Value = UsuarioElimina
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MotivoEliminacion"
        parametro.Value = MotivosEliminacion
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_PedidosWeb_CotAdmon_EliminarPagosAplicadosCotizaciones]", listaParametros)

    End Function

End Class
