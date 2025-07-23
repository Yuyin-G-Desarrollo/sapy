Imports Produccion.Negocios
Imports Tools

Public Class AltaEditarComponentesForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Public id As Integer = 0
    Public componente As String = ""
    Public activo As Integer = 0
    Public editar As Integer = 0

    Private Sub AltaEditarComponentesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If editar = 0 Then
            txtComponente.Text = ""
            txtID.Text = ""
            rdoSi.Checked = True
            rdoNo.Enabled = False
        Else
            txtComponente.Text = componente
            txtID.Text = id
            If activo = 1 Then
                rdoSi.Checked = True
                txtComponente.Enabled = False
            Else
                rdoNo.Checked = True
            End If
            If activo = 0 Then
                txtComponente.Enabled = False
            End If
        End If
        txtComponente.CharacterCasing = Windows.Forms.CharacterCasing.Upper
    End Sub

    Private Sub btnLimipar_Click(sender As Object, e As EventArgs) Handles btnLimipar.Click
        rdoSi.Checked = True
        txtComponente.Text = ""
        txtID.Text = ""
        editar = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnGuardarComponente_Click(sender As Object, e As EventArgs) Handles btnGuardarComponente.Click
        If txtComponente.Text <> "" Then
            If txtComponente.Text <> " " Then
                If txtID.Text = "" Then
                    If BuscarComponente() = True Then
                        guardarComponente()
                        Me.Close()
                    Else
                        objAdvertencia.mensaje = "Ya hay un componente igual a la captura"
                        objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                        objAdvertencia.ShowDialog()
                    End If
                Else
                    modificarComponente()
                    Me.Close()
                End If
            Else
                objAdvertencia.mensaje = "Ingrese algún componente valido"
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
                lblComponente.ForeColor = Drawing.Color.Red
            End If
        Else
            objAdvertencia.mensaje = "Ingrese algún componente"
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
            lblComponente.ForeColor = Drawing.Color.Red
        End If
    End Sub

    Public Sub guardarComponente()
        Dim obj As New ConsumosBU
        Dim listaComponentes As New DataTable
        Dim componente As New Entidades.Consumos

        componente.comp_descripcion = txtComponente.Text
        componente.comp_usuariocreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        If rdoSi.Checked = True Then
            componente.comp_activo = 1
        Else
            componente.comp_activo = 0
        End If
        obj.GuardarComponente(componente)
        objExito.mensaje = "Se guardo el componente con éxito"
        objExito.StartPosition = FormStartPosition.CenterScreen
        objExito.ShowDialog()

    End Sub

    Public Sub modificarComponente()
        Dim obj As New ConsumosBU
        Dim listaComponentes As New DataTable
        Dim componente As New Entidades.Consumos

        componente.comp_descripcion = txtComponente.Text
        componente.comp_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        If rdoSi.Checked = True Then
            componente.comp_activo = 1
        Else
            componente.comp_activo = 0
        End If
        componente.comp_idcomponente = txtID.Text
        obj.ModificarComponente(componente)
        objExito.mensaje = "Se realizo el cambio con éxito"
        objExito.StartPosition = FormStartPosition.CenterScreen
        objExito.ShowDialog()
    End Sub

    Public Function BuscarComponente()
        Dim obj As New ConsumosBU
        Dim listaComponentes As New DataTable
        Dim componente As New Entidades.Consumos
        listaComponentes = obj.ComponenteRepetido(txtComponente.Text)
        If listaComponentes.Rows.Count = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub txtComponente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComponente.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = ControlChars.Back Then
            e.Handled = False
        ElseIf e.KeyChar = " " Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub

End Class