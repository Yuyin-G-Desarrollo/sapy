
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Tools

Public Class ConsultaLotesPilotoForm
    Dim ObjBU As New Negocios.ConsultaLotesPiloto
    Public IdNave As Integer

    Friend WithEvents viewInspeccion As DevExpress.XtraGrid.Views.Grid.GridView
    Private Sub ConsultaLotesPilotoForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.WindowState = FormWindowState.Maximized
        cmbNaves = Tools.Controles.ComboNavesSegunUsuarioConIdSIcy(cmbNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid) 'LLENA EL COMBO NAVES
        cmbNaves.SelectedIndex = 0
        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now
        btnExportarExcel.Enabled = False
        lblTotalRegistros.Text = "0"
    End Sub
    Private Sub cmbNaves_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbNaves.SelectedValueChanged
        If cmbNaves.ContainsFocus Then
            IdNave = CInt(cmbNaves.SelectedValue)
        End If
    End Sub
    Private Sub CargarLotesPiloto(FechaInicio As String, FechaFin As String, Nave As Integer)
        Dim ListaLotesPiloto = ObjBU.ConsultarLotesPiloto(FechaInicio, FechaFin, Nave)
        If IsNothing(ListaLotesPiloto) Or ListaLotesPiloto.Count.Equals(0) Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontraron datos.")
            btnExportarExcel.Enabled = False
            grdLotesPiloto.DataSource = ListaLotesPiloto
            lblTotalRegistros.Text = ListaLotesPiloto.Count.ToString()
        Else
            grdLotesPiloto.DataSource = ListaLotesPiloto
            DiseñoGrid.DiseñoBaseGrid(viewLotesPiloto)
            viewLotesPiloto.IndicatorWidth = 35
            viewLotesPiloto.OptionsView.ColumnAutoWidth = False
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "FolioInspeccion", "Folios Inspeccion", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "FolioIngreso", "Folio Ingreso", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 80, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "Lote", "Lote", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "Nave", "Nave", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "Año", "Año", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "ParesLote", "Pares Por" & vbCrLf & "Lote", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "ParesInspeccionadosLote", "Pares" & vbCrLf & "Inspeccionados" & vbCrLf & "Por Lote", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "NumeroIncidenciasLote", "Numero" & vbCrLf & " Incidencias" & vbCrLf & "Lote", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "Cliente", "Cliente", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "ModeloSICY", "ModeloSICY", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "ModeloSAY", "ModeloSAY", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "Articulo", "Articulo", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "CodigoPar", "Codigo Par", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "CodigoAtado", "Codigo Atado", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "FechaRegistroIncidencia", "Fecha Registro" & vbCrLf & "Incidencia", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "Inspector", "Inspector", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "Incidencia", "Incidencias", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "IncidenciaMayor", "Incidencias" & vbCrLf & "Mayores", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "IncidenciaMenor", "Incidencias" & vbCrLf & " Menores", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "ParesDeVueltos", "Pares De" & vbCrLf & " Vueltos", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
            DiseñoGrid.EstiloColumna(viewLotesPiloto, "Observaciones", "Observaciones", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            lblTotalRegistros.Text = ListaLotesPiloto.Count.ToString()
            btnExportarExcel.Enabled = True
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If Date.Compare(dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString) > 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La fecha de inicio no puede ser mayor que la fin.")
            Return
        End If
        If IdNave = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleccione una Nave.")
            Return
        End If
        Cursor = Cursors.WaitCursor
        CargarLotesPiloto(dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString, IdNave)
        Cursor = Cursors.Default
    End Sub

    Private Sub viewLotesPilot_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewLotesPiloto.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub


    Private Sub ExportarExcel()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog


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

                If ret = Windows.Forms.DialogResult.OK Then
                    If GridView1.GroupCount > 0 Then
                        grdLotesPiloto.ExportToXlsx(.SelectedPath + "\LotesPiloto_" + fecha_hora + ".xlsx", exportOptions)
                    Else
                        grdLotesPiloto.ExportToXlsx(.SelectedPath + "\LotesPiloto_" + fecha_hora + ".xlsx", exportOptions)
                    End If
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "Datos_ReporteLotesPiloto_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\LotesPiloto_" + fecha_hora + ".xlsx")
                End If
            End With

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    '''<comentario>
    ''' Exporta los datos de la tabla a un excel
    '''</comentario>
    '''<parametro1>FechaInicio</parametro1>
    '''<parametro1>FechaFin</parametro1>
    '''<parametro1>Nave</parametro1>
    '''<retorno>Objeto ConsultaLotesPiloto</retorno>
    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)


        Dim Incidencias As String = viewLotesPiloto.GetRowCellValue(e.RowHandle, "Incidencia")
        Dim IncidenciasMayor As Integer = viewLotesPiloto.GetRowCellValue(e.RowHandle, "IncidenciaMayor")
        Dim IncidnciasMenor As Integer = viewLotesPiloto.GetRowCellValue(e.RowHandle, "IncidenciaMenor")
        Dim ParesDeVueltos As Integer = viewLotesPiloto.GetRowCellValue(e.RowHandle, "ParesDeVueltos")

        Try
            If e.ColumnFieldName = "Incidencia" Then
                If Incidencias.Length > 0 Then
                    e.Formatting.Font.Color = Color.Red
                End If
            End If


            If e.ColumnFieldName = "IncidenciaMayor" Then
                If IncidenciasMayor > 0 Then
                    e.Formatting.Font.Color = Color.Red
                End If
            End If

            If e.ColumnFieldName = "IncidenciaMenor" Then
                If IncidnciasMenor > 0 Then
                    e.Formatting.Font.Color = Color.Red
                End If
            End If

            If e.ColumnFieldName = "ParesDeVueltos" Then
                If ParesDeVueltos > 0 Then
                    e.Formatting.Font.Color = Color.Red
                End If
            End If



        Catch ex As Exception

        End Try

        e.Handled = True
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Cursor = Cursors.WaitCursor
        ExportarExcel()
        Cursor = Cursors.Default
    End Sub
    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 74
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub viewLotesPiloto_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles viewLotesPiloto.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        'If (e.RowHandle = currentView.FocusedRowHandle) Then Return


        Try
            Cursor = Cursors.WaitCursor

            If e.Column.FieldName = "Incidencia" Then

                e.Appearance.ForeColor = Color.Red

            End If

            If e.Column.FieldName = "IncidenciaMayor" Then
                If e.CellValue > 0 Then
                    e.Appearance.BackColor = Color.Red
                    e.Appearance.ForeColor = Color.White
                Else
                    e.Appearance.ForeColor = Color.Black
                End If
            End If


            If e.Column.FieldName = "IncidenciaMenor" Then
                If e.CellValue > 0 Then
                    e.Appearance.BackColor = Color.Red
                    e.Appearance.ForeColor = Color.White
                Else
                    e.Appearance.ForeColor = Color.Black
                End If
            End If
            If e.Column.FieldName = "ParesDeVueltos" Then
                If e.CellValue > 0 Then
                    e.Appearance.BackColor = Color.Red
                    e.Appearance.ForeColor = Color.White
                Else
                    e.Appearance.ForeColor = Color.Black
                End If
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default

        End Try
    End Sub

End Class