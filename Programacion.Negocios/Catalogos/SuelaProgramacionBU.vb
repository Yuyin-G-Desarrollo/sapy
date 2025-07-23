
Public Class SuelaProgramacionBU
    ''

    Public Function verSuelaProgramacionId(ByVal SuelaProgramacionID As Integer) As DataTable
        Dim objHormaDA As New Programacion.Datos.SuelaProgramacionDA
        Try
            Return objHormaDA.verSuelaProgramacionId(SuelaProgramacionID)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
