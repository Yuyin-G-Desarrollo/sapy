Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ListaNavesAsignadasProduccionEstiloForm
    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Public tablaNaves As DataTable
    Public listaNaves As New List(Of Integer)

    Private Sub ListaNavesAsignadasProduccionEstiloForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdNaves.DataSource = tablaNaves
        disenioGrid()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'objConfirmacion.mensaje = "No se ha inactivado artículo en ninguna nave." & vbCrLf & "¿Desea salir sin inactivar algun artículo?"
        'If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
        Me.Close()
        'Else
        'End If
    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        For value = 0 To grdNaves.Rows.Count - 1
            If grdNaves.Rows(value).Cells(" ").Value = 1 Then
                listaNaves.Add(grdNaves.Rows(value).Cells("ID").Value)
            End If
        Next
        If listaNaves.Count > 0 Then
            Me.Close()
        Else
            objAdvertencia.mensaje = "Seleccione la o las naves para inactivar el artículo"
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
        End If

    End Sub

    Public Sub disenioGrid()
        With grdNaves.DisplayLayout.Bands(0)
            .Columns("ID").CellActivation = Activation.NoEdit
            .Columns("Nave").CellActivation = Activation.NoEdit
            .Columns("ID").CellAppearance.TextHAlign = HAlign.Right
            .Columns("ID").Width = 20
            .Columns(" ").Width = 20
            .Columns("Nave").Width = 200

            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            For value = 0 To grdNaves.Rows.Count - 1
                If grdNaves.Rows(value).Cells("Estatus").Text = "D" Then
                    grdNaves.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF00")
                ElseIf grdNaves.Rows(value).Cells("Estatus").Text = "AD" Then
                    grdNaves.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#31B404")
                ElseIf grdNaves.Rows(value).Cells("Estatus").Text = "AP" Then
                    grdNaves.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E9AFE")
                ElseIf grdNaves.Rows(value).Cells("Estatus").Text = "I" Then
                    grdNaves.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8000")
                ElseIf grdNaves.Rows(value).Cells("Estatus").Text = "DP" Then
                    grdNaves.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#DF0101")
                End If
                grdNaves.Rows(value).Cells("Estatus").Value = ""
            Next
        End With
        grdNaves.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Public Sub validarSeleccion()
        Try
            If grdNaves.ActiveRow.Cells(" ").IsActiveCell And grdNaves.ActiveRow.Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E9AFE") Then

                'If grdNaves.ActiveRow.Cells(" ").Value = 1 Then
                '    grdNaves.ActiveRow.Cells(" ").Value = 0
                'Else
                '    grdNaves.ActiveRow.Cells(" ").Value = 1
                'End If

            Else
                grdNaves.ActiveRow.Cells(" ").Value = 0
                objAdvertencia.mensaje = "No puede inactivar de producción un artículo en estatus autorizado a desarrollo"
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdNaves_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdNaves.ClickCell
        Try
            validarSeleccion()
        Catch ex As Exception
        End Try
    End Sub
End Class