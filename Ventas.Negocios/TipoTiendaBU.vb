Public Class TipoTiendaBU

    Public Function ListadoTipoTienda() As DataTable
        Dim objDA As New Datos.TipoTiendaDA
        Return objDA.ListadoTipoTienda()
    End Function

End Class
