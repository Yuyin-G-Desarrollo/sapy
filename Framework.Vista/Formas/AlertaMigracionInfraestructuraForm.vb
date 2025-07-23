Imports System.IO
Imports System.Net
Imports Framework.Negocios
Imports Tools

Public Class AlertaMigracionInfraestructuraForm

    Private Sub AlertaMigracionInfraestructuraForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'obtenerImagen64Sql()
    End Sub
    'Private Sub obtenerImagen64Sql()
    '    Dim objAlerta As New MigracionInfraestucturaBU
    '    Dim dtImagen64 As New DataTable
    '    Dim imagen As String = ""
    '    dtImagen64 = objAlerta.obtenerAlertaMigracion(1)
    '    If dtImagen64.Rows.Count > 0 Then
    '        imagen = dtImagen64.Rows(0).Item(0).ToString
    '        pbImagenAvisoImportante.SizeMode = PictureBoxSizeMode.Zoom
    '        pbImagenAvisoImportante.Image = ConvertBase64ToImage(imagen)
    '    End If
    'End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub
    'Private Function ConvertBase64ToImage(base64String As String) As Image
    '    Try
    '        ' Convierte la cadena Base64 a bytes
    '        Dim imageBytes As Byte() = Convert.FromBase64String(base64String)

    '        ' Crea un MemoryStream a partir de los bytes
    '        Using memoryStream As New MemoryStream(imageBytes)
    '            ' Crea una imagen desde el MemoryStream
    '            Dim image As Image = Image.FromStream(memoryStream)
    '            Return image
    '        End Using
    '    Catch ex As Exception
    '        Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se encontró la imagen.")
    '        Return Nothing
    '    End Try
    'End Function

End Class