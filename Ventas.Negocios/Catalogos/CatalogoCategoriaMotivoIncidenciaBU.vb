
Public Class CatalogoCategoriaMotivoIncidenciaBU


    Public Function ListaCategoriasMotivosIncidencias(ByVal Activo As Boolean) As DataTable
        Dim objCategoriaMotivosIncidencia As New Ventas.Datos.CatalogoCategoriaMotivoIncidenciaDA
        Return objCategoriaMotivosIncidencia.ListaCategoriasMotivosIncidencias(Activo)
    End Function

    Public Sub AltaCategoria(ByVal objCategoria As Entidades.CategoriaMotivoIncidencia)
        Dim objCategoriaMotivosIncidencia As New Ventas.Datos.CatalogoCategoriaMotivoIncidenciaDA
        objCategoriaMotivosIncidencia.AltaCategoria(objCategoria)
    End Sub

    'Public Sub ActualizarRelacionMotivosIncidenciaCategorias(ByVal CategoriaID As Integer, ByVal ListaMotivosActivos As String, ByVal UsuarioID As Integer)
    '    Dim objCategoriaMotivosIncidencia As New Ventas.Datos.CatalogoCategoriaMotivoIncidenciaDA
    '    objCategoriaMotivosIncidencia.ActualizarRelacionMotivosIncidenciaCategorias(CategoriaID, ListaMotivosActivos, UsuarioID)
    'End Sub

    Public Sub EditarCategoria(ByVal objCategoria As Entidades.CategoriaMotivoIncidencia)
        Dim objCategoriaMotivosIncidencia As New Ventas.Datos.CatalogoCategoriaMotivoIncidenciaDA
        objCategoriaMotivosIncidencia.EditarCategoria(objCategoria)
    End Sub

End Class
