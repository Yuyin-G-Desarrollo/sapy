Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Nomina.Negocios
Imports Tools

Public Class AltaDiaAdicionalForm

    Public Sub GuardarSolicitudes()
        Me.Cursor = Cursors.WaitCursor
        Dim objIncentivosBU As New IncentivosBU
        Dim totalMontoSolicitado As Double = 0
        'Dim Dialogo As New DialogSeleccionarFormaDePagoForm
        Dim datosCorrectos As Boolean = True
        Dim FormadePago As String = String.Empty
        Dim guardo As Boolean = False
        Dim contSolicitudesAceptadas As Int32 = 0

        Dim enviarCorreo As Boolean = False
        Dim total As Double = 0.0
        Dim listaIncentivos As New List(Of Entidades.SolicitudIncentivos)

        ' '' ''Dialogo.cmbFormaPago.SelectedIndex = 1
        ' '' ''If Dialogo.ShowDialog = DialogResult.OK Then
        ' '' ''    IDCajas = Dialogo.idCaja
        ' '' ''    FormadePago = Dialogo.formaPago
        ' '' ''    If FormadePago.Length = 0 Then
        ' '' ''        datosCorrectos = False
        ' '' ''    End If
        ' '' ''If datosCorrectos = True Then
        ' '' ''    Dim ObjCajas As New Negocios.CajasBU
        ' '' ''    Dim objBUFiniquito As New Negocios.FiniquitosBU
        ' '' ''    Dim SumaSolicitud As Double = 0
        ' '' ''    Dim IDSolicitud As Int32
        ' '' ''    For Each rowGR As UltraGridRow In grdColaboradores.Rows
        ' '' ''        If rowGR.Cells("Seleccion").Value = True Then
        ' '' ''            SumaSolicitud += rowGR.Cells("DiaAdicional").Value
        ' '' ''        End If
        ' '' ''    Next
        ' '' ''    IDSolicitud = ObjCajas.EnviarSolicitudesCajaGratificaciones(IDCajas, FormadePago, SumaSolicitud, "Gratificaciones", "SOLICITUD DE EFECTIVO PARA PAGO DE GRATIFICACIONES")
        Dim contIncConc As Int32 = 0
        Dim guardarCambio As Boolean = True

        For Each grdRow As UltraGridRow In grdColaboradores.Rows
            If grdRow.Cells("Seleccion").Value = True And CDbl(grdRow.Cells("DiaAdicional").Value) > 0 Then
                contIncConc = objIncentivosBU.validarDiaAdicionalColaborador(cmbConcepto.SelectedValue, grdRow.Cells("ID").Value.ToString, cboxPeriodo.SelectedValue)

                If contIncConc > 0 Then
                    Dim objMensaje As New Tools.ConfirmarForm
                    objMensaje.mensaje = "El usuario ya tiene un registro anterior del mismo periodo y con el mismo concepto. ¿Desea guardar de todos modos?"
                    If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                        guardarCambio = True
                    Else
                        guardarCambio = False
                    End If
                Else
                    guardarCambio = True
                End If

                If guardarCambio = True Then
                    Dim IncentivosGrat As New Entidades.SolicitudIncentivos
                    Dim motivo As New Entidades.Incentivos
                    Dim entCol As New Entidades.Colaborador
                    Dim entIncent As New Entidades.Incentivos
                    Dim entDepa As New Entidades.Departamentos

                    IncentivosGrat.PColaboradorID = grdRow.Cells("ID").Value.ToString
                    motivo.IIncentivoId = cmbConcepto.SelectedValue
                    IncentivosGrat.PMotivoID = motivo
                    IncentivosGrat.PMontoGratificacion1 = grdRow.Cells("DiaAdicional").Value
                    IncentivosGrat.PDescripcion = "NO SE CAPTURO DESCRIPCION"
                    total = grdRow.Cells("DiaAdicional").Value

                    entCol.PNombre = grdRow.Cells("NOMBRE").Value
                    entIncent.INombre = cmbConcepto.Text
                    entDepa.DNombre = grdRow.Cells("DEPARTAMENTO").Value

                    IncentivosGrat.PNombreColaborador = entCol
                    IncentivosGrat.PDepartamento = entDepa
                    IncentivosGrat.PFechaSolicitud = Date.Now
                    IncentivosGrat.PNombreIncentivo = entIncent

                    IncentivosGrat.PMonto = total
                    objIncentivosBU.EnviarSolicitudDiaAdicional(IncentivosGrat, cmbNave.SelectedValue, cboxPeriodo.SelectedValue)
                    listaIncentivos.Add(IncentivosGrat)
                    enviarCorreo = True
                    guardo = True
                End If

            End If
        Next
        If enviarCorreo = True Then
            enviar_correo(cmbNave.SelectedValue, listaIncentivos, "ENVIO_NOTIFICACION_GRATIFICACION")
        End If

        If guardo = True Then
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Registro exitoso."
            FormaExito.ShowDialog()
            llenarTablaColaboradores()
        Else
            Dim FormaaDV As New AdvertenciaForm
            FormaaDV.mensaje = "No se registro."
            FormaaDV.ShowDialog()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Public Function validaMontoMaximo() As Boolean
        Dim itemConcepto As Object = cmbConcepto.SelectedItem
        Dim cantidadMax As Double = itemConcepto("moin_montomax")

        If cantidadMax > 0 Then
            For Each grdRow As UltraGridRow In grdColaboradores.Rows
                If grdRow.Cells("Seleccion").Value = True Then
                    If grdRow.Cells("DiaAdicional").Value > cantidadMax Then
                        Return False
                    End If
                End If
            Next
        End If

        Return True
    End Function

    Private Sub enviar_correo(ByVal naveID As Integer, ByVal Solicitudes As List(Of Entidades.SolicitudIncentivos), ByVal clave As String)
        Dim SumaTotal As New Double
        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String
        Dim correo As New Tools.Correo
        destinatarios = enviosCorreoBU.consulta_destinatarios_email(naveID, clave)
        Dim Email As String = "<html>" +
                                "<head>" +
                                  "<style type ='" + "text/css" + "'> body {display: block; margin: 8px; background: #FFFFFF;}#header{	position: fixed;	height: 62px;	top: 0;	left: 0;	right: 0;	color: #003366;	font-family: Arial, Helvetica, sans-serif;	font-size: 18px;	font-weight: bold;}#leftcolumn{	float: left;	position: fixed;	width: 2%;	margin: 1%;	padding-top: 3%;	top: 0;	left: 0;	right: 0;}#content{	width: 90%;	position: fixed;	margin: 1% 5%;		padding-top: 3%;	padding-bottom: 1%;}#rightcolumn{	float: right;	width: 5%;	margin: 1%;			padding-top: 3%;}#footer{	position: fixed;	width: 100%;	heigt: 5%;	bottom: 0;	margin: 0;	padding: 0;	color: #FFFFFF;}table.tableizer-table { 	font-family: Arial, Helvetica, sans-serif;	font-size: 9px;} .tableizer-table td {	padding: 4px;	margin: 0px;	border: 1px solid #FFFFFF;	border-color: #FFFFFF;	border: 1px solid #CCCCCC;	width: 200px;} .tableizer-table tr {	padding: 4px;	margin: 0;	color: #003366;	font-weight: bold;	background-color: #transparent; 	opacity: 1;}.tableizer-table th {	background-color: #003366; 	color: #FFFFFF;	font-weight: bold;	height: 30px;	font-size: 10px;}A:link {	text-decoration:none;color:#FFFFFF;} A:visited {	text-decoration:none;color:#FFFFFF;} A:active {	text-decoration:none;color:#FFFFFF;} A:hover {	text-decoration:none;color:#006699;} </style>" +
                                  "</head>" +
                                  "<body>" +
                                   "<div id='" + "wrapper" + "'>" +
                                    "<div id='" + "header" + "'>" +
                                    "<img src='" + "http://www.grupoyuyin.com.mx/GRUPO_YUYIN.jpg" + "'style='" + "vertical-align:middle" + "' height='" + "57" + "' widht='" + "125" + "'> Solicitud de Gratificaciones <br>  <font size=2>Usuario que Solicito : " + Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString + "</font>" +
                                   " </div> <br></br>" +
                                    "<div id='" + "leftcolumn" + "'>" +
                                    "</div>" +
                                    "<div id='" + "rightcolumn" + "'>" +
                                    "</div>" + "<div id='" + "content" + "'>" +
                                      "<table id='" + "mi_tabla" + "' class='" + "tableizer-table" + "'>" +
                                       "<thead>" +
                                        "<tr class='" + "tableizer-firstrow" + "'>" +
                                        "<th width ='" + "20%" + "'>Nombre</th>" +
                                        "<th width ='" + "15%" + "'>Departamento</th>" +
                                        "<th width ='" + "7%" + "'>Fecha de Solicitud</th>" +
                                        "<th width ='" + "13%" + "'>Motivo</th>" +
                                        "<th width ='" + "7%" + "'>Cantidad</th>" +
                                       "</thead>" +
                                       "<tbody>"

        For Each solicitud As Entidades.SolicitudIncentivos In Solicitudes
            Email +=
                                        "<tr>" +
                                            "<td>" + solicitud.PNombreColaborador.PNombre.ToString + "</td>" +
                                            "<td>" + solicitud.PDepartamento.DNombre + "</td>" +
                                            "<td>" + solicitud.PFechaSolicitud.ToShortDateString + "</td>" +
                                            "<td>" + solicitud.PNombreIncentivo.INombre.ToString + "</td>" +
                                            "<td>" + solicitud.PMonto.ToString("C") + "</td>"

            SumaTotal += solicitud.PMonto
        Next
        Email += " " +
                   "</tr>" + "<tr> <td></td> <td></td> <td></td>  <td> Total : </td> <td>" + SumaTotal.ToString("C") + "</td> </tr>" +
                "</tbody>" +
                "</table>" +
                       "</div>" +
                       "<div id='" + "footer" + "'>" +
                       "</div>" +
                   "</div>" +
                "</body>" +
                "</html>"
        correo.EnviarCorreoHtml(destinatarios, "say_nomina@grupoyuyin.com.mx", "Solicitud de Gratificacion", Email)
        'correo.EnviarCorreoHtml("gdesarrollo.ti@grupoyuyin.com.mx", "say_nomina@grupoyuyin.com.mx", "Solicitud de Gratificacion", Email)
    End Sub

    Public Sub llenarTablaColaboradores()
        grdColaboradores.DataSource = Nothing
        Dim objColBU As New Negocios.ColaboradoresBU
        Dim dtDatosColaboradores As New DataTable
        Dim idDep As Int32 = 0
        Dim idPuesto As Int32 = 0
        Dim idCelula As Int32 = 0
        If cmbDepartamento.SelectedIndex > 0 Then
            idDep = cmbDepartamento.SelectedValue
        End If
        If cmbPuesto.SelectedIndex > 0 Then
            idPuesto = cmbPuesto.SelectedValue
        End If
        If cmbCelula.SelectedIndex > 0 Then
            idCelula = cmbCelula.SelectedValue
        End If
        If CBool(chkVerHorasCheco.Checked) = True Then
            Dim objMensajeAviso As New Tools.AvisoForm
            objMensajeAviso.mensaje = "La consulta puede tardar un poco mas de lo esperado."
            objMensajeAviso.ShowDialog()
        End If

        Me.Cursor = Cursors.WaitCursor
        dtDatosColaboradores = objColBU.ListaEmpleadosDiaAdicional(cmbNave.SelectedValue, cboxPeriodo.SelectedValue,
                                                                     txtBuscarNombreIncentivo.Text, idDep, idPuesto,
                                                                     idCelula, dttDia.Value.ToShortDateString,
                                                                     CBool(chkVerHorasCheco.Checked))

        If dtDatosColaboradores.Rows.Count > 0 Then
            grdColaboradores.DataSource = dtDatosColaboradores
            calcularDiaExtra()
            FormatoTabla()
            Me.Cursor = Cursors.Default
        Else
            Me.Cursor = Cursors.Default
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "La consulta no devolvió resultados."
            objMensaje.ShowDialog()
        End If

    End Sub

    Public Sub FormatoTabla()

        With grdColaboradores.DisplayLayout.Bands(0)

            .Columns("ID").Hidden = True
            .Columns("IDLABORAL").Hidden = True
            .Columns("SIINCENTIVOS").Hidden = True
            .Columns("IDNAVE").Hidden = True
            .Columns("IDDEPARTAMENTO").Hidden = True
            .Columns("IDCELULA").Hidden = True
            .Columns("IDPUESTO").Hidden = True
            .Columns("TipoSalario").Hidden = True
            .Columns("antiguedad").Hidden = True
            .Columns("NACIMIENTO").Hidden = True

            .Columns("NOMBRE").Header.Caption = "Colaborador"
            .Columns("NAVE").Header.Caption = "Nave"
            .Columns("DEPARTAMENTO").Header.Caption = "Departamento"
            .Columns("CELULA").Header.Caption = "Célula"
            .Columns("PUESTO").Header.Caption = "Puesto"
            .Columns("Salario").Header.Caption = "Salario"
            .Columns("DiaAdicional").Header.Caption = "Extra"
            .Columns("Seleccion").Header.Caption = ""

            .Columns("NACIMIENTO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NOMBRE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NAVE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("DEPARTAMENTO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("CELULA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("PUESTO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("Salario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("DiaAdicional").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("Salario").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("DiaAdicional").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("Seleccion").Style = ColumnStyle.CheckBox
            .Columns("DiaAdicional").MaskInput = "nnnn.nn"
            .Columns("Salario").MaskInput = "nnnn.nn"

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        ''grdSolicitudes.DisplayLayout.Bands(0).Columns.Add("Configuracion", "Configuracion")
        ''Dim colConfiguracion As UltraGridColumn = grdSolicitudes.DisplayLayout.Bands(0).Columns("Configuracion")
        ''colConfiguracion.Header.Caption = ""
        ''colConfiguracion.Style = ColumnStyle.Image

        Dim sumTotal As SummarySettings = grdColaboradores.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdColaboradores.DisplayLayout.Bands(0).Columns("DiaAdicional"))
        sumTotal.DisplayFormat = "{0:#,##0.00}"
        sumTotal.Appearance.TextHAlign = HAlign.Right
        sumTotal.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

        grdColaboradores.DisplayLayout.Bands(0).SummaryFooterCaption = "Total"

        grdColaboradores.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdColaboradores.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdColaboradores.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdColaboradores.DisplayLayout.Override.RowSelectorWidth = 35
        grdColaboradores.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdColaboradores.Rows(0).Selected = True
    End Sub

    Public Sub calcularDiaExtra()
        Dim salarioDia As Double = 0
        For Each rowGr As UltraGridRow In grdColaboradores.Rows
            salarioDia = 0
            If rdoDiaCompleto.Checked = True Then
                rowGr.Cells("DiaAdicional").Value = (rowGr.Cells("Salario").Value) / 7
            ElseIf rdoMedioDia.Checked = True Then
                rowGr.Cells("DiaAdicional").Value = ((rowGr.Cells("Salario").Value) / 7) / 2
            ElseIf rdoSoloIncremento.Checked = True Then
                rowGr.Cells("DiaAdicional").Value = "0"
            End If

            If rdoDiaCompleto.Checked = True Or rdoMedioDia.Checked = True Then
                If txtIncremento.Value > 0 Then
                    rowGr.Cells("DiaAdicional").Value = rowGr.Cells("DiaAdicional").Value + (rowGr.Cells("DiaAdicional").Value * (txtIncremento.Value / 100))
                End If
            ElseIf rdoSoloIncremento.Checked = True Then
                If txtIncremento.Value > 0 Then
                    If rowGr.Cells("Salario").Value > 0 Then
                        salarioDia = ((rowGr.Cells("Salario").Value) / 7)
                        rowGr.Cells("DiaAdicional").Value = (salarioDia * (txtIncremento.Value / 100))
                    Else
                        rowGr.Cells("DiaAdicional").Value = "0"
                    End If
                End If
            End If
        Next
    End Sub

    Public Sub limpiar()
        cmbNave.SelectedIndex = 0
        grdColaboradores.DataSource = Nothing
    End Sub

    Private Sub btnSubir_Click(sender As Object, e As EventArgs) Handles btnSubir.Click
        gpbFiltroIncentivos.Height = 40
    End Sub

    Private Sub btnBajar_Click(sender As Object, e As EventArgs) Handles btnBajar.Click
        gpbFiltroIncentivos.Height = 149
    End Sub

    Private Sub AltaDiaAdicionalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        cboxPeriodo.DataSource = Nothing
        cmbDepartamento.DataSource = Nothing
        grdColaboradores.DataSource = Nothing

        If cmbNave.SelectedIndex > 0 Then
            Dim objInBU As New Negocios.IncentivosBU
            Dim dtConceptos As New DataTable
            lblMaximo.Text = ""
            dtConceptos = objInBU.verIncentivosDiasAdicional(cmbNave.SelectedValue)
            dtConceptos.Rows.InsertAt(dtConceptos.NewRow, 0)
            If dtConceptos.Rows.Count > 0 Then
                cmbConcepto.DataSource = dtConceptos
                cmbConcepto.DisplayMember = "moin_nombre"
                cmbConcepto.ValueMember = "moin_motivoincentivoid"
            End If
            cboxPeriodo = Controles.ComboPeriodoSegunNaveIncentivos(cboxPeriodo, cmbNave.SelectedValue)
            cboxPeriodo.SelectedIndex = 0
            cmbDepartamento = Controles.ComboDepatamentoSegunNave(cmbDepartamento, cmbNave.SelectedValue)
            cmbDepartamento.SelectedIndex = 0
        Else
            cmbConcepto.DataSource = Nothing
        End If
        'End If
    End Sub

    Private Sub btnFiltrarSolicitud_Click(sender As Object, e As EventArgs) Handles btnFiltrarSolicitud.Click
        If cmbNave.SelectedIndex > 0 Then
            If cboxPeriodo.SelectedIndex > 0 Then
                llenarTablaColaboradores()
            Else
                Dim objAdv As New Tools.AdvertenciaForm
                objAdv.mensaje = "Seleccione una periodo"
                objAdv.ShowDialog()
            End If
        Else
            Dim objAdv As New Tools.AdvertenciaForm
            objAdv.mensaje = "Seleccione una nave"
            objAdv.ShowDialog()
        End If
    End Sub

    Private Sub cmbDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartamento.SelectedIndexChanged
        cmbPuesto.DataSource = Nothing
        cmbCelula.DataSource = Nothing
        If cmbDepartamento.SelectedIndex > 0 Then
            cmbPuesto = Controles.ComboPuestosSegunDepartamento(cmbPuesto, cmbDepartamento.SelectedValue)
            cmbCelula = Controles.ComboCelulasSegunDepartamento(cmbCelula, cmbDepartamento.SelectedValue)
        End If
    End Sub

    Private Sub cboxPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxPeriodo.SelectedIndexChanged
        grdColaboradores.DataSource = Nothing
    End Sub

    'Private Sub rdoDiaCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles rdoDiaCompleto.CheckedChanged
    '    calcularDiaExtra()
    'End Sub

    'Private Sub rdoMedioDia_CheckedChanged(sender As Object, e As EventArgs) Handles rdoMedioDia.CheckedChanged
    '    'calcularDiaExtra()
    'End Sub

    Private Sub txtIncremento_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIncremento.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    calcularDiaExtra()
        'End If
    End Sub

    Private Sub txtIncremento_ValueChanged(sender As Object, e As EventArgs) Handles txtIncremento.ValueChanged
        calcularDiaExtra()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If cmbConcepto.SelectedIndex > 0 Then
            If validaMontoMaximo() = True Then
                ' ''Dim montoTotalCajaChica As Double = 0
                ' ''For Each rowGR As UltraGridRow In grdColaboradores.Rows
                ' ''    If rowGR.Cells("Seleccion").Value = True Then
                ' ''        montoTotalCajaChica += CDbl(rowGR.Cells("DiaAdicional").Value)
                ' ''    End If
                ' ''Next
                Dim objMensaje As New Tools.ConfirmarForm
                objMensaje.mensaje = "¿Esta seguro de guardar los cambios?"
                If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                    GuardarSolicitudes()
                End If

            Else
                Dim objMensajeAdv As New Tools.AdvertenciaForm
                objMensajeAdv.mensaje = "La cantidad maxima para el concepto es superada por algunos registros."
                objMensajeAdv.ShowDialog()
            End If
        Else
            Dim objMensajeAdv As New Tools.AdvertenciaForm
            objMensajeAdv.mensaje = "Seleccione un concepto."
            objMensajeAdv.ShowDialog()
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiarSolicitudes_Click(sender As Object, e As EventArgs) Handles btnLimpiarSolicitudes.Click

    End Sub

    Private Sub cmbConcepto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbConcepto.SelectedIndexChanged
        If cmbConcepto.SelectedIndex > 0 Then
            Dim itemConcepto As Object = cmbConcepto.SelectedItem
            Dim cantidadMax As Double = itemConcepto("moin_montomax")
            If cantidadMax > 0 Then
                lblMaximo.Text = "Max: $" + cantidadMax.ToString("N0")
            Else
                lblMaximo.Text = ""
            End If
        End If
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        If Not grdColaboradores.DataSource Is Nothing Then
            For Each rowGR As UltraGridRow In grdColaboradores.Rows.GetFilteredInNonGroupByRows
                rowGR.Cells("seleccion").Value = CBool(chkSeleccionarTodo.Checked)
            Next
        End If
    End Sub

    Private Sub txtBuscarNombreIncentivo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarNombreIncentivo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If cmbNave.SelectedIndex > 0 Then
                If cboxPeriodo.SelectedIndex > 0 Then
                    llenarTablaColaboradores()
                Else
                    Dim objAdv As New Tools.AdvertenciaForm
                    objAdv.mensaje = "Seleccione una periodo"
                    objAdv.ShowDialog()
                End If
            Else
                Dim objAdv As New Tools.AdvertenciaForm
                objAdv.mensaje = "Seleccione una nave"
                objAdv.ShowDialog()
            End If
        End If
    End Sub

    Private Sub txtBuscarNombreIncentivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscarNombreIncentivo.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtBuscarNombreIncentivo.Text.Length < 200) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or caracter = ChrW(Keys.Space) Or (caracter = "/") Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = (".")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtBuscarNombreIncentivo.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub grdColaboradores_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdColaboradores.AfterCellUpdate
        'If e.Cell.Column.ToString = "Salario" Then

        'End If
    End Sub

    Private Sub grdColaboradores_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdColaboradores.BeforeCellUpdate
        'If e.Cell.Column.ToString = "Salario" Then
        '    If IsNumeric(e.Cell.Text) = True Then

        '    Else
        '        e.Cancel = True
        '    End If
        'End If
    End Sub


    Private Sub grdColaboradores_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColaboradores.InitializeLayout
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

    Private Sub rdoSoloIncremento_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSoloIncremento.CheckedChanged
        If cmbNave.SelectedIndex > 0 And cboxPeriodo.SelectedIndex > 0 Then
            llenarTablaColaboradores()
        End If

        activarPorcentaje()
    End Sub

    Private Sub rdoDiaCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles rdoDiaCompleto.CheckedChanged
        If cmbNave.SelectedIndex > 0 And cboxPeriodo.SelectedIndex > 0 Then
            llenarTablaColaboradores()
        End If

        activarPorcentaje()
    End Sub

    Private Sub rdoMedioDia_CheckedChanged(sender As Object, e As EventArgs) Handles rdoMedioDia.CheckedChanged
        If cmbNave.SelectedIndex > 0 And cboxPeriodo.SelectedIndex > 0 Then
            llenarTablaColaboradores()
        End If

        activarPorcentaje()
    End Sub

    Private Sub activarPorcentaje()
        If rdoSoloIncremento.Checked = False Then
            txtIncremento.Enabled = False
            txtIncremento.Value = 0
        Else
            txtIncremento.Enabled = True
        End If
    End Sub
End Class