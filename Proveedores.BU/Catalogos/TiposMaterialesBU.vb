Imports Proveedores.DA
Public Class TiposMaterialesBU
    Public Function getTiposMateriales(ByVal id As Integer) As DataTable
        Dim obj As New TiposMaterialesDA
        Return obj.getTiposMateriales(id)
    End Function
    Public Function updateTiposMateriales(ByVal id As Integer, ByVal nombre As String, ByVal status As String) As DataTable
        Dim obj As New TiposMaterialesDA
        Return obj.updateTiposMateriales(id, nombre, status)
    End Function
    Public Function insertTiposMateriales(ByVal nombre As String) As DataTable
        Dim obj As New TiposMaterialesDA
        Return obj.insertTiposMateriales(nombre)
    End Function
    Public Function verificarTiposMateriales(ByVal nombre As String) As DataTable
        Dim obj As New TiposMaterialesDA
        Return obj.verificarTiposMateriales(nombre)
    End Function
End Class
