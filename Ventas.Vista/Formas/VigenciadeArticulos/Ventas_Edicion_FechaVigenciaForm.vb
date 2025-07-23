Imports Ventas.Negocios

Public Class Ventas_Edicion_FechaVigenciaForm
    Public ArticulosSeleccionados As Integer
    Public ProductoEstilosSeleccionados As String


    Dim advertencia As New AdvertenciaForm
    Dim exito As New ExitoForm
    Dim confirmar As New ConfirmarForm

    Private Sub Ventas_Edicion_FechaVigenciaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaVigencia.MinDate = Date.Now
        txtObservaciones.Select()
        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        lblArticulosSeleccionados.Text = CStr(ArticulosSeleccionados) + " Artículos Seleccionados"
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New VigenciaArticulosBU
        Dim FechaVigencia As Date
        Dim Observaciones As String = String.Empty
        Dim dtGuardarFechaVigencia As New DataTable
        Dim UsuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        Try
            Observaciones = txtObservaciones.Text
            FechaVigencia = dtpFechaVigencia.Value

            confirmar.mensaje = "¿Desea guardar la fecha de vigencia para los artículos seleccionados?."
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                dtGuardarFechaVigencia = objBU.GuardarFechaVigencia_ArticulosSeleccionados(ProductoEstilosSeleccionados, FechaVigencia, Observaciones, UsuarioID)

                If dtGuardarFechaVigencia.Rows(0).Item("respuesta").ToString = "ERROR" Then
                    advertencia.mensaje = "Ocurrió un error al asignar la fecha de vigencia, intente de nuevo."
                    advertencia.ShowDialog()
                Else
                    exito.mensaje = "Datos guardados correctamente."
                    exito.ShowDialog()
                    Me.Close()
                End If
            End If



        Catch ex As Exception
            advertencia.mensaje = ex.Message
            advertencia.ShowDialog()
        Finally
            Cursor = Cursors.Default
            'Me.Close()
        End Try

    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub


    Private Sub txtObservaciones_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles txtObservaciones.KeyPress
        If Char.IsLower(e.KeyChar) Then
            txtObservaciones.SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If
    End Sub
End Class