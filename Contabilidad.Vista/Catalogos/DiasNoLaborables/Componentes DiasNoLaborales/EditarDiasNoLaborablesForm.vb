Imports System.Windows.Forms
Imports Tools
Imports Framework.Negocios
Public Class EditarDiasNoLaborablesForm
    Public fecha As Date
    Public descripcion As String

    Private Sub EditarDiasNoLaborablesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        configuracionPermisosBotones()
        dtpFecha.Value = fecha
        txtDescripcion.Text = descripcion
    End Sub
    Private Sub configuracionPermisosBotones()
        If PermisosUsuarioBU.ConsultarPermiso("NF_CAT_DIAS_NLAB", "NF_CAT_DIAS_ETAR") Then
            pnlGuardar.Visible = True
        Else
            pnlGuardar.Visible = False
        End If
    End Sub
    
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeConf As New Tools.ConfirmarForm
        Dim objMensajeExito As New Tools.ExitoForm

        Try
            If validaCampos() Then
                Dim objBu As New Negocios.CatalogoDiasNoLaboralesBU
                Dim resultado As New Entidades.DiasNoLaborales

                objMensajeConf.mensaje = "¿Está seguro de guardar la información?"
                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    resultado = objBu.EditarDiaNoLaborables(fecha, dtpFecha.Value, txtDescripcion.Text, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, 1)
                End If
                If resultado.Resp = 1 Then
                    objMensajeExito.mensaje = "Información actualizada correctamente"
                    objMensajeExito.ShowDialog()
                    Me.Cursor = Cursors.Default
                    Me.Close()
                Else
                    objMensajeError.mensaje = resultado.Mensaje
                    objMensajeError.ShowDialog()
                End If
            Else
                objMensajeError.mensaje = "Favor de revisar la información capturada"
                objMensajeError.ShowDialog()
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error, favor de comunicarse con sistemas"
            objMensajeError.ShowDialog()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Function validaCampos()
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        If fecha = dtpFecha.Value And descripcion = txtDescripcion.Text Then
            Return False
            Exit Function
        ElseIf txtDescripcion.Text = "" Then
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
End Class