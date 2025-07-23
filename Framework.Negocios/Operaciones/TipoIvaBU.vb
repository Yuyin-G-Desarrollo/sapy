Public Class TipoIvaBU

    Public Function listaTipoIVA() As DataTable
        Dim objDA As New Datos.TipoIvaDA
        Return objDA.ListaTipoIVA()
    End Function

End Class
