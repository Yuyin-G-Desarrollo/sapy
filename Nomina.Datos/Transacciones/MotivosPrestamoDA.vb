Imports System.Data.SqlClient

Public Class MotivosPrestamoDA
	Public Function ListaMotivosPrestamos(ByVal Nombre As String, ByVal Nave As Int32, ByVal Activo As Boolean) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = " select * from Nomina.MotivosPrestamo as a JOIN Framework.Naves as b on (a.mpre_naveid=b.nave_naveid)"
		consulta += "And mpre_nombre like '%" + Nombre + "%'"
		If (Nave > 0) Then
			consulta += " AND mpre_naveid=" + Nave.ToString
		End If
		consulta += " AND mpre_activo='" + Activo.ToString + "'"
		Return operaciones.EjecutaConsulta(consulta)
	End Function
	Public Sub altasDeMotivos(ByVal motivo As Entidades.MotivosPrestamo)

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

		operaciones.EjecutarSentenciaSP("Nomina.SP_altas_Motivos", listaParametros)

	End Sub

	Public Sub editarMotivosPrestamo(ByVal motivo As Entidades.MotivosPrestamo)

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
		parametro.Value = motivo.PMotivoPrestamoId
		listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Nomina.SP_editar_Motivos", listaParametros)

	End Sub


	Public Function buscarMotivos(ByVal idmotivos As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Return operaciones.EjecutaConsulta(" select * from Nomina.MotivosPrestamo as a JOIN Framework.Naves as b on (a.mpre_naveid=b.nave_naveid) where mpre_motivoprestamoid=" + idmotivos.ToString)

	End Function


    Public Function MotivosPorNave(ByVal idNave As Int32) As DataTable

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT     mpre_motivoprestamoid, upper(mpre_nombre) as mpre_nombre "
        consulta += " FROM         Nomina.MotivosPrestamo "
        consulta += " WHERE     (mpre_naveid =" + idNave.ToString + ") AND (mpre_activo = 1) "

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function





End Class




