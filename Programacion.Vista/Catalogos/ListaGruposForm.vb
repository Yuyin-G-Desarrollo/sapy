Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaGruposForm
    Dim dtDatosListaGrupos As DataTable

    Public Sub LlenarTablaGrupos()
        Dim GruposNegocios As New Programacion.Negocios.GruposBU
        'Dim idGrupo As String = txtCodigo.Text
        'Dim Descripcion As String = txtDescripcion.Text
        Dim activo As Boolean
        If (rdoActivo.Checked = True) Then
            activo = True
        ElseIf (rdoInactivo.Checked = True) Then
            activo = False
        End If
        dtDatosListaGrupos = New DataTable
        dtDatosListaGrupos = GruposNegocios.VerGrupos("", "", activo)
        grdListaGrupos.DataSource = dtDatosListaGrupos

        With grdListaGrupos.DisplayLayout.Bands(0)
            .Columns("grpo_activo").Hidden = True
            .Columns("grpo_grupoid").Header.Caption = "Código"
            .Columns("grpo_descripcion").Header.Caption = "Nombre"
            .Columns("grpo_grupoid").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("grpo_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("grpo_grupoid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListaGrupos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListaGrupos.DisplayLayout.Bands(0).Columns("grpo_grupoid").Width = 40
    End Sub

    Public Sub EnviarDatosEditar()
        Dim entidadGrupo As New Entidades.Grupos
        Dim fila As Int32
        fila = grdListaGrupos.ActiveRow.Index
        entidadGrupo.PGrupoId = CInt(grdListaGrupos.Rows(fila).Cells(0).Value.ToString)
        entidadGrupo.PGDescripcion = grdListaGrupos.Rows(fila).Cells(1).Value.ToString
        entidadGrupo.PGActivo = grdListaGrupos.Rows(fila).Cells(2).Value.ToString
        Dim edGrp As New EditarGrupoForm
        edGrp.LlenarDatos(entidadGrupo)
        edGrp.ShowDialog()
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        pnlParametros.Height = 45
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        pnlParametros.Height = 115
    End Sub

    Private Sub ListaGruposForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdoActivo.Checked = True
        LlenarTablaGrupos()
        Me.Top = 0
        Me.Left = 0
        grdListaGrupos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListaGrupos.DisplayLayout.Override.RowSelectorWidth = 35
        grdListaGrupos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdListaGrupos.Rows(0).Selected = True
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        LlenarTablaGrupos()
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
        If (txtDescripcion.Text.Length < 100) Then
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
        Dim algrp As New AltaGrupoForm
        algrp.ShowDialog()
        LlenarTablaGrupos()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Try
            EnviarDatosEditar()
            LlenarTablaGrupos()
        Catch ex As Exception
            MsgBox("Debe seleccionar un registro.")
        End Try

    End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        LlenarTablaGrupos()
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        LlenarTablaGrupos()
    End Sub

    Private Sub grdListaGrupos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListaGrupos.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdListaGrupos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaGrupos.InitializeLayout
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