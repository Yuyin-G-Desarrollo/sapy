Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class frmConfClientesEspecialesOrden

    Public Sub llenarDatosSimulacionActual()
        Dim objBU As New Negocios.SimulacionBU
        Dim dtDatosUltimaConf As New DataTable
        Dim objBUArts As New Negocios.ArticulosPreferentesBU
        dtDatosUltimaConf = objBU.consultaDatosUltimaConfiguracion


        If dtDatosUltimaConf.Rows.Count > 0 Then
            lblNombreSimulacion.Text = dtDatosUltimaConf.Rows(0).Item("ProcSimMae_Descripcion").ToString.Trim
            lblIdSimulacion.Text = dtDatosUltimaConf.Rows(0).Item("ProcSimMae_ProcSimuladorID").ToString
            Dim objClientesBU As New Negocios.ClientesEspecialesBU
            Dim dtClientes As New DataTable
            llenarTablaClientesEspeciales(lblIdSimulacion.Text)
            llenarTablaClientesConfigurados(lblIdSimulacion.Text)
        Else
            grdConfiguracion.DataSource = Nothing
        End If

    End Sub

    Public Sub guardarOrdenClientes()
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.ClientesEspecialesBU
        Dim orden As Int32 = 0
        For Each rowCL As UltraGridRow In grdConfiguracion.Rows
            objBU.editarOrdenClienteEspecialSim(rowCL.Cells("cesp_orden").Value.ToString, rowCL.Cells("cesp_simClientesEspecialesID").Value.ToString)
            orden += 1
        Next
        Me.Cursor = Cursors.Default
        Dim objMensajeExito As New Tools.ExitoForm
        objMensajeExito.mensaje = "Registros modificados exitosamente"
        objMensajeExito.ShowDialog()
    End Sub

    Public Sub pasarClientes()
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.ClientesEspecialesBU
        Dim orden As Int32 = 0
        orden = grdConfiguracion.Rows.Count + 1
        For Each rowCL As UltraGridRow In grdClientesOrigen.Rows
            If rowCL.Cells("SEL").Value = True Then
                objBU.insertarClienteEspecialSimulacion(lblIdSimulacion.Text, rowCL.Cells("clie_idsicy").Value.ToString, orden)
                orden += 1
            End If
        Next

        llenarTablaClientesConfigurados(lblIdSimulacion.Text)
        llenarTablaClientesEspeciales(lblIdSimulacion.Text)
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub regresarClientes()
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.ClientesEspecialesBU
        Dim orden As Int32 = 1
        For Each rowCL As UltraGridRow In grdConfiguracion.Rows
            If rowCL.Cells("SEL").Value = True Then
                objBU.eliminarSimulacionClienteEspecial(rowCL.Cells("cesp_simClientesEspecialesID").Value.ToString)
            End If
        Next
        llenarTablaClientesConfigurados(lblIdSimulacion.Text)
        llenarTablaClientesEspeciales(lblIdSimulacion.Text)
        For Each rowCL As UltraGridRow In grdConfiguracion.Rows
            rowCL.Cells("cesp_orden").Value = orden
            objBU.editarOrdenClienteEspecialSim(orden, rowCL.Cells("cesp_simClientesEspecialesID").Value.ToString)
            orden += 1
        Next
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub llenarComboSimulaciones()
        Dim objBU As New Negocios.SimulacionBU
        Dim dtSimulaciones As New DataTable
        dtSimulaciones = objBU.consultaSimulacionMaestro
        If dtSimulaciones.Rows.Count > 0 Then
            dtSimulaciones.Rows.InsertAt(dtSimulaciones.NewRow, 0)
            cmbSimulaciones.DataSource = dtSimulaciones
            cmbSimulaciones.ValueMember = "ProcSimMae_ProcSimuladorID"
            cmbSimulaciones.DisplayMember = "ProcSimMae_Descripcion"
        End If
    End Sub

    Public Sub llenarTablaClientesConfigurados(ByVal idSimulacion As Int32)

        Dim objBU As New Negocios.ClientesEspecialesBU
        Dim dtClientes As New DataTable
        dtClientes = objBU.datosClientesEspecialesConfiguradosSimulacion(idSimulacion)
        If dtClientes.Rows.Count > 0 Then
            grdConfiguracion.DataSource = dtClientes
            formatoClientesEspSimulacion()
        Else
            grdConfiguracion.DataSource = Nothing
        End If

    End Sub

    Public Sub llenarTablaClientesEspeciales(ByVal idSimulacion As Int32)
        Dim objBU As New Negocios.ClientesEspecialesBU
        Dim dtClientesEsp As New DataTable
        dtClientesEsp = objBU.datosClietesEspecialesNoConfiguradosSimulacion(idSimulacion)
        If dtClientesEsp.Rows.Count > 0 Then
            grdClientesOrigen.DataSource = dtClientesEsp
            formatoClientesOriginal()
        Else
            grdClientesOrigen.DataSource = Nothing
        End If
    End Sub

    Public Sub llenarTablaClientesConfiguradosAnterior(ByVal idSimulacion As Int32)

        Dim objBU As New Negocios.ClientesEspecialesBU
        Dim dtClientes As New DataTable
        dtClientes = objBU.datosClientesEspecialesConfiguradosSimulacion(idSimulacion)
        If dtClientes.Rows.Count > 0 Then
            grdAnteriores.DataSource = dtClientes
            formatoClientesEspSimulacionAnterior()
        Else
            grdAnteriores.DataSource = Nothing
        End If

    End Sub

    Public Sub formatoClientesOriginal()
        'SEL	cesp_cespID	cesp_idCadena	cesp_orden	clie_clienteid	clie_nombregenerico
        Dim band As UltraGridBand = Me.grdClientesOrigen.DisplayLayout.Bands(0)
        With band
            .Columns("clie_nombregenerico").CellActivation = Activation.NoEdit
            .Columns("cesp_orden").CellActivation = Activation.NoEdit
            .Columns("cesp_cespID").Hidden = True
            .Columns("clie_idsicy").Hidden = True
            .Columns("clie_clienteid").Hidden = True

            .Columns("clie_nombregenerico").Header.Caption = "Cliente"
            .Columns("cesp_orden").Header.Caption = "Orden"
            .Columns("SEL").Header.Caption = ""

            .Columns("cesp_orden").CellAppearance.TextHAlign = HAlign.Right

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        grdClientesOrigen.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdClientesOrigen.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdClientesOrigen.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdClientesOrigen.DisplayLayout.Override.RowSelectorWidth = 35
        grdClientesOrigen.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdClientesOrigen.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True

        'grdClientesOrigen.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grdClientesOrigen.DisplayLayout.Override.SelectTypeRow = SelectType.SingleAutoDrag
        grdClientesOrigen.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdClientesOrigen.AllowDrop = True
    End Sub

    Public Sub formatoClientesEspSimulacion()
        Dim band As UltraGridBand = Me.grdConfiguracion.DisplayLayout.Bands(0)
        With band
            .Columns("cesp_simuIacionMaestroID").CellActivation = Activation.NoEdit
            .Columns("cesp_orden").CellActivation = Activation.NoEdit
            .Columns("clie_nombregenerico").CellActivation = Activation.NoEdit
            .Columns("cesp_simClientesEspecialesID").Hidden = True
            .Columns("clie_clienteid").Hidden = True
            .Columns("clie_idsicy").Hidden = True
            .Columns("cesp_simuIacionMaestroID").Hidden = True

            .Columns("cesp_simuIacionMaestroID").Header.Caption = "Id"
            .Columns("cesp_orden").Header.Caption = "Orden"
            .Columns("clie_nombregenerico").Header.Caption = "Cliente"
            .Columns("SEL").Header.Caption = ""

            .Columns("cesp_orden").CellAppearance.TextHAlign = HAlign.Right

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        grdConfiguracion.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdConfiguracion.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdConfiguracion.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdConfiguracion.DisplayLayout.Override.RowSelectorWidth = 35
        grdConfiguracion.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdConfiguracion.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True

        'grdConfiguracion.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grdConfiguracion.DisplayLayout.Override.SelectTypeRow = SelectType.SingleAutoDrag
        grdConfiguracion.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdConfiguracion.AllowDrop = True
    End Sub

    Public Sub formatoClientesEspSimulacionAnterior()
        Dim band As UltraGridBand = Me.grdAnteriores.DisplayLayout.Bands(0)
        With band
            .Columns("cesp_simuIacionMaestroID").CellActivation = Activation.NoEdit
            .Columns("cesp_orden").CellActivation = Activation.NoEdit
            .Columns("clie_nombregenerico").CellActivation = Activation.NoEdit
            .Columns("cesp_simClientesEspecialesID").Hidden = True
            .Columns("clie_clienteid").Hidden = True
            .Columns("clie_idsicy").Hidden = True
            .Columns("cesp_simuIacionMaestroID").Hidden = True

            .Columns("cesp_simuIacionMaestroID").Header.Caption = "Id"
            .Columns("cesp_orden").Header.Caption = "Orden"
            .Columns("clie_nombregenerico").Header.Caption = "Cliente"
            .Columns("SEL").Header.Caption = ""

            .Columns("cesp_orden").CellAppearance.TextHAlign = HAlign.Right

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        grdAnteriores.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdAnteriores.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdAnteriores.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdAnteriores.DisplayLayout.Override.RowSelectorWidth = 35
        grdAnteriores.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdAnteriores.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True

        'grdConfiguracion.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grdAnteriores.DisplayLayout.Override.SelectTypeRow = SelectType.SingleAutoDrag
        grdAnteriores.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdAnteriores.AllowDrop = True
    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objConfirmar As New Tools.ConfirmarForm
        objConfirmar.mensaje = "¿Esta seguro de guardar los cambios en el orden de los clientes? (Simulación)"
        If objConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
            guardarOrdenClientes()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmConfClientesEspecialesOrden_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        llenarComboSimulaciones()
        llenarDatosSimulacionActual()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grpBotones.Height = 41
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grpBotones.Height = 74
    End Sub

    Private Sub btnAgregarCliente_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbSimulaciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSimulaciones.SelectedIndexChanged
        If cmbSimulaciones.SelectedIndex > 0 Then
            Dim item As Object
            item = cmbSimulaciones.SelectedItem
            llenarTablaClientesConfiguradosAnterior(cmbSimulaciones.SelectedValue)
            Me.grdAnteriores.DisplayLayout.Bands(0).Columns("SEL").Hidden = True
        Else
               grdAnteriores.DataSource = Nothing
        End If
    End Sub


    Private Sub grdConfiguracion_DragDrop(sender As Object, e As DragEventArgs) Handles grdConfiguracion.DragDrop
        Dim dropIndex As Integer = 0
        Dim uieOver As UIElement = grdConfiguracion.DisplayLayout.UIElement.ElementFromPoint(grdConfiguracion.PointToClient(New Point(e.X, e.Y)))
        Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

        If ugrOver IsNot Nothing Then
            dropIndex = ugrOver.Index
            If dropIndex = -1 Then
                dropIndex = 0
            End If
            Dim SelRows As SelectedRowsCollection = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)

            For Each aRow As UltraGridRow In SelRows
                grdConfiguracion.Rows.Move(aRow, dropIndex)
            Next

            Dim nOrden As Int32 = 1
            For Each fila As UltraGridRow In grdConfiguracion.Rows
                fila.Cells("cesp_orden").Value = nOrden
                nOrden += 1
            Next
        End If
    End Sub

    Private Sub grdConfiguracion_DragOver(sender As Object, e As DragEventArgs) Handles grdConfiguracion.DragOver
        e.Effect = DragDropEffects.Move
        Dim grid As UltraGrid = TryCast(sender, UltraGrid)
        Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

        If pointInGridCoords.Y < 20 Then
            Me.grdConfiguracion.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
        ElseIf pointInGridCoords.Y > grid.Height - 20 Then
            Me.grdConfiguracion.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
        End If
    End Sub

    Private Sub grdConfiguracion_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdConfiguracion.InitializeLayout

    End Sub

    Private Sub grdConfiguracion_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdConfiguracion.SelectionDrag
        grdConfiguracion.DoDragDrop(grdConfiguracion.Selected.Rows, DragDropEffects.Move)
    End Sub

    Private Sub btnPasarVariosClientes_Click(sender As Object, e As EventArgs) Handles btnPasarVariosClientes.Click
        Dim objConfirmar As New Tools.ConfirmarForm
        objConfirmar.mensaje = "¿Esta seguro de agregar clientes a la lista? (Simulación)"
        If objConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
            pasarClientes()
        End If
        chkSeleccionarTodoOrigen.Checked = False
        chkSeleccionarTodoConf.Checked = False
    End Sub

    Private Sub btnRegresarVariosClientes_Click(sender As Object, e As EventArgs) Handles btnRegresarVariosClientes.Click
        Dim objConfirmar As New Tools.ConfirmarForm
        objConfirmar.mensaje = "¿Esta quitar clientes de la lista? (Simulación)"
        If objConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
            regresarClientes()
        End If
        chkSeleccionarTodoOrigen.Checked = False
        chkSeleccionarTodoConf.Checked = False
    End Sub

    Private Sub chkSeleccionarTodoOrigen_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodoOrigen.CheckedChanged
        For Each rowgr As UltraGridRow In grdClientesOrigen.Rows
            rowgr.Cells("SEL").Value = chkSeleccionarTodoOrigen.Checked
        Next
    End Sub

    Private Sub chkSeleccionarTodoConf_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodoConf.CheckedChanged
        For Each rowgr As UltraGridRow In grdConfiguracion.Rows
            rowgr.Cells("SEL").Value = chkSeleccionarTodoConf.Checked
        Next
    End Sub

    Private Sub grdClientesOrigen_CellChange(sender As Object, e As CellEventArgs) Handles grdClientesOrigen.CellChange
     
    End Sub

    Private Sub grdConfiguracion_CellChange(sender As Object, e As CellEventArgs) Handles grdConfiguracion.CellChange
        
    End Sub

    Private Sub grdConfiguracion_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdConfiguracion.BeforeCellUpdate
        'If e.Cell.Column.ToString = "SEL" Then
        '    If e.Cell.Value = False Then
        '        chkSeleccionarTodoConf.Checked = False
        '    End If
        'End If
    End Sub

    Private Sub grdClientesOrigen_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdClientesOrigen.BeforeCellUpdate
        'If e.Cell.Column.ToString = "SEL" Then
        '    If e.Cell.Value = False Then
        '        chkSeleccionarTodoOrigen.Checked = False
        '    End If
        'End If
    End Sub

    Private Sub grdClientesOrigen_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientesOrigen.InitializeLayout
       
    End Sub



End Class