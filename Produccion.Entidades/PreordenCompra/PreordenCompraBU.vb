Imports Produccion.Datos

Public Class PreordenCompraBU

    Public Function MaterialesPorProveedor(ByVal nave As Integer, ByVal proveedor As Integer, ByVal idmoneda As Integer) As DataTable
        Dim obj As New PreordenCompraDA
        Return obj.MaterialesPorProveedor(nave, proveedor, idmoneda)
    End Function

    Public Function ObtenerNombreClasificacion(ByVal id As Integer) As DataTable
        Dim obj As New PreordenCompraDA
        Return obj.ObtenerNombreClasificacion(id)
    End Function

    Public Function ConsultaPreOrdenesDeCompra(ByVal nave As Integer, ByVal fechaInicio As String, fechafin As String, porSemana As Integer, AñoInicio As Integer, SemanaInicio As Integer, ByVal estatus As Integer, ByVal CheckFecha As Integer) As DataTable
        Dim obj As New PreordenCompraDA
        Return obj.ConsultaPreOrdenesDeCompra(nave, fechaInicio, fechafin, porSemana, AñoInicio, SemanaInicio, estatus, CheckFecha)
    End Function

    Public Function ConsultaProveedoresMaterial(ByVal materialid As Integer) As DataTable
        Dim obj As New PreordenCompraDA
        Return obj.ConsultaProveedoresMaterial(materialid)
    End Function


    Public Function ActualizaReimprimio(ByVal preordenid As Integer, ByVal usuario As Integer) As DataTable
        Dim obj As New PreordenCompraDA
        Return obj.ActualizaReimprimio(preordenid, usuario)
    End Function

    Public Function ActualizaImprimio(ByVal preordenid As Integer, ByVal usuario As Integer) As DataTable
        Dim obj As New PreordenCompraDA
        Return obj.ActualizaImprimio(preordenid, usuario)
    End Function

    Public Function ConsultaImprimio(ByVal preordenid As Integer) As DataTable
        Dim obj As New PreordenCompraDA
        Return obj.ConsultaImprimio(preordenid)
    End Function

    Public Function ConsultaProveedores(ByVal nave As Integer) As DataTable
        Dim obj As New PreordenCompraDA
        Return obj.ConsultaProveedores(nave)
    End Function

    Public Function ConsultaPrecio(ByVal materialNaveid As Integer, ByVal proveedorid As Integer) As DataTable
        Dim obj As New PreordenCompraDA
        Return obj.ConsultaPrecio(materialNaveid, proveedorid)
    End Function

    Public Function ConsultarOrdenCompletaDetalle(ByVal ordenid As Integer) As DataTable
        Dim obj As New PreordenCompraDA
        Return obj.ConsultarOrdenCompletaDetalle(ordenid)
    End Function

    Public Function ConsultarDatosNave(ByVal naveid As Integer) As DataTable
        Dim obj As New PreordenCompraDA
        Return obj.ConsultarDatosNave(naveid)
    End Function

    Public Function ConsultarOrdenCompleta(ByVal ordenid As Integer) As DataTable
        Dim obj As New PreordenCompraDA
        Return obj.ConsultarOrdenCompleta(ordenid)
    End Function

    Public Function NombreDeUsuario(ByVal usuario As Integer) As DataTable
        Dim obj As New PreordenCompraDA
        Return obj.NombreDeUsuario(usuario)
    End Function

    Public Function ConsultaIdOrdenCompra(ByVal idpo As Integer) As DataTable
        Dim obj As New PreordenCompraDA
        Return obj.ConsultaIdOrdenCompra(idpo)
    End Function

    Public Function CantidadPorRecibir(ByVal Materialnaveid As Integer, ByVal ProveedorId As Integer, ByVal NaveId As Integer) As DataTable
        Dim obj As New PreordenCompraDA
        Return obj.CantidadPorRecibir(Materialnaveid, ProveedorId, NaveId)
    End Function


    Public Function ObtieneColumnasParaGrid(ByVal fechaProgramas As String, ByVal nave As Integer,
                                                    ByVal proveedor As Integer, ByVal Preordenid As Integer) As DataTable
        Dim objDA As New PreordenCompraDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtieneColumnasParaGrid(fechaProgramas, nave, proveedor, Preordenid)
        Return Tabla
    End Function

    Public Function AutorizarOrdenCompra(ByVal PreOrdenesCompra As String) As DataTable
        Dim objDA As New PreordenCompraDA
        Dim Tabla As New DataTable
        Tabla = objDA.AutorizarOrdenCompra(PreOrdenesCompra)
        Return Tabla
    End Function

    Public Function CancelarOrdenCompra(ByVal PreOrdenesCompra As String) As DataTable
        Dim objDA As New PreordenCompraDA
        Dim Tabla As New DataTable
        Tabla = objDA.CancelarOrdenCompra(PreOrdenesCompra)
        Return Tabla
    End Function

    Public Function GuardarPreOrdenCompra(ByVal Accion As Integer, Celdas As String) As DataTable
        Dim objDA As New PreordenCompraDA
        Dim Tabla As New DataTable
        Tabla = objDA.GuardarPreOrdenCompra(Accion, Celdas)
        Return Tabla
    End Function

    Public Function ActualizarPreOrdenCompra(ByVal Accion As Integer, Celdas As String) As DataTable
        Dim objDA As New PreordenCompraDA
        Dim Tabla As New DataTable
        Tabla = objDA.ActualizarPreOrdenCompra(Accion, Celdas)
        Return Tabla
    End Function

    Public Function ObtenerDatosProveedor(ByVal Accion As Integer, ByVal ProveedorID As Integer) As DataTable
        Dim objDA As New PreordenCompraDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtenerDatosProveedor(Accion, ProveedorID)
        Return Tabla
    End Function

    Public Function ObtieneEstatusOrdenCompra() As DataTable
        Dim objDA As New PreordenCompraDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtieneEstatusOrdenCompra()
        Return Tabla
    End Function

End Class
