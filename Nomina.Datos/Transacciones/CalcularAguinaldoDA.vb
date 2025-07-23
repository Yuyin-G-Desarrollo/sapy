Imports System.Data.SqlClient

Public Class CalcularAguinaldoDA

    Public Function ExisteAguinaldoNave(ByVal idNave As Integer, ByVal Año As Integer) As Boolean
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        Dim ExisteAguinaldo As Integer = 0

        consulta = "SELECT COUNT(*) "
        consulta += "from Nomina.Aguinaldos "
        consulta += "where agui_naveid ='" + idNave.ToString() + "' "
        consulta += "and agui_anio ='" + Año.ToString() + "' "

        ExisteAguinaldo = objOperaciones.EjecutaConsultaEscalar(consulta)

        If ExisteAguinaldo = 0 Then
            Return False
        Else
            Return True
        End If

    End Function


    Public Function ListaColaboradoresAguinaldo(ByVal idNave As Integer) As DataTable

        'Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        ''Dim consulta As String = " select * from  nomina.colaborador as A "
        ''consulta += " JOIN nomina.ColaboradorReal as B on B.real_colaboradorid=a.codr_colaboradorid "
        ''consulta += " JOIN nomina.ColaboradorLaboral as C on C.labo_colaboradorid=A.codr_colaboradorid "
        ''consulta += " where(labo_naveid = " + idNave.ToString + ") "
        ''consulta += " and labo_reportes='True'"
        ''consulta += " and A.codr_activo=1"
        ''consulta += " order by real_fecha asc"
        'Dim consulta As String = String.Empty
        'consulta = "select fini_finiquitoid,* from  nomina.colaborador as A "
        'consulta += "JOIN nomina.ColaboradorReal as B on B.real_colaboradorid=a.codr_colaboradorid "
        'consulta += "JOIN nomina.ColaboradorLaboral as C on C.labo_colaboradorid=A.codr_colaboradorid "
        'consulta += "left join Nomina.Finiquitos on A.codr_colaboradorid=fini_colaboradorid "
        'consulta += "where labo_naveid = " + idNave.ToString + " "
        'consulta += "and labo_reportes='True' "
        'consulta += "and A.codr_activo=1 "
        'consulta += "and fini_finiquitoid is null "
        'consulta += "order by real_fecha asc "

        'Return objOperaciones.EjecutaConsulta(consulta)


        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@idNave"
        parametro.Value = idNave
        listaparametros.Add(parametro)


        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_CalculoAguinaldo_ListaColaboradores]", listaparametros)

    End Function


    Public Function ListaSalariosColaborador(ByVal idColaborador As Integer, ByVal anio As Integer, ByVal naveid As Integer) As DataTable
        '        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        '        Dim consulta As String = ""
        '        consulta += "select isnull(b.conr_salariosemanal,0) conr_salariosemanal from Nomina.PeriodosNomina as a " +
        '        " left join Nomina.CorteNominaReal as b on a.pnom_PeriodoNomId=b.conr_periodonominaid and b.conr_colaboradorid=" + idColaborador.ToString +
        '" where a.pnom_NoSemanaNomina in (49,48,47,46) and year(a.pnom_FechaInicial)=" + anio.ToString + " and a.pnom_NaveId=" + naveid.ToString +
        '" order by a.pnom_FechaInicial ASC	 "
        '        Return objOperaciones.EjecutaConsulta(consulta)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@IdColaborador"
        parametro.Value = idColaborador
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Anio"
        parametro.Value = anio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = naveid
        listaparametros.Add(parametro)
        If naveid = 61 Then
            'Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ListaSalariosColaborador_Aguinaldo_17032021]", listaparametros) 'para el calculo de las vacaciones de Industar
            Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ListaSalariosColaborador_Aguinaldo_17032021_14122022]", listaparametros)
        Else
            Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ListaSalariosColaborador_Aguinaldo_17032021_ORIGINAL]", listaparametros)
        End If


    End Function

    Public Function ListaSalariosColaboradorVacaciones(ByVal idColaborador As Integer, ByVal anio As Integer, ByVal naveid As Integer) As DataTable
        '        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        '        Dim consulta As String = ""
        '        consulta += "select isnull(b.conr_salariosemanal,0) conr_salariosemanal from Nomina.PeriodosNomina as a " +
        '        " left join Nomina.CorteNominaReal as b on a.pnom_PeriodoNomId=b.conr_periodonominaid and b.conr_colaboradorid=" + idColaborador.ToString +
        '" where a.pnom_NoSemanaNomina in (49,48,47,46) and year(a.pnom_FechaInicial)=" + anio.ToString + " and a.pnom_NaveId=" + naveid.ToString +
        '" order by a.pnom_FechaInicial ASC	 "
        '        Return objOperaciones.EjecutaConsulta(consulta)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@IdColaborador"
        parametro.Value = idColaborador
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Anio"
        parametro.Value = anio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = naveid
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ListaSalariosColaborador_Aguinaldo_Vacaciones_Periodos]", listaparametros)

    End Function


    Public Function FaltasPeriodosAguinaldo(ByVal idColaborador As Integer, ByVal anio As Integer, ByVal naveid As Integer) As DataTable
        'Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = ""
        'consulta += "select sum (semanas.ccheck_inasistencia) as inasistencias " +
        '    " from (select top 4 * from Nomina.PeriodosNomina as a join ControlAsistencia.CorteChecador as b on a.pnom_PeriodoNomId=b.ccheck_periodo_id " +
        '    " where a.pnom_NaveId=" + naveid.ToString + " and a.pnom_NoSemanaNomina in (46,47,48,49) and b.ccheck_colaborador=" + idColaborador.ToString + " order by a.pnom_FechaInicial desc) semanas"
        'Return objOperaciones.EjecutaConsulta(consulta)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        parametro = New SqlParameter("@idColaborador", idColaborador)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@anio", anio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@naveid", naveid)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_CalcularAguinaldos_ConsultaFaltas]", listaParametros)

    End Function

    '''' <summary>
    '''' Obtiene las faltas del mes de noviembre del año consultado
    '''' </summary>
    '''' <param name="idColaborador"></param>
    '''' <param name="anio"></param>
    '''' <param name="naveid"></param>
    '''' <returns></returns>
    ''''' <remarks></remarks>
    'Public Function FaltasPeriodosAguinaldo2(ByVal idColaborador As Integer, ByVal anio As Integer, ByVal naveid As Integer) As DataTable
    '    Dim objOperaciones As New Persistencia.OperacionesProcedimientos
    '    Dim consulta As String = ""
    '    consulta += "select sum (semanas.ccheck_inasistencia) as inasistencias " +
    '        " from (select top 4 * from Nomina.PeriodosNomina as a join ControlAsistencia.CorteChecador as b on a.pnom_PeriodoNomId=b.ccheck_periodo_id " +
    '        " where a.pnom_NaveId=" + naveid.ToString + " and a.pnom_NoSemanaNomina in (46,47,48,49) and b.ccheck_colaborador=" + idColaborador.ToString + " and year(a.pnom_FechaInicial) = '" + anio.ToString() + "'  order by a.pnom_FechaInicial desc) semanas"
    '    Return objOperaciones.EjecutaConsulta(consulta)
    'End Function


    Public Function ListaAguinaldos(ByVal idNave As Integer) As DataTable
        Dim objoperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT * FROM nomina.aguinaldos as A "
        consulta += " join Nomina.ColaboradorLaboral as B on B.labo_colaboradorid= A.agui_colaboradorid "
        consulta += " where B.labo_naveid= " + idNave.ToString
        consulta += " order by (agui_anio) asc "

        Return objoperaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListaAguinaldosGUARDADOS(ByVal idNave As Integer, ByVal anio As Integer, ByVal colaborador As String) As DataTable
        'Dim objoperaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = "SELECT * FROM nomina.aguinaldos as A "
        'consulta += " join Nomina.ColaboradorLaboral as B on B.labo_colaboradorid= A.agui_colaboradorid "
        'consulta += " join Nomina.colaborador as C on C.codr_colaboradorid=B.labo_colaboradorid "
        'consulta += "JOIN Nomina.ColaboradorReal AS D on D.real_colaboradorid=A.agui_colaboradorid"
        'consulta += " where agui_anio=" + anio.ToString
        'consulta += " and a.agui_naveid =" + idNave.ToString() + " "
        'consulta += " and (codr_nombre+' '+codr_apellidopaterno+' '+codr_apellidomaterno) like '%" + colaborador.Replace(" ", "%") + "%'"
        'consulta += " order by real_fecha asc"
        'Return objoperaciones.EjecutaConsulta(consulta)

        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@idNave", idNave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@anio", anio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@colaborador", colaborador)
        listaParametros.Add(parametro)

        Return ObjPersistencia.EjecutarConsultaSP("[Nomina].[SP_Obtiene_ListaAguinaldosGuardados]", listaParametros)

    End Function





    Public Sub guardarAguinaldos(ByVal aguinaldos As Entidades.CalcularAguinaldos, ByVal naveid As Integer, ByVal UsuarioCreoID As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "agui_colaboradorid"
        parametro.Value = aguinaldos.PColaborador.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "agui_anio"
        parametro.Value = aguinaldos.PAguinaldoAnio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "agui_meses"
        parametro.Value = aguinaldos.PAguinaldoMeses
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "agui_sueldodiario"
        parametro.Value = aguinaldos.PnominaReal.PSalarioDiario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "agui_diasxpagar"
        parametro.Value = aguinaldos.PDiasxPagar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "agui_totalentregar"
        parametro.Value = aguinaldos.PnominaReal.PTotalEntregar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "agui_naveid"
        parametro.Value = naveid
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreoID"
        parametro.Value = UsuarioCreoID
        listaParametros.Add(parametro)


        operaciones.EjecutarSentenciaSP("Nomina.SP_Altas_Aguinaldos", listaParametros)

    End Sub

    Public Function RevisarConfiguracion(ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_ObtieneConfiguracion_PorcentajeVacaciones_PorNave]", listaParametros)

    End Function

    Public Function FaltasPeriodosVacaciones(ByVal idColaborador As Integer, ByVal anio As Integer, ByVal naveid As Integer) As DataTable
        'Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = ""
        'consulta += "select sum (semanas.ccheck_inasistencia) as inasistencias " +
        '    " from (select top 4 * from Nomina.PeriodosNomina as a join ControlAsistencia.CorteChecador as b on a.pnom_PeriodoNomId=b.ccheck_periodo_id " +
        '    " where a.pnom_NaveId=" + naveid.ToString + " and a.pnom_NoSemanaNomina in (46,47,48,49) and b.ccheck_colaborador=" + idColaborador.ToString + " order by a.pnom_FechaInicial desc) semanas"
        'Return objOperaciones.EjecutaConsulta(consulta)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        parametro = New SqlParameter("@idColaborador", idColaborador)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@anio", anio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@naveid", naveid)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_CalcularAguinaldos_ConsultaFaltas_PeriodoVacaciones]", listaParametros)

    End Function
End Class