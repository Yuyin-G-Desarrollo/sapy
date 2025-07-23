Imports System.Drawing
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class ComprasPTIngresado_ArticulosFaltantesenSAPForm
    Private Sub ComprasPTIngresado_ArticulosFaltantesenSAPForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTitulo.Text = "Artículos Faltantes en SAP"
        diseñoGrid()
    End Sub

    Private Sub diseñoGrid()

        With grdArticulosFaltantesenSAP.DisplayLayout
            .Bands(0).Columns(0).Header.Caption = "ID Artículo"
            .Bands(0).Columns(1).Header.Caption = "Artículo"
            .Bands(0).Columns(2).Hidden = True
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Bands(0).Columns("ID").CellActivation = Activation.NoEdit
            .Bands(0).Columns("Articulo").CellActivation = Activation.NoEdit
            .Bands(0).Columns("ID").Width = 18
            .Override.AllowAddNew = AllowAddNew.No
            .Override.AllowRowFiltering = DefaultableBoolean.True
        End With

        Me.Top = (Me.Owner.Height - Me.Height) / 2
        Me.Left = (Me.Owner.Width - Me.Width) / 2
    End Sub
End Class