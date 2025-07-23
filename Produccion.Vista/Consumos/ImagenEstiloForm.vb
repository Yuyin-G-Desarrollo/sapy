Imports System.Net
Imports Tools

Public Class ImagenEstiloForm
    Public imagen As String

    Private Sub ImagenEstiloForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        leerimagen()
    End Sub

    Public Sub leerimagen()
        If imagen <> "" Then
            Dim rutaImagen As String
            Dim nombreImagen As String


            rutaImagen = imagen
            nombreImagen = rutaImagen.Substring(rutaImagen.LastIndexOf("\") + 1)
            Try
                'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                Dim objFTP As New Tools.TransferenciaFTP
                Dim Stream As System.IO.Stream
                Stream = objFTP.StreamFile("Programacion/Modelos/", nombreImagen)
                pbxFoto.BackgroundImage = Image.FromStream(Stream)
            Catch
            End Try

        ElseIf imagen = "" Then

            Dim imagen As String = "noimage.jpg"
            Try
                'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                Dim objFTP As New Tools.TransferenciaFTP
                Dim Stream As System.IO.Stream
                Stream = objFTP.StreamFile("/Administracion/Proveedores/", imagen)

                pbxFoto.Image = Image.FromStream(Stream)
                pbxFoto.SizeMode = PictureBoxSizeMode.Normal
            Catch
            End Try
        End If

    End Sub
End Class