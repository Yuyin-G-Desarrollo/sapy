Public Class CalculoNominaDestajosForm
    Dim FinSemanaNomina As DateTime
    Dim IMSSLimite(,) As Double
    Dim RangoAsistenciaCheck(,) As Double
    Dim limiteMatriz As Integer
    Dim LimiteAsistencia As Integer
    Dim iterador As Integer = 0
    Dim estaMal As Integer = 0
    Dim iteradorAsis As Integer = 0

    Private Sub CalculoNominaDestajos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Tools.FormatoCtrls.formato(Me)
        Try
            Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            cmbDepartamento.Visible = False
            cmbArea.Visible = False
            txtColaborador.Visible = False
            lblcolaborador.Visible = False
            lblarea.Visible = False
            lblDepartamento.Visible = False
            IMSSLimitesSI()
            btnGuardar.Enabled = False
            ''Labels
            lblIdSemanaNomina.Visible = False
            lblPeriodoAsistencia.Visible = False
            lblPeriodoPrestamos.Visible = False
            lblPeriodoCajaAhorro.Visible = False
            lblSemanaNominaFIN.Visible = False
            lblSemanaDestajos.Visible = False
            lblSemanaSimanaFiscal.Visible = False
        Catch ex As Exception
        End Try
    End Sub


    Private Sub cmbNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNave.DropDownClosed
        Try
            grdDeducciones.Rows.Clear()

            Tools.Controles.ComboAreaSegunNave(cmbArea, cmbNave.SelectedValue)
            SemanaNomina()

            If lblSemanaDestajos.Text = "C" Then
                Dim mensajeExito As New AvisoForm
                mensajeExito.MdiParent = Me.MdiParent
                mensajeExito.mensaje = "Esta semana de Destajos ya fue cerrada"
                btnBuscar.Enabled = False
                btnGuardar.Enabled = False
                mensajeExito.Show()

            ElseIf lblSemanaDestajos.Text = "A" Then
                btnBuscar.Enabled = True

            End If

        Catch ex As Exception
        End Try
    End Sub


    Private Sub cmbArea_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.DropDownClosed
        Try
            Tools.Controles.ComboDepartamentosSegunArea(cmbDepartamento, cmbArea.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub AgregarFilaColaboradoresNominaReal(ByVal Nomina As List(Of Entidades.CalcularNominaReal))

        Try
            Dim numerodeDatos As List(Of Integer) = Nomina.Select(Function(c) c.PColaborador.PColaboradorid).Distinct.ToList


            ''''
            For Each numerodeColaboradores As Integer In numerodeDatos

                ''    Dim MontoHorasExtras As Double = 0
                Dim SalarioRegistrado As Double = 0
                Dim montoIMSS As Double = 0
                Dim iteradorLimite As Integer = 0
                Dim iteradorLimite2 As Integer = 0
                Dim cajaAhorro As Double = 0
                Dim prestamoMonto As Double = 0
                Dim GratificacionesMonto As Double = 0

                Dim DiasTrabajados As Integer = 7
                Dim asistencia As Boolean = False
                Dim MontoAsistencia As Double = 0

                ''infonavit
                Dim porcentajeRetencion As Double = 0
                Dim ImporteBimestral As Double = 0
                Dim ImporteBimestralRetener As Double = 0
                Dim RetencionAnual As Double = 0
                Dim RetencionDiaria As Double = 0
                Dim RetencionSemanal As Double = 0
                Dim RetencionMensual As Double = 0

                ''Totales
                Dim Totalpercepciones As Double = 0
                Dim TotalDeducciones As Double = 0
                Dim OtrasDeducciones As Double = 0
                Dim TotalEntregar As Double = 0
                Dim TotalSueldoSemanal As Double = 0
                Dim TotalDestajos As Double = 0

                Dim colaboradorID As Integer = numerodeColaboradores

                Dim listaCajaAhorro As List(Of Entidades.CalcularNominaReal)
                Dim listaprestamos As List(Of Entidades.CalcularNominaReal)
                Dim listaIncentivos As List(Of Entidades.CalcularNominaReal)
                Dim listaDeducciones As List(Of Entidades.CalcularNominaReal)
                Dim listaAsistencia As List(Of Entidades.CalcularNominaReal)
                Dim listaPorcentajeAsistencia As List(Of Entidades.CalcularNominaReal)
                ''  Dim listaHorasExtra As List(Of Entidades.CalcularNominaReal)
                Dim listaConfiguracionNominaFiscal As List(Of Entidades.CalculoNominaFiscal)
                Dim listaColaboradorLaboral As List(Of Entidades.CalcularNominaReal)
                Dim listaDestajos As List(Of Entidades.CalcularNominaReal)

                Dim objNominaBU As New Negocios.CalcularNominaRealBU

                Dim objE As Entidades.CalcularNominaReal = Nomina.Find(Function(c) c.PColaborador.PColaboradorid = colaboradorID)
                Dim colaboradorNom As String = objE.PColaborador.PNombre + " " + objE.PColaborador.PApaterno + " " + objE.PColaborador.PAmaterno

                '' obtener destajos inicia
                listaDestajos = objNominaBU.ListaDestajos(colaboradorID, lblIdSemanaNomina.Text)
                For Each Dato As Entidades.CalcularNominaReal In listaDestajos
                    TotalDestajos += Dato.PTotalDestajos
                Next

                If TotalDeducciones = 0 Then

                Else


                    ''obrtener destajos termina

                    Dim salarioDiario As Double = objE.PSalarioDiario

                    ''while para saber la cuota de imss que se le descontara inicia
                    If objE.PNumeroSS.Length <= 5 Then
                    Else

                        While iteradorLimite <= iterador

                            If salarioDiario >= IMSSLimite(iteradorLimite, 1) And salarioDiario <= IMSSLimite(iteradorLimite, 2) Then
                                montoIMSS = IMSSLimite(iteradorLimite, 3)
                                Exit While
                            Else
                                If salarioDiario > IMSSLimite(iteradorLimite, 1) And IMSSLimite(iteradorLimite, 2) = 0 Then

                                    montoIMSS = IMSSLimite(iteradorLimite, 3)
                                    Exit While

                                End If

                            End If
                            iteradorLimite += 1
                        End While
                    End If
                    ''while para saber la cuota de imss que se le descontara termina

                    ''OBTENER LA CAJA DE AHORRO INICIA
                    listaCajaAhorro = objNominaBU.CajaDeAhorro(colaboradorID, lblIdSemanaNomina.Text)
                    Dim ObjCaja As List(Of Double) = listaCajaAhorro.Select(Function(c) c.PCajaAhorro.pMontoAhorro).Distinct.ToList
                    For Each monto As Double In ObjCaja
                        cajaAhorro = monto
                    Next
                    ''OBTENER LA CAJA DE AHORRO TERMINA

                    ''obtener prestamos inicia
                    listaprestamos = objNominaBU.prestamos(colaboradorID, lblIdSemanaNomina.Text)
                    Dim objPres As List(Of Double) = listaprestamos.Select(Function(c) c.PPrestamos.Pmontoprestamo).Distinct.ToList
                    For Each prestamo As Double In objPres
                        prestamoMonto = prestamo
                    Next
                    ''obtener prestamos termina

                    ''obtener HorasExtra inicia
                    'listaHorasExtra = objNominaBU.HorasExtras(colaboradorID, lblIdSemanaNomina.Text)
                    'Dim objHoras As List(Of Double) = listaHorasExtra.Select(Function(c) c.PHorasExtras.PMonto).Distinct.ToList
                    'For Each horas As Double In objHoras
                    '    MontoHorasExtras = horas
                    'Next
                    ''obtener HorasExtra termina

                    'obtener incentivo inicia
                    listaIncentivos = objNominaBU.gratificaciones(colaboradorID)
                    Dim objgratificaciones As List(Of Double) = listaIncentivos.Select(Function(c) c.PIncentivoPuntualidad).Distinct.ToList
                    For Each gratificaciones As Double In objgratificaciones
                        GratificacionesMonto = gratificaciones
                    Next
                    'obtener incentivo termina

                    ''Obtener faltas inicia
                    listaAsistencia = objNominaBU.checador(colaboradorID, lblIdSemanaNomina.Text)

                    ''obtener faltar termina

                    ''FOR pasa saber el incentivo de puntualidad que se le dara INICIA

                    For Each Puntualidad As Entidades.CalcularNominaReal In listaAsistencia
                        asistencia = Puntualidad.Pchecador.PPpuntualidad_asistencia
                        SalarioRegistrado = TotalDestajos

                        Dim checkAsistencia As Boolean = Puntualidad.Pchecador.PPpuntualidad_asistencia
                        Dim inasis As Integer = Puntualidad.Pchecador.PInasistencia
                        Dim retardoMenor As Integer = Puntualidad.Pchecador.PRetardo_menor
                        Dim retardoMayor As Integer = Puntualidad.Pchecador.PRetardo_mayor
                        DiasTrabajados -= inasis

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

                    ''FOR pasa saber el incentivo de puntualidad que se le dara TERMINA

                    '' obtener deducciones inicia
                    listaDeducciones = objNominaBU.deduccionesExtraordinaria(colaboradorID, lblIdSemanaNomina.Text)
                    Dim objDeduccionesConcepto As List(Of String) = listaDeducciones.Select(Function(c) c.PDeduccionExtraordinaria.PConceptoDeduccion).Distinct.ToList
                    Dim numeroDeducciones As Integer = objDeduccionesConcepto.Count


                    ''obrtener deducciones termina

                    '''''''''''''''OBTENER EL MONTO DE INFORNAVIT A RETENER'''''''''''''''
                    ''Configuracion de la nomina FISCAL
                    Dim nominaFiscalBU As New Nomina.Negocios.CalculoNominaFiscalBU
                    Dim SalarioMinimo As Double = 0
                    Dim SalarioBimestral As Double = 0

                    Dim seguroVivienda As Double = 0
                    Dim diasAnio As Integer = 0

                    Dim infonavit As Boolean = False
                    Dim infonavitTipo As Integer = 0
                    Dim infonavitMonto As Double = 0

                    listaConfiguracionNominaFiscal = nominaFiscalBU.consulta_configuracionNominaFiscal()
                    For Each SalarioMin As Entidades.CalculoNominaFiscal In listaConfiguracionNominaFiscal
                        SalarioMinimo = SalarioMin.PSalarioMinimo
                        seguroVivienda = SalarioMin.PSeguroVivienda
                        diasAnio = SalarioMin.PDiasAnio

                    Next

                    ''CALCULA DIAS BIMESTRE
                    Dim anio_actual As Integer = Now.Year
                    Dim fecha_inicio_bimestre, fecha_termino_bimestre As Date
                    Dim mes As Integer = Now.Month
                    Dim diasBimenstre As Integer = 0
                    If mes = 1 Or mes = 2 Then
                        fecha_inicio_bimestre = anio_actual.ToString + "-01-01"
                        fecha_termino_bimestre = anio_actual.ToString + "-03-01"
                        fecha_termino_bimestre = DateAdd(DateInterval.Day, -1, fecha_termino_bimestre)
                        diasBimenstre = DateDiff(DateInterval.Day, fecha_inicio_bimestre, fecha_termino_bimestre) + 1
                    End If
                    If mes = 3 Or mes = 4 Then
                        fecha_inicio_bimestre = anio_actual.ToString + "-03-01"
                        fecha_termino_bimestre = anio_actual.ToString + "-05-01"
                        fecha_termino_bimestre = DateAdd(DateInterval.Day, -1, fecha_termino_bimestre)
                        diasBimenstre = DateDiff(DateInterval.Day, fecha_inicio_bimestre, fecha_termino_bimestre) + 1
                    End If
                    If mes = 5 Or mes = 6 Then
                        fecha_inicio_bimestre = anio_actual.ToString + "-05-01"
                        fecha_termino_bimestre = anio_actual.ToString + "-07-01"
                        fecha_termino_bimestre = DateAdd(DateInterval.Day, -1, fecha_termino_bimestre)
                        diasBimenstre = DateDiff(DateInterval.Day, fecha_inicio_bimestre, fecha_termino_bimestre) + 1
                    End If
                    If mes = 7 Or mes = 8 Then
                        fecha_inicio_bimestre = anio_actual.ToString + "-07-01"
                        fecha_termino_bimestre = anio_actual.ToString + "-09-01"
                        fecha_termino_bimestre = DateAdd(DateInterval.Day, -1, fecha_termino_bimestre)
                        diasBimenstre = DateDiff(DateInterval.Day, fecha_inicio_bimestre, fecha_termino_bimestre) + 1
                    End If
                    If mes = 9 Or mes = 10 Then
                        fecha_inicio_bimestre = anio_actual.ToString + "-09-01"
                        fecha_termino_bimestre = anio_actual.ToString + "-11-01"
                        fecha_termino_bimestre = DateAdd(DateInterval.Day, -1, fecha_termino_bimestre)
                        diasBimenstre = DateDiff(DateInterval.Day, fecha_inicio_bimestre, fecha_termino_bimestre) + 1
                    End If
                    If mes = 11 Or mes = 12 Then
                        fecha_inicio_bimestre = anio_actual.ToString + "-11-01"
                        fecha_termino_bimestre = anio_actual.ToString + "-12-31"
                        '' fecha_termino_bimestre = DateAdd(DateInterval.Day, -1, fecha_termino_bimestre)
                        diasBimenstre = DateDiff(DateInterval.Day, fecha_inicio_bimestre, fecha_termino_bimestre) + 1
                    End If

                    SalarioBimestral = diasBimenstre * SalarioMinimo

                    listaColaboradorLaboral = objNominaBU.PorcentajeRetencion(colaboradorID)

                    For Each dato As Entidades.CalcularNominaReal In listaColaboradorLaboral
                        infonavit = dato.Pinfornavit
                        infonavitTipo = dato.Pinfonavit_tipo
                        infonavitMonto = dato.Pinfonavit_monto
                    Next

                    If infonavit = True Then

                        If infonavitTipo = 1 Then

                            porcentajeRetencion = infonavitMonto / 100

                            ImporteBimestral = SalarioBimestral * porcentajeRetencion
                            ImporteBimestralRetener = ImporteBimestral + seguroVivienda

                            RetencionAnual = ImporteBimestralRetener * 6
                            RetencionDiaria = RetencionAnual / diasAnio
                            RetencionSemanal = RetencionDiaria * 7

                        End If

                        If infonavitTipo = 2 Then

                            RetencionMensual = SalarioMinimo * infonavitMonto
                            ImporteBimestral = RetencionMensual * 2
                            ImporteBimestralRetener = ImporteBimestral + seguroVivienda

                            RetencionAnual = ImporteBimestralRetener * 6
                            RetencionDiaria = RetencionAnual / diasAnio
                            RetencionSemanal = RetencionDiaria * 7

                        End If

                        If infonavitTipo = 3 Then
                            ImporteBimestral = infonavitMonto * 2
                            ImporteBimestralRetener = ImporteBimestral + seguroVivienda
                            RetencionAnual = ImporteBimestral * 6
                            RetencionDiaria = RetencionAnual / diasAnio
                            RetencionSemanal = RetencionDiaria * 7

                        End If
                    Else

                    End If

                    ''''''''''''''OBTENER EL MONTO DE INFORNAVIT A RETENER'''''''''''''''
                    ''Totales

                    TotalDeducciones = cajaAhorro + prestamoMonto + montoIMSS + RetencionSemanal
                    Totalpercepciones = GratificacionesMonto + MontoAsistencia
                    '+ MontoHorasExtras
                    TotalSueldoSemanal = TotalDestajos
                    TotalEntregar = TotalSueldoSemanal - TotalDeducciones + Totalpercepciones
                    ''Totales
                    Dim salarioDiarioReal As Double = TotalDestajos / 7

                    grdDeducciones.Rows.Add(colaboradorID, colaboradorNom, "DESTAJO", salarioDiarioReal.ToString("c"), DiasTrabajados, TotalSueldoSemanal.ToString("c"), "Incentivo puntualidad", MontoAsistencia, "Caja de ahorro", cajaAhorro, "")
                    grdDeducciones.Rows.Add(colaboradorID, colaboradorNom, "DESTAJO", salarioDiarioReal.ToString("c"), DiasTrabajados, TotalSueldoSemanal.ToString("c"), "Gratificaciones", GratificacionesMonto, "Prestamo", prestamoMonto, "")
                    grdDeducciones.Rows.Add(colaboradorID, colaboradorNom, "DESTAJO", salarioDiarioReal.ToString("c"), DiasTrabajados, TotalSueldoSemanal.ToString("c"), "", "", "IMSS", montoIMSS, "")
                    grdDeducciones.Rows.Add(colaboradorID, colaboradorNom, "DESTAJO", salarioDiarioReal.ToString("c"), DiasTrabajados, TotalSueldoSemanal.ToString("c"), "", "", "Retencion infonavit", RetencionSemanal, "")

                    If numeroDeducciones = 0 Then

                        grdDeducciones.Rows.Add(colaboradorID, colaboradorNom, "DESTAJO", salarioDiarioReal.ToString("c"), DiasTrabajados, TotalSueldoSemanal.ToString("c"), "Otras", 0, "Otras", 0, "")
                        grdDeducciones.Rows.Add(colaboradorID, colaboradorNom, "DESTAJO", salarioDiarioReal.ToString("c"), DiasTrabajados, TotalSueldoSemanal.ToString("c"), "Total", Totalpercepciones, "Total", TotalDeducciones, TotalEntregar.ToString("c"))


                        If lblSemanaDestajos.Text = "A" Then
                            btnGuardar.Enabled = True
                        Else
                            btnGuardar.Enabled = False
                        End If


                    Else

                        For Each dedu As Entidades.CalcularNominaReal In listaDeducciones
                            Dim concepto As String = dedu.PDeduccionExtraordinaria.PConceptoDeduccion
                            Dim monto As Double = dedu.PDeduccionExtraordinaria.PMontoDeduccion
                            grdDeducciones.Rows.Add(colaboradorID, colaboradorNom, TotalDestajos.ToString("c"), salarioDiarioReal.ToString("c"), DiasTrabajados, TotalSueldoSemanal.ToString("c"), "", "", concepto, monto, "")
                            OtrasDeducciones += monto

                        Next
                        TotalDeducciones += OtrasDeducciones
                        TotalEntregar -= OtrasDeducciones
                        grdDeducciones.Rows.Add(colaboradorID, colaboradorNom, TotalDestajos.ToString("c"), salarioDiarioReal.ToString("c"), DiasTrabajados, TotalSueldoSemanal.ToString("c"), "Total", Totalpercepciones.ToString("c"), "Total", TotalDeducciones.ToString("c"), TotalEntregar.ToString("c"))

                    End If


                End If

            Next

            For Each row As DataGridViewRow In grdDeducciones.Rows
                If row.Cells("clmPercepconesConcepto").Value = "Total" Then
                    row.Cells("clmPercepconesConcepto").Style.BackColor = Color.LightGray
                    row.Cells("clmPercepcionesMonto").Style.BackColor = Color.LightGray
                    row.Cells("clmDeduccionesMonto").Style.BackColor = Color.LightGray
                    row.Cells("clmDeduccionesConcepto").Style.BackColor = Color.LightGray

                    If row.Cells("clmTotalEntregar").Value < 0 Then
                        row.Cells("clmTotalEntregar").Style.BackColor = Color.Salmon
                        estaMal = 1
                    Else
                        row.Cells("clmTotalEntregar").Style.BackColor = Color.LightGreen
                    End If
                End If

            Next

            If estaMal > 0 Then

                btnGuardar.Enabled = False
                Dim mensajeExito As New AvisoForm
                mensajeExito.MdiParent = Me.MdiParent
                mensajeExito.mensaje = "Hay salarios con valores negavios favor de verificarlos"
                mensajeExito.Show()

                estaMal = 0

            Else

                If lblSemanaDestajos.Text = "A" Then
                    btnGuardar.Enabled = True
                Else
                    btnGuardar.Enabled = False
                    estaMal = 0

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    ''LLENAR SEMANA NOMINA ACTIVA
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
        lblIdSemanaNomina.Text = SemanaActiva.PsemanaNominaId
        FinSemanaNomina = SemanaActiva.PfechaFinNomina
        lblSemanaNominaFIN.Text = FinSemanaNomina
        lblPeriodoAsistencia.Text = SemanaActiva.PPeriodoNominaAsistencia
        lblPeriodoCajaAhorro.Text = SemanaActiva.PPeriodoNominaCajaAhorro
        lblPeriodoPrestamos.Text = SemanaActiva.PPeriodoNominaPrestamos
        lblSemanaDestajos.Text = SemanaActiva.PPeriodoNominaDestajos
        lblSemanaSimanaFiscal.Text = SemanaActiva.PPeriodoNominaFiscal
        lblPeriodoNomina.Text = SemanaActiva.PConceptoSemana

        If lblSemanaDestajos.Text = "C" Then

            btnGuardar.Enabled = True

        ElseIf lblSemanaDestajos.Text = "A" Then
            btnGuardar.Enabled = False

        End If

    End Sub
    ''LLENAR SEMANA NOMINA ACTIVA

    Public Sub IMSSLimitesSI()
        Try

            Dim LimitesIMSS As New List(Of Entidades.CalcularNominaReal)
            Dim LimitesBU As New Nomina.Negocios.CalcularNominaRealBU


            LimitesIMSS = LimitesBU.ListaLimites()
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
        grdDeducciones.Rows.Clear()

        Dim idNave As Integer = CInt(cmbNave.SelectedValue)
        Dim idArea As Integer = 0
        Dim idDepartamento As Integer = 0
        Dim ObjBU As New Nomina.Negocios.CalcularNominaRealBU
        Dim listaNominaReal As List(Of Entidades.CalcularNominaReal)

        listaNominaReal = ObjBU.ListaDestajos(idNave, 0, 0, txtColaborador.Text)

        AgregarFilaColaboradoresNominaReal(listaNominaReal)

    End Sub

    Private Sub grdDeducciones_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles grdDeducciones.CellPainting
        'el e.columnindex son las columnas que checara para ver si se pueden combinar las celdas iguales
        ' en este caso checara la 2

        If e.ColumnIndex = 1 Or e.ColumnIndex = 10 And e.RowIndex >= 0 AndAlso e.RowIndex >= 0 Then
            Try


                Using gridBrush As Brush = New SolidBrush(Me.grdDeducciones.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

                    Using gridLinePen As Pen = New Pen(gridBrush)

                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                        If grdDeducciones.Rows(e.RowIndex).Cells("clmIDcolaborador").Value.ToString() = grdDeducciones.Rows(e.RowIndex + 1).Cells("clmIDcolaborador").Value.ToString() Then

                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

                        Else
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)

                        End If



                        If Not e.Value Is Nothing Then

                            If e.RowIndex > 0 AndAlso grdDeducciones.Rows(e.RowIndex).Cells("clmIDcolaborador").Value.ToString() <> grdDeducciones.Rows(e.RowIndex + 1).Cells("clmIDcolaborador").Value.ToString() Then
                                e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
                            Else



                            End If

                        End If

                        e.Handled = True

                    End Using

                End Using
            Catch ex As Exception

            End Try


        End If




        If e.ColumnIndex = 4 Or e.ColumnIndex = 5 And e.RowIndex >= 0 AndAlso e.RowIndex >= 0 Then
            Try


                Using gridBrush As Brush = New SolidBrush(Me.grdDeducciones.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

                    Using gridLinePen As Pen = New Pen(gridBrush)

                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                        If grdDeducciones.Rows(e.RowIndex).Cells("clmIDcolaborador").Value.ToString() = grdDeducciones.Rows(e.RowIndex + 1).Cells("clmIDcolaborador").Value.ToString() Then

                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

                        Else
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)

                        End If



                        If Not e.Value Is Nothing Then

                            If e.RowIndex > 0 AndAlso grdDeducciones.Rows(e.RowIndex).Cells("clmIDcolaborador").Value.ToString() <> grdDeducciones.Rows(e.RowIndex + 1).Cells("clmIDcolaborador").Value.ToString() Then
                                e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
                            Else



                            End If

                        End If

                        e.Handled = True

                    End Using

                End Using
            Catch ex As Exception

            End Try


        End If

        If e.ColumnIndex = 3 And e.RowIndex >= 0 AndAlso e.RowIndex >= 0 Then
            Try

                Using gridBrush As Brush = New SolidBrush(Me.grdDeducciones.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

                    Using gridLinePen As Pen = New Pen(gridBrush)

                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                        If grdDeducciones.Rows(e.RowIndex).Cells("clmIDcolaborador").Value.ToString() = grdDeducciones.Rows(e.RowIndex + 1).Cells("clmIDcolaborador").Value.ToString() Then

                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

                        Else
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)

                        End If



                        If Not e.Value Is Nothing Then

                            If e.RowIndex > 0 AndAlso grdDeducciones.Rows(e.RowIndex).Cells("clmIDcolaborador").Value.ToString() <> grdDeducciones.Rows(e.RowIndex + 1).Cells("clmIDcolaborador").Value.ToString() Then
                                e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
                            Else

                            End If

                        End If

                        e.Handled = True

                    End Using

                End Using
            Catch ex As Exception

            End Try


        End If

        If e.ColumnIndex = 2 And e.RowIndex >= 0 AndAlso e.RowIndex >= 0 Then
            Try


                Using gridBrush As Brush = New SolidBrush(Me.grdDeducciones.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

                    Using gridLinePen As Pen = New Pen(gridBrush)

                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                        If grdDeducciones.Rows(e.RowIndex).Cells("clmIDcolaborador").Value.ToString() = grdDeducciones.Rows(e.RowIndex + 1).Cells("clmIDcolaborador").Value.ToString() Then

                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

                        Else
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)

                        End If



                        If Not e.Value Is Nothing Then

                            If e.RowIndex > 0 AndAlso grdDeducciones.Rows(e.RowIndex).Cells("clmIDcolaborador").Value.ToString() <> grdDeducciones.Rows(e.RowIndex + 1).Cells("clmIDcolaborador").Value.ToString() Then
                                e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
                            Else



                            End If

                        End If

                        e.Handled = True

                    End Using

                End Using
            Catch ex As Exception

            End Try


        End If

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim contadorRegistros As Integer = 0

        For Each row As DataGridViewRow In grdDeducciones.Rows
            contadorRegistros = 1
        Next

        If contadorRegistros = 1 Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = "¿Estas seguro de querer guardar la nómina? " + vbNewLine + "No podrá hacer modificaciones" + vbNewLine + " despues del guardado."

            If mensajeExito.ShowDialog = DialogResult.OK Then
                GuardarDeducciones()

                grdDeducciones.Rows.Clear()
                btnGuardar.Enabled = False
                btnBuscar.Enabled = False
                lblPeriodoNomina.Text = ""
            End If

        End If

    End Sub

    Public Sub GuardarDeducciones()
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

         

                Dim percepcion As New Entidades.Percepciones
                Dim colaborador As New Entidades.Colaborador
                Dim cobranza As New Entidades.CobranzaPrestamos
                Dim prestamos As New Entidades.SolicitudPrestamo
                Dim deducciones As New Entidades.Deducciones
                Dim corteNomina As New Entidades.CorteNominaReal
                Dim nomina As New Entidades.CalcularNominaReal

                colaborador.PColaboradorid = row.Cells("clmIDcolaborador").Value
                cobranza.PfechaFinNomina = FinSemanaNomina
                cobranza.PsemanaNominaId = lblIdSemanaNomina.Text

                deducciones.PColaborador = colaborador
                deducciones.PCobranza = cobranza
                deducciones.PidCreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

                If row.Cells("clmDeduccionesConcepto").Value = "Caja de ahorro" Then
                    cajaDeAhorro = row.Cells("clmDeduccionesMonto").Value

                    'If cajaDeAhorro = 0 Then

                    '    ''NO SE DESCONTARA CAJA DE AHORRO

                    'Else
                    ''GUARDA LA CAJA DE AHORRO
                    deducciones.PConceptoDeduccion = "Caja de ahorro"
                    deducciones.PMontoDeduccion = cajaDeAhorro
                    deducciones.PDeduccionTipo = 1

                    ObjBU.guardarDeducciones(deducciones)

                    'End If

                End If

                If row.Cells("clmDeduccionesConcepto").Value = "Prestamo" Then
                    Prestamo = row.Cells("clmDeduccionesMonto").Value

                    'If Prestamo = 0 Then
                    '    ''NO SE DESCONTARA PRESTAMO
                    'Else
                    ''GUARDA EL PRESTAMO
                    deducciones.PConceptoDeduccion = "Prestamo"
                    deducciones.PMontoDeduccion = Prestamo
                    deducciones.PDeduccionTipo = 2

                    ObjBU.guardarDeducciones(deducciones)
                    'End If

                End If

                If row.Cells("clmDeduccionesConcepto").Value = "IMSS" Then
                    IMSS = row.Cells("clmDeduccionesMonto").Value

                    'If IMSS = 0 Then
                    '    'NO SE DESCONTARA IMSS
                    'Else
                    ''GUARDA EL IMSS

                    deducciones.PConceptoDeduccion = "IMSS"
                    deducciones.PMontoDeduccion = IMSS
                    deducciones.PDeduccionTipo = 3

                    ObjBU.guardarDeducciones(deducciones)

                    'End If

                End If

                If row.Cells("clmDeduccionesConcepto").Value = "Retencion infonavit" Then
                    RetencionInfonavit = row.Cells("clmDeduccionesMonto").Value

                    'If IMSS = 0 Then
                    '    'NO SE DESCONTARA IMSS
                    'Else
                    ''GUARDA EL IMSS

                    deducciones.PConceptoDeduccion = "Retencion infonavit"
                    deducciones.PMontoDeduccion = RetencionInfonavit
                    deducciones.PDeduccionTipo = 4

                    ObjBU.guardarDeducciones(deducciones)

                    'End If

                End If

                ''GUARDA LAS PERCEPCIONES
                ''1. Puntualidad y asistencia,
                ' 2. Gratificaciones, 
                ' 3. Horas extras,
                ' 0. Salario semanal
                colaboradorID = row.Cells("clmIDcolaborador").Value
                colaborador.PColaboradorid = colaboradorID
                cobranza.PfechaFinNomina = lblSemanaNominaFIN.Text
                cobranza.PsemanaNominaId = lblIdSemanaNomina.Text
                prestamos.Pusuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

                percepcion.PColaborador = colaborador
                percepcion.PCobranza = cobranza
                percepcion.PPrestamos = prestamos

                If row.Cells("clmPercepconesConcepto").Value = "Incentivo puntualidad" Then
                    IncentivoPuntualidad = row.Cells("clmPercepcionesMonto").Value
                    'If IncentivoPuntualidad = 0 Then
                    '    ''No Guarda incentivo puntualidad
                    'Else

                    percepcion.PMontoPercepcion = IncentivoPuntualidad
                    percepcion.PPercepcionTipo = 1
                    ObjBUPER.guardarPrenominaPercepciones(percepcion)
                End If

                'End If

                If row.Cells("clmPercepconesConcepto").Value = "Gratificaciones" Then
                    Gratificaciones = row.Cells("clmPercepcionesMonto").Value

                    'If Gratificaciones = 0 Then
                    '    ''No guarda gratificaciones
                    'Else
                    percepcion.PMontoPercepcion = Gratificaciones
                    percepcion.PPercepcionTipo = 2
                    ObjBUPER.guardarPrenominaPercepciones(percepcion)

                End If
                'End If

                'If row.Cells("clmPercepconesConcepto").Value = "Horas extras" Then
                '    horasExtras = row.Cells("clmPercepcionesMonto").Value

                '    'If horasExtras = 0 Then
                '    '    ''No obtuvo horas extras
                '    'Else

                '    percepcion.PMontoPercepcion = horasExtras
                '    percepcion.PPercepcionTipo = 3
                '    ObjBUPER.guardarPrenominaPercepciones(percepcion)
                'End If
                ''End If

                If row.Cells("clmPercepconesConcepto").Value = "Total" Then
                    insertarSalarioSemanal = row.Cells("clmSalarioSemanal").Value

                    'If insertarSalarioSemanal = 0 Then
                    '    ''No tiene salario
                    'Else

                    percepcion.PMontoPercepcion = insertarSalarioSemanal
                    percepcion.PPercepcionTipo = 0
                    ObjBUPER.guardarPrenominaPercepciones(percepcion)
                    'End If

                End If

                ''GUARDA TOTALES PARA EL CORTE DE NOMINA
                ''GUARDA TOTALES PARA EL CORTE DE NOMINA
                ''GUARDA TOTALES PARA EL CORTE DE NOMINA

                If row.Cells("clmPercepconesConcepto").Value = "Total" Then

                    percepcion.PTotalPercepciones = CDbl(row.Cells("clmPercepcionesMonto").Value) + CDbl(row.Cells("clmSalarioSemanal").Value)
                    deducciones.PTotalDeducciones = row.Cells("clmDeduccionesMonto").Value
                    corteNomina.PTotalEntregar = row.Cells("clmTotalEntregar").Value

                    cobranza.PsemanaNominaId = lblIdSemanaNomina.Text

                    colaborador.PColaboradorid = colaboradorID

                    nomina.PSalarioDiario = row.Cells("clmSalarioDiario").Value
                    nomina.PDiasLaborados = row.Cells("clmDiasTrabajados").Value
                    nomina.PSalarioSemanal = row.Cells("clmSalarioSemanal").Value

                    corteNomina.Pcobranza = cobranza
                    corteNomina.Pcolaborador = colaborador
                    corteNomina.PNomina = nomina
                    corteNomina.PPercepciones = percepcion
                    corteNomina.PDeducciones = deducciones

                    ObjCorteBU.GuardarCorteNomina(corteNomina)
                End If

        Next
        Dim objDestajos As New Entidades.CalcularDestajos
        Dim objDestajosBU As New Nomina.Negocios.CalcularDestajosBU
        objDestajos.PIDSemanaNomina = lblIdSemanaNomina.Text

        objDestajosBU.CambiarSemanaDestajos(objDestajos)

        Dim mensajeExito As New ExitoForm
        mensajeExito.MdiParent = Me.MdiParent
        mensajeExito.mensaje = "Se a guardado la nomina correctamente"

        mensajeExito.Show()

    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 128
    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub

    Private Sub lblGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblGuardar.Click

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        grdDeducciones.Rows.Clear()
        cmbNave.SelectedIndex = 0
    End Sub
End Class