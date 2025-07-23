Imports Nomina.Datos

Public Class RangoSubsidioEmpleoBU
	Public Function SubsidioEmpleo() As List(Of Entidades.RangoSubsidioEmpleo)
		Dim objDA As New Datos.RangoSubsidioEmpleoDA
		Dim tabla As New DataTable
		SubsidioEmpleo = New List(Of Entidades.RangoSubsidioEmpleo)
		tabla = objDA.SubsidioEmpleo()
		For Each fila As DataRow In tabla.Rows
			Dim Subsidio As New Entidades.RangoSubsidioEmpleo
			Subsidio.PSubsidioID = CInt(fila("rase_subsidioid"))
			Subsidio.PLimiteInferior = CDbl(fila("rase_limiteinferior"))
			Subsidio.PLimiteSuperior = CDbl(fila("rase_limitesuperior"))
			Subsidio.PValor = CDbl(fila("rase_valor"))

			SubsidioEmpleo.Add(Subsidio)
		Next
	End Function
	Public Sub Alta(ByVal SubsidioEmpleo As Entidades.RangoSubsidioEmpleo)
		Dim objDA As New RangoSubsidioEmpleoDA
		objDA.Insert(SubsidioEmpleo)
	End Sub
	Public Sub Editar(ByVal Subsidios As Entidades.RangoSubsidioEmpleo)
		Dim objDA As New RangoSubsidioEmpleoDA
		objDA.Update(Subsidios)
	End Sub

	Public Sub Eliminar(ByVal Subsidio As Int32)
		Dim objDA As New RangoSubsidioEmpleoDA
		objDA.Delete(Subsidio)
	End Sub
End Class
