Imports DevExpress.XtraPrinting
Imports DevExpress.Export
Public Class CodigosConErrorForm

    Public dtCodigosError As DataTable
    Dim SalidaEntradaMuestras As New PedidosMuestras_SalidasEntradas

    Private Sub CodigosConErrorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GrdCodigoErrorMuestras.DataSource = dtCodigosError
        DiseñoGridNoEditable(GrdVCodigosErrorMuestras)
        lblCodigosIncorrectos.Text = dtCodigosError.Rows.Count
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click

        Dim SaveFileDialog As New SaveFileDialog
        Dim NombreArchivo As String = "Codigos_Incorrectos"

        SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
        SaveFileDialog.FilterIndex = 2
        SaveFileDialog.RestoreDirectory = True

        'ASIGNAMOS UN NOMBRE AL ARCHIVO
        SaveFileDialog.FileName = NombreArchivo + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString + ".xlsx"
        If GrdVCodigosErrorMuestras.RowCount > 0 Then
            If SaveFileDialog.ShowDialog = DialogResult.OK Then

                'ESTO ES NECESARIO PARA QUE EL EXCEL NO HAGA QUE TODAS LAS CUADRICULAS SEAN MUY PEQUEÑAS.
                'ESTO EXPORTARÁ TODAS LAS CUADRICULAS ESPACIADAS UNIFORMENTE.
                GrdVCodigosErrorMuestras.OptionsPrint.AutoWidth = True
                GrdVCodigosErrorMuestras.OptionsPrint.EnableAppearanceEvenRow = True
                GrdVCodigosErrorMuestras.OptionsPrint.EnableAppearanceOddRow = True
                GrdVCodigosErrorMuestras.OptionsPrint.PrintHorzLines = False
                GrdVCodigosErrorMuestras.OptionsPrint.PrintVertLines = False

                GrdVCodigosErrorMuestras.OptionsPrint.PrintPreview = True

                Dim FileName As String = SaveFileDialog.FileName

                Dim exportOptions = New XlsxExportOptionsEx()
                DevExpress.Export.ExportSettings.DefaultExportType = ExportType.Default
                GrdVCodigosErrorMuestras.ExportToXlsx(FileName, exportOptions)

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

    Public Sub DiseñoGridNoEditable(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Grid.OptionsView.BestFitMaxRowCount = -1
        Grid.OptionsView.ColumnAutoWidth = True
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
        Next

    End Sub

End Class