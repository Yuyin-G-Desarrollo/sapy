Imports Cobranza.Datos

Public Class Administracion_ConsultaInventarioBU

    Public Function PoblarRazonSocial() As DataTable
        Dim objDA As New Administracion_ConsultaInventarioDA
        Return objDA.PoblarRazonSocial()

    End Function

    Public Function ObtenerInventarioInicial(ByVal RazonSocial As Integer) As DataTable
        Dim objDA As New Administracion_ConsultaInventarioDA
        Dim dtDatosInventario As New DataTable
        dtDatosInventario = objDA.ObtenerInventarioInicial(RazonSocial)
        Return dtDatosInventario
    End Function

    Public Function ObtieneDetalleInventario(ByVal ProductoEstiloID As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim objDA As New Administracion_ConsultaInventarioDA
        Dim dtInventarioDetalles As New DataTable
        dtInventarioDetalles = objDA.ObtieneDetalleInventario(ProductoEstiloID, FechaInicio, FechaFin)
        Return dtInventarioDetalles
    End Function

End Class
