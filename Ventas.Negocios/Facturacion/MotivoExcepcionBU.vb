Public Class MotivoExcepcionBU

    Public Function GuardarExcepcion(ByVal IdCliente As String,
                                     ByVal IdClienteDes As String,
                                     ByVal Motivo As String,
                                     ByVal Tipo As String,
                                     ByVal IdUsuario As Integer,
                                     ByVal Solicitante As String,
                                     ByVal Cliente As String) As DataTable
        Dim objDA As New Datos.MotivoExcepcionDA
        Return objDA.GuardarExcepcion(IdCliente, IdClienteDes, Motivo, Tipo, IdUsuario, Solicitante, Cliente)
    End Function

End Class
