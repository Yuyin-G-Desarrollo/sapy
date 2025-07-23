Imports Cobranza.Datos

Public Class ProyeccionCobranzaBU

    Public Function ObtenerDatosProyeccionCobranza(ByVal fechaInicio As Date, fechaFin As Date, ByVal ClienteID As String) As DataTable
        Dim objDa As New ProyeccionCobranzaDA
        Return objDa.ObtenerDatosProyeccionCobranza(fechaInicio, fechaFin, ClienteID)
    End Function

    Public Function obtenerClientes(tipo_busqueda) As DataTable
        Dim objDa As New ProyeccionCobranzaDA
        Return objDa.obtenerClientes(tipo_busqueda)
    End Function
    Public Function ObtieneDescuentoPPCliente(ClienteID As String) As DataTable
        Dim objDa As New ProyeccionCobranzaDA
        Return objDa.ObtieneDescuentoPPCliente(ClienteID)
    End Function
    Public Function obtenerRazonesSocialesEstadosDeCuenta()
        Dim objDA As New ProyeccionCobranzaDA
        Return objDA.obtenerRazonesSocialesEstadosDeCuenta
    End Function
    Public Function obtenerEmisoresTrasladosCFDI() As DataTable
        Dim objDA As New ProyeccionCobranzaDA
        Return objDA.obtenerEmisoresTrasladosCFDI
    End Function
    Public Function obtenerListadoEstatusNotaCredito() As DataTable
        Dim objDA As New ProyeccionCobranzaDA
        Return objDA.obtenerListadoEstatusNotaCredito()
    End Function
    Public Function obtenerListadoClientesNotaCredito() As DataTable
        Dim objDA As New ProyeccionCobranzaDA
        Return objDA.obtenerClientesTipoNotaCredito()
    End Function
    Public Function obtenerListadoRazonesSociales() As DataTable
        Dim objDA As New ProyeccionCobranzaDA
        Return objDA.obtenerRazonesSocialesFiltroNC
    End Function
    Public Function obtenerCuentasRazonesSociales() As DataTable
        Dim objCuentas As New ProyeccionCobranzaDA
        Return objCuentas.obtenerCuentasRazonSociales
    End Function
End Class
