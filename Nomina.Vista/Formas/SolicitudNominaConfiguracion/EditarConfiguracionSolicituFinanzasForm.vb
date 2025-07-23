Imports Nomina.Negocios

Public Class EditarConfiguracionSolicituFinanzasForm
    Public Beneficiario As String = ""
    Public TipoSolicitud As String = ""
    Public PeriodoNominaID As Integer = 0
    Public NaveID As Integer = 0
    Dim objConfirmar As New Tools.ConfirmarForm
    Dim objExito As New Tools.ExitoForm
    Dim objAdvertencia As New Tools.AdvertenciaForm

    Private Sub EditarConfiguracionSolicituFinanzasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtBeneficiario.Text = Beneficiario
        llenarComboTipoSolicitud()
        cmbTipoSolicitud.SelectedValue = TipoSolicitud
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            Cursor = Cursors.WaitCursor
            Dim objBU As New Nomina_SolicitudNominaConfiguracionBU
            Dim Beneficiario As String
            Dim TipoSolicitud As String
            Dim PeriodoNominaIDC As Integer
            Dim NaveIDC As Integer

            objConfirmar.mensaje = "¿Está seguro que desea actualizar los datos?"
            If objConfirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then

                Beneficiario = txtBeneficiario.Text
                TipoSolicitud = cmbTipoSolicitud.SelectedValue
                PeriodoNominaIDC = PeriodoNominaID
                NaveIDC = NaveID

                objBU.ActualizarConfiguracionNomina(Beneficiario, TipoSolicitud, PeriodoNominaIDC, NaveIDC)
                objExito.mensaje = "Se realizaron con éxito los cambios."
                objExito.ShowDialog()
            Else
                objAdvertencia.mensaje = "Se canceló el cambio en la configuración."
                objAdvertencia.ShowDialog()
            End If
            Cursor = Cursors.Default
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub llenarComboTipoSolicitud()
        Dim objBU As New Nomina_SolicitudNominaConfiguracionBU
        Dim dtSolicitudFinanzas As New DataTable
        dtSolicitudFinanzas = objBU.llenarComboTipoSolicitud()
        dtSolicitudFinanzas.Rows.InsertAt(dtSolicitudFinanzas.NewRow, 0)
        cmbTipoSolicitud.DataSource = dtSolicitudFinanzas
        cmbTipoSolicitud.DisplayMember = "Concepto"
        cmbTipoSolicitud.ValueMember = "SolicitudID"
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub
End Class