Imports System.Data.SqlClient
Public Class DepositosNoIdenticadosDA

    Public Function obtenerCuentasPorRazonSocial(ByVal fechaInicio As Date, ByVal fechaFinal As Date, ByVal cuentasIdsRazonSocial As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@fechaInicio", fechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaFinal", fechaFinal)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@cuentasIds", cuentasIdsRazonSocial)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_DepositosNoIdenficados_ObtenerDepositosResumen]", listaParametros)
    End Function
    Public Function obtenerCuentasPorRazonSocial_ImprimirReporte(ByVal fechaInicio As Date, ByVal fechaFinal As Date, ByVal cuentasIdsRazonSocial As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@fechaInicio", fechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaFinal", fechaFinal)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@cuentaIds", cuentasIdsRazonSocial)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_DepositosNoIdenficados_ObtenerDepositosResumen_ImprimirReporte]", listaParametros)
    End Function
    Public Sub RegistraObservacionesCuentaNoIdentificada(ByVal observaciones As String, ByVal movimientoId As Integer)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@observaciones", observaciones)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@movimientoId", movimientoId)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_DepositosNoIdenficados_RegistraObservaciones]", listaParametros)
    End Sub
End Class
