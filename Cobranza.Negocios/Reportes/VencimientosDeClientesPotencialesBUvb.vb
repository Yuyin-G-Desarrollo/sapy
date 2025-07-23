Public Class VencimientosDeClientesPotencialesBU
    Public Function VencimientosDeClientesPotenciales(ByVal Clientes As String, ByVal fechaCorte As Date, ByVal vencido As Boolean) As DataTable
        Try
            Dim objDA As New Cobranza.Datos.VencimientosDeClientesPotencialesDA
            Return objDA.VencimientosDeClientesPotenciales(Clientes, fechaCorte, vencido)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
