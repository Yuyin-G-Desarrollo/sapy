Public Class TipoValorBU

    Public Function ListadoTipoValor() As DataTable
        Dim TipoValorDA As New Datos.TipoValorDA
        Return TipoValorDA.ListadoTipoValor()
    End Function

End Class
