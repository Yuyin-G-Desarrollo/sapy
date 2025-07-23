Public Class SpeedTrackBU
    Public Function ConsultarModelosSpeedTrack() As DataTable
        Dim objDa As New Datos.SpeedTrackDA
        Return objDa.ConsultarModelosSpeedTrack()
    End Function
    Public Function ConsultarReporteSpeedTrack(ByVal fechaInicio As Date, ByVal fechafin As Date) As DataTable
        Dim objDa As New Datos.SpeedTrackDA
        Return objDa.ConsultarReporteSpeedTrack(fechaInicio, fechafin)
    End Function

    Public Function ConsultarListasDePrecios() As DataTable
        Dim objDa As New Datos.SpeedTrackDA
        Return objDa.ConsultarListasDePrecios()
    End Function
    Public Function ConsultarModelosADDSpeedTrack(ByVal listaPrecio As Integer) As DataTable
        Dim objDa As New Datos.SpeedTrackDA
        Return objDa.ConsultarModelosADDSpeedTrack(listaPrecio)

    End Function

    Public Function AgregarModelosSpeedTrack(ByVal productoEstilo As String, ByVal usuario As Integer) As DataTable
        Dim objDa As New Datos.SpeedTrackDA
        Return objDa.AgregarModelosSpeedTrack(productoEstilo, usuario)
    End Function

    Public Function EliminarTodosLosModelosSpeedTrack() As DataTable
        Dim objDa As New Datos.SpeedTrackDA
        Return objDa.EliminarTodosLosModelosSpeedTrack()
    End Function

    Public Function EliminarSoloUnModelo(ByVal modelo As String) As DataTable
        Dim objDa As New Datos.SpeedTrackDA
        Return objDa.EliminarSoloUnModelo(modelo)
    End Function
    Public Function ActualizarParesAutorizados(ByVal cadena As String, ByVal usuarioid As String, ByVal ID As String, ByVal exporto As String) As DataTable
        Dim objDa As New Datos.SpeedTrackDA
        Return objDa.ActualizarParesAutorizados(cadena, usuarioid, ID, exporto)
    End Function
    Public Function ConsultarModelosActializarParesAutorizados() As DataTable
        Dim objDa As New Datos.SpeedTrackDA
        Return objDa.ConsultarModelosActializarParesAutorizados()
    End Function
End Class
