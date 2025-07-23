Public Class UnidadVentaBU

    Public Function ListadoUnidadVenta() As DataTable
        Dim UnidadVentaDA As New Datos.UnidadVentaDA
        Return UnidadVentaDA.ListadoUnidadVenta()
    End Function

End Class
