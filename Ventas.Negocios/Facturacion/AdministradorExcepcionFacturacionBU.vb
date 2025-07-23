Public Class AdministradorExcepcionFacturacionBU

    Public Function ListadoClientes() As DataTable
        Dim objDA As New Datos.AdministradorExcepcionFacturacionDA
        Return objDA.ListadoClientes()
    End Function

    Public Function ListadoClientesSinRegistro() As DataTable
        Dim objDA As New Datos.AdministradorExcepcionFacturacionDA
        Return objDA.ListadoClientesSinRegistro()
    End Function

End Class
