Imports Proveedores.DA

Public Class TamaniosMaterialesBU
    Public Function getTamañosMateriales(ByVal id As Integer) As DataTable
        Dim obj As New TamaniosDA
        Return obj.getTamañosMateriales(id)
    End Function
    Public Function updateTamañosMateriales(ByVal id As Integer, ByVal nombre As String, ByVal sku As String, ByVal status As Integer) As DataTable
        Dim obj As New TamaniosDA
        Return obj.updateTamañosMateriales(id, nombre, sku, status)
    End Function
    Public Function insertTamañosMateriales(ByVal nombre As String, ByVal sku As String) As DataTable
        Dim obj As New TamaniosDA
        Return obj.insertTamañosMateriales(nombre, sku)
    End Function
    Public Function idtamanoinsertado() As DataTable
        Dim obj As New TamaniosDA
        Return obj.idtamanoinsertado()
    End Function

    Public Function TamanosRepetidos(ByVal tamano As String) As DataTable
        Dim obj As New ColoresMaterialesDa
        Return obj.TamanosRepetidos(tamano)
    End Function

    Public Sub isertarTamanosClasificacion(ByVal tamano As Entidades.ClasificacionTamanovb)
        Dim obj As New TamaniosDA
        obj.isertarTamanoClasificacion(tamano)
    End Sub

    Public Sub ActualizarTamanoClasificacion(ByVal estatus As Integer, ByVal idclas As Integer, ByVal usumod As Integer,
                                             ByVal clasificaciontamid As Integer, ByVal fecha As Date, ByVal idtam As Integer)
        Dim obj As New TamaniosDA
        obj.ActualizarTamanoClasificacion(estatus, idclas, usumod, clasificaciontamid, fecha, idtam)
    End Sub

End Class
