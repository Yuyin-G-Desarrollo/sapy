Imports Nomina.Datos

Public Class HorasBU

	'Public Function listaHorariosActivos() As DataTable
	'	Dim objDA As New Datos.HorariosDA
	'	Return objDA.listaHorariosActivos()
	'End Function
	Public Function listaHorariosHoras(ByVal horarioid As Int32) As List(Of Entidades.Horas)
		Dim objDA As New Datos.HorasDA
		Dim tabla As New DataTable
		listaHorariosHoras = New List(Of Entidades.Horas)
		tabla = objDA.listaHorariosHoras(horarioid)
		For Each fila As DataRow In tabla.Rows
			Dim hora As New Entidades.Horas
			hora.PTipo = CInt(fila("hoho_tipo"))
			hora.PHoras = CInt(fila("hoho_hora"))
			hora.PMinutos = CInt(fila("hoho_minuto"))
			hora.PHorasid = CInt(fila("hoho_horariohoraid"))
			listaHorariosHoras.Add(hora)
		Next
	End Function
	Public Function buscarHoras(ByVal horasid As Int32) As Entidades.Horas
		Dim objHorasDA As New Datos.HorasDA
		Dim hora As New Entidades.Horas
		Dim tablaHoras As New DataTable
		tablaHoras = objHorasDA.buscarHoras(horasid)

		For Each fila As DataRow In tablaHoras.Rows
			hora.PHorasid = CInt(fila("hoho_horariohoraid"))
			hora.PTipo = CInt(fila("hoho_tipo"))
			hora.PHoras = CInt(fila("hoho_hora"))
			hora.PMinutos = CInt(fila("hoho_minuto"))
		Next

		Return hora
	End Function


	Public Sub guardarHorariosHoras(ByVal hora As Entidades.Horas)
		Dim objHora As New HorasDA
		objHora.guardarhorarioshoras(hora)

	End Sub
	Public Sub EliminarHorariosHoras(ByVal hora As Int32)
		Dim objHora As New HorasDA
		objHora.Eliminarhorarioshoras(hora)

	End Sub
	Public Function listaHorariosActivos() As DataTable
		Dim objDA As New Datos.HorasDA
		Return objDA.listaHorariosHoras(0)
	End Function

	Public Function listaHorariosDeHoras(ByVal horariosid As Integer) As DataTable
		Dim objDA As New Datos.HorasDA
		Return objDA.listaHorariosHoras(0)
	End Function
End Class
