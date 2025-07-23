Imports System.Data.SqlClient

Public Class CorteNominaFiscalDA
    Public Function consultaCorteNomina(ByVal periodoId As Int32, ByVal patronid As Int32, ByVal nombre As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametro As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronid"
        parametro.Value = patronid
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "periodoid"
        parametro.Value = periodoId
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaborador"
        parametro.Value = nombre
        listaParametro.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFCierre_ConsultaCorteNomina", listaParametro)
    End Function

    Public Function datosEmpresa(ByVal periodoId As Int32, ByVal patronid As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametro As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronid"
        parametro.Value = patronid
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "periodoid"
        parametro.Value = periodoId
        listaParametro.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFCierre_ConsultaDatosEmpresa", listaParametro)
    End Function

    Public Function obtnerTotalNominaFiscal(ByVal idPeriodoReal As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametro As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "idPeriodoReal"
        parametro.Value = idPeriodoReal
        listaParametro.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFCierre_ConsultaTotalNominaFiscal", listaParametro)
    End Function

    Public Function validaTimbreFiscalesCompletos(ByVal idPeriodo As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametro As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "peridoId"
        parametro.Value = idPeriodo
        listaParametro.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFCierre_ValidaTimbresFiscales", listaParametro)
    End Function

    Public Function obtenerConfiguracionPatron(ByVal patronId As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametro As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametro.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFCierre_ConsultaConfiguracionPatron", listaParametro)
    End Function
End Class
