Imports Tools
Imports System.Drawing
Imports Framework.Negocios

Public Class AltaColaboradorContabilidadForm
    Public idColaborador As Int32 = 0
    Dim validaCurp As Boolean = True
    Dim validaRFC As Boolean = True

    Public Sub cargarCombosIniciales()
        ''nave
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        ''combo estado origen (fecha de nacimiento)
        cmbEstadoOrigen = Tools.Controles.ComboEstadosAnidado(cmbEstadoOrigen, 1)

        cargarDepartamentoFiscal()
    End Sub

    Public Sub cargarCombosEdicion()
        Dim objBu As New Contabilidad.Negocios.UtileriasBU
        ''TIPO DESCUENTO
        Dim dtTipoDescuento As New DataTable
        objBu = New Negocios.UtileriasBU
        dtTipoDescuento = objBu.consultaTipoDescuento

        If dtTipoDescuento.Rows.Count > 0 Then
            cmbTipoDes.DataSource = dtTipoDescuento
            cmbTipoDes.DisplayMember = "Descuento"
            cmbTipoDes.ValueMember = "idDescuento"
            cmbTipoDes.SelectedIndex = 0
        End If

        If cmbPatron.SelectedIndex <> 0 Then
            ''Tipo Colaborador
            Dim dtTipoCola As New DataTable
            objBu = New Negocios.UtileriasBU
            dtTipoCola = objBu.consultaTipoTrabajador(cmbPatron.SelectedValue)

            If dtTipoCola.Rows.Count > 0 Then
                cmbTipoTrabajador.DataSource = dtTipoCola
                cmbTipoTrabajador.DisplayMember = "tipoColaborador"
                cmbTipoTrabajador.ValueMember = "idTipoColaborador"
                cmbTipoTrabajador.SelectedIndex = 0
            End If
        End If


        ''tipo Salario
        Dim dtTipoSalario As New DataTable
        objBu = New Negocios.UtileriasBU
        dtTipoSalario = objBu.consultaTipoSalario

        If dtTipoSalario.Rows.Count > 0 Then
            cmbTipoSalario.DataSource = dtTipoSalario
            cmbTipoSalario.DisplayMember = "TipoSalario"
            cmbTipoSalario.ValueMember = "IDTipoSalario"
            cmbTipoSalario.SelectedIndex = 0
        End If

        ''tipoJornada
        Dim dtTipoJornada As New DataTable
        objBu = New Negocios.UtileriasBU
        dtTipoJornada = objBu.consultaTipoJornada

        If dtTipoJornada.Rows.Count > 0 Then
            cmbTipoJornada.DataSource = dtTipoJornada
            cmbTipoJornada.DisplayMember = "TipoJornada"
            cmbTipoJornada.ValueMember = "IDTipoJornada"
            cmbTipoJornada.SelectedIndex = 0
        End If

        cargarDepartamentosReales()
    End Sub



    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


    Private Sub AltaColaboradorContabilidadForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtNSS.MaxLength = 11
        'txtCurp.MaxLength = 18
        dtpFechaAlta.Enabled = False
        rdoInfonavitSI.Enabled = False
        rdoInfonavitNo.Enabled = False
        txtNumeroCredito.Enabled = False
        cmbTipoDes.Enabled = False
        txtValorDescuento.Enabled = False
        rdotablaDisminucionNo.Enabled = False
        rdotablaDisminucionSI.Enabled = False
        txtSDI.Enabled = False
        cmbTipoSalario.Enabled = False
        cmbTipoTrabajador.Enabled = False
        cmbTipoJornada.Enabled = False
        'txtNSS.Enabled = False
        txtSDI.Enabled = False
        txtUMF.Enabled = False
        rdoComisionNO.Checked = True
        numComision.Value = 0.0

        If PermisosUsuarioBU.ConsultarPermiso("LISTA_COLABO", "EDITAR_COMISIONES") Then
            pnlComisiones.Enabled = True
            numComision.Enabled = True
        Else
            pnlComisiones.Enabled = False
            numComision.Enabled = False
        End If

        dtpFechaAlta.Text = Today
        dtpNacimiento.Text = Today

        cargarCombosIniciales()

        If idColaborador <> 0 Then
            ''AQUI CONSULTA DE DATOS PARA EDITAR
            cargarCombosEdicion()
            Dim objBu As New Negocios.ColaboradoresContabilidadBU
            Dim dtDatos As New DataTable

            dtDatos = objBu.consultaDatosColaborador(idColaborador)
            
            cmbNave.Enabled = False
            cmbPatron.Enabled = False
            'cmbTipoSalario.Enabled = True

            If Not IsNothing(dtDatos) Then
                If dtDatos.Rows.Count > 0 Then
                    cmbNave.SelectedValue = dtDatos.Rows(0).Item("idNave")
                    cmbPatron.SelectedValue = dtDatos.Rows(0).Item("idPatron")
                    cargarComboPuestos()
                    cargarComboPuestoReal()
                    txtNombre.Text = dtDatos.Rows(0).Item("nombre")
                    txtAPaterno.Text = dtDatos.Rows(0).Item("apaterno")
                    txtAMaterno.Text = dtDatos.Rows(0).Item("amaterno")
                    txtCurp.Text = dtDatos.Rows(0).Item("curp")
                    txtRFC.Text = dtDatos.Rows(0).Item("rfc")
                    dtpNacimiento.Text = dtDatos.Rows(0).Item("fnacimiento")
                    cmbSexo.Text = dtDatos.Rows(0).Item("sexo")
                    txtCalle.Text = dtDatos.Rows(0).Item("calle")
                    txtColonia.Text = dtDatos.Rows(0).Item("colonia")
                    txtEntreCalles.Text = dtDatos.Rows(0).Item("entrecalles")
                    txtReferencias.Text = dtDatos.Rows(0).Item("referencia")
                    txtNumero.Text = dtDatos.Rows(0).Item("numero")
                    txtcp.Text = dtDatos.Rows(0).Item("cp")
                    cmbPuesto.SelectedValue = dtDatos.Rows(0).Item("idpuesto")
                    cmbTipoTrabajador.SelectedValue = dtDatos.Rows(0).Item("idTrabajador")
                    cmbTipoSalario.SelectedValue = dtDatos.Rows(0).Item("idTipoSalario")
                    cmbTipoJornada.SelectedValue = dtDatos.Rows(0).Item("idJornada")
                    txtUMF.Text = dtDatos.Rows(0).Item("umf")
                    txtObservaciones.Text = dtDatos.Rows(0).Item("observacionesexterno")
                    txtObra.Text = dtDatos.Rows(0).Item("obra")

                    cmbDeptoFiscal.SelectedValue = dtDatos.Rows(0).Item("idDeptoFiscal")
                    cargarDepartamentosReales()
                    cmbDeptoReal.SelectedValue = dtDatos.Rows(0).Item("idDeptoReal")
                    'cargarComboPuestoReal()
                    cmbPuestoReal.SelectedValue = dtDatos.Rows(0).Item("idPuestoReal")
                    txtNumeroCredito.Text = dtDatos.Rows(0).Item("numeroinfonavit")
                    If dtDatos.Rows(0).Item("cuentainfonavit") = 0 Then
                        rdoInfonavitNo.Checked = True
                    Else
                        rdoInfonavitSI.Checked = True
                    End If
                    cmbTipoDes.SelectedValue = dtDatos.Rows(0).Item("idTipoDescuento")
                    txtValorDescuento.Text = dtDatos.Rows(0).Item("valorDescuento")

                    If dtDatos.Rows(0).Item("aplicatabla") = 0 Then
                        rdotablaDisminucionNo.Checked = True
                    Else
                        rdotablaDisminucionSI.Checked = True
                    End If


                    cmbEstadoOrigen.SelectedValue = dtDatos.Rows(0).Item("idEstado")
                    cmbCiudadColaborador.SelectedValue = dtDatos.Rows(0).Item("idnacimiento")
                    cmbPuesto.SelectedValue = dtDatos.Rows(0).Item("idPuesto")

                    txtNSS.Text = dtDatos.Rows(0).Item("nss")
                    txtSDI.Text = dtDatos.Rows(0).Item("sdi")
                    txtUMF.Text = dtDatos.Rows(0).Item("umf")
                    dtpFechaAlta.Value = dtDatos.Rows(0).Item("fechaAlta")

                    If Not CBool(dtDatos.Rows(0).Item("externo")) Then
                        cmbPuestoReal.Enabled = False
                        cmbDeptoReal.Enabled = False
                    End If

                    rdoComisionSI.Checked = CBool(dtDatos.Rows(0).Item("ganacomision"))
                    numComision.Value = CDbl(dtDatos.Rows(0).Item("maxcomision"))

                End If
            End If

        End If
    End Sub

    Public Sub cargarComboPuestos()
        Dim dtPuestos As New DataTable
        Dim objBu As New Negocios.UtileriasBU
        Dim dtSDI As New DataTable

        If cmbPatron.SelectedValue > 0 Then
            dtPuestos = objBu.consultaPuestosFiscales(cmbPatron.SelectedValue)
            cmbPuesto.DataSource = Nothing
            'cmbPuestoReal.DataSource = Nothing
            If dtPuestos.Rows.Count > 0 Then
                cmbPuesto.DataSource = dtPuestos
                cmbPuesto.DisplayMember = "Puesto"
                cmbPuesto.ValueMember = "IdPuesto"

                If dtPuestos.Rows.Count = 2 Then
                    cmbPuesto.SelectedIndex = 1
                End If
            End If
        End If
    End Sub

    Public Sub cargarComboPuestoReal()
        Try
            Dim idDepto As Int32 = 0

            idDepto = cmbDeptoReal.SelectedValue
            cmbPuestoReal.DataSource = Nothing
            If idDepto <> 0 Then
                cmbPuestoReal = Controles.ComboPuestosSegunDepartamento(cmbPuestoReal, idDepto)
            End If
        Catch ex As Exception

        End Try
        'Dim dtPuestos As New DataTable
        'Dim objBu As New Negocios.UtileriasBU
        'Dim dtSDI As New DataTable
        'Dim idPuestoF As Int32 = 0

        'idPuestoF = cmbNave.SelectedValue
        'cmbPuestoReal.DataSource = Nothing
        'If idPuestoF <> 0 Then
        '    dtPuestos = objBu.consultaPuestosReales(idPuestoF)

        '    If dtPuestos.Rows.Count > 0 Then
        '        cmbPuestoReal.DataSource = dtPuestos
        '        cmbPuestoReal.DisplayMember = "PuestoR"
        '        cmbPuestoReal.ValueMember = "IdPuestoR"
        '        If dtPuestos.Rows.Count = 2 Then
        '            cmbPuestoReal.SelectedIndex = 1
        '        End If

        '    End If
        'End If
    End Sub

    Public Sub cargarDepartamentoFiscal()
        Dim dtDeptoFiscal As New DataTable
        Dim objBu As New Negocios.UtileriasBU
        Dim dtSDI As New DataTable
        
        cmbDeptoFiscal.DataSource = Nothing
        If cmbPatron.SelectedIndex > 0 Then
            dtDeptoFiscal = objBu.consultaDepartamentosFiscales(cmbPatron.SelectedValue)

            If dtDeptoFiscal.Rows.Count > 0 Then
                cmbDeptoFiscal.DataSource = dtDeptoFiscal
                cmbDeptoFiscal.DisplayMember = "deptoFiscal"
                cmbDeptoFiscal.ValueMember = "idDeptoFiscal"

                If dtDeptoFiscal.Rows.Count = 2 Then
                    cmbDeptoFiscal.SelectedIndex = 1
                End If
            End If
        End If
    End Sub

    Public Sub cargarDepartamentosReales()
        Dim idNave As Int32 = 0

        idNave = cmbNave.SelectedValue
        cmbDeptoReal.DataSource = Nothing
        If idNave <> 0 Then
            cmbDeptoReal = Controles.ComboDepatamentoSegunNave(cmbDeptoReal, idNave)
        End If

        'Dim dtDeptoReal As New DataTable
        'Dim objBu As New Negocios.UtileriasBU
        'Dim dtSDI As New DataTable
        'Dim idDeptoF As Int32 = 0

        'idDeptoF = cmbDeptoFiscal.SelectedValue
        'cmbDeptoReal.DataSource = Nothing
        'If idDeptoF <> 0 Then
        '    dtDeptoReal = objBu.consultaDepartamentosREales(idDeptoF)

        '    If dtDeptoReal.Rows.Count > 0 Then
        '        cmbDeptoReal.DataSource = dtDeptoReal
        '        cmbDeptoReal.DisplayMember = "depto"
        '        cmbDeptoReal.ValueMember = "id"

        '        If dtDeptoReal.Rows.Count = 2 Then
        '            cmbDeptoReal.SelectedIndex = 1
        '        End If

        '    End If
        'End If
    End Sub

    Public Function validarCampos() As Boolean
        validarCampos = True
        Dim erroresForm As New AdvertenciaForm

        If cmbNave.SelectedIndex = 0 Then
            validarCampos = False
            lblNave.ForeColor = Drawing.Color.Red
        Else
            lblNave.ForeColor = Drawing.Color.Black
        End If

        If cmbPatron.SelectedIndex > 0 Then
            lblPatron.ForeColor = Drawing.Color.Black
        Else
            validarCampos = False
            lblPatron.ForeColor = Drawing.Color.Red
        End If

        If cmbDeptoFiscal.SelectedIndex > 0 Then
            lblDeptoFiscal.ForeColor = Drawing.Color.Black
        Else
            validarCampos = False
            lblDeptoFiscal.ForeColor = Drawing.Color.Red
        End If

        If cmbDeptoReal.SelectedIndex > 0 Then
            lblDeptoReal.ForeColor = Drawing.Color.Black
        Else
            validarCampos = False
            lblDeptoReal.ForeColor = Drawing.Color.Red
        End If

        If txtNombre.Text.Length <= 0 Then
            validarCampos = False
            lblNombre.ForeColor = Color.Red
        Else
            lblNombre.ForeColor = Color.Black
        End If

        If txtAPaterno.Text.Length <= 0 Then
            validarCampos = False
            lblAPaterno.ForeColor = Color.Red
        Else
            lblAPaterno.ForeColor = Color.Black
        End If

        If txtCurp.Text.Trim.Length <= 0 Then
            validarCampos = False
            lblCurp.ForeColor = Color.Red
        ElseIf txtCurp.Text.Trim.Length <> 18 Then
            validarCampos = False
            lblCurp.ForeColor = Color.Red

        Else
            lblCurp.ForeColor = Color.Black
        End If

        If txtRFC.Text.Trim.Length <= 0 Then
            validarCampos = False
            lblRFC.ForeColor = Color.Red
        ElseIf txtRFC.Text.Trim.Length <> 13 Then
            validarCampos = False
            lblRFC.ForeColor = Color.Red
        Else
            lblRFC.ForeColor = Color.Black
        End If

        If IsNothing(dtpNacimiento.Value) Then
            validarCampos = False
            lblFNacimiento.ForeColor = Color.Red
        Else
            lblFNacimiento.ForeColor = Color.Black
        End If

        If cmbEstadoOrigen.SelectedIndex <= 0 Then
            validarCampos = False
            lblLugarNa.ForeColor = Color.Red
        Else
            lblLugarNa.ForeColor = Color.Black
        End If

        If cmbCiudadColaborador.SelectedIndex <= 0 Then
            validarCampos = False
            lblLugarNa.ForeColor = Color.Red
        Else
            lblLugarNa.ForeColor = Color.Black
        End If

        If txtCalle.Text.Length <= 0 Then
            validarCampos = False
            lblCalle.ForeColor = Color.Red
        Else
            lblCalle.ForeColor = Color.Black
        End If

        If txtNumero.Text.Length <= 0 Then
            validarCampos = False
            lblNumero.ForeColor = Color.Red
        Else
            lblNumero.ForeColor = Color.Black
        End If

        If txtColonia.Text.Length <= 0 Then
            validarCampos = False
            lblColonia.ForeColor = Color.Red
        Else
            lblColonia.ForeColor = Color.Black
        End If

        If txtcp.Text.Length <= 0 Then
            validarCampos = False
            lblcp.ForeColor = Color.Red
        ElseIf txtcp.Text.Trim.Length <> 5 Then
            validarCampos = False
            lblcp.ForeColor = Color.Red
        ElseIf Not IsNumeric(txtcp.Text.Trim) Then
            validarCampos = False
            lblcp.ForeColor = Color.Red
        Else
            lblcp.ForeColor = Color.Black
        End If

        If txtEntreCalles.Text.Length <= 0 Then
            validarCampos = False
            lblEntreCalles.ForeColor = Color.Red
        Else
            lblEntreCalles.ForeColor = Color.Black
        End If

        If cmbPuesto.SelectedIndex > 0 Then

            lblPuestoLaboral.ForeColor = Color.Black
        Else
            validarCampos = False
            lblPuestoLaboral.ForeColor = Color.Red
        End If

        If cmbPuestoReal.SelectedIndex > 0 Then

            lblPuestoR.ForeColor = Color.Black
        Else
            validarCampos = False
            lblPuestoR.ForeColor = Color.Red
        End If

        If txtReferencias.Text.Length <= 0 Then
            validarCampos = False
            lblRefAd.ForeColor = Color.Red
        Else
            lblRefAd.ForeColor = Color.Black
        End If

        If txtObservaciones.Text.Length <= 0 Then
            validarCampos = False
            lblObservaciones.ForeColor = Color.Red
        Else
            lblObservaciones.ForeColor = Color.Black
        End If

        If rdoComisionSI.Checked Then
            If numComision.Value > 0 Then
                lblComision.ForeColor = Color.Black
            Else
                validarCampos = False
                lblComision.ForeColor = Color.Red
            End If
        Else
            lblComision.ForeColor = Color.Black
        End If

        If txtCurp.Text.Length < 18 Then
            validarCampos = False
            erroresForm.mensaje = "Capture el Curp COMPLETO"
            erroresForm.MdiParent = Me.MdiParent
            erroresForm.Show()
        ElseIf txtCurp.Text.Length > 18 Then
            erroresForm.mensaje = "El Curp excede los 18 caracteres permitidos para el CURP"
            erroresForm.MdiParent = Me.MdiParent
            erroresForm.Show()
        Else
            ''VALIDA CURP
            validaCurp = validaCURPRFCAlta(txtAPaterno.Text, txtAMaterno.Text, txtNombre.Text, dtpNacimiento.Text, txtCurp.Text, txtRFC.Text, "CURP")
            validaRFC = validaCURPRFCAlta(txtAPaterno.Text, txtAMaterno.Text, txtNombre.Text, dtpNacimiento.Text, txtCurp.Text, txtRFC.Text, "RFC")
        End If

        If txtNSS.Text.Length < 11 Then
            validarCampos = False
            erroresForm.mensaje = "Capture el NSS COMPLETO"
            erroresForm.MdiParent = Me.MdiParent
            erroresForm.Show()
        End If

        If validaCurp = False Then
            validarCampos = False
            erroresForm.mensaje = "El curp capturado no coincide con el nombre y la fecha de nacimiento"
            erroresForm.MdiParent = Me.MdiParent
            erroresForm.Show()
        End If

        If validaRFC = False Then
            validarCampos = False
            erroresForm.mensaje = "El RFC capturado no coincide con el nombre y la fecha de nacimiento"
            erroresForm.MdiParent = Me.MdiParent
            erroresForm.Show()
        End If

        Return validarCampos
    End Function


    Public Sub GuardarColaborador()
        If validarCampos() Then

            Dim mensajeConfirmacion As New ConfirmarForm
            mensajeConfirmacion.mensaje = "¿Está seguro de guardar la información? Posteriormente no podrán realizarse cambios"

            If mensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim colaboradorExterno As New Entidades.ColaboradorExterno
                Dim objBu As New Negocios.ColaboradoresContabilidadBU
                Dim dtResul As New DataTable

                colaboradorExterno.PNombre = txtNombre.Text
                colaboradorExterno.PAPaterno = txtAPaterno.Text
                colaboradorExterno.PAMaterno = txtAMaterno.Text
                colaboradorExterno.PCalle = txtCalle.Text
                colaboradorExterno.PColonia = txtColonia.Text
                colaboradorExterno.PDomicilioNumero = txtNumero.Text
                colaboradorExterno.PCurp = txtCurp.Text
                colaboradorExterno.PRfc = txtRFC.Text
                colaboradorExterno.PFechaNacimiento = dtpNacimiento.Text.ToString
                colaboradorExterno.PEntreCalles = txtEntreCalles.Text
                colaboradorExterno.PReferencia = txtReferencias.Text
                colaboradorExterno.PSexo = cmbSexo.Text
                colaboradorExterno.PCP = txtcp.Text
                colaboradorExterno.PIdCiudadOrigen = CInt(cmbCiudadColaborador.SelectedValue)
                colaboradorExterno.PidNave = CInt(cmbNave.SelectedValue)
                colaboradorExterno.PIdPatron = CInt(cmbPatron.SelectedValue)
                colaboradorExterno.PIdPuesto = CInt(cmbPuesto.SelectedValue)
                colaboradorExterno.PSDI = CDbl(txtSDI.Text)
                colaboradorExterno.PIdPuestoReal = CInt(cmbPuestoReal.SelectedValue)
                colaboradorExterno.PIdDeptoFiscal = CInt(cmbDeptoFiscal.SelectedValue)
                colaboradorExterno.PIdDeptoReal = CInt(cmbDeptoReal.SelectedValue)
                colaboradorExterno.PNSS = txtNSS.Text
                colaboradorExterno.PObservaciones = txtObservaciones.Text
                colaboradorExterno.PObra = txtObra.Text
                colaboradorExterno.PGanaComision = CBool(rdoComisionSI.Checked)
                colaboradorExterno.PTipoSalario = CInt(cmbTipoSalario.SelectedValue)

                If rdoComisionSI.Checked Then
                    colaboradorExterno.PMontoComision = CDbl(numComision.Value)
                Else
                    colaboradorExterno.PMontoComision = 0.0
                End If


                If idColaborador <= 0 Then
                    If validaColaboradorExistente(txtCurp.Text, txtRFC.Text, txtNSS.Text) Then
                        dtResul = objBu.insertaColaboradorExterno(colaboradorExterno)

                        If dtResul.Rows.Count > 0 Then
                            If dtResul.Rows(0).Item("resul").ToString = "EXITO" Then
                                Dim exito As New ExitoForm
                                exito.mensaje = "Se ha guardado el colaborador correctamente"
                                exito.ShowDialog()
                                Me.Close()
                            Else
                                Dim advertencia As New AdvertenciaForm
                                advertencia.mensaje = "Algo surgió mal durante el proceso, favor de intentar nuevamente"
                                advertencia.ShowDialog()
                            End If
                        End If
                    End If


                Else
                    ''actualizar
                    colaboradorExterno.PIdColaborador = idColaborador
                    dtResul = objBu.editarColaboradorExterno(colaboradorExterno)
                    If dtResul.Rows.Count > 0 Then
                        If dtResul.Rows(0).Item("resul").ToString = "EXITO" Then
                            Dim exito As New ExitoForm
                            exito.mensaje = "Se han guardado los cambios correctamente"
                            exito.ShowDialog()
                        Else
                            Dim advertencia As New AdvertenciaForm
                            advertencia.mensaje = "Algo surgió mal durante el proceso, favor de intentar nuevamente"
                            advertencia.ShowDialog()
                        End If
                    End If
                End If

                'Me.Close()
            End If



        Else
            If validaCurp = True Or validaRFC = True Then
                Dim MensajeError As New AdvertenciaForm
                MensajeError.mensaje = "Falta información por llenar, los campos indicados con * son obligatorios. Favor de verifcar que la información sea correcta."
                MensajeError.ShowDialog()
            End If


        End If
    End Sub

    Public Sub cargarSalarioDiarioPuesto()
        Dim objBu As New Negocios.UtileriasBU
        Dim dtSDI As New DataTable
        Dim advertencia As New AdvertenciaForm
        Dim idPuestoReal As Int32 = 0

        idPuestoReal = cmbPuestoReal.SelectedValue

        If idPuestoReal <> 0 Then
            dtSDI = objBu.consultaSalarioDiarioPorPuesto(idPuestoReal)
            txtSDI.Text = 0
            If Not dtSDI Is Nothing Then
                If dtSDI.Rows.Count > 0 Then
                    txtSDI.Text = dtSDI.Rows(0).Item("sdi")
                End If
            Else
                advertencia.mensaje = "No existe un SDI para el puesto seleccionado. Favor de relacionarlo para poder guardar el  colaborador"
                advertencia.ShowDialog()
            End If
        End If

    End Sub


    Private Sub cmbEstadoOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstadoOrigen.SelectedIndexChanged
        If cmbEstadoOrigen.SelectedIndex > 0 Then
            cmbCiudadColaborador = Tools.Controles.ComboCiudadesMayusculas(cmbCiudadColaborador, cmbEstadoOrigen.SelectedValue)
        End If
    End Sub

    'Private Sub cmbPatron_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPatron.DropDownClosed
    '    If cmbPatron.SelectedIndex > 0 Or cmbPatron.Items.Count = 1 Then
    '        cargarComboPuestos()
    '    End If
    'End Sub

    'Private Sub cmbPatron_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPatron.SelectedIndexChanged
    '    If cmbPatron.SelectedIndex > 0 Or cmbPatron.Items.Count = 1 Then
    '        cargarComboPuestos()
    '    End If
    'End Sub



    Private Sub btnCalcularCurp_Click(sender As Object, e As EventArgs) Handles btnCalcularCurp.Click

        Try
            Dim startInfo As System.Diagnostics.ProcessStartInfo
            Dim pStart As New System.Diagnostics.Process
            startInfo = New System.Diagnostics.ProcessStartInfo("C:\SICY\CalcCURP.exe")

            pStart.StartInfo = startInfo
            pStart.Start()
            pStart.WaitForExit()
        Catch ex As Exception
            Dim mensajeA As New AdvertenciaForm
            mensajeA.mensaje = "No existe el archivo para el calculo del CURP"
            mensajeA.ShowDialog()
        End Try

    End Sub

    Private Sub btnCalcularRfc_Click(sender As Object, e As EventArgs) Handles btnCalcularRfc.Click

        Try
            Shell("C:\SICY\CalcRFC.exe", AppWinStyle.NormalFocus)
        Catch ex As Exception
            Dim mensajeA As New AdvertenciaForm
            mensajeA.mensaje = "No existe el archivo para el calculo del CURP"
            mensajeA.ShowDialog()
        End Try

    End Sub

    Private Sub btnBuscarNSS_Click(sender As Object, e As EventArgs) Handles btnBuscarNSS.Click
        System.Diagnostics.Process.Start("https://serviciosdigitales.imss.gob.mx")
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        GuardarColaborador()
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If Char.IsLower(e.KeyChar) Then
            txtNombre.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub txtAPaterno_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtAPaterno.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If Char.IsLower(e.KeyChar) Then
            txtAPaterno.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub txtAMaterno_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtAMaterno.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If Char.IsLower(e.KeyChar) Then
            txtAMaterno.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub



    Private Sub txtCurp_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtCurp.KeyPress
        'If Char.IsSymbol(e.KeyChar) Then
        '    e.Handled = False

        'End If
        'Dim caracteresPermitidos As String = "_-"
        'Dim c As Char = e.KeyChar

        'If txtCurp.Text.Length < 18 Then

        '    If caracteresPermitidos.Contains(c) Then

        '        e.Handled = True
        '    Else
        '        e.Handled = False

        '    End If
        'Else
        '    e.Handled = True
        'End If

        txtCurp.Text = txtCurp.Text.Replace("-", "")
        txtCurp.Text = txtCurp.Text.Replace(" ", "")


    End Sub

    Private Sub txtRFC_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtRFC.KeyPress
        If Char.IsSymbol(e.KeyChar) Then
            e.Handled = False

        End If

        If Char.IsLower(e.KeyChar) Then
            txtRFC.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
        txtRFC.Text = txtRFC.Text.Replace("-", "")
        txtRFC.Text = txtRFC.Text.Replace(" ", "")
    End Sub

    Private Sub txtCalle_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtCalle.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If Char.IsLower(e.KeyChar) Then
            txtCalle.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub txtColonia_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtColonia.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If Char.IsLower(e.KeyChar) Then
            txtColonia.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub txtEntreCalles_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtEntreCalles.KeyPress
        'If Char.IsLetter(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsSeparator(e.KeyChar) Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If

        If Char.IsLower(e.KeyChar) Then
            txtEntreCalles.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub txtReferencias_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtReferencias.KeyPress
        'If Char.IsLetter(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsSeparator(e.KeyChar) Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If

        If Char.IsLower(e.KeyChar) Then
            txtReferencias.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    'Private Sub cmbPuestoReal_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPuestoReal.DropDownClosed
    '    If cmbPuestoReal.SelectedIndex > 0 Or cmbPuestoReal.Items.Count = 1 Then
    '        cargarSalarioDiarioPuesto()
    '    End If

    'End Sub



    'Private Sub cmbPuesto_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPuesto.DropDownClosed
    '    If cmbPuesto.SelectedIndex > 0 Or cmbPuesto.Items.Count = 1 Then
    '        cargarComboPuestoReal()
    '    End If
    'End Sub



    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        If cmbNave.SelectedIndex > 0 Then
            Dim objBu As New Contabilidad.Negocios.UtileriasBU
            Dim dtEmpresa As New DataTable

            dtEmpresa = objBu.consultaPatronPorNave(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbNave.SelectedValue)
            If dtEmpresa.Rows.Count > 0 Then
                If dtEmpresa.Rows.Count = 1 Then
                    Dim dtRow As DataRow = dtEmpresa.NewRow
                    dtRow("ID") = 0
                    dtRow("PATRON") = ""
                    dtEmpresa.Rows.InsertAt(dtRow, 0)
                End If

                cmbPatron.DataSource = dtEmpresa
                cmbPatron.DisplayMember = "Patron"
                cmbPatron.ValueMember = "ID"

                If dtEmpresa.Rows.Count = 2 Then
                    cmbPatron.SelectedIndex = 1
                End If



            End If

            cargarDepartamentosReales()
        End If
    End Sub






    Private Sub cmbPatron_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPatron.SelectedIndexChanged
        If cmbPatron.SelectedIndex > 0 Then

            cargarComboPuestos()
            cargarDepartamentoFiscal()
        End If
    End Sub

    Private Sub cmbDeptoReal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDeptoReal.SelectedIndexChanged
        If cmbDeptoReal.SelectedIndex > 0 Then
            cargarComboPuestoReal()
        End If
    End Sub

    Private Sub cmbPuestoReal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPuestoReal.SelectedIndexChanged
        If cmbPuestoReal.SelectedIndex > 0 Then
            cargarSalarioDiarioPuesto()
        End If
    End Sub

    'Private Sub cmbPuesto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPuesto.SelectedIndexChanged
    '    If cmbPuesto.SelectedIndex > 0 Then
    '        cargarComboPuestoReal()
    '    End If
    'End Sub

    'Private Sub cmbDeptoFiscal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDeptoFiscal.SelectedIndexChanged
    '    If cmbDeptoFiscal.SelectedIndex > 0 Then
    '        cargarDepartamentosReales()
    '    End If
    'End Sub


    Private Sub txtCurp_LostFocus(sender As Object, e As EventArgs) Handles txtCurp.LostFocus
        txtCurp.Text = txtCurp.Text.Replace("-", "")
        txtCurp.Text = txtCurp.Text.Replace(" ", "")
        'If validaColaboradorExistente(txtCurp.Text, txtRFC.Text, txtNSS.Text) Then

        'End If
    End Sub

    Private Sub txtRFC_LostFocus(sender As Object, e As EventArgs) Handles txtRFC.LostFocus
        txtRFC.Text = txtRFC.Text.Replace("-", "")
        txtRFC.Text = txtRFC.Text.Replace(" ", "")
        'If validaColaboradorExistente(txtCurp.Text, txtRFC.Text, txtNSS.Text) Then

        'End If
    End Sub

    Public Function validaColaboradorExistente(ByVal curp As String, ByVal rfc As String, ByVal nss As String) As Boolean
        Dim objBu As New Negocios.ColaboradoresContabilidadBU
        Dim dtExiste As New DataTable
        Dim existe As Boolean = False
        Dim advertencia As New AdvertenciaForm

        dtExiste = objBu.validaColaboradorExistente(curp, rfc, nss)

        If dtExiste.Rows.Count > 0 Then
            existe = dtExiste.Rows(0).Item("existe")
            If existe = True Then
                advertencia.mensaje = dtExiste.Rows(0).Item("mensaje")
                advertencia.ShowDialog()
                validaColaboradorExistente = False
            Else
                validaColaboradorExistente = True
            End If
        End If

        Return validaColaboradorExistente
    End Function

    Private Sub rdoComisionSI_CheckedChanged(sender As Object, e As EventArgs) Handles rdoComisionSI.CheckedChanged, rdoComisionNO.CheckedChanged
        numComision.Enabled = rdoComisionSI.Checked

        If rdoComisionSI.Checked Then
            lblComision.Text = "*Max. Comisiones"
        Else
            lblComision.Text = "Max. Comisiones"
        End If

    End Sub
End Class