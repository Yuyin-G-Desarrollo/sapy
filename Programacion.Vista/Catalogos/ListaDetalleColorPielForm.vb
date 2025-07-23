Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaDetalleColorPielForm
    Dim idPiel As String
    Dim codigoPiel As String
    Dim NomPiel As String
    Dim nomCorto As String
    Dim codSicy As String
    Dim activo As Boolean

    Public Sub RecibirDatos(ByVal idPl As String, ByVal codPiel As String, ByVal npiel As String, ByVal ncorto As String, ByVal cdsicy As String, ByVal act As Boolean)
        idPiel = idPl
        codigoPiel = codPiel
        NomPiel = npiel
        nomCorto = ncorto
        codSicy = cdsicy
        activo = act
    End Sub

    Public Sub llenarDatos()
        txtCodigo.Text = codigoPiel
        txtDescripcion.Text = NomPiel
        txtNombreCorto.Text = nomCorto
        txtCodSicy.Text = codSicy
        If (activo = True) Then
            rdoActivo.Checked = True
        Else
            rdoInactivo.Checked = True
        End If
    End Sub

    Public Sub llenarTablaColores()
        Dim objPieles As New Programacion.Negocios.PielesBU
        Dim dtDatosColores As New DataTable
        dtDatosColores = objPieles.consultaDetallesColorPiel(idPiel)
        grdColores.DataSource = dtDatosColores
        With grdColores.DisplayLayout.Bands(0)
            'cc.color_colorid,cc.color_descripcion, cc.color_codsicy
            .Columns("color_colorid").Header.Caption = "Código"
            .Columns("color_descripcion").Header.Caption = "Color"
            .Columns("color_codsicy").Header.Caption = "SICY"

            .Columns("color_colorid").CellActivation = Activation.NoEdit
            .Columns("color_descripcion").CellActivation = Activation.NoEdit
            .Columns("color_codsicy").CellActivation = Activation.NoEdit

            .Columns("color_colorid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("color_codsicy").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdColores.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdColores.DisplayLayout.Bands(0).Columns("color_colorid").Width = 30
        grdColores.DisplayLayout.Bands(0).Columns("color_codsicy").Width = 30
    End Sub

    Private Sub ListaDetalleColorPielForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarTablaColores()
        llenarDatos()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub grdColores_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdColores.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdColores_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColores.InitializeLayout
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