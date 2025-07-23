Imports Framework.Negocios
Imports System.Net
Imports System.IO
Imports HyperSoft.ElectronicDocumentLibrary.Document
Imports HyperSoft.ElectronicDocumentLibrary.Manage
Imports HyperSoft.ElectronicDocumentLibrary.Certificate
Imports HyperSoft.ElectronicDocumentLibrary.Base
Imports HyperSoft.ElectronicDocumentLibrary.Pax
Imports HyperSoft.ElectronicDocumentLibrary.Pax.Timbrado.Resultado

Public Class ArrendamientoExternoBU
    Private manage As ElectronicManage
    Private certificate As ElectronicCertificate

    Private pruebas As Boolean = True
    Dim descargado As Boolean = False
    Private msjError As String = String.Empty
    Private uuid As String = String.Empty

    Private usuarioWS As String = String.Empty
    Private contrasenaWS As String = String.Empty
    Private identificadorWS As String = String.Empty

    Private empresa As New Entidades.EmpresasFacturacion

    Private path As String = "C:\WSExternoArrendamiento\"
    Private pathXML As String = "C:\WSExternoArrendamiento\XMLArrendamiento\"

    Public Function consultarListadoEmpresas(ByVal usuario As String, ByVal password As String) As DataTable
        Dim objDA As New Datos.ArrendamientoExternoDA
        'Convierte la cadena de la contraseña a md5
        Dim objUtileria As New UtileriaCadenas
        Dim passwordMd5 As String = String.Empty
        passwordMd5 = objUtileria.StringToMd5(password)

        Return objDA.consultarListadoEmpresas(usuario, passwordMd5)
    End Function

    Public Function validaLogin(ByVal usuario As String, ByVal password As String) As Boolean
        Dim objDA As New Datos.ArrendamientoExternoDA
        'Convierte la cadena de la contraseña a md5
        Dim objUtileria As New UtileriaCadenas
        Dim passwordMd5 As String = String.Empty
        Dim dtResultado As New DataTable
        Dim resultado As Boolean = False
        passwordMd5 = objUtileria.StringToMd5(password)

        dtResultado = objDA.validaLogin(usuario, passwordMd5)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count <> 0 Then
                resultado = CBool(dtResultado.Rows(0)("Resultado").ToString)
            End If
        End If

        Return resultado
    End Function

    Public Function consultaDatosEmpresa(ByVal empresaId As Integer, ByVal pruebas As Boolean) As Entidades.EmpresasFacturacion
        Dim objDA As New Datos.ArrendamientoExternoDA
        Dim dtResultado As New DataTable
        Dim empresa As New Entidades.EmpresasFacturacion

        dtResultado = objDA.consultaDatosEmpresa(empresaId, pruebas)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                empresa.ERutacertificado = CStr(dtResultado.Rows(0)("RutaCertificado"))
                empresa.ERutakey = CStr(dtResultado.Rows(0)("RutaKey"))
                empresa.EContrasenacertificado = CStr(dtResultado.Rows(0)("PassCertificado"))
                empresa.EUsuariows = CStr(dtResultado.Rows(0)("UsuarioWS"))
                empresa.EContrasenaws = CStr(dtResultado.Rows(0)("PassWS"))
                empresa.EIdentificadorPax = CStr(dtResultado.Rows(0)("identificadorWS"))
                empresa.ERfc = CStr(dtResultado.Rows(0)("RFC"))
                empresa.ENombre = CStr(dtResultado.Rows(0)("RazonSocial"))
                empresa.ERegimen = CStr(dtResultado.Rows(0)("Regimen"))
                empresa.EClaveRegimen = CStr(dtResultado.Rows(0)("ClaveRegimen"))
                empresa.ECalle = CStr(dtResultado.Rows(0)("Calle"))
                empresa.ENumero = CStr(dtResultado.Rows(0)("Numero"))
                empresa.EColonia = CStr(dtResultado.Rows(0)("Colonia"))
                empresa.ECiudad = CStr(dtResultado.Rows(0)("Ciudad"))
                empresa.EEstado = CStr(dtResultado.Rows(0)("Estado"))
                empresa.EPais = CStr(dtResultado.Rows(0)("Pais"))
                empresa.ECp = CStr(dtResultado.Rows(0)("CodigoPostal"))
            Else
                empresa = Nothing
            End If
        Else
            empresa = Nothing
        End If

        Return empresa
    End Function

    Public Function descargarArchivo(ByVal archivo As String) As String
        Try
            Dim objFTP As New TransferenciaFTPBU
            Dim request = DirectCast(WebRequest.Create(rutaFTP), FtpWebRequest)
            Dim rutaArchivo As String = String.Empty
            Dim nuevaRuta As String = String.Empty
            request.Credentials = New NetworkCredential(ftpUsuario, ftpContrasena)

            If archivo <> "" Then
                If Not existeCarpeta(path) Then
                    crearCarpeta(path)
                End If

                nuevaRuta = rutaTmp & IO.Path.GetFileName(archivo)
                If Not existeArchivo(nuevaRuta) Then
                    archivo = archivo.ToUpper.Replace(rutaFTP.ToUpper, "")
                    rutaArchivo = IO.Path.GetDirectoryName(archivo)
                    objFTP.DescargarArchivo(rutaArchivo, rutaTmp, IO.Path.GetFileName(archivo))
                End If
                descargado = True
            End If

            Return nuevaRuta
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function existeCarpeta(ByVal ruta As String) As Boolean
        Dim exists As Boolean
        exists = System.IO.Directory.Exists(ruta)
        Return exists
    End Function

    Public Sub crearCarpeta(ByVal ruta As String)
        System.IO.Directory.CreateDirectory(ruta)
    End Sub

    Public Function existeArchivo(ByVal archivo As String) As Boolean
        If Dir(archivo) = vbNullString Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub eliminaArchivo(ByVal archivo As String)
        Try
            File.Delete(archivo)
        Catch ex As Exception

        End Try
    End Sub

    Public Function timbradoPruebas(ByVal Usuario As String, ByVal Password As String, ByVal empresaId As Integer,
                                    ByVal Version As String, ByVal Serie As String, ByVal Folio As String,
                                    ByVal Fecha As Date, ByVal FormaPago As String, ByVal CondicionesPago As String,
                                    ByVal Subtotal As Double, ByVal Descuento As Double, ByVal MotivoDescuento As String,
                                    ByVal TipoCambio As String, ByVal Moneda As String, ByVal Total As Double,
                                    ByVal TipoComprobante As String, ByVal MetodoPago As String, ByVal LugarExpedicion As String,
                                    ByVal NumeroCuentaPago As String, ByVal FolioFiscalOriginal As String,
                                    ByVal SerieFolioFiscalOriginal As String, ByVal FechaFolioFiscalOriginal As String,
                                    ByVal MontoFolioFiscalOriginal As Double, ByVal MostrarDomicilioEmisor As Boolean,
                                    ByVal MostrarExpedidoEnEmisor As Boolean, ByVal receptorRFC As String,
                                    ByVal ReceptorNombre As String, ByVal MostrarDomicilioReceptor As Boolean,
                                    ByVal ReceptorCalle As String, ByVal ReceptorNumeroExterior As String,
                                    ByVal ReceptorNumeroInterior As String, ByVal ReceptorColonia As String,
                                    ByVal ReceptorLocalidad As String, ByVal ReceptorReferencia As String,
                                    ByVal ReceptorMunicipio As String, ByVal ReceptorEstado As String,
                                    ByVal ReceptorPais As String, ByVal ReceptorCodigoPostal As String,
                                    ByVal dtConceptos As DataTable, ByVal TotalImpuestosRetenidos As Double,
                                    ByVal TotalImpuestosTrasladados As Double, ByVal dtImpuestosRetenidos As DataTable,
                                    ByVal dtImpuestosTrasladados As DataTable) As String
        Dim resultado As String = String.Empty
        Dim Archivo As Stream

        Try
            If validaLogin(Usuario, Password) Then
                pruebas = True
                If Not iniciaCertificado(empresaId) Then
                    resultado = "No se pudo iniciar la configuración de la libreria. " & msjError
                Else
                    Dim libElectronicDocument As ElectronicDocument = ElectronicDocument.NewEntity()
                    libElectronicDocument.AssignManage(manage)
                    libElectronicDocument.Data.Clear()

                    'Datos del comprobante
                    libElectronicDocument.Data.Version.Value = Version
                    If Serie <> "" Then
                        libElectronicDocument.Data.Serie.Value = Serie
                    End If
                    If Folio <> "" Then
                        libElectronicDocument.Data.Folio.Value = Folio
                    End If
                    libElectronicDocument.Data.Fecha.Value = Fecha
                    libElectronicDocument.Data.FormaPago.Value = FormaPago
                    If CondicionesPago <> "" Then
                        libElectronicDocument.Data.CondicionesPago.Value = CondicionesPago
                    End If
                    libElectronicDocument.Data.SubTotal.Value = Subtotal
                    libElectronicDocument.Data.Descuento.Value = Descuento
                    If MotivoDescuento <> "" Then
                        libElectronicDocument.Data.MotivoDescuento.Value = MotivoDescuento
                    End If
                    If TipoCambio <> "" Then
                        libElectronicDocument.Data.TipoCambio.Value = TipoCambio
                    End If
                    If Moneda <> "" Then
                        libElectronicDocument.Data.Moneda.Value = Moneda
                    End If
                    libElectronicDocument.Data.Total.Value = Total
                    libElectronicDocument.Data.TipoComprobante.Value = TipoComprobante
                    libElectronicDocument.Data.MetodoPago.Value = MetodoPago
                    libElectronicDocument.Data.LugarExpedicion.Value = LugarExpedicion
                    If NumeroCuentaPago <> "" Then
                        libElectronicDocument.Data.NumeroCuentaPago.Value = NumeroCuentaPago
                    End If
                    If FolioFiscalOriginal <> "" Then
                        libElectronicDocument.Data.FolioFiscalOriginal.Value = FolioFiscalOriginal
                    End If
                    If SerieFolioFiscalOriginal <> "" Then
                        libElectronicDocument.Data.SerieFolioFiscalOriginal.Value = SerieFolioFiscalOriginal
                    End If
                    If FechaFolioFiscalOriginal <> "" Then
                        If IsDate(FechaFolioFiscalOriginal) Then
                            libElectronicDocument.Data.FechaFolioFiscalOriginal.Value = FechaFolioFiscalOriginal
                        Else
                            resultado = "La fecha de folio fiscal original no es correcta."
                        End If
                    End If
                    If MontoFolioFiscalOriginal > 0 Then
                        libElectronicDocument.Data.MontoFolioFiscalOriginal.Value = MontoFolioFiscalOriginal
                    End If

                    'Datos del emisor
                    libElectronicDocument.Data.Emisor.Rfc.Value = empresa.ERfc
                    libElectronicDocument.Data.Emisor.Nombre.Value = empresa.ENombre
                    Dim regimenFiscal As RegimenFiscal = libElectronicDocument.Data.Emisor.Regimenes.Add()
                    regimenFiscal.Regimen.Value = empresa.ERegimen

                    If empresa.ECalle <> "" And empresa.ECiudad <> "" And empresa.EEstado <> "" And empresa.EPais <> "" And empresa.ECp <> "" And MostrarDomicilioEmisor Then
                        libElectronicDocument.Data.Emisor.Domicilio.Calle.Value = empresa.ECalle
                        If empresa.ENumero <> "" Then
                            libElectronicDocument.Data.Emisor.Domicilio.NumeroExterior.Value = empresa.ENumero
                        End If
                        If empresa.EColonia <> "" Then
                            libElectronicDocument.Data.Emisor.Domicilio.Colonia.Value = empresa.EColonia
                        End If
                        libElectronicDocument.Data.Emisor.Domicilio.Municipio.Value = empresa.ECiudad
                        libElectronicDocument.Data.Emisor.Domicilio.Estado.Value = empresa.EEstado
                        libElectronicDocument.Data.Emisor.Domicilio.Pais.Value = empresa.EPais
                        libElectronicDocument.Data.Emisor.Domicilio.CodigoPostal.Value = empresa.ECp
                    End If

                    If empresa.EPais <> "" And MostrarExpedidoEnEmisor Then
                        If empresa.ECalle <> "" Then
                            libElectronicDocument.Data.Emisor.ExpedidoEn.Calle.Value = empresa.ECalle
                        End If
                        If empresa.ENumero <> "" Then
                            libElectronicDocument.Data.Emisor.ExpedidoEn.NumeroExterior.Value = empresa.ENumero
                        End If
                        If empresa.EColonia <> "" Then
                            libElectronicDocument.Data.Emisor.ExpedidoEn.Colonia.Value = empresa.EColonia
                        End If
                        If empresa.ECiudad <> "" Then
                            libElectronicDocument.Data.Emisor.ExpedidoEn.Municipio.Value = empresa.ECiudad
                        End If
                        If empresa.EEstado <> "" Then
                            libElectronicDocument.Data.Emisor.ExpedidoEn.Estado.Value = empresa.EEstado
                        End If
                        libElectronicDocument.Data.Emisor.ExpedidoEn.Pais.Value = empresa.EPais
                        If empresa.ECp <> "" Then
                            libElectronicDocument.Data.Emisor.ExpedidoEn.CodigoPostal.Value = empresa.ECp
                        End If
                    End If

                    'Datos del receptor
                    libElectronicDocument.Data.Receptor.Rfc.Value = receptorRFC
                    If ReceptorNombre <> "" Then
                        libElectronicDocument.Data.Receptor.Nombre.Value = ReceptorNombre
                    End If
                    If ReceptorPais <> "" And MostrarDomicilioReceptor Then
                        If ReceptorCalle <> "" Then
                            libElectronicDocument.Data.Receptor.Domicilio.Calle.Value = ReceptorCalle
                        End If
                        If ReceptorNumeroExterior <> "" Then
                            libElectronicDocument.Data.Receptor.Domicilio.NumeroExterior.Value = ReceptorNumeroExterior
                        End If
                        If ReceptorNumeroInterior <> "" Then
                            libElectronicDocument.Data.Receptor.Domicilio.NumeroInterior.Value = ReceptorNumeroInterior
                        End If
                        If ReceptorColonia <> "" Then
                            libElectronicDocument.Data.Receptor.Domicilio.Colonia.Value = ReceptorColonia
                        End If
                        If ReceptorLocalidad <> "" Then
                            libElectronicDocument.Data.Receptor.Domicilio.Localidad.Value = ReceptorLocalidad
                        End If
                        If ReceptorMunicipio <> "" Then
                            libElectronicDocument.Data.Receptor.Domicilio.Municipio.Value = ReceptorMunicipio
                        End If
                        If ReceptorEstado <> "" Then
                            libElectronicDocument.Data.Receptor.Domicilio.Estado.Value = ReceptorEstado
                        End If
                        libElectronicDocument.Data.Receptor.Domicilio.Pais.Value = ReceptorPais
                        If ReceptorCodigoPostal <> "" Then
                            libElectronicDocument.Data.Receptor.Domicilio.CodigoPostal.Value = ReceptorCodigoPostal
                        End If
                    End If

                    'Conceptos
                    For Each row As DataRow In dtConceptos.Rows
                        Dim concepto = libElectronicDocument.Data.Conceptos.Add()
                        concepto.Cantidad.Value = row("Cantidad")
                        concepto.Cantidad.Decimals = row("Decimales")
                        concepto.Cantidad.Dot = row("Punto")
                        concepto.Unidad.Value = row("Unidad")
                        If row("NumeroIdentificacion") <> "" Then
                            concepto.NumeroIdentificacion.Value = row("NumeroIdentificacion")
                        End If
                        concepto.Descripcion.Value = row("Descripcion")
                        concepto.ValorUnitario.Value = row("ValorUnitario")
                        concepto.Importe.Value = row("Importe")
                        If row("CuentaPredial") <> "" Then
                            concepto.CuentaPredial.Numero.Value = row("CuentaPredial")
                        End If
                    Next

                    'Impuestos
                    If TotalImpuestosRetenidos > 0 Then
                        libElectronicDocument.Data.Impuestos.TotalRetenciones.Value = TotalImpuestosRetenidos

                        If Not dtImpuestosRetenidos Is Nothing Then
                            If dtImpuestosRetenidos.Rows.Count > 0 Then
                                For Each row As DataRow In dtImpuestosRetenidos.Rows
                                    Dim impRetenido = libElectronicDocument.Data.Impuestos.Retenciones.Add()
                                    impRetenido.Tipo.Value = row("Impuesto")
                                    impRetenido.Importe.Value = row("Importe")
                                Next
                            Else
                                resultado = "Falta ingresar los impuestos retenidos."
                                Return resultado
                            End If
                        Else
                            resultado = "Falta ingresar los impuestos retenidos."
                            Return resultado
                        End If
                    End If

                    If TotalImpuestosTrasladados > 0 Then
                        libElectronicDocument.Data.Impuestos.TotalTraslados.Value = TotalImpuestosTrasladados

                        If Not dtImpuestosTrasladados Is Nothing Then
                            If dtImpuestosTrasladados.Rows.Count > 0 Then
                                For Each row As DataRow In dtImpuestosTrasladados.Rows
                                    Dim impTrasladado = libElectronicDocument.Data.Impuestos.Traslados.Add()
                                    impTrasladado.Tipo.Value = row("Impuesto")
                                    impTrasladado.Tasa.Value = row("Tasa")
                                    impTrasladado.Importe.Value = row("Importe")
                                Next
                            Else
                                resultado = "Falta ingresar los impuestos trasladados."
                                Return resultado
                            End If
                        Else
                            resultado = "Falta ingresar los impuestos trasladados."
                            Return resultado
                        End If
                    End If

                    resultado = TimbrarCFDI(libElectronicDocument)
                    If resultado = "Timbrado" Then
                        Dim archivoXML As String = pathXML & empresa.ERfc & "\" & uuid.ToUpper & "_" & Date.Now.ToString("yyyyMMdd_Hmmss") & ".xml"
                        If Not existeCarpeta(IO.Path.GetDirectoryName(archivoXML)) Then
                            crearCarpeta(IO.Path.GetDirectoryName(archivoXML))
                        End If
                        If libElectronicDocument.SaveToFile(archivoXML) = False Then
                            resultado = libElectronicDocument.ErrorText
                        Else
                            Archivo = File.Open(archivoXML, FileMode.Open)
                            Dim Sr As StreamReader = New StreamReader(Archivo)
                            resultado = Sr.ReadToEnd()
                            Archivo.Close()
                        End If
                    End If
                End If
            Else
                resultado = "Usuario y/o contraseña inválidos."
            End If
        Catch ex As Exception
            resultado = ex.Message
            Archivo.Close()
        End Try

        Return resultado
    End Function

    Private Function iniciaCertificado(ByVal empresaId As Integer) As Boolean
        Dim dtDatos As New DataTable
        Dim rutaCertificado As String = String.Empty
        Dim rutaKey As String = String.Empty
        Dim contrasena As String = String.Empty
        Dim pathLista As String = path & "CSD.txt"

        Try
            empresa = consultaDatosEmpresa(empresaId, pruebas)
            If Not empresa Is Nothing Then
                If activarLibreria() Then
                    descargado = False
                    rutaCertificado = descargarArchivo(empresa.ERutacertificado)
                    If rutaCertificado = "" Then
                        msjError = "Error al descargar certificado."
                        Return False
                    ElseIf rutaCertificado <> "" And Not descargado Then
                        msjError = rutaCertificado
                        Return False
                    End If

                    descargado = False
                    rutaKey = descargarArchivo(empresa.ERutakey)
                    If rutaKey = "" Then
                        msjError = "Error al descargar archivo key."
                        Return False
                    ElseIf rutaKey <> "" And Not descargado Then
                        msjError = rutaKey
                    End If

                    contrasena = empresa.EContrasenacertificado
                    usuarioWS = empresa.EUsuariows
                    contrasenaWS = empresa.EContrasenaws
                    identificadorWS = empresa.EIdentificadorPax

                    certificate = ElectronicCertificate.NewEntity(rutaCertificado, rutaKey, contrasena)
                    manage = ElectronicManage.NewEntity()
                    manage.CertificateAuthorityList.UseForTest()
                    manage.CertificateRevocationList.FileName = pathLista
                    manage.CertificateRevocationList.Prepare()
                    manage.Save.AssignCertificate(certificate)

                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            msjError = ex.Message
            Return False
        End Try
    End Function

    Private Function activarLibreria() As Boolean
        Dim proxy As HyperSoft.ElectronicDocumentLibrary.Proxy = Nothing
        Try
            If HyperSoft.ElectronicDocumentLibrary.Activaction.ActivationStatus <> ActivationStatusType.Licensed Then
                Dim pathLincencia As String = String.Empty
                pathLincencia = path & "license.license"
                HyperSoft.ElectronicDocumentLibrary.Activaction.LoadActivationFile(pathLincencia, proxy)
                If HyperSoft.ElectronicDocumentLibrary.Activaction.ActivationStatus = ActivationStatusType.Licensed Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function TimbrarCFDI(ByVal libElectronicDocument As ElectronicDocument) As String
        Dim parameters As TimbrarParameters = TimbrarParameters.NewEntity()
        Dim proveedor As Proveedor = proveedor.NewEntity()
        Dim mensaje As String = String.Empty
        'Objeto que contiene la información retornada por el PAC
        Dim informacion As Informacion = informacion.NewEntity()

        'Parámetros a usar durante el proceso
        parameters.ElectronicDocument = libElectronicDocument
        parameters.Informacion = informacion
        parameters.TestMode = pruebas
        parameters.Usuario.Value = usuarioWS
        parameters.Password.Value = contrasenaWS
        parameters.Identificador.Value = identificadorWS

        'Timbra el documento
        Dim result As ProcessProviderResult = proveedor.TimbrarCfdi(parameters)

        If informacion.Timbre.IsAssigned Then
            uuid = informacion.Timbre.Uuid.AsString()
            mensaje = "Timbrado"
        End If

        If informacion.[Error].IsAssigned = True Then
            mensaje = informacion.[Error].Numero.Value & " - " & informacion.[Error].Descripcion.Value
        End If

        Return mensaje
    End Function
End Class
