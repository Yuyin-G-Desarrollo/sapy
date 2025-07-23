Public Class ImportacionArchivosBU
    ''funcion para obtener datos para importacion coppel a partir del codigo de cliente 
    Public Function validaCodigoClienteCoppel(ByVal codigoRapido As String, ByVal idCliente As Int32, ByVal idAgente As Int32) As DataTable
        Dim objDa As New Datos.ImportacionArchivosDA
        Dim dtCodigos As New DataTable
        dtCodigos = objDa.validaCodigoClienteCoppel(codigoRapido, idCliente, idAgente)
        Return dtCodigos
    End Function

    ''funcion para validar que el producgo leido se encuentre en la lista de precios 
    Public Function validarImportacionListaPrecio(ByVal idListaPrecio As Int32, ByVal idProductoEstilo As Int32) As DataTable
        Dim objDa As New Datos.ImportacionArchivosDA
        Dim dtLp As New DataTable

        dtLp = objDa.validarImportacionListaPrecio(idListaPrecio, idProductoEstilo)
        Return dtLp
    End Function

    ''funcion para obtener los detalles de tallas de una corrida
    Public Function consultaDetallesTallasImportacion(ByVal idTalla As Int32) As DataTable
        Dim objDa As New Datos.ImportacionArchivosDA
        Dim dtTallas As New DataTable

        dtTallas = objDa.consultaDetallesTallasImportacion(idTalla)
        Return dtTallas
    End Function

    ''funcion para validar el tipo de archivo de imprtacion de cada cliente
    Public Function consultarTipoImportacionArchivoCliente(ByVal idCliente As Int32) As DataTable
        Dim objDa As New Datos.ImportacionArchivosDA
        Dim dtClienteImp As New DataTable

        dtClienteImp = objDa.consultarTipoImportacionArchivoCliente(idCliente)
        Return dtClienteImp
    End Function

    '' funcion para validar codigos clientes importacion archivo
    Public Function validarCodigosClienteImportacion(ByVal codigoRapido As String, ByVal idCliente As Int32, ByVal idAgente As Int32) As DataTable
        Dim objDa As New Datos.ImportacionArchivosDA
        Dim dtCodigos As New DataTable

        dtCodigos = objDa.validarCodigosClienteImportacion(codigoRapido, idCliente, idAgente)
        Return dtCodigos
    End Function
#Region "pakar puebla"
    '' funcion para validar codigos clientes importacion archivo
    Public Function validarCodigosClienteImportacionPakar(ByVal codigoRapido As String, ByVal idCliente As Int32) As DataTable
        Dim objDa As New Datos.ImportacionArchivosDA
        Dim dtCodigos As New DataTable

        dtCodigos = objDa.validarCodigosClienteImportacionPakar(codigoRapido, idCliente)
        Return dtCodigos
    End Function

    ''funcion para validar el codigo de la tienda importacion archivo
    Public Function validarTiendaClienteImportacionPakar(ByVal idCliente As Int32, ByVal idRfc As Int32) As DataTable
        Dim objDa As New Datos.ImportacionArchivosDA
        Dim dtTienda As New DataTable

        dtTienda = objDa.validarTiendaClienteImportacionPakar(idCliente, idRfc)
        Return dtTienda
    End Function

