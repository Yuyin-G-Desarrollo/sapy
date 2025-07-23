Imports System.Data.SqlClient

Public Class AuditoriaDA
    Dim operaciones As New Persistencia.OperacionesProcedimientos

    ''' <summary>
    ''' Guardamos la información del inicio de sesión del usuario.
    ''' </summary>
    ''' <param name="NombreUsuario"></param>
    ''' <param name="Sistema"></param>
    Public Sub GuardarInformacionInicioSesion(ByVal NombreUsuario As String)
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@NombreUsuario", NombreUsuario)
        listaparametros.Add(parametro)

        operaciones.EjecutarConsultaSP("[Framework].[SP_Auditoria_InsertarInformacionInicioSesion]", listaparametros)
    End Sub

End Class
