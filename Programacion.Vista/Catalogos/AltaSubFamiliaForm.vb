Imports Tools

Public Class AltaSubFamiliaForm

    Public Function ValidarVacio() As Boolean
        If (txtDescripcion.Text.Trim = Nothing) Then
            If (txtDescripcion.Text.Trim = Nothing) Then
                lblDescripcion.ForeColor = Drawing.Color.Red
            Else
                lblDescripcion.ForeColor = Drawing.Color.Black
            End If
            Return False
        Else
            lblDescripcion.ForeColor = Drawing.Color.Black
            Return True
        End If

        Return True
    End Function

    Public Sub Altasubfamilia()
        Dim objSub As New Programacion.Negocios.SubfamiliasBU
        Dim EnsubFamilia As New Entidades.Subfamilias
        'EnsubFamilia.PCodigo = txtCodigo.Text.Trim
        EnsubFamilia.PDescripcion = txtDescripcion.Text.Trim
        If (rdoActivo.Checked = True) Then
            EnsubFamilia.PActivo = True
        ElseIf (rdoInactivo.Checked = True) Then
            EnsubFamilia.PActivo = False
        End If
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        objSub.RegistraSubfamilia(EnsubFamilia, usuario)
        Me.Close()
        Dim mensaje As New ExitoForm
        mensaje.mensaje = "El registro se realizó con éxito."
        mensaje.ShowDialog()
        Me.Close()
    End Sub


    Public Sub IdNuevo()
        Dim IdsubfamiliaMaximo As New Programacion.Negocios.SubfamiliasBU
        Dim dtTabla As DataTable = IdsubfamiliaMaximo.idMaxSubfamilia
        Dim ValidacionExistePrimero As Int32 = dtTabla.Rows(0)(0).ToString
        Dim IdNuevo As Int32 = ValidacionExistePrimero + 1
        txtCodigo.Text = IdNuevo.ToString
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (ValidarVacio() = True) Then
            If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                Altasubfamilia()

            End If
        Else
            Dim mensaje As New AdvertenciaForm
            mensaje.mensaje = "Los campos marcados en rojo deben ser llenados."
            mensaje.ShowDialog()
        End If
    End Sub

    Private Sub AltaSubFamiliaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IdNuevo()
        txtDescripcion.Text = String.Empty
        rdoActivo.Checked = True
        lblDescripcion.ForeColor = Drawing.Color.Black
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
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
End Class