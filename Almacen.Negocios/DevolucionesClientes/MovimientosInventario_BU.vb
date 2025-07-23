Public Class MovimientosInventario_BU
    Public Function ConsultaCodigos(ByVal codigos As String) As DataTable
        Dim datos As New Datos.MovimientosInvenario_DA
        ConsultaCodigos = datos.ConsultaCodigos(codigos)
        Return ConsultaCodigos
    End Function

    Public Function ConsultaTipoMovimientos() As DataTable
        Dim datos As New Datos.MovimientosInvenario_DA
        ConsultaTipoMovimientos = datos.ConsultaTipoMovimientos()
        Return ConsultaTipoMovimientos
    End Function

    Public Sub RegistrarMovimientoInv(ByVal movimiento As Int16, ByVal pares As String, ByVal FoliosDev As String, ByVal DestinoID As Int32)
        Dim datos As New Datos.MovimientosInvenario_DA
        datos.RegistrarMovimientoInv(movimiento, pares, FoliosDev, DestinoID)
    End Sub

    Public Function ConsultaInfoDevolucion(ByVal FolioDev As Integer) As DataTable
        Dim datos As New Datos.MovimientosInvenario_DA
        ConsultaInfoDevolucion = datos.ConsultaInfoDevolucion(FolioDev)
        Return ConsultaInfoDevolucion
    End Function

End Class
