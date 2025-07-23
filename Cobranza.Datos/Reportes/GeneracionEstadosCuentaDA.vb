Imports System.Data.SqlClient
Public Class GeneracionEstadosCuentaDA
    Public Function obtenerRazonesSocialesEstadosCuenta() As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objOperaciones.EjecutaConsulta("[Ventas].[SP_ObtenerRazonesSocialesFacturasActivas]")
    End Function
    Public Function obtenerClientesEstadosCuenta() As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_ConsultarClientesEstadosDCuentaCXC]", listaParametros)
    End Function
    Public Function obtenerRFCCliente(ByVal idClienteSICY As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@clienteSicyId", idClienteSICY)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_EstadosDeCuenta_ObtenerRFCClientes]", listaParametros)
    End Function
    Public Function obtenerReporteEstadosdeCuenta(ByVal fechaAnalisis As Date, ByVal razonSocialId As Integer, ByVal clienteId As Integer, ByVal todos As Boolean, ByVal vencidosAFecha As Boolean, ByVal tipo As Integer, ByVal rfc As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@fechaAnalisis", fechaAnalisis)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@razonSocialId", razonSocialId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@clienteId", clienteId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@todos", todos)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@vencidosAFecha", vencidosAFecha)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipo", tipo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@razonSocialCliente", rfc)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_Cobranza_GeneraInformacionEstadosDeCuenta]", listaParametros)
    End Function
    Public Function obtenerCuentasDepositosCobranza(ByVal razonSocialId As Integer, ByVal tipo As Integer)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@razonsocialid", razonSocialId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipo", tipo)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_Cobranza_EstadosDeCuenta_ObtenerCuentasDeposito]", listaParametros)
    End Function
    Public Function obtenerDatosClienteEstadosCuenta(ByVal clienteId As Integer, ByVal empresaId As Integer, ByVal tipo As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@clienteId", clienteId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@empresaId", empresaId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipo", tipo)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_Cobranza_EstadosDeCuenta_ObtenerDatosCliente]", listaParametros)
    End Function
End Class
