Imports Infragistics.Win.UltraWinGrid

Public Class suelaSeleccionRapido
    Dim IdSuela As Int32
    Dim suela As String

    Public Property PIdSuela As Int32
        Get
            Return IdSuela
        End Get
        Set(value As Int32)
            IdSuela = value
        End Set
    End Property

    Public Property PSuela As String
        Get
            Return suela
        End Get
        Set(value As String)
            suela = value
        End Set
    End Property

    Private Sub suelaSeleccionRapido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarTablaSuelas()
    End Sub

    Public Sub LlenarTablaSuelas()
        Dim objSBU As New Programacion.Negocios.SuelasBU
        Dim dtListaSuelas As DataTable
        dtListaSuelas = objSBU.verComboSuelas

        Me.grdSuela.DisplayLayout.Bands(0).Columns.Add("selectSuela", "")
        Dim colckbSl As UltraGridColumn = grdSuela.DisplayLayout.Bands(0).Columns("selectSuela")
        colckbSl.Style = ColumnStyle.Image
        grdSuela.DataSource = dtListaSuelas
        grdSuela.DataBind()

        With grdSuela.DisplayLayout.Bands(0)
            .Columns("suel_suelaid").Hidden = True
            .Columns("suel_codigo").Hidden = True
            .Columns("suel_descripcion").Header.Caption = "Suelas"
            .Columns("suel_descripcion").CellActivation = Activation.NoEdit
            .Columns("selectSuela").Header.VisiblePosition = 0
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdSuela.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        For Each row As UltraGridRow In grdSuela.Rows
            row.Cells("selectSuela").Value = False
        Next
    End Sub

    Private Sub grdSuela_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdSuela.ClickCell
        If e.Cell.Column.Key = "selectSuela" And e.Cell.Row.Index <> grdSuela.Rows.FilterRow.Index Then
            Dim fila As Int32 = e.Cell.Row.Index
            PIdSuela = grdSuela.Rows(fila).Cells("suel_suelaid").Value.ToString
            PSuela = grdSuela.Rows(fila).Cells("suel_descripcion").Value.ToString
            Me.Close()
        End If
    End Sub

    Private Sub grdSuela_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdSuela.InitializeRow
        If e.Row.Cells.Exists("selectSuela") Then
            e.Row.Cells("selectSuela").Appearance.ImageBackground = Global.Programacion.Vista.My.Resources.Resources.seleccionar
        End If
    End Sub
End Class