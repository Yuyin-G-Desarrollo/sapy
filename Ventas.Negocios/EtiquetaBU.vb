Public Class EtiquetaBU

    Public Function ListadoTipoEtiqueta() As DataTable
        Dim EtiquetaDA As New Datos.EtiquetaDA
        Return EtiquetaDA.ListadoTipoEtiqueta()
    End Function

End Class
