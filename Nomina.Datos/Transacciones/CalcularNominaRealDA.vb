Imports System.Data.SqlClient
Public Class CalcularNominaRealDA

    Public Function ListaCorteNomina(ByVal idNave As Integer, ByVal idPeriodoNomina As Integer, ByVal colaborador As String, ByVal tipoSalario As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@PeriodoNominaId"
        parametro.Value = idPeriodoNomina
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Colaborador"
        parametro.Value = colaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoSalario"
        parametro.Value = tipoSalario
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("SP_Nomina_ListaCorteNominaReal", listaParametros)
    End Function

    Public Function ListaDeduccionesColaborador(ByVal idColaborador As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos

        Dim consulta As String = "    select  * from Nomina.ColaboradorLaboral as A     "
        consulta += " JOIN Nomina.Colaborador as B on A.labo_colaboradorid=b.codr_colaboradorid "
        consulta += " JOIN nomina.Puestos as C on a.labo_puestoid=c.pues_puestoid "
        consulta += " JOIN Framework.Grupos as D on D.grup_grupoid=c.pues_departamentoid "
        consulta += " JOIN nomina.ColaboradorReal as E on E.real_colaboradorid= A.labo_colaboradorid "
        consulta += " left JOIN nomina.SolicitudIncentivos as F on F.soin_colaboradorid= A.labo_colaboradorid "
        consulta += " left JOIN CajaAhorro.ColaboradorPeriodoCaja as G on G.ccpc_ColaboradorId= A.labo_colaboradorid "
        consulta += " left JOIN Prestamos.Prestamos as H on H.pres_colaboradorid= A.labo_colaboradorid"
        consulta += " left JOIN ControlAsistencia.CorteChecador as J on J.ccheck_colaborador= A.labo_colaboradorid "
        consulta += " left JOIN nomina.Deducciones as K on K.dedu_colaboradorid= A.labo_colaboradorid "
        consulta += " where(codr_colaboradorid =" + idColaborador.ToString + " )"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaColaboradoresNominaReal(ByVal idNave As Int32, ByVal contadorDestajos As Int32, ByVal idDepartamento As Int32, ByVal colaborador As String, ByVal tipoSalario As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = " select * from Nomina.ColaboradorLaboral as A "
        'consulta += "  JOIN Nomina.Colaborador as B on A.labo_colaboradorid=b.codr_colaboradorid "
        'consulta += "  JOIN nomina.Puestos as C on a.labo_puestoid=c.pues_puestoid "
        'consulta += "  JOIN Framework.Grupos as D on D.grup_grupoid=c.pues_departamentoid "
        'consulta += "  JOIN nomina.ColaboradorReal as E on E.real_colaboradorid= A.labo_colaboradorid "
        'consulta += "  JOIN nomina.ColaboradorNomina as M on M.cono_colaboradorid= A.labo_colaboradorid "
        'consulta += "  LEFT JOIN  nomina.Celulas as N on N.celu_celulaid= a.labo_celulaid"
        'consulta += " left join Nomina.Finiquitos F on f.fini_colaboradorid=B.codr_colaboradorid"
        'consulta += "  where(labo_naveid = " + idNave.ToString + ") "
        'consulta += "  and labo_reportes='True'"
        'consulta += "  and B.codr_activo= 1 "
        'consulta += "  and (codr_nombre+' '+codr_apellidopaterno+' '+codr_apellidomaterno) like '%" + colaborador.Replace(" ", "%") + "%'"
        'consulta += " and isnull(cono_externo,0) = 0 "
        'If idDepartamento > 0 Then
        '    consulta += " and labo_departamentoid= " + idDepartamento.ToString
        'End If
        'If tipoSalario <> "" Then
        '    consulta += " and E.real_tiposueldo='" + tipoSalario.ToString + "'"
        'End If
        ''consulta += "  ORDER BY f.fini_finiquitoid desc, e.real_fecha asc"
        'consulta += "  ORDER BY  e.real_fecha asc"
        ''If contadorDestajos = 0 Then
        ''End If               
        'Return objOperaciones.EjecutaConsulta(consulta)

        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idNave"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idDepartamento"
        parametro.Value = idDepartamento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colaborador"
        parametro.Value = colaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoSalario"
        parametro.Value = tipoSalario
        listaParametros.Add(parametro)


        Return objOperaciones.EjecutarConsultaSP("[Nomina].[SP_Nomina_ListaColaboradores]", listaParametros)
    End Function

    Public Function ListaColaboradoredDESTAJO(ByVal idNave As Int32, ByVal idArea As Int32, ByVal idDepartamento As Int32, ByVal colaborador As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "     select * from Nomina.ColaboradorLaboral as A "
        consulta += "  JOIN Nomina.Colaborador as B on A.labo_colaboradorid=b.codr_colaboradorid "
        consulta += "  JOIN nomina.Puestos as C on a.labo_puestoid=c.pues_puestoid "
        consulta += "  JOIN Framework.Grupos as D on D.grup_grupoid=c.pues_departamentoid "
        consulta += "  JOIN nomina.ColaboradorReal as E on E.real_colaboradorid= A.labo_colaboradorid "
        consulta += "  left JOIN CajaAhorro.ColaboradorPeriodoCaja as G on G.ccpc_ColaboradorId= A.labo_colaboradorid "
        consulta += "  left JOIN ControlAsistencia.CorteChecador as J on J.ccheck_colaborador= A.labo_colaboradorid "
        consulta += "  JOIN nomina.ColaboradorNomina as M on M.cono_colaboradorid= A.labo_colaboradorid "
        consulta += "  where(labo_naveid = " + idNave.ToString + ") "
        consulta += "  and real_tipo='DESTAJO' "
        consulta += "   and B.codr_activo= 1 "
        consulta += "  and (codr_nombre+' '+codr_apellidopaterno+' '+codr_apellidomaterno) like '%" + colaborador.Replace(" ", "%") + "%'"

        If idArea > 0 Then
            consulta += " and  labo_areaid= " + idArea.ToString
        End If
        If idDepartamento > 0 Then
            consulta += " and labo_departamentoid= " + idDepartamento.ToString
        End If
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function NominaDestajos(ByVal idColborador As Integer, ByVal PeriodoNominaID As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from nomina.CorteNominaReal "
        consulta += " where conr_colaboradorid= " + idColborador.ToString
        consulta += " and conr_periodonominaid= " + PeriodoNominaID.ToString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function Destajos(ByVal idColborador As Integer, ByVal PeriodoNominaID As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select  SUM (dest_montoticket) as dest_montoticket  from Nomina.destajos "
        consulta += " WHERE (dest_fecha between (Select pnom_FechaInicial from Nomina.PeriodosNomina where pnom_PeriodoNomId=" + PeriodoNominaID.ToString + ") "
        consulta += " and DATEADD(DAY,1,(Select pnom_fechafinal from Nomina.PeriodosNomina where pnom_PeriodoNomId=" + PeriodoNominaID.ToString + ")))"
        consulta += " and dest_colaboradorid=" + idColborador.ToString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function IMSSLimites(ByVal idNAve As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " select * from Nomina.DeduccionRealImss"
        consulta += " WHERE drim_naveid=" + idNAve.ToString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function CajaAhorro(ByVal idColborador As Integer, ByVal PeriodoNominaID As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from CajaAhorro.ColaboradorPeriodoCaja "
        consulta += " where ccpc_ColaboradorId= " + idColborador.ToString + " and ccpc_PeriodoId= " + PeriodoNominaID.ToString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function prestamos(ByVal idColborador As Integer, ByVal PeriodoNominaID As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Prestamos.Prestamos as A "
        consulta += " JOIN Prestamos.PagoPrestamos As B on A.pres_prestamoid=B.pagop_prestamoid "
        consulta += " where A.pres_colaboradorid= " + idColborador.ToString + " and B.pagop_semananominaid= " + PeriodoNominaID.ToString
        consulta += " and (B.pagop_dentronomina='A' or B.pagop_dentronomina='B')"

        'A= ABONO NORMAL
        'B=ABONO EXTRAORDINARIO DENTRO DE NOMINA
        'C= ABONO EXTRAORIDNARIO FUERA DE NOMINA
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function abonoExtraordinarioNominaReal(ByVal semanaNominaID As Int32, ByVal colaboradorID As Int32, ByVal naveID As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Prestamos.Prestamos as A "
        consulta += "   JOIN Nomina.Colaborador as c on A.pres_colaboradorid=c.codr_colaboradorid "
        consulta += " join nomina.ColaboradorLaboral as b on pres_colaboradorid= b.labo_colaboradorid "
        consulta += " join Prestamos.PagoPrestamos AS d on d.pagop_prestamoid=a.pres_prestamoid "
        consulta += " JOIN Nomina.ColaboradorReal as E on E.real_colaboradorid = A.pres_colaboradorid"
        consulta += " WHERE pagop_semananominaid=" + semanaNominaID.ToString
        consulta += " and C.codr_colaboradorid=" + colaboradorID.ToString
        consulta += " and C.codr_activo=1"
        consulta += " and labo_naveid =" + naveID.ToString
        consulta += " and pagop_dentronomina='B'"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function Gratificaciones(ByVal idColborador As Integer, ByVal estatus As String, ByVal fechainicio As DateTime, ByVal fechafinal As DateTime, ByVal periodoNominaID As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select soin_monto, moin_nombre ,soin_solicitudincentivoid, moin_diaadicional "
        consulta += " from Nomina.SolicitudIncentivos as A"
        consulta += " JOIN Nomina.MotivosIncentivos as B on B.moin_motivoincentivoid=A.soin_motivoincentivoid "
        consulta += " where soin_colaboradorid= " + idColborador.ToString
        consulta += " and soin_estado='" + estatus.ToString + "' "
        consulta += " and   A.soin_periodonominapagado=" + periodoNominaID.ToString
        '   consulta += " and (A.soin_fechacreacion BETWEEN '" + fechainicio.ToShortDateString + "' and '" + fechafinal.ToShortDateString + " 23:59:00')"
        ''consulta += "and B.moin_incluirnomina='True' "
        Return objOperaciones.EjecutaConsulta(consulta)

    End Function

    Public Function GratificacionesConfiguracion(ByVal idNave As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  Select * from nomina.ConfiguracionGratificaciones"
        consulta += " where confgrat_naveid=" + idNave.ToString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function GratificacionesNomina(ByVal idNave As Integer, ByVal colaboradorid As Integer, ByVal periodo As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        'If idNave <> 43 Then
        consulta = "  select sum(soin_monto) from Nomina.SolicitudIncentivos where soin_colaboradorid=" + colaboradorid.ToString + " and soin_estado='B' and soin_periodonominapagado=" + periodo.ToString
        'Else
        '    consulta = "select sum(soin_monto) from Nomina.SolicitudIncentivos as a join Nomina.MotivosIncentivos as b on a.soin_motivoincentivoid=b.moin_motivoincentivoid where soin_colaboradorid=" + colaboradorid.ToString + " and soin_estado='B' and soin_periodonominapagado=" + periodo.ToString + " and b.moin_diaadicional='true'"
        'End If
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function



    Public Function DeduccionesExtras(ByVal idColaborador As Integer, ByVal PeriodoNominaID As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " select * from nomina.DeduccionesExtraordinarias as A "
        consulta += " JOIN nomina.DeduccionesExtraordinariasPago  as B on B.pagodecx_deduccionid=A.decx_deduccionid "
        consulta += " where a.decx_colaboradorid= " + idColaborador.ToString
        consulta += " and b.pagodecx_semananominaid= " + PeriodoNominaID.ToString
        ' consulta += " AND A.decx_estatus='B'"
        consulta += " AND pagodecx_condonacion=0"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function


    Public Function DeduccionesFijas(ByVal idColborador As Integer, ByVal PeriodoNominaID As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " select * from nomina.Deducciones "
        consulta += " where dedu_periodonominaid= " + PeriodoNominaID.ToString + " and dedu_colaboradorid= " + idColborador.ToString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function CajaAhorroValidacion(ByVal idNave As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from CajaAhorro.CajaAhorro "
        consulta += "where caja_NaveId=" + idNave.ToString
        consulta += " and caja_estado='A'"
        consulta += " AND '" + FechaInicio.ToShortDateString + "' BETWEEN caja_FechaInicial and caja_FechaFinal"
        consulta += " AND '" + FechaFin.ToShortDateString + "' BETWEEN caja_FechaInicial and caja_FechaFinal"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function Percepciones(ByVal idColborador As Integer, ByVal PeriodoNominaID As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  select * from nomina.Percepciones  "
        consulta += " where perc_colaboradorid= " + idColborador.ToString + " and perc_periodonominaid= " + PeriodoNominaID.ToString

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function PercepcionesDeducciones(ByVal idColborador As Integer, ByVal PeriodoNominaID As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "    select * from nomina.Percepciones as A  "
        consulta += " LEFT JOIN nomina.Deducciones as B on A.perc_colaboradorid= B.dedu_colaboradorid "
        consulta += " left join Nomina.CorteNominaReal as C on conr_colaboradorid=a.perc_colaboradorid "
        consulta += " where B.dedu_colaboradorid= " + idColborador.ToString + " and A.perc_periodonominaid= " + PeriodoNominaID.ToString

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function CorteChecador(ByVal idColborador As Integer, ByVal PeriodoNominaID As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " select * from ControlAsistencia.CorteChecador "
        consulta += " where ccheck_colaborador= " + idColborador.ToString + " and ccheck_periodo_id= " + PeriodoNominaID.ToString

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function CorteChecadorFaltasUltimoMes(ByVal idColborador As Integer, ByVal fechaInicio As DateTime, ByVal fechafin As DateTime) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " select * from ControlAsistencia.CorteChecador "
        consulta += " where ccheck_fecha_creo >= '" + fechaInicio.ToShortDateString + "' and ccheck_fecha_creo <= '" + fechafin.ToShortDateString + "'"
        consulta += "and ccheck_colaborador=" + idColborador.ToString

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function HorasExtra(ByVal idColborador As Integer, ByVal PeriodoNominaID As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "   select SUM (phex_monto) as phex_monto "
        consulta += " from controlasistencia.cortehorasextra "
        consulta += " where phex_colaboradorid= " + idColborador.ToString + " and phex_periodonominaid= " + PeriodoNominaID.ToString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function configuracionColaboradorNomina(ByVal colaboradorId As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = "select * from Nomina.ColaboradorNomina join Nomina.Patrones on cono_patronid=patr_patronid where cono_colaboradorid=" + colaboradorId.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function PorBantaTotalLotes(ByVal colaboradorId As Integer, ByVal idnave As Integer, ByVal idcelula As Integer, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime, ByVal anio As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        'Select SUM(pares) as pares from lotesAvances as a where IdCelula=" + idcelula.ToString + " and Estado='C'"
        '       consulta += " and a.FechaAvance between '" + fechainicial + "' and '" + fechafinal + "'"
        '       consulta += "and Nave=" + idnave.ToString
        consulta += " Select SUM(a.pares) as pares from lotesAvances as a"
        consulta += " join lotes as b on a.Lote=b.Lote and a.Año=b.Año and a.Nave=b.Nave"
        consulta += " where IdCelula=" + idcelula.ToString
        consulta += " and Estado='C'"
        consulta += " and b.Fecha_Salida between '" + fechainicial.ToShortDateString + " 00:01' and '" + fechafinal.ToShortDateString + " 23:59'"
        consulta += " and a.Nave=" + idnave.ToString
        ''+ " and Año=" + anio.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function


    Public Function PorcentajeAsistencia(ByVal idNave As Integer, ByVal Rango As Integer, ByVal Resultado As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " select * from ControlAsistencia.ConfiguracionAsistencia "

        If Rango = 0 Then
            consulta += " where confasis_naveid= " + idNave.ToString
            consulta += " and confasis_rango= " + Rango.ToString
            ' consulta += " and confasis_resultado= " + Resultado.ToString
        ElseIf Rango > 0 And Resultado > 1 Then
            consulta += " where confasis_naveid= " + idNave.ToString
            consulta += " and confasis_rango>= " + Rango.ToString
            consulta += " and confasis_resultado= " + Resultado.ToString
        End If
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub GuardarDeduccionesPreNomina(ByVal nomina As Entidades.CalcularNominaReal)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "dedu_concepto"
        parametro.Value = nomina.PDeduccionExtraordinaria.PConceptoDeduccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dedu_cantidad"
        parametro.Value = nomina.PDeduccionExtraordinaria.PMontoDeduccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dedu_colaboradorid"
        parametro.Value = nomina.PColaborador.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dedu_periodonominaid"
        parametro.Value = nomina.PCobranza.PsemanaNominaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dedu_fechacreacion"
        parametro.Value = nomina.PCobranza.PfechaFinNomina
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dedu_usuariocreoid"
        parametro.Value = nomina.PPrestamos.Pusuariocreoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dedu_tipo"
        parametro.Value = nomina.PDeduccionExtraordinaria.PDeduccionTipo
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.GuardarPreNomina", listaParametros)
    End Sub

    Public Function consultaFiniquitosActivos(ByVal colaboradorId As Integer, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from nomina.Finiquitos "
        consulta += " where fini_colaboradorid =" + colaboradorId.ToString
        'consulta += " and (fini_fechasolicitud Between '" + fechainicial.ToShortDateString + "'" + "and '" + fechafinal.ToShortDateString + "')"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function


    Public Function colaboradorLaboralFiscal(ByVal colaboradorID As Integer) As DataTable
        Dim ObjOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "SELECT * FROM NOmina.ColaboradorNomina "
        consulta += "where cono_colaboradorid=" + colaboradorID.ToString
        Return ObjOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function FactorIntegracion(ByVal Anios As Integer) As DataTable
        Dim ObjOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = " select * from Nomina.FactoresIntegracion"
        consulta += " where fact_anios=" + Anios.ToString
        Return ObjOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function LimiteInferior(ByVal totalGravado As Double) As DataTable
        Dim ObjOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = " select * from nomina.RangosImpuestoSubsidioEmpleo"
        consulta += " where " + totalGravado.ToString.Replace(",", ".")
        consulta += " BETWEEN rise_limiteinferior and rise_limitesuperior"
        Return ObjOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function SubsidioEmpleo(ByVal TotalGravado As Double) As DataTable
        Dim ObjOperaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String
        Consulta = " select top (1) * from nomina.RangoSubsidioEmpleo"
        Consulta += " WHERE rase_limiteinferior <=" + TotalGravado.ToString.Replace(",", ".")
        Consulta += " order by rase_limiteinferior  desc"
        Return ObjOperaciones.EjecutaConsulta(Consulta)
    End Function

    Public Function configuracionFiscal() As DataTable
        Dim ObjOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "Select * from nomina.ConfiguracionFiscalNomina"
        Return ObjOperaciones.EjecutaConsulta(consulta)
    End Function


    Public Function salarioCierreDestajo(ByVal colaboradorID As Integer, ByVal periodoNominaID As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        consulta = " SELECT * FROM Nomina.CierreDestajos"
        consulta += " where dest_periodonominaid=" + periodoNominaID.ToString
        consulta += " and dest_colaboradorid=" + colaboradorID.ToString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function validarDestajos(ByVal naveID As Integer, ByVal periodoNomina As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT *"
        consulta += " FROM Nomina.ColaboradorReal AS A"
        consulta += " JOIN Nomina.Colaborador AS B"
        consulta += " ON B.codr_colaboradorid = A.real_colaboradorid"
        consulta += " join Nomina.ColaboradorLaboral as C on C.labo_colaboradorid=B.codr_colaboradorid"
        consulta += " WHERE real_tipo = 'DESTAJO'"
        consulta += " AND B.codr_activo = 1"
        consulta += " and C.labo_naveid=" + naveID.ToString

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function calculoNetoBanda(ByVal colaboradorID As Integer, ByVal periodoID As Integer, ByVal celulaID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@colaboradorid"
        parametro.Value = colaboradorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periodoid"
        parametro.Value = periodoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@celulaid"
        parametro.Value = celulaID
        listaParametros.Add(parametro)
        Return operaciones.EjecutarConsultaSP("Nomina.sp_calculanetobanda", listaParametros)
    End Function

    Public Function configuracionNomina(ByVal naveID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        'Dim consulta As String = ""
        'consulta += " SELECT * FROM nomina.ConfiguracionNaveNomina"
        'consulta += " where conf_naveid =" + naveID.ToString

        '250520191259 Se obtiene la configuración de los registros de checadas por nave
        'consulta += " SELECT conf_gratificacionpuntualidad, conf_pagoSeptimoDia, "
        'consulta += " ISNULL(n.nave_generarRegistroNoCheca,0) nave_generarRegistroNoCheca"
        'consulta += " FROM Nomina.ConfiguracionNaveNomina cnv "
        'consulta += " LEFT JOIN Framework.Naves n ON cnv.conf_naveid = n.nave_naveid "
        'consulta += " where conf_naveid =" + naveID.ToString
        'Return operaciones.EjecutaConsulta(consulta)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = naveID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Nomina.SP_ObtenerConfiguracionNaveNomina", listaParametros)

    End Function

    Public Function montoISR(ByVal colaboradorID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT cono_isrmonto FROM Nomina.ColaboradorNomina	"
        consulta += " where cono_colaboradorid =" + colaboradorID.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function validaInicioMes(ByVal periodoId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta &= "SELECT Nomina.FNValidaInicioMes(" & periodoId & ") AS Resultado"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function reiniciaAcumuladoColaborador(ByVal naveId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "naveId"
        parametro.Value = naveId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ReiniciaAcumuladoColaborador]", listaParametros)
    End Function

    Public Function sumaAcumuladoMensualColaborador(ByVal colaboradorId As Integer, ByVal monto As Double) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "monto"
        parametro.Value = monto
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_SumaAcumuladoMensualColaborador]", listaParametros)
    End Function

    Public Function validacambioTipoPagoAplicado(ByVal periodoId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "periodonominaId"
        parametro.Value = periodoId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ConsultaCambioTipoPagoAplicado]", listaParametros)
    End Function

    Public Function CambiaTipoSueldoColaboradores(ByVal naveid As Integer, ByVal periodonominaid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "naveId"
        parametro.Value = naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "periodonominaid"
        parametro.Value = periodonominaid
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_CambiaTipoSueldoColaboradores]", listaParametros)
    End Function

    Public Function ConsultaTotalNominaFiscal(ByVal periodonominaid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "idPeriodoReal"
        parametro.Value = periodonominaid
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Nomina.SP_ConsultaTotalNominaFiscal", listaParametros)
    End Function

    Public Function ConsultaColaboradorIncapacidad(ByVal NaveId As Integer, ByVal PeriodoNominaId As Integer) As List(Of Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim dtResultado As New DataTable()
        Dim lstResultado As New List(Of Integer)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = NaveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PeriodoNominaId"
        parametro.Value = PeriodoNominaId
        listaParametros.Add(parametro)

        dtResultado = operaciones.EjecutarConsultaSP("Nomina.SP_ObtenerColaboradores_Incapacidad", listaParametros)

        For Each row As DataRow In dtResultado.Rows
            lstResultado.Add(row.Item(0))
        Next

        Return lstResultado

    End Function

    Public Function obtenerSemanaCerradaDA(ByVal periodoId As Integer) As DataTable
        'Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = String.Empty

        'consulta = "select pnom_stPeriodoNomina, pnom_PeriodoNomId, pnom_Concepto from Nomina.PeriodosNomina where pnom_PeriodoNomId =" & periodoId
        'Return operaciones.EjecutaConsulta(consulta)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "PeriodoId"
        parametro.Value = periodoId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ConsultaSemanaNominaCerrada]", listaParametros)
    End Function

    Public Function calcularNominaRealDA(ByVal periodoID As Integer, ByVal NaveID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro = New SqlParameter
        parametro.ParameterName = "@periodoId"
        parametro.Value = periodoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveId"
        parametro.Value = NaveID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Nomina.SP_CalculaNominaReal_170322", listaParametros)
    End Function

    Public Function consultarNominaRealDA(ByVal periodoID As Integer, ByVal colaborador As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro = New SqlParameter
        parametro.ParameterName = "@PeriodoId"
        parametro.Value = periodoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colaborador"
        parametro.Value = colaborador
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Nomina.SP_ConsultaNominaReal", listaParametros)
    End Function

    Public Function ConsultaSemanaNominaDA(ByVal naveId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "naveId"
        parametro.Value = naveId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ConsultaSemanaNominaActiva]", listaParametros)
    End Function

    Public Function ConsultaIncapacidades(ByVal colaboradorid As Integer, ByVal periodonominaid As Integer, ByVal tipoconsulta As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = colaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "periodoId"
        parametro.Value = periodonominaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoConsulta"
        parametro.Value = tipoconsulta
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Nomina.SP_ConsultaIncapacidadColaborador", listaParametros)
    End Function

    Public Function obtieneDescuentosFiscalesDA(ByVal colaboradorId As Integer, ByVal periodonominaid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "periodoId"
        parametro.Value = periodonominaid
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Nomina.SP_obtieneDescuentosFiscales", listaParametros)
    End Function

    Public Function obtenerDatosReporteGeneralNomina(ByVal PeriodoNominaID As Integer, ByVal Colaborador As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@PeriodoId", PeriodoNominaID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Colaborador", Colaborador)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ConsultaNominaRealAnteriores]", listaParametros)

    End Function

    Public Function ObtieneRevisaReporte(ByVal NaveID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)


        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ObtienePersona_RevisaReporteNomina]", listaParametros)


    End Function

End Class