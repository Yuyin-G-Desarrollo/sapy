Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaSubfamiliasForm
    Dim dtTablasubfamilias As DataTable

    Public Sub LlenarTablaSubfamilias()
        Dim FamiliaNegocios As New Programacion.Negocios.SubfamiliasBU
        Dim activo As Boolean = True
        If (rdoActivo.Checked = True) Then
            activo = True
        ElseIf (rdoInactivo.Checked = True) Then
            activo = False
        End If

        dtTablasubfamilias = FamiliaNegocios.ListarSubfamilias("", "", activo)
        grdListaSubfamilias.DataSource = dtTablasubfamilias
        With grdListaSubfamilias.DisplayLayout.Bands(0)
            'subf_subfamiliaid, subf_codigo, subf_descripcion, subf_activo
            .Columns("subf_subfamiliaid").Header.Caption = "Código"
            .Columns("subf_descripcion").Header.Caption = "Nombre"
            .Columns("subf_subfamiliaid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("subf_subfamiliaid").CellActivation = Activation.NoEdit
            .Columns("subf_descripcion").CellActivation = Activation.NoEdit
            .Columns("subf_activo").Hidden = True
            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListaSubfamilias.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListaSubfamilias.DisplayLayout.Bands(0).Columns("subf_subfamiliaid").Width = 40
    End Sub

    'Public Function ValidarExistencia() As Boolean
    '    Dim SubfamiliasbNegocio As New Programacion.Negocios.SubfamiliasBU

    '    Dim dtTabla As DataTable = SubfamiliasbNegocio.ContadorFilas
    '    Dim ValidacionExistePrimero As Int32 = dtTabla.Rows.Count
    '    Dim dtidFamilia As DataTable = New DataTable
    '    Dim codigoNuevo As String = String.Empty
    '    Dim IdNuevo As Int32 = 0

    '    Dim dtCodigosDisponibles As DataTable
    '    dtCodigosDisponibles = New DataTable
    '    dtCodigosDisponibles = SubfamiliasbNegocio.VerCodigosDisponibles()
    '    If (ValidacionExistePrimero >= 37) Then
    '        If (dtCodigosDisponibles.Rows.Count = 0) Then
    '            Return False
    '        End If
    '    End If
    '    Return True

    'End Function

    Public Sub EnviarEditarSubfamilia()
        Try
            Dim EntidadSubfamilia As New Entidades.Subfamilias
            Dim Fila As Int32 = 0
            Fila = grdListaSubfamilias.ActiveRow.Index
            EntidadSubfamilia.PIdSubfamilia = grdListaSubfamilias.Rows(Fila).Cells("subf_subfamiliaid").Value.ToString
            EntidadSubfamilia.PDescripcion = grdListaSubfamilias.Rows(Fila).Cells("subf_descripcion").Value.ToString
            EntidadSubfamilia.PActivo = Convert.ToBoolean(grdListaSubfamilias.Rows(Fila).Cells("subf_activo").Value.ToString)
            Dim edFam As New EditarSubfamiliaForm
            edFam.LlenarDatosSubfamilia(EntidadSubfamilia)
            edFam.ShowDialog()
        Catch ex As Exception
            MsgBox(" Debe seleccionar un registro.")
        End Try
    End Sub

    Private Sub ListaSubfamiliasForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdoActivo.Checked = True
        LlenarTablaSubfamilias()
        Me.Top = 0
        Me.Left = 0
        grdListaSubfamilias.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListaSubfamilias.DisplayLayout.Override.RowSelectorWidth = 35
        grdListaSubfamilias.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdListaSubfamilias.Rows(0).Selected = True
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LlenarTablaSubfamilias()
    End Sub

    Private Sub btnAltas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltas.Click
        Dim alSubfamilia As New AltaSubFamiliaForm
        alSubfamilia.ShowDialog()
        LlenarTablaSubfamilias()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        EnviarEditarSubfamilia()
        LlenarTablaSubfamilias()
    End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        LlenarTablaSubfamilias()
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        LlenarTablaSubfamilias()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub grdListaSubfamilias_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaSubfamilias.InitializeLayout
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