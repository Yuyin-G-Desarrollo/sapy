Imports Persistencia
Imports System.Data.SqlClient
Public Class AtrasosDA
    Public Function ListaMotivosAtraso() As DataTable
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String =<cadena>
        SELECT
	    Motivo,
	    0.0 AS 'Corte',
	    0.0 AS 'Pespunte',
	    0.0 AS 'Montado y Adorno'
        FROM MotivoAtrasosProduccion
        WHERE departamento IN ('COR')
        </cadena>.Value
        Return operaciones.EjecutaConsulta(consulta)
    End Function
End Class
