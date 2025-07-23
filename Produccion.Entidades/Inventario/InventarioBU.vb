Imports Produccion.Datos
Imports Entidades

Public Class InventarioBU
    Function getTotalInventario(ByVal idMaterialNave As Integer, ByVal idProveedor As Integer, ByVal precio As Double, ByVal fechafinal As Date)
        Dim obj As New InventarioDA
        Return obj.getTotalInventario(idMaterialNave, idProveedor, precio, fechafinal)
    End Function
    Function getCierres(ByVal idNave As Integer, ByVal fecha As Date)
        Dim obj As New InventarioDA
        Return obj.getCierres(idNave, fecha)
    End Function
    Public Function getNoSemana(ByVal fecha As Date) As Integer
        Dim obj As New InventarioDA
        Return obj.getNoSemana(fecha)
    End Function
    Function getURLNave(ByVal idNave As Integer) As String
        Dim obj As New InventarioDA
        Return obj.getURLNave(idNave)
    End Function
    Function getInventarioXProveedor(ByVal idNave As Integer, ByVal fecha As Date) As DataTable
        Dim obj As New InventarioDA
        Return obj.getInventarioXProveedor(idNave, fecha)
    End Function
    'Function getClasificaciones() As DataTable
    '    Dim obj As New InventarioDA
    '    Return obj.getClasificaciones
    'End Function
    Function getMovimientos(ByVal movsGerente As Boolean, ByVal movsUsuario As Boolean) As DataTable
        Dim obj As New InventarioDA
        Return obj.getMovimientos(movsGerente, movsUsuario)
    End Function
    Function getDatosInventario(ByVal idNave As Integer, ByVal idClasificacion As String, ByVal fecini As Date) As DataTable
        Dim obj As New InventarioDA
        Return obj.getDatosInventario(idNave, idClasificacion, fecini)
    End Function
    Function getEntradasSalidas(ByVal idMaterialNave As Integer, ByVal idProveedor As Integer, ByVal precio As Double, ByVal fecini As String, ByVal fecfin As String) As DataTable
        Dim obj As New InventarioDA
        Return obj.getEntradasSalidas(idMaterialNave, idProveedor, precio, fecini, fecfin)
    End Function
    Function getMovimientosMaterial(ByVal idProveedor As Integer, ByVal idMaterialNave As Integer, ByVal precio As Double, ByVal fecini As Date, ByVal fecfin As Date)
        Dim obj As New InventarioDA
        Return obj.getMovimientosMaterial(idProveedor, idMaterialNave, precio, fecini, fecfin)
    End Function
    Public Function insertarMovimientoInventario(ByVal p As InventarioNave) As DataTable
        Dim obj As New InventarioDA
        Return obj.insertarMovimientoInventario(p)
    End Function
    Public Function ConsultaInventarioNaves() As DataTable
        Dim obj As New InventarioDA
        Return obj.ConsultaInventarioNaves()
    End Function
End Class
