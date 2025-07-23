Imports Tools

Public Class SolicitudFinanzasNomina
    Public banderaGuardar As Boolean = False
    Public idNave As Int32 = 0
    Public nave As String = ""
    Public totNominaEfectivo As Double = 0
    Public totNominaDeposito As Double = 0
    Public totDeducciones As Double = 0
    Public totalNominaFiscal As Double = 0
    Public idSemanaN As Int32 = 0
    Public caja As String = ""
    Public idCaja As Int32 = 0
    Public semanaNomina As String = ""

    Dim confNomina As String = ""
    Dim beneficiario As String = ""


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        guardarSolicitudes()
    End Sub

    Public Sub guardarSolicitudes()
        Dim conf As New ConfirmarForm
        Dim objBu As New Negocios.CajasBU
        Dim objBuCon As New Negocios.ConfiguracionNaveNominaBU
        Dim dtSolicitudes As New DataTable
        Dim dtSolicitudCheque As New DataTable
        Dim formaPago As String = ""
        'Dim dtbeneficiario As New DataTable
        Dim idSolicitudEfectivo As Int32 = 0
        Dim idSolicitudCheque As Int32 = 0
        Dim idSolicitudDeducciones As Int32 = 0
        Dim idSolicitudFiscal As Int32 = 0

        If validaCampoFiscal() Then
            conf.mensaje = "¿ Está seguro de querer generar las solicitudes y guardar la nómina ? " + vbNewLine + "No podrá hacer modificaciones" + vbNewLine + " después del guardado."

            If conf.ShowDialog = DialogResult.OK Then
                If confNomina.Equals("A") Then
                    formaPago = "Efectivo"
                    ''solicitud para todo en efectivo
                    dtSolicitudes = objBu.EnviarSolicitudesCajaNomina(idCaja, "EFECTIVO", lblEfectivo.Text, beneficiario, "NOMINA COMPLEMENTO", 13138) ' CAMBIAR POR 'NOMINA COMPLEMENTO' 13138 Y AGREGAR EN LAS CAJS QUE HAGA FALTA
                    idSolicitudEfectivo = dtSolicitudes.Rows(0).Item(0).ToString
                ElseIf confNomina.Equals("B") Then
                    ''solicitud de efectivo depósito
                    dtSolicitudes = objBu.EnviarSolicitudesCajaNomina(idCaja, "EFECTIVO", lblEfectivo.Text, beneficiario, "NOMINA COMPLEMENTO", 13138)
                    idSolicitudCheque = dtSolicitudes.Rows(0).Item(0).ToString
                    ''solicitud de efectivo en cheque 
                    dtSolicitudes = objBu.EnviarSolicitudesCajaNomina(idCaja, "CHEQUE", lblChequeEfectivo.Text, beneficiario, "NOMINA COMPLEMENTO EFECTIVO", 76)
                    idSolicitudEfectivo = dtSolicitudes.Rows(0).Item(0).ToString
                ElseIf confNomina.Equals("C") Then
                    ''Solicitud de cheque depósito
                    dtSolicitudes = objBu.EnviarSolicitudesCajaNomina(idCaja, "CHEQUE", lblCheque.Text, beneficiario, "NOMINA COMPLEMENTO", 76)
                    idSolicitudCheque = dtSolicitudes.Rows(0).Item(0).ToString
                    ''Solicitud de cheque efectivo
                    dtSolicitudes = objBu.EnviarSolicitudesCajaNomina(idCaja, "CHEQUE", lblChequeEfectivo.Text, beneficiario, "NOMINA COMPLEMENTO EFECTIVO", 13138)
                    idSolicitudEfectivo = dtSolicitudes.Rows(0).Item(0).ToString
                ElseIf confNomina.Equals("D") Then
                    ''Solicitud de depósito en cheque 
                    dtSolicitudes = objBu.EnviarSolicitudesCajaNomina(idCaja, "CHEQUE", lblCheque.Text, beneficiario, "NOMINA COMPLEMENTO", 76)
                    idSolicitudCheque = dtSolicitudes.Rows(0).Item(0).ToString
                    ''Solicitud de efectivo en dineros
                    dtSolicitudes = objBu.EnviarSolicitudesCajaNomina(idCaja, "EFECTIVO", lblEfectivo.Text, beneficiario, "NOMINA COMPLEMENTO", 13138)
                    idSolicitudEfectivo = dtSolicitudes.Rows(0).Item(0).ToString

                End If
                ''solicitud deducciones
                dtSolicitudes = objBu.EnviarSolicitudesCajaNomina(idCaja, "EFECTIVO", lblDeducciones.Text.ToString, beneficiario, "NOMINA DEDUCCIONES", 13504) 'solo modifcar por concepto 'NOMINA DEDUCCIONES ' 13504

                idSolicitudDeducciones = dtSolicitudes.Rows(0).Item(0).ToString

                objBuCon.actualizarIdSolicitudesCajaChica(idSemanaN, idSolicitudEfectivo, idSolicitudCheque, idSolicitudDeducciones)
                Dim exito As New ExitoForm
                exito.mensaje = "Se realizaron las solicitudes a finanzas de manera correcta"
                exito.ShowDialog()
                banderaGuardar = True
                Me.Close()
            Else
                banderaGuardar = False
            End If
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        banderaGuardar = False
        Me.Close()
    End Sub

    Private Sub SolicitudFinanzasNomina_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblEfectivo.Text = 0
        lblCheque.Text = 0
        lblDeducciones.Text = 0
        lblTotalNomina.Text = (CDbl(lblEfectivo.Text) + CDbl(lblCheque.Text) + CDbl(lblDeducciones.Text)).ToString("N0")
        recuperarConfiguracionNomina()
    End Sub

    Public Sub recuperarConfiguracionNomina()
        Dim objBu As New Negocios.ConfiguracionNaveNominaBU
        Dim dtConfiguracion As New DataTable
        beneficiario = ""
        dtConfiguracion = objBu.obtenerConfiguracionNomina(idSemanaN)

        confNomina = dtConfiguracion.Rows(0).Item("pnom_TipoSolicitud").ToString
        beneficiario = dtConfiguracion.Rows(0).Item("beneficiario").ToString
        If confNomina <> "" Then
            lblDeducciones.Text = totDeducciones.ToString("N0")
            calcularTotalesSegunConfiguracion()
            lblNave.Text = nave
            'cargarComboRazonSocial()
        Else
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = "No existe una configuración para la solicitud de pago"
            advertencia.ShowDialog()
        End If
    End Sub

    Public Sub calcularTotalesSegunConfiguracion()
        Dim totEfectivo As Double = 0
        Dim fiscal As Double = 0
        Dim totCheque As Double = 0
        Dim totCheque2 As Double = 0

        ''If txtNominaFiscal.Text = "" Then
        ''    fiscal = 0
        ''Else
        ''    fiscal = txtNominaFiscal.Text
        ''    txtNominaFiscal.Text = fiscal.ToString("N0")
        ''End If

        fiscal = totalNominaFiscal
        txtNominaFiscal.Text = fiscal.ToString("N0")
        'lblTotalNomFiscal.Text = fiscal.ToString("N0")

        'If fiscal < 1 Then
        '    btnGuardar.Enabled = False
        'End If

        If confNomina.Equals("A") Then ''Efectivo  
            If fiscal > (totNominaDeposito + totNominaEfectivo) Then
                fiscal = (totNominaDeposito + totNominaEfectivo)
                'txtNominaFiscal.Text = fiscal.ToString("N0")
                lblEfectivo.ForeColor = System.Drawing.Color.Red
            End If

            totEfectivo = ((totNominaDeposito + totNominaEfectivo) - fiscal).ToString("N0")
            lblEfectivoEt.Visible = True
            
            lblEfectivo.Text = totEfectivo.ToString("N0")
            lblCheque.Text = 0
            lblTotalNomina.Text = (fiscal + totEfectivo + CDbl(lblDeducciones.Text)).ToString("N0")

        ElseIf confNomina.Equals("B") Then ''Efectivo y Cheque
            totCheque2 = totNominaEfectivo
            totEfectivo = totNominaDeposito - fiscal
            lblChequeEfectivo.Text = totCheque2.ToString("N0")
            lblEfectivoEt.Visible = True
            lblChequeEfectivo.Visible = True
            lblChequeEfec.Visible = True
            lblEfectivo.Text = totEfectivo.ToString("N0")
            lblTotalNomina.Text = (fiscal + totCheque + totEfectivo + CDbl(lblDeducciones.Text)).ToString("N0")
        End If

        If confNomina.Equals("C") Then ''Cheques ambos 
            totCheque = totNominaDeposito - fiscal
            totEfectivo = totNominaEfectivo.ToString("N0")
            totCheque2 = totEfectivo
            lblChequeEfec.Visible = True
            lblChequeEfectivo.Visible = True
            lblChequeEfectivo.Text = totCheque2.ToString("N0")
            lblCheque.Text = totCheque.ToString("N0")
            lblTotalNomina.Text = (fiscal + totCheque + totCheque2 + CDbl(lblDeducciones.Text)).ToString("N0")

        ElseIf confNomina.Equals("D") Then 'Cheque y Efectivo
            totCheque = totNominaDeposito - fiscal
            totEfectivo = totNominaEfectivo.ToString("N0")
            lblCheque.Text = totCheque
            lblEfectivo.Text = totEfectivo.ToString("N0")
            lblChequeEfec.Visible = False
            lblChequeEfectivo.Visible = False
            lblTotalNomina.Text = (fiscal + totCheque + totEfectivo + CDbl(lblDeducciones.Text)).ToString("N0")

        End If


        lblSaldo.Text = CDbl(lblTotalNomina.Text) - (totEfectivo + totCheque + CDbl(lblDeducciones.Text) + fiscal).ToString("N0")
    End Sub

    Public Function validaCampoFiscal() As Boolean
        Dim advertencia As New AdvertenciaForm
        Dim bandera As Boolean = True
        'If txtNominaFiscal.Text <> "" Then
        '    bandera = True
        'Else
        '    advertencia.mensaje = "Ingresa el monto de la nómina fiscal"
        '    advertencia.ShowDialog()
        '    bandera = False
        'End If

        If idCaja = 0 Then
            advertencia.mensaje = "No cuentas con una caja asignada para realizar la solicitud"
            advertencia.ShowDialog()
            bandera = False
        End If

        'If confNomina.Equals("B") And txtBeneficiario.Text = "" Then
        '    advertencia.mensaje = "Ingresa el nombre del beneficiario"
        '    advertencia.ShowDialog()
        '    bandera = False
        'End If

        'If cmbRazonSocial.SelectedIndex < 1 Then
        '    advertencia.mensaje = "Selecciona una razón social"
        '    advertencia.ShowDialog()
        '    bandera = False
        'End If
        Return bandera


    End Function

    'Public Sub cargarComboRazonSocial()
    '    Dim objBu As New Negocios.ConfiguracionNaveNominaBU
    '    Dim dtCombo As New DataTable

    '    dtCombo = objBu.ComboRazonesSocialesCajaChica(idCaja)
    '    dtCombo.Rows.InsertAt(dtCombo.NewRow, 0)
    '    cmbRazonSocial.DataSource = dtCombo
    '    cmbRazonSocial.DisplayMember = "RazonSocial"
    '    cmbRazonSocial.ValueMember = "IdDocumento"
    'End Sub

    ''Private Sub txtNominaFiscal_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNominaFiscal.KeyDown
    ''    If e.KeyCode = Keys.Enter Then
    ''        If IsNumeric(txtNominaFiscal.Text) Then
    ''            calcularTotalesSegunConfiguracion()
    ''        End If
    ''    End If
    ''End Sub

    ''Private Sub txtNominaFiscal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNominaFiscal.KeyPress
    ''    e.Handled = True
    ''    If Char.IsNumber(e.KeyChar) _
    ''    Or Char.IsControl(e.KeyChar) Then

    ''        e.Handled = False
    ''    End If
    ''End Sub

    ''Private Sub txtNominaFiscal_LostFocus(sender As Object, e As EventArgs) Handles txtNominaFiscal.LostFocus
    ''    If IsNumeric(txtNominaFiscal.Text) Then
    ''        calcularTotalesSegunConfiguracion()
    ''    End If
    ''End Sub
End Class