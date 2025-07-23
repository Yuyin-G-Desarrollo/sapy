Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ConsultarParesSalidaAlmacenForm

    Private salidasBuscarPares As String
    Private objFiltrosPares As Entidades.FiltrosParesEmbarquesSalidas
    Private tipoConsulta As Integer

    Sub New(ByVal idSalidasBuscarPares As String)
        InitializeComponent()
        salidasBuscarPares = idSalidasBuscarPares
        tipoConsulta = 1
    End Sub

    Sub New(ByVal objFiltroConsultaParesEmbarquesSalidas As Entidades.FiltrosParesEmbarquesSalidas)
        InitializeComponent()
        objFiltrosPares = objFiltroConsultaParesEmbarquesSalidas
        tipoConsulta = 2
    End Sub

    Private Sub ConsultarParesSalidaAlmacenForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.WindowState = 2
        Dim objBU As New Negocios.SalidasAlmacenBU
        Dim tabla_pares As New DataTable
        If tipoConsulta = 1 Then
            tabla_pares = objBU.consultaParesEmbarques(salidasBuscarPares)
        Else
            tabla_pares = objBU.consultaParesEmbarquesConFiltros(objFiltrosPares)
        End If
        grdDetallesSalida.DataSource = tabla_pares
        gridParesDiseño(grdDetallesSalida)
        Cursor = Cursors.Default
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New AdvertenciaForm
        grid = grdDetallesSalida
        If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 Then
            nombreDocumento = "\Pares"

            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog

                If ret = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                    gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                    Dim mensajeExito As New ExitoForm
                    mensajeExito.mensaje = "Los datos se exportaron correctamente"
                    Cursor = Cursors.Default
                    mensajeExito.ShowDialog()

                End If
                .Dispose()
            End With
        Else
            advertencia.mensaje = "No hay datos para exportar "
            advertencia.ShowDialog()
        End If
    End Sub

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

    Private Sub gridParesDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        'asignaFormato_Columna(grid)

        grid.DisplayLayout.Bands(0).Columns("sadp_embarqueid").Header.Caption = "#Embarque"
        grid.DisplayLayout.Bands(0).Columns("sadp_embarqueid").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sadp_embarqueid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("sadp_mensajeriarealnombre").Header.Caption = "Mensajería Real"
        grid.DisplayLayout.Bands(0).Columns("sadp_mensajeriarealnombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("sadp_idfactura").Header.Caption = "Factura"
        grid.DisplayLayout.Bands(0).Columns("sadp_idfactura").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sadp_idfactura").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("sadp_añodocumento").Header.Caption = "Año"
        grid.DisplayLayout.Bands(0).Columns("sadp_añodocumento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sadp_añodocumento").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("sadp_iddocumento").Header.Caption = "Docto"
        grid.DisplayLayout.Bands(0).Columns("sadp_iddocumento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sadp_iddocumento").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("sadp_idordentrabajo").Header.Caption = "OT"
        grid.DisplayLayout.Bands(0).Columns("sadp_idordentrabajo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sadp_idordentrabajo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("sadp_idpedido").Header.Caption = "Pedido"
        grid.DisplayLayout.Bands(0).Columns("sadp_idpedido").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sadp_idpedido").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("sadp_nombrecadena_cliente").Header.Caption = "Cliente"
        grid.DisplayLayout.Bands(0).Columns("sadp_nombrecadena_cliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("sadp_nombredistribucion_tienda").Header.Caption = "Tienda"
        grid.DisplayLayout.Bands(0).Columns("sadp_nombredistribucion_tienda").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("sadp_statusembarque").Header.Caption = "Status"
        grid.DisplayLayout.Bands(0).Columns("sadp_statusembarque").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("sadp_codigoatado").Header.Caption = "Atado"
        grid.DisplayLayout.Bands(0).Columns("sadp_codigoatado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sadp_codigoatado").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("sadp_codigopar").Header.Caption = "Par"
        grid.DisplayLayout.Bands(0).Columns("sadp_codigopar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sadp_codigopar").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("sadp_descripcionmodelo").Header.Caption = "Descripción"
        grid.DisplayLayout.Bands(0).Columns("sadp_descripcionmodelo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("sadp_descripcioncorrida").Header.Caption = "Corrida"
        grid.DisplayLayout.Bands(0).Columns("sadp_descripcioncorrida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sadp_descripcioncorrida").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("sadp_calce").Header.Caption = "Talla"
        grid.DisplayLayout.Bands(0).Columns("sadp_calce").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sadp_calce").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("sadp_lote").Header.Caption = "Lote"
        grid.DisplayLayout.Bands(0).Columns("sadp_lote").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sadp_lote").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("sadp_nombrenave").Header.Caption = "Nave"
        grid.DisplayLayout.Bands(0).Columns("sadp_nombrenave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("sadp_añolote").Header.Caption = "Año"
        grid.DisplayLayout.Bands(0).Columns("sadp_añolote").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sadp_añolote").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("sadp_fechaembarque").Header.Caption = "Embarque"
        grid.DisplayLayout.Bands(0).Columns("sadp_fechaembarque").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sadp_fechaembarque").Format = "dd/MM/yyyy HH:mm:ss"

        grid.DisplayLayout.Bands(0).Columns("sadp_salidaid").Header.Caption = "#Salida"
        grid.DisplayLayout.Bands(0).Columns("sadp_salidaid").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sadp_salidaid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("sadp_fechasalida").Header.Caption = "Salida"
        grid.DisplayLayout.Bands(0).Columns("sadp_fechasalida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sadp_fechasalida").Format = "dd/MM/yyyy HH:mm:ss"

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

        Dim summary1 As SummarySettings
        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Count, grid.DisplayLayout.Bands(0).Columns("sadp_codigopar"))
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right

        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
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

End Class