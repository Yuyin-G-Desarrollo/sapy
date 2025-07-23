Imports System.Data.SqlClient

Public Class MotivoExcepcionDA

    Public Function GuardarExcepcion(ByVal IdCliente As String,
                                     ByVal IdClienteDes As String,
                                     ByVal Motivo As String,
                                     ByVal Tipo As String,
                                     ByVal IdUsuario As Integer,
                                     ByVal Solicitante As String,
                                     ByVal Cliente As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter With {
            .ParameterName = "IdCliente",
            .Value = IdCliente
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "IdClienteDes",
            .Value = IdClienteDes
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "Motivo",
            .Value = Motivo
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "Tipo",
            .Value = Tipo
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "IdUsuario",
            .Value = IdUsuario
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "Solicitante",
            .Value = Solicitante
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "Cliente",
            .Value = Cliente
        }
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Facturacion_ModificaClientesExcepcion]", listaParametros)
    End Function

End Class
