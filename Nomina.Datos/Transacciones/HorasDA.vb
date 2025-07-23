Imports Persistencia
Imports System.Data.SqlClient

Public Class HorasDA

	Public Function listaHorariosHoras(ByVal horarioid As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = " SELECT * FROM Nomina.HorariosHoras where hoho_horarioid=" + horarioid.ToString
		consulta += " order by hoho_hora asc, hoho_minuto asc"
		Return operaciones.EjecutaConsulta(consulta)
	End Function

	Public Sub guardarhorarioshoras(ByVal Hora As Entidades.Horas)

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

		operaciones.EjecutarSentenciaSP("Nomina.SP_altas_HorariosHoras", listaParametros)

	End Sub
	Public Sub Eliminarhorarioshoras(ByVal Hora As Int32)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro = New SqlParameter
		parametro.ParameterName = "horasid"
		parametro.Value = Hora
		listaParametros.Add(parametro)



		operaciones.EjecutarSentenciaSP("Nomina.SP_Eliminar_Horas", listaParametros)

	End Sub
	Public Function buscarHoras(ByVal horasid As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Return operaciones.EjecutaConsulta("SELECT * FROM Nomina.HorariosHoras where hoho_horariohoraid =" + horasid.ToString)
	End Function
	
	
End Class

