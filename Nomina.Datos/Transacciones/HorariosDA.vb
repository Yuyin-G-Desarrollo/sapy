Imports System.Data.SqlClient
Imports Persistencia

Public Class HorariosDA

	Public Function listaHorariosActivos() As DataTable
		Dim objOperaciones As New Persistencia.OperacionesProcedimientos
		Return objOperaciones.EjecutaConsulta("select * from Nomina.Horarios where hora_activo='True'")
    End Function

    Public Function listaHorariosSegunNave(ByVal NaveId As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Return objOperaciones.EjecutaConsulta("select hora_horarioid, upper(hora_nombre) as hora_nombre   from Nomina.Horarios where hora_activo='True' and hora_naveid=" + NaveId.ToString)
    End Function

    Public Function lista_Horarios(ByVal naveID As Integer, ByVal activo As Boolean) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT hora_horarioid, UPPER(hora_nombre)  AS hora_nombre, hora_activo, hora_naveid, hora_retardo, nave_naveid, nave_nombre FROM Nomina.Horarios JOIN Framework.Naves as n on n.nave_naveid = hora_naveid"


        consulta += " WHERE hora_naveid = " + naveID.ToString + " AND hora_activo = '" + activo.ToString + "' "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

	Public Function listaHorarios(ByVal nombre As String, ByVal Nave As Int32, ByVal Activo As Boolean) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = (" select * from Nomina.Horarios as a JOIN Framework.Naves as b on (a.hora_naveid=b.nave_naveid)")
		consulta += " AND hora_nombre like '%" + nombre + "%'"
		If (Nave > 0) Then
			consulta += " AND hora_naveid=" + Nave.ToString
		End If
		consulta += " AND hora_activo='" + Activo.ToString + "'"

		Return operaciones.EjecutaConsulta(consulta)
	End Function

    Public Sub guardarhorarios(ByVal Horario As Entidades.Horarios)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter

        parametro.ParameterName = "horarioID"
        parametro.Value = Horario.DHorariosid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = Horario.DNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = Horario.DActivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreo"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodifico"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "naveID"
        parametro.Value = Horario.PNaves.PNaveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "retardo"
        parametro.Value = Horario.DRetardo
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_altas_Horarios", listaParametros)

    End Sub

	Public Sub editarHorarios(ByVal horario As Entidades.Horarios)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "Horariosid"
		parametro.Value = horario.DHorariosid
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "nombre"
		parametro.Value = horario.DNombre
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Naves"
		parametro.Value = horario.PNaves.PNaveId
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "activo"
		parametro.Value = horario.DActivo
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariomodifico"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)



		operaciones.EjecutarSentenciaSP("Nomina.SP_editar_Horarios", listaParametros)

	End Sub

	Public Function buscarHorarioId() As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Return operaciones.EjecutaConsulta("select max(hora_horarioid) from Nomina.Horarios")

	End Function

	Public Function buscarHorarios(ByVal horariosid As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Return operaciones.EjecutaConsulta(" select * from Nomina.Horarios as a JOIN Framework.Naves as b on (a.hora_naveid=b.nave_naveid) where hora_horarioid=" + horariosid.ToString)
	End Function
	Public Sub Altashorarios(ByVal Horarios As Entidades.Horarios)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter

		parametro.ParameterName = "Horariosid"
		parametro.Value = Horarios.DHorariosid
		listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Nomina.SP_editar_Horarios", listaParametros)

	End Sub


End Class

