Imports Proveedores.DA

Public Class ClasificacionesBU
    Public Function getClasificaciones(ByVal id As Integer) As DataTable
        Dim obj As New ClasificacionesMaterialesDA
        Return obj.getClasificaciones(id)
    End Function
    Public Function updateClasificaciones(ByVal id As Integer, ByVal nombre As String, ByVal status As String, ByVal sku As String, ByVal directo As Integer) As DataTable
        Dim obj As New ClasificacionesMaterialesDA
        Return obj.updateClasificacion(id, nombre, status, sku, directo)
    End Function
    Public Function inserClasificaciones(ByVal categoria As String, ByVal sku As String, ByVal directo As String) As DataTable
        Dim obj As New ClasificacionesMaterialesDA
        Return obj.insertClasificacion(categoria, sku, directo)
    End Function


    Public Function ClasificacionRepetida(ByVal Clasificacion As String, ByVal CategoriaID As Integer) As DataTable
        Dim obj As New ColoresMaterialesDa
        Return obj.ClasificacionRepetida(Clasificacion, CategoriaID)
    End Function

    'Public Function ultimaClasificaciones()
    '    Dim obj As New ClasificacionesMaterialesDA
    '    Return obj.UltimaClasificacion()
    'End Function

    Public Sub insertarCategoriaClasificaciones(ByVal AltaCategoriaClasificacion As Entidades.CategoriaClasificacion)
        Dim OBJDA As New DA.ClasificacionesMaterialesDA
        OBJDA.insertarCategoriaClasificaciones(AltaCategoriaClasificacion)
    End Sub

    Public Sub ActualizarCategoriaClasificaciones(ByVal AltaCategoriaClasificacion As Entidades.CategoriaClasificacion)
        Dim OBJDA As New DA.ClasificacionesMaterialesDA
        OBJDA.ActualizarCategoriaClasificaciones(AltaCategoriaClasificacion)
    End Sub

    Public Sub insertarClasificacionColores(ByVal AltaClasificacionColores As Entidades.ClasificacionColores)
        Dim OBJDA As New DA.ClasificacionesMaterialesDA
        OBJDA.insertarClasificacionColores(AltaClasificacionColores)
    End Sub

    Public Function updateColoresMateriales(ByVal idColor As Integer, ByVal color As String, ByVal sku As String, ByVal status As Integer) As DataTable
        Dim obj As New ColoresMaterialesDa
        Return obj.updateColoresMateriales(idColor, color, sku, status)
    End Function

    Public Function coloresSeleccionados2(ByVal clasificacion As Integer) As DataTable
        Dim OBJDA As New DA.ClasificacionesMaterialesDA
        Return OBJDA.coloresSeleccionados(clasificacion)
    End Function

    Public Function tamanosSeleccionados2(ByVal clasificacion As Integer) As DataTable
        Dim OBJDA As New DA.ClasificacionesMaterialesDA
        Return OBJDA.tamanosSeleccionados(clasificacion)
    End Function


    Public Sub insertarClasificacionTamano(ByVal AltaClasificacionTamano As Entidades.ClasificacionTamanovb)
        Dim OBJDA As New DA.ClasificacionesMaterialesDA
        OBJDA.insertarClasificacionTamano(AltaClasificacionTamano)
    End Sub

    Public Function ObtenerCategoria(ByVal id As Integer)
        Dim OBJDA As New DA.ClasificacionesMaterialesDA
        Dim lista As DataTable
        lista = OBJDA.ObtenerCategoria(id)
        Return lista
    End Function

    Public Function ObtenerColores(ByVal id As Integer)
        Dim OBJDA As New DA.ClasificacionesMaterialesDA
        Dim lista As DataTable
        lista = OBJDA.obtenerColores(id)
        Return lista
    End Function

    Public Function ClasificacionesSeleccionadasColores(ByVal idcolor As Integer)
        Dim OBJDA As New DA.ClasificacionesMaterialesDA
        Dim lista As DataTable
        lista = OBJDA.ClasificacionesSeleccionadasColores(idcolor)
        Return lista
    End Function

    Public Function coloresSeleccionados(ByVal idclasificacion As Integer)
        Dim OBJDA As New DA.ClasificacionesMaterialesDA
        Dim lista As DataTable
        lista = OBJDA.coloresSeleccionados(idclasificacion)
        Return lista
    End Function

    Public Function ClasificacionesSeleccionadasTamanos(ByVal idtamano As Integer)
        Dim OBJDA As New DA.ClasificacionesMaterialesDA
        Dim lista As DataTable
        lista = OBJDA.ClasificacionesSeleccionadasTamanos(idtamano)
        Return lista
    End Function

    Public Function UltimaClasificacion()
        Dim OBJDA As New DA.ClasificacionesMaterialesDA
        Dim tabla As New DataTable
        tabla = OBJDA.UltimaClasificacion()
        Dim idClasificacion As New Int32
        For Each row As DataRow In tabla.Rows
            idClasificacion = CInt(row("idClas"))
        Next
        Return idClasificacion
    End Function

    Public Function obtenerIdCategoriaClasificacion(ByVal id As Integer)
        Dim OBJDA As New DA.ClasificacionesMaterialesDA
        Dim tabla As New DataTable
        tabla = OBJDA.obtenerIdCategoriaClasificacion(id)
        Dim idClasificacion As New Int32
        For Each row As DataRow In tabla.Rows
            idClasificacion = CInt(row("cacl_categoriaclasificacionid"))
        Next
        Return idClasificacion
    End Function

End Class
