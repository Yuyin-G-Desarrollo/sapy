Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class MotivoInactivacion
    Public nombreLista As String = ""
    Public estatusLista As String = ""
    Public codiLista As String = ""
    Public codListaBaseActual As String = ""
    Public idLista As Int32 = 0


    Private Sub MotivoInactivacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUsuario.Text = "Usuario: " + Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        txtCodigo.Text = codiLista
        txtNombreLista.Text = nombreLista
        If estatusLista = "AUTORIZADA" Then

        ElseIf estatusLista = "ACTIVA" Then
            lblMensajeEstatico.Text = "Si la lista " + nombreLista + " se AUTORIZA, " + vbLf + "la lista de precios base actual se INACTIVARÁ automáticamente."

        End If

        Me.Height = (Me.Height - 179)
        pnlGrid.Height = 0
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim dtTablaResultadoCambioListaPrecios
        Dim objListaBU As New Negocios.ListaBaseBU
        Dim objMensajeGuardar As New Tools.ConfirmarForm
        objMensajeGuardar.mensaje = "¿Esta seguro de guardar los cambios?"
        If objMensajeGuardar.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim objCaptcha As New Tools.frmCaptcha
            objCaptcha.mensaje = "Se inactivara la lista actual."
            objCaptcha.StartPosition = FormStartPosition.CenterScreen
            If objCaptcha.ShowDialog = Windows.Forms.DialogResult.OK Then
                If idLista > 0 Then

                    dtTablaResultadoCambioListaPrecios = objListaBU.editarListaPrecios(idLista, "")

                    If dtTablaResultadoCambioListaPrecios.rows.count = 0 Then
                        Dim objMensajeError As New Tools.ErroresForm
                        objMensajeError.mensaje = "El cambio de lista ""Activa"" a ""Autorizada"" no se realizó correctamente, por favor intentar guardar de nuevo."
                        objMensajeError.ShowDialog()

                    Else
                        Dim objMensajeExito As New Tools.ExitoForm
                        objMensajeExito.mensaje = "El cambio de lista ""Activa"" a ""Autorizada""  se realizó correctamente."
                        objMensajeExito.ShowDialog()
                        Me.Height = (Me.Height + 179)
                        pnlGrid.Height = 192
                        grdListaVentasClientes.DataSource = dtTablaResultadoCambioListaPrecios
                        btnGuardar.Enabled = False

                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtMotivosInactivacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMotivosInactivacion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtMotivosInactivacion.Text.Length < 150) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Or (caracter = ("-")) Or (caracter = (".")) Or (caracter = (",")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtMotivosInactivacion.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub grdListaVentasClientes_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdListaVentasClientes.InitializeLayout
        Dim valueList As ValueList = e.Layout.FilterOperatorsValueList
        Dim item As ValueListItem
        For Each item In ValueList.ValueListItems
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



        With grdListaVentasClientes
            .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti

            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 45
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True

            .DisplayLayout.Bands(0).Columns("Clientes").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("Incremento").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("Temporal").Hidden = True
        End With

        For Each row As UltraGridRow In grdListaVentasClientes.Rows
            If row.Cells("Temporal").Text = "True" Then
                row.CellAppearance.BackColor = Color.Orange
            End If
        Next

        Dim ColumnaSumar As UltraGridColumn = grdListaVentasClientes.DisplayLayout.Bands(0).Columns("Clientes")
        Dim sumaPares As SummarySettings = grdListaVentasClientes.DisplayLayout.Bands(0).Summaries.Add("Total Clientes", SummaryType.Sum, ColumnaSumar)
        grdListaVentasClientes.DisplayLayout.Bands(0).SummaryFooterCaption = "Total Clientes"
        sumaPares.DisplayFormat = "{0:###,###,###,###00}"
        sumaPares.Appearance.TextHAlign = HAlign.Right

    End Sub
End Class