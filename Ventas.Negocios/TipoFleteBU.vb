Public Class TipoFleteBU

    Public Function ListadoTipoFlete() As DataTable
        Dim TipoFleteDA As New Datos.TipoFleteDA
        Return TipoFleteDA.ListadoTipoFlete()
    End Function

End Class
