Public Class EmpresasBU

    Public Function listaEmpresas() As DataTable
        Dim objDA As New Datos.EmpresasDA
        Return objDA.ListaEmpresas()
    End Function

End Class
