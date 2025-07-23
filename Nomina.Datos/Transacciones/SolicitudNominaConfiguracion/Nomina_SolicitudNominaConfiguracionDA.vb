Imports System.Data.SqlClient

Public Class Nomina_SolicitudNominaConfiguracionDA

    Public Function ObtenerConfiguracionNomina() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_ObtieneConfiguracion_SolicitudFinanzasNomina]", listaParametros)
    End Function

    Public Function ActualizarConfiguracionNomina(Beneficiario, TipoSolicitud, PeriodoNominaIDC, NaveIDC) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Beneficiario", Beneficiario)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@TipoSolicitud", TipoSolicitud)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@PeriodoNominaID", PeriodoNominaIDC)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveID", NaveIDC)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_ActualizaDatos_SolicitudNomina]", listaParametros)

    End Function

    Public Function llenarComboTipoSolicitud() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim cadena As String
        cadena = "SELECT CSFN_Id SolicitudID, CSFN_Concepto Concepto FROM Nomina.ConfiguracionSolicitudFinanzas"
        Return objPersistencia.EjecutaConsulta(cadena)

    End Function


End Class
