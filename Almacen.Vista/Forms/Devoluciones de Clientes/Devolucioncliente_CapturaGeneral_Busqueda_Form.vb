Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Globalization

Public Class Devolucioncliente_CapturaGeneral_Busqueda_Form

    Public rowCliente As DataRow
    Public marcadoActualmente As Int32
    Private Sub Devolucioncliente_CapturaGeneral_Busqueda_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        poblar_gridListadoParametros(gridListadoParametros)


        lblTitulo.Text = "Clientes"
        Me.Size = New System.Drawing.Size(1024, 506)
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub



    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim coleccion As DataTable = gridListadoParametros.DataSource
        rowCliente = coleccion.Rows(marcadoActualmente)
    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Public Sub poblar_gridListadoParametros(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim objBU As New Negocios.DevolucionClientesBU
        Dim Tabla_ListadoParametros As New DataTable

        grid.DataSource = Nothing

        Tabla_ListadoParametros = objBU.ListaGenerica("ListadoClientes")
        grid.DataSource = Tabla_ListadoParametros
        gridListadoParametrosDiseno(grid)

    End Sub

    Private Sub gridListadoParametrosDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        asignaFormato_Columna(grid)
        With grid.DisplayLayout

            .PerformAutoResizeColumns(True, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns

            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.AllowAddNew = AllowAddNew.No
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            .Override.SelectTypeRow = SelectType.Single
            .Bands(0).Columns("clie_clienteid").Header.Caption = "ID SAY"
        End With
    End Sub

    Private Sub gridListadoParametros_BeforeExitEditMode(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridListadoParametros.BeforeExitEditMode
        Try
            Dim cellIndex As Integer = gridListadoParametros.ActiveCell.Column.Index

            If gridListadoParametros.ActiveRow.DataChanged Then

            Else
                If gridListadoParametros.ActiveCell.DataChanged Then
                Else
                    If String.IsNullOrWhiteSpace(gridListadoParametros.ActiveCell.Value) Then
                        gridListadoParametros.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                    End If
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridListadoParametros_AfterRowActivate(sender As Object, e As EventArgs) Handles gridListadoParametros.AfterRowActivate
        gridListadoParametros.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        For Each row In gridListadoParametros.Rows
            row.Activation = Activation.NoEdit
        Next
    End Sub

    'Asigna formato a columnas de ultragrid
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

    'Private Sub chboxMarcarTodo_CheckedChanged(sender As Object, e As EventArgs)
    '    If chboxMarcarTodo.Checked Then
    '        For Each row In gridListadoParametros.Rows.GetFilteredInNonGroupByRows
    '            row.Cells(" ").Value = True
    '        Next
    '    Else
    '        For Each row As UltraGridRow In gridListadoParametros.Rows.GetFilteredInNonGroupByRows
    '            row.Cells(" ").Value = False
    '        Next
    '    End If
    '    Dim marcados As Integer
    '    For Each row As UltraGridRow In gridListadoParametros.Rows
    '        If CBool(row.Cells(" ").Value) Then
    '            marcados += 1
    '        End If
    '    Next
    '    lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    'End Sub

    Private Sub gridListadoParametros_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridListadoParametros.ClickCell
        If Not Me.gridListadoParametros.ActiveRow.IsDataRow Then Return

        If IsNothing(gridListadoParametros.ActiveRow) Then Return

        If gridListadoParametros.Rows(marcadoActualmente).Cells(" ").Value Then
            gridListadoParametros.Rows(marcadoActualmente).Cells(" ").Value = False
        End If

        marcadoActualmente = gridListadoParametros.ActiveRow.Index
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
    End Sub
End Class