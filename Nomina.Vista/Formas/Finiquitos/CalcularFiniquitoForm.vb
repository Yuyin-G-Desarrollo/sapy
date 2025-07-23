Imports Nomina.Negocios
Imports Framework.Negocios
Imports System.Net
Imports Tools

Public Class CalcularFiniquitoForm

    Dim empleadosForm As New BuscarEmpleadoForm
    Dim dias(2) As Int32
    Dim SueldoCal As Int32
    Dim meses As Double = 0
    Dim años As Int32
    Dim diasme As Int32
    Dim IdColaborador As Int32
    Dim idnaveEmpleado As Int32
    Dim FechaUltima As New Date
    Dim FechaIniciaPeriodo As New Date
    Dim PeriodoID As New Int32
    Dim ApareceNomina As New Boolean
    Dim CostoDiario As New Double
    Dim ListaFiniquitos As New List(Of Entidades.Finiquitos)


    Private Sub CalcularFiniquitoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        lblFechaEntregaDato.Text = Date.Today.ToShortDateString
        DPFecha.Enabled = False
        txtSemana1.Visible = False
        txtSemana2.Visible = False
        txtSemana3.Visible = False
        txtSemana4.Visible = False
        lblSemanas.Visible = False
        lblSemana1.Visible = False
        lblSemana2.Visible = False
        lblSemana3.Visible = False
        lblSemana4.Visible = False

        txtMesestotal.Text = "12"
        txtMEsesVacaciones.Text = "12"

        'If PermisosUsuarioBU.ConsultarPermiso("NOM_CAL_FINI", "COLAB") Then
        '    btnBuscarEmpleado.Visible = True
        '    lblBuscarEmpleado.Visible = True
        'Else
        '    btnBuscarEmpleado.Visible = False
        '    lblBuscarEmpleado.Visible = False
        'End If

        'If PermisosUsuarioBU.ConsultarPermiso("NOM_CAL_FINI", "FINI") Then
        '    btnFiniquitar.Visible = True
        '    lblFiniquitar.Visible = True
        'Else
        '    btnFiniquitar.Visible = False
        '    lblFiniquitar.Visible = False
        'End If

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarEmpleado.Click
        empleadosForm.grdBuscarEmpleado.Rows.Clear()

        If empleadosForm.ShowDialog = DialogResult.OK Then
            '------------

            lblNomTrabajadorDato.Text = empleadosForm.txtBuscarEmpleado.Text
            lblDepartamentoDato.Text = empleadosForm.txtDepartamento.Text
            idnaveEmpleado = empleadosForm.PIdNaveEmpleado

            IdColaborador = empleadosForm.pseleccion
            empleadosForm.grdBuscarEmpleado.Rows.Clear()
            empleadosForm.grdBuscarEmpleado.Columns.Clear()
            empleadosForm.txtBuscarEmpleado.Text = ""
            DPFecha.Enabled = True

            txtSemana1.Text = ""
            txtSemana2.Text = ""
            txtSemana3.Text = ""
            txtSemana4.Text = ""
            txtAhorrro.Text = ""
            txtUtilidades.Text = ""
            txtSubtotal.Text = ""
            txtPrestamo.Text = ""
            txtJustificacion.Text = ""
            txtTotalEntregar.Text = ""
            txtAhorrro.Text = FormatNumber(0, 2)
            txtAhorrro.Text = FormatNumber(txtAhorrro.Text, 2)
            txtUtilidades.Text = FormatNumber(0, 2)
            txtPrestamo.Text = FormatNumber(0, 2)
            txtPrestamo.Text = FormatNumber(txtPrestamo.Text, 2)

            Operaciones()
            txtAhorrro_LostFocus(sender, e)
            txtPrestamo_LostFocus(sender, e)

            cmbMotivoFiniquito = Controles.ComboMotivoFiniquitos(cmbMotivoFiniquito, empleadosForm.PIdNaveEmpleado)
        End If
    End Sub


    Public Sub Operaciones()


        Dim EntidadArchivos As New Entidades.ColaboradorExpediente
        Dim ObjArchivosBU As New Negocios.EnviodeArchivosBU
        EntidadArchivos = ObjArchivosBU.CredencialColaborador(empleadosForm.pseleccion)
        Try
            'Dim SourcePicture As String = "\\192.168.2.54\YuyinERP\" + EntidadArchivos.PCarpeta + "\" + EntidadArchivos.PNombreArchivo

            Dim objFTP As New Tools.TransferenciaFTP
            'PictureBox1.Image = Image.FromFile(SourcePicture)
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
            Dim Carpeta As String = ""


            Dim tabla() As String
            tabla = Split(EntidadArchivos.PCarpeta, "\")

            For n = 0 To UBound(tabla, 1)
                Carpeta += tabla(n) + "/"
            Next

            Dim Stream As System.IO.Stream
            Stream = objFTP.StreamFile(Carpeta, EntidadArchivos.PNombreArchivo)
            PictureBox1.Image = Image.FromStream(Stream)
        Catch ex As Exception

        End Try

        '----------------Caja de Ahorro y prestamos-------------------
        Dim objCA As New CajaColaboradorBU
        Dim CantidadAhorro As Int32
        CantidadAhorro = objCA.ConsultarCajaDeAhorroSaldo(IdColaborador, idnaveEmpleado)
        txtAhorrro.Text = CantidadAhorro.ToString
        Dim objPrestamo As New FiniquitosBU
        Dim CantidadPrestamo As Int32
        CantidadPrestamo = objPrestamo.ConsultaDePrestamoparaLiquidacion(IdColaborador, idnaveEmpleado)
        Dim objDeducciones As New DeduccionesBU
        Dim cantidadDeduccion As Int32
        cantidadDeduccion = objDeducciones.ConsultaDeduccionesparaLiquidacion(IdColaborador)
        txtPrestamo.Text = CantidadPrestamo + cantidadDeduccion

        '------------------------------------------------------------


        '--------------Gratificaciones y Utilidades----------------




        '---------------------------------------------------------
        Dim DatosGenerales As New Entidades.ColaboradorNomina
        Dim objDatosGeneralesColaborador, objDatosReales, objCalcularAntiguedad, _
            objMesestrabajados, CalcularAguinaldo As New FiniquitosBU
        Dim objSueldoCal As New FiniquitosBU
        DatosGenerales = objDatosGeneralesColaborador.DatosGeneralesColaborador(empleadosForm.pseleccion)
        Dim DatosReales As New Entidades.ColaboradorReal
        DatosReales = objDatosReales.DatosRealesColaborador(empleadosForm.pseleccion)
        lblFechaIngresoDato.Text = DatosReales.PFecha
        lblPuestoDato.Text = empleadosForm.txtPuesto.Text
        dias = objCalcularAntiguedad.CalcularAntiguedad(DateDiff("y", (CDate(lblFechaIngresoDato.Text)), DPFecha.Value))

        años = dias(0)
        meses = dias(1)
        diasme = dias(2)

        Dim objetoFiniquitoBU As New FiniquitosBU
        Dim mesesUtilidad As New Double
        mesesUtilidad = DateDiff("d", (CDate(lblFechaIngresoDato.Text)), DPFecha.Value)
        mesesUtilidad = mesesUtilidad / 30.4
        Dim TablaUtilidades As DataTable
        Dim PorcentajeUtilidades As New Int32
        Dim DiasGratificacion As New Double
        TablaUtilidades = objetoFiniquitoBU.ObtenerGratificacionUtilidad(mesesUtilidad)
        For Each row As DataRow In TablaUtilidades.Rows
            PorcentajeUtilidades = CInt(row("PorcentajeUtilidades"))
            DiasGratificacion = CDbl(row("DiasGratificaciones"))
        Next

        txtUtilidades.Text = FormatNumber((DatosReales.PCantidad * (PorcentajeUtilidades / 100)), 2)

        lblAnti.Text = años.ToString + "   Años  " + meses.ToString + "   Meses    " + diasme.ToString + "   Dias"
        lblTipoPagoDato.Text = DatosReales.PTipoPago
        If DatosGenerales.PNss <> "" Then
            lblEstatusSeguroDato.Text = "SI"
        Else
            lblEstatusSeguroDato.Text = "NO"
        End If
        If DatosReales.PTipoPago = "DESTAJO" Or DatosReales.PTipoPago = "POR BANDA" Then
            txtSemana1.Visible = True
            txtSemana2.Visible = True
            txtSemana3.Visible = True
            txtSemana4.Visible = True
            lblSemanas.Visible = True
            lblSemana1.Visible = True
            lblSemana2.Visible = True
            lblSemana3.Visible = True
            lblSemana4.Visible = True
            lblpesos1.Visible = True
            lblpesos2.Visible = True
            lblpesos3.Visible = True
            lblpesos4.Visible = True
        End If

        If DatosReales.PTipoPago = "SALARIO" Then
            txtSemana1.Visible = False
            txtSemana2.Visible = False
            txtSemana3.Visible = False
            txtSemana4.Visible = False
            lblSemanas.Visible = False
            lblSemana1.Visible = False
            lblSemana2.Visible = False
            lblSemana3.Visible = False
            lblSemana4.Visible = False
            lblpesos1.Visible = False
            lblpesos2.Visible = False
            lblpesos3.Visible = False
            lblpesos4.Visible = False
        End If
        Dim FechaCorte As Date = Today
        Dim mesestrabajo As Double
        mesestrabajo = objMesestrabajados.CalcularMesesTrabajados _
            (DateDiff("d", DPFecha.Value, (CDate("31 / 12 /" + FechaCorte.Year.ToString))))
        Dim ConfiguracionNave As New Entidades.ConfiguracionNaveNomina
        Dim objConfNaves As New ConfiguracionNaveNominaBU

        If DatosReales.PFecha.Year = Date.Today.Year Then

            ConfiguracionNave = objConfNaves.buscarConfiguracionNave(empleadosForm.PIdNaveEmpleado)
            txtDiasCorresponden.Text = ConfiguracionNave.PConDiasAguinaldo

            txtDiasVacCorres.Text = objConfNaves.CalcularDiasSegunAntiguedad(idnaveEmpleado, años)
            txtMesesTrabajados.Text = dias(1)
            txtDiasCorrespondenSegunMeses.Text = FormatNumber(((ConfiguracionNave.PConDiasAguinaldo / 12) * dias(1)), 2)
            If años < 1 And meses < 2 Then
                txtDiasCorrespondenSegunMeses.Text = 0
            End If
            txtDiasvacacionesCorresponden.Text = dias(1)
            txtDiasTrabajadorCorresponde.Text = FormatNumber((dias(1) * (objConfNaves.CalcularDiasSegunAntiguedad(idnaveEmpleado, años) / 12)), 2)
            If años < 1 And meses < 2 Then
                txtDiasTrabajadorCorresponde.Text = 0
            End If

        Else
            ConfiguracionNave = objConfNaves.buscarConfiguracionNave(empleadosForm.PIdNaveEmpleado)
            txtDiasCorresponden.Text = ConfiguracionNave.PConDiasAguinaldo
            txtDiasVacCorres.Text = objConfNaves.CalcularDiasSegunAntiguedad(idnaveEmpleado, años)
            txtMesesTrabajados.Text = FormatNumber(mesestrabajo, 2)
            txtDiasCorrespondenSegunMeses.Text = FormatNumber(((ConfiguracionNave.PConDiasAguinaldo / 12) * mesestrabajo), 2)
            If años < 1 And meses < 2 Then
                txtDiasCorrespondenSegunMeses.Text = 0
            End If
            txtDiasvacacionesCorresponden.Text = FormatNumber(mesestrabajo, 2)
            txtDiasTrabajadorCorresponde.Text = FormatNumber((mesestrabajo * (objConfNaves.CalcularDiasSegunAntiguedad(idnaveEmpleado, años) / 12)), 2)
            If años < 1 And meses < 2 Then
                txtDiasTrabajadorCorresponde.Text = 0
            End If
        End If



        If txtSemana1.Text = "" Then
            LblSueldoCal.Text = FormatNumber(DatosReales.PCantidad, 2)
            lblSueldoDiarioCal.Text = FormatNumber(((DatosReales.PCantidad) / 7), 2)
            Dim sueldoDiario As Double
            Try
                'sueldoDiario = (CType(lblSueldoDiarioCal.Text, Double))
                sueldoDiario = DatosReales.PCantidad / 7
                CostoDiario = sueldoDiario
                If txtDiasCorrespondenSegunMeses.Text = "" Then
                    txtDiasCorrespondenSegunMeses.Text = 0
                End If
                txtTotalAguinaldo.Text = FormatNumber((CType(txtDiasCorrespondenSegunMeses.Text, Double) * sueldoDiario), 2)
            Catch ex As Exception
                MessageBox.Show("El Empleado no tiene un sueldo registrado")
            End Try
            Try

                If txtDiasTrabajadorCorresponde.Text = "" Then
                    txtDiasTrabajadorCorresponde.Text = 0
                End If


                txtTotalVacaciones.Text = FormatNumber(CType(txtDiasTrabajadorCorresponde.Text, Double) * sueldoDiario, 2)
                txtPrimaVacacional.Text = FormatNumber(((CType(txtDiasTrabajadorCorresponde.Text, Double) * sueldoDiario) * 0.25), 2)
                txtTotalVacTotal.Text = FormatNumber((CType(txtTotalVacaciones.Text, Double) + CType(txtPrimaVacacional.Text, Double)), 2)
            Catch ex As Exception
                MessageBox.Show("El Aguinaldo a la fecha correspondiente ya ha sido entregado")

            End Try
            If txtTotalAguinaldo.Text = "" Then
                txtTotalAguinaldo.Text = 0
            End If
            If txtTotalVacaciones.Text = "" Then
                txtTotalVacaciones.Text = 0
            End If
            If txtPrimaVacacional.Text = "" Then
                txtPrimaVacacional.Text = 0
            End If
            Dim totaAguinaldo As Int32
            Dim totalvacaciones As Int32
            Dim totalPrimaVacacional As Int32
            totaAguinaldo = CType(txtTotalAguinaldo.Text, Integer)
            totalvacaciones = CType(txtTotalVacaciones.Text, Integer)
            totalPrimaVacacional = CType(txtPrimaVacacional.Text, Integer)
            txtLiquidacion.Text = FormatNumber((totaAguinaldo + totalvacaciones + totalPrimaVacacional), 2)

            Try
                txtGratificacion.Text = FormatNumber((DiasGratificacion * sueldoDiario), 2)
            Catch ex As Exception
            End Try
            If DatosReales.PTipoPago = "DESTAJO" Then
                ValidacionSemanas()
            End If






        Else

            If DatosReales.PTipoPago = "DESTAJO" Then
                ValidacionSemanas()
            End If
            If (txtSemana1.Text = 0 And txtSemana2.Text = 0 And txtSemana3.Text = 0 And txtSemana4.Text = 0) Then

            Else
                SueldoCal = objSueldoCal.CalcularSueldo(CType(txtSemana1.Text, Integer), CType(txtSemana2.Text, Integer), CType(txtSemana3.Text, Integer), CType(txtSemana4.Text, Integer))
                LblSueldoCal.Text = SueldoCal.ToString
            End If

            Dim sueldoDiario As Double
            sueldoDiario = (SueldoCal / 7)
            CostoDiario = sueldoDiario
            lblSueldoDiarioCal.Text = sueldoDiario.ToString("##,##.00")
            Try
                txtTotalAguinaldo.Text = FormatNumber((CType(txtDiasCorrespondenSegunMeses.Text, Double) * sueldoDiario), 2)
            Catch ex As Exception
                MessageBox.Show("El Empleado no tiene un sueldo registrado")
            End Try
            txtTotalVacaciones.Text = FormatNumber((CType(txtDiasTrabajadorCorresponde.Text, Double) * sueldoDiario), 2)
            txtPrimaVacacional.Text = FormatNumber(((CType(txtDiasTrabajadorCorresponde.Text, Double) * sueldoDiario) * 0.25), 2)
            If txtTotalAguinaldo.Text = "" Then
                txtTotalAguinaldo.Text = 0
            End If
            If txtTotalVacaciones.Text = "" Then
                txtTotalVacaciones.Text = 0
            End If
            If txtPrimaVacacional.Text = "" Then
                txtPrimaVacacional.Text = 0
            End If
            Dim totaAguinaldo As Int32
            Dim totalvacaciones As Int32
            Dim totalPrimaVacacional As Int32
            totaAguinaldo = CType(txtTotalAguinaldo.Text, Integer)
            totalvacaciones = CType(txtTotalVacaciones.Text, Integer)
            totalPrimaVacacional = CType(txtPrimaVacacional.Text, Integer)
            txtLiquidacion.Text = FormatNumber((totaAguinaldo + totalvacaciones + totalPrimaVacacional), 2)
            txtTotalVacTotal.Text = FormatNumber((CType(txtTotalVacaciones.Text, Double) + CType(txtPrimaVacacional.Text, Double)), 2)


            Try
                txtGratificacion.Text = FormatNumber(((años * ConfiguracionNave.PconDiasGratificacion) * sueldoDiario), 2)
            Catch ex As Exception
            End Try
        End If
        Dim objFiniquito As New FiniquitosBU
        'FechaUltima = objFiniquito.ObtenerUltimoDiaTrabajado(IdColaborador)
        'FechaIniciaPeriodo = objFiniquito.BuscarFechaNominaTrabajado(FechaUltima)
        'PeriodoID = objFiniquito.BuscarPeriodoNominaTrabajado(FechaUltima)
        'ApareceNomina = objFiniquito.BuscarAparecePeriodoNomina(IdColaborador, PeriodoID)
        'If ApareceNomina = False Then
        '    Dim DiasTrabajadossinPagar As Int32
        '    DiasTrabajadossinPagar = (DateDiff("d", FechaIniciaPeriodo, FechaUltima)) + 1
        '    'txtDiasTrabajados.Text = FormatNumber((DiasTrabajadossinPagar * CostoDiario), 2)
        'End If
        txtTotalEntregar.Text = FormatNumber((CType(txtGratificacion.Text, Integer) _
                                   + CType(txtLiquidacion.Text, Integer) + CType(txtAhorrro.Text, Integer) - CType(txtPrestamo.Text, Integer) + CType(txtUtilidades.Text, Integer)), 2)
        txtSubtotal.Text = FormatNumber((CType(txtGratificacion.Text, Integer) _
                             + CType(txtLiquidacion.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtUtilidades.Text, Integer)), 2)
        'txtTotalEntregar.Text = FormatNumber((CType(txtGratificacion.Text, Integer) _
        '                           + CType(txtLiquidacion.Text, Integer) + CType(txtDiasTrabajados.Text, Integer) + CType(txtAhorrro.Text, Integer) - CType(txtPrestamo.Text, Integer)), 2)
        'txtSubtotal.Text = FormatNumber((CType(txtGratificacion.Text, Integer) _
        '                     + CType(txtLiquidacion.Text, Integer) + CType(txtDiasTrabajados.Text, Integer) + CType(txtAhorrro.Text, Integer)), 2)
    End Sub

    Private Sub DPFecha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DPFecha.ValueChanged
        Operaciones()
    End Sub

    Private Sub txtSemana1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSemana1.LostFocus
        ValidacionSemanas()
        LblSueldoCal.Text = ((CType(txtSemana1.Text, Integer) _
                              + CType(txtSemana2.Text, Integer) _
                              + CType(txtSemana3.Text, Integer) _
                              + CType(txtSemana4.Text, Integer)) / 4) _
                      .ToString("$,##,###,##")


        lblSueldoDiarioCal.Text = (((CType(txtSemana1.Text, Integer) _
                                     + CType(txtSemana2.Text, Integer) _
                                     + CType(txtSemana3.Text, Integer) _
                                     + CType(txtSemana4.Text, Integer)) / 4) / 7) _
                         .ToString("$,##,###,##")
        Validacion()


        Operaciones()
        txtTotalVacTotal.Text = FormatNumber((CType(txtTotalVacaciones.Text, Double) + CType(txtPrimaVacacional.Text, Double)), 2)
        txtSubtotal.Text = FormatNumber((CType(txtGratificacion.Text, Integer) _
                      + CType(txtUtilidades.Text, Integer) _
                      + CType(txtAhorrro.Text, Integer) _
                      + CType(txtLiquidacion.Text, Integer)), 2)


        'txtSubtotal.Text = FormatNumber((CType(txtGratificacion.Text, Integer) _
        '           + CType(txtUtilidades.Text, Integer) _
        '           + CType(txtAhorrro.Text, Integer) _
        '           + CType(txtLiquidacion.Text, Integer) + CType(txtDiasTrabajados.Text, Integer)), 2)

        Validacion()

        'txtTotalEntregar.Text = (CType(txtGratificacion.Text, Integer) _
        '                         + CType(txtUtilidades.Text, Integer) _
        '                         + CType(txtAhorrro.Text, Integer) _
        '                         + CType(txtLiquidacion.Text, Integer) _
        '                         - CType(txtPrestamo.Text, Integer)) + CType(txtAhorrro.Text, Integer) - CType(txtPrestamo.Text, Integer) _
        '                     .ToString("##,###.##")


        'txtTotalEntregar.Text = (CType(txtGratificacion.Text, Integer) _
        '                        + CType(txtUtilidades.Text, Integer) _
        '                        + CType(txtAhorrro.Text, Integer) _
        '                        + CType(txtLiquidacion.Text, Integer) _
        '                        - CType(txtPrestamo.Text, Integer)) + CType(txtDiasTrabajados.Text, Integer) + CType(txtAhorrro.Text, Integer) - CType(txtPrestamo.Text, Integer) _
        '                    .ToString("##,###.##")

    End Sub

    Private Sub txtSemana2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSemana2.LostFocus
        ValidacionSemanas()
        LblSueldoCal.Text = ((CType(txtSemana1.Text, Integer) _
                              + CType(txtSemana2.Text, Integer) _
                              + CType(txtSemana3.Text, Integer) _
                              + CType(txtSemana4.Text, Integer)) / 4) _
                      .ToString("$,##,###,##")


        lblSueldoDiarioCal.Text = (((CType(txtSemana1.Text, Integer) _
                                     + CType(txtSemana2.Text, Integer) _
                                     + CType(txtSemana3.Text, Integer) _
                                     + CType(txtSemana4.Text, Integer)) / 4) / 7) _
                         .ToString("$,##,###,##")

        Validacion()
        Operaciones()
        txtTotalVacTotal.Text = FormatNumber((CType(txtTotalVacaciones.Text, Double) + CType(txtPrimaVacacional.Text, Double)), 2)
        txtSubtotal.Text = (CType(txtGratificacion.Text, Integer) _
                            + CType(txtUtilidades.Text, Integer) _
                            + CType(txtAhorrro.Text, Integer) _
                            + CType(txtLiquidacion.Text, Integer)) _
                        .ToString("##,###.##")


        'txtSubtotal.Text = (CType(txtGratificacion.Text, Integer) _
        '                 + CType(txtUtilidades.Text, Integer) _
        '                 + CType(txtAhorrro.Text, Integer) _
        '                 + CType(txtLiquidacion.Text, Integer)) + CType(txtDiasTrabajados.Text, Integer) _
        '             .ToString("##,###.##")



        'txtTotalEntregar.Text = (CType(txtGratificacion.Text, Integer) _
        '                         + CType(txtUtilidades.Text, Integer) _
        '                         + CType(txtAhorrro.Text, Integer) _
        '                         + CType(txtLiquidacion.Text, Integer) _
        '                         - CType(txtPrestamo.Text, Integer)) + CType(txtAhorrro.Text, Integer) - CType(txtPrestamo.Text, Integer) _
        '                     .ToString("##,###.##")





        'txtTotalEntregar.Text = (CType(txtGratificacion.Text, Integer) _
        '                         + CType(txtUtilidades.Text, Integer) _
        '                         + CType(txtAhorrro.Text, Integer) _
        '                         + CType(txtLiquidacion.Text, Integer) _
        '                         - CType(txtPrestamo.Text, Integer)) + CType(txtDiasTrabajados.Text, Integer) + CType(txtAhorrro.Text, Integer) - CType(txtPrestamo.Text, Integer) _
        '                     .ToString("##,###.##")



    End Sub

    Private Sub txtSemana3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSemana3.LostFocus
        ValidacionSemanas()
        LblSueldoCal.Text = ((CType(txtSemana1.Text, Integer) + CType(txtSemana2.Text, Integer) + CType(txtSemana3.Text, Integer) + CType(txtSemana4.Text, Integer)) / 4).ToString("$,##,###,##")
        lblSueldoDiarioCal.Text = (((CType(txtSemana1.Text, Integer) + CType(txtSemana2.Text, Integer) + CType(txtSemana3.Text, Integer) + CType(txtSemana4.Text, Integer)) / 4) / 7).ToString("$,##,###,##")
        Validacion()
        Operaciones()
        txtTotalVacTotal.Text = FormatNumber((CType(txtTotalVacaciones.Text, Double) + CType(txtPrimaVacacional.Text, Double)), 2)
        txtSubtotal.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer)).ToString("##,###.##")
        txtTotalEntregar.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer) - CType(txtPrestamo.Text, Integer)).ToString("##,###.##")



    End Sub

    Private Sub txtSemana4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSemana4.LostFocus
        ValidacionSemanas()
        LblSueldoCal.Text = ((CType(txtSemana1.Text, Integer) + CType(txtSemana2.Text, Integer) + CType(txtSemana3.Text, Integer) + CType(txtSemana4.Text, Integer)) / 4).ToString("$,##,###,##")
        lblSueldoDiarioCal.Text = (((CType(txtSemana1.Text, Integer) + CType(txtSemana2.Text, Integer) + CType(txtSemana3.Text, Integer) + CType(txtSemana4.Text, Integer)) / 4) / 7).ToString("$,##,###,##")
        Validacion()
        Operaciones()
        txtTotalVacTotal.Text = FormatNumber((CType(txtTotalVacaciones.Text, Double) + CType(txtPrimaVacacional.Text, Double)), 2)
        txtSubtotal.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer)).ToString("##,###.##")
        txtTotalEntregar.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer) - CType(txtPrestamo.Text, Integer)).ToString("##,###.##")

        'txtTotalEntregar.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer) - CType(txtPrestamo.Text, Integer) + CType(txtDiasTrabajados.Text, Integer)).ToString("##,###.##")


    End Sub

    Private Sub txtAhorrro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAhorrro.LostFocus
        Validacion()
        txtTotalEntregar.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer) - CType(txtPrestamo.Text, Integer)).ToString("##,###.##")
        'txtTotalEntregar.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer) - CType(txtPrestamo.Text, Integer) + CType(txtDiasTrabajados.Text, Integer)).ToString("##,###.##")

        txtAhorrro.Text = FormatNumber(txtAhorrro.Text, 2)
    End Sub

    Private Sub txtGratificacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGratificacion.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtGratificacion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGratificacion.LostFocus
        Validacion()
        txtSubtotal.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer)).ToString("##,###.##")
        txtTotalEntregar.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer) - CType(txtPrestamo.Text, Integer)).ToString("##,###.##")



        'txtSubtotal.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer) + CType(txtDiasTrabajados.Text, Integer)).ToString("##,###.##")
        'txtTotalEntregar.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer) - CType(txtPrestamo.Text, Integer) + CType(txtDiasTrabajados.Text, Integer)).ToString("##,###.##")


        txtGratificacion.Text = FormatNumber(txtGratificacion.Text, 2)
    End Sub

    Private Sub txtUtilidades_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUtilidades.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtUtilidades_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUtilidades.LostFocus
        Validacion()
        txtSubtotal.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer)).ToString("##,###.##")
        txtTotalEntregar.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer) - CType(txtPrestamo.Text, Integer)).ToString("##,###.##")


        'txtSubtotal.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer) + CType(txtDiasTrabajados.Text, Integer)).ToString("##,###.##")
        'txtTotalEntregar.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer) - CType(txtPrestamo.Text, Integer) + CType(txtDiasTrabajados.Text, Integer)).ToString("##,###.##")


        txtUtilidades.Text = FormatNumber(txtUtilidades.Text, 2)
    End Sub

    Private Sub txtPrestamo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrestamo.LostFocus
        Validacion()
        txtSubtotal.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer)).ToString("##,###.##")
        txtTotalEntregar.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer) - CType(txtPrestamo.Text, Integer)).ToString("##,###.##")
        txtPrestamo.Text = FormatNumber(txtPrestamo.Text, 2)
    End Sub

    Private Sub txtLiquidacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLiquidacion.KeyDown

    End Sub

    Private Sub txtLiquidacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLiquidacion.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub




    Private Sub txtLiquidacion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLiquidacion.LostFocus

        Validacion()
        txtSubtotal.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer)).ToString("##,###.##")
        txtTotalEntregar.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer) - CType(txtPrestamo.Text, Integer)).ToString("##,###.##")
        'txtTotalEntregar.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer) - CType(txtPrestamo.Text, Integer) + CType(txtDiasTrabajados.Text, Integer)).ToString("##,###.##")

    End Sub




    Public Sub Validacion()
        If txtGratificacion.Text = "" Then
            txtGratificacion.Text = 0
        End If
        If txtAhorrro.Text = "" Then
            txtAhorrro.Text = 0
        End If
        If txtUtilidades.Text = "" Then
            txtUtilidades.Text = 0
        End If
        If txtPrestamo.Text = "" Then
            txtPrestamo.Text = 0
        End If
        If txtLiquidacion.Text = "" Then
            txtLiquidacion.Text = 0
        End If
    End Sub

    Public Sub ValidacionSemanas()

        If txtSemana1.Text = "" Then
            txtSemana1.Text = "0"

        End If

        If txtSemana2.Text = "" Then
            txtSemana2.Text = "0"
        End If
        If txtSemana3.Text = "" Then
            txtSemana3.Text = "0"
        End If
        If txtSemana4.Text = "" Then
            txtSemana4.Text = "0"
        End If
    End Sub

    Private Sub btnFiniquitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiniquitar.Click
        If MessageBox.Show("¿Esta seguro que quiere Finiquitar al colaborador?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then


            Dim ComboMotivo As New Boolean
            ComboMotivo = False
            If (cmbMotivoFiniquito.Text <> "") Then
                lblMotivoFiniquito.ForeColor = Color.Black
            Else
                lblMotivoFiniquito.ForeColor = Color.Red
                ComboMotivo = True
            End If

            If ComboMotivo = True Then
                Dim FormularioError As New AdvertenciaForm
                FormularioError.mensaje = "Seleccione un Motivo"
                FormularioError.MdiParent = MdiParent
                FormularioError.Show()

            Else
                Dim ObjEntidad As New Entidades.Finiquitos
                Dim objColaborador As New Entidades.Colaborador
                objColaborador.PColaboradorid = empleadosForm.pseleccion
                ObjEntidad.PColaboradorId = objColaborador


                If cmbMotivoFiniquito.SelectedValue > 0 Then
                    Dim motivo As New Entidades.MotivosFiniquito
                    motivo.PMotivoFiniquitoId = CInt(cmbMotivoFiniquito.SelectedValue)
                    ObjEntidad.PMotivoFiniquitoId = motivo
                End If


                ObjEntidad.PJustificacion = txtJustificacion.Text
                ObjEntidad.PFechaBaja = DPFecha.Value
                ObjEntidad.PAntiguedadAnios = dias(0)
                ObjEntidad.PAntiguedadMeses = dias(1)
                ObjEntidad.PAntiguedadDias = dias(2)

                If txtSemana1.Text = "" Then
                    ObjEntidad.PSemana1 = 0
                    ObjEntidad.PSemana2 = 0
                    ObjEntidad.PSemana3 = 0
                    ObjEntidad.PSemana4 = 0
                Else
                    ObjEntidad.PSemana1 = txtSemana1.Text
                    ObjEntidad.PSemana2 = txtSemana2.Text
                    ObjEntidad.PSemana3 = txtSemana3.Text
                    ObjEntidad.PSemana4 = txtSemana4.Text
                End If

                If txtAhorrro.Text = "" Then
                    ObjEntidad.PAhorro = 0
                End If
                If txtUtilidades.Text = "" Then
                    ObjEntidad.PUtilidades = 0
                End If
                If txtUtilidades.Text = 0 Then
                    ObjEntidad.PUtilidades = 0
                End If

                If txtGratificacion.Text = "" Then
                    ObjEntidad.PGratificacion = 0
                End If

                If txtPrestamo.Text = "" Then
                    ObjEntidad.PPrestamo = 0
                End If
                If txtSubtotal.Text = "" Then
                    ObjEntidad.PSubtotal = 0
                Else
                    ObjEntidad.PSubtotal = txtSubtotal.Text
                End If
                ObjEntidad.PSalario = CType(LblSueldoCal.Text, Double)
                ObjEntidad.PSalarioDiario = CType(lblSueldoDiarioCal.Text, Double)
                ObjEntidad.PMesesAguinaldo = txtMesesTrabajados.Text
                ObjEntidad.PDiasAguinaldo = txtDiasCorrespondenSegunMeses.Text
                ObjEntidad.PMesesVacaciones = txtDiasvacacionesCorresponden.Text
                ObjEntidad.PDiasVacaciones = txtDiasTrabajadorCorresponde.Text
                'If cmbMotivoFiniquito.Text.ToUpper = "DESPIDO" Then
                '    ObjEntidad.PTotalAguinaldo = 0
                '    ObjEntidad.PTotalVacaciones = 0
                '    ObjEntidad.PTotalFiniquito = 0
                'Else
                ObjEntidad.PTotalAguinaldo = txtTotalAguinaldo.Text
                ObjEntidad.PTotalVacaciones = txtTotalVacaciones.Text
                ObjEntidad.PTotalFiniquito = txtLiquidacion.Text
                'End If

                ObjEntidad.PAhorro = txtAhorrro.Text
                ObjEntidad.PUtilidades = txtUtilidades.Text
                ObjEntidad.PGratificacion = txtGratificacion.Text

                ObjEntidad.PPrestamo = txtPrestamo.Text

                If txtTotalEntregar.Text = "" Then
                    ObjEntidad.PTotalEntregar = 0
                Else
                    ObjEntidad.PTotalEntregar = txtTotalEntregar.Text
                End If
                ObjEntidad.PEstado = "A"
                ObjEntidad.PUsuarioCreoId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                ObjEntidad.PDiasSegunAntiguedad = txtDiasVacCorres.Text
                ObjEntidad.PPrimaVacacional = txtPrimaVacacional.Text
                'ObjEntidad.PSueldoDiasTrabajados = txtDiasTrabajados.Text
                ObjEntidad.PNaveID = idnaveEmpleado
                Dim ColaboradorCorreo As New Entidades.Colaborador
                'Dim FiniquitoEnviarCorreo As New Entidades.Finiquitos
                ' FiniquitoEnviarCorreo = ObjEntidad
                ColaboradorCorreo.PNombre = lblNomTrabajadorDato.Text
                Dim DepartamentoCorreo As New Entidades.Departamentos
                DepartamentoCorreo.DNombre = lblDepartamento.Text
                ColaboradorCorreo.PIDepartamento = DepartamentoCorreo
                ' FiniquitoEnviarCorreo.PColaboradorId = ColaboradorCorreo
                Dim objBU As New FiniquitosBU
                ' Dim EnviarSolicitudFiniquito As New Entidades.Finiquitos
                Dim MensajeNegocios As String
                MensajeNegocios = objBU.SolicitarFiniquito(ObjEntidad, empleadosForm.pseleccion, "A")
                If MensajeNegocios.Length = 0 Then
                    Dim FormularioMensaje As New ExitoForm
                    FormularioMensaje.mensaje = "Solicitud Enviada"
                    ListaFiniquitos.Add(ObjEntidad)
                    enviar_correo(idnaveEmpleado, ListaFiniquitos, "ENVIO_NOTIFICACIONES_FINIQUITOS")
                    FormularioMensaje.MdiParent = MdiParent
                    FormularioMensaje.Show()
                    Me.Close()
                Else
                    Dim FormularioMensaje As New AdvertenciaForm
                    FormularioMensaje.mensaje = MensajeNegocios
                    FormularioMensaje.MdiParent = MdiParent
                    FormularioMensaje.Show()
                    Me.Close()
                End If




            End If

        End If
    End Sub

    Private Sub txtSubtotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSubtotal.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTotalEntregar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalEntregar.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrimaVacacional_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrimaVacacional.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTotalAguinaldo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalAguinaldo.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTotalVacaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalVacaciones.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMEsesVacaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMEsesVacaciones.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMesesTrabajados_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMesesTrabajados.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMesestotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMesestotal.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDiasvacacionesCorresponden_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiasvacacionesCorresponden.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDiasTrabajadorCorresponde_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiasTrabajadorCorresponde.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDiasCorrespondenSegunMeses_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiasCorrespondenSegunMeses.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtDiasCorresponden_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiasCorresponden.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDiasVacCorres_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiasVacCorres.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDiasTrabajados_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsControl(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub enviar_correo(ByVal naveID As Integer, ByVal Solicitudes As List(Of Entidades.Finiquitos), ByVal clave As String)
        Dim SumaTotal As New Double
        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String
        Dim correo As New Tools.Correo

        destinatarios = enviosCorreoBU.consulta_destinatarios_email(naveID, clave)

        Dim Email As String = "<html>" +
                                "<head>" +
                                  "<style type ='" + "text/css" + "'> body {display: block; margin: 8px; background: #FFFFFF;}#header{	position: fixed;	height: 62px;	top: 0;	left: 0;	right: 0;	color: #003366;	font-family: Arial, Helvetica, sans-serif;	font-size: 18px;	font-weight: bold;}#leftcolumn{	float: left;	position: fixed;	width: 2%;	margin: 1%;	padding-top: 3%;	top: 0;	left: 0;	right: 0;}#content{	width: 90%;	position: fixed;	margin: 1% 5%;		padding-top: 3%;	padding-bottom: 1%;}#rightcolumn{	float: right;	width: 5%;	margin: 1%;			padding-top: 3%;}#footer{	position: fixed;	width: 100%;	heigt: 5%;	bottom: 0;	margin: 0;	padding: 0;	color: #FFFFFF;}table.tableizer-table { 	font-family: Arial, Helvetica, sans-serif;	font-size: 9px;} .tableizer-table td {	padding: 4px;	margin: 0px;	border: 1px solid #FFFFFF;	border-color: #FFFFFF;	border: 1px solid #CCCCCC;	width: 200px;} .tableizer-table tr {	padding: 4px;	margin: 0;	color: #003366;	font-weight: bold;	background-color: #transparent; 	opacity: 1;}.tableizer-table th {	background-color: #003366; 	color: #FFFFFF;	font-weight: bold;	height: 30px;	font-size: 10px;}A:link {	text-decoration:none;color:#FFFFFF;} A:visited {	text-decoration:none;color:#FFFFFF;} A:active {	text-decoration:none;color:#FFFFFF;} A:hover {	text-decoration:none;color:#006699;} </style>" +
                                  "</head>" +
                                  "<body>" +
                                   "<div id='" + "wrapper" + "'>" +
                                    "<div id='" + "header" + "'>" +
                                    "<img src='" + "http://www.grupoyuyin.com.mx/GRUPO_YUYIN.jpg" + "'style='" + "vertical-align:middle" + "' height='" + "57" + "' widht='" + "125" + "'> Solicitud de Finiquito <br> <font size=2>Usuario que Solicito : " + Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString + "</font>" +
                                   " </div> <br></br>" +
                                    "<div id='" + "leftcolumn" + "'>" +
                                    "</div>" +
                                    "<div id='" + "rightcolumn" + "'>" +
                                    "</div>" + "<div id='" + "content" + "'>" +
                                      "<table id='" + "mi_tabla" + "' class='" + "tableizer-table" + "'>" +
                                       "<thead>" +
                                        "<tr class='" + "tableizer-firstrow" + "'>" +
                                        "<th width ='" + "30%" + "'>Nombre</th>" +
                                        "<th width ='" + "15%" + "'>Departamento</th>" +
                                        "<th width ='" + "10%" + "'>Fecha de Solicitud</th>" +
                                        "<th width ='" + "10%" + "'>Fecha de Ingreso</th>" +
                                        "<th width ='" + "13%" + "'>Antiguedad</th>" +
                                        "<th width ='" + "10%" + "'>Fecha baja</th>" +
                                        "<th width ='" + "15%" + "'>Justificacion</th>" +
                                        "<th width ='" + "10%" + "'>Motivo</th>" +
                                        "<th width ='" + "10%" + "'>Aguinaldo</th>" +
                                        "<th width ='" + "10%" + "'>Vacaciones</th>" +
                                        "<th width ='" + "10%" + "'>Prima Vacacional</th>" +
                                        "<th width ='" + "10%" + "'>Total Vacaciones</th>" +
                                        "<th width ='" + "10%" + "'>Finiquito</th>" +
                                        "<th width ='" + "10%" + "'>Ahorro</th>" +
                                        "<th width ='" + "10%" + "'>Utilidades</th>" +
        "<th width ='" + "7%" + "'>Gratificacion</th>" +
        "<th width ='" + "7%" + "'>Subtotal</th>" +
        "<th width ='" + "7%" + "'>Prestamo</th>" +
        "<th width ='" + "7%" + "'>Total Entregar</th>" +
                                       "</thead>" +
                                       "<tbody>"
        For Each solicitud As Entidades.Finiquitos In ListaFiniquitos
            Email +=
                                        "<tr>" +
                                            "<td>" + lblNomTrabajadorDato.Text.ToString + "</td>" +
                                            "<td>" + lblDepartamentoDato.Text.ToString + "</td>" +
                                            "<td>" + Today.ToShortDateString + "</td>" +
        "<td>" + lblFechaIngresoDato.Text.ToString + "</td>" +
        "<td>" + lblAnti.Text.ToString.ToUpper + "</td>" +
        "<td>" + solicitud.PFechaBaja.ToShortDateString + "</td>" +
        "<td>" + solicitud.PJustificacion.ToString.ToUpper + "</td>" +
 "<td>" + cmbMotivoFiniquito.Text.ToString.ToUpper + "</td>" +
  "<td> $ " + txtTotalAguinaldo.Text.ToString + "</td>" +
  "<td> $ " + txtTotalVacaciones.Text.ToString + "</td>" +
   "<td>" + solicitud.PPrimaVacacional.ToString("C") + "</td>" +
    "<td> $ " + txtTotalVacTotal.Text.ToString + "</td>" +
     "<td> $" + txtLiquidacion.Text.ToString + "</td>" +
      "<td>" + solicitud.PAhorro.ToString("C") + "</td>" +
       "<td>" + solicitud.PUtilidades.ToString("C") + "</td>" +
        "<td>" + solicitud.PGratificacion.ToString("C") + "</td>" +
         "<td>" + solicitud.PSubtotal.ToString("C") + "</td>" +
          "<td>" + solicitud.PPrestamo.ToString("C") + "</td>" +
           "<td>" + solicitud.PTotalEntregar.ToString("C") + "</td>"
            ' SumaTotal += solicitud.PMonto
        Next




        Email += "                 " +
"</tbody>" +
                "</table>" +
                       "</div>" +
                       "<div id='" + "footer" + "'>" +
                       "</div>" +
                   "</div>" +
                "</body>" +
                "</html>"

        correo.EnviarCorreoHtml(destinatarios, "say_nomina@grupoyuyin.com.mx", "Solicitud de Finiquito", Email)

    End Sub

    Private Sub txtTotalAguinaldo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalAguinaldo.LostFocus
        If txtTotalAguinaldo.Text = "" Then
            txtTotalAguinaldo.Text = "0"
            txtLiquidacion.Text = (CDbl(txtTotalAguinaldo.Text) + CDbl(txtTotalVacTotal.Text))
        End If
    End Sub

    Private Sub txtTotalVacTotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalVacTotal.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTotalVacTotal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalVacTotal.LostFocus
        If txtTotalVacTotal.Text = "" Then
            txtTotalVacTotal.Text = "0"
            txtLiquidacion.Text = (CDbl(txtTotalAguinaldo.Text) + CDbl(txtTotalVacTotal.Text))
        End If
    End Sub

    Private Sub txtLiquidacion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLiquidacion.TextChanged
        Try
            Validacion()
            txtSubtotal.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer)).ToString("##,###.##")
            txtTotalEntregar.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer) - CType(txtPrestamo.Text, Integer)).ToString("##,###.##")
            'txtTotalEntregar.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer) - CType(txtPrestamo.Text, Integer) + CType(txtDiasTrabajados.Text, Integer)).ToString("##,###.##")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub lblTotalVa_Click(sender As Object, e As EventArgs) Handles lblTotalVa.Click

    End Sub

    Private Sub lblBuscarEmpleado_Click(sender As Object, e As EventArgs) Handles lblBuscarEmpleado.Click

    End Sub

    Private Sub txtSemana1_TextChanged(sender As Object, e As EventArgs) Handles txtSemana1.TextChanged

    End Sub
End Class