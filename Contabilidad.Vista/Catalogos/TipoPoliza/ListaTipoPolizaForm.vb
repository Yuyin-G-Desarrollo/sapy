Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Windows.Forms
Imports System.Drawing
Imports Contabilidad.Negocios
Imports Tools

Public Class ListaTipoPolizaForm

    Private Sub ListaTipoPolizaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        poblar_gridListaTipoPoliza()
        Me.Location = New Point(0, 0)
    End Sub

    'TIPO POLIZAS
    Public Sub poblar_gridListaTipoPoliza()

        Dim objBU As New TipoPolizasBU
        gridListaTipoPoliza.DataSource = Nothing
        gridListaTipoPoliza.DataSource = objBU.Consulta_lista_Tipo_Poliza
        gridListaTipoPolizaDiseno(gridListaTipoPoliza)

    End Sub

    Private Sub gridListaTipoPolizaDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

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

    Private Sub gridListaTipoPoliza_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridListaTipoPoliza.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim NextRowIndex As Integer = gridListaTipoPoliza.ActiveRow.Index + 1
            Try
                gridListaTipoPoliza.DisplayLayout.Rows(NextRowIndex).Activated = True
                gridListaTipoPoliza.DisplayLayout.Rows(NextRowIndex).Selected = True
            Catch ex As Exception
                gridListaTipoPoliza.ActiveRow.Activated = False
            End Try
        End If

        If e.KeyChar = ChrW(Keys.Escape) Then
            poblar_gridListaTipoPoliza()
            gridListaTipoPoliza.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        End If

    End Sub

    'Private Sub gridListaTipoPoliza_MouseClick(sender As Object, e As MouseEventArgs) Handles gridListaTipoPoliza.MouseClick

    '    Dim mainElement As UIElement
    '    Dim element As UIElement
    '    Dim screenPoint As Point
    '    Dim clientPoint As Point
    '    Dim row As UltraGridRow
    '    Dim cell As UltraGridCell

    '    mainElement = Me.gridListaTipoPoliza.DisplayLayout.UIElement
    '    screenPoint = Control.MousePosition
    '    clientPoint = Me.gridListaTipoPoliza.PointToClient(screenPoint)
    '    element = mainElement.ElementFromPoint(clientPoint)

    '    If element Is Nothing Then Return

    '    row = element.GetContext(GetType(UltraGridRow))

    '    If Not row Is Nothing Then
    '        cell = element.GetContext(GetType(UltraGridCell))

    '        If Not cell Is Nothing Then

    '            'If e.Button <> Windows.Forms.MouseButtons.Right Then Return
    '            'Dim cms = New ContextMenuStrip
    '            'Dim item1 = cms.Items.Add("Nuevo")
    '            'item1.Tag = 1
    '            'AddHandler item1.Click, AddressOf gridListaTipoPoliza_menuChoice

    '            'Dim item2 = cms.Items.Add("Editar")
    '            'item2.Tag = 2
    '            'AddHandler item2.Click, AddressOf gridListaTipoPoliza_menuChoice
    '            'cms.Show(Control.MousePosition)

    '        End If
    '    End If

    'End Sub

    'Private Sub gridListaTipoPoliza_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim item = CType(sender, ToolStripMenuItem)
    '    Dim selection = CInt(item.Tag)

    '    If selection = 1 Then ''AGREGAR NUEVO HORARIO

    '        Dim grid As DataTable = gridListaTipoPoliza.DataSource
    '        Dim row As UltraGridRow = gridListaTipoPoliza.ActiveRow

    '        If Not IsNothing(row) Then

    '            grid.Rows.Add(0, "", False)

    '            gridListaTipoPoliza.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True
    '            Try
    '                gridListaTipoPoliza.ActiveRow.Activation = Activation.AllowEdit
    '                gridListaTipoPoliza.ActiveCell = gridListaTipoPoliza.ActiveRow.Cells(1)
    '                gridListaTipoPoliza.ActiveCell.Activation = Activation.AllowEdit
    '            Catch ex As Exception

    '            End Try

    '            gridListaTipoPoliza.PerformAction(UltraGridAction.ToggleCellSel, False, False)
    '            gridListaTipoPoliza.PerformAction(UltraGridAction.EnterEditMode, False, False)

    '        End If

    '    End If

    '    If selection = 2 Then ''EDITAR

    '        For Each row In gridListaTipoPoliza.Selected.Rows
    '            Dim i As Integer = gridListaTipoPoliza.Rows.Count

    '            gridListaTipoPoliza.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
    '            gridListaTipoPoliza.DisplayLayout.Override.CellClickAction = CellClickAction.Edit

    '        Next

    '    End If

    'End Sub

    'Private Sub gridListaTipoPoliza_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridListaTipoPoliza.BeforeExitEditMode
    '    Dim cellIndex As Integer = gridListaTipoPoliza.ActiveCell.Column.Index

    '    If Not gridListaTipoPoliza.ActiveRow.DataChanged Then
    '        If gridListaTipoPoliza.ActiveCell.DataChanged Then
    '        Else
    '            If String.IsNullOrWhiteSpace(gridListaTipoPoliza.ActiveCell.Value) Then
    '                poblar_gridListaTipoPoliza()
    '                gridListaTipoPoliza.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '            End If
    '        End If
    '    End If

    'End Sub

    'Private Sub gridListaTipoPoliza_AfterRowActivate(sender As Object, e As EventArgs) Handles gridListaTipoPoliza.AfterRowActivate
    '    gridListaTipoPoliza.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '    For Each row In gridListaTipoPoliza.Rows
    '        row.Activation = Activation.NoEdit
    '    Next
    'End Sub

    'Private Sub gridListaTipoPoliza_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridListaTipoPoliza.BeforeRowDeactivate

    '    If gridListaTipoPoliza.ActiveRow.DataChanged Then
    '        Dim tipoPoliza As New Entidades.TipoPoliza
    '        Dim objBU As New Negocios.TipoPolizasBU
    '        Dim row As UltraGridRow = gridListaTipoPoliza.ActiveRow

    '        tipoPoliza.polizatipoid = gridListaTipoPoliza.ActiveRow.Cells(0).Value
    '        tipoPoliza.nombre = CStr(gridListaTipoPoliza.ActiveRow.Cells(1).Value)
    '        tipoPoliza.status = CBool(gridListaTipoPoliza.ActiveRow.Cells(2).Value)

    '        objBU.alta_edicion_tipo_poliza(tipoPoliza)

    '        poblar_gridListaTipoPoliza()

    '    End If

    '    gridListaTipoPoliza.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

    'End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs)
        poblar_gridListaTipoPoliza()
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click

        Dim form As New AltaTipoPolizaForm

        form.ShowDialog()
        'rbtnEstatusActivo.Checked = True
        'If form.naveid > 0 Then
        '    cboxNave.SelectedValue = form.naveid
        '    listado_almacen()
        '    cboxAlmacen.Text = form.almacenid
        poblar_gridListaTipoPoliza()
        'End If

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
      
        If IsNothing(gridListaTipoPoliza.ActiveRow) Then
            show_message("Aviso", "Debe seleccionar un tipo de póliza")
            Return
        End If

        Dim form As New EditarTipoPolizaForm
        form.tipo_polizaID = CInt(gridListaTipoPoliza.ActiveRow.Cells(0).Text)
        form.descripcion = CStr(gridListaTipoPoliza.ActiveRow.Cells(1).Text)

        If (gridListaTipoPoliza.ActiveRow.Cells(2).Value.Equals("SI")) Then
            form.status = True
        Else
            form.status = False
        End If

        form.ShowDialog()
        'rbtnEstatusActivo.Checked = True
        'If form.naveid > 0 Then
        '    cboxNave.SelectedValue = form.naveid
        '    listado_almacen()
        '    cboxAlmacen.Text = form.almacenid
        '    btnMostrar.PerformClick()
        'End If
        poblar_gridListaTipoPoliza()

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

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        gridListaTipoPoliza.DataSource = Nothing
    End Sub
End Class