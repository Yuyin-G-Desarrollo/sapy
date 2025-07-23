Imports System.Data.SqlClient

Public Class ReporteCajaAhorroDA


    Public Function Listar(idcajaahorro As Int32) As DataTable
        Listar = New DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@IdCajaAhorro"
        parametro.Value = idcajaahorro

        parametros.Add(parametro)


        Listar = operaciones.EjecutarConsultaSP("CajaAhorro.SP_ObtieneReporteCajaAhorro", parametros)
    End Function


    Public Function VerificaExistenciaCierre(ByVal IdCajaAhorro As Int32) As Int32
        Dim consulta As String = vbEmpty
        Dim Operaciones As New Persistencia.OperacionesProcedimientos

        VerificaExistenciaCierre = 0


        consulta = "SELECT COUNT(caja_cajaahorroid) Cuenta "
        consulta += "FROM cajaahorro.cajaahorro "
        consulta += "WHERE caja_cajaahorroid = " + IdCajaAhorro.ToString + " and caja_estado IN ('A') "


        VerificaExistenciaCierre = Operaciones.EjecutaConsulta(consulta).Rows(0)("Cuenta")

        Return VerificaExistenciaCierre

    End Function


    Public Function VerificaExistenciaSemanasSinCerrar(ByVal IdCajaAhorro As Int32) As Int32
        Dim consulta As String = vbEmpty
        Dim Operaciones As New Persistencia.OperacionesProcedimientos

        VerificaExistenciaSemanasSinCerrar = 0


        consulta = "SELECT COUNT(ca.caja_cajaahorroid) Cuenta "
        consulta += "FROM cajaahorro.cajaahorro CA "
        consulta += "WHERE ca.caja_cajaahorroid=" + IdCajaAhorro.ToString + " AND EXISTS ( "
        consulta += "Select pn.pnom_periodonomid "
        consulta += "FROM nomina.periodosnomina PN "
        consulta += "WHERE pn.pnom_stperiodocajaahorro='A' AND CONVERT(date, pn.pnom_fechainicial, 103)>=CONVERT(date, ca.caja_fechainicial, 103) "
        consulta += "AND CONVERT(date, pn.pnom_fechafinal, 103)<=CONVERT(date, ca.caja_fechafinal, 103) AND pn.pnom_naveid= CA.caja_naveid ) "


        VerificaExistenciaSemanasSinCerrar = Operaciones.EjecutaConsulta(consulta).Rows(0)("Cuenta")

        Return VerificaExistenciaSemanasSinCerrar

    End Function


    Public Function VerificaExistenciaSemanaNomina(ByVal IdCajaAhorro As Int32) As Int32
        Dim consulta As String = vbEmpty
        Dim Operaciones As New Persistencia.OperacionesProcedimientos

        VerificaExistenciaSemanaNomina = 0


        consulta = "SELECT COUNT(ca.caja_cajaahorroid) Cuenta "
        consulta += "FROM cajaahorro.cajaahorro CA "
        consulta += "WHERE ca.caja_cajaahorroid=" + IdCajaAhorro.ToString + " AND EXISTS ( "
        consulta += "Select pn.pnom_periodonomid "
        consulta += "FROM nomina.periodosnomina PN "
        consulta += "WHERE pnom_stperiodonomina IN ('A','C') AND CONVERT(date, pn.pnom_fechainicial, 103)<=CONVERT(date, ca.caja_fechafinal, 103) "
        consulta += "AND CONVERT(date, pn.pnom_fechafinal, 103)>=CONVERT(date, ca.caja_fechafinal, 103) AND pn.pnom_naveid= CA.caja_naveid ) "

        VerificaExistenciaSemanaNomina = Operaciones.EjecutaConsulta(consulta).Rows(0)("Cuenta")

        Return VerificaExistenciaSemanaNomina

    End Function

