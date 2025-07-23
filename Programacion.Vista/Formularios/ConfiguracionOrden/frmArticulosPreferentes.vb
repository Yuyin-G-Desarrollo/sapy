Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmArticulosPreferentes

    Public Sub guardarOrdenArtsPreferentes()
        Dim objBU As New Negocios.ArticulosPreferentesBU
        For Each rowGrd As UltraGridRow In grdProductosPreferentes.Rows
            objBU.editarOrdenArticulo(rowGrd.Cells("ID").Value, rowGrd.Cells("arpr_orden").Value)
        Next
    End Sub

    Public Sub llenarGridConfiguracionesAnteriores()
        Dim objBU As New Negocios.ArticulosPreferentesBU
        Dim dt As New DataTable

        If cmbSimulaciones.SelectedIndex > 0 Then
            dt = objBU.verArticulosPreferentesSimulacion(cmbSimulaciones.SelectedValue)
            If dt.Rows.Count > 0 Then
                grdArticulosPreferentesSimulaciones.DataSource = dt
                disenioGidPreferentesAnteriores()
            Else
                grdArticulosPreferentesSimulaciones.DataSource = Nothing
            End If
        Else
            grdArticulosPreferentesSimulaciones.DataSource = Nothing
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

    Public Sub quitarArticuloPreferente()
        Dim objBU As New Negocios.ArticulosPreferentesBU
        Dim guardo As Boolean = False
        For Each rowgrd As UltraGridRow In grdProductosPreferentes.Rows
            If rowgrd.Cells("SEL").Value = True Then
                objBU.inactivarArticuloPreferente(rowgrd.Cells("ID").Value)
                guardo = True
            End If
        Next

        Dim i As Int32 = 1
        For Each rowGrd As UltraGridRow In grdProductosPreferentes.Rows
            rowGrd.Cells("arpr_orden").Value = i
            i += 1
        Next
        guardarOrdenArtsPreferentes()

        If guardo = True Then
            llenarTablasArticulos()
            Dim objMensajeE As New Tools.ExitoForm
            objMensajeE.mensaje = "Registro exitoso"
            objMensajeE.ShowDialog()
        Else
            Dim objMensajeA As New Tools.AdvertenciaForm
            objMensajeA.mensaje = "No se quitaron artículos de la lista"
            objMensajeA.ShowDialog()
        End If

    End Sub

    Public Sub guardarArticuloPreferente()
        Dim objBU As New Negocios.ArticulosPreferentesBU
        Dim guardo As Boolean = False
        For Each rowgrd As UltraGridRow In grdProductosTodos.Rows
            If rowgrd.Cells("SEL").Value = True Then
                objBU.guardarArticulosPreferentes(rowgrd.Cells("pstilo").Value, lblIdSimulacion.Text)
                guardo = True
            End If
        Next
        If guardo = True Then
            llenarTablasArticulos()
            Dim objMensajeE As New Tools.ExitoForm
            objMensajeE.mensaje = "Registro exitoso"
            objMensajeE.ShowDialog()
        Else
            Dim objMensajeA As New Tools.AdvertenciaForm
            objMensajeA.mensaje = "No se agregaron artículos a la lista"
            objMensajeA.ShowDialog()
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

            llenarTablasArticulos()

        End If

    End Sub

    Public Sub llenarTablasArticulos()
        Dim objBUArts As New Negocios.ArticulosPreferentesBU
        Dim dtArtsDisponibles As New DataTable
        Dim dtArtsPreferentes As New DataTable
        dtArtsDisponibles = objBUArts.verArticulosDisponibles(lblIdSimulacion.Text)

        If dtArtsDisponibles.Rows.Count > 0 Then
            grdProductosTodos.DataSource = dtArtsDisponibles
            disenioGidDisponibles()
        Else
            grdProductosTodos.DataSource = Nothing
        End If

        dtArtsPreferentes = objBUArts.verArticulosPreferentes(lblIdSimulacion.Text)

        If dtArtsPreferentes.Rows.Count > 0 Then
            grdProductosPreferentes.DataSource = dtArtsPreferentes
            disenioGidPreferentes()
        Else
            grdProductosPreferentes.DataSource = Nothing
        End If
    End Sub

    Public Sub disenioGidDisponibles()
        Dim bandA As UltraGridBand = Me.grdProductosTodos.DisplayLayout.Bands(0)
        With bandA

            .Columns("prod_productoid").Hidden = True
            .Columns("pstilo").Hidden = True
            .Columns("Sicy").Hidden = True
            .Columns("sicyPCOL").Hidden = True
            .Columns("psEstatus").Hidden = True

            .Columns("prod_codigo").CellActivation = Activation.NoEdit
            .Columns("modeloSICY").CellActivation = Activation.NoEdit
            .Columns("Descripcion").CellActivation = Activation.NoEdit
            .Columns("nomSts").CellActivation = Activation.NoEdit

            .Columns("SEL").Header.Caption = ""
            .Columns("prod_codigo").Header.Caption = "SAY"
            .Columns("modeloSICY").Header.Caption = "SICY"
            .Columns("Descripcion").Header.Caption = "Artículo"
            .Columns("nomSts").Header.Caption = "Estatus"

        End With

        grdProductosTodos.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        'grdProductosTodos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdProductosTodos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdProductosTodos.DisplayLayout.Override.RowSelectorWidth = 35
        grdProductosTodos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdProductosTodos.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        bandA.Columns("Descripcion").Width = 250
    End Sub

    Public Sub disenioGidPreferentes()
        Dim bandA As UltraGridBand = Me.grdProductosPreferentes.DisplayLayout.Bands(0)
        With bandA

            .Columns("prod_productoid").Hidden = True
            .Columns("pstilo").Hidden = True
            .Columns("Sicy").Hidden = True
            .Columns("sicyPCOL").Hidden = True
            .Columns("psEstatus").Hidden = True
            .Columns("ID").Hidden = True

            .Columns("prod_codigo").CellActivation = Activation.NoEdit
            .Columns("modeloSICY").CellActivation = Activation.NoEdit
            .Columns("Descripcion").CellActivation = Activation.NoEdit
            .Columns("nomSts").CellActivation = Activation.NoEdit
            .Columns("arpr_orden").CellActivation = Activation.NoEdit

            .Columns("prod_codigo").Header.Caption = "SAY"
            .Columns("modeloSICY").Header.Caption = "SICY"
            .Columns("Descripcion").Header.Caption = "Artículo"
            .Columns("nomSts").Header.Caption = "Estatus"
            .Columns("arpr_orden").Header.Caption = "Orden"
            .Columns("SEL").Header.Caption = ""

            '.Columns("cesp_orden").CellAppearance.TextHAlign = HAlign.Right
        End With

        grdProductosPreferentes.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        'grdProductosPreferentes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdProductosPreferentes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdProductosPreferentes.DisplayLayout.Override.RowSelectorWidth = 35
        grdProductosPreferentes.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdProductosPreferentes.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        bandA.Columns("Descripcion").Width = 250
        grdProductosPreferentes.DisplayLayout.Override.SelectTypeRow = SelectType.SingleAutoDrag
        grdProductosPreferentes.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdProductosPreferentes.AllowDrop = True
    End Sub

    Public Sub disenioGidPreferentesAnteriores()
        Dim bandA As UltraGridBand = Me.grdArticulosPreferentesSimulaciones.DisplayLayout.Bands(0)
        With bandA

            .Columns("prod_productoid").Hidden = True
            .Columns("pstilo").Hidden = True
            .Columns("Sicy").Hidden = True
            .Columns("sicyPCOL").Hidden = True
            .Columns("psEstatus").Hidden = True

            .Columns("prod_codigo").CellActivation = Activation.NoEdit
            .Columns("modeloSICY").CellActivation = Activation.NoEdit
            .Columns("Descripcion").CellActivation = Activation.NoEdit
            .Columns("nomSts").CellActivation = Activation.NoEdit
            .Columns("arpr_orden").CellActivation = Activation.NoEdit

            .Columns("prod_codigo").Header.Caption = "SAY"
            .Columns("modeloSICY").Header.Caption = "SICY"
            .Columns("Descripcion").Header.Caption = "Artículo"
            .Columns("nomSts").Header.Caption = "Estatus"
            .Columns("arpr_orden").Header.Caption = "Orden"
            '.Columns("SEL").Header.Caption = ""
            '.Columns("cesp_orden").CellAppearance.TextHAlign = HAlign.Right
        End With

        grdArticulosPreferentesSimulaciones.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdArticulosPreferentesSimulaciones.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdArticulosPreferentesSimulaciones.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdArticulosPreferentesSimulaciones.DisplayLayout.Override.RowSelectorWidth = 35
        grdArticulosPreferentesSimulaciones.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdArticulosPreferentesSimulaciones.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        bandA.Columns("Descripcion").Width = 250
        grdArticulosPreferentesSimulaciones.DisplayLayout.Override.SelectTypeRow = SelectType.SingleAutoDrag
        grdArticulosPreferentesSimulaciones.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdArticulosPreferentesSimulaciones.AllowDrop = True
    End Sub

    Private Sub btnGuardarCambiosOrden_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub frmArticulosPreferentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0

        llenarComboSimulaciones()
        llenarDatosSimulacionActual()

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

    Private Sub cmbSimulaciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSimulaciones.SelectedIndexChanged
        llenarGridConfiguracionesAnteriores()
    End Sub

    Private Sub grdProductosPreferentes_DragDrop(sender As Object, e As DragEventArgs) Handles grdProductosPreferentes.DragDrop
        Dim dropIndex As Integer = 0
        Dim uieOver As UIElement = grdProductosPreferentes.DisplayLayout.UIElement.ElementFromPoint(grdProductosPreferentes.PointToClient(New Point(e.X, e.Y)))
        Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

        If ugrOver IsNot Nothing Then
            dropIndex = ugrOver.Index
            If dropIndex = -1 Then
                dropIndex = 0
            End If
            Dim SelRows As SelectedRowsCollection = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)

            For Each aRow As UltraGridRow In SelRows
                grdProductosPreferentes.Rows.Move(aRow, dropIndex)
            Next

            Dim nOrden As Int32 = 1
            For Each fila As UltraGridRow In grdProductosPreferentes.Rows
                fila.Cells("arpr_orden").Value = nOrden
                nOrden += 1
            Next
        End If
    End Sub

    Private Sub grdProductosPreferentes_DragOver(sender As Object, e As DragEventArgs) Handles grdProductosPreferentes.DragOver
        e.Effect = DragDropEffects.Move
        Dim grid As UltraGrid = TryCast(sender, UltraGrid)
        Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

        If pointInGridCoords.Y < 20 Then
            Me.grdProductosPreferentes.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
        ElseIf pointInGridCoords.Y > grid.Height - 20 Then
            Me.grdProductosPreferentes.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
        End If
    End Sub

    Private Sub grdProductosPreferentes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdProductosPreferentes.InitializeLayout

    End Sub

    Private Sub grdProductosPreferentes_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdProductosPreferentes.SelectionDrag
        grdProductosPreferentes.DoDragDrop(grdProductosPreferentes.Selected.Rows, DragDropEffects.Move)
    End Sub

    Private Sub btnPasar_Click(sender As Object, e As EventArgs) Handles btnPasar.Click
        Dim objMensaje As New Tools.ConfirmarForm
        objMensaje.mensaje = "¿Está seguro de convertir los artículos seleccionados en artículos preferentes?"
        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
            guardarArticuloPreferente()
        End If
    End Sub

    Private Sub btnOrdenar_Click(sender As Object, e As EventArgs) Handles btnOrdenar.Click
        Dim objMsj As New Tools.ConfirmarForm
        objMsj.mensaje = "¿Está seguro de guardar el ordenamiento?"
        If objMsj.ShowDialog = Windows.Forms.DialogResult.OK Then
            guardarOrdenArtsPreferentes()
            Dim objMensaje As New Tools.ExitoForm
            objMensaje.mensaje = "Registro exitoso"
            objMensaje.ShowDialog()
        End If
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        Dim objMensaje As New Tools.ConfirmarForm
        objMensaje.mensaje = "¿Está seguro de quitar los artículos seleccionados de los artículos preferentes?"
        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
            quitarArticuloPreferente()
           
        End If
    End Sub

    Private Sub chkSeleccionaTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionaTodo.CheckedChanged
        For Each rowgrd As UltraGridRow In grdProductosTodos.Rows.GetFilteredInNonGroupByRows
            rowgrd.Cells("SEL").Value = chkSeleccionaTodo.Checked
        Next
    End Sub

    Private Sub chkSeleccionarTodoPreferentes_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodoPreferentes.CheckedChanged
        For Each rowgrd As UltraGridRow In grdProductosPreferentes.Rows.GetFilteredInNonGroupByRows
            rowgrd.Cells("SEL").Value = chkSeleccionarTodoPreferentes.Checked
        Next
    End Sub
End Class