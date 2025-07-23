Imports Proveedores.DA

Public Class AdmonDoctosComprasPT_BU
    Dim objDA As New AdmonDoctosComprasPT_DA()

    Public Function ObtenerEstatusFacturacion() As DataTable
        Return objDA.ObtenerEstatusFacturacion()
    End Function

    Public Function ObtenerEmisorFacturacion() As DataTable
        Return objDA.ObtenerEmisorFacturacion()
    End Function

    Public Function ObtenerReceptorFacturacion() As DataTable
        Return objDA.ObtenerReceptorFacturacion()
    End Function

    Public Function ObtenerDocumentos(ByVal porFFacturacion As Boolean, ByVal porFCancelacion As Boolean, ByVal porFIngreso As Boolean,
                                      ByVal fechaInicio As Date, ByVal fechaFin As Date,
                                      ByVal estatusIds As String, ByVal DocumentosIds As String, ByVal folios As String,
                                      ByVal emisorIds As String, ByVal receptorIds As String, ByVal articuloIds As String) As DataTable
        Return objDA.ObtenerDocumentos(porFFacturacion, porFCancelacion, porFIngreso, fechaInicio, fechaFin, estatusIds, DocumentosIds, folios, emisorIds, receptorIds, articuloIds)
    End Function

    Public Function ObtenerDetallesDocumentos(ByVal documentoId As String) As DataTable
        Return objDA.ObtenerDetallesDocumentos(documentoId)
    End Function

    Public Function ActualizarMtvoSinTimbrarFacturaPIDocumento(ByVal idDocumento As Integer, ByVal motivo As String) As String
        Dim resultado As String = String.Empty
        Dim dtResultado As New DataTable

        dtResultado = objDA.ActualizarMtvoSinTimbrarFacturaPIDocumento(idDocumento, motivo)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0)("mensaje").ToString
            End If
        End If

        Return resultado
    End Function

    Public Function ActualizarInfoFacturaPIDocumento(ByVal idDocumento As Integer, ByVal sello As String,
                                                     ByVal uuid As String, ByVal fechaTimbrado As String,
                                                     ByVal versionSat As String, ByVal rfcProvCertif As String,
                                                     ByVal noCertificadoSAT As String, ByVal selloSAT As String,
                                                     ByVal cadenaOriginal As String, ByVal cadenaOriginalComplemento As String) As String
        Dim resultado As String = String.Empty
        Dim dtResultado As New DataTable

        dtResultado = objDA.ActualizarInfoFacturaPIDocumento(idDocumento, sello, uuid, fechaTimbrado, versionSat, rfcProvCertif, noCertificadoSAT, selloSAT, cadenaOriginal, cadenaOriginalComplemento)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0)("mensaje").ToString
            End If
        End If

        Return resultado
    End Function

    Public Function ObtenerInfoCXPSaldo(ByVal idDocumento As Integer) As DataTable
        Return objDA.ObtenerInfoCXPSaldo(idDocumento)
    End Function

    Public Function InsertarCXPSaldo(ByVal tipoDoc As Integer, ByVal idProveedor As Integer, ByVal numDoc As String,
                                     ByVal fechaDoc As Date, ByVal fechaVencimiento As Date, ByVal semanaPago As Integer,
                                     ByVal semanaPagada As Integer, ByVal subTotal As Double, ByVal iva As Double,
                                     ByVal total As Double, ByVal totalDoc As Double, ByVal moneda As Integer,
                                     ByVal nave As Integer, ByVal añoSemPago As Integer, ByVal rfcContribuyente As String,
                                     ByVal rfcProveedor As String, ByVal giro As String, ByVal idcomprobantesicy As Integer) As String
        Dim resultado As String = String.Empty
        Dim dtResultado As New DataTable

        dtResultado = objDA.InsertarCXPSaldo(tipoDoc, idProveedor, numDoc, fechaDoc, fechaVencimiento, semanaPago, semanaPagada, subTotal, iva, total, totalDoc, moneda, nave, añoSemPago, rfcContribuyente, rfcProveedor, giro, idcomprobantesicy)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0)(0).ToString
            End If
        End If

        Return resultado
    End Function

    Public Function ValidarCuentaPorPagar(ByVal folio As String, ByVal fecha As Date, ByVal total As Double) As Boolean
        Dim resultado As Boolean = False
        Dim dtResultado As New DataTable

        dtResultado = objDA.ValidarCuentaPorPagar(folio, fecha, total)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = CBool(dtResultado.Rows(0)("Resultado").ToString)
            End If
        End If

        Return resultado
    End Function

    Public Function ConsultarPerfilSistemas() As Boolean
        Dim resultado As Boolean = False
        Dim dtResultado As New DataTable

        dtResultado = objDA.ConsultarPerfilSistemas()
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = CBool(dtResultado.Rows(0)("RESULTADO").ToString)
            End If
        End If

        Return resultado
    End Function

    Public Function ObtenerIdComprobanteCFD(ByVal idDocumento As Integer) As Integer
        Dim resultado As Integer = 0
        Dim dtResultado As New DataTable

        dtResultado = objDA.ObtenerIdComprobanteCFD(idDocumento)
        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            resultado = CInt(dtResultado.Rows(0)("idcomprobante").ToString)
        End If

        Return resultado
    End Function

    Public Function existeTimbradoComplemento(ByVal DocumentoId As Integer, ByVal TipoComprobante As String) As Boolean
        Dim blnReturn As Boolean = False
        Dim dtResultado As New DataTable

        Try
            dtResultado = objDA.existeTimbradoComplemento(DocumentoId, TipoComprobante)
            If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
                blnReturn = True
            End If
        Catch ex As Exception
            blnReturn = False
        End Try

        Return blnReturn
    End Function

    Public Function actualizaNombreDocumento(ByVal DocumentoId As Integer, ByVal TipoComprobante As String, ByVal TipoDocumento As String) As String
        Dim resultado As String = String.Empty
        Dim dtResultado As New DataTable

        dtResultado = objDA.actualizaNombreDocumento(DocumentoId, TipoComprobante, TipoDocumento)
        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function
End Class
