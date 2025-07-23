Imports Persistencia
Imports System.Data.SqlClient

Public Class ControlAsistenciaDA

    Public Function buscarRegistrosPeriodo(naveID As Integer, areaID As Integer, PeriodoNomID As Integer, departamentoID As Integer, celulaID As Integer, colaboradorID As Integer, nombreColaborador As String, bandera As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        '@PeriodoNomID AS INTEGER,
        '@departamentoID AS INTEGER,
        '@colaboradorID AS INTEGER

        Dim parametro As New SqlParameter
        parametro.ParameterName = "PeriodoNomID"
        parametro.Value = PeriodoNomID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "naveID"
        parametro.Value = naveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "areaID"
        parametro.Value = areaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "departamentoID"
        parametro.Value = departamentoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "celulaID"
        parametro.Value = celulaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorID"
        parametro.Value = colaboradorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombreColaborador"
        parametro.Value = nombreColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("ControlAsistencia.SP_Consulta_Registro_Check", listaParametros)

    End Function

    Public Function tiene_finiquito(colaboradorID As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " SELECT fini_finiquitoid FROM Nomina.Finiquitos WHERE fini_colaboradorid = " + colaboradorID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListadoParametroUbicacion(tipo_busqueda As Integer, id_parametros As String) As DataTable

        Dim operaciones_sicy As New Persistencia.OperacionesProcedimientosSICY
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        If tipo_busqueda = 6 Then
            consulta += " SELECT " +
                "   A.codr_colaboradorid AS 'Parámetro' " +
                " , CAST (0 AS bit) AS ' ' " +
                " , CAST(A.codr_nombre + ' ' + A.codr_apellidopaterno + ' ' + A.codr_apellidomaterno AS varchar(200)) AS 'Colaborador' " +
                " , C.grup_name AS 'Departamento' " +
                " , D.pues_nombre AS 'Puesto' " +
                " FROM [Nomina].[Colaborador] AS A " +
                " JOIN [Nomina].[ColaboradorLaboral] AS B ON B.labo_colaboradorid = A.codr_colaboradorid " +
                " JOIN [Framework].[Grupos] AS C ON C.grup_grupoid = B.labo_departamentoid " +
                " JOIN [Nomina].[Puestos] AS D ON D.pues_puestoid = B.labo_puestoid " +
                " WHERE A.codr_activo = 1 AND B.labo_checa = 1 AND B.labo_naveid = " + id_parametros + " ORDER BY A.codr_nombre "
        End If

        If tipo_busqueda = 6 Then
            Return operaciones.EjecutaConsulta(consulta)
        Else
            Return operaciones_sicy.EjecutaConsulta(consulta)
        End If


    End Function

    Public Function Resumen_Incidencias(lista_colaboradores As String, fecha_inicio As DateTime, fecha_termino As DateTime) As DataTable

        Dim operaciones_sicy As New Persistencia.OperacionesProcedimientosSICY
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        ''comentado la consulta ahora se obtiene de un procedimiento
        'consulta += " SELECT " +
        '            " 	CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS varchar(200)) AS 'Colaborador'  " +
        '            " 	,g.grup_name as 'Departamento',p.pues_nombre as 'Puesto'" +
        '            " 	,(select COUNT(DISTINCT regcheck_id) from ControlAsistencia.RegistroCheck WHERE regcheck_resultado=2 and" +
        '            " 	(regcheck_normal BETWEEN  CAST(' " + fecha_inicio.ToShortDateString + " 00:00' as datetime) and CAST(' " + fecha_termino.ToShortDateString + " 23:59' as datetime)" +
        '            " 	or regcheck_automatico BETWEEN CAST(' " + fecha_inicio.ToShortDateString + " 00:00' as datetime) and CAST('  " + fecha_termino.ToShortDateString + " 23:59' as datetime)" +
        '            " 	or regcheck_manual BETWEEN CAST(' " + fecha_inicio.ToShortDateString + " 00:00' as datetime) and CAST('  " + fecha_termino.ToShortDateString + " 23:59' as datetime) ) and regcheck_colaborador = c.codr_colaboradorid) AS 'Retardos Menores'" +
        '            "   , (select COUNT(DISTINCT regcheck_id) from ControlAsistencia.RegistroCheck where regcheck_colaborador=c.codr_colaboradorid and " +
        '            " 	(regcheck_normal BETWEEN CAST(' " + fecha_inicio.ToShortDateString + " 00:00' as datetime) and CAST(' " + fecha_termino.ToShortDateString + " 23:59' as datetime )" +
        '            " 	or regcheck_automatico BETWEEN CAST(' " + fecha_inicio.ToShortDateString + "' as datetime) and CAST('  " + fecha_termino.ToShortDateString + " 23:59'  as datetime)" +
        '            " 	or regcheck_manual BETWEEN CAST(' " + fecha_inicio.ToShortDateString + " 00:00' as datetime) and CAST('  " + fecha_termino.ToShortDateString + " 23:59' as datetime)) and regcheck_resultado=3) AS 'Retardos Mayores'" +
        '            "   ,(SELECT Nomina.fn_ObtenerNumeroFaltas('" + fecha_inicio.ToShortDateString + " 00:00','" + fecha_termino.ToShortDateString + " 23:59',c.codr_colaboradorid)) AS 'Inasistencias'" +
        '            "   FROM  Nomina.Colaborador c " +
        '            " INNER JOIN Nomina.ColaboradorLaboral cl on cl.labo_colaboradorid=c.codr_colaboradorid" +
        '            " INNER JOIN Framework.Grupos g on g.grup_grupoid=cl.labo_departamentoid " +
        '            " INNER JOIN Nomina.Puestos p on p.pues_puestoid=cl.labo_puestoid " +
        '            " WHERE "
        'If Not String.IsNullOrEmpty(lista_colaboradores) Then
        '    consulta += " c.codr_colaboradorid IN (" + lista_colaboradores + ") "
        'End If

        'Return operaciones.EjecutaConsulta(consulta)

        parametros.ParameterName = "@listaColaboradores"
        parametros.Value = lista_colaboradores
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "@fechaInicio"
        parametros.Value = fecha_inicio.ToShortDateString
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "@fechaFin"
        parametros.Value = fecha_termino.ToShortDateString
        listaParametros.Add(parametros)

        Return operaciones.EjecutarConsultaSP("[ControlAsistencia].[SP_ConsultaReporteAsistencia]", listaParametros)

    End Function

    ''consultas nuevo control de asistencia
    Public Function cargarConsultaRegistros(ByVal idNave As Int32, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal condiciones As String) As DataTable
        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        parametros.ParameterName = "@nave"
        parametros.Value = idNave.ToString
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "@fechaInicio"
        parametros.Value = fechaInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "@fechaFin"
        parametros.Value = fechaFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "@condiciones"
        parametros.Value = condiciones
        listaParametros.Add(parametros)

        Return objPersistencia.EjecutarConsultaSP("[ControlAsistencia].[SP_Consulta_Control_Asistencia]", listaParametros)
    End Function

    Public Function BuscarIncentivosPermisos(ByVal idRegistro As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = " SELECT re.regexc_puntualidad_asistencia as puntualidad, re.regexc_caja_ahorro as caja FROM ControlAsistencia.RegistroExcepcion re"
        consulta += " inner JOIN ControlAsistencia.RegistroCheck rc on re.regexc_id=rc.regcheck_excepcion_id"
        consulta += " WHERE rc.regcheck_id= " + idRegistro.ToString
        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function obtenerPuestoColaborador(ByVal idColaborador As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        consulta = "SELECT pues_nombre FROM Nomina.Puestos p INNER JOIN Nomina.ColaboradorLaboral cl  on p.pues_puestoid=cl.labo_puestoid WHERE cl.labo_colaboradorid= " + idColaborador.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function colaboradorListaAsistencia(ByVal condiciones As String) As DataTable
        'Dim op As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = ""
        'consulta = " SELECT  (c.codr_nombre + ' ' + c.codr_apellidopaterno + ' ' + c.codr_apellidomaterno ) colaborador, p.pues_nombre puesto FROM Nomina.Colaborador c"
        'consulta += "  INNER JOIN Nomina.ColaboradorLaboral cl on cl.labo_colaboradorid=c.codr_colaboradorid"
        'consulta += "  INNER JOIN Nomina.ColaboradorNomina cn on cn.cono_colaboradorid=c.codr_colaboradorid"
        'consulta += "  INNER JOIN Nomina.Puestos p on p.pues_puestoid=cl.labo_puestoid "
        'consulta += " INNER JOIN Nomina.ColaboradorReal cr on cr.real_colaboradorid=c.codr_colaboradorid"
        'consulta += " LEFT JOIN Nomina.Celulas ce on ce.celu_celulaid=cl.labo_celulaid"
        'consulta += " WHERE c.codr_activo=1 AND cono_externo=0 AND c.codr_colaboradorid NOT IN (SELECT f.fini_colaboradorid FROM Nomina.Finiquitos f WHERE f.fini_colaboradorid= c.codr_colaboradorid)" + condiciones.ToString
        'consulta += " ORDER BY cr.real_fecha"
        'Return op.EjecutaConsulta(consulta)

        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        parametros.ParameterName = "@condiciones"
        parametros.Value = condiciones
        listaParametros.Add(parametros)

        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_ControlAsistencia_ListaAsistencia]", listaParametros)

    End Function

    'Yazmin Rocha (21/04/2016) No colocar "No registro", segun el horario establecido al colaborador
    Public Function buscarHorarioSabado(colaborador As Integer, dia As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " select hd.dh_hora_check, hd.dh_inicio_bloque from Nomina.ColaboradorLaboral cl"
        consulta += " left join Nomina.Horarios h on cl.labo_horarioid=h.hora_horarioid"
        consulta += " left join ControlAsistencia.DetalleHorario hd on h.hora_horarioid=hd.dh_horarioid"
        consulta += " where labo_colaboradorid = " + colaborador.ToString + " And hd.dh_dia = " + dia.ToString + " And hd.dh_check = 1"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function obtenerColaboradorExternoListaAsistencia(ByVal IdNave As String, PeriodoNomina As Integer) As DataTable
        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        parametros.ParameterName = "@idNave"
        parametros.Value = IdNave
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "@PeriodoNomina"
        parametros.Value = PeriodoNomina
        listaParametros.Add(parametros)

        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_ControlAsistencia_ConsultaChecadasPersonalAndrea]", listaParametros)

    End Function

    Public Function InsertarDatosImportadosXml(ByVal aXmlRegistros As String, ByVal naveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoGuardado As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "XMLRegistros"
        parametro.Value = aXmlRegistros
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "naveID"
        parametro.Value = naveID
        listaParametros.Add(parametro)


        dtResultadoGuardado = objPersistencia.EjecutarConsultaSP("[Nomina].[SP_InsertaRegistroAsistencia_Importados]", listaParametros)

        Return dtResultadoGuardado

    End Function

    Public Function InsertarDatosImportadosXmlFormatoNuevo(ByVal aXmlRegistros As String, ByVal naveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "XMLRegistros"
        parametro.Value = aXmlRegistros
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "naveID"
        parametro.Value = naveID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_InsertaRegistroAsistencia_Importados_FormatoNuevo]", listaParametros)

    End Function

    Public Function generaFaltaAsistencia(ByVal registroId As Integer, ByVal periodoId As Integer, ByVal colaboradorId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "registroId"
        parametro.Value = registroId
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "periodoId"
        parametro.Value = periodoId
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = colaboradorId
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        lstParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("ControlAsistencia.SP_NominaReal_GeneraFaltaRegistro", lstParametros)
    End Function

    Public Function validaGeneraRegistroNoCheca(ByVal naveId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "naveId"
        parametro.Value = naveId
        lstParametros.add(parametro)

        Return operaciones.EjecutarConsultaSP("ControlAsistencia.validaGeneraRegistroNoCheca", lstParametros)
    End Function

    Public Function validaCierreAsistenciaNR(ByVal periodoId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "periodo_id"
        parametro.Value = periodoId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[ControlAsistencia].[SP_NominaReal_ValidaCierreChecador]", listaParametros)
    End Function

    Public Function ObtieneListaColaboradoresSinIncentivos(ByVal PeriodoID As Integer, ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        parametro = New SqlParameter("@PeriodoID", PeriodoID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[ControlAsistencia].[SP_ObtieneLista_ColaboradoresSinIncentivos]", listaParametros)

    End Function

    Public Function ModificaCorteIncentivos(ByVal PeriodoID As Integer, ByVal ColaboradorID As Integer, ByVal CalculoFaltasNuevo As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        parametro = New SqlParameter("@PeriodoID", PeriodoID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ColaboradorID", ColaboradorID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@CalculoFaltasNuevo", CalculoFaltasNuevo)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[ControlAsistencia].[SP_Modificar_CorteChecadorIncentivos]", listaParametros)
    End Function

    Public Function ReplicarCoralboradoresChecador()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@navereplicaid"
        parametro.Value = 43
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_ReplicaTablasColaborador_v4]", listaParametros)
    End Function

    Public Function ActualizarRegistrosChecador(ByVal NaveID As Integer, ByVal fechainicial As Date, ByVal fechafinal As Date)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveID"
        parametro.Value = NaveID
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@fechainicial", fechainicial)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@fechafinal", fechafinal)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_InsertaRegistroAsistencia_Importados_ChecadorHuellaPorNave_151_fechas]", listaParametros)
    End Function

End Class
