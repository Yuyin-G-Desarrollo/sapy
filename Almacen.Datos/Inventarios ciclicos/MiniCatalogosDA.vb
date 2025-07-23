Public Class MiniCatalogosDA


    Public Function verMarcas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim cadena As String = "select IdMarca, Marca from Marcas WHERE Activo='S' order by Marca"
        Return operacion.EjecutaConsulta(cadena)
    End Function


    Public Function verColecciones(ByVal IdMarca As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim cadena As String = "select a.IdColeccion , a.Coleccion as Colección from Colecciones as a JOIN MarcasColecciones AS b on b.IdColeccion=a.IdColeccion" +
            " where a.Activo='S' and b.Activo='S' "
        If IdMarca <> String.Empty Then
            cadena = cadena + " and b.IdMarca='" + IdMarca + "'"
        End If
        Return operacion.EjecutaConsulta(cadena)
    End Function



End Class
