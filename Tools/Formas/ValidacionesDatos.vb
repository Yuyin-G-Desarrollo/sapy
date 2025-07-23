Public Class ValidacionesDatos

    Public Shared Function quitarLetrasCadena(ByVal cadena As String) As String
        cadena = cadena.ToUpper.Replace("A", "").Replace("B", "").Replace("C", "").Replace("D", "").Replace("E", "").Replace("F", "").Replace("G", "").Replace("H", "").Replace("I", "").Replace("J", "").Replace("K", "").Replace("L", "").Replace("M", "").Replace("N", "").Replace("Ñ", "").Replace("O", "").Replace("P", "").Replace("Q", "").Replace("R", "").Replace("S", "").Replace("T", "").Replace("U", "").Replace("V", "").Replace("W", "").Replace("X", "").Replace("Y", "").Replace("Z", "")
        Return cadena
    End Function

    Public Shared Function soloNumeros(ByVal txt As TextBox, e As KeyPressEventArgs) As Boolean
        Dim Manejo As Boolean

        If Char.IsDigit(e.KeyChar) Then
            Manejo = False
        ElseIf Char.IsControl(e.KeyChar) Then
            Manejo = False
        Else
            Manejo = True
        End If
        Return Manejo
    End Function


    Public Shared Function soloNumeros(ByVal txt As MaskedTextBox, e As KeyPressEventArgs) As Boolean
        Dim Manejo As Boolean

        If Char.IsDigit(e.KeyChar) Then
            Manejo = False
        ElseIf Char.IsControl(e.KeyChar) Then
            Manejo = False
        Else
            Manejo = True
        End If
        Return Manejo
    End Function

    ''' <summary>
    ''' Compara dos fechas
    ''' </summary>
    ''' <param name="FechaInicio">Fecha Inicio</param>
    ''' <param name="FechaFin">Fecha Fin</param>
    ''' <returns> Si es menor a 0 la Fecha inicio es menor a FechaFin, Igual a 0 las fechas son iguales, Si es mayor a 0 las fecha de inicio es mayor a la fecha de fin. </returns>
    Public Shared Function ComparacionFechas(ByVal FechaInicio As Date, ByVal FechaFin As Date) As Integer
        Dim ResultadoComparacion As Integer = 0
        ResultadoComparacion = Date.Compare(CDate(FechaInicio.ToShortDateString), CDate(FechaFin.ToShortDateString))
        Return ResultadoComparacion
    End Function

End Class

