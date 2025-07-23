Imports System.Data.SqlClient
Public Class EnviosCorreoDA

    Public Function consulta_destinatarios_email(ByVal naveid As Integer, ByVal clave As String) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT EnviosCorreo.envio_destinos FROM Framework.EnviosCorreo WHERE EnviosCorreo.envio_clave LIKE '" + clave + "' And envio_naveid = " + naveid.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function


    Public Function consulta_email_colaborador(ListaColaborador As List(Of Integer)) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT user_email FROM Framework.Usuarios where user_colaboradorid IN ( "

        For Each colaborador In ListaColaborador

            If colaborador = ListaColaborador.First Then
                consulta += colaborador.ToString
            Else
                consulta += " , " + colaborador.ToString
            End If

        Next

        consulta += " ) "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function consulta_email_usuario_validacion(tipoValidacion As List(Of Integer)) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT user_email FROM Framework.ValidacionUsuario" +
                                " JOIN Framework.Usuarios ON user_colaboradorid = vati_colaboradorid " +
                                " WHERE vaus_activo = 1 " +
                                " AND vati_validaciontipoid IN ("

        For Each value In tipoValidacion

            If value = tipoValidacion.First Then
                consulta += value.ToString
            Else
                consulta += " , " + value.ToString
            End If

        Next

        consulta += " ) "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function consultaDestinatariosSolicitudCarta(ByVal naveId As Integer) As DataTable
        Dim obj As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@idNave", naveId)
        listaParametros.Add(parametro)

        Return obj.EjecutarConsultaSP("[Programacion].[SP_CartaInformativa_ConsultaDestinatariosXNave]", listaParametros)

        'Dim consulta As String = "select nave_cartascorreos from Framework.Naves WHERE nave_naveid = " + naveId.ToString
        'Return operaciones.EjecutaConsulta(consulta)

    End Function

End Class
