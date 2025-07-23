Imports CrystalDecisions.Shared
Imports Stimulsoft.Report

Public Class ListaCorteNominaForm
    Dim pagoSeptimoDia As String = ""
    Dim generarRegistroNoCheca As Boolean

    ''TOTALES
    Dim listaRecibosDiaFestivo As New List(Of Entidades.CalcularNominaReal)
    Dim naveSICYID As String

    Dim ColaboradorID As Integer = 0
    Dim colaboradorNombre As String = ""
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

    Dim fechaInicio As DateTime
    Dim fechaFin As DateTime

    Dim lstColaboradorIdIncapacidades As New List(Of Integer)


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

    Private Sub ListaCorteNominaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Tools.FormatoCtrls.formato(Me)

        WindowState = FormWindowState.Maximized
        grdDeducciones.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDeducciones.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDeducciones.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDeducciones.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDeducciones.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDeducciones.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDeducciones.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDeducciones.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDeducciones.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDeducciones.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDeducciones.Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDeducciones.Columns(12).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDeducciones.Columns(13).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDeducciones.Columns(14).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDeducciones.Columns(15).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter


        'ImprimirReporteGeneralAgrupadoToolStripMenuItem.Visible = False

        Try
            Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            If cmbNave.SelectedValue > 0 Then
                Controles.ComboPeriodoSegunNaveSegunAsistencia(cmbPeriodoNomina, cmbNave.SelectedValue)
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNave.DropDownClosed
        Try
            Controles.ComboPeriodoSegunNaveSegunAsistencia(cmbPeriodoNomina, cmbNave.SelectedValue)
            FechasSemanaNomina()



            'If cmbNave.SelectedValue = 3 Then
            ImprimirReporteGeneralAgrupadoToolStripMenuItem.Visible = True
            'Else
            'ImprimirReporteGeneralAgrupadoToolStripMenuItem.Visible = False
            'End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim listaCorteNominaa As New List(Of Entidades.CalcularNominaReal)
        Dim nomina As New Nomina.Negocios.CalcularNominaRealBU
        Dim objNominaBU As New Negocios.CalcularNominaRealBU
        ImprimirReciboDiaFestivoToolStripMenuItem.Enabled = True
        ImprimirSobreToolStripMenuItem.Enabled = True
        listaCorteNominaa = nomina.ListaCorteNomina(cmbNave.SelectedValue, cmbPeriodoNomina.SelectedValue, txtColaborador.Text, "")
        AgregarFilaColaboradoresNominaReal(listaCorteNominaa)
        lstColaboradorIdIncapacidades = objNominaBU.ConsultaColaboradorIncapacidad(cmbNave.SelectedValue, cmbPeriodoNomina.SelectedValue)
        If cmbNave.SelectedValue <> 61 Then
            ContextMenuStrip1.Items(9).Visible = False
        Else
            ContextMenuStrip1.Items(9).Visible = True
        End If
        'grdDeducciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub AgregarFilaColaboradoresNominaReal(ByVal Nomina As List(Of Entidades.CalcularNominaReal))
        grdDeducciones.Rows.Clear()

        Try
            Dim numerodeDatos As List(Of Integer) = Nomina.Select(Function(c) c.PColaborador.PColaboradorid).Distinct.ToList
            Dim rowCount As Integer = 0

            For Each numerodeColaboradores As Integer In numerodeDatos
                Dim totalPercepciones As Double = 0
                Dim totalDeducciones As Double = 0
                Dim totalEntregar As Double = 0

                Dim colaboradorID As Integer
                Dim salarioSemanal As Double = 0
                Dim conHoras As Integer = 0
                Dim conGratificaciones As Integer = 0
                Dim conPuntualidad As Integer = 0

                Dim TotalCumpleaños As Double = 0
                Dim TotalPuntualidadAsistencia As Double = 0
                Dim TotalGratificaciones As Double = 0
                Dim TotalcajaAhorro As Double = 0
                Dim TotalIMSS As Double = 0
                Dim TotalISR As Double = 0
                Dim Totalinfonavit As Double = 0
                Dim TotalPrestamo As Double = 0
                Dim otrasDeducciones As Double = 0
                Dim TotalSemana As Double = 0


                Dim RealTipo As String
                Dim realSalario = ""

                Dim montodescontar As Double = 0
                colaboradorID = numerodeColaboradores

                Dim objE As Entidades.CalcularNominaReal = Nomina.Find(Function(c) c.PColaborador.PColaboradorid = colaboradorID)
                Dim colaboradorNom As String = objE.PColaborador.PNombre + " " + objE.PColaborador.PApaterno + " " + objE.PColaborador.PAmaterno
                RealTipo = objE.PRealTipo



                If RealTipo = "DESTAJO" Then
                    realSalario = "DESTAJO"
                End If

                If RealTipo = "SALARIO" Then
                    realSalario = objE.PSalarioReal
                End If
                If RealTipo = "POR BANDA" Then
                    realSalario = "POR BANDA"
                End If



                ''OBTENER OTRAS DEDUCCIONES
                Dim listaDecucciones As New List(Of Entidades.Deducciones)
                Dim deduccionesBU As New Nomina.Negocios.DeduccionesBU

                listaDecucciones = deduccionesBU.ListaDeduccionFiltroCorte(cmbNave.SelectedValue, cmbPeriodoNomina.SelectedValue, txtColaborador.Text, colaboradorID)

                For Each objeto As Entidades.Deducciones In listaDecucciones
                    otrasDeducciones += objeto.Pabono
                Next



                ''OBTENER PERCEPCIONES
                Dim objNominaBU As New Negocios.CalcularNominaRealBU

                Dim listaPerc As List(Of Entidades.CalcularNominaReal)
                Dim limitePerc As Integer = 0
                Dim iterador As Integer = 0


                listaPerc = objNominaBU.percepciones(colaboradorID, cmbPeriodoNomina.SelectedValue)

                For Each dato As Entidades.CalcularNominaReal In listaPerc
                    Dim Tipoperc As Integer = dato.PPercepciones.PPercepcionTipo
                    Dim conceptoPerc As String = ""
                    Dim montoperc As Double = dato.PPercepciones.PMontoPercepcion


                    totalPercepciones += montoperc

                    If Tipoperc = 1 Then
                        conceptoPerc = "Puntualidad y asistencia"
                        TotalPuntualidadAsistencia = montoperc
                    End If
                    If Tipoperc = 2 Then
                        conceptoPerc = "Gratificaciones"
                        TotalGratificaciones = montoperc
                    End If

                    If Tipoperc = 0 Then
                        conceptoPerc = "Salario semanal"
                        TotalSemana = montoperc
                    End If

                    If Tipoperc = 3 Then
                        conceptoPerc = "Cumpleaños"
                        TotalCumpleaños = montoperc
                        TotalGratificaciones += TotalCumpleaños
                    End If
                Next

                ' '' obtener deducciones inicia
                Dim listaDedu As List(Of Entidades.CalcularNominaReal)
                listaDedu = objNominaBU.deduccionesFija(colaboradorID, cmbPeriodoNomina.SelectedValue)

                For Each dato As Entidades.CalcularNominaReal In listaDedu
                    Dim conceptoDedu As String = dato.PDeduccionExtraordinaria.PConceptoDeduccion
                    Dim montoDedu As Double = dato.PDeduccionExtraordinaria.PMontoDeduccion

                    If conceptoDedu = "Caja de ahorro" Then
                        TotalcajaAhorro = montoDedu
                    End If

                    If conceptoDedu = "Prestamo" Then
                        TotalPrestamo = montoDedu
                    End If

                    If conceptoDedu = "Retencion infonavit" Then
                        Totalinfonavit = montoDedu
                    End If

                    If conceptoDedu = "IMSS" Then
                        TotalIMSS = montoDedu
                    End If

                    If conceptoDedu = "ISR" Then
                        TotalISR = montoDedu
                    End If

                    '      TotalIMSS = TotalIMSS + TotalISR
                    totalDeducciones += montoDedu

                Next

                Dim listaAsistencia As List(Of Entidades.CalcularNominaReal)
                Dim DiasTrabajados As Double = 0
                Dim DiasTrabajados2 As Double = 0
                Dim inasistencias As Double = 0
                Dim inasistencias2 As Double = 0
                Dim ausentismos As Double = 0
                Dim SalarioSemanal2 As Double = objE.PSalarioSemanal
                Dim TotalEntregar2 As Double = objE.PTotalEntregar

                ''Obtener configuración de nómina 
                Dim objBU As New Negocios.CalcularNominaRealBU
                Dim TablaConfiguracion As DataTable = objBU.configuracionNomina(cmbNave.SelectedValue)
                pagoSeptimoDia = TablaConfiguracion.Rows(0).Item("conf_pagoSeptimoDia").ToString
                generarRegistroNoCheca = CBool(TablaConfiguracion.Rows(0).Item("nave_generarRegistroNoCheca").ToString)


                If objE.PCheca = False And generarRegistroNoCheca = False Then
                    inasistencias = 0
                    inasistencias2 = 0
                ElseIf objE.PCheca = True Or (objE.PCheca = False And generarRegistroNoCheca = True) Then
                    If objE.PGanaIncentivosSiempre = True Then

                    ElseIf objE.PGanaIncentivosSiempre = False Then


                        listaAsistencia = objNominaBU.checador(colaboradorID, cmbPeriodoNomina.SelectedValue)

                        If listaAsistencia.Count = 0 Then
                            DiasTrabajados = 0
                            DiasTrabajados2 = 0
                            inasistencias = 7
                            inasistencias2 = 7

                        Else
                            For Each fila As Entidades.CalcularNominaReal In listaAsistencia
                                DiasTrabajados = fila.Pchecador.PAsistencia
                                DiasTrabajados2 = fila.Pchecador.PAsistencia
                                inasistencias = fila.Pchecador.PInasistencia
                                inasistencias2 = fila.Pchecador.PInasistencia
                            Next

                            ''NUMERO DE FALTAS Y EL PROPORCIANAL DOMINGO
                            ''NUMERO DE FALTAS Y EL PROPORCIANAL DOMINGO
                            ''NUMERO DE FALTAS Y EL PROPORCIANAL DOMINGO
                            ''NUMERO DE FALTAS Y EL PROPORCIANAL DOMINGO
                            'Dim objBU As New Negocios.CalcularNominaRealBU
                            'Dim TablaConfiguracion As DataTable = objBU.configuracionNomina(cmbNave.SelectedValue)
                            'pagoSeptimoDia = TablaConfiguracion.Rows(0).Item("conf_pagoSeptimoDia").ToString

                            Dim totalDomingo As Double = 0
                            Dim listaFiniquitos As List(Of Entidades.CalcularNominaReal)

                            If pagoSeptimoDia = "A" Then
                                ''A=pago proporcional del domingo
                                Dim validarCalculo As Integer = 0
                                listaFiniquitos = objNominaBU.consultaFiniquitosActivos(colaboradorID, fechaInicio, fechaFin)
                                For Each dato As Entidades.CalcularNominaReal In listaFiniquitos
                                    validarCalculo += 1
                                Next
                                Dim FechaIngreso As DateTime = objE.PFechaIngreso
                                If FechaIngreso >= fechaInicio And FechaIngreso <= fechaFin Then
                                    validarCalculo += 1
                                End If

                                If validarCalculo > 0 Then

                                    totalDomingo = 1 / 6
                                    DiasTrabajados = DiasTrabajados + (DiasTrabajados * totalDomingo)
                                    If DiasTrabajados = 0 Then
                                        inasistencias = 7
                                        inasistencias2 = 7
                                    Else
                                        If DiasTrabajados2 = 7 Then
                                            inasistencias = 0
                                        Else
                                            inasistencias = inasistencias2
                                            inasistencias2 = inasistencias
                                            inasistencias += (inasistencias * totalDomingo)
                                        End If
                                    End If
                                    If inasistencias < 0 Then
                                        inasistencias = 0
                                        inasistencias2 = inasistencias
                                    End If
                                Else
                                    If DiasTrabajados = 0 Then
                                        inasistencias = 7
                                        inasistencias2 = 7
                                    End If
                                End If

                            ElseIf pagoSeptimoDia = "B" Then
                                ''SIEMPRE SE PAGA COMPLETO EL DOMINGO
                                If DiasTrabajados = 0 Then
                                    inasistencias = 7
                                    inasistencias2 = 7
                                Else
                                    DiasTrabajados += 1
                                    DiasTrabajados2 += 1
                                End If
                                'DIAS COMPLETOS 
                                If inasistencias = 0 Then

                                    DiasTrabajados = 7
                                    DiasTrabajados2 = 7
                                End If
                            End If
                        End If
                    End If
                End If
                'ausentismos = (objE.PSalarioReal / 7) * inasistencias


                ''OBTENER concepto gratificaciones

                Dim objBUG As New Nomina.Negocios.CorteNominaRealBU
                Dim tabla As New DataTable
                Dim descripcion As String = ""

                'If cmbNave.SelectedValue <> 43 Then
                tabla = objBUG.obtenerDescripcionGratificaciones(colaboradorID, cmbPeriodoNomina.SelectedValue)
                If tabla.Rows.Count > 0 Then
                    descripcion = tabla.Rows(0).Item("descripcion")
                End If
                'End If

                '''''''''''''''''''''''''''''''
                ''''''''''Cumpleaños'''''''''''
                '''''''''''''''''''''''''''''''
                Dim listaConfIncentivos As List(Of Entidades.CalcularNominaReal)
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

                If GratificacionCumple = True Then
                    If TotalCumpleaños > 0 Then
                        descripcion = "Cumpleaños"
                    End If


                    Dim dia As Integer = 0
                    Dim mes As Integer = 0
                    Dim fecha2 As String = ""
                    Dim fechaNac As DateTime
                    fecha2 = objE.PFechaNac.Day.ToString + "/" + objE.PFechaNac.Month.ToString + "/" + fechaInicio.Year.ToString
                    fechaNac = CDate(fecha2)
                    If fechaNac >= fechaInicio And fechaNac <= fechaFin And TotalCumpleaños = 0 Then
                        TotalCumpleaños = objE.PSalarioReal / 7
                        descripcion += " Cumpleaños"
                    End If

                End If


                '''''''''''''''''''''''''''''''
                ''''''''''Cumpleaños'''''''''''
                '''''''''''''''''''''''''''''''

                ''Incapacidad 
                Dim incapacidades As Integer = 0
                incapacidades = objBU.ConsultaIncapacidades(colaboradorID, cmbPeriodoNomina.SelectedValue, 2)



                Dim numeroFilaColaborador As Integer
                'If objE.PfiniquitoID = 0 Then
                rowCount = rowCount + 1
                numeroFilaColaborador = rowCount
                'Else
                'numeroFilaColaborador = 0
                'End If

                If RealTipo = "SALARIO" Then

                    If inasistencias > 0 And objE.Pausentismos = 0 Then
                        ausentismos = (SalarioSemanal2 / 7) * inasistencias
                    ElseIf inasistencias > 0 Then
                        ausentismos = objE.Pausentismos
                    End If

                    'grdDeducciones.Rows.Add(colaboradorID, numeroFilaColaborador, colaboradorNom, objE.PDepartamento, objE.PPuesto, inasistencias2, Math.Round(SalarioSemanal2, 0).ToString("N0"), Math.Round(TotalPuntualidadAsistencia).ToString("N0"), Math.Round(TotalGratificaciones).ToString("N0"), Math.Round(ausentismos).ToString("N0"), Math.Round(TotalIMSS + TotalISR).ToString("N0"), Math.Round(Totalinfonavit).ToString("N0"), Math.Round(TotalPrestamo).ToString("N0"), Math.Round(TotalcajaAhorro).ToString("N0"), Math.Round(otrasDeducciones).ToString("N0"), Math.Round(TotalEntregar2).ToString("N0"), objE.PTipoSueldo, objE.PColaborador.pIdAnual, objE.PCuenta, objE.PCelulaIDSAY, objE.PdepartamentoID, objE.Psexo, TotalISR, objE.POrdenPuesto, descripcion, objE.PfiniquitoID)
                    ''AMPM 05-10-2018 diferencia Pesos Impresion Resumen Pago de Nomina
                    grdDeducciones.Rows.Add(colaboradorID, numeroFilaColaborador, colaboradorNom, objE.PDepartamento, objE.PPuesto, inasistencias2, incapacidades, Math.Round(SalarioSemanal2, 0).ToString("N0"), Math.Round(TotalPuntualidadAsistencia).ToString("N0"), Math.Round(TotalGratificaciones).ToString("N0"), Math.Round(ausentismos).ToString("N0"), Math.Round(Math.Round(TotalIMSS, 0) + Math.Round(TotalISR, 0), 0).ToString("N0"), Math.Round(Totalinfonavit).ToString("N0"), Math.Round(TotalPrestamo).ToString("N0"), Math.Round(TotalcajaAhorro).ToString("N0"), Math.Round(otrasDeducciones).ToString("N0"), Math.Round(TotalEntregar2).ToString("N0"), objE.PTipoSueldo, objE.PColaborador.pIdAnual, objE.PCuenta, objE.PCelulaIDSAY, objE.PdepartamentoID, objE.Psexo, TotalISR, objE.POrdenPuesto, descripcion, objE.PfiniquitoID)

                ElseIf RealTipo = "DESTAJO" Then

                    'grdDeducciones.Rows.Add(colaboradorID, numeroFilaColaborador, colaboradorNom, objE.PDepartamento, objE.PPuesto, inasistencias2, Math.Round(SalarioSemanal2, 0).ToString("N0"), Math.Round(TotalPuntualidadAsistencia).ToString("N0"), Math.Round(TotalGratificaciones).ToString("N0"), Math.Round(ausentismos).ToString("N0"), Math.Round(TotalIMSS + TotalISR).ToString("N0"), Math.Round(Totalinfonavit).ToString("N0"), Math.Round(TotalPrestamo).ToString("N0"), Math.Round(TotalcajaAhorro).ToString("N0"), Math.Round(otrasDeducciones).ToString("N0"), Math.Round(TotalEntregar2).ToString("N0"), objE.PTipoSueldo, objE.PColaborador.pIdAnual, objE.PCuenta, objE.PCelulaIDSAY, objE.PdepartamentoID, objE.Psexo, TotalISR, objE.POrdenPuesto, descripcion, objE.PfiniquitoID)
                    ''AMPM 05-10-2018 diferencia Pesos Impresion Resumen Pago de Nomina
                    grdDeducciones.Rows.Add(colaboradorID, numeroFilaColaborador, colaboradorNom, objE.PDepartamento, objE.PPuesto, inasistencias2, incapacidades, Math.Round(SalarioSemanal2, 0).ToString("N0"), Math.Round(TotalPuntualidadAsistencia).ToString("N0"), Math.Round(TotalGratificaciones).ToString("N0"), Math.Round(ausentismos).ToString("N0"), Math.Round(Math.Round(TotalIMSS, 0) + Math.Round(TotalISR, 0), 0).ToString("N0"), Math.Round(Totalinfonavit).ToString("N0"), Math.Round(TotalPrestamo).ToString("N0"), Math.Round(TotalcajaAhorro).ToString("N0"), Math.Round(otrasDeducciones).ToString("N0"), Math.Round(TotalEntregar2).ToString("N0"), objE.PTipoSueldo, objE.PColaborador.pIdAnual, objE.PCuenta, objE.PCelulaIDSAY, objE.PdepartamentoID, objE.Psexo, TotalISR, objE.POrdenPuesto, descripcion, objE.PfiniquitoID)


                ElseIf RealTipo = "POR BANDA" Then

                    If inasistencias > 0 And objE.Pausentismos = 0 Then
                        ausentismos = (SalarioSemanal2 / 7) * inasistencias
                    ElseIf inasistencias > 0 Then
                        ausentismos = objE.Pausentismos
                    End If
                    'grdDeducciones.Rows.Add(colaboradorID, numeroFilaColaborador, colaboradorNom, objE.PDepartamento, objE.PPuesto, inasistencias2, Math.Round(SalarioSemanal2, 0).ToString("N0"), Math.Round(TotalPuntualidadAsistencia).ToString("N0"), Math.Round(TotalGratificaciones).ToString("N0"), Math.Round(ausentismos).ToString("N0"), Math.Round(TotalIMSS + TotalISR).ToString("N0"), Math.Round(Totalinfonavit).ToString("N0"), Math.Round(TotalPrestamo).ToString("N0"), Math.Round(TotalcajaAhorro).ToString("N0"), Math.Round(otrasDeducciones).ToString("N0"), Math.Round(TotalEntregar2).ToString("N0"), objE.PTipoSueldo, objE.PColaborador.pIdAnual, objE.PCuenta, objE.PCelulaIDSAY, objE.PdepartamentoID, objE.Psexo, TotalISR, objE.POrdenPuesto, descripcion, objE.PfiniquitoID)
                    ''AMPM 05-10-2018 diferencia Pesos Impresion Resumen Pago de Nomina
                    grdDeducciones.Rows.Add(colaboradorID, numeroFilaColaborador, colaboradorNom, objE.PDepartamento, objE.PPuesto, inasistencias2, incapacidades, Math.Round(SalarioSemanal2, 0).ToString("N0"), Math.Round(TotalPuntualidadAsistencia).ToString("N0"), Math.Round(TotalGratificaciones).ToString("N0"), Math.Round(ausentismos).ToString("N0"), Math.Round(Math.Round(TotalIMSS, 0) + Math.Round(TotalISR, 0), 0).ToString("N0"), Math.Round(Totalinfonavit).ToString("N0"), Math.Round(TotalPrestamo).ToString("N0"), Math.Round(TotalcajaAhorro).ToString("N0"), Math.Round(otrasDeducciones).ToString("N0"), Math.Round(TotalEntregar2).ToString("N0"), objE.PTipoSueldo, objE.PColaborador.pIdAnual, objE.PCuenta, objE.PCelulaIDSAY, objE.PdepartamentoID, objE.Psexo, TotalISR, objE.POrdenPuesto, descripcion, objE.PfiniquitoID)

                End If

                If objE.PfiniquitoID <> 0 Then
                    grdDeducciones.Rows(grdDeducciones.RowCount - 1).DefaultCellStyle.Font = New Font(grdDeducciones.Font, FontStyle.Bold)
                End If

            Next


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



            For Each row As DataGridViewRow In grdDeducciones.Rows
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
            If contadorFilas2 > 0 Then
                grdDeducciones.Rows.Add("", "", "", "", "", "", "", TotalpagoBruto.ToString("N0"), TotalPuntualidadAsistencia2.ToString("N0"), TotalGratificaciones2.ToString("N0"), Totalausentismos2.ToString("N0"), TotalIMSS2.ToString("N0"), TotalInfonavit2.ToString("N0"), TotalPrestamos2.ToString("N0"), TotalCajaAhorro2.ToString("N0"), TotalOtrasDeducciones2.ToString("N0"), TotalTotalEntregar2.ToString("N0"))

                grdDeducciones.Rows(contadorFilas2).DefaultCellStyle.BackColor = Color.GreenYellow
            End If


        Catch ex As Exception

        End Try
    End Sub



    Public Sub AgregarFilaColaboradoresNominaRealIMPRIMIR(ByVal Nomina As List(Of Entidades.CalcularNominaReal))
        grdDeducciones.Rows.Clear()

        Try
            '  Dim numerodeDatos As List(Of Integer) = Nomina.Select(Function(c) c.PColaborador.PColaboradorid).Distinct.ToList
            Dim rowCount As Integer = 0

            For Each row As Entidades.CalcularNominaReal In Nomina
                Dim totalPercepciones As Double = 0
                Dim totalDeducciones As Double = 0
                Dim totalEntregar As Double = 0
                Dim realFecha As DateTime
                Dim colaboradorID As Integer
                Dim salarioSemanal As Double = 0
                Dim conHoras As Integer = 0
                Dim conGratificaciones As Integer = 0
                Dim conPuntualidad As Integer = 0

                Dim TotalPuntualidadAsistencia As Double = 0
                Dim TotalGratificaciones As Double = 0
                Dim TotalcajaAhorro As Double = 0
                Dim TotalIMSS As Double = 0
                Dim TotalISR As Double = 0
                Dim Totalinfonavit As Double = 0
                Dim TotalPrestamo As Double = 0
                Dim otrasDeducciones As Double = 0
                Dim TotalSemana As Double = 0


                Dim RealTipo As String
                Dim realSalario = ""

                Dim montodescontar As Double = 0
                colaboradorID = row.PColaborador.PColaboradorid
                realFecha = row.PFechaIngreso

                If realFecha <= fechaFin Then


                    Dim objE As Entidades.CalcularNominaReal = Nomina.Find(Function(c) c.PColaborador.PColaboradorid = colaboradorID)
                    Dim colaboradorNom As String = objE.PColaborador.PNombre + " " + objE.PColaborador.PApaterno + " " + objE.PColaborador.PAmaterno
                    RealTipo = objE.PRealTipo



                    If RealTipo = "DESTAJO" Then
                        realSalario = "DESTAJO"
                    End If

                    If RealTipo = "SALARIO" Then
                        realSalario = objE.PSalarioReal
                    End If
                    If RealTipo = "POR BANDA" Then
                        realSalario = "DESTAJO"
                    End If


                    ''OBTENER OTRAS DEDUCCIONES
                    Dim listaDecucciones As New List(Of Entidades.Deducciones)
                    Dim deduccionesBU As New Nomina.Negocios.DeduccionesBU

                    listaDecucciones = deduccionesBU.ListaDeduccionFiltroCorte(cmbNave.SelectedValue, cmbPeriodoNomina.SelectedValue, "", colaboradorID)

                    For Each objeto As Entidades.Deducciones In listaDecucciones
                        otrasDeducciones += objeto.Pabono
                    Next



                    ''OBTENER PERCEPCIONES
                    Dim objNominaBU As New Negocios.CalcularNominaRealBU

                    Dim listaPerc As List(Of Entidades.CalcularNominaReal)
                    Dim limitePerc As Integer = 0
                    Dim iterador As Integer = 0

                    listaPerc = objNominaBU.percepciones(colaboradorID, cmbPeriodoNomina.SelectedValue)

                    For Each dato As Entidades.CalcularNominaReal In listaPerc
                        Dim Tipoperc As Integer = dato.PPercepciones.PPercepcionTipo
                        Dim conceptoPerc As String = ""
                        Dim montoperc As Double = dato.PPercepciones.PMontoPercepcion
                        Dim totalCumpleaños As Double = 0
                        totalPercepciones += montoperc

                        If Tipoperc = 1 Then
                            conceptoPerc = "Puntualidad y asistencia"
                            TotalPuntualidadAsistencia = montoperc
                        End If
                        If Tipoperc = 2 Then
                            conceptoPerc = "Gratificaciones"
                            TotalGratificaciones = montoperc
                        End If

                        If Tipoperc = 0 Then
                            conceptoPerc = "Salario semanal"
                            TotalSemana = montoperc
                        End If

                        If Tipoperc = 3 Then
                            conceptoPerc = "Cumpleaños"
                            totalCumpleaños = montoperc
                            TotalGratificaciones += totalCumpleaños
                        End If

                    Next

                    ' '' obtener deducciones inicia
                    Dim listaDedu As List(Of Entidades.CalcularNominaReal)
                    listaDedu = objNominaBU.deduccionesFija(colaboradorID, cmbPeriodoNomina.SelectedValue)

                    For Each dato As Entidades.CalcularNominaReal In listaDedu
                        Dim conceptoDedu As String = dato.PDeduccionExtraordinaria.PConceptoDeduccion
                        Dim montoDedu As Double = dato.PDeduccionExtraordinaria.PMontoDeduccion

                        If conceptoDedu = "Caja de ahorro" Then
                            TotalcajaAhorro = montoDedu
                        End If

                        If conceptoDedu = "Prestamo" Then
                            TotalPrestamo = montoDedu
                        End If

                        If conceptoDedu = "Retencion infonavit" Then
                            Totalinfonavit = montoDedu
                        End If

                        If conceptoDedu = "IMSS" Then
                            TotalIMSS = montoDedu
                        End If

                        If conceptoDedu = "ISR" Then
                            TotalISR = montoDedu
                        End If
                        '  TotalIMSS = TotalIMSS + TotalISR
                        totalDeducciones += montoDedu

                    Next

                    Dim listaAsistencia As List(Of Entidades.CalcularNominaReal)
                    Dim DiasTrabajados As Double = 0
                    Dim DiasTrabajados2 As Double = 0
                    Dim inasistencias As Double = 0
                    Dim inasistencias2 As Double = 0
                    Dim ausentismos As Double = 0
                    Dim SalarioSemanal2 As Double = objE.PSalarioSemanal
                    Dim TotalEntregar2 As Double = objE.PTotalEntregar

                    ''Consultar la configuración de nómina
                    Dim objBU As New Negocios.CalcularNominaRealBU
                    Dim TablaConfiguracion As DataTable = objBU.configuracionNomina(cmbNave.SelectedValue)
                    pagoSeptimoDia = TablaConfiguracion.Rows(0).Item("conf_pagoSeptimoDia").ToString
                    generarRegistroNoCheca = CBool(TablaConfiguracion.Rows(0).Item("nave_generarRegistroNoCheca").ToString)


                    If objE.PCheca = False And generarRegistroNoCheca = False Then
                        inasistencias = 0
                        inasistencias2 = 0
                    ElseIf objE.PCheca = True Or (objE.PCheca = False And generarRegistroNoCheca = True) Then
                        If objE.PGanaIncentivosSiempre = True Then

                        ElseIf objE.PGanaIncentivosSiempre = False Then


                            listaAsistencia = objNominaBU.checador(colaboradorID, cmbPeriodoNomina.SelectedValue)


                            For Each fila As Entidades.CalcularNominaReal In listaAsistencia
                                DiasTrabajados = fila.Pchecador.PAsistencia
                                DiasTrabajados2 = fila.Pchecador.PAsistencia
                                inasistencias = fila.Pchecador.PInasistencia
                                inasistencias2 = fila.Pchecador.PInasistencia


                            Next
                            ''NUMERO DE FALTAS Y EL PROPORCIANAL DOMINGO
                            ''NUMERO DE FALTAS Y EL PROPORCIANAL DOMINGO
                            ''NUMERO DE FALTAS Y EL PROPORCIANAL DOMINGO
                            ''NUMERO DE FALTAS Y EL PROPORCIANAL DOMINGO
                            ''NUMERO DE FALTAS Y EL PROPORCIANAL DOMINGO
                            'Dim objBU As New Negocios.CalcularNominaRealBU
                            'Dim TablaConfiguracion As DataTable = objBU.configuracionNomina(cmbNave.SelectedValue)
                            'pagoSeptimoDia = TablaConfiguracion.Rows(0).Item("conf_pagoSeptimoDia").ToString

                            Dim totalDomingo As Double = 0
                            Dim listaFiniquitos As List(Of Entidades.CalcularNominaReal)
                            If pagoSeptimoDia = "A" Then
                                ''A=pago proporcional del domingo
                                Dim validarCalculo As Integer = 0
                                listaFiniquitos = objNominaBU.consultaFiniquitosActivos(colaboradorID, fechaInicio, fechaFin)
                                For Each dato As Entidades.CalcularNominaReal In listaFiniquitos
                                    validarCalculo += 1
                                Next
                                Dim FechaIngreso As DateTime = objE.PFechaIngreso
                                If FechaIngreso >= fechaInicio And FechaIngreso <= fechaFin Then
                                    validarCalculo += 1
                                End If

                                If validarCalculo > 0 Then

                                    totalDomingo = 1 / 6
                                    DiasTrabajados = DiasTrabajados + (DiasTrabajados * totalDomingo)
                                    If DiasTrabajados = 0 Then
                                        inasistencias = 7
                                        inasistencias2 = 7
                                    Else
                                        If DiasTrabajados2 = 7 Then
                                            inasistencias = 0
                                        Else
                                            inasistencias = inasistencias2
                                            inasistencias2 = inasistencias
                                            inasistencias += (inasistencias * totalDomingo)
                                        End If
                                    End If
                                    If inasistencias < 0 Then
                                        inasistencias = 0
                                        inasistencias2 = inasistencias
                                    End If
                                Else
                                    If DiasTrabajados = 0 Then
                                        inasistencias = 7
                                        inasistencias2 = 7
                                    End If
                                End If

                            ElseIf pagoSeptimoDia = "B" Then
                                ''SIEMPRE SE PAGA COMPLETO EL DOMINGO
                                If DiasTrabajados = 0 Then
                                    inasistencias = 7
                                    inasistencias2 = 7
                                Else
                                    DiasTrabajados += 1
                                    DiasTrabajados2 += 1
                                End If
                                If inasistencias = 0 Then
                                    DiasTrabajados = 7
                                    DiasTrabajados2 = 7
                                End If
                            End If
                            '  ausentismos = (objE.PSalarioReal / 7) * inasistencias

                        End If
                    End If




                    Dim numeroFilaColaborador As Integer
                    If objE.PfiniquitoID = 0 Then
                        rowCount = rowCount + 1
                        numeroFilaColaborador = rowCount
                    Else
                        numeroFilaColaborador = 0
                    End If

                    If RealTipo = "SALARIO" Then
                        If inasistencias > 0 And objE.Pausentismos = 0 Then
                            ausentismos = (SalarioSemanal2 / 7) * inasistencias
                        ElseIf inasistencias > 0 Then
                            ausentismos = objE.Pausentismos
                        End If

                        If cmbPeriodoNomina.SelectedValue = "4439" Then

                            If inasistencias2 = 7 Then
                                inasistencias2 = 5
                                inasistencias = 5
                            End If
                        End If
                        If cmbPeriodoNomina.SelectedValue = "4675" Then
                            If inasistencias2 = 7 Then
                                inasistencias2 = 5
                                inasistencias = 5
                            End If

                        End If


                        'JEANS
                        If cmbPeriodoNomina.SelectedValue = "4403" Then
                            If inasistencias2 = 7 Then
                                inasistencias2 = 6
                                inasistencias = 6
                            End If

                        End If





                        grdDeducciones.Rows.Add(colaboradorID, numeroFilaColaborador, colaboradorNom, objE.PDepartamento, objE.PPuesto, inasistencias2, 0, Math.Round(SalarioSemanal2, 0).ToString("N0"), Math.Round(TotalPuntualidadAsistencia).ToString("N0"), Math.Round(TotalGratificaciones).ToString("N0"), Math.Round(ausentismos).ToString("N0"), Math.Round(Math.Round(TotalIMSS, 0) + Math.Round(TotalISR, 0), 0).ToString("N0"), Math.Round(Totalinfonavit).ToString("N0"), Math.Round(TotalPrestamo).ToString("N0"), Math.Round(TotalcajaAhorro).ToString("N0"), Math.Round(otrasDeducciones).ToString("N0"), Math.Round(TotalEntregar2).ToString("N0"), objE.PTipoSueldo, TotalISR, 0, 0, 0, 0, 0, objE.POrdenPuesto, 0, objE.PfiniquitoID)

                    ElseIf RealTipo = "DESTAJO" Then


                        'JEANS
                        If cmbPeriodoNomina.SelectedValue = "4403" Then
                            If inasistencias2 = 7 Then
                                inasistencias2 = 6
                                inasistencias = 6
                            End If

                        End If

                        grdDeducciones.Rows.Add(colaboradorID, numeroFilaColaborador, colaboradorNom, objE.PDepartamento, objE.PPuesto, inasistencias2, 0, Math.Round(SalarioSemanal2, 0).ToString("N0"), Math.Round(TotalPuntualidadAsistencia).ToString("N0"), Math.Round(TotalGratificaciones).ToString("N0"), Math.Round(ausentismos).ToString("N0"), Math.Round(Math.Round(TotalIMSS, 0) + Math.Round(TotalISR, 0), 0).ToString("N0"), Math.Round(Totalinfonavit).ToString("N0"), Math.Round(TotalPrestamo).ToString("N0"), Math.Round(TotalcajaAhorro).ToString("N0"), Math.Round(otrasDeducciones).ToString("N0"), Math.Round(TotalEntregar2).ToString("N0"), objE.PTipoSueldo, TotalISR, 0, 0, 0, 0, 0, objE.POrdenPuesto, 0, objE.PfiniquitoID)
                    ElseIf RealTipo = "POR BANDA" Then


                        'JEANS
                        If cmbPeriodoNomina.SelectedValue = "4403" Then
                            If inasistencias2 = 7 Then
                                inasistencias2 = 6
                                inasistencias = 6
                            End If

                        End If


                        If inasistencias > 0 And objE.Pausentismos = 0 Then
                            ausentismos = (SalarioSemanal2 / 7) * inasistencias
                        ElseIf inasistencias > 0 Then
                            ausentismos = objE.Pausentismos
                        End If

                        grdDeducciones.Rows.Add(colaboradorID, numeroFilaColaborador, colaboradorNom, objE.PDepartamento, objE.PPuesto, inasistencias2, 0, Math.Round(SalarioSemanal2, 0).ToString("N0"), Math.Round(TotalPuntualidadAsistencia).ToString("N0"), Math.Round(TotalGratificaciones).ToString("N0"), Math.Round(ausentismos).ToString("N0"), Math.Round(Math.Round(TotalIMSS, 0) + Math.Round(TotalISR, 0), 0).ToString("N0"), Math.Round(Totalinfonavit).ToString("N0"), Math.Round(TotalPrestamo).ToString("N0"), Math.Round(TotalcajaAhorro).ToString("N0"), Math.Round(otrasDeducciones).ToString("N0"), Math.Round(TotalEntregar2).ToString("N0"), objE.PTipoSueldo, TotalISR, 0, 0, 0, 0, 0, objE.POrdenPuesto, 0, objE.PfiniquitoID)


                    End If
                End If

            Next

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

            For Each row As DataGridViewRow In grdDeducciones.Rows
                Totalausentismos2 += row.Cells("clmAusentismos").Value
                TotalPuntualidadAsistencia2 += row.Cells("clmPuntualidadAsistencia").Value
                TotalGratificaciones2 += row.Cells("clmGratificaciones").Value
                TotalCajaAhorro2 += row.Cells("clmCajaDeAhorro").Value
                TotalIMSS2 += row.Cells("clmIMMS").Value
                TotalInfonavit2 += row.Cells("clmInfonavit").Value
                TotalPrestamos2 += row.Cells("clmPrestamos").Value
                If row.Cells("clmOtrasDeducciones").Value > 0 Then
                    TotalOtrasDeducciones2 += row.Cells("clmOtrasDeducciones").Value
                End If
                TotalTotalEntregar2 += row.Cells("clmTotalEntregar").Value
                TotalpagoBruto += row.Cells("clmSalarioRegistrado").Value
                contadorFilas2 += 1
            Next

            'grdDeducciones.Rows.Add("TOTAL", "", "", "", TotalpagoBruto, TotalPuntualidadAsistencia2, TotalGratificaciones2, Totalausentismos2, TotalIMSS2, TotalInfonavit2, TotalPrestamos2, TotalCajaAhorro2, TotalOtrasDeducciones2, TotalTotalEntregar2)

            'grdDeducciones.Rows(contadorFilas2).DefaultCellStyle.BackColor = Color.GreenYellow


        Catch ex As Exception

        End Try
    End Sub


    'Public Sub AgregarFilaColaboradoresNominaRealDEPOSITO(ByVal Nomina As List(Of Entidades.CalcularNominaReal))
    '    grdDeducciones.Rows.Clear()

    '    Try
    '        Dim numerodeDatos As List(Of Integer) = Nomina.Select(Function(c) c.PColaborador.PColaboradorid).Distinct.ToList


    '        For Each numerodeColaboradores As Integer In numerodeDatos
    '            Dim totalPercepciones As Double = 0
    '            Dim totalDeducciones As Double = 0
    '            Dim totalEntregar As Double = 0

    '            Dim colaboradorID As Integer
    '            Dim salarioSemanal As Double = 0
    '            Dim conHoras As Integer = 0
    '            Dim conGratificaciones As Integer = 0
    '            Dim conPuntualidad As Integer = 0

    '            Dim TotalPuntualidadAsistencia As Double = 0
    '            Dim TotalGratificaciones As Double = 0
    '            Dim TotalcajaAhorro As Double = 0
    '            Dim TotalIMSS As Double = 0
    '            Dim Totalinfonavit As Double = 0
    '            Dim TotalPrestamo As Double = 0
    '            Dim otrasDeducciones As Double = 0
    '            Dim TotalSemana As Double = 0


    '            Dim RealTipo As String
    '            Dim realSalario = ""

    '            Dim montodescontar As Double = 0
    '            colaboradorID = numerodeColaboradores

    '            Dim objE As Entidades.CalcularNominaReal = Nomina.Find(Function(c) c.PColaborador.PColaboradorid = colaboradorID)
    '            Dim colaboradorNom As String = objE.PColaborador.PNombre + " " + objE.PColaborador.PApaterno + " " + objE.PColaborador.PAmaterno
    '            RealTipo = objE.PRealTipo

    '            If objE.PTipoSueldo = "DEPOSITO" Then

    '                If RealTipo = "DESTAJO" Then
    '                    realSalario = "DESTAJO"
    '                End If

    '                If RealTipo = "SALARIO" Then
    '                    realSalario = objE.PSalarioReal
    '                End If
    '                If RealTipo = "POR BANDA" Then
    '                    realSalario = "DESTAJO"
    '                End If


    '                ''OBTENER OTRAS DEDUCCIONES
    '                Dim listaDecucciones As New List(Of Entidades.Deducciones)
    '                Dim deduccionesBU As New Nomina.Negocios.DeduccionesBU

    '                listaDecucciones = deduccionesBU.ListaDeduccionFiltroCorte(cmbNave.SelectedValue, cmbPeriodoNomina.SelectedValue, "", colaboradorID)

    '                For Each objeto As Entidades.Deducciones In listaDecucciones
    '                    otrasDeducciones += objeto.Pabono
    '                Next



    '                ''OBTENER PERCEPCIONES
    '                Dim objNominaBU As New Negocios.CalcularNominaRealBU

    '                Dim listaPerc As List(Of Entidades.CalcularNominaReal)
    '                Dim limitePerc As Integer = 0
    '                Dim iterador As Integer = 0

    '                listaPerc = objNominaBU.percepciones(colaboradorID, cmbPeriodoNomina.SelectedValue)

    '                For Each dato As Entidades.CalcularNominaReal In listaPerc
    '                    Dim Tipoperc As Integer = dato.PPercepciones.PPercepcionTipo
    '                    Dim conceptoPerc As String = ""
    '                    Dim montoperc As Double = dato.PPercepciones.PMontoPercepcion

    '                    totalPercepciones += montoperc

    '                    If Tipoperc = 1 Then
    '                        conceptoPerc = "Puntualidad y asistencia"
    '                        TotalPuntualidadAsistencia = montoperc
    '                    End If
    '                    If Tipoperc = 2 Then
    '                        conceptoPerc = "Gratificaciones"
    '                        TotalGratificaciones = montoperc
    '                    End If

    '                    If Tipoperc = 0 Then
    '                        conceptoPerc = "Salario semanal"
    '                        TotalSemana = montoperc
    '                    End If
    '                Next

    '                ' '' obtener deducciones inicia
    '                Dim listaDedu As List(Of Entidades.CalcularNominaReal)
    '                listaDedu = objNominaBU.deduccionesFija(colaboradorID, cmbPeriodoNomina.SelectedValue)

    '                For Each dato As Entidades.CalcularNominaReal In listaDedu
    '                    Dim conceptoDedu As String = dato.PDeduccionExtraordinaria.PConceptoDeduccion
    '                    Dim montoDedu As Double = dato.PDeduccionExtraordinaria.PMontoDeduccion

    '                    If conceptoDedu = "Caja de ahorro" Then
    '                        TotalcajaAhorro = montoDedu
    '                    End If

    '                    If conceptoDedu = "Prestamo" Then
    '                        TotalPrestamo = montoDedu
    '                    End If

    '                    If conceptoDedu = "Retencion infonavit" Then
    '                        Totalinfonavit = montoDedu
    '                    End If

    '                    If conceptoDedu = "IMSS" Then
    '                        TotalIMSS = montoDedu
    '                    End If

    '                    totalDeducciones += montoDedu

    '                Next
    '                Dim inasistencias As Integer = 7
    '                Dim ausentismos As Double = 0
    '                Dim SalarioSemanal2 As Double = objE.PSalarioSemanal
    '                Dim TotalEntregar2 As Double = objE.PTotalEntregar
    '                inasistencias = inasistencias - objE.PDiasLaborados
    '                ausentismos = objE.PSalarioDiario * inasistencias
    '                If RealTipo = "SALARIO" Then

    '                    grdDeducciones.Rows.Add(colaboradorID, CInt(grdDeducciones.Rows.Count + 1), colaboradorNom, objE.PDepartamento, objE.PPuesto, inasistencias, Math.Round(SalarioSemanal2).ToString("N0"), Math.Round(TotalPuntualidadAsistencia).ToString("N0"), Math.Round(TotalGratificaciones).ToString("N0"), Math.Round(ausentismos).ToString("N0"), Math.Round(TotalIMSS).ToString("N0"), Math.Round(Totalinfonavit).ToString("N0"), Math.Round(TotalPrestamo).ToString("N0"), Math.Round(TotalcajaAhorro).ToString("N0"), Math.Round(otrasDeducciones).ToString("N0"), Math.Round(TotalEntregar2).ToString("N0"))

    '                ElseIf RealTipo = "DESTAJO" Then
    '                    grdDeducciones.Rows.Add(colaboradorID, CInt(grdDeducciones.Rows.Count + 1), colaboradorNom, objE.PDepartamento, objE.PPuesto, inasistencias, Math.Round(SalarioSemanal2).ToString("N0"), Math.Round(TotalPuntualidadAsistencia).ToString("N0"), Math.Round(TotalGratificaciones).ToString("N0"), Math.Round(ausentismos).ToString("N0"), Math.Round(TotalIMSS).ToString("N0"), Math.Round(Totalinfonavit).ToString("N0"), Math.Round(TotalPrestamo).ToString("N0"), Math.Round(TotalcajaAhorro).ToString("N0"), Math.Round(otrasDeducciones).ToString("N0"), Math.Round(TotalEntregar2).ToString("N0"))
    '                ElseIf RealTipo = "POR BANDA" Then

    '                    grdDeducciones.Rows.Add(colaboradorID, CInt(grdDeducciones.Rows.Count + 1), colaboradorNom, objE.PDepartamento, objE.PPuesto, inasistencias, Math.Round(SalarioSemanal2).ToString("N0"), Math.Round(TotalPuntualidadAsistencia).ToString("N0"), Math.Round(TotalGratificaciones).ToString("N0"), Math.Round(ausentismos).ToString("N0"), Math.Round(TotalIMSS).ToString("N0"), Math.Round(Totalinfonavit).ToString("N0"), Math.Round(TotalPrestamo).ToString("N0"), Math.Round(TotalcajaAhorro).ToString("N0"), Math.Round(otrasDeducciones).ToString("N0"), Math.Round(TotalEntregar2).ToString("N0"))


    '                End If

    '            End If
    '        Next
    '        Totalausentismos2 = 0
    '        TotalPuntualidadAsistencia2 = 0
    '        TotalGratificaciones2 = 0
    '        TotalCajaAhorro2 = 0
    '        TotalIMSS2 = 0
    '        TotalInfonavit2 = 0
    '        TotalPrestamos2 = 0
    '        TotalOtrasDeducciones2 = 0
    '        TotalTotalEntregar2 = 0
    '        TotalpagoBruto = 0
    '        contadorFilas2 = 0
    '        For Each row As DataGridViewRow In grdDeducciones.Rows
    '            Totalausentismos2 += row.Cells("clmAusentismos").Value
    '            TotalPuntualidadAsistencia2 += row.Cells("clmPuntualidadAsistencia").Value
    '            TotalGratificaciones2 += row.Cells("clmGratificaciones").Value
    '            TotalCajaAhorro2 += row.Cells("clmCajaDeAhorro").Value
    '            TotalIMSS2 += row.Cells("clmIMMS").Value
    '            TotalInfonavit2 += row.Cells("clmInfonavit").Value
    '            TotalPrestamos2 += row.Cells("clmPrestamos").Value
    '            TotalOtrasDeducciones2 += row.Cells("clmOtrasDeducciones").Value
    '            TotalTotalEntregar2 += row.Cells("clmTotalEntregar").Value
    '            TotalpagoBruto += row.Cells("clmSalarioRegistrado").Value
    '            contadorFilas2 += 1
    '        Next

    '        'grdDeducciones.Rows.Add("TOTAL", "", "", "", TotalpagoBruto, TotalPuntualidadAsistencia2, TotalGratificaciones2, Totalausentismos2, TotalIMSS2, TotalInfonavit2, TotalPrestamos2, TotalCajaAhorro2, TotalOtrasDeducciones2, TotalTotalEntregar2)

    '        'grdDeducciones.Rows(contadorFilas2).DefaultCellStyle.BackColor = Color.GreenYellow


    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Public Sub AgregarFilaColaboradoresNominaRealEFECTIVO(ByVal Nomina As List(Of Entidades.CalcularNominaReal))
    '    grdDeducciones.Rows.Clear()

    '    Try
    '        Dim numerodeDatos As List(Of Integer) = Nomina.Select(Function(c) c.PColaborador.PColaboradorid).Distinct.ToList


    '        For Each numerodeColaboradores As Integer In numerodeDatos
    '            Dim totalPercepciones As Double = 0
    '            Dim totalDeducciones As Double = 0
    '            Dim totalEntregar As Double = 0

    '            Dim colaboradorID As Integer
    '            Dim salarioSemanal As Double = 0
    '            Dim conHoras As Integer = 0
    '            Dim conGratificaciones As Integer = 0
    '            Dim conPuntualidad As Integer = 0

    '            Dim TotalPuntualidadAsistencia As Double = 0
    '            Dim TotalGratificaciones As Double = 0
    '            Dim TotalcajaAhorro As Double = 0
    '            Dim TotalIMSS As Double = 0
    '            Dim Totalinfonavit As Double = 0
    '            Dim TotalPrestamo As Double = 0
    '            Dim otrasDeducciones As Double = 0
    '            Dim TotalSemana As Double = 0


    '            Dim RealTipo As String
    '            Dim realSalario = ""

    '            Dim montodescontar As Double = 0
    '            colaboradorID = numerodeColaboradores

    '            Dim objE As Entidades.CalcularNominaReal = Nomina.Find(Function(c) c.PColaborador.PColaboradorid = colaboradorID)
    '            Dim colaboradorNom As String = objE.PColaborador.PNombre + " " + objE.PColaborador.PApaterno + " " + objE.PColaborador.PAmaterno
    '            RealTipo = objE.PRealTipo

    '            If objE.PTipoSueldo = "EFECTIVO" Then

    '                If RealTipo = "DESTAJO" Then
    '                    realSalario = "DESTAJO"
    '                End If

    '                If RealTipo = "SALARIO" Then
    '                    realSalario = objE.PSalarioReal
    '                End If
    '                If RealTipo = "POR BANDA" Then
    '                    realSalario = "DESTAJO"
    '                End If


    '                ''OBTENER OTRAS DEDUCCIONES
    '                Dim listaDecucciones As New List(Of Entidades.Deducciones)
    '                Dim deduccionesBU As New Nomina.Negocios.DeduccionesBU

    '                listaDecucciones = deduccionesBU.ListaDeduccionFiltroCorte(cmbNave.SelectedValue, cmbPeriodoNomina.SelectedValue, "", colaboradorID)

    '                For Each objeto As Entidades.Deducciones In listaDecucciones
    '                    otrasDeducciones += objeto.Pabono
    '                Next



    '                ''OBTENER PERCEPCIONES
    '                Dim objNominaBU As New Negocios.CalcularNominaRealBU

    '                Dim listaPerc As List(Of Entidades.CalcularNominaReal)
    '                Dim limitePerc As Integer = 0
    '                Dim iterador As Integer = 0

    '                listaPerc = objNominaBU.percepciones(colaboradorID, cmbPeriodoNomina.SelectedValue)

    '                For Each dato As Entidades.CalcularNominaReal In listaPerc
    '                    Dim Tipoperc As Integer = dato.PPercepciones.PPercepcionTipo
    '                    Dim conceptoPerc As String = ""
    '                    Dim montoperc As Double = dato.PPercepciones.PMontoPercepcion

    '                    totalPercepciones += montoperc

    '                    If Tipoperc = 1 Then
    '                        conceptoPerc = "Puntualidad y asistencia"
    '                        TotalPuntualidadAsistencia = montoperc
    '                    End If
    '                    If Tipoperc = 2 Then
    '                        conceptoPerc = "Gratificaciones"
    '                        TotalGratificaciones = montoperc
    '                    End If

    '                    If Tipoperc = 0 Then
    '                        conceptoPerc = "Salario semanal"
    '                        TotalSemana = montoperc
    '                    End If
    '                Next

    '                ' '' obtener deducciones inicia
    '                Dim listaDedu As List(Of Entidades.CalcularNominaReal)
    '                listaDedu = objNominaBU.deduccionesFija(colaboradorID, cmbPeriodoNomina.SelectedValue)

    '                For Each dato As Entidades.CalcularNominaReal In listaDedu
    '                    Dim conceptoDedu As String = dato.PDeduccionExtraordinaria.PConceptoDeduccion
    '                    Dim montoDedu As Double = dato.PDeduccionExtraordinaria.PMontoDeduccion

    '                    If conceptoDedu = "Caja de ahorro" Then
    '                        TotalcajaAhorro = montoDedu
    '                    End If

    '                    If conceptoDedu = "Prestamo" Then
    '                        TotalPrestamo = montoDedu
    '                    End If

    '                    If conceptoDedu = "Retencion infonavit" Then
    '                        Totalinfonavit = montoDedu
    '                    End If

    '                    If conceptoDedu = "IMSS" Then
    '                        TotalIMSS = montoDedu
    '                    End If

    '                    totalDeducciones += montoDedu

    '                Next
    '                Dim inasistencias As Integer = 7
    '                Dim ausentismos As Double = 0
    '                Dim SalarioSemanal2 As Double = objE.PSalarioSemanal
    '                Dim TotalEntregar2 As Double = objE.PTotalEntregar
    '                inasistencias = inasistencias - objE.PDiasLaborados
    '                ausentismos = objE.PSalarioDiario * inasistencias
    '                If RealTipo = "SALARIO" Then

    '                    grdDeducciones.Rows.Add(colaboradorID, CInt(grdDeducciones.Rows.Count + 1), colaboradorNom, objE.PDepartamento, objE.PPuesto, inasistencias, Math.Round(SalarioSemanal2).ToString("N0"), Math.Round(TotalPuntualidadAsistencia).ToString("N0"), Math.Round(TotalGratificaciones).ToString("N0"), Math.Round(ausentismos).ToString("N0"), Math.Round(TotalIMSS).ToString("N0"), Math.Round(Totalinfonavit).ToString("N0"), Math.Round(TotalPrestamo).ToString("N0"), Math.Round(TotalcajaAhorro).ToString("N0"), Math.Round(otrasDeducciones).ToString("N0"), Math.Round(TotalEntregar2).ToString("N0"))

    '                ElseIf RealTipo = "DESTAJO" Then
    '                    grdDeducciones.Rows.Add(colaboradorID, CInt(grdDeducciones.Rows.Count + 1), colaboradorNom, objE.PDepartamento, objE.PPuesto, inasistencias, Math.Round(SalarioSemanal2).ToString("N0"), Math.Round(TotalPuntualidadAsistencia).ToString("N0"), Math.Round(TotalGratificaciones).ToString("N0"), Math.Round(ausentismos).ToString("N0"), Math.Round(TotalIMSS).ToString("N0"), Math.Round(Totalinfonavit).ToString("N0"), Math.Round(TotalPrestamo).ToString("N0"), Math.Round(TotalcajaAhorro).ToString("N0"), Math.Round(otrasDeducciones).ToString("N0"), Math.Round(TotalEntregar2).ToString("N0"))
    '                ElseIf RealTipo = "POR BANDA" Then

    '                    grdDeducciones.Rows.Add(colaboradorID, CInt(grdDeducciones.Rows.Count + 1), colaboradorNom, objE.PDepartamento, objE.PPuesto, inasistencias, Math.Round(SalarioSemanal2).ToString("N0"), Math.Round(TotalPuntualidadAsistencia).ToString("N0"), Math.Round(TotalGratificaciones).ToString("N0"), Math.Round(ausentismos).ToString("N0"), Math.Round(TotalIMSS).ToString("N0"), Math.Round(Totalinfonavit).ToString("N0"), Math.Round(TotalPrestamo).ToString("N0"), Math.Round(TotalcajaAhorro).ToString("N0"), Math.Round(otrasDeducciones).ToString("N0"), Math.Round(TotalEntregar2).ToString("N0"))


    '                End If

    '            End If
    '        Next

    '        Totalausentismos2 = 0
    '        TotalPuntualidadAsistencia2 = 0
    '        TotalGratificaciones2 = 0
    '        TotalCajaAhorro2 = 0
    '        TotalIMSS2 = 0
    '        TotalInfonavit2 = 0
    '        TotalPrestamos2 = 0
    '        TotalOtrasDeducciones2 = 0
    '        TotalTotalEntregar2 = 0
    '        TotalpagoBruto = 0
    '        contadorFilas2 = 0

    '        For Each row As DataGridViewRow In grdDeducciones.Rows
    '            Totalausentismos2 += row.Cells("clmAusentismos").Value
    '            TotalPuntualidadAsistencia2 += row.Cells("clmPuntualidadAsistencia").Value
    '            TotalGratificaciones2 += row.Cells("clmGratificaciones").Value
    '            TotalCajaAhorro2 += row.Cells("clmCajaDeAhorro").Value
    '            TotalIMSS2 += row.Cells("clmIMMS").Value
    '            TotalInfonavit2 += row.Cells("clmInfonavit").Value
    '            TotalPrestamos2 += row.Cells("clmPrestamos").Value
    '            TotalOtrasDeducciones2 += row.Cells("clmOtrasDeducciones").Value
    '            TotalTotalEntregar2 += row.Cells("clmTotalEntregar").Value
    '            TotalpagoBruto += row.Cells("clmSalarioRegistrado").Value
    '            contadorFilas2 += 1
    '        Next

    '        'grdDeducciones.Rows.Add("TOTAL", "", "", "", TotalpagoBruto, TotalPuntualidadAsistencia2, TotalGratificaciones2, Totalausentismos2, TotalIMSS2, TotalInfonavit2, TotalPrestamos2, TotalCajaAhorro2, TotalOtrasDeducciones2, TotalTotalEntregar2)

    '        'grdDeducciones.Rows(contadorFilas2).DefaultCellStyle.BackColor = Color.GreenYellow


    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Private Sub grdDeducciones_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs)
    '    'el e.columnindex son las columnas que checara para ver si se pueden combinar las celdas iguales
    '    ' en este caso checara la 2
    '    If e.ColumnIndex = 1 Or e.ColumnIndex = 10 And e.RowIndex >= 0 AndAlso e.RowIndex >= 0 Then
    '        Try

    '            Using gridBrush As Brush = New SolidBrush(Me.grdDeducciones.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

    '                Using gridLinePen As Pen = New Pen(gridBrush)

    '                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

    '                    If grdDeducciones.Rows(e.RowIndex).Cells("clmIDcolaborador").Value.ToString("N0") = grdDeducciones.Rows(e.RowIndex + 1).Cells("clmIDcolaborador").Value.ToString("N0") Then

    '                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

    '                    Else
    '                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)
    '                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)

    '                    End If

    '                    If Not e.Value Is Nothing Then

    '                        If e.RowIndex > 0 AndAlso grdDeducciones.Rows(e.RowIndex).Cells("clmIDcolaborador").Value.ToString("N0") <> grdDeducciones.Rows(e.RowIndex + 1).Cells("clmIDcolaborador").Value.ToString("N0") Then
    '                            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
    '                        Else

    '                        End If

    '                    End If

    '                    e.Handled = True

    '                End Using

    '            End Using
    '        Catch ex As Exception

    '        End Try

    '    End If


    '    If e.ColumnIndex = 4 Or e.ColumnIndex = 5 And e.RowIndex >= 0 AndAlso e.RowIndex >= 0 Then
    '        Try
    '            Using gridBrush As Brush = New SolidBrush(Me.grdDeducciones.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

    '                Using gridLinePen As Pen = New Pen(gridBrush)

    '                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

    '                    If grdDeducciones.Rows(e.RowIndex).Cells("clmIDcolaborador").Value.ToString("N0") = grdDeducciones.Rows(e.RowIndex + 1).Cells("clmIDcolaborador").Value.ToString("N0") Then

    '                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)
    '                    Else
    '                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)
    '                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)

    '                    End If

    '                    If Not e.Value Is Nothing Then

    '                        If e.RowIndex > 0 AndAlso grdDeducciones.Rows(e.RowIndex).Cells("clmIDcolaborador").Value.ToString("N0") <> grdDeducciones.Rows(e.RowIndex + 1).Cells("clmIDcolaborador").Value.ToString("N0") Then
    '                            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
    '                        Else

    '                        End If

    '                    End If

    '                    e.Handled = True

    '                End Using

    '            End Using
    '        Catch ex As Exception

    '        End Try

    '    End If

    '    If e.ColumnIndex = 3 And e.RowIndex >= 0 AndAlso e.RowIndex >= 0 Then
    '        Try
    '            Using gridBrush As Brush = New SolidBrush(Me.grdDeducciones.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

    '                Using gridLinePen As Pen = New Pen(gridBrush)

    '                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

    '                    If grdDeducciones.Rows(e.RowIndex).Cells("clmIDcolaborador").Value.ToString("N0") = grdDeducciones.Rows(e.RowIndex + 1).Cells("clmIDcolaborador").Value.ToString("N0") Then

    '                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

    '                    Else
    '                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)
    '                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)

    '                    End If

    '                    If Not e.Value Is Nothing Then

    '                        If e.RowIndex > 0 AndAlso grdDeducciones.Rows(e.RowIndex).Cells("clmIDcolaborador").Value.ToString("N0") <> grdDeducciones.Rows(e.RowIndex + 1).Cells("clmIDcolaborador").Value.ToString("N0") Then
    '                            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
    '                        Else

    '                        End If

    '                    End If

    '                    e.Handled = True

    '                End Using

    '            End Using
    '        Catch ex As Exception

    '        End Try

    '    End If

    '    If e.ColumnIndex = 2 And e.RowIndex >= 0 AndAlso e.RowIndex >= 0 Then
    '        Try

    '            Using gridBrush As Brush = New SolidBrush(Me.grdDeducciones.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

    '                Using gridLinePen As Pen = New Pen(gridBrush)

    '                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

    '                    If grdDeducciones.Rows(e.RowIndex).Cells("clmIDcolaborador").Value.ToString("N0") = grdDeducciones.Rows(e.RowIndex + 1).Cells("clmIDcolaborador").Value.ToString("N0") Then

    '                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

    '                    Else
    '                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)
    '                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)

    '                    End If

    '                    If Not e.Value Is Nothing Then

    '                        If e.RowIndex > 0 AndAlso grdDeducciones.Rows(e.RowIndex).Cells("clmIDcolaborador").Value.ToString("N0") <> grdDeducciones.Rows(e.RowIndex + 1).Cells("clmIDcolaborador").Value.ToString("N0") Then
    '                            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
    '                        Else

    '                        End If

    '                    End If

    '                    e.Handled = True

    '                End Using

    '            End Using
    '        Catch ex As Exception

    '        End Try
    '    End If
    'End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 128
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        ContextMenuStrip1.Show(btnReporte, 0, btnReporte.Height)
        'Try
        '    If cmbNave.SelectedIndex > 0 Then



        '        Dim listaCorteNominaa As New List(Of Entidades.CalcularNominaReal)
        '        Dim nomina As New Nomina.Negocios.CalcularNominaRealBU

        '        listaCorteNominaa = nomina.ListaCorteNomina(cmbNave.SelectedValue, cmbPeriodoNomina.SelectedValue, txtColaborador.Text)
        '        AgregarFilaColaboradoresNominaRealIMPRIMIR(listaCorteNominaa)

        '        Dim ds As New ListaCorteNominaDS
        '        Dim ObjDS As New ListaCorteNominaDS
        '        ds.Tables.Add("grdDeducciones")


        '        ''Se agregan las columnas
        '        Dim col As System.Data.DataColumn
        '        For Each dgvCol As DataGridViewColumn In Me.grdDeducciones.Columns
        '            col = New System.Data.DataColumn(dgvCol.Name)
        '            ds.Tables("grdDeducciones").Columns.Add(col)
        '        Next

        '        ''SE agregan las filas
        '        Dim row As System.Data.DataRow
        '        '' Dim colcount As Integer = Me.grdDeducciones.Columns.Count - 1

        '        For i As Integer = 0 To Me.grdDeducciones.Rows.Count - 1
        '            row = ds.Tables("grdDeducciones").Rows.Add
        '            For Each column As DataGridViewColumn In Me.grdDeducciones.Columns


        '                row.Item(column.Index) = Me.grdDeducciones.Rows.Item(i).Cells(column.Index).Value
        '            Next
        '        Next



        '        ''Se indica el tipo de parametro
        '        ''En este caso de tipo numerico

        '        'Colaborador.ParameterValueType = ParameterValueKind.StringParameter
        '        'IdNave.ParameterValueType = ParameterValueKind.NumberParameter
        '        'PeriodoNominaID.ParameterValueType = ParameterValueKind.NumberParameter

        '        PeriodoNomina.ParameterValueType = ParameterValueKind.StringParameter
        '        ruta.ParameterValueType = ParameterValueKind.StringParameter
        '        UserName.ParameterValueType = ParameterValueKind.StringParameter
        '        NombreArchivo.ParameterValueType = ParameterValueKind.StringParameter
        '        Nave.ParameterValueType = ParameterValueKind.StringParameter

        '        TotalpagoBruto3.ParameterValueType = ParameterValueKind.StringParameter
        '        TotalPuntualidadAsistencia3.ParameterValueType = ParameterValueKind.StringParameter
        '        TotalGratificaciones3.ParameterValueType = ParameterValueKind.StringParameter
        '        Totalausentismos3.ParameterValueType = ParameterValueKind.StringParameter
        '        TotalIMSS3.ParameterValueType = ParameterValueKind.StringParameter
        '        TotalInfonavit3.ParameterValueType = ParameterValueKind.StringParameter
        '        TotalPrestamos3.ParameterValueType = ParameterValueKind.StringParameter
        '        TotalCajaAhorro3.ParameterValueType = ParameterValueKind.StringParameter
        '        TotalOtrasDeducciones3.ParameterValueType = ParameterValueKind.StringParameter
        '        TotalTotalEntregar3.ParameterValueType = ParameterValueKind.StringParameter



        '        ''Se indica el nombre del parametro
        '        ''del procedimiento almacenado
        '        'Colaborador.ParameterFieldName = "@Colaborador"
        '        'IdNave.ParameterFieldName = "@NaveID"
        '        'PeriodoNominaID.ParameterFieldName = "@PeriodoNominaID"

        '        PeriodoNomina.ParameterFieldName = "PeriodoNomina"
        '        ruta.ParameterFieldName = "ruta"
        '        UserName.ParameterFieldName = "Usuario"
        '        NombreArchivo.ParameterFieldName = "NombreReporte"
        '        Nave.ParameterFieldName = "Nave"

        '        TotalpagoBruto3.ParameterFieldName = "TotalPagoBruto"
        '        TotalPuntualidadAsistencia3.ParameterFieldName = "TotalExtras"
        '        TotalGratificaciones3.ParameterFieldName = "TotalGratificaciones"
        '        Totalausentismos3.ParameterFieldName = "TotalAusentismos"
        '        TotalIMSS3.ParameterFieldName = "TotalIMSS"
        '        TotalInfonavit3.ParameterFieldName = "TotalInfonavit"
        '        TotalPrestamos3.ParameterFieldName = "TotalPrestamos"
        '        TotalCajaAhorro3.ParameterFieldName = "TotalCajaDeAhorro"
        '        TotalOtrasDeducciones3.ParameterFieldName = "TotalOtrasDeducciones"
        '        TotalTotalEntregar3.ParameterFieldName = "TotalTotalEntregar"


        '        ''Se indica el valor que va a tomar el parametro   
        '        'myDiscreteValueIdNave.Value = Convert.ToInt32(cmbNave.SelectedValue)
        '        'myDiscreteValuePeriodoNominaID.Value = Convert.ToInt32(cmbPeriodoNomina.SelectedValue)
        '        'myDiscreteValueColaborador.Value = txtColaborador.Text
        '        Dim fila As DataRowView
        '        fila = cmbPeriodoNomina.SelectedItem


        '        myDiscreteValuePeriodoNomina.Value = fila("pnom_concepto")
        '        myDiscreteValueUserName.Value = Convert.ToString(Entidades.SesionUsuario.UsuarioSesion.PUserUsername)
        '        myDiscreteValueNombreArchivo.Value = Convert.ToString("ReporteNominaReal.rpt")

        '        myDiscreteValueTotalPuntualidadAsistencia3.Value = Convert.ToString(TotalPuntualidadAsistencia2.ToString("N0"))
        '        myDiscreteValueTotalGratificaciones3.Value = Convert.ToString(TotalGratificaciones2.ToString("N0"))
        '        myDiscreteValueTotalCajaAhorro3.Value = Convert.ToString(TotalCajaAhorro2.ToString("N0"))
        '        myDiscreteValueTotalIMSS3.Value = Convert.ToString(TotalIMSS2.ToString("N0"))
        '        myDiscreteValueTotalInfonavit3.Value = Convert.ToString(TotalInfonavit2.ToString("N0"))
        '        myDiscreteValueTotalPrestamos3.Value = Convert.ToString(TotalPrestamos2.ToString("N0"))
        '        myDiscreteValueTotalOtrasDeducciones3.Value = Convert.ToString(TotalOtrasDeducciones2.ToString("N0"))
        '        myDiscreteValueTotalTotalEntregar3.Value = Convert.ToString(TotalTotalEntregar2.ToString("N0"))
        '        myDiscreteValueTotalausentismos3.Value = Convert.ToString(Totalausentismos2.ToString("N0"))
        '        myDiscreteValueTotalpagoBruto3.Value = Convert.ToString(TotalpagoBruto.ToString("N0"))




        '        ''Se indica el valor que va a tomar el parametro   

        '        If cmbNave.SelectedValue = 2 Then
        '            '   myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/YUYIN.JPG")
        '            ' myDiscreteValueNave.Value = Convert.ToString("YUYIN")

        '        ElseIf cmbNave.SelectedValue = 3 Then
        '            myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/JEANS.JPG")
        '            myDiscreteValueNave.Value = Convert.ToString("JEANS")

        '        ElseIf cmbNave.SelectedValue = 4 Then
        '            myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/MERANO.JPG")
        '            ''myDiscreteValueNave.Value = Convert.ToString("MERANO")
        '            ' '
        '        ElseIf cmbNave.SelectedValue = 5 Then
        '            '   myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/JEANS2.JPG")
        '            '   myDiscreteValueNave.Value = Convert.ToString("JEANS2")

        '        ElseIf cmbNave.SelectedValue = 43 Then
        '            '  myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/GRUPOYUYIN.JPG")
        '            '       myDiscreteValueNave.Value = Convert.ToString("COMERCIALIZADORA")
        '        End If
        '        myDiscreteValueNave.Value = Convert.ToString("")
        '        myDiscreteValueRuta.Value = ("")
        '        ''Se asigna el valor del parametro '@Colaborador  '@NaveID   '@PeriodoNominaID 
        '        'Colaborador.CurrentValues.Add(myDiscreteValueColaborador)
        '        'IdNave.CurrentValues.Add(myDiscreteValueIdNave)
        '        'PeriodoNominaID.CurrentValues.Add(myDiscreteValuePeriodoNominaID)

        '        PeriodoNomina.CurrentValues.Add(myDiscreteValuePeriodoNomina)
        '        UserName.CurrentValues.Add(myDiscreteValueUserName)
        '        NombreArchivo.CurrentValues.Add(myDiscreteValueNombreArchivo)
        '        Nave.CurrentValues.Add(myDiscreteValueNave)
        '        ruta.CurrentValues.Add(myDiscreteValueRuta)


        '        TotalpagoBruto3.CurrentValues.Add(myDiscreteValueTotalpagoBruto3)
        '        TotalPuntualidadAsistencia3.CurrentValues.Add(myDiscreteValueTotalPuntualidadAsistencia3)
        '        TotalGratificaciones3.CurrentValues.Add(myDiscreteValueTotalGratificaciones3)
        '        Totalausentismos3.CurrentValues.Add(myDiscreteValueTotalausentismos3)
        '        TotalIMSS3.CurrentValues.Add(myDiscreteValueTotalIMSS3)
        '        TotalInfonavit3.CurrentValues.Add(myDiscreteValueTotalInfonavit3)
        '        TotalPrestamos3.CurrentValues.Add(myDiscreteValueTotalPrestamos3)
        '        TotalCajaAhorro3.CurrentValues.Add(myDiscreteValueTotalCajaAhorro3)
        '        TotalOtrasDeducciones3.CurrentValues.Add(myDiscreteValueTotalOtrasDeducciones3)
        '        TotalTotalEntregar3.CurrentValues.Add(myDiscreteValueTotalTotalEntregar3)


        '        ''Se asigna el valor a la variable que se enlazsa al reporte
        '        'Parametros.Add(Colaborador)
        '        'Parametros.Add(IdNave)
        '        'Parametros.Add(PeriodoNominaID)

        '        Parametros.Add(PeriodoNomina)
        '        Parametros.Add(ruta)
        '        Parametros.Add(UserName)
        '        Parametros.Add(NombreArchivo)
        '        Parametros.Add(Nave)


        '        Parametros.Add(TotalpagoBruto3)
        '        Parametros.Add(TotalPuntualidadAsistencia3)
        '        Parametros.Add(TotalGratificaciones3)
        '        Parametros.Add(Totalausentismos3)
        '        Parametros.Add(TotalIMSS3)
        '        Parametros.Add(TotalInfonavit3)
        '        Parametros.Add(TotalPrestamos3)
        '        Parametros.Add(TotalCajaAhorro3)
        '        Parametros.Add(TotalOtrasDeducciones3)
        '        Parametros.Add(TotalTotalEntregar3)


        '        Dim Report As New ReporteListaNomina
        '        Dim VisorReporte As New VisorReportesEnTablas

        '        Report.SetDataSource(ds.Tables("grdDeducciones"))
        '        VisorReporte.ReporteViewer.ReportSource = Report
        '        VisorReporte.ReporteViewer.ParameterFieldInfo = Parametros
        '        VisorReporte.Show()


        '        listaCorteNominaa = nomina.ListaCorteNomina(cmbNave.SelectedValue, cmbPeriodoNomina.SelectedValue, txtColaborador.Text)
        '        AgregarFilaColaboradoresNominaReal(listaCorteNominaa)
        '    End If
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub txtColaborador_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtColaborador.KeyPress
        ''SOLO LETRAS
        Dim caracter As Char = e.KeyChar
        If (Char.IsLetter(caracter)) Or (caracter = ChrW(Keys.Back)) Or (Char.IsSeparator(caracter)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        grdDeducciones.Rows.Clear()
        txtColaborador.Text = ""
    End Sub


    Private Sub ImprimirReporteGeneralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirReporteGeneralToolStripMenuItem.Click
        Dim contadorfilas As Integer = 0
        For Each dato As DataGridViewRow In grdDeducciones.Rows
            contadorfilas += 1
            Exit For
        Next

        If contadorfilas > 0 Then


            Try
                If cmbNave.SelectedIndex > 0 Then



                    Dim listaCorteNominaa As New List(Of Entidades.CalcularNominaReal)
                    Dim nomina As New Nomina.Negocios.CalcularNominaRealBU

                    listaCorteNominaa = nomina.ListaCorteNomina(cmbNave.SelectedValue, cmbPeriodoNomina.SelectedValue, txtColaborador.Text, "")
                    AgregarFilaColaboradoresNominaRealIMPRIMIR(listaCorteNominaa)

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
                    '' Dim colcount As Integer = Me.grdDeducciones.Columns.Count - 1

                    For i As Integer = 0 To Me.grdDeducciones.Rows.Count - 1
                        row = ds.Tables("grdDeducciones").Rows.Add
                        For Each column As DataGridViewColumn In Me.grdDeducciones.Columns


                            row.Item(column.Index) = Me.grdDeducciones.Rows.Item(i).Cells(column.Index).Value
                        Next
                    Next



                    ''Se indica el tipo de parametro
                    ''En este caso de tipo numerico

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
                    Dim fila As DataRowView
                    fila = cmbPeriodoNomina.SelectedItem


                    myDiscreteValuePeriodoNomina.Value = fila("pnom_concepto")
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
                        '   myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/YUYIN.JPG")
                        ' myDiscreteValueNave.Value = Convert.ToString("YUYIN")

                    ElseIf cmbNave.SelectedValue = 3 Then
                        myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/JEANS.JPG")
                        myDiscreteValueNave.Value = Convert.ToString("JEANS")

                    ElseIf cmbNave.SelectedValue = 4 Then
                        myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/MERANO.JPG")
                        ''myDiscreteValueNave.Value = Convert.ToString("MERANO")
                        ' '
                    ElseIf cmbNave.SelectedValue = 5 Then
                        '   myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/JEANS2.JPG")
                        '   myDiscreteValueNave.Value = Convert.ToString("JEANS2")

                    ElseIf cmbNave.SelectedValue = 43 Then
                        '  myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/GRUPOYUYIN.JPG")
                        '       myDiscreteValueNave.Value = Convert.ToString("COMERCIALIZADORA")
                    End If
                    myDiscreteValueNave.Value = Convert.ToString("")
                    myDiscreteValueRuta.Value = ("")
                    ''Se asigna el valor del parametro '@Colaborador  '@NaveID   '@PeriodoNominaID 


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


                    listaCorteNominaa = nomina.ListaCorteNomina(cmbNave.SelectedValue, cmbPeriodoNomina.SelectedValue, txtColaborador.Text, "")
                    AgregarFilaColaboradoresNominaReal(listaCorteNominaa)


                    Me.Cursor = Cursors.Default

                End If
            Catch ex As Exception

            End Try

        End If


    End Sub

    Private Sub ImprimirReporteEfectivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirReporteEfectivoToolStripMenuItem.Click
        Dim contadorfilas As Integer = 0
        For Each dato As DataGridViewRow In grdDeducciones.Rows
            contadorfilas += 1
            Exit For
        Next

        If contadorfilas > 0 Then


            Try
                If cmbNave.SelectedIndex > 0 Then



                    Dim listaCorteNominaa As New List(Of Entidades.CalcularNominaReal)
                    Dim nomina As New Nomina.Negocios.CalcularNominaRealBU

                    listaCorteNominaa = nomina.ListaCorteNomina(cmbNave.SelectedValue, cmbPeriodoNomina.SelectedValue, txtColaborador.Text, "EFECTIVO")
                    AgregarFilaColaboradoresNominaRealIMPRIMIR(listaCorteNominaa)

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
                    '' Dim colcount As Integer = Me.grdDeducciones.Columns.Count - 1

                    For i As Integer = 0 To Me.grdDeducciones.Rows.Count - 1
                        row = ds.Tables("grdDeducciones").Rows.Add
                        For Each column As DataGridViewColumn In Me.grdDeducciones.Columns


                            row.Item(column.Index) = Me.grdDeducciones.Rows.Item(i).Cells(column.Index).Value
                        Next
                    Next



                    ''Se indica el tipo de parametro
                    ''En este caso de tipo numerico

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
                    Dim fila As DataRowView
                    fila = cmbPeriodoNomina.SelectedItem


                    myDiscreteValuePeriodoNomina.Value = fila("pnom_concepto")
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
                        '   myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/YUYIN.JPG")
                        ' myDiscreteValueNave.Value = Convert.ToString("YUYIN")

                    ElseIf cmbNave.SelectedValue = 3 Then
                        myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/JEANS.JPG")
                        myDiscreteValueNave.Value = Convert.ToString("JEANS")

                    ElseIf cmbNave.SelectedValue = 4 Then
                        myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/MERANO.JPG")
                        ''myDiscreteValueNave.Value = Convert.ToString("MERANO")
                        ' '
                    ElseIf cmbNave.SelectedValue = 5 Then
                        '   myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/JEANS2.JPG")
                        '   myDiscreteValueNave.Value = Convert.ToString("JEANS2")

                    ElseIf cmbNave.SelectedValue = 43 Then
                        '  myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/GRUPOYUYIN.JPG")
                        '       myDiscreteValueNave.Value = Convert.ToString("COMERCIALIZADORA")
                    End If


                    myDiscreteValueRuta.Value = ("EFECTIVO")
                    myDiscreteValueNave.Value = Convert.ToString("EFECTIVO")


                    ''Se asigna el valor del parametro '@Colaborador  '@NaveID   '@PeriodoNominaID 


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

                    accionSemana.ParameterFieldName = "semana"

                    Dim itemPeriodo As Object = ""
                    If cmbPeriodoNomina.SelectedIndex > 0 Then
                        itemPeriodo = cmbPeriodoNomina.SelectedItem
                    End If

                    valorAsignadoAccionEfectivo.Value = "Semana " + itemPeriodo("pnom_NoSemanaNomina").ToString
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


                    listaCorteNominaa = nomina.ListaCorteNomina(cmbNave.SelectedValue, cmbPeriodoNomina.SelectedValue, txtColaborador.Text, "")
                    AgregarFilaColaboradoresNominaReal(listaCorteNominaa)


                    Me.Cursor = Cursors.Default

                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ImprimirReporteDepósitoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirReporteDepósitoToolStripMenuItem.Click
        Dim contadorfilas As Integer = 0
        For Each dato As DataGridViewRow In grdDeducciones.Rows
            contadorfilas += 1
            Exit For
        Next

        If contadorfilas > 0 Then


            Try
                If cmbNave.SelectedIndex > 0 Then



                    Dim listaCorteNominaa As New List(Of Entidades.CalcularNominaReal)
                    Dim nomina As New Nomina.Negocios.CalcularNominaRealBU

                    listaCorteNominaa = nomina.ListaCorteNomina(cmbNave.SelectedValue, cmbPeriodoNomina.SelectedValue, txtColaborador.Text, "DEPOSITO")
                    AgregarFilaColaboradoresNominaRealIMPRIMIR(listaCorteNominaa)

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
                    '' Dim colcount As Integer = Me.grdDeducciones.Columns.Count - 1

                    For i As Integer = 0 To Me.grdDeducciones.Rows.Count - 1
                        row = ds.Tables("grdDeducciones").Rows.Add
                        For Each column As DataGridViewColumn In Me.grdDeducciones.Columns


                            row.Item(column.Index) = Me.grdDeducciones.Rows.Item(i).Cells(column.Index).Value
                        Next
                    Next



                    ''Se indica el tipo de parametro
                    ''En este caso de tipo numerico

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
                    Dim fila As DataRowView
                    fila = cmbPeriodoNomina.SelectedItem


                    myDiscreteValuePeriodoNomina.Value = fila("pnom_concepto")
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
                        '   myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/YUYIN.JPG")
                        ' myDiscreteValueNave.Value = Convert.ToString("YUYIN")

                    ElseIf cmbNave.SelectedValue = 3 Then
                        myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/JEANS.JPG")
                        myDiscreteValueNave.Value = Convert.ToString("JEANS")

                    ElseIf cmbNave.SelectedValue = 4 Then
                        myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/MERANO.JPG")
                        ''myDiscreteValueNave.Value = Convert.ToString("MERANO")
                        ' '
                    ElseIf cmbNave.SelectedValue = 5 Then
                        '   myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/JEANS2.JPG")
                        '   myDiscreteValueNave.Value = Convert.ToString("JEANS2")

                    ElseIf cmbNave.SelectedValue = 43 Then
                        '  myDiscreteValueRuta.Value = (rutaPublica & "LOGOTIPOS/GRUPOYUYIN.JPG")
                        '       myDiscreteValueNave.Value = Convert.ToString("COMERCIALIZADORA")
                    End If
                    myDiscreteValueNave.Value = Convert.ToString("DEPOSITO")
                    myDiscreteValueRuta.Value = ("DEPOSITO")
                    ''Se asigna el valor del parametro '@Colaborador  '@NaveID   '@PeriodoNominaID 


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
                    Dim itemPeriodo As Object = ""
                    If cmbPeriodoNomina.SelectedIndex > 0 Then
                        itemPeriodo = cmbPeriodoNomina.SelectedItem
                    End If
                    valorAsignadoAccionEfectivo.Value = "Semana " + itemPeriodo("pnom_NoSemanaNomina").ToString
                    accionSemana.CurrentValues.Add(valorAsignadoAccionEfectivo)

                    ''Se asigna el valor a la variable que se enlazsa al reporte


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


                    listaCorteNominaa = nomina.ListaCorteNomina(cmbNave.SelectedValue, cmbPeriodoNomina.SelectedValue, txtColaborador.Text, "")
                    AgregarFilaColaboradoresNominaReal(listaCorteNominaa)


                    Me.Cursor = Cursors.Default

                End If
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub btnCncelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub


    Private Sub ImprimirRecibosDeNóminaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirRecibosDeNóminaToolStripMenuItem.Click
        Try



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
                Dim consecutivo = 1
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
                        Dim descripcion As String = ""
                        'NUMRECIBO




                        TotalIngresos = CDbl(row.Cells("clmSalarioRegistrado").Value) + CDbl(row.Cells("clmPuntualidadAsistencia").Value) + CDbl(row.Cells("clmGratificaciones").Value)
                        TotalDeducciones = CDbl(row.Cells("clmAusentismos").Value) + CDbl(row.Cells("clmIMMS").Value) + CDbl(row.Cells("clmInfonavit").Value) + CDbl(row.Cells("clmCajaDeAhorro").Value) + CDbl(row.Cells("clmPrestamos").Value) + CDbl(row.Cells("clmOtrasDeducciones").Value)
                        PagoNeto = TotalIngresos - TotalDeducciones
                        Recibos.Rows.Add(
                            consecutivo,
                            row.Cells("clmColaborador").Value,
                            fechaFin.ToShortDateString,
                            fechaInicio.ToShortDateString,
                            fechaFin.ToShortDateString,
                            CDbl(row.Cells("clmSalarioRegistrado").Value),
                            CDbl(row.Cells("clmPuntualidadAsistencia").Value),
                            CDbl(row.Cells("clmGratificaciones").Value),
                            row.Cells("clmDiasTrabajados").Value,
                            CDbl(row.Cells("clmAusentismos").Value),
                            (CDbl(row.Cells("clmIMMS").Value) + CDbl(row.Cells("clmInfonavit").Value) - CDbl(row.Cells("clmISR").Value)),
                            CDbl(row.Cells("clmCajaDeAhorro").Value),
                            (CDbl(row.Cells("clmPrestamos").Value) + CDbl(row.Cells("clmOtrasDeducciones").Value)),
                            TotalIngresos,
                            TotalDeducciones,
                            PagoNeto,
                            CDbl(row.Cells("clmISR").Value),
                            naveSICYID,
                            row.Cells("clmDescGratificaciones").Value,
                            datoConsEnviar,
                            NUMRECIBO
                            )
                        consecutivo = consecutivo + 1
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
                reporte.Compile()
                reporte("DiaFestivo") = ""
                reporte.RegData(Recibos)
                reporte.Show()
                Me.Cursor = Cursors.Default

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbPeriodoNomina_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPeriodoNomina.DropDownClosed
        FechasSemanaNomina()

    End Sub

    Public Sub FechasSemanaNomina()

        Dim objBu As New Negocios.CorteNominaRealBU
        Dim tabla As New DataTable
        tabla = objBu.obtenerNaveIDsicy(cmbNave.SelectedValue)
        If tabla.Rows.Count > 0 Then
            naveSICYID = tabla.Rows(0).Item("nave_navesicyid")
        End If

        Dim SemanaNominaActiva As New List(Of Entidades.CobranzaPrestamos)
        Dim SenamaActivaBu As New Nomina.Negocios.CobranzaPrestamosBU

        If Not IsDBNull(cmbPeriodoNomina.SelectedValue) Then
            SemanaNominaActiva = SenamaActivaBu.FechasSemanaNomina(cmbPeriodoNomina.SelectedValue)
        End If

        For Each objeto As Entidades.CobranzaPrestamos In SemanaNominaActiva
            fechaInicio = objeto.PfechaInicioNomina
            fechaFin = objeto.PfechaFinNomina
        Next
    End Sub

    Private Sub ImprimirSobreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirSobreToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim listaCorteNominaa As New List(Of Entidades.CalcularNominaReal)
            Dim nomina As New Nomina.Negocios.CalcularNominaRealBU
            ImprimirReciboDiaFestivoToolStripMenuItem.Enabled = True
            ImprimirSobreToolStripMenuItem.Enabled = True
            listaCorteNominaa = nomina.ListaCorteNomina(cmbNave.SelectedValue, cmbPeriodoNomina.SelectedValue, txtColaborador.Text, "EFECTIVO")
            AgregarFilaColaboradoresNominaReal(listaCorteNominaa)



            Dim contador As Integer = 0
            For Each row As DataGridViewRow In grdDeducciones.Rows
                If row.Cells("clmTipoSueldo").Value = "EFECTIVO" Then
                    contador += 1
                    Exit For
                End If

            Next

            If contador > 0 Then
                ImprimirSobreToolStripMenuItem.Enabled = True
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
                ImprimirSobreToolStripMenuItem.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub grdDeducciones_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdDeducciones.CellClick
        If e.RowIndex >= 0 And e.RowIndex < grdDeducciones.RowCount - 1 Then
            ColaboradorID = grdDeducciones.Rows(e.RowIndex).Cells("clmIDcolaborador").Value
            colaboradorNombre = grdDeducciones.Rows(e.RowIndex).Cells("clmColaborador").Value
        End If

    End Sub

    Private Sub ImprimirReciboDiaFestivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirReciboDiaFestivoToolStripMenuItem.Click
        Try


            Me.Cursor = Cursors.WaitCursor
            Dim listaCorteNominaa As New List(Of Entidades.CalcularNominaReal)
            Dim nomina As New Nomina.Negocios.CalcularNominaRealBU
            ImprimirReciboDiaFestivoToolStripMenuItem.Enabled = True
            ImprimirSobreToolStripMenuItem.Enabled = True

            If grdDeducciones.Rows.Count = 0 Then
                listaCorteNominaa = nomina.ListaCorteNomina(cmbNave.SelectedValue, cmbPeriodoNomina.SelectedValue, txtColaborador.Text, "")
                AgregarFilaColaboradoresNominaReal(listaCorteNominaa)
            End If



            ImprimirReciboDiaFestivoToolStripMenuItem.Enabled = True
            Dim ObjDate As New DateForm
            Dim Fecha As DateTime
            Dim diaFestivo As String = ""
            With ObjDate
                .mensaje = "SELECCIONAR EL DIA A PAGAR."
                .ShowDialog()
                Fecha = .Dia
            End With

            Dim recibosF = New DataTable("Recibos")
            With recibosF
                .Columns.Add("Fecha")
                .Columns.Add("Colaborador")

            End With

            For Each row As DataGridViewRow In grdDeducciones.Rows
                If row.Cells("clmColaborador").Value.ToString <> "" Then
                    recibosF.Rows.Add(Fecha.ToLongDateString.ToUpper, row.Cells("clmColaborador").Value)
                End If
            Next
            diaFestivo = recibosF.Rows(0).Item("Fecha").ToString


            'Dim OBJBU As New Framework.Negocios.ReportesBU
            'Dim EntidadReporte As Entidades.Reportes
            'EntidadReporte = OBJBU.LeerReporteporClave("NOM_RECB_DFEST")
            'Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            '    EntidadReporte.Pnombre + ".mrt"
            'My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            'Dim reporte As New StiReport
            'reporte.Load(archivo)
            'reporte.Compile()
            'reporte.RegData(recibos)
            'reporte.Show()
            'Me.Cursor = Cursors.Default


            ''cambio recibos de pago
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
                Dim consecutivo = 1
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
                        Dim descripcion As String = ""
                        'NUMRECIBO




                        TotalIngresos = CDbl(row.Cells("clmSalarioRegistrado").Value) + CDbl(row.Cells("clmPuntualidadAsistencia").Value) + CDbl(row.Cells("clmGratificaciones").Value)
                        TotalDeducciones = CDbl(row.Cells("clmAusentismos").Value) + CDbl(row.Cells("clmIMMS").Value) + CDbl(row.Cells("clmInfonavit").Value) + CDbl(row.Cells("clmCajaDeAhorro").Value) + CDbl(row.Cells("clmPrestamos").Value) + CDbl(row.Cells("clmOtrasDeducciones").Value)
                        PagoNeto = TotalIngresos - TotalDeducciones
                        Recibos.Rows.Add(
                            consecutivo,
                            row.Cells("clmColaborador").Value,
                            fechaFin.ToShortDateString,
                            fechaInicio.ToShortDateString,
                            fechaFin.ToShortDateString,
                            CDbl(row.Cells("clmSalarioRegistrado").Value),
                            CDbl(row.Cells("clmPuntualidadAsistencia").Value),
                            CDbl(row.Cells("clmGratificaciones").Value),
                            row.Cells("clmDiasTrabajados").Value,
                            CDbl(row.Cells("clmAusentismos").Value),
                            (CDbl(row.Cells("clmIMMS").Value) + CDbl(row.Cells("clmInfonavit").Value) - CDbl(row.Cells("clmISR").Value)),
                            CDbl(row.Cells("clmCajaDeAhorro").Value),
                            (CDbl(row.Cells("clmPrestamos").Value) + CDbl(row.Cells("clmOtrasDeducciones").Value)),
                            TotalIngresos,
                            TotalDeducciones,
                            PagoNeto,
                            CDbl(row.Cells("clmISR").Value),
                            naveSICYID,
                            row.Cells("clmDescGratificaciones").Value,
                            datoConsEnviar,
                            NUMRECIBO
                            )
                        consecutivo = consecutivo + 1
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
                reporte.Compile()
                reporte("DiaFestivo") = "* RECIBI PAGO DE DIA FESTIVO CORRESPONDIENTE AL " & diaFestivo
                reporte.RegData(Recibos)
                reporte.Show()
                Me.Cursor = Cursors.Default

            End If




        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImprimirResumenDeNóminaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirResumenDeNóminaToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim listaCorteNominaa As New List(Of Entidades.CalcularNominaReal)
            Dim nomina As New Nomina.Negocios.CalcularNominaRealBU
            Dim totalNominaFiscal As Double = 0

            ImprimirReciboDiaFestivoToolStripMenuItem.Enabled = True
            ImprimirSobreToolStripMenuItem.Enabled = True
            listaCorteNominaa = nomina.ListaCorteNomina(cmbNave.SelectedValue, cmbPeriodoNomina.SelectedValue, txtColaborador.Text, "")
            AgregarFilaColaboradoresNominaReal(listaCorteNominaa)

            totalNominaFiscal = nomina.ConsultaTotalNominaFiscal(CInt(cmbPeriodoNomina.SelectedValue))

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

                For Each fila As DataGridViewRow In grdDeducciones.Rows
                    If fila.Cells("clmTipoSueldo").Value = "DEPOSITO" Then
                        PagoBruto += fila.Cells("clmSalarioRegistrado").Value
                        Extras += fila.Cells("clmPuntualidadAsistencia").Value
                        Otros += fila.Cells("clmGratificaciones").Value
                        Ausentismos += fila.Cells("clmAusentismos").Value
                        Seguro += CDbl(fila.Cells("clmIMMS").Value) + CDbl(fila.Cells("clmInfonavit").Value)
                        Prestamos += CDbl(fila.Cells("clmPrestamos").Value) + CDbl(fila.Cells("clmOtrasDeducciones").Value)
                        CajaAhorro += fila.Cells("clmCajaDeAhorro").Value
                    End If
                Next
                'TotalPercepciones = PagoBruto + Extras + Otros - Ausentismos
                TotalPercepciones = PagoBruto + Extras + Otros - Ausentismos - Seguro
                'TotalDeducciones = Seguro + Prestamos + CajaAhorro
                TotalDeducciones = Prestamos + CajaAhorro
                PagoNeto = TotalPercepciones - TotalDeducciones
                Deposito.Rows.Add(PagoBruto, Extras, Otros, Ausentismos, Seguro, Prestamos, CajaAhorro, PagoNeto, fechaInicio.ToLongDateString.ToUpper, fechaFin.ToLongDateString.ToUpper, TotalPercepciones, TotalDeducciones)

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
                        Seguro += CDbl(fila.Cells("clmIMMS").Value) + CDbl(fila.Cells("clmInfonavit").Value)
                        Prestamos += CDbl(fila.Cells("clmPrestamos").Value) + CDbl(fila.Cells("clmOtrasDeducciones").Value)
                        CajaAhorro += fila.Cells("clmCajaDeAhorro").Value

                    End If
                Next
                'TotalPercepciones = PagoBruto + Extras + Otros - Ausentismos
                TotalPercepciones = PagoBruto + Extras + Otros - Ausentismos - Seguro
                'TotalDeducciones = Seguro + Prestamos + CajaAhorro
                TotalDeducciones = Prestamos + CajaAhorro
                PagoNeto = TotalPercepciones - TotalDeducciones
                Efectivo.Rows.Add(PagoBruto, Extras, Otros, Ausentismos, Seguro, Prestamos, CajaAhorro, PagoNeto, fechaInicio.ToLongDateString.ToUpper, fechaFin.ToLongDateString.ToUpper, TotalPercepciones, TotalDeducciones)
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
                End If

                reporte("ChequeFiscal") = totalNominaFiscal

                reporte.RegData(Resumen)
                reporte.Show()
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub ImprimirDepósitoACuentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirDepósitoACuentasToolStripMenuItem.Click

        Try



            Me.Cursor = Cursors.WaitCursor
            Dim Total As Double = 0
            Dim listaCorteNominaa As New List(Of Entidades.CalcularNominaReal)
            Dim nomina As New Nomina.Negocios.CalcularNominaRealBU
            ImprimirReciboDiaFestivoToolStripMenuItem.Enabled = True
            ImprimirSobreToolStripMenuItem.Enabled = True
            listaCorteNominaa = nomina.ListaCorteNomina(cmbNave.SelectedValue, cmbPeriodoNomina.SelectedValue, txtColaborador.Text, "")
            AgregarFilaColaboradoresNominaReal(listaCorteNominaa)

            Dim contador As Integer = 0

            For Each row As DataGridViewRow In grdDeducciones.Rows
                contador += 1
                Exit For
            Next

            If contador > 0 Then
                Dim Cuentas = New DataTable("Cuentas")
                With Cuentas
                    .Columns.Add("Numero")
                    .Columns.Add("Cuenta")
                    .Columns.Add("Titular")
                    .Columns.Add("Total")
                End With

                For Each row As DataGridViewRow In grdDeducciones.Rows
                    If row.Cells("clmTipoSueldo").Value = "DEPOSITO" Then
                        Total += row.Cells("clmTotalEntregar").Value
                        Cuentas.Rows.Add(
        row.Cells("clmcontador").Value,
        row.Cells("clmNumCuenta").Value,
        row.Cells("clmColaborador").Value,
        row.Cells("clmTotalEntregar").Value
                        )
                    End If
                Next
                Cuentas.Rows.Add("", "", "", Total.ToString("N0"))

                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("NOM_ENV_CUEN")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                reporte.RegData(Cuentas)
                reporte.Show()
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImprimirReporteGeneralAgrupadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirReporteGeneralAgrupadoToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            'Dim listaCorteNominaa As New List(Of Entidades.CalcularNominaReal)
            'Dim nomina As New Nomina.Negocios.CalcularNominaRealBU
            'ImprimirReciboDiaFestivoToolStripMenuItem.Enabled = True
            'ImprimirSobreToolStripMenuItem.Enabled = True
            'listaCorteNominaa = nomina.ListaCorteNomina(cmbNave.SelectedValue, cmbPeriodoNomina.SelectedValue, txtColaborador.Text, "")
            'AgregarFilaColaboradoresNominaReal(listaCorteNominaa)

            'Dim contador As Integer = 0
            'contador = grdDeducciones.RowCount
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
                Dim isrIMSS As Double = 0
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

                For Each fila As DataGridViewRow In grdDeducciones.Rows
                    isrIMSS = 0

                    If fila.Cells("clmColaborador").Value <> "" Then
                        If lstColaboradorIdIncapacidades.Contains(fila.Cells("clmIDcolaborador").Value) = False Then
                            isrIMSS = fila.Cells("clmInfonavit").Value + fila.Cells("clmISR").Value
                            ' se quito           'isrIMSS.ToString.Replace(",", ""), _ y se puso  fila.Cells("clmIMMS").Value.ToString.Replace(",", ""), _
                            Colaborador.Rows.Add(
                            fila.Cells("clmcontador").Value,
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
                            CInt(fila.Cells("fini_finiquitoid").Value.ToString))

                        End If

                        If lstColaboradorIdIncapacidades.Contains(fila.Cells("clmIDcolaborador").Value) Then
                                Colaborador.Rows.Add(
                            fila.Cells("clmcontador").Value,
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
                            0,
                            fila.Cells("clmdepartamentoID").Value.ToString.Replace(",", ""),
                            fila.Cells("clmSexo").Value.ToString.Replace(",", ""),
                            CInt(fila.Cells("clmOrdenPuesto").Value.ToString.Replace(",", "")),
                            CInt(fila.Cells("fini_finiquitoid").Value.ToString))
                            End If
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
                reporte("PeriodoNomina") = cmbPeriodoNomina.Text
                reporte("semana") = "Semana " + semanaPeriodo.ToString
                reporte.RegData(Resumen)
                reporte.Show()
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub cmbPeriodoNomina_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPeriodoNomina.SelectedIndexChanged
        Try

            Dim objPNom As New Negocios.ControlDePeriodoBU
            Dim entIdPeriodo As New Entidades.PeriodosNomina
            entIdPeriodo = objPNom.BuscarPeridosSeleccionados(cmbPeriodoNomina.SelectedValue)
            semanaPeriodo = entIdPeriodo.SemanaNomina
        Catch ex As Exception
            semanaPeriodo = "0"
        End Try
    End Sub

    Private Sub ImprimirReporteGeneralAgrupadoDepartamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirReporteGeneralAgrupadoDepartamentoToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If grdDeducciones.Rows.Count > 0 Then
                Dim Resumen = New DataSet("Colaboradores")
                Dim Colaborador = New DataTable("Colaborador")
                Dim Celulas = New DataTable("Celulas")
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
                Dim isrIMSS As Double = 0

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

                For Each fila As DataGridViewRow In grdDeducciones.Rows
                    isrIMSS = 0
                    If fila.Cells("clmColaborador").Value <> "" Then
                        isrIMSS = fila.Cells("clmInfonavit").Value + fila.Cells("clmISR").Value

                        Colaborador.Rows.Add(
                            fila.Cells("clmcontador").Value,
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
                            CInt(fila.Cells("fini_finiquitoid").Value.ToString))

                        If lstColaboradorIdIncapacidades.Contains(fila.Cells("clmIDcolaborador").Value) Then
                            Colaborador.Rows.Add(
                            fila.Cells("clmcontador").Value,
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
                            0,
                            fila.Cells("clmdepartamentoID").Value.ToString.Replace(",", ""),
                            fila.Cells("clmSexo").Value.ToString.Replace(",", ""),
                            CInt(fila.Cells("clmOrdenPuesto").Value.ToString.Replace(",", "")),
                            CInt(fila.Cells("fini_finiquitoid").Value.ToString))
                        End If
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
                EntidadReporte = OBJBU.LeerReporteporClave("NOM_RG_AGRUP_DEPTO")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport


                reporte.Load(archivo)
                reporte.Compile()
                reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
                reporte("PeriodoNomina") = cmbPeriodoNomina.Text
                reporte("semana") = "Semana " + semanaPeriodo.ToString
                reporte.RegData(Resumen)
                reporte.Show()
                Me.Cursor = Cursors.Default
            End If




        Catch ex As Exception

        End Try
    End Sub
End Class

