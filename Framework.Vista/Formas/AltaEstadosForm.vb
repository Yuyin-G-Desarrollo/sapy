Imports Framework.Negocios

Public Class AltaEstadosForm

    Private Sub AltaEstadosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbPais = Controles.ComboPaises(cmbPais)
        txtAltaNombreEstado.MaxLength = 50
    End Sub

    Private Sub btnGuardarPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarPais.Click
        Dim vacios As Boolean = False
        If txtAltaNombreEstado.Text <> "" Then
            lblNombreEstadosAlta.ForeColor = Color.Black

        Else
            lblNombreEstadosAlta.ForeColor = Color.Red
            vacios = True
        End If
        Dim ComboVacio As Boolean = False
        If cmbPais.SelectedIndex > 0 Then
            lblPais.ForeColor = Color.Black
            ComboVacio = False
        Else
            lblPais.ForeColor = Color.Red
            ComboVacio = True
        End If
       
        If (vacios = True) Or (ComboVacio = True) Then
            Dim FormularioError As New ErroresForm
            FormularioError.mensaje = "Campos Vacios"
            FormularioError.Show()
        Else
            Dim Estado As New Entidades.Estados
            Estado.ENombre = txtAltaNombreEstado.Text
            Estado.EActivo = rdoActivoSi.Checked
            Dim Pais As New Entidades.Paises
            If cmbPais.SelectedIndex > 0 Then
                Pais.PIDPais = CInt(cmbPais.SelectedValue)
            End If

            Dim objEstadoBU As New EstadosBU
            objEstadoBU.guardarEstado(Estado, Pais)
            Dim FormularioMensaje As New ExitoForm
            FormularioMensaje.mensaje = "Registro Guardado"
            FormularioMensaje.ShowDialog()
            Me.Close()
        End If

    End Sub

    Private Sub txtAltaNombreEstado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAltaNombreEstado.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            txtAltaNombreEstado.SelectedText = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub btnCancelarPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarPais.Click
        Me.Close()
    End Sub

    Private Sub lblLimpiar_Click(sender As Object, e As EventArgs) Handles lblLimpiar.Click

    End Sub

    Private Sub lblBuscar_Click(sender As Object, e As EventArgs) Handles lblBuscar.Click

    End Sub

    Private Sub txtAltaNombreEstado_TextChanged(sender As Object, e As EventArgs) Handles txtAltaNombreEstado.TextChanged

    End Sub
End Class