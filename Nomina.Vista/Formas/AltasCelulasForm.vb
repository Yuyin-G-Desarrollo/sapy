Imports Nomina.Negocios
Imports Tools

Public Class AltasCelulasForm

    Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Dim falla As Boolean = False
        If txtnombre.Text <> "" Then

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
        If cmbDepartamentos.Text <> "" Then

            lblDepartamento.ForeColor = Color.Black
        Else


            lblDepartamento.ForeColor = Color.Red
            falla = True

        End If

        If falla Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Faltan campos por completar"
            mensajeAdvertencia.ShowDialog()
            'MsgBox("Falta completar campos")
        Else

            Dim celula As New Entidades.Celulas
            Dim depto As New Entidades.Departamentos
            Dim nave As New Entidades.Naves



            celula.PNombre = txtnombre.Text
            If cmbNave.SelectedIndex > 0 Then
                nave.PNaveId = CInt(cmbNave.SelectedValue)

                'celula.PDepartamento.PNave.PNaveId = CInt(cmbNave.SelectedValue)

            End If

            If cmbDepartamentos.SelectedIndex > 0 Then
                depto.Ddepartamentoid = CInt(cmbDepartamentos.SelectedValue)
                'celula.PDepartamento.Ddepartamentoid = CInt(cmbDepartamentos.SelectedValue)

            End If
            depto.PNave = nave
            celula.PDepartamento = depto
            celula.POrden = txtOrden.Text

            celula.PActivo = btnSi.Checked
            Me.Close()

            Dim objcelulasBU As New CelulasBU
            objcelulasBU.altasCelulas(celula)
            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "Registro guardado"
            mensajeExito.ShowDialog()

            'MsgBox("Transaccion exitosa")
            'Me.Close()
        End If
    End Sub
    Public Sub InitCombos()




        'cmbDepartamentos = Controles.ComboDepartamentosSegunNavesUsuario(cmbDepartamentos)

        'cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        Dim nave As Int32 = 0
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNave.SelectedIndex > 0 Then
            nave = CInt(cmbNave.SelectedValue)
        End If
        cmbDepartamentos = Tools.Controles.ComboDepatamentoSegunNave(cmbDepartamentos, nave)

    End Sub

    Private Sub AltasCelulasForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InitCombos()
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblAltasCelulas.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'lblCancelar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblGuardar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)


        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)


    End Sub

    Private Sub txtnombre_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtnombre.KeyPress

        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub cmbNave_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbNave.KeyPress
        e.Handled = True


        If Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub cmbDepartamentos_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbDepartamentos.KeyPress
        e.Handled = True


        If Char.IsControl(e.KeyChar) Then


            e.Handled = False

        End If
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
        Dim nave As Int32 = 0
        If cmbNave.SelectedIndex > 0 Then
            nave = CInt(cmbNave.SelectedValue)
        End If
        cmbDepartamentos = Tools.Controles.ComboDepatamentoSegunNave(cmbDepartamentos, nave)
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub


    Private Sub txtOrden_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrden.KeyPress
        e.Handled = True
        If Char.IsNumber(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub
End Class