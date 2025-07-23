Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class BitacoraEmbarquesSalidas

    Private BuscarEmbarques As String

    Sub New(idBuscarEmbarques As String)
        InitializeComponent()
        BuscarEmbarques = idBuscarEmbarques
    End Sub

    Private Sub BitacoraEmbarquesSalidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.WindowState = 2
        Dim objBU As New Negocios.SalidasAlmacenBU
        Dim tabla_bitacora As New DataTable
        tabla_bitacora = objBU.consultaBitacoraEmbarques(BuscarEmbarques)
        grdDetallesSalida.DataSource = tabla_bitacora
        gridBitacoraDiseño(grdDetallesSalida)
        Cursor = Cursors.Default
    End Sub

    Private Sub gridBitacoraDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        'asignaFormato_Columna(grid)

        grid.DisplayLayout.Bands(0).Columns("saeb_embarqueid").Header.Caption = "#Embarque"
        grid.DisplayLayout.Bands(0).Columns("saeb_embarqueid").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("saeb_embarqueid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("saeb_fechaEmbarque").Header.Caption = "Embarque"
        grid.DisplayLayout.Bands(0).Columns("saeb_fechaEmbarque").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("saeb_fechaEmbarque").Format = "dd/MM/yyyy HH:mm:ss"

        grid.DisplayLayout.Bands(0).Columns("saeb_usuarioembarquenombre").Header.Caption = "Embarcó"
        grid.DisplayLayout.Bands(0).Columns("saeb_usuarioembarquenombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("saeb_operadorembarquenombre").Header.Caption = "Entregó"
        grid.DisplayLayout.Bands(0).Columns("saeb_operadorembarquenombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("saeb_mensajeriarealnombre").Header.Caption = "Mensajería Real"
        grid.DisplayLayout.Bands(0).Columns("saeb_mensajeriarealnombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("saeb_statusembarque").Header.Caption = "Status"
        grid.DisplayLayout.Bands(0).Columns("saeb_statusembarque").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("saeb_salidaid").Header.Caption = "#Salida"
        grid.DisplayLayout.Bands(0).Columns("saeb_salidaid").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("saeb_salidaid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("saeb_unidadEmbarqueNombre").Header.Caption = "Unidad"
        grid.DisplayLayout.Bands(0).Columns("saeb_unidadEmbarqueNombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("saeb_fechaRegistroBitacora").Header.Caption = "Fecha Modificación"
        grid.DisplayLayout.Bands(0).Columns("saeb_fechaRegistroBitacora").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("saeb_fechaRegistroBitacora").Format = "dd/MM/yyyy HH:mm:ss"


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

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New AdvertenciaForm
        grid = grdDetallesSalida
        If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 Then
            nombreDocumento = "\BitacoraEmbarque"

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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class