Imports Proveedores.DA

Public Class ReporteMaterialesBU
    Public Function ListadoNaves(tipo_Nave As Integer, activo As Integer, ByVal TipoConsulta As Integer) As DataTable
        Dim objDA As New ReporteMaterialesDA
        Dim tabla As New DataTable
        tabla = objDA.listadoNaves(tipo_Nave, activo, TipoConsulta)

        Return tabla
    End Function

    Public Function ListadoHormas() As DataTable
        Dim objDA As New ReporteMaterialesDA
        Dim tabla As New DataTable
        tabla = objDA.listadoHormas()
        Return tabla
    End Function

    Public Function ObtenerHormasActivasInactivas(navesId As String, HormaActiva As String, Horma As String, ArticuloActivoEnNAve As String,
                                                  marca As String, coleccion As String, venta As String, temporada As String, estatus As String,
                                                  NaveDesarrollo As String,
                                                  GrupoDesarrollo As String, ModeloSicy As String, Corrida As String) As DataTable
        Dim objDA As New ReporteMaterialesDA
        Dim tabla As New DataTable
        tabla = objDA.ObtenerHormasActivasInactivas(navesId, HormaActiva, Horma, ArticuloActivoEnNAve, marca, coleccion, venta, temporada, estatus, NaveDesarrollo, GrupoDesarrollo, ModeloSicy, Corrida)
        Return tabla
    End Function

    Public Function listadoNavesDesarrollo()
        Dim objDA As New ReporteMaterialesDA
        Dim tabla As New DataTable
        tabla = objDA.listadoNavesDesarrollo()

        Return tabla
    End Function
End Class
