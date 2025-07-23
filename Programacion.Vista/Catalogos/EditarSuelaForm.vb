Imports Tools

Public Class EditarSuelaForm
    Dim IdSuela As Int32
    Dim activo As Boolean
    Public Sub LlenarDatos(ByVal entidadSuela As Entidades.Suelas)
        IdSuela = Convert.ToInt32(entidadSuela.PIdSuela)
        activo = entidadSuela.PActivoSuela
        txtCodigo.Text = entidadSuela.PCodigoSuela
        txtDescripcion.Text = entidadSuela.PDescriopcionSuela
        If (entidadSuela.PActivoSuela = True) Then
            rdoActivo.Checked = True
        ElseIf (entidadSuela.PActivoSuela = False) Then
            rdoInactivo.Checked = True
        End If
    End Sub

    Public Sub guardarCambios()
        Dim objSBU As New Programacion.Negocios.SuelasBU
        Dim suelaEntidad As New Entidades.Suelas
        Dim usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        suelaEntidad.PIdSuela = IdSuela.ToString
        suelaEntidad.PCodigoSuela = txtCodigo.Text
        suelaEntidad.PDescriopcionSuela = txtDescripcion.Text
        If (rdoActivo.Checked = True) Then
            suelaEntidad.PActivoSuela = True
        ElseIf (rdoInactivo.Checked = True) Then
            suelaEntidad.PActivoSuela = False
        End If
        objSBU.editarSuela(suelaEntidad, usuario)
    End Sub

    Public Function validarRepetidos() As Boolean
        Dim objSBU As New Programacion.Negocios.SuelasBU
        Dim dtContadorRepetidos As DataTable
        Dim contador As Int32 = 0
        Dim codigo As String = txtCodigo.Text
        dtContadorRepetidos = objSBU.validarRepetidos(codigo)
        contador = Convert.ToInt32(dtContadorRepetidos.Rows(0)(0).ToString)
        If (contador >= 1) Then
            If (activo = False) Then
                If (rdoInactivo.Checked = True) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        End If
        Return True
    End Function

    Public Function validarExistenModelos() As Boolean
        Dim objSuelaNE As New Negocios.SuelasBU
        Dim dtSuelasModelos As New DataTable

        If rdoActivo.Checked = False Then
            dtSuelasModelos = objSuelaNE.validaExistenModelos(IdSuela)
        End If

        If dtSuelasModelos.Rows.Count > 0 Then
            Dim cadena As String = "Modelos: "
            For Each row As DataRow In dtSuelasModelos.Rows
                cadena += vbLf + row.Item(0).ToString + " " + row.Item(1).ToString
            Next
            MsgBox("La suela " + txtDescripcion.Text + " no puede ser inactivada, debido a que existen " + CStr(dtSuelasModelos.Rows.Count) + " modelos activos registrados con esta suela." + vbLf + cadena)
            Return False

        End If
        Return True
    End Function

    Public Function validaVacio() As Boolean
        If (txtDescripcion.Text = Nothing) Then
            lblDescripcion.ForeColor = Drawing.Color.Red
            Return False
        End If
        lblDescripcion.ForeColor = Drawing.Color.Black
        Return True
    End Function

    Private Sub EditarSuelaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblDescripcion.ForeColor = Drawing.Color.Black
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If validarExistenModelos() = True Then
            If (validarRepetidos() = True) Then
                If (validaVacio() = True) Then
                    Dim objMensajeQ As New ConfirmarForm
                    objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
                    If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                        guardarCambios()
                        Dim mensaje As New ExitoForm
                        mensaje.mensaje = "El registro se realizó con éxito."
                        mensaje.ShowDialog()
                        Me.Close()
                    Else
                    End If
                Else
                    Dim mensaje As New AdvertenciaForm
                    mensaje.mensaje = "Los campos marcados en rojo deben ser completados."
                    mensaje.ShowDialog()
                End If
            Else
                Dim mensaje As New AdvertenciaForm
                mensaje.mensaje = "No puede activar este registro debido a que el código se encuentra activo en otra suela."
                mensaje.ShowDialog()
            End If
        Else
        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or caracter = ChrW(Keys.Space) Or (caracter = "/") Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = (".")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtDescripcion.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub
End Class