Imports Produccion.Datos

Public Class TarjetaProduccionBU

    Public Function LotesPrograma(ByVal nave As Integer, ByVal fecha As String) As DataTable
        Dim obj As New TarjetaProduccionDA
        Return obj.LotesPrograma(nave, fecha)
    End Function

End Class
