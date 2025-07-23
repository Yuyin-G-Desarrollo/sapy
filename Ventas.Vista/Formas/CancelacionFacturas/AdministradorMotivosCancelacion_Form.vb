Imports DevExpress.XtraGrid.Views.Grid

Public Class AdministradorMotivosCancelacion_Form
    Dim objMensajeValido As New Tools.AvisoForm
    Dim objMensajeAvertencia As New Tools.AdvertenciaForm
    Dim objMensajeError As New Tools.ErroresForm
    Dim objMensajeExito As New Tools.ExitoForm

    Public Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim obBu As New Negocios.SolicitarCancelacionBU
        Cursor = Cursors.WaitCursor
        Dim activo As Boolean = 0

        If rdoActivoSi.Checked Then
            activo = 1
        Else
            activo = 0
        End If
        Dim dtResultado As DataTable = obBu.ConsultarTodosMotivosCancelacion(activo)

        If dtResultado.Rows.Count > 0 Then
            grdMotivosCancelacion.DataSource = Nothing
            vwMotivosCancelacion.Columns.Clear()
            grdMotivosCancelacion.DataSource = dtResultado

            DiseñoGrid()
            lblFechaUltimaActualización.Text = DateTime.Now.ToString()
            lblNumFiltrados.Text = CDbl(vwMotivosCancelacion.RowCount.ToString()).ToString("n0")
        Else
            grdMotivosCancelacion.DataSource = Nothing
            vwMotivosCancelacion.Columns.Clear()
            objMensajeValido.Text = "Aviso"
            objMensajeValido.mensaje = "No hay datos para mostrar"
            objMensajeValido.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub DiseñoGrid()
        vwMotivosCancelacion.OptionsView.ColumnAutoWidth = False

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwMotivosCancelacion.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        ''OCULTAR COLUMNAS 
        'vwMotivosCancelacion.Columns.ColumnByFieldName("añoAnterior").Visible = False

        ''ANCHO
        vwMotivosCancelacion.Columns.ColumnByFieldName(" ").Width = 30
        vwMotivosCancelacion.Columns.ColumnByFieldName("#").Width = 40
        vwMotivosCancelacion.Columns.ColumnByFieldName("Motivo de cancelacion").Width = 250
        vwMotivosCancelacion.Columns.ColumnByFieldName("Se relaciona").Width = 70
        vwMotivosCancelacion.Columns.ColumnByFieldName("Motivo cancelacion SAT").Width = 250
        vwMotivosCancelacion.Columns.ColumnByFieldName("Activo").Width = 70

        vwMotivosCancelacion.Columns.ColumnByFieldName(" ").OptionsColumn.AllowEdit = True
        vwMotivosCancelacion.Columns.ColumnByFieldName("#").OptionsColumn.AllowEdit = False
        vwMotivosCancelacion.Columns.ColumnByFieldName("Motivo de cancelacion").OptionsColumn.AllowEdit = False
        vwMotivosCancelacion.Columns.ColumnByFieldName("Se relaciona").OptionsColumn.AllowEdit = False
        vwMotivosCancelacion.Columns.ColumnByFieldName("Motivo cancelacion SAT").OptionsColumn.AllowEdit = False
        vwMotivosCancelacion.Columns.ColumnByFieldName("Activo").OptionsColumn.AllowEdit = False
        vwMotivosCancelacion.IndicatorWidth = 40
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Try

            Dim FormularioAltaMotivosCancelacion As New AltasMotivosCancelacion_Form
            FormularioAltaMotivosCancelacion.ShowDialog()
            btnAceptar_Click(Nothing, Nothing)


        Catch ex As Exception
            objMensajeError.Text = "Error"
            objMensajeError.mensaje = ex.Message.ToString
            objMensajeError.ShowDialog()
        End Try

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim  FormularioMotivosCancelacion As New AltasMotivosCancelacion_Form
        Dim action As Integer = 2
        Try
            Dim filasSeleccionadas As Integer
            Dim indexRowSeleccionado As Integer
            Dim DVListadoDocumento As DataView = CType(vwMotivosCancelacion.DataSource, DataView)
            Dim DTResultado As DataTable = DVListadoDocumento.Table.Copy()

            filasSeleccionadas = DTResultado.AsEnumerable.Where(Function(x) CBool(x.Item(" ")) = True).Count
            indexRowSeleccionado = DTResultado.Rows.IndexOf(DTResultado.AsEnumerable.Where(Function(x) CBool(x.Item(" ")) = True).First)

            If filasSeleccionadas > 1 Then
                objMensajeValido.Text = "Advertencia"
                objMensajeValido.mensaje = "Solo se permite editar un registro."
                objMensajeValido.ShowDialog()
                Return
            ElseIf filasSeleccionadas = 0 Then
                objMensajeValido.Text = "Advertencia"
                objMensajeValido.mensaje = "Debe seleccionar un registro"
                objMensajeValido.ShowDialog()
                Return
            End If
            FormularioMotivosCancelacion.accion = 2
            FormularioMotivosCancelacion.motivoID = vwMotivosCancelacion.GetRowCellValue(indexRowSeleccionado, "#")
            FormularioMotivosCancelacion.ShowDialog()
            btnAceptar_Click(Nothing, Nothing)
        Catch ex As Exception
            objMensajeError.Text = "Error"
            objMensajeError.mensaje = ex.Message.ToString
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub vwMotivosCancelacion_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwMotivosCancelacion.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Exportar()
    End Sub
    Private Function Exportar()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty
        Dim nombreReporteParaExportacion As String = String.Empty
        Try
            Cursor = Cursors.WaitCursor
            If vwMotivosCancelacion.DataRowCount > 0 Then
                nombreReporte = "\ReporteMotivosDeCancelaciones_"

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If vwMotivosCancelacion.GroupCount > 0 Then
                            vwMotivosCancelacion.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            vwMotivosCancelacion.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        End If
                        objMensajeExito.Text = "Exito"
                        objMensajeExito.mensaje = "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx"
                        objMensajeExito.ShowDialog()
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                objMensajeValido.Text = "Aviso"
                objMensajeValido.mensaje = "No hay datos para exportar."
                objMensajeValido.ShowDialog()
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            objMensajeValido.Text = "Aviso"
            objMensajeValido.mensaje = "No hay datos para exportar."
            objMensajeValido.ShowDialog()
        End Try
    End Function

    Private Sub AdministradorMotivosCancelacion_Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.F1 Then
            Try

                Dim FormularioAltaMotivosCancelacion As New AltasMotivosCancelacion_Form
                FormularioAltaMotivosCancelacion.ShowDialog()
                btnAceptar_Click(Nothing, Nothing)
            Catch ex As Exception
                objMensajeError.Text = "Error"
                objMensajeError.mensaje = ex.Message.ToString
                objMensajeError.ShowDialog()
            End Try
        End If
        If e.KeyData = Keys.F1 Then
            Dim FormularioMotivosCancelacion As New AltasMotivosCancelacion_Form
            Dim action As Integer = 2
            Try
                Dim filasSeleccionadas As Integer
                Dim indexRowSeleccionado As Integer
                Dim DVListadoDocumento As DataView = CType(vwMotivosCancelacion.DataSource, DataView)
                Dim DTResultado As DataTable = DVListadoDocumento.Table.Copy()

                filasSeleccionadas = DTResultado.AsEnumerable.Where(Function(x) CBool(x.Item(" ")) = True).Count
                indexRowSeleccionado = DTResultado.Rows.IndexOf(DTResultado.AsEnumerable.Where(Function(x) CBool(x.Item(" ")) = True).First)

                If filasSeleccionadas > 1 Then
                    objMensajeValido.Text = "Advertencia"
                    objMensajeValido.mensaje = "Solo se permite editar un registro."
                    objMensajeValido.ShowDialog()
                    Return
                ElseIf filasSeleccionadas = 0 Then
                    objMensajeValido.Text = "Advertencia"
                    objMensajeValido.mensaje = "Debe seleccionar un registro"
                    objMensajeValido.ShowDialog()
                    Return
                End If
                FormularioMotivosCancelacion.accion = 2
                FormularioMotivosCancelacion.motivoID = vwMotivosCancelacion.GetRowCellValue(indexRowSeleccionado, "#")
                FormularioMotivosCancelacion.ShowDialog()
                btnAceptar_Click(Nothing, Nothing)
            Catch ex As Exception
                objMensajeError.Text = "Error"
                objMensajeError.mensaje = ex.Message.ToString
                objMensajeError.ShowDialog()
            End Try
        End If

        If e.KeyData = Keys.F5 Then
            Dim obBu As New Negocios.SolicitarCancelacionBU
            Cursor = Cursors.WaitCursor
            Dim activo As Boolean = 0

            If rdoActivoSi.Checked Then
                activo = 1
            Else
                activo = 0
            End If
            Dim dtResultado As DataTable = obBu.ConsultarTodosMotivosCancelacion(activo)

            If dtResultado.Rows.Count > 0 Then
                grdMotivosCancelacion.DataSource = Nothing
                vwMotivosCancelacion.Columns.Clear()
                grdMotivosCancelacion.DataSource = dtResultado

                DiseñoGrid()
                lblFechaUltimaActualización.Text = DateTime.Now.ToString()
                lblNumFiltrados.Text = CDbl(vwMotivosCancelacion.RowCount.ToString()).ToString("n0")
            Else
                grdMotivosCancelacion.DataSource = Nothing
                vwMotivosCancelacion.Columns.Clear()
                objMensajeValido.Text = "Aviso"
                objMensajeValido.mensaje = "No hay datos para mostrar"
                objMensajeValido.ShowDialog()
            End If
            Cursor = Cursors.Default
        End If
        If e.KeyData = Keys.F9 Then
            Exportar()
        End If
        If e.KeyData = Keys.Escape Then
            Dim confirmar As New ConfirmarForm
            confirmar.mensaje = "¿Está seguro de cerrar la ventana?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.Close()
            End If
        End If

    End Sub
End Class