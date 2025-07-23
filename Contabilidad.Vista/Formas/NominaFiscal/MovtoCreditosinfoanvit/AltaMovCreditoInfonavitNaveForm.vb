Imports System.Windows.Forms
Imports System.Drawing
Imports System.Net

Public Class AltaMovCreditoInfonavitNaveForm
    Dim creditoInfonavit As New Entidades.CreditoInfonavit
    Public editar As Boolean = False
    Public guardado As Boolean = False
    Public consulta As Boolean = False
    Dim salarioBase As Double = 0
    Dim directorio As String = String.Empty

    Private Sub AltaMovCreditoInfonavitNaveForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaRecepcion.MaxDate = Now.ToShortDateString
        llenarComboTipoMovimientos()
        llenarComboTipoDescuentos()
        obtenerBimestreActual()

        If editar Then
            btnBuscar.Visible = False
            lblBuscarColaborador.Visible = False
            cargarDatosMovimiento()
        End If

        If consulta Then
            pnlEditables.Enabled = False
            pnlPie.Enabled = False
        End If
    End Sub

    Private Sub llenarComboTipoMovimientos()
        Dim objBU As New Negocios.CreditoInfonavitBU
        Dim dtMovimientos As New DataTable

        dtMovimientos = objBU.obtenerListaTipoMovimientos()
        If Not dtMovimientos Is Nothing Then
            If dtMovimientos.Rows.Count > 0 Then
                cmbTipoMovimientos.DataSource = dtMovimientos
                cmbTipoMovimientos.ValueMember = "Id"
                cmbTipoMovimientos.DisplayMember = "Movimiento"
            Else
                cmbTipoMovimientos.DataSource = Nothing
            End If
        Else
            cmbTipoMovimientos.DataSource = Nothing
        End If
    End Sub

    Private Sub llenarComboTipoDescuentos()
        Dim objBU As New Negocios.CreditoInfonavitBU
        Dim dtDescuentos As New DataTable

        dtDescuentos = objBU.obtenerListaTipoDescuentos()
        If Not dtDescuentos Is Nothing Then
            If dtDescuentos.Rows.Count > 0 Then
                cmbTipoDescuento.DataSource = dtDescuentos
                cmbTipoDescuento.ValueMember = "Id"
                cmbTipoDescuento.DisplayMember = "Descuento"
            Else
                cmbTipoDescuento.DataSource = Nothing
            End If
        Else
            cmbTipoDescuento.DataSource = Nothing
        End If
    End Sub

    Private Sub obtenerBimestreActual()
        Dim objMensajeError As New Tools.ErroresForm

        Try
            Dim objBU As New Negocios.CreditoInfonavitBU
            Dim fecha As New Date

            fecha = objBU.obtenerBimestreActual()
            dtpFechaRecepcion.MinDate = fecha
        Catch ex As Exception
            objMensajeError.mensaje = "Error al obtener fecha inicial del bimestre actual"
            objMensajeError.ShowDialog()
            Me.Close()
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click, lblBuscarColaborador.Click
        abrirPantallaBuscarColaborador()
    End Sub

    Private Sub abrirPantallaBuscarColaborador()
        Dim objForm As New BuscarColaboradorForm
        If Not CheckForm(objForm) Then
            objForm.externo = 1
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

    Private Sub cargarDatos(ByVal credInfonavit As Entidades.CreditoInfonavit)
        Dim objMensajeError As New Tools.ErroresForm
        Try
            limpiarCampos()

            lblCreditoId.Text = credInfonavit.CICreditoInfonavitId
            lblColaboradorId.Text = credInfonavit.CIColaboradorid
            lblPatronId.Text = credInfonavit.CIPatronId
            lblColaborador.Text = credInfonavit.CIColaborador
            lblEmpresa.Text = credInfonavit.CIEmpresa
            lblNSS.Text = credInfonavit.CINss
            lblRFC.Text = credInfonavit.CIRfc
            salarioBase = credInfonavit.CISalarioBase.ToString("N2")

            If credInfonavit.CIMovimientoinfonavitid <> 0 Then
                cmbTipoMovimientos.SelectedValue = credInfonavit.CIMovimientoinfonavitid
            End If
            If lblCreditoId.Text <> "0" Then
                dtpFechaRecepcion.MinDate = credInfonavit.CIFechaInicioBimestre
                dtpFechaRecepcion.MaxDate = credInfonavit.CIFechaFinBimestre
            End If
            If credInfonavit.CIFecharecepcion <> "" Then
                dtpFechaRecepcion.Text = CDate(credInfonavit.CIFecharecepcion).ToShortDateString
            End If

            If credInfonavit.CIFechamovimiento <> "" Then
                lblFechaMovimiento.Text = CDate(credInfonavit.CIFechamovimiento).ToShortDateString
            End If

            If credInfonavit.CINumerocredito <> "" Then
                txtNumCredito.Text = credInfonavit.CINumerocredito
            End If

            If credInfonavit.CITipodescuentoid <> 0 Then
                cmbTipoDescuento.SelectedValue = credInfonavit.CITipodescuentoid
            End If

            If credInfonavit.CIValordescuento <> 0 Then
                txtValorDescuento.Text = credInfonavit.CIValordescuento.ToString("N2")
            End If

            rdbAplicaDisminucionSI.Checked = credInfonavit.CIAplicatabladisminucion
            rdbAplicaDisminucionNo.Checked = Not (credInfonavit.CIAplicatabladisminucion)

            If credInfonavit.CIRutaarchivoretencion <> "" Then
                opfArchivoRetencion.FileName = credInfonavit.CIRutaarchivoretencion
                pnlArchivoCargado.Visible = True
            End If
            creditoInfonavit = credInfonavit

            habilitarPanelEditables(True)
        Catch ex As Exception
            objMensajeError.mensaje = "Error al cargar los datos."
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub limpiarCampos()
        lblCreditoId.Text = "0"
        lblColaboradorId.Text = "0"
        lblPatronId.Text = "0"
        lblColaborador.Text = "--"
        lblEmpresa.Text = "--"
        lblNSS.Text = "--"
        cmbTipoMovimientos.SelectedIndex = 0
        dtpFechaRecepcion.Text = Now.ToShortDateString
        lblFechaMovimiento.Text = "- -/- -/- - - -"
        txtNumCredito.Text = String.Empty
        cmbTipoDescuento.SelectedIndex = 0
        txtValorDescuento.Text = String.Empty
        rdbAplicaDisminucionNo.Checked = True
        pnlArchivoCargado.Visible = False
        opfArchivoRetencion.FileName = String.Empty
        habilitarPanelEditables(False)
    End Sub

    Private Sub habilitarPanelEditables(ByVal opcion As Boolean)
        pnlEditables.Enabled = opcion
    End Sub

    Private Sub cargarDatosColaborador()
        Dim objMensajeError As New Tools.ErroresForm
        Try
            If CInt(lblColaboradorId.Text) <> 0 Then
                Dim objBU As New Negocios.CreditoInfonavitBU
                Dim credInfonavit As New Entidades.CreditoInfonavit

                credInfonavit = objBU.obtenerColaboradorCreditoInfonavit(CInt(lblColaboradorId.Text))
                cargarDatos(credInfonavit)
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al cargar los datos del colaborador."
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub cmbTipoMovimientos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoMovimientos.SelectedIndexChanged
        obtenerFechaMovimiento()
        If cmbTipoMovimientos.SelectedValue.ToString <> "2" Then
            txtNumCredito.Enabled = True
            cmbTipoDescuento.Enabled = True
            txtValorDescuento.Enabled = True
            btnGuardar.Enabled = True

            realizarCalculo()
        Else
            txtNumCredito.Text = ""
            cmbTipoDescuento.SelectedValue = 0
            txtValorDescuento.Text = ""

            consultarCreditoColaborador()

            txtNumCredito.Enabled = False
            cmbTipoDescuento.Enabled = False
            txtValorDescuento.Enabled = False
        End If
    End Sub

    Private Sub obtenerFechaMovimiento()
        Try
            lblFechaMovimiento.Text = "- -/- -/- - - -"
            Select Case cmbTipoMovimientos.SelectedValue.ToString
                Case "0"
                Case "1"
                    lblFechaMovimiento.Text = CDate(dtpFechaRecepcion.Text.ToString).AddDays(1)
                Case "2", "3"
                    lblFechaMovimiento.Text = CDate(dtpFechaRecepcion.Text.ToString)
                Case Else
                    obtenerFechaBimestreFecha()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Public Sub obtenerFechaBimestre()
        Dim objMensajeError As New Tools.ErroresForm

        Try
            Dim objBU As New Negocios.CreditoInfonavitBU
            Dim fecha As New Date

            fecha = objBU.obtenerFechaBimestre()
            lblFechaMovimiento.Text = fecha.ToShortDateString
        Catch ex As Exception
            objMensajeError.mensaje = "Error al obtener fecha del movimiento"
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Public Sub obtenerFechaBimestreFecha()
        Dim objMensajeError As New Tools.ErroresForm

        Try
            Dim objBU As New Negocios.CreditoInfonavitBU
            Dim fecha As New Date

            fecha = objBU.obtenerFechaBimestreFecha(CDate(dtpFechaRecepcion.Text.ToString))
            lblFechaMovimiento.Text = fecha.ToShortDateString
        Catch ex As Exception
            objMensajeError.mensaje = "Error al obtener fecha del movimiento"
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub dtpFechaRecepcion_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaRecepcion.ValueChanged
        obtenerFechaMovimiento()
        realizarCalculo()
    End Sub

    Private Sub txtNumCredito_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumCredito.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cmbTipoDescuento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoDescuento.SelectedIndexChanged
        realizarCalculo()
    End Sub

    Private Sub txtValorDescuento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValorDescuento.KeyPress
        Dim arreglo(2) As String

        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            If txtValorDescuento.Text.IndexOf(".") > 0 Then
                arreglo = Split(txtValorDescuento.Text, ".")

                If arreglo(1).Length >= 4 Then
                    e.Handled = True
                Else
                    e.Handled = False
                End If
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "." And txtValorDescuento.Text.IndexOf(".") > 0 Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtValorDescuento_KeyUp(sender As Object, e As KeyEventArgs) Handles txtValorDescuento.KeyUp
        realizarCalculo()
    End Sub

    Private Sub realizarCalculo()
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        creditoInfonavit = New Entidades.CreditoInfonavit

        If txtValorDescuento.Text <> "" And txtValorDescuento.Text <> "0" And txtValorDescuento.Text <> "." And lblPatronId.Text <> "0" And lblFechaMovimiento.Text <> "- -/- -/- - - -" Then
            If IsNumeric(txtValorDescuento.Text) Then
                If CDbl(txtValorDescuento.Text) > 0 Then
                    If cmbTipoMovimientos.SelectedValue.ToString <> "2" Then
                        Select Case cmbTipoDescuento.SelectedValue.ToString
                            Case "0"
                            Case "1" 'PORCENTAJE
                                realizarCalculoPorcentaje()
                            Case "2" 'CUOTAFIJA
                                realizarCalculoCuotaFija()
                            Case "3" 'VECES SALARIO MÍNIMO
                                realizarCalculoVecesSM()
                        End Select
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub realizarCalculoPorcentaje()
        Dim objMensajeError As New Tools.ErroresForm
        Try
            'Dim credInfonavit As New Entidades.CreditoInfonavit
            Dim objCalcInfonavit As New CalculoInfonavit
            Dim msjError As String = String.Empty

            If salarioBase <> 0 And txtValorDescuento.Text <> "0" And txtValorDescuento.Text <> "" Then
                Dim porcentajeDescuento As Double = CDbl(txtValorDescuento.Text)

                creditoInfonavit = objCalcInfonavit.calcularDescuentoPorcentaje(salarioBase, porcentajeDescuento, CInt(lblPatronId.Text), lblFechaMovimiento.Text)
                If objCalcInfonavit.msjError <> "" Then
                    objMensajeError.mensaje = objCalcInfonavit.msjError
                    objMensajeError.ShowDialog()
                End If
            End If

        Catch ex As Exception
            objMensajeError.mensaje = "Error al realizar el calculo"
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub realizarCalculoVecesSM()
        Dim objMensajeError As New Tools.ErroresForm
        Try
            'Dim credInfonavit As New Entidades.CreditoInfonavit
            Dim objCalcInfonavit As New CalculoInfonavit
            Dim msjError As String = String.Empty

            Dim factorDescuento As Double = CDbl(txtValorDescuento.Text)
            creditoInfonavit = objCalcInfonavit.calcularDescuentoVecesSM(factorDescuento, CInt(lblPatronId.Text), lblFechaMovimiento.Text)
            If objCalcInfonavit.msjError <> "" Then
                objMensajeError.mensaje = objCalcInfonavit.msjError
                objMensajeError.ShowDialog()
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al realizar el calculo"
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub realizarCalculoCuotaFija()
        Dim objMensajeError As New Tools.ErroresForm
        Try
            'Dim credInfonavit As New Entidades.CreditoInfonavit
            Dim objCalcInfonavit As New CalculoInfonavit
            Dim msjError As String = String.Empty

            Dim valorDescuento As Double = CDbl(txtValorDescuento.Text)
            creditoInfonavit = objCalcInfonavit.calcularDescuentoCoutaFija(valorDescuento, CInt(lblPatronId.Text), lblFechaMovimiento.Text)
            If objCalcInfonavit.msjError <> "" Then
                objMensajeError.mensaje = objCalcInfonavit.msjError
                objMensajeError.ShowDialog()
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al realizar el calculo"
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub btnPDFAcuse_Click(sender As Object, e As EventArgs) Handles btnPDFAcuse.Click
        opfArchivoRetencion.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        opfArchivoRetencion.Filter = "PDF|*.pdf;"
        opfArchivoRetencion.FilterIndex = 3
        opfArchivoRetencion.ShowDialog()
        If opfArchivoRetencion.FileName <> "" Then
            pnlArchivoCargado.Visible = True
        Else
            pnlArchivoCargado.Visible = False
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeConf As New Tools.ConfirmarForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim objFTP As New Tools.TransferenciaFTP

        Try
            If validarCampos() Then
                If validacionesMovimiento() Then
                    If validarInformacion() Then
                        Dim objBU As New Negocios.CreditoInfonavitBU
                        Dim resultado As String = String.Empty

                        objMensajeConf.mensaje = "¿Está seguro de guardar la información?"
                        If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                            If subirArchivo(opfArchivoRetencion.FileName) Then
                                creditoInfonavit.CICreditoInfonavitId = CInt(lblCreditoId.Text)
                                creditoInfonavit.CIColaboradorid = CInt(lblColaboradorId.Text)
                                creditoInfonavit.CIPatronId = CInt(lblPatronId.Text)
                                creditoInfonavit.CINumerocredito = txtNumCredito.Text
                                creditoInfonavit.CIMovimientoinfonavitid = CInt(cmbTipoMovimientos.SelectedValue.ToString)
                                creditoInfonavit.CITipodescuentoid = CInt(cmbTipoDescuento.SelectedValue.ToString)
                                creditoInfonavit.CIFecharecepcion = CDate(dtpFechaRecepcion.Text).ToShortDateString
                                creditoInfonavit.CIFechamovimiento = CDate(lblFechaMovimiento.Text).ToShortDateString
                                creditoInfonavit.CIValordescuento = CDbl(txtValorDescuento.Text)
                                creditoInfonavit.CIAplicatabladisminucion = rdbAplicaDisminucionSI.Checked
                                creditoInfonavit.CIRutaarchivoretencion = directorio & "/" & IO.Path.GetFileName(opfArchivoRetencion.FileName)

                                If Not editar Then
                                    resultado = objBU.altaMovimientoCreditoInfonavit(creditoInfonavit, directorio, IO.Path.GetFileName(opfArchivoRetencion.FileName))
                                Else
                                    resultado = objBU.editarMovimientoCreditoInfonavit(creditoInfonavit, directorio, IO.Path.GetFileName(opfArchivoRetencion.FileName))
                                End If

                                If resultado = "EXITO" Then
                                    objMensajeExito.mensaje = "Movimiento de Crédito Infonavit guardado correctamente"
                                    objMensajeExito.ShowDialog()
                                    guardado = True
                                    Me.Cursor = Cursors.Default
                                    Me.Close()
                                Else
                                    objMensajeError.mensaje = "Error al guardar el Movimiento de Crédito Infonavit"
                                    objMensajeError.ShowDialog()
                                End If
                            Else
                                objMensajeError.mensaje = "Error subir el archivo de Retención de Descuentos."
                                objMensajeError.ShowDialog()
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al guardar el movimiento de Crédito Infonavit"
            objMensajeError.ShowDialog()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Function validacionesMovimiento() As Boolean
        Dim objBU As New Negocios.CreditoInfonavitBU
        Dim resultado As Boolean = True
        Dim dtValidaciones As New DataTable
        Dim colaboradorId As Integer = lblColaboradorId.Text.Trim
        Dim patronId As Integer = lblPatronId.Text.Trim
        Dim numeroCredito As String = txtNumCredito.Text.Trim
        Dim tipoMovimiento As Integer = cmbTipoMovimientos.SelectedValue.ToString
        Dim valorDescuento As Double = txtValorDescuento.Text.Trim
        Dim tipodescuentoId As Integer = cmbTipoDescuento.SelectedValue.ToString

        dtValidaciones = objBU.consultarValidacionesCredito(colaboradorId, patronId, numeroCredito, tipoMovimiento, valorDescuento, tipodescuentoId)
        If dtValidaciones.Rows.Count > 0 Then
            Tools.Utilerias.show_message(Tools.Utilerias.TipoMensaje.Advertencia, dtValidaciones.Rows(0).Item("mensaje").ToString)
            resultado = False
        End If

        Return resultado
    End Function
    Private Function validarCampos() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If lblColaboradorId.Text = "0" Or lblColaboradorId.Text = "" Then
            lblEtqColaborador.ForeColor = Color.Red
            objMensajeAdv.mensaje = "Favor de seleccionar un colaborador."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        Else
            lblEtqColaborador.ForeColor = Color.Black
        End If

        If cmbTipoMovimientos.SelectedIndex = 0 Then
            lblEtqMovimiento.ForeColor = Color.Red
            objMensajeAdv.mensaje = "Favor de seleccionar el movimiento a realizar."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        Else
            lblEtqMovimiento.ForeColor = Color.Black
        End If

        If Not IsDate(dtpFechaRecepcion.Text) Then
            lblEtqFechaRecepcion.ForeColor = Color.Red
            objMensajeAdv.mensaje = "Favor de ingresar fecha recepción válida."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        Else
            lblEtqFechaRecepcion.ForeColor = Color.Black
        End If

        If txtNumCredito.Text = "" Then
            lblEtqNumCredito.ForeColor = Color.Red
            objMensajeAdv.mensaje = "Favor de ingresar Número de Crédito."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        Else
            If Not IsNumeric(txtNumCredito.Text) Then
                lblEtqNumCredito.ForeColor = Color.Red
                objMensajeAdv.mensaje = "Favor de ingresar Número de Crédito válido."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            Else
                If CLng(txtNumCredito.Text) = 0 Then
                    lblEtqNumCredito.ForeColor = Color.Red
                    objMensajeAdv.mensaje = "Favor de ingresar Número de Crédito válido."
                    objMensajeAdv.ShowDialog()
                    Return False
                    Exit Function
                Else
                    If txtNumCredito.Text.Length < 10 Then
                        lblEtqNumCredito.ForeColor = Color.Red
                        objMensajeAdv.mensaje = "El Número de Crédito debe tener 10 dígitos."
                        objMensajeAdv.ShowDialog()
                        Return False
                        Exit Function
                    Else
                        lblEtqNumCredito.ForeColor = Color.Black
                    End If
                End If
            End If
        End If

        If cmbTipoDescuento.SelectedIndex = 0 Then
            lblEtqTipoDescuento.ForeColor = Color.Red
            objMensajeAdv.mensaje = "Favor de seleccionar el tipo de descuento."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        Else
            lblEtqTipoDescuento.ForeColor = Color.Black
        End If

        If txtValorDescuento.Text = "" Then
            lblEtqValorDescuento.ForeColor = Color.Red
            objMensajeAdv.mensaje = "Favor de ingresar Valor de Descuento."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        Else
            If Not IsNumeric(txtValorDescuento.Text) Then
                lblEtqValorDescuento.ForeColor = Color.Red
                objMensajeAdv.mensaje = "Favor de ingresar Valor de Descuento válido."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            Else
                If CDbl(txtValorDescuento.Text) = 0 Then
                    lblEtqValorDescuento.ForeColor = Color.Red
                    objMensajeAdv.mensaje = "Favor de ingresar Valor de Descuento válido."
                    objMensajeAdv.ShowDialog()
                    Return False
                    Exit Function
                Else
                    lblEtqValorDescuento.ForeColor = Color.Black
                End If
            End If
        End If

        If opfArchivoRetencion.FileName = "" And Not editar Then
            lblEtqArchivoRetDescuentos.ForeColor = Color.Red
            objMensajeAdv.mensaje = "Favor de cargar el archivo de Retención de Descuentos."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        ElseIf opfArchivoRetencion.FileName <> "" Then
            If System.IO.Path.GetExtension(opfArchivoRetencion.FileName).ToUpper <> ".PDF" Then
                objMensajeAdv.mensaje = "El archivo seleccionado no es un PDF."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            Else
                lblEtqArchivoRetDescuentos.ForeColor = Color.Black
            End If
        End If

        Return True
    End Function

    Private Function validarInformacion() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Try
            Dim objUtileriasBU As New Negocios.UtileriasBU
            If Not objUtileriasBU.existePeriodoNomina(lblPatronId.Text, 1, lblFechaMovimiento.Text) Then
                objMensajeAdv.mensaje = "No hay periodo de nómina fiscal cargado para el movimiento."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            End If

            Dim objBU As New Negocios.CreditoInfonavitBU
            Dim resultado As String = String.Empty

            If cmbTipoMovimientos.SelectedValue.ToString <> "2" And creditoInfonavit.CIDescuentosemanal = 0 Then
                objMensajeAdv.mensaje = "El cálculo del descuento semanal da como resultado 0, favor de revisar los datos."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            End If

            resultado = objBU.validarColaboradorMovimiento(CInt(lblColaboradorId.Text), creditoInfonavit.CIDescuentosemanal, CInt(lblCreditoId.Text))
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

            If editar Then
                If Not validarEstatus(3, CInt(lblCreditoId.Text)) Then
                    objMensajeError.mensaje = "El movimiento de Crédito infonavit ya se encuentra en proceso. Favor de esperar a que Contabilidad termine el proceso."
                    objMensajeError.ShowDialog()
                    Return False
                    Exit Function
                End If
            End If

            Return True
        Catch ex As Exception
            objMensajeError.mensaje = "Error al validar la información."
            objMensajeError.ShowDialog()
            Return False
        End Try
    End Function

    Private Function validarEstatus(ByVal opcEstatus As Int16, ByVal idCredito As Integer) As Boolean
        Dim objBU As New Negocios.CreditoInfonavitBU
        Dim resultado As String = String.Empty

        resultado = objBU.validarEstatus(idCredito, opcEstatus)
        If resultado <> "CORRECTO" Then
            Return False
            Exit Function
        Else
            Return True
        End If
    End Function

    Private Function subirArchivo(ByVal ruta As String) As Boolean
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
            Dim rutaArchivo As String = String.Empty

            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
            directorio = rutaAcuses & lblColaboradorId.Text

            If ruta <> "" Then
                objFTP.EnviarArchivo(directorio, ruta)
                rutaArchivo = objFTP.obtenerURL & "/" & directorio & "/" & IO.Path.GetFileName(ruta)

                If objFTP.FtpExisteArchivo(rutaArchivo) Then
                    Return True
                Else
                    Return False
                End If
            Else
                If editar Then
                    Return True
                Else
                    Return False
                End If
            End If
        Catch
            Return False
        End Try
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub cargarDatosMovimiento()
        Dim objMensajeError As New Tools.ErroresForm
        Try
            If CInt(lblCreditoId.Text) <> 0 Then
                Dim objBU As New Negocios.CreditoInfonavitBU
                Dim credInfonavit As New Entidades.CreditoInfonavit

                credInfonavit = objBU.consultarMovimientoCreditoInfonavit(CInt(lblCreditoId.Text))
                cargarDatos(credInfonavit)
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al cargar los datos del movimiento de crédito infonavit."
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub consultarCreditoColaborador()
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Try
            If CInt(lblColaboradorId.Text) <> 0 Then
                Dim objBU As New Negocios.CreditoInfonavitBU
                Dim dtCredInfonavit As New DataTable

                dtCredInfonavit = objBU.consultarCreditoColaborador(CInt(lblColaboradorId.Text))
                If Not dtCredInfonavit Is Nothing Then
                    If dtCredInfonavit.Rows.Count > 0 Then
                        If CBool(dtCredInfonavit.Rows(0)("infonavit").ToString) Then
                            txtNumCredito.Text = dtCredInfonavit.Rows(0)("numeroCreditoInfonavit").ToString
                            cmbTipoDescuento.SelectedValue = dtCredInfonavit.Rows(0)("tipodescuentoinfonavitid").ToString
                            txtValorDescuento.Text = dtCredInfonavit.Rows(0)("valordescuentoinfonavit").ToString
                        Else
                            objMensajeAdv.mensaje = "El colaborador no tiene crédito infonavit."
                            objMensajeAdv.ShowDialog()
                            btnGuardar.Enabled = False
                        End If
                    Else
                        objMensajeError.mensaje = "No hay datos de crédito infonavit para el colaborador seleccionado."
                        objMensajeError.ShowDialog()
                    End If
                Else
                    objMensajeError.mensaje = "No hay datos de crédito infonavit para el colaborador seleccionado."
                    objMensajeError.ShowDialog()
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al cargar los datos del crédito infonavit del colaborador."
            objMensajeError.ShowDialog()
        End Try
    End Sub
End Class