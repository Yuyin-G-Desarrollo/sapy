Imports Tools

Public Class AltaGrupoForm

    Public Sub generarIdNuevo()
        Dim grupoBU As New Programacion.Negocios.GruposBU
        Dim dtValidaExistenFilas As DataTable
        Dim dtMaximoIdGrupos As DataTable
        Dim idMaximo As Int32 = 0
        Dim nuevoId As Int32 = 0

        dtValidaExistenFilas = New DataTable
        dtValidaExistenFilas = grupoBU.VerFilasGruposBU()
        dtMaximoIdGrupos = New DataTable
        dtMaximoIdGrupos = grupoBU.VerIdMaximoGrupos

        Dim tamValidaExiste As Int32
        tamValidaExiste = dtValidaExistenFilas.Rows.Count
        If (tamValidaExiste < 1) Then
            nuevoId = 1
        ElseIf (tamValidaExiste >= 1) Then
            idMaximo = Convert.ToInt32(dtMaximoIdGrupos.Rows(0)(0).ToString)
            nuevoId = idMaximo + 1

        End If
        txtCodigo.Text = nuevoId.ToString
    End Sub

    Public Function ValidaVacio() As Boolean
        If (txtDescripcion.Text = Nothing) Then
            lblDescripcionGrp.ForeColor = Drawing.Color.Red
            Return False
        Else
            lblDescripcionGrp.ForeColor = Drawing.Color.Black
        End If
        Return True
    End Function

    Public Sub RegistrarGrupo()
        Dim GrupoNegocios As New Programacion.Negocios.GruposBU
        Dim entidadGrupo As New Entidades.Grupos
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        entidadGrupo.PGDescripcion = txtDescripcion.Text
        If (rdoActivo.Checked = True) Then
            entidadGrupo.PGActivo = True
        ElseIf (rdoInactivo.Checked = True) Then
            entidadGrupo.PGActivo = False
        End If

        GrupoNegocios.RegistrarGrupo(entidadGrupo)
    End Sub

    Private Sub AltaGrupoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDescripcion.Text = String.Empty
        'lblDescripcionGrp.ForeColor = Drawing.Color.Black
        rdoActivo.Checked = True
        generarIdNuevo()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If (ValidaVacio() = True) Then
            If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                RegistrarGrupo()
                Dim mensaje As New ExitoForm
                mensaje.mensaje = "El registro se realizó con éxito."
                mensaje.ShowDialog()
                Me.Close()
            Else
            End If

        ElseIf (ValidaVacio() = False) Then
            Dim mensaje As New AdvertenciaForm
            mensaje.mensaje = "Los campos marcados en rojo deben ser completados."
            mensaje.ShowDialog()
        End If

    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 100) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space) Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = ("."))) Then
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