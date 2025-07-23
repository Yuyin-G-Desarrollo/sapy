Public Class CatalogoJustificacionesDA
  
    Public Function JustificacionesTabla() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT just_justID id_,just_mensaje Mensaje FROM Programacion.PedidosCatalogoJustificaciones ORDER BY just_mensaje"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Sub Agregar(mensaje As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        operaciones.EjecutaSentencia("INSERT INTO Programacion.PedidosCatalogoJustificaciones (just_mensaje) values ('" & mensaje.ToString & "')")
    End Sub

    Public Sub Eliminar(id As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        operaciones.EjecutaSentencia("DELETE FROM Programacion.PedidosCatalogoJustificaciones where just_justID=" & id.ToString)
    End Sub

    Public Sub Modificar(obj As Entidades.ProgramacionCatalogoJustificaciones)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        operaciones.EjecutaSentencia("UPDATE Programacion.PedidosCatalogoJustificaciones set just_mensaje = '" & obj.Mensaje.ToString & "' where just_justID = " & obj.Id.ToString)
    End Sub
End Class
