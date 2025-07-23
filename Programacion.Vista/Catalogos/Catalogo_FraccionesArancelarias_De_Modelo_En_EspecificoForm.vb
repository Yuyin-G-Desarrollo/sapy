Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class Catalogo_FraccionesArancelarias_De_Modelo_En_EspecificoForm

    Public objFraccion_Detalle As New Entidades.Fracciones_Arancelarias_Detalles
    Public IdCorrida As Integer
    Public Modelo_Corrida As String

    Private Sub Catalogo_FraccionesArancelarias_De_Modelo_En_EspecificoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblEncabezado.Text = Modelo_Corrida
        PoblarTablaTallas()
    End Sub


    Private Sub PoblarTablaTallas()
        Dim objBU As New Negocios.FraccionesArtancelariasBU
        Dim dtTablaGrid As New DataTable

        Try
            dtTablaGrid = objBU.ListaFracciones_De_Detalle_SoloConsulta(IdCorrida, objFraccion_Detalle)
            gridFraccionesArancelarias.DataSource = dtTablaGrid
        Catch ex As Exception
            Dim objErrores As New ErroresForm
            objErrores.StartPosition = FormStartPosition.CenterScreen
            objErrores.mensaje = "Ocurrio un error al momento de consultar Las tallas de la corrida seleccionada. Erro: " + ex.Message
            objErrores.ShowDialog()
        End Try
    End Sub


    Private Sub gridFraccionesArancelarias_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridFraccionesArancelarias.InitializeLayout
        Diseno_Grid(gridFraccionesArancelarias)
    End Sub

    ''' <summary>
    ''' LE DA EL DISEÑO DE APARIENCIA AL GRID TALLAS
    ''' </summary>
    ''' <param name="Grid"></param>
    ''' <remarks></remarks>
    Private Sub Diseno_Grid(ByVal Grid As UltraGrid)
        With Grid
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        End With
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class