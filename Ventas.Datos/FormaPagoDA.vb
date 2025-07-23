Imports Persistencia
Imports System.Data.SqlClient

Public Class FormaPagoDA

    Public Function ListadoFormaPago() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT fopa_formapagoid, LTRIM(RTRIM(UPPER(fopa_nombre))) AS fopa_nombre, fopa_parcialidades FROM Cobranza.FormaPago WHERE fopa_activo = 1 ORDER BY fopa_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListadoFormaPago_NotaCredito() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutarConsultaSP("[Cliente].[SP_FichaTecnica_CreditoCobranza_FormaPagoNotaCredito]", New List(Of SqlParameter))
    End Function

End Class
