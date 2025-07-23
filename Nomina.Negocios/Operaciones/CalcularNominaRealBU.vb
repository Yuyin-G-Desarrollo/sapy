Public Class CalcularNominaRealBU

    Public Function ListaCorteNomina(ByVal idNave As Integer, ByVal idPeriodoNomina As Integer, ByVal colaborador As String, ByVal tipoSalario As String) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable

        ListaCorteNomina = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.ListaCorteNomina(idNave, idPeriodoNomina, colaborador, tipoSalario)

        For Each fila As DataRow In tabla.Rows
            Dim deducciones As New Entidades.Deducciones
            Dim percepciones As New Entidades.Percepciones
            Dim colaboradorEnt As New Entidades.Colaborador
            Dim nominaReal As New Entidades.CalcularNominaReal

            ''COLABORADOR

            colaboradorEnt.PColaboradorid = CInt(fila("codr_colaboradorid"))
            If IsDBNull(fila("codr_idanual")) Then
                colaboradorEnt.pIdAnual = 0
            Else
                colaboradorEnt.pIdAnual = CInt(fila("codr_idanual"))
            End If

            colaboradorEnt.PNombre = CStr(fila("codr_nombre"))
            colaboradorEnt.PApaterno = CStr(fila("codr_apellidopaterno"))
            colaboradorEnt.PAmaterno = CStr(fila("codr_apellidomaterno"))
            nominaReal.PCheca = CBool(fila("labo_checa"))
            nominaReal.PDepartamento = fila("grup_name")

            nominaReal.PdepartamentoID = fila("grup_grupoid")

            If IsDBNull(fila("celu_celulaid")) Then
                nominaReal.PCelulaIDSAY = 0
            Else
                nominaReal.PCelulaIDSAY = fila("celu_celulaid")
            End If


            nominaReal.PPuesto = fila("pues_nombre")
            'se cambia la manera de recuperar el tipo al momento del corte y no del colaborador ipxalem
            'nominaReal.PTipoSueldo = fila("real_tiposueldo")
            If IsDBNull(fila("conr_tipopago")) Then
                nominaReal.PTipoSueldo = fila("real_tiposueldo")
            Else
                nominaReal.PTipoSueldo = fila("conr_tipopago")
            End If





            nominaReal.PCheca = CBool(fila("labo_checa"))
            nominaReal.PGanaIncentivos = CBool(fila("labo_ganaincentivos"))
            nominaReal.PGanaIncentivosSiempre = CBool(fila("labo_GanaIncentivosSiempre"))

            ''COLABORADOR

            ''NOMINA REAL
            If IsDBNull(fila("real_cuenta")) Then
                nominaReal.PCuenta = 0
            Else
                nominaReal.PCuenta = fila("real_cuenta")
            End If
            '
            If IsDBNull(fila("real_cantidad")) Then
                nominaReal.PSalarioReal = 0
            Else
                nominaReal.PSalarioReal = CDbl(fila("real_cantidad"))
            End If


            'se cambia la manera de recuperar el tipo al momento del corte y no del colaborador ipxalem
            If IsDBNull(fila("conr_TipoSueldo")) Then
                nominaReal.PRealTipo = CStr(fila("real_tipo"))
            Else
                nominaReal.PRealTipo = CStr(fila("conr_TipoSueldo"))
            End If

            'If IsDBNull(fila("real_tipo")) Then
            '    nominaReal.PRealTipo = ""
            'Else
            '    nominaReal.PRealTipo = CStr(fila("real_tipo"))
            'End If

            nominaReal.PFechaIngreso = fila("real_fecha")

            '   ''NOMINA REAL

            ''SALARIO DIARIO
            If IsDBNull(fila("conr_salariodiario")) Then
                nominaReal.PSalarioDiario = 0
            Else
                nominaReal.PSalarioDiario = CDbl(fila("conr_salariodiario"))
            End If

            ''SALARIO DIARIO


            ''Dias laborados
            If IsDBNull(fila("conr_diaslaborados")) Then
                nominaReal.PDiasLaborados = 0
            Else
                nominaReal.PDiasLaborados = CDbl(fila("conr_diaslaborados"))
            End If
            ''Dias laborados

            ''CHECA


            ''SALARIO semanal
            If IsDBNull(fila("conr_salariosemanal")) Then
                nominaReal.PSalarioSemanal = 0
            Else
                nominaReal.PSalarioSemanal = Math.Round(CDbl(fila("conr_salariosemanal")))
            End If

            ''SALARIO semanal

            ''Percepciones concepto
            ''percepciones monto
            'If IsDBNull(fila("perc_tipo")) Then
            '    percepciones.PPercepcionTipo = 0
            'Else
            '    percepciones.PPercepcionTipo = CInt(fila("perc_tipo"))
            'End If


            'If IsDBNull(fila("perc_monto")) Then
            '    percepciones.PMontoPercepcion = 0
            'Else
            '    percepciones.PMontoPercepcion = CDbl(fila("perc_monto"))
            'End If

            ''Percepciones concepto
            ''percepciones monto

            ''DEDUCCIONES CONCEPTO
            ''DEDUCCIONE MONTO
            'If IsDBNull(fila("dedu_concepto")) Then
            '    deducciones.PConceptoDeduccion = ""
            'Else
            '    deducciones.PConceptoDeduccion = CStr(fila("dedu_concepto"))
            'End If


            'If IsDBNull(fila("dedu_cantidad")) Then
            '    deducciones.PMontoDeduccion = ""
            'Else
            '    deducciones.PMontoDeduccion = CDbl(fila("dedu_cantidad"))
            'End If
            ''DEDUCCIONE MONTO
            ''DEDUCCIONES CONCEPTO



            ''TOTAL A ENTREGAR
            If IsDBNull(fila("cont_totalentregar")) Then
                nominaReal.PTotalEntregar = 0
            Else
                nominaReal.PTotalEntregar = Math.Round(CDbl(fila("cont_totalentregar")))
            End If

            ''TOTAL A ENTREGAR
            ''NOMINA REAL
            ''LAS DESTAS

            nominaReal.PColaborador = colaboradorEnt
            nominaReal.PDeduccionExtraordinaria = deducciones
            nominaReal.PPercepciones = percepciones

            If IsDBNull(fila("cont_ausentismos")) Then
                nominaReal.Pausentismos = 0
            Else
                nominaReal.Pausentismos = fila("cont_ausentismos")
            End If

            'AGREGAGO JUANA 21-07-2015 PARA SABER CUANDO UN COLABORADOR TIENE UN FINIQUITO DE ESA SEMANA
            If IsDBNull(fila("fini_finiquitoid")) Then
                nominaReal.PfiniquitoID = 0
            Else
                nominaReal.PfiniquitoID = fila("fini_finiquitoid")
            End If

            nominaReal.Psexo = fila("codr_sexo")

            ''Agregado Ipxalem 10-09-2015 para ordenar por el puesto
            If IsDBNull(fila("pues_orden")) Then
                nominaReal.POrdenPuesto = 0
            Else
                nominaReal.POrdenPuesto = CInt(fila("pues_orden"))
            End If

            ListaCorteNomina.Add(nominaReal)

        Next

    End Function

    Public Function ListaDestajos(ByVal IdColaborador As Integer, ByVal IdSemanaNomina As Integer) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable

        ListaDestajos = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.Destajos(IdColaborador, IdSemanaNomina)

        For Each fila As DataRow In tabla.Rows

            Dim entDestajos As New Entidades.CalcularNominaReal

            If IsDBNull(fila("dest_montoticket")) Then
                entDestajos.PTotalDestajos = 0
            Else
                entDestajos.PTotalDestajos = CDbl(fila("dest_montoticket"))

            End If

            ListaDestajos.Add(entDestajos)

        Next

    End Function


    Public Function NominaDestajos(ByVal IdColaborador As Integer, ByVal IdSemanaNomina As Integer) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable

        NominaDestajos = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.NominaDestajos(IdColaborador, IdSemanaNomina)

        For Each fila As DataRow In tabla.Rows

            Dim entDestajos As New Entidades.CalcularNominaReal

            If IsDBNull(fila("conr_salariodiario")) Then
                entDestajos.PDestajosSalarioDiario = 0
            Else
                entDestajos.PDestajosSalarioDiario = CDbl(fila("conr_salariodiario"))

            End If

            If IsDBNull(fila("conr_diaslaborados")) Then
                entDestajos.PDestajosdiasLaborados = 0
            Else
                entDestajos.PDestajosdiasLaborados = CInt(fila("conr_diaslaborados"))

            End If

            If IsDBNull(fila("cont_totalentregar")) Then
                entDestajos.PDestajosTotalEntregar = 0
            Else
                entDestajos.PDestajosTotalEntregar = CDbl(fila("cont_totalentregar"))
            End If

            If IsDBNull(fila("conr_salariosemanal")) Then
                entDestajos.PDestajosSalarioSemanal = 0
            Else
                entDestajos.PDestajosSalarioSemanal = CDbl(fila("conr_salariosemanal"))
            End If


            NominaDestajos.Add(entDestajos)

        Next

    End Function

    Public Function ListaDeducciones(ByVal IdColaborador As Integer) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable

        ListaDeducciones = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.ListaDeduccionesColaborador(IdColaborador)


        For Each fila As DataRow In tabla.Rows
            Dim deducciones As New Entidades.Deducciones
            Dim nominaReal As New Entidades.CalcularNominaReal
            deducciones.PNumeroDeducciones = CInt(fila("codr_colaboradorid"))
            nominaReal.PDeduccionExtraordinaria = deducciones
            ListaDeducciones.Add(nominaReal)

        Next

    End Function


    Public Function CajaDeAhorro(ByVal IdColaborador As Integer, ByVal IdSemanaNomina As Integer) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        CajaDeAhorro = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.CajaAhorro(IdColaborador, IdSemanaNomina)

        For Each fila As DataRow In tabla.Rows
            Dim cajaAhorro As New Entidades.CalcularNominaReal
            Dim caja As New Entidades.CajaAhorro
            If IsDBNull(fila("ccpc_montoahorro")) Then
                caja.pMontoAhorro = 0
                cajaAhorro.PCajaAhorro = caja
            Else
                caja.pMontoAhorro = CDbl(fila("ccpc_montoahorro"))
                cajaAhorro.PCajaAhorro = caja
            End If

            CajaDeAhorro.Add(cajaAhorro)

        Next

    End Function


    Public Function HorasExtras(ByVal IdColaborador As Integer, ByVal IdSemanaNomina As Integer) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        HorasExtras = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.HorasExtra(IdColaborador, IdSemanaNomina)

        For Each fila As DataRow In tabla.Rows
            Dim nomina As New Entidades.CalcularNominaReal
            Dim HorasExtra As New Entidades.HorasExtras
            If IsDBNull(fila("phex_monto")) Then
                HorasExtra.PMonto = 0
                nomina.PHorasExtras = HorasExtra
            Else
                HorasExtra.PMonto = CDbl(fila("phex_monto"))
                nomina.PHorasExtras = HorasExtra
            End If
            HorasExtras.Add(nomina)
        Next

    End Function


    Public Function prestamos(ByVal IdColaborador As Integer, ByVal IdSemanaNomina As Integer) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        prestamos = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.prestamos(IdColaborador, IdSemanaNomina)
        For Each fila As DataRow In tabla.Rows
            Dim nomina As New Entidades.CalcularNominaReal
            Dim prestamosEnt As New Entidades.SolicitudPrestamo
            If IsDBNull(fila("pagop_abonocapital")) Then
                prestamosEnt.PPagoTotal = 0
                nomina.PPrestamos = prestamosEnt
            Else
                prestamosEnt.PPagoTotal = CDbl(fila("pagop_abonocapital")) + CDbl(fila("pagop_interes"))
                prestamosEnt.Psaldo = CDbl(fila("pres_saldo"))
                prestamosEnt.Pmontoprestamo = CDbl(fila("pres_montoautorizado"))
                prestamosEnt.Ptipointeres = CStr(fila("pres_tipointeresautorizado"))
                prestamosEnt.Pinteres = CDbl(fila("pres_interesautorizado"))

                nomina.PPrestamos = prestamosEnt
            End If
            prestamos.Add(nomina)
        Next
    End Function
    Public Function abonoExtraordinarioNominaReal(ByVal semanaNominaID As Int32, ByVal colaboradorID As Int32, ByVal naveID As Int32) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        abonoExtraordinarioNominaReal = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.abonoExtraordinarioNominaReal(semanaNominaID, colaboradorID, naveID)

        For Each fila As DataRow In tabla.Rows
            Dim nomina As New Entidades.CalcularNominaReal
            Dim prestamosEnt As New Entidades.SolicitudPrestamo
            If IsDBNull(fila("pagop_abonocapital")) Then
                prestamosEnt.PPagoTotal = 0
                nomina.PPrestamos = prestamosEnt
            Else
                prestamosEnt.PPagoTotal = CDbl(fila("pagop_abonocapital")) + CDbl(fila("pagop_interes"))
                prestamosEnt.Psaldo = CDbl(fila("pres_saldo"))
                prestamosEnt.Pmontoprestamo = CDbl(fila("pres_montoautorizado"))
                prestamosEnt.Ptipointeres = CStr(fila("pres_tipointeresautorizado"))
                prestamosEnt.Pinteres = CDbl(fila("pres_interesautorizado"))

                nomina.PPrestamos = prestamosEnt
            End If
            abonoExtraordinarioNominaReal.Add(nomina)
        Next
    End Function

    Public Function gratificacionesNomina(ByVal idNave As Integer, ByVal colaboradorid As Integer, ByVal periodo As Integer) As DataTable
        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        tabla = objDA.GratificacionesNomina(idNave, colaboradorid, periodo)
        Return tabla
    End Function

    Public Function gratificaciones(ByVal IdColaborador As Integer, ByVal estatus As String, ByVal fechainicio As DateTime, ByVal fechafinal As DateTime, ByVal periodoNominaID As Integer) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        gratificaciones = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.Gratificaciones(IdColaborador, estatus, fechainicio, fechafinal, periodoNominaID)

        For Each fila As DataRow In tabla.Rows
            Dim nomina As New Entidades.CalcularNominaReal

            If IsDBNull(fila("soin_monto")) Then

                nomina.PMontoGratificacion = 0
                nomina.PMotivoGratificacion = ""
            Else
                nomina.PMontoGratificacion = CDbl(fila("soin_monto"))
                nomina.PMotivoGratificacion = CStr(fila("moin_nombre"))
                nomina.PIdGratificacion = fila("soin_solicitudincentivoid")
                nomina.PDiaAdicional = CBool(fila("moin_diaadicional"))
            End If

            gratificaciones.Add(nomina)

        Next

    End Function

    Public Function gratificacionesConfiguracion(ByVal idNave As Integer) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        gratificacionesConfiguracion = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.GratificacionesConfiguracion(idNave)

        For Each fila As DataRow In tabla.Rows
            Dim nomina As New Entidades.CalcularNominaReal
            Dim incentivos As New Entidades.SolicitudIncentivos
            If IsDBNull(fila("confgrat_aparecenomina")) Then
                nomina.PGratificacionConfiguracion = 0
                nomina.PGratificacionGerente = 0
                nomina.PGratificacionDirector = 0
            Else
                nomina.PGratificacionConfiguracion = CBool(fila("confgrat_aparecenomina"))
                nomina.PGratificacionGerente = CBool(fila("confgrat_autorizagerente"))
                nomina.PGratificacionDirector = CBool(fila("confgrat_autorizaDirector"))
                nomina.PGratificacionCumpleanios = CBool(fila("confgrat_aparecenominaCumple"))
            End If
            gratificacionesConfiguracion.Add(nomina)
        Next
    End Function


    'Public Function gratificacionesConfiguracionCumpleaños(ByVal idNave As Integer) As List(Of Entidades.CalcularNominaReal)
    '    Dim objDA As New Nomina.Datos.CalcularNominaRealDA
    '    Dim tabla As New DataTable
    '    gratificacionesConfiguracionCumpleaños = New List(Of Entidades.CalcularNominaReal)
    '    tabla = objDA.GratificacionesConfiguracion(idNave)

    '    For Each fila As DataRow In tabla.Rows
    '        Dim nomina As New Entidades.CalcularNominaReal
    '        Dim incentivos As New Entidades.SolicitudIncentivos
    '        If IsDBNull(fila("confgrat_aparecenominaCumple")) Then
    '            nomina.PGratificacionCumpleanios = False
    '        Else
    '            nomina.PGratificacionCumpleanios = CBool(fila("confgrat_aparecenominaCumple"))
    '        End If
    '        gratificacionesConfiguracionCumpleaños.Add(nomina)
    '    Next
    'End Function

    Public Function deduccionesExtraordinaria(ByVal IdColaborador As Integer, ByVal IdSemanaNomina As Integer) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        deduccionesExtraordinaria = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.DeduccionesExtras(IdColaborador, IdSemanaNomina)

        For Each fila As DataRow In tabla.Rows
            Dim nomina As New Entidades.CalcularNominaReal
            Dim deduccionesEnt As New Entidades.Deducciones

            If IsDBNull(fila("pagodecx_abono")) Then
                deduccionesEnt.PMontoDeduccion = 0

                nomina.PDeduccionExtraordinaria = deduccionesEnt
            Else
                deduccionesEnt.PMontoDeduccion = CDbl(fila("pagodecx_abono"))

                nomina.PDeduccionExtraordinaria = deduccionesEnt
            End If



            deduccionesExtraordinaria.Add(nomina)

        Next

    End Function

    Public Function deduccionesFija(ByVal IdColaborador As Integer, ByVal IdSemanaNomina As Integer) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        deduccionesFija = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.DeduccionesFijas(IdColaborador, IdSemanaNomina)

        For Each fila As DataRow In tabla.Rows
            Dim nomina As New Entidades.CalcularNominaReal
            Dim deduccionesEnt As New Entidades.Deducciones

            If IsDBNull(fila("dedu_cantidad")) Then
                deduccionesEnt.PMontoDeduccion = 0
                deduccionesEnt.PConceptoDeduccion = ""
                nomina.PDeduccionExtraordinaria = deduccionesEnt
            Else
                deduccionesEnt.PMontoDeduccion = CDbl(fila("dedu_cantidad"))
                deduccionesEnt.PConceptoDeduccion = CStr(fila("dedu_concepto"))
                nomina.PDeduccionExtraordinaria = deduccionesEnt
            End If



            deduccionesFija.Add(nomina)

        Next

    End Function


    Public Function percepciones(ByVal IdColaborador As Integer, ByVal IdSemanaNomina As Integer) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        percepciones = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.Percepciones(IdColaborador, IdSemanaNomina)

        For Each fila As DataRow In tabla.Rows
            Dim nomina As New Entidades.CalcularNominaReal
            Dim percepcionesEnt As New Entidades.Percepciones

            If IsDBNull(fila("perc_monto")) Then

                percepcionesEnt.PMontoPercepcion = 0
                nomina.PPercepciones = percepcionesEnt
            Else
                percepcionesEnt.PMontoPercepcion = CDbl(fila("perc_monto"))
                percepcionesEnt.PPercepcionTipo = CInt(fila("perc_tipo"))
                nomina.PPercepciones = percepcionesEnt
            End If



            percepciones.Add(nomina)

        Next

    End Function


    Public Function cajaAhorroValidacion(ByVal idNave As Integer, ByVal FechaInicio As DateTime, FechaFin As DateTime) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        cajaAhorroValidacion = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.CajaAhorroValidacion(idNave, FechaInicio, FechaFin)

        For Each fila As DataRow In tabla.Rows
            Dim nomina As New Entidades.CalcularNominaReal
            Dim percepcionesEnt As New Entidades.Percepciones

            If IsDBNull(fila("caja_CajaAhorroId")) Then

                nomina.PCajaAhorroValidacion = 0
            Else
                nomina.PCajaAhorroValidacion = CInt(fila("caja_CajaAhorroId"))

            End If

            cajaAhorroValidacion.Add(nomina)

        Next

    End Function

    Public Function percepcionesDeducciones(ByVal IdColaborador As Integer, ByVal IdSemanaNomina As Integer) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        percepcionesDeducciones = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.PercepcionesDeducciones(IdColaborador, IdSemanaNomina)

        For Each fila As DataRow In tabla.Rows
            Dim nomina As New Entidades.CalcularNominaReal
            Dim percepcionesEnt As New Entidades.Percepciones
            Dim deduccionesEnt As New Entidades.Deducciones

            If IsDBNull(fila("perc_monto")) Then

                percepcionesEnt.PMontoPercepcion = 0
                nomina.PPercepciones = percepcionesEnt
            Else
                percepcionesEnt.PMontoPercepcion = CDbl(fila("perc_monto"))
                percepcionesEnt.PPercepcionTipo = CInt(fila("perc_tipo"))
                percepcionesEnt.PTotalPercepciones = CDbl(fila("cont_totalpercepciones"))

                deduccionesEnt.PConceptoDeduccion = CStr(fila("dedu_concepto"))
                deduccionesEnt.PMontoDeduccion = CDbl(fila("dedu_cantidad"))
                deduccionesEnt.PTotalDeducciones = CDbl(fila("cont_totaldeducciones"))

                nomina.PTotalEntregar = CDbl(fila("cont_totalentregar"))

                nomina.PPercepciones = percepcionesEnt
                nomina.PDeduccionExtraordinaria = deduccionesEnt
            End If

            percepcionesDeducciones.Add(nomina)

        Next

    End Function

    Public Function checador(ByVal IdColaborador As Integer, ByVal IdSemanaNomina As Integer) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        checador = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.CorteChecador(IdColaborador, IdSemanaNomina)

        For Each fila As DataRow In tabla.Rows
            Dim nomina As New Entidades.CalcularNominaReal
            Dim checadorEnt As New Entidades.CorteChecador

            If IsDBNull(fila("ccheck_inasistencia")) Then
                checadorEnt.PInasistencia = 0
                checadorEnt.PRetardo_mayor = 0
                checadorEnt.PRetardo_menor = 0
                nomina.Pchecador = checadorEnt
            Else
                checadorEnt.PInasistencia = CDbl(fila("ccheck_inasistencia"))
                checadorEnt.PPpuntualidad_asistencia = CBool(fila("ccheck_puntualidad_asistencia"))
                checadorEnt.PCaja_Ahorro = CBool(fila("ccheck_caja_ahorro"))
                checadorEnt.PRetardo_menor = CInt(fila("ccheck_retardo_menor"))
                checadorEnt.PRetardo_mayor = CInt(fila("ccheck_retardo_mayor"))
                checadorEnt.PAsistencia = CDbl(fila("ccheck_asistencia"))
                nomina.Pchecador = checadorEnt
            End If
            checador.Add(nomina)

        Next

    End Function

    Public Function CorteChecadorFaltasUltimoMes(ByVal idColborador As Integer, ByVal fechaInicio As DateTime, ByVal fechafin As DateTime) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        CorteChecadorFaltasUltimoMes = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.CorteChecadorFaltasUltimoMes(idColborador, fechaInicio, fechafin)

        For Each fila As DataRow In tabla.Rows
            Dim nomina As New Entidades.CalcularNominaReal
            Dim checadorEnt As New Entidades.CorteChecador

            If IsDBNull(fila("ccheck_inasistencia")) Then
                checadorEnt.PInasistencia = 0
                checadorEnt.PRetardo_mayor = 0
                checadorEnt.PRetardo_menor = 0
                nomina.Pchecador = checadorEnt
            Else
                checadorEnt.PInasistencia = CInt(fila("ccheck_inasistencia"))
                checadorEnt.PPpuntualidad_asistencia = CBool(fila("ccheck_puntualidad_asistencia"))
                checadorEnt.PCaja_Ahorro = CBool(fila("ccheck_caja_ahorro"))
                checadorEnt.PRetardo_menor = CInt(fila("ccheck_retardo_menor"))
                checadorEnt.PRetardo_mayor = CInt(fila("ccheck_retardo_mayor"))



                nomina.Pchecador = checadorEnt
            End If



            CorteChecadorFaltasUltimoMes.Add(nomina)

        Next

    End Function

    Public Function ListaNominaReal(ByVal IdNave As Integer, ByVal contadorDestajos As Integer, ByVal idDepartamento As Integer, ByVal ColaboradorN As String, ByVal TipoSueldo As String) As List(Of Entidades.CalcularNominaReal)

        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        ListaNominaReal = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.ListaColaboradoresNominaReal(IdNave, contadorDestajos, idDepartamento, ColaboradorN, TipoSueldo.ToString)

        For Each fila As DataRow In tabla.Rows

            Dim colaborador As New Entidades.Colaborador
            Dim NominaReal As New Entidades.CalcularNominaReal
            Dim nominaFiscal As New Entidades.CalculoNominaFiscal

            ''COLABORADOR
            If IsDBNull(fila("codr_idanual")) Then
                colaborador.pIdAnual = 0
            Else
                colaborador.pIdAnual = CInt(fila("codr_idanual"))
            End If

            colaborador.PNombre = CStr(fila("codr_nombre"))
            colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            colaborador.PColaboradorid = CInt(fila("codr_colaboradorid"))

            Try
                NominaReal.PCheca = CBool(fila("labo_checa"))
                NominaReal.PGanaIncentivos = CBool(fila("labo_ganaincentivos"))
                NominaReal.PGanaIncentivosSiempre = CBool(fila("labo_GanaIncentivosSiempre"))
                'NominaReal.PRetencionIMMS = CDbl(fila("cono_imsssemanal"))
                'NominaReal.PRetencionISR = CDbl(fila("cono_isrmonto"))
            Catch e As Exception
                MsgBox(e.Message)
            End Try

            ''NOMINA REAL
            If IsDBNull(fila("cono_isrmonto")) Then
                NominaReal.PRetencionISR = 0
            Else
                NominaReal.PRetencionISR = fila("cono_isrmonto")
            End If
            ''NOMINA REAL
            If IsDBNull(fila("cono_imsssemanal")) Then
                NominaReal.PRetencionIMMS = 0
            Else
                NominaReal.PRetencionIMMS = fila("cono_imsssemanal")
            End If

            NominaReal.PTipoSueldo = fila("real_tiposueldo")
            NominaReal.PDepartamento = fila("grup_name")
            NominaReal.PPuesto = fila("pues_nombre")
            NominaReal.PFechaNac = CDate(fila("codr_fechanacimiento"))
            NominaReal.PCuenta = fila("real_cuenta")
            NominaReal.PFechaIngreso = CDate(fila("real_fecha"))

            ''COLABORADOR

            ''NOMINA REAL
            If IsDBNull(fila("real_tipo")) Then
                NominaReal.PRealTipo = ""
            Else
                NominaReal.PRealTipo = fila("real_tipo")
            End If

            If IsDBNull(fila("real_cantidad")) Then
                NominaReal.PSalarioReal = 0
            Else
                NominaReal.PSalarioReal = CDbl(fila("real_cantidad"))
            End If


            '
            ''SALARIO DIARIO
            If IsDBNull(fila("cono_salariodiario")) Then
                NominaReal.PSalarioDiario = 0
                nominaFiscal.PSalarioDiario = 0
            Else
                NominaReal.PSalarioDiario = CDbl(fila("cono_salariodiario"))
                nominaFiscal.PSalarioDiario = CDbl(fila("cono_salariodiario"))

            End If


            If IsDBNull(fila("cono_nss")) Then
                NominaReal.PNumeroSS = ""
            Else
                NominaReal.PNumeroSS = CStr(fila("cono_nss"))
            End If

            ''AGREGADO ASEGURADO
            If IsDBNull(fila("cono_asegurado")) Then
                NominaReal.PAsegurado = False
            Else
                NominaReal.PAsegurado = fila("cono_asegurado")
            End If

            ''SALARIO DIARIO
            If IsDBNull(fila("celu_idcelulasicy")) Then
                NominaReal.PCelulaID = 0
            Else
                NominaReal.PCelulaID = CInt(fila("celu_idcelulasicy"))
            End If

            If IsDBNull(fila("celu_celulaid")) Then
                NominaReal.PCelulaIDSAY = 0
            Else
                NominaReal.PCelulaIDSAY = fila("celu_celulaid")
            End If


            '
            ''NOMINA REAL

            If IsDBNull(fila("real_costofraccion")) Then
                NominaReal.PcostoFraccion = 0
            Else
                NominaReal.PcostoFraccion = CDbl(fila("real_costofraccion"))
            End If
            ''LAS DESTAS
            NominaReal.Psexo = fila("codr_sexo")
            NominaReal.PColaborador = colaborador

            ''AGREGADO JUANA 21-07-2015 PARA SABER SI EL COLABORADOR TIENE UN FINIQUITO EN LA FECHA DE LA SEMANA DE NOMINA
            If IsDBNull(fila("fini_finiquitoid")) Then
                NominaReal.PfiniquitoID = 0
            Else
                NominaReal.PfiniquitoID = CInt(fila("fini_finiquitoid"))
            End If

            ''Agregado Ipxalem 10-09-2015 para ordenar por el puesto
            If IsDBNull(fila("pues_orden")) Then
                NominaReal.POrdenPuesto = 0
            Else
                NominaReal.POrdenPuesto = CInt(fila("pues_orden"))
            End If
            ''LAS DESTAS


            'If NominaReal.PRealTipo = "SALARIO" And IdNave = 2 Then
            '    NominaReal.PSalarioReal = (NominaReal.PSalarioReal / 7) * 6
            'End If

            ListaNominaReal.Add(NominaReal)

        Next
    End Function

    Public Function ListaDestajos(ByVal IdNave As Integer, ByVal idArea As Integer, ByVal idDepartamento As Integer, ByVal ColaboradorN As String) As List(Of Entidades.CalcularNominaReal)


        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        ListaDestajos = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.ListaColaboradoredDESTAJO(IdNave, idArea, idDepartamento, ColaboradorN)

        For Each fila As DataRow In tabla.Rows

            Dim colaborador As New Entidades.Colaborador
            Dim NominaReal As New Entidades.CalcularNominaReal
            Dim nominaFiscal As New Entidades.CalculoNominaFiscal

            ''COLABORADOR
            colaborador.PNombre = CStr(fila("codr_nombre"))
            colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            colaborador.PColaboradorid = CInt(fila("codr_colaboradorid"))
            ''COLABORADOR

            ''NOMINA REAL
            '
            If IsDBNull(fila("real_cantidad")) Then
                NominaReal.PSalarioReal = 0
            Else
                NominaReal.PSalarioReal = CDbl(fila("real_cantidad"))
            End If
            '
            ''SALARIO DIARIO
            If IsDBNull(fila("cono_salariodiario")) Then
                NominaReal.PSalarioDiario = 0
                nominaFiscal.PSalarioDiario = 0
            Else
                NominaReal.PSalarioDiario = CDbl(fila("cono_salariodiario"))
                nominaFiscal.PSalarioDiario = CDbl(fila("cono_salariodiario"))
            End If

            ''SALARIO DIARIO

            If IsDBNull(fila("cono_nss")) Then
                NominaReal.PNumeroSS = ""
            Else
                NominaReal.PNumeroSS = CStr(fila("cono_nss"))
            End If
            '
            If IsDBNull(fila("ccpc_MontoAhorro")) Then
                NominaReal.PCajaDeAhorro = 0
            Else
                NominaReal.PCajaDeAhorro = CDbl(fila("ccpc_MontoAhorro"))
            End If
            ''NOMINA REAL
            ''LAS DESTAS

            NominaReal.PColaborador = colaborador

            ''LAS DESTAS
            ListaDestajos.Add(NominaReal)

        Next
    End Function


    Public Function ListaLimites(ByVal idNave As Integer) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        ListaLimites = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.IMSSLimites(idNave)

        For Each fila As DataRow In tabla.Rows
            Dim CalcularNominaReal As New Entidades.CalcularNominaReal
            Dim IMSS As New Entidades.DeduccionRealImss
            IMSS.PLimiteInferior = CDbl(fila("drim_limiteinferior"))
            IMSS.PLimiteSuperior = CDbl(fila("drim_limitesuperior"))
            IMSS.PCantidad = CDbl(fila("drim_monto"))
            CalcularNominaReal.PIMSS = IMSS
            ListaLimites.Add(CalcularNominaReal)
        Next
    End Function

    Public Function PorcentajeAsistencia(ByVal idNave As Integer, ByVal Rango As Integer, ByVal Resultado As Integer) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        PorcentajeAsistencia = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.PorcentajeAsistencia(idNave, Rango, Resultado)

        For Each fila As DataRow In tabla.Rows
            Dim Nomina As New Entidades.CalcularNominaReal

            Nomina.PIncentivoPuntualidad = CDbl(fila("confasis_porcentaje"))
            PorcentajeAsistencia.Add(Nomina)
        Next
    End Function


    Public Function PorcentajeRetencion(ByVal idColaborador As Integer) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        PorcentajeRetencion = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.configuracionColaboradorNomina(idColaborador)

        For Each fila As DataRow In tabla.Rows
            Dim Nomina As New Entidades.CalcularNominaReal

            If fila("cono_infonavit") = True Then

                Nomina.Pinfornavit = CBool(fila("cono_infonavit"))
                Nomina.Pinfonavit_monto = CDbl(fila("cono_infonavit_monto"))
                Nomina.Pinfonavit_tipo = CInt(fila("cono_infonavit_tipo"))
                Nomina.PFechaInfonavit = CDate(fila("cono_infonavit_fecha"))

            Else
                Nomina.Pinfornavit = False
                Nomina.Pinfonavit_monto = 0
                Nomina.Pinfonavit_tipo = 0

            End If

            PorcentajeRetencion.Add(Nomina)
        Next
    End Function

    Public Sub guardarPrenomina(ByVal nomina As Entidades.CalcularNominaReal)
        Dim objNomina As New Datos.CalcularNominaRealDA
        objNomina.GuardarDeduccionesPreNomina(nomina)
    End Sub


    Public Function PorBandaTotalLotes(ByVal colaboradorId As Integer, ByVal idnave As Integer, ByVal idcelula As Integer, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime, ByVal anio As Integer) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable

        PorBandaTotalLotes = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.PorBantaTotalLotes(colaboradorId, idnave, idcelula, fechainicial, fechafinal, anio)

        For Each fila As DataRow In tabla.Rows
            Dim BandaTotal As New Entidades.CalcularNominaReal
            If IsDBNull(fila("pares")) Then
                BandaTotal.PTotalParesLotes = 0
            Else
                BandaTotal.PTotalParesLotes = CDbl(fila("pares"))
            End If
            PorBandaTotalLotes.Add(BandaTotal)
        Next
    End Function

    Public Function consultaFiniquitosActivos(ByVal colaboradorId As Integer, ByVal fechainicial As DateTime, ByVal fechafinal As DateTime) As List(Of Entidades.CalcularNominaReal)
        Dim objDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable

        consultaFiniquitosActivos = New List(Of Entidades.CalcularNominaReal)
        tabla = objDA.consultaFiniquitosActivos(colaboradorId, fechainicial, fechafinal)

        For Each fila As DataRow In tabla.Rows
            Dim objEnt As New Entidades.CalcularNominaReal
            If IsDBNull(fila("fini_finiquitoid")) Then
                objEnt.PfiniquitoID = 0
            Else
                objEnt.PfiniquitoID = CInt(fila("fini_finiquitoid"))
            End If
            consultaFiniquitosActivos.Add(objEnt)
        Next
    End Function

    Public Function colaboradorLaboralFiscal(ByVal ColaboradorID As Integer) As List(Of Entidades.CalcularNominaReal)
        Dim ObjDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable

        colaboradorLaboralFiscal = New List(Of Entidades.CalcularNominaReal)
        tabla = ObjDA.colaboradorLaboralFiscal(ColaboradorID)
        For Each fila As DataRow In tabla.Rows
            Dim Objent As New Entidades.CalcularNominaReal


            colaboradorLaboralFiscal.Add(Objent)
        Next
    End Function

    Public Function FactorIntegracion(ByVal Anios As Integer) As List(Of Entidades.CalcularNominaReal)

        Dim ObjDA As New Nomina.Datos.CalcularNominaRealDA
        Dim Tabla As New DataTable
        FactorIntegracion = New List(Of Entidades.CalcularNominaReal)
        Tabla = ObjDA.FactorIntegracion(Anios)
        For Each Fila As DataRow In Tabla.Rows
            Dim ObjENT As New Entidades.CalcularNominaReal
            ObjENT.PFactorIntegracion = CDbl(Fila("fact_factorintegracion"))
            FactorIntegracion.Add(ObjENT)
        Next
    End Function

    Public Function LimiteInferior(ByVal TotalGravado As Double) As List(Of Entidades.CalcularNominaReal)

        Dim ObjDA As New Nomina.Datos.CalcularNominaRealDA
        Dim Tabla As New DataTable
        LimiteInferior = New List(Of Entidades.CalcularNominaReal)
        Tabla = ObjDA.LimiteInferior(TotalGravado)
        For Each fila As DataRow In Tabla.Rows
            Dim Objent As New Entidades.CalcularNominaReal
            Objent.PLimiteInferior = CDbl(fila("rise_limiteinferior"))
            Objent.PTasaImpuesto = CDbl(fila("rise_porcentaje"))
            Objent.PCuotaFija = CDbl(fila("rise_cuotafija"))
            LimiteInferior.Add(Objent)
        Next
    End Function

    Public Function SubsidioEmpleo(ByVal TotalGravado As Double) As List(Of Entidades.CalcularNominaReal)
        Dim ObjDA As New Nomina.Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        tabla = ObjDA.SubsidioEmpleo(TotalGravado)
        SubsidioEmpleo = New List(Of Entidades.CalcularNominaReal)

        For Each fila As DataRow In tabla.Rows
            Dim ObjEnt As New Entidades.CalcularNominaReal
            ObjEnt.PSubsidioEmpleo = CDbl(fila("rase_valor"))
            SubsidioEmpleo.Add(ObjEnt)
        Next
    End Function

    Public Function configuracionFiscal() As List(Of Entidades.CalcularNominaReal)
        Dim ObjDA As New Nomina.Datos.CalcularNominaRealDA
        Dim Tabla As New DataTable
        Tabla = ObjDA.configuracionFiscal()
        configuracionFiscal = New List(Of Entidades.CalcularNominaReal)
        For Each fila As DataRow In Tabla.Rows
            Dim Objent As New Entidades.CalcularNominaReal
            Objent.PSalarioMinimo = fila("cfis_salarioA")
            Objent.PCuotaExedente = fila("cfis_cuotaexcedenteimss")
            Objent.PPrestacionesDinero = fila("cfis_prestacionesdinero")
            Objent.PGastosMedicos = fila("cfis_gastosmedicospensionados")
            Objent.PinvalidezVida = fila("cfis_invalidezvida")
            Objent.PCesantia = fila("cfis_cesantia")
            configuracionFiscal.Add(Objent)

        Next
    End Function

    Public Function salarioCierreDestajo(ByVal colaboradorID As Integer, ByVal periodoNominaID As Integer) As DataTable
        Dim objDA As New Datos.CalcularNominaRealDA
        Return objDA.salarioCierreDestajo(colaboradorID, periodoNominaID)
    End Function

    Public Function validarDestajos(ByVal naveID As Integer, ByVal periodoNomina As Integer) As DataTable
        Dim objDa As New Datos.CalcularNominaRealDA
        Return objDa.validarDestajos(naveID, periodoNomina)
    End Function

    Public Function calculoNetoBanda(ByVal colaboradorID As Integer, ByVal periodoID As Integer, ByVal celulaID As Integer) As DataTable
        Dim objDA As New Datos.CalcularNominaRealDA
        Return objDA.calculoNetoBanda(colaboradorID, periodoID, celulaID)
    End Function

    Public Function configuracionNomina(ByVal naveID As Integer) As DataTable
        Dim objDA As New Datos.CalcularNominaRealDA
        Return objDA.configuracionNomina(naveID)
    End Function

    Public Function montoISR(ByVal colaboradorID As Integer) As Double
        Dim objDA As New Datos.CalcularNominaRealDA
        Dim tabla As New DataTable
        Dim monto As Double = 0
        tabla = objDA.montoISR(colaboradorID)
        monto = tabla.Rows(0).Item("cono_isrmonto")
        Return monto
    End Function

    Public Function validaInicioMes(ByVal periodoId As Integer) As Boolean
        Dim objDA As New Datos.CalcularNominaRealDA
        Dim dtResultado As New DataTable
        Dim resultado As Boolean

        dtResultado = objDA.validaInicioMes(periodoId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0).Item("Resultado")
            End If
        End If
        Return resultado
    End Function

    Public Function reiniciaAcumuladoColaborador(ByVal naveId As Integer) As String
        Dim objDA As New Datos.CalcularNominaRealDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDA.reiniciaAcumuladoColaborador(naveId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0).Item("mensaje")
            End If
        End If
        Return resultado
    End Function

    Public Function sumaAcumuladoMensualColaborador(ByVal colaboradorId As Integer, ByVal monto As Double) As String
        Dim objDA As New Datos.CalcularNominaRealDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDA.sumaAcumuladoMensualColaborador(colaboradorId, monto)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0).Item("mensaje")
            End If
        End If
        Return resultado
    End Function

    Public Function validacambioTipoPagoAplicado(ByVal periodoId As Integer) As Boolean
        Dim objDA As New Datos.CalcularNominaRealDA
        Dim dtResultado As New DataTable
        Dim resultado As Boolean = False

        dtResultado = objDA.validacambioTipoPagoAplicado(periodoId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0).Item("cambiotipopago")
            End If
        End If
        Return resultado
    End Function

    Public Function CambiaTipoSueldoColaboradores(ByVal naveid As Integer, ByVal periodonominaid As Integer) As String
        Dim objDA As New Datos.CalcularNominaRealDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDA.CambiaTipoSueldoColaboradores(naveid, periodonominaid)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0).Item("mensaje")
            End If
        End If
        Return resultado
    End Function

    Public Function ConsultaTotalNominaFiscal(ByVal periodonominaid As Integer) As Double
        Dim objDA As New Datos.CalcularNominaRealDA
        Dim dtResultado As New DataTable
        Dim resultado As Double = 0

        dtResultado = objDA.ConsultaTotalNominaFiscal(periodonominaid)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = CDbl(dtResultado.Rows(0).Item("TotalNominaFiscal"))
            End If
        End If
        Return resultado
    End Function

    Public Function ConsultaColaboradorIncapacidad(ByVal NaveId As Integer, ByVal PeriodoNominaId As Integer) As List(Of Integer)
        Dim objDA As New Datos.CalcularNominaRealDA
        Return objDA.ConsultaColaboradorIncapacidad(NaveId, PeriodoNominaId)
    End Function

    Public Function obtenerSemanaCerradaBU(ByVal periodoNomina As Integer) As DataTable
        Dim objDa As New Datos.CalcularNominaRealDA
        Return objDa.obtenerSemanaCerradaDA(periodoNomina)
    End Function
    Public Function calcularNominaRealBU(ByVal periodoNomina As Integer, ByVal naveId As Integer) As DataTable
        Dim ObjDA As New Nomina.Datos.CalcularNominaRealDA
        Return ObjDA.calcularNominaRealDA(periodoNomina, naveId)

    End Function

    Public Function consultarCierreNomina(ByVal idPeriodoNomina As Integer, ByVal colaborador As String) As DataTable
        Dim ObjDA As New Nomina.Datos.CalcularNominaRealDA
        Return ObjDA.consultarNominaRealDA(idPeriodoNomina, colaborador)
    End Function

    Public Function ConsultaSemanaNominaBU(ByVal naveId As Integer) As DataTable
        Dim objDA As New Datos.CalcularNominaRealDA
        Return objDA.ConsultaSemanaNominaDA(naveId)
    End Function

    Public Function ConsultaIncapacidades(ByVal colaboradorid As Integer, ByVal periodonominaid As Integer, ByVal tipoconsulta As Integer) As Double
        Dim objDA As New Datos.CalcularNominaRealDA
        Dim dtResultado As New DataTable
        Dim resultado As Double = 0

        dtResultado = objDA.ConsultaIncapacidades(colaboradorid, periodonominaid, tipoconsulta)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = CDbl(dtResultado.Rows(0).Item("Incapacidades"))
            End If
        End If
        Return resultado
    End Function

    Public Function obtieneDescuentosFiscalesBU(ByVal colaboradorId As Integer, ByVal periodonominaid As Integer) As DataTable
        Dim objDA As New Datos.CalcularNominaRealDA
        Return objDA.obtieneDescuentosFiscalesDA(colaboradorId, periodonominaid)
    End Function

    Public Function obtenerDatosReporteGeneralNomina(ByVal PeriodoNominaID As Integer, ByVal Colaborador As String) As DataTable
        Dim objDa As New Datos.CalcularNominaRealDA
        Return objDa.obtenerDatosReporteGeneralNomina(PeriodoNominaID, Colaborador)
    End Function

    Public Function ObtieneRevisaReporte(ByVal NaveID As Integer) As DataTable
        Dim objDa As New Datos.CalcularNominaRealDA
        Return objDa.ObtieneRevisaReporte(NaveID)
    End Function


End Class
