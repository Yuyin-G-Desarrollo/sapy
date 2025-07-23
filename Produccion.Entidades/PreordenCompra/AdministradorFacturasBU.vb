Imports Produccion.Datos

Public Class AdministradorFacturasBU
    Dim objDA As New AdministradorFacturasDA
    Public Function ObtenerFacturas(ByVal NaveID As Integer, ByVal ProveedorID As String, ByVal SemanaPago As Integer, ByVal AñoPago As Integer, ByVal FechaInicio As String, ByVal FechaFin As String) As DataTable
        Dim dtFacturas As New DataTable
        dtFacturas = objDA.ObtenerFacturas(NaveID, ProveedorID, SemanaPago, AñoPago, FechaInicio, FechaFin)
        Return dtFacturas
    End Function

    Public Function EnviarFacturas(ByVal Celdas As String) As DataTable
        Return objDA.EnviarFacturas(Celdas)
    End Function

    Public Function CancelarFacturas(ByVal Celdas As String) As DataTable
        Return objDA.CancelarFacturas(Celdas)
    End Function

End Class
