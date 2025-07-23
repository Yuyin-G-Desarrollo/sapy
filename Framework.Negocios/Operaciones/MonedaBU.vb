Public Class MonedaBU

    Public Function listaMoneda() As DataTable
        Dim objDA As New Datos.MonedaDA
        Return objDA.ListaMoneda()
    End Function

End Class
