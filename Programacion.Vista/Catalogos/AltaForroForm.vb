Imports Tools

Public Class AltaForroForm

    Public Sub GenerarCodigo()
        Dim ForroNegocios As New Programacion.Negocios.ForrosBU
        Dim validaExistencia As Int32 = 0
        Dim idMaximo As Int32 = 0
        Dim idnuevo As Int32 = 0
        Dim dtValidaExistencia As DataTable
        Dim dtVerIdMaximo As DataTable
        dtValidaExistencia = New DataTable
        dtVerIdMaximo = New DataTable

        dtValidaExistencia = ForroNegocios.verFilasForros()
        validaExistencia = dtValidaExistencia.Rows.Count()

        dtVerIdMaximo = ForroNegocios.VerIdMaximoForros
        If (validaExistencia = 0) Then
            idnuevo = 1
            txtCodigo.Text = idnuevo.ToString
        Else
            idMaximo = dtVerIdMaximo.Rows(0)("idMax").ToString
            idnuevo = idMaximo + 1
            txtCodigo.Text = idnuevo.ToString
        End If
    End Sub

    Public Sub RegistrarForro()
        Dim EntidadForro As New Entidades.Forros
        Dim ForroNegocios As New Programacion.Negocios.ForrosBU
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadForro.ForroCodigo = txtCodigo.Text
        EntidadForro.ForroDescripcion = txtDescripcion.Text
        If (rdoActivo.Checked = True) Then
            EntidadForro.ForroActivo = True
        ElseIf (rdoInactivo.Checked = True) Then
            EntidadForro.ForroActivo = False
        End If
        ForroNegocios.RegistrarForro(EntidadForro, usuario)
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


    Private Sub AltaForroForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdoActivo.Checked = True
        txtDescripcion.Text = String.Empty
        GenerarCodigo()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (ValidarVacio() = True) Then
            If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                RegistrarForro()
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class