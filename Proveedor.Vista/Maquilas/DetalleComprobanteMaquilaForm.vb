Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinGrid
Imports Proveedores.BU

Public Class DetalleComprobanteMaquilaForm
    Public idcomprobante As Integer

    Private Sub DetalleComprobanteMaquilaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarGrid()
    End Sub

    Private Sub llenarGrid()
        Dim obj As New AgregarComprobanteBU
        Dim detalle As New DataTable

        detalle = obj.ObtenerComprobanteDetalle(idcomprobante)
        grdDetalles.DataSource = detalle
        disenioGrid()
        suma()
    End Sub

    Private Sub disenioGrid()
        Try
            With grdDetalles.DisplayLayout.Bands(0)
                .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
                .Columns("Precio").Format = "##,##0.00"
                .Columns("Total").Format = "##,##0.00"
                .Columns("Pares").Format = "##,##0"
                .Columns("Pares").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Total").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Precio").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            End With
            grdDetalles.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdDetalles.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

            'insertar sumatorias
            Dim sumPares As SummarySettings = grdDetalles.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdDetalles.DisplayLayout.Bands(0).Columns("Pares"))
            Dim sumTotal As SummarySettings = grdDetalles.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdDetalles.DisplayLayout.Bands(0).Columns("Total"))

            sumPares.DisplayFormat = "{0:#,##0}"
            sumPares.Appearance.TextHAlign = Infragistics.Win.HAlign.Right
            sumTotal.DisplayFormat = "{0:#,##0.00}"
            sumTotal.Appearance.TextHAlign = Infragistics.Win.HAlign.Right

            grdDetalles.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"

        Catch ex As Exception
        End Try
    End Sub

    Private Sub suma()
        Dim sumaTotal As Double
        Dim sumaPares As Integer

        sumaTotal = 0
        sumaPares = 0

        For Each row As UltraGridRow In grdDetalles.Rows
            sumaTotal += row.Cells("Total").Value
            sumaPares += row.Cells("Pares").Value
        Next

        lblTotalPares.Text = "" & sumaPares.ToString("##,##0")
        lblTotalDocumento.Text = "$ " & sumaTotal.ToString("##,##0.00")

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If grdDetalles.Rows.Count > 0 Then
            ExportarGridAExcel()
        End If
    End Sub

    Private Sub ExportarGridAExcel()

        Dim sfd As New SaveFileDialog

        sfd.DefaultExt = "xls"
        sfd.Filter = "Excel Files|*.xls"

        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor

                ultExportGrid.Export(grdDetalles, fileName)

                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()
                Process.Start(fileName)
            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm
                objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub
End Class