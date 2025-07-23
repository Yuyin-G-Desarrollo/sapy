Imports System.Globalization
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FiltrosReportesForm

#Region "Variables Globales"
    Public TIPO_BUSQUEDA As Integer
    Public LST_PARAMETROS As New DataTable
    Public LST_ID_FILTRO As List(Of String)
    Private ReadOnly LST_ESTATUS As New List(Of String) From {
        "PROGRAMADO / POR PROGRAMAR",
        "PROCESO",
        "TERMINADO",
        "RESERVADO",
        "DISPONIBLE",
        "PROYECTADO",
        "REPROCESO"
    }
    'Public ID_USUARIO As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
#End Region

    Private Sub ListadoParametrosReportesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Poblar_gridListadoParametros(gridListadoParametros)

        For Each item In LST_ID_FILTRO
            For Each row As UltraGridRow In gridListadoParametros.Rows
                If item = row.Cells(0).Text Then
                    row.Cells(" ").Value = True
                End If
            Next
        Next

        Select Case TIPO_BUSQUEDA
            Case 1
                lblTitulo.Text = "Estatus"
                Size = New Size(575, 506)

            Case 2
                lblTitulo.Text = "Clientes"
                Size = New Size(630, 506)
                pnlTipoFiltroCliente.Visible = True
                rdbTodos.Checked = True

            Case 3
                lblTitulo.Text = "Familias"
                Size = New Size(575, 506)

            Case 4
                lblTitulo.Text = "Pieles"
                Size = New Size(630, 506)
                rdbTodos.Checked = True

            Case 5
                lblTitulo.Text = "Colecciones"
                Size = New Size(860, 506)

            Case 6
                lblTitulo.Text = "Colores"
                Size = New Size(860, 506)

            Case 7
                lblTitulo.Text = "Corridas"
                Size = New Size(860, 506)

            Case 8
                lblTitulo.Text = "Marcas"
                Size = New Size(575, 506)

            Case 9
                lblTitulo.Text = "Temporadas"
                Size = New Size(575, 506)

            Case 10
                lblTitulo.Text = "Estatus Articulo"
                Size = New Size(575, 506)

            Case 11
                lblTitulo.Text = "Naves"
                Size = New Size(575, 506)

            Case 12
                lblTitulo.Text = "Traslados"
                Size = New Size(575, 506)

            Case 13
                lblTitulo.Text = "Emisor"
                Size = New Size(575, 506)

            Case 14
                lblTitulo.Text = "Modelo Say"
                Size = New Size(575, 506)

            Case 15
                lblTitulo.Text = "Corrida"
                Size = New Size(575, 506)

        End Select

        Top = (Owner.Height - Height) / 2
        Left = (Owner.Width - Width) / 2
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If gridListadoParametros.Rows.Count = 0 Then Return

        Dim grid As DataTable = gridListadoParametros.DataSource
        LST_PARAMETROS = grid.Clone
        For Each row As UltraGridRow In gridListadoParametros.Rows
            If row.Cells(" ").Value Then
                Dim fila As DataRow = LST_PARAMETROS.NewRow

                For index = 0 To row.Cells.Count - 1 Step 1
                    fila(index) = row.Cells(index).Value
                Next
                LST_PARAMETROS.Rows.Add(fila)
            End If
        Next
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub GridListadoParametros_Click(sender As Object, e As EventArgs) Handles gridListadoParametros.Click
        If Not gridListadoParametros.ActiveRow.IsDataRow Then Return
        If IsNothing(gridListadoParametros.ActiveRow) Then Return

        gridListadoParametros.ActiveRow.Cells(" ").Value = If(gridListadoParametros.ActiveRow.Cells(" ").Value, False, True)

        Dim marcados As Integer
        For Each row As UltraGridRow In gridListadoParametros.Rows
            If row.Cells(" ").Value Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Private Sub GridListadoParametros_AfterRowActivate(sender As Object, e As EventArgs) Handles gridListadoParametros.AfterRowActivate
        gridListadoParametros.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        For Each row In gridListadoParametros.Rows
            row.Activation = Activation.NoEdit
        Next
    End Sub

    Private Sub ChboxMarcarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxMarcarTodo.CheckedChanged
        If chboxMarcarTodo.Checked Then
            For Each row In gridListadoParametros.Rows.GetFilteredInNonGroupByRows
                If row.Hidden = False Then
                    row.Cells(" ").Value = True
                End If
            Next
        Else
            For Each row As UltraGridRow In gridListadoParametros.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = False
            Next
        End If
        Dim marcados As Integer
        For Each row As UltraGridRow In gridListadoParametros.Rows
            If row.Cells(" ").Value Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Public Sub RdbActivos_CheckedChanged(sender As Object, e As EventArgs) Handles rdbActivos.CheckedChanged
        If rdbActivos.Checked Then
            SeleccionarTipoFiltro()
        End If
    End Sub

    Private Sub RdbInactivos_CheckedChanged(sender As Object, e As EventArgs) Handles rdbInactivos.CheckedChanged
        If rdbInactivos.Checked Then
            SeleccionarTipoFiltro()
        End If
    End Sub

    Private Sub RdbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rdbTodos.CheckedChanged
        If rdbTodos.Checked Then
            SeleccionarTipoFiltro()
        End If
    End Sub

