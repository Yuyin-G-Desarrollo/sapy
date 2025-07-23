Imports Nomina.Negocios
Imports Stimulsoft.Report
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ListaSolicitudIncentivoForm
    Dim SumaTotal As Double
    Dim seleccion As Int32
    Dim Estatus As String
    Dim cambiofecha As Int32 = 0
    Dim Naves As Int32
    Dim FechaInicial, FechaFinal As New Date
    Dim Consecutivo As Int32
    Dim permisoAutorizarRechazar As Boolean = False

    Public Sub llenarComboCajas()
        Dim objCajas As New CajasBU
        Dim dtCajas As New DataTable
        dtCajas = objCajas.listaCajas(CInt(cmbNave.SelectedValue))

        If dtCajas.Rows.Count > 0 Then
            cmbCajas.DataSource = dtCajas
            cmbCajas.DisplayMember = "Nombre"
            cmbCajas.ValueMember = "Id_Caja"
            cmbCajas.Visible = True
            lblAlertaSinCaja.Visible = False
        Else
            cmbCajas.Visible = False
            lblAlertaSinCaja.Visible = True
        End If
    End Sub

    Public Sub RechazarSolicitudes()
        Dim objIncentivosBU As New IncentivosBU
        Dim guardo As Boolean = False
        Dim contSolicitudesRechazadas As Int32 = 0
        For Each rowGR As UltraGridRow In grdSolicitudes.Rows
            If CBool(rowGR.Cells("Seleccion").Value) = True And rowGR.Cells("soin_estado").Value = "A" Then
                objIncentivosBU.RechazarSolicitud(rowGR.Cells("soin_solicitudincentivoid").Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                guardo = True
                contSolicitudesRechazadas += 1
            End If
        Next
        If guardo = True Then
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Se rechazarón " + contSolicitudesRechazadas.ToString + " gratificaciones."
            FormaExito.ShowDialog()
            llenartabla()
        Else
            Dim FormaExito As New AvisoForm
            FormaExito.mensaje = "No se realizo ningun cambio."
            FormaExito.ShowDialog()
        End If
    End Sub

    Public Sub AutorizarSolicitudes()
        Dim objIncentivosBU As New IncentivosBU
        Dim MensajeNegocios As String = ""
        Dim guardo As Boolean = False
        Dim contSolicitudesAceptadas As Int32 = 0

        For Each rowGr As UltraGridRow In grdSolicitudes.Rows
            MensajeNegocios = ""
            If CBool(rowGr.Cells("Seleccion").Value) = True And rowGr.Cells("soin_estado").Value = "A" Then
                MensajeNegocios = objIncentivosBU.AceptarSolicitud(rowGr.Cells("soin_solicitudincentivoid").Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, CDbl(rowGr.Cells("TOTAL").Value), rowGr.Cells("MotUnoID").Value)
                guardo = True
                contSolicitudesAceptadas += 1
            End If
        Next
        If guardo = True Then
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Gratificaciones autorizadas correctamente. Se autorizarón " + contSolicitudesAceptadas.ToString + " gratificaciones."
            FormaExito.ShowDialog()
            llenartabla()
        Else
            Dim FormaExito As New AvisoForm
            FormaExito.mensaje = "No se realizo ningun cambio."
            FormaExito.ShowDialog()
        End If
    End Sub

    Public Sub solicitarCajaChica()
        Dim objIncentivosBU As New IncentivosBU
        Dim totalMontoSolicitado As Double = 0
        'Dim Dialogo As New DialogSeleccionarFormaDePagoForm

        Dim datosCorrectos As Boolean = True
        Dim FormadePago As String = String.Empty
        Dim guardo As Boolean = False
        Dim contSolicitudesAceptadas As Int32 = 0

        ' ''Dialogo.cmbFormaPago.SelectedIndex = 1
        ''If Dialogo.ShowDialog = DialogResult.OK Then
        ''IDCajas = Dialogo.idCaja
        ''FormadePago = Dialogo.formaPago

        Dim objCaja As New Negocios.CajasBU
        Dim IDCajas As Int32
        IDCajas = objCaja.consultaCajaUsuarioSAY

        If Not cmbCajas.DataSource Is Nothing Then
            IDCajas = cmbCajas.SelectedValue
        Else
            IDCajas = 0
        End If

        FormadePago = "EFECTIVO"

        If IDCajas > 0 Then
            If FormadePago.Length = 0 Then
                datosCorrectos = False
            End If
            If datosCorrectos = True Then
                Dim ObjCajas As New Negocios.CajasBU
                Dim objBUFiniquito As New Negocios.FiniquitosBU
                Dim SumaSolicitud As Double = 0
                Dim IDSolicitud As Int32

                For Each rowGR As UltraGridRow In grdSolicitudes.Rows
                    If rowGR.Cells("soin_estado").Value = "B" And CBool(rowGR.Cells("moin_diaadicional").Value) = False Then
                        Dim MensajeNegocios As String = ""
                        Dim Montos As Double
                        Montos = rowGR.Cells("Total").Value
                        SumaSolicitud += rowGR.Cells("Total").Value
                        objIncentivosBU.SolicitarCajaChicaIncentivo(rowGR.Cells("soin_solicitudincentivoid").Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Montos, rowGR.Cells("MotUnoID").Value, 0)
                        guardo = True
                    End If
                Next

                If ApareceNomina() = False And TieneDirector() = False Then
                    IDSolicitud = ObjCajas.EnviarSolicitudesCajaGratificaciones(IDCajas, FormadePago, SumaSolicitud, "Gratificaciones", "SOLICITUD DE EFECTIVO PARA PAGO DE GRATIFICACIONES")

                    For Each rowGR As UltraGridRow In grdSolicitudes.Rows
                        If rowGR.Cells("soin_estado").Value = "B" And CBool(rowGR.Cells("moin_diaadicional").Value) = False Then
                            Dim Montos As Double
                            Montos = rowGR.Cells("Total").Value
                            objIncentivosBU.SolicitarCajaChicaIncentivo(rowGR.Cells("soin_solicitudincentivoid").Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Montos, rowGR.Cells("MotUnoID").Value, IDSolicitud)
                            guardo = True
                        End If
                    Next
                End If
            Else
                Dim FormaExito As New Tools.AdvertenciaForm
                FormaExito.mensaje = "Se cancelo la transacción. Seleccione una forma de pago correcta."
                FormaExito.ShowDialog()
            End If
        Else
            Dim FormaExito As New Tools.AdvertenciaForm
            FormaExito.mensaje = "Se cancelo la transacción, el usuario no tiene relacion con una caja."
            FormaExito.ShowDialog()
        End If
        If guardo = True Then
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Solicitado a caja chica"
            FormaExito.ShowDialog()
            llenartabla()
        End If

    End Sub

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


    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gpbFiltroIncentivos.Height = 32
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gpbFiltroIncentivos.Height = 176
    End Sub

    Private Sub btnAltaIncentivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltaIncentivo.Click
        Dim NuevaSolicitud As New AltaGratificacion
        NuevaSolicitud.ShowDialog()
        llenartabla()
    End Sub

    Private Sub ListaSolicitudIncentivoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_SOL_INCE", "AUTORIZARECHAZASOLICITUD") Then
            pnlAutorizar.Visible = True
            permisoAutorizarRechazar = True
            chkSeleccionarTodo.Visible = True
        Else
            pnlAutorizar.Visible = False
            permisoAutorizarRechazar = False
            chkSeleccionarTodo.Visible = False
        End If

        'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_SOL_INCE", "SOLICITARCAJACHICA") Then
        '    pnlSolicitar.Visible = True
        'Else
        '    pnlSolicitar.Visible = False
        'End If

        'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_SOL_INCE", "SOLICITARCAJACHICA") Then
        '    pnlSolicitar.Visible = True
        'Else
        '    pnlSolicitar.Visible = False
        'End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_SOL_INCE", "NOM_SOL_DIA_ADICIONAL") Then
            pnlDiaAdicional.Visible = True
        Else
            pnlDiaAdicional.Visible = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_SOL_INCE", "ALTA_GRATIFICACION") Then
            pnlNuevaGratificacion.Visible = True
        Else
            pnlNuevaGratificacion.Visible = False
        End If
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        ' llenarComboCajas()
        cmbStatus.SelectedIndex = 2

        Me.Panel3.BackColor = Color.Salmon ' rechazado
        'Me.Panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#BAEBFF ") 'director
        Me.Panel5.BackColor = System.Drawing.ColorTranslator.FromHtml("#96CF3A") ' gerente
        Me.Panel6.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFBB8 ") 'solicitado
        Me.pnlCajaChica.BackColor = System.Drawing.ColorTranslator.FromHtml("#088A85")
        Me.pnlPagado.BackColor = Color.LightSkyBlue



        ''grdFiltroSolicitudes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        ''grdFiltroSolicitudes.Columns.Add("Consecutivo", "#") '0
        ''grdFiltroSolicitudes.Columns("Consecutivo").SortMode = DataGridViewColumnSortMode.NotSortable
        ''grdFiltroSolicitudes.Columns("Consecutivo").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        ' ''-----------------------------------------------------------------
        ''grdFiltroSolicitudes.Columns.Add("Nombre", "Nombre") '1
        ''grdFiltroSolicitudes.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells 'DataGridViewAutoSizeColumnMode.Fill
        ' ''---------------------------------------------------
        ''grdFiltroSolicitudes.Columns.Add("Departamento", "Departamento") '2
        ''grdFiltroSolicitudes.Columns("Departamento").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        ' ''---------------------------------------------------
        ''grdFiltroSolicitudes.Columns.Add("Celula", "Celula") '2
        ''grdFiltroSolicitudes.Columns("Celula").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        ' ''-----------------------------------------------------
        ''grdFiltroSolicitudes.Columns.Add("Monto", "Total") '3
        ''grdFiltroSolicitudes.Columns("Monto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        ' ''----------------------------------------------'**4
        ''grdFiltroSolicitudes.Columns.Add("Monto_1", "Monto1")
        ''grdFiltroSolicitudes.Columns("Monto_1").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells 'DataGridViewContentAlignment.MiddleRight
        ''grdFiltroSolicitudes.Columns("Monto_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        ' ''------------------------------------------------------ '4 **5
        ''grdFiltroSolicitudes.Columns.Add("Motivo", "Motivo 1")
        ''grdFiltroSolicitudes.Columns("Motivo").Visible = True
        ''grdFiltroSolicitudes.Columns("Motivo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        ' ''------------------------------------------------------'**6
        ''grdFiltroSolicitudes.Columns.Add("Monto_2", "Monto2")
        ''grdFiltroSolicitudes.Columns("Monto_2").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        ''grdFiltroSolicitudes.Columns("Monto_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' ''------------------------------------------------------**7
        ''grdFiltroSolicitudes.Columns.Add("Motivo2", "Motivo 2")
        ''grdFiltroSolicitudes.Columns("Motivo2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        ' ''-----------------------------------------------------**8
        ''grdFiltroSolicitudes.Columns.Add("Monto_3", "Monto3")
        ''grdFiltroSolicitudes.Columns("Monto_3").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        ''grdFiltroSolicitudes.Columns("Monto_3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        ' ''------------------------------------------------------**9
        ''grdFiltroSolicitudes.Columns.Add("Motivo3", "Motivo 3")
        ''grdFiltroSolicitudes.Columns("Motivo3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' ''-------------------------------------------------------
        ''grdFiltroSolicitudes.Columns.Add("Fecha_Solicitud", "Fecha de Solicitud") '5
        ''grdFiltroSolicitudes.Columns("Fecha_Solicitud").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        ''grdFiltroSolicitudes.Columns("Fecha_Solicitud").SortMode = DataGridViewColumnSortMode.NotSortable
        '' ''--------------------------------------------------------
        ''grdFiltroSolicitudes.Columns.Add("Fecha_Autorizacion", "Fecha de Autorización") '6
        ''grdFiltroSolicitudes.Columns("Fecha_Autorizacion").SortMode = DataGridViewColumnSortMode.NotSortable
        ''grdFiltroSolicitudes.Columns("Fecha_Autorizacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        ' ''---------------------------------------------------------
        ''grdFiltroSolicitudes.Columns.Add("Solicito", "Solicitó") '7
        ''grdFiltroSolicitudes.Columns("Solicito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        ' ''------------------------------------------------
        ''grdFiltroSolicitudes.Columns.Add("Autorizo", "Autorizó") '8
        ''grdFiltroSolicitudes.Columns("Autorizo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        ' ''---------------------------------------------------------------------------
        ''grdFiltroSolicitudes.Columns.Add("IDEmpleado", "IDEmpleado") '9
        ''grdFiltroSolicitudes.Columns("IDEmpleado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ''grdFiltroSolicitudes.Columns("IDEmpleado").Visible = False
        ' ''----------------------------------------
        ''grdFiltroSolicitudes.Columns.Add("Estatus", "Estatus") '10
        ''grdFiltroSolicitudes.Columns("Estatus").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        ''grdFiltroSolicitudes.Columns("Estatus").Visible = False
        ' ''----------------------------------------------
        ''grdFiltroSolicitudes.Columns.Add("ID_SolicitudIncentivo", "ID_SolicitudIncentivo") '11
        ''grdFiltroSolicitudes.Columns("ID_SolicitudIncentivo").Visible =
        ''grdFiltroSolicitudes.Columns("ID_SolicitudIncentivo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        ' ''----------------------------------------------
        ''grdFiltroSolicitudes.Columns.Add("Observacion", "Observación") '12
        ''grdFiltroSolicitudes.Columns("Observacion").Visible = False
        ''grdFiltroSolicitudes.Columns("Observacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft


        Dim dt As New DateTime
        Dim fechas As String
        fechas = dt.ToString
        ' llenartabla()
        ' Pintartabla()
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

            If cmbNave.SelectedValue > 0 Then
                Naves = cmbNave.SelectedValue
                'grdFiltroSolicitudes.Rows.Clear()
                'llenartabla()
                'Pintartabla()
                llenarComboCajas()
            Else
                Naves = 0
            End If
        Catch ex As Exception

        End Try
        lblTotal.Visible = False
        WindowState = FormWindowState.Maximized
    End Sub


    'Public Sub Pintartabla()
    '    Dim hasta As New Int32
    '    'hasta = grdFiltroSolicitudes.Rows.Count - 1
    '    For i = 0 To hasta
    '        'If grdFiltroSolicitudes.Rows(i).Cells("Estatus").Value = "A" Then 'Solicitado
    '        '    grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFBB8")
    '        'ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estatus").Value = "B" Then 'Autorizado Gerente
    '        '    grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#96CF3A")
    '        'ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estatus").Value = "C" Then ' Autorizado Director
    '        '    grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#BAEBFF")
    '        'ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estatus").Value = "D" Then ' Rechazado
    '        '    grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF96")
    '        'ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estatus").Value = "E" Then
    '        '    grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#C5C5C5")
    '        'ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estatus").Value = "F" Then
    '        '    grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#088A85")
    '        'ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estatus").Value = "P" Then
    '        '    grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
    '        'End If

    '        'If grdFiltroSolicitudes.Rows(i).Cells("Observacion").Value = "NO SE CAPTURO DESCRIPCION" Then

    '        'Else
    '        '    grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF96")
    '        'End If
    '    Next
    'End Sub

    ''Public Sub AgregarFila(ByVal Solicitudincentivos As Entidades.SolicitudIncentivos)

    ''    Dim celda As DataGridViewCell
    ''    Dim fila As New DataGridViewRow

    ''    celda = New DataGridViewTextBoxCell
    ''    celda.Value = Consecutivo
    ''    fila.Cells.Add(celda)


    ''    celda = New DataGridViewTextBoxCell
    ''    celda.Value = Solicitudincentivos.PNombreColaborador.PNombre.ToUpper & " " & Solicitudincentivos.PNombreColaborador.PApaterno.ToUpper & " " & Solicitudincentivos.PNombreColaborador.PAmaterno.ToUpper
    ''    fila.Cells.Add(celda)


    ''    celda = New DataGridViewTextBoxCell
    ''    celda.Value = Solicitudincentivos.PDepartamento.DNombre.ToUpper
    ''    fila.Cells.Add(celda)

    ''    celda = New DataGridViewTextBoxCell
    ''    celda.Value = Solicitudincentivos.Pcelulas.PNombre.ToUpper
    ''    fila.Cells.Add(celda)

    ''    celda = New DataGridViewTextBoxCell
    ''    celda.Value = Solicitudincentivos.PMonto.ToString("N2")
    ''    fila.Cells.Add(celda)
    ''    SumaTotal += Solicitudincentivos.PMonto

    ''    celda = New DataGridViewTextBoxCell 'monto 1
    ''    celda.Value = Solicitudincentivos.PMontoGratificacion1.ToString("N2")
    ''    fila.Cells.Add(celda)

    ''    celda = New DataGridViewTextBoxCell 'motivo 1
    ''    celda.Value = Solicitudincentivos.PNombreIncentivo.INombre.ToUpper
    ''    fila.Cells.Add(celda)

    ''    celda = New DataGridViewTextBoxCell 'monto 2
    ''    celda.Value = Solicitudincentivos.PMontoGratificacion2.ToString("N2")
    ''    fila.Cells.Add(celda)

    ''    celda = New DataGridViewTextBoxCell 'motivo 2
    ''    celda.Value = Solicitudincentivos.PMotivoID2.INombre.ToUpper
    ''    fila.Cells.Add(celda)

    ''    celda = New DataGridViewTextBoxCell 'monto 3
    ''    celda.Value = Solicitudincentivos.PMontoGratificacion3.ToString("N2")
    ''    fila.Cells.Add(celda)

    ''    celda = New DataGridViewTextBoxCell 'motivo 3
    ''    celda.Value = Solicitudincentivos.PMotivoID3.INombre.ToUpper
    ''    fila.Cells.Add(celda)

    ''    celda = New DataGridViewTextBoxCell
    ''    celda.Value = Solicitudincentivos.PFechaSolicitud.ToShortDateString
    ''    fila.Cells.Add(celda)

    ''    celda = New DataGridViewTextBoxCell
    ''    If (Solicitudincentivos.PFechaAutorizacion.ToShortDateString = CDate("01/01/0001")) Then
    ''        celda.Value = " "
    ''    Else
    ''        celda.Value = Solicitudincentivos.PFechaAutorizacion.ToShortDateString
    ''    End If

    ''    fila.Cells.Add(celda)


    ''    celda = New DataGridViewTextBoxCell
    ''    celda.Value = Solicitudincentivos.PSolicito.PUserUsername
    ''    fila.Cells.Add(celda)

    ''    celda = New DataGridViewTextBoxCell
    ''    celda.Value = Solicitudincentivos.PAutorizo.PUserUsername
    ''    fila.Cells.Add(celda)

    ''    celda = New DataGridViewTextBoxCell
    ''    celda.Value = Solicitudincentivos.PColaboradorID
    ''    fila.Cells.Add(celda)

    ''    celda = New DataGridViewTextBoxCell
    ''    celda.Value = Solicitudincentivos.PEstatus
    ''    fila.Cells.Add(celda)

    ''    celda = New DataGridViewTextBoxCell
    ''    celda.Value = Solicitudincentivos.PSolicitudID
    ''    fila.Cells.Add(celda)

    ''    celda = New DataGridViewTextBoxCell
    ''    celda.Value = Solicitudincentivos.PDescripcion
    ''    fila.Cells.Add(celda)




    ''    'grdFiltroSolicitudes.Rows.Add(fila)

    ''End Sub

    Public Sub llenartabla()
        grdSolicitudes.DataSource = Nothing
        chkSeleccionarTodo.Checked = False
        'If Naves > 0 Then
        Dim Estatus As String = ""
        If cmbStatus.Text = "" Then
            Estatus = ""
        ElseIf cmbStatus.Text = "TODOS" Then
            Estatus = ""
        ElseIf cmbStatus.Text = "SOLICITADO" Then
            Estatus = "A"
        ElseIf cmbStatus.Text = "Autorizado".ToUpper Then
            Estatus = "B"
            'ElseIf cmbStatus.Text = "Autorizado".ToUpper Then
            '    Estatus = "C"
        ElseIf cmbStatus.Text = "Rechazado".ToUpper Then
            Estatus = "D"
        ElseIf cmbStatus.Text = "SOLICITADO A CAJA CHICA".ToUpper Then
            Estatus = "F"
        ElseIf cmbStatus.Text = "PAGADO".ToUpper Then
            Estatus = "P"
        End If

        Dim confecha As String
        '  Dim SegundaFecha As String
        If cambiofecha = 1 Then
            'Dim dt As DateTime = Fecha.Value.Date
            'confecha = Fecha.Value.ToString("dd/MM/yyyy")
            'SegundaFecha = dtpSegundaFecha.Value.ToString("dd/MM/yyyy")
        Else
            confecha = ""
        End If

        Dim Naveid As Int32
        If cmbNave.SelectedIndex > 0 Then
            Naveid = cmbNave.SelectedValue
        End If
        ''Dim listaSolicitudes As New List(Of Entidades.SolicitudIncentivos)
        Dim objBU As New Negocios.IncentivosBU
        Dim dtSolicitudes As New DataTable
        Dim numero As New Int32
        numero = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim Accesototal As Integer = 0

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_INCE_AUT", "WRITE") Then
            Accesototal = 1
        Else
            Accesototal = 0
        End If
        If cmbNave.SelectedIndex > 0 Then
            If cboxPeriodo.SelectedIndex > 0 Then
                dtSolicitudes = objBU.ListaSolicitudesIncentivosConsulta(txtBuscarNombreIncentivo.Text, Estatus, numero, Naveid, Accesototal, CInt(cboxPeriodo.SelectedValue))
                If dtSolicitudes.Rows.Count > 0 Then
                    grdSolicitudes.DataSource = dtSolicitudes
                    formatoGrid()
                Else
                    Dim objMensaje As New Tools.AdvertenciaForm
                    objMensaje.mensaje = "La consulta no regreso resultados."
                    objMensaje.ShowDialog()
                End If
            End If
        End If
        'quitar
        ''Consecutivo = 1
        ''For Each objeto As Entidades.SolicitudIncentivos In listaSolicitudes
        ''    AgregarFila(objeto)
        ''    Consecutivo += 1
        ''Next
        'quitar
        'Else
        '    Dim objMensaje As New Tools.AdvertenciaForm
        '    objMensaje.mensaje = "Seleccione una nave."
        '    objMensaje.ShowDialog()
        'End If
    End Sub

    Public Sub formatoGrid()
        With grdSolicitudes.DisplayLayout.Bands(0)

            .Columns("soin_solicitudincentivoid").Hidden = True
            .Columns("codr_colaboradorid").Hidden = True
            .Columns("grup_grupoid").Hidden = True
            .Columns("celu_celulaid").Hidden = True
            .Columns("IDSOLICITO").Hidden = True
            .Columns("IDAUTORIZO").Hidden = True
            .Columns("MotUnoID").Hidden = True
            .Columns("MotDosID").Hidden = True
            .Columns("MotTresID").Hidden = True
            .Columns("soin_justificación").Hidden = True
            .Columns("moin_diaadicional").Hidden = True
            .Columns("soin_estado").Hidden = True

            .Columns("soin_justificación").Header.Caption = "Justificación"
            .Columns("NOMBRE").Header.Caption = "Colaborador"
            .Columns("DEPARTAMENTO").Header.Caption = "Departamento"
            .Columns("CELULA").Header.Caption = "Célula"
            .Columns("MotUno").Header.Caption = "Motivo 1"
            .Columns("montouno").Header.Caption = "Cantidad"
            .Columns("MotDos").Header.Caption = "Motivo 2"
            .Columns("montodos").Header.Caption = "Cantidad"
            .Columns("MotTres").Header.Caption = "Motivo 3"
            .Columns("montotres").Header.Caption = "Cantidad"
            .Columns("USUARIOSOLICITO").Header.Caption = "Solicitó"
            .Columns("USUARIOAUTORIZO").Header.Caption = "Autorizó"
            .Columns("FECHASOLICITO").Header.Caption = "Fecha Solicitd"
            .Columns("FECHAAUTORIZO").Header.Caption = "Fecha Autorizo"
            .Columns("TOTAL").Header.Caption = "Total"
            .Columns("soin_estado").Header.Caption = ""
            .Columns("Seleccion").Header.Caption = ""
            .Columns("Color").Header.Caption = ""

            '.Columns("MotUno").CellAppearance.BackColor = Color.Silver
            '.Columns("montouno").CellAppearance.BackColor = Color.Silver
            '.Columns("MotDos").CellAppearance.BackColor = Color.Khaki
            '.Columns("montodos").CellAppearance.BackColor = Color.Khaki
            '.Columns("MotTres").CellAppearance.BackColor = Color.LightPink
            '.Columns("montotres").CellAppearance.BackColor = Color.LightPink

            .Columns("MotUno").Header.Appearance.ForeColor = Color.DodgerBlue
            .Columns("montouno").Header.Appearance.ForeColor = Color.DodgerBlue
            .Columns("MotDos").Header.Appearance.ForeColor = Color.Orange
            .Columns("montodos").Header.Appearance.ForeColor = Color.Orange
            .Columns("MotTres").Header.Appearance.ForeColor = Color.HotPink
            .Columns("montotres").Header.Appearance.ForeColor = Color.HotPink

            .Columns("soin_justificación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NOMBRE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("DEPARTAMENTO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("CELULA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("MotUnoID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("MotUno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("MotDosID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("MotDos").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("MotTresID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("MotTres").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("USUARIOSOLICITO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("USUARIOAUTORIZO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("FECHASOLICITO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("FECHAAUTORIZO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("TOTAL").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("montouno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("montodos").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("montotres").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("soin_estado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Color").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("montouno").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("montodos").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("montotres").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("TOTAL").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("Seleccion").Style = ColumnStyle.CheckBox

            .Columns("Seleccion").AllowRowFiltering = DefaultableBoolean.False
            .Columns("soin_estado").AllowRowFiltering = DefaultableBoolean.False

            .Columns("montouno").Format = "###,###,##0.00"
            .Columns("montodos").Format = "###,###,##0.00"
            .Columns("montotres").Format = "###,###,##0.00"
            .Columns("TOTAL").Format = "###,###,##0.00"

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

            If permisoAutorizarRechazar = False Then
                .Columns("Seleccion").Hidden = True
            End If

        End With

        grdSolicitudes.DisplayLayout.Bands(0).Columns.Add("Configuracion", "Configuracion")
        Dim colConfiguracion As UltraGridColumn = grdSolicitudes.DisplayLayout.Bands(0).Columns("Configuracion")
        colConfiguracion.AllowRowFiltering = DefaultableBoolean.False
        colConfiguracion.Header.Caption = ""
        colConfiguracion.Style = ColumnStyle.Image

        Dim sumuno As SummarySettings = grdSolicitudes.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudes.DisplayLayout.Bands(0).Columns("montouno"))
        Dim sumdos As SummarySettings = grdSolicitudes.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudes.DisplayLayout.Bands(0).Columns("montodos"))
        Dim sumtres As SummarySettings = grdSolicitudes.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudes.DisplayLayout.Bands(0).Columns("montotres"))
        Dim sumTotal As SummarySettings = grdSolicitudes.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudes.DisplayLayout.Bands(0).Columns("TOTAL"))

        sumuno.DisplayFormat = "{0:#,##0.00}"
        sumuno.Appearance.TextHAlign = HAlign.Right
        sumdos.DisplayFormat = "{0:#,##0.00}"
        sumdos.Appearance.TextHAlign = HAlign.Right
        sumtres.DisplayFormat = "{0:#,##0.00}"
        sumtres.Appearance.TextHAlign = HAlign.Right
        sumTotal.DisplayFormat = "{0:#,##0.00}"
        sumTotal.Appearance.TextHAlign = HAlign.Right
        sumTotal.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True


        grdSolicitudes.DisplayLayout.Bands(0).SummaryFooterCaption = "Total"

        grdSolicitudes.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdSolicitudes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdSolicitudes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdSolicitudes.DisplayLayout.Override.RowSelectorWidth = 35
        grdSolicitudes.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdSolicitudes.Rows(0).Selected = True
        grdSolicitudes.DisplayLayout.Bands(0).Columns("Color").Width = 18
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged
        llenartabla()
        If cmbStatus.SelectedIndex > 0 Then
            If cmbStatus.Text = "AUTORIZADO" Then
                btnSolicitar.Enabled = True
                lblSolicitar.Enabled = True
            Else
                btnSolicitar.Enabled = False
                lblSolicitar.Enabled = False
            End If
        End If
        'grdFiltroSolicitudes.Rows.Clear()
        'llenartabla()
        'Pintartabla()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'grdFiltroSolicitudes.Rows.Clear()
        cambiofecha = 1
        'llenartabla()
        'Pintartabla()

    End Sub



    Private Sub btnFiltrarSolicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        SumaTotal = 0
        llenartabla()
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

    'Private Sub btnEditarIncentivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If MessageBox.Show("¿Esta seguro que quiere cancelar la solicitud?", "Solicitud Cancelada", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
    '        CancelarSolicitud()
    '        llenartabla()
    '    End If
    'End Sub

    Public Sub CancelarSolicitud()
        Dim objIncentivosBU As New IncentivosBU
        objIncentivosBU.CancelarSolicitud(seleccion)

        Dim FormaExito As New ExitoForm
        FormaExito.mensaje = "Solicitud Cancelada"
        FormaExito.Show()
    End Sub

    'Private Sub grdFiltroSolicitudes_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    Try
    '        If e.RowIndex >= 0 Then
    '            seleccion = CInt(grdFiltroSolicitudes.Rows(e.RowIndex).Cells("ID_SolicitudIncentivo").Value)
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub

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

    Private Sub btnLimpiarSolicitudes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dt As New DateTime
        Dim fecha As String
        fecha = dt.ToString
        txtBuscarNombreIncentivo.Text = ""
        Estatus = ""
        cmbStatus.Text = ""
        cambiofecha = 0
        llenartabla()
    End Sub

    Private Sub btnAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    ''Private Sub grdFiltroSolicitudes_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    ''    Dim colaboradorid As String = ""
    ''    Dim solicitudid As String = ""
    ''    Dim estatus As String = ""
    ''    Dim estatusAutorizado As New IncentivosBU
    ''    Dim tablaConfiguracion As DataTable
    ''    colaboradorid = grdFiltroSolicitudes.Rows(e.RowIndex).Cells("IDEmpleado").Value
    ''    solicitudid = grdFiltroSolicitudes.Rows(e.RowIndex).Cells("ID_SolicitudIncentivo").Value

    ''    If Not IsNothing(solicitudid) Then
    ''        estatus = estatusAutorizado.validarEstatusAutorizado(colaboradorid, solicitudid)

    ''        tablaConfiguracion = estatusAutorizado.validarConfiguracion(cmbNave.SelectedValue)
    ''        Dim autorizaGerente As Boolean = False
    ''        Dim autorizaDirector As Boolean = False
    ''        Dim montoNuevo As Double = 0

    ''        ' If estatus <> "B" Then
    ''        SumaTotal = 0
    ''        If e.RowIndex >= 0 Then

    ''            Dim AltaIncentivo As New AltaIncentivoForm

    ''            With AltaIncentivo
    ''                .IDNave = cmbNave.SelectedValue
    ''                .IdColaborador = grdFiltroSolicitudes.Rows(e.RowIndex).Cells("IDEmpleado").Value()
    ''                .IDSolicitud = grdFiltroSolicitudes.Rows(e.RowIndex).Cells("ID_SolicitudIncentivo").Value
    ''                .estatusGratificacion = estatus
    ''                .ShowDialog()
    ''                montoNuevo = .montoNuevo

    ''            End With

    ''            grdFiltroSolicitudes.Rows(e.RowIndex).Cells("Monto").Value = montoNuevo.ToString("N2")
    ''            If grdFiltroSolicitudes.Rows.Count > 0 Then
    ''                SumaTotal = 0
    ''                grdFiltroSolicitudes.Rows.Remove(grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1))

    ''                For Each row As DataGridViewRow In grdFiltroSolicitudes.Rows
    ''                    SumaTotal += row.Cells("Monto").Value
    ''                Next

    ''                grdFiltroSolicitudes.Rows.Add("", "", "Total", "", SumaTotal.ToString("N2"), "", Date.MinValue, Date.MinValue, "", "", "", "")
    ''                grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1).Cells("Fecha_Solicitud").Style.ForeColor = Color.GreenYellow
    ''                grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1).Cells("Fecha_Autorizacion").Style.ForeColor = Color.GreenYellow
    ''                grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1).DefaultCellStyle.BackColor = Color.GreenYellow
    ''            End If

    ''            'Dim AltaIncentivo As New AltaIncentivoForm
    ''            'AltaIncentivo.IDNave = cmbNave.SelectedValue
    ''            'AltaIncentivo.IdColaborador = grdFiltroSolicitudes.Rows(e.RowIndex).Cells("IDEmpleado").Value
    ''            'AltaIncentivo.IDSolicitud = grdFiltroSolicitudes.Rows(e.RowIndex).Cells("ID_SolicitudIncentivo").Value
    ''            'AltaIncentivo.ShowDialog()
    ''            'grdFiltroSolicitudes.Rows.Clear()
    ''            'llenartabla()
    ''            'Pintartabla()



    ''            'If grdFiltroSolicitudes.Rows.Count > 0 Then
    ''            '    grdFiltroSolicitudes.Rows.Add("", "", "Total", "", SumaTotal.ToString("N0"), "", Date.MinValue.ToShortDateString, Date.MinValue.ToShortDateString, "", "", "", "")
    ''            '    grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1).Cells("Fecha_Solicitud").Style.ForeColor = Color.GreenYellow
    ''            '    grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1).Cells("Fecha_Autorizacion").Style.ForeColor = Color.GreenYellow
    ''            '    grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1).DefaultCellStyle.BackColor = Color.GreenYellow
    ''            'End If

    ''            Try

    ''                If cboxPeriodo.SelectedValue >= 0 Then
    ''                    Dim BuscarFechas As New IncentivosBU
    ''                    Try
    ''                        FechaInicial = BuscarFechas.BuscarFechaInicialPerdiodo(cboxPeriodo.SelectedValue)
    ''                        FechaFinal = BuscarFechas.BuscarFechaFinalPerdiodo(cboxPeriodo.SelectedValue)
    ''                    Catch ex As Exception

    ''                    End Try

    ''                End If


    ''            Catch ex As Exception

    ''            End Try

    ''        End If
    ''        '     End If
    ''    End If
    ''End Sub


    Private Sub dtpSegundaFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambiofecha = 1
        llenartabla()
    End Sub

    Private Sub cmbNave_DropDownClosed(sender As Object, e As EventArgs) Handles cmbNave.DropDownClosed
        llenarComboCajas()
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
        Try
            If cmbNave.SelectedIndex > 0 Then
                cboxPeriodo = Controles.ComboPeriodoSegunNaveIncentivos(cboxPeriodo, cmbNave.SelectedValue)
                'cboxPeriodo.SelectedIndex = 0
            Else
                cboxPeriodo.SelectedIndex = 0
            End If
            If cboxPeriodo.SelectedIndex >= 0 Then
                Dim BuscarFechas As New IncentivosBU
                Try
                    FechaInicial = BuscarFechas.BuscarFechaInicialPerdiodo(cboxPeriodo.SelectedValue)
                    FechaFinal = BuscarFechas.BuscarFechaFinalPerdiodo(cboxPeriodo.SelectedValue)
                Catch ex As Exception

                End Try

            End If

            If cmbNave.SelectedValue > 0 Then
                Naves = cmbNave.SelectedValue
                'grdFiltroSolicitudes.Rows.Clear()
                'llenartabla()
                'Pintartabla()
            Else
                Naves = 0
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub lblEncabezado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        gpbFiltroIncentivos.Height = 45
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        gpbFiltroIncentivos.Height = 117 '127
    End Sub

    Private Sub cboxPeriodo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxPeriodo.SelectedIndexChanged
        If cboxPeriodo.SelectedIndex >= 0 Then
            Dim BuscarFechas As New IncentivosBU
            Try
                FechaInicial = BuscarFechas.BuscarFechaInicialPerdiodo(cboxPeriodo.SelectedValue)
                FechaFinal = BuscarFechas.BuscarFechaFinalPerdiodo(cboxPeriodo.SelectedValue)
            Catch ex As Exception

            End Try

        End If




    End Sub


    Private Sub gpbFiltroIncentivos_Enter(sender As Object, e As EventArgs) Handles gpbFiltroIncentivos.Enter

    End Sub

    Private Sub btnLimpiarSolicitudes_Click_1(sender As Object, e As EventArgs) Handles btnLimpiarSolicitudes.Click
        Dim dt As New DateTime
        Dim fecha As String
        fecha = dt.ToString
        txtBuscarNombreIncentivo.Text = ""
        Estatus = ""
        cmbNave.SelectedIndex = 0
        cboxPeriodo.SelectedIndex = 0
        cmbStatus.Text = ""
        cambiofecha = 0
        grdSolicitudes.DataSource = Nothing
    End Sub

    Private Sub lblLimpiar_Click(sender As Object, e As EventArgs) Handles lblLimpiar.Click

    End Sub

    Private Sub lblBuscar_Click(sender As Object, e As EventArgs) Handles lblBuscar.Click

    End Sub

    Private Sub btnFiltrarSolicitud_Click_1(sender As Object, e As EventArgs) Handles btnFiltrarSolicitud.Click

        SumaTotal = 0
        ''grdFiltroSolicitudes.Rows.Clear()
        If cmbNave.SelectedIndex > 0 Then
            If cboxPeriodo.SelectedIndex > 0 Then
                llenartabla()
            Else
                Dim objMensaje As New Tools.AdvertenciaForm
                objMensaje.mensaje = "Seleccione un periodo."
                objMensaje.ShowDialog()
            End If
        Else
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "Seleccione una nave."
            objMensaje.ShowDialog()
        End If
        ''Pintartabla()
        ''If grdFiltroSolicitudes.Rows.Count > 0 Then
        ''    grdFiltroSolicitudes.Rows.Add("", "", "Total", "", SumaTotal.ToString("N0"), "", Date.MinValue.ToShortDateString, Date.MinValue.ToShortDateString, "", "", "", "")
        ''    grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1).Cells("Fecha_Solicitud").Style.ForeColor = Color.GreenYellow
        ''    grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1).Cells("Fecha_Autorizacion").Style.ForeColor = Color.GreenYellow
        ''    grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1).DefaultCellStyle.BackColor = Color.GreenYellow
        ''End If
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

    Private Sub pnColores_Paint(sender As Object, e As PaintEventArgs) Handles pnColores.Paint

    End Sub


    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

        Dim Gratificaciones = New DataTable("Gratificaciones")
        With Gratificaciones
            .Columns.Add("Consecutivo")
            .Columns.Add("NombreColaborador")
            .Columns.Add("Departamento")
            .Columns.Add("Concepto")
            .Columns.Add("Cantidad")
        End With

        'For Each row As DataGridViewRow In grdFiltroSolicitudes.Rows
        '    Dim cantidad As String = row.Cells("Monto").Value
        '    cantidad = cantidad.Replace("$", "")
        '    If row.Cells("Nombre").Value = "Total" Then
        '        row.Cells("Nombre").Value = ""
        '        row.Cells("Motivo").Value = "Total"
        '    End If

        '    Gratificaciones.Rows.Add(row.Cells("Consecutivo").Value, row.Cells("Nombre").Value, row.Cells("Departamento").Value, row.Cells("Motivo").Value, cantidad)
        'Next


        Dim cont As Int32 = 1
        Dim totalRp As Double = 0
        For Each row As UltraGridRow In grdSolicitudes.Rows.GetAllNonGroupByRows
            Dim cantidad As String = row.Cells("TOTAL").Value
            cantidad = cantidad.Replace("$", "")
            Gratificaciones.Rows.Add(cont, row.Cells("Nombre").Value, row.Cells("DEPARTAMENTO").Value, row.Cells("MotUno").Value, CDbl(cantidad).ToString("N2").Replace(",", ""))
            If cantidad <> "" Then
                totalRp = totalRp + CDbl(cantidad)
            End If
            cont += 1
        Next
        'Gratificaciones.Rows.Add(cont + 1, "TOTAL", "", "", totalRp.ToString("N2"))

        Me.Cursor = Cursors.WaitCursor
        Dim OBJBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        EntidadReporte = OBJBU.LeerReporteporClave("NOM_REP_GRATF")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            EntidadReporte.Pnombre + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()

        reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
        reporte("nombreNave") = cmbNave.Text
        reporte("NombreReporte") = "SAY: CONFGRATIFICACIONES.mrt"
        reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
        reporte("FechaPeriodoNomina") = cboxPeriodo.Text

        reporte.RegData(Gratificaciones)
        reporte.Show()
        Me.Cursor = Cursors.Default



    End Sub


    Private Sub grdFiltroSolicitudes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub grdSolicitudes_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grdSolicitudes.DoubleClickRow
        If e.Row.IsFilterRow = False Then
            Dim colaboradorid As String = ""
            Dim solicitudid As String = ""
            Dim estatus As String = ""
            Dim estatusAutorizado As New IncentivosBU
            Dim tablaConfiguracion As DataTable
            colaboradorid = e.Row.Cells("codr_colaboradorid").Value
            solicitudid = e.Row.Cells("soin_solicitudincentivoid").Value
            If Not IsNothing(solicitudid) Then
                estatus = estatusAutorizado.validarEstatusAutorizado(colaboradorid, solicitudid)
                tablaConfiguracion = estatusAutorizado.validarConfiguracion(cmbNave.SelectedValue)

                Dim autorizaGerente As Boolean = False
                Dim autorizaDirector As Boolean = False
                Dim montoNuevo As Double = 0

                SumaTotal = 0

                Dim AltaIncentivo As New AltaIncentivoForm
                With AltaIncentivo
                    .IDNave = cmbNave.SelectedValue
                    .IdColaborador = e.Row.Cells("codr_colaboradorid").Value
                    .IDSolicitud = e.Row.Cells("soin_solicitudincentivoid").Value
                    .idCelula = e.Row.Cells("celu_celulaid").Value.ToString
                    .celula = e.Row.Cells("CELULA").Value.ToString
                    .estatusGratificacion = estatus
                    .estatus = e.Row.Cells("soin_estado").Value.ToString
                    .ShowDialog()
                    montoNuevo = .montoNuevo
                End With
                llenartabla()
                ''grdFiltroSolicitudes.Rows(e.RowIndex).Cells("Monto").Value = montoNuevo.ToString("N2")
                ''If grdFiltroSolicitudes.Rows.Count > 0 Then
                ''    SumaTotal = 0
                ''    grdFiltroSolicitudes.Rows.Remove(grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1))

                ''    For Each row As DataGridViewRow In grdFiltroSolicitudes.Rows
                ''        SumaTotal += row.Cells("Monto").Value
                ''    Next
                ''    grdFiltroSolicitudes.Rows.Add("", "", "Total", "", SumaTotal.ToString("N2"), "", Date.MinValue, Date.MinValue, "", "", "", "")
                ''    grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1).Cells("Fecha_Solicitud").Style.ForeColor = Color.GreenYellow
                ''    grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1).Cells("Fecha_Autorizacion").Style.ForeColor = Color.GreenYellow
                ''    grdFiltroSolicitudes.Rows(grdFiltroSolicitudes.Rows.Count - 1).DefaultCellStyle.BackColor = Color.GreenYellow
                ''End If
                ''Try
                ''    If cboxPeriodo.SelectedValue >= 0 Then
                ''        Dim BuscarFechas As New IncentivosBU
                ''        Try
                ''            FechaInicial = BuscarFechas.BuscarFechaInicialPerdiodo(cboxPeriodo.SelectedValue)
                ''            FechaFinal = BuscarFechas.BuscarFechaFinalPerdiodo(cboxPeriodo.SelectedValue)
                ''        Catch ex As Exception

                ''        End Try

                ''    End If
                ''Catch ex As Exception

                ''End Try

            End If
        End If
    End Sub

    Private Sub grdSolicitudes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdSolicitudes.InitializeLayout
        Dim valueList As ValueList = e.Layout.FilterOperatorsValueList
        Dim item As ValueListItem
        For Each item In valueList.ValueListItems
            Dim filterOperator As FilterComparisionOperator = DirectCast(item.DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Contains = filterOperator Then
                item.DisplayText = "CONTIENE"
            ElseIf FilterComparisionOperator.DoesNotEndWith = filterOperator Then
                item.DisplayText = "NO TERMINA CON"
            ElseIf FilterComparisionOperator.DoesNotStartWith = filterOperator Then
                item.DisplayText = "NO COMIENZA CON"
            ElseIf FilterComparisionOperator.EndsWith = filterOperator Then
                item.DisplayText = "TERMINA CON"
            ElseIf FilterComparisionOperator.Equals = filterOperator Then
                item.DisplayText = "IGUAL"
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                item.DisplayText = "MAYOR QUE"
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                item.DisplayText = "MAYOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                item.DisplayText = "MENOR QUE"
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                item.DisplayText = "MENOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.NotEquals = filterOperator Then
                item.DisplayText = "DIFERENTE A"
            ElseIf FilterComparisionOperator.StartsWith = filterOperator Then
                item.DisplayText = "COMIENZA CON"
            End If
        Next

        Dim cont As Integer
        For cont = valueList.ValueListItems.Count - 1 To 0 Step -1
            Dim filterOperator As FilterComparisionOperator = DirectCast(valueList.ValueListItems.Item(cont).DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Custom = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotContain = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotMatch = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Like = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Match = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.NotLike = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            End If
        Next

    End Sub

    Private Sub grdSolicitudes_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdSolicitudes.InitializeRow
        If grdSolicitudes.Rows.Count > 0 Then
            If e.Row.Cells("soin_estado").Value = "A" Then
                e.Row.Cells("Color").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFBB8")
                e.Row.Cells("Seleccion").Activation = Activation.AllowEdit
            ElseIf e.Row.Cells("soin_estado").Value = "B" Then
                e.Row.Cells("Color").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#96CF3A")
                e.Row.Cells("Seleccion").Activation = Activation.NoEdit
            ElseIf e.Row.Cells("soin_estado").Value = "C" Then
                e.Row.Cells("Color").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#BAEBFF")
                e.Row.Cells("Seleccion").Activation = Activation.NoEdit
            ElseIf e.Row.Cells("soin_estado").Value = "D" Then
                e.Row.Cells("Color").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF96")
                e.Row.Cells("Seleccion").Activation = Activation.NoEdit
            ElseIf e.Row.Cells("soin_estado").Value = "E" Then
                e.Row.Cells("Color").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#C5C5C5")
                e.Row.Cells("Seleccion").Activation = Activation.NoEdit
            ElseIf e.Row.Cells("soin_estado").Value = "F" Then
                e.Row.Cells("Color").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#088A85")
                e.Row.Cells("Seleccion").Activation = Activation.NoEdit
            ElseIf e.Row.Cells("soin_estado").Value = "P" Then
                e.Row.Cells("Color").Appearance.BackColor = Color.LightSkyBlue
                e.Row.Cells("Seleccion").Activation = Activation.NoEdit
            End If
            If e.Row.Cells.Exists("Configuracion") Then
                If e.Row.Cells("soin_justificación").Value <> "NO SE CAPTURO DESCRIPCION" Then
                    e.Row.Cells("Configuracion").Appearance.ImageBackground = Global.Nomina.Vista.My.Resources.cobservacion
                Else
                    e.Row.Cells("Configuracion").Value = ""
                End If
            End If
            If e.Row.Cells.Exists("Configuracion") Then
                If CBool(e.Row.Cells("moin_diaadicional").Value) = True Then
                    e.Row.Cells("Configuracion").Appearance.ImageBackground = Global.Nomina.Vista.My.Resources.diafestivocalendario
                Else
                    e.Row.Cells("Configuracion").Value = ""
                End If
            End If
        End If

    End Sub

    Private Sub btnAutorizar_Click_1(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        Dim objMensaje As New Tools.ConfirmarForm
        objMensaje.mensaje = "¿Esta seguro que quiere autorizar las gratificaciones?"
        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
            AutorizarSolicitudes()
        End If
    End Sub

    Private Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
        Dim objMensaje As New Tools.ConfirmarForm
        objMensaje.mensaje = "¿Esta seguro que quiere rechazar las gratificaciones?"
        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
            RechazarSolicitudes()
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        If Not grdSolicitudes.DataSource Is Nothing Then
            For Each rowGR As UltraGridRow In grdSolicitudes.Rows.GetFilteredInNonGroupByRows
                If rowGR.Cells("soin_estado").Value = "A" Then
                    rowGR.Cells("seleccion").Value = CBool(chkSeleccionarTodo.Checked)
                End If
            Next
        End If
    End Sub


    Private Sub btnSolicitar_Click(sender As Object, e As EventArgs) Handles btnSolicitar.Click
        Dim montoTotalCajaChica As Double = 0
        For Each rowGR As UltraGridRow In grdSolicitudes.Rows
            If rowGR.Cells("soin_estado").Value = "B" And CBool(rowGR.Cells("moin_diaadicional").Value) = False Then
                montoTotalCajaChica += CDbl(rowGR.Cells("Total").Value)
            End If
        Next

        Dim objMensaje As New Tools.ConfirmarForm
        objMensaje.mensaje = "Se realizara una solicitud por $" + montoTotalCajaChica.ToString("N2") + " a finanzas. ¿Desea continuar?"
        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
            solicitarCajaChica()
        End If
    End Sub

    Private Sub btnDiaAdicional_Click(sender As Object, e As EventArgs) Handles btnDiaAdicional.Click
        Dim objDiaAdicional As New AltaDiaAdicionalForm
        objDiaAdicional.ShowDialog()
        llenartabla()
    End Sub

End Class