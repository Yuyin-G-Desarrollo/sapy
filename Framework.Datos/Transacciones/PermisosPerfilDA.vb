Imports Entidades
Imports System.Data.SqlClient

Public Class PermisosPerfilDA
	Public Function ConsultaPermiso(ByVal UsuarioID As Int32, ByVal ClaveModulo As String, ByVal ClaveAccion As String) As PermisosPerfil
		Try
			Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos()
			Dim DtResultados As DataTable
			Dim ObjPermisosPerfil As New PermisosPerfil

			Dim Consulta As String = "SELECT pepe_perfilid,pepe_accionid FROM Framework.PermisosPerfil"
			Consulta += " join Framework.Perfiles on (pepe_perfilid=perf_perfilid)"
			Consulta += " join Framework.AccionesModulo on (pepe_accionid=acmo_accionmoduloid)"
			Consulta += " JOIN Framework.Modulos on (acmo_moduloid=modu_moduloid)"
			Consulta += " JOIN Framework.PerfilesUsuario on (perf_perfilid=peus_perfilid)"
			Consulta += " JOIN Framework.Usuarios on (peus_usuarioid = user_usuarioid)"
			Consulta += " where perf_activo='True' AND acmo_activo='True' and user_activo='True'"
			Consulta += " and user_usuarioid=" + UsuarioID.ToString
			Consulta += " and modu_clave LIKE '" + ClaveModulo + "'"
			Consulta += " and acmo_clave LIKE '" + ClaveAccion + "'"



			DtResultados = ObjPersistencia.EjecutaConsulta(Consulta)
			For Each row As DataRow In DtResultados.Rows
				Dim perfil As New Perfiles
				perfil.Pperfilid = CInt(row(0))
				ObjPermisosPerfil.Pperfilid = perfil

				Dim accion As New Acciones
				accion.PAccionId = CInt(row(1))
				ObjPermisosPerfil.Paccionid = accion

			Next
			Return ObjPermisosPerfil
		Catch ex As SqlClient.SqlException
			Throw ex
		End Try

	End Function

	Public Function ConsultaPermisoLectura(ByVal UsuarioID As Int32, ByVal Moduloid As Int32) As PermisosPerfil
		Try
			Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos()
			Dim DtResultados As DataTable
			Dim ObjPermisosPerfil As New PermisosPerfil

            Dim Consulta As String
            Consulta = "SELECT pepe_perfilid,pepe_accionid FROM Framework.PermisosPerfil  join Framework.Perfiles on (pepe_perfilid=perf_perfilid) " +
            " join Framework.AccionesModulo on (pepe_accionid=acmo_accionmoduloid) " +
            " JOIN Framework.Modulos on (acmo_moduloid=modu_moduloid) " +
            " where pepe_perfilid in " +
            " (select peus_perfilid from Framework.PerfilesUsuario" +
            " join Framework.Usuarios on (peus_usuarioid=user_usuarioid) " +
            " where peus_usuarioid=" +
                CStr(UsuarioID) +
            " and user_activo='True') and acmo_tipo=1 and acmo_moduloid=" + CStr(Moduloid)

            DtResultados = ObjPersistencia.EjecutaConsulta(Consulta)
            For Each row As DataRow In DtResultados.Rows
                Dim perfil As New Perfiles
                perfil.Pperfilid = CInt(row(0))
                ObjPermisosPerfil.Pperfilid = perfil

                Dim accion As New Acciones
                accion.PAccionId = CInt(row(1))
                ObjPermisosPerfil.Paccionid = accion
            Next
            Return ObjPermisosPerfil
        Catch ex As SqlClient.SqlException
			Throw ex
		End Try

	End Function

	Public Function listaPermisos(ByVal perfilid As Int32, ByVal accionid As Int32, ByVal modulo As Int32) As DataTable

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = "SELECT * FROM Framework.PermisosPerfil as a " +
		 "JOIN Framework.Perfiles as b on (a.pepe_perfilid=b.perf_perfilid)" +
		 "JOIN Framework.accionesmodulo as c on (a.pepe_accionid=c.acmo_accionmoduloid)" +
		 "JOIN framework.modulos as d on (c.acmo_moduloid=d.modu_moduloid)" +
		 "JOIN Framework.grupos as e on (b.perf_grupoid=e.grup_grupoid)"

		If (perfilid > 0) Then
			consulta += " AND pepe_perfilid=" + perfilid.ToString
		End If

		If (accionid > 0) Then
			consulta += " AND pepe_accionid=" + accionid.ToString
		End If
		If (modulo > 0) Then
			consulta += " AND acmo_moduloid =" + modulo.ToString
		End If

		Return operaciones.EjecutaConsulta(consulta)
	End Function

	Public Sub AltasPermisos(ByVal permisos As Entidades.PermisosPerfil)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaValores As New List(Of SqlParameter)

		

		Dim valores As New SqlParameter
		valores.ParameterName = "idperfil"
		valores.Value = permisos.Pperfilid.Pperfilid
		listaValores.Add(valores)


		valores = New SqlParameter
		valores.ParameterName = "idaccion"
		valores.Value = permisos.Paccionid.PAccionId
		listaValores.Add(valores)


		valores = New SqlParameter
		valores.ParameterName = "usuariocreo"
		valores.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaValores.Add(valores)

		operaciones.EjecutarSentenciaSP("Framework.SP_altas_PermisosPerfil", listaValores)

	End Sub
	Public Sub eliminarPermisos(ByVal permisos As Int32, ByVal idperfil As Int32, ByVal idmodulo As Int32)


		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaValores As New List(Of SqlParameter)



		Dim valores As New SqlParameter
		valores.ParameterName = "idperfil"
		valores.Value = idperfil
		listaValores.Add(valores)


		valores = New SqlParameter
		valores.ParameterName = "idaccion"
		valores.Value = permisos
		listaValores.Add(valores)



		operaciones.EjecutarSentenciaSP("Framework.SP_Eliminar_PermisosPerfil", listaValores)

	End Sub
	Public Function buscarpermisos(ByVal idpermisos As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Return operaciones.EjecutaConsulta("SELECT * FROM Framework.PermisosPerfil as a " +
		 "JOIN Framework.Perfiles as b on (a.pepe_perfilid=b.perf_perfilid)" +
		 "JOIN Framework.accionesmodulo as c on (a.pepe_accionid=c.acmo_accionmoduloid)" +
		 "JOIN framework.modulos as d on (c.acmo_moduloid=d.modu_moduloid)" +
		 "JOIN Framework.grupos as e on (b.perf_grupoid=e.grup_grupoid) where acmo_moduloid")

	End Function

    Public Function TraerUsuario(ByVal Usuario As String) As String
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim dt = operaciones.EjecutaConsulta("SELECT user_username FROM Framework.Usuarios WHERE user_colaboradorid = " + Usuario)
        Return dt.Rows(0).Item(0).ToString

    End Function

End Class
