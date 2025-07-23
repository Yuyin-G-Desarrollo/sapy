Public Class frmEliminarCapacidad
    Public semana As Int32
    Public anio As Int32
    Public fecha As String
    Public accionPantalla As String

    Dim editarsemana As Boolean
    Dim editarFecha As Boolean

    Public Sub cambiarSemana()
        If editarsemana = True Then
            Dim objLBU As New Negocios.LineasProduccionBU
            Dim semanasadd As Int32 = (numSemana.Value) - 1
            'If semanasadd > 0 Then
            Dim fechaSemana As String = objLBU.consultaFechaSeleccionSemana(semanasadd, numAnio.Value)
            Dim diaSemana As String = CDate(fechaSemana).DayOfWeek.ToString
            Dim fechaSemanaPrimerDia As Date = Date.Now

            Select Case diaSemana
                Case "Sunday"
                    fechaSemanaPrimerDia = DateAdd(DateInterval.Day, -6, CDate(fechaSemana))
                Case "Monday"
                    fechaSemanaPrimerDia = DateAdd(DateInterval.Day, 0, CDate(fechaSemana))
                Case "Tuesday"
                    fechaSemanaPrimerDia = DateAdd(DateInterval.Day, -1, CDate(fechaSemana))
                Case "Wednesday"
                    fechaSemanaPrimerDia = DateAdd(DateInterval.Day, -2, CDate(fechaSemana))
                Case "Thursday"
                    fechaSemanaPrimerDia = DateAdd(DateInterval.Day, -3, CDate(fechaSemana))
                Case "Friday"
                    fechaSemanaPrimerDia = DateAdd(DateInterval.Day, -4, CDate(fechaSemana))
                Case "Saturday"
                    fechaSemanaPrimerDia = DateAdd(DateInterval.Day, -5, CDate(fechaSemana))
            End Select
            If DatePart(DateInterval.Year, CDate(fechaSemanaPrimerDia)) < numAnio.Value Then
                fechaSemanaPrimerDia = "01/01/" + numAnio.Value.ToString
            ElseIf DatePart(DateInterval.Year, CDate(fechaSemanaPrimerDia)) > numAnio.Value Then
                fechaSemanaPrimerDia = "31/12/" + numAnio.Value.ToString
            End If
            dttFecha.Value = fechaSemanaPrimerDia
        End If
        'End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objMAdv As New Tools.ConfirmarForm
        objMAdv.mensaje = "¿ Desea eliminar las capacidades de la semana capturada hasta finalizar el año ?" + vbCrLf + "Para volver a asignar capacidades utilice el botón Copiar Semana."
        If objMAdv.ShowDialog = Windows.Forms.DialogResult.OK Then
            semana = numSemana.Value
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            Me.DialogResult = Windows.Forms.DialogResult.None
        End If

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.None
        Me.Close()
    End Sub

    Private Sub numSemana_ValueChanged(sender As Object, e As EventArgs) Handles numSemana.ValueChanged
        editarFecha = False
        cambiarSemana()
        editarFecha = True
    End Sub

    Private Sub dttFecha_ValueChanged(sender As Object, e As EventArgs) Handles dttFecha.ValueChanged
        editarsemana = False
        If editarFecha = True Then
            Dim semanaSeleccion As Int32 = DatePart(DateInterval.WeekOfYear, dttFecha.Value).ToString
            Dim mesSeleccion As String = DatePart(DateInterval.Month, dttFecha.Value).ToString
            If semanaSeleccion > 52 And mesSeleccion = 1 Then
                semanaSeleccion = 1
            ElseIf semanaSeleccion > 52 And mesSeleccion > 1 Then
                semanaSeleccion = 52
            End If
            numSemana.Value = semanaSeleccion
        End If
        editarsemana = True
    End Sub

    Private Sub frmEliminarCapacidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblCelula.Text = accionPantalla
        editarsemana = False
        numSemana.Value = semana
        editarsemana = True
        editarFecha = False
        dttFecha.Value = Date.Now
        editarFecha = True
        numAnio.Value = anio
        dttFecha.MinDate = "01-01-" + anio.ToString
        dttFecha.MaxDate = "31-12-" + anio.ToString
        If anio = Date.Now.Year Then
            numSemana.Minimum = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
        End If
    End Sub

End Class