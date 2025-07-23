Imports Tools
Imports Infragistics.Win
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Globalization
Imports DevExpress.Data

Public Class ReporteAlertasCalidadForm

    Dim objBU As New Negocios.ReporteEvaluacionCalidadNaveBU
    Dim SemanaActual As Integer = 0

    Private Sub ReporteAlertasCalidadForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            nudAño.Value = Date.Now.Year
            'SemanaActual = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
            SemanaActual = objBU.ObtenerNumeroSemana(nudAño.Value, Date.Now.ToShortDateString)
            nudSemanaInicio.Value = SemanaActual
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim DtResultado As New DataTable
        Dim Grupo As String = String.Empty
        Dim dtSemanas As DataTable

        Try
            Cursor = Cursors.WaitCursor
            If nudSemanaInicio.Value = SemanaActual Then
                objBU.GenerarInformaciónAlertarCalidadSemana(nudAño.Value, nudSemanaInicio.Value, Date.Now)
            End If

            dtSemanas = objBU.ConsultarDiasLaboralesSemana(nudAño.Value, nudSemanaInicio.Value)

            If rdoRVO.Checked = True Then
                Grupo = "RVO"
            ElseIf rdoFVO.Checked = True Then
                Grupo = "FVO"
            End If

            DtResultado = objBU.ConsultaInformaciónAlertasCalidadSemana(nudAño.Value, nudSemanaInicio.Value, Grupo)
            grdReporteAlertas.DataSource = DtResultado
            DiseñoGrid.DiseñoBaseGrid(viewReporteAlertas)

            viewReporteAlertas.OptionsView.AllowCellMerge = True
            viewReporteAlertas.Columns.ColumnByFieldName("NAVE").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True

            If dtSemanas.Rows.Count >= 1 Then
                viewReporteAlertas.Columns.ColumnByFieldName("1").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            Else
                viewReporteAlertas.Columns.ColumnByFieldName("1").Visible = False
            End If

            If dtSemanas.Rows.Count >= 2 Then
                viewReporteAlertas.Columns.ColumnByFieldName("2").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            Else
                viewReporteAlertas.Columns.ColumnByFieldName("2").Visible = False
            End If

            If dtSemanas.Rows.Count >= 3 Then
                viewReporteAlertas.Columns.ColumnByFieldName("3").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            Else
                viewReporteAlertas.Columns.ColumnByFieldName("3").Visible = False
            End If

            If dtSemanas.Rows.Count >= 4 Then
                viewReporteAlertas.Columns.ColumnByFieldName("4").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            Else
                viewReporteAlertas.Columns.ColumnByFieldName("4").Visible = False
            End If

            If dtSemanas.Rows.Count >= 5 Then
                viewReporteAlertas.Columns.ColumnByFieldName("5").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            Else
                viewReporteAlertas.Columns.ColumnByFieldName("5").Visible = False
            End If

            If dtSemanas.Rows.Count >= 6 Then
                viewReporteAlertas.Columns.ColumnByFieldName("6").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            Else
                viewReporteAlertas.Columns.ColumnByFieldName("6").Visible = False
            End If


            viewReporteAlertas.Columns.ColumnByFieldName("Total").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            viewReporteAlertas.Columns.ColumnByFieldName("Acumulado").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            viewReporteAlertas.Columns.ColumnByFieldName("Promedio").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            Dim contador As Integer = 1

            For Each Fila As DataRow In dtSemanas.Rows
                DiseñoGrid.EstiloColumna(viewReporteAlertas, contador, Fila.Item(0), True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "")
                contador += 1
            Next

            'DiseñoGrid.EstiloColumna(viewReporteAlertas, "1", setRangoSemana(nudAño.Value, nudSemanaInicio.Value, 1), True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "")
            'DiseñoGrid.EstiloColumna(viewReporteAlertas, "2", setRangoSemana(nudAño.Value, nudSemanaInicio.Value, 2), True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "")
            'DiseñoGrid.EstiloColumna(viewReporteAlertas, "3", setRangoSemana(nudAño.Value, nudSemanaInicio.Value, 3), True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "")
            'DiseñoGrid.EstiloColumna(viewReporteAlertas, "4", setRangoSemana(nudAño.Value, nudSemanaInicio.Value, 4), True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "")
            'DiseñoGrid.EstiloColumna(viewReporteAlertas, "5", setRangoSemana(nudAño.Value, nudSemanaInicio.Value, 5), True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "")
            'DiseñoGrid.EstiloColumna(viewReporteAlertas, "6", setRangoSemana(nudAño.Value, nudSemanaInicio.Value, 6), True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "")

            viewReporteAlertas.Columns.ColumnByFieldName("Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            viewReporteAlertas.Columns.ColumnByFieldName("Acumulado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric


            DiseñoGrid.EstiloColumna(viewReporteAlertas, "Total", "TOTAL", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
            DiseñoGrid.EstiloColumna(viewReporteAlertas, "Acumulado", "ACUMULADO", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
            DiseñoGrid.EstiloColumna(viewReporteAlertas, "Promedio", "PROMEDIO", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, True, DevExpress.Data.SummaryItemType.Custom, "{0:N0}")


            Cursor = Cursors.Default


        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            Cursor = Cursors.Default
        End Try


    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            Cursor = Cursors.WaitCursor
            ExportarExcel()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub ExportarExcel()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                Dim exportOptions = New XlsxExportOptionsEx()
                'AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then
                    If GridView1.GroupCount > 0 Then
                        grdReporteAlertas.ExportToXlsx(.SelectedPath + "\Datos_ReporteAlertasCalidad_" + fecha_hora + ".xlsx", exportOptions)
                    Else
                        grdReporteAlertas.ExportToXlsx(.SelectedPath + "\Datos_ReporteAlertasCalidad_" + fecha_hora + ".xlsx", exportOptions)
                    End If
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "Datos_ReporteAlertasCalidad_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_ReporteAlertasCalidad_" + fecha_hora + ".xlsx")
                End If
            End With

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Function ObtenerFormatoFecha(ByVal Semana As Integer, ByVal Año As Integer, ByVal DiaSemana As Integer) As String





    End Function

    Private Shared Function primerDíaSemana(ByVal year As Integer, ByVal weekOfYear As Integer, ByVal ci As System.Globalization.CultureInfo) As DateTime
        Dim jan1 As DateTime = New DateTime(year, 1, 1)
        Dim daysOffset As Integer = CInt(ci.DateTimeFormat.FirstDayOfWeek) - CInt(jan1.DayOfWeek)
        Dim firstWeekDay As DateTime = jan1.AddDays(daysOffset)
        Dim firstWeek As Integer = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek)

        If (firstWeek <= 1 OrElse firstWeek >= 52) AndAlso daysOffset >= -3 Then
            weekOfYear -= 1
        End If

        Return firstWeekDay.AddDays(weekOfYear * 7)
    End Function

    Private Function numeroSemana(ByVal time As DateTime) As Integer
        Dim day As DayOfWeek = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time)

        If day >= DayOfWeek.Monday AndAlso day <= DayOfWeek.Wednesday Then
            time = time.AddDays(3)
        End If

        Return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
    End Function

    'Private Function setRangoSemana(ByVal fecha As DateTime) As String
    '    Dim noSemana = numeroSemana(fecha)
    '    Dim semana = primerDíaSemana(If(noSemana = 52, fecha.AddYears(-1).Year, fecha.Year), noSemana, CultureInfo.CurrentCulture)
    '    Dim lunes = semana.AddDays(1)
    '    Dim domingo = semana.AddDays(7)
    '    Return String.Format("Semana {0} de {1} = {2}-{3}", noSemana, fecha.Year, lunes.ToShortDateString(), domingo.ToShortDateString())
    'End Function

    Private Function setRangoSemana(ByVal Año As Integer, ByVal NumeroSemana As Integer, ByVal DiaSemana As Integer) As String

        Dim semana = primerDíaSemana(Año, NumeroSemana, CultureInfo.CurrentCulture)
        'Dim lunes = semana.AddDays(1)
        'Dim domingo = semana.AddDays(7)
        Dim dia = semana.AddDays(DiaSemana)

        Return dia.ToShortDateString()

        'Return String.Format("Semana {0} de {1} = {2}-{3}", noSemana, fecha.Year, lunes.ToShortDateString(), domingo.ToShortDateString())
    End Function

    Private Sub viewReporteAlertas_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles viewReporteAlertas.CustomSummaryCalculate
        Try
            If e.IsTotalSummary Then

                Dim summary As DevExpress.XtraGrid.GridColumnSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridColumnSummaryItem)

                If summary.FieldName = "Promedio" Then
                    Dim view As GridView = TryCast(sender, GridView)
                    Dim Acumulado As Decimal = Convert.ToDecimal(view.Columns("Acumulado").SummaryItem.SummaryValue)
                    Dim Semana As Decimal = nudSemanaInicio.Value

                    If Semana > 0 Then
                        e.TotalValue = Math.Round((Acumulado / Semana), 2)
                    Else
                        e.TotalValue = 0
                    End If
                    e.TotalValueReady = True

                End If

            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub
End Class