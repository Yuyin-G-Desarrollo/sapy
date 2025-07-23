Public Class NaveAuxDA

    Public Function tablaNavesAux() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT nave_naveid, nave_nombre, nave_activo, nave_lun," & _
        " nave_mar, nave_mie, nave_jue, nave_vie, nave_sab," & _
        " nave_dom, nave_idSicy, nave_orden" & _
        " FROM Programacion.NavesAux" & _
        " WHERE nave_activo = 1" & _
        " ORDER BY nave_orden"
        Return operacion.EjecutaConsulta(cadena)
    End Function
End Class
