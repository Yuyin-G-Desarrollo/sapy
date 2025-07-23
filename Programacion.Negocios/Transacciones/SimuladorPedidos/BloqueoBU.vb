Imports Programacion.Datos

Public Class BloqueoBU
    Public Function ListadoParametrosReportes(tipo_busqueda As Integer, idUsuario As Integer) As DataTable
        Dim objDA As New BloqueoDA
        Dim tabla As New DataTable
        tabla = objDA.ListadoParametrosReportes(tipo_busqueda, idUsuario)
        Return tabla
    End Function

    Public Function tabla(ByVal filtros As Entidades.FiltrosBloqueos) As DataTable
        Dim vBloqueo As New BloqueoDA
        Return vBloqueo.tabla(filtros)
    End Function
    Public Sub InsertarSemana()
        Dim vBloqueo As New BloqueoDA
        vBloqueo.InsertarSemana()
    End Sub

    Public Sub importarBloqueo()
        Dim objDA As New Datos.BloqueoDA
        objDA.importarBloqueo()
    End Sub

    Public Function consultaTablaBloqueo() As DataTable
        Dim objDA As New Datos.BloqueoDA
        Return objDA.consultaTablaBloqueo()
    End Function

    Public Function fechaUltimaActualizacionTablaBloqueo() As String
        Dim objDA As New Datos.BloqueoDA
        Return objDA.fechaUltimaActualizacionTablaBloqueo
    End Function
End Class
