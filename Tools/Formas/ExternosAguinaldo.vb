Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Drawing

Public Class ExternosAguinaldo
    Public nave As String
    Public año As String
    Public dtExternos As DataTable
    Private Sub ExternosAguinaldo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargaDatosExterno()
        grdExternos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdExternos.DisplayLayout.Override.RowSelectorWidth = 20
        grdExternos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

        grdExternos.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdExternos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grdExternos.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grdExternos.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
    End Sub

    Public Sub CargaDatosExterno()
        grdExternos.DataSource = dtExternos
        disenioGrid()
    End Sub


    Public Sub disenioGrid()
        With grdExternos.DisplayLayout.Bands(0)
            .Columns("Colaborador").Width = 250
            .Columns("Nave").Width = 130
            .Columns("Total").Width = 100
        End With

        SumarizarColumnaGrid(grdExternos, 2, "Totales")

    End Sub

    Public Sub SumarizarColumnaGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal Index As Integer, ByVal Key As String)
        Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns(Index)
        Dim summary As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add(Key, SummaryType.Sum, columnToSummarize)
        summary.DisplayFormat = "{0:###,###,##0}"
        summary.Appearance.TextHAlign = HAlign.Left
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = ""
    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

End Class