#Region "Metodos Privados"

    Private Sub SeleccionarTipoFiltro()
        Dim totalSeleccionados As Integer = 0

        For Each row As UltraGridRow In gridListadoParametros.Rows.Where(Function(x) x.Cells(" ").Value = True)
            row.Cells(" ").Value = False
        Next
        lblNumFiltrados.Text = "0"
        If rdbActivos.Checked Then
            For Each Fila As UltraGridRow In gridListadoParametros.Rows
                Fila.Hidden = Fila.Cells("clie_activo").Value = False
            Next
        ElseIf rdbActivos.Checked = False And rdbInactivos.Checked = True Then
            For Each Fila As UltraGridRow In gridListadoParametros.Rows
                Fila.Hidden = Fila.Cells("clie_activo").Value = True
            Next
        ElseIf rdbTodos.Checked = True And rdbActivos.Checked = False Then
            For Each Fila As UltraGridRow In gridListadoParametros.Rows
                Fila.Hidden = False
            Next
        End If
        chboxMarcarTodo.Checked = False

        For Each item In LST_ID_FILTRO
            For Each row As UltraGridRow In gridListadoParametros.Rows
                If item = row.Cells(0).Text And row.Hidden = False Then
                    row.Cells(" ").Value = True
                    totalSeleccionados += 1
                End If
            Next
        Next

        lblNumFiltrados.Text = totalSeleccionados.ToString("N0")

    End Sub

    Private Sub Poblar_gridListadoParametros(grid As UltraGrid)
        Dim objBU As New FiltrosReportesBU
        grid.DataSource = Nothing

        Try
            If Not TIPO_BUSQUEDA = 1 Then
                Dim Tabla_ListadoParametros As DataTable = objBU.ConsultarFiltros(TIPO_BUSQUEDA)
                grid.DataSource = Tabla_ListadoParametros
            Else
                Dim Tabla_ListadoParametros As New DataTable

                Tabla_ListadoParametros.Columns.Add(New DataColumn(" ", GetType(Boolean)))
                Tabla_ListadoParametros.Columns.Add("Estatus")

                For Each estatus In LST_ESTATUS
                    Dim fila As DataRow = Tabla_ListadoParametros.NewRow()
                    fila(0) = False
                    fila(1) = estatus

                    Tabla_ListadoParametros.Rows.Add(fila)
                Next

                grid.DataSource = Tabla_ListadoParametros
            End If

            GridListadoParametrosDiseno(grid)
        Catch ex As Exception
            Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
        End Try
    End Sub

    Private Sub GridListadoParametrosDiseno(grid As UltraGrid)
        AsignaFormato_Columna(grid)

        If Not TIPO_BUSQUEDA = 1 Then
            grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
        End If

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

    Private Sub AsignaFormato_Columna(grid As UltraGrid)
        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then
                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("String") Then
                If col.Header.Caption.Equals("TELÉFONO") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("EXTENSIÓN") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If
            End If
        Next
    End Sub

    Public Sub MarcarCasillaActivos()

        rdbActivos.Checked = True
        RdbActivos_CheckedChanged(Nothing, Nothing)
    End Sub

#End Region

End Class