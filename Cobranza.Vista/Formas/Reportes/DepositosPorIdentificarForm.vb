Imports System.Drawing
Imports System.Windows.Forms
Imports Cobranza.Negocios
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Framework.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Stimulsoft.Report
Imports Tools

Public Class DepositosPorIdentificarForm
    Dim lstInicial As New List(Of String)
    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        obtenerCuentasRazonSocial()
    End Sub
    Private Sub obtenerCuentasRazonSocial()
        Dim objResumenCuenta As New DepositosNoIdentificadosBU
        Dim dtResumenCuenta As New DataTable
        Dim fechaInicio As Date = dtpFechaInicio.Text
        Dim fechaFinal As Date = dtpFechaFinal.Text
        Dim cuentasIdsRazonSocial As String = llenarFiltrosCuentaRazonSocial(grdCuentaRazSocial)
        If grdCuentaRazSocial.Rows.Count = 0 Then
            cuentasIdsRazonSocial = ""
        End If
        dtResumenCuenta = objResumenCuenta.obtenerResumenCuentasRazonSocial(fechaInicio, fechaFinal, cuentasIdsRazonSocial)
        If dtResumenCuenta.Rows.Count > 0 Then
            grdDepositosNoIdentificados.DataSource = dtResumenCuenta
            diseñoGridCuentas(wvDepositosNoIdentificados)
            lblRegistros.Text = dtResumenCuenta.Rows.Count
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No existen registros para esta(s) cuenta(s).")
            grdDepositosNoIdentificados.DataSource = Nothing
            wvDepositosNoIdentificados.Columns.Clear()
        End If
    End Sub
    Private Sub diseñoGridCuentas(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Tools.DiseñoGrid.AlternarColorEnFilas(wvDepositosNoIdentificados)
        ''Grid.OptionsView.ColumnAutoWidth = False
        '' Grid.BestFitColumns()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvDepositosNoIdentificados.Columns
            If col.FieldName = "Movimiento" Then
                col.Visible = False
            End If
            If col.FieldName = "Cuenta" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 110
            End If
            If col.FieldName = "Razón Social" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 297
            End If
            If col.FieldName = "Fecha" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 93
            End If
            If col.FieldName = "Descripción" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 770
            End If
            If col.FieldName = "Importe" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 110
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "{0:N2}"
            End If
            If col.FieldName = "Observaciones" Then
                col.Width = 250
            End If
        Next

        Dim editTextTipo As New RepositoryItemTextEdit()
        editTextTipo.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        editTextTipo.Mask.EditMask = "([A-Z]|[0-9]|\s|\u00D1|\p{P})+"
        wvDepositosNoIdentificados.Columns.ColumnByFieldName("Observaciones").ColumnEdit = editTextTipo

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvDepositosNoIdentificados.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvDepositosNoIdentificados.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName.Contains("Importe") Then
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Importe")) = True And col.FieldName = "Importe" Then
                    col.Summary.Clear()
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
            End If
        Next
        Grid.IndicatorWidth = 30
    End Sub
    Private Sub wvDepositosNoIdentificados_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles wvDepositosNoIdentificados.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiaFormularioCuentas()
    End Sub
    Private Sub limpiaFormularioCuentas()
        dtpFechaInicio.Value = Today
        dtpFechaFinal.Value = Today
        grdDepositosNoIdentificados.DataSource = Nothing
        wvDepositosNoIdentificados.Columns.Clear()
        lblRegistros.Text = 0
        grdCuentaRazSocial.DataSource = lstInicial
        grdCuentaRazSocial.DataSource = Nothing
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlAcciones.Height = 32
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlAcciones.Height = 180
    End Sub
    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        imprimirReporteResumenCuentas()
    End Sub
    Private Sub imprimirReporteResumenCuentas()
        Dim objResumenCuenta As New DepositosNoIdentificadosBU
        Dim dtResumenCuenta As New DataTable
        Dim fechaInicio As Date = dtpFechaInicio.Text
        Dim fechaFinal As Date = dtpFechaFinal.Text
        Dim cuentasIdsRazonSocial As String = llenarFiltrosCuentaRazonSocial(grdCuentaRazSocial)
        If wvDepositosNoIdentificados.RowCount > 0 Then
            If grdCuentaRazSocial.Rows.Count = 0 Then
                cuentasIdsRazonSocial = ""
            End If
            dtResumenCuenta = objResumenCuenta.obtenerResumenCuentasRazonSocial_ImprimirReporte(fechaInicio, fechaFinal, cuentasIdsRazonSocial)
            If dtResumenCuenta.Rows.Count > 0 Then
                formatoReporteCuentasNoDepositadas(dtResumenCuenta)
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay información para imprimir el reporte.")
        End If
    End Sub
    Private Sub formatoReporteCuentasNoDepositadas(ByVal dtReporteCuentas As DataTable)
        Dim dsDatosReporteCuentas As New DataSet("dtCtaNoIdentificados")
        Dim dtReporte As New DataTable
        Try
            Me.Cursor = Cursors.WaitCursor
            dtReporte = dtReporteCuentas
            dtReporteCuentas.TableName = "dtCtaNoIdentificados"
            dsDatosReporteCuentas.Tables.Add(dtReporteCuentas)

            Dim objConsultaReporteCuentas As New ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            EntidadReporte = objConsultaReporteCuentas.LeerReporteporClave("RPT_CUENTAS_NO_IDENTIFICADAS")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                   EntidadReporte.Pnombre
            My.Computer.FileSystem.WriteAllText(archivo + ".mrt", EntidadReporte.Pxml, False)
            Dim reporteCobranza As New StiReport
            reporteCobranza.Load((archivo + ".mrt"))
            reporteCobranza.Compile()
            reporteCobranza("fechaInicio") = dtpFechaInicio.Value
            reporteCobranza("fechaFinal") = dtpFechaFinal.Value
            reporteCobranza.RegData(dsDatosReporteCuentas)
            reporteCobranza.Render()
            reporteCobranza.Show()
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        If dtpFechaFinal.Value < dtpFechaInicio.Value Then
            dtpFechaFinal.Value = dtpFechaInicio.Value
        End If
        dtpFechaFinal.MinDate = dtpFechaInicio.Value
    End Sub
    Private Sub wvDepositosNoIdentificados_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles wvDepositosNoIdentificados.CellValueChanged
        Dim observaciones As String
        Dim movimientoId As Integer = 0
        Dim objActualizaObservaciones As New DepositosNoIdentificadosBU
        If e.Column.FieldName = "Observaciones" Then
            movimientoId = CInt(wvDepositosNoIdentificados.GetDataRow(wvDepositosNoIdentificados.FocusedRowHandle).Item("Movimiento"))
            observaciones = e.Value
            objActualizaObservaciones.registraObservaciones(observaciones, movimientoId)
        End If
    End Sub
    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarInformacionToExcel()
    End Sub
    Private Sub exportarInformacionToExcel()
        Dim fechaInicio As Date = dtpFechaInicio.Text
        Dim fechaFinal As Date = dtpFechaFinal.Text
        If wvDepositosNoIdentificados.DataRowCount > 0 Then
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvDepositosNoIdentificados.Columns
                col.AppearanceHeader.BackColor = Color.LightSkyBlue
            Next
            Tools.Excel.ExportarExcel(wvDepositosNoIdentificados, "Depósitos no identificados")
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay información para exportar.")
        End If
    End Sub
    Private Sub DepositosPorIdentificarForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            imprimirReporteResumenCuentas()
        End If
        If e.KeyCode = Keys.F9 Then
            exportarInformacionToExcel()
        End If
        If e.KeyCode = Keys.F1 Then
            abrirListadoRazonSocial()
        End If
        If e.KeyCode = Keys.F5 Then
            obtenerCuentasRazonSocial()
        End If
    End Sub
    Private Sub btnAgregarRacSocEmisor_Click(sender As Object, e As EventArgs) Handles btnAgregarRacSocEmisor.Click
        abrirListadoRazonSocial()
    End Sub
    Private Sub abrirListadoRazonSocial()
        Dim listado As New ListadoParametrosProyeccionCobranza
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCuentaRazSocial.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.tipo_busqueda = 7
        listado.listaParametroId = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        grdCuentaRazSocial.DataSource = listado.listaParametros
        With grdCuentaRazSocial
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Width = 350
        End With
    End Sub
    Private Sub btnLimpiarRacZocEmisor_Click(sender As Object, e As EventArgs) Handles btnLimpiarRacZocEmisor.Click
        grdCuentaRazSocial.DataSource = lstInicial
        grdCuentaRazSocial.DataSource = Nothing
    End Sub
    Private Sub grdCuentaRazSocial_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdCuentaRazSocial.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
    Private Function llenarFiltrosCuentaRazonSocial(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid) As String
        Dim lista As New List(Of Integer)
        For Each Row As UltraGridRow In grid.Rows
            If Row.Cells(0).Value Then lista.Add(Row.Cells(1).Value)
        Next
        Return String.Join(",", lista).ToString
    End Function

    Private Sub DepositosPorIdentificarForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class