Imports Tools

Public Class AltaSuelaForm

    Public Sub GenerarCodigo()
        Dim objSBU As New Programacion.Negocios.SuelasBU
        Dim dtContador As DataTable = objSBU.ContarFilasSuelas
        Dim dtIdMaximo As DataTable = objSBU.VerMaximoIdSuela
        Dim contador As Int32 = Convert.ToInt32(dtContador.Rows(0)(0).ToString)
        Dim idMaximo As Int32 = 0
        Dim idNuevo As Int32 = 0
        Dim idNuevoCadena As String = String.Empty

        If (contador >= 1) Then
            idMaximo = Convert.ToInt32(dtIdMaximo.Rows(0)(0).ToString)
            If (idMaximo < 99) Then
                idNuevo = idMaximo + 1
                If (idNuevo >= 1 And idNuevo <= 9) Then
                    idNuevoCadena = "0" + idNuevo.ToString
                    txtCodigo.Text = idNuevoCadena
                Else
                    txtCodigo.Text = idNuevo.ToString
                End If
            ElseIf (idMaximo >= 99) Then
                Dim dtCodigosDisponibles As DataTable
                dtCodigosDisponibles = objSBU.verCodigosDiscponibles
                idNuevoCadena = dtCodigosDisponibles.Rows(0)(0)
                txtCodigo.Text = idNuevoCadena
            End If
        Else
            idNuevoCadena = "01"
            txtCodigo.Text = idNuevoCadena
        End If
    End Sub

    Public Function validaVacio() As Boolean
        If (txtDescripcion.Text = Nothing) Then
            lblDescripcion.ForeColor = Drawing.Color.Red
            Return False
        End If
        Return True
    End Function

    Public Sub registrarSuela()
        Dim objSBU As New Programacion.Negocios.SuelasBU
        Dim entidadSuela As New Entidades.Suelas
        entidadSuela.PCodigoSuela = txtCodigo.Text
        entidadSuela.PDescriopcionSuela = txtDescripcion.Text
        If (rdoActivo.Checked = True) Then
            entidadSuela.PActivoSuela = "True"
        ElseIf (rdoInactivo.Checked = True) Then
            entidadSuela.PActivoSuela = "False"
        End If
        Dim usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        objSBU.registraSuela(entidadSuela, usuario)
    End Sub


    Private Sub AltaSuelaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblDescripcion.ForeColor = Drawing.Color.Black
        txtDescripcion.Text = String.Empty
        rdoActivo.Checked = True
        GenerarCodigo()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (validaVacio() = True) Then
            If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                registrarSuela()
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
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or caracter = ChrW(Keys.Space) Or (caracter = "/") Or (caracter = ("-")) Or (caracter = (".")) Then
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class