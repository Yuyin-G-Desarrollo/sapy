Public Class AdministradorCotizacionesBU
    ''consulta de los documentos de las cotizacionew (administrador cotizaciones)
    Public Function consultaDocumentosAdmonCotizaciones(ByVal idCotizacion As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtDocumentos As New DataTable

        dtDocumentos = objDa.consultaDocumentosAdmonCotizaciones(idCotizacion)
        Return dtDocumentos
    End Function

    ''consulta pagos (administrador cotizaciones)
    Public Function consultaPagosAdmonCotizaciones(ByVal idCotizacion As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtPagos As New DataTable

        dtPagos = objDa.consultaPagosAdmonCotizaciones(idCotizacion)

        Return dtPagos
    End Function

    ''consulta de los datos de la cotizacion seleccionada
    Public Function consultaDatosCotizacionSeleccionada(ByVal idCotizacion As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtDetallesSeleccion As New DataTable

        dtDetallesSeleccion = objDa.consultaDatosCotizacionSeleccionada(idCotizacion)

        Return dtDetallesSeleccion
    End Function

    ''consulta para permisos del boton de pagos de pedidos
    Public Function consultaPermisoBotonPagoTotal(ByVal idCotizacion As Int32, ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtPermisos As New DataTable

        dtPermisos = objDa.consultaPermisoBotonPagoTotal(idCotizacion, idUsuario)

        Return dtPermisos
    End Function

    'consulta del cliente (pantalla registrar pagos)
    Public Function consultaClienteRegistroPago(ByVal idCotizacion As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtClientePago As New DataTable

        dtClientePago = objDa.consultaClienteRegistroPago(idCotizacion)

        Return dtClientePago
    End Function

    ''consulta cuentas bancarias registro pagos
    Public Function consultaCuentasBancariasRegistroPagos(ByVal idCotizacion As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtCuentas As New DataTable

        dtCuentas = objDa.consultaCuentasBancariasRegistroPagos(idCotizacion)
        Return dtCuentas
    End Function

    ''consulta tipos de pago (pantalla registrar pagos)
    Public Function consultaTiposPagoRegistroPagos() As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtFormaPago As New DataTable

        dtFormaPago = objDa.consultaTiposPagoRegistroPagos()

        Return dtFormaPago
    End Function

    ''consulta de detalles de la cotizacion registro pagos
    Public Function consultaTotalesCotizacionRegistroPagos(ByVal idCotizacion As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtTotales As New DataTable

        dtTotales = objDa.consultaTotalesCotizacionRegistroPagos(idCotizacion)

        Return dtTotales
    End Function

    ''consulta administrador de cotizaciones vista almacen
    Public Function consultaAdministradorCotizacionesAlmacen(ByVal clientes As String, ByVal estatus As String, ByVal pedidosSAY As String,
                                                              ByVal pedidosSICY As String, ByVal ordenesCliente As String, ByVal cotizaciones As String,
                                                              ByVal idUsuario As Int32, ByVal porFechaCaptura As Int32, ByVal fechaInicio As String,
                                                              ByVal fechafin As String, ByVal tipoConsulta As String, NaveUsuario As String) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtAlmacen As New DataTable

        dtAlmacen = objDa.consultaAdministradorCotizacionesAlmacen(clientes, estatus, pedidosSAY, pedidosSICY, ordenesCliente, cotizaciones, idUsuario, porFechaCaptura,
                                                                   fechaInicio, fechafin, tipoConsulta, NaveUsuario)

        Return dtAlmacen
    End Function

    ''consulta administrador de cotizaciones vista general
    Public Function consultaAdministradorCotizacionesGeneral(ByVal clientes As String, ByVal estatus As String, ByVal pedidosSAY As String,
                                                              ByVal pedidosSICY As String, ByVal ordenesCliente As String, ByVal cotizaciones As String,
                                                              ByVal idUsuario As Int32, ByVal porFechaCaptura As Int32, ByVal fechaInicio As String,
                                                              ByVal fechafin As String, ByVal tipoConsulta As String, NaveUsuario As String) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtGeneral As New DataTable

        dtGeneral = objDa.consultaAdministradorCotizacionesGeneral(clientes, estatus, pedidosSAY, pedidosSICY, ordenesCliente, cotizaciones, idUsuario, porFechaCaptura,
                                                                   fechaInicio, fechafin, tipoConsulta, NaveUsuario)

        Return dtGeneral
    End Function

    ''consulta para validar la vista que se va a mostrar del administrador  
    Public Function consultaValidarVistaAdministrador(ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtCotizaciones As New DataTable

        dtCotizaciones = objDa.consultaValidarVistaAdministrador(idUsuario)

        Return dtCotizaciones
    End Function

    ''inserta pago cotizacion
    Public Function insertaEncabezadoPagosCotizacion(ByVal clienteId As Int32, ByVal cuentabancariaId As Int32, ByVal metodoPagoId As Int32,
                                                     ByVal montoPago As Double, ByVal fechaPago As Date, ByVal rutaArchivo As String,
                                                     ByVal pagoValidado As Boolean, ByVal usuarioCreo As Int32) As DataTable

        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtPago As New DataTable
        dtPago = objDa.insertaEncabezadoPagosCotizacion(clienteId, cuentabancariaId, metodoPagoId, montoPago, fechaPago, rutaArchivo, pagoValidado, usuarioCreo)

        Return dtPago
    End Function


    ''inserta el pago por cotizaciom
    Public Function insertaPagoPorCotizacion(ByVal idPago As Int32, ByVal idCotizacion As Int32, ByVal montoAplicado As Double,
                                             ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtPagoPorCotizacion As DataTable

        dtPagoPorCotizacion = objDa.insertaPagoPorCotizacion(idPago, idCotizacion, montoAplicado, idUsuario)

        Return dtPagoPorCotizacion
    End Function

    ''consulta detalles para cancelacion
    Public Function consultaDetallesParaCancelacion(ByVal idCotizacion As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtDetalles As New DataTable

        dtDetalles = objDa.consultaDetallesParaCancelacion(idCotizacion)

        Return dtDetalles
    End Function

    ''consulta permisos boton cancelar
    Public Function consultaPermisoBotonCancelar(ByVal idCotizacion As Int32, ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtPermiso As New DataTable

        dtPermiso = objDa.consultaPermisoBotonCancelar(idCotizacion, idUsuario)

        Return dtPermiso
    End Function

    ''consulta para cancelar una cotizacion
    Public Function cancelarCotizacion(ByVal idCotizacion As Int32, ByVal motivoCancelacion As String, ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtResultado As New DataTable

        dtResultado = objDa.cancelarCotizacion(idCotizacion, motivoCancelacion, idUsuario)

        Return dtResultado
    End Function

    ''consulta listado de estatus de cotizaciones
    Public Function listadoEstatusCotizaciones() As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtEstatus As New DataTable

        dtEstatus = objDa.listadoEstatusCotizaciones()

        Return dtEstatus
    End Function

    ''consulta monto pendiente total de la cotizacion
    Public Function consultaMontoPendienteCotizacion(ByVal idCotizacion As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtMonto As New DataTable

        dtMonto = objDa.consultaMontoPendienteCotizacion(idCotizacion)

        Return dtMonto
    End Function

    ''consulta para validar las facturas
    Public Function validacionFacturas(ByVal detallesDocumentos As String, ByVal idUsuario As Int32, ByVal tipoFacturacion As Boolean) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtValidacion As New DataTable

        dtValidacion = objDa.validacionFacturas(detallesDocumentos, idUsuario, tipoFacturacion)

        Return dtValidacion
    End Function

    ''consulta para validar los pagos (unicamente cobranza)
    Public Function permisosBotonValidarPagos(ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtValidacion As New DataTable

        dtValidacion = objDa.permisosBotonValidarPagos(idUsuario)

        Return dtValidacion
    End Function

    '' consulta con los permisos administrador de pagos
    Public Function permisosAdministradorPagos(ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtPermisos As New DataTable

        dtPermisos = objDa.permisosAdministradorPagos(idUsuario)

        Return dtPermisos
    End Function

    ''consulta listado cuentas bancarias
    Public Function listadoCuentasBancarias() As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtCuentas As New DataTable

        dtCuentas = objDa.listadoCuentasBancarias()
        Return dtCuentas
    End Function

    ''consulta de los detalles del pago
    Public Function consultaDetallesPago(ByVal pagoId As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtDetallesPago As New DataTable

        dtDetallesPago = objDa.consultaDetallesPago(pagoId)

        Return dtDetallesPago
    End Function

    ''consulta detalles del pago seleccionado
    Public Function consultaPagoSeleccionado(ByVal pagoId As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtPagos As New DataTable

        dtPagos = objDa.consultaPagoSeleccionado(pagoId)

        Return dtPagos
    End Function

    ''actualiza la ruta del archivo
    Public Sub actualizaRutaArchivoPago(ByVal pagoId As Int32, ByVal ruta As String)
        Dim objDa As New Datos.AdministradorCotizacionesDA

        objDa.actualizaRutaArchivoPago(pagoId, ruta)
    End Sub

    ''consulta de las cuentas bancarias por cliente
    Public Function consultaCuentasBancariasPorCliente(ByVal idCliente As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtCuentas As New DataTable

        dtCuentas = objDa.consultaCuentasBancariasPorCliente(idCliente)

        Return dtCuentas
    End Function

    ''consulta de la empresa por cliente 
    Public Function consultaEmpresaPorCliente(ByVal idCliente As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtEmpresa As New DataTable

        dtEmpresa = objDa.consultaEmpresaPorCliente(idCliente)
        Return dtEmpresa
    End Function

    ''consulta de cotizaciones por cliente
    Public Function consultaCotizacionesPorCliente(ByVal idCliente As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtCotizaciones As New DataTable

        dtCotizaciones = objDa.consultaCotizacionesPorCliente(idCliente)
        Return dtCotizaciones
    End Function

    ''consulta para validar pantalla de registro de pagos 
    Public Function validaPerfilRegistoPagosVariasCotizaciones(ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtPerfil As New DataTable

        dtPerfil = objDa.validaPerfilRegistoPagosVariasCotizaciones(idUsuario)

        Return dtPerfil
    End Function

    ''consulta tipo de pagos para el area de cobranza
    Public Function consultaTipoPagoCobranzaRegistroPago() As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtTipoPago As New DataTable

        dtTipoPago = objDa.consultaTipoPagoCobranzaRegistroPago()

        Return dtTipoPago
    End Function

    ''validacion de pagos cobranza
    Public Function validacionPagosCobranza(ByVal pagoId As Int32, ByVal pagoValidado As Boolean, ByVal idUsuario As Int32, ByVal cuentaNoFiscal As Integer, ByVal folioFiscalAnticipo As String) As DataTable
        Dim dtMensaje As New DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA

        dtMensaje = objDa.validacionPagosCobranza(pagoId, pagoValidado, idUsuario, cuentaNoFiscal, folioFiscalAnticipo)

        Return dtMensaje
    End Function

    ''consulta para obtener permiso en boton editar pagos
    Public Function permisoBotonEditarPagos(ByVal idPago As Int32, ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtPermisosEditar As New DataTable

        dtPermisosEditar = objDa.permisoBotonEditarPagos(idPago, idUsuario)

        Return dtPermisosEditar
    End Function

    ''consulta de datos del encabezado del pago al editarlo
    Public Function consultaDatosPagoEditarPago(ByVal pagoId As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtEncabezadoPago As New DataTable

        dtEncabezadoPago = objDa.consultaDatosPagoEditarPago(pagoId)

        Return dtEncabezadoPago
    End Function

    ''consulta listado cotizaciones de un pago (pantalla editar pago)
    Public Function consultaCotizacionesEdicionPagos(ByVal clienteId As Int32, ByVal pagoId As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtCotizaciones As New DataTable

        dtCotizaciones = objDa.consultaCotizacionesEdicionPagos(clienteId, pagoId)

        Return dtCotizaciones
    End Function

    ''consulta permisos administrador de cotizaciones
    Public Function permisosAdministradorCotizaciones(ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtPermisos As New DataTable
        dtPermisos = objDa.permisosAdministradorCotizaciones(idUsuario)

        Return dtPermisos
    End Function

    ''consulta administrador de pagos
    Public Function consultaAdministradorPagos(ByVal clientes As String, ByVal cuentas As String, ByVal porFechaPago As Int32,
                                               ByVal fechaPagoInicio As String, ByVal fechaPagoFin As String, ByVal porFechaRecepcion As Int32,
                                               ByVal fechaRecepcionInicio As String, ByVal fechaRecepcionFin As String, ByVal idUsuario As Int32,
                                               ByVal tipoConsulta As String, ByVal validadoSI As Int32, ByVal validadoNO As Int32, ByVal idPago As String, NaveUsuario As String) As DataTable

        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtAdmon As New DataTable

        dtAdmon = objDa.consultaAdministradorPagos(clientes, cuentas, porFechaPago, fechaPagoInicio, fechaPagoFin, porFechaRecepcion,
                                                 fechaRecepcionInicio, fechaRecepcionFin, idUsuario, tipoConsulta, validadoSI, validadoNO, idPago, NaveUsuario)

        Return dtAdmon
    End Function


    ''Editar cotizaciones en pago
    Public Function editarCotizacionesPago(ByVal pagoCotizacionId As Int32, ByVal pagoId As Int32, ByVal idCotizacion As Int32,
                                            ByVal montoAplicado As Double, ByVal idUsuario As Int32, ByVal tipoModificacion As Boolean) As DataTable

        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtEdicion As New DataTable

        dtEdicion = objDa.editarCotizacionesPago(pagoCotizacionId, pagoId, idCotizacion, montoAplicado, idUsuario, tipoModificacion)

        Return dtEdicion
    End Function

    ''editar informacion del encabezado del pago
    Public Function editarInformacionEncabezadoPago(ByVal pagoId As Int32, ByVal cuentaBancariaId As Int32, ByVal metodoPagoId As Int32,
                                                    ByVal montoPago As Double, ByVal fechaPago As Date, ByVal pagoValidado As Boolean,
                                                    ByVal IdUsuario As Int32) As DataTable

        Dim objDa As New Datos.AdministradorCotizacionesDA
        Dim dtEdicionEnc As New DataTable

        dtEdicionEnc = objDa.editarInformacionEncabezadoPago(pagoId, cuentaBancariaId, metodoPagoId, montoPago, fechaPago, pagoValidado, IdUsuario)

        Return dtEdicionEnc
    End Function

    Public Function validaPermisoEliminarPagoCotizacion(ByVal UsuarioId As Integer) As DataTable
        Dim objDA As New Datos.AdministradorCotizacionesDA
        Dim tbl_permisos As DataTable
        tbl_permisos = objDA.validaPermisoEliminarPagoACotizacion(UsuarioId)
        Return tbl_permisos
    End Function

    Public Function EliminarPagosCotizacionesAplicadosSAC(ByVal PagoId As Integer, ByVal UsuarioElimina As Integer, ByVal MotivosEliminacion As String) As DataTable
        Dim objDA As New Datos.AdministradorCotizacionesDA
        Dim tbl_Mensaje As DataTable
        tbl_Mensaje = objDA.EliminarPagosAplicadosSAC(PagoId, UsuarioElimina, MotivosEliminacion)
        Return tbl_Mensaje
    End Function

End Class
