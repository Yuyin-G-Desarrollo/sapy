Public Class Nomina_TablaCalculoPrestacionesSAY
    Public Monto As Double
    Public Semanas As Integer

    Private Sub Nomina_TablaCalculoPrestacionesSAY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CalcularPrestacion()
    End Sub

    Public Sub CalcularPrestacion()
        Dim abono As Double = 0
        Dim fila As Integer = 0
        Dim controlSemanas As Integer = 1
        Dim TotalPagado As Double = 0
        Dim nSem As Integer = 0
        Dim Pagototal2 As Double = 0
        Dim totalInteres2 As Double = 0


        grdTablaAmortizacion.Rows.Clear()
        abono = Monto / Semanas
        fila = 0
        controlSemanas = 1

        While Semanas > 0

            TotalPagado = abono
            ' txtAbono.Text = TotalPagado.ToString("c")
            If Monto < abono Then
                Dim abonofinal As Double = Monto
                Monto = Monto - abonofinal
                TotalPagado = abonofinal + 0
                Me.grdTablaAmortizacion.Rows.Insert(fila, controlSemanas, abonofinal, TotalPagado, Monto)
                Monto = 0
                Semanas = 0
                controlSemanas = controlSemanas + 1
            Else

                Monto = Monto - abono
                Me.grdTablaAmortizacion.Rows.Insert(fila, controlSemanas, abono, TotalPagado, Monto)
                Semanas = Semanas - 1
                controlSemanas = controlSemanas + 1
                'End If
            End If
            fila += 1

        End While

        Dim totalAbono2 As Double = 0
        Pagototal2 = 0
        Dim contadorFilas As Integer = 0

        For Each row As DataGridViewRow In grdTablaAmortizacion.Rows
            totalAbono2 += row.Cells("clmAbonoACapital").Value
            Pagototal2 += row.Cells("clmTotal").Value
            contadorFilas += 1

        Next

        grdTablaAmortizacion.Rows.Add("", totalAbono2, Pagototal2, "")
        grdTablaAmortizacion.Rows(contadorFilas).DefaultCellStyle.BackColor = Color.GreenYellow

    End Sub

End Class