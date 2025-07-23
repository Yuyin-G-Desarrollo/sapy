Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmNavesOrden

    Public Sub editarOrdenNaves()
        Dim objBU As New Negocios.OrdenNaveAuxBU
        For Each rowGrd As UltraGridRow In grdOrdenNavesActual.Rows
            objBU.editarOrdenSimulacion(rowGrd.Cells("onax_ordenNaveAuxId").Value, rowGrd.Cells("onax_orden").Value)
        Next
        Dim objMensajeE As New Tools.ExitoForm
        objMensajeE.mensaje = "Registro exitoso"
        objMensajeE.ShowDialog()
    End Sub

    Public Sub llenarTablaOrdenNavesAnterior()
        Dim objBU As New Negocios.OrdenNaveAuxBU
        Dim dt As New DataTable

        If cmbSimulaciones.SelectedIndex > 0 Then
            dt = objBU.consultaOrdenNavesSImulacion(cmbSimulaciones.SelectedValue)
            If dt.Rows.Count > 0 Then
                grdOrdenNavesAnt.DataSource = dt
                disenioGidAnterior()
            Else
                grdOrdenNavesAnt.DataSource = Nothing
            End If
        Else
            grdOrdenNavesAnt.DataSource = Nothing
        End If
    End Sub

    Public Sub llenarTablaOrdenNavesActual()
        Dim objBU As New Negocios.OrdenNaveAuxBU
        Dim dt As New DataTable
        dt = objBU.consultaOrdenNavesSImulacion(lblIdSimulacion.Text)

        If dt.Rows.Count > 0 Then
            grdOrdenNavesActual.DataSource = dt
            disenioGidDisponibles()
        Else
            grdOrdenNavesActual.DataSource = Nothing
        End If

    End Sub

    Public Sub disenioGidDisponibles()

        Dim bandA As UltraGridBand = Me.grdOrdenNavesActual.DisplayLayout.Bands(0)
        With bandA

            .Columns("onax_ordenNaveAuxId").Hidden = True
            .Columns("onax_naveAuxId").Hidden = True

            .Columns("nave_nombre").CellActivation = Activation.NoEdit
            .Columns("nave_orden").CellActivation = Activation.NoEdit
            .Columns("onax_orden").CellActivation = Activation.NoEdit

            .Columns("nave_nombre").Header.Caption = "Nave"
            .Columns("nave_orden").Header.Caption = "Orden Original"
            .Columns("onax_orden").Header.Caption = "Orden Configurado"

        End With

        grdOrdenNavesActual.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdOrdenNavesActual.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdOrdenNavesActual.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdOrdenNavesActual.DisplayLayout.Override.RowSelectorWidth = 35
        grdOrdenNavesActual.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdOrdenNavesActual.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True
        bandA.Columns("nave_orden").Width = 50
        bandA.Columns("onax_orden").Width = 50
        bandA.Columns("nave_orden").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        bandA.Columns("onax_orden").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grdOrdenNavesActual.DisplayLayout.Override.SelectTypeRow = SelectType.SingleAutoDrag
        grdOrdenNavesActual.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdOrdenNavesActual.AllowDrop = True
    End Sub

    Public Sub disenioGidAnterior()

        Dim bandA As UltraGridBand = Me.grdOrdenNavesAnt.DisplayLayout.Bands(0)
        With bandA

            .Columns("onax_ordenNaveAuxId").Hidden = True
            .Columns("onax_naveAuxId").Hidden = True

            .Columns("nave_nombre").CellActivation = Activation.NoEdit
            .Columns("nave_orden").CellActivation = Activation.NoEdit
            .Columns("onax_orden").CellActivation = Activation.NoEdit

            .Columns("nave_nombre").Header.Caption = "Nave"
            .Columns("nave_orden").Header.Caption = "Orden Original"
            .Columns("onax_orden").Header.Caption = "Orden Configurado"

        End With

        grdOrdenNavesAnt.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdOrdenNavesAnt.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdOrdenNavesAnt.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdOrdenNavesAnt.DisplayLayout.Override.RowSelectorWidth = 35
        grdOrdenNavesAnt.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdOrdenNavesAnt.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True
        bandA.Columns("nave_orden").Width = 50
        bandA.Columns("onax_orden").Width = 50
        bandA.Columns("nave_orden").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        bandA.Columns("onax_orden").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
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

    Public Sub llenarDatosSimulacionActual()
        Dim objBU As New Negocios.SimulacionBU
        Dim dtDatosUltimaConf As New DataTable
        Dim objBUArts As New Negocios.ArticulosPreferentesBU


        dtDatosUltimaConf = objBU.consultaDatosUltimaConfiguracion

        If dtDatosUltimaConf.Rows.Count > 0 Then
            lblNombreSimulacion.Text = dtDatosUltimaConf.Rows(0).Item("ProcSimMae_Descripcion").ToString.Trim
            lblIdSimulacion.Text = dtDatosUltimaConf.Rows(0).Item("ProcSimMae_ProcSimuladorID").ToString


        End If

    End Sub

    Private Sub frmNavesOrden_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        llenarComboSimulaciones()
        llenarDatosSimulacionActual()
        llenarTablaOrdenNavesActual()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grpBotones.Height = 40
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grpBotones.Height = 78
    End Sub

    Private Sub btnUPSM_Click(sender As Object, e As EventArgs) Handles btnUPSM.Click
        grpSimulacionesAnt.Height = 40
    End Sub

    Private Sub btnDownSM_Click(sender As Object, e As EventArgs) Handles btnDownSM.Click
        grpSimulacionesAnt.Height = 78
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub btnOrdenar_Click(sender As Object, e As EventArgs) Handles btnOrdenar.Click
        Dim objMsjConf As New Tools.ConfirmarForm
        objMsjConf.mensaje = "¿Está seguro de cambiar el ordenamiento?"
        If objMsjConf.ShowDialog = Windows.Forms.DialogResult.OK Then
            editarOrdenNaves()
        End If
    End Sub

    Private Sub grdOrdenNavesActual_DragDrop(sender As Object, e As DragEventArgs) Handles grdOrdenNavesActual.DragDrop
        Dim dropIndex As Integer = 0
        Dim uieOver As UIElement = grdOrdenNavesActual.DisplayLayout.UIElement.ElementFromPoint(grdOrdenNavesActual.PointToClient(New Point(e.X, e.Y)))
        Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

        If ugrOver IsNot Nothing Then
            dropIndex = ugrOver.Index
            If dropIndex = -1 Then
                dropIndex = 0
            End If
            Dim SelRows As SelectedRowsCollection = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)

            For Each aRow As UltraGridRow In SelRows
                grdOrdenNavesActual.Rows.Move(aRow, dropIndex)
            Next

            Dim nOrden As Int32 = 1
            For Each fila As UltraGridRow In grdOrdenNavesActual.Rows
                fila.Cells("onax_orden").Value = nOrden
                nOrden += 1
            Next
        End If
    End Sub

    Private Sub grdOrdenNavesActual_DragOver(sender As Object, e As DragEventArgs) Handles grdOrdenNavesActual.DragOver
        e.Effect = DragDropEffects.Move
        Dim grid As UltraGrid = TryCast(sender, UltraGrid)
        Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

        If pointInGridCoords.Y < 20 Then
            Me.grdOrdenNavesActual.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
        ElseIf pointInGridCoords.Y > grid.Height - 20 Then
            Me.grdOrdenNavesActual.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
        End If
    End Sub

    Private Sub grdOrdenNavesActual_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdOrdenNavesActual.InitializeLayout

    End Sub

    Private Sub grdOrdenNavesActual_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdOrdenNavesActual.SelectionDrag
        grdOrdenNavesActual.DoDragDrop(grdOrdenNavesActual.Selected.Rows, DragDropEffects.Move)
    End Sub

    Private Sub cmbSimulaciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSimulaciones.SelectedIndexChanged
        llenarTablaOrdenNavesAnterior()
    End Sub
End Class