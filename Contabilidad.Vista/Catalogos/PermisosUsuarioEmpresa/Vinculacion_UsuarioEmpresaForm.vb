Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Contabilidad.Negocios
Imports System.Drawing
Imports System.Windows.Forms

Public Class Vinculacion_UsuarioEmpresaForm

    Public userID As Integer
    Public userName As String

    Private Sub VinculacionTEC_RFC_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        poblar_grid_Usuario_Empresa(userID, grid_Usuario_Empresa)
        lblUsuario.Text = userName
    End Sub


#Region "ACCIONES GRIDS        "

    Public Sub poblar_grid_Usuario_Empresa(userID As Integer, grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim objBU As New PermisosUsuarioEmpresaBU
        Dim Tabla_Vinculacion As New DataTable

        Tabla_Vinculacion = objBU.lista_Permisos_Usuario_Empresa(userID)

        grid.DataSource = Tabla_Vinculacion

        grid_Usuario_EmpresaDiseno(grid)

    End Sub

    Private Sub grid_Usuario_EmpresaDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        'asignaFormato_Columna(grid)

        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        'asignaFormato_Columna(grid)

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No


    End Sub

    Private Sub asignar_grid_grid_Usuario_Empresa(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid_Usuario_Empresa = grid

    End Sub

    Private Sub grid_Usuario_Empresa_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles grid_Usuario_Empresa.DoubleClickHeader

        If Me.grid_Usuario_Empresa.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.grid_Usuario_Empresa.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.grid_Usuario_Empresa.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.grid_Usuario_Empresa.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.grid_Usuario_Empresa.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.grid_Usuario_Empresa.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.grid_Usuario_Empresa.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If

    End Sub

    Private Sub grid_Usuario_Empresa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grid_Usuario_Empresa.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNothing(grid_Usuario_Empresa.ActiveRow) Then Return

        End If

        If e.KeyChar = ChrW(Keys.Escape) Then
            'poblar_grid_Usuario_Empresa(String.Empty, grid_Usuario_Empresa)
            grid_Usuario_Empresa.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        End If

    End Sub

    Private Sub grid_Usuario_Empresa_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles grid_Usuario_Empresa.MouseDoubleClick

        If grid_Usuario_Empresa.ActiveRow Is Nothing Then Return

        Dim row As UltraGridRow = grid_Usuario_Empresa.ActiveRow

        If row Is Nothing Then Return

        Dim estatus As Boolean = CBool(row.Cells(2).Value)
        Dim objBU As New Negocios.PermisosUsuarioEmpresaBU

        If estatus Then
            ''AQUI BORRA 
            objBU.Permisos_Usuario_Empresa(2, userID, CInt(row.Cells(0).Value))
            row.Cells(2).Value = False
        Else
            ''AQUI INSERTA
            objBU.Permisos_Usuario_Empresa(1, userID, CInt(row.Cells(0).Value))
            row.Cells(2).Value = True
        End If

    End Sub

    Private Sub grid_Usuario_Empresa_MouseClick(sender As Object, e As MouseEventArgs) Handles grid_Usuario_Empresa.MouseClick

        'Dim mainElement As UIElement
        'Dim element As UIElement
        'Dim screenPoint As Point
        'Dim clientPoint As Point
        'Dim row As UltraGridRow
        'Dim cell As UltraGridCell

        '' Get the control's main element
        'mainElement = Me.grid_Usuario_Empresa.DisplayLayout.UIElement

        '' Convert the current mouse position to a point
        '' in client coordinates of the control.
        'screenPoint = Control.MousePosition
        'clientPoint = Me.grid_Usuario_Empresa.PointToClient(screenPoint)

        '' Get the element at that point
        'element = mainElement.ElementFromPoint(clientPoint)

        'If element Is Nothing Then Return

        'Debug.WriteLine("Clicked on an " + element.GetType().ToString())
        'Debug.Indent()

        '' Get the row that contains this element.
        'row = element.GetContext(GetType(UltraGridRow))

        'If Not row Is Nothing Then

        '    Debug.WriteLine("in row: " + row.Index.ToString())

        '    ' Get the cell that contains this element.
        '    cell = element.GetContext(GetType(UltraGridCell))

        '    If Not cell Is Nothing Then

        '        If e.Button <> Windows.Forms.MouseButtons.Right Then Return

        '        ''MessageBox.Show("CLICK CLICK    ")
        '        'Dim cms = New ContextMenuStrip
        '        'Dim item1 = cms.Items.Add("Nuevo contacto")
        '        'item1.Tag = 1
        '        'AddHandler item1.Click, AddressOf grid_Usuario_Empresa_menuChoice

        '        'Dim item2 = cms.Items.Add("Editar contacto")
        '        'item2.Tag = 2
        '        'AddHandler item2.Click, AddressOf grid_Usuario_Empresa_menuChoice

        '        'Dim item3 = cms.Items.Add("Nuevo email")
        '        'item3.Tag = 3
        '        'AddHandler item3.Click, AddressOf grid_Usuario_Empresa_menuChoice

        '        'Dim item4 = cms.Items.Add("Nuevo teléfono")
        '        'item4.Tag = 4
        '        'AddHandler item4.Click, AddressOf grid_Usuario_Empresa_menuChoice

        '        'If Not Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
        '        '    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
        '        '        cms.Show(Control.MousePosition)
        '        '    End If
        '        'End If

        '        Debug.WriteLine("in column: " + cell.Column.Key)
        '        Debug.WriteLine("cell text: " + cell.Text)
        '    End If
        'End If

        '' Walk up the parent element chain and write out a line 
        '' for each parent element.
        'While Not element.Parent Is Nothing
        '    element = element.Parent
        '    Debug.WriteLine("is a child of an " + element.GetType().ToString())
        '    Debug.Indent()
        'End While

        '' reset the indent level
        'Debug.IndentLevel = 0

    End Sub

    Private Sub grid_Usuario_Empresa_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        'Dim item = CType(sender, ToolStripMenuItem)
        'Dim selection = CInt(item.Tag)

        'If selection = 1 Then

        '    Dim grid As DataTable = grid_Usuario_Empresa.DataSource
        '    Dim row As UltraGridRow = grid_Usuario_Empresa.ActiveRow


        '    If Not IsNothing(row) Then


        '    End If

        'End If

    End Sub

    Private Sub grid_Usuario_Empresa_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles grid_Usuario_Empresa.BeforeExitEditMode
        Try
            Dim cellIndex As Integer = grid_Usuario_Empresa.ActiveCell.Column.Index

            If grid_Usuario_Empresa.ActiveRow.DataChanged Then

            Else
                If grid_Usuario_Empresa.ActiveCell.DataChanged Then
                Else
                    If String.IsNullOrWhiteSpace(grid_Usuario_Empresa.ActiveCell.Value) Then
                        'poblar_grid_Usuario_Empresa(String.Empty, grid_Usuario_Empresa)
                        grid_Usuario_Empresa.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                    End If
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub grid_Usuario_Empresa_AfterRowActivate(sender As Object, e As EventArgs) Handles grid_Usuario_Empresa.AfterRowActivate
        grid_Usuario_Empresa.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        For Each row In grid_Usuario_Empresa.Rows
            row.Activation = Activation.NoEdit
        Next
    End Sub

    Private Sub grid_Usuario_Empresa_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grid_Usuario_Empresa.BeforeRowDeactivate

        'If grid_Usuario_Empresa.ActiveRow.IsFilterRow Then Return

        'If grid_Usuario_Empresa.ActiveRow.DataChanged Then

        '    Dim row As UltraGridRow = grid_Usuario_Empresa.ActiveRow


        'End If

        'grid_Usuario_Empresa.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

    End Sub

#End Region


End Class