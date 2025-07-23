Imports System.Data.SqlClient

Public Class ExcepcionesHorariosHorasDA
	Public Function listaHorariosHoras(ByVal horaid As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = " SELECT * FROM Nomina.HorarioExcepcionHoras where hxho_horarioexcepcionid=" + horaid.ToString
		consulta += " order by hxho_hora asc, hxho_minuto asc"
		Return operaciones.EjecutaConsulta(consulta)
	End Function

	Public Sub guardarhorarioshora(ByVal Hora As Entidades.ExcepcionesHorariosHoras)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter

		parametro.ParameterName = "Tipos"
		parametro.Value = Hora.PTipo
		listaParametros.Add(parametro)


		parametro = New SqlParameter
		parametro.ParameterName = "Hora"
		parametro.Value = Hora.PHoras
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Minutos"
		parametro.Value = Hora.PMinutos
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariocreo"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "horarioid"
		parametro.Value = Hora.PHorarioId
		listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Nomina.SP_altas_ExcepcionesHorariosHoras", listaParametros)

	End Sub
	Public Sub EliminarExcepcioneshorarioshoras(ByVal Hora As Int32)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = "delete from Nomina.HorarioExcepcionHoras where hxho_horarioexcepcionid=" + Hora.ToString

		operaciones.EjecutaConsulta(consulta)


	End Sub
	Public Function buscarHorasHorarios(ByVal horasid As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Return operaciones.EjecutaConsulta("SELECT * FROM Nomina.HorarioExcepcionHoras where hxho_horarioexcepcionhoraid =" + horasid.ToString)
	End Function
End Class
