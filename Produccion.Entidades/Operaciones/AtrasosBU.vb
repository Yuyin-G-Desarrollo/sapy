Imports Produccion.Datos
Imports Entidades
Public Class AtrasosBU
    Public Function ListaMotivosAtrasosDeProduccion() As DataTable
        Dim objDA As New AtrasosDA
        Dim tabla As New DataTable
        ListaMotivosAtrasosDeProduccion = New DataTable
        tabla = objDA.ListaMotivosAtraso()
        If tabla.Rows.Count > 0 Then
            ListaMotivosAtrasosDeProduccion = tabla
        End If
    End Function
End Class
