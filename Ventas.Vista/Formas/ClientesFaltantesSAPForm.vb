Imports DevExpress.XtraGrid.Views.Grid

Public Class ClientesFaltantesSAPForm
    Private Sub ClientesFaltantesSAPForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        diseñoGridClientesFaltantesSAP()
    End Sub
    Private Sub diseñoGridClientesFaltantesSAP()
        vwReporteClientesFaltantesSAP.Columns("Código").Width = 50
        vwReporteClientesFaltantesSAP.Columns("Razón Social").Width = 210
        vwReporteClientesFaltantesSAP.Columns("Dirección").Width = 360
        vwReporteClientesFaltantesSAP.Columns("Ciudad").Width = 120
        vwReporteClientesFaltantesSAP.Columns("Estado").Width = 120
        vwReporteClientesFaltantesSAP.Columns("Plazo").Width = 50
        vwReporteClientesFaltantesSAP.Columns("Cadena").Width = 120
        vwReporteClientesFaltantesSAP.IndicatorWidth = 30
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub vwReporteClientesFaltantesSAP_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwReporteClientesFaltantesSAP.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
End Class