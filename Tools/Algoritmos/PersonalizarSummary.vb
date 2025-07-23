Imports Infragistics.Win.UltraWinGrid

Public Class PersonalizarSummary
    Implements ICustomSummaryCalculator

    Private totals As Decimal = 0
    Private columna As String = String.Empty

    Public Sub New()
    End Sub

    Public Sub New(ByVal nombreColumna As String)
        columna = nombreColumna
    End Sub

    Private Sub BeginCustomSummary(ByVal summarySettings As SummarySettings, ByVal rows As RowsCollection) Implements ICustomSummaryCalculator.BeginCustomSummary

        ' Begins the summary for the SummarySettings object passed in. Implementation of 
        ' this method should reset any state variables used for calculating the summary.
        Me.totals = 0

    End Sub

    Private Sub AggregateCustomSummary(ByVal summarySettings As SummarySettings, ByVal row As UltraGridRow) Implements ICustomSummaryCalculator.AggregateCustomSummary

        ' Here is where we process each row that gets passed in.

        Dim total As Object = row.GetCellValue(summarySettings.SourceColumn.Band.Columns(columna))


        ' Handle null values
        If total Is DBNull.Value Then
            Return
        End If

        ' Convert to decimal.
        Try
            Dim nUnitPrice As Decimal = Convert.ToDecimal(total.ToString.Replace("%", ""))


            Me.totals += nUnitPrice
        Catch e As Exception
            ' This should not happen if the columns are numeric.
            Debug.Assert(False, "Exception thrown while trying to convert cell's value to decimal !")
        End Try

    End Sub

    Private Function EndCustomSummary(ByVal summarySettings As SummarySettings, ByVal rows As RowsCollection) Implements ICustomSummaryCalculator.EndCustomSummary

        ' This gets called when the every row has been processed so here is where we
        ' would return the calculated summary value.
        Return Me.totals.ToString + "%"

    End Function
End Class
