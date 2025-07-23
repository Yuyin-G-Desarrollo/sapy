Public Class ProductosBu
    'Clase con todos los metodos relacionados al producto para pedidos web

    Public Function recuperarColeccionesPorMarcaDescripcion(ByVal idListaPrecio As Int32, ByVal idmarca As Int32, ByVal descripcion As String, ByVal idAgente As Int32) As DataTable
        Dim objDa As New Datos.ProductosDA
        Dim dtColecciones As New DataTable
        dtColecciones = objDa.recuperarColeccionesPorMarcaDescripcion(idListaPrecio, idmarca, descripcion, idAgente)
        Return dtColecciones
    End Function

    'funcion para recuperar la lista de productos por modelo
    Public Function recuperarProductosConsultaPorLPPorModelo(ByVal tipoConsulta As Int32, ByVal idListaPrecio As Int32, ByVal idCliente As Int32, ByVal idModeloSay As String, ByVal idModeloSicy As String, ByVal idAgente As Int32) As DataTable
        Dim objDa As New Datos.ProductosDA
        Dim dtProductos As New DataTable
        dtProductos = objDa.recuperarProductosConsultaPorLPPorModelo(tipoConsulta, idListaPrecio, idCliente, idModeloSay, idModeloSicy, idAgente)
        Return dtProductos
    End Function


    ''funcion para recuperar las listas de precio de un cliente
    Public Function recuperarListasPreciosCliente(ByVal idCliente As Int32) As DataTable
        Dim objDa As New Datos.ProductosDA
        Dim dtListas As New DataTable
        dtListas = objDa.recuperarListasPreciosCliente(idCliente)
        Return dtListas
    End Function

    '' funcion para recuperar el modelo original en la consulta de productos.
    Public Function recuperarModeloOriginalProductos(ByVal idListaPrecio As Int32, ByVal modeloSay As String, ByVal modeloSicy As String) As DataTable
        Dim objDa As New Datos.ProductosDA
        Dim dtModelo As New DataTable
        dtModelo = objDa.recuperarModeloOriginalProductos(idListaPrecio, modeloSay, modeloSicy)
        Return dtModelo
    End Function

    ' funcion para recuperar la consulta de modelos con el filtro de coleccioin completa pedidos web
    Public Function recuperarConsultaProductosColeccionCompleta(ByVal tipoConsulta As Int32, ByVal idListaPrecio As Int32, ByVal idMarcas As String, ByVal modeloSay As String, ByVal modeloSicy As String, ByVal idAgente As Int32) As DataTable
        Dim objDa As New Datos.ProductosDA
        Dim dtProductosC As New DataTable
        dtProductosC = objDa.recuperarConsultaProductosColeccionCompleta(tipoConsulta, idListaPrecio, idMarcas, modeloSay, modeloSicy, idAgente)
        Return dtProductosC
    End Function

    'funcion para recuperar la lista de productos consultados por modelo sustituto
    Public Function recuperarConsultaProductosModeloSustituto(ByVal tipoConsulta As Int32, ByVal idListaPrecio As Int32, ByVal modeloSay As String, ByVal modeloSicy As String, ByVal idCliente As Int32, ByVal idAgente As Int32) As DataTable
        Dim objDa As New Datos.ProductosDA
        Dim dtmodelos As New DataTable
        dtmodelos = objDa.recuperarConsultaProductosModeloSustituto(tipoConsulta, idListaPrecio, modeloSay, modeloSicy, idCliente, idAgente)
        Return dtmodelos
    End Function

    ''funcion que recupera la consulta de los productos por marca o coleccion
    Public Function recuperarConsultaProductosMarcaColeccion(ByVal idLista As Int32, ByVal idMarcas As String, ByVal idColeccion As String, ByVal coleccion As String, ByVal idAgente As Int32) As DataTable
        Dim objDa As New Datos.ProductosDA
        Dim dtmodelos As New DataTable
        dtmodelos = objDa.recuperarConsultaProductosMarcaColeccion(idLista, idMarcas, idColeccion, coleccion, idAgente)
        Return dtmodelos
    End Function

    ''funcion para recuperar tecs del rfc seleccionado en el pedido 
    Public Function recuperarTECRfcPedido(ByVal idClienteRfc As Int32) As DataTable
        Dim objDa As New Datos.ProductosDA
        Dim dtTiendas As New DataTable
        dtTiendas = objDa.recuperarTECRfcPedido(idClienteRfc)
        Return dtTiendas
    End Function

    'funcion para recuperar tallas de EU, USA de una talla Mx
    Public Function recuperarTallasRelacionadasMx(ByVal idTalla As Int32) As DataTable
        Dim objDa As New Datos.ProductosDA
        Dim dtTallas As New DataTable
        dtTallas = objDa.recuperarTallasRelacionadasMx(idTalla)
        Return dtTallas
    End Function

    'funcion para calcular la cantidad de docenas normales
    Public Function calcularDocenasNormalesTalla(ByVal cantidad As Int32, ByVal idTalla As Int32, ByVal pedidoDetalleId As Int32,
                                                 ByVal usuarioCreo As Int32, ByVal ClienteId As Int32, ByVal ProductoEstiloId As Int32) As DataTable
        Dim objDa As New Datos.ProductosDA
        Dim dtTDocenas As New DataTable
        dtTDocenas = objDa.calcularDocenasNormalesTalla(cantidad, idTalla, pedidoDetalleId, usuarioCreo, ClienteId, ProductoEstiloId)
        Return dtTDocenas
    End Function

    'funcion para recuperar la ruta del pdf de etiquetas especiales del cliente
    Public Function recuperarRutaPdfEtiquetaEspecial(ByVal idCliente As Int32) As DataTable
        Dim objDa As New Datos.ProductosDA
        Dim dtRuta As New DataTable
        dtRuta = objDa.recuperarRutaPdfEtiquetaEspecial(idCliente)
        Return dtRuta
    End Function

    'funcion para validar nuemero de tiendas de un rfc
    Public Function validarNumeroTiendasRfc(ByVal idClienteRfc As Int32) As DataTable
        Dim objDa As New Datos.ProductosDA
        Dim dtNumeroTiendas As New DataTable
        dtNumeroTiendas = objDa.validarNumeroTiendasRfc(idClienteRfc)
        Return dtNumeroTiendas
    End Function

    ''funcion para recuperar tecs del rfc seleccionado nombre simple
    Public Function recuperarTECRfcPedidoTecs(ByVal idClienteRfc As Int32) As DataTable
        Dim objDa As New Datos.ProductosDA
        Dim dtRfc As New DataTable

        dtRfc = objDa.recuperarTECRfcPedidoTecs(idClienteRfc)
        Return dtRfc
    End Function
End Class
