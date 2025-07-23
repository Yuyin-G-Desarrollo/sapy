Imports System.Data.SqlClient


Public Class ReportePDFDA

    Public Function ConsultarDatosEmisorReportePDF(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoComprobante"
        parametro.Value = TipoComprobante
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_PDF_DatosEmisor]", listaParametros)
    End Function


    Public Function ConsultarDatosEnzabezadoReportePDF(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoComprobante"
        parametro.Value = TipoComprobante
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_PDF_DatosEncabezadoFactura]", listaParametros)
    End Function



    Public Function ConsultarComplementosReportePDF(ByVal idDocumento As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@p_DocumentoID"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_PDF_Complemento]", listaParametros)
    End Function
    Public Function ConsultarConceptosDocumento(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoComprobante"
        parametro.Value = TipoComprobante
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_PDF_ConsultaConceptosDocumento]", listaParametros)
    End Function

    Public Function ObtenerCFDIRelacionados(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoComprobante"
        parametro.Value = TipoComprobante
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_PDF_ObtenerCFDIRelacionados]", listaParametros)
    End Function

    Public Function ObtenerNumeroReferenciaCliente(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoId"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoComprobante"
        parametro.Value = TipoComprobante
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_PDF_ObtenerNumeroReferenciaDocumento]", listaParametros)
    End Function
    Public Function obtenerDatosPDFNotaCredito(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoComprobante"
        parametro.Value = TipoComprobante
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_Timbrado_PDF_DatosEmisor]", listaParametros)
    End Function
    Public Function ConsultarDatosEncabezadoNotaCreditoReportePDF(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoComprobante"
        parametro.Value = TipoComprobante
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_Timbrado_PDF_DatosEncabezadoFactura]", listaParametros)
    End Function
    Public Function ConsultarComplementosNotaCreditoReportePDF(ByVal idDocumento As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@p_DocumentoID"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_Timbrado_PDF_Complemento]", listaParametros)
    End Function
    Public Function ConsultarComplementosNotasCreditoReportePDF(ByVal idDocumento As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@p_DocumentoID"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Cobranza].[SP_NotasCreditoTimbrado_Documento_Rutas]", listaParametros)
    End Function
    Public Function consultarEncabezadoFacturaCanceladaPDF(ByVal idDocumento As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@documentoId"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_Timbrado_PDF_DatosEncabezadoFacturaCancelacion]", listaParametros)
    End Function
    Public Sub actualizaPDFCancelacionFactura(ByVal documentoId As Integer, ByVal rutaPDFCancelacion As String)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@documentoId", documentoId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@rutaPDFCancelacion", rutaPDFCancelacion)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarSentenciaSP("[Cobranza].[SP_NotasCredito_Timbrado_ActualizaPDFCancelacion]", listaParametros)
    End Sub
End Class
