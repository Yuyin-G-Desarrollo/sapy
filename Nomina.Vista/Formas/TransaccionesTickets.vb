Imports Tools

Public Class TransaccionesTickets
    Dim empleadosForm As New BuscarEmpleadoForm
    Dim Consecutivoin, Descendente, ColaboradorID, NoTickets, Semana As Int32
    Dim SemanaActiva As New Negocios.TicketsBU

    Private Sub TransaccionesTickets_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''WindowState = FormWindowState.Maximized
        'cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        'If cmbNave.Items.Count = 2 Then
        'Else
        '    cmbNave.SelectedIndex = 0
        '    If cmbNave.SelectedIndex >= 0 Then
        '        ' grdTickets.Rows.Clear()

        '        Semana = SemanaActiva.SemanaActiva(cmbNave.SelectedValue)
        '        'descomentar linea anterior y borrar la siguiente
        '        'Semana = 4158
        '        llenartabla()
        '    End If
        'End If
        btnTransfer.Enabled = False

    End Sub
    Public Sub llenartabla()

        'Dim listaSolicitudes As New List(Of Entidades.Ticket)
        'Dim objBU As New Negocios.TicketsBU
        'Consecutivoin = 1
        'Dim nave As Int32
        'If cmbNave.SelectedIndex > 0 Then
        '    nave = cmbNave.SelectedValue
        'Else
        '    nave = 0
        'End If
        'listaSolicitudes = objBU.ListaTicketsGeneral(83, Semana, nave)
        'Descendente = listaSolicitudes.Count
        'For Each objeto As Entidades.Ticket In listaSolicitudes


        '    '   AgregarFila(objeto)
        '    Consecutivoin += 1
        '    Descendente -= 1
        'Next
    End Sub

    'Private Sub txtTicket_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTicket.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        Dim sentinela As Int32 = 0
    '        Dim Existe As Boolean = False
    '        For sentinela = 0 To grdTickets.Rows.Count - 1
    '            If grdTickets.Rows(sentinela).Cells(0).Value = txtTicket.Text Then
    '                Existe = True
    '                'NoTickets = txtTicket.Text

    '            Else

    '            End If
    '        Next
    '        If Existe = False Then
    '            Dim AnteriormenteRegistrado As New Boolean
    '            Dim EntidadTicket As New Entidades.Ticket
    '            Dim ObjBU As New Negocios.TicketsBU
    '            Dim Colaborador As New Entidades.Colaborador
    '            AnteriormenteRegistrado = ObjBU.ExisteRegistro(txtTicket.Text)
    '            If AnteriormenteRegistrado = False Then
    '                EntidadTicket = ObjBU.BuscarTickets(txtTicket.Text)




    '            Else
    '                Colaborador = ObjBU.DevolverNombreRegistro(txtTicket.Text)
    '                lblRegistrado.Text = Colaborador.PNombre + " " + Colaborador.PApaterno + " " + Colaborador.PAmaterno
    '                lblRegistrado.Visible = True
    '                lblRegistrado.Visible = True

    '            End If

    '        End If

    '    End If
    'End Sub


    'Public Sub AgregarFila(ByVal Solicitudincentivos As Entidades.Ticket)

    '    Dim celda As DataGridViewCell
    '    Dim fila As New DataGridViewRow



    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Descendente
    '    fila.Cells.Add(celda)


    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Solicitudincentivos.PNoTicket
    '    fila.Cells.Add(celda)

    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Solicitudincentivos.PFecha.ToShortDateString
    '    fila.Cells.Add(celda)

    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Solicitudincentivos.PDescripcion
    '    fila.Cells.Add(celda)


    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Solicitudincentivos.PCostoPartida
    '    fila.Cells.Add(celda)

    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Solicitudincentivos.PCantidadPares
    '    fila.Cells.Add(celda)

    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Solicitudincentivos.PTotal
    '    fila.Cells.Add(celda)

    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Solicitudincentivos.PIDRegistro
    '    fila.Cells.Add(celda)


    '    grdTickets.Rows.Add(fila)



    'End Sub

    'Private Sub cmbNave_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
    '    If cmbNave.SelectedIndex > 0 Then
    '        grdTickets.Rows.Clear()

    '        Semana = SemanaActiva.SemanaActiva(cmbNave.SelectedValue)
    '        'descomentar linea anterior y borrar la siguiente
    '        'Semana = 4158
    '        llenartabla()
    '    End If
    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        empleadosForm.grdBuscarEmpleado.Rows.Clear()
        empleadosForm = New BuscarEmpleadoForm
        If empleadosForm.ShowDialog = DialogResult.OK Then
            '------------

            lblDestino.Text = empleadosForm.txtBuscarEmpleado.Text
            'lblDepartamentoDato.Text = empleadosForm.txtDepartamento.Text
            'idnaveEmpleado = empleadosForm.PIdNaveEmpleado

            ColaboradorID = empleadosForm.pseleccion
            empleadosForm.grdBuscarEmpleado.Rows.Clear()
            empleadosForm.grdBuscarEmpleado.Columns.Clear()
        End If
    End Sub



    Private Sub btnTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransfer.Click
        Dim objBu As New Negocios.TicketsBU
        Dim vError As New AdvertenciaForm
        Dim Exito As New ExitoForm
        If Not txtTicket.Text = "" Then
            If lblEstatusSemana.Text = "A" Then
                If Not lblDestino.Text = "Colaborador" Then


                    If ColaboradorID > 0 Then
                        objBu.TranferirTickets(ColaboradorID, txtTicket.Text)
                    End If
                    txtTicket.Text = ""
                    ColaboradorID = 0
                    NoTickets = 0
                    lblRegistrado.Text = "Colaborador"
                    lblDestino.Text = "Colaborador"

                    Exito.mensaje = "Transaccion Exitosa"
                    Exito.ShowDialog()
                Else
                    vError.mensaje = "Debe de buscar el colaborador al cual sera trasferido el ticket"
                    vError.ShowDialog()
                End If
            Else
                vError.mensaje = "EL TICKET NÚMERO " + txtTicket.Text.ToString + " YA FÚE PAGADO EN LA " + lblPeriodoNominal.Text.ToString
                vError.ShowDialog()
            End If
        Else
            vError.mensaje = "Debe de ingresar un numero de ticket"
            vError.ShowDialog()
        End If


    End Sub

    Private Sub txtTicket_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTicket.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim AnteriormenteRegistrado As New Boolean
            Dim EntidadTicket As New Entidades.Ticket
            Dim ObjBU As New Negocios.TicketsBU
            Dim Colaborador As New Entidades.Colaborador
            Dim Ticket As New Entidades.Ticket
            Dim vError As New AdvertenciaForm
            AnteriormenteRegistrado = ObjBU.ExisteRegistro(txtTicket.Text)
            If AnteriormenteRegistrado = False Then
                EntidadTicket = ObjBU.BuscarTickets(txtTicket.Text)


                vError.mensaje = "El ticket No ha sido registrado"
                vError.ShowDialog()

            Else
                Colaborador = ObjBU.DevolverNombreRegistro(txtTicket.Text)
                lblRegistrado.Text = Colaborador.PNombre.ToUpper + " " + Colaborador.PApaterno.ToUpper + " " + Colaborador.PAmaterno.ToUpper
                lblRegistrado.Visible = True
                lblRegistrado.Visible = True
                Ticket = ObjBU.DatosTicket(txtTicket.Text)
                lblMonto.Text = Ticket.PMontoTotal
                lblCantidadPares.Text = Ticket.PCantidadPares
                lblCostoPar.Text = Ticket.PCostoPartida
                lblDescripcion.Text = Ticket.PDescripcion.ToUpper
                lblFechaCaptura.Text = Colaborador.Pcolonia
                lblEstatusSemana.Text = Colaborador.PCalle
                lblPeriodoNominal.Text = Colaborador.pCurp
                If lblEstatusSemana.Text = "A" Then
                    btnTransfer.Enabled = True
                Else
                    btnTransfer.Enabled = False
                    vError.mensaje = "EL TICKET NÚMERO " + txtTicket.Text.ToString + " YA FÚE PAGADO EN LA " + lblPeriodoNominal.Text.ToString
                    vError.ShowDialog()
                End If


            End If

        End If
    End Sub

    Private Sub txtTicket_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTicket.LostFocus

        'Dim AnteriormenteRegistrado As New Boolean
        'Dim EntidadTicket As New Entidades.Ticket
        'Dim ObjBU As New Negocios.TicketsBU
        'Dim Colaborador As New Entidades.Colaborador
        'Dim Ticket As New Entidades.Ticket
        'AnteriormenteRegistrado = ObjBU.ExisteRegistro(txtTicket.Text)
        'If AnteriormenteRegistrado = False Then
        '    EntidadTicket = ObjBU.BuscarTickets(txtTicket.Text)




        'Else
        '    Colaborador = ObjBU.DevolverNombreRegistro(txtTicket.Text)
        '    lblRegistrado.Text = Colaborador.PNombre.ToUpper + " " + Colaborador.PApaterno.ToUpper + " " + Colaborador.PAmaterno.ToUpper
        '    lblRegistrado.Visible = True
        '    lblRegistrado.Visible = True
        '    Ticket = ObjBU.DatosTicket(txtTicket.Text)
        '    lblMonto.Text = Ticket.PMontoTotal
        '    lblCantidadPares.Text = Ticket.PCantidadPares
        '    lblCostoPar.Text = Ticket.PCostoPartida
        '    lblDescripcion.Text = Ticket.PDescripcion.ToUpper



        'End If


    End Sub

    Private Sub lblEncabezado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEncabezado.Click

    End Sub

    Private Sub txtTicket_TextChanged(sender As Object, e As EventArgs) Handles txtTicket.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnCapturaManual_Click(sender As Object, e As EventArgs)
        Dim CapturaManual As New CapturaManualTicketForm
        CapturaManual.naveID =
        CapturaManual.ShowDialog()
    End Sub
End Class