Public Class cotizacionesBu
    ''funcion para recuperar los datos del pedido al generar cotizaciones
    Public Function consultaDatosPedidoCotizacion(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtDatos As New DataTable

        dtDatos = objDa.consultaDatosPedidoCotizacion(idPedido)

        Return dtDatos
    End Function

    ''funcion para recuperar los datos de la FTC cotizaciones
    Public Function consultaDatosFTCCotizacion(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtDatosFTC As New DataTable

        dtDatosFTC = objDa.consultaDatosFTCCotizacion(idPedido)

        Return dtDatosFTC
    End Function

    ''funcion para recuperar los datos de los descuentos FTC
    Public Function consultaDatosFTCDEscuentos(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtDatosDes As New DataTable

        dtDatosDes = objDa.consultaDatosFTCDEscuentos(idPedido)

        Return dtDatosDes
    End Function

    ''funcion para consultar los encabezados de las posible cotizaciones
    Public Function consultaListadoCotizaciones(ByVal idPedidoSay As Int32) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtDatosEnc As New DataTable

        dtDatosEnc = objDa.consultaListadoCotizaciones(idPedidoSay)

        Return dtDatosEnc
    End Function

    ''consulta de razones sociales 
    Public Function consultaRazonesSocialesCotizaciones(ByVal clienteRfcId As Int32) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtRazonesSociales As New DataTable

        dtRazonesSociales = objDa.consultaRazonesSocialesCotizaciones(clienteRfcId)

        Return dtRazonesSociales
    End Function

    'Nueva funcion con pedidos
    Public Function consultaRazonesSocialesCotizacionesPedido(ByVal pedidoId As Int32) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtRazonesSocialesPedido As New DataTable

        dtRazonesSocialesPedido = objDa.consultaRazonesSocialesCotizacionesPedido(pedidoId)

        Return dtRazonesSocialesPedido
    End Function

    ''consulta de los detalles del pedido a cotizar
    Public Function consultaParesPorCotizar(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtPares As New DataTable
        dtPares = objDa.consultaParesPorCotizar(idPedido)

        Return dtPares
    End Function

    ''consulta de los detalles de detalles del pedido pedido a cotizar
    Public Function consultaDatosDetallesParesPorCotizar(ByVal idPedidoDetalle As Int32) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtPares As New DataTable
        dtPares = objDa.consultaDatosDetallesParesPorCotizar(idPedidoDetalle)

        Return dtPares
    End Function

    ''inserta encabezado de la cotizacion
    Public Function insertaEncabezadoCotizacion(ByVal pedidoId As Int32, ByVal solicitadaPor As String, ByVal paresCotizados As Int32,
                                                ByVal montoCotizado As Double, ByVal empresaId As Int32, ByVal importemaxfactura As Double,
                                                ByVal retriccionFacturacionId As Int32, ByVal facturar As Double, ByVal documentar As Double,
                                                ByVal plazo As Int32, ByVal tipoIvaid As Int32, ByVal monedaId As Int32, ByVal idUsuario As Int32,
                                                ByVal esRegalo As Boolean, ByVal cargoDeEnvio As Double) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtCotizacion As New DataTable

        dtCotizacion = objDa.insertaEncabezadoCotizacion(pedidoId, solicitadaPor, paresCotizados, montoCotizado, empresaId, importemaxfactura, retriccionFacturacionId, facturar,
                                                         documentar, plazo, tipoIvaid, monedaId, idUsuario, esRegalo, cargoDeEnvio)

        Return dtCotizacion
    End Function

    ''inserta el documento de la cotizacion
    Public Function insertaDocumentoCotizacion(ByVal tipoOperacion As Int32, ByVal cotizacionId As Int32, ByVal tipoDocumento As String, ByVal clienterfcId As Int32,
                                               ByVal tec As Int32, ByVal rfc As String, ByVal direccion As String, ByVal pares As Int32,
                                               ByVal subtotal As Double, ByVal montoDescuento1 As Double, ByVal subtotalmenosDescuento1 As Double,
                                               ByVal montodescuento2 As Double, ByVal subtotalmenosdescuento2 As Double, ByVal montoPagar As Double,
                                               ByVal idUsuario As Int32, ByVal idDocumento As Int32) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtDocumentosCotizacion As New DataTable

        dtDocumentosCotizacion = objDa.insertaDocumentoCotizacion(tipoOperacion, cotizacionId, tipoDocumento, clienterfcId, tec, rfc, direccion, pares,
                                                                  subtotal, montoDescuento1, subtotalmenosDescuento1, montodescuento2, subtotalmenosdescuento2,
                                                                  montoPagar, idUsuario, idDocumento)
        Return dtDocumentosCotizacion
    End Function

    ''inserta el detalle del documento
    Public Sub insertaDocumentoDetalleCotizacion(ByVal idDocumento As Int32, ByVal pedidoDetalleId As Int32, ByVal pares As Int32,
                                                  ByVal precio As Double, ByVal importe As Double, ByVal IdUsuario As Int32)
        Dim objDa As New Datos.CotizacionesDA


        objDa.insertaDocumentoDetalleCotizacion(idDocumento, pedidoDetalleId, pares, precio, importe, IdUsuario)

    End Sub

    ''inserta los descuentos
    Public Sub insertaDescuentosCotizacion(ByVal cotizacionId As Int32, ByVal motivodescuentoid As Int32, ByVal lugarDescuento As Int32,
                                           ByVal diasPlazo As Int32, ByVal descuentoPorcentaje As Int32, ByVal cantidadDescuento As Double,
                                           ByVal aplicaEncadenado As Int32, ByVal montoDescuento As Double)

        Dim objDa As New Datos.CotizacionesDA


        objDa.insertaDescuentosCotizacion(cotizacionId, motivodescuentoid, lugarDescuento, diasPlazo, descuentoPorcentaje,
                                          cantidadDescuento, aplicaEncadenado, montoDescuento)
    End Sub

    ''consulta del listado de documentos
    Public Function consultaListadoDocumentosCotizaciones(ByVal idCotizacion As Int32) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtDoc As New DataTable

        dtDoc = objDa.consultaListadoDocumentosCotizaciones(idCotizacion)
        Return dtDoc
    End Function

    ''consulta datos del encabezado de la cotizacion
    Public Function consultaDatosEncabezadoCotizacion(ByVal idCotizacion As Int32) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtDatos As New DataTable

        dtDatos = objDa.consultaDatosEncabezadoCotizacion(idCotizacion)

        Return dtDatos
    End Function

    ''consulta cuentas bancarias cotizacion
    Public Function consultaCuentasBancariasCotizacion(ByVal idCotizacion As Int32) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtCuentas As New DataTable

        dtCuentas = objDa.consultaCuentasBancariasCotizacion(idCotizacion)
        Return dtCuentas
    End Function

    ''consulta de los detalles del documento
    Public Function consultaDetallesDocumento(ByVal idDocumento As Int32) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtDocumentos As New DataTable

        dtDocumentos = objDa.consultaDetallesDocumento(idDocumento)
        Return dtDocumentos
    End Function

    ''consulta de descuentos de la cotizacion
    Public Function consultaDescuentosCotizacion(ByVal idCotizacion As Int32, ByVal idDocumento As Int32) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtDescuentosCot As New DataTable
        dtDescuentosCot = objDa.consultaDescuentosCotizacion(idCotizacion, idDocumento)
        Return dtDescuentosCot
    End Function

    ''consulta descuentos plazos a cotizar 
    Public Function consultaDescuentoConPlazo(ByVal idPedido As Int32, ByVal plazo As Int32) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtplazo As New DataTable

        dtplazo = objDa.consultaDescuentoConPlazo(idPedido, plazo)

        Return dtplazo
    End Function

    ''consulta de los datos del encabezado del documento
    Public Function consultaEncabezadoDetallesDocumento(ByVal idDocumento As Int32) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtEncabezado As New DataTable

        dtEncabezado = objDa.consultaEncabezadoDetallesDocumento(idDocumento)
        Return dtEncabezado
    End Function

    ''consulta de cantidad en letra cotizacion
    Public Function consultaCantidadLetras(ByVal idDocumento As Int32) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtCantidad As New DataTable

        dtCantidad = objDa.consultaCantidadLetras(idDocumento)

        Return dtCantidad
    End Function

    ''consulta permisos cotizacion
    Public Function consultaPermisosCotizacion(ByVal idUsuario As Int32, ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtPermisos As New DataTable

        dtPermisos = objDa.consultaPermisosCotizacion(idUsuario, idPedido)

        Return dtPermisos
    End Function

    ''consultaLeyendaProntoPAgo
    Public Function consultaLeyendaProntoPago(ByVal idCotizacion As Int32) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtPago As New DataTable

        dtPago = objDa.consultaLeyendaProntoPago(idCotizacion)

        Return dtPago
    End Function

    Public Function ConsultaOTPorCotizar(idPedido As Integer) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtPago As New DataTable

        dtPago = objDa.ConsultarOTPorCotizar(idPedido)

        Return dtPago
    End Function

    Public Function ConsultaOTPorCotizarDetalle(idOrdenTrabajo As String) As DataTable
        Dim objDa As New Datos.CotizacionesDA
        Dim dtPago As New DataTable

        dtPago = objDa.ConsultarOTPorCotizarDetalle(idOrdenTrabajo)

        Return dtPago
    End Function

    Public Sub Registrar_RelacionOT(informacionOT As String, idCotizacion As Integer, idUsuario As Integer)
        Dim objDa As New Datos.CotizacionesDA

        objDa.Registrar_RelacionOT(informacionOT, idCotizacion, idUsuario)

    End Sub

    Public Function ValidarCotizacionRegalo(idPago As Integer) As Boolean
        Dim objDa As New Datos.CotizacionesDA
        Dim dtResultado As New DataTable
        Dim resultado As Boolean = False

        dtResultado = objDa.ValidarCotizacionRegalo(idPago)

        If dtResultado.Rows.Count > 0 Then
            If CInt(dtResultado.Rows(0).Item("resultado")) > 0 Then
                resultado = True
            End If
        End If

        Return resultado
    End Function
End Class
