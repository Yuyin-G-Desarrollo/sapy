Public Class DiasBU


    Public Function TablaDias() As DataTable

        Dim DiasDA As New Datos.DiasDA
        Return DiasDA.TablaDias()

    End Function

End Class
