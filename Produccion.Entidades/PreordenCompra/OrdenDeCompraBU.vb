Imports Produccion.Datos
Imports Entidades

Public Class OrdenDeCompraBU
    Public Function consultarOrdenesDeCompra(ByVal fechaPrograma As Date, ByVal idnave As Integer, ByVal estatusC As String, ByVal ban As Boolean) As DataTable
        Dim obj As New OrdenDeCompraDA
        Return obj.consultarOrdenesDeCompra(fechaPrograma, idnave, estatusC, ban)
    End Function
    Public Function getEncabezadoDatosOrdenCompra(ByVal idOrden As Integer) As DataTable
        Dim obj As New OrdenDeCompraDA
        Return obj.getEncabezadoDatosOrdenCompra(idOrden)
    End Function
    Public Function getMaterialesOrdenCompra(ByVal idOrden As Integer) As DataTable
        Dim obj As New OrdenDeCompraDA
        Return obj.getMaterialesOrdenCompra(idOrden)
    End Function
    Public Function getEstatusMaterialesOC() As DataTable
        Dim obj As New OrdenDeCompraDA
        Return obj.getEstatusMaterialesOC()
    End Function
    Public Function actualizarMaterialOrdenCompra(ByVal estatus As String, ByVal idocd As Integer, ByVal cantidadRecibida As Double) As DataTable
        Dim obj As New OrdenDeCompraDA
        Return obj.ActualizarMaterialOrdenCompra(estatus, idocd, cantidadRecibida)
    End Function
    Public Function actualizarOrdenCompraEstatus(ByVal idOrdenCompra As Integer, ByVal estatus As String) As DataTable
        Dim obj As New OrdenDeCompraDA
        Return obj.actualizarOrdenCompraEstatus(idOrdenCompra, estatus)
    End Function
    Public Function cancelarOrdenDeCompra(ByVal idOrdenCompra As Integer) As DataTable
        Dim obj As New OrdenDeCompraDA
        Return obj.cancelarOrdenDeCompra(idOrdenCompra)
    End Function
    Public Function insertarMovimientoInventario(ByVal p As InventarioNave) As DataTable
        Dim obj As New OrdenDeCompraDA
        Return obj.insertarMovimientoInventario(p)
    End Function
    Public Function getMovimientoXTipoCapturaOrden(ByVal tipo As String) As Integer
        Dim obj As New OrdenDeCompraDA
        Return obj.getMovimientoXTipoCapturaOrden(tipo)
    End Function
    Public Function getUnidadMedida(ByVal nombre As String) As Integer
        Dim obj As New OrdenDeCompraDA
        Return obj.getUnidadMedida(nombre)
    End Function
    Public Function getCantidadInicial(ByVal i As InventarioNave) As Double
        Dim obj As New OrdenDeCompraDA
        Return obj.getCantidadInicial(i)
    End Function
    Public Function entraEnInventario(ByVal i As InventarioNave) As Boolean
        Dim obj As New OrdenDeCompraDA
        Return obj.entraEnInventario(i)
    End Function
    Public Function getDatosMoneda(ByVal idModena As Integer) As DataTable
        Dim obj As New OrdenDeCompraDA
        Return obj.getDatosMoneda(idModena)
    End Function
End Class
