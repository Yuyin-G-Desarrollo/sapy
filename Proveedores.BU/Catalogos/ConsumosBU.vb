Imports Proveedores.DA
Imports Entidades

Public Class ConsumosBU

    Public Function VerListaProductos()
        Dim obj As New DA.ConsumosDA
        Return obj.VerListaProductos()
    End Function

    Public Function tablaConsumos()
        Dim obj As New DA.ConsumosDA
        Return obj.tablaConsumos()
    End Function
    Public Function tablaConsumosss()
        Dim obj As New DA.ConsumosDA
        Return obj.tablaConsumosss()
    End Function

    Public Function tablaFracciones()
        Dim obj As New DA.ConsumosDA
        Return obj.tablaFracciones()
    End Function

    Public Function listaMaterialesConConsumos()
        Dim obj As New DA.ConsumosDA
        Return obj.listaMaterialesConConsumos()
    End Function

    Public Function listaMateriales()
        Dim obj As New DA.ConsumosDA
        Return obj.listaMateriales()
    End Function

    Public Function listaProveedoress()
        Dim obj As New DA.ConsumosDA
        Return obj.listaProveedoress()
    End Function

    Public Function ConsultaProductosEspecifico(ByVal productoid As Integer)
        Dim obj As New DA.ConsumosDA
        Return obj.ConsultaProductosEspecifico(productoid)
    End Function
    Public Function insertConsumo(ByVal c As Consumo) As DataTable
        Dim obj As New ConsumosDA
        Return obj.insertConsumo(c)
    End Function
    Public Function eliminarConsumos(ByVal productoEstiloId) As DataTable
        Dim obj As New ConsumosDA
        Return obj.eliminarConsumos(productoEstiloId)
    End Function
    Public Function getconsumos(ByVal productoEstiloId As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getconsumos(productoEstiloId)
    End Function
    Public Function getDatosProducto(ByVal productoEstiloId As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getDatosProducto(productoEstiloId)
    End Function
    Public Function getMarcas() As DataTable
        Dim obj As New ConsumosDA
        Return obj.getMarcas()
    End Function
    Public Function getColecciones(ByVal idMarca As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.getColecciones(idMarca)
    End Function
    Public Function listadoProductosSinNave(ByVal idMarca As Integer, ByVal idColecc As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.listadoProductosSinNave(idMarca, idColecc)
    End Function
    Public Function VerListaProductos(ByVal naveid As Integer)
        Dim obj As New ConsumosDA
        Return obj.VerListaProductos(naveid)
    End Function
    Public Function listaComponente() As DataTable
        Dim obj As New ConsumosDA
        Return obj.listaComponente()
    End Function
    Public Function VerListaProductosPorNaveyEstatus(ByVal naveid As Integer, ByVal estatus As String)
        Dim obj As New ConsumosDA
        Return obj.VerListaProductosPorNaveyEstatus(naveid, estatus)
    End Function
    Public Function actualizarProductos(ByVal idNave As Integer, ByVal idProducto As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.actualizarProductos(idNave, idProducto)
    End Function
    Public Function listaDepartamentos() As DataTable
        Dim obj As New ConsumosDA
        Return obj.listaDepartamentos()
    End Function
    Public Function listaComponentes() As DataTable
        Dim obj As New ConsumosDA
        Return obj.listaComponente()
    End Function
    Public Function GuardarComponente(ByVal componente As Consumos) As DataTable
        Dim obj As New ConsumosDA
        Return obj.GuardarComponente(componente)
    End Function
    Public Function ModificarComponente(ByVal componente As Consumos) As DataTable
        Dim obj As New ConsumosDA
        Return obj.ModificarComponente(componente)
    End Function
    Public Function ComponenteRepetido(ByVal componente As String) As DataTable
        Dim obj As New ConsumosDA
        Return obj.ComponenteRepetido(componente)
    End Function
    Public Function listaClasificaciones() As DataTable
        Dim obj As New ConsumosDA
        Return obj.listaClasificaciones()
    End Function
    Public Function listaProveedores() As DataTable
        Dim obj As New ConsumosDA
        Return obj.listaClasificaciones()
    End Function

    Public Function listaMarcas() As DataTable
        Dim obj As New ConsumosDA
        Return obj.listaMarcas()
    End Function

    Public Function listaColecciones(ByVal idMarca As Integer) As DataTable
        Dim obj As New ConsumosDA
        Return obj.listaColeccion(idMarca)
    End Function

End Class
