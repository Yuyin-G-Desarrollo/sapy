Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class tallaSeleccionRapida
    Dim idCorrida As Int32
    Dim corrida As String

    Public Property PIdCorrida As Int32
        Get
            Return idCorrida
        End Get
        Set(value As Int32)
            idCorrida = value
        End Set
    End Property

    Public Property PCorrida As String
        Get
            Return corrida
        End Get
        Set(value As String)
            corrida = value
        End Set
    End Property

    Private Sub tallaSeleccionRapida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarTablaTallas()
    End Sub

    Public Sub LlenarTablaTallas()
        Dim objTBU As New Programacion.Negocios.TallasBU
        Dim dtListaTallas As New DataTable
        dtListaTallas = objTBU.verComboTallas
        Me.grdTallas.DisplayLayout.Bands(0).Columns.Add("selectTalla", "")
        Dim colckbTalla As UltraGridColumn = grdTallas.DisplayLayout.Bands(0).Columns("selectTalla")
        colckbTalla.Style = ColumnStyle.Image
        grdTallas.DataSource = dtListaTallas
        grdTallas.DataBind()

        With grdTallas.DisplayLayout.Bands(0)
            .Columns("talla_tallaid").Header.Caption = "Código"
            .Columns("talla_descripcion").Header.Caption = "Corrida"
            .Columns("talla_descripcion").CellActivation = Activation.NoEdit
            .Columns("talla_descripcion").CellAppearance.TextHAlign = HAlign.Right
            .Columns("talla_tallaid").CellActivation = Activation.NoEdit
            .Columns("talla_tallaid").CellAppearance.TextHAlign = HAlign.Right
            .Columns("selectTalla").Header.VisiblePosition = 0
            ' ''.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdTallas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        grdTallas.DisplayLayout.Bands(0).Columns("talla_tallaid").Width = 30
        grdTallas.DisplayLayout.Bands(0).Columns("selectTalla").Width = 30
    End Sub

    Private Sub grdTallas_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdTallas.ClickCell
        If e.Cell.Column.Key = "selectTalla" And e.Cell.Row.Index <> grdTallas.Rows.FilterRow.Index Then
            Dim fila As Int32 = e.Cell.Row.Index
            PIdCorrida = grdTallas.Rows(fila).Cells("talla_tallaid").Value.ToString
            PCorrida = grdTallas.Rows(fila).Cells("talla_descripcion").Value.ToString
            Me.Close()
        End If
    End Sub

    Private Sub grdTallas_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdTallas.InitializeRow
        If e.Row.Cells.Exists("selectTalla") Then
            e.Row.Cells("selectTalla").Appearance.ImageBackground = Global.Programacion.Vista.My.Resources.Resources.seleccionar
        End If
    End Sub
End Class