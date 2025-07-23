Imports Libreria_CFDI_33.Datos
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Export
Imports ToolServicios
Imports System.IO
Imports System.Net

Public Class GenerarFacturaElectronicaBU


    'Dim ServidorRest As String = My.Settings.ServidorRestPruebasPruebas
    'Dim ServidorRest As String = My.Settings.ServidorRestLocal
    'Dim servidorrest As String = My.Settings.ServidorRestPruebasProduccion
    Dim servidorRest As String = My.Settings.ServidorRestProduccion
    Dim ServidorArchivosPDF As String = String.Empty

    Sub New()
        _Aviso = String.Empty
        _Respuesta = 0
        _RutaRest = String.Empty
        _RutaPDFServidor = String.Empty
        _RutaCliente = String.Empty
        _UUID = String.Empty
    End Sub
    ''' <summary>
    ''' Propiedad solo lectura que retorna un string con el mensaje que genera la función del timbrado
    ''' </summary>
    ''' <remarks>Aviso</remarks>
    Private _Aviso As String
    Public ReadOnly Property Aviso() As String
        Get
            Return _Aviso
        End Get
    End Property
    ''' <summary>
    ''' Propiedad solo lectura que retorna un valor entero que indica el estado de la funcion, 1 o 0 
    ''' </summary>
    ''' <remarks></remarks>
    Private _Respuesta As Int16
    Public ReadOnly Property Respuesta() As Int16
        Get
            Return _Respuesta
        End Get
    End Property
    ''' <summary>
    ''' Propiedad solo lectura que retorna una string con la ruta donde se encuentra el pdf en el servidor rest.
    ''' </summary>
    ''' <remarks></remarks>
    Private _RutaRest As String
    Public ReadOnly Property RutaRest() As String
        Get
            Return _RutaRest
        End Get
    End Property
    ''' <summary>
    ''' Propiedad solo lectura que retorna un string con la ruta donde se copiara el pdf.
    ''' </summary>
    ''' <remarks></remarks>
    Private _RutaPDFServidor As String
    Public ReadOnly Property RutaPDFServidor() As String
        Get
            Return _RutaPDFServidor
        End Get
    End Property
    ''' <summary>
    ''' Propiedad solo lectura que retorna un string con la ruta donde se colocara el pdf en el cliente.
    ''' </summary>
    ''' <remarks></remarks>
    Private _RutaCliente As String
    Public ReadOnly Property RutaCliente() As String
        Get
            Return _RutaCliente
        End Get
    End Property
    ''' <summary>
    ''' Propiedad de solo lectura que retorna un string con la fecha en que se cancelo la nota de credito.
    ''' </summary>
    ''' <remarks></remarks>
    Private _FechaCancelacion As DateTime
    Public ReadOnly Property FechaCancelacion() As DateTime
        Get
            Return _FechaCancelacion
        End Get
    End Property
    Private _EstatusCancelacionID As String
    Public ReadOnly Property EstatusCancelacionID() As String
        Get
            Return _EstatusCancelacionID
        End Get
    End Property
    Private _EstatusCancelaciondescripcion As String
    Public ReadOnly Property EstatusCancelacionDescripcion() As String
        Get
            Return _EstatusCancelaciondescripcion
        End Get
    End Property

    ''' <summary>
    ''' Propiedad solo lectura que retorna el UUID de la nota de credto que se envio cancelar.
    ''' </summary>
    ''' <remarks></remarks>
    Private _UUID As String
    Public ReadOnly Property UUID() As String
        Get
            Return _UUID
        End Get
    End Property

    ''' <summary>
    ''' Genera la información de la nota de credito y envia xml.
    ''' </summary>
    ''' <param name="IdNotaCredito">Integer id de la nota de credito que se desea timbrar</param>
    Public Sub Folio(ByVal IdNotaCredito As Integer)

        Dim objDatos As New GenerarFacturaElectronicaDA
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim dtResultado As DataTable
        Dim Resultados() As String
        Dim NumeroDeError As Integer
        Dim MensajeDeError As String
        Dim idEmpresa As Integer
        '  Dim fallo As Boolean = 0


        Try
            dtResultado = objDatos.InsertaDatosTimbradoNotaDeCredito(IdNotaCredito)
            Resultados = dtResultado.Rows(0).Item("resultado").ToString.Split("|")
            NumeroDeError = CInt(Resultados(0))
            MensajeDeError = Resultados(1).ToString
            If NumeroDeError = 0 Then
                'IdNotaCredito = Resultados(1)
                idEmpresa = Resultados(2)
                'servidorRest = "http://localhost:7639/"
                llamarServicio.url = servidorRest & "NotasDeCredito/Timbrado?DocumentoID=" + CStr(IdNotaCredito) + "&EmpresaID=" + CStr(idEmpresa)
                llamarServicio.metodo = "GET"
                Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo
                _Respuesta = Respuesta.respuesta
                _Aviso = Respuesta.aviso
                If Respuesta.respuesta = 1 Then
                    _RutaRest = Respuesta.mensaje(0).ToString
                    _RutaPDFServidor = Respuesta.mensaje(1).ToString
                    _RutaCliente = Respuesta.mensaje(2).ToString
                    objDatos.ActualizaSICYDoctosElectronicos(IdNotaCredito, "NOTACREDITO", "XML", _RutaPDFServidor)

                End If
            Else
                'Manejar error controlado regresado del procedimiento almacenado
                'MsgBox(MensajeDeError)
                _Respuesta = 0
                _Aviso = MensajeDeError
            End If
        Catch ex As Exception
            'Manejar errror en el proceso de las capas
            'MsgBox(ex.Message)
            _Respuesta = 0
            _Aviso = ex.Message

        Finally
            llamarServicio = Nothing
            objDatos = Nothing
            dtResultado = Nothing
        End Try
    End Sub

    ''' <summary>
    ''' Envia la cancelacion del folio fiscal de la nota de credito y lee el xml que regresa el paq.
    ''' </summary>
    ''' <param name="IdNotaCredito">Integer id de la nota de credito que se desea timbrar</param>
    Public Sub folio_cancelacion(ByVal IdNotaCredito As Integer)

        Dim objDatos As New GenerarFacturaElectronicaDA
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim dtResultado As DataTable
        Dim idEmpresa As Integer
        Dim UUID As String
        Try
            dtResultado = objDatos.ObtenerUUIDEmpresaNotaDeCredito(IdNotaCredito)
            'IdNotaCredito = Resultados(1)
            idEmpresa = CInt(dtResultado.Rows(0).Item("EmpresaID"))
            UUID = CStr(dtResultado.Rows(0).Item("UUID"))
            llamarServicio.url = ServidorRest & "NotasDeCredito/TimbradoCancelacion?DocumentoID=" & CStr(IdNotaCredito) & "&UUID=" & UUID & "&EmpresaID=" & CStr(idEmpresa) & "&UsuarioID=236"
            llamarServicio.metodo = "GET"
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo
            _Respuesta = Respuesta.respuesta
            _Aviso = Respuesta.aviso
            If Respuesta.respuesta = 1 Then
                _RutaRest = Respuesta.mensaje(0).ToString
                _RutaPDFServidor = Respuesta.mensaje(1).ToString
                _RutaCliente = Respuesta.mensaje(2).ToString
                _FechaCancelacion = Convert.ToDateTime(Respuesta.mensaje(3))
                _UUID = UUID
                _EstatusCancelacionID = Respuesta.mensaje(4).ToString
                _EstatusCancelaciondescripcion = Respuesta.mensaje(5).ToString
            End If

        Catch ex As Exception
            'Manejar errror en el proceso de las capas
            'MsgBox(ex.Message)
            _Respuesta = 0
            _Aviso = ex.Message

        Finally
            llamarServicio = Nothing
            objDatos = Nothing
            dtResultado = Nothing
        End Try
    End Sub

    ''' <summary>
    ''' Genera documento en formato pdf
    ''' </summary>
    ''' <param name="IdNotaCredito">Integer identificador de la nota de credito</param>
    ''' <remarks></remarks>
    Public Sub GenerarPdf(ByVal IdNotaCredito As Integer)
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim idEmpresa As Integer
        Dim objDA As New GenerarFacturaElectronicaDA
        Dim dtEmpresa As DataTable
        Try
            dtEmpresa = objDA.ObtenerEmpresaIdTimbradoNotaDeCredito(IdNotaCredito)

            idEmpresa = CInt(dtEmpresa.Rows(0).Item("EmpresaId"))
            llamarServicio.url = ServidorRest & "NotasDeCredito/GenerarPDF?DocumentoID=" + CStr(IdNotaCredito) + "&EmpresaID=" + CStr(idEmpresa)
            llamarServicio.metodo = "GET"
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo
            _Respuesta = Respuesta.respuesta
            _Aviso = Respuesta.aviso
            If Respuesta.respuesta = 1 Then
                _RutaRest = Respuesta.mensaje(0).ToString
                _RutaPDFServidor = Respuesta.mensaje(1).ToString
                _RutaCliente = Respuesta.mensaje(2).ToString
                objDA.ActualizaSICYDoctosElectronicos(IdNotaCredito, "NOTACREDITO", "PDF", _RutaPDFServidor)
            End If
        Catch ex As Exception
            _Respuesta = 0
            _Aviso = "Error al generar pdf: " + ex.Message
        Finally
            llamarServicio = Nothing
        End Try
    End Sub

    Public Sub GenerarPdfCancelacion(ByVal IdNotaCredito As Integer)
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim objDA As New GenerarFacturaElectronicaDA
        Try
            llamarServicio.url = ServidorRest & "NotasDeCredito/GenerarPdfCancelacion?DocumentoID=" + CStr(IdNotaCredito)
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo
            _Respuesta = Respuesta.respuesta
            _Aviso = Respuesta.aviso
            If Respuesta.respuesta = 1 Then
                _RutaRest = Respuesta.mensaje(0).ToString
                _RutaPDFServidor = Respuesta.mensaje(1).ToString
                _RutaCliente = Respuesta.mensaje(2).ToString
            End If
        Catch ex As Exception
            _Respuesta = 0
            _Aviso = "Error al generar pdf: " + ex.Message
        Finally
            llamarServicio = Nothing
        End Try
    End Sub

    Public Sub CopiarDocumento()
        Dim Respuesta As RespuestaRestArray
        Try
            Respuesta = CopiarArchivoSICY(_RutaRest, _RutaPDFServidor, _RutaCliente)
            _Respuesta = Respuesta.respuesta
            _Aviso = Respuesta.aviso
        Catch ex As Exception
            _Respuesta = 0
            _Aviso = "Error al copiar Documento: " + ex.Message
        End Try
    End Sub

    Public Function CopiarArchivoSICY(ByVal RutaRest As String, ByVal RutaServidor As String, ByVal RutaCliente As String) As RespuestaRestArray
        Dim myWebClient As New WebClient()
        Dim respuesta As New RespuestaRestArray()
        Try
            Dim objDA As New GenerarFacturaElectronicaDA
            Dim dtInformacion As DataTable
            dtInformacion = objDA.ObtenerRutaServidorREST()
            If IsNothing(dtInformacion) = False Then
                If dtInformacion.Rows.Count > 0 Then
                    ServidorArchivosPDF = dtInformacion.Rows(0).Item(0)
                End If
            Else
                ServidorArchivosPDF = String.Empty
            End If

            Dim url As String

            If ServidorRest.ToString.Contains("local") Then
                url = RutaRest
            Else
                url = Replace(RutaRest, "C:\inetpub\wwwroot\Facturacion33\", ServidorArchivosPDF)
            End If
            CrearDirectorio(RutaCliente)
            myWebClient.DownloadFile(url, RutaCliente)
            CrearDirectorio(RutaServidor)
            File.Copy(RutaCliente, RutaServidor, True)
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

    Public Sub prueba()
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = My.Settings.ServidorRestPruebasPruebas
        Try
            llamarServicio.url = Servidor & "NotasDeCredito/prueba"
            llamarServicio.metodo = "GET"
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo
            _Respuesta = Respuesta.respuesta
            _Aviso = Respuesta.aviso
        Catch ex As Exception
            _Respuesta = 0
            _Aviso = ex.Message
        Finally
            llamarServicio = Nothing
        End Try
    End Sub

    Public Function ObtenerUUIDNOtaDeCredito(ByVal IdNotaCredito As Integer) As String
        Dim dtResultado As DataTable
        Dim objDA As New GenerarFacturaElectronicaDA
        Dim UUID As String = String.Empty
        Try
            dtResultado = objDA.ObtenerUUIDNotaDeCredito(IdNotaCredito)
            If Not IsNothing(dtResultado) Then
                If dtResultado.Rows.Count Then
                    UUID = CStr(dtResultado.Rows(0).Item("UUID"))
                End If
            End If
            Return UUID
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "ComplementoPago"
    ''' <summary>
    ''' Envia xml del complemento de pago mediante una solicitud al servicio rest.
    ''' </summary>
    ''' <param name="DocumentoID">Integer id del complemento que se desea timbrar</param>
    Public Sub FolioComplementoPago(ByVal DocumentoID As Integer, ByVal idEmpresa As Integer)

        Dim objDatos As New GenerarFacturaElectronicaDA
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim dtResultado As DataTable
        Try
            llamarServicio.url = ServidorRest & "ComplementoPago/Timbrado?DocumentoID=" + CStr(DocumentoID) + "&EmpresaID=" + CStr(idEmpresa)
            llamarServicio.metodo = "GET"
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo
            _Respuesta = Respuesta.respuesta
            _Aviso = Respuesta.aviso
            If Respuesta.respuesta = 1 Then
                _RutaRest = Respuesta.mensaje(0).ToString
                _RutaPDFServidor = Respuesta.mensaje(1).ToString
                _RutaCliente = Respuesta.mensaje(2).ToString
                objDatos.ActualizaSICYDoctosElectronicos(DocumentoID, "COMPLEMENTOPAGO", "XML", _RutaPDFServidor, "TIMBRADO")
            End If
        Catch ex As Exception
            'Manejar errror en el proceso de las capas
            'MsgBox(ex.Message)
            _Respuesta = 0
            _Aviso = ex.Message

        Finally
            llamarServicio = Nothing
            objDatos = Nothing
            dtResultado = Nothing
        End Try
    End Sub

    Public Sub GenerarPdfComplementoPago(ByVal documentoID As Integer)
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim idEmpresa As Integer
        Dim objDA As New GenerarFacturaElectronicaDA
        Dim dtEmpresa As DataTable
        Try
            dtEmpresa = objDA.ObtenerEmpresaIdTimbradoNotaDeCredito(documentoID)

            idEmpresa = CInt(dtEmpresa.Rows(0).Item("EmpresaId"))
            ' idEmpresa = 19
            'servidorRest = "http://localhost:7639/"
            llamarServicio.url = servidorRest & "ComplementoPago/GenerarPDF?DocumentoID=" + CStr(documentoID) + "&EmpresaID=" + CStr(idEmpresa)
            llamarServicio.metodo = "GET"
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo
            _Respuesta = Respuesta.respuesta
            _Aviso = Respuesta.aviso
            If Respuesta.respuesta = 1 Then
                _RutaRest = Respuesta.mensaje(0).ToString
                _RutaPDFServidor = Respuesta.mensaje(1).ToString
                _RutaCliente = Respuesta.mensaje(2).ToString
                objDA.ActualizaSICYDoctosElectronicos(documentoID, "COMPLEMENTOPAGO", "PDF", _RutaPDFServidor, "TIMBRADO")
            End If
        Catch ex As Exception
            _Respuesta = 0
            _Aviso = "Error al generar pdf: " + ex.Message
        Finally
            llamarServicio = Nothing
        End Try
    End Sub
    ''' <summary>
    ''' Genera la cancelacion del comprobante de pago
    ''' </summary>
    ''' <param name="DocumentoID"></param>
    ''' <remarks>DocumentoID: integer que indentifica el documento que se cancela. </remarks>
    Public Sub folioComplementoPago_cancelacion(ByVal DocumentoID As Integer)

        Dim objDatos As New GenerarFacturaElectronicaDA
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim dtResultado As DataTable
        Dim idEmpresa As Integer
        Dim UUID As String
        Try
            dtResultado = objDatos.ObtenerUUIDEmpresaComplementoPago(DocumentoID)
            'IdNotaCredito = Resultados(1)
            idEmpresa = CInt(dtResultado.Rows(0).Item("EmpresaID"))
            UUID = CStr(dtResultado.Rows(0).Item("UUID"))
            llamarServicio.url = ServidorRest & "ComplementoPago/TimbradoCancelacion?DocumentoID=" & CStr(DocumentoID) & "&UUID=" & UUID & "&EmpresaID=" & CStr(idEmpresa) & "&UsuarioID=236"
            llamarServicio.metodo = "GET"
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo
            _Respuesta = Respuesta.respuesta
            _Aviso = Respuesta.aviso
            If Respuesta.respuesta = 1 Then
                _RutaRest = Respuesta.mensaje(0).ToString
                _RutaPDFServidor = Respuesta.mensaje(1).ToString
                _RutaCliente = Respuesta.mensaje(2).ToString
                _FechaCancelacion = Convert.ToDateTime(Respuesta.mensaje(3))
                _UUID = UUID
                _EstatusCancelacionID = Respuesta.mensaje(4).ToString
                _EstatusCancelaciondescripcion = Respuesta.mensaje(5).ToString
                objDatos.ActualizaSICYDoctosElectronicos(DocumentoID, "COMPLEMENTOPAGO", "XML", _RutaPDFServidor, "TIMBRADO_CANCELACION")
            End If

        Catch ex As Exception
            'Manejar errror en el proceso de las capas
            'MsgBox(ex.Message)
            _Respuesta = 0
            _Aviso = ex.Message

        Finally
            llamarServicio = Nothing
            objDatos = Nothing
            dtResultado = Nothing
        End Try
    End Sub

    Public Sub GenerarPdfComplementoPagoCancelacion(ByVal documentoID As Integer)
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim objDA As New GenerarFacturaElectronicaDA
        Try
            llamarServicio.url = ServidorRest & "ComplementoPago/GenerarPdfCancelacion?DocumentoID=" + CStr(documentoID)
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo
            _Respuesta = Respuesta.respuesta
            _Aviso = Respuesta.aviso
            If Respuesta.respuesta = 1 Then
                _RutaRest = Respuesta.mensaje(0).ToString
                _RutaPDFServidor = Respuesta.mensaje(1).ToString
                _RutaCliente = Respuesta.mensaje(2).ToString
                objDA.ActualizaSICYDoctosElectronicos(documentoID, "COMPLEMENTOPAGO", "PDF", _RutaPDFServidor, "TIMBRADO_CANCELACION")
            End If
        Catch ex As Exception
            _Respuesta = 0
            _Aviso = "Error al generar pdf: " + ex.Message
        Finally
            llamarServicio = Nothing
        End Try
    End Sub

#End Region


End Class
