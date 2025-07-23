Public Class RutaBU

    Public Function ListadoRutas() As DataTable
        Dim objDA As New Datos.RutaDA
        Return objDA.ListadoRutas()
    End Function

End Class
