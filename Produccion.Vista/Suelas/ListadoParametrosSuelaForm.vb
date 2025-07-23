Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Windows.Forms
Imports System.Globalization

Public Class ListadoParametrosSuelaForm
    Public tipo_busqueda As Integer
    Public listaParametroID As List(Of String)
    Public listaParametros As New DataTable
    Public naveId_Colaborador As Integer = 0
    Dim objAdvertencia As New Tools.AdvertenciaForm

    Private Sub ListadoParametrosSuelaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Me.Name = "Marcas"
            Me.Size = New System.Drawing.Size(575, 506)
        Else
            If tipo_busqueda = 2 Then
                Me.Name = "Colecciones"
                lblTitulo.Text = "Colecciones"
                Me.Size = New System.Drawing.Size(575, 506)
            End If
            If tipo_busqueda = 3 Then
                lblTitulo.Text = "Estatus"
                Me.Name = "Estatus"
                Me.Size = New System.Drawing.Size(575, 506)
            ElseIf tipo_busqueda = 4 Then
                lblTitulo.Text = "Naves"
                Me.Name = "Naves"
                Me.Size = New System.Drawing.Size(575, 506)
            ElseIf tipo_busqueda = 5 Then
                Me.Name = "Suelas"
                lblTitulo.Text = "Suelas"
                Me.Size = New System.Drawing.Size(575, 506)
                gridListadoParametros.DisplayLayout.Bands(0).Columns(2).Header.Caption = "Suelas"
            ElseIf tipo_busqueda = 6 Then
                Me.Name = "Operadores"
                lblTitulo.Text = "Operadores"
                Me.Size = New System.Drawing.Size(575, 506)

            ElseIf tipo_busqueda = 7 Then
                lblTitulo.Text = "Máquinas"
                Me.Name = "Máquinas"
                Me.Size = New System.Drawing.Size(575, 506)
                gridListadoParametros.DisplayLayout.Bands(0).Columns(2).Header.Caption = "Máquinas"
                gridListadoParametros.DisplayLayout.Bands(0).Columns(1).Width = 2
            End If
        End If
        Me.Top = (Me.Owner.Height - Me.Height) / 2
        Me.Left = (Me.Owner.Width - Me.Width) / 2
    End Sub

    Public Sub poblar_gridListadoParametros(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DataSource = Nothing

        Dim objBU As New Negocios.ArticulosSuelaBU
        Dim Tabla_ListadoParametros As New DataTable

        Tabla_ListadoParametros = objBU.ListadoParametroArticulos(tipo_busqueda, naveId_Colaborador)
        If Tabla_ListadoParametros.Rows.Count > 0 Then
            grid.DataSource = Tabla_ListadoParametros
            gridListadoParametrosDiseno(grid)
        Else
            objAdvertencia.mensaje = "No se encontro informacion"
            objAdvertencia.ShowDialog()
            Me.Close()
        End If

    End Sub

    Public Sub gridListadoParametrosDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
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

    Private Sub gridListadoParametros_AfterRowActivate(sender As Object, e As EventArgs) Handles gridListadoParametros.AfterRowActivate
        gridListadoParametros.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        For Each row In gridListadoParametros.Rows
            row.Activation = Activation.NoEdit
        Next
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