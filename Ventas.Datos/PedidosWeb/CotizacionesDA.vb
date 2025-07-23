Imports System.Data.SqlClient

Public Class CotizacionesDA
    ''funcion para recuperar los datos del pedido al generar cotizaciones
    Public Function consultaDatosPedidoCotizacion(ByVal idPedido As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idPedidoSay"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("ventas.SP_PedidosWeb_Cotizaciones_Consulta_DatosPedido", listaParametros)

    End Function

    ''funcion para recuperar los datos de la FTC cotizaciones
    Public Function consultaDatosFTCCotizacion(ByVal idPedido As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idPedidoSay"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Cotizaciones_ConsultaDatosFTC", listaParametros)
    End Function

    ''funcion para recuperar los datos de los descuentos FTC
    Public Function consultaDatosFTCDEscuentos(ByVal idPedido As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idPedidoSay"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Cotizaciones_ConsultaDescuentosFTC", listaParametros)
    End Function

    ''funcion para consultar los encabezados de las posible cotizaciones
    Public Function consultaListadoCotizaciones(ByVal idPedidoSay As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idPedidoSay"
        parametro.Value = idPedidoSay
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Cotizaciones_ConsultaListadoCotizaciones", listaParametros)
    End Function

    ''consulta de razones sociales 
    Public Function consultaRazonesSocialesCotizaciones(ByVal clienteRfcId As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "clienteRfcId"
        parametro.Value = clienteRfcId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Cotizaciones_ConsultaRazonesSociales", listaParametros)
    End Function

    'Nueva funcion consulta pedidos
    Public Function consultaRazonesSocialesCotizacionesPedido(ByVal pedidoId As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "PedidoID"
        parametro.Value = pedidoId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Cotizaciones_ConsultaRazonesSociales_Nuevo", listaParametros)
    End Function

    ''consulta de los detalles del pedido a cotizar
    Public Function consultaParesPorCotizar(ByVal idPedido As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Cotizaciones_ConsultaParesPorCotizar", listaParametros)
    End Function


    ''consulta de los detalles de detalles del pedido pedido a cotizar
    Public Function consultaDatosDetallesParesPorCotizar(ByVal idPedidoDetalle As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idPedidoDetalle"
        parametro.Value = idPedidoDetalle
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Cotizaciones_ConsultaDatosDetallesParesPorCotizar", listaParametros)
    End Function

    ''inserta encabezado de la cotizacion
    Public Function insertaEncabezadoCotizacion(ByVal pedidoId As Int32, ByVal solicitadaPor As String, ByVal paresCotizados As Int32,
                                                ByVal montoCotizado As Double, ByVal empresaId As Int32, ByVal importemaxfactura As Double,
                                                ByVal retriccionFacturacionId As Int32, ByVal facturar As Double, ByVal documentar As Double,
                                                ByVal plazo As Int32, ByVal tipoIvaid As Int32, ByVal monedaId As Int32, ByVal idUsuario As Int32,
                                                ByVal esRegalo As Boolean, ByVal cargoDeEnvio As Double) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "pedidoId"
        parametro.Value = pedidoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "solicitadaPor"
        parametro.Value = solicitadaPor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "paresCotizados"
        parametro.Value = paresCotizados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "montoCotizado"
        parametro.Value = montoCotizado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "empresaId"
        parametro.Value = empresaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "importemaxfactura"
        parametro.Value = importemaxfactura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "retriccionFacturacionId"
        parametro.Value = retriccionFacturacionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "facturar"
        parametro.Value = facturar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "documentar"
        parametro.Value = documentar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "plazo"
        parametro.Value = plazo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoIvaid"
        parametro.Value = tipoIvaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "monedaId"
        parametro.Value = monedaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "esRegalo"
        parametro.Value = esRegalo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cargoDeEnvio"
        parametro.Value = cargoDeEnvio
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Cotizaciones_InsertaEncabezadoCotizacion", listaParametros)
    End Function

    Public Function insertaDocumentoCotizacion(ByVal tipoOperacion As Int32, ByVal cotizacionId As Int32, ByVal tipoDocumento As String, ByVal clienterfcId As Int32,
                                             ByVal tec As Int32, ByVal rfc As String, ByVal direccion As String, ByVal pares As Int32,
                                             ByVal subtotal As Double, ByVal montoDescuento1 As Double, ByVal subtotalmenosDescuento1 As Double,
                                             ByVal montodescuento2 As Double, ByVal subtotalmenosdescuento2 As Double, ByVal montoPagar As Double,
                                             ByVal idUsuario As Int32, ByVal idDocumento As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "tipoOperacion"
        parametro.Value = tipoOperacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cotizacionId"
        parametro.Value = cotizacionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoDocumento"
        parametro.Value = tipoDocumento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clienterfcId"
        parametro.Value = clienterfcId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tec"
        parametro.Value = tec
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "rfc"
        parametro.Value = rfc
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "direccion"
        parametro.Value = direccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pares"
        parametro.Value = pares
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "subtotal"
        parametro.Value = subtotal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "montoDescuento1"
        parametro.Value = montoDescuento1
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "subtotalmenosDescuento1"
        parametro.Value = subtotalmenosDescuento1
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "montodescuento2"
        parametro.Value = montodescuento2
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "subtotalmenosdescuento2"
        parametro.Value = subtotalmenosdescuento2
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "montoPagar"
        parametro.Value = montoPagar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idDocumento"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Cotizaciones_InsertaDocumentosCotizacion", listaParametros)
    End Function

    ''inserta el detalle del documento
    Public Sub insertaDocumentoDetalleCotizacion(ByVal idDocumento As Int32, ByVal pedidoDetalleId As Int32, ByVal pares As Int32,
                                                      ByVal precio As Double, ByVal importe As Double, ByVal IdUsuario As Int32)

        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idDocumento"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidoDetalleId"
        parametro.Value = pedidoDetalleId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pares"
        parametro.Value = pares
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "precio"
        parametro.Value = precio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "importe"
        parametro.Value = importe
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdUsuario"
        parametro.Value = IdUsuario
        listaParametros.Add(parametro)

        persistencia.EjecutarSentenciaSP("Ventas.SP_PedidosWeb_Cotizacion_InsertaDocumentoDetalles", listaParametros)
    End Sub

    ''inserta los descuentos
    Public Sub insertaDescuentosCotizacion(ByVal cotizacionId As Int32, ByVal motivodescuentoid As Int32, ByVal lugarDescuento As Int32,
                                           ByVal diasPlazo As Int32, ByVal descuentoPorcentaje As Int32, ByVal cantidadDescuento As Double,
                                           ByVal aplicaEncadenado As Int32, ByVal montoDescuento As Double)

        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "cotizacionId"
        parametro.Value = cotizacionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "motivodescuentoid"
        parametro.Value = motivodescuentoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "lugarDescuento"
        parametro.Value = lugarDescuento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "diasPlazo"
        parametro.Value = diasPlazo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "descuentoPorcentaje"
        parametro.Value = descuentoPorcentaje
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cantidadDescuento"
        parametro.Value = cantidadDescuento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "aplicaEncadenado"
        parametro.Value = aplicaEncadenado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "montoDescuento"
        parametro.Value = montoDescuento
        listaParametros.Add(parametro)

        persistencia.EjecutarSentenciaSP("Ventas.SP_PedidosWeb_Cotizaciones_InsertaDescuentosCotizacion", listaParametros)
    End Sub

    ''consulta del listado de documentos
    Public Function consultaListadoDocumentosCotizaciones(ByVal idCotizacion As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "IdCotizacion"
        parametro.Value = idCotizacion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_COtizaciones_ConsultaListadoDocumentos", listaParametros)
    End Function


    ''consulta datos del encabezado de la cotizacion
    Public Function consultaDatosEncabezadoCotizacion(ByVal idCotizacion As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "IdCotizacion"
        parametro.Value = idCotizacion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Cotizacion_ConsultaDatosEncabezadoCot", listaParametros)
    End Function

    ''consulta cuentas bancarias cotizacion
    Public Function consultaCuentasBancariasCotizacion(ByVal idCotizacion As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "IdCotizacion"
        parametro.Value = idCotizacion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Cotizaciones_ConsultaCuentasBancarias", listaParametros)
    End Function

    ''consulta de los detalles del documento
    Public Function consultaDetallesDocumento(ByVal idDocumento As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "IdDocumento"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Cotizaciones_ConsultaDetallesDocumentos", listaParametros)
    End Function

    ''consulta de descuentos de la cotizacion
    Public Function consultaDescuentosCotizacion(ByVal idCotizacion As Int32, ByVal idDocumento As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idCotizacion"
        parametro.Value = idCotizacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idDocumento"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Cotizaciones_ConsultaDescuentosCotizaciones", listaParametros)
    End Function

    ''consulta descuentos plazos a cotizar 
    Public Function consultaDescuentoConPlazo(ByVal idPedido As Int32, ByVal plazo As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idPedidoSay"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "plazo"
        parametro.Value = plazo
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Cotizaciones_ConsultaDescuentosPlazo", listaParametros)
    End Function

    ''consulta de los datos del encabezado del documento
    Public Function consultaEncabezadoDetallesDocumento(ByVal idDocumento As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "IdDocumento"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Cotizaciones_ConsultaEncabezadoDocumentosDetalles", listaParametros)
    End Function

    ''consulta de cantidad en letra cotizacion
    Public Function consultaCantidadLetras(ByVal idDocumento As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "IdDocumento"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Cotizacion_ConsultaCantidadLetra", listaParametros)
    End Function

    ''consulta permisos cotizacion
    Public Function consultaPermisosCotizacion(ByVal idUsuario As Int32, ByVal idPedido As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "IdUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Cotizaciones_PermisosCotizaciones", listaParametros)
    End Function

    ''consultaLeyendaProntoPAgo
    Public Function consultaLeyendaProntoPago(ByVal idCotizacion As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "IdCotizacion"
        parametro.Value = idCotizacion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_Cotizaciones_LeyendaProntoPago", listaParametros)
    End Function


    Public Function ConsultarOTPorCotizar(idPedido As Integer) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "@idPedido"
        parametro.Value = idPedido
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[Ventas].[SP_PedidosWeb_CotAdmon_ConsultarOT]", listaParametros)
    End Function

    Public Function ConsultarOTPorCotizarDetalle(idOrdenTrabajo As String) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "@OT"
        parametro.Value = idOrdenTrabajo
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[Ventas].[SP_PedidosWeb_CotAdmon_ConsultarOT_Detalle]", listaParametros)
    End Function

    Public Sub Registrar_RelacionOT(informacionOT As String, idCotizacion As Integer, idUsuario As Integer)
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "@informacionOT"
        parametro.Value = informacionOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idCotizacion"
        parametro.Value = idCotizacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioid"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        persistencia.EjecutarConsultaSP("[Ventas].[SP_PedidosWeb_CotAdmon_Registrar_RelacionOT]", listaParametros)

    End Sub

    Public Function ValidarCotizacionRegalo(idPago As Integer) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "@idPago"
        parametro.Value = idPago
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[Ventas].[SP_PedidosWeb_CotAdmon_ValidarCotizacionRegalo]", listaParametros)

    End Function
End Class
