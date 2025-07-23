Public Class ApartadosBU

    Public Function ListadoParametroApartados(tipo_busqueda As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.ListadoParametroApartados(tipo_busqueda)
        Return tabla
    End Function

    Public Function consultaGenerarApartados(ByVal FiltrosApartados As Entidades.FiltrosGeneracionApartadosPPCP) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaGenerarApartados(FiltrosApartados)
        Return tabla
    End Function

    Public Function consultaParesTallasPartidas(ByVal detallePedidoID As String, ByVal programa As String, ByVal nave As String, ByVal tipoConsulta As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaParesTallasPartidas(detallePedidoID, programa, nave, tipoConsulta)
        Return tabla
    End Function

    Function guardarApartados(ByVal idPedido As Int32, ByVal idPedidoDetalle As String, ByVal fechaPreparacionPedido As String, ByVal idCliente As Integer, ByVal usuarioCaptura As Int32, ByVal observacionApartado As String, ByVal origenApartado As String) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.guardarApartados(idPedido, idPedidoDetalle, fechaPreparacionPedido, idCliente, usuarioCaptura, observacionApartado, origenApartado)
        Return tabla
    End Function
    Function guardarApartadosSICY() As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.guardarApartadosSICY()
        Return tabla
    End Function

    Public Function consultaAdministradorApartados(ByVal FiltrosAdministradorApartados As Entidades.FiltrosAdministradorApartados) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaAdministradorApartados(FiltrosAdministradorApartados)
        Return tabla
    End Function

    Public Function consultaAdministradorApartadosConTallas(ByVal FiltrosAdministradorApartados As Entidades.FiltrosAdministradorApartados) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaAdministradorApatadosConTallas(FiltrosAdministradorApartados)
        Return tabla
    End Function

    Public Function priorizarApartadosPrimeraVez(ByVal ApartadosIds As String) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.priorizarApartadosPrimeraVez(ApartadosIds)
        Return tabla
    End Function

    Public Function priorizarApartadosUrgencias(ByVal ApartadosIds As String) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.priorizarApartadosUrgencias(ApartadosIds)
        Return tabla
    End Function

    Public Function priorizarNuevamenteApartados(ByVal ApartadosIds As String) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.priorizarNuevamenteApartados(ApartadosIds)
        Return tabla
    End Function

    Public Function editarDatosApartado(ByVal apartadoId As String, ByVal tipoModificacion As Integer, ByVal fechaPreparacion As String, ByVal operadorAsignado As Integer, ByVal observacionesApartado As String, ByVal UsuarioModifico As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.editarDatosApartado(apartadoId, tipoModificacion, fechaPreparacion, operadorAsignado, observacionesApartado, UsuarioModifico)
        Return tabla
    End Function

    Public Function consultarDetallesPartidasApartados(ByVal apartadosIds As String, ByVal totalApartados As Integer, ByVal consolidacion As Integer, ByVal conExistencia As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.consultarDetallesPartidasApartados(apartadosIds, totalApartados, consolidacion, conExistencia)
        Return tabla
    End Function

    Public Function consultarDetallesParesApartados(ByVal apartadosIds As String, ByVal consolidacion As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.consultarDetallesParesApartados(apartadosIds, consolidacion)
        Return tabla
    End Function

    Public Function consultaMotivosCancelacion() As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaMotivosCancelacion()
        Return tabla
    End Function

    Public Function cancelarApartados(ByVal apartadosCancelar As String, ByVal motivosCancelacion As String, ByVal observacionesCancelacion As String, ByVal usuarioId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.cancelarApartados(apartadosCancelar, motivosCancelacion, observacionesCancelacion, usuarioId)
        Return tabla
    End Function

    Public Function cancelarPartidas(ByVal partidasCancelar As String, ByVal motivosCancelacion As String, ByVal observacionesCancelacion As String, ByVal usuarioId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.cancelarPartidas(partidasCancelar, motivosCancelacion, observacionesCancelacion, usuarioId)
        objDA.cancelarPartidasSICY(partidasCancelar, motivosCancelacion, observacionesCancelacion, usuarioId)

        Return tabla
    End Function

    Public Function consultaApartadosCanceladosDia(ByVal tipoConsulta As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaApartadosCanceladosDia(tipoConsulta)
        Return tabla
    End Function

    Public Function consultaCorreosEnvioCancelacion(ByVal ClaveEnvio As String) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaCorreosEnvioCancelacion(ClaveEnvio)
        Return tabla
    End Function

    Public Function busquedaPartidasApartadosParaCorreoCancelacion(ByVal idApartadoOPartida As Integer, ByVal TipoBusqueda As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.busquedaPartidasApartadosParaCorreoCancelacion(idApartadoOPartida, TipoBusqueda)
        Return tabla
    End Function

    Public Function imprimirOrdenApartado(ByVal idApartados As String, ByVal TipoBusqueda As Integer, ByVal Consolidado As Boolean) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.imprimirOrdenApartado(idApartados, TipoBusqueda, Consolidado)
        Return tabla
    End Function

    Public Function imprimirOrdenApartadoTotalUbicacionTallas(ByVal idApartados As String, ByVal tallas As String, ByVal Consolidado As Boolean, ByVal Corridas As String) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.imprimirOrdenApartadoTotalUbicacionTallas(idApartados, tallas, Consolidado, Corridas)
        Return tabla
    End Function


#Region "CONFIRMACIÓN APARTADO"

    Public Function validaAtadoLeidoConfirmacion(ByVal NumeroAtado As String)
        Dim objDa As New Datos.ApartadosDA
        Return objDa.validaAtadoLeidoConfirmacion(NumeroAtado)
    End Function

    Public Function ValidarParLeidoConfirmacion(ByVal codigo As String, ByVal atado As Boolean) As List(Of Entidades.ParesConfirmarApartado)
        Dim objDa As New Datos.ApartadosDA
        Dim tabla As New DataTable
        Dim DetallePar As New Entidades.ParesConfirmarApartado
        Dim listaPares As New List(Of Entidades.ParesConfirmarApartado)
        tabla = objDa.ValidarParLeidoConfirmacion(codigo, atado)
        If tabla.Rows.Count > 0 Then
            For Each row As DataRow In tabla.Rows
                DetallePar = New Entidades.ParesConfirmarApartado
                DetallePar.PPar = row.Item("ID_Par")
                DetallePar.PAtado = row.Item("ID_Docena")
                'DetallePar.PPartidaPedido = row.Item("idtblPartida")
                'DetallePar.PPartidaApartado = row.Item("idtblPedido")
                DetallePar.PTalla = row.Item("Talla")
                DetallePar.PLote = row.Item("Lote")
                DetallePar.PDescripcion = row.Item("Descripcion")
                DetallePar.PNave = row.Item("Nave")
                DetallePar.PEntradaAlmacen = row.Item("EntradaAlmacen")
                DetallePar.PAño = row.Item("Año")
                DetallePar.PIdProducto = row.Item("Producto")
                DetallePar.PIdNave = row.Item("IdNave")
                listaPares.Add(DetallePar)
            Next
        End If
        Return listaPares
    End Function

    Public Function consultarDatosApartadoAConfirmar(ByVal apartadoId As String) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.consultarDatosApartadoAConfirmar(apartadoId)
        Return tabla
    End Function

    Public Function InsertarParConfirmado(ByVal Par As Entidades.ParesConfirmarApartado, ByVal apartadoDetallePorTallaId As Integer, ByVal colaboradorConfirmoId As Integer, ByVal apartadoSICY As Integer, ByVal pedidoSICY As Integer, ByVal IdCadena As Integer) As Integer
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim resultado As Integer = 0
        resultado = objDA.InsertarParConfirmado(Par, apartadoDetallePorTallaId, colaboradorConfirmoId, apartadoSICY, pedidoSICY, IdCadena)
        Return resultado
    End Function

    Public Function ActualizaPartidasYApartadosDespuesDeConfirmacion(ByVal idApartado As Integer, ByVal colaboradorConfirmoId As Integer) As Integer
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim resultado As Integer = 0
        resultado = objDA.ActualizaPartidasYApartadosDespuesDeConfirmacion(idApartado, colaboradorConfirmoId)
        Return resultado
    End Function


    Public Function consultarParesDisponiblesApartado(ByVal ApartadoId As String) As DataTable
        Dim objDA As New Datos.ApartadosDA
        Dim resultado As New DataTable
        resultado = objDA.consultarParesDisponiblesApartado(ApartadoId)
        Return resultado
    End Function

    Public Function ConfirmacionIncompleta(ByVal ApartadoId As Integer, ByVal UsuarioId As Integer, ByVal Observacion As String) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.ConfirmacionIncompleta(ApartadoId, UsuarioId, Observacion)
        Return tabla
    End Function


#End Region

    Public Function verificaDisponibilidadApartar(ByVal EstatusGenerandoApartado As Integer, ByVal Usuario As String, ByVal Origen As String) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.verificaDisponibilidadApartar(EstatusGenerandoApartado, Usuario, Origen)
        Return tabla
    End Function

    Public Function consultaCorreosEnvioConfirmacionIncompleta(ByVal ClaveEnvio As String) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaCorreosEnvioConfirmacionIncompleta(ClaveEnvio)
        Return tabla
    End Function

    Public Function validarParesPorConfirmarArchivoCargado(ByVal CodigosEscaneados As String, ByVal ApartadosEscaneados As String, ByVal TiposCodigosEscaneados As String, ByVal TipoConsulta As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.validarParesPorConfirmarArchivoCargado(CodigosEscaneados, ApartadosEscaneados, TiposCodigosEscaneados, TipoConsulta)
        Return tabla
    End Function

    Public Function ConsultaCorreoUsuarioCaptura(ByVal IdApartado As String) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultaCorreoUsuarioCaptura(IdApartado)
        Return tabla
    End Function

    Public Function consultaInventarioDisponible(cedis As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaInventarioDisponible(cedis)
        Return tabla
    End Function

    Public Function consultaPrioridadClientesApartar() As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaPrioridadClientesApartar()
        Return tabla
    End Function

    Public Function modificarPrioridadesClientesApartar(ByVal Cliente As String, ByVal Prioridad As String, ByVal SolicitaRespuesta As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.modificarPrioridadesClientesApartar(Cliente, Prioridad, SolicitaRespuesta)
        Return tabla
    End Function


    Public Sub verDisponibilidadGenerarApartado(ByVal PedidosDetalles As String, ByVal Naves As String, ByVal Programas As String)
        Dim objDA As New Ventas.Datos.ApartadosDA
        objDA.verDisponibilidadGenerarApartado(PedidosDetalles, Naves, Programas)
    End Sub

    Public Sub generarInventarioDisponible()
        Dim objDA As New Ventas.Datos.ApartadosDA
        objDA.generarInventarioDisponible()
    End Sub

    Public Sub generarDistribucionApartados()
        Dim objDA As New Ventas.Datos.ApartadosDA
        objDA.generarDistribucionApartados()
    End Sub

    Public Function seleccionarPartidasConDistribucion(ByVal tipoConsulta As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Return objDA.seleccionarPartidasConDistribucion(tipoConsulta)
    End Function

    Public Sub actualizarApartadosPorGenerar(ByVal filtrosGenerarApartados As Entidades.FiltrosGeneracionApartadosPPCP)
        Dim objDA As New Ventas.Datos.ApartadosDA
        objDA.actualizarApartadosPorGenerar(filtrosGenerarApartados)
    End Sub

    Public Sub actualizarTotalesDistribucionPartidasPorGenerar()
        Dim objDA As New Ventas.Datos.ApartadosDA
        objDA.actualizarTotalesDistribucionPartidasPorGenerar()
    End Sub

    Public Sub RegenerarDistribucionPartidasModificadas(ByVal filtrosGenerarApartados As Entidades.FiltrosGeneracionApartadosPPCP)
        Dim objDA As New Ventas.Datos.ApartadosDA
        objDA.RegenerarDistribucionPartidasModificadas(filtrosGenerarApartados)
    End Sub

    Public Sub ModificacionesPartidas(ByVal pedidoDetallesId As String, ByVal NaveId As String, ByVal ProgramaId As String, ByVal tipoActualizacion As Integer)
        Dim objDA As New Ventas.Datos.ApartadosDA
        objDA.ModificacionesPartidas(pedidoDetallesId, NaveId, ProgramaId, tipoActualizacion)
    End Sub

    Public Function consultaParesDistribucionPartida(ByVal detallePedidoID As String, ByVal NaveIdSAY As Integer, ByVal ProgramaId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaParesDistribucionPartida(detallePedidoID, NaveIdSAY, ProgramaId)
        Return tabla
    End Function

    Public Sub modificarTotalesTallasPartidas(ByVal detallePedidoID As Integer, ByVal Tallas As String, ByVal TotalesTallas As String, ByVal NaveId As Integer, ByVal ProgramaId As Integer)
        Dim objDA As New Ventas.Datos.ApartadosDA
        objDA.modificarTotalesTallasPartidas(detallePedidoID, Tallas, TotalesTallas, NaveId, ProgramaId)
    End Sub

    Public Function guardarApartadosPPCP(ByVal apartadoInsertar As Entidades.ApartadoPorGenerar_PPCP) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Return objDA.guardarApartadosPPCP(apartadoInsertar)
    End Function

    Public Sub RegenerarDistribucionPartidasModificadasM3(ByVal filtrosGenerarApartados As Entidades.FiltrosGeneracionApartadosPPCP, ByVal PedidoDetalleID As Integer, ByVal NaveId As Integer, ByVal ProgramaId As Integer)
        Dim objDA As New Ventas.Datos.ApartadosDA
        objDA.RegenerarDistribucionPartidasModificadasM3(filtrosGenerarApartados, PedidoDetalleID, NaveId, ProgramaId)
    End Sub

    Public Function consultaResumenApartadosGenerados(ByVal tipoConsulta As Integer, ByVal apartadosGenerados As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaResumenApartadosGenerados(tipoConsulta, apartadosGenerados)
        Return tabla
    End Function

    Function descontarParesDeLotesA() As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.descontarParesDeLotesA()
        Return tabla
    End Function

    Function crearRespaldoLotesProgramasEnSAY() As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.crearRespaldoLotesProgramasEnSAY()
        Return tabla
    End Function

    Public Sub actualizarTallasDesdeLotesA(ByVal idPedidosPartidasId As Integer, ByVal idPedido As Integer, ByVal idPartida As Integer, ByVal idPrograma As Integer, ByVal idNave As Integer)
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.actualizarTallasDesdeLotesA(idPedidosPartidasId, idPedido, idPartida, idPrograma, idNave)
        'Return tabla
    End Sub

    Public Function ListadoParametroApartadosPPCP(tipo_busqueda As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.ListadoParametroApartadosPPCP(tipo_busqueda)
        Return tabla
    End Function

    Function crearInventarioInicialTemporal() As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.crearInventarioInicialTemporal()
        Return tabla
    End Function

    Public Function seleccionarInventarioDisponibleInicial() As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.seleccionarInventarioDisponibleInicial()
        Return tabla
    End Function

    Public Sub InsertarInventarioDisponibleInicial_original(ByVal CodigoSICY As String, ByVal IdCorridaSICY As String, ByVal Corrida As String, ByVal Talla As String, ByVal IdTallaSAY As Integer, ByVal Pares As Integer, ByVal ProductoEstilo As Integer, ByVal Descripcion As String)
        Dim objDA As New Ventas.Datos.ApartadosDA
        objDA.InsertarInventarioDisponibleInicial_Original(CodigoSICY, IdCorridaSICY, Corrida, Talla, IdTallaSAY, Pares, ProductoEstilo, Descripcion)
    End Sub

    Public Sub InsertarInventarioDisponibleInicial_V2(ByVal CodigoSICY As String, ByVal IdCorridaSICY As String, ByVal Corrida As String, ByVal Talla As String, ByVal IdTallaSAY As String, ByVal Pares As String, ByVal ProductoEstilo As String, ByVal Descripcion As String)
        Dim objDA As New Ventas.Datos.ApartadosDA
        objDA.InsertarInventarioDisponibleInicial_V2(CodigoSICY, IdCorridaSICY, Corrida, Talla, IdTallaSAY, Pares, ProductoEstilo, Descripcion)
    End Sub

    Public Sub InsertarInventarioDisponibleInicial()
        Dim objDA As New Ventas.Datos.ApartadosDA
        objDA.InsertarInventarioDisponibleInicial()
    End Sub

    Public Function SeleccionarDatosLotesProgramas(ByVal FiltrosApartados As Entidades.FiltrosGeneracionApartadosPPCP) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.SeleccionarDatosLotesProgramas(FiltrosApartados)
        Return tabla
    End Function

    Public Sub InsertarDatosLotesProgramas_original(ByVal IdPedido As Integer, ByVal IdPartida As Integer, ByVal IdNave As Integer, ByVal programalote As Integer, ByVal estatusLote As String, ByVal CantLotesA As Integer, ByVal FechaPrograma As String,
     ByVal EstatusPrograma As String, ByVal LT01 As Integer, ByVal LT02 As Integer, ByVal LT03 As Integer, ByVal LT04 As Integer, ByVal LT05 As Integer, ByVal LT06 As Integer, ByVal LT07 As Integer, ByVal LT08 As Integer, ByVal LT09 As Integer,
     ByVal LT10 As Integer, ByVal LT11 As Integer, ByVal LT12 As Integer, ByVal LT13 As Integer, ByVal LT14 As Integer, ByVal LT15 As Integer, ByVal LT16 As Integer, ByVal LT17 As Integer, ByVal LT18 As Integer, ByVal LT19 As Integer,
     ByVal LT20 As Integer, ByVal TallaId As String, ByVal CodigoSICY As String)
        Dim objDA As New Ventas.Datos.ApartadosDA
        objDA.InsertarDatosLotesProgramas_v2(IdPedido, IdPartida, IdNave, programalote, estatusLote, CantLotesA, FechaPrograma,
      EstatusPrograma, LT01, LT02, LT03, LT04, LT05, LT06, LT07, LT08, LT09, LT10, LT11, LT12, LT13, LT14, LT15, LT16, LT17, LT18, LT19,
      LT20, TallaId, CodigoSICY)
    End Sub

    Public Sub InsertarDatosLotesProgramas_v2(ByVal IdPedido As String, ByVal IdPartida As String, ByVal IdNave As String, ByVal programalote As String, ByVal estatusLote As String, ByVal CantLotesA As String, ByVal FechaPrograma As String,
     ByVal EstatusPrograma As String, ByVal LT01 As String, ByVal LT02 As String, ByVal LT03 As String, ByVal LT04 As String, ByVal LT05 As String, ByVal LT06 As String, ByVal LT07 As String, ByVal LT08 As String, ByVal LT09 As String,
     ByVal LT10 As String, ByVal LT11 As String, ByVal LT12 As String, ByVal LT13 As String, ByVal LT14 As String, ByVal LT15 As String, ByVal LT16 As String, ByVal LT17 As String, ByVal LT18 As String, ByVal LT19 As String,
     ByVal LT20 As String, ByVal TallaId As String, ByVal CodigoSICY As String)
        Dim objDA As New Ventas.Datos.ApartadosDA
        objDA.InsertarDatosLotesProgramas_v2(IdPedido, IdPartida, IdNave, programalote, estatusLote, CantLotesA, FechaPrograma,
      EstatusPrograma, LT01, LT02, LT03, LT04, LT05, LT06, LT07, LT08, LT09, LT10, LT11, LT12, LT13, LT14, LT15, LT16, LT17, LT18, LT19,
      LT20, TallaId, CodigoSICY)
    End Sub

    Public Sub InsertarDatosLotesProgramas(ByVal FiltrosApartados As Entidades.FiltrosGeneracionApartadosPPCP)
        Dim objDA As New Ventas.Datos.ApartadosDA
        objDA.InsertarDatosLotesProgramas(FiltrosApartados)
    End Sub
    Public Sub consultaGenerarVistaFiltrar(ByVal FiltrosApartados As Entidades.FiltrosGeneracionApartadosPPCP)
        Dim objDA As New Ventas.Datos.ApartadosDA

        objDA.consultaGenerarVistaFiltrar(FiltrosApartados)
    End Sub

    Public Function obtenerUltimoApartadoGenerado() As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA

        Return objDA.obtenerUltimoApartadoGenerado()
    End Function

    Public Sub separarPartidasApartadas(ByVal pedidos As String, ByVal pedidosDetalles As String, ByVal naves As String, ByVal programas As String)
        Dim objDA As New Ventas.Datos.ApartadosDA

        objDA.separarPartidasApartadas(pedidos, pedidosDetalles, naves, programas)
    End Sub

    Public Sub limpiarModificacionAnteriorRegenerarDistribucion()
        Dim objDA As New Ventas.Datos.ApartadosDA

        objDA.limpiarModificacionAnteriorRegenerarDistribucion()
    End Sub

    Public Sub distribucionApartadosPorGenerar(ByVal filtrosGenerarApartados As Entidades.FiltrosGeneracionApartadosPPCP)
        Dim objDA As New Ventas.Datos.ApartadosDA
        objDA.distribucionApartadosPorGenerar(filtrosGenerarApartados)
    End Sub

    Public Function obtenerTotalApartadosPorConfirmar(ByVal tipoConsulta As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA

        Return objDA.obtenerTotalApartadosPorConfirmar(tipoConsulta)
    End Function

    Public Function obtenerTotalParesPorConfirmar(ByVal tipoConsulta As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA

        Return objDA.obtenerTotalParesPorConfirmar(tipoConsulta)
    End Function

    Public Function resumenDisponibilidadClientes() As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA

        Return objDA.resumenDisponibilidadClientes()
    End Function

    Public Function actualizarInventarioTotalesDisponibles() As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA

        Return objDA.actualizarInventarioTotalesDisponibles()
    End Function

    Public Function asignarDisponibilidadSinDistribucionApartados() As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA

        Return objDA.asignarDisponibilidadSinDistribucionApartados()
    End Function

    Public Sub actualizarTotalesDistribucionPartidasPorGenerarSinDistribucion()
        Dim objDA As New Ventas.Datos.ApartadosDA
        objDA.actualizarTotalesDistribucionPartidasPorGenerarSinDistribucion()
    End Sub

    Public Function reasignarDisponibilidadSinDistribucionApartados() As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA

        Return objDA.reasignarDisponibilidadSinDistribucionApartados()
    End Function

    Public Function descartarPartidasDeDistribucion(ByVal partidasDescartarDeApartados As String) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA

        Return objDA.descartarPartidasDeDistribucion(partidasDescartarDeApartados)
    End Function

    Public Sub consultaGenerarApartadosResumenClientes(ByVal FiltrosApartados As Entidades.FiltrosGeneracionApartadosPPCP)
        Dim objDA As New Ventas.Datos.ApartadosDA

        objDA.consultaGenerarApartadosResumenClientes(FiltrosApartados)
    End Sub

    Public Function ActualizaPartidasYApartadosAntesDeConfirmacion(ByVal idApartado As Integer) As Integer
        Dim objDA As New Ventas.Datos.ApartadosDA

        Return objDA.ActualizaPartidasYApartadosAntesDeConfirmacion(idApartado)
    End Function

    Public Function priorizarApartadosProspecta(ByVal ApartadosIds As String) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.priorizarApartadosProspecta(ApartadosIds)
        Return tabla
    End Function

    Public Function verificarDistribucionApartadosPorConfirmar() As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.verificarDistribucionApartadosPorConfirmar()
        Return tabla
    End Function

    Public Function validaApartadosPorCancelarEnOT(ByVal apartadosIds As String) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.validaApartadosPorCancelarEnOT(apartadosIds)
        Return tabla
    End Function

    Public Function obtenerParesEntregadosPorApartado(ByVal apartadosIds As String) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.obtenerParesEntregadosPorApartado(apartadosIds)
        Return tabla
    End Function

    Public Function obtenerParesEntregadosPorPartida(ByVal apartadosIds As String, ByVal partidasIds As String) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.obtenerParesEntregadosPorPartida(apartadosIds, partidasIds)
        Return tabla
    End Function

    Public Function obtenerPartidaApartadoEnOrdenTrabajo(ByVal apartadosIds As String, ByVal partidasIds As String) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.obtenerPartidaApartadoEnOrdenTrabajo(apartadosIds, partidasIds)
        Return tabla
    End Function

    Public Function consultaPerfilUsuario(ByVal usuarioId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaPerfilUsuario(usuarioId)

        Return tabla

    End Function
    Public Function Replicacion_TmpdocenasPares() As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.Replicacion_TmpdocenasPares()

        Return tabla

    End Function

    Public Function cancelarApartado(ByVal ApartadoID As Integer, ByVal motivosCancelacion As Integer, ByVal observacionesCancelacion As String, ByVal usuarioId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.cancelarApartado(ApartadoID, motivosCancelacion, observacionesCancelacion, usuarioId)

        Return tabla
    End Function

    Public Function cancelarApartadoSICY(ByVal ApartadoID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.cancelarApartadoSICY(ApartadoID)

        Return tabla
    End Function

    Public Function EnviarParesCanceladosApartadoAProgramar(ByVal ApartadoID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.EnviarParesCanceladosApartadoAProgramar(ApartadoID)

        Return tabla
    End Function


    Public Function CancelarPartidaApartado(ByVal ApartadoID As Integer, ByVal Apartadodetalle As Integer, ByVal motivosCancelacion As Integer, ByVal observacionesCancelacion As String, ByVal usuarioId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.CancelarPartidaApartado(ApartadoID, Apartadodetalle, motivosCancelacion, observacionesCancelacion, usuarioId)

        Return tabla
    End Function

    Public Function cancelarPartidaApartadoSICY(ByVal ApartadoID As Integer, ByVal ApartadoDetalleid As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.cancelarPartidaApartadoSICY(ApartadoID, ApartadoDetalleid)

        Return tabla
    End Function

    Public Function EnviarParesCanceladosPartidaApartadoAProgramar(ByVal ApartadoID As Integer, ByVal ApartadoDetalleid As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ApartadosDA
        Dim tabla As New DataTable
        tabla = objDA.EnviarParesCanceladosPartidaApartadoAProgramar(ApartadoID, ApartadoDetalleid)

        Return tabla
    End Function

    Public Sub CalculoApartados(entidadApartado As Entidades.ApartadoPorGenerar_PPCP, Optional apartado As String = "")
        Dim objDA As New Datos.ApartadosDA
        objDA.CalculoApartados(entidadApartado, apartado)
    End Sub

End Class
