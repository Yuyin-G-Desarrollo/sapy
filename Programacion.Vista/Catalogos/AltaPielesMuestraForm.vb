Imports Tools

Public Class AltaPielesMuestraForm
    Public Sub GenerarCodigo()
        Dim pielMuestraNegocios As New Programacion.Negocios.PielesMuestraBU
        Dim dtPielMuestraExistente As DataTable
        Dim dtPielMuestraId As DataTable

        dtPielMuestraExistente = New DataTable

        dtPielMuestraExistente = pielMuestraNegocios.VerCantidadFilas
        dtPielMuestraId = New DataTable

        Dim validaFilaCero As Int32 = dtPielMuestraExistente.Rows.Count


        Dim idNuevo As Int32 = 0
        Dim idMax As Int32 = 0
        If (validaFilaCero = 0) Then
            idMax = 1
            idNuevo = 1
            txtCodigo.Text = idNuevo.ToString
        Else
            dtPielMuestraId = pielMuestraNegocios.VerIdMaximoPielMuestra
            idMax = dtPielMuestraId.Rows(0)("idMax").ToString
            idNuevo = idMax + 1
            txtCodigo.Text = idNuevo.ToString

        End If
    End Sub

    Public Sub RegistrarPielMuestra()
        Dim entidadPielMuestra As New Entidades.PielesMuestra
        Dim pielMuestraNegocios As New Programacion.Negocios.PielesMuestraBU
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        entidadPielMuestra.PiMuCodigo = txtCodigo.Text
        entidadPielMuestra.PiMuDescripcion = txtDescripcion.Text
        If (rdoActivo.Checked = True) Then
            entidadPielMuestra.PiMuActivo = True
        ElseIf (rdoInactivo.Checked = True) Then
            entidadPielMuestra.PiMuActivo = False
        End If

        pielMuestraNegocios.RegistraPielMuestra(entidadPielMuestra, usuario)


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

    Private Sub AltaPielesMuestraForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdoActivo.Checked = True
        lblDescripcion.ForeColor = Drawing.Color.Black
        txtDescripcion.Text = String.Empty
        GenerarCodigo()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If (ValidarVacio() = True) Then
            If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                RegistrarPielMuestra()
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or caracter = ChrW(Keys.Space) Or (caracter = "/") Or (caracter = ("-")) Or (caracter = (".")) Then
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