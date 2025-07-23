Imports Nomina.Negocios

Public Class EditarMotivosPrestamosForm
	Public idMOTIVO As Int32
	Public Property PidMOTIVO As Int32
		Get
			Return idMOTIVO
		End Get
		Set(value As Int32)
			idMOTIVO = value
		End Set
	End Property

	Private Sub EditarMotivosPrestamosForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
		initCombos()
		Dim objMotivoBU As New MotivosPrestamoBU
		Dim MOTIVO As New Entidades.MotivosPrestamo
		Dim Naves As New Entidades.Naves
		MOTIVO = objMotivoBU.BuscarMotivos(idMOTIVO)

		txtNombre.Text = MOTIVO.PNombre



		'Modulos.PModuloid = CInt(cmbModulo.SelectedValue)
		cmbNave.SelectedValue = MOTIVO.PNaveId.PNaveId
		MOTIVO.PNaveId.PNaveId = Naves.PNaveId


		If (MOTIVO.PActivo) Then
			rdoSi.Checked = True
		Else
			rdoNo.Checked = True
		End If
	End Sub

	Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
		Me.Close()
	End Sub

	Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
		Dim falla As Boolean = False
		If txtNombre.Text <> "" Then

			lblNombreBanco.ForeColor = Color.Black
		Else


			lblNombreBanco.ForeColor = Color.Red
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

			'TOdo OK para editar
			Dim Motivo As New Entidades.MotivosPrestamo
			Dim Nave As New Entidades.Naves
			Motivo.PNombre = txtNombre.Text
			Motivo.PActivo = rdoSi.Checked
			''
			'If cmbNave.SelectedIndex > 0 Then
			'	Motivo.PNaveId = CInt(cmbNave.SelectedValue)
			'End If
			''
			If cmbNave.SelectedIndex > 0 Then
				Nave.PNaveId = CInt(cmbNave.SelectedValue)
				Motivo.PNaveId = Nave
			End If
			Motivo.PMotivoPrestamoId = idMOTIVO
			Dim objMotivosBU As New MotivosPrestamoBU
			objMotivosBU.editarmoivos(Motivo)
			Me.Close()

			Dim mensajeExito As New ExitoForm
			mensajeExito.MdiParent = Me.MdiParent
			mensajeExito.mensaje = "Transaccion exitosa"
			mensajeExito.Show()
			'MsgBox("Transaccion exitosa")
			End If
	End Sub


	Public Sub initCombos()
		Dim objNavesBU As New Framework.Negocios.NavesBU
		Dim tablaNaves As New DataTable
		tablaNaves = objNavesBU.listaNavesActivas
		tablaNaves.Rows.InsertAt(tablaNaves.NewRow, 0)
		With cmbNave
			.DisplayMember = "nave_nombre"
			.ValueMember = "nave_naveid"
			.DataSource = tablaNaves
		End With
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
End Class