Imports System.Data.SqlClient

Public Class AdministradorComplementoRecepcionPagosDA

    Public Function consultaFiltroRFCCliente(ByVal ClienteId As String, ByVal tipoCliente As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ClienteId"
        parametro.Value = ClienteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoCliente"
        parametro.Value = tipoCliente
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_AdministradorComplementoPagos_ConsultaFiltroRFC", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function consultaFiltroRazonesSociales(ByVal tipoCte As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "tipoCrpCliente"
        parametro.Value = tipoCte
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_AdministradorComplementoPagos_ConsultaFiltroRazonesSociales]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function consultaAdministradorPagosSinDatosFactura(ByVal Cliente As String, ByVal RFCReceptor As String, ByVal FolioFactura As String, ByVal FolioCFDI As String, ByVal RazonSocialEmisor As Integer, ByVal EstatusPago As String, ByVal EstatusCFDI As Integer, ByVal FechaGeneracionInicio As String, ByVal FechaGeneracionFin As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Cliente"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RFCReceptor"
        parametro.Value = RFCReceptor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioFactura"
        parametro.Value = FolioFactura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioCFDI"
        parametro.Value = FolioCFDI
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RazonSocialEmisor"
        parametro.Value = RazonSocialEmisor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EstatusPago"
        parametro.Value = EstatusPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EstatusCFDI"
        parametro.Value = EstatusCFDI
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaGeneracionInicio"
        parametro.Value = FechaGeneracionInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaGeneracionFin"
        parametro.Value = FechaGeneracionFin
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ConsultaAdministradorComplementoPagos_SinDatosFacturas", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function consultaAdministradorPagosConDatosFactura(ByVal Cliente As String, ByVal RFCReceptor As String, ByVal FolioFactura As String, ByVal FolioCFDI As String, ByVal RazonSocialEmisor As Integer, ByVal EstatusPago As String, ByVal EstatusCFDI As Integer, ByVal FechaGeneracionInicio As String, ByVal FechaGeneracionFin As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Cliente"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RFCReceptor"
        parametro.Value = RFCReceptor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioFactura"
        parametro.Value = FolioFactura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioCFDI"
        parametro.Value = FolioCFDI
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RazonSocialEmisor"
        parametro.Value = RazonSocialEmisor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EstatusPago"
        parametro.Value = EstatusPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EstatusCFDI"
        parametro.Value = EstatusCFDI
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaGeneracionInicio"
        parametro.Value = FechaGeneracionInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaGeneracionFin"
        parametro.Value = FechaGeneracionFin
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ConsultaAdministradorComplementoPagos_ConDatosFacturas", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function consultaMotivosCancelacion() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        dtResultadoConsulta = objPersistencia.EjecutaConsulta("EXEC Ventas.SP_AdministradorComplementoPagos_ConsultaMotivosCancelacion")

        Return dtResultadoConsulta

    End Function

    Public Function consultaDatosFacturasPantallaCancelacion(ByVal ComplementoIdBuscarCancelacion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ComplementoIdBuscarCancelacion"
        parametro.Value = ComplementoIdBuscarCancelacion
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ConsultaComplementoPagos_DatosFacturasParaCancelacion", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function cancelarComplementoPago(ByVal ComplementoIdCancelacion As Integer, ByVal Tipo As String, ByVal Observaciones As String, ByVal MotivoCancelacionId As Integer, ByVal UsuarioCancelaId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "complementoid"
        parametro.Value = ComplementoIdCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipo"
        parametro.Value = Tipo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "observaciones"
        parametro.Value = Observaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "motivoid"
        parametro.Value = MotivoCancelacionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuario"
        parametro.Value = UsuarioCancelaId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("dbo.SPR_CANCELACION_COMPLEMENTO", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function descartarComplementoPago(ByVal ComplementoIdDescartar As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "complementoid"
        parametro.Value = ComplementoIdDescartar
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_AdministradorComplementoPagos_DescartarCRP", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function generarDatosTimbrarComplemento(ByVal ComplementoIdTimbrar As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "complementoid"
        parametro.Value = ComplementoIdTimbrar
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_ComplementoPago_GeneraDatosTimbrado]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function generarDatosTimbrarVariosComplementos(ByVal ComplementosIdTimbrar As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "complementosids"
        parametro.Value = ComplementosIdTimbrar
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_ComplementoPago_GeneraDatosTimbrado_VariosComplementos]", listaParametros)

        Return dtResultadoConsulta

    End Function
    Public Function generarDatosPagosInternosTimbrarVariosComplementos(ByVal ComplementosIdTimbrar As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "complementosid"
        parametro.Value = ComplementosIdTimbrar
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_ComplementoPagoClientesInternos_GeneraDatosTimbrado_VariosComplementos]", listaParametros)

        Return dtResultadoConsulta
    End Function
    Public Function ConsultarComplementosDetallesTimbrado(ByVal complementosId As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "complementosid"
        parametro.Value = complementosId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_ConsultarDetallesComplementosInternos_Timbrado]", listaParametros)

        Return dtResultadoConsulta
    End Function
    Public Function consultaCorreosEnvioFactura(ByVal ClaveEnvio As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ClaveEnvio"
        parametro.Value = ClaveEnvio
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ConsultaDatosCorreosFacturacion", listaParametros)

    End Function
    Public Function ActualizarStatusCorreoEnviadoCRP(IdComplemento As Integer, CorreoEnviado As String, UsuarioEnvia As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdComplemento"
        parametro.Value = IdComplemento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Enviado"
        parametro.Value = If(CorreoEnviado = "N", 0, 1)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdUsuarioEnvia"
        parametro.Value = UsuarioEnvia
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_ComplementosPago_ActualizarBitEnvio]", listaParametros)

    End Function
    Public Function RegistraBitacoraEnvio(IdComplemento As Integer, CorreoEnviado As String, UsuarioEnvia As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdComplemento"
        parametro.Value = IdComplemento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Enviado"
        parametro.Value = CorreoEnviado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdUsuarioEnvia"
        parametro.Value = UsuarioEnvia
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_ComplementosPago_ActualizarBitacoraEnvios]", listaParametros)

    End Function

    Public Function ObtenerEmpresaID(IdComplemento As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@complementoPagoId"
        parametro.Value = IdComplemento
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_ComplementoPago_ObtenerEmpresaID]", listaParametros)

    End Function

    Public Function obtenerTipoClientes(ByVal opcionCliente As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "opcionCte"
        parametro.Value = opcionCliente
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_ObtenerTextoClientes]", listaParametros)

    End Function
    Public Function obtenerComplementosPagosInternosSinFactura(ByVal Cliente As String, ByVal RFCReceptor As String, ByVal FolioFactura As String, ByVal FolioCFDI As String, ByVal RazonSocialEmisor As Integer, ByVal EstatusPago As String, ByVal EstatusCFDI As Integer, ByVal FechaGeneracionInicio As String, ByVal FechaGeneracionFin As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Cliente"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RFCReceptor"
        parametro.Value = RFCReceptor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioFactura"
        parametro.Value = FolioFactura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioCFDI"
        parametro.Value = FolioCFDI
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RazonSocialEmisor"
        parametro.Value = RazonSocialEmisor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EstatusPago"
        parametro.Value = EstatusPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EstatusCFDI"
        parametro.Value = EstatusCFDI
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaGeneracionInicio"
        parametro.Value = FechaGeneracionInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaGeneracionFin"
        parametro.Value = FechaGeneracionFin
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_ConsultaComplementosPagos_ClientesInternosSinDatosFactura]", listaParametros)

        Return dtResultadoConsulta
    End Function
    Public Function obtenerComplementosPagosInternosConFactura(ByVal Cliente As String, ByVal RFCReceptor As String, ByVal FolioFactura As String, ByVal FolioCFDI As String, ByVal RazonSocialEmisor As Integer, ByVal EstatusPago As String, ByVal EstatusCFDI As Integer, ByVal FechaGeneracionInicio As String, ByVal FechaGeneracionFin As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Cliente"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RFCReceptor"
        parametro.Value = RFCReceptor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioFactura"
        parametro.Value = FolioFactura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioCFDI"
        parametro.Value = FolioCFDI
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RazonSocialEmisor"
        parametro.Value = RazonSocialEmisor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EstatusPago"
        parametro.Value = EstatusPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EstatusCFDI"
        parametro.Value = EstatusCFDI
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaGeneracionInicio"
        parametro.Value = FechaGeneracionInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaGeneracionFin"
        parametro.Value = FechaGeneracionFin
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_ConsultaComplementosPagos_ClientesInternosConDatosFactura]", listaParametros)
        Return dtResultadoConsulta
    End Function
End Class
