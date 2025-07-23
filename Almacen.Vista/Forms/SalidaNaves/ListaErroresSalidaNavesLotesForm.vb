Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaErroresSalidaNavesLotesForm

    Public lErrores As New List(Of String)
    Public IdSalidaNave As Integer
    Public Plataformas As Boolean ''TRUE PARA PLATAFORMAS, FALSE PARA CODIGOS CON ERROR
    Public IdNave As Integer

    Private Sub ListaErroresInventarioCiclicoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen

        If Plataformas = True Then
            Me.Text = "Plataformas"
            lblEncabezado.Text = "Plataformas"
            PoblarDetalleCarritos()
        Else
            cargar_grdCodigos()
        End If
    End Sub


    Private Sub PoblarDetalleCarritos()
        Dim objBU As New Negocios.EntradaProductoBU
        Dim dtTablaDetalleCarritos As New DataTable

        dtTablaDetalleCarritos = objBU.PoblarDetalleCarritos(IdSalidaNave, IdNave)

        grdCodigos.DataSource = dtTablaDetalleCarritos
    End Sub


    Private Sub cargar_grdCodigos()
        grdCodigos.DataSource = LErrores
    End Sub


    Private Sub grdCodigos_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdCodigos.InitializeLayout
        With grdCodigos
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns 'Ajusta todas las columnas a un tamaño igual.
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            .DisplayLayout.Override.AllowMultiCellOperations = AllowMultiCellOperation.Copy
            If Plataformas = False Then
                .DisplayLayout.Bands(0).Columns(0).Header.Caption = "Errores"
            End If

        End With
    End Sub


    Private Sub grdCodigos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdCodigos.BeforeRowsDeleted
        e.Cancel = True
    End Sub
End Class