Imports Nomina.Datos

Public Class ExcepcionesHorariosHorasBU


	Public Function listaExeHorariosHoras(ByVal horarioid As Int32) As List(Of Entidades.ExcepcionesHorariosHoras)
		Dim objDA As New Datos.ExcepcionesHorariosHorasDA
		Dim tabla As New DataTable
		listaExeHorariosHoras = New List(Of Entidades.ExcepcionesHorariosHoras)
		tabla = objDA.listaHorariosHoras(horarioid)
		For Each fila As DataRow In tabla.Rows
			Dim hora As New Entidades.ExcepcionesHorariosHoras
			hora.PTipo = CInt(fila("hxho_tipo"))
			hora.PHoras = CInt(fila("hxho_hora"))
			hora.PMinutos = CInt(fila("hxho_minuto"))
			hora.PHorasid = CInt(fila("hxho_horarioExcepcionhoraid"))
			hora.PHorasid = CInt(fila("hxho_horarioExcepcionid"))
			listaExeHorariosHoras.Add(hora)
		Next
	End Function
	Public Sub guardarHorariosHoras(ByVal hora As Entidades.ExcepcionesHorariosHoras)
		Dim objHora As New ExcepcionesHorariosHorasDA
		objHora.guardarhorarioshora(hora)

	End Sub
	Public Function buscarHoras(ByVal horasid As Int32) As Entidades.ExcepcionesHorariosHoras
		Dim objHorasDA As New Datos.ExcepcionesHorariosHorasDA
		Dim hora As New Entidades.ExcepcionesHorariosHoras
		Dim tablaHoras As New DataTable
		tablaHoras = objHorasDA.buscarHorasHorarios(horasid)

		For Each fila As DataRow In tablaHoras.Rows

			hora.PHorasid = CInt(fila("hxho_horarioexcepcionhoraid"))
			hora.PTipo = CInt(fila("hxho_tipo"))
			hora.PHoras = CInt(fila("hxho_hora"))
			hora.PMinutos = CInt(fila("hxho_minuto"))
		Next

		Return hora
	End Function

	Public Sub EliminarHorariosHoras(ByVal hora As Int32)
		Dim objHora As New ExcepcionesHorariosHorasDA
		objHora.EliminarExcepcioneshorarioshoras(hora)

	End Sub
	
End Class
