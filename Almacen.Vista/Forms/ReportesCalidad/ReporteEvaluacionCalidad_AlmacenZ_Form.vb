Imports DevExpress.XtraGrid.Views.Grid
Imports Tools
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Repository
Imports System.ComponentModel
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraPrinting
Imports DevExpress.Data

Public Class ReporteEvaluacionCalidad_AlmacenZ_Form

    Private ObjBU As New Negocios.ReporteEvaluacionCalidadNaveBU
    Dim SemanaActual As Integer = 0
    Dim emptyEditor As RepositoryItem
    Dim ValorModificado As Boolean = False
    Dim NaveSICY As Integer = 0
    Dim Almacen As Integer = 2

    Private Sub ReporteEvaluacionCalidad_AlmacenZ_Form_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            Cursor = Cursors.WaitCursor
            SemanaActual = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
            lblSemanaActual.Text = SemanaActual
            CargarNaves()
            nudSemanaInicio.Value = SemanaActual
            nudSemanaFinal.Value = SemanaActual
            nudAño.Value = Date.Now.Year
            Me.WindowState = FormWindowState.Maximized
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Throw ex
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim dtResultado As New DataTable
        Dim dtTopIncidencias As New DataTable
        Dim TopIncidencia_1 As String = String.Empty
        Dim TopIncidencia_2 As String = String.Empty
        Dim TopIncidencia_3 As String = String.Empty
        Dim TopIncidencia_4 As String = String.Empty
        Dim TopIncidencia_5 As String = String.Empty


        Try
            Cursor = Cursors.WaitCursor
            If nudSemanaInicio.Value <= nudSemanaFinal.Value Then
                NaveSICY = cmbNave.SelectedValue

                If nudSemanaInicio.Value >= SemanaActual And nudSemanaFinal.Value <= SemanaActual And nudAño.Value = Date.Now.Year Then
                    If ObjBU.ReporteValidarExisteSemanaNave(NaveSICY, nudAño.Value, SemanaActual, Almacen) = False Then
                        ObjBU.ReporteInsertarInformacionSemanalNave(NaveSICY, nudAño.Value, SemanaActual, Almacen)
                    Else
                        ObjBU.ReporteActualizarEvaluacionSemanaNave(NaveSICY, nudAño.Value, SemanaActual, Almacen)
                    End If
                End If

                dtResultado = ObjBU.ReporteConsultaEvaluacionSemanal(NaveSICY, nudAño.Value, nudSemanaInicio.Value, nudSemanaFinal.Value, Almacen)
                'dtResultado = ObjBU.ConsultaReporteSemanaNave(NaveSICY, SemanaActual, nudAño.Value)
                dtTopIncidencias = ObjBU.ReporteEvaluacionTop5(nudAño.Value, Almacen)

                If dtTopIncidencias.AsEnumerable.Where(Function(x) x.Item("fila") = "1").Count > 0 Then
                    TopIncidencia_1 = dtTopIncidencias.AsEnumerable.Where(Function(x) x.Item("fila") = "1").Select(Function(y) y.Item("Descripcion")).FirstOrDefault().ToString
                End If

                If dtTopIncidencias.AsEnumerable.Where(Function(x) x.Item("fila") = "2").Count > 0 Then
                    TopIncidencia_2 = dtTopIncidencias.AsEnumerable.Where(Function(x) x.Item("fila") = "2").Select(Function(y) y.Item("Descripcion")).FirstOrDefault().ToString
                End If

                If dtTopIncidencias.AsEnumerable.Where(Function(x) x.Item("fila") = "3").Count > 0 Then
                    TopIncidencia_3 = dtTopIncidencias.AsEnumerable.Where(Function(x) x.Item("fila") = "3").Select(Function(y) y.Item("Descripcion")).FirstOrDefault().ToString
                End If

                If dtTopIncidencias.AsEnumerable.Where(Function(x) x.Item("fila") = "4").Count > 0 Then
                    TopIncidencia_4 = dtTopIncidencias.AsEnumerable.Where(Function(x) x.Item("fila") = "4").Select(Function(y) y.Item("Descripcion")).FirstOrDefault().ToString
                End If

                If dtTopIncidencias.AsEnumerable.Where(Function(x) x.Item("fila") = "5").Count > 0 Then
                    TopIncidencia_5 = dtTopIncidencias.AsEnumerable.Where(Function(x) x.Item("fila") = "5").Select(Function(y) y.Item("Descripcion")).FirstOrDefault().ToString
                End If

                grdReporteEvaluacion.DataSource = dtResultado
                DiseñoGrid.DiseñoBaseGrid(vwReporteEvaluacion)

                vwReporteEvaluacion.Columns.ColumnByFieldName("ParesRecibidos").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwReporteEvaluacion.Columns.ColumnByFieldName("ParesInspeccionados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwReporteEvaluacion.Columns.ColumnByFieldName("ParesConIncidencia").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwReporteEvaluacion.Columns.ColumnByFieldName("IncidenciaMayor").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwReporteEvaluacion.Columns.ColumnByFieldName("IncidenciaMenor").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                vwReporteEvaluacion.Columns.ColumnByFieldName("ParesRechazados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwReporteEvaluacion.Columns.ColumnByFieldName("OtrosRechazos").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwReporteEvaluacion.Columns.ColumnByFieldName("OtrasIncidencias").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwReporteEvaluacion.Columns.ColumnByFieldName("LotesPilotoPresentado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwReporteEvaluacion.Columns.ColumnByFieldName("LotesPilotoIncidencia").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwReporteEvaluacion.Columns.ColumnByFieldName("TotalDevoluciones").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwReporteEvaluacion.Columns.ColumnByFieldName("TotalDevolucionesAndrea").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vwReporteEvaluacion.Columns.ColumnByFieldName("QuejasClientes").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "NumeroSemana", "No Semana", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, False, Nothing, "")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "ParesRecibidos", "Pares Recibidos", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "ParesInspeccionados", "Pares Inspeccionados", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "PorcentajeInspeccion", "% Inspección", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Custom, "")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "ParesConIncidencia", "Prs Con Incidencia", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "IncidenciaMayor", "Incidencia Mayor", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "IncidenciaMenor", "Incidencia Menor", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "PorcentajeParesConIncidencia", "% Pares Con Incidencia", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, SummaryItemType.Custom, "")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "ParesRechazados", "# Prs Rech.", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "OtrosRechazos", "Prs Rechazados ", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "OtrasIncidencias", "Otros", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "CORTE", "CORTE", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "PESPUNTE", "PESPUNTE", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "MONTADO", "MONTADO", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "ADORNO", "ADORNO", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "LotesPilotoPresentado", "Lotes Presentados", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "LotesPilotoIncidencia", "Lotes Con Incidencia", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "TotalDevoluciones", "Total", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "TotalDevolucionesAndrea", "Andrea", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "Calificacion", "Calificación", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, SummaryItemType.Average, "")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "QuejasClientes", "Quejas Clientes", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")

                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "T1", TopIncidencia_1, True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "T2", TopIncidencia_2, True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "T3", TopIncidencia_3, True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "T4", TopIncidencia_4, True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwReporteEvaluacion, "T5", TopIncidencia_5, True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")



            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La semana de inicio no puede ser mayor a la de fin.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Throw ex
        End Try

    End Sub

    Private Sub CargarNaves()
        Dim lstNavesCombo As New List(Of Entidades.Naves)
        Dim lstNavesMostrar As New List(Of Integer)
        Dim dtDatosNaves As New DataTable

        Try
            dtDatosNaves = ObjBU.ConsultaNaves()
            cmbNave.DataSource = Nothing
            cmbNave.DataSource = dtDatosNaves
            cmbNave.ValueMember = "IdNave"
            cmbNave.DisplayMember = "Nave"
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim NumeroFilas As Integer = 0
        Dim Semana As Integer = 0
        Dim NumeroQuejas As Integer = 0

        Try

            Cursor = Cursors.WaitCursor
            NumeroFilas = vwReporteEvaluacion.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1

                Semana = CInt(vwReporteEvaluacion.GetRowCellValue(vwReporteEvaluacion.GetVisibleRowHandle(index), "NumeroSemana"))
                NumeroQuejas = CInt(vwReporteEvaluacion.GetRowCellValue(vwReporteEvaluacion.GetVisibleRowHandle(index), "QuejasClientes"))

                If Semana = SemanaActual Then
                    ObjBU.ReporteActualizarNumeroQuejas(NaveSICY, nudAño.Value, SemanaActual, NumeroQuejas, Almacen)
                End If

            Next
            ValorModificado = False


            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 25
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 93
    End Sub

    Private Sub vwReporteEvaluacion_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles vwReporteEvaluacion.CustomRowCellEdit
        Dim View2 As GridView = sender
        Dim QuejasCliente As Integer = 0
        Dim ParesPartidaOT As Integer = 0
        Dim Semana As Integer = 0

        If (e.RowHandle >= 0) Then
            If e.Column.FieldName = "QuejasClientes" Then
                Semana = vwReporteEvaluacion.GetRowCellValue(e.RowHandle, "NumeroSemana")
                If Semana = SemanaActual Then
                    e.RepositoryItem = emptyEditor
                Else

                End If
            End If

        End If
    End Sub

    Private Sub vwReporteEvaluacion_ShowingEditor(sender As Object, e As CancelEventArgs) Handles vwReporteEvaluacion.ShowingEditor
        Dim ParesPartidaOT As Integer = 0
        Dim Semana As Integer = 0
        Dim indexFila As Integer = 0

        Semana = vwReporteEvaluacion.GetRowCellValue(vwReporteEvaluacion.FocusedRowHandle, "NumeroSemana")

        e.Cancel = True
        If Semana = SemanaActual Then
            e.Cancel = False
            ValorModificado = True
        End If
    End Sub

    Private Sub vwReporteEvaluacion_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles vwReporteEvaluacion.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        'If (e.RowHandle = currentView.FocusedRowHandle) Then Return
        Dim Semana As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            Semana = vwReporteEvaluacion.GetRowCellValue(e.RowHandle, "NumeroSemana")
            If Semana = SemanaActual Then
                If e.Column.FieldName = "QuejasClientes" Then
                    If ValorModificado = True Then
                        e.Appearance.ForeColor = Color.Purple
                    Else
                        e.Appearance.ForeColor = Color.Black
                    End If
                End If
            End If



            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then

                    If vwReporteEvaluacion.GroupCount > 0 Then
                        grdReporteEvaluacion.ExportToXlsx(.SelectedPath + "\ReportesEvaluacionCalidadNaves_" + SemanaActual.ToString() + "_" + fecha_hora + ".xlsx")
                    Else
                        Dim exportOptions = New XlsxExportOptionsEx()
                        AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                        grdReporteEvaluacion.ExportToXlsx(.SelectedPath + "\ReportesEvaluacionCalidadNaves_" + SemanaActual.ToString() + "_" + fecha_hora + ".xlsx", exportOptions)

                    End If

                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "ReportesEvaluacionCalidadNaves_" & fecha_hora.ToString() & ".xlsx")

                    .Dispose()

                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\ReportesEvaluacionCalidadNaves_" + SemanaActual.ToString() + "_" + fecha_hora + ".xlsx")
                End If



            End With
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)


        'Dim EstatusID As Integer = grdVentas.GetRowCellValue(e.RowHandle, "EstatusID")
        'Dim Bloqueado As String = grdVentas.GetRowCellValue(e.RowHandle, "BE")
        'Dim TotalErrores As Integer = 0
        'Dim TotalIncidencias As Integer = 0
        'Dim index As Integer = 0
        'Try



        '    If EstatusID = 130 Then
        '        e.Formatting.BackColor = pnlEstatusRechazada.BackColor
        '    ElseIf Bloqueado = "SI" Then
        '        e.Formatting.BackColor = Color.Salmon
        '    Else
        '        'If e.ColumnFieldName = "ColorEstatus" Then
        '        '    e.Formatting.BackColor = ObtenerColorStatusOT(grdVentas.GetRowCellValue(e.RowHandle, "EstatusID"))

        '        'End If
        '    End If

        '    If e.ColumnFieldName = "ColorEstatus" Then
        '        e.Formatting.BackColor = ObtenerColorStatusOT(grdVentas.GetRowCellValue(e.RowHandle, "EstatusID"))

        '    End If

        '    If TipoPerfil = 2 Then

        '        If chkDetallada.Checked = False Then
        '            If e.ColumnFieldName = "TotalErrores" Then
        '                TotalErrores = grdVentas.GetRowCellValue(e.RowHandle, "TotalErrores")
        '                If TotalErrores > 0 Then
        '                    e.Formatting.Font.Color = Color.Red
        '                Else
        '                    e.Formatting.Font.Color = Color.Black
        '                End If
        '            End If
        '        End If



        '        If e.ColumnFieldName = "TotalIncidencias" Then
        '            TotalIncidencias = grdVentas.GetRowCellValue(e.RowHandle, "TotalIncidencias")

        '            If TotalIncidencias > 0 Then
        '                e.Formatting.Font.Color = Color.Red
        '            Else
        '                e.Formatting.Font.Color = Color.Black
        '            End If
        '        End If

        '        If e.ColumnFieldName = "FechaValidoAlmacen" Then
        '            If IsDBNull(grdVentas.GetRowCellValue(e.RowHandle, "UsuarioValidoAlmacen")) = False Then
        '                If EstatusID = "129" Or EstatusID = "130" Then
        '                    e.Formatting.Font.Color = Color.Red
        '                Else
        '                    e.Formatting.Font.Color = Color.Green
        '                End If
        '            End If

        '        End If

        '        If e.ColumnFieldName = "UsuarioValidoAlmacen" Then
        '            If IsDBNull(grdVentas.GetRowCellValue(e.RowHandle, "UsuarioValidoAlmacen")) = False Then
        '                If EstatusID = "129" Or EstatusID = "130" Then
        '                    e.Formatting.Font.Color = Color.Red
        '                Else
        '                    e.Formatting.Font.Color = Color.Green
        '                End If
        '            End If

        '        End If


        '    End If

        'Catch ex As Exception
        '    show_message("Error", ex.Message.ToString())
        'End Try



        'e.Handled = True
    End Sub

    Private Sub vwReporteEvaluacion_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles vwReporteEvaluacion.CustomSummaryCalculate
        Try
            If e.IsTotalSummary Then

                Dim summary As DevExpress.XtraGrid.GridColumnSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridColumnSummaryItem)

                If summary.FieldName = "PorcentajeInspeccion" Then
                    Dim view As GridView = TryCast(sender, GridView)
                    Dim ParesRecibidos As Decimal = Convert.ToDecimal(view.Columns("ParesRecibidos").SummaryItem.SummaryValue)
                    Dim ParesInspeccionados As Decimal = Convert.ToDecimal(view.Columns("ParesInspeccionados").SummaryItem.SummaryValue)

                    e.TotalValue = Math.Round((ParesInspeccionados / ParesRecibidos) * 100, 2)
                    e.TotalValueReady = True
                ElseIf summary.FieldName = "PorcentajeParesConIncidencia" Then
                    Dim view As GridView = TryCast(sender, GridView)


                    Dim ParesInspeccionados As Decimal = Convert.ToDecimal(view.Columns("ParesInspeccionados").SummaryItem.SummaryValue)
                    Dim ParesConIncidencia As Decimal = Convert.ToDecimal(view.Columns("ParesConIncidencia").SummaryItem.SummaryValue)

                    e.TotalValue = Math.Round((ParesConIncidencia / ParesInspeccionados) * 100, 2)
                    e.TotalValueReady = True
                End If

            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub
End Class