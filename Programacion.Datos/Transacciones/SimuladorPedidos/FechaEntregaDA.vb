Public Class FechaEntregaDA
    Public Function ObtenerOpcionDate(ByVal opcion As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select opci_valor_date from programacion.opciones where opci_descripcion='" + opcion + "'"
        Return operacion.EjecutaConsulta(cadena)
    End Function
    Public Sub GuardarFechaEntrega(fecha As Date)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "UPDATE Programacion.Opciones set opci_valor_date='" & fecha.ToShortDateString & "' where opci_opciID=1"
        operacion.EjecutaConsulta(cadena)
    End Sub
End Class
