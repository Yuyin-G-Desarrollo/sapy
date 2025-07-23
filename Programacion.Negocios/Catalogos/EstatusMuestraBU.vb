Imports Entidades
Imports ToolServicios
Imports Programacion.Datos
Imports EntidadesFachada.Programacion
Public Class EstatusMuestraBU
    ''' <summary>
    ''' Obtiene el id de estatus para Pedidos Muestra
    ''' </summary>
    ''' <param name="opcion">1= Abierto, 2= Capturado, 3= Autorizado</param>
    ''' <returns>Lista enlazada tipo Estatus Muestra</returns>
    Public Function ConsultaEstatusMuestra(ByVal opcion As Int32) As RespuestaRestLista(Of EstatusMuestra)
        Dim objPedidosMuestra As New PedidosMuestraDA()
        Dim objConvertidor As New Convertidor(Of EstatusMuestra)()
        Dim respuesta As New RespuestaRestLista(Of EstatusMuestra)
        Dim tabla As DataTable = Nothing
        Try
            tabla = objPedidosMuestra.ConsultaEstatusMuestras(opcion)
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
    ''' Obtiene estatus para pedidos muestra
    ''' </summary>
    ''' <param name="opcion">1= Abierto, 2= Capturado, 3= Autorizado</param>
    ''' <param name="encabezado">Si es diferente de 0, se agregar las primeras 2 filas con nombres y tipos de dato</param>
    ''' <returns>Arreglo de objetos con estatus correspondiente</returns>
    Public Function ConsultaEstatusMuestraArreglo(ByVal opcion As Int32, Optional ByVal encabezado As Int32 = 0) As RespuestaRestArray
        Dim objPedidosMuestra As New PedidosMuestraDA()
        Dim objConvertidor As New Convertidor(Of EstatusMuestra)()
        Dim respuesta As New RespuestaRestArray
        Dim tabla As DataTable = Nothing
        Try
            tabla = objPedidosMuestra.ConsultaEstatusMuestras(opcion)
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
End Class
