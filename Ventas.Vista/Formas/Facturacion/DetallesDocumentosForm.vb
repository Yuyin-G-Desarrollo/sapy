Imports DevExpress.Data
Imports DevExpress.Export
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Linq

Public Class DetallesDocumentosForm

    'Dim TotalParesPedido As Integer
    'Dim sumSubTotal As Decimal
    'Dim sumImporte As Decimal
    Dim CalcularsumSubTotal As Boolean = True
    Dim CalcularsumImporte As Boolean = True

    Private _Documentos As String
    Public Property Documentos() As String
        Get
            Return _Documentos
        End Get
        Set(ByVal value As String)
            _Documentos = value
        End Set
    End Property


    Dim ObjBu As New Negocios.AdministradorDocumentosBU

    Private Sub DetallesDocumentosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor

        CargarGrid()
        DiseñoGrid(GrdVDocumentosDetalles)

        Cursor = Cursors.Default
    End Sub

    Private Sub CargarGrid()
        Dim dtDocumentos As DataTable
        'Dim dtSum As DataTable
        Try

            dtDocumentos = ObjBu.ConsultarDetallesDocumentos(_Documentos)
            'dtSum = ObjBu.ConsultarDetallesDocumentos_TotalParesPedido(_Documentos)
            GrdDocumentosDetalles.DataSource = dtDocumentos

            lblRegistros.Text = dtDocumentos.Rows.Count.ToString("N0")

            'TotalParesPedido = dtSum.Rows(0).Item(0)
            'sumSubTotal = dtSum.Rows(0).Item(1)
            'sumImporte = dtSum.Rows(0).Item(2)

        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try
    End Sub

    Private Sub DiseñoGrid(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        'Grid.OptionsView.BestFitMaxRowCount = -1
        Grid.OptionsView.ColumnAutoWidth = False
        Grid.BestFitColumns()

        Grid.IndicatorWidth = 30

        Grid.OptionsView.EnableAppearanceEvenRow = True
        Grid.OptionsView.EnableAppearanceOddRow = True
        Grid.OptionsSelection.EnableAppearanceFocusedCell = True
        Grid.OptionsSelection.EnableAppearanceFocusedRow = True
        Grid.Appearance.SelectedRow.Options.UseBackColor = True

        Grid.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)

        Grid.Appearance.EvenRow.BackColor = Color.White
        Grid.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        Grid.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        Grid.Appearance.FocusedRow.ForeColor = Color.White

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsColumn.AllowEdit = False
            col.BestFit()
            col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Next

        Grid.Columns.ColumnByFieldName("ParesPedido").Visible = False

        Grid.Columns.ColumnByFieldName("FDocto").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Grid.Columns.ColumnByFieldName("FDocto").DisplayFormat.FormatString = "dd/MM/yyyy"

        Grid.Columns.ColumnByFieldName("ParesPedido").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("ParesPedido").DisplayFormat.FormatString = "N0"
        Grid.Columns.ColumnByFieldName("ParesFacturados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("ParesFacturados").DisplayFormat.FormatString = "N0"
        Grid.Columns.ColumnByFieldName("PrecioDocto").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("PrecioDocto").DisplayFormat.FormatString = "n2"
        Grid.Columns.ColumnByFieldName("Subtotal").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("Subtotal").DisplayFormat.FormatString = "n2"
        Grid.Columns.ColumnByFieldName("Descuento").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("Descuento").DisplayFormat.FormatString = "n2"
        Grid.Columns.ColumnByFieldName("Importe").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("Importe").DisplayFormat.FormatString = "n2"
        Grid.Columns.ColumnByFieldName("IVA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("IVA").DisplayFormat.FormatString = "n2"
        Grid.Columns.ColumnByFieldName("Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("Total").DisplayFormat.FormatString = "n2"

        Grid.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        Grid.Columns.ColumnByFieldName("ParesFacturados").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Grid.Columns.ColumnByFieldName("ParesFacturados").SummaryItem.DisplayFormat = "{0:N0}"
        Grid.Columns.ColumnByFieldName("PrecioDocto").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Grid.Columns.ColumnByFieldName("PrecioDocto").SummaryItem.DisplayFormat = "{0:N2}"
        Grid.Columns.ColumnByFieldName("Subtotal").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Grid.Columns.ColumnByFieldName("Subtotal").SummaryItem.DisplayFormat = "{0:N2}"
        Grid.Columns.ColumnByFieldName("Descuento").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Grid.Columns.ColumnByFieldName("Descuento").SummaryItem.DisplayFormat = "{0:N2}"
        Grid.Columns.ColumnByFieldName("Importe").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Grid.Columns.ColumnByFieldName("Importe").SummaryItem.DisplayFormat = "{0:N2}"
        Grid.Columns.ColumnByFieldName("IVA").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Grid.Columns.ColumnByFieldName("IVA").SummaryItem.DisplayFormat = "{0:N2}"
        Grid.Columns.ColumnByFieldName("Total").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Grid.Columns.ColumnByFieldName("Total").SummaryItem.DisplayFormat = "{0:N2}"

        Grid.Columns.ColumnByFieldName("Cliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("Factura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("RFCEmisor").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("RFCReceptor").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("EstatusDocto").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("Descripcion").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("Piel").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("Color").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("ListaPrecios").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("Tienda").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

    End Sub


    Private Sub GrdVDocumentosDetalles_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles GrdVDocumentosDetalles.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim SaveFileDialog As New SaveFileDialog
        Dim NombreArchivo As String = "Detalles_Documentos"

        SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
        SaveFileDialog.FilterIndex = 2
        SaveFileDialog.RestoreDirectory = True

        'ASIGNAMOS UN NOMBRE AL ARCHIVO
        SaveFileDialog.FileName = NombreArchivo + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString + ".xlsx"
        If GrdVDocumentosDetalles.RowCount > 0 Then
            If SaveFileDialog.ShowDialog = DialogResult.OK Then

                'ESTO ES NECESARIO PARA QUE EL EXCEL NO HAGA QUE TODAS LAS CUADRICULAS SEAN MUY PEQUEÑAS.
                'ESTO EXPORTARÁ TODAS LAS CUADRICULAS ESPACIADAS UNIFORMENTE.
                GrdVDocumentosDetalles.OptionsPrint.AutoWidth = True
                GrdVDocumentosDetalles.OptionsPrint.EnableAppearanceEvenRow = True
                GrdVDocumentosDetalles.OptionsPrint.EnableAppearanceOddRow = True
                GrdVDocumentosDetalles.OptionsPrint.PrintHorzLines = False
                GrdVDocumentosDetalles.OptionsPrint.PrintVertLines = False

                GrdVDocumentosDetalles.OptionsPrint.PrintPreview = True

                Dim FileName As String = SaveFileDialog.FileName

                Dim exportOptions = New DevExpress.XtraPrinting.XlsxExportOptionsEx()
                DevExpress.Export.ExportSettings.DefaultExportType = ExportType.Default
                GrdVDocumentosDetalles.ExportToXlsx(FileName, exportOptions)

                Dim msg_Exito As New Tools.ExitoForm
                msg_Exito.mensaje = "Los datos se exportaron correctamente."
                msg_Exito.ShowDialog()

                System.Diagnostics.Process.Start(FileName)
            End If
        Else
            Dim msg_adv As New Tools.AdvertenciaForm
            msg_adv.mensaje = "No hay registros para exportar."
            msg_adv.ShowDialog()
        End If
    End Sub



End Class