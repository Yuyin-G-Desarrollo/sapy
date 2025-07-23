Public Class WebFacturasBU
    Public Function obtenerMetodosPagos() As DataTable
        Dim objDA As New Datos.WebFacturasDA
        Return objDA.obtenerMetodosPagos()
    End Function

    Public Function guardarFactura(ByVal facturaId As Integer, ByVal factura As Entidades.Factura, ByVal sucursalId As Integer, ByVal empresaId As Integer, ByVal clienteId As Integer, ByVal usuarioId As Integer) As Integer
        Dim objDA As New Datos.WebFacturasDA
        Dim tabla As New DataTable

        tabla = objDA.guardarFactura(facturaId, factura, sucursalId, empresaId, clienteId, usuarioId)
        Return CInt(tabla.Rows(0)("FACTID"))
    End Function

    Public Sub guardarProductoFactura(ByVal facturaId As Integer, ByVal lstConceptos As List(Of Entidades.Conceptos))
        Dim objDA As New Datos.WebFacturasDA
        objDA.guardarProductoFactura(facturaId, lstConceptos)
    End Sub

    Public Function obtenerListadoFacturas(ByVal usuarioId As Integer, ByVal sucursalId As Integer, ByVal empresaId As Integer, ByVal estatus As String, ByVal filtro As String, ByVal opcFechas As Integer, ByVal filtroFecha1 As String, ByVal filtroFecha2 As String, ByVal orden As String) As DataTable
        Dim objDA As New Datos.WebFacturasDA
        Return objDA.obtenerListadoFacturas(usuarioId, sucursalId, empresaId, estatus, filtro, opcFechas, filtroFecha1, filtroFecha2, orden)
    End Function

    Public Function obtenerFactura(ByVal facturaId As Integer) As Entidades.Factura
        Dim objDA As New Datos.WebFacturasDA
        Dim tabla As New DataTable
        Dim factura As New Entidades.Factura

        tabla = objDA.obtenerFactura(facturaId)
        For Each row As DataRow In tabla.Rows
            factura.FIdFact = CInt(row("fact_id"))
            factura.FVersion = CStr(row("fact_version"))
            factura.FFechaExpedicion = CDate(row("fact_fecha"))
            factura.FSello = CStr(row("fact_sello"))
            factura.FSelloCFD = CStr(row("fact_sello"))

            factura.FFormaDePago = CStr(row("fact_formaPago"))
            factura.FNoCertificado = CStr(row("fact_noCertificado"))
            factura.FSubtotal = CDbl(row("fact_subtotal"))
            factura.FTotal = CDbl(row("fact_total"))
            factura.FTipoComprobante = CStr(row("fact_tipoComprobante"))

            factura.FIdMetodoPago = CInt(row("fact_metodoPagoId"))
            factura.FMetodoPago = CStr(row("metodoPago"))
            factura.FSerie = CStr(row("fact_serie"))
            factura.FFolio = CInt(row("fact_folio"))
            factura.FCertificado = CStr(row("fact_certificado"))

            factura.FCondicionesPago = CStr(row("fact_condicionesPago"))
            factura.FDescuento = CDbl(row("fact_descuento"))
            factura.FMotivoDescuento = CStr(row("fact_motivoDescuento"))
            factura.FTasa = CDbl(row("fact_tasa"))
            factura.FImpuesto = "IVA"
            factura.FImpuestoTrasladadoImporte = CDbl(row("fact_iva"))
            factura.FTotalImpuestosTrasladados = CDbl(row("fact_iva"))

            factura.FMoneda = CStr(row("fact_moneda"))
            factura.FUuid = CStr(row("fact_uuid"))
            factura.FFechaTimbrado = CDate(row("fact_fechaTimbrado"))
            factura.FNoCertificadoSAT = CStr(row("fact_noCertificadoSAT"))
            factura.FSelloSat = CStr(row("fact_selloSAT"))

            factura.FCadenaOriginal = CStr(row("fact_cadenaOriginal"))
            factura.FCadenaOriginalSAT = CStr(row("fact_cadenaOriginalSAT"))
            factura.FXml = CStr(row("fact_xml"))
            factura.FPdf = CStr(row("fact_pdf"))
            factura.FIdCte = CInt(row("fact_clienteId"))

            factura.FIdSucu = CInt(row("fact_sucursalId"))
            factura.FIdEmp = CInt(row("fact_empresaId"))
            factura.FIdUser = CInt(row("fact_usuarioId"))
            factura.FEstatus = CStr(row("fact_estatus"))
            factura.FUuidCancelacion = CStr(row("fact_uuidCancelacion"))

            factura.FFechaCancelacion = CDate(row("fact_fechaCancelacion"))
            factura.FIdUserCancelacion = CInt(row("fact_usuarioIdCancelacion"))
            factura.FImprimeSucursal = CBool(row("fact_imprimeSucursal"))
            factura.FXmlCancelacion = CStr(row("fact_xmlCancelacion"))
            factura.FPdfCancelacion = CStr(row("fact_pdfCancelacion"))

            factura.FReporteId = CInt(row("fact_reporteId"))
            factura.FReporteCancId = CInt(row("fact_reporteCancelacionId"))
            factura.FObservacion = CStr(row("fact_observacion"))
            factura.FMotivoCancelacion = CStr(row("fact_motivoCancelacion"))
        Next

        Return factura
    End Function

    Public Function obtenerProductosFactura(ByVal facturaId As Integer) As List(Of Entidades.Conceptos)
        Dim objDA As New Datos.WebFacturasDA
        Dim tabla As New DataTable
        Dim concepto As Entidades.Conceptos
        Dim lstConceptos As New List(Of Entidades.Conceptos)

        tabla = objDA.obtenerProductosFactura(facturaId)
        For Each row As DataRow In tabla.Rows
            concepto = New Entidades.Conceptos

            concepto.CProductoId = CInt(row("facprod_productoId"))
            concepto.CDescripcion = CStr(row("descripcion"))
            concepto.CUnidadId = CInt(row("facprod_unidadMedidaId"))
            concepto.CUnidad = CStr(row("unidadMedida"))
            concepto.CCantidad = CDbl(row("facprod_cantidad"))
            concepto.CValorUnitario = CDbl(row("facprod_valorUnitario"))
            concepto.CImporte = CDbl(row("facprod_importe"))

            lstConceptos.Add(concepto)
        Next

        Return lstConceptos
    End Function

    Public Sub guardarFacturaCancelada(ByVal facturaId As Integer, ByVal factura As Entidades.Factura)
        Dim objDA As New Datos.WebFacturasDA
        objDA.guardarFacturaCancelada(facturaId, factura)
    End Sub

    Public Function ConsultarEmailFacturacion() As String
        Dim objDA As New Datos.WebFacturasDA
        Dim tabla As New DataTable

        tabla = objDA.ConsultarEmailFacturacion()
        Return tabla.Rows(0)("envio_destinos").ToString
    End Function

    Public Function ConsultarCuentaCorreo() As String
        Dim objDA As New Datos.WebFacturasDA
        Dim tabla As New DataTable

        tabla = objDA.ConsultarCuentaCorreo()
        Return tabla.Rows(0)("cuentaCorreo").ToString
    End Function
End Class
