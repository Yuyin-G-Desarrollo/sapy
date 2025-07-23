
Imports Cobranza.Datos
Imports Entidades

Public Class NotaCreditoDevolucionesBU
    Public Function obtenerRazonesSociales() As DataTable
        Dim objRazSociales As New NotaCreditoDevolucionesDA
        Return objRazSociales.obtenerRazonesSociales
    End Function
    Public Function obtenerConceptos(ByVal NCDevoluciones As NotasCreditoDevoluciones) As DataTable
        Dim objConceptos As New NotaCreditoDevolucionesDA
        Return objConceptos.obtenerConceptosNotaCredito(NCDevoluciones)
    End Function
    Public Function obtenerTipoMoneda() As DataTable
        Dim objTipoMoneda As New NotaCreditoDevolucionesDA
        Return objTipoMoneda.obtenerTipoMoneda
    End Function
    Public Function obtenerClientes(ByVal NCDevoluciones As NotasCreditoDevoluciones) As DataTable
        Dim objCtesNC As New NotaCreditoDevolucionesDA
        Return objCtesNC.obtenerClientesTipoNotaCredito(NCDevoluciones)
    End Function
    Public Function obtenerDescuentoCxC(ByVal NCDevoluciones As NotasCreditoDevoluciones) As DataTable
        Dim objDescuento As New NotaCreditoDevolucionesDA
        Return objDescuento.obtenerDescuentoCXC(NCDevoluciones)
    End Function
    Public Function obtenerRFCClientes(ByVal NCDevoluciones As NotasCreditoDevoluciones) As DataTable
        Dim objRFC As New NotaCreditoDevolucionesDA
        Return objRFC.obtenerRFCClientes(NCDevoluciones)
    End Function
    Public Function obtenerTipoMonedaRFC(ByVal NCDevoluciones As NotasCreditoDevoluciones) As DataTable
        Dim objTipoMoneda As New NotaCreditoDevolucionesDA
        Return objTipoMoneda.obtenerMonedaRFCCliente(NCDevoluciones)
    End Function
    Public Function obtenerDocumentosRazonSocial(ByVal NCDevoluciones As NotasCreditoDevoluciones) As DataTable
        Dim objDocumentos As New NotaCreditoDevolucionesDA
        Return objDocumentos.obtenerDocumentosRazonSocial(NCDevoluciones)
    End Function
    Public Function obtenerUltimoFolio(ByVal NCDevoluciones As NotasCreditoDevoluciones) As DataTable
        Dim objUltimoFolio As New NotaCreditoDevolucionesDA
        Return objUltimoFolio.obtenerUltimoFolio(NCDevoluciones)
    End Function
    Public Function obtenerVentasCliente(ByVal NCVentasCliente As NotasCreditoDevoluciones, ByVal facturasIds As String) As DataTable
        Dim objVentaCliente As New NotaCreditoDevolucionesDA
        Return objVentaCliente.obtenerVentasCliente(NCVentasCliente, facturasIds)
    End Function
    Public Function obtenerIdRazonSocial(ByVal NotaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objIdRazonSocial As New NotaCreditoDevolucionesDA
        Return objIdRazonSocial.obtenerIdRazonSocial(NotaCredito)
    End Function
    Public Function obtenerDetallesDevoluciones(ByVal NCDetalles As NotasCreditoDevoluciones, ByVal sessionId As Integer, ByVal factura As String, ByVal nuevaFila As Boolean) As DataTable
        Dim objDetallesDevolucion As New NotaCreditoDevolucionesDA
        Return objDetallesDevolucion.obtenerDetallesDevolucionesNotaCredito(NCDetalles, sessionId, factura, nuevaFila)
    End Function
    Public Function obtenerIdCliente(ByVal NotaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objIdRazonSocial As New NotaCreditoDevolucionesDA
        Return objIdRazonSocial.obtenerIdCliente(NotaCredito)
    End Function
    Public Function obtenerTotalNC(ByVal NotaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objTotalNC As New NotaCreditoDevolucionesDA
        Return objTotalNC.ConsultaTotalNC(NotaCredito)
    End Function
    Public Sub insertarTblWork(ByVal NotaCredito As NotasCreditoDevoluciones)
        Dim objInsertarTblWork As New NotaCreditoDevolucionesDA
        objInsertarTblWork.insertarFolioDocuementoTblWork(NotaCredito)
    End Sub
    Public Sub LimpiarTblWorkSesiones()
        Dim objLimpiar As New NotaCreditoDevolucionesDA
        objLimpiar.limpiarTblWorkSesiones()
    End Sub
    Public Function obtenerSessionActiva(ByVal NotaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objSessionActiva As New NotaCreditoDevolucionesDA
        Return objSessionActiva.obtenerSessionesActivas(NotaCredito)
    End Function
    Public Sub InsertaFoliosDevolucionSessionUsuario(ByVal NotaCredito As NotasCreditoDevoluciones)
        Dim objFolioDevolucion As New NotaCreditoDevolucionesDA
        objFolioDevolucion.InsertaFoliosDevolucionesSesionUsuario(NotaCredito)
    End Sub
    Public Function obtenerSessionActivaFolioDevolucion(ByVal NotaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objSessionFolioDev As New NotaCreditoDevolucionesDA
        Return objSessionFolioDev.obtenerSessionActivaFolioDevolucion(NotaCredito)
    End Function
    Public Sub LimpiaSessionesActivasFoliosDev()
        Dim objLimpiaFoliosDev As New NotaCreditoDevolucionesDA
        objLimpiaFoliosDev.limpiaSessionesActivasFoliosDev()
    End Sub
    Public Function insertaEncabezadoNotaCredito(ByVal NotaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objInsertarNC As New NotaCreditoDevolucionesDA
        Return objInsertarNC.InsertarEncabezadoNotaCredito(NotaCredito)
    End Function
    Public Sub insertaDetallesNotaCredito(ByVal vXmlCeldasDetalles As String)
        Dim objInsertaDetalles As New NotaCreditoDevolucionesDA
        objInsertaDetalles.InsertaDetallesNotaCredito(vXmlCeldasDetalles)
    End Sub
    Public Function InsertarFacturarNotaCredito(ByVal NotaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objFacturaNC As New NotaCreditoDevolucionesDA
        Return objFacturaNC.InsertarFacturaNotaCredito(NotaCredito)
    End Function
    Public Sub insertaDetallesFacturaNotaCredito(ByVal vXmlCeldasFacturaDetalles As String)
        Dim objInsertaDetallesFactura As New NotaCreditoDevolucionesDA
        objInsertaDetallesFactura.insertaDetallesFacturaNotaCredito(vXmlCeldasFacturaDetalles)
    End Sub
    Public Function obtenerDetallesDevolucionesRemisiones(ByVal NotaCredito As NotasCreditoDevoluciones, ByVal sessionId As Integer, ByVal remisionId As Integer, ByVal nuevaFila As Boolean) As DataTable
        Dim objDetallesDEvRemisiones As New NotaCreditoDevolucionesDA
        Return objDetallesDEvRemisiones.obtenerDetallesDevolcionesRemisiones(NotaCredito, sessionId, remisionId, nuevaFila)
    End Function
    Public Sub actualizaSaldoFactura(ByVal NotaCredito As NotasCreditoDevoluciones)
        Dim objActualizaSaldo As New NotaCreditoDevolucionesDA
        objActualizaSaldo.actualizaSaldoFactura(NotaCredito)
    End Sub
    Public Function cargaInformacionDelDiaNotasCredito()
        Dim objNotasCreditoDelDia As New NotaCreditoDevolucionesDA
        Return objNotasCreditoDelDia.CargaInformacionDelDiaNotasCredito
    End Function
    Public Function obtenerDetallesNotaCredito(ByVal NotaCredito As NotasCreditoDevoluciones)
        Dim objDettales As New NotaCreditoDevolucionesDA
        Return objDettales.obtenerDetallesNotasCredito(NotaCredito)
    End Function
    Public Function generaInformacionTimbrado(ByVal NotaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objTimbrado As New NotaCreditoDevolucionesDA
        Return objTimbrado.generaInformacionTimbradoNotasCredito(NotaCredito)
    End Function
    Public Function actualizaInformacionFacturacion(ByVal NotaCredito As NotasCreditoDevoluciones)
        Dim objTimbrado As New NotaCreditoDevolucionesDA
        Return objTimbrado.actualizaDatosTimbrado(NotaCredito)
    End Function
    Public Function obtenerEncabezadoDetallesNC(ByVal NotaCredito As NotasCreditoDevoluciones)
        Dim objEncabezado As New NotaCreditoDevolucionesDA
        Return objEncabezado.obtenerEncabezadoDetallesNC(NotaCredito)
    End Function
    Public Function obtenerRutasTimbradoXMLPDF(ByVal NotaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objRutas As New NotaCreditoDevolucionesDA
        Return objRutas.obtenerRutasTimbradoXMLPDF(NotaCredito)
    End Function
    Public Function consultarAdministrador(ByVal fechaInicio As String, ByVal fechaFin As String, ByVal emisorIds As String, ByVal receptorIds As String, ByVal estatusIds As String, ByVal folios As String, ByVal clientesIds As String) As DataTable
        Dim objAdministrador As New NotaCreditoDevolucionesDA
        Return objAdministrador.consultarAdmninistradorNotaCredito(fechaInicio, fechaFin, emisorIds, receptorIds, estatusIds, folios, clientesIds)
    End Function
    Public Function consultarAdministradorDetallado(ByVal fechaInicio As String, ByVal fechaFin As String, ByVal emisorIds As String, ByVal receptorIds As String, ByVal estatusIds As String, ByVal folios As String, ByVal clientesIds As String) As DataTable
        Dim objAdmonNC As New NotaCreditoDevolucionesDA
        Return objAdmonNC.consultarAdmistradorNotaCreditoDetallado(fechaInicio, fechaFin, emisorIds, receptorIds, estatusIds, folios, clientesIds)
    End Function
    Public Function consultarAdministradorConTipoNC(ByVal fechaInicio As String, ByVal fechaFin As String, ByVal emisorIds As String, ByVal receptorIds As String, ByVal estatusIds As String, ByVal folios As String, ByVal clientesIds As String, ByVal tipoNc As String) As DataTable
        Dim objAdministrador As New NotaCreditoDevolucionesDA
        Return objAdministrador.consultarAdnistradorConTipoNC(fechaInicio, fechaFin, emisorIds, receptorIds, estatusIds, folios, clientesIds, tipoNc)
    End Function
    Public Function consultarAdministradorDetalladoConTipoNC(ByVal fechaInicio As String, ByVal fechaFin As String, ByVal emisorIds As String, ByVal receptorIds As String, ByVal estatusIds As String, ByVal folios As String, ByVal clientesIds As String, ByVal tipoNc As String) As DataTable
        Dim objAdministradorDetallado As New NotaCreditoDevolucionesDA
        Return objAdministradorDetallado.consultarAdministradorDetalladoConTipoNC(fechaInicio, fechaFin, emisorIds, receptorIds, estatusIds, folios, clientesIds, tipoNc)
    End Function
    Public Function consultarCorreosRemitentes()
        Dim objCorreos As New NotaCreditoDevolucionesDA
        Return objCorreos.consultarCorreosRemitentes
    End Function
    Public Sub registraBitacoraEnvioCorreos(ByVal documentoId As Integer, ByVal correoEnviado As String)
        Dim objBitacora As New NotaCreditoDevolucionesDA
        objBitacora.insertaBitacoraRegistrosEnviosCorreos(documentoId, correoEnviado)
    End Sub
    Public Sub actualizaEstadoEnviosCorreos(ByVal documentoId As Integer)
        Dim objActualiza As New NotaCreditoDevolucionesDA
        objActualiza.actualizaEstadoEnvioCorreo(documentoId)
    End Sub
    Public Function consultarMotivosCancelacion() As DataTable
        Dim objMotivos As New NotaCreditoDevolucionesDA
        Return objMotivos.ConsultarMotivosCancelacionNotaCredito
    End Function
    Public Function consultaCatalogoMotivosCancelacion(ByVal tipoActivo As Boolean) As DataTable
        Dim objCatalogo As New NotaCreditoDevolucionesDA
        Return objCatalogo.consultaCatalogoMotivosCancelacion(tipoActivo)
    End Function
    Public Function obtenerDatosFacturacionCancelacion(ByVal NotaCredito As NotasCreditoDevoluciones) As DataTable
        Dim objDatosCancelacion As New NotaCreditoDevolucionesDA
        Return objDatosCancelacion.obtenerDatosCancelacionFactura(NotaCredito)
    End Function
    Public Sub insertaNuevoMotivoCancelacion(ByVal descripcionMotivo As String, ByVal activo As Boolean, ByVal motivoId As Integer)
        Dim objNuevoMotivo As New NotaCreditoDevolucionesDA
        objNuevoMotivo.registraNuevoMotivoCancelacion(descripcionMotivo, activo, motivoId)
    End Sub
    Public Function obtenerMotivoCancelacionEdicion(ByVal motivoId As Integer) As DataTable
        Dim objMotivo As New NotaCreditoDevolucionesDA
        Return objMotivo.obtenerMotivoCancelacionEdicion(motivoId)
    End Function
    Public Sub activaDesactivarMotivoCancelacion(ByVal motivoId As Integer, ByVal activo As Boolean)
        Dim objActivaDesactiva As New NotaCreditoDevolucionesDA
        objActivaDesactiva.activaDesactivaMotivoCancelacion(motivoId, activo)
    End Sub
    Public Function obtenerParesDevueltosParaCancelar(ByVal documentoId As Integer) As DataTable
        Dim objParesCancelados As New NotaCreditoDevolucionesDA
        Return objParesCancelados.obtenerParesDevueltosParaCancelar(documentoId)
    End Function
    Public Sub cancelarParesDevoluciones(ByVal NotaCredito As NotasCreditoDevoluciones)
        Dim objCancelarPares As New NotaCreditoDevolucionesDA
        objCancelarPares.CancelarParesDevueltos(NotaCredito)
    End Sub
    Public Function consultarCorreoFacturacionEnviar(ByVal documentoId As Integer) As DataTable
        Dim objCorreoEnviar As New NotaCreditoDevolucionesDA
        Return objCorreoEnviar.obtenerCorreoFacturacionEnviar(documentoId)
    End Function
    Public Function obtenerEncabezadoRemision_PDF(ByVal documentoId As Integer) As DataTable
        Dim objEncabezado As New NotaCreditoDevolucionesDA
        Return objEncabezado.obtenerEncabezadoRemision_PDF(documentoId)
    End Function
    Public Function obtenerDetallesRemision_PDF(ByVal documentoId As Integer) As DataTable
        Dim objDetalles As New NotaCreditoDevolucionesDA
        Return objDetalles.obtenerDetallesRemision_PDF(documentoId)
    End Function
    Public Function obtenerNotaCreditoGeneradaEnElDia(ByVal notacreditoId As Integer) As DataTable
        Dim NCGeneradaDia As New NotaCreditoDevolucionesDA
        Return NCGeneradaDia.obtenerNotaCreditoGeneradaEnelDia(notacreditoId)
    End Function
    Public Function obtenerClientesFuncionF1(ByVal tipoNC As String, ByVal razonSocialId As Integer) As DataTable
        Dim objClientesF1 As New NotaCreditoDevolucionesDA
        Return objClientesF1.obtenerClientesFuncionF1(tipoNC, razonSocialId)
    End Function

    Public Function CrearSesionUsuario(clienteID As Integer) As DataTable
        Dim objClientesF1 As New NotaCreditoDevolucionesDA
        Return objClientesF1.CrearSesionUsuario(clienteID)
    End Function

    Public Function ConsultaSesionUsuario(clienteID As Integer) As DataTable
        Dim objClientesF1 As New NotaCreditoDevolucionesDA
        Return objClientesF1.ConsultaSesionUsuario(clienteID)
    End Function

    Public Sub EliminarSesionUsuario(clienteID As Integer, ByVal sessionId As Integer)
        Dim objClientesF1 As New NotaCreditoDevolucionesDA
        objClientesF1.EliminarSesionUsuario(clienteID, sessionId)
    End Sub
    Public Sub insertaSesionDetallesUsuario(ByVal idsesion As Integer, ByVal devolucionId As String, ByVal paresaplicados As Integer, ByVal folio As String, ByVal precio As Decimal, ByVal productoestilo As String, ByVal porcentaje As Decimal, ByVal clavesat As String, ByVal descripcion As String, ByVal subtotal As Decimal, ByVal iva As Decimal, ByVal total As Decimal, ByVal detalleFolioId As Integer, ByVal documento As Integer, ByVal anio As Integer)
        Dim objInsertaDetalles As New NotaCreditoDevolucionesDA
        objInsertaDetalles.insertaDatosDetallesSesionUsuario(idsesion, devolucionId, paresaplicados, folio, precio, productoestilo, porcentaje, clavesat, descripcion, subtotal, iva, total, detalleFolioId, documento, anio)
    End Sub
    Public Function consultarDetallesSessionUsuario(ByVal sesionId As Integer, ByVal documento As String) As DataTable
        Dim objDetalles As New NotaCreditoDevolucionesDA
        Return objDetalles.consultarDetallesSessionUsuario(sesionId, documento)
    End Function
    Public Function consultarFoliosDetallesActivos(ByVal sesionId As Integer)
        Dim objFolios As New NotaCreditoDevolucionesDA
        Return objFolios.consultarFoliosActivosDetalles(sesionId)
    End Function
    Public Sub eliminarFilaDetalleDevolucion(ByVal sesionId As Integer, ByVal detalleId As String, ByVal factura As String, ByVal tipoNC As String, ByVal remisionId As Integer)
        Dim objEliminarFila As New NotaCreditoDevolucionesDA
        objEliminarFila.eliminarFilaSessionDocumento(sesionId, detalleId, factura, tipoNC, remisionId)
    End Sub
    Public Function obtenerDetallesSesionesDevoluciones(ByVal sesionId As Integer) As DataTable
        Dim objDetalles As New NotaCreditoDevolucionesDA
        Return objDetalles.obtenerDetallesSesionesDevolucione(sesionId)
    End Function
    Public Sub actualizarDetallesParModificado(ByVal sessionId As Integer, ByVal detalleId As String, ByVal subtotal As Decimal, ByVal iva As Decimal, ByVal total As Decimal, ByVal parActualizado As Integer)
        Dim objActualizar As New NotaCreditoDevolucionesDA
        objActualizar.actualziarDetallesParModificado(sessionId, detalleId, subtotal, iva, total, parActualizado)
    End Sub
    Public Sub actualizaParSessionDetalle(ByVal sesionid As Integer, ByVal factura As String, ByVal subtotal As Decimal, ByVal iva As Decimal, ByVal total As Decimal, ByVal par As Integer, ByVal detalleid As Integer, ByVal folioDev As String, ByVal precip As Decimal, productoestilo As String, ByVal porcentaje As Decimal, ByVal clavesat As String, ByVal descripcion As String, ByVal documentoId As Integer, ByVal anio As Integer)
        Dim objactualizarpar As New NotaCreditoDevolucionesDA
        objactualizarpar.actualizaParSessionDetalle(sesionid, factura, subtotal, iva, total, par, detalleid, folioDev, precip, productoestilo, porcentaje, clavesat, descripcion, documentoId, anio)
    End Sub
    Public Sub replicaNotasCreditoSay_Sicy(ByVal NotaCredito As NotasCreditoDevoluciones)
        Dim objReplicaNC As New NotaCreditoDevolucionesDA
        objReplicaNC.ReplicaNotasCreditoSAY_SICY(NotaCredito)
    End Sub
    Public Sub ActualizaParAplicado(ByVal paraplicado As Integer, ByVal folioDev As Integer, ByVal productoEstilo As Integer, ByVal detalleIdDevolucion As Integer)
        Dim objReplicaNC As New NotaCreditoDevolucionesDA
        objReplicaNC.ActualizaParAplicado(paraplicado, folioDev, productoEstilo, detalleIdDevolucion)
    End Sub
End Class
