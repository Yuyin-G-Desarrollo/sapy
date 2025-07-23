Imports Infragistics.Win.UltraWinGrid

Public Class forroSeleccionRapido
    Dim idForro As Int32
    Dim forro As String

    Public Property PIdForro As Int32
        Get
            Return idForro
        End Get
        Set(value As Int32)
            idForro = value
        End Set
    End Property

    Public Property PForro As String
        Get
            Return forro
        End Get
        Set(value As String)
            forro = value
        End Set
    End Property

    Private Sub forroSeleccionRapido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarTablaForros()
    End Sub

    Public Sub LlenarTablaForros()
        Dim objFBU As New Programacion.Negocios.ForrosBU
        Dim dtListaForros As DataTable
        dtListaForros = objFBU.verComboForros
        
        Me.grdForros.DisplayLayout.Bands(0).Columns.Add("selectForro", "")
        Dim colckbFr As UltraGridColumn = grdForros.DisplayLayout.Bands(0).Columns("selectForro")
        colckbFr.Style = ColumnStyle.Image
        grdForros.DataSource = dtListaForros
        grdForros.DataBind()

        With grdForros.DisplayLayout.Bands(0)
            .Columns("forr_forroid").Hidden = True
            .Columns("forr_codigo").Hidden = True
            .Columns("forr_descripcion").Header.Caption = "Forros"
            .Columns("forr_descripcion").CellActivation = Activation.NoEdit
            .Columns("selectForro").Header.VisiblePosition = 0
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdForros.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        For Each row As UltraGridRow In grdForros.Rows
            row.Cells("selectForro").Value = False
        Next
    End Sub

    Private Sub grdForros_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdForros.ClickCell
        If e.Cell.Column.Key = "selectForro" And e.Cell.Row.Index <> grdForros.Rows.FilterRow.Index Then
            Dim fila As Int32 = e.Cell.Row.Index
            PIdForro = grdForros.Rows(fila).Cells("forr_forroid").Value.ToString
            PForro = grdForros.Rows(fila).Cells("forr_descripcion").Value.ToString
            Me.Close()
        End If
    End Sub

    Private Sub grdForros_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdForros.InitializeRow
        If e.Row.Cells.Exists("selectForro") Then
            e.Row.Cells("selectForro").Appearance.ImageBackground = Global.Programacion.Vista.My.Resources.Resources.seleccionar
        End If
    End Sub

End Class