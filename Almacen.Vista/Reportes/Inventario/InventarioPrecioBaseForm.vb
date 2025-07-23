Imports DevExpress.XtraGrid
Imports Tools

Public Class InventarioPrecioBaseForm

    Private ReadOnly ObjBU As New Negocios.InventarioPrecioBaseBU

    Private Sub InventarioPrecioBaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        cmbCEDIS = Utilerias.ComboObtenerCEDISUsuario(cmbCEDIS)

        Inicializar()
    End Sub

    Private Sub ListadoVisitantesForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case Keys.F5
                MostrarInventario()

            Case Keys.F9
                ExportarExcel()
        End Select
    End Sub

#Region "Panel Cabecera"

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ExportarExcel()
    End Sub

#End Region

#Region "Panel de Formulario"

    Private Sub VwReporteInventario_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwReporteInventario.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

#End Region

#Region "Panel de Acciones"

    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        MostrarInventario()
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Inicializar()
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

#End Region

#Region "Metodos Privados"

    Private Sub Inicializar()
        grdReporteInventario.DataSource = Nothing
        vwReporteInventario.Columns.Clear()

        dtpFecha.Value = Date.Now

        lblRegistroR.Text = "0"
    End Sub

    Private Sub ExportarExcel()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreDocumento = "\ReporteInventario_"

        If vwReporteInventario.RowCount > 0 Then
            Try
                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        If vwReporteInventario.GroupCount > 0 Then
                            grdReporteInventario.ExportToXlsx(.SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                        Else
                            grdReporteInventario.ExportToXlsx(.SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                        End If

                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & nombreDocumento & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                    End If
                End With
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrio un error al momento de exportar los datos.")
            End Try
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay datos para exportar.")
        End If
    End Sub

    Public Sub MostrarInventario()
        Cursor = Cursors.WaitCursor

        Try
            Dim dtResultadoReporte As DataTable = ObjBU.ConsultaInventario(cmbCEDIS.SelectedValue, dtpFecha.Value)
            If dtResultadoReporte.Rows.Count > 0 Then
                grdReporteInventario.DataSource = Nothing
                vwReporteInventario.Columns.Clear()

                grdReporteInventario.DataSource = dtResultadoReporte
                DiseñoGrid.DiseñoBaseGrid(vwReporteInventario)
                DiseñoColumnas()

                lblRegistroR.Text = String.Format("{0:N0}", dtResultadoReporte.Rows.Count)
                lblFechaUltimaActualización.Text = Date.Now.ToString()
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se encontro información disponible.")
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrio un error al momento de consultar los datos.")
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub DiseñoColumnas()
        Try
            If vwReporteInventario.Columns.Count > 0 Then
                vwReporteInventario.IndicatorWidth = 50

                For Each col As Columns.GridColumn In vwReporteInventario.Columns
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
                    col.OptionsColumn.AllowEdit = False
                    If (col.FieldName = "Pares") Then
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        col.DisplayFormat.FormatString = "N0"
                        DiseñoGrid.EstiloColumna(vwReporteInventario, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, False, 100, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                    ElseIf (col.FieldName = "Precio Base") Or (col.FieldName = "Total") Then
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        col.DisplayFormat.FormatString = "C2"
                        DiseñoGrid.EstiloColumna(vwReporteInventario, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, False, 100, True, DevExpress.Data.SummaryItemType.Sum, "{0:C2}")
                    Else
                        DiseñoGrid.EstiloColumna(vwReporteInventario, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
                    End If
                Next

                vwReporteInventario.OptionsView.ColumnAutoWidth = True
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se encotraron columnas en la tabla.")
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrio un error al momento de personalizar la informacion.")
        End Try

    End Sub

#End Region

End Class