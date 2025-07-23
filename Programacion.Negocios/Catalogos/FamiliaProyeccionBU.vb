Public Class FamiliaProyeccionBU

    Public Function consultaFamiliasProyeccion(ByVal activo As Boolean) As DataTable
        Dim objDA As New Programacion.Datos.FamiliaProyeccionDA
        Return objDA.consultaFamiliasProyeccion(activo)
    End Function
    Public Function getNaves() As DataTable
        Dim objDA As New Programacion.Datos.FamiliaProyeccionDA
        Return objDA.getNaves()
    End Function
    Public Function getNavesDesarrolla() As DataTable
        Dim objDA As New Programacion.Datos.FamiliaProyeccionDA
        Return objDA.getNavesDesarrolla()
    End Function
    Public Function getClasificacion() As DataTable
        Dim objDA As New Programacion.Datos.FamiliaProyeccionDA
        Return objDA.getClasificacion()
    End Function
End Class
