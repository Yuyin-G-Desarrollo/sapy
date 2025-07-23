Imports Entidades
Imports Tools

Public Class Produccion_Borradores_ReplicarLotesSICY_SAYForm
    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New Negocios.ReportesBU
        Dim dtResultadoReplica As New DataTable
        Dim fechaInicio As String = String.Empty
        Dim fechaFin As String = String.Empty
        Dim nave As Integer = 0
        Dim resultadoReplica As String = String.Empty
        Dim mensajeReplica As String = String.Empty
        Dim errorReplica As String = String.Empty


        fechaInicio = dtpFechaInicio.Value.ToShortDateString
        fechaFin = dtpFechaFin.Value.ToShortDateString
        nave = cmbNave.SelectedValue

        'If nave = 0 Then

        '    Tools.MostrarMensaje(Tools.Mensajes.Warning, "Seleccione una nave")

        'Else

        '    objConfirmacion.mensaje = "El proceso puede tardar algunos segundos, ¿Desea continuar?"
        'If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
        Cursor = Cursors.WaitCursor
                dtResultadoReplica = objBU.ActualizaLotes_SICY_a_SAY(nave, fechaInicio, fechaFin)

                resultadoReplica = dtResultadoReplica.Rows(0).Item("Resultado").ToString
                mensajeReplica = dtResultadoReplica.Rows(0).Item("Mensaje").ToString
                errorReplica = dtResultadoReplica.Rows(0).Item("Error").ToString

                If resultadoReplica = "Exito" Then
                    objExito.mensaje = mensajeReplica
                    objExito.ShowDialog()
                ElseIf resultadoReplica = "Error" Then
                    objErrores.mensaje = mensajeReplica
                    If errorReplica <> "" Then
                        objErrores.mensaje += "  - " + errorReplica
                    End If
                    objErrores.ShowDialog()
                End If

        '    End If
        'End If

        Cursor = Cursors.Default

    End Sub

    Private Sub Produccion_Borradores_ReplicarLotesSICY_SAYForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarcomboNaves()
        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now

    End Sub

    Private Sub LlenarcomboNaves()
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

End Class