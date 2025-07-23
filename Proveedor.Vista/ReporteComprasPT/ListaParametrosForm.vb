Imports System.Drawing
Imports System.Globalization
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Proveedores.BU

Public Class ListaParametrosForm
    Public tipo_busqueda As Integer
    Public tipo_Nave As Integer = 0
    Public listaPatametroID As List(Of String)
    Public listaParametros As New DataTable
    Dim objAdvertencia As New Tools.AdvertenciaForm


    Private Sub ListaParametrosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If tipo_busqueda = 0 Then 'Naves
        '    Me.Text = "Naves"
        '    lblTitulo.Text = "Naves"
        'Else
        '    Me.Text = "Marcas" 'marcas
        '    lblTitulo.Text = "Marcas"
        'End If

        Select Case tipo_busqueda
            Case 0
                Me.Text = "Naves"
                lblTitulo.Text = "Naves"
            Case 1
                Me.Text = "Marcas"
                lblTitulo.Text = "Marcas"
            Case 2
                Me.Text = "Status"
                lblTitulo.Text = "Status"
            Case 4
                Me.Text = "Emisor"
                lblTitulo.Text = "Emisor"
            Case 3
                Me.Text = "Receptor"
                lblTitulo.Text = "Receptor"
            Case 5
                Me.Text = "Artículo"
                lblTitulo.Text = "Artículo"
                Me.Size = New System.Drawing.Size(720, 506)
            Case 6
                Me.Text = "Status"
                lblTitulo.Text = "Status"
        End Select

        poblar_gridListaParametros(gridListadoParametros)

        For Each item In listaPatametroID
            For Each row As UltraGridRow In gridListadoParametros.Rows
                If item = row.Cells(0).Text Then
                    row.Cells(" ").Value = True
                End If
            Next
        Next

        Me.Top = (Me.Owner.Height - Me.Height) / 2
        Me.Left = (Me.Owner.Width - Me.Width) / 2

    End Sub

    Private Sub poblar_gridListaParametros(grid As UltraGrid)
        grid.DataSource = Nothing

        Dim objBU As New ConsultaComprasPT_BU
        Dim objAdmonBU As New AdmonDoctosComprasPT_BU
        Dim objDevBU As New DevolucionesPreliminares_BU
        Dim Tabla_listadoParametros As New DataTable

        'If tipo_busqueda = 0 Then 'naves
        '    Tabla_listadoParametros = objBU.ListadoParametroNaves(tipo_Nave)
        'Else
        '    Tabla_listadoParametros = objBU.ListadoParametroMarcas()
        'End If

        Select Case tipo_busqueda
            Case 0
                Tabla_listadoParametros = objBU.ListadoParametroNaves(tipo_Nave)
            Case 1
                Tabla_listadoParametros = objBU.ListadoParametroMarcas()
            Case 2
                Tabla_listadoParametros = objAdmonBU.ObtenerEstatusFacturacion()
            Case 3
                Tabla_listadoParametros = objAdmonBU.ObtenerEmisorFacturacion()
            Case 4
                Tabla_listadoParametros = objAdmonBU.ObtenerReceptorFacturacion()
            Case 5
                Tabla_listadoParametros = objBU.ListadoParametroArticulos()
            Case 6
                Tabla_listadoParametros = objDevBU.ObtenerEstatusDevolucion()
        End Select

        If Tabla_listadoParametros.Rows.Count > 0 Then
            grid.DataSource = Tabla_listadoParametros
            gridListadoParametrosDiseno(grid)
        Else
            objAdvertencia.mensaje = "No se encontró información"
            objAdvertencia.ShowDialog()
            Me.Close()
        End If

    End Sub

    Private Sub gridListadoParametrosDiseno(grid As UltraGrid)
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

    Private Sub gridListadoParametros_Click(sender As Object, e As EventArgs) Handles gridListadoParametros.Click
        If Not Me.gridListadoParametros.ActiveRow.IsActiveRow Then Return

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

    Private Sub chboxMarcarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxMarcarTodo.CheckedChanged
        If chboxMarcarTodo.Checked Then
            For Each row In gridListadoParametros.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = True
            Next
        Else
            For Each row In gridListadoParametros.Rows.GetFilteredInNonGroupByRows
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
End Class