Imports Persistencia

Public Class OpcionesProgramacionDA
    Public Function obtnerValoresTabla() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * from Programacion.Opciones"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function tablaUsuarioProgramacion() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select paus_pausID ID_,UPPER( u1.user_nombrereal) Usuario, CONVERT(varchar,paus_fechamodificacion,103) + ' '+ CONVERT(varchar,paus_fechamodificacion,108) paus_fechamodificacion,u2.user_username from Programacion.programacionAutomaticaUsuarios INNER JOIN Framework.Usuarios u1 ON u1.user_usuarioid = paus_usuarioID INNER JOIN Framework.Usuarios u2 ON u2.user_usuarioid = paus_usuariomodificaid ORDER by u1.user_nombrereal"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Sub Agregar(usuarioID As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim idUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim consulta As String = "insert into Programacion.programacionAutomaticaUsuarios (paus_usuarioID,paus_fechamodificacion,paus_usuariomodificaid) values (" & usuarioID.ToString & ", GETDATE(), " + idUsuario.ToString + ")"
        operaciones.EjecutaConsulta(consulta)
    End Sub
    Public Sub Eliminar(pausID As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "delete from programacion.ProgramacionAutomaticaUsuarios where paus_pausID=" & pausID.ToString
        operaciones.EjecutaSentencia(consulta)
    End Sub
    Public Sub actualizarOpciones(ByVal valoreOpciones As DataTable)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim idUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim consulta As String = ""
        For Each fila As DataRow In valoreOpciones.Rows
            consulta = "UPDATE Programacion.Opciones SET " + fila(0).ToString + "='" + fila(1).ToString + "', opci_fechamodificacion = GETDATE(),opci_usuariomodificaid = " + idUsuario.ToString + "  where  " + fila(2).ToString + "='" + fila(3).ToString + "'"
            operaciones.EjecutaSentencia(consulta)
        Next
    End Sub
    Public Function ListarUsuariosSegunPerfil(ByVal perfil As Integer) As DataTable
        Dim ObjPersistencia As New OperacionesProcedimientos
        Dim consulta As String = "SELECT p.perf_perfilid, p.perf_nombre, u.user_usuarioid, u.user_username,UPPER ( u.user_nombrereal ) as user_nombrereal " +
                     "FROM Framework.Perfiles p " +
                     "JOIN Framework.PerfilesUsuario pu ON p.perf_perfilid = pu.peus_perfilid " +
                     "JOIN Framework.Usuarios u   ON pu.peus_usuarioid = u.user_usuarioid " +
                     "WHERE p.perf_perfilid = " + perfil.ToString + " AND u.user_activo = 1 AND u.user_usuarioid NOT IN (SELECT paus_usuarioID from Programacion.ProgramacionAutomaticaUsuarios)  ORDER by u.user_nombrereal "
        Return ObjPersistencia.EjecutaConsulta(consulta)
    End Function
End Class
