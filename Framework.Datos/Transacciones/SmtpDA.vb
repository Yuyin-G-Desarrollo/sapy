Imports System.Data.SqlClient

Public Class SmtpDA


    Public Function BuscaSMTP(ByVal user As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = "Select * from Framework.SMTP where smtp_usuario='" + user + "'"
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@correo"
        parametro.Value = user
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Framework].[SP_ObtenerCuentaCorreo]", listaParametros)
    End Function

    Public Function ConsultarSMTPTodos() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "Select * from Framework.SMTP"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
End Class

