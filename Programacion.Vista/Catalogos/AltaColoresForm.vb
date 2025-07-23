Imports Tools

Public Class AltaColoresForm

    Public Sub generarIdNuevo()
        Dim colorNegocios As New Programacion.Negocios.ColoresBU
        Dim dtValidaExistenFilas As DataTable
        Dim dtMaximoIdColor As DataTable
        Dim idMaximo As Int32 = 0
        Dim nuevoId As Int32 = 0

        dtValidaExistenFilas = New DataTable
        dtValidaExistenFilas = colorNegocios.VerFilasColores
        dtMaximoIdColor = New DataTable
        dtMaximoIdColor = colorNegocios.verIdMaximoColores
        Dim tamValidaExiste As Int32
        tamValidaExiste = dtValidaExistenFilas.Rows.Count
        If (tamValidaExiste < 1) Then
            nuevoId = 1
        ElseIf (tamValidaExiste >= 1) Then
            idMaximo = Convert.ToInt32(dtMaximoIdColor.Rows(0)(0).ToString)
            nuevoId = idMaximo + 1

        End If
        txtCodigo.Text = nuevoId.ToString

        Dim objColeBU As New Negocios.ColeccionBU
        txtCodSicy.Text = objColeBU.EncontrarColeccionSICY(2)(0)(0)
    End Sub

    Public Sub GuardarRegistro()
        Dim EntidadColor As New Entidades.Colores
        Dim ColorNegocios As New Programacion.Negocios.ColoresBU
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadColor.PColorId = txtCodigo.Text
        EntidadColor.PCDescripcion = txtDescripcion.Text
        EntidadColor.PCCodSicy = txtCodSicy.Text
        If (rdoActivo.Checked = True) Then
            EntidadColor.PCActivo = True
        ElseIf (rdoInactivo.Checked = True) Then
            EntidadColor.PCActivo = False
        End If
        ColorNegocios.registrarColor(EntidadColor, usuario)
        Me.Close()
    End Sub

    Public Function ValidaVacio() As Boolean
        If (txtDescripcion.Text = Nothing) Then
            lblDescripcion.ForeColor = Drawing.Color.Red
            Return False
        Else
            lblDescripcion.ForeColor = Drawing.Color.Black
        End If
        Return True
    End Function


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (ValidaVacio() = True) Then
            If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                GuardarRegistro()
                Dim mensaje As New ExitoForm
                mensaje.mensaje = "El registro se realizó con éxito."
                mensaje.ShowDialog()
                Me.Close()
            Else
            End If

        ElseIf (ValidaVacio() = False) Then
            Dim mensaje As New AdvertenciaForm
            mensaje.mensaje = "Los campos marcados en rojo deben ser completados."
            mensaje.ShowDialog()
        End If
    End Sub

    Private Sub AltaColoresForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdoActivo.Checked = True
        txtDescripcion.Text = String.Empty
        generarIdNuevo()
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 50) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = (".")) Then
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


    Private Sub txtCodSicy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodSicy.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtCodSicy.Text.Length < 2) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtCodSicy.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub
End Class