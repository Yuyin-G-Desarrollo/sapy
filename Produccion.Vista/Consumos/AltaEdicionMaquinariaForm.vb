Imports Produccion.Negocios
Imports Tools

Public Class AltaEdicionMaquinariaForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Public id As Integer = 0
    Public maquinaria As String = ""
    Public idmaquinqrias As Integer = 0
    Public activo As Integer = 0
    Public modificar As Integer = 0
    Public nave As Integer = 0

    Private Sub AltaEdicionMaquinariaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If modificar <> 0 Then
            txtID.Text = id
            txtMaquinaria.Text = maquinaria
            txtIDMaquinaria.Text = id
            If activo = 1 Then
                rdoSi.Checked = True
            Else
                rdoNo.Checked = True
                txtMaquinaria.Enabled = False
            End If

        Else
            txtID.Text = ""
            txtMaquinaria.Text = ""
            rdoSi.Checked = True
            txtIDMaquinaria.Text = ""
            rdoNo.Enabled = False
        End If
        txtMaquinaria.CharacterCasing = Windows.Forms.CharacterCasing.Upper
    End Sub

    Private Sub btnLimipar_Click(sender As Object, e As EventArgs) Handles btnLimipar.Click
        txtID.Text = ""
        txtMaquinaria.Text = ""
        rdoSi.Checked = True
        txtIDMaquinaria.Text = ""
        modificar = 0
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Public Sub guardarMaquinaria()
        Dim entidad As New Entidades.Maquinaria
        Dim obj As New catalagosBU

        entidad.maq_descripcion = txtMaquinaria.Text
        entidad.maq_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        If rdoSi.Checked = True Then
            entidad.maq_activo = 1
        Else
            entidad.maq_activo = 0
        End If
        obj.GuardarMaquinaria(entidad)
        objExito.mensaje = "Maquinaria registrada con éxito"
        objExito.StartPosition = FormStartPosition.CenterScreen
        objExito.ShowDialog()
    End Sub

    Public Sub ModificarMaquinaria()
        Dim entidad As New Entidades.Maquinaria
        Dim obj As New catalagosBU

        entidad.maq_descripcion = txtMaquinaria.Text
        entidad.maq_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        If rdoSi.Checked = True Then
            entidad.maq_activo = 1
        ElseIf rdoNo.Checked = True Then
            entidad.maq_activo = 0
        End If
        entidad.maq_maquinaid = txtIDMaquinaria.Text

        obj.ActualizarMaquinaria(entidad)
        objExito.mensaje = "Maquinaria modificada con éxito"
        objExito.StartPosition = FormStartPosition.CenterScreen
        objExito.ShowDialog()
    End Sub

    Public Function buscarMaquinariaRepetida() As Boolean
        Dim obj As New catalagosBU
        Dim tabla As New DataTable
        tabla = obj.buscarMaquinaria(txtMaquinaria.Text)
        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If modificar = 0 Then
            If txtMaquinaria.Text = "" Or txtMaquinaria.Text = " " Then
                objAdvertencia.mensaje = "Ingrese maquinaria para poder registrarla"
                lblMaquinaria.ForeColor = Drawing.Color.Red
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
            Else
                If buscarMaquinariaRepetida() = True Then
                    objAdvertencia.mensaje = "Ya hay un registro de maquinaria igual al que desea capturar"
                    objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                    objAdvertencia.ShowDialog()
                Else
                    guardarMaquinaria()
                    Me.Close()
                End If
            End If
        ElseIf modificar = 1 Then
            If txtMaquinaria.Text = "" Or txtMaquinaria.Text = " " Then
                objAdvertencia.mensaje = "Ingrese maquinaria para poder modificarla"
                lblMaquinaria.ForeColor = Drawing.Color.Red
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
            Else

                ModificarMaquinaria()
                Me.Close()

            End If
        End If
    End Sub

    Private Sub txtMaquinaria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMaquinaria.KeyPress
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