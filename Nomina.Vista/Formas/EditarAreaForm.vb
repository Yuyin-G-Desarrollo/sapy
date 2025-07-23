Imports Nomina.Negocios
Imports Tools

Public Class EditarAreaForm
    Public areaid As Integer
    Public Property Pareaid As Integer
        Get
            Return areaid
        End Get
        Set(value As Integer)
            areaid = value
        End Set
    End Property
    Private Sub EditarAreaForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblAreas.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'lblCancelar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblGuardar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)


        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)

        initCombos()
        Dim objBU As New AreasBU

        Dim areas As New Entidades.Areas
        Dim grupo As New Entidades.Departamentos
        Dim nave As New Entidades.Naves

        areas = objBU.buscar(areaid)

        txtNombre.Text = areas.PNombre

        cmbNave.SelectedValue = areas.Nave.PNaveId

        'cmbDepartamento.SelectedValue = areas.Departamento.Ddepartamentoid




        If (areas.PActivo) Then
            btnSi.Checked = True
        Else
            btnNo.Checked = True
        End If

    End Sub
    Public Sub initCombos()
        Dim nave As Int32 = 0
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNave.SelectedIndex > 0 Then
            nave = CInt(cmbNave.SelectedValue)
        End If
        'cmbDepartamento = Tools.Controles.ComboDepatamentoSegunNave(cmbDepartamento, nave)


    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
        Dim nave As Int32 = 0
        If cmbNave.SelectedIndex > 0 Then
            nave = CInt(cmbNave.SelectedValue)
        End If
        'cmbDepartamento = Tools.Controles.ComboDepatamentoSegunNave(cmbDepartamento, nave)
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Dim falla As Boolean = False

        If txtNombre.Text <> "" Then

            lblNombre.ForeColor = Color.Black
        Else


            lblNombre.ForeColor = Color.Red
            falla = True

        End If

        If cmbNave.Text <> "" Then

            lblNave.ForeColor = Color.Black
        Else


            lblNave.ForeColor = Color.Red
            falla = True

        End If

        'If cmbDepartamento.Text <> "" Then

        '	lblDepartamento.ForeColor = Color.Black
        'Else


        '	lblDepartamento.ForeColor = Color.Red
        '	falla = True

        'End If


        If falla Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.MdiParent = Me.MdiParent

            mensajeAdvertencia.mensaje = "Faltan campos por completar"
            mensajeAdvertencia.ShowDialog()
            'MsgBox("Falta completar campos")
        Else
            Dim area As New Entidades.Areas
            Dim naves As New Entidades.Naves
            Dim grupo As New Entidades.Departamentos

            area.PNombre = txtNombre.Text
            area.PActivo = btnSi.Checked

            If cmbNave.SelectedIndex > 0 Then
                naves.PNaveId = CInt(cmbNave.SelectedValue)

                area.PNave = naves

            End If

            'If cmbDepartamento.SelectedIndex > 0 Then
            '	grupo.Ddepartamentoid = CInt(cmbDepartamento.SelectedValue)

            '	area.PDepartamento = grupo

            'End If
            area.PAreaid = areaid
            Dim objexeBU As New Negocios.AreasBU

            objexeBU.editarAreas(area)
            Me.Close()
            Dim mensajeExito As New ExitoForm
            mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "Transaccion exitosa"
            mensajeExito.ShowDialog()
            'MsgBox("Transaccion exitosa")
            Me.Close()
        End If
    End Sub

    Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub cmbNave_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbNave.KeyPress
        e.Handled = True
        If Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub cmbDepartamento_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub cmbDepartamento_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
        If Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If

        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            txtNombre.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If

    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged

    End Sub

    Private Sub pcbTitulo_Click(sender As Object, e As EventArgs) Handles pcbTitulo.Click

    End Sub
End Class