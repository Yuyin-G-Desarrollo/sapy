Imports Proveedores.DA

Public Class CatalogoRetencionesBU

    Public Function InsertaEditaRetenciones(ByVal descripcion As String, ByVal base As String, ByVal porcentaje As Double, ByVal RetencionID As Integer, ByVal Activo As Integer) As DataTable
        Dim objDA As New CatalogoRetencionesDA
        Return objDA.InsertaEditaRetenciones(descripcion, base, porcentaje, RetencionID, Activo)
    End Function

    Public Function ObtenerRetenciones(ByVal RetencionID As Integer) As DataTable
        Dim objDA As New CatalogoRetencionesDA
        Return objDA.ObtenerRetenciones(RetencionID)
    End Function

End Class
