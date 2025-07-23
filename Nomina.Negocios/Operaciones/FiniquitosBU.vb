Imports Nomina.Datos

Public Class FiniquitosBU

    Public Function BuscarFechaIngreso(ByVal IdEmpleado As Int32) As String
        Dim ObjDA As New FiniquitosDA
        BuscarFechaIngreso = ObjDA.BusquedaFechaIngreso("codr_fechacreacion")
    End Function

    Public Sub AceptarSolicitud(ByVal IDincentivo As Int32, ByVal IdAprobo As Int32)
        Dim objIncentivo As New FiniquitosDA
        objIncentivo.AceptarSolicitudFiniquito(IDincentivo, IdAprobo)
    End Sub

    Public Sub EntregoFiniquito(ByVal IDincentivo As Int32, ByVal IdAprobo As Int32, ByVal fechaEntrega As Date)
        Dim objIncentivo As New FiniquitosDA
        objIncentivo.EntregoFiniquito(IDincentivo, IdAprobo, fechaEntrega)
    End Sub

    Public Sub AceptarSolicitudGerente(ByVal IDincentivo As Int32, ByVal IdAprobo As Int32)
        Dim objIncentivo As New FiniquitosDA
        objIncentivo.AceptarSolicitudGerente(IDincentivo, IdAprobo)
    End Sub

    Public Sub PagarSolicitudFiniquito(ByVal IDincentivo As Int32, ByVal idSolicitudCaja As Int32)
        Dim objIncentivo As New FiniquitosDA
        objIncentivo.PagarSolicitudFiniquito(IDincentivo, idSolicitudCaja)
    End Sub


    Public Sub RechazarSolicitud(ByVal IDincentivo As Int32, ByVal IdAprobo As Int32)
        Dim objIncentivo As New FiniquitosDA
        objIncentivo.RechazarSolicitudFiniquito(IDincentivo, IdAprobo)
    End Sub

    Public Sub ModificarSolicitud(ByVal idSolicitud As Int32, ByVal utilidades As Double, ByVal gratificacion As Double, ByVal totalEntregar As Double, ByVal subtotal As Double)
        Dim objFiniquito As New FiniquitosDA
        objFiniquito.ActualizarDatosSolicitarFiniquito(idSolicitud, utilidades, gratificacion, totalEntregar, subtotal)
    End Sub

    Public Function DatosGeneralesColaborador(ByVal IdColaborador As Int32) As Entidades.ColaboradorNomina

        Dim ObjColaboradorNomina As New ColaboradorNominaBU
        DatosGeneralesColaborador = ObjColaboradorNomina.buscarColaborarNomina(IdColaborador)
    End Function

    Public Function DatosRealesColaborador(ByVal IdColaborador As Int32) As Entidades.ColaboradorReal
        Dim ObjColaboradorReal As New ColaboradorRealBU
        DatosRealesColaborador = ObjColaboradorReal.BuscarColaboradorReal(IdColaborador)
    End Function

    Public Function CalcularAntiguedad(ByVal DiasTrabajados As Int32) As Int32()
        'Metodo que se corrigio mas abajo ..... quitar si no se necesita mas
        Dim diasAnio As Int32 = 0
        Dim anioActual As Int32 = 0
        Dim anios As Int32 = 0
        Dim meses As Int32 = 0
        Dim dias As Int32 = 0
        Dim diasme As Int32 = 0

        anioActual = Date.Now.Year
        If anioActual Mod 4 = 0 Then
            diasAnio = 366
        Else
            diasAnio = 365
        End If

        anios = DiasTrabajados \ diasAnio
        meses = (DiasTrabajados - (diasAnio * Fix(DiasTrabajados / diasAnio)))
        meses = Fix(meses / 30.4)
        diasme = (DiasTrabajados Mod diasAnio) Mod 30.4
        CalcularAntiguedad = {anios, meses, diasme}
    End Function

    Public Function CalcularMesesTrabajados(ByVal MesesTrabajados As Int32) As Double
        'Quitar metodo
        Dim mesestrabajadoscalc As Double
        mesestrabajadoscalc = (365 - MesesTrabajados) / 30.4
        CalcularMesesTrabajados = mesestrabajadoscalc
    End Function


    Public Function CalcularSueldo(ByVal semana1 As Int32, ByVal semana2 As Int32, ByVal semana3 As Int32, ByVal semana4 As Int32) As Int32

        Dim PromedioSueldo As Int32
        PromedioSueldo = (semana1 + semana2 + semana3 + semana4) / 4
        CalcularSueldo = PromedioSueldo
    End Function
    Public Function CalcularAguinaldo(ByVal Aguinaldo As Int32) As Int32
        CalcularAguinaldo = Aguinaldo
    End Function

    Public Function SolicitarFiniquito(ByVal solicitud As Entidades.Finiquitos, ByVal ColaboradorID As Int32, ByVal Estatus As String) As String
        Dim objDA As New FiniquitosDA
        SolicitarFiniquito = ""
        Dim ListaSolicitudFiniquitos As New DataTable

        ListaSolicitudFiniquitos = objDA.ValidarFiniquitos(ColaboradorID, Estatus)
        If (ListaSolicitudFiniquitos.Rows.Count <= 0) Then
            objDA.SolicitarFiniquito(solicitud)

        Else
            SolicitarFiniquito = "No se puede realizar esta transaccion el usuario ya cuenta con el mismo tramite en proceso"
        End If





    End Function

    Public Function TablaImprimir(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal NaveId As Int32) As DataTable
        Dim ObjDA As New FiniquitosDA
        TablaImprimir = ObjDA.TablaImprimir(FechaInicio, FechaFin, NaveId)
        Return TablaImprimir
    End Function


    Public Function ReporteIncidencias(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal naveid As Int32) As DataTable
        Dim ObjDA As New FiniquitosDA
        ReporteIncidencias = ObjDA.ReporteIncidencias(FechaInicio, FechaFin, naveid)
        Return ReporteIncidencias
    End Function


    Public Function ConsultaDePrestamoparaLiquidacion(ByVal Colaboradorid As Int32, ByVal NaveID As Integer)
        Dim objDA As New FiniquitosDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultaDePrestamoparaLiquidacion(Colaboradorid, NaveID)
        Dim cantidad As New Int32
        For Each row As DataRow In tabla.Rows
            Try
                cantidad = CInt(row("Prestamo"))
            Catch ex As Exception

            End Try
        Next
        Return cantidad
    End Function

    Public Function SolicitudesFiniquitosSegunNaveConsulta(ByVal nombre As String,
                                                           ByVal Estatus As String,
                                                           ByVal NaveId As Int32,
                                                           ByVal filtrar As Boolean,
                                                           ByVal fechabaja As Boolean,
                                                           ByVal fechainicio As String,
                                                           ByVal fechafin As String) As DataTable
        Dim ObjDa As New FiniquitosDA
        Return ObjDa.SolicitudesFiniquitosSegunNaveConsulta(nombre, Estatus, NaveId, filtrar, fechabaja, fechainicio, fechafin)
    End Function

    Public Function obtenerFiniquitoColaborador(ByVal idColaborador As Integer) As Entidades.Finiquitos
        Dim vFiniquitosDA As New FiniquitosDA
        Dim tabla As New DataTable
        Dim vFiniquitos As New Entidades.Finiquitos
        tabla = vFiniquitosDA.BuscarFiniquito(idColaborador)
        For Each fila As DataRow In tabla.Rows
            vFiniquitos.PFiniquito = CInt(fila("fini_finiquitoid"))
            vFiniquitos.PAntiguedadAnios = CInt(fila("fini_antiguedadanios"))
            vFiniquitos.PAntiguedadMeses = CInt(fila("fini_antiguedadmeses"))
            vFiniquitos.PAntiguedadDias = CInt(fila("fini_antiguedaddias"))
            vFiniquitos.PTotalFiniquito = CDbl(fila("fini_totalfiniquito"))
            vFiniquitos.PAhorro = CDbl(fila("fini_ahorro"))
            vFiniquitos.PPrestamo = CDbl(fila("fini_prestamo"))
            vFiniquitos.PUtilidades = CDbl(fila("fini_utilidades"))
            vFiniquitos.PGratificacion = CDbl(fila("fini_gratificacion"))
            vFiniquitos.PSubtotal = CDbl(fila("fini_subtotal"))
            vFiniquitos.PTotalEntregar = CDbl(fila("fini_totalentregar"))
            vFiniquitos.PEstado = CStr(fila("fini_estado"))
            vFiniquitos.PFechaBaja = CDate(fila("fini_fechabaja"))
            Dim Motivo As New Entidades.MotivosFiniquito
            Motivo.PMotivoFiniquitoId = CInt(fila("fini_motivofiniquitoid"))
            vFiniquitos.PMotivoFiniquitoId = Motivo
            vFiniquitos.PJustificacion = CStr(fila("fini_justificacion"))
            vFiniquitos.PExtras = CDbl(fila("fini_extras"))
        Next
        Return vFiniquitos
    End Function

    Public Function ListaFiniquitosSegunUsuario(ByVal nombre As String, ByVal fecha As String, ByVal SegundaFecha As String, ByVal Estatus As String, ByVal NaveId As Int32) As List(Of Entidades.Finiquitos)
        Dim ObjDa As New FiniquitosDA
        Dim tabla As New DataTable

        ListaFiniquitosSegunUsuario = New List(Of Entidades.Finiquitos)
        tabla = ObjDa.SolicitudesFiniquitosSegunNave(nombre, fecha, SegundaFecha, Estatus, NaveId)

        For Each fila As DataRow In tabla.Rows
            Dim SolicitudFiniquitos As New Entidades.Finiquitos
            Dim Colaborador As New Entidades.Colaborador
            Colaborador.PColaboradorid = CInt(fila("codr_colaboradorid"))
            Colaborador.PNombre = CStr(fila("codr_nombre"))
            Colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            Colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            SolicitudFiniquitos.PColaboradorId = Colaborador
            Dim Real As New Entidades.ColaboradorReal
            Real.PFecha = CDate(fila("real_fecha"))
            SolicitudFiniquitos.PAntiguedadAnios = CInt(fila("fini_antiguedadanios"))
            SolicitudFiniquitos.PAntiguedadMeses = CInt(fila("fini_antiguedadmeses"))
            SolicitudFiniquitos.PAntiguedadDias = CInt(fila("fini_antiguedaddias"))
            SolicitudFiniquitos.PTotalAguinaldo = CDbl(fila("fini_totalaguinaldo"))
            SolicitudFiniquitos.PTotalVacaciones = CDbl(fila("fini_totalvacaciones"))
            SolicitudFiniquitos.PTotalFiniquito = CDbl(fila("fini_totalfiniquito"))
            SolicitudFiniquitos.PAhorro = CDbl(fila("fini_ahorro"))
            SolicitudFiniquitos.PPrestamo = CDbl(fila("fini_prestamo"))
            SolicitudFiniquitos.PUtilidades = CDbl(fila("fini_utilidades"))
            SolicitudFiniquitos.PGratificacion = CDbl(fila("fini_gratificacion"))
            SolicitudFiniquitos.PTotalEntregar = CDbl(fila("fini_totalentregar"))
            SolicitudFiniquitos.PEstado = CStr(fila("fini_estado"))
            SolicitudFiniquitos.PFechaBaja = CDate(fila("fini_fechabaja"))
            SolicitudFiniquitos.PFechaSolicitud = CDate(fila("fini_fechasolicitud"))
            SolicitudFiniquitos.PFiniquito = CInt(fila("fini_finiquitoid"))
            SolicitudFiniquitos.PPrimaVacacional = CDbl(fila("fini_primavacacional"))
            Try
                SolicitudFiniquitos.PSueldoDiasTrabajados = CDbl(fila("fini_sueldodiastrabajados"))
            Catch ex As Exception

            End Try

            If Not IsDBNull(fila("fini_fechaautorizacion")) Then
                SolicitudFiniquitos.PFechaAutorizacion = CDate(fila("fini_fechaautorizacion"))
            End If
            SolicitudFiniquitos.PUsuarioCreoId = (fila("fini_usuariocreoid"))
            If Not IsDBNull(fila("fini_vobusuarioid")) Then
                SolicitudFiniquitos.PVoBo = CInt(fila("fini_vobusuarioid"))
            End If
            If Not IsDBNull(fila("fini_vobfecha")) Then
                SolicitudFiniquitos.PVoBoFecha = CDate(fila("fini_vobfecha"))
            End If

            ListaFiniquitosSegunUsuario.Add(SolicitudFiniquitos)
        Next


    End Function


    Public Function SolicitudFiniquito(ByVal idSolicitud As Int32) As Entidades.Finiquitos
        Dim objFiniquito As New FiniquitosDA
        Dim tabla As New DataTable
        SolicitudFiniquito = New Entidades.Finiquitos
        tabla = objFiniquito.SolicitudFiniquitosSegunNave(idSolicitud)
        Dim SolicitudFiniquitos As New Entidades.Finiquitos
        For Each fila As DataRow In tabla.Rows

            Dim Colaborador As New Entidades.Colaborador
            Colaborador.PColaboradorid = CInt(fila("codr_colaboradorid"))
            Colaborador.PNombre = CStr(fila("codr_nombre"))
            Colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            Colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            SolicitudFiniquitos.PColaboradorId = Colaborador
            Dim Real As New Entidades.ColaboradorReal
            Real.PFecha = CDate(fila("real_fecha"))
            SolicitudFiniquitos.PAntiguedadAnios = CInt(fila("fini_antiguedadanios"))
            SolicitudFiniquitos.PAntiguedadMeses = CInt(fila("fini_antiguedadmeses"))
            SolicitudFiniquitos.PAntiguedadDias = CInt(fila("fini_antiguedaddias"))
            SolicitudFiniquitos.PTotalAguinaldo = CDbl(fila("fini_totalaguinaldo"))
            SolicitudFiniquitos.PTotalVacaciones = CDbl(fila("fini_totalvacaciones"))
            SolicitudFiniquitos.PTotalFiniquito = CDbl(fila("fini_totalfiniquito"))
            SolicitudFiniquitos.PJustificacion = CStr(fila("fini_justificacion"))
            SolicitudFiniquitos.PMesesVacaciones = CDbl(fila("fini_mesesvacaciones"))
            SolicitudFiniquitos.PDiasVacaciones = CDbl(fila("fini_diasvacaciones"))
            SolicitudFiniquitos.PPrimaVacacional = CDbl(fila("fini_primavacacional"))
            SolicitudFiniquitos.PMesesAguinaldo = CDbl(fila("fini_mesesaguinaldo"))
            SolicitudFiniquitos.PDiasAguinaldo = CDbl(fila("fini_diasaguinaldo"))
            SolicitudFiniquitos.PDiasSegunAntiguedad = CInt(fila("fini_diasVacacionesAntiguedad"))

            SolicitudFiniquitos.PSalarioDiario = CDbl(fila("fini_salariodiario"))
            SolicitudFiniquitos.PSalario = CDbl(fila("fini_salariosemanal"))
            SolicitudFiniquitos.PSubtotal = CDbl(fila("fini_subtotal"))


            SolicitudFiniquitos.PAhorro = CDbl(fila("fini_ahorro"))
            SolicitudFiniquitos.PPrestamo = CDbl(fila("fini_prestamo"))
            SolicitudFiniquitos.PUtilidades = CDbl(fila("fini_utilidades"))
            SolicitudFiniquitos.PGratificacion = CDbl(fila("fini_gratificacion"))
            SolicitudFiniquitos.PTotalEntregar = CDbl(fila("fini_totalentregar"))
            SolicitudFiniquitos.PEstado = CStr(fila("fini_estado"))
            SolicitudFiniquitos.PFechaBaja = CDate(fila("fini_fechabaja"))
            SolicitudFiniquitos.PFechaSolicitud = CDate(fila("fini_fechasolicitud"))
            SolicitudFiniquitos.PFiniquito = CInt(fila("fini_finiquitoid"))
            ' SolicitudFiniquitos.PSueldoDiasTrabajados = CDbl(fila("fini_sueldodiastrabajados"))


            Dim Motivo As New Entidades.MotivosFiniquito
            Motivo.PMotivoFiniquitoId = CInt(fila("fini_motivofiniquitoid"))
            SolicitudFiniquitos.PMotivoFiniquitoId = Motivo
            If Not IsDBNull(fila("fini_fechaautorizacion")) Then
                SolicitudFiniquitos.PFechaAutorizacion = CDate(fila("fini_fechaautorizacion"))
            End If
            SolicitudFiniquitos.PUsuarioCreoId = (fila("fini_usuariocreoid"))
            If Not IsDBNull(fila("fini_vobusuarioid")) Then
                SolicitudFiniquitos.PVoBo = CInt(fila("fini_vobusuarioid"))
            End If
            If Not IsDBNull(fila("fini_vobfecha")) Then
                SolicitudFiniquitos.PVoBoFecha = CDate(fila("fini_vobfecha"))
            End If

            If Not IsDBNull(fila("fini_sueldosemana1")) Then
                SolicitudFiniquitos.PSemana1 = CDbl(fila("fini_sueldosemana1"))
            End If
            If Not IsDBNull(fila("fini_sueldosemana2")) Then
                SolicitudFiniquitos.PSemana2 = CDbl(fila("fini_sueldosemana2"))
            End If
            If Not IsDBNull(fila("fini_sueldosemana3")) Then
                SolicitudFiniquitos.PSemana3 = CDbl(fila("fini_sueldosemana3"))
            End If
            If Not IsDBNull(fila("fini_sueldosemana4")) Then
                SolicitudFiniquitos.PSemana4 = CDbl(fila("fini_sueldosemana4"))
            End If


        Next
        Return SolicitudFiniquitos
    End Function

    Public Function ObtenerUltimoDiaTrabajado(ByVal Colaboradorid As Int32, ByVal bandera As Boolean) As Date
        Dim objDa As New FiniquitosDA
        Dim Tabla As New DataTable
        Dim FechaUltima As Date

        If bandera=True then
            Tabla = objDa.ObtenerUltimoDiaTrabajado(Colaboradorid)
            For Each row As DataRow In Tabla.Rows
                FechaUltima = CDate(row("ultimodia"))
            Next
        Else
            Tabla = objDa.ObtenerUltimoDiaTrabajadoNoCheca(Colaboradorid)
            For Each row As DataRow In Tabla.Rows
                FechaUltima = CDate(row("fini_fechabaja"))
            Next
        End If

        
        Return FechaUltima
    End Function

    Public Function BuscarPeriodoNominaTrabajado(ByVal Fecha As Date) As Int32
        Dim objDA As New FiniquitosDA
        Dim Tabla As New DataTable
        Tabla = objDA.BuscarPeriodoNominaTrabajado(Fecha)
        Dim PeriodoNomina As New Int32
        For Each row As DataRow In Tabla.Rows
            PeriodoNomina = CInt(row("pnom_PeriodoNomId"))
        Next
        Return PeriodoNomina
    End Function

    Public Function BuscarFechaNominaTrabajado(ByVal Fecha As Date) As Date
        Dim objDA As New FiniquitosDA
        Dim Tabla As New DataTable
        Tabla = objDA.BuscarPeriodoNominaTrabajado(Fecha)
        Dim FechaInicio As New Date
        For Each row As DataRow In Tabla.Rows
            FechaInicio = CDate(row("pnom_FechaInicial"))
        Next
        Return FechaInicio
    End Function

    Public Function BuscarAparecePeriodoNomina(ByVal idColaborador As String, ByVal PeriodoNominaid As Int32) As Boolean
        Dim objDa As New FiniquitosDA
        Dim tabla As New DataTable
        tabla = objDa.BuscarAparecePeriodoNomina(idColaborador, PeriodoNominaid)
        Dim vacio As New Int32
        For Each row As DataRow In tabla.Rows
            vacio = CInt(row("conr_colaboradorid"))
        Next
        If vacio <= 0 Then
            BuscarAparecePeriodoNomina = False
        Else
            BuscarAparecePeriodoNomina = True
        End If
        Return BuscarAparecePeriodoNomina
    End Function


    Public Function ObtenerGratificacionUtilidad(ByVal NoMeses As Double) As DataTable
        Dim tabla As New DataTable
        Dim OBJDA As New FiniquitosDA
        Return OBJDA.ObtenerGratificacionUtilidad(NoMeses)
    End Function


    Public Function BuscarFiniquito(ByVal Colaboradorid As Int32) As Entidades.Finiquitos
        Dim objbu As New FiniquitosDA
        Dim tabla As New DataTable
        Dim finiquito As New Entidades.Finiquitos
        tabla = objbu.BuscarFiniquito(Colaboradorid)
        Dim fecha As New Date
        For Each row As DataRow In tabla.Rows
            finiquito.PFechaBaja = CDate(row("fini_fechabaja"))
            finiquito.PAntiguedadAnios = CInt(row("fini_antiguedadanios"))
            finiquito.PAntiguedadMeses = CInt(row("fini_antiguedadmeses"))
            finiquito.PAntiguedadDias = CInt(row("fini_antiguedaddias"))

            fecha = CDate(row("fini_fechabaja"))
        Next
        Return finiquito
    End Function
    Public Function BuscarDescripcion(ByVal Colaboradorid As Int32) As String
        Dim objbu As New FiniquitosDA
        Dim tabla As New DataTable
        tabla = objbu.BuscarFiniquito(Colaboradorid)
        Dim justificacion As String = ""
        For Each row As DataRow In tabla.Rows
            justificacion = CStr(row("fini_justificacion"))
        Next
        Return justificacion
    End Function


    Public Function CalcularAntiguedad(ByVal fechaingreso As Date, ByVal fechaSalida As Date) As Int32()
        Dim AnioInicio As Int32
        Dim MesInicio As Int32
        Dim DiaInicio As Int32
        Dim AnioFin As Int32
        Dim MesFin As Int32
        Dim DiaFin As Int32
        Dim Anios As Int32
        Dim Meses As Int32
        Dim Dias As Int32
        Dim cosa As String = ""

        DiaInicio = fechaingreso.Day
        MesInicio = fechaingreso.Month
        AnioInicio = fechaingreso.Year

        DiaFin = fechaSalida.Day
        MesFin = fechaSalida.Month
        AnioFin = fechaSalida.Year

        If DiaFin - DiaInicio >= 0 Then
            Dias = DiaFin - DiaInicio
        Else
            ' ''Dias = (DateAdd(DateInterval.Day, -1, (DateAdd(DateInterval.Month, 1, CDate("01/" + MesInicio.ToString + "/" + AnioInicio.ToString)))).Day - DiaInicio) + DiaFin
            Dias = (DateAdd(DateInterval.Day, -1, (DateAdd(DateInterval.Month, 1, CDate("01/" + Date.Now.Month.ToString + "/" + Date.Now.Year.ToString)))).Day - DiaInicio) + DiaFin
            MesFin = MesFin - 1
        End If

        If MesFin - MesInicio >= 0 Then
            Meses = MesFin - MesInicio
        Else
            Meses = (MesFin - MesInicio) + 12
            AnioFin = AnioFin - 1
        End If

        Anios = AnioFin - AnioInicio

        CalcularAntiguedad = {Anios, Meses, Dias}
    End Function

    Public Function consultaUltimosSalarios(ByVal Colaboradorid As Int32) As DataTable
        Dim objDA As New FiniquitosDA
        Return objDA.consultaUltimosSalarios(Colaboradorid)
    End Function
    'Public Function CalcularMesesTrabajados(ByVal fechaingreso As Date) As Double

    '    Dim mesestrabajadoscalc As Double
    '    mesestrabajadoscalc = (365 - MesesTrabajados) / 30.4
    '    CalcularMesesTrabajados = mesestrabajadoscalc
    'End Function

    Public Sub editarFiniquito(ByVal idFiniquito As Int32, ByVal enFiniquito As Entidades.Finiquitos)
        Dim objDA As New FiniquitosDA
        objDA.editarFiniquito(idFiniquito, enFiniquito)
    End Sub

    Public Sub editarFiniquitoCerrado(ByVal idFiniquito As Int32, ByVal montoTotal As Int32, ByVal montoSubtotal As Double, ByVal gratificacion As Double, ByVal justificacion As String, ByVal recontratar As Boolean)
        Dim objDA As New FiniquitosDA
        objDA.editarFiniquitoCerrado(idFiniquito, montoTotal, montoSubtotal, gratificacion, justificacion, recontratar)
    End Sub

    Public Function ImprimirReporteFichaRenuncia(ByVal idFiniquito As Int32) As DataTable
        Dim objDa As New Datos.FiniquitosDA
        Dim tabla As New DataTable
        tabla = objDa.ImprimirReporteFichaRenuncia(idFiniquito)
        Return tabla
    End Function

    ''entregar a direccion
    Public Sub EntregarFiniquitoDireccion(ByVal IDincentivo As Int32, ByVal IdAprobo As Int32, ByVal fechaEntrega As Date)
        Dim objIncentivo As New FiniquitosDA
        objIncentivo.EntregarFiniquitoDireccion(IDincentivo, IdAprobo, fechaEntrega)
    End Sub

    Public Function imprimirReporteConcentradoLiquidaciones(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal idNave As Int32, ByVal idUsuario As Int32)
        Dim objDa As New FiniquitosDA
        Dim tabla As New DataTable
        tabla = objDa.imprimirReporteConcentradoLiquidaciones(fechaInicio, fechaFin, idNave, idUsuario)
        Return tabla
    End Function

    Public Function obtenerMontosCajaAhorro(ByVal idNave As Int32, ByVal idColaborador As Int32) As DataTable
        Dim objDA As New Datos.FiniquitosDA
        Dim tabla As New DataTable
        tabla = objDA.obtenerMontosCajaAhorro(idNave, idColaborador)
        Return tabla
    End Function

    Public Function validaColaboradorAsegurado(ByVal idColaborador As Int32) As Int32
        Dim objDA As New Datos.FiniquitosDA
        Dim tabla As New DataTable
        Dim asegurado As Int32 = 0
        tabla = objDA.validaColaboradorAsegurado(idColaborador)

        If tabla.Rows.Count > 0 Then
            asegurado = tabla.Rows(0).Item("asegurado")
        Else
            asegurado = 0
        End If
        Return asegurado
    End Function

    Public Function obtenerFechaCreacionAguinaldo(ByVal IdColaborador As Int32) As String
        Dim objDa As New FiniquitosDA
        Dim dtFechaCreacion As New DataTable
        dtFechaCreacion = objDa.ObtenerFechaCreacionAguinaldo(IdColaborador)
        obtenerFechaCreacionAguinaldo = dtFechaCreacion.Rows(0).Item("agui_fechacreacion")
    End Function

    Public Function validaProcesoAlta(ByVal colaboradorId As Integer) As Boolean
        Dim objDA As New FiniquitosDA
        Dim dtResult As New DataTable
        Dim existe As Boolean = False
        dtResult = objDA.validaProcesoAlta(colaboradorId)

        If Not dtResult Is Nothing Then
            If dtResult.Rows.Count > 0 Then
                existe = CBool(dtResult.Rows(0)("Solicitud") > 0)
            End If
        End If

        Return existe
    End Function

    Public Function consultarHorarioNave(ByVal NaveID As Integer) As String
        Dim objDa As New FiniquitosDA
        Dim dtHorario As New DataTable
        Dim horario As String = String.Empty

        dtHorario = objDa.consultarHorarioNave(NaveID)

        If Not IsNothing(dtHorario) AndAlso dtHorario.Rows.Count > 0 Then
            horario = dtHorario.Rows(0).Item(0)
        End If

        Return horario
    End Function


    Public Function ValidaSolicitudCaja(ByVal FiniquitoID As Integer) As DataTable
        Dim objDA As New FiniquitosDA
        Dim dtValidaSolicitudCaja As New DataTable
        dtValidaSolicitudCaja = objDA.ValidaSolicitudCaja(FiniquitoID)
        Return dtValidaSolicitudCaja
    End Function

    Public Function CambiarEstatusLiquidacionNoEntregada(ByVal pmXlCeldas As String) As DataTable
        Dim objDA As New FiniquitosDA
        Return objDA.CambiarEstatusLiquidacionNoEntregada(pmXlCeldas)
    End Function

    Public Function DatosCalculoFiniquito(ByVal idColaborador As Integer, ByVal FechaBaja As Date) As DataTable
        Dim objDA As New Datos.FiniquitosDA
        Dim tabla As New DataTable
        tabla = objDA.DatosCalculoFiniquito(idColaborador, FechaBaja)
        Return tabla
    End Function
    Public Function ConfiguracionFiniquitoNave(ByVal idColaborador As Integer) As DataTable
        Dim ObjDa As New Datos.FiniquitosDA
        Dim tabla As New DataTable
        tabla = ObjDa.ConfiguracionFiniquitoNave(idColaborador)
        Return tabla
    End Function
End Class
