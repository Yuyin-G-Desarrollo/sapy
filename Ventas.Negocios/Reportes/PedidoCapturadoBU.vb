Public Class PedidoCapturadoBU
    Public Function ConsultaPedidosCapturadosAgentes(ByVal FechaInicio As String,
                                                     ByVal FechaFin As String,
                                                     ByVal Cliente As String,
                                                     ByVal Agente As String,
                                                     ByVal Familia As String,
                                                     ByVal grpFamilia As Boolean,
                                                     ByVal grpCliente As Boolean,
                                                     ByVal grpAgente As Boolean) As DataTable

        Dim objDA As New Datos.PedidoCapturadoDA

        Return objDA.ConsultaPedidosCapturadosAgentes(FechaInicio, FechaFin, Agente, Familia, Cliente, grpFamilia, grpCliente, grpAgente)
    End Function

End Class
