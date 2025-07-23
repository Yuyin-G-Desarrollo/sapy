Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaForrosForm
    Dim dtTablaForros As DataTable

    Public Sub LlenarTablaForros()
        Dim ForroNegocios As New Programacion.Negocios.ForrosBU
        Dim codigo As String = txtCodigo.Text
        Dim descripcion As String = txtDescripcion.Text
        Dim activo As Boolean
        If (rdoActivo.Checked = True) Then
            activo = True
        ElseIf (rdoInactivo.Checked = True) Then
            activo = False
        End If
        dtTablaForros = New DataTable
        dtTablaForros = ForroNegocios.VerListaForros(descripcion, codigo, activo)
        grdListaForros.DataSource = dtTablaForros
        'select forr_forroid, forr_codigo, forr_descripcion, forr_activo
        'grdListaForros.Columns("forr_forroid").Visible = False
        'grdListaForros.Columns("forr_activo").Visible = False
        'grdListaForros.Columns(1).Width = 55
        'grdListaForros.Columns(1).ReadOnly = True
        'grdListaForros.Columns(2).ReadOnly = True
        With grdListaForros.DisplayLayout.Bands(0)
            .Columns("forr_forroid").Hidden = True
            .Columns("forr_activo").Hidden = True
            .Columns("forr_codigo").Header.Caption = "Código"
            .Columns("forr_descripcion").Header.Caption = "Nombre"
            .Columns("forr_codigo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("forr_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("forr_codigo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListaForros.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListaForros.DisplayLayout.Bands(0).Columns("forr_codigo").Width = 45
    End Sub

    'Public Sub LimpiarTablaForros()
    '    Dim ForroNegocios As New Programacion.Negocios.ForrosBU

    '    dtTablaForros = New DataTable
    '    dtTablaForros = ForroNegocios.VerListaForros("0", "0", "0")
    '    grdListaForros.DataSource = dtTablaForros
    '    grdListaForros.Columns("forr_forroid").Visible = False
    '    grdListaForros.Columns("forr_activo").Visible = False
    '    grdListaForros.Columns(1).Width = 55
    '    grdListaForros.Columns(1).ReadOnly = True
    '    grdListaForros.Columns(2).ReadOnly = True

    'End Sub

    Public Sub EnviarDatosForro()
        Try
            Dim entidadForro As New Entidades.Forros
            Dim fila As Int32 = grdListaForros.ActiveRow.Index


            entidadForro.ForroActivo = grdListaForros.Rows(fila).Cells(3).Value.ToString
            entidadForro.ForroCodigo = grdListaForros.Rows(fila).Cells(1).Value.ToString
            entidadForro.ForroDescripcion = grdListaForros.Rows(fila).Cells(2).Value.ToString
            entidadForro.ForroId = grdListaForros.Rows(fila).Cells(0).Value.ToString
            Dim edForro As New EditarForroForm
            edForro.recibirDatos(entidadForro)
            edForro.ShowDialog()
        Catch ex As Exception
            MsgBox(" Debe seleccionar un registro.")
        End Try
    End Sub



    Private Sub ListaForrosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdoActivo.Checked = True
        LlenarTablaForros()
        Me.Top = 0
        Me.Left = 0
        grdListaForros.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListaForros.DisplayLayout.Override.RowSelectorWidth = 35
        grdListaForros.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdListaForros.Rows(0).Selected = True
    End Sub

    Private Sub btnAltas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltas.Click
        Dim alForro As New AltaForroForm
        alForro.ShowDialog()
        LlenarTablaForros()

    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        LlenarTablaForros()

    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        EnviarDatosForro()
        LlenarTablaForros()
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        pnlParametrosBusqueda.Height = 40
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        pnlParametrosBusqueda.Height = 103
    End Sub

    'Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
    '    txtDescripcion.Text = String.Empty
    '    txtCodigo.Text = String.Empty
    '    rdoActivo.Checked = True
    '    LimpiarTablaForros()
    'End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtCodigo.Text.Length < 5) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtCodigo.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 50) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = (".")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtDescripcion.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        LlenarTablaForros()
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        LlenarTablaForros()
    End Sub

    Private Sub grdListaForros_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListaForros.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdListaForros_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaForros.InitializeLayout
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