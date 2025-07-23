Imports Ventas.Datos

Public Class TipoClienteBU

    Public Function ListaTiposCliente() As DataTable
        Dim da As New Datos.TipoClienteDA
        Return da.ListaTiposCliente()
    End Function

End Class
