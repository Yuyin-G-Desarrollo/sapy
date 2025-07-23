Imports Tools

Public Class CancelarRefacturacion_Form

    Public OTCancelarRefacturación As Integer

    Private Sub btnGuardarCancelación_Click(sender As Object, e As EventArgs) Handles btnGuardarCancelación.Click
        Dim ObjBu As New Negocios.CancelacionDocumentosBU

        Try

            ObjBu.cancelarRefacturacion(OTCancelarRefacturación, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, txtMotivoCancelarRefacturación.Text)

            show_message("Exito", "Refacturación cancelada correctamente")

            btnGuardarCancelación.Enabled = False

        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try


    End Sub


    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub CancelarRefacturacion_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblOtCancelarRefacturacion.Text = OTCancelarRefacturación.ToString()
    End Sub
End Class