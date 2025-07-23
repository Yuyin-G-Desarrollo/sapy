Imports Nomina.Datos

Public Class ExcepcionesHorariosBU


	Public Function ListaExcepcionesHorarios(ByVal Nombre As String, ByVal activo As Boolean, ByVal Horario As Int32, ByVal Fecha As Date, ByVal fechaseleccionada As Boolean) As List(Of Entidades.ExcepcionesHorarios)
		Dim objDA As New Datos.ExcepcionesHorariosDA
		Dim tabla As New DataTable
		ListaExcepcionesHorarios = New List(Of Entidades.ExcepcionesHorarios)
		tabla = objDA.ListaExcepcionesHorarios(Nombre, activo, Horario, Fecha.ToString("yyyy-MM-dd"), fechaseleccionada)
		For Each fila As DataRow In tabla.Rows
			Dim exe As New Entidades.ExcepcionesHorarios
			exe.PExcepcionesHorarioID = CInt(fila("hexc_Horarioexcepcionid"))
			exe.Pnombre = CStr(fila("hexc_nombre"))
			exe.PTipo = CInt(fila("hexc_tipo"))
			exe.PActivo = CBool(fila("hexc_activo"))
			exe.PFecha = CDate(fila("hexc_Fecha"))


			Dim horarios As New Entidades.Horarios

			horarios.DHorariosid = CInt(fila("hora_horarioid"))
			horarios.DNombre = CStr(fila("hora_nombre"))


			exe.PHorario = horarios


			ListaExcepcionesHorarios.Add(exe)

		Next
	End Function
	Public Function BuscarHexc(ByVal idHexc As Int32) As Entidades.ExcepcionesHorarios
		

			Dim objDA As New Datos.ExcepcionesHorariosDA
		Dim exe As New Entidades.ExcepcionesHorarios
			Dim tabla As New DataTable
		tabla = objDA.buscarExcepciones(idHexc)
			For Each fila As DataRow In tabla.Rows

			exe.PExcepcionesHorarioID = CInt(fila("hexc_Horarioexcepcionid"))
			exe.Pnombre = CStr(fila("hexc_nombre"))
			exe.PTipo = CInt(fila("hexc_tipo"))
			exe.PActivo = CBool(fila("hexc_activo"))
			exe.PFecha = CDate(fila("hexc_Fecha"))


			Dim horarios As New Entidades.Horarios

			horarios.DHorariosid = CInt(fila("hora_horarioid"))
			horarios.DNombre = CStr(fila("hora_nombre"))


			exe.PHorario = horarios

				
			Next

		Return exe
	End Function
	Public Sub ALtashexc(ByVal excepciones As Entidades.ExcepcionesHorarios)
		Dim objexeDA As New ExcepcionesHorariosDA
		objexeDA.altasExe(excepciones)
	End Sub
	Public Sub EditarHexc(ByVal excepcion As Entidades.ExcepcionesHorarios)

		Dim objexeDA As New ExcepcionesHorariosDA
		objexeDA.editarHEXC(excepcion)
	End Sub
	Public Function listaHorariosExcepcionesActivos() As DataTable
		Dim objDA As New Datos.ExcepcionesHorariosDA
		Return objDA.listaHorariosActivos()
	End Function
End Class
