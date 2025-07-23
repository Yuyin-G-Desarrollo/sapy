Imports System.Xml
Imports System.IO
Imports System.Net
'Imports Facturacion.Negocios.mx.com.paxfacturacion.test 'Pruebas 
'Imports Facturacion.Negocios.mx.com.paxfacturacion.testCanc 'Pruebas
Imports Facturacion.Negocios.mx.com.paxfacturacion.www
Imports Facturacion.Negocios.mx.com.paxfacturacion.wwwCanc
Imports Stimulsoft.Report

Public Class FacturaBU
    'Dim ftp As String = "ftp://192.168.7.16"
    Private cfdi As String = "http://www.sat.gob.mx/cfd/3"
    Private xsi As String = "http://www.w3.org/2001/XMLSchema-instance"
    Private implocal As String = "http://www.sat.gob.mx/implocal"
    Private schemaLocation As String = "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv32.xsd http://www.sat.gob.mx/implocal http://www.sat.gob.mx/sitio_internet/cfd/implocal/implocal.xsd"

    Private rutaArchivosTemp As String = "C:\RespaldosXml\"
    Private rutaUtilerias As String = "C:\UtileriasFacturacion\"
    'Private ftpUtilerias As String = "/Administracion/ConfiguracionEmpresas/Utilerias/"
    Private strOpensslExe As String = "C:\UtileriasFacturacion\OpenSSL\bin\openssl.exe"
    Private archivoXSLT As String = "C:\UtileriasFacturacion\XSLT\cadenaoriginal_3_2.xslt"

    Private version As String = "3.2"
    Private tipoDeComprobante As String = "ingreso"
    Private fechaExpedicion As DateTime
    Public msjError As String = ""

    Dim objFactura As Entidades.Factura
    Dim objConceptos As List(Of Entidades.Conceptos)
    Dim empresaID As Integer
    Dim sucursalID As Integer
    Dim sucursaNombre As String
    Dim tipoComprobante As String

    Public imprimeSucursal As Boolean
    Private rutaWS As String
    Private usuarioWS As String
    Private pssWS As String
    Private rutaXML As String
    Private rutaPDF As String
    Private rutaKey As String
    Private rutaCer As String
    Private psskey As String
    Private rutaLogo As String
    Private reporteId As Int32
    Private reporteCancId As Int32
    Private curp As String

    Private cadenaOriginal As String
    Private selloB64 As String
    Private sXML As String
    Public guidTemp As Guid = Nothing

    Private archKeyPem As String
    Private archCerPem As String
    Private tempCadena As String
    Private tempSHA As String
    Private tempSello As String

    Public Function construirXML(ByVal factura As Entidades.Factura, ByVal conceptos As List(Of Entidades.Conceptos), ByVal idEmpresa As Integer, ByVal idSucursal As Integer, ByVal tipo As String) As Entidades.Factura
        Try
            Dim objDA As New Datos.EmpresasDA
            Dim tabla As New DataTable

            objFactura = factura
            objConceptos = conceptos
            empresaID = idEmpresa
            sucursalID = idSucursal
            tipoComprobante = tipo
            guidTemp = Guid.NewGuid() 'Genera un identificador universal para utilizarlo temporalmente

            If validarCampos() Then
                objFactura.FVersion = version
                objFactura.FTipoComprobante = tipoDeComprobante

                If obtenerDatosEmpresa() Then
                    If obtenerConfiguracion() Then
                        If obtenerDatosSucursal() Then
                            rutaArchivosTemp = rutaArchivosTemp & objFactura.FEmisorRfc & "\" & sucursaNombre.Replace(" ", "_") & "\"
                            rutaCer = descargarArchivo(rutaCer)
                            rutaKey = descargarArchivo(rutaKey)

                            If rutaCer <> "" And rutaKey <> "" Then
                                tabla = objDA.obtenerFechaActual()
                                If tabla.Rows.Count <> 0 Then
                                    fechaExpedicion = CDate(tabla.Rows(0)("FechaActual"))
                                    objFactura.FFechaExpedicion = CStr(fechaExpedicion.ToString("yyyy-MM-ddTHH:mm:ss"))
                                    rutaXML &= CStr(fechaExpedicion.ToString("yyyyMM"))
                                    rutaPDF &= CStr(fechaExpedicion.ToString("yyyyMM"))
                                    sXML = rutaArchivosTemp & guidTemp.ToString & "\" & guidTemp.ToString & ".xml"

                                    If generarXML() Then
                                        cadenaOriginal = obtenerCadenaOriginal()
                                        objFactura.FCadenaOriginal = cadenaOriginal

                                        archKeyPem = rutaKey & ".pem"
                                        archCerPem = rutaCer & ".pem"

                                        tempCadena = crearArchivoTemporal("tempCadena_" & guidTemp.ToString & ".txt")
                                        tempSHA = crearArchivoTemporal("tempSHA_" & guidTemp.ToString & ".txt")
                                        tempSello = crearArchivoTemporal("tempSello_" & guidTemp.ToString & ".txt")

                                        If obtenerSello() Then
                                            If agregarSello() Then
                                                If timbrar(sXML) Then
                                                    'Timbardo correcto
                                                    My.Computer.FileSystem.CopyFile(sXML, rutaArchivosTemp & objFactura.FEmisorRfc & "_" & objFactura.FSerie & factura.FFolio & ".xml", Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
                                                    sXML = rutaArchivosTemp & objFactura.FEmisorRfc & "_" & objFactura.FSerie & objFactura.FFolio & ".xml"
                                                    'If Not subirFtp(Mid(rutaXML.Replace(ftp.ToUpper, ""), 2), sXML) Then
                                                    If Not subirFtp(rutaXML, sXML) Then
                                                        msjError = "El proceso se realizó con éxito pero no se pudo copiar el XML al FTP. Favor de contactar al area de TI."
                                                    Else
                                                        objFactura.FXml = rutaXML & "/" & objFactura.FEmisorRfc & "_" & objFactura.FSerie & factura.FFolio & ".xml"
                                                    End If

                                                    objFactura.FReporteId = reporteId
                                                    Try
                                                        generarPdf("Factura", reporteId)
                                                    Catch
                                                    End Try
                                                    eliminaArchivosTemp()
                                                    Return objFactura
                                                Else
                                                    'msjError = "Error al timbrar."
                                                    eliminaArchivosTemp()
                                                    Return Nothing
                                                End If
                                            Else
                                                msjError = "Error al agregar el sello."
                                                eliminaArchivosTemp()
                                                Return Nothing
                                            End If
                                        Else
                                            msjError = "Error al obtener el sello."
                                            eliminaArchivosTemp()
                                            Return Nothing
                                        End If
                                    Else
                                        msjError = "Error al generar el xml."
                                        Return Nothing
                                    End If
                                Else
                                    msjError = "Error al obtener la fecha del servidor."
                                    fechaExpedicion = Nothing
                                    Return Nothing
                                End If
                            Else
                                msjError = "Error al obtener el certificado y el key."
                                Return Nothing
                            End If
                        Else
                            msjError = "Error al obtener los datos de la succursal."
                            Return Nothing
                        End If
                    Else
                        msjError = "Error al obtener configuracion de la succursal."
                        Return Nothing
                    End If
                Else
                    msjError = "Error al obtener los datos de la empresa."
                    Return Nothing
                End If
            Else
                msjError = "Existen campos obligatorios que no se han capturado."
                Return Nothing
            End If
        Catch
            eliminaArchivosTemp()
            Return Nothing
        End Try
    End Function

    Public Function descargarArchivo(ByVal archivo As String) As String
        Try
            Dim objFTP As New TransferenciaFTPBU
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
            Dim rutaArchivo As String = ""
            Dim nuevaRuta As String = ""
            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)

            If archivo <> "" Then
                'archivo = archivo.ToUpper.Replace(ftp.ToUpper, "")
                rutaArchivo = IO.Path.GetDirectoryName(archivo)
                objFTP.DescargarArchivo(rutaArchivo, rutaArchivosTemp & guidTemp.ToString, IO.Path.GetFileName(archivo))
                nuevaRuta = rutaArchivosTemp & guidTemp.ToString & "\" & IO.Path.GetFileName(archivo)
            End If

            Return nuevaRuta
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function validarCampos() As Boolean
        Dim validos As Boolean = True

        'Comprobante
        If objFactura.FSerie = "" Then
            validos = False
        End If

        If objFactura.FFolio = 0 Then
            validos = False
        End If

        If objFactura.FFormaDePago = "" Then
            validos = False
        End If

        If objFactura.FSubtotal = 0 Then
            validos = False
        End If

        If objFactura.FTotal = 0 Then
            validos = False
        End If

        If objFactura.FMetodoPago = "" Then
            validos = False
        End If

        'Receptor
        If objFactura.FReceptorRfc = "" Then
            validos = False
        End If

        If objFactura.FReceptorNombre = "" Then
            validos = False
        End If

        If objFactura.FReceptorCalle = "" Then
            validos = False
        End If

        If objFactura.FReceptorNoExterior = "" Then
            validos = False
        End If

        If objFactura.FReceptorColonia = "" Then
            validos = False
        End If

        If objFactura.FReceptorMunicipio = "" Then
            validos = False
        End If

        If objFactura.FReceptorEstado = "" Then
            validos = False
        End If

        If objFactura.FReceptorPais = "" Then
            validos = False
        End If

        If objFactura.FReceptorCp = "" Then
            validos = False
        End If

        'Conceptos
        If objConceptos.Count = 0 Then
            validos = False
        Else
            For Each concepto In objConceptos
                If concepto.CCantidad = 0 Then
                    validos = False
                End If

                If concepto.CUnidad = "" Then
                    validos = False
                End If

                If concepto.CDescripcion = "" Then
                    validos = False
                End If

                If concepto.CValorUnitario = 0 Then
                    validarCampos = False
                End If

                If concepto.CImporte = 0 Then
                    validos = False
                End If
            Next
        End If

        Return validos
    End Function

    Private Function obtenerDatosEmpresa() As Boolean
        Try
            Dim objDA As New Datos.EmpresasDA
            Dim tabla As New DataTable

            tabla = objDA.getDatosEmpresa(empresaID)
            For Each row As DataRow In tabla.Rows
                objFactura.FNoCertificado = CStr(row("empr_numerocertificado"))
                objFactura.FEmisorRfc = CStr(row("empr_rfc")).Replace("-", "")
                objFactura.FEmisorNombre = CStr(row("empr_nombre"))
                objFactura.FEmisorRegimen = CStr(row("empr_regimen"))
                objFactura.FEmisorCalle = CStr(row("empr_calle"))
                objFactura.FEmisorNoExterior = CStr(row("empr_numero"))
                objFactura.FEmisorColonia = CStr(row("empr_colonia"))
                objFactura.FEmisorMunicipio = CStr(row("ciudad"))
                objFactura.FEmisorEstado = CStr(row("estado"))
                objFactura.FEmisorPais = CStr(row("pais"))
                objFactura.FEmisorCp = CStr(row("empr_cp"))

                objFactura.FCertificado = CStr(row("empr_cadenacertificado"))

                rutaXML = CStr(row("empr_rutaxmlproductos"))
                rutaPDF = CStr(row("empr_rutapdfproductos"))
                rutaKey = CStr(row("empr_rutakey"))
                rutaCer = CStr(row("empr_rutacertificado"))
                psskey = CStr(row("empr_contrasenacertificado"))
                rutaWS = CStr(row("empr_webservice"))
                usuarioWS = CStr(row("empr_usuariows"))
                pssWS = CStr(row("empr_contrasenaws"))
                rutaLogo = CStr(row("empr_rutalogo"))
                reporteId = CInt(row("empr_reporteproductosid"))
                reporteCancId = CInt(row("empr_reportecancproductosid"))
                curp = CStr(row("empr_curp"))
            Next

            Return True
        Catch
            Return False
        End Try
    End Function

    Private Function obtenerConfiguracion() As Boolean
        Try
            Dim objDA As New Datos.SucursalesDA
            Dim tablaSE As New DataTable

            tablaSE = objDA.getDatosSucEmpresa(sucursalID, empresaID)

            If CInt(tablaSE.Rows(0)("reporteID")) <> 0 Then
                reporteId = CInt(tablaSE.Rows(0)("reporteID"))
                reporteCancId = CInt(tablaSE.Rows(0)("reporteCancID"))
            End If

            imprimeSucursal = CBool(tablaSE.Rows(0)("suem_imprimirsucursal"))
            objFactura.FImprimeSucursal = imprimeSucursal
            Return True
        Catch
            Return False
        End Try
    End Function

    Private Function obtenerDatosSucursal() As Boolean
        Try
            Dim objDA As New Datos.SucursalesDA
            Dim tablaSU As New DataTable

            tablaSU = objDA.getDatosSucursal(sucursalID)
            For Each row As DataRow In tablaSU.Rows
                If imprimeSucursal = True Then
                    objFactura.FExpedidoCalle = CStr(row("suc_calle"))
                    objFactura.FExpedidoNoExterior = CStr(row("suc_numero"))
                    objFactura.FExpedidoColonia = CStr(row("suc_colonia"))
                    objFactura.FExpedidoMunicipio = CStr(row("ciudad"))
                    objFactura.FExpedidoEstado = CStr(row("estado"))
                    objFactura.FExpedidoPais = CStr(row("pais"))
                    objFactura.FExpedidoCp = CStr(row("suc_cp"))

                    objFactura.FLugarExpedicion = CStr(row("ciudad")) & " " & CStr(row("estado"))
                    If CStr(row("suc_logo")) <> "" Then
                        rutaLogo = CStr(row("suc_logo"))
                    End If
                Else
                    objFactura.FLugarExpedicion = objFactura.FEmisorMunicipio & " " & objFactura.FEmisorEstado
                End If

                sucursaNombre = CStr(row("suc_nombre"))
                rutaXML = rutaXML & sucursaNombre & "/XML/"
                rutaPDF = rutaPDF & sucursaNombre & "/PDF/"
            Next

            Return True
        Catch
            Return False
        End Try
    End Function

    Public Function generarXML() As Boolean
        Try
            'Dim myXmlTextWriter As XmlTextWriter = New XmlTextWriter("C:\Users\SISTEMAS14\Desktop\XMLFacturaPruebas.xml", System.Text.Encoding.UTF8)
            Dim myXmlTextWriter As XmlTextWriter = New XmlTextWriter(sXML, System.Text.Encoding.UTF8)
            myXmlTextWriter.Formatting = System.Xml.Formatting.Indented
            myXmlTextWriter.WriteStartDocument(False)
            Dim claveMetodoPago As String = String.Empty

            'Comprobante
            myXmlTextWriter.WriteStartElement("cfdi:Comprobante")
            myXmlTextWriter.WriteAttributeString("xmlns:cfdi", cfdi)
            myXmlTextWriter.WriteAttributeString("xmlns:xsi", xsi)
            myXmlTextWriter.WriteAttributeString("xmlns:implocal", implocal)
            myXmlTextWriter.WriteAttributeString("xsi:schemaLocation", schemaLocation)
            myXmlTextWriter.WriteAttributeString("version", objFactura.FVersion)
            myXmlTextWriter.WriteAttributeString("serie", objFactura.FSerie)
            myXmlTextWriter.WriteAttributeString("folio", objFactura.FFolio)
            myXmlTextWriter.WriteAttributeString("fecha", objFactura.FFechaExpedicion)
            myXmlTextWriter.WriteAttributeString("sello", objFactura.FSello)
            myXmlTextWriter.WriteAttributeString("formaDePago", objFactura.FFormaDePago)
            myXmlTextWriter.WriteAttributeString("noCertificado", objFactura.FNoCertificado)
            myXmlTextWriter.WriteAttributeString("certificado", objFactura.FCertificado)

            If objFactura.FCondicionesPago <> "" Then
                myXmlTextWriter.WriteAttributeString("condicionesDePago", objFactura.FCondicionesPago)
            End If

            If objFactura.FMoneda <> "" Then
                myXmlTextWriter.WriteAttributeString("Moneda", objFactura.FMoneda)
            End If

            myXmlTextWriter.WriteAttributeString("subTotal", objFactura.FSubtotal.ToString("0.00"))
            myXmlTextWriter.WriteAttributeString("total", objFactura.FTotal.ToString("0.00"))
            myXmlTextWriter.WriteAttributeString("descuento", objFactura.FDescuento.ToString("0.00"))
            If objFactura.FMotivoDescuento <> "" Then
                myXmlTextWriter.WriteAttributeString("motivoDescuento", objFactura.FMotivoDescuento)
            End If

            myXmlTextWriter.WriteAttributeString("tipoDeComprobante", objFactura.FTipoComprobante)

            claveMetodoPago = obtenerClaveMetodoPago(objFactura.FMetodoPago.Trim)
            objFactura.FClaveMetodoPago = claveMetodoPago
            myXmlTextWriter.WriteAttributeString("metodoDePago", claveMetodoPago)

            If objFactura.FLugarExpedicion <> "" Then
                myXmlTextWriter.WriteAttributeString("LugarExpedicion", objFactura.FLugarExpedicion)
            End If


            'Emisor
            myXmlTextWriter.WriteStartElement("cfdi:Emisor")
            myXmlTextWriter.WriteAttributeString("rfc", objFactura.FEmisorRfc)
            myXmlTextWriter.WriteAttributeString("nombre", objFactura.FEmisorNombre)

            myXmlTextWriter.WriteStartElement("cfdi:DomicilioFiscal")
            myXmlTextWriter.WriteAttributeString("calle", objFactura.FEmisorCalle)
            myXmlTextWriter.WriteAttributeString("noExterior", objFactura.FEmisorNoExterior)
            myXmlTextWriter.WriteAttributeString("colonia", objFactura.FEmisorColonia)
            myXmlTextWriter.WriteAttributeString("municipio", objFactura.FEmisorMunicipio)
            myXmlTextWriter.WriteAttributeString("estado", objFactura.FEmisorEstado)
            myXmlTextWriter.WriteAttributeString("pais", objFactura.FEmisorPais)
            myXmlTextWriter.WriteAttributeString("codigoPostal", objFactura.FEmisorCp)
            myXmlTextWriter.WriteEndElement()

            If imprimeSucursal Then
                myXmlTextWriter.WriteStartElement("cfdi:ExpedidoEn")
                myXmlTextWriter.WriteAttributeString("calle", objFactura.FExpedidoCalle)
                myXmlTextWriter.WriteAttributeString("noExterior", objFactura.FExpedidoNoExterior)
                myXmlTextWriter.WriteAttributeString("colonia", objFactura.FExpedidoColonia)
                myXmlTextWriter.WriteAttributeString("municipio", objFactura.FExpedidoMunicipio)
                myXmlTextWriter.WriteAttributeString("estado", objFactura.FExpedidoEstado)
                myXmlTextWriter.WriteAttributeString("pais", objFactura.FExpedidoPais)
                myXmlTextWriter.WriteAttributeString("codigoPostal", objFactura.FExpedidoCp)
                myXmlTextWriter.WriteEndElement()
            End If

            myXmlTextWriter.WriteStartElement("cfdi:RegimenFiscal")
            myXmlTextWriter.WriteAttributeString("Regimen", objFactura.FEmisorRegimen)
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.WriteEndElement()


            'Receptor
            myXmlTextWriter.WriteStartElement("cfdi:Receptor")
            myXmlTextWriter.WriteAttributeString("rfc", objFactura.FReceptorRfc)
            myXmlTextWriter.WriteAttributeString("nombre", objFactura.FReceptorNombre)

            myXmlTextWriter.WriteStartElement("cfdi:Domicilio")
            myXmlTextWriter.WriteAttributeString("calle", objFactura.FReceptorCalle)
            myXmlTextWriter.WriteAttributeString("noExterior", objFactura.FReceptorNoExterior)
            myXmlTextWriter.WriteAttributeString("colonia", objFactura.FReceptorColonia)
            myXmlTextWriter.WriteAttributeString("municipio", objFactura.FReceptorMunicipio)
            myXmlTextWriter.WriteAttributeString("estado", objFactura.FReceptorEstado)
            myXmlTextWriter.WriteAttributeString("pais", objFactura.FReceptorPais)
            myXmlTextWriter.WriteAttributeString("codigoPostal", objFactura.FReceptorCp)
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.WriteEndElement()


            'Conceptos
            myXmlTextWriter.WriteStartElement("cfdi:Conceptos")

            For Each concepto In objConceptos
                myXmlTextWriter.WriteStartElement("cfdi:Concepto")
                myXmlTextWriter.WriteAttributeString("cantidad", concepto.CCantidad.ToString("0.00"))
                myXmlTextWriter.WriteAttributeString("unidad", concepto.CUnidad)
                myXmlTextWriter.WriteAttributeString("descripcion", concepto.CDescripcion)
                myXmlTextWriter.WriteAttributeString("valorUnitario", concepto.CValorUnitario.ToString("0.00"))
                myXmlTextWriter.WriteAttributeString("importe", concepto.CImporte.ToString("0.00"))
                myXmlTextWriter.WriteEndElement()
            Next

            myXmlTextWriter.WriteEndElement()


            'Impuestos
            myXmlTextWriter.WriteStartElement("cfdi:Impuestos")
            myXmlTextWriter.WriteAttributeString("totalImpuestosRetenidos", objFactura.FTotalImpuestosRetenidos.ToString("0.00"))
            myXmlTextWriter.WriteAttributeString("totalImpuestosTrasladados", objFactura.FTotalImpuestosTrasladados.ToString("0.00"))

            If objFactura.FTotalImpuestosTrasladados <> 0 Then
                myXmlTextWriter.WriteStartElement("cfdi:Traslados")

                myXmlTextWriter.WriteStartElement("cfdi:Traslado")
                myXmlTextWriter.WriteAttributeString("impuesto", objFactura.FImpuesto)
                myXmlTextWriter.WriteAttributeString("tasa", objFactura.FTasa.ToString("0.00"))
                myXmlTextWriter.WriteAttributeString("importe", objFactura.FImpuestoTrasladadoImporte.ToString("0.00"))
                myXmlTextWriter.WriteEndElement()

                myXmlTextWriter.WriteEndElement()
            End If

            myXmlTextWriter.WriteEndElement()


            'Cierra comprobante
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.Flush()
            myXmlTextWriter.Close()

            Return True

        Catch
            Return False
        End Try
    End Function

    Private Function obtenerCadenaOriginal() As String
        Dim xmlDoc As New System.Xml.XmlDocument
        Dim transformer As System.Xml.Xsl.XslCompiledTransform
        Dim document As New System.Xml.XmlDocument
        Dim navigator As System.Xml.XPath.XPathNavigator
        Dim output As New System.IO.StringWriter()
        Dim strCadenaOriginal As String = ""

        document = New System.Xml.XmlDocument()
        transformer = New System.Xml.Xsl.XslCompiledTransform

        Try
            document.Load(sXML)
            navigator = document.CreateNavigator
            transformer.Load(archivoXSLT)
            transformer.Transform(navigator, Nothing, output)
            Console.WriteLine(output.ToString)
            strCadenaOriginal = output.ToString
            output.Close()

            Return strCadenaOriginal
        Catch ex As Exception

            Return strCadenaOriginal
        Finally
            document = Nothing
            transformer = Nothing
            navigator = Nothing
            output.Dispose()
        End Try
    End Function

    Private Function crearArchivoTemporal(ByVal archivo As String) As String
        Try
            If Dir(rutaArchivosTemp) = vbNullString Then
                Directory.CreateDirectory(rutaArchivosTemp)
            End If

            If File.Exists(rutaArchivosTemp & guidTemp.ToString & "\" & archivo) = False Then
                Dim fichero As New IO.FileStream(rutaArchivosTemp & guidTemp.ToString & "\" & archivo, IO.FileMode.Create)
                fichero.Close()
            End If

            Return rutaArchivosTemp & guidTemp.ToString & "\" & archivo
        Catch
            Return ""
        End Try
    End Function

    Private Function obtenerSello() As Boolean
        Dim process1 As New Process
        Dim process2 As New Process
        Dim process3 As New Process

        Try
            File.WriteAllText(tempCadena, cadenaOriginal)
            'Crea un archivo con la cadena del key
            process1.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
            process1.StartInfo.FileName = strOpensslExe
            process1.StartInfo.Arguments = "pkcs8 -inform DER -in " & rutaKey & " -passin pass:" & psskey & " -out " & archKeyPem
            process1.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(strOpensslExe)
            process1.StartInfo.UseShellExecute = False
            process1.StartInfo.ErrorDialog = False
            process1.StartInfo.RedirectStandardOutput = True
            process1.StartInfo.CreateNoWindow = True
            process1.Start()
            process1.WaitForExit()

            'Crea archivo del certificado con SHA1
            process2.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
            process2.StartInfo.FileName = strOpensslExe
            process2.StartInfo.Arguments = "dgst -SHA1 -sign " & archKeyPem & " -out " & tempSHA & " " & tempCadena
            process2.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(strOpensslExe)
            process2.StartInfo.UseShellExecute = False
            process2.StartInfo.ErrorDialog = False
            process2.StartInfo.RedirectStandardOutput = True
            process2.StartInfo.CreateNoWindow = True
            process2.Start()
            process2.WaitForExit()

            'Crea archivo con el sello en base 64
            process3.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
            process3.StartInfo.FileName = strOpensslExe
            process3.StartInfo.Arguments = "enc -base64 -in " & tempSHA & " -out " & tempSello
            process3.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(strOpensslExe)
            process3.StartInfo.UseShellExecute = False
            process3.StartInfo.ErrorDialog = False
            process3.StartInfo.RedirectStandardOutput = True
            process3.StartInfo.CreateNoWindow = True
            process3.Start()
            process3.WaitForExit()

            'Agregar la cadena del sello a la variable String
            selloB64 = File.ReadAllText(tempSello)
            'Quita los saltos de línea
            selloB64 = Replace(selloB64, Chr(10), "")
            'Quita los retornos de carro
            selloB64 = Replace(selloB64, Chr(13), "")
            'Asigna a FSello la cadena del sello
            If selloB64 <> "" Then
                objFactura.FSello = selloB64
                Return True
            Else
                Return False
            End If
        Catch
            Return False
        End Try
    End Function

    Private Function agregarSello() As Boolean
        Try
            Dim Factura As XmlNode
            Dim Doc As New XmlDocument

            Doc.Load(sXML)
            Factura = Doc.ChildNodes(1)
            'Factura.Attributes.GetNamedItem("certificado").Value = objFactura.FCertificado
            Factura.Attributes.GetNamedItem("sello").Value = objFactura.FSello
            Doc.Save(sXML)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function obtenerCertificado(ByVal pathCer As String) As String
        Dim process1 As New Process
        Dim process2 As New Process
        Dim CertificadoCadena As String = ""
        Dim RespCertificadoCadena As String = ""

        Try
            guidTemp = Guid.NewGuid()
            rutaCer = pathCer
            rutaCer = descargarArchivo(rutaCer)
            'Crea un archivo con la cadena del certificado (posiblemente no se ocupa)
            process1.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
            process1.StartInfo.FileName = strOpensslExe
            process1.StartInfo.Arguments = "x509 -inform DER -outform PEM -in " & rutaCer & " -pubkey > " & rutaCer & ".pem"
            process1.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(strOpensslExe)
            process1.StartInfo.UseShellExecute = False
            process1.StartInfo.ErrorDialog = False
            process1.StartInfo.RedirectStandardOutput = True
            process1.StartInfo.CreateNoWindow = True
            process1.Start()
            process1.WaitForExit()

            'Obtiene la cadena del certificado 
            process2.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
            process2.StartInfo.FileName = strOpensslExe
            process2.StartInfo.Arguments = "x509 -inform DER -outform PEM -in " & rutaCer
            process2.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(strOpensslExe)
            process2.StartInfo.UseShellExecute = False
            process2.StartInfo.ErrorDialog = False
            process2.StartInfo.RedirectStandardOutput = True
            process2.StartInfo.CreateNoWindow = True
            process2.Start()
            process2.WaitForExit()

            'Agregar la cadena del certificado a la variable String
            CertificadoCadena = process2.StandardOutput.ReadToEnd
            If CertificadoCadena <> "" Then
                'Quita el encabezado: -----BEGIN CERTIFICATE-----
                CertificadoCadena = Mid(CertificadoCadena, 28)
                'Quita enter final
                CertificadoCadena = Replace(Mid(CertificadoCadena, 1, Len(CertificadoCadena) - 2), (Chr(13) + Chr(10)), "")

                'Reescribe la cadena sin el pie: -----END CERTIFICATE----
                For i As Integer = 0 To CertificadoCadena.Length - 1
                    If CertificadoCadena.Chars(i) <> "-" Then
                        RespCertificadoCadena = RespCertificadoCadena & CertificadoCadena.Chars(i)
                    Else
                        Exit For
                    End If
                Next

                'Quita los saltos de línea
                RespCertificadoCadena = Replace(RespCertificadoCadena, Chr(10), "")
                'Quita los retornos de carro
                RespCertificadoCadena = Replace(RespCertificadoCadena, Chr(13), "")
                'Asigna a FCertificado la cadena del certificado sin espacios
                'objFactura.FCertificado = RespCertificadoCadena.Trim
            End If

            eliminaArchivosTemp()

            Return RespCertificadoCadena.Trim
        Catch
            eliminaArchivosTemp()
            Return ""
        End Try
    End Function

    Public Sub eliminaArchivosTemp()
        Try
            Directory.Delete(rutaArchivosTemp & guidTemp.ToString, True)
        Catch ex As Exception

        End Try
    End Sub

    Public Function timbrar(ByVal archivoXML As String) As Boolean
        Try
            Dim Cliente As New wcfRecepcionASMX
            'Cliente.Credentials = New System.Net.NetworkCredential("Hector.GE8308", "Goe.Hector8308")
            Dim Archivo As Stream = File.Open(archivoXML, FileMode.Open)
            Dim Sr As StreamReader = New StreamReader(Archivo)
            Dim strXML As String = String.Empty
            Dim strXMLTimbrado As String = String.Empty

            strXML = Sr.ReadToEnd()
            'Quita el encabezado
            strXML = Replace(strXML, "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & " standalone=" & Chr(34) & "no" & Chr(34) & "?>", "")
            strXML = Replace(Mid(strXML, 1, Len(strXML)), (Chr(13) + Chr(10)), "")
            strXMLTimbrado = Cliente.fnEnviarXML(strXML, tipoComprobante, 0, usuarioWS, pssWS, "3.2")
            Archivo.Close()

            If (strXMLTimbrado.Contains("<cfdi:Comprobante")) = True Then
                'Agrega nuevamente el encabezado
                strXML = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & " standalone=" & Chr(34) & "no" & Chr(34) & "?> " & strXMLTimbrado
                File.WriteAllText(archivoXML, strXML)

                Dim factura As XmlNode
                Dim Doc As New XmlDocument
                Dim strSelloCFDI As String = String.Empty

                'Obtiene los datos del timbrado
                Doc.Load(archivoXML)
                factura = Doc.ChildNodes(1).ChildNodes(4).ChildNodes(0)
                objFactura.FUuid = factura.Attributes.GetNamedItem("UUID").Value
                objFactura.FFechaTimbrado = factura.Attributes.GetNamedItem("FechaTimbrado").Value
                objFactura.FNoCertificadoSAT = factura.Attributes.GetNamedItem("noCertificadoSAT").Value
                objFactura.FSelloSat = factura.Attributes.GetNamedItem("selloSAT").Value

                strSelloCFDI = factura.Attributes.GetNamedItem("selloCFD").Value
                strSelloCFDI = Replace(strSelloCFDI, Chr(10), "")
                strSelloCFDI = Replace(strSelloCFDI, Chr(13), "")
                objFactura.FSelloCFD = strSelloCFDI
                Return True
            Else
                msjError = strXMLTimbrado
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function subirFtp(ByVal ruta As String, ByVal archivo As String) As Boolean
        Try
            Dim objFTP As New TransferenciaFTPBU
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)

            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
            objFTP.EnviarArchivo(ruta, archivo)

            Dim srtRuta As String = objFTP.obtenerURL & "/" & ruta & "/" & IO.Path.GetFileName(archivo)
            'Dim srtRuta As String = ruta & "/" & IO.Path.GetFileName(archivo)
            If objFTP.FtpExisteArchivo(srtRuta) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function generarPdf(ByVal tipo As String, ByVal rptID As Int16, Optional EstatusCancelacion As String = "", Optional FechaCancelacion As String = "") As Boolean
        Try
            Dim objReporte As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            Dim reporte As New StiReport
            Dim pdfSettings = New StiPdfExportSettings()
            EntidadReporte = objReporte.LeerReporte(rptID)
            Dim archivo As String = rutaArchivosTemp & EntidadReporte.Pnombre.Trim & ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim dtConcepto = New DataTable("Conceptos")
            Dim cantidadLetra As String
            Dim auxcantidadLetra() As String
            'Dim objTools As New Tools.Controles
            Dim sPDF As String = ""

            reporte.Load(archivo)
            reporte.Compile()
            reporte("rutaImagen") = descargarArchivo(rutaLogo)
            reporte("serie") = objFactura.FSerie
            reporte("folio") = objFactura.FFolio
            reporte("fechaExpedicion") = CStr(CDate(objFactura.FFechaExpedicion).ToString("yyyy-MM-ddTHH:mm:ss"))
            reporte("uuid") = objFactura.FUuid

            reporte("RazonSocial") = objFactura.FEmisorNombre
            reporte("CURP") = "C.U.R.P." & curp
            reporte("EmisorRFC") = "R.F.C. " & objFactura.FEmisorRfc
            reporte("EmisorCalleNum") = objFactura.FEmisorCalle & " No. " & objFactura.FEmisorNoExterior
            reporte("EmisorColoniaCP") = "COL. " & objFactura.FEmisorColonia & ", C.P. " & objFactura.FEmisorCp
            reporte("EmisorMunEstadoPais") = objFactura.FEmisorMunicipio & ", " & objFactura.FEmisorEstado & ", " & objFactura.FEmisorPais

            If imprimeSucursal Then
                reporte("ExpedicionEncabezado") = "LUGAR DE EXPEDICIÓN"
                reporte("ExpedicionCalleNum") = objFactura.FEmisorCalle & " No. " & objFactura.FEmisorNoExterior
                reporte("ExpedicionColoniaCP") = "COL. " & objFactura.FEmisorColonia & ", C.P. " & objFactura.FEmisorCp
                reporte("ExpedicionMunEstadoPais") = objFactura.FEmisorMunicipio & ", " & objFactura.FEmisorEstado & ", " & objFactura.FEmisorPais
            Else
                reporte("ExpedicionEncabezado") = ""
                reporte("ExpedicionCalleNum") = ""
                reporte("ExpedicionColoniaCP") = ""
                reporte("ExpedicionMunEstadoPais") = ""

            End If

            reporte("Receptor") = objFactura.FReceptorNombre
            reporte("ReceptorCalleNumCol") = objFactura.FReceptorCalle & " # " & objFactura.FReceptorNoExterior & " COL. " & objFactura.FReceptorColonia
            reporte("ReceptorCP") = objFactura.FReceptorCp
            reporte("ReceptorMunEstadoPais") = objFactura.FReceptorMunicipio & ", " & objFactura.FReceptorEstado & ", " & objFactura.FReceptorPais
            reporte("ReceptorRFC") = objFactura.FReceptorRfc

            reporte("noCertificadoSAT") = objFactura.FNoCertificadoSAT
            reporte("noCertificado") = objFactura.FNoCertificado
            reporte("Regimen") = objFactura.FEmisorRegimen
            reporte("FechaTimbrado") = CStr(CDate(objFactura.FFechaTimbrado).ToString("yyyy-MM-ddTHH:mm:ss"))
            reporte("FormaPago") = objFactura.FFormaDePago

            Dim claveMetodoPago As String = obtenerClaveMetodoPago(objFactura.FMetodoPago.Trim)
            reporte("MetodoPago") = claveMetodoPago & " - " & objFactura.FMetodoPago

            With dtConcepto
                .Columns.Add("Cantidad")
                .Columns.Add("Unidad")
                .Columns.Add("Descripcion")
                .Columns.Add("Estilo")
                .Columns.Add("PrecioUnitario")
                .Columns.Add("Importe")
            End With
            reporte("Observacion") = objFactura.FObservacion

            For Each concepto In objConceptos
                dtConcepto.Rows.Add( _
                    concepto.CCantidad, _
                    concepto.CUnidad, _
                    concepto.CDescripcion, _
                    concepto.CEstilo, _
                    concepto.CValorUnitario, _
                    concepto.CImporte _
                )
            Next
            reporte.RegData(dtConcepto)

            cantidadLetra = EnLetras(objFactura.FTotal.ToString()).ToUpper
            auxcantidadLetra = Split(cantidadLetra, " CON ")
            If auxcantidadLetra.Length = 1 Then
                cantidadLetra = "(" & auxcantidadLetra(0) & " PESOS 00/100 M.N.)"
            Else
                cantidadLetra = "(" & auxcantidadLetra(0) & " PESOS " & auxcantidadLetra(1) & "/100 M.N.)"
            End If
            reporte("CantidadLetra") = cantidadLetra

            If objFactura.FDescuento <> 0 Then
                reporte("lblSubtotalSD") = "SubTotal"
                reporte("SubtotalSD") = objFactura.FSubtotal.ToString("C")
                reporte("lblDescuento") = "Descuento"
                reporte("Descuento") = objFactura.FDescuento.ToString("C")

                reporte("Subtotal") = objFactura.FSubtotal - objFactura.FDescuento
            Else
                reporte("lblSubtotalSD") = ""
                reporte("SubtotalSD") = ""
                reporte("lblDescuento") = ""
                reporte("Descuento") = ""

                reporte("Subtotal") = objFactura.FSubtotal
            End If
            reporte("IVA") = objFactura.FImpuestoTrasladadoImporte
            reporte("Total") = objFactura.FTotal
            reporte("CadenaOrigComplemento") = obtenerCadenaOriginalComplemento()
            reporte("CodigoQR") = generarQR()
            reporte("Sello") = objFactura.FSello
            reporte("SelloSAT") = objFactura.FSelloSat

            Select Case tipo
                Case "Factura"
                    'sPDF = rutaArchivosTemp & objFactura.FUuid & ".pdf"
                    sPDF = rutaArchivosTemp & objFactura.FEmisorRfc & "_" & objFactura.FSerie & objFactura.FFolio & ".pdf"
                Case "Cancelacion"
                    reporte("FechaCancelacion") = FechaCancelacion
                    reporte("EstatusCancelacion") = EstatusCancelacion
                    'sPDF = rutaArchivosTemp & objFactura.FUuid & "_CANCELADO.pdf"
                    sPDF = rutaArchivosTemp & objFactura.FEmisorRfc & "_" & objFactura.FSerie & objFactura.FFolio & "_CANCELADO.pdf"
            End Select

            'reporte.Show()
            reporte.Render()
            reporte.ExportDocument(StiExportFormat.Pdf, sPDF, pdfSettings)
            reporte.Dispose()

            'If Not subirFtp(Mid(rutaPDF.ToUpper.Replace(ftp.ToUpper, ""), 2), sPDF) Then
            If Not subirFtp(rutaPDF.ToUpper, sPDF) Then
                If msjError = "" Then
                    msjError = "El proceso se realizó con éxito pero no se pudo copiar el PDF al FTP. Favor de contactar al area de TI."
                Else
                    msjError = "El proceso se realizó con éxito pero no se pudo copiar el XML ni el PDF  al FTP. Favor de contactar al area de TI."
                End If
            Else
                Select Case tipo
                    Case "Factura"
                        objFactura.FPdf = rutaPDF & "/" & objFactura.FEmisorRfc & "_" & objFactura.FSerie & objFactura.FFolio & ".pdf"
                    Case "Cancelacion"
                        objFactura.FPdfCancelacion = rutaPDF & objFactura.FEmisorRfc & "_" & objFactura.FSerie & objFactura.FFolio & "_CANCELADO.pdf"
                End Select
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function generarQR() As String
        Dim codigo As String = ""
        Dim strTotal As String = ""

        strTotal = objFactura.FTotal.ToString("0000000000.000000")
        codigo = "http://?re=" & objFactura.FEmisorRfc & "&rr=" & objFactura.FReceptorRfc & "&tt=" & strTotal & "&id=" & objFactura.FUuid

        Return codigo
    End Function

    Private Function obtenerCadenaOriginalComplemento() As String
        Dim strCadOriginalSat As String = ""
        strCadOriginalSat = "||" & objFactura.FVersion & "|" & objFactura.FUuid & "|" & CStr(CDate(objFactura.FFechaTimbrado).ToString("yyyy-MM-ddTHH:mm:ss")) & "|" & objFactura.FSelloCFD & "|" & objFactura.FNoCertificadoSAT & "||"

        objFactura.FCadenaOriginalSAT = strCadOriginalSat
        Return strCadOriginalSat
    End Function

    Public Function cancelarFactura(ByVal pathXML As String, ByVal factura As Entidades.Factura, ByVal conceptos As List(Of Entidades.Conceptos), ByVal idEmpresa As Integer, ByVal idSucursal As Integer, ByVal imprimeSuc As Boolean) As Entidades.Factura
        Dim objPAC As New wcfCancelaASMX
        Dim nodo As XmlNode
        Dim Doc As New XmlDocument
        Dim Folio() As String
        Dim Resultado As String = String.Empty
        Dim sXML_Canc As String = String.Empty
        Dim sPDF_Canc As String = String.Empty
        Dim Folio_Canc As String = String.Empty
        Dim estatus As String = String.Empty

        Try
            empresaID = idEmpresa
            sucursalID = idSucursal
            objFactura = factura
            objConceptos = conceptos
            imprimeSucursal = imprimeSuc
            guidTemp = Guid.NewGuid()

            If Not obtenerDatosEmpresa() Then
                msjError = "Error al obtener los datos de la empresa."
                Return Nothing
                Exit Function
            End If

            If Not obtenerDatosSucursal() Then
                msjError = "Error al obtener los datos de la sucursal."
                Return Nothing
                Exit Function
            End If


            rutaArchivosTemp = rutaArchivosTemp & objFactura.FEmisorRfc & "\" & sucursaNombre.Replace(" ", "_") & "\Cancelaciones\"
            pathXML = descargarArchivo(pathXML)
            Folio = New String() {objFactura.FUuid}
            Resultado = objPAC.fnCancelarXML(Folio, objFactura.FEmisorRfc, 0, usuarioWS, pssWS)

            sXML_Canc = rutaArchivosTemp & IO.Path.GetFileName(pathXML.Insert(pathXML.Length - 4, "_CANCELADO"))
            File.WriteAllText(sXML_Canc, Resultado)

            Doc.Load(sXML_Canc)
            nodo = Doc.ChildNodes(0).ChildNodes(0)
            Folio_Canc = nodo.ChildNodes.Item(0).InnerText
            estatus = nodo.ChildNodes.Item(1).InnerText.Trim

            rutaXML = objFactura.FXml.Replace(System.IO.Path.GetFileName(objFactura.FXml), "")
            rutaPDF = objFactura.FXml.Replace(System.IO.Path.GetFileName(objFactura.FXml), "").Replace("XML", "PDF")
            'System.IO.Path.GetDirectoryName(objFactura.FXml.Replace("XML", "PDF"))

            If estatus = "201" Then
                'If Not subirFtp(Mid(rutaXML.ToUpper.Replace(ftp.ToUpper, ""), 2), sXML_Canc) Then
                If Not subirFtp(Mid(rutaXML.ToUpper, 2), sXML_Canc) Then
                    msjError = "El proceso se realizó con éxito pero no se pudo copiar el XML de cancelación al FTP. Favor de contactar al area de TI."
                End If

                objFactura.FUuidCancelacion = Folio_Canc
                objFactura.FFechaCancelacion = nodo.ChildNodes.Item(3).InnerText.Trim
                objFactura.FXmlCancelacion = rutaXML & IO.Path.GetFileName(sXML_Canc)
                objFactura.FReporteCancId = reporteCancId

                generarPdf("Cancelacion", reporteCancId, nodo.ChildNodes.Item(2).InnerText, nodo.ChildNodes.Item(3).InnerText)
                eliminaArchivosTemp()
                Return objFactura
            Else
                eliminaArchivosTemp()
                msjError = estatus & nodo.ChildNodes.Item(2).InnerText
                Return Nothing
            End If
        Catch ex As Exception
            msjError = "Error al cancelar la factura"
            Return Nothing
        End Try
    End Function

    Public Function regeneraPDF(ByVal facturaId As Integer, ByVal factura As Entidades.Factura, ByVal conceptos As List(Of Entidades.Conceptos), ByVal idEmpresa As Integer, ByVal idSucursal As Integer, ByVal tipo As String, ByVal impSuc As Boolean, ByVal rptID As Integer, Optional EstatusCancelacion As String = "", Optional FechaCancelacion As String = "") As Boolean
        Try
            Dim objDA As New Datos.EmpresasDA
            Dim tabla As New DataTable
            Dim objFacturaDA As New Datos.WebFacturasDA

            objFactura = factura
            objConceptos = conceptos
            empresaID = idEmpresa
            sucursalID = idSucursal
            tipoComprobante = tipo
            imprimeSucursal = impSuc
            guidTemp = Guid.NewGuid() 'Genera un identificador universal para utilizarlo temporalmente

            objFactura.FVersion = version
            objFactura.FTipoComprobante = tipoDeComprobante

            If obtenerDatosEmpresa() Then
                If obtenerDatosSucursal() Then
                    Select Case tipo
                        Case "Factura"
                            rutaArchivosTemp = rutaArchivosTemp & objFactura.FEmisorRfc & "\" & sucursaNombre.Replace(" ", "_") & "\"
                        Case "Cancelacion"
                            rutaArchivosTemp = rutaArchivosTemp & objFactura.FEmisorRfc & "\" & sucursaNombre.Replace(" ", "_") & "\Cancelaciones\"
                    End Select

                    'rutaPDF = System.IO.Path.GetDirectoryName(objFactura.FXml.Replace("XML", "PDF"))
                    rutaPDF = objFactura.FXml.Replace(System.IO.Path.GetFileName(objFactura.FXml), "").Replace("XML", "PDF")

                    rutaCer = descargarArchivo(rutaCer)
                    If rutaCer <> "" And rutaKey <> "" Then
                        If generarPdf(tipo, rptID, EstatusCancelacion, FechaCancelacion) Then
                            If facturaId <> 0 Then
                                objFacturaDA.actualizaRutaPDF(facturaId, objFactura, tipo)
                            End If

                            eliminaArchivosTemp()
                            Return True
                        Else
                            eliminaArchivosTemp()
                            msjError = "Error al obtener el certificado y el key."
                            Return False
                        End If
                    Else
                        msjError = "Error al obtener el certificado y el key."
                        Return False
                    End If
                Else
                    msjError = "Error al obtener los datos de la succursal."
                    Return False
                End If
            Else
                msjError = "Error al obtener los datos de la empresa."
                Return False
            End If
        Catch
            eliminaArchivosTemp()
            Return False
        End Try
    End Function

    Public Function EnLetras(numero As String) As String
        Dim b, paso As Integer
        Dim expresion, entero, deci, flag As String
        expresion = ""
        entero = ""
        deci = ""
        flag = ""

        flag = "N"
        For paso = 1 To Len(numero)
            If Mid(numero, paso, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, paso, 1) 'Extae la parte entera del numero
                Else
                    deci = deci + Mid(numero, paso, 1) 'Extrae la parte decimal del numero
                End If
            End If
        Next paso

        If Len(deci) = 1 Then
            deci = deci & "0"
        End If

        flag = "N"
        If Val(numero) >= -999999999 And Val(numero) <= 999999999 Then 'si el numero esta dentro de 0 a 999.999.999
            For paso = Len(entero) To 1 Step -1
                b = Len(entero) - (paso - 1)
                Select Case paso
                    Case 3, 6, 9
                        Select Case Mid(entero, b, 1)
                            Case "1"
                                If Mid(entero, b + 1, 1) = "0" And Mid(entero, b + 2, 1) = "0" Then
                                    expresion = expresion & "cien "
                                Else
                                    expresion = expresion & "ciento "
                                End If
                            Case "2"
                                expresion = expresion & "doscientos "
                            Case "3"
                                expresion = expresion & "trescientos "
                            Case "4"
                                expresion = expresion & "cuatrocientos "
                            Case "5"
                                expresion = expresion & "quinientos "
                            Case "6"
                                expresion = expresion & "seiscientos "
                            Case "7"
                                expresion = expresion & "setecientos "
                            Case "8"
                                expresion = expresion & "ochocientos "
                            Case "9"
                                expresion = expresion & "novecientos "
                        End Select

                    Case 2, 5, 8
                        Select Case Mid(entero, b, 1)
                            Case "1"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    flag = "S"
                                    expresion = expresion & "diez "
                                End If
                                If Mid(entero, b + 1, 1) = "1" Then
                                    flag = "S"
                                    expresion = expresion & "once "
                                End If
                                If Mid(entero, b + 1, 1) = "2" Then
                                    flag = "S"
                                    expresion = expresion & "doce "
                                End If
                                If Mid(entero, b + 1, 1) = "3" Then
                                    flag = "S"
                                    expresion = expresion & "trece "
                                End If
                                If Mid(entero, b + 1, 1) = "4" Then
                                    flag = "S"
                                    expresion = expresion & "catorce "
                                End If
                                If Mid(entero, b + 1, 1) = "5" Then
                                    flag = "S"
                                    expresion = expresion & "quince "
                                End If
                                If Mid(entero, b + 1, 1) > "5" Then
                                    flag = "N"
                                    expresion = expresion & "dieci"
                                End If

                            Case "2"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "veinte "
                                    flag = "S"
                                Else
                                    expresion = expresion & "veinti"
                                    flag = "N"
                                End If

                            Case "3"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "treinta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "treinta y "
                                    flag = "N"
                                End If

                            Case "4"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "cuarenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "cuarenta y "
                                    flag = "N"
                                End If

                            Case "5"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "cincuenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "cincuenta y "
                                    flag = "N"
                                End If

                            Case "6"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "sesenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "sesenta y "
                                    flag = "N"
                                End If

                            Case "7"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "setenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "setenta y "
                                    flag = "N"
                                End If

                            Case "8"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "ochenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "ochenta y "
                                    flag = "N"
                                End If

                            Case "9"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "noventa "
                                    flag = "S"
                                Else
                                    expresion = expresion & "noventa y "
                                    flag = "N"
                                End If
                        End Select

                    Case 1, 4, 7
                        Select Case Mid(entero, b, 1)
                            Case "1"
                                If flag = "N" Then
                                    If paso = 1 Then
                                        expresion = expresion & "uno "
                                    Else
                                        expresion = expresion & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then
                                    expresion = expresion & "dos "
                                End If
                            Case "3"
                                If flag = "N" Then
                                    expresion = expresion & "tres "
                                End If
                            Case "4"
                                If flag = "N" Then
                                    expresion = expresion & "cuatro "
                                End If
                            Case "5"
                                If flag = "N" Then
                                    expresion = expresion & "cinco "
                                End If
                            Case "6"
                                If flag = "N" Then
                                    expresion = expresion & "seis "
                                End If
                            Case "7"
                                If flag = "N" Then
                                    expresion = expresion & "siete "
                                End If
                            Case "8"
                                If flag = "N" Then
                                    expresion = expresion & "ocho "
                                End If
                            Case "9"
                                If flag = "N" Then
                                    expresion = expresion & "nueve "
                                End If
                        End Select
                End Select
                If paso = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                      (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                       Len(entero) <= 6) Then
                        expresion = expresion & "mil "
                    End If
                End If
                If paso = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        expresion = expresion & "millón "
                    Else
                        expresion = expresion & "millones "
                    End If
                End If
            Next paso

            If deci <> "" Then
                If Mid(entero, 1, 1) = "-" Then 'si el numero es negativo
                    EnLetras = "menos " & expresion & "con " & deci ' & "/100"
                Else
                    EnLetras = expresion & "con " & deci ' & "/100"
                End If
            Else
                If Mid(entero, 1, 1) = "-" Then 'si el numero es negativo
                    EnLetras = "menos " & expresion
                Else
                    EnLetras = expresion
                End If
            End If
        Else 'si el numero a convertir esta fuera del rango superior e inferior
            EnLetras = ""
        End If
    End Function

    Public Function validaXMLsinTimbrar(ByVal archivoXML As String) As Boolean
        Try
            Dim objFTP As New TransferenciaFTPBU
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
            If objFTP.FtpExisteArchivo(objFTP.obtenerURL & "/" & archivoXML) Then
                guidTemp = Guid.NewGuid() 'Genera un identificador universal para utilizarlo temporalmente
                Dim arcXML As String = descargarArchivo(archivoXML)
                Dim Archivo As Stream = File.Open(arcXML, FileMode.Open)
                Dim Sr As StreamReader = New StreamReader(Archivo)
                Dim strXML As String = String.Empty

                strXML = Sr.ReadToEnd()
                If (strXML.Contains("UUID=")) = True Then
                    Dim factura As XmlNode
                    Dim Doc As New XmlDocument

                    Sr.Close()
                    Doc.Load(arcXML)
                    factura = Doc.ChildNodes(1).ChildNodes(4).ChildNodes(0)

                    If factura.Attributes.GetNamedItem("UUID").Value <> "" Then
                        Return False
                        Exit Function
                    End If
                End If
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function descargarArchivoCorreo(ByVal archivo As String) As String
        Try
            Dim objFTP As New TransferenciaFTPBU
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
            Dim rutaArchivo As String = ""
            Dim nuevaRuta As String = ""
            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)

            If archivo <> "" Then
                'archivo = archivo.ToUpper.Replace(ftp.ToUpper, "")
                rutaArchivo = IO.Path.GetDirectoryName(archivo.ToUpper)
                objFTP.DescargarArchivo(rutaArchivo, rutaArchivosTemp & "Correo", IO.Path.GetFileName(archivo))
                nuevaRuta = rutaArchivosTemp & "Correo" & "\" & IO.Path.GetFileName(archivo)
            End If

            Return nuevaRuta
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Sub eliminaCarpetaTemporal(ByVal carpeta As String)
        Try
            Directory.Delete(rutaArchivosTemp & carpeta, True)
        Catch ex As Exception

        End Try
    End Sub

    Public Function generarReporteFacturacion(ByVal Datos As DataTable, ByVal sucursalId As Integer, ByVal periodo As String, ByVal strEmpresa As String, ByVal usuario As String) As String
        Try
            Dim objBU As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            EntidadReporte = objBU.LeerReporteporClave("REPORTE_FACTURACION")
            Dim archivo As String = rutaArchivosTemp & EntidadReporte.Pnombre.Trim & ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim pdfSettings = New StiPdfExportSettings()
            Dim rutaReporte As String = String.Empty
            Dim rutaFTPReporte As String = "Administracion/ConfiguracionEmpresas/ReportesFacturacion/"
            Dim reporte As New StiReport
            Dim rLogo As String = String.Empty

            Dim Facturas = New DataTable("Facturas")
            With Facturas
                .Columns.Add("NoFactura")
                .Columns.Add("Cliente")
                .Columns.Add("Fecha")
                .Columns.Add("Pares")
                .Columns.Add("Subtotal")
                .Columns.Add("Iva")
                .Columns.Add("Total")
            End With


            For Each row As DataRow In Datos.Rows
                Facturas.Rows.Add( _
                        row("FACTURA").ToString, _
                        row("CLIENTE").ToString, _
                        row("FECHA").ToString, _
                        row("PARES").ToString, _
                        row("SUBTOTAL").ToString, _
                        row("IVA").ToString, _
                        row("TOTAL").ToString _
                        )
            Next

            Dim objNave As New Negocios.SucursalesBU
            Dim tblSucursal As New Entidades.SucursalesFacturacion
            tblSucursal = objNave.getDatosSucursal(sucursalId)
            rLogo = tblSucursal.SLogo

            reporte.Load(archivo)
            reporte.Compile()
            reporte("rutaImagen") = descargarArchivo(rLogo)
            reporte("Empresa") = strEmpresa
            reporte("Periodo") = periodo
            reporte("UserName") = usuario
            reporte.RegData(Facturas)

            reporte.Render()
            guidTemp = Guid.NewGuid()
            rutaReporte = rutaArchivosTemp & "Reporte_Facturacion_" & guidTemp.ToString & ".pdf"
            reporte.ExportDocument(StiExportFormat.Pdf, rutaReporte, pdfSettings)
            reporte.Dispose()


            If Not subirFtp(rutaFTPReporte, rutaReporte) Then
                Try
                    File.Delete(rutaReporte)
                Catch
                End Try
                Return ""
            Else
                Try
                    File.Delete(rutaReporte)
                Catch
                End Try
                'Return ftp & "/" & rutaFTPReporte & System.IO.Path.GetFileName(rutaReporte)
                Return rutaFTPReporte & System.IO.Path.GetFileName(rutaReporte)
            End If
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Function obtenerClaveMetodoPago(ByVal strMetodoPago As String) As String
        Dim claveMetodoPago As String = String.Empty

        Select Case strMetodoPago
            Case "EFECTIVO"
                claveMetodoPago = "01"
            Case "CHEQUE NOMINATIVO"
                claveMetodoPago = "02"
            Case "TRANSFERENCIA ELECTRONICA DE FONDOS"
                claveMetodoPago = "03"
            Case "TARJETA DE CREDITO"
                claveMetodoPago = "04"
            Case "MONEDERO ELECTRONICO"
                claveMetodoPago = "05"
            Case "DINERO ELECTRONICO"
                claveMetodoPago = "06"
            Case "VALES DE DESPENSA"
                claveMetodoPago = "08"
            Case "TARJETA DE DEBITO"
                claveMetodoPago = "28"
            Case "TARJETA DE SERVICIO"
                claveMetodoPago = "29"
            Case "NO APLICA"
                claveMetodoPago = "NA"
            Case Else
                claveMetodoPago = "99"
        End Select

        Return claveMetodoPago
    End Function
End Class