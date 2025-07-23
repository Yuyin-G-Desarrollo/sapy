Public Class LineasProduccionBU

    Public Function tablaLineas(ByVal activo As Boolean) As DataTable
        Dim objD As New Datos.LineasProduccionDA
        Return objD.tablaLineas(activo)
    End Function

    Public Function comboLineas(ByVal activo As Boolean) As DataTable
        Dim objD As New Datos.LineasProduccionDA
        Return objD.comboLineas(activo)
    End Function

    Public Sub registrarEditarLinea(ByVal accion As String,
                                   ByVal idLinea As Int32,
                                   ByVal idNave As Int32,
                                   ByVal capacidad As Int32,
                                   ByVal activo As Boolean,
                                   ByVal nombre As String)
        Dim objD As New Datos.LineasProduccionDA
        objD.registrarEditarLinea(accion, idLinea, idNave, capacidad, activo, nombre)
    End Sub

    Public Function validarNombreRepetido(ByVal idNave As Int32, ByVal nombre As String) As Int32
        Dim objD As New Datos.LineasProduccionDA
        Return objD.validarNombreRepetido(idNave, nombre)
    End Function

    Public Function consultaValidarCont(ByVal idCelula As Int32) As Int32
        Dim objD As New Datos.LineasProduccionDA
        Dim dt As New DataTable
        Dim cont As Int32 = 0

        dt = objD.consultaValidarCont(idCelula)

        If dt.Rows.Count > 0 Then
            cont = dt.Rows(0).Item(0)
        End If

        Return cont

    End Function

    Public Function TablaSemanaLineas(ByVal anioInicio As Int32, ByVal anioFin As Int32, ByVal activoCelula As Boolean, ByVal inactivoCelula As Boolean) As DataTable
        Dim objD As New Datos.LineasProduccionDA
        Return objD.TablaSemanaLineas(anioInicio, anioFin, activoCelula, inactivoCelula)
    End Function

    Public Function TablaSemanaGruposAnioNave(ByVal idNave As Int32, ByVal anioInicio As Int32, ByVal anioFin As Int32, ByVal activoGrupo As Boolean,
                                              ByVal inactivoGrupo As Boolean, ByVal asignadoGrupo As Boolean, ByVal noAsignadoGrupo As Boolean) As DataTable
        Dim objD As New Datos.LineasProduccionDA
        Return objD.TablaSemanaGruposAnioNave(idNave, anioInicio, anioFin, activoGrupo, inactivoGrupo, asignadoGrupo, noAsignadoGrupo)
    End Function

    Public Function TablaSemanaProductosAnioNave(ByVal idNave As Int32, ByVal anioInicio As Int32, ByVal anioFin As Int32, ByVal activoProd As Boolean,
                                              ByVal inactivoProd As Boolean, ByVal asignadoProd As Boolean, ByVal noAsignadoProd As Boolean) As DataTable
        Dim objD As New Datos.LineasProduccionDA
        Return objD.TablaSemanaProductosAnioNave(idNave, anioInicio, anioFin, activoProd, inactivoProd, asignadoProd, noAsignadoProd)
    End Function

    Public Function TablaHormaAnioNave(ByVal idNave As Int32, ByVal anioInicio As Int32, ByVal anioFin As Int32, ByVal activoHorma As Boolean,
                                       ByVal inactivoHorma As Boolean, ByVal asignadoHorma As Boolean, ByVal noAsignadoHorma As Boolean) As DataTable
        Dim objD As New Datos.LineasProduccionDA
        Return objD.TablaHormaAnioNave(idNave, anioInicio, anioFin, activoHorma, inactivoHorma, asignadoHorma, noAsignadoHorma)
    End Function

    Public Sub editarCapacidadCelula(ByVal semana As Int32, ByVal capacidad As Int32, ByVal idCelula As Int32)
        Dim objD As New Datos.LineasProduccionDA
        objD.editarCapacidadCelula(semana, capacidad, idCelula)
    End Sub

    Public Sub editarCapacidadGrupo(ByVal semana As Int32, ByVal capacidad As Int32, ByVal idGrupCap As Int32)
        Dim objD As New Datos.LineasProduccionDA
        objD.editarCapacidadGrupo(semana, capacidad, idGrupCap)
    End Sub

    Public Sub editarCapacidadHorma(ByVal semana As Int32, ByVal capacidad As Int32, ByVal idhormCap As Int32)
        Dim objD As New Datos.LineasProduccionDA
        objD.editarCapacidadHorma(semana, capacidad, idhormCap)
    End Sub

    Public Sub editarCapacidadProducto(ByVal semana As Int32, ByVal capacidad As Int32, ByVal idProdCapa As Int32)
        Dim objD As New Datos.LineasProduccionDA
        objD.editarCapacidadProducto(semana, capacidad, idProdCapa)
    End Sub

    Public Function consultaCelulasNuevas(ByVal anio As Int32) As DataTable
        Dim objD As New Datos.LineasProduccionDA
        Return objD.consultaCelulasNuevas(anio)
    End Function

    Public Sub insertarCelulaCapacidad(ByVal idCelula As Int32, ByVal anio As Int32, ByVal capacidad As Int32)
        Dim objD As New Datos.LineasProduccionDA
        objD.insertarCelulaCapacidad(idCelula, anio, capacidad)
    End Sub

    Public Sub insertarGrupoCapacidad(ByVal idLinea As Int32, ByVal idGrupo As Int32, ByVal anio As Int32, ByVal capacidad As Int32)
        Dim objD As New Datos.LineasProduccionDA
        objD.insertarGrupoCapacidad(idLinea, idGrupo, anio, capacidad)
    End Sub

    Public Sub insertarHormaCapacidadCelula(ByVal idLinea As Int32, ByVal idHorma As Int32,
                                          ByVal idTalla As Int32, ByVal anio As Int32,
                                          ByVal idHormaXNave As Int32, ByVal capacidad As Int32)
        Dim objD As New Datos.LineasProduccionDA
        objD.insertarHormaCapacidadCelula(idLinea, idHorma, idTalla, anio, idHormaXNave, capacidad)
    End Sub

    Public Sub insertarProductoCapacidad(ByVal idLinea As Int32, ByVal idProducto As Int32,
                                         ByVal idProductoEstilo As Int32, ByVal idHorma As String,
                                         ByVal idTalla As Int32, ByVal anio As Int32,
                                         ByVal capacidad As Int32, ByVal idProductoNave As Int32)
        Dim objD As New Datos.LineasProduccionDA
        objD.insertarProductoCapacidad(idLinea, idProducto, idProductoEstilo, idHorma, idTalla, anio, capacidad, idProductoNave)
    End Sub

    Public Function consultaAniosMaximoRegistrado() As Int32
        Dim objD As New Datos.LineasProduccionDA
        Return objD.consultaAniosMaximoRegistrado()
    End Function

    Public Function consultaAniosMinimoRegistrado() As Int32
        Dim objD As New Datos.LineasProduccionDA
        Return objD.consultaAniosMinimoRegistrado()
    End Function

    Public Function consultaidCapacidadCelulaAnioDiferente(ByVal idLinea As Int32,
                                                           ByVal anio As Int32,
                                                           ByVal semana As Int32) As String
        Dim objD As New Datos.LineasProduccionDA
        Return objD.consultaidCapacidadCelulaAnioDiferente(idLinea, anio, semana)
    End Function

    Public Function consultaidCapacidadGrupoAnioDiferente(ByVal idLinea As Int32,
                                                          ByVal idGrupo As Int32,
                                                          ByVal anio As Int32,
                                                          ByVal semana As Int32) As String
        Dim objD As New Datos.LineasProduccionDA
        Return objD.consultaidCapacidadGrupoAnioDiferente(idLinea, idGrupo, anio, semana)
    End Function

    Public Function consultaidCapacidadHormaAnioDiferente(ByVal idLinea As Int32,
                                                          ByVal idHorma As Int32,
                                                          ByVal idTalla As Int32,
                                                          ByVal idHormaXNave As Int32,
                                                          ByVal anio As Int32,
                                                          ByVal semana As Int32) As String
        Dim objD As New Datos.LineasProduccionDA
        Return objD.consultaidCapacidadHormaAnioDiferente(idLinea, idHorma, idTalla, idHormaXNave, anio, semana)
    End Function

    Public Function consultaidCapacidadProductoAnioDiferente(ByVal idLinea As Int32,
                                                         ByVal idHorma As Int32,
                                                         ByVal idProdestilo As Int32,
                                                         ByVal idTalla As Int32,
                                                         ByVal idProductoXnave As Int32,
                                                         ByVal anio As Int32,
                                                         ByVal semana As Int32) As String
        Dim objD As New Datos.LineasProduccionDA
        Return objD.consultaidCapacidadProductoAnioDiferente(idLinea, idHorma, idProdestilo, idTalla, idProductoXnave, anio, semana)
    End Function

    Public Function consultaFechaSeleccionSemana(ByVal semanasCambio As Int32, ByVal anio As Int32) As String
        Dim objD As New Datos.LineasProduccionDA
        Return objD.consultaFechaSeleccionSemana(semanasCambio, anio)
    End Function

    'Public Sub inactivarCelula(ByVal idCelula As Int32, ByVal semana As Int32)
    '    Dim objDA As New Datos.LineasProduccionDA
    '    objDA.inactivarCelula(idCelula, semana)
    'End Sub

    Public Function contadorGruposEnCelula(ByVal idCelula As Int32, ByVal anio As Int32) As Int32
        Dim objDA As New Datos.LineasProduccionDA
        Return objDA.contadorGruposEnCelula(idCelula, anio)
    End Function

    'Public Sub inactivarGrupo(ByVal idGrupoCapacidad As Int32, semana As Int32)
    '    Dim objDA As New Datos.LineasProduccionDA
    '    objDA.inactivarGrupo(idGrupoCapacidad, semana)
    'End Sub

    Public Sub inactivarHorma(ByVal idHormaCapacidad As Int32, ByVal semana As Int32, ByVal anio As Int32)
        Dim objDA As New Datos.LineasProduccionDA
        objDA.inactivarHorma(idHormaCapacidad, semana, anio)
    End Sub

    Public Function contadosProductoEnHorma(ByVal idLinea As Int32, ByVal anio As Int32,
                                            ByVal idHorma As Int32, ByVal idTalla As Int32,
                                            ByVal semanaRegistro As Int32) As Int32
        Dim objDA As New Datos.LineasProduccionDA
        Return objDA.contadosProductoEnHorma(idLinea, anio, idHorma, idTalla, semanaRegistro)
    End Function

    Public Sub inactivarProducto(ByVal idProductoCapacidad As Int32, ByVal semana As Int32, ByVal anio As Int32)
        Dim objDA As New Datos.LineasProduccionDA
        objDA.inactivarProducto(idProductoCapacidad, semana, anio)
    End Sub

    Public Sub inactivarHormasSemanaActual()
        Dim objDA As New Datos.LineasProduccionDA
        objDA.inactivarHormasSemanaActual()
    End Sub

    Public Sub inactivarProductosSemanaActual()
        Dim objDA As New Datos.LineasProduccionDA
        objDA.inactivarProductosSemanaActual()
    End Sub

    Public Function consultaCapacidadesCelulasHorma(ByVal idNave As Int32,
                                                    ByVal idHorma As Int32,
                                                    ByVal idTalla As Int32) As DataTable
        Dim objDA As New Datos.LineasProduccionDA
        Return objDA.consultaCapacidadesCelulasHorma(idNave, idHorma, idTalla)
    End Function

    Public Sub eliminarAniosAnteriores()
        Dim objDA As New Datos.LineasProduccionDA
        objDA.eliminarAniosAnteriores()
    End Sub

    Public Function consultarLineasDiferenteALaSeleccion(ByVal idNave As Int32) As DataTable
        Dim objBu As New Datos.LineasProduccionDA
        Return objBu.consultarLineasDiferenteALaSeleccion(idNave)
    End Function

    Public Function consultarArticulosLineaProduccion(ByVal idNave As Int32,
                                                      ByVal productosExcluir As String,
                                                      ByVal idSimulacion As Int32,
                                                      ByVal idLinea As Int32,
                                                      ByVal idNaveDestino As Int32,
                                                      ByVal anio As Int32) As DataTable
        Dim objBu As New Datos.LineasProduccionDA
        Return objBu.consultarArticulosLineaProduccion(idNave, productosExcluir, idSimulacion, idLinea, idNaveDestino, anio)
    End Function
End Class
