Imports System.Net

Public Class SolicitudPrestamos
    Public Property MaxLength As Integer
    Dim IdColaborador As Integer = 0
    Dim IdNave As Integer = 0
    Dim valorFormato As String
    Dim MaximoNave As Double = 0
    Dim MaximoColaborador As Double = 0
    Dim MaximoSemanas As Integer = 0
    Dim prestamos As Integer = 0
    Dim TotalInteres As Double = 0
    Dim TotalTotales As Double = 0


    Private Sub SolicitudPrestamos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        picBoxColaborador.Image = CType(My.Resources.ResourceManager.GetObject("YUMPER1"), Image)

        pnlBanner.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)
        Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)
        lblGuardar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        lblTitulo.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        grdTablaAmortizacion.BackgroundColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.grid)
        rbtnSemanas.Checked = True

        btnCalcular.Visible = False
        lblCalcular.Visible = False
        btnLimpiar.Visible = False
        lblLimpiar.Visible = False
        btnImprimir.Visible = False
        lblImprimir.Visible = False
        btnGuardar.Visible = False
        lblGuardar.Visible = False
        lblPagoTotal.Visible = False
        lblPagoTotal2.Visible = False
        lblInteresTotal.Visible = False
        lblInteresTotal2.Visible = False


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


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim empleadosForm As New BuscarEmpleadoForm
        empleadosForm.grdBuscarEmpleado.Rows.Clear()
        txtMonto.Focus()


        If empleadosForm.ShowDialog = DialogResult.OK Then

            IdColaborador = empleadosForm.pseleccion
            validarPrestamo()

            If prestamos > 0 Then
                Dim mensajeError As New AdvertenciaForm
                mensajeError.MdiParent = Me.MdiParent
                mensajeError.mensaje = "El colaborador tiene un prestamo en proceso no puede solicitar otro por el momento"
                mensajeError.Show()
                prestamos = 0
            Else

                limpiar()
                llenarParametros()
                btnBuscar.Visible = False
                lblBuscar.Visible = False

                btnCalcular.Visible = True
                lblCalcular.Visible = True

                btnLimpiar.Visible = True
                lblLimpiar.Visible = True

                txtMonto.Enabled = True
                txtSemanas.Enabled = True

                txtInteres.Enabled = True
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

            Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)

            request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
            Dim Carpeta As String = ""


            Dim tabla() As String
            tabla = Split(EntidadArchivos.PCarpeta, "\")

            For n = 0 To UBound(tabla, 1)
                Carpeta += tabla(n) + "/"
            Next

            Dim objFTP As New Tools.TransferenciaFTP
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
            meses = (DiasDeVida Mod 365) \ 30.4
            diasme = (DiasDeVida Mod 365) Mod 30.4
            lblEdad2.Text = anios.ToString + " años "

            ''LLENADO DE DATOS LABORALES
            Dim DatosLaborales As New Entidades.ColaboradorLaboral
            Dim DatosLaboralesBU As New Nomina.Negocios.ColaboradorLaboralBU

            DatosLaborales = DatosLaboralesBU.buscarInformacionLaboral(IdColaborador)
            lblPuesto2.Text = DatosLaborales.PPuestoId.PNombre
            lblDepartamento2.Text = DatosLaborales.PDepartamentoId.DNombre
            lblNave2.Text = DatosLaborales.PNaveId.PNombre
            IdNave = DatosLaborales.PNaveId.PNaveId


            ''LLENADO DE DATOS REALES
            Dim DatosReales As New Entidades.ColaboradorReal
            Dim DatosRealesBU As New Nomina.Negocios.ColaboradorRealBU

            DatosReales = DatosRealesBU.BuscarColaboradorReal(IdColaborador)
            lblSalario2.Text = DatosReales.PCantidad


            ''Calcular antiguedad
            anios = 0
            meses = 0
            diasme = 0
            Dim FechaIngreso As Date = DatosReales.PFecha
            DiasTrabajados = (FechaActual - FechaIngreso).TotalDays

            anios = DiasTrabajados \ 365
            meses = (DiasTrabajados Mod 365) \ 30.4
            diasme = (DiasTrabajados Mod 365) Mod 30.4
            lblAntiguedad2.Text = anios.ToString + " años " + meses.ToString + " meses " + diasme.ToString + " dias "

            ''Llenar configuracion del prestamo
            llenarconfiguracionPrestamo()

            ''Llenar combo de motivos de prestamos
            MotivosPrestamo()

            ''Llenar combo de TipoDeInteres


        Catch ex As Exception
            Dim mensajeError As New AdvertenciaForm
            mensajeError.MdiParent = Me.MdiParent
            mensajeError.mensaje = "No selecciono ningun colaborador"
            mensajeError.Show()
            lblEdad2.Text = ""

        End Try

    End Sub

    Public Sub AgregarDatos(ByVal ConfiguracionPrestamos As Entidades.ConfiguracionPrestamos)
        txtSemanas.Text = ConfiguracionPrestamos.PSemanasMaximo.ToString
        txtInteres.Text = ConfiguracionPrestamos.PInteres.ToString
        MaximoNave = ConfiguracionPrestamos.PMontoMaximoPorNave
        MaximoSemanas = ConfiguracionPrestamos.PSemanasMaximo

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


        If ConfiguracionPrestamos.PInteresFijo = False Then

        Else
            cmbTipoInteres.Items.Add("Interes fijo")
        End If

        If ConfiguracionPrestamos.PInteresSobreSaldo = False Then

        Else
            cmbTipoInteres.Items.Add("Interes sobre saldo")
        End If

        If ConfiguracionPrestamos.PSinInteres = False Then

        Else
            cmbTipoInteres.Items.Add("Sin interes")
        End If



    End Sub

    Public Sub llenarconfiguracionPrestamo()
        Dim listaConfiguracionPrestamos As New List(Of Entidades.ConfiguracionPrestamos)
        Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU

        listaConfiguracionPrestamos = prestamosBU.ListaConfiguracionPrestamos(IdNave)

        For Each objeto As Entidades.ConfiguracionPrestamos In listaConfiguracionPrestamos
            AgregarDatos(objeto)
        Next
    End Sub

    Public Sub ValidarSiHayPrestamo(ByVal validarPrestamos As Entidades.SolicitudPrestamo)
        prestamos = validarPrestamos.Pprestamoid


    End Sub

    Public Sub validarPrestamo()
        Dim listaPrestamos As New List(Of Entidades.SolicitudPrestamo)
        Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU

        listaPrestamos = prestamosBU.ValidacionPrestamo(IdColaborador)

        For Each objeto As Entidades.SolicitudPrestamo In listaPrestamos
            ValidarSiHayPrestamo(objeto)
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
        Dim justificacion As String = ""
        Dim motivo As Integer
        Dim numero As Single
        'Validar que no deje campos vacios
        Try
            Dim mensajeError As New AdvertenciaForm

            Monto = txtMonto.Text
            Interes = txtInteres.Text
            TipoInteres = cmbTipoInteres.SelectedItem.ToString
            justificacion = txtJustificacion.Text
            motivo = (Int(cmbMotivo.SelectedValue))


            If IsDBNull(motivo) Or txtJustificacion.Text = "" Then
                mensajeError.MdiParent = Me.MdiParent
                mensajeError.mensaje = "No dejar espacios vacios"
                mensajeError.Show()
            Else
                If Monto > MaximoColaborador Then
                    mensajeError.MdiParent = Me.MdiParent
                    mensajeError.mensaje = "El maximo a prestar es $" + MaximoColaborador.ToString
                    mensajeError.Show()

                Else

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
                            mensajeError.mensaje = "El exede el numero de semanas para pagar. El maximo es" + MaximoSemanas.ToString
                            mensajeError.Show()
                        Else

                            If Monto < abono Then
                                mensajeError.MdiParent = Me.MdiParent
                                mensajeError.mensaje = "El abono no puede ser mayor al monto a prestar"
                                mensajeError.Show()
                            Else
                                If txtAbono.Text = 0 Or txtMonto.Text = 0 Then

                                    mensajeError.MdiParent = Me.MdiParent
                                    mensajeError.mensaje = "No puedes dejar columnas en $0.00"
                                    mensajeError.Show()

                                Else

                                    grdTablaAmortizacion.Rows.Clear()

                                    fila = 0

                                    ''CALCULAR INTERES FIJO SI ES POR ABONO

                                    If TipoInteres.Equals("Interes fijo") Or TipoInteres.Equals("Interes sobre saldo") Then
                                        Interes = 0
                                        Interes = 7 * (txtInteres.Text / 30.4)
                                        Interes = Interes / 100
                                        abono = txtAbono.Text
                                        numero = Monto / abono
                                        numero = -Int(-numero)
                                        Interes = Monto * Interes


                                        If Interes > abono Then
                                            mensajeError.MdiParent = Me.MdiParent
                                            mensajeError.mensaje = "El abono minimo es de " + Interes.ToString("c")
                                            mensajeError.Show()
                                            grdTablaAmortizacion.Rows.Clear()
                                            btnImprimir.Visible = False
                                            lblImprimir.Visible = False
                                            btnGuardar.Visible = False
                                            lblGuardar.Visible = False
                                        Else

                                            If TipoInteres.Equals("Interes fijo") Then


                                                Interes = Interes
                                                abono = abono - Interes
                                                InteresPorPago = Interes
                                                TotalPagado = InteresPorPago + abono

                                                While Monto > 0

                                                    If Monto < TotalPagado Then
                                                        Dim abonofinal As Double = Monto
                                                        Monto = Monto - abonofinal
                                                        TotalPagado = abonofinal + InteresPorPago

                                                        Me.grdTablaAmortizacion.Rows.Insert(fila, Semanas, abonofinal, InteresPorPago, TotalPagado, Monto)
                                                        Monto = 0
                                                        Semanas = Semanas + 1
                                                    Else
                                                        Monto = Monto - abono
                                                        Me.grdTablaAmortizacion.Rows.Insert(fila, Semanas, abono, InteresPorPago, TotalPagado, Monto)
                                                        Semanas = Semanas + 1


                                                    End If
                                                    fila += 1
                                                    TotalInteres += InteresPorPago
                                                    TotalTotales += TotalPagado
                                                End While
                                                txtSemanas.Text = Semanas - 1
                                                lblInteresTotal2.Text = TotalInteres

                                                btnGuardar.Visible = True
                                                lblGuardar.Visible = True
                                                btnImprimir.Visible = True
                                                lblImprimir.Visible = True

                                                lblPagoTotal.Visible = True
                                                lblPagoTotal2.Visible = True
                                                lblPagoTotal2.Text = TotalTotales.ToString("c")
                                                lblInteresTotal.Visible = True
                                                lblInteresTotal2.Visible = True
                                                lblInteresTotal2.Text = TotalInteres.ToString("c")
                                                lblJustificacion.ForeColor = Color.Black
                                                TotalInteres = 0
                                                TotalTotales = 0

                                            End If


                                            ''CALCULAR INTERES SOBRE SALDO SI ES POR ABONO
                                            If TipoInteres.Equals("Interes sobre saldo") Then
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


                                                    If Monto < TotalPagado Then
                                                        Dim abonofinal As Double = Monto
                                                        Monto = Monto - abonofinal
                                                        TotalPagado = abonofinal + InteresPorPago

                                                        Me.grdTablaAmortizacion.Rows.Insert(fila, Semanas, abonofinal, InteresPorPago, TotalPagado, Monto)
                                                        Monto = 0
                                                        Semanas = Semanas + 1

                                                    Else
                                                        Monto = Monto - AbonoSobreSaldo
                                                        Me.grdTablaAmortizacion.Rows.Insert(fila, Semanas, AbonoSobreSaldo, InteresPorPago, TotalPagado, Monto)
                                                        Semanas = Semanas + 1
                                                    End If

                                                    fila += 1
                                                    TotalInteres += InteresPorPago
                                                    TotalTotales += TotalPagado
                                                End While
                                                txtSemanas.Text = Semanas - 1
                                                btnGuardar.Visible = True
                                                lblGuardar.Visible = True
                                                btnImprimir.Visible = True
                                                lblImprimir.Visible = True

                                                lblPagoTotal.Visible = True
                                                lblPagoTotal2.Visible = True
                                                lblPagoTotal2.Text = TotalTotales.ToString("c")
                                                lblInteresTotal.Visible = True
                                                lblInteresTotal2.Visible = True
                                                lblInteresTotal2.Text = TotalInteres.ToString("c")
                                                lblJustificacion.ForeColor = Color.Black
                                                TotalInteres = 0
                                                TotalTotales = 0




                                            End If
                                        End If
                                    End If

                                    ''CALCULAR SIN INTERES SI ES POR ABONO
                                    If TipoInteres.Equals("Sin interes") Then
                                        grdTablaAmortizacion.Rows.Clear()
                                        fila = 0
                                        While Monto > 0
                                            InteresPorPago = 0

                                            If Monto < abono Then
                                                Dim abonofinal As Double = Monto
                                                Monto = Monto - abonofinal
                                                TotalPagado = abonofinal + InteresPorPago

                                                Me.grdTablaAmortizacion.Rows.Insert(fila, Semanas, abonofinal, InteresPorPago, TotalPagado, Monto)
                                                Monto = 0
                                                Semanas = Semanas + 1

                                            Else
                                                TotalPagado = InteresPorPago + abono
                                                Monto = Monto - abono
                                                Me.grdTablaAmortizacion.Rows.Insert(0, Semanas, abono, InteresPorPago, TotalPagado, Monto)

                                                Semanas = Semanas + 1
                                            End If

                                            fila += 1
                                            TotalInteres += InteresPorPago
                                            TotalTotales += TotalPagado

                                        End While
                                        txtSemanas.Text = Semanas - 1

                                        btnGuardar.Visible = True
                                        lblGuardar.Visible = True
                                        btnImprimir.Visible = True
                                        lblImprimir.Visible = True

                                        lblPagoTotal.Visible = True
                                        lblPagoTotal2.Visible = True
                                        lblPagoTotal2.Text = TotalTotales.ToString("c")
                                        lblInteresTotal.Visible = True
                                        lblInteresTotal2.Visible = True
                                        lblInteresTotal2.Text = TotalInteres.ToString("c")
                                        lblJustificacion.ForeColor = Color.Black
                                        TotalInteres = 0
                                        TotalTotales = 0




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
                            mensajeError.mensaje = "No puesdes dejar campos con valo 0"
                            mensajeError.Show()
                        Else
                            grdTablaAmortizacion.Rows.Clear()
                            Semanas = txtSemanas.Text

                            ''CALCULAR INTERES FIJO  SI ES POR SEMANA

                            If TipoInteres.Equals("Interes fijo") Then
                                grdTablaAmortizacion.Rows.Clear()

                                abono = Monto / Semanas
                                fila = 0
                                controlSemanas = 1

                                Interes = Monto * Interes
                                TotalPagado = Interes + abono
                                txtAbono.Text = TotalPagado.ToString("c")



                                While Semanas > 0

                                    If Monto < abono Then
                                        Dim abonofinal As Double = Monto
                                        Monto = Monto - abonofinal
                                        TotalPagado = abonofinal + Interes

                                        Me.grdTablaAmortizacion.Rows.Insert(fila, controlSemanas, abonofinal, Interes, TotalPagado, Monto)
                                        Monto = 0
                                        Semanas = Semanas - 1
                                        controlSemanas = controlSemanas + 1
                                    Else

                                        Monto = Monto - abono
                                        Me.grdTablaAmortizacion.Rows.Insert(fila, controlSemanas, abono, Interes, TotalPagado, Monto)
                                        Semanas = Semanas - 1
                                        controlSemanas = controlSemanas + 1
                                    End If
                                    fila += 1
                                    TotalInteres += Interes
                                    TotalTotales += TotalPagado
                                End While

                                btnGuardar.Visible = True
                                lblGuardar.Visible = True
                                btnImprimir.Visible = True
                                lblImprimir.Visible = True

                                lblPagoTotal.Visible = True
                                lblPagoTotal2.Visible = True
                                lblPagoTotal2.Text = TotalTotales.ToString("c")
                                lblInteresTotal.Visible = True
                                lblInteresTotal2.Visible = True
                                lblInteresTotal2.Text = TotalInteres.ToString("c")
                                lblJustificacion.ForeColor = Color.Black
                                TotalInteres = 0
                                TotalTotales = 0

                            End If

                            ''CALCULAR INTERES SOBRE SALDO SI ES POR SEMANA

                            If TipoInteres.Equals("Interes sobre saldo") Then
                                Dim interesMonto As Double


                                grdTablaAmortizacion.Rows.Clear()
                                abono = Monto / Semanas
                                fila = 0
                                controlSemanas = 1

                                While Semanas > 0

                                    interesMonto = Monto * Interes

                                    InteresPorPago = interesMonto
                                    TotalPagado = InteresPorPago + abono
                                    txtAbono.Text = TotalPagado.ToString("c")
                                    If Monto < abono Then
                                        Dim abonofinal As Double = Monto
                                        Monto = Monto - abonofinal
                                        TotalPagado = abonofinal + InteresPorPago

                                        Me.grdTablaAmortizacion.Rows.Insert(fila, controlSemanas, abonofinal, InteresPorPago, TotalPagado, Monto)
                                        Monto = 0
                                        Semanas = Semanas - 1
                                        controlSemanas = controlSemanas + 1
                                    Else
                                        Monto = Monto - abono
                                        Me.grdTablaAmortizacion.Rows.Insert(fila, controlSemanas, abono, interesMonto, TotalPagado, Monto)
                                        Semanas = Semanas - 1
                                        controlSemanas = controlSemanas + 1
                                    End If
                                    fila += 1
                                    TotalInteres += InteresPorPago
                                    TotalTotales += TotalPagado
                                End While
                                btnGuardar.Visible = True
                                lblGuardar.Visible = True
                                btnImprimir.Visible = True
                                lblImprimir.Visible = True

                                lblPagoTotal.Visible = True
                                lblPagoTotal2.Visible = True
                                lblPagoTotal2.Text = TotalTotales.ToString("c")
                                lblInteresTotal.Visible = True
                                lblInteresTotal2.Visible = True
                                lblInteresTotal2.Text = TotalInteres.ToString("c")
                                lblJustificacion.ForeColor = Color.Black
                                TotalInteres = 0
                                TotalTotales = 0

                            End If



                            ''CALCULAR SIN INTERES SI ES POR SEMANA
                            If TipoInteres.Equals("Sin interes") Then
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
                                        Semanas = Semanas - 1
                                        controlSemanas = controlSemanas + 1
                                    Else
                                        Monto = Monto - abono
                                        Me.grdTablaAmortizacion.Rows.Insert(fila, controlSemanas, abono, InteresPorPago, TotalPagado, Monto)
                                        Semanas = Semanas - 1
                                        controlSemanas = controlSemanas + 1
                                    End If
                                    fila += 1
                                    TotalInteres += InteresPorPago
                                    TotalTotales += TotalPagado
                                End While
                                txtAbono.Text = abono.ToString("c")
                                btnGuardar.Visible = True
                                lblGuardar.Visible = True
                                btnImprimir.Visible = True
                                lblImprimir.Visible = True

                                lblPagoTotal.Visible = True
                                lblPagoTotal2.Visible = True
                                lblPagoTotal2.Text = TotalTotales.ToString("c")
                                lblInteresTotal.Visible = True
                                lblInteresTotal2.Visible = True
                                lblInteresTotal2.Text = TotalInteres.ToString("c")
                                lblJustificacion.ForeColor = Color.Black
                                TotalInteres = 0
                                TotalTotales = 0
                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Dim mensajeError As New AdvertenciaForm
            mensajeError.MdiParent = Me.MdiParent
            mensajeError.mensaje = "No dejar espacios vacios"
            mensajeError.Show()
        End Try

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Calcular()
        guardar()

    End Sub

    Public Sub guardar()

        Dim objBU = New Nomina.Negocios.SolicitudPrestamoBU
        Dim ObjEnt = New Entidades.SolicitudPrestamo
        Dim ColaboradorId As New Entidades.Colaborador
        Try
            ColaboradorId.PColaboradorid = IdColaborador
            ObjEnt.Pcolaboradorid = ColaboradorId
            ObjEnt.Pusuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            ObjEnt.Pmontoprestamo = txtMonto.Text
            ObjEnt.Pinteres = txtInteres.Text
            ObjEnt.Pmotivoprestamoid = (Int(cmbMotivo.SelectedValue))
            ObjEnt.Pmotivoprestamoid = cmbMotivo.SelectedIndex
            ObjEnt.Psemanas = txtSemanas.Text
            ObjEnt.Pestatus = "A"
            ObjEnt.Psaldo = txtMonto.Text
            Dim justificacion As String = txtJustificacion.Text
            ObjEnt.Pjustificacion = justificacion
            ObjEnt.Pabono = txtAbono.Text

            Dim interesTipo As String = cmbTipoInteres.SelectedItem.ToString

            Console.WriteLine(interesTipo)

            If interesTipo.Equals("Interes fijo") Then

                ObjEnt.Ptipointeres = "F"
            Else
                If interesTipo.Equals("Interes sobre saldo") Then
                    ObjEnt.Ptipointeres = "S"

                Else

                    If interesTipo.Equals("Sin interes") Then
                        ObjEnt.Ptipointeres = "I"

                    End If
                End If
            End If



            ''Guardar mandando mensaje
            objBU.guardarPrestamos(ObjEnt)
            btnGuardar.Visible = False
            lblGuardar.Visible = False
            btnCalcular.Visible = False
            lblCalcular.Visible = False
            Dim mensajeExito As New ExitoForm
            mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "Prestamo Guardado"

            mensajeExito.Show()

        Catch ex As Exception

        End Try


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

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
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
        lblInteresTotal2.Text = ""
        lblPagoTotal2.Text = ""





        lblInteresTotal2.Visible = False
        lblPagoTotal2.Visible = False



        ''Combos
        cmbMotivo.DataSource = Nothing
        cmbMotivo.DisplayMember = Nothing
        cmbMotivo.ValueMember = Nothing
        cmbTipoInteres.Items.Clear()
        cmbMotivo.Enabled = False
        cmbTipoInteres.Enabled = False

        ''Botones
        btnLimpiar.Visible = False
        lblLimpiar.Visible = False
        btnCalcular.Visible = False
        lblCalcular.Visible = False
        btnGuardar.Visible = False
        lblGuardar.Visible = False
        btnBuscar.Visible = True
        lblBuscar.Visible = True
        btnImprimir.Visible = False
        lblImprimir.Visible = False

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

    Private Sub txtJustificacion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtJustificacion.LostFocus

        Try
            txtJustificacion.Text = Format(CType(Me.txtJustificacion.Text, Decimal), "N0")
            lblJustificacion.ForeColor = Color.Black

        Catch ex As Exception
            lblJustificacion.ForeColor = Color.Red

        End Try


    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        pnlPropiedades.Height = 27
        grdTablaAmortizacion.Top = 850
        grdTablaAmortizacion.Height = 500
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        pnlPropiedades.Height = 318
        grdTablaAmortizacion.Top = 878
        grdTablaAmortizacion.Height = 270

    End Sub


End Class