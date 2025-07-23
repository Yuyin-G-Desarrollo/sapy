Imports System.Data.SqlClient
Imports Entidades

Public Class NotaCreditoDevolucionesDA
    Public Function obtenerRazonesSociales() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_RazonesSociales]", listaParametros)
    End Function
    Public Function obtenerConceptosNotaCredito(ByVal NCDevoluciones As NotasCreditoDevoluciones) As DataTable

        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@tipoNC", NCDevoluciones.NotaCreditoConcepto)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_TiposConcepto]", listaParametros)
    End Function
    Public Function obtenerTipoMoneda() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_TipoMoneda]", listaParametros)
    End Function
    Public Function obtenerClientesTipoNotaCredito(ByVal NCDevoluciones As NotasCreditoDevoluciones) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@tipoNotaCredito", NCDevoluciones.NotaCreditoTipo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@razonsocialId", NCDevoluciones.NotaCreditoRazSocialId)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_Clientes]", listaParametros)
    End Function
    Public Function obtenerDescuentoCXC(ByVal NCDevoluciones As NotasCreditoDevoluciones) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@cadenaId", NCDevoluciones.NotaCreditoClienteId)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_DescuentoCxC]", listaParametros)
    End Function
    Public Function obtenerRFCClientes(ByVal NCDevoluciones As NotasCreditoDevoluciones) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@cadenaId", NCDevoluciones.NotaCreditoClienteId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipoNotaCredito", NCDevoluciones.NotaCreditoTipo)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ClientesRFC]", listaParametros)
    End Function
    Public Function obtenerMonedaRFCCliente(ByVal NCDevoluciones As NotasCreditoDevoluciones) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@clienteRFCId", NCDevoluciones.NotaCreditoRFCClienteId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@anio", NCDevoluciones.NotaCreditoAnio)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_TipoMonedaRFC]", listaParametros)
    End Function
    Public Function obtenerDocumentosRazonSocial(ByVal NCDevoluciones As NotasCreditoDevoluciones) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@documentoId", NCDevoluciones.NotaCreditoRazSocialId)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_DocumentoFiscal]", listaParametros)
    End Function
    Public Function obtenerUltimoFolio(ByVal NCDevoluciones As NotasCreditoDevoluciones) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@certificadoId", NCDevoluciones.NotaCreditoCertificadoId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@serie", NCDevoluciones.NotaCreditoSerie)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_UltimoFolio]", listaParametros)
    End Function
    Public Function obtenerVentasCliente(ByVal NCVentasCliente As NotasCreditoDevoluciones, ByVal facturasIds As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@clienteId", NCVentasCliente.NotaCreditoRFCClienteId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@empresaId", NCVentasCliente.NotaCreditoRazSocialId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipoNotaCredito", NCVentasCliente.NotaCreditoTipo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@facturas", facturasIds)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ConsultaVentasClientes]", listaParametros)
    End Function
    Public Function obtenerIdRazonSocial(ByVal NotaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@razonSocial", NotaCredito.NotaCreditoRazonSocial)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ObtenerIdRazonsSocial]", listaParametros)
    End Function
    Public Function obtenerDetallesDevolucionesNotaCredito(ByVal NCDetalles As NotasCreditoDevoluciones, ByVal sessionId As Integer, ByVal factura As String, ByVal filaNueva As Boolean) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@razonSocialId", NCDetalles.NotaCreditoRazSocialId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@clienteId", NCDetalles.NotaCreditoClienteId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Session", sessionId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Factura", factura)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@docNuevo", filaNueva)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ConsultarDetallesDevoluciones]", listaParametros)
    End Function
    Public Function obtenerIdCliente(ByVal NotaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@nombreCliente", NotaCredito.NotaCreditoCliente)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ObtenerIdClienteSAY]", listaParametros)
    End Function
    Public Function ConsultaTotalNC(ByVal NotaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@precioDevolucion", NotaCredito.NotaCreditoPrecioDevolucion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@clienteId", NotaCredito.NotaCreditoClienteId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipoNC", NotaCredito.NotaCreditoTipo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@totalParesAAplicar", NotaCredito.NotaCreditoParesAplicar)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito _ObtenerTotalNC]", listaParametros)
    End Function
    Public Sub insertarFolioDocuementoTblWork(ByVal NotaCredito As NotasCreditoDevoluciones)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@tipoBusqueda", NotaCredito.NotaCreditoBusqueda)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@usuarioId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@folioDocumento", NotaCredito.NotaCreditoFolio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@documento", NotaCredito.NotaCredtioDocumento)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@notaCreditoId", NotaCredito.NotaCreditoId)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarSentenciaSP("[Work].[dbo].[SP_NotasCredito_ValidarSessionUsuario]", listaParametros)
    End Sub
    Public Sub limpiarTblWorkSesiones()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        objPersistencia.EjecutarSentenciaSP("[Work].[dbo].[SP_NotasCredito_LimpiaSesionesActivas]", listaParametros)
    End Sub
    Public Function obtenerSessionesActivas(ByVal NotaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@tipoBusqueda", NotaCredito.NotaCreditoBusqueda)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@usuarioId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@folioDocumento", NotaCredito.NotaCreditoFolio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@documento", NotaCredito.NotaCredtioDocumento)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@devolucionId", NotaCredito.NotaCreditoDevolucionId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@notaCreditoId", NotaCredito.NotaCreditoId)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Work].[dbo].[SP_NotasCredito_RecuperarSessionesActivasUsuarios]", listaParametros)
    End Function
    Public Sub InsertaFoliosDevolucionesSesionUsuario(ByVal NotaCredito As NotasCreditoDevoluciones)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@folioDevolucion", NotaCredito.NotaCreditoFolio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@usuarioId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarSentenciaSP("[Work].[dbo].[SP_NotasCredito_InsertaFoliosDevoluciones]", listaParametros)
    End Sub
    Public Function obtenerSessionActivaFolioDevolucion(ByVal NotaCredito As NotasCreditoDevoluciones)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@folioDevolucion", NotaCredito.NotaCreditoFolio)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Work].[dbo].[SP_NotasCredito_ConsultaFoliosDevolucionesSessionActiva]", listaParametros)
    End Function
    Public Sub limpiaSessionesActivasFoliosDev()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        objPersistencia.EjecutarSentenciaSP("[Work].[dbo].[SP_NotasCredito_LimpiaSesionesActivaFoliosDevoluciones]", listaParametros)
    End Sub
    Public Function InsertarEncabezadoNotaCredito(ByVal notaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@tipoNC", notaCredito.NotaCreditoTipo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@razonSocialemisorId", notaCredito.NotaCreditoRazSocialId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipoConcepto", notaCredito.NotaCreditoConcepto)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@clienteSAYId", notaCredito.NotaCreditoClienteId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@rfcClienteSAYId", notaCredito.NotaCreditoRFCClienteId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@usuarioId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@subtotal", notaCredito.NotaCreditoSubtotal)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@descuento", notaCredito.NotaCreditoDescuento)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@iva", notaCredito.NotaCreditoIvaTotal)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@total", notaCredito.NotaCreditoTotal)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@estatus", notaCredito.NotaCreditoEstatus)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@formaPago", notaCredito.NotaCreditoFormaPago)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@metodoPago", notaCredito.NotaCreditoMetodoPago)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@monedaId", notaCredito.NotaCreditoMonedaId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@rfccliente", notaCredito.NotaCreditoRFCCliente)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@clienteIdSicy", notaCredito.NotaCreditoClienteId_SICY)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_InsertaNotasCredito]", listaParametros)
    End Function
    Public Sub InsertaDetallesNotaCredito(ByVal vXmlCeldasDetalles As String)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@vXmlCeldasDetalles", vXmlCeldasDetalles)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_InsertaDetallesNotasCredito]", listaParametros)
    End Sub
    Public Function InsertarFacturaNotaCredito(ByVal notaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@notaCreditoId", notaCredito.NotaCreditoId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@anio", notaCredito.NotaCreditoAnio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipoDocumento", notaCredito.NotaCreditoTipo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@clienteId", notaCredito.NotaCreditoClienteId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@rfcClienteId", notaCredito.NotaCreditoRFCClienteId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@razonSocialId", notaCredito.NotaCreditoRazSocialId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@usuarioId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@monedaId", notaCredito.NotaCreditoMonedaId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@paresFacturados", notaCredito.NotaCreditoParesFacturados)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@subtotal", notaCredito.NotaCreditoSubtotal)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@iva", notaCredito.NotaCreditoIvaTotal)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@total", notaCredito.NotaCreditoTotal)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@metodoPago", notaCredito.NotaCreditoMetodoPago)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@formaPago", notaCredito.NotaCreditoFormaPago)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@rfccliente", notaCredito.NotaCreditoRFCCliente)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_InsertarFactura]", listaParametros)
    End Function
    Public Sub insertaDetallesFacturaNotaCredito(ByVal vXmlCeldasFacturaDetalles As String)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@vXmlCeldasFacturaDetalles", vXmlCeldasFacturaDetalles)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_InsertarFacturaDetalles]", listaParametros)
    End Sub
    Public Function obtenerDetallesDevolcionesRemisiones(ByVal notaCredito As NotasCreditoDevoluciones, ByVal sessionId As Integer, ByVal remisionId As Integer, ByVal filaNueva As Boolean) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@clienteId", notaCredito.NotaCreditoClienteId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Session", notaCredito.NotaCreditoClienteId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@remisionId", notaCredito.NotaCreditoClienteId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@filaNueva", notaCredito.NotaCreditoClienteId)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ConsultarDetallesDevolucionesRemisiones]", listaParametros)
    End Function
    Public Sub actualizaSaldoFactura(ByVal notaCredito As NotasCreditoDevoluciones)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@saldo", notaCredito.NotaCreditoSaldoFactura)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@anio", notaCredito.NotaCreditoAnio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@folio", notaCredito.NotaCreditoRemisionId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@importe", notaCredito.NotaCreditoImporte)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ActualizaSaldoFactura]", listaParametros)
    End Sub
    Public Function CargaInformacionDelDiaNotasCredito() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ConsultarNotasCreditoDiaActual]", listaParametros)
    End Function
    Public Function obtenerDetallesNotasCredito(ByVal notaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@notaCreditoId", notaCredito.NotaCreditoId)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ConsultarDetalles]", listaParametros)
    End Function
    Public Function generaInformacionTimbradoNotasCredito(ByVal notaCredito As NotasCreditoDevoluciones) As DataTable
        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter("@documentoId", notaCredito.NotaCreditoId)
            listaParametros.Add(parametro)

            parametro = New SqlParameter("@nombreCliente", notaCredito.NotaCreditoRFCCliente)
            listaParametros.Add(parametro)

            parametro = New SqlParameter("@rfcClienteId", notaCredito.NotaCreditoRFCClienteId)
            listaParametros.Add(parametro)

            Return ObjPersistencia.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_GeneraInformacionTimbrar]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizaDatosTimbrado(ByVal notaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@notaCreditoId", notaCredito.NotaCreditoId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Sello", notaCredito.NotaCreditoSello)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Uuid", notaCredito.NotaCreditoUUID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@UsuarioTimbroId", notaCredito.NotaCreditoUsuarioTimbro)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaTimbrado", notaCredito.NotaCreditoFechaTimbrado)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@VersionSat", notaCredito.NotaCreditoVersionSAT)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@RfcProvCertif", notaCredito.NotaCreditoRFCProvCertif)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NoCertificadoSAT", notaCredito.NotaCreditoNoCertificadoSAT)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@SelloSAT", notaCredito.NotaCreditoSelloSAT)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@CadenaOriginal", notaCredito.NotaCreditoCadenaOriginal)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ActualizaInformacionFacturaNotaCredito]", listaParametros)
    End Function
    Public Function obtenerEncabezadoDetallesNC(ByVal notaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@documentoId", notaCredito.NotaCreditoId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@nombreCliente", notaCredito.NotaCreditoCliente)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipoNC", notaCredito.NotaCreditoTipo)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ConsultaEncabezadoDetalle]", listaParametros)
    End Function
    Public Function obtenerRutasTimbradoXMLPDF(ByVal notaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@documentoId", notaCredito.NotaCreditoId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipoComprobante", notaCredito.NotaCreditoConcepto)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@archivo", notaCredito.NotaCreditoTipo)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ObtenerRutas_Timbrado]", listaParametros)
    End Function
    Public Function consultarAdmninistradorNotaCredito(ByVal FechaInicio As Date, ByVal FechaFinal As Date, ByVal EmisorIds As String, ByVal ReceptorIds As String, ByVal EstatusIds As String, ByVal FoliosIds As String, clientesIds As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@FechaInicio", FechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", FechaFinal)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@EmisorIds", EmisorIds)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ReceptorIds", ReceptorIds)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@EstatusIds", EstatusIds)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FoliosIds", FoliosIds)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@clientesIds", clientesIds)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ReporteAcumuladoAdministrador]", listaParametros)
    End Function
    Public Function consultarAdmistradorNotaCreditoDetallado(ByVal FechaInicio As Date, ByVal FechaFinal As Date, ByVal EmisorIds As String, ByVal ReceptorIds As String, ByVal EstatusIds As String, ByVal FoliosIds As String, clientesIds As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@FechaInicio", FechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", FechaFinal)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@EmisorIds", EmisorIds)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ReceptorIds", ReceptorIds)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@EstatusIds", EstatusIds)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FoliosIds", FoliosIds)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@clientesIds", clientesIds)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ReporteDetalladoAdministrador]", listaParametros)
    End Function
    Public Function consultarAdnistradorConTipoNC(ByVal FechaInicio As Date, ByVal FechaFinal As Date, ByVal EmisorIds As String, ByVal ReceptorIds As String, ByVal EstatusIds As String, ByVal FoliosIds As String, clientesIds As String, ByVal tipoNC As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@FechaInicio", FechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", FechaFinal)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@EmisorIds", EmisorIds)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ReceptorIds", ReceptorIds)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@EstatusIds", EstatusIds)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FoliosIds", FoliosIds)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@clientesIds", clientesIds)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipoNC", tipoNC)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ReporteAcumuladoAdministradorTipoNC]", listaParametros)
    End Function
    Public Function consultarAdministradorDetalladoConTipoNC(ByVal FechaInicio As Date, ByVal FechaFinal As Date, ByVal EmisorIds As String, ByVal ReceptorIds As String, ByVal EstatusIds As String, ByVal FoliosIds As String, clientesIds As String, ByVal tipoNC As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@FechaInicio", FechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", FechaFinal)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@EmisorIds", EmisorIds)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ReceptorIds", ReceptorIds)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@EstatusIds", EstatusIds)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FoliosIds", FoliosIds)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@clientesIds", clientesIds)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipoNC", tipoNC)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ReporteDetalladoAdministradorTipoNC]", listaParametros)
    End Function
    Public Function consultarCorreosRemitentes()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ConsultaCorreos_Envio]", listaParametros)
    End Function
    Public Sub insertaBitacoraRegistrosEnviosCorreos(ByVal documentoId As Integer, ByVal correoEnviado As String)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@notacreditoId", documentoId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@enviado", correoEnviado)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@usuarioenvio", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarSentenciaSP("[Cobranza].[SP_NotaCredito_RegistraBitacoraEnviosCorreos]", listaParametros)
    End Sub
    Public Sub actualizaEstadoEnvioCorreo(ByVal documentoId As Integer)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@documentoId", documentoId)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarSentenciaSP("[Cobranza].[SP_NotasCredito_ActualizaEstadoEnvioCorreo]", listaParametros)
    End Sub
    Public Function ConsultarMotivosCancelacionNotaCredito() As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ConsultaMotivosCancelacion]", listaParametros)
    End Function
    Public Function consultaCatalogoMotivosCancelacion(ByVal tipoActivo As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@tipoActivo", tipoActivo)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ConsultaCatalogo_MotivosCancelacion]", listaParametros)
    End Function
    Public Function obtenerDatosCancelacionFactura(ByVal notaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@documentoId", notaCredito.NotaCreditoId)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ObtenerDatosCancelacion]", listaParametros)
    End Function
    Public Sub registraNuevoMotivoCancelacion(ByVal descripcionMotivo As String, ByVal activo As Boolean, ByVal motivoId As Integer)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@descripcionMotivo", descripcionMotivo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@usuarioCreo", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@activo", activo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@motivoId", motivoId)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarSentenciaSP("[Cobranza].[SP_NotasCredito_RegistraNuevo_MotivoCancelacion]", listaParametros)
    End Sub
    Public Function obtenerMotivoCancelacionEdicion(ByVal motivoId As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@motivoId", motivoId)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_RecuperaMotivo_Edicion]", listaParametros)
    End Function
    Public Sub activaDesactivaMotivoCancelacion(ByVal motivoId As Integer, ByVal activo As Boolean)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@motivoId", motivoId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@activo", activo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@usuarioModifica", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarSentenciaSP("[Cobranza].[SP_NotasCredito_ActivaDesactiva_MotivoCancelacion]", listaParametros)
    End Sub
    Public Function obtenerParesDevueltosParaCancelar(ByVal documentoId As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@documentoId", documentoId)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ConsultarParesDevoluciones_ParaCancelar]", listaParametros)
    End Function
    Public Sub CancelarParesDevueltos(ByVal notaCredito As NotasCreditoDevoluciones)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@detalleDevolucionId", notaCredito.NotaCreditoDetalleDevolucionId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@folioDevolucion", notaCredito.NotaCreditoFolio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@cantidad", notaCredito.NotaCreditoParesAplicar)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@productoEstiloId", notaCredito.NotaCreditoProductoEstiloId)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarSentenciaSP("[Cobranza].[SP_NotasCredito_CancelarParesDevueltos]", listaParametros)
    End Sub
    Public Function obtenerCorreoFacturacionEnviar(ByVal documentoId As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@documentoId", documentoId)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito _ConsultarCorreoFacturacionEnviar]", listaParametros)
    End Function
    Public Function obtenerEncabezadoRemision_PDF(ByVal documentoId As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@documentoId", documentoId)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito _ConsultaEncabezadoRemision_GenerarPDF]", listaParametros)
    End Function
    Public Function obtenerDetallesRemision_PDF(ByVal documentoId As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@documentoId", documentoId)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito _ConsultaDetallesRemision_GenerarPDF]", listaParametros)
    End Function
    Public Function obtenerNotaCreditoGeneradaEnelDia(ByVal notacreditoId As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@notacreditoId", notacreditoId)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito _ConsultarNotaCredito_Generada]", listaParametros)
    End Function
    Public Function obtenerClientesFuncionF1(ByVal tipoNC As String, ByVal razonSocialId As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@tipoNotaCredito", tipoNC)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@razonsocialId", razonSocialId)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_Clientes]", listaParametros)
    End Function

    Public Function CrearSesionUsuario(clienteID As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@UsuarioID", SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Usuario", SesionUsuario.UsuarioSesion.PUserUsername)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ClienteID", clienteID)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_Insertar_CrearSesionUsuario]", listaParametros)
    End Function

    Public Function ConsultaSesionUsuario(clienteID As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@UsuarioID", SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ClienteID", clienteID)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_Consulta_ConsultaSesionUsuario]", listaParametros)
    End Function

    Public Sub EliminarSesionUsuario(clienteID As Integer, ByVal sessionId As Integer)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@UsuarioID", SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ClienteID", clienteID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@SessionId", sessionId)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_Eliminar_EliminarSesionUsuario]", listaParametros)
    End Sub
    Public Sub insertaDatosDetallesSesionUsuario(ByVal idsesion As Integer, ByVal devolucionId As String, ByVal paresaplicados As Integer, ByVal folio As String, ByVal precio As Decimal, ByVal productoestilo As String, ByVal porcentaje As Decimal, ByVal clavesat As String, ByVal descripcion As String, ByVal subtotal As Decimal, ByVal iva As Decimal, ByVal total As Decimal, ByVal detalleFolioId As Integer, ByVal documento As Integer, ByVal anio As Integer)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@idsesion", idsesion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@devolucion", devolucionId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@paresaplicados", paresaplicados)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@folio", folio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@precio", precio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@productoestilo", productoestilo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@porcentaje", porcentaje)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@clavesat", clavesat)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@descripcion", descripcion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@subtotal", subtotal)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@iva", iva)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@totalNC", total)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@detalleId", detalleFolioId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@documento", documento)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@anio", anio)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito _InsertaDatosSesionDetalles]", listaParametros)
    End Sub
    Public Function consultarDetallesSessionUsuario(ByVal sesionId As Integer, ByVal Documentos As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@sessionId", sesionId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@folio", Documentos)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito _ConsultaDetallesSessionUsuario]", listaParametros)
    End Function
    Public Function consultarFoliosActivosDetalles(ByVal sesionId As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@sesionId", sesionId)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito _ConsultaFoliosActivos_SessionUsuario]", listaParametros)
    End Function
    Public Sub eliminarFilaSessionDocumento(ByVal sesionId As Integer, ByVal detalleIddevolucion As String, ByVal factura As String, ByVal tipoNC As String, ByVal remisionId As Integer)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@SessionId", sesionId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@detalleId", detalleIddevolucion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@factura", factura)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipoNC", tipoNC)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@remisionId", remisionId)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_EliminarSesionFolioFila]", listaParametros)
    End Sub
    Public Function obtenerDetallesSesionesDevolucione(ByVal sesionId As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@sessionId", sesionId)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito _ConsultaDetalles_Devoluciones]", listaParametros)
    End Function
    Public Sub actualziarDetallesParModificado(ByVal sessionId As Integer, ByVal detalleId As String, ByVal subtotal As Decimal, ByVal iva As Decimal, ByVal total As Decimal, ByVal parActualizado As Integer)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@sesionId", sessionId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@factura", detalleId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@subtotal", subtotal)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@iva", iva)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@total", total)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@par", parActualizado)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito _ActualizaTotalesDetallesSesionUsuario]", listaParametros)
    End Sub
    Public Sub actualizaParSessionDetalle(ByVal sesionid As Integer, ByVal factura As String, ByVal subtotal As Decimal, ByVal iva As Decimal, ByVal total As Decimal, ByVal par As Integer, ByVal detalleid As Integer, ByVal folioDev As String, ByVal precip As Decimal, productoestilo As String, ByVal porcentaje As Decimal, ByVal clavesat As String, ByVal descripcion As String, ByVal documentoId As Integer, ByVal anio As Integer)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@sesionId", sesionid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@factura", factura)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@subtotal", subtotal)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@iva", iva)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@total", total)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@par", par)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@detalleId", detalleid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@folioDev", folioDev)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@precio", precip)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@productoestilo", productoestilo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@porcentaje", porcentaje)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@clavesat", clavesat)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@descripcion", descripcion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@documento", documentoId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@anio", anio)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito _ActualizaParesSessionDetalles]", listaParametros)
    End Sub
    Public Sub ReplicaNotasCreditoSAY_SICY(ByVal notaCredito As NotasCreditoDevoluciones)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@notacreditoID", notaCredito.NotaCreditoId)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito _Replica_SAYSICY]", listaParametros)
    End Sub
    Public Sub ActualizaParAplicado(ByVal paraplicado As Integer, ByVal folioDev As Integer, ByVal productoEstilo As Integer, ByVal detalleIdDevolucion As Integer)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@parAplicado", paraplicado)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@folioDev", folioDev)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@productoEstilo", productoEstilo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@detalleDevolucionId", detalleIdDevolucion)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ActualizaParesAplicados]", listaParametros)
    End Sub
End Class
