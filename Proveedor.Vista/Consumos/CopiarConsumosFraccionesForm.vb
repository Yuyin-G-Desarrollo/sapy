Imports Proveedores.BU
Imports Infragistics.Win.UltraWinGrid

Public Class CopiarConsumosFraccionesForm

    Private Sub CopiarConsumosFraccionesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarTablaConsumos()
    End Sub

    Public Sub llenarTablaConsumos()
        Dim obj As New ConsumosBU
        Dim dtTablaConsumos As DataTable
        dtTablaConsumos = obj.tablaConsumos
        grdConsumos.DataSource = dtTablaConsumos
        diseñoGrid()
    End Sub

    Public Sub diseñoGrid()
        With grdConsumos.DisplayLayout.Bands(0)

            .Columns("Lotear").Hidden = True
            .Columns("Explosionar").Hidden = True

            .Columns("Bloq").Header.Caption = " "

            .Columns("Bloq").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Bloq").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Bloq").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Bloq").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            '.Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            '.Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            '.Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            '.Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdConsumos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

    End Sub

End Class