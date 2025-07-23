Imports System.IO
Imports System.IO.FileStream
Imports System.Net

Public Class TransferenciaFTPBU

    Dim DestinoSubir As String = String.Empty
#Region "Propiedades"
    Private _Message As String = String.Empty
    ''' <summary>
    ''' Muestra un mensaje sobre la operaciones ejecutadas
    ''' </summary>
    ''' <value></value>
    ''' <returns>Regresa una cadena vacia si se ejecuto correctamente la operacion</returns>
    ''' <remarks></remarks>
    Public Property Message() As String
        Get
            Return _Message
        End Get
        Set(ByVal value As String)
            If _Message <> value Then
                _Message = value
            End If
        End Set
    End Property

    Private _hostname As String
    ''' <summary>
    ''' Nombre del Host
    ''' </summary>
    ''' <value></value>
    ''' <remarks>Nombre del Host puede ser en formato URL completa
    ''' ftp://ftp.myhost.com o como ftp.myhost.com
    ''' </remarks>
    Public Property Hostname() As String
        Get
            If _hostname.StartsWith("ftp://") Then
                Return _hostname
            Else
                Return "ftp://" & _hostname
            End If
        End Get
        Set(ByVal value As String)
            _hostname = value
        End Set
    End Property
    Private _username As String
    ''' <summary>
    ''' Propiedad Nombre de usuario
    ''' </summary>
    ''' <value></value>
    ''' <remarks>Puedes dejarlo en blanco, es ese caso va a regregar el valor 'anonymous'</remarks>
    Public Property Username() As String
        Get
            Return IIf(_username = "", "anonymous", _username)
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property
    Private _password As String
    ''' <summary>
    ''' Propiedad Contraseña o password
    ''' </summary>
    ''' <value>Contraseña del ftp</value>
    ''' <returns>Cadena con la contraseña del ftp</returns>
    ''' <remarks></remarks>
    Public Property Password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property

#End Region
#Region "Contructores"
    ''' <summary>
    ''' Contructor en blanco
    ''' </summary>
    ''' <remarks>Nombre del Host, Usuario y Contraseña pueden ser configurados manualmente</remarks>
    Sub New()
        _hostname = My.Settings.progftpURL
        _password = My.Settings.progftpPassword
        _username = My.Settings.progftpUser

        '_hostname = ftpUrl
        '_password = pass
        '_username = user
    End Sub

    ''' <summary>
    ''' Contructor toma el nombre del host
    ''' </summary>
    ''' <param name="Hostname">puede ser en la forma ftp://ftp.host.com o ftp.host.com </param>
    ''' <remarks></remarks>
    Sub New(ByVal Hostname As String)
        _hostname = Hostname
    End Sub

    ''' <summary>
    ''' El constructor toma el nombre de host, usuario y contraseña
    ''' </summary>
    ''' <param name="Hostname">Puede ser en la forma ftp://ftp.host.com o ftp.host.com </param>
    ''' <param name="Username">Dejar en blanco para usar 'anonymous'</param>
    ''' <param name="Password"></param>
    ''' <remarks></remarks>
    Sub New(ByVal Hostname As String, ByVal Username As String, ByVal Password As String)
        _hostname = Hostname
        _username = Username
        _password = Password
    End Sub
