Public Class ProductosFactBU
    Public Function obtenerListadoProductos(ByVal idUsuario As Integer, ByVal idSucursal As Integer, ByVal activo As Boolean, ByVal filtro As String, ByVal ids As String, ByVal pesos As Boolean) As DataTable
        Dim datos As New Datos.ProductosFactDA
        Return datos.obtenerListadoProductos(idUsuario, idSucursal, activo, filtro, ids, pesos)
    End Function

    Public Function obtenerUnidadMedida() As DataTable
        Dim datos As New Datos.ProductosFactDA
        Return datos.obtenerUnidadMedida()
    End Function

    Public Function obtenerProducto(ByVal idProducto As Integer) As Entidades.ProductosFacturacion
        Dim datos As New Datos.ProductosFactDA
        Dim tabla As New DataTable
        Dim producto As New Entidades.ProductosFacturacion

        tabla = datos.obtenerProducto(idProducto)
        For Each row As DataRow In tabla.Rows
            producto.PProdId = CInt(row("fapr_productoid"))
            producto.PSucursalId = CInt(row("fapr_sucursalid"))
            producto.PDescripcion = CStr(row("fapr_descripción"))
            producto.PPrecioPesos = CDbl(row("fapr_preciopesos"))
            producto.PPrecioDolares = CDbl(row("fapr_preciodolares"))
            producto.PUnidadMedidaId = CInt(row("fapr_unidadmedidaid"))
            producto.PActivo = CBool(row("fapr_activo"))
        Next

        Return producto
    End Function

    Public Function existeRegistro(ByVal descripcion As String, ByVal idSucursal As Integer, ByVal idProducto As Integer) As Boolean
        Dim datos As New Datos.ProductosFactDA
        Dim tabla As New DataTable

        tabla = datos.existeRegistro(descripcion, idSucursal, idProducto)
        If tabla.Rows.Count = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub guardarProducto(ByVal producto As Entidades.ProductosFacturacion)
        Dim datos As New Datos.ProductosFactDA
        datos.guardarProducto(producto)
    End Sub
End Class
