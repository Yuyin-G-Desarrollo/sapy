Imports Persistencia
Imports System.Data.SqlClient

Public Class RegistroCheckDA

    Public Function buscar_BloqueDetalleHorario(ByVal horaCheck As DateTime, ByVal diaCheck As Integer, ByVal horarioID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
                  " SELECT *FROM ControlAsistencia.DetalleHorario " +
                  " WHERE dh_inicio_bloque <= CAST(GETDATE() AS time)" +
                  " AND dh_termino_bloque >= CAST(GETDATE() AS time)" +
                  " AND dh_horarioid = " + horarioID.ToString +
                  " AND dh_dia = DATEPART(WEEKDAY,GETDATE()) "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function buscar_DetalleRegistroCheck(ByVal regcheck_id As Integer, ByVal regcheck_naveid As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM ControlAsistencia.RegistroCheck "
        consulta += "Join Nomina.ColaboradorLaboral "
        consulta += "ON regcheck_colaborador = labo_colaboradorid "
        consulta += "Join Framework.Grupos "
        consulta += "ON labo_departamentoid = Grupos.grup_grupoid "
        consulta += "WHERE regcheck_id = " + regcheck_id.ToString + " And regcheck_naveid = " + regcheck_naveid.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub guardar_RegistroCheck(ByVal check_flag As Integer, ByVal registroCheck As Entidades.RegistroCheck)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "checkID"
        parametro.Value = registroCheck.PId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "check_naveID"
        parametro.Value = registroCheck.Pregcheck_nave.PNaveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "check_colaboradorID"
        parametro.Value = registroCheck.PCheck_Colaborador.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "check_resultado"
        parametro.Value = registroCheck.PCheck_Resultado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "check_tipo_check"
        parametro.Value = registroCheck.PCheck_Tipo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "check_excepcion_id"
        If IsDBNull(registroCheck.PCheck_Excepcion) Or IsNothing(registroCheck.PCheck_Excepcion) Then
            parametro.Value = 0
            listaParametros.Add(parametro)
        Else
            parametro.Value = registroCheck.PCheck_Excepcion.Pregexc_id
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "check_flag"
        parametro.Value = check_flag
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "check_manual"
        If registroCheck.PCheck_manual = DateTime.MinValue Then
            parametro.Value = Now
            listaParametros.Add(parametro)
        Else
            parametro.Value = registroCheck.PCheck_manual
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "check_nota"
        If IsDBNull(registroCheck.PCheck_Nota) Or IsNothing(registroCheck.PCheck_Nota) Then
            parametro.Value = 0
            listaParametros.Add(parametro)
        Else
            parametro.Value = registroCheck.PCheck_Nota
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "usuario_modifico"
        Try
            parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            listaParametros.Add(parametro)
        Catch ex As Exception
            parametro.Value = 0
            listaParametros.Add(parametro)
        End Try

        operaciones.EjecutarSentenciaSP("ControlAsistencia.SP_Alta_RegistroCheck", listaParametros)
        Console.WriteLine("Mandó la sentencia")

    End Sub

    Public Function buscar_RegistroPrevioCheck(ByVal tipoCheck As Integer, ByVal colaboradorID As Integer) As DataTable

        Dim opereciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM ControlAsistencia.RegistroCheck "

        consulta += "WHERE RegistroCheck.regcheck_tipo_check = " + tipoCheck.ToString + " "
        consulta += "AND RegistroCheck.regcheck_colaborador = " + colaboradorID.ToString + " "
        consulta += "AND ((RegistroCheck.regcheck_normal > CAST(GETDATE() AS date) AND RegistroCheck.regcheck_normal < DATEADD(DAY,1,CAST(GETDATE() AS date))) "
        consulta += "OR (RegistroCheck.regcheck_automatico > CAST(GETDATE() AS date) AND RegistroCheck.regcheck_automatico < DATEADD(DAY,1,CAST(GETDATE() AS date))) "
        consulta += "OR (RegistroCheck.regcheck_manual > CAST(GETDATE() AS date) AND RegistroCheck.regcheck_manual < DATEADD(DAY,1,CAST(GETDATE() AS date)))) "

        Return opereciones.EjecutaConsulta(consulta)

    End Function

    Public Function buscar_RegistroPrevioCheckUlterior(ByVal tipoCheck As Integer, ByVal colaboradorID As Integer) As DataTable

        Dim opereciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM ControlAsistencia.RegistroCheck "

        consulta += "WHERE RegistroCheck.regcheck_tipo_check >= " + tipoCheck.ToString + " "
        consulta += "AND RegistroCheck.regcheck_colaborador = " + colaboradorID.ToString + " "
        consulta += "AND ((RegistroCheck.regcheck_normal > CAST(GETDATE() AS date) AND RegistroCheck.regcheck_normal < DATEADD(DAY,1,CAST(GETDATE() AS date))) "
        consulta += "OR (RegistroCheck.regcheck_automatico > CAST(GETDATE() AS date) AND RegistroCheck.regcheck_automatico < DATEADD(DAY,1,CAST(GETDATE() AS date))) "
        consulta += "OR (RegistroCheck.regcheck_manual > CAST(GETDATE() AS date) AND RegistroCheck.regcheck_manual < DATEADD(DAY,1,CAST(GETDATE() AS date)))) "

        Return opereciones.EjecutaConsulta(consulta)

    End Function

    Public Function buscar_Excepcion(ByVal tipoCheck As Integer, ByVal colaboradorID As Integer) As DataTable

        Dim opereciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM ControlAsistencia.RegistroCheck JOIN ControlAsistencia.RegistroExcepcion ON RegistroCheck.regcheck_excepcion_id = RegistroExcepcion.regexc_id "

        consulta += "WHERE RegistroCheck.regcheck_tipo_check >= " + tipoCheck.ToString + " "
        consulta += "AND RegistroCheck.regcheck_colaborador = " + colaboradorID.ToString + " "
        consulta += "AND ((RegistroCheck.regcheck_normal > CAST(GETDATE() AS date) AND RegistroCheck.regcheck_normal < DATEADD(DAY,1,CAST(GETDATE() AS date))) "
        consulta += "OR (RegistroCheck.regcheck_automatico > CAST(GETDATE() AS date) AND RegistroCheck.regcheck_automatico < DATEADD(DAY,1,CAST(GETDATE() AS date))) "
        consulta += "OR (RegistroCheck.regcheck_manual > CAST(GETDATE() AS date) AND RegistroCheck.regcheck_manual < DATEADD(DAY,1,CAST(GETDATE() AS date)))) "

        Return opereciones.EjecutaConsulta(consulta)

    End Function

    Public Function buscar_ExcepcionUlterior(ByVal tipoCheck As Integer, ByVal colaboradorID As Integer) As DataTable

        Dim opereciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM ControlAsistencia.RegistroCheck JOIN ControlAsistencia.RegistroExcepcion ON RegistroCheck.regcheck_excepcion_id = RegistroExcepcion.regexc_id "

        consulta += "WHERE RegistroCheck.regcheck_tipo_check >= " + tipoCheck.ToString + " "
        consulta += "AND RegistroCheck.regcheck_colaborador = " + colaboradorID.ToString + " "
        consulta += "AND ((RegistroCheck.regcheck_normal > CAST(GETDATE() AS date) AND RegistroCheck.regcheck_normal < DATEADD(DAY,1,CAST(GETDATE() AS date))) "
        consulta += "OR (RegistroCheck.regcheck_automatico > CAST(GETDATE() AS date) AND RegistroCheck.regcheck_automatico < DATEADD(DAY,1,CAST(GETDATE() AS date))) "
        consulta += "OR (RegistroCheck.regcheck_manual > CAST(GETDATE() AS date) AND RegistroCheck.regcheck_manual < DATEADD(DAY,1,CAST(GETDATE() AS date)))) "

        Return opereciones.EjecutaConsulta(consulta)

    End Function

End Class
