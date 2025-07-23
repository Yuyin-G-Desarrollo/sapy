Imports System.Drawing
Imports System.Globalization
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Proveedores.BU

Public Class listadoHormasForm
    Public listaParametroID As List(Of String)
    Public listaParametros As New DataTable
    Dim objAdvertencia As New Tools.AdvertenciaForm

    Private Sub listadoHormasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Hormas"
        lblTitulo.Text = "Hormas"
        poblar_gridHormas(gridListadoHormas)

        For Each item In listaParametroID
            For Each row As UltraGridRow In gridListadoHormas.Rows
                If item = row.Cells(0).Text Then
                    row.Cells(" ").Value = True
                End If

            Next
        Next

        Me.Top = (Me.Owner.Height - Me.Height) / 2
        Me.Left = (Me.Owner.Width - Me.Width) / 2

    End Sub
    Private Sub poblar_gridHormas(grid As UltraGrid)

        grid.DataSource = Nothing
        Dim objBU As New ReporteMaterialesBU
        Dim tabla_listadoParametros As New DataTable
        tabla_listadoParametros = objBU.ListadoHormas()
        If tabla_listadoParametros.Rows.Count > 0 Then
            grid.DataSource = tabla_listadoParametros
            gridListadoHormasDiseño(grid)
        Else
            objAdvertencia.mensaje = "No se encontró información"
            objAdvertencia.ShowDialog()
            Me.Close()
        End If
    End Sub

    Private Sub gridListadoHormasDiseño(grid As UltraGrid)
        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
        With grid.DisplayLayout
            .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.AllowAddNew = AllowAddNew.No
        End With
    End Sub

    Private Sub gridListadoHormas_Click(sender As Object, e As EventArgs) Handles gridListadoHormas.Click
        If Not Me.gridListadoHormas.ActiveRow.IsActiveRow Then Return

        If IsNothing(gridListadoHormas.ActiveRow) Then Return

        If gridListadoHormas.ActiveRow.Cells(" ").Value Then
            gridListadoHormas.ActiveRow.Cells(" ").Value = False
        Else
            gridListadoHormas.ActiveRow.Cells(" ").Value = True
        End If

        Dim marcados As Integer
        For Each row As UltraGridRow In gridListadoHormas.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Private Sub chboxMarcarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxMarcarTodo.CheckedChanged
        If chboxMarcarTodo.Checked Then
            For Each row In gridListadoHormas.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = True
            Next
        Else
            For Each row In gridListadoHormas.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = False
            Next
        End If
        Dim marcados As Integer
        For Each row As UltraGridRow In gridListadoHormas.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If gridListadoHormas.Rows.Count = 0 Then Return
        Dim grid As DataTable = gridListadoHormas.DataSource

        listaParametros = grid.Clone
        For Each row As UltraGridRow In gridListadoHormas.Rows
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