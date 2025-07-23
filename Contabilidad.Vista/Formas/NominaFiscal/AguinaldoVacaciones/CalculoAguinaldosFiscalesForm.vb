Imports System.Windows.Forms
Imports Framework.Negocios
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports Stimulsoft.Report

Public Class CalculoAguinaldosFiscalesForm

    Private Sub CalculoAguinaldosFiscalesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        configuracionPermisosBotones()
        llenarComboEmpresa()
        cargarSalarioMinimo()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbFiltros.Visible = False
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbFiltros.Visible = True
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub configuracionPermisosBotones()
        If PermisosUsuarioBU.ConsultarPermiso("CALC_AGUI_VACAC", "CALCULAR") Then
            pnlCalcular.Visible = True
        Else
            pnlCalcular.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("CALC_AGUI_VACAC", "IMPRIMIR") Then
            pnlImprimir.Visible = True
        Else
            pnlImprimir.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("CALC_AGUI_VACAC", "EXPORTAR") Then
            pnlExportar.Visible = True
        Else
            pnlExportar.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("CALC_AGUI_VACAC", "AUTORIZAR") Then
            pnlAutorizar.Visible = True
        Else
            pnlAutorizar.Visible = False
        End If
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
            Else
                cmbEmpresa.DataSource = Nothing
            End If
        Else
            cmbEmpresa.DataSource = Nothing
        End If
    End Sub

    Private Sub cargarSalarioMinimo()
        Try
            Dim objBU As New Negocios.UtileriasBU
            Dim dtEmpresas As New DataTable

            lblSalarioMinimo.Text = objBU.consultaUMA()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarFiltros()
    End Sub

    Private Sub limpiarFiltros()
        cmbEmpresa.SelectedIndex = 0
        'cmbAnio.SelectedIndex = 0
        'cmbFechaCalculo.SelectedIndex = 0

        grdListado.DataSource = Nothing
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click, lblCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        llenarComboAnios()
    End Sub

    Private Sub llenarComboAnios()
        Dim objMsjError As New Tools.ErroresForm
        Dim objBU As New Negocios.AguinaldoVacacionesBU
        Dim dtListado As New DataTable
        cmbAnio.DataSource = Nothing

        Try
            If Not cmbEmpresa Is Nothing Then
                If cmbEmpresa.SelectedIndex = 0 Or cmbEmpresa.SelectedIndex <> 0 Then
                    dtListado = objBU.obtenerAniosPatron(cmbEmpresa.SelectedValue)
                    If Not dtListado Is Nothing Then
                        If dtListado.Rows.Count > 0 Then
                            cmbAnio.DataSource = dtListado
                            cmbAnio.DisplayMember = "Anios"
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            objMsjError.mensaje = ex.Message
            objMsjError.ShowDialog()
        End Try
    End Sub

    Private Sub cmbAnio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAnio.SelectedIndexChanged
        'Try
        '    If cmbAnio.Text.ToString <> "" And cmbAnio.Text.ToString <> "System.Data.DataRowView" Then
        '        Dim objBU As New Negocios.AguinaldoVacacionesBU
        '        Dim dtResultado As New DataTable
        '        Dim fechaInicio As Date = "01/01/" & cmbAnio.Text
        '        Dim fechaFin As Date = "31/12/" & cmbAnio.Text

        '        dtpFechaCalculo.MinDate = DateTimePicker.MinimumDateTime
        '        dtpFechaCalculo.MaxDate = DateTimePicker.MaximumDateTime
        '        dtpFechaCalculo.MinDate = fechaInicio
        '        dtpFechaCalculo.MaxDate = fechaFin
        '        dtpFechaCalculo.Value = fechaFin

        '        validarAnio()
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        cargarListado()
    End Sub

    Private Sub cargarListado()
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        grdListado.DataSource = Nothing
        Try
            If validarFiltros() Then
                Dim objBU As New Negocios.AguinaldoVacacionesBU
                Dim dtListado As New DataTable
                Dim patronId As Integer = cmbEmpresa.SelectedValue
                Dim anio As Integer = CInt(cmbAnio.Text)
                Dim fechaCalculo As Date = dtpFechaCalculo.Value
                Dim metodo As Boolean = rdoPorLey.Checked

                dtListado = objBU.consultarAguinaldosVacaciones(patronId, anio, metodo)
                If Not dtListado Is Nothing Then
                    If dtListado.Rows.Count > 0 Then
                        grdListado.DataSource = dtListado
                        disenioGrid()
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
            objMensajeError.ShowDialog()
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Function validarFiltros() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbEmpresa.Items.Count > 1 And cmbEmpresa.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar una Empresa."
            objMensajeAdv.ShowDialog()
            Return False
        End If

        If cmbAnio.Items.Count > 1 And cmbAnio.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar un año."
            objMensajeAdv.ShowDialog()
            Return False
        End If

        Return True
    End Function

    Public Sub disenioGrid()
        grdListado.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True
        grdListado.DisplayLayout.UseFixedHeaders = True

        With grdListado.DisplayLayout.Bands(0)
            .ColHeaderLines = 2
            .Columns("Folio Fiscal").Hidden = True
            .Columns("Clave").Header.Fixed = True
            .Columns("Nombre del trabajador").Header.Fixed = True
            .Columns("NSS").Header.Fixed = True

            If cmbPeriodo.Text = "SEMANA SANTA" Then
                .Columns("Días Aguinaldo").Hidden = True
                .Columns("Importe Aguinaldo").Hidden = True
                .Columns("Aguinaldo Excento 30 S.M.A.G.").Hidden = True
                .Columns("Aguinaldo Excento").Hidden = True
                .Columns("Aguinaldo Gravado").Hidden = True
                .Columns("Retención ISR Aguinaldo").Hidden = True
                .Columns("Aguinaldo Neto").Hidden = True
            End If

            .Columns("Clave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Nombre del trabajador").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NSS").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("RFC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("CURP").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Fecha de ingreso").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Sueldo Diario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Días Trabajados").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Días Aguinaldo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Importe Aguinaldo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Aguinaldo Excento 30 S.M.A.G.").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Aguinaldo Excento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Aguinaldo Gravado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Retención ISR Aguinaldo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Aguinaldo Neto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Años Laborados").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Días Vacaciones").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Importe Vacaciones").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Importe Prima Vacacional").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Prima vacacional exenta").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Prima vacacional gravada").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Retención ISR Vacaciones").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Neto Vacaciones").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Retención ISR").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Neto a Recibir").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("Fecha de ingreso").Format = "dd/MM/yyyy"
            .Columns("Fecha de ingreso").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date
            .Columns("Fecha de ingreso").FilterOperandStyle = FilterOperandStyle.UseColumnEditor
            .Columns("Días Trabajados").Format = "##,##0"
            .Columns("Días Aguinaldo").Format = "##,##0"
            .Columns("Sueldo Diario").Format = "##,##0.00"
            .Columns("Importe Aguinaldo").Format = "##,##0"
            .Columns("Aguinaldo Excento 30 S.M.A.G.").Format = "##,##0"
            .Columns("Aguinaldo Excento").Format = "##,##0"
            .Columns("Aguinaldo Gravado").Format = "##,##0"
            .Columns("Retención ISR Aguinaldo").Format = "##,##0"
            .Columns("Aguinaldo Neto").Format = "##,##0"
            .Columns("Años Laborados").Format = "##,##0"
            .Columns("Días Vacaciones").Format = "##,##0.00"
            .Columns("Importe Vacaciones").Format = "##,##0"
            .Columns("Importe Prima Vacacional").Format = "##,##0"
            .Columns("Prima vacacional exenta").Format = "##,##0"
            .Columns("Prima vacacional gravada").Format = "##,##0"
            .Columns("Retención ISR Vacaciones").Format = "##,##0"
            .Columns("Neto Vacaciones").Format = "##,##0"
            .Columns("Retención ISR").Format = "##,##0"
            .Columns("Neto a Recibir").Format = "##,##0"

            .Columns("Sueldo Diario").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Días Trabajados").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Días Aguinaldo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Importe Aguinaldo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Aguinaldo Excento 30 S.M.A.G.").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Aguinaldo Excento").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Aguinaldo Gravado").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Retención ISR Aguinaldo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Aguinaldo Neto").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Años Laborados").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Días Vacaciones").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Importe Vacaciones").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Importe Prima Vacacional").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Prima vacacional exenta").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Prima vacacional gravada").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Retención ISR Vacaciones").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Neto Vacaciones").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Retención ISR").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Neto a Recibir").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("Clave").CharacterCasing = CharacterCasing.Upper
            .Columns("Nombre del trabajador").CharacterCasing = CharacterCasing.Upper
            .Columns("RFC").CharacterCasing = CharacterCasing.Upper
            .Columns("CURP").CharacterCasing = CharacterCasing.Upper

            If cmbPeriodo.Text = "NAVIDAD" Then
                Dim clnSumTotalImporteAguinaldo As UltraGridColumn = .Columns("Importe Aguinaldo")
                Dim clnSumTotalAguinaldoExcentoSmag As UltraGridColumn = .Columns("Aguinaldo Excento 30 S.M.A.G.")
                Dim clnSumTotalAguinaldoExcento As UltraGridColumn = .Columns("Aguinaldo Excento")
                Dim clnSumTotalAguinaldoGravado As UltraGridColumn = .Columns("Aguinaldo Gravado")
                Dim clnSumTotalIsrAguinaldo As UltraGridColumn = .Columns("Retención ISR Aguinaldo")
                Dim clnSumTotalAguinaldo As UltraGridColumn = .Columns("Aguinaldo Neto")

                Dim SumTotalImporteAguinaldo As SummarySettings = .Summaries.Add("Importe Aguinaldo", SummaryType.Sum, clnSumTotalImporteAguinaldo)
                Dim SumTotalAguinaldoExcentoSmag As SummarySettings = .Summaries.Add("Aguinaldo Excento 30 S.M.A.G", SummaryType.Sum, clnSumTotalAguinaldoExcentoSmag)
                Dim SumTotalAguinaldoExcento As SummarySettings = .Summaries.Add("Aguinaldo Excento", SummaryType.Sum, clnSumTotalAguinaldoExcento)
                Dim SumTotalAguinaldoGravado As SummarySettings = .Summaries.Add("Aguinaldo Gravado", SummaryType.Sum, clnSumTotalAguinaldoGravado)
                Dim SumTotalIsrAguinaldo As SummarySettings = .Summaries.Add("Retención ISR Aguinaldo", SummaryType.Sum, clnSumTotalIsrAguinaldo)
                Dim SumTotalAguinaldo As SummarySettings = .Summaries.Add("Aguinaldo Neto", SummaryType.Sum, clnSumTotalAguinaldo)


                SumTotalImporteAguinaldo.DisplayFormat = "{0:###,###,###0}"
                SumTotalAguinaldoExcentoSmag.DisplayFormat = "{0:###,###,##0}"
                SumTotalAguinaldoExcento.DisplayFormat = "{0:###,###,##0}"
                SumTotalAguinaldoGravado.DisplayFormat = "{0:###,###,##0}"
                SumTotalIsrAguinaldo.DisplayFormat = "{0:###,###,##0}"
                SumTotalAguinaldo.DisplayFormat = "{0:###,###,##0}"

                SumTotalImporteAguinaldo.Appearance.TextHAlign = HAlign.Right
                SumTotalAguinaldoExcentoSmag.Appearance.TextHAlign = HAlign.Right
                SumTotalAguinaldoExcento.Appearance.TextHAlign = HAlign.Right
                SumTotalAguinaldoGravado.Appearance.TextHAlign = HAlign.Right
                SumTotalIsrAguinaldo.Appearance.TextHAlign = HAlign.Right
                SumTotalAguinaldo.Appearance.TextHAlign = HAlign.Right


            End If

            Dim clnSumTotalImporteVacaciones As UltraGridColumn = .Columns("Importe Vacaciones")
            Dim clnSumTotalImportePrimaVacacional As UltraGridColumn = .Columns("Importe Prima Vacacional")
            Dim clnSumTotalPrimaVacacionalExcenta As UltraGridColumn = .Columns("Prima vacacional exenta")
            Dim clnSumTotalPrimaVacacionalGravada As UltraGridColumn = .Columns("Prima vacacional gravada")
            Dim clnSumTotalIsrVacaciones As UltraGridColumn = .Columns("Retención ISR Vacaciones")
            Dim clnSumTotalVacaciones As UltraGridColumn = .Columns("Neto Vacaciones")
            Dim clnSumTotalISR As UltraGridColumn = .Columns("Retención ISR")
            Dim clnSumTotal As UltraGridColumn = .Columns("Neto a Recibir")


            Dim SumTotalImporteVacaciones As SummarySettings = .Summaries.Add("Importe Vacaciones", SummaryType.Sum, clnSumTotalImporteVacaciones)
            Dim SumTotalImportePrimaVacacional As SummarySettings = .Summaries.Add("Importe Prima Vacacional", SummaryType.Sum, clnSumTotalImportePrimaVacacional)
            Dim SumTotalPrimaVacacionalExcenta As SummarySettings = .Summaries.Add("Prima vacacional exenta", SummaryType.Sum, clnSumTotalPrimaVacacionalExcenta)
            Dim SumTotalPrimaVacacionalGravada As SummarySettings = .Summaries.Add("Prima vacacional gravada", SummaryType.Sum, clnSumTotalPrimaVacacionalGravada)
            Dim SumTotalIsrVacaciones As SummarySettings = .Summaries.Add("Retención ISR Vacaciones", SummaryType.Sum, clnSumTotalIsrVacaciones)
            Dim SumTotalVacaciones As SummarySettings = .Summaries.Add("Neto Vacaciones", SummaryType.Sum, clnSumTotalVacaciones)
            Dim SumTotalISR As SummarySettings = .Summaries.Add("Retención ISR", SummaryType.Sum, clnSumTotalISR)
            Dim SumTotal As SummarySettings = .Summaries.Add("Neto a Recibir", SummaryType.Sum, clnSumTotal)

            SumTotalImporteVacaciones.DisplayFormat = "{0:###,###,##0}"
            SumTotalImportePrimaVacacional.DisplayFormat = "{0:###,###,##0}"
            SumTotalPrimaVacacionalExcenta.DisplayFormat = "{0:###,###,##0}"
            SumTotalPrimaVacacionalGravada.DisplayFormat = "{0:###,###,##0}"
            SumTotalIsrVacaciones.DisplayFormat = "{0:###,###,##0}"
            SumTotalVacaciones.DisplayFormat = "{0:###,###,##0}"
            SumTotalISR.DisplayFormat = "{0:###,###,##0}"
            SumTotal.DisplayFormat = "{0:###,###,##0}"


            SumTotalImporteVacaciones.Appearance.TextHAlign = HAlign.Right
            SumTotalImportePrimaVacacional.Appearance.TextHAlign = HAlign.Right
            SumTotalPrimaVacacionalExcenta.Appearance.TextHAlign = HAlign.Right
            SumTotalPrimaVacacionalGravada.Appearance.TextHAlign = HAlign.Right
            SumTotalIsrVacaciones.Appearance.TextHAlign = HAlign.Right
            SumTotalVacaciones.Appearance.TextHAlign = HAlign.Right
            SumTotalISR.Appearance.TextHAlign = HAlign.Right
            SumTotal.Appearance.TextHAlign = HAlign.Right

            .SummaryFooterCaption = "TOTALES"

            .Columns("Fecha de ingreso").Header.Caption = "Fecha de " & vbCrLf & "ingreso"
            .Columns("Sueldo Diario").Header.Caption = "Sueldo " & vbCrLf & "Diario"
            .Columns("Días Trabajados").Header.Caption = "Días " & vbCrLf & "Trabajados"
            .Columns("Días Aguinaldo").Header.Caption = "Días " & vbCrLf & "Aguinaldo"
            .Columns("Importe Aguinaldo").Header.Caption = "Importe " & vbCrLf & "Aguinaldo"
            .Columns("Retención ISR Aguinaldo").Header.Caption = "Retención " & vbCrLf & "ISR Aguinaldo"
            .Columns("Aguinaldo Neto").Header.Caption = "Aguinaldo " & vbCrLf & "Neto"
            .Columns("Aguinaldo Excento 30 S.M.A.G.").Header.Caption = "Aguinaldo " & vbCrLf & "Excento " & vbCrLf & "30 S.M.A.G."
            .Columns("Aguinaldo Excento").Header.Caption = "Aguinaldo " & vbCrLf & "Excento"
            .Columns("Aguinaldo Gravado").Header.Caption = "Aguinaldo " & vbCrLf & "Gravado"
            .Columns("Años Laborados").Header.Caption = "Años " & vbCrLf & "Laborados"
            .Columns("Días Vacaciones").Header.Caption = "Días " & vbCrLf & "Vacaciones"
            .Columns("Importe Vacaciones").Header.Caption = "Importe " & vbCrLf & "Vacaciones"
            .Columns("Importe Prima Vacacional").Header.Caption = "Importe " & vbCrLf & "Prima " & vbCrLf & "Vacacional"
            .Columns("Prima vacacional exenta").Header.Caption = "Prima " & vbCrLf & "vacacional " & vbCrLf & "exenta"
            .Columns("Prima vacacional gravada").Header.Caption = "Prima " & vbCrLf & "vacacional " & vbCrLf & "gravada"
            .Columns("Retención ISR Vacaciones").Header.Caption = "Retención " & vbCrLf & "ISR " & vbCrLf & "Vacaciones"
            .Columns("Neto Vacaciones").Header.Caption = "Neto " & vbCrLf & "Vacaciones"
            .Columns("Retención ISR").Header.Caption = "Retención " & vbCrLf & "ISR"
            .Columns("Neto a Recibir").Header.Caption = "Neto a " & vbCrLf & "Recibir"
            grdListado.DisplayLayout.Bands(0).PerformAutoResizeColumns(True, PerformAutoSizeType.AllRowsInBand, True)

            .Columns("Clave").Width = 45
            '.Columns("Nombre del trabajador").Width = 295
            '.Columns("NSS").Width = 80
            '.Columns("RFC").Width = 100
            '.Columns("CURP").Width = 130
            '.Columns("Fecha de ingreso").Width = 70
            '.Columns("Sueldo Diario").Width = 65
            '.Columns("Días Trabajados").Width = 65
            '.Columns("Días Aguinaldo").Width = 65
            '.Columns("Importe Aguinaldo").Width = 65
            '.Columns("Aguinaldo Excento 30 S.M.A.G.").Width = 65
            '.Columns("Aguinaldo Excento").Width = 65
            '.Columns("Aguinaldo Gravado").Width = 65
            '.Columns("Retención ISR").Width = 65
            '.Columns("Neto a Recibir").Width = 65
        End With

        grdListado.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdListado.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        calcular()
    End Sub

    Private Sub calcular()
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.AguinaldoVacacionesBU
        Dim dtResultado As New DataTable
        Dim objMensaje As New Tools.AdvertenciaForm
        Dim mensajeConfirmar As New Tools.ConfirmarForm
        Dim soloVacaciones As Integer

        Try
            If validarFiltros() Then
                mensajeConfirmar.mensaje = "Se eliminará el calculo anterior. ¿Desea continuar? "
                If mensajeConfirmar.ShowDialog = DialogResult.OK Then
                    If validarAnio() Then
                        If cmbPeriodo.Text = "SEMANA SANTA" Then
                            soloVacaciones = 1
                        Else
                            soloVacaciones = 0
                        End If
                        objBU.calcularAguinaldoVacaciones(dtpFechaCalculo.Value, cmbEmpresa.SelectedValue, rdoPorLey.Checked, soloVacaciones)

                        cargarListado()
                    Else
                        objMensaje.mensaje = "Ya no se puede recalcular debido a que el calculo ya se envio a por timbrar."
                        objMensaje.ShowDialog()
                    End If
                End If
            End If
        Catch ex As Exception
            objMensaje.mensaje = ex.Message()
            objMensaje.ShowDialog()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        Try
            If validarFiltros() Then
                If grdListado.Rows.Count > 0 Then
                    Dim objBU As New Negocios.AguinaldoVacacionesBU
                    Dim existenTimbres As Boolean = False

                    existenTimbres = objBU.validaTimbreFiscalesCompletos(cmbEmpresa.SelectedValue, CInt(cmbAnio.Text))
                    If existenTimbres Then
                        Dim mensajeConfirmar As New ConfirmarForm
                        mensajeConfirmar.mensaje = "Existen recibos que aún falta timbrar. ¿Desea generar el reporte de aguinaldo y vacaciones? "
                        If mensajeConfirmar.ShowDialog = DialogResult.OK Then
                            If cmbPeriodo.Text = "NAVIDAD" Then
                                imprimirReporte()
                            Else
                                imprimirReporteSemanaSanta()
                            End If
                        End If
                    Else
                        If cmbPeriodo.Text = "NAVIDAD" Then
                            imprimirReporte()
                        Else
                            imprimirReporteSemanaSanta()
                        End If
                    End If
                Else
                    objMensajeAdv.mensaje = "No hay información para imprimir."
                    objMensajeAdv.ShowDialog()
                End If
            End If

        Catch ex As Exception
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "Intente nuevamente."
            objMensaje.ShowDialog()
        End Try
    End Sub

    Private Sub imprimirReporte()
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objBU As New Negocios.CorteNominaFiscalBU
        Dim dtEmpresa As New DataTable
        Dim empresa As String = String.Empty
        Dim rfc As String = String.Empty
        Dim regPatronal As String = String.Empty
        Dim domicilio As String = String.Empty


        Try
            dtEmpresa = objBU.datosEmpresa(0, cmbEmpresa.SelectedValue)
            If Not dtEmpresa Is Nothing Then
                If dtEmpresa.Rows.Count > 0 Then
                    empresa = dtEmpresa.Rows(0).Item("empresa")
                    regPatronal = dtEmpresa.Rows(0).Item("regPatronal")
                    rfc = dtEmpresa.Rows(0).Item("rfc")
                    domicilio = dtEmpresa.Rows(0).Item("domicilio")
                Else
                    objMensajeAdv.mensaje = "No se pudo recuperar la información de la empresa."
                    objMensajeAdv.ShowDialog()
                    Exit Sub
                End If
            Else
                objMensajeAdv.mensaje = "No se pudo recuperar la información de la empresa."
                objMensajeAdv.ShowDialog()
                Exit Sub
            End If

            Dim objReporte As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            Dim reporte As New StiReport
            EntidadReporte = objReporte.LeerReporteporClave("REPORTE_AGUINALDO_VACACIONES")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & EntidadReporte.Pnombre.Trim & ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

            reporte.Load(archivo)
            reporte.Compile()

            Dim dtListado = New DataTable("dtAguinaldosVacaciones")
            With dtListado
                .Columns.Add("Codigo")
                .Columns.Add("Nombre")
                .Columns.Add("NSS")
                .Columns.Add("Rfc")
                .Columns.Add("Curp")
                .Columns.Add("FechaIngeso")
                .Columns.Add("SalarioDiario")
                .Columns.Add("DiasAguinaldo")
                .Columns.Add("ImporteAguinaldo")
                .Columns.Add("RetencionIsrAguinaldo")
                .Columns.Add("AguinaldoNeto")
                .Columns.Add("AñosLaborados")
                .Columns.Add("DiasVacaciones")
                .Columns.Add("ImporteVacaciones")
                .Columns.Add("ImportePrimaVacaciones")
                .Columns.Add("RetencionIsrVacaciones")
                .Columns.Add("VacacionesNeto")
                .Columns.Add("RetencionIsr")
                .Columns.Add("NetoRecibir")
                .Columns.Add("FolioFiscal")
            End With

            For Each item As UltraGridRow In grdListado.Rows
                dtListado.Rows.Add(
                    item.Cells("Clave").Value.ToString(),
                    item.Cells("Nombre del trabajador").Value.ToString(),
                    item.Cells("NSS").Value.ToString(),
                    item.Cells("RFC").Value.ToString(),
                    item.Cells("CURP").Value.ToString(),
                    CDate(item.Cells("Fecha de ingreso").Value.ToString()),
                    CDbl(item.Cells("Sueldo Diario").Value.ToString()),
                    CDbl(item.Cells("Días Aguinaldo").Value.ToString()),
                    CDbl(item.Cells("Importe Aguinaldo").Value.ToString()),
                    CDbl(item.Cells("Retención ISR Aguinaldo").Value.ToString()),
                    CDbl(item.Cells("Aguinaldo Neto").Value.ToString()),
                    CDbl(item.Cells("Años Laborados").Value.ToString()),
                    CDbl(item.Cells("Días Vacaciones").Value.ToString()),
                    CDbl(item.Cells("Importe Vacaciones").Value.ToString()),
                    CDbl(item.Cells("Importe Prima Vacacional").Value.ToString()),
                    CDbl(item.Cells("Retención ISR Vacaciones").Value.ToString()),
                    CDbl(item.Cells("Neto Vacaciones").Value.ToString()),
                    CDbl(item.Cells("Retención ISR").Value.ToString()),
                    CDbl(item.Cells("Neto a Recibir").Value.ToString()),
                    item.Cells("Folio Fiscal").Value.ToString()
                )
            Next

            reporte("Empresa") = empresa
            reporte("rfc") = rfc
            reporte("regPatronal") = regPatronal
            reporte("domicilioFiscal") = domicilio
            reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            reporte("Año") = CInt(cmbAnio.Text)

            reporte.RegData(dtListado)
            reporte.Show()
            'reporte.Render()
        Catch ex As Exception
            objMensajeError.mensaje = "Error al imprimir."
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel()
    End Sub

    Private Sub exportarExcel()
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm

        If validarFiltros() Then
            If grdListado.Rows.Count > 0 Then
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
                            grdListado.DisplayLayout.UseFixedHeaders = False
                            grdListado.DisplayLayout.Bands(0).Columns.Add("#")
                            grdListado.DisplayLayout.Bands(0).Columns("#").Header.VisiblePosition = 0
                            grdListado.DisplayLayout.Bands(0).Columns("#").Width = 30
                            'grdListado.DisplayLayout.Bands(0).Columns("Días Trabajados").Hidden = True
                            'grdListado.DisplayLayout.Bands(0).Columns("Aguinaldo Excento 30 S.M.A.G.").Hidden = True
                            'grdListado.DisplayLayout.Bands(0).Columns("Aguinaldo Excento").Hidden = True
                            'grdListado.DisplayLayout.Bands(0).Columns("Aguinaldo Gravado").Hidden = True
                            'grdListado.DisplayLayout.Bands(0).Columns("Prima vacacional exenta").Hidden = True
                            'grdListado.DisplayLayout.Bands(0).Columns("Prima vacacional gravada").Hidden = True

                            For Each row As UltraGridRow In grdListado.Rows
                                row.Cells("#").Value = row.Index + 1
                            Next

                            Dim fecha_hora As String = Date.Now.ToString("yyyyMMdd_Hmmss")
                            archivo = "ReporteAguinaldoVacaciones_" & fecha_hora & ".xlsx"
                            gridExcelExporter.Export(grdListado, .SelectedPath & "\" & archivo)

                            grdListado.DisplayLayout.UseFixedHeaders = True
                            grdListado.DisplayLayout.Bands(0).Columns("Clave").Header.Fixed = True
                            grdListado.DisplayLayout.Bands(0).Columns("Nombre del trabajador").Header.Fixed = True
                            grdListado.DisplayLayout.Bands(0).Columns("NSS").Header.Fixed = True
                            'grdListado.DisplayLayout.Bands(0).Columns("Días Trabajados").Hidden = False
                            'grdListado.DisplayLayout.Bands(0).Columns("Aguinaldo Excento 30 S.M.A.G.").Hidden = False
                            'grdListado.DisplayLayout.Bands(0).Columns("Aguinaldo Excento").Hidden = False
                            'grdListado.DisplayLayout.Bands(0).Columns("Aguinaldo Gravado").Hidden = False
                            'grdListado.DisplayLayout.Bands(0).Columns("Prima vacacional exenta").Hidden = False
                            'grdListado.DisplayLayout.Bands(0).Columns("Prima vacacional gravada").Hidden = False
                            grdListado.DisplayLayout.Bands(0).Columns.Remove("#")

                            objMensajeExito.mensaje = "Los datos se exportaron correctamente al archivo " & archivo
                            objMensajeExito.ShowDialog()
                            Try
                                Process.Start(.SelectedPath & "\" & archivo)
                            Catch ex As Exception
                            End Try

                        End If
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
        End If
    End Sub

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeExito As New Tools.ExitoForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeConfirmar As New Tools.ConfirmarForm
        Dim objBU As New Negocios.AguinaldoVacacionesBU
        Dim resultado As String = String.Empty
        Dim soloVacaciones As Integer

        If cmbPeriodo.Text = "SEMANA SANTA" Then
            soloVacaciones = 1
        Else
            soloVacaciones = 0
        End If

        Try
            If validarFiltros() Then
                If grdListado.Rows.Count > 0 Then
                    If validarAnio() Then
                        objMensajeConfirmar.mensaje = "Despues de autorizar ya no se podrá recalcular ni hacer modificaciones. ¿Desea continuar? "
                        If objMensajeConfirmar.ShowDialog = DialogResult.OK Then
                            Dim form As New FechaPagoForm
                            If Not CheckForm(form) Then
                                form.dtpFechaPago.MinDate = dtpFechaCalculo.MinDate
                                form.dtpFechaPago.MaxDate = dtpFechaCalculo.MaxDate
                                form.ShowDialog()
                                If form.cerrado Then
                                    objMensajeAdv.mensaje = "Debe ingresar la fecha de pago."
                                    objMensajeAdv.ShowDialog()
                                    Exit Sub
                                End If
                            End If
                            Me.Cursor = Cursors.WaitCursor

                            resultado = objBU.enviarTimbrar(cmbEmpresa.SelectedValue, CInt(cmbAnio.Text), form.dtpFechaPago.Value, soloVacaciones)
                            If resultado = "EXITO" Then
                                If insertarCheque() Then
                                    objMensajeExito.mensaje = "Información autorizada correctamente."
                                    objMensajeExito.ShowDialog()
                                Else
                                    objMensajeError.mensaje = "Error al generar los cheques"
                                    objMensajeError.ShowDialog()
                                End If
                            Else
                                objMensajeError.mensaje = "Error al enviar los registros"
                                objMensajeError.ShowDialog()
                            End If
                        End If
                    Else
                        objMensajeAdv.mensaje = "La informacion ya fue previamente autorizada."
                        objMensajeAdv.ShowDialog()
                    End If
                Else
                    objMensajeAdv.mensaje = "No hay información para Autorizar."
                    objMensajeAdv.ShowDialog()
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = ex.Message
            objMensajeError.ShowDialog()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Function insertarCheque() As Boolean
        Dim objBU As New Negocios.AguinaldoVacacionesBU
        Dim dtResultado As New DataTable
        Dim cajaId As Integer
        Dim razonSocial As String = String.Empty
        Dim concepto As String

        If cmbPeriodo.Text = "SEMANA SANTA" Then
            concepto = "VACACIONES SEMANA SANTA "
        Else
            concepto = "AGUINALDO Y VACACIONES "
        End If

        dtResultado = objBU.ConsultarCajaChicaPatron(cmbEmpresa.SelectedValue)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                cajaId = CInt(dtResultado.Rows(0)("CajaChicaId").ToString)
                razonSocial = dtResultado.Rows(0)("RazonSocial").ToString

                For Each row As UltraGridRow In grdListado.Rows
                    objBU.altaVacacionesAguinaldos(cajaId, "CHEQUE", CDbl(row.Cells("Neto a Recibir").Value.ToString), row.Cells("Nombre del trabajador").Value.ToString, concepto & cmbAnio.Text, razonSocial)
                Next
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Function validarAnio() As Boolean
        Dim objBU As New Negocios.AguinaldoVacacionesBU
        Dim dtResultado As New DataTable

        pnlCalcular.Enabled = True
        pnlAutorizar.Enabled = True
        dtpFechaCalculo.Enabled = True
        pnlMetodo.Enabled = True

        dtResultado = objBU.validaAnioTimbrado(cmbEmpresa.SelectedValue, CInt(cmbAnio.Text))
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                If CInt(dtResultado.Rows(0).Item("Timbrados").ToString) > 0 Then
                    lblSalarioMinimo.Text = dtResultado.Rows(0).Item("SalarioMinimo").ToString
                    If dtResultado.Rows(0).Item("FechaCalculo").ToString <> "" Then
                        dtpFechaCalculo.Value = dtResultado.Rows(0).Item("FechaCalculo").ToString
                    End If
                    If dtResultado.Rows(0).Item("Tipo").ToString = "L" Then
                        rdoPorLey.Checked = True
                    Else
                        rdoPorReglamento.Checked = True
                    End If

                    pnlCalcular.Enabled = False
                    pnlAutorizar.Enabled = False
                    dtpFechaCalculo.Enabled = False
                    pnlMetodo.Enabled = False
                    Return False
                End If
            End If
        End If

        Return True
    End Function

    Private Sub cmbPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPeriodo.SelectedIndexChanged
        Try
            If cmbAnio.Text.ToString <> "" And cmbAnio.Text.ToString <> "System.Data.DataRowView" Then
                Dim objBU As New Negocios.AguinaldoVacacionesBU
                Dim dtResultado As New DataTable
                Dim fechaInicio As Date = "01/01/" & cmbAnio.Text
                Dim fechaFin As Date = "31/12/" & cmbAnio.Text

                dtpFechaCalculo.MinDate = DateTimePicker.MinimumDateTime
                dtpFechaCalculo.MaxDate = DateTimePicker.MaximumDateTime
                dtpFechaCalculo.MinDate = fechaInicio
                dtpFechaCalculo.MaxDate = fechaFin

                If cmbPeriodo.Text = "SEMANA SANTA" Then
                    dtpFechaCalculo.Value = Date.Now
                Else
                    dtpFechaCalculo.Value = fechaFin
                End If

                validarAnio()
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub imprimirReporteSemanaSanta()
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objBU As New Negocios.CorteNominaFiscalBU
        Dim dtEmpresa As New DataTable
        Dim empresa As String = String.Empty
        Dim rfc As String = String.Empty
        Dim regPatronal As String = String.Empty
        Dim domicilio As String = String.Empty


        Try
            dtEmpresa = objBU.datosEmpresa(0, cmbEmpresa.SelectedValue)
            If Not dtEmpresa Is Nothing Then
                If dtEmpresa.Rows.Count > 0 Then
                    empresa = dtEmpresa.Rows(0).Item("empresa")
                    regPatronal = dtEmpresa.Rows(0).Item("regPatronal")
                    rfc = dtEmpresa.Rows(0).Item("rfc")
                    domicilio = dtEmpresa.Rows(0).Item("domicilio")
                Else
                    objMensajeAdv.mensaje = "No se pudo recuperar la información de la empresa."
                    objMensajeAdv.ShowDialog()
                    Exit Sub
                End If
            Else
                objMensajeAdv.mensaje = "No se pudo recuperar la información de la empresa."
                objMensajeAdv.ShowDialog()
                Exit Sub
            End If

            Dim objReporte As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            Dim reporte As New StiReport
            EntidadReporte = objReporte.LeerReporteporClave("REPORTE_VACA_FISCAL")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & EntidadReporte.Pnombre.Trim & ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

            reporte.Load(archivo)
            reporte.Compile()

            Dim dtListado = New DataTable("dtAguinaldosVacaciones")
            With dtListado
                .Columns.Add("Codigo")
                .Columns.Add("Nombre")
                .Columns.Add("NSS")
                .Columns.Add("Rfc")
                .Columns.Add("Curp")
                .Columns.Add("FechaIngeso")
                .Columns.Add("SalarioDiario")
                .Columns.Add("DiasAguinaldo")
                .Columns.Add("ImporteAguinaldo")
                .Columns.Add("RetencionIsrAguinaldo")
                .Columns.Add("AguinaldoNeto")
                .Columns.Add("AñosLaborados")
                .Columns.Add("DiasVacaciones")
                .Columns.Add("ImporteVacaciones")
                .Columns.Add("ImportePrimaVacaciones")
                .Columns.Add("RetencionIsrVacaciones")
                .Columns.Add("VacacionesNeto")
                .Columns.Add("RetencionIsr")
                .Columns.Add("NetoRecibir")
                .Columns.Add("FolioFiscal")
            End With

            For Each item As UltraGridRow In grdListado.Rows
                dtListado.Rows.Add(
                    item.Cells("Clave").Value.ToString(),
                    item.Cells("Nombre del trabajador").Value.ToString(),
                    item.Cells("NSS").Value.ToString(),
                    item.Cells("RFC").Value.ToString(),
                    item.Cells("CURP").Value.ToString(),
                    CDate(item.Cells("Fecha de ingreso").Value.ToString()),
                    CDbl(item.Cells("Sueldo Diario").Value.ToString()),
                    CDbl(item.Cells("Días Aguinaldo").Value.ToString()),
                    CDbl(item.Cells("Importe Aguinaldo").Value.ToString()),
                    CDbl(item.Cells("Retención ISR Aguinaldo").Value.ToString()),
                    CDbl(item.Cells("Aguinaldo Neto").Value.ToString()),
                    CDbl(item.Cells("Años Laborados").Value.ToString()),
                    CDbl(item.Cells("Días Vacaciones").Value.ToString()),
                    CDbl(item.Cells("Importe Vacaciones").Value.ToString()),
                    CDbl(item.Cells("Importe Prima Vacacional").Value.ToString()),
                    CDbl(item.Cells("Retención ISR Vacaciones").Value.ToString()),
                    CDbl(item.Cells("Neto Vacaciones").Value.ToString()),
                    CDbl(item.Cells("Retención ISR").Value.ToString()),
                    CDbl(item.Cells("Neto a Recibir").Value.ToString()),
                    item.Cells("Folio Fiscal").Value.ToString()
                )
            Next

            reporte("Empresa") = empresa
            reporte("rfc") = rfc
            reporte("regPatronal") = regPatronal
            reporte("domicilioFiscal") = domicilio
            reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            reporte("Año") = CInt(cmbAnio.Text)

            reporte.RegData(dtListado)
            reporte.Show()
            'reporte.Render()
        Catch ex As Exception
            objMensajeError.mensaje = "Error al imprimir."
            objMensajeError.ShowDialog()
        End Try
    End Sub
End Class