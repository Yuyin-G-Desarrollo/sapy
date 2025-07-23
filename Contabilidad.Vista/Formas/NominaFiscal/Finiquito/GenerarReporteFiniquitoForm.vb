Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Linq
Imports System.Data
Imports System.Data.DataTable
Imports System.Data.DataSet
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports Stimulsoft.Report
Imports Framework.Negocios

Public Class GenerarReporteFiniquitoForm

    Public NaveId As Integer = -1
    Dim EmpresaID As Integer
    Dim EstatusID As Integer


    Private Sub GenerarReporteFiniquitoForm_Load(sender As Object, e As EventArgs) Handles Me.Load        
        CargarNAves()
        CargarEstatusBaja()
        If NaveId <> -1 Then
            cmbNave.SelectedValue = NaveId
            CargarFiniquitos()
        End If
        dtmRangoFechaAl.Value = Now
        dtmRangoFechaDel.Value = Now
    End Sub

    Private Sub configuracionBotones()
        If PermisosUsuarioBU.ConsultarPermiso("CONSOLBAJA_CONTA", "SOL_IMPRIMIRREPORTE") Then
            pnlImprimirReporte.Visible = True
        Else
            pnlImprimirReporte.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("CONSOLBAJA_CONTA", "SOL_EXPORTARREPORTE") Then
            pnlExportarReporte.Visible = True
        Else
            pnlExportarReporte.Visible = False
        End If
    End Sub

    Private Sub CargarFiniquitos()
        Dim LNaveID As Integer = cmbNave.SelectedValue
        Dim LEmpresa As Integer = cmbEmpresa.SelectedValue
        Dim LEstatus As Integer = cmbEstatus.SelectedValue
        Dim LNombre As String = txtNombre.Text
        Dim LEsFechaBaja As Boolean = rdoFechaBaja.Checked
        Dim LFiltroFechas As Boolean = chkFiltroFechas.Checked
        Dim LFechaInicio As Date = dtmRangoFechaDel.Value
        Dim LFechaFin As Date = dtmRangoFechaAl.Value
        Dim LPeriodoId As Integer = cmbPeriodo.SelectedValue
        Dim LEsFechaTRango As Boolean = rdoRango.Checked

        If LNaveID = 0 Then
            LNaveID = -1
        End If

        If LEmpresa = 0 Then
            LEmpresa = -1
        End If

        NaveId = LNaveID
        EmpresaID = LEmpresa
        EstatusID = LEstatus



        Dim ObjListaFinquitos As New Contabilidad.Negocios.FiniquitoFiscalBU
        grdReporteFiniquito.DataSource = Nothing
        gridDiseno(grdReporteFiniquito)
        grdReporteFiniquito.DataSource = ObjListaFinquitos.ConsultarFiniquitos(LNaveID, LEstatus, LNombre, LEsFechaBaja, LFiltroFechas, LEsFechaTRango, LFechaInicio.ToShortDateString + " 00:00", LFechaFin.ToShortDateString + " 23:59", LPeriodoId, LEmpresa)

        'ConsultarFiniquitos
    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnFiltrarSolicitud_Click(sender As Object, e As EventArgs) Handles btnFiltrarSolicitud.Click
        If cmbNave.SelectedIndex > 0 Then
            CargarFiniquitos()
            lblNave.ForeColor = Color.Black
        Else
            show_message("Advertencia", "Se debe de seleccionar una nave")
            lblNave.ForeColor = Color.Red
            grdReporteFiniquito.DataSource = Nothing
        End If

    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If grdReporteFiniquito.Rows.Count > 0 Then
            exportarExcel(grdReporteFiniquito)
        Else
            show_message("Advertencia", "No hay información para exportar")
        End If
    End Sub

    Public Sub exportarExcel(ByVal grd As UltraGrid)
        Dim sfd As New SaveFileDialog
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

    Public Function show_message(ByVal tipo As String, ByVal mensaje As String) As DialogResult
        Dim ResultadoDialogo As DialogResult

        If tipo.ToString.Equals("Advertencia") Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then
            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            ResultadoDialogo = mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            ResultadoDialogo = mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        Return ResultadoDialogo
    End Function

    Private Sub AgregarColumna(ByRef grid As UltraGrid, ByVal Key As String, ByVal NombreColumna As String, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, ByVal ColorColumna As Color, Optional ByVal Width As Integer = -1, Optional ByVal SumarizarColumna As Boolean = False, Optional ByVal Edicion As Boolean = False, Optional ByVal Alineacion As HAlign = Nothing, Optional ByVal NEgrita As Boolean = False, Optional ByVal EsPorcentaje As Boolean = False, Optional ByVal Tooltip As String = "")
        With grid
            .DisplayLayout.Bands(0).Columns.Add(Key, NombreColumna)
            FormatoColumna(.DisplayLayout.Bands(0).Columns(Key), Ocultar, EsCadena, Width, EsPorcentaje)
            If IsNothing(ColorColumna) Then
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = Color.Black
            Else
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = ColorColumna
            End If
            If SumarizarColumna = True Then
                SumarizarColumnaGrid(grid, Key, "Sumarizar " + Key)
            End If
            If Tooltip <> "" Then
                grid.DisplayLayout.Bands(0).Columns(Key).Header.ToolTipText = Tooltip
            End If

            'If Alineacion <> HAlign.Default Then
            '    .DisplayLayout.Bands(0).Columns(Key).CellAppearance.TextHAlign = Alineacion
            'End If

            If IsNothing(Alineacion) = False Then
                .DisplayLayout.Bands(0).Columns(Key).CellAppearance.TextHAlign = Alineacion
            End If
            If NEgrita = True Then
                .DisplayLayout.Bands(0).Columns(Key).CellAppearance.FontData.Bold = DefaultableBoolean.True
            End If


            If Edicion = True Then
                .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.AllowEdit
            Else
                .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.NoEdit
            End If

        End With
    End Sub

    Private Sub FormatoColumna(ByRef columna As UltraGridColumn, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, Optional ByVal Width As Integer = -1, Optional ByVal EsPorcentaje As Boolean = False)
        Dim FormatoNumero As String = "###,###,##0.00"
        Dim FormatoPorcentaje As String = "##0%"
        columna.Hidden = Ocultar
        If EsCadena = True Then
            columna.CellAppearance.TextHAlign = HAlign.Left
        Else

            If EsPorcentaje = True Then
                columna.Format = FormatoPorcentaje
                columna.CellAppearance.TextHAlign = HAlign.Right
            Else
                columna.Format = FormatoNumero
                columna.CellAppearance.TextHAlign = HAlign.Right
            End If

        End If

        If Width <> -1 Then
            columna.Width = Width
            columna.MaxWidth = Width
        End If
    End Sub

    Private Sub SumarizarColumnaGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal NombreColumna As String, ByVal Key As String)
        Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns(NombreColumna)
        Dim summary As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add(Key, SummaryType.Sum, columnToSummarize)
        summary.DisplayFormat = "{0:###,###,##0}"
        summary.Appearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
    End Sub


    Private Sub gridDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)


        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        '        grid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText

        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard

        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns


        AgregarColumna(grid, " ", " ", True, True, Nothing, 100)
        AgregarColumna(grid, "APaterno", "A PATERNO", False, True, Nothing, 100)
        AgregarColumna(grid, "AMaterno", "A MATERNO", False, True, Nothing, 100)
        AgregarColumna(grid, "Nombre", "NOMBRE", False, True, Nothing, -1)
        AgregarColumna(grid, "NSS", "NSS", False, True, Nothing, 100)
        AgregarColumna(grid, "fifi_fechabaja", "FBAJA", False, True, Nothing, 100)
        AgregarColumna(grid, "FechaSolicitud", "FSOLICITUD", False, True, Nothing, -1)
        AgregarColumna(grid, "baim_fechabajaimss", "FBAJAIMSS", False, True, Nothing, -1)
        'AgregarColumna(grid, "fifi_fechacreacion", "FCREACIÓN", False, True, Nothing, -1)
        AgregarColumna(grid, "fifi_totalvacaciones", "TOTAL VACACIONES", False, False, Nothing, -1, True, False, HAlign.Right)
        AgregarColumna(grid, "fifi_primavacacional", "PRIMA VACACIONAL", False, False, Nothing, -1, True, , HAlign.Right)
        AgregarColumna(grid, "fifi_totalaguinaldo", "TOTAL AGUINALDO", False, False, Nothing, -1, True, False, HAlign.Right)
        AgregarColumna(grid, "fifi_indemnizacionfiniquito", "INDEMIZACIÓN POR FINIQUITO", False, False, Nothing, -1, True, False, HAlign.Right)
        AgregarColumna(grid, "fifi_impuestoretener", "RETENCIÓN ISR", False, False, Nothing, -1, True, False, HAlign.Right)
        AgregarColumna(grid, "fifi_totalentregar", "TOTAL ENTREGAR", False, False, Nothing, -1, True, False, HAlign.Right)

        AgregarColumna(grid, "fifi_finiquitofiscalid", "fifi_finiquitofiscalid", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_colaboradorid", "fifi_colaboradorid", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_periodonominafiscalid", "fifi_periodonominafiscalid", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_patronid", "fifi_patronid", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_antiguedadanios", "fifi_antiguedadanios", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_antiguedadmeses", "fifi_antiguedadmeses", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_diascurso", "fifi_diascurso", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_salariominimo", "fifi_salariominimo", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_salariodiario", "fifi_salariodiario", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_iniciocurso", "fifi_iniciocurso", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_ultimopagovacaciones", "fifi_ultimopagovacaciones", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_diasvacacionescorresponden", "fifi_diasvacacionescorresponden", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_diasvacaciones", "fifi_diasvacaciones", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_iniciofifi_totalvacacionescurso", "fifi_totalvacaciones", True, True, Nothing, 100)

        AgregarColumna(grid, "fifi_factoraguinaldo", "fifi_factoraguinaldo", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_diasaguinaldocorresponden", "fifi_diasaguinaldocorresponden", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_diasaguinaldo", "fifi_diasaguinaldo", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_totalgravado", "fifi_totalgravado", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_ultimosueldomensual", "fifi_ultimosueldomensual", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_baseimpuesto", "fifi_baseimpuesto", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_tarifasemanalid", "fifi_tarifasemanalid", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_limiteinferior", "fifi_limiteinferior", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_excedentelimiteinferior", "fifi_excedentelimiteinferior", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_porcentajelimiteinferior", "fifi_porcentajelimiteinferior", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_impuestomarginal", "fifi_impuestomarginal", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_cuotafija", "fifi_cuotafija", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_impuestodeterminado", "fifi_impuestodeterminado", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_subsidioempleo", "fifi_subsidioempleo", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_retencionusmo", "fifi_retencionusmo", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_subtotal", "fifi_subtotal", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_usuariocreoid", "fifi_usuariocreoid", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_usuariomodificoid", "fifi_usuariomodificoid", True, True, Nothing, 100)
        AgregarColumna(grid, "fifi_fechamodificacion", "fifi_fechamodificacion", True, True, Nothing, 100)
        AgregarColumna(grid, "CodigoEmpleado", "CodigoEmpleado", True, True, Nothing, 100)
        AgregarColumna(grid, "NombreCompleto", "NombreCompleto", True, True, Nothing, 100)

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If NaveId > 0 Then
            If grdReporteFiniquito.Rows.Count > 0 Then
                imprimirReporte()
            Else
                show_message("Advertencia", "No hay información para generar el reporte")
            End If
        Else
            Dim exito As New AdvertenciaForm
            exito.mensaje = "No se ha seleccionado una nave"
            exito.ShowDialog()
        End If
    End Sub




    Public Sub imprimirReporte()
        Dim dtFiniquitoFiscal As New DataTable
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim entReporte As New Entidades.Reportes
        entReporte = objReporte.LeerReporteporClave("FINIQ_FISCAL")
        Dim CodigoEmpleado As String
        Dim TotalVacaciones As Double
        Dim PrimaVacacional As Double
        Dim TotalAguinaldo As Double
        Dim IndemizacionFiniquito As Double
        Dim ImpuestoRetenidos As Double
        Dim TotalEntregar As Double
        Dim NombreCompleto As String
        Dim objFiniquitoFiscal As New Contabilidad.Negocios.FiniquitoFiscalBU
        Dim DtInformacionEncabezado As DataTable

        DtInformacionEncabezado = objFiniquitoFiscal.ObtenerInformacionEmpresa(NaveId, 0, 0)

        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)
        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()

        reporte("RFC") = DtInformacionEncabezado.Rows(0).Item("patr_rfc").ToString()
        reporte("Empresa") = DtInformacionEncabezado.Rows(0).Item("patr_nombre").ToString()
        reporte("DomicilioFiscal") = DtInformacionEncabezado.Rows(0).Item("Domicilio").ToString()
        reporte("RegistroPatronal") = DtInformacionEncabezado.Rows(0).Item("patr_nopatronal").ToString()

        dtFiniquitoFiscal.Columns.Add("CodigoEmpleado", Type.GetType("System.String"))
        dtFiniquitoFiscal.Columns.Add("Vacaciones", Type.GetType("System.Double"))
        dtFiniquitoFiscal.Columns.Add("PrimaVacacional", Type.GetType("System.Double"))
        dtFiniquitoFiscal.Columns.Add("Aguinaldo", Type.GetType("System.Double"))
        dtFiniquitoFiscal.Columns.Add("IndemizacionFiniquito", Type.GetType("System.Double"))
        dtFiniquitoFiscal.Columns.Add("RetencionISR", Type.GetType("System.Double"))
        dtFiniquitoFiscal.Columns.Add("NetoRecibir", Type.GetType("System.Double"))
        dtFiniquitoFiscal.Columns.Add("FirmaEmpleado", Type.GetType("System.String"))
        dtFiniquitoFiscal.Columns.Add("Nombre", Type.GetType("System.String"))

        For Each fila As UltraGridRow In grdReporteFiniquito.Rows
            CodigoEmpleado = fila.Cells("CodigoEmpleado").Value
            TotalVacaciones = fila.Cells("fifi_totalvacaciones").Value
            IndemizacionFiniquito = fila.Cells("fifi_indemnizacionfiniquito").Value
            PrimaVacacional = fila.Cells("fifi_primavacacional").Value
            TotalAguinaldo = fila.Cells("fifi_totalaguinaldo").Value
            ImpuestoRetenidos = fila.Cells("fifi_impuestoretener").Value
            TotalEntregar = fila.Cells("fifi_totalentregar").Value
            NombreCompleto = fila.Cells("NombreCompleto").Value

            dtFiniquitoFiscal.Rows.Add(New Object() {CodigoEmpleado, TotalVacaciones, PrimaVacacional, TotalAguinaldo, IndemizacionFiniquito, ImpuestoRetenidos, TotalEntregar, "", NombreCompleto})
        Next


        reporte("NombreReporte") = "SAY: " & LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
        reporte("UsuarioCreo") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString.ToUpper + " " + Date.Now.ToLongDateString()

        Dim dt As DataTable
        dt = dtFiniquitoFiscal.Select("", "CodigoEmpleado").CopyToDataTable()


        reporte.Dictionary.Clear()
        reporte.RegData(dtFiniquitoFiscal)
        reporte.Dictionary.Synchronize()
        reporte.Show()
        dtFiniquitoFiscal.Clear()


    End Sub


    Private Sub CargarNAves()
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub CargarEmpresas()
        cmbEmpresa.DataSource = Nothing
        If cmbNave.SelectedIndex > 0 Then
            Dim objBu As New Contabilidad.Negocios.UtileriasBU
            Dim dtEmpresa As New DataTable

            dtEmpresa = objBu.consultaPatronPorNave(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbNave.SelectedValue)
            If dtEmpresa.Rows.Count > 0 Then
                If dtEmpresa.Rows.Count = 1 Then
                    Dim dtRow As DataRow = dtEmpresa.NewRow
                    dtRow("ID") = 0
                    dtRow("PATRON") = ""
                    dtEmpresa.Rows.InsertAt(dtRow, 0)
                End If

                cmbEmpresa.DataSource = dtEmpresa
                cmbEmpresa.DisplayMember = "Patron"
                cmbEmpresa.ValueMember = "ID"

                If dtEmpresa.Rows.Count = 2 Then
                    cmbEmpresa.SelectedIndex = 1
                End If
            End If
        End If


        ''Dim objBU As New Negocios.UtileriasBU
        ''Dim dtEmpresas As New DataTable

        ''dtEmpresas = objBU.consultarPatronEmpresa()
        ''If Not dtEmpresas Is Nothing Then
        ''    If dtEmpresas.Rows.Count > 0 Then
        ''        cmbEmpresa.DataSource = dtEmpresas
        ''        cmbEmpresa.ValueMember = "ID"
        ''        cmbEmpresa.DisplayMember = "PATRON"
        ''        cmbEmpresa.SelectedIndex = 1
        ''    Else
        ''        cmbEmpresa.DataSource = Nothing
        ''    End If
        ''Else
        ''    cmbEmpresa.DataSource = Nothing
        ''End If
    End Sub


    Private Sub CargarEstatusBaja()
        Dim objSolicitudesBaja As New Contabilidad.Negocios.SolicitudBajaBU

        cmbEstatus.DataSource = objSolicitudesBaja.ConsultaEstatusSolicitudBaja()

        cmbEstatus.ValueMember = "EstatusID"
        cmbEstatus.DisplayMember = "Estatus"


        cmbEstatus.SelectedValue = 106

    End Sub


    Private Sub CargarPeriodosNominaFicales()
        Dim objutl As New Contabilidad.Negocios.UtileriasBU()

        cmbPeriodo.DataSource = objutl.ConsultarPeriodosNomina(cmbNave.SelectedValue)

        cmbPeriodo.ValueMember = "PeriodoNominaFiscalID"
        cmbPeriodo.DisplayMember = "Descripcion"

    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        CargarEmpresas()
    End Sub



    Private Sub chkFiltroFechas_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltroFechas.CheckedChanged
        CargarPeriodosNominaFicales()

        If chkFiltroFechas.Checked = True Then
            rdoRango.Enabled = True
            rdoPeriodo.Enabled = True
            rdoFechaBaja.Enabled = True
            rdoFechaSolicitud.Enabled = True
            If rdoRango.Checked = True Then
                dtmRangoFechaDel.Enabled = True
                dtmRangoFechaAl.Enabled = True
                cmbPeriodo.Enabled = False
            Else
                cmbPeriodo.Enabled = True
                dtmRangoFechaDel.Enabled = False
                dtmRangoFechaAl.Enabled = False
            End If

        Else
            rdoRango.Enabled = False
            rdoPeriodo.Enabled = False
            cmbPeriodo.Enabled = False
            dtmRangoFechaDel.Enabled = False
            dtmRangoFechaAl.Enabled = False

        End If
    End Sub

    Private Sub rdoRango_CheckedChanged(sender As Object, e As EventArgs) Handles rdoRango.CheckedChanged
        dtmRangoFechaDel.Enabled = True
        dtmRangoFechaAl.Enabled = True
        cmbPeriodo.Enabled = False
    End Sub

    Private Sub rdoPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPeriodo.CheckedChanged
        CargarPeriodosNominaFicales()
        dtmRangoFechaDel.Enabled = False
        dtmRangoFechaAl.Enabled = False
        cmbPeriodo.Enabled = True
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        gpbFiltro.Height = 148
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        gpbFiltro.Height = 35
    End Sub



    Private Sub btnLimpiarSolicitudes_Click(sender As Object, e As EventArgs) Handles btnLimpiarSolicitudes.Click
        cmbNave.SelectedIndex = 0
        cmbEmpresa.DataSource = Nothing
        cmbEstatus.SelectedValue = 106
        txtNombre.Text = String.Empty
        chkFiltroFechas.Checked = False
        chkFiltroFechas_CheckedChanged(Nothing, Nothing)
        cmbPeriodo.DataSource = Nothing
        rdoFechaBaja.Checked = True
        rdoFechaSolicitud.Checked = False
        rdoRango.Checked = True
        rdoPeriodo.Checked = False
        grdReporteFiniquito.DataSource = Nothing
    End Sub


End Class