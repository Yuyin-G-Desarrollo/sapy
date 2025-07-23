Imports Nomina.Negocios
Imports Tools

Public Class EditarCelulasForm
    Public celulaid As Int32
    Public Property Pcelulaid As Int32
        Get
            Return celulaid
        End Get
        Set(value As Int32)
            celulaid = value

        End Set
    End Property
    Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub EditarCelulasForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        InitCombos()
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblEditarCelulas.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'lblCancelar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblGuardar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)


        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)



        Dim objcelulasBU As New CelulasBU
        Dim celula As New Entidades.Celulas

        celula = objcelulasBU.buscarcelula(celulaid)

        txtnombre.Text = celula.PNombre
        txtOrden.Text = CStr(celula.POrden)
        cmbNave.SelectedValue = celula.PDepartamento.PNave.PNaveId
        cmbDepartamento.SelectedValue = celula.PDepartamento.Ddepartamentoid

        If (celula.PActivo) Then
            btnSi.Checked = True
        Else
            btnNo.Checked = True
        End If

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
        If cmbDepartamento.Text <> "" Then

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


            celula.PCelulaid = celulaid
            celula.PNombre = txtnombre.Text

            If cmbDepartamento.SelectedIndex > 0 Then
                depto.Ddepartamentoid = CInt(cmbDepartamento.SelectedValue)
                'celula.PDepartamento.Ddepartamentoid = CInt(cmbDepartamento.SelectedValue)
            End If

            If cmbNave.SelectedIndex > 0 Then
                nave.PNaveId = CInt(cmbNave.SelectedValue)
                'celula.PDepartamento.PNave.PNaveId = CInt(cmbNave.SelectedValue)

            End If
            depto.PNave = nave
            celula.PDepartamento = depto
            celula.POrden = txtOrden.Text

            celula.PActivo = btnSi.Checked
            Me.Close()
            Dim objCelulaBU As New CelulasBU
            objCelulaBU.editarCelulas(celula)
            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "Registro guardado"
            mensajeExito.ShowDialog()

            'MsgBox("Transaccion exitosa")
        End If
    End Sub
    Public Sub InitCombos()

        'cmbDepartamento = Controles.ComboDepartamentosSegunNavesUsuario(cmbDepartamento)

        'cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        Dim nave As Int32 = 0
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNave.SelectedIndex > 0 Then
            nave = CInt(cmbNave.SelectedValue)
        End If
        cmbDepartamento = Tools.Controles.ComboDepatamentoSegunNave(cmbDepartamento, nave)


        ''combos anteriores antes del combo de utileria muestran todos los registros



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

    Private Sub cmbDepartamento_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbDepartamento.KeyPress
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
        cmbDepartamento = Tools.Controles.ComboDepatamentoSegunNave(cmbDepartamento, nave)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub txtOrden_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrden.KeyPress
        e.Handled = True
        If Char.IsNumber(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub
End Class