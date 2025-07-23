Imports Entidades
Imports ToolServicios
Imports Programacion.Datos

Public Class AsuntoBU
    ''' <summary>
    ''' Obtiene los asuntos para pedidos muestra
    ''' </summary>
    ''' <returns>Lista enlazada tipo asunto</returns>
    Public Function ConsultaAsuntosMuestraLista() As RespuestaRestLista(Of Asunto)
        Dim objPedidosMuestra As New PedidosMuestraDA()
        Dim objConvertidor As New Convertidor(Of Asunto)()
        Dim respuesta As New RespuestaRestLista(Of Asunto)
        Dim tabla As DataTable = Nothing
        Try
            tabla = objPedidosMuestra.ConsultaAsuntosMuestra()
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
    ''' Obtiene los asuntos para pedido muestra 
    ''' </summary>
    ''' <param name="encabezados">Si encabezado es diferente de 0, las 2 primeras filas son columnas y tipo de dato</param>
    ''' <returns>retorna arreglo de objetos</returns>
    Public Function ConsultaAsuntosMuestraArreglo(Optional ByVal encabezados As Int32 = 0) As RespuestaRestArray
        Dim objPedidosMuestra As New PedidosMuestraDA()
        Dim objConvertidor As New Convertidor(Of Asunto)()
        Dim respuesta As New RespuestaRestArray
        Dim tabla As DataTable = Nothing
        Try
            tabla = objPedidosMuestra.ConsultaAsuntosMuestra()
            If tabla.Rows IsNot Nothing Then
                If tabla.Rows.Count > 0 Then
                    respuesta.respuesta = ResultadoServicio.Correcto
                    respuesta.aviso = MensajesPedidosMuestra.CNSAccionRealizada
                    respuesta.mensaje = objConvertidor.DataTableToArray(encabezados, tabla)
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
