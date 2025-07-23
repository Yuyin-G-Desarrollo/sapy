Public Class CatalogoEmpresasBU
    Public Function ConsultarEmpresas() As DataTable
        Dim obj As New Ventas.Datos.ConsultaEmpresasDA
        Return obj.ConsultaEmpresaDA
    End Function

End Class
