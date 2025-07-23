Imports Tools

Public Class AltaTemporadaForm

    Public Sub GenerarCodigo()
        Dim objSBU As New Programacion.Negocios.TemporadasBU
        Dim dtContador As DataTable = objSBU.ContarFilasTemporadas
        Dim dtIdMaximo As DataTable = objSBU.VerMaximoIdTemporada
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

    Public Sub registrarTemporada()
        Dim objTBU As New Programacion.Negocios.TemporadasBU
        Dim entidadTemporada As New Entidades.Temporadas

        entidadTemporada.pCodigoTemporada = txtCodigo.Text
        entidadTemporada.pNombreTemporada = txtNombre.Text
        entidadTemporada.pAnioTemporada = txtAnio.Text
        If (rdoActivo.Checked = True) Then
            entidadTemporada.pActivoTemporada = True
        ElseIf (rdoInactivo.Checked = True) Then
            entidadTemporada.pActivoTemporada = False
        End If
        Dim usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        objTBU.RegistrarTemporada(entidadTemporada, usuario)
    End Sub

    Public Function validaVacio() As Boolean

        If (txtNombre.Text = Nothing) Then
            lblNombre.ForeColor = Drawing.Color.Red
            Return False
        End If
        If (txtAnio.Text = Nothing Or txtAnio.TextLength < 4 Or txtAnio.TextLength > 4) Then
            lblAnio.ForeColor = Drawing.Color.Red
            Return False
        End If

        Return True
    End Function

    Private Sub AltaTemporadaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblNombre.ForeColor = Drawing.Color.Black
        lblAnio.ForeColor = Drawing.Color.Black
        rdoActivo.Checked = True
        txtAnio.Text = String.Empty
        txtNombre.Text = String.Empty
        GenerarCodigo()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (validaVacio() = True) Then
            If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                registrarTemporada()
                Dim mensaje As New ExitoForm
                mensaje.mensaje = "El registro se realizó con éxito."
                mensaje.ShowDialog()
                Me.Close()
            Else
            End If
        Else
            Dim mensaje As New AdvertenciaForm
            mensaje.mensaje = "Los campos marcados en rojo deben ser completados correctamente."
            mensaje.ShowDialog()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtNombre.Text.Length < 50) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or caracter = ChrW(Keys.Space) Or (caracter = "-") Or (caracter = ("/")) Or (caracter = (".")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtNombre.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtAnio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAnio.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtAnio.Text.Length < 4) Then

            If (Char.IsDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtAnio.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

End Class