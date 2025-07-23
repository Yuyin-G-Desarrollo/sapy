Imports System.Data.SqlClient

Public Class AlertaMovimientosDA
    Public Function actualizaSolicitudesRechazadas(ByVal idmovimiento As Int32, ByVal tipoMovimiento As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idMovimiento"
        parametro.Value = idmovimiento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoMovimiento"
        parametro.Value = tipoMovimiento
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_AplicaCambioSolicitudesRechazadas", listaParametros)
    End Function
End Class
