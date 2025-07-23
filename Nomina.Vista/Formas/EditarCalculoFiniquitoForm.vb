Imports Nomina.Negocios
Imports System.Net
Imports Tools

Public Class EditarCalculoFiniquitoForm
    Dim SolicitudFiniquitoColaborador As Int32
    Dim SolFiniquitoExterno As Entidades.Finiquitos
    Public Property PSolFiniquitosExterno As Entidades.Finiquitos
        Get
            Return SolFiniquitoExterno
        End Get
        Set(ByVal value As Entidades.Finiquitos)
            SolFiniquitoExterno = value
        End Set
    End Property

    Public Property PSolicitudFiniquitoColaborador As Int32
        Get
            Return SolicitudFiniquitoColaborador
        End Get
        Set(ByVal value As Int32)
            SolicitudFiniquitoColaborador = value
        End Set
    End Property
    Private Sub EditarCalculoFiniquitoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtMesestotal.Text = "12"
        txtMEsesVacaciones.Text = "12"
        If SolFiniquitoExterno.PEstado = "D" Or SolFiniquitoExterno.PEstado = "E" Then
            btnAutorizar.Visible = False
            btnRechazar.Visible = False
            lblAutorizar.Visible = False
            lblRechazar.Visible = False
        End If

        Me.MaximizeBox = False

        Dim ObjBU As New FiniquitosBU
        Dim ObjColaboradores As New ColaboradoresBU
        Dim ObjColaboradorLaboral As New ColaboradorLaboralBU
        Dim ColaboradorLaboral As Entidades.ColaboradorLaboral
        Dim Colaborador As New Entidades.Colaborador
        Dim objColaboradorReal As New ColaboradorRealBU
        Dim ColaboradorReal As Entidades.ColaboradorReal
        Dim objColaboradorNomina As New ColaboradorNominaBU
        Dim ColaboradorNomina As Entidades.ColaboradorNomina
        ColaboradorReal = objColaboradorReal.BuscarColaboradorReal(SolicitudFiniquitoColaborador)
        Colaborador = ObjColaboradores.BuscarColaboradorGeneral(SolicitudFiniquitoColaborador)
        ColaboradorLaboral = ObjColaboradorLaboral.buscarInformacionLaboral(SolicitudFiniquitoColaborador)
        ColaboradorNomina = ObjBU.DatosGeneralesColaborador(SolicitudFiniquitoColaborador)


        Dim Finiquito As New Entidades.Finiquitos

        Finiquito = ObjBU.SolicitudFiniquito(SolFiniquitoExterno.PFiniquito)
        DPFecha.Value = Finiquito.PFechaBaja
        lblFechaEntregaDato.Text = Finiquito.PFechaSolicitud
        cmbMotivoFiniquito = Controles.ComboMotivoFiniquitos(cmbMotivoFiniquito, ColaboradorLaboral.PNaveId.PNaveId)
        cmbMotivoFiniquito.SelectedValue = Finiquito.PMotivoFiniquitoId.PMotivoFiniquitoId
        lblNomTrabajadorDato.Text = Colaborador.PNombre + " " + Colaborador.PApaterno + " " + Colaborador.PAmaterno
        lblDepartamentoDato.Text = ColaboradorLaboral.PDepartamentoId.DNombre
        lblPuestoDato.Text = ColaboradorLaboral.PPuestoId.PNombre
        lblFechaIngresoDato.Text = ColaboradorReal.PFecha
        lblAnti.Text = Finiquito.PAntiguedadAnios.ToString + " Años " + Finiquito.PAntiguedadMeses.ToString + " Meses " + Finiquito.PAntiguedadDias.ToString + " Dias"
        txtTotalAguinaldo.Text = Finiquito.PTotalAguinaldo
        txtMesesTrabajados.Text = Finiquito.PMesesAguinaldo
        txtDiasCorrespondenSegunMeses.Text = Finiquito.PDiasAguinaldo
        txtDiasvacacionesCorresponden.Text = Finiquito.PMesesVacaciones
        txtDiasTrabajadorCorresponde.Text = Finiquito.PDiasVacaciones
        txtDiasVacCorres.Text = Finiquito.PDiasSegunAntiguedad
        txtTotalVacaciones.Text = Finiquito.PTotalVacaciones
        txtPrimaVacacional.Text = Finiquito.PPrimaVacacional
        txtJustificacion.Text = Finiquito.PJustificacion.ToUpper
        txtTotalVacTotal.Text = (CDbl(txtPrimaVacacional.Text)) + (CDbl(txtTotalVacaciones.Text))
        LblSueldoCal.Text = FormatNumber(Finiquito.PSalario, 2)
        lblSueldoDiarioCal.Text = FormatNumber(Finiquito.PSalarioDiario, 2)
        txtLiquidacion.Text = FormatNumber(Finiquito.PTotalFiniquito, 2)
        txtAhorrro.Text = FormatNumber(Finiquito.PAhorro, 2)
        txtUtilidades.Text = FormatNumber(Finiquito.PUtilidades, 2)
        txtGratificacion.Text = FormatNumber(Finiquito.PGratificacion, 2)
        txtSubtotal.Text = FormatNumber(Finiquito.PSubtotal, 2)
        txtPrestamo.Text = FormatNumber(Finiquito.PPrestamo, 2)
        txtTotalEntregar.Text = FormatNumber(Finiquito.PTotalEntregar, 2)
        txtSemana1.Text = FormatNumber(Finiquito.PSemana1, 2)
        txtSemana2.Text = FormatNumber(Finiquito.PSemana2, 2)
        txtSemana3.Text = FormatNumber(Finiquito.PSemana3, 2)
        txtSemana4.Text = FormatNumber(Finiquito.PSemana4, 2)
        txtTotalAguinaldo.Text = FormatNumber(txtTotalAguinaldo.Text, 2)
        txtPrimaVacacional.Text = FormatNumber(txtPrimaVacacional.Text, 2)
        txtTotalVacTotal.Text = FormatNumber(txtTotalVacTotal.Text, 2)
        txtTotalVacaciones.Text = FormatNumber(txtTotalVacaciones.Text, 2)
        'If Finiquito.PSueldoDiasTrabajados > 0 Then
        '    txtDiasTrabajados.Text = Finiquito.PSueldoDiasTrabajados
        'Else
        '    txtDiasTrabajados.Text = 0
        'End If

        If ColaboradorNomina.PNss <> "" Then
            lblEstatusSeguroDato.Text = "SI"
        Else
            lblEstatusSeguroDato.Text = "NO"
        End If
        If ColaboradorReal.PTipoPago = "DESTAJO" Then
            lblTipoPagoDato.Text = ColaboradorReal.PTipoPago
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

        If ColaboradorReal.PTipoPago = "SALARIO" Then
            lblTipoPagoDato.Text = ColaboradorReal.PTipoPago
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

        Dim EntidadArchivos As New Entidades.ColaboradorExpediente
        Dim ObjArchivosBU As New Negocios.EnviodeArchivosBU
        EntidadArchivos = ObjArchivosBU.CredencialColaborador(SolicitudFiniquitoColaborador)
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


        Dim ConfiguracionNave As New Entidades.ConfiguracionNaveNomina
        Dim objConfNaves As New ConfiguracionNaveNominaBU



        ConfiguracionNave = objConfNaves.buscarConfiguracionNave(ColaboradorLaboral.PNaveId.PNaveId)
        txtDiasCorresponden.Text = ConfiguracionNave.PConDiasAguinaldo






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

    Private Sub txtSemana4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSemana4.KeyPress
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

    Private Sub txtSemana3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSemana3.KeyPress
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

    Private Sub txtSemana2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSemana2.KeyPress
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

    Private Sub txtSemana1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSemana1.KeyPress
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

    Private Sub txtJustificacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtJustificacion.KeyPress
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

    Private Sub txtAhorrro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAhorrro.KeyPress
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

    Private Sub txtPrestamo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrestamo.KeyPress
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

    Private Sub btnAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutorizar.Click
        If txtTotalEntregar.Text = "" Then
            txtTotalEntregar.Text = 0
        Else
            txtTotalEntregar.Text = txtTotalEntregar.Text
        End If

        If txtSubtotal.Text = "" Then
            txtSubtotal.Text = 0
        Else
            txtSubtotal.Text = txtSubtotal.Text
        End If
        If SolFiniquitoExterno.PEstado = "A" Then
            AutorizarSolicitudes()
            Me.Close()
        ElseIf SolFiniquitoExterno.PEstado = "B" Then
            Dim objBUFiniquito As New Negocios.FiniquitosBU
            objBUFiniquito.AceptarSolicitudGerente(SolFiniquitoExterno.PFiniquito, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            objBUFiniquito.ModificarSolicitud(SolFiniquitoExterno.PFiniquito, txtUtilidades.Text, txtGratificacion.Text, txtTotalEntregar.Text, txtSubtotal.Text)
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Solicitud Aprobada"
            FormaExito.Show()
            Me.Close()


        End If


    End Sub




    Public Sub AutorizarSolicitudes()


        Dim objBUFiniquito As New Negocios.FiniquitosBU









        objBUFiniquito.AceptarSolicitud(SolFiniquitoExterno.PFiniquito, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        objBUFiniquito.ModificarSolicitud(SolFiniquitoExterno.PFiniquito, txtUtilidades.Text, txtGratificacion.Text, txtTotalEntregar.Text, txtSubtotal.Text)



        Dim FormaExito As New ExitoForm
        FormaExito.mensaje = "Solicitud Aprobada"
        FormaExito.Show()



    End Sub

    Public Sub RechazarSolicitudes()
        Dim objBUFiniquito As New Negocios.FiniquitosBU






        objBUFiniquito.RechazarSolicitud(SolFiniquitoExterno.PFiniquito, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        Dim FormaExito As New ExitoForm
        FormaExito.mensaje = "Solicitud Rechazada"

    End Sub

    Private Sub btnRechazar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRechazar.Click
        RechazarSolicitudes()
    End Sub

    Private Sub txtUtilidades_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUtilidades.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtUtilidades.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtUtilidades_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUtilidades.LostFocus
        If txtUtilidades.Text.Length = 0 Then
            txtUtilidades.Text = "0"
        End If
        txtTotalEntregar.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer) - CType(txtPrestamo.Text, Integer)).ToString("##,###.##")
        txtSubtotal.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer)).ToString("##,###.##")

        txtUtilidades.Text = FormatNumber(txtUtilidades.Text, 2)
    End Sub

    Private Sub txtGratificacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGratificacion.KeyPress

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtGratificacion.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtGratificacion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGratificacion.LostFocus
        If txtGratificacion.Text.Length = 0 Then
            txtGratificacion.Text = "0"
        End If
        txtTotalEntregar.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer) - CType(txtPrestamo.Text, Integer)).ToString("##,###.##")
        txtSubtotal.Text = (CType(txtGratificacion.Text, Integer) + CType(txtUtilidades.Text, Integer) + CType(txtAhorrro.Text, Integer) + CType(txtLiquidacion.Text, Integer)).ToString("##,###.##")

        txtGratificacion.Text = FormatNumber(txtGratificacion.Text, 2)

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub



End Class