Imports Proveedores.DA

Public Class EntregarPagosProveedorBU

    Public Function ListadoParametroProveedor(tipo_busqueda As Integer) As DataTable
        Dim objDa As New EntregaPagosProveedorDA
        Dim tabla As New DataTable
        tabla = objDa.ListadoParametrosProveedor(tipo_busqueda)
        Return tabla
    End Function

    Public Function ObtenerDocumentosaPagar(ByVal ProveedorId As String) As DataTable
        Dim objDa As New EntregaPagosProveedorDA
        Return objDa.ObtenerDocumentosaPagar(ProveedorId)
    End Function

    Public Function ObtieneReciboPagoAnterior(ByVal proveedorid As Integer, ByVal recibo As Integer, ByVal usuario As String) As DataTable
        Dim objDa As New EntregaPagosProveedorDA
        Return objDa.ObtieneReciboPagoAnterior(proveedorid, recibo, usuario)
    End Function

    Public Function ObtieneReciboPagoAnteriorDetalles(ByVal semana As Integer, ByVal proveedorid As Integer, ByVal recibo As Integer, ByVal año As Integer, ByVal usuario As String) As DataTable
        Dim objDa As New EntregaPagosProveedorDA
        Return objDa.ObtieneReciboPagoAnteriorDetalles(semana, proveedorid, recibo, año, usuario)
    End Function

    Public Function ActualizaTablaEntregaPagos(ByVal pXmlCeldas As String) As DataTable
        Dim objDa As New EntregaPagosProveedorDA
        Dim tabla As New DataTable
        tabla = objDa.ActualizaTablaEntregaPagos(pXmlCeldas)
        Return tabla
    End Function

    Public Function SiguienteRecibo() As DataTable
        Dim objDa As New EntregaPagosProveedorDA
        Return objDa.SiguienteRecibo()
    End Function

    Public Function ImprimirReciboPago() As DataTable
        Dim objDa As New EntregaPagosProveedorDA
        Return objDa.ImprimirReciboPago()
    End Function

    Public Function ObtieneReciboPagoEncabezado(ByVal ProveedorId As Integer, ByVal Recibo As Integer, ByVal Usuario As String) As DataTable
        Dim objDa As New EntregaPagosProveedorDA
        Dim tabla As New DataTable
        tabla = objDa.ObtieneReciboPagoEncabezado(ProveedorId, Recibo, Usuario)
        Return tabla
    End Function

    Public Function ObtieneReciboPagoDetalles(ByVal ProveedorId As Integer, ByVal Recibo As Integer) As DataTable
        Dim objDa As New EntregaPagosProveedorDA
        Return objDa.ObtieneReciboPagoDetalles(ProveedorId, Recibo)
    End Function

    Public Function ActualizaPagosProveedor(ByVal pXmlCeldas As String) As DataTable
        Dim objDa As New EntregaPagosProveedorDA
        Dim tabla As New DataTable
        tabla = objDa.ActualizaPagosProveedor(pXmlCeldas)
        Return tabla
    End Function

    Public Function verComboReciboPago(ByVal idProveedor As Integer, ByVal Semana As Integer, ByVal año As Integer) As DataTable
        Dim objDa As New EntregaPagosProveedorDA
        Dim tabla As New DataTable
        tabla = objDa.verComboReciboPago(idProveedor, Semana, año)
        Return tabla
    End Function

    Public Function verComboProveedores() As DataTable
        Dim objDa As New EntregaPagosProveedorDA
        Return objDa.VerComboProveedores()
    End Function

    Public Function verComboSemanaPago(ByVal año As Integer) As DataTable
        Dim objDa As New EntregaPagosProveedorDA
        Return objDa.verComboSemanaPago(año)
    End Function

    Public Function verComboAño() As DataTable
        Dim objDa As New EntregaPagosProveedorDA
        Return objDa.verComboAño()
    End Function

    Public Function InsertaRecibo(ByVal ProveedorId As Integer, ByVal Usuario As String, ByVal Recibo As Integer) As DataTable
        Dim objDa As New EntregaPagosProveedorDA
        Return objDa.insertaRecibo(ProveedorId, Usuario, Recibo)
    End Function


End Class
