Imports Proveedores.BU
Imports Infragistics.Win.UltraWinGrid

Public Class ListaDeNavesCopiarConsumoForm

    Public listaNaves As New List(Of Integer)

    Private Sub ListaDeNavesCopiarConsumoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarNaves()
        diseniogrdNaves()
    End Sub

    Public Sub LlenarNaves()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtListaNaves As New DataTable
        grdNaves.DataSource = Nothing
        dtListaNaves = objBU.ListaNavesCombo()
        grdNaves.DataSource = dtListaNaves
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub diseniogrdNaves()
        With grdNaves.DisplayLayout.Bands(0)
            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("ID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NOMBRE ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ID SICY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("ID").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ID SICY").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("ID").Width = 20
            .Columns(" ").Width = 20
            .Columns("NOMBRE ").Width = 200

            .Columns("ID SICY").Hidden = True
        End With
        grdNaves.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            For value = 0 To grdNaves.Rows.Count - 1
                If grdNaves.Rows(value).Cells(" ").Value = 1 Then
                    listaNaves.Add(grdNaves.Rows(value).Cells("ID").Text)
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class