Imports System.Data.SqlClient

Public Class PedidoCapturadoDA

    Public Function ConsultaPedidosCapturadosAgentes(ByVal FechaInicio As String,
                                                     ByVal FechaFin As String,
                                                     ByVal Agente As String,
                                                     ByVal Familia As String,
                                                     ByVal Cliente As String,
                                                     ByVal grpFamilia As Boolean,
                                                     ByVal grpCliente As Boolean,
                                                     ByVal grpAgente As Boolean) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClientesIDSay"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgentesIDSay"
        parametro.Value = Agente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FamiliasIDSay"
        parametro.Value = Familia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "grpFamilia"
        parametro.Value = grpFamilia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "grpCliente"
        parametro.Value = grpCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "grpAgente"
        parametro.Value = grpAgente
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Ventas_Consulta_PedidosCapturadosAgentes]", listaParametros)

    End Function

End Class
