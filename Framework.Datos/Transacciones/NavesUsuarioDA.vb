Imports System.Data.SqlClient

Public Class NavesUsuarioDA
	Public Function listaNavesUsuario(ByVal naveid As Int32, ByVal usuarioid As String) As DataTable

		Dim operaciones As New Persistencia.OperacionesProcedimientos

		Dim consulta As String = "SELECT * FROM Framework.NavesUsuario as a " +
		"JOIN Framework.Naves as b on (a.naus_naveid=b.nave_naveid) " +
		 "JOIN Framework.Usuarios as c on (a.naus_usuarioid=c.user_usuarioid)"
		consulta += " where user_username like '%" + usuarioid + "%'"
		If (naveid > 0) Then
			consulta += " AND naus_naveid=" + naveid.ToString
		End If



		Return operaciones.EjecutaConsulta(consulta)
	End Function
	Public Sub guardar(ByVal naus As Entidades.NavesUsuario)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "usuario"
		parametro.Value = naus.PUsuariosID.PUserUsuarioid
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "nave"
		parametro.Value = naus.PNavesID.PNaveId
		listaParametros.Add(parametro)


		parametro = New SqlParameter
		parametro.ParameterName = "usuariocreo"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)



		operaciones.EjecutarSentenciaSP("Framework.SP_altas_NavesUsuario", listaParametros)

	End Sub
	Public Sub eliminarNaus(ByVal usuario As Int32, ByVal nave As Int32)


		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaValores As New List(Of SqlParameter)



		Dim valores As New SqlParameter
		valores.ParameterName = "usuarios"
		valores.Value = usuario
		listaValores.Add(valores)


		valores = New SqlParameter
		valores.ParameterName = "naves"
		valores.Value = nave
		listaValores.Add(valores)



		operaciones.EjecutarSentenciaSP("Framework.SP_Eliminar_NavesUsuario", listaValores)

	End Sub

	Public Function listaNavesU(ByVal naveid As Int32, ByVal usuarioid As Int32) As DataTable

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = "SELECT * FROM Framework.NavesUsuario as a " +
		"JOIN Framework.Naves as b on (a.naus_naveid=b.nave_naveid) " +
		 "JOIN Framework.Usuarios as c on (a.naus_naveid=b.nave_naveid)"
		If (usuarioid > 0) Then
			consulta += " where user_usuarioid=" + usuarioid.ToString
		End If
		If (naveid > 0) Then
			consulta += " AND naus_naveid=" + naveid.ToString
		End If



		Return operaciones.EjecutaConsulta(consulta)
	End Function

    Public Function listaNavesUsuarioAltas(ByVal naveid As Int32, ByVal usuarioid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM Framework.NavesUsuario "


        If (naveid > 0) Then
            consulta += " where naus_naveid=" + naveid.ToString
        End If
        If (usuarioid > 0) Then
            consulta += " and naus_usuarioid=" + usuarioid.ToString
        End If



        Return operaciones.EjecutaConsulta(consulta)

    End Function


    Public Function listaNavesUsuario(ByVal usuarioid As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos

        Dim consulta As String = "SELECT * FROM Framework.NavesUsuario as a " +
        "JOIN Framework.Naves as b on (a.naus_naveid=b.nave_naveid) " +
         "JOIN Framework.Usuarios as c on (a.naus_usuarioid=c.user_usuarioid) " +
         " where c.user_usuarioid = " + usuarioid.ToString + " "


        Return operaciones.EjecutaConsulta(consulta)
    End Function

End Class
