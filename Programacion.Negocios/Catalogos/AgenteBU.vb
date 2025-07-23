Imports Entidades
Imports ToolServicios
Imports Programacion.Datos
Imports EntidadesFachada.Programacion

Public Class AgenteBU
    ''' <summary>
    ''' Obtiene Agentes para pedidos muestra
    ''' </summary>
    ''' <param name="idCliente">Si idCliente es igual 0 obtienen todos</param>
    ''' <returns>Lista enlazada de tipo AgenteFachada</returns>
    Public Function ConsultaAgentesPedidosMuestra(Optional ByVal idCliente As Int32 = 0) As RespuestaRestLista(Of AgenteFachada)
        Dim objPedidosMuestra As New PedidosMuestraDA()
        Dim objConvertidor As New Convertidor(Of AgenteFachada)()
        Dim respuesta As New RespuestaRestLista(Of AgenteFachada)
        Dim tabla As DataTable = Nothing
        Try
            tabla = objPedidosMuestra.ListaAgente(idCliente)
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
    ''' Obtiene agentes para pedido muestra
    ''' </summary>
    ''' <param name="idCliente">Si idCliente es igual 0 obtienen todos</param>
    ''' <param name="encabezado">Si es diferente de 0, se agregar las primeras 2 filas con nombres y tipos de dato</param>
    ''' <returns>Arreglo tipo objeto</returns>
    Public Function ConsultaAgentesPedidosMuestraArreglo(Optional ByVal idCliente As Int32 = 0, Optional ByVal encabezado As Int32 = 0) As RespuestaRestArray
        Dim objPedidosMuestra As New PedidosMuestraDA()
        Dim objConvertidor As New Convertidor(Of AgenteFachada)()
        Dim respuesta As New RespuestaRestArray
        Dim tabla As DataTable = Nothing
        Try
            tabla = objPedidosMuestra.ListaAgente(idCliente)
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
