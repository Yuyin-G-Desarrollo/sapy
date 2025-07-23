Imports Programacion.Negocios
Imports Entidades
Imports Tools

Public Class Programacion_ColocacionSemanal_ConfiguracionPorcentajePromedioSemana_CalcularFechaEntrega

    Dim cerrar As Boolean = True

    Private Sub Programacion_ColocacionSemanal_ConfiguracionPorcentajePromedioSemana_CalcularFechaEntrega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObtenerPorcentajeActual()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtPromedioOcupacion.Text.ToString <> "" Then
            If IsNumeric(txtPromedioOcupacion.Text) = False Then
                MostrarMensaje(Mensajes.Notice, "El dato a guardar debe ser númerico")
            Else
                If Double.Parse(txtPromedioOcupacion.Text) < 0 Or Double.Parse(txtPromedioOcupacion.Text) >= 100 Then
                    MostrarMensaje(Mensajes.Notice, "El promedio de ocupación debe ser mayor a 0% y menor a 100%")
                Else
                    Dim objBU As New ClientesPrefGenBU
                    Dim resultado As DataTable
                    resultado = objBU.GuardarPorcentajePromedio(Double.Parse(txtPromedioOcupacion.Text), SesionUsuario.UsuarioSesion.PUserUsuarioid, SesionUsuario.UsuarioSesion.PIDColaboradorUser)

                    If resultado.Rows(0)("TipoMensaje").ToString = "Exito" Then
                        MostrarMensaje(Mensajes.Success, resultado.Rows(0)("Mensaje").ToString)
                        ObtenerPorcentajeActual()
                    Else
                        MostrarMensaje(Mensajes.Fault, resultado.Rows(0)("Mensaje").ToString)
                    End If

                End If
            End If
        Else
            MostrarMensaje(Mensajes.Warning, "No hay dato para guardar")
        End If
        cerrar = False
    End Sub

    Private Sub ObtenerPorcentajeActual()
        Dim objBU As New ClientesPrefGenBU
        lblPromedioActual.Text = objBU.ObtenerPorcentajePromedioActual(SesionUsuario.UsuarioSesion.PIDColaboradorUser).Rows(0)("PorcentajeActual").ToString + "%"
    End Sub

    Private Sub Programacion_ColocacionSemanal_ConfiguracionPorcentajePromedioSemana_CalcularFechaEntrega_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If cerrar = False Then
            e.Cancel = True
            cerrar = True
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtPromedioOcupacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPromedioOcupacion.KeyDown
        If e.KeyData = Keys.Enter Then
            btnGuardar_Click(Nothing, Nothing)
        End If
    End Sub

End Class