#End Region
    ''funcion para validar el codigo de la tienda importacion archivo
    Public Function validarTiendaClienteImportacion(ByVal idCliente As Int32, ByVal codTienda As String, ByVal idRfc As Int32) As DataTable
        Dim objDa As New Datos.ImportacionArchivosDA
        Dim dtTienda As New DataTable

        dtTienda = objDa.validarTiendaClienteImportacion(idCliente, codTienda, idRfc)
        Return dtTienda
    End Function

    ''funcion para recuperar los modelos e insertarlos en el excel
    Public Function consultaModelosExportarExcel(ByVal idCLiente As Int32, ByVal idMarcas As String) As DataTable
        Dim objDa As New Datos.ImportacionArchivosDA
        Dim dtModelos As New DataTable

        dtModelos = objDa.consultaModelosExportarExcel(idCLiente, idMarcas)

        Return dtModelos
    End Function

    ''funcion para recuperar datos del cliente(exportar a excel)
    Public Function consultaDatosClienteExportar(ByVal idCliente As Int32) As DataTable
        Dim objDa As New Datos.ImportacionArchivosDA
        Dim dtClientes As New DataTable

        dtClientes = objDa.consultaDatosClienteExportar(idCliente)
        Return dtClientes
    End Function

    ''funcion para recuperar ramos del cliente(exportar a excel)
    Public Function consultaRamosClienteExportar(ByVal idCliente As Int32) As DataTable
        Dim objDa As New Datos.ImportacionArchivosDA
        Dim dtRamos As New DataTable
        dtRamos = objDa.consultaRamosClienteExportar(idCliente)

        Return dtRamos
    End Function

    '' funcion para consultar los rfc activos del cliente (exportar a excel)
    Public Function consultaRFCClienteExportar(ByVal idCliente As Int32) As DataTable
        Dim objDa As New Datos.ImportacionArchivosDA
        Dim dtRfc As New DataTable

        dtRfc = objDa.consultaRFCClienteExportar(idCliente)
        Return dtRfc
    End Function

    ''funcion para consultar todas las tiendas activas de un rfc (exportar a excel)
    Public Function consultaTiendasActivasExportar(ByVal idCliente As Int32) As DataTable
        Dim dtTiendas As New DataTable
        Dim objDa As New Datos.ImportacionArchivosDA

        dtTiendas = objDa.consultaTiendasActivasExportar(idCliente)
        Return dtTiendas
    End Function

    ''funcion para consultar los modelos (exportar a excel)
    Public Function consultaCatalogoModeloExportar(ByVal idCliente As Int32, ByVal idMarcas As String) As DataTable
        Dim dtModelos As New DataTable
        Dim objDa As New Datos.ImportacionArchivosDA

        dtModelos = objDa.consultaCatalogoModeloExportar(idCliente, idMarcas)
        Return dtModelos
    End Function

    ''funcion para recuperar la fecha de programacion 
    Public Function consultarFechaProgramacionPedido() As DataTable
        Dim dtFechaProgramacion As New DataTable
        Dim objDa As New Datos.ImportacionArchivosDA

        dtFechaProgramacion = objDa.consultarFechaProgramacionPedido()

        Return dtFechaProgramacion
    End Function

    ''funcion para validar las marcas importacion pedido general
    Public Function validarMarcaImportacionGeneral(ByVal productoEstilo As Int32, ByVal idCliente As Int32, ByVal idAgente As Int32)
        Dim objDa As New Datos.ImportacionArchivosDA
        Dim dtValidacionMar As New DataTable

        dtValidacionMar = objDa.validarMarcaImportacionGeneral(productoEstilo, idCliente, idAgente)

        Return dtValidacionMar
    End Function

    ''funcion para validar los codigos amece importacion de archivos
    Public Function validarCodigosAmeceImportacionArchivos(ByVal productoEstiloId As Int32, ByVal talla As String) As DataTable
        Dim objDa As New Datos.ImportacionArchivosDA
        Dim dtAmece As New DataTable

        dtAmece = objDa.validarCodigosAmeceImportacionArchivos(productoEstiloId, talla)
        Return dtAmece
    End Function

    ''funcion para obtener el producto estilo a partir del codigo de andrea
    Public Function consultaPECodigoAndrea(ByVal idCliente As Int32, ByVal codigocliente As String, ByVal material As String, ByVal color As String) As DataTable
        Dim objDa As New Datos.ImportacionArchivosDA
        Dim dtCodigos As New DataTable

        dtCodigos = objDa.consultaPECodigoAndrea(idCliente, codigocliente, material, color)

        Return dtCodigos
    End Function

    ''funcion para validar los codigos de cliente de andrea 
    Public Function validarCodigoClienteAndrea(ByVal idCliente As Int32, ByVal prodcutoEstilo As Int32, ByVal talla As String) As DataTable
        Dim objDa As New Datos.ImportacionArchivosDA
        Dim dtCodigosAndrea As New DataTable

        dtCodigosAndrea = objDa.validarCodigoClienteAndrea(idCliente, prodcutoEstilo, talla)

        Return dtCodigosAndrea
    End Function

    ''funcion para obtener el producto estilo a partir del codigo amece
    Public Function validarPEAmeceImportacionSears(ByVal codigoAmece As String, ByVal talla As String) As DataTable
        Dim dtPEAmece As New DataTable
        Dim objDa As New Datos.ImportacionArchivosDA

        dtPEAmece = objDa.validarPEAmeceImportacionSears(codigoAmece, talla)

        Return dtPEAmece
    End Function

    ''funcion para validar articulos en lista de precios dependiendo de la fecha de programacion
    Public Function validaListaPreciosFPImportacionSears(ByVal idListaPrecios As Int32, ByVal fechaProgramacion As Date, ByVal productoEstiloId As Int32) As DataTable
        Dim objDa As New Datos.ImportacionArchivosDA
        Dim dtValidaLP As New DataTable

        dtValidaLP = objDa.validaListaPreciosFPImportacionSears(idListaPrecios, fechaProgramacion, productoEstiloId)

        Return dtValidaLP

    End Function

    ''funcion para obtener la tienda en el archivo de importacion de sears
    Public Function validarTecImportacionSears(ByVal clienteRfcId As Int32) As DataTable
        Dim objDa As New Datos.ImportacionArchivosDA
        Dim dtTec As New DataTable

        dtTec = objDa.validarTecImportacionSears(clienteRfcId)

        Return dtTec
    End Function

