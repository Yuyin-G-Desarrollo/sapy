Imports Framework.Negocios

Public Class AltasPaisesForm

    Private Sub btnGuardarPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarPais.Click

        Dim vacios As Boolean = False
        If txtAltaNombrePais.Text <> "" Then
            lblNombrePaisAlta.ForeColor = Color.Black
        Else
            lblNombrePaisAlta.ForeColor = Color.Red
            vacios = True
        End If

        If vacios Then
            Dim FormularioError As New ErroresForm
            FormularioError.mensaje = "Campos Vacios"
        Else
            Dim Pais As New Entidades.Paises
            Pais.PNombre = txtAltaNombrePais.Text
            Pais.PActivo = rdoActivoSi.Checked

            Dim objPaisBU As New PaisesBU
            objPaisBU.guardarPais(Pais)
            Dim FormularioMensaje As New ExitoForm
            FormularioMensaje.mensaje = "Registro Guardado"
            FormularioMensaje.ShowDialog()
        End If


    End Sub

    Private Sub AltasPaisesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdoActivoSi.Checked = True
        txtAltaNombrePais.MaxLength = 50
    End Sub

    Private Sub btnCancelarPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarPais.Click
        Me.Close()
    End Sub

   
    Private Sub txtAltaNombrePais_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAltaNombrePais.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            txtAltaNombrePais.SelectedText = Char.ToUpper(e.KeyChar)
        End If
    End Sub


    Private Sub lblLimpiar_Click(sender As Object, e As EventArgs) Handles lblLimpiar.Click

    End Sub
    Private Sub lblBuscar_Click(sender As Object, e As EventArgs) Handles lblBuscar.Click

    End Sub

    Private Sub txtAltaNombrePais_TextChanged(sender As Object, e As EventArgs) Handles txtAltaNombrePais.TextChanged

    End Sub
End Class