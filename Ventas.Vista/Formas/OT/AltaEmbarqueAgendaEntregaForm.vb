Public Class AltaEmbarqueAgendaEntregaForm

    Public idOrdenesTrabajo As String
    Public fechaEntrega As String
    Public FechaRegreso As String
    Public paqueteriaId As Integer
    Public unidadId As Integer
    Public operadorId As Integer
    Public actualizarAgenda As AgendaEntrega_Form
    Dim cerrar As Integer = 1

    Private Sub AltaEmbarqueAgendaEntregaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objBU As New Negocios.OrdenTrabajoBU
        Dim Tabla_ListadoParametros As New DataTable
        Dim splitFechaEntrega() As String
        Dim splitHoraEntrega() As String

        dtpFechaEntrega.Value = Date.Now

        Tabla_ListadoParametros = objBU.ConsultaMensajeriasAltaEmbarquesAgenda(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        Tabla_ListadoParametros.Rows.InsertAt(Tabla_ListadoParametros.NewRow, 0)
        cmbPaqueteria.DataSource = Tabla_ListadoParametros
        cmbPaqueteria.DisplayMember = "Nombre"
        cmbPaqueteria.ValueMember = "ID"
        Tabla_ListadoParametros = objBU.ConsultaUnidadesAltaEmbarquesAgenda()
        Tabla_ListadoParametros.Rows.InsertAt(Tabla_ListadoParametros.NewRow, 0)
        cmbUnidad.DataSource = Tabla_ListadoParametros
        cmbUnidad.DisplayMember = "Unidad"
        cmbUnidad.ValueMember = "ID"
        Tabla_ListadoParametros = objBU.ConsultaOperadoresAltaEmbarquesAgenda()
        Tabla_ListadoParametros.Rows.InsertAt(Tabla_ListadoParametros.NewRow, 0)
        cmbOperador.DataSource = Tabla_ListadoParametros
        cmbOperador.DisplayMember = "Operador"
        cmbOperador.ValueMember = "ID"

        If paqueteriaId <> 0 Then
            cmbPaqueteria.SelectedValue = paqueteriaId
        End If
        If unidadId <> 0 Then
            cmbUnidad.SelectedValue = unidadId
        End If
        If operadorId <> 0 Then
            cmbOperador.SelectedValue = operadorId
        End If

        If fechaEntrega <> "" Then
            splitFechaEntrega = Replace(fechaEntrega, "12:00:00 a. m. ", "").Split(" ")
            splitHoraEntrega = splitFechaEntrega(1).Split(":")
            dtpFechaEntrega.Value = splitFechaEntrega(0)
            cmbHoraFechaEntrega.Text = If(Integer.Parse(splitHoraEntrega(0).ToString()) > 12, If(Integer.Parse(splitHoraEntrega(0).ToString()) - 12 > 9, Integer.Parse(splitHoraEntrega(0).ToString()) - 12, "0" + (Integer.Parse(splitHoraEntrega(0).ToString()) - 12).ToString()), Integer.Parse(splitHoraEntrega(0).ToString())).ToString()
            cmbHorarioFechaEntrega.Text = If(Integer.Parse(splitHoraEntrega(0).ToString()) >= 12, "p.m.", "a.m.").ToString()
            cmbMinutoFechaEntrega.Text = splitHoraEntrega(1).ToString()
        Else
            fechaEntrega = Date.Now.ToString("dd/MM/yy H:mm:ss")
            splitFechaEntrega = Replace(fechaEntrega, "12:00:00 a. m. ", "").Split(" ")
            splitHoraEntrega = splitFechaEntrega(1).Split(":")
            dtpFechaEntrega.Value = splitFechaEntrega(0)
            cmbHoraFechaEntrega.Text = If(Integer.Parse(splitHoraEntrega(0).ToString()) > 12, If(Integer.Parse(splitHoraEntrega(0).ToString()) - 12 > 9, Integer.Parse(splitHoraEntrega(0).ToString()) - 12, "0" + (Integer.Parse(splitHoraEntrega(0).ToString()) - 12).ToString()), Integer.Parse(splitHoraEntrega(0).ToString())).ToString()
            cmbHorarioFechaEntrega.Text = If(Integer.Parse(splitHoraEntrega(0).ToString()) >= 12, "p.m.", "a.m.").ToString()
            cmbMinutoFechaEntrega.Text = splitHoraEntrega(1).ToString()
        End If

        If FechaRegreso <> "" Then
            splitFechaEntrega = Replace(FechaRegreso, "12:00:00 a. m. ", "").Split(" ")
            splitHoraEntrega = splitFechaEntrega(1).Split(":")
            dtpFechaEntrega.Value = splitFechaEntrega(0)
            cmbHoraFechaRegreso.Text = If(Integer.Parse(splitHoraEntrega(0).ToString()) > 12, If(Integer.Parse(splitHoraEntrega(0).ToString()) - 12 > 9, Integer.Parse(splitHoraEntrega(0).ToString()) - 12, "0" + (Integer.Parse(splitHoraEntrega(0).ToString()) - 12).ToString()), Integer.Parse(splitHoraEntrega(0).ToString())).ToString()
            cmbHorarioFechaRegreso.Text = If(Integer.Parse(splitHoraEntrega(0).ToString()) >= 12, "p.m.", "a.m.").ToString()
            cmbMinutoFechaRegreso.Text = splitHoraEntrega(1).ToString()
        Else
            dtpfechaRegreso.Value = dtpFechaEntrega.Value
            cmbHorarioFechaRegreso.SelectedItem = cmbHorarioFechaEntrega.SelectedItem
            cmbHoraFechaRegreso.SelectedItem = cmbHoraFechaEntrega.SelectedItem
            cmbMinutoFechaRegreso.SelectedItem = cmbMinutoFechaEntrega.SelectedItem
        End If


    End Sub

    Private Sub cmbPaqueteria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPaqueteria.SelectedIndexChanged
        If RTrim(LTrim(cmbPaqueteria.SelectedItem(1).ToString())) = "YUYIN (NOSOTROS MISMOS)" Then
            cmbOperador.Enabled = True
            cmbOperador.SelectedIndex = -1
            cmbUnidad.Enabled = True
            cmbUnidad.SelectedIndex = -1

            cmbHoraFechaRegreso.Enabled = True
            cmbMinutoFechaRegreso.Enabled = True
            cmbHorarioFechaRegreso.Enabled = True

            
        Else
            AsignarHoraEstimaRegresoPaqueteria()

            cmbOperador.Enabled = False
            cmbOperador.SelectedIndex = -1
            'If RTrim(LTrim(cmbPaqueteria.SelectedItem(1).ToString())) = "CLIENTE (RECOGE)" Then
            cmbUnidad.Enabled = False
            cmbUnidad.SelectedIndex = -1

            cmbHoraFechaRegreso.Enabled = False
            cmbMinutoFechaRegreso.Enabled = False
            cmbHorarioFechaRegreso.Enabled = False
            
            'Else
            '    cmbUnidad.Enabled = True
            '    cmbUnidad.SelectedIndex = -1
            'End If
        End If
    End Sub

    Private Sub AsignarHoraEstimaRegresoPaqueteria()
        cmbHoraFechaRegreso.SelectedItem = cmbHoraFechaEntrega.SelectedItem.ToString()
        cmbMinutoFechaRegreso.SelectedItem = cmbMinutoFechaEntrega.SelectedItem
        cmbHorarioFechaRegreso.SelectedItem = cmbHorarioFechaEntrega.SelectedItem
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        cerrar = 1
        Me.Close()
    End Sub

    Private Function ValidarFecha() As Boolean
        Dim Resultado As Boolean = False
        Dim CadenaFechaInicio As String = ""
        Dim CadenaFechaFin As String = ""
        Dim FFechaInicio As Date
        Dim FFechaFin As Date

        If cmbPaqueteria.SelectedIndex >= 0 And RTrim(LTrim(cmbPaqueteria.SelectedItem(1).ToString())) <> "YUYIN (NOSOTROS MISMOS)" Then
            Resultado = True
        Else
            CadenaFechaInicio = dtpFechaEntrega.Value.ToShortDateString() + " " + If(cmbHorarioFechaEntrega.Text.ToString() = "p.m." And cmbHoraFechaEntrega.Text.ToString() <> "12", Integer.Parse(cmbHoraFechaEntrega.Text.ToString()) + 12, cmbHoraFechaEntrega.Text.ToString()).ToString() + ":" + cmbMinutoFechaEntrega.Text.ToString()
            CadenaFechaFin = dtpfechaRegreso.Value.ToShortDateString() + " " + If(cmbHorarioFechaRegreso.Text.ToString() = "p.m." And cmbHoraFechaRegreso.Text.ToString() <> "12", Integer.Parse(cmbHoraFechaRegreso.Text.ToString()) + 12, cmbHoraFechaRegreso.Text.ToString()).ToString() + ":" + cmbMinutoFechaRegreso.Text.ToString()

            FFechaInicio = CDate(CadenaFechaInicio)
            FFechaFin = CDate(CadenaFechaFin)

            If FFechaFin > FFechaInicio Then
                Resultado = True
            Else
                Resultado = False
            End If
        End If

      

        Return Resultado

    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New Negocios.OrdenTrabajoBU
        Dim mensaje As New Tools.AvisoForm
        Dim exito As New Tools.ExitoForm
        Dim advertencia As New Tools.AdvertenciaForm
        Dim altaEmbarque As New Entidades.OrdenTrabajoEmbarqueEntrega
        Dim confirmacion As New Tools.ConfirmarForm()
        Dim Paqueteria As String = RTrim(LTrim(cmbPaqueteria.SelectedItem(1).ToString()))

        Cursor = Cursors.WaitCursor
        cerrar = 0

        If ValidarFecha() = False Then
            Cursor = Cursors.Default
            advertencia.mensaje = "La fecha de regreso tiene que ser mayor a la de inicio."
            advertencia.ShowDialog()
            Return
        End If

        If DateTime.Parse(dtpFechaEntrega.Value.ToShortDateString() + " " + If(cmbHorarioFechaEntrega.Text.ToString() = "p.m." And cmbHoraFechaEntrega.Text.ToString() <> "12", Integer.Parse(cmbHoraFechaEntrega.Text.ToString()) + 12, cmbHoraFechaEntrega.Text.ToString()).ToString() + ":" + cmbMinutoFechaEntrega.Text.ToString()) >= DateTime.Now Then
            If (RTrim(LTrim(cmbPaqueteria.SelectedItem(1).ToString())) = "YUYIN (NOSOTROS MISMOS)" And cmbUnidad.Text <> "" And cmbOperador.Text <> "") Or (RTrim(LTrim(cmbPaqueteria.SelectedItem(1).ToString())) <> "YUYIN (NOSOTROS MISMOS)" And RTrim(LTrim(cmbPaqueteria.SelectedItem(1).ToString())) <> "") Then
                Try
                    confirmacion.mensaje = "Este cambio no podrá revertirse. ¿Desea continuar?"
                    If confirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        altaEmbarque.PusuarioModifica = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        altaEmbarque.PordenesTrabajo = idOrdenesTrabajo
                        altaEmbarque.PfechaEntrega = dtpFechaEntrega.Value.ToShortDateString() + " " + If(cmbHorarioFechaEntrega.Text.ToString() = "p.m." And cmbHoraFechaEntrega.Text.ToString() <> "12", Integer.Parse(cmbHoraFechaEntrega.Text.ToString()) + 12, cmbHoraFechaEntrega.Text.ToString()).ToString() + ":" + cmbMinutoFechaEntrega.Text.ToString()
                        altaEmbarque.PmensajeriaIdSAY = cmbPaqueteria.SelectedValue
                        altaEmbarque.PunidadIdSICY = cmbUnidad.SelectedValue
                        altaEmbarque.PoperadorIdSAY = cmbOperador.SelectedValue
                        altaEmbarque.PfechaRegreso = dtpfechaRegreso.Value.ToShortDateString() + " " + If(cmbHorarioFechaRegreso.Text.ToString() = "p.m." And cmbHoraFechaRegreso.Text.ToString() <> "12", Integer.Parse(cmbHoraFechaRegreso.Text.ToString()) + 12, cmbHoraFechaRegreso.Text.ToString()).ToString() + ":" + cmbMinutoFechaRegreso.Text.ToString()
                        objBU.InsertarEditarEmbarqueEntrega(altaEmbarque)
                        exito.mensaje = "Datos guardados correctamente."
                        cerrar = 1
                        actualizarAgenda.btnMostrar_Click(sender, e)
                        exito.ShowDialog()
                    End If
                Catch ex As Exception
                    mensaje.mensaje = "Los datos no se guardaron, intente de nuevo."
                    mensaje.ShowDialog()
                End Try
            Else
                advertencia.mensaje = "Faltan datos, verifique por favor"
                advertencia.ShowDialog()
            End If
        Else
            advertencia.mensaje = "La fecha de embarque debe ser mayor o igual a la fecha actual."
            advertencia.ShowDialog()
        End If
        Cursor = Cursors.Default

    End Sub

    Private Sub AltaEmbarqueAgendaEntregaForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason <> CloseReason.UserClosing Then
            If cerrar = 0 Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub dtpFechaEntrega_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaEntrega.ValueChanged
        dtpfechaRegreso.Value = dtpFechaEntrega.Value
    End Sub

    Private Sub cmbHoraFechaEntrega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbHoraFechaEntrega.SelectedIndexChanged
        ActualizarFechaRegreoPaqueteria()
    End Sub


    Private Sub ActualizarFechaRegreoPaqueteria()
        If cmbPaqueteria.SelectedIndex >= 0 Then
            If RTrim(LTrim(cmbPaqueteria.SelectedItem(1).ToString())) = "YUYIN (NOSOTROS MISMOS)" Then
                cmbHoraFechaRegreso.Enabled = True
                cmbMinutoFechaRegreso.Enabled = True
                cmbHorarioFechaRegreso.Enabled = True
                AsignarHoraEstimaRegresoPaqueteria()
            Else
                AsignarHoraEstimaRegresoPaqueteria()
                cmbHoraFechaRegreso.Enabled = False
                cmbMinutoFechaRegreso.Enabled = False
                cmbHorarioFechaRegreso.Enabled = False                

            End If
        End If

       
    End Sub


    Private Sub cmbMinutoFechaEntrega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMinutoFechaEntrega.SelectedIndexChanged
        ActualizarFechaRegreoPaqueteria()
    End Sub

    Private Sub cmbHorarioFechaEntrega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbHorarioFechaEntrega.SelectedIndexChanged
        ActualizarFechaRegreoPaqueteria()
    End Sub
End Class