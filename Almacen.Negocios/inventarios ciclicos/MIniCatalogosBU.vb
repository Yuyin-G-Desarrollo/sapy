Public Class MIniCatalogosBU

    Public Function verMarcasRapido() As DataTable
        Dim MarcaDatos As New Datos.MiniCatalogosDA
        Return MarcaDatos.verMarcas()
    End Function

    Public Function verColecciones(ByVal IdMarca As String) As DataTable
        Dim MarcaDatos As New Datos.MiniCatalogosDA
        Return MarcaDatos.verColecciones(IdMarca)
    End Function

End Class
