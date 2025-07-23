Imports Infragistics.Win.UltraWinGrid

Public Class ConsultaEstadosArticuloPorNaveForm

    Public tabla As DataTable
    Public estilo As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ConsultaEstadosArticuloPorNaveForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdEstatus.DataSource = tabla
        disenioGrid()
    End Sub

    Public Sub disenioGrid()
        Dim band As UltraGridBand = Me.grdEstatus.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        With grdEstatus.DisplayLayout.Bands(0)
     
            .Columns("Estatus").CellActivation = Activation.NoEdit
            .Columns("Nave").CellActivation = Activation.NoEdit

            .Columns("Estatus").Width = 25
            .Columns("Nave").Width = 250

            .Columns("Estatus").Header.Caption = ""

            For value = 0 To grdEstatus.Rows.Count - 1
                If grdEstatus.Rows(value).Cells("Estatus").Text = "D" Then
                    grdEstatus.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF00")
                ElseIf grdEstatus.Rows(value).Cells("Estatus").Text = "AD" Then
                    grdEstatus.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#31B404")
                ElseIf grdEstatus.Rows(value).Cells("Estatus").Text = "AP" Then
                    grdEstatus.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E9AFE")
                ElseIf grdEstatus.Rows(value).Cells("Estatus").Text = "I" Then
                    grdEstatus.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#424242")
                ElseIf grdEstatus.Rows(value).Cells("Estatus").Text = "DP" Then
                    grdEstatus.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#DF0101")
                End If
                grdEstatus.Rows(value).Cells("Estatus").Value = ""
            Next

        End With
        grdEstatus.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

End Class