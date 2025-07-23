Public Class ReporteResumenClienteBU

    Public Function ObtenerTiposReportes() As DataTable

        Dim objDA As New Datos.ReporteResumenClienteDA

        Return objDA.ObtenerTiposReportes()
    End Function

    Public Function ConsultaSessionCliente(ByVal Año As String,
                                           ByVal Cliente As String,
                                           ByVal Usuario As Integer,
                                           ByVal TipoCalendario As Integer) As DataTable

        Dim objDA As New Datos.ReporteResumenClienteDA

        Return objDA.ConsultaSessionCliente(Año, Cliente, Usuario, TipoCalendario)
    End Function

    Public Function ConsultaHistoricoVenta(ByVal SessionID As Integer, ByVal TipoCalendario As Integer) As DataTable

        Dim objDA As New Datos.ReporteResumenClienteDA

        Return objDA.ConsultaHistoricoVenta(SessionID, TipoCalendario)
    End Function

    Public Function ConsultaProyeccionVenta(ByVal SessionID As Integer, ByVal TipoCalendario As Integer) As DataTable

        Dim objDA As New Datos.ReporteResumenClienteDA

        Return objDA.ConsultaProyeccionVenta(SessionID, TipoCalendario)
    End Function

    Public Function ConsultaComparativoFamilia(ByVal SessionID As Integer) As DataTable

        Dim objDA As New Datos.ReporteResumenClienteDA

        Return objDA.ConsultaComparativoFamilia(SessionID)
    End Function

    Public Sub BorrarSession(ByVal SessionID As Integer)

        Dim objDA As New Datos.ReporteResumenClienteDA

        objDA.BorrarSession(SessionID)

    End Sub

    Public Function ConsultaHistoricoVentaCliente(ByVal SessionID As Integer, ByVal ClienteID As Integer) As DataTable

        Dim objDA As New Datos.ReporteResumenClienteDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.ConsultaHistoricoVentaCliente(SessionID, ClienteID)

        Return dtResultado
    End Function
    Public Function CumplimientoVentaCliente(ByVal SessionID As Integer, ByVal ClienteID As Integer) As DataTable
        Dim objDA As New Datos.ReporteResumenClienteDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.CumplimientoVentaCliente(SessionID, ClienteID)

        Return dtResultado
    End Function

    Public Function ComparativoFamiliaCliente(ByVal SessionID As Integer, ByVal ClienteID As Integer) As DataTable
        Dim objDA As New Datos.ReporteResumenClienteDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.ComparativoFamiliaCliente(SessionID, ClienteID)

        Return dtResultado
    End Function

    Public Function EncabezadoReporte(ByVal SessionID As Integer, ByVal ClienteID As Integer) As DataTable
        Dim objDA As New Datos.ReporteResumenClienteDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.EncabezadoReporte(SessionID, ClienteID)

        Return dtResultado
    End Function

    Public Function ConsultarClientesImpresionReporte(ByVal SessionID As Integer) As DataTable
        Dim objDA As New Datos.ReporteResumenClienteDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.ConsultarClientesImpresionReporte(SessionID)

        Return dtResultado
    End Function

    Public Function ConsultarTiendasMarcaje(ByVal ClienteID As String) As DataTable

        Dim objDA As New Datos.ReporteResumenClienteDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.ConsultarTiendasMarcaje(ClienteID)

        Return dtResultado
    End Function

End Class
