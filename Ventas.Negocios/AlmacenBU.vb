Public Class AlmacenBU

    Public Function ListadoAlmacen() As DataTable
        Dim AlmacenDA As New Datos.AlmacenDA
        Return AlmacenDA.ListadoAlmacen()
    End Function

End Class
