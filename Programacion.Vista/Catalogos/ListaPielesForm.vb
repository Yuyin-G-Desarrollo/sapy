Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ListaPielesForm
    Dim dtTablaPieles As DataTable

    Public Sub AbrirDetallesProducto()
        Dim detallePiel As New ListaDetalleColorPielForm
        Dim fila As Int32
        fila = grdListaPieles.ActiveRow.Index

        Dim idPiel As String = grdListaPieles.Rows(fila).Cells(0).Value.ToString
        Dim codigoPiel As String = grdListaPieles.Rows(fila).Cells(1).Value.ToString
        Dim NomPiel As String = grdListaPieles.Rows(fila).Cells(2).Value.ToString
        Dim nomCorto As String = grdListaPieles.Rows(fila).Cells(3).Value.ToString
        Dim codSicy As String = grdListaPieles.Rows(fila).Cells(4).Value.ToString
        Dim activo As Boolean = grdListaPieles.Rows(fila).Cells(5).Value.ToString

        detallePiel.RecibirDatos(idPiel, codigoPiel, NomPiel, nomCorto, codSicy, activo)
        detallePiel.MdiParent = MdiParent
        detallePiel.Show()

    End Sub

    Public Sub LlenarTablaPieles()
        Dim PielNegocios As New Programacion.Negocios.PielesBU
        Dim codigo As String = txtCodigo.Text.Trim
        Dim descripcion As String = txtDescripcion.Text.Trim
        Dim nombreCorto As String = txtNombreCorto.Text.Trim
        Dim activo As Boolean = True
        Dim codSicy As String = txtCodSicy.Text

        If (rdoActivo.Checked = True) Then
            activo = True
        ElseIf (rdoInactivo.Checked = True) Then
            activo = False
        End If
        dtTablaPieles = New DataTable
        grdListaPieles.DataSource = Nothing
        dtTablaPieles = PielNegocios.VerListaPieles(codigo, descripcion, nombreCorto, activo, codSicy)
        grdListaPieles.DataSource = dtTablaPieles
        'Select piel_pielid, piel_codigo, piel_descripcion, piel_nombrecorto, piel_codsicy, piel_activo
        With grdListaPieles.DisplayLayout.Bands(0)
            .Columns("piel_codigo").Header.Caption = "Código"
            .Columns("piel_descripcion").Header.Caption = "Nombre"
            .Columns("piel_nombrecorto").Header.Caption = "Nombre Corto"
            .Columns("piel_codsicy").Header.Caption = "SICY"

            .Columns("piel_codigo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("piel_codsicy").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("piel_codigo").CellActivation = Activation.NoEdit
            .Columns("piel_descripcion").CellActivation = Activation.NoEdit
            .Columns("piel_nombrecorto").CellActivation = Activation.NoEdit
            .Columns("piel_codsicy").CellActivation = Activation.NoEdit

            .Columns("piel_pielid").Hidden = True
            .Columns("piel_activo").Hidden = True
            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListaPieles.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListaPieles.DisplayLayout.Bands(0).Columns("piel_codigo").Width = 30
        'grdListaPieles.Columns(0).Visible = False
        'grdListaPieles.Columns(1).Width = 55
        'grdListaPieles.Columns(4).Width = 55
        'grdListaPieles.Columns(1).ReadOnly = True
        'grdListaPieles.Columns(2).ReadOnly = True
        'grdListaPieles.Columns(3).ReadOnly = True
        'grdListaPieles.Columns(5).Visible = False
        'Me.grdListaPieles.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub

    Public Sub EnviarDatoPiel()
        Try
            Dim idPiel As Int32 = 0
            Dim entidadPiel As New Entidades.Pieles
            Dim fila As Int32 = grdListaPieles.ActiveRow.Index
            idPiel = Convert.ToString(grdListaPieles.Rows(fila).Cells(0).Value.ToString)
            entidadPiel.PPielId = idPiel
            entidadPiel.PPActivo = grdListaPieles.Rows(fila).Cells(5).Value.ToString
            entidadPiel.PPielCodigo = grdListaPieles.Rows(fila).Cells(1).Value.ToString
            entidadPiel.PPielDescripcion = grdListaPieles.Rows(fila).Cells(2).Value.ToString
            entidadPiel.PPNombreCorto = grdListaPieles.Rows(fila).Cells(3).Value.ToString
            entidadPiel.PPCodSicy = grdListaPieles.Rows(fila).Cells(4).Value.ToString
            Dim edPiel As New EditarPielForm
            edPiel.LLenarCampos(entidadPiel)
            edPiel.ShowDialog()
        Catch ex As Exception
            Dim form As New AdvertenciaForm
            form.mensaje = "Debe seleccionar un registro."
            form.ShowDialog()
        End Try
    End Sub


    Private Sub pnlParametrosBusqueda_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlParametrosBusqueda.Enter

    End Sub

    Private Sub ListaPielesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdoActivo.Checked = True
        LlenarTablaPieles()
        Me.Top = 0
        Me.Left = 0
        grdListaPieles.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListaPieles.DisplayLayout.Override.RowSelectorWidth = 35
        grdListaPieles.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdListaPieles.Rows(0).Selected = True
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        LlenarTablaPieles()
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        pnlParametrosBusqueda.Height = 122
    End Sub

    Private Sub btnUP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUP.Click
        pnlParametrosBusqueda.Height = 43
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        EnviarDatoPiel()
        LlenarTablaPieles()

    End Sub

    Private Sub btnAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlta.Click
        Dim alPiel As New AltaPielesForm
        alPiel.ShowDialog()
        LlenarTablaPieles()

    End Sub

    Private Sub txtNombreCorto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreCorto.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtNombreCorto.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space) Or (caracter = "/")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtNombreCorto.SelectedText = Char.ToUpper(e.KeyChar)
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


    Private Sub txtCodSicy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodSicy.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtCodSicy.Text.Length < 5) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
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

    Private Sub grdListaPieles_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListaPieles.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdListaPieles_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grdListaPieles.DoubleClickRow
        AbrirDetallesProducto()
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        LlenarTablaPieles()
    End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        LlenarTablaPieles()
    End Sub

    Private Sub grdListaPieles_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaPieles.InitializeLayout
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

    Private Sub btnColCli_Click(sender As Object, e As EventArgs) Handles btnColCli.Click
        Dim form As New PielesClientesForm()
        form.ShowDialog()
    End Sub
End Class