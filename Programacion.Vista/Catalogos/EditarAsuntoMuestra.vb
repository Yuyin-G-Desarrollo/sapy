Public Class EditarAsuntoMuestraForm
    Dim idAsuntoMuestra As Int32

    Public Sub EditarAsuntoMuestra()
        Dim entidadAsuntoM As New Entidades.AsuntosMuestras
        Dim AsuntoMNegocios As New Programacion.Negocios.AsuntosMuestrasBU
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        entidadAsuntoM.Descripcion = txtDescripcion.Text
        entidadAsuntoM.AsuntoMuestraId = idAsuntoMuestra
        If (rdoActivo.Checked = True) Then
            entidadAsuntoM.Activo = True
        ElseIf (rdoInactivo.Checked = True) Then
            entidadAsuntoM.Activo = False
        End If

        AsuntoMNegocios.EditarAsuntoMuestra(entidadAsuntoM, usuario)

    End Sub


    Public Function ValidarVacio() As Boolean
        If (txtDescripcion.Text = Nothing) Then
            lblDescripcion.ForeColor = Drawing.Color.Red
            Return False
        Else
            lblDescripcion.ForeColor = Drawing.Color.Black
            Return True
        End If
        Return True
    End Function

    Public Sub recibirDatos(ByVal entidadAsuntoMuestra As Entidades.AsuntosMuestras)
        If (entidadAsuntoMuestra.Activo = True) Then
            rdoActivo.Checked = True
        ElseIf (entidadAsuntoMuestra.Activo = False) Then
            rdoInactivo.Checked = True
        End If
        idAsuntoMuestra = entidadAsuntoMuestra.AsuntoMuestraId
        txtCodigo.Text = entidadAsuntoMuestra.AsuntoMuestraId
        txtDescripcion.Text = entidadAsuntoMuestra.Descripcion
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (ValidarVacio() = True) Then
            Dim objMensajeQ As New ConfirmarForm
            objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
            If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                EditarAsuntoMuestra()
                Dim mensaje As New ExitoForm
                mensaje.mensaje = "El registro se realizó con éxito."
                mensaje.ShowDialog()
                Me.Close()
            Else
            End If

        ElseIf (ValidarVacio() = False) Then
            Dim mensaje As New AdvertenciaForm
            mensaje.mensaje = "Los campos marcados en rojo deben ser completados."
            mensaje.ShowDialog()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


End Class