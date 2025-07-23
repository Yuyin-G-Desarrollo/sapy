Public Class ProgramasBU

    Public Function importarProgramasRenglon(ByVal fechaInicio As Date, ByVal fechaFin As Date) As String
        Dim objDA As New Datos.ProgramasDA
        Return objDA.importarProgramasRenglon(fechaInicio, fechaFin)
    End Function

    Public Function consultaPedidosConfirmadosSinApartar() As DataTable
        Dim objDA As New Datos.ProgramasDA
        Return objDA.consultaPedidosConfirmadosSinApartar
    End Function

    Public Function consultaPedidosSinProgramaAsignado() As DataTable
        Dim objDA As New Datos.ProgramasDA
        Return objDA.consultaPedidosSinProgramaAsignado
    End Function

    Public Function obtenerFolio() As Integer
        Dim objDA As New Datos.ProgramasDA
        Return objDA.obtenerFolio()
    End Function

    Public Sub guardarRegistroBItacora(ByVal folio As Int32, ByVal idPedido As Int32, ByVal idRenglon As Int32,
                                      ByVal idProducto As Int32, ByVal pares As Int32, ByVal fecha As String,
                                      ByVal mensaje As String, ByVal tipo As String, ByVal pares_faltan As Int32,
                                      ByVal linea As Int32, ByVal prestilo As Int32, ByVal idTalla As Int32,
                                  ByVal origen As String, ByVal simulacionid As Int32, ByVal bita_pdetID As Int32)
        Dim objDA As New Datos.ProgramasDA
        objDA.guardarRegistroBItacora(folio, idPedido, idRenglon,
                                       idProducto, pares, fecha,
                                       mensaje, tipo, pares_faltan,
                                       linea, prestilo, idTalla,
                                       origen, simulacionid, bita_pdetID)

    End Sub

    Public Function ObtenerOpcionFecha(ByVal opcion As String) As Date
        Dim objDA As New Datos.ProgramasDA
        Return objDA.ObtenerOpcionFecha(opcion)
    End Function

    Public Function ObtenerOpcionValorEntero(ByVal opcion As String) As Int32
        Dim objDA As New Datos.ProgramasDA
        Return objDA.ObtenerOpcionValorEntero(opcion)
    End Function

    Public Function consultaExistenciaCapacidadArticuloAnio(ByVal anioInicio As Int32, ByVal anioFin As Int32,
                                                         ByVal semanaInicio As Int32, ByVal semanaFin As Int32,
                                                         ByVal idProd As Int32, ByVal idEstilo As Int32,
                                                         ByVal idTalla As Int32) As DataTable
        Dim objDA As New Datos.ProgramasDA
        Return objDA.consultaExistenciaCapacidadArticuloAnio(anioInicio, anioFin,
                                                             semanaInicio, semanaFin,
                                                             idProd, idEstilo,
                                                             idTalla)
    End Function

    Public Function consultaExistenciaCapacidadParesXArticuloAnio(ByVal anioInicio As Int32, ByVal anioFin As Int32,
                                                         ByVal semanaInicio As Int32, ByVal semanaFin As Int32,
                                                         ByVal idProd As Int32, ByVal idEstilo As Int32,
                                                         ByVal idTalla As Int32) As DataTable
        Dim objDA As New Datos.ProgramasDA
        Return objDA.consultaExistenciaCapacidadParesXArticuloAnio(anioInicio, anioFin,
                                                             semanaInicio, semanaFin,
                                                             idProd, idEstilo, idTalla)
    End Function

    Public Function consultaCapacidadHormaXArticulo(ByVal anioInicio As Int32,
                                                    ByVal anioFin As Int32,
                                                    ByVal semanaInicio As Int32,
                                                    ByVal semanaFin As Int32,
                                                    ByVal idEstilo As Int32,
                                                    ByVal idTalla As Int32,
                                                    ByVal idLinea As Int32,
                                                    ByVal idHorma As Int32) As DataTable
        Dim objDA As New Datos.ProgramasDA
        Return objDA.consultaCapacidadHormaXArticulo(anioInicio, anioFin, semanaInicio, semanaFin, idEstilo, idTalla, idLinea, idHorma)

    End Function

    Public Function consultaCapacidadLineaProduccionCelulaXArticulo(ByVal anioInicio As Int32,
                                                                    ByVal anioFin As Int32,
                                                       ByVal semanaInicio As Int32,
                                                       ByVal semanaFin As Int32,
                                                       ByVal idLinea As Int32) As DataTable
        Dim objDA As New Datos.ProgramasDA
        Return objDA.consultaCapacidadLineaProduccionCelulaXArticulo(anioInicio, anioFin, semanaInicio, semanaFin, idLinea)
    End Function

    Public Function consultaCapacidadLineaProduccionGruposXArticulo(ByVal anioInicio As Int32,
                                                                    ByVal anioFin As Int32,
                                                           ByVal semanaInicio As Int32,
                                                           ByVal semanaFin As Int32,
                                                           ByVal idEstilo As Int32,
                                                           ByVal idTalla As Int32,
                                                           ByVal idLinea As Int32,
                                                           ByVal idGrupo As Int32) As DataTable
        Dim objDA As New Datos.ProgramasDA
        Return objDA.consultaCapacidadLineaProduccionGruposXArticulo(anioInicio, anioFin, semanaInicio, semanaFin,
                                                                     idEstilo, idTalla, idLinea, idGrupo)
    End Function

    Public Sub guardarProgramaRenglonCompleto(ByVal idLinea As Int32,
                                               ByVal idProducto As Int32,
                                               ByVal idEstilo As Int32,
                                               ByVal idPedido As Int32,
                                               ByVal idRenglon As Int32,
                                               ByVal idLote As Int32,
                                               ByVal idTalla As Int32,
                                               ByVal idClienteCadena As String,
                                               ByVal cantidad As String,
                                               ByVal anio As Int32,
                                               ByVal semana As Int32,
                                               ByVal idClienteSAY As String,
                                               ByVal idNave As Int32,
                                                ByVal idHorma As String,
                                                ByVal fechaEntrega As String,
                                                ByVal entregaCliente As String,
                                                ByVal tipo As String)
        Dim objDA As New Datos.ProgramasDA
        objDA.guardarProgramaRenglonCompleto(idLinea, idProducto, idEstilo, idPedido,
                                             idRenglon, idLote, idTalla, idClienteCadena,
                                             cantidad, anio, semana, idClienteSAY, idNave,
                                             idHorma, fechaEntrega, entregaCliente, tipo)

    End Sub

    Public Function consultaRangoColoresMapa() As DataTable
        Dim objDA As New Datos.ProgramasDA
        Return objDA.consultaRangoColoresMapa
    End Function

    Public Function consultaBitacora(ByVal folio As Int32) As DataTable
        Dim objDA As New Datos.ProgramasDA
        Return objDA.consultaBitacora(folio)
    End Function

    Public Sub inactivarFechasImportacionAnterior()
        Dim objDA As New Datos.ProgramasDA
        objDA.inactivarFechasImportacionAnterior()
    End Sub

    Public Sub guardarFechasImportacion(ByVal fechaInicio As Date, ByVal fechafin As Date,
                                        ByVal semanainicio As Int32, ByVal semanafin As Int32, ByVal anioinicio As Int32,
                                        ByVal aniofin As Int32, ByVal folio As Int32)
        Dim objDA As New Datos.ProgramasDA
        objDA.guardarFechasImportacion(fechaInicio, fechafin, semanainicio, semanafin, anioinicio, aniofin, folio)
    End Sub

    Public Function consultaRangosFechaTodo() As DataTable
         Dim objDA As New Datos.ProgramasDA
        Return objDA.consultaRangosFechaTodo
    End Function

    Public Function consultaProgramaRenglonPorSemana(ByVal semanaInicio As Int32, ByVal semanaFin As Int32,
                                                    ByVal anioInicio As Int32, ByVal anioFin As Int32,
                                                    ByVal idNave As Int32, ByVal idLinea As Int32,
                                                    ByVal VerSoloConCantidad As Boolean) As DataTable

        Dim objDA As New Datos.ProgramasDA
        Return objDA.consultaProgramaRenglonPorSemana(semanaInicio, semanaFin, anioInicio, anioFin, idNave, idLinea, VerSoloConCantidad)
    End Function

    Public Function consultaAnioMaximoCapacidades() As Int32
        Dim objDA As New Datos.ProgramasDA
        Return objDA.consultaAnioMaximoCapacidades
    End Function

    Public Function consultaMapaSimulacionSegmentado(ByVal anioInicio As Int32,
                                     ByVal anioFin As Int32,
                                     ByVal semanaInicio As Int32,
                                     ByVal semanaFin As Int32,
                                     ByVal idNave As Int32,
                                     ByVal pedidos As Boolean,
                                     ByVal bloqueo As Boolean,
                                     ByVal ordenamiento As Int32,
                                     ByVal idSimulacionMaestro As Int32,
                                     ByVal folio As Int32) As DataTable

        Dim objDA As New Datos.ProgramasDA
        Return objDA.consultaMapaSimulacionSegmentado(anioInicio, anioFin, semanaInicio, semanaFin, idNave, pedidos, bloqueo, ordenamiento, idSimulacionMaestro, folio)
    End Function

    Public Function consultaMapaSegmentado(ByVal anioInicio As Int32,
                                     ByVal anioFin As Int32,
                                     ByVal semanaInicio As Int32,
                                     ByVal semanaFin As Int32,
                                     ByVal idNave As Int32,
                                     ByVal pedidos As Boolean,
                                     ByVal bloqueo As Boolean,
                                     ByVal ordenamiento As Int32) As DataTable

        Dim objDA As New Datos.ProgramasDA
        Return objDA.consultaMapaSegmentado(anioInicio, anioFin, semanaInicio, semanaFin, idNave, pedidos, bloqueo, ordenamiento)
    End Function

End Class