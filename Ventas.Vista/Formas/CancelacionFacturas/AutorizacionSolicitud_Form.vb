Imports Tools
Public Class AutorizacionSolicitud_Form
    Public idSolicitud As Integer
    Public idMotivoCancelacion As Integer

    Dim objMensajeValido As New Tools.AvisoForm
    Dim objMensajeError As New Tools.ErroresForm
    Dim objMensajeExito As New Tools.ExitoForm
    Private Sub AutorizacionSolicitud_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LLenarComboMotivos()
        ''cmbMotivosInternos.SelectedValue = idMotivoCancelacion


    End Sub

    Public Sub LLenarComboMotivos()
        Try
            Dim objBU As New Ventas.Negocios.SolicitarCancelacionBU
            Dim dtResultado As New DataTable
            dtResultado = objBU.ConsultarMotivosSAT(idMotivoCancelacion)


            'If dtResultado.Rows.Count > 0 Then
            '    cmbMotivosInternos.DataSource = dtResultado
            '    cmbMotivosInternos.DisplayMember = "motivoSat"
            '    cmbMotivosInternos.ValueMember = "idMotivoSat"
            'End If

        Catch ex As Exception
            objMensajeValido.Text = "Error"
            objMensajeValido.mensaje = "ERROR:" + ex.Message.ToString
            objMensajeValido.ShowDialog()
        End Try

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Guardar()
    End Sub

    Private Sub Guardar()
        Dim dtSolicitud As New DataTable
        Dim dtResultado As New DataTable
        Dim objBU As New Ventas.Negocios.SolicitarCancelacionBU

        Dim dtResultadotTipoCancelacion As New DataTable
        dtResultadotTipoCancelacion = objBU.ConsultarClaveSatSolicitud(idSolicitud)
        Dim claveSat As String = dtResultadotTipoCancelacion.Rows(0).Item("claveSAT").ToString

        If claveSat = "02" Then
            dtResultado = objBU.AutorizarSolicitudCancelacion(idSolicitud, txtObservaciones.Text)
            If dtResultado.Rows(0).Item("respuesta").ToString = "ERROR" Then
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrio un error al guardar, intente de nuevo.")
            Else
                objMensajeExito.Text = "Exito"
                objMensajeExito.mensaje = dtResultado.Rows(0).Item("respuesta").ToString()
                objMensajeExito.ShowDialog()
                Me.Close()
            End If
        ElseIf claveSat = "01" Then
            Try
                dtResultado = objBU.AutorizarSolicitudCancelacion(idSolicitud, txtObservaciones.Text)
                If dtResultado.Rows(0).Item("respuesta").ToString = "ERROR" Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Ocurrio un error al guardar, intente de nuevo.")
                Else
                    Dim dtDocumneto As New DataTable
                    dtDocumneto = objBU.ConsultarClaveSatSolicitud(idSolicitud)
                    Dim idDocumento As Integer = dtDocumneto.Rows(0).Item("idDocumneto")
                    objBU.EnviarParesRefacturarOT(idDocumento)
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "La solcitud se autorizo correctamente")
                    Me.Close()
                End If
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Ocurrio un error al guardar, intente de nuevo.")
            End Try
        ElseIf claveSat = "03" Then
            dtResultado = objBU.AutorizarSolicitudCancelacion(idSolicitud, txtObservaciones.Text)
            If dtResultado.Rows(0).Item("respuesta").ToString = "ERROR" Then
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrio un error al guardar, intente de nuevo.")
            Else
                objMensajeExito.Text = "Exito"
                objMensajeExito.mensaje = dtResultado.Rows(0).Item("respuesta").ToString()
                objMensajeExito.ShowDialog()
                Me.Close()
            End If
        End If


    End Sub

    Private Sub btnCncelar_Click(sender As Object, e As EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub txtObservaciones_TextChanged(sender As Object, e As EventArgs) Handles txtObservaciones.TextChanged
        txtObservaciones.Text = txtObservaciones.Text.ToUpper
        txtObservaciones.SelectionStart = txtObservaciones.Text.Length
    End Sub

    Private Sub AutorizacionSolicitud_Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.F5 Then
            Guardar()
        End If
        If e.KeyData = Keys.Escape Then
            Dim confirmar As New ConfirmarForm
            confirmar.mensaje = "¿Está seguro de cerrar la ventana?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.Close()
            End If
        End If
    End Sub
End Class