Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class AlertaApartadosCancelados

    Public InicioDeSesion As Integer = 0

    Private Sub AlertaApartadosCancelados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargaApartadosPartidasCanceladosDia(2)
        cargaApartadosPartidasCanceladosDia(4)
        If grdApartadosCancelados.Rows.Count > 0 Or grdPartidasCanceladas.Rows.Count > 0 Then
            If grdApartadosCancelados.Rows.Count > 0 Then
                gridApartadosPartidasCancelarDiseño(grdApartadosCancelados)
            End If
            If grdPartidasCanceladas.Rows.Count > 0 Then
                gridApartadosPartidasCancelarDiseño(grdPartidasCanceladas)
            End If
        End If
        lblHoraEnvioAlerta.Text = Date.Now.ToString()

    End Sub

    Public Sub cargaApartadosPartidasCanceladosDia(ByVal tipoConsulta As Integer)
        Dim objBu As New Negocios.ApartadosBU
        Dim dtResultadoConsulta As New DataTable
        dtResultadoConsulta = objBu.consultaApartadosCanceladosDia(tipoConsulta)

        If tipoConsulta = 2 Then
            If dtResultadoConsulta.Rows.Count > 0 Then
                grdApartadosCancelados.DataSource = dtResultadoConsulta
            End If
        End If

        If tipoConsulta = 4 Then
            If dtResultadoConsulta.Rows.Count > 0 Then
                grdPartidasCanceladas.DataSource = dtResultadoConsulta
            End If
        End If

    End Sub

    Private Sub gridApartadosPartidasCancelarDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Bands(0).Columns("Apartado").Header.Caption = "Apartado"
        grid.DisplayLayout.Bands(0).Columns("Apartado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Apartado").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        If grid Is grdPartidasCanceladas Then
            grid.DisplayLayout.Bands(0).Columns("Partida").Header.Caption = "Partida"
            grid.DisplayLayout.Bands(0).Columns("Partida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Partida").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            grid.DisplayLayout.Bands(0).Columns("Producto").Header.Caption = "Producto"
            grid.DisplayLayout.Bands(0).Columns("Producto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        End If

        grid.DisplayLayout.Bands(0).Columns("PedidoSAY").Header.Caption = "PedidoSAY"
        grid.DisplayLayout.Bands(0).Columns("PedidoSAY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("PedidoSAY").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("OrdenCliente").Header.Caption = "OrdenCte"
        grid.DisplayLayout.Bands(0).Columns("OrdenCliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("Pares").Header.Caption = "Pares"
        grid.DisplayLayout.Bands(0).Columns("Pares").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Pares").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Pares").Format = "n0"

        grid.DisplayLayout.Bands(0).Columns("StatusAnterior").Header.Caption = "Status Anterior"
        grid.DisplayLayout.Bands(0).Columns("StatusAnterior").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("FCancelacion").Header.Caption = "FCancelación"
        grid.DisplayLayout.Bands(0).Columns("FCancelacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("FCancelacion").Format = "dd/MM/yyyy HH:mm:ss"

        grid.DisplayLayout.Bands(0).Columns("usuarioCancelo").Header.Caption = "Canceló"
        grid.DisplayLayout.Bands(0).Columns("usuarioCancelo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("Motivo").Header.Caption = "Motivo Cancelación"
        grid.DisplayLayout.Bands(0).Columns("Motivo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("ObservacionesCancelado").Header.Caption = "Observaciones"
        grid.DisplayLayout.Bands(0).Columns("ObservacionesCancelado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit


        ' grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No


        Dim summary1 As SummarySettings
        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Pares"))
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right



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

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub AlertaApartadosCancelados_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If grdApartadosCancelados.Rows.Count = 0 And grdPartidasCanceladas.Rows.Count = 0 And InicioDeSesion = 1 Then
            Me.Close()
        End If
    End Sub
End Class