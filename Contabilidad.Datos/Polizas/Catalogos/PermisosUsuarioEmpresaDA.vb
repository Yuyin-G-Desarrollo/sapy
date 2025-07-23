Imports System.Data
Imports System.Data.SqlClient
Imports Persistencia
Imports System.Collections.Generic

Public Class PermisosUsuarioEmpresaDA

    Public Function Consulta_lista_Usuario_Contabilidad() As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " " +
                    " SELECT DISTINCT" +
                    " 	U.user_usuarioid," +
                    " 	UPPER(U.user_username) AS 'Nombre de Usuario'," +
                    "   UPPER(U.user_nombrereal) AS 'Nombre Real'" +
                    " FROM Framework.AccionesModulo" +
                    " JOIN Framework.PermisosUsuario ON peru_accionid = acmo_accionmoduloid" +
                    " JOIN Framework.Usuarios AS U ON U.user_usuarioid = peru_usuarioid" +
                    " WHERE U.user_activo = 1 And acmo_accionmoduloid = 362" +
                    " UNION" +
                    " SELECT DISTINCT" +
                    "   U2.user_usuarioid," +
                    "   UPPER(U2.user_username) AS 'Nombre de Usuario'," +
                    "   UPPER(U2.user_nombrereal) AS 'Nombre Real'" +
                    " FROM Framework.AccionesModulo" +
                    " JOIN Framework.PermisosPerfil ON pepe_accionid = acmo_accionmoduloid" +
                    " JOIN Framework.PerfilesUsuario ON peus_perfilid = pepe_perfilid" +
                    " JOIN Framework.Usuarios AS U2 ON U2.user_usuarioid = peus_usuarioid" +
                    " WHERE U2.user_activo = 1 And acmo_accionmoduloid = 362"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function lista_Permisos_Usuario_Empresa(userID As Integer) As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " " +
                    " WITH " +
                    " 	 T AS ( " +
                    " 			SELECT" +
                    " 				essc_empresaid," +
                    " 				essc_razonsocial," +
                    " 				ROW_NUMBER() OVER (ORDER BY essc_empresaid) AS eFila" +
                    " 			FROM Framework.empresaSaySicyContpaq" +
                    " 			LEFT JOIN Framework.permisosUsuarioEmpresa ON prue_empresaid = essc_empresaid" +
                    " 			WHERE prue_usuarioid = " + userID.ToString +
                    " 		  )," +
                    " 	F AS (" +
                    " 			SELECT DISTINCT" +
                    " 				essc_empresaid," +
                    " 				essc_razonsocial," +
                    " 				ROW_NUMBER() OVER (ORDER BY essc_empresaid) AS FFila" +
                    "           FROM Framework.empresaSaySicyContpaq" +
                    " 		 )" +
                    " SELECT" +
                    " 	COALESCE(T.essc_empresaid, F.essc_empresaid) AS 'ID'," +
                    " 	COALESCE(T.essc_razonsocial, F.essc_razonsocial) AS 'Razón Social'," +
                    " 	(CASE" +
                    " 		WHEN T.essc_empresaid IS NULL THEN CAST(0 AS bit)" +
                    " 		ELSE CAST(1 AS bit)" +
                    " 	END) AS '	'" +
                    " FROM T FULL OUTER JOIN F ON T.essc_empresaid = F.essc_empresaid"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub Permisos_Usuario_Empresa(bandera As Integer, userID As Integer, empresaID As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ' @bandera AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        ',@userID AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "userID"
        parametro.Value = userID
        listaParametros.Add(parametro)

        ',@empresaID AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "empresaID"
        parametro.Value = empresaID
        listaParametros.Add(parametro)

        ',@usuariocreoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuarioID"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Contabilidad.SP_Permisos_Usuario_Empresa", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

End Class
