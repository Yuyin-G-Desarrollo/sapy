Imports Framework.Datos

Public Class AuditoriaBU
    Dim objDA As New AuditoriaDA

    ''' <summary>
    ''' Guardamos la información del inicio de sesión del usuario.
    ''' </summary>
    ''' <param name="NombreUsuario"></param>
    ''' <param name="Sistema"></param>
    Public Sub GuardarInformacionInicioSesion(ByVal NombreUsuario As String)
        Try
            objDA.GuardarInformacionInicioSesion(NombreUsuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
