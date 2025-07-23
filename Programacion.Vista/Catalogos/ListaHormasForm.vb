Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaHormasForm


    Public Sub llenarDatosHormas()
        Dim objHormaBu As New Programacion.Negocios.HormasBU
        Dim dtDatosListaHormas As New DataTable
        dtDatosListaHormas = objHormaBu.verListaHormas("", "", CBool(rdoActivo.Checked))
        grdListaHromas.DataSource = dtDatosListaHormas
        'grdListaHromas.Columns("horma_hormaid").HeaderText = "Código"
        'grdListaHromas.Columns("horma_descripcion").HeaderText = "Horma"
        'grdListaHromas.Columns("horma_activo").Visible = False
        'grdListaHromas.Columns("horma_hormaid").Width = 60
        With grdListaHromas.DisplayLayout.Bands(0)
            .Columns("horma_hormaid").Header.Caption = "Código"
            .Columns("horma_descripcion").Header.Caption = "Nombre"
            .Columns("horma_activo").Hidden = True
            .Columns("horma_hormaid").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("horma_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("horma_hormaid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListaHromas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListaHromas.DisplayLayout.Bands(0).Columns("horma_hormaid").Width = 40
    End Sub

    Public Sub limpiarDatosHormas()
        Dim objHormaBu As New Programacion.Negocios.HormasBU
        Dim dtDatosListaHormas As New DataTable
        dtDatosListaHormas = objHormaBu.verListaHormas("0", "", "0")
        grdListaHromas.DataSource = dtDatosListaHormas
    End Sub

    Public Sub enviarDatosEditar()
        Try
            Dim fila As Int32 = 0
            fila = grdListaHromas.ActiveRow.Index
            Dim objEdiarHorma As New EditarHormaForm
            objEdiarHorma.idHorma = CInt(grdListaHromas.Rows(fila).Cells(0).Value)
            objEdiarHorma.descripcionHorma = grdListaHromas.Rows(fila).Cells(1).Value.ToString
            objEdiarHorma.activoHorma = CBool(grdListaHromas.Rows(fila).Cells(2).Value)
            objEdiarHorma.ShowDialog()
        Catch ex As Exception
            MsgBox("Debe seleccionar un registro.")
        End Try

    End Sub

    Private Sub ListaHormasForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdoActivo.Checked = True
        llenarDatosHormas()
        Me.Top = 0
        Me.Left = 0
        grdListaHromas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListaHromas.DisplayLayout.Override.RowSelectorWidth = 35
        grdListaHromas.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdListaHromas.Rows(0).Selected = True
    End Sub


    Private Sub btnAltas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltas.Click
        Dim objAltaHorma As New AltaHormaForm
        objAltaHorma.ShowDialog()
        llenarDatosHormas()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        enviarDatosEditar()
        llenarDatosHormas()
    End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        llenarDatosHormas()
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        llenarDatosHormas()
    End Sub

    Private Sub grdListaHromas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListaHromas.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdListaHromas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaHromas.InitializeLayout
        Dim valueList As ValueList = e.Layout.FilterOperatorsValueList
        Dim item As ValueListItem
        For Each item In valueList.ValueListItems
            Dim filterOperator As FilterComparisionOperator = DirectCast(item.DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Contains = filterOperator Then
                item.DisplayText = "CONTIENE"
            ElseIf FilterComparisionOperator.DoesNotEndWith = filterOperator Then
                item.DisplayText = "NO TERMINA CON"
            ElseIf FilterComparisionOperator.DoesNotStartWith = filterOperator Then
                item.DisplayText = "NO COMIENZA CON"
            ElseIf FilterComparisionOperator.EndsWith = filterOperator Then
                item.DisplayText = "TERMINA CON"
            ElseIf FilterComparisionOperator.Equals = filterOperator Then
                item.DisplayText = "IGUAL"
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                item.DisplayText = "MAYOR QUE"
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                item.DisplayText = "MAYOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                item.DisplayText = "MENOR QUE"
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                item.DisplayText = "MENOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.NotEquals = filterOperator Then
                item.DisplayText = "DIFERENTE A"
            ElseIf FilterComparisionOperator.StartsWith = filterOperator Then
                item.DisplayText = "COMIENZA CON"
            End If
        Next

        Dim cont As Integer
        For cont = valueList.ValueListItems.Count - 1 To 0 Step -1
            Dim filterOperator As FilterComparisionOperator = DirectCast(valueList.ValueListItems.Item(cont).DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Custom = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotContain = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotMatch = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Like = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Match = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.NotLike = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            End If
        Next
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class