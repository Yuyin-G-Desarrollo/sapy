Public Class ProveedoresBU

    Public Function ListaProveedores() As DataTable
        Dim OBJDA As New Datos.ProveedoresDA
        Dim tabla As New DataTable
        tabla = OBJDA.ListaProveedores()
        Return tabla
    End Function


End Class
