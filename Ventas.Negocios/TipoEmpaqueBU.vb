Public Class TipoEmpaqueBU

    Public Function ListadoTipoEmpaque() As DataTable
        Dim TipoEmpaqueDA As New Datos.TipoEmpaqueDA
        Return TipoEmpaqueDA.ListadoTipoEmpaque()
    End Function

End Class
