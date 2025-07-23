Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class TallasEnPartida

    Private detallePedidoID As String

    Sub New(detallePedidoIDRecibido As String)
        detallePedidoID = detallePedidoIDRecibido
        InitializeComponent()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub TallasEnPartida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objBU As New Negocios.ApartadosBU

        lblPedidoDetalle.Text = detallePedidoID

        Dim tabla_tallas As New DataTable
        grdTallasEnPartida.DataSource = Nothing

        tabla_tallas = objBU.consultaParesTallasPartidas(detallePedidoID)

        grdTallasEnPartida.DataSource = tabla_tallas
        grid_simple_diseño(grdTallasEnPartida)
    End Sub

    Private Sub grid_simple_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            '.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.None
            '.Override.RowSelectorWidth = pnlTextosRenglones.Width
            '.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.False
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            '.Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
            .Override.AllowColSizing = AllowColSizing.None
            .Override.AllowDelete = DefaultableBoolean.False
            .Override.HeaderClickAction = HeaderClickAction.Select
            .Bands(0).Columns("Numeración").Hidden = True
        End With

        For Each row In grid.Rows
            If row.Index <> 2 Then
                row.Activation = Activation.NoEdit
            End If
        Next

    End Sub

End Class