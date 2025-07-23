Imports Programacion.Datos

Public Class HormasCapacidadesBU
    Dim vHormasCapacidadesDA As HormasCapacidadesDA

    Public Function TablaHormasDisponibles(naveID As Int32) As DataTable
        vHormasCapacidadesDA = New HormasCapacidadesDA
        Return vHormasCapacidadesDA.TablaHormasDisponibles(naveID)
    End Function

    Public Sub AsigarHorma(naveID As Int32, hormaID As Int32, tallaID As Integer, capacidad As Integer)
        vHormasCapacidadesDA = New HormasCapacidadesDA
        vHormasCapacidadesDA.AsigarHorma(naveID, hormaID, tallaID, capacidad)
    End Sub

    Public Function verificarHormaNave(naveID As Integer, hormaID As Integer, tallaID As Integer) As Boolean
        vHormasCapacidadesDA = New HormasCapacidadesDA
        Dim tabla As DataTable = vHormasCapacidadesDA.verificarHormaNave(naveID, hormaID, tallaID)
        If tabla.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Public Sub actualizarHormaNave(naveID As Integer, hormaID As Integer, tallaID As Integer, capacidad As Integer)
        vHormasCapacidadesDA = New HormasCapacidadesDA
        vHormasCapacidadesDA.actualizarHormaNave(naveID, hormaID, tallaID, capacidad)
    End Sub

    Public Function TablaHormasAsignadas(naveID As Int32) As DataTable
        vHormasCapacidadesDA = New HormasCapacidadesDA
        Return vHormasCapacidadesDA.TablaHormasAsignadas(naveID)
    End Function

    Public Sub actualizarCapacidasHormaAsignada(hormaAsignada As Integer, capacidad As Integer)
        vHormasCapacidadesDA = New HormasCapacidadesDA
        vHormasCapacidadesDA.actualizarCapacidasHormaAsignada(hormaAsignada, capacidad)
    End Sub

    Public Function TablaHormasTodas(hormaID As Int32, tallaID As Integer) As DataTable
        vHormasCapacidadesDA = New HormasCapacidadesDA
        Return vHormasCapacidadesDA.TablaHormasTodas(hormaID, tallaID)
    End Function

    Public Sub DesasignarColeccion(ByVal conaID As Integer, ByVal tipo As Boolean, ByVal naveID As Integer, ByVal tallaID As Integer, ByVal hormaID As Integer)
        vHormasCapacidadesDA = New HormasCapacidadesDA
        vHormasCapacidadesDA.DesasignarColeccion(conaID, tipo, naveID, tallaID, hormaID)
    End Sub

    Public Function listaNaves() As DataTable
        vHormasCapacidadesDA = New HormasCapacidadesDA
        Return vHormasCapacidadesDA.listaNaves()
    End Function

    Public Function obtnerHormasNave(ByVal naveID As Integer) As DataTable
        vHormasCapacidadesDA = New HormasCapacidadesDA
        Return vHormasCapacidadesDA.obtnerHormasNave(naveID)
    End Function

    Public Function obtnerTallasHormas(ByVal hormaID As Integer, ByVal nave As Integer) As DataTable
        vHormasCapacidadesDA = New HormasCapacidadesDA
        Return vHormasCapacidadesDA.obtnerTallasHormas(hormaID, nave)
    End Function

    Public Function TablaProductosDisponibles(hormaID As Int32, naveID As Int32, tallaID As Int32) As DataTable
        vHormasCapacidadesDA = New HormasCapacidadesDA
        Return vHormasCapacidadesDA.TablaProductosDisponibles(hormaID, naveID, tallaID)
    End Function

    Public Function TablaProductoAsignado(naveID As Int32, hormaID As Int32, ByVal idTalla As Int32) As DataTable
        vHormasCapacidadesDA = New HormasCapacidadesDA
        Return vHormasCapacidadesDA.TablaProductoAsignado(naveID, hormaID, idTalla)
    End Function

    Public Sub AsignarProducto(naveID As Int32, productoId As Int32, productoEstiloID As Int32, tallaID As Int32, capacidad As Integer, orden As Integer)
        vHormasCapacidadesDA = New HormasCapacidadesDA
        vHormasCapacidadesDA.AsignarProducto(naveID, productoId, productoEstiloID, tallaID, capacidad, orden)
    End Sub

    Public Function verificarProductoAsignar(naveID As Int32, productoId As Int32, productoEstiloID As Int32, tallaID As Int32) As Boolean
        vHormasCapacidadesDA = New HormasCapacidadesDA
        Dim tabla As DataTable = vHormasCapacidadesDA.verificarProductoAsignar(naveID, productoId, productoEstiloID, tallaID)
        If tabla.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Public Sub actualizarProductoAsignar(naveID As Int32, productoId As Int32, productoEstiloID As Int32, tallaID As Int32, capacidad As Integer, orden As Integer)
        vHormasCapacidadesDA = New HormasCapacidadesDA
        vHormasCapacidadesDA.actualizarProductoAsignar(naveID, productoId, productoEstiloID, tallaID, capacidad, orden)
    End Sub

    Public Sub DesasignarProducto(prna_prnaID As Int32)
        vHormasCapacidadesDA = New HormasCapacidadesDA
        vHormasCapacidadesDA.DesasignarProducto(prna_prnaID)
    End Sub

    Public Function obtenerOrdenNaves() As DataTable
        vHormasCapacidadesDA = New HormasCapacidadesDA
        Return vHormasCapacidadesDA.obtenerOrdenNaves
    End Function

    Public Sub actualizarOrdenCantidadProducto(ByVal OrdenAnterior As Integer, ByVal aCantidad As Boolean, ByVal cantidad As Integer, ByVal aOrden As Boolean, ByVal orden As Integer, ByVal prnaID As Integer)
        vHormasCapacidadesDA = New HormasCapacidadesDA
        vHormasCapacidadesDA.actualizarOrdenCantidadProducto(OrdenAnterior, aCantidad, cantidad, aOrden, orden, prnaID)
    End Sub

    Public Sub actualizarOrdenProducto(ByVal anteriorOrden As Integer, ByVal nuevoOrden As Integer, ByVal idPrn As Integer)
        vHormasCapacidadesDA = New HormasCapacidadesDA
        vHormasCapacidadesDA.actualizarOrdenProducto(anteriorOrden, nuevoOrden, idPrn)
    End Sub

    Public Sub actualizarCapacidadProducto(ByVal capacidad As Integer, ByVal idPrn As Integer)
        vHormasCapacidadesDA = New HormasCapacidadesDA
        vHormasCapacidadesDA.actualizarCapacidadProducto(capacidad, idPrn)
    End Sub

    Public Sub actualizarMuestraProducto(ByVal muestra As Integer, ByVal idPrn As Integer)
        vHormasCapacidadesDA = New HormasCapacidadesDA
        vHormasCapacidadesDA.actualizarMuestraProducto(muestra, idPrn)
    End Sub

    Public Function TablaProductoTodo(productoID As Int32, productoEstiloID As Int32, tallaID As Int32) As DataTable
        vHormasCapacidadesDA = New HormasCapacidadesDA
        Return vHormasCapacidadesDA.TablaProductoTodo(productoID, productoEstiloID, tallaID)
    End Function

    Public Function TablaProductosVerTodo() As DataTable
        vHormasCapacidadesDA = New HormasCapacidadesDA
        Return vHormasCapacidadesDA.TablaProductosVerTodo
    End Function

    Public Sub actualizarOrdenNaves(ByVal idPrna As Integer, ByVal norden As Integer)
        vHormasCapacidadesDA = New HormasCapacidadesDA
        vHormasCapacidadesDA.actualizarOrdenNaves(idPrna, norden)
    End Sub

    Public Function obtenerTodasHormas() As DataTable
        vHormasCapacidadesDA = New HormasCapacidadesDA
        Return vHormasCapacidadesDA.obtenerTodasHormas
    End Function

    Public Function obtnerProductosDisponiblesGeneral() As DataTable
        vHormasCapacidadesDA = New HormasCapacidadesDA
        Return vHormasCapacidadesDA.obtnerProductosDisponiblesGeneral
    End Function

    Public Function verificarHormaNave2(ByVal idHormaNave As Integer, ByVal naveId As Integer, ByVal tallaID As Integer) As Boolean
        vHormasCapacidadesDA = New HormasCapacidadesDA
        If vHormasCapacidadesDA.verificarHormaNave2(idHormaNave, naveId, tallaID).Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Public Function consultaHormaPorNave(ByVal idNave As Int32) As DataTable
        Dim objDA As New Datos.HormasCapacidadesDA
        Return objDA.consultaHormaPorNave(idNave)
    End Function

    Public Function consultaHormaPorNaveCapacidad(ByVal idNave As Int32,
                                         ByVal idLineaProduccion As Int32,
                                         ByVal anio As Int32) As DataTable
        Dim objDA As New Datos.HormasCapacidadesDA
        Return objDA.consultaHormaPorNaveCapacidad(idNave, idLineaProduccion, anio)
    End Function

    Public Function consultaValidaExisteHormaSimulacion(ByVal entPC As Entidades.ProductoCapacidad, ByVal linea As Int32) As Int32
        Dim objProd As New Datos.HormasCapacidadesDA
        Return objProd.consultaValidaExisteHormaSimulacion(entPC, linea)
    End Function

    Public Sub insertarCapacidadSimulacion(ByVal idLinea As Int32, ByVal tipoAlta As Int32, ByVal idCopia As Int32,
                                         ByVal idCambio As Int32, ByVal idSimulacion As Int32,
                                         ByVal entHormsCap As Entidades.HormasCapacidad)

        Dim objDA As New Datos.HormasCapacidadesDA
        objDA.insertarCapacidadSimulacion(idLinea, tipoAlta, idCambio, idCambio, idSimulacion, entHormsCap)
    End Sub

    Public Function consultaSimulacionHormasCapacidad(ByVal idSimulacion As Int32, ByVal idLinea As Int32) As DataTable
        Dim objDA As New Datos.HormasCapacidadesDA
        Return objDA.consultaSimulacionHormasCapacidad(idSimulacion, idLinea)
    End Function

    Public Sub editarHormaCapacidadSimulacion(ByVal idSimCapHorma As Int32,
                                         ByVal semanaInicio As Int32,
                                              ByVal semanaFin As Int32,
                                              ByVal cantidad As Int32)
        Dim objDA As New Datos.HormasCapacidadesDA
        objDA.editarHormaCapacidadSimulacion(idSimCapHorma, semanaInicio, semanaFin, cantidad)
    End Sub
End Class
