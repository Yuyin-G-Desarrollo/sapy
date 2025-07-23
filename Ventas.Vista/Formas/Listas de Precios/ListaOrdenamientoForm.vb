Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class ListaOrdenamientoForm

    Public Sub llenarTablaMarca()
        Dim objMarca As New Programacion.Negocios.MarcasBU
        Dim dtDatosMarc As New DataTable
        dtDatosMarc = objMarca.verMarcasRapido("")
        grdDatosCargados.DataSource = dtDatosMarc

        Me.grdDatosCargados.DisplayLayout.Bands(0).Columns.Add("posicion", "posicion")

        With grdDatosCargados.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(3).Hidden = True
            .Columns(1).CellActivation = Activation.NoEdit
            .Columns(2).CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdDatosCargados.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        'Dim posicion As UltraGridColumn = grdDatosCargados.DisplayLayout.Bands(0).Columns("posicion")
    End Sub

    Public Sub llenarTablaColeccion()
        Dim objCole As New Programacion.Negocios.ColeccionBU
        Dim dtDatosCole As New DataTable
        dtDatosCole = objCole.verComboColeccion("")
        grdDatosCargados.DataSource = dtDatosCole

        Me.grdDatosCargados.DisplayLayout.Bands(0).Columns.Add("posicion", "posicion")
        'Dim posicion As UltraGridColumn = grdDatosCargados.DisplayLayout.Bands(0).Columns("posicion")

        With grdDatosCargados.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Header.Caption = "Colección"
            .Columns(1).CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdDatosCargados.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Public Sub llenarTablaFamilias()
        Dim objFam As New Programacion.Negocios.FamiliasBU
        Dim dtDatosFam As New DataTable
        dtDatosFam = objFam.ListarFamilias("", "", True)
        grdDatosCargados.DataSource = dtDatosFam

        Me.grdDatosCargados.DisplayLayout.Bands(0).Columns.Add("posicion", "posicion")
        'Dim posicion As UltraGridColumn = grdDatosCargados.DisplayLayout.Bands(0).Columns("posicion")

        With grdDatosCargados.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(3).Hidden = True
            .Columns(1).CellActivation = Activation.NoEdit
            .Columns(2).CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdDatosCargados.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub ListaOrdenamientoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'grdDatosCargados.AllowDrop = True
    End Sub

    Private Sub btnGenerarReporte_Click(sender As Object, e As EventArgs) Handles btnGenerarReporte.Click
        Dim contFilas As Int32 = 0
        Dim contPos As Int32 = 1
        contFilas = grdDatosCargados.Rows.Count

        For Each row As UltraGridRow In grdDatosCargados.Rows
            row.Cells("posicion").Value = contPos
            contPos = contPos + 1
        Next

        Dim objVPREP As New VistaPreviaReporte
        objVPREP.ShowDialog()


    End Sub

    Private Sub rdoMarca_CheckedChanged(sender As Object, e As EventArgs) Handles rdoMarca.CheckedChanged
        grdDatosCargados.DataSource = Nothing
        llenarTablaMarca()
    End Sub

    Private Sub rdoColeccion_CheckedChanged(sender As Object, e As EventArgs) Handles rdoColeccion.CheckedChanged
        grdDatosCargados.DataSource = Nothing
        llenarTablaColeccion()
    End Sub

    Private Sub rdoFamilia_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFamilia.CheckedChanged
        grdDatosCargados.DataSource = Nothing
        llenarTablaFamilias()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSinOrden.CheckedChanged
        grdDatosCargados.DataSource = Nothing
    End Sub


    Private Sub grdDatosCargados_DragDrop(sender As Object, e As DragEventArgs) Handles grdDatosCargados.DragDrop
        Dim dropIndex As Integer
        'Get the position on the grid where the dragged row(s) are to be dropped. 
        'get the grid coordinates of the row (the drop zone) 
        Dim uieOver As UIElement = grdDatosCargados.DisplayLayout.UIElement.ElementFromPoint(grdDatosCargados.PointToClient(New Point(e.X, e.Y)))

        'get the row that is the drop zone/or where the dragged row is to be dropped 
        Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

        If ugrOver IsNot Nothing Then
            dropIndex = ugrOver.Index    'index/position of drop zone in grid 

            'get the dragged row(s)which are to be dragged to another position in the grid 
            Dim SelRows As SelectedRowsCollection = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)
            'get the count of selected rows and drop each starting at the dropIndex 
            For Each aRow As UltraGridRow In SelRows
                'move the selected row(s) to the drop zone 
                grdDatosCargados.Rows.Move(aRow, dropIndex)
            Next
        End If
    End Sub

    Private Sub grdDatosCargados_DragOver(sender As Object, e As DragEventArgs) Handles grdDatosCargados.DragOver
        e.Effect = DragDropEffects.Move
        Dim grid As UltraGrid = TryCast(sender, UltraGrid)
        Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

        If pointInGridCoords.Y < 20 Then
            'Scroll up
            Me.grdDatosCargados.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
        ElseIf pointInGridCoords.Y > grid.Height - 20 Then
            'Scroll down
            Me.grdDatosCargados.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
        End If
    End Sub

    Private Sub grdDatosCargados_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdDatosCargados.SelectionDrag
        grdDatosCargados.DoDragDrop(grdDatosCargados.Selected.Rows, DragDropEffects.Move)
    End Sub
End Class