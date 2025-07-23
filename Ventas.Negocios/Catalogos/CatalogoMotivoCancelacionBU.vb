Public Class CatalogoMotivoCancelacionBU

    ''Funcion ListaCatalogoMotivoCancelacion para llenar la lista de motivos cancelacion
    Public Function ListaCatalogoMotivoCancelacion(ByVal Activo As Boolean) As DataTable
        Dim objCatalogoMotivosCancelacion As New Ventas.Datos.CatalogoMotivoCancelacionDA

        Return objCatalogoMotivosCancelacion.ListaMotivosCancelacion(Activo)
    End Function


    Public Function AltaMotivoCancelacion(ByVal objMotivoCancelacion As Entidades.CatalogoMotivoCancelacion)
        Dim objCatalogocancelacion As New Ventas.Datos.CatalogoMotivoCancelacionDA
        Dim dtRespuesta As New DataTable

        dtRespuesta = objCatalogocancelacion.AltaMotivoCancelacion(objMotivoCancelacion)
        Return dtRespuesta
    End Function



    Public Sub EditarMotivoCancelacion(ByVal objMotivoCancelacion As Entidades.CatalogoMotivoCancelacion)
        Dim objCatalogoMotivoCancelacion As New Ventas.Datos.CatalogoMotivoCancelacionDA
        objCatalogoMotivoCancelacion.EditarMotivoCancelacion(objMotivoCancelacion)
    End Sub

End Class
