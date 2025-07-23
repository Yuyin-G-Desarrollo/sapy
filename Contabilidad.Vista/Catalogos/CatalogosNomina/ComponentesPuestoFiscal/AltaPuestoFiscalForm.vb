Imports Tools

Public Class AltaPuestoFiscalForm
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        InsertarPuesto_PorPatron()
    End Sub

    Public Sub InsertarPuesto_PorPatron()
        Dim ObjBU As New Contabilidad.Negocios.CatalogoPuestoFiscalBU
        Dim entPuesto As New Entidades.PuestoFiscal
        Try
            If txtPatron.Text = "" Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Favor de ingresar un Patron")
            ElseIf txtpuesto.Text = "" Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Favor de ingresar un Puesto")
            Else
                entPuesto.UsuarioCreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                entPuesto.ID_Patron = txtidpatron.Text
                entPuesto.NombrePatron = txtpuesto.Text
                entPuesto.FechaCreo = Date.Now

                Dim success = ObjBU.InsertarPuesto_PorPatron(entPuesto)
                If success.Resp > 0 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, success.Mensaje)
                    Me.Close()
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, success.Mensaje)
                End If
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El puesto no es valido")
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub




    Private Sub txtpuesto_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtpuesto.KeyPress

        e.KeyChar = UCase(e.KeyChar)
    End Sub
End Class