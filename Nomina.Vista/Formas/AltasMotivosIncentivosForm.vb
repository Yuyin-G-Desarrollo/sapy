Imports Nomina.Negocios
Imports Tools

Public Class AltasMotivosIncentivosForm

    Dim IDUsuario As Int32 = IDUsuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

    Private Sub AltasMotivosIncentivosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbNaves = Controles.ComboNavesSegunUsuario(cmbNaves, IDUsuario)
    End Sub

    Private Sub btnGuardarMotivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarMotivo.Click
        Dim vacios As Boolean = False
        Dim pagoExtra As Boolean
        If txtNombreMotivo.Text <> "" Then
            lblNombre.ForeColor = Color.Black

        Else
            lblNombre.ForeColor = Color.Red
            vacios = True
        End If
        Dim ComboVacio As Boolean = False
        If cmbNaves.SelectedIndex > 0 Then
            lblNave.ForeColor = Color.Black
            ComboVacio = False
        Else
            lblNave.ForeColor = Color.Red
            ComboVacio = True
        End If

        Dim DescripcionVacia As Boolean = False
        If txtDescripcion.Text <> "" Then
            lblDescripcion.ForeColor = Color.Black
        Else
            lblDescripcion.ForeColor = Color.Red
            DescripcionVacia = True
        End If
        Dim MontoVacia As Boolean = False
        If txtMontoMaximo.Text <> "" Then
            lblMonto.ForeColor = Color.Black
        Else
            lblMonto.ForeColor = Color.Red
            MontoVacia = True
        End If


        If (vacios = True) Or (ComboVacio = True) Or (DescripcionVacia = True) Or (MontoVacia = True) Then
            Dim FormularioError As New AdvertenciaForm
            FormularioError.mensaje = "Faltan campos por completar"
            FormularioError.MdiParent = MdiParent
            FormularioError.ShowDialog()
        Else
            Dim Incentivos As New Entidades.Incentivos
            Incentivos.INombre = txtNombreMotivo.Text
            Incentivos.IDescripcion = txtDescripcion.Text
            Incentivos.IMontoMaximo = txtMontoMaximo.Text
            Incentivos.IActivo = rdoActivoSi.Checked

            If rdoPagoExtraSi.Checked Then
                pagoExtra = True
            Else
                pagoExtra = False
            End If

            Incentivos.IPagoDiaExtra = pagoExtra
            If cmbNaves.SelectedIndex > 0 Then
                Dim nave As New Entidades.Naves
                nave.PNaveId = CInt(cmbNaves.SelectedValue)
                Incentivos.IIncentivosNaveId = nave
            End If


            Dim objBU As New IncentivosBU
            objBU.guardarIncentivo(Incentivos)
            Dim FormularioMensaje As New ExitoForm
            FormularioMensaje.mensaje = "Registro Guardado"
            FormularioMensaje.MdiParent = MdiParent
            FormularioMensaje.ShowDialog()
            Me.Close()
        End If
    End Sub

    Private Sub btnCancelarMotivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarMotivo.Click
        Me.Close()
    End Sub

    Private Sub txtNombreMotivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreMotivo.KeyPress
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetterOrDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetterOrDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtMontoMaximo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoMaximo.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = False
        End If
    End Sub


End Class