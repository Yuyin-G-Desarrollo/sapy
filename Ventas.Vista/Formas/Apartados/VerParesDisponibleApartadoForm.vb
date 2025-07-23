Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class VerParesDisponibleApartadoForm

    Public ApartadoId As String

    Private Sub VerParesDisponibleApartadoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        verPares()
    End Sub

    Public Sub verPares()
        Dim ObjBu As New Negocios.ApartadosBU
        Dim tablaPares As New DataTable

        tablaPares = ObjBu.consultarParesDisponiblesApartado(ApartadoId)

        grdParesDisponibles.DataSource = tablaPares

        lblTextoTituloVentana.Text = "Pares en existencia disponible del apartado " + ApartadoId
        Me.Text = "Pares en existencia disponible del apartado " + ApartadoId

        lblUltimaActualizacionFecha.Text = Date.Now.ToShortDateString()
        lblUltimaActualizacionHora.Text = Date.Now.ToShortTimeString()

        lblTotalPares.Text = grdParesDisponibles.Rows.Count

        gridParesDiseño(grdParesDisponibles)

    End Sub

    Private Sub gridParesDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Bands(0).Columns("fechaUbicacionHr").Header.Caption = "FechaUbicacionHr"
        grid.DisplayLayout.Bands(0).Columns("fechaUbicacionHr").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("fechaUbicacionHr").Format = "dd/MM/yyyy HH:mm:ss"

        grid.DisplayLayout.Bands(0).Columns("SalidaNaveHr").Header.Caption = "SalidaNaveHr"
        grid.DisplayLayout.Bands(0).Columns("SalidaNaveHr").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("SalidaNaveHr").Format = "dd/MM/yyyy HH:mm:ss"

        grid.DisplayLayout.Bands(0).Columns("EntradaAlmacenHr").Header.Caption = "EntradaAlmacenHr"
        grid.DisplayLayout.Bands(0).Columns("EntradaAlmacenHr").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("EntradaAlmacenHr").Format = "dd/MM/yyyy HH:mm:ss"

        grid.DisplayLayout.Bands(0).Columns("FechaUbicacionAnteriorHr").Header.Caption = "FechaUbicacionAnteriorHr"
        grid.DisplayLayout.Bands(0).Columns("FechaUbicacionAnteriorHr").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("FechaUbicacionAnteriorHr").Format = "dd/MM/yyyy HH:mm:ss"



        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grid.DisplayLayout.GroupByBox.Hidden = False
        grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"

        'grid.DisplayLayout.Bands(0).Columns("#").Width = 25

        Dim summary1 As SummarySettings
        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Prs"))
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right


        For Each row As UltraGridRow In grid.Rows

            If row.Cells("P/A").Text.Equals("P") Then
                row.Cells("P/A").Appearance.BackColor = pnlLocalizadoPar.BackColor
            Else
                If row.Cells("P/A").Text.Equals("A") Then
                    row.Cells("P/A").Appearance.BackColor = pnlLocalizadoAtado.BackColor
                Else
                    row.Cells("P/A").Appearance.BackColor = pnlLocalizadoError.BackColor
                    If row.Cells("PROCESO").Text.Equals("EXTERNO (Coppel)") Then
                        row.Cells("P/A").Appearance.BackColor = pnlLocalizadoCoppel.BackColor
                        row.Cells("P/A").Value = "C"
                    Else
                        row.Cells("P/A").Appearance.BackColor = pnlLocalizadoError.BackColor
                    End If
                End If
            End If

            If row.Cells("D").Text.Equals("1") Then
                row.Cells("D").Appearance.BackColor = pnlEstatusDisponible.BackColor
            End If

            If row.Cells("A").Text.Equals("1") Then
                row.Cells("A").Appearance.BackColor = pnlEstatusAsignado.BackColor
            End If

            If row.Cells("C").Text.Equals("1") Then
                row.Cells("C").Appearance.BackColor = pnlEstatusCalidad.BackColor
            End If

            If row.Cells("B").Text.Equals("1") Then
                row.Cells("B").Appearance.BackColor = pnlEstatusBloqueado.BackColor
            End If

            If row.Cells("R").Text.Equals("1") Then
                row.Cells("R").Appearance.BackColor = pnlEstatusReproceso.BackColor
            End If

            If row.Cells("P").Text.Equals("1") Then
                row.Cells("P").Appearance.BackColor = pnlEstatusProyectado.BackColor
            ElseIf row.Cells("P").Text.Equals("2") Then
                row.Cells("P").Appearance.BackColor = Color.HotPink
            End If
            If row.Cells("V").Text.Equals("1") Then
                row.Cells("V").Appearance.BackColor = pnlEstatusValidado.BackColor
            End If

        Next


        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If


    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Cursor = Cursors.WaitCursor
        grdParesDisponibles.DataSource = Nothing
        verPares()
        Cursor = Cursors.Default
    End Sub


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        With fbdUbicacionArchivo

            .Reset()
            .Description = " Seleccione una carpeta "
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True

            Dim ret As DialogResult = .ShowDialog

            If ret = Windows.Forms.DialogResult.OK Then

                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                gridExcelExporter.Export(Me.grdParesDisponibles, .SelectedPath + "\Pares_Disponibles_" + fecha_hora + ".xlsx")

            End If
            show_message("Exito", "Los datos se exportaron correctamente")
            .Dispose()

        End With
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try

            grdParesDisponibles.PrintPreview()

            grdParesDisponibles.Print()
        Catch exc As Exception

            MessageBox.Show("Error al imprimir." & vbCrLf & exc.Message, "Error impresión.", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Muestra el form de mensaje
    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub gridListaUbicacion_BeforePrint(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs) Handles grdParesDisponibles.BeforePrint

        ' Following code shows a message box giving the user a last chance to cancel printing the 
        ' UltraGrid.
        Dim result As DialogResult = MessageBox.Show("¿Seguro que desea imprimir?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If DialogResult.Cancel = result Then e.Cancel = True

    End Sub

    Private Sub gridListaUbicacion_InitializePrintPreview(sender As Object, e As CancelablePrintPreviewEventArgs) Handles grdParesDisponibles.InitializePrintPreview

        e.PrintDocument.DefaultPageSettings.Landscape = True
        e.PrintLayout.Appearance.BackColor = Color.White
        'e.PrintLayout.Grid.DisplayLayout.Appearance.BackColor = Color.White
        'e.PrintLayout.Grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.White
        ''e.PrintPreviewSettings.Zoom = 100
        e.PrintLayout.Override.RowAlternateAppearance.BackColor = Color.White
        e.PrintDocument.DefaultPageSettings.Margins.Left = 0
        e.PrintDocument.DefaultPageSettings.Margins.Right = 0

        With e.PrintLayout

            .Bands(0).Columns(1).Hidden = True
            '.Bands(0).Columns(2).Header.Caption = "PAR"
            '.Bands(0).Columns(3).Header.Caption = "ATADO"

        End With

    End Sub

End Class