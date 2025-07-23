Imports Nomina.Datos

Public Class DeduccionRealImssBU
	Public Function DeduccionRealIms() As List(Of Entidades.DeduccionRealImss)
		Dim objDA As New Datos.DeduccionRealImssDA
		Dim tabla As New DataTable
		DeduccionRealIms = New List(Of Entidades.DeduccionRealImss)
		tabla = objDA.DeduccionRealIMSS()
		For Each fila As DataRow In tabla.Rows
			Dim IMSS As New Entidades.DeduccionRealImss
			IMSS.PDeduccionImssID = CInt(fila("drim_deduccionimssid"))
			IMSS.PLimiteInferior = CDbl(fila("drim_limiteinferior"))
			IMSS.PLimiteSuperior = CDbl(fila("drim_limitesuperior"))
			IMSS.PCantidad = CDbl(fila("drim_monto"))

			DeduccionRealIms.Add(IMSS)
		Next
	End Function
	Public Sub AltasImss(ByVal Imss As Entidades.DeduccionRealImss)
		Dim objimss As New DeduccionRealImssDA
		objimss.AltasDeduccionIMSS(Imss)
	End Sub
	Public Sub EditarImss(ByVal Imss As Entidades.DeduccionRealImss)
		Dim objimss As New DeduccionRealImssDA
		objimss.EditarDeduccionIMSS(Imss)
	End Sub

	Public Sub eliminar(ByVal imss As Int32)
		Dim objDA As New DeduccionRealImssDA
		objDA.eliminar(imss)
	End Sub
End Class
