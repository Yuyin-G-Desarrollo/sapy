Public Class EnviosCorreoBU

    Public Function consulta_destinatarios_email(ByVal naveid As Integer, ByVal clave As String) As String
        Dim objDA As New Datos.EnviosCorreoDA
        Dim tabla As New DataTable
        tabla = objDA.consulta_destinatarios_email(naveid, clave)

        consulta_destinatarios_email = Nothing
        For Each row As DataRow In tabla.Rows
            consulta_destinatarios_email = CStr(row("envio_destinos"))
        Next

    End Function

    Public Function consulta_email_colaborador(ListaColaborador As List(Of Integer)) As String

        Dim objDA As New Datos.EnviosCorreoDA
        Dim tabla As New DataTable
        tabla = objDA.consulta_email_colaborador(ListaColaborador)

        consulta_email_colaborador = Nothing

        For Each row As DataRow In tabla.Rows

            If tabla.Rows.IndexOf(row) = 0 Then
                consulta_email_colaborador = CStr(row("user_email"))
            Else
                consulta_email_colaborador = " , " + CStr(row("user_email"))
            End If

        Next

    End Function

    Public Function consulta_email_usuario_validacion(tipoValidacion As List(Of Integer)) As String

        Dim objDA As New Datos.EnviosCorreoDA
        Dim tabla As New DataTable
        tabla = objDA.consulta_email_usuario_validacion(tipoValidacion)

        consulta_email_usuario_validacion = Nothing

        For Each row As DataRow In tabla.Rows

            If tabla.Rows.IndexOf(row) = 0 Then
                consulta_email_usuario_validacion = CStr(row("user_email"))
            Else
                consulta_email_usuario_validacion = " , " + CStr(row("user_email"))
            End If

        Next

    End Function

    Public Function consultaDestinatariosSolicitudCarta(ByVal naveId As Integer) As String
        Dim obj As New Framework.Datos.EnviosCorreoDA
        Dim tabla As New DataTable
        tabla = obj.consultaDestinatariosSolicitudCarta(naveId)
        consultaDestinatariosSolicitudCarta = Nothing
        For Each row As DataRow In tabla.Rows
            consultaDestinatariosSolicitudCarta = CStr(row("nave_cartascorreos"))
        Next
    End Function

End Class
