Imports Infragistics.Win.UltraWinGrid

Public Class ModeloReferenciaFormRapido
    Private nombreModelo As String
    Private idProducto As String
    Public Property PnombreModelo As String
        Get
            Return nombreModelo
        End Get
        Set(ByVal value As String)
            nombreModelo = value
        End Set
    End Property

    Public Property PidProducto As String
        Get
            Return idProducto
        End Get
        Set(ByVal value As String)
            idProducto = value
        End Set
    End Property

    Private Sub ModeloReferenciaFormRapido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarTablaModelos()
    End Sub

    Private Sub LlenarTablaModelos()
        Dim objModelosReferencia As New Programacion.Negocios.ModeloReferenciaBU
        Dim dtDatosModelosReferencia As New DataTable
        dtDatosModelosReferencia = objModelosReferencia.VerListaModelosReferencia()

        Me.grdModelos.DisplayLayout.Bands(0).Columns.Add("selectModelo", "")
        Dim colckbCr As UltraGridColumn = grdModelos.DisplayLayout.Bands(0).Columns("selectModelo")
        colckbCr.Style = ColumnStyle.Image
        grdModelos.DataSource = dtDatosModelosReferencia

        With grdModelos.DisplayLayout.Bands(0)
            .Columns("marcaSAY").Header.Caption = "Marca "
            .Columns("ColeccionSAY").Header.Caption = "Colección"
            .Columns("ModeloSAY").Header.Caption = "Modelo"
            ' .Columns("ProductoEstiloId").CellActivation = Activation.NoEdit
            .Columns("marcaSAY").CellActivation = Activation.NoEdit
            .Columns("ColeccionSAY").CellActivation = Activation.NoEdit
            .Columns("ModeloSAY").CellActivation = Activation.NoEdit
            .Columns("selectModelo").Header.VisiblePosition = 0
            .Columns("selectModelo").Width = 30
            .Columns("marcaSAY").Width = 90
            .Columns("ColeccionSAY").Width = 152
            .Columns("ModeloSAY").Width = 60
            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        '      grdModelos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub grdModelos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdModelos.InitializeRow
        If e.Row.Cells.Exists("selectModelo") Then
            e.Row.Cells("selectModelo").Appearance.ImageBackground = Global.Programacion.Vista.My.Resources.Resources.seleccionar
        End If
    End Sub

    Private Sub grdModelos_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdModelos.ClickCell
        If e.Cell.Column.Key = "selectModelo" And e.Cell.Row.Index <> grdModelos.Rows.FilterRow.Index Then
            Dim fila As Int32 = e.Cell.Row.Index
            '    PidProducto = grdModelos.Rows(fila).Cells("ProductoEstiloId").Value.ToString
            PnombreModelo = grdModelos.Rows(fila).Cells("ModeloSAY").Value.ToString
            Me.Close()
        End If
    End Sub


End Class