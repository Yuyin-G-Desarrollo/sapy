Public Class ReportePDFBU

    Public Function ConsultarDatosEmisorReportePDF(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As DataTable
        Dim objDA As New Facturacion.Datos.ReportePDFDA
        Return objDA.ConsultarDatosEmisorReportePDF(idDocumento, TipoComprobante)
    End Function

    Public Function ConsultarDatosEnzabezadoReportePDF(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As DataTable
        Dim objDA As New Facturacion.Datos.ReportePDFDA
        Return objDA.ConsultarDatosEnzabezadoReportePDF(idDocumento, TipoComprobante)
    End Function
    Public Function ConsultarComplementosReportePDF(ByVal idDocumento As Integer) As DataTable
        Dim objDA As New Facturacion.Datos.ReportePDFDA
        Return objDA.ConsultarComplementosReportePDF(idDocumento)
    End Function

    Public Function ConsultarConceptosDocumento(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As DataTable
        Dim objDA As New Facturacion.Datos.ReportePDFDA
        Return objDA.ConsultarConceptosDocumento(idDocumento, TipoComprobante)
    End Function

    Public Function ObtenerCFDIRelacionados(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As List(Of Entidades.CFDIRelacionadosDocumento)
        Dim objDA As New Facturacion.Datos.ReportePDFDA
        Dim dtInformacion As New DataTable
        Dim Renglon As Integer = 0
        Dim ListaCFDIRelacionados As New List(Of Entidades.CFDIRelacionadosDocumento)
        Dim EntCFDI As Entidades.CFDIRelacionadosDocumento
        Dim NumeroRenglones As Integer = 0

        dtInformacion = objDA.ObtenerCFDIRelacionados(idDocumento, TipoComprobante)

        Dim dtNumeroRenglones = dtInformacion.AsEnumerable().Select(Function(x) x.Item("dore_rengloncfdirelacionadoid")).Distinct()

        If dtInformacion.Rows.Count > 0 Then
            For Each Fila As String In dtNumeroRenglones
                EntCFDI = New Entidades.CFDIRelacionadosDocumento
                EntCFDI.CFDIRelacionado = dtInformacion.AsEnumerable().Where(Function(x) x.Item("dore_rengloncfdirelacionadoid") = Fila And x.Item("dore_atributo") = "UUID").Select(Function(y) y.Item("dore_valorPDF")).FirstOrDefault()
                EntCFDI.ClaveCFDI = dtInformacion.AsEnumerable().Where(Function(x) x.Item("dore_rengloncfdirelacionadoid") = Fila And x.Item("dore_atributo") = "ClaveCFDI").Select(Function(y) y.Item("dore_valorPDF")).FirstOrDefault()
                EntCFDI.TipoRelacion = dtInformacion.AsEnumerable().Where(Function(x) x.Item("dore_rengloncfdirelacionadoid") = Fila And x.Item("dore_atributo") = "Descripcion").Select(Function(y) y.Item("dore_valorPDF")).FirstOrDefault()
                ListaCFDIRelacionados.Add(EntCFDI)
            Next
        End If
        Return ListaCFDIRelacionados
    End Function

    Public Function ObtenerNumeroReferenciaCliente(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As DataTable
        Dim objDA As New Facturacion.Datos.ReportePDFDA
        Return objDA.ObtenerNumeroReferenciaCliente(idDocumento, TipoComprobante)
    End Function
    Public Function consultarDatosGeneracionPDF(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As DataTable
        Dim objDA As New Facturacion.Datos.ReportePDFDA
        Return objDA.obtenerDatosPDFNotaCredito(idDocumento, TipoComprobante)
    End Function
    Public Function ConsultarDatosEnCabezadoNotaCreditoReportePDF(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As DataTable
        Dim objDA As New Facturacion.Datos.ReportePDFDA
        Return objDA.ConsultarDatosEncabezadoNotaCreditoReportePDF(idDocumento, TipoComprobante)
    End Function
    Public Function ConsultarComplementosNotaCreditoReportePDF(ByVal idDocumento As Integer) As DataTable
        Dim objDA As New Facturacion.Datos.ReportePDFDA
        Return objDA.ConsultarComplementosNotaCreditoReportePDF(idDocumento)
    End Function
    Public Function ConsultarComplementosNotasCreditoReportePDF(ByVal idDocumento As Integer) As DataTable
        Dim objDA As New Facturacion.Datos.ReportePDFDA
        Return objDA.ConsultarComplementosReportePDF(idDocumento)
    End Function
    Public Function consultarEncabezadoFacturaCanceladaPDF(ByVal idDocumento As Integer) As DataTable
        Dim objDA As New Facturacion.Datos.ReportePDFDA
        Return objDA.consultarEncabezadoFacturaCanceladaPDF(idDocumento)
    End Function
    Public Sub actualizaPDFCancelacionFactura(ByVal idDocumento As Integer, ByVal rutaPDFCancelacion As String)
        Dim objActualizacion As New Facturacion.Datos.ReportePDFDA
        objActualizacion.actualizaPDFCancelacionFactura(idDocumento, rutaPDFCancelacion)
    End Sub
End Class
