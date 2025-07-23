Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class DevolucionCliente_CapturaGeneral_DetallesArticulo_Tallas_Form

    Public DetalleID As Integer
    Public FolioDev As Integer
    Public ProductoEstiloID As Integer
    Public cargar As Boolean = False

    Private Sub DevolucionCliente_CapturaGeneral_DetallesArticulo_Tallas_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim negocios As New Negocios.DevolucionClientesBU
        Dim paresPorTallas As New DataTable
        paresPorTallas = negocios.ConsultarParesPorTalla(DetalleID, ProductoEstiloID, 1)
        grdParesPorTalla.DataSource = paresPorTallas
        If paresPorTallas.Rows.Count > 0 Then
            lblArticulo.Text = paresPorTallas.Rows(0).Item("DescripcionCompleta")
        End If

        Dim suma As Double = 0
        For Each row As UltraGridRow In grdParesPorTalla.Rows
            suma += CDbl(row.Cells("Pares").Value.ToString)
        Next
        lblNumFiltrados.Text = suma.ToString("N0")
    End Sub

    Public Sub ActualizarTallas()
        Try
            Dim obj As New Negocios.DevolucionClientesBU
            Cursor = Cursors.WaitCursor
            Dim xmlArticulos As XElement = New XElement("Detalles")
            For Each row As UltraGridRow In grdParesPorTalla.Rows
                Dim vNodo As XElement = New XElement("Detalle")
                vNodo.Add(New XAttribute("DetalleTalla", row.Cells("IdDetalleTalla").Value))
                vNodo.Add(New XAttribute("talla", row.Cells("Talla").Value))
                vNodo.Add(New XAttribute("cantidad", row.Cells("Pares").Value))
                vNodo.Add(New XAttribute("usuario", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                xmlArticulos.Add(vNodo)
            Next
            obj.ActualizarTallas(FolioDev, DetalleID, xmlArticulos.ToString())
            Dim ventana As New Tools.ExitoForm
            ventana.mensaje = "Tallas guardadas"
            ventana.ShowDialog()

        Catch ex As Exception
            Dim ventanaError As New Tools.ErroresForm
            ventanaError.mensaje = "Ocurrió un error al guardar " + vbCrLf + ex.Message
            ventanaError.ShowDialog()
        End Try
        Cursor = Cursors.Default
    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = ColumnStyle.IntegerNonNegative
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

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub grdParesPorTalla_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdParesPorTalla.InitializeLayout
        asignaFormato_Columna(grdParesPorTalla)
        With grdParesPorTalla.DisplayLayout
            .PerformAutoResizeColumns(True, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.AllowUpdate = DefaultableBoolean.True
            .Bands(0).Override.AllowUpdate = DefaultableBoolean.True

            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            '.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.Override.CellClickAction = CellClickAction.Edit
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.AllowAddNew = AllowAddNew.No
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            .Override.SelectTypeRow = SelectType.Single
            .Bands(0).Columns("DescripcionCompleta").Hidden = True
            .Bands(0).Columns("IdDetalleTalla").Hidden = True
            '.Bands(0).Columns("ProductoEstiloID").Hidden = True
            '.Bands(0).Columns("TallaSICY").Hidden = True
            .Bands(0).Columns("Pares").CellActivation = Activation.AllowEdit
            .Bands(0).Columns("Pares").Format = "N0"
            .Bands(0).Columns("Talla").CellActivation = Activation.NoEdit
        End With
        If grdParesPorTalla.Rows.Count > 0 And grdParesPorTalla.DisplayLayout.Bands(0).Columns.Exists("Pares") Then
            With grdParesPorTalla.DisplayLayout.Bands(0)
                .Columns("Pares").AllowRowSummaries = AllowRowSummaries.True
                Dim configuracionDeSuma As SummarySettings = .Summaries.Add(SummaryType.Sum, grdParesPorTalla.DisplayLayout.Bands(0).Columns("Pares"))

                configuracionDeSuma.DisplayFormat = "{0:###,###,##0.##}"
                configuracionDeSuma.Appearance.TextHAlign = HAlign.Right
                .SummaryFooterCaption = "Total:"
            End With
        End If
    End Sub

    Private Sub grdParesPorTalla_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdParesPorTalla.KeyPress
        Dim grid As UltraGrid = sender
        If e.KeyChar = ChrW(Keys.Enter) Then
            If e.KeyChar = "-" Then Return
            Dim cell As UltraGridCell = grid.ActiveCell
            Dim currentRow As Integer = grid.ActiveRow.Index
            Dim col As Integer = 3

            If currentRow < grdParesPorTalla.Rows.Last.Index Then
                cargar = True
                grdParesPorTalla.Focus()
                grid.Rows(currentRow + 1).Cells(col).Activate()
                grdParesPorTalla.PerformAction(UltraGridAction.ToggleCellSel, False, False)
                grid.PerformAction(UltraGridAction.EnterEditMode, False, False)

                Dim suma As Double = 0
                For Each row As UltraGridRow In grdParesPorTalla.Rows
                    suma += CDbl(row.Cells("Pares").Value.ToString)
                Next
                lblNumFiltrados.Text = suma.ToString("N0")
            Else
                grdParesPorTalla.ActiveCell = grdParesPorTalla.Rows(0).Cells("Pares")
                grdParesPorTalla.PerformAction(UltraGridAction.ToggleCellSel, False, False)
                grdParesPorTalla.PerformAction(UltraGridAction.EnterEditMode, False, False)
                btnAceptar.Select()
                ActualizarTallas()
                Me.Close()
            End If

        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        btnAceptar.Select()
        grdParesPorTalla.Rows(grdParesPorTalla.Rows.Last.Index).Cells(3).Activate()
        grdParesPorTalla.PerformAction(UltraGridAction.ToggleCellSel, False, False)
        'grdParesPorTalla.PerformAction(UltraGridAction., False, False)
        ActualizarTallas()
    End Sub

    Private Sub DevolucionCliente_CapturaGeneral_DetallesArticulo_Tallas_Form_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        If grdParesPorTalla.Rows.Count > 0 And cargar = False Then
            grdParesPorTalla.Focus()
            grdParesPorTalla.ActiveCell = grdParesPorTalla.Rows(0).Cells("Pares")
            grdParesPorTalla.PerformAction(UltraGridAction.ToggleCellSel, False, False)
            grdParesPorTalla.PerformAction(UltraGridAction.EnterEditMode, False, False)
            
        End If
    End Sub
End Class