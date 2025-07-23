Imports Framework.Negocios
Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports System.IO
Imports System.Globalization

Public Class ListaModificacionSalarioForm
    Dim perfilContabilidad As Boolean = False

    Private pPatronId As Integer
    Public Property prPatronId() As Integer
        Get
            Return pPatronId
        End Get
        Set(ByVal value As Integer)
            pPatronId = value
        End Set
    End Property

    Private pEstatusId As Integer
    Public Property prEstatusId() As Integer
        Get
            Return pEstatusId
        End Get
        Set(ByVal value As Integer)
            pEstatusId = value
        End Set
    End Property

    Private pNaveId As Integer
    Public Property prNaveId() As Integer
        Get
            Return pNaveId
        End Get
        Set(ByVal value As Integer)
            pNaveId = value
        End Set
    End Property

    Private Sub ListaModificacionSalarioForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        llenarComboNave()
        'llenarComboEmpresa()
        llenarComboEstatus()
        configuracionPerfil()
        configuracionPermisosBotones()
        'cargarListado()

        If pNaveId <> 0 And cmbNave.Items.Count > 0 Then
            cmbNave.SelectedValue = pNaveId
            If pPatronId <> 0 And cmbEmpresa.Items.Count > 0 Then
                If pEstatusId <> 0 Then
                    cmbEstatus.SelectedValue = pEstatusId
                End If
                cmbEmpresa.SelectedValue = pPatronId
                cargarListado()
            End If
        End If
    End Sub

    Private Sub configuracionPermisosBotones()
        If perfilContabilidad Then
            If PermisosUsuarioBU.ConsultarPermiso("LIST_SOLMODSAL", "ALTA_MODSAL") Then
                pnlAltas.Visible = True
            Else
                pnlAltas.Visible = False
            End If

            If PermisosUsuarioBU.ConsultarPermiso("LIST_SOLMODSAL", "AUTORIZAR_MODSAL") Then
                pnlAutorizar.Visible = True
                pnlRechazar.Visible = True
            Else
                pnlAutorizar.Visible = False
                pnlRechazar.Visible = False
            End If

            If PermisosUsuarioBU.ConsultarPermiso("LIST_SOLMODSAL", "EDITAR_MODSAL") Then
                pnlEditar.Visible = True
            Else
                pnlEditar.Visible = False
            End If

            If PermisosUsuarioBU.ConsultarPermiso("LIST_SOLMODSAL", "GENERARTXT_MODSAL") Then
                pnlGenerarTxt.Visible = True
            Else
                pnlGenerarTxt.Visible = False
            End If

            If PermisosUsuarioBU.ConsultarPermiso("LIST_SOLMODSAL", "PDFACUSE_MODSAL") Then
                pnlPDFAcuse.Visible = True
            Else
                pnlPDFAcuse.Visible = False
            End If

            If PermisosUsuarioBU.ConsultarPermiso("LIST_SOLMODSAL", "REGRESAR_MODSAL") Then
                pnlRegresar.Visible = True
            Else
                pnlRegresar.Visible = False
            End If

        Else
            If PermisosUsuarioBU.ConsultarPermiso("LIST_SOLMODSALN", "ALTA_MODSALN") Then
                pnlAltas.Visible = True
            Else
                pnlAltas.Visible = False
            End If

            If PermisosUsuarioBU.ConsultarPermiso("LIST_SOLMODSALN", "AUTORIZAR_MODSALN") Then
                pnlAutorizar.Visible = True
                pnlRechazar.Visible = True
            Else
                pnlAutorizar.Visible = False
                pnlRechazar.Visible = False
            End If

            If PermisosUsuarioBU.ConsultarPermiso("LIST_SOLMODSALN", "EDITAR_MODSALN") Then
                pnlEditar.Visible = True
            Else
                pnlEditar.Visible = False
            End If

            If PermisosUsuarioBU.ConsultarPermiso("LIST_SOLMODSALN", "GENERARTXT_MODSALN") Then
                pnlGenerarTxt.Visible = True
            Else
                pnlGenerarTxt.Visible = False
            End If

            If PermisosUsuarioBU.ConsultarPermiso("LIST_SOLMODSALN", "PDFACUSE_MODSALN") Then
                pnlPDFAcuse.Visible = True
            Else
                pnlPDFAcuse.Visible = False
            End If

            If PermisosUsuarioBU.ConsultarPermiso("LIST_SOLMODSALN", "REGRESAR_MODSALN") Then
                pnlRegresar.Visible = True
            Else
                pnlRegresar.Visible = False
            End If
        End If
    End Sub

    Private Sub llenarComboNave()
        Tools.Controles.ComboNavesSegunUsuario(cmbNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
    End Sub

    Private Sub llenarComboEmpresa()
        Dim objBU As New Negocios.UtileriasBU
        Dim dtEmpresas As New DataTable

        dtEmpresas = objBU.consultarPatronEmpresa()
        If Not dtEmpresas Is Nothing Then
            If dtEmpresas.Rows.Count > 0 Then
                cmbEmpresa.DataSource = dtEmpresas
                cmbEmpresa.ValueMember = "ID"
                cmbEmpresa.DisplayMember = "PATRON"
                'cmbEmpresa.SelectedIndex = 1
            Else
                cmbEmpresa.DataSource = Nothing
            End If
        Else
            cmbEmpresa.DataSource = Nothing
        End If
    End Sub

    Private Sub llenarComboEstatus()
        Dim objBU As New Negocios.ModificacionSalarioBU
        Dim dtEstatus As New DataTable

        dtEstatus = objBU.obtenerEstatusModificacionSalario
        If Not dtEstatus Is Nothing Then
            If dtEstatus.Rows.Count > 0 Then
                cmbEstatus.DataSource = dtEstatus
                cmbEstatus.ValueMember = "esta_estatusid"
                cmbEstatus.DisplayMember = "esta_nombre"
            Else
                cmbEstatus.DataSource = Nothing
            End If
        Else
            cmbEstatus.DataSource = Nothing
        End If
    End Sub

    Private Sub configuracionPerfil()
        Try
            Dim objBU As New Negocios.UtileriasBU
            perfilContabilidad = objBU.validarPerfilContabilidad()
            If perfilContabilidad Then
                cmbEstatus.SelectedIndex = cmbEstatus.FindString("AUTORIZADO")
            Else
                cmbEstatus.SelectedIndex = cmbEstatus.FindString("SOLICITADO")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkPeriodo.CheckedChanged
        If chkPeriodo.Checked Then
            dtpFechaInicio.Enabled = True
            dtpFechaFin.Enabled = True
        Else
            dtpFechaInicio.Enabled = False
            dtpFechaFin.Enabled = False
        End If
    End Sub

    Private Sub cargarListado()
        Dim objMensajeError As New Tools.ErroresForm
        Try
            If validarFiltros() Then
                Dim objBu As New Negocios.ModificacionSalarioBU
                Dim dtListado As New DataTable

                Dim patronId As Integer = cmbEmpresa.SelectedValue
                Dim estatusId As Integer = cmbEstatus.SelectedValue
                Dim naveId As Integer = cmbNave.SelectedValue
                Dim nombre As String = txtNombre.Text
                Dim periodo As Boolean = chkPeriodo.Checked
                Dim fInicio As String = dtpFechaInicio.Value.ToShortDateString
                Dim fFin As String = dtpFechaFin.Value.ToShortDateString

                dtListado = objBu.consultarListaSolicitudesModificacionSalario(patronId, estatusId, naveId, nombre, periodo, fInicio, fFin)
                If dtListado.Rows.Count > 0 Then
                    grdListadoSolicitudes.DataSource = dtListado
                    disenioGrid()
                Else
                    grdListadoSolicitudes.DataSource = Nothing
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al cargar listado de solicitudes de modificacion de salario."
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Function validarFiltros() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbEmpresa.Items.Count > 1 And cmbEmpresa.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar una Empresa."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        End If

        If cmbEstatus.Items.Count > 1 And cmbEstatus.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar un Estatus."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        End If

        If chkPeriodo.Checked Then
            Dim entFechaInicio As Integer = 0
            Dim entFechaFin As Integer = 0
            entFechaInicio = CInt(dtpFechaInicio.Value.ToString("yyyyMMdd"))
            entFechaFin = CInt(dtpFechaFin.Value.ToString("yyyyMMdd"))

            If entFechaFin < entFechaInicio Then
                objMensajeAdv.mensaje = "La fecha inicial no puede ser mayor a la fecha final del filtro por periodo."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            End If
        End If

        Return True
    End Function

    Public Sub disenioGrid()
        With grdListadoSolicitudes.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
            .Columns("ColaboradorId").Hidden = True

            If cmbEstatus.Text <> "RECHAZADO" And cmbEstatus.Text <> "RECHAZADO IDSE" Then
                .Columns("Motivo Rechazo").Hidden = True
            Else
                .Columns("Motivo Rechazo").Hidden = False
            End If

            .Columns("#").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("A. Paterno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("A. Materno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Nombre(s)").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Nave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NSS").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Fecha Movimiento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Fecha Solicitud").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Salario Anterior").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Salario Nuevo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Excedente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Motivo Rechazo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("Selección").Header.VisiblePosition = 0
            .Columns("Selección").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Fecha Movimiento").Format = "dd/MM/yyyy"
            .Columns("Fecha Solicitud").Format = "dd/MM/yyyy H:mm"
            .Columns("Salario Anterior").Format = "$##,##0.00"
            .Columns("Salario Nuevo").Format = "$##,##0.00"
            .Columns("Excedente").Format = "$##,##0.00"

            .Columns("#").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Salario Anterior").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Salario Nuevo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Excedente").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            grdListadoSolicitudes.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            '.Columns("Selección").Width = 50
            '.Columns("#").Width = 25
            '.Columns("A. Paterno").Width = 250
            '.Columns("A. Materno").Width = 250
            '.Columns("Nombres(s)").Width = 250
            '.Columns("Nave").Width = 250
            '.Columns("NSS").Width = 250
            '.Columns("Fecha Movimiento").Width = 250
            '.Columns("Fecha Solicitud").Width = 250
            '.Columns("Salario Anterior").Width = 250
            '.Columns("Salario Nuevo").Width = 250
            .Columns("Motivo Rechazo").MaxWidth = 200

            .Columns("#").CharacterCasing = CharacterCasing.Upper
            .Columns("A. Paterno").CharacterCasing = CharacterCasing.Upper
            .Columns("A. Materno").CharacterCasing = CharacterCasing.Upper
            .Columns("Nombre(s)").CharacterCasing = CharacterCasing.Upper
            .Columns("Nave").CharacterCasing = CharacterCasing.Upper
            .Columns("NSS").CharacterCasing = CharacterCasing.Upper
            .Columns("Fecha Movimiento").CharacterCasing = CharacterCasing.Upper
            .Columns("Fecha Solicitud").CharacterCasing = CharacterCasing.Upper
            .Columns("Salario Anterior").CharacterCasing = CharacterCasing.Upper
            .Columns("Salario Nuevo").CharacterCasing = CharacterCasing.Upper
            .Columns("Excedente").CharacterCasing = CharacterCasing.Upper
            .Columns("Motivo Rechazo").CharacterCasing = CharacterCasing.Upper
        End With

        grdListadoSolicitudes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListadoSolicitudes.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdListadoSolicitudes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListadoSolicitudes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        'grdListadoSolicitudes.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        formatoColorFila()
    End Sub

    Private Sub formatoColorFila()
        Try
            For Each row As UltraGridRow In grdListadoSolicitudes.Rows
                If CDbl(row.Cells("Excedente").Value) > 0 Then
                    row.Appearance.ForeColor = Color.Red
                End If
                If row.Cells("Fecha Movimiento").Value = "01/01/1900" Then
                    row.Cells("Fecha Movimiento").Appearance.ForeColor = Color.Transparent
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click, lblMostrar.Click
        cargarListado()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarFiltros()
        cargarListado()
    End Sub

    Private Sub limpiarFiltros()
        cmbNave.SelectedValue = 0

        If cmbEmpresa.Items.Count > 1 Then
            cmbEmpresa.SelectedIndex = 1
        End If

        configuracionPerfil()
        txtNombre.Text = String.Empty
        dtpFechaInicio.Value = Now
        dtpFechaFin.Value = Now
        chkPeriodo.Checked = False
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click, lblAltas.Click
        abrirPantallaAltas()
    End Sub

    Private Sub abrirPantallaAltas()
        Dim objForm As New AltasSolicitudModSalarioForm
        If Not CheckForm(objForm) Then

            Dim formaAltas As New AltasSolicitudModSalarioForm
            formaAltas.ShowDialog()

            If formaAltas.guardado Then
                cargarListado()
            End If
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

    Private Function validarEstatus(ByVal opcEstatus As Int16, ByVal idsSolicitudes() As Integer) As Boolean
        Dim objBU As New Negocios.ModificacionSalarioBU
        Dim resultado As String = String.Empty

        For item As Integer = 0 To idsSolicitudes.Length - 1
            resultado = objBU.validarEstatus(idsSolicitudes(item), opcEstatus)
            If resultado <> "CORRECTO" Then
                Return False
                Exit Function
            End If
        Next

        Return True
    End Function

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click, lblAutorizar.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim idsSolicitudes() As Integer
        Dim contSeleccionadas As Integer = 0

        For Each row As UltraGridRow In grdListadoSolicitudes.Rows
            If row.Cells("Selección").Value Then
                ReDim Preserve idsSolicitudes(contSeleccionadas)
                idsSolicitudes(contSeleccionadas) = row.Cells("ID").Value
                contSeleccionadas += 1
            End If
        Next

        If contSeleccionadas > 0 Then
            If validarEstatus(1, idsSolicitudes) Then
                Dim objMensajeConf As New Tools.ConfirmarForm
                objMensajeConf.mensaje = "¿Está seguro de autorizar los " & contSeleccionadas & " registros seleccionados?"

                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim objBU As New Negocios.ModificacionSalarioBU
                    Dim resultado As String = String.Empty
                    Dim contAutorizadas As Integer = 0

                    Try
                        For item As Integer = 0 To idsSolicitudes.Length - 1
                            Dim credinfonavit As New Entidades.CreditoInfonavit
                            Try
                                credinfonavit = obtenerCreditoInfonavit(idsSolicitudes(item))

                                If Not credinfonavit Is Nothing Then
                                    resultado = objBU.cambiarEstatus(idsSolicitudes(item), 1, "", credinfonavit.CIDescuentosemanal.ToString("N2"), credinfonavit.CIRetenciondiaria.ToString("N2"))

                                    If resultado = "EXITO" Then
                                        contAutorizadas += 1
                                    End If
                                Else
                                    resultado = "ERROR"
                                End If
                            Catch ex As Exception
                                resultado = "ERROR"
                            End Try
                        Next

                        If contSeleccionadas = contAutorizadas Then
                            objMensajeExito.mensaje = "Solicitudes Autorizadas correctamente."
                            objMensajeExito.ShowDialog()
                            cargarListado()
                        ElseIf contAutorizadas = 0 Then
                            objMensajeError.mensaje = "Error no se pudieron autorizar las solicitudes."
                            objMensajeError.ShowDialog()
                        ElseIf contSeleccionadas > contAutorizadas Then
                            objMensajeError.mensaje = "Algunas solicitudes seleccionadas no se pudieron autorizar, el listado se actualizará favor de intentarlo nuevamente."
                            objMensajeError.ShowDialog()
                            cargarListado()
                        End If
                    Catch ex As Exception
                        objMensajeError.mensaje = "Error al autorizar solicitudes."
                        objMensajeError.ShowDialog()
                    End Try
                End If
            Else
                objMensajeAdv.mensaje = "Las solicitudes deben de estar en estatus SOLICITADO o REGRESADO para Autorizarlas."
                objMensajeAdv.ShowDialog()
            End If
        Else
            objMensajeAdv.mensaje = "Favor de selecionar al menos un registro."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Function obtenerCreditoInfonavit(ByVal solicitudId As Integer) As Entidades.CreditoInfonavit
        Dim credinfonavit As New Entidades.CreditoInfonavit

        Try
            Dim objBu As New Negocios.ModificacionSalarioBU
            Dim modSalario As New Entidades.ModificacionSalario

            modSalario = objBu.consultarSolicitudModificacionSalario(solicitudId)
            If Not modSalario Is Nothing Then
                If modSalario.MDNumCreditoInfonavit <> "" Then
                    Dim objCalcInfonavit As New CalculoInfonavit
                    Dim fechaMovimiento As String = objBu.obtenerFechaMovimiento(modSalario.MDPatronId)

                    If fechaMovimiento <> "" Then
                        credinfonavit = objCalcInfonavit.calcularDescuentoPorcentaje(modSalario.MDSalarioNuevo, modSalario.MDvalorDescuentoInfonavit, modSalario.MDPatronId, fechaMovimiento)
                    Else
                        Return Nothing
                    End If
                Else
                    credinfonavit.CIRetenciondiaria = 0
                    credinfonavit.CIDescuentosemanal = 0
                End If
            Else
                Return Nothing
            End If

            Return credinfonavit
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click, lblRechazar.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim idsSolicitudes() As Integer
        Dim contSeleccionadas As Integer = 0

        For Each row As UltraGridRow In grdListadoSolicitudes.Rows
            If row.Cells("Selección").Value Then
                ReDim Preserve idsSolicitudes(contSeleccionadas)
                idsSolicitudes(contSeleccionadas) = row.Cells("ID").Value
                contSeleccionadas += 1
            End If
        Next

        If contSeleccionadas > 0 Then
            If validarEstatus(1, idsSolicitudes) Then
                Dim objMensajeConf As New Tools.ConfirmarForm
                objMensajeConf.mensaje = "¿Está seguro de rechazar los " & contSeleccionadas & " registros seleccionados?"

                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim objBU As New Negocios.ModificacionSalarioBU
                    Dim resultado As String = String.Empty
                    Dim motivoRechazo As String = String.Empty
                    Dim contRechazadas As Integer = 0
                    Dim formMotivo As New MotivoRechazoForm

                    If Not CheckForm(formMotivo) Then
                        formMotivo.ShowDialog()

                        If formMotivo.motivo <> "" Then
                            motivoRechazo = formMotivo.motivo
                        Else
                            objMensajeAdv.mensaje = "No se rechazaron las solicitudes debido a que no se ingresó el motivo de rechazo."
                            objMensajeAdv.ShowDialog()
                            Exit Sub
                        End If
                    End If


                    Try
                        For item As Integer = 0 To idsSolicitudes.Length - 1
                            resultado = objBU.cambiarEstatus(idsSolicitudes(item), 2, motivoRechazo, 0, 0)

                            If resultado = "EXITO" Then
                                contRechazadas += 1
                            End If
                        Next

                        If contSeleccionadas = contRechazadas Then
                            objMensajeExito.mensaje = "Solicitudes Rechazadas correctamente."
                            objMensajeExito.ShowDialog()
                            cargarListado()
                        ElseIf contRechazadas = 0 Then
                            objMensajeError.mensaje = "Error no se pudieron rechazar las solicitudes."
                            objMensajeError.ShowDialog()
                        ElseIf contSeleccionadas > contRechazadas Then
                            objMensajeError.mensaje = "Algunas solicitudes seleccionadas no se pudieron rechazar, el listado se actualizará favor de intentarlo nuevamente."
                            objMensajeError.ShowDialog()
                            cargarListado()
                        End If
                    Catch ex As Exception
                        objMensajeError.mensaje = "Error al Rechazar solicitudes."
                        objMensajeError.ShowDialog()
                    End Try
                End If
            Else
                objMensajeAdv.mensaje = "Las solicitudes deben de estar en estatus SOLICITADO o REGRESADO para Rechazarlas."
                objMensajeAdv.ShowDialog()
            End If
        Else
            objMensajeAdv.mensaje = "Favor de selecionar al menos un registro."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click, lblRegresar.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim idsSolicitudes() As Integer
        Dim contSeleccionadas As Integer = 0

        For Each row As UltraGridRow In grdListadoSolicitudes.Rows
            If row.Cells("Selección").Value Then
                ReDim Preserve idsSolicitudes(contSeleccionadas)
                idsSolicitudes(contSeleccionadas) = row.Cells("ID").Value
                contSeleccionadas += 1
            End If
        Next

        If contSeleccionadas > 0 Then
            If validarEstatus(2, idsSolicitudes) Then
                Dim objMensajeConf As New Tools.ConfirmarForm
                objMensajeConf.mensaje = "¿Está seguro de regresar los " & contSeleccionadas & " registros seleccionados?"

                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim objBU As New Negocios.ModificacionSalarioBU
                    Dim resultado As String = String.Empty
                    Dim motivoRechazo As String = String.Empty
                    Dim contRegresadas As Integer = 0
                    Dim formMotivo As New MotivoRechazoForm

                    If Not CheckForm(formMotivo) Then
                        formMotivo.ShowDialog()

                        If formMotivo.motivo <> "" Then
                            motivoRechazo = formMotivo.motivo
                        Else
                            objMensajeAdv.mensaje = "No se regresaron las solicitudes debido a que no se ingresó el motivo de regreso."
                            objMensajeAdv.ShowDialog()
                            Exit Sub
                        End If
                    End If


                    Try
                        For item As Integer = 0 To idsSolicitudes.Length - 1
                            resultado = objBU.cambiarEstatus(idsSolicitudes(item), 3, motivoRechazo, 0, 0)

                            If resultado = "EXITO" Then
                                contRegresadas += 1
                            End If
                        Next

                        If contSeleccionadas = contRegresadas Then
                            objMensajeExito.mensaje = "Solicitudes Regresadas correctamente."
                            objMensajeExito.ShowDialog()
                            cargarListado()
                        ElseIf contRegresadas = 0 Then
                            objMensajeError.mensaje = "Error no se pudieron regresar las solicitudes."
                            objMensajeError.ShowDialog()
                        ElseIf contSeleccionadas > contRegresadas Then
                            objMensajeError.mensaje = "Algunas solicitudes seleccionadas no se pudieron regresar, el listado se actualizará favor de intentarlo nuevamente."
                            objMensajeError.ShowDialog()
                            cargarListado()
                        End If
                    Catch ex As Exception
                        objMensajeError.mensaje = "Error al regresar solicitudes."
                        objMensajeError.ShowDialog()
                    End Try
                End If
            Else
                objMensajeAdv.mensaje = "Las solicitudes deben de estar en estatus AUTORIZADO o RECHAZADO para Regresarlas."
                If perfilContabilidad Then
                    objMensajeAdv.mensaje = objMensajeAdv.mensaje & " Las solicitudes dadas de alta por contabilidad no puede ser Regresadas."
                End If
                objMensajeAdv.ShowDialog()
            End If
        Else
            objMensajeAdv.mensaje = "Favor de selecionar al menos un registro."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click, lblEditar.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim contSeleccionadas As Integer = 0
        Dim solicitudId As Integer = 0

        For Each row As UltraGridRow In grdListadoSolicitudes.Rows
            If row.Cells("Selección").Value Then
                contSeleccionadas += 1
                solicitudId = row.Cells("ID").Value
            End If
        Next

        If contSeleccionadas = 0 Then
            objMensajeAdv.mensaje = "Favor de selecionar un registro."
            objMensajeAdv.ShowDialog()
        ElseIf contSeleccionadas > 1 Then
            objMensajeAdv.mensaje = "Favor de selecionar solo un registro."
            objMensajeAdv.ShowDialog()
        Else
            Dim idsSolicitud(0) As Integer
            idsSolicitud(0) = solicitudId
            If validarEstatus(3, idsSolicitud) Then
                Dim objForm As New AltasSolicitudModSalarioForm
                If Not CheckForm(objForm) Then

                    Dim formaAltas As New AltasSolicitudModSalarioForm
                    formaAltas.editar = True
                    formaAltas.lblModificacionSalarioId.Text = solicitudId
                    formaAltas.ShowDialog()

                    If formaAltas.guardado Then
                        cargarListado()
                    End If
                End If
            Else
                objMensajeAdv.mensaje = "La solicitud debe de estar en estatus AUTORIZADO o RECHAZADO IDSE para Editarla."
                objMensajeAdv.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnGenerarTxt_Click(sender As Object, e As EventArgs) Handles btnGenerarTxt.Click, lblGenerarTxt.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm

        Dim contSeleccionadas As Integer = 0
        Dim idsSolicitudes() As Integer
        Dim solicitudIdsCE As String = String.Empty

        For Each row As UltraGridRow In grdListadoSolicitudes.Rows
            If row.Cells("Selección").Value Then
                ReDim Preserve idsSolicitudes(contSeleccionadas)
                idsSolicitudes(contSeleccionadas) = row.Cells("ID").Value
                solicitudIdsCE &= "(" & row.Cells("ID").Value & "),"
                contSeleccionadas += 1
            End If
        Next

        If contSeleccionadas > 0 Then
            If validarEstatus(3, idsSolicitudes) Then
                Dim objBU As New Negocios.ModificacionSalarioBU
                Dim lstInformacionIdse As New List(Of Entidades.InformacionIDSE_SUA)
                Dim contExiste As Integer = 0
                Dim archivoTXT As String = String.Empty
                Dim reemplazar As Boolean = True
                Dim contGeneradas As Integer = 0
                Dim fecha As String = Date.Now.ToString("ddMMyyyHmm")
                Dim mes As String = Date.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-MX"))


                'Para borrar
                'Dim sinResultado As Boolean = False
                'Dim contSinResultado As Integer = 0
                'Dim archivoCreado As Boolean = False
                'Dim informacionIdse As New Entidades.InformacionIDSE_SUA

                Try
                    solicitudIdsCE = solicitudIdsCE.Substring(0, solicitudIdsCE.Length - 1)
                    lstInformacionIdse = objBU.consultarInformacionIDSE(solicitudIdsCE)

                    If Not lstInformacionIdse Is Nothing Then
                        If contSeleccionadas = lstInformacionIdse.Count Then
                            For item As Integer = 0 To lstInformacionIdse.Count - 1
                                archivoTXT = lstInformacionIdse(item).IIRutaDescarga & "movtoSalIDSE_" & lstInformacionIdse(item).IINumeroSeguroSocial & "_" & lstInformacionIdse(item).IITablaId & ".dat"
                                If existeArchivo(archivoTXT) Then
                                    lstInformacionIdse(item).IIExiste = True
                                    contExiste += 1
                                End If
                            Next

                            If contExiste > 0 Then
                                Dim objMensajeConf As New Tools.ConfirmarForm
                                objMensajeConf.mensaje = "Ya existen archivos para " & contExiste & " de los registros seleccionados. ¿Desea reemplazarlos?"

                                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                                    reemplazar = True
                                Else
                                    reemplazar = False
                                End If
                            End If

                            For item As Integer = 0 To lstInformacionIdse.Count - 1
                                If Not lstInformacionIdse(item).IIExiste Or reemplazar Then
                                    If generarTxtIdse(lstInformacionIdse(item)) Then
                                        contGeneradas += 1
                                    End If
                                End If
                            Next

                            If contSeleccionadas = contGeneradas Then
                                If generarTxtSua(lstInformacionIdse, fecha) Then
                                    objMensajeExito.mensaje = "Los archivos se generaron correctamente."
                                    objMensajeExito.ShowDialog()
                                Else
                                    objMensajeAdv.mensaje = "El archivo para el SUA no se generó, favor de volverlo a intentar."
                                    objMensajeAdv.ShowDialog()
                                End If
                            Else
                                objMensajeAdv.mensaje = "El archivo para el SUA no se generó, favor de volverlo a intentar."
                                objMensajeAdv.ShowDialog()
                            End If
                        Else
                            objMensajeAdv.mensaje = "No se pueden generar los archivos TXT debido información incorrecta de algunos colaboradores, favor de verificar."
                            objMensajeAdv.ShowDialog()
                        End If
                    Else
                        objMensajeAdv.mensaje = "No se pueden generar los archivos TXT debido información incorrecta de los colaboradores, favor de verificar."
                        objMensajeAdv.ShowDialog()
                    End If

                    '    If contSeleccionadas = contGeneradas And archivoCreado Then
                    '        objMensajeExito.mensaje = "Los archivos se generaron correctamente."
                    '        objMensajeExito.ShowDialog()
                    '        'ElseIf If contSeleccionadas = contGeneradas And archivoCreado Then
                    '    ElseIf contGeneradas = 0 And Not sinResultado Then
                    '        objMensajeAdv.mensaje = "No se pudieron generar los TXT's de las solicitudes."
                    '        objMensajeAdv.ShowDialog()
                    '    ElseIf contGeneradas = 0 And sinResultado Then
                    '        objMensajeAdv.mensaje = "No se pudieron generar los TXT's de las solicitudes."
                    '        objMensajeAdv.ShowDialog()
                    '    ElseIf contSeleccionadas > contGeneradas And contGeneradas <> 0 Then
                    '        objMensajeAdv.mensaje = "No se pudo generar los TXT's de algunas solicitudes seleccionadas, favor de revisar los datos."
                    '        objMensajeAdv.ShowDialog()
                    '    End If
                Catch ex As Exception
                    objMensajeError.mensaje = "Error al generar TXT's de las solicitudes."
                    objMensajeError.ShowDialog()
                End Try
            Else
                objMensajeAdv.mensaje = "Las solicitudes deben de estar en estatus AUTORIZADO o RECHAZADO IDSE para Generar los TXT's."
                objMensajeAdv.ShowDialog()
            End If
        Else
            objMensajeAdv.mensaje = "Favor de selecionar al menos un registro."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Function generarTxtIdse(ByVal infoIdse As Entidades.InformacionIDSE_SUA) As Boolean
        Try
            Dim archivoTXT As String = String.Empty
            Dim informacion As String = String.Empty

            'archivoTXT = infoIdse.IIRutaDescarga & "movtoSalIDSE_" & infoIdse.IINumeroSeguroSocial & "_" & fecha & ".dat"
            archivoTXT = infoIdse.IIRutaDescarga & "movtoSalIDSE_" & infoIdse.IINumeroSeguroSocial & "_" & infoIdse.IITablaId & ".dat"
            If Not existeCarpeta(IO.Path.GetDirectoryName(archivoTXT)) Then
                crearCarpeta(IO.Path.GetDirectoryName(archivoTXT))
            End If

            informacion = infoIdse.IIRegistroPatronal
            informacion &= infoIdse.IINumeroSeguroSocial
            informacion &= infoIdse.IIAPaterno
            informacion &= infoIdse.IIAMaterno
            informacion &= infoIdse.IINombre
            informacion &= infoIdse.IISalarioDiario
            informacion &= "      " 'Filler
            informacion &= " " 'Filler
            informacion &= infoIdse.IIClaveTipoSalario
            informacion &= infoIdse.IIClaveTipoJornada
            informacion &= infoIdse.IIFechaMovimiento
            informacion &= "     " 'Filler
            informacion &= infoIdse.IIClaveMovimiento
            informacion &= guia
            informacion &= infoIdse.IIClaveTrabajador
            informacion &= " " 'Filler
            informacion &= infoIdse.IICurp
            informacion &= infoIdse.IIIdentificador

            'Pie del archivo
            informacion &= vbCrLf
            informacion &= "*************                                           "
            informacion &= "000001                                                                       "
            informacion &= guia
            informacion &= "                             "
            informacion &= infoIdse.IIIdentificador


            File.WriteAllText(archivoTXT, informacion.ToUpper)
            Return existeArchivo(archivoTXT)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function generarTxtSua(ByVal infoIdse As List(Of Entidades.InformacionIDSE_SUA), ByVal fecha As String) As Boolean
        Dim archivoTXT As String = String.Empty
        Dim informacion As String = String.Empty

        archivoTXT = infoIdse(0).IIRutaDescarga & "movtoSalSUA_" & fecha & ".txt"
        If Not existeCarpeta(IO.Path.GetDirectoryName(archivoTXT)) Then
            crearCarpeta(IO.Path.GetDirectoryName(archivoTXT))
        End If

        For i As Integer = 0 To infoIdse.Count - 1
            informacion &= infoIdse(i).IIRegistroPatronal
            informacion &= infoIdse(i).IINumeroSeguroSocial
            informacion &= infoIdse(i).IIClaveMovimiento
            informacion &= infoIdse(i).IIFechaMovimiento
            informacion &= "00000000" 'Espacio para Folio incapacidad (NO APLICA)
            informacion &= "00" 'Espacio para Dias de incidencia (NO APLICA)
            informacion &= "0" & infoIdse(i).IISalarioDiario
            informacion &= vbCrLf
        Next

        File.WriteAllText(archivoTXT, informacion.ToUpper)
        Return existeArchivo(archivoTXT)
    End Function

    Private Sub btnPDFAcuse_Click(sender As Object, e As EventArgs) Handles btnPDFAcuse.Click, lblPDFAcuse.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim contSeleccionadas As Integer = 0
        Dim solicitudId As Integer = 0
        Dim colaboradorId As Integer = 0

        For Each row As UltraGridRow In grdListadoSolicitudes.Rows
            If row.Cells("Selección").Value Then
                contSeleccionadas += 1
                solicitudId = row.Cells("ID").Value
                colaboradorId = row.Cells("ColaboradorId").Value
            End If
        Next

        If contSeleccionadas = 0 Then
            objMensajeAdv.mensaje = "Favor de selecionar un registro."
            objMensajeAdv.ShowDialog()
        ElseIf contSeleccionadas > 1 Then
            objMensajeAdv.mensaje = "Favor de selecionar solo un registro."
            objMensajeAdv.ShowDialog()
        Else
            Dim idsSolicitud(0) As Integer
            idsSolicitud(0) = solicitudId
            If validarEstatus(3, idsSolicitud) Then
                Dim objForm As New ModSalarioPDFAcuseForm
                If Not CheckForm(objForm) Then

                    Dim formaSubirPdf As New ModSalarioPDFAcuseForm
                    formaSubirPdf.solicitudId = solicitudId
                    formaSubirPdf.colaboradorId = colaboradorId
                    formaSubirPdf.ShowDialog()

                    If formaSubirPdf.guardado Then
                        cargarListado()
                    End If
                End If
            Else
                objMensajeAdv.mensaje = "La solicitudes debe de estar en estatus AUTORIZADO o REGRESADO IDSE para subir el PDF de Acuse."
                objMensajeAdv.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbFiltros.Height = 43
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbFiltros.Height = 114
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        cmbEmpresa.DataSource = Nothing
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

                cmbEmpresa.DataSource = dtEmpresa
                cmbEmpresa.DisplayMember = "Patron"
                cmbEmpresa.ValueMember = "ID"

                If dtEmpresa.Rows.Count = 2 Then
                    cmbEmpresa.SelectedIndex = 1
                End If
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class