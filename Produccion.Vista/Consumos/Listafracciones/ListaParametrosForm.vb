Imports System.Drawing
Imports System.Globalization
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Produccion.Negocios


Public Class ListaParametrosForm

    'Private Sub ListaParametrosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    'End Sub


    Public tipo_busqueda As Integer
    Public tipo_Nave As Integer = 0
    Public listaPatametroID As List(Of String)
    Public listaParametros As New DataTable
    Dim objAdvertencia As New Tools.AdvertenciaForm


    Private Sub ListaParametrosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If tipo_busqueda = 0 Then 'Naves
            Me.Text = "Naves"
            lblTitulo.Text = "Naves"
        ElseIf tipo_busqueda = 1 Then
            Me.Text = "Marcas" 'marcas
            lblTitulo.Text = "Marcas"
        ElseIf tipo_busqueda = 2 Then
            Me.Text = "Colecciones" 'colecciones
            lblTitulo.Text = "Colecciones"
        ElseIf tipo_busqueda = 4 Then 'Fracciones
            Me.Text = "Fracciones"
            lblTitulo.Text = "Fracciones"
        Else
            Me.Text = "Estatus" 'Estatus
            lblTitulo.Text = "Estatus"
        End If

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

        Dim objBU As New ProduccionBU
        Dim Tabla_listadoParametros As New DataTable
        If tipo_busqueda = 0 Then 'naves
            Tabla_listadoParametros = objBU.ListadoParametroNaves(tipo_Nave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        ElseIf tipo_busqueda = 1 Then
            Tabla_listadoParametros = objBU.ListadoParametroMarcas()
        ElseIf tipo_busqueda = 2 Then
            Tabla_listadoParametros = objBU.listadoParametroColecciones()
        ElseIf tipo_busqueda = 4 Then
            Tabla_listadoParametros = objBU.listaFraccionesIncremento()
        Else
            Tabla_listadoParametros = objBU.listadoParametroEstatus()
        End If

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