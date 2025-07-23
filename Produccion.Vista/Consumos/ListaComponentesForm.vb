Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaComponentesForm

    Public idComponente As Integer = 0
    Public Componente As String = ""

    Dim contador = 0

    Private Sub ListaComponentesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        obtenerComponentes()
    End Sub

    Public Sub obtenerComponentes()
        Dim obj As New ConsumosBU
        Dim listaComponentes As New DataTable
        listaComponentes = obj.listaComponente
        grdComponente.DataSource = listaComponentes
        disenioGrid()
    End Sub

    Public Sub disenioGrid()
        With grdComponente.DisplayLayout.Bands(0)
            .Columns("ID").CellActivation = Activation.NoEdit
            .Columns("Componente").CellActivation = Activation.NoEdit
            .Columns("ID").CellAppearance.TextHAlign = HAlign.Right
            .Columns("ID").Width = 20
            .Columns("Componente").Width = 200
            .Columns("Activo").Hidden = True
        End With
        grdComponente.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub grdComponente_DoubleClick(sender As Object, e As EventArgs) Handles grdComponente.DoubleClick
        Try
            If grdComponente.ActiveCell.Column.ToString = "ID" Or grdComponente.ActiveCell.Column.ToString = "Componente" Then
                idComponente = grdComponente.ActiveRow.Cells("ID").Value
                Componente = grdComponente.ActiveRow.Cells("Componente").Value
                Me.Close()
            End If
            
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub grdComponente_KeyUp(sender As Object, e As KeyEventArgs) Handles grdComponente.KeyUp
        Dim valor = 0
        valor = e.KeyValue

        Dim renglon As Integer = 0
        renglon = grdComponente.Rows.Count
        If valor = 40 Then 'abajo
            If contador = 0 Then
                grdComponente.Rows(0).Cells("Componente").Selected = True
                contador = contador + 1
            End If
        ElseIf valor = 38 Then 'arriba
            If contador = 0 Then
                grdComponente.Rows(0).Cells("Componente").Selected = True
                contador = contador + 1
            End If
        ElseIf valor = 13 Then
            Try
                idComponente = grdComponente.ActiveRow.Cells("ID").Value
                Componente = grdComponente.ActiveRow.Cells("Componente").Value
                Me.Close()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub grdComponente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdComponente.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Up Then
                grdComponente.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdComponente.DisplayLayout.Bands(0)
                If grdComponente.ActiveRow.HasPrevSibling(True) Then
                    Dim nextRow As UltraGridRow = grdComponente.ActiveRow.GetSibling(SiblingRow.Previous, True)
                    grdComponente.ActiveCell = nextRow.Cells(grdComponente.ActiveCell.Column)
                    e.Handled = True
                    grdComponente.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Down Then
                grdComponente.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdComponente.DisplayLayout.Bands(0)
                If grdComponente.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdComponente.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdComponente.ActiveCell = nextRow.Cells(grdComponente.ActiveCell.Column)
                    e.Handled = True
                    grdComponente.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ListaComponentesForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
End Class