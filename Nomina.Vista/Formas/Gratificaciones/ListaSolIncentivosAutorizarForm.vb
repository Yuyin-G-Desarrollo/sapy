Imports Nomina.Negocios
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports Tools

Public Class ListaSolIncentivosAutorizarForm

    Dim SumaTotal As Double
    Dim seleccion As Int32
    Dim Estatus As String
    Dim cambiofecha As Int32 = 0
    Dim parametros As ParameterFields = New ParameterFields()
    Dim FechaInicio As ParameterField = New ParameterField()
    Dim FechaFin As ParameterField = New ParameterField()
    Dim Naveid As ParameterField = New ParameterField()
    Dim myDiscreteValue1 As ParameterDiscreteValue = New ParameterDiscreteValue()
    Dim myDiscreteValue As ParameterDiscreteValue = New ParameterDiscreteValue()
    Dim Naveidd As ParameterDiscreteValue = New ParameterDiscreteValue()
    Dim FechaInicial, FechaFinal As New Date
    Dim Consecutivo As Int32

    Dim NavesID As Int32 = 0

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gpbFiltroIncentivos.Height = 32
        grdFiltroSolicitudes.Top = 111
        grdFiltroSolicitudes.Height = 386
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gpbFiltroIncentivos.Height = 176
        grdFiltroSolicitudes.Top = 255
        grdFiltroSolicitudes.Height = 254

    End Sub

    Private Sub ListaSolIncentivosAutorizarForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        Me.Panel3.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF96") ' rechazado
        Me.Panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#BAEBFF ") 'director
        Me.Panel5.BackColor = System.Drawing.ColorTranslator.FromHtml("#96CF3A") ' gerente
        Me.Panel6.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFBB8 ") 'solicitado
        Me.Panel7.BackColor = Color.Salmon

        grdFiltroSolicitudes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdFiltroSolicitudes.Columns.Add("clmConsecutivo", "#") '0
        grdFiltroSolicitudes.Columns("clmConsecutivo").SortMode = DataGridViewColumnSortMode.NotSortable
        grdFiltroSolicitudes.Columns("clmConsecutivo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdFiltroSolicitudes.Columns("clmConsecutivo").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        ' ------------------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("clmSeleccion", "") '1
        grdFiltroSolicitudes.Columns("clmSeleccion").SortMode = DataGridViewColumnSortMode.NotSortable
        grdFiltroSolicitudes.Columns("clmSeleccion").ToolTipText = "Seleccción"
        grdFiltroSolicitudes.Columns("clmSeleccion").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grdFiltroSolicitudes.Columns("clmSeleccion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        '------------------------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("clmNombre", "Nombre") '2
        grdFiltroSolicitudes.Columns("clmNombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells ' DataGridViewAutoSizeColumnMode.Fill
        grdFiltroSolicitudes.Columns("clmNombre").ReadOnly = True
        grdFiltroSolicitudes.Columns("clmNombre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        '---------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("clmDepartamento", "Departamento") '3
        grdFiltroSolicitudes.Columns("clmDepartamento").ReadOnly = True
        grdFiltroSolicitudes.Columns("clmDepartamento").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grdFiltroSolicitudes.Columns("clmDepartamento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        '--------------------------------------------------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("clmCelula", "Celula") '3
        grdFiltroSolicitudes.Columns("clmCelula").ReadOnly = True
        grdFiltroSolicitudes.Columns("clmCelula").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grdFiltroSolicitudes.Columns("clmCelula").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        '-----------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("clmTotal", "Total") 'total
        grdFiltroSolicitudes.Columns("clmTotal").ReadOnly = True
        grdFiltroSolicitudes.Columns("clmTotal").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grdFiltroSolicitudes.Columns("clmTotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdFiltroSolicitudes.Columns.Add("clmMonto", "Monto") '4
        grdFiltroSolicitudes.Columns("clmMonto").ReadOnly = True
        grdFiltroSolicitudes.Columns("clmMonto").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grdFiltroSolicitudes.Columns("clmMonto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '------------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("clmMotivo", "Motivo") ' 5
        grdFiltroSolicitudes.Columns("clmMotivo").ReadOnly = True
        grdFiltroSolicitudes.Columns("clmMotivo").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        grdFiltroSolicitudes.Columns.Add("clmMonto2", "Monto2") 'monto 2
        grdFiltroSolicitudes.Columns("clmMonto2").ReadOnly = True
        grdFiltroSolicitudes.Columns("clmMonto2").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grdFiltroSolicitudes.Columns("clmMonto2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '------------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("clmMotivo2", "Motivo2")
        grdFiltroSolicitudes.Columns("clmMotivo2").ReadOnly = True
        grdFiltroSolicitudes.Columns("clmMotivo2").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        grdFiltroSolicitudes.Columns.Add("clmMonto3", "Monto3") 'monto 3
        grdFiltroSolicitudes.Columns("clmMonto3").ReadOnly = True
        grdFiltroSolicitudes.Columns("clmMonto3").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grdFiltroSolicitudes.Columns("clmMonto3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '------------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("clmMotivo3", "Motivo3") ' 5
        grdFiltroSolicitudes.Columns("clmMotivo3").ReadOnly = True
        grdFiltroSolicitudes.Columns("clmMotivo3").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '  --------------------------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("clmFecha_Solicitud", "Fecha de Solicitud") '6
        grdFiltroSolicitudes.Columns("clmFecha_Solicitud").ReadOnly = True
        grdFiltroSolicitudes.Columns("clmFecha_Solicitud").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grdFiltroSolicitudes.Columns("clmFecha_Solicitud").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdFiltroSolicitudes.Columns("clmFecha_Solicitud").SortMode = DataGridViewColumnSortMode.NotSortable
        ''--------------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("clmFecha_Autorizacion", "Fecha de Autorización") '7
        grdFiltroSolicitudes.Columns("clmFecha_Autorizacion").ReadOnly = True
        grdFiltroSolicitudes.Columns("clmFecha_Autorizacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdFiltroSolicitudes.Columns("clmFecha_Autorizacion").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grdFiltroSolicitudes.Columns("clmFecha_Autorizacion").SortMode = DataGridViewColumnSortMode.NotSortable
        grdFiltroSolicitudes.Columns("clmFecha_Autorizacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        '---------------------------------------------------------

        grdFiltroSolicitudes.Columns.Add("clmSolicito", "Solicitó") '8
        grdFiltroSolicitudes.Columns("clmSolicito").ReadOnly = True
        grdFiltroSolicitudes.Columns("clmSolicito").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        '------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("clmAutorizo", "Autorizó") '9
        grdFiltroSolicitudes.Columns("clmAutorizo").ReadOnly = True
        grdFiltroSolicitudes.Columns("clmAutorizo").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        grdFiltroSolicitudes.Columns("clmAutorizo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        '----------------------------------------------------
        grdFiltroSolicitudes.Columns.Add("clmIDEmpleado", "IDEmpleado") '10
        grdFiltroSolicitudes.Columns("clmIDEmpleado").Visible = False
        '----------------------------------------
        grdFiltroSolicitudes.Columns.Add("clmEstatus", "Estatus") '11
        grdFiltroSolicitudes.Columns("clmEstatus").Visible = False
        '----------------------------------------------
        grdFiltroSolicitudes.Columns.Add("clmID_SolicitudIncentivo", "ID_SolicitudIncentivo") '12
        grdFiltroSolicitudes.Columns("clmID_SolicitudIncentivo").Visible = False
        '----------------------------------------------
        grdFiltroSolicitudes.Columns.Add("clmID_motivo", "ID_motivo") '13
        grdFiltroSolicitudes.Columns("clmID_motivo").Visible = False
        '----------------------------------------------
        grdFiltroSolicitudes.Columns.Add("clmObservacion", "Observacion") '14
        grdFiltroSolicitudes.Columns("clmObservacion").Visible = False

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_INCE_AUT", "GERENTE") Then
            cmbStatus.Text = "Solicitado"
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_INCE_AUT", "DIRECTOR") Then
            cmbStatus.Text = "Autorizado"
        End If



        Dim dt As New DateTime
        Dim fecha As String
        fecha = dt.ToString

        Pintartabla()



        Try
            If cmbNave.SelectedValue > 0 Then
                cboxPeriodo = Controles.ComboPeriodoSegunNaveIncentivos(cboxPeriodo, cmbNave.SelectedValue)
                cboxPeriodo.SelectedIndex = 0
            End If
            If cboxPeriodo.SelectedValue >= 0 Then
                Dim BuscarFechas As New IncentivosBU
                Try
                    FechaInicial = BuscarFechas.BuscarFechaInicialPerdiodo(cboxPeriodo.SelectedValue)
                    FechaFinal = BuscarFechas.BuscarFechaFinalPerdiodo(cboxPeriodo.SelectedValue)
                Catch ex As Exception

                End Try

            End If

            WindowState = FormWindowState.Maximized
        Catch ex As Exception

        End Try



    End Sub

    Public Sub Pintartabla()
        Dim hasta As New Int32
        hasta = grdFiltroSolicitudes.Rows.Count - 1
        For i = 0 To hasta
            If grdFiltroSolicitudes.Rows(i).Cells("clmEstatus").Value = "A" Then
                grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFBB8")
            ElseIf grdFiltroSolicitudes.Rows(i).Cells("clmEstatus").Value = "B" Then
                grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#96CF3A")
            ElseIf grdFiltroSolicitudes.Rows(i).Cells("clmEstatus").Value = "C" Then
                grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#BAEBFF")
            ElseIf grdFiltroSolicitudes.Rows(i).Cells("clmEstatus").Value = "D" Then
                grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = Color.Salmon
            ElseIf grdFiltroSolicitudes.Rows(i).Cells("clmEstatus").Value = "E" Then
                grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#C5C5C5")

            End If
            If grdFiltroSolicitudes.Rows(i).Cells("clmObservacion").Value = "NO SE CAPTURO DESCRIPCION" Then

            Else
                grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF96")
            End If

        Next
    End Sub


    Public Sub AgregarFila(ByVal Solicitudincentivos As Entidades.SolicitudIncentivos)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow


        celda = New DataGridViewTextBoxCell
        celda.Value = Consecutivo
        fila.Cells.Add(celda)

        celda = New DataGridViewCheckBoxCell
        celda.Value = True
        fila.Cells.Add(celda)


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_INCE_AUT", "GERENTE") Then
            If TieneGerente() = True Then
                If (Solicitudincentivos.PEstatus = "A") Then
                    celda.Value = CheckState.Unchecked
                    celda.ReadOnly = False
                Else
                    celda.Value = CheckState.Unchecked

                    celda.ReadOnly = True
                End If
            Else
                If (Solicitudincentivos.PEstatus = "A") Or (Solicitudincentivos.PEstatus = "B") Then
                    celda.Value = CheckState.Unchecked
                    celda.ReadOnly = False
                Else
                    celda.Value = CheckState.Unchecked

                    celda.ReadOnly = True
                End If
            End If

        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_INCE_AUT", "DIRECTOR") Then
            If TieneDirector() = True Then
                If (Solicitudincentivos.PEstatus = "B") Then
                    celda.Value = CheckState.Unchecked
                    celda.ReadOnly = False
                Else
                    celda.Value = CheckState.Unchecked

                    celda.ReadOnly = True
                End If

            Else
                If (Solicitudincentivos.PEstatus = "B") Or (Solicitudincentivos.PEstatus = "A") Then
                    celda.Value = CheckState.Unchecked
                    celda.ReadOnly = False
                Else
                    celda.Value = CheckState.Unchecked

                    celda.ReadOnly = True
                End If
            End If

        End If



        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PNombreColaborador.PNombre.ToUpper & " " & Solicitudincentivos.PNombreColaborador.PApaterno.ToUpper & " " & Solicitudincentivos.PNombreColaborador.PAmaterno.ToUpper
        fila.Cells.Add(celda)



        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PDepartamento.DNombre.ToUpper
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.Pcelulas.PNombre.ToUpper
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PMonto.ToString("N2")
        fila.Cells.Add(celda)
        SumaTotal += Solicitudincentivos.PMonto

        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PMontoGratificacion1.ToString("N2")
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PNombreIncentivo.INombre.ToUpper
        fila.Cells.Add(celda)

        'monto 2 gratificación
        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PMontoGratificacion2.ToString("N2")
        fila.Cells.Add(celda)
        'SumaTotal += Solicitudincentivos.PMonto

        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PMotivoID2.INombre.ToUpper
        fila.Cells.Add(celda)

        'monto 3 gratificacion
        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PMontoGratificacion3.ToString("N2")
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PMotivoID3.INombre.ToUpper
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PFechaSolicitud.ToShortDateString
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        If (Solicitudincentivos.PFechaAutorizacion.ToShortDateString = CDate("01/01/0001")) Then
            celda.Value = " "
        Else
            celda.Value = Solicitudincentivos.PFechaAutorizacion.ToShortDateString
        End If

        fila.Cells.Add(celda)



        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PSolicito.PUserUsername
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PAutorizo.PUserUsername
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PColaboradorID
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PEstatus
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PSolicitudID
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PNombreIncentivo.IIncentivoId
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Solicitudincentivos.PDescripcion
        fila.Cells.Add(celda)



        grdFiltroSolicitudes.Rows.Add(fila)



    End Sub




    Public Sub llenartabla()
        If cmbNave.SelectedValue > 0 Then

            Dim Estatus As String = ""
            If cmbStatus.Text = "" Then
                Estatus = ""
            ElseIf cmbStatus.Text = "Solicitado".ToUpper Then
                Estatus = "A"
            ElseIf cmbStatus.Text = "Autorizado Gerente".ToUpper Then
                Estatus = "B"
            ElseIf cmbStatus.Text = "Autorizado Director".ToUpper Then
                Estatus = "C"
            ElseIf cmbStatus.Text = "Rechazado".ToUpper Then
                Estatus = "D"


            Else

            End If
            'Dim confecha As String
            ' Dim SegundaFecha As String
            'If cambiofecha = 1 Then
            '    Dim dt As DateTime = Fecha.Value.Date

            '    confecha = Fecha.Value.ToString("dd/MM/yyyy")
            '    SegundaFecha = dtpSegundaFecha.Value.ToString("dd/MM/yyyy")


            'Else
            '    confecha = ""
            'End If

            Dim Naveid As Int32
            If cmbNave.SelectedIndex > 0 Then
                Naveid = cmbNave.SelectedValue
            End If




            Dim listaSolicitudes As New List(Of Entidades.SolicitudIncentivos)
            Dim objBU As New Negocios.IncentivosBU
            Dim numero As New Int32
            numero = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

            Dim Accesototal As Boolean = False
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_INCE_AUT", "WRITE") Then
                Accesototal = True
            Else
                Accesototal = False
            End If

            Consecutivo = 1
            'listaSolicitudes = objBU.ListaSolicitudesIncentivos(txtBuscarNombreIncentivo.Text, FechaInicial.ToShortDateString, Estatus, numero, FechaFinal.ToShortDateString, Naveid, Accesototal)
            If cboxPeriodo.SelectedIndex > 0 Then
                listaSolicitudes = objBU.ListaSolicitudesIncentivos(txtBuscarNombreIncentivo.Text, FechaInicial.ToShortDateString, Estatus, numero, FechaFinal.ToShortDateString, Naveid, Accesototal, CInt(cboxPeriodo.SelectedValue))
            Else
                listaSolicitudes = objBU.ListaSolicitudesIncentivosSinFechas(txtBuscarNombreIncentivo.Text, Estatus, numero, Naveid, Accesototal, 0)
            End If
            SumaTotal = 0
            For Each objeto As Entidades.SolicitudIncentivos In listaSolicitudes


                AgregarFila(objeto)
                Consecutivo += 1
            Next


        Else

        End If






    End Sub



    Private Sub cmbStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged
        'grdFiltroSolicitudes.Rows.Clear()
        'llenartabla()
        'Pintartabla()
    End Sub

    Private Sub Fecha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'grdFiltroSolicitudes.Rows.Clear()
        cambiofecha = 1
        'llenartabla()
        'Pintartabla()
    End Sub

    Private Sub btnFiltrarSolicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            If cboxPeriodo.SelectedValue >= 0 Then
                Dim BuscarFechas As New IncentivosBU
                Try
                    FechaInicial = BuscarFechas.BuscarFechaInicialPerdiodo(cboxPeriodo.SelectedValue)
                    FechaFinal = BuscarFechas.BuscarFechaFinalPerdiodo(cboxPeriodo.SelectedValue)
                Catch ex As Exception

                End Try

            End If


        Catch ex As Exception

        End Try



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
        If grdFiltroSolicitudes.Rows.Count >= 1 Then

            Dim Confirmar As New ConfirmarForm
            Confirmar.mensaje = " ¿Esta seguro que quiere aprobar las Solicitudes? "
            If Confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then

                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_INCE_AUT", "GERENTE") Then
                    AutorizarSolicitudes()
                    grdFiltroSolicitudes.Rows.Clear()
                    llenartabla()
                    Pintartabla()

                Else



                End If

            End If
            'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_INCE_AUT", "DIRECTOR") Then
            '    AutorizarSolicitudesDirector()
            '    grdFiltroSolicitudes.Rows.Clear()
            '    llenartabla()
            '    Pintartabla()
            'Else

            'End If

        End If



    End Sub




    Public Sub AutorizarSolicitudes()

        Dim objIncentivosBU As New IncentivosBU
        Dim CountAcept As Int32 = 0
        Dim valorCheck As Integer
        Dim sentinela As Integer = 0
        Dim Dialogo As New DialogSeleccionarFormaDePagoForm
        'Dim IDCajas As Int32
        Dim datosCorrectos As Boolean = True
        Dim FormadePago As String = String.Empty
        Dialogo.cmbFormaPago.SelectedIndex = 1

        'If Dialogo.ShowDialog = DialogResult.OK Then
        'Try
        '    IDCajas = Dialogo.cmbCaja.SelectedValue

        '    FormadePago = Dialogo.cmbFormaPago.Text
        '    If FormadePago.Length = 0 Then
        '        Dim Advertencia As New AdvertenciaForm
        '        Advertencia.mensaje = "Seleccione al menos una forma de pago"
        '        Advertencia.MdiParent = MdiParent
        '        Advertencia.ShowDialog()
        '        datosCorrectos = False
        '    End If
        'Catch ex As Exception
        '    Dim Advertencia As New AdvertenciaForm
        '    Advertencia.mensaje = "Seleccione Correctamente los datos"
        '    Advertencia.MdiParent = MdiParent
        '    Advertencia.ShowDialog()
        '    datosCorrectos = False
        'End Try

        If datosCorrectos = True Then
            Dim ObjCajas As New Negocios.CajasBU
            Dim objBUFiniquito As New Negocios.FiniquitosBU
            Dim Suma As Double = 0
            'Dim IDSolicitud As DataTable

            For Each row As DataGridViewRow In grdFiltroSolicitudes.Rows 'Recorro todo el grid fila por fila
                Try
                    valorCheck = CInt(row.Cells("clmSeleccion").Value)
                Catch ex As Exception
                    valorCheck = 0
                End Try

                Dim MensajeNegocios As String = ""
                If valorCheck <> 0 Then
                    seleccion = CInt(grdFiltroSolicitudes.Rows(sentinela).Cells("clmID_SolicitudIncentivo").Value)
                    Dim Montos As Double
                    If grdFiltroSolicitudes.Rows(sentinela).Cells("clmMonto").Value = "$" Or grdFiltroSolicitudes.Rows(sentinela).Cells("clmMonto").Value = Nothing Then
                        Montos = 0

                    Else
                        Montos = CDbl(grdFiltroSolicitudes.Rows(sentinela).Cells("clmMonto").Value) + CDbl(grdFiltroSolicitudes.Rows(sentinela).Cells("clmMonto2").Value) + CDbl(grdFiltroSolicitudes.Rows(sentinela).Cells("clmMonto3").Value)
                        Suma += grdFiltroSolicitudes.Rows(sentinela).Cells("clmMonto").Value
                    End If

                    MensajeNegocios = objIncentivosBU.AceptarSolicitud(seleccion, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Montos, grdFiltroSolicitudes.Rows(sentinela).Cells("clmID_motivo").Value)


                    CountAcept += 1
                    'Dim objBU As New IncentivosBU

                    'Dim FormularioMensaje As New ExitoForm
                    'Dim FormularioError As New AdvertenciaForm



                    'If MensajeNegocios.Length = 0 Then



                    '    grdFiltroSolicitudes.Rows(sentinela).DefaultCellStyle.BackColor = Color.GreenYellow

                    'ElseIf MensajeNegocios = "El monto solicitado excede el limite del monto permitido." Then

                    '    grdFiltroSolicitudes.Rows(sentinela).DefaultCellStyle.BackColor = Color.Salmon


                    'Else

                    '    grdFiltroSolicitudes.Rows(sentinela).DefaultCellStyle.BackColor = Color.Sienna

                    'End If


                End If
                sentinela += 1
            Next
            'If ApareceNomina() = False And TieneDirector() = False Then
            'IDSolicitud = ObjCajas.EnviarSolicitudesCaja(IDCajas, FormadePago, Suma, "Gratificaciones", "SOLICITUD DE EFECTIVO PARA PAGO DE GRATIFICACIONES")
            'End If

        End If
        ' End If

        Dim FormaExito As New ExitoForm
        FormaExito.mensaje = "Solicitudes Autorizadas"
        FormaExito.ShowDialog()



    End Sub


    Public Sub AutorizarSolicitudesDirector()

        Dim objIncentivosBU As New IncentivosBU
        Dim CountAcept As Int32 = 0
        Dim valorCheck As Integer
        Dim sentinela As Integer = 0
        Dim Dialogo As New DialogSeleccionarFormaDePagoForm
        'Dim IDCajas As Int32
        Dim datosCorrectos As Boolean = True
        Dim FormadePago As String = String.Empty
        Dialogo.cmbFormaPago.SelectedIndex = 1
        'If Dialogo.ShowDialog = DialogResult.OK Then
        'Try
        '    IDCajas = Dialogo.cmbCaja.SelectedValue

        '    FormadePago = Dialogo.cmbFormaPago.Text
        '    If FormadePago.Length = 0 Then
        '        Dim Advertencia As New AdvertenciaForm
        '        Advertencia.mensaje = "Seleccione al menos una forma de pago"
        '        Advertencia.MdiParent = MdiParent
        '        Advertencia.ShowDialog()
        '        datosCorrectos = False
        '    End If
        'Catch ex As Exception
        '    Dim Advertencia As New AdvertenciaForm
        '    Advertencia.mensaje = "Seleccione Correctamente los datos"
        '    Advertencia.MdiParent = MdiParent
        '    Advertencia.ShowDialog()
        '    datosCorrectos = False
        'End Try

        If datosCorrectos = True Then
            Dim ObjCajas As New Negocios.CajasBU
            Dim objBUFiniquito As New Negocios.FiniquitosBU
            Dim Suma As Double = 0
            'Dim IDSolicitud As DataTable

            For Each row As DataGridViewRow In grdFiltroSolicitudes.Rows 'Recorro todo el grid fila por fila
                Try
                    valorCheck = CInt(row.Cells("clmSeleccion").Value)
                Catch ex As Exception
                    valorCheck = 0
                End Try
                Dim MensajeNegocios As String = ""
                If valorCheck <> 0 Then
                    seleccion = CInt(grdFiltroSolicitudes.Rows(sentinela).Cells("clmID_SolicitudIncentivo").Value)
                    Dim Montos As Double
                    If grdFiltroSolicitudes.Rows(sentinela).Cells("clmMonto").Value = "$" Or grdFiltroSolicitudes.Rows(sentinela).Cells("clmMonto").Value = Nothing Then
                        Montos = 0

                    Else
                        Montos = grdFiltroSolicitudes.Rows(sentinela).Cells("clmMonto").Value
                        Suma += grdFiltroSolicitudes.Rows(sentinela).Cells("clmMonto").Value
                    End If

                    MensajeNegocios = objIncentivosBU.AceptarSolicitudDirector(seleccion, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Montos, grdFiltroSolicitudes.Rows(sentinela).Cells("clmID_motivo").Value)


                    CountAcept += 1
                    'Dim objBU As New IncentivosBU

                    'Dim FormularioMensaje As New ExitoForm
                    'Dim FormularioError As New AdvertenciaForm



                    'If MensajeNegocios.Length = 0 Then



                    '    grdFiltroSolicitudes.Rows(sentinela).DefaultCellStyle.BackColor = Color.GreenYellow

                    'ElseIf MensajeNegocios = "El monto solicitado excede el limite del monto permitido." Then

                    '    grdFiltroSolicitudes.Rows(sentinela).DefaultCellStyle.BackColor = Color.Salmon


                    'Else

                    '    grdFiltroSolicitudes.Rows(sentinela).DefaultCellStyle.BackColor = Color.Sienna

                    'End If


                End If
                sentinela += 1
            Next
            'If ApareceNomina() = False Then
            '    IDSolicitud = ObjCajas.EnviarSolicitudesCaja(IDCajas, FormadePago, Suma, "Gratificaciones", "SOLICITUD DE EFECTIVO PARA PAGO DE GRATIFICACIONES")
            'End If

        End If
        ' End If

        Dim FormaExito As New ExitoForm
        FormaExito.mensaje = "Solicitudes Autorizadas"
        FormaExito.Show()




        'Dim objIncentivosBU As New IncentivosBU
        'Dim CountAcept As Int32 = 0
        'Dim valorCheck As Integer
        'Dim sentinela As Integer = 0
        'Dim Dialogo As New DialogSeleccionarFormaDePagoForm
        'Dim IDCajas As Int32
        'Dim datosCorrectos As Boolean = True
        'Dim FormadePago As String = String.Empty
        'Dialogo.cmbFormaPago.SelectedIndex = 1
        'For Each row As DataGridViewRow In grdFiltroSolicitudes.Rows 'Recorro todo el grid fila por fila
        '    valorCheck = CInt(row.cells("clmSeleccion").Value)
        '    Dim MensajeNegocios As String = ""
        '    If valorCheck <> 0 Then
        '        seleccion = CInt(grdFiltroSolicitudes.Rows(sentinela).Cells("clmID_SolicitudIncentivo").Value)
        '        Dim Montos As Double
        '        If grdFiltroSolicitudes.Rows(sentinela).Cells("clmMonto").Value = "$" Or grdFiltroSolicitudes.Rows(sentinela).Cells("clmMonto").Value = Nothing Then
        '            Montos = 0
        '        Else
        '            Montos = grdFiltroSolicitudes.Rows(sentinela).Cells("clmMonto").Value
        '        End If
        '        MensajeNegocios = objIncentivosBU.AceptarSolicitudDirector(seleccion, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Montos, grdFiltroSolicitudes.Rows(sentinela).Cells("clmID_motivo").Value)
        '        CountAcept += 1
        '        Dim objBU As New IncentivosBU
        '        'bjBU.EnviarSolicitud(Incentivos)
        '        Dim FormularioMensaje As New ExitoForm
        '        Dim FormularioError As New AdvertenciaForm



        '        If MensajeNegocios.Length = 0 Then



        '            grdFiltroSolicitudes.Rows(sentinela).DefaultCellStyle.BackColor = Color.GreenYellow

        '        ElseIf MensajeNegocios = "El monto solicitado excede el limite del monto permitido." Then

        '            grdFiltroSolicitudes.Rows(sentinela).DefaultCellStyle.BackColor = Color.Salmon


        '        Else

        '            grdFiltroSolicitudes.Rows(sentinela).DefaultCellStyle.BackColor = Color.Sienna

        '        End If


        '    End If
        '    sentinela += 1
        'Next


        'Dim FormaExito As New ExitoForm
        'FormaExito.mensaje = "Solicitudes Realizadas"
        'FormaExito.Show()

        '****************************************

        'Dim objIncentivosBU As New IncentivosBU




        'Dim CountAcept As Int32 = 0
        'Dim valorCheck As Integer
        'Dim sentinela As Integer = 0
        'For Each row As DataGridViewRow In grdFiltroSolicitudes.Rows 'Recorro todo el grid fila por fila
        '    valorCheck = CInt(row.cells("clmConsecutivo").Value)

        '    If valorCheck <> 0 Then
        '        seleccion = CInt(grdFiltroSolicitudes.Rows(sentinela).Cells("clmEstatus").Value)
        '        objIncentivosBU.AceptarSolicitudDirector(seleccion, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        '        CountAcept += 1
        '    End If
        '    sentinela += 1
        'Next

        'If CountAcept = 1 Then
        '    Dim FormaExito As New ExitoForm
        '    FormaExito.mensaje = "Solicitud Aprobada"
        '    FormaExito.Show()

        'ElseIf CountAcept > 1 Then
        '    Dim FormaExito As New ExitoForm
        '    FormaExito.mensaje = "Solicitudes Aprobadas"
        '    FormaExito.Show()
        'Else
        '    Dim FormaExito As New AdvertenciaForm
        '    FormaExito.mensaje = "No ha seleccionado ninguna solicitud"
        '    FormaExito.Show()
        'End If


    End Sub



    Public Sub RechazarSolicitudes()


        Dim objIncentivosBU As New IncentivosBU




        Dim CountAcept As Int32 = 0
        Dim valorCheck As Integer
        Dim sentinela As Integer = 0
        For Each row As DataGridViewRow In grdFiltroSolicitudes.Rows 'Recorro todo el grid fila por fila

            Try
                valorCheck = CInt(row.Cells("clmSeleccion").Value)
            Catch ex As Exception
                valorCheck = 0
            End Try
            If valorCheck <> 0 Then
                seleccion = CInt(grdFiltroSolicitudes.Rows(sentinela).Cells("clmID_SolicitudIncentivo").Value)
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




    Private Sub btnLimpiarSolicitudes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub pbYuyin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Gerente As New ListaAutorizarGerenteFiniquitosForm
        Gerente.Show()
    End Sub

    Private Sub grdFiltroSolicitudes_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            Dim AltaIncentivo As New AltaIncentivoForm
            AltaIncentivo.IdColaborador = grdFiltroSolicitudes.Rows(e.RowIndex).Cells("clmIDEmpleado").Value
            AltaIncentivo.IDSolicitud = grdFiltroSolicitudes.Rows(e.RowIndex).Cells("clmID_SolicitudIncentivo").Value
            AltaIncentivo.ShowDialog()
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        OpcionesDeImprimir.Show(btnImprimir, 0, btnImprimir.Height)
    End Sub



    Public Function ImprimirReporteTabla() As DataTable
        Dim OBJBU As New Negocios.IncentivosBU
        Dim tablas As New DataTable
        tablas = OBJBU.TablaImprimirIncentivos(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, FechaInicial.ToShortDateString, FechaFinal.ToShortDateString, NavesID)
        Return tablas

    End Function

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        If cmbNave.SelectedIndex > 0 Then
            Dim dataSetReporte As New Vista.ReporteIncentivos
            Dim visor As New VisorReportesEnTablas
            NavesID = cmbNave.SelectedValue
            dataSetReporte.SetDataSource(ImprimirReporteTabla())
            FechaInicio.ParameterFieldName = "FechaInicio"
            FechaFin.ParameterFieldName = "FechaFin"
            Naveid.ParameterFieldName = "NaveId"
            myDiscreteValue1.Value = FechaInicial.ToShortDateString
            myDiscreteValue.Value = FechaFinal.ToShortDateString

            If NavesID = 2 Then
                Naveidd.Value = rutaPublica & "LOGOTIPOS/YUYIN.JPG"
            ElseIf NavesID = 3 Then
                Naveidd.Value = rutaPublica & "LOGOTIPOS/JEANS.JPG"
            ElseIf NavesID = 4 Then
                Naveidd.Value = rutaPublica & "LOGOTIPOS/MERANO.JPG"
            ElseIf NavesID = 5 Then
                Naveidd.Value = rutaPublica & "LOGOTIPOS/JEANS2.JPG"
            ElseIf NavesID = 43 Then
                Naveidd.Value = rutaPublica & "LOGOTIPOS/GRUPOYUYIN.JPG"
            End If




            Naveid.CurrentValues.Add(Naveidd)
            FechaInicio.CurrentValues.Add(myDiscreteValue1)

            FechaFin.CurrentValues.Add(myDiscreteValue)


            'Cargo los parametros y los envio al Crystal

            parametros.Add(FechaInicio)

            parametros.Add(FechaFin)
            parametros.Add(Naveid)
            'info.SetDataSource(MiDataSetDatos)
            visor.ReporteViewer.ParameterFieldInfo = parametros

            visor.ReporteViewer.ReportSource = dataSetReporte
            visor.ShowDialog()
            'dataSetReporte = New Vista.ReportesFiniquitos
            visor.Close()
            visor = Nothing
            dataSetReporte = Nothing
        Else
            Dim Advertencia As New AdvertenciaForm
            Advertencia.mensaje = "Seleccione una nave primero"
            Advertencia.ShowDialog()
        End If

    End Sub

    Private Sub dtpSegundaFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        cambiofecha = 1

    End Sub

    Private Sub cmbNave_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
        Try
            If cmbNave.SelectedIndex > 0 Then
                cboxPeriodo = Controles.ComboPeriodoSegunNaveIncentivos(cboxPeriodo, cmbNave.SelectedValue)
                'cboxPeriodo.SelectedIndex = 0
            End If
            If cboxPeriodo.SelectedIndex >= 0 Then
                Dim BuscarFechas As New IncentivosBU
                Try
                    FechaInicial = BuscarFechas.BuscarFechaInicialPerdiodo(cboxPeriodo.SelectedValue)
                    FechaFinal = BuscarFechas.BuscarFechaFinalPerdiodo(cboxPeriodo.SelectedValue)
                Catch ex As Exception

                End Try

            End If


        Catch ex As Exception

        End Try


    End Sub



    Public Function TieneGerente() As Boolean
        Dim ObjBU As New Negocios.ConfiguracionGratificacionesBU
        Dim respuestaGerente As New Boolean

        respuestaGerente = ObjBU.AutorizaGerente(cmbNave.SelectedValue)
        Return respuestaGerente
    End Function

    Public Function TieneDirector() As Boolean
        Dim ObjBU As New Negocios.ConfiguracionGratificacionesBU
        Dim respuestaDirector As New Boolean
        respuestaDirector = ObjBU.AutorizaDirector(cmbNave.SelectedValue)

        Return respuestaDirector
    End Function

    Public Function ApareceNomina() As Boolean
        Dim ObjBU As New Negocios.ConfiguracionGratificacionesBU
        Dim respuestaNomina As New Boolean
        respuestaNomina = ObjBU.ApareceNomina(cmbNave.SelectedValue)

        Return respuestaNomina
    End Function

    Private Sub ConcentradoAnualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim dataSetReportes As New Vista.ConcentradoGratificacionesAnual
        'Dim visor As New VisorReportesEnTablas
        'NavesID = cmbNave.SelectedValue
        'dataSetReportes.SetDataSource(ImprimirTablaGratificacionesConcentrado())
        'Dim objTools As New Tools.ReportesVistaPrevia
        'objTools.ImprimirYuyinERP(dataSetReportes, "", "", "", False, True)
        ''visor.ReporteViewer.ReportSource = dataSetReportes
        ''visor.ShowDialog()
        ''dataSetReporte = New Vista.ReportesFiniquitos
        'visor.Close()
        'visor = Nothing
        'dataSetReportes = Nothing


        'Dim Menu As New MenuConcentradosForm
        'Menu.Show()

    End Sub


    Public Function ImprimirTablaGratificacionesConcentrado() As DataTable
        Dim ObjBu As New IncentivosBU
        Dim DataSetIncentivos As New DataTable
        DataSetIncentivos = ObjBu.ConcentradoAnualGratificaciones(cmbNave.SelectedValue)
        'Dim contador As New Int32
        'contador = DataSetIncentivos.Rows.Count
        Return DataSetIncentivos
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        gpbFiltroIncentivos.Height = 45
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        gpbFiltroIncentivos.Height = 117

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    '
    Private Sub grdFiltroSolicitudes_CellDoubleClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFiltroSolicitudes.CellDoubleClick



        Dim colaboradorid As String = ""
        Dim solicitudid As String = ""
        Dim estatus As String = ""
        Dim estatusAutorizado As New IncentivosBU
        colaboradorid = grdFiltroSolicitudes.Rows(e.RowIndex).Cells("clmIDEmpleado").Value
        solicitudid = grdFiltroSolicitudes.Rows(e.RowIndex).Cells("clmID_SolicitudIncentivo").Value

        If Not IsNothing(solicitudid) Then

            Dim montoNuevo As Double = 0


            If colaboradorid <> "" Then


                estatus = estatusAutorizado.validarEstatusAutorizado(colaboradorid, solicitudid)

                ' If estatus = "A" Then
                Try
                    If e.RowIndex >= 0 Then
                        Dim AltaIncentivo As New AltaIncentivoForm

                        With AltaIncentivo
                            .IDNave = cmbNave.SelectedValue
                            .IdColaborador = grdFiltroSolicitudes.Rows(e.RowIndex).Cells("clmIDEmpleado").Value()
                            .IDSolicitud = grdFiltroSolicitudes.Rows(e.RowIndex).Cells("clmID_SolicitudIncentivo").Value
                            .estatusGratificacion = estatus
                            .ShowDialog()
                            montoNuevo = .montoNuevo

                        End With

                        'AltaIncentivo.IDNave = cmbNave.SelectedValue
                        'AltaIncentivo.IdColaborador = grdFiltroSolicitudes.Rows(e.RowIndex).Cells("clmIDEmpleado").Value
                        'AltaIncentivo.IDSolicitud = grdFiltroSolicitudes.Rows(e.RowIndex).Cells("clmID_SolicitudIncentivo").Value
                        'AltaIncentivo.ShowDialog()
                        'grdFiltroSolicitudes.Rows.Clear()
                        '  llenartabla()
                        ' Pintartabla()
                        grdFiltroSolicitudes.Rows(e.RowIndex).Cells("clmmonto").Value = montoNuevo.ToString("N2")
                        If grdFiltroSolicitudes.Rows.Count > 0 Then
                            SumaTotal = 0
                            grdFiltroSolicitudes.Rows.Remove(grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1))

                            For Each row As DataGridViewRow In grdFiltroSolicitudes.Rows
                                SumaTotal += row.Cells("clmmonto").Value
                            Next


                            grdFiltroSolicitudes.Rows.Add("", "", "Total", "", "", SumaTotal.ToString("N2"), "", Date.MinValue, Date.MinValue, "", "", "", "")
                            grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1).Cells("clmFecha_Solicitud").Style.ForeColor = Color.GreenYellow
                            grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1).Cells("clmFecha_Autorizacion").Style.ForeColor = Color.GreenYellow
                            grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1).DefaultCellStyle.BackColor = Color.GreenYellow
                        End If

                        Try

                            If cboxPeriodo.SelectedValue >= 0 Then
                                Dim BuscarFechas As New IncentivosBU
                                Try
                                    FechaInicial = BuscarFechas.BuscarFechaInicialPerdiodo(cboxPeriodo.SelectedValue)
                                    FechaFinal = BuscarFechas.BuscarFechaFinalPerdiodo(cboxPeriodo.SelectedValue)
                                Catch ex As Exception

                                End Try

                            End If


                        Catch ex As Exception

                        End Try

                    End If
                Catch ex As Exception

                End Try
            End If
            '  End If
        End If
    End Sub

    Private Sub grdFiltroSolicitudes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFiltroSolicitudes.DoubleClick

    End Sub

    Private Sub cboxPeriodo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxPeriodo.SelectedIndexChanged
        Try

            If cboxPeriodo.SelectedValue >= 0 Then
                Dim BuscarFechas As New IncentivosBU
                Try
                    FechaInicial = BuscarFechas.BuscarFechaInicialPerdiodo(cboxPeriodo.SelectedValue)
                    FechaFinal = BuscarFechas.BuscarFechaFinalPerdiodo(cboxPeriodo.SelectedValue)
                Catch ex As Exception

                End Try

            End If


        Catch ex As Exception

        End Try
    End Sub



    Private Sub pnlMinimizarParametros_Paint(sender As Object, e As PaintEventArgs) Handles pnlMinimizarParametros.Paint

    End Sub

    Private Sub pnlColores_Paint(sender As Object, e As PaintEventArgs) Handles pnlColores.Paint

    End Sub

    Private Sub btnFiltrarSolicitud_Click_1(sender As Object, e As EventArgs) Handles btnFiltrarSolicitud.Click
        Try

            If cboxPeriodo.SelectedValue >= 0 Then
                Dim BuscarFechas As New IncentivosBU
                Try
                    FechaInicial = BuscarFechas.BuscarFechaInicialPerdiodo(cboxPeriodo.SelectedValue)
                    FechaFinal = BuscarFechas.BuscarFechaFinalPerdiodo(cboxPeriodo.SelectedValue)
                Catch ex As Exception

                End Try

            End If


        Catch ex As Exception

        End Try


        grdFiltroSolicitudes.Rows.Clear()
        If cmbStatus.Text <> "" Then
            llenartabla()
            Pintartabla()
        End If

        If grdFiltroSolicitudes.Rows.Count > 0 Then
            grdFiltroSolicitudes.Rows.Add("", "", "Total", "", "", SumaTotal.ToString("N2"), "", "", "", "", "", "", "")
            grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1).Cells("clmFecha_Solicitud").Style.ForeColor = Color.GreenYellow
            grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1).Cells("clmFecha_Autorizacion").Style.ForeColor = Color.GreenYellow
            grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1).DefaultCellStyle.BackColor = Color.GreenYellow
        End If
    End Sub

    Private Sub btnLimpiarSolicitudes_Click1(sender As Object, e As EventArgs) Handles btnLimpiarSolicitudes.Click
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




    Private Sub SeleccionarTodosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionarTodosToolStripMenuItem.Click
        If cmbStatus.Text = "SOLICITADO" Then
            For Each row As DataGridViewRow In grdFiltroSolicitudes.Rows
                If row.Cells("clmNombre").Value <> "Total" Then
                    row.Cells("clmSeleccion").Value = True
                End If

            Next
        End If
    End Sub

    Private Sub pcbTitulo_Click(sender As Object, e As EventArgs) Handles pcbTitulo.Click

    End Sub

    Private Sub DeseleccionarTodosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeseleccionarTodosToolStripMenuItem.Click
        If cmbStatus.Text = "SOLICITADO" Then
            For Each row As DataGridViewRow In grdFiltroSolicitudes.Rows
                If row.Cells("clmNombre").Value <> "Total" Then
                    row.Cells("clmSeleccion").Value = False
                End If

            Next
        End If
    End Sub


End Class