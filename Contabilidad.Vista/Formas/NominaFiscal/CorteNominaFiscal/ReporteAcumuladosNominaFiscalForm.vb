Imports System.Windows.Forms
Imports Framework.Negocios
Imports Tools
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid
Imports Stimulsoft.Report
Imports System.Data.OleDb
Imports System.Drawing

Public Class ReporteAcumuladosNominaFiscalForm
    Dim colaboradorIds As String = String.Empty
    Dim blnEditarGrid As Boolean = False
    Dim registrosEdicion As Integer = 0

    Private Sub ReporteAcumuladosNominaFiscalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        cargarComboEmpresaPatron()
        configuracionPermisosBotones()
        txtAnio.Text = DateTime.Now.ToString("yyyy")
    End Sub

    Public Sub cargarComboEmpresaPatron()
        Dim objBu As New Contabilidad.Negocios.ReporteAcumuladoSueldosSalariosBU
        Dim dtEmpresa As New DataTable
        dtEmpresa = objBu.consultarPatronEmpresaBU()
        If dtEmpresa.Rows.Count > 0 Then
            If dtEmpresa.Rows.Count = 1 Then
                Dim dtRow As DataRow = dtEmpresa.NewRow
                dtRow("ID") = 0
                dtRow("PATRON") = ""
                dtEmpresa.Rows.InsertAt(dtRow, 0)
                cmbPatron.DataSource = dtEmpresa
                cmbPatron.DisplayMember = "Patron"
                cmbPatron.ValueMember = "ID"
                cmbPatron.SelectedIndex = 1
            Else
                cmbPatron.DataSource = dtEmpresa
                cmbPatron.DisplayMember = "Patron"
                cmbPatron.ValueMember = "ID"
            End If
        End If
    End Sub

    Private Sub configuracionPermisosBotones()
        If PermisosUsuarioBU.ConsultarPermiso("ACMU_SUE2_SAOS", "ACMU_IMPR") Then
            pnlImprimir.Visible = True
        Else
            pnlImprimir.Visible = False
        End If
        If PermisosUsuarioBU.ConsultarPermiso("ACMU_SUE2_SAOS", "ACMU_EXPO") Then
            pnlExportar.Visible = True
        Else
            pnlExportar.Visible = False
        End If
        If PermisosUsuarioBU.ConsultarPermiso("ACMU_SUE2_SAOS", "ACMU_LOUT") Then
            pnlLayout.Visible = True
            pnlLayout.Enabled = False
        Else
            pnlLayout.Visible = False
        End If
        If PermisosUsuarioBU.ConsultarPermiso("ACMU_SUE2_SAOS", "ACMU_IMPO") Then
            pnlCargar.Visible = True
            pnlCargar.Enabled = False
        Else
            pnlCargar.Visible = False
        End If
        If PermisosUsuarioBU.ConsultarPermiso("ACMU_SUE2_SAOS", "ACMU_AUTO") Then
            pnlAutorizarISR.Visible = True
            pnlAutorizarISR.Enabled = False
        Else
            pnlAutorizarISR.Visible = False
        End If
        If PermisosUsuarioBU.ConsultarPermiso("ACMU_SUE2_SAOS", "ACMU_GDAR") Then
            pnlCalcular.Visible = True
            pnlCalcular.Enabled = False
        Else
            pnlCalcular.Visible = False
        End If

        blnEditarGrid = PermisosUsuarioBU.ConsultarPermiso("ACMU_SUE2_SAOS", "ACUM_EDITGRD")
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        gpbFiltro.Height = 40
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        gpbFiltro.Height = 99
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        If registrosEdicion = 0 Then
            limpiarCampos()
        Else
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Existen registros en edición, ¿Esta seguro de continuar?"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                limpiarCampos()
            End If
        End If
    End Sub

    Private Sub rdoCalculo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCalculo.CheckedChanged
        GridAcumuladoSS.DataSource = Nothing
        Me.txtAnio.Select()
        If rdoCalculo.Checked Then
            habilitarBotones()
        End If
        pnlGuardar.Visible = blnEditarGrid
    End Sub

    Private Sub rdoAcumulado_CheckedChanged(sender As Object, e As EventArgs) Handles rdoAcumulado.CheckedChanged
        GridAcumuladoSS.DataSource = Nothing
        Me.txtAnio.Select()
        If rdoAcumulado.Checked Then
            pnlLayout.Enabled = False
            pnlCargar.Enabled = False
            pnlAutorizarISR.Enabled = False
            pnlCalcular.Enabled = False
        End If
        pnlGuardar.Visible = False
    End Sub

    Private Sub cmbPeriodoDel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPeriodoDel.SelectedIndexChanged
        GridAcumuladoSS.DataSource = Nothing
        Me.txtAnio.Select()
    End Sub

    Private Sub cmbPeriodoAl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPeriodoAl.SelectedIndexChanged
        GridAcumuladoSS.DataSource = Nothing
        Me.txtAnio.Select()
    End Sub

    Public Sub limpiarCampos()
        grdAcumuladoSS.Columns.Clear()
        GridAcumuladoSS.DataSource = Nothing
        txtNombre.Text = ""
        cmbPatron.SelectedIndex = 0
        txtAnio.Text = DateTime.Now.ToString("yyyy")
        rdoAcumulado.Checked = True
        configuracionPermisosBotones()
        registrosEdicion = 0
    End Sub

    Private Sub cmbPatron_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPatron.SelectedIndexChanged
        GridAcumuladoSS.DataSource = Nothing
        cmbPeriodoDel.DataSource = Nothing
        cmbPeriodoAl.DataSource = Nothing
        colaboradorIds = String.Empty
        pnlArchivoCargado.Visible = False
        'txtAnio.Text = DateTime.Now.ToString("yyyy")
        If cmbPatron.SelectedIndex > 0 Then
            cargarCombosPeriodos()
            Me.txtAnio.Select()
        End If
        configuracionPermisosBotones()
    End Sub


    Public Sub cargarCombosPeriodos()
        Dim objMensajeError As New Tools.AdvertenciaForm
        Try
            cmbPeriodoDel.DataSource = Nothing
            cmbPeriodoAl.DataSource = Nothing
            If cmbPatron.SelectedValue > 0 Then
                Dim objBu As New Contabilidad.Negocios.UtileriasBU
                Dim dtPeriodosDel As New DataTable
                Dim dtPeriodosAl As New DataTable
                dtPeriodosDel = objBu.consultarPeriodosNominaxAnioBU(CInt(cmbPatron.SelectedValue.ToString), CInt(txtAnio.Text.ToString))
                dtPeriodosAl = objBu.consultarPeriodosNominaxAnioAlBU(CInt(cmbPatron.SelectedValue.ToString), CInt(txtAnio.Text.ToString))
                If Not dtPeriodosDel Is Nothing Then
                    If dtPeriodosDel.Rows.Count > 0 Then
                        cmbPeriodoDel.DataSource = dtPeriodosDel
                        cmbPeriodoDel.ValueMember = "ID"
                        cmbPeriodoDel.DisplayMember = "PERIODO"

                        cmbPeriodoAl.DataSource = dtPeriodosAl
                        cmbPeriodoAl.ValueMember = "ID"
                        cmbPeriodoAl.DisplayMember = "PERIODO"
                    Else
                        objMensajeError.mensaje = "No hay periodos de nómina para la empresa seleccionada."
                        objMensajeError.ShowDialog()
                    End If
                End If
            Else
                objMensajeError.mensaje = "No hay periodos de nómina para la empresa seleccionada."
                objMensajeError.ShowDialog()
            End If
        Catch
            objMensajeError.mensaje = "Error al consultar los periodos de nómina"
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub txtNombre_Enter(sender As Object, e As EventArgs) Handles txtNombre.Enter
        If registrosEdicion = 0 Then
            mostrarAcumulado()
        Else
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Existen registros en edición, ¿Esta seguro de continuar?"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                mostrarAcumulado()
            End If
        End If
    End Sub

    Private Sub btnMostrarAcumulado_Click(sender As Object, e As EventArgs) Handles btnMostrarAcumulado.Click
        mostrarAcumulado()
    End Sub

    Public Sub mostrarAcumulado()
        Me.Cursor = Cursors.WaitCursor
        Dim objBu As New Negocios.ReporteAcumuladoSueldosSalariosBU
        Dim dtAcumulado As New DataTable
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        GridAcumuladoSS.DataSource = Nothing
        registrosEdicion = 0

        If cmbPatron.SelectedIndex > 0 Then
            If rdoAcumulado.Checked Then
                dtAcumulado = objBu.mostrarAcumuladoBU(cmbPatron.SelectedValue, cmbPeriodoDel.SelectedValue, cmbPeriodoAl.SelectedValue, txtAnio.Text, txtNombre.Text, colaboradorIds)
                pnlCalcular.Enabled = False

            ElseIf rdoCalculo.Checked Then
                dtAcumulado = objBu.consultarCalculoBU(cmbPatron.SelectedValue, txtAnio.Text)

            End If

            If dtAcumulado.Rows.Count > 0 Then
                grdAcumuladoSS.Columns.Clear()
                GridAcumuladoSS.DataSource = Nothing
                GridAcumuladoSS.DataSource = dtAcumulado
                DiseñoGrid.AlternarColorEnFilas(grdAcumuladoSS)
                DiseñoGrid.DeshabilitarEdicion(grdAcumuladoSS)
                DiseñoGrid.DiseñoBaseGrid(grdAcumuladoSS)

                If rdoCalculo.Checked Then

                    grdAcumuladoSS.Columns.ColumnByFieldName("Comisiones").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("salariodiario").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("salariodiariointegrado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("ISRSAY").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("ISRCargado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("TotalISRRetenido").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("SPEPagado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("Sueldos").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("Asistencia").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("Puntualidad").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("Aguinaldo").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("AguiExento").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("AguiGravado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("Vacaciones").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("PV").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("pvExento").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("pvGravado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("ExentoCargado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("GravadoCargado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("TotalExento").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("TotalGravado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("LI").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("EXCELI").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("TASA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("IMPTOMARGINAL").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("CUOTAFIJA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("IMPTO177").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("SPEAPLICADO").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("ISRPAGADO").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("ACARGO").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("AFAVOR").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("Compensado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("PorCompensar").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdAcumuladoSS.Columns.ColumnByFieldName("ISR No Compensado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                    grdAcumuladoSS.Columns("ColaboradorId").Visible = False
                    grdAcumuladoSS.Columns("No").Fixed = Columns.FixedStyle.Left
                    grdAcumuladoSS.Columns("Clave").Fixed = Columns.FixedStyle.Left
                    grdAcumuladoSS.Columns("Colaborador").Fixed = Columns.FixedStyle.Left
                    grdAcumuladoSS.Columns("ISR No Compensado").Fixed = Columns.FixedStyle.Right
                    grdAcumuladoSS.Columns("PorCompensar").Fixed = Columns.FixedStyle.Right
                    grdAcumuladoSS.Columns("PorCompensar").Caption = "ISRPorCompensar"
                    grdAcumuladoSS.Columns("PorCompensar").Name = "ISRPorCompensar"
                    grdAcumuladoSS.Columns("Compensado").Fixed = Columns.FixedStyle.Right
                    grdAcumuladoSS.Columns("Compensado").Caption = "ISRCompensado"
                    grdAcumuladoSS.Columns("Compensado").Name = "ISRCompensado"
                    grdAcumuladoSS.Columns("AFAVOR").Fixed = Columns.FixedStyle.Right
                    grdAcumuladoSS.Columns("ACARGO").Fixed = Columns.FixedStyle.Right

                    grdAcumuladoSS.Columns("salariodiario").Caption = "Salario Diario"
                    grdAcumuladoSS.Columns("salariodiariointegrado").Caption = "SDI"
                    grdAcumuladoSS.Columns("TotalISRRetenido").Caption = "Total ISR Retenido"

                    grdAcumuladoSS.Columns.ColumnByFieldName("ExentoCargado").OptionsColumn.AllowEdit = blnEditarGrid
                    grdAcumuladoSS.Columns.ColumnByFieldName("GravadoCargado").OptionsColumn.AllowEdit = blnEditarGrid
                    grdAcumuladoSS.Columns.ColumnByFieldName("ISRCargado").OptionsColumn.AllowEdit = blnEditarGrid
                    grdAcumuladoSS.Columns("EdicionEC").Visible = False
                    grdAcumuladoSS.Columns("EdicionGC").Visible = False
                    grdAcumuladoSS.Columns("EdicionIC").Visible = False

                    habilitarBotones()

                Else

                    pnlCalcular.Enabled = False

                    grdAcumuladoSS.Columns.ColumnByFieldName("colaboradorid").Visible = False
                    grdAcumuladoSS.Columns("Sueldos").Caption = "001" & Environment.NewLine & "Sueldos"
                    grdAcumuladoSS.Columns("Asistencia").Caption = "049" & Environment.NewLine & "Asistencia"
                    grdAcumuladoSS.Columns("Puntualidad").Caption = "010" & Environment.NewLine & "Puntualidad"
                    grdAcumuladoSS.Columns("Comisiones").Caption = "028" & Environment.NewLine & "Comisiones"
                    grdAcumuladoSS.Columns("Aguinaldo").Caption = "002" & Environment.NewLine & "Aguinaldo"
                    grdAcumuladoSS.Columns("Vacaciones").Caption = "001" & Environment.NewLine & "Vacaciones"
                    grdAcumuladoSS.Columns("importePV").Caption = "021" & Environment.NewLine & "importePV"
                    grdAcumuladoSS.Columns("Total de Percepciones").Caption = "Total de" & Environment.NewLine & "Percepciones"
                    grdAcumuladoSS.Columns("SPEPagado").Caption = "002" & Environment.NewLine & "SPEPagado"
                    grdAcumuladoSS.Columns("ISRAjustadoXSPE").Caption = "007 (Informativa)" & Environment.NewLine & "ISR Ajustado" & Environment.NewLine & " por SPE"
                    grdAcumuladoSS.Columns("SPENoCorrespondia").Caption = "008 (Informativa)" & Environment.NewLine & "Subsidio que no" & Environment.NewLine & "correspondía entregar"
                    grdAcumuladoSS.Columns("Otros Pagos").Caption = "Otros" & Environment.NewLine & "Pagos"
                    grdAcumuladoSS.Columns("CompensacionSaldoAFavor").Caption = "004" & Environment.NewLine & "Compensación de" & Environment.NewLine & "saldos a favor"
                    grdAcumuladoSS.Columns("Total Otros Pagos").Caption = "Total" & Environment.NewLine & "Otros Pagos"
                    grdAcumuladoSS.Columns("IMSS").Caption = "001" & Environment.NewLine & "IMSS"
                    grdAcumuladoSS.Columns("Afore").Caption = "003" & Environment.NewLine & "Afore"
                    grdAcumuladoSS.Columns("Infonavit").Caption = "010" & Environment.NewLine & "Infonavit"
                    grdAcumuladoSS.Columns("AjusteSPE").Caption = "071" & Environment.NewLine & "Ajuste al" & Environment.NewLine & "subsidio para el empleo"
                    grdAcumuladoSS.Columns("AjusteSPECausado").Caption = "107 (Informativa)" & Environment.NewLine & "Ajuste al" & Environment.NewLine & "subsidio causado"
                    grdAcumuladoSS.Columns("TotalDeducciones").Caption = "Total de" & Environment.NewLine & "Deducciones"
                    grdAcumuladoSS.Columns("RetISRAnual").Caption = "101" & Environment.NewLine & "Retención" & Environment.NewLine & "ISR Anual"
                    grdAcumuladoSS.Columns("ISR").Caption = "002" & Environment.NewLine & "Retención de" & Environment.NewLine & "ISR"
                    grdAcumuladoSS.Columns("ISRAjusteSPE").Caption = "002" & Environment.NewLine & "Retención de ISR" & Environment.NewLine & "por ajuste de SPE"
                    grdAcumuladoSS.Columns("AguiISR").Caption = "002" & Environment.NewLine & "AguiISR"
                    grdAcumuladoSS.Columns("VacISR").Caption = "002" & Environment.NewLine & "VacISR"
                    grdAcumuladoSS.Columns("TotalRetenciones").Caption = "Total de" & Environment.NewLine & "Retenciones"
                    grdAcumuladoSS.Columns("Faltas").Caption = "Ausentismos"
                    grdAcumuladoSS.Columns("Incapacidad").Caption = "Incapacidades"

                    For Each Col As DevExpress.XtraGrid.Columns.GridColumn In grdAcumuladoSS.Columns
                        If Not (Col.FieldName = "No" Or Col.FieldName = "colaboradorid" Or Col.FieldName = "Clave" Or Col.FieldName = "Colaborador") Then
                            Col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            Col.DisplayFormat.FormatString = "{0:N2}"
                        End If
                    Next

                End If

                DiseñoGrid.AjustarAnchoColumnas(grdAcumuladoSS)
                DiseñoGrid.AlinearTextoEncabezadoColumnas(grdAcumuladoSS)
            Else
                objMensajeAdv.mensaje = "La consulta no devolvió ningún resultado"
                objMensajeAdv.Show()
            End If
        Else
            objMensajeAdv.mensaje = "Favor de seleccionar un registro en el combo Patrón"
            objMensajeAdv.Show()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnSeleccionarColaborador_Click(sender As Object, e As EventArgs) Handles btnSeleccionarColaborador.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbPatron.Items.Count > 1 And cmbPatron.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar un Patrón"
            objMensajeAdv.ShowDialog()
        Else
            Dim objForm As New SeleccionarColaboradoresForm
            If Not CheckForm(objForm) Then
                objForm.colaboradorIds = colaboradorIds
                objForm.patronId = cmbPatron.SelectedValue
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

    Private Sub btnExportar_Click_1(sender As Object, e As EventArgs) Handles btnExportar.Click
        If grdAcumuladoSS.RowCount > 0 Then
            'tipo 0 cuando se exporta Grid
            Dim tipo As Integer = 0
            exportar(tipo)
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay información cargada.")
        End If
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        Dim EstatusID As Integer = grdAcumuladoSS.GetRowCellValue(e.RowHandle, "EstatusID")
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If cmbPatron.SelectedValue > 0 Then
                imprimirReporte()
            Else
                Dim objMensaje As New Tools.AdvertenciaForm
                objMensaje.mensaje = "Es necesario seleccionar un patrón"
                objMensaje.ShowDialog()
            End If
        Catch ex As Exception
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "Intente exportar nuevamente."
            objMensaje.ShowDialog()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub imprimirReporte()
        Dim dtAcumulado As New DataTable
        Dim objBuC As New Negocios.ReporteAcumuladoSueldosSalariosBU
        Dim empresa As String = String.Empty
        Dim rfc As String = String.Empty
        Dim regPatronal As String = String.Empty
        Dim domicilio As String = String.Empty
        Dim periodoDel As String = String.Empty
        Dim periodoAl As String = String.Empty
        Dim cveReporte As String = String.Empty

        Dim mensaje As String = String.Empty
        mensaje = objBuC.validarExistenciaBU(cmbPatron.SelectedValue, txtAnio.Text)
        If rdoAcumulado.Checked Then
            dtAcumulado = objBuC.mostrarAcumuladoBU(cmbPatron.SelectedValue, cmbPeriodoDel.SelectedValue, cmbPeriodoAl.SelectedValue, txtAnio.Text, txtNombre.Text, colaboradorIds)
            cveReporte = "ASS_DTCORTE"
        ElseIf rdoCalculo.Checked Then
            dtAcumulado = objBuC.consultarCalculoBU(cmbPatron.SelectedValue, txtAnio.Text)
            cveReporte = "ASUSA_CALCULO"
        End If

        If dtAcumulado.Rows.Count > 0 Then
            objBuC = New Negocios.ReporteAcumuladoSueldosSalariosBU
            Dim dtDatosEmpresa = objBuC.consultarDatosPatronBU(cmbPatron.SelectedValue, cmbPeriodoDel.SelectedValue, cmbPeriodoAl.SelectedValue)
            If dtDatosEmpresa.Rows.Count > 0 Then
                empresa = dtDatosEmpresa.Rows(0).Item("empresa")
                regPatronal = dtDatosEmpresa.Rows(0).Item("regPatronal")
                rfc = dtDatosEmpresa.Rows(0).Item("rfc")
                domicilio = dtDatosEmpresa.Rows(0).Item("domicilio")
                periodoDel = dtDatosEmpresa.Rows(0).Item("periodoDel")
                periodoAl = dtDatosEmpresa.Rows(0).Item("periodoAl")
            End If

            Dim OBJBU As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes

            EntidadReporte = OBJBU.LeerReporteporClave(cveReporte)

            Dim archivo As String
            archivo = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

            Dim reporte As StiReport = New StiReport()
            reporte.Load(archivo)
            reporte.Compile()
            reporte("Empresa") = empresa
            reporte("rfc") = rfc
            reporte("regPatronal") = regPatronal
            reporte("domicilioFiscal") = domicilio
            reporte("periodoDel") = periodoDel
            reporte("periodoAl") = periodoAl
            reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            reporte.Dictionary.Clear()
            reporte.RegData(dtAcumulado)
            reporte.Dictionary.Synchronize()
            reporte.Show()
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If registrosEdicion = 0 Then
            Me.Close()
        Else
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Existen registros en edición, ¿Esta seguro de continuar?"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Me.Cursor = Cursors.WaitCursor
        guardarCalculo()
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub guardarCalculo()
        If registrosEdicion > 0 Then
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Esta acción realizará la actualizacion del cálculo del acumulado, ¿Esta seguro de continuar?"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    Dim objBU As New Negocios.ReporteAcumuladoSueldosSalariosBU
                    Dim colid As Integer
                    Dim exentocargado As Double = 0.0
                    Dim gravadocargado As Double = 0.0
                    Dim isrcargado As Double = 0.0

                    For index As Integer = 0 To grdAcumuladoSS.DataRowCount - 1 Step 1
                        If grdAcumuladoSS.GetRowCellValue(grdAcumuladoSS.GetVisibleRowHandle(index), "EdicionEC") Or grdAcumuladoSS.GetRowCellValue(grdAcumuladoSS.GetVisibleRowHandle(index), "EdicionGC") Or grdAcumuladoSS.GetRowCellValue(grdAcumuladoSS.GetVisibleRowHandle(index), "EdicionIC") Then
                            colid = grdAcumuladoSS.GetRowCellValue(grdAcumuladoSS.GetVisibleRowHandle(index), "ColaboradorId")
                            exentocargado = grdAcumuladoSS.GetRowCellValue(grdAcumuladoSS.GetVisibleRowHandle(index), "ExentoCargado")
                            gravadocargado = grdAcumuladoSS.GetRowCellValue(grdAcumuladoSS.GetVisibleRowHandle(index), "GravadoCargado")
                            isrcargado = grdAcumuladoSS.GetRowCellValue(grdAcumuladoSS.GetVisibleRowHandle(index), "ISRCargado")

                            objBU.actualizarCalculoBU(cmbPatron.SelectedValue, txtAnio.Text, colid, exentocargado, gravadocargado, isrcargado)
                        End If
                    Next

                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se han actualizado correctamente.")
                    mostrarAcumulado()

                Catch ex As Exception
                    Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al actualizar la información.")
                Finally
                    Me.Cursor = Cursors.Default
                End Try
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Debe haber al menos un registro en edición para guardar la información.")
        End If
    End Sub

    Private Sub btnImportarDatos_Click(sender As Object, e As EventArgs) Handles btnImportarDatos.Click
        importarDatos()
    End Sub

    Public Sub importarDatos()
        Me.Cursor = Cursors.WaitCursor
        Dim objbu As New Negocios.ReporteAcumuladoSueldosSalariosBU
        Dim dtActualiza As New DataTable
        Dim dt As DataTable
        Dim mensajeExito As New ExitoForm
        Dim objMensajeConf As New Tools.ConfirmarForm
        Dim myFileDialog As New OpenFileDialog()
        Dim xSheet As String = ""
        Dim tabla As New DataGridView
        Dim colid As Integer
        Dim exentocargado As String
        Dim gravadocargado As String
        Dim isrcargado As String

        objMensajeConf.mensaje = "Al importar el archivo excel se realizará la actualizacion del cálculo del acumulado, ¿Esta seguro de continuar?"
        If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                With myFileDialog
                    .Filter = "Excel Files |*.xlsx"
                    .Title = "Open File"
                    .ShowDialog()
                End With
                If myFileDialog.FileName.ToString <> "" Then
                    Dim ExcelFile As String = myFileDialog.FileName.ToString
                    Dim ds As New DataSet
                    Dim da As New OleDbDataAdapter
                    Dim conn As OleDbConnection
                    xSheet = "Sheet"
                    conn = New OleDbConnection(
                        "Provider=Microsoft.ACE.OLEDB.12.0;" &
                        "data source=" & ExcelFile & "; " &
                        "Extended Properties='Excel 12.0 Xml;HDR=Yes'")
                    Try
                        Me.Cursor = Cursors.WaitCursor
                        da = New OleDbDataAdapter("Select * FROM [" & xSheet & "$]", conn)
                        conn.Open()
                        da.Fill(ds, "MyData")
                        dt = ds.Tables("MyData")
                        For Each Row As DataRow In dt.Rows
                            colid = Row.Item(1)
                            exentocargado = Row.Item(3)
                            gravadocargado = Row.Item(4)
                            isrcargado = Row.Item(5)
                            objbu.actualizarCalculoBU(cmbPatron.SelectedValue, txtAnio.Text, colid, exentocargado, gravadocargado, isrcargado)
                        Next
                    Catch ex As Exception
                        MsgBox("El nombre de la hoja de calculo debe ser Sheet", MsgBoxStyle.Information, "Informacion")
                    Finally
                        conn.Close()
                    End Try
                End If
                mensajeExito.mensaje = "Los datos se han actualizado correctamente."
                mensajeExito.ShowDialog()
                mostrarAcumulado()

                Me.Cursor = Cursors.Default
            Catch ex As Exception
                Dim mensajeError As New ErroresForm
                mensajeError.mensaje = ex.Message
                mensajeError.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnLayout_Click(sender As Object, e As EventArgs) Handles btnLayout.Click
        If grdAcumuladoSS.RowCount > 0 Then
            'tipo 1 cuando se exporta layout
            Dim tipo As Integer = 1
            exportar(tipo)
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay información cargada para exportar al Layout.")
        End If
    End Sub

    Private Sub exportar(ByVal tipo As Integer)
        Me.Cursor = Cursors.WaitCursor
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim mensajeExito As New ExitoForm

        Try
            With fbdUbicacionArchivo
                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then
                    Dim exportOptions = New XlsxExportOptionsEx()
                    AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                    If tipo = 1 Then

                        For Each Col As DevExpress.XtraGrid.Columns.GridColumn In grdAcumuladoSS.Columns
                            If Col.FieldName = "ColaboradorId" Or Col.FieldName = "Clave" Or Col.FieldName = "RFC" Or Col.FieldName = "ExentoCargado" Or Col.FieldName = "GravadoCargado" Or Col.FieldName = "ISRCargado" Then
                                Col.Visible = True
                                Select Case Col.FieldName
                                    Case "ExentoCargado"
                                        Col.VisibleIndex = 3
                                    Case "GravadoCargado"
                                        Col.VisibleIndex = 4
                                    Case "ISRCargado"
                                        Col.VisibleIndex = 5
                                End Select
                            Else
                                Col.Visible = False
                            End If
                        Next

                        DiseñoGrid.AjustarAnchoColumnas(grdAcumuladoSS)
                        grdAcumuladoSS.OptionsView.ShowFooter = False
                        grdAcumuladoSS.ExportToXlsx(.SelectedPath + "\LayoutCargarDatos_" + fecha_hora + ".xlsx", exportOptions)
                        grdAcumuladoSS.Columns.Clear()
                        GridAcumuladoSS.DataSource = Nothing
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente.")
                        mostrarAcumulado()
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "\LayoutCargarDatos_" + fecha_hora + ".xlsx")

                    ElseIf tipo = 0 Then
                        Dim nombreReporte As String = String.Empty

                        If rdoAcumulado.Checked Then
                            nombreReporte = "\AcumuladoSueldosSalarios_" + fecha_hora + ".xlsx"
                        ElseIf rdoCalculo.Checked Then
                            nombreReporte = "\CalculoSueldosSalarios_" + fecha_hora + ".xlsx"
                        End If

                        grdAcumuladoSS.ExportToXlsx(.SelectedPath + nombreReporte, exportOptions)
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente.")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte)

                    End If
                End If
            End With
        Catch ex As Exception
            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = ex.Message
            mensajeError.ShowDialog()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAutorizarISR_Click(sender As Object, e As EventArgs) Handles btnAutorizarISR.Click
        If registrosEdicion > 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Existen registros en edición, no es posible autorizar.")
        Else
            autorizarCalculo()
        End If
    End Sub

    Public Sub autorizarCalculo()
        Me.Cursor = Cursors.WaitCursor
        Dim objBu As New Negocios.ReporteAcumuladoSueldosSalariosBU
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeConf As New Tools.ConfirmarForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim resultado As String = String.Empty

        Try
            'If validaCampos() Then
            objMensajeConf.mensaje = "¿Está seguro de Autorizar el cálculo de Acumulado? Posteriormente no se podrán realizar cambios"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                resultado = objBu.autorizarCalculoBU(cmbPatron.SelectedValue, txtAnio.Text)
                If resultado = "EXITO" Then
                    objMensajeExito.mensaje = "Se ha Autorizado el cálculo del acumulado"
                    objMensajeExito.ShowDialog()
                    mostrarAcumulado()
                Else
                    objMensajeError.mensaje = resultado
                    objMensajeError.ShowDialog()
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error, favor de comunicarse con sistemas"
            objMensajeError.ShowDialog()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtAnio_TextChanged(sender As Object, e As EventArgs) Handles txtAnio.TextChanged
        GridAcumuladoSS.DataSource = Nothing
        cmbPeriodoDel.DataSource = Nothing
        cmbPeriodoAl.DataSource = Nothing
        colaboradorIds = String.Empty
        pnlArchivoCargado.Visible = False
        If cmbPatron.SelectedIndex > 0 And txtAnio.Text.Length = 4 Then
            cargarCombosPeriodos()
            Me.txtAnio.Select()
        End If
        configuracionPermisosBotones()
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        Dim objBu As New Negocios.ReporteAcumuladoSueldosSalariosBU
        Dim dtAcumulado As New DataTable
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeConf As New Tools.ConfirmarForm

        If cmbPatron.SelectedIndex > 0 Then
            If rdoCalculo.Checked Then
                Dim mensaje As String = String.Empty
                mensaje = objBu.validarExistenciaBU(cmbPatron.SelectedValue, txtAnio.Text)
                If mensaje = "NOEXISTE" Then
                    Me.Cursor = Cursors.WaitCursor
                    mensaje = objBu.guardarCalculoBU(cmbPatron.SelectedValue, cmbPeriodoDel.SelectedValue, cmbPeriodoAl.SelectedValue, txtAnio.Text, txtNombre.Text, colaboradorIds, 2)
                Else
                    objMensajeConf.mensaje = "Se eliminará el calculo anterior. ¿Desea continuar?"
                    If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor
                        mensaje = objBu.guardarCalculoBU(cmbPatron.SelectedValue, cmbPeriodoDel.SelectedValue, cmbPeriodoAl.SelectedValue, txtAnio.Text, txtNombre.Text, colaboradorIds, 2)
                    Else
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If

                If mensaje = "EXITO" Then
                    objMensajeExito.mensaje = "El calculo se ha guardado correctamente."
                    objMensajeExito.ShowDialog()
                Else
                    objMensajeError.mensaje = mensaje
                    objMensajeError.ShowDialog()
                End If
                mostrarAcumulado()
            End If
        Else
            objMensajeAdv.mensaje = "Favor de seleccionar un registro en el combo Patrón"
            objMensajeAdv.Show()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub habilitarBotones()
        Dim objBu As New Negocios.ReporteAcumuladoSueldosSalariosBU
        Dim mensaje As String = String.Empty
        mensaje = objBu.validarExistenciaBU(cmbPatron.SelectedValue, txtAnio.Text)

        pnlCalcular.Enabled = True
        If mensaje = "HABILITAR" Then
            pnlLayout.Enabled = True
            pnlCargar.Enabled = True
            pnlAutorizarISR.Enabled = True
            pnlGuardar.Enabled = True
        ElseIf mensaje = "DESHABILITAR" Then
            pnlLayout.Enabled = False
            pnlCargar.Enabled = False
            pnlAutorizarISR.Enabled = False
            pnlCalcular.Enabled = False
            pnlGuardar.Enabled = False
            DiseñoGrid.DeshabilitarEdicion(grdAcumuladoSS)
        End If
    End Sub

    Private Sub grdAcumuladoSS_CellValueChanged(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles grdAcumuladoSS.CellValueChanged
        If e.Column.FieldName = "ExentoCargado" OrElse e.Column.FieldName = "GravadoCargado" OrElse e.Column.FieldName = "ISRCargado" Then

            Select Case e.Column.FieldName
                Case "ExentoCargado"
                    grdAcumuladoSS.SetRowCellValue(e.RowHandle, "EdicionEC", True)
                Case "GravadoCargado"
                    grdAcumuladoSS.SetRowCellValue(e.RowHandle, "EdicionGC", True)
                Case "ISRCargado"
                    Dim TotalISRRetenido As Double = 0.0
                    grdAcumuladoSS.SetRowCellValue(e.RowHandle, "EdicionIC", True)
                    If Not IsDBNull(grdAcumuladoSS.GetRowCellValue(e.RowHandle, "TotalISRRetenido")) Then
                        TotalISRRetenido = grdAcumuladoSS.GetRowCellValue(e.RowHandle, "TotalISRRetenido")
                    End If

                    TotalISRRetenido += grdAcumuladoSS.GetRowCellValue(e.RowHandle, "ISRCargado")
                    grdAcumuladoSS.SetRowCellValue(e.RowHandle, "TotalISRRetenido", TotalISRRetenido)
                    grdAcumuladoSS.SetRowCellValue(e.RowHandle, "ISRPAGADO", TotalISRRetenido)

            End Select

            registrosEdicion += 1
        End If
    End Sub

    Private Sub grdAcumuladoSS_CustomDrawCell(sender As Object, e As Views.Base.RowCellCustomDrawEventArgs) Handles grdAcumuladoSS.CustomDrawCell
        Try
            If e.Column.FieldName = "ExentoCargado" AndAlso CBool(sender.GetRowCellValue(e.RowHandle, "EdicionEC")) Then
                e.Appearance.BackColor = Color.FromArgb(35, 177, 77)
            ElseIf e.Column.FieldName = "GravadoCargado" AndAlso CBool(sender.GetRowCellValue(e.RowHandle, "EdicionGC")) Then
                e.Appearance.BackColor = Color.FromArgb(35, 177, 77)
            ElseIf e.Column.FieldName = "ISRCargado" AndAlso CBool(sender.GetRowCellValue(e.RowHandle, "EdicionIC")) Then
                e.Appearance.BackColor = Color.FromArgb(35, 177, 77)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ReporteAcumuladosNominaFiscalForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If registrosEdicion > 0 Then
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Existen registros en edición que se perderán al salir, ¿Esta seguro de continuar?"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                e.Cancel = True
            Else
                Me.Dispose()
            End If
        End If
    End Sub
End Class
