Imports Nomina.Negocios
Imports System.Net
Imports Tools

Public Class AltaIncentivoForm
    Dim prueba As String
    Dim Seleccion As Int32
    Dim CmbSeleccion As Int32
    Dim nombre As String
    Public IdColaborador As Int32
    Public IDNave As Int32
    Public IDSolicitud As Int32
    Public montoNuevo As Double
    Public estatusGratificacion As String
    Public idCelula As String
    Public celula As String
    Public estatus As String
    Dim dtCatMotivos As New DataTable

    Public Sub AltaIncentivoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If estatus <> "A" Then
            btnGuardar.Visible = False
            lblGuardar.Visible = False
        End If
        If celula.Length = 0 Then
            lblCelula.Visible = False
            lblEtiquetaCelula.Visible = False
        Else
            lblCelula.Text = celula
        End If
        Dim objIncentivoBU As New IncentivosBU
        dtCatMotivos = New DataTable
        dtCatMotivos = objIncentivoBU.ListaIncentivosSUsuarioConsulta(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, IDNave)

        cmbMotivos = Controles.ComboMotivosIncentivoSegunNave(cmbMotivos, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, IDNave)
        cmbMotivos2 = Controles.ComboMotivosIncentivoSegunNave(cmbMotivos2, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, IDNave)
        cmbMotivos3 = Controles.ComboMotivosIncentivoSegunNave(cmbMotivos3, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, IDNave)
        '--------------------------------------------------
        If IdColaborador > 0 Then
            llenarParametros()
            Dim objBU As New IncentivosBU
            Dim EntidadIncentivo As New Entidades.SolicitudIncentivos
            '    Dim EntidadIncentivo2 As New Entidades.SolicitudIncentivos

            '  EntidadIncentivo = objBU.BuscarSolicitudIncentivo(IDSolicitud)
            EntidadIncentivo = objBU.BuscarSolicitudIncentivosVarios(IDSolicitud)

            txtJustificacion.Text = EntidadIncentivo.PDescripcion.ToUpper
            cmbMotivos.SelectedValue = EntidadIncentivo.PMotivoID.IIncentivoId
            cmbMotivos2.SelectedValue = EntidadIncentivo.PMotivoID2.IIncentivoId 'varias gratificaciones
            cmbMotivos3.SelectedValue = EntidadIncentivo.PMotivoID3.IIncentivoId



            'txtMonto.Text = EntidadIncentivo.PMonto
            txtMonto.Text = EntidadIncentivo.PMontoGratificacion1
            If EntidadIncentivo.PMontoGratificacion2 <> 0 Then
                txtMonto2.Text = EntidadIncentivo.PMontoGratificacion2
            Else
                txtMonto2.Text = String.Empty
            End If
            If EntidadIncentivo.PMontoGratificacion2 <> 0 Then
                txtMonto3.Text = EntidadIncentivo.PMontoGratificacion3
            Else
                txtMonto3.Text = String.Empty
            End If

            Dim cUnoEna As Boolean = False
            Dim cDosEna As Boolean = False
            Dim cTresEna As Boolean = False
            For Each rowdt As DataRow In dtCatMotivos.Rows
                If EntidadIncentivo.PMotivoID.IIncentivoId.ToString = rowdt.Item("moin_motivoincentivoid").ToString Then
                    cUnoEna = True
                End If
                If EntidadIncentivo.PMotivoID2.IIncentivoId = rowdt.Item("moin_motivoincentivoid").ToString Then
                    cDosEna = True
                End If
                If EntidadIncentivo.PMotivoID3.IIncentivoId.ToString = rowdt.Item("moin_motivoincentivoid").ToString Then
                    cTresEna = True
                End If
            Next

            If EntidadIncentivo.PMotivoID.IIncentivoId = 0 Then
                cUnoEna = True
            End If

            If EntidadIncentivo.PMotivoID2.IIncentivoId = 0 Then
                cDosEna = True
            End If

            If EntidadIncentivo.PMotivoID3.IIncentivoId = 0 Then
                cTresEna = True
            End If
            If cUnoEna = False Then
                txtMonto.ReadOnly = True
                cmbMotivos.Visible = False
                txtMotivoUno.Visible = True
                txtMotivoUno.Text = cmbMotivos.Text
            End If

            If cDosEna = False Then
                txtMonto2.ReadOnly = True
                cmbMotivos2.Visible = False
                txtMotivoDos.Visible = True
                txtMotivoDos.Text = cmbMotivos2.Text
            End If

            If cTresEna = False Then
                txtMonto3.ReadOnly = True
                cmbMotivos3.Visible = False
                txtMotivoTres.Visible = True
                txtMotivoTres.Text = cmbMotivos3.Text
            End If

            'If cmbMotivos.Text = "TRABAJO MEDIO DIA FESTIVO" Or cmbMotivos.Text = "TRABAJO DIA FESTIVO" Then
            '    txtMonto.ReadOnly = True
            '    cmbMotivos.Enabled = False
            'End If

            'If cmbMotivos2.Text = "TRABAJO MEDIO DIA FESTIVO" Or cmbMotivos.Text = "TRABAJO DIA FESTIVO" Then
            '    txtMonto2.ReadOnly = True
            '    cmbMotivos2.Enabled = False
            'End If

            'If cmbMotivos3.Text = "TRABAJO MEDIO DIA FESTIVO" Or cmbMotivos.Text = "TRABAJO DIA FESTIVO" Then
            '    txtMonto3.ReadOnly = True
            '    cmbMotivos3.Enabled = False
            'End If


            If estatusGratificacion <> "A" Then
                btnGuardar.Visible = False
                lblGuardar.Visible = False
                txtJustificacion.Enabled = False
                txtMonto.Enabled = False
                cmbMotivos.Enabled = False
                txtMonto2.Enabled = False
                txtMonto3.Enabled = False
                cmbMotivos2.Enabled = False
                cmbMotivos3.Enabled = False

            End If
            'btnBuscar.Visible = False
            'btnLimpiar.Visible = False
            'btnGuardar.Visible = False
            'btnLimpiarSolicitudes.Visible = False
            'lblBuscar.Visible = False
            'lblClear.Visible = False
            'lblCancelar.Visible = False
            'lblGuardar.Visible = False
        End If


    End Sub

    Private Sub btnBuscarEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  Dim empleados As New BuscarEmpleadoForm
        'empleados.MdiParent = Me
        ' empleados.ShowDialog()
    End Sub


    Private Sub cmbMotivos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If cmbMotivos.SelectedIndex <= 0 Then
        Else
            CmbSeleccion = cmbMotivos.SelectedValue
        End If
    End Sub


    Private Sub btnGuardar_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Dim Empleado As Boolean = False
        Dim monto1 As Integer = 0
        Dim monto2 As Integer = 0
        Dim monto3 As Integer = 0

        Dim Monto As Boolean = False
        If txtMonto.Text <> "" Then
            lblMonto.ForeColor = Color.Black
        Else
            lblMonto.ForeColor = Color.Red
            Monto = True
        End If
        Dim combo As Boolean = False
        If cmbMotivos.Text <> "" Then
            lblMotivo.ForeColor = Color.Black
        Else
            lblMotivo.ForeColor = Color.Red
            combo = True
        End If


        If (Empleado = True) Or (Monto = True) Or (combo = True) Then
            Dim FormularioError As New AdvertenciaForm
            FormularioError.mensaje = "Faltan campos por completar"
            'FormularioError.MdiParent = MdiParent
            FormularioError.ShowDialog()
        Else
            Dim Incentivos As New Entidades.SolicitudIncentivos

            monto1 = CInt(txtMonto.Text)
            If txtMonto2.Text.Trim <> "" Then
                monto2 = CInt(txtMonto2.Text)
            End If
            If txtMonto3.Text.Trim <> "" Then
                monto3 = CInt(txtMonto3.Text)
            End If

            Incentivos.PColaboradorID = IdColaborador
            Incentivos.PMonto = monto1 + monto2 + monto3
            Incentivos.PMontoGratificacion1 = monto1
            Incentivos.PMontoGratificacion2 = monto2
            Incentivos.PMontoGratificacion3 = monto3
            If txtJustificacion.Text.Length > 0 Or txtJustificacion.Text <> "No se capturo descripcion" Then
                Incentivos.PDescripcion = txtJustificacion.Text
            Else
                Incentivos.PDescripcion = "No se capturo descripcion"
            End If

            If cmbMotivos.SelectedIndex > 0 Then
                Dim motivo As New Entidades.Incentivos
                motivo.IIncentivoId = CInt(cmbMotivos.SelectedValue)
                Incentivos.PMotivoID = motivo
            End If


            ' If cmbMotivos2.SelectedIndex > 0 Then
            Dim motivo2 As New Entidades.Incentivos
            motivo2.IIncentivoId = CInt(cmbMotivos2.SelectedValue)
            Incentivos.PMotivoID2 = motivo2
            'End If

            '  If cmbMotivos3.SelectedIndex > 0 Then
            Dim motivo3 As New Entidades.Incentivos
            motivo3.IIncentivoId = CInt(cmbMotivos3.SelectedValue)
            Incentivos.PMotivoID3 = motivo3
            '    End If

            Dim objBU As New IncentivosBU
            'bjBU.EnviarSolicitud(Incentivos)
            Dim FormularioMensaje As New ExitoForm
            Dim FormularioError As New AdvertenciaForm
            Dim MensajeNegocios As String = ""

            Dim objMensaje As New Tools.ConfirmarForm
            objMensaje.mensaje = "¿Esta seguro de guardar los cambios?"
            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then

                If IDSolicitud > 0 Then
                    objBU.EditarSolicitud(Incentivos, IDSolicitud)
                End If
            Else
                MensajeNegocios = "Cancelo"
            End If
            If MensajeNegocios.Length = 0 Then

                montoNuevo = monto1 + monto2 + monto3
                FormularioMensaje.mensaje = "Registro Guardado"
                FormularioMensaje.ShowDialog()
                Me.Close()

            ElseIf MensajeNegocios = "El monto solicitado excede el limite del monto permitido." Then
                FormularioError.mensaje = MensajeNegocios
                FormularioError.ShowDialog()
            ElseIf MensajeNegocios = "Cancelo" Then

            Else
                FormularioError.mensaje = MensajeNegocios
                FormularioError.ShowDialog()
                Me.Close()
            End If
        End If

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim empleadosForm As New BuscarEmpleadoForm
        empleadosForm.grdBuscarEmpleado.Rows.Clear()
        txtMonto.Focus()


        If empleadosForm.ShowDialog = DialogResult.OK Then
            IdColaborador = empleadosForm.pseleccion
            llenarParametros()
            btnLimpiar.Visible = True
            lblCancelar.Visible = True
            txtMonto.Enabled = True
            txtJustificacion.Enabled = True
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
            lblColaborador2.Text = DatosPersonales.PNombre.ToUpper + " " + DatosPersonales.PApaterno.ToUpper + " " + DatosPersonales.PAmaterno.ToUpper

            ''Llenado de EDAD
            Dim FechaNacimiento As Date = DatosPersonales.PFechaNacimiento
            DiasDeVida = (FechaActual - FechaNacimiento).TotalDays
            anios = DiasDeVida \ 365
            meses = (DiasDeVida Mod 365) \ 30.4
            diasme = (DiasDeVida Mod 365) Mod 30.4
            lblEdad2.Text = anios.ToString + " AÑOS "

            ''LLENADO DE DATOS LABORALES
            Dim DatosLaborales As New Entidades.ColaboradorLaboral
            Dim DatosLaboralesBU As New Nomina.Negocios.ColaboradorLaboralBU

            DatosLaborales = DatosLaboralesBU.buscarInformacionLaboral(IdColaborador)
            lblPuesto2.Text = DatosLaborales.PPuestoId.PNombre.ToUpper
            lblDepartamento2.Text = DatosLaborales.PDepartamentoId.DNombre.ToUpper
            lblNave2.Text = DatosLaborales.PNaveId.PNombre.ToUpper
            IDNave = DatosLaborales.PNaveId.PNaveId


            ''LLENADO DE DATOS REALES
            Dim DatosReales As New Entidades.ColaboradorReal
            Dim DatosRealesBU As New Nomina.Negocios.ColaboradorRealBU

            DatosReales = DatosRealesBU.BuscarColaboradorReal(IdColaborador)

            ''Calcular antiguedad
            anios = 0
            meses = 0
            diasme = 0
            Dim FechaIngreso As Date = DatosReales.PFecha
            DiasTrabajados = (FechaActual - FechaIngreso).TotalDays

            anios = DiasTrabajados \ 365
            meses = (DiasTrabajados Mod 365) \ 30.4
            diasme = (DiasTrabajados Mod 365) Mod 30.4
            lblAntiguedad2.Text = anios.ToString + " AÑOS " + meses.ToString + " MESES " + diasme.ToString + " DIAS "

            ''Llenar configuracion del prestamo


            ''Llenar combo de motivos de prestamos


            ''Llenar combo de TipoDeInteres


        Catch ex As Exception
            Dim mensajeError As New AdvertenciaForm
            mensajeError.MdiParent = Me.MdiParent
            mensajeError.mensaje = "No selecciono ningun colaborador"
            mensajeError.ShowDialog()
            lblEdad2.Text = ""

        End Try

    End Sub

    Private Sub btnLimpiarSolicitudes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarSolicitudes.Click
        Dim monto1 As Integer = 0
        Dim monto2 As Integer = 0
        Dim monto3 As Integer = 0

        monto1 = CInt(txtMonto.Text)
        If txtMonto2.Text.Trim <> "" Then
            monto2 = CInt(txtMonto2.Text)
        End If
        If txtMonto3.Text.Trim <> "" Then
            monto3 = CInt(txtMonto3.Text)
        End If

        montoNuevo = monto1 + monto2 + monto3
        Me.Close()
    End Sub

    Private Sub AltaIncentivoForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim monto1 As Integer = 0
        Dim monto2 As Integer = 0
        Dim monto3 As Integer = 0

        monto1 = CInt(txtMonto.Text)
        If txtMonto2.Text.Trim <> "" Then
            monto2 = CInt(txtMonto2.Text)
        End If
        If txtMonto3.Text.Trim <> "" Then
            monto3 = CInt(txtMonto3.Text)
        End If

        montoNuevo = monto1 + monto2 + monto3
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtMonto2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtMonto3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto3.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cmbMotivos_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMotivos.SelectedIndexChanged
        'If cmbMotivos.Text = "TRABAJO MEDIO DIA FESTIVO" Or cmbMotivos.Text = "TRABAJO DIA FESTIVO" Then
        '    txtMonto.ReadOnly = True
        '    txtMonto.Text = "0.0"
        'Else
        '    txtMonto.ReadOnly = False
        'End If
        If estatus = "A" Then
            Try
                If cmbMotivos.SelectedIndex > 0 Then
                    Dim existe As Boolean = False
                    For Each rowdt As DataRow In dtCatMotivos.Rows
                        If cmbMotivos.SelectedValue = rowdt.Item("moin_motivoincentivoid").ToString Then
                            existe = True
                        End If
                    Next
                    If existe = True Then
                        txtMonto.ReadOnly = False
                    Else
                        txtMonto.ReadOnly = True
                        txtMonto.Text = "0.0"

                        cmbMotivos.SelectedIndex = 0

                        Dim objMensaje As New Tools.AdvertenciaForm
                        objMensaje.mensaje = "No se pueden guardar días adicionales desde esta pantalla."
                        objMensaje.ShowDialog()
                    End If
                End If
            Catch ex As Exception
                Dim objMensaje As New Tools.AdvertenciaForm
                objMensaje.mensaje = "Seleccione un motivo."
                objMensaje.ShowDialog()
            End Try
        End If

    End Sub

    Private Sub cmbMotivos2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMotivos2.SelectedIndexChanged
        If estatus = "A" Then
            Try
                If cmbMotivos2.SelectedIndex > 0 Then
                    Dim existe As Boolean = False
                    For Each rowdt As DataRow In dtCatMotivos.Rows
                        If cmbMotivos2.SelectedValue = rowdt.Item("moin_motivoincentivoid").ToString Then
                            existe = True
                        End If
                    Next
                    If existe = True Then
                        txtMonto2.ReadOnly = False
                    Else
                        txtMonto2.ReadOnly = True
                        txtMonto2.Text = "0.0"

                        cmbMotivos2.SelectedIndex = 0

                        Dim objMensaje As New Tools.AdvertenciaForm
                        objMensaje.mensaje = "No se pueden guardar días adicionales desde esta pantalla."
                        objMensaje.ShowDialog()
                    End If
                End If
            Catch ex As Exception
                Dim objMensaje As New Tools.AdvertenciaForm
                objMensaje.mensaje = "Seleccione un motivo."
                objMensaje.ShowDialog()
            End Try
        End If
    End Sub

    Private Sub cmbMotivos3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMotivos3.SelectedIndexChanged
        If estatus = "A" Then
            Try
                If cmbMotivos3.SelectedIndex > 0 Then
                    Dim existe As Boolean = False
                    For Each rowdt As DataRow In dtCatMotivos.Rows
                        If cmbMotivos3.SelectedValue = rowdt.Item("moin_motivoincentivoid").ToString Then
                            existe = True
                        End If
                    Next
                    If existe = True Then
                        txtMonto3.ReadOnly = False
                    Else
                        txtMonto3.ReadOnly = True
                        txtMonto3.Text = "0.0"

                        cmbMotivos3.SelectedIndex = 0

                        Dim objMensaje As New Tools.AdvertenciaForm
                        objMensaje.mensaje = "No se pueden guardar días adicionales desde esta pantalla."
                        objMensaje.ShowDialog()
                    End If
                End If
            Catch ex As Exception
                Dim objMensaje As New Tools.AdvertenciaForm
                objMensaje.mensaje = "Seleccione un motivo."
                objMensaje.ShowDialog()
            End Try
        End If
    End Sub

End Class