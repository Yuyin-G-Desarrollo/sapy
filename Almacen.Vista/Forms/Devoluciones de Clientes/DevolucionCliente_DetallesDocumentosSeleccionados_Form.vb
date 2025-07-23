Imports DevExpress.Utils
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class DevolucionCliente_DetallesDocumentosSeleccionados_Form

    Public FolioDev As Integer = 0

    Private Sub DevolucionCliente_DetallesDocumentosSeleccionados_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim negocios As New Negocios.DevolucionClientesBU
        grdDetallesDocumentos.DataSource = negocios.Consulta_DocumentosDetalles(FolioDev)
        DiseñoGridPrincipal()
    End Sub

    Public Sub DiseñoGridPrincipal()
        Try
            bgvDetallesDocumentos.OptionsView.ColumnAutoWidth = True

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvDetallesDocumentos.Columns
                col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            Next

            bgvDetallesDocumentos.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatType = FormatType.Numeric
            bgvDetallesDocumentos.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatString = "N0"

            bgvDetallesDocumentos.Columns.ColumnByFieldName("TotalPartida").DisplayFormat.FormatType = FormatType.Numeric
            bgvDetallesDocumentos.Columns.ColumnByFieldName("TotalPartida").DisplayFormat.FormatString = "N2"

            bgvDetallesDocumentos.Columns.ColumnByFieldName("TotalDocumento").DisplayFormat.FormatType = FormatType.Numeric
            bgvDetallesDocumentos.Columns.ColumnByFieldName("TotalDocumento").DisplayFormat.FormatString = "N2"

            bgvDetallesDocumentos.Columns.ColumnByFieldName("DevolucionClienteID").Visible = False
            bgvDetallesDocumentos.Columns.ColumnByFieldName("DetalleID").Visible = False
            bgvDetallesDocumentos.Columns.ColumnByFieldName("ProductoEstiloID").Visible = False
            bgvDetallesDocumentos.Columns.ColumnByFieldName("TotalDocumento").Visible = False

            SumarColumnas("Pares", "{0:N0}")
            SumarColumnas("TotalPartida", "{0:N2}")
            SumarColumnas("TotalDocumento", "{0:N2}")

            bgvDetallesDocumentos.IndicatorWidth = 40
            bgvDetallesDocumentos.BestFitColumns()
        Catch ex As Exception
            Tools.Controles.Mensajes_Y_Alertas("ERROR", "Error " + ex.Message)
        End Try
    End Sub

    Public Sub SumarColumnas(columna As String, formato As String)
        If IsNothing(bgvDetallesDocumentos.Columns(columna).Summary.FirstOrDefault(Function(x) x.FieldName = columna)) = True Then
            bgvDetallesDocumentos.Columns(columna).Summary.Add(DevExpress.Data.SummaryItemType.Sum, columna, formato)

            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = columna
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = formato
            bgvDetallesDocumentos.GroupSummary.Add(item)
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub bgvDetallesDocumentos_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles bgvDetallesDocumentos.RowCellStyle
        If e.RowHandle Mod 2 <> 0 Then
            e.Appearance.BackColor = Color.LightSteelBlue
        End If

        Dim currentView As GridView = CType(sender, GridView)

        If bgvDetallesDocumentos.RowCount <= 0 Then Return
        Try
            Cursor = Cursors.WaitCursor
            If e.Column.FieldName = "PS" Then
                Dim StatusDev As String = bgvDetallesDocumentos.GetRowCellValue(e.RowHandle, "PS").ToString
                If StatusDev = "C" Then
                    e.Appearance.BackColor = pnlC.BackColor
                    'e.Appearance.ForeColor = pnlC.BackColor
                ElseIf StatusDev = "P" Then
                    e.Appearance.BackColor = pnlP.BackColor
                    'e.Appearance.ForeColor = pnlP.BackColor

                End If
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            'MsgBox("Error" + ex.Message.ToString())
        End Try
    End Sub

    Private Sub bgvDetallesDocumentos_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvDetallesDocumentos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub bgvDetallesDocumentos_CustomDrawCell(sender As Object, e As Views.Base.RowCellCustomDrawEventArgs) Handles bgvDetallesDocumentos.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)

        If bgvDetallesDocumentos.RowCount <= 0 Then Return
        Try
            Cursor = Cursors.WaitCursor
            If e.Column.FieldName = "PS" Then
                Dim StatusDev As String = bgvDetallesDocumentos.GetRowCellValue(e.RowHandle, "St").ToString
                If StatusDev = "C" Then
                    e.Appearance.BackColor = pnlC.BackColor
                    e.Appearance.ForeColor = pnlC.BackColor
                ElseIf StatusDev = "P" Then
                    e.Appearance.BackColor = pnlP.BackColor
                    e.Appearance.ForeColor = pnlP.BackColor

                End If
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            'MsgBox("Error" + ex.Message.ToString())
        End Try
    End Sub
End Class