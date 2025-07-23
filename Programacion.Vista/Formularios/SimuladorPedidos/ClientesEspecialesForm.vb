Imports Framework.Negocios
Imports Programacion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ClientesEspecialesForm

    Dim AlturaMaximaPanel As Int32 = 0
#Region "UI"
    Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs)
        ' grbNaves.Height = InterfazUsuario.AlturaMinimaPanel
    End Sub



    Public Sub guardarCambiosClienteExcluir()
        Dim objBU As New Negocios.ClientesProgramacionBU
        Dim objMens As New Tools.ConfirmarForm
        objMens.mensaje = "Esta seguro de guardar los cambios"
        If objMens.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each row As UltraGridRow In grdClientesExcluidos.Rows
                objBU.editarExcluirCliente(row.Cells("clie_excluirproductosnuevos").Value, row.Cells("clie_clienteid").Value)
            Next
            Dim objMensExito As New Tools.ExitoForm
            objMensExito.mensaje = "Registro Correcto"
            objMensExito.ShowDialog()
        End If
    End Sub

    Private Sub form_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        'ConfigurarInterfazUsuario()
        ConfigurarSeguridad()
        LlenarTabla()
        llebarTablaClientesExcluidos()
        cargarComobos()


    End Sub


    Private Sub ConfigurarSeguridad()
        'Dim permiso As Boolean

        'permiso = PermisosUsuarioBU.ConsultarPermiso("PRG_AUTORIZAR", "WRITE")
        'btnAutorizar.Visible = permiso
        'lblAutorizar.Visible = permiso


    End Sub

    ''' <summary>
    ''' Configura el formulario con los estándares de programación del proyecto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ConfigurarInterfazUsuario()
        AlturaMaximaPanel = grbNaves.Height
        ' pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)
        ' Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)
    End Sub







