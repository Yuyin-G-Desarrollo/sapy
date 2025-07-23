Imports Tools

Public Class AbonoExtraordinarioPrestamoForm
    Dim fechaPago As DateTime
    Dim fechaInicioNomina As DateTime
    Dim fechaFinNomina As DateTime
    Private Sub AbonoAdelantadoPrestamoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        grdPrestamos.Columns("clmColaborador").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdPrestamos.Columns("clmMontototal").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdPrestamos.Columns("clmSaldoActual").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdPrestamos.Columns("clmInteres").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdPrestamos.Columns("clmabonocapital").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdPrestamos.Columns("clmabono").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdPrestamos.Columns("clmsaldo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdPrestamos.Columns("clmNum").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter


        'Tools.FormatoCtrls.formato(Me)
        Try
            Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

            If (Not cmbNave.SelectedValue Is Nothing Or cmbNave.SelectedValue > 0) Then
                grdPrestamos.Rows.Clear()
                SemanaNomina()
                If lblEstatusSemanaPrestamos.Text = "C" Then
                    Dim mensajeExito As New AvisoForm
                    'mensajeExito.MdiParent = Me.MdiParent
                    mensajeExito.mensaje = "El periodo de préstamos de esta nave ya fue cerrado."
                    mensajeExito.ShowDialog()
                End If
            End If


        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 109
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If (cmbNave.SelectedValue Is Nothing Or cmbNave.SelectedValue <= 0) Then
            lblNave.ForeColor = Color.Red
        Else
            lblNave.ForeColor = Color.Black
        End If

        If (cmbTipoAbono.Text = "") Then
            lblTipoAbono.ForeColor = Color.Red
        Else
            lblTipoAbono.ForeColor = Color.Black
        End If

        Me.Cursor = Cursors.WaitCursor
        grdPrestamos.Rows.Clear()
        If lblEstatusSemanaPrestamos.Text = "A" Then
            If chkGuardados.Checked = False Then
                llenarTablaConPrestamos()
            ElseIf chkGuardados.Checked = True Then
                llenarTablaAbonosExtraordinariosGuardados()
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmbNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNave.DropDownClosed
        grdPrestamos.Rows.Clear()
        SemanaNomina()
        If lblEstatusSemanaPrestamos.Text = "C" Then
            Dim mensajeExito As New AvisoForm
            ' mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "El periodo de préstamos de esta nave ya fue cerrado."
            mensajeExito.ShowDialog()
        End If

    End Sub


    Public Sub SemanaNomina()
        Try
            Dim SemanaNominaActiva As New List(Of Entidades.CobranzaPrestamos)
            Dim SenamaActivaBu As New Nomina.Negocios.CobranzaPrestamosBU
            Dim idNave As Integer
            idNave = (Int(cmbNave.SelectedValue))
            SemanaNominaActiva = SenamaActivaBu.SemanaNominaActiva(idNave)

            For Each objeto As Entidades.CobranzaPrestamos In SemanaNominaActiva
                lblsemananomina2.Text = objeto.PsemanaNomina
                lblIdSemanaNomina.Text = objeto.PsemanaNominaId
                lblfechainicio.Text = objeto.PfechaInicioNomina.ToString("MM/dd/yyyy")
                lblfechafin.Text = objeto.PfechaFinNomina.ToString("MM/dd/yyyy")
                fechaPago = objeto.PfechaFinNomina
                fechaInicioNomina = objeto.PfechaInicioNomina.ToShortDateString
                fechaFinNomina = objeto.PfechaFinNomina.ToShortDateString
                EstatusSemanaNomina.Text = objeto.PPeriodoNominaPrestamos
                lblEstatusSemanaPrestamos.Text = objeto.PPeriodoNominaPrestamos
                lblPeriodoNomina.Text = objeto.PConceptoSemana

                If objeto.PsemanaNomina = "A" Then
                    btnBuscar.Enabled = True
                    btnGuardar.Enabled = False
                Else
                    btnBuscar.Enabled = False
                    btnGuardar.Enabled = False
                End If
            Next

        Catch ex As Exception
        End Try
    End Sub

    ''LLENAR PRESTAMOS POR COBRAR
    Public Sub llenarTablaConPrestamos()
        Try
            Dim listaConfiguracionPrestamos As New List(Of Entidades.SolicitudPrestamo)
            Dim listaValidarAbonosExtraordinarios As New List(Of Entidades.CobranzaPrestamos)
            Dim cobranzaBU As New Negocios.CobranzaPrestamosBU
            Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU
            Dim idNave As Integer
            Dim Colaborador As String = ""
            Dim interes As Double = 0
            Dim tasaInteres As Double = 0
            Dim tipoInteres As String
            Dim abonoCapital As Double
            idNave = (Int(cmbNave.SelectedValue))
            listaConfiguracionPrestamos = prestamosBU.ListaPrestamosCobrar(idNave)
            If cmbTipoAbono.Text = "DENTRO DE NOMINA" Then
                For Each objeto As Entidades.SolicitudPrestamo In listaConfiguracionPrestamos
                    ''VALIDA SI YA HAY ALGUNO PAGO DADO DE ALTA
                    listaValidarAbonosExtraordinarios = cobranzaBU.ValidarAbonosExtraordinarios(lblIdSemanaNomina.Text, objeto.Pprestamoid, "B")
                    Dim contador As Integer = 0
                    For Each dato As Entidades.CobranzaPrestamos In listaValidarAbonosExtraordinarios
                        contador += 1
                    Next
                    ''SI NO TIENE PAGOS ENTRA AL IF
                    If contador = 0 Then
                        tipoInteres = objeto.Ptipointeres
                        tasaInteres = objeto.Pinteres
                        interes = 0
                        interes = 7 * (tasaInteres / 30.4)
                        interes = interes / 100

                        ''INTERES QUE PAGARA INICIA
                        If tipoInteres.Equals("I") Then
                            interes = 0
                        Else
                            If tipoInteres.Equals("F") Then
                                interes = objeto.Pmontoprestamo * interes
                                interes = (Math.Round(interes, 0))
                            Else
                                If tipoInteres.Equals("S") Then
                                    interes = objeto.Psaldo * interes
                                    interes = Math.Round(interes, 0)
                                End If
                            End If
                        End If
                        ''OBTENER ABONO CAPITAL
                        If tipoInteres.Equals("I") Then
                            abonoCapital = objeto.Pabono
                        Else
                            If tipoInteres.Equals("F") Then
                                abonoCapital = objeto.Pabono - interes
                            Else
                                If tipoInteres.Equals("S") Then
                                    abonoCapital = objeto.Pabono - interes
                                End If
                            End If
                        End If

                        ''Validacion cuando el abono capital ya es mayor al saldo que tiene
                        If abonoCapital > objeto.Psaldo Then

                            If tipoInteres.Equals("I") Then
                                abonoCapital = objeto.Psaldo
                                abonoCapital = Math.Round(abonoCapital, 2)
                                ''TOTAL ABONO
                                'celda.Value = Math.Round(objeto.Psaldo, 2)
                            Else
                                If tipoInteres.Equals("F") Then
                                    abonoCapital = objeto.Psaldo
                                    abonoCapital = Math.Round(abonoCapital, 2)
                                    ''TOTAL ABONO
                                    'celda.Value = Math.Round(objeto.Psaldo + (objeto.Pmontoprestamo * interes), 2)

                                Else
                                    If tipoInteres.Equals("S") Then
                                        abonoCapital = objeto.Psaldo
                                        abonoCapital = Math.Round(abonoCapital, 2)
                                        ''TOTAL ABONO
                                        ' celda.Value = Math.Round(objeto.Psaldo + (objeto.Psaldo * interes), 2)
                                    End If
                                End If
                            End If
                        End If

                        Colaborador = objeto.Pcolaborador.PNombre.ToUpper.ToString + " " + objeto.Pcolaborador.PApaterno.ToUpper.ToString + " " + objeto.Pcolaborador.PAmaterno.ToUpper.ToString
                        grdPrestamos.Rows.Add(objeto.Pprestamoid, grdPrestamos.RowCount + 1, False, Colaborador, objeto.Pmontoprestamo, Math.Round(objeto.Psaldo, 0), interes, abonoCapital, objeto.Pabono, (Math.Round(objeto.Psaldo, 0) - abonoCapital), objeto.Pabono, objeto.PcobranzaPrestamos.PnumPago)
                    End If
                    btnGuardar.Enabled = True
                    btnGuardar.Enabled = True

                Next
            End If

            If cmbTipoAbono.Text = "FUERA DE NOMINA" Then
                For Each objeto As Entidades.SolicitudPrestamo In listaConfiguracionPrestamos
                    listaValidarAbonosExtraordinarios = cobranzaBU.ValidarAbonosExtraordinarios(lblIdSemanaNomina.Text, objeto.Pprestamoid, "C")
                    Dim contador As Integer = 0
                    For Each dato As Entidades.CobranzaPrestamos In listaValidarAbonosExtraordinarios
                        contador += 1
                    Next

                    If contador = 0 Then
                        Colaborador = objeto.Pcolaborador.PNombre.ToUpper.ToString + " " + objeto.Pcolaborador.PApaterno.ToUpper.ToString + " " + objeto.Pcolaborador.PAmaterno.ToUpper.ToString
                        grdPrestamos.Rows.Add(objeto.Pprestamoid, grdPrestamos.RowCount + 1, False, Colaborador, objeto.Pmontoprestamo, Math.Round(objeto.Psaldo, 0), 0, 0, 0, Math.Round(objeto.Psaldo, 0), 0)
                    End If
                    btnGuardar.Enabled = True
                    btnGuardar.Enabled = True
                Next
            End If

        Catch ex As Exception
        End Try
    End Sub

    ''LLENAR ABONOS COBRADOS
    Public Sub llenarTablaAbonosExtraordinariosGuardados()
        grdPrestamos.Rows.Clear()
        Try
            Dim listaAbonosExtraordinarios As New List(Of Entidades.SolicitudPrestamo)

            Dim prestamosBU As New Nomina.Negocios.CobranzaPrestamosBU
            Dim idNave As Integer
            Dim Colaborador As String = ""
            idNave = (Int(cmbNave.SelectedValue))

            If cmbTipoAbono.Text = "DENTRO DE NOMINA" Then

                listaAbonosExtraordinarios = prestamosBU.ListaAbonosExtraordinarios(lblIdSemanaNomina.Text, idNave, "B", "")
                For Each row As Entidades.SolicitudPrestamo In listaAbonosExtraordinarios

                    Colaborador = row.Pcolaborador.PNombre + " " + row.Pcolaborador.PApaterno + " " + row.Pcolaborador.PAmaterno
                    grdPrestamos.Rows.Add(row.Pprestamoid, grdPrestamos.RowCount + 1, True, Colaborador, row.Pmontoprestamo, row.PcobranzaPrestamos.PsaldoAnterior, row.Pinteres, row.Pabono, (row.Pabono + row.Pinteres), row.Psaldo, row.Pabono, row.PcobranzaPrestamos.PnumPago)
                Next
            End If

            If cmbTipoAbono.Text = "FUERA DE NOMINA" Then
                listaAbonosExtraordinarios = prestamosBU.ListaAbonosExtraordinarios(lblIdSemanaNomina.Text, idNave, "C", "")
                For Each row As Entidades.SolicitudPrestamo In listaAbonosExtraordinarios
                    Colaborador = row.Pcolaborador.PNombre + " " + row.Pcolaborador.PApaterno + " " + row.Pcolaborador.PAmaterno
                    grdPrestamos.Rows.Add(row.Pprestamoid, grdPrestamos.RowCount + 1, True, Colaborador, row.Pmontoprestamo, row.PcobranzaPrestamos.PsaldoAnterior, row.Pinteres, row.Pabono, (row.Pabono + row.Pinteres), row.Psaldo, row.Pabono, row.PcobranzaPrestamos.PnumPago)
                Next
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbTipoAbono_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoAbono.DropDownClosed
        grdPrestamos.Rows.Clear()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim contadorFilas As Integer = 0
        For Each row As DataGridViewRow In grdPrestamos.Rows
            contadorFilas += 1
        Next

        If contadorFilas > 0 Then
            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = "¿Está seguro que quiere guardar los abonos seleccionados?"

            If mensajeExito.ShowDialog = DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                btnGuardar.Enabled = False
                If chkGuardados.Checked = False Then
                    guardarAbonoExtraordinario()
                ElseIf chkGuardados.Checked = True Then
                    EditarAbonoExtraordinario()
                End If
                grdPrestamos.Rows.Clear()
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Public Sub guardarAbonoExtraordinario()
        Dim objBU = New Nomina.Negocios.CobranzaPrestamosBU
        Dim ObjEnt = New Entidades.CobranzaPrestamos
        Dim ObjEntSol = New Entidades.SolicitudPrestamo
        Dim objEntColaborador = New Entidades.Colaborador
        Dim contador As Integer = 0
        Dim mensaje As String = ""
        Dim abonoCapital As Double = 0
        Dim estaMal As Integer = 0
        Try

            If cmbTipoAbono.Text = "DENTRO DE NOMINA" Then
                For Each row As DataGridViewRow In grdPrestamos.Rows
                    If row.Cells("clmSelect").Value = True Then

                        'SI EL ABONO ES IGUAL A 0 ENTONCES NO DARA INTERES NI ABONO CAPITA.L
                        abonoCapital = row.Cells("clmabono").Value - row.Cells("clmInteres").Value
                        'VALIDADION PARA QUE EL TOTAL DE ABONO NO SOBRE PASE EL SANDO QUE TIENE
                        If (abonoCapital > row.Cells("clmSaldoActual").Value) Then
                            row.Cells("clmabonocapital").Style.BackColor = Color.Salmon
                            row.Cells("clmsaldo").Value = row.Cells("clmSaldoActual").Value
                            estaMal = 1
                        Else
                            row.Cells("clmsaldo").Value = row.Cells("clmSaldoActual").Value - abonoCapital
                            row.Cells("clmabonocapital").Value = abonoCapital
                            row.Cells("clmabonocapital").Style.BackColor = Color.White
                        End If

                        If estaMal = 0 Then
                            ObjEntSol.Pprestamoid = CInt(row.Cells("clmidPrestamo").Value)
                            ObjEnt.PsemanaNominaId = CInt(lblIdSemanaNomina.Text)
                            ObjEnt.PnumPago = CInt(row.Cells("clmNumeroPago").Value)
                            ObjEnt.PsaldoAnterior = row.Cells("clmSaldoActual").Value
                            ObjEntSol.Pinteres = row.Cells("clmInteres").Value
                            ObjEntSol.Psaldo = row.Cells("clmsaldo").Value
                            ObjEntSol.Pfechamodificacion = fechaPago
                            objEntColaborador.PColaboradorid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                            ObjEnt.PTipoAbono = "B"
                            ObjEntSol.Pabono = row.Cells("clmabonocapital").Value
                            ObjEnt.Pcolaborador = objEntColaborador
                            ObjEnt.PSolicitudPrestamo = ObjEntSol
                            objBU.AbonosExtraordinarios(ObjEnt)
                            contador += 1
                        End If
                        estaMal = 0

                    End If
                Next
            End If

            If cmbTipoAbono.Text = "FUERA DE NOMINA" Then
                For Each row As DataGridViewRow In grdPrestamos.Rows
                    If row.Cells("clmSelect").Value = True Then

                        'SI EL ABONO ES IGUAL A 0 ENTONCES NO DARA INTERES NI ABONO CAPITA.L
                        abonoCapital = row.Cells("clmabono").Value - row.Cells("clmInteres").Value
                        'VALIDADION PARA QUE EL TOTAL DE ABONO NO SOBRE PASE EL SANDO QUE TIENE
                        If (abonoCapital > row.Cells("clmSaldoActual").Value) Then
                            row.Cells("clmabonocapital").Style.BackColor = Color.Salmon
                            row.Cells("clmsaldo").Value = row.Cells("clmSaldoActual").Value
                            estaMal = 1
                        Else
                            row.Cells("clmsaldo").Value = row.Cells("clmSaldoActual").Value - abonoCapital
                            row.Cells("clmabonocapital").Value = abonoCapital
                            row.Cells("clmabonocapital").Style.BackColor = Color.White
                        End If

                        If estaMal = 0 Then
                            ObjEntSol.Pprestamoid = CInt(row.Cells("clmidPrestamo").Value)
                            ObjEnt.PsemanaNominaId = CInt(lblIdSemanaNomina.Text)
                            ObjEnt.PnumPago = CInt(row.Cells("clmNumeroPago").Value)
                            ObjEnt.PsaldoAnterior = row.Cells("clmSaldoActual").Value
                            ObjEntSol.Pinteres = 0
                            ObjEntSol.Psaldo = row.Cells("clmsaldo").Value
                            ObjEntSol.Pfechamodificacion = fechaPago
                            objEntColaborador.PColaboradorid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                            ObjEnt.PTipoAbono = "C"
                            If row.Cells("clmsaldo").Value = 0 Then
                                ObjEnt.Pliquidacion = 1
                            Else
                                ObjEnt.Pliquidacion = 0
                            End If
                            ObjEntSol.Pabono = row.Cells("clmabonocapital").Value
                            ObjEnt.Pcolaborador = objEntColaborador
                            ObjEnt.PSolicitudPrestamo = ObjEntSol
                            objBU.AbonosExtraordinarios(ObjEnt)
                            contador += 1
                        End If
                        estaMal = 0
                    End If
                Next
            End If

            If contador > 0 Then
                Dim mensajeExito As New ExitoForm
                'mensajeExito.MdiParent = Me.MdiParent
                mensajeExito.mensaje = "Abonos extraordinarios guardados correctamente." + mensaje.ToString
                mensajeExito.ShowDialog()
                Limpiar()
            Else
                Dim mensajeExito As New AdvertenciaForm
                'mensajeExito.MdiParent = Me.MdiParent
                mensajeExito.mensaje = "Seleccione al menos un préstamo." + mensaje.ToString
                mensajeExito.ShowDialog()
                btnBuscar.Enabled = True
                btnGuardar.Enabled = True
            End If


        Catch ex As Exception
        End Try
    End Sub

    Public Sub EditarAbonoExtraordinario()
        Dim objBU = New Nomina.Negocios.CobranzaPrestamosBU
        Dim ObjEnt = New Entidades.CobranzaPrestamos
        Dim ObjEntSol = New Entidades.SolicitudPrestamo
        Dim objEntColaborador = New Entidades.Colaborador
        Dim contador As Integer = 0
        Dim mensaje As String = ""

        If cmbTipoAbono.Text = "DENTRO DE NOMINA" Then
            For Each row As DataGridViewRow In grdPrestamos.Rows

                ObjEntSol.Pprestamoid = CInt(row.Cells("clmidPrestamo").Value)
                ObjEnt.PsemanaNominaId = CInt(lblIdSemanaNomina.Text)
                ObjEntSol.Pabono = CDbl(row.Cells("clmabonocapital").Value)
                ObjEnt.PsaldoAnterior = CDbl(row.Cells("clmSaldoActual").Value)
                ObjEntSol.Psaldo = CDbl(row.Cells("clmsaldo").Value)
                ObjEnt.PTipoAbono = "B"

                If row.Cells("clmsaldo").Value = 0 Then
                    ObjEnt.Pliquidacion = 1
                Else
                    ObjEnt.Pliquidacion = 0
                End If

                If row.Cells("clmSelect").Value = True Then
                    ObjEnt.PDelete = 0
                Else
                    ObjEnt.PDelete = 1
                End If
                ObjEnt.Pcolaborador = objEntColaborador
                ObjEnt.PSolicitudPrestamo = ObjEntSol
                objBU.EditarAbonosExtraordinarios(ObjEnt)
                contador += 1
            Next
        End If


        If cmbTipoAbono.Text = "FUERA DE NOMINA" Then
            For Each row As DataGridViewRow In grdPrestamos.Rows

                ObjEntSol.Pprestamoid = CInt(row.Cells("clmidPrestamo").Value)
                ObjEnt.PsemanaNominaId = CInt(lblIdSemanaNomina.Text)
                ObjEntSol.Pabono = CDbl(row.Cells("clmabonocapital").Value)
                ObjEnt.PsaldoAnterior = CDbl(row.Cells("clmSaldoActual").Value)
                ObjEntSol.Psaldo = CDbl(row.Cells("clmsaldo").Value)
                ObjEnt.PfechaFinNomina = fechaFinNomina
                ObjEnt.PTipoAbono = "C"

                If row.Cells("clmsaldo").Value = 0 Then
                    ObjEnt.Pliquidacion = 1
                Else
                    ObjEnt.Pliquidacion = 0
                End If

                If row.Cells("clmSelect").Value = True Then
                    ObjEnt.PDelete = 0
                Else
                    ObjEnt.PDelete = 1
                End If
                ObjEnt.Pcolaborador = objEntColaborador
                ObjEnt.PSolicitudPrestamo = ObjEntSol
                objBU.EditarAbonosExtraordinariosFueraNomina(ObjEnt)
                contador += 1
            Next
        End If

        If contador > 0 Then
            Dim mensajeExito As New ExitoForm
            'mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "Abonos extraordinarios guardados correctamente." + mensaje.ToString
            mensajeExito.ShowDialog()
            btnBuscar.Enabled = True
            btnGuardar.Enabled = True
            Limpiar()
        Else
            Dim mensajeExito As New AdvertenciaForm
            'mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "Seleccionar almenos un préstamo." + mensaje.ToString
            mensajeExito.ShowDialog()
            btnBuscar.Enabled = True
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub

    Public Sub Limpiar()
        grdPrestamos.Rows.Clear()
        cmbNave.SelectedIndex = 0
        cmbTipoAbono.SelectedIndex = 0
        lblIdSemanaNomina.Text = ""
        lblEstatusSemanaNomina.Text = ""
        lblEstatusSemanaPrestamos.Text = ""
        lblsemananomina.Text = ""
        lblsemananomina2.Text = ""
        EstatusSemanaNomina.Text = ""
        lblfechamodificacion.Text = ""
        Label2.Text = ""
        lblfechafin.Text = ""
        lblfechainicio.Text = ""
        btnBuscar.Enabled = True
        btnGuardar.Enabled = True
        chkGuardados.Checked = False
        lblPeriodoNomina.Text = "Seleccione primero una nave"
    End Sub

    Private Sub chkGuardados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGuardados.CheckedChanged
        If chkGuardados.Checked = True Or chkGuardados.Checked = False Then
            grdPrestamos.Rows.Clear()
        End If
    End Sub


    Private Sub grdPrestamos_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPrestamos.CellLeave
        Dim TotalAbono As Double = 0
        Dim estaMal As Integer = 0
        Dim abonoCapital As Double = 0
        If e.ColumnIndex = 8 Then
            Try
                For Each row As DataGridViewRow In grdPrestamos.Rows
                    'SI EL ABONO ES IGUAL A 0 ENTONCES NO DARA INTERES NI ABONO CAPITA.L
                    abonoCapital = row.Cells("clmabono").Value - row.Cells("clmInteres").Value
                    'VALIDADION PARA QUE EL TOTAL DE ABONO NO SOBRE PASE EL SANDO QUE TIENE
                    If (abonoCapital > row.Cells("clmSaldoActual").Value) Then
                        row.Cells("clmabonocapital").Style.BackColor = Color.Salmon
                        row.Cells("clmsaldo").Value = row.Cells("clmSaldoActual").Value
                        estaMal = 1
                    Else
                        row.Cells("clmsaldo").Value = row.Cells("clmSaldoActual").Value - abonoCapital
                        row.Cells("clmabonocapital").Value = abonoCapital
                        row.Cells("clmabonocapital").Style.BackColor = Color.White
                    End If
                Next
                'If estaMal = 1 Then
                '    btnGuardar.Enabled = False
                'Else
                '    btnGuardar.Enabled = True
                'End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub grdPrestamos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPrestamos.CellValueChanged
        Dim TotalAbono As Double = 0
        Dim estaMal As Integer = 0
        Dim abonoCapital As Double = 0
        If e.ColumnIndex = 8 Then
            Try
                For Each row As DataGridViewRow In grdPrestamos.Rows
                    'SI EL ABONO ES IGUAL A 0 ENTONCES NO DARA INTERES NI ABONO CAPITA.L
                    abonoCapital = row.Cells("clmabono").Value - row.Cells("clmInteres").Value
                    'VALIDADION PARA QUE EL TOTAL DE ABONO NO SOBRE PASE EL SANDO QUE TIENE
                    If (abonoCapital > row.Cells("clmSaldoActual").Value) Then
                        row.Cells("clmabonocapital").Style.BackColor = Color.Salmon
                        row.Cells("clmsaldo").Value = row.Cells("clmSaldoActual").Value
                        estaMal = 1
                    Else
                        row.Cells("clmsaldo").Value = row.Cells("clmSaldoActual").Value - abonoCapital
                        row.Cells("clmabonocapital").Value = abonoCapital
                        row.Cells("clmabonocapital").Style.BackColor = Color.White
                    End If
                Next
                'If estaMal = 1 Then
                '    btnGuardar.Enabled = False
                'Else
                '    btnGuardar.Enabled = True
                'End If
            Catch ex As Exception
            End Try
        End If
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
            If txt.Text.IndexOf(".") > 0 Then
                clmabono.MaxInputLength = txt.Text.IndexOf(".") + 3
            End If
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

    Private Sub grbParametros_Enter(sender As Object, e As EventArgs) Handles grbParametros.Enter

    End Sub

    Private Sub btnCncelar_Click(sender As Object, e As EventArgs) Handles btnCncelar.Click
        Dim mensajeExito As New ConfirmarForm
        mensajeExito.mensaje = "¿Está seguro que quiere salir sin guardar cambios?"

        If mensajeExito.ShowDialog = DialogResult.OK Then
            Me.Close()
        End If
    End Sub
End Class