Imports System.Globalization
Imports DevExpress.Utils
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class DevolucionCliente_AdministradorDC_Parametros_Form

    Public filtro As String
    Public listaParametroID As List(Of String)
    Public listParametros As New DataTable
    Public pantallaOrigen As Integer = 0
    Public perfilUsuario As String = ""

    Private Sub DevolucionCliente_AdministradorDC_Parametros_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        poblar_gridListadoParametros()
        Dim marcados As Integer = 0
        For Each item In listaParametroID
            For index As Integer = 0 To bgvParametros.DataRowCount - 1 Step 1
                If item = bgvParametros.GetRowCellValue(bgvParametros.GetVisibleRowHandle(index), "Parámetro").ToString Then
                    bgvParametros.SelectRow(index)
                    marcados += 1
                End If
            Next
        Next

        If filtro = "CLIENTES" Then
            lblTitulo.Text = "Clientes"
            Me.Size = New System.Drawing.Size(650, 506)
            Me.MaximumSize = New System.Drawing.Size(650, 506)
            Me.MinimumSize = New System.Drawing.Size(650, 506)
        ElseIf filtro = "COLECCIONES" Then
            lblTitulo.Text = "Colecciones"
            Me.Size = New System.Drawing.Size(660, 506)
            Me.MaximumSize = New System.Drawing.Size(660, 506)
            Me.MinimumSize = New System.Drawing.Size(660, 506)
        ElseIf filtro = "MODELOS" Then
            lblTitulo.Text = "Modelos"
            Me.Size = New System.Drawing.Size(680, 506)
            Me.MaximumSize = New System.Drawing.Size(680, 506)
            Me.MinimumSize = New System.Drawing.Size(680, 506)
        ElseIf filtro = "AGENTE_DE_VENTAS" Then
            lblTitulo.Text = "Agente de ventas"
            Me.Size = New System.Drawing.Size(575, 506)
            Me.MaximumSize = New System.Drawing.Size(575, 506)
            Me.MinimumSize = New System.Drawing.Size(575, 506)
        ElseIf filtro = "ATENCIÓN_A_CLIENTES" Then
            lblTitulo.Text = "Atención a Clientes"
            Me.Size = New System.Drawing.Size(575, 506)
            Me.MaximumSize = New System.Drawing.Size(575, 506)
            Me.MinimumSize = New System.Drawing.Size(575, 506)
        ElseIf filtro = "MARCAS" Then
            lblTitulo.Text = "Marca"
            Me.Size = New System.Drawing.Size(500, 506)
            Me.MaximumSize = New System.Drawing.Size(500, 506)
            Me.MinimumSize = New System.Drawing.Size(500, 506)
        ElseIf filtro = "PIEL" Then
            lblTitulo.Text = "Piel"
            Me.Size = New System.Drawing.Size(575, 506)
            Me.MaximumSize = New System.Drawing.Size(575, 506)
            Me.MinimumSize = New System.Drawing.Size(575, 506)
        ElseIf filtro = "COLOR" Then
            lblTitulo.Text = "Color"
            Me.Size = New System.Drawing.Size(475, 506)
            Me.MaximumSize = New System.Drawing.Size(475, 506)
            Me.MinimumSize = New System.Drawing.Size(475, 506)
        ElseIf filtro = "CORRIDA" Then
            lblTitulo.Text = "Corrida"
            Me.Size = New System.Drawing.Size(475, 506)
            Me.MaximumSize = New System.Drawing.Size(475, 506)
            Me.MinimumSize = New System.Drawing.Size(475, 506)
        ElseIf filtro = "ESTATUS" Then
            lblTitulo.Text = "Estatus"
            Me.Size = New System.Drawing.Size(475, 506)
            Me.MaximumSize = New System.Drawing.Size(475, 506)
            Me.MinimumSize = New System.Drawing.Size(475, 506)
        ElseIf filtro = "DEFECTO" Then
            lblTitulo.Text = "Defecto / Motivo"
            Me.Size = New System.Drawing.Size(600, 506)
            Me.MaximumSize = New System.Drawing.Size(600, 506)
            Me.MinimumSize = New System.Drawing.Size(600, 506)
            bgvParametros.Columns.ColumnByFieldName(" ").Visible = False
            bgvParametros.Columns.ColumnByFieldName("Activo").Visible = False
        End If

        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)

        Me.Text = lblTitulo.Text

        Me.Top = (Me.Owner.Height - Me.Height) / 2
        Me.Left = (Me.Owner.Width - Me.Width) / 2
    End Sub

    Public Sub DiseñoGrid()
        Try
            bgvParametros.OptionsView.ColumnAutoWidth = True

            bgvParametros.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
            AddHandler bgvParametros.SelectionChanged, AddressOf gridPrincipal_SelectionChanged
            bgvParametros.OptionsSelection.MultiSelect = True
            bgvParametros.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DefaultBoolean.False
            bgvParametros.OptionsSelection.CheckBoxSelectorColumnWidth = 25
            bgvParametros.OptionsSelection.EnableAppearanceFocusedRow = False
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvParametros.Columns
                If col.FieldName <> " " Then
                    col.OptionsColumn.AllowEdit = False
                    col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
                    If col.ColumnType.ToString.Equals("Int32") Or col.ColumnType.ToString.Equals("Int16") Or col.ColumnType.ToString.Equals("Integer") Then
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        col.DisplayFormat.FormatString = "N0"
                    ElseIf col.ColumnType.ToString.Equals("Decimal") Then
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        col.DisplayFormat.FormatString = "N2"
                    End If
                End If
            Next

            bgvParametros.Columns.ColumnByFieldName("Parámetro").Visible = False

            bgvParametros.IndicatorWidth = 40
            bgvParametros.BestFitColumns()
        Catch ex As Exception
            Tools.Controles.Mensajes_Y_Alertas("ERROR", "Error " + ex.Message)
        End Try
    End Sub

    Public Sub poblar_gridListadoParametros()
        Dim objBU As New Negocios.DevolucionClientesBU
        Dim Tabla_ListadoParametros As New DataTable

        If filtro = "DEFECTO" Then
            Tabla_ListadoParametros = objBU.ConsultaMotivos_Calidad()
        Else
            Tabla_ListadoParametros = objBU.ConsultaDatosFiltros(filtro, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, perfilUsuario)
        End If

        grdParametros.DataSource = Nothing
        grdParametros.DataSource = Tabla_ListadoParametros

        DiseñoGrid()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If bgvParametros.DataRowCount = 0 Then Return

        Dim grid As DataTable = grdParametros.DataSource
        listParametros = grid.Clone

        If bgvParametros.DataRowCount > 0 Then
            'valida que se hayan seleccionado registros de la tabla principal
            If bgvParametros.SelectedRowsCount > 0 Then
                For I = 0 To bgvParametros.SelectedRowsCount() - 1
                    If (bgvParametros.GetSelectedRows()(I) >= 0) Then
                        Dim fila As DataRow = listParametros.NewRow
                        Dim Row As DataRow = CType(bgvParametros.GetDataRow(bgvParametros.GetSelectedRows()(I)), DataRow)
                        Dim contador As Integer = 0
                        For Each col As DataColumn In listParametros.Columns
                            fila(col.Caption) = Row(col.Caption)
                        Next
                        listParametros.Rows.Add(fila)
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub chboxMarcarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxMarcarTodo.CheckedChanged
        If chboxMarcarTodo.Checked Then
            bgvParametros.SelectAll()
        Else
            bgvParametros.ClearSelection()
        End If

        gridPrincipal_SelectionChanged(Nothing, Nothing)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub gridPrincipal_SelectionChanged(ByVal sender As Object, ByVal e As DevExpress.Data.SelectionChangedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim contador As Integer = 0
        For I = 0 To bgvParametros.SelectedRowsCount() - 1
            If (bgvParametros.GetSelectedRows()(I) >= 0) Then
                contador += 1
            End If
        Next

        If contador = 0 Then
            btnAceptar.Enabled = False
        Else
            btnAceptar.Enabled = True
        End If

        lblNumFiltrados.Text = contador.ToString("N0", CultureInfo.InvariantCulture)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub bgvParametros_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles bgvParametros.RowStyle
        If e.RowHandle Mod 2 <> 0 Then
            e.Appearance.BackColor = Color.LightSteelBlue
        End If
    End Sub

    Private Sub bgvParametros_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles bgvParametros.RowCellStyle
        Try
            If bgvParametros.IsRowSelected(e.RowHandle) Then
                If e.RowHandle Mod 2 <> 0 Then
                    e.Appearance.BackColor = Color.LightSteelBlue
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bgvParametros_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvParametros.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
End Class