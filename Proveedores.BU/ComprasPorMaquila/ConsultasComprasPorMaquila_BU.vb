Imports Proveedores.DA
Public Class ConsultasComprasPorMaquila_BU
    Public Function ObtenerComprasPorMaquila(pAnio As Integer, pSemanaInicio As Integer, pSemanaFin As Integer, pIdNaves As String) As DataTable
        Dim obj As New ConsultaComprasMaquila_DA
        Return obj.ObtenieneComprasPorMaquila(pAnio, pSemanaInicio, pSemanaFin, pIdNaves)
    End Function

    Public Function ObtenerConsultasNaveFiltro(pIdNaves As Integer) As DataTable
        Dim obj As New ConsultaComprasMaquila_DA
        Dim tabla As New DataTable
        tabla = obj.ConsultasNavesFiltro(pIdNaves)
        Return tabla
    End Function

End Class
