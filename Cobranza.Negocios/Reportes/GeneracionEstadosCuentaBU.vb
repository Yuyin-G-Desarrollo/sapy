Imports Cobranza.Datos
Public Class GeneracionEstadosCuentaBU
    Public Function obtenerRazonesSociales()
        Dim objObtenerRazonSocial As New GeneracionEstadosCuentaDA
        Return objObtenerRazonSocial.obtenerRazonesSocialesEstadosCuenta
    End Function
    Public Function obtenerClientes() As DataTable
        Dim objObtenerClientes As New GeneracionEstadosCuentaDA
        Return objObtenerClientes.obtenerClientesEstadosCuenta
    End Function
    Public Function obtenerRFCCliente(ByVal idClienteSICY As Integer) As DataTable
        Dim objConsultaRFC As New GeneracionEstadosCuentaDA
        Return objConsultaRFC.obtenerRFCCliente(idClienteSICY)
    End Function
    Public Function crearReporteEstadosCuenta(ByVal fechaAnalisis As Date, ByVal razonSocialId As Integer, ByVal clienteId As Integer, ByVal todos As Boolean, ByVal vencidosAFecha As Boolean, ByVal tipo As Integer, ByVal rfc As String) As DataTable
        Dim objConsultarReporte As New GeneracionEstadosCuentaDA
        Return objConsultarReporte.obtenerReporteEstadosdeCuenta(fechaAnalisis, razonSocialId, clienteId, todos, vencidosAFecha, tipo, rfc)
    End Function
    Public Function consultaCuentasDepositosCobranza(ByVal razonSocialId As Integer, ByVal tipo As Integer)
        Dim objConsultaCuentasDepositoDA As New GeneracionEstadosCuentaDA
        Return objConsultaCuentasDepositoDA.obtenerCuentasDepositosCobranza(razonSocialId, tipo)
    End Function
    Public Function obtenerDatosClienteEstadosCuenta(ByVal clienteId As Integer, ByVal empresaId As Integer, ByVal tipo As String) As DataTable
        Dim objDatosCliente As New GeneracionEstadosCuentaDA
        Return objDatosCliente.obtenerDatosClienteEstadosCuenta(clienteId, empresaId, tipo)
    End Function
End Class
