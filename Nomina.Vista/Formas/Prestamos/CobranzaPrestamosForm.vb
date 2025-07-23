Imports Tools

Public Class CobranzaPrestamosForm
    Dim fechaPago As DateTime
    Dim fechaInicioNomina As DateTime
    Dim fechaFinNomina As DateTime

    Private Sub CobranzaPrestamosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        Me.Top = 0
        Me.Left = 0
        Tools.FormatoCtrls.formato(Me)
        Controles.ComboNavesSegunUsuario(cmbNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))

        If cmbNave.SelectedValue > 0 Then
            grdPrestamos.Rows.Clear()
            SemanaNomina()
            cmbEstatus.SelectedIndex = 0
        End If

        btnEditarCobro.Visible = False
        lblEditarCobro.Visible = False
        btncobrar.Enabled = False

        EstatusSemanaNomina.Visible = False
        lblfechafin.Visible = False
        lblfechainicio.Visible = False
        lblfechamodificacion.Visible = False
        lblIdSemanaNomina.Visible = False
        lblsemananomina2.Visible = False
        lblsemananomina.Visible = False
        lblEstatusSemanaPrestamos.Visible = False


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_COBRANZA", "CONDONARPRESTAMO") Then
            clmCondonar.Visible = True
        Else
            clmCondonar.Visible = False
        End If

    End Sub

    ''LLENAR PRESTAMOS POR COBRAR
    Public Sub llenarTablaConPrestamosPorCobrar()
        Try
            Dim listaConfiguracionPrestamos As New List(Of Entidades.SolicitudPrestamo)


            Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU

            Dim idNave As Integer
            idNave = (Int(cmbNave.SelectedValue))
            listaConfiguracionPrestamos = prestamosBU.ListaPrestamosCobrar(idNave)

            For Each objeto As Entidades.SolicitudPrestamo In listaConfiguracionPrestamos
                AgregarFilaDePrestamosPorCobrar(objeto)
                btncobrar.Enabled = True
                lblcobrar.Enabled = True
                lblcobrar2.Enabled = True
            Next

            Dim total As Double = 0
            Dim parche As Double = 0
            Dim parche2 As Int32 = 0
            Dim contadorfilas As Integer = 0
            For Each row As DataGridViewRow In grdPrestamos.Rows
                total += row.Cells("clmtotalabono").Value
                contadorfilas += 1
            Next
            If contadorfilas > 0 Then
                grdPrestamos.Rows.Add("", "", False, "", "", "", "", "", "", "", total, "", "", "", "", "")
                grdPrestamos.Rows(contadorfilas).DefaultCellStyle.BackColor = Color.GreenYellow
                'grdPrestamos.Rows(contadorfilas).DefaultCellStyle.ForeColor = Color.GreenYellow
                'grdPrestamos.Rows(contadorfilas).Cells("clmtotalabono").Style.ForeColor = Color.Black
            End If

        Catch ex As Exception
        End Try
    End Sub

    Public Sub AgregarFilaDePrestamosPorCobrar(ByVal Prestamos As Entidades.SolicitudPrestamo)
        Dim objSolicitud = New Entidades.CobranzaPrestamos
        Dim fechaModificacion As DateTime
        Dim fechaCreacion As DateTime

        Dim contador As Integer = 0
        Dim interes As Double
        Dim saldo As Double
        Dim tasaInteres As Double
        Dim tipoInteres As String
        Dim abonoCapital As Double
        Dim abonoExtra As String = ""
        Dim TotalSaldo As Double



        If lblEstatusSemanaPrestamos.Text = "C" Then

        Else
            tipoInteres = Prestamos.Ptipointeres
            tasaInteres = Prestamos.Pinteres
            interes = 0
            interes = 7 * (tasaInteres / 30.4)
            interes = interes / 100

            fechaModificacion = Prestamos.Pfechamodificacion.ToShortDateString
            fechaCreacion = Prestamos.PfechaCreacion.ToShortDateString

            ' If (fechaCreacion <= fechaFinNomina And fechaCreacion >= fechaInicioNomina) Or Prestamos.Pestatus = "F" Then
            tipoInteres = Prestamos.Ptipointeres
            saldo = Prestamos.Psaldo
            TotalSaldo = Prestamos.Pmontoprestamo


            Dim listaValidacionAbonosExtraordinarios As New List(Of Entidades.CobranzaPrestamos)
            Dim cobranzaBu As New Nomina.Negocios.CobranzaPrestamosBU
            listaValidacionAbonosExtraordinarios = cobranzaBu.ValidarAbonosExtraordinarios(lblIdSemanaNomina.Text, Prestamos.Pprestamoid, "B")

            For Each dato As Entidades.CobranzaPrestamos In listaValidacionAbonosExtraordinarios
                abonoCapital = dato.PAbonoCobranza
                interes = dato.PInteresCobranza
                abonoExtra = "AE"
                contador += 1
            Next

            If contador = 0 Then

                ''INTERES QUE PAGARA INICIA
                If tipoInteres.Equals("I") Then
                    interes = 0
                Else
                    If tipoInteres.Equals("F") Then
                        interes = Prestamos.Pmontoprestamo * interes
                        interes = (Math.Round(interes, 0))
                    Else
                        If tipoInteres.Equals("S") Then
                            interes = Prestamos.Psaldo * interes
                            interes = Math.Round(interes, 0)
                        End If
                    End If
                End If



                ''OBTENER ABONO CAPITAL
                If tipoInteres.Equals("I") Then
                    abonoCapital = Prestamos.Pabono
                Else
                    If tipoInteres.Equals("F") Then
                        abonoCapital = Prestamos.Pabono - interes
                    Else
                        If tipoInteres.Equals("S") Then
                            abonoCapital = Prestamos.Pabono - interes
                        End If
                    End If
                End If

                '' CALCULAR INTERES CUANDO EL ABONO ES CERO
                If Prestamos.Pabono = 0 Then
                    interes = interes
                    interes = Math.Round(interes, 0)
                    abonoCapital = 0
                End If
                ''Validacion cuando el abono capital ya es mayor al saldo que tiene
                If abonoCapital > Prestamos.Psaldo Then

                    If tipoInteres.Equals("I") Then
                        abonoCapital = Prestamos.Psaldo
                        abonoCapital = Math.Round(abonoCapital, 2)
                    Else
                        If tipoInteres.Equals("F") Then
                            abonoCapital = Prestamos.Psaldo
                            abonoCapital = Math.Round(abonoCapital, 2)
                        Else
                            If tipoInteres.Equals("S") Then
                                abonoCapital = Prestamos.Psaldo
                                abonoCapital = Math.Round(abonoCapital, 2)

                            End If
                        End If
                    End If
                End If
            End If

            grdPrestamos.Rows.Add( _
                Prestamos.Pprestamoid, _
                Prestamos.PcobranzaPrestamos.PnumPago, _
                False, _
                grdPrestamos.RowCount + 1, _
                Prestamos.PcobranzaPrestamos.PnumPago.ToString + " / " + Prestamos.Psemanas.ToString, _
                Prestamos.Pcolaborador.PNombre + " " + Prestamos.Pcolaborador.PApaterno + " " + Prestamos.Pcolaborador.PAmaterno, _
                TotalSaldo, _
                saldo, _
                interes, _
                abonoCapital, _
                interes + abonoCapital, _
                saldo - abonoCapital, _
                saldo + interes, _
                interes, _
                "PC", _
                fechaPago, _
                abonoExtra, _
                Prestamos.Pcolaborador.PNaveID
                )
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        '    If fechaModificacion <= fechaFinNomina And fechaModificacion >= fechaInicioNomina Then
        '    Else
        '        tipoInteres = Prestamos.Ptipointeres
        '        saldo = Prestamos.Psaldo
        '        TotalSaldo = Prestamos.Pmontoprestamo

        '        abonoExtra = ""
        '        contador = 0
        '        tasaInteres = Prestamos.Pinteres
        '        interes = 0
        '        interes = 7 * (tasaInteres / 30.4)
        '        interes = interes / 100

        '        Dim listaValidacionAbonosExtraordinarios As New List(Of Entidades.CobranzaPrestamos)
        '        Dim cobranzaBu As New Nomina.Negocios.CobranzaPrestamosBU
        '        listaValidacionAbonosExtraordinarios = cobranzaBu.ValidarAbonosExtraordinarios(lblIdSemanaNomina.Text, Prestamos.Pprestamoid, "B")

        '        For Each dato As Entidades.CobranzaPrestamos In listaValidacionAbonosExtraordinarios
        '            abonoCapital = dato.PAbonoCobranza
        '            interes = dato.PInteresCobranza
        '            abonoExtra = "AE"
        '            contador += 1
        '        Next

        '        If contador = 0 Then
        '            ''INTERES QUE PAGARA INICIA
        '            If tipoInteres.Equals("I") Then
        '                interes = 0
        '            Else
        '                If tipoInteres.Equals("F") Then
        '                    interes = Prestamos.Pmontoprestamo * interes
        '                    interes = (Math.Round(interes, 0))
        '                Else
        '                    If tipoInteres.Equals("S") Then
        '                        interes = Prestamos.Psaldo * interes
        '                        interes = Math.Round(interes, 0)
        '                    End If
        '                End If
        '            End If
        '            ''OBTENER ABONO CAPITAL
        '            If tipoInteres.Equals("I") Then
        '                abonoCapital = Prestamos.Pabono
        '            Else
        '                If tipoInteres.Equals("F") Then
        '                    abonoCapital = Prestamos.Pabono - interes
        '                Else
        '                    If tipoInteres.Equals("S") Then
        '                        abonoCapital = Prestamos.Pabono - interes
        '                    End If
        '                End If
        '            End If
        '            ''Validacion cuando el abono capital ya es mayor al saldo que tiene
        '            If abonoCapital > Prestamos.Psaldo Then
        '                If tipoInteres.Equals("I") Then
        '                    abonoCapital = Prestamos.Psaldo
        '                    abonoCapital = Math.Round(abonoCapital, 2)
        '                    ''TOTAL ABONO
        '                Else
        '                    If tipoInteres.Equals("F") Then
        '                        abonoCapital = Prestamos.Psaldo
        '                        abonoCapital = Math.Round(abonoCapital, 2)
        '                        ''TOTAL ABONO
        '                    Else
        '                        If tipoInteres.Equals("S") Then
        '                            abonoCapital = Prestamos.Psaldo
        '                            abonoCapital = Math.Round(abonoCapital, 2)
        '                            ''TOTAL ABONO
        '                        End If
        '                    End If
        '                End If
        '            End If
        '        End If

        '        grdPrestamos.Rows.Add( _
        '            Prestamos.Pprestamoid, _
        '            Prestamos.PcobranzaPrestamos.PnumPago, _
        '            False, _
        '            grdPrestamos.RowCount + 1, _
        '            Prestamos.PcobranzaPrestamos.PnumPago.ToString + " / " + Prestamos.Psemanas.ToString, _
        '            Prestamos.Pcolaborador.PNombre + " " + Prestamos.Pcolaborador.PApaterno + " " + Prestamos.Pcolaborador.PAmaterno, _
        '            TotalSaldo, _
        '            saldo, _
        '            interes, _
        '            abonoCapital, _
        '            interes + abonoCapital, _
        '            saldo - abonoCapital, _
        '            saldo + interes, _
        '            interes, _
        '            "PC", _
        '            fechaPago, _
        '            abonoExtra _
        '            )
        '    End If
        'End If
    End Sub
    ''LLENAR PRESTAMOS POR COBRAR

    ''LLENAR PRESTAMOS COBRADOS
    Public Sub llenarTablaConPrestamosCOBRADOS()
        Try
            Dim listaConfiguracionPrestamos As New List(Of Entidades.SolicitudPrestamo)
            Dim prestamosBU As New Nomina.Negocios.CobranzaPrestamosBU
            Dim semanaNominaId As Integer
            semanaNominaId = lblIdSemanaNomina.Text

            listaConfiguracionPrestamos = prestamosBU.ListaPrestamosCobrados(semanaNominaId)

            For Each objeto As Entidades.SolicitudPrestamo In listaConfiguracionPrestamos
                AgregarFilaDePrestamosCOBRADOS(objeto)
            Next

            Dim total As Double = 0
            Dim contadorFilas As Integer = 0
            For Each row As DataGridViewRow In grdPrestamos.Rows
                total += row.Cells("clmtotalabono").Value
                contadorFilas += 1
            Next
            For Each row As DataGridViewRow In grdPrestamos.Rows
                row.Cells(10).Style.BackColor = Color.LightGreen
                row.Cells(11).Style.BackColor = Color.LightGreen



            Next
            If contadorFilas > 0 Then
                grdPrestamos.Rows.Add("", "", False, "", "", "", "", "", "", "", total.ToString("N0"), "")
                grdPrestamos.Rows(contadorFilas).DefaultCellStyle.BackColor = Color.GreenYellow
            End If

        Catch ex As Exception
        End Try
    End Sub

    Public Sub AgregarFilaDePrestamosCOBRADOS(ByVal Prestamos As Entidades.SolicitudPrestamo)

        Dim numPago As Int16
        Dim fechaModificacion As DateTime
        Dim interes As Double
        Dim interes2 As Double
        Dim Saldo As Double
        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow
        Dim tasaInteres As Double
        Dim abonoCapital As Double
        Dim TotalSaldo As Double
        tasaInteres = Prestamos.Pinteres

        interes = 0
        interes = 7 * (tasaInteres / 30.4)
        interes = interes / 100

        fechaModificacion = Prestamos.Pfechamodificacion.ToShortDateString

        numPago = Prestamos.PcobranzaPrestamos.PnumPago

        Dim tipoInteres As String
        tipoInteres = Prestamos.Ptipointeres

        ''ID DEL PRESTAMO
        celda = New DataGridViewTextBoxCell
        celda.Value = Prestamos.Pprestamoid
        fila.Cells.Add(celda)



        'NUMERO DE PAGO
        celda = New DataGridViewTextBoxCell
        celda.Value = numPago
        fila.Cells.Add(celda)

        ''condonar
        celda = New DataGridViewCheckBoxCell
        celda.Value = False
        fila.Cells.Add(celda)

        ''CONSECUTIVO
        celda = New DataGridViewTextBoxCell
        celda.Value = grdPrestamos.RowCount + 1
        fila.Cells.Add(celda)

        ''NUMERO DE PAGO/ PAGOS
        celda = New DataGridViewTextBoxCell
        celda.Value = numPago.ToString + " / " + Prestamos.Psemanas.ToString
        fila.Cells.Add(celda)

        'NOMBRE DEL COLABORADOR
        celda = New DataGridViewTextBoxCell
        celda.Value = Prestamos.Pcolaborador.PNombre + " " + Prestamos.Pcolaborador.PApaterno + " " + Prestamos.Pcolaborador.PAmaterno
        fila.Cells.Add(celda)

        ''MONTO TOTAL DEL PRESTAMOS
        celda = New DataGridViewTextBoxCell
        TotalSaldo = Prestamos.Pmontoprestamo
        celda.Value = TotalSaldo
        fila.Cells.Add(celda)

        ''SALDO ANTERIOR
        celda = New DataGridViewTextBoxCell

        celda.Value = Prestamos.PcobranzaPrestamos.PsaldoAnterior
        fila.Cells.Add(celda)

        ''INTERES QUE PAGARA INICIA
        If tipoInteres.Equals("I") Then
            celda = New DataGridViewTextBoxCell
            interes2 = 0
            celda.Value = 0
            fila.Cells.Add(celda)
        Else
            If tipoInteres.Equals("F") Then
                celda = New DataGridViewTextBoxCell
                interes2 = Prestamos.Pinteres
                celda.Value = interes2
                fila.Cells.Add(celda)
            Else
                If tipoInteres.Equals("S") Then
                    celda = New DataGridViewTextBoxCell
                    interes2 = Prestamos.Pinteres
                    celda.Value = interes2
                    fila.Cells.Add(celda)
                End If
            End If
        End If
        ''INTERES QUE PAGARA TERMINA

        ''ABONO CAPITAL INICIA
        If tipoInteres.Equals("I") Then
            celda = New DataGridViewTextBoxCell
            abonoCapital = Prestamos.Pabono
            celda.Value = Prestamos.Pabono
            fila.Cells.Add(celda)
        Else
            If tipoInteres.Equals("F") Then
                celda = New DataGridViewTextBoxCell
                abonoCapital = Prestamos.Pabono
                celda.Value = abonoCapital
                fila.Cells.Add(celda)
            Else
                If tipoInteres.Equals("S") Then
                    celda = New DataGridViewTextBoxCell
                    abonoCapital = Prestamos.Pabono
                    celda.Value = abonoCapital
                    fila.Cells.Add(celda)
                End If
            End If
        End If

        ''ABONO CAPITAL TERMINA
        ''INICIA TOTAL ABONO
        If tipoInteres.Equals("I") Then
            celda = New DataGridViewTextBoxCell
            celda.Value = Prestamos.Pabono + tasaInteres
            fila.Cells.Add(celda)
        Else
            If tipoInteres.Equals("F") Then
                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pabono + tasaInteres
                fila.Cells.Add(celda)
            Else
                If tipoInteres.Equals("S") Then
                    celda = New DataGridViewTextBoxCell
                    celda.Value = Prestamos.Pabono + tasaInteres
                    fila.Cells.Add(celda)
                End If
            End If
        End If
        'TERMINA TOTAL ABONO
        ''NUEVO SALDO INICIA
        If tipoInteres.Equals("I") Then
            celda = New DataGridViewTextBoxCell
            Saldo = Prestamos.Psaldo
            celda.Value = Prestamos.Psaldo
            fila.Cells.Add(celda)
        Else
            If tipoInteres.Equals("F") Then
                celda = New DataGridViewTextBoxCell
                Saldo = Prestamos.Psaldo
                celda.Value = Prestamos.Psaldo
                fila.Cells.Add(celda)
            Else
                If tipoInteres.Equals("S") Then
                    celda = New DataGridViewTextBoxCell
                    Saldo = Prestamos.Psaldo
                    celda.Value = Prestamos.Psaldo
                    fila.Cells.Add(celda)
                End If
            End If
        End If
        ''NUEVO SALDO TERMINA
        ''LIQUIDA CON
        celda = New DataGridViewTextBoxCell
        celda.Value = interes2 + Saldo
        fila.Cells.Add(celda)

        ''LIQUIDA CON
        ''RESPALDO INTERES QUE PAGARA INICIA
        If tipoInteres.Equals("I") Then
            celda = New DataGridViewTextBoxCell
            celda.Value = 0
            fila.Cells.Add(celda)
        Else
            If tipoInteres.Equals("F") Then
                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pmontoprestamo * interes
                fila.Cells.Add(celda)
            Else
                If tipoInteres.Equals("S") Then
                    celda = New DataGridViewTextBoxCell
                    celda.Value = Prestamos.Psaldo * interes
                    fila.Cells.Add(celda)
                End If
            End If
        End If
        '' RESPALDO INTERES QUE PAGARA TERMINA

        celda = New DataGridViewTextBoxCell
        celda.Value = "C"
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = fechaPago
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Prestamos.Pcolaborador.PNaveID
        fila.Cells.Add(celda)

        grdPrestamos.Rows.Add(fila)

        For Each row As DataGridViewRow In grdPrestamos.Rows
            row.Cells(0).Style.BackColor = Color.LightGreen
            row.Cells(1).Style.BackColor = Color.LightGreen
            row.Cells(2).Style.BackColor = Color.LightGreen
            row.Cells(3).Style.BackColor = Color.LightGreen
            row.Cells(4).Style.BackColor = Color.LightGreen
            row.Cells(5).Style.BackColor = Color.LightGreen
            row.Cells(6).Style.BackColor = Color.LightGreen
            row.Cells(7).Style.BackColor = Color.LightGreen
            row.Cells(8).Style.BackColor = Color.LightGreen
            row.Cells(9).Style.BackColor = Color.LightGreen
            row.Cells("clmLiquidacion").Style.BackColor = Color.LightGreen

            row.Cells(0).ReadOnly = True
            row.Cells(1).ReadOnly = True
            row.Cells(2).ReadOnly = True
            row.Cells(3).ReadOnly = True
            row.Cells(4).ReadOnly = True
            row.Cells(5).ReadOnly = True
            row.Cells(6).ReadOnly = True
            row.Cells(7).ReadOnly = True
            row.Cells("clmtotalabono").ReadOnly = True
        Next
    End Sub
    ''LLENAR PRESTAMOS COBRADOS

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

        lblsemananomina2.Text = SemanaActiva.PsemanaNomina
        lblIdSemanaNomina.Text = SemanaActiva.PsemanaNominaId
        lblfechainicio.Text = SemanaActiva.PfechaInicioNomina.ToString("MM/dd/yyyy")
        lblfechafin.Text = SemanaActiva.PfechaFinNomina.ToString("MM/dd/yyyy")
        fechaPago = SemanaActiva.PfechaFinNomina
        fechaInicioNomina = SemanaActiva.PfechaInicioNomina.ToShortDateString
        fechaFinNomina = SemanaActiva.PfechaFinNomina.ToShortDateString
        EstatusSemanaNomina.Text = SemanaActiva.PPeriodoNominaPrestamos
        lblEstatusSemanaPrestamos.Text = SemanaActiva.PPeriodoNominaPrestamos
        lblConceptoNomina.Text = SemanaActiva.PConceptoSemana

        If SemanaActiva.PsemanaNomina = "A" Then
            btnBuscar.Enabled = True
            btncobrar.Enabled = False
        Else
            btnBuscar.Enabled = False
            btncobrar.Enabled = False
        End If

    End Sub
    ''
    Private Sub grdPrestamos_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPrestamos.CellLeave
        Dim TotalAbono As Double = 0
        Dim estaMal As Integer = 0
        If e.ColumnIndex = 8 Then
            Try
                For Each row As DataGridViewRow In grdPrestamos.Rows
                    If row.Cells("clmCobrado").Value = "PC" Then

                        'SI EL ABONO ES IGUAL A 0 ENTONCES NO DARA INTERES NI ABONO CAPITA.L
                        If row.Cells("clmtotalabono").Value = 0 Then
                            row.Cells("clminteres").Value = 0
                            row.Cells("clmabonocapital").Value = 0
                            row.Cells("clmtotalabono").Style.BackColor = Color.LightYellow
                            row.Cells("clmsaldo").Value = row.Cells("clmsaldoanterior").Value
                        Else
                            'VALIDADION PARA QUE EL TOTAL DE ABONO NO SOBRE PASE EL SANDO QUE TIENE
                            If (row.Cells("clmtotalabono").Value - row.Cells("clminteres").Value) > row.Cells("clmsaldoanterior").Value Then
                                row.Cells("clmtotalabono").Style.BackColor = Color.Salmon
                                row.Cells("clmsaldo").Value = row.Cells("clmsaldoanterior").Value
                                estaMal = 1
                            Else
                                'VALIDA QUE NO DE UN ABONO MENOR A LOS INTERESES
                                If row.Cells("clmtotalabono").Value < row.Cells("clmInteres2").Value And row.Cells("clmtotalabono").Value > 0 Then
                                    row.Cells("clmtotalabono").Style.BackColor = Color.LightSalmon
                                    row.Cells("clminteres").Value = row.Cells("clmInteres2").Value
                                    estaMal = 1
                                Else
                                    row.Cells("clmtotalabono").Style.BackColor = Color.LightYellow
                                    row.Cells("clminteres").Value = row.Cells("clmInteres2").Value
                                    row.Cells("clmabonocapital").Value = row.Cells("clmtotalabono").Value - row.Cells("clmInteres2").Value
                                    row.Cells("clmsaldo").Value = row.Cells("clmsaldoanterior").Value - row.Cells("clmabonocapital").Value
                                    TotalAbono = row.Cells("clmtotalabono").Value
                                    row.Cells("clmtotalabono").Value = TotalAbono
                                End If
                            End If
                        End If
                    End If
                Next
                If estaMal = 1 Then
                    btncobrar.Enabled = False
                Else
                    btncobrar.Enabled = True
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub grdPrestamos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPrestamos.CellValueChanged
        Dim TotalAbono As Double = 0
        Dim Interes As Double = 0
        Dim Saldo As Double = 0
        Dim AbonoCapital As Double = 0
        Dim estaMal As Integer = 0

        If e.ColumnIndex = 8 Then
            Try
                For Each row As DataGridViewRow In grdPrestamos.Rows
                    If row.Cells("clmCobrado").Value = "PC" Then
                        ''SI EL ABONO ES IGUAL A 0 ENTONCES NO DARA INTERES NI ABONO CAPITA.L
                        If row.Cells("clmtotalabono").Value = 0 Then
                            row.Cells("clminteres").Value = 0
                            row.Cells("clmabonocapital").Value = 0
                            row.Cells("clmsaldo").Value = row.Cells("clmsaldoanterior").Value
                        Else
                            ''VALIDADION PARA QUE EL TOTAL DE ABONO NO SOBRE PASE EL SALDO QUE TIENE
                            If row.Cells("clmtotalabono").Value > row.Cells("clmLiquidacion").Value Then
                                row.Cells("clmtotalabono").Style.BackColor = Color.Salmon
                                row.Cells("clmsaldo").Value = row.Cells("clmsaldoanterior").Value
                                estaMal = 1

                            Else
                                ''VALIDA QUE NO DE UN ABONO MENOR A LOS INTERESES
                                If row.Cells("clmtotalabono").Value < row.Cells("clmInteres2").Value And row.Cells("clmtotalabono").Value > 0 Then
                                    row.Cells("clmtotalabono").Style.BackColor = Color.Salmon
                                    row.Cells("clminteres").Value = row.Cells("clmInteres2").Value
                                    estaMal = 1
                                Else
                                    row.Cells("clmtotalabono").Style.BackColor = Color.LightYellow
                                    row.Cells("clminteres").Value = row.Cells("clmInteres2").Value
                                    row.Cells("clmabonocapital").Value = row.Cells("clmtotalabono").Value - row.Cells("clmInteres2").Value
                                    row.Cells("clmsaldo").Value = row.Cells("clmsaldoanterior").Value - row.Cells("clmabonocapital").Value
                                    TotalAbono = row.Cells("clmtotalabono").Value
                                    row.Cells("clmtotalabono").Value = TotalAbono

                                End If
                            End If
                        End If
                    End If
                Next
                If estaMal = 1 Then
                    btncobrar.Enabled = False
                Else
                    btncobrar.Enabled = True
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnenviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncobrar.Click
        Dim contadorFilas As Integer = 0
        For Each row As DataGridViewRow In grdPrestamos.Rows
            contadorFilas += 1
        Next

        If contadorFilas > 0 Then
            Dim objBU As New Negocios.CobranzaPrestamosBU

            If objBU.validaPeriodoAnterior(CInt(lblIdSemanaNomina.Text), CInt(cmbNave.SelectedValue)) Then
                Dim mensajeExito As New ConfirmarForm
                mensajeExito.mensaje = "¿Esta seguro de querer realizar el cierre de préstamos?. "

                If mensajeExito.ShowDialog = DialogResult.OK Then
                    btncobrar.Enabled = False
                    ObtenerDatosReportePrestamos()
                    cobrarPrestamo()
                    grdPrestamos.Rows.Clear()
                    lblsemananomina.Text = ""
                    cmbNave.SelectedIndex = 0

                End If
            Else
                Dim mensajeAdv As New AdvertenciaForm
                mensajeAdv.mensaje = "No se puede cerrar semana si el periodo de nómina anterior no ha sido cerrado."
            End If
        End If
    End Sub

    Public Sub ObtenerDatosReportePrestamos()

        Dim objBU = New Nomina.Negocios.CobranzaPrestamosBU
        Dim ObjEntSol = New Entidades.SolicitudPrestamo
        Dim filas As Integer = grdPrestamos.Rows.Count
        Dim contador As Integer = 1

        Dim vXmlCeldas As XElement = New XElement("Celdas")
        For Each row As DataGridViewRow In grdPrestamos.Rows
            If contador < filas Then
                Dim vNodo As XElement = New XElement("Celda")
                vNodo.Add(New XAttribute("PprestamoId", row.Cells(0).Value))
                vNodo.Add(New XAttribute("PMontoPrestamo", row.Cells(6).Value))
                vNodo.Add(New XAttribute("PSemanaNominaId", lblIdSemanaNomina.Text))
                vNodo.Add(New XAttribute("PsaldoAnterior", row.Cells("clmsaldoanterior").Value))
                vNodo.Add(New XAttribute("Pinteres", row.Cells("clminteres").Value))
                vNodo.Add(New XAttribute("PSaldo", row.Cells("clmsaldo").Value))
                vNodo.Add(New XAttribute("PnumPago", row.Cells("clmNumPago").Value))
                vNodo.Add(New XAttribute("PTotalAbono", row.Cells(10).Value))
                vNodo.Add(New XAttribute("PabonoCapital", row.Cells("clmabonocapital").Value))
                vXmlCeldas.Add(vNodo)
            End If
            contador += 1
        Next

        objBU.guardarDatosReporteConcentradoPrestamos(vXmlCeldas.ToString())


    End Sub


    Public Sub cobrarPrestamo()
        Dim objBU = New Nomina.Negocios.CobranzaPrestamosBU
        Dim ObjEnt = New Entidades.CobranzaPrestamos
        Dim ObjEntSol = New Entidades.SolicitudPrestamo
        Dim objEntColaborador = New Entidades.Colaborador
        Dim contador As Integer = 0
        Dim mensaje As String = ""
        Try


            For Each row As DataGridViewRow In grdPrestamos.Rows
                If row.Cells("clmCobrado").Value = "PC" Then
                    If row.Cells("clmColaborador").Value <> "" Then
                        If row.Cells("clmsaldo").Value < 0 Then

                            row.Cells("clmsaldo").Style.BackColor = Color.LightSalmon
                            row.Cells("clmtotalabono").Style.BackColor = Color.LightSalmon
                            mensaje = "Las filas en rojo no se guardaron por errores en los saldos."
                        Else


                            ObjEntSol.Pprestamoid = CInt(row.Cells(0).Value)
                            ObjEnt.PsemanaNominaId = CInt(lblIdSemanaNomina.Text)
                            ObjEnt.PnumPago = CInt(row.Cells("clmNumPago").Value)
                            ObjEnt.PsaldoAnterior = row.Cells("clmsaldoanterior").Value
                            ObjEntSol.Pinteres = row.Cells("clminteres").Value
                            ObjEntSol.Psaldo = row.Cells("clmsaldo").Value
                            ObjEntSol.Pfechamodificacion = fechaPago
                            objEntColaborador.PColaboradorid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                            objEntColaborador.PNaveID = CInt(row.Cells("naveid").Value)
                            If row.Cells("clmAbonoExtraordinario").Value = "AE" Then
                                ObjEnt.PTipoAbono = "B"
                            Else
                                ObjEnt.PTipoAbono = "A"
                            End If

                            If row.Cells("clmCondonar").Value = True Then
                                ObjEnt.Pliquidacion = 1
                                ObjEntSol.Pabono = 0
                            ElseIf CInt(row.Cells("clmsaldo").Value) = 0 Then
                                ObjEnt.Pliquidacion = 1
                                ObjEntSol.Pabono = row.Cells("clmabonocapital").Value
                            Else
                                ObjEnt.Pliquidacion = 0
                                ObjEntSol.Pabono = row.Cells("clmabonocapital").Value
                            End If

                            ObjEnt.Pcolaborador = objEntColaborador
                            ObjEnt.PSolicitudPrestamo = ObjEntSol
                            objBU.guardarCobranza(ObjEnt)

                        End If
                    End If
                    contador += 1
                End If
            Next
            If contador > 0 Then
                Dim mensajeExito As New ExitoForm
                mensajeExito.MdiParent = Me.MdiParent
                mensajeExito.mensaje = "Cierre semanal de préstamos guardado." + mensaje.ToString
                mensajeExito.Show()
                btnBuscar.Enabled = True
                grdPrestamos.Rows.Clear()
                cmbNave.SelectedIndex = 0
                llenarTablaConPrestamosPorCobrar()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNave.DropDownClosed
        grdPrestamos.Rows.Clear()
        SemanaNomina()
        cmbEstatus.SelectedIndex = 0
    End Sub

    Private Sub btnEditarCobro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditarCobro.Click
        '28/02/14 - Actualmente no se usa.
        Dim objEditar As New EditarCobranzaPrestamos
        objEditar.Show()
    End Sub

    ''Metodo para que solo se ingresen NUMEROS y UN punto en un datagridview
    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdPrestamos.EditingControlShowing
        ' referencia a la celda 
        Dim validar As TextBox = CType(e.Control, TextBox)
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    ''Evento key press para validacion del datagridview
    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' evento Keypress  
        ' obtener indice de la columna  
        Dim columna As Integer = grdPrestamos.CurrentCell.ColumnIndex
        ' comprobar si la celda en edición corresponde a la columna que se requiera
        If columna = 8 Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar
            ' referencia a la celda  
            Dim txt As TextBox = CType(sender, TextBox)
            ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
            ' es el separador decimal, y que no contiene ya el separador  
            If (Char.IsNumber(caracter)) Or _
