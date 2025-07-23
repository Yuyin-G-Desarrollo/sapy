Imports System.IO
Imports System.Net
Imports System.Xml

Public Class TimbradoBU

    Public VersionFacturacion As String = String.Empty
    Private RutaArchivoXSLT_3_3 As String = String.Empty
    Private DirectorioRutaCadenaOriginal As String = String.Empty
    Private DirectorioRutaArchivoSHA As String = String.Empty
    Private DirectorioRutaArchivoSELLO As String = String.Empty
    Private RutaOpenSSL As String = String.Empty
    Public RFCPrueba As String = String.Empty
    Public RutaArchivosTemp As String = String.Empty
    Private TimbradoPrueba As Boolean = False
    Public mensaje As String = String.Empty


    Private objDA As New Facturacion.Datos.TimbradoDA
    Private _EntidadEmpresa As Entidades.Empresas

    Private EntEmpresa As New Entidades.Empresas
    Public Property _EntEmpresa() As Entidades.Empresas
        Get
            Return EntEmpresa
        End Get
        Set(ByVal value As Entidades.Empresas)
            EntEmpresa = value
        End Set
    End Property

    ''' <summary>
    ''' Cargar las opciones de configuracion y la informacion de la empresa
    ''' </summary>
    ''' <param name="EmpresaID">EmpresaID</param>
    ''' <param name="EsTimbradoPrueba">True => Timbrado de Prueba, False => Timbrado produccion.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal EmpresaID As Integer, Optional ByVal EsTimbradoPrueba As Boolean = True)

        Try
            TimbradoPrueba = EsTimbradoPrueba
            If TimbradoPrueba = True Then
                EmpresaID = 19
            End If

            Dim dtEmpresa = objDA.getDatosEmpresa(EmpresaID)
            Dim dtDatosConfiguracion As DataTable = objDA.getDatosConfiguracionTimbrado()

            If dtDatosConfiguracion.Rows.Count > 0 Then
                VersionFacturacion = dtDatosConfiguracion.AsEnumerable().Where(Function(x) x.Item("opci_descripcion") = "Version").Select(Function(y) y.Item("opci_valor_cadena")).FirstOrDefault
                RutaArchivoXSLT_3_3 = dtDatosConfiguracion.AsEnumerable().Where(Function(x) x.Item("opci_descripcion") = "CadenaXSLT3.3").Select(Function(y) y.Item("opci_valor_cadena")).FirstOrDefault
                DirectorioRutaArchivoSHA = dtDatosConfiguracion.AsEnumerable().Where(Function(x) x.Item("opci_descripcion") = "ArchivoSHA").Select(Function(y) y.Item("opci_valor_cadena")).FirstOrDefault
                DirectorioRutaArchivoSELLO = dtDatosConfiguracion.AsEnumerable().Where(Function(x) x.Item("opci_descripcion") = "ArchivoSello").Select(Function(y) y.Item("opci_valor_cadena")).FirstOrDefault
                DirectorioRutaCadenaOriginal = dtDatosConfiguracion.AsEnumerable().Where(Function(x) x.Item("opci_descripcion") = "ArchivoCadenaOriginal").Select(Function(y) y.Item("opci_valor_cadena")).FirstOrDefault
                RutaOpenSSL = dtDatosConfiguracion.AsEnumerable().Where(Function(x) x.Item("opci_descripcion") = "RutaOpenSSL").Select(Function(y) y.Item("opci_valor_cadena")).FirstOrDefault
                RFCPrueba = dtDatosConfiguracion.AsEnumerable().Where(Function(x) x.Item("opci_descripcion") = "RFCPrueba").Select(Function(y) y.Item("opci_valor_cadena")).FirstOrDefault
                RutaArchivosTemp = dtDatosConfiguracion.AsEnumerable().Where(Function(x) x.Item("opci_descripcion") = "DirectorioArchivoTMP").Select(Function(y) y.Item("opci_valor_cadena")).FirstOrDefault
            End If

            For Each row As DataRow In dtEmpresa.Rows
                EntEmpresa.Nombre = row("empr_nombre")
                EntEmpresa.RFC = row("empr_rfc")
                EntEmpresa.RutaKEY = row("empr_rutakey")
                EntEmpresa.RutaCertificado = row("empr_rutacertificado")
                EntEmpresa.WebService = row("empr_webservice")
                EntEmpresa.UsuarioWS = row("empr_usuariows")
                EntEmpresa.ContraseñaWS = row("empr_contrasenaws")
                EntEmpresa.ContraseñaCertificado = row("empr_contrasenacertificado")
                EntEmpresa.CertificadoVigenciaInicio = row("empr_certificadovigenciainicio")
                EntEmpresa.RutaXML = row("empr_rutaxmlcalzado")
                EntEmpresa.RutaPDF = row("empr_rutapdfcalzado")
                EntEmpresa.CadenaCertificado = row("empr_cadenacertificado")
                EntEmpresa.NumeroCertificado = row("empr_numerocertificado")
                EntEmpresa.ClaveRegimen = row("empr_claveRegimen")
                EntEmpresa.Calle = row("empr_calle")
                EntEmpresa.CertificadovigenciaFin = row("empr_certificadovigenciafin")
                EntEmpresa.Colonia = row("empr_colonia")
                EntEmpresa.CP = row("empr_cp")
                EntEmpresa.CURP = row("empr_curp")
                EntEmpresa.EmpresaID = row("empr_empresaid")
                EntEmpresa.IdentificadorPAX = row("empr_identificadorPax")
                EntEmpresa.Numero = row("empr_numero")
                EntEmpresa.RazonSocial = row("empr_razonsocial")
                EntEmpresa.Regimen = row("empr_regimen")
                EntEmpresa.Serie = row("empr_serie")
                EntEmpresa.TasaIVA = row("empr_tasaiva")
                EntEmpresa.TasaIVAEncabezado = row("empr_tasaivaencabezado")
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub New(ByVal EmpresaID As Integer)
        If TimbradoPrueba = True Then
            EmpresaID = 19
        End If

        Dim dtEmpresa = objDA.getDatosEmpresa(EmpresaID)
        Dim dtDatosConfiguracion As DataTable = objDA.getDatosConfiguracionTimbrado()

        If dtDatosConfiguracion.Rows.Count > 0 Then
            VersionFacturacion = dtDatosConfiguracion.AsEnumerable().Where(Function(x) x.Item("opci_descripcion") = "Version").Select(Function(y) y.Item("opci_valor_cadena")).FirstOrDefault
            RutaArchivoXSLT_3_3 = dtDatosConfiguracion.AsEnumerable().Where(Function(x) x.Item("opci_descripcion") = "CadenaXSLT3.3").Select(Function(y) y.Item("opci_valor_cadena")).FirstOrDefault
            DirectorioRutaArchivoSHA = dtDatosConfiguracion.AsEnumerable().Where(Function(x) x.Item("opci_descripcion") = "ArchivoSHA").Select(Function(y) y.Item("opci_valor_cadena")).FirstOrDefault
            DirectorioRutaArchivoSELLO = dtDatosConfiguracion.AsEnumerable().Where(Function(x) x.Item("opci_descripcion") = "ArchivoSello").Select(Function(y) y.Item("opci_valor_cadena")).FirstOrDefault
            DirectorioRutaCadenaOriginal = dtDatosConfiguracion.AsEnumerable().Where(Function(x) x.Item("opci_descripcion") = "ArchivoCadenaOriginal").Select(Function(y) y.Item("opci_valor_cadena")).FirstOrDefault
            RutaOpenSSL = dtDatosConfiguracion.AsEnumerable().Where(Function(x) x.Item("opci_descripcion") = "RutaOpenSSL").Select(Function(y) y.Item("opci_valor_cadena")).FirstOrDefault
            RFCPrueba = dtDatosConfiguracion.AsEnumerable().Where(Function(x) x.Item("opci_descripcion") = "RFCPrueba").Select(Function(y) y.Item("opci_valor_cadena")).FirstOrDefault
            RutaArchivosTemp = dtDatosConfiguracion.AsEnumerable().Where(Function(x) x.Item("opci_descripcion") = "DirectorioArchivoTMP").Select(Function(y) y.Item("opci_valor_cadena")).FirstOrDefault
        End If

        For Each row As DataRow In dtEmpresa.Rows
            EntEmpresa.Nombre = row("empr_nombre")
            EntEmpresa.RFC = row("empr_rfc")
            EntEmpresa.RutaKEY = row("empr_rutakey")
            EntEmpresa.WebService = row("empr_webservice")
            EntEmpresa.UsuarioWS = row("empr_usuariows")
            EntEmpresa.ContraseñaWS = row("empr_contrasenaws")
            EntEmpresa.ContraseñaCertificado = row("empr_contrasenacertificado")
            EntEmpresa.CertificadoVigenciaInicio = row("empr_certificadovigenciainicio")
            EntEmpresa.RutaXML = row("empr_rutaxmlcalzado")
            EntEmpresa.RutaPDF = row("empr_rutapdfcalzado")
            EntEmpresa.CadenaCertificado = row("empr_cadenacertificado")
            EntEmpresa.NumeroCertificado = row("empr_numerocertificado")
            EntEmpresa.ClaveRegimen = row("empr_claveRegimen")
            EntEmpresa.Calle = row("empr_calle")
            EntEmpresa.CertificadovigenciaFin = row("empr_certificadovigenciafin")
            EntEmpresa.Colonia = row("empr_colonia")
            EntEmpresa.CP = row("empr_cp")
            EntEmpresa.CURP = row("empr_curp")
            EntEmpresa.EmpresaID = row("empr_empresaid")
            EntEmpresa.IdentificadorPAX = row("empr_identificadorPax")
            EntEmpresa.Numero = row("empr_numero")
            EntEmpresa.RazonSocial = row("empr_razonsocial")
            EntEmpresa.Regimen = row("empr_regimen")
            EntEmpresa.Serie = row("empr_serie")
            EntEmpresa.TasaIVA = row("empr_tasaiva")
            EntEmpresa.TasaIVAEncabezado = row("empr_tasaivaencabezado")
        Next



    End Sub

    ''' <summary>
    ''' Genera cadena Original a partir del archivo XML
    ''' </summary>
    ''' <param name="RutaXML">Ruta del Archivo XML</param>
    ''' <returns>regresa la cadena original, en caso de error manda una cadena vacía</returns>
    ''' <remarks></remarks>
    Public Function GenerarCadenaOriginal(ByVal RutaXML As String, ByVal DocumentoID As Integer, ByVal TipoComprobante As String) As String
        Dim xmlDoc As New System.Xml.XmlDocument
        Dim transformer As System.Xml.Xsl.XslCompiledTransform
        Dim document As New System.Xml.XmlDocument
        Dim navigator As System.Xml.XPath.XPathNavigator
        Dim output As New System.IO.StringWriter()
        Dim strCadenaOriginal As String = String.Empty
        Dim rutaTemporalXSLT As String = String.Empty

        document = New System.Xml.XmlDocument()
        transformer = New System.Xml.Xsl.XslCompiledTransform

        Try

            If File.Exists(RutaArchivoXSLT_3_3) = True Then
                'rutaTemporalXSLT = Path.GetDirectoryName(RutaArchivoXSLT_3_3)
                'rutaTemporalXSLT = rutaTemporalXSLT & Path.GetFileNameWithoutExtension(RutaArchivoXSLT_3_3) & "_" & DocumentoID.ToString() & "_" & TipoComprobante & "." & Path.GetExtension(RutaArchivoXSLT_3_3)
                rutaTemporalXSLT = RutaArchivoXSLT_3_3.Insert(RutaArchivoXSLT_3_3.Length - 5, "_" & DocumentoID.ToString() & "_" & TipoComprobante)
                File.Copy(RutaArchivoXSLT_3_3, rutaTemporalXSLT, True)
            End If

            document.Load(RutaXML)
            navigator = document.CreateNavigator
            transformer.Load(rutaTemporalXSLT)
            transformer.Transform(navigator, Nothing, output)
            Console.WriteLine(output.ToString)
            strCadenaOriginal = output.ToString
            output.Close()




        Catch ex As Exception
            strCadenaOriginal = String.Empty
            Throw ex
        Finally
            document = Nothing
            transformer = Nothing
            navigator = Nothing
            output.Dispose()

            If File.Exists(rutaTemporalXSLT) = True Then
                File.Delete(rutaTemporalXSLT)
            End If
        End Try

        Return strCadenaOriginal

    End Function

    ''' <summary>
    ''' Genera el SELLO a partir de la cadena Orignal
    ''' </summary>
    ''' <param name="RutaXML">Ruta del Archivo XML</param>
    ''' <param name="CadenaOriginal">Cadena Orignal</param>
    ''' <param name="DocumentoID">Documeto ID</param>    
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GeneraSello(ByVal RutaXML As String, ByVal CadenaOriginal As String, ByVal DocumentoID As Integer, ByVal TipoComprobante As String) As String

        Dim process1 As New Process
        Dim process2 As New Process
        Dim process3 As New Process
        Dim RutaCertificado As String = String.Empty
        Dim RutaKeyCertificado As String = String.Empty
        Dim PassCertificado As String = String.Empty
        Dim ArchivoCadenaOriginal As String = String.Empty
        Dim RutaCertificadoPem As String = String.Empty
        Dim RutaKeyCertificadoPem As String = String.Empty
        Dim RutaSHA As String = String.Empty
        Dim RutaSELLO As String = String.Empty
        Dim SelloBase64 As String = String.Empty

        'RutaKeyCertificado = ObtenerRutaKey(EmpresaID)
        'RutaCertificado = ObtenerRutaCertificado(EmpresaID)
        'PassCertificado = ObtenerPassKey(EmpresaID)

        Try

            RutaKeyCertificado = EntEmpresa.RutaKEY.Trim()
            RutaCertificado = EntEmpresa.RutaCertificado.Trim
            PassCertificado = EntEmpresa.ContraseñaCertificado.Trim()

            RutaKeyCertificadoPem = RutaKeyCertificado & ".pem"
            RutaCertificadoPem = RutaCertificado & ".pem"
            ArchivoCadenaOriginal = DirectorioRutaCadenaOriginal & "CadenaOriginal_" & TipoComprobante & "_" & DocumentoID.ToString() & ".txt"
            RutaSHA = DirectorioRutaArchivoSHA & "ArchivoSHA_" & TipoComprobante & "_" & DocumentoID.ToString() & ".txt"
            RutaSELLO = DirectorioRutaArchivoSELLO & "ArchivoSello_" & TipoComprobante & "_" & DocumentoID.ToString() & ".txt"

            crearArchivoTemporal(ArchivoCadenaOriginal)
            crearArchivoTemporal(RutaSHA)
            crearArchivoTemporal(RutaSELLO)

            File.WriteAllText(ArchivoCadenaOriginal, CadenaOriginal)
            'Crea un archivo con la cadena del key
            process1.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
            process1.StartInfo.FileName = RutaOpenSSL
            process1.StartInfo.Arguments = "pkcs8 -inform DER -in " & RutaKeyCertificado & " -passin pass:" & PassCertificado & " -out " & RutaKeyCertificadoPem
            process1.StartInfo.WorkingDirectory = System.AppDomain.CurrentDomain.BaseDirectory()
            process1.StartInfo.UseShellExecute = False
            process1.StartInfo.ErrorDialog = False
            process1.StartInfo.RedirectStandardOutput = True
            process1.StartInfo.CreateNoWindow = True
            process1.Start()
            process1.WaitForExit()

            'Crea archivo del certificado con SHA1
            process2.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
            process2.StartInfo.FileName = RutaOpenSSL
            process2.StartInfo.Arguments = "dgst -SHA256 -sign " & RutaKeyCertificadoPem & " -out " & RutaSHA & " " & ArchivoCadenaOriginal
            process2.StartInfo.WorkingDirectory = System.AppDomain.CurrentDomain.BaseDirectory()
            process2.StartInfo.UseShellExecute = False
            process2.StartInfo.ErrorDialog = False
            process2.StartInfo.RedirectStandardOutput = True
            process2.StartInfo.CreateNoWindow = True
            process2.Start()
            process2.WaitForExit()

            'Crea archivo con el sello en base 64
            process3.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
            process3.StartInfo.FileName = RutaOpenSSL
            process3.StartInfo.Arguments = "enc -base64 -in " & RutaSHA & " -out " & RutaSELLO
            process3.StartInfo.WorkingDirectory = System.AppDomain.CurrentDomain.BaseDirectory()
            process3.StartInfo.UseShellExecute = False
            process3.StartInfo.ErrorDialog = False
            process3.StartInfo.RedirectStandardOutput = True
            process3.StartInfo.CreateNoWindow = True
            process3.Start()
            process3.WaitForExit()

            'Agregar la cadena del sello a la variable String
            SelloBase64 = File.ReadAllText(RutaSELLO)
            'Quita los saltos de línea
            SelloBase64 = Replace(SelloBase64, Chr(10), "")
            'Quita los retornos de carro
            SelloBase64 = Replace(SelloBase64, Chr(13), "")
            'Asigna a FSello la cadena del certificado sin espacios
        Catch ex As Exception
            SelloBase64 = String.Empty
            Throw ex
        End Try

        Return SelloBase64
    End Function

    ''' <summary>
    ''' Generar la ruta de un archivo si no existe
    ''' </summary>
    ''' <param name="archivo">Ruta del archivo</param>
    ''' <returns>La ruta del archivo generada, o mensaje de error</returns>
    ''' <remarks></remarks>
    Private Function crearArchivoTemporal(ByVal archivo As String) As String
        Try
            If Dir(RutaArchivosTemp) = vbNullString Then
                Directory.CreateDirectory(RutaArchivosTemp)
            End If
            If File.Exists(archivo) = False Then
                Dim fichero As New IO.FileStream(archivo, IO.FileMode.Create)
                fichero.Close()
            End If
            Return archivo
        Catch ex As Exception
            Throw ex
            Return "Error"
        End Try
    End Function

    ''' <summary>
    ''' Agregar el sello generado en el archivo XML
    ''' </summary>
    ''' <param name="RutaXML">Ruta del Archivo XML</param>
    ''' <param name="Sello">Sello</param>
    ''' <returns>True si el Sello se agrego correctamente al archivo XML</returns>
    ''' <remarks></remarks>
    Public Function AgregarSelloXML(ByVal RutaXML As String, ByVal Sello As String) As Boolean
        Dim Resultado As Boolean = True

        Try
            Dim Factura As XmlNode
            Dim Doc As New XmlDocument
            Dim obj As New Facturacion.Negocios.FacturasBU
            Dim sXML As String = RutaXML
            Dim Certificado As String = String.Empty
            Certificado = EntEmpresa.CadenaCertificado

            Doc.Load(sXML)
            Factura = Doc.ChildNodes(1)
            Factura.Attributes.GetNamedItem("Certificado").Value = Certificado.Trim
            Factura.Attributes.GetNamedItem("Sello").Value = Sello
            Doc.Save(sXML)
            Resultado = True

        Catch ex As Exception
            Resultado = False
            Throw ex
        End Try

        Return Resultado
    End Function

    ''' <summary>
    ''' Realiza el timbrado del XML
    ''' </summary>
    ''' <param name="sXML">Ruta XML</param>    
    ''' <param name="DocumentoID">documento ID</param>
    ''' <param name="TipoComprobante">FACTURACALZADO, NOTACREDITO</param>
    ''' <returns>True => si el timbrado fue exitoso, False=> Si ocurrio un error al timbrar el XML</returns>
    ''' <remarks></remarks>
    Public Function GenerarTimbrado(ByVal sXML As String, ByVal DocumentoID As Integer, ByVal TipoComprobante As String) As String
        Try
            Dim REsultado As Boolean = False
            If TimbradoPrueba = True Then
                REsultado = TimbrarPrueba(sXML, DocumentoID, TipoComprobante)
            Else
                REsultado = Timbrar(sXML, DocumentoID, TipoComprobante)
            End If

            Return REsultado
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    ''' <summary>
    ''' Realiza el timbrado del XML
    ''' </summary>
    ''' <param name="sXML">Ruta XML</param>    
    ''' <param name="DocumentoID">documento ID</param>
    ''' <param name="TipoComprobante">FACTURACALZADO, NOTACREDITO</param>
    ''' <returns>True => Si el timbrado del XML fue exitoso, FALSE => Si ocurrio un error al timbrar el XML.</returns>
    ''' <remarks></remarks>
    Private Function Timbrar(ByVal sXML As String, ByVal DocumentoID As Integer, ByVal TipoComprobante As String) As Boolean
        Dim Resultado As Boolean = False
        Dim MensajeError As String()
        Dim UsuarioWS As String = String.Empty
        Dim pssWS As String = String.Empty
        Dim ClaveTipoComprobante As String = String.Empty


        Try
            UsuarioWS = EntEmpresa.UsuarioWS
            pssWS = EntEmpresa.ContraseñaWS

            If TimbradoPrueba = True Then
                Dim ws As New mx.com.paxfacturacion.test.wcfRecepcionASMX

                'Cliente.Credentials = New System.Net.NetworkCredential("Hector.GE8308", "Goe.Hector8308")
                Dim Archivo As Stream = File.Open(sXML, FileMode.Open)
                Dim Sr As StreamReader = New StreamReader(Archivo)
                Dim strXML As String = ""
                Dim strXMLTimbrado As String = ""
                ClaveTipoComprobante = ObtenerClaveTipoComprobante(TipoComprobante)
                strXML = Sr.ReadToEnd()
                'Quita el encabezado
                strXML = Replace(strXML, "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & " standalone=" & Chr(34) & "no" & Chr(34) & "?>", "")
                strXML = Replace(Mid(strXML, 1, Len(strXML)), (Chr(13) + Chr(10)), "")
                strXMLTimbrado = ws.fnEnviarXML(strXML, ClaveTipoComprobante, 0, UsuarioWS, pssWS, VersionFacturacion)
                Archivo.Close()

                If (strXMLTimbrado.Contains("<cfdi:Comprobante")) = True Then
                    'Agrega nuevamente el encabezado
                    strXML = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & " standalone=" & Chr(34) & "no" & Chr(34) & "?> " & strXMLTimbrado
                    File.WriteAllText(sXML, strXML)
                    Resultado = True
                Else
                    MensajeError = Split(strXMLTimbrado, "-")
                    If MensajeError.Length > 1 Then
                        objDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, MensajeError(0).ToString, strXMLTimbrado.ToString.Trim)
                        mensaje = MensajeError(1).ToString()
                    Else
                        objDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, "NA", strXMLTimbrado.ToString.Trim())
                        mensaje = "NA " & strXMLTimbrado.ToString().Trim()
                    End If
                    Resultado = False
                End If
            Else
                '*******prueba
                'Dim ws As New mx.com.paxfacturacion.test.wcfRecepcionASMX
                '******produccion
                Dim ws As New mx.com.paxfacturacion.www.wcfRecepcionASMX
                'Cliente.Credentials = New System.Net.NetworkCredential("Hector.GE8308", "Goe.Hector8308")
                Dim Archivo As Stream = File.Open(sXML, FileMode.Open)
                Dim Sr As StreamReader = New StreamReader(Archivo)
                Dim strXML As String = ""
                Dim strXMLTimbrado As String = ""

                ClaveTipoComprobante = ObtenerClaveTipoComprobante(TipoComprobante)

                strXML = Sr.ReadToEnd()
                'Quita el encabezado
                strXML = Replace(strXML, "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & " standalone=" & Chr(34) & "no" & Chr(34) & "?>", "")
                strXML = Replace(Mid(strXML, 1, Len(strXML)), (Chr(13) + Chr(10)), "")
                strXMLTimbrado = ws.fnEnviarXML(strXML, ClaveTipoComprobante, 0, UsuarioWS, pssWS, VersionFacturacion)
                Archivo.Close()

                If (strXMLTimbrado.Contains("<cfdi:Comprobante")) = True Then
                    'Agrega nuevamente el encabezado
                    strXML = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & " standalone=" & Chr(34) & "no" & Chr(34) & "?> " & strXMLTimbrado
                    File.WriteAllText(sXML, strXML)
                    Resultado = True
                Else
                    MensajeError = Split(strXMLTimbrado, "-")
                    If MensajeError.Length > 1 Then
                        objDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, MensajeError(0).ToString, strXMLTimbrado.ToString.Trim())
                        mensaje = MensajeError(1).ToString()
                    Else
                        objDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, "NA", strXMLTimbrado.ToString.Trim())
                        mensaje = "NA " & strXMLTimbrado.ToString().Trim()
                    End If
                    Resultado = False
                End If
            End If

        Catch ex As Exception
            Resultado = False
            Throw ex
        End Try
        Return Resultado
    End Function

    ''' <summary>
    ''' Realiza el timbrado del XML
    ''' </summary>
    ''' <param name="sXML">Ruta XML</param>    
    ''' <param name="DocumentoID">documento ID</param>
    ''' <param name="TipoComprobante">FACTURACALZADO, Nota de CREDITO</param>
    ''' <returns>True => Si el Timbrado fue Exitoso, False => si ocurrio un error al timbrar el XML.</returns>
    ''' <remarks></remarks>
    Private Function TimbrarPrueba(ByVal sXML As String, ByVal DocumentoID As Integer, ByVal TipoComprobante As String) As Boolean
        Dim Resultado As Boolean = False
        Dim MensajeError As String()
        Dim UsuarioWS As String = String.Empty
        Dim pssWS As String = String.Empty
        Dim ClaveTipoComprobante As String = String.Empty

        Try
            UsuarioWS = EntEmpresa.UsuarioWS
            pssWS = EntEmpresa.ContraseñaWS

            ServicePointManager.SecurityProtocol = 3072

            Dim ws As New mx.com.paxfacturacion.test.wcfRecepcionASMX
            'Cliente.Credentials = New System.Net.NetworkCredential("Hector.GE8308", "Goe.Hector8308")
            Dim Archivo As Stream = File.Open(sXML, FileMode.Open)
            Dim Sr As StreamReader = New StreamReader(Archivo)
            Dim strXML As String = ""
            Dim strXMLTimbrado As String = ""

            ClaveTipoComprobante = ObtenerClaveTipoComprobante(TipoComprobante)


            strXML = Sr.ReadToEnd()
            'Quita el encabezado
            strXML = Replace(strXML, "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & " standalone=" & Chr(34) & "no" & Chr(34) & "?>", "")
            strXML = Replace(Mid(strXML, 1, Len(strXML)), (Chr(13) + Chr(10)), "")
            strXMLTimbrado = ws.fnEnviarXML(strXML, ClaveTipoComprobante, 0, UsuarioWS, pssWS, VersionFacturacion)
            Archivo.Close()

            If (strXMLTimbrado.Contains("<cfdi:Comprobante")) = True Then
                'Agrega nuevamente el encabezado
                strXML = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & " standalone=" & Chr(34) & "no" & Chr(34) & "?> " & strXMLTimbrado
                File.WriteAllText(sXML, strXML)
                Resultado = True
            Else
                MensajeError = Split(strXMLTimbrado, "-")
                If MensajeError.Length > 1 Then
                    objDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, MensajeError(0).ToString, MensajeError(1).ToString())
                    mensaje = MensajeError(1).ToString()
                Else
                    objDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, "NA", strXMLTimbrado.ToString.Trim())
                    mensaje = "NA " & strXMLTimbrado.ToString().Trim()
                End If

                Resultado = False
            End If

        Catch ex As Exception
            Resultado = False
            Throw ex
        End Try
        Return Resultado
    End Function

    Public Function ObtenerClaveTipoComprobante(ByVal TipoComprobante As String) As String
        Dim ClaveDocumento As String = String.Empty
        Dim objDA As New Datos.TimbradoDA
        Dim dtResultado As New DataTable

        dtResultado = objDA.ObtenerClaveTipoComprobante(TipoComprobante)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                ClaveDocumento = dtResultado.Rows(0).Item("ClaveTipoComprobante").ToString()
            End If
        End If
        Return ClaveDocumento
    End Function

    Public Function ObtenerDatosDelComplemento(ByVal DocumentoID As Integer, ByVal RutaXML As String, ByVal CadenaOriginal As String, ByVal TipoComprobante As String) As Boolean

        Dim Resultado As Boolean = True
        Dim objDA As New Facturacion.Datos.TimbradoDA

        Try
            Dim UUID As String = String.Empty
            Dim FechaTimbradoFormato As String = String.Empty
            Dim FechaTimbradoSinFormato As String = String.Empty
            Dim SelloSAT As String = String.Empty
            Dim SelloCFD As String = String.Empty
            Dim SerieCertificadoSAT As String = String.Empty
            Dim SerieCertificadoEmisor As String = String.Empty
            Dim CadenaOrignalComplemento As String = String.Empty
            Dim VersionComplemento As String = String.Empty
            Dim RFCProveedor As String = String.Empty
            Dim doc As New XmlDocument()
            Dim Factura As XmlNode
            Dim TimbreFiscal As XmlNode


            doc.Load(RutaXML)
            Dim xmlmanager As System.Xml.XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)
            xmlmanager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
            xmlmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
            Dim Fila As Integer = 0
            Factura = doc.ChildNodes(1)
            SerieCertificadoEmisor = Factura.Attributes.GetNamedItem("NoCertificado").Value
            Dim nodo As XmlNode = Factura.SelectSingleNode("cfdi:Complemento", xmlmanager)
            TimbreFiscal = nodo.ChildNodes(0)
            UUID = TimbreFiscal.Attributes.GetNamedItem("UUID").Value
            FechaTimbradoFormato = TimbreFiscal.Attributes.GetNamedItem("FechaTimbrado").Value
            SelloSAT = TimbreFiscal.Attributes.GetNamedItem("SelloSAT").Value
            SelloCFD = TimbreFiscal.Attributes.GetNamedItem("SelloCFD").Value
            VersionComplemento = TimbreFiscal.Attributes.GetNamedItem("Version").Value
            SerieCertificadoSAT = TimbreFiscal.Attributes.GetNamedItem("NoCertificadoSAT").Value
            RFCProveedor = TimbreFiscal.Attributes.GetNamedItem("RfcProvCertif").Value
            FechaTimbradoSinFormato = QuitarFormatoFecha(FechaTimbradoFormato)
            CadenaOrignalComplemento = "||" & VersionComplemento.Trim() & "|" & UUID & "|" & FechaTimbradoFormato & "|" & SelloCFD & "|" & SerieCertificadoSAT & "||"

            If TipoComprobante = "NOTACREDITODEVOLUCION" Then
                objDA.ActualizaDatosTimbradoNotasCreditoDevolucion(DocumentoID, UUID, FechaTimbradoFormato, RutaXML, "", CadenaOriginal, SelloSAT, SelloCFD, SerieCertificadoSAT, TipoComprobante, CadenaOrignalComplemento, RFCProveedor)
                objDA.actualizaInformacionTimbradaAtributos(DocumentoID, TipoComprobante, UUID, FechaTimbradoFormato, SelloCFD, SelloSAT, CadenaOriginal, SerieCertificadoSAT, CadenaOrignalComplemento, SerieCertificadoEmisor)
            Else
                objDA.ActualizarInformacionDocumentoTimbrado(DocumentoID, FechaTimbradoFormato, UUID, RutaXML, "", FechaTimbradoSinFormato, CadenaOriginal, SelloSAT, SelloCFD, SerieCertificadoSAT, SerieCertificadoEmisor, EntEmpresa.EmpresaID, TipoComprobante, CadenaOrignalComplemento, RFCProveedor)
            End If

            If TimbradoPrueba = False Then
                objDA.ActualizarInformacionTimbradoSICY(DocumentoID, SelloCFD, FechaTimbradoSinFormato, CadenaOrignalComplemento, SerieCertificadoSAT, UUID, Date.Now.Year.ToString, TipoComprobante)
            Else
                If TipoComprobante = "COMPLEMENTOPAGO" Then
                    objDA.ActualizarInformacionTimbradoSICY(DocumentoID, SelloCFD, FechaTimbradoSinFormato, CadenaOrignalComplemento, SerieCertificadoSAT, UUID, Date.Now.Year.ToString, TipoComprobante)
                End If
            End If

            Resultado = True
        Catch ex As Exception
            Resultado = False
            Throw ex
        Finally
            objDA = Nothing
        End Try

        Return Resultado

    End Function

    Public Function ObtenerDatosDelComplementoExterno(ByVal DocumentoID As Integer, ByVal RutaXML As String, ByVal CadenaOriginal As String, ByVal TipoComprobante As String) As Boolean

        Dim Resultado As Boolean = True
        Dim objDA As New Facturacion.Datos.TimbradoDA

        Try
            Dim UUID As String = String.Empty
            Dim FechaTimbradoFormato As String = String.Empty
            Dim FechaTimbradoSinFormato As String = String.Empty
            Dim SelloSAT As String = String.Empty
            Dim SelloCFD As String = String.Empty
            Dim SerieCertificadoSAT As String = String.Empty
            Dim SerieCertificadoEmisor As String = String.Empty
            Dim CadenaOrignalComplemento As String = String.Empty
            Dim VersionComplemento As String = String.Empty
            Dim RFCProveedor As String = String.Empty
            Dim TotalUSD As String = String.Empty
            Dim doc As New XmlDocument()
            Dim Factura As XmlNode
            Dim TimbreFiscal As XmlNode


            doc.Load(RutaXML)
            Dim xmlmanager As System.Xml.XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)
            xmlmanager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
            xmlmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
            Dim Fila As Integer = 0
            Factura = doc.ChildNodes(1)
            SerieCertificadoEmisor = Factura.Attributes.GetNamedItem("NoCertificado").Value
            Dim nodo As XmlNode = Factura.SelectSingleNode("cfdi:Complemento", xmlmanager)


            TimbreFiscal = nodo.ChildNodes(1)
            UUID = TimbreFiscal.Attributes.GetNamedItem("UUID").Value
            FechaTimbradoFormato = TimbreFiscal.Attributes.GetNamedItem("FechaTimbrado").Value
            SelloSAT = TimbreFiscal.Attributes.GetNamedItem("SelloSAT").Value
            SelloCFD = TimbreFiscal.Attributes.GetNamedItem("SelloCFD").Value
            VersionComplemento = TimbreFiscal.Attributes.GetNamedItem("Version").Value
            SerieCertificadoSAT = TimbreFiscal.Attributes.GetNamedItem("NoCertificadoSAT").Value
            RFCProveedor = TimbreFiscal.Attributes.GetNamedItem("RfcProvCertif").Value
            FechaTimbradoSinFormato = QuitarFormatoFecha(FechaTimbradoFormato)
            CadenaOrignalComplemento = "||" & VersionComplemento.Trim() & "|" & UUID & "|" & FechaTimbradoFormato & "|" & SelloCFD & "|" & SerieCertificadoSAT & "||"
            objDA.ActualizarInformacionDocumentoTimbrado(DocumentoID, FechaTimbradoFormato, UUID, RutaXML, "", FechaTimbradoSinFormato, CadenaOriginal, SelloSAT, SelloCFD, SerieCertificadoSAT, SerieCertificadoEmisor, EntEmpresa.EmpresaID, TipoComprobante, CadenaOrignalComplemento, RFCProveedor)



            If TimbradoPrueba = False Then
                objDA.ActualizarInformacionTimbradoSICY(DocumentoID, SelloCFD, FechaTimbradoSinFormato, CadenaOrignalComplemento, SerieCertificadoSAT, UUID, Date.Now.Year.ToString, TipoComprobante)
            Else
                If TipoComprobante = "COMPLEMENTOPAGO" Then
                    objDA.ActualizarInformacionTimbradoSICY(DocumentoID, SelloCFD, FechaTimbradoSinFormato, CadenaOrignalComplemento, SerieCertificadoSAT, UUID, Date.Now.Year.ToString, TipoComprobante)
                End If
            End If

            Resultado = True
        Catch ex As Exception
            Resultado = False
            Throw ex
        Finally
            objDA = Nothing
        End Try

        Return Resultado

    End Function

    Public Function ValidarMontoFacturaExterno(ByVal RutaXML As String, ByVal TotalFactura As Double) As Boolean

        Dim Resultado As Boolean = True
        Dim objDA As New Facturacion.Datos.TimbradoDA

        Try
            Dim UUID As String = String.Empty
            Dim FechaTimbradoFormato As String = String.Empty
            Dim FechaTimbradoSinFormato As String = String.Empty
            Dim SelloSAT As String = String.Empty
            Dim SelloCFD As String = String.Empty
            Dim SerieCertificadoSAT As String = String.Empty
            Dim SerieCertificadoEmisor As String = String.Empty
            Dim CadenaOrignalComplemento As String = String.Empty
            Dim VersionComplemento As String = String.Empty
            Dim RFCProveedor As String = String.Empty
            Dim TotalUSD As String = String.Empty
            Dim doc As New XmlDocument()
            Dim Factura As XmlNode
            Dim TimbreFiscalTotal As XmlNode


            doc.Load(RutaXML)
            Dim xmlmanager As System.Xml.XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)
            xmlmanager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
            xmlmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
            Dim Fila As Integer = 0
            Factura = doc.ChildNodes(1)
            SerieCertificadoEmisor = Factura.Attributes.GetNamedItem("NoCertificado").Value
            Dim nodo As XmlNode = Factura.SelectSingleNode("cfdi:Complemento", xmlmanager)

            TimbreFiscalTotal = nodo.ChildNodes(0)
            TotalUSD = TimbreFiscalTotal.Attributes.GetNamedItem("TotalUSD").Value

            If TotalFactura <> CDbl(TotalUSD) Then
                Return False
            End If



            Resultado = True
        Catch ex As Exception
            Resultado = False
            Throw ex
        Finally
            objDA = Nothing
        End Try

        Return Resultado

    End Function


    Private Function ObtenerTipoDocumentoSICY(ByVal TipoComprobante As String) As String
        Dim TipoDocumento As String = String.Empty

        Select Case TipoComprobante
            Case "c"
                TipoDocumento = "FACTURA"
            Case "NOTACREDITO"
                TipoDocumento = "NOTA CREDITO"
            Case Else
                TipoDocumento = ""
        End Select

        Return TipoDocumento
    End Function

    Private Function QuitarFormatoFecha(ByVal Fecha As String) As String
        Dim ResultadoFecha As DateTime
        Dim CadenaSplit As String()
        Dim FechaCompleto As String

        Try
            CadenaSplit = Split(Fecha, "T")
            FechaCompleto = Convert.ToDateTime(CadenaSplit(0) + " " + CadenaSplit(1))
            ResultadoFecha = Convert.ToDateTime(FechaCompleto.Replace("p.m.", "PM").Replace("a.m.", "AM"))
            FechaCompleto = ResultadoFecha.ToString("dd-MM-yyyy HH:mm:ss")
        Catch ex As Exception
            Throw ex
        End Try

        Return FechaCompleto
    End Function

    'Public Function Cancelacion(ByVal UUID As String, ByVal RFCEmisor As String, ByVal TipoComprobante As String, ByVal RutaXMLCancelacion As String) As Boolean
    '    Dim UsuarioWS As String = String.Empty
    '    Dim pssWS As String = String.Empty
    '    Dim ClaveTipoComprobante As String = String.Empty
    '    Dim ListaUUID(0) As String
    '    Dim Doc As New XmlDocument
    '    Dim nodo As XmlNode
    '    Dim estatus As String = ""
    '    Dim Resultado As Boolean = False
    '    Dim DocumentoID As String = String.Empty
    '    Dim ResultadoCancelacion As String = String.Empty
    '    Dim splitDescripcion() As String
    '    Dim DirectorioCancelacion As String = String.Empty

    '    Try
    '        'pruebas
    '        'Dim ws As New mx.com.paxfacturacion.testCanc.wcfCancelaASMX
    '        'Produccion
    '        Dim ws As New mx.com.paxfacturacion.wwwCanc.wcfCancelaASMX

    '        Dim strXML As String = ""
    '        Dim strXMLTimbrado As String = ""

    '        ListaUUID(0) = UUID
    '        UsuarioWS = EntEmpresa.UsuarioWS
    '        pssWS = EntEmpresa.ContraseñaWS
    '        ws.Timeout = 600000
    '        strXMLTimbrado = ws.fnCancelarXML(ListaUUID, RFCEmisor, 0, UsuarioWS, pssWS)

    '        'If File.Exists(RutaXMLCancelacion) = False Then
    '        '    File.Create(RutaXMLCancelacion)
    '        'End If
    '        DirectorioCancelacion = Path.GetDirectoryName(RutaXMLCancelacion)

    '        If Directory.Exists(DirectorioCancelacion) = False Then
    '            Directory.CreateDirectory(DirectorioCancelacion)
    '        End If

    '        File.WriteAllText(RutaXMLCancelacion, strXMLTimbrado)

    '        If File.Exists(RutaXMLCancelacion) = True Then
    '            Doc.Load(RutaXMLCancelacion)
    '            nodo = Doc.ChildNodes(0).ChildNodes(0)
    '            estatus = nodo.ChildNodes.Item(1).InnerText
    '            ResultadoCancelacion = nodo.ChildNodes.Item(2).InnerText
    '            splitDescripcion = Split(ResultadoCancelacion, "-")
    '            ResultadoCancelacion = splitDescripcion(1).Trim()

    '            If estatus.Contains("201") = True Or estatus.Contains("202") = True Then
    '                mensaje = ResultadoCancelacion
    '                Resultado = True
    '            Else
    '                mensaje = ResultadoCancelacion
    '                Resultado = False
    '            End If
    '        Else
    '            Resultado = False
    '            mensaje = "No se genero el XML de cancelación"
    '        End If

    '        If Resultado = False Then
    '            DocumentoID = ObtenerDocumentoID_UUID(UUID, TipoComprobante)
    '            objDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, "NA", estatus)
    '        End If
    '    Catch ex As Exception
    '        Resultado = False
    '        mensaje = ex.Message.ToString.Trim()
    '        Throw ex
    '    End Try

    '    Return Resultado
    'End Function

    Public Function Cancelacion(ByVal UUID As String, ByVal RFCEmisor As String, ByVal TipoComprobante As String, ByVal RutaXMLCancelacion As String) As Boolean
        Dim UsuarioWS As String = String.Empty
        Dim pssWS As String = String.Empty
        Dim ClaveTipoComprobante As String = String.Empty
        Dim ListaUUID(0) As String
        Dim RFCReceptorArr(0) As String
        Dim TotalesArr(0) As String
        Dim Doc As New XmlDocument
        Dim nodo As XmlNode
        Dim estatus As String = ""
        Dim Resultado As Boolean = False
        Dim DocumentoID As String = String.Empty
        Dim ResultadoCancelacion As String = String.Empty
        Dim splitDescripcion() As String
        Dim DirectorioCancelacion As String = String.Empty
        Dim RFCReceptor As String = String.Empty
        Dim Total As Double = 0
        Try
            'pruebas
            ' Dim ws As New mx.com.paxfacturacion.testCancelar.wcfCancelaASMX
            'Produccion
            Dim ws As New mx.com.paxfacturacion.wwwCancv2.wcfCancelaASMX



            Dim strXML As String = ""
            Dim strXMLTimbrado As String = ""
            RFCReceptor = ObtenerReceptorRFC_UUID(UUID, TipoComprobante)
            Total = ObtenerDocumentoID_Total(UUID, TipoComprobante)
            ListaUUID(0) = UUID
            RFCReceptorArr(0) = RFCReceptor
            TotalesArr(0) = Total.ToString()
            UsuarioWS = EntEmpresa.UsuarioWS
            pssWS = EntEmpresa.ContraseñaWS
            ws.Timeout = 600000
            'strXMLTimbrado = ws.fnCancelarXML(ListaUUID, RFCEmisor, 0, UsuarioWS, pssWS)
            strXMLTimbrado = ws.fnCancelarXML(ListaUUID, RFCEmisor, RFCReceptorArr, TotalesArr, UsuarioWS, pssWS)

            'If File.Exists(RutaXMLCancelacion) = False Then
            '    File.Create(RutaXMLCancelacion)
            'End If
            DirectorioCancelacion = Path.GetDirectoryName(RutaXMLCancelacion)

            If Directory.Exists(DirectorioCancelacion) = False Then
                Directory.CreateDirectory(DirectorioCancelacion)
            End If

            File.WriteAllText(RutaXMLCancelacion, strXMLTimbrado)

            If File.Exists(RutaXMLCancelacion) = True Then
                Doc.Load(RutaXMLCancelacion)
                nodo = Doc.ChildNodes(0).ChildNodes(0)
                estatus = nodo.ChildNodes.Item(1).InnerText
                ResultadoCancelacion = nodo.ChildNodes.Item(2).InnerText
                splitDescripcion = Split(ResultadoCancelacion, "-")
                ResultadoCancelacion = splitDescripcion(1).Trim()

                If estatus.Contains("201") = True Or estatus.Contains("202") = True Or estatus.Contains("103") = True Or estatus.Contains("107") = True Then
                    mensaje = ResultadoCancelacion
                    Resultado = True
                Else
                    mensaje = ResultadoCancelacion
                    Resultado = False
                End If
            Else
                Resultado = False
                mensaje = "No se genero el XML de cancelación"
            End If

            If Resultado = False Then
                DocumentoID = ObtenerDocumentoID_UUID(UUID, TipoComprobante)
                objDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, "NA", estatus)
            End If
        Catch ex As Exception
            Resultado = False
            mensaje = ex.Message.ToString.Trim()
            Throw ex
        End Try

        Return Resultado
    End Function


    Public Function ObtenerDocumentoID_UUID(ByVal UUID As String, ByVal TipoComprobante As String) As String
        Dim dtResultado As New DataTable
        Dim DocumentoID As String = String.Empty

        Try
            dtResultado = objDA.ObtenerDocumentoID_UUID(UUID, TipoComprobante)
            If dtResultado.Rows.Count > 0 Then
                DocumentoID = dtResultado.Rows(0).Item("DocumentoID")
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return DocumentoID
    End Function


    Public Function ObtenerReceptorRFC_UUID(ByVal UUID As String, ByVal TipoComprobante As String) As String
        Dim dtResultado As New DataTable
        Dim DocumentoID As String = String.Empty

        Try
            dtResultado = objDA.ObtenerDocumentoID_UUID(UUID, TipoComprobante)
            If dtResultado.Rows.Count > 0 Then
                DocumentoID = dtResultado.Rows(0).Item("ReceptorRFC")
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return DocumentoID
    End Function


    Public Function ObtenerFolio_UUID(ByVal UUID As String, ByVal TipoComprobante As String) As String
        Dim dtResultado As New DataTable
        Dim Folio As String = String.Empty

        Try
            dtResultado = objDA.ObtenerDocumentoID_UUID(UUID, TipoComprobante)
            If dtResultado.Rows.Count > 0 Then
                Folio = dtResultado.Rows(0).Item("Folio")
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return Folio
    End Function

    Public Function ObtenerSerie_UUID(ByVal UUID As String, ByVal TipoComprobante As String) As String
        Dim dtResultado As New DataTable
        Dim Serie As String = String.Empty

        Try
            dtResultado = objDA.ObtenerDocumentoID_UUID(UUID, TipoComprobante)
            If dtResultado.Rows.Count > 0 Then
                Serie = dtResultado.Rows(0).Item("Serie")
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return Serie
    End Function

    Public Shared Sub ActualizarRutaPDFFactura(ByVal idDocumento As Integer, RutaPDF As String, ByVal TipoComprobante As String, ByVal RutaPDFsicy As String)
        Try
            Facturacion.Datos.TimbradoDA.ActualizarRutaPDFFactura(idDocumento, RutaPDF, TipoComprobante, RutaPDFsicy)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ObtenerDatosDelComplementoCancelado(ByVal DocumentoID As Integer, ByVal RutaXML As String, ByVal TipoComprobante As String) As Entidades.FacturaCancelada

        Dim Resultado As Boolean = False
        Dim objDA As New Facturacion.Datos.TimbradoDA
        Dim EntFacturaCancelada As New Entidades.FacturaCancelada

        Try
            Dim UUID As String = String.Empty
            Dim FechaTimbradoFormato As String = String.Empty
            Dim FechaTimbradoSinFormato As String = String.Empty
            Dim FechaCancelacion As String = String.Empty
            Dim EstatusCancelacionID As String = String.Empty
            Dim DescripcionEstatusCancelacion As String = String.Empty
            Dim splitDescripcionEstatusCancelacion() As String
            Dim doc As New XmlDocument()
            Dim Factura As XmlNode
            Dim NodoCancelacion As XmlNode

            If File.Exists(RutaXML) = False Then
                Return EntFacturaCancelada
            End If


            doc.Load(RutaXML)
            Dim xmlmanager As System.Xml.XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)
            xmlmanager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
            xmlmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
            Dim Fila As Integer = 0
            Factura = doc.ChildNodes(0)
            FechaCancelacion = Factura.Attributes.GetNamedItem("Fecha").Value
            FechaCancelacion = FechaCancelacion.Replace(" ", "")

            Dim nodo As XmlNode = Factura.ChildNodes(0)
            NodoCancelacion = nodo.ChildNodes(0)

            EstatusCancelacionID = nodo.ChildNodes.Item(1).InnerText ' NodoCancelacion.Attributes.GetNamedItem("UUIDEstatus").Value
            splitDescripcionEstatusCancelacion = Split(nodo.ChildNodes.Item(2).InnerText, "-") 'Split(NodoCancelacion.Attributes.GetNamedItem("UUIDdescripcion").Value, "-")
            DescripcionEstatusCancelacion = splitDescripcionEstatusCancelacion(1)

            EntFacturaCancelada.DocumentoID = DocumentoID
            EntFacturaCancelada.DescripcionEstatusCancelacion = DescripcionEstatusCancelacion
            EntFacturaCancelada.EstatusCancelacionID = EstatusCancelacionID
            EntFacturaCancelada.FechaCancelacion = FechaCancelacion
            EntFacturaCancelada.TipoComprobante = TipoComprobante

        Catch ex As Exception
            Throw ex
        Finally
            objDA = Nothing
        End Try

        Return EntFacturaCancelada

    End Function

    Public Shared Sub ActualizarRutaXMLFactura(ByVal idDocumento As Integer, RutaXML As String, ByVal TipoComprobante As String, ByVal RutaXMLSICY As String)
        Try
            Facturacion.Datos.TimbradoDA.ActualizarRutaXMLFactura(idDocumento, RutaXML, TipoComprobante, RutaXMLSICY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function CancelacionFacturaPrueba(ByVal UUID As String, ByVal RFCEmisor As String, ByVal TipoComprobante As String, ByVal RutaXMLCancelacion As String) As Boolean
        Dim UsuarioWS As String = String.Empty
        Dim pssWS As String = String.Empty
        Dim ClaveTipoComprobante As String = String.Empty
        Dim ListaUUID(0) As String
        Dim RFCReceptorArr(0) As String
        Dim TotalesArr(0) As String
        Dim Doc As New XmlDocument
        Dim nodo As XmlNode
        Dim estatus As String = ""
        Dim Resultado As Boolean = False
        Dim DocumentoID As String = String.Empty
        Dim ResultadoCancelacion As String = String.Empty
        Dim splitDescripcion() As String
        Dim DirectorioCancelacion As String = String.Empty
        Dim RFCReceptor As String = String.Empty



        Try
            'Dim ws As New mx.com.paxfacturacion.testCancelar.wcfCancelaASMX 'mx.com.paxfacturacion.testCancelar.wcfCancelaASMX


            'Dim ws As New mx.com
            Dim strXML As String = ""
            Dim strXMLTimbrado As String = ""
            RFCReceptor = ObtenerReceptorRFC_UUID(UUID, TipoComprobante)
            ListaUUID(0) = UUID
            RFCReceptorArr(0) = RFCReceptor
            TotalesArr(0) = "0.00"
            UsuarioWS = EntEmpresa.UsuarioWS
            pssWS = EntEmpresa.ContraseñaWS
            'strXMLTimbrado = ws.fnCancelarXML(ListaUUID, RFCEmisor, RFCReceptorArr, TotalesArr, UsuarioWS, pssWS)

            'If File.Exists(RutaXMLCancelacion) = False Then
            '    File.Create(RutaXMLCancelacion)
            'End If
            DirectorioCancelacion = Path.GetDirectoryName(RutaXMLCancelacion)

            If Directory.Exists(DirectorioCancelacion) = False Then
                Directory.CreateDirectory(DirectorioCancelacion)
            End If

            File.WriteAllText(RutaXMLCancelacion, strXMLTimbrado)

            If File.Exists(RutaXMLCancelacion) = True Then
                Doc.Load(RutaXMLCancelacion)
                nodo = Doc.ChildNodes(0).ChildNodes(0)
                estatus = nodo.ChildNodes.Item(1).InnerText
                ResultadoCancelacion = nodo.ChildNodes.Item(2).InnerText
                splitDescripcion = Split(ResultadoCancelacion, "-")
                ResultadoCancelacion = splitDescripcion(1).Trim()

                If estatus.Contains("201") = True Or estatus.Contains("202") = True Or estatus.Contains("303") = True Then
                    mensaje = ResultadoCancelacion
                    Resultado = True
                Else
                    mensaje = ResultadoCancelacion
                    Resultado = False
                End If
            Else
                Resultado = False
                mensaje = "No se genero el XML de cancelación"
            End If
            If Resultado = False Then
                DocumentoID = ObtenerDocumentoID_UUID(UUID, TipoComprobante)
                objDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, "NA", estatus)
            End If
        Catch ex As Exception
            Resultado = False
            mensaje = ex.Message.ToString.Trim()
            Throw ex
        End Try

        Return Resultado
    End Function

    Public Function CancelacionFacturaPruebaSolicitud4_0(ByVal UUID As String, ByVal RFCEmisor As String, ByVal TipoComprobante As String, ByVal RutaXMLCancelacion As String, ByVal MotivoCancelacion As String, ByVal FolioSustitucion As String) As DataTable

        'PruebaTimbrado(UUID, RFCEmisor, TipoComprobante, RutaXMLCancelacion, MotivoCancelacion, FolioSustitucion)

        'Dim UsuarioWS As String = String.Empty
        'Dim pssWS As String = String.Empty
        'Dim ClaveTipoComprobante As String = String.Empty
        'Dim ListaUUID(0) As String
        'Dim RFCReceptorArr(0) As String
        'Dim TotalesArr(0) As String
        'Dim Doc As New XmlDocument
        'Dim nodo As XmlNode
        'Dim estatus As String = ""
        'Dim Resultado As Boolean = False
        'Dim DocumentoID As String = String.Empty
        'Dim ResultadoCancelacion As String = String.Empty
        'Dim splitDescripcion(0) As String
        'Dim DirectorioCancelacion As String = String.Empty
        'Dim RFCReceptor(0) As String

        'Dim dtrespuesta As New DataTable
        'dtrespuesta.Columns.Add("Resultado")
        'dtrespuesta.Columns.Add("Mensaje")
        'Dim Renglon As DataRow = dtrespuesta.NewRow()

        'Dim MotivoCancelacionArr(0) As String
        'Dim FoliosSustitucion(0) As String


        'Try
        '    'Dim ws As New mx.com.paxfacturacion.testCanc.wcfCancelaASMX
        '    Dim ws As New mx.com.paxfacturacion.testCanc.wcfCancelaASMX

        '    'Dim ws As New mx.com
        '    Dim strXML As String = ""
        '    Dim strXMLTimbrado As String = ""


        '    RFCReceptor(0) = ObtenerReceptorRFC_UUID(UUID, TipoComprobante)

        '    ListaUUID(0) = UUID
        '    TotalesArr(0) = (10.7)
        '    UsuarioWS = EntEmpresa.UsuarioWS
        '    pssWS = EntEmpresa.ContraseñaWS
        '    MotivoCancelacionArr(0) = MotivoCancelacion
        '    FoliosSustitucion(0) = FolioSustitucion

        '    strXMLTimbrado = ws.fnCancelarXML20(ListaUUID, RFCEmisor, RFCReceptor, TotalesArr, MotivoCancelacionArr, FoliosSustitucion, UsuarioWS, pssWS)

        '    DirectorioCancelacion = Path.GetDirectoryName(RutaXMLCancelacion)

        '    If Directory.Exists(DirectorioCancelacion) = False Then
        '        Directory.CreateDirectory(DirectorioCancelacion)
        '    End If

        '    File.WriteAllText(RutaXMLCancelacion, strXMLTimbrado)

        '    If File.Exists(RutaXMLCancelacion) = True Then
        '        Doc.Load(RutaXMLCancelacion)
        '        nodo = Doc.ChildNodes(0).ChildNodes(0)
        '        estatus = nodo.ChildNodes.Item(1).InnerText
        '        ResultadoCancelacion = nodo.ChildNodes.Item(2).InnerText
        '        splitDescripcion = Split(ResultadoCancelacion, "-")
        '        ResultadoCancelacion = splitDescripcion(1).Trim()

        '        If estatus.Contains("201") = True Or estatus.Contains("202") = True Or estatus.Contains("107") = True Then
        '            mensaje = ResultadoCancelacion
        '            Resultado = True

        '            Renglon("Resultado") = 1
        '            Renglon("Mensaje") = estatus
        '        Else
        '            mensaje = ResultadoCancelacion
        '            Resultado = False

        '            Renglon("Resultado") = 0
        '            Renglon("Mensaje") = estatus

        '        End If

        '        dtrespuesta.Rows.Add(Renglon)

        '    Else
        '        Resultado = False
        '        'mensaje = "No se genero el XML de cancelación"
        '        Renglon("Resultado") = 0
        '        Renglon("Mensaje") = "No se genero el XML de cancelación"

        '        dtrespuesta.Rows.Add(Renglon)
        '        'respuesta = "No se genero el XML de cancelación"
        '    End If
        '    If Resultado = False Then
        '        DocumentoID = ObtenerDocumentoID_UUID(UUID, TipoComprobante)
        '        objDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, "NA", estatus)
        '    End If
        'Catch ex As Exception
        '    Resultado = False
        '    mensaje = ex.Message.ToString.Trim()
        '    Renglon("Resultado") = 0
        '    Renglon("Mensaje") = "ERROR"
        '    dtrespuesta.Rows.Add(Renglon)
        '    Throw ex
        'End Try

        'Return dtrespuesta
    End Function

    Private Sub PruebaTimbrado(ByVal UUID As String, ByVal RFCEmisor2 As String, ByVal TipoComprobante As String, ByVal RutaXMLCancelacion As String, ByVal MotivoCancelacion As String, ByVal FolioSustitucion As String)

        'Dim UsuarioWS As String = String.Empty
        'Dim pssWS As String = String.Empty
        'Dim ClaveTipoComprobante As String = String.Empty
        ''Dim ListaUUID(0) As String
        'Dim RFCReceptorArr(0) As String
        'Dim TotalesArr(0) As String
        'Dim Doc As New XmlDocument
        'Dim nodo As XmlNode
        'Dim estatus As String = ""
        'Dim Resultado As Boolean = False
        'Dim DocumentoID As String = String.Empty
        'Dim ResultadoCancelacion As String = String.Empty
        'Dim splitDescripcion(0) As String
        'Dim DirectorioCancelacion As String = String.Empty
        'Dim RFCReceptor(0) As String
        'Dim strXML As String = ""
        'Dim strXMLTimbrado As String = ""


        'Dim ws As New Facturacion.Negocios.mx.com.paxfacturacion.testCanc.wcfCancelaASMX
        'Dim listauuid(0) As String
        'Dim rfcemisor As String
        'Dim ListRFCRecptor(0) As String
        'Dim ListaTotales(0) As String
        'Dim ListaMotivos(0) As String
        'Dim FoliosSusstitucion(0) As String
        'Dim Nombre As String
        'Dim Contraseña As String

        'Dim dtrespuesta As New DataTable
        'dtrespuesta.Columns.Add("Resultado")
        'dtrespuesta.Columns.Add("Mensaje")
        'Dim Renglon As DataRow = dtrespuesta.NewRow()

        'listauuid(0) = "dbfd9f2f-1b75-4e07-a865-082d0dbc7712"
        'rfcemisor = "CACX7605101P8"
        'ListRFCRecptor(0) = "AAA010101AAA"
        'ListaTotales(0) = "10.77"
        'ListaMotivos(0) = "01"
        'FoliosSusstitucion(0) = ""
        'Nombre = "wsdl_pax"
        'Contraseña = "wrnDgcOvxYXEr8OKw6jDm8WDxYXCgzV5xLTEgMKoXk/EjcK5776k77+V77+QMu++qe++s++9se+8kw=="

        'Try
        '    Dim reuslatodo = ws.fnCancelarXML20(listauuid, rfcemisor, ListRFCRecptor, ListaTotales, ListaMotivos, FoliosSusstitucion, Nombre, Contraseña)


        '    DirectorioCancelacion = Path.GetDirectoryName(RutaXMLCancelacion)

        '    If Directory.Exists(DirectorioCancelacion) = False Then
        '        Directory.CreateDirectory(DirectorioCancelacion)
        '    End If

        '    File.WriteAllText(RutaXMLCancelacion, strXMLTimbrado)

        '    If File.Exists(RutaXMLCancelacion) = True Then
        '        Doc.Load(RutaXMLCancelacion)
        '        nodo = Doc.ChildNodes(0).ChildNodes(0)
        '        estatus = nodo.ChildNodes.Item(1).InnerText
        '        ResultadoCancelacion = nodo.ChildNodes.Item(2).InnerText
        '        splitDescripcion = Split(ResultadoCancelacion, "-")
        '        ResultadoCancelacion = splitDescripcion(1).Trim()

        '        If estatus.Contains("201") = True Or estatus.Contains("202") = True Or estatus.Contains("107") = True Then
        '            mensaje = ResultadoCancelacion
        '            Resultado = True

        '            Renglon("Resultado") = 1
        '            Renglon("Mensaje") = estatus
        '        Else
        '            mensaje = ResultadoCancelacion
        '            Resultado = False

        '            Renglon("Resultado") = 0
        '            Renglon("Mensaje") = estatus

        '        End If

        '        dtrespuesta.Rows.Add(Renglon)

        '    Else
        '        Resultado = False
        '        'mensaje = "No se genero el XML de cancelación"
        '        Renglon("Resultado") = 0
        '        Renglon("Mensaje") = "No se genero el XML de cancelación"

        '        dtrespuesta.Rows.Add(Renglon)
        '        'respuesta = "No se genero el XML de cancelación"
        '    End If
        '    If Resultado = False Then
        '        DocumentoID = ObtenerDocumentoID_UUID(UUID, TipoComprobante)
        '        objDA.InsertarErrorAlTimbrar(DocumentoID, TipoComprobante, "NA", estatus)
        '    End If
        'Catch ex As Exception
        '    Resultado = False
        '    mensaje = ex.Message.ToString.Trim()
        '    Renglon("Resultado") = 0
        '    Renglon("Mensaje") = "ERROR"
        '    dtrespuesta.Rows.Add(Renglon)
        '    Throw ex
        'End Try



    End Sub

    Public Sub EliminarArchivosTemporales(ByVal DirectorioArchivosTemporales As String, ByVal DocumentoID As Integer, ByVal TipoComprobante As String)
        Try
            If File.Exists(DirectorioArchivosTemporales & "ArchivoSello_" & TipoComprobante & "_" & DocumentoID.ToString() & ".txt") = True Then
                File.Delete(DirectorioArchivosTemporales & "ArchivoSello_" & TipoComprobante & "_" & DocumentoID.ToString() & ".txt")
            End If

            If File.Exists(DirectorioArchivosTemporales & "ArchivoSHA_" & TipoComprobante & "_" & DocumentoID.ToString() & ".txt") = True Then
                File.Delete(DirectorioArchivosTemporales & "ArchivoSHA_" & TipoComprobante & "_" & DocumentoID.ToString() & ".txt")
            End If

            If File.Exists(DirectorioArchivosTemporales & "CadenaOriginal_" & TipoComprobante & "_" & DocumentoID.ToString() & ".txt") = True Then
                File.Delete(DirectorioArchivosTemporales & "CadenaOriginal_" & TipoComprobante & "_" & DocumentoID.ToString() & ".txt")
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function ObtenerDocumentoID_Total(ByVal UUID As String, ByVal TipoComprobante As String) As String
        Dim dtResultado As New DataTable
        Dim DocumentoID As String = String.Empty

        Try
            dtResultado = objDA.ObtenerDocumentoID_UUID(UUID, TipoComprobante)
            If dtResultado.Rows.Count > 0 Then
                DocumentoID = dtResultado.Rows(0).Item("Total")
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return DocumentoID
    End Function

    Public Sub CANCELADODEPRUEBA()
        '''fnCancelarXML20
        ''Dim w As New mx.com.paxfacturacion.testCanc.wcfCancelaASMX

        ''Dim w As New CancelacionFacturas4_0
        'Dim w As New mx.com.paxfacturacion.testCanc.wcfCancelaASMX
        'Dim ws As New CancelacionFacturas4_0.wcfCancelaASMXSoapClient


        'Dim UsuarioWS As String = String.Empty
        'Dim pssWS As String = String.Empty
        'Dim ClaveTipoComprobante As String = String.Empty
        'Dim ListaUUID As New CancelacionFacturas4_0.ArrayOfString

        'Try

        '    Dim TotalesArr As New CancelacionFacturas4_0.ArrayOfString
        '    Dim Doc As New XmlDocument
        '    Dim nodo As XmlNode
        '    Dim estatus As String = ""
        '    Dim Resultado As Boolean = False
        '    Dim DocumentoID As String = String.Empty
        '    Dim ResultadoCancelacion As String = String.Empty
        '    Dim splitDescripcion() As String
        '    Dim DirectorioCancelacion As String = String.Empty
        '    Dim RFCEmisor As String = String.Empty
        '    Dim RFCReceptor As New CancelacionFacturas4_0.ArrayOfString
        '    Dim MotivoCancelacionArr As New CancelacionFacturas4_0.ArrayOfString
        '    Dim FoliosSustitucion As New CancelacionFacturas4_0.ArrayOfString

        '    Dim dtrespuesta As New DataTable
        '    dtrespuesta.Columns.Add("Resultado")
        '    dtrespuesta.Columns.Add("Mensaje")

        '    Dim strXMLTimbrado As String = ""
        '    RFCReceptor.Add("AAA010101AAA")
        '    ListaUUID.Add("dbfd9f2f-1b75-4e07-a865-082d0dbc7712")


        '    TotalesArr.Add("10.70")
        '    UsuarioWS = "wsdl_pax"
        '    pssWS = "wrnDgcOvxYXEr8OKw6jDm8WDxYXCgzV5xLTEgMKoXk/EjcK5776k77+V77+QMu++qe++s++9se+8kw=="
        '    MotivoCancelacionArr.Add("01")
        '    FoliosSustitucion.Add("")

        '    strXMLTimbrado = ws.fnCancelarXML20(ListaUUID, RFCEmisor, RFCReceptor, TotalesArr, MotivoCancelacionArr, FoliosSustitucion, UsuarioWS, pssWS)





        'Catch ex As Exception

        'End Try




        'strXMLTimbrado = 
        '(c, RFCEmisor, RFCReceptorArr, TotalesArr, MotivoCancelacionArr, FoliosSustitucion, UsuarioWS, pssWS)



    End Sub

End Class
