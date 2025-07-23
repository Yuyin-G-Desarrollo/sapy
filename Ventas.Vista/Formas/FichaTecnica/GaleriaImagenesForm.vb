Imports Tools

Public Class GaleriaImagenesForm

    Public id_carpeta As Integer
    Public RutaArchivo As String
    Public NombreArchivo As String
    Public MostrarCarrusel As Boolean
    Public AtnClientes As Integer
    Dim imgCarruselMiniatura As Infragistics.Win.UltraWinEditors.UltraPictureBox



    Private Sub GaleriaImagenesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mostrar_pnlGaleriaCarrusel(MostrarCarrusel)

    End Sub

    Private Sub mostrar_pnlGaleriaCarrusel(mostrarCarrusel As Boolean)

        If mostrarCarrusel Then
            pnlGaleriaCarrusel.Visible = True
            pnlBotonesGaleria.Visible = True
            If Not Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = AtnClientes Then
                If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
                    btnAgregarImagenes.Enabled = False
                    btnEliminarImagen.Enabled = False
                Else
                    btnAgregarImagenes.Enabled = True
                    btnEliminarImagen.Enabled = True
                End If
            End If
            cargar_carruselMiniaturas()
        Else
            pnlGaleriaCarrusel.Visible = False
            pnlBotonesGaleria.Visible = False
            cargar_imgGaleriaImagen()
        End If

    End Sub

    Private Sub cargar_imgGaleriaImagen()

        Dim objFTP As New Tools.TransferenciaFTP
        Try
            Dim Stream As System.IO.Stream
            Stream = objFTP.StreamFile(RutaArchivo, NombreArchivo)
            imgGaleria.Image = Image.FromStream(Stream)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cargar_carruselMiniaturas()

        imgGaleria.Image = Nothing
        pnlGaleriaCarruselMiniaturas.Controls.Clear()
        pnlGaleriaCarruselMiniaturas.Refresh()

        Dim objFTP As New Tools.TransferenciaFTP
        Try

            Dim listaArchivos As New List(Of String)
            listaArchivos = objFTP.ListarArchivos(RutaArchivo)

            Dim i, x As Integer

            For Each archivo As String In listaArchivos
                Dim Stream As System.IO.Stream
                Stream = objFTP.StreamFile(RutaArchivo, archivo)

                Dim imgCarruselMiniatura As New Infragistics.Win.UltraWinEditors.UltraPictureBox()

                With imgCarruselMiniatura
                    .Name = archivo
                    .Location = New System.Drawing.Point(x, 0)
                    .Visible = True
                    .Image = Image.FromStream(Stream)
                    .Size = New System.Drawing.Size(90, 90)
                    .BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
                    .BackColor = Color.Black
                    .BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4Thick
                    .TabIndex = i
                End With

                AddHandler imgCarruselMiniatura.Click, AddressOf imgCarruselMiniatura_Click


                pnlGaleriaCarruselMiniaturas.Controls.Add(imgCarruselMiniatura)

                i += 1
                x += 93

            Next

        Catch

        End Try

    End Sub

    Private Sub imgCarruselMiniatura_Click(sender As Object, e As EventArgs)

        If Not imgCarruselMiniatura Is Nothing Then
            imgCarruselMiniatura.DrawBorderShadow = False
        End If

        imgCarruselMiniatura = sender

        imgCarruselMiniatura.DrawBorderShadow = True
        imgCarruselMiniatura.BorderShadowColor = Color.LightGray

        imgGaleria.Image = imgCarruselMiniatura.Image
        Me.Text = imgCarruselMiniatura.Name

    End Sub

    Private Sub btnAgregarImagenes_Click(sender As Object, e As EventArgs) Handles btnAgregarImagenes.Click

        Dim objBU As New Negocios.ClientesBU
        Dim ofdGaleria As New OpenFileDialog
        ofdGaleria.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        ofdGaleria.Filter = "JPEG|*.jpg"
        ofdGaleria.Multiselect = True
        ofdGaleria.FilterIndex = 3
        ofdGaleria.ShowDialog()

        For Each archivo As String In ofdGaleria.FileNames

            Dim RutaArchivo As String = "Ventas/FTC/Cliente_" + id_carpeta.ToString + "/MKT"
            Dim objFTP As New Tools.TransferenciaFTP

            objFTP.EnviarArchivo(RutaArchivo, archivo)

        Next

        cargar_carruselMiniaturas()

    End Sub

    Private Sub btnEliminarImagen_Click(sender As Object, e As EventArgs) Handles btnEliminarImagen.Click

        Dim mensajeExito As New ConfirmarForm
        mensajeExito.mensaje = "¿ Está seguro de eliminar esta imagen ? "

        If mensajeExito.ShowDialog = DialogResult.OK Then

            If imgCarruselMiniatura Is Nothing Then Return
            Dim RutaArchivo As String = "Ventas/FTC/Cliente_" + id_carpeta.ToString + "/MKT"
            Dim objFTP As New Tools.TransferenciaFTP

            objFTP.BorraArchivo(RutaArchivo, imgCarruselMiniatura.Name)

            cargar_carruselMiniaturas()

        End If

    End Sub

End Class