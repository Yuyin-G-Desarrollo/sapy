Imports Tools

Public Class AltasMotivosFiniquitoForm

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        initCombos()
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
            mensajeAdvertencia.Show()
            'MsgBox("Falta completar campos")
        Else
            Dim motivo As New Entidades.MotivosFiniquito
            Dim nave As New Entidades.Naves

            motivo.PNombre = txtNombre.Text
            motivo.PActivo = rdoSi.Checked
            ''
            'If cmbNave.SelectedIndex > 0 Then
            '	motivo.PNaveId = CInt(cmbNave.SelectedValue)
            'End If
            ''
            If cmbNave.SelectedIndex > 0 Then
                nave.PNaveId = CInt(cmbNave.SelectedValue)
                motivo.PNaveId = nave
                'Accion.PModulo.PModuloid = CInt(cmbModulo.SelectedValue)
            End If
            Dim objMotivoBU As New Negocios.MotivosFiniquitoBU
            objMotivoBU.ALtasMfin(motivo)
            Me.Close()
            Dim mensajeExito As New ExitoForm
            mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "Transaccion exitosa"
            mensajeExito.Show()
            'MsgBox("Transaccion exitosa")
            Me.Close()
        End If

    End Sub
    Public Sub initCombos()
        'Dim objNavesBU As New Framework.Negocios.NavesBU
        'Dim tablaNaves As New DataTable
        'tablaNaves = objNavesBU.listaNavesActivas
        'tablaNaves.Rows.InsertAt(tablaNaves.NewRow, 0)
        'With cmbNave
        '	.DisplayMember = "nave_nombre"
        '	.ValueMember = "nave_naveid"
        '	.DataSource = tablaNaves
        'End With

        Dim nave As Int32 = 0
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNave.SelectedIndex > 0 Then
            nave = CInt(cmbNave.SelectedValue)
        End If

    End Sub


    Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub txtNombre_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
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

    Private Sub cmbNave_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
        Dim nave As Int32 = 0
        If cmbNave.SelectedIndex > 0 Then
            nave = CInt(cmbNave.SelectedValue)
        End If
    End Sub
End Class