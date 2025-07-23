Imports System.Net
Imports Tools

Public Class EditarPrestamoForm
    Public PrestamoEditar As Integer
    Public ColaboradorEditar As Integer
    Public editarAbono As Boolean
    Public MontoEditar As Double
    Public abonoEditar As Double
    Public semanasEditar As Integer
    Public TasaDeInteresEditar As Double
    Public TipoDeInteresEditar As String
    Public justificacionEditar As String
    Public IndiceNave As Integer
    Public IndiceEstatus As Integer
    Public editarmonto As Boolean
    Public saldoPrestamo As Double

    Dim totalInteres2 As Double = 0
    Dim abonoOriginal As Double

    Dim MaximoNave As Double
    Dim IdNave As Integer
    Dim MaximoColaborador As Double
    Dim MaximoSemanas As Integer
    Dim prestamos As Integer
    Dim TotalInteres As Double
    Dim TotalTotales As Double
    Dim montoAhorro As Double = 0
    Dim TipoPerfil As Integer = 0


    Private Sub EditarPrestamoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        btnGuardar.Enabled = False
        lblGuardar.Enabled = False

        If editarAbono = False Then
            rbtnSemanas.Checked = True
            txtAbono.Enabled = False
            lblFaltas2.Visible = False
            lblCajaDeAhorro2.Visible = False

        End If
        llenarParametros()
        PermisosPerfil()

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

        EntidadArchivos = ObjArchivosBU.CredencialColaborador(ColaboradorEditar)

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

            DatosPersonales = DatosPersonalesBU.BuscarColaboradorGeneral(ColaboradorEditar)
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

            DatosLaborales = DatosLaboralesBU.buscarInformacionLaboral(ColaboradorEditar)
            lblPuesto2.Text = DatosLaborales.PPuestoId.PNombre
            lblDepartamento2.Text = DatosLaborales.PDepartamentoId.DNombre
            lblNave2.Text = DatosLaborales.PNaveId.PNombre
            IdNave = DatosLaborales.PNaveId.PNaveId


            ''LLENADO DE DATOS REALES
            Dim DatosReales As New Entidades.ColaboradorReal
            Dim DatosRealesBU As New Nomina.Negocios.ColaboradorRealBU
            Dim objetoSolicitudPrestamo As New Negocios.SolicitudPrestamoBU
            lblFaltas2.Text = objetoSolicitudPrestamo.TotalFaltasMes(ColaboradorEditar)
            DatosReales = DatosRealesBU.BuscarColaboradorReal(ColaboradorEditar)
            lblSalario2.Text = DatosReales.PCantidad.ToString("N2")
            Dim objCA As New Negocios.CajaColaboradorBU
            Dim CantidadAhorro As New List(Of Entidades.CajaColaborador)
            Dim montoAcumulado As Double = 0
            CantidadAhorro = objCA.ConsultarCajaDeAhorroSaldoPrestamo(ColaboradorEditar, IdNave)
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
            lblAntiguedad2.Text = anios.ToString + " años " + meses.ToString + " meses " + diasme.ToString + " dias "

            ''Llenar configuracion del prestamo
            llenarconfiguracionPrestamo()

            ''Llenar combo de motivos de prestamos
            'MotivosPrestamo()

            ''Llenar combo de TipoDeInteres

            Dim objBUPres As New Negocios.SolicitudPrestamoBU
            Dim tablaPrestamo As New DataTable

            tablaPrestamo = objBUPres.editarPrestamo(PrestamoEditar, ColaboradorEditar)

            If editarAbono = True Then
                Dim monto, abono, montoActual As Double
                monto = tablaPrestamo.Rows(0).Item("pres_montoautorizado")
                abono = tablaPrestamo.Rows(0).Item("pres_abonoautorizado")
                montoActual = tablaPrestamo.Rows(0).Item("pres_saldo")

                'txtAbono.Text = tablaPrestamo.Rows(0).Item("pres_abonoautorizado")
                txtAbono.Text = abono.ToString("N2")
                abonoOriginal = tablaPrestamo.Rows(0).Item("pres_abonoautorizado")
                txtSemanas.Text = tablaPrestamo.Rows(0).Item("pres_semanasautorizadas")

                ' txtMonto.Text = tablaPrestamo.Rows(0).Item("pres_montoautorizado")
                ' txtMontoActual.Text = tablaPrestamo.Rows(0).Item("pres_saldo")
                txtMonto.Text = monto.ToString("N2")
                txtMontoActual.Text = montoActual.ToString("N2")

                ' txtMonto.Text = tablaPrestamo.Rows(0).Item("pres_montoautorizado")
                txtInteres.Text = tablaPrestamo.Rows(0).Item("pres_interesautorizado")
                txtJustificacion.Text = tablaPrestamo.Rows(0).Item("pres_justificacion")
                TipoDeInteresEditar = tablaPrestamo.Rows(0).Item("pres_tipointeresautorizado")
                If TipoDeInteresEditar = "I" Then
                    TipoDeInteresEditar = "SIN INTERES"
                ElseIf TipoDeInteresEditar = "S" Then
                    TipoDeInteresEditar = "INTERES SOBRE SALDO"
                ElseIf TipoDeInteresEditar = "F" Then
                    TipoDeInteresEditar = "INTERES FIJO"
                End If

                cmbTipoInteres.SelectedItem = TipoDeInteresEditar









            Else
                txtAbono.Text = abonoEditar.ToString("N2")
                txtSemanas.Text = semanasEditar
                txtMonto.Text = MontoEditar.ToString("N2")
                txtInteres.Text = TasaDeInteresEditar.ToString("N2")
                txtJustificacion.Text = justificacionEditar
            End If
            ''LLENAR DATOS ACTUALES DEL PRESTAMO




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
            cmbTipoInteres.Items.Add("INTERES FIJO")



        End If

        If ConfiguracionPrestamos.PInteresSobreSaldo = False Then

        Else
            cmbTipoInteres.Items.Add("INTERES SOBRE SALDO")

        End If

        If ConfiguracionPrestamos.PSinInteres = False Then

        Else
            cmbTipoInteres.Items.Add("SIN INTERES")

        End If

        cmbTipoInteres.SelectedItem = TipoDeInteresEditar

    End Sub

    Public Sub llenarconfiguracionPrestamo()
        Dim listaConfiguracionPrestamos As New List(Of Entidades.ConfiguracionPrestamos)
        Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU

        listaConfiguracionPrestamos = prestamosBU.ListaConfiguracionPrestamos(IdNave)

        For Each objeto As Entidades.ConfiguracionPrestamos In listaConfiguracionPrestamos
            AgregarDatos(objeto)
        Next
    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grpParametros.Height = 45

    End Sub
    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grpParametros.Height = 304
    End Sub

    Public Sub SeleccionarTipoDeInteres()
        Dim TamañoDelCombo As Integer = cmbTipoInteres.SelectionLength
        MessageBox.Show(TamañoDelCombo)
    End Sub

    Private Sub btnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcular.Click
        Calcular()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Dim mensajeExito As New ConfirmarForm
        mensajeExito.mensaje = "¿Estas seguro de querer realizar los siguientes cambios? "

        If mensajeExito.ShowDialog = DialogResult.OK Then
            If txtAbono.Text <> 0 Then
                Calcular()
            End If

            guardar()
            Dim objAutorizacion As New AutorizacionPrestamoForm
            objAutorizacion.llenarTablaConPrestamosAutorizados()
        End If
    End Sub

    Public Sub guardar()

        Dim objBU = New Nomina.Negocios.SolicitudPrestamoBU
        Dim ObjEnt = New Entidades.SolicitudPrestamo
        Dim Colaborador As New Entidades.Colaborador
        Try

            Colaborador.PColaboradorid = ColaboradorEditar
            ObjEnt.PeditarAbono = editarAbono
            ObjEnt.PeditarMonto = editarmonto
            ObjEnt.Pprestamoid = PrestamoEditar
            ObjEnt.Pcolaborador = Colaborador
            ObjEnt.Pusuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            ObjEnt.Pmontoprestamo = txtMonto.Text
            ObjEnt.Pinteres = txtInteres.Text

            ObjEnt.Psemanas = txtSemanas.Text
            ObjEnt.Pestatus = "A"
            ObjEnt.Psaldo = txtMonto.Text
            Dim justificacion As String = txtJustificacion.Text
            ObjEnt.Pjustificacion = justificacion
            ObjEnt.Pabono = txtAbono.Text
            ObjEnt.Ptotalinteres = totalInteres2

            Dim interesTipo As String = cmbTipoInteres.SelectedItem.ToString

            Console.WriteLine(interesTipo)

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
            If editarAbono = True Then
                enviar_correo(IdNave, "ENVIO_NOTIFICACION_ABONO_PRESTAMO_EDITADO")
            End If

            objBU.ActualizarPrestamo(ObjEnt)
            btnGuardar.Enabled = False
            lblGuardar.Enabled = False
            btnCalcular.Visible = False
            lblCalcular.Visible = False
            Dim mensajeExito As New ExitoForm
            'mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "Prestamo Guardado"

            mensajeExito.ShowDialog()

            Dim obj As New AutorizacionPrestamoForm


        Catch ex As Exception

        End Try


    End Sub

    Public Sub PermisosPerfil()

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_LISTAPRESTAMOS", "NOM_PRES_EDITA_INTERESMENSUAL") Then
            TipoPerfil = 1
        End If


        If TipoPerfil = 1 Then
            txtInteres.Enabled = True

        Else
            txtInteres.Enabled = False
        End If

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
        Dim numero As Single
        'Validar que no deje campos vacios
        Try
            Dim mensajeError As New AdvertenciaForm

            If editarAbono = True And editarmonto = False Then
                Monto = txtMontoActual.Text
            Else
                Monto = txtMonto.Text
            End If
            'Monto = txtMonto.Text
            Interes = txtInteres.Text
            TipoInteres = cmbTipoInteres.SelectedItem.ToString
            justificacion = txtJustificacion.Text
            'motivo = (Int(cmbMotivo.SelectedValue))


            '  If IsDBNull(motivo) Or txtJustificacion.Text = "" Then
            'mensajeError.MdiParent = Me.MdiParent
            '   mensajeError.mensaje = "No dejar espacios vacios"
            '  mensajeError.Show()
            '   Else
            If Monto > MaximoColaborador Then
                mensajeError.MdiParent = Me.MdiParent
                mensajeError.mensaje = "El maximo a prestar es $" + MaximoColaborador.ToString
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

                    ' If numero > MaximoSemanas Then
                    If abono = 0 Then
                        mensajeError.MdiParent = Me.MdiParent
                        mensajeError.mensaje = "En el cierre semanal se descontarán los intereses correspondientes al saldo del préstamo"
                        mensajeError.Show()
                        fila = 1
                        Dim abonofinal As Double = abono
                        Interes = 7 * (txtInteres.Text / 30.4)
                        Interes = Interes / 100
                        InteresPorPago = Monto * Interes
                        TotalPagado = InteresPorPago + abono
                        Me.grdTablaAmortizacion.Rows.Add(fila, abonofinal.ToString("N2"), InteresPorPago.ToString("N2"), TotalPagado.ToString("N2"), Monto.ToString("N2"))
                        btnGuardar.Enabled = True
                        lblGuardar.Enabled = True

                        'mensajeError.MdiParent = Me.MdiParent
                        'mensajeError.mensaje = "El exede el numero de semanas para pagar. El maximo es" + MaximoSemanas.ToString
                        'mensajeError.Show()
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
                                        mensajeError.mensaje = "El abono minimo es de " + Interes.ToString("N2")
                                        mensajeError.Show()
                                        grdTablaAmortizacion.Rows.Clear()

                                        btnGuardar.Enabled = False
                                        lblGuardar.Enabled = False
                                    Else

                                        If TipoInteres.Equals("INTERES FIJO") Then


                                            Interes = Interes
                                            abono = abono - Interes
                                            InteresPorPago = Interes
                                            TotalPagado = InteresPorPago + abono
                                            fila = 1
                                            While Monto > 0

                                                If Monto < TotalPagado Then
                                                    Dim abonofinal As Double = Monto
                                                    Monto = Monto - abonofinal
                                                    TotalPagado = abonofinal + InteresPorPago

                                                    Me.grdTablaAmortizacion.Rows.Add(fila, abonofinal.ToString("N2"), InteresPorPago.ToString("N2"), TotalPagado.ToString("N2"), Monto.ToString("N2"))
                                                    Monto = 0
                                                    Semanas = Semanas + 1
                                                Else
                                                    ''''CAJA AHORRO
                                                    If nSem = Semanas Then
                                                        lblMensajeCaja.Text = "EN EL PAGO NUMERO " + nSem.ToString + " SE DESCONTARA DEL ACUMULADO EN CAJA DE AHORRO " + vbNewLine + "EL MONTO MOSTRADO PUEDE VARIAR."
                                                        If Monto < montoAcumuladoCajaAhorro Then
                                                            Dim abonoFinal As Double = Monto
                                                            Monto = Monto - abonoFinal
                                                            TotalPagado = abonoFinal
                                                            Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, abonoFinal.ToString("N2"), 0.0, TotalPagado.ToString("N2"), Monto.ToString("N2"))
                                                            Semanas = Semanas + 1
                                                        Else
                                                            Monto = Monto - montoAcumuladoCajaAhorro

                                                            Me.grdTablaAmortizacion.Rows.Add(fila, montoAcumuladoCajaAhorro.ToString("N2"), 0.0, montoAcumuladoCajaAhorro.ToString("N"), Monto.ToString("N2"))
                                                            Semanas = Semanas + 1

                                                        End If

                                                    Else
                                                        Monto = Monto - abono
                                                        Me.grdTablaAmortizacion.Rows.Add(fila, abono.ToString("N2"), InteresPorPago.ToString("N2"), TotalPagado.ToString("N2"), Monto.ToString("N2"))
                                                        Semanas = Semanas + 1
                                                    End If
                                                    ''''''' FIN CAJA AHORRO
                                                    'Monto = Monto - abono
                                                    'Me.grdTablaAmortizacion.Rows.Add(fila, abono.ToString("N2"), InteresPorPago.ToString("N2"), TotalPagado.ToString("N2"), Monto.ToString("N2"))
                                                    'Semanas = Semanas + 1


                                                End If
                                                fila += 1
                                                TotalInteres += InteresPorPago
                                                TotalTotales += TotalPagado
                                                fila += 1
                                            End While
                                            txtSemanas.Text = Semanas - 1
                                            '    lblInteresTotal2.Text = TotalInteres

                                            btnGuardar.Enabled = True
                                            lblGuardar.Enabled = True


                                            '  lblPagoTotal.Visible = True
                                            'lblPagoTotal2.Visible = True
                                            'lblPagoTotal2.Text = TotalTotales.ToString("N2")
                                            'lblInteresTotal.Visible = True
                                            'lblInteresTotal2.Visible = True
                                            'lblInteresTotal2.Text = TotalInteres.ToString("N2")
                                            lblJustificacion.ForeColor = Color.Black
                                            TotalInteres = 0
                                            TotalTotales = 0

                                        End If


                                        ''CALCULAR INTERES SOBRE SALDO SI ES POR ABONO
                                        If TipoInteres.Equals("INTERES SOBRE SALDO") Then
                                            grdTablaAmortizacion.Rows.Clear()
                                            fila = 1
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

                                                    Me.grdTablaAmortizacion.Rows.Add(fila, abonofinal.ToString("N2"), InteresPorPago.ToString("N2"), TotalPagado.ToString("N2"), Monto.ToString("N2"))
                                                    Monto = 0
                                                    Semanas = Semanas + 1

                                                Else
                                                    ''CAJA AHORRO 
                                                    If nSem = Semanas Then
                                                        lblMensajeCaja.Text = "EN EL PAGO NUMERO " + nSem.ToString + " SE DESCONTARA DEL ACUMULADO EN CAJA DE AHORRO " + vbNewLine + "EL MONTO MOSTRADO PUEDE VARIAR."
                                                        If Monto < montoAcumuladoCajaAhorro Then
                                                            Dim abonoFinal As Double = Monto
                                                            Monto = Monto - abonoFinal
                                                            TotalPagado = abonoFinal
                                                            Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, abonoFinal.ToString("N2"), 0.0, TotalPagado.ToString("N2"), Monto.ToString("N2"))
                                                            Semanas = Semanas + 1
                                                        Else
                                                            Monto = Monto - montoAcumuladoCajaAhorro

                                                            Me.grdTablaAmortizacion.Rows.Add(fila, montoAcumuladoCajaAhorro.ToString("N2"), 0.0, montoAcumuladoCajaAhorro.ToString("N2"), Monto.ToString("N2"))
                                                            Semanas = Semanas + 1

                                                        End If
                                                    Else
                                                        Monto = Monto - AbonoSobreSaldo
                                                        Me.grdTablaAmortizacion.Rows.Add(fila, AbonoSobreSaldo.ToString("N2"), InteresPorPago.ToString("N2"), TotalPagado.ToString("N2"), Monto.ToString("N2"))
                                                        Semanas = Semanas + 1
                                                    End If
                                                    '' FIN CAJA AHORRO
                                                    'Monto = Monto - AbonoSobreSaldo
                                                    'Me.grdTablaAmortizacion.Rows.Add(fila, AbonoSobreSaldo.ToString("N2"), InteresPorPago.ToString("N2"), TotalPagado.ToString("N2"), Monto.ToString("N2"))
                                                    'Semanas = Semanas + 1
                                                End If

                                                fila += 1
                                                TotalInteres += InteresPorPago
                                                TotalTotales += TotalPagado
                                            End While
                                            txtSemanas.Text = Semanas - 1
                                            btnGuardar.Enabled = True
                                            lblGuardar.Enabled = True


                                            'lblPagoTotal.Visible = True
                                            'lblPagoTotal2.Visible = True
                                            'lblPagoTotal2.Text = TotalTotales.ToString("N2")
                                            'lblInteresTotal.Visible = True
                                            'lblInteresTotal2.Visible = True
                                            'lblInteresTotal2.Text = TotalInteres.ToString("N2")
                                            lblJustificacion.ForeColor = Color.Black
                                            TotalInteres = 0
                                            TotalTotales = 0




                                        End If
                                    End If
                                End If

                                ''CALCULAR SIN INTERES SI ES POR ABONO
                                If TipoInteres.Equals("SIN INTERES") Then
                                    grdTablaAmortizacion.Rows.Clear()
                                    fila = 1
                                    While Monto > 0
                                        InteresPorPago = 0

                                        If Monto < abono Then
                                            Dim abonofinal As Double = Monto
                                            Monto = Monto - abonofinal
                                            TotalPagado = abonofinal + InteresPorPago

                                            Me.grdTablaAmortizacion.Rows.Add(fila, abonofinal.ToString("N2"), InteresPorPago.ToString("N2"), TotalPagado.ToString("N2"), Monto.ToString("N2"))
                                            Monto = 0
                                            Semanas = Semanas + 1

                                        Else
                                            ''CAJA AHORRO
                                            If nSem = Semanas Then
                                                lblMensajeCaja.Text = "EN EL PAGO NUMERO " + nSem.ToString + " SE DESCONTARA DEL ACUMULADO EN CAJA DE AHORRO " + vbNewLine + "EL MONTO MOSTRADO PUEDE VARIAR."
                                                If Monto < montoAcumuladoCajaAhorro Then
                                                    Dim abonoFinal As Double = Monto
                                                    Monto = Monto - abonoFinal
                                                    TotalPagado = abonoFinal
                                                    Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, abonoFinal.ToString("N2"), 0.0, TotalPagado.ToString("N2"), Monto.ToString("N2"))
                                                    Semanas = Semanas + 1
                                                Else
                                                    Monto = Monto - montoAcumuladoCajaAhorro

                                                    Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, montoAcumuladoCajaAhorro.ToString("N2"), 0.0, montoAcumuladoCajaAhorro.ToString("N2"), Monto.ToString("N2"))
                                                    Semanas = Semanas + 1
                                                End If

                                            Else
                                                TotalPagado = InteresPorPago + abono
                                                Monto = Monto - abono
                                                Me.grdTablaAmortizacion.Rows.Add(fila, abono.ToString("N2"), InteresPorPago.ToString("N2"), TotalPagado.ToString("N2"), Monto.ToString("N2"))
                                                Semanas = Semanas + 1
                                            End If

                                            ''FIN CAJA AHORRO

                                            'TotalPagado = InteresPorPago + abono
                                            'Monto = Monto - abono
                                            'Me.grdTablaAmortizacion.Rows.Add(fila, abono.ToString("N2"), InteresPorPago.ToString("N2"), TotalPagado.ToString("N2"), Monto.ToString("N2"))

                                            'Semanas = Semanas + 1
                                        End If

                                        fila += 1
                                        TotalInteres += InteresPorPago
                                        TotalTotales += TotalPagado

                                    End While
                                    txtSemanas.Text = Semanas - 1

                                    btnGuardar.Enabled = True
                                    lblGuardar.Enabled = True


                                    'lblPagoTotal.Visible = True
                                    'lblPagoTotal2.Visible = True
                                    'lblPagoTotal2.Text = TotalTotales.ToString("N2")
                                    'lblInteresTotal.Visible = True
                                    'lblInteresTotal2.Visible = True
                                    'lblInteresTotal2.Text = TotalInteres.ToString("N2")
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

                        If TipoInteres.Equals("INTERES FIJO") Then
                            grdTablaAmortizacion.Rows.Clear()

                            abono = Monto / Semanas
                            fila = 1
                            controlSemanas = 1

                            Interes = Monto * Interes
                            TotalPagado = Interes + abono
                            txtAbono.Text = TotalPagado.ToString("N2")



                            While Semanas > 0

                                If Monto < abono Then
                                    Dim abonofinal As Double = Monto
                                    Monto = Monto - abonofinal
                                    TotalPagado = abonofinal + Interes

                                    Me.grdTablaAmortizacion.Rows.Add(fila, abonofinal.ToString("N2"), Interes.ToString("N2"), TotalPagado.ToString("N2"), Monto.ToString("N2"))
                                    Monto = 0
                                    Semanas = Semanas - 1
                                    controlSemanas = controlSemanas + 1
                                Else

                                    ''CAJA AHORRO
                                    If nSem = controlSemanas Then
                                        lblMensajeCaja.Text = "EN EL PAGO NUMERO " + nSem.ToString + " SE DESCONTARA DEL ACUMULADO EN CAJA DE AHORRO " + vbNewLine + "EL MONTO MOSTRADO PUEDE VARIAR."
                                        If Monto < montoAcumuladoCajaAhorro Then
                                            Dim abonoFinal As Double = Monto
                                            Monto = Monto - abonoFinal
                                            TotalPagado = abonoFinal
                                            Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, abonoFinal.ToString("N2"), 0.0, TotalPagado.ToString("N2"), Monto.ToString("N2"))
                                            controlSemanas = controlSemanas + 1
                                            Semanas = 0
                                        Else
                                            Monto = Monto - montoAcumuladoCajaAhorro

                                            Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, montoAcumuladoCajaAhorro.ToString("N2"), 0.0, montoAcumuladoCajaAhorro.ToString("N2"), Monto.ToString("N2"))
                                            controlSemanas = controlSemanas + 1
                                            Semanas = Semanas - 1
                                        End If

                                    Else
                                        Monto = Monto - abono
                                        Me.grdTablaAmortizacion.Rows.Add(fila, abono.ToString("N2"), Interes.ToString("N2"), TotalPagado.ToString("N2"), Monto.ToString("N2"))
                                        Semanas = Semanas - 1
                                        controlSemanas = controlSemanas + 1
                                    End If
                                    ''FIN CAJA AHORRO
                                    'Monto = Monto - abono
                                    'Me.grdTablaAmortizacion.Rows.Add(fila, abono.ToString("N2"), Interes.ToString("N2"), TotalPagado.ToString("N2"), Monto.ToString("N2"))
                                    'Semanas = Semanas - 1
                                    'controlSemanas = controlSemanas + 1
                                End If
                                fila += 1
                                TotalInteres += Interes
                                TotalTotales += TotalPagado
                            End While

                            btnGuardar.Enabled = True
                            lblGuardar.Enabled = True


                            'lblPagoTotal.Visible = True
                            'lblPagoTotal2.Visible = True
                            'lblPagoTotal2.Text = TotalTotales.ToString("N2")
                            'lblInteresTotal.Visible = True
                            'lblInteresTotal2.Visible = True
                            'lblInteresTotal2.Text = TotalInteres.ToString("N2")
                            lblJustificacion.ForeColor = Color.Black
                            TotalInteres = 0
                            TotalTotales = 0

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

                            End While

                            ''PARA SACAR EL ABONO FIJO
                            Dim totalAbono As Double
                            Dim abonoPago As Double
                            Dim TotalTotales2 As Double = 0
                            Monto = txtMonto.Text
                            Semanas = txtSemanas.Text
                            fila = 1
                            Dim promedioPago As Double = TotalTotales / (controlSemanas - 1)
                            txtAbono.Text = promedioPago.ToString("N2")

                            While Semanas > 0

                                interesMonto = Monto * Interes
                                abonoPago = promedioPago - interesMonto


                                If Semanas = 1 Then
                                    Dim abonoFinal As Double = Monto
                                    promedioPago = Monto + interesMonto
                                    Monto = Monto - abonoFinal

                                    Me.grdTablaAmortizacion.Rows.Add(fila, abonoFinal.ToString("N2"), interesMonto.ToString("N2"), promedioPago.ToString("N2"), Monto.ToString("N2"))
                                    Semanas = Semanas - 1
                                    Monto = 0
                                    totalAbono += abonoFinal
                                Else
                                    Monto = Monto - abonoPago
                                    Me.grdTablaAmortizacion.Rows.Add(fila, abonoPago.ToString("N2"), interesMonto.ToString("N2"), promedioPago.ToString("N2"), Monto.ToString("N2"))
                                    Semanas = Semanas - 1
                                    totalAbono += abonoPago
                                End If

                                TotalInteres += interesMonto
                                TotalTotales2 += promedioPago
                                fila += 1
                            End While
                            btnGuardar.Enabled = True
                            lblGuardar.Enabled = True


                            'lblPagoTotal.Visible = True
                            'lblPagoTotal2.Visible = True
                            'lblPagoTotal2.Text = TotalTotales.ToString("N2")
                            'lblInteresTotal.Visible = True
                            'lblInteresTotal2.Visible = True
                            'lblInteresTotal2.Text = TotalInteres.ToString("N2")
                            lblJustificacion.ForeColor = Color.Black
                            TotalInteres = 0
                            TotalTotales = 0

                        End If



                        ''CALCULAR SIN INTERES SI ES POR SEMANA
                        If TipoInteres.Equals("SIN INTERES") Then
                            grdTablaAmortizacion.Rows.Clear()
                            abono = Monto / Semanas
                            fila = 1
                            controlSemanas = 1

                            While Semanas > 0
                                InteresPorPago = 0
                                TotalPagado = InteresPorPago + abono
                                txtAbono.Text = TotalPagado.ToString("N2")
                                If Monto < abono Then
                                    Dim abonofinal As Double = Monto
                                    Monto = Monto - abonofinal
                                    TotalPagado = abonofinal + InteresPorPago
                                    Me.grdTablaAmortizacion.Rows.Add(fila, abonofinal.ToString("N2"), InteresPorPago.ToString("N2"), TotalPagado.ToString("N2"), Monto.ToString("N2"))
                                    Monto = 0
                                    Semanas = Semanas - 1
                                    controlSemanas = controlSemanas + 1
                                Else

                                    ''CAJA AHORRO
                                    If nSem = grdTablaAmortizacion.Rows.Count + 1 Then
                                        lblMensajeCaja.Text = "EN EL PAGO NUMERO " + nSem.ToString + " SE DESCONTARA DEL ACUMULADO EN CAJA DE AHORRO " + vbNewLine + "EL MONTO MOSTRADO PUEDE VARIAR."
                                        If Monto < montoAcumuladoCajaAhorro Then
                                            Dim abonoFinal As Double = Monto
                                            Monto = Monto - abonoFinal
                                            TotalPagado = abonoFinal
                                            Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, abonoFinal.ToString("N2"), 0.0, TotalPagado.ToString("N2"), Monto.ToString("N2"))
                                            controlSemanas = controlSemanas + 1
                                            Semanas = 0
                                        Else
                                            Monto = Monto - montoAcumuladoCajaAhorro

                                            Me.grdTablaAmortizacion.Rows.Add(grdTablaAmortizacion.Rows.Count + 1, montoAcumuladoCajaAhorro.ToString("N2"), 0.0, montoAcumuladoCajaAhorro.ToString("N2"), Monto.ToString("N2"))
                                            controlSemanas = controlSemanas + 1
                                            Semanas = Semanas - 1
                                        End If
                                    Else


                                        Monto = Monto - abono
                                        Me.grdTablaAmortizacion.Rows.Add(fila, abono.ToString("N2"), InteresPorPago.ToString("N2"), TotalPagado.ToString("N2"), Monto.ToString("N2"))
                                        Semanas = Semanas - 1
                                        controlSemanas = controlSemanas + 1
                                        ''FIN CAJA AHORRO    
                                        'Monto = Monto - abono
                                        'Me.grdTablaAmortizacion.Rows.Add(fila, abono.ToString("N2"), InteresPorPago.ToString("N2"), TotalPagado.ToString("N2"), Monto.ToString("N2"))
                                        'Semanas = Semanas - 1
                                        'controlSemanas = controlSemanas + 1
                                    End If
                                End If
                                fila += 1
                                TotalInteres += InteresPorPago
                                TotalTotales += TotalPagado
                            End While
                            txtAbono.Text = abono.ToString("N2")
                            btnGuardar.Enabled = True
                            lblGuardar.Enabled = True


                            'lblPagoTotal.Visible = True
                            'lblPagoTotal2.Visible = True
                            'lblPagoTotal2.Text = TotalTotales.ToString("N2")
                            'lblInteresTotal.Visible = True
                            'lblInteresTotal2.Visible = True
                            'lblInteresTotal2.Text = TotalInteres.ToString("N2")
                            lblJustificacion.ForeColor = Color.Black
                            TotalInteres = 0
                            TotalTotales = 0
                        End If
                    End If
                End If
            End If
            '   End If

            Dim totalAbono2 As Double = 0
            Dim Pagototal2 As Double = 0
            Dim contadorFilas As Integer = 0

            totalInteres2 = 0
            For Each row As DataGridViewRow In grdTablaAmortizacion.Rows
                totalInteres2 += row.Cells("clmInteres").Value
                totalAbono2 += row.Cells("clmAbonoACapital").Value
                Pagototal2 += row.Cells("clmTotal").Value
                contadorFilas += 1

            Next

            grdTablaAmortizacion.Rows.Add("", totalAbono2.ToString("N2"), totalInteres2.ToString("N2"), Pagototal2.ToString("N2"), "")
            grdTablaAmortizacion.Rows(contadorFilas).DefaultCellStyle.BackColor = Color.GreenYellow




        Catch ex As Exception
            Dim mensajeError As New AdvertenciaForm
            mensajeError.MdiParent = Me.MdiParent
            mensajeError.mensaje = "No dejar espacios vacios"
            mensajeError.Show()
        End Try

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



    Private Sub rbtnAbono_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rbtnAbono.Checked = True Then

            txtSemanas.Enabled = False
            txtAbono.Enabled = True
            txtAbono.Focus()
            lblSemanas.ForeColor = Color.Black
        End If
    End Sub

    Private Sub rbtnSemanas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rbtnSemanas.Checked = True Then

            txtAbono.Enabled = False
            txtSemanas.Enabled = True
            txtSemanas.Focus()
            lblAbono.ForeColor = Color.Black
        End If
    End Sub


    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ''SOLO NUMEROS
        Dim caracter As Char = e.KeyChar
        If (Char.IsNumber(caracter)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ".") And (txtMonto.Text.Contains(".") = False) Then
            e.Handled = False
        Else
            e.Handled = True

        End If
    End Sub

    Private Sub txtSemanas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ''SOLO NUMEROS
        Dim caracter As Char = e.KeyChar
        If (Char.IsNumber(caracter)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ".") And (txtMonto.Text.Contains(".") = False) Then
            e.Handled = False
        Else
            e.Handled = True

        End If
    End Sub

    Private Sub txtAbono_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ''SOLO NUMEROS
        Dim caracter As Char = e.KeyChar
        If (Char.IsNumber(caracter)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ".") And (txtMonto.Text.Contains(".") = False) Then
            e.Handled = False
        Else
            e.Handled = True

        End If
    End Sub

    Private Sub txtInteres_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ''SOLO NUMEROS
        Dim caracter As Char = e.KeyChar
        If (Char.IsNumber(caracter)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ".") And (txtMonto.Text.Contains(".") = False) Then
            e.Handled = False
        Else
            e.Handled = True

        End If
    End Sub

    Private Sub enviar_correo(ByVal naveID As Integer, ByVal clave As String)



        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String
        Dim correo As New Tools.Correo
        Dim fecha As DateTime = Now.Date
        destinatarios = enviosCorreoBU.consulta_destinatarios_email(naveID, clave)

        Dim Email As String = ""
        Email += " <!DOCTYPE html>"
        Email += " <html>  "
        Email += " <head>  "
        Email += " <style> "
        Email += " #Header{"
        Email += " color:#003366;"
        Email += " font-family: Arial, Helvetica, sans-serif;"
        Email += " }"
        Email += " table, th, td { border: 1px solid black; text-align: center; } "
        Email += " th{ background-color:#003366; "
        Email += " color:#FFFFFF; "
        Email += " font-weight:bold;"
        Email += " height:30px;"
        Email += " font-size:10px;"
        Email += " font-family: Arial, Helvetica, sans-serif;"
        Email += " text-align: center; "
        Email += " } "
        Email += " td{ "
        Email += " font-family: Arial, Helvetica, sans-serif; "
        Email += " text-align: center; "
        Email += " color:#003363;"
        Email += " font-size:10px;"
        Email += " font-weight:bold;"
        Email += " } "
        Email += " </style>"
        Email += " <div id='Header'>"
        Email += " <img src='" + "http://grupoyuyin.com.mx/images/SAY170.jpg" + "' height='" + "60" + "' width='" + "60" + "'alt='" + "logo" + "'>"
        Email += " <h1>"
        Email += " <strong>"
        Email += " Pr&eacute;stamo editado."
        Email += " </strong>"
        Email += " </h1>"
        Email += "<h5>Usuario modificó: " + Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString + " <h5>"
        Email += "<h5>Fecha modificación: " + Now.Date.ToLongDateString + "<h5>"
        Email += " </div>"
        Email += " </head>"
        Email += "<body>"
        Email += "<table style='border:1px;'>"
        Email += "<thead>"
        Email += "<tr>"
        Email += "<th>"
        Email += "Colaborador"
        Email += "</th>"
        Email += "<th>"
        Email += "Monto autorizado"
        Email += "</th>"
        Email += "<th>"
        Email += "Abono original"
        Email += "</th>"
        Email += "<th>"
        Email += "Abono nuevo"
        Email += "</th>"

        Email += "</tr>"
        Email += "</thead>"
        Email += "<tbody>"


        Email += "<tr>"

        Email += "<td>"
        Email += lblColaborador2.Text
        Email += "</td>"

        Email += "<td>"
        Email += CInt(txtMonto.Text).ToString("N2")
        Email += "</td>"

        Email += "<td>"
        Email += abonoOriginal.ToString("N2")
        Email += "</td>"

        Email += "<td>"
        Email += CInt(txtAbono.Text).ToString("N2")
        Email += "</td>"

        Email += "</tr>"

        Email += "</tbody>"
        Email += "</table>"
        Email += "</body> "
        Email += "</html> "
        correo.EnviarCorreoHtml(destinatarios, "say_nomina@grupoyuyin.com.mx", "Abono Editado", Email)
    End Sub

    Private Sub txtInteres_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles txtInteres.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnCalcular_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtInteres_Leave(sender As Object, e As EventArgs) Handles txtInteres.Leave
        btnCalcular_Click(Nothing, Nothing)
    End Sub


End Class