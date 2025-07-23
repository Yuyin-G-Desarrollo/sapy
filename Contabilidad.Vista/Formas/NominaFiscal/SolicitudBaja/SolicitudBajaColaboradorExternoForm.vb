Imports Tools

Public Class SolicitudBajaColaboradorExternoForm


    Public ColaboradorID As Integer = -1

    Private Sub SolicitudBajaColaboradorExternoForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If ColaboradorID <> -1 Then
            CargarInformacionColaborador()
        End If
    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim objSolicitudBaja As New Contabilidad.Negocios.SolicitudBajaBU
            Dim DTSolicitudBaja As DataTable

            DTSolicitudBaja = objSolicitudBaja.ConsultarSolicitudBajaExterno(ColaboradorID)
            If DTSolicitudBaja.Rows.Count > 0 Then
                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.mensaje = "El colaborador ya cuenta con una solicitud de baja."
                mensajeAdvertencia.ShowDialog()
            Else
                Dim FiniquitoFiscal As New CalculoFiniquitoForm
                Dim SoliciutdBaja As New Contabilidad.Negocios.SolicitudBajaBU
                Dim mensajeConfirmacion As New ConfirmarForm

                FiniquitoFiscal.ColaboradorID = ColaboradorID
                FiniquitoFiscal.FechaBaja = dtmFechaBaja.Value
                mensajeConfirmacion.mensaje = "¿Está seguro de generar la Solicitud de Baja? Posteriormente no se podrán realizar cambios."

                If mensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    DTSolicitudBaja = SoliciutdBaja.GuardarSolicitudBaja(ColaboradorID, dtmFechaBaja.Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Date.Now, txtMotivo.Text.Trim(), "EXTERNO", 0)
                    FiniquitoFiscal.SolicitudBajaID = DTSolicitudBaja.Rows(0).Item("SolicitudBajaID")
                    Dim exito As New ExitoForm
                    exito.mensaje = "Se ha generado la Solicitud de Baja."
                    exito.ShowDialog()

                    If IsDBNull(FiniquitoFiscal.SolicitudBajaID) = False Or IsNothing(FiniquitoFiscal.SolicitudBajaID) = False Then
                        FiniquitoFiscal.Show()
                    End If
                End If
                Me.Close()
            End If
        Catch ex As Exception
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = "Algo surgió mal durante el proceso, favor de intentar nuevamente"
            advertencia.ShowDialog()
        End Try

    End Sub



    Private Sub CargarInformacionColaborador()

        Dim objBu As New Negocios.ColaboradoresContabilidadBU
        Dim dtDatos As New DataTable

        dtDatos = objBu.consultaDatosColaborador(ColaboradorID)

        If Not IsNothing(dtDatos) Then
            If dtDatos.Rows.Count > 0 Then
                txtNombre.Text = dtDatos.Rows(0).Item("nombre") + " " + dtDatos.Rows(0).Item("apaterno") + " " + dtDatos.Rows(0).Item("amaterno")
                txtCURP.Text = dtDatos.Rows(0).Item("curp")
                txtRFC.Text = dtDatos.Rows(0).Item("rfc")
                txtNSS.Text = dtDatos.Rows(0).Item("nss")
                txtFechaSolicitud.Text = Date.Now.ToShortDateString()
                dtmFechaBaja.Value = Date.Now

            End If
        End If



    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

End Class