Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Windows.Forms
Imports System.Drawing
Imports Framework.Negocios
Imports Tools

Public Class ListaComisionesMensualesForm
    Dim colaboradorIds As String = String.Empty
    Private Sub ConsultaComisionesMensualesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        llenarComboEmpresa()
        llenarComboEstatus()
        validaPermisos()
    End Sub
    Private Sub validaPermisos()

        pnlAltas.Visible = PermisosUsuarioBU.ConsultarPermiso("CAPTURA_COMISION_MENSUAL", "CAPTURA_COM_MNF")
        pnlEditar.Visible = PermisosUsuarioBU.ConsultarPermiso("CAPTURA_COMISION_MENSUAL", "MODIF_COM_MNF")
        pnlCancelar.Visible = PermisosUsuarioBU.ConsultarPermiso("CAPTURA_COMISION_MENSUAL", "CANCEL_COM_MNF")

        'Permisos menú 
        ComisionesMensualesArchivoWordToolStripMenuItem.Visible = PermisosUsuarioBU.ConsultarPermiso("CAPTURA_COMISION_MENSUAL", "MODIF_WORD_COM_MNF")
        ComisionesMensualesPropuestaToolStripMenuItem.Visible = PermisosUsuarioBU.ConsultarPermiso("CAPTURA_COMISION_MENSUAL", "PROPUESTA_COM_MNF")
        'ToolStripMenuItem 

    End Sub
    Private Sub llenarComboEmpresa()
        Dim objBU As New Negocios.UtileriasBU
        Dim dtEmpresas As New DataTable

        dtEmpresas = objBU.consultarPatronEmpresaComisiones()
        If Not dtEmpresas Is Nothing Then
            If dtEmpresas.Rows.Count > 0 Then
                cmbEmpresa.DataSource = dtEmpresas
                cmbEmpresa.ValueMember = "ID"
                cmbEmpresa.DisplayMember = "PATRON"
            Else
                cmbEmpresa.DataSource = Nothing
            End If
        Else
            cmbEmpresa.DataSource = Nothing
        End If
    End Sub

    Private Sub llenarComboEstatus()
        Dim objBU As New Negocios.ComisionesBU
        Dim dtEstatus As New DataTable

        dtEstatus = objBU.obtenerEstatusComisiones()
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        cargarListado()
    End Sub
    Private Sub cargarListado()
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        grdComisiones.DataSource = Nothing
        Try
            If validarFiltros() Then
                Dim objBU As New Negocios.ComisionesBU
                Dim dtListado As New DataTable
                Dim dtTotales As New DataTable
                Dim patronId As Integer = cmbEmpresa.SelectedValue
                Dim periodoId As Integer = cmbPeriodo.SelectedValue
                Dim rango As Boolean = rdoRango.Checked
                Dim fechaInicio As Date = dtpFechaInicio.Value.ToShortDateString
                Dim fechaFin As Date = dtpFechaFin.Value.ToShortDateString
                Dim estatus As Integer = cmbEstatus.SelectedValue

                dtListado = objBU.consultarComisionesMensuales(patronId, periodoId, rango, fechaInicio, fechaFin, colaboradorIds, estatus)
                If Not dtListado Is Nothing Then
                    If dtListado.Rows.Count > 0 Then

                        grdComisiones.DataSource = dtListado
                        estiloGrdComisionesConsulta()

                    Else
                        objMensajeAdv.mensaje = "La consulta no devolvió ningún resultado"
                        objMensajeAdv.Show()
                    End If
                Else
                    objMensajeAdv.mensaje = "La consulta no devolvió ningún resultado"
                    objMensajeAdv.Show()
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al cargar listado de recibos nómina."
            objMensajeError.Show()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Function validarFiltros() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbEmpresa.Items.Count > 1 And cmbEmpresa.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar un Patrón."
            objMensajeAdv.Show()
            Return False
        End If

        If rdoPeriodo.Checked Then
            If cmbPeriodo.Items.Count > 1 And cmbPeriodo.SelectedIndex = 0 Then
                objMensajeAdv.mensaje = "Favor de seleccionar un Periodo de Nómina."
                objMensajeAdv.Show()
                Return False
            End If
        ElseIf rdoRango.Checked Then
            Dim entFechaInicio As Integer = 0
            Dim entFechaFin As Integer = 0
            entFechaInicio = CInt(dtpFechaInicio.Value.ToString("yyyyMMdd"))
            entFechaFin = CInt(dtpFechaFin.Value.ToString("yyyyMMdd"))

            If entFechaFin < entFechaInicio Then
                objMensajeAdv.mensaje = "La fecha inicial no puede ser mayor a la fecha final del filtro por periodo."
                objMensajeAdv.Show()
                Return False
                Exit Function
            End If
        End If

        Return True
    End Function

    Private Sub estiloGrdComisionesConsulta()

        grdComisiones.DisplayLayout.UseFixedHeaders = True
        grdComisiones.DisplayLayout.Bands(0).Columns("Clave").Header.Fixed = True
        grdComisiones.DisplayLayout.Bands(0).Columns("Colaborador").Header.Fixed = True
        grdComisiones.DisplayLayout.Bands(0).Columns("SDI").Header.Fixed = True
        grdComisiones.DisplayLayout.Bands(0).Override.FixedHeaderIndicator = FixedHeaderIndicator.None

        grdComisiones.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        'grdComisiones.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdComisiones.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grdComisiones.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdComisiones.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdComisiones.DisplayLayout.Override.RowSelectorWidth = 35
        grdComisiones.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        grdComisiones.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
        grdComisiones.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True

        With grdComisiones.DisplayLayout.Bands(0)
            .Override.CellClickAction = CellClickAction.CellSelect

            .Columns("cmnf_comisionid").Hidden = True
            .Columns("codr_colaboradorid").Hidden = True
            .Columns("penof_periodonominafiscalId").Hidden = True
            .Columns("cmnf_limitecomisionpatron").Hidden = True
            .Columns("cmnf_estatus").Hidden = True

            .Columns("cmnf_montocomision").Header.Caption = "Comisión"
            .Columns("cmnf_maxcomisioncolaborador").Header.Caption = "Máx. Comisión (Colaborador)"
            '.Columns("cmnf_limitecomisionpatron").Header.Caption = "Límite Comisión (Patrón)"
            .Columns("penof_descripcion").Header.Caption = "Periodo Aplicación"
            .Columns("cmnf_fechacreacion").Header.Caption = "Fecha Captura"
            .Columns("usuariocreo").Header.Caption = "Usuario Captura"
            .Columns("cmnf_fechamodificacion").Header.Caption = "Fecha Modficación"
            .Columns("usuariomodifico").Header.Caption = "Usuario Modificó"
            .Columns("Anio").Header.Caption = "Año"
            .Columns("estatus").Header.Caption = "Estatus Comisión"

            '.Columns("Clave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("Colaborador").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("SDI").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("cmnf_maxcomisioncolaborador").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("cmnf_limitecomisionpatron").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("penof_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("cmnf_fechacreacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("usuariocreo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("cmnf_fechamodificacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("usuariomodifico").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("cmnf_montocomision").CellActivation = Activation.NoEdit
            '.Columns("Mes").CellActivation = Activation.NoEdit
            '.Columns("Anio").CellActivation = Activation.NoEdit

            '.Columns("NumeroPago").CellAppearance.TextHAlign = HAlign.Center       
            .Columns("SDI").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Mes").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Anio").CellAppearance.TextHAlign = HAlign.Right
            .Columns("cmnf_montocomision").CellAppearance.TextHAlign = HAlign.Right
            .Columns("cmnf_maxcomisioncolaborador").CellAppearance.TextHAlign = HAlign.Right
            '.Columns("cmnf_limitecomisionpatron").CellAppearance.TextHAlign = HAlign.Right


            .Columns("cmnf_montocomision").Format = "##,##0.00" '"##,##0.00"
            .Columns("cmnf_maxcomisioncolaborador").Format = "##,##0.00" '"##,##0.00"
            '.Columns("cmnf_limitecomisionpatron").Format = "$##,##0.00" '"##,##0.00"
            .Columns("SDI").Format = "##,##0.00"
            .Columns("cmnf_fechacreacion").Format = "dd/MM/yyyy HH:mm:ss"
            .Columns("cmnf_fechamodificacion").Format = "dd/MM/yyyy HH:mm:ss"

            .Columns("Clave").Width = 60
            .Columns("Colaborador").Width = 300
            .Columns("SDI").Width = 70
            .Columns("cmnf_maxcomisioncolaborador").Width = 100
            '.Columns("cmnf_limitecomisionpatron").Width = 75
            .Columns("penof_descripcion").Width = 390
            .Columns("cmnf_fechacreacion").Width = 115
            .Columns("usuariocreo").Width = 95
            .Columns("cmnf_fechamodificacion").Width = 115
            .Columns("usuariomodifico").Width = 95
            .Columns("cmnf_montocomision").Width = 75
            .Columns("Mes").Width = 40
            .Columns("Anio").Width = 60
            .Columns("estatus").Width = 90

        End With


        Dim summary1 As SummarySettings
        summary1 = grdComisiones.DisplayLayout.Bands(0).Summaries.Add("Total", SummaryType.Sum, grdComisiones.DisplayLayout.Bands(0).Columns("cmnf_montocomision"))
        grdComisiones.DisplayLayout.Bands(0).SummaryFooterCaption = "Total"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right

        Me.grdComisiones.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdComisiones.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        grdComisiones.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti

        For Each row As UltraGridRow In grdComisiones.Rows
            Select Case row.Cells("estatus").Value
                Case "CANCELADA"
                    row.Appearance.ForeColor = Color.Red
                Case Else
                    row.Appearance.ForeColor = Color.Black
            End Select
        Next

    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbFiltros.Visible = False
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbFiltros.Visible = True
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnSeleccionarColaborador_Click(sender As Object, e As EventArgs) Handles btnSeleccionarColaborador.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbEmpresa.Items.Count > 1 And cmbEmpresa.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar una Empresa."
            objMensajeAdv.ShowDialog()
        Else
            Dim objForm As New SeleccionarColaboradoresForm
            If Not CheckForm(objForm) Then
                objForm.colaboradorIds = colaboradorIds
                objForm.patronId = cmbEmpresa.SelectedValue
                objForm.ShowDialog()
                colaboradorIds = String.Empty
                colaboradorIds = objForm.colaboradorIds

                If colaboradorIds <> "" Then
                    pnlArchivoCargado.Visible = True
                Else
                    pnlArchivoCargado.Visible = False
                End If
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

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarFiltros()
    End Sub
    Private Sub limpiarFiltros()
        cmbEmpresa.SelectedIndex = 0
        grdComisiones.DataSource = Nothing

    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub rdoRango_CheckedChanged(sender As Object, e As EventArgs) Handles rdoRango.CheckedChanged, rdoPeriodo.CheckedChanged
        cmbPeriodo.Enabled = rdoPeriodo.Checked
        dtpFechaInicio.Enabled = rdoRango.Checked
        dtpFechaFin.Enabled = rdoRango.Checked

        If rdoRango.Checked Then
            If cmbPeriodo.Items.Count > 0 Then
                cmbPeriodo.SelectedIndex = 0
            End If
        End If

    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        grdComisiones.DataSource = Nothing
        colaboradorIds = String.Empty
        pnlArchivoCargado.Visible = False

        llenarComboPeriodo()
    End Sub
    Private Sub llenarComboPeriodo()
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Try
            cmbPeriodo.DataSource = Nothing
            If cmbEmpresa.SelectedIndex > 0 Or cmbEmpresa.Items.Count = 1 And IsNumeric(cmbEmpresa.SelectedValue) Then
                Dim objBU As New Negocios.ControlAsistenciaBU
                Dim dtListado As New DataTable

                dtListado = objBU.consultarPeriodoNomina(CInt(cmbEmpresa.SelectedValue.ToString))
                If Not dtListado Is Nothing Then
                    If dtListado.Rows.Count > 0 Then
                        cmbPeriodo.DataSource = dtListado
                        cmbPeriodo.ValueMember = "ID"
                        cmbPeriodo.DisplayMember = "DESCRIPCION"

                        If dtListado.Rows.Count > 1 Then
                            Dim dtRow As DataRow = dtListado.NewRow
                            dtRow("ID") = 0
                            dtRow("DESCRIPCION") = ""
                            dtListado.Rows.InsertAt(dtRow, 0)
                        End If

                        If rdoRango.Checked Then
                            cmbPeriodo.SelectedIndex = 0
                        End If
                    Else
                        objMensajeAdv.mensaje = "No hay periodos de nómina para la empresa seleccionada."
                        objMensajeAdv.Show()
                    End If
                Else
                    objMensajeAdv.mensaje = "No hay periodos de nómina para la empresa seleccionada."
                    objMensajeAdv.Show()
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al consultar los periodos de nómina"
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm

        If grdComisiones.Rows.Count > 0 Then
            Try
                Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
                Dim fbdUbicacionArchivo As New FolderBrowserDialog
                Dim archivo As String = String.Empty

                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    If ret = Windows.Forms.DialogResult.OK Then

                        Dim fecha_hora As String = Date.Now.ToString("yyyyMMdd_Hmmss")
                        archivo = "ListadoComisiones_" & fecha_hora & ".xlsx"
                        gridExcelExporter.Export(grdComisiones, .SelectedPath & "\" & archivo)

                    End If
                    objMensajeExito.mensaje = "Los datos se exportaron correctamente al archivo " & archivo
                    objMensajeExito.ShowDialog()
                    .Dispose()
                End With
            Catch ex As Exception
                objMensajeError.mensaje = "Error al exportar."
                objMensajeError.ShowDialog()
            End Try
        Else
            objMensajeAdv.mensaje = "No hay información para exportar."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim altaForm As New AltaComisionesMensualesForm
        altaForm.idComisionEditar = 0
        altaForm.ShowDialog()
        If cmbEmpresa.SelectedIndex > 0 Then
            cargarListado()
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim objAdvertencias As New Tools.AdvertenciaForm
        Dim objError As New Tools.ErroresForm
        Dim objComisonesBU As New Negocios.ComisionesBU

        If grdComisiones.Selected.Rows.Count > 1 Then
            objAdvertencias.mensaje = "Seleccione solo un registro para poder editarlo."
            objAdvertencias.ShowDialog()
        ElseIf grdComisiones.Selected.Rows.Count = 0 Then
            objAdvertencias.mensaje = "Seleccione un registro para poder editarlo."
            objAdvertencias.ShowDialog()
        ElseIf (IsNumeric(grdComisiones.Selected.Rows(0).Cells("penof_periodonominafiscalId").Value)) AndAlso objComisonesBU.validaEstatusPeriodoNominaFiscal(CInt(grdComisiones.Selected.Rows(0).Cells("penof_periodonominafiscalId").Value)) Then
            'ElseIf (cmbPeriodo.SelectedIndex > 0 Or cmbPeriodo.Items.Count = 1 And IsNumeric(cmbPeriodo.SelectedValue)) AndAlso objComisonesBU.validaEstatusPeriodoNominaFiscal(CInt(cmbPeriodo.SelectedValue)) Then
            objAdvertencias.mensaje = "El periodo ha sido cerrado, no es posible editar el registro."
            objAdvertencias.ShowDialog()
        ElseIf IsDBNull(grdComisiones.Selected.Rows(0).Cells("cmnf_comisionid").Value) = False Then
            Dim altaForm As New AltaComisionesMensualesForm
            altaForm.idComisionEditar = grdComisiones.Selected.Rows(0).Cells("cmnf_comisionid").Value
            altaForm.Show()
            cargarListado()
        Else
            objError.mensaje = "No es posible editar el registro seleccionado."
            objError.ShowDialog()
        End If
    End Sub

    Private Sub AyudaComisionesMensualesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaComisionesMensualesToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "CONTA_MAUS_PagoComisiones_NominaFiscal_V1.pdf")
            Process.Start("Descargas\Manuales\Contabilidad\CONTA_MAUS_PagoComisiones_NominaFiscal_V1.pdf")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        menuAyuda.Show(btnAyuda, 0, btnAyuda.Height)
    End Sub

    Private Sub ComisionesMensualesArchivoWordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComisionesMensualesArchivoWordToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "CONTA_MAUS_PagoComisiones_NominaFiscal_V1.docx")
            Process.Start("Descargas\Manuales\Contabilidad\CONTA_MAUS_PagoComisiones_NominaFiscal_V1.docx")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ComisionesMensualesPropuestaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComisionesMensualesPropuestaToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "Contabilidad_SAY_ComisionesNominaFiscal_Jun2019_V1.docx")
            Process.Start("Descargas\Manuales\Contabilidad\Contabilidad_SAY_ComisionesNominaFiscal_Jun2019_V1.docx")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPeriodo.SelectedIndexChanged
        grdComisiones.DataSource = Nothing
        colaboradorIds = String.Empty
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dim objAdvertencias As New Tools.AdvertenciaForm
        Dim objError As New Tools.ErroresForm
        Dim objComisonesBU As New Negocios.ComisionesBU

        If grdComisiones.Selected.Rows.Count > 1 Then
            objAdvertencias.mensaje = "Seleccione solo un registro."
            objAdvertencias.ShowDialog()
        ElseIf grdComisiones.Selected.Rows.Count = 0 Then
            objAdvertencias.mensaje = "Seleccione al menos un registro."
            objAdvertencias.ShowDialog()
        ElseIf (IsNumeric(grdComisiones.Selected.Rows(0).Cells("penof_periodonominafiscalId").Value)) AndAlso objComisonesBU.validaEstatusPeriodoNominaFiscal(CInt(grdComisiones.Selected.Rows(0).Cells("penof_periodonominafiscalId").Value)) Then
            objAdvertencias.mensaje = "El periodo ha sido cerrado, no es posible editar el registro."
            objAdvertencias.ShowDialog()
        ElseIf IsDBNull(grdComisiones.Selected.Rows(0).Cells("cmnf_comisionid").Value) = False AndAlso grdComisiones.Selected.Rows(0).Cells("cmnf_comisionid").Value > 0 Then
            If IsDBNull(grdComisiones.Selected.Rows(0).Cells("estatus").Value) = False AndAlso grdComisiones.Selected.Rows(0).Cells("estatus").Value = "CAPTURADA" Then
                Dim objMensajeConf As New Tools.ConfirmarForm
                objMensajeConf.mensaje = "¿Está seguro de cancelar la comisión seleccionada? Este proceso no se podrá revertir."
                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    cancelarComision(CInt(grdComisiones.Selected.Rows(0).Cells("cmnf_comisionid").Value))
                End If
            Else
                objAdvertencias.mensaje = "No es posible editar el registro seleccionado."
                objAdvertencias.ShowDialog()
            End If
        Else
            objError.mensaje = "No es posible editar el registro seleccionado."
            objError.ShowDialog()
        End If

    End Sub

    Private Sub cancelarComision(ByVal comisionCancelar As Integer)
        Try
            Dim objComision As New Entidades.ComisionMensual
            Dim objBU As New Negocios.ComisionesBU
            Dim mensajeExito As New ExitoForm
            Dim mensajeError As ErroresForm = Nothing
            Dim mensaje As String

            mensaje = objBU.cancelarComisiones(comisionCancelar, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            If mensaje <> "EXITO" Then
                mensajeError = New ErroresForm
                mensajeError.mensaje = "Ocurrió un erro al intentar cancelar la comisión."
                mensajeError.ShowDialog()
            Else
                mensajeExito.mensaje = "La comisión fue cancelada correctamente."
                mensajeExito.ShowDialog()
            End If

            cargarListado()

        Catch ex As Exception
            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = "Ocurrió un erro al intentar cancelar la comisión." + vbNewLine + ex.ToString
            mensajeError.ShowDialog()
        End Try

    End Sub
End Class