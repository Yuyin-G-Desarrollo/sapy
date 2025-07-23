
Imports Produccion.Negocios
Imports Tools

Public Class AdministradorArchivos_GuardarCategoria_Departamento
    Public vEsDepto As Boolean = True
    Public VentanaAltaArchivos As AltaDocumentosProduccion_Form

    Private Sub AdministradorArchivos_GuardarCategoria_Departamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If vEsDepto = True Then
            lblCategoria.Visible = False
            lblDepto.Visible = True
            lblTituloCate.Visible = False
            lblTituloDepto.Visible = True
            txtImagen.Visible = True
            btnSelectorImagen.Visible = True
            lblImagen.Visible = True
            Me.Text = "Nuevo Departamento"
        Else
            lblCategoria.Visible = True
            lblDepto.Visible = False
            lblTituloCate.Visible = True
            lblTituloDepto.Visible = False
            Me.Text = "Nueva Categoría"
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim obj As New AdministradorArchivosBU
        Dim obA As New TransferenciaFTP

        If txtNombre.Text <> "" Then
            Try
                Dim NombreTipo() As String = txtImagen.Text.Split("\")
                Dim n As Integer = NombreTipo.Count - 1

                obA.EnviarArchivo("Produccion/IconosDepartamentos", txtImagen.Text)

                obj.GuardarCategoriasDeptos(txtNombre.Text, vEsDepto, NombreTipo(n))

                Dim FormularioMensaje As New ExitoForm
                FormularioMensaje.mensaje = "Registro Guardado"
                FormularioMensaje.ShowDialog()

            Catch ex As Exception
                Dim FormaError As New ErroresForm
                FormaError.mensaje = "Error"
                FormaError.ShowDialog()
            End Try
            Me.Close()
        Else
            Dim FormaError As New ErroresForm
            FormaError.mensaje = "Campos vacios"
            FormaError.ShowDialog()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub AdministradorArchivos_GuardarCategoria_Departamento_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        'VentanaAltaArchivos.Dispose()
        'VentanaAltaArchivos.Show()
        VentanaAltaArchivos.btnMostrar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnSelectorImagen_Click(sender As Object, e As EventArgs) Handles btnSelectorImagen.Click
        Dim ruta As String = String.Empty
        Dim open As New OpenFileDialog
        Dim OBJBU As New AdministradorArchivosBU
        With open
            .ShowDialog()
        End With
        If open.FileName.Trim.Length > 0 Then
        Else
            Exit Sub
        End If
        If OBJBU.ArchivoEnUso(open.FileName) Then
            MessageBox.Show("El archivo está en uso, debe cerrarlo para poder agregarlo a la base de datos.",
                            "Precaución", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        txtImagen.Text = open.FileName
    End Sub
End Class