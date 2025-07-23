
Public Class EnvioCorreosBU

    Public Function ConsultaEnvioCorreosFacturas(ByVal StatusCorreo As Integer, ByVal TipoArchivo As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal ClienteSICYID As String, ByVal AgenteID As String, ByVal RazonSocial As String, ByVal Usuario As String)

        Dim objListaDevolucionesDA As New Datos.EnvioCorreosDA
        Dim tablas As New DataTable

        Try
            tablas = objListaDevolucionesDA.ConsultaEnvioCorreosFacturas(StatusCorreo, TipoArchivo, FechaInicio, FechaFin, ClienteSICYID, AgenteID, RazonSocial, Usuario)
        Catch ex As Exception
            Throw ex
        End Try

        Return tablas
    End Function


End Class
