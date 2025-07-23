Imports System.Globalization
Imports ToolServicios
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports Stimulsoft.Report
Imports System.Net

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
        Dim Servidor As String = My.Settings.ServidorRest
        Dim dtResultado As DataTable
        Dim RutaREst As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        Dim entFactura As New Entidades.DatosFactura
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
                'Actualizar rutas de documento en SICY
                entFactura = ConsultarRutasDocumento(DocumentoID)
                ActualizarRutaDocumentoSICY(entFactura.RemisionID, entFactura.Año, entFactura.RutaXML, entFactura.RutaPDF)


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
        Dim Servidor As String = My.Settings.ServidorRest
        Dim dtResultado As DataTable
        Dim Resultado As Boolean = False
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        Dim RutaCliente As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaRest As String = String.Empty
        Dim EmpresaId As Integer = 0
        Dim RutaLogoEmpresa As String = String.Empty
        Dim EntFactura As New Entidades.DatosFactura

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


                objUtilerias.CopiarArchivoSICY(RutaRest, RutaServidorSICY, RutaCliente)
                Facturacion.Negocios.TimbradoBU.ActualizarRutaPDFFactura(DocumentoID, RutaRest, TipoComprobante, RutaServidorSICY)
                'Actualizar rutas de documento en SICY
                EntFactura = ConsultarRutasDocumento(DocumentoID)
                ActualizarRutaDocumentoSICY(EntFactura.RemisionID, EntFactura.Año, EntFactura.RutaXML, EntFactura.RutaPDF)

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
        Dim objDA As New Datos.TimbradoFacturasDA
        Dim dtinformacion As DataTable
        Dim RutaPDF As String = String.Empty

        Try
            dtinformacion = objDA.ConsultarRutaPDFFactura(DocumentoID, "FACTURACALZADO")
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
        Dim objDA As New Datos.TimbradoFacturasDA
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
        Dim objDA As New Datos.TimbradoFacturasDA
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
        Dim Servidor As String = My.Settings.ServidorRest
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
    ''' Cancela la factura de una solicitud
    ''' </summary>
    ''' <param name="DocumentoID">Documento de la factura</param>
    ''' <param name="EmpresaId">EmpresaID relacionada a la factura</param>    
    ''' <param name="TipoComprobante">FACTURACALZADO</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CancelarFacturaSolicitud4_0(ByVal DocumentoID As Integer, ByVal UUID As String, ByVal EmpresaId As Integer, ByVal TipoComprobante As String, ByVal UsuarioID As Integer, ByVal MotivoID As String, Optional ByVal FolioSustitucion As String = "") As DataTable
        'Dim Resultado As Boolean = False
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = My.Settings.ServidorRest
        Dim dtResultado As DataTable
        Dim RutaREst As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU



        Dim dtrespuesta As New DataTable
        dtrespuesta.Columns.Add("Resultado")
        dtrespuesta.Columns.Add("Mensaje")
        Dim Renglon As DataRow = dtrespuesta.NewRow()

        'Servidor = "http://192.168.2.4:8037/"

        'Servidor = "http://localhost:7639/"

        Servidor = "http://192.168.2.4:8033/"

        Try
            If TimbradoPrueba = True Then
                EmpresaId = EmpresaPruebaID
            End If

            llamarServicio.url = Servidor & "Facturas/CancelacionFactura4_0?DocumentoId=" & DocumentoID.ToString & "&UUID=" & UUID.Trim & "&EmpresaID=" & EmpresaId.ToString() & "&TipoComprobante=" & TipoComprobante.Trim() & "&TimbradoPrueba=" & TimbradoPrueba.ToString() & "&UsuarioID=" & UsuarioID.ToString() & "&MotivoID=" & MotivoID.ToString() & "FolioSustitucion=" & FolioSustitucion.ToString()
            'llamarServicio.url = Servidor & "Facturas/CancelacionFactura4_0?DocumentoId=0" & "&UUID=" & UUID.Trim & "&EmpresaID=" & EmpresaId.ToString() & "&TipoComprobante=" & TipoComprobante.Trim() & "&TimbradoPrueba=" & TimbradoPrueba.ToString() & "&UsuarioID=" & UsuarioID.ToString() & "&MotivoID=" & MotivoID.ToString() & "FolioSustitucion=" & FolioSustitucion.ToString()

            llamarServicio.metodo = "GET"
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

            _Aviso = Respuesta.aviso
            If Respuesta.respuesta = 1 Then
                Renglon("Resultado") = 1
                Renglon("Mensaje") = Respuesta.aviso
                dtrespuesta.Rows.Add(Renglon)

                'Resultado = True
                RutaREst = Respuesta.mensaje(0)
                RutaServidorSICY = Respuesta.mensaje(1)
                RutaCliente = Respuesta.mensaje(2)
                objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaCliente))
                objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaServidorSICY))

                objUtilerias.CopiarArchivoSICY(RutaREst, RutaServidorSICY, RutaCliente)
                Facturacion.Negocios.TimbradoBU.ActualizarRutaXMLFactura(DocumentoID, RutaREst, TipoComprobante, RutaServidorSICY)
            Else
                Renglon("Resultado") = 0
                Renglon("Mensaje") = Respuesta.aviso
                dtrespuesta.Rows.Add(Renglon)

                'Resultado = False
            End If
        Catch ex As Exception
            'Manejar errror en el proceso de las capas
            'MsgBox(ex.Message)
            _Aviso = ex.Message
            'Resultado = False
            Renglon("Resultado") = 0
            Renglon("Mensaje") = ex.Message.ToString
            dtrespuesta.Rows.Add(Renglon)
        Finally
            llamarServicio = Nothing
            dtResultado = Nothing
        End Try
        Return dtrespuesta
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
        Dim Servidor As String = My.Settings.ServidorRest
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


                objUtilerias.CopiarArchivoSICY(RutaREst, RutaServidorSICY, RutaCliente)
                Facturacion.Negocios.TimbradoBU.ActualizarRutaPDFFactura(DocumentoID, RutaREst, TipoComprobante, RutaServidorSICY)
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
        Dim objBUTimbrado As New Negocios.TimbradoFacturasBU
        Dim RutaRestXML As String = String.Empty
        Dim myWebClient As New WebClient()
        Dim respuesta As New RespuestaRestArray()
        Dim ServidorRest As String = String.Empty
        Dim url As String = String.Empty
        Dim RutaXMLCliente As String = String.Empty
        Dim RutaXMLSICY As String = String.Empty

        ServidorRest = ObtenerRutaServidorRest()
        RutaRestXML = objBUTimbrado.ObtenerRutaXMLRESTFactura(DocumentoID)
        RutaXMLSICY = objBUTimbrado.ObtenerRutaXMLSICYFactura(DocumentoID)

        RutaXMLCliente = RutaRestXML
        url = Replace(RutaRestXML, "C:\inetpub\wwwroot\Facturacion33\", ServidorRest)

        CrearDirectorio(RutaXMLCliente)
        myWebClient.DownloadFile(url, RutaXMLCliente)
        CrearDirectorio(RutaRestXML)
        'File.Copy(RutaXMLCliente, RutaRestXML, True)


        doc.Load(RutaXMLCliente)
        Dim xmlmanager As System.Xml.XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)
        xmlmanager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
        xmlmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
        Dim Fila As Integer = 0
        Dim nodo As XmlNode = doc.SelectSingleNode("/cfdi:Comprobante", xmlmanager)
        Dim item As XmlElement = doc.CreateElement("cfdi:Addenda", xmlmanager.LookupNamespace("cfdi"))
        Dim ListaItems As New List(Of Entidades.AddendaDetalles)
        Dim objAddendaEnc As New Entidades.Addenda
        Dim FechaVacia As Date = Nothing

        ListaItems = objBUTimbrado.ObtenerDetalleAddenda(DocumentoID)
        objAddendaEnc = objBUTimbrado.ConsultarEncabezadoAddendaCOPPEL(DocumentoID)

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
        selleralternatePartyIdentification.InnerText = objAddendaEnc.ClaveProveedor

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
            longText.InnerText = ItemAddenda.Articulo.Trim()
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
        'doc.Save("C:\inetpub\wwwroot\Facturacion33\Facturas2.xml")
        doc.Save(RutaXMLSICY)
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

    Public Function ImprimirRemision(ByVal DocumentoID As Integer) As Boolean
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim objBU As New Negocios.TimbradoFacturasBU
        Dim dtRemision As New DataSet("dtRemision")
        Dim ReporteRemision As New StiReport
        Dim dtInformacionPares As New DataTable

        Dim entReporte As New Entidades.Reportes
        Dim dtInformacionParesAux As New DataTable
        Dim dtInformacionEncabezado As DataTable
        Dim Docenas As String = String.Empty
        Dim Pares As String = String.Empty
        Dim SubTotal As String = String.Empty
        Dim Descuento As String = String.Empty
        Dim Total As String = String.Empty
        Dim RemissionId As String = String.Empty
        Dim Cliente As String = String.Empty
        Dim OrdenTrabajo As String = String.Empty
        Dim Notas As String = String.Empty
        Dim MensajeImportante As String = String.Empty
        Dim PDFImpreso As Boolean = False
        Dim FechaEmision As String = String.Empty
        Dim DocumentoValido As Boolean = False
        Try

            With dtInformacionPares
                .Columns.Add("Cantidad")
                .Columns.Add("Descripcion")
                .Columns.Add("Descripcion2")
                .Columns.Add("Corrida")
                .Columns.Add("Estilo")
                .Columns.Add("Precio")
                .Columns.Add("Importe")
            End With

            entReporte = objReporte.LeerReporteporClave("FACT_REMISION")

            dtInformacionParesAux = objBU.ObtenerInformacionParesImpresion(DocumentoID)
            dtInformacionEncabezado = objBU.ObtenerInformacionEncabezadoImpresion(DocumentoID)


            If IsNothing(dtInformacionEncabezado) = False Then
                If dtInformacionEncabezado.Rows.Count > 0 Then
                    Docenas = Double.Parse(dtInformacionEncabezado.Rows(0).Item("Docenas")).ToString("F2")
                    Pares = dtInformacionEncabezado.Rows(0).Item("Pares")
                    SubTotal = dtInformacionEncabezado.Rows(0).Item("SubTotal")
                    Descuento = dtInformacionEncabezado.Rows(0).Item("Descuento")
                    Total = dtInformacionEncabezado.Rows(0).Item("Total")
                    RemissionId = dtInformacionEncabezado.Rows(0).Item("RemisionID")
                    Cliente = dtInformacionEncabezado.Rows(0).Item("Cliente")
                    OrdenTrabajo = dtInformacionEncabezado.Rows(0).Item("OrdenTrabajo")
                    Notas = dtInformacionEncabezado.Rows(0).Item("Notas")
                    MensajeImportante = dtInformacionEncabezado.Rows(0).Item("Mensaje")
                    FechaEmision = dtInformacionEncabezado.Rows(0).Item("FechaEmision")
                    DocumentoValido = True
                End If
            End If

            If DocumentoValido = True Then
                For Each Fila As DataRow In dtInformacionParesAux.Rows
                    dtInformacionPares.Rows.Add(Fila.Item("Cantidad"), Fila.Item("Descripcion"), Fila.Item("PielColor"), Fila.Item("Corrida"), Fila.Item("Estilo"), Fila.Item("Precio"), Fila.Item("Importe"))
                Next

                dtInformacionPares.TableName = "dtContenidoRemision"
                dtRemision.Tables.Add(dtInformacionPares)

                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)

                Dim Fecha As String = String.Empty

                ReporteRemision.Load(archivo)
                ReporteRemision.Compile()
                ReporteRemision.RegData(dtRemision)
                'reporteUnaTiendaConCita("RutaImagen") = Tools.Controles.ObtenerLogoNave(43)
                ReporteRemision("Docenas") = Docenas
                ReporteRemision("Orden") = OrdenTrabajo
                ReporteRemision("SubTotal") = SubTotal
                ReporteRemision("Descuento") = Descuento
                ReporteRemision("Pares") = Pares
                ReporteRemision("Total") = Total
                'ReporteRemision("Fecha") = FormatoFechaImpresion()
                ReporteRemision("Fecha") = FechaEmision
                ReporteRemision("IdRemision") = RemissionId
                ReporteRemision("Nota") = Notas
                ReporteRemision("MensajeImportante") = MensajeImportante
                ReporteRemision("Nombre") = Cliente
                ReporteRemision.Dictionary.Clear()
                ReporteRemision.Dictionary.Synchronize()
                'ReporteRemision.Render()
                ReporteRemision.Show()

                PDFImpreso = True
            Else
                PDFImpreso = False
            End If


        Catch ex As Exception
            PDFImpreso = False
        End Try

        Return PDFImpreso

    End Function


    Private Function FormatoFechaImpresion() As String
        Dim FormatoFecha As String = String.Empty
        FormatoFecha = Date.Now.Day.ToString & "-" & ObtenerMes(Date.Now.Month) & "-" & Date.Now.Year.ToString
        Return FormatoFecha
    End Function

    Private Function ObtenerMes(ByVal Mes As Integer)
        Dim NombreMes As String = String.Empty
        Select Case Mes
            Case 1
                NombreMes = "Ene"
            Case 2
                NombreMes = "Feb"
            Case 3
                NombreMes = "Mar"
            Case 4
                NombreMes = "Abr"
            Case 5
                NombreMes = "May"
            Case 6
                NombreMes = "Jun"
            Case 7
                NombreMes = "Jul"
            Case 8
                NombreMes = "Ago"
            Case 9
                NombreMes = "Sep"
            Case 10
                NombreMes = "Oct"
            Case 11
                NombreMes = "Nov"
            Case 12
                NombreMes = "Dic"
        End Select

        Return NombreMes

    End Function

    Public Function GenerarInformacionTimbrado(ByVal DocumentoID As Integer, ByVal TipoDocumento As String) As DataTable
        Dim objDA As New Facturacion.Datos.TimbradoFacturasDA
        Return objDA.GenerarInformacionTimbrado(DocumentoID, TipoDocumento)
    End Function

    Public Function ObtenerInformacionParesImpresion(ByVal DocumentoID As Integer) As DataTable
        Dim objDA As New Facturacion.Datos.TimbradoFacturasDA
        Return objDA.ObtenerInformacionParesImpresion(DocumentoID)
    End Function

    Public Function ObtenerInformacionEncabezadoImpresion(ByVal DocumentoID As Integer) As DataTable
        Dim objDA As New Facturacion.Datos.TimbradoFacturasDA
        Return objDA.ObtenerInformacionEncabezadoImpresion(DocumentoID)
    End Function

    Public Function ObtenerDetalleAddenda(ByVal DocumentoID As Integer) As List(Of Entidades.AddendaDetalles)
        Dim objDA As New Datos.TimbradoFacturasDA
        Dim ListaDetalles As New List(Of Entidades.AddendaDetalles)
        Dim dtDetallesAddenda As DataTable
        Dim objEnt As Entidades.AddendaDetalles

        dtDetallesAddenda = objDA.ObtenerDetalleAddenda(DocumentoID)

        For Each Fila As DataRow In dtDetallesAddenda.Rows
            objEnt = New Entidades.AddendaDetalles
            objEnt.Partida = Fila.Item("Partida")
            objEnt.Codigo = Fila.Item("Codigo")
            objEnt.Calce = Fila.Item("talla_sicy")
            objEnt.SKU = Fila.Item("SKU")
            objEnt.CodigoCliente = Fila.Item("CodigoCliente")
            objEnt.CodigoAMECE = Fila.Item("CodigoAMECE")
            objEnt.Articulo = Fila.Item("Articulo")
            objEnt.Talla = Fila.Item("Talla")
            objEnt.CantidadPares = Fila.Item("CantidadPares")

            objEnt.PrecioBruto = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", Fila.Item("PBruto"))
            'objEnt.PrecioBruto = String.Format(Fila.Item("PBruto"), "#0.00")
            objEnt.MontoBruto = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", Fila.Item("MBruto")) 'String.Format(Fila.Item("MBruto"), "#0.00")
            objEnt.FormatoTalla = Fila.Item("FormatoTalla")
            objEnt.Estilo = Fila.Item("Estilo")
            objEnt.ImpLinea = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", Fila.Item("impLinea")) 'String.Format(Fila.Item("impLinea"), "#0.00")
            objEnt.MontoImpresionLinea = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", Fila.Item("MImpLinea")) 'String.Format(Fila.Item("MImpLinea"), "#0.00")
            objEnt.PorcentajeIVA = Fila.Item("TIVa")
            objEnt.MontoIVA = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", Fila.Item("MIVA")) ' String.Format(Fila.Item("MIVA"), "#0.00")
            objEnt.UmPri = Fila.Item("UmPri")
            objEnt.UMPSec = Fila.Item("UMPSec")
            objEnt.DescripcionCte = Fila.Item("DescripcionCte")
            objEnt.PrecioNeto = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", Fila.Item("Pneto")) ' String.Format(Fila.Item("Pneto"), "#0.00")
            objEnt.Descuento = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", Fila.Item("CantDesc")) 'String.Format(Fila.Item("CantDesc"), "#0.00")
            objEnt.CantidadEmpacado = Fila.Item("cantemp")
            objEnt.PorcentajeDescuento = Fila.Item("fcdc_porcentajedescuento")
            ListaDetalles.Add(objEnt)
        Next

        Return ListaDetalles
    End Function

    Public Function ConsultarEncabezadoAddendaCOPPEL(ByVal DocumentoID As Integer) As Entidades.Addenda
        Dim objDA As New Datos.TimbradoFacturasDA
        Dim dtInformacion As DataTable
        Dim obj As New Entidades.Addenda

        dtInformacion = objDA.ConsultarEncabezadoAddendaCOPPEL(DocumentoID)

        If dtInformacion.Rows.Count > 0 Then

            obj.DocumentoID = dtInformacion.Rows(0).Item("fcdc_documentoid")
            If IsDBNull(dtInformacion.Rows(0).Item("fcdc_remisionid")) = False Then
                obj.RemisionID = dtInformacion.Rows(0).Item("fcdc_remisionid")
            Else
                obj.RemisionID = 0
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("fcdc_añoremision")) = False Then
                obj.AñoRemision = dtInformacion.Rows(0).Item("fcdc_añoremision")
            Else
                obj.AñoRemision = 0
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("fcdc_foliofactura")) = False Then
                obj.FolioFactura = dtInformacion.Rows(0).Item("fcdc_foliofactura")
            Else
                obj.FolioFactura = ""
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("fcdc_seriefactura")) = False Then
                obj.SerieFactura = dtInformacion.Rows(0).Item("fcdc_seriefactura")
            Else
                obj.SerieFactura = ""
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("fcdc_tipodocumento")) = False Then
                obj.TipoDocumento = dtInformacion.Rows(0).Item("fcdc_tipodocumento")
            Else
                obj.TipoDocumento = ""
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("fcdc_numcajas")) = False Then
                obj.NumeroCajas = dtInformacion.Rows(0).Item("fcdc_numcajas")
            Else
                obj.NumeroCajas = "0"
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("tiec_codigotienda")) = False Then
                obj.CodigoTienda = dtInformacion.Rows(0).Item("tiec_codigotienda")
            Else
                obj.CodigoTienda = "----"
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("fcdc_fechacaptura")) = False Then
                obj.FechaCaptura = dtInformacion.Rows(0).Item("fcdc_fechacaptura")
            Else
                obj.FechaCaptura = Nothing
            End If

            obj.ParesFacturados = dtInformacion.Rows(0).Item("fcdc_paresfacturados")
            obj.ParesCancelados = dtInformacion.Rows(0).Item("fcdc_parescancelados")
            obj.TotalPares = dtInformacion.Rows(0).Item("fcdc_totalpares")
            obj.SubTotal = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", dtInformacion.Rows(0).Item("fcdc_subtotal")) 'dtInformacion.Rows(0).Item("fcdc_subtotal")
            obj.Descuento = dtInformacion.Rows(0).Item("fcdc_descuento")
            obj.TipoIVA = dtInformacion.Rows(0).Item("fcdc_tipoiva")
            obj.MontoTotal = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", dtInformacion.Rows(0).Item("fcdc_montototal")) ' dtInformacion.Rows(0).Item("fcdc_montototal")
            obj.PorcentajeDescuento = dtInformacion.Rows(0).Item("fcdc_porcentajedescuento")
            obj.MontoTotalLetra = dtInformacion.Rows(0).Item("fcdc_montototal_letra")
            obj.UsoCFDI = dtInformacion.Rows(0).Item("fcdc_usocfdiid")
            obj.OrdenCompra = dtInformacion.Rows(0).Item("fcdc_ordencompra")
            obj.CorreoReceptor = dtInformacion.Rows(0).Item("fcdc_correoreceptor")
            obj.TotalIVA = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", dtInformacion.Rows(0).Item("fcdc_totaliva")) 'dtInformacion.Rows(0).Item("fcdc_totaliva")
            obj.Importe = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", dtInformacion.Rows(0).Item("fcdc_importe")) 'dtInformacion.Rows(0).Item("fcdc_importe")
            obj.ClaveProveedor = dtInformacion.Rows(0).Item("clie_claveyuyinproveedor")
        End If

        Return obj
    End Function


    Public Function ConsultarRutasDocumento(ByVal DocumentoID As Integer) As Entidades.DatosFactura
        Dim objDA As New Datos.TimbradoFacturasDA
        Dim dtinformacion As New DataTable
        Dim objFactura As New Entidades.DatosFactura

        dtinformacion = objDA.ConsultarRutasDocumento(DocumentoID)

        If dtinformacion.Rows.Count > 0 Then
            objFactura.DocumentoID = DocumentoID
            objFactura.RutaPDF = dtinformacion.Rows(0).Item("RutaPDF")
            objFactura.RutaXML = dtinformacion.Rows(0).Item("RutaXML")
            objFactura.RemisionID = dtinformacion.Rows(0).Item("RemisionID")
            objFactura.Año = dtinformacion.Rows(0).Item("Año")
            objFactura.FolioFactura = dtinformacion.Rows(0).Item("FolioFactura")
            objFactura.SerieFactura = dtinformacion.Rows(0).Item("SerieFactura")
            objFactura.UUID = dtinformacion.Rows(0).Item("UUID")
        End If

        Return objFactura
    End Function

    Public Sub CancelarDocumentoSICY(ByVal RemisionID As Integer, ByVal Año As Integer, ByVal UUID As String, ByVal RutaXML As String, ByVal RutaPDF As String)
        Dim objDA As New Datos.TimbradoFacturasDA
        objDA.CancelarDocumentoSICY(RemisionID, Año, UUID, RutaXML, RutaPDF)
    End Sub

    Public Sub ActualizarRutaDocumentoSICY(ByVal RemisionID As Integer, ByVal Año As Integer, ByVal RutaXML As String, ByVal RutaPDF As String)
        Dim objDA As New Datos.TimbradoFacturasDA
        objDA.ActualizarRutaDocumentoSICY(RemisionID, Año, RutaXML, RutaPDF)
    End Sub

    Public Function ConsultarInformacionDocumentoFactura(ByVal DocumentoID As Integer) As Entidades.DatosFactura
        Dim objDA As New Datos.TimbradoFacturasDA
        Dim dtinformacion As New DataTable
        Dim objFactura As New Entidades.DatosFactura

        dtinformacion = objDA.ConsultarInformacionDocumentoFactura(DocumentoID)

        If dtinformacion.Rows.Count > 0 Then
            objFactura.DocumentoID = DocumentoID
            objFactura.RutaPDF = dtinformacion.Rows(0).Item("fcdc_rutaPDF")
            objFactura.RutaXML = dtinformacion.Rows(0).Item("fcdc_rutaXML")
            objFactura.RemisionID = dtinformacion.Rows(0).Item("fcdc_remisionid")
            objFactura.Año = dtinformacion.Rows(0).Item("fcdc_añoremision")
            objFactura.FolioFactura = dtinformacion.Rows(0).Item("fcdc_foliofactura")
            objFactura.SerieFactura = dtinformacion.Rows(0).Item("fcdc_seriefactura")
            objFactura.UUID = dtinformacion.Rows(0).Item("fcdc_uuid")
            objFactura.TipoComprobante = dtinformacion.Rows(0).Item("fcdc_tipodocumento")
        End If

        Return objFactura

    End Function


    Public Function ImprimirRemisionCancelada(ByVal DocumentoID As Integer) As Boolean
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim objBU As New Negocios.TimbradoFacturasBU
        Dim dtRemision As New DataSet("dtRemision")
        Dim ReporteRemision As New StiReport
        Dim dtInformacionPares As New DataTable

        Dim entReporte As New Entidades.Reportes
        Dim dtInformacionParesAux As New DataTable
        Dim dtInformacionEncabezado As DataTable
        Dim Docenas As String = String.Empty
        Dim Pares As String = String.Empty
        Dim SubTotal As String = String.Empty
        Dim Descuento As String = String.Empty
        Dim Total As String = String.Empty
        Dim RemissionId As String = String.Empty
        Dim Cliente As String = String.Empty
        Dim OrdenTrabajo As String = String.Empty
        Dim Notas As String = String.Empty
        Dim MensajeImportante As String = String.Empty
        Dim PDFImpreso As Boolean = False
        Dim FechaEmision As String = String.Empty
        Dim DocumentoValido As Boolean = False
        Try

            With dtInformacionPares
                .Columns.Add("Cantidad")
                .Columns.Add("Descripcion")
                .Columns.Add("Descripcion2")
                .Columns.Add("Corrida")
                .Columns.Add("Estilo")
                .Columns.Add("Precio")
                .Columns.Add("Importe")
            End With

            entReporte = objReporte.LeerReporteporClave("FACT_REMISION_CANCELACION")

            dtInformacionParesAux = objBU.ObtenerInformacionParesImpresion(DocumentoID)
            dtInformacionEncabezado = objBU.ObtenerInformacionEncabezadoImpresion(DocumentoID)


            If IsNothing(dtInformacionEncabezado) = False Then
                If dtInformacionEncabezado.Rows.Count > 0 Then
                    Docenas = Double.Parse(dtInformacionEncabezado.Rows(0).Item("Docenas")).ToString("F2")
                    Pares = dtInformacionEncabezado.Rows(0).Item("Pares")
                    SubTotal = dtInformacionEncabezado.Rows(0).Item("SubTotal")
                    Descuento = dtInformacionEncabezado.Rows(0).Item("Descuento")
                    Total = dtInformacionEncabezado.Rows(0).Item("Total")
                    RemissionId = dtInformacionEncabezado.Rows(0).Item("RemisionID")
                    Cliente = dtInformacionEncabezado.Rows(0).Item("Cliente")
                    OrdenTrabajo = dtInformacionEncabezado.Rows(0).Item("OrdenTrabajo")
                    Notas = dtInformacionEncabezado.Rows(0).Item("Notas")
                    MensajeImportante = dtInformacionEncabezado.Rows(0).Item("Mensaje")
                    FechaEmision = dtInformacionEncabezado.Rows(0).Item("FechaEmision")
                    DocumentoValido = True
                End If
            End If

            If DocumentoValido = True Then
                For Each Fila As DataRow In dtInformacionParesAux.Rows
                    dtInformacionPares.Rows.Add(Fila.Item("Cantidad"), Fila.Item("Descripcion"), Fila.Item("PielColor"), Fila.Item("Corrida"), Fila.Item("Estilo"), Fila.Item("Precio"), Fila.Item("Importe"))
                Next

                dtInformacionPares.TableName = "dtContenidoRemision"
                dtRemision.Tables.Add(dtInformacionPares)

                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)

                Dim Fecha As String = String.Empty

                ReporteRemision.Load(archivo)
                ReporteRemision.Compile()
                ReporteRemision.RegData(dtRemision)
                'reporteUnaTiendaConCita("RutaImagen") = Tools.Controles.ObtenerLogoNave(43)
                ReporteRemision("Docenas") = Docenas
                ReporteRemision("Orden") = OrdenTrabajo
                ReporteRemision("SubTotal") = SubTotal
                ReporteRemision("Descuento") = Descuento
                ReporteRemision("Pares") = Pares
                ReporteRemision("Total") = Total
                'ReporteRemision("Fecha") = FormatoFechaImpresion()
                ReporteRemision("Fecha") = FechaEmision
                ReporteRemision("IdRemision") = RemissionId
                ReporteRemision("Nota") = Notas
                ReporteRemision("MensajeImportante") = MensajeImportante
                ReporteRemision("Nombre") = Cliente
                ReporteRemision.Dictionary.Clear()
                ReporteRemision.Dictionary.Synchronize()
                'ReporteRemision.Render()
                ReporteRemision.Show()

                PDFImpreso = True
            Else
                PDFImpreso = False
            End If


        Catch ex As Exception
            PDFImpreso = False
        End Try

        Return PDFImpreso

    End Function

    Private Function ObtenerRutaServidorRest() As String
        Dim objDA As New Datos.TimbradoFacturasDA
        Dim dtInformacion As DataTable
        Dim Servidor As String = String.Empty

        dtInformacion = objDA.ObtenerRutaServidorREST()
        If IsNothing(dtInformacion) = False Then
            If dtInformacion.Rows.Count > 0 Then
                Servidor = dtInformacion.Rows(0).Item(0)
            End If
        Else
            Servidor = String.Empty
        End If

        Return Servidor
    End Function

    Public Sub CrearDirectorio(ByVal Ruta As String)

        Dim DirectorioCliente As String = String.Empty
        Dim FileName As String = String.Empty
        Dim DirectoryName As String = String.Empty
        Try
            DirectorioCliente = Path.GetDirectoryName(Ruta)
            ' DirectorioCliente &= "\"
            If System.IO.Directory.Exists(DirectorioCliente) = False Then
                System.IO.Directory.CreateDirectory(DirectorioCliente)
            End If
            FileName = Path.GetFileName(Ruta)
            DirectorioCliente &= FileName
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ObtenerRutaXMLRESTFactura(ByVal DocumentoID As String) As String
        Dim objDA As New Datos.TimbradoFacturasDA
        Dim dtInformacionXML As DataTable
        Dim RutaXML As String = String.Empty
        dtInformacionXML = objDA.ObtenerRutaXMLFactura(DocumentoID)

        If dtInformacionXML.Rows.Count > 0 Then
            RutaXML = dtInformacionXML.Rows(0).Item(1)
        Else
            RutaXML = String.Empty
        End If
        Return RutaXML
    End Function

    Public Function ObtenerRutaXMLSICYFactura(ByVal DocumentoID As String) As String
        Dim objDA As New Datos.TimbradoFacturasDA
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

    Public Function ConsultarErroresTimbrado(ByVal DocumentoID As String, ByVal TipoComprobante As String) As DataTable
        Dim objDA As New Datos.TimbradoFacturasDA
        Dim dtInformacion As DataTable
        dtInformacion = objDA.ConsultarErroresTimbrado(DocumentoID, TipoComprobante)
        Return dtInformacion
    End Function

    Public Sub InsertarErrorAlTimbrar(ByVal idDocumento As Integer, ByVal TipoComprobante As String, ByVal ClaveError As String, ByVal DescripcionError As String)
        Dim objDA As New Datos.TimbradoFacturasDA
        objDA.InsertarErrorAlTimbrar(idDocumento, TipoComprobante, ClaveError, DescripcionError)
    End Sub

    Public Function ValidarMontosDocumento(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As Boolean
        Dim ObjDA As New Datos.TimbradoFacturasDA
        Dim dtInformacion As DataTable
        Dim Resultado As Boolean = True
        Dim TotalDescuento As Double = 0
        Dim TotalDetalleDescuento As Double = 0
        Dim TotalSubtotal As Double = 0
        Dim TotalDetalleSubTotal As Double = 0
        Dim TotalTotal As Double = 0
        Dim TotalDetalleTotal As Double = 0
        Dim TotalIVA As Double = 0
        Dim TotalDetalleIVA As Double = 0
        Dim MensajeError As String = String.Empty
        Dim IVACalculadoCorrecto As Integer = 0

        Try
            dtInformacion = ObjDA.ValidarMontosDocumento(idDocumento, TipoComprobante)
            If dtInformacion.Rows.Count > 0 Then
                TotalDescuento = dtInformacion.Rows(0).Item("EncabezadoDescuento")
                TotalDetalleDescuento = dtInformacion.Rows(0).Item("DetalleDescuento")
                TotalSubtotal = dtInformacion.Rows(0).Item("EncabezadoSubtotal")
                TotalDetalleSubTotal = dtInformacion.Rows(0).Item("DetalleSubTotal")
                TotalTotal = dtInformacion.Rows(0).Item("EncabezadoTotal")
                TotalDetalleTotal = dtInformacion.Rows(0).Item("DetalleTotal")
                TotalIVA = dtInformacion.Rows(0).Item("EncabezadoIVA")
                TotalDetalleIVA = dtInformacion.Rows(0).Item("DetalleIVA")
                IVACalculadoCorrecto = dtInformacion.Rows(0).Item("IVACalculado")

                If TotalDescuento <> TotalDetalleDescuento Then
                    Resultado = False
                    MensajeError = "El monto total del descuento no coincide con el monto total del detalle."
                    ObjDA.InsertarErrorAlTimbrar(idDocumento, TipoComprobante, "NA", MensajeError)
                End If

                If TotalSubtotal <> TotalDetalleSubTotal Then
                    Resultado = False
                    MensajeError = "El monto SubTotal no coincide con el SubTotal del detalle."
                    ObjDA.InsertarErrorAlTimbrar(idDocumento, TipoComprobante, "NA", MensajeError)
                End If

                If TotalTotal <> TotalDetalleTotal Then
                    Resultado = False
                    MensajeError = "El monto Total no coincide con el Total del detalle."
                    ObjDA.InsertarErrorAlTimbrar(idDocumento, TipoComprobante, "NA", MensajeError)
                End If

                If TotalIVA <> TotalDetalleIVA Then
                    Resultado = False
                    MensajeError = "El monto del IVA no coincide con el Total del IVA del detalle."
                    ObjDA.InsertarErrorAlTimbrar(idDocumento, TipoComprobante, "NA", MensajeError)
                End If

                If IVACalculadoCorrecto > 0 Then
                    Resultado = False
                    MensajeError = "Los impuestos no coinciden con el total."
                    ObjDA.InsertarErrorAlTimbrar(idDocumento, TipoComprobante, "NA", MensajeError)
                End If

            End If

        Catch ex As Exception
            Resultado = False
        End Try

        Return Resultado
    End Function

    Public Sub RecalcularMontos(ByVal idDocumento As Integer)
        Dim ObjDA As New Datos.TimbradoFacturasDA
        ObjDA.RecalcularMontos(idDocumento)
    End Sub

    Public Function EnviarCorreoFactura(ByVal DocumentoID As Integer) As Boolean
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = My.Settings.ServidorRestCorreo
        Dim dtResultado As DataTable
        Dim Resultado As Boolean = False
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        Dim RutaCliente As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaRest As String = String.Empty
        Dim EmpresaId As Integer = 0
        Dim RutaLogoEmpresa As String = String.Empty
        Dim EntFactura As New Entidades.DatosFactura

        Try



            llamarServicio.url = Servidor & "Facturas/EnviarCorreoFactura?DocumentoID=" & DocumentoID.ToString & ""
            llamarServicio.metodo = "GET"
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

            _Aviso = Respuesta.aviso
            If Respuesta.respuesta = 1 Then
                Resultado = True
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

    Public Function ReenvioCorreoDoctosElectronicos(ByVal DocumentoID As Integer, ByVal TipoDocumento As String) As Boolean
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = My.Settings.ServidorRestCorreo
        Dim dtResultado As DataTable
        Dim Resultado As Boolean = False
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        Dim RutaCliente As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaRest As String = String.Empty
        Dim EmpresaId As Integer = 0
        Dim RutaLogoEmpresa As String = String.Empty
        Dim EntFactura As New Entidades.DatosFactura







        Try

            llamarServicio.url = Servidor & "Facturas/EnviarCorreoFacturaDoctosElectronicos?IdUnico=" & DocumentoID.ToString & "&TipoDocumento=" & TipoDocumento
            llamarServicio.metodo = "GET"
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

            _Aviso = Respuesta.aviso
            If Respuesta.respuesta = 1 Then
                Resultado = True
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


End Class
