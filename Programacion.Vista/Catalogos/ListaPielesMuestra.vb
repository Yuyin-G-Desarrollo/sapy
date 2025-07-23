Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaPielesMuestra

    Public Sub LlenarTablaPielMuestra()
        Dim PielMuestraNegocio As New Programacion.Negocios.PielesMuestraBU
        Dim dtTablaPielMuestra As DataTable

        Dim descripcion As String = txtDescripcion.Text
        Dim codigo As String = txtCodigo.Text
        Dim activo As Boolean = True
        If (rdoActivo.Checked = True) Then
            activo = True
        ElseIf (rdoInactivo.Checked = True) Then
            activo = False
        End If

        dtTablaPielMuestra = New DataTable
        dtTablaPielMuestra = (PielMuestraNegocio.VerPielesMuestra(descripcion, codigo, activo))
        grdListaPielesMuestra.DataSource = dtTablaPielMuestra

        With grdListaPielesMuestra.DisplayLayout.Bands(0)

            .Columns("plmu_codigo").Header.Caption = "Código"
            .Columns("plmu_descripcion").Header.Caption = "Nombre"
            .Columns("plmu_codigo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("plmu_codigo").CellActivation = Activation.NoEdit
            .Columns("plmu_descripcion").CellActivation = Activation.NoEdit
            .Columns("plmu_pielmuestraid").Hidden = True
            .Columns("plmu_activo").Hidden = True
            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListaPielesMuestra.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListaPielesMuestra.DisplayLayout.Bands(0).Columns("plmu_codigo").Width = 35
    End Sub

    Private Sub ListaPielesMuestra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdoActivo.Checked = True
        LlenarTablaPielMuestra()
        Me.Top = 0
        Me.Left = 0
        grdListaPielesMuestra.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListaPielesMuestra.DisplayLayout.Override.RowSelectorWidth = 35
        grdListaPielesMuestra.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdListaPielesMuestra.Rows(0).Selected = True
    End Sub

    Private Sub btnUP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUP.Click
        pnlparametrosBusqueda.Height = 43
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        pnlparametrosBusqueda.Height = 105
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or caracter = ChrW(Keys.Space) Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = (".")) Then
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

    Public Sub EnviarDatosPielMuestraEditar()
        Try
            Dim entidadPielMuestra As New Entidades.PielesMuestra
            Dim fila As Int32 = grdListaPielesMuestra.ActiveRow.Index
            entidadPielMuestra.PiMUId = grdListaPielesMuestra.Rows(fila).Cells(0).Value.ToString
            entidadPielMuestra.PiMuDescripcion = grdListaPielesMuestra.Rows(fila).Cells(2).Value.ToString
            entidadPielMuestra.PiMuCodigo = grdListaPielesMuestra.Rows(fila).Cells(1).Value.ToString
            entidadPielMuestra.PiMuActivo = grdListaPielesMuestra.Rows(fila).Cells(3).Value.ToString
            'LimpiarTablaPielMuestra()
            Dim edPielMuestra As New EditarPielMuestraForm
            edPielMuestra.LLenarCampos(entidadPielMuestra)
            edPielMuestra.ShowDialog()

        Catch ex As Exception
            MsgBox("Debe Seleccionar un registro")
        End Try

    End Sub

    Private Sub btnAltas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltas.Click
        Dim alPiel As New AltaPielesMuestraForm
        alPiel.ShowDialog()
        LlenarTablaPielMuestra()
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        LlenarTablaPielMuestra()

    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click

        EnviarDatosPielMuestraEditar()
        LlenarTablaPielMuestra()

    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtCodigo.Text.Length < 5) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space) Or (caracter = "/")) Then
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

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        LlenarTablaPielMuestra()
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        LlenarTablaPielMuestra()
    End Sub

    Private Sub grdListaPielesMuestra_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListaPielesMuestra.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdListaPielesMuestra_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaPielesMuestra.InitializeLayout
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