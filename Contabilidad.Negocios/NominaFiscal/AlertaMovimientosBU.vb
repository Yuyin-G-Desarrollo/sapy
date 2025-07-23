Public Class AlertaMovimientosBU
    Public Function actualizaSolicitudesRechazadas(ByVal idmovimiento As Int32, ByVal tipoMovimiento As String) As String
        Dim resultado As String = String.Empty
        Dim dtSolicitudes As New DataTable
        Dim objDa As New Datos.AlertaMovimientosDA

        dtSolicitudes = objDa.actualizaSolicitudesRechazadas(idmovimiento, tipoMovimiento)

        If dtSolicitudes.Rows.Count > 0 Then
            resultado = dtSolicitudes.Rows(0).Item("mensaje")
        End If

        Return resultado
    End Function
End Class
