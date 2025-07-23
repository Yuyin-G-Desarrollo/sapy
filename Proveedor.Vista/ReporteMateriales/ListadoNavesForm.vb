Imports System.Drawing
Imports System.Globalization
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Proveedores.BU

Public Class ListadoNavesForm
    Public tipo_Nave As Integer = 0
    Public activo As Integer '0 = Inactivo, 1 = Activo, 2 Ambos
    Public listaParametroID As List(Of String)
    Public listaParametros As New DataTable
    Public listaNavesDesarrollo As Integer = 0

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Private Sub ListadoNavesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If listaNavesDesarrollo = 0 Then
            Me.Text = "Naves"
            lblTitulo.Text = "Naves"
        ElseIf listaNavesDesarrollo = 1 Then
            Me.Text = "Naves Desarrollo"
            lblTitulo.Text = "Naves Desarrollo"
        End If

        poblar_gridListaNaves(gridListadoNaves)

        For Each item In listaParametroID
            For Each row As UltraGridRow In gridListadoNaves.Rows
                If item = row.Cells(0).Text Then
                    row.Cells(" ").Value = True
                End If
            Next
        Next

        Me.Top = (Me.Owner.Height - Me.Height) / 2
        Me.Left = (Me.Owner.Width - Me.Width) / 2
    End Sub

    Private Sub poblar_gridListaNaves(grid As UltraGrid)
        grid.DataSource = Nothing
        Dim tipoconsulta As Integer = 0

        Dim objBU As New ReporteMaterialesBU
        Dim Tabla_listadoParametros As New DataTable
        If listaNavesDesarrollo = 1 Then
            Tabla_listadoParametros = objBU.listadoNavesDesarrollo()
        Else

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Rep_Hormas", "READ_FVO") Then
                tipoconsulta = 1
                Tabla_listadoParametros = objBU.ListadoNaves(tipo_Nave, activo, tipoconsulta)
            Else
                Tabla_listadoParametros = objBU.ListadoNaves(tipo_Nave, activo, tipoconsulta)
            End If

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

    Private Sub gridListadoNaves_Click(sender As Object, e As EventArgs) Handles gridListadoNaves.Click
        If Not Me.gridListadoNaves.ActiveRow.IsActiveRow Then Return

        If IsNothing(gridListadoNaves.ActiveRow) Then Return

        If gridListadoNaves.ActiveRow.Cells(" ").Value Then
            gridListadoNaves.ActiveRow.Cells(" ").Value = False
        Else
            gridListadoNaves.ActiveRow.Cells(" ").Value = True
        End If

        Dim marcados As Integer
        For Each row As UltraGridRow In gridListadoNaves.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Private Sub chboxMarcarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxMarcarTodo.CheckedChanged
        If chboxMarcarTodo.Checked Then
            For Each row In gridListadoNaves.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = True
            Next
        Else
            For Each row In gridListadoNaves.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = False
            Next
        End If

        Dim marcados As Integer
        For Each row As UltraGridRow In gridListadoNaves.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If gridListadoNaves.Rows.Count = 0 Then Return

        Dim grid As DataTable = gridListadoNaves.DataSource
        listaParametros = grid.Clone
        For Each row As UltraGridRow In gridListadoNaves.Rows
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