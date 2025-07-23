Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class listaFraccionesForm

    Public id As Integer = 0
    Public fraccion As String = ""
    Public cerrado As Boolean = False
    Public selecciono As Boolean = False
    Public FraccionRepetida As String = String.Empty

    Private Sub listaFraccionesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        obtenerComponentes()
        lblTitulo.Focus()
    End Sub

    Private Sub grdFracciones_DoubleClick(sender As Object, e As EventArgs) Handles grdFracciones.DoubleClick
        Try
            If grdFracciones.ActiveCell.Column.ToString = "ID" Or grdFracciones.ActiveCell.Column.ToString = "Fracción" Then
                id = grdFracciones.ActiveRow.Cells("ID").Value
                fraccion = grdFracciones.ActiveRow.Cells("Fracción").Value
                selecciono = True
                Me.Close()
            End If
        Catch ex As Exception

        End Try
      
    End Sub

    Public Sub obtenerComponentes()
        Dim obj As New catalagosBU
        Dim listaFracciones As New DataTable
        listaFracciones = obj.listaFraccioness(FraccionRepetida)
        grdFracciones.DataSource = listaFracciones
        disenioGrid()
        grdFracciones.ActiveRow = Nothing
        'grdFracciones.Selected.Rows.Clear()

    End Sub

    Public Sub disenioGrid()
        With grdFracciones.DisplayLayout.Bands(0)
            .Columns("ID").CellActivation = Activation.NoEdit
            .Columns("Fracción").CellActivation = Activation.NoEdit
            .Columns("ID").CellAppearance.TextHAlign = HAlign.Right
            .Columns("ID").Width = 20
            .Columns("Fracción").Width = 200
        End With
        grdFracciones.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        id = 0
        fraccion = ""
        cerrado = True
        selecciono = False
        Me.Close()
    End Sub

    Private Sub grdFracciones_KeyUp(sender As Object, e As KeyEventArgs) Handles grdFracciones.KeyUp
        Dim valor = 0
        valor = e.KeyValue
        Dim contador = 0
        Dim renglon As Integer = 0
        renglon = grdFracciones.Rows.Count
        If valor = 40 Then 'abajo
            If contador = 0 Then
                grdFracciones.Rows(0).Cells("Fracción").Selected = True
                contador = contador + 1
            End If
        ElseIf valor = 38 Then 'arriba
            If contador = 0 Then
                grdFracciones.Rows(0).Cells("Fracción").Selected = True
                contador = contador + 1
            End If
        ElseIf valor = 13 Then
            Try
                id = grdFracciones.ActiveRow.Cells("ID").Value
                fraccion = grdFracciones.ActiveRow.Cells("Fracción").Value
                Me.Close()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub grdFracciones_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdFracciones.ClickCell
        'Try
        '    id = grdFracciones.ActiveRow.Cells("ID").Value
        '    fraccion = grdFracciones.ActiveRow.Cells("Fracción").Value
        'Catch ex As Exception
        'End Try
       
    End Sub

    Private Sub grdFracciones_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFracciones.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Up Then
                grdFracciones.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdFracciones.DisplayLayout.Bands(0)
                If grdFracciones.ActiveRow.HasPrevSibling(True) Then
                    Dim nextRow As UltraGridRow = grdFracciones.ActiveRow.GetSibling(SiblingRow.Previous, True)
                    grdFracciones.ActiveCell = nextRow.Cells(grdFracciones.ActiveCell.Column)
                    e.Handled = True
                    grdFracciones.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Down Then
                grdFracciones.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdFracciones.DisplayLayout.Bands(0)
                If grdFracciones.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdFracciones.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdFracciones.ActiveCell = nextRow.Cells(grdFracciones.ActiveCell.Column)
                    e.Handled = True
                    grdFracciones.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim altaAltaModificarFracciones As New AltaModificarFraccionesForm
        altaAltaModificarFracciones.actualizar = 0
        altaAltaModificarFracciones.ShowDialog()

        obtenerComponentes()
        lblTitulo.Focus()

    End Sub


End Class