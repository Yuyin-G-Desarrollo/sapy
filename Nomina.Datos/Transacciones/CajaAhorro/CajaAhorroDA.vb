Imports System.Data.SqlClient

Public Class CajaAhorroDA


    Public Sub Altas(objCajaAhorro As Entidades.CajaAhorro)

        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametros As New List(Of SqlParameter)

        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = objCajaAhorro.pNave.PNaveId
        parametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Concepto"
        parametro.Value = objCajaAhorro.pConcepto
        parametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicial"
        parametro.Value = objCajaAhorro.pFechaInicial
        parametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuariocreo"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        parametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFinal"
        parametro.Value = objCajaAhorro.pFechaFinal
        parametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaInicialReporte"
        parametro.Value = objCajaAhorro.pFechaInicialDeducciones
        parametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaFinarlReporte"
        parametro.Value = objCajaAhorro.PFechaFinalDeducciones
        parametros.Add(parametro)

        Operaciones.EjecutarSentenciaSP("[CajaAhorro].[SP_altas_CajaAhorro]", parametros)

    End Sub


    Public Sub Editar(objCajaAhorro As Entidades.CajaAhorro)

        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametros As New List(Of SqlParameter)

        Dim parametro As SqlParameter


        parametro = New SqlParameter
        parametro.ParameterName = "@CajaAhorroId"
        parametro.Value = objCajaAhorro.pCajaAhorroId
        parametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Concepto"
        parametro.Value = objCajaAhorro.pConcepto
        parametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicial"
        parametro.Value = objCajaAhorro.pFechaInicial
        parametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFinal"
        parametro.Value = objCajaAhorro.pFechaFinal
        parametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuariomodifico"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        parametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Operacion"
        parametro.Value = "Editar"
        parametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaInicialReporte"
        parametro.Value = objCajaAhorro.pFechaInicialDeducciones
        parametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaFinarlReporte"
        parametro.Value = objCajaAhorro.PFechaFinalDeducciones
        parametros.Add(parametro)

        Operaciones.EjecutarSentenciaSP("CajaAhorro.SP_editar_CajaAhorro", parametros)


    End Sub


    Public Function Periodos(ByVal objCajaAhorro As Entidades.CajaAhorro) As Int32
        Dim consulta As String
        Dim Operaciones As New Persistencia.OperacionesProcedimientos


        consulta = String.Empty
        consulta += "Select COUNT(*) Cuenta from cajaahorro.cajaahorro where (CONVERT(date, caja_fechaInicial, 103)<= CONVERT(date, '" + Format(objCajaAhorro.pFechaInicial, "dd/MM/yyyy").ToString + "', 103) AND CONVERT(date, caja_fechafinal, 103)>= CONVERT(date, '" + Format(objCajaAhorro.pFechaInicial, "dd/MM/yyyy").ToString + "', 103) " + vbCrLf
        consulta += "OR CONVERT(date, caja_FechaInicial, 103)<=CONVERT(date,'" + Format(objCajaAhorro.pFechaFinal, "dd/MM/yyyy").ToString + "', 103) AND CONVERT(date, caja_FechaFinal, 103) >= CONVERT(date, '" + Format(objCajaAhorro.pFechaFinal, "dd/MM/yyyy").ToString + "', 103)) AND caja_NaveId= " + objCajaAhorro.pNave.PNaveId.ToString + " " + vbCrLf

        Periodos = Operaciones.EjecutaConsulta(consulta).Rows(0)("Cuenta")

    End Function


    Public Function Periodos(ByVal objCajaAhorro As Entidades.CajaAhorro, ByVal Editar As Boolean) As Int32
        Dim consulta As String
        Dim Operaciones As New Persistencia.OperacionesProcedimientos


        consulta = String.Empty
        consulta += "Select COUNT(*) Cuenta from cajaahorro.cajaahorro where (CONVERT(date, caja_fechaInicial, 103) <= CONVERT(date, '" + Format(objCajaAhorro.pFechaInicial, "dd/MM/yyyy").ToString + "', 103) AND CONVERT(date, caja_fechaFinal, 103)>= CONVERT(date, '" + Format(objCajaAhorro.pFechaInicial, "dd/MM/yyyy").ToString + "', 103) " + vbCrLf
        consulta += "OR CONVERT(date, caja_FechaInicial, 103)<=CONVERT(date, '" + Format(objCajaAhorro.pFechaFinal, "dd/MM/yyyy").ToString + "', 103) AND CONVERT(date, caja_FechaFinal, 103) >= CONVERT(date, '" + Format(objCajaAhorro.pFechaFinal, "dd/MM/yyyy").ToString + "', 103)) AND caja_NaveId= " + objCajaAhorro.pNave.PNaveId.ToString + " AND caja_cajaahorroid not IN (" + objCajaAhorro.pCajaAhorroId.ToString + ") " + vbCrLf

        Periodos = Operaciones.EjecutaConsulta(consulta).Rows(0)("Cuenta")

    End Function


    Public Function ObtenerCajaAhorro(ByVal IdCajaAhorro As Int32) As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        ObtenerCajaAhorro = New DataTable

        consulta = "SELECT * FROM cajaahorro.cajaahorro where caja_cajaahorroid= " & IdCajaAhorro

        ObtenerCajaAhorro = Operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ObtenerCajaAhorroAnterior(ByVal IdCajaAhorro As Int32) As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim lstParam As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idCajaAhorro"
        parametro.Value = IdCajaAhorro
        lstParam.Add(parametro)

        Return Operaciones.EjecutarConsultaSP("CajaAhorro.SP_ConsultarCajaAhorroAnterior", lstParam)
    End Function


    Public Function ObtenerCajaAhorro(ByVal IdNave As Int32, Activa As Boolean) As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        ObtenerCajaAhorro = New DataTable

        consulta = "SELECT * FROM cajaahorro.cajaahorro where caja_cajaahorroid= " ' & IdCajaAhorro

        ObtenerCajaAhorro = Operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListarEstatusCajaAhorro() As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim procedimiento As String = String.Empty

        procedimiento = "cajaahorro.SP_EstatusCajaAhorro"

        ListarEstatusCajaAhorro = New DataTable
        ListarEstatusCajaAhorro = Operaciones.EjecutarConsultaSP(procedimiento, Nothing)

    End Function



    Public Function Listar(idnave As Int32, estatus As String) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = vbEmpty

        If estatus = String.Empty Then
            consulta = "SELECT ca.*,ve.estatus from cajaahorro.cajaahorro CA INNER JOIN vEstatusCA vE on CA.caja_estado= vE.caja_estado where CA.caja_naveid= " & idnave.ToString
        Else
            consulta = "SELECT ca.*,ve.estatus from cajaahorro.cajaahorro CA INNER JOIN vEstatusCA vE on CA.caja_estado= vE.caja_estado where CA.caja_naveid= " & idnave.ToString & " AND CA.caja_estado='" & estatus.ToString & "'"
        End If

        Listar = New DataTable
        Listar = operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function periodosCajaAhorroSinCierre(ByVal naveID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT * FROM Nomina.PeriodosNomina"
        consulta += " where pnom_NaveId =" + naveID.ToString
        consulta += " and"
        consulta += " pnom_PeriodoNomId not in (SELECT ccpc_PeriodoId FROM CajaAhorro.ColaboradorPeriodoCaja "
        consulta += " where ccpc_CajaAhorroId=(SELECT caja_CajaAhorroId FROM CajaAhorro.CajaAhorro where caja_NaveId=" + naveID.ToString + " and caja_estado='A')"
        consulta += " GROUP by ccpc_PeriodoId)"
        consulta += " and pnom_stPeriodoNomina in ('C','A')"
        consulta += " order BY pnom_FechaInicial DESC"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function consultaCierreAnualCajaAhorroCerrada(ByVal idCajaAhorro As Int32) As DataTable

        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim lstParam As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idCajaAhorro"
        parametro.Value = idCajaAhorro
        lstParam.Add(parametro)

        Return Operaciones.EjecutarConsultaSP("CajaAhorro.SP_ConsultaCierreAnualCajaAhorro", lstParam)

    End Function


    Public Function consultaCajaAhorroActual(ByVal idNave As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim cadena As String = "SELECT TOP 1 caja_CajaAhorroId, caja_NaveId, caja_Concepto, caja_FechaInicial, caja_FechaFinal," +
        '    " DATEPART(YEAR, caja_FechaInicial) AS AnioInicio, DATEPART(YEAR, caja_FechaFinal) AS AnioFin, caja_FechaCierre," +
        '    " (((DATEDIFF(DAY, caja_FechaInicial, caja_FechaFinal) )/7)-2) as Semanas" +
        '    " FROM CajaAhorro.CajaAhorro WHERE caja_estado = 'A' AND caja_NaveId = " + idNave.ToString
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "naveid"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("CajaAhorro.SP_ConsultaCajaAhorroActual", listaParametros)
        'Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaResumenCajaCerrada(ByVal idCajaAhorro As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim cadena As String = "SELECT" & _
        '    " ca.cca_colaboradorid AS idCol," & _
        '    " c.codr_nombre + ' ' + c.codr_apellidopaterno + ' ' + c.codr_apellidomaterno AS Nombre," & _
        '    " ca.cca_montoahorro AS Monto," & _
        '    " ca.cca_semanasahorradas AS Ahorradas," & _
        '    " ca.cca_semanasganadas AS Ganadas," & _
        '    " ca.cca_semanasperdidas AS Perdidas," & _
        '    " ca.cca_montoacumulado AS Acumulado," & _
        '    " ca.cca_interesganado AS Interes," & _
        '    " ca.cca_totalintereses AS montoInteres," & _
        '    " ca.cca_totalcaja AS Total," & _
        '    " ca.cca_saldoanterior AS SaldoAnterior," & _
        '    " ca.cca_abono AS Abono," & _
        '    " ca.cca_saldonuevo AS SaldoNuevo," & _
        '    " ca.cca_totalentregar AS TotalPagar" & _
        '    " FROM CajaAhorro.CierreAnual ca " & _
        '    " JOIN Nomina.ColaboradorReal cr ON ca.cca_colaboradorid = cr.real_colaboradorid" & _
        '    " JOIN Nomina.Colaborador c ON ca.cca_colaboradorid = c.codr_colaboradorid" & _
        '    " WHERE ca.cca_cajaahorroid = " + idCajaAhorro.ToString & _
        '            " GROUP BY	ca.cca_colaboradorid," & _
        '    " c.codr_nombre," & _
        '    " c.codr_apellidopaterno," & _
        '    " c.codr_apellidomaterno," & _
        '    " ca.cca_montoahorro," & _
        '    " ca.cca_semanasahorradas," & _
        '    " ca.cca_semanasganadas," & _
        '    " ca.cca_semanasperdidas," & _
        '    " ca.cca_montoacumulado," & _
        '    " ca.cca_interesganado," & _
        '    " ca.cca_totalintereses," & _
        '    " ca.cca_totalcaja," & _
        '    " ca.cca_saldoanterior," & _
        '    " ca.cca_abono," & _
        '    " ca.cca_saldonuevo," & _
        '    " cr.real_fecha," & _
        '    " ca.cca_totalentregar" & _
        '    " ORDER BY cr.real_fecha "

        ''" AND c.codr_activo = 1" 

        'Return operacion.EjecutaConsulta(cadena)
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "@idCajaAhorro"
        parametro.Value = idCajaAhorro
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("CajaAhorro.SP_CajaAhorro_ConsultaResumenCajaCerrada", listaParametros)
    End Function


    Public Function consultaGanaInteresPeriodo(ByVal idCaja As Int32, ByVal idNave As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim cadena As String = "SELECT" & _
        '" clp.ccpc_ColaboradorId," & _
        '" cl.codr_nombre + ' '+cl.codr_apellidopaterno+' '+ cl.codr_apellidomaterno AS Nombre," & _
        '" CASE " & _
        '    " WHEN ccheck_caja_ahorro = 1" & _
        '    " THEN" & _
        '        " 's'" & _
        '    " ELSE" & _
        '" 'x'END AS ccheck_caja_ahorro," & _
        '" pn.pnom_NoSemanaNomina," & _
        '" CONVERT(varchar(10), pn.pnom_FechaInicial, 103) + ' AL ' + CONVERT(varchar(10), pn.pnom_FechaFinal, 103) SEMANA" & _
        '" FROM ControlAsistencia.CorteChecador ch" & _
        '" JOIN CajaAhorro.ColaboradorPeriodoCaja clp ON ch.ccheck_colaborador = clp.ccpc_ColaboradorId AND ch.ccheck_periodo_id = clp.ccpc_PeriodoId" & _
        '" JOIN CajaAhorro.CajaColaborador ca ON ca.cajc_ColaboradorId = clp.ccpc_ColaboradorId AND ca.cajc_CajaAhorroId = clp.ccpc_CajaAhorroId" & _
        '" JOIN Nomina.Colaborador cl ON clp.ccpc_ColaboradorId = cl.codr_colaboradorid" & _
        '" JOIN Nomina.PeriodosNomina pn ON ch.ccheck_periodo_id = pn.pnom_PeriodoNomId" & _
        '" AND clp.ccpc_CajaAhorroId = " + idCaja.ToString & _
        '" AND pn.pnom_NaveId =" + idNave.ToString & _
        '" AND cl.codr_activo = 1" & _
        '" GROUP BY clp.ccpc_CajaAhorroId," & _
        '" clp.ccpc_ColaboradorId," & _
        '" cl.codr_nombre," & _
        '" cl.codr_apellidopaterno," & _
        '" cl.codr_apellidomaterno," & _
        '" pn.pnom_Concepto," & _
        '" ch.ccheck_caja_ahorro," & _
        '" pn.pnom_NoSemanaNomina, " & _
        '" pn.pnom_FechaInicial, " & _
        '" pn.pnom_FechaFinal, " & _
        '" pn.pnom_PeriodoNomId " & _
        '" ORDER BY 	pn.pnom_PeriodoNomId, Nombre"
        'Nomina.SP_ConsultaSemanaInteres

        Dim lstParam As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idCaja"
        parametro.Value = idCaja
        lstParam.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idNave"
        parametro.Value = idNave
        lstParam.Add(parametro)

        Return operacion.EjecutarConsultaSP("Nomina.SP_ConsultaSemanaInteres", lstParam)
    End Function

    Public Function NavesAsignadasAsistenteCaja() As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return Operaciones.EjecutarConsultaSP("[Nomina].[SP_CajaAhorro_ObtieneLista_NavesAsistenteCaja]", listaParametros)

    End Function

    Public Function obtenerSaldosPrestamosCaja(ByVal idCajaAhorro As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "@idCajaAhorro"
        parametro.Value = idCajaAhorro
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("CajaAhorro.SP_CajaAhorro_ConsultaSaldosPrestamoCaja", listaParametros)
    End Function

End Class
