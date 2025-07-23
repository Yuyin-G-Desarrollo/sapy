Imports System.Globalization
Imports ToolServicios

Public Class VistaPreviaDocumentosBU

    Private Property _Aviso As String


    Public Function consultaDescuentosCliente(ByVal ClienteId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaDescuentosCliente(ClienteId)
        Return tabla
    End Function

    Public Function obtenerEncabezadosDocumentosPorGenerar(ByVal ClienteId As Integer, ByVal IdOrdenesTrabajo As String, ByVal PorcentajeFacturacionUsuario As Integer, ByVal PorcentajeRemisionUsuario As Integer, ByVal PorcentajeFacturacionFTC As Integer, ByVal PorcentajeRemisionFTC As Integer, ByVal MontoMaximoFacturacion As Double, ByVal RestriccionFacturacionID As Integer, ByVal TipoIVAID As Integer, ByVal MonedaID As Integer, ByVal ImprimirOC As Integer, ByVal ImprimirTienda As Integer, ByVal RFCId As String, ByVal RFCPorcentaje As String, ByVal EmisorID As Integer, ByVal UsuarioID As Integer, ByVal SesionID As Integer, ByVal generacionAutomatica As Integer) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.obtenerEncabezadosDocumentosPorGenerar(ClienteId, IdOrdenesTrabajo, PorcentajeFacturacionUsuario, PorcentajeRemisionUsuario, PorcentajeFacturacionFTC, PorcentajeRemisionFTC, MontoMaximoFacturacion, RestriccionFacturacionID, TipoIVAID, MonedaID, ImprimirOC, ImprimirTienda, RFCId, RFCPorcentaje, EmisorID, UsuarioID, SesionID, generacionAutomatica)
        Return tabla
    End Function

    Public Function obtenerDetallesDocumentosPorGenerar(ByVal ClienteId As Integer, ByVal SesionID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.obtenerDetallesDocumentosPorGenerar(ClienteId, SesionID)
        Return tabla
    End Function

    Public Function consultaTiendasPorCliente(ByVal ClienteId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaTiendasPorCliente(ClienteId)
        Return tabla
    End Function

    Public Function actualizaTiendaPorDocumento(ByVal DocumentoId As Integer, ByVal TiendaId As Integer, ByVal OC As String) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.actualizaTiendaPorDocumento(DocumentoId, TiendaId, OC)
        Return tabla
    End Function

    Public Function consultarPermisoModificarPreciosManualmente() As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.consultarPermisoModificarPreciosManualmente()
        Return tabla
    End Function

    Public Function actualizaDescripcionDetalleDocumentoPorGenerar(ByVal DetalleDocumentoId As Integer, ByVal Descripcion As String) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.actualizaDescripcionDetalleDocumentoPorGenerar(DetalleDocumentoId, Descripcion)
        Return tabla
    End Function


    Public Function actualizaPrecioDocumentoPorGenerar(ByVal DetalleDocumentoId As Integer, ByVal Precio As Double, ByVal Subtotal As Double, ByVal Descuento As Double, ByVal Importe As Double, ByVal SumaSubtotal As Double, ByVal SumaDescuento As Double, ByVal SumaImporte As Double, ByVal IVA As Double) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.actualizaPrecioDocumentoPorGenerar(DetalleDocumentoId, Precio, Subtotal, Descuento, Importe, SumaSubtotal, SumaDescuento, SumaImporte, IVA)
        Return tabla
    End Function

    Public Function actualizaCajasYMensajesDocumentoPorGenerar(ByVal DocumentoID As Integer, ByVal Cajas As Integer, ByVal Mensaje As String, ByVal Observacion As String) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.actualizaCajasYMensajesDocumentoPorGenerar(DocumentoID, Cajas, Mensaje, Observacion)
        Return tabla
    End Function

    Public Function InsertarDescuentoClienteDocumento(ByVal DocumentoID As Integer, ByVal MotivoDescuento As String, ByVal PorcentajeDescuento As Double, ByVal Encadenado As Boolean) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.InsertarDescuentoClienteDocumento(DocumentoID, MotivoDescuento, PorcentajeDescuento, Encadenado)
        Return tabla
    End Function

    Public Function EnviarDocumentosSAY(ByVal SessionID As Integer, ByVal DocumentoID As Integer, ByVal DiasPlazo As Integer, ByVal ImporteConLetra As String, ParidadDocumento As Double, ByVal cargoEnvioConIva As Double, ByVal cargoEnvioSinIva As Double, ByVal cargoEnvioSoloIva As Double) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Dim tabla As New DataTable
        'tabla = objDA.EnviarDocumentosSAY(SessionID, DocumentoID, DiasPlazo, ImporteConLetra, ParidadDocumento)
        tabla = objDA.EnviarDocumentosSAY(SessionID, DocumentoID, DiasPlazo, ImporteConLetra, ParidadDocumento, cargoEnvioConIva, cargoEnvioSinIva, cargoEnvioSoloIva)
        Return tabla
    End Function

    Public Function EnviarDetalleDocumentosSAY(ByVal DocumentoIDTMP As Integer, ByVal DocumentoID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.EnviarDetalleDocumentosSAY(DocumentoIDTMP, DocumentoID)
        Return tabla
    End Function

    Public Sub EnviarDetallePartidaOTDocumentosSAY(ByVal DocumentoIDTMP As Integer, ByVal DocumentoID As Integer)
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        objDA.EnviarDetallePartidaOTDocumentosSAY(DocumentoIDTMP, DocumentoID)
    End Sub

    Public Sub BorrarDatosDocumento(ByVal DocumentoID As Integer)
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        objDA.BorrarDatosDocumento(DocumentoID)
    End Sub

    Public Sub ActualizarParesFacturados(ByVal DocumentoID As String)
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        objDA.ActualizarParesFacturados(DocumentoID)
    End Sub

    Public Sub ActualizarStatusOT(ByVal DocumentoID As String)
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        objDA.ActualizarStatusOT(DocumentoID)
    End Sub

    Public Sub ActualizarStatusPedido(ByVal DocumentoID As String)
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        objDA.ActualizarStatusPedido(DocumentoID)
    End Sub

    Public Function ObtenerFolioFacturacionRemision(ByVal EmpresaId As Integer, ByVal TipoDocumento As String) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Return objDA.ObtenerFolioFacturacionRemision(EmpresaId, TipoDocumento)
    End Function

    Public Function ObtenerInformaciondocumento(ByVal DocumentoId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Return objDA.ObtenerInformaciondocumento(DocumentoId)
    End Function

    Public Function ObtenerInformaciondocumentoSession(ByVal SessionID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Return objDA.ObtenerInformaciondocumentoSession(SessionID)
    End Function

    Public Function GenerarInformacionTimbrado(ByVal DocumentoID As Integer, ByVal TipoDocumento As String) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Return objDA.GenerarInformacionTimbrado(DocumentoID, TipoDocumento)
    End Function

    Public Sub limpiarSesionFacturacion(ByVal SesionID As Integer)
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        objDA.limpiarSesionFacturacion(SesionID)
    End Sub

    Public Function obtenerDetallesDocumentosPorGenerarRecuperarSesion(ByVal SesionID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.obtenerDetallesDocumentosPorGenerarRecuperarSesion(SesionID)
        Return tabla
    End Function
    Public Function obtenerOTsRecuperarSesion(ByVal SesionID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.obtenerOTSRecuperarSesion(SesionID)
        Return tabla
    End Function

    Public Function ObtenerInformacionParesImpresion(ByVal DocumentoID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Return objDA.ObtenerInformacionParesImpresion(DocumentoID)
    End Function

    Public Function ObtenerInformacionEncabezadoImpresion(ByVal DocumentoID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Return objDA.ObtenerInformacionEncabezadoImpresion(DocumentoID)
    End Function

    Public Function EnviarHistoricoTimbrado(ByVal DocumentoID As String) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Return objDA.EnviarHistoricoTimbrado(DocumentoID)
    End Function

    Public Function ActualizarParesFacturadosCOPPEL(ByVal DocumentoID As String) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Return objDA.ActualizarParesFacturadosCOPPEL(DocumentoID)
    End Function

    Public Function ObtenerEncabezadoAddenda(ByVal DocumentoID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Return objDA.ObtenerEncabezadoAddenda(DocumentoID)
    End Function

    Public Function ObtenerDetalleAddenda(ByVal DocumentoID As Integer) As List(Of Entidades.AddendaDetalles)
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Dim ListaDetalles As New List(Of Entidades.AddendaDetalles)
        Dim dtDetallesAddenda As DataTable
        Dim objEnt As Entidades.AddendaDetalles

        dtDetallesAddenda = objDA.ObtenerDetalleAddenda(DocumentoID)

        For Each Fila As DataRow In dtDetallesAddenda.Rows
            objEnt = New Entidades.AddendaDetalles
            objEnt.Partida = Fila.Item("Partida")
            objEnt.Codigo = Fila.Item("Codigo")
            objEnt.Calce = Fila.Item("talla_sicy")
            objEnt.SKU = Fila.Item("SKU")
            objEnt.CodigoCliente = Fila.Item("CodigoCliente")
            objEnt.CodigoAMECE = Fila.Item("CodigoAMECE")
            objEnt.Articulo = Fila.Item("Articulo")
            objEnt.Talla = Fila.Item("Talla")
            objEnt.CantidadPares = Fila.Item("CantidadPares")

            objEnt.PrecioBruto = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", Fila.Item("PBruto"))
            'objEnt.PrecioBruto = String.Format(Fila.Item("PBruto"), "#0.00")
            objEnt.MontoBruto = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", Fila.Item("MBruto")) 'String.Format(Fila.Item("MBruto"), "#0.00")
            objEnt.FormatoTalla = Fila.Item("FormatoTalla")
            objEnt.Estilo = Fila.Item("Estilo")
            objEnt.ImpLinea = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", Fila.Item("impLinea")) 'String.Format(Fila.Item("impLinea"), "#0.00")
            objEnt.MontoImpresionLinea = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", Fila.Item("MImpLinea")) 'String.Format(Fila.Item("MImpLinea"), "#0.00")
            objEnt.PorcentajeIVA = Fila.Item("TIVa")
            objEnt.MontoIVA = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", Fila.Item("MIVA")) ' String.Format(Fila.Item("MIVA"), "#0.00")
            objEnt.UmPri = Fila.Item("UmPri")
            objEnt.UMPSec = Fila.Item("UMPSec")
            objEnt.DescripcionCte = Fila.Item("DescripcionCte")
            objEnt.PrecioNeto = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", Fila.Item("Pneto")) ' String.Format(Fila.Item("Pneto"), "#0.00")
            objEnt.Descuento = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", Fila.Item("CantDesc")) 'String.Format(Fila.Item("CantDesc"), "#0.00")
            objEnt.CantidadEmpacado = Fila.Item("cantemp")
            objEnt.PorcentajeDescuento = Fila.Item("fcdc_porcentajedescuento")
            ListaDetalles.Add(objEnt)
        Next

        Return ListaDetalles
    End Function

    Public Function ReplicarDocumentos_SAY_SICY(ByVal DocumentoID As Integer, ByVal ParidadDocumetoExtranjero As Double) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Return objDA.ReplicarDocumentos_SAY_SICY(DocumentoID, ParidadDocumetoExtranjero)
    End Function

    Public Function ConsultarFoliosFacturasYRemisiones(ByVal DocumentoID As String) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Return objDA.ConsultarFoliosFacturasYRemisiones(DocumentoID)
    End Function

    Public Function ConsultarEncabezadoAddendaCOPPEL(ByVal DocumentoID As Integer) As Entidades.Addenda
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Dim dtInformacion As DataTable
        Dim obj As New Entidades.Addenda

        dtInformacion = objDA.ConsultarEncabezadoAddendaCOPPEL(DocumentoID)

        If dtInformacion.Rows.Count > 0 Then

            obj.DocumentoID = dtInformacion.Rows(0).Item("fcdc_documentoid")
            If IsDBNull(dtInformacion.Rows(0).Item("fcdc_remisionid")) = False Then
                obj.RemisionID = dtInformacion.Rows(0).Item("fcdc_remisionid")
            Else
                obj.RemisionID = 0
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("fcdc_añoremision")) = False Then
                obj.AñoRemision = dtInformacion.Rows(0).Item("fcdc_añoremision")
            Else
                obj.AñoRemision = 0
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("fcdc_foliofactura")) = False Then
                obj.FolioFactura = dtInformacion.Rows(0).Item("fcdc_foliofactura")
            Else
                obj.FolioFactura = ""
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("fcdc_seriefactura")) = False Then
                obj.SerieFactura = dtInformacion.Rows(0).Item("fcdc_seriefactura")
            Else
                obj.SerieFactura = ""
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("fcdc_tipodocumento")) = False Then
                obj.TipoDocumento = dtInformacion.Rows(0).Item("fcdc_tipodocumento")
            Else
                obj.TipoDocumento = ""
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("fcdc_numcajas")) = False Then
                obj.NumeroCajas = dtInformacion.Rows(0).Item("fcdc_numcajas")
            Else
                obj.NumeroCajas = "0"
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("tiec_codigotienda")) = False Then
                obj.CodigoTienda = dtInformacion.Rows(0).Item("tiec_codigotienda")
            Else
                obj.CodigoTienda = "----"
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("fcdc_fechacaptura")) = False Then
                obj.FechaCaptura = dtInformacion.Rows(0).Item("fcdc_fechacaptura")
            Else
                obj.FechaCaptura = Nothing
            End If

            obj.ParesFacturados = dtInformacion.Rows(0).Item("fcdc_paresfacturados")
            obj.ParesCancelados = dtInformacion.Rows(0).Item("fcdc_parescancelados")
            obj.TotalPares = dtInformacion.Rows(0).Item("fcdc_totalpares")
            obj.SubTotal = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", dtInformacion.Rows(0).Item("fcdc_subtotal")) 'dtInformacion.Rows(0).Item("fcdc_subtotal")
            obj.Descuento = dtInformacion.Rows(0).Item("fcdc_descuento")
            obj.TipoIVA = dtInformacion.Rows(0).Item("fcdc_tipoiva")
            obj.MontoTotal = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", dtInformacion.Rows(0).Item("fcdc_montototal")) ' dtInformacion.Rows(0).Item("fcdc_montototal")
            obj.PorcentajeDescuento = dtInformacion.Rows(0).Item("fcdc_porcentajedescuento")
            obj.MontoTotalLetra = dtInformacion.Rows(0).Item("fcdc_montototal_letra")
            obj.UsoCFDI = dtInformacion.Rows(0).Item("fcdc_usocfdiid")
            obj.OrdenCompra = dtInformacion.Rows(0).Item("fcdc_ordencompra")
            obj.CorreoReceptor = dtInformacion.Rows(0).Item("fcdc_correoreceptor")
            obj.TotalIVA = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", dtInformacion.Rows(0).Item("fcdc_totaliva")) 'dtInformacion.Rows(0).Item("fcdc_totaliva")
            obj.Importe = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", dtInformacion.Rows(0).Item("fcdc_importe")) 'dtInformacion.Rows(0).Item("fcdc_importe")
        End If

        Return obj
    End Function

    Public Function consultaCorreosEnvioFactura(ByVal ClaveEnvio As String) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Return objDA.consultaCorreosEnvioFactura(ClaveEnvio)
    End Function

    Public Function consultaDatosDocumentoEnvioFactura(ByVal DocumentoId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Return objDA.consultaDatosDocumentoEnvioFactura(DocumentoId)
    End Function

    Public Sub InsertarDatosCorreoEnviadoSICY(ByVal EnviadoA As String, ByVal Enviado As String, ByVal Usuario As String, ByVal Asunto As String, ByVal MotivoNoEnvio As String, ByVal RemisionId As Integer, ByVal TipoArchivo As String, ByVal Reenviado As Boolean)
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        objDA.InsertarDatosCorreoEnviadoSICY(EnviadoA, Enviado, Usuario, Asunto, MotivoNoEnvio, RemisionId, TipoArchivo, Reenviado)
    End Sub

    Public Sub ActualizarStatusCorreoEnviadoSAY(ByVal DocumentoID As Integer, ByVal CorreoEnviado As Boolean)
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        objDA.ActualizarStatusCorreoEnviadoSAY(DocumentoID, CorreoEnviado)
    End Sub

    Public Sub ActualizarNumeroCajas(ByVal DocumentoID As Integer, ByVal NumeroCajas As Integer)
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        objDA.ActualizarNumeroCajas(DocumentoID, NumeroCajas)
    End Sub

    Public Sub ActualizarStatusPedidoSICY(ByVal DocumentoID As Integer)
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        objDA.ActualizarStatusPedidoSICY(DocumentoID)
    End Sub

    Public Function ParesDcumentosIgualParesOT(ByVal OTs As String, ByVal Pares As Integer) As Entidades.Respuesta

        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        Dim obj As New Entidades.Respuesta
        Dim dtResp = objDA.ParesDcumentosIgualParesOT(OTs, Pares)

        obj.Resp = dtResp.Rows(0).Item("Respuesta")
        obj.Mensaje = dtResp.Rows(0).Item("mensaje")
        Return obj
    End Function

    Public Function GeneraRegistgrosSalidaDocumento(ByVal DocumentoId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.VistaPreviaDocumentosDA
        objDA.GeneraRegistgrosSalidaDocumento(DocumentoId)
    End Function
End Class
