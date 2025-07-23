Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid

Public Class ReporteSalidaNavesProduccionForm

    Private objBU As New Negocios.SalidaNavesProduccion_ConsultasFiltrosBU

    Private _EntidadFiltros As Entidades.FiltrosSalidaNavesProduccion
    Public Property EntidadFiltros() As Entidades.FiltrosSalidaNavesProduccion
        Get
            Return _EntidadFiltros
        End Get
        Set(ByVal value As Entidades.FiltrosSalidaNavesProduccion)
            _EntidadFiltros = value
        End Set
    End Property

    Private Sub ReporteSalidaNavesProduccionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = _EntidadFiltros.TipoConsulta

        Me.Cursor = Cursors.WaitCursor
        CargarGrid()
        Me.Cursor = Cursors.Default

        Select Case _EntidadFiltros.TipoConsulta
            Case "Detallada (Por Par)"
                lblSubtititulo.Text = "Detallada (Por Par)"
            Case "Auditoría de Entradas (Por CEDIS)"
                lblSubtititulo.Text = "(Por CEDIS)"
        End Select

    End Sub

    Private Sub CargarGrid()
        Dim dtSalidasNaves As DataTable
        Try
            dtSalidasNaves = objBU.ConsultarSalidasNavesProduccion(_EntidadFiltros)
            grdSalidaNaves.DataSource = dtSalidasNaves

            Select Case _EntidadFiltros.TipoConsulta
                Case "Detallada (Por Par)"
                    pnlConsultaDetallada.Visible = True
                    pnlConsultaPorCedis.Visible = False

                    lblPar.Text = dtSalidasNaves.Select("Tipo = 'P'").Count.ToString("N0")
                    lblAtado.Text = dtSalidasNaves.Select("Tipo = 'A'").Count.ToString("N0")
                    lblError.Text = dtSalidasNaves.Select("Tipo = 'E'").Count.ToString("N0")

                    lblTotal.Text = "Total Pares: " + dtSalidasNaves.Rows.Count.ToString("N0")
                    lblUltimaActualizacion.Text = Date.Now

                Case "Auditoría de Entradas (Por CEDIS)"
                    pnlConsultaDetallada.Visible = False
                    pnlConsultaPorCedis.Visible = True

                    Dim tabla As New DataTable
                    tabla.Columns.Add("Entrega", Type.GetType("System.String"))
                    tabla.Columns.Add("EMD", Type.GetType("System.String"))
                    tabla.Columns.Add("Descripción", Type.GetType("System.String"))

                    Dim Row = tabla.NewRow
                    Row.Item("Entrega") = "COMPLETA"
                    Row.Item("EMD") = "SI"
                    Row.Item("Descripción") = "Ya se entregó el folio, el mismo día de salida de la nave"
                    tabla.Rows.Add(Row)

                    Row = tabla.NewRow
                    Row.Item("Entrega") = "COMPLETA"
                    Row.Item("EMD") = "NO"
                    Row.Item("Descripción") = "Ya se entregó el folio, en diferente día de salida de la nave"
                    tabla.Rows.Add(Row)

                    Row = tabla.NewRow
                    Row.Item("Entrega") = "PARCIAL"
                    Row.Item("EMD") = ""
                    Row.Item("Descripción") = "Aún no se termina de entregar en CEDIS"
                    tabla.Rows.Add(Row)

                    grid.DataSource = tabla
                    gridV.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
                    gridV.OptionsSelection.EnableAppearanceFocusedCell = False
                    gridV.OptionsSelection.EnableAppearanceFocusedRow = False
                    gridV.OptionsSelection.EnableAppearanceHideSelection = False
                    If dtSalidasNaves.Rows.Count > 0 Then
                        lblTotal.Text = "Total Pares Embarcados: " + CInt(dtSalidasNaves.Compute("SUM(Embarcado)", "")).ToString("N0")
                    End If
                    lblUltimaActualizacion.Text = Date.Now

            End Select

            DiseñarGrid(grdVSalidaNaves)
            DiseñarGridV(gridV)
            AplicarReglasFormatoGrid(grdVSalidaNaves, _EntidadFiltros.TipoConsulta)
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub DiseñarGrid(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        'Grid.OptionsView.BestFitMaxRowCount = -1
        Grid.OptionsView.ColumnAutoWidth = False
        Grid.BestFitColumns()

        Grid.IndicatorWidth = 30

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsColumn.AllowEdit = False
            col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Next

        Grid.Columns.ColumnByFieldName("FechaSalida(Hr)").DisplayFormat.FormatType = FormatType.DateTime
        Grid.Columns.ColumnByFieldName("FechaSalida(Hr)").DisplayFormat.FormatString = "dd/MM/yyyy h:mm:ss tt"
        Grid.Columns.ColumnByFieldName("FechaEntrada(Hr)").DisplayFormat.FormatType = FormatType.DateTime
        Grid.Columns.ColumnByFieldName("FechaEntrada(Hr)").DisplayFormat.FormatString = "dd/MM/yyyy h:mm:ss tt"

    End Sub

    Private Sub DiseñarGridV(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        'Grid.OptionsView.BestFitMaxRowCount = -1
        Grid.OptionsView.ColumnAutoWidth = False
        Grid.BestFitColumns()

        Grid.IndicatorWidth = 30

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsColumn.AllowEdit = False
            col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Next

    End Sub


    Private Sub AplicarReglasFormatoGrid(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView, TipoConsulta As String)
        Dim gridFormatRule As DevExpress.XtraGrid.GridFormatRule
        Dim formatConditionRuleExpression As DevExpress.XtraEditors.FormatConditionRuleExpression

        Select Case TipoConsulta
            Case "Detallada (Por Par)"

                gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
                gridFormatRule.Column = Grid.Columns.ColumnByFieldName("Proceso")
                gridFormatRule.ApplyToRow = True

                formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
                formatConditionRuleExpression.PredefinedName = "Light Text"
                formatConditionRuleExpression.Expression = "[Proceso] = 'TRÁNSITO'"
                formatConditionRuleExpression.Appearance.BackColor = pnlColorEmbarcado.BackColor

                gridFormatRule.Rule = formatConditionRuleExpression
                Grid.FormatRules.Add(gridFormatRule)


                gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
                gridFormatRule.Column = Grid.Columns.ColumnByFieldName("Tipo")
                gridFormatRule.ColumnApplyTo = Grid.Columns.ColumnByFieldName("Tipo")

                formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
                formatConditionRuleExpression.PredefinedName = "Light Text"
                formatConditionRuleExpression.Expression = "[Tipo] = 'P'"
                formatConditionRuleExpression.Appearance.BackColor = pnlColorPar.BackColor

                gridFormatRule.Rule = formatConditionRuleExpression
                Grid.FormatRules.Add(gridFormatRule)


                gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
                gridFormatRule.Column = Grid.Columns.ColumnByFieldName("Tipo")
                gridFormatRule.ColumnApplyTo = Grid.Columns.ColumnByFieldName("Tipo")

                formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
                formatConditionRuleExpression.PredefinedName = "Light Text"
                formatConditionRuleExpression.Expression = "[Tipo] = 'A'"
                formatConditionRuleExpression.Appearance.BackColor = pnlColorAtado.BackColor

                gridFormatRule.Rule = formatConditionRuleExpression
                Grid.FormatRules.Add(gridFormatRule)


                gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
                gridFormatRule.Column = Grid.Columns.ColumnByFieldName("Tipo")
                gridFormatRule.ColumnApplyTo = Grid.Columns.ColumnByFieldName("Tipo")

                formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
                formatConditionRuleExpression.PredefinedName = "Light Text"
                formatConditionRuleExpression.Expression = "[Tipo] = 'E'"
                formatConditionRuleExpression.Appearance.BackColor = pnlColorError.BackColor

                gridFormatRule.Rule = formatConditionRuleExpression
                Grid.FormatRules.Add(gridFormatRule)


                gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
                gridFormatRule.Column = Grid.Columns.ColumnByFieldName("D")
                gridFormatRule.ColumnApplyTo = Grid.Columns.ColumnByFieldName("D")

                formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
                formatConditionRuleExpression.PredefinedName = "Light Text"
                formatConditionRuleExpression.Expression = "[D] = '1'"
                formatConditionRuleExpression.Appearance.BackColor = pnlColorDisponible.BackColor

                gridFormatRule.Rule = formatConditionRuleExpression
                Grid.FormatRules.Add(gridFormatRule)


                gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
                gridFormatRule.Column = Grid.Columns.ColumnByFieldName("A")
                gridFormatRule.ColumnApplyTo = Grid.Columns.ColumnByFieldName("A")

                formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
                formatConditionRuleExpression.PredefinedName = "Light Text"
                formatConditionRuleExpression.Expression = "[A] = '1'"
                formatConditionRuleExpression.Appearance.BackColor = pnlColorAsignado.BackColor

                gridFormatRule.Rule = formatConditionRuleExpression
                Grid.FormatRules.Add(gridFormatRule)


                gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
                gridFormatRule.Column = Grid.Columns.ColumnByFieldName("B")
                gridFormatRule.ColumnApplyTo = Grid.Columns.ColumnByFieldName("B")

                formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
                formatConditionRuleExpression.PredefinedName = "Light Text"
                formatConditionRuleExpression.Expression = "[B] = '1'"
                formatConditionRuleExpression.Appearance.BackColor = pnlColorBloqueado.BackColor

                gridFormatRule.Rule = formatConditionRuleExpression
                Grid.FormatRules.Add(gridFormatRule)


                gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
                gridFormatRule.Column = Grid.Columns.ColumnByFieldName("R")
                gridFormatRule.ColumnApplyTo = Grid.Columns.ColumnByFieldName("R")

                formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
                formatConditionRuleExpression.PredefinedName = "Light Text"
                formatConditionRuleExpression.Expression = "[R] = '1'"
                formatConditionRuleExpression.Appearance.BackColor = pnlColorReproceso.BackColor

                gridFormatRule.Rule = formatConditionRuleExpression
                Grid.FormatRules.Add(gridFormatRule)


                gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
                gridFormatRule.Column = Grid.Columns.ColumnByFieldName("P")
                gridFormatRule.ColumnApplyTo = Grid.Columns.ColumnByFieldName("P")

                formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
                formatConditionRuleExpression.PredefinedName = "Light Text"
                formatConditionRuleExpression.Expression = "[P] > 0"
                formatConditionRuleExpression.Appearance.BackColor = pnlColorProyectado.BackColor

                gridFormatRule.Rule = formatConditionRuleExpression
                Grid.FormatRules.Add(gridFormatRule)


                gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
                gridFormatRule.Column = Grid.Columns.ColumnByFieldName("EMD")
                gridFormatRule.ColumnApplyTo = Grid.Columns.ColumnByFieldName("EMD")

                formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
                formatConditionRuleExpression.PredefinedName = "Light Text"
                formatConditionRuleExpression.Expression = "[EMD] = 'SI'"
                formatConditionRuleExpression.Appearance.ForeColor = lblColorSI.ForeColor

                gridFormatRule.Rule = formatConditionRuleExpression
                Grid.FormatRules.Add(gridFormatRule)

                gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
                gridFormatRule.Column = Grid.Columns.ColumnByFieldName("EMD")
                gridFormatRule.ColumnApplyTo = Grid.Columns.ColumnByFieldName("EMD")

                formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
                formatConditionRuleExpression.PredefinedName = "Light Text"
                formatConditionRuleExpression.Expression = "[EMD] = 'NO'"
                formatConditionRuleExpression.Appearance.ForeColor = lblColorNO.ForeColor

                gridFormatRule.Rule = formatConditionRuleExpression
                Grid.FormatRules.Add(gridFormatRule)
            Case "Auditoría de Entradas (Por CEDIS)"

                gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
                gridFormatRule.Column = Grid.Columns.ColumnByFieldName("Entrega")
                gridFormatRule.ColumnApplyTo = Grid.Columns.ColumnByFieldName("Entrega")

                formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
                formatConditionRuleExpression.PredefinedName = "Light Text"
                formatConditionRuleExpression.Expression = "[Entrega] = 'COMPLETA' AND [EMD] = 'SI'"
                formatConditionRuleExpression.Appearance.ForeColor = Color.FromArgb(0, 176, 80)

                gridFormatRule.Rule = formatConditionRuleExpression
                Grid.FormatRules.Add(gridFormatRule)

                gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
                gridFormatRule.Column = Grid.Columns.ColumnByFieldName("EMD")
                gridFormatRule.ColumnApplyTo = Grid.Columns.ColumnByFieldName("EMD")

                formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
                formatConditionRuleExpression.PredefinedName = "Light Text"
                formatConditionRuleExpression.Expression = "[Entrega] = 'COMPLETA' AND [EMD] = 'SI'"
                formatConditionRuleExpression.Appearance.ForeColor = Color.FromArgb(0, 176, 80)

                gridFormatRule.Rule = formatConditionRuleExpression
                Grid.FormatRules.Add(gridFormatRule)


                gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
                gridFormatRule.Column = Grid.Columns.ColumnByFieldName("Entrega")
                gridFormatRule.ColumnApplyTo = Grid.Columns.ColumnByFieldName("Entrega")

                formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
                formatConditionRuleExpression.PredefinedName = "Light Text"
                formatConditionRuleExpression.Expression = "[Entrega] = 'COMPLETA' AND [EMD] = 'NO'"
                formatConditionRuleExpression.Appearance.ForeColor = Color.FromArgb(255, 102, 0)

                gridFormatRule.Rule = formatConditionRuleExpression
                Grid.FormatRules.Add(gridFormatRule)


                gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
                gridFormatRule.Column = Grid.Columns.ColumnByFieldName("EMD")
                gridFormatRule.ColumnApplyTo = Grid.Columns.ColumnByFieldName("EMD")

                formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
                formatConditionRuleExpression.PredefinedName = "Light Text"
                formatConditionRuleExpression.Expression = "[Entrega] = 'COMPLETA' AND [EMD] = 'NO'"
                formatConditionRuleExpression.Appearance.ForeColor = Color.FromArgb(255, 102, 0)

                gridFormatRule.Rule = formatConditionRuleExpression
                Grid.FormatRules.Add(gridFormatRule)


                gridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
                gridFormatRule.Column = Grid.Columns.ColumnByFieldName("Entrega")
                gridFormatRule.ApplyToRow = True

                formatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
                formatConditionRuleExpression.PredefinedName = "Light Text"
                formatConditionRuleExpression.Expression = "[Entrega] = 'PARCIAL'"
                formatConditionRuleExpression.Appearance.ForeColor = Color.FromArgb(255, 0, 0)
                formatConditionRuleExpression.Appearance.BackColor = Color.FromArgb(248, 203, 173)

                gridFormatRule.Rule = formatConditionRuleExpression
                Grid.FormatRules.Add(gridFormatRule)
        End Select

    End Sub
    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            ExportarAExcel(grdVSalidaNaves, "AuditoráEEntradasAlmacén_Detallada")
        Catch ex As Exception
            show_message("Error", "Ocurrió un error al exportar la información. " + ex.Message)
        End Try

    End Sub
    Public Sub ExportarAExcel(Grid As DevExpress.XtraGrid.Views.Grid.GridView, NombreArchivo As String)
        'PREGUNTA AL USUARIO DONDE GUARDAR EL ARCHIVO
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
        SaveFileDialog.FilterIndex = 2
        SaveFileDialog.RestoreDirectory = True

        'ASIGNAMOS UN NOMBRE AL ARCHIVO
        SaveFileDialog.FileName = NombreArchivo + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString + ".xlsx"
        If Grid.RowCount > 0 Then
            If SaveFileDialog.ShowDialog = DialogResult.OK Then

                'ESTO ES NECESARIO PARA QUE EL EXCEL NO HAGA QUE TODAS LAS CUADRICULAS SEAN MUY PEQUEÑAS.
                'ESTO EXPORTARÁ TODAS LAS CUADRICULAS ESPACIADAS UNIFORMENTE.
                Grid.OptionsPrint.AutoWidth = False
                Grid.OptionsPrint.UsePrintStyles = False
                'Grid.OptionsPrint.EnableAppearanceEvenRow = True
                'Grid.OptionsPrint.EnableAppearanceOddRow = True
                'Grid.OptionsPrint.PrintHorzLines = False
                'Grid.OptionsPrint.PrintVertLines = False

                'Grid.OptionsPrint.PrintPreview = True

                Dim FileName As String = SaveFileDialog.FileName

                'Dim exportOptions = New DevExpress.XtraPrinting.XlsxExportOptionsEx
                'exportOptions.AllowConditionalFormatting = True
                'exportOptions.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True
                'exportOptions.ExportType = DevExpress.Export.ExportType.DataAware
                DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG
                Grid.ExportToXlsx(FileName)

                show_message("Exito", "Los datos se exportaron correctamente.")

                System.Diagnostics.Process.Start(FileName)
            End If
        Else
            show_message("Exito", "No hay registros para exportar.")
        End If
    End Sub
    Private Sub grdVSalidaNaves_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdVSalidaNaves.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New Tools.AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New Tools.AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New Tools.ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Sub gridV_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles gridV.RowCellStyle
        Dim view As GridView = TryCast(sender, GridView)
        If e.Column.FieldName = "Entrega" Then
            If e.RowHandle = 0 Then
                e.Appearance.ForeColor = Color.FromArgb(0, 176, 80)
            ElseIf e.RowHandle = 1 Then
                e.Appearance.ForeColor = Color.FromArgb(255, 102, 0)
            Else
                e.Appearance.ForeColor = Color.FromArgb(255, 0, 0)
                e.Appearance.BackColor = Color.FromArgb(248, 203, 173)
            End If

        End If
        If e.Column.FieldName = "EMD" Then
            If e.RowHandle = 0 Then
                e.Appearance.ForeColor = Color.FromArgb(0, 176, 80)
            ElseIf e.RowHandle = 1 Then
                e.Appearance.ForeColor = Color.FromArgb(255, 102, 0)
            End If
        End If
    End Sub
    Private Sub btnMostrar_Click_1(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Me.Cursor = Cursors.WaitCursor
        CargarGrid()
        Me.Cursor = Cursors.Default
    End Sub
End Class