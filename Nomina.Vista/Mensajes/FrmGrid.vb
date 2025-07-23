Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class FrmGrid
    Public titulo As String = String.Empty
    Public mensaje As String = String.Empty
    Public dtlistado As New DataTable

    Private Sub FrmGrid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = titulo
        lblMensaje.MaximumSize = pnlMensaje.Size
        lblMensaje.Text = mensaje
        'cargarListado()
    End Sub

    Public Sub cargarListado()
        Dim objMsjError As New ErroresForm
        grdListado.DataSource = Nothing
        Try
            If Not dtlistado Is Nothing Then
                grdListado.DataSource = dtlistado
                disenioGrid()
            End If
        Catch ex As Exception
            objMsjError.mensaje = "Error al cargar el listado"
            objMsjError.ShowDialog()
        End Try
    End Sub

    Private Sub disenioGrid()
        For Each col As UltraGridColumn In grdListado.DisplayLayout.Bands(0).Columns
            col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            col.CharacterCasing = CharacterCasing.Upper
        Next

        grdListado.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        'grdListado.DisplayLayout.Bands(0).Columns("#").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grdListado.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListado.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdListado.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListado.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        grdListado.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    End Sub

    Public Sub columnaAlinearDerecha(ByVal columna As String)
        Try
            grdListado.DisplayLayout.Bands(0).Columns(columna).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        Catch ex As Exception

        End Try
    End Sub

    Public Sub columnaFormatoPesos(ByVal columna As String)
        Try
            grdListado.DisplayLayout.Bands(0).Columns(columna).Format = "$##,##0.00"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub
End Class