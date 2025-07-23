Imports Framework.Negocios
Imports Entidades



Public Class EditarPuestosForm
	Public puestoid As Integer
	Public Property Ppuestoid As Integer
		Get
			Return puestoid
		End Get
		Set(value As Integer)
			puestoid = value
		End Set
    End Property
    Public Area As String
    Public Property PArea As String
        Get
            Return Area
        End Get
        Set(value As String)
            Area = value
        End Set
    End Property
    Dim Departamento As String
    Public Property PDepartamento As String
        Get
            Return Departamento
        End Get
        Set(value As String)
            Departamento = value
        End Set
    End Property

    Public Orden As Int32
    Public Property POrden As Int32
        Get
            Return Orden
        End Get
        Set(ByVal value As Int32)
            Orden = value
        End Set
    End Property



	Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
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
			Dim mensajeAdvertencia As New AdvertenciaForm
			mensajeAdvertencia.MdiParent = Me.MdiParent
			mensajeAdvertencia.mensaje = "Faltan campos por completar"
			mensajeAdvertencia.ShowDialog()
			'MsgBox("Falta completar campos")
		Else

			Dim puesto As New Entidades.Puestos
			puesto.PNombre = txtNombreDelPuesto.Text
			puesto.PActivo = rdoSi.Checked
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

			puesto.Ppuestosid = puestoid
			Dim objPuestosBU As New puestosBU
			objPuestosBU.editarPuestos(puesto)
			Me.Close()
			Dim mensajeExito As New ExitoForm
			mensajeExito.MdiParent = Me.MdiParent
			mensajeExito.mensaje = "Transaccion exitosa"
			mensajeExito.ShowDialog()
			'MsgBox("Transaccion exitosa")
		End If
	End Sub

	Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
		Me.Close()
	End Sub

	Private Sub EditarPuestosForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        'lblEditarPuestos.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'lblCancelar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblGuardar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)


        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)

		initCombos()
		Dim objpuestosBU As New puestosBU
		Dim puesto As New Entidades.Puestos
		Dim grupo As New Entidades.Departamentos
		Dim nave As New Entidades.Naves
		
			puesto = objpuestosBU.buscarPuesto(puestoid)
			txtNombreDelPuesto.Text = puesto.PNombre
			cmbNave.SelectedValue = puesto.PNave.PNaveId
			cmbDepartamento.SelectedValue = puesto.PDepartamento.Ddepartamentoid
        txtOrden.Text = CStr(puesto.POrden)




		If (puesto.PActivo) Then
			rdoSi.Checked = True
		Else
			btnNo.Checked = True
		End If

        cmbAreas.Text = Area
        cmbDepartamento.Text = Departamento

	End Sub
	Public Sub initCombos()
		Dim nave As Int32 = 0
		cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
		If cmbNave.SelectedIndex > 0 Then
			nave = CInt(cmbNave.SelectedValue)
		End If
		cmbDepartamento = Tools.Controles.ComboDepatamentoSegunNave(cmbDepartamento, nave)

		'Dim objNaveBU As New NavesBU
		'Dim tablaNaves As New DataTable
		'tablaNaves = objNaveBU.listaNavesActivas()
		'tablaNaves.Rows.InsertAt(tablaNaves.NewRow, 0)
		'With cmbNave
		'	.DataSource = tablaNaves
		'	.DisplayMember = "nave_nombre"
		'	.ValueMember = "nave_naveid"
		'End With
	End Sub

	Private Sub cmbNave_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
		Dim nave As Int32 = 0
		If cmbNave.SelectedIndex > 0 Then
			nave = CInt(cmbNave.SelectedValue)
        End If

        If cmbNave.SelectedIndex > 0 Then
            nave = CInt(cmbNave.SelectedValue)
        End If
        cmbAreas = Tools.Controles.ComboAreaSegunNave(cmbAreas, nave)
		cmbDepartamento = Tools.Controles.ComboDepatamentoSegunNave(cmbDepartamento, nave)
    End Sub

    Private Sub txtNombreDelPuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreDelPuesto.KeyPress
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            txtNombreDelPuesto.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub txtNombreDelPuesto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombreDelPuesto.TextChanged
      
    End Sub

    Private Sub cmbAreas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAreas.SelectedIndexChanged
        Try
            Dim Area As Int32 = 0

            If cmbAreas.SelectedIndex > 0 Then
                Area = CInt(cmbAreas.SelectedValue)

            End If

            cmbDepartamento = Controles.ComboDepatamentoSegunArea(cmbDepartamento, Area)
            

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartamento.SelectedIndexChanged

    End Sub

    Private Sub txtOrden_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrden.KeyPress
        e.Handled = True
        If Char.IsNumber(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub
End Class