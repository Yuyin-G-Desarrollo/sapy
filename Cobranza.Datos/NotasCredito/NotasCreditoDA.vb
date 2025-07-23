Imports System.Data.SqlClient
Public Class NotasCreditoDA
    Public Function consultaNCPendientesTimbrar()
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Return operaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_PendientesTimbrar]", New List(Of SqlParameter))
    End Function

    Public Function validarTimbrado(ByVal IdNotaCredito As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Try
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@IdNotaCredito"
            parametro.Value = IdNotaCredito
            listaparametros.Add(parametro)

            Return operaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ValidarTimbrado]", listaparametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
