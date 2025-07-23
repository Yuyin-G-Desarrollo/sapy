Imports Produccion.Datos
Imports Entidades

Public Class RecepcionBU
    Public Function getConfiguracionNave(ByVal idNaveSay As Integer) As DataTable
        Dim obj As New RecepcionDA
        Return obj.getConfiguracionNave(idNaveSay)
    End Function
    Public Function getNextFolioRemision(ByVal idNavesay As Integer, ByVal idProveedorsay As Integer) As String
        Dim obj As New RecepcionDA
        Return obj.getNextFolioRemision(idNavesay, idProveedorsay)
    End Function
    Public Function insertarComprobante(ByVal idordencompra As Integer, ByVal ruta As String) As DataTable
        Dim obj As New RecepcionDA
        Return obj.insertarComprobante(idordencompra, ruta)
    End Function
    Public Function getRFCProveedor(ByVal idproveedor As Integer) As String
        Dim obj As New RecepcionDA
        Return obj.getRFCProveedor(idproveedor)
    End Function
    Public Function validarFolio(ByVal folio As String, ByVal idProveedor As Integer) As DataTable
        Dim obj As New RecepcionDA
        Return obj.validarFolio(folio, idProveedor)
    End Function
    Public Function getDatosOrdendeCompra(ByVal idOrdenCompra As Integer) As DataTable
        Dim obj As New RecepcionDA
        Return obj.getDatosOrdendeCompra(idOrdenCompra)
    End Function
    Public Function getEmpresasXNave(ByVal idNave As Integer) As DataTable
        Dim obj As New RecepcionDA
        Return obj.getEmpresasXNave(idNave)
    End Function
    Public Function getFacturas(ByVal idNave As Integer, ByVal idProveedor As Integer, ByVal total As Double, ByVal idEmpresa As Integer, ByVal idMoneda As Integer) As DataTable
        Dim obj As New RecepcionDA
        Return obj.getFacturas(idNave, idProveedor, total, idEmpresa, idMoneda)
    End Function
    Public Function getPlazoProveedor(ByVal idProveedor As Integer) As DataTable
        Dim obj As New RecepcionDA
        Return obj.getPlazoProveedor(idProveedor)
    End Function
    Public Function getDatosProveedor(ByVal idProveedor As Integer) As DataTable
        Dim obj As New RecepcionDA
        Return obj.getDatosProveedor(idProveedor)
    End Function
    Public Function getSemana(ByVal idsemana As Integer, ByVal fecha As Date) As DataTable
        Dim obj As New RecepcionDA
        Return obj.getSemana(idsemana, fecha)
    End Function
    Public Function getSemanaPago(ByVal idsemanaRecibido As Integer, ByVal idplazo As Integer) As DataTable
        Dim obj As New RecepcionDA
        Return obj.getSemanaPago(idsemanaRecibido, idplazo)
    End Function
    Public Function cerrarDatosOrdenCompraFacturaRecibida(ByVal idordencompra As Integer, ByVal idcfdsOrdenCompra As Integer) As DataTable
        Dim obj As New RecepcionDA
        Return obj.cerrarDatosOrdenCompraFacturaRecibida(idordencompra, idcfdsOrdenCompra)
    End Function
    Public Function InsertcxpSaldoscxpMovimientos(ByVal c As CxPSaldos) As DataTable
        Dim obj As New RecepcionDA
        Return obj.InsertcxpSaldoscxpMovimientos(c)
    End Function
    Public Function getPaisProveedor(ByVal idproveedor As Integer) As String
        Dim obj As New RecepcionDA
        Return obj.getPaisProveedor(idproveedor)
    End Function
    Public Function getNombreNave(ByVal idNave As Integer) As String
        Dim obj As New RecepcionDA
        Return obj.getNombreNave(idNave)
    End Function
    Public Function getDocumentosOrden(ByVal idordencompra As Integer) As DataTable
        Dim obj As New RecepcionDA
        Return obj.getDocumentosOrden(idordencompra)
    End Function
    Public Function getPDFProveedorExtranjero(ByVal idordencompra As Integer) As DataTable
        Dim obj As New RecepcionDA
        Return obj.getPDFProveedorExtranjero(idordencompra)
    End Function
    Public Function getProveedorOrdenCompra(ByVal idordencompra As Integer) As Integer
        Dim obj As New RecepcionDA
        Return obj.getProveedorOrdenCompra(idordencompra)
    End Function
End Class
