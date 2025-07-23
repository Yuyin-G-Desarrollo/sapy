Imports Tools
Imports CrystalDecisions.Shared
Public Class ListaDineroporEntregarFiniquitoForm
    Dim seleccion As Int32

    Dim cambiofecha As Int32 = 0
    Dim Columna As New Int32
    Dim Estatus As String
    Dim EstatusInicial As String = "E"
    Dim TablaImprimir As New DataTable
    Dim Fechas As New DataTable
    Dim parametros As ParameterFields = New ParameterFields()
    Dim FechaInicio As ParameterField = New ParameterField()
    Dim FechaFin As ParameterField = New ParameterField()
    Dim LogotipoNave As ParameterField = New ParameterField()
    Dim myDiscreteValue1 As ParameterDiscreteValue = New ParameterDiscreteValue()
    Dim myDiscreteValue As ParameterDiscreteValue = New ParameterDiscreteValue()
    Dim LogotipoRuta As ParameterDiscreteValue = New ParameterDiscreteValue()
    ' Dim Visor As New VisorReportesEnTablas
    Dim NaveID As Int32 = 0


    Private Sub ListaDineroporEntregarFiniquitoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'grdFiltroSolicitudes.ReadOnly = True
        WindowState = FormWindowState.Maximized
        grdFiltroSolicitudes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.Panel5.BackColor = System.Drawing.ColorTranslator.FromHtml("#C5C5C5")
        Me.Panel6.BackColor = System.Drawing.ColorTranslator.FromHtml("#618DEE ")
        '    grdFiltroSolicitudes.Columns.Add("Autorizar", "") '0
        '   grdFiltroSolicitudes.Columns.Add("Nombre", "Nombre") '1
        '  grdFiltroSolicitudes.Columns("Nombre").ReadOnly = True
        '  grdFiltroSolicitudes.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        ' grdFiltroSolicitudes.Columns.Add("Años", "Años") '2
        'grdFiltroSolicitudes.Columns("Años").ReadOnly = True
        'grdFiltroSolicitudes.Columns.Add("Meses", "Meses") '2
        'grdFiltroSolicitudes.Columns("Meses").ReadOnly = True
        'grdFiltroSolicitudes.Columns.Add("Aguinaldo", "Aguinaldo") '3
        'grdFiltroSolicitudes.Columns("Aguinaldo").DefaultCellStyle.Format = "##,##00"
        'grdFiltroSolicitudes.Columns("Aguinaldo").ReadOnly = True
        'grdFiltroSolicitudes.Columns.Add("Vacaciones", "Vacaciones") '4
        'grdFiltroSolicitudes.Columns("Vacaciones").ReadOnly = True
        'grdFiltroSolicitudes.Columns("Vacaciones").DefaultCellStyle.Format = "##,##00"
        'grdFiltroSolicitudes.Columns.Add("Finiquito", "Finiquito") '5
        'grdFiltroSolicitudes.Columns("Finiquito").DefaultCellStyle.Format = "##,##00"
        'grdFiltroSolicitudes.Columns("Finiquito").ReadOnly = True
        'grdFiltroSolicitudes.Columns.Add("Ahorro", "Ahorro") '6
        'grdFiltroSolicitudes.Columns("Ahorro").ReadOnly = True
        'grdFiltroSolicitudes.Columns("Ahorro").DefaultCellStyle.Format = "##,##00"
        'grdFiltroSolicitudes.Columns.Add("Prestamo", "Prestamo") '7
        'grdFiltroSolicitudes.Columns("Prestamo").ReadOnly = True
        'grdFiltroSolicitudes.Columns("Prestamo").DefaultCellStyle.Format = "##,##00"
        'grdFiltroSolicitudes.Columns.Add("Utilidades", "Utilidades") '8
        'grdFiltroSolicitudes.Columns("Utilidades").ReadOnly = True
        'grdFiltroSolicitudes.Columns("Utilidades").DefaultCellStyle.Format = "##,##00"
        'grdFiltroSolicitudes.Columns.Add("Gratificacion", "Gratificacion") '9
        'grdFiltroSolicitudes.Columns("Gratificacion").DefaultCellStyle.Format = "##,##00"
        'grdFiltroSolicitudes.Columns("Gratificacion").ReadOnly = True

        grdFiltroSolicitudes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdFiltroSolicitudes.Columns.Add("Autorizar", "") '0
        grdFiltroSolicitudes.Columns("Autorizar").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        grdFiltroSolicitudes.Columns("Autorizar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdFiltroSolicitudes.Columns.Add("Nombre", "Colaborador") '1
        grdFiltroSolicitudes.Columns("Nombre").ReadOnly = True
        grdFiltroSolicitudes.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        grdFiltroSolicitudes.Columns.Add("Años", "Años") '2
        grdFiltroSolicitudes.Columns("Años").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        grdFiltroSolicitudes.Columns("Años").ReadOnly = True
        grdFiltroSolicitudes.Columns("Años").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdFiltroSolicitudes.Columns.Add("Meses", "Meses") '2
        grdFiltroSolicitudes.Columns("Meses").DefaultCellStyle.Format = "##,##00"
        grdFiltroSolicitudes.Columns("Meses").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdFiltroSolicitudes.Columns("Meses").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        grdFiltroSolicitudes.Columns.Add("Aguinaldo", "Aguinaldo") '3
        grdFiltroSolicitudes.Columns("Aguinaldo").DefaultCellStyle.Format = "##,##00"
        grdFiltroSolicitudes.Columns("Aguinaldo").ReadOnly = True
        grdFiltroSolicitudes.Columns("Aguinaldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdFiltroSolicitudes.Columns("Aguinaldo").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        grdFiltroSolicitudes.Columns.Add("Vacaciones", "Vacaciones") '4
        grdFiltroSolicitudes.Columns("Vacaciones").ReadOnly = True
        grdFiltroSolicitudes.Columns("Vacaciones").DefaultCellStyle.Format = "##,##00"
        grdFiltroSolicitudes.Columns("Vacaciones").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdFiltroSolicitudes.Columns("Vacaciones").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader


        grdFiltroSolicitudes.Columns.Add("PrimaVacacional", "Prima Vacacional") '4
        grdFiltroSolicitudes.Columns("PrimaVacacional").ReadOnly = True
        grdFiltroSolicitudes.Columns("PrimaVacacional").DefaultCellStyle.Format = "##,##00"
        grdFiltroSolicitudes.Columns("PrimaVacacional").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdFiltroSolicitudes.Columns("PrimaVacacional").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader


        grdFiltroSolicitudes.Columns.Add("Finiquito", "Finiquito") '5
        grdFiltroSolicitudes.Columns("Finiquito").DefaultCellStyle.Format = "##,##00"
        grdFiltroSolicitudes.Columns("Finiquito").ReadOnly = True
        grdFiltroSolicitudes.Columns("Finiquito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdFiltroSolicitudes.Columns("Finiquito").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        grdFiltroSolicitudes.Columns.Add("Ahorro", "Ahorro") '6
        grdFiltroSolicitudes.Columns("Ahorro").ReadOnly = True
        grdFiltroSolicitudes.Columns("Ahorro").DefaultCellStyle.Format = "##,##00"
        grdFiltroSolicitudes.Columns("Ahorro").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdFiltroSolicitudes.Columns("Ahorro").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        grdFiltroSolicitudes.Columns.Add("Prestamo", "Préstamo") '7
        grdFiltroSolicitudes.Columns("Prestamo").ReadOnly = True
        grdFiltroSolicitudes.Columns("Prestamo").DefaultCellStyle.Format = "##,##00"
        grdFiltroSolicitudes.Columns("Prestamo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdFiltroSolicitudes.Columns("Prestamo").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        grdFiltroSolicitudes.Columns.Add("Utilidades", "Utilidades") '8
        grdFiltroSolicitudes.Columns("Utilidades").DefaultCellStyle.Format = "##,##00"
        grdFiltroSolicitudes.Columns("Utilidades").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdFiltroSolicitudes.Columns("Utilidades").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        grdFiltroSolicitudes.Columns.Add("Gratificacion", "Gratificación") '9
        grdFiltroSolicitudes.Columns("Gratificacion").ReadOnly = True
        grdFiltroSolicitudes.Columns("Gratificacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdFiltroSolicitudes.Columns("Gratificacion").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        grdFiltroSolicitudes.Columns("Utilidades").ReadOnly = True
        grdFiltroSolicitudes.Columns("Utilidades").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        grdFiltroSolicitudes.Columns("Gratificacion").DefaultCellStyle.Format = "##,##00"

        'grdFiltroSolicitudes.Columns.Add("DiasTrabajados", "DíasTrabajados") '10
        'grdFiltroSolicitudes.Columns("DiasTrabajados").ReadOnly = True
        'grdFiltroSolicitudes.Columns("DiasTrabajados").Visible = False
        'grdFiltroSolicitudes.Columns("DiasTrabajados").DefaultCellStyle.Format = "##,##00"
        'grdFiltroSolicitudes.Columns("DiasTrabajados").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdFiltroSolicitudes.Columns.Add("TotalEntregar", "TotalEntregar") '10
        grdFiltroSolicitudes.Columns("TotalEntregar").ReadOnly = True
        grdFiltroSolicitudes.Columns("TotalEntregar").DefaultCellStyle.Format = "##,##00"
        grdFiltroSolicitudes.Columns("TotalEntregar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdFiltroSolicitudes.Columns("TotalEntregar").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        grdFiltroSolicitudes.Columns.Add("Estado", "Estado") '11
        grdFiltroSolicitudes.Columns("Estado").Visible = False
        grdFiltroSolicitudes.Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdFiltroSolicitudes.Columns.Add("FechaSolicitud", "FechaSolicitud") '12
        grdFiltroSolicitudes.Columns("FechaSolicitud").ReadOnly = True
        grdFiltroSolicitudes.Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdFiltroSolicitudes.Columns("FechaSolicitud").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        grdFiltroSolicitudes.Columns.Add("FechaBaja", "FechaBaja") '13
        grdFiltroSolicitudes.Columns("FechaBaja").ReadOnly = True
        grdFiltroSolicitudes.Columns("FechaBaja").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdFiltroSolicitudes.Columns("FechaBaja").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        grdFiltroSolicitudes.Columns.Add("FechaAutorizacion", "FechaAutorización") '14
        grdFiltroSolicitudes.Columns("FechaAutorizacion").ReadOnly = True
        grdFiltroSolicitudes.Columns("FechaAutorizacion").Visible = False
        grdFiltroSolicitudes.Columns("FechaAutorizacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdFiltroSolicitudes.Columns("FechaAutorizacion").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        grdFiltroSolicitudes.Columns.Add("UsuarioCreo", "UsuarioCreo") '15
        grdFiltroSolicitudes.Columns("UsuarioCreo").ReadOnly = True
        grdFiltroSolicitudes.Columns("UsuarioCreo").Visible = False
        grdFiltroSolicitudes.Columns.Add("VoBo", "VoBo") '16
        grdFiltroSolicitudes.Columns("VoBo").ReadOnly = True
        grdFiltroSolicitudes.Columns("VoBo").Visible = False
        grdFiltroSolicitudes.Columns.Add("VoBoFecha", "VoBoFecha") '17
        grdFiltroSolicitudes.Columns("VoBoFecha").ReadOnly = True
        grdFiltroSolicitudes.Columns("VoBoFecha").Visible = False
        grdFiltroSolicitudes.Columns.Add("IDSolicitud", "IDSolicitud") '18

        grdFiltroSolicitudes.Columns("IDSolicitud").Visible = False
        grdFiltroSolicitudes.Columns.Add("ColaboradorID", "ColaboradorID") '19

        grdFiltroSolicitudes.Columns("ColaboradorID").Visible = False


        TablaImprimir.Columns.Add("fini_consecutivonave")
        TablaImprimir.Columns.Add("Nombre")
        TablaImprimir.Columns.Add("real_fecha")
        TablaImprimir.Columns.Add("fini_fechabaja")
        TablaImprimir.Columns.Add("fini_totalfiniquito")
        TablaImprimir.Columns.Add("fini_gratificacion")
        TablaImprimir.Columns.Add("fini_utilidades")
        TablaImprimir.Columns.Add("fini_ahorro")
        TablaImprimir.Columns.Add("fini_prestamo")
        TablaImprimir.Columns.Add("fini_totalentregar")
        Fechas.Columns.Add("FechaInicio")
        Fechas.Columns.Add("FechasFin")
        Dim dt As New DateTime
        Dim fecha As String
        fecha = dt.ToString


        grdFiltroSolicitudes.Columns("Autorizar").ReadOnly = False
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        grdFiltroSolicitudes.Columns("Años").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        grdFiltroSolicitudes.Columns("Meses").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader

    End Sub


    Public Sub AgregarFila(ByVal ListaFiniquitos As Entidades.Finiquitos)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow



        celda = New DataGridViewCheckBoxCell
        celda.Value = True
        fila.Cells.Add(celda)
        If ListaFiniquitos.PEstado = "F" Then
            celda.Value = CheckState.Unchecked
            celda.ReadOnly = False
        Else
            celda.Value = CheckState.Unchecked

            celda.ReadOnly = True
        End If


        celda = New DataGridViewTextBoxCell
        celda.Value = ListaFiniquitos.PColaboradorId.PNombre & " " & ListaFiniquitos.PColaboradorId.PApaterno & " " & ListaFiniquitos.PColaboradorId.PAmaterno
        fila.Cells.Add(celda)



        celda = New DataGridViewTextBoxCell
        celda.Value = ListaFiniquitos.PAntiguedadAnios.ToString
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        'celda.Value = FormatNumber((ListaFiniquitos.PAntiguedadMeses + ((ListaFiniquitos.PAntiguedadDias / 30.4))), 2)
        celda.Value = FormatNumber((ListaFiniquitos.PAntiguedadMeses + ((ListaFiniquitos.PAntiguedadDias / 30.4))), 0)
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = ListaFiniquitos.PTotalAguinaldo
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        celda.Value = ListaFiniquitos.PTotalVacaciones
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        celda.Value = ListaFiniquitos.PPrimaVacacional
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = ListaFiniquitos.PTotalFiniquito
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = ListaFiniquitos.PAhorro
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = ListaFiniquitos.PPrestamo
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = ListaFiniquitos.PUtilidades
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = ListaFiniquitos.PGratificacion
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = ListaFiniquitos.PTotalEntregar
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = ListaFiniquitos.PEstado
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        If (ListaFiniquitos.PFechaSolicitud.ToShortDateString = CDate("01/01/0001")) Then
            celda.Value = " "
        Else
            celda.Value = ListaFiniquitos.PFechaSolicitud.ToShortDateString
        End If


        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        If (ListaFiniquitos.PFechaBaja.ToShortDateString = CDate("01/01/0001")) Then
            celda.Value = " "
        Else
            celda.Value = ListaFiniquitos.PFechaBaja.ToShortDateString
        End If

        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        If (ListaFiniquitos.PFechaAutorizacion.ToShortDateString = CDate("01/01/0001")) Then
            celda.Value = " "
        Else
            celda.Value = ListaFiniquitos.PFechaAutorizacion.ToShortDateString
        End If

        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        celda.Value = ListaFiniquitos.PUsuarioCreoId
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        celda.Value = ListaFiniquitos.PVoBo
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        If (ListaFiniquitos.PVoBoFecha.ToShortDateString = CDate("01/01/0001")) Then
            celda.Value = " "
        Else
            celda.Value = ListaFiniquitos.PVoBoFecha.ToShortDateString
        End If

        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        celda.Value = ListaFiniquitos.PFiniquito
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = ListaFiniquitos.PColaboradorId.PColaboradorid
        fila.Cells.Add(celda)

        grdFiltroSolicitudes.Rows.Add(fila)



    End Sub


    Public Sub llenartabla()


        If cmbStatus.Text = "" Then
            If EstatusInicial = "E" Then
                Estatus = "E"
            End If



        ElseIf cmbStatus.Text = "Recibidos de caja chica".ToUpper Then
            Estatus = "F"
            EstatusInicial = ""
        ElseIf cmbStatus.Text = "Entregados al colaborador".ToUpper Then
            Estatus = "G"
            EstatusInicial = ""


        Else

        End If
        Dim secondDate As String
        Dim confecha As String
        If cambiofecha = 1 Then
            Dim dt As DateTime = Fecha.Value.Date

            confecha = Fecha.Value.ToString("dd/MM/yyyy")
            secondDate = DtpSegundaFecha.Value.ToString("dd/MM/yyyy")


        Else
            confecha = ""
            secondDate = ""
        End If


        If cmbNave.SelectedIndex > 0 Then
            NaveID = cmbNave.SelectedValue
        End If



        Dim listaSolicitudes As New List(Of Entidades.Finiquitos)
        Dim objBU As New Negocios.FiniquitosBU


        listaSolicitudes = objBU.ListaFiniquitosSegunUsuario(txtBuscarNombreIncentivo.Text, confecha, secondDate, Estatus, NaveId)
        For Each objeto As Entidades.Finiquitos In listaSolicitudes


            AgregarFila(objeto)
        Next








    End Sub

    Private Sub btnFiltrarSolicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cmbNave.SelectedIndex > 0 Then
            grdFiltroSolicitudes.Rows.Clear()
            llenartabla()
            Pintartabla()
            lblNave.ForeColor = Color.Black
        Else
            lblNave.ForeColor = Color.Red
            Dim adv As New AdvertenciaForm
            adv.mensaje = "Seleccione una nave para realizar la búsqueda"
            adv.ShowDialog()
        End If
    End Sub

    Private Sub btnLimpiarSolicitudes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dt As New DateTime
        Dim fecha As String
        fecha = dt.ToString
        txtBuscarNombreIncentivo.Text = ""
        Estatus = ""
        cmbStatus.Text = ""
        cambiofecha = 0
        lblNave.ForeColor = Color.Black
        grdFiltroSolicitudes.Rows.Clear()

    End Sub

    Private Sub txtBuscarNombreIncentivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscarNombreIncentivo.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub


    Private Sub grdFiltroSolicitudes_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFiltroSolicitudes.CellClick
        If e.RowIndex >= 0 Then
            If (CStr(grdFiltroSolicitudes.Rows(e.RowIndex).Cells("Estado").Value) <> "") Then

                seleccion = CInt(grdFiltroSolicitudes.Rows(e.RowIndex).Cells("IDSolicitud").Value)
            Else
                seleccion = 0
            End If
        End If
        Columna = e.RowIndex
    End Sub


    Private Sub Fecha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fecha.ValueChanged
        grdFiltroSolicitudes.Rows.Clear()
        cambiofecha = 1
        DtpSegundaFecha.Visible = True
        lblAl.Visible = True
        llenartabla()
        Pintartabla()
    End Sub


    Private Sub cmbStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged

        'If cmbNave.SelectedIndex > 0 Then
        '    grdFiltroSolicitudes.Rows.Clear()
        '    llenartabla()
        '    Pintartabla()
        '    lblNave.ForeColor = Color.Black
        'Else
        '    lblNave.ForeColor = Color.Red
        'End If
    End Sub
    Public Sub Pintartabla()
        Dim hasta As New Int32
        hasta = grdFiltroSolicitudes.Rows.Count - 1
        For i = 0 To hasta
            If grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "A" Then ' Solicitado
                grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFBB8")
            ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "B" Then ' Autorizado
                grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#96CF3A")
            ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "C" Then ' Rechazado
                grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#BAEBFF")
            ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "D" Then ' Autorizado Gerente
                grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF96")
            ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "E" Then ' solocitado a Cajca Chica
                grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#C5C5C5")
            ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "F" Then ' Entregado
                grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#618DEE")
            ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "G" Then ' Entregado
                grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#C5C5C5")
            End If

        Next
    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gpbFiltroIncentivos.Height = 35
        grdFiltroSolicitudes.Top = 111
        grdFiltroSolicitudes.Height = 386
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gpbFiltroIncentivos.Height = 176
        grdFiltroSolicitudes.Top = 255
        grdFiltroSolicitudes.Height = 254
    End Sub

    Private Sub ChckActivarFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChckActivarFecha.CheckedChanged
        If ChckActivarFecha.Checked = True Then
            DtpSegundaFecha.Enabled = True
            Fecha.Enabled = True
        Else
            DtpSegundaFecha.Enabled = False
            Fecha.Enabled = False
        End If
    End Sub


    Private Sub DtpSegundaFecha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpSegundaFecha.ValueChanged
        grdFiltroSolicitudes.Rows.Clear()
        cambiofecha = 1
        llenartabla()
        Pintartabla()
    End Sub

    Private Sub pnlListaPaises_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlListaPaises.Paint

    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        ContextMenuStrip1.Show(btnImprimir, 0, btnImprimir.Height)
    End Sub


    Private Sub ImprimirFichaDeRenunciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirFichaDeRenunciaToolStripMenuItem.Click

        If seleccion = 0 Then
            Dim Advertencia As New AdvertenciaForm
            Advertencia.mensaje = "Seleccione un colaborador válido"

            Advertencia.ShowDialog()
        Else
            Dim FichaFiniquito As New FichaFiniquito

            Dim objTools As New ReportesVistaPrevia
            Dim IDCOlaborador As String = seleccion.ToString
            If objTools.ImprimirYuyinERP(FichaFiniquito, "@fini_finiquitoid", IDCOlaborador, "Entero") Then
                objTools.ShowDialog()
                objTools.Close()
            End If
        End If


    End Sub

    Private Sub ImprimirCartaDeRenunciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirCartaDeRenunciaToolStripMenuItem.Click


        If seleccion = 0 Then
            Dim Advertencia As New AdvertenciaForm
            Advertencia.mensaje = "Seleccione un colaborador valido"
            'Advertencia.MdiParent = MdiParent
            Advertencia.ShowDialog()
        Else
            Dim objTools As New ReportesVistaPrevia
            Dim objFoto As New FichaFiniquito
            Dim CartaRenuncia As New CartaRenuncia
            Dim IDCOlaborador As String = seleccion.ToString

            If objTools.ImprimirYuyinERP(CartaRenuncia, "@fini_finiquitoid", IDCOlaborador, "Entero") Then

                objTools.ShowDialog()
                objTools.Close()
            End If
        End If


    End Sub

    Private Sub ImprimirDetalleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirDetalleToolStripMenuItem.Click

        If seleccion = 0 Then
            Dim Advertencia As New AdvertenciaForm
            Advertencia.mensaje = "Seleccione un colaborador valido"
            Advertencia.MdiParent = MdiParent
            Advertencia.ShowDialog()
        Else
            Dim objTools As New ReportesVistaPrevia
            Dim Detalle As New DetalleCantidadEntregada
            Dim IDCOlaborador As String = seleccion.ToString
            If objTools.ImprimirYuyinERP(Detalle, "@fini_finiquitoid", IDCOlaborador, "Entero") Then
                objTools.ShowDialog()
                objTools.Close()
            End If
        End If


    End Sub

    Public Function Llenar_datatable() As DataTable
        Dim objBu As New Negocios.FiniquitosBU
        TablaImprimir = objBu.TablaImprimir(Fecha.Value.ToShortDateString, DtpSegundaFecha.Value.ToShortDateString, NaveID)
        Fechas.Rows.Add("2013-09-21", "2013-09-21")

        Return TablaImprimir
    End Function

    Public Function LLenarTablaIncidencias() As DataTable



    End Function


    Private Sub ImprimirReporteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirReporteToolStripMenuItem.Click

        If cmbNave.SelectedIndex > 0 Then


            Dim dataSetReporte As New Vista.ReportesFiniquitos
            dataSetReporte.SetDataSource(Llenar_datatable())
            'Visor = New VisorReportesEnTablas
            'Visor.ReporteViewer.ReportSource = dataSetReporte

            FechaInicio.ParameterFieldName = "FechaInicio"
            FechaFin.ParameterFieldName = "FechaFin"
            LogotipoNave.ParameterFieldName = "LogotipoNave"
            myDiscreteValue1.Value = Me.Fecha.Value.ToShortDateString
            myDiscreteValue.Value = Me.DtpSegundaFecha.Value.ToShortDateString

            If NaveID = 2 Then
                LogotipoRuta.Value = rutaPublica & "LOGOTIPOS/YUYIN.JPG"
            ElseIf NaveID = 3 Then
                LogotipoRuta.Value = rutaPublica & "LOGOTIPOS/JEANS.JPG"
            ElseIf NaveID = 4 Then
                LogotipoRuta.Value = rutaPublica & "LOGOTIPOS/MERANO.JPG"
            ElseIf NaveID = 5 Then
                LogotipoRuta.Value = rutaPublica & "LOGOTIPOS/JEANS2.JPG"
            ElseIf NaveID = 43 Then
                LogotipoRuta.Value = rutaPublica & "LOGOTIPOS/GRUPOYUYIN.JPG"
            End If




            LogotipoNave.CurrentValues.Add(LogotipoRuta)
            FechaInicio.CurrentValues.Add(myDiscreteValue1)

            FechaFin.CurrentValues.Add(myDiscreteValue)


            'Cargo los parametros y los envio al Crystal

            parametros.Add(FechaInicio)

            parametros.Add(FechaFin)
            parametros.Add(LogotipoNave)
            'info.SetDataSource(MiDataSetDatos)
            ' Visor.ReporteViewer.ParameterFieldInfo = parametros

            LlenarReporte()
            'Visor.ShowDialog()
            'dataSetReporte = New Vista.ReportesFiniquitos
            'Visor.Close()
            'Visor = Nothing
            dataSetReporte = Nothing

        Else
            Dim Advertencia As New AdvertenciaForm
            Advertencia.mensaje = "Seleccione una Nave"
            'Advertencia.MdiParent = MdiParent
            Advertencia.ShowDialog()
        End If

    End Sub


    Public Sub LlenarReporte()

        'Creo una instancia de mi Reporte
        Dim info As New Vista.ReportesFiniquitos
        Dim Visor As New VisorReportesEnTablas
        Visor.ReporteViewer.ReportSource = info





    End Sub

    Private Sub cmbNave_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
        If cmbNave.SelectedIndex > 0 Then
            NaveID = cmbNave.SelectedValue
        End If

    End Sub

    Private Sub lblAl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAl.Click

    End Sub

    Private Sub lblEncabezado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEncabezado.Click

    End Sub

    Private Sub btnPagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPagar.Click
        If MessageBox.Show("¿Esta seguro que quiere registrar como entregado al colaborador el finiquito?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            AutorizarSolicitudes()
            grdFiltroSolicitudes.Rows.Clear()
            llenartabla()
            Pintartabla()
        End If
    End Sub


    Public Sub AutorizarSolicitudes()
        Dim objBUFiniquito As New Negocios.FiniquitosBU
        Dim CountAcept As Int32 = 0
        Dim valorCheck As Integer
        Dim sentinela As Integer = 0
        For Each row As DataGridViewRow In grdFiltroSolicitudes.Rows 'Recorro todo el grid fila por fila
            valorCheck = CInt(row.Cells(0).Value)
            If valorCheck <> 0 Then
                seleccion = CInt(grdFiltroSolicitudes.Rows(sentinela).Cells("IDSolicitud").Value)
                'objBUFiniquito.EntregoFiniquito(seleccion, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                CountAcept += 1
            End If
            sentinela += 1
        Next
        If CountAcept = 1 Then
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Finiquito Entregado"
            FormaExito.ShowDialog()

        ElseIf CountAcept > 1 Then
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Finiquitos Entregados"
            FormaExito.ShowDialog()
        Else
            Dim FormaExito As New AdvertenciaForm
            FormaExito.mensaje = "No ha seleccionado ningun finiquito"
            FormaExito.ShowDialog()
        End If
    End Sub

    Private Sub ImprimirCartaUtilidadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirCartaUtilidadesToolStripMenuItem.Click
        If seleccion = 0 Then
            Dim Advertencia As New AdvertenciaForm
            Advertencia.mensaje = "Seleccione un colaborador valido"
            Advertencia.ShowDialog()
        Else
            Dim objTools As New ReportesVistaPrevia
            Dim Detalle As New CartaUtilidades
            Dim IDCOlaborador As String = seleccion.ToString
            If objTools.ImprimirYuyinERP(Detalle, "@fini_finiquitoid", IDCOlaborador, "Entero") Then
                objTools.ShowDialog()
                objTools.Close()
            End If
        End If
    End Sub

    Private Sub ImprimirReporteDeIncidenciasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirReporteDeIncidenciasToolStripMenuItem.Click

    End Sub

    Private Sub btnArriba_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        gpbFiltroIncentivos.Height = 45

    End Sub

    Private Sub btnAbajo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        gpbFiltroIncentivos.Height = 110
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiarSolicitudes_Click_1(sender As Object, e As EventArgs) Handles btnLimpiarSolicitudes.Click
        Dim dt As New DateTime
        Dim fecha As String
        fecha = dt.ToString
        txtBuscarNombreIncentivo.Text = ""
        Estatus = ""
        cmbStatus.Text = ""
        cambiofecha = 0
        lblNave.ForeColor = Color.Black
        grdFiltroSolicitudes.Rows.Clear()
    End Sub

    Private Sub btnFiltrarSolicitud_Click_1(sender As Object, e As EventArgs) Handles btnFiltrarSolicitud.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If cmbNave.SelectedIndex > 0 Then
            grdFiltroSolicitudes.Rows.Clear()
            llenartabla()
            Pintartabla()
            lblNave.ForeColor = Color.Black
        Else
            lblNave.ForeColor = Color.Red
            Dim adv As New AdvertenciaForm
            adv.mensaje = "Seleccione una nave para realizar la búsqueda"
            adv.ShowDialog()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub grdFiltroSolicitudes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdFiltroSolicitudes.CellDoubleClick

    End Sub

    Private Sub grdFiltroSolicitudes_MouseClick(sender As Object, e As MouseEventArgs) Handles grdFiltroSolicitudes.MouseClick
        If seleccion > 0 Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                cntxopciones.Show(MousePosition.X, MousePosition.Y)
            End If
        End If

    End Sub

    Private Sub AgregarAnotacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarAnotacionToolStripMenuItem.Click
        Dim agregaranotacion As New AgregarDescripcionFiniquitoForm
        agregaranotacion.PidFiniquito = seleccion
        agregaranotacion.ShowDialog()
    End Sub
End Class