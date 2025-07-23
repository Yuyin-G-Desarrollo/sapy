
Imports Tools
Public Class AgregarFechaPreparacionForm


    Public OrdenTabajoId As String = String.Empty
    Public FechaPreparacion As Date
    Public NumeroOrdenesTrabajo As Integer = 0
    Public FechaPreparacionModificada As Date = Nothing
    Public NumeroOrdenesTrabajoValidas As Integer = 0

    Private Sub AgregarFechaPreparacionForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim FechaNula As Date = Nothing
        If FechaPreparacion <> FechaNula Then
            dtmpFechaPreparacion.Value = FechaPreparacion
            If FechaPreparacion >= Date.Now.Date Then
                dtmpFechaPreparacion.MinDate = Date.Now
            Else
                dtmpFechaPreparacion.MinDate = FechaPreparacion
            End If
        Else
            dtmpFechaPreparacion.Value = Date.Now
            dtmpFechaPreparacion.MinDate = Date.Now
        End If
        dtmpFechaPreparacion.Format = DateTimePickerFormat.Custom
        dtmpFechaPreparacion.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New Ventas.Negocios.OrdenTrabajoBU
        Try


            objBU.ActualizarFechaPreparacion(OrdenTabajoId, dtmpFechaPreparacion.Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            show_message("Exito", "Se ha actualizado la fecha de Preparación a " + NumeroOrdenesTrabajoValidas.ToString + " de " + NumeroOrdenesTrabajo.ToString() + " OTs.")
            FechaPreparacionModificada = dtmpFechaPreparacion.Value
            DialogResult = Windows.Forms.DialogResult.OK            
            Me.Close()
            'Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
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




End Class