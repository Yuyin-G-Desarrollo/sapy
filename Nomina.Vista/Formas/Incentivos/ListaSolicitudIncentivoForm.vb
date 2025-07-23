Imports Nomina.Negocios

Public Class ListaSolicitudIncentivoForm

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

    Private Sub btnAltaIncentivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltaIncentivo.Click
        Dim NuevaSolicitud As New AltaIncentivoForm
        NuevaSolicitud.MdiParent = MdiParent
        NuevaSolicitud.Show()
    End Sub

    Private Sub ListaSolicitudIncentivoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grdFiltroSolicitudes.Columns.Add("Nombre", "Nombre") '0
        grdFiltroSolicitudes.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '---------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("Departamento", "Departamento") '1
        '-----------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("Monto", "Monto") '2
        '------------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("Fecha_Solicitud", "Fecha_Solicitud") '3
        ''--------------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("Fecha_Autorizacion", "Fecha_Autorizacion") '4
        '---------------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("Solicito", "Solicito") '5
        '------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("Autorizo", "Autorizo") '6
        'grdFiltroSolicitudes.Columns("IDEmpleado").Visible = False
        '----------------------------------------
        grdFiltroSolicitudes.Columns.Add("Estatus", "Estatus") '7
        grdFiltroSolicitudes.Columns("Estatus").Visible = False
        '----------------------------------------------
        grdFiltroSolicitudes.Columns.Add("ID_SolicitudIncentivo", "ID_SolicitudIncentivo") '8
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

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fecha.ValueChanged
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

    Private Sub btnEditarIncentivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If MessageBox.Show("¿Esta seguro que quiere cancelar la solicitud?", "Solicitud Cancelada", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            CancelarSolicitud()

            grdFiltroSolicitudes.Rows.Clear()
            llenartabla()
            Pintartabla()

        End If







    End Sub

    Public Sub CancelarSolicitud()
        Dim objIncentivosBU As New IncentivosBU
        objIncentivosBU.CancelarSolicitud(seleccion)

        Dim FormaExito As New ExitoForm
        FormaExito.mensaje = "Solicitud Cancelada"
        FormaExito.Show()
    End Sub

    Private Sub grdFiltroSolicitudes_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFiltroSolicitudes.CellClick

        If e.RowIndex > 0 Then
            seleccion = CInt(grdFiltroSolicitudes.Rows(e.RowIndex).Cells(8).Value)
        End If


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

    Private Sub btnAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class