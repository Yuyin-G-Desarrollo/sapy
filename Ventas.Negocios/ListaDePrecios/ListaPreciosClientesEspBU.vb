Public Class ListaPreciosClientesEspBU

    Public Function buscarClientesNombreComercial(ByVal ClienteID As Integer) As DataTable
        Dim objDA As New Datos.ListaPreciosClientesEspDA
        Return objDA.buscarClientesNombreComercial(ClienteID)
    End Function

End Class
