Public Class PedidosDA

    Public Function ObtenerAvisos() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT avis_avisID as ID,cast(CONVERT(VARCHAR(8), avis_hora, 108)  as varchar) as Hora FROM Programacion.ProgramacionAvisos order BY 1"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function TablaUsuarioAviso(avisID As Int32) As DataTable
        TablaUsuarioAviso = New DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select ausu_ausuID ID ,user_nombrereal Usuario, cast(CONVERT(VARCHAR(8), avis_hora, 108)  as varchar) Hora from Programacion.ProgramacionAvisosUsuarios inner join Framework.Usuarios on user_usuarioid = ausu_usuarioID INNER join Programacion.ProgramacionAvisos on avis_avisID = ausu_avisID where avis_avisID = " + avisID.ToString + " ORDER BY user_nombrereal ASC, avis_hora ASC"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Sub AgregarHoraAviso(hora As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "INSERT INTO Programacion.ProgramacionAvisos (avis_hora) values ('" + hora + "')"
        operaciones.EjecutaSentencia(consulta)
    End Sub
    Public Function VerificarHoraAviso(hora As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT *FROM Programacion.ProgramacionAvisos WHERE  avis_hora ='" + hora + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Sub EliminarHoraAviso(id As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "DELETE Programacion.ProgramacionAvisos where avis_avisID=" + id.ToString
        operaciones.EjecutaSentencia(consulta)
    End Sub
    Public Sub AgregarUsuarioAviso(usuarioID As Int32, avisID As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "INSERT INTO Programacion.ProgramacionAvisosUsuarios(ausu_usuarioID,ausu_avisID) values(" + usuarioID.ToString + "," + avisID.ToString + ")"
        operaciones.EjecutaSentencia(consulta)
    End Sub
    Public Sub EliminarUsuarioAviso(ausuID As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "DELETE FROM Programacion.ProgramacionAvisosUsuarios where ausu_ausuID=" + ausuID.ToString
        operaciones.EjecutaSentencia(consulta)
    End Sub
    Public Function VerificarUsuarioAviso(usuarioID As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT *  from Programacion.ProgramacionAvisosUsuarios where ausu_usuarioID=" + usuarioID.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Sub ModificarHoraAviso(id As Int32, hora As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "UPDATE Programacion.ProgramacionAvisos SET avis_hora ='" + hora + "' where avis_avisID =" + id.ToString
        operaciones.EjecutaSentencia(consulta)
    End Sub
End Class
