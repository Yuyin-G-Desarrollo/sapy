Imports EntidadesFachada
Imports Entidades
Imports Ventas.Datos
Imports ToolServicios

Public Class ReportesSapicaBU
    ''consulta de las familia de ventas  pantalla de filtros
    Public Function listadoFamiliaVentas() As DataTable
        Dim objDa As New Datos.ReportesSapicaDA
        Dim dtFamilias As New DataTable

        dtFamilias = objDa.listadoFamiliaVentas()

        Return dtFamilias
    End Function

    ''consulta de los estatus de las partidas pantalla filtros
    Public Function listadoEstatusPartidas() As DataTable
        Dim objDa As New Datos.ReportesSapicaDA
        Dim dtPartidas As New DataTable

        dtPartidas = objDa.listadoEstatusPartidas

        Return dtPartidas
    End Function

    ''consulta del reporte de pares por familia
    Public Function reporteParesPorFamilia(ByVal idEvento As Int32, ByVal visitantes As String, ByVal clientes As String, ByVal atendio As String, ByVal marcas As String,
                                           ByVal coleccion As String, ByVal familiaVentas As String, ByVal modelo As String, ByVal corrida As String,
                                           ByVal piel As String, ByVal color As String, ByVal estatusPartida As String, ByVal fechaCaptura As Int32,
                                           ByVal fechaCapturaInicio As String, ByVal fechaCapturaFin As String, ByVal fechaProgramacion As Int32,
                                           ByVal fechaProgramacionInicio As String, ByVal fechaProgramacionFin As String, ByVal tipoCondicion As String) As DataTable

        Dim objDa As New Datos.ReportesSapicaDA
        Dim dtParesFamila As New DataTable

        dtParesFamila = objDa.reporteParesPorFamilia(idEvento, visitantes, clientes, atendio, marcas, coleccion, familiaVentas, modelo, corrida,
                                                     piel, color, estatusPartida, fechaCaptura, fechaCapturaInicio, fechaCapturaFin,
                                                     fechaProgramacion, fechaProgramacionInicio, fechaProgramacionFin, tipoCondicion)

        Return dtParesFamila
    End Function

    ''consulta del reporte de pares por marca
    Public Function reporteParesPorMarca(ByVal idEvento As Int32, ByVal visitantes As String, ByVal clientes As String, ByVal atendio As String, ByVal marcas As String,
                                           ByVal coleccion As String, ByVal familiaVentas As String, ByVal modelo As String, ByVal corrida As String,
                                           ByVal piel As String, ByVal color As String, ByVal estatusPartida As String, ByVal fechaCaptura As Int32,
                                           ByVal fechaCapturaInicio As String, ByVal fechaCapturaFin As String, ByVal fechaProgramacion As Int32,
                                           ByVal fechaProgramacionInicio As String, ByVal fechaProgramacionFin As String, ByVal tipoCondicion As String) As DataTable

        Dim objDa As New Datos.ReportesSapicaDA
        Dim dtParesFamila As New DataTable

        dtParesFamila = objDa.reporteParesPorMarca(idEvento, visitantes, clientes, atendio, marcas, coleccion, familiaVentas, modelo, corrida,
                                                     piel, color, estatusPartida, fechaCaptura, fechaCapturaInicio, fechaCapturaFin,
                                                     fechaProgramacion, fechaProgramacionInicio, fechaProgramacionFin, tipoCondicion)

        Return dtParesFamila
    End Function

    ''consulta del reporte de pares por corrida
    Public Function reporteParesPorCorrida(ByVal idEvento As Int32, ByVal visitantes As String, ByVal clientes As String, ByVal atendio As String, ByVal marcas As String,
                                           ByVal coleccion As String, ByVal familiaVentas As String, ByVal modelo As String, ByVal corrida As String,
                                           ByVal piel As String, ByVal color As String, ByVal estatusPartida As String, ByVal fechaCaptura As Int32,
                                           ByVal fechaCapturaInicio As String, ByVal fechaCapturaFin As String, ByVal fechaProgramacion As Int32,
                                           ByVal fechaProgramacionInicio As String, ByVal fechaProgramacionFin As String, ByVal tipoCondicion As String) As DataTable

        Dim objDa As New Datos.ReportesSapicaDA
        Dim dtParesFamila As New DataTable

        dtParesFamila = objDa.reporteParesPorCorrida(idEvento, visitantes, clientes, atendio, marcas, coleccion, familiaVentas, modelo, corrida,
                                                     piel, color, estatusPartida, fechaCaptura, fechaCapturaInicio, fechaCapturaFin,
                                                     fechaProgramacion, fechaProgramacionInicio, fechaProgramacionFin, tipoCondicion)

        Return dtParesFamila
    End Function

    ''consulta listado de marcas
    Public Function listadoMarcas() As DataTable
        Dim dtMarcas As New DataTable
        Dim objDa As New Datos.ReportesSapicaDA

        dtMarcas = objDa.listadoMarcas()
        Return dtMarcas
    End Function

    ''consulta del reporte de pares por familia coleccion
    Public Function reporteParesPorFamiliaColeccion(ByVal idEvento As Int32, ByVal visitantes As String, ByVal clientes As String, ByVal atendio As String, ByVal marcas As String,
                                           ByVal coleccion As String, ByVal familiaVentas As String, ByVal modelo As String, ByVal corrida As String,
                                           ByVal piel As String, ByVal color As String, ByVal estatusPartida As String, ByVal fechaCaptura As Int32,
                                           ByVal fechaCapturaInicio As String, ByVal fechaCapturaFin As String, ByVal fechaProgramacion As Int32,
                                           ByVal fechaProgramacionInicio As String, ByVal fechaProgramacionFin As String, ByVal tipoCondicion As String) As DataTable

        Dim objDa As New Datos.ReportesSapicaDA
        Dim dtParesFamila As New DataTable

        dtParesFamila = objDa.reporteParesPorFamiliaColeccion(idEvento, visitantes, clientes, atendio, marcas, coleccion, familiaVentas, modelo, corrida,
                                                     piel, color, estatusPartida, fechaCaptura, fechaCapturaInicio, fechaCapturaFin,
                                                     fechaProgramacion, fechaProgramacionInicio, fechaProgramacionFin, tipoCondicion)

        Return dtParesFamila
    End Function

    ''consulta del reporte de pares por coleccion modelo
    Public Function reporteParesPorColeccionModelo(ByVal idEvento As Int32, ByVal visitantes As String, ByVal clientes As String, ByVal atendio As String, ByVal marcas As String,
                                           ByVal coleccion As String, ByVal familiaVentas As String, ByVal modelo As String, ByVal corrida As String,
                                           ByVal piel As String, ByVal color As String, ByVal estatusPartida As String, ByVal fechaCaptura As Int32,
                                           ByVal fechaCapturaInicio As String, ByVal fechaCapturaFin As String, ByVal fechaProgramacion As Int32,
                                           ByVal fechaProgramacionInicio As String, ByVal fechaProgramacionFin As String, ByVal tipoCondicion As String) As DataTable

        Dim objDa As New Datos.ReportesSapicaDA
        Dim dtParesColeccion As New DataTable

        dtParesColeccion = objDa.reporteParesPorColeccionModelo(idEvento, visitantes, clientes, atendio, marcas, coleccion, familiaVentas, modelo, corrida,
                                                     piel, color, estatusPartida, fechaCaptura, fechaCapturaInicio, fechaCapturaFin,
                                                     fechaProgramacion, fechaProgramacionInicio, fechaProgramacionFin, tipoCondicion)

        Return dtParesColeccion
    End Function

    ''consulta del reporte de pares por coleccion corrida
    Public Function reporteParesPorColeccionCorrida(ByVal idEvento As Int32, ByVal visitantes As String, ByVal clientes As String, ByVal atendio As String, ByVal marcas As String,
                                           ByVal coleccion As String, ByVal familiaVentas As String, ByVal modelo As String, ByVal corrida As String,
                                           ByVal piel As String, ByVal color As String, ByVal estatusPartida As String, ByVal fechaCaptura As Int32,
                                           ByVal fechaCapturaInicio As String, ByVal fechaCapturaFin As String, ByVal fechaProgramacion As Int32,
                                           ByVal fechaProgramacionInicio As String, ByVal fechaProgramacionFin As String, ByVal tipoCondicion As String) As DataTable

        Dim objDa As New Datos.ReportesSapicaDA
        Dim dtParesColeccion As New DataTable

        dtParesColeccion = objDa.reporteParesPorColeccionCorrida(idEvento, visitantes, clientes, atendio, marcas, coleccion, familiaVentas, modelo, corrida,
                                                     piel, color, estatusPartida, fechaCaptura, fechaCapturaInicio, fechaCapturaFin,
                                                     fechaProgramacion, fechaProgramacionInicio, fechaProgramacionFin, tipoCondicion)

        Return dtParesColeccion
    End Function

    ''consulta del reporte de pares por coleccion piel color
    Public Function reporteParesPorColeccionPielColor(ByVal idEvento As Int32, ByVal visitantes As String, ByVal clientes As String, ByVal atendio As String, ByVal marcas As String,
                                           ByVal coleccion As String, ByVal familiaVentas As String, ByVal modelo As String, ByVal corrida As String,
                                           ByVal piel As String, ByVal color As String, ByVal estatusPartida As String, ByVal fechaCaptura As Int32,
                                           ByVal fechaCapturaInicio As String, ByVal fechaCapturaFin As String, ByVal fechaProgramacion As Int32,
                                           ByVal fechaProgramacionInicio As String, ByVal fechaProgramacionFin As String, ByVal tipoCondicion As String) As DataTable

        Dim objDa As New Datos.ReportesSapicaDA
        Dim dtParesColeccion As New DataTable

        dtParesColeccion = objDa.reporteParesPorColeccionPielColor(idEvento, visitantes, clientes, atendio, marcas, coleccion, familiaVentas, modelo, corrida,
                                                     piel, color, estatusPartida, fechaCaptura, fechaCapturaInicio, fechaCapturaFin,
                                                     fechaProgramacion, fechaProgramacionInicio, fechaProgramacionFin, tipoCondicion)

        Return dtParesColeccion
    End Function

    ''consulta reporte de visitas
    Public Function reporteVisitas(ByVal idEvento As Int32, ByVal fechaCaptura As Int32, ByVal fechaCapturaInicio As String, ByVal fechaCapturaFin As String) As DataTable
        Dim objDa As New Datos.ReportesSapicaDA
        Dim dtVisitas As New DataTable

        dtVisitas = objDa.reporteVisitas(idEvento, fechaCaptura, fechaCapturaInicio, fechaCapturaFin)

        Return dtVisitas
    End Function

    ''conuslta reporte comparativo
    Public Function reporteComparativo(ByVal idEvento As Int32, ByVal fechaCaptura As Int32, ByVal fechaCapturaInicio As String,
                                       ByVal fechaCapturaFin As String) As DataTable

        Dim objDa As New Datos.ReportesSapicaDA
        Dim dtComparativo As New DataTable

        dtComparativo = objDa.reporteComparativo(idEvento, fechaCaptura, fechaCapturaInicio, fechaCapturaFin)

        Return dtComparativo
    End Function

    ''consulta reporte partidas
    Public Function reportePartidas(ByVal idEvento As Int32, ByVal visitantes As String, ByVal clientes As String, ByVal atendio As String, ByVal marcas As String,
                                           ByVal coleccion As String, ByVal familiaVentas As String, ByVal modelo As String, ByVal corrida As String,
                                           ByVal piel As String, ByVal color As String, ByVal estatusPartida As String, ByVal fechaCaptura As Int32,
                                           ByVal fechaCapturaInicio As String, ByVal fechaCapturaFin As String, ByVal fechaProgramacion As Int32,
                                           ByVal fechaProgramacionInicio As String, ByVal fechaProgramacionFin As String, ByVal tipoCondicion As String)


        Dim objDa As New Datos.ReportesSapicaDA
        Dim dtPartidas As New DataTable

        dtPartidas = objDa.reportePartidas(idEvento, visitantes, clientes, atendio, marcas, coleccion, familiaVentas, modelo, corrida,
                                                     piel, color, estatusPartida, fechaCaptura, fechaCapturaInicio, fechaCapturaFin,
                                                     fechaProgramacion, fechaProgramacionInicio, fechaProgramacionFin, tipoCondicion)

        Return dtPartidas
    End Function


    ''consulta listado visitantes
    Public Function consultalistadoVisitantes(ByVal opcionFiltro As Int32, ByVal filtro As String) As DataTable
        Dim objDa As New Datos.ReportesSapicaDA
        Dim dtVisitantes As New DataTable

        dtVisitantes = objDa.consultalistadoVisitantes(opcionFiltro, filtro)

        Return dtVisitantes
    End Function


    ''consulta listado de eventos
    Public Function listadoEventos() As DataTable
        Dim dtEventos As New DataTable
        Dim objDa As New Datos.ReportesSapicaDA

        dtEventos = objDa.listadoEventos()
        Return dtEventos
    End Function

    ''consulta listado de colecciones
    Public Function listadoColecciones() As DataTable
        Dim dtColecciones As New DataTable
        Dim objDa As New Datos.ReportesSapicaDA

        dtColecciones = objDa.listadoColecciones()
        Return dtColecciones
    End Function


    ''consulta listado de modelos
    Public Function listadoModelos() As DataTable
        Dim dtModelos As New DataTable
        Dim objDa As New Datos.ReportesSapicaDA

        dtModelos = objDa.listadoModelos()
        Return dtModelos
    End Function

