Imports System.Net
Imports Facturacion.Datos
Imports System.IO
Imports ToolServicios

Public Class UtileriasFacturasBU

    Dim Servidor As String = String.Empty

    Sub New()
        Dim objDA As New UtileriasFacturasDA
        Dim dtInformacion As DataTable
        dtInformacion = objDA.ObtenerRutaServidorREST()
        If IsNothing(dtInformacion) = False Then
            If dtInformacion.Rows.Count > 0 Then
                Servidor = dtInformacion.Rows(0).Item(0)
            End If
        Else
            Servidor = String.Empty
        End If

    End Sub

    Public Function CopiarArchivoSICY(ByVal RutaRest As String, ByVal RutaServidor As String, ByVal RutaCliente As String, Optional ByVal local As Boolean = False, Optional ByVal RutaContabilidad As String = "") As RespuestaRestArray
        Dim myWebClient As New WebClient()
        Dim respuesta As New RespuestaRestArray()
        Try
            Dim url As String
            If local Then
                url = RutaRest
            Else
                url = Replace(RutaRest, "C:\inetpub\wwwroot\Facturacion33\", Servidor)
            End If
            CrearDirectorio(RutaCliente)
            myWebClient.DownloadFile(url, RutaCliente)
            CrearDirectorio(RutaServidor)
            File.Copy(RutaCliente, RutaServidor, True)

            'url = Replace(RutaRest, "C:\inetpub\wwwroot\Facturacion33\", "\\192.168.2.158\cfdi\")
            'File.Copy(url, RutaServidor, True)

            'CrearDirectorio(RutaServidor)
            'File.Copy(RutaRest, RutaServidor, True)

            If RutaContabilidad <> String.Empty Then
                CrearDirectorio(RutaContabilidad)
                File.Copy(RutaCliente, RutaContabilidad, True)
            End If

            respuesta.respuesta = 1
            respuesta.aviso = "Se Copio correctamente el archivo en el servidor."
            respuesta.mensaje = Nothing
        Catch ex As Exception
            respuesta.respuesta = 0
            respuesta.aviso = "Error UtileriasFaturas CopiarArchivoSICY : " & ex.Message
            respuesta.mensaje = Nothing
        End Try

        Return respuesta
    End Function

    Public Function existeArchivoServidor(ByVal RutaArchivo As String, Optional ByVal local As Boolean = False) As RespuestaRestArray
        Dim myWebClient As New WebClient()
        Dim respuesta As New RespuestaRestArray()
        Try
            Dim url As String
            If local Then
                url = RutaArchivo
            Else
                url = Replace(RutaArchivo, "C:\inetpub\wwwroot\Facturacion33\", Servidor)
            End If

            If File.Exists(RutaArchivo) Then
                respuesta.respuesta = 1
                respuesta.aviso = "El archivo existe en el servidor."
                respuesta.mensaje = Nothing
            Else
                respuesta.respuesta = 0
                respuesta.aviso = "El archivo no existe en el servidor."
                respuesta.mensaje = Nothing
            End If
        Catch ex As Exception
            respuesta.respuesta = 0
            respuesta.aviso = "Error UtileriasFaturas existeArchivoServidor: " & ex.Message
            respuesta.mensaje = Nothing
        End Try

        Return respuesta
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

    'Public Function CopiarArchivoCliente(ByVal RutaPDF As String, ByVal EmpresaID As Integer, ByVal TipoComprobante As String, ByVal TipoDocumento As String) As String
    '    Dim DirectorioCliente As String = String.Empty
    '    Dim dtDirectorio As DataTable
    '    Dim objDA As New DatosDocumentoDA
    '    Dim FileName As String = String.Empty
    '    Try
    '        dtDirectorio = objDA.ObtenerRutaCliente(EmpresaID, TipoComprobante, TipoDocumento)

    '        If dtDirectorio.Rows.Count > 0 Then
    '            DirectorioCliente = dtDirectorio.Rows(0).Item(0)
    '            DirectorioCliente &= Date.Now.ToString("MMyyyy") & "\"
    '            If System.IO.Directory.Exists(DirectorioCliente) = False Then
    '                '    System.IO.Directory.CreateDirectory(DirectorioPDFSICY)
    '            End If

    '            FileName = Path.GetFileName(RutaPDF)
    '            DirectorioCliente &= FileName
    '        End If
    '    Catch ex As Exception
    '        DirectorioCliente = String.Empty
    '        Throw ex
    '    End Try
    '    Return DirectorioCliente
    'End Function

    Public Function ObtenerDirectorios(ByVal EmpresaID As Integer, ByVal TipoComprobante As Integer, ByVal TipoDocumento As String) As Entidades.RutasDocumentosFacturacion
        Dim DirectorioCliente As String = String.Empty
        Dim dtDirectorio As DataTable
        Dim objDA As New DatosDocumentoDA
        Dim FileName As String = String.Empty
        Dim EntidadRutas As New Entidades.RutasDocumentosFacturacion
        Try
            dtDirectorio = objDA.ObtenerDirectoriosDocumentosFacturacion(EmpresaID, TipoComprobante, TipoDocumento)
            Dim objConvertidor As New Convertidor(Of Entidades.RutasDocumentosFacturacion)()
            EntidadRutas = objConvertidor.DataTableToClase(dtDirectorio)
            EntidadRutas.RutaCliente &= Date.Now.ToString("MMyyyy") & "\"
            EntidadRutas.RutaSICY &= Date.Now.ToString("MMyyyy") & "\"
            EntidadRutas.RutaServicioRest &= Date.Now.ToString("MMyyyy") & "\"
            Return EntidadRutas
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerTipoComprobanteId(ByVal TipoComprobante As String) As Integer
        Dim objDA As New DatosDocumentoDA
        Dim dtResultado As New DataTable
        Dim resultado As Integer = 1

        dtResultado = objDA.ObtenerTipoComprobanteId(TipoComprobante)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0).Item("TipoComprobanteId")
            End If
        End If

        Return resultado
    End Function

    Public Function ObtenerDirectoriosNomina(ByVal EmpresaID As Integer, ByVal TipoComprobante As Integer, ByVal TipoDocumento As String) As Entidades.RutasDocumentosFacturacion
        Dim DirectorioCliente As String = String.Empty
        Dim dtDirectorio As DataTable
        Dim objDA As New DatosDocumentoDA
        Dim FileName As String = String.Empty
        Dim EntidadRutas As New Entidades.RutasDocumentosFacturacion
        Try
            dtDirectorio = objDA.ObtenerDirectoriosDocumentosFacturacion(EmpresaID, TipoComprobante, TipoDocumento)
            Dim objConvertidor As New Convertidor(Of Entidades.RutasDocumentosFacturacion)()
            EntidadRutas = objConvertidor.DataTableToClase(dtDirectorio)
            Return EntidadRutas
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function ObtenerRutaLogoEmpresa(ByVal EmpresaID As Integer) As String
        Dim objDa As New Datos.UtileriasFacturasDA
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
        Dim objDa As New Datos.UtileriasFacturasDA
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

    Public Function ObtenerLogoEmpresa(ByVal EmpresaID As Integer) As String
        Dim RutaLogo As String = String.Empty
        Dim objFTP As New TransferenciaFTPBU
        Dim Directorio As String = String.Empty
        Dim NombreArchivo As String = String.Empty
        RutaLogo = ObtenerRutaLogoEmpresa(EmpresaID)

        If RutaLogo <> String.Empty Then
            RutaLogo = "C:/" & RutaLogo
            Directorio = Path.GetDirectoryName(RutaLogo)
            If System.IO.Directory.Exists(Directorio) = False Then
                System.IO.Directory.CreateDirectory(Directorio)
            End If
            NombreArchivo = Path.GetFileName(RutaLogo)
            Directorio = Replace(Directorio, "C:", "")
            Directorio = Replace(Directorio, "c:", "")
            Directorio = Replace(Directorio, "\", "/")
            objFTP.DescargarArchivo(Directorio, Directorio, NombreArchivo)
        Else
            RutaLogo = String.Empty
        End If

        Return RutaLogo

    End Function




End Class
