Public Class MensajeriaBU

    Public Function ObtenerIDDestinoMensajeria(ByVal idProveedor As Int32, ByVal idCiudad As Int32, ByVal IdPoblacion As Integer) As DataTable
        Dim objDA As New Datos.MensajeriaDA
        Dim consulta As String = String.Empty

        ObtenerIDDestinoMensajeria = objDA.ObtenerIDDestinoMensajeria(idProveedor, idCiudad, IdPoblacion)

        Return ObtenerIDDestinoMensajeria
    End Function

End Class
