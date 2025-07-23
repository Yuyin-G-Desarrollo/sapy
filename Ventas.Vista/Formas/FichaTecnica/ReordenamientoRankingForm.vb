Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class ReordenamientoRankingForm

    Dim tblClasificaciones As New DataTable
    Dim listClasificaciones As New List(Of String)
    Dim listClasificacionesIds As New List(Of String)

    Private Sub ReordenamientoRankingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        WindowState = FormWindowState.Maximized
        Dim objClientesBU As New Ventas.Negocios.ClientesBU
        tblClasificaciones = objClientesBU.ListaClasificacionCliente()

        ListaClasificacionCliente()
    End Sub

    Private Sub ListaClasificacionCliente()

        Try
            Controles.ComboClasificacionCliente(cboxClienteClasificacion)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        poblar_gridRanking(cboxClienteClasificacion.Text)
    End Sub

    Private Sub btnLimpiarSolicitudes_Click(sender As Object, e As EventArgs) Handles btnLimpiarSolicitudes.Click
        cboxClienteClasificacion.SelectedIndex = 0
        grdFiltroClasificacionCliente.DataSource = Nothing
        listClasificaciones.Clear()
        listClasificacionesIds.Clear()
        grdFiltroCliente.DataSource = Nothing
        gridRanking.DataSource = Nothing
    End Sub

    Private Sub btnGuardarRanking_Click(sender As Object, e As EventArgs) Handles btnGuardarRanking.Click

        Dim clientesBU As New Negocios.ClientesBU

        For Each row As UltraGridRow In gridRanking.Rows

            Dim cliente As New Entidades.Cliente
            cliente.clienteid = CInt(row.Cells(0).Value)
            cliente.idsicy = CInt(row.Cells(1).Value)
            cliente.ranking = CInt(row.Cells(5).Value)

            Me.Cursor = Cursors.WaitCursor

            Try
                clientesBU.editarCliente(cliente, Nothing, 5, True, True)
                clientesBU.editarCliente_Ranking_Sicy(cliente, 1)
            Catch ex As Exception
                show_message("Error", "Algo falló en la operación")
                Exit Sub
            End Try

        Next

        show_message("Exito", "Información guardada con éxito")
        poblar_gridRanking(cboxClienteClasificacion.Text)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    'Muestra el form de mensaje
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

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    'Asigna formato a columnas de ultragrid
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

    'ACCIONES DE GRID RANKING
    Public Sub poblar_gridRanking(clasificacion As String)

        gridRanking.DataSource = Nothing

        Dim objBU As New Negocios.ClientesBU
        Dim ranking As New DataTable
        Dim objClientesBU As New Ventas.Negocios.ClientesBU
        Dim tblClasificacion As New DataTable
        Dim vlClasificacion As New Infragistics.Win.ValueList
        Dim filtroClasificacion As String = String.Empty
        Dim filtroCliente As String = String.Empty


        For index = 0 To listClasificacionesIds.Count - 1
            If index = 0 Then
                filtroClasificacion += "" + Replace(listClasificacionesIds(index), ",", "")
            Else
                filtroClasificacion += "," + Replace(listClasificacionesIds(index), ",", "")
            End If
        Next


        For Each row As UltraGridRow In grdFiltroCliente.Rows
            If row.Index = 0 Then
                filtroCliente += " " + Replace(row.Cells(0).Text, ",", "")
            Else
                filtroCliente += ", " + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        ranking = objBU.Datos_TablaReordenamientoRanking(filtroClasificacion, filtroCliente)
        tblClasificacion = objClientesBU.ListaClasificacionCliente()

        For Each fila As DataRow In tblClasificacion.Rows
            vlClasificacion.ValueListItems.Add(fila.Item("clas_clasificacioclientenid"), fila.Item("clas_nombre"))
        Next

        gridRanking.DataSource = ranking
        gridRanking.DisplayLayout.Bands(0).Columns(3).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        gridRanking.DisplayLayout.Bands(0).Columns(3).ValueList = vlClasificacion
        gridRankingDiseno(gridRanking)

        lblRegistros.Text = gridRanking.Rows.Count
        lblUltimaActualizacion.Text = DateTime.Now.ToString

    End Sub

    Private Sub gridRankingDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.SelectTypeRow = SelectType.SingleAutoDrag
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.AllowDrop = True

    End Sub

    Private Sub gridRanking_AfterCellListCloseUp(sender As Object, e As CellEventArgs) Handles gridRanking.AfterCellListCloseUp

        Dim row As UltraGridRow = gridRanking.ActiveRow
        If IsNothing(row) Then Return

        Dim clientesBU As New Negocios.ClientesBU
        Dim cliente As New Entidades.Cliente

        If String.IsNullOrEmpty(row.Cells(3).Text) Then Return
        If row.Cells(3).Text = cboxClienteClasificacion.Text Then Return

        cliente.clienteid = CInt(row.Cells(0).Value)
        cliente.idsicy = CInt(row.Cells(1).Value)

        'cliente.clasificacioncliente = CStr(row.Cells(3).Value)
        Dim valueList As ValueList = e.Cell.ValueListResolved
        Dim selectedItem As ValueListItem = CType(valueList.SelectedItem, ValueListItem)
        cliente.clasificacioncliente = selectedItem.DataValue

        Me.Cursor = Cursors.WaitCursor

        Try
            clientesBU.editarCliente(cliente, Nothing, 6, True, True)
            clientesBU.editarCliente_Ranking_Sicy(cliente, 2)
        Catch ex As Exception
            show_message("Error", "Algo falló en la operación")
            Exit Sub
        End Try

        row.Delete(False)

        For Each fila As UltraGridRow In gridRanking.Rows
            fila.Cells(5).Value = fila.Index + 1
        Next

        cboxClienteClasificacion.Text = cliente.clasificacioncliente
        btnGuardarRanking.PerformClick()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub gridRanking_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridRanking.SelectionDrag

        gridRanking.DoDragDrop(gridRanking.Selected.Rows, DragDropEffects.Move)

    End Sub

    Private Sub gridRanking_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles gridRanking.DragOver
        e.Effect = DragDropEffects.Move
        Dim grid As UltraGrid = TryCast(sender, UltraGrid)
        Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

        If pointInGridCoords.Y < 20 Then
            Me.gridRanking.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
        ElseIf pointInGridCoords.Y > grid.Height - 20 Then
            Me.gridRanking.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
        End If
    End Sub

    Private Sub gridRanking_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles gridRanking.DragDrop
        Dim dropIndex As Integer
        Dim uieOver As UIElement = gridRanking.DisplayLayout.UIElement.ElementFromPoint(gridRanking.PointToClient(New Point(e.X, e.Y)))
        Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

        If ugrOver IsNot Nothing Then
            dropIndex = ugrOver.Index

            Dim SelRows As SelectedRowsCollection = DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection)

            For Each aRow As UltraGridRow In SelRows
                gridRanking.Rows.Move(aRow, dropIndex)
            Next

            For Each fila As UltraGridRow In gridRanking.Rows
                fila.Cells(5).Value = fila.Index + 1
            Next

        End If
    End Sub

    Private Sub gridRanking_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridRanking.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then

            Dim NextRowIndex As Integer = gridRanking.ActiveRow.Index + 1
            Try
                gridRanking.DisplayLayout.Rows(NextRowIndex).Activated = True
                gridRanking.DisplayLayout.Rows(NextRowIndex).Selected = True
            Catch ex As Exception
                gridRanking.ActiveRow.Activated = False
            End Try

        End If

        If e.KeyChar = ChrW(Keys.Escape) Then
            gridRanking.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        End If

    End Sub

    Private Sub gridRanking_MouseClick(sender As Object, e As MouseEventArgs) Handles gridRanking.MouseClick

        Dim mainElement As UIElement
        Dim element As UIElement
        Dim screenPoint As Point
        Dim clientPoint As Point
        Dim row As UltraGridRow
        Dim cell As UltraGridCell

        mainElement = Me.gridRanking.DisplayLayout.UIElement
        screenPoint = Control.MousePosition
        clientPoint = Me.gridRanking.PointToClient(screenPoint)
        element = mainElement.ElementFromPoint(clientPoint)

        If element Is Nothing Then Return

        row = element.GetContext(GetType(UltraGridRow))

        If Not row Is Nothing Then
            cell = element.GetContext(GetType(UltraGridCell))

            If Not cell Is Nothing Then

                If e.Button <> Windows.Forms.MouseButtons.Right Then Return

                Dim cms = New ContextMenuStrip
                Dim item1 = cms.Items.Add("Cambiar Clasificación")
                item1.Tag = 1
                AddHandler item1.Click, AddressOf gridRanking_menuChoice

                cms.Show(Control.MousePosition)

            End If
        End If

    End Sub

    Private Sub gridRanking_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        Dim grid As DataTable = gridRanking.DataSource
        Dim row As UltraGridRow = gridRanking.ActiveRow

        show_message("Advertencia", "El ranking será modificado a la ultima posición de la clasificación seleccionada")

        If selection = 1 Then
            For Each row In gridRanking.Selected.Rows
                Dim i As Integer = gridRanking.Rows.Count
                gridRanking.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
                gridRanking.DisplayLayout.Override.CellClickAction = CellClickAction.Edit
            Next
        End If

    End Sub

    Private Sub gridRanking_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridRanking.BeforeExitEditMode
        Try
            Dim cellIndex As Integer = gridRanking.ActiveCell.Column.Index

            If gridRanking.ActiveRow.DataChanged Then

            Else
                If gridRanking.ActiveCell.DataChanged Then
                Else
                    If String.IsNullOrWhiteSpace(gridRanking.ActiveCell.Value) Then
                        gridRanking.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                    End If
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gridRanking_AfterRowActivate(sender As Object, e As EventArgs) Handles gridRanking.AfterRowActivate
        gridRanking.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        For Each row In gridRanking.Rows
            row.Activation = Activation.NoEdit
        Next
    End Sub

    Private Sub gridRanking_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridRanking.BeforeRowDeactivate

        gridRanking.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

    End Sub

    Private Sub cboxClienteClasificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxClienteClasificacion.SelectedIndexChanged
        If cboxClienteClasificacion.SelectedIndex = 0 Then Return

        For Each row As DataRow In tblClasificaciones.Rows
            If cboxClienteClasificacion.SelectedValue.ToString = row.Item("clas_clasificacioclientenid").ToString Then
                If IsDBNull(row.Item("clas_descripcion")) = False Then
                    'txtDescripcionClasificacion.Text = row.Item("clas_descripcion")
                    listClasificaciones.Add(cboxClienteClasificacion.SelectedValue + " - " + row.Item("clas_descripcion"))
                    listClasificacionesIds.Add(cboxClienteClasificacion.SelectedValue)
                Else
                    'txtDescripcionClasificacion.Text = ""
                End If
            ElseIf cboxClienteClasificacion.SelectedValue.ToString = "" Then
                'txtDescripcionClasificacion.Text = ""
            End If
        Next

        grdFiltroClasificacionCliente.DataSource = Nothing
        grdFiltroClasificacionCliente.DataSource = listClasificaciones
        cboxClienteClasificacion.SelectedIndex = 0

    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        gpbFiltroIncentivos.Height = 45
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        gpbFiltroIncentivos.Height = 145
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim fileName As String = String.Empty
        With fbdUbicacionArchivo

            .Reset()
            .Description = " Seleccione una carpeta "
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True

            Dim ret As DialogResult = .ShowDialog

            If ret = Windows.Forms.DialogResult.OK Then

                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                fileName = .SelectedPath + "\Datos_ListaClientes_" + fecha_hora + ".xlsx"
                gridExcelExporter.Export(Me.gridRanking, fileName)

            End If
            show_message("Exito", "Los datos se exportaron correctamente")
            Process.Start(fileName)

            .Dispose()

        End With
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        asignaFormato_Columna(grid)

    End Sub

    Private Sub btnFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnFiltroCliente.Click
        AbrirBusquedaFiltroCliente()
    End Sub

    Private Sub AbrirBusquedaFiltroCliente()
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 1

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFiltroCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)

        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroCliente.DataSource = listado.listParametros
        With grdFiltroCliente
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
        End With

        grdFiltroCliente.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub grdFiltroCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFiltroCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFiltroCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFiltroClasificacionCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFiltroClasificacionCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFiltroClasificacionCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFiltroClasificacionCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroClasificacionCliente.InitializeLayout
        grid_diseño(grdFiltroClasificacionCliente)
        grdFiltroClasificacionCliente.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Clasificaciones"
    End Sub

    Private Sub grdFiltroCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroCliente.InitializeLayout
        grid_diseño(grdFiltroCliente)
        grdFiltroCliente.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Clasificaciones"
    End Sub

End Class