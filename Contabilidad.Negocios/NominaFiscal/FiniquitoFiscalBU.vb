Public Class FiniquitoFiscalBU


    Public Function ConsultarFiniquitos(ByVal NaveId As Integer, ByVal EstatusId As Integer, ByVal Nombre As String, ByVal EsFechaBaja As Boolean, ByVal FiltrarPorFechas As Boolean, ByVal FiltrarPorRangoFechas As Boolean, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal PeriodoNopminaFiscal As Integer, ByVal EmpresaID As Integer) As DataTable
        Dim obj As New Contabilidad.Datos.FiniquitoFiscalDA
        Return obj.ConsultarFiniquitos(NaveId, EstatusId, Nombre, EsFechaBaja, FiltrarPorFechas, FiltrarPorRangoFechas, FechaInicio, FechaFin, PeriodoNopminaFiscal, EmpresaID)
    End Function

    Public Function ObtenerInformacionColaborador(ByVal ColaboradorID As Integer, ByVal FechaBaja As Date) As DataTable
        Dim obj As New Contabilidad.Datos.FiniquitoFiscalDA
        Return obj.ObtenerInformacionColaborador(ColaboradorID, FechaBaja)
    End Function

    Public Function ObtenerFiniquitoFiscal(ByVal FiniquitoFiscalID As Integer) As Entidades.FiniquitoFiscal
        Dim obj As New Contabilidad.Datos.FiniquitoFiscalDA
        Dim DtInformacionFinquito As DataTable
        Dim FiniquitoFiscal As New Entidades.FiniquitoFiscal
        'Dim DTInformacionColaborador As DataTable

        DtInformacionFinquito = obj.ObtenerFiniquitoFiscal(FiniquitoFiscalID)


        FiniquitoFiscal.ColaboradorID = DtInformacionFinquito.Rows(0).Item("fifi_colaboradorid")
        FiniquitoFiscal.PeriodoNomidaID = DtInformacionFinquito.Rows(0).Item("fifi_periodonominafiscalid")
        FiniquitoFiscal.PatronID = DtInformacionFinquito.Rows(0).Item("fifi_patronid")
        FiniquitoFiscal.FechaBaja = DtInformacionFinquito.Rows(0).Item("fifi_fechabaja")
        FiniquitoFiscal.Antiguedad = DtInformacionFinquito.Rows(0).Item("fifi_antiguedadanios").ToString() + " Años " + CInt(DtInformacionFinquito.Rows(0).Item("fifi_antiguedadmeses")).ToString + " Meses "
        FiniquitoFiscal.DiasEnCurso = DtInformacionFinquito.Rows(0).Item("fifi_diascurso")
        FiniquitoFiscal.SalarioMinimo = DtInformacionFinquito.Rows(0).Item("fifi_salariominimo")
        FiniquitoFiscal.InformacionColoaborador.IISalarioDiario = DtInformacionFinquito.Rows(0).Item("fifi_salariodiario")
        FiniquitoFiscal.FechaInicioCurso = DtInformacionFinquito.Rows(0).Item("fifi_iniciocurso")
        'FiniquitoFiscal.FechaUltimoPagoVacaciones = DtInformacionFinquito.Rows(0).Item("fifi_ultimopagovacaciones")
        FiniquitoFiscal.DiasVacacionesCorresponden = DtInformacionFinquito.Rows(0).Item("fifi_diasvacacionescorresponden")
        FiniquitoFiscal.DiasVacacionesAño = DtInformacionFinquito.Rows(0).Item("fifi_diasvacaciones")
        FiniquitoFiscal.TotalVacaciones = DtInformacionFinquito.Rows(0).Item("fifi_totalvacaciones")
        FiniquitoFiscal.PrimaVacacional = DtInformacionFinquito.Rows(0).Item("fifi_primavacacional")
        FiniquitoFiscal.DiasAguinaldoCorresponden = DtInformacionFinquito.Rows(0).Item("fifi_diasaguinaldocorresponden")
        FiniquitoFiscal.DiasAguinaldo = DtInformacionFinquito.Rows(0).Item("fifi_diasaguinaldo")
        FiniquitoFiscal.TotalAguinaldo = DtInformacionFinquito.Rows(0).Item("fifi_totalaguinaldo")
        FiniquitoFiscal.TotalGravado = DtInformacionFinquito.Rows(0).Item("fifi_totalgravado")
        FiniquitoFiscal.ISR.UltimoSueldoMensualOrdinario = DtInformacionFinquito.Rows(0).Item("fifi_ultimosueldomensual")
        FiniquitoFiscal.ISR.BaseImpuesto = DtInformacionFinquito.Rows(0).Item("fifi_baseimpuesto")
        FiniquitoFiscal.ISR.TarifaMensualID = DtInformacionFinquito.Rows(0).Item("fifi_tarifasemanalid")
        FiniquitoFiscal.ISR.LimiteInferior = DtInformacionFinquito.Rows(0).Item("fifi_limiteinferior")
        FiniquitoFiscal.ISR.ExcedenteLimiteInferior = DtInformacionFinquito.Rows(0).Item("fifi_excedentelimiteinferior")
        FiniquitoFiscal.ISR.PorcentajeLimiteInferior = DtInformacionFinquito.Rows(0).Item("fifi_porcentajelimiteinferior")
        FiniquitoFiscal.ISR.ImpuestoMarginal = DtInformacionFinquito.Rows(0).Item("fifi_impuestomarginal")
        FiniquitoFiscal.ISR.CuotaFija = DtInformacionFinquito.Rows(0).Item("fifi_cuotafija")
        FiniquitoFiscal.ISR.ImpuestoDeterminado = DtInformacionFinquito.Rows(0).Item("fifi_impuestodeterminado")
        FiniquitoFiscal.ISR.SubsidioEmpleo = DtInformacionFinquito.Rows(0).Item("fifi_subsidioempleo")
        FiniquitoFiscal.ISR.RentencionUSMO = DtInformacionFinquito.Rows(0).Item("fifi_retencionusmo")
        FiniquitoFiscal.ISR.ImpuestoRetenido = DtInformacionFinquito.Rows(0).Item("fifi_impuestoretener")
        FiniquitoFiscal.IndemizacionFiniquito = DtInformacionFinquito.Rows(0).Item("fifi_indemnizacionfiniquito")
        FiniquitoFiscal.USMO.RentencionUSMO = DtInformacionFinquito.Rows(0).Item("fifi_retencionusmo")
        FiniquitoFiscal.NetoRecibir = DtInformacionFinquito.Rows(0).Item("fifi_totalentregar")
        FiniquitoFiscal.MesesLaborandoDelAño = DtInformacionFinquito.Rows(0).Item("fifi_antiguedadmeses")
        FiniquitoFiscal.FactorAguinaldo = DtInformacionFinquito.Rows(0).Item("fifi_factoraguinaldo")
        FiniquitoFiscal.ISRRetenido = DtInformacionFinquito.Rows(0).Item("fifi_impuestoretener")
        FiniquitoFiscal.TotalAntesImpuestos = FiniquitoFiscal.ISRRetenido + FiniquitoFiscal.NetoRecibir
        FiniquitoFiscal.SubTotalEntregar = DtInformacionFinquito.Rows(0).Item("fifi_subtotal")
        FiniquitoFiscal.ImpuestoRetenerFavor = DtInformacionFinquito.Rows(0).Item("fifi_impuestoretenerafavor")

        FiniquitoFiscal.InformacionColoaborador.IIAMaterno = DtInformacionFinquito.Rows(0).Item("AMaterno")
        FiniquitoFiscal.InformacionColoaborador.IIAPaterno = DtInformacionFinquito.Rows(0).Item("APaterno")
        FiniquitoFiscal.InformacionColoaborador.IINumeroSeguroSocial = DtInformacionFinquito.Rows(0).Item("NSS")
        FiniquitoFiscal.InformacionColoaborador.IINombre = DtInformacionFinquito.Rows(0).Item("Nombre")
        FiniquitoFiscal.InformacionColoaborador.IISalarioDiario = DtInformacionFinquito.Rows(0).Item("SDI")
        FiniquitoFiscal.InformacionColoaborador.IIFechaMovimiento = DtInformacionFinquito.Rows(0).Item("FechaIngreso")
        FiniquitoFiscal.InformacionColoaborador.IICurp = DtInformacionFinquito.Rows(0).Item("CURP")
        FiniquitoFiscal.InformacionColoaborador.IIRFC = DtInformacionFinquito.Rows(0).Item("RFC")
        FiniquitoFiscal.SMAG = DtInformacionFinquito.Rows(0).Item("SMAG")
        FiniquitoFiscal.FechaInicioCurso = DtInformacionFinquito.Rows(0).Item("FechaInicioCurso")
        FiniquitoFiscal.FechaUltimoPagoVacaciones = DtInformacionFinquito.Rows(0).Item("FechaUltimoPago")
        FiniquitoFiscal.PatronID = DtInformacionFinquito.Rows(0).Item("PatronID")
        'FiniquitoFiscal.Antiguedad = DtInformacionFinquito.Rows(0).Item("AñosLaborando").ToString() + " Años " + DtInformacionFinquito.Rows(0).Item("MesesLaborando").ToString() + " Meses"
        FiniquitoFiscal.InformacionColoaborador.IIClaveTrabajador = DtInformacionFinquito.Rows(0).Item("CodigoEmpleado")
        FiniquitoFiscal.PAniosVacaciones = DtInformacionFinquito.Rows(0).Item("añosVacaciones").ToString()

        'DTInformacionColaborador = ObtenerInformacionColaborador(FiniquitoFiscal.ColaboradorID, FiniquitoFiscal.FechaBaja)


        'If Not DTInformacionColaborador Is Nothing Then
        '    If DTInformacionColaborador.Rows.Count > 0 Then
        '        FiniquitoFiscal.InformacionColoaborador.IIAMaterno = DTInformacionColaborador.Rows(0).Item("AMaterno")
        '        FiniquitoFiscal.InformacionColoaborador.IIAPaterno = DTInformacionColaborador.Rows(0).Item("APaterno")
        '        FiniquitoFiscal.InformacionColoaborador.IINumeroSeguroSocial = DTInformacionColaborador.Rows(0).Item("NSS")
        '        FiniquitoFiscal.InformacionColoaborador.IINombre = DTInformacionColaborador.Rows(0).Item("Nombre")
        '        FiniquitoFiscal.InformacionColoaborador.IISalarioDiario = DTInformacionColaborador.Rows(0).Item("SDI")
        '        FiniquitoFiscal.InformacionColoaborador.IIFechaMovimiento = DTInformacionColaborador.Rows(0).Item("FechaIngreso")
        '        FiniquitoFiscal.InformacionColoaborador.IICurp = DTInformacionColaborador.Rows(0).Item("CURP")
        '        FiniquitoFiscal.InformacionColoaborador.IIRFC = DTInformacionColaborador.Rows(0).Item("RFC")                
        '        FiniquitoFiscal.SMAG = DTInformacionColaborador.Rows(0).Item("SMAG")
        '        FiniquitoFiscal.FechaInicioCurso = DTInformacionColaborador.Rows(0).Item("FechaInicioCurso")
        '        FiniquitoFiscal.FechaUltimoPagoVacaciones = DTInformacionColaborador.Rows(0).Item("FechaUltimoPago")
        '        FiniquitoFiscal.PatronID = DTInformacionColaborador.Rows(0).Item("PatronID")
        '        FiniquitoFiscal.Antiguedad = DTInformacionColaborador.Rows(0).Item("AñosLaborando").ToString() + " Años " + DTInformacionColaborador.Rows(0).Item("MesesLaborando").ToString() + " Meses"
        '        FiniquitoFiscal.InformacionColoaborador.IIClaveTrabajador = DTInformacionColaborador.Rows(0).Item("CodigoEmpleado")
        '        FiniquitoFiscal.AñosLaborando = DTInformacionColaborador.Rows(0).Item("AñosLaborando").ToString()
        '    End If
        'End If

        Return FiniquitoFiscal

    End Function


    Public Function GuardarFiniquitoFiscal(ByVal Finiquito As Entidades.FiniquitoFiscal) As DataTable
        Dim obj As New Contabilidad.Datos.FiniquitoFiscalDA
        Return obj.GuardarFiniquitoFiscal(Finiquito)
    End Function


    Public Function CalcularFinquitoFiscal(ByVal ColaboradorID As Integer, ByVal FechaBaja As Date, ByVal IndemizacionPorFiniquito As Double) As Entidades.FiniquitoFiscal

        Dim Finiquito As New Entidades.FiniquitoFiscal
        Dim InformacionColaborador As New Contabilidad.Negocios.ColaboradoresContabilidadBU()
        Dim DTInformacionColaborador As DataTable

        Dim objUtl As New UtileriasBU
        Dim DTInformacionVacaciones As DataTable
        Dim DiasDelMes As Integer = 0
        Dim DiasCorrespondenAguinaldo As Double = 0
        Dim MesesLaborando As Double = 0
        Dim BaseGravablePrimaVacacional As Double = 0
        Dim BaseGravableAguinaldo As Double = 0
        Dim BaseGravableIndemizacionPrimaAntiguedad As Double = 0

        Dim DiferenciaBaseGravablePrimaVacacional As Double = 0
        Dim DiferenciaBaseGravableAguinaldo As Double = 0
        Dim DiferenciaIndemizacionPrimaAntiguedad As Double = 0
        Dim CalCuloMensual As Int16 = 1
        Dim MontoGravable As Double = 0
        Dim TarifaMensual As Entidades.TarifaMensualSemanal
        Dim SubsidioEmpleo As Entidades.SubsidioEmpleo
        Dim DiasAguinaldo As Integer = 0

        Try

            DiasAguinaldo = objUtl.ConsultaDiasAguinaldo()
            DTInformacionColaborador = ObtenerInformacionColaborador(ColaboradorID, FechaBaja)


            If Not DTInformacionColaborador Is Nothing Then
                If DTInformacionColaborador.Rows.Count > 0 Then
                    Finiquito.InformacionColoaborador.IIAMaterno = DTInformacionColaborador.Rows(0).Item("AMaterno")
                    Finiquito.InformacionColoaborador.IIAPaterno = DTInformacionColaborador.Rows(0).Item("APaterno")
                    Finiquito.InformacionColoaborador.IINumeroSeguroSocial = DTInformacionColaborador.Rows(0).Item("NSS")
                    Finiquito.InformacionColoaborador.IINombre = DTInformacionColaborador.Rows(0).Item("Nombre")
                    Finiquito.InformacionColoaborador.IISalarioDiario = DTInformacionColaborador.Rows(0).Item("SDI")
                    Finiquito.InformacionColoaborador.IIFechaMovimiento = DTInformacionColaborador.Rows(0).Item("FechaIngreso")
                    Finiquito.InformacionColoaborador.IICurp = DTInformacionColaborador.Rows(0).Item("CURP")
                    Finiquito.InformacionColoaborador.IIRFC = DTInformacionColaborador.Rows(0).Item("RFC")                    
                    Finiquito.SMAG = DTInformacionColaborador.Rows(0).Item("SMAG")
                    Finiquito.FechaInicioCurso = DTInformacionColaborador.Rows(0).Item("FechaInicioCurso")
                    Finiquito.FechaUltimoPagoVacaciones = DTInformacionColaborador.Rows(0).Item("FechaUltimoPago")
                    Finiquito.PatronID = DTInformacionColaborador.Rows(0).Item("PatronID")
                    Finiquito.Antiguedad = DTInformacionColaborador.Rows(0).Item("AñosLaborando").ToString() + " Años " + DTInformacionColaborador.Rows(0).Item("MesesLaborando").ToString() + " Meses"
                    Finiquito.InformacionColoaborador.IIClaveTrabajador = DTInformacionColaborador.Rows(0).Item("CodigoEmpleado")

                End If
            End If
            Finiquito.SalarioMinimo = objUtl.consultaSalarioMinimoDF()


            Finiquito.PeriodoNomidaID = objUtl.ObtenerPeriodoNominaID(Finiquito.PatronID, FechaBaja)

            '---------Vacaciones--------------------------------
            DTInformacionVacaciones = objUtl.ConsultaDiasCorrespondenVacaciones(Finiquito.InformacionColoaborador.IIFechaMovimiento, FechaBaja)

            If Not DTInformacionVacaciones Is Nothing Then
                If DTInformacionVacaciones.Rows.Count > 0 Then
                    Finiquito.AñosLaborando = CDbl(DTInformacionVacaciones.Rows(0).Item("diva_anios").ToString())
                    Finiquito.PAniosVacaciones = CDbl(DTInformacionVacaciones.Rows(0).Item("diva_anios").ToString())
                    Finiquito.DiasVacacionesAño = CDbl(DTInformacionVacaciones.Rows(0).Item("diva_diasvacaciones").ToString())
                    Finiquito.DiasEnCurso = CInt(DTInformacionVacaciones.Rows(0).Item("DiasTranscurridosDelAño").ToString())
                    MesesLaborando = CInt(DTInformacionVacaciones.Rows(0).Item("MesesLaborando").ToString())
                    DiasDelMes = CInt(DTInformacionVacaciones.Rows(0).Item("DiaDelMes").ToString())

                    If Finiquito.DiasEnCurso < DiasDelMes Then
                        DiasDelMes = Finiquito.DiasEnCurso
                    End If

                    'MesesLaborando = MesesLaborando + (CDbl(DiasDelMes) / 30.4)
                    MesesLaborando = (CDbl(Finiquito.DiasEnCurso) / 30.4)

                    'Dias que corresponde de vacaciones al año= (Días de vacaciones por año / 365 ) * días del año en curso 
                    Finiquito.DiasVacacionesCorresponden = (CDbl(Finiquito.DiasVacacionesAño) / 365) * CDbl(Finiquito.DiasEnCurso)

                    'Monto de Total de Vacaciones = ( días vacaciones * sdi)
                    Finiquito.TotalVacaciones = Finiquito.DiasVacacionesCorresponden * CDbl(Finiquito.InformacionColoaborador.IISalarioDiario)
                End If
            End If


            '-----------------------------------------

            '--------------------Aguinaldo---------------------------
            '	Aguinaldo: Factor de aguinaldo (15 días /  365.4 días del año) * días del año en curso *sdi
            Finiquito.FactorAguinaldo = ((CDbl(DiasAguinaldo)) / (CDbl(365.4)))
            '* CDbl(Finiquito.DiasEnCurso) * CDbl(Finiquito.InformacionColoaborador.IISalarioDiario)
            Finiquito.MesesLaborandoDelAño = MesesLaborando

            Finiquito.DiasAguinaldoCorresponden = ((CDbl(DiasAguinaldo)) * Finiquito.MesesLaborandoDelAño) / CDbl(12.0)
            Finiquito.DiasAguinaldo = DiasAguinaldo
            'Finiquito.TotalAguinaldo = Finiquito.DiasAguinaldoCorresponden * CDbl(Finiquito.InformacionColoaborador.IISalarioDiario)

            'Factor de aguinaldo (15 días /  365.4 días del año) * días del año en curso *sdi
            Finiquito.TotalAguinaldo = (Finiquito.FactorAguinaldo) * Finiquito.DiasEnCurso * CDbl(Finiquito.InformacionColoaborador.IISalarioDiario)


            '------------------------------------
            '  Base Gravable
            Finiquito.PrimaVacacional = Finiquito.TotalVacaciones * CDbl(0.25)
            Finiquito.SMAG = Finiquito.SMAG
            BaseGravablePrimaVacacional = Finiquito.SMAG * DiasAguinaldo
            BaseGravableAguinaldo = Finiquito.SMAG * 30
            BaseGravableIndemizacionPrimaAntiguedad = Finiquito.SMAG * 90


            DiferenciaBaseGravablePrimaVacacional = BaseGravablePrimaVacacional - Finiquito.PrimaVacacional
            DiferenciaBaseGravableAguinaldo = BaseGravableAguinaldo - Finiquito.TotalAguinaldo
            DiferenciaIndemizacionPrimaAntiguedad = BaseGravableIndemizacionPrimaAntiguedad - IndemizacionPorFiniquito


            If DiferenciaBaseGravablePrimaVacacional < 0 Then
                MontoGravable = (-1) * DiferenciaBaseGravablePrimaVacacional
            End If

            If DiferenciaBaseGravableAguinaldo < 0 Then
                MontoGravable += (-1) * DiferenciaBaseGravableAguinaldo
            End If

            If DiferenciaIndemizacionPrimaAntiguedad < 0 Then
                MontoGravable += (-1) * DiferenciaIndemizacionPrimaAntiguedad
            End If


            MontoGravable += Finiquito.TotalVacaciones

            Finiquito.TotalGravado = MontoGravable


            '--------Calculo del USMO
            Finiquito.USMO.UltimoSueldoMensualOrdinario = CDbl(Finiquito.InformacionColoaborador.IISalarioDiario) * 30.4
            TarifaMensual = objUtl.consultaTarifa(Finiquito.USMO.UltimoSueldoMensualOrdinario, CalCuloMensual)
            Finiquito.USMO.LimiteInferior = TarifaMensual.TMSLimiteinferior
            Finiquito.USMO.CuotaFija = TarifaMensual.TMSCuotafija
            Finiquito.USMO.TarifaMensualID = TarifaMensual.TMSTarifaId
            Finiquito.USMO.PorcentajeLimiteInferior = TarifaMensual.TMSPorcentajeexcedente
            Finiquito.USMO.ExcedenteLimiteInferior = Finiquito.USMO.UltimoSueldoMensualOrdinario - Finiquito.USMO.LimiteInferior
            Finiquito.USMO.ImpuestoMarginal = Finiquito.USMO.ExcedenteLimiteInferior * Finiquito.USMO.PorcentajeLimiteInferior
            Finiquito.USMO.ImpuestoDeterminado = Finiquito.USMO.ImpuestoMarginal + Finiquito.USMO.CuotaFija
            SubsidioEmpleo = objUtl.consultaSubsidioEmpleo(Finiquito.USMO.UltimoSueldoMensualOrdinario, CalCuloMensual)
            Finiquito.USMO.SubsidioEmpleo = SubsidioEmpleo.SEValorspe
            Finiquito.USMO.RentencionUSMO = Finiquito.USMO.ImpuestoDeterminado - Finiquito.USMO.SubsidioEmpleo

            If Finiquito.USMO.RentencionUSMO < 0 Then
                Finiquito.USMO.RentencionUSMO = 0
            End If

            '--------Calculo ISR
            Finiquito.ISR.UltimoSueldoMensualOrdinario = CDbl(Finiquito.InformacionColoaborador.IISalarioDiario) * 30.4
            Finiquito.ISR.BaseGravable = MontoGravable
            Finiquito.ISR.BaseImpuesto = Finiquito.ISR.BaseGravable + Finiquito.ISR.UltimoSueldoMensualOrdinario
            TarifaMensual = objUtl.consultaTarifa(Finiquito.ISR.BaseImpuesto, CalCuloMensual)
            Finiquito.ISR.LimiteInferior = TarifaMensual.TMSLimiteinferior
            Finiquito.ISR.CuotaFija = TarifaMensual.TMSCuotafija
            Finiquito.ISR.ExcedenteLimiteInferior = Finiquito.ISR.BaseImpuesto - Finiquito.ISR.LimiteInferior
            Finiquito.ISR.TarifaMensualID = TarifaMensual.TMSTarifaId
            Finiquito.ISR.PorcentajeLimiteInferior = TarifaMensual.TMSPorcentajeexcedente
            Finiquito.ISR.ImpuestoMarginal = Finiquito.ISR.ExcedenteLimiteInferior * Finiquito.ISR.PorcentajeLimiteInferior
            Finiquito.ISR.ImpuestoDeterminado = Finiquito.ISR.ImpuestoMarginal + Finiquito.ISR.CuotaFija
            SubsidioEmpleo = objUtl.consultaSubsidioEmpleo(Finiquito.ISR.BaseImpuesto, CalCuloMensual)
            Finiquito.ISR.SubsidioEmpleo = SubsidioEmpleo.SEValorspe
            Finiquito.ISR.RentencionUSMO = Finiquito.USMO.RentencionUSMO
            'Impuesto determinado – subsidio al empleo – retención USMO
            Finiquito.ISR.ImpuestoRetenido = Finiquito.ISR.ImpuestoDeterminado - Finiquito.ISR.SubsidioEmpleo - Finiquito.ISR.RentencionUSMO
            If Finiquito.ISR.ImpuestoRetenido < 0 Then
                Finiquito.ImpuestoRetenerFavor = Finiquito.ISR.ImpuestoRetenido
                Finiquito.ISR.ImpuestoRetenido = 0
            End If
            Finiquito.FechaBaja = FechaBaja


            'vacaciones + prima vacacional + aguinaldo + indemnización por finiquito
            Finiquito.TotalAntesImpuestos = Finiquito.TotalVacaciones + Finiquito.PrimaVacacional + Finiquito.TotalAguinaldo + Finiquito.IndemizacionFiniquito
            Finiquito.ISRRetenido = Finiquito.ISR.ImpuestoRetenido

            'Neto a Recibir: Total antes de impuestos – ISR retenido
            Finiquito.SubTotalEntregar = Finiquito.TotalAntesImpuestos
            Finiquito.NetoRecibir = Finiquito.TotalAntesImpuestos - Finiquito.ISRRetenido
        Catch ex As Exception
            Dim error1 As String
            error1 = "ha surgido un error"
        End Try

        Return Finiquito

    End Function


    Public Function EditarFiniquitoFiscal(ByVal Finiquito As Entidades.FiniquitoFiscal) As DataTable
        Dim obj As New Contabilidad.Datos.FiniquitoFiscalDA
        Return obj.EditarFiniquitoFiscal(Finiquito)
    End Function

    Public Function ObtenerInformacionEmpresa(ByVal NaveID As Integer, ByVal EmpresaID As Integer, ByVal PatronID As Integer) As DataTable
        Dim obj As New Contabilidad.Datos.FiniquitoFiscalDA
        Return obj.ObtenerInformacionEmpresa(NaveID, EmpresaID, PatronID)
    End Function

    Public Function consultaDatosCorreo(ByVal colaboradorId As Integer, ByVal naveId As Integer) As DataTable
        Dim objDatos As New Datos.FiniquitoFiscalDA
        Return objDatos.consultaDatosCorreo(colaboradorId, naveId)
    End Function
End Class
