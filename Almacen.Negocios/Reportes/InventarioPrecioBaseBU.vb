Imports Almacen.Datos

Public Class InventarioPrecioBaseBU

    Private ReadOnly objDA As New InventarioPrecioBaseDA

    Public Function ConsultaInventario(cedis As Integer, fecha As Date) As DataTable
        Return objDA.ConsultaInventario(cedis, fecha)
    End Function

End Class
