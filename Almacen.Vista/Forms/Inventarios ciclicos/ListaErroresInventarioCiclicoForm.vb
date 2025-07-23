Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaErroresInventarioCiclicoForm
    Public arrCodigosError As New ArrayList()

    Private Sub ListaErroresInventarioCiclicoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        cargar_grdCodigos()

    End Sub
    Private Sub cargar_grdCodigos()
        grdCodigos.DataSource = arrCodigosError
    End Sub

    Private Sub grdCodigos_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdCodigos.InitializeLayout
        With grdCodigos
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns 'Ajusta todas las columnas a un tamaño igual.
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            .DisplayLayout.Override.AllowMultiCellOperations = AllowMultiCellOperation.Copy
        End With
    End Sub

    Private Sub grdCodigos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdCodigos.BeforeRowsDeleted
        e.Cancel = True
    End Sub
End Class