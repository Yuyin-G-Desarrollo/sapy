Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Tools
Imports Ventas.Negocios

Public Class Ventas_Alerta_VigenciaArticulosForm
    Dim advertencia As New AdvertenciaForm
    Public inicio As Integer = 0
    Dim dtObtieneArticulos As New DataTable


    Private Sub Ventas_Alerta_VigenciaArticulosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarArticulosConFechaVigencia()
    End Sub

    Public Function CargarArticulosConFechaVigencia() As DataTable
        Try
            Dim objBU As New VigenciaArticulosBU

            Cursor = Cursors.WaitCursor

            dtObtieneArticulos = objBU.ObtieneArticulos_FechaVigencia()

            If dtObtieneArticulos.Rows.Count > 0 Then
                grdAlertaDescontinuar.DataSource = dtObtieneArticulos
                DisenioGrid()
                lblFechaUltimaActualizacion.Text = Date.Now
                lblRegistros.Text = CDbl(vwAlertaDescontinuar.RowCount.ToString()).ToString("n0")
            Else
                If inicio = 1 Then

                Else
                    advertencia.mensaje = "No hay artículos con fecha vigencia."
                    advertencia.ShowDialog()
                End If

            End If

        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        Cursor = Cursors.Default

        Return dtObtieneArticulos
    End Function

    Private Sub DisenioGrid()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwAlertaDescontinuar.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
        Next

        vwAlertaDescontinuar.IndicatorWidth = 35

        vwAlertaDescontinuar.Columns.ColumnByFieldName("Descripcion").Width = 350
        vwAlertaDescontinuar.Columns.ColumnByFieldName("FechaEntregaProgramacion").Width = 85
        vwAlertaDescontinuar.Columns.ColumnByFieldName("FechaVigencia").Width = 70
        vwAlertaDescontinuar.Columns.ColumnByFieldName("UsuarioModifico").Width = 70
        vwAlertaDescontinuar.Columns.ColumnByFieldName("Descripcion").Width = 360
        vwAlertaDescontinuar.Columns.ColumnByFieldName("Descripcion").Width = 350
        vwAlertaDescontinuar.Columns.ColumnByFieldName("FechaCreacion").Width = 100
        vwAlertaDescontinuar.Columns.ColumnByFieldName("Observaciones").Width = 150
        vwAlertaDescontinuar.Columns.ColumnByFieldName("Naves Asignadas").Width = 150
        vwAlertaDescontinuar.Columns.ColumnByFieldName("ST").Width = 20

        vwAlertaDescontinuar.Columns.ColumnByFieldName("Descripcion").Caption = "Descripción"
        vwAlertaDescontinuar.Columns.ColumnByFieldName("FechaEntregaProgramacion").Caption = "Última" + vbCrLf + "F Entrega" + vbCrLf + "Propuesta Programación"
        vwAlertaDescontinuar.Columns.ColumnByFieldName("FechaVigencia").Caption = "Fecha" + vbCrLf + "Vigencia"
        vwAlertaDescontinuar.Columns.ColumnByFieldName("UsuarioModifico").Caption = "Usuario" + vbCrLf + "Modificó"
        vwAlertaDescontinuar.Columns.ColumnByFieldName("FechaCreacion").Caption = "Fecha" + vbCrLf + "Creación"
        vwAlertaDescontinuar.Columns.ColumnByFieldName("ST").Caption = " "


    End Sub

    Private Function ObtenerColorEstatus(ByVal Estatus As String) As Color
        Dim TipoColor As Color = Color.Empty

        If Estatus = "VDES" Then
            TipoColor = pnlDescontinuado.BackColor
        ElseIf Estatus = "V1Y15" Then
            TipoColor = pnlde1a15dias.BackColor
        ElseIf Estatus = "V+15" Then
            TipoColor = pnlMayora15dias.BackColor
        Else
            TipoColor = Color.Empty
        End If

        Return TipoColor

    End Function

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        CargarArticulosConFechaVigencia()
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If vwAlertaDescontinuar.RowCount > 0 Then
            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty


            Try
                nombreReporte = "\Alertas_Vigencia de Artículos"

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = System.Windows.Forms.DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor

                        If vwAlertaDescontinuar.GroupCount > 0 Then
                            vwAlertaDescontinuar.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                            vwAlertaDescontinuar.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)

                        End If

                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")

                        .Dispose()

                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay datos para exportar.")
        End If
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        Dim Estatus As String = vwAlertaDescontinuar.GetRowCellValue(e.RowHandle, "ST")

        Try
            If e.ColumnFieldName = "ST" Then
                If Estatus = "VDES" Then
                    e.Formatting.BackColor = pnlDescontinuado.BackColor
                    e.Formatting.Font.Color = pnlDescontinuado.BackColor
                ElseIf Estatus = "V1Y15" Then
                    e.Formatting.BackColor = pnlde1a15dias.BackColor
                    e.Formatting.Font.Color = pnlde1a15dias.BackColor
                ElseIf Estatus = "V+15" Then
                    e.Formatting.BackColor = pnlMayora15dias.BackColor
                    e.Formatting.Font.Color = pnlMayora15dias.BackColor
                Else
                    e.Formatting.BackColor = Color.Empty
                End If
            End If

        Catch ex As Exception

        End Try
        e.Handled = True
    End Sub

    Private Sub vwAlertaDescontinuar_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwAlertaDescontinuar.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub vwAlertaDescontinuar_CustomDrawCell(sender As Object, e As Views.Base.RowCellCustomDrawEventArgs) Handles vwAlertaDescontinuar.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        'If (e.RowHandle = currentView.FocusedRowHandle) Then Return


        If vwAlertaDescontinuar.DataRowCount > 0 Then
            If e.Column.FieldName = "ST" Then
                e.Appearance.BackColor = ObtenerColorEstatus(currentView.GetRowCellValue(e.RowHandle, "ST"))
                e.Appearance.ForeColor = ObtenerColorEstatus(currentView.GetRowCellValue(e.RowHandle, "ST"))
            End If
        End If

    End Sub



End Class