Public Class ArticulosPreferentesDA

    Public Function verArticulosDisponibles(ByVal idMaestro As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT" & _
        " CAST( 0 AS BIT) AS SEL, prod_productoid, pstilo, prod_codigo, modeloSICY, Sicy," & _
        " sicyPCOL, prod_descripcion + ' ' + pielColor + ' - ' + talla AS Descripcion," & _
        " psEstatus, nomSts" & _
        " FROM vProductoEstilos WHERE pstilo NOT IN (" & _
        " SELECT arpr_productoEstiloId FROM Programacion.ArticulosPreferentes " & _
        " WHERE arpr_activo = 1 AND arpr_simulacionMaestroID = " + idMaestro.ToString + ")" & _
        " AND psEstatus IN (2, 3, 4)" & _
        " ORDER BY prod_codigo"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verArticulosPreferentes(ByVal idMaestro As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT CAST( 0 AS BIT) AS SEL, arpr_articuloPreferenteid AS ID, " & _
        " prod_productoid, pstilo, prod_codigo, modeloSICY," & _
        " Sicy, sicyPCOL, prod_descripcion + ' ' + pielColor + ' - ' + talla AS Descripcion," & _
        " psEstatus, nomSts, arpr_orden" & _
        " FROM vProductoEstilos vs" & _
        " JOIN Programacion.ArticulosPreferentes ap" & _
        " ON ap.arpr_productoEstiloId = vs.pstilo" & _
        " WHERE ap.arpr_activo = 1" & _
        " AND vs.pres_activo = 1" & _
        " AND ap.arpr_simulacionMaestroID = " + idMaestro.ToString & _
        " AND psEstatus IN (2, 3, 4)" & _
        " ORDER BY arpr_orden"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub guardarArticulosPreferentes(ByVal idPrestilo As Int32,
                                           ByVal idSimulacion As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@idPrestilo"
        parametro.Value = idPrestilo.ToString
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@idSimulacion"
        parametro.Value = idSimulacion.ToString
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Programacion.SP_guardarArticuloPreferente", listaParametros)

    End Sub

    'Public Sub quitarArticuloPreferente(ByVal idPrestilo As Int32, ByVal idSimulacion As Int32)
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim cadena As String = ""
    '    cadena = "UPDATE Programacion.ArticulosPreferentes SET " & _
    '    " arpr_orden = 0, " & _
    '    " arpr_activo = 0," & _
    '    " arpr_usuarioModifico = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + "," & _
    '    " arpr_fechaModifico = GETDATE()" & _
    '    " WHERE arpr_productoEstiloId = " + idPrestilo.ToString + " AND arpr_simulacionMaestroID = " + idSimulacion.ToString
    '    operacion.EjecutaSentencia(cadena)
    'End Sub

    Public Function verArticulosPreferentesSimulacion(ByVal idSimulacion As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT prod_productoid, pstilo, prod_codigo, modeloSICY," & _
       " Sicy, sicyPCOL, prod_descripcion + ' ' + pielColor + ' - ' + talla AS Descripcion," & _
       " psEstatus, nomSts, arpr_orden" & _
       " FROM vProductoEstilos vs" & _
       " JOIN Programacion.ArticulosPreferentes ap" & _
       " ON ap.arpr_productoEstiloId = vs.pstilo" & _
       " WHERE ap.arpr_activo = 1" & _
       " AND vs.pres_activo = 1" & _
       " AND ap.arpr_simulacionMaestroID = " + idSimulacion.ToString & _
       " ORDER BY arpr_orden"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub editarOrdenArticulo(ByVal idArticuloPrefID As Int32, ByVal orden As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "UPDATE Programacion.ArticulosPreferentes SET arpr_orden = " + orden.ToString & _
            ", arpr_usuarioModifico= " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString & _
            ", arpr_fechaModifico = GETDATE() " & _
            " WHERE arpr_articuloPreferenteid = " + idArticuloPrefID.ToString
        operacion.EjecutaConsulta(cadena)
    End Sub

    Public Sub inactivarArticuloPreferente(ByVal idArticuloPrefID As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "UPDATE Programacion.ArticulosPreferentes SET arpr_activo = 0, arpr_orden = 0" & _
            ", arpr_usuarioModifico= " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString & _
            ", arpr_fechaModifico = GETDATE() " & _
            " WHERE arpr_articuloPreferenteid = " + idArticuloPrefID.ToString
        operacion.EjecutaConsulta(cadena)
    End Sub

End Class
