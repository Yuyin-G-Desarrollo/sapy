Imports Infragistics.Win.UltraWinGrid

Public Class pielColorSeleccionRapido
    Dim idPiel As Int32
    Dim idColor As Int32
    Dim pielColor As String
    Dim SICY As String

    Public Property PIdPiel As Int32
        Get
            Return idPiel
        End Get
        Set(value As Int32)
            idPiel = value
        End Set
    End Property

    Public Property PIdColor As Int32
        Get
            Return idColor
        End Get
        Set(value As Int32)
            idColor = value
        End Set
    End Property

    Public Property PPielColor As String
        Get
            Return pielColor
        End Get
        Set(value As String)
            pielColor = value
        End Set
    End Property

    Public Property PSICY As String
        Get
            Return SICY
        End Get
        Set(value As String)
            SICY = value
        End Set
    End Property

    
    Private Sub pielColorSeleccionRapido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarTablaPielColor()
    End Sub

    Public Sub llenarTablaPielColor()
        Dim objPBU As New Programacion.Negocios.PielesBU
        Dim dtListaPieles As DataTable
        dtListaPieles = objPBU.VerPielGridProducto

        Me.grdPielColor.DisplayLayout.Bands(0).Columns.Add("selectPiCol", "")
        Dim colckbCr As UltraGridColumn = grdPielColor.DisplayLayout.Bands(0).Columns("selectPiCol")
        colckbCr.Style = ColumnStyle.Image
        grdPielColor.DataSource = dtListaPieles
        grdPielColor.DataBind()

        With grdPielColor.DisplayLayout.Bands(0)
            .Columns("pcsicy").Header.Caption = "SICY"
            .Columns("convinacionPC").Header.Caption = "Piel-Color"
            .Columns("convinacionPC").CellActivation = Activation.NoEdit
            .Columns("pcsicy").CellActivation = Activation.NoEdit
            .Columns("color_colorid").Hidden = True
            .Columns("piel_pielid").Hidden = True
            
            .Columns("piel_pielid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("color_colorid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("selectPiCol").Header.VisiblePosition = 0
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdPielColor.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub grdPielColor_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdPielColor.ClickCell
        If e.Cell.Column.Key = "selectPiCol" And e.Cell.Row.Index <> grdPielColor.Rows.FilterRow.Index Then
            Dim fila As Int32 = e.Cell.Row.Index
            PSICY = grdPielColor.Rows(fila).Cells("pcsicy").Value.ToString
            PIdColor = grdPielColor.Rows(fila).Cells("color_colorid").Value.ToString
            PIdPiel = grdPielColor.Rows(fila).Cells("piel_pielid").Value.ToString
            PPielColor = grdPielColor.Rows(fila).Cells("convinacionPC").Value.ToString
            Me.Close()
        End If
    End Sub

    Private Sub grdPielColor_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdPielColor.InitializeLayout

    End Sub

    Private Sub grdPielColor_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdPielColor.InitializeRow
        If e.Row.Cells.Exists("selectPiCol") Then
            e.Row.Cells("selectPiCol").Appearance.ImageBackground = Global.Programacion.Vista.My.Resources.Resources.seleccionar
        End If
    End Sub
End Class