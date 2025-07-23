Imports Proveedores.DA
Public Class CategoriasMaterialesBU
    Public Function getCategoriasMateriales(ByVal id As Integer) As DataTable
        Dim obj As New CategoriasMaterialesDA
        Return obj.getCategorias(id)
    End Function
    Public Function updateCategoriasMateriales(ByVal id As Integer, ByVal nombre As String, ByVal status As String, ByVal Giro As Integer) As DataTable
        Dim obj As New CategoriasMaterialesDA
        Return obj.updateCategorias(id, nombre, status, Giro)
    End Function
    Public Function inserCategoriasMateriales(ByVal categoria As String, ByVal Giro As Integer, ByVal UsuarioCreoID As Integer) As DataTable
        Dim obj As New CategoriasMaterialesDA
        Return obj.insertCategorias(categoria, Giro, UsuarioCreoID)
    End Function
    Public Function verificarCategoria(ByVal des As String) As DataTable
        Dim obj As New CategoriasMaterialesDA
        Return obj.verificarCategoria(des)
    End Function
    Public Function ObtieneGiroDeNave() As DataTable
        Dim obj As New CategoriasMaterialesDA
        Return obj.ObtieneGiroDeNave()
    End Function

End Class
