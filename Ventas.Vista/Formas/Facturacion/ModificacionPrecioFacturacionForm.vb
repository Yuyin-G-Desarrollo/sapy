Imports Ventas.Negocios

Public Class ModificacionPrecioFacturacionForm
    Private Sub ModificacionPrecioFacturacionForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
        MaximizeBox = False
        Me.Top = 0
        Me.Left = 0

        datosInicio()

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New ModificacionPrecioFacturacionBU
        Dim conf As New Tools.ConfirmarForm
        conf.mensaje = "¿Desea guardar los cambios?"

        If conf.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            Me.Cursor = Cursors.WaitCursor

            If rdoOtorgar.Checked Then

                objBU.guardarCambios(True, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)               

            ElseIf rdoDenegar.Checked Then

                objBU.guardarCambios(False, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)                

            End If
            mensajExito()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub mensajExito()
        Dim exito As New Tools.ExitoForm
        exito.mensaje = "Se han realizado los cambios con éxito."
        exito.ShowDialog()
        datosInicio()
    End Sub

    Private Sub datosInicio()
        Dim dtDatos As New DataTable
        Dim objBU As New ModificacionPrecioFacturacionBU
        Dim otorgarDenegar As Boolean

        dtDatos = objBU.datosInicio

        If dtDatos.Rows.Count > 0 Then

            otorgarDenegar = dtDatos.Rows(0).Item(3).ToString

            If otorgarDenegar = True Then
                rdoOtorgar.Checked = True
            Else
                rdoDenegar.Checked = True
            End If
            lblUltimaActualizacion.Text = "Última Actualización: " + dtDatos.Rows(0).Item(4).ToString
        Else
            'mensaje de que no existen datos
        End If
    End Sub
End Class