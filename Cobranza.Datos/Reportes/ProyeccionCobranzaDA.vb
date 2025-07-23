Imports System.Data.SqlClient

Public Class ProyeccionCobranzaDA

    Public Function ObtenerDatosProyeccionCobranza(ByVal fechaInicio As Date, fechaFin As Date, ByVal ClienteID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClienteID"
        parametro.Value = ClienteID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_Obtiene_ReporteProyeccionCobranzaDetallado]", listaParametros)

    End Function
    Public Function obtenerClientes(tipo_busqueda As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@tipoBusqueda"
        parametro.Value = tipo_busqueda
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_ListadoParametrosCobranza_Clientes]", listaParametros)
    End Function

    Public Function ObtieneDescuentoPPCliente(ClienteID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@ClienteID"
        parametro.Value = ClienteID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_ObtieneDescuentosPP_ClientesProyeccionCobranza]", listaParametros)

    End Function
    Public Function obtenerRazonesSocialesEstadosDeCuenta() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_ConsultaRazonSocial_EstadosDeCuenta]", listaParametros)
    End Function
    Public Function obtenerEmisoresTrasladosCFDI() As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objOperaciones.EjecutaConsulta("[Almacen].[SP_ConsultaRazonSocial_CFDITraslados]")
    End Function
    Public Function obtenerListadoEstatusNotaCredito()
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objOperaciones.EjecutaConsulta("[Cobranza].[SP_NotasCredito_ObtieneTipoEstatus]")
    End Function
    Public Function obtenerClientesTipoNotaCredito() As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ObtenerClientesFiltro]", listaParametros)
    End Function
    Public Function obtenerRazonesSocialesFiltroNC()
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_obtenerEmpresasFiltroNC]", listaParametros)
    End Function

    Public Function obtenerEmpresas(tipo_busqueda As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@tipoBusqueda"
        parametro.Value = tipo_busqueda
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_ListadoParametrosCobranza_Empresas]", listaParametros)
    End Function

    Public Function obtenerAgentes(tipo_busqueda As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@tipoBusqueda"
        parametro.Value = tipo_busqueda
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_ListadoParametrosCobranza_Agentes]", listaParametros)
    End Function
    Public Function obtenerCuentasRazonSociales() As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        'Dim listaParametros As New List(Of SqlParameter)
        'Dim parametro As New SqlParameter

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_DepositosNoIdenficados_ObtenerCuentasRazonesSociales]", New List(Of SqlParameter))
    End Function

End Class