Public Sub CierreAnualCajaAhorro(ByVal idCajaAhorro As Int32)

        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim comandoSql As New List(Of SqlCommand)


        Dim parametros1 As New List(Of SqlParameter)
        Dim parametro1 As SqlParameter


        parametro1 = New SqlParameter
        parametro1.ParameterName = "@IdCajaAhorro"
        parametro1.Value = idCajaAhorro
        parametros1.Add(parametro1)

        Dim comando1 As New SqlCommand
        comando1.CommandType = CommandType.StoredProcedure
        comando1.CommandText = "[CajaAhorro].[SP_CierreAnualOperaciones]"

        For Each Para As SqlParameter In parametros1
            comando1.Parameters.Add(Para)
        Next
        comandoSql.Add(comando1)

        Operaciones.EjecutacmdTransaccion(comandoSql)



    End Sub


    Public Function consultaSemanasCaJa(ByVal idCajaAhorro As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim sql As String = vbEmpty
        'sql = "select * from Nomina.PeriodosNomina as a"
        'sql += " where pnom_FechaInicial>=(select convert(date,c.caja_FechaInicial) from CajaAhorro.CajaAhorro as c where caja_CajaAhorroId=" + idCajaAhorro.ToString + ")"
        'sql += "and pnom_FechaFinal<= ( select convert(date,c.caja_FechaFinal) from CajaAhorro.CajaAhorro as c where caja_CajaAhorroId=" + idCajaAhorro.ToString + " ) "
        'sql += " and pnom_NaveId=(select c.caja_NaveId from CajaAhorro.CajaAhorro as c where caja_CajaAhorroId=" + idCajaAhorro.ToString + ")"
        'sql += " order by pnom_FechaInicial"

        'Return operaciones.EjecutaConsulta(sql)
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idCajaAhorro"
        parametro.Value = idCajaAhorro
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[CajaAhorro].[SP_CajaAhorro_consultaSemanasCaJa]", listaParametros) ''SCDA 24012020


    End Function

    Public Function colaboradoresCajaCierre(ByVal idCajaAhorro As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim sql As String = vbEmpty
        sql = "select * from Nomina.Colaborador as a "
        sql += " join nomina.ColaboradorLaboral as b on a.codr_colaboradorid=b.labo_colaboradorid"
        sql += " where a.codr_activo = 1"
        sql += " and b.labo_naveid=(select c.caja_NaveId from CajaAhorro.CajaAhorro as c where caja_CajaAhorroId=" + idCajaAhorro.ToString + ")"
        sql += " and a.codr_colaboradorid not in"
        sql += " (select fini_colaboradorid from Nomina.Finiquitos as f)"
        sql += " and a.codr_colaboradorid in "
        sql += " (select cajc_ColaboradorId from CajaAhorro.CajaColaborador where cajc_CajaAhorroId=" + idCajaAhorro.ToString + ")"
        sql += " order by a.codr_idanual"

        Return operaciones.EjecutaConsulta(sql)
    End Function

    Public Function colaboradoresCajaCierre2(ByVal idCajaAhorro As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim sql As String = vbEmpty
        'sql =  "select a.codr_colaboradorid, a.codr_nombre+' '+  a.codr_apellidopaterno+' '+ a.codr_apellidomaterno as codr_nombre, b.labo_checa from Nomina.Colaborador as a "
        'sql += " join nomina.ColaboradorLaboral as b on a.codr_colaboradorid=b.labo_colaboradorid"
        'sql += " where a.codr_activo = 1"
        'sql += " and b.labo_naveid=(select c.caja_NaveId from CajaAhorro.CajaAhorro as c where caja_CajaAhorroId=" + idCajaAhorro.ToString + ")"
        'sql += " and a.codr_colaboradorid not in"
        'sql += " (select fini_colaboradorid from Nomina.Finiquitos as f)"
        'sql += " and a.codr_colaboradorid in "
        'sql += " (select cajc_ColaboradorId from CajaAhorro.CajaColaborador where cajc_CajaAhorroId=" + idCajaAhorro.ToString + ")"
        'sql += " order by a.codr_idanual"

        'Return operaciones.EjecutaConsulta(sql)

        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idCajaAhorro"
        parametro.Value = idCajaAhorro
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[CajaAhorro].[SP_CajaAhorro_colaboradoresCajaCierre]", listaParametros) ''SCDA 24012020
    End Function

    Public Function consultaSemanasGanadasCol(ByVal idColaborador As Int32, ByVal idCajaAhorro As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim sql As String
        'sql = "  select cpc.ccpc_PeriodoId,isnull(ccheck_caja_ahorro,1) as ccheck_caja_ahorro, cpc.ccpc_MontoAhorro  from CajaAhorro.ColaboradorPeriodoCaja as cpc"
        'sql += " INNER JOIN Nomina.PeriodosNomina pn on cpc.ccpc_PeriodoId = pn.pnom_PeriodoNomId "
        'sql += " left join ControlAsistencia.CorteChecador AS CC on cc.ccheck_periodo_id=cpc.ccpc_PeriodoId and cc.ccheck_colaborador=cpc.ccpc_ColaboradorId"
        'sql += " where cpc.ccpc_ColaboradorId = " & idColaborador.ToString & " And cpc.ccpc_CajaAhorroId = " & idCajaAhorro.ToString & " "
        'sql += " ORDER BY pnom_FechaInicial "
        'Return operaciones.EjecutaConsulta(sql)

        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idColaborador"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCajaAhorro"
        parametro.Value = idCajaAhorro
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[CajaAhorro].[SP_CajaAhorro_consultaSemanasGanadasCol]", listaParametros) ''SCDA 23012020

    End Function

    Public Function ConsultaSemanasGanadas(ByVal idColaborador As Int32, ByVal idSemana As Int32) As Boolean
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim sql As String = vbEmpty

        sql = "select ccheck_caja_ahorro from ControlAsistencia.CorteChecador where ccheck_colaborador=" + idColaborador.ToString + " and ccheck_periodo_id=" + idSemana.ToString
        Dim tabla As New DataTable
        tabla = operaciones.EjecutaConsulta(sql)
        ConsultaSemanasGanadas = False
        For Each row As DataRow In tabla.Rows
            Try
                ConsultaSemanasGanadas = row("ccheck_caja_ahorro")
            Catch
                ConsultaSemanasGanadas = False
            End Try
        Next

    End Function

    Public Function ConsultaSemanaIngreso(ByVal idColaborador As Int32, ByVal idCajaAhorro As Int32) As Int32
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim sql As String
        sql = "select top 1 * from CajaAhorro.ColaboradorPeriodoCaja where ccpc_ColaboradorId=" & idColaborador & " and ccpc_CajaAhorroId=" & idCajaAhorro & " and ccpc_MontoAhorro>0 order by ccpc_fechacreacion"
        Dim tabla As New DataTable
        tabla = operaciones.EjecutaConsulta(sql)
        If tabla.Rows.Count > 0 Then
            ConsultaSemanaIngreso = tabla.Rows(0).Item("ccpc_PeriodoId").ToString
        Else
            ConsultaSemanaIngreso = 0
        End If
        Return ConsultaSemanaIngreso
    End Function

    Public Function ConsultaSemanasGanadasNoCheca(ByVal idCajaAhorro As Int32, ByVal nave As Int32) As Int32
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim sql As String = vbEmpty
        sql = "SELECT MAX(pnom_NoSemanaCajaAhorro) as totalSemanas FROM Nomina.PeriodosNomina WHERE pnom_stPeriodoNomina='C' AND"
        sql += " pnom_FechaInicial >= (SELECT c.caja_FechaInicial FROM CajaAhorro.CajaAhorro AS c WHERE c.caja_CajaAhorroId = " + idCajaAhorro.ToString + ")"
        sql += " AND pnom_FechaFinal <= (SELECT c.caja_FechaFinal FROM CajaAhorro.CajaAhorro AS c WHERE c.caja_CajaAhorroId =" + idCajaAhorro.ToString + ")"
        sql += " AND pnom_NaveId=" + nave.ToString
        Dim tabla As New DataTable
        tabla = operaciones.EjecutaConsulta(sql)
        If tabla.Rows.Count > 0 Then
            ConsultaSemanasGanadasNoCheca = tabla.Rows(0).Item("totalSemanas").ToString
        Else
            ConsultaSemanasGanadasNoCheca = 0
        End If
        Return ConsultaSemanasGanadasNoCheca
    End Function

    Public Function CountSemanasAhorradas(ByVal idColaborador As Int32, ByVal idCajaAhorro As Int32) As Int32
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim sql As String

        sql = "select count(*) as semanasAhorradas from CajaAhorro.ColaboradorPeriodoCaja where ccpc_ColaboradorId=" & idColaborador.ToString
        sql += "and ccpc_CajaAhorroId=" & idCajaAhorro.ToString & " and ccpc_MontoAhorro>0"
        Dim tabla As New DataTable
        tabla = operaciones.EjecutaConsulta(sql)
        If tabla.Rows.Count > 0 Then
            CountSemanasAhorradas = tabla.Rows(0).Item("semanasAhorradas").ToString
        Else
            CountSemanasAhorradas = 0
        End If
        Return CountSemanasAhorradas
    End Function

    Public Function CountSemanasGanadas(ByVal idColaborador As Int32, ByVal idCajaAhorro As Int32, ByVal accion As Int32) As Int32
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim sql As String

        sql = "select count(*) as numero from CajaAhorro.ColaboradorPeriodoCaja as cpc "
        sql += " left join ControlAsistencia.CorteChecador AS CC   on cc.ccheck_periodo_id=cpc.ccpc_PeriodoId and cc.ccheck_colaborador=cpc.ccpc_ColaboradorId"
        sql += " where cpc.ccpc_ColaboradorId=" & idColaborador.ToString & " and cpc.ccpc_CajaAhorroId=" & idCajaAhorro.ToString
        If accion = 1 Then
            sql += "  AND (CC.ccheck_caja_ahorro=1 OR CC.ccheck_caja_ahorro IS NULL)  and ccpc_MontoAhorro>0"
        Else
            sql += "  AND (CC.ccheck_caja_ahorro=0)  and ccpc_MontoAhorro>0"
        End If

        Dim tabla As New DataTable
        tabla = operaciones.EjecutaConsulta(sql)
        If tabla.Rows.Count > 0 Then
            CountSemanasGanadas = tabla.Rows(0).Item("numero").ToString
        Else
            CountSemanasGanadas = 0
        End If
        Return CountSemanasGanadas
    End Function

    'Public Function CountSemanasGanadas(ByVal idColaborador As Int32, ByVal idCajaAhorro As Int32) As Int32
    '    Dim operaciones As New Persistencia.OperacionesProcedimientos
    '    Dim sql As String = vbEmpty

    '    sql = "select COUNT(*) as totalSemanas from ControlAsistencia.CorteChecador as a"
    '    sql += " join Nomina.PeriodosNomina as b on a.ccheck_periodo_id=b.pnom_PeriodoNomId"
    '    sql += " where ccheck_colaborador = " + idColaborador.ToString
    '    sql += " and pnom_FechaInicial>=(select c.caja_FechaInicial from CajaAhorro.CajaAhorro as c where c.caja_CajaAhorroId=" + idCajaAhorro.ToString + ")"
    '    sql += " and pnom_FechaFinal<=(select c.caja_FechaFinal from CajaAhorro.CajaAhorro as c where c.caja_CajaAhorroId=" + idCajaAhorro.ToString + ")"
    '    Dim tabla As New DataTable
    '    tabla = operaciones.EjecutaConsulta(sql)
    '    If tabla.Rows.Count > 0 Then
    '        CountSemanasGanadas = tabla.Rows(0).Item("totalSemanas").ToString
    '    Else
    '        CountSemanasGanadas = 0
    '    End If
    '    Return CountSemanasGanadas
    'End Function

    Public Function CalcularInteresTotal(ByVal idCajaAhorro As Int32, ByVal idColaborador As Int32, ByVal interes As Int32) As Int32
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim intereses As Int32 = 0
        Dim dt As New DataTable


        'Dim sql As String'

        'sql = "SELECT  ISNULL(sum(CASE WHEN isnull(CC.ccheck_caja_ahorro,1)>0 THEN cpc.ccpc_MontoAhorro*0." & interes
        'sql += " WHEN isnull(CC.ccheck_caja_ahorro,1)<1 THEN 0 END ),0) as TotalIntereses  "
        'sql += " from CajaAhorro.ColaboradorPeriodoCaja as cpc"
        'sql += " left join ControlAsistencia.CorteChecador AS CC   on cc.ccheck_periodo_id=cpc.ccpc_PeriodoId and cc.ccheck_colaborador=cpc.ccpc_ColaboradorId"
        'sql += " where cpc.ccpc_ColaboradorId=" & idColaborador.ToString & " and cpc.ccpc_CajaAhorroId=" & idCajaAhorro.ToString

        'dt = operaciones.EjecutaConsulta(sql)

        parametro.ParameterName = "@cajaahorroid"
        parametro.Value = idCajaAhorro
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colaboradorid"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@intereses"
        parametro.Value = Double.Parse("0." + interes.ToString)
        listaParametros.Add(parametro)

        dt = operaciones.EjecutarConsultaSP("[Nomina].[SP_CierreAnualCajaAhorro_CalcularInteresesTotal]", listaParametros)

        If dt.Rows.Count > 0 Then
            intereses = dt.Rows(0).Item(0)
        End If
        Return intereses
    End Function

    Public Function BuscaInteresGanado(ByVal idCajaAhorro As Int32, ByVal semanasPerdidas As Int32) As Int32
        ', ByVal semanasAhorradas As Int32, ByVal totalSemanas As Int32, ByVal registraChecador As Boolean Se quitaron 16/05/2015
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim sql As String = vbEmpty
        Dim dt As New DataTable
        Dim interes As Int32 = 0
        'If semanasAhorradas < totalSemanas Then
        '    semanasPerdidas = totalSemanas
        'End If
        'If registraChecador = True Then
        '    sql = "select * from CajaAhorro.ConfiguracionCajaNave where cocn_CajaAhorroId=" + idCajaAhorro.ToString + " and cocn_SemanaInicial <=" + semanasPerdidas.ToString + " and cocn_SemanaFinal>=" + semanasPerdidas.ToString
        'Else
        '    sql = "select max(cocn_Interes) as cocn_Interes from CajaAhorro.ConfiguracionCajaNave where cocn_CajaAhorroId=" + idCajaAhorro.ToString
        'End If
        'Dim tabla As New DataTable
        'tabla = operaciones.EjecutaConsulta(sql)
        'BuscaInteresGanado = 0
        'For Each row As DataRow In tabla.Rows
        '    Try
        '        BuscaInteresGanado = row("cocn_Interes")
        '    Catch
        '        BuscaInteresGanado = 0
        '    End Try
        'Next
        sql = "SELECT" +
        " TOP 1 cocn_Interes" +
        " FROM CajaAhorro.ConfiguracionCajaNave" +
        " WHERE cocn_CajaAhorroId = " + idCajaAhorro.ToString +
        " AND (cocn_SemanaInicial <= " + semanasPerdidas.ToString +
        " AND cocn_SemanaFinal >= " + semanasPerdidas.ToString + ")"

        dt = operaciones.EjecutaConsulta(sql)

        If dt.Rows.Count > 0 Then
            interes = dt.Rows(0).Item(0)
        End If
        Return interes
    End Function

    Public Function BuscaMontoAcumulado(ByVal idCajaAhorro As Int32, ByVal colaboradorid As Int32) As Double
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim sql As String = vbEmpty
        
        sql = "select SUM(ccpc_montoahorro) as montoahorro from CajaAhorro.ColaboradorPeriodoCaja where ccpc_CajaAhorroId=" + idCajaAhorro.ToString + " and ccpc_ColaboradorId=" + colaboradorid.ToString
       
        Dim tabla As New DataTable
        tabla = operaciones.EjecutaConsulta(sql)
        BuscaMontoAcumulado = 0
        For Each row As DataRow In tabla.Rows
            Try
                BuscaMontoAcumulado = row("montoahorro")
            Catch
                BuscaMontoAcumulado = 0
            End Try
        Next

    End Function

    Public Function BuscaMontoAhorroColaborador(ByVal idCajaAhorro As Int32, ByVal colaboradorid As Int32) As Double
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim sql As String = vbEmpty

        sql = "select cajc_MontoAhorro from CajaAhorro.CajaColaborador where cajc_CajaAhorroId=" + idCajaAhorro.ToString + " and cajc_ColaboradorId=" + colaboradorid.ToString + ""

        Dim tabla As New DataTable
        tabla = operaciones.EjecutaConsulta(sql)
        BuscaMontoAhorroColaborador = 0
        For Each row As DataRow In tabla.Rows
            Try
                BuscaMontoAhorroColaborador = row("cajc_MontoAhorro")
            Catch
                BuscaMontoAhorroColaborador = 0
            End Try
        Next
    End Function

    Public Sub cierreAnualCajaAhorro(ByVal CierreAnual As Entidades.ReporteCajaAhorro)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@cca_colaboradorid"
        parametro.Value = CierreAnual.pIdColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cca_cajaahorroid"
        parametro.Value = CierreAnual.pIdCajaAhorro
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cca_montoahorro"
        parametro.Value = CierreAnual.pMontoAhorro
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cca_semanasahorradas"
        parametro.Value = CierreAnual.PSEmanasAhorradas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cca_semanasganadas"
        parametro.Value = CierreAnual.pGanadas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cca_semanasperdidas"
        parametro.Value = CierreAnual.pPerdidas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cca_interesganado"
        parametro.Value = CierreAnual.pInteres
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cca_montoacumulado"
        parametro.Value = CierreAnual.pAhorrado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cca_totalintereses"
        parametro.Value = CierreAnual.pTotalInteres
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cca_totalcaja"
        parametro.Value = CierreAnual.pAhorroMasInteres
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cca_prestamoid"
        parametro.Value = CierreAnual.PPrestamos.Pjustificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cca_saldoanterior"
        parametro.Value = CierreAnual.PPrestamosPago.PSaldoAnterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cca_abono"
        parametro.Value = CierreAnual.PPrestamosPago.PAbonoCapital
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cca_saldonuevo"
        parametro.Value = CierreAnual.PPrestamosPago.PSaldoNuevo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cca_totalentregar"
        parametro.Value = CierreAnual.PTotalEntregar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@caja_MontoAhorro"
        parametro.Value = CierreAnual.PMontoAcumuladoCajaAnual
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@caja_MontoInteres"
        parametro.Value = CierreAnual.PMontoAcumuladoInteresCajaAnual
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@caja_MontoAhorroTotal"
        parametro.Value = CierreAnual.PMontoAcumuladoCajaMASInteres
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@caja_usuariomodificoid"
        parametro.Value = CierreAnual.PUsuarioModifico
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pagop_semananominaid"
        parametro.Value = CierreAnual.PPrestamosPeriodoNomina.PeriodoId
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@Prestamo"
        'parametro.Value = CierreAnual.PPrestamo
        'listaParametros.Add(parametro)


        operaciones.EjecutarSentenciaSP("CajaAhorro.SP_Cierre_AnualCajaAhorro", listaParametros)


    End Sub


    Public Sub guardarAbonosTemporal(ByVal idprestamo As Integer, ByVal abono As Double)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idprestamo"
        parametro.Value = idprestamo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@montoabono"
        parametro.Value = abono
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("CajaAhorro.sp_guardatemporal_abonoscierreanual", listaParametros)
    End Sub

    Public Sub guardarAbonosCierreCaja(ByVal idcolaborador As Integer, ByVal idcajaAhorro As Integer, ByVal abono As Double, ByVal operacion As Integer, ByVal usuario As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idcolaborador"
        parametro.Value = idcolaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idcajaAhorro"
        parametro.Value = idcajaAhorro
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@montoabono"
        parametro.Value = abono
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@operacion"
        parametro.Value = operacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = usuario
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("CajaAhorro.sp_guardaabonoscierreanual", listaParametros)
    End Sub

    Public Function BuscaMontoAbonoTemporal(ByVal idColaborador As Integer, ByVal idCajaAhorro As Integer) As Double
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim sql As String = vbEmpty

        sql = "select * from Nomina.AbonoPrestamosCierreCaja where idColaborador=" + idColaborador.ToString + " and idCajaAhorro=" + idCajaAhorro.ToString

        Dim tabla As New DataTable
        tabla = operaciones.EjecutaConsulta(sql)
        BuscaMontoAbonoTemporal = -1
        For Each row As DataRow In tabla.Rows
            Try
                BuscaMontoAbonoTemporal = row("Abono")
            Catch
                BuscaMontoAbonoTemporal = 0
            End Try
        Next
    End Function

    Public Function ConsultaCierreAnual(ByVal idCajaAhorro, ByVal idColaborador) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim sql As String = vbEmpty

        sql = "select * from CajaAhorro.CierreAnual where cca_cajaahorroid=" + idCajaAhorro.ToString + " and cca_colaboradorid=" + idColaborador.ToString
        Return operaciones.EjecutaConsulta(sql)
    End Function

    Public Function consultaCajaAhorroRecorridas(ByVal idCaja As Int32) As Int32
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        Dim total As Int32 = 0
        cadena = "SELECT DISTINCT" +
                    " COUNT(DISTINCT pn.pnom_PeriodoNomId)" +
                    " FROM CajaAhorro.ColaboradorPeriodoCaja cp" +
                    " JOIN Nomina.PeriodosNomina pn" +
                        " ON cp.ccpc_PeriodoId = pn.pnom_PeriodoNomId" +
                    " WHERE ccpc_CajaAhorroId = " + idCaja.ToString
        Dim dt As DataTable
        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            total = dt.Rows(0).Item(0)
        End If
        Return total
    End Function

    Public Function consultaDeduccionesSemanas(ByVal anio As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        '    Dim cadena As String = "SELECT * FROM (SELECT" +
        '" pn.pnom_NoSemanaNomina," +
        '" pn.pnom_NoSemanaCajaAhorro," +
        '" nv.nave_nombre," +
        '" SUM(d.dedu_cantidad) AS TotalSemana" +
        '" FROM CajaAhorro.ColaboradorPeriodoCaja cpc" +
        '" JOIN Nomina.Deducciones d ON cpc.ccpc_ColaboradorId = d.dedu_colaboradorid AND cpc.ccpc_PeriodoId = d.dedu_periodonominaid" +
        '" JOIN CajaAhorro.CajaAhorro ca ON cpc.ccpc_CajaAhorroId = ca.caja_CajaAhorroId" +
        '" JOIN Framework.Naves nv	ON ca.caja_NaveId = nv.nave_naveid" +
        '" JOIN Nomina.PeriodosNomina pn ON cpc.ccpc_PeriodoId = pn.pnom_PeriodoNomId" +
        '    " WHERE DatePart(Year, ca.caja_FechaInicial) = " + anio.ToString +
        '" GROUP BY	pn.pnom_NoSemanaNomina, pn.pnom_NoSemanaCajaAhorro, ca.caja_NaveId," +
        '        " nv.nave_nombre) AS CONS PIVOT (SUM(TotalSemana) FOR nave_nombre IN (" +
        '        " [YUYIN],[JEANS], [MERANO],[VAGABUNDO],[JEANS 2], [ORENSE],[COMERCIALIZADORA], [RANCHITO],[COMERCIALIZADORA DE SUELAS])) AS PVTO" +
        '        " ORDER BY pnom_NoSemanaNomina, pnom_NoSemanaCajaAhorro"
        '" AND ca.caja_estado = 'A'" +
        'Return operacion.EjecutaConsulta(cadena)
        parametro.ParameterName = "anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[CajaAhorro].[SP_ObtieneReporteConcentradoCajaAhorro]", listaParametros) ''SCDA 280319
    End Function

    Public Function consultaPrestamoSemanas(ByVal anio As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        'Dim cadena As String = "SELECT * FROM (" +
        '" SELECT cons.pnom_NoSemanaNomina," +
        '" cons.pnom_NoSemanaCajaAhorro," +
        '" cons.nave_nombre," +
        '" (SELECT SUM(p.pres_montoautorizado) FROM Prestamos.Prestamos p" +
        '" JOIN Nomina.ColaboradorLaboral cl ON p.pres_colaboradorid = cl.labo_colaboradorid" +
        '" WHERE cl.labo_naveid = cons.nave_naveid AND pres_fechaentrega BETWEEN cons.pnom_FechaInicial AND cons.pnom_FechaFinal) prestamo" +
        ' " FROM  (SELECT" +
        '    " pn.pnom_NoSemanaNomina," +
        '    " pn.pnom_NoSemanaCajaAhorro," +
        '    " nv.nave_naveid," +
        '    " nv.nave_nombre," +
        '    " pn.pnom_FechaInicial," +
        '    " pn.pnom_FechaFinal" +
        '" FROM CajaAhorro.ColaboradorPeriodoCaja cpc" +
        '" JOIN CajaAhorro.CajaAhorro ca ON cpc.ccpc_CajaAhorroId = ca.caja_CajaAhorroId" +
        '" JOIN Framework.Naves nv	ON ca.caja_NaveId = nv.nave_naveid" +
        '" JOIN Nomina.PeriodosNomina pn ON cpc.ccpc_PeriodoId = pn.pnom_PeriodoNomId" +
        '" WHERE DatePart(Year, ca.caja_FechaInicial) = " + anio.ToString +
        '                " GROUP BY" +
        '" pn.pnom_NoSemanaNomina," +
        '    " pn.pnom_NoSemanaCajaAhorro," +
        '    " nv.nave_naveid," +
        '    " nv.nave_nombre," +
        '    " pn.pnom_FechaInicial, " +
        '    " pn.pnom_FechaFinal) as cons) as pres PIVOT (SUM(prestamo) FOR nave_nombre IN (" +
        '    " [YUYIN],[JEANS], [MERANO],[VAGABUNDO],[JEANS 2], [ORENSE],[COMERCIALIZADORA], [RANCHITO],[COMERCIALIZADORA DE SUELAS])) AS PVTO" +
        '     " ORDER BY pnom_NoSemanaNomina, pnom_NoSemanaCajaAhorro"

        ''" AND ca.caja_estado = 'A'" +
        'Return operacion.EjecutaConsulta(cadena)
        parametro.ParameterName = "anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[CajaAhorro].[SP_ObtieneReporteConcentradoPrestamos]", listaParametros)
    End Function

    Public Function consultaLisquidacionSemana(ByVal anio As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        '    cadena = "SELECT" +
        '" * FROM (SELECT" +
        '" cons.pnom_NoSemanaNomina," +
        '" cons.pnom_NoSemanaCajaAhorro," +
        '" cons.nave_nombre," +
        '" (SELECT SUM(f.fini_totalentregar) FROM Nomina.Finiquitos f " +
        '" JOIN Nomina.ColaboradorLaboral cl ON cl.labo_colaboradorid = f.fini_colaboradorid" +
        '" WHERE fini_fechaentregado BETWEEN cons.pnom_FechaInicial AND cons.pnom_FechaFinal AND f.fini_estado = 'G' AND cl.labo_naveid = cons.nave_naveid)" +
        '    " prestamo" +
        '" FROM (SELECT" +
        '    " pn.pnom_NoSemanaNomina," +
        '    " pn.pnom_NoSemanaCajaAhorro," +
        '    " nv.nave_naveid," +
        '    " nv.nave_nombre," +
        '    " pn.pnom_FechaInicial," +
        '    " pn.pnom_FechaFinal" +
        '    " FROM CajaAhorro.ColaboradorPeriodoCaja cpc" +
        '    " JOIN CajaAhorro.CajaAhorro ca	ON cpc.ccpc_CajaAhorroId = ca.caja_CajaAhorroId" +
        '    " JOIN Framework.Naves nv	ON ca.caja_NaveId = nv.nave_naveid" +
        '    " JOIN Nomina.PeriodosNomina pn ON cpc.ccpc_PeriodoId = pn.pnom_PeriodoNomId" +
        '    " WHERE DatePart(Year, ca.caja_FechaInicial) = " + anio.ToString +
        '" GROUP BY	pn.pnom_NoSemanaNomina," +
        '        " pn.pnom_NoSemanaCajaAhorro," +
        '        " nv.nave_naveid," +
        '        " nv.nave_nombre," +
        '        " pn.pnom_FechaInicial," +
        '        " pn.pnom_FechaFinal) AS cons) AS pres PIVOT (SUM(prestamo) FOR nave_nombre" +
        '        " IN ([YUYIN], [JEANS], [MERANO], [VAGABUNDO], [JEANS 2], [ORENSE], [COMERCIALIZADORA], [RANCHITO], [COMERCIALIZADORA DE SUELAS])) AS PVTO" +
        '         " ORDER BY pnom_NoSemanaNomina, pnom_NoSemanaCajaAhorro"

        '    Return operacion.EjecutaConsulta(cadena)

        parametro.ParameterName = "anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[CajaAhorro].[SP_ObtieneReporteConcentradoLiquidaciones]", listaParametros)
    End Function

    Public Function consultaDeduccionesSemanasNaves(ByVal anio As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[CajaAhorro].[SP_ConsultaReporteConcentradoCajaAhorro_V2]", listaParametros) ''SCDA 280319
    End Function

End Class
