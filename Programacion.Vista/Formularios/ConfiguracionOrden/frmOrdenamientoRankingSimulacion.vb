Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmOrdenamientoRankingSimulacion

    Public Sub llenarTablaOrdenamientoSimulacionClasificacion(ByVal idSimulacion As Int32)
        Dim objBU As New Negocios.OpcionesSimlacionBU
        Dim dtDatos As New DataTable
        dtDatos = objBU.consultaClasificacionCliente(idSimulacion)
        If dtDatos.Rows.Count > 0 Then
            grdOrdenClasificacion.DataSource = dtDatos
            formatoGridOrdenClasificacion()
        Else
            grdOrdenClasificacion.DataSource = Nothing
        End If
    End Sub

    Public Sub llenarDatosSimulacionActual()
        Dim objBU As New Negocios.SimulacionBU
        Dim dtDatosUltimaConf As New DataTable

        dtDatosUltimaConf = objBU.consultaDatosUltimaConfiguracion

        If dtDatosUltimaConf.Rows.Count > 0 Then
            lblNombreSimulacion.Text = dtDatosUltimaConf.Rows(0).Item("ProcSimMae_Descripcion").ToString.Trim
            lblIdSimulacion.Text = dtDatosUltimaConf.Rows(0).Item("ProcSimMae_ProcSimuladorID").ToString

            llenarTablaClientesTodos(lblIdSimulacion.Text)
            llenarTablaConfigurados(lblIdSimulacion.Text)

        End If

    End Sub

    Public Sub editarOrdenPorClasificacion()
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.OpcionesSimlacionBU
        Dim nOrden As Int32 = 1

        For Each rowGr As UltraGridRow In grdClientesMovimiento.Rows
            objBU.cambiarConfiguracionClasRanking(cmbSimulaciones.SelectedValue,
                                                  rowGr.Cells("clie_clienteid").Value,
                                                  rowGr.Cells("clie_idsicy").Value,
                                                  cmbClasificacion.SelectedValue, nOrden,
                                                  rowGr.Cells("clie_clasificacionclienteid").Value.ToString,
                                                  rowGr.Cells("clie_ranking").Value)
            nOrden += 1
        Next

        If CInt(lblIdSimulacion.Text) > 0 Then
            llenarTablaClientesTodos(lblIdSimulacion.Text)
            llenarTablaConfigurados(lblIdSimulacion.Text)
        Else
            grdClientesTodos.DataSource = Nothing
            grdClientesMovimiento.DataSource = Nothing
        End If

        Me.Cursor = Cursors.Default
        Dim objMens As New Tools.ExitoForm
        objMens.mensaje = "Ordenamiento de la clasificación " + cmbClasificacion.Text + " actualizado exitosamente"
        If objMens.ShowDialog = Windows.Forms.DialogResult.OK Then
            objMens.ShowDialog()
        End If
    End Sub

    Public Sub editarClasificacionCliente()
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.OpcionesSimlacionBU
        Dim nOrden As Int32 = grdClientesMovimiento.Rows.Count + 1

        For Each rowGr As UltraGridRow In grdClientesTodos.Rows
            If rowGr.Cells("SEL").Value = True Then
                objBU.cambiarConfiguracionClasRanking(lblIdSimulacion.Text,
                                                      rowGr.Cells("clie_clienteid").Value,
                                                      rowGr.Cells("clie_idsicy").Value,
                                                     cmbSimulaciones.SelectedValue, nOrden,
                                                      rowGr.Cells("clie_clasificacionclienteid").Value.ToString,
                                                      rowGr.Cells("clie_ranking").Value)
                nOrden += 1
            End If
        Next
        'If cmbSimulaciones.SelectedIndex > 0 Then
        '    llenarTablaClientesTodos(cmbSimulaciones.SelectedValue)
        '    llenarTablaConfigurados(cmbSimulaciones.SelectedValue)
        '    llenarTablaOrdenamientoSimulacionClasificacion(cmbSimulaciones.SelectedValue)
        'Else
        '    grdClientesTodos.DataSource = Nothing
        '    grdClientesMovimiento.DataSource = Nothing
        '    grdOrdenClasificacion.DataSource = Nothing
        'End If

        If CInt(lblIdSimulacion.Text) > 0 Then
            llenarTablaClientesTodos(lblIdSimulacion.Text)
            llenarTablaConfigurados(lblIdSimulacion.Text)
        Else
            grdClientesTodos.DataSource = Nothing
            grdClientesMovimiento.DataSource = Nothing
        End If

        If cmbSimulaciones.SelectedIndex > 0 Then
            llenarTablaOrdenamientoSimulacionClasificacion(cmbSimulaciones.SelectedValue)
        Else
            grdOrdenClasificacion.DataSource = Nothing
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Public Sub reordenarRankingClientesConf()
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.OpcionesSimlacionBU
        Dim nOrden As Int32 = grdClientesMovimiento.Rows.Count + 1
        Dim clasActual As String = ""

        For Each rowGr As UltraGridRow In grdClientesTodos.Rows
            If clasActual <> rowGr.Cells("sirc_Clasificacion").Value.ToString Then
                clasActual = rowGr.Cells("sirc_Clasificacion").Value.ToString
                nOrden = 1
            End If
            objBU.cambiarConfiguracionClasRanking(cmbSimulaciones.SelectedValue,
                                                      rowGr.Cells("clie_clienteid").Value,
                                                      rowGr.Cells("clie_idsicy").Value,
                                                      rowGr.Cells("sirc_Clasificacion").Value.ToString, nOrden,
                                                      rowGr.Cells("clie_clasificacionclienteid").Value.ToString,
                                                      rowGr.Cells("clie_ranking").Value)
            nOrden += 1
        Next

        'If cmbSimulaciones.SelectedIndex > 0 Then
        '    llenarTablaClientesTodos(cmbSimulaciones.SelectedValue)
        '    llenarTablaConfigurados(cmbSimulaciones.SelectedValue)
        '    llenarTablaOrdenamientoSimulacionClasificacion(cmbSimulaciones.SelectedValue)
        'Else
        '    grdClientesTodos.DataSource = Nothing
        '    grdClientesMovimiento.DataSource = Nothing
        '    grdOrdenClasificacion.DataSource = Nothing
        'End If

        If CInt(lblIdSimulacion.Text) > 0 Then
            llenarTablaClientesTodos(lblIdSimulacion.Text)
            llenarTablaConfigurados(lblIdSimulacion.Text)
        Else
            grdClientesTodos.DataSource = Nothing
            grdClientesMovimiento.DataSource = Nothing
        End If

        If cmbSimulaciones.SelectedIndex > 0 Then

            llenarTablaOrdenamientoSimulacionClasificacion(cmbSimulaciones.SelectedValue)
        Else
            grdOrdenClasificacion.DataSource = Nothing
        End If

        Me.Cursor = Cursors.Default
        Dim objMens As New Tools.ExitoForm
        objMens.mensaje = "Ordenamiento actualizado exitosamente"
        If objMens.ShowDialog = Windows.Forms.DialogResult.OK Then
            objMens.ShowDialog()
        End If
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

    Public Sub llenarComboClasificaciones()

        Dim objBU As New Negocios.OpcionesSimlacionBU
        Dim dtClasificaciones As New DataTable
        dtClasificaciones = objBU.consultaClasificaciones

        If dtClasificaciones.Rows.Count > 0 Then
            dtClasificaciones.Rows.InsertAt(dtClasificaciones.NewRow, 0)
            cmbClasificacion.DataSource = dtClasificaciones
            cmbClasificacion.DisplayMember = "clas_nombre"
            cmbClasificacion.ValueMember = "clas_clasificacioclientenid"
        Else
            cmbClasificacion.DataSource = Nothing
        End If

    End Sub


    Public Sub llenarTablaClientesTodos(ByVal idSimulacion As Int32)
        Dim objBU As New Negocios.OpcionesSimlacionBU
        Dim dtClientesTodos As New DataTable

        If cmbClasificacion.SelectedIndex > 0 Then
            dtClientesTodos = objBU.verClientesClasificacionRealYConfigurada(idSimulacion, cmbClasificacion.SelectedValue)
            If dtClientesTodos.Rows.Count > 0 Then
                grdClientesTodos.DataSource = dtClientesTodos
                formatoClientesTodos()
            Else
                grdClientesTodos.DataSource = Nothing
            End If

        End If
    End Sub

    Public Sub llenarTablaConfigurados(ByVal idSimulacion As Int32)
        If cmbClasificacion.SelectedIndex > 0 Then
            Dim objBU As New Negocios.OpcionesSimlacionBU
            Dim dtClientesConf As New DataTable
            dtClientesConf = objBU.consultaClientesConfigurados(idSimulacion, cmbClasificacion.SelectedValue)
            If dtClientesConf.Rows.Count > 0 Then
                grdClientesMovimiento.DataSource = dtClientesConf
                formatoClientesConfigurados()
            Else
                grdClientesMovimiento.DataSource = Nothing
            End If
        Else
            grdClientesMovimiento.DataSource = Nothing
        End If

    End Sub

    Public Sub formatoClientesTodos()
        Dim band As UltraGridBand = Me.grdClientesTodos.DisplayLayout.Bands(0)
        'clie_clienteid	clie_idsicy	clie_nombregenerico	clie_clasificacionclienteid	clie_ranking	sirc_Clasificacion	sirc_Ranking
        With band
            .Columns("clie_clienteid").Hidden = True
            .Columns("clie_idsicy").Hidden = True

            .Columns("SEL").Header.Caption = ""
            .Columns("clie_nombregenerico").Header.Caption = "Cliente"
            .Columns("clie_clasificacionclienteid").Header.Caption = "C. FTC"
            .Columns("clie_ranking").Header.Caption = "R. FTC"
            .Columns("sirc_Clasificacion").Header.Caption = "C. Conf."
            .Columns("sirc_Ranking").Header.Caption = "R. Conf."

            .Columns("SEL").Width = 25
            .Columns("clie_nombregenerico").Width = 150
            .Columns("clie_clasificacionclienteid").Width = 30
            .Columns("clie_ranking").Width = 30
            .Columns("sirc_Clasificacion").Width = 30
            .Columns("sirc_Ranking").Width = 30

            .Columns("clie_ranking").CellAppearance.TextHAlign = HAlign.Right
            .Columns("sirc_Ranking").CellAppearance.TextHAlign = HAlign.Right

            .Columns("clie_nombregenerico").CellActivation = Activation.NoEdit
            .Columns("clie_clasificacionclienteid").CellActivation = Activation.NoEdit
            .Columns("clie_ranking").CellActivation = Activation.NoEdit
            .Columns("sirc_Clasificacion").CellActivation = Activation.NoEdit
            .Columns("sirc_Ranking").CellActivation = Activation.NoEdit

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdClientesTodos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdClientesTodos.DisplayLayout.Override.RowSelectorWidth = 35
        grdClientesTodos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdClientesTodos.Rows(0).Selected = True
        'grdClientesTodos.DisplayLayout.Bands(0).Override.CellClickAction = CellClickAction.RowSelect
        'grdClientesTodos.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
    End Sub

    Public Sub formatoClientesConfigurados()
        Dim band As UltraGridBand = Me.grdClientesMovimiento.DisplayLayout.Bands(0)
        With band
            .Columns("clie_clienteid").Hidden = True
            .Columns("clie_idsicy").Hidden = True
            .Columns("sirc_simRankingClasificacionId").Hidden = True

            .Columns("clie_nombregenerico").Header.Caption = "Cliente"

            .Columns("clie_clasificacionclienteid").Header.Caption = "C. FTC"
            .Columns("clie_ranking").Header.Caption = "R. FTC"
            .Columns("sirc_Clasificacion").Header.Caption = "C. Conf."
            .Columns("sirc_Ranking").Header.Caption = "R. Conf."

            .Columns("clie_nombregenerico").Width = 150
            .Columns("clie_clasificacionclienteid").Width = 30
            .Columns("clie_ranking").Width = 30
            .Columns("sirc_Clasificacion").Width = 30
            .Columns("sirc_Ranking").Width = 30

            .Columns("clie_ranking").CellAppearance.TextHAlign = HAlign.Right
            .Columns("sirc_Ranking").CellAppearance.TextHAlign = HAlign.Right

            .Columns("clie_nombregenerico").CellActivation = Activation.NoEdit
            .Columns("clie_clasificacionclienteid").CellActivation = Activation.NoEdit
            .Columns("clie_ranking").CellActivation = Activation.NoEdit
            .Columns("sirc_Clasificacion").CellActivation = Activation.NoEdit
            .Columns("sirc_Ranking").CellActivation = Activation.NoEdit

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdClientesMovimiento.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdClientesMovimiento.DisplayLayout.Override.RowSelectorWidth = 35
        grdClientesMovimiento.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdClientesMovimiento.Rows(0).Selected = True
        'grdClientesMovimiento.DisplayLayout.Bands(0).Override.CellClickAction = CellClickAction.RowSelect
        'grdClientesMovimiento.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
        grdClientesMovimiento.DisplayLayout.Override.SelectTypeRow = SelectType.SingleAutoDrag
        grdClientesMovimiento.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdClientesMovimiento.AllowDrop = True
    End Sub

    Public Sub formatoGridOrdenClasificacion()
        Dim band As UltraGridBand = Me.grdOrdenClasificacion.DisplayLayout.Bands(0)
        With band
            .Columns("sirc_simRankingClasificacionId").Hidden = True
            .Columns("sirc_cadenaId").Hidden = True
            .Columns("sirc_clienteId").Hidden = True

            .Columns("clie_nombregenerico").Header.Caption = "Cliente"
            .Columns("clie_clasificacionclienteid").Header.Caption = "C. FTC"
            .Columns("clie_ranking").Header.Caption = "R. FTC"
            .Columns("sirc_Clasificacion").Header.Caption = "C. Conf."
            .Columns("sirc_Ranking").Header.Caption = "R. Conf."

            .Columns("clie_nombregenerico").Width = 450
            .Columns("clie_clasificacionclienteid").Width = 30
            .Columns("clie_ranking").Width = 30
            .Columns("sirc_Clasificacion").Width = 30
            .Columns("sirc_Ranking").Width = 30

            .Columns("clie_ranking").CellAppearance.TextHAlign = HAlign.Right
            .Columns("sirc_Ranking").CellAppearance.TextHAlign = HAlign.Right

            .Columns("clie_nombregenerico").CellActivation = Activation.NoEdit
            .Columns("clie_clasificacionclienteid").CellActivation = Activation.NoEdit
            .Columns("clie_ranking").CellActivation = Activation.NoEdit
            .Columns("sirc_Clasificacion").CellActivation = Activation.NoEdit
            .Columns("sirc_Ranking").CellActivation = Activation.NoEdit

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdOrdenClasificacion.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdOrdenClasificacion.DisplayLayout.Override.RowSelectorWidth = 35
        grdOrdenClasificacion.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdOrdenClasificacion.Rows(0).Selected = True
        grdOrdenClasificacion.DisplayLayout.Bands(0).Override.CellClickAction = CellClickAction.RowSelect
    End Sub

    Private Sub frmOrdenamientoRankingSimulacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        'ultima() aqui voy
        llenarComboClasificaciones()
        llenarDatosSimulacionActual()
        llenarComboSimulaciones()
        'llenarTablaClasificaciones()
    End Sub

    Private Sub cmbSimulaciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSimulaciones.SelectedIndexChanged
        If cmbSimulaciones.SelectedIndex > 0 Then
            llenarTablaOrdenamientoSimulacionClasificacion(cmbSimulaciones.SelectedValue)
            Dim item As Object
            item = cmbSimulaciones.SelectedItem
            If item("ProcSimMae_Estatus").ToString = "0" Then
                btnPasar.Enabled = False
                btnReordenar.Enabled = False
                btnGuardarOrden.Enabled = False
            Else
                btnPasar.Enabled = True
                btnReordenar.Enabled = True
                btnGuardarOrden.Enabled = True
            End If
        Else
            grdOrdenClasificacion.DataSource = Nothing
        End If
    End Sub

    Private Sub chkTodoClientesTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodoClientesTodos.CheckedChanged
        For Each rowGrd As UltraGridRow In grdClientesTodos.Rows.GetFilteredInNonGroupByRows
            rowGrd.Cells("SEL").Value = chkTodoClientesTodos.Checked
        Next
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnPasar_Click(sender As Object, e As EventArgs) Handles btnPasar.Click
        If cmbClasificacion.SelectedIndex > 0 Then
            Dim objMs As New Tools.ConfirmarForm
            objMs.mensaje = "¿Está seguro de cambiar la configuración de los clientes seleccionados?"
            If objMs.ShowDialog = Windows.Forms.DialogResult.OK Then
                editarClasificacionCliente()
            End If
        Else
            Dim objMsjA As New Tools.AdvertenciaForm
            objMsjA.mensaje = "Seleccione una clasificación"
            objMsjA.ShowDialog()
        End If
    End Sub

    Private Sub btnReordenar_Click(sender As Object, e As EventArgs) Handles btnReordenar.Click
        If cmbClasificacion.SelectedIndex > 0 Then
            Dim objMs As New Tools.ConfirmarForm
            objMs.mensaje = "¿Está seguro de cambiar el ordenamiento de ranking de los clientes seleccionados?"
            If objMs.ShowDialog = Windows.Forms.DialogResult.OK Then
                reordenarRankingClientesConf()
            End If
        Else
            Dim objMsjA As New Tools.AdvertenciaForm
            objMsjA.mensaje = "Seleccione una clasificación"
            objMsjA.ShowDialog()
        End If
    End Sub

    Private Sub grdClientesTodos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientesTodos.InitializeLayout

    End Sub

    Private Sub grdClientesMovimiento_DragDrop(sender As Object, e As DragEventArgs) Handles grdClientesMovimiento.DragDrop
        Dim dropIndex As Integer = 0
        Dim uieOver As UIElement = grdClientesMovimiento.DisplayLayout.UIElement.ElementFromPoint(grdClientesMovimiento.PointToClient(New Point(e.X, e.Y)))
        Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

        If ugrOver IsNot Nothing Then
            dropIndex = ugrOver.Index
            If dropIndex = -1 Then
                dropIndex = 0
            End If
            Dim SelRows As SelectedRowsCollection = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)

            For Each aRow As UltraGridRow In SelRows
                grdClientesMovimiento.Rows.Move(aRow, dropIndex)
            Next

            Dim nOrden As Int32 = 1
            For Each fila As UltraGridRow In grdClientesMovimiento.Rows
                If fila.IsFilterRow = False Then
                    fila.Cells("sirc_Ranking").Value = nOrden
                    nOrden += 1
                End If
            Next

        End If
    End Sub

    Private Sub grdClientesMovimiento_DragOver(sender As Object, e As DragEventArgs) Handles grdClientesMovimiento.DragOver
        e.Effect = DragDropEffects.Move
        Dim grid As UltraGrid = TryCast(sender, UltraGrid)
        Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

        If pointInGridCoords.Y < 20 Then
            Me.grdClientesMovimiento.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
        ElseIf pointInGridCoords.Y > grid.Height - 20 Then
            Me.grdClientesMovimiento.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
        End If
    End Sub

    Private Sub grdClientesMovimiento_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientesMovimiento.InitializeLayout

    End Sub

    Private Sub btnGuardarOrden_Click(sender As Object, e As EventArgs) Handles btnGuardarOrden.Click
        If cmbClasificacion.SelectedIndex > 0 Then
            Dim objMs As New Tools.ConfirmarForm
            objMs.mensaje = "¿Está seguro de cambiar el ordenamiento de ranking de la clasificación " + cmbClasificacion.SelectedItem(1) + "?"
            If objMs.ShowDialog = Windows.Forms.DialogResult.OK Then
                editarOrdenPorClasificacion()
            End If
        Else
            Dim objMsjA As New Tools.AdvertenciaForm
            objMsjA.mensaje = "Seleccione una clasificación"
            objMsjA.ShowDialog()
        End If

    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grpBotones.Height = 42
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grpBotones.Height = 78
    End Sub

    Private Sub grdClientesMovimiento_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdClientesMovimiento.SelectionDrag
        grdClientesMovimiento.DoDragDrop(grdClientesMovimiento.Selected.Rows, DragDropEffects.Move)
    End Sub

    Private Sub btnCerrarDos_Click(sender As Object, e As EventArgs) Handles btnCerrarDos.Click
        Me.Close()
    End Sub

    Private Sub cmbClasificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClasificacion.SelectedIndexChanged
        If cmbClasificacion.SelectedIndex > 0 Then
            If CInt(lblIdSimulacion.Text) > 0 Then
                llenarTablaClientesTodos(lblIdSimulacion.Text)
                llenarTablaConfigurados(lblIdSimulacion.Text)
            Else
                grdClientesTodos.DataSource = Nothing
                grdClientesMovimiento.DataSource = Nothing
            End If
        Else
            grdClientesTodos.DataSource = Nothing
            grdClientesMovimiento.DataSource = Nothing
        End If
    End Sub
End Class