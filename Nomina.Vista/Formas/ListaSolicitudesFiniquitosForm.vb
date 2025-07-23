Imports Tools

Public Class ListaSolicitudesFiniquitosForm

    Dim seleccion As Int32

    Dim cambiofecha As Int32 = 0
    Dim Columna As New Int32
    Dim Estatus As String
    Dim EstatusInicial As String = "A"

    Private Sub ListaSolicitudesFiniquitosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        Me.Panel3.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFBB8")
        Me.Panel4.BackColor = System.Drawing.ColorTranslator.FromHtml("#96CF3A")
        Me.Panel5.BackColor = System.Drawing.ColorTranslator.FromHtml("#BAEBFF")
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
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

        grdFiltroSolicitudes.Columns.Add("DiasTrabajados", "DíasTrabajados") '10
        grdFiltroSolicitudes.Columns("DiasTrabajados").ReadOnly = True
        grdFiltroSolicitudes.Columns("DiasTrabajados").Visible = False
        grdFiltroSolicitudes.Columns("DiasTrabajados").DefaultCellStyle.Format = "##,##00"
        grdFiltroSolicitudes.Columns("DiasTrabajados").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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



        ' grdFiltroSolicitudes.ScrollBars = ScrollBars.Horizontal


        Dim dt As New DateTime
        Dim fecha As String
        fecha = dt.ToString

        grdFiltroSolicitudes.Columns("Años").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        grdFiltroSolicitudes.Columns("Meses").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        '  grdFiltroSolicitudes.Columns("Autorizar").ReadOnly = False
    End Sub


    Public Sub AgregarFila(ByVal ListaFiniquitos As Entidades.Finiquitos)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow



        celda = New DataGridViewCheckBoxCell
        celda.Value = True
        fila.Cells.Add(celda)
        If ListaFiniquitos.PEstado = "A" Then
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
        celda.Value = ListaFiniquitos.PSueldoDiasTrabajados
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
            If EstatusInicial = "A" Then
                Estatus = "A"
            ElseIf cmbStatus.Text = "" Then
                Estatus = ""
                EstatusInicial = ""
            End If

        ElseIf cmbStatus.Text = "Solicitado".ToUpper Then
            Estatus = "A"
            EstatusInicial = ""
        ElseIf cmbStatus.Text = "Rechazados".ToUpper Then
            Estatus = "C"
            EstatusInicial = ""
        ElseIf cmbStatus.Text = "Autorizado".ToUpper Then
            Estatus = "B"
            EstatusInicial = ""
        ElseIf cmbStatus.Text = "Pagado".ToUpper Then
            Estatus = "D"
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


        Dim Naveid As Int32 = 0
        If cmbNave.SelectedIndex >= 0 Then
            Naveid = cmbNave.SelectedValue
        End If


        Dim listaSolicitudes As New List(Of Entidades.Finiquitos)
        Dim objBU As New Negocios.FiniquitosBU


        listaSolicitudes = objBU.ListaFiniquitosSegunUsuario(txtBuscarNombreIncentivo.Text, confecha, secondDate, Estatus, Naveid)
        For Each objeto As Entidades.Finiquitos In listaSolicitudes


            AgregarFila(objeto)
        Next

        grdFiltroSolicitudes.ScrollBars = ScrollBars.None
        grdFiltroSolicitudes.ScrollBars = ScrollBars.Both






    End Sub




    Private Sub btnFiltrarSolicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnLimpiarSolicitudes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dt As New DateTime
        Dim fecha As String
        fecha = dt.ToString
        txtBuscarNombreIncentivo.Text = ""
        Estatus = ""
        cmbStatus.Text = ""
        cambiofecha = 0
        grdFiltroSolicitudes.Rows.Clear()
        llenartabla()
        Pintartabla()
    End Sub

    Private Sub txtBuscarNombreIncentivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscarNombreIncentivo.KeyPress

        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
            If Char.IsLower(e.KeyChar) Then
                txtBuscarNombreIncentivo.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
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
        'grdFiltroSolicitudes.Rows.Clear()
        'llenartabla()
        'Pintartabla()
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

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub btnAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutorizar.Click
        If MessageBox.Show("¿Esta seguro que quiere aprobar las Solicitudes?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
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
                Try
                    seleccion = CInt(grdFiltroSolicitudes.Rows(sentinela).Cells("IDSolicitud").Value)
                Catch
                    seleccion = 0
                End Try
                objBUFiniquito.AceptarSolicitud(seleccion, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                CountAcept += 1
            End If
            sentinela += 1
        Next

        If CountAcept = 1 Then
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Solicitud Aprobada"
            FormaExito.ShowDialog()

        ElseIf CountAcept > 1 Then
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Solicitudes Aprobadas"
            FormaExito.ShowDialog()
        Else
            Dim FormaExito As New AdvertenciaForm
            FormaExito.mensaje = "No ha seleccionado ninguna solicitud"
            FormaExito.ShowDialog()
        End If


    End Sub

    Private Sub grdFiltroSolicitudes_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFiltroSolicitudes.CellDoubleClick
        If e.RowIndex >= 0 And grdFiltroSolicitudes.Rows(e.RowIndex).Cells("IDSolicitud").Value > 0 Then
            Dim Calculo As New EditarCalculoFiniquitoForm
            Dim Finiquitos As New Entidades.Finiquitos
            Calculo.MaximizeBox = False
            Calculo.PSolicitudFiniquitoColaborador = grdFiltroSolicitudes.Rows(e.RowIndex).Cells(22).Value
            Finiquitos.PFiniquito = grdFiltroSolicitudes.Rows(e.RowIndex).Cells("IDSolicitud").Value
            Finiquitos.PEstado = grdFiltroSolicitudes.Rows(e.RowIndex).Cells("Estado").Value
            Calculo.PSolFiniquitosExterno = Finiquitos

            Calculo.ShowDialog()
        End If

    End Sub

    Private Sub grdFiltroSolicitudes_CellStyleContentChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellStyleContentChangedEventArgs) Handles grdFiltroSolicitudes.CellStyleContentChanged

    End Sub



    Private Sub btnRechazar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRechazar.Click

        If MessageBox.Show("¿Esta seguro que quiere rechazar las Solicitudes?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            RechazarSolicitudes()
            grdFiltroSolicitudes.Rows.Clear()
            llenartabla()
            Pintartabla()

        End If



    End Sub


    Public Sub RechazarSolicitudes()
        Dim objBUFiniquito As New Negocios.FiniquitosBU



        Dim CountAcept As Int32 = 0
        Dim valorCheck As Integer
        Dim sentinela As Integer = 0
        For Each row As DataGridViewRow In grdFiltroSolicitudes.Rows 'Recorro todo el grid fila por fila
            valorCheck = CInt(row.Cells(0).Value)
            If valorCheck <> 0 Then

                seleccion = CInt(grdFiltroSolicitudes.Rows(sentinela).Cells(18).Value)
                objBUFiniquito.RechazarSolicitud(seleccion, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                CountAcept += 1
            End If
            sentinela += 1
        Next

        If CountAcept = 1 Then
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Solicitud Rechazada"
            FormaExito.ShowDialog()

        ElseIf CountAcept > 1 Then
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Solicitudes Rechazadas"
            FormaExito.ShowDialog()
        Else
            Dim FormaExito As New AdvertenciaForm
            FormaExito.mensaje = "No ha seleccionado ninguna solicitud"
            FormaExito.ShowDialog()
        End If
    End Sub


    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        ContextMenuStrip1.Show(btnImprimir, 0, btnImprimir.Height)




    End Sub

    Private Sub ImprimirFichaDeRenunciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirFichaDeRenunciaToolStripMenuItem.Click

        If seleccion = 0 Then
            Dim Advertencia As New AdvertenciaForm
            Advertencia.mensaje = "Seleccione un colaborador valido"
            ' Advertencia.MdiParent = MdiParent
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
            Advertencia.MdiParent = MdiParent
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


    Private Sub DtpSegundaFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpSegundaFecha.ValueChanged
        grdFiltroSolicitudes.Rows.Clear()

        llenartabla()
        Pintartabla()
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


    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub cmbNave_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNave.SelectedIndexChanged



    End Sub

    Private Sub lblNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblNuevo.Click

    End Sub

    Private Sub ImprimirCartaDeUtilidadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirCartaDeUtilidadesToolStripMenuItem.Click
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

    Private Sub btnArriba_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        gpbFiltroIncentivos.Height = 45
    End Sub

    Private Sub btnAbajo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        gpbFiltroIncentivos.Height = 110
    End Sub

    Private Sub lblFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFecha.Click

    End Sub

    Private Sub Status_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Status.Click

    End Sub

    Private Sub lblNave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblNave.Click

    End Sub

    Private Sub lblNombreEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblNombreEmpleado.Click

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub gpbFiltroIncentivos_Enter(sender As Object, e As EventArgs) Handles gpbFiltroIncentivos.Enter

    End Sub

    Private Sub btnLimpiarSolicitudes_Click_1(sender As Object, e As EventArgs) Handles btnLimpiarSolicitudes.Click
        Dim dt As New DateTime
        Dim fecha As String
        fecha = dt.ToString
        txtBuscarNombreIncentivo.Text = ""
        Estatus = ""
        cmbStatus.Text = ""
        cambiofecha = 0
        grdFiltroSolicitudes.Rows.Clear()
        llenartabla()
        Pintartabla()
    End Sub

    Private Sub btnFiltrarSolicitud_Click_1(sender As Object, e As EventArgs) Handles btnFiltrarSolicitud.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If cmbNave.SelectedValue > 0 Then
            grdFiltroSolicitudes.Rows.Clear()
            llenartabla()
            Pintartabla()
            lblNave.ForeColor = Color.Black
        Else
            lblNave.ForeColor = Color.Red
            Dim forma As New AdvertenciaForm
            forma.mensaje = "Debe de seleccionar una nave para realizar la búsqueda"
            forma.ShowDialog()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub txtBuscarNombreIncentivo_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarNombreIncentivo.TextChanged

    End Sub

    Private Sub grdFiltroSolicitudes_MouseClick(sender As Object, e As MouseEventArgs) Handles grdFiltroSolicitudes.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If seleccion > 0 Then
  
                cnxopciones.Show(MousePosition.X, MousePosition.Y)


            End If


        End If
    End Sub

  
    Private Sub AgregarAnotacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarAnotacionToolStripMenuItem.Click
        Dim agregaranotacion As New AgregarDescripcionFiniquitoForm
        agregaranotacion.PidFiniquito = seleccion
        agregaranotacion.ShowDialog()
    End Sub

    
End Class