Imports System.Data.SqlClient


Public Class FiniquitosDA

    Public Sub AceptarSolicitudFiniquito(ByVal IdSolicitud As Int32, ByVal idAprobo As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = "UPDATE Nomina.Finiquitos SET fini_estado='B', fini_usuarioautorizoid=" + idAprobo.ToString + ", fini_fechaautorizacion= GETDATE() WHERE fini_finiquitoid = " + IdSolicitud.ToString
        'operaciones.EjecutaConsulta(consulta)
        Dim ListaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@IdSolicitud"
        parametro.Value = IdSolicitud
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idAprobo"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("[Nomina].[SP_AceptarSolicitudFiniquito]", ListaParametros)

    End Sub
    Public Sub EntregoFiniquito(ByVal IdSolicitud As Int32, ByVal idAprobo As Int32, ByVal fechaEntrega As Date)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = "update Nomina.Finiquitos set fini_estado='G', fini_usuarioautorizoid=" + idAprobo.ToString + ", fini_fechaentregado = '" + fechaEntrega.ToShortDateString + "' where fini_finiquitoid = " + IdSolicitud.ToString
        'operaciones.EjecutaConsulta(consulta)
        Dim ListaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@finiquitoid"
        parametro.Value = IdSolicitud
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoEntrega"
        parametro.Value = 1
        ListaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Nomina.SP_CAJACHICA_FINIQUITOS_ENTREGASALIDA", ListaParametros)

    End Sub

    Public Sub AgregarAnotacion(ByVal IdSolicitud As Int32, ByVal anotacion As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "update Nomina.Finiquitos  set fini_justificacion='" + anotacion + "' where  fini_finiquitoid = " + IdSolicitud.ToString
        operaciones.EjecutaConsulta(consulta)
    End Sub

    Public Sub AceptarSolicitudGerente(ByVal IdSolicitud As Int32, ByVal idAprobo As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "update Nomina.Finiquitos  set fini_estado='D', fini_vobusuarioid=" + idAprobo.ToString + ", fini_vobfecha= (select GETDATE()) where  fini_finiquitoid = " + IdSolicitud.ToString
        operaciones.EjecutaConsulta(consulta)
    End Sub
    Public Sub PagarSolicitudFiniquito(ByVal IdSolicitud As Int32, ByVal idSolicitudCaja As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "update Nomina.Finiquitos  set fini_estado='E', fini_solucitudcajaid=" + idSolicitudCaja.ToString + " where  fini_finiquitoid = " + IdSolicitud.ToString
        operaciones.EjecutaConsulta(consulta)
    End Sub

    Public Sub RechazarSolicitudFiniquito(ByVal IdSolicitud As Int32, ByVal idAprobo As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "UPDATE Nomina.Finiquitos SET fini_estado='C', fini_usuarioautorizoid=" + idAprobo.ToString + ", fini_fechaautorizacion= GETDATE() where  fini_finiquitoid = " + IdSolicitud.ToString
        operaciones.EjecutaConsulta(consulta)
    End Sub

    Public Sub ActualizarDatosSolicitarFiniquito(ByVal idSolicitud As Int32, ByVal utilidades As Double, ByVal gratificacion As Double, ByVal totalEntregar As Double, ByVal subtotal As Double)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "update Nomina.Finiquitos set fini_utilidades = " + utilidades.ToString + ", fini_gratificacion=" + gratificacion.ToString + " , fini_totalentregar=" + totalEntregar.ToString + ", fini_subtotal=" + subtotal.ToString + " where fini_finiquitoid = " + idSolicitud.ToString
        operaciones.EjecutaConsulta(consulta)
    End Sub

    Public Function BusquedaFechaIngreso(ByVal idEmpleado As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Nomina.Colaborador where=" + idEmpleado.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function _TablaImprimir(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Naveid As Int32) As DataTable

    End Function
    Public Function TablaImprimir(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Naveid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select fini_consecutivonave, (codr_apellidopaterno+ ' '+ codr_apellidomaterno+' ' + codr_nombre)as Nombre, real_fecha, fini_fechabaja, fini_totalfiniquito, fini_sueldodiastrabajados,"
        consulta += " fini_gratificacion, fini_utilidades, fini_ahorro, fini_prestamo, fini_totalentregar "
        consulta += " from Nomina.Finiquitos left join Nomina.Colaborador on (codr_colaboradorid= fini_colaboradorid) "
        consulta += " left join Nomina.ColaboradorReal on (fini_colaboradorid= real_colaboradorid) left join Nomina.ColaboradorLaboral on (codr_colaboradorid=labo_colaboradorid)"
        consulta += " where fini_estado='G' and fini_fechabaja between '" + FechaInicio.ToString + "'  and '" + FechaFin.ToString + "'"
        If Naveid > 0 Then
            consulta += " and labo_naveid=" + Naveid.ToString
        End If

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ReporteIncidencias(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Naveid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = "select pnom_NoSemanaNomina as Semana,(codr_apellidopaterno + ' ' + codr_apellidomaterno+' ' + codr_nombre) as Nombre, fini_fechabaja as FechaBaja, mfin_nombre as Motivo  from Nomina.Colaborador join Nomina.Finiquitos"
        Consulta += " on (codr_colaboradorid=fini_colaboradorid) join Nomina.ColaboradorLaboral on (labo_colaboradorid= codr_colaboradorid) left join Nomina.Areas on (labo_areaid= area_areaid)"
        Consulta += " left join Nomina.PeriodosNomina on (pnom_FechaInicial >= '" + FechaInicio.ToString + " 00:00:00'    and  pnom_FechaFinal<= '" + FechaFin.ToString + " 23:59:00'  and pnom_NaveId=labo_naveid and fini_fechabaja>= pnom_FechaInicial and fini_fechabaja<= pnom_FechaFinal)"
        Consulta += " join Nomina.MotivosFiniquito on (fini_motivofiniquitoid=mfin_motivofiniquitoid) where labo_naveid=" + Naveid.ToString
        Return operaciones.EjecutaConsulta(Consulta)
    End Function

    Public Function ConsultaDePrestamoparaLiquidacion(ByVal Colaboradorid As Int32, ByVal NaveID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@ColaboradorId"
        parametro.Value = Colaboradorid
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveID"
        parametro.Value = NaveID
        ListaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Prestamos].[SP_Consulta_SaldoPrestamo_Liquidacion]", ListaParametros)

        'Dim Consulta As String = "select SUM(pres_saldo) as Prestamo from Prestamos.Prestamos where pres_estatus in ('F','G') and pres_colaboradorid=" + Colaboradorid.ToString
        'Return operaciones.EjecutaConsulta(Consulta)

    End Function

    Public Sub SolicitarFiniquito(ByVal finiquito As Entidades.Finiquitos)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        '  Dim ConsultaDesactivarUsuario As String = "update Nomina.Colaborador set codr_activo=0 where codr_colaboradorid=" + finiquito.PColaboradorId.PColaboradorid.ToString
        Dim ListaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "fini_colaboradorid"
        parametro.Value = finiquito.PColaboradorId.PColaboradorid
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_motivofiniquitoid"
        parametro.Value = finiquito.PMotivoFiniquitoId.PMotivoFiniquitoId
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_justificacion"
        parametro.Value = finiquito.PJustificacion
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_fechabaja"
        parametro.Value = finiquito.PFechaBaja
        ListaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "fini_antiguedaddias"
        parametro.Value = finiquito.PAntiguedadDias
        ListaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "fini_antiguedadmeses"
        parametro.Value = finiquito.PAntiguedadMeses
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_antiguedadanios"
        parametro.Value = finiquito.PAntiguedadAnios
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_sueldosemana1"
        parametro.Value = finiquito.PSemana1
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_sueldosemana2"
        parametro.Value = finiquito.PSemana2
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_sueldosemana3"
        parametro.Value = finiquito.PSemana3
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_sueldosemana4"
        parametro.Value = finiquito.PSemana4
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_salariosemanal"
        parametro.Value = finiquito.PSalario
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_salariodiario"
        parametro.Value = finiquito.PSalarioDiario
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_mesesaguinaldo"
        parametro.Value = finiquito.PMesesAguinaldo
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_diasaguinaldo"
        parametro.Value = finiquito.PDiasAguinaldo
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_totalaguinaldo"
        parametro.Value = finiquito.PTotalAguinaldo
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_mesesvacaciones"
        parametro.Value = finiquito.PMesesVacaciones
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_diasvacaciones"
        parametro.Value = finiquito.PDiasVacaciones
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_totalvacaciones"
        parametro.Value = finiquito.PTotalVacaciones
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_totalfiniquito"
        parametro.Value = finiquito.PTotalFiniquito
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_ahorro"
        parametro.Value = finiquito.PAhorro
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_utilidades"
        parametro.Value = finiquito.PUtilidades
        ListaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "fini_gratificacion"
        parametro.Value = finiquito.PGratificacion
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_subtotal"
        parametro.Value = finiquito.PSubtotal
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_prestamo"
        parametro.Value = finiquito.PPrestamo
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_totalentregar"
        parametro.Value = finiquito.PTotalEntregar
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_estado"
        parametro.Value = finiquito.PEstado
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_usuariocreoid"
        parametro.Value = finiquito.PUsuarioCreoId
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_primavacacional"
        parametro.Value = finiquito.PPrimaVacacional
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_diasVacacionesAntiguedad"
        parametro.Value = finiquito.PDiasSegunAntiguedad
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Naveid"
        parametro.Value = finiquito.PNaveID
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_sueldodiastrabajados"
        parametro.Value = 0
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_norecontratar"
        parametro.Value = finiquito.PnoRecontratar
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_extras"
        parametro.Value = finiquito.PExtras
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_utilidadesanterior"
        parametro.Value = finiquito.PUtilidadesAnterior
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_anioutilidades"
        parametro.Value = finiquito.PAnioUtilidades
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fini_anioutilidadesanterior"
        parametro.Value = finiquito.PAnioUtilidadesAnterior
        ListaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Nomina.SP_Solicitud_Finiquito", ListaParametros)
        ' operaciones.EjecutaConsulta(ConsultaDesactivarUsuario)
    End Sub

    Public Function SolicitudesFiniquitosSegunNave(ByVal nombre As String, ByVal Fecha As String, ByVal SegundaFecha As String, ByVal Estatus As String, ByVal NaveId As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Nomina.Finiquitos join Nomina.Colaborador on fini_colaboradorid = codr_colaboradorid "
        consulta += "join Nomina.ColaboradorLaboral on codr_colaboradorid = labo_colaboradorid join Nomina.ColaboradorReal on labo_colaboradorid = real_colaboradorid where labo_naveid in("
        consulta += "select naus_naveid from Framework.NavesUsuario where naus_usuarioid=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
        consulta += ") and (codr_nombre + ' '+codr_apellidopaterno + ' ' + codr_apellidomaterno) like '%" + nombre.Replace(" ", "%") + "%'"
        If Fecha <> "" Then
            consulta += "AND fini_fechasolicitud BETWEEN '" + Fecha.ToString + " 00:00:01' and '" + SegundaFecha.ToString + " 23:59:59'"
        End If
        If Estatus <> "" Then
            consulta += " AND fini_estado='" + Estatus.ToString + "' "

        End If
        If NaveId > 0 Then
            consulta += " and labo_naveid=" + NaveId.ToString
        End If

        consulta += " order by fini_fechasolicitud desc"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function SolicitudesFiniquitosSegunNaveConsulta(ByVal nombre As String,
                                                           ByVal Estatus As String,
                                                           ByVal NaveId As Int32,
                                                           ByVal filtrar As Boolean,
                                                           ByVal fechabaja As Boolean,
                                                           ByVal fechainicio As String,
                                                           ByVal fechafin As String) As DataTable

        'Dim consulta As String = "SELECT CAST(0 AS bit) AS Seleccion, fini_estado, NULL AS estDsn,fini_consecutivonave, fini_finiquitoid, labo_naveid, codr_colaboradorid," +
        '" DATEPART(WEEK, fini_fechaentregado) as SemanaEntrega,/* DATEPART(WEEK, fini_fechabaja) as SemanaBaja, */" +
        '" (SELECT pnom_NoSemanaNomina FROM Nomina.PeriodosNomina WHERE fini_fechabaja BETWEEN pnom_FechaInicial AND pnom_FechaFinal AND pnom_NaveId= " + NaveId.ToString + " )  AS SemanaBaja," +
        '" codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS Colaborador, fini_fechabaja," +
        '" fini_antiguedadanios, fini_antiguedadmeses, fini_totalaguinaldo, fini_totalvacaciones, fini_primavacacional," +
        '" fini_totalfiniquito, fini_gratificacion, fini_utilidades, fini_ahorro, fini_prestamo,fini_extras, fini_totalentregar," +
        '" fini_fechaentregado, labo_departamentoid, g.grup_name, labo_puestoid, p.pues_nombre, real_fecha," +
        '" fini_justificacion, fini_antiguedaddias,fini_motivofiniquitoid, fini_sueldosemana1, fini_sueldosemana2, fini_sueldosemana3," +
        '" fini_sueldosemana4, fini_fechasolicitud, fini_norecontratar, fini_salariosemanal, fini_salariodiario, fini_mesesaguinaldo," +
        '" fini_diasaguinaldo, fini_mesesvacaciones, fini_diasvacaciones, real_tiposueldo, fini_subtotal, fini_fechaautorizacion" +
        '    " FROM Nomina.Finiquitos" +
        '    " JOIN Nomina.Colaborador	ON fini_colaboradorid = codr_colaboradorid" +
        '    " JOIN Nomina.ColaboradorLaboral ON codr_colaboradorid = labo_colaboradorid" +
        '    " JOIN Nomina.ColaboradorReal ON labo_colaboradorid = real_colaboradorid" +
        '    " JOIN Framework.Grupos g ON labo_departamentoid = g.grup_grupoid" +
        '    " JOIN Nomina.Puestos p ON labo_puestoid = p.pues_puestoid"
        '        consulta += " where labo_naveid in("
        '        consulta += "select naus_naveid from Framework.NavesUsuario where naus_usuarioid=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
        '        consulta += ") and (codr_nombre + ' '+codr_apellidopaterno + ' ' + codr_apellidomaterno) like '%" + nombre.Replace(" ", "%") + "%'"

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@UsuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ColaboradorNombre"
        parametro.Value = nombre
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Estado"
        parametro.Value = Estatus
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = NaveId
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Filtrar"
        parametro.Value = filtrar
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaBaja"
        parametro.Value = fechabaja
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = CDate(fechainicio)
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = CDate(fechafin)
        ListaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Nomina.SP_ConsultaFiniquitosPorNave", ListaParametros)
    End Function


    Public Function SolicitudFiniquitosSegunNave(ByVal SolicitudFiniquito As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Nomina.Finiquitos join Nomina.Colaborador on fini_colaboradorid = codr_colaboradorid "
        consulta += "join Nomina.ColaboradorLaboral on codr_colaboradorid = labo_colaboradorid join Nomina.ColaboradorReal on labo_colaboradorid = real_colaboradorid where labo_naveid in("
        consulta += "select naus_naveid from Framework.NavesUsuario where naus_usuarioid=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
        consulta += ") and fini_finiquitoid=" + SolicitudFiniquito.ToString

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ValidarFiniquitos(ByVal ColaboradorID As Int32, ByVal Estatus As String) As DataTable
        Dim operacioneas As New Persistencia.OperacionesProcedimientos
        'Dim Consulta As String = "select * from Nomina.Finiquitos where fini_colaboradorid =" + ColaboradorID.ToString + "and fini_estado = '" + Estatus.ToString + "'"        
        Dim Consulta As String = "select * from Nomina.Finiquitos where fini_colaboradorid =" + ColaboradorID.ToString + "and fini_estado <> 'C'"
        Return operacioneas.EjecutaConsulta(Consulta)

    End Function

    Public Function ObtenerUltimoDiaTrabajado(ByVal Colaboradorid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim Consulta As String = "select top 1 convert(varchar(10), regcheck_normal, 103) as ultimodia from ControlAsistencia.RegistroCheck where regcheck_colaborador=" + Colaboradorid.ToString + " AND regcheck_resultado <>0 order by  regcheck_normal desc"
        'Return operaciones.EjecutaConsulta(Consulta)
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter("@Colaboradorid", Colaboradorid)
        listaParametros.Add(parametro)
        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ObtenerUltimoDiaTrabajado]", listaParametros)

    End Function

    Public Function ObtenerUltimoDiaTrabajadoNoCheca(ByVal Colaboradorid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = "select * from Nomina.Finiquitos where fini_colaboradorid=" + Colaboradorid.ToString
        Return operaciones.EjecutaConsulta(Consulta)
    End Function

    Public Function BuscarPeriodoNominaTrabajado(ByVal Fecha As Date) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select pnom_PeriodoNomId, pnom_FechaInicial from Nomina.PeriodosNomina where (pnom_FechaInicial <= '" + Fecha + " 00:00:00'    and  pnom_FechaFinal>= '" + Fecha + " 23:59:00'  )"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscarAparecePeriodoNomina(ByVal idColaborador As String, ByVal PeriodoNominaid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Nomina.CorteNominaReal where conr_periodonominaid=" + PeriodoNominaid.ToString + " and conr_colaboradorid=" + idColaborador.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ObtenerGratificacionUtilidad(ByVal NoMeses As Double) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "NumeroMeses"
        parametro.Value = NoMeses
        ListaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Nomina.SP_CalcularGratificacionUtilidad", ListaParametros)
        ' operaciones.EjecutaConsulta(ConsultaDesactivarUsuario)
    End Function

    Public Function BuscarFiniquito(ByVal Colaboradorid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT top 1 * from Nomina.Finiquitos where fini_colaboradorid=" + Colaboradorid.ToString + " order by fini_fechabaja DESC"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function consultaUltimosSalarios(ByVal Colaboradorid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT TOP 4 * FROM Nomina.CorteNominaReal" +
            " WHERE conr_colaboradorid = " + Colaboradorid.ToString +
            " ORDER BY conr_periodonominaid DESC"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub editarFiniquito(ByVal idFiniquito As Int32, ByVal enFiniquito As Entidades.Finiquitos)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@fini_finiquitoid"
        parametro.Value = idFiniquito
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_motivofiniquitoid"
        parametro.Value = enFiniquito.PMotivoFiniquitoId.PMotivoFiniquitoId
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_justificacion"
        parametro.Value = enFiniquito.PJustificacion
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_fechabaja"
        parametro.Value = enFiniquito.PFechaBaja
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_antiguedaddias"
        parametro.Value = enFiniquito.PAntiguedadDias
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_antiguedadmeses"
        parametro.Value = enFiniquito.PAntiguedadMeses
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_antiguedadanios"
        parametro.Value = enFiniquito.PAntiguedadAnios
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_sueldosemana1"
        parametro.Value = enFiniquito.PSemana1
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_sueldosemana2"
        parametro.Value = enFiniquito.PSemana2
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_sueldosemana3"
        parametro.Value = enFiniquito.PSemana3
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_sueldosemana4"
        parametro.Value = enFiniquito.PSemana4
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_salariosemanal"
        parametro.Value = enFiniquito.PSalario
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_salariodiario"
        parametro.Value = enFiniquito.PSalarioDiario
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_mesesaguinaldo"
        parametro.Value = enFiniquito.PMesesAguinaldo
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_diasaguinaldo"
        parametro.Value = enFiniquito.PDiasAguinaldo
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_totalaguinaldo"
        parametro.Value = enFiniquito.PTotalAguinaldo
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_mesesvacaciones"
        parametro.Value = enFiniquito.PMesesVacaciones
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_diasvacaciones"
        parametro.Value = enFiniquito.PDiasVacaciones
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_totalvacaciones"
        parametro.Value = enFiniquito.PTotalVacaciones
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_ahorro"
        parametro.Value = enFiniquito.PAhorro
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_utilidades"
        parametro.Value = enFiniquito.PUtilidades
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_gratificacion"
        parametro.Value = enFiniquito.PGratificacion
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_subtotal"
        parametro.Value = enFiniquito.PSubtotal
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_prestamo"
        parametro.Value = enFiniquito.PPrestamo
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_totalentregar"
        parametro.Value = enFiniquito.PTotalEntregar
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_primavacacional"
        parametro.Value = enFiniquito.PPrimaVacacional
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_diasVacacionesAntiguedad"
        parametro.Value = enFiniquito.PDiasSegunAntiguedad
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_norecontratar"
        parametro.Value = enFiniquito.PnoRecontratar
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_totalfiniquito"
        parametro.Value = enFiniquito.PTotalFiniquito
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_extras"
        parametro.Value = enFiniquito.PExtras
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_utilidadesanterior"
        parametro.Value = enFiniquito.PUtilidadesAnterior
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_anioutilidades"
        parametro.Value = enFiniquito.PAnioUtilidades
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fini_anioutilidadesanterior"
        parametro.Value = enFiniquito.PAnioUtilidadesAnterior
        ListaParametros.Add(parametro)

        '' ''parametro = New SqlParameter
        '' ''parametro.ParameterName = "@usuario"
        '' ''parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        '' ''ListaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Nomina.SP_EditarInformacionFiniquito", ListaParametros)
    End Sub

    Public Sub editarFiniquitoCerrado(ByVal idFiniquito As Int32, ByVal montoTotal As Int32, ByVal montoSubtotal As Double, ByVal gratificacion As Double, ByVal justificacion As String, ByVal recontratar As Boolean)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "UPDATE Nomina.Finiquitos SET fini_totalfiniquito = " + montoTotal.ToString + "," +
                                " fini_subtotal = " + montoSubtotal.ToString + "," +
                                " fini_gratificacion =" + gratificacion.ToString + "," +
                                " fini_justificacion = '" + justificacion + "'," +
                                " fini_norecontratar = '" + recontratar.ToString + "'" +
                                " WHERE fini_finiquitoid =" + idFiniquito.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Function ImprimirReporteFichaRenuncia(ByVal idFiniquito As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@fini_finiquitoid"
        parametro.Value = idFiniquito
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Nomina.SP_Reporte_Finiquito", listaParametros)
    End Function

    Public Sub EntregarFiniquitoDireccion(ByVal IdSolicitud As Int32, ByVal idAprobo As Int32, ByVal fechaEntrega As Date)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = "update Nomina.Finiquitos set fini_estado='H', fini_usuarioautorizoid=" + idAprobo.ToString + ", fini_fechaentregado = '" + fechaEntrega.ToShortDateString + "' where fini_finiquitoid = " + IdSolicitud.ToString
        'operaciones.EjecutaConsulta(consulta)
        Dim ListaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@finiquitoid"
        parametro.Value = IdSolicitud
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoEntrega"
        parametro.Value = 2
        ListaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Nomina.SP_CAJACHICA_FINIQUITOS_ENTREGASALIDA", ListaParametros)

    End Sub

    Public Function imprimirReporteConcentradoLiquidaciones(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal idNave As Int32, ByVal idUsuario As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = ""
        'consulta = "SELECT COUNT(*) totalBaja,cons.semana, SUM(cons.fini_totalfiniquito) liquidacion, sum(cons.fini_utilidades) utilidades, SUM(cons.fini_gratificacion) gratificacion,"
        'consulta += " SUM(cons.fini_ahorro) cajaAhorro, SUM(cons.fini_prestamo) prestamo, SUM(cons.extras) extras , SUM(cons.fini_totalentregar) totalEntregado ,UPPER((SELECT max(mes))) mes FROM ("
        'consulta += " SELECT f.fini_totalfiniquito, f.fini_utilidades, (SELECT pnom_NoSemanaNomina FROM Nomina.PeriodosNomina WHERE fini_fechabaja BETWEEN pnom_FechaInicial AND pnom_FechaFinal AND pnom_NaveId = " + idNave.ToString + ") AS semana/*DATEPART(week,fini_fechabaja) as semana*/,f.fini_gratificacion, f.fini_ahorro, f.fini_prestamo,isnull(f.fini_extras,0) extras, f.fini_totalentregar, "
        'consulta += "(case when (datediff(day, '" + fechaInicio.ToShortDateString + " 00:01', DATEADD(dd,-(DAY(DATEADD(mm,1,'" + fechaInicio.ToShortDateString + " 00:01'))),DATEADD(mm,1,'" + fechaInicio.ToShortDateString + " 00:01')))) >= "
        'consulta += "(datediff(day,DATEADD(dd,-(DAY('" + fechaFin.ToShortDateString + " 23:59')-1),'" + fechaFin.ToShortDateString + " 23:59'),'" + fechaFin.ToShortDateString + " 23:59')) "
        'consulta += "then DATENAME(MONTH,'" + fechaInicio.ToShortDateString + " 00:01')	else DATENAME(MONTH,'" + fechaFin.ToShortDateString + " 23:59') end) as mes "
        'consulta += "FROM Nomina.Finiquitos f "
        'consulta += " INNER JOIN Nomina.Colaborador c ON c.codr_colaboradorid=fini_colaboradorid"
        'consulta += " INNER JOIN Nomina.ColaboradorLaboral cl on cl.labo_colaboradorid=c.codr_colaboradorid "
        'consulta += " WHERE labo_naveid IN (SELECT naus_naveid FROM Framework.NavesUsuario WHERE naus_usuarioid = " + idUsuario.ToString + ")"
        'consulta += " AND (codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno) LIKE '%%'"
        'consulta += " AND labo_naveid =" + idNave.ToString + " AND fini_fechabaja BETWEEN '" + fechaInicio.ToShortDateString + " 00:01' AND '" + fechaFin.ToShortDateString + " 23:59'"
        'consulta += " )cons GROUP BY cons.semana "
        'Return operaciones.EjecutaConsulta(consulta)

        Dim ListaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@fechaInicio"
        parametro.Value = fechaInicio + " 00:01"
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaFin"
        parametro.Value = fechaFin + " 23:59"
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idNave"
        parametro.Value = idNave
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idUsuario"
        parametro.Value = idUsuario
        ListaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ObtieneReporteConcentradoLiquidacion]", ListaParametros)

    End Function

    Public Function obtenerMontosCajaAhorro(ByVal idNave As Int32, ByVal idColaborador As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = "SELECT isnull(MAX(cons.ccpc_MontoAhorro),0) as monto,COUNT(*) as semanas, isnull(SUM(cons.ccpc_MontoAhorro),0) ahorro from"
        consulta += " (SELECT cp.ccpc_MontoAhorro FROM CajaAhorro.ColaboradorPeriodoCaja cp"
        consulta += " INNER JOIN CajaAhorro.CajaAhorro c on cp.ccpc_CajaAhorroId=c.caja_CajaAhorroId"
        consulta += " WHERE c.caja_estado='A' and c.caja_NaveId= " + idNave.ToString + " AND cp.ccpc_ColaboradorId= " + idColaborador.ToString + " ) cons"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function validaColaboradorAsegurado(ByVal idColaborador As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "colaboradorid"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Contabilidad.SP_NFFinquito_ValidaColaboradorAsegurado", listaParametros)
    End Function

    Public Function ObtenerFechaCreacionAguinaldo(ByVal IdColaborador As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim Parametro As New SqlParameter

        Parametro.ParameterName = "@idColaborador"
        Parametro.Value = IdColaborador
        listaParametros.Add(Parametro)

        Return operaciones.EjecutarConsultaSP("Nomina.SP_ObtieneFechaCreacion_Aguinaldo", listaParametros)
    End Function

    Public Function validaProcesoAlta(ByVal idColaborador As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ColaboradorId"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFSolicitudBaja_ValidaAltasPendientes]", listaParametros)
    End Function

    Public Function consultarHorarioNave(ByVal NaveID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NaveID"
        parametro.Value = NaveID
        ListaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_Consulta_Horario_Liquidacion]", ListaParametros)

    End Function


    Public Function ValidaSolicitudCaja(ByVal FiniquitoID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@FiniquitoID"
        parametro.Value = FiniquitoID
        listaParametros.Add(parametro)
        Return operacion.EjecutarConsultaSP("[Nomina].[SP_ValidaSolicitudCajaChica_Finiquito]", listaParametros)
    End Function

    Public Function CambiarEstatusLiquidacionNoEntregada(ByVal pXmlCeldas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@XMLCeldas", pXmlCeldas)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_CambiarEstatusLiquidacionNoEntregada]", listaParametros)
    End Function

    Public Function DatosCalculoFiniquito(idColaborador As Integer, fechaBaja As Date) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@colaboradorid"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechabaja"
        parametro.Value = fechaBaja
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_CalculoFiniquito]", listaParametros)

    End Function

    Public Function ConfiguracionFiniquitoNave(idColaborador As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@IdColaborador"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ObtenerConfiguracionFiniquitoNave]", listaParametros)

    End Function
End Class
