Imports System.Globalization
Imports ToolServicios
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath


Public Class TimbradoFacturasBU

    Private Property _Aviso As String
    Dim TimbradoPrueba As Boolean = True
    Dim EmpresaPruebaID As Integer = 0
    Dim RFCPrueba As String = String.Empty

    Sub New()
        'Verificar si es un timbrado de Prueba
        If _GlobalTimbradoPrueba = True Then
            TimbradoPrueba = True
            EmpresaPruebaID = _GlobalEmpresaPrueba
            RFCPrueba = _GlobalRFCPrueba
        Else
            TimbradoPrueba = False
            EmpresaPruebaID = 0
            RFCPrueba = String.Empty
        End If
    End Sub

    ''' <summary>
    ''' Timbra la Factura 
    ''' </summary>
    ''' <param name="DocumentoID">Documento ID de la factura</param>
    ''' <param name="EmpresaId">EmpresaID con la cual se va a facturar</param>
    ''' <returns>True si la factura se timbro correctamente, False= si la no se timbro la factura.</returns>
    ''' <remarks></remarks>
    Public Function TimbrarFactura(ByVal DocumentoID As Integer, ByVal EmpresaId As Integer, ByVal TipoComprobante As String) As Boolean
        Dim Resultado As Boolean = False
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = My.Settings.ServidorRestPruebasPruebas
        Dim dtResultado As DataTable
        Dim RutaREst As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU

        Try
            If TimbradoPrueba = True Then
                EmpresaId = EmpresaPruebaID
            End If

            llamarServicio.url = Servidor & "Facturas/Timbrado?DocumentoID=" & DocumentoID.ToString & "&EmpresaID=" & EmpresaId & "&TipoComprobante=" & TipoComprobante.Trim() & "&TimbradoPrueba=" & TimbradoPrueba.ToString()            
            llamarServicio.metodo = "GET"
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

            _Aviso = Respuesta.aviso
            If Respuesta.respuesta = 1 Then
                Resultado = True

                RutaREst = Respuesta.mensaje(0)
                RutaServidorSICY = Respuesta.mensaje(1)
                RutaCliente = Respuesta.mensaje(2)
                objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaCliente))
                objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaServidorSICY))
                objUtilerias.CopiarArchivoSICY(RutaREst, RutaServidorSICY, RutaCliente)
                Facturacion.Negocios.TimbradoBU.ActualizarRutaXMLFactura(DocumentoID, RutaREst, TipoComprobante, RutaServidorSICY)

            Else
                Resultado = False
            End If
        Catch ex As Exception
            'Manejar errror en el proceso de las capas
            'MsgBox(ex.Message)
            _Aviso = ex.Message
            Resultado = False
        Finally
            llamarServicio = Nothing
            dtResultado = Nothing
        End Try
        Return Resultado
    End Function


    ''' <summary>
    ''' Genera el PDF de la Factura 
    ''' </summary>
    ''' <param name="DocumentoID">Documento a  Timbrar.</param>
    ''' <remarks></remarks>
    Public Function GenerarPDFFactura(ByVal DocumentoID As Integer, ByVal TipoComprobante As String) As Boolean
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = My.Settings.ServidorRestPruebasPruebas
        Dim dtResultado As DataTable
        Dim Resultado As Boolean = False
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        Dim RutaCliente As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaRest As String = String.Empty
        Dim EmpresaId As Integer = 0
        Dim RutaLogoEmpresa As String = String.Empty


        Try

            EmpresaId = ObtenerEmpresaFactura(DocumentoID)
            RutaLogoEmpresa = ObtenerRutaLogoEmpresa(EmpresaId)

            llamarServicio.url = Servidor & "Facturas/GeneraPDF?DocumentoID=" & DocumentoID.ToString & "&TipoComprobante=" & TipoComprobante.ToString
            llamarServicio.metodo = "GET"
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

            _Aviso = Respuesta.aviso
            If Respuesta.respuesta = 1 Then
                Resultado = True
                RutaRest = Respuesta.mensaje(0)
                RutaServidorSICY = Respuesta.mensaje(1)
                RutaCliente = Respuesta.mensaje(2)
                objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaCliente))
                objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaServidorSICY))
                'objUtilerias.CopiarArchivoSICY(RutaRest, RutaServidorSICY, RutaCliente)

                Facturacion.Negocios.TimbradoBU.ActualizarRutaPDFFactura(DocumentoID, RutaRest, TipoComprobante, RutaServidorSICY)

            Else
                Resultado = False
            End If

        Catch ex As Exception
            'Manejar errror en el proceso de las capas
            'MsgBox(ex.Message)
            _Aviso = ex.Message
            Resultado = False
        Finally
            llamarServicio = Nothing
            dtResultado = Nothing
        End Try

        Return Resultado

    End Function

    ''' <summary>
    ''' Consulta Ruta PDF del documento
    ''' </summary>
    ''' <param name="DocumentoID">DocumentoID</param>
    ''' <returns>La Ruta completa del PDF en el servidor 2.2</returns>
    ''' <remarks></remarks>
    Public Function ConsultarRutaPDFFactura(ByVal DocumentoID As String) As String
        Dim objDA As New Ventas.Datos.TimbradoFacturasDA
        Dim dtinformacion As DataTable
        Dim RutaPDF As String = String.Empty

        Try
            dtinformacion = objDA.ConsultarRutaPDFFactura(DocumentoID)
            If dtinformacion.Rows.Count > 0 Then
                RutaPDF = dtinformacion.Rows(0).Item(0)
            Else
                RutaPDF = String.Empty
            End If

        Catch ex As Exception
            Throw ex
            RutaPDF = String.Empty
        End Try
        
        Return RutaPDF
    End Function

    Public Function ObtenerRutaPDFFactura(ByVal DocumentoID As String) As String
        Dim objDA As New Ventas.Datos.TimbradoFacturasDA
        Dim dtInformacionPDF As DataTable
        Dim RutaPDF As String = String.Empty
        dtInformacionPDF = objDA.ObtenerRutaPDFFactura(DocumentoID)

        If dtInformacionPDF.Rows.Count > 0 Then
            RutaPDF = dtInformacionPDF.Rows(0).Item(0)
        Else
            RutaPDF = String.Empty
        End If
        Return RutaPDF
    End Function

    ''' <summary>
    ''' Obtiene la Ruta del archivo XML del documento
    ''' </summary>
    ''' <param name="DocumentoID">DocumentoID de la factura</param>
    ''' <returns>La Ruta completa del XML en el servidor 2.2</returns>
    ''' <remarks></remarks>
    Public Function ObtenerRutaXMLFactura(ByVal DocumentoID As String) As String
        Dim objDA As New Ventas.Datos.TimbradoFacturasDA
        Dim dtInformacionXML As DataTable
        Dim RutaXML As String = String.Empty
        dtInformacionXML = objDA.ObtenerRutaXMLFactura(DocumentoID)

        If dtInformacionXML.Rows.Count > 0 Then
            RutaXML = dtInformacionXML.Rows(0).Item(0)
        Else
            RutaXML = String.Empty
        End If
        Return RutaXML
    End Function

    ''' <summary>
    ''' Cancela la factura
    ''' </summary>
    ''' <param name="DocumentoID">Documento de la factura</param>
    ''' <param name="EmpresaId">EmpresaID relacionada a la factura</param>    
    ''' <param name="TipoComprobante">FACTURACALZADO</param>
    ''' <returns>True => Si la factura se cancelo correctamente, False => Si la factura no se pudo cancelar.</returns>
    ''' <remarks></remarks>
    Public Function CancelarFactura(ByVal DocumentoID As Integer, ByVal UUID As String, ByVal EmpresaId As Integer, ByVal TipoComprobante As String, ByVal UsuarioID As Integer) As Boolean
        Dim Resultado As Boolean = False
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = My.Settings.ServidorRestPruebasPruebas
        Dim dtResultado As DataTable
        Dim RutaREst As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU

        Try
            If TimbradoPrueba = True Then
                EmpresaId = EmpresaPruebaID
            End If

            llamarServicio.url = Servidor & "Facturas/CancelacionFactura?DocumentoID=" & DocumentoID.ToString & "&UUID=" & UUID.Trim & "&EmpresaID=" & EmpresaId.ToString() & "&TipoComprobante=" & TipoComprobante.Trim() & "&TimbradoPrueba=" & TimbradoPrueba.ToString() & "&UsuarioID=" & UsuarioID.ToString()
            llamarServicio.metodo = "GET"
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

            _Aviso = Respuesta.aviso
            If Respuesta.respuesta = 1 Then
                Resultado = True
                RutaREst = Respuesta.mensaje(0)
                RutaServidorSICY = Respuesta.mensaje(1)
                RutaCliente = Respuesta.mensaje(2)
                objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaCliente))
                objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaServidorSICY))
                objUtilerias.CopiarArchivoSICY(RutaREst, RutaServidorSICY, RutaCliente)
                Facturacion.Negocios.TimbradoBU.ActualizarRutaXMLFactura(DocumentoID, RutaREst, TipoComprobante, RutaServidorSICY)
            Else
                Resultado = False
            End If
        Catch ex As Exception
            'Manejar errror en el proceso de las capas
            'MsgBox(ex.Message)
            _Aviso = ex.Message
            Resultado = False
        Finally
            llamarServicio = Nothing
            dtResultado = Nothing
        End Try
        Return Resultado
    End Function

    ''' <summary>
    ''' Genera el PDF de cancelacion del documento.
    ''' </summary>
    ''' <param name="DocumentoID">DocumentoID</param>
    ''' <param name="TipoComprobante">FACTURACALZADO</param>
    ''' <returns>True => Si el PDF se Genero Correctamente, False => Si Ocurrio un error al generar el PDF.</returns>
    ''' <remarks></remarks>
    Public Function GenerarPDFFacturaCancelada(ByVal DocumentoID As Integer, ByVal TipoComprobante As String) As Boolean
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = My.Settings.ServidorRestPruebasPruebas
        Dim dtResultado As DataTable
        Dim Resultado As Boolean = False
        Dim RutaREst As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU

        Try
            llamarServicio.url = Servidor & "Facturas/GeneraPDFFacturaCancelada?DocumentoID=" & DocumentoID.ToString & "&TipoComprobante=" & TipoComprobante.Trim()            
            llamarServicio.metodo = "GET"
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

            _Aviso = Respuesta.aviso
            If Respuesta.respuesta = 1 Then
                Resultado = True
                RutaREst = Respuesta.mensaje(0)
                RutaServidorSICY = Respuesta.mensaje(1)
                RutaCliente = Respuesta.mensaje(2)
                objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaCliente))
                objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaServidorSICY))
                'objUtilerias.CopiarArchivoSICY(RutaREst, RutaServidorSICY, RutaCliente)
                Facturacion.Negocios.TimbradoBU.ActualizarRutaXMLFactura(DocumentoID, RutaREst, TipoComprobante, RutaServidorSICY)
            Else
                Resultado = False
            End If
        Catch ex As Exception
            'Manejar errror en el proceso de las capas
            'MsgBox(ex.Message)
            _Aviso = ex.Message
            Resultado = False
        Finally
            llamarServicio = Nothing
            dtResultado = Nothing
        End Try

        Return Resultado

    End Function

    Public Sub GenerarAddendaCOPPEL(ByVal DocumentoID As Integer, ByVal TipoComprobante As String)

        Dim doc As New XmlDocument()
        Dim objBU As New Negocios.VistaPreviaDocumentosBU
        Dim objBUTimbrado As New Negocios.TimbradoFacturasBU
        Dim RutaXML As String = String.Empty
        RutaXML = objBUTimbrado.ObtenerRutaXMLFactura(DocumentoID)
        doc.Load(RutaXML)
        Dim xmlmanager As System.Xml.XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)
        xmlmanager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
        xmlmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
        Dim Fila As Integer = 0
        Dim nodo As XmlNode = doc.SelectSingleNode("/cfdi:Comprobante", xmlmanager)
        Dim item As XmlElement = doc.CreateElement("cfdi:Addenda", xmlmanager.LookupNamespace("cfdi"))
        Dim ListaItems As New List(Of Entidades.AddendaDetalles)
        Dim objAddendaEnc As New Entidades.Addenda
        Dim FechaVacia As Date = Nothing

        ListaItems = objBU.ObtenerDetalleAddenda(DocumentoID)
        objAddendaEnc = objBU.ConsultarEncabezadoAddendaCOPPEL(DocumentoID)

        Dim requestForPayment As XmlElement = doc.CreateElement("requestForPayment")
        requestForPayment.SetAttribute("type", "SimpleInvoiceType")
        requestForPayment.SetAttribute("contentVersion", "1.0")
        requestForPayment.SetAttribute("documentStructureVersion", "CPLR1.0")
        requestForPayment.SetAttribute("documentStatus", "ORIGINAL")

        Dim MesDocumento As String = ""
        Dim DiaDocumento As String = ""

        If objAddendaEnc.FechaCaptura = FechaVacia Then
            requestForPayment.SetAttribute("DeliveryDate", "------") 'Modifcar
        Else
            If Month(objAddendaEnc.FechaCaptura) <= 9 Then
                MesDocumento = "0" + Month(objAddendaEnc.FechaCaptura).ToString()
            Else
                MesDocumento = Month(objAddendaEnc.FechaCaptura).ToString()
            End If

            If objAddendaEnc.FechaCaptura.Day <= 9 Then
                DiaDocumento = "0" + objAddendaEnc.FechaCaptura.Day.ToString()
            Else
                DiaDocumento = objAddendaEnc.FechaCaptura.Day.ToString()
            End If
            requestForPayment.SetAttribute("DeliveryDate", Year(objAddendaEnc.FechaCaptura).ToString + MesDocumento + DiaDocumento) 'Modifcar
        End If



        Dim requestForPaymentIdentification As XmlElement = doc.CreateElement("requestForPaymentIdentification")
        Dim entityType As XmlElement = doc.CreateElement("entityType")
        entityType.InnerText = "INVOICE"
        Dim uniqueCreatorIdentification As XmlElement = doc.CreateElement("uniqueCreatorIdentification")
        uniqueCreatorIdentification.InnerText = objAddendaEnc.SerieFactura.ToString() + objAddendaEnc.FolioFactura.ToString()

        requestForPaymentIdentification.AppendChild(entityType)
        requestForPaymentIdentification.AppendChild(uniqueCreatorIdentification)

        requestForPayment.AppendChild(requestForPaymentIdentification)

        Dim specialInstruction As XmlElement = doc.CreateElement("specialInstruction")
        specialInstruction.SetAttribute("code", "ZZZ")

        Dim text As XmlElement = doc.CreateElement("text")
        text.InnerText = objAddendaEnc.MontoTotalLetra.Trim()

        specialInstruction.AppendChild(text)
        requestForPayment.AppendChild(specialInstruction)


        Dim orderIdentification As XmlElement = doc.CreateElement("orderIdentification")

        Dim referenceIdentification As XmlElement = doc.CreateElement("referenceIdentification")
        referenceIdentification.SetAttribute("type", "ON")
        referenceIdentification.InnerText = objAddendaEnc.OrdenCompra.ToString()

        orderIdentification.AppendChild(referenceIdentification)
        requestForPayment.AppendChild(orderIdentification)

        Dim AdditionalInformation As XmlElement = doc.CreateElement("AdditionalInformation")

        Dim AdditionalreferenceIdentification As XmlElement = doc.CreateElement("referenceIdentification")
        AdditionalreferenceIdentification.SetAttribute("type", "ON")
        AdditionalreferenceIdentification.InnerText = objAddendaEnc.OrdenCompra


        AdditionalInformation.AppendChild(AdditionalreferenceIdentification)
        requestForPayment.AppendChild(AdditionalInformation)

        Dim buyer As XmlElement = doc.CreateElement("buyer")
        Dim gln As XmlElement = doc.CreateElement("gln")
        gln.InnerText = "7504004086006"

        buyer.AppendChild(gln)
        requestForPayment.AppendChild(buyer)

        Dim seller As XmlElement = doc.CreateElement("seller")
        Dim sellergln As XmlElement = doc.CreateElement("gln")
        sellergln.InnerText = "7501234567890"
        Dim selleralternatePartyIdentification As XmlElement = doc.CreateElement("alternatePartyIdentification")
        selleralternatePartyIdentification.SetAttribute("type", "SELLER_ASSIGNED_IDENTIFIER_FOR_A_PARTY")
        selleralternatePartyIdentification.InnerText = "38679"

        Dim sellerIndentificaTipoProv As XmlElement = doc.CreateElement("IndentificaTipoProv")
        sellerIndentificaTipoProv.InnerText = "2"

        seller.AppendChild(sellergln)
        seller.AppendChild(selleralternatePartyIdentification)
        seller.AppendChild(sellerIndentificaTipoProv)

        requestForPayment.AppendChild(seller)

        Dim shipTo As XmlElement = doc.CreateElement("shipTo")
        Dim shipTogln As XmlElement = doc.CreateElement("gln")
        shipTogln.InnerText = "0"

        Dim shipTonameAndAddress As XmlElement = doc.CreateElement("nameAndAddress")
        Dim shipToname As XmlElement = doc.CreateElement("name")
        Dim shipTostreetAddressOne As XmlElement = doc.CreateElement("streetAddressOne")
        Dim shipTostreetcity As XmlElement = doc.CreateElement("city")
        Dim shipTopostalCode As XmlElement = doc.CreateElement("postalCode")
        Dim shipTobodegaEnt As XmlElement = doc.CreateElement("bodegaEnt")
        shipTobodegaEnt.InnerText = objAddendaEnc.CodigoTienda.ToString()

        shipTonameAndAddress.AppendChild(shipToname)
        shipTonameAndAddress.AppendChild(shipTostreetAddressOne)
        shipTonameAndAddress.AppendChild(shipTostreetcity)
        shipTonameAndAddress.AppendChild(shipTopostalCode)
        shipTonameAndAddress.AppendChild(shipTobodegaEnt)

        shipTo.AppendChild(shipTogln)
        shipTo.AppendChild(shipTonameAndAddress)
        requestForPayment.AppendChild(shipTo)

        Dim currency As XmlElement = doc.CreateElement("currency")
        currency.SetAttribute("currencyISOCode", "MXN")

        Dim currencyFunction As XmlElement = doc.CreateElement("currencyFunction")
        currencyFunction.InnerText = "PAYMENT_CURRENCY"
        Dim rateOfChange As XmlElement = doc.CreateElement("rateOfChange")
        rateOfChange.InnerText = objAddendaEnc.NumeroCajas.ToString()

        currency.AppendChild(currencyFunction)
        currency.AppendChild(rateOfChange)
        requestForPayment.AppendChild(currency)

        Dim TotalLotes As XmlElement = doc.CreateElement("TotalLotes")
        Dim TotalLotescantidad As XmlElement = doc.CreateElement("cantidad")
        TotalLotescantidad.InnerText = objAddendaEnc.NumeroCajas.ToString()

        TotalLotes.AppendChild(TotalLotescantidad)
        requestForPayment.AppendChild(TotalLotes)

        For Each ItemAddenda As Entidades.AddendaDetalles In ListaItems
            Fila += 1
            Dim lineItem As XmlElement = doc.CreateElement("lineItem")
            lineItem.SetAttribute("type", "SimpleInvoiceLineItemType")
            lineItem.SetAttribute("number", Fila.ToString())

            Dim tItemIdentificador As XmlElement = doc.CreateElement("tradeItemIdentification")
            Dim tItemIdentificadorgtin As XmlElement = doc.CreateElement("gtin")
            'tItemIdentificadorgtin.InnerText = ""

            tItemIdentificador.AppendChild(tItemIdentificadorgtin)
            lineItem.AppendChild(tItemIdentificador)

            Dim alternateTradeItemIdentification As XmlElement = doc.CreateElement("alternateTradeItemIdentification")
            alternateTradeItemIdentification.SetAttribute("type", "BUYER_ASSIGNED")
            lineItem.AppendChild(alternateTradeItemIdentification)

            Dim codigoTallaInternoCop As XmlElement = doc.CreateElement("codigoTallaInternoCop")
            Dim codigo As XmlElement = doc.CreateElement("codigo")
            codigo.InnerText = ItemAddenda.SKU
            Dim talla As XmlElement = doc.CreateElement("talla")
            talla.InnerText = ItemAddenda.FormatoTalla
            codigoTallaInternoCop.AppendChild(codigo)
            codigoTallaInternoCop.AppendChild(talla)

            lineItem.AppendChild(codigoTallaInternoCop)

            Dim tradeItemDescriptionInformation As XmlElement = doc.CreateElement("tradeItemDescriptionInformation")
            Dim longText As XmlElement = doc.CreateElement("longText")
            longText.InnerText = ItemAddenda.DescripcionCte.Trim()
            tradeItemDescriptionInformation.AppendChild(longText)
            lineItem.AppendChild(tradeItemDescriptionInformation)

            Dim invoicedQuantity As XmlElement = doc.CreateElement("invoicedQuantity")
            invoicedQuantity.SetAttribute("unitOfMeasure", "CA")
            invoicedQuantity.InnerText = ItemAddenda.CantidadPares.ToString()
            lineItem.AppendChild(invoicedQuantity)

            Dim grossPrice As XmlElement = doc.CreateElement("grossPrice")
            Dim grossPriceAmount As XmlElement = doc.CreateElement("Amount")
            grossPriceAmount.InnerText = ItemAddenda.PrecioBruto.ToString()
            grossPrice.AppendChild(grossPriceAmount)
            lineItem.AppendChild(grossPrice)

            Dim netPrice As XmlElement = doc.CreateElement("netPrice")
            Dim netPriceAmount As XmlElement = doc.CreateElement("Amount")
            netPriceAmount.InnerText = ItemAddenda.PrecioNeto.ToString()
            netPrice.AppendChild(netPriceAmount)
            lineItem.AppendChild(netPrice)

            Dim tradeItemTaxInformation As XmlElement = doc.CreateElement("tradeItemTaxInformation")
            Dim taxTypeDescription As XmlElement = doc.CreateElement("taxTypeDescription")
            taxTypeDescription.InnerText = "VAT"
            tradeItemTaxInformation.AppendChild(taxTypeDescription)

            Dim tradeItemTaxAmount As XmlElement = doc.CreateElement("tradeItemTaxAmount")
            Dim taxPercentage As XmlElement = doc.CreateElement("taxPercentage")
            taxPercentage.InnerText = ItemAddenda.PorcentajeIVA
            Dim taxAmount As XmlElement = doc.CreateElement("taxAmount")
            taxAmount.InnerText = ItemAddenda.MontoIVA 'Porcentaje IVA
            tradeItemTaxAmount.AppendChild(taxPercentage)
            tradeItemTaxAmount.AppendChild(taxAmount)
            tradeItemTaxInformation.AppendChild(tradeItemTaxAmount)
            lineItem.AppendChild(tradeItemTaxInformation)


            Dim palletInformation As XmlElement = doc.CreateElement("palletInformation")
            Dim palletInformationdescription As XmlElement = doc.CreateElement("description")
            palletInformationdescription.SetAttribute("type", "BOX")
            palletInformationdescription.InnerText = "EMPAQUETADO"
            Dim transport As XmlElement = doc.CreateElement("transport")
            Dim methodOfPayment As XmlElement = doc.CreateElement("methodOfPayment")
            methodOfPayment.InnerText = "PAID_BY_BUYER"
            Dim prepactCant As XmlElement = doc.CreateElement("prepactCant")
            prepactCant.InnerText = ItemAddenda.CantidadEmpacado.ToString()
            transport.AppendChild(methodOfPayment)
            transport.AppendChild(prepactCant)
            palletInformation.AppendChild(palletInformationdescription)
            palletInformation.AppendChild(transport)

            lineItem.AppendChild(palletInformation)

            Dim allowanceCharge As XmlElement = doc.CreateElement("allowanceCharge")
            allowanceCharge.SetAttribute("allowanceChargeType", "ALLOWANCE_GLOBAL")

            Dim specialServicesType As XmlElement = doc.CreateElement("specialServicesType")
            specialServicesType.InnerText = "EAB"
            allowanceCharge.AppendChild(specialServicesType)

            Dim monetaryAmountOrPercentage As XmlElement = doc.CreateElement("monetaryAmountOrPercentage")

            Dim percentagePerUnit As XmlElement = doc.CreateElement("percentagePerUnit")
            percentagePerUnit.InnerText = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", ItemAddenda.PorcentajeDescuento.ToString) 'ItemAddenda.PorcentajeDescuento.ToString

            monetaryAmountOrPercentage.AppendChild(percentagePerUnit)

            Dim ratePerUnit As XmlElement = doc.CreateElement("ratePerUnit")
            Dim amountPerUnit As XmlElement = doc.CreateElement("amountPerUnit")
            amountPerUnit.InnerText = ItemAddenda.Descuento.ToString

            ratePerUnit.AppendChild(amountPerUnit)
            monetaryAmountOrPercentage.AppendChild(ratePerUnit)
            allowanceCharge.AppendChild(monetaryAmountOrPercentage)
            lineItem.AppendChild(allowanceCharge)

            Dim totalLineAmount As XmlElement = doc.CreateElement("totalLineAmount")
            Dim grossAmount As XmlElement = doc.CreateElement("grossAmount")
            Dim grossAmountAmount As XmlElement = doc.CreateElement("grossAmount")
            grossAmountAmount.InnerText = ItemAddenda.MontoBruto
            grossAmount.AppendChild(grossAmountAmount)
            Dim netAmount As XmlElement = doc.CreateElement("netAmount")
            Dim netAmountAmount As XmlElement = doc.CreateElement("Amount")
            netAmountAmount.InnerText = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", ItemAddenda.PrecioNeto * ItemAddenda.CantidadPares)
            netAmount.AppendChild(netAmountAmount)
            totalLineAmount.AppendChild(grossAmount)
            totalLineAmount.AppendChild(netAmount)

            lineItem.AppendChild(totalLineAmount)
            requestForPayment.AppendChild(lineItem)

        Next


        Dim totalAmount As XmlElement = doc.CreateElement("totalAmount")
        Dim Amount As XmlElement = doc.CreateElement("Amount")

        Amount.InnerText = objAddendaEnc.Importe.ToString
        totalAmount.AppendChild(Amount)
        requestForPayment.AppendChild(totalAmount)


        Dim TotalAllowanceCharge As XmlElement = doc.CreateElement("TotalAllowanceCharge")
        TotalAllowanceCharge.SetAttribute("allowanceOrChargeType", "ALLOWANCE")

        Dim PspecialServicesType As XmlElement = doc.CreateElement("specialServicesType")
        PspecialServicesType.InnerText = "EAB"

        Dim TotalAllowanceChargeAmount As XmlElement = doc.CreateElement("Amount")
        TotalAllowanceChargeAmount.InnerText = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", objAddendaEnc.Descuento)

        TotalAllowanceCharge.AppendChild(PspecialServicesType)
        TotalAllowanceCharge.AppendChild(TotalAllowanceChargeAmount)
        requestForPayment.AppendChild(TotalAllowanceCharge)

        Dim baseAmount As XmlElement = doc.CreateElement("baseAmount")
        Dim baseAmountAmount As XmlElement = doc.CreateElement("Amount")
        baseAmountAmount.InnerText = objAddendaEnc.Importe.ToString()

        baseAmount.AppendChild(baseAmountAmount)
        requestForPayment.AppendChild(baseAmount)

        Dim tax As XmlElement = doc.CreateElement("tax")
        tax.SetAttribute("type", "VAT")

        Dim PtaxPercentage As XmlElement = doc.CreateElement("taxPercentage")
        PtaxPercentage.InnerText = "16.00"

        Dim PtaxAmount As XmlElement = doc.CreateElement("taxAmount")
        PtaxAmount.InnerText = objAddendaEnc.TotalIVA.ToString()

        tax.AppendChild(PtaxPercentage)
        tax.AppendChild(PtaxAmount)
        requestForPayment.AppendChild(tax)

        Dim payableAmount As XmlElement = doc.CreateElement("payableAmount")
        Dim payableAmountAmount As XmlElement = doc.CreateElement("Amount")
        payableAmountAmount.InnerText = objAddendaEnc.MontoTotal.ToString()
        payableAmount.AppendChild(payableAmountAmount)
        requestForPayment.AppendChild(payableAmount)

        item.AppendChild(requestForPayment)
        nodo.AppendChild(item)
        doc.Save(RutaXML)
        'doc.Save("C:\Arc_Sync\addendaPrueba_" & DocumentoID.ToString() & "_v2.xml")

    End Sub


    Public Function ObtenerRutaLogoEmpresa(ByVal EmpresaID As Integer) As String
        Dim objDa As New Datos.TimbradoFacturasDA
        Dim dtinformacion As New DataTable
        Dim RutaLogo As String = String.Empty

        dtinformacion = objDa.ObtenerRutaLogoEmpresa(EmpresaID)

        If dtinformacion.Rows.Count > 0 Then
            RutaLogo = dtinformacion.Rows(0).Item("LogoEmpresa")
        Else
            RutaLogo = String.Empty
        End If

        Return RutaLogo
    End Function


    Public Function ObtenerEmpresaFactura(ByVal DocumentoID As Integer) As Integer
        Dim objDa As New Datos.TimbradoFacturasDA
        Dim dtinformacion As New DataTable
        Dim EmpresaID As Integer = 0

        dtinformacion = objDa.ObtenerEmpresaFactura(DocumentoID)

        If dtinformacion.Rows.Count > 0 Then
            EmpresaID = dtinformacion.Rows(0).Item("EmpresaID")
        Else
            EmpresaID = 0
        End If

        Return EmpresaID
    End Function

End Class
