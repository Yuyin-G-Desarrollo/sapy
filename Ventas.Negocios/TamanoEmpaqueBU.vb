Public Class TamanoEmpaqueBU

    Public Function ListadoTamanoEmpaque() As DataTable
        Dim TamanoEmpaqueDA As New Datos.TamanoEmpaqueDA
        Return TamanoEmpaqueDA.ListadoTamanoEmpaque()
    End Function

End Class
