Imports Cobranza.Datos
Public Class DepositosNoIdentificadosBU
    Public Function obtenerResumenCuentasRazonSocial(ByVal fechaInicio As Date, ByVal fechaFinal As Date, ByVal cuentasIdsRazonSocial As String) As DataTable
        Dim objResumen As New DepositosNoIdenticadosDA
        Return objResumen.obtenerCuentasPorRazonSocial(fechaInicio, fechaFinal, cuentasIdsRazonSocial)
    End Function
    Public Function obtenerResumenCuentasRazonSocial_ImprimirReporte(ByVal fechaInicio As Date, ByVal fechaFinal As Date, ByVal cuentasIdsRazonSocial As String) As DataTable
        Dim objResumen As New DepositosNoIdenticadosDA
        Return objResumen.obtenerCuentasPorRazonSocial_ImprimirReporte(fechaInicio, fechaFinal, cuentasIdsRazonSocial)
    End Function
    Public Sub registraObservaciones(ByVal observaciones As String, ByVal movimientoId As Integer)
        Dim objObservaciones As New DepositosNoIdenticadosDA
        objObservaciones.RegistraObservacionesCuentaNoIdentificada(observaciones, movimientoId)
    End Sub
End Class
