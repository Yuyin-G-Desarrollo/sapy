Public Class AdministradorComplementoRecepcionPagosBU

    Public Function consultaFiltroRFCCliente(ByVal ClienteId As String, ByVal tipoCliente As String) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorComplementoRecepcionPagosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaFiltroRFCCliente(ClienteId, tipoCliente)
        Return tabla
    End Function

    Public Function consultaFiltroRazonesSociales(ByVal tipoCte As String) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorComplementoRecepcionPagosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaFiltroRazonesSociales(tipoCte)
        Return tabla
    End Function

    Public Function consultaAdministradorPagosSinDatosFactura(ByVal Cliente As String, ByVal RFCReceptor As String, ByVal FolioFactura As String, ByVal FolioCFDI As String, ByVal RazonSocialEmisor As Integer, ByVal EstatusPago As String, ByVal EstatusCFDI As Integer, ByVal FechaGeneracionInicio As String, ByVal FechaGeneracionFin As String) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorComplementoRecepcionPagosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaAdministradorPagosSinDatosFactura(Cliente, RFCReceptor, FolioFactura, FolioCFDI, RazonSocialEmisor, EstatusPago, EstatusCFDI, FechaGeneracionInicio, FechaGeneracionFin)
        Return tabla
    End Function

    Public Function consultaAdministradorPagosConDatosFactura(ByVal Cliente As String, ByVal RFCReceptor As String, ByVal FolioFactura As String, ByVal FolioCFDI As String, ByVal RazonSocialEmisor As Integer, ByVal EstatusPago As String, ByVal EstatusCFDI As Integer, ByVal FechaGeneracionInicio As String, ByVal FechaGeneracionFin As String) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorComplementoRecepcionPagosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaAdministradorPagosConDatosFactura(Cliente, RFCReceptor, FolioFactura, FolioCFDI, RazonSocialEmisor, EstatusPago, EstatusCFDI, FechaGeneracionInicio, FechaGeneracionFin)
        Return tabla
    End Function

    Public Function consultaMotivosCancelacion() As DataTable
        Dim objDA As New Ventas.Datos.AdministradorComplementoRecepcionPagosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaMotivosCancelacion()
        Return tabla
    End Function

    Public Function consultaDatosFacturasPantallaCancelacion(ByVal ComplementoIdBuscarCancelacion As Integer) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorComplementoRecepcionPagosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaDatosFacturasPantallaCancelacion(ComplementoIdBuscarCancelacion)
        Return tabla
    End Function

    Public Function cancelarComplementoPago(ByVal ComplementoIdCancelacion As Integer, ByVal Tipo As String, ByVal Observaciones As String, ByVal MotivoCancelacionId As Integer, ByVal UsuarioCancelaId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorComplementoRecepcionPagosDA
        Dim tabla As New DataTable
        tabla = objDA.cancelarComplementoPago(ComplementoIdCancelacion, Tipo, Observaciones, MotivoCancelacionId, UsuarioCancelaId)
        Return tabla
    End Function

    Public Function descartarComplementoPago(ByVal ComplementoIdDescartar As String) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorComplementoRecepcionPagosDA
        Dim tabla As New DataTable
        tabla = objDA.descartarComplementoPago(ComplementoIdDescartar)
        Return tabla
    End Function

    Public Function generarDatosTimbrarComplemento(ByVal ComplementoIdTimbrar As Integer) As DataTable
        Try
            Dim objDA As New Ventas.Datos.AdministradorComplementoRecepcionPagosDA
            Dim tabla As New DataTable
            tabla = objDA.generarDatosTimbrarComplemento(ComplementoIdTimbrar)
            Return tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function generarDatosTimbrarVariosComplementos(ByVal ComplementosIdTimbrar As String) As DataTable
        Try
            Dim objDA As New Ventas.Datos.AdministradorComplementoRecepcionPagosDA
            Dim tabla As New DataTable
            tabla = objDA.generarDatosTimbrarVariosComplementos(ComplementosIdTimbrar)
            Return tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function generarDatosPagosInternosTimbrarVariosComplementos(ByVal ComplementosIdTimbrar As String) As DataTable
        Try
            Dim objDA As New Ventas.Datos.AdministradorComplementoRecepcionPagosDA
            Dim tabla As New DataTable
            tabla = objDA.generarDatosPagosInternosTimbrarVariosComplementos(ComplementosIdTimbrar)
            Return tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarComplementosDetallesInternosTimbrar(ByVal complementosId As String) As DataTable
        Try
            Dim objDA As New Ventas.Datos.AdministradorComplementoRecepcionPagosDA
            Dim tabla As New DataTable
            tabla = objDA.ConsultarComplementosDetallesTimbrado(complementosId)
            Return tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function consultaCorreosEnvioFactura(ByVal ClaveEnvio As String) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorComplementoRecepcionPagosDA
        Return objDA.consultaCorreosEnvioFactura(ClaveEnvio)
    End Function

    Public Function RegistraBitacoraEnvio(IdComplemento As Integer, CorreoEnviado As String, UsuarioEnvia As Integer) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorComplementoRecepcionPagosDA
        Return objDA.RegistraBitacoraEnvio(IdComplemento, CorreoEnviado, UsuarioEnvia)
    End Function

    Public Function ActualizarStatusCorreoEnviadoCRP(IdComplemento As Integer, CorreoEnviado As String, UsuarioEnvia As Integer) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorComplementoRecepcionPagosDA
        Return objDA.ActualizarStatusCorreoEnviadoCRP(IdComplemento, CorreoEnviado, UsuarioEnvia)
    End Function

    Public Function ObtenerEmpresaID(IdComplemento As Integer) As Integer
        Dim objDA As New Ventas.Datos.AdministradorComplementoRecepcionPagosDA
        Dim DtEmpresaId As DataTable
        Dim EmpresaID As Integer = 0
        DtEmpresaId = objDA.ObtenerEmpresaID(IdComplemento)

        If IsNothing(DtEmpresaId) = False Then
            EmpresaID = CInt(DtEmpresaId.Rows(0).Item(0))
        End If

        Return EmpresaID

    End Function
    Public Function obtenerTipoClientes(ByVal opcionCliente As String)
        Dim objDA As New Ventas.Datos.AdministradorComplementoRecepcionPagosDA
        Dim tabla As New DataTable
        tabla = objDA.obtenerTipoClientes(opcionCliente)
        Return tabla
    End Function
    Public Function obtenerCRPPagosInternosSinFactura(ByVal Cliente As String, ByVal RFCReceptor As String, ByVal FolioFactura As String, ByVal FolioCFDI As String, ByVal RazonSocialEmisor As Integer, ByVal EstatusPago As String, ByVal EstatusCFDI As Integer, ByVal FechaGeneracionInicio As String, ByVal FechaGeneracionFin As String) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorComplementoRecepcionPagosDA
        Dim tabla As New DataTable
        tabla = objDA.obtenerComplementosPagosInternosSinFactura(Cliente, RFCReceptor, FolioFactura, FolioCFDI, RazonSocialEmisor, EstatusPago, EstatusCFDI, FechaGeneracionInicio, FechaGeneracionFin)
        Return tabla
    End Function
    Public Function obtenerCRPPagosInternosConFacturas(ByVal Cliente As String, ByVal RFCReceptor As String, ByVal FolioFactura As String, ByVal FolioCFDI As String, ByVal RazonSocialEmisor As Integer, ByVal EstatusPago As String, ByVal EstatusCFDI As Integer, ByVal FechaGeneracionInicio As String, ByVal FechaGeneracionFin As String) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorComplementoRecepcionPagosDA
        Dim tabla As New DataTable
        tabla = objDA.obtenerComplementosPagosInternosConFactura(Cliente, RFCReceptor, FolioFactura, FolioCFDI, RazonSocialEmisor, EstatusPago, EstatusCFDI, FechaGeneracionInicio, FechaGeneracionFin)
        Return tabla
    End Function
End Class
