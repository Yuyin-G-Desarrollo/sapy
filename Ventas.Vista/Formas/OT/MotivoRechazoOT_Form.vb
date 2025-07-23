Public Class MotivoRechazoOT_Form

    Public totalParesConfirmados As Integer = 0
    Public FilasSeleccionadas As Integer = 0
    Public ventanaAdmonOT As AdministradorOT_Form
    Public otSeleccionadas As String = String.Empty
    Public dtResultadoVerificaPartidas As New DataTable()


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim confirmacion As New Tools.ConfirmarForm
        Dim ObjBU As New Negocios.OrdenTrabajoBU
        Dim splitOtSeleccionadas As New List(Of String)
        Dim dtResultadoRechazoOT As New DataTable
        Dim mensajePartidasNoRechazables As String = String.Empty
        Dim partidasNoRechazables As String = String.Empty
        Dim motivoRechazo As String = LTrim(RTrim(txtMotivoRechazoOT.Text))

        If totalParesConfirmados > 0 Then
            confirmacion.mensaje = "Todos los pares confirmados se perderán. "
        End If

        If FilasSeleccionadas = 1 Then
            confirmacion.mensaje = "Se rechazará una OT. " + confirmacion.mensaje + "¿Desea continuar?"
        Else
            confirmacion.mensaje = "Se rechazarán " + FilasSeleccionadas.ToString() + " OTs. " + confirmacion.mensaje + "¿Desea continuar?"
        End If

        If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then

            'dtResultadoVerificaPartidas = objBU.VerificarPartidasAntesRechazarOT(otSeleccionadas)

            splitOtSeleccionadas = otSeleccionadas.Split(",").ToList()

            'If dtResultadoVerificaPartidas.Rows.Count > 0 Then
            '    For Each row As DataRow In dtResultadoVerificaPartidas.Rows
            '        If mensajePartidasNoRechazables <> "" Then
            '            mensajePartidasNoRechazables += ","
            '        End If
            '        mensajePartidasNoRechazables += " " + row.Item("idotsay").ToString()
            '        partidasNoRechazables = row.Item("PartidasNoRechazables").ToString()
            '        splitOtSeleccionadas.Remove(row.Item("idotsay").ToString())
            '    Next

            '    otSeleccionadas = ""

            '    For Each ot As String In splitOtSeleccionadas
            '        If otSeleccionadas <> "" Then
            '            otSeleccionadas += ","
            '        End If
            '        otSeleccionadas += ot
            '    Next

            '    If otSeleccionadas <> "" Then
            '        dtResultadoRechazoOT = ObjBU.RechazarOT(otSeleccionadas, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, motivoRechazo)
            '    End If

            '    ventanaAdmonOT.show_message("Advertencia", mensajePartidasNoRechazables)
            'Else

            dtResultadoRechazoOT = ObjBU.RechazarOT(otSeleccionadas, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString(), motivoRechazo)

            'End If

            If Integer.Parse(dtResultadoRechazoOT.Rows(0).Item("resultadoRechazo").ToString()) = 1 Then
                ventanaAdmonOT.show_message("Exito", "Datos guardados correctamente")
                ventanaAdmonOT.MostrarInformacion(sender, e)
                Me.Close()
            Else
                ventanaAdmonOT.show_message("Advertencia", "No se pudo generar el rechazo de las OTs seleccionadas, intente de nuevo.")
                ventanaAdmonOT.MostrarInformacion(sender, e)
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class