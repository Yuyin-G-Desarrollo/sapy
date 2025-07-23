Public Class RegistrarInventarioSAPBU
    Public Sub LimpiarTablaTemporalSAP()
        Dim objPDA As New Ventas.Datos.InventarioSAPDA
        objPDA.LimpiarTablaTemporal()
    End Sub
    Public Sub LimpiarTablaTemporalClientesSAP()
        Dim objPDA As New Ventas.Datos.InventarioSAPDA
        objPDA.LimpiarTablaTemporalClientesSAP()
    End Sub
    Public Function ObtenerArticulosFaltantesSAP(razonSocial As Int16, fechaFacturasInicio As Date, fechaFacturasFin As Date, ByVal facturasIds As String) As DataTable
        Dim objPDA As New Ventas.Datos.InventarioSAPDA
        Return objPDA.ObtenerArticulosFaltantesSap(razonSocial, fechaFacturasInicio, fechaFacturasFin, facturasIds)
    End Function

    Public Function obtenerClientesFaltantesSAP(razonSocial As Int16, fechaFacturasInicio As Date, fechaFacturasFin As Date) As DataTable
        Dim objPDA As New Ventas.Datos.InventarioSAPDA
        Return objPDA.obtenerCantidadesClientesFaltantesSAP(razonSocial, fechaFacturasInicio, fechaFacturasFin)
    End Function
    Public Function ObtenerArticulosCantidadesSAP(razonsocial As Int16, fechaFacturasInicio As Date, fechaFacturasFin As Date, ByVal facturasIds As String) As DataTable
        Dim objPDA As New Ventas.Datos.InventarioSAPDA
        Return objPDA.ObtenerCantidadesSap(razonsocial, fechaFacturasInicio, fechaFacturasFin, facturasIds)
    End Function
    Public Sub RegistrarInventarioSAP(dtDatosMostarImportados As DataTable)
        Dim objPDA As New Ventas.Datos.InventarioSAPDA
        objPDA.RegistrarInventarioSAP(dtDatosMostarImportados)
    End Sub
    Public Sub RegistrarInventarioClientesSAP(dtDatosMostrarImportadosClientesSAP As DataTable)
        Dim objPDA As New Ventas.Datos.InventarioSAPDA
        objPDA.RegistrarInventarioClientesSAP(dtDatosMostrarImportadosClientesSAP)
    End Sub
    Public Function ObtenerArticulosFaltantesSapEntradas(razonSocial As Int16, fechaFacturasInicio As Date, fechaFacturasFin As Date) As DataTable
        Dim objPDA As New Ventas.Datos.InventarioSAPDA
        Return objPDA.ObtenerArticulosFaltantesSapEntradas(razonSocial, fechaFacturasInicio, fechaFacturasFin)
    End Function
    Public Function ConsultarDocumentosFaltantesSAP(ByVal Documentos As String, ByVal FechaInicioSAP As Date, ByVal FechaFinalSAP As Date, ByVal razonSocial As Integer, ByVal facturasIds As String) As DataTable
        Dim ObjDa As New Datos.InventarioSAPDA
        Return ObjDa.ObtenerDocumentosDetallesArticulosFaltantesSAP(Documentos, FechaInicioSAP, FechaFinalSAP, razonSocial, facturasIds)
    End Function
    Public Function ConsultarResumenComplementosSAP(razonSocial As Int16, fechaFacturasInicio As Date, fechaFacturasFin As Date, ByVal facturasIds As String) As DataTable
        Dim objConsulta As New Datos.InventarioSAPDA
        Return objConsulta.ConsultarResumenComplementosFacturarSAP(razonSocial, fechaFacturasInicio, fechaFacturasFin, facturasIds)
    End Function

    Public Function insertarFacturarComplementosPT_SAP(ByVal fechaInicio As Date, ByVal fechaFinal As Date, ByVal razonsocialId As Integer, ByVal pruebas As Boolean, ByVal facturasIds As String) As DataTable
        Dim objDA As New Datos.InventarioSAPDA
        Return objDA.InsertarFacturasComplementosSAP_PT(fechaInicio, fechaFinal, razonsocialId, pruebas, facturasIds)
    End Function
    Public Function GeneraInformacionTimbrar(ByVal documentoId As Integer) As String
        Dim objDA As New Datos.InventarioSAPDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDA.GeneraInformacionComplementosPT_SAP_Timbrar(documentoId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0).Item("mensaje").ToString()
            End If
        End If
        Return resultado
    End Function
    Public Function ActualizarInfoFacturaComplementosSAP_PT(ByVal idDocumento As Integer, ByVal sello As String,
                                                     ByVal uuid As String, ByVal fechaTimbrado As String,
                                                     ByVal versionSat As String, ByVal rfcProvCertif As String,
                                                     ByVal noCertificadoSAT As String, ByVal selloSAT As String,
                                                     ByVal cadenaOriginal As String, ByVal cadenaOriginalComplemento As String) As String

        Dim objDA As New Datos.InventarioSAPDA
        Dim resultado As String = String.Empty
        Dim dtResultado As New DataTable

        dtResultado = objDA.ActualizarInformacionFacturasComplementosSAP_PT(idDocumento, sello, uuid, fechaTimbrado, versionSat, rfcProvCertif, noCertificadoSAT, selloSAT, cadenaOriginal, cadenaOriginalComplemento)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0)("mensaje").ToString
            End If
        End If

        Return resultado
    End Function
    Public Function ObtenerIdComprobanteCFD(ByVal idDocumento As Integer) As Integer
        Dim resultado As Integer = 0
        Dim dtResultado As New DataTable
        Dim objDA As New Datos.InventarioSAPDA

        dtResultado = objDA.ObtenerIdComprobanteCFD(idDocumento)
        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            resultado = CInt(dtResultado.Rows(0)("idcomprobante").ToString)
        End If

        Return resultado
    End Function
    Public Function ObtenerInfoCXPSaldo(ByVal idDocumento As Integer) As DataTable
        Dim objDA As New Datos.InventarioSAPDA
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
        Dim objDA As New Datos.InventarioSAPDA

        dtResultado = objDA.InsertarCXPSaldo(tipoDoc, idProveedor, numDoc, fechaDoc, fechaVencimiento, semanaPago, semanaPagada, subTotal, iva, total, totalDoc, moneda, nave, añoSemPago, rfcContribuyente, rfcProveedor, giro, idcomprobantesicy)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0)(0).ToString
            End If
        End If

        Return resultado
    End Function
    Public Function ConsultarArticulosFacturados(ByVal razonSocialId As Integer, ByVal fechaInicio As Date, ByVal fechaFinal As Date) As DataTable
        Dim objConsultarDA As New Ventas.Datos.InventarioSAPDA
        Return objConsultarDA.ConsultarArticulosSAPFacturados(razonSocialId, fechaInicio, fechaFinal)
    End Function

End Class
