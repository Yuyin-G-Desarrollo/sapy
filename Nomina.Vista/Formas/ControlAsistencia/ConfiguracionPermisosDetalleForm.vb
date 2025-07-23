Imports Tools

Public Class ConfiguracionPermisosDetalleForm
    Dim objMotivo As New Entidades.ConfiguracionPermisos

    Public Sub load_infoMotivo(ByVal idConfigPermiso As Integer, ByVal consultar As Boolean)
        Dim objInfoMotivo As New Negocios.ConfiguracionPermisosBU

        objMotivo = objInfoMotivo.BuscarConfiguracionPermisos(idConfigPermiso)

        txtMotivo.Text = objMotivo.PConfiguracionPermisos_nombre
        lblIdConfPermiso.Text = objMotivo.PConfiguracionPermisos_id
        lblIdNave.Text = objMotivo.PConfiguracionPermisos_naveid

        If objMotivo.PConfiguracionPermisos_puntualidad_asistencia = 255 Then
            chkPuntualidadAsistencia.Checked = True
        Else
            chkPuntualidadAsistencia.Checked = False
        End If

        If objMotivo.PConfiguracionPermisos_caja_ahorro = 255 Then
            chkCajaAhorro.Checked = True
        Else
            chkCajaAhorro.Checked = False
        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Hide()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If Validar() Then
                Guardar()
                Dim FrmA As New ExitoForm
                FrmA.mensaje = "Registro guardado correctamente"
                FrmA.ShowDialog()
                FrmA.Close()
                Me.Tag = "1"
                Me.Hide()
            End If
        Catch ex As Exception
            Dim FrmE As New ErroresForm
            FrmE.mensaje = "Error al guardar el Motivo del permiso."
            FrmE.StartPosition = FormStartPosition.CenterScreen
            FrmE.ShowDialog()
            FrmE.Close()
            Me.Hide()
        End Try
    End Sub

    Private Function Validar() As Boolean

        Dim objConfPerm As New Negocios.ConfiguracionPermisosBU

        Validar = True

        If txtMotivo.Text.Length = 0 Then
            MessageBox.Show("Es necesario especificar un Motivo.", "Motivo de Permiso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Validar = False
        End If

        If objConfPerm.BuscarMotivoPermisoNave(CInt(lblIdConfPermiso.Text), CInt(lblIdNave.Text), txtMotivo.Text) Then
            MessageBox.Show("El Motivo " + txtMotivo.Text + " ya se encuentra registrado para esta nave.", "Motivo de Permiso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Validar = False
        End If


    End Function

    Private Sub Guardar()
        Dim objConfigPermiso As New Negocios.ConfiguracionPermisosBU

        objMotivo.PConfiguracionPermisos_id = CInt(lblIdConfPermiso.Text)
        objMotivo.PConfiguracionPermisos_nombre = txtMotivo.Text
        objMotivo.PConfiguracionPermisos_puntualidad_asistencia = IIf(chkPuntualidadAsistencia.Checked = True, 1, 0)
        objMotivo.PConfiguracionPermisos_caja_ahorro = IIf(chkCajaAhorro.Checked = True, 1, 0)
        objMotivo.PConfiguracionPermisos_naveid = CInt(lblIdNave.Text)

        objConfigPermiso.guardarConfiguracionPermisos(objMotivo)

    End Sub

    Private Sub txtMotivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMotivo.KeyPress

        Dim caracter As Char = e.KeyChar
        If Char.IsLetter(e.KeyChar) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Then

            e.Handled = False
            e.KeyChar = Char.ToUpper(e.KeyChar)
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub txtMotivo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMotivo.TextChanged

    End Sub

    Private Sub ConfiguracionPermisosDetalleForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class