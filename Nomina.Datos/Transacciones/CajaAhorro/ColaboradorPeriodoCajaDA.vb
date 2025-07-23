Imports System.Data.SqlClient

Public Class ColaboradorPeriodoCajaDA

    Public Function Listar(idCajaAhorro As Int32) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = vbEmpty


        If VerificaExistenciaCierre(idCajaAhorro) <= 0 Then
            'Resultado = "El cierre de la caja de ahorro ya se realizo."
            consulta = "SELECT ca.caja_cajaahorroid cajc_cajaahorroid, pn.pnom_periodonomid pnom_periodonomid, cpc.ccpc_colaboradorid cajc_colaboradorid, cpc.ccpc_montoahorro cajc_montoahorro "
            consulta += "FROM cajaahorro.cajaahorro CA INNER JOIN nomina.periodosnomina PN ON ca.caja_naveid=pn.pnom_naveid "
            consulta += "INNER JOIN CAJAAHORRO.colaboradorperiodocaja CPC ON ca.caja_cajaahorroid=ca.caja_cajaahorroid AND cpc.ccpc_periodoid=pn.pnom_periodonomid "
            consulta += "INNER JOIN nomina.colaborador nc on nc.codr_colaboradorid=cpc.ccpc_ColaboradorId "
            consulta += "INNER JOIN nomina.colaboradorreal ncr on ncr.real_colaboradorid=cpc.ccpc_ColaboradorId "
            consulta += "WHERE ca.caja_cajaahorroid=" + idCajaAhorro.ToString + " AND pn.pnom_stperiodonomina='A' and codr_activo=1 and nc.codr_colaboradorid not in (SELECT fini_colaboradorid FROM nomina.finiquitos) "
            consulta += "AND CONVERT(date, pn.pnom_fechainicial, 103)>=CONVERT(date, ca.caja_fechainicial, 103) "
            consulta += "AND CONVERT(date, pn.pnom_fechafinal, 103)<=CONVERT(date, ca.caja_fechafinal, 103) "
            consulta += "ORDER BY ncr.real_fecha ASC"
        Else
            consulta = "SELECT cc.cajc_cajaahorroid, pn.pnom_periodonomid, cc.cajc_colaboradorid, cc.cajc_montoahorro "
            consulta += "FROM cajaahorro.cajacolaborador CC INNER JOIN cajaahorro.cajaahorro CA ON cc.cajc_cajaahorroid=ca.caja_cajaahorroid "
            consulta += "INNER JOIN nomina.periodosnomina PN ON ca.caja_naveid=pn.pnom_naveid "
            consulta += "INNER JOIN nomina.colaborador nc on nc.codr_colaboradorid=cc.cajc_colaboradorid "
            consulta += "INNER JOIN nomina.colaboradorreal ncr on ncr.real_colaboradorid=cc.cajc_colaboradorid "
            consulta += "WHERE cc.cajc_cajaahorroid=" + idCajaAhorro.ToString + " AND cc.cajc_estatus='A' AND pn.pnom_stPeriodoNomina='A' /*and pn.pnom_stPeriodoCajaAhorro='A'*/ and codr_activo=1 and nc.codr_colaboradorid not in (SELECT fini_colaboradorid FROM nomina.finiquitos)"
            consulta += "AND CONVERT(date, pn.pnom_fechainicial, 103)>=CONVERT(date, ca.caja_fechainicial, 103) "
            consulta += "AND CONVERT(date, pn.pnom_fechafinal, 103)<=CONVERT(date, ca.caja_fechafinal, 103)  "
            consulta += "ORDER BY ncr.real_fecha ASC"
        End If


        'consulta = "SELECT cc.cajc_cajaahorroid, pn.pnom_periodonomid, cc.cajc_colaboradorid, cc.cajc_montoahorro "
        'consulta += "FROM cajaahorro.cajacolaborador CC INNER JOIN cajaahorro.cajaahorro CA ON cc.cajc_cajaahorroid=ca.caja_cajaahorroid "
        'consulta += "INNER JOIN nomina.periodosnomina PN ON ca.caja_naveid=pn.pnom_naveid "
        'consulta += "WHERE cc.cajc_cajaahorroid=" + idCajaAhorro.ToString + " AND cc.cajc_estatus='A' AND pn.pnom_stPeriodoNomina='A' /*and pn.pnom_stPeriodoCajaAhorro='A'*/ "
        'consulta += "AND CONVERT(date, pn.pnom_fechainicial, 103)>=CONVERT(date, ca.caja_fechainicial, 103) "
        'consulta += "AND CONVERT(date, pn.pnom_fechafinal, 103)<=CONVERT(date, ca.caja_fechafinal, 103)  "


        Listar = New DataTable
        Listar = operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Listar(idCajaAhorro As Int32, idperiodonomina As Int32) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = vbEmpty


        consulta = "SELECT ccpc_cajaahorroid, ccpc_periodoid, ccpc_colaboradorid, ccpc_montoahorro "
        consulta += "FROM cajaahorro.colaboradorperiodocaja "
        consulta += "WHERE ccpc_cajaahorroid = " + idCajaAhorro.ToString + " And ccpc_periodoid = " + idperiodonomina.ToString + " "


        Listar = New DataTable
        Listar = operaciones.EjecutaConsulta(consulta)

    End Function



    Public Function VerificaExistenciaPeriodoNomina(ByVal IdCajaAhorro As Int32) As Int32
        Dim consulta As String = vbEmpty
        Dim Operaciones As New Persistencia.OperacionesProcedimientos

        VerificaExistenciaPeriodoNomina = 0


        consulta = "SELECT COUNT(ca.caja_cajaahorroid) Cuenta "
        consulta += "FROM cajaahorro.cajaahorro CA "
        consulta += "WHERE ca.caja_cajaahorroid=" + IdCajaAhorro.ToString + " AND EXISTS ( "
        consulta += "Select pn.pnom_periodonomid "
        consulta += "FROM nomina.periodosnomina PN "
        consulta += "WHERE pnom_stperiodonomina='A' AND CONVERT(date, pn.pnom_fechainicial, 103)>=CONVERT(date, ca.caja_fechainicial, 103) "
        consulta += "AND CONVERT(date, pn.pnom_fechafinal, 103)<=CONVERT(date, ca.caja_fechafinal, 103) AND pn.pnom_naveid= CA.caja_naveid ) "


        VerificaExistenciaPeriodoNomina = Operaciones.EjecutaConsulta(consulta).Rows(0)("Cuenta")

        Return VerificaExistenciaPeriodoNomina

    End Function


    Public Function VerificaExistenciaCierre(ByVal IdCajaAhorro As Int32) As Int32
        Dim consulta As String = vbEmpty
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        VerificaExistenciaCierre = 0

        consulta = ""
        consulta += "SELECT COUNT(*) Cuenta "
        consulta += "FROM cajaahorro.cajaahorro CA "
        consulta += "INNER JOIN nomina.periodosnomina PN ON ca.caja_naveid=pn.pnom_naveid "
        consulta += "WHERE ca.caja_cajaahorroid=" + IdCajaAhorro.ToString + " AND pn.pnom_stPeriodoNomina='A' and pn.pnom_stPeriodoCajaAhorro='A' "
        consulta += "AND CONVERT(date, pn.pnom_fechainicial, 103)>=CONVERT(date, ca.caja_fechainicial, 103) "
        consulta += "AND CONVERT(date, pn.pnom_fechafinal, 103)<=CONVERT(date, ca.caja_fechafinal, 103)  "

        VerificaExistenciaCierre = Operaciones.EjecutaConsulta(consulta).Rows(0)("Cuenta")

        Return VerificaExistenciaCierre

    End Function


   Public Function VerificaExistenciaColaboradores(ByVal IdCajaAhorro As Int32) As Int32
        Dim consulta As String = vbEmpty
        Dim Operaciones As New Persistencia.OperacionesProcedimientos

        VerificaExistenciaColaboradores = 0

        consulta = "Select COUNT(cajc_cajaahorroid) Cuenta "
        consulta += "FROM cajaahorro.cajacolaborador "
        consulta += "where cajc_cajaahorroid = " + IdCajaAhorro.ToString

        VerificaExistenciaColaboradores = Operaciones.EjecutaConsulta(consulta).Rows(0)("Cuenta")

        Return VerificaExistenciaColaboradores

    End Function


    Public Sub CerrarCajaAhorro(ByVal listado As List(Of Entidades.ColaboradorPeriodoCaja))

        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim comandoSql As New List(Of SqlCommand)
        Dim IdPeriodo As Int32 = 0
        Dim IdCajaAhorro As Int32 = 0

        For Each objeto As Entidades.ColaboradorPeriodoCaja In listado

            Dim parametros As New List(Of SqlParameter)
            Dim parametro As SqlParameter

            IdPeriodo = objeto.pPeriodo.PPeriodoId
            IdCajaAhorro = objeto.pCajaAhorro.pCajaAhorroId

            parametro = New SqlParameter
            parametro.ParameterName = "@CajaAhorroId"
            parametro.Value = objeto.pCajaAhorro.pCajaAhorroId
            parametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@PeriodoId"
            parametro.Value = objeto.pPeriodo.PPeriodoId
            parametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColaboradorId"
            parametro.Value = objeto.pColaborador.PColaboradorid
            parametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MontoAhorro"
            parametro.Value = objeto.pMontoAhorrado
            parametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuariocreo"
            parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            parametros.Add(parametro)

            Dim comando As New SqlCommand
            comando.CommandType = CommandType.StoredProcedure
            comando.CommandText = "CajaAhorro.SP_CierreSemanal"

            For Each Para As SqlParameter In parametros
                comando.Parameters.Add(Para)
            Next

            comandoSql.Add(comando)
        Next


        Dim parametros1 As New List(Of SqlParameter)
        Dim parametro1 As SqlParameter

        parametro1 = New SqlParameter
        parametro1.ParameterName = "@PeriodoId"
        parametro1.Value = IdPeriodo
        parametros1.Add(parametro1)

        parametro1 = New SqlParameter
        parametro1.ParameterName = "@IdCajaAhorro"
        parametro1.Value = IdCajaAhorro
        parametros1.Add(parametro1)

        Dim comando1 As New SqlCommand
        comando1.CommandType = CommandType.StoredProcedure
        comando1.CommandText = "[CajaAhorro].[SP_CierreSemanalOperaciones]"

        For Each Para As SqlParameter In parametros1
            comando1.Parameters.Add(Para)
        Next
        comandoSql.Add(comando1)

        Operaciones.EjecutacmdTransaccion(comandoSql)



    End Sub




   Public Function ObtieneIdCajaAhorro(ByVal IdPeriodoNomina As Int32) As Int32
        Dim consulta As String = vbEmpty
        Dim Operaciones As New Persistencia.OperacionesProcedimientos

        ObtieneIdCajaAhorro = 0

        consulta = "Select ccpc_cajaahorroid "
        consulta += "FROM cajaahorro.colaboradorperiodocaja "
        consulta += "where ccpc_periodoid= " & IdPeriodoNomina.ToString & " "
        consulta += "GROUP by ccpc_cajaahorroid"

        ObtieneIdCajaAhorro = Operaciones.EjecutaConsulta(consulta).Rows(0)("ccpc_cajaahorroid")

        Return ObtieneIdCajaAhorro

    End Function

   Public Function ObtieneIdCajaAhorro_nave(ByVal idnave As Int32) As Int32
        Dim consulta As String = vbEmpty
        Dim Operaciones As New Persistencia.OperacionesProcedimientos

        ObtieneIdCajaAhorro_nave = 0


        consulta = "Select caja_cajaahorroid "
        consulta += "FRom cajaahorro.cajaahorro "
        consulta += "where caja_naveid= " & idnave.ToString & " and caja_estado='A' "


        ObtieneIdCajaAhorro_nave = Operaciones.EjecutaConsulta(consulta).Rows(0)("caja_cajaahorroid")

        Return ObtieneIdCajaAhorro_nave

    End Function

   Public Function VerificaIdCajaAhorro_nave(ByVal idnave As Int32) As Int32
        Dim consulta As String = vbEmpty
        Dim Operaciones As New Persistencia.OperacionesProcedimientos

        VerificaIdCajaAhorro_nave = 0


        consulta = "Select count(caja_cajaahorroid) Id "
        consulta += "FRom cajaahorro.cajaahorro "
        consulta += "where caja_naveid= " & idnave.ToString & " and caja_estado='A' "


        VerificaIdCajaAhorro_nave = Operaciones.EjecutaConsulta(consulta).Rows(0)("Id")

        Return VerificaIdCajaAhorro_nave

    End Function



End Class
