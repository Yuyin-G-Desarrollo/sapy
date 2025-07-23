Imports System.Globalization
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ListadoParametrosReportesForm

    Public tipo_busqueda As Integer
    Public idUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

    Public ListaPrecios As Boolean
    Public ClienteID As Integer = 0
    Public ListaPrecioClienteID As Integer = 0
    Public MarcasAgenteID As String = String.Empty

    Public listaParametroID As List(Of String)
    Public listParametros As New DataTable


    Private Sub ListadoParametrosReportesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        poblar_gridListadoParametros(gridListadoParametros)

        For Each item In listaParametroID
            For Each row As UltraGridRow In gridListadoParametros.Rows
                If item = row.Cells(0).Text Then
                    row.Cells(" ").Value = True
                End If
            Next
        Next

        If ListaPrecios Then
            Select Case tipo_busqueda
                Case 1
                    lblTitulo.Text = "Familia de ventas"
                    Me.Size = New System.Drawing.Size(575, 506)
                Case 2
                    lblTitulo.Text = "Colecciones"
                    Me.Size = New System.Drawing.Size(860, 506)
                Case 3
                    lblTitulo.Text = "Artículos"
                    Me.Size = New System.Drawing.Size(860, 506)
            End Select
        Else
            Select Case tipo_busqueda
                Case 1
                    lblTitulo.Text = "Agentes de venta"
                    Me.Size = New System.Drawing.Size(575, 506)
                Case 2
                    lblTitulo.Text = "Clientes"
                    Me.Size = New System.Drawing.Size(630, 506)
                    pnlTipoFiltroCliente.Visible = True
                    rdbTodos.Checked = True
                Case 3
                    lblTitulo.Text = "Marcas"
                    Me.Size = New System.Drawing.Size(575, 506)
                Case 4
                    lblTitulo.Text = "Clientes"
                    Me.Size = New System.Drawing.Size(630, 506)
                    pnlTipoFiltroCliente.Visible = True
                    rdbTodos.Checked = True
                Case 5
                    lblTitulo.Text = "Colecciones"
                    Me.Size = New System.Drawing.Size(860, 506)
                Case 6
                    lblTitulo.Text = "Colecciones"
                    Me.Size = New System.Drawing.Size(860, 506)
                Case 11
                    lblTitulo.Text = "Estatus Artículos"
                    Me.Size = New System.Drawing.Size(575, 506)



            End Select
        End If




        Me.Top = (Me.Owner.Height - Me.Height) / 2
        Me.Left = (Me.Owner.Width - Me.Width) / 2
    End Sub

    Public Sub poblar_gridListadoParametros(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim objBU As New Negocios.EstadisticoPedidosBU
        Dim Tabla_ListadoParametros As New DataTable
        Try
            If ListaPrecios Then
                Dim objBULista As New Negocios.ListaPreciosVentaClienteBU
                Tabla_ListadoParametros = objBULista.ListadoParametrosReportes(tipo_busqueda, ClienteID, ListaPrecioClienteID, MarcasAgenteID)
            Else
                If tipo_busqueda <> 4 And tipo_busqueda <> 6 Then

                    Tabla_ListadoParametros = objBU.ListadoParametrosReportes(tipo_busqueda, idUsuario)

                Else
                    If tipo_busqueda = 6 Then
                        Tabla_ListadoParametros = objBU.ListadoParametrosReportesColeccionAgente(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)
                    Else
                        Tabla_ListadoParametros = objBU.ListadoParametrosReportesClienteAgente(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)
                    End If
                End If

            End If
            grid.DataSource = Tabla_ListadoParametros
            gridListadoParametrosDiseno(grid)
        Catch ex As Exception
            Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
        End Try
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
            If col.Header.Caption = "clie_activo" Then
                col.Hidden = True
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

    Private Sub gridListadoParametros_AfterRowActivate(sender As Object, e As EventArgs) Handles gridListadoParametros.AfterRowActivate
        gridListadoParametros.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        For Each row In gridListadoParametros.Rows
            row.Activation = Activation.NoEdit
        Next
    End Sub

    Private Sub chboxMarcarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxMarcarTodo.CheckedChanged
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
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Private Sub rdbActivos_CheckedChanged(sender As Object, e As EventArgs) Handles rdbActivos.CheckedChanged
        If rdbActivos.Checked Then
            SeleccionarTipoFiltro()
        End If
    End Sub

    Private Sub rdbInactivos_CheckedChanged(sender As Object, e As EventArgs) Handles rdbInactivos.CheckedChanged
        If rdbInactivos.Checked Then
            SeleccionarTipoFiltro()
        End If
    End Sub

    Private Sub rdbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rdbTodos.CheckedChanged
        If rdbTodos.Checked Then
            SeleccionarTipoFiltro()
        End If
    End Sub

    Private Sub SeleccionarTipoFiltro()
        Dim totalSeleccionados As Integer = 0

        For Each row As UltraGridRow In gridListadoParametros.Rows.Where(Function(x) x.Cells(" ").Value = True)
            row.Cells(" ").Value = False
        Next
        lblNumFiltrados.Text = "0"
        If rdbActivos.Checked Then
            For Each Fila As UltraGridRow In gridListadoParametros.Rows
                If Fila.Cells("clie_activo").Value = False Then
                    Fila.Hidden = True
                Else
                    Fila.Hidden = False
                End If
            Next
        ElseIf rdbActivos.Checked = False And rdbInactivos.Checked = True Then
            For Each Fila As UltraGridRow In gridListadoParametros.Rows
                If Fila.Cells("clie_activo").Value = True Then
                    Fila.Hidden = True
                Else
                    Fila.Hidden = False
                End If
            Next
        ElseIf rdbTodos.Checked = True And rdbActivos.Checked = False Then
            For Each Fila As UltraGridRow In gridListadoParametros.Rows
                Fila.Hidden = False
            Next
        End If
        chboxMarcarTodo.Checked = False

        For Each item In listaParametroID
            For Each row As UltraGridRow In gridListadoParametros.Rows
                If item = row.Cells(0).Text And row.Hidden = False Then
                    row.Cells(" ").Value = True
                    totalSeleccionados += 1
                End If
            Next
        Next

        lblNumFiltrados.Text = totalSeleccionados.ToString("N0")

    End Sub

End Class