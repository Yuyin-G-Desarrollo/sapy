Imports Programacion.Negocios
Imports Tools

Public Class Programacion_BalanceoNaves_HabilitarProgramasSICY
    Dim NumSemana As Integer
    Public Año As Integer

    Private Sub Programacion_BalanceoNaves_HabilitarProgramasSICY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nudAñoFin.Value = DatePart(DateInterval.Year, Now)
        NumSemana = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        nudSemanaInicio.Value = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        nudSemanaFinal.Value = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        nudSemanaFinal.TextAlign = HorizontalAlignment.Center
        nudSemanaInicio.TextAlign = HorizontalAlignment.Center
    End Sub

    Private Sub consultaUltimaSemanaDelAñoInicio(ByVal añoSeleccionado As Integer)
        Dim obj As New Programacion_MapaOcupacionBU
        Try
            Dim maximoSemana As Integer = obj.ConsultarUltimaSemanaAño(añoSeleccionado)
            nudSemanaInicio.Maximum = maximoSemana
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub consultaUltimaSemanaDelAñoFin(ByVal añoSeleccionado As Integer)
        Dim obj As New Programacion_MapaOcupacionBU
        Try
            Dim maximoSemana As Integer = obj.ConsultarUltimaSemanaAño(añoSeleccionado)
            nudSemanaFinal.Maximum = maximoSemana
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub nudSemanaInicio_ValueChanged(sender As Object, e As EventArgs) Handles nudSemanaInicio.ValueChanged
        If (nudSemanaInicio.Value > nudSemanaFinal.Value) Then
            nudSemanaFinal.Value = nudSemanaInicio.Value
        End If
    End Sub

    Private Sub nudSemanaFinal_ValueChanged(sender As Object, e As EventArgs) Handles nudSemanaFinal.ValueChanged
        If (nudSemanaInicio.Value > nudSemanaFinal.Value) Then
            nudSemanaInicio.Value = nudSemanaFinal.Value
        End If
    End Sub




    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New Tools.AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New Tools.AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New Tools.ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New BalanceoNavesBU
        Dim dtHabilitarProgramasSICY As New DataTable
        Dim confirmar As New ConfirmarForm
        Dim SemanaInicio As Integer = 0
        Dim Año As Integer = 0
        Dim SemanaFin As Integer = 0


        confirmar.mensaje = "¿Desea habilitar las semanas seleccionadas en SICY? Esta acción no podrá revertirse."
        If confirmar.ShowDialog() = DialogResult.OK Then

            SemanaInicio = nudSemanaInicio.Value
            SemanaFin = nudSemanaFinal.Value
            Año = nudAñoFin.Value

            dtHabilitarProgramasSICY = objBU.HabilitarProgramasSICY(SemanaInicio, SemanaFin, Año)
            show_message("Exito", "Se habilitaron los programas correctamente.")
            Me.Close()
        End If

    End Sub
End Class