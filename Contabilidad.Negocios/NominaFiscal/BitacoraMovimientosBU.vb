Public Class BitacoraMovimientosBU
    Public Function consultarBitacoraMovimientos(ByVal NaveId As Integer, ByVal EmpresaId As Integer, ByVal TipoMovimiento As Integer, ByVal PeriodoId As Integer, ByVal FechaInicial As Date, ByVal FechaFinal As Date) As DataTable
        Dim objDA As New Datos.BitacoraMovimientosDA
        Return objDA.consultarBitacoraMovimientos(NaveId, EmpresaId, TipoMovimiento, PeriodoId, FechaInicial, FechaFinal)

    End Function
    Public Function obtieneDestinosCorreo(ByVal patronid As Integer) As String
        Dim objDA As New Datos.BitacoraMovimientosDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDA.obtieneDestinosCorreo(patronid)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("destinos").ToString
        End If
        Return resultado
    End Function

End Class
