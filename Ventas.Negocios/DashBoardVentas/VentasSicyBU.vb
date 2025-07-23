Public Class VentasSicyBU
    Public Function verListaClasificacionesSicy() As DataTable
        Dim objVentSicyDA As New Datos.VentasSicyDA
        Return objVentSicyDA.verListaClasificacionesSicy
    End Function

    Public Function verListaClientesSicy() As DataTable
        Dim objVentSicyDA As New Datos.VentasSicyDA
        Return objVentSicyDA.verListaClientesSicy
    End Function

    Public Function verListaClientesSicyPorAgente(ByVal idAgenteColabora As Int32) As DataTable
        Dim objVentSicyDA As New Datos.VentasSicyDA
        Return objVentSicyDA.verListaClientesSicyPorAgente(idAgenteColabora)
    End Function

    Public Function verListaAgentesSicy() As DataTable
        Dim objVentSicyDA As New Datos.VentasSicyDA
        Return objVentSicyDA.verListaAgentesSicy
    End Function

    Public Function verListaModelosSicy() As DataTable
        Dim objVentSicyDA As New Datos.VentasSicyDA
        Return objVentSicyDA.verListaModelosSicy
    End Function

    Public Function verListaDescripcionesSicy() As DataTable
        Dim objVentSicyDA As New Datos.VentasSicyDA
        Return objVentSicyDA.verListaDescripcionesSicy
    End Function

    Public Function verListaMarcasSicy() As DataTable
        Dim objVentSicyDA As New Datos.VentasSicyDA
        Return objVentSicyDA.verListaMarcasSicy
    End Function

    Public Function verListaColeccionesSicy() As DataTable
        Dim objVentSicyDA As New Datos.VentasSicyDA
        Return objVentSicyDA.verListaColeccionesSicy
    End Function

    Public Function verListaCorridasSicy() As DataTable
        Dim objVentSicyDA As New Datos.VentasSicyDA
        Return objVentSicyDA.verListaCorridasSicy
    End Function

    Public Function verListaColoresSicy() As DataTable
        Dim objVentSicyDA As New Datos.VentasSicyDA
        Return objVentSicyDA.verListaColoresSicy
    End Function

    Public Function verListaRutasSicy() As DataTable
        Dim objVentSicyDA As New Datos.VentasSicyDA
        Return objVentSicyDA.verListaRutasSicy()
    End Function

    Public Function agenteReporteFiltro(ByVal colaboradorId As Int32) As DataTable
        Dim objVentSicyDA As New Datos.VentasSicyDA
        Return objVentSicyDA.agenteReporteFiltro(colaboradorId)
    End Function

    Public Function verListaCategorias() As DataTable
        Dim objVentSicyDA As New Datos.VentasSicyDA
        Return objVentSicyDA.verListaCategorias()
    End Function

    Public Function ListarFamilias() As DataTable
        Dim objVentSicyDA As New Datos.VentasSicyDA
        Return objVentSicyDA.ListarFamilias()
    End Function

    Public Function generarConsultaDash(ByVal filas As String, ByVal columnas As String, ByVal fechaUno As String, ByVal fechaDos As String,
                                           ByVal clasificacion As String, ByVal clientes As String, ByVal agentes As String, ByVal marcas As String,
                                           ByVal colecciones As String, ByVal modelos As String, ByVal descripcion As String, ByVal corrida As String,
                                           ByVal familias As String, ByVal categoria As String, ByVal color As String, ByVal ruta As String, ByVal radioYO As String,
                                           ByVal operaciones As String, ByVal usuario As String, ByVal ubicacion As String) As DataTable

        Dim objVentSicyDA As New Datos.VentasSicyDA
        Dim objAccionesBu As New Framework.Negocios.AccionesBU
        Dim accionId As Int32 = objAccionesBu.BuscarAccion("READ", "VENT_RPTS_TACT")
        Return objVentSicyDA.generarConsultaDash(filas, columnas, fechaUno, fechaDos, clasificacion, clientes, agentes, marcas, colecciones, modelos, descripcion, corrida, familias, categoria, color, ruta, radioYO, operaciones, accionId, usuario, ubicacion)
    End Function

    Public Function generarConsultaDash(ByVal filas As String, ByVal columnas As String, ByVal fechaUno As String,
                                        ByVal fechaDos As String, ByVal clasificacion As String, ByVal clientes As String,
                                        ByVal agentes As String, ByVal marcas As String, ByVal colecciones As String,
                                        ByVal modelos As String, ByVal descripcion As String, ByVal corrida As String,
                                        ByVal familias As String, ByVal categoria As String, ByVal color As String,
                                        ByVal ruta As String, ByVal radioYO As String, ByVal operaciones As String,
                                        ByVal usuario As String, ByVal ubicacion As String, ByVal conAgente As Boolean,
                                        ByVal vistaAgente As String) As DataTable
        Dim objVentSicyDA As New Datos.VentasSicyDA
        Dim objAccionesBu As New Framework.Negocios.AccionesBU
        Dim accionId As Int32 = objAccionesBu.BuscarAccion("READ", "VENT_RPTS_TACT")
        Return objVentSicyDA.generarConsultaDash(filas, columnas, fechaUno, fechaDos, clasificacion, clientes, agentes, marcas, colecciones, modelos, descripcion, corrida, familias, categoria, color, ruta, radioYO, operaciones, accionId, usuario, ubicacion, conAgente, vistaAgente)
    End Function

    Public Function generarConsultaFechas(ByVal filas As String, ByVal tipoReporte As String, ByVal fechaUno As String, ByVal fechaDos As String,
                                           ByVal clasificacion As String, ByVal clientes As String, ByVal agentes As String, ByVal marcas As String,
                                           ByVal colecciones As String, ByVal modelos As String, ByVal descripcion As String, ByVal corrida As String,
                                           ByVal familias As String, ByVal categoria As String, ByVal Ruta As String, ByVal Color As String,
                                           ByVal radioYO As String, ByVal operaciones As String, ByVal usuario As String, ByVal ubicacion As String) As DataTable
        Dim objVentSicyDA As New Datos.VentasSicyDA
        Dim objAccionesBu As New Framework.Negocios.AccionesBU
        Dim accionId As Int32 = objAccionesBu.BuscarAccion("READ", "VENT_RPTS_TACT")
        Return objVentSicyDA.generarConsultaFechas(filas, tipoReporte, fechaUno, fechaDos, clasificacion, clientes, agentes, marcas, colecciones, modelos, descripcion, corrida, familias, categoria, Ruta, Color, radioYO, operaciones, accionId, usuario, ubicacion)
    End Function

    Public Function generarConsultaFechas(ByVal filas As String, ByVal tipoReporte As String, ByVal fechaUno As String, ByVal fechaDos As String,
                                           ByVal clasificacion As String, ByVal clientes As String, ByVal agentes As String, ByVal marcas As String,
                                           ByVal colecciones As String, ByVal modelos As String, ByVal descripcion As String, ByVal corrida As String,
                                           ByVal familias As String, ByVal categoria As String, ByVal Ruta As String, ByVal Color As String,
                                           ByVal radioYO As String, ByVal operaciones As String, ByVal usuario As String, ByVal ubicacion As String, ByVal conAgente As Boolean, ByVal vistaAgente As String) As DataTable
        Dim objVentSicyDA As New Datos.VentasSicyDA
        Dim objAccionesBu As New Framework.Negocios.AccionesBU
        Dim accionId As Int32 = objAccionesBu.BuscarAccion("READ", "VENT_RPTS_TACT")
        Return objVentSicyDA.generarConsultaFechas(filas, tipoReporte, fechaUno, fechaDos, clasificacion, clientes, agentes, marcas, colecciones, modelos, descripcion, corrida, familias, categoria, Ruta, Color, radioYO, operaciones, accionId, usuario, ubicacion, conAgente, vistaAgente)
    End Function

    Public Function listaNavesDesarrolla() As DataTable
        Dim objVentSicyDA As New Datos.VentasSicyDA
        Return objVentSicyDA.listaNavesDesarrolla()
    End Function


    Public Function generarConsultaFechas_Agentes_SAY(ByVal filas As String, ByVal tipoReporte As String, ByVal fechaUno As String, ByVal fechaDos As String,
                                          ByVal clasificacion As String, ByVal clientes As String, ByVal agentes As String, ByVal marcas As String,
                                          ByVal colecciones As String, ByVal modelos As String, ByVal descripcion As String, ByVal corrida As String,
                                          ByVal familias As String, ByVal categoria As String, ByVal Ruta As String, ByVal Color As String,
                                          ByVal radioYO As String, ByVal operaciones As String, ByVal usuario As String, ByVal ubicacion As String, ByVal conAgente As Boolean, ByVal vistaAgente As String) As DataTable
        Dim objVentSicyDA As New Datos.VentasSicyDA
        Dim objAccionesBu As New Framework.Negocios.AccionesBU
        Dim accionId As Int32 = objAccionesBu.BuscarAccion("READ", "VENT_RPTS_TACT")
        Return objVentSicyDA.generarConsultaFechas_Agentes_SAY(filas, tipoReporte, fechaUno, fechaDos, clasificacion, clientes, agentes, marcas, colecciones, modelos, descripcion, corrida, familias, categoria, Ruta, Color, radioYO, operaciones, accionId, usuario, ubicacion, conAgente, vistaAgente)
    End Function

    Public Function generarConsultaDashAgente_SAY(ByVal filas As String, ByVal columnas As String, ByVal fechaUno As String,
                                        ByVal fechaDos As String, ByVal clasificacion As String, ByVal clientes As String,
                                        ByVal agentes As String, ByVal marcas As String, ByVal colecciones As String,
                                        ByVal modelos As String, ByVal descripcion As String, ByVal corrida As String,
                                        ByVal familias As String, ByVal categoria As String, ByVal color As String,
                                        ByVal ruta As String, ByVal radioYO As String, ByVal operaciones As String,
                                        ByVal usuario As String, ByVal ubicacion As String, ByVal conAgente As Boolean,
                                        ByVal vistaAgente As String) As DataTable
        Dim objVentSicyDA As New Datos.VentasSicyDA
        Dim objAccionesBu As New Framework.Negocios.AccionesBU
        Dim accionId As Int32 = objAccionesBu.BuscarAccion("READ", "VENT_RPTS_TACT")
        Return objVentSicyDA.generarConsultaDashAgente_SAY(filas, columnas, fechaUno, fechaDos, clasificacion, clientes, agentes, marcas, colecciones, modelos, descripcion, corrida, familias, categoria, color, ruta, radioYO, operaciones, accionId, usuario, ubicacion, conAgente, vistaAgente)
    End Function
End Class
