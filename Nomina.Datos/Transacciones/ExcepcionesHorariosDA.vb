Imports System.Data.SqlClient

Public Class ExcepcionesHorariosDA
	Public Function ListaExcepcionesHorarios(ByVal Nombre As String, ByVal Activo As Boolean, ByVal Horario As Int32, ByVal Fecha As String, fechaSeleccionada As Boolean) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = ("select * from Nomina.HorariosExcepciones as a join Nomina.Horarios as b on (a.hexc_horarioid=b.hora_horarioid)")
		consulta += "And hexc_nombre like '%" + Nombre + "%'"
		If (Horario > 0) Then
			consulta += " AND hexc_horarioid=" + Horario.ToString
		End If
		consulta += " AND hexc_activo='" + Activo.ToString + "'"

		If fechaSeleccionada Then
			consulta += " and hexc_Fecha='" + Fecha.ToString + "'"
		End If
		Return operaciones.EjecutaConsulta(consulta)

	End Function

	Public Sub altasExe(ByVal excepcion As Entidades.ExcepcionesHorarios)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "nombre"
		parametro.Value = excepcion.Pnombre
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Fecha"
		parametro.Value = excepcion.PFecha
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Horario"
		parametro.Value = excepcion.PHorario.DHorariosid
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Tipo"
		parametro.Value = excepcion.PTipo
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Activo"
		parametro.Value = excepcion.PActivo
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariocreo"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Nomina.SP_altas_ExcepcionesHorarios", listaParametros)

	End Sub
	Public Sub editarHEXC(ByVal excepciones As Entidades.ExcepcionesHorarios)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "nombre"
		parametro.Value = excepciones.Pnombre
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Fecha"
		parametro.Value = excepciones.PFecha
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Horario"
		parametro.Value = excepciones.PHorario.DHorariosid
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Tipo"
		parametro.Value = excepciones.PTipo
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Activo"
		parametro.Value = excepciones.PActivo
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariomodifico"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "idHexc"
		parametro.Value = excepciones.PExcepcionesHorarioID
		listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Nomina.SP_editar_ExcepcionesHorario", listaParametros)

	End Sub
	Public Function buscarExcepciones(ByVal idHexc As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Return operaciones.EjecutaConsulta(" select * from Nomina.HorariosExcepciones as a join Nomina.Horarios as b on (a.hexc_horarioid=b.hora_horarioid) where hexc_horarioexcepcionid=" + idHexc.ToString)

	End Function
	Public Function listaHorariosActivos() As DataTable
		Dim objOperaciones As New Persistencia.OperacionesProcedimientos
		Return objOperaciones.EjecutaConsulta("select * from Nomina.HorariosExcepciones where hexc_activo='True'")
	End Function
End Class