#Region "Reporte Mensula de Ventas"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="usuarioId"></param>
    ''' <param name="fechaInicio"></param>
    ''' <param name="fechaFin"></param>
    ''' <param name="clientesIdSay"></param>
    ''' <param name="AgentesId"></param>
    ''' <param name="MarcasId"></param>
    ''' <param name="FamiliasId"></param>
    ''' <param name="coleccionesId"></param>
    ''' <returns></returns>
    Public Function ReporteVtaMensualClienteFamArreglo(ByVal usuarioId As Int32, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal clientesIdSay As String, ByVal AgentesId As String, ByVal MarcasId As String, ByVal FamiliasId As String, ByVal coleccionesId As String) As RespuestaRestArray
        Dim objReporteVentasDA = New ReportesSapicaDA()
        Dim respuesta = New RespuestaRestArray
        Dim objConvertidor As New Convertidor(Of Entidades.PedidoMuestra)()
        Dim tabla As DataTable

        Try
            tabla = objReporteVentasDA.ConsultaReporteVtaMensualClienteFamilia(usuarioId, fechaInicio, fechaFin, clientesIdSay, AgentesId, MarcasId, FamiliasId, coleccionesId)
            respuesta.respuesta = ResultadoServicio.Correcto
            respuesta.aviso = MensajesPedidosMuestra.CNSInsercionPedidoMuestra
            respuesta.mensaje = objConvertidor.DataTableToArray(0, tabla)
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorInsercionPedidoMuestra
            respuesta.mensaje = Nothing
        Finally
            objReporteVentasDA = Nothing
        End Try
        Return respuesta
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="usuarioId"></param>
    ''' <param name="fechaInicio"></param>
    ''' <param name="fechaFin"></param>
    ''' <param name="clientesIdSay"></param>
    ''' <param name="AgentesId"></param>
    ''' <param name="MarcasId"></param>
    ''' <param name="FamiliasId"></param>
    ''' <param name="coleccionesId"></param>
    ''' <returns></returns>
    Public Function ReporteVtaMensualConcentradoTotal(ByVal usuarioId As Int32, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal clientesIdSay As String, ByVal AgentesId As String, ByVal MarcasId As String, ByVal FamiliasId As String, ByVal coleccionesId As String) As RespuestaRestArray
        Dim objReporteVentasDA = New ReportesSapicaDA()
        Dim respuesta = New RespuestaRestArray
        Dim objConvertidor As New Convertidor(Of Entidades.PedidoMuestra)()
        Dim tabla As DataTable

        Try
            tabla = objReporteVentasDA.ConsultaReporteVtaMensualConcentradoTotal(usuarioId, fechaInicio, fechaFin, clientesIdSay, AgentesId, MarcasId, FamiliasId, coleccionesId)
            respuesta.respuesta = ResultadoServicio.Correcto
            respuesta.aviso = MensajesPedidosMuestra.CNSInsercionPedidoMuestra
            respuesta.mensaje = objConvertidor.DataTableToArray(0, tabla)
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorInsercionPedidoMuestra
            respuesta.mensaje = Nothing
        Finally
            objReporteVentasDA = Nothing
        End Try
        Return respuesta
    End Function
#End Region
End Class
