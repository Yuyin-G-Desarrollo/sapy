Imports Tools

Public Class ReportePrestamosForm

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
        cmbNave.Text = ""
        dtpFechaFinal.Value = Now
        dtpFechaInicial.Value = Now

    End Sub


    Private Sub Inicializar()

        Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

    End Sub

    Private Sub ReportePrestamosForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Inicializar()
        Tools.FormatoCtrls.formato(Me)
    End Sub


    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click

        If cmbNave.SelectedIndex > 0 Then
            'Mandar Imprimir
            Dim frmVistaPrevia As New Tools.ReportesVistaPrevia
            Dim vReporte As New Prestamos

            With frmVistaPrevia
                If .Imprimir(vReporte, "@IdNave|@FechaInicio|@FechaFin", cmbNave.SelectedValue & "|" & FormatDateTime(dtpFechaInicial.Value, DateFormat.ShortDate) & "|" & FormatDateTime(dtpFechaFinal.Value, DateFormat.ShortDate), "Entero|Fecha|Fecha", False, False) Then
                    .ShowDialog()
                    .Close()
                End If
            End With

            frmVistaPrevia = Nothing

        Else
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Debes seleccionar una nave para imprimir el reporte."
            mensajeAdvertencia.ShowDialog()
        End If

    End Sub

    Private Sub btnRegresar_Click(sender As System.Object, e As System.EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub



End Class