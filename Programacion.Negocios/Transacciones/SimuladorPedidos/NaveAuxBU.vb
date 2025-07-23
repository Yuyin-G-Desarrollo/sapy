Public Class NaveAuxBU

    Public Function tablaNavesAux() As DataTable
        Dim objda As New Datos.NaveAuxDA
        Return objda.tablaNavesAux
    End Function

End Class
