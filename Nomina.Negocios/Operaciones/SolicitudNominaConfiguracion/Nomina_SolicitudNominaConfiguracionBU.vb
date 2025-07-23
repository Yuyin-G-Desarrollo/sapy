Imports Nomina.Datos

Public Class Nomina_SolicitudNominaConfiguracionBU

    Public Function ObtenerConfiguracionNomina() As DataTable
        Dim objDa As New Nomina_SolicitudNominaConfiguracionDA
        Dim tablaConfiguracion As New DataTable

        tablaConfiguracion = objDa.ObtenerConfiguracionNomina()
        Return tablaConfiguracion
    End Function

    Public Function ActualizarConfiguracionNomina(Beneficiario, TipoSolicitud, PeriodoNominaIDC, NaveIDC) As DataTable
        Dim objDa As New Nomina_SolicitudNominaConfiguracionDA
        Return objDa.ActualizarConfiguracionNomina(Beneficiario, TipoSolicitud, PeriodoNominaIDC, NaveIDC)
    End Function

    Public Function llenarComboTipoSolicitud() As DataTable
        Dim objDa As New Nomina_SolicitudNominaConfiguracionDA
        Return objDa.llenarComboTipoSolicitud()
    End Function

End Class
