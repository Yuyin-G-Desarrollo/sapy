Imports System.Drawing
Imports System.Globalization
Imports Cobranza.Negocios
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Public Class ListadoParametrosProyeccionCobranza
    Public tipo_busqueda As Integer = 0
    Public listaParametroId As List(Of String)
    Public listaParametros As New DataTable
    Private Sub ListadoParametrosProyeccionCobranza_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        poblarGrid(gridListadoParametros)

        For Each item In listaParametroId
            For Each row As UltraGridRow In gridListadoParametros.Rows
                If item = row.Cells(0).Text Then
                    row.Cells(" ").Value = True
                End If
            Next
        Next

        If tipo_busqueda = 1 Then
            lblTitulo.Text = "Clientes"
            Me.Size = New System.Drawing.Size(575, 506)
        End If
        If tipo_busqueda = 2 Then
            lblTitulo.Text = "Razón Social"
            Text = "Cobranza Razón Social"
            Me.Size = New System.Drawing.Size(575, 506)
        End If
        If tipo_busqueda = 3 Then ''CFDI TRASLADOS
            lblTitulo.Text = "Emisores"
            Text = "Emisores Traslados CFDI"
            Me.Size = New System.Drawing.Size(575, 506)
        End If
        If tipo_busqueda = 60 Then
            lblTitulo.Text = "Estatus"
            Me.Size = New System.Drawing.Size(100, 100)
        End If
        If tipo_busqueda = 59 Then
            lblTitulo.Text = "Clientes"
            Me.Size = New System.Drawing.Size(100, 100)
        End If
        If tipo_busqueda = 58 Then
            lblTitulo.Text = "Emisor"
            Me.Size = New System.Drawing.Size(100, 100)
        End If
        If tipo_busqueda = 7 Then
            lblTitulo.Text = "Cuenta Razón Social"
            Me.Size = New System.Drawing.Size(100, 100)
        End If
        Me.Top = (Me.Owner.Height - Me.Height) / 2
        Me.Left = (Me.Owner.Width - Me.Width) / 2
    End Sub
    Public Sub poblarGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim objBU As New ProyeccionCobranzaBU
        Dim listadoTabla As New DataTable

        grid.DataSource = Nothing
        If tipo_busqueda = 1 Then
            listadoTabla = objBU.obtenerClientes(tipo_busqueda) '' CLIENTES
        End If
        If tipo_busqueda = 2 Then
            listadoTabla = objBU.obtenerRazonesSocialesEstadosDeCuenta() ''RAZON SOCIAL
        End If
        If tipo_busqueda = 3 Then ''EMISORES CFDI TRASLADOS
            listadoTabla = objBU.obtenerEmisoresTrasladosCFDI
        End If
        If tipo_busqueda = 60 Then
            listadoTabla = objBU.obtenerListadoEstatusNotaCredito
        End If
        If tipo_busqueda = 59 Then
            listadoTabla = objBU.obtenerListadoClientesNotaCredito()
        End If
        If tipo_busqueda = 58 Then
            listadoTabla = objBU.obtenerListadoRazonesSociales
        End If
        If tipo_busqueda = 7 Then '' LISTADO DE RAZON SOCIAL PARA DEPOSITOS NO IDENTIFICADOS
            listadoTabla = objBU.obtenerCuentasRazonesSociales
        End If
        grid.DataSource = listadoTabla
        gridDiseno(grid)
    End Sub

    Public Sub gridDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        If tipo_busqueda = 60 Then
            grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
            grid.DisplayLayout.Bands(0).Columns(0).Width = 5
        Else
            If tipo_busqueda = 59 Then
                grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
                grid.DisplayLayout.Bands(0).Columns(1).Hidden = False
                grid.DisplayLayout.Bands(0).Columns(0).Width = 5
            Else
                If tipo_busqueda = 7 Then
                    grid.DisplayLayout.Bands(0).Columns(0).Hidden = False
                    grid.DisplayLayout.Bands(0).Columns(1).Hidden = True
                Else
                    grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
                End If

            End If

        End If

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 20
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

    Private Sub gridListadoParametros_AfterRowActivate(sender As Object, e As EventArgs) Handles gridListadoParametros.AfterRowActivate
        gridListadoParametros.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        For Each row In gridListadoParametros.Rows
            row.Activation = Activation.NoEdit
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
        Dim marcados As Integer
        For Each row As UltraGridRow In gridListadoParametros.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

End Class