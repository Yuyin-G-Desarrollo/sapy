Imports System.Drawing
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class RelacionNavePatronForm

    Public patronID As Integer
    Public patronNombre As String

    Private Sub RelacionNavePatronForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarRelacionesNavePatron()
        lblPatron.Text = patronNombre

    End Sub

    Private Sub cargarRelacionesNavePatron()
        Dim objBU As New Negocios.RelacionNavePatronBU
        Dim dtRelaciones As New DataTable

        dtRelaciones = objBU.cargarNavesRelacion(patronID)
        grdNavePatron.DataSource = Nothing
        If Not dtRelaciones Is Nothing AndAlso dtRelaciones.Rows.Count > 0 Then
            grdNavePatron.DataSource = dtRelaciones
            formatoGrid()
        End If

    End Sub

    Public Sub formatoGrid()
        grdNavePatron.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdNavePatron.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False

        With grdNavePatron.DisplayLayout.Bands(0)
            .Override.CellClickAction = CellClickAction.RowSelect
            .Columns("Id").Hidden = True
        End With

        grdNavePatron.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdNavePatron.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdNavePatron.DisplayLayout.Override.RowSelectorWidth = 35
        grdNavePatron.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

        grdNavePatron.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        grdNavePatron.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.IncludeHeader)
        grdNavePatron.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdNavePatron.DisplayLayout.Bands(0).Columns("Nave").Width = 190

        grdNavePatron.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        grdNavePatron.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

        grdNavePatron.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

    End Sub

    Private Sub grdNavePatron_MouseDoubleClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles grdNavePatron.MouseDoubleClick
        If grdNavePatron.Selected.Rows.Count > 0 Then
            Dim objBU As New Negocios.RelacionNavePatronBU
            Try
                Dim naveId As Integer
                Dim relacionar As Boolean

                naveId = CInt(grdNavePatron.Selected.Rows(0).Cells("Id").Value)
                relacionar = CBool(grdNavePatron.Selected.Rows(0).Cells(2).Value)

                objBU.editarRelacion(patronID, naveId, Not relacionar)
                grdNavePatron.Selected.Rows(0).Cells(2).Value = Not relacionar

            Catch ex As Exception
                cargarRelacionesNavePatron()
            End Try
        End If
    End Sub

End Class