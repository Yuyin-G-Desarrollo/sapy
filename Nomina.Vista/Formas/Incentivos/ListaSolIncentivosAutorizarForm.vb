Imports Nomina.Negocios

Public Class ListaSolIncentivosAutorizarForm


    Dim seleccion As Int32
    Dim Estatus As String
    Dim cambiofecha As Int32 = 0

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        gpbFiltroIncentivos.Height = 32
        grdFiltroSolicitudes.Top = 111
        grdFiltroSolicitudes.Height = 386
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        gpbFiltroIncentivos.Height = 176
        grdFiltroSolicitudes.Top = 255
        grdFiltroSolicitudes.Height = 254

    End Sub

    Private Sub ListaSolIncentivosAutorizarForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        grdFiltroSolicitudes.Columns.Add("Seleccion", "Seleccion") '0



        grdFiltroSolicitudes.Columns.Add("Nombre", "Nombre") '1
        ' grdFiltroSolicitudes.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '---------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("Departamento", "Departamento") '2
        '-----------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("Monto", "Monto") '3
        '------------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("Motivo", "Motivo") ' 4
        grdFiltroSolicitudes.Columns.Add("Fecha_Solicitud", "Fecha_Solicitud") '4
        ''--------------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("Fecha_Autorizacion", "Fecha_Autorizacion") '6
        '---------------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("Solicito", "Solicito") '7
        '------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("Autorizo", "Autorizo") '8
        'grdFiltroSolicitudes.Columns("IDEmpleado").Visible = False
        '----------------------------------------
        grdFiltroSolicitudes.Columns.Add("Estatus", "Estatus") '9
        grdFiltroSolicitudes.Columns("Estatus").Visible = False
        '----------------------------------------------
        grdFiltroSolicitudes.Columns.Add("ID_SolicitudIncentivo", "ID_SolicitudIncentivo") '10
        grdFiltroSolicitudes.Columns("ID_SolicitudIncentivo").Visible = False
        '----------------------------------------------


        Dim dt As New DateTime
        Dim fecha As String
        fecha = dt.ToString
        llenartabla()
        Pintartabla()



    End Sub

    Public Sub Pintartabla()
        Dim hasta As New Int32
        hasta = grdFiltroSolicitudes.Rows.Count - 1
        For i = 0 To hasta
            If grdFiltroSolicitudes.Rows(i).Cells("Estatus").Value = "A" Then
                grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFBB8")
            ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estatus").Value = "B" Then
                grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#96CF3A")
            ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estatus").Value = "C" Then
                grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#BAEBFF")
            ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estatus").Value = "D" Then
                grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF96")
            ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estatus").Value = "E" Then
                grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#C5C5C5")

            End If

        Next
    End Sub


    Public Sub AgregarFila(ByVal Solicitudincentivos As Entidades.SolicitudIncentivos)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        celda = New DataGridViewCheckBoxCell
        celda.Value = True
        fila.Cells.Add(celda)
        If (Solicitudincentivos.PEstatus = "A") Then
            celda.Value = CheckState.Unchecked
            celda.ReadOnly = False
        Else
            celda.Value = CheckState.Unchecked

            celda.ReadOnly = True
        End If


        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PNombreColaborador.PNombre & " " & Solicitudincentivos.PNombreColaborador.PApaterno & " " & Solicitudincentivos.PNombreColaborador.PAmaterno
        fila.Cells.Add(celda)



        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PDepartamento.DNombre
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PMonto.ToString("$,#,##.##")
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PNombreIncentivo.INombre
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PFechaSolicitud
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PFechaAutorizacion
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PSolicito.PUserUsername
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PAutorizo.PUserUsername
        fila.Cells.Add(celda)



        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PEstatus
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PSolicitudID
        fila.Cells.Add(celda)





        grdFiltroSolicitudes.Rows.Add(fila)



    End Sub




    Public Sub llenartabla()

        Dim Estatus As String = ""
        If cmbStatus.Text = "" Then
            Estatus = ""
        ElseIf cmbStatus.Text = "Solicitado" Then
            Estatus = "A"
        ElseIf cmbStatus.Text = "Autorizado" Then
            Estatus = "B"
        ElseIf cmbStatus.Text = "Pagado" Then
            Estatus = "C"
        ElseIf cmbStatus.Text = "Rechazado" Then
            Estatus = "D"
        ElseIf cmbStatus.Text = "Cancelado" Then
            Estatus = "E"

        Else

        End If
        Dim confecha As String
        If cambiofecha = 1 Then
            Dim dt As DateTime = Fecha.Value.Date

            confecha = Fecha.Value.ToString("dd/MM/yyyy")



        Else
            confecha = ""
        End If





        Dim listaSolicitudes As New List(Of Entidades.SolicitudIncentivos)
        Dim objBU As New Negocios.IncentivosBU
        Dim numero As New Int32
        numero = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaSolicitudes = objBU.ListaSolicitudesIncentivos(txtBuscarNombreIncentivo.Text, confecha, Estatus, numero)
        For Each objeto As Entidades.SolicitudIncentivos In listaSolicitudes


            AgregarFila(objeto)
        Next








    End Sub



    Private Sub cmbStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged
        grdFiltroSolicitudes.Rows.Clear()
        llenartabla()
        Pintartabla()
    End Sub

    Private Sub Fecha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fecha.ValueChanged
        grdFiltroSolicitudes.Rows.Clear()
        cambiofecha = 1
        llenartabla()
        Pintartabla()
    End Sub

    Private Sub btnFiltrarSolicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrarSolicitud.Click
        grdFiltroSolicitudes.Rows.Clear()
        llenartabla()
        Pintartabla()
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

    Private Sub btnRechazar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRechazar.Click


        If MessageBox.Show("¿Esta seguro que quiere rechazar las Solicitudes?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            RechazarSolicitudes()
            grdFiltroSolicitudes.Rows.Clear()
            llenartabla()
            Pintartabla()

        End If

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

        Dim objIncentivosBU As New IncentivosBU


        

        Dim CountAcept As Int32 = 0
        Dim valorCheck As Integer
        Dim sentinela As Integer = 0
        For Each row As DataGridViewRow In grdFiltroSolicitudes.Rows 'Recorro todo el grid fila por fila
            valorCheck = CInt(row.Cells(0).Value)

            If valorCheck <> 0 Then
                seleccion = CInt(grdFiltroSolicitudes.Rows(sentinela).Cells(10).Value)
                objIncentivosBU.AceptarSolicitud(seleccion, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                CountAcept += 1
            End If
            sentinela += 1
        Next

        If CountAcept = 1 Then
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Solicitud Aprobada"
            FormaExito.Show()

        ElseIf CountAcept > 1 Then
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Solicitudes Aprobadas"
            FormaExito.Show()
        Else
            Dim FormaExito As New AdvertenciaForm
            FormaExito.mensaje = "No ha seleccionado ninguna solicitud"
            FormaExito.Show()
        End If


    End Sub



    Public Sub RechazarSolicitudes()


        Dim objIncentivosBU As New IncentivosBU




        Dim CountAcept As Int32 = 0
        Dim valorCheck As Integer
        Dim sentinela As Integer = 0
        For Each row As DataGridViewRow In grdFiltroSolicitudes.Rows 'Recorro todo el grid fila por fila
            valorCheck = CInt(row.Cells(0).Value)

            If valorCheck <> 0 Then
                seleccion = CInt(grdFiltroSolicitudes.Rows(sentinela).Cells(10).Value)
                objIncentivosBU.RechazarSolicitud(seleccion, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                CountAcept += 1
            End If
            sentinela += 1
        Next

        If CountAcept = 1 Then
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Solicitud Rechazada"
            FormaExito.Show()

        ElseIf CountAcept > 1 Then
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Solicitudes Rechazadas"
            FormaExito.Show()
        Else
            Dim FormaExito As New AdvertenciaForm
            FormaExito.mensaje = "No ha seleccionado ninguna solicitud"
            FormaExito.Show()
        End If


    End Sub




    Private Sub btnLimpiarSolicitudes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarSolicitudes.Click
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

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub pbYuyin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbYuyin.Click
        Dim Gerente As New ListaAutorizarGerenteFiniquitosForm
        Gerente.Show()
    End Sub
End Class