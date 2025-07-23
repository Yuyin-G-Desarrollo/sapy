Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports Infragistics.Win
Imports System.Windows.Forms
Imports System.IO
Imports System.Xml
Imports Tools

Public Class MovimientosPolizaForm

    Public polizaID As Integer

    Private Sub MovimientosPolizaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        poblar_gridListaPolizasGeneradas(gridListaMovimientosPoliza)
    End Sub

    ''  ACCIONES GRID LISTA POLIZAS GENERADAS
    Public Sub poblar_gridListaPolizasGeneradas(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim objBU As New Negocios.PolizaBU
        Dim lista_movimientos_poliza As DataTable

        lista_movimientos_poliza = objBU.lista_movimientos_poliza(polizaID)

        grid.DataSource = lista_movimientos_poliza

        gridListaPolizasGeneradasDiseno(grid)

    End Sub

    Private Sub gridListaPolizasGeneradasDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        With grid.DisplayLayout
            .Bands(0).Columns(0).Hidden = True
            .Bands(0).Columns("pomo_rutaxml").Hidden = True
            .Bands(0).Columns("pomo_rutapdf").Hidden = True
            .Bands(0).Columns("Cargo").Format = Format("N2")
            .Bands(0).Columns("Cargo").CellAppearance.TextHAlign = HAlign.Right
            .Bands(0).Columns("Abono").Format = Format("N2")
            .Bands(0).Columns("Abono").CellAppearance.TextHAlign = HAlign.Right
            .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectors = DefaultableBoolean.True
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.FilterUIType = FilterUIType.FilterRow
            .Override.AllowAddNew = AllowAddNew.No
            .Override.AllowDelete = DefaultableBoolean.False
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If

    End Sub

    Private Sub gridListaPolizasGeneradas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridListaMovimientosPoliza.KeyPress

        If e.KeyChar = ChrW(Keys.Escape) Then
            poblar_gridListaPolizasGeneradas(gridListaMovimientosPoliza)
            gridListaMovimientosPoliza.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        End If

    End Sub

    Private Sub gridListaPolizasGeneradas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gridListaMovimientosPoliza.MouseDoubleClick

        If gridListaMovimientosPoliza.ActiveRow Is Nothing Then Return

        Dim row As UltraGridRow = gridListaMovimientosPoliza.ActiveRow

        If row Is Nothing Then Return
        Try
            Dim ruta As String = CStr(row.Cells("pomo_rutaxml").Value)
            Process.Start(ruta)
            ruta = ruta.Replace(".xml", ".pdf")
            Process.Start(ruta)
        Catch ex As Exception

        End Try


    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub



End Class