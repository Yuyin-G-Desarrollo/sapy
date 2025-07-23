Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaColoresForm

    Public Sub LlenarTablaColores()
        Dim coloresNegocio As New Programacion.Negocios.ColoresBU
        Dim dtListaColores As DataTable
        Dim idColor As String = txtCodigo.Text
        Dim descripcion As String = txtDescripcion.Text
        Dim activo As Boolean = True
        Dim codSicy As String = txtCodSicy.Text
        If (rdoActivo.Checked = True) Then
            activo = True
        ElseIf (rdoInactivo.Checked = True) Then
            activo = False
        End If
        dtListaColores = New DataTable
        dtListaColores = coloresNegocio.VerListaColores(idColor, descripcion, activo, codSicy)
        'grdListaColoresUNO.DataSource = dtListaColores
        'grdListaColoresUNO.Columns(0).HeaderText = "Código"
        'grdListaColoresUNO.Columns(1).HeaderText = "Color"
        'grdListaColoresUNO.Columns(2).HeaderText = "Código sicy"
        'grdListaColoresUNO.Columns(3).Visible = False
        'grdListaColoresUNO.Columns(0).Width = 70
        'grdListaColoresUNO.Columns(2).Width = 70
        'Me.grdListaColoresUNO.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'Me.grdListaColoresUNO.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdListaColores.DataSource = dtListaColores
        'color_colorid , color_descripcion,color_codsicy, color_activo
        With grdListaColores.DisplayLayout.Bands(0)
            .Columns("color_colorid").Header.Caption = "Código"
            .Columns("color_descripcion").Header.Caption = "Nombre"
            .Columns("color_codsicy").Header.Caption = "SICY"
            .Columns("color_colorid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("color_codsicy").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("color_colorid").CellActivation = Activation.NoEdit
            .Columns("color_descripcion").CellActivation = Activation.NoEdit
            .Columns("color_codsicy").CellActivation = Activation.NoEdit
            .Columns("color_activo").Hidden = True
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListaColores.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Public Sub LimpiarTablaColores()
        Dim coloresNegocio As New Programacion.Negocios.ColoresBU
        Dim dtListaColores As DataTable
        txtCodigo.Text = String.Empty
        txtDescripcion.Text = String.Empty
        dtListaColores = New DataTable
        dtListaColores = coloresNegocio.VerListaColores("0", "0", "0", "0")
        grdListaColoresUNO.DataSource = dtListaColores
        grdListaColoresUNO.Columns(0).HeaderText = "Código"
        grdListaColoresUNO.Columns(1).HeaderText = "Color"
        grdListaColoresUNO.Columns(2).HeaderText = "Código sicy"
        grdListaColoresUNO.Columns(3).Visible = False
        grdListaColoresUNO.Columns(0).Width = 30
        grdListaColoresUNO.Columns(2).Width = 30
    End Sub

    Public Sub EnviarDatos()
        Try
            Dim entidadColor As New Entidades.Colores
            Dim fila As Int32

            fila = grdListaColores.ActiveRow.Index
            entidadColor.PColorId = CInt(grdListaColores.Rows(fila).Cells("color_colorid").Value.ToString)
            entidadColor.PCDescripcion = grdListaColores.Rows(fila).Cells("color_descripcion").Value.ToString
            entidadColor.PCCodSicy = grdListaColores.Rows(fila).Cells("color_codsicy").Value.ToString
            entidadColor.PCActivo = grdListaColores.Rows(fila).Cells("color_activo").Value.ToString
            Dim edColor As New EditarColorForm
            edColor.recibirDatosColor(entidadColor)
            edColor.ShowDialog()
        Catch ex As Exception
            MsgBox("Debe seleccionar un registro.")
        End Try


    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        pnlParametros.Height = 45
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        pnlParametros.Height = 109
    End Sub

    Private Sub ListaColoresForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grdListaColoresUNO.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        rdoActivo.Checked = True
        LlenarTablaColores()
        Me.Top = 0
        Me.Left = 0
        grdListaColores.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListaColores.DisplayLayout.Override.RowSelectorWidth = 35
        grdListaColores.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdListaColores.Rows(0).Selected = True
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        LlenarTablaColores()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        LimpiarTablaColores()
    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtCodigo.Text.Length < 5) Then
            If (Char.IsDigit(e.KeyChar) Or (caracter = ChrW(Keys.Back))) Then
                e.Handled = False
            Else
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

    Private Sub btnAltas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltas.Click
        Dim altaColor As New AltaColoresForm
        altaColor.ShowDialog()
        LlenarTablaColores()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        EnviarDatos()
        LlenarTablaColores()
    End Sub

    Private Sub txtCodSicy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodSicy.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtCodSicy.Text.Length < 3) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtCodSicy.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub rdoActivo_CheckedChanged_1(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        LlenarTablaColores()
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        LlenarTablaColores()
    End Sub

    Private Sub grdListaColores_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListaColores.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdListaColores_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaColores.InitializeLayout
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

    Private Sub ColCli_Click(sender As Object, e As EventArgs) Handles btnColCli.Click
        Dim form As New ColoresClientesForm()
        form.ShowDialog()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class