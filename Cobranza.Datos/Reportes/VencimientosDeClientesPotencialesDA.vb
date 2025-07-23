Imports System.Data.SqlClient

Public Class VencimientosDeClientesPotencialesDA
    Public Function VencimientosDeClientesPotenciales(ByVal Clientes As String, ByVal fechaCorte As Date, ByVal vencido As Boolean) As DataTable
        Try
            Dim operacion As New Persistencia.OperacionesProcedimientosSICY
            Dim ListaParametros As New List(Of SqlClient.SqlParameter)
            Dim ParametroParaLista As New SqlParameter With {
                .ParameterName = "@cadena",
                .Value = Clientes
            }
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter With {
                .ParameterName = "@finDeAño",
                .Value = fechaCorte
            }
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter With {
                .ParameterName = "@vencido",
                .Value = vencido
            }
            ListaParametros.Add(ParametroParaLista)

            Return operacion.EjecutarConsultaSP("Cobranza.SP_VencimientoDeClientesPotenciales_PRUEBA", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
