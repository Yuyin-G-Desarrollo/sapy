
Imports Entidades
Imports ToolServicios
Imports Programacion.Datos
Imports EntidadesFachada.Programacion
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Export

Imports System.Net

''' <summary>
''' 
''' </summary>
Public Class PedidoMuestraBU
    Dim sPDF As String
    Dim File As String
    ''' <summary>
    ''' Consulta general para productos en pedidos muestra
    ''' </summary>
    ''' <param name="filtro">con 3 caracteres minimo</param>
    ''' <returns>Lista enlazada tipo ProductoPedidoMuestra</returns>
    Public Function ConsultaProductosMuestra(ByVal filtro As String, ByVal idCliente As Int32) As RespuestaRestLista(Of ProductosPedidoMuestra)
        Dim objPedidosMuestra As New PedidosMuestraDA()
        Dim objConvertidor As New Convertidor(Of ProductosPedidoMuestra)()
        Dim respuesta As New RespuestaRestLista(Of ProductosPedidoMuestra)
        Dim tabla As DataTable = Nothing
        Try
            tabla = objPedidosMuestra.ConsultarProductosMuestras(filtro, idCliente)
            If tabla.Rows IsNot Nothing Then
                If tabla.Rows.Count > 0 Then
                    respuesta.respuesta = ResultadoServicio.Correcto
                    respuesta.aviso = MensajesPedidosMuestra.CNSAccionRealizada
                    respuesta.mensaje = objConvertidor.DataTableToList(tabla)
                Else
                    respuesta.respuesta = ResultadoServicio.incorrecto
                    respuesta.aviso = MensajesPedidosMuestra.CNSNoExistenDatos
                    respuesta.mensaje = Nothing
                End If
            Else
                respuesta.respuesta = ResultadoServicio.incorrecto
                respuesta.aviso = MensajesPedidosMuestra.CNSNoExistenDatos
                respuesta.mensaje = Nothing
            End If
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorConsulta
            respuesta.mensaje = Nothing
        Finally
            objPedidosMuestra = Nothing
            objConvertidor = Nothing
        End Try
        Return respuesta
    End Function
    ''' <summary>
    ''' Consulta general para productos en pedidos muestra
    ''' </summary>
    ''' <param name="filtro">con 3 caracteres minimo</param>
    ''' <param name="encabezado">Si es diferente de 0, se agregar las primeras 2 filas con nombres y tipos de dato</param>
    ''' <returns>Arreglo de tipo objeto</returns>
    Public Function CConsultaProductosMuestraArreglo(ByVal filtro As String, ByVal idCliente As Int32, Optional ByVal encabezado As Int32 = 0) As RespuestaRestArray
        Dim objPedidosMuestra As New PedidosMuestraDA()
        Dim objConvertidor As New Convertidor(Of EstatusMuestra)()
        Dim respuesta As New RespuestaRestArray
        Dim tabla As DataTable = Nothing
        Try
            tabla = objPedidosMuestra.ConsultarProductosMuestras(filtro, idCliente)
            If tabla.Rows IsNot Nothing Then
                If tabla.Rows.Count > 0 Then
                    respuesta.respuesta = ResultadoServicio.Correcto
                    respuesta.aviso = MensajesPedidosMuestra.CNSAccionRealizada
                    respuesta.mensaje = objConvertidor.DataTableToArray(encabezado, tabla)
                Else
                    respuesta.respuesta = ResultadoServicio.incorrecto
                    respuesta.aviso = MensajesPedidosMuestra.CNSNoExistenDatos
                    respuesta.mensaje = Nothing
                End If
            Else
                respuesta.respuesta = ResultadoServicio.incorrecto
                respuesta.aviso = MensajesPedidosMuestra.CNSNoExistenDatos
                respuesta.mensaje = Nothing
            End If
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorConsulta
            respuesta.mensaje = Nothing
        Finally
            objPedidosMuestra = Nothing
            objConvertidor = Nothing
        End Try
        Return respuesta
    End Function
    ''' <summary>
    ''' Consulta general para productos en pedidos muestra
    ''' </summary>
    ''' <param name="filtro">con 3 caracteres minimo</param>
    ''' <param name="encabezado">Si es diferente de 0, se agregar las primeras 2 filas con nombres y tipos de dato</param>
    ''' <returns>Arreglo de tipo objeto</returns>
    Public Function CConsultaProductosMuestraEtiquetaArreglo(ByVal filtro As String, ByVal idCliente As Int32, Optional ByVal encabezado As Int32 = 0) As RespuestaRestArray
        Dim objPedidosMuestra As New PedidosMuestraDA()
        Dim objConvertidor As New Convertidor(Of EstatusMuestra)()
        Dim respuesta As New RespuestaRestArray
        Dim tabla As DataTable = Nothing
        Try
            tabla = objPedidosMuestra.ConsultarProductosMuestrasCodigo(filtro, idCliente)
            If tabla.Rows IsNot Nothing Then
                If tabla.Rows.Count > 0 Then
                    respuesta.respuesta = ResultadoServicio.Correcto
                    respuesta.aviso = MensajesPedidosMuestra.CNSAccionRealizada
                    respuesta.mensaje = objConvertidor.DataTableToArray(encabezado, tabla)
                Else
                    respuesta.respuesta = ResultadoServicio.incorrecto
                    respuesta.aviso = MensajesPedidosMuestra.CNSNoExistenDatos
                    respuesta.mensaje = Nothing
                End If
            Else
                respuesta.respuesta = ResultadoServicio.incorrecto
                respuesta.aviso = MensajesPedidosMuestra.CNSNoExistenDatos
                respuesta.mensaje = Nothing
            End If
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorConsulta
            respuesta.mensaje = Nothing
        Finally
            objPedidosMuestra = Nothing
            objConvertidor = Nothing
        End Try
        Return respuesta
    End Function

    ''' <summary>
    ''' Inserta pedido muestra (Maestro)
    ''' </summary>
    ''' <param name="pedidoMuestra">objeto PedidoMuetra</param>
    ''' <returns>Regresa el ID de pedido muestra insertado</returns>
    Public Function InsertarPedidoMuestraClase(ByVal pedidoMuestra As PedidoMuestra) As RespuestaRestArray
        Dim objPedidoMuestraDA = New PedidosMuestraDA()
        Dim respuesta = New RespuestaRestArray
        Dim idPedidoMuestra As Int32
        Try
            idPedidoMuestra = objPedidoMuestraDA.InsertarPedidosMuestra(pedidoMuestra)
            respuesta.respuesta = ResultadoServicio.Correcto
            respuesta.aviso = MensajesPedidosMuestra.CNSInsercionPedidoMuestra
            respuesta.mensaje = New Object() {idPedidoMuestra}
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorInsercionPedidoMuestra
            respuesta.mensaje = Nothing
        Finally
            objPedidoMuestraDA = Nothing
        End Try
        Return respuesta
    End Function
    ''' <summary>
    ''' Inserta pedido muestra (Maestro)
    ''' </summary>
    ''' <param name="pedim_clienteid"> ID Cliente</param>
    ''' <param name="pedim_colaboradorid_vendedor">ID Agente</param>
    ''' <param name="pedim_fechacreacion">fecha de creacion</param>
    ''' <param name="pedim_asuntomuestrasid">ID de Asunto</param>
    ''' <param name="pedim_temporadaid">ID de Temporada</param>
    ''' <param name="pedim_fechaentregacliente">Fecha entrega al cliente</param>
    ''' <param name="pedim_estatusid">ID estatus</param>
    ''' <param name="pedim_usuariocreoid">ID usuario</param>
    ''' <returns>Regresa el ID de pedido muestra insertado</returns>
    Public Function InsertarPedidoMuestraParametros(ByVal pedim_clienteid As Integer _
                                          , ByVal pedim_colaboradorid_vendedor As Integer _
                                          , ByVal pedim_fechacreacion As String _
                                          , ByVal pedim_asuntomuestrasid As Integer _
                                          , ByVal pedim_temporadaid As Integer _
                                          , ByVal pedim_fechaentregacliente As String _
                                          , ByVal pedim_estatusid As Integer _
                                          , ByVal pedim_usuariocreoid As Integer _
                                          , ByVal pedim_observaciones As String
) As RespuestaRestArray
        Dim objPedidoMuestraDA = New PedidosMuestraDA()
        Dim respuesta = New RespuestaRestArray
        Dim objPedidoMuestra As New PedidoMuestra
        Dim idPedidoMuestra As Int32

        objPedidoMuestra.pedim_clienteid = pedim_clienteid
        objPedidoMuestra.pedim_colaboradorid_vendedor = pedim_colaboradorid_vendedor
        objPedidoMuestra.pedim_fechaentregacliente = Date.Parse(pedim_fechaentregacliente)
        objPedidoMuestra.pedim_asuntomuestrasid = pedim_asuntomuestrasid
        objPedidoMuestra.pedim_temporadaid = pedim_temporadaid
        objPedidoMuestra.pedim_fechacreacion = Date.Parse(pedim_fechacreacion)
        objPedidoMuestra.pedim_estatusid = pedim_estatusid
        objPedidoMuestra.pedim_usuariocreoid = pedim_usuariocreoid
        objPedidoMuestra.pedim_observaciones = pedim_observaciones

        Try
            idPedidoMuestra = objPedidoMuestraDA.InsertarPedidosMuestra(objPedidoMuestra)
            respuesta.respuesta = ResultadoServicio.Correcto
            respuesta.aviso = MensajesPedidosMuestra.CNSInsercionPedidoMuestra
            respuesta.mensaje = New Object() {idPedidoMuestra}
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorInsercionPedidoMuestra
            respuesta.mensaje = Nothing
        Finally
            objPedidoMuestraDA = Nothing
        End Try
        Return respuesta
    End Function
    ''' <summary>
    ''' Modificar Pedido Muestra
    ''' </summary>
    ''' <param name="pedidoMuestra">Objeto tipo PedidoMuestra</param>
    ''' <returns></returns>
    Public Function ModificarPedidoMuestraClase(ByVal pedidoMuestra As PedidoMuestra) As RespuestaRestArray
        Dim objPedidoMuestraDA = New PedidosMuestraDA()
        Dim respuesta = New RespuestaRestArray
        Dim idPedidoMuestra As Int32
        Try
            idPedidoMuestra = objPedidoMuestraDA.ModificarPedidosMuestra(pedidoMuestra)
            respuesta.respuesta = ResultadoServicio.Correcto
            respuesta.aviso = MensajesPedidosMuestra.CNSInsercionPedidoMuestra
            respuesta.mensaje = New Object() {idPedidoMuestra}
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorInsercionPedidoMuestra
            respuesta.mensaje = Nothing
        Finally
            objPedidoMuestraDA = Nothing
        End Try
        Return respuesta
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="pedim_pedidoid"></param>
    ''' <param name="pedim_clienteid"></param>
    ''' <param name="pedim_colaboradorid_vendedor"></param>
    ''' <param name="pedim_fechacreacion"></param>
    ''' <param name="pedim_asuntomuestrasid"></param>
    ''' <param name="pedim_temporadaid"></param>
    ''' <param name="pedim_fechaentregacliente"></param>
    ''' <param name="pedim_estatusid"></param>
    ''' <param name="pedim_usuariocreoid"></param>
    ''' <returns></returns>
    Public Function ModificarPedidoMuestraParametros(ByVal pedim_pedidoid As Integer _
                                                     , ByVal pedim_clienteid As Integer _
                                                     , ByVal pedim_colaboradorid_vendedor As Integer _
                                                     , ByVal pedim_fechacreacion As String _
                                                     , ByVal pedim_asuntomuestrasid As Integer _
                                                     , ByVal pedim_temporadaid As Integer _
                                                     , ByVal pedim_fechaentregacliente As String _
                                                     , ByVal pedim_estatusid As Integer _
                                                     , ByVal pedim_usuariocreoid As Integer _
                                                     , ByVal pedim_observaciones As String
                                                    ) As RespuestaRestArray
        Dim objPedidoMuestraDA = New PedidosMuestraDA()
        Dim respuesta = New RespuestaRestArray
        Dim idPedidoMuestra As Int32
        Dim objPedidoMuestra As New PedidoMuestra()
        Try

            objPedidoMuestra.pedim_pedidoid = pedim_pedidoid
            objPedidoMuestra.pedim_clienteid = pedim_clienteid
            objPedidoMuestra.pedim_colaboradorid_vendedor = pedim_colaboradorid_vendedor
            objPedidoMuestra.pedim_fechaentregacliente = Date.Parse(pedim_fechaentregacliente)
            objPedidoMuestra.pedim_asuntomuestrasid = pedim_asuntomuestrasid
            objPedidoMuestra.pedim_temporadaid = pedim_temporadaid
            objPedidoMuestra.pedim_fechacreacion = Date.Parse(pedim_fechacreacion)
            objPedidoMuestra.pedim_estatusid = pedim_estatusid
            objPedidoMuestra.pedim_usuariocreoid = pedim_usuariocreoid
            objPedidoMuestra.pedim_observaciones = pedim_observaciones


            idPedidoMuestra = objPedidoMuestraDA.ModificarPedidosMuestra(objPedidoMuestra)
            respuesta.respuesta = ResultadoServicio.Correcto
            respuesta.aviso = MensajesPedidosMuestra.CNSInsercionPedidoMuestra
            respuesta.mensaje = New Object() {idPedidoMuestra}
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorInsercionPedidoMuestra
            respuesta.mensaje = Nothing
        Finally
            objPedidoMuestraDA = Nothing
        End Try
        Return respuesta
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="objDedidoDetalle"></param>
    ''' <returns></returns>
    Public Function InsertarPedidoMuestraDetalleClase(ByVal objDedidoDetalle As PedidoMuestraDetalle, ByVal ejecutivo As Integer) As RespuestaRestArray
        Dim objPedidoMuestraDA = New PedidosMuestraDA()
        Dim respuesta = New RespuestaRestArray
        Dim idPedidoMuestra As Int32

        Try
            idPedidoMuestra = objPedidoMuestraDA.InsertarPedidosMuestraDetalle(objDedidoDetalle, ejecutivo)
            respuesta.respuesta = ResultadoServicio.Correcto
            respuesta.aviso = MensajesPedidosMuestra.CNSInsercionPedidoMuestra
            respuesta.mensaje = New Object() {idPedidoMuestra}
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorInsercionPedidoMuestra
            respuesta.mensaje = Nothing
        Finally
            objPedidoMuestraDA = Nothing
        End Try
        Return respuesta
    End Function

    Public Function InsertarPedidoMuestraDetalleParametros(ByVal pdetm_pedidoid As Integer _
            , ByVal pdetm_productoestiloid As Integer _
            , ByVal pdetm_unidadmedidaid As Integer _
            , ByVal pdetm_estatusid As Integer _
            , ByVal pdetm_talla As String _
            , ByVal pdetm_cantidad As Integer _
            , ByVal pdetm_costo As Double _
            , ByVal pdetm_fechaentregacliente As String _
            , ByVal pdetm_fechaentregareal As String _
            , ByVal pdetm_anotacion As String _
            , ByVal pdetm_fechacancelacion As String _
            , ByVal pdetm_estatuscancelacionid As Integer _
            , ByVal pdetm_motivocancelacion As String _
            , ByVal pdetm_fechacreacion As String _
            , ByVal pdetm_usuariocreoid As Integer _
        , ByVal pdtm_ejecutivo As Integer
        ) As RespuestaRestArray

        Dim objPedidoMuestraDA = New PedidosMuestraDA()
        Dim respuesta = New RespuestaRestArray
        Dim idPedidoMuestra As Int32
        Dim objDedidoDetalle As New PedidoMuestraDetalle

        objDedidoDetalle.pdetm_pedidoid = pdetm_pedidoid
        objDedidoDetalle.pdetm_productoestiloid = pdetm_productoestiloid
        objDedidoDetalle.pdetm_unidadmedidaid = pdetm_unidadmedidaid
        objDedidoDetalle.pdetm_estatusid = pdetm_estatusid
        objDedidoDetalle.pdetm_talla = pdetm_talla
        objDedidoDetalle.pdetm_cantidad = pdetm_cantidad
        objDedidoDetalle.pdetm_costo = pdetm_costo
        objDedidoDetalle.pdetm_fechaentregacliente = Date.Parse(pdetm_fechaentregacliente)
        objDedidoDetalle.pdetm_fechaentregareal = Date.Parse(pdetm_fechaentregareal)
        objDedidoDetalle.pdetm_anotacion = pdetm_anotacion
        objDedidoDetalle.pdetm_fechacancelacion = Date.Parse(pdetm_fechacancelacion)
        objDedidoDetalle.pdetm_estatuscancelacionid = pdetm_estatuscancelacionid
        objDedidoDetalle.pdetm_motivocancelacion = pdetm_motivocancelacion
        objDedidoDetalle.pdetm_fechacreacion = Date.Parse(pdetm_fechacreacion)
        objDedidoDetalle.pdetm_usuariocreoid = pdetm_usuariocreoid
        Try
            idPedidoMuestra = objPedidoMuestraDA.InsertarPedidosMuestraDetalle(objDedidoDetalle, pdtm_ejecutivo)
            respuesta.respuesta = ResultadoServicio.Correcto
            respuesta.aviso = MensajesPedidosMuestra.CNSInsercionPedidoMuestra
            respuesta.mensaje = New Object() {idPedidoMuestra}
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorInsercionPedidoMuestra
            respuesta.mensaje = Nothing
        Finally
            objPedidoMuestraDA = Nothing
        End Try
        Return respuesta
    End Function

    Public Function ModificarPedidoMuestraDetalleClase(ByVal objDedidoDetalle As PedidoMuestraDetalle, ByVal idEjecutivo As Int32) As RespuestaRestArray
        Dim objPedidoMuestraDA = New PedidosMuestraDA()
        Dim respuesta = New RespuestaRestArray
        Dim idPedidoMuestra As Int32

        Try
            idPedidoMuestra = objPedidoMuestraDA.ModificarPedidosMuestraDetalle(objDedidoDetalle, idEjecutivo)
            respuesta.respuesta = ResultadoServicio.Correcto
            respuesta.aviso = MensajesPedidosMuestra.CNSInsercionPedidoMuestra
            respuesta.mensaje = New Object() {idPedidoMuestra}
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorInsercionPedidoMuestra
            respuesta.mensaje = Nothing
        Finally
            objPedidoMuestraDA = Nothing
        End Try
        Return respuesta
    End Function


    Public Function ConsultaPedidsMuestraGeneralArreglo(ByVal filtro As String _
           , ByVal fechaInicio As DateTime? _
           , ByVal fechaFin As DateTime? _
           , ByVal usuario As Integer _
           , ByVal perfil As Integer _
           , ByVal agente As Integer _
           , ByVal finalizado As Integer _
           , Optional ByVal encabezado As Int32 = 0
        ) As RespuestaRestArray

        Dim objPedidoMuestraDA = New PedidosMuestraDA()
        Dim respuesta = New RespuestaRestArray
        Dim convetidor As New Convertidor(Of PedidoMuestra)
        Dim tabla As DataTable

        Try
            tabla = objPedidoMuestraDA.PedidosMuestraGeneral(filtro, fechaInicio, fechaFin, usuario, perfil, agente, finalizado)
            respuesta.respuesta = ResultadoServicio.Correcto
            respuesta.aviso = MensajesPedidosMuestra.CNSInsercionPedidoMuestra
            respuesta.mensaje = convetidor.DataTableToArray(encabezado, tabla)
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorInsercionPedidoMuestra
            respuesta.mensaje = Nothing
        Finally
            objPedidoMuestraDA = Nothing
            convetidor = Nothing
        End Try
        Return respuesta
    End Function
    Public Function ConsultarPerfilesUsuarioArreglo(ByVal login As String, Optional ByVal encabezado As Integer = 0) As RespuestaRestArray

        Dim objPedidoMuestraDA = New PedidosMuestraDA()
        Dim respuesta = New RespuestaRestArray
        Dim convetidor As New Convertidor(Of PedidoMuestra)
        Dim tabla As DataTable

        Try
            tabla = objPedidoMuestraDA.ConsultaPerfilUsuario(login)
            respuesta.respuesta = ResultadoServicio.Correcto
            respuesta.aviso = MensajesPedidosMuestra.CNSAccionRealizada
            respuesta.mensaje = convetidor.DataTableToArray(encabezado, tabla)
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorInsercionPedidoMuestra
            respuesta.mensaje = Nothing
        Finally
            objPedidoMuestraDA = Nothing
            convetidor = Nothing
        End Try
        Return respuesta
    End Function

    Public Function ConsultarTemporadasArreglo() As RespuestaRestArray
        Dim objPedidoMuestraDA = New PedidosMuestraDA()
        Dim respuesta = New RespuestaRestArray
        Dim convetidor As New Convertidor(Of PedidoMuestra)
        Dim tabla As DataTable

        Try
            tabla = objPedidoMuestraDA.ConsultaTemporadas()
            If tabla.Rows IsNot Nothing Then
                If tabla.Rows.Count > 0 Then
                    respuesta.respuesta = ResultadoServicio.Correcto
                    respuesta.aviso = MensajesPedidosMuestra.CNSAccionRealizada
                    respuesta.mensaje = convetidor.DataTableToArray(0, tabla)
                Else
                    respuesta.respuesta = ResultadoServicio.incorrecto
                    respuesta.aviso = MensajesPedidosMuestra.CNSNoExistenDatos
                    respuesta.mensaje = Nothing
                End If
            Else
                respuesta.respuesta = ResultadoServicio.incorrecto
                respuesta.aviso = MensajesPedidosMuestra.CNSNoExistenDatos
                respuesta.mensaje = Nothing
            End If


        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorConsulta
            respuesta.mensaje = Nothing
        Finally
            objPedidoMuestraDA = Nothing
            convetidor = Nothing
        End Try
        Return respuesta
    End Function
    Public Function ConsultarUnidadMedidaArreglo() As RespuestaRestArray
        Dim objPedidoMuestraDA = New PedidosMuestraDA()
        Dim respuesta = New RespuestaRestArray
        Dim convetidor As New Convertidor(Of PedidoMuestra)
        Dim tabla As DataTable

        Try
            tabla = objPedidoMuestraDA.ConsultaUnidadesMedida()
            If tabla.Rows IsNot Nothing Then
                If tabla.Rows.Count > 0 Then
                    respuesta.respuesta = ResultadoServicio.Correcto
                    respuesta.aviso = MensajesPedidosMuestra.CNSAccionRealizada
                    respuesta.mensaje = convetidor.DataTableToArray(0, tabla)
                Else
                    respuesta.respuesta = ResultadoServicio.incorrecto
                    respuesta.aviso = MensajesPedidosMuestra.CNSNoExistenDatos
                    respuesta.mensaje = Nothing
                End If
            Else
                respuesta.respuesta = ResultadoServicio.incorrecto
                respuesta.aviso = MensajesPedidosMuestra.CNSNoExistenDatos
                respuesta.mensaje = Nothing
            End If


        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorConsulta
            respuesta.mensaje = Nothing
        Finally
            objPedidoMuestraDA = Nothing
            convetidor = Nothing
        End Try
        Return respuesta
    End Function

    Public Function ConsultarDetalleTallas(ByVal idtalla As Int32) As RespuestaRestArray
        Dim objPedidoMuestraDA = New PedidosMuestraDA()
        Dim respuesta = New RespuestaRestArray
        Dim convetidor As New Convertidor(Of PedidoMuestra)
        Dim tabla As DataTable

        Try
            tabla = objPedidoMuestraDA.ConsultaDetalleTallas(idtalla)
            If tabla.Rows IsNot Nothing Then
                If tabla.Rows.Count > 0 Then
                    respuesta.respuesta = ResultadoServicio.Correcto
                    respuesta.aviso = MensajesPedidosMuestra.CNSAccionRealizada
                    respuesta.mensaje = convetidor.DataTableToArray(0, tabla)
                Else
                    respuesta.respuesta = ResultadoServicio.incorrecto
                    respuesta.aviso = MensajesPedidosMuestra.CNSNoExistenDatos
                    respuesta.mensaje = Nothing
                End If
            Else
                respuesta.respuesta = ResultadoServicio.incorrecto
                respuesta.aviso = MensajesPedidosMuestra.CNSNoExistenDatos
                respuesta.mensaje = Nothing
            End If


        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorConsulta
            respuesta.mensaje = Nothing
        Finally
            objPedidoMuestraDA = Nothing
            convetidor = Nothing
        End Try
        Return respuesta
    End Function

    Public Function ConsultaPedidoMuestraDetWebArreglo(ByVal idPedido As Int32) As RespuestaRestArray

        Dim objPedidoMuestraDA = New PedidosMuestraDA()
        Dim respuesta = New RespuestaRestArray
        Dim convetidor As New Convertidor(Of PedidoMuestra)
        Dim tabla As DataTable

        Try
            tabla = objPedidoMuestraDA.ConsultarPedidosMuestraDetalleWeb(idPedido)
            respuesta.respuesta = ResultadoServicio.Correcto
            respuesta.aviso = MensajesPedidosMuestra.CNSAccionRealizada
            respuesta.mensaje = convetidor.DataTableToArray(0, tabla)
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorConsulta
            respuesta.mensaje = Nothing
        Finally
            objPedidoMuestraDA = Nothing
            convetidor = Nothing
        End Try
        Return respuesta

    End Function

    Private Function ReportePedidoMuestras(ByVal Accion As Integer, ByVal Folio As Integer) As DataTable
        Dim PedidoMuestrasDatos = New PedidosMuestraDA()
        Return PedidoMuestrasDatos.ReportePedidoMuestras(Accion, Folio)
    End Function


    Private Function subirFtp(ByVal ruta As String, ByVal archivo As String) As Boolean
        Try
            Dim objFTP As New TransferenciaFTPBU
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)

            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
            objFTP.EnviarArchivo(ruta, archivo)

            Dim srtRuta As String = objFTP.obtenerURL & "/" & ruta & "/" & IO.Path.GetFileName(archivo)
            'Dim srtRuta As String = ruta & "/" & IO.Path.GetFileName(archivo)
            If objFTP.FtpExisteArchivo(srtRuta) Then
                Return True
            Else
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Public Function GeneraPedidosMuestraPdf(ByVal idPedido As Int32) As RespuestaRestArray

        Dim objPedidoMuestraDA = New PedidosMuestraDA()
        Dim respuesta = New RespuestaRestArray
        Dim convetidor As New Convertidor(Of PedidoMuestra)
        If idPedido > 0 Then
            Dim OBJBU As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            Dim dtPedido As DataTable
            Dim dtPedidosMuestras As DataTable
            Dim pdfSettings = New StiPdfExportSettings()
            Dim fecha() As String
            Dim fechaE() As String
            EntidadReporte = OBJBU.LeerReporteporClave("PEDIDO_MUESTRAS")
            'Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            '    LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
            Dim archivo As String = "C:\PedidosMuestras" + "\" + LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport
            reporte.Load(archivo)
            reporte.Compile()
            dtPedido = ReportePedidoMuestras(1, idPedido)
            fecha = Split(dtPedido.Rows(0).Item("Fecha_Creacion"), "/")
            fechaE = Split(dtPedido.Rows(0).Item("Fecha_Entrega_Cliente"), "/")
            reporte("urlImagenNave") = "http://192.168.2.158/nomina/LOGOTIPOS/GRUPOYUYIN.JPG"
            reporte("Pedido") = dtPedido.Rows(0).Item("Folio").ToString
            reporte("Observaciones") = dtPedido.Rows(0).Item("Observaciones").ToString
            reporte("Dia") = fecha(0).ToString
            reporte("Mes") = fecha(1).ToString
            reporte("Año") = fecha(2).ToString
            reporte("diaE") = fechaE(0).ToString
            reporte("MesE") = fechaE(1).ToString
            reporte("AñoE") = fechaE(2).ToString
            reporte("Capturo") = dtPedido.Rows(0).Item("NombreUsuarioCreo").ToString
            reporte("Vendedor") = dtPedido.Rows(0).Item("Agente").ToString
            reporte("Cliente") = dtPedido.Rows(0).Item("Cliente").ToString
            'reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
            'reporte("elaboro") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString.ToUpper
            Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
            File = "PEDIDO_MUESTRAS_" + fecha_hora + ".pdf"
            sPDF = "C:\PedidosMuestras\" + "PEDIDO_MUESTRAS_" + fecha_hora + ".pdf"
            dtPedidosMuestras = ReportePedidoMuestras(2, idPedido)

            reporte.Dictionary.Clear()
            reporte.RegData(dtPedidosMuestras)
            reporte.Dictionary.Synchronize()
            'reporte.Show()

            reporte.Render()
            reporte.ExportDocument(StiExportFormat.Pdf, sPDF, pdfSettings)
            reporte.Dispose()
            subirFtp("Programacion/Muestras", sPDF)
        End If
        Try

            respuesta.respuesta = ResultadoServicio.Correcto
            'respuesta.aviso = MensajesPedidosMuestra.CNSAccionRealizada
            respuesta.aviso = File
            'File
            Dim var(0) As Object
            var(0) = File
            respuesta.mensaje = var
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = ex.Message.ToString
            respuesta.mensaje = Nothing
        Finally
            objPedidoMuestraDA = Nothing
            convetidor = Nothing
        End Try
        Return respuesta

    End Function

    Public Function ConsultaPedidoMuestraWebArreglo(ByVal idPedido As Int32, ByVal accion As Int32) As RespuestaRestArray

        Dim objPedidoMuestraDA = New PedidosMuestraDA()
        Dim respuesta = New RespuestaRestArray
        Dim convetidor As New Convertidor(Of PedidoMuestra)
        Dim tabla As DataTable

        Try
            tabla = objPedidoMuestraDA.ConsultarPedidosMuestraWeb(idPedido, accion)
            respuesta.respuesta = ResultadoServicio.Correcto
            respuesta.aviso = MensajesPedidosMuestra.CNSAccionRealizada
            respuesta.mensaje = convetidor.DataTableToArray(0, tabla)
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorConsulta
            respuesta.mensaje = Nothing
        Finally
            objPedidoMuestraDA = Nothing
            convetidor = Nothing
        End Try
        Return respuesta
    End Function

    Public Function EliminarPedidoMuestraWebArreglo(ByVal idPedido As Int32) As RespuestaRestArray

        Dim objPedidoMuestraDA = New PedidosMuestraDA()
        Dim respuesta = New RespuestaRestArray
        Dim convetidor As New Convertidor(Of PedidoMuestra)
        Dim tabla As DataTable

        Try
            tabla = objPedidoMuestraDA.EliminarPedidosMuestraWeb(idPedido)
            respuesta.respuesta = ResultadoServicio.Correcto
            respuesta.aviso = MensajesPedidosMuestra.CNSAccionRealizada
            respuesta.mensaje = convetidor.DataTableToArray(0, tabla)
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorConsulta
            respuesta.mensaje = Nothing
        Finally
            objPedidoMuestraDA = Nothing
            convetidor = Nothing
        End Try
        Return respuesta
    End Function

    Public Function CopiarPedidoMuestra(ByVal idPedido As Int32, ByVal IdUsuario As Int32) As RespuestaRestArray

        Dim objPedidoMuestraDA = New PedidosMuestraDA()
        Dim respuesta = New RespuestaRestArray
        Dim convetidor As New Convertidor(Of PedidoMuestra)
        Dim tabla As DataTable

        Try
            tabla = objPedidoMuestraDA.CopiarPedidoMuestra(idPedido, IdUsuario)
            respuesta.respuesta = ResultadoServicio.Correcto
            respuesta.aviso = MensajesPedidosMuestra.CNSAccionRealizada
            respuesta.mensaje = convetidor.DataTableToArray(0, tabla)
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorConsulta
            respuesta.mensaje = Nothing
        Finally
            objPedidoMuestraDA = Nothing
            convetidor = Nothing
        End Try
        Return respuesta
    End Function

    Public Function ValidarPedidosMuestra(ByVal pdetm_pedidoid As Integer _
        , ByVal pdetm_estatusid As Integer _
        , ByVal pdetm_estatusid2 As Integer _
        , ByVal pdtm_ejecutivo As Integer
       ) As RespuestaRestArray
        Dim objPedidoMuestraDA = New PedidosMuestraDA()
        Dim respuesta = New RespuestaRestArray
        Dim validacion As Int32
        Dim objDedidoDetalle As New PedidoMuestraDetalle
        Try
            validacion = objPedidoMuestraDA.ValidarPedidosMuestraProductos(pdetm_pedidoid, pdetm_estatusid, pdetm_estatusid2, pdtm_ejecutivo)

            If (validacion = ValidacionProductosDetalle.Duplicados) Then
                respuesta.respuesta = ResultadoServicio.incorrecto
                respuesta.aviso = MensajesPedidosMuestra.CNSPedidosDetalleDuplicados
            Else
                respuesta.respuesta = ResultadoServicio.Correcto
                respuesta.aviso = MensajesPedidosMuestra.CNSGuardarPedidosMuestra
            End If
            respuesta.mensaje = New Object() {validacion}
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorInsercionPedidoMuestra
            respuesta.mensaje = Nothing
        Finally
            objPedidoMuestraDA = Nothing
        End Try
        Return respuesta
    End Function


#Region "Valida Usuario"
    Public Function ValidaAgenteXUsuario(ByVal idUsuario As Integer) As RespuestaRestArray
        Dim objPedidoMuestraDA = New PedidosMuestraDA()
        Dim respuesta = New RespuestaRestArray
        Dim validacion As DataTable
        Dim convetidor As New Convertidor(Of PedidoMuestra)
        Dim objDedidoDetalle As New PedidoMuestraDetalle
        Try
            validacion = objPedidoMuestraDA.ValidaAgenteBaseUsuario(idUsuario)
            respuesta.respuesta = ResultadoServicio.Correcto
            respuesta.aviso = MensajesPedidosMuestra.CNSOperacionRealizada
            respuesta.mensaje = convetidor.DataTableToArray(0, validacion)
        Catch ex As Exception
            respuesta.respuesta = ResultadoServicio.incorrecto
            respuesta.aviso = MensajesPedidosMuestra.CNSErrorConsulta
            respuesta.mensaje = Nothing
        Finally
            objPedidoMuestraDA = Nothing
        End Try
        Return respuesta
    End Function
#End Region


End Class
