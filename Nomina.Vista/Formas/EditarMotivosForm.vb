Imports Nomina.Negocios
Imports Tools

Public Class EditarMotivosForm
    Dim usuarioID As Int32 = usuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    Dim nombre, descripcion As String
    Dim monto, idnave, idIncentivo As Int32
    Dim pagoDiaExtra As Boolean

    Public Property Edescripcion As String
        Get
            Return descripcion
        End Get
        Set(ByVal value As String)
            descripcion = value
        End Set
    End Property

    Public Property ENombre As String
        Get
            Return nombre
        End Get
        Set(ByVal value As String)
            nombre = value
        End Set
    End Property

    Public Property EMonto As Int32
        Get
            Return monto
        End Get
        Set(ByVal value As Int32)
            monto = value
        End Set
    End Property
    Public Property EInave As Int32
        Get
            Return idnave
        End Get
        Set(ByVal value As Int32)
            idnave = value
        End Set
    End Property
    Public Property EidIncentivo As Int32
        Get
            Return idIncentivo
        End Get
        Set(ByVal value As Int32)
            idIncentivo = value
        End Set
    End Property
    'Public Property EpagoDiaExtra As Boolean
    '    Get
    '        Return pagoDiaExtra
    '    End Get
    '    Set(value As Boolean)
    '        pagoDiaExtra = value
    '    End Set
    'End Property



    Private Sub EditarMotivosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, usuarioID)
        txtNombreMotivo.Text = nombre
        txtMontoMaximo.Text = monto
        cmbNave.SelectedValue = idnave
        txtDescripcionMotivo.Text = descripcion
        'If pagoDiaExtra = True Then
        '    rdoPagoExtraSi.Checked = True
        'Else
        '    rdoPagoExtraNo.Checked = True
        'End If
    End Sub

    Private Sub btnGuardarPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarPais.Click
        Dim vacios As Boolean = False
        Dim pagoExtra As Boolean
        If txtNombreMotivo.Text <> "" Then
            lblNombre.ForeColor = Color.Black

        Else
            lblNombre.ForeColor = Color.Red
            vacios = True
        End If
        Dim ComboVacio As Boolean = False
        If cmbNave.SelectedIndex > 0 Then
            lblNave.ForeColor = Color.Black
            ComboVacio = False
        Else
            lblNave.ForeColor = Color.Red
            ComboVacio = True
        End If

        Dim DescripcionVacia As Boolean = False
        If txtDescripcionMotivo.Text <> "" Then
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
            FormularioError.Show()
        Else
            Dim Incentivos As New Entidades.Incentivos
            Incentivos.INombre = txtNombreMotivo.Text
            Incentivos.IDescripcion = txtDescripcionMotivo.Text
            Incentivos.IMontoMaximo = txtMontoMaximo.Text
            Incentivos.IActivo = rdoActivoSi.Checked
            If cmbNave.SelectedIndex > 0 Then
                Dim nave As New Entidades.Naves
                nave.PNaveId = CInt(cmbNave.SelectedValue)
                Incentivos.IIncentivosNaveId = nave
            End If

            If rdoPagoExtraSi.Checked Then
                pagoExtra = True
            Else
                pagoExtra = False
            End If
            Incentivos.IPagoDiaExtra = pagoExtra
            Incentivos.IIncentivoId = idIncentivo

            Dim objBU As New IncentivosBU
            objBU.EditarIncentivo(Incentivos)
            Dim FormularioMensaje As New ExitoForm
            FormularioMensaje.mensaje = "Registro Guardado"
            FormularioMensaje.MdiParent = MdiParent
            FormularioMensaje.Show()
            Me.Close()
        End If
    End Sub

    Private Sub btnCancelarPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarPais.Click
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

    Private Sub txtDescripcionMotivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcionMotivo.KeyPress
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