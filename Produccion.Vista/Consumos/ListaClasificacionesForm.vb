Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Produccion.Negocios

Public Class ListaClasificacionesForm
    Public idClasificacion As Integer = 0
    Public Clasificacion As String = ""
    Dim contador = 0
    Public idcomponente = 0

    Public listaClasificaciones As List(Of Integer)

    Private Sub ListaClasificacionesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            obtenerClasificaciones()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub obtenerClasificaciones()
        Dim obj As New catalagosBU
        Dim ListaClasificaciones As New DataTable
        ListaClasificaciones = obj.listaClasificacionesComponentes(idcomponente)
        grdClasificaciones.DataSource = ListaClasificaciones
        disenioGrid()
    End Sub

    Public Sub disenioGrid()
        With grdClasificaciones.DisplayLayout.Bands(0)

            '.Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            '.Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            '.Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            '.Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("ID").CellActivation = Activation.NoEdit
            .Columns("Clasificación").CellActivation = Activation.NoEdit
            .Columns("ID").CellAppearance.TextHAlign = HAlign.Right
            '.Columns(" ").Width = 15
            .Columns("ID").Width = 20
            .Columns("Clasificación").Width = 200
        End With
        grdClasificaciones.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub grdComponente_DoubleClick(sender As Object, e As EventArgs) Handles grdClasificaciones.DoubleClick
        Try
            If grdClasificaciones.ActiveCell.Column.ToString = "ID" Or grdClasificaciones.ActiveCell.Column.ToString = "Clasificación" Then
                idClasificacion = grdClasificaciones.ActiveRow.Cells("ID").Value
                Clasificacion = grdClasificaciones.ActiveRow.Cells("Clasificación").Value
                Me.Close()
            End If
            
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub grdClasificaciones_KeyUp(sender As Object, e As KeyEventArgs) Handles grdClasificaciones.KeyUp
        Dim valor = 0
        valor = e.KeyValue

        Dim renglon As Integer = 0
        renglon = grdClasificaciones.Rows.Count
        If valor = 40 Then 'abajo
            If contador = 0 Then
                grdClasificaciones.Rows(0).Cells("Clasificación").Selected = True
                contador = contador + 1
            End If
        ElseIf valor = 38 Then 'arriba
            If contador = 0 Then
                grdClasificaciones.Rows(0).Cells("Clasificación").Selected = True
                contador = contador + 1
            End If
        ElseIf valor = 13 Then
            Try
                idClasificacion = grdClasificaciones.ActiveRow.Cells("ID").Value
                Clasificacion = grdClasificaciones.ActiveRow.Cells("Clasificación").Value
                Me.Close()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub grdClasificaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles grdClasificaciones.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Up Then
                grdClasificaciones.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdClasificaciones.DisplayLayout.Bands(0)
                If grdClasificaciones.ActiveRow.HasPrevSibling(True) Then
                    Dim nextRow As UltraGridRow = grdClasificaciones.ActiveRow.GetSibling(SiblingRow.Previous, True)
                    grdClasificaciones.ActiveCell = nextRow.Cells(grdClasificaciones.ActiveCell.Column)
                    e.Handled = True
                    grdClasificaciones.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Down Then
                grdClasificaciones.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdClasificaciones.DisplayLayout.Bands(0)
                If grdClasificaciones.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdClasificaciones.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdClasificaciones.ActiveCell = nextRow.Cells(grdClasificaciones.ActiveCell.Column)
                    e.Handled = True
                    grdClasificaciones.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ListaClasificacionesForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
End Class