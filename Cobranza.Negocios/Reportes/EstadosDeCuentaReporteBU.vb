Imports Cobranza.Datos

Public Class EstadosDeCuentaReporteBU
    Public Function Combo_lista_Empresas_Say_Sicy_Contpaq() As DataTable

        Dim objDA As New EstadoDeCuentaReporteDA
        Return objDA.Combo_lista_Empresas_Say_Sicy_Contpaq()

    End Function

    Public Function consultaComboAgentesParaFamilia(ByVal colaboradorId As Integer) As DataTable
        Dim objDA As New Datos.EstadoDeCuentaReporteDA
        Dim dtAgentes As New DataTable

        dtAgentes = objDA.recuperarListaAgentesActivos(colaboradorId)
        Return dtAgentes
    End Function

    Public Function ConsultarClientesEstadosDCuentaCXC() As DataTable
        Dim objDA As New Datos.EstadoDeCuentaReporteDA
        Return objDA.SP_ConsultarClientesEstadosDCuentaCXC()
    End Function
    Public Function ConsultarReporteEstadoCuenta(fechaAnalisis As String, razonSocial As Integer, agente As Integer, cliente As Integer, vencidosAFA As Integer, vencidosEFA As Integer, todos As Integer, tipo As Integer) As DataTable
        Dim objDA As New Datos.EstadoDeCuentaReporteDA
        Return objDA.ConsultarReporteEstadoCuenta(fechaAnalisis, razonSocial, agente, cliente, vencidosAFA, vencidosEFA, todos, tipo)
    End Function

    Public Function ConsultarReporteGeneralEstadoCuenta(fechaAnalisis As String, razonSocial As Integer, agente As Integer, cliente As Integer, vencidosAFA As Integer, vencidosEFA As Integer, todos As Integer, tipo As Integer) As DataTable
        Dim objDA As New Datos.EstadoDeCuentaReporteDA
        Return objDA.ConsultarReporteGeneralEstadoCuenta(fechaAnalisis, razonSocial, agente, cliente, vencidosAFA, vencidosEFA, todos, tipo)
    End Function
    Public Function EjecutarProce_Obtener_AgenteActualporDocumento() As DataTable
        Dim objDA As New Datos.EstadoDeCuentaReporteDA
        Return objDA.EjecutarProce_Obtener_AgenteActualporDocumento()
    End Function
    Public Function consultarReporteHistoricoEstadosCuenta(ByVal clientes As String, ByVal razonSocial As String, ByVal estatus As Integer) As DataTable
        Dim objDA As New EstadoDeCuentaReporteDA
        Return objDA.ConsultarReporteHistoricoEstadosCuenta(clientes, razonSocial, estatus)
    End Function
    Public Function consultarReporteEstadosReenviar(ByVal clienteId As Integer, ByVal razonSocialId As Integer, ByVal tipo As Integer) As DataTable
        Dim objDA As New EstadoDeCuentaReporteDA
        Return objDA.ConsultaEstadosCuentaReenviar(clienteId, razonSocialId, tipo)
    End Function
    Public Function consultaCuentasDepositosCobranza(ByVal razonSocialId As Integer, ByVal tipo As Integer)
        Dim objConsultaCuentasDepositoDA As New EstadoDeCuentaReporteDA
        Dim tblCuentas As New DataTable
        tblCuentas = objConsultaCuentasDepositoDA.obtenerCuentasDepositosCobranza(razonSocialId, tipo)
        Return tblCuentas
    End Function
    Public Function insertarRegistroHistoricoEstadosdeCuenta(ByVal clienteId As Integer, ByVal empresaId As Integer, ByVal tipoDocumento As String, ByVal enviado As Boolean, ByVal email As String, ByVal mensajeError As String) As DataTable
        Dim objInsertaEstadoCta As New EstadoDeCuentaReporteDA
        Dim tblInserta As New DataTable
        tblInserta = objInsertaEstadoCta.insertarReporteHistoricoEstadosdeCuenta(clienteId, empresaId, tipoDocumento, enviado, email, mensajeError)
        Return tblInserta
    End Function
    Public Function ObtenerCorreoEnvioFallos(ByVal envioClave As String) As DataTable
        Dim objObtenerCorreo As New EstadoDeCuentaReporteDA
        Return objObtenerCorreo.obtenerCorreoEnvioFallos(envioClave)
    End Function
    Public Function obtenerDatosClienteEstadosCuenta(ByVal clienteId As Integer, ByVal empresaId As Integer, ByVal tipo As String) As DataTable
        Dim objDatosCliente As New EstadoDeCuentaReporteDA
        Return objDatosCliente.obtenerDatosClienteEstadosCuenta(clienteId, empresaId, tipo)
    End Function
End Class
