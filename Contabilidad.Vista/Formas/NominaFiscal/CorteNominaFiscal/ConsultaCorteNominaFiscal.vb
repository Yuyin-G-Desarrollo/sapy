Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Stimulsoft.Report
Imports Tools
Imports Framework.Negocios

Public Class ConsultaCorteNominaFiscal
    Dim manejaComisiones As Boolean = False
    Dim manejaPremios As Boolean = False

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        gpbFiltro.Height = 40
        grdCorteNomina.Height = 471
        grdCorteNomina.Top = 115
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        gpbFiltro.Height = 99
        grdCorteNomina.Height = 346
        grdCorteNomina.Top = 240
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiarSolicitudes_Click(sender As Object, e As EventArgs) Handles btnLimpiarSolicitudes.Click
        limpiarCampos()
    End Sub

    Public Sub limpiarCampos()
        grdCorteNomina.DataSource = Nothing
        txtNombre.Text = ""
        cmbPeriodo.SelectedIndex = 0
        cmbPatron.SelectedIndex = 0

    End Sub

    Public Sub mostrarCorte()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim objBu As New Negocios.CorteNominaFiscalBU
            Dim dtCorte As New DataTable
            grdCorteNomina.DataSource = Nothing

            If cmbPatron.SelectedIndex > 0 Then
                dtCorte = objBu.consultaCorteNomina(cmbPeriodo.SelectedValue, cmbPatron.SelectedValue, txtNombre.Text)
            End If

            If dtCorte.Rows.Count > 0 Then
                grdCorteNomina.DataSource = dtCorte
                obtieneConfiguracionPatron()
                formatoGrid()
                'EncabezadoGridNomina(grdCorteNomina)
            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Public Sub obtieneConfiguracionPatron()
        Dim objBu As New Negocios.CorteNominaFiscalBU
        Dim dtConfig As New DataTable
        dtConfig = objBu.obtenerConfiguracionPatron(cmbPatron.SelectedValue)

        If Not dtConfig Is Nothing AndAlso dtConfig.Rows.Count > 0 Then
            manejaComisiones = dtConfig.Rows(0).Item("patr_manejaComisiones")
            manejaPremios = dtConfig.Rows(0).Item("manejaPremios")
        End If

    End Sub

    Public Sub cargarComboEmpresaPatron()
        Dim objBu As New Contabilidad.Negocios.UtileriasBU
        Dim dtEmpresa As New DataTable

        dtEmpresa = objBu.consultarPatronEmpresa()
        If dtEmpresa.Rows.Count > 0 Then
            If dtEmpresa.Rows.Count = 1 Then
                Dim dtRow As DataRow = dtEmpresa.NewRow
                dtRow("ID") = 0
                dtRow("PATRON") = ""
                dtEmpresa.Rows.InsertAt(dtRow, 0)

                cmbPatron.DataSource = dtEmpresa
                cmbPatron.DisplayMember = "Patron"
                cmbPatron.ValueMember = "ID"

                cmbPatron.SelectedIndex = 1
            Else
                cmbPatron.DataSource = dtEmpresa
                cmbPatron.DisplayMember = "Patron"
                cmbPatron.ValueMember = "ID"
            End If

        End If
    End Sub

    Private Sub llenarComboPeriodo()
        Dim objMensajeError As New Tools.AdvertenciaForm
        Try
            cmbPeriodo.DataSource = Nothing
            If cmbPatron.SelectedValue > 0 Then
                Dim objBU As New Negocios.ControlAsistenciaBU
                Dim dtListado As New DataTable

                dtListado = objBU.consultarPeriodoNomina(CInt(cmbPatron.SelectedValue.ToString))
                If Not dtListado Is Nothing Then
                    If dtListado.Rows.Count > 0 Then
                        cmbPeriodo.DataSource = dtListado
                        cmbPeriodo.ValueMember = "ID"
                        cmbPeriodo.DisplayMember = "DESCRIPCION"
                        cmbPeriodo.SelectedValue = objBU.obtenerPeriodoNominaActual(CInt(cmbPatron.SelectedValue.ToString))
                    Else
                        objMensajeError.mensaje = "No hay periodos de nómina para la empresa seleccionada."
                        objMensajeError.ShowDialog()
                    End If
                Else
                    objMensajeError.mensaje = "No hay periodos de nómina para la empresa seleccionada."
                    objMensajeError.ShowDialog()
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al consultar los periodos de nómina"
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub cmbPatron_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPatron.SelectedIndexChanged
        If cmbPatron.SelectedIndex > 0 Then
            grdCorteNomina.DataSource = Nothing
            llenarComboPeriodo()
        End If


    End Sub

    Private Sub ConsultaCorteNominaFiscal_Load(sender As Object, e As EventArgs) Handles Me.Load
        WindowState = FormWindowState.Maximized
        cargarComboEmpresaPatron()
        configurarPermisosBotonesEspeciales()
    End Sub

    Private Sub btnFiltrarSolicitud_Click(sender As Object, e As EventArgs) Handles btnFiltrarSolicitud.Click
        mostrarCorte()
    End Sub

    Public Sub formatoGrid()
        With grdCorteNomina.DisplayLayout.Bands(0)

            '.Columns("idColaborador").Hidden = True
            '.Columns("idAlta").Hidden = True
            '.Columns("estatus").Hidden = True
            '.Columns("curp").Hidden = True
            '.Columns("sdi").Hidden = True
            '.Columns("diasAntiguedad").Hidden = True

            .Columns("Row").Hidden = True
            .Columns("duracion").Hidden = True
            .Columns("folioFiscal").Hidden = True
            .Columns("retencionImss").Hidden = True


            .Columns("premioAsis").Hidden = Not manejaPremios
            .Columns("premioPunt").Hidden = Not manejaPremios
            .Columns("Comisiones").Hidden = Not manejaComisiones


            '.Columns("Row").Header.Caption = "No."
            .Columns("clave").Header.Caption = "Clave"
            .Columns("nombre").Header.Caption = "Nombre del trabajador"
            .Columns("nss").Header.Caption = "NSS"
            .Columns("rfc").Header.Caption = "RFC"
            .Columns("curp").Header.Caption = "CURP"
            .Columns("fechaIngeso").Header.Caption = "Fecha de ingreso"
            '.Columns("duracion").Header.Caption = "Duración Jornada"
            .Columns("sbc").Header.Caption = "SBC"
            .Columns("factor").Header.Caption = "Factor integración"
            .Columns("salarioDiario").Header.Caption = "Sueldo Diario"
            .Columns("diasTrabajados").Header.Caption = "Días trabajados"
            .Columns("diasInc").Header.Caption = "Días de incapacidad"
            .Columns("diasAu").Header.Caption = "Días de ausentismo"
            .Columns("retardos").Header.Caption = "Retardos"
            .Columns("diasPagados").Header.Caption = "Días Pagados"

            .Columns("salarioSemanal").Header.Caption = "001" & Environment.NewLine & "Sueldo semanal"
            .Columns("septimoDia").Header.Caption = "001" & Environment.NewLine & "Septimo Día"
            .Columns("premioAsis").Header.Caption = "049" & Environment.NewLine & "Premio de asistencia"
            .Columns("premioPunt").Header.Caption = "010" & Environment.NewLine & "Premio de puntualidad"
            .Columns("Comisiones").Header.Caption = "028" & Environment.NewLine & "Comisiones"
            .Columns("totalPercepciones").Header.Caption = "Total " & Environment.NewLine & "Percepciones"

            .Columns("spe").Header.Caption = "002" & Environment.NewLine & "SPE"
            .Columns("ajusteisrxspe").Header.Caption = "007" & Environment.NewLine & "ISR Ajustado" & Environment.NewLine & "por SPE"
            .Columns("ajustespepagado").Header.Caption = "008" & Environment.NewLine & "Subsidio que no" & Environment.NewLine & "correspondía entregar"
            .Columns("otrosPagos").Header.Caption = "Otros Pagos"
            .Columns("compensacionafavor").Header.Caption = "004 " & Environment.NewLine & "Compensación de" & Environment.NewLine & "Saldo a Favor"
            .Columns("TotalOtrosPagos").Header.Caption = "Total" & Environment.NewLine & "Otros Pagos"

            .Columns("retencionImssDetalle").Header.Caption = "001" & Environment.NewLine & "Retención IMSS"
            .Columns("retencionAfore").Header.Caption = "003" & Environment.NewLine & "Retención Afore"
            '.Columns("retencionImss").Header.Caption = "Retención IMSS"
            .Columns("infonavit").Header.Caption = "010" & Environment.NewLine & "Retención INFONAVIT"
            .Columns("ajustespe").Header.Caption = "071" & Environment.NewLine & "Ajuste en Subsidio" & Environment.NewLine & "para el Empleo"
            .Columns("ajustespecausado").Header.Caption = "107" & Environment.NewLine & "Ajuste al" & Environment.NewLine & "Subsidio Causado"
            .Columns("totalDed").Header.Caption = "Total" & Environment.NewLine & "Deducciones"

            .Columns("retencionanualISR").Header.Caption = "101" & Environment.NewLine & "Retención" & Environment.NewLine & "ISR Anual"
            .Columns("isr").Header.Caption = "002" & Environment.NewLine & "Retención" & Environment.NewLine & "ISR"
            .Columns("ajusteisrnoretenido").Header.Caption = "002" & Environment.NewLine & "Retención ISR por" & Environment.NewLine & "Ajuste de Subsidio"
            .Columns("totalRet").Header.Caption = "Total" & Environment.NewLine & "Retenciones"

            .Columns("neto").Header.Caption = "Sueldo Neto"

            '.Columns("Row").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("clave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("rfc").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("curp").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fechaIngeso").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("nss").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("sbc").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("factor").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("salarioDiario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("diasTrabajados").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("diasInc").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("diasAu").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("retardos").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("diasPagados").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("salarioSemanal").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("septimoDia").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Comisiones").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("premioAsis").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("premioPunt").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("totalPercepciones").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("spe").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ajusteisrxspe").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ajustespepagado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("otrosPagos").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("compensacionafavor").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("TotalOtrosPagos").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("retencionImssDetalle").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("retencionAfore").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("retencionImss").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("infonavit").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ajustespe").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ajustespecausado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("totalDed").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("retencionanualISR").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("isr").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ajusteisrnoretenido").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("totalRet").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("neto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Obra").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("sbc").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("factor").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("salarioDiario").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            '.Columns("row").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("diasTrabajados").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("diasInc").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("diasAu").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("retardos").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("diasPagados").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("salarioSemanal").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("septimoDia").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Comisiones").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("premioAsis").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("premioPunt").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("totalPercepciones").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("spe").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ajusteisrxspe").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ajustespepagado").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("otrosPagos").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("compensacionafavor").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("TotalOtrosPagos").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("retencionImssDetalle").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("retencionAfore").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            '.Columns("retencionImss").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("infonavit").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ajustespe").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ajustespecausado").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("totalDed").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("retencionanualISR").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("isr").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ajusteisrnoretenido").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("totalRet").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("neto").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right


            .Columns("sbc").Format = "###,###,##0.00"
            '.Columns("factor").Format = "###,###,##0.00"
            .Columns("salarioDiario").Format = "###,###,##0.00"
            .Columns("salarioSemanal").Format = "###,###,##0.00"
            .Columns("septimoDia").Format = "###,###,##0.00"
            .Columns("Comisiones").Format = "###,###,##0.00"
            .Columns("premioAsis").Format = "###,###,##0.00"
            .Columns("premioPunt").Format = "###,###,##0.00"
            .Columns("totalPercepciones").Format = "###,###,##0.00"

            .Columns("spe").Format = "###,###,##0.00"
            .Columns("ajusteisrxspe").Format = "###,###,##0.00"
            .Columns("ajustespepagado").Format = "###,###,##0.00"
            .Columns("otrosPagos").Format = "###,###,##0.00"

            .Columns("compensacionafavor").Format = "###,###,##0.00"
            .Columns("TotalOtrosPagos").Format = "###,###,##0.00"

            .Columns("retencionImssDetalle").Format = "###,###,##0.00"
            .Columns("retencionAfore").Format = "###,###,##0.00"
            '.Columns("retencionImss").Format = "###,###,##0.00"
            .Columns("infonavit").Format = "###,###,##0.00"
            .Columns("ajustespe").Format = "###,###,##0.00"
            .Columns("ajustespecausado").Format = "###,###,##0.00"
            .Columns("totalDed").Format = "###,###,##0.00"

            .Columns("retencionanualISR").Format = "###,###,##0.00"
            .Columns("isr").Format = "###,###,##0.00"
            .Columns("ajusteisrnoretenido").Format = "###,###,##0.00"
            .Columns("totalRet").Format = "###,###,##0.00"

            .Columns("neto").Format = "###,###,##0.00"

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

        End With

        Dim sumuno As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("salarioSemanal"))
        Dim sumSeptimo As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("septimoDia"))
        Dim sumComisiones As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("Comisiones"))
        Dim sumdos As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("premioAsis"))
        Dim sumtres As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("premioPunt"))
        Dim sumtotp As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("totalPercepciones"))

        Dim sumspe As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("spe"))
        Dim sumajusteisrxspe As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("ajusteisrxspe"))
        Dim sumajustespepagado As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("ajustespepagado"))
        Dim sumotrosPagos As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("otrosPagos"))
        Dim sumafavor As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("compensacionafavor"))
        Dim sumTotrosPagos As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("TotalOtrosPagos"))

        Dim sumimssDetalle As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("retencionImssDetalle"))
        Dim sumAfore As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("retencionAfore"))
        'Dim sumimss As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("retencionImss"))
        Dim suminofo As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("infonavit"))
        Dim sumajspe As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("ajustespe"))
        Dim sumajspec As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("ajustespecausado"))
        Dim sumtotD As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("totalDed"))


        Dim sumisranual As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("retencionanualISR"))
        Dim sumisr As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("isr"))
        Dim sumisrnoret As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("ajusteisrnoretenido"))
        Dim sumtotret As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("totalRet"))

        Dim sumTotal As SummarySettings = grdCorteNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdCorteNomina.DisplayLayout.Bands(0).Columns("neto"))


        sumuno.DisplayFormat = "{0:#,##0}"
        sumuno.Appearance.TextHAlign = HAlign.Right
        sumSeptimo.DisplayFormat = "{0:#,##0}"
        sumSeptimo.Appearance.TextHAlign = HAlign.Right
        sumComisiones.DisplayFormat = "{0:#,##0}"
        sumComisiones.Appearance.TextHAlign = HAlign.Right
        sumdos.DisplayFormat = "{0:#,##0}"
        sumdos.Appearance.TextHAlign = HAlign.Right
        sumtres.DisplayFormat = "{0:#,##0}"
        sumtres.Appearance.TextHAlign = HAlign.Right
        sumspe.DisplayFormat = "{0:#,##0}"
        sumspe.Appearance.TextHAlign = HAlign.Right
        sumotrosPagos.DisplayFormat = "{0:#,##0}"
        sumotrosPagos.Appearance.TextHAlign = HAlign.Right
        sumtotp.DisplayFormat = "{0:#,##0}"
        sumtotp.Appearance.TextHAlign = HAlign.Right
        sumisr.DisplayFormat = "{0:#,##0}"
        sumisr.Appearance.TextHAlign = HAlign.Right

        sumimssDetalle.DisplayFormat = "{0:#,##0}"
        sumimssDetalle.Appearance.TextHAlign = HAlign.Right
        sumAfore.DisplayFormat = "{0:#,##0}"
        sumAfore.Appearance.TextHAlign = HAlign.Right

        sumajusteisrxspe.DisplayFormat = "{0:#,##0}"
        sumajusteisrxspe.Appearance.TextHAlign = HAlign.Right
        sumajustespepagado.DisplayFormat = "{0:#,##0}"
        sumajustespepagado.Appearance.TextHAlign = HAlign.Right
        sumafavor.DisplayFormat = "{0:#,##0}"
        sumafavor.Appearance.TextHAlign = HAlign.Right
        sumTotrosPagos.DisplayFormat = "{0:#,##0}"
        sumTotrosPagos.Appearance.TextHAlign = HAlign.Right

        'sumimss.DisplayFormat = "{0:#,##0}"
        'sumimss.Appearance.TextHAlign = HAlign.Right
        suminofo.DisplayFormat = "{0:#,##0}"
        suminofo.Appearance.TextHAlign = HAlign.Right
        sumtotD.DisplayFormat = "{0:#,##0}"
        sumtotD.Appearance.TextHAlign = HAlign.Right
        sumTotal.DisplayFormat = "{0:#,##0}"
        sumTotal.Appearance.TextHAlign = HAlign.Right
        sumTotal.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

        sumtotret.DisplayFormat = "{0:#,##0}"
        sumtotret.Appearance.TextHAlign = HAlign.Right
        sumisrnoret.DisplayFormat = "{0:#,##0}"
        sumisrnoret.Appearance.TextHAlign = HAlign.Right
        sumisranual.DisplayFormat = "{0:#,##0}"
        sumisranual.Appearance.TextHAlign = HAlign.Right

        sumajspec.DisplayFormat = "{0:#,##0}"
        sumajspec.Appearance.TextHAlign = HAlign.Right
        sumajspe.DisplayFormat = "{0:#,##0}"
        sumajspec.Appearance.TextHAlign = HAlign.Right

        grdCorteNomina.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"

        'grdCorteNomina.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        'grdCorteNomina.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdCorteNomina.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdCorteNomina.DisplayLayout.Override.RowSelectorWidth = 35
        grdCorteNomina.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        'grdCorteNomina.Rows(0).Selected = True

        'grdCorteNomina.DisplayLayout.Bands(0).Columns("Row").Width = 40
        grdCorteNomina.DisplayLayout.Bands(0).Columns("clave").Width = 45
        'grdSolicitudes.DisplayLayout.Bands(0).Columns("SemanaEntrega").Width = 50
        'grdSolicitudes.DisplayLayout.Bands(0).Columns("SemanaBaja").Width = 50

        grdCorteNomina.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Private Sub EncabezadoGridNomina(ByVal grid As UltraGrid)
        'GUARDAMOS EL DISEÑO Y LA BANDA EN VARIABLES PARA HACER REFERENCIA A ELLOS MAS FACIL 
        Dim Layout As UltraGridLayout = grid.DisplayLayout
        Dim rootBand As UltraGridBand = Layout.Bands(0)

        rootBand.RowLayoutStyle = RowLayoutStyle.GroupLayout

        'FOR PARA AGREGAR LOS RESPECTIVOS GRUPOS 
        For n = 2 To rootBand.Columns.Count - 1 Step 1


            If (n < 16) Or (n > 22 And n < 24) Or (n > 27 And n < 32 And n <> 28) Then
                Dim grupo As UltraGridGroup = rootBand.Groups.Add(rootBand.Columns(n).Header.Caption, " ")
                rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = grupo
                'If n = 2 Or n = 3 Then
                '    If ProspectaID = -1 Then
                '        grupo.Hidden = True
                '    End If
                'End If
            Else
                If n >= 16 And n <= 22 Then
                    If n = 16 Then
                        Dim NombreColumna As String
                        NombreColumna = "PERCEPCIONES"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        'Grupo.CellAppearance.ForeColor = Color.Purple
                        'Grupo.CellAppearance.BorderColor = Color.Black

                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo

                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("PERCEPCIONES")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If



                ElseIf n >= 24 And n <= 28 Then
                    If n = 24 Then
                        Dim NombreColumna As String
                        NombreColumna = "DEDUCCIONES"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        'Grupo.CellAppearance.ForeColor = Color.Purple
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo

                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("DEDUCCIONES")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                End If
            End If
        Next
    End Sub

    Private Sub txtNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyDown
        If (e.KeyValue = Keys.Enter) Then
            mostrarCorte()
        End If
    End Sub

    Private Sub ReporteNóminaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteNóminaToolStripMenuItem.Click
        Try
            imprimirReporteNomina()
        Catch ex As Exception
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "Intente exportar nuevamente."
            objMensaje.ShowDialog()
        End Try
    End Sub

    Public Sub imprimirReporteNomina()
        If cmbPeriodo.SelectedValue > 0 Then

            Dim objBuV As New Negocios.CorteNominaFiscalBU
            Dim existenTimbres As Boolean = False


            existenTimbres = objBuV.validaTimbreFiscalesCompletos(cmbPeriodo.SelectedValue)

            If existenTimbres Then
                Dim mensajeConfirmar As New ConfirmarForm
                mensajeConfirmar.mensaje = "Existen recibos que aún falta timbrar. ¿Desea generar el reporte de nómina? "
                If mensajeConfirmar.ShowDialog = DialogResult.OK Then
                    imprimirReporte()
                End If
            Else
                imprimirReporte()
            End If


        Else
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "Es necesario seleccionar filtro de periodo."
            objMensaje.ShowDialog()
        End If
    End Sub

    Public Sub imprimirReporte()
        Dim dtCorte As New DataTable
        Dim objBuC As New Negocios.CorteNominaFiscalBU
        Dim periodo As String = String.Empty
        Dim empresa As String = String.Empty
        Dim rfc As String = String.Empty
        Dim regPatronal As String = String.Empty
        Dim domicilio As String = String.Empty
        Dim arrendamiento As Boolean = False

        Try
            Me.Cursor = Cursors.WaitCursor
            dtCorte = objBuC.consultaCorteNomina(cmbPeriodo.SelectedValue, cmbPatron.SelectedValue, "")

            If dtCorte.Rows.Count > 0 Then

                objBuC = New Negocios.CorteNominaFiscalBU
                Dim dtDatosEmpresa = objBuC.datosEmpresa(cmbPeriodo.SelectedValue, cmbPatron.SelectedValue)
                If dtDatosEmpresa.Rows.Count > 0 Then
                    periodo = dtDatosEmpresa.Rows(0).Item("periodo")
                    empresa = dtDatosEmpresa.Rows(0).Item("empresa")
                    regPatronal = dtDatosEmpresa.Rows(0).Item("regPatronal")
                    rfc = dtDatosEmpresa.Rows(0).Item("rfc")
                    domicilio = dtDatosEmpresa.Rows(0).Item("domicilio")
                    arrendamiento = CBool(dtDatosEmpresa.Rows(0).Item("arrendamiento"))
                End If

                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                Dim cveReporte As String = String.Empty

                If arrendamiento Then
                    If manejaComisiones Then
                        cveReporte = "REP_CORTENOMINA_ARR_COM"
                    Else
                        cveReporte = "REP_CORTENOMINA_ARR"
                    End If
                Else
                    If manejaComisiones And Not manejaPremios Then
                        cveReporte = "REP_CORTENOMINA_COM"
                    ElseIf manejaComisiones And manejaPremios Then
                        cveReporte = "REP_CORTENOMINA_CP"
                    Else
                        cveReporte = "REP_CORTENOMINA"
                    End If

                End If
                EntidadReporte = OBJBU.LeerReporteporClave(cveReporte)
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                reporte("Empresa") = empresa
                reporte("rfc") = rfc
                reporte("regPatronal") = regPatronal
                reporte("domicilioFiscal") = domicilio
                reporte("periodo") = periodo
                reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername

                reporte.Dictionary.Clear()
                reporte.RegData(dtCorte)
                reporte.Dictionary.Synchronize()
                reporte.Show()

            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al intentar imprimir el reporte.")
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ContextMenuStrip1.Show(btnImprimir, 0, btnImprimir.Height)
    End Sub

    Public Sub exportarExcel()
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim exito As New ExitoForm
        Dim ruta As String = String.Empty

        nombreDocumento = "\NF_" + Replace(cmbPeriodo.Text, "/", "-")
        grid = grdCorteNomina

        With fbdUbicacionArchivo

            .Reset()
            .Description = " Seleccione una carpeta "
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True

            Dim ret As DialogResult = .ShowDialog

            If ret = Windows.Forms.DialogResult.OK Then
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                'ruta = .SelectedPath + nombreDocumento + fecha_hora + ".xlsx"
                ruta = .SelectedPath + nombreDocumento + ".xlsx"

                gridExcelExporter.Export(grid, ruta)

                exito.mensaje = "Los datos se exportaron correctamente"
                exito.ShowDialog()
                .Dispose()
            End If

        End With
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel()
    End Sub

    Public Sub configurarPermisosBotonesEspeciales()
        If PermisosUsuarioBU.ConsultarPermiso("CIERRE_NF", "CNF_IMPRIMIR") Then
            pnlImprimir.Visible = True
        Else
            pnlImprimir.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("CIERRE_NF", "CNF_EXPORTAR") Then
            pnlExportar.Visible = True
        Else
            pnlExportar.Visible = False
        End If

    End Sub


End Class