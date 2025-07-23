Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Windows.Forms
Imports System.Drawing
Imports Contabilidad.Negocios
Imports Tools

Public Class ListaPermisosUsuarioEmpresaForm



    Private Sub ListaPermisosUsuarioEmpresaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        poblar_gridListaUsuarios(gridListaUsuarios)
        Me.Location = New Point(0, 0)
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs)
        poblar_gridListaUsuarios(gridListaUsuarios)
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs)

    End Sub

    Public Sub poblar_gridListaUsuarios(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim objBU As New PermisosUsuarioEmpresaBU
        Dim lista_usuarios_contabilidad As DataTable

        lista_usuarios_contabilidad = objBU.Consulta_lista_Usuario_Contabilidad()

        grid.DataSource = lista_usuarios_contabilidad

        gridListaUsuariosDiseno(grid)


    End Sub

    Private Sub gridListaUsuariosDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        With grid.DisplayLayout
            .Bands(0).Columns(0).Hidden = True
            .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectors = DefaultableBoolean.True
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.FilterUIType = FilterUIType.FilterRow
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If

    End Sub

    Private Sub asignar_grid_gridListaUsuarios(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        gridListaUsuarios = grid

    End Sub

    Private Sub gridListaUsuarios_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridListaUsuarios.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNothing(gridListaUsuarios.ActiveRow) Then Return

            Dim NextRowIndex As Integer = gridListaUsuarios.ActiveRow.Index + 1
            Try

                If NextRowIndex <= gridListaUsuarios.Rows.Count Then
                    gridListaUsuarios.DisplayLayout.Rows(NextRowIndex).Activated = True
                    gridListaUsuarios.DisplayLayout.Rows(NextRowIndex).Selected = True
                Else
                    gridListaUsuarios.DisplayLayout.Rows(0).Activated = True
                    gridListaUsuarios.DisplayLayout.Rows(0).Selected = True
                End If

            Catch ex As Exception
                gridListaUsuarios.ActiveRow.Activated = False
            End Try


        End If

        If e.KeyChar = ChrW(Keys.Escape) Then
            poblar_gridListaUsuarios(gridListaUsuarios)
            gridListaUsuarios.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        End If

    End Sub

    Private Sub gridListaUsuarios_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gridListaUsuarios.MouseDoubleClick

        If gridListaUsuarios.ActiveRow Is Nothing Then Return

        Dim row As UltraGridRow = gridListaUsuarios.ActiveRow

        If row Is Nothing Then Return

        Dim ftc As New Vinculacion_UsuarioEmpresaForm
        ftc.MdiParent = Me.MdiParent
        ftc.userID = CInt(row.Cells(0).Value)
        ftc.userName = CStr(row.Cells(1).Value)

        'Me.Close()
        ftc.Show()

    End Sub

    Private Sub gridListaUsuarios_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)

        If selection = 1 Then

            For Each row In gridListaUsuarios.Selected.Rows
                Dim i As Integer = gridListaUsuarios.Rows.Count

                gridListaUsuarios.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
                gridListaUsuarios.DisplayLayout.Override.CellClickAction = CellClickAction.Edit

            Next

        End If

    End Sub

    Private Sub gridListaUsuarios_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridListaUsuarios.BeforeExitEditMode
        Try
            Dim cellIndex As Integer = gridListaUsuarios.ActiveCell.Column.Index

            If gridListaUsuarios.ActiveRow.DataChanged Then

            Else
                If gridListaUsuarios.ActiveCell.DataChanged Then
                Else
                    If String.IsNullOrWhiteSpace(gridListaUsuarios.ActiveCell.Value) Then
                        poblar_gridListaUsuarios(gridListaUsuarios)
                        gridListaUsuarios.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                    End If
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gridListaUsuarios_AfterRowActivate(sender As Object, e As EventArgs) Handles gridListaUsuarios.AfterRowActivate
        gridListaUsuarios.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        For Each row In gridListaUsuarios.Rows
            row.Activation = Activation.NoEdit
        Next
    End Sub

    Private Sub gridListaUsuarios_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridListaUsuarios.BeforeRowDeactivate

        gridListaUsuarios.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub


End Class