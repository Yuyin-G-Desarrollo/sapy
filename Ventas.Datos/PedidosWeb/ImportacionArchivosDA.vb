Imports System.Data.SqlClient

Public Class ImportacionArchivosDA
    ''funcion para obtener datos para importacion coppel a partir del codigo de cliente
    Public Function validaCodigoClienteCoppel(ByVal codigoRapido As String, ByVal idCliente As Int32, ByVal idAgente As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametros.ParameterName = "idCliente"
        parametros.Value = idCliente
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "idAgente"
        parametros.Value = idAgente
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "codigoRapido"
        parametros.Value = codigoRapido
        listaParametros.Add(parametros)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ValidacionCodigoClienteCoppel", listaParametros)
    End Function

    ''funcion para validar que el producgo leido se encuentre en la lista de precios 
    Public Function validarImportacionListaPrecio(ByVal idListaPrecio As Int32, ByVal idProductoEstilo As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idListaPrecio"
        parametro.Value = idListaPrecio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "productoEstilo"
        parametro.Value = idProductoEstilo
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ValidacionImportacion_LP", listaParametros)
    End Function

    ''funcion para obtener los detalles de tallas de una corrida
    Public Function consultaDetallesTallasImportacion(ByVal idTalla As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idTalla"
        parametro.Value = idTalla
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ImportacionDetallesTallas", listaParametros)
    End Function

    ''funcion para validar el tipo de archivo de imprtacion de cada cliente
    Public Function consultarTipoImportacionArchivoCliente(ByVal idCliente As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConsultaTipoImportacionCliente", listaParametros)
    End Function

    '' funcion para validar codigos clientes importacion archivo
    Public Function validarCodigosClienteImportacion(ByVal codigoRapido As String, ByVal idCliente As Int32, ByVal idAgente As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "codigoRapido"
        parametro.Value = codigoRapido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idAgente"
        parametro.Value = idAgente
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ValidaCodigoClienteImportacion", listaParametros)
    End Function
#Region "Pakar Puebla"
    '' funcion para validar codigos clientes importacion archivo
    Public Function validarCodigosClienteImportacionPakar(ByVal codigoRapido As String, ByVal idCliente As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "codigocliente"
        parametro.Value = codigoRapido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "idAgente"
        'parametro.Value = idAgente
        'listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ValidaCodigoClienteImportacionPakar", listaParametros)
    End Function

    ''funcion para validar el codigo de la tienda importacion archivo
    Public Function validarTiendaClienteImportacionPakar(ByVal idCliente As Int32, ByVal idRfc As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idRfc"
        parametro.Value = idRfc
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ValidaTiendaImportacionPakar", listaParametros)
    End Function

#End Region
    ''funcion para validar el codigo de la tienda importacion archivo
    Public Function validarTiendaClienteImportacion(ByVal idCliente As Int32, ByVal codTienda As String, ByVal idRfc As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "codigoTienda"
        parametro.Value = codTienda
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idRfc"
        parametro.Value = idRfc
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ValidaTiendaImportacion", listaParametros)
    End Function

    ''funcion para recuperar los modelos e insertarlos en el excel
    Public Function consultaModelosExportarExcel(ByVal idCLiente As Int32, ByVal idMarcas As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "clienteIdSAY"
        parametro.Value = idCLiente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idMarcas"
        parametro.Value = idMarcas
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_FormatoGeneral_Modelos", listaParametros)
    End Function

    ''funcion para recuperar datos del cliente(exportar a excel)
    Public Function consultaDatosClienteExportar(ByVal idCliente As Int32) As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        consulta = "SELECT clie_nombregenerico,clie_clienteid FROM Cliente.Cliente WHERE clie_statuscliente='C' AND clie_clienteid= " + idCliente.ToString

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''funcion para recuperar ramos del cliente(exportar a excel)
    Public Function consultaRamosClienteExportar(ByVal idCliente As Int32) As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        consulta = <consulta>
                    SELECT ramo_nombre,ramo_ramoid FROM Cliente.Ramos WHERE ramo_ramoid IN (SELECT tiec_ramoid FROM Cliente.TiendaEmbarqueCEDIS
                    where tiec_clienteid=<%= idCliente.ToString %> and tiec_activo=1) OR ramo_ramoid IN (SELECT racl_ramoid FROM Cliente.ClienteRamos WHERE racl_clienteid=<%= idCliente.ToString %> 
                    AND racl_activo=1 AND racl_numtiendasreal>0 )
                   </consulta>.Value
        Return persistencia.EjecutaConsulta(consulta)
    End Function

    '' funcion para consultar los rfc activos del cliente (exportar a excel)
    Public Function consultaRFCClienteExportar(ByVal idCliente As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConsultaRfc_ExportarPedido", listaParametros)
    End Function

    ''funcion para consultar todas las tiendas activas de un rfc (exportar a excel)
    Public Function consultaTiendasActivasExportar(ByVal idCliente As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConsultaTiendasRFC_ExportarPedido", listaParametros)
    End Function

    ''funcion para consultar los modelos (exportar a excel)
    Public Function consultaCatalogoModeloExportar(ByVal idCliente As Int32, ByVal idMarcas As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idMarcas"
        parametro.Value = idMarcas
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConsultaModelos_ExportarPedidos", listaParametros)
    End Function


    ''funcion para recuperar la fecha de programacion 
    Public Function consultarFechaProgramacionPedido() As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        consulta = "select opci_valor_date from Programacion.Opciones where opci_descripcion='FechaEntrega'"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''funcion para validar las marcas importacion pedido general
    Public Function validarMarcaImportacionGeneral(ByVal productoEstilo As Int32, ByVal idCliente As Int32, ByVal idAgente As Int32)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "productoEstilo"
        parametro.Value = productoEstilo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idAgente"
        parametro.Value = idAgente
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ValidacionMarca_ImportacionGeneral", listaParametros)
    End Function

    ''funcion para validar los codigos amece importacion de archivos
    Public Function validarCodigosAmeceImportacionArchivos(ByVal productoEstiloId As Int32, ByVal talla As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "productoEstiloId"
        parametro.Value = productoEstiloId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "talla"
        parametro.Value = talla
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ValidaCodigosAmece_Importacion", listaParametros)
    End Function

    ''funcion para obtener el producto estilo a partir del codigo de andrea
    Public Function consultaPECodigoAndrea(ByVal idCliente As Int32, ByVal codigocliente As String, ByVal material As String, ByVal color As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "codigoCliente"
        parametro.Value = codigocliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "color"
        parametro.Value = color
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "material"
        parametro.Value = material
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConsultaPE_CodigoAndrea", listaParametros)
    End Function

    ''funcion para validar los codigos de cliente de andrea 
    Public Function validarCodigoClienteAndrea(ByVal idCliente As Int32, ByVal prodcutoEstilo As Int32, ByVal talla As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "productoEstilo"
        parametro.Value = prodcutoEstilo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "talla"
        parametro.Value = talla
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ValidacionCodigoClienteAndrea", listaParametros)
    End Function

    ''funcion para obtener el producto estilo a partir del codigo amece
    Public Function validarPEAmeceImportacionSears(ByVal codigoAmece As String, ByVal talla As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter
        Dim listaParemetros As New List(Of SqlParameter)

        parametros.ParameterName = "codigoAmece"
        parametros.Value = codigoAmece
        listaParemetros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "talla"
        parametros.Value = talla
        listaParemetros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ObtenerPE_AmeceImportacion", listaParemetros)
    End Function

    ''funcion para validar articulos en lista de precios dependiendo de la fecha de programacion
    Public Function validaListaPreciosFPImportacionSears(ByVal idListaPrecios As Int32, ByVal fechaProgramacion As Date, ByVal productoEstiloId As Int32) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter

        parametros.ParameterName = "idListaPrecio"
        parametros.Value = idListaPrecios
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "productoEstilo"
        parametros.Value = productoEstiloId
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaProgramacion"
        parametros.Value = fechaProgramacion
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ValidaLP_FPSears", listaParametros)

    End Function

    ''funcion para obtener la tienda en el archivo de importacion de sears
    Public Function validarTecImportacionSears(ByVal clienteRfcId As Int32) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter

        parametros.ParameterName = "clientesRFCId"
        parametros.Value = clienteRfcId
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_RecuperarTec_ImportacionSears", listaParametros)
    End Function

#Region "Mejoras importacion hermanos batta"

    Public Function insertaEncabezadoArchivoImportacion(ByVal clienteid As Int32, ByVal agenteid As Int32, ByVal listaPreciosid As Int32,
                                                        ByVal rfcid As Int32, ByVal ramoid As Int32, ByVal inicial As Boolean,
                                                        ByVal ordenCliente As String, ByVal entregainmediata As Boolean, ByVal fechaProgramacion As Date,
                                                        ByVal fechaSolicitada As Date, ByVal incotermid As Int32, ByVal observacion As String,
                                                        ByVal rutaid As Int32, ByVal monedaid As Int32, ByVal usuarioid As Int32) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter

        parametros.ParameterName = "clienteid"
        parametros.Value = clienteid
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "agenteid"
        parametros.Value = agenteid
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "listaPreciosid"
        parametros.Value = listaPreciosid
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "rfcid"
        parametros.Value = rfcid
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "ramoid"
        parametros.Value = ramoid
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "inicial"
        parametros.Value = inicial
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "ordenCliente"
        parametros.Value = ordenCliente
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "entregainmediata"
        parametros.Value = entregainmediata
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaProgramacion"
        parametros.Value = fechaProgramacion
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaSolicitada"
        parametros.Value = fechaSolicitada
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "incotermid"
        parametros.Value = incotermid
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "observacion"
        parametros.Value = observacion
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "rutaid"
        parametros.Value = rutaid
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "monedaid"
        parametros.Value = monedaid
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "usuarioid"
        parametros.Value = usuarioid
        listaParametros.Add(parametros)

       
        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebImp_InsertaEncabezadoArchivo", listaParametros)
    End Function

    Public Function insertaDetalleArchivoImportacion(ByVal encabezadoid As Int32, ByVal pedidoCliente As String, ByVal codigorapido As String,
                                                     ByVal nombreTienda As String, ByVal talla As String, ByVal cantidad As Int32) As DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter

        parametros.ParameterName = "encabezadoid"
        parametros.Value = encabezadoid
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "pedidoCliente"
        parametros.Value = pedidoCliente
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "codigorapido"
        parametros.Value = codigorapido
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "nombreTienda"
        parametros.Value = nombreTienda
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "talla"
        parametros.Value = talla
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "cantidad"
        parametros.Value = cantidad
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebImp_InsertaDetallesArchivo", listaParametros)
    End Function

    Public Function validaCodigoClienteRelacionadoImpArchivo(ByVal encabezadoImportacionid As Int32) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter

        parametros.ParameterName = "encabezadoid"
        parametros.Value = encabezadoImportacionid
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebImp_ValidaCodigoClienteRelacionado", listaParametros)
    End Function

    Public Function validaMarcaAgenteRelacionadoImpArchivo(ByVal encabezadoImportacionid As Int32) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter

        parametros.ParameterName = "encabezadoid"
        parametros.Value = encabezadoImportacionid
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebImp_ValidaMarcaAgenteRelacionado", listaParametros)
    End Function


    Public Function validaListaPrecioRelacionadoImpArchivo(ByVal encabezadoImportacionid As Int32) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter

        parametros.ParameterName = "encabezadoid"
        parametros.Value = encabezadoImportacionid
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebImp_ValidaListaPreciosRelacionado", listaParametros)
    End Function

    Public Function validaTiendaRelacionadaRFCImpArchivo(ByVal encabezadoImportacionid As Int32) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter

        parametros.ParameterName = "encabezadoid"
        parametros.Value = encabezadoImportacionid
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebImp_ValidaTiendaRelacionadaRFC", listaParametros)
    End Function

    Public Function insertaPedidosGeneradosArchivoImp(ByVal encabezadoImportacionid As Int32) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter

        parametros.ParameterName = "encabezadoid"
        parametros.Value = encabezadoImportacionid
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebImp_GeneraPedidosImportacion", listaParametros)
    End Function

    Public Sub eliminaDatosArchivoLeido(ByVal encabezadoImportacionid As Int32)
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter

        parametros.ParameterName = "encabezadoid"
        parametros.Value = encabezadoImportacionid
        listaParametros.Add(parametros)

        persistencia.EjecutarSentenciaSP("Ventas.SP_PedidosWebImp_EliminaInformacionArchivo", listaParametros)
    End Sub

    Public Function consultaDetallesArchivoGenerarPedidos(ByVal encabezadoid As Int32) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter

        parametros.ParameterName = "encabezadoid"
        parametros.Value = encabezadoid
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWebImp_ObtieneDetalleArchivo", listaParametros)

    End Function

    Public Function obtenerTiendaImportacionCoppel(ByVal idCliente As Int32) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter

        parametros.ParameterName = "idCliente"
        parametros.Value = idCliente
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_RecuperarTECRFC_COPPEL", listaParametros)
    End Function
#End Region
End Class
