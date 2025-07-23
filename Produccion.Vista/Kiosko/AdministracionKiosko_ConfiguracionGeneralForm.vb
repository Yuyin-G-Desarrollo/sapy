Imports Produccion.Negocios
Imports Tools
Imports Tools.modMensajes

Public Class AdministracionKiosko_ConfiguracionGeneralForm

    Private Sub AdministracionKiosko_ConfiguracionGeneralForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializarFormulario()
    End Sub

    Private Sub InicializarFormulario()
        Try
            Dim objAdministracionKioskoBU As New AdministracionKioskoBU
            Cursor = Cursors.WaitCursor
            Dim dtInformacionKiosko As DataTable = objAdministracionKioskoBU.ConsultarConfiguracionesKioskoCITY()
            Cursor = Cursors.Default
            If dtInformacionKiosko.Rows.Count = 0 Then
                Return
            End If
            txtPrincipal.Text = dtInformacionKiosko.Rows(0)("RutaFotografiaPrincipal")
            txtVistaExterna.Text = dtInformacionKiosko.Rows(0)("RutaFotografiaExterna")
            txtVistaInterna.Text = dtInformacionKiosko.Rows(0)("RutaFotografiaInterna")
            txtFichaTecnica.Text = dtInformacionKiosko.Rows(0)("RutaFichaTecnica")
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "Ocurrio un problema al inicializar la pantalla. Intente nuevamente")
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim vConfirmarForm As New ConfirmarForm
            vConfirmarForm.Text = "Configuración Kiosko"
            vConfirmarForm.mensaje = "¿Estás seguro de que deseas guardar la información?"
            Dim vDialogResult As New DialogResult
            vDialogResult = vConfirmarForm.ShowDialog
            If Not vDialogResult = Windows.Forms.DialogResult.OK Then
                Return
            End If

            Dim objAdministracionKioskoBU As New AdministracionKioskoBU
            Cursor = Cursors.WaitCursor
            Dim dtRespuestaProceso As DataTable = objAdministracionKioskoBU.InsertarConfiguracionesKioskoCITY(txtPrincipal.Text,
                                                                                                               txtVistaExterna.Text,
                                                                                                               txtVistaInterna.Text,
                                                                                                               txtFichaTecnica.Text)
            If dtRespuestaProceso.Rows.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "Ocurrio un problema al guardar la información. Intente nuevamente")
                Return
            End If

            If dtRespuestaProceso.Rows(0)("BanderaRespuesta") <> 1 Then
                Tools.MostrarMensaje(Mensajes.Warning, dtRespuestaProceso.Rows(0)("ErrorRespuesta"))
                Return
            End If
            Tools.MostrarMensaje(Mensajes.Success, dtRespuestaProceso.Rows(0)("MensajeRespuesta"))
            InicializarFormulario()
            Cursor = Cursors.Default
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ocurrio un problema al guardar la información. Intente nuevamente")
        End Try
    End Sub
End Class