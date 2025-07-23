Public Class AltaCitaEntregaForm

    Public idOrdenesTrabajo As String
    Public clienteNombre As String
    Public totalPares As Integer = 0
    Public fechaEntrega As String
    Public clave As String = ""
    Public personaParaDescarga As Integer = 0
    Public observaciones As String = ""
    Public insertar_actualizar As Integer = 0 '0 = insertar, 1 = actualizar

    Public objCita As New Entidades.OrdenTrabajoCitaEntrega

    Private Sub AltaCitaEntregaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim splitFechaEntrega As String()
        Dim splitHoraEntrega As String()

        dtpFechaEntrega.Value = Date.Now


        cmbHoraFechaEntrega.SelectedValue = cmbHoraFechaEntrega.Items(cmbHoraFechaEntrega.Items.Count - 1)
        cmbHoraFechaEntrega.SelectedValue = cmbHoraFechaEntrega.Items(0)
        cmbHoraFechaEntrega.SelectedValue = cmbHoraFechaEntrega.Items(0)

        If fechaEntrega <> "" Then
            splitFechaEntrega = fechaEntrega.Split(" ")
            splitHoraEntrega = splitFechaEntrega(1).Split(":")
            cmbHoraFechaEntrega.Text = If(Integer.Parse(splitHoraEntrega(0).ToString()) >= 12, If(Integer.Parse(splitHoraEntrega(0).ToString()) - 12 > 9, Integer.Parse(splitHoraEntrega(0).ToString()) - 12, "0" + (Integer.Parse(splitHoraEntrega(0).ToString()) - 12).ToString()), Integer.Parse(splitHoraEntrega(0).ToString())).ToString()
            cmbHorarioFechaEntrega.Text = If(Integer.Parse(splitHoraEntrega(0).ToString()) > 12, "p.m.", "a.m.").ToString()
            cmbMinutoFechaEntrega.Text = splitHoraEntrega(1).ToString()
        Else
            fechaEntrega = Date.Now.ToString("MM/dd/yy H:mm:ss")
            splitFechaEntrega = fechaEntrega.Split(" ")
            splitHoraEntrega = splitFechaEntrega(1).Split(":")
            cmbHoraFechaEntrega.Text = If(Integer.Parse(splitHoraEntrega(0).ToString()) >= 12, If(Integer.Parse(splitHoraEntrega(0).ToString()) - 12 > 9, Integer.Parse(splitHoraEntrega(0).ToString()) - 12, "0" + (Integer.Parse(splitHoraEntrega(0).ToString()) - 12).ToString()), Integer.Parse(splitHoraEntrega(0).ToString())).ToString()
            cmbHorarioFechaEntrega.Text = If(Integer.Parse(splitHoraEntrega(0).ToString()) > 12, "p.m.", "a.m.").ToString()
            cmbMinutoFechaEntrega.Text = splitHoraEntrega(1).ToString()
        End If

        txtClienteNombre.Text = clienteNombre
        txtCantidadPares.Text = totalPares
        txtClave.Text = clave.Trim()
        nudPersonasDescarga.Value = personaParaDescarga
        txtObservaciones.Text = observaciones.Trim()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

   

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New Negocios.OrdenTrabajoBU
        Dim mensaje As New Tools.ExitoForm
        Dim advertencia As New Tools.AdvertenciaForm
        Dim AltaCita As New Entidades.OrdenTrabajoCitaEntrega
        Try
            AltaCita.PusuarioModifica = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            AltaCita.PordenesTrabajo = idOrdenesTrabajo
            AltaCita.PfechaEntrega = dtpFechaEntrega.Value.ToShortDateString() + " " + If(cmbHorarioFechaEntrega.Text.ToString() = "p.m." And cmbHoraFechaEntrega.Text.ToString() <> "12", Integer.Parse(cmbHoraFechaEntrega.Text.ToString()) + 12, cmbHoraFechaEntrega.Text.ToString()).ToString() + ":" + cmbMinutoFechaEntrega.Text.ToString()
            AltaCita.Pclave = txtClave.Text
            AltaCita.PpersonasRequeridas = nudPersonasDescarga.Value
            AltaCita.Pobservaciones = txtObservaciones.Text

            objCita = AltaCita

            objBU.InsertarCitaEntrega(AltaCita)
            mensaje.mensaje = "Datos guardados correctamente."
            mensaje.ShowDialog()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()



        Catch ex As Exception
            advertencia.mensaje = "Los datos no se guardaron, intente de nuevo."
            advertencia.ShowDialog()
        End Try
    End Sub
End Class