Imports Nomina.Datos

Public Class FactoresDeIntegracionBU

	Public Function FactoresDeIntegracion() As List(Of Entidades.FactoresDeIntegracion)
		Dim objDA As New Datos.FactoresDeIntegracionDA
		Dim tabla As New DataTable
		FactoresDeIntegracion = New List(Of Entidades.FactoresDeIntegracion)
		tabla = objDA.FactoresDeIntegracion()
		For Each fila As DataRow In tabla.Rows
			Dim Factor As New Entidades.FactoresDeIntegracion
			Factor.PFactorIntegracionId = CInt(fila("fact_factorid"))
			Factor.PAñosDeServicio = CInt(fila("fact_anios"))
			Factor.PDiasDeVacaciones = CInt(fila("fact_diasvacaciones"))
			Factor.PFactorPrimaVacacional = CDbl(fila("fact_factorvacacional"))
			Factor.PFactorAguinaldo = CDbl(fila("fact_aguinaldo"))
			Factor.PFactorIntegracion = CDbl(fila("fact_factorintegracion"))

			FactoresDeIntegracion.Add(Factor)
		Next
	End Function
	Public Sub Altas(ByVal factor As Entidades.FactoresDeIntegracion)
		Dim objFactorIntegracion As New FactoresDeIntegracionDA
		objFactorIntegracion.WriteFactorIntegracion(factor)
	End Sub
	Public Sub Editar(ByVal factor As Entidades.FactoresDeIntegracion)
		Dim objFactorIntegracion As New FactoresDeIntegracionDA
		objFactorIntegracion.UpdateFactorIntegracion(factor)
	End Sub

	Public Sub eliminar(ByVal factor As Int32)
		Dim objDA As New FactoresDeIntegracionDA
		objDA.eliminar(factor)
	End Sub
End Class
