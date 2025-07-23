Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Globalization

Public Class ListadoParametroForm

    Public tipo_busqueda As Integer
    Public tipo_busueda_str As String
    Public id_parametros As String
    Public listaParametroID As List(Of String)
    Public listParametros As New DataTable()
    Public cedisId As Integer
    Private _Usuario As String = "JRCAMPOS"
    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property


    Private Sub ListadoParametroUbicacionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString.Trim()

        poblar_gridListadoParametros(gridListadoParametros)

        For Each item In listaParametroID
            For Each row As UltraGridRow In gridListadoParametros.Rows
                If item = row.Cells(1).Text Then
                    row.Cells(" ").Value = True
                End If
            Next
        Next

        Select Case tipo_busueda_str
            Case "NAVES"
                lblTitulo.Text = "Naves"
                Me.Size = New System.Drawing.Size(375, 506)
            Case "CLIENTES"
                lblTitulo.Text = "Clientes"
                Me.Size = New System.Drawing.Size(575, 506)
                With gridListadoParametros
                    .DisplayLayout.Bands(0).Columns(1).Hidden = True
                    .DisplayLayout.Bands(0).Columns(2).Hidden = True
                End With
            Case "BAHIA"
                lblTitulo.Text = "Bahías"
                Me.Size = New System.Drawing.Size(575, 506)
                With gridListadoParametros
                    ' .DisplayLayout.Bands(0).Columns(1).Hidden = True
                End With
            Case "OPERADOR"
                lblTitulo.Text = "Operador"
                Me.Size = New System.Drawing.Size(575, 506)
                With gridListadoParametros
                    .DisplayLayout.Bands(0).Columns(1).Hidden = True
                End With
            Case "CORRIDAS"
                lblTitulo.Text = "Corridas"
                Me.Size = New System.Drawing.Size(375, 506)
            Case "TALLAS"
                lblTitulo.Text = "Tallas"
                Me.Size = New System.Drawing.Size(375, 506)
            Case "ARTICULOS"
                lblTitulo.Text = "Artículos"
                Me.Size = New System.Drawing.Size(850, 506)
                With gridListadoParametros
                    .DisplayLayout.Bands(0).Columns(1).Hidden = True
                End With
            Case "NAVES_TODAS"
                lblTitulo.Text = "Naves"
                Me.Size = New System.Drawing.Size(375, 506)
            Case "MOVIMIENTOS"
                lblTitulo.Text = "Movimientos"
                Me.Size = New System.Drawing.Size(375, 506)
            Case "FAMILIAS"
                lblTitulo.Text = "Familia de Ventas"
                Me.Size = New System.Drawing.Size(520, 506)
        End Select


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

        Dim objBU As New Negocios.EnvioRecepcionMuestrasBU
        Dim Tabla_ListadoParametros As New DataTable

        Tabla_ListadoParametros = objBU.ConsultaTablaFiltros(tipo_busueda_str, cedisId, _Usuario)

        grid.DataSource = Tabla_ListadoParametros

        gridListadoParametrosDiseno(grid)

    End Sub

    Private Sub gridListadoParametrosDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        asignaFormato_Columna(grid)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        Select Case tipo_busueda_str
            Case "NAVES"
                grid.DisplayLayout.Bands(0).Columns("NaveID").Hidden = True
            Case "CORRIDAS"
                grid.DisplayLayout.Bands(0).Columns("talla_descripcion").Header.Caption = "Corrida"
            Case "TALLAS"
                grid.DisplayLayout.Bands(0).Columns("tade_talla").Header.Caption = "Talla"
            Case "ARTICULOS"
                grid.DisplayLayout.Bands(0).Columns("MarcaSAY").Header.Caption = "Marca"
                grid.DisplayLayout.Bands(0).Columns("ColeccionSAY").Header.Caption = "Colección"
            Case "MOVIMIENTOS"
                grid.DisplayLayout.Bands(0).Columns("esta_estatusid").Header.Caption = "ID"
                grid.DisplayLayout.Bands(0).Columns("esta_estatusid").Width = 20
                grid.DisplayLayout.Bands(0).Columns("esta_nombre").Header.Caption = "Movimiento"
            Case "FAMILIAS"
                grid.DisplayLayout.Bands(0).Columns("fapr_familiaproyeccionid").Header.Caption = "ID"
                grid.DisplayLayout.Bands(0).Columns("fapr_familiaproyeccionid").Width = 20
                grid.DisplayLayout.Bands(0).Columns("fapr_descripcion").Header.Caption = "Familia"
        End Select

        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

    End Sub

    Private Sub gridListadoParametros_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles gridListadoParametros.AfterRowFilterChanged


        If gridListadoParametros.Rows.GetFilteredOutNonGroupByRows.Count > 0 Then
            Me.gridListadoParametros.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
            gridListadoParametros.DisplayLayout.Override.SelectTypeCol = SelectType.None
        Else
            Me.gridListadoParametros.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
            gridListadoParametros.DisplayLayout.Override.SelectTypeCol = SelectType.Default
        End If


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
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Private Sub gridListadoParametros_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridListadoParametros.BeforeExitEditMode
        Try
            Dim cellIndex As Integer = gridListadoParametros.ActiveCell.Column.Index

            If gridListadoParametros.ActiveRow.DataChanged Then

            Else
                If gridListadoParametros.ActiveCell.DataChanged Then
                Else
                    If String.IsNullOrWhiteSpace(gridListadoParametros.ActiveCell.Value) Then
                        'poblar_gridListadoParametros(String.Empty, gridListadoParametros)
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

    ''Asigna formato a columnas de ultragrid
    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

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
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)

    End Sub


End Class