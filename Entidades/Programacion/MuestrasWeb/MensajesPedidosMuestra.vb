Public NotInheritable Class MensajesPedidosMuestra

    ''' <summary>
    ''' Mensajes de aviso para admon de Pedidos Muestra
    ''' </summary>
    Public Const CNSOperacionRealizada As String = "Operación realizada satisfactoriamente"
    Public Const CNSInsercionPedidoMuestra As String = "Pedido muestra realizado correctamente"
    Public Const CNSErrorInsercionPedidoMuestra As String = "Ocurrio un error en la inserción de Pedidos Muestra"
    Public Const CNSErrorInsercionDetallePedidosMuestra As String = "Ocurrio un error en la inserción de productos en Pedidos Muestra"
    Public Const CNSNoExistenDatos As String = "No existen datos con estas carateristicas"
    Public Const CNSAccionRealizada As String = "Accion realizada"
    Public Const CNSErrorConsulta As String = "Error al consultar la información"
    Public Const CNSPedidosDetalleDuplicados As String = "Existe productos con la misma talla y unidad de medida"
    Public Const CNSGuardarPedidosMuestra As String = "El Pedido Muestra se guardo correctamente"

End Class

Public Enum OpcionesPedidosMuestra
    Insertar = 1
    Modificar = 2
    Consultar = 3
End Enum

Public Enum ResultadoServicio
    Correcto = 1
    incorrecto = 0
End Enum

Public Enum ValidacionProductosDetalle
    Duplicados = 1
    NoDuplicados = 0
End Enum
