Imports Persistencia
Imports System.Data.SqlClient

Public Class DetalleHorarioDA

    Public Function listaDetalleHorario(ByVal idHorario As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM ControlAsistencia.DetalleHorario JOIN Nomina.Horarios AS h ON h.hora_horarioid = dh_horarioid "


        consulta += " WHERE h.hora_horarioid = " + idHorario.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function buscar_InicioFinBloque(ByVal dh_horarioid As Integer, ByVal dh_check As Integer, ByVal dh_dia As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM ControlAsistencia.DetalleHorario "

        If dh_dia <> 0 Then
            consulta += "WHERE dh_horarioid = " + dh_horarioid.ToString + " AND dh_check = " + dh_check.ToString + " AND dh_dia = " + dh_dia.ToString
        ElseIf dh_dia = 0 Then
            consulta += "WHERE dh_horarioid = " + dh_horarioid.ToString + " AND dh_check = " + dh_check.ToString + " AND dh_dia = 7"
        End If



        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub guardarDetalleHorario(ByVal detalleHorario As Entidades.DetalleHorario)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        '@id AS INTEGER,
        '@hora_check AS TIME,
        '@inicio_bloque AS TIME,
        '@termino_bloque AS TIME,
        '@horarioid AS INTEGER,
        '@dia AS INTEGER,
        '@check AS INTEGER,
        '@usuario_crea AS INTEGER,
        '@usuario_modifica AS INTEGER

        Dim parametro As New SqlParameter
        parametro.ParameterName = "id"
        parametro.Value = detalleHorario.DH_ID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "hora_check"
        parametro.Value = detalleHorario.DH_HoraCheck
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inicio_bloque"
        parametro.Value = detalleHorario.DH_InicioBloque
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "termino_bloque"
        parametro.Value = detalleHorario.DH_FinBloque
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "horarioid"
        parametro.Value = detalleHorario.DH_horario.DHorariosid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dia"
        parametro.Value = detalleHorario.DH_Dia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "check"
        parametro.Value = detalleHorario.DH_TipoCheck
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuario_crea"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuario_modifica"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("ControlAsistencia.SP_altas_DetalleHorario", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

End Class
