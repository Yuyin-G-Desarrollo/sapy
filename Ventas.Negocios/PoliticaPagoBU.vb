Public Class PoliticaPagoBU

    Public Sub editarPoliticaPago(ByVal PoliticaPago As Entidades.PoliticaPago, bandera As Integer)

        Dim CobranzaPoliticaPago As New Datos.PoliticaPagoDA

        CobranzaPoliticaPago.editarPoliticaPago(PoliticaPago, bandera)

    End Sub


    Public Function Datos_TablaPoliticaPago(ByVal clienteID As Integer) As DataTable
        Dim objDA As New Datos.PoliticaPagoDA
        Return objDA.Datos_TablaPoliticaPago(clienteID)
    End Function

    Public Function editarNumReferenciayConvenio(cliente As Integer, numeroRef As String, convenio As String) As DataTable
        Dim objDA As New Datos.PoliticaPagoDA
        Return objDA.editarNumReferenciayConvenio(cliente, numeroRef, convenio)
    End Function

    Public Function AltaEditarPeriodicidadCobranza(ByVal clienteId As Integer, tipoPeriodicidad As Integer, ByVal mostrarFacturas As Boolean, ByVal mostrarRemisiones As Boolean) As DataTable
        Dim objPeriodicidadDA As New Datos.PoliticaPagoDA
        Return objPeriodicidadDA.AltaEdicionPeriodicidadEnvioEstadosCuenta(clienteId, tipoPeriodicidad, mostrarFacturas, mostrarRemisiones)
    End Function

    Public Function ObtenerPeriodicidadEstadosCuenta(ByVal clienteId As Integer) As DataTable
        Dim objObtenerPeriodicidad As New Datos.PoliticaPagoDA
        Return objObtenerPeriodicidad.ObtenerPeriodicidadEnvioEstadosCuenta(clienteId)
    End Function
End Class