(caracter = ChrW(Keys.Back)) Or _
            (caracter = ".") And _
            (txt.Text.Contains(".") = False) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 111
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            grdPrestamos.Rows.Clear()
            If cmbEstatus.SelectedIndex = 1 Then
                If lblEstatusSemanaPrestamos.Text = "A" Then

                    llenarTablaConPrestamosPorCobrar()
                    btncobrar.Enabled = True
                Else
                    btncobrar.Enabled = False
                End If
            End If
            If cmbEstatus.SelectedIndex = 2 Then
                If lblEstatusSemanaPrestamos.Text = "C" Then
                    llenarTablaConPrestamosCOBRADOS()
                    btncobrar.Enabled = False
                    lblcobrar.Enabled = False
                    lblcobrar2.Enabled = False
                    clmCondonar.Visible = False
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grdPrestamos.Rows.Clear()
        cmbNave.SelectedIndex = 0
        cmbEstatus.SelectedIndex = 0
        btncobrar.Enabled = True

    End Sub

    Private Sub btnCncelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objEditar As New AbonoExtraordinarioPrestamoForm
        objEditar.ShowDialog()
    End Sub

    Private Sub btnLimpiar_Click_1(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdPrestamos.Rows.Clear()
        cmbNave.SelectedIndex = 0
        cmbEstatus.SelectedIndex = 0
        btncobrar.Enabled = True
        lblConceptoNomina.Text = "-"
    End Sub

    Private Sub btnBuscar_Click_1(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Try

            grdPrestamos.Rows.Clear()
            If cmbEstatus.SelectedIndex = 1 Then
                If lblEstatusSemanaPrestamos.Text = "A" Then

                    llenarTablaConPrestamosPorCobrar()
                    btncobrar.Enabled = True
                Else
                    btncobrar.Enabled = False
                End If
            End If
            If cmbEstatus.SelectedIndex = 2 Then
                If lblEstatusSemanaPrestamos.Text = "C" Then
                    llenarTablaConPrestamosCOBRADOS()
                    btncobrar.Enabled = False
                    lblcobrar.Enabled = False
                    lblcobrar2.Enabled = False
                    clmCondonar.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
        Me.Cursor = System.Windows.Forms.Cursors.Default
        validarCierreSemanal()
    End Sub

    '' Si existen prestamos en estatus entregado deshabilitar botón de guardar
    Public Sub validarCierreSemanal()
        Dim objBU As New Negocios.CobranzaPrestamosBU
        Dim dtEstatusPrestamos As New DataTable
        Dim idNave As Int32 = 0
        Dim advertencia As New AdvertenciaForm
        idNave = (Int(cmbNave.SelectedValue))
        dtEstatusPrestamos = objBU.validarCierreSemanalEstatusEntregado(idNave)
        If dtEstatusPrestamos.Rows.Count > 0 Then
            btncobrar.Enabled = False
            lblcobrar.Enabled = False
            lblcobrar2.Enabled = False
            advertencia.mensaje = "Aún cuenta con préstamos en estatus entregado a nave, no es posible cerrar semana"
            advertencia.ShowDialog()
        Else
            btncobrar.Enabled = True
            lblcobrar.Enabled = True
            lblcobrar2.Enabled = True
        End If
    End Sub
End Class