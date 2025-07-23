Imports Ventas.Datos

Public Class ModificacionPrecioFacturacionBU

    Public Function datosInicio() As DataTable
        Dim objDA As New ModificacionPrecioFacturacionDA
        Return objDA.datosInicio
    End Function

    Public Function guardarCambios(otorgarDenegar As Boolean, usuarioModificaId As Integer)
        Dim objDA As New ModificacionPrecioFacturacionDA
        Return objDA.guardarCambios(otorgarDenegar, usuarioModificaId)
    End Function
End Class
