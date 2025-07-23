Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Produccion.Negocios
Imports Tools.modMensajes

Public Class ReporteLotesPilotoForm
    Dim msgAdvertencia As New Tools.AdvertenciaForm
    Dim msgError As New Tools.ErroresForm
    Dim msgExito As New Tools.ExitoForm
#Region "Private Methods"
    Private Sub DisenioGrid()
        vwReporte.BestFitColumns()
        vwReporte.OptionsView.ColumnAutoWidth = True
        vwReporte.OptionsView.EnableAppearanceEvenRow = True
        vwReporte.IndicatorWidth = 30
        vwReporte.OptionsView.ShowAutoFilterRow = True
        vwReporte.OptionsView.RowAutoHeight = True
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName.Contains("(SUM)") Then
                col.Caption = col.FieldName.Replace("(SUM)", "")
                col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
            End If
        Next

    End Sub
    Private Function Filtros(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim lista As New List(Of Integer)
        For Each Row As UltraGridRow In grid.Rows
            If Row.Cells(" ").Value Then lista.Add(Row.Cells(0).Value)
        Next
        Return String.Join(",", lista).ToString
    End Function
    Public Sub limpiarGrid(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DataSource = Nothing
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
#End Region
    Private Sub ReporteLotesPiloto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        dtpFechaFin.Value = Date.Now
        dtpFechaInicio.Value = Date.Now
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If vwReporte.DataRowCount > 0 Then
                nombreReporte = "Lotes_Piloto_"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If vwReporte.GroupCount > 0 Then
                            vwReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            'AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                            vwReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo")
        End Try
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim fechaInicioPrograma As Date = dtpFechaInicio.Value.ToShortDateString
            Dim fechaFinPrograma As Date = dtpFechaFin.Value.ToShortDateString
            Dim navesId As String = Filtros(grdNaves)
            grdReporte.DataSource = Nothing
            vwReporte.Columns.Clear()
            If fechaFinPrograma >= fechaInicioPrograma Then
                Dim obj As New ReportesBU
                Dim tabla As DataTable = obj.ObtenerLotesPiloto(navesId, fechaInicioPrograma, fechaFinPrograma)
                If tabla.Rows.Count > 0 Then
                    grdReporte.DataSource = tabla
                    DisenioGrid()
                    lblFechaUltimaActualización.Text = Date.Now.ToString
                    pnlParametros.Height = 27
                Else
                    msgAdvertencia.mensaje = "Nos encontro información."
                    msgAdvertencia.ShowDialog()
                End If
            Else
                msgAdvertencia.mensaje = "La fecha de fin debe ser mayor a la de inicio."
                msgAdvertencia.ShowDialog()
            End If
        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 183
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnLimNave_Click(sender As Object, e As EventArgs) Handles btnLimNave.Click
        limpiarGrid(grdNaves)
    End Sub

    Private Sub btnNave_Click(sender As Object, e As EventArgs) Handles btnNave.Click
        Dim listado As New ListadoParametrosForm
        listado.tipo_busqueda = 8 'Naves segun usuario
        listado.naveId_Colaborador = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser

        Dim listaParametroID As New List(Of String)

        For Each row As UltraGridRow In grdNaves.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdNaves.DataSource = listado.listaParametros
        grid_diseño(grdNaves)
        With grdNaves
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub grdNaves_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdNaves.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
End Class