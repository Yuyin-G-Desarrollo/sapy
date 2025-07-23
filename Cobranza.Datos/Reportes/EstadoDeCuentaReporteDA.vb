Imports System.Data.SqlClient
Imports Entidades.Produccion
Imports Persistencia
Public Class EstadoDeCuentaReporteDA
    Public Function Combo_lista_Empresas_Say_Sicy_Contpaq() As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return operaciones.EjecutarConsultaSP("[Ventas].[SP_ObtenerRazonesSocialesFacturasActivas]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function recuperarListaAgentesActivos(ByVal colaboradorId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        'Dim consulta As String = String.Empty
        'consulta = <consulta>
        '                EXEC  [Ventas].[SP_PedidosWeb_Consulta_AgentesActivos]
        '           </consulta>.Value
        'Return objPersistencia.EjecutaConsulta(consulta)

        parametro.ParameterName = "@colaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_PedidosWeb_Consulta_AgentesActivos_v2]", listaParametros)
        'Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_PedidosWeb_Consulta_AgentesActivos]", listaParametros)


    End Function

    Public Function SP_ConsultarClientesEstadosDCuentaCXC() As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return operaciones.EjecutarConsultaSP("[Cobranza].[SP_ConsultarClientesEstadosDCuentaCXC]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarReporteEstadoCuenta(fechaAnalisis As String, razonSocial As Integer, agente As Integer, cliente As Integer, vencidosAFA As Integer, vencidosEFA As Integer, todos As Integer, tipo As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@fechaAnalisis"
            parametro.Value = fechaAnalisis
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@razonsocial"
            parametro.Value = razonSocial
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@agente"
            parametro.Value = agente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@cliente"
            parametro.Value = cliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@vencidosAFA"
            parametro.Value = vencidosAFA
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@vencidosEFA"
            parametro.Value = vencidosEFA
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@todos"
            parametro.Value = todos
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@tipo"
            parametro.Value = tipo
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_Cobranza_GenerarReporteEstadoDeCuenta]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function EjecutarProce_Obtener_AgenteActualporDocumento() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_Obtener_AgenteActualporDocumento]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarReporteGeneralEstadoCuenta(fechaAnalisis As String, razonSocial As Integer, agente As Integer, cliente As Integer, vencidosAFA As Integer, vencidosEFA As Integer, todos As Integer, tipo As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@fechaAnalisis"
            parametro.Value = fechaAnalisis
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@razonsocial"
            parametro.Value = razonSocial
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@agente"
            parametro.Value = agente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@cliente"
            parametro.Value = cliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@vencidosAFA"
            parametro.Value = vencidosAFA
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@vencidosEFA"
            parametro.Value = vencidosEFA
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@todos"
            parametro.Value = todos
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@tipo"
            parametro.Value = tipo
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_Cobranza_GenerarReporteEstadoDeCuentaPorCliente]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarReporteHistoricoEstadosCuenta(ByVal cliente As String, ByVal razonSocial As String, ByVal estatus As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing
        Try
            parametro = New SqlParameter("@cliente", cliente)
            listaParametros.Add(parametro)

            parametro = New SqlParameter("@razonsocial", razonSocial)
            listaParametros.Add(parametro)

            parametro = New SqlParameter("@estatus", estatus)
            listaParametros.Add(parametro)

            Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_ConsultarHistorico_EnvioEstadosDeCuenta]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultaEstadosCuentaReenviar(ByVal clienteId As Integer, ByVal razonSocialId As Integer, ByVal tipo As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing
        Try
            parametro = New SqlParameter("@clienteId", clienteId)
            listaParametros.Add(parametro)

            parametro = New SqlParameter("@razonsocialId", razonSocialId)
            listaParametros.Add(parametro)

            parametro = New SqlParameter("@tipo", tipo)
            listaParametros.Add(parametro)

            Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_Cobranza_ObtenerEstadoDeCuentaEnviar]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
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
    Public Function insertarReporteHistoricoEstadosdeCuenta(ByVal clienteId As Integer, ByVal empresaId As Integer, ByVal tipoDocumento As String,
                                                            ByVal enviado As Boolean, ByVal email As String, ByVal mensajeError As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@clienteId", clienteId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@empresaId", empresaId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipoDocumento", tipoDocumento)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaEnvio", DateTime.Now)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@email", email)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@enviado", enviado)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@errorenvio", mensajeError)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@usuarioenvia", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_RegistrarHistorico_EnvioEstadosDeCuenta]", listaParametros)
    End Function
    Public Function obtenerCorreoEnvioFallos(ByVal envioClave As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@envioClave", envioClave)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_ObtenerCorreoDestinatario_NotificacionFallos]", listaParametros)
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
