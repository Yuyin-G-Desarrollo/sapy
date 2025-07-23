Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class CodigosCliente_ListaCodigosNoImportadosForm

    Public dtCodigos As New DataTable

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub

    Private Sub grdCodigosCliente_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdCodigosCliente.InitializeLayout
        With grdCodigosCliente


            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 50
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.RowSelectorAppearance.ForeColor = Color.Black

            .DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No

            .DisplayLayout.Bands(0).Columns("ProductoEstiloId").Hidden = True
            .DisplayLayout.Bands(0).Columns("Cant. Empaque").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            For Each columna As UltraGridColumn In grdCodigosCliente.DisplayLayout.Bands(0).Columns
                columna.CellActivation = Activation.NoEdit
            Next

        
        End With
    End Sub

    Private Sub CodigosCliente_ListaCodigosNoImportadosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdCodigosCliente.DataSource = dtCodigos
    End Sub

    Private Sub pnlCabecera_Paint(sender As Object, e As PaintEventArgs) Handles pnlCabecera.Paint

    End Sub

    Private Sub pnlPie_Paint(sender As Object, e As PaintEventArgs) Handles pnlPie.Paint

    End Sub
End Class