Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports Nomina.Negocios
Imports Stimulsoft.Report

Public Class ListaSolicitudFiniquitosORForm
    Dim cambiofecha As Int32 = 0
    Dim Columna As New Int32
    Dim Estatus As String
    Dim EstatusInicial As String = ""
    Dim dtReporte As DataTable
    Dim checa As Boolean
    Dim verReporteLiquidacionCompleto As Boolean = False



    Public Sub llenarComboPeriodos()
        Dim objPeriBU As New Negocios.ControlDePeriodoBU
        Dim dtPeriodos As New DataTable
        dtPeriodos = objPeriBU.buscarPeriodoSegunNavesSegunAsistenciaAnio(cmbNave.SelectedValue)
        cmbPeriodo.DataSource = dtPeriodos
        dtPeriodos.Rows.InsertAt(dtPeriodos.NewRow, 0)
        cmbPeriodo.DisplayMember = "pnom_Concepto"
        cmbPeriodo.ValueMember = "pnom_PeriodoNomId"
    End Sub

    Public Sub llenarComboCajas()
        Dim objCajas As New CajasBU
        Dim dtCajas As New DataTable
        dtCajas = objCajas.listaCajas(CInt(cmbNave.SelectedValue))
        cmbCajas.DataSource = Nothing
        If dtCajas.Rows.Count > 0 Then
            cmbCajas.DataSource = dtCajas
            cmbCajas.DisplayMember = "Nombre"
            cmbCajas.ValueMember = "Id_Caja"
            cmbCajas.SelectedIndex = 0
            lblAlertaSinCaja.Visible = False
            cmbCajas.Visible = True
        Else
            cmbCajas.Visible = False
            lblAlertaSinCaja.Visible = True
        End If
    End Sub

    Public Sub llenarTablaSolicitudes()
        grdSolicitudes.DataSource = Nothing
        dtReporte = New DataTable

        If cmbStatus.Text = "" Then
            Estatus = ""
        ElseIf cmbStatus.Text = "TODOS" Then
            Estatus = ""
        ElseIf cmbStatus.Text = "Autorizado".ToUpper Then
            Estatus = "B"
            EstatusInicial = ""
        ElseIf cmbStatus.Text = "DINERO ENTREGADO A NAVE".ToUpper Then
            Estatus = "F"
            EstatusInicial = ""
        ElseIf cmbStatus.Text = "DINERO ENTREGADO AL COLABORADOR".ToUpper Then
            Estatus = "G"
            EstatusInicial = ""
        ElseIf cmbStatus.Text = "Solicitado a caja chica".ToUpper Then
            Estatus = "E"
            EstatusInicial = ""
        ElseIf cmbStatus.Text = "Solicitado".ToUpper Then
            Estatus = "A"
            EstatusInicial = ""
        ElseIf cmbStatus.Text = "Rechazados".ToUpper Then
            Estatus = "C"
            EstatusInicial = ""
        ElseIf cmbStatus.Text = "DINERO ENTREGADO A DIRECCIÓN".ToUpper Then
            Estatus = "H"
            EstatusInicial = ""


        ElseIf cmbStatus.Text = "NO ENTREGADA".ToUpper Then
            Estatus = "N"
            EstatusInicial = ""
        End If


        Dim Naveid As Int32 = 0
        If cmbNave.SelectedIndex > 0 Then
            Naveid = cmbNave.SelectedValue
        Else
            Naveid = 0
        End If
        Dim dtSolicitudes As New DataTable
        Dim objBU As New Negocios.FiniquitosBU
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim inicioFechaFiltro As String = ""
        Dim finFechaFiltro As String = ""

        If rdoPeriodo.Checked = True Then
            Try
                Dim itemsCombo As Object
                itemsCombo = cmbPeriodo.SelectedItem
                inicioFechaFiltro = itemsCombo("pnom_FechaInicial")
                finFechaFiltro = itemsCombo("pnom_FechaFinal")
            Catch ex As Exception
                Dim forma As New AdvertenciaForm
                forma.mensaje = "Seleccione un periodo valido"
                forma.ShowDialog()
                inicioFechaFiltro = ""
                finFechaFiltro = ""
            End Try
        Else
            inicioFechaFiltro = CDate(dttInicio.Value).ToShortDateString()
            finFechaFiltro = CDate(dttFin.Value).ToShortDateString()
        End If

        dtSolicitudes = objBU.SolicitudesFiniquitosSegunNaveConsulta("", Estatus, Naveid, CBool(chkXFechas.Checked), CBool(rdoFechaBaja.Checked), inicioFechaFiltro, finFechaFiltro)
        dtReporte = dtSolicitudes
        If dtSolicitudes.Rows.Count > 0 Then
            grdSolicitudes.DataSource = dtSolicitudes
            formatoGrid()
        Else
            Dim forma As New AdvertenciaForm
            forma.mensaje = "La consulta no devolvió resultados"
            forma.ShowDialog()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub


    Public Sub formatoGrid()
        With grdSolicitudes.DisplayLayout.Bands(0)
            .Columns("labo_naveid").Hidden = True
            .Columns("codr_colaboradorid").Hidden = True
            .Columns("labo_departamentoid").Hidden = True
            .Columns("labo_puestoid").Hidden = True
            .Columns("fini_motivofiniquitoid").Hidden = True
            .Columns("fini_sueldosemana1").Hidden = True
            .Columns("fini_sueldosemana2").Hidden = True
            .Columns("fini_sueldosemana3").Hidden = True
            .Columns("fini_sueldosemana4").Hidden = True
            .Columns("fini_justificacion").Hidden = True

            .Columns("fini_salariosemanal").Hidden = True
            .Columns("fini_salariodiario").Hidden = True
            .Columns("fini_mesesaguinaldo").Hidden = True
            .Columns("fini_diasaguinaldo").Hidden = True
            .Columns("fini_mesesvacaciones").Hidden = True
            .Columns("fini_diasvacaciones").Hidden = True
            .Columns("fini_subtotal").Hidden = True
            .Columns("fini_fechaautorizacion").Hidden = True
            .Columns("fini_fechaautorizacion").Hidden = True
            .Columns("grup_name").Hidden = True
            .Columns("pues_nombre").Hidden = True
            .Columns("real_fecha").Hidden = True
            .Columns("fini_finiquitoid").Hidden = True
            .Columns("fini_estado").Hidden = True
            .Columns("real_tiposueldo").Hidden = True
            .Columns("fini_norecontratar").Hidden = True
            .Columns("fini_antiguedaddias").Hidden = True
            .Columns("fini_fechasolicitud").Hidden = True
            .Columns("fini_utilidades").Hidden = True
            .Columns("fini_anioutilidadesanterior").Hidden = True
            .Columns("fini_anioutilidades").Hidden = True
            '  .Columns("fini_extras").Hidden = True

            .Columns("Seleccion").Header.Caption = ""
            .Columns("fini_consecutivonave").Header.Caption = "No. Baja"
            .Columns("Colaborador").Header.Caption = "Colaborador"
            .Columns("grup_name").Header.Caption = "Departamento"
            .Columns("pues_nombre").Header.Caption = "Puesto"
            .Columns("real_fecha").Header.Caption = "Ingreso"
            .Columns("fini_justificacion").Header.Caption = "Justificacion"
            .Columns("fini_antiguedadanios").Header.Caption = "Años"
            .Columns("fini_antiguedadmeses").Header.Caption = "Meses"
            .Columns("fini_antiguedaddias").Header.Caption = "Días"
            .Columns("fini_totalaguinaldo").Header.Caption = "Aguinaldo"
            .Columns("fini_totalvacaciones").Header.Caption = "Vacaciones"
            .Columns("fini_primavacacional").Header.Caption = "Prima V."
            .Columns("fini_totalfiniquito").Header.Caption = "Finiquito"
            .Columns("fini_ahorro").Header.Caption = "Ahorro"
            .Columns("fini_prestamo").Header.Caption = "Préstamo"
            .Columns("fini_utilidadesactual").Header.Caption = "Utilidades Periodo Actual"
            .Columns("fini_utilidadesanterior").Header.Caption = "Utilidades Periodo Anterior"
            .Columns("fini_gratificacion").Header.Caption = "Gratificación"
            .Columns("fini_totalentregar").Header.Caption = "Total"
            .Columns("fini_fechasolicitud").Header.Caption = "Solicitado"
            .Columns("fini_fechabaja").Header.Caption = "Baja"
            .Columns("estDsn").Header.Caption = ""
            .Columns("fini_fechaentregado").Header.Caption = "Entrega"
            .Columns("SemanaEntrega").Header.Caption = "Semana" & vbCrLf & "Entrega"
            .Columns("SemanaBaja").Header.Caption = "Semana" & vbCrLf & "Baja"

            .Columns("fini_extras").Header.Caption = "Extras"



            .Columns("Colaborador").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("grup_name").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("pues_nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("real_fecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fini_justificacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fini_antiguedadanios").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fini_antiguedadmeses").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fini_antiguedaddias").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fini_totalaguinaldo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fini_totalvacaciones").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fini_primavacacional").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fini_totalfiniquito").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fini_ahorro").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fini_prestamo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fini_utilidadesactual").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fini_utilidadesanterior").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fini_gratificacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fini_totalentregar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fini_fechasolicitud").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fini_fechabaja").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("estDsn").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fini_fechaentregado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("SemanaEntrega").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("SemanaBaja").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fini_extras").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("fini_antiguedadanios").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("fini_antiguedadmeses").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("fini_antiguedaddias").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("fini_totalaguinaldo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("fini_totalvacaciones").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("fini_primavacacional").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("fini_totalfiniquito").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("fini_ahorro").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("fini_prestamo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("fini_utilidadesactual").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("fini_utilidadesanterior").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("fini_gratificacion").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("fini_totalentregar").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("SemanaEntrega").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("SemanaBaja").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("fini_extras").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("fini_antiguedaddias").Format = "###,###,##0.00"
            .Columns("fini_totalaguinaldo").Format = "###,###,##0.00"
            .Columns("fini_totalvacaciones").Format = "###,###,##0.00"
            .Columns("fini_primavacacional").Format = "###,###,##0.00"
            .Columns("fini_totalfiniquito").Format = "###,###,##0.00"
            .Columns("fini_ahorro").Format = "###,###,##0.00"
            .Columns("fini_prestamo").Format = "###,###,##0.00"
            .Columns("fini_utilidadesactual").Format = "###,###,##0.00"
            .Columns("fini_utilidadesanterior").Format = "###,###,##0.00"
            .Columns("fini_gratificacion").Format = "###,###,##0.00"
            .Columns("fini_totalentregar").Format = "###,###,##0.00"
            .Columns("fini_extras").Format = "###,###,##0.00"
            .Columns("Seleccion").Style = ColumnStyle.CheckBox

            .Columns("Seleccion").AllowRowFiltering = DefaultableBoolean.False
            .Columns("estDsn").AllowRowFiltering = DefaultableBoolean.False

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

            ''pau inicio
            Dim vAdvertenciaForm As New AdvertenciaForm
            Try

                'Dim finiquito1 As SummarySettings = grdSolicitudes.DisplayLayout.Bands(0).Summaries.Add("TOTAL", SummaryType.Sum,  grdSolicitudes.DisplayLayout.Bands(0).Columns("finiquito1"))
                Dim aguinaldo As SummarySettings = grdSolicitudes.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudes.DisplayLayout.Bands(0).Columns("fini_totalaguinaldo"))
                Dim vacaciones As SummarySettings = grdSolicitudes.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudes.DisplayLayout.Bands(0).Columns("fini_totalvacaciones"))
                Dim primaV As SummarySettings = grdSolicitudes.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudes.DisplayLayout.Bands(0).Columns("fini_primavacacional"))
                Dim finiquito As SummarySettings = grdSolicitudes.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudes.DisplayLayout.Bands(0).Columns("fini_totalfiniquito"))
                Dim gratificacion As SummarySettings = grdSolicitudes.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudes.DisplayLayout.Bands(0).Columns("fini_gratificacion"))
                Dim utilidadesactual As SummarySettings = grdSolicitudes.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudes.DisplayLayout.Bands(0).Columns("fini_utilidadesactual"))
                Dim utilidadesanterior As SummarySettings = grdSolicitudes.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudes.DisplayLayout.Bands(0).Columns("fini_utilidadesanterior"))
                Dim ahorro As SummarySettings = grdSolicitudes.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudes.DisplayLayout.Bands(0).Columns("fini_ahorro"))
                Dim prestamo As SummarySettings = grdSolicitudes.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudes.DisplayLayout.Bands(0).Columns("fini_prestamo"))
                Dim extras As SummarySettings = grdSolicitudes.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudes.DisplayLayout.Bands(0).Columns("fini_extras"))
                Dim total As SummarySettings = grdSolicitudes.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudes.DisplayLayout.Bands(0).Columns("fini_totalentregar"))


                aguinaldo.DisplayFormat = "{0:#,##0}"
                aguinaldo.Appearance.TextHAlign = HAlign.Right
                vacaciones.DisplayFormat = "{0:#,##0}"
                vacaciones.Appearance.TextHAlign = HAlign.Right
                primaV.DisplayFormat = "{0:#,##0}"
                primaV.Appearance.TextHAlign = HAlign.Right
                finiquito.DisplayFormat = "{0:#,##0}"
                finiquito.Appearance.TextHAlign = HAlign.Right
                gratificacion.DisplayFormat = "{0:#,##0}"
                gratificacion.Appearance.TextHAlign = HAlign.Right
                ahorro.DisplayFormat = "{0:#,##0}"
                ahorro.Appearance.TextHAlign = HAlign.Right
                prestamo.DisplayFormat = "{0:#,##0}"
                prestamo.Appearance.TextHAlign = HAlign.Right
                utilidadesactual.DisplayFormat = "{0:#,##0}"
                utilidadesactual.Appearance.TextHAlign = HAlign.Right
                utilidadesanterior.DisplayFormat = "{0:#,##0}"
                utilidadesanterior.Appearance.TextHAlign = HAlign.Right
                extras.DisplayFormat = "{0:#,##0}"
                extras.Appearance.TextHAlign = HAlign.Right
                total.DisplayFormat = "{0:#,##0}"
                total.Appearance.TextHAlign = HAlign.Right


                grdSolicitudes.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
            Catch ex As Exception
                vAdvertenciaForm.Text = "Liquidacion"
                vAdvertenciaForm.mensaje = "Ocurrio un error" & ex.Message
                vAdvertenciaForm.Show()
            End Try
            ''pau fin

        End With

        'Dim sumuno As SummarySettings = grdSolicitudes.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudes.DisplayLayout.Bands(0).Columns("montouno"))
        'Dim sumdos As SummarySettings = grdSolicitudes.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudes.DisplayLayout.Bands(0).Columns("montodos"))
        'Dim sumtres As SummarySettings = grdSolicitudes.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudes.DisplayLayout.Bands(0).Columns("montotres"))
        'Dim sumTotal As SummarySettings = grdSolicitudes.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudes.DisplayLayout.Bands(0).Columns("TOTAL"))

        'sumuno.DisplayFormat = "{0:#,##0.00}"
        'sumuno.Appearance.TextHAlign = HAlign.Right
        'sumdos.DisplayFormat = "{0:#,##0.00}"
        'sumdos.Appearance.TextHAlign = HAlign.Right
        'sumtres.DisplayFormat = "{0:#,##0.00}"
        'sumtres.Appearance.TextHAlign = HAlign.Right
        'sumTotal.DisplayFormat = "{0:#,##0.00}"
        'sumTotal.Appearance.TextHAlign = HAlign.Right
        'sumTotal.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

        grdSolicitudes.DisplayLayout.Bands(0).SummaryFooterCaption = "Total"
        grdSolicitudes.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdSolicitudes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdSolicitudes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdSolicitudes.DisplayLayout.Override.RowSelectorWidth = 35
        grdSolicitudes.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdSolicitudes.Rows(0).Selected = True

        grdSolicitudes.DisplayLayout.Bands(0).Columns("estDsn").Width = 20
        grdSolicitudes.DisplayLayout.Bands(0).Columns("Seleccion").Width = 20
        grdSolicitudes.DisplayLayout.Bands(0).Columns("SemanaEntrega").Width = 50
        grdSolicitudes.DisplayLayout.Bands(0).Columns("SemanaBaja").Width = 50

        grdSolicitudes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Public Sub AutorizarSolicitudes()
        Dim objSolicitudBaja As New Contabilidad.Negocios.SolicitudBajaBU
        Me.Cursor = Cursors.WaitCursor
        Dim objBUFiniquito As New Negocios.FiniquitosBU
        Dim CountAcept As Int32 = 0
        For Each row As UltraGridRow In grdSolicitudes.Rows
            If CBool(row.Cells("Seleccion").Value) = True And row.Cells("fini_estado").Value = "A" Then
                objBUFiniquito.AceptarSolicitud(row.Cells("fini_finiquitoid").Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                CountAcept += 1
                objSolicitudBaja.SolicitudAceptada(row.Cells("fini_finiquitoid").Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            End If
        Next
        If CountAcept = 1 Then
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Finiquito autorizado correctamente"
            FormaExito.ShowDialog()
        ElseIf CountAcept > 1 Then
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Finiquitos autorizados correctamente"
            FormaExito.ShowDialog()
        Else
            Dim FormaExito As New AdvertenciaForm
            FormaExito.mensaje = "No ha seleccionado ninguna solicitud"
            FormaExito.ShowDialog()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub entregarColaborador()
        Me.Cursor = Cursors.WaitCursor
        Dim objBUFiniquito As New Negocios.FiniquitosBU
        Dim CountAcept As Int32 = 0

        Dim objFechaEntrega As New frmSeleccionarFechaEntrega

        For Each row As UltraGridRow In grdSolicitudes.Rows
            If CBool(row.Cells("Seleccion").Value) = True And row.Cells("fini_estado").Value = "F" Then
                objFechaEntrega = New frmSeleccionarFechaEntrega
                objFechaEntrega.fechaSoliditud = row.Cells("fini_fechasolicitud").Value.ToString
                objFechaEntrega.colaborador = row.Cells("Colaborador").Value.ToString
                objFechaEntrega.ShowDialog()
                If objFechaEntrega.fechaEntrega <> "" Then
                    objBUFiniquito.EntregoFiniquito(row.Cells("fini_finiquitoid").Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, objFechaEntrega.fechaEntrega)
                    CountAcept += 1
                End If
            End If
        Next
        If CountAcept = 1 Then
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Se cambio el estatus a entregado y se generó la Salida de Caja chica en SICY"
            FormaExito.ShowDialog()
        ElseIf CountAcept > 1 Then
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Se cambio el estatus a entregado"
            FormaExito.ShowDialog()
        Else
            Dim FormaExito As New AdvertenciaForm
            FormaExito.mensaje = "No ha seleccionado ninguna solicitud"
            FormaExito.ShowDialog()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub RechazarSolicitudes()
        Dim objSolicitudBaja As New Contabilidad.Negocios.SolicitudBajaBU
        Dim objBUFiniquito As New Negocios.FiniquitosBU
        Dim CountAcept As Int32 = 0
        For Each row As UltraGridRow In grdSolicitudes.Rows
            If CBool(row.Cells("Seleccion").Value) = True And row.Cells("fini_estado").Value = "A" Then
                objBUFiniquito.RechazarSolicitud(row.Cells("fini_finiquitoid").Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                CountAcept += 1
                objSolicitudBaja.SolicitudCancelada(row.Cells("fini_finiquitoid").Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            End If
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

    Public Sub solicitarCajaChica()
        Dim datosCorrectos As Boolean = True
        Dim FormadePago As String = String.Empty

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
            If datosCorrectos = True Then
                If FormadePago = "CHEQUE" Then
                    Dim ObjCajas As New Negocios.CajasBU
                    Dim objBUFiniquito As New Negocios.FiniquitosBU
                    Dim IDSolicitud As DataTable
                    Dim CountAcept As Int32 = 0
                    For Each row As UltraGridRow In grdSolicitudes.Rows
                        If CBool(row.Cells("Seleccion").Value) = True And (row.Cells("fini_estado").Value = "B" Or row.Cells("fini_estado").Value = "D") Then
                            IDSolicitud = ObjCajas.EnviarSolicitudesCaja(IDCajas, FormadePago, row.Cells("fini_totalentregar").Value, CStr(row.Cells("Colaborador").Value), "SOLICITUD DE CHEQUE PARA PAGO DE FINIQUITO")
                            objBUFiniquito.PagarSolicitudFiniquito(row.Cells("fini_finiquitoid").Value, CInt(IDSolicitud.Rows(0).Item(0)))
                            CountAcept += 1
                        End If
                    Next

                    ''For Each row As UltraGridRow In grdSolicitudes.Rows
                    ''    If CBool(row.Cells("Seleccion").Value) = True And row.Cells("fini_estado").Value = "A" Then
                    ''        objBUFiniquito.AceptarSolicitud(row.Cells("fini_finiquitoid").Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                    ''        CountAcept += 1
                    ''    End If
                    ''Next
                    llenarTablaSolicitudes()
                Else
                    Dim ObjCajas As New Negocios.CajasBU
                    Dim objBUFiniquito As New Negocios.FiniquitosBU
                    Dim CountAcept As Int32 = 0
                    Dim Suma As Double = 0
                    Dim IDSolicitud As DataTable
                    For Each row As UltraGridRow In grdSolicitudes.Rows
                        If CBool(row.Cells("Seleccion").Value) = True And (row.Cells("fini_estado").Value = "B" Or row.Cells("fini_estado").Value = "D") Then
                            objBUFiniquito.PagarSolicitudFiniquito(row.Cells("fini_finiquitoid").Value, 0)
                            Suma += CDbl(row.Cells("fini_totalentregar").Value)
                            CountAcept += 1
                        End If
                    Next
                    ''CountAcept = CountAcept - 1 
                    IDSolicitud = ObjCajas.EnviarSolicitudesCaja(IDCajas, FormadePago, Suma, "VARIOS FINIQUITOS", "SOLICITUD DE EFECTIVO PARA PAGO DE " + CountAcept.ToString + " FINIQUITOS")
                    For Each row As UltraGridRow In grdSolicitudes.Rows
                        If CBool(row.Cells("Seleccion").Value) = True And (row.Cells("fini_estado").Value = "B" Or row.Cells("fini_estado").Value = "D") Then
                            objBUFiniquito.PagarSolicitudFiniquito(row.Cells("fini_finiquitoid").Value, CInt(IDSolicitud.Rows(0).Item(0).ToString))
                            CountAcept += 1
                        End If
                    Next
                    grdSolicitudes.DataSource = Nothing
                End If
                Dim exito As New ExitoForm
                exito.mensaje = "Solicitud Enviada Correctamente"
                exito.ShowDialog()
                llenarTablaSolicitudes()
            End If
        Else
            Dim FormaExito As New Tools.AdvertenciaForm
            FormaExito.mensaje = "Se cancelo la transacción, el usuario no tiene relacion con una caja."
            FormaExito.ShowDialog()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub entregarDireccion()
        Me.Cursor = Cursors.WaitCursor
        Dim objBUFiniquito As New Negocios.FiniquitosBU
        Dim CountAcept As Int32 = 0

        Dim objFechaEntrega As New frmSeleccionarFechaEntrega

        For Each row As UltraGridRow In grdSolicitudes.Rows
            If CBool(row.Cells("Seleccion").Value) = True And row.Cells("fini_estado").Value = "F" Then
                objFechaEntrega = New frmSeleccionarFechaEntrega
                objFechaEntrega.fechaSoliditud = row.Cells("fini_fechasolicitud").Value.ToString
                objFechaEntrega.colaborador = row.Cells("Colaborador").Value.ToString
                objFechaEntrega.ShowDialog()
                If objFechaEntrega.fechaEntrega <> "" Then
                    objBUFiniquito.EntregarFiniquitoDireccion(row.Cells("fini_finiquitoid").Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, objFechaEntrega.fechaEntrega)
                    CountAcept += 1
                End If
            End If
        Next
        If CountAcept = 1 Then
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Se cambió el estatus a entregado dirección y se genero la salida de Caja Chica de SICY."
            FormaExito.ShowDialog()

        ElseIf CountAcept > 1 Then
            Dim FormaExito As New ExitoForm
            FormaExito.mensaje = "Se cambió el estatus a entregado dirección y se genero la salida de Caja Chica de SICY."
            FormaExito.ShowDialog()
        Else
            Dim FormaExito As New AdvertenciaForm
            FormaExito.mensaje = "No ha seleccionado ninguna solicitud"
            FormaExito.ShowDialog()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    ' ''Public Sub AgregarFila(ByVal ListaFiniquitos As Entidades.Finiquitos)
    ' ''    Dim celda As DataGridViewCell
    ' ''    Dim fila As New DataGridViewRow
    ' ''    celda = New DataGridViewCheckBoxCell
    ' ''    celda.Value = True
    ' ''    fila.Cells.Add(celda)
    ' ''    If ListaFiniquitos.PEstado = "A" Then
    ' ''        celda.Value = CheckState.Unchecked
    ' ''        celda.ReadOnly = False
    ' ''    Else
    ' ''        celda.Value = CheckState.Unchecked

    ' ''        celda.ReadOnly = True
    ' ''    End If
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    celda.Value = ListaFiniquitos.PColaboradorId.PNombre & " " & ListaFiniquitos.PColaboradorId.PApaterno & " " & ListaFiniquitos.PColaboradorId.PAmaterno
    ' ''    fila.Cells.Add(celda)
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    celda.Value = ListaFiniquitos.PAntiguedadAnios.ToString
    ' ''    fila.Cells.Add(celda)
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    'celda.Value = FormatNumber((ListaFiniquitos.PAntiguedadMeses + ((ListaFiniquitos.PAntiguedadDias / 30.4))), 2)
    ' ''    celda.Value = FormatNumber((ListaFiniquitos.PAntiguedadMeses + ((ListaFiniquitos.PAntiguedadDias / 30.4))), 0)
    ' ''    fila.Cells.Add(celda)
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    celda.Value = ListaFiniquitos.PTotalAguinaldo
    ' ''    fila.Cells.Add(celda)
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    celda.Value = ListaFiniquitos.PTotalVacaciones
    ' ''    fila.Cells.Add(celda)
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    celda.Value = ListaFiniquitos.PTotalFiniquito
    ' ''    fila.Cells.Add(celda)
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    celda.Value = ListaFiniquitos.PAhorro
    ' ''    fila.Cells.Add(celda)
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    celda.Value = ListaFiniquitos.PPrestamo
    ' ''    fila.Cells.Add(celda)
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    celda.Value = ListaFiniquitos.PUtilidades
    ' ''    fila.Cells.Add(celda)
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    celda.Value = ListaFiniquitos.PGratificacion
    ' ''    fila.Cells.Add(celda)
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    celda.Value = ListaFiniquitos.PSueldoDiasTrabajados
    ' ''    fila.Cells.Add(celda)
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    celda.Value = ListaFiniquitos.PTotalEntregar
    ' ''    fila.Cells.Add(celda)
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    celda.Value = ListaFiniquitos.PEstado
    ' ''    fila.Cells.Add(celda)
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    If (ListaFiniquitos.PFechaSolicitud.ToShortDateString = CDate("01/01/0001")) Then
    ' ''        celda.Value = " "
    ' ''    Else
    ' ''        celda.Value = ListaFiniquitos.PFechaSolicitud.ToShortDateString
    ' ''    End If
    ' ''    fila.Cells.Add(celda)
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    If (ListaFiniquitos.PFechaBaja.ToShortDateString = CDate("01/01/0001")) Then
    ' ''        celda.Value = " "
    ' ''    Else
    ' ''        celda.Value = ListaFiniquitos.PFechaBaja.ToShortDateString
    ' ''    End If
    ' ''    fila.Cells.Add(celda)
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    If (ListaFiniquitos.PFechaAutorizacion.ToShortDateString = CDate("01/01/0001")) Then
    ' ''        celda.Value = " "
    ' ''    Else
    ' ''        celda.Value = ListaFiniquitos.PFechaAutorizacion.ToShortDateString
    ' ''    End If
    ' ''    fila.Cells.Add(celda)
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    celda.Value = ListaFiniquitos.PUsuarioCreoId
    ' ''    fila.Cells.Add(celda)
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    celda.Value = ListaFiniquitos.PVoBo
    ' ''    fila.Cells.Add(celda)
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    If (ListaFiniquitos.PVoBoFecha.ToShortDateString = CDate("01/01/0001")) Then
    ' ''        celda.Value = " "
    ' ''    Else
    ' ''        celda.Value = ListaFiniquitos.PVoBoFecha.ToShortDateString
    ' ''    End If
    ' ''    fila.Cells.Add(celda)
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    celda.Value = ListaFiniquitos.PFiniquito
    ' ''    fila.Cells.Add(celda)
    ' ''    celda = New DataGridViewTextBoxCell
    ' ''    celda.Value = ListaFiniquitos.PColaboradorId.PColaboradorid
    ' ''    fila.Cells.Add(celda)
    ' ''    grdFiltroSolicitudes.Rows.Add(fila)
    ' ''End Sub

    ' ''Public Sub llenartabla()
    ' ''    If cmbStatus.Text = "" Then
    ' ''    ElseIf cmbStatus.Text = "Autorizado Gerente".ToUpper Then
    ' ''        Estatus = "B"
    ' ''        EstatusInicial = ""
    ' ''    ElseIf cmbStatus.Text = "Autorizado Director".ToUpper Then
    ' ''        Estatus = "D"
    ' ''        EstatusInicial = ""
    ' ''    ElseIf cmbStatus.Text = "Recibidos de caja chica".ToUpper Then
    ' ''        Estatus = "F"
    ' ''        EstatusInicial = ""
    ' ''    ElseIf cmbStatus.Text = "Entregados al colaborador".ToUpper Then
    ' ''        Estatus = "G"
    ' ''        EstatusInicial = ""
    ' ''    ElseIf cmbStatus.Text = "Solicitado a caja chica".ToUpper Then
    ' ''        Estatus = "E"
    ' ''        EstatusInicial = ""
    ' ''    ElseIf cmbStatus.Text = "Solicitado".ToUpper Then
    ' ''        Estatus = "A"
    ' ''        EstatusInicial = ""
    ' ''    ElseIf cmbStatus.Text = "Rechazados".ToUpper Then
    ' ''        Estatus = "C"
    ' ''        EstatusInicial = ""
    ' ''    Else
    ' ''    End If
    ' ''    Dim secondDate As String
    ' ''    Dim confecha As String
    ' ''    If cambiofecha = 1 Then
    ' ''    Else
    ' ''        confecha = ""
    ' ''        secondDate = ""
    ' ''    End If
    ' ''    Dim Naveid As Int32 = 0
    ' ''    If cmbNave.SelectedIndex >= 0 Then
    ' ''        Naveid = cmbNave.SelectedValue
    ' ''    End If
    ' ''    Dim listaSolicitudes As New List(Of Entidades.Finiquitos)
    ' ''    Dim objBU As New Negocios.FiniquitosBU
    ' ''    listaSolicitudes = objBU.ListaFiniquitosSegunUsuario("", confecha, secondDate, Estatus, Naveid)
    ' ''    For Each objeto As Entidades.Finiquitos In listaSolicitudes
    ' ''        AgregarFila(objeto)
    ' ''    Next
    ' ''    grdFiltroSolicitudes.ScrollBars = System.Windows.Forms.ScrollBars.None
    ' ''    grdFiltroSolicitudes.ScrollBars = System.Windows.Forms.ScrollBars.Both
    ' ''End Sub

    Private Sub btnLimpiarSolicitudes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dt As New DateTime
        Dim fecha As String
        fecha = dt.ToString

        Estatus = ""
        cmbStatus.Text = ""
        cambiofecha = 0
        ''grdFiltroSolicitudes.Rows.Clear()
        ''llenartabla()
        ''Pintartabla()
    End Sub

    ' ''Public Sub Pintartabla()
    ' ''    Dim hasta As New Int32
    ' ''    hasta = grdFiltroSolicitudes.Rows.Count - 1
    ' ''    For i = 0 To hasta
    ' ''        If grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "A" Then ' Solicitado
    ' ''            grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFBB8")
    ' ''        ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "B" Then ' Autorizado Gerente
    ' ''            grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#96CF3A")
    ' ''        ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "C" Then ' Rechazado
    ' ''            grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#BAEBFF")
    ' ''        ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "D" Then ' Autorizado Director
    ' ''            grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF96")
    ' ''        ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "E" Then ' solocitado a Cajca Chica
    ' ''            grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#C5C5C5")
    ' ''        ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "F" Then ' Entregado
    ' ''            grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#618DEE")
    ' ''        ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "G" Then ' Entregado
    ' ''            grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#C5C5C5")
    ' ''        End If
    ' ''    Next
    ' ''End Sub

    Private Sub btnArriba_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        gpbFiltroIncentivos.Height = 41
    End Sub

    Private Sub btnAbajo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        gpbFiltroIncentivos.Height = 85
    End Sub

    Private Sub ListaSolicitudFiniquitosORForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  llenarComboCajas()
        'Me.Panel3.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFBB8")
        'Me.Panel4.BackColor = System.Drawing.ColorTranslator.FromHtml("#BAEBFF")
        'Me.Panel5.BackColor = System.Drawing.ColorTranslator.FromHtml("#96CF3A")
        ''Me.Panel6.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF96")
        'Me.Panel8.BackColor = System.Drawing.ColorTranslator.FromHtml("#618DEE")
        'Me.Panel9.BackColor = System.Drawing.ColorTranslator.FromHtml("#C5C5C5")

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_LIST_FINI", "NOM_NUEVO_FINIQUITO") Then
            pnlNuevoFiniquito.Visible = True
        Else
            pnlNuevoFiniquito.Visible = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_LIST_FINI", "NOM_AUTORIZAR_FINIQUITO") Then
            pnlAutorizar.Visible = True
            lblInstruccionPanelesEstado.Visible = True
        Else
            pnlAutorizar.Visible = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_LIST_FINI", "NOM_SOLICITAR_FINIQUITO_CJ") Then
            pnlSolicitar.Visible = True
            lblInstruccionPanelesEstado.Visible = True
        Else
            pnlSolicitar.Visible = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_LIST_FINI", "NOM_ENTREGAR_FINIQUITO") Then
            pnlEntregar.Visible = True
            lblInstruccionPanelesEstado.Visible = True
        Else
            pnlEntregar.Visible = False
        End If

        WindowState = FormWindowState.Maximized
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNave.SelectedIndex > 0 Then
            llenarComboCajas()
        End If

        ' ''grdFiltroSolicitudes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        ' ''grdFiltroSolicitudes.Columns.Add("Autorizar", "") '0
        ' ''grdFiltroSolicitudes.Columns("Autorizar").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        ' ''grdFiltroSolicitudes.Columns("Autorizar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        ' ''grdFiltroSolicitudes.Columns.Add("Nombre", "Colaborador") '1
        ' ''grdFiltroSolicitudes.Columns("Nombre").ReadOnly = True
        ' ''grdFiltroSolicitudes.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ' ''grdFiltroSolicitudes.Columns.Add("Años", "Años") '2
        ' ''grdFiltroSolicitudes.Columns("Años").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        ' ''grdFiltroSolicitudes.Columns("Años").ReadOnly = True
        ' ''grdFiltroSolicitudes.Columns("Años").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' ''grdFiltroSolicitudes.Columns.Add("Meses", "Meses") '2
        ' ''grdFiltroSolicitudes.Columns("Meses").DefaultCellStyle.Format = "##,##00"
        ' ''grdFiltroSolicitudes.Columns("Meses").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' ''grdFiltroSolicitudes.Columns("Meses").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        ' ''grdFiltroSolicitudes.Columns.Add("Aguinaldo", "Aguinaldo") '3
        ' ''grdFiltroSolicitudes.Columns("Aguinaldo").DefaultCellStyle.Format = "##,##00"
        ' ''grdFiltroSolicitudes.Columns("Aguinaldo").ReadOnly = True
        ' ''grdFiltroSolicitudes.Columns("Aguinaldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' ''grdFiltroSolicitudes.Columns("Aguinaldo").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        ' ''grdFiltroSolicitudes.Columns.Add("Vacaciones", "Vacaciones") '4
        ' ''grdFiltroSolicitudes.Columns("Vacaciones").ReadOnly = True
        ' ''grdFiltroSolicitudes.Columns("Vacaciones").DefaultCellStyle.Format = "##,##00"
        ' ''grdFiltroSolicitudes.Columns("Vacaciones").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' ''grdFiltroSolicitudes.Columns("Vacaciones").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        ' ''grdFiltroSolicitudes.Columns.Add("Finiquito", "Finiquito") '5
        ' ''grdFiltroSolicitudes.Columns("Finiquito").DefaultCellStyle.Format = "##,##00"
        ' ''grdFiltroSolicitudes.Columns("Finiquito").ReadOnly = True
        ' ''grdFiltroSolicitudes.Columns("Finiquito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' ''grdFiltroSolicitudes.Columns("Finiquito").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        ' ''grdFiltroSolicitudes.Columns.Add("Ahorro", "Ahorro") '6
        ' ''grdFiltroSolicitudes.Columns("Ahorro").ReadOnly = True
        ' ''grdFiltroSolicitudes.Columns("Ahorro").DefaultCellStyle.Format = "##,##00"
        ' ''grdFiltroSolicitudes.Columns("Ahorro").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' ''grdFiltroSolicitudes.Columns("Ahorro").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        ' ''grdFiltroSolicitudes.Columns.Add("Prestamo", "Préstamo") '7
        ' ''grdFiltroSolicitudes.Columns("Prestamo").ReadOnly = True
        ' ''grdFiltroSolicitudes.Columns("Prestamo").DefaultCellStyle.Format = "##,##00"
        ' ''grdFiltroSolicitudes.Columns("Prestamo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' ''grdFiltroSolicitudes.Columns("Prestamo").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        ' ''grdFiltroSolicitudes.Columns.Add("Utilidades", "Utilidades") '8
        ' ''grdFiltroSolicitudes.Columns("Utilidades").DefaultCellStyle.Format = "##,##00"
        ' ''grdFiltroSolicitudes.Columns("Utilidades").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' ''grdFiltroSolicitudes.Columns("Utilidades").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        ' ''grdFiltroSolicitudes.Columns.Add("Gratificacion", "Gratificación") '9
        ' ''grdFiltroSolicitudes.Columns("Gratificacion").ReadOnly = True
        ' ''grdFiltroSolicitudes.Columns("Gratificacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' ''grdFiltroSolicitudes.Columns("Gratificacion").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        ' ''grdFiltroSolicitudes.Columns("Utilidades").ReadOnly = True
        ' ''grdFiltroSolicitudes.Columns("Utilidades").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        ' ''grdFiltroSolicitudes.Columns("Gratificacion").DefaultCellStyle.Format = "##,##00"
        ' ''grdFiltroSolicitudes.Columns.Add("DiasTrabajados", "DíasTrabajados") '10
        ' ''grdFiltroSolicitudes.Columns("DiasTrabajados").ReadOnly = True
        ' ''grdFiltroSolicitudes.Columns("DiasTrabajados").Visible = False
        ' ''grdFiltroSolicitudes.Columns("DiasTrabajados").DefaultCellStyle.Format = "##,##00"
        ' ''grdFiltroSolicitudes.Columns("DiasTrabajados").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' ''grdFiltroSolicitudes.Columns.Add("TotalEntregar", "TotalEntregar") '10
        ' ''grdFiltroSolicitudes.Columns("TotalEntregar").ReadOnly = True
        ' ''grdFiltroSolicitudes.Columns("TotalEntregar").DefaultCellStyle.Format = "##,##00"
        ' ''grdFiltroSolicitudes.Columns("TotalEntregar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ' ''grdFiltroSolicitudes.Columns("TotalEntregar").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        ' ''grdFiltroSolicitudes.Columns.Add("Estado", "Estado") '11
        ' ''grdFiltroSolicitudes.Columns("Estado").Visible = False
        ' ''grdFiltroSolicitudes.Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        ' ''grdFiltroSolicitudes.Columns.Add("FechaSolicitud", "FechaSolicitud") '12
        ' ''grdFiltroSolicitudes.Columns("FechaSolicitud").ReadOnly = True
        ' ''grdFiltroSolicitudes.Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        ' ''grdFiltroSolicitudes.Columns("FechaSolicitud").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        ' ''grdFiltroSolicitudes.Columns.Add("FechaBaja", "FechaBaja") '13
        ' ''grdFiltroSolicitudes.Columns("FechaBaja").ReadOnly = True
        ' ''grdFiltroSolicitudes.Columns("FechaBaja").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        ' ''grdFiltroSolicitudes.Columns("FechaBaja").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        ' ''grdFiltroSolicitudes.Columns.Add("FechaAutorizacion", "FechaAutorización") '14
        ' ''grdFiltroSolicitudes.Columns("FechaAutorizacion").ReadOnly = True
        ' ''grdFiltroSolicitudes.Columns("FechaAutorizacion").Visible = False
        ' ''grdFiltroSolicitudes.Columns("FechaAutorizacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        ' ''grdFiltroSolicitudes.Columns("FechaAutorizacion").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        ' ''grdFiltroSolicitudes.Columns.Add("UsuarioCreo", "UsuarioCreo") '15
        ' ''grdFiltroSolicitudes.Columns("UsuarioCreo").ReadOnly = True
        ' ''grdFiltroSolicitudes.Columns("UsuarioCreo").Visible = False
        ' ''grdFiltroSolicitudes.Columns.Add("VoBo", "VoBo") '16
        ' ''grdFiltroSolicitudes.Columns("VoBo").ReadOnly = True
        ' ''grdFiltroSolicitudes.Columns("VoBo").Visible = False
        ' ''grdFiltroSolicitudes.Columns.Add("VoBoFecha", "VoBoFecha") '17
        ' ''grdFiltroSolicitudes.Columns("VoBoFecha").ReadOnly = True
        ' ''grdFiltroSolicitudes.Columns("VoBoFecha").Visible = False
        ' ''grdFiltroSolicitudes.Columns.Add("IDSolicitud", "IDSolicitud") '18
        ' ''grdFiltroSolicitudes.Columns("IDSolicitud").Visible = False
        ' ''grdFiltroSolicitudes.Columns.Add("ColaboradorID", "ColaboradorID") '19
        ' ''grdFiltroSolicitudes.Columns("ColaboradorID").Visible = False
        '' '' grdFiltroSolicitudes.ScrollBars = ScrollBars.Horizontal

        ' ''Dim dt As New DateTime
        ' ''Dim fecha As String
        ' ''fecha = dt.ToString

        ' ''grdFiltroSolicitudes.Columns("Años").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        ' ''grdFiltroSolicitudes.Columns("Meses").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        '' ''  grdFiltroSolicitudes.Columns("Autorizar").ReadOnly = False
    End Sub

    Private Sub grdSolicitudes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdSolicitudes.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    ' ''Private Sub grdSolicitudes_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grdSolicitudes.DoubleClickRow
    ' ''    If e.Row.IsFilterRow = False Then
    ' ''        Dim Calculo As New EditarCalculoFiniquitoForm
    ' ''        Dim Finiquitos As New Entidades.Finiquitos
    ' ''        Calculo.MaximizeBox = False
    ' ''        Calculo.PSolicitudFiniquitoColaborador = e.Row.Cells("codr_colaboradorid").Value
    ' ''        Finiquitos.PFiniquito = e.Row.Cells("fini_finiquitoid").Value
    ' ''        Finiquitos.PEstado = e.Row.Cells("fini_estado").Value
    ' ''        Calculo.PSolFiniquitosExterno = Finiquitos
    ' ''        Calculo.ShowDialog()
    ' ''    End If
    ' ''End Sub

    Private Sub grdSolicitudes_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdSolicitudes.InitializeRow
        ' ''Public Sub Pintartabla()
        ' ''    Dim hasta As New Int32
        ' ''    hasta = grdFiltroSolicitudes.Rows.Count - 1
        ' ''    For i = 0 To hasta
        ' ''        If grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "A" Then ' Solicitado
        ' ''            grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFBB8")
        ' ''        ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "B" Then ' Autorizado Gerente
        ' ''            grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#96CF3A")
        ' ''        ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "C" Then ' Rechazado
        ' ''            grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#BAEBFF")
        ' ''        ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "D" Then ' Autorizado Director
        ' ''            grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF96")
        ' ''        ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "E" Then ' solocitado a Cajca Chica
        ' ''            grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#C5C5C5")
        ' ''        ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "F" Then ' Entregado
        ' ''            grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#618DEE")
        ' ''        ElseIf grdFiltroSolicitudes.Rows(i).Cells("Estado").Value = "G" Then ' Entregado
        ' ''            grdFiltroSolicitudes.Rows(i).DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#C5C5C5")
        ' ''        End If
        ' ''    Next
        ' ''End Sub
        If e.Row.Cells("fini_estado").Value = "A" Then ' Solicitado
            e.Row.Cells("estDsn").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFBB8")
            e.Row.Cells("Seleccion").Activation = Activation.AllowEdit
        ElseIf e.Row.Cells("fini_estado").Value = "B" Then ' AUTORIZADO
            e.Row.Cells("estDsn").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#96CF3A")
            e.Row.Cells("Seleccion").Activation = Activation.AllowEdit
        ElseIf e.Row.Cells("fini_estado").Value = "C" Then ' Rechazado
            e.Row.Cells("estDsn").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#F28773")
            e.Row.Cells("Seleccion").Activation = Activation.NoEdit
        ElseIf e.Row.Cells("fini_estado").Value = "D" Then ' Autorizado Director
            e.Row.Cells("estDsn").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#96CF3A")
            e.Row.Cells("Seleccion").Activation = Activation.AllowEdit
        ElseIf e.Row.Cells("fini_estado").Value = "E" Then ' Solicitado a caja chica
            e.Row.Cells("estDsn").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#088A85")
            e.Row.Cells("Seleccion").Activation = Activation.NoEdit
        ElseIf e.Row.Cells("fini_estado").Value = "F" Then  ' Recibido caja chica
            e.Row.Cells("estDsn").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#70EE9C")
            e.Row.Cells("Seleccion").Activation = Activation.AllowEdit
        ElseIf e.Row.Cells("fini_estado").Value = "G" Then ' Entregado
            e.Row.Cells("estDsn").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FEF60D")
            e.Row.Cells("Seleccion").Activation = Activation.NoEdit
        ElseIf e.Row.Cells("fini_estado").Value = "H" Then  'Entregado dirección
            e.Row.Cells("estDsn").Appearance.BackColor = Color.MediumPurple
            e.Row.Cells("seleccion").Activation = Activation.NoEdit
        ElseIf e.Row.Cells("fini_estado").Value = "N" Then  'No Entregada
            e.Row.Cells("estDsn").Appearance.BackColor = Color.RoyalBlue
            e.Row.Cells("seleccion").Activation = Activation.NoEdit
        End If
    End Sub

    Private Sub cmbNave_DropDownClosed(sender As Object, e As EventArgs) Handles cmbNave.DropDownClosed
        llenarComboCajas()
    End Sub



    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        grdSolicitudes.DataSource = Nothing
        If cmbNave.SelectedIndex > 0 Then
            llenarComboPeriodos()
        Else
            cmbPeriodo.DataSource = Nothing
        End If
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged
        If cmbNave.SelectedIndex > 0 Then
            llenarTablaSolicitudes()
        End If

        If cmbStatus.SelectedIndex > 0 Then
            If cmbStatus.Text = "SOLICITADO" Then
                pnlAutorizar.Enabled = True
                pnlSolicitar.Enabled = False
                pnlEntregar.Enabled = False
            ElseIf cmbStatus.Text = "AUTORIZADO" Then
                pnlAutorizar.Enabled = False
                pnlSolicitar.Enabled = True
                pnlEntregar.Enabled = False
            ElseIf cmbStatus.Text = "DINERO ENTREGADO A NAVE" Then
                pnlAutorizar.Enabled = False
                pnlSolicitar.Enabled = False
                pnlEntregar.Enabled = True
                pnlEntregarDireccion.Enabled = True
            Else
                pnlAutorizar.Enabled = False
                pnlSolicitar.Enabled = False
                pnlEntregar.Enabled = False
                pnlEntregarDireccion.Enabled = False
            End If
        Else
            grdSolicitudes.DataSource = Nothing
            pnlAutorizar.Enabled = False
            pnlSolicitar.Enabled = False
            pnlEntregar.Enabled = False
            pnlEntregarDireccion.Enabled = False
        End If
    End Sub

    Private Sub btnFiltrarSolicitud_Click_1(sender As Object, e As EventArgs) Handles btnFiltrarSolicitud.Click
        If cmbNave.SelectedValue > 0 Then
            llenarTablaSolicitudes()
            ' ''grdFiltroSolicitudes.Rows.Clear()
            ' ''llenartabla()
            ' ''Pintartabla()
            lblNave.ForeColor = Color.Black
        Else
            lblNave.ForeColor = Color.Red
            Dim forma As New AdvertenciaForm
            forma.mensaje = "Debe de seleccionar una nave para realizar la búsqueda"
            forma.ShowDialog()
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnLimpiarSolicitudes_Click_1(sender As Object, e As EventArgs) Handles btnLimpiarSolicitudes.Click
        cmbNave.SelectedIndex = 0
        cmbStatus.SelectedIndex = 0
        grdSolicitudes.DataSource = Nothing
    End Sub

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        Dim CountAcept As Int32 = 0
        Dim SolicitudBajaID As New Contabilidad.Negocios.SolicitudBajaBU

        For Each row As UltraGridRow In grdSolicitudes.Rows
            If CBool(row.Cells("Seleccion").Value) = True And row.Cells("fini_estado").Value = "A" Then
                CountAcept += 1
            End If
        Next
        If CountAcept > 0 Then
            Dim objMensaje As New Tools.ConfirmarForm
            objMensaje.mensaje = "¿Esta seguro que desea autorizar los finiquitos seleccionados?"
            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                AutorizarSolicitudes()
                Me.Cursor = Cursors.Default
                llenarTablaSolicitudes()


            End If
        Else
            Dim FormaExito As New AdvertenciaForm
            FormaExito.mensaje = "Debe seleccionar al menos un finiquito cuyo estado sea SOLICITADO"
            FormaExito.ShowDialog()
        End If
    End Sub

    Private Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
        Dim CountAcept As Int32 = 0
        For Each row As UltraGridRow In grdSolicitudes.Rows
            If CBool(row.Cells("Seleccion").Value) = True And row.Cells("fini_estado").Value = "A" Then
                CountAcept += 1
            End If
        Next
        If CountAcept > 0 Then
            Dim objMensaje As New Tools.ConfirmarForm
            objMensaje.mensaje = "¿Está seguro de rechazar las Solicitudes?"
            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                RechazarSolicitudes()
                llenarTablaSolicitudes()
            End If
        Else
            Dim FormaExito As New AdvertenciaForm
            FormaExito.mensaje = "Seleccione al menos una solicitud"
            FormaExito.ShowDialog()
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
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

    Private Sub grdSolicitudes_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grdSolicitudes.DoubleClickRow
        If e.Row.IsFilterRow = False Then
            If e.Row.Cells("fini_finiquitoid").Value > 0 Then
                Dim finiquitoCons As New CalculoFiniquitoForm
                If e.Row.Cells("fini_estado").Value = "A" Then
                    finiquitoCons.ACCION = "EDITAR"
                Else
                    finiquitoCons.ACCION = "CONSULTA"
                End If
                finiquitoCons.idFiniquito = e.Row.Cells("fini_finiquitoid").Value
                finiquitoCons.idNaveEmpleadoFin = e.Row.Cells("labo_naveid").Value
                finiquitoCons.idColaboradorFin = e.Row.Cells("codr_colaboradorid").Value
                finiquitoCons.puestoFin = e.Row.Cells("pues_nombre").Value
                finiquitoCons.nombreEmpleadoFin = e.Row.Cells("Colaborador").Value
                finiquitoCons.departamentoFin = e.Row.Cells("grup_name").Value
                finiquitoCons.ahorroFin = e.Row.Cells("fini_ahorro").Value
                finiquitoCons.JustificacionFin = e.Row.Cells("fini_justificacion").Value
                finiquitoCons.prestamoFin = e.Row.Cells("fini_prestamo").Value
                finiquitoCons.gratificacionFin = e.Row.Cells("fini_gratificacion").Value
                finiquitoCons.fechaIngreso = e.Row.Cells("real_fecha").Value

                finiquitoCons.antiguedadanios = e.Row.Cells("fini_antiguedadanios").Value
                finiquitoCons.antiguedadmeses = e.Row.Cells("fini_antiguedadmeses").Value
                finiquitoCons.antiguedaddias = e.Row.Cells("fini_antiguedaddias").Value
                finiquitoCons.sueldosemana1 = e.Row.Cells("fini_sueldosemana1").Value
                finiquitoCons.sueldosemana2 = e.Row.Cells("fini_sueldosemana2").Value
                finiquitoCons.sueldosemana2 = e.Row.Cells("fini_sueldosemana2").Value
                finiquitoCons.sueldosemana3 = e.Row.Cells("fini_sueldosemana3").Value
                finiquitoCons.sueldosemana4 = e.Row.Cells("fini_sueldosemana4").Value

                finiquitoCons.totalaguinaldo = e.Row.Cells("fini_totalaguinaldo").Value
                finiquitoCons.totalvacaciones = e.Row.Cells("fini_totalvacaciones").Value
                finiquitoCons.primavacacional = e.Row.Cells("fini_primavacacional").Value
                finiquitoCons.subtotalfiniquito = e.Row.Cells("fini_subtotal").Value
                finiquitoCons.fechaAutorizo = e.Row.Cells("fini_fechaautorizacion").Value.ToString

                finiquitoCons.totalfiniquito = e.Row.Cells("fini_totalfiniquito").Value

                finiquitoCons.utilidades = e.Row.Cells("fini_utilidades").Value
                finiquitoCons.utilidadesanterior = e.Row.Cells("fini_utilidadesanterior").Value.ToString
                finiquitoCons.anioutilidades = e.Row.Cells("fini_anioutilidades").Value.ToString
                finiquitoCons.anioutilidadesanterior = e.Row.Cells("fini_anioutilidadesanterior").Value.ToString
                finiquitoCons.totalentregar = e.Row.Cells("fini_totalentregar").Value
                finiquitoCons.fechasolicitud = e.Row.Cells("fini_fechasolicitud").Value
                finiquitoCons.salariosemanal = e.Row.Cells("fini_salariosemanal").Value
                finiquitoCons.salariodiario = e.Row.Cells("fini_salariodiario").Value
                finiquitoCons.mesesaguinaldo = e.Row.Cells("fini_mesesaguinaldo").Value
                finiquitoCons.diasaguinaldo = e.Row.Cells("fini_diasaguinaldo").Value
                finiquitoCons.mesesvacaciones = e.Row.Cells("fini_mesesvacaciones").Value
                finiquitoCons.diasvacaciones = e.Row.Cells("fini_diasvacaciones").Value
                finiquitoCons.tipoPago = e.Row.Cells("real_tiposueldo").Value
                finiquitoCons.estado = e.Row.Cells("fini_estado").Value
                If e.Row.Cells("fini_extras").Value.ToString = "" Then
                    finiquitoCons.extras = 0
                Else
                    finiquitoCons.extras = e.Row.Cells("fini_extras").Value
                End If


                If e.Row.Cells("fini_norecontratar").Value.ToString = "" Then
                    finiquitoCons.recontratarFin = False
                Else
                    finiquitoCons.recontratarFin = CBool(e.Row.Cells("fini_norecontratar").Value)
                End If

                finiquitoCons.motivoFin = e.Row.Cells("fini_motivofiniquitoid").Value
                finiquitoCons.fechaBajaFin = e.Row.Cells("fini_fechabaja").Value
                finiquitoCons.ShowDialog()
                If cmbNave.SelectedIndex > 0 Then
                    llenarTablaSolicitudes()
                End If
            End If
        End If


    End Sub

    Private Sub btnSolicitar_Click(sender As Object, e As EventArgs) Handles btnSolicitar.Click
        Dim CountAcept As Int32 = 0
        Dim monto As Double = 0.0
        Dim dtValidaSolicitudCaja As New DataTable
        Dim objBu As New Negocios.FiniquitosBU
        Dim PasaValidacion As Integer = 0
        Dim advertencia As New AdvertenciaForm
        Dim NaveID As Integer = 0

        NaveID = cmbNave.SelectedValue

        For Each row As UltraGridRow In grdSolicitudes.Rows
            If CBool(row.Cells("Seleccion").Value) = True And (row.Cells("fini_estado").Value = "B" Or row.Cells("fini_estado").Value = "D") Then
                'If NaveID <> 43 And NaveID <> 73 Then
                dtValidaSolicitudCaja = objBu.ValidaSolicitudCaja(row.Cells("fini_finiquitoid").Value)

                For Each fila As DataRow In dtValidaSolicitudCaja.Rows
                    PasaValidacion = dtValidaSolicitudCaja.Rows(0).Item("Solicitar")
                Next
                If PasaValidacion = 1 Then
                    monto = monto + CDbl(row.Cells("fini_totalentregar").Value)
                    CountAcept += 1
                Else
                    advertencia.mensaje = "Los finiquitos con fecha antigua no se solicitarán a caja chica."
                    advertencia.ShowDialog()
                End If
                'Else
                '    monto = monto + CDbl(row.Cells("fini_totalentregar").Value)
                '    CountAcept += 1
                'End If
            Else
            End If
        Next
        If CountAcept > 0 Then
            Dim objMensaje As New Tools.ConfirmarForm
            objMensaje.mensaje = "Se realizara una solicitud por $" + monto.ToString("N2") + " a finanzas. ¿Desea continuar?"
            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                solicitarCajaChica()
                Me.Cursor = Cursors.Default
                llenarTablaSolicitudes()
            End If
        Else
            Dim FormaExito As New AdvertenciaForm
            FormaExito.mensaje = "Debe seleccionar un finiquito cuyo estado sea AUTORIZADO"
            FormaExito.ShowDialog()
        End If


    End Sub

    Private Sub btnEntragarColaborador_Click(sender As Object, e As EventArgs) Handles btnEntragarColaborador.Click
        Dim CountAcept As Int32 = 0
        For Each row As UltraGridRow In grdSolicitudes.Rows
            If CBool(row.Cells("Seleccion").Value) = True And row.Cells("fini_estado").Value = "F" Then
                CountAcept += 1
            End If
        Next
        If CountAcept > 0 Then
            Dim objMensaje As New Tools.ConfirmarForm
            objMensaje.mensaje = "¿Está seguro de cambiar el estatus a entregado?"
            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                entregarColaborador()
                Me.Cursor = Cursors.Default
                llenarTablaSolicitudes()
            End If
        Else
            Dim FormaExito As New AdvertenciaForm
            FormaExito.mensaje = "Debe seleccionar un finiquito cuyo estado sea RECIBIDO DE CAJA CHICA"
            FormaExito.ShowDialog()
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_LIST_FINI", "NOM_REP_FINI") Then
            verReporteLiquidacionCompleto = True
            ReporteFiniquitoToolStripMenuItem.Visible = False
            ReporteFiniquito2ToolStripMenuItem.Visible = True
        Else
            verReporteLiquidacionCompleto = False
            ReporteFiniquitoToolStripMenuItem.Visible = True
            ReporteFiniquito2ToolStripMenuItem.Visible = False
        End If

        ContextMenuStrip1.Show(btnImprimir, 0, btnImprimir.Height)
    End Sub

    Private Sub ImprimirFichaDeRenunciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirFichaDeRenunciaToolStripMenuItem.Click
        If Not grdSolicitudes.DataSource Is Nothing Then
            If grdSolicitudes.ActiveRow.IsFilterRow = False Then
                'Dim FichaFiniquito As New FichaFiniquito
                'Dim objTools As New ReportesVistaPrevia
                Dim IdFiniquito As String = grdSolicitudes.ActiveRow.Cells("fini_finiquitoid").Value.ToString
                Dim idColaborador As String = grdSolicitudes.ActiveRow.Cells("codr_colaboradorid").Value.ToString
                'If objTools.ImprimirYuyinERP(FichaFiniquito, "@fini_finiquitoid", IDCOlaborador, "Entero") Then
                '    objTools.ShowDialog()
                '    objTools.Close()
                'End If

                ''Agregado cambio de reporte 
                Dim objBu As New Negocios.FiniquitosBU
                Dim dtReporte As New DataTable
                Dim dtCajas As New DataTable
                Dim semanas, monto, ahorro As Int32
                dtCajas = objBu.obtenerMontosCajaAhorro(CInt(cmbNave.SelectedValue), idColaborador)

                monto = dtCajas.Rows(0).Item("monto")
                semanas = dtCajas.Rows(0).Item("semanas")
                ahorro = dtCajas.Rows(0).Item("ahorro")


                dtReporte = objBu.ImprimirReporteFichaRenuncia(IdFiniquito)
                If dtReporte.Rows.Count > 0 Then
                    Dim objReporte As New Framework.Negocios.ReportesBU
                    Dim entReporte As New Entidades.Reportes
                    entReporte = objReporte.LeerReporteporClave("FICHA_RENUNCIA_FINIQUITO")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)

                    Dim reporte As New StiReport
                    reporte.Load(archivo)
                    reporte.Compile()

                    If dtReporte.Rows(0).Item("seguro").ToString.Length >= 7 Then
                        reporte("asegurado") = "SI"
                    Else
                        reporte("asegurado") = "NO"
                    End If
                    reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
                    reporte("elaboro") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString.ToUpper
                    reporte("semanas") = semanas
                    reporte("monto") = monto
                    reporte("ahorro") = ahorro
                    reporte.Dictionary.Clear()
                    reporte.RegData(dtReporte)
                    reporte.Dictionary.Synchronize()
                    reporte.Show()

                End If
            Else
                Dim Advertencia As New AdvertenciaForm
                Advertencia.mensaje = "Seleccione un colaborador valido"
                Advertencia.MdiParent = MdiParent
                Advertencia.ShowDialog()
            End If
        End If
    End Sub

    Private Sub ImprimirCartaDeRenunciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirCartaDeRenunciaToolStripMenuItem.Click
        If Not grdSolicitudes.DataSource Is Nothing Then
            If grdSolicitudes.ActiveRow.IsFilterRow = False Then
                Dim estatus As String = ""
                estatus = grdSolicitudes.ActiveRow.Cells("fini_estado").Value.ToString
                Dim nombre As String = ""
                Dim patron As String = ""
                Dim domicilio As String = ""
                Dim Puesto As String = ""
                Dim IDCOlaborador As String = grdSolicitudes.ActiveRow.Cells("codr_colaboradorid").Value.ToString
                Dim objBu As New ColaboradorNominaBU
                Dim objNomina As New Entidades.ColaboradorNomina
                Dim objlaboral As New ColaboradorLaboralBU
                Dim entidadLaboral As New Entidades.ColaboradorLaboral

                entidadLaboral = objlaboral.buscarInformacionLaboral(CInt(IDCOlaborador))
                checa = entidadLaboral.PCheca
                Puesto = entidadLaboral.PPuestoId.PNombre
                objNomina = objBu.buscarColaborarNomina(CInt(IDCOlaborador))
                nombre = grdSolicitudes.ActiveRow.Cells("Colaborador").Value.ToString()
                patron = objNomina.PPatron.Pnombre.Replace("( JEANS 1 )", "").Replace("( JEANS 2 )", "").Replace("(SUELAS)", "")
                Dim objPatron As New PatronesBU
                Dim entidadPatron As New Entidades.Patrones
                entidadPatron = objPatron.buscarPatrones(objNomina.PPatron.Ppatronid)
                domicilio = entidadPatron.Pcalle.ToUpper + " NO. " + entidadPatron.PDnumero.ToUpper + " COLONIA " + entidadPatron.Pcolonia.ToUpper

                If estatus = "A" Then

                    imprimirCartaRenunicaSinCantidades(nombre, patron, domicilio, Puesto)

                Else
                    imprimirCartaRenunicaConCantidades(nombre, patron, domicilio, Puesto)
                    'Dim objTools As New ReportesVistaPrevia
                    'Dim objFoto As New FichaFiniquito
                    'Dim CartaRenuncia As New CartaRenuncia
                    'Dim IDCOlaborador As String = grdSolicitudes.ActiveRow.Cells("fini_finiquitoid").Value.ToString
                    'If objTools.ImprimirYuyinERP(CartaRenuncia, "@fini_finiquitoid", IDCOlaborador, "Entero") Then
                    '    objTools.ShowDialog()
                    '    objTools.Close()
                    'End If
                End If


            Else
                Dim Advertencia As New AdvertenciaForm
                Advertencia.mensaje = "Seleccione un registro"
                Advertencia.MdiParent = MdiParent
                Advertencia.ShowDialog()
            End If
        End If

    End Sub

    Private Sub ImprimirDetalleToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Not grdSolicitudes.DataSource Is Nothing Then
            If grdSolicitudes.ActiveRow.IsFilterRow = False Then
                Dim objTools As New ReportesVistaPrevia
                Dim Detalle As New DetalleCantidadEntregada
                Dim IDCOlaborador As String = grdSolicitudes.ActiveRow.Cells("fini_finiquitoid").Value.ToString
                If objTools.ImprimirYuyinERP(Detalle, "@fini_finiquitoid", IDCOlaborador, "Entero") Then
                    objTools.ShowDialog()
                    objTools.Close()
                End If
            Else
                Dim Advertencia As New AdvertenciaForm
                Advertencia.mensaje = "Seleccione un colaborador valido"
                Advertencia.MdiParent = MdiParent
                Advertencia.ShowDialog()
            End If
        End If
    End Sub

    Private Sub ImprimirCartaUtilidadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirCartaUtilidadesToolStripMenuItem.Click
        If Not grdSolicitudes.DataSource Is Nothing Then
            If grdSolicitudes.ActiveRow.IsFilterRow = False Then
                Dim estatus As String = ""
                estatus = grdSolicitudes.ActiveRow.Cells("fini_estado").Value.ToString
                Dim nombre As String = ""
                Dim IDCOlaborador As String = grdSolicitudes.ActiveRow.Cells("codr_colaboradorid").Value.ToString
                nombre = grdSolicitudes.ActiveRow.Cells("Colaborador").Value.ToString()
                imprimirCartaUtilidades(IDCOlaborador, nombre)
            Else
                Dim Advertencia As New AdvertenciaForm
                Advertencia.mensaje = "Seleccione un registro"
                Advertencia.MdiParent = MdiParent
                Advertencia.ShowDialog()
            End If
        End If

        '[AAlcaraz 2023-05-02] Este snip comentado es como se sacaba el reporte antes, se cambia de Crystal reports a Stimulsoft.
        'If Not grdSolicitudes.DataSource Is Nothing Then
        '    If grdSolicitudes.ActiveRow.IsFilterRow = False Then
        '        Dim objTools As New ReportesVistaPrevia
        '        Dim Detalle As New CartaUtilidades
        '        Dim IDCOlaborador As String = grdSolicitudes.ActiveRow.Cells("fini_finiquitoid").Value.ToString
        '        If objTools.ImprimirYuyinERP(Detalle, "@fini_finiquitoid", IDCOlaborador, "Entero") Then
        '            objTools.ShowDialog()
        '            objTools.Close()
        '        End If
        '    Else
        '        Dim Advertencia As New AdvertenciaForm
        '        Advertencia.mensaje = "Seleccione un colaborador valido"
        '        Advertencia.MdiParent = MdiParent
        '        Advertencia.ShowDialog()
        '    End If
        'End If
    End Sub

    Private Sub btnNuevoFiniquito_Click(sender As Object, e As EventArgs) Handles btnNuevoFiniquito.Click
        Dim objFiniq As New CalculoFiniquitoForm
        objFiniq.ShowDialog()
        If cmbNave.SelectedIndex > 0 Then
            llenarTablaSolicitudes()
        End If
    End Sub


    Public Sub imprimirReporte()
        If chkXFechas.Checked = True Then
            Dim dsFiniquitos As New DataSet("dsFiniquitos")
            Dim dtFechaEntrega As New DataTable("dtFechaEntrega")
            Dim dtFechaBaja As New DataTable("dtFechaBaja")
            Dim dtConcentrado As New DataTable("dtConcentrado")

            Dim objBuC As New Negocios.ReporteCajaAhorroBU

            If (verReporteLiquidacionCompleto) Then
                dtConcentrado = objBuC.consultaDeduccionesPrestamosSemanas_V2(DatePart(DateInterval.Year, CDate(dttInicio.Value)))
                dtConcentrado.TableName = "dtConcentrado"
                dsFiniquitos.Tables.Add(dtConcentrado)
            Else
                dtConcentrado = objBuC.consultaDeduccionesPrestamosSemanas(DatePart(DateInterval.Year, CDate(dttInicio.Value)))
                dtConcentrado.TableName = "dtConcentrado"
                dsFiniquitos.Tables.Add(dtConcentrado)
            End If

            Dim periodo As String = ""
            If rdoFechaBaja.Checked = True Then
                If dtReporte.Rows.Count > 0 Then
                    dtFechaBaja = dtReporte.Copy()
                    dtFechaBaja.TableName = "dtFechaBaja"
                    dtFechaEntrega.TableName = "dtFechaEntrega"
                    dsFiniquitos.Tables.Add(dtFechaBaja)
                    dsFiniquitos.Tables.Add(dtFechaEntrega)
                End If
            Else
                If dtReporte.Rows.Count > 0 Then
                    dtFechaEntrega = dtReporte.Copy()
                    dtFechaEntrega.TableName = "dtFechaEntrega"
                    dtFechaBaja.TableName = "dtFechaBaja"
                    dsFiniquitos.Tables.Add(dtFechaEntrega)
                    dsFiniquitos.Tables.Add(dtFechaBaja)
                End If
            End If



            Dim OBJBU As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            If (verReporteLiquidacionCompleto) Then
                EntidadReporte = OBJBU.LeerReporteporClave("NOM_REP_FINIQUITOS_V2")
            Else
                EntidadReporte = OBJBU.LeerReporteporClave("NOM_REP_FINIQUITOS")
            End If

            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport
            reporte.Load(archivo)
            reporte.Compile()
            reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
            reporte("nombreNave") = cmbNave.Text
            reporte("NombreReporte") = "SAY: REPORTE FINIQUITOS.mrt"
            reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
            reporte("elaboro") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString.ToUpper

            Dim objPeriBU As New Negocios.ControlDePeriodoBU
            Dim dtPeriodos As New DataTable
            dtPeriodos = objPeriBU.buscarPeriodoSegunNaveSegunAsistencia(cmbNave.SelectedValue)
            For Each row As DataRow In dtPeriodos.Rows
                If cmbPeriodo.SelectedValue.ToString = row.Item("pnom_PeriodoNomId").ToString Then
                    reporte("SemanaBaja") = CInt(row.Item("pnom_NoSemanaNomina").ToString)


                    If CInt(row.Item("pnom_NoSemanaNomina").ToString) = 51 Then
                        reporte("SemanaEntrega") = 2
                    ElseIf CInt(row.Item("pnom_NoSemanaNomina").ToString) = 52 Then
                        reporte("SemanaEntrega") = 2
                    ElseIf CInt(row.Item("pnom_NoSemanaNomina").ToString) = 50 Then
                        reporte("SemanaEntrega") = 1
                    Else
                        reporte("SemanaEntrega") = CInt(row.Item("pnom_NoSemanaNomina").ToString) + 2
                    End If

                    Exit For
                End If
            Next


            Dim cadenaPeriodo As String = ""

            If rdoPeriodo.Checked = True Then
                cadenaPeriodo = "PERIODO " + cmbPeriodo.Text.ToUpper
            Else
                periodo = Replace(dttInicio.Value.ToString("dd/MMMM/yyyy"), "/", " ").ToUpper + " AL " + Replace(dttFin.Value.ToString("dd/MMMM/yyyy"), "/", " ").ToUpper
                'cadenaPeriodo = "PERIODO DEL " + periodo.ToUpper + " AL " + dttFin.Text.ToUpper
                cadenaPeriodo = periodo
            End If
            If cmbStatus.SelectedIndex > 1 Then
                cadenaPeriodo += ", ESTATUS: " + cmbStatus.Text.ToUpper
            End If
            reporte("Periodo") = cadenaPeriodo


            reporte.Dictionary.Clear()
            reporte.RegData(dsFiniquitos)
            reporte.Dictionary.Synchronize()
            reporte.Show()
            dsFiniquitos.Tables.Clear()
        Else
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "Es necesario seleccionar filtro por fechas."
            objMensaje.ShowDialog()
        End If
    End Sub

    Public Sub imprimirCartaUtilidades(ByVal IdColaborador As Int32, ByVal nombreColaborador As String)
        Dim OBJBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim objBuNe As New Negocios.FiniquitosBU
        Dim tool As New Tools.Controles
        Dim ultimoDia As New Date
        Dim utilidadesAnterior As Double
        Dim utilidadesActual As Double
        Dim totalLetraAnterior As String
        Dim totalLetraActual As String
        Dim periodoAnterior As Int32
        Dim periodoActual As Int32
        Dim configUtilidades As Int32
        Dim conteopaginas As Int32

        'Datos calculados
        ultimoDia = CDate(grdSolicitudes.ActiveRow.Cells("fini_fechabaja").Value)

        Dim dtCalculoFiniquito As New DataTable
        Dim dtConfigNave As New DataTable
        dtCalculoFiniquito = objBuNe.DatosCalculoFiniquito(CInt(grdSolicitudes.ActiveRow.Cells("codr_colaboradorid").Value.ToString), CDate(grdSolicitudes.ActiveRow.Cells("fini_fechabaja").Value.ToString))
        dtConfigNave = objBuNe.ConfiguracionFiniquitoNave(CInt(grdSolicitudes.ActiveRow.Cells("codr_colaboradorid").Value.ToString))

        If dtConfigNave.Rows.Count > 0 Then
            configUtilidades = dtConfigNave.Rows(0).Item("cffn_utilidades")
        Else
            configUtilidades = 1
        End If
        'Se valida que la nave pueda dar utilidades.
        If configUtilidades = 1 Then

            totalLetraAnterior = ""
            totalLetraActual = ""
            conteopaginas = 0

            If IsDBNull(grdSolicitudes.ActiveRow.Cells("fini_utilidadesanterior").Value) = False Then
                If grdSolicitudes.ActiveRow.Cells("fini_utilidadesanterior").Value > 0 Then
                    utilidadesAnterior = Math.Round(CDbl(grdSolicitudes.ActiveRow.Cells("fini_utilidadesanterior").Value), 0)
                    totalLetraAnterior = tool.EnLetras(utilidadesAnterior.ToString.Replace(".0000", "")).ToUpper + " PESOS 00/100 M.N.) "
                    conteopaginas = conteopaginas + 1
                Else
                    utilidadesAnterior = CDbl(0)
                End If
            Else
                utilidadesAnterior = CDbl(0)
            End If


            If IsDBNull(grdSolicitudes.ActiveRow.Cells("fini_utilidades").Value) = False Then
                If grdSolicitudes.ActiveRow.Cells("fini_utilidades").Value > 0 Then
                    utilidadesActual = Math.Round(CDbl(grdSolicitudes.ActiveRow.Cells("fini_utilidades").Value), 0) - utilidadesAnterior
                    totalLetraActual = tool.EnLetras(utilidadesActual.ToString.Replace(".0000", "")).ToUpper + " PESOS 00/100 M.N.) "
                    conteopaginas = conteopaginas + 1
                Else
                    utilidadesActual = CDbl(0)
                End If
            Else
                utilidadesActual = CDbl(0)
            End If


            If IsDBNull(grdSolicitudes.ActiveRow.Cells("fini_anioutilidadesanterior").Value) = True Then
                periodoAnterior = Year(CDate(ultimoDia)) - 1
            Else
                periodoAnterior = grdSolicitudes.ActiveRow.Cells("fini_anioutilidadesanterior").Value
            End If

            If IsDBNull(grdSolicitudes.ActiveRow.Cells("fini_anioutilidades").Value) = True Then
                periodoActual = Year(CDate(ultimoDia))
            Else
                periodoActual = grdSolicitudes.ActiveRow.Cells("fini_anioutilidades").Value
            End If

            Dim MostrarValido As Boolean = True

            If conteopaginas = 2 Then
                EntidadReporte = OBJBU.LeerReporteporClave("NOM_REP_CARTAUTILIDADES")
            ElseIf conteopaginas = 1 Then
                EntidadReporte = OBJBU.LeerReporteporClave("NOM_REP_CARTAUTILIDADES_1P")
            Else
                Dim FormaExito As New AdvertenciaForm
                FormaExito.mensaje = "Debe de existir monto de utilidades para mostrar la carta."
                FormaExito.ShowDialog()
                MostrarValido = False
            End If
            If MostrarValido = True Then
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                reporte("NombreColaborador") = nombreColaborador.ToUpper
                reporte("UltimoDia") = ultimoDia.ToLongDateString
                reporte("UtilidadesAnterior") = utilidadesAnterior
                reporte("UtilidadesActual") = utilidadesActual
                reporte("TotalLetraAnterior") = totalLetraAnterior
                reporte("TotalLetraActual") = totalLetraActual
                reporte("PeriodoAnterior") = periodoAnterior.ToString
                reporte("PeriodoActual") = periodoActual.ToString

                reporte.Dictionary.Clear()
                reporte.Dictionary.Synchronize()
                reporte.Show()
            End If

        Else
            Dim FormaExito As New AdvertenciaForm
            FormaExito.mensaje = "Reporte no disponible."
            FormaExito.ShowDialog()
        End If
    End Sub
    Public Sub imprimirCartaRenunicaSinCantidades(ByVal nombreColaborador As String, ByVal patron As String, ByVal Domicilio As String, ByVal puesto As String)

        Dim OBJBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim objBuNe As New Negocios.FiniquitosBU
        Dim ultimoDia As New Date
        Dim horario As String = ""
        EntidadReporte = OBJBU.LeerReporteporClave("NOM_REP_CARTARENUNCIA1")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()
        reporte("NombreColaborador") = nombreColaborador.ToUpper
        reporte("Patron") = patron.ToUpper
        reporte("Domicilio") = Domicilio.ToUpper
        reporte("Puesto") = puesto.ToUpper

        ultimoDia = objBuNe.ObtenerUltimoDiaTrabajado(grdSolicitudes.ActiveRow.Cells("codr_colaboradorid").Value.ToString, checa)

        horario = objBuNe.consultarHorarioNave(cmbNave.SelectedValue)
        'If cmbNave.SelectedValue = 43 Then
        '    horario = "Lunes a Viernes, de 9:00 hrs. A 14:00 hrs. y de 16:00 hrs. A 19:00 hrs y el Sábado de 9:00 hrs. a 14:00 hrs"
        'Else
        '    horario = "Lunes a Viernes, de 8:00 hrs. A 14:00 hrs. y de 15:00 hrs. A 17:00 hrs y el Sábado de 8:00 hrs. a 13:00 hrs"
        'End If

        reporte("horario") = horario
        reporte("UltimoDia") = ultimoDia.ToLongDateString

        reporte.Dictionary.Clear()
        reporte.Dictionary.Synchronize()
        reporte.Show()

    End Sub

    Public Sub imprimirCartaRenunicaConCantidades(ByVal nombreColaborador As String, ByVal patron As String, ByVal Domicilio As String, ByVal puesto As String)

        Dim OBJBU As New Framework.Negocios.ReportesBU
        Dim ultimoDia As New Date
        Dim fechaEntrega As New Date
        Dim horario As String = ""
        Dim objBuNe As New Negocios.FiniquitosBU
        Dim EntidadReporte As Entidades.Reportes
        Dim dtCantidades As New DataTable
        ' Dim etiquetaValor As DataRow = dtCantidades.NewRow
        dtCantidades = New DataTable
        dtCantidades.Columns.Add("Etiqueta")
        dtCantidades.Columns.Add("Valor")
        Dim antiguedadanios, aguinaldo, vacaciones, primaV, ahorro, gratificacion, utilidades, utilidadesanterior, utilidadesactual, extras, prestamo, totalentregar, totalPercepciones As Double
        Dim dtCalculoFiniquito As New DataTable
        Dim dtConfigNave As New DataTable
        Dim configUtilidades As Int32
        Dim configGratificacion As Int32
        Dim configAguinaldo As Int32
        Dim configExtras As Int32
        Dim saldoPendiente As Int32

        dtConfigNave = objBuNe.ConfiguracionFiniquitoNave(CInt(grdSolicitudes.ActiveRow.Cells("codr_colaboradorid").Value.ToString))
        If dtConfigNave.Rows.Count > 0 Then
            configUtilidades = dtConfigNave.Rows(0).Item("cffn_utilidades")
            configGratificacion = dtConfigNave.Rows(0).Item("cffn_gratificacion")
            configAguinaldo = dtConfigNave.Rows(0).Item("cffn_aguinaldo")
            configExtras = dtConfigNave.Rows(0).Item("cffn_extras")
        Else
            configUtilidades = 1
            configGratificacion = 1
            configAguinaldo = 1
            configExtras = 1
        End If

        Try
            fechaEntrega = CDate(grdSolicitudes.ActiveRow.Cells("fini_fechaentregado").Value)
        Catch
            fechaEntrega = Now
        End Try

        antiguedadanios = CInt(grdSolicitudes.ActiveRow.Cells("fini_antiguedadanios").Value)
        aguinaldo = CDbl(grdSolicitudes.ActiveRow.Cells("fini_totalaguinaldo").Value)
        vacaciones = CDbl(grdSolicitudes.ActiveRow.Cells("fini_totalvacaciones").Value)
        primaV = CDbl(grdSolicitudes.ActiveRow.Cells("fini_primavacacional").Value)
        ahorro = CDbl(grdSolicitudes.ActiveRow.Cells("fini_ahorro").Value)
        gratificacion = CDbl(grdSolicitudes.ActiveRow.Cells("fini_gratificacion").Value)
        utilidades = CDbl(grdSolicitudes.ActiveRow.Cells("fini_utilidades").Value)
        If IsDBNull(grdSolicitudes.ActiveRow.Cells("fini_utilidadesanterior").Value) = False Then
            utilidadesanterior = CDbl(grdSolicitudes.ActiveRow.Cells("fini_utilidadesanterior").Value)
        Else
            utilidadesanterior = CDbl(0)
        End If
        utilidadesactual = utilidades - utilidadesanterior
        prestamo = CDbl(grdSolicitudes.ActiveRow.Cells("fini_prestamo").Value)
        totalentregar = CDbl(grdSolicitudes.ActiveRow.Cells("fini_totalentregar").Value) + prestamo
        totalPercepciones = aguinaldo + ahorro
        Try
            extras = CDbl(grdSolicitudes.ActiveRow.Cells("fini_extras").Value)
        Catch
            extras = 0
        End Try

        ''creacion de etuiquetas reporte
        If aguinaldo > 0 And configAguinaldo <> 0 Then
            Dim etiquetaValor As DataRow = dtCantidades.NewRow
            etiquetaValor.Item("Etiqueta") = "Aguinaldo proporcional " + Year(fechaEntrega).ToString
            etiquetaValor.Item("Valor") = aguinaldo
            dtCantidades.Rows.Add(etiquetaValor)
        End If

        If vacaciones > 0 Then
            Dim etiquetaValor As DataRow = dtCantidades.NewRow
            etiquetaValor.Item("Etiqueta") = "Vacaciones proporcionales " + Year(fechaEntrega).ToString
            etiquetaValor.Item("Valor") = (vacaciones)
            dtCantidades.Rows.Add(etiquetaValor)
            totalPercepciones = totalPercepciones + vacaciones
        End If

        If primaV > 0 Then
            Dim etiquetaValor As DataRow = dtCantidades.NewRow
            etiquetaValor.Item("Etiqueta") = "Prima vacacional proporcional " + Year(fechaEntrega).ToString
            etiquetaValor.Item("Valor") = primaV
            dtCantidades.Rows.Add(etiquetaValor)
            totalPercepciones = totalPercepciones + primaV
        End If

        If extras < 0 Then
            gratificacion = gratificacion + extras
            If gratificacion < 0 Then
                saldoPendiente = gratificacion
            End If
        End If
        '[AAlcaraz 2023-04-18] Aqui se desglosan las utilidades del SP_CalculoFiniquito
        'If utilidades > 0 Then
        '    Dim etiquetaValor As DataRow = dtCantidades.NewRow
        '    etiquetaValor.Item("Etiqueta") = "Utilidades proporcionales al " + Year(Now).ToString
        '    etiquetaValor.Item("Valor") = utilidades
        '    dtCantidades.Rows.Add(etiquetaValor)
        'End If

        If utilidadesanterior > 0 And configUtilidades <> 0 Then
            Dim etiquetaValor As DataRow = dtCantidades.NewRow
            etiquetaValor.Item("Etiqueta") = "Utilidades " + (Year(fechaEntrega) - 1).ToString
            etiquetaValor.Item("Valor") = utilidadesanterior
            dtCantidades.Rows.Add(etiquetaValor)
            totalPercepciones = totalPercepciones + CDbl(utilidadesanterior)
        End If

        If utilidadesactual > 0 And configUtilidades <> 0 Then
            Dim etiquetaValor As DataRow = dtCantidades.NewRow
            etiquetaValor.Item("Etiqueta") = "Utilidades proporcionales al " + Year(fechaEntrega).ToString
            etiquetaValor.Item("Valor") = utilidadesactual
            dtCantidades.Rows.Add(etiquetaValor)
            totalPercepciones = totalPercepciones + CDbl(utilidadesactual)
        End If

        If ahorro > 0 Then
            Dim etiquetaValor As DataRow = dtCantidades.NewRow
            etiquetaValor.Item("Etiqueta") = "Caja de Ahorro " + Year(fechaEntrega).ToString
            etiquetaValor.Item("Valor") = ahorro
            dtCantidades.Rows.Add(etiquetaValor)
        End If

        If gratificacion > 0 And configGratificacion <> 0 Then
            Dim etiquetaValor As DataRow = dtCantidades.NewRow
            If (antiguedadanios >= 15) Then
                etiquetaValor.Item("Etiqueta") = "Prima de Antigüedad"
            Else
                etiquetaValor.Item("Etiqueta") = "Gratificación"
            End If
            etiquetaValor.Item("Valor") = gratificacion
            dtCantidades.Rows.Add(etiquetaValor)
            totalPercepciones = totalPercepciones + gratificacion
        End If

        If extras > 0 And configExtras <> 0 Then
            Dim etiquetaValor As DataRow = dtCantidades.NewRow
            etiquetaValor.Item("Etiqueta") = "Extras"
            etiquetaValor.Item("Valor") = extras
            dtCantidades.Rows.Add(etiquetaValor)
            totalPercepciones = totalPercepciones + extras
        End If

        totalPercepciones = Math.Round(totalPercepciones, 0)

        Dim etiquetaTotal = dtCantidades.NewRow
        etiquetaTotal.Item("Etiqueta") = "Total a entregar"
        etiquetaTotal.Item("Valor") = totalPercepciones
        dtCantidades.Rows.Add(etiquetaTotal)

        If vacaciones < 0 Then
            saldoPendiente = saldoPendiente + vacaciones + primaV
        End If

        If Math.Abs(saldoPendiente) > 0 Then
            Dim etiquetaSaldo As DataRow = dtCantidades.NewRow
            etiquetaSaldo.Item("Etiqueta") = "(-) Saldo Pendiente"
            etiquetaSaldo.Item("Valor") = Math.Abs(saldoPendiente)
            totalPercepciones = totalPercepciones + (saldoPendiente)
            dtCantidades.Rows.Add(etiquetaSaldo)
        End If

        If prestamo > 0 Then
            Dim etiquetaValor As DataRow = dtCantidades.NewRow
            etiquetaValor.Item("Etiqueta") = "(-) Saldo de Prestamo"
            etiquetaValor.Item("Valor") = prestamo
            totalPercepciones = totalPercepciones - prestamo
            dtCantidades.Rows.Add(etiquetaValor)
        End If

        If (saldoPendiente > 0 Or prestamo > 0) Then
            etiquetaTotal = dtCantidades.NewRow
            etiquetaTotal.Item("Etiqueta") = "Total a Recibir"
            etiquetaTotal.Item("Valor") = totalPercepciones
            'etiquetaTotal.Item("Valor") = totalentregar
            dtCantidades.Rows.Add(etiquetaTotal)
        End If

        EntidadReporte = OBJBU.LeerReporteporClave("NOM_REP_CARTARENUNCIA2")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()
        reporte("NombreColaborador") = nombreColaborador.ToUpper
        reporte("Patron") = patron.ToUpper
        reporte("Domicilio") = Domicilio.ToUpper
        reporte("Puesto") = puesto.ToUpper
        ''''
        'reporte("Aguinaldo") = CDbl(grdSolicitudes.ActiveRow.Cells("fini_totalaguinaldo").Value)
        'reporte("Vacaciones") = CDbl(grdSolicitudes.ActiveRow.Cells("fini_totalvacaciones").Value)
        'reporte("Prima") = CDbl(grdSolicitudes.ActiveRow.Cells("fini_primavacacional").Value)
        'reporte("CajaAhorro") = CDbl(grdSolicitudes.ActiveRow.Cells("fini_ahorro").Value)
        'reporte("Gratificacion") = CDbl(grdSolicitudes.ActiveRow.Cells("fini_gratificacion").Value)
        'reporte("Utilidades") = CDbl(grdSolicitudes.ActiveRow.Cells("fini_utilidades").Value)
        'Try
        '    reporte("Extras") = CDbl(grdSolicitudes.ActiveRow.Cells("fini_extras").Value)
        'Catch
        '    reporte("Extras") = 0
        'End Try
        '''''''''''



        reporte("fechaEntrega") = fechaEntrega.ToLongDateString
        ultimoDia = objBuNe.ObtenerUltimoDiaTrabajado(grdSolicitudes.ActiveRow.Cells("codr_colaboradorid").Value.ToString, checa)

        horario = objBuNe.consultarHorarioNave(cmbNave.SelectedValue)

        'If cmbNave.SelectedValue = 43 Then
        '    horario = "Lunes a Viernes, de 9:00 hrs. A 14:00 hrs. y de 16:00 hrs. A 19:00 hrs y el Sábado de 9:00 hrs. a 14:00 hrs"
        'Else
        '    horario = "Lunes a Viernes, de 8:00 hrs. A 14:00 hrs. y de 15:00 hrs. A 17:00 hrs y el Sábado de 8:00 hrs. a 13:00 hrs"
        'End If

        reporte("horario") = horario

        'reporte("UltimoDia") = ultimoDia.ToLongDateString -- Cambio solicitado por Administración [2023-04-28]
        reporte("UltimoDia") = CDate(grdSolicitudes.ActiveRow.Cells("fini_fechabaja").Value).ToLongDateString
        reporte("Prestamos") = CDbl(grdSolicitudes.ActiveRow.Cells("fini_prestamo").Value)
        reporte("Total") = CDbl(totalPercepciones)
        'reporte("Total") = CDbl(grdSolicitudes.ActiveRow.Cells("fini_totalentregar").Value)
        Dim tool As New Tools.Controles
        Dim TotalLetra As String = totalPercepciones.ToString.Replace(".0000", "")
        ' + "(" + tool.EnLetras(grdSolicitudes.ActiveRow.Cells("fini_totalentregar").Value.ToString).ToUpper + " PESOS 00/100 M.N.) "
        TotalLetra = "$" + CDbl(TotalLetra).ToString("#,###") + " (" + tool.EnLetras(TotalLetra).ToUpper + " PESOS 00/100 M.N.) "
        reporte("TotalLetra") = TotalLetra
        reporte.RegData(dtCantidades)
        reporte.Dictionary.Clear()
        reporte.Dictionary.Synchronize()
        reporte.Show()

    End Sub































































    Private Sub ReporteFiniquitoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteFiniquitoToolStripMenuItem.Click

        Try
            imprimirReporte()
        Catch ex As Exception
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "Intente exportar nuevamente." & ex.Message
            objMensaje.ShowDialog()
        End Try
    End Sub

    Private Sub chkXFechas_CheckedChanged(sender As Object, e As EventArgs) Handles chkXFechas.CheckedChanged
        grdSolicitudes.DataSource = Nothing
    End Sub

    Private Sub cmbPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPeriodo.SelectedIndexChanged
        grdSolicitudes.DataSource = Nothing
    End Sub

    Private Sub dttInicio_ValueChanged(sender As Object, e As EventArgs) Handles dttInicio.ValueChanged
        grdSolicitudes.DataSource = Nothing
    End Sub

    Private Sub dttFin_ValueChanged(sender As Object, e As EventArgs) Handles dttFin.ValueChanged
        grdSolicitudes.DataSource = Nothing
    End Sub

    Private Sub rdoRango_CheckedChanged(sender As Object, e As EventArgs) Handles rdoRango.CheckedChanged
        grdSolicitudes.DataSource = Nothing
    End Sub

    Private Sub rdoPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPeriodo.CheckedChanged
        grdSolicitudes.DataSource = Nothing
    End Sub

    Private Sub btnEntregarDireccion_Click(sender As Object, e As EventArgs) Handles btnEntregarDireccion.Click
        Dim CountAcept As Int32 = 0
        For Each row As UltraGridRow In grdSolicitudes.Rows
            If CBool(row.Cells("Seleccion").Value) = True And row.Cells("fini_estado").Value = "F" Then
                CountAcept += 1
            End If
        Next
        If CountAcept > 0 Then
            Dim objMensaje As New Tools.ConfirmarForm
            objMensaje.mensaje = "¿Está seguro de cambiar el estatus a entregado a dirección?"
            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                entregarDireccion()
                EntregarReciboDireccion()
                Me.Cursor = Cursors.Default
                llenarTablaSolicitudes()

            End If
        Else
            Dim FormaExito As New AdvertenciaForm
            FormaExito.mensaje = "Debe seleccionar un finiquito cuyo estado sea RECIBIDO DE CAJA CHICA"
            FormaExito.ShowDialog()
        End If
    End Sub

    Private Sub ConcentradoLiquidacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConcentradoLiquidacionesToolStripMenuItem.Click
        Try
            imprimirConcentradoUtilidades()
        Catch ex As Exception
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = "Intente generarlo nuevamente"
            advertencia.ShowDialog()
        End Try
    End Sub

    Public Sub imprimirConcentradoUtilidades()
        If chkXFechas.Checked = True Then
            Dim OBJBU As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            Dim objFiBU As New Negocios.FiniquitosBU
            Dim dtConcentrado As New DataTable

            EntidadReporte = OBJBU.LeerReporteporClave("CONCENTRADO_LIQUIDACIONES")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport
            reporte.Load(archivo)
            reporte.Compile()
            reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
            reporte("nombreReporte") = "SAY: CONCENTRADO_LIQUIDACIONES.mrt"
            reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
            reporte("elaboro") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString.ToUpper

            dtConcentrado = objFiBU.imprimirReporteConcentradoLiquidaciones(dttInicio.Value.ToShortDateString, dttFin.Value.ToShortDateString, cmbNave.SelectedValue, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

            reporte.Dictionary.Clear()
            reporte.RegData(dtConcentrado)
            reporte.Dictionary.Synchronize()
            reporte.Show()
        Else
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "Es necesario seleccionar filtro por fechas."
            objMensaje.ShowDialog()
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel(grdSolicitudes)
    End Sub

    Public Sub exportarExcel(ByVal grd As UltraGrid)
        Dim sfd As New SaveFileDialog

        If IsNothing(grd) = False Then
            If grd.Rows.Count = 0 Then
                show_message("Advertencia", "No hay información para exportar a excel.")
                Return
            End If
        End If


        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                UltraGridExcelExporter1.Export(grd, fileName)
                show_message("Exito", "El archivo se ha exportado correctamente en la ruta " + fileName)
                Process.Start(fileName)
                Me.Cursor = Cursors.Default


            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try
        End If
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub EntregarReciboDireccion()
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim entReporte As New Entidades.Reportes
        entReporte = objReporte.LeerReporteporClave("NOM_RECB_ENTREGAR_A_DIRECCION")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + entReporte.Pnombre + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)
        Dim reporte As New StiReport

        Dim nombrecolaborador As String = ""
        Dim cantidad As Double = 0
        Dim estatus As String = ""
        Dim nombreNave As String = ""
        Dim idNave As Int32 = cmbNave.SelectedValue

        For Each row As UltraGridRow In grdSolicitudes.Rows.GetAllNonGroupByRows
            If CBool(row.Cells("Seleccion").Value) = True Then
                ' If grdSolicitudes.Rows.Count > 0 Then
                nombrecolaborador = row.Cells("Colaborador").Value
                cantidad = CDbl(row.Cells("fini_totalentregar").Value)
                estatus = "ENTREGADO A NAVE"
                nombreNave = cmbNave.Text
            End If
        Next

        reporte.Load(archivo)
        reporte.Compile()
        reporte("NombreColaborador") = nombrecolaborador
        reporte("Cantidad") = cantidad
        reporte("Estatus") = estatus
        reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(idNave)
        reporte("Nave") = nombreNave
        reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString.ToUpper
        reporte("NbUsuarioReal") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        reporte("NumSemana") = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)

        reporte.Dictionary.Clear()
        reporte.Dictionary.Synchronize()
        reporte.Show()


    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub btnNoEntragada_Click(sender As Object, e As EventArgs) Handles btnNoEntragada.Click
        Dim CountAcept As Int32 = 0
        Dim dtValidaSolicitudCaja As New DataTable
        Dim NaveID As Integer = 0
        Dim PasaValidacion As Integer = 0
        Dim objBu As New Negocios.FiniquitosBU
        Dim advertencia As New AdvertenciaForm
        Dim dtCambiaEstatus As New DataTable
        Dim exito As New ExitoForm

        NaveID = cmbNave.SelectedValue


        For Each row As UltraGridRow In grdSolicitudes.Rows
            If CBool(row.Cells("Seleccion").Value) = True Then
                dtValidaSolicitudCaja = objBu.ValidaSolicitudCaja(row.Cells("fini_finiquitoid").Value)
                CountAcept += 1
            End If
        Next

        For Each fila As DataRow In dtValidaSolicitudCaja.Rows
            PasaValidacion = dtValidaSolicitudCaja.Rows(0).Item("Solicitar")
        Next
        If PasaValidacion = 0 Then
            CountAcept += 1
        Else
            advertencia.mensaje = "Finiquito no entra dentro en criterio de No Entregada."
            advertencia.ShowDialog()
        End If

        If CountAcept > 0 Then
            Dim objMensaje As New Tools.ConfirmarForm
            objMensaje.mensaje = "¿Está seguro de cambiar el estatus a Liquidaciones No Entregadas?"
            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                Dim vXmlCeldas As XElement = New XElement("Celdas")
                For Each row As UltraGridRow In grdSolicitudes.Rows
                    Dim vNodo As XElement = New XElement("Celda")
                    vNodo.Add(New XAttribute("PFiniquitoID", row.Cells("fini_finiquitoid").Value))
                    vXmlCeldas.Add(vNodo)
                Next

                dtCambiaEstatus = objBu.CambiarEstatusLiquidacionNoEntregada(vXmlCeldas.ToString())
                exito.mensaje = "Se cambió el estatus a No Entregada."
                exito.ShowDialog()

                Me.Cursor = Cursors.Default
                llenarTablaSolicitudes()
            End If
        Else
            Dim FormaExito As New AdvertenciaForm
            FormaExito.mensaje = "Debe seleccionar un finiquito que cumpla los criterios del estatus No Entregada"
            FormaExito.ShowDialog()

        End If
    End Sub

    Private Sub ReporteLiquidaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteFiniquito2ToolStripMenuItem.Click
        Try
            imprimirReporte()
        Catch ex As Exception
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "Intente exportar nuevamente." & ex.Message
            objMensaje.ShowDialog()
        End Try
    End Sub
End Class