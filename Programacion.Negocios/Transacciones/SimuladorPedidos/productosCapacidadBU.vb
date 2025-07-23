Public Class productosCapacidadBU

    Public Function consultaProductosNave(ByVal idNave As Int32)
        Dim objNave As New Datos.productosCapacidadDA
        Return objNave.consultaProductosNave(idNave)
    End Function

    Public Function consultaProductosNaveCapacidad(ByVal idNave As Int32, ByVal idLinea As Int32, ByVal anio As Int32)
        Dim objNave As New Datos.productosCapacidadDA
        Return objNave.consultaProductosNaveCapacidad(idNave, idLinea, anio)
    End Function

    Public Function consultaProductosCelula(ByVal idNave As Int32, ByVal productoEstilo As String) As DataTable
        Dim objNave As New Datos.productosCapacidadDA
        Return objNave.consultaProductosCelula(idNave, productoEstilo)
    End Function

    Public Function consultaProductosNuevosNoAsignados(ByVal idNave As Int32) As DataTable
        Dim objProd As New Datos.productosCapacidadDA
        Return objProd.consultaProductosNuevosNoAsignados(idNave)
    End Function

    Public Function consultaProductosNuevosAsignados(ByVal idNave As Int32) As DataTable
        Dim objProd As New Datos.productosCapacidadDA
        Return objProd.consultaProductosNuevosAsignados(idNave)
    End Function

    Public Sub guardarProductoNuevo(ByVal idArticulo As Int32, ByVal idNave As Int32, ByVal fecha As Date)
        Dim objProd As New Datos.productosCapacidadDA
        objProd.guardarProductoNuevo(idArticulo, idNave, fecha)
    End Sub

    Public Sub inactivarRegistroProductoNuevo(ByVal idProductoNuevo As Int32)
        Dim objProd As New Datos.productosCapacidadDA
        objProd.inactivarRegistroProductoNuevo(idProductoNuevo)
    End Sub

    Public Sub cambiarFechaRegistroProductoNuevo(ByVal idProductoNuevo As Int32, ByVal fecha As Date)
        Dim objProd As New Datos.productosCapacidadDA
        objProd.cambiarFechaRegistroProductoNuevo(idProductoNuevo, fecha)
    End Sub

    Public Function consultaListaProductosCapacidadCopiar(ByVal idLinea As Int32, ByVal idHorma As Int32,
                                                        ByVal idTalla As Int32, ByVal idPstilo As Int32,
                                                        ByVal anio As String) As DataTable

        Dim objProd As New Datos.productosCapacidadDA
        Return objProd.consultaListaProductosCapacidadCopiar(idLinea, idHorma, idTalla, idPstilo, anio)
    End Function

    Public Function insertarCapacidadSimulador(ByVal idLinea As Int32, ByVal tipoAlta As Int32, ByVal idCopia As Int32,
                                             ByVal idCambio As Int32, ByVal idSimulacion As Int32,
                                             ByVal entPrdsCap As Entidades.ProductoCapacidad) As DataTable
        Dim objProd As New Datos.productosCapacidadDA
        Return objProd.insertarCapacidadSimulador(idLinea, tipoAlta, idCopia, idCambio, idSimulacion, entPrdsCap)
    End Function

    Public Function consultaArticulosConfigurados(ByVal idSimulacion As Int32, ByVal idLinea As Int32, ByVal idLineaOrigen As Int32) As DataTable
        Dim objProd As New Datos.productosCapacidadDA
        Return objProd.consultaArticulosConfigurados(idSimulacion, idLinea, idLineaOrigen)
    End Function

    Public Function consultaOrdenProductoNaveSimulacion(ByVal idSimulacion As Int32,
                                                       ByVal idPEstilo As Int32,
                                                       ByVal existe As Boolean,
                                                       ByVal idNave As Int32) As DataTable
        Dim objProd As New Datos.productosCapacidadDA
        Return objProd.consultaOrdenProductoNaveSimulacion(idSimulacion, idPEstilo, existe, idNave)
    End Function

    Public Sub insertarOrdenArticuloNaveSimulacion(ByVal simulacionId As Int32,
                                                   ByVal productoEstiloId As Int32,
                                                   ByVal naveId As Int32,
                                                   ByVal orden As Int32)
        Dim objProd As New Datos.productosCapacidadDA
        objProd.insertarOrdenArticuloNaveSimulacion(simulacionId, productoEstiloId, naveId, orden)
    End Sub

    Public Sub editarOrdenNaveArticuloSimulacion(ByVal idOrdNvArtSim As Int32, ByVal orden As Int32)
        Dim objProd As New Datos.productosCapacidadDA
        objProd.editarOrdenNaveArticuloSimulacion(idOrdNvArtSim, orden)
    End Sub

    Public Sub inactivarArticuloCapacidadSimulacion(ByVal idSimArtCapacidad As Int32)
        Dim objProd As New Datos.productosCapacidadDA
        objProd.inactivarArticuloCapacidadSimulacion(idSimArtCapacidad)
    End Sub

    Public Sub editarCapacidadArticuloSimulacion(ByVal idSimCapArticulo As Int32,
                                                ByVal semanaInicio As Int32,
                                                ByVal semanaFin As Int32,
                                                ByVal cantidad As Int32)
        Dim objProd As New Datos.productosCapacidadDA
        objProd.editarCapacidadArticuloSimulacion(idSimCapArticulo, semanaInicio, semanaFin, cantidad)
    End Sub


    Public Sub editarTipoAltaCapacidadArticuloSimulacion(ByVal idSimCapArticulo As Int32,
                                                 ByVal idTipoAlta As Int32,
                                                 ByVal idLineaOrigen As Int32)
        Dim objProd As New Datos.productosCapacidadDA
        objProd.editarTipoAltaCapacidadArticuloSimulacion(idSimCapArticulo, idTipoAlta, idLineaOrigen)
    End Sub

End Class
