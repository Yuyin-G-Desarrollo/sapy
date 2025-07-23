Imports System.Net
Imports Programacion.Negocios
Public Class FotoModeloForm

    Private _NombreFoto As String = String.Empty      '"33011/JEANS ACTIVA 1627 NAPA negro.jpg"
    Public Property NombreFoto() As String
        Get
            Return _NombreFoto
        End Get
        Set(ByVal value As String)
            _NombreFoto = value
        End Set
    End Property

    Private _Marca As String = String.Empty
    Public Property Marca() As String
        Get
            Return _Marca
        End Get
        Set(ByVal value As String)
            _Marca = value
        End Set
    End Property

    Private _Coleccion As String = String.Empty
    Public Property Coleccion() As String
        Get
            Return _Coleccion
        End Get
        Set(ByVal value As String)
            _Coleccion = value
        End Set
    End Property

    Private _ModeloSicy As String = String.Empty
    Public Property ModeloSicy() As String
        Get
            Return _ModeloSicy
        End Get
        Set(ByVal value As String)
            _ModeloSicy = value
        End Set
    End Property

    Private _ModeloSay As String
    Public Property ModleoSay() As String
        Get
            Return _ModeloSay
        End Get
        Set(ByVal value As String)
            _ModeloSay = value
        End Set
    End Property

    Private _Talla As String = String.Empty
    Public Property Talla() As String
        Get
            Return _Talla
        End Get
        Set(ByVal value As String)
            _Talla = value
        End Set
    End Property

    Private _ProductoEstiloId As Integer = 0
    Public Property ProductoEstiloId() As Integer
        Get
            Return _ProductoEstiloId
        End Get
        Set(ByVal value As Integer)
            _ProductoEstiloId = value
        End Set
    End Property





    Dim objFTP As New Global.Tools.TransferenciaFTP
    Dim rutaFtp As String = objFTP.obtenerURL
    Dim FtpUser As String = objFTP.obtenerUsuario
    Dim ftppasswd As String = objFTP.obtenerContrasena
    Dim msgError As New Tools.ErroresForm
    Dim objEtiquetas As New EtiquetasBU

    Private Sub FotoModeloForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim Carpeta As String = "Programacion/Modelos/"
            Dim objFTP As New Tools.TransferenciaFTP
            Dim StreamFoto As System.IO.Stream

            If _ProductoEstiloId > 0 Then
                _NombreFoto = objEtiquetas.ObtenerImagenProductoEstilo(_ProductoEstiloId)
                If _NombreFoto <> "" Then
                    StreamFoto = objFTP.StreamFile(Carpeta, _NombreFoto)
                    Using ms As New IO.MemoryStream()
                        StreamFoto.CopyTo(ms)
                        ms.Position = 0
                        picFoto.Image = Image.FromStream(ms)
                    End Using

                    lblDescripcion.Text = _Marca & " " & _Coleccion & " " & _ModeloSay & " (" & _ModeloSicy & ")"
                    Return
                Else
                    ' Si no hay nombre de imagen o falló la anterior, cargar imagen por defecto
                    StreamFoto = objFTP.StreamFile(Carpeta, "ImagenModeloNoEncontrada.png")

                    Using msDefault As New IO.MemoryStream()
                        StreamFoto.CopyTo(msDefault)
                        msDefault.Position = 0
                        picFoto.Image = Image.FromStream(msDefault)
                    End Using
                End If
            Else
                ' Intentamos cargar la imagen principal
                If _NombreFoto.Trim.Length > 0 Then
                    Try
                        StreamFoto = objFTP.StreamFile(Carpeta, _NombreFoto)
                        Using ms As New IO.MemoryStream()
                            StreamFoto.CopyTo(ms)
                            ms.Position = 0
                            picFoto.Image = Image.FromStream(ms)
                        End Using

                        lblDescripcion.Text = _Marca & " " & _Coleccion & " " & _ModeloSay & " (" & _ModeloSicy & ")"
                        Return
                    Catch exFoto As Exception
                        ' Si no hay nombre de imagen o falló la anterior, cargar imagen por defecto
                        StreamFoto = objFTP.StreamFile(Carpeta, "ImagenModeloNoEncontrada.png")

                        Using msDefault As New IO.MemoryStream()
                            StreamFoto.CopyTo(msDefault)
                            msDefault.Position = 0
                            picFoto.Image = Image.FromStream(msDefault)
                        End Using
                    End Try
                Else
                    ' Si no hay nombre de imagen o falló la anterior, cargar imagen por defecto
                    StreamFoto = objFTP.StreamFile(Carpeta, "ImagenModeloNoEncontrada.png")

                    Using msDefault As New IO.MemoryStream()
                        StreamFoto.CopyTo(msDefault)
                        msDefault.Position = 0
                        picFoto.Image = Image.FromStream(msDefault)
                    End Using
                End If
            End If
        Catch ex As Exception
            msgError.mensaje = ex.Message & vbCrLf & ex.Source & vbCrLf & ex.StackTrace
            msgError.ShowDialog()
        End Try
        ''Try
        ''    If _NombreFoto.Trim.Length > 0 Then
        ''        Dim request = DirectCast(WebRequest.Create(rutaFtp), FtpWebRequest)
        ''        request.Credentials = New NetworkCredential(FtpUser, ftppasswd)
        ''        Dim Carpeta As String = "Programacion/Modelos/"
        ''        Dim objFTP As New Tools.TransferenciaFTP
        ''        Dim StreamFoto As System.IO.Stream
        ''        StreamFoto = objFTP.StreamFile(Carpeta, _NombreFoto)
        ''        picFoto.Image = Image.FromStream(StreamFoto)
        ''        lblDescripcion.Text = _Marca & " " & _Coleccion & " " & _ModeloSay & " (" & _ModeloSicy & ")"
        ''    Else
        ''        picFoto.Image = Global.Programacion.Vista.My.Resources.Resources.sin_imagen
        ''    End If

        ''Catch ex As Exception
        ''    msgError.mensaje = ex.Message + vbCrLf + ex.Source + vbCrLf + ex.StackTrace
        ''    msgError.ShowDialog()
        ''End Try
    End Sub
    Private Sub FotoModeloForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCerrar_KeyDown(sender As Object, e As KeyEventArgs) Handles btnCerrar.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class