Imports System.Globalization
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Programacion.Negocios

Public Class ListadoParametrosFiltradoForm

    Public tipo_busqueda As Integer
    Public listaParametroID As List(Of String)
    Public listParametros As New DataTable
    Public vIdNave As Integer

    Private Sub ListadoParametrosFiltrado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        poblar_gridListadoParametros(gridListadoParametros)

        For Each item In listaParametroID
            For Each row As UltraGridRow In gridListadoParametros.Rows
                If item = row.Cells(0).Text Then
                    row.Cells(" ").Value = True
                End If
            Next
        Next



        If tipo_busqueda = 1 Then
            lblTitulo.Text = "Marcas"
            Me.Text = "Marcas"
            Me.Size = New System.Drawing.Size(575, 506)
        Else
            If tipo_busqueda = 2 Then
                lblTitulo.Text = "Colecciones"
                Me.Text = "Colecciones"
                Me.Size = New System.Drawing.Size(650, 506)
            Else
                If tipo_busqueda = 3 Then
                    lblTitulo.Text = "Modelos"
                    Me.Text = "Modelos"
                    Me.Size = New System.Drawing.Size(600, 506)
                Else
                    If tipo_busqueda = 4 Then
                        lblTitulo.Text = "Piel"
                        Me.Text = "Piel"
                        Me.Size = New System.Drawing.Size(575, 506)
                    Else
                        If tipo_busqueda = 5 Then
                            lblTitulo.Text = "Color"
                            Me.Text = "Color"
                            Me.Size = New System.Drawing.Size(575, 506)
                        Else
                            If tipo_busqueda = 6 Then
                                lblTitulo.Text = "Corrida"
                                Me.Text = "Corrida"
                                Me.Size = New System.Drawing.Size(575, 506)
                            Else
                                If tipo_busqueda = 7 Then
                                    lblTitulo.Text = "Piel / Color"
                                    Me.Text = "Piel / Color"
                                    Me.Size = New System.Drawing.Size(575, 506)
                                Else
                                    If tipo_busqueda = 8 Then
                                        lblTitulo.Text = "Tipo de Material"
                                        Me.Text = "Tipo de Material"
                                        Me.Size = New System.Drawing.Size(575, 506)
                                    Else
                                        If tipo_busqueda = 10 Then
                                            lblTitulo.Text = "Naves Producción"
                                            Me.Text = "Naves Producción"
                                            Me.Size = New System.Drawing.Size(575, 506)
                                        Else
                                            If tipo_busqueda = 11 Then
                                                lblTitulo.Text = "Naves Desarrollo"
                                                Me.Text = "Naves Desarrollo"
                                                Me.Size = New System.Drawing.Size(575, 506)
                                            Else
                                                If tipo_busqueda = 13 Then
                                                    lblTitulo.Text = "Clientes"
                                                    Me.Text = "Clientes"
                                                    Me.Size = New System.Drawing.Size(575, 506)
                                                Else
                                                    If tipo_busqueda = 14 Then
                                                        lblTitulo.Text = "Familia"
                                                        Me.Text = "Familia"
                                                        Me.Size = New System.Drawing.Size(575, 506)
                                                    Else
                                                        If tipo_busqueda = 15 Then
                                                            lblTitulo.Text = "Articulo"
                                                            Me.Text = "Articulo"
                                                            Me.Size = New System.Drawing.Size(575, 506)
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
                End If
            End If
        End If

        Me.Top = (Me.Owner.Height - Me.Height) / 2
        Me.Left = (Me.Owner.Width - Me.Width) / 2

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If gridListadoParametros.Rows.Count = 0 Then Return

        Dim grid As DataTable = gridListadoParametros.DataSource
        listParametros = grid.Clone
        For Each row As UltraGridRow In gridListadoParametros.Rows
            If CBool(row.Cells(" ").Value) Then
                Dim fila As DataRow = listParametros.NewRow

                For index = 0 To row.Cells.Count - 1 Step 1
                    fila(index) = row.Cells(index).Value
                Next
                listParametros.Rows.Add(fila)
            End If
        Next
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
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
    End Sub

    Public Sub poblar_gridListadoParametros(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim objBU As New Programacion_Reportes_ParesProgramadosPorTallaBU
        Dim Tabla_ListadoParametros As New DataTable

        Tabla_ListadoParametros = objBU.ObtenerConsultaFiltro(tipo_busqueda, vIdNave)
        grid.DataSource = Tabla_ListadoParametros

        gridListadoParametrosDiseno(grid)

    End Sub

    Private Sub gridListadoParametrosDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        asignaFormato_Columna(grid)

        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = UltraWinGrid.ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If
        Next

    End Sub

    Private Sub gridListadoParametros_AfterRowActivate(sender As Object, e As EventArgs) Handles gridListadoParametros.AfterRowActivate
        gridListadoParametros.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        For Each row In gridListadoParametros.Rows
            row.Activation = Activation.NoEdit
        Next
    End Sub

    Private Sub gridListadoParametros_Click(sender As Object, e As EventArgs) Handles gridListadoParametros.Click

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

    End Sub
End Class