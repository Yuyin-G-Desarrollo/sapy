Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmFiltroArticulos

    Public idNave As String
    Public idNaveDestino As Int32
    Public verTodo As Boolean
    Public idSimulacion As Int32
    Public idLinea As Int32
    Public productosExcluir As String
    Public anioProducto As Int32
    Public dtArticulos As DataTable = Nothing

    Public Sub regresarDatos()
        dtArticulos = Nothing
        dtArticulos = New DataTable
        dtArticulos.Columns.Add("idProducto", Type.GetType("System.String"))
        dtArticulos.Columns.Add("idPEstilo", Type.GetType("System.String"))
        dtArticulos.Columns.Add("codigo", Type.GetType("System.String"))
        dtArticulos.Columns.Add("Descripcion", Type.GetType("System.String"))
        dtArticulos.Columns.Add("horma", Type.GetType("System.String"))
        dtArticulos.Columns.Add("talla", Type.GetType("System.String"))

        For Each rowGrd As UltraGridRow In grdArticulos.Rows
            If rowGrd.Cells("Sel").Value Then
                Dim row As DataRow = dtArticulos.NewRow
                row.Item("idProducto") = rowGrd.Cells("prod_productoid").Value.ToString
                row.Item("idPEstilo") = rowGrd.Cells("pstilo").Value.ToString
                row.Item("codigo") = rowGrd.Cells("codigo").Value.ToString
                row.Item("Descripcion") = rowGrd.Cells("Descripcion").Value.ToString
                row.Item("horma") = rowGrd.Cells("idHorma").Value.ToString
                row.Item("talla") = rowGrd.Cells("idTalla").Value.ToString
                dtArticulos.Rows.InsertAt(row, 0)
            End If
        Next
        Me.Close()
    End Sub

    Public Sub llenarTablaArticulos()
        Dim objBU As New Negocios.LineasProduccionBU
        Dim dt As New DataTable
        If verTodo = True Then
            dt = objBU.consultarArticulosLineaProduccion(idNave, productosExcluir, idSimulacion, idLinea, idNaveDestino, anioProducto)
        ElseIf idNave <> String.Empty Then
            dt = objBU.consultarArticulosLineaProduccion(idNave, productosExcluir, idSimulacion, idLinea, idNaveDestino, anioProducto)
        End If

        If dt.Rows.Count > 0 Then
            grdArticulos.DataSource = dt
            formatoGrid()
        End If
    End Sub

    Public Sub formatoGrid()
        Dim banda As UltraGridBand = grdArticulos.DisplayLayout.Bands(0)
        With banda
            .Columns("prod_productoid").Hidden = True
            .Columns("pstilo").Hidden = True
            .Columns("idHorma").Hidden = True
            .Columns("idTalla").Hidden = True
            .Columns("Sel").Header.Caption = ""
            .Columns("codigo").Header.Caption = "Código"
            .Columns("Descripcion").Header.Caption = "Descripción"
            .Columns("codigo").CellActivation = Activation.NoEdit
            .Columns("Descripcion").CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdArticulos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdArticulos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdArticulos.DisplayLayout.Override.RowSelectorWidth = 35
        grdArticulos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdArticulos.Rows(0).Selected = True

        grdArticulos.DisplayLayout.Override.SelectTypeRow = SelectType.SingleAutoDrag
        grdArticulos.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdArticulos.AllowDrop = True

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        regresarDatos()
    End Sub

    Private Sub frmFiltroArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarTablaArticulos()
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        For Each rowGrd As UltraGridRow In grdArticulos.Rows.GetFilteredInNonGroupByRows
            rowGrd.Cells("Sel").Value = chkSeleccionarTodo.Checked
        Next
    End Sub

    Private Sub grdArticulos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdArticulos.InitializeLayout

    End Sub
End Class