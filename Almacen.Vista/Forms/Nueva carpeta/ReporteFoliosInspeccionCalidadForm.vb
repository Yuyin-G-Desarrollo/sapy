Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports Infragistics.Win
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraPrinting

Public Class ReporteFoliosInspeccionCalidadForm

    Dim OBJBU As New Almacen.Negocios.InspeccionCalidadBU
    Dim lstFiltroFoliosInspeccion As New List(Of String)
    Dim lstFiltroFoliosSalida As New List(Of String)
    Dim lstInicial As New List(Of String)

    Private Sub ReporteFoliosInspeccionCalidadForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Cursor = Cursors.WaitCursor
            lblTotalRegistros.Text = "0"
            Me.WindowState = FormWindowState.Maximized
            dtpFechaInicio.Value = Date.Now
            dtpFechaFin.Value = Date.Now
            PermisosPerfil()
            ObtenerInformacion()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub PermisosPerfil()
        Dim NaveUsuario As New Framework.Negocios.NavesUsuarioBU
        Dim ListaNaves As New List(Of Entidades.NavesUsuario)
        Dim dtResultado As New DataTable

        Try
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Calidad_Inpeccion", "FOLIOS_NAVE") Then
                ListaNaves = NaveUsuario.listaNaves(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

                dtResultado.Columns.Add("Parámetro")
                dtResultado.Columns.Add(" ")
                dtResultado.Columns.Add("Status")

                For Each Fila As Entidades.NavesUsuario In ListaNaves
                    dtResultado.Rows.Add(Fila.NavesID.PNaveSICYid, False, Fila.NavesID.PNombre)
                Next
                btnAgregarFiltroNave.Enabled = False
                btnLimpiarFiltroNave.Enabled = False
                grdNave.Enabled = False
                grdNave.DataSource = dtResultado
                With grdNave
                    .DisplayLayout.Bands(0).Columns(0).Hidden = True
                    .DisplayLayout.Bands(0).Columns(1).Hidden = True
                    .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Nave"
                End With

            End If

        Catch ex As Exception

        End Try

    End Sub



    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 180
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Cursor = Cursors.WaitCursor
        ObtenerInformacion()
        Cursor = Cursors.Default
    End Sub

    Private Sub ObtenerInformacion()
        Dim DtInformacion As New DataTable
        Dim FiltroFoliosInspeccion As String = String.Empty
        Dim FiltrofolioSalida As String = String.Empty
        Dim FiltroNave As String = String.Empty
        Dim FiltroStatus As String = String.Empty


        Try
            grdInspeccion.DataSource = Nothing

            FiltroFoliosInspeccion = ObtenerFiltrosGrid(grdFiltroFolioInspeccion)
            FiltrofolioSalida = ObtenerFiltrosGrid(grdFiltroFolioSalida)
            FiltroNave = ObtenerFiltrosGrid(grdNave)
            FiltroStatus = ObtenerFiltrosGrid(grdStatus)

            If chkFechaInspeccion.Checked = True Then
                If Date.Compare(dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString) > 0 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La fecha de inicio no puede ser mayor que la fin.")
                    Return
                End If
            End If

            DtInformacion = OBJBU.ReporteDeInspeccion(FiltroNave, chkFechaInspeccion.Checked, dtpFechaInicio.Value, dtpFechaFin.Value, FiltroStatus, FiltroFoliosInspeccion, FiltrofolioSalida)

            grdInspeccion.DataSource = DtInformacion
            DiseñoGrid.DiseñoBaseGrid(viewInspeccion)
            viewInspeccion.IndicatorWidth = 30
            viewInspeccion.OptionsView.ColumnAutoWidth = True
            DiseñoGrid.EstiloColumna(viewInspeccion, "FolioInspeccionID", "Folio Inspección", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, False, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccion, "Nave", "Nave", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccion, "Fecha", "Fecha Inspección", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccion, "HoraInicio", "Hora Inicio", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccion, "HoraFin", "Hora Fin", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccion, "Entrega", "Entrega", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccion, "FolioSalida", "Folio Salida", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccion, "ParesFolio", "Pares Folio", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "")
            DiseñoGrid.EstiloColumna(viewInspeccion, "LotesPiloto", "Lotes Piloto", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "")
            DiseñoGrid.EstiloColumna(viewInspeccion, "ParesInspeccionados", "Pares Inspeccionados", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "")
            DiseñoGrid.EstiloColumna(viewInspeccion, "Incidencias", "Incidencias", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "")
            DiseñoGrid.EstiloColumna(viewInspeccion, "IncidenciasMayores", "Incidencias Mayores", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "")
            DiseñoGrid.EstiloColumna(viewInspeccion, "IncidenciasCriticas", "Incidencias Criticas", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "")
            DiseñoGrid.EstiloColumna(viewInspeccion, "ParesDevueltos", "Pares Devueltos", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "")
            DiseñoGrid.EstiloColumna(viewInspeccion, "ParesIngresados", "Pares Ingresados", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "")

            lblTotalRegistros.Text = CDbl(DtInformacion.Rows.Count).ToString("N0")

            If DtInformacion.Rows.Count = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay información para mostrar.")
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrio un error al mostrar la información.")
        End Try


    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Try
            chkFechaInspeccion.Checked = True
            grdFiltroFolioInspeccion.DataSource = Nothing
            grdFiltroFolioSalida.DataSource = Nothing
            grdStatus.DataSource = Nothing
            txtFiltroFolioInspeccion.Text = String.Empty
            txtFiltroFolioSalida.Text = String.Empty
            dtpFechaInicio.Value = Date.Now
            dtpFechaFin.Value = Date.Now
            lblTotalRegistros.Text = "0"

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Calidad_Inpeccion", "FOLIOS_NAVE") = False Then
                grdNave.DataSource = Nothing
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Cursor = Cursors.WaitCursor
        ExportarExcel()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnDetalles_Click(sender As Object, e As EventArgs) Handles btnDetalles.Click
        Dim DetFolio As New DetallesFolioInspeccionFormvb
        Dim FolioInspeccionId As Integer = 0
        Dim ParesFolio As Integer = 0
        Dim ParesIncidencias As Integer = 0
        Dim ParesDevueltos As Integer = 0
        Dim Nave As String = String.Empty
        Dim ParesInspeccionados As Integer = 0
        Try
            Cursor = Cursors.WaitCursor

            For Each Fila As Integer In viewInspeccion.GetSelectedRows()
                FolioInspeccionId = viewInspeccion.GetRowCellValue(viewInspeccion.GetVisibleRowHandle(Fila), "FolioInspeccionID").ToString()
                ParesFolio = viewInspeccion.GetRowCellValue(viewInspeccion.GetVisibleRowHandle(Fila), "ParesFolio").ToString()
                ParesIncidencias = viewInspeccion.GetRowCellValue(viewInspeccion.GetVisibleRowHandle(Fila), "Incidencias").ToString()
                ParesDevueltos = viewInspeccion.GetRowCellValue(viewInspeccion.GetVisibleRowHandle(Fila), "ParesDevueltos").ToString()
                Nave = viewInspeccion.GetRowCellValue(viewInspeccion.GetVisibleRowHandle(Fila), "Nave").ToString()
                ParesInspeccionados = viewInspeccion.GetRowCellValue(viewInspeccion.GetVisibleRowHandle(Fila), "ParesInspeccionados").ToString()
            Next

            If FolioInspeccionId > 0 Then
                DetFolio.FolioInspeccionId = FolioInspeccionId
                DetFolio.ParesFolio = ParesFolio
                DetFolio.ParesInspeccionados = ParesInspeccionados
                DetFolio.Nave = Nave
                DetFolio.ParesIncidencias = ParesIncidencias
                DetFolio.ParesDevueltos = ParesDevueltos
                DetFolio.MdiParent = Me.MdiParent
                DetFolio.Show()
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se ha seleccionado un Folio de inspección.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try



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
                        grdInspeccion.ExportToXlsx(.SelectedPath + "\Datos_ReporteInspeccionCalidad_" + fecha_hora + ".xlsx", exportOptions)
                    Else
                        grdInspeccion.ExportToXlsx(.SelectedPath + "\Datos_ReporteInspeccionCalidad_" + fecha_hora + ".xlsx", exportOptions)
                    End If
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "Datos_ReporteInspeccionCalidad_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_ReporteInspeccionCalidad_" + fecha_hora + ".xlsx")
                End If
            End With

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub chkFechaInspeccion_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechaInspeccion.CheckedChanged

        dtpFechaInicio.Enabled = chkFechaInspeccion.Checked
        dtpFechaFin.Enabled = chkFechaInspeccion.Checked

    End Sub

    Private Sub viewInspeccion_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewInspeccion.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub txtFiltroFolioInspeccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroFolioInspeccion.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroFolioInspeccion.Text) Then Return

            lstFiltroFoliosInspeccion.Add(txtFiltroFolioInspeccion.Text)
            grdFiltroFolioInspeccion.DataSource = Nothing
            grdFiltroFolioInspeccion.DataSource = lstFiltroFoliosInspeccion

            txtFiltroFolioInspeccion.Text = String.Empty

        End If
    End Sub

    Private Sub txtFiltroFolioSalida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroFolioSalida.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroFolioSalida.Text) Then Return

            lstFiltroFoliosSalida.Add(txtFiltroFolioSalida.Text)
            grdFiltroFolioSalida.DataSource = Nothing
            grdFiltroFolioSalida.DataSource = lstFiltroFoliosSalida

            txtFiltroFolioSalida.Text = String.Empty

        End If
    End Sub

    Private Sub grdFiltroFolioInspeccion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroFolioInspeccion.InitializeLayout
        grid_diseño(grdFiltroFolioInspeccion)
        grdFiltroFolioInspeccion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Folio Inspección"
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No

        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        asignaFormato_Columna(grid)

    End Sub

    'Asigna formato a columnas de ultragrid
    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("String") Then

                If col.Header.Caption.Equals("Télefono") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("Extensión") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If

            End If

        Next
    End Sub

    Private Sub grdFiltroFolioInspeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFiltroFolioInspeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFiltroFolioInspeccion.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFiltroFolioSalida_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFiltroFolioSalida.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFiltroFolioSalida.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFiltroFolioSalida_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroFolioSalida.InitializeLayout
        grid_diseño(grdFiltroFolioSalida)
        grdFiltroFolioSalida.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Folio Salida"
    End Sub

    Private Sub btnLimpiarFiltroNave_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroNave.Click
        grdNave.DataSource = lstInicial
    End Sub

    Private Sub btnLimpiarFiltroStatus_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroStatus.Click
        grdStatus.DataSource = lstInicial
    End Sub

    Private Sub grdNave_KeyDown(sender As Object, e As KeyEventArgs) Handles grdNave.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdNave.DeleteSelectedRows(False)
    End Sub

    Private Sub grdStatus_KeyDown(sender As Object, e As KeyEventArgs) Handles grdStatus.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdStatus.DeleteSelectedRows(False)
    End Sub

    Private Sub btnAgregarFiltroNave_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroNave.Click
        Dim listado As New ListadoParametrosForm
        listado.tipo_busqueda = 18
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdNave.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdNave.DataSource = listado.listParametros
        With grdNave
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(3).Hidden = True
            '.DisplayLayout.Bands(0).Columns(4).Hidden = True
            '.DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Nave"
        End With
    End Sub

    Private Sub btnAgregarFiltroStatus_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroStatus.Click
        Dim listado As New ListadoParametrosForm
        listado.tipo_busqueda = 17
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdStatus.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdStatus.DataSource = listado.listParametros
        With grdStatus
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(3).Hidden = True
            '.DisplayLayout.Bands(0).Columns(4).Hidden = True
            '.DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Estatus"
        End With
    End Sub

    Private Sub grdNave_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdNave.InitializeLayout
        grid_diseño(grdNave)
    End Sub

    Private Sub grdStatus_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdStatus.InitializeLayout
        grid_diseño(grdStatus)
    End Sub

    Private Sub viewInspeccion_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles viewInspeccion.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        'If (e.RowHandle = currentView.FocusedRowHandle) Then Return


        Try
            Cursor = Cursors.WaitCursor

            If e.Column.FieldName = "Incidencias" Then
                If e.CellValue > 0 Then
                    e.Appearance.ForeColor = Color.Red
                Else
                    e.Appearance.ForeColor = Color.Black
                End If
            End If

            If e.Column.FieldName = "IncidenciasMayores" Then
                If e.CellValue > 0 Then
                    e.Appearance.ForeColor = Color.Red
                Else
                    e.Appearance.ForeColor = Color.Black
                End If
            End If


            If e.Column.FieldName = "IncidenciasCriticas" Then
                If e.CellValue > 0 Then
                    e.Appearance.ForeColor = Color.Red
                Else
                    e.Appearance.ForeColor = Color.Black
                End If
            End If


            If e.Column.FieldName = "ParesDevueltos" Then
                If e.CellValue > 0 Then
                    e.Appearance.ForeColor = Color.Red
                Else
                    e.Appearance.ForeColor = Color.Black
                End If
            End If


            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)


        Dim Incidencias As Integer = viewInspeccion.GetRowCellValue(e.RowHandle, "Incidencias")
        Dim IncidenciasMayores As Integer = viewInspeccion.GetRowCellValue(e.RowHandle, "IncidenciasMayores")
        Dim IncidnciasCriticas As Integer = viewInspeccion.GetRowCellValue(e.RowHandle, "IncidenciasCriticas")
        Dim ParesDevueltos As Integer = viewInspeccion.GetRowCellValue(e.RowHandle, "ParesDevueltos")

        Try
            If e.ColumnFieldName = "Incidencias" Then
                If Incidencias > 0 Then
                    e.Formatting.Font.Color = Color.Red
                End If
            End If


            If e.ColumnFieldName = "IncidenciasMayores" Then
                If IncidenciasMayores > 0 Then
                    e.Formatting.Font.Color = Color.Red
                End If
            End If

            If e.ColumnFieldName = "IncidenciasCriticas" Then
                If IncidnciasCriticas > 0 Then
                    e.Formatting.Font.Color = Color.Red
                End If
            End If

            If e.ColumnFieldName = "ParesDevueltos" Then
                If ParesDevueltos > 0 Then
                    e.Formatting.Font.Color = Color.Red
                End If
            End If



        Catch ex As Exception

        End Try

        e.Handled = True
    End Sub

    Public Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                Resultado += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        Return Resultado
    End Function

    Private Sub viewInspeccion_RowClick(sender As Object, e As RowClickEventArgs) Handles viewInspeccion.RowClick
        Dim DetFolio As New DetallesFolioInspeccionFormvb
        Dim FolioInspeccionId As Integer = 0
        Dim ParesFolio As Integer = 0
        Dim ParesIncidencias As Integer = 0
        Dim ParesDevueltos As Integer = 0
        Dim Nave As String = String.Empty
        Dim ParesInspeccionados As Integer = 0

        If e.Clicks = 2 Then

            Try
                Cursor = Cursors.WaitCursor
                FolioInspeccionId = viewInspeccion.GetRowCellValue(viewInspeccion.GetVisibleRowHandle(e.RowHandle), "FolioInspeccionID").ToString()
                ParesFolio = viewInspeccion.GetRowCellValue(viewInspeccion.GetVisibleRowHandle(e.RowHandle), "ParesFolio").ToString()
                ParesIncidencias = viewInspeccion.GetRowCellValue(viewInspeccion.GetVisibleRowHandle(e.RowHandle), "Incidencias").ToString()
                ParesDevueltos = viewInspeccion.GetRowCellValue(viewInspeccion.GetVisibleRowHandle(e.RowHandle), "ParesDevueltos").ToString()
                Nave = viewInspeccion.GetRowCellValue(viewInspeccion.GetVisibleRowHandle(e.RowHandle), "Nave").ToString()
                ParesInspeccionados = viewInspeccion.GetRowCellValue(viewInspeccion.GetVisibleRowHandle(e.RowHandle), "ParesInspeccionados").ToString()
                'DiseñoGrid.EstiloColumna(viewInspeccion, "ParesInspeccionados", "Pares Inspeccionados", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "")


                If FolioInspeccionId > 0 Then
                    DetFolio.FolioInspeccionId = FolioInspeccionId
                    DetFolio.ParesFolio = ParesFolio
                    DetFolio.ParesInspeccionados = ParesInspeccionados
                    DetFolio.Nave = Nave
                    DetFolio.ParesIncidencias = ParesIncidencias
                    DetFolio.ParesDevueltos = ParesDevueltos
                    DetFolio.MdiParent = Me.MdiParent
                    DetFolio.Show()
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se ha seleccionado un Folio de inspección.")
                End If

                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            End Try


        End If

    End Sub
End Class