Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ListaTemporadasForm

    Public Sub LlenarTablaTemporadas()
        Dim objTDA As New Programacion.Negocios.TemporadasBU
        Dim dtTablaTemporadas As DataTable
        Dim activo As Boolean
        If (rdoActivo.Checked = True) Then
            activo = True
        ElseIf (rdoInactivo.Checked = True) Then
            activo = False
        End If
        dtTablaTemporadas = New DataTable
        dtTablaTemporadas = objTDA.verListaTemporadas("", "", "", activo)
        grdListaTemporadas.DataSource = dtTablaTemporadas
        'select temp_temporadaid, temp_codigo, temp_nombre, temp_año, temp_activo
        With grdListaTemporadas.DisplayLayout.Bands(0)
            .Columns("temp_temporadaid").Hidden = True
            .Columns("temp_activo").Hidden = True
            .Columns("temp_codigo").Header.Caption = "Código"
            .Columns("temp_nombre").Header.Caption = "Nombre"
            .Columns("temp_año").Header.Caption = "Año"

            .Columns("temp_codigo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("temp_año").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("temp_codigo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("temp_nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("temp_año").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListaTemporadas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListaTemporadas.DisplayLayout.Bands(0).Columns("temp_codigo").Width = 28
    End Sub

    Public Function VerExistenciaNuevasTemporadas() As Boolean
        Dim objtBU As New Programacion.Negocios.TemporadasBU
        Dim dtIdMAximo As DataTable = objtBU.VerMaximoIdTemporada
        Dim dtCodigosDisponibles As DataTable
        dtCodigosDisponibles = objtBU.verCodigosDiscponibles
        Dim dtContador As DataTable = objtBU.ContarFilasTemporadas
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

    Public Sub enviarDatosEditar()
        Try
            Dim entidadTemporada As New Entidades.Temporadas
            Dim fila As Int32
            fila = grdListaTemporadas.ActiveRow.Index
            entidadTemporada.pIdTemporada = grdListaTemporadas.Rows(fila).Cells(0).Value.ToString
            entidadTemporada.pCodigoTemporada = grdListaTemporadas.Rows(fila).Cells(1).Value.ToString
            entidadTemporada.pNombreTemporada = grdListaTemporadas.Rows(fila).Cells(2).Value.ToString
            entidadTemporada.pAnioTemporada = grdListaTemporadas.Rows(fila).Cells(3).Value.ToString
            entidadTemporada.pActivoTemporada = grdListaTemporadas.Rows(fila).Cells(4).Value.ToString
            Dim edTemp As New EditarTemporadaForm
            edTemp.LlenarDatosTemporada(entidadTemporada)
            edTemp.ShowDialog()

        Catch ex As Exception
            MsgBox("Debe seleccionar un registro.")
        End Try
    End Sub

    Private Sub ListaTemporadasForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdoActivo.Checked = True
        LlenarTablaTemporadas()
        Me.Top = 0
        Me.Left = 0
        grdListaTemporadas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListaTemporadas.DisplayLayout.Override.RowSelectorWidth = 35
        grdListaTemporadas.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdListaTemporadas.Rows(0).Selected = True
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grpParametros.Height = 47
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grpParametros.Height = 107
    End Sub

    Private Sub btnAltas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltas.Click
        If (VerExistenciaNuevasTemporadas() = True) Then
            Dim altaTemp As New AltaTemporadaForm
            altaTemp.ShowDialog()
            'AltaTemporadaForm.ShowDialog(Me)
            LlenarTablaTemporadas()
        ElseIf (VerExistenciaNuevasTemporadas() = False) Then
            Dim mensajeA As New AvisoForm
            mensajeA.mensaje = "No existen códigos disponibles."
            mensajeA.ShowDialog(Me)
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LlenarTablaTemporadas()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        enviarDatosEditar()
        LlenarTablaTemporadas()
    End Sub

    'Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    Dim caracter As Char = e.KeyChar
    '    If (txtNombre.Text.Length < 50) Then
    '        If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or caracter = ChrW(Keys.Space) Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = (".")) Then
    '            e.Handled = False
    '        Else
    '            e.Handled = True
    '        End If

    '        If Char.IsLower(e.KeyChar) Then
    '            txtNombre.SelectedText = Char.ToUpper(e.KeyChar)
    '            e.Handled = True
    '        End If
    '    Else
    '        If e.KeyChar <> vbBack Then
    '            e.Handled = True
    '        End If
    '    End If
    'End Sub

    'Private Sub txtAnio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    Dim caracter As Char = e.KeyChar
    '    If (txtAnio.Text.Length < 4) Then

    '        If (Char.IsDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
    '            e.Handled = False
    '        Else
    '            e.Handled = True
    '        End If

    '        If Char.IsLower(e.KeyChar) Then
    '            txtAnio.SelectedText = Char.ToUpper(e.KeyChar)
    '            e.Handled = True
    '        End If
    '    Else
    '        If e.KeyChar <> vbBack Then
    '            e.Handled = True
    '        End If
    '    End If
    'End Sub

    'Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    Dim caracter As Char = e.KeyChar
    '    If (txtCodigo.Text.Length < 5) Then
    '        If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space) Or (caracter = "-")) Then
    '            e.Handled = False
    '        Else
    '            e.Handled = True
    '        End If

    '        If Char.IsLower(e.KeyChar) Then
    '            txtCodigo.SelectedText = Char.ToUpper(e.KeyChar)
    '            e.Handled = True
    '        End If
    '    Else
    '        If e.KeyChar <> vbBack Then
    '            e.Handled = True
    '        End If
    '    End If
    'End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        LlenarTablaTemporadas()
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        LlenarTablaTemporadas()
    End Sub

    Private Sub grdListaTemporadas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListaTemporadas.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdListaTemporadas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaTemporadas.InitializeLayout
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