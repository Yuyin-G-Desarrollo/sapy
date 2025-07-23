Imports ToolServicios
Imports Entidades

Public Class ReportesPedidosBU
    ''consulta de reporte general de pedidos
    Public Function consultaReporteGeneralPedidos(ByVal estatusProgramacion As String, ByVal estatusFechaE As String, ByVal tipoCondicion As String,
                                                  ByVal estatusPedido As String, ByVal estatusPartida As String, ByVal idCliente As String,
                                                  ByVal idAgente As String, ByVal idAtencion As String, ByVal idRamos As String, ByVal marcas As String,
                                                  ByVal coleccionMarca As String, ByVal modelo As String, ByVal corrida As String, ByVal piel As String,
                                                  ByVal color As String, ByVal familia As String, ByVal tec As String, ByVal pedidoInicial As Boolean, ByVal pedidoResutido As Boolean,
                                                  ByVal pedidoSay As String, ByVal pedidoSicy As String, ByVal fechaCaptura As Boolean, ByVal fechaCapturaInicio As Date,
                                                  ByVal fechaCapturaFin As Date, ByVal fechaSolicitada As Boolean, ByVal fechaSolicitadaInicio As Date,
                                                  ByVal fechaSolicitadaFin As Date, ByVal fechaProgramacion As Boolean, ByVal fechaProgramacionInicio As Date,
                                                  ByVal fechaProgramacionFin As Date, ByVal idusuario As String, ByVal NaveUsuaruio As String) As DataTable

        Dim objDa As New Datos.ReportesPedidosDA
        Dim dtReporte As New DataTable

        dtReporte = objDa.consultaReporteGeneralPedidos(estatusProgramacion, estatusFechaE, tipoCondicion, estatusPedido, estatusPartida, idCliente, idAgente,
                                                     idAtencion, idRamos, marcas, coleccionMarca, modelo, corrida, piel, color, familia, tec, pedidoInicial, pedidoResutido,
                                                     pedidoSay, pedidoSicy, fechaCaptura, fechaCapturaInicio, fechaCapturaFin, fechaSolicitada, fechaSolicitadaInicio,
                                                     fechaSolicitadaFin, fechaProgramacion, fechaProgramacionInicio, fechaProgramacionFin, idusuario, NaveUsuaruio)
        Return dtReporte
    End Function

    ''consulta con el listado de marcas(filtro reportes pedido)
    Public Function consultaListadoMarcas() As DataTable
        Dim dtMarcas As New DataTable
        Dim objDa As New Datos.ReportesPedidosDA

        dtMarcas = objDa.consultaListadoMarcas()

        Return dtMarcas
    End Function

    ''consulta con el listado de atencion a clientes(filtro reportes pedido)
    Public Function consultaListadoAtencionClientes()
        Dim dtAtencion As New DataTable
        Dim objDa As New Datos.ReportesPedidosDA

        dtAtencion = objDa.consultaListadoAtencionClientes()
        Return dtAtencion
    End Function

    ''consulta con el listado de ramos(filtro reportes pedido)
    Public Function consultaListadoRamos()
        Dim dtRamos As New DataTable
        Dim objDa As New Datos.ReportesPedidosDA

        dtRamos = objDa.consultaListadoRamos

        Return dtRamos
    End Function

    ''consulta con el listado de colecciones(filtro reportes pedido)
    Public Function consultaListadoColecciones()
        Dim dtColecciones As New DataTable
        Dim objDa As New Datos.ReportesPedidosDA

        dtColecciones = objDa.consultaListadoColecciones

        Return dtColecciones
    End Function

    ''consulta con el listado de modelos (filtro reportes pedido)
    Public Function consultaListadoModelos()
        Dim dtModelos As New DataTable
        Dim objDa As New Datos.ReportesPedidosDA

        dtModelos = objDa.consultaListadoModelos

        Return dtModelos
    End Function

    ''consulta con el listado de modelos (filtro reportes pedido)
    Public Function consultaListadoCorridas()
        Dim dtCorridas As New DataTable
        Dim objDa As New Datos.ReportesPedidosDA

        dtCorridas = objDa.consultaListadoCorridas

        Return dtCorridas
    End Function

    ''consulta con el listado de pieles (filtro reportes pedido)
    Public Function consultaListadoPieles()
        Dim dtPieles As New DataTable
        Dim objDa As New Datos.ReportesPedidosDA

        dtPieles = objDa.consultaListadoPieles

        Return dtPieles
    End Function

    ''consulta con el listado de colores (filtro reportes pedido)
    Public Function consultaListadoColores()
        Dim dtColores As New DataTable
        Dim objDa As New Datos.ReportesPedidosDA

        dtColores = objDa.consultaListadoColores

        Return dtColores
    End Function

    ''consulta con el listado de clientes tec (filtro reportes pedido)
    Public Function consultaListadoClienteTec()
        Dim dtTec As New DataTable
        Dim objDa As New Datos.ReportesPedidosDA

        dtTec = objDa.consultaListadoClienteTec

        Return dtTec
    End Function

    ''consulta con el listado de clientes tec (filtro reportes pedido)
    Public Function consultaListadoNaves()
        Dim dtNaves As New DataTable
        Dim objDa As New Datos.ReportesPedidosDA

        dtNaves = objDa.consultaListadoNaves

        Return dtNaves
    End Function

    ''consulta reporte detallado simplificado
    Public Function consultaReporteDetalladoSimplificado(ByVal verTallas As Boolean, ByVal estatusProgramacion As String, ByVal estatusFechaEntrega As String,
                                                         ByVal tipoCondicion As String, ByVal estatusPedido As String, ByVal estatusPartida As String,
                                                         ByVal idCliente As String, ByVal idAgente As String, ByVal idAtencion As String, ByVal idRamos As String,
                                                         ByVal Marcas As String, ByVal coleccionMarca As String, ByVal modelo As String, ByVal corrida As String,
                                                         ByVal piel As String, ByVal color As String, ByVal familia As String, ByVal TEC As String, ByVal pedidoInicial As String,
                                                         ByVal pedidoResurtido As String, ByVal pedidoSay As String, ByVal pedidoSicy As String,
                                                         ByVal fechaCaptura As Boolean, ByVal fechaCapturaInicio As Date, ByVal fechaCapturaFin As Date,
                                                         ByVal fechaSolicitada As Boolean, ByVal fechaSolicitadaInicio As Date, ByVal fechaSolicitadaFin As Date,
                                                         ByVal fechaProgramacion As Boolean, ByVal fechaProgramacionInicio As Date, ByVal fechaProgramacionFin As Date, ByVal idusuario As String,
                                                         ByVal NaveUsuaruio As String) As DataTable

        Dim dtConsultaSimplificado As New DataTable
        Dim objDa As New Datos.ReportesPedidosDA

        dtConsultaSimplificado = objDa.consultaReporteDetalladoSimplificado(verTallas, estatusProgramacion, estatusFechaEntrega, tipoCondicion, estatusPedido, estatusPartida,
                                                                            idCliente, idAgente, idAtencion, idRamos, Marcas, coleccionMarca, modelo, corrida, piel, color, familia, TEC,
                                                                            pedidoInicial, pedidoResurtido, pedidoSay, pedidoSicy, fechaCaptura, fechaCapturaInicio,
                                                                            fechaCapturaFin, fechaSolicitada, fechaSolicitadaInicio, fechaSolicitadaFin, fechaProgramacion,
                                                                            fechaProgramacionInicio, fechaProgramacionFin, idusuario, NaveUsuaruio)

        Return dtConsultaSimplificado
    End Function

    ''consulta reporte detallado completo
    Public Function consultaReporteDetalladoCompleto(ByVal verTallas As Boolean, ByVal estatusProgramacion As String, ByVal estatusFechaEntrega As String,
                                                        ByVal tipoCondicion As String, ByVal estatusPedido As String, ByVal estatusPartida As String,
                                                        ByVal idCliente As String, ByVal idAgente As String, ByVal idAtencion As String, ByVal idRamos As String,
                                                        ByVal Marcas As String, ByVal coleccionMarca As String, ByVal modelo As String, ByVal corrida As String,
                                                        ByVal piel As String, ByVal color As String, ByVal familia As String, ByVal TEC As String, ByVal pedidoInicial As String,
                                                        ByVal pedidoResurtido As String, ByVal pedidoSay As String, ByVal pedidoSicy As String,
                                                        ByVal fechaCaptura As Boolean, ByVal fechaCapturaInicio As Date, ByVal fechaCapturaFin As Date,
                                                        ByVal fechaSolicitada As Boolean, ByVal fechaSolicitadaInicio As Date, ByVal fechaSolicitadaFin As Date,
                                                        ByVal fechaProgramacion As Boolean, ByVal fechaProgramacionInicio As Date, ByVal fechaProgramacionFin As Date,
                                                        ByVal deptoLote As String, ByVal numeroLote As String, ByVal aniolote As String, ByVal naveLote As String,
                                                        ByVal fechaProgramacionLote As Boolean, ByVal fechaProgramacionLoteInicio As Date, ByVal fechaProgramacionLoteFin As Date,
                                                        ByVal fechaLlegadaLote As Boolean, ByVal fechaLlegadaLoteInicio As Date, ByVal fechaLlegadaLoteFin As Date, ByVal idusuario As String, ByVal NaveUsuaruio As String) As DataTable
        Dim dtConsultaCompleto As New DataTable
        Dim objDa As New Datos.ReportesPedidosDA

        dtConsultaCompleto = objDa.consultaReporteDetalladoCompleto(verTallas, estatusProgramacion, estatusFechaEntrega, tipoCondicion, estatusPedido, estatusPartida,
                                                                            idCliente, idAgente, idAtencion, idRamos, Marcas, coleccionMarca, modelo, corrida, piel, color, familia, TEC,
                                                                            pedidoInicial, pedidoResurtido, pedidoSay, pedidoSicy, fechaCaptura, fechaCapturaInicio,
                                                                            fechaCapturaFin, fechaSolicitada, fechaSolicitadaInicio, fechaSolicitadaFin, fechaProgramacion,
                                                                            fechaProgramacionInicio, fechaProgramacionFin, deptoLote, numeroLote, aniolote, naveLote, fechaProgramacionLote,
                                                                            fechaProgramacionLoteInicio, fechaProgramacionLoteFin, fechaLlegadaLote, fechaLlegadaLoteInicio, fechaLlegadaLoteFin, idusuario, NaveUsuaruio)

        Return dtConsultaCompleto

    End Function


    ''consulta reporte por fechas
    Public Function consultaReportePorFechas(ByVal fechaBase As String, ByVal visualizar As String, ByVal estatusProgramacion As String, ByVal estatusFechaE As String, ByVal tipoCondicion As String,
                                              ByVal estatusPedido As String, ByVal estatusPartida As String, ByVal idCliente As String,
                                              ByVal idAgente As String, ByVal idAtencion As String, ByVal idRamos As String, ByVal marcas As String,
                                              ByVal coleccionMarca As String, ByVal modelo As String, ByVal corrida As String, ByVal piel As String,
                                              ByVal color As String, ByVal familia As String, ByVal tec As String, ByVal pedidoInicial As Boolean, ByVal pedidoResutido As Boolean,
                                              ByVal pedidoSay As String, ByVal pedidoSicy As String, ByVal fechaCaptura As Boolean, ByVal fechaCapturaInicio As Date,
                                              ByVal fechaCapturaFin As Date, ByVal fechaSolicitada As Boolean, ByVal fechaSolicitadaInicio As Date,
                                              ByVal fechaSolicitadaFin As Date, ByVal fechaProgramacion As Boolean, ByVal fechaProgramacionInicio As Date,
                                              ByVal fechaProgramacionFin As Date, ByVal idusuario As String, ByVal NaveUsuaruio As String) As DataTable

        Dim objDa As New Datos.ReportesPedidosDA
        Dim dtReporte As New DataTable

        dtReporte = objDa.consultaReportePorFechas(fechaBase, visualizar, estatusProgramacion, estatusFechaE, tipoCondicion, estatusPedido, estatusPartida, idCliente, idAgente,
                                                     idAtencion, idRamos, marcas, coleccionMarca, modelo, corrida, piel, color, familia, tec, pedidoInicial, pedidoResutido,
                                                     pedidoSay, pedidoSicy, fechaCaptura, fechaCapturaInicio, fechaCapturaFin, fechaSolicitada, fechaSolicitadaInicio,
                                                     fechaSolicitadaFin, fechaProgramacion, fechaProgramacionInicio, fechaProgramacionFin, idusuario, NaveUsuaruio)
        Return dtReporte

    End Function

    ''funcion para consultar la lista de los clientes todos
    Public Function consultaClientesTodos(ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.ReportesPedidosDA
        Dim dtClientes As New DataTable

        dtClientes = objDa.consultaClientesTodos(idUsuario)

        Return dtClientes
    End Function
#Region "ventas reporte estadisticas"

    Public Function consultaListadoColeccionesEstadVentas()
        Dim dtColecciones As New DataTable
        Dim objDa As New Datos.ReportesPedidosDA

        dtColecciones = objDa.consultaListadoColeccionesEstadVentas

        Return dtColecciones
    End Function

    Public Function consultaClientesTodosRPTVENTAS(ByVal idUsuario As Int32) As DataTable
        Dim objDa As New Datos.ReportesPedidosDA
        Dim dtClientes As New DataTable

        dtClientes = objDa.consultaClientesTodosRPTVENTAS(idUsuario)

        Return dtClientes
    End Function

    Public Function consultaReporteGeneralVentas(ByVal idCliente As String,
                                                 ByVal idAgente As String,
                                                 ByVal marcas As String,
                                                 ByVal familias As String,
                                                 ByVal colecciones As String,
                                                 ByVal fechaInicio As Date,
                                                 ByVal fechaFin As Date, ByVal idusuario As String, ByVal NaveUsuaruio As String) As DataTable

        Dim objDa As New Datos.ReportesPedidosDA
        Dim dtReporte As New DataTable

        dtReporte = objDa.consultaReporteEstadisticoVentas(idCliente, idAgente, marcas, familias, colecciones, fechaInicio, fechaFin, idusuario, NaveUsuaruio)
        Return dtReporte
    End Function

    Public Function consultaReporteGeneralVentas2(ByVal idCliente As String,
                                                ByVal idAgente As String,
                                                ByVal marcas As String,
                                                ByVal familias As String,
                                                ByVal colecciones As String,
                                                ByVal fechaInicio As Date,
                                                ByVal fechaFin As Date, ByVal idusuario As String, ByVal NaveUsuario As String) As DataTable

        Dim objDa As New Datos.ReportesPedidosDA
        Dim dtReporte As New DataTable

        dtReporte = objDa.consultaReporteEstadisticoVentas2(idCliente, idAgente, marcas, familias, colecciones, fechaInicio, fechaFin, idusuario, NaveUsuario)
        Return dtReporte
    End Function

    Public Function consultaListadoFamilias() As DataTable
        Dim dtMarcas As New DataTable
        Dim objDa As New Datos.ReportesPedidosDA

        dtMarcas = objDa.consultaListadoFamilias()

        Return dtMarcas
    End Function

    Public Function consultaReporteEstadVentasCliFam(ByVal idCliente As String,
                                             ByVal idAgente As String,
                                             ByVal marcas As String,
                                             ByVal familias As String,
                                             ByVal colecciones As String,
                                             ByVal fechaInicio As Date,
                                             ByVal fechaFin As Date, ByVal idusuario As String,
                                                     ByVal NaveUsuario As String) As DataTable

        Dim objDa As New Datos.ReportesPedidosDA
        Dim dtReporte As New DataTable

        dtReporte = objDa.consultaReporteEstadisticoVentasClienteFamilia(idCliente, idAgente, marcas, familias, colecciones, fechaInicio, fechaFin, idusuario, NaveUsuario )
        Return dtReporte
    End Function
    Public Function consultaReporteEstadVentasFamCliente(ByVal idCliente As String,
                                      ByVal idAgente As String,
                                      ByVal marcas As String,
                                      ByVal familias As String,
                                      ByVal colecciones As String,
                                      ByVal fechaInicio As Date,
                                      ByVal fechaFin As Date, ByVal idusuario As String) As DataTable

        Dim objDa As New Datos.ReportesPedidosDA
        Dim dtReporte As New DataTable

        dtReporte = objDa.consultaReporteEstadisticoVentasFamiliaCliente(idCliente, idAgente, marcas, familias, colecciones, fechaInicio, fechaFin, idusuario)
        Return dtReporte
    End Function


    Public Function bitacora_reporte_venta(ByVal Exportado_a As String,
                                             ByVal Aplicacion As String,
                                             ByVal tipoReporte As String,
                                             ByVal fechaInicio As Date,
                                             ByVal fechaFin As Date, ByVal idusuario As String)

        Dim objDa As New Datos.ReportesPedidosDA
        Dim dtReporte As New DataTable

        dtReporte = objDa.bitacora_reporte_venta(Exportado_a, Aplicacion, tipoReporte, fechaInicio, fechaFin, idusuario)
        Return dtReporte
    End Function

    Public Function bitacoraReporteVentaWEB(ByVal Exportado_a As String,
                                             ByVal Aplicacion As String,
                                             ByVal tipoReporte As String,
                                             ByVal fechaInicio As Date,
                                             ByVal fechaFin As Date, ByVal idusuario As String) As RespuestaRestArray
        Dim objDa As New Datos.ReportesPedidosDA
        Dim respuesta = New RespuestaRestArray
        Dim objConvertidor As New Convertidor(Of Entidades.PedidoMuestra)()
        Dim tabla As DataTable

        Try
            tabla = objDa.bitacora_reporte_venta(Exportado_a, Aplicacion, tipoReporte, fechaInicio, fechaFin, idusuario)
            respuesta.respuesta = ResultadoServicio.Correcto
            respuesta.aviso = MensajesPedidosMuestra.CNSInsercionPedidoMuestra
            respuesta.mensaje = objConvertidor.DataTableToArray(0, tabla)
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorInsercionPedidoMuestra
            respuesta.mensaje = Nothing
        Finally
            objDa = Nothing
        End Try
        Return respuesta
    End Function

#End Region
End Class