#End Region

    Public Function obtenerURL() As String
        Return My.Settings.progftpURL
    End Function

    Public Function obtenerUsuario() As String
        Return My.Settings.progftpUser
    End Function

    Public Function obtenerContrasena() As String
        Return My.Settings.progftpPassword
    End Function



    ''' <summary>
    ''' Copia un archivo a la carpetaDestino en la ruta predeterminada
    ''' </summary>
    ''' <param name="CarpetaDestino">Nombre de la carpeta en la que se va a copiar el archivo</param>
    ''' <param name="archivo">Ruta y nombre del archivo a copiar a la carpeta destino</param>
    ''' <remarks></remarks>
    Public Sub EnviarArchivo(ByVal CarpetaDestino As String, ByVal archivo As String)

        Try

            Dim Carpeta As String = String.Empty

            Carpeta = Path.Combine(_hostname, CarpetaDestino & "\")

            If ExisteDirectorio(Carpeta) = False Then
                Creardirectorios(CarpetaDestino)
            End If

            Upload(archivo, CarpetaDestino)

        Catch ex As Exception
            Message = Message + "Ocurrio el siguiente error: " + ex.Message + " Origen: " + ex.Source + " "
        End Try


    End Sub

    ''' <summary>
    ''' Obtiene una copia del archivo desde la carpetaOrigen de la ruta predeterminada hasta la carpetadestino
    ''' </summary>
    ''' <param name="carpetaOrigen">Nombre de la carpeta que contiene el archivo solicitado</param>
    ''' <param name="CarpetaDestino">Nombre y ruta de la carpeta en la que se va a copiar el archivo</param>
    ''' <param name="archivo">Nombre del archivo que se desea copiar</param>
    ''' <remarks></remarks>
    Public Sub DescargarArchivo(ByVal carpetaOrigen As String, ByVal CarpetaDestino As String, ByVal archivo As String)

        Dim CadenaErrores As String = String.Empty
        carpetaOrigen = "/" + carpetaOrigen
        Try

            Dim Carpeta As String = String.Empty

            Carpeta = _hostname & carpetaOrigen & "/"

            If ExisteDirectorio(Carpeta) = True Then
                If FtpFileExists(Carpeta & archivo) = True Then

                    If Directory.Exists(CarpetaDestino) = False Then
                        Directory.CreateDirectory(CarpetaDestino)
                    End If

                    Dim fi As New FileInfo(Path.Combine(CarpetaDestino, archivo))
                    Download(Carpeta & archivo, fi, True)
                Else
                    Message = "No existe el archivo solicitado "
                End If
            Else
                Message = "No existe la carpeta Origen "
            End If

        Catch ex As Exception
            Message = Message + "Ocurrio el siguiente error: " + ex.Message + " Origen: " + ex.Source + " "
        End Try

    End Sub

    Private Function CrearDirectorio(ByVal dirpath As String) As Boolean

        Dim URI As String = dirpath
        URI = URI.Replace("\", "/")
        Dim ftp As Net.FtpWebRequest = GetRequest(URI)
        ftp.Method = Net.WebRequestMethods.Ftp.MakeDirectory
        Try
            Dim str As String = GetStringResponse(ftp)
        Catch ex As Exception
            Return False
        End Try
        Return True

    End Function

    Private Sub Creardirectorios(ByVal dirpath As String)
        dirpath = dirpath.Replace("\", "/")
        Dim directorios() As String
        Dim carpeta As String = String.Empty
        directorios = dirpath.Split("/")
        carpeta = _hostname + "/"
        For i = 0 To directorios.Length - 1
            carpeta = Path.Combine(carpeta, directorios(i).ToString & "/")
            carpeta = carpeta.Replace("\", "/")
            DestinoSubir = carpeta
            If ExisteDirectorio(carpeta) = False Then
                If CrearDirectorio(carpeta) = False Then
                    Throw New Exception("Error al crear la carpeta")
                End If
            End If
        Next i

    End Sub

    Private Function ExisteDirectorio(ByVal directoryPath As String) As Boolean
        directoryPath = directoryPath.Replace("\", "/")
        ExisteDirectorio = False

        Dim request = DirectCast(WebRequest.Create(directoryPath), FtpWebRequest)

        request.Credentials = New NetworkCredential(_username, _password)

        request.Method = WebRequestMethods.Ftp.ListDirectory

        Try
            Using response As FtpWebResponse = DirectCast(request.GetResponse(), FtpWebResponse)
                Return True
                'existe
            End Using
        Catch ex As WebException

            Dim response As FtpWebResponse = DirectCast(ex.Response, FtpWebResponse)
            If response.StatusCode = FtpStatusCode.ActionNotTakenFileUnavailable Then
                Return False
                'No existe
            End If

            If ex.Status = WebExceptionStatus.ConnectFailure Then
                Throw New Exception("Fallo la conexion al servidor")
            End If

            If ex.Status = WebExceptionStatus.ProtocolError Then
                Throw New Exception("Nombre de usuario o contraseña incorrecta.")
            End If

            Throw New Exception(ex.Message)

        End Try

    End Function

    ''' <summary>
    ''' Determina si existe un archivo en el ftp 
    ''' </summary>
    ''' <param name="filename">Nombre del archivo (Ruta completa) </param>
    ''' <returns></returns>
    ''' <remarks>Nota: Solo funciona para archivos</remarks>
    Private Function FtpFileExists(ByVal filename As String) As Boolean
        'tratar de obtener el tañao del archivo: if se consigue el mensaje de error que contenga "550"
        'el archivo no existe
        Try
            Dim size As Long = GetFileSize(filename)
            Return True

        Catch ex As Exception

            If TypeOf ex Is System.Net.WebException Then
                If ex.Message.Contains("550") Then
                    Return False
                Else
                    Throw
                End If
            Else
                Throw
            End If
        End Try
    End Function

    ''' <summary>
    ''' Determina el tamaño del archivo remoto
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <returns></returns>
    ''' <remarks>Lanza una excepcion si no existe el archivo</remarks>
    Private Function GetFileSize(ByVal filename As String) As Long
        Dim URI As String = filename
        Dim ftp As Net.FtpWebRequest = GetRequest(URI)
        'Trata de conseguir la informacion del archivo o directorio
        ftp.Method = Net.WebRequestMethods.Ftp.GetFileSize
        Dim tmp As String = Me.GetStringResponse(ftp)
        Return GetSize(ftp)

    End Function

#Region "Upload: Transferir un archivo al servidor ftp"
    ''' <summary>
    ''' Copiar un archivo al servidor FTP
    ''' </summary>
    ''' <param name="localFilename">Ruta completa del archivo local</param>
    ''' <param name="CarpetaDestino">Nombre del archivo destino</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Upload(ByVal localFilename As String, ByVal CarpetaDestino As String) As Boolean
        If Not File.Exists(localFilename) Then
            Throw New ApplicationException("File " & localFilename & " not found")
        End If
        Dim fi As New FileInfo(localFilename)

        Return Upload(fi, CarpetaDestino)
    End Function

    ''' <summary>
    ''' Copia un archivo locar al servidor FTP
    ''' </summary>
    ''' <param name="fi">Archivo origen</param>
    ''' <param name="CarpetaDestino">Archivo Destino</param>
    ''' <returns></returns>
    Private Function Upload(ByVal fi As FileInfo, ByVal carpetadestino As String) As Boolean

        carpetadestino = "/" + carpetadestino.Replace("\", "/")
        Dim URI As String = _hostname & carpetadestino & "/" & fi.Name

        Dim ftp As Net.FtpWebRequest = GetRequest(URI)

        ftp.Method = Net.WebRequestMethods.Ftp.UploadFile
        ftp.UseBinary = True

        ftp.ContentLength = fi.Length

        Const BufferSize As Integer = 2048
        Dim content(BufferSize - 1) As Byte, dataRead As Integer

        Using fs As FileStream = fi.OpenRead()
            Try
                Using rs As Stream = ftp.GetRequestStream
                    Do
                        dataRead = fs.Read(content, 0, BufferSize)
                        rs.Write(content, 0, dataRead)
                    Loop Until dataRead < BufferSize
                    rs.Close()
                End Using
            Catch ex As Exception
                Throw 'MessageBox.Show(ex.Message)
            Finally
                fs.Close()
            End Try
        End Using
        ftp = Nothing
        Return True
    End Function
#End Region

    Private Function Download(ByVal sourceFilename As String, ByVal targetFI As FileInfo, Optional ByVal PermitOverwrite As Boolean = False) As Boolean

        If targetFI.Exists And Not (PermitOverwrite) Then Throw New ApplicationException("Target file already exists")
        Dim URI As String = sourceFilename


        Dim ftp As Net.FtpWebRequest = GetRequest(URI)

        ftp.Method = Net.WebRequestMethods.Ftp.DownloadFile
        ftp.UseBinary = True
        Using response As FtpWebResponse = CType(ftp.GetResponse, FtpWebResponse)
            Using responseStream As Stream = response.GetResponseStream
                Using fs As FileStream = targetFI.OpenWrite
                    Try
                        Dim buffer(2047) As Byte
                        Dim read As Integer = 0
                        Do
                            read = responseStream.Read(buffer, 0, buffer.Length)
                            fs.Write(buffer, 0, read)
                        Loop Until read = 0
                        responseStream.Close()
                        fs.Flush()
                        fs.Close()
                    Catch ex As Exception
                        fs.Close()
                        targetFI.Delete()
                        Throw
                    End Try
                End Using
                responseStream.Close()
            End Using
            response.Close()
        End Using
        Return True
    End Function

    Public Sub RenombraArchivo(ByVal CarpetaDestino As String, ByVal ArchivoViejo As String, ByVal ArchivoNuevo As String)

        Dim Carpeta As String = _hostname + "/" + CarpetaDestino + "/" + ArchivoViejo
        Dim MyFtpWebRequest As System.Net.FtpWebRequest = CType(System.Net.FtpWebRequest.Create(Carpeta), FtpWebRequest)
        MyFtpWebRequest.Credentials = New System.Net.NetworkCredential(_username, _password)
        MyFtpWebRequest.Method = System.Net.WebRequestMethods.Ftp.Rename
        MyFtpWebRequest.RenameTo() = ArchivoNuevo

        Dim MyResponse As System.Net.FtpWebResponse

        Try
            MyResponse = CType(MyFtpWebRequest.GetResponse, FtpWebResponse)

            Dim MyStatusStr As String = MyResponse.StatusDescription
            Dim MyStatusCode As System.Net.FtpStatusCode = MyResponse.StatusCode

            If MyStatusCode <> Net.FtpStatusCode.FileActionOK Then
                Debug.WriteLine("*** El archivo: " & ArchivoViejo & " no pudo ser renombrado a: " & ArchivoNuevo & ". Estatus obtenido = " & MyStatusStr)
            Else
                Debug.WriteLine("El archivo: " & ArchivoViejo & " fue renombrado como: " & ArchivoNuevo & " con éxito " & Now.ToString)
            End If
        Catch ex As Exception
            Debug.WriteLine("*** El archivo: " & ArchivoViejo & " no pudo ser renombrado a: " & ArchivoNuevo & " Debido al siguiente error: " & ex.Message)

        End Try
    End Sub

    Public Sub BorraArchivo(ByVal CarpetaDestino As String, ByVal Archivo As String)

        Dim Carpeta As String = _hostname + "/" + CarpetaDestino + "/" + Archivo
        Dim MyFtpWebRequest As FtpWebRequest = CType(FtpWebRequest.Create(Carpeta), FtpWebRequest)
        MyFtpWebRequest.Credentials = New NetworkCredential(_username, _password)
        MyFtpWebRequest.Method = WebRequestMethods.Ftp.DeleteFile

        Dim MyResponse As System.Net.FtpWebResponse

        Try
            MyResponse = CType(MyFtpWebRequest.GetResponse, FtpWebResponse)

            Dim MyStatusStr As String = MyResponse.StatusDescription
            Dim MyStatusCode As System.Net.FtpStatusCode = MyResponse.StatusCode

            If MyStatusCode <> Net.FtpStatusCode.FileActionOK Then
                Debug.WriteLine("*** El archivo: " & Archivo & " no pudo ser borrado.  Estatus = " & MyStatusStr)
            Else
                Debug.WriteLine("El archivo: " & Archivo & " fue eliminado con éxito" & Now.ToString)
            End If
        Catch ex As Exception
            Debug.WriteLine("*** El archivo: " & Archivo & " no pudo ser eliminado debido al siguiente error: " & ex.Message)

        End Try

    End Sub

    Public Function ListarArchivos(ByVal CarpetaDestino As String) As List(Of String)

        Dim Carpeta As String = _hostname + "/" + CarpetaDestino + "/"

        Dim MyFtpWebRequest As FtpWebRequest = CType(System.Net.FtpWebRequest.Create(Carpeta), FtpWebRequest)
        MyFtpWebRequest.Credentials = New NetworkCredential(_username, _password)
        MyFtpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory

        Dim MyResponse As FtpWebResponse

        Try
            MyResponse = CType(MyFtpWebRequest.GetResponse, FtpWebResponse)

            Dim sr As StreamReader = New StreamReader(MyResponse.GetResponseStream)
            Dim str As String = sr.ReadLine
            Dim oList As New List(Of String)
            While str IsNot Nothing
                oList.Add(str)
                str = sr.ReadLine
            End While

            Return oList
        Catch ex As Exception
            Debug.WriteLine("*** Error: " & ex.Message)
            Return Nothing
        End Try

    End Function


#Region "Funciones privadas de soporte"
    'Obtiene el objeto basic FtpWebRequest con la configuracion comun y la seguridad
    Private Function GetRequest(ByVal URI As String) As FtpWebRequest
        'Crear la solicitud
        Dim result As FtpWebRequest = CType(FtpWebRequest.Create(URI), FtpWebRequest)
        'Fijar los detalles de la cuenta
        result.Credentials = GetCredentials()
        'no mantener vivo (modo liberar)
        result.KeepAlive = False
        Return result
    End Function

    ''' <summary>
    ''' Obtener las credenciales de nombre de usuario y contraseña
    ''' </summary>
    Private Function GetCredentials() As Net.ICredentials
        Return New Net.NetworkCredential(Username, Password)
    End Function

    ''' <summary>
    ''' Obtiene una secuencia de respuesta como una cadena
    ''' </summary>
    ''' <param name="ftp">Solicitud actual FTP</param>
    ''' <returns>Cadena conteniendo una respuesta</returns>
    ''' </remarks>El servidor FTP normalmente regresa una cadena con CR 
    ''' y no con CRLF. Usar respons.Replace(vbCR, vbCRLF) para convertir
    ''' a un cadena MSDOS <remarks>
    Private Function GetStringResponse(ByVal ftp As FtpWebRequest) As String
        'Obtener el resultado, la transmisión a una cadena
        Dim result As String = ""
        Using response As FtpWebResponse = CType(ftp.GetResponse, FtpWebResponse)
            Dim size As Long = response.ContentLength
            Using datastream As Stream = response.GetResponseStream
                Using sr As New StreamReader(datastream)
                    result = sr.ReadToEnd()
                    sr.Close()
                End Using
                datastream.Close()
            End Using
            response.Close()
        End Using
        Return result
    End Function

    ''' <summary>
    ''' Obtener el tamaño de una solicitud FTP
    ''' </summary>
    ''' <param name="ftp"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSize(ByVal ftp As FtpWebRequest) As Long
        Dim size As Long
        Using response As FtpWebResponse = CType(ftp.GetResponse, FtpWebResponse)
            size = response.ContentLength
            response.Close()
        End Using
        Return size
    End Function
#End Region

    ''' <summary>
    ''' Determina si existe un archivo en el ftp 
    ''' </summary>
    ''' <param name="filename">Nombre del archivo (Ruta completa) </param>
    ''' <returns></returns>
    ''' <remarks>Nota: Solo funciona para archivos</remarks>
    Public Function FtpExisteArchivo(ByVal filename As String) As Boolean
        'tratar de obtener el tañao del archivo: if se consigue el mensaje de error que contenga "550"
        'el archivo no existe
        Try
            Dim size As Long = GetFileSize(filename)
            Return True

        Catch ex As Exception

            If TypeOf ex Is System.Net.WebException Then
                If ex.Message.Contains("550") Then
                    Return False
                Else
                    Throw
                End If
            Else
                Throw
            End If
        End Try
    End Function
End Class
