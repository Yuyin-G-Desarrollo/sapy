Imports Nomina.Datos

Public Class PatronesBU
	'
	Public Function listaPatrones(ByVal nombre As String, ByVal rfc As String, ByVal Npatronal As String, ByVal activo As Boolean) As List(Of Entidades.Patrones)
		Dim objDA As New Datos.PatronesDA
		Dim tabla As New DataTable
		listaPatrones = New List(Of Entidades.Patrones)
		tabla = objDA.listaPatrones(nombre, rfc, Npatronal, activo)
		For Each fila As DataRow In tabla.Rows
			Dim patron As New Entidades.Patrones
			patron.Ppatronid = CInt(fila("patr_patronid"))
			patron.Pnombre = CStr(fila("patr_nombre"))
			patron.Prfc = CStr(fila("patr_rfc"))
			patron.PNpatronal = CStr(fila("patr_nopatronal"))
			patron.Pcalle = CStr(fila("patr_domiciliocalle"))
			patron.PDnumero = CStr(fila("patr_domicilionumero"))
			patron.Pcolonia = CStr(fila("patr_domiciliocolonia"))
			patron.PciudadId = CInt(fila("patr_ciudadid"))
			patron.Pcp = CStr(fila("patr_cp"))
			patron.Pactivo = CBool(fila("patr_activo"))
			patron.PNombreCiudad = CStr(fila("city_nombre"))

			listaPatrones.Add(patron)
		Next
	End Function


	Public Sub guardarPatron(ByVal patron As Entidades.Patrones)
		Dim objPatronesDA As New PatronesDA
		objPatronesDA.guardarPatrones(patron)
	End Sub

	Public Sub editarPatron(ByVal patron As Entidades.Patrones)
		Dim objPatronesDA As New PatronesDA
		objPatronesDA.editarPatron(patron)
	End Sub

	Public Function buscarPatrones(ByVal patronid As Int32) As Entidades.Patrones
		Dim objPatronesDA As New Datos.PatronesDA
		Dim patron As New Entidades.Patrones
		Dim tablaPatron As New DataTable
		tablaPatron = objPatronesDA.buscarPatron(patronid)

		For Each fila As DataRow In tablaPatron.Rows

			patron.Ppatronid = CInt(fila("patr_patronid"))
			patron.Pnombre = CStr(fila("patr_nombre"))
			patron.Prfc = CStr(fila("patr_rfc"))
			patron.PNpatronal = CStr(fila("patr_nopatronal"))
			patron.Pcalle = CStr(fila("patr_domiciliocalle"))
			patron.PDnumero = CStr(fila("patr_domicilionumero"))
			patron.Pcolonia = CStr(fila("patr_domiciliocolonia"))
			patron.PciudadId = CInt(fila("patr_ciudadid"))
			patron.Pcp = CStr(fila("patr_cp"))
            patron.Pactivo = CBool(fila("patr_activo"))
            patron.Pcomisiones = CBool(fila("patr_manejaComisiones"))
            'If IsDBNull(fila("patr_porcentajecomisiones")) Then
            '    patron.PporcentajeComision = 0.0
            'Else
            '    patron.PporcentajeComision = CDbl(fila("patr_porcentajecomisiones"))
            'End If
        Next

		Return patron
	End Function

	Public Function listaPatronesActivos() As DataTable
		Dim objDA As New Datos.PatronesDA

		Return objDA.listaPatrones("", "", "", True)
	End Function

	Public Function listaPatronesCiudades(ByVal CiudadId As Integer) As DataTable
		Dim objDA As New Datos.PatronesDA

		Return objDA.listaPatrones("", "", "", True)

	End Function
End Class


