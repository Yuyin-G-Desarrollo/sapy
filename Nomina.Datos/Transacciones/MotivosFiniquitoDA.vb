Imports System.Data.SqlClient

Public Class MotivosFiniquitoDA

	Public Function ListaMotivosFiniquitos(ByVal Nombre As String, ByVal Nave As Int32, ByVal Activo As Boolean) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = " select * from Nomina.MotivosFiniquito as a JOIN Framework.Naves as b on (a.mfin_naveid=b.nave_naveid)"
		consulta += "And mfin_nombre like '%" + Nombre + "%'"
		If (Nave > 0) Then
			consulta += " AND mfin_naveid=" + Nave.ToString
		End If
		consulta += " AND mfin_activo='" + Activo.ToString + "'"
		Return operaciones.EjecutaConsulta(consulta)
	End Function
	Public Sub altasDeMotivos(ByVal motivo As Entidades.MotivosFiniquito)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "nombre"
		parametro.Value = motivo.PNombre
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Nave"
		parametro.Value = motivo.PNaveId.PNaveId
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "activo"
		parametro.Value = motivo.PActivo
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariocreo"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Nomina.SP_altas_Motivos_Finiquito", listaParametros)

	End Sub



	Public Sub editarMotivosFiniquitos(ByVal motivo As Entidades.MotivosFiniquito)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "nombre"
		parametro.Value = motivo.PNombre
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Nave"
		parametro.Value = motivo.PNaveId.PNaveId
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "activo"
		parametro.Value = motivo.PActivo
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariomodifico"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "idmotivo"
		parametro.Value = motivo.PMotivoFiniquitoId
		listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Nomina.SP_editar_Motivos_Finiquito", listaParametros)

	End Sub


	Public Function buscarMotivos(ByVal idmotivos As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Return operaciones.EjecutaConsulta(" select * from Nomina.MotivosFiniquito as a JOIN Framework.Naves as b on (a.mfin_naveid=b.nave_naveid) where mfin_motivofiniquitoid=" + idmotivos.ToString)

	End Function

    Public Function ListaMotivosFiniquitoSegunNave(ByVal Idnave As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Nomina.MotivosFiniquito where mfin_naveid="
        consulta += Idnave.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function


End Class
