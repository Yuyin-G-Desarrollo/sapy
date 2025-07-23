Imports System.Drawing
Imports System.Windows.Forms

Public Class AltaPatronesForm

    Public editar As Boolean = False
    Public idpatron As Integer = 0
    Public guardado As Boolean = False

    Private Sub AltaPatronesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarComboEmpresa()
        Tools.Controles.ComboEstadosAnidado(cmbEstado, 1)
        cargarCajaChica()

        cargarTipoColaborador()
        cargarTipoContrato()
        cargarRiesgoPuesto()
        cargarNavesRelacion()
        cargarPatronesGrupo()

        If idpatron > 0 Then
            cmbEmpresa.Enabled = False
            txtRFC.Enabled = False
            chkAgrupado.Enabled = False
            cmbPatronGrupo.Enabled = False
            cmbNaves.Enabled = False
            cargarDatosPatronEditar()
        End If

    End Sub

#Region "Cargar Combos"

    Private Sub cargarComboEmpresa()
        Dim objBU As New Negocios.CatalogoPatronesBU
        Dim dtEmpresa As New DataTable

        dtEmpresa = objBU.ConsultaEmpresas(True)
        If dtEmpresa.Rows.Count > 0 Then
            dtEmpresa.Rows.InsertAt(dtEmpresa.NewRow, 0)
            cmbEmpresa.DataSource = dtEmpresa
            cmbEmpresa.DisplayMember = "Nombre"
            cmbEmpresa.ValueMember = "EmpresaId"
        End If

    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedIndexChanged
        Try
            cmbCiudad = Tools.Controles.ComboCiudadesMayusculas(cmbCiudad, cmbEstado.SelectedValue)

            If cmbEstado.SelectedValue <> 0 Then
                cmbCiudad.Enabled = True
            Else
                cmbCiudad.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargarTipoColaborador()
        Dim objBU As New Negocios.CatalogoPatronesBU
        Dim dtTipoCol As New DataTable

        dtTipoCol = objBU.ConsultarTipoColaborador(True)
        If dtTipoCol.Rows.Count > 0 Then
            dtTipoCol.Rows.InsertAt(dtTipoCol.NewRow, 0)
            cmbTipoColaborador.DataSource = dtTipoCol
            cmbTipoColaborador.DisplayMember = "descripcion"
            cmbTipoColaborador.ValueMember = "tipoColId"
        End If
    End Sub

    Private Sub cargarCajaChica()
        Dim objBU As New Negocios.CatalogoPatronesBU
        Dim dtCajas As New DataTable

        dtCajas = objBU.ConsultarCajas(True)
        If dtCajas.Rows.Count > 0 Then
            dtCajas.Rows.InsertAt(dtCajas.NewRow, 0)
            cmbCajaChica.DataSource = dtCajas
            cmbCajaChica.DisplayMember = "Nombre"
            cmbCajaChica.ValueMember = "Id_Caja"
        End If

    End Sub

    Private Sub cargarTipoContrato()
        Dim objBU As New Negocios.CatalogoPatronesBU
        Dim dtTipoContrato As New DataTable

        dtTipoContrato = objBU.ConsultarTipoContrato(True)
        If dtTipoContrato.Rows.Count > 0 Then
            dtTipoContrato.Rows.InsertAt(dtTipoContrato.NewRow, 0)
            cmbTipoContrato.DataSource = dtTipoContrato
            cmbTipoContrato.DisplayMember = "descripcion"
            cmbTipoContrato.ValueMember = "tipocontrato"
        End If

    End Sub

    Private Sub cargarRiesgoPuesto()
        Dim objBU As New Negocios.CatalogoPatronesBU
        Dim dtTipoRiesgo As New DataTable

        dtTipoRiesgo = objBU.ConsultarRiesgoPuesto(True)
        If dtTipoRiesgo.Rows.Count > 0 Then
            dtTipoRiesgo.Rows.InsertAt(dtTipoRiesgo.NewRow, 0)
            cmbRiesgoPuesto.DataSource = dtTipoRiesgo
            cmbRiesgoPuesto.DisplayMember = "clase"
            cmbRiesgoPuesto.ValueMember = "clave"
        End If
    End Sub

    Private Sub cargarNavesRelacion()
        Dim objBU As New Negocios.CatalogoPatronesBU
        Dim dtNaves As New DataTable

        dtNaves = objBU.ConsultarNaves(True)
        If dtNaves.Rows.Count > 0 Then
            dtNaves.Rows.InsertAt(dtNaves.NewRow, 0)
            cmbNaves.DataSource = dtNaves
            cmbNaves.DisplayMember = "nombre"
            cmbNaves.ValueMember = "naveid"
        End If
    End Sub

    Private Sub cargarPatronesGrupo()
        Dim objBU As New Negocios.CatalogoPatronesBU
        Dim dtPatronesRel As New DataTable

        dtPatronesRel = objBU.ConsultarPatronesGrupo(True)
        If dtPatronesRel.Rows.Count > 0 Then
            dtPatronesRel.Rows.InsertAt(dtPatronesRel.NewRow, 0)
            cmbPatronGrupo.DataSource = dtPatronesRel
            cmbPatronGrupo.DisplayMember = "nombre"
            cmbPatronGrupo.ValueMember = "patronid"
        End If
    End Sub

