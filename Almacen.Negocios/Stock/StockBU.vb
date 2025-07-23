Public Class StockBU

    Public Function Stock_DocenaNormal(ByVal productoID As String) As System.Data.DataTable
        Dim ObjDa As New Almacen.Datos.StockDA
        Return ObjDa.Stock_DocenaNormal(productoID)
    End Function

    Public Function ConsulaStock(ByVal productosID As String, ByVal varlidarStock As Boolean) As System.Data.DataTable
        Dim ObjDa As New Almacen.Datos.StockDA
        Return ObjDa.ConsultaStock(productosID, varlidarStock)
    End Function

    Public Function ConsultaModelosStock(ByVal marcas As String, ByVal colecciones As String, ByVal modelos As String, ByVal modeloFiltro As String, ByVal aplicaciones As String, ByVal colores As String, ByVal pieles As String, ByVal corridas As String, ByVal familias As String, ByVal categorias As String, ByVal lineas As String, ByVal horma As String) As System.Data.DataTable
        Dim ObjDa As New Almacen.Datos.StockDA
        Dim Tabla As New DataTable
        Tabla = ObjDa.ConsultaModelosStock(marcas, colecciones, modelos, modeloFiltro, aplicaciones, colores, pieles, corridas, familias, categorias, lineas, horma)
        Return Tabla
    End Function

    Public Sub InsertarPedidoAbierto(ByVal ListaPedidoAbierto As Entidades.Stock)
        Dim ObjDa As New Datos.StockDA
        ObjDa.InsertarPedidoAbierto(ListaPedidoAbierto)
    End Sub

    Public Function Stock_VerificarPedidoAbierto(ByVal AgenteID As Integer, ByVal Estatus As String) As DataTable
        Dim ObjDa As New Datos.StockDA
        Return ObjDa.Stock_VerificarPedidoAbierto(AgenteID, Estatus)
    End Function

    Public Function Stock_ResumenPedido(ByVal AgenteId As Integer, ByVal Estatus As String) As DataTable
        Dim ObjDA As New Datos.StockDA
        Return ObjDA.Stock_ResumenPedido(AgenteId, Estatus)
    End Function

    Public Function EliminarCorrida(ByVal codigoSICY As String, ByVal TallaID As String, ByVal agenteID As String, ByVal pedidoID As String) As Boolean
        Dim ObjDA As New Datos.StockDA
        Return ObjDA.EliminarCorrida(codigoSICY, TallaID, agenteID, pedidoID)
    End Function

    Public Function ListaClientes_SegunAgente(ByVal AgenteID As Integer) As DataTable
        Dim ObjDa As New Datos.StockDA
        Return ObjDa.ListaClientes_SegunAgente(AgenteID)
    End Function

    Public Sub CerrarPedido(ByVal AgenteID As Integer, ByVal ClienteID As Integer, ByVal pedidoID As Integer, ByVal tienda As Integer, ByVal corridaid As String, ByVal codigo As String, ByVal rfcCliente As String)
        Dim ObjDA As New Datos.StockDA
        ObjDA.CerrarPedido(AgenteID, ClienteID, pedidoID, tienda, corridaid, codigo, rfcCliente)
    End Sub

    Public Function TiendasSegunCliente(ByVal clienteID As Integer) As DataTable
        Dim objDA As New Datos.StockDA
        Return objDA.TiendasSegunCliente(clienteID)
    End Function

    Public Function marcasSegunAgente(ByVal agenteID As String) As DataTable
        Dim objDA As New Datos.StockDA
        Return objDA.marcasSegunAgente(agenteID)
    End Function

    Public Function agentesSegunCliente(ByVal clienteID As Integer) As DataTable
        Dim objDA As New Datos.StockDA
        Return objDA.agentesSegunCliente(clienteID)
    End Function


    Public Function descripcionAgente(ByVal agenteID As String) As String
        Dim objDA As New Almacen.Datos.StockDA
        Dim tabla As DataTable
        Dim nombre As String = ""
        tabla = objDA.descripcionAgente(agenteID)
        If tabla.Rows.Count > 0 Then
            nombre = tabla.Rows(0).Item(0)
        End If
        Return nombre

    End Function

    Public Function descripcionCliente(ByVal clienteID As String) As String
        Dim objDA As New Almacen.Datos.StockDA
        Dim tabla As DataTable
        Dim nombre As String = ""     
        tabla = objDA.descripcionCliente(clienteID)
        If tabla.Rows.Count > 0 Then
            nombre = tabla.Rows(0).Item(0)
        End If
        Return nombre
    End Function

    Public Function RFCClientes(ByVal clienteID As String) As DataTable
        Dim objDA As New Almacen.Datos.StockDA
        Return objDA.RFCClientes(clienteID)
    End Function

End Class
