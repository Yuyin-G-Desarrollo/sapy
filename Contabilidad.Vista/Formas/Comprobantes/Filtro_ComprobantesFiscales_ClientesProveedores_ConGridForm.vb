Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports Infragistics.Win
Imports System.Windows.Forms

Public Class Filtro_ComprobantesFiscales_ClientesProveedores_ConGridForm


    Public tipo_busqueda As Integer
    Public id_parametros As String
    Public listaParametroID As List(Of String)
    Public listParametros As New DataTable()

    Private Sub Filtro_ComprobantesFiscales_ClientesProveedores_ConGridForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        poblar_gridListadoParametros(gridListadoParametros)

        If tipo_busqueda = 1 Then
            For Each item In listaParametroID
                For Each row As UltraGridRow In gridListadoParametros.Rows
                    If item = row.Cells(0).Text Then
                        row.Cells(" ").Value = True
                    End If
                Next
            Next
        Else
            For Each item In listaParametroID
                For Each row As UltraGridRow In gridListadoParametros.Rows
                    If item = row.Cells(0).Text Then
                        row.Cells(" ").Value = True
                    End If
                Next
            Next
        End If


        If tipo_busqueda = 1 Then
            lblTitulo.Text = "Clientes"
            Me.Size = New System.Drawing.Size(575, 506)
        ElseIf tipo_busqueda = 2 Then
            lblTitulo.Text = "Proveedores"
            Me.Size = New System.Drawing.Size(575, 506)
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


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


    Public Sub poblar_gridListadoParametros(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim objBU As New Negocios.ComprobantesFiscalesBU
        Dim Tabla_ListadoParametros As New DataTable

        Tabla_ListadoParametros = objBU.ListadoParametroUbicacion(tipo_busqueda, id_parametros)

        grid.DataSource = Tabla_ListadoParametros

        gridListadoParametrosDiseno(grid)
    End Sub

    Private Sub gridListadoParametrosDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        asignaFormato_Columna(grid)

        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True

        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        grid.DisplayLayout.Bands(0).Columns("Razon_Social").Header.Caption = "Razón Social"

    End Sub


    Private Sub gridListadoParametros_Click(sender As Object, e As MouseEventArgs) Handles gridListadoParametros.Click

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
        lblNumFiltrados.Text = marcados.ToString("N0")
    End Sub

    Private Sub gridListadoParametros_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridListadoParametros.BeforeExitEditMode
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

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive
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

    Private Sub chboxMarcarTodo_CheckStateChanged(sender As Object, e As EventArgs) Handles chboxMarcarTodo.CheckStateChanged
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
        lblNumFiltrados.Text = marcados.ToString("N0")

    End Sub

End Class