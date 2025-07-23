Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class DetalleSalidaCoppelForm
    Public listDetallesDeSalida As List(Of Entidades.DetallesDeSalida)

    Public Sub cargarDatos()
        grdDetallesSalida.DataSource = Nothing
        Dim dtDetalles As New DataTable
        Dim objBu As New Negocios.OTCoppelBU
        Me.Cursor = Cursors.WaitCursor
        dtDetalles = objBu.mostrarDetallesSalida(getIdotCoppel())
        Me.Cursor = Cursors.Default
        grdDetallesSalida.DataSource = dtDetalles
        formatoGrdDetallesSalida()
        totalPares()

    End Sub
    Public Function getIdotCoppel() As String
        Dim ids As String = ""
        Dim ban As Integer = 0
        If listDetallesDeSalida.Count > 0 Then
            For Each id As Entidades.DetallesDeSalida In listDetallesDeSalida
                If ban = 0 Then
                    ids += id.pIdotCoppel
                    ban = 1
                Else
                    ids += "," & id.pIdotCoppel
                End If
            Next
        End If
        Return ids
    End Function

    Public Sub totalPares()
        Dim i As Int32 = 0
        Dim totalPares As Int32 = 0
        For i = 0 To grdDetallesSalida.Rows.Count - 1
            totalPares = totalPares + 1
        Next
        lblTotalParesMostrar.Text = CStr(totalPares)
    End Sub

    Private Sub DetalleSalidaCoppelForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        cargarDatos()
    End Sub

    Public Sub formatoGrdDetallesSalida()
        Dim totalExternos As Integer = 0
        Dim totalCorrectos As Integer = 0
        With grdDetallesSalida.DisplayLayout.Bands(0)

            '.Columns("otdp_idLote").Header.Caption = "Lote"
            '.Columns("otdp_idPar").Header.Caption = "Par"
            '.Columns("atado").Header.Caption = "Atado"
            '.Columns("idModelo").Header.Caption = "Modelo"
            '.Columns("Descripcion").Header.Caption = "Descripción"
            '.Columns("Corrida").Header.Caption = "Corrida"
            '.Columns("otcod_talla").Header.Caption = "Talla"


            .Columns("Lote").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Par").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Atado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Modelo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Descripción").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Corrida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Talla").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("OT").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("St").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Entrega").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Tienda").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Nave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Año").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Salida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Talla").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Lote").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Pedido").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("OT").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Año").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Salida").Format = "dd/MM/yy H:mm"
        End With


        grdDetallesSalida.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdDetallesSalida.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdDetallesSalida.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDetallesSalida.DisplayLayout.Override.RowSelectorWidth = 35
        grdDetallesSalida.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grdDetallesSalida.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grdDetallesSalida.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grdDetallesSalida.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grdDetallesSalida.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdDetallesSalida.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grdDetallesSalida.DisplayLayout.GroupByBox.Hidden = False
        grdDetallesSalida.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"

        grdDetallesSalida.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdDetallesSalida.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDetallesSalida.DisplayLayout.Override.RowSelectorWidth = 60
        grdDetallesSalida.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        'grdDetallesSalida.Rows(0).Selected = True

        grdDetallesSalida.DisplayLayout.Bands(0).Columns("Descripción").Width = 540
        grdDetallesSalida.DisplayLayout.Bands(0).Columns("Lote").Width = 75
        grdDetallesSalida.DisplayLayout.Bands(0).Columns("Par").Width = 130
        grdDetallesSalida.DisplayLayout.Bands(0).Columns("Salida").Width = 118
        grdDetallesSalida.DisplayLayout.Bands(0).Columns("Tienda").Width = 180
        grdDetallesSalida.DisplayLayout.Bands(0).Columns("St").Width = 25
        grdDetallesSalida.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        For Each rowPar As UltraGridRow In grdDetallesSalida.Rows
            If rowPar.Cells("St").Value = "E" Then
                rowPar.Cells("St").Appearance.BackColor = Color.Red
                totalExternos += 1
                lblTotalExternos.Text = totalExternos.ToString()
            ElseIf rowPar.Cells("St").Value = "C" Then
                rowPar.Cells("St").Appearance.BackColor = Color.Green
                totalCorrectos += 1
                lblTotalCorrectos.Text = totalCorrectos.ToString()
            End If
        Next
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim formaConfirmacion As New ConfirmarForm
        formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
        formaConfirmacion.mensaje = "¿Estas seguro que deseas salir?"
        If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub exportarExcel()
        Dim grdExcelExportar As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacion As New FolderBrowserDialog
        Dim fecha As String = ""
        With fbdUbicacion
            .Reset()
            .Description = "Seleccione una carpeta"
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True
            Dim dr As DialogResult = .ShowDialog
            If dr = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                fecha = Now.Year.ToString + Now.Minute.ToString + Now.Day.ToString + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                grdExcelExportar.Export(Me.grdDetallesSalida, .SelectedPath + "\Datos_DetallesSalidas_" + fecha + ".xls")
                Me.Cursor = Cursors.Default
                Dim exito As New ExitoForm
                exito.mensaje = "Los datos se exportaron correctamente"
                exito.ShowDialog()
            End If
            .Dispose()
        End With

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel()
    End Sub
End Class