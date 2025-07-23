Public Class ReplicaPermisosForm
    Private colaboradorOrigenId As String
    Private colaboradorOrigenNombre As String
    Private colaboradorDestinoId As String
    Private colaboradorDestinoNombre As String

    Private Sub btnBuscarUsuarioOrigen_Click(sender As Object, e As EventArgs) Handles btnBuscarUsuarioOrigen.Click
        Dim objColForm As New seleccionColaboradoForm
        Dim objDatos As New Negocios.PermisosUsuarioBU

        objColForm.ShowDialog()

        colaboradorOrigenId = objColForm.PidColaborador
        If (colaboradorOrigenId <> String.Empty) Then
            txtNombreColaboradorOrigen.Text = objColForm.PnombeColaborador
            txtUsuarioOrigen.Text = objDatos.TraerNombreUsuarioPermisosUsuario(colaboradorOrigenId)
        End If
        CambiarColorComponentesUsuarioOrigen()

    End Sub

    Private Sub btnBuscarUsuarioDestino_Click(sender As Object, e As EventArgs) Handles btnBuscarUsuarioDestino.Click
        Dim objColForm As New seleccionColaboradoForm
        Dim objDatos As New Negocios.PermisosUsuarioBU
        objColForm.ShowDialog()

        colaboradorDestinoId = objColForm.PidColaborador
        If (colaboradorDestinoId <> String.Empty) Then
            txtNombreColaboradorDestino.Text = objColForm.PnombeColaborador
            txtUsuarioDestino.Text = objDatos.TraerNombreUsuarioPermisosUsuario(colaboradorDestinoId)

        End If
        CambiarColorComponentesUsuarioDestino()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Guardar()
    End Sub

    Private Function ValidarUsuariosSeleccion() As Boolean

        If (colaboradorOrigenId <> "" And colaboradorDestinoId <> "") Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function ValidarUsuariosDiferentes() As Boolean

        If (Not colaboradorOrigenId.Equals(colaboradorDestinoId)) Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub CambiarColorComponentesUsuarioOrigen()
        If colaboradorOrigenId = String.Empty Then
            lblUsuarioOrigen.ForeColor = Color.Red
            lblColaboradorOrigen.ForeColor = Color.Red
        Else
            lblUsuarioOrigen.ForeColor = DefaultForeColor
            lblColaboradorOrigen.ForeColor = DefaultForeColor
        End If
    End Sub

    Private Sub CambiarColorComponentesUsuarioDestino()
        If colaboradorDestinoId = String.Empty Then
            lblUsuarioDestino.ForeColor = Color.Red
            lblColaboradorDestino.ForeColor = Color.Red
        Else
            lblUsuarioDestino.ForeColor = DefaultForeColor
            lblColaboradorDestino.ForeColor = DefaultForeColor
        End If
    End Sub



    Private Sub Guardar()

        If (ValidarUsuariosSeleccion()) Then
            If (ValidarUsuariosDiferentes()) Then

                Dim objPermisosUsuarios As New Negocios.PermisosUsuarioBU
                Dim idUsuarioOrigen = CInt(colaboradorOrigenId)
                Dim idUsuarioDestino = CInt(colaboradorDestinoId)

                Dim objConfirmarForm As New Tools.ConfirmarForm
                objConfirmarForm.mensaje = "¿Está seguro de replicar los permisos?"


                If objConfirmarForm.ShowDialog() = DialogResult.OK Then
                    objPermisosUsuarios.CopiarPermisosPermisosUsuario(idUsuarioOrigen, idUsuarioDestino)
                    Dim mensaje As New ExitoForm
                    mensaje.mensaje = "Se han replicado los permisos."
                    mensaje.ShowDialog()
                    Me.Close()
                End If

            Else
                Dim advMensaje As New AdvertenciaForm
                advMensaje.mensaje = "Los usuarios deben ser diferentes."
                advMensaje.ShowDialog()

            End If

        Else
            Dim advMensaje As New AdvertenciaForm
            advMensaje.mensaje = "Debe seleccionar los dos usuarios."
            advMensaje.ShowDialog()

        End If
    End Sub

End Class