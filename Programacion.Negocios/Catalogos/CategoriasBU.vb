Public Class CategoriasBU

    Public Function verListaCategorias(ByVal activo As Boolean) As DataTable
        Dim objCatDA As New Datos.CategoriasDA
        Return objCatDA.verListaCategorias(activo)
    End Function

    Public Function verIdMaxCategorias() As DataTable
        Dim objCatDA As New Datos.CategoriasDA
        Return objCatDA.verIdMaxCategorias
    End Function

    Public Sub registrarEditaCategoria(ByVal entCategoria As Entidades.Categorias, ByVal altaCat As Boolean)
        Dim objCatDA As New Datos.CategoriasDA
        objCatDA.registrarEditaCategoria(entCategoria, altaCat)
    End Sub

    Public Function verCategoriaRapido(ByVal idCategoria As Int32) As DataTable
        Dim objCatDA As New Datos.CategoriasDA
        Return objCatDA.vercategoriaRapido(idCategoria)
    End Function

    Public Function contarRegistrosCategoria(ByVal idCategoria As Int32) As DataTable
        Dim objCatDA As New Datos.CategoriasDA
        Return objCatDA.contarRegistrosCategoria(idCategoria)
    End Function

    Public Function verListaSuelas(ByVal activo As Boolean) As DataTable
        Dim objCatDA As New Datos.CategoriasDA
        Return objCatDA.verListaSuelas(activo)
    End Function

    Public Function verListaColorSuela(ByVal activo As Boolean) As DataTable
        Dim objCatDA As New Datos.CategoriasDA
        Return objCatDA.verListaColorSuela(activo)
    End Function



End Class
