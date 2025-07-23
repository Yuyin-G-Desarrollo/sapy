Imports System.Globalization
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class ListadoParametroForm

    Public tipo_busqueda As String
    Public id_parametros As String
    Public listaParametroID As List(Of String)
    Public listParametros As New DataTable()
    Private UsuarioID As Integer

    Private _Usuario As String
    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property
    Private Sub ListadoParametroForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString.Trim()
        UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        poblar_gridListadoParametros(gridListadoParametros)

        For Each item In listaParametroID
            For Each row As UltraGridRow In gridListadoParametros.Rows
                If item = row.Cells(1).Text Then
                    row.Cells(" ").Value = True
                End If
            Next
        Next

        Select Case tipo_busqueda
            Case "NAVES"
                lblTitulo.Text = "Naves"
                Me.Text = "Naves"
                Me.Size = New System.Drawing.Size(375, 506)
            Case "CLIENTES"
                lblTitulo.Text = "Clientes"
                Me.Text = "Clientes"
                Me.Size = New System.Drawing.Size(375, 506)
            Case "TIENDAS"
                lblTitulo.Text = "Tiendas"
                Me.Text = "Tiendas"
                Me.Size = New System.Drawing.Size(720, 506)
            Case "ARTICULOS"
                lblTitulo.Text = "Artículos"
                Me.Text = "Artículos"
                Me.Size = New System.Drawing.Size(840, 506)
            Case "CARRIDAS"
                lblTitulo.Text = "Corridas"
                Me.Text = "Corridas"
                Me.Size = New System.Drawing.Size(340, 506)
            Case "TALLAS"
                lblTitulo.Text = "Tallas"
                Me.Text = "Tallas"
                Me.Size = New System.Drawing.Size(340, 506)
        End Select

        Me.Top = (Me.Owner.Height - Me.Height) / 2
        Me.Left = (Me.Owner.Width - Me.Width) / 2

    End Sub

    Public Sub poblar_gridListadoParametros(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim objBU As New Negocios.SalidaNavesProduccion_ConsultasFiltrosBU
        Dim dtParametros As New DataTable

        Try

            Select Case tipo_busqueda
                Case "NAVES"
                    dtParametros = objBU.ListaNaves(UsuarioID)
                Case "CLIENTES"
                    dtParametros = objBU.ListaClientes()
                Case "TIENDAS"
                    dtParametros = objBU.ListaTiendas
                Case "ARTICULOS"
                    dtParametros = objBU.ListaArticulos
                Case "CORRIDAS"
                    dtParametros = objBU.ListaCorridas
                Case "TALLAS"
                    dtParametros = objBU.ListaTallas
            End Select

            grid.DataSource = dtParametros
            gridListadoParametrosDiseno(grid)
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try



    End Sub

    Private Sub gridListadoParametrosDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        asignaFormato_Columna(grid)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        Select Case tipo_busqueda
            Case "NAVES"
                grid.DisplayLayout.Bands(0).Columns("NaveID").Hidden = True
            Case "CLIENTES"
                grid.DisplayLayout.Bands(0).Columns("IdSAY").Hidden = True
                grid.DisplayLayout.Bands(0).Columns("IdSICY").Hidden = True
            Case "TIENDAS"
                grid.DisplayLayout.Bands(0).Columns("IdSICY").Hidden = True
            Case "ARTICULOS"
                grid.DisplayLayout.Bands(0).Columns("ProductoEstiloId").Hidden = True
            Case "CORRIDAS"
                grid.DisplayLayout.Bands(0).Columns("talla_tallaid").Hidden = True
                grid.DisplayLayout.Bands(0).Columns("talla_sicy").Hidden = True
        End Select

        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

    End Sub

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

    Private Sub gridListadoParametros_AfterRowActivate(sender As Object, e As EventArgs) Handles gridListadoParametros.AfterRowActivate
        gridListadoParametros.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        For Each row In gridListadoParametros.Rows
            row.Activation = Activation.NoEdit
        Next
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

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New Tools.AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New Tools.AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New Tools.ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

End Class