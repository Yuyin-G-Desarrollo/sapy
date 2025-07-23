

Public Class CatalogoMotivosIncidenciaBU


    Public Function ListaTiposMotivosIncidencias(ByVal Activo As Boolean) As DataTable
        Dim objCatalogoMotivosIncidencia As New Ventas.Datos.CatalogoMotivosIncidenciaDA
        Return objCatalogoMotivosIncidencia.ListaTiposMotivosIncidencias(Activo)
    End Function


    Public Sub AltaMotivoIncidencia(ByVal objMotivoIncidencia As Entidades.CatalogoMotivosIncidencias)
        Dim objCatalogoMotivosIncidencia As New Ventas.Datos.CatalogoMotivosIncidenciaDA
        objCatalogoMotivosIncidencia.AltaMotivoIncidencia(objMotivoIncidencia)
    End Sub

    Public Sub EditarMotivoIncidencia(ByVal objMotivoIncidencia As Entidades.CatalogoMotivosIncidencias)
        Dim objCatalogoMotivosIncidencia As New Ventas.Datos.CatalogoMotivosIncidenciaDA
        objCatalogoMotivosIncidencia.EditarMotivoIncidencia(objMotivoIncidencia)
    End Sub

End Class
