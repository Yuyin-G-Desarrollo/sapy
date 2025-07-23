Imports CrystalDecisions.Shared
Imports Stimulsoft.Report
Imports Tools

Public Class CalculoNominaRealForm
    Dim pagoSeptimoDia As String = ""
    Dim pagoGratificacionAsistencia As String = ""
    Dim generarRegistroNoCheca As Boolean
    Dim configOrigenIMSS As String = ""
    Dim configValidaIncapacidad As Boolean

    Dim listaLiquidarGratificaciones As New List(Of Entidades.CalcularNominaReal)
    Dim listaRecibosDiaFestivo As New List(Of Entidades.CalcularNominaReal)
    Dim listaNegativos As New List(Of Integer)
    Dim listaDepositoEfectivo As New List(Of Entidades.CalcularNominaReal)
    Dim ContadorDepositos As Integer = 0
    Dim NaveIDSICY As Integer = 0
    Dim FinSemanaNomina As DateTime
    Dim IMSSLimite(,) As Double
    Dim RangoAsistenciaCheck(,) As Double
    Dim limiteMatriz As Integer
    Dim LimiteAsistencia As Integer
    Dim iterador As Integer = 0
    Dim estaMal As Integer = 0
    Dim iteradorAsis As Integer = 0
    Dim contadorDestajos As Integer = 0
    Dim Interes2 As Double = 0
    Dim RetencionSemanal As Double = 0
    Dim montoIMSS As Double = 0
    Dim numSS As String = ""
    Dim FechaInicio As DateTime
    Dim fechaFinal As DateTime
    Dim naveSICYID As String

    Dim TotalPuntualidadAsistencia2 As Double = 0
    Dim TotalGratificaciones2 As Double = 0
    Dim TotalCajaAhorro2 As Double = 0
    Dim TotalIMSS2 As Double = 0
    Dim TotalInfonavit2 As Double = 0
    Dim TotalPrestamos2 As Double = 0
    Dim TotalOtrasDeducciones2 As Double = 0
    Dim TotalTotalEntregar2 As Double = 0
    Dim contadorFilas2 As Integer = 0
    Dim Totalausentismos2 As Double = 0
    Dim TotalpagoBruto As Double = 0

    ''Esta varaiable asigna el parametro al reporte
    Dim Parametros As New ParameterFields()

    ''Esta variable indica el nombre del parametro que se encuentra en el procedimiento almacenado
    Dim IdNave As New ParameterField()
    Dim PeriodoNominaID As New ParameterField()
    Dim Colaborador As New ParameterField()
    Dim ruta As New ParameterField()

    Dim UserName As New ParameterField()
    Dim NombreArchivo As New ParameterField()
    Dim Nave As New ParameterField()
    Dim PeriodoNomina As New ParameterField()



    Dim TotalPuntualidadAsistencia3 As New ParameterField()
    Dim TotalGratificaciones3 As New ParameterField()
    Dim TotalCajaAhorro3 As New ParameterField()
    Dim TotalIMSS3 As New ParameterField()
    Dim TotalInfonavit3 As New ParameterField()
    Dim TotalPrestamos3 As New ParameterField()
    Dim TotalOtrasDeducciones3 As New ParameterField()
    Dim TotalTotalEntregar3 As New ParameterField()
    Dim contadorFilas3 As New ParameterField()
    Dim Totalausentismos3 As New ParameterField()
    Dim TotalpagoBruto3 As New ParameterField()


    ''Esta variable toma el valor dle parametro
    Dim myDiscreteValueColaborador As New ParameterDiscreteValue()
    Dim myDiscreteValueIdNave As New ParameterDiscreteValue()
    Dim myDiscreteValuePeriodoNominaID As New ParameterDiscreteValue()
    Dim myDiscreteValueRuta As New ParameterDiscreteValue()

    Dim myDiscreteValueUserName As New ParameterDiscreteValue()
    Dim myDiscreteValueNombreArchivo As New ParameterDiscreteValue()
    Dim myDiscreteValueNave As New ParameterDiscreteValue()
    Dim myDiscreteValuePeriodoNomina As New ParameterDiscreteValue()


    Dim myDiscreteValueTotalPuntualidadAsistencia3 As New ParameterDiscreteValue()
    Dim myDiscreteValueTotalGratificaciones3 As New ParameterDiscreteValue()
    Dim myDiscreteValueTotalCajaAhorro3 As New ParameterDiscreteValue()
    Dim myDiscreteValueTotalIMSS3 As New ParameterDiscreteValue()
    Dim myDiscreteValueTotalInfonavit3 As New ParameterDiscreteValue()
    Dim myDiscreteValueTotalPrestamos3 As New ParameterDiscreteValue()
    Dim myDiscreteValueTotalOtrasDeducciones3 As New ParameterDiscreteValue()
    Dim myDiscreteValueTotalTotalEntregar3 As New ParameterDiscreteValue()
    Dim myDiscreteValueTotalausentismos3 As New ParameterDiscreteValue()
    Dim myDiscreteValueTotalpagoBruto3 As New ParameterDiscreteValue()


    Dim accionSemana As New ParameterField()
    Dim valorAsignadoAccionEfectivo As New ParameterDiscreteValue()

    Dim semanaPeriodo As String

    Dim cambioTipoPago As Boolean = False

    Private Sub CalculoNominaRealForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        'Tools.FormatoCtrls.formato(Me)
        Try


            Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            'ImprimirReporteGeneralAgrupadoToolStripMenuItem.Visible = False
            cmbDepartamento.Visible = False
            cmbArea.Visible = False
            txtColaborador.Visible = False
            lblcolaborador.Visible = False
            lblarea.Visible = False
            lblDepartamento.Visible = False

            btnGuardar.Enabled = False
            ''Labels
            lblIdSemanaNomina.Visible = False
            lblPeriodoAsistencia.Visible = False
            lblPeriodoPrestamos.Visible = False
            lblPeriodoCajaAhorro.Visible = False
            lblSemanaNominaFIN.Visible = False
            lblPeriodoDeducciones.Visible = False
            lblPeriodoFiscal.Visible = False

            If cmbNave.SelectedValue > 0 Then
                cmbNaveDrop()
                IMSSLimitesSI()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNave.DropDownClosed
        Try
            'If cmbNave.SelectedValue = 3 Then
            ImprimirReporteGeneralAgrupadoToolStripMenuItem.Visible = True
            'Else
            '    ImprimirReporteGeneralAgrupadoToolStripMenuItem.Visible = False
            'End If





            cmbNaveDrop()
            IMSSLimitesSI()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbArea_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.DropDownClosed
        Try
            Tools.Controles.ComboDepartamentosSegunArea(cmbDepartamento, cmbArea.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub AgregarFilaColaboradoresNominaReal(ByVal Nomina As List(Of Entidades.CalcularNominaReal), ByVal imprimir As Boolean)

        Try
            Dim ObjBU As New Nomina.Negocios.CalcularNominaRealBU
            Dim resultado As String = String.Empty
            Dim objMensajeAdv As New Tools.AdvertenciaForm
            listaRecibosDiaFestivo.Clear()
            listaLiquidarGratificaciones.Clear()
            listaDepositoEfectivo.Clear()
            Dim numerodeDatos As List(Of Integer) = Nomina.Select(Function(c) c.PColaborador.PColaboradorid).Distinct.ToList
            grdDeducciones.Rows.Clear()
            cambioTipoPago = ObjBU.validacambioTipoPagoAplicado(CInt(lblIdSemanaNomina.Text))

            Dim rowCount As Integer = 0
            For Each numerodeColaboradores As Integer In numerodeDatos

                ''DATOS REALES
                Dim TipoSueldo As String
                Dim FechaIngreso As DateTime
                Dim colaboradorID As Integer = numerodeColaboradores
                Dim descripcion As String = ""
                Dim ColaboradorTipo As String
                Dim SalarioReal As Double
                Dim salarioDiario As Double = 0
                Dim salarioDiarioReal As Double = 0
                Dim MontoHorasExtras As Double = 0
                Dim SalarioRegistrado As Double = 0
                Dim idCelula As Integer = 0
                Dim costoFraccion As Double = 0
                Dim pares As Integer = 0
                Dim FechaNacDia As Integer
                Dim FechaNacMes As Integer
                Dim GratificacionFechaNac As Double = 0

                ''Asistencia
                Dim inasis As Double = 0
                Dim inasis2 As Double = 0

                Dim incapacidades As Double = 0

                Dim ausentismos As Double = 0
                ''IMSS
                montoIMSS = 0
                numSS = ""

                'Iteradores 
                Dim iteradorLimite As Integer = 0
                Dim iteradorLimite2 As Integer = 0

                ''Caja de ahoro
                Dim cajaAhorro As Double = 0

                ''Prestamo
                Dim prestamoMonto As Double = 0
                Dim TipoInteres As String = ""
                Dim Interes As Double = 0
                Interes2 = 0
                Dim saldo As Double = 0
                Dim pagoTotal As Double = 0

                ''Gratificaciones
                Dim GratificacionesMonto As Double = 0

                ''PUNTUALIDAD Y ASISTENCIA
                Dim DiasTrabajados As Double = 7
                Dim asistencia As Boolean = False
                Dim MontoAsistencia As Double = 0

                ''infonavit
                Dim porcentajeRetencion As Double = 0
                Dim ImporteBimestral As Double = 0
                Dim ImporteBimestralRetener As Double = 0
                Dim RetencionAnual As Double = 0
                Dim RetencionDiaria As Double = 0
                RetencionSemanal = 0
                Dim RetencionMensual As Double = 0

                ''Totales
                Dim Totalpercepciones As Double = 0
                Dim TotalDeducciones As Double = 0
                ''Dim OtrasDeducciones As Double = 0
                Dim TotalEntregar As Double = 0
                Dim TotalSueldoSemanal As Double = 0
                Dim TotalDestajos As Double = 0
                Dim TotalBanda As Double = 0

                ''LISTAS
                Dim listaCajaAhorro As List(Of Entidades.CalcularNominaReal)
                Dim listaprestamos As List(Of Entidades.CalcularNominaReal)
                'Dim listaIncentivos As List(Of Entidades.CalcularNominaReal)
                Dim listaConfIncentivos As List(Of Entidades.CalcularNominaReal)
                Dim listaDeducciones As List(Of Entidades.CalcularNominaReal)
                Dim listaAsistencia As List(Of Entidades.CalcularNominaReal)
                Dim listaPorcentajeAsistencia As List(Of Entidades.CalcularNominaReal)
                Dim listaFiniquitos As List(Of Entidades.CalcularNominaReal)
                ''Dim listaHorasExtra As List(Of Entidades.CalcularNominaReal)
                Dim listaConfiguracionNominaFiscal As List(Of Entidades.CalculoNominaFiscal)
                Dim listaColaboradorLaboral As List(Of Entidades.CalcularNominaReal)
                ' Dim listaSalarioDestajos As List(Of Entidades.CalcularNominaReal)
                '    Dim listaSalarioBanda As List(Of Entidades.CalcularNominaReal)

                Dim objNominaBU As New Negocios.CalcularNominaRealBU
                Dim objE As Entidades.CalcularNominaReal = Nomina.Find(Function(c) c.PColaborador.PColaboradorid = colaboradorID)
                Dim colaboradorNom As String = objE.PColaborador.PNombre + " " + objE.PColaborador.PApaterno + " " + objE.PColaborador.PAmaterno


                'Dim objBU As New Negocios.CalcularNominaRealBU
                Dim TablaConfiguracion As DataTable = ObjBU.configuracionNomina(cmbNave.SelectedValue)

                pagoGratificacionAsistencia = TablaConfiguracion.Rows(0).Item("conf_gratificacionpuntualidad").ToString
                pagoSeptimoDia = TablaConfiguracion.Rows(0).Item("conf_pagoSeptimoDia").ToString
                generarRegistroNoCheca = CBool(TablaConfiguracion.Rows(0).Item("nave_generarRegistroNoCheca").ToString)
                configOrigenIMSS = TablaConfiguracion.Rows(0).Item("conf_origenIMSS").ToString
                configValidaIncapacidad = CBool(TablaConfiguracion.Rows(0).Item("conf_descuentosincapacidad").ToString)

                SalarioRegistrado = 0
                ''DATOS REALES
                SalarioRegistrado = objE.PSalarioReal
                FechaIngreso = objE.PFechaIngreso
                salarioDiario = objE.PSalarioDiario
                ColaboradorTipo = objE.PRealTipo.ToString
                TipoSueldo = objE.PTipoSueldo.ToString
                idCelula = objE.PCelulaID
                FechaNacMes = objE.PFechaNac.Month
                FechaNacDia = objE.PFechaNac.Day
                ''Dim fechaNac2 As String = FechaNacDia.ToString + "-" + FechaNacMes.ToString + "-" + FechaInicio.Year.ToString
                Dim fechaNac2 As String
                If FechaNacMes.ToString = "2" And FechaNacDia.ToString = "29" Then
                    fechaNac2 = "28-" + FechaNacMes.ToString + "-" + FechaInicio.Year.ToString
                Else
                    fechaNac2 = FechaNacDia.ToString + "-" + FechaNacMes.ToString + "-" + FechaInicio.Year.ToString
                End If
                Dim FechaNac As DateTime = CDate(fechaNac2)


                ''QUE HAYA ENTRADO DENTRO DE ESTE PERIODO DE NOMINA
                If FechaIngreso <= fechaFinal Then

                    '' COLABORADOR POR DESTAJOS TOTAL DESTAJOS
                    If ColaboradorTipo = "DESTAJO" Then
                        Dim tablaSalarioDestajo As DataTable
                        '' obtener destajos inicia
                        '' listaSalarioDestajos = objNominaBU.ListaDestajos(colaboradorID, lblIdSemanaNomina.Text)
                        tablaSalarioDestajo = objNominaBU.salarioCierreDestajo(colaboradorID, lblIdSemanaNomina.Text)
                        For Each Dato As DataRow In tablaSalarioDestajo.Rows
                            TotalDestajos += Dato.Item("dest_totalpagar")
                        Next
                        SalarioRegistrado = TotalDestajos
                    End If

                    ''COLABORADOR POR BANDA TOTAL BANDA
                    costoFraccion = objE.PcostoFraccion
                    If ColaboradorTipo = "POR BANDA" Then
                        Dim tablaBandatbl As New DataTable
                        tablaBandatbl = objNominaBU.calculoNetoBanda(colaboradorID, lblIdSemanaNomina.Text, objE.PCelulaIDSAY)

                        '     listaSalarioBanda = objNominaBU.PorBandaTotalLotes(colaboradorID, NaveIDSICY, idCelula, FechaInicio, fechaFinal, Now.Year)

                        'For Each Dato As Entidades.CalcularNominaReal In listaSalarioBanda
                        '    pares += Dato.PTotalParesLotes
                        '    TotalBanda = costoFraccion * pares
                        'Next
                        For Each row As DataRow In tablaBandatbl.Rows
                            TotalBanda += row.Item("totalAPAgar")
                        Next
                        SalarioRegistrado = TotalBanda

                    End If

                    ''while para saber la cuota de imss que se le descontara inicia
                    numSS = objE.PNumeroSS

                    If IsNothing(numSS) Then
                        numSS = ""
                    End If

                    'If objE.PAsegurado = False Then
                    '    'If numSS.Length <= 5 Then
                    '    montoIMSS = 0
                    'Else
                    '    'If CInt(cmbNave.SelectedValue) = 43 Or CInt(cmbNave.SelectedValue) = 73 Then
                    '    If configOrigenIMSS = "NOMINA_FISCAL" Then

                    montoIMSS = objE.PRetencionIMMS

                    '    Else
                    '        While iteradorLimite <= iterador
                    '            If salarioDiario >= IMSSLimite(iteradorLimite, 1) And salarioDiario <= IMSSLimite(iteradorLimite, 2) Then
                    '                montoIMSS = IMSSLimite(iteradorLimite, 3)
                    '                Exit While
                    '            Else
                    '                If salarioDiario >= IMSSLimite(iteradorLimite, 2) And iteradorLimite = iterador Then

                    '                    montoIMSS = RealziarCalculoRetencionFiscalIMSS(colaboradorID, salarioDiario, FechaIngreso)
                    '                    Exit While
                    '                End If
                    '            End If
                    '            iteradorLimite += 1
                    '        End While
                    '    End If
                    'End If





                    ''while para saber la cuota de imss que se le descontara termina


                    ''OBTENER LA CAJA DE AHORRO INICIA
                    listaCajaAhorro = objNominaBU.CajaDeAhorro(colaboradorID, lblIdSemanaNomina.Text)
                    Dim ObjCaja As List(Of Double) = listaCajaAhorro.Select(Function(c) c.PCajaAhorro.pMontoAhorro).Distinct.ToList
                    For Each monto As Double In ObjCaja
                        cajaAhorro = monto
                    Next
                    ''OBTENER LA CAJA DE AHORRO TERMINA


                    ''OBTENER PRESTAMO

                    listaprestamos = objNominaBU.prestamos(colaboradorID, lblIdSemanaNomina.Text)

                    ''Dim objPres As List(Of Double) = listaprestamos.Select(Function(c) c.PPrestamos.Pmontoprestamo).Distinct.ToList
                    For Each prestamo As Entidades.CalcularNominaReal In listaprestamos
                        pagoTotal += prestamo.PPrestamos.PPagoTotal
                        prestamoMonto += prestamo.PPrestamos.Pmontoprestamo
                        TipoInteres += prestamo.PPrestamos.Ptipointeres
                        Interes += prestamo.PPrestamos.Pinteres
                        saldo += prestamo.PPrestamos.Psaldo

                        Interes = 7 * (Interes / 30.4)
                        Interes = Interes / 100
                        ''INTERES QUE PAGARA INICIA
                        If TipoInteres.Equals("I") Then
                            Interes2 += 0
                        Else
                            If TipoInteres.Equals("F") Then
                                Interes2 += prestamoMonto * Interes
                            Else
                                If TipoInteres.Equals("S") Then
                                    Interes2 += saldo * Interes
                                End If
                            End If
                        End If
                        ''INTERES QUE PAGARA TERMINA
                    Next

                    ''OBTENER PRESTAMO

                    ' ''obtener HorasExtra inicia
                    'listaHorasExtra = objNominaBU.HorasExtras(colaboradorID, lblIdSemanaNomina.Text)
                    'Dim objHoras As List(Of Double) = listaHorasExtra.Select(Function(c) c.PHorasExtras.PMonto).Distinct.ToList
                    'For Each horas As Double In objHoras
                    '    MontoHorasExtras = horas
                    'Next
                    ' ''obtener HorasExtra termina

                    'obtener incentivo inicia
                    'obtener incentivo inicia
                    'obtener incentivo inicia


                    listaConfIncentivos = objNominaBU.gratificacionesConfiguracion(cmbNave.SelectedValue)

                    Dim confGratificacion As Boolean = False
                    Dim GratificacionGerente As Boolean = False
                    Dim GratificacionDirector As Boolean = False
                    Dim GratificacionCumple As Boolean = False
                    Dim estatus As String = ""

                    For Each dato As Entidades.CalcularNominaReal In listaConfIncentivos
                        confGratificacion = dato.PGratificacionConfiguracion
                        GratificacionGerente = dato.PGratificacionGerente
                        GratificacionDirector = dato.PGratificacionDirector
                        GratificacionCumple = dato.PGratificacionCumpleanios
                    Next


                    If GratificacionDirector = True Then
                        estatus = "C"
                    Else
                        estatus = "B"

                    End If

                    'listaIncentivos = objNominaBU.gratificaciones(colaboradorID, estatus, FechaInicio, fechaFinal, lblIdSemanaNomina.Text)
                    Dim tablaGratificaciones
                    tablaGratificaciones = objNominaBU.gratificacionesNomina(cmbNave.SelectedValue, colaboradorID, CInt(lblIdSemanaNomina.Text))

                    For Each row As DataRow In tablaGratificaciones.rows
                        Try
                            GratificacionesMonto += row(0)
                        Catch
                            GratificacionesMonto += 0
                        End Try
                    Next

                    'For Each gratificaciones As Entidades.CalcularNominaReal In listaIncentivos

                    '    If gratificaciones.PMotivoGratificacion = "TRABAJO DIA FESTIVO" Then
                    '        GratificacionesMonto += objE.PSalarioReal / 7
                    '        listaRecibosDiaFestivo.Add(objE)
                    '        listaLiquidarGratificaciones.Add(gratificaciones)
                    '    End If

                    '    If gratificaciones.PMotivoGratificacion = "TRABAJO MEDIO DIA FESTIVO" Then
                    '        GratificacionesMonto += (objE.PSalarioReal / 7) / 2
                    '        listaRecibosDiaFestivo.Add(objE)
                    '        listaLiquidarGratificaciones.Add(gratificaciones)
                    '    End If

                    '    If confGratificacion = True Then
                    '        If gratificaciones.PMotivoGratificacion <> "TRABAJO MEDIO DIA FESTIVO" Or gratificaciones.PMotivoGratificacion <> "TRABAJO DIA FESTIVO" Then
                    '            GratificacionesMonto += gratificaciones.PMontoGratificacion
                    '            listaLiquidarGratificaciones.Add(gratificaciones)
                    '        End If
                    '    End If
                    'Next

                    ''Dia cumpleaños
                    For Each datoC As Entidades.CalcularNominaReal In listaConfIncentivos
                        If datoC.PGratificacionCumpleanios = True Then
                            GratificacionCumple = True
                        End If

                    Next

                    If GratificacionCumple = True Then
                        If FechaNac >= FechaInicio And FechaNac <= fechaFinal Then
                            GratificacionFechaNac = objE.PSalarioReal / 7
                            If cmbNave.SelectedValue = 43 Then
                                descripcion += "Cumpleaños"
                            End If
                        Else
                            GratificacionFechaNac = 0
                        End If
                    End If

                    GratificacionesMonto += GratificacionFechaNac

                    'obtener incentivo termina

                    ''Obtener faltas inicia
                    Dim retardoMenor As Double = 0
                    Dim retardoMayor As Double = 0

                    If pagoGratificacionAsistencia = False Then

                        'jeans
                        SalarioRegistrado += GratificacionesMonto
                    End If


                    'comer

                    If objE.PCheca = False And generarRegistroNoCheca = False Then
                        inasis = 0
                        retardoMayor = 0
                        retardoMenor = 0
                        DiasTrabajados = 0
                        asistencia = True

                        ''TODO PERFECT
                        If objE.PGanaIncentivos = True And objE.PGanaIncentivosSiempre = True Then
                            listaPorcentajeAsistencia = objNominaBU.PorcentajeAsistencia(cmbNave.SelectedValue, 0, 1)
                            For Each porcentaje As Entidades.CalcularNominaReal In listaPorcentajeAsistencia
                                MontoAsistencia = porcentaje.PIncentivoPuntualidad
                                MontoAsistencia = MontoAsistencia / 100
                                MontoAsistencia = SalarioRegistrado * MontoAsistencia
                            Next
                        ElseIf objE.PGanaIncentivos = False Then
                            MontoAsistencia = 0
                        End If


                    ElseIf objE.PCheca = True Or (objE.PCheca = False And generarRegistroNoCheca = True) Then
                        If objE.PGanaIncentivosSiempre = True Then
                            listaPorcentajeAsistencia = objNominaBU.PorcentajeAsistencia(cmbNave.SelectedValue, 0, 1)
                            For Each porcentaje As Entidades.CalcularNominaReal In listaPorcentajeAsistencia
                                '   SalarioRegistrado = objE.PSalarioReal
                                MontoAsistencia = porcentaje.PIncentivoPuntualidad
                                MontoAsistencia = MontoAsistencia / 100
                                MontoAsistencia = SalarioRegistrado * MontoAsistencia
                            Next
                        ElseIf objE.PGanaIncentivos = True Then
                            listaAsistencia = objNominaBU.checador(colaboradorID, lblIdSemanaNomina.Text)


                            If listaAsistencia.Count = 0 Then
                                DiasTrabajados = 0
                                inasis = 7
                                inasis2 = 7
                            Else


                                ''FOR pasa saber el incentivo de puntualidad que se le dara INICIA
                                For Each Puntualidad As Entidades.CalcularNominaReal In listaAsistencia
                                    asistencia = Puntualidad.Pchecador.PPpuntualidad_asistencia
                                    ' SalarioRegistrado = objE.PSalarioReal
                                    Dim diasTrabajados2 As Double = 0
                                    diasTrabajados2 = Puntualidad.Pchecador.PAsistencia
                                    DiasTrabajados = Puntualidad.Pchecador.PAsistencia

                                    Dim checkAsistencia As Boolean = Puntualidad.Pchecador.PPpuntualidad_asistencia
                                    inasis = Puntualidad.Pchecador.PInasistencia
                                    inasis2 = Puntualidad.Pchecador.PInasistencia
                                    retardoMenor = Puntualidad.Pchecador.PRetardo_menor
                                    retardoMayor = Puntualidad.Pchecador.PRetardo_mayor


                                    ''NUMERO DE FALTAS Y EL PROPORCIANAL DOMINGO
                                    ''NUMERO DE FALTAS Y EL PROPORCIANAL DOMINGO
                                    ''NUMERO DE FALTAS Y EL PROPORCIANAL DOMINGO
                                    ''NUMERO DE FALTAS Y EL PROPORCIANAL DOMINGO

                                    '' validacion para saber el numero de dias que tendra la semana


                                    Dim totalDomingo As Double = 0

                                    If pagoSeptimoDia = "A" Then
                                        ''A=pago proporcional del domingo
                                        Dim validarCalculo As Integer = 0
                                        listaFiniquitos = objNominaBU.consultaFiniquitosActivos(colaboradorID, FechaInicio, fechaFinal)
                                        For Each dato As Entidades.CalcularNominaReal In listaFiniquitos
                                            validarCalculo += 1
                                        Next
                                        If FechaIngreso >= FechaInicio And FechaIngreso <= fechaFinal Then
                                            validarCalculo += 1
                                        End If

                                        If validarCalculo > 0 Then

                                            totalDomingo = 1 / 6
                                            DiasTrabajados = DiasTrabajados + (DiasTrabajados * totalDomingo)
                                            If DiasTrabajados = 0 Then
                                                inasis = 7
                                                inasis2 = 7
                                            Else
                                                If Puntualidad.Pchecador.PAsistencia = 7 Then
                                                    inasis = 0
                                                Else
                                                    inasis = Puntualidad.Pchecador.PInasistencia
                                                    inasis2 = inasis
                                                    inasis += (inasis * totalDomingo)

                                                End If
                                            End If
                                            If inasis < 0 Then
                                                inasis = 0
                                                inasis2 = inasis
                                            End If
                                        Else
                                            If DiasTrabajados = 0 Then
                                                inasis = 7
                                                inasis2 = 7
                                            End If
                                        End If

                                    ElseIf pagoSeptimoDia = "B" Then
                                        ''SIEMPRE SE PAGA COMPLETO EL DOMINGO
                                        If DiasTrabajados = 0 Then
                                            inasis = 7
                                            inasis2 = 7
                                        Else
                                            DiasTrabajados += 1
                                            diasTrabajados2 += 1
                                        End If
                                        If inasis = 0 Then
                                            DiasTrabajados = 7
                                            diasTrabajados2 = 7
                                        End If
                                    End If
                                    If asistencia = False Then
                                        MontoAsistencia = 0
                                    Else
                                        If inasis > 0 Then
                                            listaPorcentajeAsistencia = objNominaBU.PorcentajeAsistencia(cmbNave.SelectedValue, inasis, 6)
                                            For Each porcentaje As Entidades.CalcularNominaReal In listaPorcentajeAsistencia
                                                MontoAsistencia = porcentaje.PIncentivoPuntualidad
                                                MontoAsistencia = MontoAsistencia / 100
                                                MontoAsistencia = SalarioRegistrado * MontoAsistencia
                                            Next
                                        Else
                                            If retardoMayor > 0 Then
                                                listaPorcentajeAsistencia = objNominaBU.PorcentajeAsistencia(cmbNave.SelectedValue, retardoMayor, 3)
                                                For Each porcentaje As Entidades.CalcularNominaReal In listaPorcentajeAsistencia
                                                    MontoAsistencia = porcentaje.PIncentivoPuntualidad
                                                    MontoAsistencia = MontoAsistencia / 100
                                                    MontoAsistencia = SalarioRegistrado * MontoAsistencia
                                                Next
                                            Else
                                                If retardoMenor > 0 Then
                                                    listaPorcentajeAsistencia = objNominaBU.PorcentajeAsistencia(cmbNave.SelectedValue, retardoMenor, 2)
                                                    For Each porcentaje As Entidades.CalcularNominaReal In listaPorcentajeAsistencia
                                                        MontoAsistencia = porcentaje.PIncentivoPuntualidad
                                                        MontoAsistencia = MontoAsistencia / 100
                                                        MontoAsistencia = SalarioRegistrado * MontoAsistencia
                                                    Next
                                                Else
                                                    ''TODO PERFECT
                                                    listaPorcentajeAsistencia = objNominaBU.PorcentajeAsistencia(cmbNave.SelectedValue, 0, 1)
                                                    For Each porcentaje As Entidades.CalcularNominaReal In listaPorcentajeAsistencia
                                                        MontoAsistencia = porcentaje.PIncentivoPuntualidad
                                                        MontoAsistencia = MontoAsistencia / 100
                                                        MontoAsistencia = SalarioRegistrado * MontoAsistencia
                                                    Next

                                                End If
                                            End If
                                        End If
                                    End If
                                Next

                            End If


                        ElseIf objE.PGanaIncentivos = False Then
                            MontoAsistencia = 0

                            listaAsistencia = objNominaBU.checador(colaboradorID, lblIdSemanaNomina.Text)
                            ''FOR pasa saber el incentivo de puntualidad que se le dara INICIA
                            For Each Puntualidad As Entidades.CalcularNominaReal In listaAsistencia
                                asistencia = Puntualidad.Pchecador.PPpuntualidad_asistencia
                                ' SalarioRegistrado = objE.PSalarioReal
                                Dim diasTrabajados2 As Double = 0
                                diasTrabajados2 = Puntualidad.Pchecador.PAsistencia
                                DiasTrabajados = Puntualidad.Pchecador.PAsistencia


                                Dim checkAsistencia As Boolean = Puntualidad.Pchecador.PPpuntualidad_asistencia
                                inasis = Puntualidad.Pchecador.PInasistencia
                                inasis2 = Puntualidad.Pchecador.PInasistencia
                                retardoMenor = Puntualidad.Pchecador.PRetardo_menor
                                retardoMayor = Puntualidad.Pchecador.PRetardo_mayor


                                ''NUMERO DE FALTAS Y EL PROPORCIANAL DOMINGO
                                ''NUMERO DE FALTAS Y EL PROPORCIANAL DOMINGO
                                ''NUMERO DE FALTAS Y EL PROPORCIANAL DOMINGO
                                ''NUMERO DE FALTAS Y EL PROPORCIANAL DOMINGO

                                Dim totalDomingo As Double = 0

                                If pagoSeptimoDia = "A" Then
                                    ''A=pago proporcional del domingo
                                    Dim validarCalculo As Integer = 0
                                    listaFiniquitos = objNominaBU.consultaFiniquitosActivos(colaboradorID, FechaInicio, fechaFinal)
                                    For Each dato As Entidades.CalcularNominaReal In listaFiniquitos
                                        validarCalculo += 1
                                    Next
                                    If FechaIngreso >= FechaInicio And FechaIngreso <= fechaFinal Then
                                        validarCalculo += 1
                                    End If

                                    If validarCalculo > 0 Then

                                        totalDomingo = 1 / 6
                                        DiasTrabajados = DiasTrabajados + (DiasTrabajados * totalDomingo)
                                        If DiasTrabajados = 0 Then
                                            inasis = 7
                                            inasis2 = 7
                                        Else
                                            If Puntualidad.Pchecador.PAsistencia = 7 Then
                                                inasis = 0
                                            Else
                                                inasis = Puntualidad.Pchecador.PInasistencia
                                                inasis2 = inasis
                                                inasis += (inasis * totalDomingo)
                                            End If
                                        End If
                                        If inasis < 0 Then
                                            inasis = 0
                                            inasis2 = inasis
                                        End If
                                    Else
                                        If DiasTrabajados = 0 Then
                                            inasis = 7
                                            inasis2 = 7
                                        End If
                                    End If
                                ElseIf pagoSeptimoDia = "B" Then
                                    ''SIEMPRE SE PAGA COMPLETO EL DOMINGO
                                    If DiasTrabajados = 0 Then
                                        inasis = 7
                                        inasis2 = 7
                                    Else
                                        DiasTrabajados += 1
                                        diasTrabajados2 += 1
                                    End If
                                    'CAMBIO DIAS COMPLETOS
                                    If inasis = 0 Then
                                        DiasTrabajados = 7
                                        diasTrabajados2 = 7
                                    End If
                                End If
                            Next
                        End If
                    End If

                    ''FOR pasa saber el incentivo de puntualidad que se le dara TERMINA
                    ''obtener faltas termina
                    '''''''EL COTORREO DEL IMSS  SI TIENE UN FINIQUITO ACTIVO O DENTRO DEL PERIODO DE NOMINA SOLO LE COBRABRARA LA PARTE PROPORCIONAL DEL IMSS

                    'listaFiniquitos = objNominaBU.consultaFiniquitosActivos(colaboradorID, FechaInicio, fechaFinal)
                    'Dim finiquitoID As Int32 = 0
                    'Dim DiasAsistencia As Double = 7
                    'For Each dato As Entidades.CalcularNominaReal In listaFiniquitos
                    '    finiquitoID = dato.PfiniquitoID
                    'Next

                    'If finiquitoID > 0 Then
                    '    DiasAsistencia = DiasAsistencia - inasis
                    '    montoIMSS = montoIMSS / 7
                    '    montoIMSS = montoIMSS * DiasAsistencia
                    'End If



                    ''OBTENER LAS DEDUCCIONES
                    Dim numeroDeducciones As Integer = 0
                    listaDeducciones = objNominaBU.deduccionesExtraordinaria(colaboradorID, lblIdSemanaNomina.Text)
                    Dim objDeduccionesConcepto As List(Of String) = listaDeducciones.Select(Function(c) c.PDeduccionExtraordinaria.PConceptoDeduccion).Distinct.ToList
                    numeroDeducciones = objDeduccionesConcepto.Count
                    Dim montoDeduExt As Double = 0

                    For Each dedu As Entidades.CalcularNominaReal In listaDeducciones
                        Dim concepto As String = dedu.PDeduccionExtraordinaria.PConceptoDeduccion
                        montoDeduExt += dedu.PDeduccionExtraordinaria.PMontoDeduccion
                        'OtrasDeducciones += monto
                    Next
                    ''OBTENER LAS DEDUCCIONES
                    ' '''''''''''''''OBTENER EL MONTO DE INFORNAVIT A RETENER'''''''''''''''


                    '''''''''''''''OBTENER EL MONTO DE INFORNAVIT A RETENER'''''''''''''''


                    ''Configuracion de la nomina FISCAL
                    Dim nominaFiscalBU As New Nomina.Negocios.CalculoNominaFiscalBU
                    Dim SalarioMinimo As Double = 0
                    Dim SalarioBimestral As Double = 0
                    Dim RetencionVacaciones As Double = 0

                    Dim inicioVacaciones1 As DateTime
                    Dim finvacaciones1 As DateTime

                    Dim seguroVivienda As Double = 0
                    Dim diasAnio As Integer = 0

                    Dim infonavit As Boolean = False
                    Dim infonavitTipo As Integer = 0
                    Dim infonavitMonto As Double = 0

                    ''Meses
                    Dim bimestre1 As Double = 0
                    Dim bimestre2 As Double = 0
                    Dim bimestre3 As Double = 0
                    Dim bimestre4 As Double = 0
                    Dim bimestre5 As Double = 0
                    Dim bimestre6 As Double = 0

                    ''CALCULA DIAS BIMESTRE
                    Dim anio_actual As Integer = Now.Year
                    Dim fecha_inicio_bimestre, fecha_termino_bimestre As Date
                    Dim mes As Integer = Now.Month
                    Dim diasBimenstre As Integer = 0
                    Dim promedioDias As Double = 0
                    Dim anioActual As DateTime = Now.Year.ToString + "-01-01"


                    listaConfiguracionNominaFiscal = nominaFiscalBU.consulta_configuracionNominaFiscal()
                    For Each SalarioMin As Entidades.CalculoNominaFiscal In listaConfiguracionNominaFiscal
                        SalarioMinimo = SalarioMin.PSalarioMinimo
                        seguroVivienda = SalarioMin.PSeguroVivienda
                        diasAnio = SalarioMin.PDiasAnio
                        inicioVacaciones1 = SalarioMin.PInicioVacaciones1
                        finvacaciones1 = SalarioMin.PfinVacaciones1

                    Next


                    listaColaboradorLaboral = objNominaBU.PorcentajeRetencion(colaboradorID)

                    For Each dato As Entidades.CalcularNominaReal In listaColaboradorLaboral
                        'If dato.PFechaInfonavit <= fechaFinal Then
                        infonavit = dato.Pinfornavit
                        infonavitTipo = dato.Pinfonavit_tipo
                        infonavitMonto = dato.Pinfonavit_monto
                        'End If
                    Next

                    FechaIngreso = objE.PFechaIngreso

                    ''si NO entro en este año

                    If mes > 0 Then
                        fecha_inicio_bimestre = anio_actual.ToString + "-01-01"
                        fecha_termino_bimestre = anio_actual.ToString + "-03-01"
                        fecha_termino_bimestre = DateAdd(DateInterval.Day, -1, fecha_termino_bimestre)
                        diasBimenstre = DateDiff(DateInterval.Day, fecha_inicio_bimestre, fecha_termino_bimestre) + 1
                        bimestre1 = diasBimenstre

                    End If
                    If mes > 0 Then
                        fecha_inicio_bimestre = anio_actual.ToString + "-03-01"
                        fecha_termino_bimestre = anio_actual.ToString + "-05-01"
                        fecha_termino_bimestre = DateAdd(DateInterval.Day, -1, fecha_termino_bimestre)
                        diasBimenstre = DateDiff(DateInterval.Day, fecha_inicio_bimestre, fecha_termino_bimestre) + 1
                        bimestre2 = diasBimenstre
                    End If
                    If mes > 0 Then
                        fecha_inicio_bimestre = anio_actual.ToString + "-05-01"
                        fecha_termino_bimestre = anio_actual.ToString + "-07-01"
                        fecha_termino_bimestre = DateAdd(DateInterval.Day, -1, fecha_termino_bimestre)
                        diasBimenstre = DateDiff(DateInterval.Day, fecha_inicio_bimestre, fecha_termino_bimestre) + 1
                        bimestre3 = diasBimenstre
                    End If
                    If mes > 0 Then
                        fecha_inicio_bimestre = anio_actual.ToString + "-07-01"
                        fecha_termino_bimestre = anio_actual.ToString + "-09-01"
                        fecha_termino_bimestre = DateAdd(DateInterval.Day, -1, fecha_termino_bimestre)
                        diasBimenstre = DateDiff(DateInterval.Day, fecha_inicio_bimestre, fecha_termino_bimestre) + 1
                        bimestre4 = diasBimenstre
                    End If
                    If mes > 0 Then
                        fecha_inicio_bimestre = anio_actual.ToString + "-09-01"
                        fecha_termino_bimestre = anio_actual.ToString + "-11-01"
                        fecha_termino_bimestre = DateAdd(DateInterval.Day, -1, fecha_termino_bimestre)
                        diasBimenstre = DateDiff(DateInterval.Day, fecha_inicio_bimestre, fecha_termino_bimestre) + 1
                        bimestre5 = diasBimenstre
                    End If
                    If mes > 0 Then
                        fecha_inicio_bimestre = anio_actual.ToString + "-11-01"
                        fecha_termino_bimestre = anio_actual.ToString + "-12-31"
                        ''fecha_termino_bimestre = DateAdd(DateInterval.Day, -1, fecha_termino_bimestre)
                        diasBimenstre = DateDiff(DateInterval.Day, fecha_inicio_bimestre, fecha_termino_bimestre) + 1
                        bimestre6 = diasBimenstre
                    End If

                    promedioDias = (bimestre1 + bimestre2 + bimestre3 + bimestre4 + bimestre5 + bimestre6) / 6

                    If infonavit = True Then
                        If infonavitTipo = 1 Then
                            ''infonavitMonto
                            Dim ImporteBimestralRetener1 As Double = 0
                            Dim ImporteBimestralRetener2 As Double = 0
                            Dim ImporteBimestralRetener3 As Double = 0
                            Dim ImporteBimestralRetener4 As Double = 0
                            Dim ImporteBimestralRetener5 As Double = 0
                            Dim ImporteBimestralRetener6 As Double = 0



                            'Bimiestre 6
                            porcentajeRetencion = infonavitMonto / 100
                            SalarioBimestral = porcentajeRetencion * objE.PSalarioDiario
                            ImporteBimestral = SalarioBimestral * promedioDias
                            ImporteBimestralRetener = ImporteBimestral + seguroVivienda

                            RetencionDiaria = ImporteBimestralRetener / promedioDias
                            RetencionSemanal = RetencionDiaria * 7

                            Dim weekNum As Integer = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar.GetWeekOfYear(FechaIngreso, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday)

                            Dim anioInicio As DateTime = anio_actual.ToString + "-01-01"

                            If (FechaIngreso >= anioInicio) And (FechaIngreso < inicioVacaciones1) Then
                                RetencionVacaciones = RetencionSemanal * 2
                                RetencionVacaciones = RetencionVacaciones / (50 - weekNum - 1)
                                RetencionSemanal = RetencionSemanal + RetencionVacaciones
                            End If


                            If (FechaIngreso >= anioInicio) And (FechaIngreso > inicioVacaciones1) Then
                                RetencionVacaciones = RetencionSemanal * 2
                                RetencionVacaciones = RetencionVacaciones / (51 - weekNum - 1)
                                RetencionSemanal = RetencionSemanal + RetencionVacaciones
                            End If

                            If FechaIngreso < anioInicio Then
                                RetencionVacaciones = RetencionSemanal * 2
                                RetencionVacaciones = RetencionVacaciones / 50
                                RetencionSemanal = RetencionSemanal + RetencionVacaciones
                            End If

                            ''SI entro en este año
                            ''SI entro en este año

                        End If

                        ''Infonavit tipo 2 
                        If infonavitTipo = 2 Then

                            RetencionMensual = SalarioMinimo * infonavitMonto
                            ImporteBimestral = RetencionMensual * 2
                            ImporteBimestralRetener = ImporteBimestral + seguroVivienda


                            RetencionDiaria = ImporteBimestralRetener / promedioDias
                            RetencionSemanal = RetencionDiaria * 7




                            Dim weekNum As Integer = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar.GetWeekOfYear(FechaIngreso, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday)
                            Dim anio_actual2 As Integer = Now.Year
                            Dim anioInicio As DateTime = anio_actual2.ToString + "-01-01"

                            If (FechaIngreso >= anioInicio) And (FechaIngreso < inicioVacaciones1) Then
                                RetencionVacaciones = RetencionSemanal * 2
                                RetencionVacaciones = RetencionVacaciones / (50 - weekNum - 1)
                                RetencionSemanal = RetencionSemanal + RetencionVacaciones
                                ''RetencionSemanal = RetencionDiaria * 7
                            End If

                            If (FechaIngreso >= anioInicio) And (FechaIngreso > inicioVacaciones1) Then

                                RetencionVacaciones = RetencionSemanal * 2
                                RetencionVacaciones = RetencionVacaciones / (51 - weekNum - 1)
                                RetencionSemanal = RetencionSemanal + RetencionVacaciones
                            End If

                            If FechaIngreso < anioInicio Then
                                RetencionVacaciones = RetencionSemanal * 2
                                RetencionVacaciones = RetencionVacaciones / 50
                                RetencionSemanal = RetencionSemanal + RetencionVacaciones
                            End If

                        End If

                        If infonavitTipo = 3 Then
                            ImporteBimestral = infonavitMonto * 2
                            ImporteBimestralRetener = ImporteBimestral + seguroVivienda
                            'RetencionAnual = ImporteBimestral * 6
                            RetencionDiaria = ImporteBimestralRetener / promedioDias
                            RetencionSemanal = RetencionDiaria * 7

                            Dim weekNum As Integer = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar.GetWeekOfYear(FechaIngreso, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday)
                            Dim anio_actual3 As Integer = Now.Year
                            Dim anioInicio As DateTime = anio_actual3.ToString + "-01-01"

                            If (FechaIngreso >= anioInicio) And (FechaIngreso < inicioVacaciones1) Then
                                RetencionVacaciones = RetencionSemanal * 2
                                RetencionVacaciones = RetencionVacaciones / (50 - weekNum - 1)
                                RetencionSemanal = RetencionSemanal + RetencionVacaciones
                            End If


                            If (FechaIngreso >= anioInicio) And (FechaIngreso > inicioVacaciones1) Then
                                RetencionVacaciones = RetencionSemanal * 2
                                RetencionVacaciones = RetencionVacaciones / (51 - weekNum - 1)
                                RetencionSemanal = RetencionSemanal + RetencionVacaciones
                            End If

                            If FechaIngreso < anioInicio Then
                                RetencionVacaciones = RetencionSemanal * 2
                                RetencionVacaciones = RetencionVacaciones / 50
                                RetencionSemanal = RetencionSemanal + RetencionVacaciones
                            End If

                        End If

                    End If


                    If infonavitTipo = 4 Then
                        RetencionSemanal = infonavitMonto
                    End If


                    'Obtener monto ISR
                    Dim objBUISR As New Negocios.CalcularNominaRealBU
                    Dim montoISR As Double = 0
                    montoISR = objBUISR.montoISR(colaboradorID)

                    ''Consultar incapacidades
                    incapacidades = 0
                    incapacidades = objNominaBU.ConsultaIncapacidades(colaboradorID, lblIdSemanaNomina.Text, 1)

                    If incapacidades > 0 And configValidaIncapacidad Then
                        Dim tblDescuentosFiscales As DataTable = ObjBU.obtieneDescuentosFiscalesBU(colaboradorID, lblIdSemanaNomina.Text)

                        If Not IsNothing(tblDescuentosFiscales) AndAlso tblDescuentosFiscales.Rows.Count > 0 Then
                            montoIMSS = tblDescuentosFiscales.Rows(0).Item("nofis_retencionImss").ToString
                            montoISR = tblDescuentosFiscales.Rows(0).Item("nofis_retencionISR").ToString
                            RetencionSemanal = tblDescuentosFiscales.Rows(0).Item("nofis_infonavit").ToString

                        End If

                    End If

                    ''Totales            

                    TotalDeducciones = Math.Round(cajaAhorro, 0) + Math.Round(pagoTotal, 0) + Math.Round(montoIMSS, 0) + Math.Round(RetencionSemanal, 0) + Math.Round(montoDeduExt, 0) + Math.Round(montoISR, 0)
                    Totalpercepciones = Math.Round(GratificacionesMonto, 0) + Math.Round(MontoAsistencia, 0)
                    ''Totales
                    '  montoIMSS = montoIMSS + montoISR

                    ''OBTENER concepto gratificaciones

                    Dim objBUG As New Nomina.Negocios.CorteNominaRealBU
                    Dim tabla As New DataTable

                    Dim numeroFilaColaborador As Integer
                    'If objE.PfiniquitoID = 0 Then
                    rowCount = rowCount + 1
                    numeroFilaColaborador = rowCount
                    'Else
                    '    numeroFilaColaborador = 0
                    'End If

                    If cmbNave.SelectedValue <> 43 Then
                        tabla = objBUG.obtenerDescripcionGratificaciones(colaboradorID, lblIdSemanaNomina.Text)
                        If tabla.Rows.Count > 0 Then
                            descripcion = tabla.Rows(0).Item("descripcion")
                        End If
                    End If


                    If ColaboradorTipo = "SALARIO" Then
                        salarioDiarioReal = objE.PSalarioReal / 7
                        ausentismos = salarioDiarioReal * inasis
                        SalarioReal = objE.PSalarioReal.ToString("N0")
                        TotalSueldoSemanal = (DiasTrabajados * salarioDiarioReal)


                        TotalEntregar = Math.Round(SalarioReal, 0) - TotalDeducciones + Totalpercepciones - Math.Round(ausentismos, 0)
                        'grdDeducciones.Rows.Add(colaboradorID, RetencionSemanal, numSS, montoIMSS, Interes2, numeroFilaColaborador, colaboradorNom.ToUpper, objE.PDepartamento.ToUpper, objE.PPuesto.ToUpper, inasis2, Math.Round(SalarioReal, 0).ToString("N0"), Math.Round(MontoAsistencia, 0).ToString("N0"), Math.Round(GratificacionesMonto, 0).ToString("N0"), Math.Round(ausentismos, 0).ToString("N0"), Math.Round(montoIMSS + montoISR, 0).ToString("N0"), Math.Round(RetencionSemanal, 0).ToString("N0"), Math.Round(pagoTotal, 0).ToString("N0"), Math.Round(cajaAhorro, 0).ToString("N0"), Math.Round(montoDeduExt, 0).ToString("N0"), CDbl(Math.Round(TotalEntregar, 0)), salarioDiarioReal, SalarioReal, TipoSueldo, objE.PColaborador.pIdAnual, objE.PCuenta, objE.PCelulaIDSAY, 0, objE.Psexo, montoISR, objE.POrdenPuesto, ColaboradorTipo, descripcion, Math.Round(GratificacionFechaNac, 0), 0, 0, objE.PfiniquitoID)
                        grdDeducciones.Rows.Add(colaboradorID, RetencionSemanal, numSS, montoIMSS, Interes2, numeroFilaColaborador, colaboradorNom.ToUpper, objE.PDepartamento.ToUpper, objE.PPuesto.ToUpper, inasis2, incapacidades, Math.Round(SalarioReal, 0).ToString("N0"), Math.Round(MontoAsistencia, 0).ToString("N0"), Math.Round(GratificacionesMonto, 0).ToString("N0"), Math.Round(ausentismos, 0).ToString("N0"), Math.Round(Math.Round(montoIMSS, 0) + Math.Round(montoISR, 0), 0).ToString("N0"), Math.Round(RetencionSemanal, 0).ToString("N0"), Math.Round(pagoTotal, 0).ToString("N0"), Math.Round(cajaAhorro, 0).ToString("N0"), Math.Round(montoDeduExt, 0).ToString("N0"), CDbl(Math.Round(TotalEntregar, 0)), salarioDiarioReal, SalarioReal, TipoSueldo, objE.PColaborador.pIdAnual, objE.PCuenta, objE.PCelulaIDSAY, 0, objE.Psexo, montoISR, objE.POrdenPuesto, ColaboradorTipo, descripcion, Math.Round(GratificacionFechaNac, 0), 0, 0, objE.PfiniquitoID, 0, 0, 0)
                    ElseIf ColaboradorTipo = "DESTAJO" Then

                        Dim salarioDiarioDestajos As Double = TotalDestajos / 7
                        TotalEntregar = TotalDestajos + GratificacionFechaNac + Totalpercepciones - TotalDeducciones
                        ausentismos = 0

                        grdDeducciones.Rows.Add(colaboradorID, RetencionSemanal, numSS, montoIMSS, Interes2, numeroFilaColaborador, colaboradorNom.ToUpper, objE.PDepartamento.ToUpper, objE.PPuesto.ToUpper, inasis2, incapacidades, Math.Round(TotalDestajos, 0).ToString("N0"), Math.Round(MontoAsistencia, 0).ToString("N0"), Math.Round(GratificacionesMonto, 0).ToString("N0"), Math.Round(ausentismos, 0).ToString("N0"), Math.Round(Math.Round(montoIMSS, 0) + Math.Round(montoISR, 0), 0).ToString("N0"), Math.Round(RetencionSemanal, 0).ToString("N0"), Math.Round(pagoTotal, 0).ToString("N0"), Math.Round(cajaAhorro, 0).ToString("N0"), Math.Round(montoDeduExt, 0).ToString("N0"), CDbl(Math.Round(TotalEntregar, 0)), salarioDiarioDestajos, TotalDestajos, TipoSueldo, objE.PColaborador.pIdAnual, objE.PCuenta, objE.PCelulaIDSAY, 0, objE.Psexo, montoISR, objE.POrdenPuesto, ColaboradorTipo, descripcion, Math.Round(GratificacionFechaNac, 0), 0, 0, objE.PfiniquitoID, 0, 0, 0)


                    ElseIf ColaboradorTipo = "POR BANDA" Then
                        Dim salarioDiarioBanda As Double = TotalBanda / 7
                        ausentismos = salarioDiarioBanda * inasis

                        TotalEntregar = TotalBanda + Totalpercepciones + GratificacionFechaNac - TotalDeducciones - Math.Round(ausentismos)

                        grdDeducciones.Rows.Add(colaboradorID, RetencionSemanal, numSS, montoIMSS, Interes2, numeroFilaColaborador, colaboradorNom.ToUpper, objE.PDepartamento.ToUpper, objE.PPuesto.ToUpper, inasis2, incapacidades, Math.Round(TotalBanda, 0).ToString("N0"), Math.Round(MontoAsistencia, 0).ToString("N0"), Math.Round(GratificacionesMonto, 0).ToString("N0"), Math.Round(ausentismos, 0).ToString("N0"), Math.Round(Math.Round(montoIMSS, 0) + Math.Round(montoISR, 0), 0).ToString("N0"), Math.Round(RetencionSemanal, 0).ToString("N0"), Math.Round(pagoTotal, 0).ToString("N0"), Math.Round(cajaAhorro, 0).ToString("N0"), Math.Round(montoDeduExt, 0).ToString("N0"), CDbl(Math.Round(TotalEntregar, 0)), salarioDiarioBanda, TotalBanda, TipoSueldo, objE.PColaborador.pIdAnual, objE.PCuenta, objE.PCelulaIDSAY, 0, objE.Psexo, montoISR, objE.POrdenPuesto, ColaboradorTipo, descripcion, Math.Round(GratificacionFechaNac, 0), 0, 0, objE.PfiniquitoID, 0, 0, 0)

                    End If

                    If objE.PfiniquitoID <> 0 Then
                        grdDeducciones.Rows(grdDeducciones.RowCount - 1).DefaultCellStyle.Font = New Font(grdDeducciones.Font, FontStyle.Bold)
                    End If

                End If

                'If TipoSueldo = "DEPOSITO" Then
                '    ''Sumar al acumulado mensual
                '    If cambioTipoPago = False Then
                '        sumaAcumuladoMensualColaborador(colaboradorID, CDbl(Math.Round(TotalEntregar, 0)))
                '    End If
                'End If
            Next

            For Each row As DataGridViewRow In grdDeducciones.Rows
                'SI SU SUELDO SEMANAL ES NEGATIVO
                If row.Cells("clmTotalEntregar").Value < 0 Then
                    row.Cells("clmTotalEntregar").Style.BackColor = Color.Salmon

                    ''Si tiene incapacidades o es baja, lo primero que va a descontar es la caja... 
                    'If row.Cells("clmIncapacidades").Value > 0 Or row.Cells("fini_finiquitoid").Value > 0 Or row.Cells("clmDiasTrabajados").Value = 7 Then

                    If row.Cells("clmCajaDeAhorro").Value > 0 Then
                        row.Cells("clmTotalEntregar").Value = row.Cells("clmTotalEntregar").Value + row.Cells("clmCajaDeAhorro").Value
                        row.Cells("clmCajaDeAhorro").Value = 0
                        row.Cells("clmCajaDeAhorro").Style.BackColor = Color.LightBlue
                        row.Cells("clmModificaCaja").Value = 1
                        row.Cells("clmTotalEntregar").Style.BackColor = Color.LightGray
                    End If
                    'Si sigue siendo negativo quita el préstamo
                    If row.Cells("clmPrestamos").Value > 0 And row.Cells("clmTotalEntregar").Value < 0 Then
                        row.Cells("clmTotalEntregar").Value = row.Cells("clmTotalEntregar").Value + row.Cells("clmPrestamos").Value
                        row.Cells("clmPrestamos").Value = 0
                        row.Cells("clmPrestamos").Style.BackColor = Color.LightBlue
                        row.Cells("clmModificaPrestamo").Value = 1
                        row.Cells("clmTotalEntregar").Style.BackColor = Color.LightGray
                    End If
                    'Si sigue siendo negativo quita las deducciones extraordinarias
                    If row.Cells("clmOtrasDeducciones").Value > 0 And row.Cells("clmTotalEntregar").Value < 0 Then
                        row.Cells("clmTotalEntregar").Value = row.Cells("clmTotalEntregar").Value + row.Cells("clmOtrasDeducciones").Value
                        row.Cells("clmOtrasDeducciones").Value = 0
                        row.Cells("clmOtrasDeducciones").Style.BackColor = Color.LightBlue
                        row.Cells("clmModificaDeducciones").Value = 1
                        row.Cells("clmTotalEntregar").Style.BackColor = Color.LightGray
                    End If

                    'End If

                    ''Si ya se elminó pago de préstamo y caja de ahorro se elimina el imms en caso de que siga siendo negativo
                    If row.Cells("clmCajaDeAhorro").Value = 0 And row.Cells("clmPrestamos").Value = 0 And row.Cells("clmTotalEntregar").Value < 0 Then

                        If row.Cells("clmRespaldoIMSS").Value.Length >= 5 Then
                            'clmIMMS contiene IMSS e ISR
                            row.Cells("clmTotalEntregar").Value = row.Cells("clmTotalEntregar").Value + row.Cells("clmIMMS").Value
                            row.Cells("clmIMMS").Style.BackColor = Color.LightBlue
                            row.Cells("clmIMMS").Value = 0
                            row.Cells("clmISR").Value = 0
                            row.Cells("clmTotalEntregar").Style.BackColor = Color.LightGray
                        End If

                        ''SI AUN SI SIGUE SIENDO NEGATIVO SE ELIMINA EL INFONAVIT
                        If row.Cells("clmTotalEntregar").Value < 0 And row.Cells("clmInfonavit").Value > 0 Then

                            row.Cells("clmTotalEntregar").Value = row.Cells("clmTotalEntregar").Value + row.Cells("clmInfonavit").Value
                            row.Cells("clmInfonavit").Value = 0
                            row.Cells("clmInfonavit").Style.BackColor = Color.LightBlue
                            row.Cells("clmTotalEntregar").Style.BackColor = Color.LightGray

                        End If


                        ''SI  QUEDA EN 0 o POSITIVA
                        If row.Cells("clmTotalEntregar").Value > 0 Then
                            'row.Cells("clmTotalEntregar").Style.BackColor = Color.LightGray

                            ''SI NO SE PUEDE DESCONTAR EL INFONAVIT, SE TRATARA DE DESCONTAR EL IMSS AUNQUE SEA PROPORCIONAL
                            If row.Cells("clmRespaldoIMSS").Value.Length >= 5 Then
                                If row.Cells("clmIMMS").Value = 0 And row.Cells("clmRespaldoIMSSMonto").Value > 0 Then

                                    If row.Cells("clmTotalEntregar").Value >= row.Cells("clmRespaldoIMSSMonto").Value Then
                                        row.Cells("clmIMMS").Value = row.Cells("clmRespaldoIMSSMonto").Value
                                        row.Cells("clmTotalEntregar").Value = row.Cells("clmTotalEntregar").Value - row.Cells("clmRespaldoIMSSMonto").Value

                                    Else
                                        row.Cells("clmIMMS").Value = row.Cells("clmTotalEntregar").Value
                                        row.Cells("clmTotalEntregar").Value = row.Cells("clmTotalEntregar").Value - row.Cells("clmIMMS").Value
                                        row.Cells("clmIMMS").Style.BackColor = Color.LightBlue

                                    End If

                                    row.Cells("clmTotalEntregar").Style.BackColor = Color.LightGray

                                End If

                                'If row.Cells("clmTotalEntregar").Value > 0 Then
                                '    row.Cells("clmCajaDeAhorro").Style.BackColor = Color.Cyan
                                'End If

                            End If


                            ''SE VERIFICA SI SE PUEDE DESCONTAR EL MONTO TOTAL DE INFONAVIT
                            If row.Cells("clmTotalEntregar").Value > 0 Then
                                'Verficiar si tiene infonavit y no se ha descontado 180620191629
                                If row.Cells("clmRespaldoInfonavit").Value > 0 And row.Cells("clmInfonavit").Value = 0 Then
                                    If row.Cells("clmTotalEntregar").Value >= row.Cells("clmRespaldoInfonavit").Value Then
                                        row.Cells("clmTotalEntregar").Value = row.Cells("clmTotalEntregar").Value - row.Cells("clmRespaldoInfonavit").Value
                                        row.Cells("clmInfonavit").Value = row.Cells("clmRespaldoInfonavit").Value
                                    Else
                                        row.Cells("clmInfonavit").Value = row.Cells("clmTotalEntregar").Value
                                        row.Cells("clmTotalEntregar").Value = row.Cells("clmInfonavit").Value - row.Cells("clmTotalEntregar").Value
                                        row.Cells("clmInfonavit").Style.BackColor = Color.LightBlue

                                    End If
                                End If
                            End If

                            ''SE VERIFICA SI SE PUEDE DESCONTAR LOS INTERES DEL PRESTAMO QUE TIENE ACTIVO
                            If row.Cells("clmTotalEntregar").Value > 0 Then
                                If row.Cells("clmTotalEntregar").Value >= Interes2 And Interes2 > 0 Then
                                    row.Cells("clmPrestamos").Style.BackColor = Color.LightPink
                                End If
                            End If
                        Else
                            If row.Cells("clmTotalEntregar").Value < 0 Then
                                row.Cells("clmTotalEntregar").Style.BackColor = Color.Salmon
                            End If
                        End If
                    End If
                Else ''ELSE DEL IF PRINCIPAL
                    row.Cells("clmTotalEntregar").Style.BackColor = Color.LightGreen
                End If

            Next

            'If grdDeducciones.RowCount > 0 Then
            '    ObjBU = New Nomina.Negocios.CalcularNominaRealBU
            '    resultado = ObjBU.CambiaTipoSueldoColaboradores(cmbNave.SelectedValue, CInt(lblIdSemanaNomina.Text))
            '    If resultado <> "EXITO" Then
            '        objMensajeAdv.mensaje = "No fue posible cambiar el tipo de pago."
            '        objMensajeAdv.Show()
            '    End If
            'End If

            Totalausentismos2 = 0
            TotalPuntualidadAsistencia2 = 0
            TotalGratificaciones2 = 0
            TotalCajaAhorro2 = 0
            TotalIMSS2 = 0
            TotalInfonavit2 = 0
            TotalPrestamos2 = 0
            TotalOtrasDeducciones2 = 0
            TotalTotalEntregar2 = 0
            TotalpagoBruto = 0
            contadorFilas2 = 0
            estaMal = 0
            contadorFilas2 = 0

            listaNegativos.Clear()
            listaDepositoEfectivo.Clear()
            ContadorDepositos = 0
            For Each row As DataGridViewRow In grdDeducciones.Rows

                If row.Cells("clmTipoSueldo").Value = "DEPOSITO" Then
                    Dim obj As New Entidades.CalcularNominaReal
                    Dim objCola As New Entidades.Colaborador
                    obj.PTotalEntregar = row.Cells("clmTotalEntregar").Value
                    obj.PCuenta = row.Cells("clmCuenta").Value
                    objCola.PNombre = row.Cells("clmColaborador").Value
                    obj.PColaborador = objCola
                    listaDepositoEfectivo.Add(obj)
                    ContadorDepositos += 1
                End If

                If Math.Round(row.Cells("clmTotalEntregar").Value, 2) < 0 Then
                    estaMal = 1

                    Dim IDCOLABO As New Int32
                    IDCOLABO = CInt(row.Cells("clmIDcolaborador").Value)
                    listaNegativos.Add(IDCOLABO)
                End If



                Totalausentismos2 += row.Cells("clmAusentismos").Value
                TotalPuntualidadAsistencia2 += row.Cells("clmPuntualidadAsistencia").Value
                TotalGratificaciones2 += row.Cells("clmGratificaciones").Value
                TotalCajaAhorro2 += row.Cells("clmCajaDeAhorro").Value
                TotalIMSS2 += row.Cells("clmIMMS").Value
                TotalInfonavit2 += row.Cells("clmInfonavit").Value
                TotalPrestamos2 += row.Cells("clmPrestamos").Value
                TotalOtrasDeducciones2 += row.Cells("clmOtrasDeducciones").Value
                TotalTotalEntregar2 += row.Cells("clmTotalEntregar").Value
                TotalpagoBruto += row.Cells("clmSalarioRegistrado").Value
                contadorFilas2 += 1
            Next

            If imprimir = False Then
                grdDeducciones.Rows.Add("", "", "", "", "", "", "", "", "", "", "", TotalpagoBruto.ToString("N0"), TotalPuntualidadAsistencia2.ToString("N0"), TotalGratificaciones2.ToString("N0"), Totalausentismos2.ToString("N0"), TotalIMSS2.ToString("N0"), TotalInfonavit2.ToString("N0"), TotalPrestamos2.ToString("N0"), TotalCajaAhorro2.ToString("N0"), TotalOtrasDeducciones2.ToString("N0"), CDbl(Math.Round(TotalTotalEntregar2, 2)), "", "", "", "", "")
                grdDeducciones.Rows(contadorFilas2).DefaultCellStyle.BackColor = Color.GreenYellow
            End If


            If estaMal > 0 Then

                btnGuardar.Enabled = False
                Dim mensajeExito As New AvisoForm
                mensajeExito.MdiParent = Me.MdiParent
                mensajeExito.mensaje = "Hay salarios con valores negativos favor de verificarlos."
                mensajeExito.Show()
                btnGuardar.Enabled = False
                estaMal = 0
            Else
                btnGuardar.Enabled = True
                estaMal = 0
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Public Sub SemanaNomina()
        Try
            Dim SemanaNominaActiva As New List(Of Entidades.CobranzaPrestamos)
            Dim SenamaActivaBu As New Nomina.Negocios.CobranzaPrestamosBU
            Dim idNave As Integer
            idNave = (Int(cmbNave.SelectedValue))
            SemanaNominaActiva = SenamaActivaBu.SemanaNominaActiva(idNave)

            For Each objeto As Entidades.CobranzaPrestamos In SemanaNominaActiva
                SemanaActiva(objeto)
            Next

        Catch ex As Exception

        End Try
    End Sub

    Public Sub SemanaActiva(ByVal SemanaActiva As Entidades.CobranzaPrestamos)
        Dim mensaje As String = ""
        NaveIDSICY = SemanaActiva.PNaveIDSICY
        lblIdSemanaNomina.Text = SemanaActiva.PsemanaNominaId
        'lblIdSemanaNomina.Text = "4679"
        'MsgBox("BORRAME")
        FinSemanaNomina = SemanaActiva.PfechaFinNomina
        lblSemanaNominaFIN.Text = FinSemanaNomina
        lblPeriodoAsistencia.Text = SemanaActiva.PPeriodoNominaAsistencia
        lblPeriodoCajaAhorro.Text = SemanaActiva.PPeriodoNominaCajaAhorro
        lblPeriodoPrestamos.Text = SemanaActiva.PPeriodoNominaPrestamos
        lblPeriodoDeducciones.Text = SemanaActiva.PPeriodoNominaDeducciones
        lblPeriodoFiscal.Text = SemanaActiva.PPeriodoNominaFiscal
        lblPeriodoNomina.Text = SemanaActiva.PConceptoSemana
        lblPeriodoDestajos.Text = SemanaActiva.PPeriodoNominaDestajos

        FechaInicio = SemanaActiva.PfechaInicioNomina
        fechaFinal = SemanaActiva.PfechaFinNomina

        semanaPeriodo = SemanaActiva.PsemanaNomina

        If lblPeriodoAsistencia.Text = "A" Then
            mensaje = " El periodo de asistencia no se ha cerrado.  "
        End If

        'If lblPeriodoFiscal.Text = "A" Then
        '    mensaje += vbNewLine & " El periodo fiscal no se ha cerrado. "
        'End If

        ''VALIDAR SI HAY PRESTAMOS COBRADOS
        Dim contadorPrestamos As Integer = 0
        Dim listaConfiguracionPrestamos As New List(Of Entidades.SolicitudPrestamo)
        Dim prestamosBU As New Nomina.Negocios.CobranzaPrestamosBU
        Dim semanaNominaId As Integer
        semanaNominaId = lblIdSemanaNomina.Text

        listaConfiguracionPrestamos = prestamosBU.PrestamosActivos(cmbNave.SelectedValue)

        For Each objeto As Entidades.SolicitudPrestamo In listaConfiguracionPrestamos
            contadorPrestamos += 1

        Next
        If contadorPrestamos > 0 And lblPeriodoPrestamos.Text = "A" Then
            mensaje += vbNewLine & " El periodo de préstamos no se ha cerrado. "
        End If


        ''VALIDAR SI HAY DEDUCCIONES EXTRAORDINARIAS COBRADAS
        Dim listaDeduccionesExtra As New List(Of Entidades.Deducciones)
        Dim deduccionesBU As New Nomina.Negocios.DeduccionesBU
        Dim contadorDeduccionesExtra As Integer = 0
        listaDeduccionesExtra = deduccionesBU.DeduccionesExtraordinariasActivas(cmbNave.SelectedValue, lblIdSemanaNomina.Text, "")

        For Each objeto As Entidades.Deducciones In listaDeduccionesExtra
            contadorDeduccionesExtra += 1
        Next
        If contadorDeduccionesExtra > 0 And lblPeriodoDeducciones.Text = "A" Then
            mensaje += vbNewLine & " El periodo de deducciones no se ha cerrado. "
        End If

        ''VALIDAR SI HAY CAJA DE AHORRO ABIERTA
        Dim listaCajaAhorro As New List(Of Entidades.CalcularNominaReal)
        Dim CajaBU As New Nomina.Negocios.CalcularNominaRealBU
        Dim contadorCaja As Integer = 0
        listaCajaAhorro = CajaBU.cajaAhorroValidacion(cmbNave.SelectedValue, FechaInicio, fechaFinal)

        For Each objeto As Entidades.CalcularNominaReal In listaCajaAhorro
            contadorCaja += 1
        Next
        If contadorCaja > 0 And lblPeriodoCajaAhorro.Text = "A" Then
            mensaje += vbNewLine & " El periodo de caja de ahorro no se ha cerrado. "
        ElseIf contadorCaja = 0 Then
            lblPeriodoCajaAhorro.Text = "C"
        End If


        'VALIDAR SI HAY COLABORADORES CON DESTAJOS
        Dim tablaDest As New DataTable
        Dim destBU As New Nomina.Negocios.CalcularNominaRealBU
        Dim contadorDest As Integer = 0
        tablaDest = destBU.validarDestajos(cmbNave.SelectedValue, lblIdSemanaNomina.Text)
        If tablaDest.Rows.Count > 0 And lblPeriodoDestajos.Text = "A" Then
            mensaje += vbNewLine & " El periodo de destajos de se ha cerrado."
        End If


        If mensaje <> "" Then

            Dim mensajeExito As New AvisoForm
            ' mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = mensaje.ToString
            mensajeExito.ShowDialog()
            btnGuardar.Enabled = False
            btnBuscar.Enabled = False
        Else
            btnGuardar.Enabled = True
            btnBuscar.Enabled = True
        End If

    End Sub
    ''LLENAR SEMANA NOMINA ACTIVA
    Public Sub IMSSLimitesSI()
        Try
            IMSSLimite = Nothing
            iterador = 0
            Dim LimitesIMSS As New List(Of Entidades.CalcularNominaReal)
            Dim LimitesBU As New Nomina.Negocios.CalcularNominaRealBU

            LimitesIMSS = LimitesBU.ListaLimites(cmbNave.SelectedValue)
            limiteMatriz = LimitesIMSS.Count
            ReDim IMSSLimite(limiteMatriz, 3)
            For Each objeto As Entidades.CalcularNominaReal In LimitesIMSS
                IMSSLimitesSIM(objeto)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Public Sub IMSSLimitesSIM(ByVal Limites As Entidades.CalcularNominaReal)

        IMSSLimite(iterador, 1) = Limites.PIMSS.PLimiteInferior
        IMSSLimite(iterador, 2) = Limites.PIMSS.PLimiteSuperior
        IMSSLimite(iterador, 3) = Limites.PIMSS.PCantidad
        iterador += 1
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        Me.Cursor = Cursors.WaitCursor
        grdDeducciones.Rows.Clear()

        Dim idNave As Integer = CInt(cmbNave.SelectedValue)
        Dim idArea As Integer = 0
        Dim idDepartamento As Integer = 0
        Dim listaNominaReal As List(Of Entidades.CalcularNominaReal)
        Dim ObjBU As New Nomina.Negocios.CalcularNominaRealBU
        Dim resultado As String = String.Empty
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        'If (cmbNave.SelectedValue = 43) Then
        'cambioTipoPago = ObjBU.validacambioTipoPagoAplicado(CInt(lblIdSemanaNomina.Text))


        'If verificaReinicioAcumuladoTipoPago() Then
        '    listaNominaReal = ObjBU.ListaNominaReal(cmbNave.SelectedValue, 0, 0, txtColaborador.Text, "")
        '    AgregarFilaColaboradoresNominaReal(listaNominaReal, False)
        '    ''actualiza bit  periodo de nomina y tipo de pago
        '    If grdDeducciones.RowCount > 0 Then
        '        ObjBU = New Nomina.Negocios.CalcularNominaRealBU
        '        resultado = ObjBU.CambiaTipoSueldoColaboradores(cmbNave.SelectedValue, CInt(lblIdSemanaNomina.Text))
        '        If resultado <> "EXITO" Then
        '            objMensajeAdv.mensaje = "No fue posible cambiar el tipo de pago."
        '            objMensajeAdv.Show()
        '        End If
        '    End If
        'Else
        '    objMensajeAdv.mensaje = "No fue posible actualizar el acumulado."
        '    objMensajeAdv.Show()
        'End If
        'Else

        listaNominaReal = ObjBU.ListaNominaReal(cmbNave.SelectedValue, 0, 0, txtColaborador.Text, "")
        AgregarFilaColaboradoresNominaReal(listaNominaReal, False)

        'End If
        Me.Cursor = Cursors.Default

    End Sub


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim contadorRegistros As Integer = 0
        Dim ObjEnvio As New EnvioDepositoForm

        ''Agregado para solicitudes de finanzas
        For Each row As DataGridViewRow In grdDeducciones.Rows
            contadorRegistros += 1
            Exit For
        Next

        If contadorRegistros > 0 Then
            Dim objContabilidadBU As New Contabilidad.Negocios.CreditoInfonavitBU
            Dim dtListado As New DataTable

            If cmbNave.SelectedValue <> 53 And cmbNave.SelectedValue <> 57 Then  ''para la nave suelas no se realiza solicitud de caja chica

                If GenerarSolicitudNomina() Then
                    btnGuardar.Enabled = False

                    If ContadorDepositos > 0 Then
                        With ObjEnvio
                            .ListaDepositosEfectivo = listaDepositoEfectivo
                            .FechaInicio = FechaInicio
                            .FechaFin = fechaFinal
                            .NaveID = cmbNave.SelectedValue
                            .ShowDialog()
                            ContadorDepositos = 0
                        End With
                    End If

                    GuardarNomina()
                    'grdDeducciones.Rows.Clear()
                    'btnBuscar.Enabled = False
                    'lblPeriodoNomina.Text = ""
                End If
            ElseIf cmbNave.SelectedValue = 53 Or cmbNave.SelectedValue = 57 Then

                ''cierre suelas
                btnGuardar.Enabled = False
                Dim mensajeExito As New ConfirmarForm
                mensajeExito.mensaje = "¿ Está seguro de querer guardar la nómina ? " + vbNewLine + "No podrá hacer modificaciones" + vbNewLine + " después del guardado."

                If mensajeExito.ShowDialog = DialogResult.OK Then

                    If ContadorDepositos > 0 Then
                        With ObjEnvio
                            .ListaDepositosEfectivo = listaDepositoEfectivo
                            .FechaInicio = FechaInicio
                            .FechaFin = fechaFinal
                            .NaveID = cmbNave.SelectedValue
                            .ShowDialog()
                            ContadorDepositos = 0
                        End With
                    End If

                    GuardarNomina()

                End If

            End If
        End If
    End Sub

    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Sub GuardarNomina()
        Dim naves As New Entidades.Naves
        Dim corteNomina2 As New Entidades.CorteNominaReal
        Dim ObjBU As New Nomina.Negocios.DeduccionesBU
        Dim ObjBUPER As New Nomina.Negocios.PercepcionesBU
        Dim ObjCorteBU As New Nomina.Negocios.CorteNominaRealBU

        Dim colaboradorID As Integer = 0
        Dim cajaDeAhorro As Double = 0
        Dim Prestamo As Double = 0
        Dim Gratificaciones As Double = 0
        Dim IncentivoPuntualidad As Double = 0
        Dim IMSS As Double = 0
        Dim horasExtras As Double = 0
        Dim RetencionInfonavit As Double = 0

        Dim insertarSalarioSemanal As Integer = 0
        Dim insertarTotalDeducciones As Double = 0
        Dim insertarTotalpercepciones As Double = 0
        Dim insertarTotalEntregar As Double = 0
        Dim salarioDiario As Double = 0



        For Each row As DataGridViewRow In grdDeducciones.Rows
            ''GUARDA DEDUCCIONES
            '0 - Extraordinaria
            '1 – Caja de Ahorro
            '2 – Préstamos
            '3 – IMSS
            Dim ausentismos As Double
            Dim percepcion As New Entidades.Percepciones
            Dim colaborador As New Entidades.Colaborador
            Dim cobranza As New Entidades.CobranzaPrestamos
            Dim prestamos As New Entidades.SolicitudPrestamo
            Dim deducciones As New Entidades.Deducciones
            Dim corteNomina As New Entidades.CorteNominaReal
            Dim nomina As New Entidades.CalcularNominaReal
            Dim isr As Double = 0

            If row.Cells("clmColaborador").Value = "" Then

            Else
                colaboradorID = row.Cells("clmIDcolaborador").Value
                colaborador.PColaboradorid = row.Cells("clmIDcolaborador").Value
                cobranza.PfechaFinNomina = FinSemanaNomina
                cobranza.PsemanaNominaId = lblIdSemanaNomina.Text

                deducciones.PColaborador = colaborador
                deducciones.PCobranza = cobranza
                deducciones.PidCreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

                deducciones.PConceptoDeduccion = "Caja de ahorro"
                deducciones.PMontoDeduccion = row.Cells("clmCajaDeAhorro").Value
                deducciones.PDeduccionTipo = 1
                ObjBU.guardarDeducciones(deducciones)


                deducciones.PConceptoDeduccion = "Prestamo"
                deducciones.PMontoDeduccion = row.Cells("clmPrestamos").Value
                deducciones.PDeduccionTipo = 2
                ObjBU.guardarDeducciones(deducciones)

                deducciones.PConceptoDeduccion = "IMSS"
                If row.Cells("clmIMMS").Value = 0 Then
                    deducciones.PMontoDeduccion = row.Cells("clmIMMS").Value
                Else
                    deducciones.PMontoDeduccion = row.Cells("clmRespaldoIMSSMonto").Value
                End If

                deducciones.PDeduccionTipo = 3
                ObjBU.guardarDeducciones(deducciones)

                deducciones.PConceptoDeduccion = "Retencion infonavit"
                deducciones.PMontoDeduccion = row.Cells("clmInfonavit").Value
                deducciones.PDeduccionTipo = 4
                ObjBU.guardarDeducciones(deducciones)

                deducciones.PConceptoDeduccion = "ISR"
                If row.Cells("clmIMMS").Value = 0 Then
                    deducciones.PMontoDeduccion = 0
                Else
                    deducciones.PMontoDeduccion = row.Cells("clmISR").Value
                End If
                deducciones.PDeduccionTipo = 5
                ObjBU.guardarDeducciones(deducciones)

                ''GUARDA LAS PERCEPCIONES
                ''1. Puntualidad y asistencia,
                ' 2. Gratificaciones, 
                ' 3. Horas extras,
                ' 0. Salario semanal



                colaborador.PColaboradorid = colaboradorID
                cobranza.PfechaFinNomina = lblSemanaNominaFIN.Text
                cobranza.PsemanaNominaId = lblIdSemanaNomina.Text
                prestamos.Pusuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

                percepcion.PColaborador = colaborador
                percepcion.PCobranza = cobranza
                percepcion.PPrestamos = prestamos

                ''INCENTIVO PUNTUALIDAD
                percepcion.PMontoPercepcion = row.Cells("clmPuntualidadAsistencia").Value
                percepcion.PPercepcionTipo = 1
                ObjBUPER.guardarPrenominaPercepciones(percepcion)


                ''GRATIFICACIONES

                If row.Cells("clmGratificaciones").Value > 0 Then
                    If row.Cells("clmBanderaCumple").Value > 0 Then
                        percepcion.PMontoPercepcion = Math.Round(CDbl(row.Cells("clmGratificaciones").Value), 0) - Math.Round(CDbl(row.Cells("clmSalarioDiario").Value), 0)
                        percepcion.PPercepcionTipo = 2
                        ObjBUPER.guardarPrenominaPercepciones(percepcion)
                    Else
                        percepcion.PMontoPercepcion = row.Cells("clmGratificaciones").Value
                        percepcion.PPercepcionTipo = 2
                        ObjBUPER.guardarPrenominaPercepciones(percepcion)
                    End If
                Else
                    percepcion.PMontoPercepcion = row.Cells("clmGratificaciones").Value
                    percepcion.PPercepcionTipo = 2
                    ObjBUPER.guardarPrenominaPercepciones(percepcion)
                End If

                ''GRATIFICACIONES cumpleaños
                If row.Cells("clmGratificaciones").Value > 0 Then
                    If row.Cells("clmBanderaCumple").Value > 0 Then
                        percepcion.PMontoPercepcion = Math.Round(CDbl(row.Cells("clmSalarioDiario").Value), 0)
                        percepcion.PPercepcionTipo = 3
                        ObjBUPER.guardarPrenominaPercepciones(percepcion)
                    End If
                End If
                'If row.Cells("clmPercepconesConcepto").Value = "Horas extras" Then
                '    horasExtras = row.Cells("clmPercepcionesMonto").Value

                '    'If horasExtras = 0 Then
                '    '    ''No obtuvo horas extras
                '    'Else

                '    percepcion.PMontoPercepcion = horasExtras
                '    percepcion.PPercepcionTipo = 4
                '    ObjBUPER.guardarPrenominaPercepciones(percepcion)
                'End If
                ''End If

                ''SALARIO SEMANAL
                percepcion.PMontoPercepcion = row.Cells("clmTotalEntregar").Value
                percepcion.PPercepcionTipo = 0
                ObjBUPER.guardarPrenominaPercepciones(percepcion)
                'End If

                ''ACTUALIZAR PRESTAMO Y CAJA DE AHORRO
                If row.Cells("clmModificaCaja").Value > 0 OrElse row.Cells("clmModificaPrestamo").Value > 0 OrElse row.Cells("clmModificaDeducciones").Value > 0 Then
                    Dim resultado As String = ""
                    Dim modificaCaja As Boolean = row.Cells("clmModificaCaja").Value > 0
                    Dim modificaPrestamo As Boolean = row.Cells("clmModificaPrestamo").Value > 0
                    Dim modificaDeducciones As Boolean = row.Cells("clmModificaDeducciones").Value > 0
                    Dim objMensajeAdv As New AdvertenciaForm

                    resultado = ObjBU.CambiaDeduccionesNegativos(colaboradorID, modificaCaja, modificaPrestamo, modificaDeducciones, CInt(lblIdSemanaNomina.Text))
                    If resultado <> "EXITO" Then
                        objMensajeAdv.mensaje = "No fue posible modificar las deducciones."
                        objMensajeAdv.Show()
                    End If
                End If

                ''GUARDA TOTALES PARA EL CORTE DE NOMINA
                ''GUARDA TOTALES PARA EL CORTE DE NOMINA
                ''GUARDA TOTALES PARA EL CORTE DE NOMINA

                percepcion.PTotalPercepciones = CDbl(row.Cells("clmGratificaciones").Value) + CDbl(row.Cells("clmPuntualidadAsistencia").Value)
                deducciones.PTotalDeducciones = CDbl(row.Cells("clmCajaDeAhorro").Value) + CDbl(row.Cells("clmIMMS").Value) + CDbl(row.Cells("clmInfonavit").Value) + CDbl(row.Cells("clmPrestamos").Value) + CDbl(row.Cells("clmOtrasDeducciones").Value)
                ausentismos = row.Cells("clmAusentismos").Value
                corteNomina.PTotalEntregar = row.Cells("clmTotalEntregar").Value

                cobranza.PsemanaNominaId = lblIdSemanaNomina.Text

                colaborador.PColaboradorid = colaboradorID

                nomina.PSalarioDiario = row.Cells("clmSalarioDiario").Value
                nomina.PDiasLaborados = 7 - row.Cells("clmDiasTrabajados").Value
                nomina.PSalarioSemanal = row.Cells("clmSalarioSemanal").Value

                corteNomina.Pcobranza = cobranza
                corteNomina.Pcolaborador = colaborador
                corteNomina.PNomina = nomina
                corteNomina.PPercepciones = percepcion
                corteNomina.PDeducciones = deducciones
                corteNomina.pAusentismos = ausentismos

                ''Se agrega tipo de pago y tipo de sueldo ipxalem 15-09-2015
                corteNomina.PTipoPago = row.Cells("clmTipoSueldo").Value
                corteNomina.PTipoSueldo = row.Cells("clmcolaboradorTipo").Value

                ''Se agregan las incpacidades de la semana 190620191557
                corteNomina.PIncapacidad = row.Cells("clmIncapacidades").Value

                ObjCorteBU.GuardarCorteNomina(corteNomina)
            End If
        Next

        For Each fila As Entidades.CalcularNominaReal In listaLiquidarGratificaciones
            Dim Obj As New Entidades.CalcularNominaReal
            Dim ObjCorte As New Negocios.CorteNominaRealBU
            Obj.PIdGratificacion = fila.PIdGratificacion

            Obj.PSemanaNominaID = CInt(lblIdSemanaNomina.Text)
            Obj.PEstatus = "P"
            ObjCorte.LiquidarGratificaciones(Obj)
        Next

        naves.PNaveId = cmbNave.SelectedValue
        corteNomina2.PNave = naves
        ObjCorteBU.CambiarSemanaNomina(corteNomina2)


        Dim EntidadNave As New Entidades.Naves
        EntidadNave = TryCast(cmbNave.SelectedItem, Entidades.Naves)
        EnviarCorreoCambioDeNave(EntidadNave)


        Dim mensajeExito As New ExitoForm
        ' mensajeExito.MdiParent = Me.MdiParent
        mensajeExito.mensaje = "Se ha generado la nómina correctamente."

        mensajeExito.ShowDialog()

        ObjCorteBU.GuardarReporteGeneralDeducciones(CInt(lblIdSemanaNomina.Text))
        ObjCorteBU.GuardarReportePrestamos(CInt(lblIdSemanaNomina.Text))

        grdDeducciones.Rows.Clear()
        btnBuscar.Enabled = False
        lblPeriodoNomina.Text = ""
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 113
    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub

    Private Sub grdDeducciones_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDeducciones.CellContentDoubleClick

        If e.ColumnIndex = 18 Then
            Dim ObjCaja As New CierreSemanalForm
            ObjCaja.Nave = cmbNave.SelectedValue 'cmbNave.Text
            'ObjCaja.Periodo = lblIdSemanaNomina.Text
            ObjCaja.IdPeriodoNomina = CLng(lblIdSemanaNomina.Text)
            ObjCaja.listaNegativos = listaNegativos
            ObjCaja.ShowDialog()

        End If

        If e.ColumnIndex = 17 Then
            Dim ObjPres As New EditarCobranzaPrestamos
            ObjPres.PLISTAID = listaNegativos
            ObjPres.ShowDialog()

        End If

        If e.ColumnIndex = 19 Then
            Dim ObjDeducciones As New EditarDeduccionesExtraordinarias
            ObjDeducciones.PLISTAID2 = listaNegativos
            ObjDeducciones.ShowDialog()

        End If
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        ContextMenuStrip1.Show(btnReporte, 0, btnReporte.Height)
    End Sub

    Private Sub ImprimirReporteGeneralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirReporteGeneralToolStripMenuItem.Click
        grdDeducciones.Rows.Clear()

        Dim idNave As Integer = CInt(cmbNave.SelectedValue)
        Dim idArea As Integer = 0
        Dim idDepartamento As Integer = 0
        Dim ObjBU As New Nomina.Negocios.CalcularNominaRealBU
        Dim listaNominaReal As List(Of Entidades.CalcularNominaReal)

        listaNominaReal = ObjBU.ListaNominaReal(idNave, 0, 0, txtColaborador.Text, "")

        AgregarFilaColaboradoresNominaReal(listaNominaReal, True)
        Try
            If cmbNave.SelectedIndex > 0 Then


                Dim ds As New ListaCorteNominaDS
                Dim ObjDS As New ListaCorteNominaDS
                ds.Tables.Add("grdDeducciones")


                ''Se agregan las columnas
                Dim col As System.Data.DataColumn
                For Each dgvCol As DataGridViewColumn In Me.grdDeducciones.Columns
                    col = New System.Data.DataColumn(dgvCol.Name)
                    ds.Tables("grdDeducciones").Columns.Add(col)
                Next

                ''SE agregan las filas
                Dim row As System.Data.DataRow
                Dim colcount As Integer = Me.grdDeducciones.Columns.Count - 1

                For i As Integer = 0 To Me.grdDeducciones.Rows.Count - 1
                    row = ds.Tables("grdDeducciones").Rows.Add
                    For Each column As DataGridViewColumn In Me.grdDeducciones.Columns
                        row.Item(column.Index) = Me.grdDeducciones.Rows.Item(i).Cells(column.Index).Value
                    Next
                Next

                ''Se indica el tipo de parametro
                ''En este caso de tipo numerico

                'Colaborador.ParameterValueType = ParameterValueKind.StringParameter
                'IdNave.ParameterValueType = ParameterValueKind.NumberParameter
                'PeriodoNominaID.ParameterValueType = ParameterValueKind.NumberParameter

                PeriodoNomina.ParameterValueType = ParameterValueKind.StringParameter
                ruta.ParameterValueType = ParameterValueKind.StringParameter
                UserName.ParameterValueType = ParameterValueKind.StringParameter
                NombreArchivo.ParameterValueType = ParameterValueKind.StringParameter
                Nave.ParameterValueType = ParameterValueKind.StringParameter


                TotalpagoBruto3.ParameterValueType = ParameterValueKind.StringParameter
                TotalPuntualidadAsistencia3.ParameterValueType = ParameterValueKind.StringParameter
                TotalGratificaciones3.ParameterValueType = ParameterValueKind.StringParameter
                Totalausentismos3.ParameterValueType = ParameterValueKind.StringParameter
                TotalIMSS3.ParameterValueType = ParameterValueKind.StringParameter
                TotalInfonavit3.ParameterValueType = ParameterValueKind.StringParameter
                TotalPrestamos3.ParameterValueType = ParameterValueKind.StringParameter
                TotalCajaAhorro3.ParameterValueType = ParameterValueKind.StringParameter
                TotalOtrasDeducciones3.ParameterValueType = ParameterValueKind.StringParameter
                TotalTotalEntregar3.ParameterValueType = ParameterValueKind.StringParameter


                ''Se indica el nombre del parametro
                ''del procedimiento almacenado
                'Colaborador.ParameterFieldName = "@Colaborador"
                'IdNave.ParameterFieldName = "@NaveID"
                'PeriodoNominaID.ParameterFieldName = "@PeriodoNominaID"

                PeriodoNomina.ParameterFieldName = "PeriodoNomina"
                ruta.ParameterFieldName = "ruta"
                UserName.ParameterFieldName = "Usuario"
                NombreArchivo.ParameterFieldName = "NombreReporte"
                Nave.ParameterFieldName = "Nave"


                TotalpagoBruto3.ParameterFieldName = "TotalPagoBruto"
                TotalPuntualidadAsistencia3.ParameterFieldName = "TotalExtras"
                TotalGratificaciones3.ParameterFieldName = "TotalGratificaciones"
                Totalausentismos3.ParameterFieldName = "TotalAusentismos"
                TotalIMSS3.ParameterFieldName = "TotalIMSS"
                TotalInfonavit3.ParameterFieldName = "TotalInfonavit"
                TotalPrestamos3.ParameterFieldName = "TotalPrestamos"
                TotalCajaAhorro3.ParameterFieldName = "TotalCajaDeAhorro"
                TotalOtrasDeducciones3.ParameterFieldName = "TotalOtrasDeducciones"
                TotalTotalEntregar3.ParameterFieldName = "TotalTotalEntregar"

                ''Se indica el valor que va a tomar el parametro   
                'myDiscreteValueIdNave.Value = Convert.ToInt32(cmbNave.SelectedValue)
                'myDiscreteValuePeriodoNominaID.Value = Convert.ToInt32(cmbPeriodoNomina.SelectedValue)
                'myDiscreteValueColaborador.Value = txtColaborador.Text
                'Dim fila As DataRowView
                'fila = cmbPeriodoNomina.SelectedItem

                myDiscreteValuePeriodoNomina.Value = lblPeriodoNomina.Text
                myDiscreteValueUserName.Value = Convert.ToString(Entidades.SesionUsuario.UsuarioSesion.PUserUsername)
                myDiscreteValueNombreArchivo.Value = Convert.ToString("ReporteNominaReal.rpt")


                myDiscreteValueTotalPuntualidadAsistencia3.Value = Convert.ToString(TotalPuntualidadAsistencia2.ToString("N0"))
                myDiscreteValueTotalGratificaciones3.Value = Convert.ToString(TotalGratificaciones2.ToString("N0"))
                myDiscreteValueTotalCajaAhorro3.Value = Convert.ToString(TotalCajaAhorro2.ToString("N0"))
                myDiscreteValueTotalIMSS3.Value = Convert.ToString(TotalIMSS2.ToString("N0"))
                myDiscreteValueTotalInfonavit3.Value = Convert.ToString(TotalInfonavit2.ToString("N0"))
                myDiscreteValueTotalPrestamos3.Value = Convert.ToString(TotalPrestamos2.ToString("N0"))
                myDiscreteValueTotalOtrasDeducciones3.Value = Convert.ToString(TotalOtrasDeducciones2.ToString("N0"))
                myDiscreteValueTotalTotalEntregar3.Value = Convert.ToString(TotalTotalEntregar2.ToString("N0"))
                myDiscreteValueTotalausentismos3.Value = Convert.ToString(Totalausentismos2.ToString("N0"))
                myDiscreteValueTotalpagoBruto3.Value = Convert.ToString(TotalpagoBruto.ToString("N0"))

                ''Se indica el valor que va a tomar el parametro   

                If cmbNave.SelectedValue = 2 Then
                    myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/YUYIN.JPG")
                    ''  myDiscreteValueNave.Value = Convert.ToString("YUYIN")

                ElseIf cmbNave.SelectedValue = 3 Then
                    myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/JEANS.JPG")
                    'myDiscreteValueNave.Value = Convert.ToString("JEANS")

                ElseIf cmbNave.SelectedValue = 4 Then
                    myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/MERANO.JPG")
                    'myDiscreteValueNave.Value = Convert.ToString("MERANO")

                ElseIf cmbNave.SelectedValue = 5 Then
                    myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/JEANS2.JPG")
                    'myDiscreteValueNave.Value = Convert.ToString("JEANS2")

                ElseIf cmbNave.SelectedValue = 43 Then
                    myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/GRUPOYUYIN.JPG")
                    'myDiscreteValueNave.Value = Convert.ToString("COMERCIALIZADORA")
                End If
                myDiscreteValueNave.Value = Convert.ToString("")
                ''Se asigna el valor del parametro '@Colaborador  '@NaveID   '@PeriodoNominaID 
                'Colaborador.CurrentValues.Add(myDiscreteValueColaborador)
                'IdNave.CurrentValues.Add(myDiscreteValueIdNave)
                'PeriodoNominaID.CurrentValues.Add(myDiscreteValuePeriodoNominaID)

                PeriodoNomina.CurrentValues.Add(myDiscreteValuePeriodoNomina)
                UserName.CurrentValues.Add(myDiscreteValueUserName)
                NombreArchivo.CurrentValues.Add(myDiscreteValueNombreArchivo)
                Nave.CurrentValues.Add(myDiscreteValueNave)
                ruta.CurrentValues.Add(myDiscreteValueRuta)


                TotalpagoBruto3.CurrentValues.Add(myDiscreteValueTotalpagoBruto3)
                TotalPuntualidadAsistencia3.CurrentValues.Add(myDiscreteValueTotalPuntualidadAsistencia3)
                TotalGratificaciones3.CurrentValues.Add(myDiscreteValueTotalGratificaciones3)
                Totalausentismos3.CurrentValues.Add(myDiscreteValueTotalausentismos3)
                TotalIMSS3.CurrentValues.Add(myDiscreteValueTotalIMSS3)
                TotalInfonavit3.CurrentValues.Add(myDiscreteValueTotalInfonavit3)
                TotalPrestamos3.CurrentValues.Add(myDiscreteValueTotalPrestamos3)
                TotalCajaAhorro3.CurrentValues.Add(myDiscreteValueTotalCajaAhorro3)
                TotalOtrasDeducciones3.CurrentValues.Add(myDiscreteValueTotalOtrasDeducciones3)
                TotalTotalEntregar3.CurrentValues.Add(myDiscreteValueTotalTotalEntregar3)

                ''Se asigna el valor a la variable que se enlazsa al reporte
                'Parametros.Add(Colaborador)
                'Parametros.Add(IdNave)
                'Parametros.Add(PeriodoNominaID)
                accionSemana.ParameterFieldName = "semana"
                valorAsignadoAccionEfectivo.Value = "Semana " + semanaPeriodo
                accionSemana.CurrentValues.Add(valorAsignadoAccionEfectivo)

                Parametros.Add(PeriodoNomina)
                Parametros.Add(ruta)
                Parametros.Add(UserName)
                Parametros.Add(NombreArchivo)
                Parametros.Add(Nave)

                Parametros.Add(TotalpagoBruto3)
                Parametros.Add(TotalPuntualidadAsistencia3)
                Parametros.Add(TotalGratificaciones3)
                Parametros.Add(Totalausentismos3)
                Parametros.Add(TotalIMSS3)
                Parametros.Add(TotalInfonavit3)
                Parametros.Add(TotalPrestamos3)
                Parametros.Add(TotalCajaAhorro3)
                Parametros.Add(TotalOtrasDeducciones3)
                Parametros.Add(TotalTotalEntregar3)

                Parametros.Add(accionSemana)

                Dim Report As New ReporteListaNomina
                Dim VisorReporte As New VisorReportesEnTablas

                Report.SetDataSource(ds.Tables("grdDeducciones"))
                VisorReporte.ReporteViewer.ReportSource = Report
                VisorReporte.ReporteViewer.ParameterFieldInfo = Parametros
                VisorReporte.Show()

                grdDeducciones.Rows.Clear()
                listaNominaReal = ObjBU.ListaNominaReal(idNave, 0, 0, txtColaborador.Text, "")
                AgregarFilaColaboradoresNominaReal(listaNominaReal, False)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImprimirReporteEfectivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirReporteEfectivoToolStripMenuItem.Click
        grdDeducciones.Rows.Clear()

        Dim idNave As Integer = CInt(cmbNave.SelectedValue)
        Dim idArea As Integer = 0
        Dim idDepartamento As Integer = 0
        Dim ObjBU As New Nomina.Negocios.CalcularNominaRealBU
        Dim listaNominaReal As List(Of Entidades.CalcularNominaReal)

        listaNominaReal = ObjBU.ListaNominaReal(idNave, 0, 0, txtColaborador.Text, "EFECTIVO")

        AgregarFilaColaboradoresNominaReal(listaNominaReal, True)
        Try
            If cmbNave.SelectedIndex > 0 Then

                Dim ds As New ListaCorteNominaDS
                Dim ObjDS As New ListaCorteNominaDS
                ds.Tables.Add("grdDeducciones")

                ''Se agregan las columnas
                Dim col As System.Data.DataColumn
                For Each dgvCol As DataGridViewColumn In Me.grdDeducciones.Columns
                    col = New System.Data.DataColumn(dgvCol.Name)
                    ds.Tables("grdDeducciones").Columns.Add(col)
                Next

                ''SE agregan las filas
                Dim row As System.Data.DataRow
                Dim colcount As Integer = Me.grdDeducciones.Columns.Count - 1

                For i As Integer = 0 To Me.grdDeducciones.Rows.Count - 1
                    row = ds.Tables("grdDeducciones").Rows.Add
                    For Each column As DataGridViewColumn In Me.grdDeducciones.Columns
                        row.Item(column.Index) = Me.grdDeducciones.Rows.Item(i).Cells(column.Index).Value
                    Next
                Next

                ''Se indica el tipo de parametro
                ''En este caso de tipo numerico

                'Colaborador.ParameterValueType = ParameterValueKind.StringParameter
                'IdNave.ParameterValueType = ParameterValueKind.NumberParameter
                'PeriodoNominaID.ParameterValueType = ParameterValueKind.NumberParameter

                PeriodoNomina.ParameterValueType = ParameterValueKind.StringParameter
                ruta.ParameterValueType = ParameterValueKind.StringParameter
                UserName.ParameterValueType = ParameterValueKind.StringParameter
                NombreArchivo.ParameterValueType = ParameterValueKind.StringParameter
                Nave.ParameterValueType = ParameterValueKind.StringParameter


                TotalpagoBruto3.ParameterValueType = ParameterValueKind.StringParameter
                TotalPuntualidadAsistencia3.ParameterValueType = ParameterValueKind.StringParameter
                TotalGratificaciones3.ParameterValueType = ParameterValueKind.StringParameter
                Totalausentismos3.ParameterValueType = ParameterValueKind.StringParameter
                TotalIMSS3.ParameterValueType = ParameterValueKind.StringParameter
                TotalInfonavit3.ParameterValueType = ParameterValueKind.StringParameter
                TotalPrestamos3.ParameterValueType = ParameterValueKind.StringParameter
                TotalCajaAhorro3.ParameterValueType = ParameterValueKind.StringParameter
                TotalOtrasDeducciones3.ParameterValueType = ParameterValueKind.StringParameter
                TotalTotalEntregar3.ParameterValueType = ParameterValueKind.StringParameter


                ''Se indica el nombre del parametro
                ''del procedimiento almacenado
                'Colaborador.ParameterFieldName = "@Colaborador"
                'IdNave.ParameterFieldName = "@NaveID"
                'PeriodoNominaID.ParameterFieldName = "@PeriodoNominaID"

                PeriodoNomina.ParameterFieldName = "PeriodoNomina"
                ruta.ParameterFieldName = "ruta"
                UserName.ParameterFieldName = "Usuario"
                NombreArchivo.ParameterFieldName = "NombreReporte"
                Nave.ParameterFieldName = "Nave"



                TotalpagoBruto3.ParameterFieldName = "TotalPagoBruto"
                TotalPuntualidadAsistencia3.ParameterFieldName = "TotalExtras"
                TotalGratificaciones3.ParameterFieldName = "TotalGratificaciones"
                Totalausentismos3.ParameterFieldName = "TotalAusentismos"
                TotalIMSS3.ParameterFieldName = "TotalIMSS"
                TotalInfonavit3.ParameterFieldName = "TotalInfonavit"
                TotalPrestamos3.ParameterFieldName = "TotalPrestamos"
                TotalCajaAhorro3.ParameterFieldName = "TotalCajaDeAhorro"
                TotalOtrasDeducciones3.ParameterFieldName = "TotalOtrasDeducciones"
                TotalTotalEntregar3.ParameterFieldName = "TotalTotalEntregar"

                ''Se indica el valor que va a tomar el parametro   
                'myDiscreteValueIdNave.Value = Convert.ToInt32(cmbNave.SelectedValue)
                'myDiscreteValuePeriodoNominaID.Value = Convert.ToInt32(cmbPeriodoNomina.SelectedValue)
                'myDiscreteValueColaborador.Value = txtColaborador.Text
                'Dim fila As DataRowView
                'fila = cmbPeriodoNomina.SelectedItem

                myDiscreteValuePeriodoNomina.Value = lblPeriodoNomina.Text
                myDiscreteValueUserName.Value = Convert.ToString(Entidades.SesionUsuario.UsuarioSesion.PUserUsername)
                myDiscreteValueNombreArchivo.Value = Convert.ToString("ReporteNominaReal.rpt")


                myDiscreteValueTotalPuntualidadAsistencia3.Value = Convert.ToString(TotalPuntualidadAsistencia2.ToString("N0"))
                myDiscreteValueTotalGratificaciones3.Value = Convert.ToString(TotalGratificaciones2.ToString("N0"))
                myDiscreteValueTotalCajaAhorro3.Value = Convert.ToString(TotalCajaAhorro2.ToString("N0"))
                myDiscreteValueTotalIMSS3.Value = Convert.ToString(TotalIMSS2.ToString("N0"))
                myDiscreteValueTotalInfonavit3.Value = Convert.ToString(TotalInfonavit2.ToString("N0"))
                myDiscreteValueTotalPrestamos3.Value = Convert.ToString(TotalPrestamos2.ToString("N0"))
                myDiscreteValueTotalOtrasDeducciones3.Value = Convert.ToString(TotalOtrasDeducciones2.ToString("N0"))
                myDiscreteValueTotalTotalEntregar3.Value = Convert.ToString(TotalTotalEntregar2.ToString("N0"))
                myDiscreteValueTotalausentismos3.Value = Convert.ToString(Totalausentismos2.ToString("N0"))
                myDiscreteValueTotalpagoBruto3.Value = Convert.ToString(TotalpagoBruto.ToString("N0"))

                ''Se indica el valor que va a tomar el parametro   

                If cmbNave.SelectedValue = 2 Then
                    '  myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/YUYIN.JPG")
                    myDiscreteValueNave.Value = Convert.ToString("YUYIN")

                ElseIf cmbNave.SelectedValue = 3 Then
                    'myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/JEANS.JPG")
                    'myDiscreteValueNave.Value = Convert.ToString("JEANS")

                ElseIf cmbNave.SelectedValue = 4 Then
                    ' myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/MERANO.JPG")
                    'myDiscreteValueNave.Value = Convert.ToString("MERANO")

                ElseIf cmbNave.SelectedValue = 5 Then
                    '  myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/JEANS2.JPG")
                    'myDiscreteValueNave.Value = Convert.ToString("JEANS2")

                ElseIf cmbNave.SelectedValue = 43 Then
                    '  myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/GRUPOYUYIN.JPG")
                    'myDiscreteValueNave.Value = Convert.ToString("COMERCIALIZADORA")
                End If
                myDiscreteValueRuta.Value = ("EFECTIVO")
                myDiscreteValueNave.Value = Convert.ToString("EFECTIVO")
                ''Se asigna el valor del parametro '@Colaborador  '@NaveID   '@PeriodoNominaID 
                'Colaborador.CurrentValues.Add(myDiscreteValueColaborador)
                'IdNave.CurrentValues.Add(myDiscreteValueIdNave)
                'PeriodoNominaID.CurrentValues.Add(myDiscreteValuePeriodoNominaID)

                PeriodoNomina.CurrentValues.Add(myDiscreteValuePeriodoNomina)
                UserName.CurrentValues.Add(myDiscreteValueUserName)
                NombreArchivo.CurrentValues.Add(myDiscreteValueNombreArchivo)
                Nave.CurrentValues.Add(myDiscreteValueNave)
                ruta.CurrentValues.Add(myDiscreteValueRuta)


                TotalpagoBruto3.CurrentValues.Add(myDiscreteValueTotalpagoBruto3)
                TotalPuntualidadAsistencia3.CurrentValues.Add(myDiscreteValueTotalPuntualidadAsistencia3)
                TotalGratificaciones3.CurrentValues.Add(myDiscreteValueTotalGratificaciones3)
                Totalausentismos3.CurrentValues.Add(myDiscreteValueTotalausentismos3)
                TotalIMSS3.CurrentValues.Add(myDiscreteValueTotalIMSS3)
                TotalInfonavit3.CurrentValues.Add(myDiscreteValueTotalInfonavit3)
                TotalPrestamos3.CurrentValues.Add(myDiscreteValueTotalPrestamos3)
                TotalCajaAhorro3.CurrentValues.Add(myDiscreteValueTotalCajaAhorro3)
                TotalOtrasDeducciones3.CurrentValues.Add(myDiscreteValueTotalOtrasDeducciones3)
                TotalTotalEntregar3.CurrentValues.Add(myDiscreteValueTotalTotalEntregar3)


                accionSemana.ParameterFieldName = "semana"
                valorAsignadoAccionEfectivo.Value = "Semana " + semanaPeriodo
                accionSemana.CurrentValues.Add(valorAsignadoAccionEfectivo)

                ''Se asigna el valor a la variable que se enlazsa al reporte
                'Parametros.Add(Colaborador)
                'Parametros.Add(IdNave)
                'Parametros.Add(PeriodoNominaID)

                Parametros.Add(PeriodoNomina)
                Parametros.Add(ruta)
                Parametros.Add(UserName)
                Parametros.Add(NombreArchivo)
                Parametros.Add(Nave)


                Parametros.Add(TotalpagoBruto3)
                Parametros.Add(TotalPuntualidadAsistencia3)
                Parametros.Add(TotalGratificaciones3)
                Parametros.Add(Totalausentismos3)
                Parametros.Add(TotalIMSS3)
                Parametros.Add(TotalInfonavit3)
                Parametros.Add(TotalPrestamos3)
                Parametros.Add(TotalCajaAhorro3)
                Parametros.Add(TotalOtrasDeducciones3)
                Parametros.Add(TotalTotalEntregar3)

                Parametros.Add(accionSemana)


                Dim Report As New ReporteListaNomina
                Dim VisorReporte As New VisorReportesEnTablas

                Report.SetDataSource(ds.Tables("grdDeducciones"))
                VisorReporte.ReporteViewer.ReportSource = Report
                VisorReporte.ReporteViewer.ParameterFieldInfo = Parametros
                VisorReporte.Show()

                grdDeducciones.Rows.Clear()
                listaNominaReal = ObjBU.ListaNominaReal(idNave, 0, 0, txtColaborador.Text, "")
                AgregarFilaColaboradoresNominaReal(listaNominaReal, False)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImprimirReporteDepósitoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirReporteDepósitoToolStripMenuItem.Click
        grdDeducciones.Rows.Clear()

        Dim idNave As Integer = CInt(cmbNave.SelectedValue)
        Dim idArea As Integer = 0
        Dim idDepartamento As Integer = 0
        Dim ObjBU As New Nomina.Negocios.CalcularNominaRealBU
        Dim listaNominaReal As List(Of Entidades.CalcularNominaReal)


        listaNominaReal = ObjBU.ListaNominaReal(idNave, 0, 0, txtColaborador.Text, "DEPOSITO")

        AgregarFilaColaboradoresNominaReal(listaNominaReal, True)
        Try
            If cmbNave.SelectedIndex > 0 Then
                'grdDeducciones.Rows.Clear()


                'Dim listaCorteNominaa As New List(Of Entidades.CalcularNominaReal)
                'Dim nomina As New Nomina.Negocios.CalcularNominaRealBU

                'listaCorteNominaa = nomina.ListaCorteNomina(cmbNave.SelectedValue, lblIdSemanaNomina.Text, txtColaborador.Text)
                'AgregarFilaColaboradoresNominaReal(listaCorteNominaa)

                Dim ds As New ListaCorteNominaDS
                Dim ObjDS As New ListaCorteNominaDS
                ds.Tables.Add("grdDeducciones")


                ''Se agregan las columnas
                Dim col As System.Data.DataColumn
                For Each dgvCol As DataGridViewColumn In Me.grdDeducciones.Columns
                    col = New System.Data.DataColumn(dgvCol.Name)
                    ds.Tables("grdDeducciones").Columns.Add(col)
                Next

                ''SE agregan las filas
                Dim row As System.Data.DataRow
                Dim colcount As Integer = Me.grdDeducciones.Columns.Count - 1

                For i As Integer = 0 To Me.grdDeducciones.Rows.Count - 1
                    row = ds.Tables("grdDeducciones").Rows.Add
                    For Each column As DataGridViewColumn In Me.grdDeducciones.Columns
                        row.Item(column.Index) = Me.grdDeducciones.Rows.Item(i).Cells(column.Index).Value
                    Next
                Next

                ''Se indica el tipo de parametro
                ''En este caso de tipo numerico

                'Colaborador.ParameterValueType = ParameterValueKind.StringParameter
                'IdNave.ParameterValueType = ParameterValueKind.NumberParameter
                'PeriodoNominaID.ParameterValueType = ParameterValueKind.NumberParameter

                PeriodoNomina.ParameterValueType = ParameterValueKind.StringParameter
                ruta.ParameterValueType = ParameterValueKind.StringParameter
                UserName.ParameterValueType = ParameterValueKind.StringParameter
                NombreArchivo.ParameterValueType = ParameterValueKind.StringParameter
                Nave.ParameterValueType = ParameterValueKind.StringParameter


                TotalpagoBruto3.ParameterValueType = ParameterValueKind.StringParameter
                TotalPuntualidadAsistencia3.ParameterValueType = ParameterValueKind.StringParameter
                TotalGratificaciones3.ParameterValueType = ParameterValueKind.StringParameter
                Totalausentismos3.ParameterValueType = ParameterValueKind.StringParameter
                TotalIMSS3.ParameterValueType = ParameterValueKind.StringParameter
                TotalInfonavit3.ParameterValueType = ParameterValueKind.StringParameter
                TotalPrestamos3.ParameterValueType = ParameterValueKind.StringParameter
                TotalCajaAhorro3.ParameterValueType = ParameterValueKind.StringParameter
                TotalOtrasDeducciones3.ParameterValueType = ParameterValueKind.StringParameter
                TotalTotalEntregar3.ParameterValueType = ParameterValueKind.StringParameter


                ''Se indica el nombre del parametro
                ''del procedimiento almacenado
                'Colaborador.ParameterFieldName = "@Colaborador"
                'IdNave.ParameterFieldName = "@NaveID"
                'PeriodoNominaID.ParameterFieldName = "@PeriodoNominaID"

                PeriodoNomina.ParameterFieldName = "PeriodoNomina"
                ruta.ParameterFieldName = "ruta"
                UserName.ParameterFieldName = "Usuario"
                NombreArchivo.ParameterFieldName = "NombreReporte"
                Nave.ParameterFieldName = "Nave"


                TotalpagoBruto3.ParameterFieldName = "TotalPagoBruto"
                TotalPuntualidadAsistencia3.ParameterFieldName = "TotalExtras"
                TotalGratificaciones3.ParameterFieldName = "TotalGratificaciones"
                Totalausentismos3.ParameterFieldName = "TotalAusentismos"
                TotalIMSS3.ParameterFieldName = "TotalIMSS"
                TotalInfonavit3.ParameterFieldName = "TotalInfonavit"
                TotalPrestamos3.ParameterFieldName = "TotalPrestamos"
                TotalCajaAhorro3.ParameterFieldName = "TotalCajaDeAhorro"
                TotalOtrasDeducciones3.ParameterFieldName = "TotalOtrasDeducciones"
                TotalTotalEntregar3.ParameterFieldName = "TotalTotalEntregar"

                ''Se indica el valor que va a tomar el parametro   
                'myDiscreteValueIdNave.Value = Convert.ToInt32(cmbNave.SelectedValue)
                'myDiscreteValuePeriodoNominaID.Value = Convert.ToInt32(cmbPeriodoNomina.SelectedValue)
                'myDiscreteValueColaborador.Value = txtColaborador.Text
                'Dim fila As DataRowView
                'fila = cmbPeriodoNomina.SelectedItem

                myDiscreteValuePeriodoNomina.Value = lblPeriodoNomina.Text
                myDiscreteValueUserName.Value = Convert.ToString(Entidades.SesionUsuario.UsuarioSesion.PUserUsername)
                myDiscreteValueNombreArchivo.Value = Convert.ToString("ReporteNominaReal.rpt")


                myDiscreteValueTotalPuntualidadAsistencia3.Value = Convert.ToString(TotalPuntualidadAsistencia2.ToString("N0"))
                myDiscreteValueTotalGratificaciones3.Value = Convert.ToString(TotalGratificaciones2.ToString("N0"))
                myDiscreteValueTotalCajaAhorro3.Value = Convert.ToString(TotalCajaAhorro2.ToString("N0"))
                myDiscreteValueTotalIMSS3.Value = Convert.ToString(TotalIMSS2.ToString("N0"))
                myDiscreteValueTotalInfonavit3.Value = Convert.ToString(TotalInfonavit2.ToString("N0"))
                myDiscreteValueTotalPrestamos3.Value = Convert.ToString(TotalPrestamos2.ToString("N0"))
                myDiscreteValueTotalOtrasDeducciones3.Value = Convert.ToString(TotalOtrasDeducciones2.ToString("N0"))
                myDiscreteValueTotalTotalEntregar3.Value = Convert.ToString(TotalTotalEntregar2.ToString("N0"))
                myDiscreteValueTotalausentismos3.Value = Convert.ToString(Totalausentismos2.ToString("N0"))
                myDiscreteValueTotalpagoBruto3.Value = Convert.ToString(TotalpagoBruto.ToString("N0"))



                ''Se indica el valor que va a tomar el parametro   

                If cmbNave.SelectedValue = 2 Then
                    myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/YUYIN.JPG")
                    ' myDiscreteValueNave.Value = Convert.ToString("YUYIN")

                ElseIf cmbNave.SelectedValue = 3 Then
                    myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/JEANS.JPG")
                    '  myDiscreteValueNave.Value = Convert.ToString("JEANS")

                ElseIf cmbNave.SelectedValue = 4 Then
                    myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/MERANO.JPG")
                    ' myDiscreteValueNave.Value = Convert.ToString("MERANO")

                ElseIf cmbNave.SelectedValue = 5 Then
                    myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/JEANS2.JPG")
                    ' myDiscreteValueNave.Value = Convert.ToString("JEANS2")

                ElseIf cmbNave.SelectedValue = 43 Then
                    myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/GRUPOYUYIN.JPG")
                    '  myDiscreteValueNave.Value = Convert.ToString("COMERCIALIZADORA")
                End If
                myDiscreteValueNave.Value = Convert.ToString("DEPÓSITO")

                ''Se asigna el valor del parametro '@Colaborador  '@NaveID   '@PeriodoNominaID 
                'Colaborador.CurrentValues.Add(myDiscreteValueColaborador)
                'IdNave.CurrentValues.Add(myDiscreteValueIdNave)
                'PeriodoNominaID.CurrentValues.Add(myDiscreteValuePeriodoNominaID)

                PeriodoNomina.CurrentValues.Add(myDiscreteValuePeriodoNomina)
                UserName.CurrentValues.Add(myDiscreteValueUserName)
                NombreArchivo.CurrentValues.Add(myDiscreteValueNombreArchivo)
                Nave.CurrentValues.Add(myDiscreteValueNave)
                ruta.CurrentValues.Add(myDiscreteValueRuta)


                TotalpagoBruto3.CurrentValues.Add(myDiscreteValueTotalpagoBruto3)
                TotalPuntualidadAsistencia3.CurrentValues.Add(myDiscreteValueTotalPuntualidadAsistencia3)
                TotalGratificaciones3.CurrentValues.Add(myDiscreteValueTotalGratificaciones3)
                Totalausentismos3.CurrentValues.Add(myDiscreteValueTotalausentismos3)
                TotalIMSS3.CurrentValues.Add(myDiscreteValueTotalIMSS3)
                TotalInfonavit3.CurrentValues.Add(myDiscreteValueTotalInfonavit3)
                TotalPrestamos3.CurrentValues.Add(myDiscreteValueTotalPrestamos3)
                TotalCajaAhorro3.CurrentValues.Add(myDiscreteValueTotalCajaAhorro3)
                TotalOtrasDeducciones3.CurrentValues.Add(myDiscreteValueTotalOtrasDeducciones3)
                TotalTotalEntregar3.CurrentValues.Add(myDiscreteValueTotalTotalEntregar3)


                accionSemana.ParameterFieldName = "semana"
                valorAsignadoAccionEfectivo.Value = "Semana " + semanaPeriodo
                accionSemana.CurrentValues.Add(valorAsignadoAccionEfectivo)


                ''Se asigna el valor a la variable que se enlazsa al reporte
                'Parametros.Add(Colaborador)
                'Parametros.Add(IdNave)
                'Parametros.Add(PeriodoNominaID)

                Parametros.Add(PeriodoNomina)
                Parametros.Add(ruta)
                Parametros.Add(UserName)
                Parametros.Add(NombreArchivo)
                Parametros.Add(Nave)

                Parametros.Add(TotalpagoBruto3)
                Parametros.Add(TotalPuntualidadAsistencia3)
                Parametros.Add(TotalGratificaciones3)
                Parametros.Add(Totalausentismos3)
                Parametros.Add(TotalIMSS3)
                Parametros.Add(TotalInfonavit3)
                Parametros.Add(TotalPrestamos3)
                Parametros.Add(TotalCajaAhorro3)
                Parametros.Add(TotalOtrasDeducciones3)
                Parametros.Add(TotalTotalEntregar3)

                Parametros.Add(accionSemana)

                Dim Report As New ReporteListaNomina
                Dim VisorReporte As New VisorReportesEnTablas

                Report.SetDataSource(ds.Tables("grdDeducciones"))
                VisorReporte.ReporteViewer.ReportSource = Report
                VisorReporte.ReporteViewer.ParameterFieldInfo = Parametros
                VisorReporte.Show()

                grdDeducciones.Rows.Clear()
                listaNominaReal = ObjBU.ListaNominaReal(idNave, 0, 0, txtColaborador.Text, "")
                AgregarFilaColaboradoresNominaReal(listaNominaReal, False)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


    Public Sub cmbNaveDrop()
        Dim objBu As New Negocios.CorteNominaRealBU
        Dim tabla As New DataTable
        tabla = objBu.obtenerNaveIDsicy(cmbNave.SelectedValue)
        If tabla.Rows.Count > 0 Then
            naveSICYID = tabla.Rows(0).Item("nave_navesicyid")
        End If

        grdDeducciones.Rows.Clear()
        Tools.Controles.ComboAreaSegunNave(cmbArea, cmbNave.SelectedValue)
        NaveIDSICY = 0
        lblPeriodoNomina.Text = ""
        lblIdSemanaNomina.Text = ""
        lblSemanaNominaFIN.Text = ""
        lblPeriodoAsistencia.Text = ""
        lblPeriodoCajaAhorro.Text = ""
        lblPeriodoPrestamos.Text = ""
        lblPeriodoDeducciones.Text = ""
        lblPeriodoFiscal.Text = ""
        lblPeriodoNomina.Text = ""
        lblPeriodoDestajos.Text = ""
        SemanaNomina()
    End Sub

    Public Function RealziarCalculoRetencionFiscalIMSS(ByVal ColaboradorID As Integer, ByVal Salariodiario As Double, ByVal FechaIngreso As DateTime)
        Dim IMSS As Double
        Dim AntiguedadAnios As Integer = 0
        Dim diastrabajados As Integer = 0
        Dim FactorIntegracion As Double = 0
        Dim SalarioIntegrado As Double = 0
        Dim DiasLabo As Integer = 7
        Dim SalarioSema As Double = 0
        Dim SalarioMes As Double = 0
        Dim PuntualidadAsistencia As Double = 0
        Dim TotalGravado As Double = 0
        Dim Despensa As Double = 0
        Dim LimiteInferior As Double = 0
        Dim Excedente As Double = 0
        Dim TasaImpuesto As Double = 0
        Dim ImpuestoMarginal As Double = 0
        Dim CuotaFija As Double = 0
        Dim IsrDeterminado As Double = 0
        Dim SubsidioEmpleo As Double = 0
        Dim SubsidioXPagar As Double = 0
        Dim SalarioBaseCotizacion As Double = 0

        'Configuracion fiscal
        Dim SalarioMinimo As Double = 0
        Dim CuotaPorExcedente As Double = 0
        Dim PrestacionesDinero As Double = 0
        Dim GastosMedicos As Double = 0
        Dim InvalidezVida As Double = 0
        Dim Cesantia As Double = 0

        Dim ExcedenteSalarioMin As Double = 0

        Dim TotalExcedente As Double = 0
        Dim Factor As Double = 0
        Dim TotalRetener As Double = 0

        diastrabajados = (Now.Date - FechaIngreso).TotalDays
        AntiguedadAnios = Math.Round(diastrabajados / 365, 0)
        If AntiguedadAnios = 0 Then
            AntiguedadAnios = 1
        End If
        ''Factor Integracion
        Dim ListaFactorIntegracion As New List(Of Entidades.CalcularNominaReal)
        Dim ObjBU As New Nomina.Negocios.CalcularNominaRealBU
        ListaFactorIntegracion = ObjBU.FactorIntegracion(AntiguedadAnios)

        For Each fila As Entidades.CalcularNominaReal In ListaFactorIntegracion
            FactorIntegracion = fila.PFactorIntegracion
        Next
        ''Total Gravado
        SalarioIntegrado = Salariodiario * FactorIntegracion
        SalarioSema = DiasLabo * SalarioIntegrado
        SalarioMes = SalarioIntegrado * 30.4
        PuntualidadAsistencia = (SalarioSema * 0.1)

        TotalGravado = SalarioSema + PuntualidadAsistencia + Despensa

        ''Limite Inferior
        Dim ListaLimiteInferior As New List(Of Entidades.CalcularNominaReal)
        ListaLimiteInferior = ObjBU.LimiteInferior(TotalGravado)
        For Each fila As Entidades.CalcularNominaReal In ListaLimiteInferior
            LimiteInferior = fila.PLimiteInferior
            TasaImpuesto = fila.PTasaImpuesto
            CuotaFija = fila.PCuotaFija
        Next

        'Excedente Sobre limite inferior
        Excedente = TotalGravado - LimiteInferior

        'Impuesto Marginal
        ImpuestoMarginal = Excedente * (TasaImpuesto / 100)

        ''ISR DETERMINADO
        IsrDeterminado = ImpuestoMarginal + CuotaFija

        ''Subsidio para el empleo
        Dim ListaSubsidioEmpleo As New List(Of Entidades.CalcularNominaReal)
        ListaSubsidioEmpleo = ObjBU.SubsidioEmpleo(TotalGravado)
        For Each fila As Entidades.CalcularNominaReal In ListaSubsidioEmpleo
            SubsidioEmpleo = fila.PSubsidioEmpleo
        Next
        ''Subsidio por pagar
        SubsidioXPagar = SubsidioEmpleo - IsrDeterminado
        If SubsidioXPagar < 0 Then
            SubsidioXPagar = 0
        End If

        'Salario base de cotizacion
        SalarioBaseCotizacion = Salariodiario / FactorIntegracion

        '3 Salarios minimos Zona A (CONFIGURACION FISCAL)
        Dim ListaSalariosMinimos As New List(Of Entidades.CalcularNominaReal)
        ListaSalariosMinimos = ObjBU.configuracionFiscal
        For Each fila As Entidades.CalcularNominaReal In ListaSalariosMinimos
            PrestacionesDinero = fila.PPrestacionesDinero
            GastosMedicos = fila.PGastosMedicos
            InvalidezVida = fila.PinvalidezVida
            Cesantia = fila.PCesantia
            CuotaPorExcedente = fila.PCuotaExedente
            SalarioMinimo = fila.PSalarioMinimo
            SalarioMinimo = SalarioMinimo * 3
        Next
        ExcedenteSalarioMin = Salariodiario - SalarioMinimo

        If ExcedenteSalarioMin > 0 Then
            TotalExcedente = DiasLabo * (CuotaPorExcedente)
        End If
        Factor = (PrestacionesDinero + GastosMedicos + InvalidezVida + Cesantia) / 100
        TotalRetener = ((Salariodiario * Factor * DiasLabo)) + TotalExcedente

        For Each fila As Entidades.CalcularNominaReal In ListaSalariosMinimos
            TotalRetener = fila.PRetencionIMMS
            IsrDeterminado = fila.PRetencionISR
        Next


        'IMSS = Math.Round(TotalRetener, 0) + Math.Round(IsrDeterminado, 0)

        Return IMSS
    End Function

    Private Sub ImprimirRecibosDeNóminaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirRecibosDeNóminaToolStripMenuItem.Click

        Dim contador As Integer = 0
        For Each row As DataGridViewRow In grdDeducciones.Rows
            contador += 1
            Exit For
        Next

        If contador > 0 Then
            Dim Recibos = New DataTable("Recibos")
            With Recibos
                .Columns.Add("IDColaborador")
                .Columns.Add("NombreColaborador")
                .Columns.Add("FechaDePago")
                .Columns.Add("FechaInicioNomina")
                .Columns.Add("FechaFinNomina")
                .Columns.Add("PagoBruto")
                .Columns.Add("Extras")
                .Columns.Add("Otros")
                .Columns.Add("Faltas")
                .Columns.Add("Ausentismo")
                .Columns.Add("SeguroInfonavit")
                .Columns.Add("CajaAhorro")
                .Columns.Add("PrestamosDeduccionesExtraordinarias")
                .Columns.Add("TotalIngresos")
                .Columns.Add("TotalDeducciones")
                .Columns.Add("PagoNeto")
                .Columns.Add("ISR")
                .Columns.Add("NaveID")
                .Columns.Add("Concepto")
                .Columns.Add("ConsecutivoReciboEfectivo")
                .Columns.Add("NUMRECIBO")
            End With
            Dim consReciboNominaeEFECTIVO As Int32 = 0
            Dim consDEPOSITO As Int32 = 0
            Dim datoConsEnviar As String = ""
            Dim NUMRECIBO As String = ""
            Dim contadorEmpleados As Integer = 1
            For Each row As DataGridViewRow In grdDeducciones.Rows
                If row.Cells("clmIDcolaborador").Value.ToString <> "" Then

                    If row.Cells("clmTipoSueldo").Value = "EFECTIVO" Then
                        consReciboNominaeEFECTIVO += 1
                        datoConsEnviar = consReciboNominaeEFECTIVO.ToString
                        NUMRECIBO = "EFECTIVO No. "
                    Else
                        consDEPOSITO += 1
                        datoConsEnviar = consDEPOSITO.ToString
                        NUMRECIBO = "DEPÓSITO No. "
                    End If

                    Dim TotalIngresos As Double = 0
                    Dim TotalDeducciones As Double = 0
                    Dim PagoNeto As Double = 0
                    Dim ISRDescontado As Double = CDbl(row.Cells("clmISR").Value)

                    TotalIngresos = CDbl(row.Cells("clmSalarioSemanal").Value) + CDbl(row.Cells("clmPuntualidadAsistencia").Value) + CDbl(row.Cells("clmGratificaciones").Value)
                    TotalDeducciones = CDbl(row.Cells("clmAusentismos").Value) + CDbl(row.Cells("clmIMMS").Value) + CDbl(row.Cells("clmInfonavit").Value) + CDbl(row.Cells("clmCajaDeAhorro").Value) + CDbl(row.Cells("clmPrestamos").Value) + CDbl(row.Cells("clmOtrasDeducciones").Value) '+ ISRDescontado '' CDbl(row.Cells("clmISR").Value)
                    PagoNeto = TotalIngresos - TotalDeducciones
                    Recibos.Rows.Add(
                        contadorEmpleados,
                        row.Cells("clmColaborador").Value,
                        fechaFinal.ToShortDateString,
                        FechaInicio.ToShortDateString,
                        fechaFinal.ToShortDateString,
                        CDbl(row.Cells("clmSalarioSemanal").Value),
                        CDbl(row.Cells("clmPuntualidadAsistencia").Value),
                        CDbl(row.Cells("clmGratificaciones").Value),
                        CDbl(row.Cells("clmDiasTrabajados").Value),
                        CDbl(row.Cells("clmAusentismos").Value),
                        ((CDbl(row.Cells("clmIMMS").Value) - ISRDescontado) + CDbl(row.Cells("clmInfonavit").Value)),
                        row.Cells("clmCajaDeAhorro").Value,
                        (CDbl(row.Cells("clmPrestamos").Value) + CDbl(row.Cells("clmOtrasDeducciones").Value)),
                        TotalIngresos,
                        TotalDeducciones,
                        PagoNeto,
                        ISRDescontado,
                        naveSICYID,
                        row.Cells("clmConceptoGratificaciones").Value,
                        datoConsEnviar,
                        NUMRECIBO
                    )
                    contadorEmpleados = contadorEmpleados + 1
                End If
            Next

            Me.Cursor = Cursors.WaitCursor
            Dim OBJBU As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            EntidadReporte = OBJBU.LeerReporteporClave("NOM_RECB_NOM")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                EntidadReporte.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport
            reporte.Load(archivo)
            reporte("DiaFestivo") = ""
            reporte.Compile()
            reporte.RegData(Recibos)
            reporte.Show()
            Me.Cursor = Cursors.Default
        End If
    End Sub


    Private Sub ImprimirRecibosDiaFestivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirRecibosDiaFestivoToolStripMenuItem.Click

        ''comentado cambia formato de recibos de dia festivo
        ImprimirRecibosDiaFestivoToolStripMenuItem.Enabled = True
        Dim ObjDate As New DateForm
        Dim Fecha As DateTime
        Dim diaFestivo As String = ""
        With ObjDate
            .mensaje = "SELECCIONAR EL DIA A PAGAR."
            .ShowDialog()
            Fecha = .Dia
        End With

        Dim recibosFecha = New DataTable("Recibos")
        With recibosFecha
            .Columns.Add("Fecha")
            .Columns.Add("Colaborador")

        End With

        For Each row As DataGridViewRow In grdDeducciones.Rows
            If row.Cells("clmColaborador").Value.ToString <> "" Then
                recibosFecha.Rows.Add(Fecha.ToLongDateString.ToUpper, row.Cells("clmColaborador").Value)
            End If
        Next
        diaFestivo = recibosFecha.Rows(0).Item("Fecha").ToString
        ' diaFestivo = Fecha.ToShortDateString
        'Me.Cursor = Cursors.WaitCursor
        'Dim OBJBU As New Framework.Negocios.ReportesBU
        'Dim EntidadReporte As Entidades.Reportes
        'EntidadReporte = OBJBU.LeerReporteporClave("NOM_RECB_DFEST")
        'Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
        '    EntidadReporte.Pnombre + ".mrt"
        'My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        'Dim reporte As New StiReport
        'reporte.Load(archivo)
        'reporte.Compile()
        'reporte.RegData(recibosFecha)
        'reporte.Show()
        'Me.Cursor = Cursors.Default

        'Dim contador As Integer = 0
        'For Each row As DataGridViewRow In grdDeducciones.Rows
        '    contador += 1
        '    Exit For
        'Next

        ''metodo imprimir recibos de pago
        Dim contador As Integer = 0
        For Each row As DataGridViewRow In grdDeducciones.Rows
            contador += 1
            Exit For
        Next
        If contador > 0 Then
            Dim Recibos = New DataTable("Recibos")
            With Recibos
                .Columns.Add("IDColaborador")
                .Columns.Add("NombreColaborador")
                .Columns.Add("FechaDePago")
                .Columns.Add("FechaInicioNomina")
                .Columns.Add("FechaFinNomina")
                .Columns.Add("PagoBruto")
                .Columns.Add("Extras")
                .Columns.Add("Otros")
                .Columns.Add("Faltas")
                .Columns.Add("Ausentismo")
                .Columns.Add("SeguroInfonavit")
                .Columns.Add("CajaAhorro")
                .Columns.Add("PrestamosDeduccionesExtraordinarias")
                .Columns.Add("TotalIngresos")
                .Columns.Add("TotalDeducciones")
                .Columns.Add("PagoNeto")
                .Columns.Add("ISR")
                .Columns.Add("NaveID")
                .Columns.Add("Concepto")
                .Columns.Add("ConsecutivoReciboEfectivo")
                .Columns.Add("NUMRECIBO")
            End With
            Dim consReciboNominaeEFECTIVO As Int32 = 0
            Dim consDEPOSITO As Int32 = 0
            Dim datoConsEnviar As String = ""
            Dim NUMRECIBO As String = ""
            Dim contadorEmpleados As Integer = 1
            For Each row As DataGridViewRow In grdDeducciones.Rows
                If row.Cells("clmIDcolaborador").Value.ToString <> "" Then

                    If row.Cells("clmTipoSueldo").Value = "EFECTIVO" Then
                        consReciboNominaeEFECTIVO += 1
                        datoConsEnviar = consReciboNominaeEFECTIVO.ToString
                        NUMRECIBO = "EFECTIVO No. "
                    Else
                        consDEPOSITO += 1
                        datoConsEnviar = consDEPOSITO.ToString
                        NUMRECIBO = "DEPÓSITO No. "
                    End If

                    Dim TotalIngresos As Double = 0
                    Dim TotalDeducciones As Double = 0
                    Dim PagoNeto As Double = 0
                    TotalIngresos = CDbl(row.Cells("clmSalarioSemanal").Value) + CDbl(row.Cells("clmPuntualidadAsistencia").Value) + CDbl(row.Cells("clmGratificaciones").Value)
                    TotalDeducciones = CDbl(row.Cells("clmAusentismos").Value) + CDbl(row.Cells("clmRespaldoIMSSMonto").Value) + CDbl(row.Cells("clmInfonavit").Value) + CDbl(row.Cells("clmCajaDeAhorro").Value) + CDbl(row.Cells("clmPrestamos").Value) + CDbl(row.Cells("clmOtrasDeducciones").Value) + CDbl(row.Cells("clmISR").Value)
                    PagoNeto = TotalIngresos - TotalDeducciones
                    Recibos.Rows.Add(
                        contadorEmpleados,
                                                   row.Cells("clmColaborador").Value,
                                                   fechaFinal.ToShortDateString,
                                                   FechaInicio.ToShortDateString,
                                                   fechaFinal.ToShortDateString,
                                                   row.Cells("clmSalarioSemanal").Value,
                                                   row.Cells("clmPuntualidadAsistencia").Value,
                                                   row.Cells("clmGratificaciones").Value,
                                                   row.Cells("clmDiasTrabajados").Value,
                                                   row.Cells("clmAusentismos").Value,
                                                   (CDbl(row.Cells("clmRespaldoIMSSMonto").Value) + CDbl(row.Cells("clmInfonavit").Value)),
                                                   row.Cells("clmCajaDeAhorro").Value,
                                                    (CDbl(row.Cells("clmPrestamos").Value) + CDbl(row.Cells("clmOtrasDeducciones").Value)),
                                    TotalIngresos,
                                    TotalDeducciones,
                                    PagoNeto,
                      CDbl(row.Cells("clmISR").Value),
                      naveSICYID,
                      row.Cells("clmConceptoGratificaciones").Value,
                            datoConsEnviar,
                            NUMRECIBO
                                                    )
                    contadorEmpleados = contadorEmpleados + 1
                End If
            Next

            Me.Cursor = Cursors.WaitCursor
            Dim objBu As New Framework.Negocios.ReportesBU
            Dim EntidadRepor As Entidades.Reportes
            EntidadRepor = objBu.LeerReporteporClave("NOM_RECB_NOM")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                EntidadRepor.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadRepor.Pxml, False)
            Dim reporte As New StiReport
            reporte.Load(archivo)
            reporte.Compile()
            reporte("DiaFestivo") = "* RECIBI PAGO DE DIA FESTIVO CORRESPONDIENTE AL " & diaFestivo

            reporte.RegData(Recibos)
            reporte.Show()
            Me.Cursor = Cursors.Default
        End If


    End Sub

    Private Sub ImprimirSobrePorEfectivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirSobrePorEfectivoToolStripMenuItem.Click
        Try

            Dim contador As Integer = 0
            For Each row As DataGridViewRow In grdDeducciones.Rows
                If row.Cells("clmTipoSueldo").Value = "EFECTIVO" Then
                    contador += 1
                    Exit For
                End If

            Next

            If contador > 0 Then
                ImprimirSobrePorEfectivoToolStripMenuItem.Enabled = True
                Dim Recibos = New DataTable("Recibos")

                With Recibos
                    .Columns.Add("iDColaborador")
                    .Columns.Add("Colaborador")
                End With

                For Each fila As DataGridViewRow In grdDeducciones.Rows
                    If fila.Cells("clmTipoSueldo").Value = "EFECTIVO" Then
                        Recibos.Rows.Add(fila.Cells("clmIdAnual").Value, fila.Cells("clmColaborador").Value)
                    End If
                Next

                Me.Cursor = Cursors.WaitCursor
                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("NOM_IMP_SOBRES")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                reporte.RegData(Recibos)
                reporte.Show()
                Me.Cursor = Cursors.Default
            Else
                ImprimirSobrePorEfectivoToolStripMenuItem.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ImprimirResumenDeNóminaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirResumenDeNóminaToolStripMenuItem.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Dim listaCorteNominaa As New List(Of Entidades.CalcularNominaReal)
            Dim nomina As New Nomina.Negocios.CalcularNominaRealBU
            Dim totalNominaFiscal As Double = 0

            listaCorteNominaa = nomina.ListaNominaReal(cmbNave.SelectedValue, 0, 0, txtColaborador.Text, "")
            'listaCorteNominaa = nomina.ListaCorteNomina(cmbNave.SelectedValue, lblIdSemanaNomina.Text, txtColaborador.Text, "")
            AgregarFilaColaboradoresNominaReal(listaCorteNominaa, True)

            totalNominaFiscal = nomina.ConsultaTotalNominaFiscal(CInt(lblIdSemanaNomina.Text))

            Dim contador As Integer = 0
            contador = grdDeducciones.RowCount
            If contador > 0 Then


                Dim Resumen = New DataSet("Resumen")
                Dim Deposito = New DataTable("Deposito")
                Dim Efectivo = New DataTable("Efectivo")
                Dim PagoBruto As Double = 0
                Dim Extras As Double = 0
                Dim Otros As Double = 0
                Dim Ausentismos As Double = 0
                Dim Seguro As Double = 0
                Dim Prestamos As Double = 0
                Dim CajaAhorro As Double = 0
                Dim PagoNeto As Double = 0
                Dim TotalDeducciones As Double = 0
                Dim TotalPercepciones As Double = 0

                With Deposito
                    .Columns.Add("PagoBruto")
                    .Columns.Add("Extras")
                    .Columns.Add("Otros")
                    .Columns.Add("Ausentismos")
                    .Columns.Add("Seguro")
                    .Columns.Add("Prestamos")
                    .Columns.Add("CajaAhorro")
                    .Columns.Add("PagoNeto")
                    .Columns.Add("FechaInicio")
                    .Columns.Add("FechaFin")
                    .Columns.Add("TotalPercepciones")
                    .Columns.Add("TotalDeducciones")


                End With
                Dim montoIMSS As Double = 0
                For Each fila As DataGridViewRow In grdDeducciones.Rows
                    If fila.Cells("clmTipoSueldo").Value = "DEPOSITO" Then
                        PagoBruto += fila.Cells("clmSalarioRegistrado").Value
                        Extras += fila.Cells("clmPuntualidadAsistencia").Value
                        Otros += fila.Cells("clmGratificaciones").Value
                        Ausentismos += fila.Cells("clmAusentismos").Value

                        montoIMSS = 0
                        If fila.Cells("clmIMMS").Value = 0 Then
                            montoIMSS = fila.Cells("clmIMMS").Value
                        Else
                            montoIMSS = fila.Cells("clmRespaldoIMSSMonto").Value
                        End If

                        'Seguro += CDbl(montoIMSS) + CDbl(fila.Cells("clmInfonavit").Value) + CDbl(fila.Cells("clmISR").Value)
                        Seguro += CDbl(fila.Cells("clmIMMS").Value) + CDbl(fila.Cells("clmInfonavit").Value)


                        Prestamos += CDbl(fila.Cells("clmPrestamos").Value) + CDbl(fila.Cells("clmOtrasDeducciones").Value)
                        CajaAhorro += fila.Cells("clmCajaDeAhorro").Value
                    End If
                Next
                'TotalPercepciones = PagoBruto + Extras + Otros - Ausentismos
                TotalPercepciones = PagoBruto + Extras + Otros - Ausentismos - Seguro
                TotalDeducciones = Prestamos + CajaAhorro
                PagoNeto = TotalPercepciones - TotalDeducciones
                Deposito.Rows.Add(PagoBruto, Extras, Otros, Ausentismos, Seguro, Prestamos, CajaAhorro, PagoNeto, FechaInicio.ToLongDateString.ToUpper, fechaFinal.ToLongDateString.ToUpper, TotalPercepciones, TotalDeducciones)

                With Efectivo
                    .Columns.Add("PagoBruto")
                    .Columns.Add("Extras")
                    .Columns.Add("Otros")
                    .Columns.Add("Ausentismos")
                    .Columns.Add("Seguro")
                    .Columns.Add("Prestamos")
                    .Columns.Add("CajaAhorro")
                    .Columns.Add("PagoNeto")
                    .Columns.Add("FechaInicio")
                    .Columns.Add("FechaFin")
                    .Columns.Add("TotalPercepciones")
                    .Columns.Add("TotalDeducciones")


                End With

                PagoBruto = 0
                Extras = 0
                Otros = 0
                Ausentismos = 0
                Seguro = 0
                Prestamos = 0
                CajaAhorro = 0
                PagoNeto = 0
                TotalPercepciones = 0
                For Each fila As DataGridViewRow In grdDeducciones.Rows
                    If fila.Cells("clmTipoSueldo").Value = "EFECTIVO" Then
                        PagoBruto += fila.Cells("clmSalarioRegistrado").Value
                        Extras += fila.Cells("clmPuntualidadAsistencia").Value
                        Otros += fila.Cells("clmGratificaciones").Value
                        Ausentismos += fila.Cells("clmAusentismos").Value

                        montoIMSS = 0
                        If fila.Cells("clmIMMS").Value = 0 Then
                            montoIMSS = fila.Cells("clmIMMS").Value
                        Else
                            montoIMSS = fila.Cells("clmRespaldoIMSSMonto").Value
                        End If


                        Seguro += CDbl(montoIMSS) + CDbl(fila.Cells("clmInfonavit").Value) + CDbl(fila.Cells("clmISR").Value)
                        Prestamos += CDbl(fila.Cells("clmPrestamos").Value) + CDbl(fila.Cells("clmOtrasDeducciones").Value)
                        CajaAhorro += fila.Cells("clmCajaDeAhorro").Value

                    End If
                Next
                'TotalPercepciones = PagoBruto + Extras + Otros - Ausentismos
                'TotalDeducciones = Seguro + Prestamos + CajaAhorro
                TotalPercepciones = PagoBruto + Extras + Otros - Ausentismos - Seguro
                TotalDeducciones = Prestamos + CajaAhorro
                PagoNeto = TotalPercepciones - TotalDeducciones
                Efectivo.Rows.Add(PagoBruto, Extras, Otros, Ausentismos, Seguro, Prestamos, CajaAhorro, PagoNeto, FechaInicio.ToLongDateString.ToUpper, fechaFinal.ToLongDateString.ToUpper, TotalPercepciones, TotalDeducciones)
                Resumen.Tables.Add(Deposito)
                Resumen.Tables.Add(Efectivo)

                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("NOM_RES_NOM")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()

                reporte("Elaboro") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal
                If cmbNave.SelectedValue = 43 Then
                    reporte("Reviso") = "ALMA VILLAGRANA"
                ElseIf cmbNave.SelectedValue = 3 Then
                    reporte("Reviso") = "RAFAEL ORTIZ LOPEZ"
                ElseIf cmbNave.SelectedValue = 1 Then
                    reporte("Reviso") = "JOSÉ LUIS ROJO CRUCES"
                End If

                reporte("ChequeFiscal") = totalNominaFiscal

                reporte.RegData(Resumen)
                reporte.Show()

                Dim ObjB As New Nomina.Negocios.CalcularNominaRealBU
                Dim listaNominaReal As List(Of Entidades.CalcularNominaReal)

                Dim idNave As Integer = CInt(cmbNave.SelectedValue)
                grdDeducciones.Rows.Clear()
                listaNominaReal = ObjB.ListaNominaReal(idNave, 0, 0, txtColaborador.Text, "")
                AgregarFilaColaboradoresNominaReal(listaNominaReal, False)
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImprimirReporteGeneralAgrupadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirReporteGeneralAgrupadoToolStripMenuItem.Click
        Try

            If grdDeducciones.Rows.Count > 0 Then

                Dim Resumen = New DataSet("Colaboradores")
                Dim Colaborador = New DataTable("Colaborador")
                Dim Celulas = New DataTable("Celulas")
                'Dim Efectivo = New DataTable("Efectivo")
                Dim PagoBruto As Double = 0
                Dim Extras As Double = 0
                Dim Otros As Double = 0
                Dim Ausentismos As Double = 0
                Dim Seguro As Double = 0
                Dim Prestamos As Double = 0
                Dim CajaAhorro As Double = 0
                Dim PagoNeto As Double = 0
                Dim TotalDeducciones As Double = 0
                Dim TotalPercepciones As Double = 0

                With Colaborador
                    .Columns.Add("contador")
                    .Columns.Add("Colaborador")
                    .Columns.Add("Puesto")
                    .Columns.Add("Faltas")
                    .Columns.Add("Pagobruto")
                    .Columns.Add("Extras")
                    .Columns.Add("Gratificaciones")
                    .Columns.Add("Ausentismos")
                    .Columns.Add("IMSS")
                    .Columns.Add("Infonavit")
                    .Columns.Add("Prestamos")
                    .Columns.Add("Cajadeahorro")
                    .Columns.Add("Otrasdeducciones")
                    .Columns.Add("Pagoneto")
                    .Columns.Add("CelulaID")
                    .Columns.Add("DepartamentoID")
                    .Columns.Add("Sexo")
                    .Columns.Add("OrdenPuesto")
                    .Columns.Add("finiquitoid")
                End With

                With Celulas
                    .Columns.Add("CelulasID")
                    .Columns.Add("CelulasNombre")
                End With
                Dim isrIMSS As Double = 0
                '' se cambio isrIMSS.ToString.Replace(",", ""), _  por  fila.Cells("clmIMMS").Value.ToString.Replace(",", ""), _ 15/05/2015
                For Each fila As DataGridViewRow In grdDeducciones.Rows
                    isrIMSS = 0
                    If fila.Cells("clmColaborador").Value <> "" Then
                        isrIMSS = fila.Cells("clmInfonavit").Value + fila.Cells("clmISR").Value
                        Colaborador.Rows.Add(
                            fila.Cells("clmContador").Value,
                            fila.Cells("clmColaborador").Value,
                            fila.Cells("clmPuesto").Value,
                            fila.Cells("clmDiasTrabajados").Value,
                            fila.Cells("clmSalarioRegistrado").Value.ToString.Replace(",", ""),
                            fila.Cells("clmPuntualidadAsistencia").Value.ToString.Replace(",", ""),
                            fila.Cells("clmGratificaciones").Value.ToString.Replace(",", ""),
                            fila.Cells("clmAusentismos").Value.ToString.Replace(",", ""),
                            fila.Cells("clmIMMS").Value.ToString.Replace(",", ""),
                            fila.Cells("clmInfonavit").Value.ToString.Replace(",", ""),
                            fila.Cells("clmPrestamos").Value.ToString.Replace(",", ""),
                            fila.Cells("clmCajaDeAhorro").Value.ToString.Replace(",", ""),
                            fila.Cells("clmOtrasDeducciones").Value.ToString.Replace(",", ""),
                            fila.Cells("clmTotalEntregar").Value.ToString.Replace(",", ""),
                            fila.Cells("clmCelulaID").Value.ToString.Replace(",", ""),
                            fila.Cells("clmdepartamentoID").Value.ToString.Replace(",", ""),
                            fila.Cells("clmSexo").Value.ToString.Replace(",", ""),
                            CInt(fila.Cells("clmOrdenPuesto").Value.ToString.Replace(",", "")),
                            CInt(fila.Cells("fini_finiquitoid").Value.ToString)
                            )
                    End If
                Next

                Dim objCelulas As New Negocios.CelulasBU
                Dim celulasTBL As New DataTable
                celulasTBL = objCelulas.listaCelulasActivas()
                For Each row As DataRow In celulasTBL.Rows
                    Celulas.Rows.Add(row.Item("celu_celulaid"), row.Item("celu_nombre"))
                Next


                Resumen.Tables.Add(Colaborador)
                Resumen.Tables.Add(Celulas)

                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("NOM_RG_AGRUP")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport

                reporte.Load(archivo)
                reporte.Compile()
                reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
                reporte("PeriodoNomina") = lblPeriodoNomina.Text
                reporte("semana") = "Semana " + semanaPeriodo.ToString
                reporte.RegData(Resumen)
                reporte.Show()
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception

        End Try
    End Sub


    Public Function GenerarSolicitudNomina() As Boolean
        Dim pagoBruto As Double = 0
        Dim extras As Double = 0
        Dim otros As Double = 0
        Dim ausentismos As Double = 0
        Dim IMSS As Double = 0
        Dim seguro As Double = 0
        Dim prestamos As Double = 0
        Dim cajaAhorro As Double = 0
        Dim TotalPercepciones As Double = 0
        Dim TotalDeducciones As Double = 0
        Dim PagoNeto As Double = 0
        Dim segur As Double = 0

        'variables efectivo
        Dim pagoBrutoE As Double = 0
        Dim extrasE As Double = 0
        Dim otrosE As Double = 0
        Dim ausentismosE As Double = 0
        Dim IMSSE As Double = 0
        Dim seguroE As Double = 0
        Dim prestamosE As Double = 0
        Dim cajaAhorroE As Double = 0
        Dim TotalPercepcionesE As Double = 0
        Dim TotalDeduccionesE As Double = 0
        Dim PagoNetoE As Double = 0

        'variable que obtiene el monto de nómina fiscal 
        Dim totalNominaFiscal As Double = 0


        Dim banderaG As Boolean = False
        Dim formSolicitudF As New SolicitudFinanzasNomina
        Dim nave As New Entidades.Naves

        For Each fila As DataGridViewRow In grdDeducciones.Rows
            If fila.Cells("clmTipoSueldo").Value = "DEPOSITO" Then
                pagoBruto += fila.Cells("clmSalarioRegistrado").Value
                extras += fila.Cells("clmPuntualidadAsistencia").Value
                otros += fila.Cells("clmGratificaciones").Value
                ausentismos += fila.Cells("clmAusentismos").Value

                IMSS = 0
                If fila.Cells("clmIMMS").Value = 0 Then
                    IMSS = fila.Cells("clmIMMS").Value
                Else
                    IMSS = fila.Cells("clmRespaldoIMSSMonto").Value
                End If

                segur += CDbl(fila.Cells("clmIMMS").Value) + CDbl(fila.Cells("clmInfonavit").Value)
                prestamos += CDbl(fila.Cells("clmPrestamos").Value) + CDbl(fila.Cells("clmOtrasDeducciones").Value)
                cajaAhorro += fila.Cells("clmCajaDeAhorro").Value

            ElseIf fila.Cells("clmTipoSueldo").Value = "EFECTIVO" Then
                pagoBrutoE += fila.Cells("clmSalarioRegistrado").Value
                extrasE += fila.Cells("clmPuntualidadAsistencia").Value
                otrosE += fila.Cells("clmGratificaciones").Value
                ausentismosE += fila.Cells("clmAusentismos").Value

                IMSSE = 0
                If fila.Cells("clmIMMS").Value = 0 Then
                    IMSSE = fila.Cells("clmIMMS").Value
                Else
                    IMSSE = fila.Cells("clmRespaldoIMSSMonto").Value
                End If


                'seguroE += CDbl(IMSSE) + CDbl(fila.Cells("clmInfonavit").Value) + CDbl(fila.Cells("clmISR").Value)
                seguroE += CDbl(fila.Cells("clmIMMS").Value) + CDbl(fila.Cells("clmInfonavit").Value)
                prestamosE += CDbl(fila.Cells("clmPrestamos").Value) + CDbl(fila.Cells("clmOtrasDeducciones").Value)
                cajaAhorroE += fila.Cells("clmCajaDeAhorro").Value

            End If
        Next

        TotalPercepciones = pagoBruto + extras + otros - ausentismos - segur
        TotalDeducciones = prestamos + cajaAhorro
        PagoNeto = TotalPercepciones - TotalDeducciones

        TotalPercepcionesE = pagoBrutoE + extrasE + otrosE - ausentismosE - seguroE
        TotalDeduccionesE = prestamosE + cajaAhorroE
        PagoNetoE = TotalPercepcionesE - TotalDeduccionesE
        ''replicar lo mismo para efectivo

        ''obtener caja asignada a usuario
        Dim dtCajas As New DataTable
        Dim objCajas As New Negocios.CajasBU
        dtCajas = objCajas.listaCajas(CInt(cmbNave.SelectedValue))
        Dim semanaNomina As String = ""
        semanaNomina = lblPeriodoNomina.Text

        'Se obtiene el total de nómina fiscal 
        Dim nomina As New Nomina.Negocios.CalcularNominaRealBU
        totalNominaFiscal = nomina.ConsultaTotalNominaFiscal(CInt(lblIdSemanaNomina.Text))

        With formSolicitudF
            formSolicitudF.idNave = (Int(cmbNave.SelectedValue))
            nave = cmbNave.SelectedItem
            formSolicitudF.nave = nave.PNombre
            formSolicitudF.totDeducciones = TotalDeducciones + TotalDeduccionesE
            formSolicitudF.totNominaEfectivo = PagoNetoE
            formSolicitudF.totNominaDeposito = PagoNeto
            formSolicitudF.idSemanaN = CInt(lblIdSemanaNomina.Text)
            formSolicitudF.semanaNomina = semanaNomina
            formSolicitudF.totalNominaFiscal = totalNominaFiscal
            'formSolicitudF.FechaInicio = FechaInicio
            'formSolicitudF.fechaFinal = fechaFinal
            If dtCajas.Rows.Count > 0 Then
                formSolicitudF.idCaja = CInt(dtCajas.Rows(0).Item("Id_Caja").ToString)
                formSolicitudF.caja = dtCajas.Rows(0).Item("Nombre").ToString
            Else
                formSolicitudF.idCaja = 0
            End If

            formSolicitudF.ShowDialog()
            banderaG = formSolicitudF.banderaGuardar

        End With
        Dim bandera As Boolean = False
        If banderaG = True Then
            bandera = True
        Else
            bandera = False
        End If
        Return bandera
    End Function

    Public Function verificaReinicioAcumuladoTipoPago() As Boolean
        Dim resultado As Boolean = False
        Try
            ''verifica inicio de mes para reiniciar los acumulados
            Dim objBU As New Negocios.CalcularNominaRealBU
            If objBU.validaInicioMes(CInt(lblIdSemanaNomina.Text)) And cambioTipoPago = False Then
                Dim reiniciado As String = String.Empty
                reiniciado = objBU.reiniciaAcumuladoColaborador(cmbNave.SelectedValue)
                If reiniciado = "EXITO" Then
                    resultado = True
                End If
            Else
                resultado = True
            End If
        Catch ex As Exception

        End Try

        Return resultado
    End Function

    Public Function sumaAcumuladoMensualColaborador(ByVal colaboradorId As Integer, ByVal monto As Double) As Boolean
        Dim resultado As Boolean = False
        ''Suma el monto de la nómina actual al acumulado mensual
        Try
            Dim objBU As New Negocios.CalcularNominaRealBU
            Dim reiniciado As String = String.Empty
            reiniciado = objBU.sumaAcumuladoMensualColaborador(colaboradorId, monto)
            If reiniciado = "EXITO" Then
                resultado = True
            End If



        Catch ex As Exception

        End Try
        Return resultado
    End Function


    Private Sub EnviarCorreoCambioDeNave(Nave As Entidades.Naves)
        Dim ObjCorteBU As New Nomina.Negocios.CorteNominaRealBU
        Dim dtCorreos As DataTable
        Dim dtCorreosColaboradores As DataTable
        Dim Remitente As String
        Dim Destinatarios As String
        Dim NaveDestinoID As Integer
        Dim NaveDestino As String
        Dim CadenaCorreo As String
        Dim correo As New Tools.Correo
        Dim asuntoCorreo As String
        Dim FechaCorte As String

        Try
            Dim accion As Integer = 1
            dtCorreos = ObjCorteBU.ObtenerDatosCorreos(Nave, 1) 'OBTIENE LAS NAVES Y CORREOS DE LOS DESTINATARIOS

            If dtCorreos.Rows.Count > 0 Then

                Remitente = dtCorreos.Rows(0).Item("Remitente")

                For Each row As DataRow In dtCorreos.Rows
                    Destinatarios = row.Item("Destinos").ToString
                    NaveDestinoID = CInt(row.Item("naveDestinoID"))
                    NaveDestino = row.Item("naveDestino")
                    FechaCorte = row.Item("Fecha")

                    dtCorreosColaboradores = ObjCorteBU.ObtenerDatosCorreos(Nave, 2, NaveDestinoID) 'OBTIENE LOS COLABORADORES

                    If dtCorreosColaboradores.Rows.Count > 0 Then

                        CadenaCorreo = GenerarCadenaCorreo(Nave.PNombre, NaveDestino, dtCorreosColaboradores, FechaCorte)
                        asuntoCorreo = "Movimiento de ALTA por Cambio de Nave"
                        correo.EnviarCorreoHtml(Destinatarios, Remitente, asuntoCorreo, CadenaCorreo)

                    End If

                Next


            End If


        Catch ex As Exception
            Dim msg_Error As New Tools.ErroresForm
            msg_Error.mensaje = ex.Message
            msg_Error.ShowDialog()
        End Try

    End Sub

    Private Function GenerarCadenaCorreo(NaveOrigen As String, NaveDestino As String, ListaColaboradores As DataTable, FechaCorte As String) As String

        Dim CadenaCorreo As String
        Dim CadenaColaboradores As String = ""
        Dim CadenaDiseño As String

        For Each row As DataRow In ListaColaboradores.Rows
            CadenaColaboradores = CadenaColaboradores + " <tr><td class='centro'> " + row.Item("rfc") + " </td> "
            CadenaColaboradores = CadenaColaboradores + " <td> " + row.Item("Colaborador") + " </td></tr> "
        Next

        CadenaDiseño = <CadenaDiseño>                   
                            body {}

                                    .encabezado {
                                      display: flex;
                                      justify-content: center;
                                      align-items: center;
                                      background: #536EBE;
                                      color: white;
                                      text-align: center;
                                    }

                                    h2 {
                                      font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
                                      font-weight: 200;
                                      line-height: 1.0;
                                      font-size: 1.5rem;
                                    }

                                    .cuerpo {
                                      margin-top: 25px;
                                      margin-left: 25px;
                                      margin-right: 250px;
                                      font-family: arial, sans-serif;
                                      color: black;
                                    }

                                    .cuerpo-tabla {
                                      display: flex;
                                      justify-content: center;
                                      align-items: center;
                                      margin: 20px;
                                    }

                                    table {
                                      /*margin: 0 auto;*/
                                      margin-top: 10px;
                                      border-collapse: collapse;
                                      width: 75%;
                                    }        

                                    table th{
                                      border-bottom: 2px solid #212529;
                                    }

                                    th {
                                      text-align: center;
                                    }                                   

                                    .centro {
                                      text-align: center;
                                    }

                                    .cuerpo-pie {
                                      display: flex;
                                      justify-content: center;
                                      align-items: center;
                                      margin-top: 25px;
                                      font-family: arial, sans-serif;
                                      background: #CDCDCD;
                                      color: black;
                                    }

                                    .cuerpo-pie label {
                                      margin-left: 25px;
                                      margin-bottom: 25px;
                                    }

                       </CadenaDiseño>.Value
        CadenaCorreo = " <html> " +
                            " <head> " +
                               " <meta charset ='utf-8'/> " +
                               " <style type='text/css'>" + CadenaDiseño + "</style> " +
                            " </head> " +
                            " <body> " +
                                " <div Class='encabezado'> " +
                                        " <h2> NOTIFICACIÓN PARA CAMBIO DE NAVE </h2> " +
                                " </div> " +
                                " <div Class='cuerpo'> " +
                                    " <div> " +
                                        " <Label> Se ha realizado el cambio desde " +
                                            " <b>" + NaveOrigen + "</b> a nave <b>" + NaveDestino + "</b> de los siguientes colaboradores: " +
                                        " </label> " +
                                    " </div> " +
                                    " <div Class='cuerpo-tabla'> " +
                                        " <table> " +
                                            " <thead> " +
                                                " <tr Class='encabezado-tabla'>" +
                                                   " <th> RFC </th>" +
                                                   " <th> NOMBRE </th> " +
                                                " </tr> " +
                                            " </thead> " +
                                            " <tbody> " +
                                                   CadenaColaboradores +
                                            " </tbody> " +
                                        " </table> " +
                                    " </div> " +
                                " </div> " +
                                " <div Class='cuerpo-pie'> " +
                                            " <Label> Favor de ingresar al sistemas SAY para registrar las solicitudes de altas al IMSS, reimprimir las credenciales y verificar los datos del colaborador. </label> " +
                                            " <Label> " +
                                                "<br><br><b> Nota : </b> A partir del día " + FechaCorte + " debe registrar su asistencia en dicha nave</label> " +
                                " </div> " +
                            " </body> " +
                        " </html> "

        Return CadenaCorreo
    End Function

End Class