Imports System.Net
Imports Tools

Public Class SolicitudPrestamosForm
    Public Property MaxLength As Integer
    Dim IdColaborador As Integer = 0
    Dim IdNave As Integer = 0
    Dim valorFormato As String
    Dim MaximoNave As Double = 0
    Dim MaximoColaborador As Double = 0
    Dim MaximoSemanas As Integer = 0
    Dim prestamos As Integer = 0
    Dim TotalInteres As Double = 0
    ''Dim TotalInteres As Double = 0
    Dim totalInteres2 As Double = 0
    Dim TotalTotales As Double = 0
    Dim Pagototal2 As Double = 0
    Dim estaMal As Boolean = False
    Dim montoAhorro As Double = 0



    Private Sub SolicitudPrestamos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Top = 0
        Me.Left = 0
        picBoxColaborador.Image = CType(My.Resources.ResourceManager.GetObject("YUMPER1"), Image)
        'Tools.FormatoCtrls.formato(Me)
        rbtnSemanas.Checked = True
        'lblAbonoTotal.Enabled = False
        'lblAbonoTotal2.Enabled = False
        btnCalcular.Enabled = False
        lblCalcular.Enabled = False
        btnLimpiar.Enabled = False
        lblLimpiar.Enabled = False
        'btnImprimir.Enabled = False
        'lblImprimir.Enabled = False
        btnGuardar.Enabled = False
        lblGuardar.Enabled = False
        'lblPagoTotal.Enabled = False
        'lblPagoTotal2.Enabled = False
        'lblInteresTotal.Visible = False
        'lblInteresTotal2.Visible = False
        lblDirector.Visible = False
        lblGerente.Visible = False

        rbtnAbono.Enabled = False
        rbtnSemanas.Enabled = False
        txtMonto.Enabled = False
        txtSemanas.Enabled = False
        txtAbono.Enabled = False
        txtInteres.Enabled = False
        txtJustificacion.Enabled = False
        cmbMotivo.Enabled = False
        cmbTipoInteres.Enabled = False

        limpiar()


    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim empleadosForm As New BuscarEmpleadoForm
        empleadosForm.grdBuscarEmpleado.Rows.Clear()
        txtMonto.Focus()


        If empleadosForm.ShowDialog = DialogResult.OK Then

            IdColaborador = empleadosForm.pseleccion
            validarPrestamo()

            If prestamos > 0 Then
                Dim mensajeError As New AdvertenciaForm
                mensajeError.MdiParent = Me.MdiParent
                mensajeError.mensaje = "El colaborador tiene un préstamo en proceso, no puede solicitar otro por el momento."
                mensajeError.Show()
                prestamos = 0
            Else

                limpiar()
                llenarParametros()
                btnBuscar.Enabled = False
                lblBuscar.Enabled = False


                btnCalcular.Enabled = True
                lblCalcular.Enabled = True

                btnLimpiar.Enabled = True
                lblLimpiar.Enabled = True

                txtMonto.Enabled = True
                txtSemanas.Enabled = True

                ' txtInteres.Enabled = True
                txtJustificacion.Enabled = True

                rbtnSemanas.Enabled = True
                rbtnAbono.Enabled = True
                cmbMotivo.Enabled = True
                cmbTipoInteres.Enabled = True

            End If
        End If
        lblMonto.ForeColor = Color.Black
    End Sub

    Public Sub llenarParametros()

        Dim FechaActual As Date = DateTime.Now().ToShortDateString()
        Dim anios As Int32 = 0
        Dim meses As Int32 = 0
        Dim dias As Int32 = 0
        Dim diasme As Int32 = 0
        Dim DiasTrabajados As Integer
        Dim DiasDeVida As Integer


        Dim EntidadArchivos As New Entidades.ColaboradorExpediente
        Dim ObjArchivosBU As New Negocios.EnviodeArchivosBU

        EntidadArchivos = ObjArchivosBU.CredencialColaborador(IdColaborador)

        Try

            Dim objFTP As New Tools.TransferenciaFTP
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
            picBoxColaborador.Image = Image.FromStream(Stream)
        Catch ex As Exception

        End Try




        Try

            ''LLENADO DE DATOS PERSONALES
            Dim DatosPersonales As New Entidades.Colaborador
            Dim DatosPersonalesBU As New Nomina.Negocios.ColaboradoresBU

            DatosPersonales = DatosPersonalesBU.BuscarColaboradorGeneral(IdColaborador)
            lblColaborador2.Text = DatosPersonales.PNombre + " " + DatosPersonales.PApaterno + " " + DatosPersonales.PAmaterno

            ''Llenado de EDAD
            Dim FechaNacimiento As Date = DatosPersonales.PFechaNacimiento
            DiasDeVida = (FechaActual - FechaNacimiento).TotalDays
            anios = DiasDeVida \ 365
            meses = (DiasDeVida - (365 * Fix(DiasDeVida / 365)))
            meses = Fix(meses / 30.4)
            diasme = (DiasDeVida Mod 365) Mod 30.4
            lblEdad2.Text = UCase(anios.ToString + " años ")

            ''LLENADO DE DATOS LABORALES
            Dim DatosLaborales As New Entidades.ColaboradorLaboral
            Dim DatosLaboralesBU As New Nomina.Negocios.ColaboradorLaboralBU

            DatosLaborales = DatosLaboralesBU.buscarInformacionLaboral(IdColaborador)
            lblPuesto2.Text = DatosLaborales.PPuestoId.PNombre
            lblDepartamento2.Text = DatosLaborales.PDepartamentoId.DNombre
            lblNave2.Text = UCase(DatosLaborales.PNaveId.PNombre)


            IdNave = DatosLaborales.PNaveId.PNaveId


            ''LLENADO DE DATOS REALES
            Dim DatosReales As New Entidades.ColaboradorReal
            Dim DatosRealesBU As New Nomina.Negocios.ColaboradorRealBU

            DatosReales = DatosRealesBU.BuscarColaboradorReal(IdColaborador)
            lblSalario2.Text = DatosReales.PCantidad.ToString("c")
            Dim objetoSolicitudPrestamo As New Negocios.SolicitudPrestamoBU
            lblFaltas2.Text = objetoSolicitudPrestamo.TotalFaltasMes(IdColaborador)
            Dim objCA As New Negocios.CajaColaboradorBU
            Dim CantidadAhorro As New List(Of Entidades.CajaColaborador)
            Dim montoAcumulado As Double = 0
            CantidadAhorro = objCA.ConsultarCajaDeAhorroSaldoPrestamo(IdColaborador, IdNave)
            For Each fila As Entidades.CajaColaborador In CantidadAhorro

                montoAcumulado += fila.PMontoAcumulado
                montoAhorro = fila.PMontoAhorro

            Next
            lblCajaDeAhorro2.Text = montoAcumulado.ToString("C")
            ''Calcular antiguedad

            anios = 0
            meses = 0
            diasme = 0
            Dim FechaIngreso As Date = DatosReales.PFecha
            DiasTrabajados = (FechaActual - FechaIngreso).TotalDays

            anios = DiasTrabajados \ 365
            meses = (DiasTrabajados Mod 365) \ 30.4
            diasme = (DiasTrabajados Mod 365) Mod 30.4
            lblAntiguedad2.Text = UCase(anios.ToString + " años " + meses.ToString + " meses " + diasme.ToString + " días ")

            ''Llenar configuracion del prestamo
            llenarconfiguracionPrestamo()

            ''Llenar combo de motivos de prestamos
            MotivosPrestamo()

            ''Llenar combo de TipoDeInteres


        Catch ex As Exception
            Dim mensajeError As New AdvertenciaForm
            mensajeError.MdiParent = Me.MdiParent
            mensajeError.mensaje = "No seleccionó ningún colaborador."
            mensajeError.Show()
            lblEdad2.Text = ""

        End Try

    End Sub

    Public Sub AgregarDatos(ByVal ConfiguracionPrestamos As Entidades.ConfiguracionPrestamos)

        txtSemanas.Text = ConfiguracionPrestamos.PSemanasMaximo.ToString
        txtInteres.Text = ConfiguracionPrestamos.PInteres.ToString
        MaximoNave = ConfiguracionPrestamos.PMontoMaximoPorNave
        MaximoSemanas = ConfiguracionPrestamos.PSemanasMaximo
        lblGerente.Text = ConfiguracionPrestamos.PAutorizacionGerente
        lblDirector.Text = ConfiguracionPrestamos.PAutorizacionDirector

        MaximoColaborador = ConfiguracionPrestamos.PMontoMaximoPorColaborador
        If MaximoColaborador = 0 Then
            MaximoColaborador = 10000000
        Else
            MaximoColaborador = ConfiguracionPrestamos.PMontoMaximoPorColaborador
        End If


        If MaximoSemanas = 0 Then
            MaximoSemanas = 10000
        Else
            MaximoSemanas = ConfiguracionPrestamos.PSemanasMaximo
        End If


        'If ConfiguracionPrestamos.PInteresFijo = False Then

        'Else
        '    cmbTipoInteres.Items.Add("INTERES FIJO")
        'End If

        If ConfiguracionPrestamos.PInteresSobreSaldo = False Then

        Else
            cmbTipoInteres.Items.Add("INTERES SOBRE SALDO")
        End If

        'If ConfiguracionPrestamos.PSinInteres = False Then

        'Else
        '    cmbTipoInteres.Items.Add("SIN INTERES")
        'End If


        cmbTipoInteres.SelectedItem = "INTERES SOBRE SALDO"

    End Sub

    Public Sub llenarconfiguracionPrestamo()
        Dim listaConfiguracionPrestamos As New List(Of Entidades.ConfiguracionPrestamos)
        Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU
        Dim advertencia As New Tools.AdvertenciaForm

        listaConfiguracionPrestamos = prestamosBU.ListaConfiguracionPrestamos(IdNave)

        If listaConfiguracionPrestamos.Count > 0 Then
            For Each objeto As Entidades.ConfiguracionPrestamos In listaConfiguracionPrestamos
                AgregarDatos(objeto)
            Next
            Dim items As Integer = cmbTipoInteres.Items.Count

            If items = 1 Then
                cmbTipoInteres.SelectedIndex = items - 1
            End If
        Else
            advertencia.mensaje = "La nave no cuenta con configuración de préstamos."
            advertencia.ShowDialog()
        End If



    End Sub



    Public Sub validarPrestamo()
        Dim listaPrestamos As New List(Of Entidades.SolicitudPrestamo)
        Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU

        listaPrestamos = prestamosBU.ValidacionPrestamo(IdColaborador)

        For Each objeto As Entidades.SolicitudPrestamo In listaPrestamos
            prestamos = objeto.Pprestamoid
        Next
    End Sub

    Public Sub MotivosPrestamo()
        Dim objMotivosBU As New Nomina.Negocios.MotivosPrestamoBU
        Dim tablaMotivos As New DataTable
        tablaMotivos = objMotivosBU.MotivosNave(IdNave)
        tablaMotivos.Rows.InsertAt(tablaMotivos.NewRow, 0)
        With cmbMotivo
            .DisplayMember = "mpre_nombre"
            .ValueMember = "mpre_motivoprestamoid"
            .DataSource = tablaMotivos
        End With

        Dim items As Integer = cmbMotivo.Items.Count
        If items = 1 Then
            cmbMotivo.SelectedIndex = items - 1
        End If
    End Sub

    Private Sub btnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcular.Click
        Calcular()
    End Sub

    Public Sub Calcular()

        grdTablaAmortizacion.Rows.Clear()

        Dim Monto As Double = 0
        Dim Semanas As Integer = 1
        Dim abono As Double = 0
        Dim Interes As Double = 0
        Dim TipoInteres As String = ""
        Dim InteresPorPago As Double = 0
        Dim TotalPagado As Double = 0
        Dim fila As Integer = 0
        Dim controlSemanas As Integer = 1
        lblMensajeCaja.Text = ""


        Dim numero As Single
        'Validar que no deje campos vacios
        Try
            Dim mensajeError As New AdvertenciaForm

            ''
            If Trim(txtMonto.Text.Length) < 1 Or txtMonto.Text = "$0.00" Then
                lblMonto.ForeColor = Color.Red
                estaMal = True
            Else
                Monto = txtMonto.Text
                lblMonto.ForeColor = Color.Black
                estaMal = False
            End If
            ''
            If rbtnSemanas.Checked = True Then
                If (Trim(txtMonto.Text.Length) < 1 Or txtSemanas.Text = 0) Then
                    lblSemanas.ForeColor = Color.Red
                    estaMal = True
                Else
                    lblSemanas.ForeColor = Color.Black
                    estaMal = False
                End If
            End If
            ''
            If rbtnAbono.Checked = True Then
                If (Trim(txtMonto.Text.Length) < 1 Or txtAbono.Text = "$0.00") Then
                    lblAbono.ForeColor = Color.Red
                    estaMal = True
                Else
                    abono = txtAbono.Text
                    lblAbono.ForeColor = Color.Black
                    estaMal = False
                End If
            End If
            ''
            If Trim(txtInteres.Text.Length) < 1 Then
                lblInteres.ForeColor = Color.Red
                estaMal = True
            Else
                Interes = txtInteres.Text
                lblInteres.ForeColor = Color.Black
                estaMal = False
            End If


            If cmbTipoInteres.Text = "" Then
                lblTipoDeInteres.ForeColor = Color.Red
                estaMal = True
            Else
                TipoInteres = cmbTipoInteres.SelectedItem.ToString
                lblTipoDeInteres.ForeColor = Color.Black
                estaMal = False
            End If

            If estaMal = True Then

            Else
                If Monto > MaximoColaborador Then
                    mensajeError.MdiParent = Me.MdiParent
                    mensajeError.mensaje = "El máximo a prestar es $" + MaximoColaborador.ToString
                    mensajeError.Show()

                Else

                    Dim FechaFin As DateTime
                    FechaFin = "01/01/1900"
                    FechaFin = ValidarCajaahorro()
                    Dim nSem As Integer
                    Dim montoAcumuladoCajaAhorro As Double = 0
                    If FechaFin <> "01/01/1900" Then
                        nSem = DateDiff("ww", CDate(Today.Date), CDate(FechaFin))
                    End If
                    montoAcumuladoCajaAhorro = (nSem * montoAhorro + CDbl(lblCajaDeAhorro2.Text))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''CALCULAR POR ABONO''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''

                    If rbtnAbono.Checked = True Then
                        Interes = 7 * (Interes / 30.4)
                        Interes = Interes / 100

                        abono = txtAbono.Text
                        numero = Monto / abono
                        numero = -Int(-numero)


                        If numero > MaximoSemanas Then

                            mensajeError.MdiParent = Me.MdiParent
                            mensajeError.mensaje = "Se excede en el número de semanas para pagar. El máximo es" + MaximoSemanas.ToString + "."
                            mensajeError.Show()
                        Else

                            If Monto < abono Then
                                mensajeError.MdiParent = Me.MdiParent
                                mensajeError.mensaje = "El abono no puede ser mayor al monto a prestar."
                                mensajeError.Show()
                            Else
                                If txtAbono.Text = 0 Or txtMonto.Text = 0 Then
                                    mensajeError.MdiParent = Me.MdiParent
                                    mensajeError.mensaje = "No puede dejar columnas con valores en $0.00 ."
                                    mensajeError.Show()

                                Else

                                    grdTablaAmortizacion.Rows.Clear()

                                    fila = 0

                                    ''CALCULAR INTERES FIJO SI ES POR ABONO

                                    If TipoInteres.Equals("INTERES FIJO") Or TipoInteres.Equals("INTERES SOBRE SALDO") Then
                                        Interes = 0
                                        Interes = 7 * (txtInteres.Text / 30.4)
                                        Interes = Interes / 100
                                        abono = txtAbono.Text
                                        numero = Monto / abono
                                        numero = -Int(-numero)
                                        Interes = Monto * Interes


                                        If Interes > abono Then
                                            mensajeError.MdiParent = Me.MdiParent
                                            mensajeError.mensaje = "El abono mínimo es de " + Interes.ToString("c") + "."
                                            mensajeError.Show()
                                            grdTablaAmortizacion.Rows.Clear()
                                            'btnImprimir.Enabled = False
                                            'lblImprimir.Enabled = False
                                            btnGuardar.Enabled = False
                                            lblGuardar.Enabled = False
                                        Else

                                            If TipoInteres.Equals("INTERES FIJO") Then


                                                Interes = Interes
                                                abono = abono - Interes
                                                InteresPorPago = Interes
                                                TotalPagado = InteresPorPago + abono

                                                While Monto > 0

                                                    If Monto < abono Then
                                                        Dim abonofinal As Double = Monto
                                                        Monto = Monto - abonofinal
                                                        TotalPagado = abonofinal + InteresPorPago

                                                        Me.grdTablaAmortizacion.Rows.Insert(fila, Semanas, abonofinal, InteresPorPago, TotalPagado, Monto)
                                                        Monto = 0
                                                        Semanas = Semanas + 1
                                                    Else
                                                        If nSem = Semanas Then
                                                            lblMensajeCaja.Text = "EN EL PAGO NUMERO " + nSem.ToString + " SE DESCONTARA DEL ACUMULADO EN CAJA DE AHORRO " + vbNewLine + "EL MONTO MOSTRADO PUEDE VARIAR."
                                                        End If
                                                        '    If Monto < montoAcumuladoCajaAhorro Then
                                                        '        Dim abonoFinal As Double = Monto
                                                        '        Monto = Monto - abonoFinal
                                                        '        TotalPagado = abonoFinal
                                                        '        Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, abonoFinal, 0, TotalPagado, Monto)
                                                        '        Semanas = Semanas + 1
                                                        '    Else
                                                        '        Monto = Monto - montoAcumuladoCajaAhorro

                                                        '        Me.grdTablaAmortizacion.Rows.Insert(fila, Semanas, montoAcumuladoCajaAhorro, 0, montoAcumuladoCajaAhorro, Monto)
                                                        '        Semanas = Semanas + 1

                                                        '    End If

                                                        'Else
                                                        Monto = Monto - abono
                                                        Me.grdTablaAmortizacion.Rows.Insert(fila, Semanas, abono, InteresPorPago, TotalPagado, Monto)
                                                        Semanas = Semanas + 1
                                                        End If

                                                        'End If
                                                        fila += 1
                                                        '  TotalInteres += InteresPorPago
                                                        '  TotalTotales += TotalPagado
                                                End While
                                                txtSemanas.Text = Semanas - 1
                                                ' lblInteresTotal2.Text = TotalInteres

                                                btnGuardar.Enabled = True
                                                lblGuardar.Enabled = True
                                                'btnImprimir.Enabled = True
                                                'lblImprimir.Enabled = True

                                                'lblPagoTotal.Enabled = True
                                                'lblPagoTotal2.Enabled = True
                                                '' lblPagoTotal2.Text = TotalTotales.ToString("c")
                                                'lblInteresTotal.Enabled = True
                                                'lblInteresTotal2.Enabled = True
                                                ' lblInteresTotal2.Text = TotalInteres.ToString("c")
                                                lblJustificacion.ForeColor = Color.Black
                                                ' TotalInteres = 0
                                                '  TotalTotales = 0

                                            End If


                                            ''CALCULAR INTERES SOBRE SALDO SI ES POR ABONO
                                            If TipoInteres.Equals("INTERES SOBRE SALDO") Then
                                                grdTablaAmortizacion.Rows.Clear()
                                                fila = 0
                                                Dim interesMonto As Double
                                                Dim AbonoSobreSaldo As Double

                                                While Monto > 0

                                                    Interes = 0
                                                    Interes = 7 * (txtInteres.Text / 30.4)
                                                    Interes = Interes / 100
                                                    abono = txtAbono.Text
                                                    numero = Monto / abono
                                                    numero = -Int(-numero)
                                                    Interes = Monto * Interes


                                                    interesMonto = Interes
                                                    AbonoSobreSaldo = abono - interesMonto
                                                    InteresPorPago = interesMonto
                                                    TotalPagado = InteresPorPago + AbonoSobreSaldo


                                                    If Monto < abono Then
                                                        Dim abonofinal As Double = Monto
                                                        Monto = Monto - abonofinal
                                                        TotalPagado = abonofinal + InteresPorPago

                                                        Me.grdTablaAmortizacion.Rows.Insert(fila, Semanas, abonofinal, InteresPorPago, TotalPagado, Monto)
                                                        Monto = 0
                                                        Semanas = Semanas + 1

                                                    Else
                                                        If nSem = Semanas Then
                                                            lblMensajeCaja.Text = "EN EL PAGO NUMERO " + nSem.ToString + " SE DESCONTARA DEL ACUMULADO EN CAJA DE AHORRO " + vbNewLine + "EL MONTO MOSTRADO PUEDE VARIAR."
                                                        End If
                                                        '    If Monto < montoAcumuladoCajaAhorro Then
                                                        '        Dim abonoFinal As Double = Monto
                                                        '        Monto = Monto - abonoFinal
                                                        '        TotalPagado = abonoFinal
                                                        '        Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, abonoFinal, 0, TotalPagado, Monto)
                                                        '        Semanas = Semanas + 1
                                                        '    Else
                                                        '        Monto = Monto - montoAcumuladoCajaAhorro

                                                        '        Me.grdTablaAmortizacion.Rows.Insert(fila, Semanas, montoAcumuladoCajaAhorro, 0, montoAcumuladoCajaAhorro, Monto)
                                                        '        Semanas = Semanas + 1

                                                        '    End If
                                                        'Else
                                                        Monto = Monto - AbonoSobreSaldo
                                                        Me.grdTablaAmortizacion.Rows.Insert(fila, Semanas, AbonoSobreSaldo, InteresPorPago, TotalPagado, Monto)
                                                        Semanas = Semanas + 1
                                                        'End If

                                                        End If

                                                        fila += 1
                                                        ' TotalInteres += InteresPorPago
                                                        '  TotalTotales += TotalPagado
                                                End While
                                                txtSemanas.Text = Semanas - 1
                                                btnGuardar.Enabled = True
                                                lblGuardar.Enabled = True
                                                'btnImprimir.Enabled = True
                                                'lblImprimir.Enabled = True

                                                'lblPagoTotal.Enabled = True
                                                'lblPagoTotal2.Enabled = True
                                                ''    lblPagoTotal2.Text = TotalTotales.ToString("c")
                                                'lblInteresTotal.Enabled = True
                                                'lblInteresTotal2.Enabled = True
                                                '' lblInteresTotal2.Text = TotalInteres.ToString("c")
                                                'lblJustificacion.ForeColor = Color.Black
                                                ''  TotalInteres = 0
                                                '   TotalTotales = 0




                                            End If
                                        End If
                                    End If

                                    ''CALCULAR SIN INTERES SI ES POR ABONO
                                    If TipoInteres.Equals("SIN INTERES") Then
                                        grdTablaAmortizacion.Rows.Clear()
                                        fila = 0
                                        While Monto > 0
                                            InteresPorPago = 0

                                            If Monto < abono Then
                                                Dim abonofinal As Double = Monto
                                                Monto = Monto - abonofinal
                                                TotalPagado = abonofinal + InteresPorPago

                                                Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, abonofinal, InteresPorPago, TotalPagado, Monto)
                                                Monto = 0
                                                Semanas = Semanas + 1

                                            Else
                                                If nSem = Semanas Then
                                                    lblMensajeCaja.Text = "EN EL PAGO NUMERO " + nSem.ToString + " SE DESCONTARA DEL ACUMULADO EN CAJA DE AHORRO " + vbNewLine + "EL MONTO MOSTRADO PUEDE VARIAR."
                                                End If
                                                '    If Monto < montoAcumuladoCajaAhorro Then
                                                '        Dim abonoFinal As Double = Monto
                                                '        Monto = Monto - abonoFinal
                                                '        TotalPagado = abonoFinal
                                                '        Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, abonoFinal, 0, TotalPagado, Monto)
                                                '        Semanas = Semanas + 1
                                                '    Else
                                                '        Monto = Monto - montoAcumuladoCajaAhorro

                                                '        Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, montoAcumuladoCajaAhorro, 0, montoAcumuladoCajaAhorro, Monto)
                                                '        Semanas = Semanas + 1
                                                '    End If

                                                'Else
                                                TotalPagado = InteresPorPago + abono
                                                Monto = Monto - abono
                                                Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, abono, InteresPorPago, TotalPagado, Monto)
                                                Semanas = Semanas + 1
                                                'End If

                                                End If

                                                fila += 1
                                                '  TotalInteres += InteresPorPago
                                                '  TotalTotales += TotalPagado
                                                '
                                        End While
                                        txtSemanas.Text = Semanas - 1

                                        btnGuardar.Enabled = True
                                        lblGuardar.Enabled = True
                                        'btnImprimir.Enabled = True
                                        'lblImprimir.Enabled = True

                                        'lblPagoTotal.Enabled = True
                                        'lblPagoTotal2.Enabled = True
                                        '' lblPagoTotal2.Text = TotalTotales.ToString("c")
                                        'lblInteresTotal.Enabled = True
                                        'lblInteresTotal2.Enabled = True
                                        ' lblInteresTotal2.Text = TotalInteres.ToString("c")
                                        lblJustificacion.ForeColor = Color.Black
                                        ' TotalInteres = 0
                                        '  TotalTotales = 0




                                    End If
                                End If
                            End If
                        End If
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''CALCULAR POR SEMANA''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''

                    If rbtnSemanas.Checked = True Then
                        Interes = 7 * (Interes / 30.4)
                        Interes = Interes / 100

                        If txtSemanas.Text = 0 Or txtMonto.Text = 0 Then

                            mensajeError.MdiParent = Me.MdiParent
                            mensajeError.mensaje = "No puede dejar columnas con valores en $0.00 ."
                            mensajeError.Show()
                        Else
                            grdTablaAmortizacion.Rows.Clear()
                            Semanas = txtSemanas.Text

                            ''CALCULAR INTERES FIJO  SI ES POR SEMANA

                            If TipoInteres.Equals("INTERES FIJO") Then
                                grdTablaAmortizacion.Rows.Clear()

                                abono = Monto / Semanas
                                fila = 0
                                controlSemanas = 1

                                Interes = Monto * Interes
                                TotalPagado = Interes + abono
                                txtAbono.Text = TotalPagado.ToString("c")

                                While Monto > 0

                                    If Monto < abono Then
                                        Dim abonofinal As Double = Monto
                                        Monto = Monto - abonofinal
                                        TotalPagado = abonofinal + Interes

                                        Me.grdTablaAmortizacion.Rows.Insert(fila, controlSemanas, abonofinal, Interes, TotalPagado, Monto)
                                        Monto = 0
                                        Semanas = 0
                                        controlSemanas = controlSemanas + 1
                                    Else

                                        ''''''''''
                                        If nSem = controlSemanas Then
                                            lblMensajeCaja.Text = "EN EL PAGO NUMERO " + nSem.ToString + " SE DESCONTARA DEL ACUMULADO EN CAJA DE AHORRO " + vbNewLine + "EL MONTO MOSTRADO PUEDE VARIAR."
                                            If Monto < montoAcumuladoCajaAhorro Then
                                                Dim abonoFinal As Double = Monto
                                                Monto = Monto - abonoFinal
                                                TotalPagado = abonoFinal
                                                Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, abonoFinal, 0, TotalPagado, Monto)
                                                controlSemanas = controlSemanas + 1
                                                Semanas = 0
                                            Else
                                                Monto = Monto - montoAcumuladoCajaAhorro

                                                Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, montoAcumuladoCajaAhorro, 0, montoAcumuladoCajaAhorro, Monto)
                                                controlSemanas = controlSemanas + 1
                                                Semanas = Semanas - 1
                                            End If

                                        Else
                                            Monto = Monto - abono
                                            Me.grdTablaAmortizacion.Rows.Insert(fila, controlSemanas, abono, Interes, TotalPagado, Monto)
                                            Semanas = Semanas - 1
                                            controlSemanas = controlSemanas + 1
                                        End If
                                        ''


                                    End If
                                    fila += 1
                                    '   TotalInteres += Interes
                                    '   TotalTotales += TotalPagado
                                End While

                                btnGuardar.Enabled = True
                                lblGuardar.Enabled = True
                                'btnImprimir.Enabled = True
                                'lblImprimir.Enabled = True

                                'lblPagoTotal.Enabled = True
                                'lblPagoTotal2.Enabled = True
                                ''   lblPagoTotal2.Text = TotalTotales.ToString("c")
                                'lblInteresTotal.Enabled = True
                                'lblInteresTotal2.Enabled = True
                                '  lblInteresTotal2.Text = TotalInteres.ToString("c")
                                lblJustificacion.ForeColor = Color.Black
                                ' TotalInteres = 0
                                '  TotalTotales = 0

                            End If

                            ''CALCULAR INTERES SOBRE SALDO SI ES POR SEMANA

                            If TipoInteres.Equals("INTERES SOBRE SALDO") Then
                                Dim interesMonto As Double


                                grdTablaAmortizacion.Rows.Clear()
                                abono = Monto / Semanas

                                controlSemanas = 1

                                While Semanas > 0

                                    interesMonto = Monto * Interes
                                    InteresPorPago = interesMonto
                                    TotalPagado = InteresPorPago + abono

                                    If Monto < abono Then
                                        Dim abonofinal As Double = Monto
                                        Monto = Monto - abonofinal
                                        TotalPagado = abonofinal + InteresPorPago
                                        Monto = 0
                                        Semanas = Semanas - 1
                                        controlSemanas = controlSemanas + 1
                                    Else
                                        Monto = Monto - abono
                                        Semanas = Semanas - 1
                                        controlSemanas = controlSemanas + 1
                                    End If

                                    TotalTotales += TotalPagado
                                    '
                                End While

                                ''PARA SACAR EL ABONO FIJO
                                Dim totalAbono As Double
                                Dim abonoPago As Double
                                Dim TotalTotales2 As Double = 0
                                Monto = txtMonto.Text
                                Semanas = txtSemanas.Text
                                fila = 0
                                Dim promedioPago As Double = TotalTotales / (controlSemanas - 1)
                                txtAbono.Text = promedioPago.ToString("c")

                                While Monto > 0

                                    interesMonto = Monto * Interes
                                    abonoPago = promedioPago - interesMonto


                                    If Monto < promedioPago Then
                                        Dim abonoFinal As Double = Monto
                                        promedioPago = Monto + interesMonto
                                        Monto = Monto - abonoFinal

                                        Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, abonoFinal, interesMonto, promedioPago, Monto)
                                        Semanas = 0
                                        Monto = 0
                                        totalAbono += abonoFinal
                                    Else
                                        If nSem = grdTablaAmortizacion.Rows.Count + 1 Then
                                            lblMensajeCaja.Text = "EN EL PAGO NUMERO " + nSem.ToString + " SE DESCONTARA DEL ACUMULADO EN CAJA DE AHORRO " + vbNewLine + "EL MONTO MOSTRADO PUEDE VARIAR."
                                        End If
                                        '    If Monto < montoAcumuladoCajaAhorro Then
                                        '        Dim abonoFinal As Double = Monto
                                        '        Monto = Monto - abonoFinal
                                        '        TotalPagado = abonoFinal
                                        '        Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, abonoFinal, 0, TotalPagado, Monto)
                                        '        controlSemanas = controlSemanas + 1
                                        '        Semanas = 0
                                        '    Else
                                        '        Monto = Monto - montoAcumuladoCajaAhorro
                                        '        TotalPagado = montoAcumuladoCajaAhorro
                                        '        Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, montoAcumuladoCajaAhorro, 0, TotalPagado, Monto)
                                        '        controlSemanas = controlSemanas + 1
                                        '        Semanas = Semanas - 1
                                        '    End If
                                        'Else
                                        Monto = Monto - abonoPago
                                        Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, abonoPago, interesMonto, promedioPago, Monto)
                                        Semanas = Semanas - 1
                                        controlSemanas = controlSemanas + 1
                                        totalAbono += abonoPago
                                        'End If
                                        End If

                                End While


                                btnGuardar.Enabled = True
                                lblGuardar.Enabled = True

                                lblJustificacion.ForeColor = Color.Black

                                TotalTotales = 0
                                TotalTotales2 = 0
                            End If



                            ''CALCULAR SIN INTERES SI ES POR SEMANA
                            If TipoInteres.Equals("SIN INTERES") Then
                                grdTablaAmortizacion.Rows.Clear()
                                abono = Monto / Semanas
                                fila = 0
                                controlSemanas = 1

                                While Semanas > 0
                                    InteresPorPago = 0
                                    TotalPagado = InteresPorPago + abono
                                    txtAbono.Text = TotalPagado.ToString("c")
                                    If Monto < abono Then
                                        Dim abonofinal As Double = Monto
                                        Monto = Monto - abonofinal
                                        TotalPagado = abonofinal + InteresPorPago
                                        Me.grdTablaAmortizacion.Rows.Insert(fila, controlSemanas, abonofinal, InteresPorPago, TotalPagado, Monto)
                                        Monto = 0
                                        Semanas = 0
                                        controlSemanas = controlSemanas + 1
                                    Else
                                        If nSem = grdTablaAmortizacion.Rows.Count + 1 Then
                                            lblMensajeCaja.Text = "EN EL PAGO NUMERO " + nSem.ToString + " SE DESCONTARA DEL ACUMULADO EN CAJA DE AHORRO " + vbNewLine + "EL MONTO MOSTRADO PUEDE VARIAR."
                                        End If
                                        '    If Monto < montoAcumuladoCajaAhorro Then
                                        '        Dim abonoFinal As Double = Monto
                                        '        Monto = Monto - abonoFinal
                                        '        TotalPagado = abonoFinal
                                        '        Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, abonoFinal, 0, TotalPagado, Monto)
                                        '        controlSemanas = controlSemanas + 1
                                        '        Semanas = 0
                                        '    Else
                                        '        Monto = Monto - montoAcumuladoCajaAhorro

                                        '        Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, montoAcumuladoCajaAhorro, 0, montoAcumuladoCajaAhorro, Monto)
                                        '        controlSemanas = controlSemanas + 1
                                        '        Semanas = Semanas - 1
                                        '    End If
                                        'Else


                                        Monto = Monto - abono
                                        Me.grdTablaAmortizacion.Rows.Insert(fila, controlSemanas, abono, InteresPorPago, TotalPagado, Monto)
                                        Semanas = Semanas - 1
                                        controlSemanas = controlSemanas + 1
                                        'End If
                                        End If
                                        fila += 1

                                End While
                                txtAbono.Text = abono.ToString("c")
                                btnGuardar.Enabled = True
                                lblGuardar.Enabled = True
                                lblJustificacion.ForeColor = Color.Black






                            End If
                        End If
                    End If
                End If


                Dim totalAbono2 As Double = 0
                Pagototal2 = 0
                Dim contadorFilas As Integer = 0
                totalInteres2 = 0
                For Each row As DataGridViewRow In grdTablaAmortizacion.Rows
                    totalInteres2 += row.Cells("clmInteres").Value
                    totalAbono2 += row.Cells("clmAbonoACapital").Value
                    Pagototal2 += row.Cells("clmTotal").Value
                    contadorFilas += 1

                Next

                grdTablaAmortizacion.Rows.Add("", totalAbono2, totalInteres2, Pagototal2, "")
                grdTablaAmortizacion.Rows(contadorFilas).DefaultCellStyle.BackColor = Color.GreenYellow
                'lblAbonoTotal2.Enabled = True
                'lblAbonoTotal2.Text = totalAbono2.ToString("c")

                'lblInteresTotal2.Enabled = True
                'lblInteresTotal2.Text = totalInteres2.ToString("c")

                'lblPagoTotal2.Enabled = True
                'lblPagoTotal2.Text = Pagototal2.ToString("c")
            End If





        Catch ex As Exception
            Dim mensajeError As New AdvertenciaForm
            mensajeError.MdiParent = Me.MdiParent
            mensajeError.mensaje = "Para calcular el préstamo requiere capturar toda la información."
            mensajeError.Show()
        End Try

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        ''Estas seguro??

        Dim mensajeError As New AdvertenciaForm
        Dim justificacion As String = ""


        If IsDBNull(cmbMotivo.SelectedValue) Or txtJustificacion.Text = "" Then

            mensajeError.MdiParent = Me.MdiParent
            mensajeError.mensaje = "Para guardar el préstamo requiere capturar toda la información."
            mensajeError.Show()

        Else
            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = "¿Estas seguro de querer dar de alta el préstamo? "

            If mensajeExito.ShowDialog = DialogResult.OK Then
                Calcular()
                If estaMal = False Then
                    guardar()
                    enviar_correo(IdNave, "ENVIO_NOTIFICACION_ALTA_PRESTAMO")
                End If



            End If

        End If


    End Sub

    Public Sub guardar()

        Dim objBU = New Nomina.Negocios.SolicitudPrestamoBU
        Dim ObjEnt = New Entidades.SolicitudPrestamo
        Dim ColaboradorId As New Entidades.Colaborador
        Try
            ColaboradorId.PColaboradorid = IdColaborador
            ColaboradorId.PNaveID = IdNave
            ObjEnt.Pcolaborador = ColaboradorId
            ObjEnt.Pusuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            ObjEnt.Pmontoprestamo = txtMonto.Text
            ObjEnt.Pinteres = txtInteres.Text
            ObjEnt.Pmotivoprestamoid = (Int(cmbMotivo.SelectedValue))
            '  ObjEnt.Pmotivoprestamoid = cmbMotivo.SelectedIndex
            ObjEnt.Psemanas = txtSemanas.Text
            ObjEnt.Ptotalinteres = CDbl(totalInteres2)
            ObjEnt.Pestatus = "A"


            ObjEnt.Psaldo = txtMonto.Text
            Dim justificacion As String = txtJustificacion.Text
            ObjEnt.Pjustificacion = justificacion
            ObjEnt.Pabono = txtAbono.Text

            Dim interesTipo As String = cmbTipoInteres.SelectedItem.ToString

            If interesTipo.Equals("INTERES FIJO") Then

                ObjEnt.Ptipointeres = "F"
            Else
                If interesTipo.Equals("INTERES SOBRE SALDO") Then
                    ObjEnt.Ptipointeres = "S"

                Else

                    If interesTipo.Equals("SIN INTERES") Then
                        ObjEnt.Ptipointeres = "I"

                    End If
                End If
            End If



            ''Guardar mandando mensaje
            objBU.guardarPrestamos(ObjEnt)
            btnGuardar.Enabled = False
            lblGuardar.Enabled = False
            btnCalcular.Enabled = False
            lblCalcular.Enabled = False
            Dim mensajeExito As New ExitoForm
            mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "Préstamo Guardado."
            mensajeExito.Show()
            Me.Close()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub enviar_correo(ByVal naveID As Integer, ByVal clave As String)

        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String
        Dim correo As New Tools.Correo
        Dim fecha As DateTime = Now.Date
        destinatarios = enviosCorreoBU.consulta_destinatarios_email(naveID, clave)

        Dim Email As String = ""
        Email += "<!DOCTYPE html>"
        Email += "<html> "
        Email += "<head> "
        Email += "<style type = '" + "text/css" + "'>"
        Email += "body {display: block; margin: 8px; background: #FFFFFF;}"
        Email += "#header{	position: absolute;"
        Email += "height: 62px;"
        'Email += "margin: 1% 1%;"
        Email += "top: 0;"
        Email += "left: 0;"
        Email += "right: 0;"
        Email += "color: #003366;"
        Email += "font-family: Arial, Helvetica, sans-serif;"
        Email += "font-size: 18px;"
        Email += "font-weight: bold;}"

        Email += "#content   {width: 90%;"
        Email += "position: fixed;"
        Email += "margin: 0% 0%;"
        Email += "padding-top: 15%;"
        Email += "padding-bottom: 1%;}"

        Email += "table.tableizer-table { 	font-family: Arial, Helvetica, sans-serif;"
        Email += "font-size: 9px;}"

        Email += ".tableizer-table td {	padding: 4px;"
        Email += "margin: 0px;"
        Email += "border: 1px solid #FFFFFF;"
        Email += "                     	border-color: #FFFFFF;"
        Email += "border: 1px solid #CCCCCC;"
        Email += "width: 200px;}"

        Email += ".tableizer-table tr {	padding: 4px;"
        Email += "margin: 0;"
        Email += "color: #003366;"
        Email += "font-weight: bold;"
        Email += "background-color: #transparent;"
        Email += "opacity: 1;}"

        Email += ".tableizer-table th {	background-color: #003366;"
        Email += "color: #FFFFFF;"
        Email += "font-weight: bold;"
        Email += "height: 30px;"
        Email += "font-size: 10px;}"

        Email += "</style> "

        Email += "</head> "
        Email += "<body> "
        'Email += "<div id='" + "wrapper" + "' >"
        Email += "<div id='" + "header" + "' >"
        Email += " <img src='" + "http://grupoyuyin.com.mx/images/SAY170.jpg" + "' height='" + "60" + "' width='" + "60" + "'alt='" + "logo" + "'>"
        Email += "<br><h1>Solicitud de préstamo</h1>  "
        Email += "<br><h5>Usuario creo:" + Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString + " <h5>"
        Email += "<br><h5>Fecha creación:" + Now.Date.ToShortDateString.ToString + "<h5>"
        Email += "</div>"


        Email += "<div id= '" + "content" + "'>"
        Email += "<table id='" + "mi_tabla" + "'  class='" + "tableizer-table" + "'>"
        Email += "<thead>"
        Email += "<tr class='" + "tableizer-firstrow" + "'>"
        Email += "<th width ='" + "20%" + "'>Colaborador</th>"
        Email += "<th width ='" + "20%" + "'>Antigüedad</th>"
        Email += "<th>Nave</th>"
        Email += "<th>Departamento</th>"
        Email += "<th width ='" + "20%" + "'>Puesto</th>"
        Email += "<th>Salario</th>"
        Email += "<th>Monto</th>"
        Email += "<th>Semanas</th>"
        Email += "<th>Abono</th>"
        Email += "<th>Interés mensual</th>"
        Email += "<th>Monto+interés</th>"
        Email += "<th width ='" + "20%" + "'>Tipo interés</th>"
        Email += "<th>Motivo</th>"
        Email += "<th width ='" + "20%" + "'>Justificación</th>"
        Email += "</tr>"
        Email += "</thead>"
        Email += "<tbody>"
        Email += "<tr>"
        Email += "<td>" + lblColaborador2.Text.ToUpper + " </td>"
        Email += "<td>" + lblAntiguedad2.Text.ToUpper + "</td>"
        Email += "<td>" + lblNave2.Text.ToUpper + "</td>"
        Email += "<td> " + lblDepartamento2.Text.ToUpper + " </td>"
        Email += "<td> " + lblPuesto2.Text.ToUpper + " </td>"
        Email += "<td> " + lblSalario2.Text + " </td>"
        Email += "<td>" + txtMonto.Text.ToString + "</td>"
        Email += "<td>" + txtSemanas.Text.ToString + "</td>"
        Email += "<td>" + txtAbono.Text.ToString + "</td>"
        Email += "<td> " + txtInteres.Text.ToString + "%</td>"
        Email += "<td>" + Pagototal2.ToString("C") + "</td>"
        Email += "<td> " + cmbTipoInteres.Text.ToString.ToUpper + "</td>"
        Email += "<td>" + cmbMotivo.Text.ToString.ToUpper + " </td>"
        Email += "<td>" + txtJustificacion.Text.ToString.ToUpper + " </td>"
        Email += "</tr>"
        Email += "</tbody>"
        Email += "</table>"
        Email += "</div>"
        Email += "</body> "
        Email += "</html> "
        correo.EnviarCorreoHtml(destinatarios, "say_nomina@grupoyuyin.com.mx", "Solicitud de prestamo", Email)

    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress

        Dim caracter As Char = e.KeyChar
        If (caracter = ChrW(Keys.Back)) Then
            e.Handled = False
        Else
            If Not IsNumeric(e.KeyChar) Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub txtSemanas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSemanas.KeyPress
        Dim caracter As Char = e.KeyChar
        If (caracter = ChrW(Keys.Back)) Then
            e.Handled = False
        Else
            If Not IsNumeric(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtAbono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAbono.KeyPress
        Dim abono As String = txtAbono.Text
        Dim caracter As Char = e.KeyChar
        If abono.IndexOf(".") > 0 Then
            txtMonto.MaxLength = abono.IndexOf(".") + 3
        End If
        If abono.Contains(".") = False Or (caracter = ChrW(Keys.Back)) Then
            e.Handled = False
        Else
            If Not IsNumeric(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtInteres_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInteres.KeyPress
        Dim Interes As String = txtInteres.Text
        Dim caracter As Char = e.KeyChar
        If Interes.IndexOf(".") > 0 Then
            txtMonto.MaxLength = Interes.IndexOf(".") + 3
        End If
        If Interes.Contains(".") = False Or (caracter = ChrW(Keys.Back)) Then
            e.Handled = False
        Else
            If Not IsNumeric(e.KeyChar) Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar()
    End Sub

    Public Sub limpiar()
        ''pic box
        picBoxColaborador.Image = My.Resources.YUMPER1


        ''Grid
        grdTablaAmortizacion.Rows.Clear()

        ''Etiquetas
        lblColaborador2.Text = ""
        lblEdad2.Text = ""
        lblAntiguedad2.Text = ""
        lblCajaDeAhorro2.Text = ""
        lblFaltas2.Text = ""
        lblPuesto2.Text = ""
        lblNave2.Text = ""
        lblDepartamento2.Text = ""
        lblSalario2.Text = ""
        'lblInteresTotal2.Text = ""
        'lblPagoTotal2.Text = ""





        'lblInteresTotal2.Enabled = False
        'lblPagoTotal2.Enabled = False



        ''Combos
        cmbMotivo.DataSource = Nothing
        cmbMotivo.DisplayMember = Nothing
        cmbMotivo.ValueMember = Nothing
        cmbTipoInteres.Items.Clear()
        cmbMotivo.Enabled = False
        cmbTipoInteres.Enabled = False

        ''Botones
        btnLimpiar.Enabled = False
        lblLimpiar.Enabled = False
        btnCalcular.Enabled = False
        lblCalcular.Enabled = False
        btnGuardar.Enabled = False
        lblGuardar.Enabled = False
        btnBuscar.Enabled = True
        lblBuscar.Enabled = True
        'btnImprimir.Enabled = False
        'lblImprimir.Enabled = False

        ''radio button
        rbtnSemanas.Checked = True
        rbtnAbono.Enabled = False
        rbtnSemanas.Enabled = False



        ''Cajas de texto
        txtAbono.Text = ""
        txtInteres.Text = ""
        txtSemanas.Text = ""
        txtMonto.Text = ""
        txtJustificacion.Text = ""

        txtMonto.Enabled = False
        txtSemanas.Enabled = False
        txtAbono.Enabled = False
        txtInteres.Enabled = False
        txtJustificacion.Enabled = False


        lblMonto.ForeColor = Color.Black
        lblSemanas.ForeColor = Color.Black
        lblAbono.ForeColor = Color.Black
        lblInteres.ForeColor = Color.Black
        lblJustificacion.ForeColor = Color.Black
        lblMotivo.ForeColor = Color.Black
        lblTipoDeInteres.ForeColor = Color.Black



    End Sub

    Private Sub rbtnSemanas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnSemanas.CheckedChanged
        If rbtnSemanas.Checked = True Then
            txtAbono.Text = ""
            txtAbono.Enabled = False
            txtSemanas.Enabled = True
            txtSemanas.Focus()
            lblAbono.ForeColor = Color.Black
        End If
    End Sub

    Private Sub rbtnAbono_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAbono.CheckedChanged
        If rbtnAbono.Checked = True Then
            txtSemanas.Text = ""
            txtSemanas.Enabled = False
            txtAbono.Enabled = True
            txtAbono.Focus()
            lblSemanas.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtMonto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMonto.LostFocus

        Try
            txtMonto.Text = Format(CType(Me.txtMonto.Text, Decimal), "c")
            lblMonto.ForeColor = Color.Black
        Catch ex As Exception
            lblMonto.ForeColor = Color.Red
        End Try
    End Sub

    Private Sub txtAbono_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAbono.LostFocus
        If rbtnAbono.Checked = True Then
            Try
                txtAbono.Text = Format(CType(Me.txtAbono.Text, Decimal), "c")
                lblAbono.ForeColor = Color.Black

            Catch ex As Exception
                lblAbono.ForeColor = Color.Red

            End Try

        End If
    End Sub

    Private Sub txtSemanas_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSemanas.LostFocus
        If rbtnSemanas.Checked = True Then
            Try
                txtSemanas.Text = Format(CType(Me.txtSemanas.Text, Decimal), "N0")
                lblSemanas.ForeColor = Color.Black

            Catch ex As Exception
                lblSemanas.ForeColor = Color.Red

            End Try

        End If
    End Sub

    Private Sub txtinteres_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInteres.LostFocus

        Try
            txtInteres.Text = Format(CType(Me.txtInteres.Text, Decimal), "N2")
            lblInteres.ForeColor = Color.Black
        Catch ex As Exception
            lblInteres.ForeColor = Color.Red
        End Try
    End Sub

    Private Sub txtJustificacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJustificacion.KeyPress
        If Char.IsLower(e.KeyChar) Then
            txtJustificacion.SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If
    End Sub

    Private Sub txtJustificacion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtJustificacion.LostFocus

        Try
            ' txtJustificacion.Text = Format(CType(Me.txtJustificacion.Text, Decimal), "N0")
            If Trim(txtJustificacion.Text) <> "" Then
                lblJustificacion.ForeColor = Color.Black
            Else
                lblJustificacion.ForeColor = Color.Red
            End If

        Catch ex As Exception
            lblJustificacion.ForeColor = Color.Red

        End Try


    End Sub

    Private Sub btnCancelarPrestamo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objCancelar As New CancelarPrestamosForm
        objCancelar.Show()

    End Sub

    Private Sub btnAbajo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grbParametros.Height = 352
    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grbParametros.Height = 45
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click_1(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim empleadosForm As New BuscarEmpleadoForm

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        empleadosForm.grdBuscarEmpleado.Rows.Clear()
        txtMonto.Focus()


        If empleadosForm.ShowDialog = DialogResult.OK Then

            IdColaborador = empleadosForm.pseleccion
            validarPrestamo()

            If prestamos > 0 Then
                Dim mensajeError As New AdvertenciaForm
                mensajeError.MdiParent = Me.MdiParent
                mensajeError.mensaje = "El colaborador tiene un préstamo en proceso, no puede solicitar otro por el momento."
                mensajeError.Show()
                prestamos = 0
            Else

                limpiar()
                llenarParametros()
                btnBuscar.Enabled = False
                lblBuscar.Enabled = False

                btnCalcular.Enabled = True
                lblCalcular.Enabled = True

                btnLimpiar.Enabled = True
                lblLimpiar.Enabled = True

                txtMonto.Enabled = True
                txtSemanas.Enabled = True

                'txtInteres.Enabled = True
                txtJustificacion.Enabled = True

                rbtnSemanas.Enabled = True
                rbtnAbono.Enabled = True
                cmbMotivo.Enabled = True
                cmbTipoInteres.Enabled = True

            End If
        End If
        lblMonto.ForeColor = Color.Black
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnLimpiar_Click_1(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub

    Public Function ValidarCajaahorro()
        Dim ObjBU As New Negocios.SolicitudPrestamoBU
        Dim ListaCajaAhorro As New List(Of Entidades.SolicitudPrestamo)
        Dim fechaFin As DateTime = "01/01/1900"
        ListaCajaAhorro = ObjBU.FechasCajaAhorro(IdNave)

        For Each fila As Entidades.SolicitudPrestamo In ListaCajaAhorro
            fechaFin = fila.PFechaFinCaja.ToShortDateString
        Next
        Return fechaFin
    End Function


End Class