#Region "Mejoras importacion hermanos batta"

    Public Function insertaEncabezadoArchivoImportacion(ByVal clienteid As Int32, ByVal agenteid As Int32, ByVal listaPreciosid As Int32,
                                                        ByVal rfcid As Int32, ByVal ramoid As Int32, ByVal inicial As Boolean,
                                                        ByVal ordenCliente As String, ByVal entregainmediata As Boolean, ByVal fechaProgramacion As Date,
                                                        ByVal fechaSolicitada As Date, ByVal incotermid As Int32, ByVal observacion As String,
                                                        ByVal rutaid As Int32, ByVal monedaid As Int32, ByVal usuarioid As Int32) As DataTable

        Dim objDa As New Datos.ImportacionArchivosDA
        Dim dtEncabezado As New DataTable

        dtEncabezado = objDa.insertaEncabezadoArchivoImportacion(clienteid, agenteid, listaPreciosid, rfcid, ramoid, inicial, ordenCliente,
                                                               entregainmediata, fechaProgramacion, fechaSolicitada, incotermid,
                                                               observacion, rutaid, monedaid, usuarioid)

        Return dtEncabezado
    End Function

    Public Function insertaDetalleArchivoImportacion(ByVal encabezadoid As Int32, ByVal pedidoCliente As String, ByVal codigorapido As String,
                                                 ByVal nombreTienda As String, ByVal talla As String, ByVal cantidad As Int32) As DataTable

        Dim dtDetalles As New DataTable
        Dim objDa As New Datos.ImportacionArchivosDA

        dtDetalles = objDa.insertaDetalleArchivoImportacion(encabezadoid, pedidoCliente, codigorapido, nombreTienda, talla, cantidad)

        Return dtDetalles
    End Function

    Public Function validaCodigoClienteRelacionadoImpArchivo(ByVal encabezadoImportacionid As Int32) As DataTable
        Dim dtCodigos As New DataTable
        Dim objDa As New Datos.ImportacionArchivosDA

        dtCodigos = objDa.validaCodigoClienteRelacionadoImpArchivo(encabezadoImportacionid)

        Return dtCodigos
    End Function

    Public Function validaMarcaAgenteRelacionadoImpArchivo(ByVal encabezadoImportacionid As Int32) As DataTable
        Dim dtMarcas As New DataTable
        Dim objDa As New Datos.ImportacionArchivosDA

        dtMarcas = objDa.validaMarcaAgenteRelacionadoImpArchivo(encabezadoImportacionid)

        Return dtMarcas
    End Function

    Public Function validaListaPrecioRelacionadoImpArchivo(ByVal encabezadoImportacionid As Int32) As DataTable
        Dim dtLista As New DataTable
        Dim objDa As New Datos.ImportacionArchivosDA

        dtLista = objDa.validaListaPrecioRelacionadoImpArchivo(encabezadoImportacionid)

        Return dtLista
    End Function

    Public Function validaTiendaRelacionadaRFCImpArchivo(ByVal encabezadoImportacionid As Int32) As DataTable
        Dim dtTienda As New DataTable
        Dim objDa As New Datos.ImportacionArchivosDA

        dtTienda = objDa.validaTiendaRelacionadaRFCImpArchivo(encabezadoImportacionid)

        Return dtTienda
    End Function

    Public Function insertaPedidosGeneradosArchivoImp(ByVal encabezadoImportacionid As Int32) As DataTable
        Dim dtPedidos As New DataTable
        Dim objDa As New Datos.ImportacionArchivosDA

        dtPedidos = objDa.insertaPedidosGeneradosArchivoImp(encabezadoImportacionid)

        Return dtPedidos
    End Function

    Public Sub eliminaDatosArchivoLeido(ByVal encabezadoImportacionid As Int32)
        Dim objDa As New Datos.ImportacionArchivosDA

        objDa.eliminaDatosArchivoLeido(encabezadoImportacionid)
    End Sub

    Public Function consultaDetallesArchivoGenerarPedidos(ByVal encabezadoid As Int32) As DataTable
        Dim dtArchivo As New DataTable
        Dim objDa As New Datos.ImportacionArchivosDA

        dtArchivo = objDa.consultaDetallesArchivoGenerarPedidos(encabezadoid)

        Return dtArchivo
    End Function

    Public Function obtenerTiendaImportacionCoppel(ByVal idCliente As Int32) As Int32
        Dim dtTienda As New DataTable
        Dim objDa As New Datos.ImportacionArchivosDA
        Dim idtienda As Int32 = 0
        dtTienda = objDa.obtenerTiendaImportacionCoppel(idCliente)

        If dtTienda.Rows.Count > 0 Then
            idtienda = dtTienda.Rows(0).Item("idTienda")
        End If

        Return idtienda
    End Function
#End Region

End Class