#End Region

    Public Sub llebarTablaClientesExcluidos()
        Dim objCLBU As New ClientesProgramacionBU
        Dim dtClientes As New DataTable
        dtClientes = objCLBU.ConsultaClientesExclucionProductosNuevos()
        If dtClientes.Rows.Count > 0 Then
            grdClientesExcluidos.DataSource = dtClientes
            disenioGridClientesExcluidos()
        Else
            grdClientesExcluidos.DataSource = Nothing
        End If
    End Sub

    Public Sub disenioGridClientesExcluidos()
        Dim band As UltraGridBand = Me.grdClientesExcluidos.DisplayLayout.Bands(0)

        With band

            .Columns("clie_clienteid").Hidden = True
            .Columns("clie_nombregenerico").CellActivation = Activation.NoEdit
            .Columns("clie_excluirproductosnuevos").Style = ColumnStyle.CheckBox
            .Columns("clie_nombregenerico").Header.Caption = "Cliente"
            .Columns("clie_excluirproductosnuevos").Header.Caption = "Excluir"

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

        End With

        grdClientesExcluidos.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdClientesExcluidos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdClientesExcluidos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdClientesExcluidos.DisplayLayout.Override.RowSelectorWidth = 35
        grdClientesExcluidos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdClientesExcluidos.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True

        grdClientesExcluidos.DisplayLayout.Override.SelectTypeRow = SelectType.SingleAutoDrag
        grdClientesExcluidos.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdClientesExcluidos.AllowDrop = True
        band.Columns("clie_excluirproductosnuevos").Width = 60
    End Sub

    Private Sub btnExportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportarExcel.Click
        ExportarExcel()
    End Sub

    Private Sub ExportarExcel()
        Dim vErrorForm As New ErroresForm
        Dim vExitoForm As New ExitoForm
        Try
            Dim sfd As New SaveFileDialog
            sfd.DefaultExt = ".xls"
            sfd.Filter = "*.xls|*.xls"
            If sfd.ShowDialog = System.Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            If sfd.FileName.Trim = "" Then
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            Dim nombre As String = sfd.FileName

            Me.UltraGridExcelExporter1.Export(grdDatos, nombre)
            System.Diagnostics.Process.Start(nombre)

            vExitoForm.Text = "Clientes Especiales"
            vExitoForm.mensaje = "Información exportada correctamente"
            vExitoForm.ShowDialog()
        Catch ex As Exception
            vErrorForm.Text = "Clientes Especiales"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        LlenarTabla()
    End Sub



    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        With grdDatos
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        eliminarClientesEspecial()
    End Sub

    Private Sub btnAbajo_Click_1(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlOpciones.Height = 88
    End Sub

    Private Sub btnArriba_Click_1(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlOpciones.Height = 32
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        agregarClienteEspecial()
    End Sub
    Public Sub eliminarClientesEspecial()
        Dim vClientesEspeciales As New ClientesEspecialesBU
        Dim vErrorForm As New ErroresForm
        Dim vConfirmarForm As New ConfirmarForm
        Dim vExitoForm As New ExitoForm
        Try
            Me.Cursor = Cursors.WaitCursor
            vConfirmarForm.Text = "Clientes Especiales"
            vConfirmarForm.mensaje = "¿ Desea eliminar como cliente especial al registro seleccionado ?"
            Dim vDialogResult As New DialogResult
            vDialogResult = vConfirmarForm.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then
                vClientesEspeciales.Eliminar(grdDatos.ActiveRow.Cells("id_").Value)
                LlenarTabla()
                actualizarClienteEspecial()
                LlenarTabla()
                vExitoForm.Text = "Fecha de entrega"
                vExitoForm.mensaje = "Registro eliminado con éxito"
                vExitoForm.ShowDialog()

            End If
        Catch ex As Exception
            vErrorForm.Text = "Clientes Especiales"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub actualizarClienteEspecial()
        Dim vClientesEspeciales As New ClientesEspecialesBU
        Dim i As Integer = 1
        For Each rowGrd As UltraGridRow In grdDatos.Rows
            vClientesEspeciales.Actualizar(CInt(rowGrd.Cells("id_").Value), i)
            i += 1
        Next
    End Sub
    Public Sub guardarCambiosClientesEspeciales()
        Dim vErrorForm As New ErroresForm
        Dim vConfirmarForm As New ConfirmarForm
        Dim vExitoForm As New ExitoForm
        Try
            Me.Cursor = Cursors.WaitCursor
            vConfirmarForm.Text = "Clientes Especiales"
            vConfirmarForm.mensaje = "¿ Desea actualizar el orden de los clientes especiales ?"
            Dim vDialogResult As New DialogResult
            vDialogResult = vConfirmarForm.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then
                actualizarClienteEspecial()
                LlenarTabla()
                vExitoForm.Text = "Fecha de entrega"
                vExitoForm.mensaje = "Clientes especiales reordenados con éxito"
                vExitoForm.ShowDialog()

            End If
        Catch ex As Exception
            vErrorForm.Text = "Clientes Especiales"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub agregarClienteEspecial()
        Dim vClientesEspeciales As New ClientesEspecialesBU
        Dim vErrorForm As New ErroresForm
        Dim vConfirmarForm As New ConfirmarForm
        Dim vExitoForm As New ExitoForm
        Try
            Me.Cursor = Cursors.WaitCursor
            vConfirmarForm.Text = "Clientes Especiales"
            vConfirmarForm.mensaje = "¿ Desea agregar como cliente especial al registro seleccionado ?"
            Dim vDialogResult As New DialogResult
            vDialogResult = vConfirmarForm.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then
                vClientesEspeciales.Agregar(cbClientes.SelectedValue, CInt(lblOrden.Text))
                cargarComobos()
                LlenarTabla()
                vExitoForm.Text = "Fecha de entrega"
                vExitoForm.mensaje = "Registro actualizado con éxito"
                vExitoForm.ShowDialog()

            End If
        Catch ex As Exception
            vErrorForm.Text = "Clientes Especiales"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub cargarComobos()
        Dim vClientesEspeciales As New ClientesEspecialesBU
        With cbClientes
            .DataSource = vClientesEspeciales.TablaCombo
            .DisplayMember = "Nombre"
            .ValueMember = "IdCadena"
            '.AutoCompleteMode = AutoCompleteMode.SuggestAppend ' This is necessary
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With
    End Sub

    Private Sub LlenarTabla()
        Dim vClientesEspeciales As New ClientesEspecialesBU
        Dim vErrorForm As New ErroresForm
        Try

            Me.Cursor = Cursors.WaitCursor
            grdDatos.DataSource = Nothing
            grdDatos.DataSource = vClientesEspeciales.Tabla
            formatotabla()
        Catch ex As Exception
            vErrorForm.Text = "Clientes Especiales"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Public Sub formatotabla()
        grdDatos.DisplayLayout.Bands(0).Columns.Add("NOrden", "Orden Nuevo")

        Dim band As UltraGridBand = Me.grdDatos.DisplayLayout.Bands(0)
        With band
            .Columns("ID_").CellActivation = Activation.NoEdit
            .Columns("Nombre").CellActivation = Activation.NoEdit
            .Columns("Orden").CellActivation = Activation.NoEdit
            .Columns("NOrden").CellActivation = Activation.NoEdit
            .Columns("ID_").Hidden = True
            .Columns("Orden").Header.Caption = "Orden Actual"

            .Columns("NOrden").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Orden").CellAppearance.TextHAlign = HAlign.Right

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdDatos.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdDatos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdDatos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDatos.DisplayLayout.Override.RowSelectorWidth = 35
        grdDatos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdDatos.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True



        grdDatos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grdDatos.DisplayLayout.Override.SelectTypeRow = SelectType.SingleAutoDrag
        grdDatos.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdDatos.AllowDrop = True
        band.Columns("Orden").Width = 60
        band.Columns("NOrden").Width = 60

        Dim contarTotalTickets As Integer = 0
        For Each rowGrd As UltraGridRow In grdDatos.Rows
            contarTotalTickets += 1
            rowGrd.Cells("NOrden").Value = contarTotalTickets
        Next
        lblOrden.Text = (contarTotalTickets + 1)

    End Sub

    Private Sub grdDatos_BeforeRowExpanded(sender As Object, e As CancelableRowEventArgs) Handles grdDatos.BeforeRowExpanded
        e.Cancel = True
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If tbtClientes.SelectedIndex = 0 Then
            guardarCambiosClientesEspeciales()
        ElseIf tbtClientes.SelectedIndex = 1 Then
            guardarCambiosClienteExcluir()
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub gridRanking_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdDatos.SelectionDrag

        grdDatos.DoDragDrop(grdDatos.Selected.Rows, DragDropEffects.Move)

    End Sub

    Private Sub gridRanking_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdDatos.DragOver
        e.Effect = DragDropEffects.Move
        Dim grid As UltraGrid = TryCast(sender, UltraGrid)
        Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

        If pointInGridCoords.Y < 20 Then
            Me.grdDatos.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
        ElseIf pointInGridCoords.Y > grid.Height - 20 Then
            Me.grdDatos.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
        End If
    End Sub

    Private Sub gridRanking_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdDatos.DragDrop
        Dim dropIndex As Integer = 0
        Dim uieOver As UIElement = grdDatos.DisplayLayout.UIElement.ElementFromPoint(grdDatos.PointToClient(New Point(e.X, e.Y)))
        Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

        If ugrOver IsNot Nothing Then
            dropIndex = ugrOver.Index
            If dropIndex = -1 Then
                dropIndex = 0
            End If
            Dim SelRows As SelectedRowsCollection = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)

            For Each aRow As UltraGridRow In SelRows
                grdDatos.Rows.Move(aRow, dropIndex)
            Next

            For Each fila As UltraGridRow In grdDatos.Rows
                fila.Cells("NOrden").Value = fila.Index + 1
            Next

        End If
    End Sub


    Private Sub grdDatos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdDatos.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub tbtClientes_TabIndexChanged(sender As Object, e As EventArgs) Handles tbtClientes.TabIndexChanged
        If tbtClientes.SelectedIndex = 0 Then
            btnAltas.Enabled = True
            lblActualizar.Enabled = True
            btnExportarExcel.Enabled = True
            Label4.Enabled = True
        ElseIf tbtClientes.SelectedIndex = 1 Then
            btnAltas.Enabled = False
            lblActualizar.Enabled = False
            btnExportarExcel.Enabled = False
            Label4.Enabled = False
        End If
    End Sub

    Private Sub grdDatos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdDatos.InitializeLayout

    End Sub
End Class