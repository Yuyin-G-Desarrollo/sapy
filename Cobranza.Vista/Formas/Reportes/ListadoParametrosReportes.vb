Imports System.Drawing
Imports System.Globalization
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class ListadoParametrosReportes
    Public listaParametroID As New List(Of String)
    Public listaParametros As New DataTable
    Public UsuarioID As Integer = 0

    Public Sub PoblarGrid()
        Dim negocios As New Negocios.ConsultaDocumentosBU
        Dim datos As New DataTable

        datos = negocios.ConsultaClientes(UsuarioID)
        gridListadoParametros.DataSource = datos
        Dim marcados As Integer = 0
        For Each row As UltraGridRow In gridListadoParametros.Rows
            For Each elemento In listaParametroID
                If row.Cells("IdSICY").Value.ToString = elemento.ToString Then
                    row.Cells(" ").Value = True
                    marcados += 1
                End If
            Next
        Next

        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
        If marcados > 0 Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
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

    Public Sub diseñoGrid()
        With gridListadoParametros.DisplayLayout
            .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns

            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            .Override.SelectTypeRow = SelectType.Single

            .Bands(0).ColHeaderLines = 2

            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.AllowAddNew = AllowAddNew.No
            .Scrollbars = Scrollbars.Both

            'If .Bands(0).Columns.Exists("Activo") Then
            '.Bands(0).Columns("Activo").Hidden = True
            'End If
        End With
        asignaFormato_Columna(gridListadoParametros)
    End Sub

    Private Sub ListadoParametrosReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PoblarGrid()
    End Sub

    Private Sub gridListadoParametros_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridListadoParametros.InitializeLayout
        diseñoGrid()
    End Sub

    Private Sub gridListadoParametros_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridListadoParametros.ClickCell
        If Not Me.gridListadoParametros.ActiveRow.IsDataRow Then Return

        If IsNothing(gridListadoParametros.ActiveRow) Then Return

        If gridListadoParametros.ActiveRow.Cells(" ").Value Then
            gridListadoParametros.ActiveRow.Cells(" ").Value = False
        Else
            gridListadoParametros.ActiveRow.Cells(" ").Value = True
        End If


        Dim marcados As Integer
        For Each row As UltraGridRow In gridListadoParametros.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
        If marcados > 0 Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    Private Sub chboxMarcarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxMarcarTodo.CheckedChanged
        If chboxMarcarTodo.Checked Then
            For Each row In gridListadoParametros.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = True
            Next
        Else
            For Each row As UltraGridRow In gridListadoParametros.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = False
            Next
        End If
        Dim marcados As Integer
        For Each row As UltraGridRow In gridListadoParametros.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
        If marcados > 0 Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If gridListadoParametros.Rows.Count = 0 Then Return
        Dim grid As DataTable = gridListadoParametros.DataSource
        listaParametros = grid.Clone

        For Each row As UltraGridRow In gridListadoParametros.Rows
            If CBool(row.Cells(" ").Value) Then
                Dim fila As DataRow = listaParametros.NewRow

                For index = 0 To row.Cells.Count - 1 Step 1
                    fila(index) = row.Cells(index).Value
                Next
                listaParametros.Rows.Add(fila)
            End If
        Next
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class