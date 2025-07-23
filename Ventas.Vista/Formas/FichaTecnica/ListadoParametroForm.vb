Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Globalization

Public Class ListadoParametroForm

    Public tipo_busqueda As Integer
    Public id_parametros As String
    'Public listaParametroID As List(Of String)
    'Public listParametros As New DataTable()

    Private Sub ListadoParametroUbicacionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        poblar_gridListadoParametros(gridListadoParametros)


        If tipo_busqueda = 1 Then
            lblTitulo.Text = "Productos"
            Me.Size = New System.Drawing.Size(1075, 506)
        Else
            If tipo_busqueda = 2 Then
                lblTitulo.Text = "Clientes"
                Me.Size = New System.Drawing.Size(575, 506)
            Else
                If tipo_busqueda = 3 Then
                    lblTitulo.Text = "Corridas"
                    Me.Size = New System.Drawing.Size(375, 506)
                Else
                    If tipo_busqueda = 4 Then
                        lblTitulo.Text = "Bahías"
                        Me.Size = New System.Drawing.Size(575, 506)
                    Else
                        If tipo_busqueda = 5 Then
                            lblTitulo.Text = "Naves"
                            Me.Size = New System.Drawing.Size(375, 506)
                        Else
                            If tipo_busqueda = 6 Then
                                lblTitulo.Text = "Operadores"
                                Me.Size = New System.Drawing.Size(575, 506)
                            Else
                                If tipo_busqueda = 7 Then
                                    lblTitulo.Text = "Agentes"
                                    Me.Size = New System.Drawing.Size(575, 506)
                                Else
                                    If tipo_busqueda = 8 Then
                                        lblTitulo.Text = "Descripción de bahías"
                                        Me.Size = New System.Drawing.Size(475, 506)
                                    Else
                                        If tipo_busqueda = 9 Then
                                            lblTitulo.Text = "Tiendas"
                                            Me.Size = New System.Drawing.Size(775, 506)
                                        Else
                                            If tipo_busqueda = 10 Then
                                                lblTitulo.Text = "Tallas"
                                                Me.Size = New System.Drawing.Size(375, 506)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        Me.Top = (Me.Owner.Height - Me.Height) / 2
        Me.Left = (Me.Owner.Width - Me.Width) / 2

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If gridListadoParametros.Rows.Count = 0 Then Return

        Dim grid As DataTable = gridListadoParametros.DataSource
        'listParametros = grid.Clone
        For Each row As UltraGridRow In gridListadoParametros.Rows
            If CBool(row.Cells(" ").Value) Then
                id_parametros = row.Cells("Parámetro").Value
                Exit For
            End If
        Next

    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


    Public Sub poblar_gridListadoParametros(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim objBU As New Negocios.ClientesBU
        Dim Tabla_ListadoParametros As New DataTable

        Tabla_ListadoParametros = objBU.ListadoParametroUbicacion(tipo_busqueda, id_parametros)

        grid.DataSource = Tabla_ListadoParametros

        gridListadoParametrosDiseno(grid)

    End Sub

    Private Sub gridListadoParametrosDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        asignaFormato_Columna(grid)

        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True

        If tipo_busqueda = 1 Then
            grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        Else
            If tipo_busqueda = 2 Then
                grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
            Else
                If tipo_busqueda = 3 Then
                    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                Else
                    If tipo_busqueda = 4 Then
                        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                    Else
                        If tipo_busqueda = 5 Then
                            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                        Else
                            If tipo_busqueda = 6 Then
                                grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                            Else
                                If tipo_busqueda = 7 Then
                                    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                                Else
                                    If tipo_busqueda = 8 Then
                                        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                                    Else
                                        If tipo_busqueda = 9 Then
                                            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                                        Else
                                            If tipo_busqueda = 10 Then
                                                grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

    End Sub

    'Private Sub gridListadoParametros_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles gridListadoParametros.AfterRowFilterChanged


    '    If gridListadoParametros.Rows.GetFilteredOutNonGroupByRows.Count > 0 Then
    '        Me.gridListadoParametros.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
    '        gridListadoParametros.DisplayLayout.Override.SelectTypeCol = SelectType.None
    '    Else
    '        Me.gridListadoParametros.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
    '        gridListadoParametros.DisplayLayout.Override.SelectTypeCol = SelectType.Default
    '    End If

    '    'If True Then
    '    '    Dim row As UltraGridFilterRow = Me.gridListadoParametros.Rows.FilterRow
    '    '    For Each cell As UltraGridFilterCell In row.Cells


    '    '    Next
    '    'End If

    'End Sub

    Private Sub gridListadoParametros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridListadoParametros.KeyPress

    End Sub

    Private Sub gridListadoParametros_Click(sender As Object, e As MouseEventArgs) Handles gridListadoParametros.Click

        'If Me.gridListadoParametros.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select Then
        '    Return

        'End If

        If Not Me.gridListadoParametros.ActiveRow.IsDataRow Then Return

        For Each row As UltraGridRow In gridListadoParametros.Rows
            If row.Cells(" ").Value Then
                row.Cells(" ").Value = False
            End If
        Next

        If IsNothing(gridListadoParametros.ActiveRow) Then Return

        If gridListadoParametros.ActiveRow.Cells(" ").Value Then

            gridListadoParametros.ActiveRow.Cells(" ").Value = False
        Else
            gridListadoParametros.ActiveRow.Cells(" ").Value = True
        End If

        'Dim marcados As Integer
        'For Each row As UltraGridRow In gridListadoParametros.Rows
        '    If CBool(row.Cells(" ").Value) Then
        '        marcados += 1
        '    End If
        'Next
        'lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)

    End Sub

    Private Sub gridListadoParametros_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridListadoParametros.BeforeExitEditMode
        Try
            Dim cellIndex As Integer = gridListadoParametros.ActiveCell.Column.Index

            If gridListadoParametros.ActiveRow.DataChanged Then

            Else
                If gridListadoParametros.ActiveCell.DataChanged Then
                Else
                    If String.IsNullOrWhiteSpace(gridListadoParametros.ActiveCell.Value) Then
                        'poblar_gridListadoParametros(String.Empty, gridListadoParametros)
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

    'Private Sub chboxMarcarTodo_CheckStateChanged(sender As Object, e As EventArgs) Handles chboxMarcarTodo.CheckStateChanged
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


End Class