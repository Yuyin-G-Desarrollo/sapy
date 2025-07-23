Imports Tools

Public Class AltaEditarDepartamento
    Public cerrado As Integer = 0
    Dim adv As New AdvertenciaForm
    Public idNave As Integer = 0
    Private Sub AltaEditarDepartamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboNaves()
        cmbNave.SelectedValue = idNave
    End Sub
    Public Sub llenarComboNaves()
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNave.Items.Count = 2 Then
            cmbNave.SelectedIndex = 1
        End If
    End Sub
    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub
    Private Sub AltaEditarDepartamento_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If cerrado = 1 Then
            cerrado = 1 'se sabe que oprimió en el botón guardar
        Else
            cerrado = 0 ' se sabe que oprimió el boton cerrar
        End If
    End Sub
    Function validarCampos() As Boolean
        If txtDescripcion.Text.Trim.Length = 0 Then
            adv.mensaje = "La descripción es obligatoria."
            adv.ShowDialog()
            Return False
        End If
        If cmbNave.SelectedValue = 0 Then
            adv.mensaje = "La nave es obligatoria."
            adv.ShowDialog()
            Return False
        End If
        Return True
    End Function
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If validarCampos() Then
            cerrado = 1
            Me.Close()
        End If
    End Sub
End Class