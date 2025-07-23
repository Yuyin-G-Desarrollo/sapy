Public Class ControlAsistenciaReplicarDA

    Public Function ListaColaboradorres(ByVal IDNave As Integer, ByVal fechainicio As DateTime)
        Dim ObjOperaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = ""
        Consulta += " select * from Nomina.ColaboradorLaboral as A "
        Consulta += " JOIN Nomina.Colaborador as B on A.labo_colaboradorid=b.codr_colaboradorid"
        Consulta += " JOIN Nomina.ColaboradorNomina as C ON C.cono_colaboradorid=A.labo_colaboradorlaboralid"
        Consulta += " where labo_naveid = " + IDNave.ToString
        Consulta += " and A.labo_checa='TRUE'"
        Consulta += " and B.codr_activo= 'TRUE'"
        Consulta += " AND C.cono_salariodiario>0"
        Consulta += " and C.cono_fechaaltaimss<='" + fechainicio.ToShortDateString + "'"
        Return ObjOperaciones.EjecutaConsulta(Consulta)

    End Function

    Public Function IncidenciasCorteLista(ByVal PeriodoInicioID As Integer, ByVal PeriodoFinID As Integer, ByVal ColaboradorID As Integer)
        Dim ObjOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT * FROM ControlAsistencia.CorteChecador"
        consulta += " where"
        consulta += " (ccheck_retardo_menor>0"
        consulta += " OR ccheck_retardo_mayor>0"
        consulta += " OR ccheck_inasistencia>0)"
        consulta += " AND ccheck_periodo_id BETWEEN " + PeriodoInicioID.ToString + " and " + PeriodoFinID.ToString
        consulta += " and ccheck_colaborador=" + ColaboradorID.ToString
        consulta += " ORDER BY ccheck_periodo_id ASC"
        Return ObjOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function IncidenciasCorteDetalle(ByVal ColaboradorID As Integer, periodoID As Integer, ByVal TipoIncidencia As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT * from ControlAsistencia.RegistroCheck"
        consulta += "         where regcheck_colaborador = " + ColaboradorID.ToString
        consulta += " AND"
        consulta += " ("
        consulta += " (RegistroCheck.regcheck_normal BETWEEN"
        consulta += " ("
        consulta += " Select pnom_FechaInicial"
        consulta += "         FROM Nomina.PeriodosNomina"
        consulta += " WHERE pnom_PeriodoNomId = " + periodoID.ToString
        consulta += " ) "
        consulta += " AND "
        consulta += " DATEADD (DAY , 1 , ("
        consulta += " Select pnom_FechaFinal"
        consulta += "         FROM Nomina.PeriodosNomina"
        consulta += " WHERE pnom_PeriodoNomId = " + periodoID.ToString
        consulta += " )"
        consulta += " )"
        consulta += " ) "
        consulta += " OR (RegistroCheck.regcheck_automatico BETWEEN"
        consulta += " ("
        consulta += " Select pnom_FechaInicial"
        consulta += "         FROM Nomina.PeriodosNomina"
        consulta += " WHERE pnom_PeriodoNomId = " + periodoID.ToString
        consulta += " ) "
        consulta += " AND "
        consulta += " DATEADD (DAY , 1 , ("
        consulta += " Select pnom_FechaFinal"
        consulta += "         FROM Nomina.PeriodosNomina"
        consulta += " WHERE pnom_PeriodoNomId = " + periodoID.ToString
        consulta += " )"
        consulta += " )"
        consulta += " )"
        consulta += " OR (RegistroCheck.regcheck_manual BETWEEN"
        consulta += " ("
        consulta += " Select pnom_FechaInicial"
        consulta += "         FROM Nomina.PeriodosNomina"
        consulta += " WHERE pnom_PeriodoNomId = " + periodoID.ToString
        consulta += " ) "
        consulta += " AND "
        consulta += " DATEADD (DAY , 1 , ("
        consulta += " Select pnom_FechaFinal"
        consulta += "         FROM Nomina.PeriodosNomina"
        consulta += " WHERE pnom_PeriodoNomId = " + periodoID.ToString
        consulta += " )"
        consulta += " )"
        consulta += " )"
        consulta += " )"
        consulta += " AND regcheck_resultado=" + TipoIncidencia.ToString
        consulta += " AND regcheck_replicadoNP='FALSE'"
        If TipoIncidencia = 0 Then
            consulta += " ANd regcheck_tipo_check=1"
        End If
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function FechaInicialPeriodo(ByVal periodoID As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " select * from Nomina.PeriodosNomina"
        consulta += " where pnom_PeriodoNomId=" + periodoID.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub ActualizarReplicar(ByVal idRegistroCheck As Integer)
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += "  UPDATE ControlAsistencia.RegistroCheck"
        consulta += " SET regcheck_replicadoNP='TRUE'"
        consulta += " where"
        consulta += " regcheck_id =" + idRegistroCheck.ToString
        Operaciones.EjecutaConsulta(consulta)
    End Sub

    ''select * from nomina.PeriodosNomina where pnom_NaveId=3 and pnom_stPeriodoAsistencia='C' order by pnom_FechaFinal DESC
    Public Function PeriodosReplicar(ByVal naveID As Integer)
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " select * from nomina.PeriodosNomina "
        consulta += " where pnom_NaveId=" + naveID.ToString
        consulta += " and pnom_stPeriodoAsistencia='C' "
        consulta += " order by pnom_FechaFinal DESC"
        Return Operaciones.EjecutaConsulta(consulta)
    End Function

End Class
