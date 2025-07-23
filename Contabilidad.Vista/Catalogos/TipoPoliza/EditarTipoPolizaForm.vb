Imports Tools

Public Class EditarTipoPolizaForm

    Public tipo_polizaID As Integer
    Public descripcion As String
    Public status As Boolean

    Private Sub EditarTipoPolizaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDescripcion.Text = descripcion
        If status Then
            rbtnEstatusActivo.Checked = True
        Else
            rbtnEstatusInactivo.Checked = True
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Dim tipoPoliza As New Entidades.TipoPoliza
        Dim objBU As New Negocios.TipoPolizasBU

        tipoPoliza.polizatipoid = tipo_polizaID
        tipoPoliza.nombre = txtDescripcion.Text
        tipoPoliza.status = CBool(rbtnEstatusActivo.Checked)

        Try
            objBU.alta_edicion_tipo_poliza(tipoPoliza)
            show_message("Exito", "Información guardada con éxito")
            Me.Close()
        Catch ex As Exception
            show_message("Error", "Algo surgió mal en el procedimiento")
            Me.Close()
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
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


End Class