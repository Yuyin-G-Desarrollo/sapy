Imports Proveedores.DA

Public Class ConfigPagoMaquilasBU
    Public Function getNavesConfig() As DataTable
        Dim obj As New ConfigPagoMaquilasDA
        Return obj.getNavesConfig()
    End Function
    Public Function getContribuyentes() As DataTable
        Dim obj As New ConfigPagoMaquilasDA
        Return obj.getContribuyentes()
    End Function
    Public Function getConfigContribuyentes() As DataTable
        Dim obj As New ConfigPagoMaquilasDA
        Return obj.getConfigContribuyentes()
    End Function
    Public Function existeConfiguracionDetalles(ByVal idConfig As Integer, ByVal idRazSoc As Integer) As DataTable
        Dim obj As New ConfigPagoMaquilasDA
        Return obj.existeConfiguracionDetalles(idConfig, idRazSoc)
    End Function
    Public Function insertConfiguracionDetalles(ByVal idConfig As Integer, ByVal idRazSoc As Integer, ByVal value As Integer) As DataTable
        Dim obj As New ConfigPagoMaquilasDA
        Return obj.insertConfiguracionDetalles(idConfig, idRazSoc, value)
    End Function
    Public Function updateConfiguracionDetalles(ByVal idConfig As Integer, ByVal idRazSoc As Integer, ByVal value As Integer) As DataTable
       Dim obj As New ConfigPagoMaquilasDA
        Return obj.updateConfiguracionDetalles(idConfig, idRazSoc, value)
    End Function
    Public Function insertConfiguracion(ByVal idNave As Integer, ByVal factura As Double, ByVal remision As Double, ByVal tolerancia As Double) As DataTable
       Dim obj As New ConfigPagoMaquilasDA
        Return obj.insertConfiguracion(idNave, factura, remision, tolerancia)
    End Function
    Public Function updateConfiguracion(ByVal idConfig As Integer, ByVal factura As Double, ByVal remision As Double, ByVal tolerancia As Double) As DataTable
       Dim obj As New ConfigPagoMaquilasDA
        Return obj.updateConfiguracion(idConfig, factura, remision, tolerancia)
    End Function
End Class
