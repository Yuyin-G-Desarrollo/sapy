Imports Entidades
Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ResumenMotivosAtrasos
    Public listaDiasAtrasados As New List(Of DiasAtrasadosDep)


    Private Sub ResumenMotivosAtrasos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarGrid()
    End Sub
    Private Sub llenarGrid()
        Dim table As New DataTable
        grdResumenAtrasos.DataSource = agruparDatosDeLista() 'Cuenta los dias de atraso por departamento y motivo de atraso
        With grdResumenAtrasos.DisplayLayout.Bands(0)
            .Columns("Corte").Format = "##,##0"
            .Columns("Corte").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Pespunte").Format = "##,##0"
            .Columns("Pespunte").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Montado y Adorno").Format = "##,##0"
            .Columns("Montado y Adorno").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Motivo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Corte").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Pespunte").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Montado y Adorno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        End With
        grdResumenAtrasos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdResumenAtrasos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdResumenAtrasos.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        Dim sum1 As UltraGridColumn = grdResumenAtrasos.DisplayLayout.Bands(0).Columns("Corte")
        Dim sum11 As SummarySettings = grdResumenAtrasos.DisplayLayout.Bands(0).Summaries.Add("TOTAL1", SummaryType.Sum, sum1)
        sum11.DisplayFormat = "{0:#,##0}"
        sum11.Appearance.TextHAlign = HAlign.Right
        Dim sum2 As UltraGridColumn = grdResumenAtrasos.DisplayLayout.Bands(0).Columns("Pespunte")
        Dim sum12 As SummarySettings = grdResumenAtrasos.DisplayLayout.Bands(0).Summaries.Add("TOTAL2", SummaryType.Sum, sum2)
        sum12.DisplayFormat = "{0:#,##0}"
        sum12.Appearance.TextHAlign = HAlign.Right
        Dim sum3 As UltraGridColumn = grdResumenAtrasos.DisplayLayout.Bands(0).Columns("Montado y Adorno")
        Dim sum13 As SummarySettings = grdResumenAtrasos.DisplayLayout.Bands(0).Summaries.Add("TOTAL3", SummaryType.Sum, sum3)
        sum13.DisplayFormat = "{0:#,##0}"
        sum13.Appearance.TextHAlign = HAlign.Right
        grdResumenAtrasos.DisplayLayout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False
    End Sub
    Function agruparDatosDeLista() As DataTable
        Dim tmplista As New List(Of DiasAtrasadosDep)
        Dim obj As New AtrasosBU
        Dim table = obj.ListaMotivosAtrasosDeProduccion() 'Regresa todos los motivos de atraso con dias de atraso 0
        'Recorre lista para contar los dias de atraso dependiendo del motivo y del departamento 
        For Each a As DiasAtrasadosDep In listaDiasAtrasados
            For Each r As DataRow In table.Rows
                If r(0) = a.motivoAtraso Then
                    If a.departamento = "CORTE" Then
                        r(1) = r(1) + a.diasAtrasados
                    End If
                    If a.departamento = "PESPUNTE" Then
                        r(2) = r(2) + a.diasAtrasados
                    End If
                    If a.departamento = "MONTADO Y ADORNO" Then
                        r(3) = r(3) + a.diasAtrasados
                    End If
                End If
            Next
        Next
        Return table
    End Function

    Private Sub btnExpCod_Click(sender As Object, e As EventArgs) Handles btnExpCod.Click
        ExportarGridAExcel()
    End Sub
    Private Sub ExportarGridAExcel()
        Dim sfd As New SaveFileDialog
        'sfd.DefaultExt = "xlsx"
        'sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        sfd.DefaultExt = "xls"
        sfd.Filter = "Excel Files|*.xls"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                ultGrid.Export(grdResumenAtrasos, fileName)
                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()

                Process.Start(fileName)
            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm
                objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub
End Class