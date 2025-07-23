Public Class ProtectorFlejeBU

    Public Function ListadoProtectorFleje() As DataTable
        Dim ProtectorFlejeDA As New Datos.ProtectorFlejeDA
        Return ProtectorFlejeDA.ListadoProtectorFleje()
    End Function

End Class
