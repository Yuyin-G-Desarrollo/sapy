Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class DevolucionCliente_CapturaGeneral_LecturaCodigos_PedidosDocumentos

    Public documentosSeleccionados As String
    Public pedidosSeleccionados As String

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then
                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("String") Then
                If col.Header.Caption.Equals("TELÉFONO") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("EXTENSIÓN") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If
            End If
        Next
    End Sub

    Public Sub SumarColumnas(grid As UltraGrid, columna As String, tipoSuma As Int16)
        If grid.Rows.Count > 0 And grid.DisplayLayout.Bands(0).Columns.Exists(columna) Then
            With grid.DisplayLayout.Bands(0)
                .Columns(columna).AllowRowSummaries = AllowRowSummaries.True
                Dim configuracionDeSuma As SummarySettings = .Summaries.Add(tipoSuma, grid.DisplayLayout.Bands(0).Columns(columna))

                configuracionDeSuma.DisplayFormat = "{0}"
                configuracionDeSuma.Appearance.TextHAlign = HAlign.Right
                .SummaryFooterCaption = "Total:"
                'MsgBox(grdArticulos.Rows.SummaryValues(configuracionDeSuma).Value)
            End With
        End If
    End Sub

    Public Sub FormatoGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        With grid.DisplayLayout
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
            .Override.AllowUpdate = DefaultableBoolean.False
            .Scrollbars = Scrollbars.Both
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            .Override.SelectTypeRow = SelectType.Single


            If .Bands(0).Columns.Exists(" ") Then
                .Bands(0).Columns(" ").Hidden = True
            End If

            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.FilterUIType = FilterUIType.FilterRow
        End With

    End Sub

    Private Sub grdPedidos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidos.InitializeLayout
        FormatoGrid(grdPedidos)
        grdPedidos.DisplayLayout.Scrollbars = Scrollbars.None
        grdPedidos.DisplayLayout.Scrollbars = Scrollbars.Vertical
        asignaFormato_Columna(grdPedidos)
        If grdPedidos.DisplayLayout.Bands(0).Columns.Exists("FechaÚltimoDocto") Then
            grdPedidos.DisplayLayout.Bands(0).Columns("FechaÚltimoDocto").Header.Caption = "FÚltimoDocto"
        End If
        grdPedidos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub grdDocumentos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdDocumentos.InitializeLayout
        FormatoGrid(grdDocumentos)
        asignaFormato_Columna(grdDocumentos)
        SumarColumnas(grdDocumentos, "Pares", 1)
        If grdDocumentos.DisplayLayout.Bands(0).Columns.Exists("FolioFactura") Then
            grdDocumentos.DisplayLayout.Bands(0).Columns("FolioFactura").Header.Caption = "Factura"
        End If
        If grdDocumentos.DisplayLayout.Bands(0).Columns.Exists("FechaDocumento") Then
            grdDocumentos.DisplayLayout.Bands(0).Columns("FechaDocumento").Header.Caption = "FDocto"
        End If
        If grdDocumentos.DisplayLayout.Bands(0).Columns.Exists("DoctoSeleccionado") Then
            grdDocumentos.DisplayLayout.Bands(0).Columns("DoctoSeleccionado").Hidden = True
        End If

        If grdDocumentos.DisplayLayout.Bands(0).Columns.Exists("fcdd_productoestiloid") Then
            grdDocumentos.DisplayLayout.Bands(0).Columns("fcdd_productoestiloid").Hidden = True
        End If

        If grdDocumentos.DisplayLayout.Bands(0).Columns.Exists("Total") Then
            grdDocumentos.DisplayLayout.Bands(0).Columns("Total").Format = String.Format("n2")
        End If

        If grdDocumentos.DisplayLayout.Bands(0).Columns.Exists("Pares") Then
            grdDocumentos.DisplayLayout.Bands(0).Columns("Pares").Format = String.Format("N0")
        End If
        If grdDocumentos.Rows.Count = 0 Then
            grdDocumentos.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        End If
    End Sub

    Private Sub DevolucionCliente_CapturaGeneral_LecturaCodigos_PedidosDocumentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objBU As New Negocios.DevolucionClientesBU
        grdDocumentos.DataSource = objBU.ListaDocumentosFacturas(documentosSeleccionados)
        grdPedidos.DataSource = objBU.ListaPedidosFacturados(pedidosSeleccionados)
    End Sub
End Class