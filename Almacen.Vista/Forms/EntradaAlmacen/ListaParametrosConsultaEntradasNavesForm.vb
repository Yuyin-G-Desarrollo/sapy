Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaParametrosConsultaEntradasNavesForm

    Public id_tipo_busqueda As Integer '1 = CLIENTES, 2 = TIENDAS, 3 = CORRIDAS, 4 = PRODUCTOS, 5 TALLAS
    Public id_parametros As String
    Public lParametroID As List(Of String)
    Public dtParametros As New DataTable()


    Private Sub ListaParametrosConsultaEntradasNaves_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen

        If id_tipo_busqueda = 1 Then
            lblTitulo.Text = "Clientes"
            Me.Text = "Clientes"
        ElseIf id_tipo_busqueda = 2 Then
            Me.Size = New System.Drawing.Size(450, 506)
            lblTitulo.Text = "Tiendas"
            Me.Text = "Tiendas"
        ElseIf id_tipo_busqueda = 3 Then
            Me.Size = New System.Drawing.Size(350, 506)
            lblTitulo.Text = "Corridas"
            Me.Text = "Corridas"
        ElseIf id_tipo_busqueda = 4 Then
            Me.Size = New System.Drawing.Size(1075, 506)
            lblTitulo.Text = "Productos"
            Me.Text = "Productos"
        ElseIf id_tipo_busqueda = 5 Then
            Me.Size = New System.Drawing.Size(350, 506)
            lblTitulo.Text = "Tallas"
            Me.Text = "Tallas"
       End If

        Me.StartPosition = FormStartPosition.CenterScreen

        PoblarGridParametros(id_tipo_busqueda)

        For Each item In lParametroID
            For Each row As UltraGridRow In grdListadoParametros.Rows
                If item = row.Cells(0).Text Then
                    row.Cells(" ").Value = True
                End If
            Next
        Next

    End Sub

    Private Sub PoblarGridParametros(ByVal IdBusqueda)
        Dim objBU As New Negocios.EntradaProductoBU
        dtParametros = objBU.RecuperarInformacionDelParametro(IdBusqueda)

        grdListadoParametros.DataSource = dtParametros

    End Sub

#Region "Grid"

    Private Sub grdListadoParametros_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdListadoParametros.InitializeLayout
        With grdListadoParametros
            If id_tipo_busqueda = 4 Then
                .DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            Else
                .DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
            End If

            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Bands(0).Columns(" ").Style = ColumnStyle.CheckBox
            .DisplayLayout.Bands(0).Columns(" ").CellActivation = Activation.AllowEdit
            .DisplayLayout.Bands(0).Columns("Parámetro").Hidden = True
        End With


        For Each col In grdListadoParametros.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
                col.CellActivation = Activation.NoEdit
            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then
                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right
                col.CellActivation = Activation.NoEdit
            End If

            If col.DataType.Name.ToString.Equals("String") Then
                If col.Header.Caption.Equals(" ") Then
                    col.Style = ColumnStyle.CheckBox
                    col.CellActivation = Activation.AllowEdit
                    col.CellAppearance.TextHAlign = HAlign.Center
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                    col.CellActivation = Activation.NoEdit
                End If

            End If

        Next

    End Sub

    Private Sub grdListadoParametros_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListadoParametros.ClickCell

        If grdListadoParametros.ActiveRow.IsFilterRow Then Return

        If IsNothing(grdListadoParametros.ActiveRow) Then Return

        If grdListadoParametros.ActiveRow.Cells(" ").Value Then

            grdListadoParametros.ActiveRow.Cells(" ").Value = False
        Else
            grdListadoParametros.ActiveRow.Cells(" ").Value = True
        End If
        Dim marcados As Integer
        For Each row As UltraGridRow In grdListadoParametros.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0")
    End Sub


    Private Sub grdListadoParametros_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles grdListadoParametros.BeforeExitEditMode
        Try
            Dim cellIndex As Integer = grdListadoParametros.ActiveCell.Column.Index

            If grdListadoParametros.ActiveRow.DataChanged Then

            Else
                If grdListadoParametros.ActiveCell.DataChanged Then
                Else
                    If String.IsNullOrWhiteSpace(grdListadoParametros.ActiveCell.Value) Then
                        'poblar_gridListadoParametros(String.Empty, gridListadoParametros)
                        grdListadoParametros.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                    End If
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If grdListadoParametros.Rows.Count = 0 Then Return

        Dim grid As DataTable = grdListadoParametros.DataSource
        dtParametros = grid.Clone
        For Each row As UltraGridRow In grdListadoParametros.Rows
            If CBool(row.Cells(" ").Value) Then
                Dim fila As DataRow = dtParametros.NewRow

                For index = 0 To row.Cells.Count - 1 Step 1
                    fila(index) = row.Cells(index).Value
                Next
                dtParametros.Rows.Add(fila)
            End If
        Next

    End Sub

   




    Private Sub chboxMarcarTodo_CheckStateChanged(sender As Object, e As EventArgs) Handles chboxMarcarTodo.CheckStateChanged
        If chboxMarcarTodo.Checked Then
            For Each row In grdListadoParametros.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = True
            Next
        Else
            For Each row As UltraGridRow In grdListadoParametros.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = False
            Next
        End If
        Dim marcados As Integer
        For Each row As UltraGridRow In grdListadoParametros.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0")

    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub



End Class