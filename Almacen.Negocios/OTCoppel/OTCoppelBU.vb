Public Class OTCoppelBU

    Public Function RecuperaTiendasPedido(ByVal idPedido As Int32) As DataTable
        Dim objDA As New Datos.OTCoppelDA
        Dim tabla As New DataTable
        tabla = objDA.RecuperarTiendasPedido(idPedido)
        Return tabla
    End Function

    Public Function RecuperaFechaEntrega(ByVal idPedido As Int32) As DataTable
        Dim objDa As New Datos.OTCoppelDA
        Dim tabla As New DataTable
        tabla = objDa.RecuperarFechaEntrega(idPedido)
        Return tabla
    End Function

    Public Function DetalleTiendasPedido(ByVal idOrdenTrabajo As String, ByVal idPedido As String, ByVal idDistribucion As String, ByVal estatus As String, ByVal fechaEntregaDe As String, ByVal fechaEntregaA As String) As DataTable
        Dim objDa As New Datos.OTCoppelDA
        Dim tabla As New DataTable
        tabla = objDa.DetalleTiendasPedido(idOrdenTrabajo, idPedido, idDistribucion, estatus, fechaEntregaDe, fechaEntregaA)
        Return tabla
    End Function

    Public Function DetalleParesAConfirmar(ByVal idOtCoppel As Int32)
        Dim objDa As New Datos.OTCoppelDA
        Dim tabla As New DataTable
        tabla = objDa.DetalleParesAConfirmar(idOtCoppel)
        Return tabla
    End Function

    Public Function ValidarParLeido(ByVal codigo As String, ByVal atado As Boolean) As List(Of Entidades.ValidacionPar)
        Dim objDa As New Datos.OTCoppelDA
        Dim tabla As New DataTable
        Dim DetallePar As New Entidades.ValidacionPar
        Dim listaPares As New List(Of Entidades.ValidacionPar)
        tabla = objDa.ValidarParLeido(codigo, atado)
        If tabla.Rows.Count > 0 Then
            For Each row As DataRow In tabla.Rows
                DetallePar = New Entidades.ValidacionPar
                DetallePar.PTipoPar = row.Item("TipoPar")
                DetallePar.PIdPar = row.Item("ID_Par")
                DetallePar.PIdDocena = row.Item("ID_Docena")
                DetallePar.PIdPartida = row.Item("idtblPartida")
                DetallePar.PIdPedido = row.Item("idtblPedido")
                DetallePar.PIdCliente = row.Item("idtblcte")
                DetallePar.PIdNave = row.Item("idtblnave")
                DetallePar.PIdLote = row.Item("idtblLote")
                DetallePar.PEstatusPar = row.Item("estatusPar")
                DetallePar.PDescripcion = row.Item("Descripcion")
                DetallePar.PIdProducto = row.Item("idtblproducto")
                DetallePar.PCalce = row.Item("calce")
                DetallePar.PIdTalla = row.Item("idtblTalla")
                DetallePar.PNave = row.Item("Nave")
                DetallePar.PEntradaAlmacen = row.Item("EntradaAlmacen")
                DetallePar.PAño = row.Item("Año")
                listaPares.Add(DetallePar)
            Next
        End If
        Return listaPares
    End Function

    Public Sub InsertarDetalleParesOT(ByVal DetallesPares As Entidades.ValidacionPar, ByVal idOtCoppelDetalles As Int32,
                                      ByVal idOtCoppel As Integer, ByVal paresConfirmado As Integer,
                                      ByVal Usuario As String)
        Dim objDa As New Datos.OTCoppelDA
        objDa.InsertarDetalleParesOT(DetallesPares, idOtCoppelDetalles, idOtCoppel, paresConfirmado, Usuario)
    End Sub

    Public Sub ActualizarDetallesOTCoppel(ByVal IdotCoppelDetalles As Int32, ByVal ParesConfirmados As Int32, ByVal usuario As String, ByVal estatusDetalle As String)
        Dim objDa As New Datos.OTCoppelDA
        objDa.ActualizarDetallesOTCoppel(IdotCoppelDetalles, ParesConfirmados, usuario, estatusDetalle)
    End Sub

    Public Sub ActualizarOTCoppel(ByVal IdOtCoppel As Int32, ByVal EstatusOt As String, ByVal paresConfirmados As Int32, ByVal usuario As String, ByVal paresCorrectos As Int32, ByVal paresExternos As Int32)
        Dim objDa As New Datos.OTCoppelDA
        objDa.ActualizarOTCoppel(IdOtCoppel, EstatusOt, paresConfirmados, usuario, paresCorrectos, paresExternos)
    End Sub

    Public Sub ActualizarEstatusOTCoppel(ByVal IdOtCoppel As Int32, ByVal ParesConfirmados As Int32, ByVal IdotCoppelDetalles As Int32, ByVal EstatusOt As String)
        Dim objDa As New Datos.OTCoppelDA
        objDa.ActualizarEstatusOTCoppel(IdOtCoppel, ParesConfirmados, IdotCoppelDetalles, EstatusOt)
    End Sub

    Public Function VerDetallesGridConfirmacion(ByVal idOtCoppel As Int32) As DataTable
        Dim tabla As New DataTable
        Dim objDa As New Datos.OTCoppelDA
        tabla = objDa.VerDetallesGridConfirmacion(idOtCoppel)
        Return tabla
    End Function

    Public Function imprimirOrdenTrabajoCoppel(ByVal idOtCoppel As String, ByVal tipoConsulta As Int32) As DataTable
        Dim tabla As New DataTable
        Dim objDa As New Datos.OTCoppelDA
        tabla = objDa.imprimirOrdenTrabajoCoppel(idOtCoppel, tipoConsulta)
        Return tabla
    End Function

    Public Sub ActualizarQuitarPar(ByVal idPar As String, ByVal idotDetalles As Int32, ByVal idotCoppel As Int32,
                                   ByVal estatus As String, ByVal paresConf As Integer)
        Dim objDa As New Datos.OTCoppelDA
        objDa.ActualizarQuitarPar(idPar, idotDetalles, idotCoppel, estatus, paresConf)

    End Sub

    Public Function CargarSalidasCoppel(ByVal estatus As String, ByVal idPedido As Int32, ByVal idTienda As Int32, ByVal fechaInicio As String, ByVal fechaFin As String, ByVal filtro As Boolean) As DataTable
        Dim objDa As New Datos.OTCoppelDA
        Dim tabla As New DataTable
        tabla = objDa.CargarSalidasCoppel(estatus, idPedido, idTienda, fechaInicio, fechaFin, filtro)
        Return tabla
    End Function

    Public Function ParesADarSalida(ByVal idOtCoppel As Int32) As DataTable
        Dim objDa As New Datos.OTCoppelDA
        Dim tabla As New DataTable
        tabla = objDa.ParesADarSalida(idOtCoppel)
        Return tabla
    End Function

    Public Sub ActualizaEstatusParesSalidaOT(ByVal idOtCoppel As Int32)
        Dim objDa As New Datos.OTCoppelDA
        objDa.ActualizaEstatusParesSalidaOT(idOtCoppel)
    End Sub

    Public Sub ActualizaEstatusParesTmpdocenapares(ByVal idPar As String)
        Dim objDa As New Datos.OTCoppelDA
        objDa.ActualizaEstatusParesTmpdocenapares(idPar)
    End Sub

    Public Sub ActualizaEstatusParesTmpdocenasparesCoppel(ByVal pares As String)
        Dim objDa As New Datos.OTCoppelDA
        objDa.ActualizaEstatusParesTmpdocenasparesCoppel(pares)
    End Sub

    Public Function mostrarDetallesSalida(ByVal idsotcoppel As String) As DataTable
        Dim objDa As New Datos.OTCoppelDA
        Dim tabla As New DataTable
        tabla = objDa.mostrarDetallesSalida(idsotcoppel)
        Return tabla
    End Function

    Public Sub InsertarIncidencias(ByVal idOtCoppel As Integer, ByVal Usuario As String, ByVal paresLeidos As Integer, ByVal paresIncorrectos As Integer)
        Dim objDa As New Datos.OTCoppelDA
        objDa.InsertarIncidencias(idOtCoppel, Usuario, paresLeidos, paresIncorrectos)
    End Sub

    Public Function geTiendaCoppel() As DataTable
        Dim objDa As New Datos.OTCoppelDA
        Dim tabla As New DataTable

        tabla = objDa.geTiendaCoppel()
        Return tabla
    End Function

    Public Sub ActualizaEstatusParesTmpdocenaparesCoppel(ByVal idPar As String, ByVal idOTCoppel As Int32)
        Dim objDa As New Datos.OTCoppelDA
        objDa.ActualizaEstatusParesTmpdocenaparesCoppel(idPar, idOTCoppel)
    End Sub

    Public Function validaAtadoOTCoppel(ByVal NumeroAtado As String)
        Dim objDa As New Datos.OTCoppelDA
        Return objDa.validaAtadoOTCoppel(NumeroAtado)
    End Function

    Public Function CancelarConfirmacionOT(ordenTrabajo As Integer) As DataTable
        Dim dt As DataTable
        Dim correcto As Boolean = 0
        Dim objDa As New Datos.OTCoppelDA
        Try
            dt = objDa.CancelarConfirmacionOT(ordenTrabajo)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LimpiarOtCoppel(ByVal idOTCOppel As Integer)
        Dim objDa As New Datos.OTCoppelDA
        Return objDa.LimpiarOtCoppel(idOTCOppel)
    End Function

    Public Function ActualizarParesEntregadosPedido(ByVal PedidoSICYID As Integer)
        Dim objDa As New Datos.OTCoppelDA
        Return objDa.ActualizarParesEntregadosPedido(PedidoSICYID)
    End Function
    Public Sub ReplicarEstatusPedidoSAY_SICY(ByVal PedidoSICYID As Integer)
        Dim objDa As New Datos.OTCoppelDA
        objDa.ReplicarEstatusSAY_SICY(PedidoSICYID)
    End Sub

End Class