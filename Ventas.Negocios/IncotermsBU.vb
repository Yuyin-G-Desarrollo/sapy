Public Class IncotermsBU

    Public Function ListadoIncoterms() As DataTable
        Dim objDA As New Datos.IncotermsDA
        Return objDA.ListadoIncoterms()
    End Function

End Class