#End Region

    Private Sub cargarDatosPatronEditar()
        Dim objPatronEdit As New Entidades.Patron
        Dim objBU As New Negocios.CatalogoPatronesBU

        objPatronEdit = objBU.ConsultarPatronEditar(Me.idpatron)
        If Not objPatronEdit Is Nothing Then

            txtNombre.Text = objPatronEdit.PNombre
            txtRFC.Text = objPatronEdit.PRFC
            txtNumeroDeRegistro.Text = objPatronEdit.PNoPatronal
            txtCalle.Text = objPatronEdit.PCalle
            txtNumero.Text = objPatronEdit.PNumero
            txtColonia.Text = objPatronEdit.PColonia
            cmbEstado.SelectedValue = objPatronEdit.PEstadoId
            cmbCiudad.SelectedValue = objPatronEdit.PCiudadId
            txtCP.Text = objPatronEdit.PCP
            rdoActivoSi.Checked = objPatronEdit.PActivo
            rdoActivoNo.Checked = Not (objPatronEdit.PActivo)
            cmbEmpresa.SelectedValue = objPatronEdit.PEmpresaId
            cmbNaves.SelectedValue = objPatronEdit.PNaveId
            rdoChecadorSi.Checked = objPatronEdit.PChecador
            rdoChecadorNo.Checked = Not (objPatronEdit.PChecador)
            cmbTipoColaborador.SelectedValue = objPatronEdit.PTipoColaborador
            cmbTipoContrato.SelectedValue = objPatronEdit.PTipoContrato
            cmbRiesgoPuesto.SelectedValue = objPatronEdit.PRiesgoPuesto
            cmbCajaChica.SelectedValue = objPatronEdit.PCajaChica
            rdoComisionSI.Checked = objPatronEdit.PComisiones
            rdoComisionNO.Checked = Not (objPatronEdit.PComisiones)
            txtDescuentoInfonavit.Text = objPatronEdit.PDescuentoInfonavit
            txtPrcAsistencia.Text = objPatronEdit.PPorcentajeAsistencia
            txtPrcPuntualidad.Text = objPatronEdit.PPorcentajePuntualidad
            txtClaveSS.Text = objPatronEdit.PClaveSeguridadSocial
            txtClaveAfore.Text = objPatronEdit.PClaveRetiroCesantia
            txtClaveISR.Text = objPatronEdit.PClaveISR
            txtClaveInfonavit.Text = objPatronEdit.PClaveInfonavit
            txtClaveSPE.Text = objPatronEdit.PClaveSPE
            txtClaveISRAyV.Text = objPatronEdit.PClaveISRAguinaldoVacaciones
            txtClaveISRAnual.Text = objPatronEdit.PClaveISRAnual
            txtClaveSPEAnual.Text = objPatronEdit.PClaveSPEAnual
            txtOtrosPagosAnual.Text = objPatronEdit.PClavePercepcionACargoAnual
            txtClaveComisiones.Text = objPatronEdit.PClaveComisiones
            chkAgrupado.Checked = objPatronEdit.PAgrupado
            If chkAgrupado.Checked Then
                cmbPatronGrupo.SelectedValue = objPatronEdit.PPatronGrupo
            End If

        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objMensajeConf As New Tools.ConfirmarForm
        Dim mensajeAdv As New Tools.AdvertenciaForm
        Dim objBu As New Negocios.CatalogoPatronesBU
        If Not editar AndAlso objBu.ExistePatron(txtRFC.Text, txtNumeroDeRegistro.Text) Then
            mensajeAdv.mensaje = "Ya existe un patrón con el RFC y Registro Patronal capturados."
            mensajeAdv.ShowDialog()
        Else
            If validarDatos() Then
                If editar Then
                    objMensajeConf.mensaje = "Esta acción modificará los datos del patrón. ¿Desea continuar?"
                Else
                    objMensajeConf.mensaje = "Una vez guardado no se podrá modificar RFC, Registro Patronal, Empresa y los datos de la pestaña «Relaciones». ¿Está seguro de guardar?"
                End If

                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim objPatron As New Entidades.Patron
                    Dim mensaje As String = String.Empty

                    With objPatron
                        .PPatronId = Me.idpatron
                        .PNombre = txtNombre.Text
                        .PRFC = txtRFC.Text
                        .PNoPatronal = txtNumeroDeRegistro.Text
                        .PCalle = txtCalle.Text
                        .PNumero = txtNumero.Text
                        .PColonia = txtColonia.Text
                        .PEstadoId = cmbEstado.SelectedValue
                        .PCiudadId = cmbCiudad.SelectedValue
                        .PCP = txtCP.Text
                        .PActivo = rdoActivoSi.Checked
                        .PEmpresaId = CInt(cmbEmpresa.SelectedValue)
                        .PNaveId = CInt(cmbNaves.SelectedValue)
                        .PChecador = rdoChecadorSi.Checked
                        .PTipoColaborador = CInt(cmbTipoColaborador.SelectedValue)
                        .PTipoContrato = CStr(cmbTipoContrato.SelectedValue)
                        .PRiesgoPuesto = CStr(cmbRiesgoPuesto.SelectedValue)
                        .PCajaChica = CInt(cmbCajaChica.SelectedValue)
                        .PComisiones = rdoComisionSI.Checked
                        .PDescuentoInfonavit = txtDescuentoInfonavit.Text
                        .PPorcentajeAsistencia = txtPrcAsistencia.Text
                        .PPorcentajePuntualidad = txtPrcPuntualidad.Text
                        .PClaveSeguridadSocial = txtClaveSS.Text
                        .PClaveRetiroCesantia = txtClaveAfore.Text
                        .PClaveISR = txtClaveISR.Text
                        .PClaveInfonavit = txtClaveInfonavit.Text
                        .PClaveSPE = txtClaveSPE.Text
                        .PClaveISRAguinaldoVacaciones = txtClaveISRAyV.Text
                        .PClaveISRAnual = txtClaveISRAnual.Text
                        .PClaveSPEAnual = txtClaveSPEAnual.Text
                        .PClavePercepcionACargoAnual = txtOtrosPagosAnual.Text
                        .PClaveComisiones = txtClaveComisiones.Text
                        .PAgrupado = chkAgrupado.Checked
                        If chkAgrupado.Checked Then
                            .PPatronGrupo = cmbPatronGrupo.SelectedValue
                        Else
                            .PPatronGrupo = 0
                        End If
                    End With

                    mensaje = objBu.AltaEdicionPatron(objPatron)
                    If mensaje = "EXITO" Then
                        If Not editar Then
                            mensaje = String.Empty
                            mensaje = objBu.AltaRutasFacturacion(objPatron.PEmpresaId, 3, "AMBOS")
                        End If

                        If mensaje = "EXITO" Then
                            Dim mensajeExito As New Tools.ExitoForm
                            mensajeExito.mensaje = "Se guardó correctamente la información del patrón."
                            mensajeExito.ShowDialog()
                        Else
                            mensajeAdv.mensaje = "Se guardó correctamente la información del patrón pero no se pudieron guardar las rutas de facturación, favor de informar a sistemas."
                            mensajeAdv.ShowDialog()

                        End If

                        guardado = True
                        Me.Close()

                    Else
                        Dim mensajeError As New Tools.ErroresForm
                        mensajeError.mensaje = "Ocurrió un error al guardar la información del patrón."
                        mensajeError.ShowDialog()
                        guardado = False
                    End If
                End If
            Else
                mensajeAdv.mensaje = "Faltan campos por llenar."
                mensajeAdv.ShowDialog()
            End If
        End If
    End Sub

    Private Function validarDatos() As Boolean
        Dim blnRetur As Boolean = True

        If txtNombre.Text.Trim = "" Then
            blnRetur = False
            lblNombre.ForeColor = Color.Red
        Else
            lblNombre.ForeColor = Color.Black
        End If

        If cmbEmpresa.Text.Trim = "" Or cmbEmpresa.SelectedIndex = 0 Then
            blnRetur = False
            lblEmpresa.ForeColor = Color.Red
        Else
            lblEmpresa.ForeColor = Color.Black
        End If

        If txtCalle.Text.Trim = "" Then
            blnRetur = False
            lblCalle.ForeColor = Color.Red
        Else
            lblCalle.ForeColor = Color.Black
        End If

        If txtNumero.Text.Trim = "" Then
            blnRetur = False
            lblNumero.ForeColor = Color.Red
        Else
            lblNumero.ForeColor = Color.Black
        End If

        If txtColonia.Text.Trim = "" Then
            blnRetur = False
            lblColonia.ForeColor = Color.Red
        Else
            lblColonia.ForeColor = Color.Black
        End If

        If cmbCiudad.Text.Trim = "" Or cmbCiudad.SelectedIndex = 0 Then
            blnRetur = False
            lblCiudad.ForeColor = Color.Red
        Else
            lblCiudad.ForeColor = Color.Black
        End If

        If cmbEstado.Text.Trim = "" Or cmbEstado.SelectedIndex = 0 Then
            blnRetur = False
            lblEstado.ForeColor = Color.Red
        Else
            lblEstado.ForeColor = Color.Black
        End If

        If txtCP.Text.Trim = "" Then
            blnRetur = False
            lblCp.ForeColor = Color.Red
        Else
            lblCp.ForeColor = Color.Black
        End If

        If txtRFC.Text.Trim = "" Then
            blnRetur = False
            lblRFC.ForeColor = Color.Red
        Else
            lblRFC.ForeColor = Color.Black
        End If

        If txtNumeroDeRegistro.Text.Trim = "" Then
            blnRetur = False
            lblNumeroDeRegistroPatronal.ForeColor = Color.Red
        Else
            lblNumeroDeRegistroPatronal.ForeColor = Color.Black
        End If

        If txtDescuentoInfonavit.Text.Trim = "" Then
            blnRetur = False
            lblDescuentoInfonavit.ForeColor = Color.Red
        Else
            lblDescuentoInfonavit.ForeColor = Color.Black
        End If

        If cmbTipoColaborador.Text.Trim = "" Or cmbTipoColaborador.SelectedIndex = 0 Then
            blnRetur = False
            lblTipoColaborador.ForeColor = Color.Red
        Else
            lblTipoColaborador.ForeColor = Color.Black
        End If

        If cmbCajaChica.Text.Trim = "" Or cmbCajaChica.SelectedIndex = 0 Then
            blnRetur = False
            lblCajaChica.ForeColor = Color.Red
        Else
            lblCajaChica.ForeColor = Color.Black
        End If

        If cmbTipoContrato.Text.Trim = "" Or cmbTipoContrato.SelectedIndex = 0 Then
            blnRetur = False
            lblTipoContrato.ForeColor = Color.Red
        Else
            lblTipoContrato.ForeColor = Color.Black
        End If

        If cmbRiesgoPuesto.Text.Trim = "" Or cmbRiesgoPuesto.SelectedIndex = 0 Then
            blnRetur = False
            lblRiesgoPuesto.ForeColor = Color.Red
        Else
            lblRiesgoPuesto.ForeColor = Color.Black
        End If

        If cmbNaves.Text.Trim = "" Or cmbNaves.SelectedIndex = 0 Then
            blnRetur = False
            lblNave.ForeColor = Color.Red
        Else
            lblNave.ForeColor = Color.Black
        End If

        If chkAgrupado.Checked Then
            If cmbPatronGrupo.Text.Trim = "" Or cmbPatronGrupo.SelectedIndex = 0 Then
                blnRetur = False
                chkAgrupado.ForeColor = Color.Red
            Else
                chkAgrupado.ForeColor = Color.Black
            End If
        Else
            chkAgrupado.ForeColor = Color.Black
        End If

        If txtClaveISR.Text.Trim = "" Then
            blnRetur = False
            lblClaveISR.ForeColor = Color.Red
        Else
            lblClaveISR.ForeColor = Color.Black
        End If

        If txtClaveSPE.Text.Trim = "" Then
            blnRetur = False
            lblClaveSPE.ForeColor = Color.Red
        Else
            lblClaveSPE.ForeColor = Color.Black
        End If

        If txtClaveSS.Text.Trim = "" Then
            blnRetur = False
            lblClaveSS.ForeColor = Color.Red
        Else
            lblClaveSS.ForeColor = Color.Black
        End If

        If txtClaveAfore.Text.Trim = "" Then
            blnRetur = False
            lblClaveAfore.ForeColor = Color.Red
        Else
            lblClaveAfore.ForeColor = Color.Black
        End If

        If txtClaveInfonavit.Text.Trim = "" Then
            blnRetur = False
            lblClaveInfonavit.ForeColor = Color.Red
        Else
            lblClaveInfonavit.ForeColor = Color.Black
        End If

        If txtClaveISRAnual.Text.Trim = "" Then
            blnRetur = False
            lblClaveISRAnual.ForeColor = Color.Red
        Else
            lblClaveISRAnual.ForeColor = Color.Black
        End If

        If txtClaveSPEAnual.Text.Trim = "" Then
            blnRetur = False
            lblClaveSPEAnual.ForeColor = Color.Red
        Else
            lblClaveSPEAnual.ForeColor = Color.Black
        End If

        If txtClaveISRAyV.Text.Trim = "" Then
            blnRetur = False
            lblClaveISRAyV.ForeColor = Color.Red
        Else
            lblClaveISRAyV.ForeColor = Color.Black
        End If

        If txtOtrosPagosAnual.Text.Trim = "" Then
            blnRetur = False
            lblOtrosPagosAnual.ForeColor = Color.Red
        Else
            lblOtrosPagosAnual.ForeColor = Color.Black
        End If

        If txtPrcAsistencia.Text.Trim = "" Then
            blnRetur = False
            lblPrcAsistencia.ForeColor = Color.Red
        Else
            lblPrcAsistencia.ForeColor = Color.Black
        End If

        If txtPrcPuntualidad.Text.Trim = "" Then
            blnRetur = False
            lblPrcPuntualidad.ForeColor = Color.Red
        Else
            lblPrcPuntualidad.ForeColor = Color.Black
        End If

        If rdoComisionSI.Checked Then
            If txtClaveComisiones.Text.Trim = "" Then
                blnRetur = False
                lblClaveComisiones.ForeColor = Color.Red
            Else
                lblClaveComisiones.ForeColor = Color.Black
            End If
        Else
            lblClaveComisiones.ForeColor = Color.Black
        End If

        Return blnRetur
    End Function

    Private Sub chkAgrupado_CheckedChanged(sender As Object, e As EventArgs) Handles chkAgrupado.CheckedChanged
        cmbPatronGrupo.Enabled = chkAgrupado.Checked
        If editar Then
            cmbPatronGrupo.Enabled = False
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dim objMensajeAdv As New Tools.ConfirmarForm

        objMensajeAdv.mensaje = "¿Realmente quiere cerrar la ventana?, los datos capturados se perderan al cerrar"
        If objMensajeAdv.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub txtPrcAsistencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrcAsistencia.KeyPress, txtPrcPuntualidad.KeyPress, txtDescuentoInfonavit.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = False
        End If
    End Sub

End Class