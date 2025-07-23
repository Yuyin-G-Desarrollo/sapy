Public Class CalculoNominaFiscalBU

    Public Function consultar_DatosBasicosColaboradores(ByVal naveID As Integer, ByVal periodoNomID As Integer) As List(Of Entidades.CalculoNominaFiscal)

        Dim objDA As New Datos.CalculoNominaFiscalDA
        Dim tablaCalculoNominaFiscal, tablaConfiguracionNominaFiscal, tablaImpuestos, tablaImpuestosRangoMayor, tablaSubsidioEmpleo, tablaFactorIntegracion As New DataTable
        consultar_DatosBasicosColaboradores = New List(Of Entidades.CalculoNominaFiscal)
        'tabla = objDA.listaHorarios(nombre, Nave, activo)
        tablaCalculoNominaFiscal = objDA.consultar_DatosBasicosColaboradores(naveID)

        For Each fila As DataRow In tablaCalculoNominaFiscal.Rows

            Dim CalculoNominaFiscal As New Entidades.CalculoNominaFiscal
            Dim Colaborador As New Entidades.Colaborador

            Colaborador.PColaboradorid = CInt(fila("codr_colaboradorid"))
            Colaborador.PApaterno = CStr(fila("codr_apellidopaterno"))
            Colaborador.PAmaterno = CStr(fila("codr_apellidomaterno"))
            Colaborador.PNombre = CStr(fila("codr_nombre"))

            CalculoNominaFiscal.PColaborador = Colaborador
            Try
                CalculoNominaFiscal.PSalarioDiario = CDec(fila("cono_salariodiario"))
            Catch ex As Exception
                CalculoNominaFiscal.PSalarioDiario = 0
            End Try

            CalculoNominaFiscal.PDiasTrabajados = 7 - CInt(fila("ccheck_inasistencia"))
            CalculoNominaFiscal.PSalarioSemanal = CalculoNominaFiscal.PSalarioDiario * CalculoNominaFiscal.PDiasTrabajados
            CalculoNominaFiscal.PSalarioMensual = CalculoNominaFiscal.PSalarioDiario * 30.4
            CalculoNominaFiscal.PPremioPuntualidad = CalculoNominaFiscal.PSalarioSemanal * 0.1

            ''SACA LO DE LA CONFIGURACION NOMINA FISCAL
            tablaConfiguracionNominaFiscal = objDA.consultar_ConfiguracionNominaFiscal
            For Each row As DataRow In tablaConfiguracionNominaFiscal.Rows

                CalculoNominaFiscal.PDespensa = CDec(row("cfis_bonodespensa"))
                CalculoNominaFiscal.PCuotaPorExcedente = CDec(row("cfis_cuotaexcedenteimss"))
                CalculoNominaFiscal.PPrestacionesEnDinero = CDec(row("cfis_prestacionesdinero"))
                CalculoNominaFiscal.PGastosMedicosPensionados = CDec(row("cfis_gastosmedicospensionados"))
                CalculoNominaFiscal.PInvalidezYVida = CDec(row("cfis_invalidezvida"))
                CalculoNominaFiscal.PCesantiaEdadAvanzadaVejez = CDec(row("cfis_cesantia"))
                CalculoNominaFiscal.PSalarioMinimo = CDec(row("cfis_salarioA"))
                CalculoNominaFiscal.PSeguroVivienda = CDec(row("cfis_segurovivienda"))

            Next

            CalculoNominaFiscal.PTotalGravado = CalculoNominaFiscal.PSalarioSemanal + CalculoNominaFiscal.PDespensa + CalculoNominaFiscal.PPremioPuntualidad

            ''SACA LO DEL SUBSIDIO
            tablaImpuestos = objDA.consultar_DatosCalculoSubsidio(CalculoNominaFiscal.PTotalGravado)
            If tablaImpuestos.Rows.Count = 0 Then
                tablaImpuestosRangoMayor = objDA.consultar_SubsidioEmpleoRangoMayor()
                For Each row As DataRow In tablaImpuestosRangoMayor.Rows
                    CalculoNominaFiscal.PLimiteInfeior = CDec(row("rise_limiteinferior"))
                    CalculoNominaFiscal.PTasaDeImpuesto = CDec(row("rise_porcentaje") / 100)
                    CalculoNominaFiscal.PCuotaFija = CDec(row("rise_cuotafija"))
                Next
            Else
                For Each row As DataRow In tablaImpuestos.Rows
                    CalculoNominaFiscal.PLimiteInfeior = CDec(row("rise_limiteinferior"))
                    CalculoNominaFiscal.PTasaDeImpuesto = CDec(row("rise_porcentaje") / 100)
                    CalculoNominaFiscal.PCuotaFija = CDec(row("rise_cuotafija"))
                Next
            End If

            CalculoNominaFiscal.PExcedente = CalculoNominaFiscal.PTotalGravado - CalculoNominaFiscal.PLimiteInfeior
            CalculoNominaFiscal.PImpuestoMarginal = CalculoNominaFiscal.PExcedente * (CalculoNominaFiscal.PTasaDeImpuesto)
            CalculoNominaFiscal.PISRDeterminado = CalculoNominaFiscal.PImpuestoMarginal + CalculoNominaFiscal.PCuotaFija

            ''SUBSIDIO EMPLEO
            tablaSubsidioEmpleo = objDA.consultar_SubsidioEmpleo(CalculoNominaFiscal.PTotalGravado)
            If tablaSubsidioEmpleo.Rows.Count = 0 Then
                CalculoNominaFiscal.PSubsidioEmpleo = 0
            Else
                For Each dato As DataRow In tablaSubsidioEmpleo.Rows
                    CalculoNominaFiscal.PSubsidioEmpleo = CDec(dato("rase_valor"))
                Next
            End If

            Dim resultado As Decimal = CalculoNominaFiscal.PISRDeterminado - CalculoNominaFiscal.PSubsidioEmpleo

            If resultado >= 0 Then
                CalculoNominaFiscal.PCantidadARetener = resultado
                CalculoNominaFiscal.PSubsidioPorPagar = 0
            Else
                CalculoNominaFiscal.PCantidadARetener = 0
                CalculoNominaFiscal.PSubsidioPorPagar = resultado * (-1)
            End If


            ''CALCULO IMMS
            Dim FechaIngreso As Date = Date.Parse(fila("cono_fechaaltaimss"))
            Dim DiasTrabajados As Integer = (Now.Date - FechaIngreso).TotalDays

            If (DiasTrabajados \ 365) = 0 Then
                CalculoNominaFiscal.PAniosServicio = 1
            Else
                CalculoNominaFiscal.PAniosServicio = DiasTrabajados \ 365
            End If

            ''FACTOR DE INTEGRACION
            tablaFactorIntegracion = objDA.consultar_FactorIntegracion(CalculoNominaFiscal.PAniosServicio)
            For Each dato As DataRow In tablaFactorIntegracion.Rows
                CalculoNominaFiscal.PFactorIntegracion = CDec(dato("fact_factorintegracion"))
            Next

            CalculoNominaFiscal.PSalarioBaseCotizacion = CalculoNominaFiscal.PFactorIntegracion * CalculoNominaFiscal.PSalarioDiario
            CalculoNominaFiscal.PExcedentesSalariosMinimos = CalculoNominaFiscal.PSalarioBaseCotizacion - (CalculoNominaFiscal.PSalarioMinimo * 3)

            If CalculoNominaFiscal.PExcedentesSalariosMinimos >= 0 Then
                CalculoNominaFiscal.PTotalPorExcedente = CalculoNominaFiscal.PExcedentesSalariosMinimos * CalculoNominaFiscal.PCuotaPorExcedente
            Else
                CalculoNominaFiscal.PTotalPorExcedente = 0
            End If




            CalculoNominaFiscal.PFactor = (CalculoNominaFiscal.PPrestacionesEnDinero + CalculoNominaFiscal.PGastosMedicosPensionados + CalculoNominaFiscal.PInvalidezYVida + CalculoNominaFiscal.PCesantiaEdadAvanzadaVejez) / 100


            ''CALCULAR DIAS TRABAJADOS - DIAS INCAPACIDAD
            Dim tablaDiasIncapacidad As New DataTable
            tablaDiasIncapacidad = objDA.consultar_DiasIncapacidad(periodoNomID, CalculoNominaFiscal.PColaborador.PColaboradorid)
            Dim diasIcapacidad As Integer
            For Each row As DataRow In tablaDiasIncapacidad.Rows
                diasIcapacidad = CInt(row("dias_incapacidad"))
            Next
            CalculoNominaFiscal.PDiasTrabajadosMasAusentismosMenosIncapacidad = 7 - diasIcapacidad

            CalculoNominaFiscal.PTotalARetener = (CalculoNominaFiscal.PSalarioBaseCotizacion * CalculoNominaFiscal.PFactor * CalculoNominaFiscal.PDiasTrabajadosMasAusentismosMenosIncapacidad) + CalculoNominaFiscal.PTotalPorExcedente

            ''CALCULA DIAS BIMESTRE
            Dim anio_actual As Integer = Now.Year
            Dim fecha_inicio_bimestre, fecha_termino_bimestre As Date
            Dim mes As Integer = Now.Month
            If mes = 1 Or mes = 2 Then
                fecha_inicio_bimestre = anio_actual.ToString + "-01-01"
                fecha_termino_bimestre = anio_actual.ToString + "-03-01"
                fecha_termino_bimestre = DateAdd(DateInterval.Day, -1, fecha_termino_bimestre)
                CalculoNominaFiscal.PDiasBimestre = DateDiff(DateInterval.Day, fecha_inicio_bimestre, fecha_termino_bimestre) + 1
            End If
            If mes = 3 Or mes = 4 Then
                fecha_inicio_bimestre = anio_actual.ToString + "-03-01"
                fecha_termino_bimestre = anio_actual.ToString + "-05-01"
                fecha_termino_bimestre = DateAdd(DateInterval.Day, -1, fecha_termino_bimestre)
                CalculoNominaFiscal.PDiasBimestre = DateDiff(DateInterval.Day, fecha_inicio_bimestre, fecha_termino_bimestre) + 1
            End If
            If mes = 5 Or mes = 6 Then
                fecha_inicio_bimestre = anio_actual.ToString + "-05-01"
                fecha_termino_bimestre = anio_actual.ToString + "-07-01"
                fecha_termino_bimestre = DateAdd(DateInterval.Day, -1, fecha_termino_bimestre)
                CalculoNominaFiscal.PDiasBimestre = DateDiff(DateInterval.Day, fecha_inicio_bimestre, fecha_termino_bimestre) + 1
            End If
            If mes = 7 Or mes = 8 Then
                fecha_inicio_bimestre = anio_actual.ToString + "-07-01"
                fecha_termino_bimestre = anio_actual.ToString + "-09-01"
                fecha_termino_bimestre = DateAdd(DateInterval.Day, -1, fecha_termino_bimestre)
                CalculoNominaFiscal.PDiasBimestre = DateDiff(DateInterval.Day, fecha_inicio_bimestre, fecha_termino_bimestre) + 1
            End If
            If mes = 9 Or mes = 10 Then
                fecha_inicio_bimestre = anio_actual.ToString + "-09-01"
                fecha_termino_bimestre = anio_actual.ToString + "-11-01"
                fecha_termino_bimestre = DateAdd(DateInterval.Day, -1, fecha_termino_bimestre)
                CalculoNominaFiscal.PDiasBimestre = DateDiff(DateInterval.Day, fecha_inicio_bimestre, fecha_termino_bimestre) + 1
            End If
            If mes = 11 Or mes = 12 Then
                fecha_inicio_bimestre = anio_actual.ToString + "-11-01"
                fecha_termino_bimestre = anio_actual.ToString + "-12-31"
                ' fecha_termino_bimestre = DateAdd(DateInterval.Day, -1, fecha_termino_bimestre)
                CalculoNominaFiscal.PDiasBimestre = DateDiff(DateInterval.Day, fecha_inicio_bimestre, fecha_termino_bimestre) + 1
            End If

            CalculoNominaFiscal.PSalarioBimestral = CalculoNominaFiscal.PSalarioDiario * CalculoNominaFiscal.PDiasBimestre


            If CBool(fila("cono_infonavit")) Then
                CalculoNominaFiscal.PTipoCredito = CInt(fila("cono_infonavit_tipo"))

                If CalculoNominaFiscal.PTipoCredito = 1 Then

                    CalculoNominaFiscal.PPorcentajeRetencion = CDec(fila("cono_infonavit_monto") / 100)

                    CalculoNominaFiscal.PImporteBimestral = CalculoNominaFiscal.PSalarioBimestral * CalculoNominaFiscal.PPorcentajeRetencion
                    CalculoNominaFiscal.PImporteBimestralRetener = CalculoNominaFiscal.PImporteBimestral + CalculoNominaFiscal.PSeguroVivienda

                    CalculoNominaFiscal.PRetencionDiario = CalculoNominaFiscal.PImporteBimestralRetener / CalculoNominaFiscal.PDiasBimestre
                    CalculoNominaFiscal.PRetencionSemanal = CalculoNominaFiscal.PRetencionDiario * CalculoNominaFiscal.PDiasTrabajadosMasAusentismosMenosIncapacidad

                End If

                If CalculoNominaFiscal.PTipoCredito = 2 Then

                    CalculoNominaFiscal.PFactorDescuento = CDec(fila("cono_infonavit_monto"))

                    CalculoNominaFiscal.PRetencionMensual = CalculoNominaFiscal.PSalarioMinimo * CalculoNominaFiscal.PFactorDescuento
                    CalculoNominaFiscal.PImporteBimestral = CalculoNominaFiscal.PRetencionMensual * 2
                    CalculoNominaFiscal.PImporteBimestralRetener = CalculoNominaFiscal.PImporteBimestral + CalculoNominaFiscal.PSeguroVivienda

                    CalculoNominaFiscal.PRetencionDiario = CalculoNominaFiscal.PImporteBimestralRetener / CalculoNominaFiscal.PDiasBimestre
                    CalculoNominaFiscal.PRetencionSemanal = CalculoNominaFiscal.PRetencionDiario * CalculoNominaFiscal.PDiasTrabajadosMasAusentismosMenosIncapacidad

                End If

                If CalculoNominaFiscal.PTipoCredito = 3 Then
                    CalculoNominaFiscal.PCuotaFijaINFONAVIT = CDec(fila("cono_infonavit_monto"))

                    CalculoNominaFiscal.PRetencionMensual = CalculoNominaFiscal.PCuotaFijaINFONAVIT
                    CalculoNominaFiscal.PImporteBimestral = CalculoNominaFiscal.PRetencionMensual * 2
                    CalculoNominaFiscal.PImporteBimestralRetener = CalculoNominaFiscal.PImporteBimestral + CalculoNominaFiscal.PSeguroVivienda

                    CalculoNominaFiscal.PRetencionDiario = CalculoNominaFiscal.PImporteBimestralRetener / CalculoNominaFiscal.PDiasBimestre
                    CalculoNominaFiscal.PRetencionSemanal = CalculoNominaFiscal.PRetencionDiario * CalculoNominaFiscal.PDiasTrabajadosMasAusentismosMenosIncapacidad

                End If

            Else
                CalculoNominaFiscal.PPorcentajeRetencion = Decimal.Zero
                CalculoNominaFiscal.PTipoCredito = 0

            End If



            consultar_DatosBasicosColaboradores.Add(CalculoNominaFiscal)



        Next

    End Function

    Public Function consulta_configuracionNominaFiscal() As List(Of Entidades.CalculoNominaFiscal)
        ''SACA LO DE LA CONFIGURACION NOMINA FISCAL
        Dim CalculoNominaFiscal As New Entidades.CalculoNominaFiscal

        consulta_configuracionNominaFiscal = New List(Of Entidades.CalculoNominaFiscal)

        Dim tablaConfiguracionNominaFiscal As New DataTable
        Dim objDA As New Datos.CalculoNominaFiscalDA
        tablaConfiguracionNominaFiscal = objDA.consultar_ConfiguracionNominaFiscal

        For Each row As DataRow In tablaConfiguracionNominaFiscal.Rows

            CalculoNominaFiscal.PDespensa = CDec(row("cfis_bonodespensa"))
            CalculoNominaFiscal.PCuotaPorExcedente = CDec(row("cfis_cuotaexcedenteimss"))
            CalculoNominaFiscal.PPrestacionesEnDinero = CDec(row("cfis_prestacionesdinero"))
            CalculoNominaFiscal.PGastosMedicosPensionados = CDec(row("cfis_gastosmedicospensionados"))
            CalculoNominaFiscal.PInvalidezYVida = CDec(row("cfis_invalidezvida"))
            CalculoNominaFiscal.PCesantiaEdadAvanzadaVejez = CDec(row("cfis_cesantia"))
            CalculoNominaFiscal.PSalarioMinimo = CDec(row("cfis_salarioA"))
            CalculoNominaFiscal.PSeguroVivienda = CDec(row("cfis_segurovivienda"))
            CalculoNominaFiscal.PDiasAnio = CInt(row("cfis_diasAnio"))

            If IsDBNull(row("cfis_iniciovacaciones1")) Then

            Else
                CalculoNominaFiscal.PInicioVacaciones1 = CDate(row("cfis_iniciovacaciones1"))
            End If

            If IsDBNull(row("cfis_finvacaciones1")) Then

            Else
                CalculoNominaFiscal.PfinVacaciones1 = CDate(row("cfis_finvacaciones1"))
            End If

            consulta_configuracionNominaFiscal.Add(CalculoNominaFiscal)
        Next


    End Function



End Class
