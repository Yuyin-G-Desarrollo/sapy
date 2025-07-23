Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ListaSuelasForm


    Public Sub LlenarTablaSuelas()
        Dim dtTablaSuelas As New DataTable
        Dim objSBU As New Programacion.Negocios.SuelasBU

        Dim activo As String = String.Empty
        If (rdoActivo.Checked = True) Then
            activo = "True"
        ElseIf (rdoInactivo.Checked = True) Then
            activo = "False"
        End If
        dtTablaSuelas = objSBU.verListaSuelas("", activo, "")
        grdDatosSuelas.DataSource = dtTablaSuelas
        With grdDatosSuelas.DisplayLayout.Bands(0)
            ' suel_suelaid, suel_codigo, suel_descripcion, suel_activo
            .Columns("suel_codigo").Header.Caption = "Código"
            .Columns("suel_descripcion").Header.Caption = "Nombre"
            .Columns("suel_codigo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("suel_codigo").CellActivation = Activation.NoEdit
            .Columns("suel_descripcion").CellActivation = Activation.NoEdit
            .Columns("suel_suelaid").Hidden = True
            .Columns("suel_activo").Hidden = True
            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdDatosSuelas.DisplayLayout.Bands(0).Columns("suel_codigo").Width = 40
        grdDatosSuelas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'grdDatosSuelas.Columns(0).Visible = False
        'grdDatosSuelas.Columns(3).Visible = False
        'grdDatosSuelas.Columns(1).HeaderText = "Código"
        'grdDatosSuelas.Columns(1).Width = 50
        'grdDatosSuelas.Columns(2).HeaderText = "Descripción"
        'Me.grdDatosSuelas.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub

    Public Function VerExistenciaNuevasSuelas() As Boolean
        Dim objSBU As New Programacion.Negocios.SuelasBU
        Dim dtIdMAximo As DataTable = objSBU.VerMaximoIdSuela()
        Dim dtCodigosDisponibles As DataTable
        dtCodigosDisponibles = objSBU.verCodigosDiscponibles
        Dim dtContador As DataTable = objSBU.ContarFilasSuelas()
        Dim contador As Int32 = Convert.ToInt32(dtContador.Rows(0)(0).ToString)
        Dim idMaximo As Int32 = 0
        If (contador > 0) Then
            idMaximo = Convert.ToInt32(dtIdMAximo.Rows(0)(0).ToString)
            If (idMaximo >= 99) Then
                If (dtCodigosDisponibles.Rows.Count <= 0) Then
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Public Sub EnviarDatoEditar()
        Try
            Dim EntidadSuelas As New Entidades.Suelas
            Dim Fila As Int32 = 0
            Fila = grdDatosSuelas.ActiveRow.Index
            EntidadSuelas.PIdSuela = grdDatosSuelas.Rows(Fila).Cells(0).Value.ToString
            EntidadSuelas.PCodigoSuela = grdDatosSuelas.Rows(Fila).Cells(1).Value.ToString
            EntidadSuelas.PDescriopcionSuela = grdDatosSuelas.Rows(Fila).Cells(2).Value.ToString
            EntidadSuelas.PActivoSuela = grdDatosSuelas.Rows(Fila).Cells(3).Value.ToString
            Dim edSuela As New EditarSuelaForm
            edSuela.LlenarDatos(EntidadSuelas)
            edSuela.ShowDialog()
        Catch ex As Exception
            MsgBox("Debe seleccionar un registro.")
        End Try

    End Sub

    Private Sub ListaSuelasForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        rdoActivo.Checked = True
        LlenarTablaSuelas()
        Me.Top = 0
        Me.Left = 0
        grdDatosSuelas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDatosSuelas.DisplayLayout.Override.RowSelectorWidth = 35
        grdDatosSuelas.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdDatosSuelas.Rows(0).Selected = True
    End Sub

    Private Sub btnAltas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltas.Click
        If (VerExistenciaNuevasSuelas() = True) Then
            Dim alSuela As New AltaSuelaForm
            alSuela.ShowDialog()
            LlenarTablaSuelas()
        ElseIf (VerExistenciaNuevasSuelas() = False) Then
            Dim mensajeA As New AvisoForm
            mensajeA.mensaje = "No existen códigos disponibles."
            mensajeA.ShowDialog(Me)
        End If
    End Sub

    Private Sub btnFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LlenarTablaSuelas()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        EnviarDatoEditar()
        LlenarTablaSuelas()
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grpParametros.Height = 43
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grpParametros.Height = 103
    End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        LlenarTablaSuelas()
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        LlenarTablaSuelas()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub grdDatosSuelas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdDatosSuelas.InitializeLayout
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