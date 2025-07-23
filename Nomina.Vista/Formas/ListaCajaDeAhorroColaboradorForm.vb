Imports Nomina.Negocios
Imports Entidades

Public Class ListaCajaDeAhorroColaboradorForm
	Public nave As Entidades.Naves
	Public cajaAhorroId As Integer
	Public nombrecaja As String
	Public Colaboradorid As Int32
	Public PorcentajeSalario As Double
	Public mensaje As Boolean = True

	Private Sub ListaCajaDeAhorroColaboradorForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


		llenarTabla()

		lblCajaColaborador.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
		pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

		lblGuardar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
		lblBúscar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)

		lblLimpiar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
		grdCajaColaborador.BackgroundColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.grid)

		Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)

		Dim naves As New Entidades.Naves
		Dim caja As New Entidades.CajaAhorro


		lblIdCaja.Text = cajaAhorroId.ToString
		lblNaves.Text = nave.PNombre
		lblPeriodos.Text = nombrecaja

		grdCajaColaborador.EditMode = DataGridViewEditMode.EditProgrammatically

	End Sub

	Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
		pnlEncabezado.Height = 69
		grbCajaColaborador.Height = 51
		grdCajaColaborador.Height = 350
		grdCajaColaborador.Top = 135

	End Sub

	Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click

		pnlEncabezado.Height = 69
		grbCajaColaborador.Height = 136
		grdCajaColaborador.Height = 261
		grdCajaColaborador.Top = 220

	End Sub
	Public Sub llenarTabla()

		Dim listacaja As New List(Of Entidades.CajaColaborador)
		Dim objBU As New Negocios.CajaColaboradorBU

		listacaja = objBU.listaCajaColaborador(txtNombre.Text, rdoSi.Checked, cajaAhorroId)

		For Each caja As Entidades.CajaColaborador In listacaja
			AgregarFila(caja)

		Next

	End Sub
	Public Sub llenarTablaNoAsignado(ByVal LISTA As List(Of Entidades.Colaborador))


		For Each cajas As Entidades.Colaborador In LISTA
			AgregarFilas(cajas)

		Next

	End Sub


	Public Sub AgregarFila(ByVal caja As Entidades.CajaColaborador)

		Dim celda As DataGridViewCell
		Dim fila As New DataGridViewRow

		celda = New DataGridViewTextBoxCell
		celda.Value = caja.PColaborador.PColaboradorid
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = caja.PColaborador.PNombre
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = caja.PColaborador.PApaterno
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = caja.PColaborador.PAmaterno
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = caja.PDepartamento.DNombre
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = caja.PSalario.PCantidad
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = caja.PEstatus
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = caja.PMontoAcumulado
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = caja.PMontoAhorro
		fila.Cells.Add(celda)



		grdCajaColaborador.Rows.Add(fila)


	End Sub
	Public Sub AgregarFilas(ByVal cajas As Entidades.Colaborador)

		Dim celda As DataGridViewCell
		Dim fila As New DataGridViewRow

		celda = New DataGridViewTextBoxCell
		celda.Value = cajas.PColaboradorid.ToString
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = cajas.PNombre
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = cajas.PApaterno
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = cajas.PAmaterno
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = cajas.PIDepartamento.DNombre
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = 0
		fila.Cells.Add(celda)

		'celda = New DataGridViewTextBoxCell
		'celda.Value = "Nuevo"
		'fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = 0
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = 0
		fila.Cells.Add(celda)



		grdCajaColaborador.Rows.Add(fila)


	End Sub

	Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
		grdCajaColaborador.Rows.Clear()

		Dim listacaja As New List(Of Entidades.Colaborador)
		Dim listacajas As New List(Of Entidades.CajaColaborador)
		Dim objBU As New Negocios.CajaColaboradorBU


		If rdoSi.Checked Then
			' entrar a los colaboradores asignados 
			listacajas = objBU.listaCajaColaborador(txtNombre.Text, rdoSi.Checked, cajaAhorroId)
			llenarTabla()
		Else

			listacaja = objBU.listaCajaColaboradoresNoAsignados(txtNombre.Text, cajaAhorroId, nave.PNaveId)
			llenarTablaNoAsignado(listacaja)
		End If

		'
	End Sub

	Private Sub grdCajaColaborador_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCajaColaborador.CellClick
		If e.RowIndex >= 0 Then
			PorcentajeSalario = CDbl(grdCajaColaborador.Rows(e.RowIndex).Cells("ColSalario").Value) * 0.1
		End If

	End Sub

	Private Sub grdCajaColaborador_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCajaColaborador.CellContentClick

	End Sub

	Private Sub grdCajaColaborador_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCajaColaborador.CellDoubleClick
		If e.ColumnIndex = 8 Then
			'MessageBox.Show("Hola")
			grdCajaColaborador.BeginEdit(True)
		End If
	End Sub

	Private Sub grdCajaColaborador_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCajaColaborador.CellValueChanged


		If PorcentajeSalario > 0 Then

			If PorcentajeSalario < 300 Then
				If (CDbl(grdCajaColaborador.Rows(e.RowIndex).Cells("ColMontoAhorrado").Value) > PorcentajeSalario) Then

					Dim Advertencia As New AdvertenciaForm
					Advertencia.MdiParent = MdiParent
					Advertencia.mensaje = " El monto excede el limite permitido "
					Advertencia.Show()
					grdCajaColaborador.Rows(e.RowIndex).Cells("ColMontoAhorrado").Value = 0
					grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Style.BackColor = Color.Tomato
				Else

					grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Style.BackColor = Color.White
				End If
			Else
				If (CDbl(grdCajaColaborador.Rows(e.RowIndex).Cells("ColMontoAhorrado").Value) > 300) Then

					Dim Advertencia As New AdvertenciaForm
					Advertencia.MdiParent = MdiParent
					Advertencia.mensaje = "Monto debe ser menor a 300 "
					Advertencia.Show()
					grdCajaColaborador.Rows(e.RowIndex).Cells("ColMontoAhorrado").Value = 0
					grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Style.BackColor = Color.Tomato
				Else

					grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Style.BackColor = Color.White

				End If

			End If


			If e.ColumnIndex = 8 Then
				Dim cajaAhorro As Double
				For Each row As DataGridViewRow In grdCajaColaborador.Rows
					Try

						cajaAhorro = grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value
						grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = cajaAhorro

					Catch ex As Exception

					End Try

				Next
			End If

		End If





	End Sub
	Public Sub Insert(ByVal Index As Int32)

		Dim objCajaBU As New CajaColaboradorBU
		Dim caja As New Entidades.CajaColaborador
		Dim MontoAhorro, MontoAcumulado As Double
		Dim Status As String
		Dim IdColaborador As Int32

		IdColaborador = grdCajaColaborador.Rows(Index).Cells(0).Value
		MontoAhorro = grdCajaColaborador.Rows(Index).Cells(8).Value
		MontoAcumulado = grdCajaColaborador.Rows(Index).Cells(7).Value
		Status = grdCajaColaborador.Rows(Index).Cells(6).Value



		objCajaBU.Insert(IdColaborador, MontoAcumulado, MontoAhorro, Status)






	End Sub

	Private Sub GroupBox1_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox1.Enter

	End Sub

	Private Sub rdoSi_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoSi.CheckedChanged

	End Sub

	Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
		grdCajaColaborador.Rows.Clear()
		txtNombre.Text = ""
	End Sub

	Private Sub btnSaveAndClose_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAndClose.Click

		Dim cajaColaborador As New Entidades.CajaColaborador
		Dim Colaborador As New Entidades.Colaborador
		Dim CajaAhorro As New Entidades.CajaAhorro

	


		Dim objcajaBU As New Negocios.CajaColaboradorBU
		

		For fila = 0 To grdCajaColaborador.Rows.Count - 1
			Dim monto As Double
			monto = CDbl(grdCajaColaborador.Rows(fila).Cells("ColMontoAhorrado").Value)
			Dim idColaborador = CInt(grdCajaColaborador.Rows(fila).Cells("ColColaboradorId").Value)

			Colaborador.PColaboradorid = idColaborador
			cajaColaborador.Colaborador = Colaborador

			CajaAhorro.pCajaAhorroId = cajaAhorroId
			cajaColaborador.PcajaAhorro = CajaAhorro

			cajaColaborador.PMontoAhorro = monto
			cajaColaborador.PEstatus = "A"




			If monto > 0 Then
				If rdoSi.Checked Then
					objcajaBU.EditarCajas(cajaColaborador)

				Else

				End If
			End If
		Next


		If grdCajaColaborador.Rows.Count > 1 Then

			Dim mensajeExito As New ExitoForm
			mensajeExito.MdiParent = Me.MdiParent
			mensajeExito.mensaje = "Registro Guardado"
			mensajeExito.Show()

		End If

	End Sub

	Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
		Me.Close()
	End Sub

	Private Sub grdCajaColaborador_CellLeave(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCajaColaborador.CellLeave


	End Sub
End Class