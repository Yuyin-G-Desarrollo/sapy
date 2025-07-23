Imports Tools

Public Class AgregarIncidencia_Form
    Dim ObjBU As New Negocios.CatalogoInsidencias
    Private Sub AgregarIncidencia_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbDepartamentos = ObjBU.llenarcmbDepartamento(cmbDepartamentos)
        cmbDepartamentos.SelectedIndex = 0
    End Sub

    Private Sub InsertarIncidencia()

        Try
            If cmbDepartamentos.SelectedValue <> 0 And txtpuesto.Text <> String.Empty Then
                Dim entidad As New Entidades.CatalogoInsidencias
                entidad.Departamento = cmbDepartamentos.SelectedValue
                entidad.Incidencias = txtpuesto.Text
                entidad.Fecha = Date.Now
                entidad.Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                Dim success = ObjBU.AgregarIncidencias(entidad)
                If success.Rows(0).Item("Respuesta") > 0 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, success.Rows(0).Item("mensaje"))
                    Me.Close()
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, success.Rows(0).Item("mensaje"))
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Introduce los campos faltantes")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        InsertarIncidencia()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtpuesto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpuesto.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtpuesto_Validated(sender As Object, e As EventArgs) Handles txtpuesto.Validated
        If txtpuesto.Text.Trim() = "" Then
            errincidencia.SetError(txtpuesto, "Introduce el nombre de la incidencia...")
        Else
            errincidencia.Clear()
        End If

    End Sub

    Private Sub cmbDepartamentos_Validated(sender As Object, e As EventArgs) Handles cmbDepartamentos.Validated
        If cmbDepartamentos.Text.Trim() = "" Then
            errdepartamento.SetError(cmbDepartamentos, "Introduce el departamento de la incidencia...")
        Else
            errdepartamento.Clear()
        End If
    End Sub
End Class