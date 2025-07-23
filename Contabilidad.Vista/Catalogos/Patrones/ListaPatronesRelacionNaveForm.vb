Imports System.Drawing
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class ListaPatronesRelacionNaveForm
    Private Sub ListaPatronesRelacionNaveForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarPatrones()
    End Sub

    Private Sub cargarPatrones()
        Dim objBU As New Negocios.RelacionNavePatronBU
        Dim dtPatrones As New DataTable

        dtPatrones = objBU.cargarListaPatrones
        If Not dtPatrones Is Nothing AndAlso dtPatrones.Rows.Count > 0 Then
            grdListaPatrones.DataSource = dtPatrones
            formatoGrid()
        End If
    End Sub

    Public Sub formatoGrid()
        grdListaPatrones.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdListaPatrones.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False

        With grdListaPatrones.DisplayLayout.Bands(0)
            .Override.CellClickAction = CellClickAction.RowSelect
            .Columns("ID").Hidden = True
            .Columns("PATRON").Header.Caption = "Patrón"

        End With

        grdListaPatrones.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdListaPatrones.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListaPatrones.DisplayLayout.Override.RowSelectorWidth = 35
        grdListaPatrones.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

        grdListaPatrones.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        grdListaPatrones.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.IncludeHeader)
        grdListaPatrones.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        grdListaPatrones.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        grdListaPatrones.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        grdListaPatrones.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

    End Sub

    Private Sub gridListaUsuarios_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles grdListaPatrones.MouseDoubleClick
        If grdListaPatrones.Selected.Rows.Count > 0 Then

            Dim form As New RelacionNavePatronForm
            form.MdiParent = Me.MdiParent
            form.patronID = CInt(grdListaPatrones.Selected.Rows(0).Cells("ID").Value)
            form.patronNombre = grdListaPatrones.Selected.Rows(0).Cells("PATRON").Value
            form.Show()

        End If
    End Sub

End Class