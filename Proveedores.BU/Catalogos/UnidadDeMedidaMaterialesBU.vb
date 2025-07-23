Imports Proveedores.DA

Public Class UnidadDeMedidaMaterialesBU
    Public Function getUnidadesMedidas(ByVal id As Integer) As DataTable
        Dim obj As New UnidadDeMedidaMaterialesDA
        Return obj.getUnidadesMedidas(id)
    End Function
    Public Function updateUnidadesMedidas(ByVal id As Integer, ByVal nombre As String, ByVal status As String) As DataTable
        Dim obj As New UnidadDeMedidaMaterialesDA
        Return obj.updateUnidadesMedidas(id, nombre, status)
    End Function
    Public Function insertUnidadesMedidas(ByVal nombre As String) As DataTable
        Dim obj As New UnidadDeMedidaMaterialesDA
        Return obj.insertUnidadesMedidas(nombre)
    End Function
    Public Function verificarUnidadesMedidas(ByVal des As String) As DataTable
        Dim obj As New UnidadDeMedidaMaterialesDA
        Return obj.verificarUnidadesMedidas(des)
    End Function
End Class
