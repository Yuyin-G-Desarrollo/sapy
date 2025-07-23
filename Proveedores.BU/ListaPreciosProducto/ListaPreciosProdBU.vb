Imports Proveedores.DA
Imports Entidades

Public Class ListaPreciosProdBU
    Public Function getPreciosLista(ByVal idLista As String, ByVal idMarca As String, ByVal idColeccion As String, ByVal idNave As Integer) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.getPreciosLista(idLista, idMarca, idColeccion, idNave)
    End Function
    Public Function getDestinatarios(ByVal clave As String) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.getDestinatarios(clave)
    End Function
    Public Function getListasReporte(ByVal lista As List(Of Integer)) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.getListasReporte(lista)
    End Function
    Public Function getListasDetallesReporte(ByVal lista As List(Of Integer)) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.getListasDetallesReporte(lista)
    End Function
    Public Function getMarcas(ByVal idNave As Integer, ByVal idEmpresa As Integer) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.getMarcas(idNave, idEmpresa)
    End Function
    Public Function getMarcasAltas(ByVal idNave As Integer) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.getMarcasAltas(idNave)
    End Function
    Public Function getColecciones(ByVal idNave As Integer, ByVal idMarca As String) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.getColecciones(idNave, idMarca)
    End Function
    Public Function getPreciosModelos(ByVal idList As Integer, ByVal idNave As Integer, ByVal idMarca As String, ByVal idCol As String, ByVal tipoprecio As String) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.getPreciosModelos(idList, idNave, idMarca, idCol, tipoprecio)
    End Function
    Public Function InsertListaPrecioProducto(ByVal lista As ListaPrecioProd) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.InsertListaPrecioProducto(lista)
    End Function
    Public Function InsertListaPrecioProductoDetalles(ByVal lista As ListaPrecioProdDetalles) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.InsertListaPrecioProductoDetalles(lista)
    End Function
    Public Function copiarListaPrecioProducto(ByVal lista As ListaPrecioProd) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.copiarListaPrecioProducto(lista)
    End Function
    Public Function getValidarLista(ByVal lista As ListaPrecioProd) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.getValidarLista(lista)
    End Function
    Public Function getModelos(ByVal idNave As Integer, ByVal idMarca As String, ByVal idCol As String) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.getModelos(idNave, idMarca, idCol)
    End Function
    Public Function UpdateListaPrecioProducto(ByVal lista As ListaPrecioProd) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.UpdateListaPrecioProducto(lista)
    End Function
    Public Function UpdateListaPrecioProductoDetalles(ByVal lista As ListaPrecioProdDetalles) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.UpdateListaPrecioProductoDetalles(lista)
    End Function
    Public Function getDatosListas(ByVal Estatus As String, ByVal idNaveSicy As Integer, ByVal vigente As Boolean, ByVal IdEmpresa As Integer) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.getDatosListas(Estatus, idNaveSicy, vigente, IdEmpresa)
    End Function
    '    Public Function getDatosListasPrecios(ByVal capturada As String, ByVal autorizada As String, ByVal rechazada As String, ByVal vigente As Boolean, ByVal marca As String, ByVal coleccion As String, ByVal idNaveSicy As Integer) As DataTable
    Public Function getDatosListasPrecios(ByVal Estatus As String, ByVal Vigente As Boolean, ByVal IdMarca As String, ByVal Coleccion As String, ByVal idNaveSicy As Integer, ByVal preciocompra_venta As Integer, ByVal idEmpresa As Integer) As DataTable
        Dim obj As New ListaPreciosProdDA
        'Return obj.getDatosListasPrecios(capturada, autorizada, rechazada, vigente, marca, coleccion, idNaveSicy)
        Return obj.getDatosListasPrecios(Estatus, Vigente, IdMarca, Coleccion, idNaveSicy, preciocompra_venta, idEmpresa)
    End Function

    Public Function getDatosPreciosVentas(Naves As String, idEmpresa As Integer) As DataTable
        Dim obj As New ListaPreciosProdDA
        'Return obj.getDatosListasPrecios(capturada, autorizada, rechazada, vigente, marca, coleccion, idNaveSicy)
        Return obj.getDatosPreciosVentas(Naves, idEmpresa)
    End Function

    Public Function getDatosListasPreciosVenta(ByVal Estatus As String, ByVal Vigente As Boolean, ByVal IdMarca As String, ByVal Coleccion As String, ByVal idNaveSicy As Integer) As DataTable
        Dim obj As New ListaPreciosProdDA

        Return obj.getDatosListasPreciosVenta(Estatus, Vigente, IdMarca, Coleccion, idNaveSicy)
    End Function
    Public Function autorizarListas(ByVal lista As List(Of Integer)) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.autorizarListas(lista)
    End Function
    Public Function revertirListas(ByVal lista As List(Of Integer)) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.revertirListas(lista)
    End Function
    Public Function rechazarListas(ByVal lista As List(Of Integer)) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.rechazarListas(lista)
    End Function
    Public Function getNaveSIcy(ByVal idNave As Integer) As Integer
        Dim obj As New ListaPreciosProdDA
        Return obj.getNaveSIcy(idNave)
    End Function
    Public Function getNaveSAY(ByVal idNave As Integer) As Integer
        Dim obj As New ListaPreciosProdDA
        Return obj.getNaveSAY(idNave)
    End Function
    Public Function getProductoTerminadoMaquila(ByVal idNave As Integer, ByVal inicio As Date, ByVal fin As Date) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.getProductoTerminadoMaquila(idNave, inicio, fin)
    End Function
    Public Function getURLNave(ByVal idNave As Integer) As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.getURLNave(idNave)
    End Function

    Public Function getcomercializadoras() As DataTable
        Dim obj As New ListaPreciosProdDA
        Return obj.getComercializadora()
    End Function

    Public Function getNombreNave(ByVal idNave As Integer) As String
        Dim obj As New ListaPreciosProdDA
        Return obj.getNombreNave(idNave)
    End Function
    Public Function getRazSocReceptor(ByVal idNave As Integer) As String
        Dim obj As New ListaPreciosProdDA
        Return obj.getRazSocReceptor(idNave)
    End Function

    Public Function ObtenerNumeroSemanas(ByVal FechaDel As Date, ByVal FechaAl As Date) As String
        Dim obj As New ListaPreciosProdDA
        Dim dt As New DataTable
        Dim semanas As String = String.Empty
        dt = obj.ObtenerNumeroSemanas(FechaDel, FechaAl)
        If dt.Rows.Count > 0 Then
            semanas = dt.Rows(0).Item("Semanas")
        End If
        Return semanas
    End Function
End Class

