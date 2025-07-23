Imports Nomina.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class CapturaManualTicketForm
    Dim empleadosForm As New BuscarEmpleadoForm
    Dim Consecutivoin, Descendente, ColaboradorID, NoTickets, Semana As Int32
    Dim SemanaActiva As New Negocios.TicketsBU
    Dim TicketEnviar As New Entidades.Ticket
    Public naveID As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        empleadosForm.grdBuscarEmpleado.Rows.Clear()
        empleadosForm = New BuscarEmpleadoForm
        If empleadosForm.ShowDialog = DialogResult.OK Then
            '------------
            If empleadosForm.txtTipoSalario.Text = "DESTAJO" Then


                txtTicket.Enabled = True
                cboxPeriodo.Enabled = True
                lblColaborador.Text = empleadosForm.txtBuscarEmpleado.Text
                lblDepartamento.Text = empleadosForm.txtDepartamento.Text
                lblCelula.Text = empleadosForm.txtCelula.Text
                lblPuesto.Text = empleadosForm.txtPuesto.Text
                'idnaveEmpleado = empleadosForm.PIdNaveEmpleado
                Semana = empleadosForm.cmbNave.SelectedValue
                ColaboradorID = empleadosForm.pseleccion
                empleadosForm.grdBuscarEmpleado.Rows.Clear()
                empleadosForm.grdBuscarEmpleado.Columns.Clear()
                lblIdDepartamento.Text = empleadosForm.txtIdDepartamento.Text
                lblNave.Text = empleadosForm.txtNave.Text
                listado_periodos_asistencia(lblNave.Text)
            Else
                Dim vMensaje As New Tools.AdvertenciaForm
                vMensaje.mensaje = "El tipo de sueldo del colaborador seleccionado es " + empleadosForm.txtTipoSalario.Text + " y no puede cobrar tickets"
                vMensaje.ShowDialog()
                txtTicket.Enabled = False
                cboxPeriodo.Enabled = False
            End If

        Else
            txtTicket.Enabled = False
            cboxPeriodo.Enabled = False
        End If
    End Sub
    Public Sub llenarTablaColaborador(idColaborador As Integer, periodoNominal As Integer)
        Dim vticketBU As New Negocios.TicketsBU
        Dim dtTablaTicket As New DataTable
        Dim vMensaje As New Tools.AdvertenciaForm
        dtTablaTicket = vticketBU.obtenerTicketsColaborador(idColaborador, periodoNominal)
        If dtTablaTicket.Rows.Count > 0 Then
            grdTablaTicket.DataSource = dtTablaTicket
            disenotabla()
        Else
            grdTablaTicket.DataSource = Nothing
            vMensaje.mensaje = "El colaborado no tiene tickets registrados aún "
            vMensaje.ShowDialog()
        End If

    End Sub

    Public Sub disenotabla()
        Dim band As UltraGridBand = Me.grdTablaTicket.DisplayLayout.Bands(0)
        With band
            .Columns("dest_detajoid").Hidden = True
            .Columns("dest_codigo").Header.Caption = "Número de Ticket"
            .Columns("dest_fecha").Header.Caption = "Fecha de Captura"
            .Columns("dest_descripcion").Header.Caption = "Descripción"
            .Columns("dest_pares").Header.Caption = "Número de Pares"
            .Columns("dest_costopar").Header.Caption = "Costo Fracción"
            .Columns("dest_montoticket").Header.Caption = "Total"
            .Columns("dest_codigo").CellActivation = Activation.NoEdit
            .Columns("dest_fecha").CellActivation = Activation.NoEdit
            .Columns("dest_descripcion").CellActivation = Activation.NoEdit
            .Columns("dest_pares").CellActivation = Activation.NoEdit
            .Columns("dest_costopar").CellActivation = Activation.NoEdit
            .Columns("dest_montoticket").CellActivation = Activation.NoEdit
            .Columns("dest_pares").CellAppearance.TextHAlign = HAlign.Right
            .Columns("dest_costopar").CellAppearance.TextHAlign = HAlign.Right
            .Columns("dest_montoticket").CellAppearance.TextHAlign = HAlign.Right
            .Columns("dest_montoticket").Style = ColumnStyle.Currency
            .Columns("dest_costopar").Style = ColumnStyle.Currency
            .Columns("dest_montoticket").MaskInput = " nnnn.nnn"
            .Columns("dest_costopar").MaskInput = " nnnn.nn"
            .Columns("dest_montoticket").Format = " #####.00"
            .Columns("dest_costopar").Format = " 0.000"
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        grdTablaTicket.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdTablaTicket.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdTablaTicket.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdTablaTicket.DisplayLayout.Override.RowSelectorWidth = 35
        grdTablaTicket.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdTablaTicket.Rows(0).Selected = True

        Try
            If band.Summaries.Exists("sumuno") Then
                Dim tmpSettings As SummarySettings = band.Summaries("sumuno")
                band.Summaries.Remove(tmpSettings)
                tmpSettings = band.Summaries("count")
                band.Summaries.Remove(tmpSettings)
            End If

        Catch ex As Exception

        End Try



        Dim sumuno As SummarySettings = band.Summaries.Add("sumuno", SummaryType.Sum, band.Columns("dest_montoticket"))
        sumuno.DisplayFormat = "Total = $ {0:#####}"
        sumuno.Appearance.TextHAlign = HAlign.Right

        Dim count As SummarySettings = band.Summaries.Add("count", SummaryType.Count, band.Columns("dest_codigo"))
        count.DisplayFormat = "Tickets = {0:#####}"
        count.Appearance.TextHAlign = HAlign.Left

        band.SummaryFooterCaption = "Total"

        Dim contarTotalTickets As Integer = 0
        Dim contTickets As Double = 0
        For Each rowGrd As UltraGridRow In grdTablaTicket.Rows
            contTickets = contTickets + CDbl(rowGrd.Cells("dest_montoticket").Value)
            contarTotalTickets = contarTotalTickets + 1
        Next
        lblTotalPrecio.Text = "$ " + contTickets.ToString("N2")
        lblTotalTicket.Text = contarTotalTickets.ToString("N0")


    End Sub

    'Private Sub listado_naves()

    '    Try

    '        Controles.ComboNavesSegunUsuario(cboxNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))

    '    Catch ex As Exception

    '    End Try

    '    If cboxNave.SelectedIndex > 0 Then

    '        listado_periodos_asistencia()

    '    End If

    'End Sub

    Private Sub cboxNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs)
        'listado_periodos_asistencia()
    End Sub

    Private Sub listado_periodos_asistencia(ByVal id_nave As String)

        'Try

        '    Controles.ComboPeriodoSegunNaveSegunAsistenciaControlAsistencia(cboxPeriodo, CInt(cboxNave.SelectedValue.ToString))
        '    Dim ControlDelPeriodoBu As New Negocios.ControlDePeriodoBU
        '    Dim periodoNominaID As Integer = CInt(ControlDelPeriodoBu.periodoSegunNaveSegunAsistenciaActual(CInt(cboxNave.SelectedValue.ToString)).Rows(0).Item(0).ToString)

        '    cboxPeriodo.SelectedValue = periodoNominaID
        '    cboxPeriodo.SelectedItem = cboxPeriodo.SelectedValue
        'Catch ex As Exception

        'End Try

        cboxPeriodo.DataSource = Nothing
        Dim objBU As New ControlDePeriodoBU
        Dim ControlDelPeriodoBu As New Negocios.ControlDePeriodoBU
        Dim tabla As New DataTable
        Try
            tabla = objBU.buscarPeriodoSegunNaves_Top10(CInt(id_nave))
            tabla.Rows.InsertAt(tabla.NewRow, 0)
            cboxPeriodo.DisplayMember = "pnom_Concepto"
            cboxPeriodo.ValueMember = "pnom_PeriodoNomId"
            cboxPeriodo.DataSource = tabla
            cboxPeriodo.SelectedValue = 0
        Catch ex As Exception

        End Try


        'Dim periodoNominaID As Integer = CInt(ControlDelPeriodoBu.periodoSegunNaveSegunAsistenciaActual(CInt(cboxNave.SelectedValue.ToString)).Rows(0).Item(0).ToString)

        'cboxPeriodo.SelectedValue = periodoNominaID
        cboxPeriodo.SelectedItem = cboxPeriodo.SelectedValue

    End Sub

    Private Sub txtTicket_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTicket.KeyDown
        If (e.KeyValue = Keys.Enter) Then
            If ((txtTicket.TextLength = 10 And txtTicket.Text.ToUpper.Contains("N") = False) Or (txtTicket.TextLength = 15 And txtTicket.Text.ToUpper.Contains("N") = True)) Then
                Dim AnteriormenteRegistrado, Departamento As New Boolean
                Dim EntidadTicket As New Entidades.Ticket
                Dim ObjBU As New Negocios.TicketsBU
                Dim Colaborador As New Entidades.Colaborador
                Dim Ticket As New Entidades.Ticket
                AnteriormenteRegistrado = ObjBU.ExisteRegistro(txtTicket.Text)
                If AnteriormenteRegistrado = False Then
                    EntidadTicket = ObjBU.BuscarTickets(txtTicket.Text)
                    If Not EntidadTicket.PCostoPartida = 0.0 Then
                        'falta validar que sea de su departamento y que este en los dias habiles
                        Dim vDiasHabiles As Boolean = diasHabiles(EntidadTicket.pLote, EntidadTicket.pNave, EntidadTicket.pAnio)
                        If vDiasHabiles = False Then
                            Dim confirma As New Tools.ConfirmarForm
                            confirma.mensaje = "El ticket número " + txtTicket.Text + " caducó el " + EntidadTicket.PFecha.ToShortDateString + " ¿Desea guardarlo de todas formas?"
                            Dim vDialogResult As New DialogResult
                            vDialogResult = confirma.ShowDialog
                            If vDialogResult = Windows.Forms.DialogResult.Cancel Then
                                Exit Sub
                            End If
                        End If
                        Dim vPerteneceDepartamento As Boolean = perteneceDepartamento(CInt(lblIdDepartamento.Text), lblDepartamento.Text)
                        If vPerteneceDepartamento = False Then
                            Dim confirma As New Tools.ConfirmarForm
                            confirma.mensaje = "Esta fracción no pertenece al departamento del colaborador ¿Desea guardarlo de todas formas?"
                            Dim vDialogResult As New DialogResult
                            vDialogResult = confirma.ShowDialog
                            If vDialogResult = Windows.Forms.DialogResult.Cancel Then
                                Exit Sub
                            End If
                        End If

                        Dim EstausPeriodo As String
                        EstausPeriodo = ObjBU.obtenerEstatusPeriodo(CInt(cboxPeriodo.SelectedValue))

                        If Not EstausPeriodo = "C" Then
                            Ticket.PNoTicket = txtTicket.Text
                            Colaborador.PColaboradorid = ColaboradorID
                            Ticket.PIDColaborador = Colaborador
                            'Ticket.PPeriodoNomina = ObjBU.SemanaActiva(Semana)
                            Ticket.PDescripcion = EntidadTicket.PDescripcion
                            Ticket.PCantidadPares = EntidadTicket.PCantidadPares
                            Ticket.PCostoPartida = EntidadTicket.PCostoPartida
                            Ticket.PTotal = EntidadTicket.PTotal
                            Ticket.PPeriodoNomina = CInt(cboxPeriodo.SelectedValue)
                            TicketEnviar = Ticket
                            guardarTicket()
                        Else
                            Dim advertencia As New AdvertenciaForm
                            advertencia.mensaje = "El ticket " + txtTicket.Text + " no puede ser agregado por que el periodo " + cboxPeriodo.Text + " ya esta cerrado "
                            advertencia.ShowDialog()
                        End If
                        'lblCelula.Text = Ticket.PCantidadPares
                        ''lblMonto.Text = Ticket.PTotal
                        'lblPuesto.Text = Ticket.PCostoPartida
                        'lblDepartamento.Text = Ticket.PDescripcion


                    Else
                        Dim advertencia As New AdvertenciaForm
                        advertencia.mensaje = "El número del ticket no fue encontrado"
                        advertencia.ShowDialog()
                    End If
                Else
                    Dim advertencia As New AdvertenciaForm
                    advertencia.mensaje = "El número del ticket ya esta registrado"
                    advertencia.ShowDialog()
                End If
            Else
                Dim advertencia As New AdvertenciaForm
                advertencia.mensaje = "El número del ticket no fue encontrado"
                advertencia.ShowDialog()
            End If
        End If
    End Sub
    Public Function diasHabiles(lote As Integer, nave As Integer, anio As Integer) As Boolean
        Dim ObjBU As New Negocios.TicketsBU
        Dim diasHabilesTicket As Integer
        diasHabilesTicket = ObjBU.obtenerDiasHabilesNave(lblNave.Text)
        diasHabiles = ObjBU.bDiasHabiles(lote, nave, anio, diasHabilesTicket)

    End Function
    Public Function perteneceDepartamento(idDepartamento As Integer, Fraccion As String) As Boolean
        Dim ObjBU As New Negocios.TicketsBU
        perteneceDepartamento = ObjBU.bDepartamento(idDepartamento, Fraccion.ToString)
    End Function
    'Private Sub txtTicket_LostFocus(sender As Object, e As EventArgs) Handles txtTicket.LostFocus
    '    Dim AnteriormenteRegistrado As New Boolean
    '    Dim EntidadTicket As New Entidades.Ticket
    '    Dim ObjBU As New Negocios.TicketsBU
    '    Dim Colaborador As New Entidades.Colaborador
    '    Dim Ticket As New Entidades.Ticket
    '    AnteriormenteRegistrado = ObjBU.ExisteRegistro(txtTicket.Text)
    '    If AnteriormenteRegistrado = False Then
    '        EntidadTicket = ObjBU.BuscarTickets(txtTicket.Text)
    '        Ticket.PNoTicket = CInt(txtTicket.Text)
    '        Colaborador.PColaboradorid = ColaboradorID
    '        Ticket.PIDColaborador = Colaborador
    '        Ticket.PPeriodoNomina = ObjBU.SemanaActiva(Semana)
    '        Ticket.PDescripcion = EntidadTicket.PDescripcion
    '        Ticket.PCantidadPares = EntidadTicket.PCantidadPares
    '        Ticket.PCostoPartida = EntidadTicket.PCostoPartida
    '        Ticket.PTotal = EntidadTicket.PTotal

    '        lblCantidadPares.Text = Ticket.PCantidadPares
    '        lblMonto.Text = Ticket.PTotal
    '        lblCostoPar.Text = Ticket.PCostoPartida
    '        lblDescripcion.Text = Ticket.PDescripcion

    '        TicketEnviar = Ticket
    '    End If
    'End Sub



    Private Sub CapturaManualTicketForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        txtTicket.Enabled = False
        cboxPeriodo.Enabled = False

        'listado_periodos_asistencia()
    End Sub

    Private Sub btnTransfer_Click(sender As Object, e As EventArgs)
        guardarTicket()

    End Sub
    Public Sub guardarTicket()
        If ColaboradorID > 0 Then

            If IsNothing(cboxPeriodo.SelectedValue) Then
                Dim advertencia As New AdvertenciaForm
                advertencia.mensaje = "Debe seleccionar una nave y un periodo de asistencia"
                advertencia.ShowDialog()
            Else



                Dim objbu As New Negocios.TicketsBU
                objbu.RegistrarTickets(TicketEnviar, ColaboradorID)

                'lblCelula.Text = ""
                'lblMonto.Text = ""
                'lblPuesto.Text = ""
                'lblDepartamento.Text = ""
                txtTicket.Text = ""
                TicketEnviar = New Entidades.Ticket
                Dim mensaje As New ExitoForm
                mensaje.mensaje = "Ticket guardado correctamente"
                mensaje.ShowDialog()
                llenarTablaColaborador(ColaboradorID, CInt(cboxPeriodo.SelectedValue))
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim mensaje2 As New ConfirmarForm

        mensaje2.mensaje = "¿Está seguro de cerrar la pestaña?"
        If mensaje2.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Close()
        End If

    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim objmensaje As New Tools.ConfirmarForm
        Dim mensaje As New ExitoForm
        Dim mensaje2 As New AdvertenciaForm
        If grdTablaTicket.Rows.Count > 0 Then
            'If Not grdTablaTicket.ActiveRow.Index = 0 Then
            If grdTablaTicket.ActiveRow.IsFilterRow = False Then
                objmensaje.mensaje = "¿Está seguro de eliminar el ticket " + grdTablaTicket.ActiveRow.Cells("dest_codigo").Value.ToString + " del colaborador?"
                If objmensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim belimino As Boolean
                    If grdTablaTicket.ActiveRow.IsFilterRow = False Then
                        belimino = eliminarTicket(grdTablaTicket.ActiveRow.Cells("dest_codigo").Value.ToString)
                        If belimino = 0 Then
                            mensaje2.mensaje = "No se pudo eliminar el ticket"
                            mensaje2.ShowDialog()
                        ElseIf belimino = 1 Then
                            mensaje.mensaje = "Ticket borrado correctamente"
                            mensaje.ShowDialog()
                        Else
                            mensaje2.mensaje = "El ticket que intenta eliminar ya fue pagado en la " + cboxPeriodo.Text + " El ticket no se eliminará "
                            mensaje2.ShowDialog()
                        End If
                        llenarTablaColaborador(ColaboradorID, CInt(cboxPeriodo.SelectedValue))
                    End If
                End If
            Else
                mensaje2.mensaje = "Seleccione un ticket"
                mensaje2.ShowDialog()
            End If
        Else
            mensaje2.mensaje = "Seleccione un ticket"
            mensaje2.ShowDialog()
        End If
    End Sub

    Public Function eliminarTicket(ByVal idTicket As String) As Integer
        eliminarTicket = 0
        Dim ObjBU As New Negocios.TicketsBU
        eliminarTicket = ObjBU.beliminarTicketColaborador(idTicket)
    End Function

    Private Sub txtTicket_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTicket.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtTicket.Text.Length < 50) Then
            If (Char.IsDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = (".")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtTicket.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            Else
                'txtTicket.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = False
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub cboxPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxPeriodo.SelectedIndexChanged
        If Not IsNothing(cboxPeriodo.SelectedValue) Then
            If Not cboxPeriodo.SelectedIndex = 0 Then
                llenarTablaColaborador(ColaboradorID, CInt(cboxPeriodo.SelectedValue))
            Else
                grdTablaTicket.DataSource = Nothing
            End If
        Else
            grdTablaTicket.DataSource = Nothing
        End If
    End Sub


End Class