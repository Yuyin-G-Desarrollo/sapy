Imports Framework.Negocios
Imports Nomina.Negocios
Imports Tools

Public Class AltasAreasForm
    Public nave As Int32
    Public grupo As Int32

    Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
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



        If falla Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.MdiParent = Me.MdiParent
            mensajeAdvertencia.mensaje = "Faltan campos por completar"
            mensajeAdvertencia.ShowDialog()
            'MsgBox("Falta completar campos")
        Else

            Dim area As New Entidades.Areas
            Dim nave As New Entidades.Naves
            Dim departamento As New Entidades.Departamentos




            If cmbNave.SelectedIndex > 0 Then
                nave.PNaveId = CInt(cmbNave.SelectedValue)


            End If



            'If cmbDepartamento.SelectedIndex > 0 Then
            '	departamento.Ddepartamentoid = CInt(cmbDepartamento.SelectedValue)

            'End If

            area.PNombre = txtNombre.Text
            area.PActivo = btnSi.Checked




            'area.PNave.PNaveId = nave.PNaveId
            area.PNave = nave
            'area.PDepartamento = departamento
            Dim objBU As New AreasBU
            Dim mensajeNegocios As String = ""

            mensajeNegocios = objBU.guardar(area)

            If (mensajeNegocios.Length = 0) Then
                Me.Close()
                Dim mensajeExito As New ExitoForm
                mensajeExito.MdiParent = Me.MdiParent
                mensajeExito.mensaje = "Registro guardado"
                mensajeExito.ShowDialog()
            Else
                Dim mensajeAdvertencias As New AdvertenciaForm
                mensajeAdvertencias.mensaje = mensajeNegocios
                mensajeAdvertencias.ShowDialog()
            End If

        End If



    End Sub

    Private Sub AltasAreasForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InitCombos()
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblAreas.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'lblCancelar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblGuardar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)


        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)

        If nave > 0 Then
            cmbNave.SelectedValue = nave
        End If
        'If grupo > 0 Then
        '	cmbDepartamento.SelectedValue = grupo
        'End If
    End Sub
    Public Sub InitCombos()

        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)


    End Sub

    Private Sub cmbDepartamento_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
        Dim nave As Int32 = 0
        If cmbNave.SelectedIndex > 0 Then
            nave = CInt(cmbNave.SelectedValue)
        End If
        'cmbDepartamento = Tools.Controles.ComboDepatamentoSegunNave(cmbDepartamento, nave)
    End Sub

    Private Sub lblCancelar_Click(sender As System.Object, e As System.EventArgs) Handles lblCancelar.Click

    End Sub

    Private Sub lblGuardar_Click(sender As System.Object, e As System.EventArgs) Handles lblGuardar.Click

    End Sub

    Private Sub cmbNave_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbNave.KeyPress
        e.Handled = True
        If Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub cmbDepartamento_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
        If Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub txtNombre_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNombre.TextChanged

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
End Class