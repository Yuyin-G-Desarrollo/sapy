Imports System.Data.SqlClient
Imports Persistencia

Public Class BitacoraMovimientosDA
    Public Function consultarBitacoraMovimientos(ByVal NaveId As Integer, ByVal EmpresaId As Integer, ByVal TipoMovimiento As Integer, ByVal PeriodoId As Integer, ByVal FechaInicial As Date, ByVal FechaFinal As Date) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = NaveId
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@EmpresaId"
        parametro.Value = EmpresaId
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@TipoMovimiento"
        parametro.Value = TipoMovimiento
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@PeriodoId"
        parametro.Value = PeriodoId
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@FechaInicial"
        parametro.Value = FechaInicial
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@FechaFinal"
        parametro.Value = FechaFinal
        ListaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_NF_BitacoraMovimientos_Consultar]", ListaParametros)
    End Function

    Public Function obtieneDestinosCorreo(ByVal patronId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametro As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@patronid"
        parametro.Value = patronId
        listaParametro.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[Contabilidad].[SP_NF_BitacoraMovimientos_obtenerCorreos]", listaParametro)
    End Function

End Class
