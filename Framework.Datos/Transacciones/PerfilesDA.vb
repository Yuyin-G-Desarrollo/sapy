Imports System.Data.SqlClient

Public Class PerfilesDA
    Public Function listaPerfiles(ByVal nombre As String, ByVal idDepartamento As Int32, ByVal activo As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM Framework.Perfiles as a JOIN Framework.Grupos as b on (a.perf_grupoid=b.grup_grupoid)"
        consulta += " AND perf_nombre like '%" + nombre + "%'"
        If (idDepartamento > 0) Then
            consulta += " AND perf_grupoid=" + idDepartamento.ToString
        End If

        consulta += " AND perf_activo='" + activo.ToString + "'"

        Return operaciones.EjecutaConsulta(consulta)
    End Function


    ' funcion para boton altas'
    Public Sub guardarPerfil(ByVal perfil As Entidades.Perfiles)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = perfil.PNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "departamento"
        parametro.Value = perfil.PDepartamento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = perfil.PActivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreo"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_altas_perfiles", listaParametros)

    End Sub

    Public Sub editarPerfil(ByVal perfil As Entidades.Perfiles)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = perfil.PNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idDepartamento"
        parametro.Value = perfil.PDepartamento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = perfil.PActivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodifico"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPerfil"
        parametro.Value = perfil.Pperfilid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_editar_perfil", listaParametros)

    End Sub

    Public Function buscarPerfil(ByVal idPerfil As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutaConsulta("SELECT * FROM Framework.Perfiles where perf_perfilid=" + idPerfil.ToString)
    End Function
	Public Function ListaPerfilesSegunDepartamento(ByVal departamentoid As Integer) As DataTable
		Dim opereciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = "SELECT * FROM Framework.grupos AS b JOIN Framework.perfiles as c on (b.grup_grupoid=perf_grupoid)  where perf_activo = 'true'"

		If departamentoid > 0 Then
			consulta += " AND perf_grupoid=" + departamentoid.ToString
		End If

		Return opereciones.EjecutaConsulta(consulta)
    End Function

    Public Function VerPerfiles() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutaConsulta("select perf_perfilid , perf_nombre  from Framework.Perfiles where perf_activo ='true' order by perf_nombre")
    End Function

    Public Function VerUsuariosPerfil(ByVal idPerfil As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutaConsulta("select us.user_usuarioid , us.user_nombrereal +' ('+ us.user_username +')' as 'NombreUsuario' from Framework.Usuarios  as us" +
                                             " inner join Framework.PerfilesUsuario as pu on us.user_usuarioid=pu.peus_usuarioid" +
                                             " inner join Framework.Perfiles as pe on pu.peus_perfilid =pe.perf_perfilid where perf_perfilid =" + idPerfil + " and us.user_activo ='true';")
    End Function


    Public Function ValidarPerfilNuevo(ByVal nomPerfil As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutaConsulta("select COUNT (*) as 'total' from Framework.Perfiles where perf_nombre ='" + nomPerfil + "' and perf_activo ='True'")
    End Function

    Public Function verGrupos() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutaConsulta("SELECT grup_grupoid,grup_name,grup_naveid,grup_areaid FROM Framework.Grupos where grup_activo ='true'")
    End Function

End Class


