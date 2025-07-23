Imports Programacion.Datos

Public Class FechaEntregaBU
    Public Function ObtenerOpcionDate(opcion As String) As Date
        Dim vFechaEntregaDA As New FechaEntregaDA
        Dim tabla As New DataTable
        Dim fecha As Date
        tabla = vFechaEntregaDA.ObtenerOpcionDate(opcion)
        For Each fila As DataRow In tabla.Rows
            fecha = CDate(fila("opci_valor_date"))
        Next
        Return fecha
    End Function

    Public Sub GuardarFechaEntrega(fecha As Date)
        Dim vFechaEntregaDA As New FechaEntregaDA
        vFechaEntregaDA.GuardarFechaEntrega(fecha)
    End Sub

    Public Function PrimerDiaSemana(ByVal año As Integer, ByVal semana As Integer) As DateTime
        Dim enero1 As New DateTime(año, 1, 1)

        Dim daysOffset As Integer = CInt(Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek) - CInt(enero1.DayOfWeek)
        Dim PrimerDia As DateTime = enero1.AddDays(daysOffset)
        Dim curCulture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
        Dim PrimerSemana As Integer = curCulture.Calendar.GetWeekOfYear(enero1, curCulture.DateTimeFormat.CalendarWeekRule, curCulture.DateTimeFormat.FirstDayOfWeek)
        If PrimerSemana < 1 Then
            semana -= 1
        End If
        Dim dia As Date = PrimerDia.AddDays(semana * 7)
        If dia.DayOfWeek = DayOfWeek.Sunday Then dia = dia.AddDays(1)
        Return dia
    End Function
End Class
