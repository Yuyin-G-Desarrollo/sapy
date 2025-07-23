Imports Framework.Negocios
Public Class EditarEstadoForm

    Public estadoid, paisseleccion As Integer
    Public Property DPais As Integer
        Get
            Return estadoid
        End Get
        Set(ByVal value As Integer)
            estadoid = value
        End Set
    End Property

    Public Property DPaisSeleccion As Integer
        Get
            Return paisseleccion
        End Get
        Set(ByVal value As Integer)
            paisseleccion = value
        End Set
    End Property

    Public Sub EditarEstadoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objPaisBU As New EstadosBU
        Dim estado As New Entidades.Estados
        txtEditarNombreEstado.MaxLength = 50
        estado = objPaisBU.buscarEstado(estadoid)

        txtEditarNombreEstado.Text = estado.ENombre

        If (estado.EActivo) Then
            rdoActivoSi.Checked = True
        Else
            rdoActivoNo.Checked = True
        End If
        cmbPais = Controles.ComboPaises(cmbPais)
        cmbPais.SelectedValue = paisseleccion
        txtEditarNombreEstado.MaxLength = 50
    End Sub



    Private Sub btnGuardarEdicionPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarEdicionPais.Click
        Dim vacios As Boolean = False
        If txtEditarNombreEstado.Text <> "" Then
            lblActivoPaisAlta.ForeColor = Color.Black

        Else
            lblEditarNombreEstado.ForeColor = Color.Red
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
            Estado.ENombre = txtEditarNombreEstado.Text
            Estado.EActivo = rdoActivoSi.Checked
            Estado.EIDDEstado = estadoid
            Dim Pais As New Entidades.Paises
            If cmbPais.SelectedIndex > 0 Then
                Pais.PIDPais = CInt(cmbPais.SelectedValue)
            End If

            Dim objEstadoBU As New EstadosBU
            objEstadoBU.editarRegistro(Estado, Pais)
            Dim FormularioMensaje As New ExitoForm
            FormularioMensaje.mensaje = "Registro Modificado"
            FormularioMensaje.ShowDialog()
            Me.Close()
        End If

    End Sub

    Private Sub txtEditarNombreEstado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEditarNombreEstado.KeyPress
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

    Private Sub btnCancelarEdicionPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarEdicionPais.Click
        Me.Close()
    End Sub

    Private Sub lblBuscar_Click(sender As Object, e As EventArgs) Handles lblBuscar.Click

    End Sub
End Class