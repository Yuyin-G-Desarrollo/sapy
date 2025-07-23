Imports Tools

Public Class AltaAsuntosMuestrasForm

    Public Sub RegistrarAsunto()
        Dim EntidadAsuntoMuestra As New Entidades.AsuntosMuestras
        Dim AsuntoMuestraNegocios As New Programacion.Negocios.AsuntosMuestrasBU



        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadAsuntoMuestra.Descripcion = txtDescripcion.Text
        If (rdoActivo.Checked = True) Then
            EntidadAsuntoMuestra.Activo = True
        ElseIf (rdoInactivo.Checked = True) Then
            EntidadAsuntoMuestra.Activo = False
        End If
        AsuntoMuestraNegocios.RegistrarAsunto(EntidadAsuntoMuestra, usuario)
    End Sub

    Private Sub AltaAsuntosMuestrasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rdoActivo.Checked = True
        txtDescripcion.Text = String.Empty

    End Sub

    Public Function ValidarVacio() As Boolean
        If (txtDescripcion.Text = Nothing) Then
            lblDescripcion.ForeColor = Drawing.Color.Red
            Return False
        Else
            lblDescripcion.ForeColor = Drawing.Color.Black
            Return True
        End If
        Return True
    End Function


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (ValidarVacio() = True) Then
            If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                RegistrarAsunto()
                Dim mensaje As New ExitoForm
                mensaje.mensaje = "El registro se realizó con éxito."
                mensaje.ShowDialog()
                Me.Close()
            Else
            End If

        ElseIf (ValidarVacio() = False) Then
            Dim mensaje As New AdvertenciaForm
            mensaje.mensaje = "Los campos marcados en rojo deben ser completados."
            mensaje.ShowDialog()
        End If
    End Sub


    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 50) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space) Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = ("."))) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtDescripcion.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

End Class