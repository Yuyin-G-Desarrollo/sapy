Public Class ListaMotivosFiniquitoForm
	Public Naveid As Int32
	Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = 0
        Me.Top = 0
        InitCombos()
		If Naveid > 0 Then
			cmbNave.SelectedValue = Naveid
		End If
        If cmbNave.Items.Count > 2 Then

        Else
            cmbNave.SelectedIndex = 1
            Dim nave As Int32 = 0
            If cmbNave.SelectedIndex >= 0 Then
                nave = CInt(cmbNave.SelectedValue)
            End If
        End If
	End Sub

    Private Sub btnAltas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltas.Click
        Dim altasForm As New AltasMotivosFiniquitoForm

        altasForm.ShowDialog()
        grdMotivos.Rows.Clear()
        llenarTabla()
    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbMotivos.Height = 41
        grdMotivos.Height = 422
        grdMotivos.Top = 104
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        grbMotivos.Height = 129
        grdMotivos.Height = 334
        grdMotivos.Top = 196
    End Sub
    Public Sub llenarTabla()
        If cmbNave.SelectedValue > 0 Then
            Dim Nave As Int32 = 0
            If cmbNave.SelectedIndex > 0 Then
                Nave = CInt(cmbNave.SelectedValue)
            End If

            Dim listaMotivosFiniquito As New List(Of Entidades.MotivosFiniquito)
            Dim objBU As New Negocios.MotivosFiniquitoBU
            listaMotivosFiniquito = objBU.listaMotivosFiniquitos(txtNombre.Text, Nave, rdoSi.Checked)
            For Each motivo As Entidades.MotivosFiniquito In listaMotivosFiniquito
                AgregarFila(motivo)
            Next
        End If
        
    End Sub

	Public Sub AgregarFila(ByVal motivo As Entidades.MotivosFiniquito)
		Dim celda As DataGridViewCell
		Dim fila As New DataGridViewRow

		celda = New DataGridViewTextBoxCell
		celda.Value = motivo.PMotivoFiniquitoId
		fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        celda.Value = motivo.PNaveId.PNombre.ToUpper
		fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = motivo.PNombre.ToUpper
        fila.Cells.Add(celda)

        celda = New DataGridViewCheckBoxCell
		celda.Value = motivo.PActivo
		fila.Cells.Add(celda)



		grdMotivos.Rows.Add(fila)


	End Sub

	Public Sub InitCombos()
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

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If cmbNave.SelectedIndex > 0 Then
            grdMotivos.Rows.Clear()
            llenarTabla()
        End If


    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        txtNombre.Text = ""
        cmbNave.SelectedIndex = -1
        rdoSi.Checked = True
        grdMotivos.Rows.Clear()
        ' llenarTabla()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Dim IdMotivo As Int32 = 0
        For Each fila As DataGridViewRow In grdMotivos.SelectedRows
            For Each columna As DataGridViewCell In fila.Cells
                If (columna.OwningColumn.Name = "ColMFiniquitos") Then
                    IdMotivo = CInt(columna.Value)
                End If
            Next
        Next
        If IdMotivo > 0 Then
            Dim formaEditarMotivos As New EditarMotivosFiniquitoForm

            formaEditarMotivos.PidMOTIVO = IdMotivo
            formaEditarMotivos.ShowDialog()
            grdMotivos.Rows.Clear()
            llenarTabla()
        End If
        
    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub cmbNave_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbNave.KeyPress
        e.Handled = True
        If Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
        Dim nave As Int32 = 0
        If cmbNave.SelectedIndex > 0 Then
            nave = CInt(cmbNave.SelectedValue)
        End If
    End Sub

    'Private Sub btnArriba_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Panel2.Height = 35
    '    grdMotivos.Height = 269
    '    grdMotivos.Top = 124
    'End Sub

    'Private Sub btnAbajo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Panel2.Height = 148
    '    grdMotivos.Height = 160
    '    grdMotivos.Top = 235
    'End Sub
End Class