Imports System.Drawing
Imports System.Globalization
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class FiltroPatronesForm

    Public listaParametroID As List(Of String)
    Public listParametros As New DataTable

    Public Sub poblar_gridListadoParametros(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim objBU As New Negocios.CatalogoDiasNoLaboralesBU
        Dim Tabla_ListadoParametros As New DataTable

        Tabla_ListadoParametros = objBU.Patrones(Date.Now.Year)
        grid.DataSource = Tabla_ListadoParametros

        gridListadoParametrosDiseno(grid)

    End Sub

    Private Sub gridListadoParametrosDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

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

        For Each col As UltraGridColumn In grid.DisplayLayout.Bands(0).Columns
            If col.Header.Caption = "Año" Then
                grid.DisplayLayout.Bands(0).Columns("Año").Width = 40
            End If
        Next

    End Sub

    Private Sub FiltroPatronesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        poblar_gridListadoParametros(gridpatrones)
        For Each item In listaParametroID
            For Each row As UltraGridRow In gridpatrones.Rows
                If item = row.Cells(0).Text Then
                    row.Cells(" ").Value = True
                End If
            Next
        Next
    End Sub
    Private Sub chboxMarcarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxMarcarTodo.CheckedChanged
        If chboxMarcarTodo.Checked Then
            For Each row In gridpatrones.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = True
            Next
        Else
            For Each row As UltraGridRow In gridpatrones.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = False
            Next
        End If
        Dim marcados As Integer
        For Each row As UltraGridRow In gridpatrones.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If gridpatrones.Rows.Count = 0 Then Return

        Dim grid As DataTable = gridpatrones.DataSource
        listParametros = grid.Clone
        For Each row As UltraGridRow In gridpatrones.Rows
            If CBool(row.Cells(" ").Value) Then
                Dim fila As DataRow = listParametros.NewRow

                For index = 0 To row.Cells.Count - 1 Step 1
                    fila(index) = row.Cells(index).Value
                Next
                listParametros.Rows.Add(fila)
            End If
        Next
    End Sub
    Private Sub gridListadoParametros_Click(sender As Object, e As EventArgs) Handles gridpatrones.Click
        Try
            If Not Me.gridpatrones.ActiveRow.IsDataRow Then Return

            If IsNothing(gridpatrones.ActiveRow) Then Return

            If gridpatrones.ActiveRow.Cells(" ").Value Then

                gridpatrones.ActiveRow.Cells(" ").Value = False
            Else
                gridpatrones.ActiveRow.Cells(" ").Value = True
            End If
            Dim marcados As Integer
            For Each row As UltraGridRow In gridpatrones.Rows
                If CBool(row.Cells(" ").Value) Then
                    marcados += 1
                End If
            Next
            lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, ex.Message)
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class