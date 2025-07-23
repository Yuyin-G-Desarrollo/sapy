Imports Tools

Public Class EditarIncidencia_Form
    Dim ObjBU As New Negocios.CatalogoInsidencias
    Private _depa As Integer
    Private _nombre As String

    Public Property Depa As Integer
        Get
            Return _depa
        End Get
        Set(value As Integer)
            _depa = value
        End Set
    End Property

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If cmbDepartamentos.SelectedValue <> 0 And txtpuesto.Text <> String.Empty Then
                Dim entidad As New Entidades.CatalogoInsidencias
                entidad.IDIncidencias = txtid.Text
                entidad.Departamento = cmbDepartamentos.SelectedValue
                entidad.Incidencias = txtpuesto.Text
                entidad.Fecha = Date.Now
                entidad.Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                Dim success = ObjBU.EditarIncidencias(entidad)
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
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "ERROR" + ex.Message)
        End Try
    End Sub

    Private Sub EditarIncidencia_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbDepartamentos = ObjBU.llenarcmbDepartamento(cmbDepartamentos)
        cmbDepartamentos.SelectedValue =Depa 
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtpuesto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpuesto.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub cmbDepartamentos_Validated(sender As Object, e As EventArgs) Handles cmbDepartamentos.Validated
        If cmbDepartamentos.Text.Trim() = "" Then
            errdepartamento.SetError(cmbDepartamentos, "Introduce el departamento de la incidencia...")
        Else
            errdepartamento.Clear()
        End If
    End Sub

    Private Sub txtpuesto_Validated(sender As Object, e As EventArgs) Handles txtpuesto.Validated
        If txtpuesto.Text.Trim() = "" Then
            errincidencia.SetError(txtpuesto, "Introduce el nombre de la incidencia...")
        Else
            errincidencia.Clear()
        End If

    End Sub
End Class