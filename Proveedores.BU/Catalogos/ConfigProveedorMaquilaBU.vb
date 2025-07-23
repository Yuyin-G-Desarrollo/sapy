Imports Proveedores.DA

Public Class ConfigProveedorMaquilaBU
    Public Function getProveedores() As DataTable
        Dim obj As New ConfigProveedorMaquilaDA
        Return obj.getProveedores()
    End Function
    Public Function insertProveedorConfig(ByVal idNave As Integer, ByVal idProvee As Integer) As DataTable
        Dim obj As New ConfigProveedorMaquilaDA
        Return obj.insertProveedorConfig(idNave, idProvee)
    End Function
    Public Function getProveedoresNave(ByVal idNave As Integer) As DataTable
        Dim obj As New ConfigProveedorMaquilaDA
        Return obj.getProveedoresNave(idNave)
    End Function
    Public Function getProveedoresNaveConfigurados(ByVal idNaveSICY As Integer) As DataTable
        Dim obj As New ConfigProveedorMaquilaDA
        Return obj.getProveedoresNaveConfigurados(idNaveSICY)
    End Function
    Public Function eliminarProveedorConfig(ByVal id As Integer) As DataTable
        Dim obj As New ConfigProveedorMaquilaDA
        Return obj.eliminarProveedorConfig(id)
    End Function
    Public Function verificarProveedorConfig(ByVal idProv As Integer, ByVal idNave As Integer) As Boolean
        Dim obj As New ConfigProveedorMaquilaDA
        Return obj.verificarProveedorConfig(idProv, idNave)
    End Function
    Public Function getNaveSIcy(ByVal idNave As Integer) As Integer
        Dim obj As New AgregarComprobanteDA
        Return obj.getNaveSIcy(idNave)
    End Function
End Class
