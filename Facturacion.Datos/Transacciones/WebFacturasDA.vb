Imports System.Data.SqlClient
Public Class WebFacturasDA
    Public Function obtenerMetodosPagos() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "select mepa_metodopagoid ID, mepa_nombre METODO from Cobranza.MetodoPago where mepa_activo = 1 order by mepa_nombre"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function guardarFactura(ByVal facturaId As Integer, ByVal factura As Entidades.Factura, ByVal sucursalId As Integer, ByVal empresaId As Integer, ByVal clienteId As Integer, ByVal usuarioId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "id"
        parametro.Value = facturaId
        listaParametros.Add(parametro)

        If factura.FVersion <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "version"
            parametro.Value = factura.FVersion
            listaParametros.Add(parametro)
        End If

        If factura.FFechaExpedicion <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "fecha"
            parametro.Value = factura.FFechaExpedicion
            listaParametros.Add(parametro)
        End If

        If factura.FSello <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "sello"
            parametro.Value = factura.FSello
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "formaPago"
        parametro.Value = factura.FFormaDePago
        listaParametros.Add(parametro)

        If factura.FNoCertificado <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "noCertificado"
            parametro.Value = factura.FNoCertificado
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "subtotal"
        parametro.Value = factura.FSubtotal.ToString("0.00")
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "total"
        parametro.Value = factura.FTotal.ToString("0.00")
        listaParametros.Add(parametro)

        If factura.FTipoComprobante <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "tipoComprobante"
            parametro.Value = factura.FTipoComprobante
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "metodoPagoId"
        parametro.Value = factura.FIdMetodoPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "serie"
        parametro.Value = factura.FSerie
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "folio"
        parametro.Value = factura.FFolio
        listaParametros.Add(parametro)

        If factura.FCertificado <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "certificado"
            parametro.Value = factura.FCertificado
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "condicionesPago"
        parametro.Value = factura.FCondicionesPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "descuento"
        parametro.Value = factura.FDescuento.ToString("0.00")
        listaParametros.Add(parametro)

        If factura.FMotivoDescuento <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "motivoDescuento"
            parametro.Value = factura.FMotivoDescuento
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "tasa"
        parametro.Value = factura.FTasa.ToString("0.00")
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "iva"
        parametro.Value = factura.FImpuestoTrasladadoImporte.ToString("0.00")
        listaParametros.Add(parametro)

        If factura.FMoneda <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "moneda"
            parametro.Value = factura.FMoneda
            listaParametros.Add(parametro)
        End If

        If factura.FUuid <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "uuid"
            parametro.Value = factura.FUuid
            listaParametros.Add(parametro)
        End If

        If factura.FFechaTimbrado <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "fechaTimbrado"
            parametro.Value = factura.FFechaTimbrado
            listaParametros.Add(parametro)
        End If

        If factura.FNoCertificadoSAT <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "noCertificadoSAT"
            parametro.Value = factura.FNoCertificadoSAT
            listaParametros.Add(parametro)
        End If

        If factura.FSelloSat <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "selloSAT"
            parametro.Value = factura.FSelloSat
            listaParametros.Add(parametro)
        End If

        If factura.FCadenaOriginal <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "cadenaOriginal"
            parametro.Value = factura.FCadenaOriginal
            listaParametros.Add(parametro)
        End If

        If factura.FCadenaOriginalSAT <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "cadenaOriginalSAT"
            parametro.Value = factura.FCadenaOriginalSAT
            listaParametros.Add(parametro)
        End If

        If factura.FXml <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "xml"
            parametro.Value = factura.FXml
            listaParametros.Add(parametro)
        End If

        If factura.FPdf <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "pdf"
            parametro.Value = factura.FPdf
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "clienteId"
        parametro.Value = clienteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "sucursalId"
        parametro.Value = sucursalId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "empresaId"
        parametro.Value = empresaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "imprimeSucursal"
        parametro.Value = factura.FImprimeSucursal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "reporteId"
        parametro.Value = factura.FReporteId
        listaParametros.Add(parametro)

        If factura.FObservacion <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "observacion"
            parametro.Value = factura.FObservacion
            listaParametros.Add(parametro)
        End If

        Return operacion.EjecutarConsultaSP("Facturacion.SP_GuardarFactura", listaParametros)
    End Function

    Public Sub guardarProductoFactura(ByVal facturaId As Integer, ByVal lstConceptos As List(Of Entidades.Conceptos))
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As List(Of SqlParameter)
        Dim parametro As SqlParameter

        For i As Integer = 0 To lstConceptos.Count - 1
            listaParametros = New List(Of SqlParameter)

            parametro = New SqlParameter
            parametro.ParameterName = "facturaId"
            parametro.Value = facturaId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "productoId"
            parametro.Value = lstConceptos.Item(i).CProductoId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "unidadMedidaId"
            parametro.Value = lstConceptos.Item(i).CUnidadId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "cantidad"
            parametro.Value = lstConceptos.Item(i).CCantidad
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "valorUnitario"
            parametro.Value = lstConceptos.Item(i).CValorUnitario
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "importe"
            parametro.Value = lstConceptos.Item(i).CImporte
            listaParametros.Add(parametro)

            operacion.EjecutarConsultaSP("Facturacion.SP_GuardarProductoFactura", listaParametros)
        Next
    End Sub

    Public Function obtenerListadoFacturas(ByVal usuarioId As Integer, ByVal sucursalId As Integer, ByVal empresaId As Integer, ByVal estatus As String, ByVal filtro As String, ByVal opcFechas As Integer, ByVal filtroFecha1 As String, ByVal filtroFecha2 As String, ByVal orden As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "SELECT row_number() OVER(ORDER BY f.fact_fecha " & orden & ") NUM, " & vbCrLf & _
                    "fact_id ID, " & vbCrLf & _
                    "ISNULL(fact_serie + '' + CONVERT(VARCHAR(10), fact_folio), '') FACTURA, " & vbCrLf & _
                    "ISNULL(s.suc_nombre, '') SUCURSAL, " & vbCrLf & _
                    "ISNULL(e.empr_nombre, '') EMPRESA, " & vbCrLf & _
                    "ISNULL(c.cfac_razonsocial, '') CLIENTE, " & vbCrLf & _
                    "ISNULL(sum(fp.facprod_cantidad), 0) PARES, " & vbCrLf & _
                    "ISNULL(f.fact_subtotal, 0) SUBTOTAL, " & vbCrLf & _
                    "ISNULL(f.fact_iva, 0) IVA, " & vbCrLf & _
                    "ISNULL(f.fact_total, 0) TOTAL, " & vbCrLf & _
                    "ISNULL(CONVERT(VARCHAR(20), f.fact_fechaTimbrado, 120), '') FECHA, " & vbCrLf & _
                    "ISNULL(f.fact_uuid, '') UUID, " & vbCrLf & _
                    "(CASE WHEN f.fact_estatus = 'ACTIVA' THEN ISNULL(f.fact_xml, '') ELSE ISNULL(f.fact_xmlCancelacion, '') END) RUTA_XML, " & vbCrLf & _
                    "(CASE WHEN f.fact_estatus = 'ACTIVA' THEN ISNULL(f.fact_pdf, '') ELSE ISNULL(f.fact_pdfCancelacion, '') END) RUTA_PDF, " & vbCrLf & _
                    "ISNULL(f.fact_estatus, '') ESTATUS " & vbCrLf & _
                    "FROM Facturacion.Factura f " & vbCrLf & _
                    "INNER JOIN Facturacion.Sucursales s ON s.suc_sucursalid = f.fact_sucursalId " & vbCrLf & _
                    "INNER JOIN Framework.Empresas e ON e.empr_empresaid = f.fact_empresaId " & vbCrLf & _
                    "INNER JOIN Facturacion.ClientesCFDI c ON c.cfac_clienteid = f.fact_clienteId " & vbCrLf & _
                    "INNER JOIN Facturacion.SucursalUsuarios su ON su.sucu_sucursaldid = f.fact_sucursalId " & vbCrLf & _
                    "INNER JOIN Facturacion.FacturaProductos fp on fp.facprod_facuraId = f.fact_id " & vbCrLf & _
                    "WHERE su.susu_usuarioid = " & usuarioId & " AND fact_estatus = '" & estatus & "' "

        If sucursalId <> 0 Then
            consulta &= " AND f.fact_sucursalId = " & sucursalId & vbCrLf
        End If

        If empresaId <> 0 Then
            consulta &= " AND f.fact_empresaId = " & empresaId & vbCrLf
        End If

        Select Case opcFechas
            Case 0
                consulta &= " AND MONTH(ISNULL(f.fact_fechaTimbrado, f.fact_fecha)) = MONTH(GETDATE()) AND YEAR(ISNULL(f.fact_fechaTimbrado, f.fact_fecha)) = YEAR(GETDATE()) " & vbCrLf
            Case 1
                consulta &= " AND (ISNULL(f.fact_fechaTimbrado, f.fact_fecha)) BETWEEN '" & filtroFecha1 & " 00:00' AND '" & filtroFecha2 & " 23:59' " & vbCrLf
            Case 2
                consulta &= " AND DATEPART(wk, ISNULL(fact_fechaTimbrado, fact_fecha)) = " & filtroFecha1 & " and YEAR(ISNULL(fact_fechaTimbrado, fact_fecha)) = " & filtroFecha2 & vbCrLf
        End Select

        If filtro <> "" Then
            consulta &= " AND (fact_serie + '' + CONVERT(VARCHAR(10), fact_folio) LIKE '%" & filtro & "%' OR c.cfac_razonsocial LIKE '%" & filtro & "%') "
        End If

        consulta &= " GROUP BY fact_id, f.fact_fecha, f.fact_serie, f.fact_folio, s.suc_nombre, e.empr_nombre, c.cfac_razonsocial, f.fact_total, f.fact_fechaTimbrado, f.fact_uuid, f.fact_estatus, f.fact_xml, f.fact_xmlCancelacion, f.fact_pdf, f.fact_pdfCancelacion, f.fact_subtotal, f.fact_iva "
        'consulta &= vbCrLf & "ORDER BY FECHA DESC"

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerFactura(ByVal facturaId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "SELECT ISNULL(fact_id, 0) fact_id, " & vbCrLf & _
                    "ISNULL(fact_version, '') fact_version, " & vbCrLf & _
                    "ISNULL(fact_fecha, '') fact_fecha, " & vbCrLf & _
                    "ISNULL(fact_sello, '') fact_sello, " & vbCrLf & _
                    "ISNULL(fact_formaPago, '') fact_formaPago, " & vbCrLf & _
                    "ISNULL(fact_noCertificado, '') fact_noCertificado, " & vbCrLf & _
                    "ISNULL(fact_subtotal, 0) fact_subtotal, " & vbCrLf & _
                    "ISNULL(fact_total, 0) fact_total, " & vbCrLf & _
                    "ISNULL(fact_tipoComprobante, '') fact_tipoComprobante, " & vbCrLf & _
                    "ISNULL(fact_metodoPagoId, 0) fact_metodoPagoId, " & vbCrLf & _
                    "ISNULL(mp.mepa_nombre, '') metodoPago, " & vbCrLf & _
                    "ISNULL(fact_serie, '') fact_serie, " & vbCrLf & _
                    "ISNULL(fact_folio, 0) fact_folio, " & vbCrLf & _
                    "ISNULL(fact_certificado, '') fact_certificado, " & vbCrLf & _
                    "ISNULL(fact_condicionesPago, '') fact_condicionesPago, " & vbCrLf & _
                    "ISNULL(fact_descuento, 0) fact_descuento, " & vbCrLf & _
                    "ISNULL(fact_motivoDescuento, '') fact_motivoDescuento, " & vbCrLf & _
                    "ISNULL(fact_tasa, 0) fact_tasa, " & vbCrLf & _
                    "ISNULL(fact_iva, 0) fact_iva, " & vbCrLf & _
                    "ISNULL(fact_moneda, '') fact_moneda, " & vbCrLf & _
                    "ISNULL(fact_uuid, '') fact_uuid, " & vbCrLf & _
                    "ISNULL(fact_fechaTimbrado, '') fact_fechaTimbrado, " & vbCrLf & _
                    "ISNULL(fact_noCertificadoSAT, '') fact_noCertificadoSAT, " & vbCrLf & _
                    "ISNULL(fact_selloSAT, '') fact_selloSAT, " & vbCrLf & _
                    "ISNULL(fact_cadenaOriginal, '') fact_cadenaOriginal, " & vbCrLf & _
                    "ISNULL(fact_cadenaOriginalSAT, '') fact_cadenaOriginalSAT, " & vbCrLf & _
                    "ISNULL(fact_xml, '') fact_xml, " & vbCrLf & _
                    "ISNULL(fact_pdf, '') fact_pdf, " & vbCrLf & _
                    "ISNULL(fact_clienteId, 0) fact_clienteId, " & vbCrLf & _
                    "ISNULL(fact_sucursalId, 0) fact_sucursalId, " & vbCrLf & _
                    "ISNULL(fact_empresaId, 0) fact_empresaId, " & vbCrLf & _
                    "ISNULL(fact_usuarioId, 0) fact_usuarioId, " & vbCrLf & _
                    "ISNULL(fact_estatus, '') fact_estatus, " & vbCrLf & _
                    "ISNULL(fact_uuidCancelacion, '') fact_uuidCancelacion, " & vbCrLf & _
                    "ISNULL(fact_fechaCancelacion, '') fact_fechaCancelacion, " & vbCrLf & _
                    "ISNULL(fact_usuarioIdCancelacion, '') fact_usuarioIdCancelacion, " & vbCrLf & _
                    "ISNULL(fact_imprimeSucursal, 0) fact_imprimeSucursal, " & vbCrLf & _
                    "ISNULL(fact_xmlCancelacion, '') fact_xmlCancelacion, " & vbCrLf & _
                    "ISNULL(fact_pdfCancelacion, '') fact_pdfCancelacion, " & vbCrLf & _
                    "ISNULL(fact_reporteId, 0) fact_reporteId, " & vbCrLf & _
                    "ISNULL(fact_reporteCancelacionId, 0) fact_reporteCancelacionId, " & vbCrLf & _
                    "ISNULL(fact_observacion, '') fact_observacion, " & vbCrLf & _
                    "ISNULL(fact_motivoCancelacion, '') fact_motivoCancelacion " & vbCrLf & _
                    "FROM Facturacion.Factura f " & vbCrLf & _
                    "INNER JOIN Cobranza.MetodoPago mp on mp.mepa_metodopagoid = f.fact_metodoPagoId " & vbCrLf & _
                    "WHERE fact_id = " & facturaId

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerProductosFactura(ByVal facturaId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "SELECT ISNULL(facprod_id, 0) facprod_id, " & vbCrLf & _
                    "ISNULL(facprod_facuraId, 0) facprod_facuraId, " & vbCrLf & _
                    "ISNULL(facprod_productoId, 0) facprod_productoId, " & vbCrLf & _
                    "ISNULL(p.fapr_descripción, '') descripcion, " & vbCrLf & _
                    "ISNULL(facprod_unidadMedidaId, 0) facprod_unidadMedidaId, " & vbCrLf & _
                    "ISNULL(um.unme_descripcion, '') unidadMedida, " & vbCrLf & _
                    "ISNULL(facprod_cantidad, 0) facprod_cantidad, " & vbCrLf & _
                    "ISNULL(facprod_valorUnitario, 0) facprod_valorUnitario, " & vbCrLf & _
                    "ISNULL(facprod_importe, 0) facprod_importe " & vbCrLf & _
                    "FROM Facturacion.FacturaProductos fp " & vbCrLf & _
                    "INNER JOIN Facturacion.FacturacionProductos p on p.fapr_productoid = fp.facprod_productoId " & vbCrLf & _
                    "INNER JOIN Materiales.UnidadDeMedida um on um.unme_idunidad = fp.facprod_unidadMedidaId " & vbCrLf & _
                    "WHERE facprod_facuraId = " & facturaId

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function guardarFacturaCancelada(ByVal facturaId As Integer, ByVal factura As Entidades.Factura) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "id"
        parametro.Value = facturaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "uuidCancelacion"
        parametro.Value = factura.FUuidCancelacion
        listaParametros.Add(parametro)

        If factura.FFechaCancelacion <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "fechaCancelacion"
            parametro.Value = factura.FFechaCancelacion
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioIdCancelacion"
        parametro.Value = factura.FIdUserCancelacion
        listaParametros.Add(parametro)

        If factura.FXmlCancelacion <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "xmlCancelacion"
            parametro.Value = factura.FXmlCancelacion
            listaParametros.Add(parametro)
        End If

        If factura.FPdfCancelacion <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "pdfCancelacion"
            parametro.Value = factura.FPdfCancelacion
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "reporteCancelacionId"
        parametro.Value = factura.FReporteCancId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "motivoCancelacion"
        parametro.Value = factura.FMotivoCancelacion
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Facturacion.SP_GuardarFacturaCancelada", listaParametros)
    End Function

    Public Sub actualizaRutaPDF(ByVal facturaId As Integer, ByVal factura As Entidades.Factura, ByVal tipo As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        Select Case tipo
            Case "Factura"
                consulta = "update Facturacion.Factura set fact_pdf = '" & factura.FPdf.ToUpper & "', fact_cadenaOriginalSAT = '" & factura.FCadenaOriginalSAT & "' where fact_id = " & facturaId
            Case "Cancelacion"
                consulta = "update Facturacion.Factura set fact_pdfCancelacion = '" & factura.FPdfCancelacion.ToUpper & "' where fact_id = " & facturaId
        End Select

        operacion.EjecutaConsulta(consulta)
    End Sub

    Public Function ConsultarEmailFacturacion() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "EXEC FACTURACION.SP_ConsultarEmailFacturacion"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultarCuentaCorreo() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "EXEC FACTURACION.SP_ConsultarCuentaCorreo"
        Return operacion.EjecutaConsulta(consulta)
    End Function
End Class
