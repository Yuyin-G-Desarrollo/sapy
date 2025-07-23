Public Class AdministradorOTFacturacionBU

    Public Function consultaStatusCombo() As DataTable
        Dim objDA As New Ventas.Datos.AdministradorOTFacturacionDA
        Dim tabla As New DataTable
        tabla = objDA.consultaStatusCombo()
        Return tabla
    End Function

    Public Function cambiarTipoDocumento(ByVal tipoDocumento As Integer, ByVal ordennTrabajoID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorOTFacturacionDA
        objDA.cambiarTipoDocumento(tipoDocumento, ordennTrabajoID)

    End Function

    Public Function consultaAdministrador(ByVal TipoFecha As Integer, ByVal FechaInicio As String, ByVal FechaFin As String, ByVal PedidoSAY As String, ByVal PedidoSICY As String, ByVal FolioOT As String, ByVal Cliente As String, ByVal Tienda As String, ByVal StatusOT As Integer, ByVal MostrarAndrea As Integer, ByVal CEDIS As Integer) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorOTFacturacionDA
        Dim tabla As New DataTable
        tabla = objDA.consultaAdministrador(TipoFecha, FechaInicio, FechaFin, PedidoSAY, PedidoSICY, FolioOT, Cliente, Tienda, StatusOT, MostrarAndrea, CEDIS)
        Return tabla
    End Function

    Public Function rechazarOT(ByVal OrdenTrabajo As String) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorOTFacturacionDA
        Dim tabla As New DataTable
        tabla = objDA.rechazarOT(OrdenTrabajo)
        Return tabla
    End Function

    Public Function guardarSesionUsuarioFacturando(ByVal UsuarioId As Integer, ByVal ColaboradorId As Integer, ByVal UsuarioaNombre As String, ByVal TipoFacturacion As Integer, ByVal OTSeleccionadas As String) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorOTFacturacionDA
        Dim tabla As New DataTable
        tabla = objDA.guardarSesionUsuarioFacturando(UsuarioId, ColaboradorId, UsuarioaNombre, TipoFacturacion, OTSeleccionadas)
        Return tabla
    End Function

    Public Function recuperarSesionUsuarioFacturando(ByVal UsuarioId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorOTFacturacionDA
        Dim tabla As New DataTable
        tabla = objDA.recuperarSesionUsuarioFacturando(UsuarioId)
        Return tabla
    End Function

    Public Function consultarPartidasRechazarAndrea(ByVal OrdenTrabajoID As String) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorOTFacturacionDA
        Dim tabla As New DataTable
        tabla = objDA.consultarPartidasRechazarAndrea(OrdenTrabajoID)
        Return tabla
    End Function

    Public Function consultarParesPartidasRechazarAndrea(ByVal OrdenTrabajoId As String) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorOTFacturacionDA
        Dim tabla As New DataTable
        tabla = objDA.consultarParesPartidasRechazarAndrea(OrdenTrabajoId)
        Return tabla
    End Function

    Public Function rechazarPartidasAndrea(ByVal OrdenTrabajoDetalleId As String) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorOTFacturacionDA
        Dim tabla As New DataTable
        tabla = objDA.rechazarPartidasAndrea(OrdenTrabajoDetalleId)
        Return tabla
    End Function

    Public Function rechazarParesAndrea(ByVal OrdenTrabajoDetalleId As String, ByVal CodigoPar As String) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorOTFacturacionDA
        Dim tabla As New DataTable
        tabla = objDA.rechazarParesAndrea(OrdenTrabajoDetalleId, CodigoPar)
        Return tabla
    End Function

    Public Function ParesRechazadosOTs(ByVal OrdenTrabajoID As String) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorOTFacturacionDA
        Dim tabla As New DataTable
        tabla = objDA.ParesRechazadosOTs(OrdenTrabajoID)
        Return tabla
    End Function

    Public Function ValidacionClientesContado(ByVal ClienteID As Integer, ByVal OrdenTrabajoID As String) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorOTFacturacionDA
        Dim tabla As New DataTable
        tabla = objDA.ValidacionClientesContado(ClienteID, OrdenTrabajoID)
        Return tabla
    End Function

    Public Function ObtenerInfomracionCliente(ClienteID As Integer) As Entidades.Cliente
        Dim objDA As New Ventas.Datos.AdministradorOTFacturacionDA
        Dim tabla As New DataTable
        Dim entCliente As New Entidades.Cliente
        Try
            tabla = objDA.ObtenerInfomracionCliente(ClienteID)
            If tabla.Rows.Count > 0 Then
                entCliente.clienteid = tabla.Rows(0).Item("ClienteID")
                entCliente.idsicy = tabla.Rows(0).Item("ClienteID_SICY")
                entCliente.Moneda = New Entidades.Moneda
                entCliente.Moneda.monedaid = tabla.Rows(0).Item("MonedaID")
                entCliente.Moneda.nombre = tabla.Rows(0).Item("MonedaNombre")
                entCliente.nombregenerico = tabla.Rows(0).Item("NombreGenerico")
                entCliente.razonsocial = tabla.Rows(0).Item("RazonSocial")
                entCliente.TipoIVA = tabla.Rows(0).Item("TipoIVA_ID")
                entCliente.tipocliente = New Entidades.TipoCliente
                entCliente.tipocliente.tipoclienteid = tabla.Rows(0).Item("TipoClienteID")
                entCliente.tipocliente.nombre = tabla.Rows(0).Item("TipoCliente")
            End If
            Return entCliente
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Validar si las facturas de la OT estan canceladas
    ''' </summary>
    ''' <param name="OTID"></param>
    ''' <returns>false no tiene facturas pendientes, true tiene facturas pendientes.</returns>
    Public Function TieneFacturasPendientesCancelar(ByVal OTID As Integer) As Boolean
        Dim objDA As New Ventas.Datos.AdministradorOTFacturacionDA
        Dim tabla As New DataTable
        Dim Resultado As Integer = 0

        Try
            tabla = objDA.ValidaFacturasPendientesCancelar(OTID)


            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    Resultado = tabla.Rows(0).Item(0)
                End If
            End If

            If Resultado = 0 Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            Return False
        End Try


    End Function

    Public Function TieneSolocitudCancelacionActiva(ByVal tipoDocumento As Integer) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorOTFacturacionDA
        Return objDA.TieneSolocitudCancelacionActiva(tipoDocumento)
    End Function

End Class
