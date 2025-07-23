Imports Nomina.Datos

Public Class ImpuestoSubsidioEmpleoBU
	Public Function ImpuestoSubsidio() As List(Of Entidades.ImpuestoSubsidioEmpleo)
		Dim objDA As New Datos.ImpuestoSubsidioEmpleoDA
		Dim tabla As New DataTable
		ImpuestoSubsidio = New List(Of Entidades.ImpuestoSubsidioEmpleo)
		tabla = objDA.ImpuestoSubsidio()
		For Each fila As DataRow In tabla.Rows
			Dim impuesto As New Entidades.ImpuestoSubsidioEmpleo
			impuesto.PimpuestoEmpleoID = CInt(fila("rise_rangoid"))
			impuesto.PLimiteInferior = CDbl(fila("rise_limiteinferior"))
			impuesto.PLimiteSuperior = CDbl(fila("rise_limitesuperior"))
			impuesto.PPorcentaje = CDbl(fila("rise_porcentaje"))
			impuesto.PCuotaFija = CDbl(fila("rise_cuotafija"))
			ImpuestoSubsidio.Add(impuesto)
		Next
	End Function
	Public Sub Altas(ByVal Impuesto As Entidades.ImpuestoSubsidioEmpleo)
		Dim obj As New ImpuestoSubsidioEmpleoDA
		obj.AltasImpuestoSubsidio(Impuesto)
	End Sub
	Public Sub Editar(ByVal Impuesto As Entidades.ImpuestoSubsidioEmpleo)
		Dim obj As New ImpuestoSubsidioEmpleoDA
		obj.EditarImpuestoSubsidio(Impuesto)
	End Sub

	Public Sub eliminar(ByVal Impuesto As Int32)
		Dim objDA As New ImpuestoSubsidioEmpleoDA
		objDA.eliminar(Impuesto)
	End Sub
End Class
