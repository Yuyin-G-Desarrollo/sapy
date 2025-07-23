Imports System.Data.SqlClient

Public Class CalcularPrimaVacacionalDA


    Public Function ExistePrimaVacacionalNave(ByVal idNave As Integer, ByVal Año As Integer) As Boolean
        Dim objoperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        Dim Existe As Integer = 0

        consulta = "SELECT COUNT(*) "
        consulta += "from Nomina.Vacaciones "
        consulta += "where prim_naveid ='" + idNave.ToString() + "' "
        consulta += "and prim_anio ='" + Año.ToString() + "' "


        Existe = objoperaciones.EjecutaConsultaEscalar(consulta)

        If Existe = 0 Then
            Return False
        Else
            Return True
        End If

    End Function



    Public Function ListaPrimaVacacional(ByVal idNave As Integer) As DataTable
        Dim objoperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT * FROM nomina.Vacaciones as A "
        consulta += " join Nomina.ColaboradorLaboral as B on B.labo_colaboradorid= A.prim_colaboradorid  "
        consulta += " where B.labo_naveid= " + idNave.ToString
        consulta += " order by (a.prim_anio) asc "

        Return objoperaciones.EjecutaConsulta(consulta)

    End Function



    Public Function ListaColaboradoresPrimaVacacional(ByVal idNave As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        ''Dim consulta As String = "    select * from  nomina.colaborador as A  "
        ''consulta += " JOIN nomina.ColaboradorReal as B on B.real_colaboradorid=a.codr_colaboradorid "
        ''consulta += " inner join Nomina.ColaboradorLaboral as C on A.codr_colaboradorid= C.labo_colaboradorid  "
        ''consulta += " where(c.labo_naveid = " + idNave.ToString + ") "
        ''consulta += " and labo_reportes='True'"
        ''consulta += " and A.codr_activo = 'True'"
        ''consulta += " ORDER BY b.real_fecha"
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

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Nomina].[SP_CalculoVacaciones_ListaColaboradores]", listaParametros)
    End Function


    Public Function ListaPrimaGUARDADOS(ByVal idNave As Integer, ByVal anio As Integer, ByVal colaborador As String) As DataTable
        'Dim objoperaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = "SELECT * FROM nomina.vacaciones as A  "
        'consulta += " join Nomina.ColaboradorLaboral as B on B.labo_colaboradorid= A.prim_colaboradorid  "
        'consulta += " join Nomina.colaborador as C on C.codr_colaboradorid=B.labo_colaboradorid  "
        'consulta += " join nomina.ColaboradorReal as D on A.prim_colaboradorid= D.real_colaboradorid"
        'consulta += " where  A.prim_anio=" + anio.ToString
        'consulta += " and a.prim_naveid = " + idNave.ToString() + " "
        'consulta += " and (codr_nombre+' '+codr_apellidopaterno+' '+codr_apellidomaterno) like '%" + colaborador.Replace(" ", "%") + "%'"
        'consulta += " ORDER BY  D.real_fecha asc"

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

        Return ObjPersistencia.EjecutarConsultaSP("[Nomina].[SP_Obtiene_ListaVacacionesGuardados]", listaParametros)

    End Function

    Public Function ListaDiasVacacionesXAnios(ByVal Anios As Integer) As DataTable
        Dim objoperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  select * from nomina.FactoresIntegracion "
        consulta += " where fact_anios =" + Anios.ToString

        Return objoperaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListaDiasVacacionesXAniosMeses(ByVal Anios As Integer, ByVal meses As Integer) As DataTable
        Dim objoperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from nomina.diasvacaciones where diva_anios=" + Anios.ToString + " and diva_meses=" + meses.ToString
        Return objoperaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub guardarPrima(ByVal Prima As Entidades.CalcularPrimaVacacional, ByVal naveid As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "prim_colaboradorid"
        parametro.Value = Prima.PColaborador.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prim_anio"
        parametro.Value = Prima.PPrimaVacacionalAnio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prim_meses"
        parametro.Value = Prima.PPrimaVacacionalMeses
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prim_sueldodiario"
        parametro.Value = Prima.PSueldoDiario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prim_diasxpagar"
        parametro.Value = Prima.PDiasxPagar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prim_subtotal"
        parametro.Value = Prima.PPrimaSubtotal
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "prim_primavacacional"
        parametro.Value = Prima.PPrimaPrimaVacacional
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prim_totalentregar"
        parametro.Value = Prima.PPrimaTotalEntregar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prim_usuariocreoid"
        parametro.Value = Prima.PPrimaUsuarioCreo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prim_naveid"
        parametro.Value = naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "prim_periodovacaciones"
        parametro.Value = Prima.PPeriodoVacaciones
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_Altas_PrimaVacacional_V2", listaParametros)

    End Sub

    Public Function fechasSueldos(ByVal naveID As Integer, ByVal anio As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        'Dim consulta As String = ""
        ''consulta += "SELECT top 4	CONVERT(date, pnom_FechaInicial,103) as 'FechaInicial',"
        ''consulta += " CONVERT(date, pnom_FechaFinal,103) as 'FechaFinal'"
        ''consulta += " FROM Nomina.PeriodosNomina"
        ''consulta += " WHERE pnom_FechaInicial BETWEEN '01-11-2014' AND '30-11-2014 23:59:59'"
        ''consulta += " and pnom_NaveId=" + naveID.ToString

        'consulta += "SELECT top 4	CONVERT(date, pnom_FechaInicial,103) as 'FechaInicial',"
        'consulta += " CONVERT(date, pnom_FechaFinal,103) as 'FechaFinal'"
        'consulta += " FROM Nomina.PeriodosNomina"
        'consulta += " where pnom_NaveId=" + naveID.ToString
        'consulta += " AND pnom_NoSemanaNomina in(49, 48, 47, 46) and  YEAR(pnom_FechaInicial)=" + anio.ToString + ""
        'consulta += " order by pnom_FechaInicial DESC"
        'Return objOperaciones.EjecutaConsulta(consulta)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = naveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Nomina].[SP_Aguinaldos_fechasSueldos]", listaParametros)
    End Function

    Public Function fechasSueldosVacaciones(ByVal naveID As Integer, ByVal anio As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        'Dim consulta As String = ""
        ''consulta += "SELECT top 4	CONVERT(date, pnom_FechaInicial,103) as 'FechaInicial',"
        ''consulta += " CONVERT(date, pnom_FechaFinal,103) as 'FechaFinal'"
        ''consulta += " FROM Nomina.PeriodosNomina"
        ''consulta += " WHERE pnom_FechaInicial BETWEEN '01-11-2014' AND '30-11-2014 23:59:59'"
        ''consulta += " and pnom_NaveId=" + naveID.ToString

        'consulta += "SELECT top 4	CONVERT(date, pnom_FechaInicial,103) as 'FechaInicial',"
        'consulta += " CONVERT(date, pnom_FechaFinal,103) as 'FechaFinal'"
        'consulta += " FROM Nomina.PeriodosNomina"
        'consulta += " where pnom_NaveId=" + naveID.ToString
        'consulta += " AND pnom_NoSemanaNomina in(49, 48, 47, 46) and  YEAR(pnom_FechaInicial)=" + anio.ToString + ""
        'consulta += " order by pnom_FechaInicial DESC"
        'Return objOperaciones.EjecutaConsulta(consulta)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = naveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Nomina].[SP_Aguinaldos_fechasSueldosVacaciones]", listaParametros)
    End Function
    Public Function logoNave(ByVal naveID As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT isnull(nave_logotipourl,'') as 'RUTA' FROM Framework.Naves"
        consulta += " where nave_naveid = " + naveID.ToString
        consulta += " And nave_activo = 1"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function


    Public Function obtenerFechaInicioSemanaSanta(ByVal naveID As Integer, ByVal anio As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = naveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Nomina].[SP_Vacaciones_ObtenerFechaSemanaSanta]", listaParametros)
    End Function

    Public Function obtenerSemanasSueldoVacaciones(ByVal naveID As Integer, ByVal anio As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = naveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Nomina].[SP_Vacaciones_ObtenerSemanasSueldoVacaciones]", listaParametros)
    End Function

    Public Function obtenerInfoReporteVacaciones(ByVal naveID As Integer, ByVal anio As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = naveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Nomina].[SP_ObtieneDatos_Vacaciones_Periodos]", listaParametros)
    End Function

    Public Function ListaSalariosColaboradorVacacionesGuardadas(ByVal idColaborador As Integer, ByVal anio As Integer, ByVal naveid As Integer) As DataTable

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

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ListaSalariosColaborador_Aguinaldo_Vacaciones_PeriodosGuardado]", listaparametros)

    End Function

    Public Function obtenerInfoReporteVacacionesCartaFinal(ByVal naveID As Integer, ByVal anio As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = naveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Nomina].[SP_ObtieneDatos_Vacaciones_Periodos_CartaFinal]", listaParametros)
    End Function

    Public Function obtenerInfoFiscalVacaciones(ByVal anio As Integer, ByVal colaborador As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        parametro.ParameterName = "@anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colaborador"
        parametro.Value = colaborador
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Nomina].[SP_ObtieneDatosFiscales_CalculoVacaciones]", listaParametros)
    End Function

End Class
