Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Globalization

Public Class ListadoTiendasImprimirFacturacion_Form

    Public clienteId As Integer
    Public listaParametroID As List(Of Integer)
    Public listParametros As New DataTable

    Dim objBU As New Negocios.VistaPreviaDocumentosBU

    Private Sub ListadoTiendasImprimirFacturacion_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        poblar_gridListadoParametros(gridListadoParametros)

        For Each item In listaParametroID
            For Each row As UltraGridRow In gridListadoParametros.Rows
                If item = row.Cells(0).Text Then
                    row.Cells(" ").Value = True
                End If
            Next
        Next

        lblTitulo.Text = "Tiendas / Embarques / CEDIS"
        Me.Size = New System.Drawing.Size(650, 506)


        Me.Top = (Me.Owner.Height - Me.Height) / 2
        Me.Left = (Me.Owner.Width - Me.Width) / 2
    End Sub


    Public Sub poblar_gridListadoParametros(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim Tabla_ListadoParametros As New DataTable

        Tabla_ListadoParametros = objBU.consultaTiendasPorCliente(clienteId)

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

        For Each col As UltraGridColumn In grid.DisplayLayout.Bands(0).Columns
            If col.Header.Caption = "Año" Then
                grid.DisplayLayout.Bands(0).Columns("Año").Width = 40
            End If
        Next

    End Sub

    'Asigna formato a columnas de ultragrid
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


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If gridListadoParametros.Rows.Count = 0 Then Return
        listParametros.Columns.Add("Parámetro")
        listParametros.Columns.Add("Tiendas / Embarques / CEDIS")

        For Each row As UltraGridRow In gridListadoParametros.Rows
            If CBool(row.Cells(" ").Value) Then
                listParametros.Rows.Add(row.Cells("Parámetro").Value, row.Cells("Tiendas / Embarques / CEDIS").Value)
            End If
        Next
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub gridListadoParametros_Click(sender As Object, e As EventArgs) Handles gridListadoParametros.Click
        If Not Me.gridListadoParametros.ActiveRow.IsDataRow Then Return

        If IsNothing(gridListadoParametros.ActiveRow) Then Return


        If gridListadoParametros.ActiveRow.Cells(" ").Value Then

            gridListadoParametros.ActiveRow.Cells(" ").Value = False
        Else
            gridListadoParametros.ActiveRow.Cells(" ").Value = True
        End If

        For Each renglon As UltraGridRow In gridListadoParametros.Rows
            If renglon.Activated = False Then
                renglon.Cells(" ").Value = False
            End If
        Next

        Dim marcados As Integer = 0
        For Each row As UltraGridRow In gridListadoParametros.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next

        If marcados = 0 Then
            btnAceptar.Enabled = False
            lblAceptar.Enabled = False
        Else
            btnAceptar.Enabled = True
            lblAceptar.Enabled = True
        End If

        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Private Sub gridListadoParametros_AfterRowActivate(sender As Object, e As EventArgs) Handles gridListadoParametros.AfterRowActivate
        gridListadoParametros.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        For Each row In gridListadoParametros.Rows
            row.Activation = Activation.NoEdit
        Next
    End Sub


End Class