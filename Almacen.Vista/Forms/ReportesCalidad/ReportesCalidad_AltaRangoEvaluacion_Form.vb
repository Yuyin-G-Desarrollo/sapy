Public Class ReportesCalidad_AltaRangoEvaluacion_Form
    Public IdNave As Int16
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub ReportesCalidad_AltaRangoEvaluacion_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lista As New List(Of String)
        lista.Add("")
        lista.Add("DEVOLUCIONES")
        lista.Add("ALERTAS_MAYORES")
        lista.Add("ALERTAS_MENORES")

        cmbCriterio.DataSource = lista
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If cmbCriterio.SelectedIndex > 0 Then
            If nudValorInicial.Value > nudValorFinal.Value Then
                Dim ventanaAdvertencia As New Tools.AdvertenciaForm
                ventanaAdvertencia.mensaje = "El valor final deber ser mayor al valor inivial"
                ventanaAdvertencia.ShowDialog()
                Return
            End If

            Dim negocios As New Negocios.ReporteEvaluacionCalidadNaveBU
            Dim dtResultado As DataTable

            dtResultado = negocios.RegistrarCriterioEvaluacion(IdNave, cmbCriterio.Text, nudValorInicial.Value, nudValorFinal.Value, nudPuntuacion.Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            If dtResultado.Rows.Count > 0 Then
                If dtResultado.Rows(0).Item("Insertado") = True Then
                    Dim ventanaExito As New Tools.ExitoForm
                    ventanaExito.mensaje = dtResultado.Rows(0).Item("Mensaje").ToString
                    ventanaExito.ShowDialog()
                    Me.Close()
                Else
                    Dim ventanaAdvertencia As New Tools.AdvertenciaForm
                    ventanaAdvertencia.mensaje = dtResultado.Rows(0).Item("Mensaje").ToString
                    ventanaAdvertencia.ShowDialog()
                End If
            End If
        Else
            Dim ventanaAdvertencia As New Tools.AdvertenciaForm
            ventanaAdvertencia.mensaje = "Seleccione un criterio"
            ventanaAdvertencia.ShowDialog()
        End If

    End Sub

    Private Sub nudValorInicial_ValueChanged(sender As Object, e As EventArgs) Handles nudValorInicial.ValueChanged
        nudValorFinal.Minimum = nudValorInicial.Value + 1
    End Sub
End Class