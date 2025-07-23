Imports System.Net
Imports Tools

Public Class agregarImagenEstilo
    Public dtEstilosEditarImagen As DataTable
    Public codigoProducto As String
    Public foto As String
    Public Renglon As Integer
    Dim cadenaFoto As String
    Dim NombreFoto As String = ""
    Public Descripcion As String
    Dim Carpeta As String = "Programacion/Modelos/"

    Private Sub btnAbrirFile_Click(sender As Object, e As EventArgs) Handles btnAbrirFile.Click
        If ofdFoto.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim sr As New System.IO.StreamReader(ofdFoto.FileName)
            picImagenEstilo.Image = Image.FromFile(ofdFoto.FileName)
            sr.Close()
        End If
    End Sub

    Private Sub agregarImagenEstilo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROG_CAT_PROD", "PROD_EDT_IMGEST") Then 'APLICAR PERMISO PARA EDITAR LOGO
            lblSeleccionar.Visible = True
            lblGuardar.Visible = True
            lblEditar.Visible = True
            btnAbrirFile.Visible = True
            btnGuardar.Visible = True
            btnEditar.Visible = True
        Else
            lblSeleccionar.Visible = False
            lblGuardar.Visible = False
            lblEditar.Visible = False
            btnAbrirFile.Visible = False
            btnGuardar.Visible = False
            btnEditar.Visible = False
        End If
        mostrarImagen()
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objAceptarForm As New ConfirmarForm
        Dim objConfirma As New ExitoForm

        Try
            objAceptarForm.mensaje = "Está seguro de guardar los cambios."
            If objAceptarForm.ShowDialog = Windows.Forms.DialogResult.OK Then
                guardarImagenesEstilos()
                objConfirma.mensaje = "Registro exitoso"
                objConfirma.ShowDialog()
                Me.Close()
            End If
        Catch ex As Exception
            Cursor = Cursors.WaitCursor
            Throw ex
        End Try
        Cursor = Cursors.WaitCursor
    End Sub

    Public Sub guardarImagenesEstilos()
        Dim objProductos As New Programacion.Negocios.ProductosBU
        Dim obj As New Tools.TransferenciaFTP
        Dim imagenMod As Integer = 0
        Dim productoestiloId As Integer

        Cursor = Cursors.WaitCursor
        GenerarCadenaImagenes()
        If cadenaFoto <> "" Then '09/09/2020 sin imagen
            cadenaFoto = registrarImagenesFTP()
            If lblTitulo.Text = "Fotografía del Artículo" Then
                imagenMod = 1
            ElseIf lblTitulo.Text = "Logo Marca Cliente" Then
                imagenMod = 2
            End If

            For Each rowDtEs As DataRow In dtEstilosEditarImagen.Rows
                objProductos.editarImagenesEstilos(rowDtEs.Item("idEstilo").ToString, cadenaFoto, imagenMod, Renglon)
            Next

            productoestiloId = dtEstilosEditarImagen.Rows(0).Item("idEstilo")

            obj.Redimencionar(productoestiloId)
        End If

    End Sub

    Public Sub GenerarCadenaImagenes()
        If (ofdFoto.SafeFileName().ToString <> "ofdFoto") Then
            NombreFoto = ofdFoto.SafeFileName().ToUpper
            cadenaFoto = codigoProducto + "/" + ofdFoto.SafeFileName
        ElseIf (ofdFoto.SafeFileName.ToString = "ofdFoto") Then
            cadenaFoto = String.Empty
        End If
    End Sub


    Public Function registrarImagenesFTP() As String
        Dim f As String = NombreFoto
        Try
            ' Dim foto As New Tools.TransferenciaFTP("ftp://192.168.7.16", "prod\yuyinerp", "yuyinerp")
            Dim foto As New Tools.TransferenciaFTP
            If (ofdFoto.SafeFileName().ToString = "ofdFoto") Then
            ElseIf (ofdFoto.SafeFileName.ToString <> "ofdFoto") Then
                foto.EnviarArchivo("programacion/Modelos/" + codigoProducto + "/", ofdFoto.FileName)
                'foto.EnviarArchivo("programacion/Modelos/" + codigoProducto + "/", ofdFoto.FileName)
                If lblTitulo.Text = "Logo Marca Cliente" Then
                    foto.RenombraArchivo("programacion/Modelos/" + codigoProducto, ofdFoto.SafeFileName, "LOGOMARCA_" + NombreFoto)
                    f = "LOGOMARCA_" + NombreFoto
                ElseIf lblTitulo.Text = "Fotografía del Artículo" Then
                    foto.StreamFileThumbNail("programacion/Modelos/" + codigoProducto + "/", NombreFoto)
                End If
            End If

        Catch ex As Exception
            MsgBox("Sucedió algo inesperado, no se pudo subir la imagen.")
        End Try

        'Try
        '    'Dim fotoWeb As New Tools.TransferenciaFTP("ftp://50.63.89.1", "m4394882", "Asmlrl020907@") 
        '    'Dim fotoWeb As New Tools.TransferenciaFTP("ftp://65.99.252.249", "ftpsay@grupoyuyin.com", "Sayweb2020")
        '    Dim fotoWeb As New Tools.TransferenciaFTP("ftp://192.168.2.158", "ftpaccess", "Yuyin2017""")
        '    If (ofdFoto.SafeFileName().ToString = "ofdFoto") Then
        '    ElseIf (ofdFoto.SafeFileName.ToString <> "ofdFoto") Then
        '        fotoWeb.EnviarArchivo("programacion/modelos/" + codigoProducto + "/", ofdFoto.FileName)
        '        'fotoWeb.EnviarArchivo("programacion/modelos/" + codigoProducto + "/", ofdFoto.FileName)
        '        If lblTitulo.Text = "Logo Marca Cliente" Then
        '            fotoWeb.RenombraArchivo("programacion/modelos/" + codigoProducto, ofdFoto.SafeFileName, "LOGOMARCA_" + NombreFoto)
        '        ElseIf lblTitulo.Text = "Fotografía del Artículo" Then
        '            fotoWeb.StreamFileThumbNail("programacion/modelos/" + codigoProducto + "/", NombreFoto)
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox("Sucedió algo inesperado, no se pudo subir la imagen a GrupoYuyin.com.")
        'End Try
        Return codigoProducto + "/" + f
        'Try
        '    Dim fotoWeb As New Tools.TransferenciaFTP("ftp://www.grupoyuyin.com.mx/say", "yuyinerp", "Yuyin2014!")
        '    If (ofdFoto.SafeFileName().ToString = "ofdFoto") Then
        '    ElseIf (ofdFoto.SafeFileName.ToString <> "ofdFoto") Then
        '        fotoWeb.EnviarArchivo("programacion/modelos/" + codigoProducto + "/", ofdFoto.FileName)
        '        fotoWeb.EnviarArchivo("programacion/modelos/" + codigoProducto + "/", ofdFoto.FileName)
        '    End If
        'Catch ex As Exception
        '    MsgBox("Sucedió algo inesperado, no se pudo subir la imagen a GrupoYuyin.com.")
        'End Try
    End Function

    Public Sub mostrarImagen()
        If foto <> "" Then
            Try

                'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")

                Dim Carpeta As String = "Programacion/Modelos/"
                Dim objFTP As New Tools.TransferenciaFTP
                Dim StreamFoto As System.IO.Stream
                'StreamFoto = objFTP.StreamFile(Carpeta, foto)
                If (foto <> Nothing) Then
                    StreamFoto = objFTP.StreamFile(Carpeta, foto)
                    picImagenEstilo.Image = Image.FromStream(StreamFoto)
                    StreamFoto.Close()
                End If
                cadenaFoto = foto
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If btnGuardar.Enabled = False Then
            btnGuardar.Enabled = True
            btnAbrirFile.Enabled = True
        Else
            btnGuardar.Enabled = False
            btnAbrirFile.Enabled = False
        End If
    End Sub
End Class