Imports System.Windows.Forms

Public Class AltasSolicitudModSalarioForm
    Public editar As Boolean = False
    Public guardado As Boolean = False
    Dim valorDescuento As Double = 0.0
    Dim descuentoDiario As Double = 0.0
    Dim perfilContabilidad As Boolean = False

    Private Sub AltasSolicitudModSalarioForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        configuracionPerfil()

        If editar Then
            cargarDatosSolicitud()

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("LIST_SOLMODSAL", "CAPTDESTIEMPO_MOVSALARIO") Then
                dtpFechaMovimiento.MinDate = CDate("1900-01-01")
                dtpFechaMovimiento.MaxDate = CDate("2099-01-01")
            End If

            txtSueldoNuevo.Visible = False
            lblSueldoNuevo.Visible = True

            lblFechaMovimiento.Visible = False
            dtpFechaMovimiento.Visible = True
        End If
    End Sub

    Private Sub configuracionPerfil()
        Try
            Dim objBU As New Negocios.UtileriasBU
            perfilContabilidad = objBU.validarPerfilContabilidad()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click, lblBuscarColaborador.Click
        abrirPantallaBuscarColaborador()
    End Sub

    Private Sub abrirPantallaBuscarColaborador()
        Dim objForm As New BuscarColaboradorForm
        If Not CheckForm(objForm) Then
            If perfilContabilidad Then
                objForm.externo = 2
            Else
                objForm.externo = 1
            End If
            objForm.ShowDialog()
            lblColaboradorId.Text = objForm.idColaborador
            cargarDatosColaborador()
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

    Private Sub cargarDatosColaborador()
        Dim objMensajeError As New Tools.ErroresForm
        Try
            If CInt(lblColaboradorId.Text) <> 0 Then
                Dim objBU As New Negocios.ModificacionSalarioBU
                Dim modSalario As New Entidades.ModificacionSalario

                modSalario = objBU.obtenerColaboradorModificacionSalario(CInt(lblColaboradorId.Text))
                cargarDatos(modSalario)
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al cargar los datos del colaborador."
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub cargarDatos(ByVal modSalario As Entidades.ModificacionSalario)
        Dim objMensajeError As New Tools.ErroresForm
        Try
            limpiarCampos()

            lblModificacionSalarioId.Text = modSalario.MDID
            lblColaboradorId.Text = modSalario.MDColaboradorId
            lblPatronId.Text = modSalario.MDPatronId
            lblColaborador.Text = modSalario.MDColaborador
            lblDepartamento.Text = modSalario.MDDepartamento
            lblPuesto.Text = modSalario.MDPuesto
            lblFechaIngreso.Text = modSalario.MDFechaIngreso
            lblAntiguedad.Text = modSalario.MDAntiguedad
            lblNSS.Text = modSalario.MDNSS
            lblSueldoAnterior.Text = modSalario.MDSalarioAnterior.ToString("N2")
            lblSueldoNuevo.Text = modSalario.MDSalarioNuevo.ToString("N2")
            lblFactorIntegracion.Text = modSalario.MDFactorIntegracion.ToString("N4")
            If modSalario.MDSalarioNuevo > 0 Then
                txtSueldoNuevo.Text = modSalario.MDSalarioNuevo.ToString("N2")
            Else
                txtSueldoNuevo.Text = ""
            End If

            If modSalario.MDFechaMovimiento <> "" Then
                lblFechaMovimiento.Text = CDate(modSalario.MDFechaMovimiento).ToShortDateString
                dtpFechaMovimiento.Text = CDate(modSalario.MDFechaMovimiento).ToShortDateString
            End If

            If modSalario.MDNumCreditoInfonavit <> "" Then
                lblNumCredito.Text = modSalario.MDNumCreditoInfonavit
                lblTipoDescuento.Text = modSalario.MDTipoDescuento
                lblPorcentajeDescuento.Text = modSalario.MDvalorDescuentoInfonavit.ToString("N2")
                lblValorDescAnterior.Text = modSalario.MDDescuentoInfonavitAnterior.ToString("N2")
                lblValorDescNuevo.Text = modSalario.MDDescuentoInfonavitNuevo.ToString("N2")
                valorDescuento = modSalario.MDvalorDescuentoInfonavit
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al cargar los datos."
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub limpiarCampos()
        lblModificacionSalarioId.Text = "0"
        lblColaboradorId.Text = "0"
        lblPatronId.Text = "0"
        lblColaborador.Text = "--"
        lblDepartamento.Text = "--"
        lblPuesto.Text = "--"
        lblFechaIngreso.Text = "- -/- -/- - - -"
        lblAntiguedad.Text = "--"
        lblNSS.Text = "--"
        lblSueldoAnterior.Text = "--"
        lblSueldoNuevo.Text = ""
        txtSueldoNuevo.Text = "--"
        lblFechaMovimiento.Text = "- -/- -/- - - -"
        ' dtpFechaMovimiento.Text = Now.ToShortDateString

        lblNumCredito.Text = "--"
        lblTipoDescuento.Text = "--"
        lblValorDescAnterior.Text = "--"
        lblValorDescNuevo.Text = "--"
    End Sub

    Private Sub txtSueldoNuevo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSueldoNuevo.KeyPress
        Dim arreglo(2) As String

        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            If txtSueldoNuevo.Text.IndexOf(".") > 0 Then
                arreglo = Split(txtSueldoNuevo.Text, ".")

                If arreglo(1).Length >= 2 Then
                    e.Handled = True
                Else
                    e.Handled = False
                End If
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "." And txtSueldoNuevo.Text.IndexOf(".") > 0 Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtSueldoNuevo_KeyUp(sender As Object, e As KeyEventArgs) Handles txtSueldoNuevo.KeyUp
        Try
            If lblNumCredito.Text <> "" And lblNumCredito.Text <> "--" And lblNumCredito.Text <> "0" Then
                obtenerDescuentoInfonavitNuevo()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub obtenerDescuentoInfonavitNuevo()
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        lblValorDescNuevo.Text = "- -"
        Try
            If txtSueldoNuevo.Text <> "" And txtSueldoNuevo.Text <> "." And lblColaboradorId.Text <> "" And lblColaboradorId.Text <> "0" And lblPatronId.Text <> "" And lblPatronId.Text <> "0" Then
                Dim objUtileria As New CalculoInfonavit
                Dim objBU As New Negocios.ModificacionSalarioBU
                Dim credInfonavit As New Entidades.CreditoInfonavit
                Dim fechaMovimiento As String = objBU.obtenerFechaMovimiento(CInt(lblPatronId.Text))

                If fechaMovimiento <> "" Then
                    credInfonavit = objUtileria.calcularDescuentoPorcentaje(txtSueldoNuevo.Text, valorDescuento, CInt(lblPatronId.Text), fechaMovimiento)
                    If Not credInfonavit Is Nothing Then
                        If credInfonavit.CIDescuentosemanal <> 0 Then
                            lblValorDescNuevo.Text = credInfonavit.CIDescuentosemanal.ToString("N2")
                            descuentoDiario = credInfonavit.CIRetenciondiaria.ToString("N2")
                        End If
                    End If
                Else
                    objMensajeAdv.mensaje = "No se pudo obtener la fecha para realizar el cálculo de Infonavit."
                    objMensajeAdv.ShowDialog()
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al recalcular valor de descuento del crédito Infonavit."
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click, lblGuardar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeExito As New Tools.ExitoForm
        Try
            If validarCampos() Then
                If validarInformacion() Then
                    Dim objBU As New Negocios.ModificacionSalarioBU
                    Dim modSalario As New Entidades.ModificacionSalario
                    Dim resultado As String = String.Empty

                    If editar Then
                        resultado = objBU.editarModificacionSalario(CInt(lblModificacionSalarioId.Text), dtpFechaMovimiento.Value)
                    Else
                        Dim excedente As Double
                        Dim retencionImss As New Entidades.RetencionImss
                        Dim retencionISRSPE As New Entidades.RetencionISR_SPE
                        Dim objCalcImss As New CalculoIMSS
                        Dim objCalcISRSPE As New CalculoISR
                        Dim valorISR As Double = 0
                        Dim motivo As String = String.Empty
                        Dim formMotivo As New MotivoRechazoForm

                        If perfilContabilidad Then
                            If Not CheckForm(formMotivo) Then
                                formMotivo.ShowDialog()

                                If formMotivo.motivo <> "" Then
                                    motivo = formMotivo.motivo
                                Else
                                    objMensajeAdv.mensaje = "Debe ingresar el motivo de la modificación de salario."
                                    objMensajeAdv.ShowDialog()
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            End If
                        End If

                        excedente = obtenerExcedente()
                        If excedente > 0 Then
                            Dim objMensajeConf As New Tools.ConfirmarForm
                            objMensajeConf.mensaje = "El salario diario integrado nuevo sobrepasa con " & excedente.ToString("C2") & " el límite del tabulador para el colaborador indicado. ¿Está seguro de continuar con el proceso?"
                            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Else
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            End If
                        End If


                        Try
                            retencionImss = objCalcImss.calcularRetecionImssIntegrado(CDbl(txtSueldoNuevo.Text), 7)
                            If objCalcImss.msjError <> "" Then
                                objMensajeError.mensaje = objCalcImss.msjError
                                objMensajeError.ShowDialog()
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            End If
                        Catch ex As Exception
                            objMensajeError.mensaje = "Error al calcular retencion IMSS del nuevo salario."
                            objMensajeError.ShowDialog()
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End Try

                        Try
                            Dim salarioDiario As Double
                            salarioDiario = CDbl(txtSueldoNuevo.Text) / (CDbl(lblFactorIntegracion.Text) + 1)
                            retencionISRSPE = objCalcISRSPE.calcularISR_SPE(salarioDiario * 7, CInt(lblColaboradorId.Text), True, True, 0)
                            If objCalcISRSPE.msjError <> "" Then
                                objMensajeAdv.mensaje = objCalcISRSPE.msjError
                                objMensajeAdv.ShowDialog()
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            Else
                                If retencionISRSPE.RISSPEpagado > 0 Then
                                    valorISR = retencionISRSPE.RISSPEpagado * (-1)
                                ElseIf retencionISRSPE.RISISRretenido > 0 Then
                                    valorISR = retencionISRSPE.RISISRretenido
                                End If
                            End If
                        Catch ex As Exception

                        End Try

                        modSalario.MDColaboradorId = CInt(lblColaboradorId.Text)
                        modSalario.MDPatronId = CInt(lblPatronId.Text)
                        modSalario.MDSalarioAnterior = CDbl(lblSueldoAnterior.Text)
                        modSalario.MDSalarioNuevo = CDbl(txtSueldoNuevo.Text)
                        modSalario.MDExcedenteTabulador = excedente
                        modSalario.MDDescuentoImssDiario = retencionImss.RIRetencionDiaria
                        modSalario.MDDescuentoImssSem = retencionImss.RIRetencionImss
                        modSalario.MDDescuentoISRDiario = valorISR / 7
                        modSalario.MDDescuentoISRSem = valorISR
                        modSalario.MDMotivoCreacion = motivo
                        If lblValorDescAnterior.Text <> "--" Then
                            modSalario.MDDescuentoInfonavitAnterior = CDbl(lblValorDescAnterior.Text)
                        End If
                        If lblValorDescNuevo.Text <> "--" Then
                            modSalario.MDDescuentoInfonavitNuevo = CDbl(lblValorDescNuevo.Text)
                        End If
                        modSalario.MDDescuentoInfonavitDiarionuevo = descuentoDiario

                        resultado = objBU.altaModificacionSalario(modSalario)
                    End If

                    If resultado = "EXITO" Then
                        objMensajeExito.mensaje = "Solicitud guardada correctamente"
                        objMensajeExito.ShowDialog()
                        guardado = True
                        Me.Cursor = Cursors.Default
                        Me.Close()
                    Else
                        objMensajeError.mensaje = "Error al guardar la solicitud"
                        objMensajeError.ShowDialog()
                    End If
                End If
            End If

        Catch ex As Exception
            objMensajeError.mensaje = "Error al guardar"
            objMensajeError.ShowDialog()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Function validarCampos() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim esNumero As Double = 0.0

        If lblColaboradorId.Text = "" Or lblColaboradorId.Text = "0" Then
            objMensajeAdv.mensaje = "Favor de seleccionar un colaborador."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        End If

        If txtSueldoNuevo.Visible Then
            If txtSueldoNuevo.Text = "" Then
                objMensajeAdv.mensaje = "Favor de ingresar el Sueldo Diario Nuevo."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            Else
                Try
                    esNumero = CDbl(txtSueldoNuevo.Text)
                    If CDbl(txtSueldoNuevo.Text) <= 0 Then
                        objMensajeAdv.mensaje = "El Sueldo Diario Nuevo debe ser mayor a 0."
                        objMensajeAdv.ShowDialog()
                        Return False
                        Exit Function
                    End If

                    If CDbl(txtSueldoNuevo.Text) < CDbl(lblSueldoAnterior.Text) Then
                        objMensajeAdv.mensaje = "El Sueldo Diario Nuevo no puede ser menor al Sueldo Diaro Anterior."
                        objMensajeAdv.ShowDialog()
                        Return False
                        Exit Function
                    End If
                Catch ex As Exception
                    objMensajeAdv.mensaje = "El Sueldo Diario Nuevo debe ser un valor décimal."
                    objMensajeAdv.ShowDialog()
                    Return False
                    Exit Function
                End Try
            End If
        End If

        'If dtpFechaMovimiento.Visible Then
        '    If dtpFechaMovimiento.Value.ToString = "" Then
        '        objMensajeAdv.mensaje = "Favor de ingresar fecha de movimiento."
        '        objMensajeAdv.ShowDialog()
        '        Return False
        '        Exit Function
        '    Else
        '        If Not IsDate(dtpFechaMovimiento.Value.ToString) Then
        '            objMensajeAdv.mensaje = "Favor de ingresar una fecha valida."
        '            objMensajeAdv.ShowDialog()
        '            Return False
        '            Exit Function
        '        End If
        '    End If
        'End If

        Return True
    End Function

    Private Function validarInformacion() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Try
            Dim objUtileriasBU As New Negocios.UtileriasBU
            If Not objUtileriasBU.existePeriodoNomina(lblPatronId.Text, 0, "") Then
                objMensajeAdv.mensaje = "No hay periodo de nómina fiscal cargado para el movimiento."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            End If

            If Not editar Then
                Dim objBU As New Negocios.ModificacionSalarioBU
                Dim resultado As String = String.Empty

                resultado = objBU.validarSolicitud(CInt(lblColaboradorId.Text))
                If resultado = "" Then
                    objMensajeError.mensaje = "Error al validar movimientos del colaborador."
                    objMensajeError.ShowDialog()
                    Return False
                    Exit Function
                Else
                    If resultado <> "Correcto" Then
                        objMensajeAdv.mensaje = resultado
                        objMensajeAdv.ShowDialog()
                        Return False
                        Exit Function
                    End If
                End If
            End If

            'If dtpFechaMovimiento.Visible Then
            '    If dtpFechaMovimiento.Value.DayOfWeek = DayOfWeek.Saturday Or dtpFechaMovimiento.Value.DayOfWeek = DayOfWeek.Sunday Then
            '        objMensajeAdv.mensaje = "La fecha de movimiento no puede ser Sábado ni Domingo."
            '        objMensajeAdv.ShowDialog()
            '        Return False
            '        Exit Function
            '    End If
            'End If

            Return True
        Catch ex As Exception
            objMensajeError.mensaje = "Error al validar la información."
            objMensajeError.ShowDialog()
            Return False
        End Try
    End Function

    Private Function obtenerExcedente() As Double
        Dim objMensajeError As New Tools.ErroresForm
        Dim excedente As Double = 0.0

        Try
            Dim objBU As New Negocios.ModificacionSalarioBU
            excedente = objBU.obtenerExedenteTabulador(CInt(lblColaboradorId.Text), CDbl(lblSueldoAnterior.Text), CDbl(txtSueldoNuevo.Text))
        Catch ex As Exception
            objMensajeError.mensaje = "Error al validar la información."
            objMensajeError.ShowDialog()
        End Try

        Return excedente
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub cargarDatosSolicitud()
        Dim objMensajeError As New Tools.ErroresForm
        Try
            If CInt(lblModificacionSalarioId.Text) <> 0 Then
                Dim objBU As New Negocios.ModificacionSalarioBU
                Dim modSalario As New Entidades.ModificacionSalario

                modSalario = objBU.consultarSolicitudModificacionSalario(CInt(lblModificacionSalarioId.Text))
                cargarDatos(modSalario)
                dtpFechaMovimiento.MinDate = CDate(modSalario.MDFechaMovimiento)
                obtenerRangoPeriodoNomina()
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al cargar los datos de la solicitud."
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub obtenerRangoPeriodoNomina()
        Dim objMensajeError As New Tools.ErroresForm
        Try
            Dim objBU As New Negocios.ModificacionSalarioBU
            Dim dtPeriodo As New DataTable

            dtPeriodo = objBU.consultarPeriodoNominaSolicitud(CInt(lblModificacionSalarioId.Text))
            If Not dtPeriodo Is Nothing Then
                dtpFechaMovimiento.MinDate = dtPeriodo.Rows(0)("fechaInicial").ToString

                If CInt(dtPeriodo.Rows(0)("diasLaborados").ToString) > 7 Then
                    Dim fecha As Date = dtPeriodo.Rows(0)("fechaInicial").ToString

                    Dim dias As Int16 = 1
                    Do Until dias = 5
                        fecha = fecha.AddDays(1)
                        If fecha.DayOfWeek <> DayOfWeek.Saturday And fecha.DayOfWeek <> DayOfWeek.Sunday Then
                            dias += 1
                        End If
                    Loop
                    dtpFechaMovimiento.MaxDate = fecha
                Else
                    dtpFechaMovimiento.MaxDate = dtPeriodo.Rows(0)("fechaFinal").ToString
                End If
            Else
                objMensajeError.mensaje = "Error iniciar fecha de movimiento."
                objMensajeError.ShowDialog()
                Me.Close()
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error iniciar fecha de movimiento."
            objMensajeError.ShowDialog()
            Me.Close()
        End Try
    End Sub
End Class