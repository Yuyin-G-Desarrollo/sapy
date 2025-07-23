Public Class FactoresDeIntegracionForm

	Private Sub FactoresDeIntegracionForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
		grdFactoresDeIntegracion.EnableHeadersVisualStyles = False
		llenarTabla()
		
	End Sub

	Public Sub llenarTabla()

		Dim FactorIntegracion As New List(Of Entidades.FactoresDeIntegracion)
		Dim objBU As New Negocios.FactoresDeIntegracionBU
		FactorIntegracion = objBU.FactoresDeIntegracion()
		For Each factor As Entidades.FactoresDeIntegracion In FactorIntegracion
			AgregarFila(factor)
		Next
	End Sub

	Public Sub AgregarFila(ByVal factor As Entidades.FactoresDeIntegracion)

		Dim celda As DataGridViewCell
		Dim fila As New DataGridViewRow

		celda = New DataGridViewTextBoxCell
		celda.Value = factor.PFactorIntegracionId
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = factor.PAñosDeServicio
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = factor.DiasDeVacaciones
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = factor.PFactorPrimaVacacional
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = factor.PFactorAguinaldo
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = factor.PFactorIntegracion
		fila.Cells.Add(celda)


		grdFactoresDeIntegracion.Rows.Add(fila)


	End Sub

	Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
		grdFactoresDeIntegracion.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
		If MessageBox.Show("¿Esta seguro que quiere eliminar el Factor de integracion ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

			Dim FactorID As Int32 = 0

			For Each fila As DataGridViewRow In grdFactoresDeIntegracion.SelectedRows
				For Each columna As DataGridViewCell In fila.Cells
					If (columna.OwningColumn.Name = "ColId") Then
						FactorID = CInt(columna.Value)

					End If

				Next
			Next

			Dim objBU As New Negocios.FactoresDeIntegracionBU
			objBU.eliminar(FactorID)

			grdFactoresDeIntegracion.Rows.Clear()
			llenarTabla()
		Else

		End If

	End Sub

	Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click

		Dim FactorIntegracion As New Entidades.FactoresDeIntegracion
		

		Dim objFactorBU As New Negocios.FactoresDeIntegracionBU

		For fila = 0 To grdFactoresDeIntegracion.Rows.Count - 1
			Dim Años As Int32
			Años = CInt(grdFactoresDeIntegracion.Rows(fila).Cells("ColAñosDeServicio").Value)
			Dim idfactor = CInt(grdFactoresDeIntegracion.Rows(fila).Cells("ColId").Value)
			Dim DiasVacaciones = CInt(grdFactoresDeIntegracion.Rows(fila).Cells("ColDiasDeVacaciones").Value)
			Dim PrimaVacacional = CDbl(grdFactoresDeIntegracion.Rows(fila).Cells("ColFactorPrimaVacacional").Value)
			Dim Aguinaldo = CDbl(grdFactoresDeIntegracion.Rows(fila).Cells("ColFactorAguinaldo").Value)
			Dim FIntegracion = CDbl(grdFactoresDeIntegracion.Rows(fila).Cells("ColFactorDeIntegracion").Value)

			FactorIntegracion.PFactorIntegracionId = idfactor
			FactorIntegracion.AñosDeServicio = Años
			FactorIntegracion.DiasDeVacaciones = DiasVacaciones
			FactorIntegracion.FactorPrimaVacacional = PrimaVacacional
			FactorIntegracion.FactorAguinaldo = Aguinaldo
			FactorIntegracion.FactorIntegracion = FIntegracion

			If idfactor > 0 Then

				objFactorBU.Editar(FactorIntegracion)

			Else
				If FactorIntegracion.DiasDeVacaciones > 0 Then
					objFactorBU.Altas(FactorIntegracion)
				End If
			End If
		Next

		If grdFactoresDeIntegracion.Rows.Count > 1 Then

			Dim mensajeExito As New ExitoForm
			mensajeExito.MdiParent = Me.MdiParent
			mensajeExito.mensaje = "Registro Guardado"
			mensajeExito.Show()

		End If

	End Sub
	
	Private Sub grdFactoresDeIntegracion_CellEnter_1(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFactoresDeIntegracion.CellEnter
		'	Dim factor As New Entidades.FactoresDeIntegracion

		'	For i = 0 To grdFactoresDeIntegracion.Rows.Count - 1

		'		grdFactoresDeIntegracion.Rows(i).HeaderCell.Value = (i + 1).ToString
		'	Next

	End Sub

End Class