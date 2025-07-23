Imports Tools

Public Class AltaDiasNoLaboralesForm
    Private Sub AltaDiasNoLaboralesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ObjB As New Contabilidad.Negocios.CatalogoDiasNoLaboralesBU
        cmbDescripcion = ObjB.llenarcmbDescripciones(cmbDescripcion)
        'dtpFecha.MinDate = Date.Now
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim entidadDia As New Entidades.DiasNoLaborales
            entidadDia.Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

            If cmbDescripcion.Text.Equals("") Then
                lblDescripción.ForeColor = Drawing.Color.Red
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Llena los campos requeridos")
                Return
            Else
                lblDescripción.ForeColor = Drawing.Color.Black
            End If
            'If Date.Compare(Date.Now, dtpFecha.Value.ToShortDateString) > 0 Then
            '    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No puedes registrar fechas pasadas.")
            '    Return
            'End If
            entidadDia.Descripción = cmbDescripcion.Text
            entidadDia.Fecha = dtpFecha.Value
            entidadDia.Anio = dtpFecha.Value.Year
            insertarDia(entidadDia)
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Error" + " " + ex.Message)
        End Try
    End Sub


    Public Sub insertarDia(ByVal entidad As Entidades.DiasNoLaborales)
        Try
            Dim ObjB2 As New Contabilidad.Negocios.CatalogoDiasNoLaboralesBU
            Dim success = ObjB2.InsertarDiaNoLaboral(entidad)
            If success.Resp > 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Exito, success.Mensaje)
                Me.Close()
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, success.Mensaje)
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, ex.Message)
        End Try
    End Sub

    Private Sub cmbDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbDescripcion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class