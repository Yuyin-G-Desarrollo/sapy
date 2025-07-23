Public Class OrdenNaveAuxDA

    Public Function consultaOrdenNavesSImulacion(ByVal idSimulacion As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT" & _
                " oa.onax_ordenNaveAuxId," & _
                " oa.onax_naveAuxId," & _
                " na.nave_nombre," & _
                " na.nave_orden," & _
                " oa.onax_orden" & _
        " FROM Programacion.ordenNavesAux oa" & _
        " JOIN Programacion.NavesAux na" & _
            " ON oa.onax_naveAuxId = na.nave_naveid" & _
                " WHERE oa.onax_simulacionMaestroId = " + idSimulacion.ToString & _
            " ORDER BY oa.onax_orden"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub editarOrdenSimulacion(ByVal idOrdenNaveAux As Int32, ByVal orden As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "UPDATE Programacion.ordenNavesAux SET onax_orden = " + orden.ToString & _
            ", onax_usuarioModifico = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString & _
            ", onax_fechaModifico = GETDATE() WHERE onax_ordenNaveAuxId = " + idOrdenNaveAux.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub

End Class
