Imports Framework.Negocios

Public Class AltasCiudadesForm

    Private Sub AltasCiudadesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbPaises = Controles.ComboPaises(cmbPaises)
        txtAltaNombreCiudad.MaxLength = 50
    End Sub



    Private Sub cmbPaises_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPaises.SelectedIndexChanged
        If cmbPaises.SelectedIndex <= 0 Then
            cmbEstados = Controles.ComboEstados(cmbEstados)
        Else
            cmbEstados = Controles.ComboEstadosAnidado(cmbEstados, CInt(cmbPaises.SelectedValue))
        End If

    End Sub

    Private Sub btnGuardarPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarPais.Click
        Dim vacios As Boolean = False
        If txtAltaNombreCiudad.Text <> "" Then
            lblNombreCiudad.ForeColor = Color.Black
        Else
            lblNombreCiudad.ForeColor = Color.Red
            vacios = True
        End If




        Dim ComboVaciopaises As Boolean = False
        If cmbPaises.SelectedIndex > 0 Then
            lblPais.ForeColor = Color.Black
            ComboVaciopaises = False
        Else
            lblPais.ForeColor = Color.Red
            ComboVaciopaises = True
        End If

        Dim ComboVacioEstados As Boolean = False
        If cmbEstados.SelectedIndex > 0 Then
            lblEstado.ForeColor = Color.Black
            ComboVacioEstados = False
        Else
            lblEstado.ForeColor = Color.Red
            ComboVacioEstados = True
        End If

        If (vacios = True) Or (ComboVaciopaises = True) Or (ComboVacioEstados = True) Then


            Dim FormularioError As New ErroresForm
            FormularioError.mensaje = "Campos Vacios"
            FormularioError.Show()






        Else
            Dim Ciudad As New Entidades.Ciudades
            Ciudad.CNombre = txtAltaNombreCiudad.Text
            Ciudad.CActivo = rdoActivoSi.Checked
            Dim Estado As New Entidades.Estados
            Estado.EIDDEstado = CInt(cmbEstados.SelectedValue)
            Ciudad.CIDEstado = Estado
            Dim objCiudadBU As New CiudadesBU
            objCiudadBU.guardarCiudad(Ciudad)
            Dim FormularioMensaje As New ExitoForm
            FormularioMensaje.mensaje = "Registro Guardado"
            FormularioMensaje.ShowDialog()
            Me.Close()
        End If
    End Sub

    Private Sub txtAltaNombreCiudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAltaNombreCiudad.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnCancelarPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarPais.Click
        Me.Close()

    End Sub
End Class