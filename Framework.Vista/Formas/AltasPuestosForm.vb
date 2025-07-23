Imports Framework.Negocios
Imports Entidades

Public Class AltasPuestosForm

    Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs)
        Dim falla As Boolean = False
        If txtNombreDelPuesto.Text <> "" Then

            lblNombreDelPuesto.ForeColor = Color.Black
        Else


            lblNombreDelPuesto.ForeColor = Color.Red
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
            'MsgBox("Falta completar campos")
            Dim mensajeAdvertencia As New AdvertenciaForm

            mensajeAdvertencia.mensaje = "Faltan campos por completar"
            mensajeAdvertencia.ShowDialog()
            Me.btnGuardar.DialogResult = Windows.Forms.DialogResult.Ignore
        Else
            Dim puesto As New Entidades.Puestos
            puesto.PNombre = txtNombreDelPuesto.Text
            puesto.PActivo = btnSi.Checked
            If cmbNave.SelectedIndex > 0 Then
                Dim nave As New Naves
                nave.PNaveId = CInt(cmbNave.SelectedValue)
                puesto.PNave = nave
            End If

            If cmbDepartamento.SelectedIndex > 0 Then
                Dim Departamento As New Departamentos
                Departamento.Ddepartamentoid = CInt(cmbDepartamento.SelectedValue)
                puesto.PDepartamento = Departamento
            End If

            Dim objPuestosBU As New puestosBU
            objPuestosBU.guardarpuesto(puesto)
            'Me.Close()
            Dim mensajeExito As New ExitoForm
            'mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "Registro guardado"
            mensajeExito.ShowDialog()
            'MsgBox("Transaccion exitosa")
            'Me.Close()
        End If

    End Sub

    Private Sub AltasPuestosForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblAltasPuestos.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'lblCancelar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblGuardar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)


        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)

        initCombos()
    End Sub
    Public Sub initCombos()
        Dim nave As Int32 = 0
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNave.SelectedIndex > 0 Then
            nave = CInt(cmbNave.SelectedValue)
        End If
        cmbDepartamento = Tools.Controles.ComboDepatamentoSegunNave(cmbDepartamento, nave)

        'Dim objnaveBU As New NavesBU
        'Dim tablaNAVES As New DataTable
        'tablaNAVES = objnaveBU.listaNavesActivas()
        'tablaNAVES.Rows.InsertAt(tablaNAVES.NewRow, 0)
        'With cmbNave
        '	.DataSource = tablaNAVES
        '	.DisplayMember = "nave_nombre"
        '	.ValueMember = "nave_naveid"
        'End With
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Dim nave As Int32 = 0
        If cmbNave.SelectedIndex > 0 Then
            nave = CInt(cmbNave.SelectedValue)
        End If
        cmbAreas = Tools.Controles.ComboAreaSegunNave(cmbAreas, nave)
    End Sub

    Private Sub txtNombreDelPuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            txtNombreDelPuesto.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub txtNombreDelPuesto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmbAreas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmbNave_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        Dim nave As Int32 = 0
        If cmbNave.SelectedIndex > 0 Then
            nave = CInt(cmbNave.SelectedValue)
        End If
        cmbAreas = Tools.Controles.ComboAreaSegunNave(cmbAreas, nave)
    End Sub

    Private Sub cmbAreas_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbAreas.SelectedIndexChanged
        Dim Departamento As New Int32
        If cmbAreas.SelectedIndex > 0 Then
            Departamento = CInt(cmbAreas.SelectedValue)

        End If
        Try
            cmbDepartamento = Tools.Controles.ComboDepartamentosSegunArea(cmbDepartamento, Departamento)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click_1(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim falla As Boolean = False
        If txtNombreDelPuesto.Text <> "" Then

            lblNombreDelPuesto.ForeColor = Color.Black
        Else


            lblNombreDelPuesto.ForeColor = Color.Red
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

        If txtOrden.Text <> "" Then
            lblOrden.ForeColor = Color.Black
        Else
            lblOrden.ForeColor = Color.Red
            falla = True
        End If


        If falla Then
            'MsgBox("Falta completar campos")
            Dim mensajeAdvertencia As New AdvertenciaForm

            mensajeAdvertencia.mensaje = "Faltan campos por completar"
            mensajeAdvertencia.ShowDialog()
            Me.btnGuardar.DialogResult = Windows.Forms.DialogResult.Ignore
        Else
            Dim puesto As New Entidades.Puestos
            puesto.PNombre = txtNombreDelPuesto.Text
            puesto.PActivo = btnSi.Checked
            If cmbNave.SelectedIndex > 0 Then
                Dim nave As New Naves
                nave.PNaveId = CInt(cmbNave.SelectedValue)
                puesto.PNave = nave
            End If

            If cmbDepartamento.SelectedIndex > 0 Then
                Dim Departamento As New Departamentos
                Departamento.Ddepartamentoid = CInt(cmbDepartamento.SelectedValue)
                puesto.PDepartamento = Departamento
            End If
            puesto.POrden = CInt(txtOrden.Text)

            Dim objPuestosBU As New puestosBU
            objPuestosBU.guardarpuesto(puesto)
            'Me.Close()
            Dim mensajeExito As New ExitoForm
            'mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "Registro guardado"
            mensajeExito.ShowDialog()
            'MsgBox("Transaccion exitosa")
            'Me.Close()
        End If
    End Sub

    Private Sub btnCncelar_Click_1(sender As Object, e As EventArgs) Handles btnCncelar.Click
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