Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class PrioridadClientesApartadosForm

    Dim ordenamientoRenglones As String = ""

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub PrioridadClientesApartadosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        cargarDatos()
    End Sub

    Private Sub gridClientesDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.Bands(0).Columns("ClienteID").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Bloqueado").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("BloqueadoTresMeses").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Seleccionar").Hidden = True


        grid.DisplayLayout.Bands(0).Columns("Seleccionar").Header.Caption = ""
        grid.DisplayLayout.Bands(0).Columns("Prioridad").Header.Caption = "Prioridad"
        grid.DisplayLayout.Bands(0).Columns("Prioridad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Prioridad").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Prioridad").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("*Nueva Prioridad").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("*Nueva Prioridad").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Ranking").Header.Caption = "Ranking"
        grid.DisplayLayout.Bands(0).Columns("Ranking").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Ranking").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Ranking").Format = "n0"

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        'grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        'grid.DisplayLayout.GroupByBox.Hidden = False
        'grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"


        grid.DisplayLayout.Bands(0).Columns("seleccionar").Width = 20


        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        For Each renglon As UltraGridRow In grdPrioridadClientes.Rows
            If renglon.Cells("BloqueadoTresMeses").Value.ToString() = "SI" Then
                renglon.Appearance.ForeColor = pnlClienteBloqueadoAnteriormente.BackColor
            End If
            If renglon.Cells("Bloqueado").Value.ToString() = "SI" Then
                renglon.Appearance.ForeColor = pnlClienteBloqueado.BackColor
            End If
        Next

        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If


        grid.DisplayLayout.Bands(0).Columns("*Nueva Prioridad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit

        grid.DisplayLayout.Bands(0).Columns("Seleccionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit

    End Sub


    Private Sub grdPrioridadClientes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdPrioridadClientes.KeyPress
        If grdPrioridadClientes.ActiveRow.IsFilterRow = False Then
            If IsNumeric(e.KeyChar) = False And e.KeyChar <> Convert.ToChar(Keys.Back) Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim ventanaConfirmacion As New Tools.ConfirmarForm
        Dim Clientes As String = String.Empty
        Dim Prioridad As String = String.Empty
        Dim ObjBU As New Negocios.ApartadosBU
        Dim dtResultado As New DataTable
        ventanaConfirmacion.mensaje = "¿Está seguro de reasignar las prioridades de los clientes en Apartados? (Una vez realizada esta acción no se podrá revertir)"
        If ventanaConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
            btnReordenar_Click(sender, e)
            For Each renglon As UltraGridRow In grdPrioridadClientes.Rows
                If Clientes <> "" Then
                    Clientes += ","
                End If
                Clientes += renglon.Cells("ClienteID").Value.ToString()
                If Prioridad <> "" Then
                    Prioridad += ","
                End If
                Prioridad += renglon.Cells("*Nueva Prioridad").Value.ToString()
            Next
            dtResultado = ObjBU.modificarPrioridadesClientesApartar(Clientes, Prioridad, 1)
            show_message(dtResultado.Rows(0).Item("tipoResultado"), dtResultado.Rows(0).Item("mensajeResultado"))
            cargarDatos()
        End If
    End Sub

    Private Sub grdPrioridadClientes_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdPrioridadClientes.SelectionDrag
        Dim contadorAsc As Integer = 1
        Dim contadorDesc As Integer = grdPrioridadClientes.Rows.Count()
        Dim renglonesIncorrectos As Integer = 0
        Dim mensajeAlerta As New Tools.AdvertenciaForm
        For Each renglon As UltraGridRow In grdPrioridadClientes.Rows
            If Integer.Parse(renglon.Cells("*Nueva Prioridad").Value.ToString()) <> contadorDesc And Integer.Parse(renglon.Cells("*Nueva Prioridad").Value.ToString()) <> contadorAsc Then
                renglonesIncorrectos += 1
            Else
                If Integer.Parse(renglon.Cells("*Nueva Prioridad").Value.ToString()) = contadorDesc Then
                    ordenamientoRenglones = "Desc"
                End If
                If Integer.Parse(renglon.Cells("*Nueva Prioridad").Value.ToString()) = contadorAsc Then
                    ordenamientoRenglones = "Asc"
                End If
            End If
            contadorAsc += 1
            contadorDesc -= 1
        Next
        If renglonesIncorrectos > 0 Then
            mensajeAlerta.mensaje = "La lista debe estar ordenada por Nueva Prioridad para poder arrastrar renglones."
            mensajeAlerta.ShowDialog()
        Else
            grdPrioridadClientes.DoDragDrop(grdPrioridadClientes.Selected.Rows, DragDropEffects.Move)
        End If
    End Sub

    Private Sub grdPrioridadClientes_DragOver(sender As Object, e As DragEventArgs) Handles grdPrioridadClientes.DragOver
        e.Effect = DragDropEffects.Move
        Dim grid As UltraGrid = TryCast(sender, UltraGrid)
        Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

        If pointInGridCoords.Y < 20 Then
            'Scroll up
            Me.grdPrioridadClientes.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
        ElseIf pointInGridCoords.Y > grid.Height - 20 Then
            'Scroll down
            Me.grdPrioridadClientes.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
        End If
    End Sub

    Private Sub grdPrioridadClientes_DragDrop(sender As Object, e As DragEventArgs) Handles grdPrioridadClientes.DragDrop
        Try
            Dim dropIndex As Integer

            'Get the position on the grid where the dragged row(s) are to be dropped. 
            'get the grid coordinates of the row (the drop zone) 
            Dim uieOver As UIElement = grdPrioridadClientes.DisplayLayout.UIElement.ElementFromPoint(grdPrioridadClientes.PointToClient(New Point(e.X, e.Y)))

            'get the row that is the drop zone/or where the dragged row is to be dropped 
            Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

            If ugrOver IsNot Nothing Then
                dropIndex = ugrOver.Index    'index/position of drop zone in grid 

                'get the dragged row(s)which are to be dragged to another position in the grid 
                Dim SelRows As SelectedRowsCollection = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)
                'get the count of selected rows and drop each starting at the dropIndex 
                For Each aRow As UltraGridRow In SelRows
                    'move the selected row(s) to the drop zone 
                    If dropIndex >= 0 And dropIndex <> aRow.Index Then
                        grdPrioridadClientes.Rows.Move(aRow, dropIndex)
                        reasignarPrioridades()
                    End If
                Next

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub reasignarPrioridades()
        Dim contador As Integer = 1
        If ordenamientoRenglones = "Asc" Then
            For Each renglon As UltraGridRow In grdPrioridadClientes.Rows
                renglon.Cells("*Nueva Prioridad").Value = contador
                contador += 1
            Next
        Else
            contador = grdPrioridadClientes.Rows.Count
            For Each renglon As UltraGridRow In grdPrioridadClientes.Rows
                renglon.Cells("*Nueva Prioridad").Value = contador
                contador -= 1
            Next
        End If
    End Sub

    Private Sub reordenarPrioridades()
        Dim tblClientes As New DataTable
        Dim contador As Integer = 1
        tblClientes = grdPrioridadClientes.DataSource
        Dim dvTblClientes As New DataView(tblClientes)
        dvTblClientes.Sort = "*Nueva Prioridad ASC, Nombre ASC"
        tblClientes = dvTblClientes.ToTable()
        For Each renglon As DataRow In tblClientes.Rows
            renglon.Item("*Nueva Prioridad") = contador
            contador += 1
        Next
        grdPrioridadClientes.DataSource = tblClientes
        gridClientesDiseño(grdPrioridadClientes)
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim ventanaConfirmacion As New Tools.ConfirmarForm
        ventanaConfirmacion.mensaje = "Todos los datos no guardados se perderán, ¿Desea continuar?"
        If ventanaConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
            cargarDatos()
        End If
    End Sub

    Private Sub cargarDatos()
        Dim objBU As New Ventas.Negocios.ApartadosBU
        Dim tblResultadoPrioridad As New DataTable

        tblResultadoPrioridad = objBU.consultaPrioridadClientesApartar()

        grdPrioridadClientes.DataSource = Nothing
        grdPrioridadClientes.DataSource = tblResultadoPrioridad
        gridClientesDiseño(grdPrioridadClientes)
    End Sub

    Private Sub btnReordenar_Click(sender As Object, e As EventArgs) Handles btnReordenar.Click
        reordenarPrioridades()
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then

            Dim mensajeAdvertencia As New AdvertenciaFormGrande
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