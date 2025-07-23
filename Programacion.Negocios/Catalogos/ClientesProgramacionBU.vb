Imports Entidades
Imports EntidadesFachada.Programacion
Imports ToolServicios

Public Class ClientesProgramacionBU

    Public Function llenarListaClientesConsulta(ByVal marcaid As Int32) As DataTable
        Dim objCliente As New Datos.ClientesProgramacionDA
        Return objCliente.llenarListaClientesConsulta(marcaid)
    End Function

    Public Function mostrarClientesAgregarConsulta(ByVal marcaid As Int32)
        Dim objCliente As New Datos.ClientesProgramacionDA
        Return objCliente.mostrarClientesAgregarConsulta(marcaid)
    End Function

    Public Sub inactivarRelacionMarcaCliente(ByVal idMarca As Int32)
        Dim objCliente As New Datos.ClientesProgramacionDA
        objCliente.inactivarRelacionMarcaCliente(idMarca)
    End Sub

    Public Sub registrarRelacionMarcaCLiente(ByVal idMarca As Int32, ByVal idCliente As Int32)
        Dim objCliente As New Datos.ClientesProgramacionDA
        objCliente.registrarRelacionMarcaCLiente(idMarca, idCliente)
    End Sub

    Public Function mostrarTodosLosClientes(ByVal idMarca As Int32)
        Dim objCliente As New Datos.ClientesProgramacionDA
        Return objCliente.mostrarTodosLosClientes(idMarca)
    End Function

    Public Sub registrarClienteDescripcionModelo(ByVal idDescripcion As Int32, ByVal idCliente As Int32, ByVal idModelo As Int32, ByVal descripcion As String)
        Dim objCliente As New Datos.ClientesProgramacionDA
        objCliente.registrarClienteDescripcionModelo(idDescripcion, idCliente, idModelo, descripcion)
    End Sub

    Public Function mostrarClientesColeccionMarca(ByVal idMarca As Int32, ByVal idColeccion As Int32) As DataTable
        Dim objCliente As New Datos.ClientesProgramacionDA
        Return objCliente.mostrarClientesColeccionMarca(idMarca, idColeccion)
    End Function

    Public Function mostrarDescripcionPorModelo(ByVal idModelo As Int32) As DataTable
        Dim objCliente As New Datos.ClientesProgramacionDA
        Return objCliente.mostrarDescripcionPorModelo(idModelo)
    End Function

    Public Function ConsultaClientesExclucionProductosNuevos() As DataTable
        Dim objCliente As New Datos.ClientesProgramacionDA
        Return objCliente.ConsultaClientesExclucionProductosNuevos
    End Function

    Public Sub editarExcluirCliente(ByVal excluir As Boolean, ByVal idCliente As Int32)
        Dim objCliente As New Datos.ClientesProgramacionDA
        objCliente.editarExcluirCliente(excluir, idCliente)
    End Sub
#Region "Pedidos Muestra"
    ''' <summary>
    ''' Obtienen los clientes para pedidos Muestra
    ''' </summary>
    ''' <param name="idCliente">Opcional trar todos o el especifico</param>
    ''' <param name="encabezado">  si es 0 solo trae los datos, sino carga los encabezados y el tipo de dato para trabajarlo como DataTable</param>
    ''' <returns>regresa un RespuestaRestArray con mensaje = arreglo de objetos</returns>
    Public Function ConsultaClientesPedidosMuestraArray(ByVal idCliente As Int32?, Optional ByVal encabezado As Int32 = 0) As RespuestaRestArray
        Dim objPedidosMuestraDA As New Datos.PedidosMuestraDA
        Dim tabla As DataTable = Nothing
        Dim respuesta As New RespuestaRestArray
        Dim conversor As New Convertidor(Of Object)

        Try
            tabla = objPedidosMuestraDA.ConsultaClientesMuestras(idCliente)
            If tabla.Rows IsNot Nothing Then
                If tabla.Rows.Count > 0 Then
                    respuesta.respuesta = ResultadoServicio.Correcto
                    respuesta.aviso = MensajesPedidosMuestra.CNSAccionRealizada
                    respuesta.mensaje = conversor.DataTableToArray(encabezado, tabla)
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
            conversor = Nothing
            objPedidosMuestraDA = Nothing
        End Try
        Return respuesta
    End Function
    ''' <summary>
    ''' Trae los clientes en lsita enlazada
    ''' </summary>
    ''' <param name="idCliente"></param>
    ''' <returns>lista enlazada de clientes</returns>
    Public Function ConsultaClientesPedidosMuestraList(ByVal idCliente As Int32) As RespuestaRestLista(Of ClienteFachada)
        Dim objPedidosMuestraDA As New Datos.PedidosMuestraDA
        Dim tabla As DataTable = Nothing
        Dim respuesta As New RespuestaRestLista(Of ClienteFachada)
        Dim conversor As New Convertidor(Of ClienteFachada)

        Try
            tabla = objPedidosMuestraDA.ConsultaClientesMuestras(idCliente)
            If tabla.Rows IsNot Nothing Then
                If tabla.Rows.Count > 0 Then
                    respuesta.respuesta = ResultadoServicio.Correcto
                    respuesta.aviso = MensajesPedidosMuestra.CNSAccionRealizada
                    respuesta.mensaje = conversor.DataTableToList(tabla)
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
            conversor = Nothing
            objPedidosMuestraDA = Nothing
        End Try
        Return respuesta
    End Function
#End Region
End Class
