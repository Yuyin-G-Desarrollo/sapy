Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaCategoriasForm

    Public Sub llenarListaCategorias()

        Dim objCatBU As New Negocios.CategoriasBU
        Dim dtDatosCategoria As New DataTable
        dtDatosCategoria = objCatBU.verListaCategorias(CBool(rdoActivo.Checked))
        grdListaCategorias.DataSource = dtDatosCategoria

        With grdListaCategorias.DisplayLayout.Bands(0)
            .Columns("tica_tipocategoriaid").Header.Caption = "Código"
            .Columns("tica_descripcion").Header.Caption = "Nombre"
            .Columns("tica_tipocategoriaid").CellActivation = Activation.NoEdit
            .Columns("tica_descripcion").CellActivation = Activation.NoEdit
            .Columns("tica_tipocategoriaid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("tica_activo").Hidden = True
            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListaCategorias.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListaCategorias.DisplayLayout.Bands(0).Columns("tica_tipocategoriaid").Width = 40
    End Sub

    Public Sub editarCategoria()
        Try

            Dim fila As Int32
            fila = CInt(grdListaCategorias.ActiveRow.Index)
            Dim idCategoria As Int32
            Dim activoCat As Boolean
            Dim nomCat As String
            idCategoria = CInt(grdListaCategorias.Rows(fila).Cells("tica_tipocategoriaid").Value)
            activoCat = CBool(grdListaCategorias.Rows(fila).Cells("tica_activo").Value)
            nomCat = CStr(grdListaCategorias.Rows(fila).Cells("tica_descripcion").Value.ToString)
            Dim objEditarCat As New AltaCategorias
            objEditarCat.esAltaCat = False
            objEditarCat.idCategoria = idCategoria
            objEditarCat.activoCat = activoCat
            objEditarCat.nombreCat = nomCat
            objEditarCat.ShowDialog()
            llenarListaCategorias()

        Catch ex As Exception
            MsgBox("Debe seleccionar un registro.")
        End Try

    End Sub

    Private Sub ListaCategoriasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rdoActivo.Checked = True
        llenarListaCategorias()
        Me.Top = 0
        Me.Left = 0
        grdListaCategorias.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListaCategorias.DisplayLayout.Override.RowSelectorWidth = 35
        grdListaCategorias.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdListaCategorias.Rows(0).Selected = True
    End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        llenarListaCategorias()
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        llenarListaCategorias()
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim objCatAlta As New AltaCategorias
        objCatAlta.esAltaCat = True
        objCatAlta.ShowDialog()
        llenarListaCategorias()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        editarCategoria()
    End Sub

    Private Sub grdListaCategorias_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListaCategorias.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdListaCategorias_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaCategorias.InitializeLayout
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