Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ResumenListaPrecios_Form

    Public idLista As Int16
    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        show_message("Advertencia", "Esta consulta puede tomar varios segundos en desplegarse.")
        MostararResumenListaBase()
    End Sub

    Private Sub MostararResumenListaBase()
        Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.ListaBaseBU
        Dim tablaResultado As New DataTable

        tablaResultado = objBU.ConsultarResumenListaPreciosBase(idLista)
        grdResumenListaPrecios.DataSource = Nothing
        grdResumenListaPrecios.DataSource = tablaResultado
        gridInventarioDiseño(grdResumenListaPrecios)

        lblFechaUltimaActualizacion.Text = Date.Now.ToString()
        Cursor = Cursors.Default


    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then

            Dim mensajeAdvertencia As New AdvertenciaFormGrande
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

    Private Sub btnExportarExcelInventario_Click(sender As Object, e As EventArgs) Handles btnExportarExcelInventario.Click
        Cursor = Cursors.WaitCursor
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New AdvertenciaForm
        grid = grdResumenListaPrecios
        If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 Then
            nombreDocumento = "\Resumen_Lista_De_Precios_Base_"


            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta"
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog

                If ret = Windows.Forms.DialogResult.OK Then

                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                    gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")

                    Dim mensajeExito As New ExitoForm
                    Cursor = Cursors.Default
                    mensajeExito.mensaje = "Los datos se exportaron correctamente"
                    mensajeExito.ShowDialog()

                End If
            End With
        Else
            Cursor = Cursors.Default
            advertencia.mensaje = "No hay datos para exportar "
            advertencia.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub gridInventarioDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim band As UltraGridBand = Me.grdResumenListaPrecios.DisplayLayout.Bands(0)
        Me.grdResumenListaPrecios.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.GroupLayout
        Me.grdResumenListaPrecios.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.AllowAll
        Dim grupoGeneral As UltraGridGroup = band.Groups.Add("general", "GENERAL")
        grupoGeneral.Header.Appearance.BackColor = Color.Cyan
        Dim grupoListaVentas As UltraGridGroup = band.Groups.Add("listaVentas", "LISTA DE VENTAS")
        Dim grupoCliente As UltraGridGroup = band.Groups.Add("cliente", "CLIENTE")

        With band
            .Columns("LBase").RowLayoutColumnInfo.ParentGroup = grupoGeneral
            .Columns("#ListaVtas").RowLayoutColumnInfo.ParentGroup = grupoGeneral
            .Columns("Agentes").RowLayoutColumnInfo.ParentGroup = grupoGeneral
            .Columns("Cliente").RowLayoutColumnInfo.ParentGroup = grupoGeneral

            .Columns("%Factura").RowLayoutColumnInfo.ParentGroup = grupoListaVentas
            .Columns("TipoIVA").RowLayoutColumnInfo.ParentGroup = grupoListaVentas
            .Columns("TipoFlete").RowLayoutColumnInfo.ParentGroup = grupoListaVentas
            .Columns("%Descuento").RowLayoutColumnInfo.ParentGroup = grupoListaVentas
            .Columns("%Fact").RowLayoutColumnInfo.ParentGroup = grupoListaVentas

            .Columns("IVA").RowLayoutColumnInfo.ParentGroup = grupoCliente
            .Columns("Flete").RowLayoutColumnInfo.ParentGroup = grupoCliente
            .Columns("Desc Docto").RowLayoutColumnInfo.ParentGroup = grupoCliente
            .Columns("Desc Cobranza").RowLayoutColumnInfo.ParentGroup = grupoCliente
            .Columns("PlazoPago").RowLayoutColumnInfo.ParentGroup = grupoCliente
        End With

        With grdResumenListaPrecios.DisplayLayout
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            .Override.SelectTypeRow = SelectType.Single
            .Override.AllowUpdate = DefaultableBoolean.False
            .Bands(0).ColHeaderLines = 2

            .Bands(0).Groups("general").Header.Appearance.BackColor = Color.Silver
            .Bands(0).Groups("listaVentas").Header.Appearance.BackColor = Color.LightSkyBlue
            .Bands(0).Groups("cliente").Header.Appearance.BackColor = Color.YellowGreen

            .Bands(0).Columns(0).Header.Caption = "Lista" + vbCrLf + "Base"
            .Bands(0).Columns(1).Header.Caption = "#Lista " + vbCrLf + "Ventas"
            .Bands(0).Columns(5).Header.Caption = "Tipo IVA"
            .Bands(0).Columns(6).Header.Caption = "Tipo Flete"
            .Bands(0).Columns(13).Header.Caption = "Plazo" + vbCrLf + "Pago"

            .Bands(0).Columns(0).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .Bands(0).Columns(1).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .Bands(0).Columns(2).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .Bands(0).Columns(3).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .Bands(0).Columns(4).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .Bands(0).Columns(5).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .Bands(0).Columns(6).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .Bands(0).Columns(7).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .Bands(0).Columns(8).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .Bands(0).Columns(9).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .Bands(0).Columns(10).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .Bands(0).Columns(11).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .Bands(0).Columns(12).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .Bands(0).Columns(13).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)

            .Bands(0).Columns("LBase").Format = "n0"
            .Bands(0).Columns(1).Format = "n0"
            .Bands(0).Columns("%Fact").Format = "n0"
            .Bands(0).Columns(13).Format = "n0"
            .Bands(0).Columns("%Fact").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Bands(0).Columns(13).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right


            grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            'grid.DisplayLayout.Override.RowSelectorWidth = 20
            grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
            grid.DisplayLayout.GroupByBox.Hidden = False
            grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"


            Dim width As Integer
            For Each col As UltraGridColumn In grid.Rows.Band.Columns
                col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                If Not col.Hidden Then
                    width += col.Width
                End If
            Next

            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.AllowAddNew = AllowAddNew.No
            .Scrollbars = Scrollbars.Both
        End With
    End Sub

    Private Sub ResumenListaPrecios_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.Location = New Point(0, 0)
        Me.WindowState = 2
        MostararResumenListaBase()
    End Sub
End Class