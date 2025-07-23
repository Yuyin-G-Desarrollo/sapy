Public Class TipoFlejeBU

    Public Function ListadoTipoFleje() As DataTable
        Dim TipoFlejeDA As New Datos.TipoFlejeDA
        Return TipoFlejeDA.ListadoTipoFleje()
    End Function

End Class
