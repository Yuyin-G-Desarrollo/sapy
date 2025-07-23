Public Class SimulacionBU

    Public Function verOpcionesSimulacion() As DataTable
        Dim objDA As New Datos.SimulacionDA
        Return objDA.verOpcionesSimulacion
    End Function

    Public Function verOpcionesConfiguradasSimulacion(ByVal idSimulacion As Int32) As DataTable
        Dim objDA As New Datos.SimulacionDA
        Return objDA.verOpcionesConfiguradasSimulacion(idSimulacion)
    End Function

    Public Function verConfiguracionOpionesSimulacion(ByVal idOpcion As Int32) As DataTable
        Dim objDA As New Datos.SimulacionDA
        Return objDA.verConfiguracionOpionesSimulacion(idOpcion)
    End Function

    Public Function rangoAnios() As DataTable
        Dim objDA As New Datos.SimulacionDA
        Return objDA.rangoAnios
    End Function

    Public Function consultaDatosUltimaConfiguracion()
        Dim objDA As New Datos.SimulacionDA
        Return objDA.consultaDatosUltimaConfiguracion
    End Function

    Public Sub editarOrdenOpcion(ByVal idOpcion As Int32, ByVal orden As Int32)
        Dim objDA As New Datos.SimulacionDA
        objDA.editarOrdenOpcion(idOpcion, orden)
    End Sub

    Public Sub editaConfiguracionesOrden()
        Dim objDA As New Datos.SimulacionDA
        objDA.editaConfiguracionesOrden()
    End Sub

    Public Sub seleccionarOrdenOpcionConfiguracion(idConfiguracion As Int32)
        Dim objDA As New Datos.SimulacionDA
        objDA.seleccionarOrdenOpcionConfiguracion(idConfiguracion)
    End Sub

    Public Sub inactivarConfiguracionAnterior()
        Dim objDA As New Datos.SimulacionDA
        objDA.inactivarConfiguracionAnterior()
    End Sub

    Public Sub guardarNuevaConfiguracionSimulacion(ByVal descripcion As String, ByVal semanaInicio As Int32, ByVal semanaFin As Int32, ByVal anioinicio As Int32, ByVal anioFin As Int32, ByVal verTodo As Boolean)
        Dim objDA As New Datos.SimulacionDA
        objDA.guardarNuevaConfiguracionSimulacion(descripcion, semanaInicio, semanaFin, anioinicio, anioFin, verTodo)
    End Sub

    Public Function verIdRegistradoConf() As Int32
        Dim objDA As New Datos.SimulacionDA
        Return objDA.verIdRegistradoConf
    End Function

    Public Function consultaSimulacionTemporal() As DataTable
        Dim objDA As New Datos.SimulacionDA
        Return objDA.consultaSimulacionTemporal
    End Function

    Public Function consultaSimulacionTemporalNOProgramados() As DataTable
        Dim objDA As New Datos.SimulacionDA
        Return objDA.consultaSimulacionTemporalNOProgramados()
    End Function

    Public Function obtenerFolio() As Int32
        Dim objDA As New Datos.SimulacionDA
        Return objDA.obtenerFolio
    End Function

    Public Sub guardarRegistroBItacoraSimulacion(ByVal folio As Int32, ByVal idPedido As Int32, ByVal idRenglon As Int32,
                                  ByVal idProducto As Int32, ByVal pares As Int32, ByVal fecha As String,
                                  ByVal mensaje As String, ByVal tipo As String, ByVal pares_faltan As Int32,
                                  ByVal linea As Int32, ByVal prestilo As Int32, ByVal idTalla As Int32,
                                  ByVal origen As String, ByVal simulacionid As Int32, ByVal bita_pdetID As Int32)
        Dim objDA As New Datos.SimulacionDA
        objDA.guardarRegistroBItacoraSimulacion(folio, idPedido, idRenglon, idProducto, pares, fecha, mensaje, tipo, pares, linea,
                                                prestilo, idTalla, origen, simulacionid, bita_pdetID)
    End Sub

    'Public Sub eliminarDatosSimulacionAnterior(ByVal idSimulacionMaestro As Int32)
    '    Dim objDA As New Datos.SimulacionDA
    '    objDA.eliminarDatosSimulacionAnterior(idSimulacionMaestro)
    'End Sub

    Public Function consultaExistenciaCapacidadArticuloAnioSimulacion(ByVal anio As Int32, ByVal semana As Int32,
                                                        ByVal idProd As Int32, ByVal idEstilo As Int32,
                                                        ByVal idTalla As Int32, ByVal idSimulacionMaestro As Int32,
                                                        ByVal simularCambio As Boolean) As DataTable
        Dim objDA As New Datos.SimulacionDA
        Return objDA.consultaExistenciaCapacidadArticuloAnioSimulacion(anio, semana, idProd, idEstilo, idTalla, idSimulacionMaestro, simularCambio)
    End Function

    Public Function consultaExistenciaCapacidadParesXArticuloAnioSimulacion(ByVal anioInicio As Int32, ByVal anioFin As Int32,
                                                           ByVal semanaInicio As Int32, ByVal semanaFin As Int32,
                                                           ByVal idProd As Int32, ByVal idEstilo As Int32,
                                                           ByVal idTalla As Int32, ByVal idSimulacionMaestro As Int32) As DataTable
        Dim objDA As New Datos.SimulacionDA
        Return objDA.consultaExistenciaCapacidadParesXArticuloAnioSimulacion(anioInicio, anioFin, semanaInicio, semanaFin, idProd, idEstilo, idTalla, idSimulacionMaestro)
    End Function

    Public Function consultaCapacidadHormaXArticuloSimulacion(ByVal anio As Int32,
                                                       ByVal semana As Int32,
                                                       ByVal idEstilo As Int32,
                                                       ByVal idTalla As Int32,
                                                       ByVal idLinea As Int32,
                                                       ByVal idHorma As Int32,
                                                       ByVal idSimulacionMaestro As Int32,
                                                       ByVal cambioArticulo As Boolean) As DataTable
        Dim objDA As New Datos.SimulacionDA
        Return objDA.consultaCapacidadHormaXArticuloSimulacion(anio, semana,
                                                               idEstilo, idTalla,
                                                               idLinea, idHorma,
                                                               idSimulacionMaestro,
                                                               cambioArticulo)
    End Function

    Public Function consultaCapacidadLineaProduccionGruposXArticuloSimulacion(ByVal anio As Int32,
                                               ByVal semana As Int32,
                                               ByVal idEstilo As Int32,
                                               ByVal idTalla As Int32,
                                               ByVal idLinea As Int32,
                                               ByVal idGrupo As Int32,
                                               ByVal idSimulacionMaestro As Int32) As DataTable
        Dim objDA As New Datos.SimulacionDA
        Return objDA.consultaCapacidadLineaProduccionGruposXArticuloSimulacion(anio, semana, idEstilo, idTalla, idLinea, idGrupo, idSimulacionMaestro)
    End Function

    Public Function consultaCapacidadLineaProduccionCelulaXArticuloSimulacion(ByVal anio As Int32,
                                                                   ByVal semana As Int32,
                                                                   ByVal idLinea As Int32,
                                                                   ByVal idSimulacionMaestro As Int32,
                                                                    ByVal limiteCapacidad As Boolean) As DataTable
        Dim objDA As New Datos.SimulacionDA
        Return objDA.consultaCapacidadLineaProduccionCelulaXArticuloSimulacion(anio, semana,
                                                                     idLinea, idSimulacionMaestro,
                                                                     limiteCapacidad)
    End Function

    Public Sub guardarRenglonSimulacion(ByVal programaID As Int32, ByVal naveID As Int32, ByVal linpID As Int32, ByVal productoID As Int32,
                                      ByVal productoEstiloID As Int32, ByVal tallaID As Int32, ByVal IdPedido As Int32, ByVal IdRenglon As Int32,
                                      ByVal idLote As Int32, ByVal pdetID As Int32, ByVal anio As Int32, ByVal semana As Int32,
                                      ByVal idCadena As Int32, ByVal fecha_Entrega As String, ByVal pares_apartado As Int32,
                                      ByVal idCliente As Int32, ByVal hormaid As Int32, ByVal ProcSimuladorMaestroID As Int32,
                                      ByVal entregaCliente As String)
        Dim objDA As New Datos.SimulacionDA
        objDA.guardarRenglonSimulacion(programaID, naveID, linpID, productoID,
                                         productoEstiloID, tallaID, IdPedido, IdRenglon,
                                         idLote, pdetID, anio, semana, idCadena, fecha_Entrega, pares_apartado,
                                         idCliente, hormaid, ProcSimuladorMaestroID, entregaCliente)
    End Sub

    Public Function consultaSimulaciones() As DataTable
        Dim objDA As New Datos.SimulacionDA
        Return objDA.consultaSimulaciones
    End Function

    Public Sub truncarTablaTemporalSimulacion()
        Dim objDA As New Datos.SimulacionDA
        objDA.truncarTablaTemporalSimulacion()
    End Sub

    Public Sub truncarTablaSimulacionProceso()
        Dim objDA As New Datos.SimulacionDA
        objDA.truncarTablaSimulacionProceso()
    End Sub
    'Public Sub ordenarTablaTemporalSimulacion(ByVal opcion As Int32, ByVal idSimulacion As Int32)
    '    Dim objDA As New Datos.SimulacionDA
    '    objDA.ordenarTablaTemporalSimulacion(opcion, idSimulacion)
    'End Sub

    Public Sub construirConsulta(ByVal opciones As Int32(), ByVal idSimulacion As Int32)
        Dim objDA As New Datos.SimulacionDA
        objDA.construirConsulta(opciones, idSimulacion)
    End Sub

    Public Sub cargaInicialCatalogos(ByVal idSimulacion As Int32)
        Dim objDA As New Datos.SimulacionDA
        objDA.cargaInicialCatalogos(idSimulacion)
    End Sub

    Public Function consultaListaClientesRankingSimulacion() As DataTable
        Dim objDA As New Datos.SimulacionDA
        Return objDA.consultaListaClientesRankingSimulacion
    End Function

    Public Sub guardarOpcionSimulacion(ByVal idSimulacion As Int32, ByVal idOpcion As Int32, ByVal idConfiguracion As Int32, ByVal orden As Int32)
        Dim objDA As New Datos.SimulacionDA
        objDA.guardarOpcionSimulacion(idSimulacion, idOpcion, idConfiguracion, orden)
    End Sub

    Public Function consultaSimulacionMaestro() As DataTable
        Dim objDA As New Datos.SimulacionDA
        Return objDA.consultaSimulacionMaestro
    End Function

    Public Sub moverDatosTablaHist(ByVal idSimulacion As Int32)
        Dim objDA As New Datos.SimulacionDA
        objDA.moverDatosTablaHist(idSimulacion)
    End Sub

    Public Function consultaFoliosSimulacion() As DataTable
        Dim objDA As New Datos.SimulacionDA
        Return objDA.consultaFoliosSimulacion()
    End Function

    Public Sub eliminarSimulacion(ByVal idSimulacion As Int32, ByVal folio As Int32)
        Dim objDA As New Datos.SimulacionDA
        objDA.eliminarSimulacion(idSimulacion, folio)
    End Sub

    Public Sub quitarPedidosPendientesTmpSimulacion()
        Dim objDA As New Datos.SimulacionDA
        objDA.quitarPedidosPendientesTmpSimulacion()
    End Sub

    Public Sub insertarDatosProgramasRenglonSimulador_SinSimular(ByVal idSimulacion As Int32)
        Dim objDA As New Datos.SimulacionDA
        objDA.insertarDatosProgramasRenglonSimulador_SinSimular(idSimulacion)
    End Sub

    Public Function consultaSimulacionPorSemana(ByVal semanaInicio As Int32, ByVal semanaFin As Int32,
                                                   ByVal anioInicio As Int32, ByVal anioFin As Int32,
                                                   ByVal idNave As Int32, ByVal idLinea As Int32,
                                                   ByVal idFolio As Int32, ByVal idSimulacion As Int32,
                                                   ByVal VerSoloConCantidad As Boolean) As DataTable

        Dim objDA As New Datos.SimulacionDA
        Return objDA.consultaSimulacionPorSemana(semanaInicio, semanaFin, anioInicio, anioFin, idNave, idLinea, idFolio, idSimulacion, VerSoloConCantidad)
    End Function

    Public Function consultaEstatusSimulacionActual() As Boolean
        Dim objDA As New Datos.SimulacionDA
        Return objDA.consultaEstatusSimulacionActual
    End Function

    Public Sub editarEstatusSimulacionActual(ByVal valorBool As Boolean)
        Dim objDA As New Datos.SimulacionDA
        objDA.editarEstatusSimulacionActual(valorBool)
    End Sub

    Public Function consultaPermisoSimulador() As Boolean
        Dim objDA As New Datos.SimulacionDA
        Return objDA.consultaPermisoSimulador
    End Function

    ' ------------------------------------------------------------------------------------------------------------------->
    Public Function consultaExistenciaCapacidadArticuloAnioSimulacion(ByVal idSimulacionMaestro As Int32, ByVal simularCambio As Boolean) As DataTable
        Dim objDA As New Datos.SimulacionDA
        Return objDA.consultaExistenciaCapacidadArticuloAnioSimulacion(idSimulacionMaestro, simularCambio)
    End Function

    Public Function consultaExistenciaHormasCapacidadSimulacion(ByVal idSimulacionMaestro As Int32, ByVal simularCambio As Boolean) As DataTable
        Dim objDA As New Datos.SimulacionDA
        Return objDA.consultaExistenciaHormasCapacidadSimulacion(idSimulacionMaestro, simularCambio)
    End Function

    Public Function consultaExistenciaGruposCapacidadSimulacion() As DataTable
        Dim objDA As New Datos.SimulacionDA
        Return objDA.consultaExistenciaGruposCapacidadSimulacion
    End Function

    Public Function consultaExistenciaLineaProduccionCapacidadSimulacion(ByVal idSimulacion As Int32, ByVal limiteCapacidad As Boolean) As DataTable
        Dim objDA As New Datos.SimulacionDA
        Return objDA.consultaExistenciaLineaProduccionCapacidadSimulacion(idSimulacion, limiteCapacidad)
    End Function
End Class