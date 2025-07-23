Imports Programacion.Datos

Public Class MaterialesPorArticuloBU

    Public Function ObtieneMaterialesPorArticulo(ByVal NavesDesarrollo As String, NavesProduccion As String, ByVal Proveedor As String, ByVal TipoMaterial As String, ByVal Marca As String, ByVal Coleccion As String, ByVal Modelo As String, ByVal PielColor As String, ByVal Corrida As String, ByVal Estatus As String) As DataTable
        Dim obj As New MaterialesPorArticuloDA

        Return obj.ObtieneMaterialesPorArticulo(NavesDesarrollo, NavesProduccion, Proveedor, TipoMaterial, Marca, Coleccion, Modelo, PielColor, Corrida, Estatus)
    End Function

End Class
