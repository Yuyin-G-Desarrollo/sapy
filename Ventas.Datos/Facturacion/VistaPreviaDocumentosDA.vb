Imports System.Data.SqlClient

Public Class VistaPreviaDocumentosDA


    Public Function consultaDescuentosCliente(ByVal ClienteId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ClienteId"
        parametro.Value = ClienteId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ConfigDoctos_DescuentosCliente", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function obtenerEncabezadosDocumentosPorGenerar(ByVal ClienteId As Integer, ByVal IdOrdenesTrabajo As String, ByVal PorcentajeFacturacionUsuario As Integer, ByVal PorcentajeRemisionUsuario As Integer, ByVal PorcentajeFacturacionFTC As Integer, ByVal PorcentajeRemisionFTC As Integer, ByVal MontoMaximoFacturacion As Integer, ByVal RestriccionFacturacionID As Double, ByVal TipoIVAID As Integer, ByVal MonedaID As Integer, ByVal ImprimirOC As Integer, ByVal ImprimirTienda As Integer, ByVal RFCId As String, ByVal RFCPorcentaje As String, ByVal EmisorID As Integer, ByVal UsuarioID As Integer, ByVal SesionID As Integer, ByVal generacionAutomatica As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ClienteId"
        parametro.Value = ClienteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OT"
        parametro.Value = IdOrdenesTrabajo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PorcentajeFacturacion"
        parametro.Value = PorcentajeFacturacionUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PorcentajeRemision"
        parametro.Value = PorcentajeRemisionUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PorcentajeFacturacion_FTC"
        parametro.Value = PorcentajeFacturacionFTC
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PorcentajeRemision_FTC"
        parametro.Value = PorcentajeRemisionFTC
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MontoMaximoFactura"
        parametro.Value = MontoMaximoFacturacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RestriccionFacturacionID"
        parametro.Value = RestriccionFacturacionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoIVAID"
        parametro.Value = TipoIVAID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MonedaID"
        parametro.Value = MonedaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ImprimirOC"
        parametro.Value = ImprimirOC
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ImprimirTienda"
        parametro.Value = ImprimirTienda
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RFCId"
        parametro.Value = RFCId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RFCPorcentaje"
        parametro.Value = RFCPorcentaje
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EmisorID"
        parametro.Value = EmisorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SesionID"
        parametro.Value = SesionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "GeneracionAutomatica"
        parametro.Value = generacionAutomatica
        listaParametros.Add(parametro)

        'dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_VisualizacionDocumentos_Encabezados", listaParametros)
        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_VisualizacionDocumentos_Encabezados_02032021", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function obtenerDetallesDocumentosPorGenerar(ByVal ClienteId As Integer, ByVal SesionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ClienteId"
        parametro.Value = ClienteId
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "RestriccionFacturacionID"
        'parametro.Value = RestriccionFacturacionID
        'listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SesionID"
        parametro.Value = SesionID
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_VisualizacionDocumentos_Detalles", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function consultaTiendasPorCliente(ByVal ClienteId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ClienteId"
        parametro.Value = ClienteId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ConsultarTiendaPorCliente", listaParametros)

    End Function

    Public Function actualizaTiendaPorDocumento(ByVal DocumentoId As Integer, ByVal TiendaId As Integer, ByVal OC As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "DocumentoId"
        parametro.Value = DocumentoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TiendaId"
        parametro.Value = TiendaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OC"
        parametro.Value = OC
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ActualizaTiendaYOrdenCompraDocumento", listaParametros)

    End Function

    Public Function consultarPermisoModificarPreciosManualmente() As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Return objPersistencia.EjecutaConsulta("exec Almacen.SP_ConsultaOpcionFacturacionCalzado")

    End Function

    Public Function actualizaDescripcionDetalleDocumentoPorGenerar(ByVal DetalleDocumentoId As Integer, ByVal Descripcion As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "DetalleDocumentoId"
        parametro.Value = DetalleDocumentoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Descripcion"
        parametro.Value = Descripcion
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ActualizaDescripcionDetalleDocumento", listaParametros)

    End Function


    Public Function actualizaPrecioDocumentoPorGenerar(ByVal DetalleDocumentoId As Integer, ByVal Precio As Double, ByVal Subtotal As Double, ByVal Descuento As Double, ByVal Importe As Double, ByVal SumaSubtotal As Double, ByVal SumaDescuento As Double, ByVal SumaImporte As Double, ByVal IVA As Double) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "DetalleDocumentoId"
        parametro.Value = DetalleDocumentoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Precio"
        parametro.Value = Precio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Subtotal"
        parametro.Value = Subtotal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Descuento"
        parametro.Value = Descuento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Importe"
        parametro.Value = Importe
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SumaSubtotal"
        parametro.Value = SumaSubtotal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SumaDescuento"
        parametro.Value = SumaDescuento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SumaImporte"
        parametro.Value = SumaImporte
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IVA"
        parametro.Value = IVA
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ActualizaPrecioYTotalesDocumento", listaParametros)

    End Function

    Public Function actualizaCajasYMensajesDocumentoPorGenerar(ByVal DocumentoID As Integer, ByVal Cajas As Integer, ByVal Mensaje As String, ByVal Observacion As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "DocumentoId"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cajas"
        parametro.Value = Cajas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Mensaje"
        parametro.Value = Mensaje
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Observacion"
        parametro.Value = Observacion
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ActualizaCajasYMensajes", listaParametros)

    End Function


    Public Function InsertarDescuentoClienteDocumento(ByVal DocumentoID As Integer, ByVal MotivoDescuento As String, ByVal PorcentajeDescuento As Double, ByVal Encadenado As Boolean) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MotivoDescuento"
        parametro.Value = MotivoDescuento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PorcentajeDescuento"
        parametro.Value = PorcentajeDescuento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Encadenado"
        parametro.Value = Encadenado
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_InsertarDescuentoPorDocumento]", listaParametros)

    End Function

    Public Function EnviarDocumentosSAY(ByVal SessionID As Integer, ByVal DocumentoID As Integer, ByVal DiasPlazo As Integer, ByVal ImporteConLetra As String, ParidadDocumento As Double, ByVal cargoEnvioConIva As Double, ByVal cargoEnvioSinIva As Double, ByVal cargoEnvioSoloIva As Double) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@SesionID"
        parametro.Value = SessionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@Folio"
        'parametro.Value = Folio
        'listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@Serie"
        'parametro.Value = Serie
        'listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@Remision"
        'parametro.Value = Remision
        'listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@AñoRemision"
        'parametro.Value = AñoRemision
        'listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@DiasPlazo"
        parametro.Value = DiasPlazo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ImporteConLetra"
        parametro.Value = ImporteConLetra
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ParidadDocumetoExtranjero"
        parametro.Value = ParidadDocumento
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@cargoEnvioConIva", cargoEnvioConIva)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@cargoEnvioSinIva", cargoEnvioSinIva)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@cargoEnvioSoloIva",cargoEnvioSoloIva)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_EnviarDocumentosSAY_01032021]", listaParametros)

    End Function

    Public Function EnviarDetalleDocumentosSAY(ByVal DocumentoIDTMP As Integer, ByVal DocumentoID As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoIDTMP"
        parametro.Value = DocumentoIDTMP
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_EnviarDocumentosDetalleSAY]", listaParametros)


    End Function

    Public Sub EnviarDetallePartidaOTDocumentosSAY(ByVal DocumentoIDTMP As Integer, ByVal DocumentoID As Integer)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoIDTMP"
        parametro.Value = DocumentoIDTMP
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_InsertarDetallesPartidaOT]", listaParametros)

    End Sub

    Public Sub BorrarDatosDocumento(ByVal DocumentoID As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_BorrarDatosDocumento]", listaParametros)

    End Sub

    Public Sub ActualizarParesFacturados(ByVal DocumentoID As String)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Documento"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_ActualizarParesFacturadoOTDocumento]", listaParametros)

    End Sub


    Public Sub ActualizarStatusOT(ByVal DocumentoID As String)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Documento"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_ActualizarStatusOTFacturado]", listaParametros)

    End Sub

    Public Sub ActualizarStatusPedido(ByVal DocumentoID As String)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Documento"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_ActualizarStatusPedidoFacturado]", listaParametros)

    End Sub


    Public Function ObtenerFolioFacturacionRemision(ByVal EmpresaId As Integer, ByVal TipoDocumento As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@EmpresaID"
        parametro.Value = EmpresaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoDocumento"
        parametro.Value = TipoDocumento
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_FacturacionCalzada_ObtenerFolioFacturacionRemision]", listaParametros)

    End Function

    Public Function ObtenerInformaciondocumento(ByVal DocumentoId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_VistaPrevia_ObtenerInformacionDocumento]", listaParametros)

    End Function

    Public Function ObtenerInformaciondocumentoSession(ByVal SessionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Session"
        parametro.Value = SessionID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_VistaPrevia_ObtenerInformacionDocumentosSession]", listaParametros)

    End Function


    Public Function GenerarInformacionTimbrado(ByVal DocumentoID As Integer, ByVal TipoDocumento As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoComprobante"
        parametro.Value = TipoDocumento
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Timbrado_InsertarInformacion__01032021]", listaParametros)

    End Function



    Public Function limpiarSesionFacturacion(ByVal SesionID As Integer)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "SesionId"
        parametro.Value = SesionID
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_LimpiarSesionFacturacion", listaParametros)

    End Function

    Public Function obtenerDetallesDocumentosPorGenerarRecuperarSesion(ByVal SesionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "SesionID"
        parametro.Value = SesionID
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_VisualizacionDocumentos_Detalles_RecuperaSesion", listaParametros)

        Return dtResultadoConsulta

    End Function
    Public Function obtenerOTSRecuperarSesion(ByVal SesionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "SesionID"
        parametro.Value = SesionID
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_VisualizacionDocumentos_Detalles_OTS]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ObtenerInformacionParesImpresion(ByVal DocumentoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_DocumentoRemision_InformacionPares]", listaParametros)

    End Function

    Public Function ObtenerInformacionEncabezadoImpresion(ByVal DocumentoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_DocumentoRemision_InformacionEncabezado]", listaParametros)

    End Function

    Public Function EnviarHistoricoTimbrado(ByVal DocumentoID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Timbrado_EnvioHistorico]", listaParametros)

    End Function


    Public Function ActualizarParesFacturadosCOPPEL(ByVal DocumentoID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Documento"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_ActualizarParesFacturadosCOPPEL]", listaParametros)

    End Function

    Public Function ObtenerEncabezadoAddenda(ByVal DocumentoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Addenda_ConsultaInformacion]", listaParametros)
    End Function


    Public Function ObtenerDetalleAddenda(ByVal DocumentoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Addenda_ConsultaInformacionPartidaTallas]", listaParametros)
    End Function


    Public Function ReplicarDocumentos_SAY_SICY(ByVal DocumentoID As Integer, ByVal ParidadDocumetoExtranjero As Double) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ParidadDocumetoExtranjero"
        parametro.Value = ParidadDocumetoExtranjero
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_ReplicarDocumentos_SAY_a_SICY_01032021]", listaParametros)
    End Function

    Public Function ConsultarFoliosFacturasYRemisiones(ByVal DocumentoID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_ConsultarFoliosFacturasRemisiones]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ConsultarEncabezadoAddendaCOPPEL(ByVal DocumentoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Addenda_ConsultaEncabezado]", listaParametros)

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

    Public Function consultaDatosDocumentoEnvioFactura(ByVal DocumentoId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "DocumentoId"
        parametro.Value = DocumentoId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ConsultarDatosEnvioCorreoPorDocumento", listaParametros)

    End Function


    Public Sub InsertarDatosCorreoEnviadoSICY(ByVal EnviadoA As String, ByVal Enviado As String, ByVal Usuario As String, ByVal Asunto As String, ByVal MotivoNoEnvio As String, ByVal RemisionId As Integer, ByVal TipoArchivo As String, ByVal Reenviado As Boolean)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@enviadoA"
        parametro.Value = EnviadoA
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@Enviado"
        parametro.Value = Enviado
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Usuario
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@Asunto"
        parametro.Value = Asunto
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@MotivoNoEnvio"
        parametro.Value = MotivoNoEnvio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Remision"
        parametro.Value = RemisionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoArchivo"
        parametro.Value = TipoArchivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Reenviado"
        parametro.Value = Reenviado
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Correo_InsertarDatosEnvio]", listaParametros)

    End Sub

    Public Sub ActualizarStatusCorreoEnviadoSAY(ByVal DocumentoID As Integer, ByVal CorreoEnviado As Boolean)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoId"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CorreoEnviado"
        parametro.Value = CorreoEnviado
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_ActualizarStatusCorreo]", listaParametros)

    End Sub


    Public Sub ActualizarNumeroCajas(ByVal DocumentoID As Integer, ByVal NumeroCajas As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoId"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Cajas"
        parametro.Value = NumeroCajas
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_ActualizaNumeroCajas]", listaParametros)

    End Sub


    Public Sub ActualizarStatusPedidoSICY(ByVal DocumentoID As Integer)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Pedidos_ActualizarEstatusFacturadoPartidas]", listaParametros)

    End Sub

    Public Function ParesDcumentosIgualParesOT(ByVal OTs As String, ByVal Pares As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@OT"
        parametro.Value = OTs
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ParesDOC"
        parametro.Value = Pares
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_ParesDcumentosIgualParesOT]", listaParametros)

    End Function

    Public Function GeneraRegistgrosSalidaDocumento(ByVal DocumentoId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoId
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaVentas_GenerarDetallesPares_Optimizado]", listaParametros)

    End Function

End Class
