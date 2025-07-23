Imports Programacion.Negocios
Imports Tools

Public Class FechaEntregaForm

    Private Listo As Boolean = False

    Private Sub FechaEntregaForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        CargarOpcion()

        nudAño.Minimum = Now.Year
        nudAño.Maximum = nudAño.Minimum + 1
        Listo = True

        Semana()

    End Sub

    Private Sub dtpFechaEntrega_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaEntrega.ValueChanged
        Semana()
        'If Not Listo Then Exit Sub
        'GuardarOpcion()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs)
        GuardarOpcion()
    End Sub

    Private Sub nudAño_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudAño.ValueChanged
        CalcularSemana()
    End Sub

    Private Sub nudSemana_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudSemana.ValueChanged
        CalcularSemana()
    End Sub

    Private Sub FechaEntregaForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Semana()
    End Sub

    Private Sub btnGuardar_Click_1(sender As Object, e As EventArgs) Handles btnGuardar.Click
        GuardarOpcion()
    End Sub

    Private Sub CargarOpcion()
        Dim vFechaEntregaBU As New FechaEntregaBU
        dtpFechaEntrega.Value = vFechaEntregaBU.ObtenerOpcionDate("FechaEntrega")
    End Sub

    Private Sub GuardarOpcion()
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim vExitoForm As New ExitoForm
        Dim vErrorForm As New ErroresForm
        Dim vConfirmarForm As New ConfirmarForm
        Dim vFechaEntregaBU As New FechaEntregaBU
        Dim vFecha As Date
        If Listo Then
            vConfirmarForm.Text = "Fecha de entrega"
            vConfirmarForm.mensaje = "¿ Desea actualizar la fecha de entrega ?"
            Dim vDialogResult As New DialogResult
            vDialogResult = vConfirmarForm.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then
                Try
                    vFecha = dtpFechaEntrega.Value
                    If vFecha > Now Then
                        vFechaEntregaBU.GuardarFechaEntrega(vFecha)
                        vExitoForm.Text = "Fecha de entrega"
                        vExitoForm.mensaje = "Registro guardado"
                        vExitoForm.ShowDialog()
                    Else
                        vAdvertenciaForm.Text = "Fecha de entrega"
                        vAdvertenciaForm.mensaje = "No puede seleccionar una fecha inferior a la fecha actual"
                        vAdvertenciaForm.ShowDialog()
                    End If
                    'Me.Close()
                Catch ex As Exception
                    vErrorForm.Text = "Fecha de entrega"
                    vErrorForm.mensaje = ex.Message
                    vErrorForm.ShowDialog()
                End Try
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Semana()
        If Not Listo Then Exit Sub
        lblSemanaValor.Text = DatePart(DateInterval.WeekOfYear, dtpFechaEntrega.Value)
        Listo = False
        Try
            nudAño.Value = DatePart(DateInterval.Year, dtpFechaEntrega.Value)
            nudSemana.Value = DatePart(DateInterval.WeekOfYear, dtpFechaEntrega.Value)
        Catch ex As Exception
            Listo = True
        End Try
        Listo = True
    End Sub

    Private Sub CalcularSemana()
        Dim vErrorForm As New ErroresForm
        Dim vFechaEntregaBU As New FechaEntregaBU
        If Not Listo Then Exit Sub
        Try
            dtpFechaEntrega.Value = vFechaEntregaBU.PrimerDiaSemana(nudAño.Value, nudSemana.Value)
        Catch ex As Exception
            vErrorForm.Text = ex.Message
            vErrorForm.ShowDialog()
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class