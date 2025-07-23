Public Class AgregarInventarioCiclicoBU

    Public Function RecuperarNombreCliente(ByVal IdCliente As String) As List(Of Entidades.Cliente)
        Dim objClienteDA As New Datos.AgregarInventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objClienteDA.RecuperarNombreCliente(IdCliente)
        RecuperarNombreCliente = New List(Of Entidades.Cliente)
        For Each fila As DataRow In tabla.Rows
            Dim RecuperarNombre As New Entidades.Cliente
            RecuperarNombre.nombregenerico = CStr(fila("Nombre"))
            RecuperarNombreCliente.Add(RecuperarNombre)
        Next
    End Function

    Public Function RecuperaNombreAgente(ByVal IdNombreAgente As String) As List(Of Entidades.Colaborador)
        Dim objDA As New Datos.AgregarInventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objDA.RecuperarNombreAgente(IdNombreAgente)
        RecuperaNombreAgente = New List(Of Entidades.Colaborador)
        For Each fila As DataRow In tabla.Rows
            Dim NombreAgente As New Entidades.Colaborador
            NombreAgente.PNombre = CStr(fila("Nombre"))
            RecuperaNombreAgente.Add(NombreAgente)
        Next
    End Function

    Public Function RecuperarNombreTienda(ByVal IdTienda As String) As List(Of Entidades.TipoTienda)
        Dim objTiendaDA As New Datos.AgregarInventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objTiendaDA.RecuperarNombreTienda(IdTienda)
        RecuperarNombreTienda = New List(Of Entidades.TipoTienda)
        For Each fila As DataRow In tabla.Rows
            Dim NombreTienda As New Entidades.TipoTienda
            NombreTienda.nombre = CStr(fila("Tienda"))
            RecuperarNombreTienda.Add(NombreTienda)
        Next
    End Function


    Public Function RecuperarNombreProducto(ByVal IdProducto As String) As List(Of Entidades.Productos)
        Dim objProductoDA As New Datos.AgregarInventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objProductoDA.RecuperarNombreProducto(IdProducto)
        RecuperarNombreProducto = New List(Of Entidades.Productos)
        For Each row As DataRow In tabla.Rows
            Dim NombreProducto As New Entidades.Productos
            NombreProducto.PDescripcionProd = CStr(row("Descripcion"))
            RecuperarNombreProducto.Add(NombreProducto)
        Next
    End Function

    Public Function RecuperarNombreBahia(ByVal IdBahia As String) As List(Of Entidades.Bahia)
        Dim objBahiaDA As New Datos.AgregarInventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objBahiaDA.RecuperarNombreBahia(IdBahia)
        RecuperarNombreBahia = New List(Of Entidades.Bahia)
        For Each row As DataRow In tabla.Rows
            Dim NombreBahia As New Entidades.Bahia
            NombreBahia.bahi_descripcion = CStr(row("Bahía"))
            RecuperarNombreBahia.Add(NombreBahia)
        Next
    End Function

    Public Function RecuperarDescripcionCorrida(ByVal IdCorrida As String) As List(Of Entidades.Corridas)
        Dim objCorridaBU As New Datos.AgregarInventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objCorridaBU.RecuperarDescripcionCorrida(IdCorrida)
        RecuperarDescripcionCorrida = New List(Of Entidades.Corridas)
        For Each row As DataRow In tabla.Rows
            Dim DescripcionCorrida As New Entidades.Corridas
            DescripcionCorrida.PCorrida = CStr(row("Talla"))
            RecuperarDescripcionCorrida.Add(DescripcionCorrida)
        Next
    End Function

    Public Function RecuperarMarca(ByVal IdMarca As String) As List(Of Entidades.Marcas)
        Dim objMarcaDA As New Datos.AgregarInventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objMarcaDA.RecuperarMarca(IdMarca)
        RecuperarMarca = New List(Of Entidades.Marcas)
        For Each row As DataRow In tabla.Rows
            Dim Marca As New Entidades.Marcas
            Marca.PDescripcion = CStr(row("Marca"))
            RecuperarMarca.Add(Marca)
        Next
    End Function

    Public Function RecuperarColeccion(ByVal IdColeccion As String) As List(Of Entidades.Coleccion)
        Dim objColeccionDa As New Datos.AgregarInventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objColeccionDa.RecuperarColeccion(IdColeccion)
        RecuperarColeccion = New List(Of Entidades.Coleccion)
        For Each row As DataRow In tabla.Rows
            Dim Coleccion As New Entidades.Coleccion
            Coleccion.PColeccionDescripcion = CStr(row("coleccion"))
            RecuperarColeccion.Add(Coleccion)
        Next
    End Function

    Public Function ListaOperadoresAlmacenSicy() As DataTable
        ListaOperadoresAlmacenSicy = New DataTable
        Dim objListaOperadoresAlmacenSicyDA = New Datos.AgregarInventarioCiclicoDA
        ListaOperadoresAlmacenSicy = objListaOperadoresAlmacenSicyDA.ListaOperadores
    End Function


    Public Sub AgregarInventarioCiclico(ByVal Inventario As Entidades.InventariosCiclicos)
        Dim objAltaInventarioCiclicoDA As New Datos.AgregarInventarioCiclicoDA
        objAltaInventarioCiclicoDA.AgregarInventarioCiclico(Inventario)


    End Sub


End Class
