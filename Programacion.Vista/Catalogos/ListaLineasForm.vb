Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaLineasForm

    Public Sub llenarTablaLineas()
        Dim objLineasBU As New Negocios.LineasBU
        Dim dtDatosLineas As New DataTable
        dtDatosLineas = objLineasBU.verListaLineas(CBool(rdoActivo.Checked))
        grdListaLineas.DataSource = dtDatosLineas

        With grdListaLineas.DisplayLayout.Bands(0)
            .Columns("linea_lineaid").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("linea_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("linea_lineaid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("linea_lineaid").Header.Caption = "Código"
            .Columns("linea_descripcion").Header.Caption = "Nombre"
            .Columns("linea_activo").Hidden = True
            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListaLineas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListaLineas.DisplayLayout.Bands(0).Columns("linea_lineaid").Width = 40
    End Sub

    Public Sub registrarLinea()
        Dim objAltaEditar As New AltaEditarLineas
        objAltaEditar.esAltaLinea = True
        objAltaEditar.ShowDialog()
        llenarTablaLineas()
    End Sub

    Public Sub editarLinea()
        Try
            Dim fila As Int32
            fila = grdListaLineas.ActiveRow.Index
            Dim objEditarLinea As New AltaEditarLineas
            objEditarLinea.idLineaEditar = CInt(grdListaLineas.Rows(fila).Cells("linea_lineaid").Value)
            objEditarLinea.nombreLinea = grdListaLineas.Rows(fila).Cells("linea_descripcion").Value.ToString
            objEditarLinea.activoLinea = CBool(grdListaLineas.Rows(fila).Cells("linea_activo").Value)
            objEditarLinea.ShowDialog()
            llenarTablaLineas()
        Catch ex As Exception
            MsgBox("Debe seleccionar un registro.")
        End Try
    End Sub

    Private Sub ListaLineasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rdoActivo.Checked = True
        llenarTablaLineas()
        Me.Top = 0
        Me.Left = 0
        grdListaLineas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListaLineas.DisplayLayout.Override.RowSelectorWidth = 35
        grdListaLineas.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdListaLineas.Rows(0).Selected = True
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        registrarLinea()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        editarLinea()
    End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        llenarTablaLineas()
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        llenarTablaLineas()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub grdListaLineas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaLineas.InitializeLayout
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
End Class