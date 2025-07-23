Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports Infragistics.Win
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraPrinting

Public Class DetallesDevolucionNaveForm

    Public FolioDevolucionId As Integer = 0
    Public Nave As String = String.Empty
    Public ParesDevueltos As Integer = 0

    Private ObjBu As New Negocios.InspeccionCalidadBU


    Private Sub DetallesDevolucionNaveForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Cursor = Cursors.WaitCursor
            Me.WindowState = FormWindowState.Maximized
            CargarDetalles(FolioDevolucionId)
            lblFolioDevolucion.Text = FolioDevolucionId.ToString()
            lblNave.Text = Nave
            lblParesDevueltos.Text = CDbl(ParesDevueltos).ToString("N0")
            Cursor = Cursors.Default
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub CargarDetalles(ByVal FolioDevolucionID As Integer)
        Dim dtResultado As New DataTable
        Try
            dtResultado = ObjBu.ConsultarDetallesDevolucion(FolioDevolucionID)
            grdDevolucionDetalle.DataSource = dtResultado
            DiseñoGrid.DiseñoBaseGrid(viewDevolucionDetalle)
            viewDevolucionDetalle.IndicatorWidth = 30
            viewDevolucionDetalle.OptionsView.ColumnAutoWidth = False
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "DevolucionNaveID", "Folio devolución", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "Nave", "Nave", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "FechaCaptura", "Fecha Captura", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "Colaborador", "Inspector", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "Atado", "Atado", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "Par", "Par", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "Lote", "Lote", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "Año", "Año", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "Pedido", "Pedido", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "CantidadDevuelto", "Cantidad Devuelto", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "CantidadRegreso", "Cantidad Regreso", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "CantidadPendiente", "Cantidad Pendiente", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "Incidencia", "Incidencia", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "EstatusID", "EstatusID", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "FechaREgreso", "Fecha Regreso", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "ColaboradorRecibioID", "ColaboradorRecibioID", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "MarcaSAY", "Marca SAY", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "ColeccionSAY", "Colección SAY", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "Piel", "Piel", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "Talla", "Talla", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "Color", "Color", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "FechaEstimadaRegreso", "Fecha Estimada Regreso", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            'DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "FechaRegreso", "Fecha Regreso", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "ColaboradorRecibio", "Colaborador Recibio", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "Status", "Status", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "FolioSalidaID", "Folio Salida", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "FolioInspeccionID", "Folio Inspección", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "Cliente", "Cliente", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "DiasTranscurridos", "Días Transcurridos", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDevolucionDetalle, "DiasParaEntrega", "Días Para Entrega", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")






            lblTotalRegistros.Text = CDbl(dtResultado.Rows.Count).ToString("N0")
            'viewDevolucionDetalle.OptionsView.ColumnAutoWidth = True
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub viewDevolucionDetalle_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewDevolucionDetalle.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Cursor = Cursors.WaitCursor
        ExportarExcel()
        Cursor = Cursors.Default
    End Sub

    Private Sub ExportarExcel()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim NombreArchivo As String = String.Empty
        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                Dim exportOptions = New XlsxExportOptionsEx()
                AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                NombreArchivo = "\Datos_DevolucionNave_" + FolioDevolucionId.ToString() + "_" + fecha_hora + ".xlsx"

                If ret = Windows.Forms.DialogResult.OK Then
                    If GridView1.GroupCount > 0 Then
                        grdDevolucionDetalle.ExportToXlsx(.SelectedPath + NombreArchivo, exportOptions)
                    Else
                        grdDevolucionDetalle.ExportToXlsx(.SelectedPath + NombreArchivo, exportOptions)
                    End If
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & NombreArchivo)
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + NombreArchivo)
                End If
            End With

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

        Dim CantidadPendiente As Integer = viewDevolucionDetalle.GetRowCellValue(e.RowHandle, "CantidadPendiente")
        Dim Status As String = viewDevolucionDetalle.GetRowCellValue(e.RowHandle, "Status")
        Dim statusid As Integer
        Dim DiasParaEntrega As Integer
        Try


            If e.ColumnFieldName = "CantidadPendiente" Then
                If CantidadPendiente > 0 Then
                    e.Formatting.Font.Color = Color.Red
                Else
                    e.Formatting.Font.Color = Color.Black
                End If
            End If

            If e.ColumnFieldName = "Status" Then

                statusid = viewDevolucionDetalle.GetRowCellValue(viewDevolucionDetalle.GetVisibleRowHandle(e.RowHandle), "EstatusID").ToString()

                If statusid = 210 Then
                    e.Formatting.BackColor = Color.LightSeaGreen
                    ' e.Appearance.ForeColor = Color.White
                ElseIf statusid = 211 Then
                    e.Formatting.BackColor = Color.Yellow
                    ' e.Appearance.ForeColor = Color.White
                ElseIf statusid = 212 Then
                    e.Formatting.BackColor = Color.Brown
                    ' e.Appearance.ForeColor = Color.White
                End If
            End If


            If e.ColumnFieldName = "DiasTranscurridos" Then

                DiasParaEntrega = viewDevolucionDetalle.GetRowCellValue(viewDevolucionDetalle.GetVisibleRowHandle(e.RowHandle), "DiasParaEntrega").ToString()

                If DiasParaEntrega > 0 Then
                    e.Formatting.BackColor = Color.LightSeaGreen
                    'e.Appearance.ForeColor = Color.White
                ElseIf DiasParaEntrega = 0 Then
                    e.Formatting.BackColor = Color.Orange
                Else
                    e.Formatting.BackColor = Color.Tomato
                End If

            End If



        Catch ex As Exception

        End Try

        e.Handled = True

        'Dim Incidencias As Integer = viewInspeccion.GetRowCellValue(e.RowHandle, "Incidencias")
        'Dim IncidenciasMayores As Integer = viewInspeccion.GetRowCellValue(e.RowHandle, "IncidenciasMayores")
        'Dim IncidnciasCriticas As Integer = viewInspeccion.GetRowCellValue(e.RowHandle, "IncidenciasCriticas")
        'Dim ParesDevueltos As Integer = viewInspeccion.GetRowCellValue(e.RowHandle, "ParesDevueltos")

        'Try
        '    If e.ColumnFieldName = "Incidencias" Then
        '        If Incidencias > 0 Then
        '            e.Formatting.Font.Color = Color.Red
        '        End If
        '    End If


        '    If e.ColumnFieldName = "IncidenciasMayores" Then
        '        If IncidenciasMayores > 0 Then
        '            e.Formatting.Font.Color = Color.Red
        '        End If
        '    End If

        '    If e.ColumnFieldName = "IncidenciasCriticas" Then
        '        If IncidnciasCriticas > 0 Then
        '            e.Formatting.Font.Color = Color.Red
        '        End If
        '    End If

        '    If e.ColumnFieldName = "ParesDevueltos" Then
        '        If ParesDevueltos > 0 Then
        '            e.Formatting.Font.Color = Color.Red
        '        End If
        '    End If

        'Catch ex As Exception

        'End Try

        e.Handled = True
    End Sub

    Private Sub viewDevolucionDetalle_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles viewDevolucionDetalle.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        Dim StatusID As Integer = 0
        Dim DiasParaEntrega As Integer = 0

        Try
            Cursor = Cursors.WaitCursor

            If e.Column.FieldName = "CantidadPendiente" Then
                If e.CellValue > 0 Then
                    e.Appearance.ForeColor = Color.Red
                Else
                    e.Appearance.ForeColor = Color.Black
                End If
            End If

            If e.Column.FieldName = "Status" Then

                StatusID = viewDevolucionDetalle.GetRowCellValue(viewDevolucionDetalle.GetVisibleRowHandle(e.RowHandle), "EstatusID")

                If StatusID = 210 Then
                    e.Appearance.BackColor = Color.LightSeaGreen
                    ' e.Appearance.ForeColor = Color.White
                ElseIf StatusID = 211 Then
                    e.Appearance.BackColor = Color.Yellow
                    ' e.Appearance.ForeColor = Color.White
                ElseIf StatusID = 212 Then
                    e.Appearance.BackColor = Color.Brown
                    ' e.Appearance.ForeColor = Color.White
                End If
            End If

            '210 DEVOLUCION	1	DEVOLUCION_INSPECCION	ACTIVO
            '211 DEVOLUCION	2	DEVOLUCION_INSPECCION	PARCIALMENTE INGRESADO
            '212 DEVOLUCION	3	DEVOLUCION_INSPECCION	INGRESADO


            If e.Column.FieldName = "DiasTranscurridos" Then

                DiasParaEntrega = viewDevolucionDetalle.GetRowCellValue(viewDevolucionDetalle.GetVisibleRowHandle(e.RowHandle), "DiasParaEntrega")

                If DiasParaEntrega > 0 Then
                    e.Appearance.BackColor = Color.LightSeaGreen
                    'e.Appearance.ForeColor = Color.White
                ElseIf DiasParaEntrega = 0 Then
                    e.Appearance.BackColor = Color.Orange
                Else
                    e.Appearance.BackColor = Color.Tomato
                End If

            End If


            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub
End Class