Imports Programacion.Datos

Public Class ColeccionNaveBU
    Public Function ConsultarNavesAux() As DataTable
        Dim objDA As New ColeccionNaveDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarNavesAux()
        Return tabla
    End Function


    Public Function ConsultarNavesMarca(ByVal NaveIdSAY As Integer) As DataTable
        Dim objDA As New ColeccionNaveDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarNavesMarca(NaveIdSAY)
        Return tabla
    End Function

    Public Function ConsultarColeccion(ByVal IdNaveSAY As Integer, ByVal marca As String) As DataTable
        Dim objDA As New ColeccionNaveDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarColeccion(IdNaveSAY, marca)
        Return tabla
    End Function
    Public Function ObtieneArticulosNoAsignadosPorNave(ByVal IdNaveSAY As Integer, ByVal Marca As String, ByVal ColeccionSay As String) As DataTable
        Dim objDA As New ColeccionNaveDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.ObtieneArticulosNoAsignadosPorNave(IdNaveSAY, Marca, ColeccionSay)
        Return dtResultado
    End Function

    Public Function CrearReporteActualizarCostos(ByVal NaveIdSAY As Integer, ByVal ProductoEstiloSeleccionados As String) As DataTable
        Dim objDA As New ColeccionNaveDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.CrearReporteActualizarCostos(NaveIdSAY, ProductoEstiloSeleccionados)
        Return dtResultado
    End Function


    Public Function ListadoParametroMovimientoColecciones(ByVal tipo_busqueda As Integer, ByVal NaveSayId As Integer, ByVal Marca As String, ByVal Colecciones As String) As DataTable
        Dim objDA As New ColeccionNaveDA
        Dim tabla As New DataTable
        tabla = objDA.ListadoParametroMovimientoColecciones(tipo_busqueda, NaveSayId, Marca, Colecciones)
        Return tabla
    End Function



    Public Function ObtieneArticulostallas(ByVal NaveSayId As Integer, ByVal Colecciones As String, ByVal Marca As String, ByVal tallas As String) As DataTable
        Dim objDA As New ColeccionNaveDA
        Dim tabla As New DataTable
        tabla = objDA.ObtieneArticulostallas(NaveSayId, Colecciones, Marca, tallas)
        Return tabla
    End Function

    Public Function ObtenerNaveDesarrolla(ByVal productoestiloId As String)
        Dim obj As New ColeccionNaveDA
        Dim dt As New DataTable
        Dim idnaveDes As Integer
        dt = obj.ObtenerNaveDesarrolla(productoestiloId)
        idnaveDes = dt.Rows(0).Item("NaveId")
        Return idnaveDes

    End Function


End Class