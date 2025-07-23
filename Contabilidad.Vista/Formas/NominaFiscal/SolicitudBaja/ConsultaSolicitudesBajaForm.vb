Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports Infragistics.Win
Imports System.Linq
Imports System.Data
Imports System.Data.DataTable
Imports System.Data.DataSet
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports Stimulsoft.Report
Imports Framework.Negocios

Public Class ConsultaSolicitudesBajaForm

    Dim NaveID As Integer
    Dim EmpresaID As Integer


    Private pPatronId As Integer
    Public Property prPatronId() As Integer
        Get
            Return pPatronId
        End Get
        Set(ByVal value As Integer)
            pPatronId = value
        End Set
    End Property

    Private pEstatusId As Integer
    Public Property prEstatusId() As Integer
        Get
            Return pEstatusId
        End Get
        Set(ByVal value As Integer)
            pEstatusId = value
        End Set
    End Property

    Private pNaveId As Integer
    Public Property prNaveId() As Integer
        Get
            Return pNaveId
        End Get
        Set(ByVal value As Integer)
            pNaveId = value
        End Set
    End Property


    Private Sub ConsultaSolicitudesBajaForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        'CargarGrid()
        Me.Location = New Point(0, 0)
        Me.WindowState = FormWindowState.Maximized
        btnEditarFiniquito.Enabled = False

        CargarNAves()
        'CargarEmpresas()
        CargarEstatusBaja()
        dtmRangoFechaAl.Value = Date.Now
        dtmRangoFechaDel.Value = Date.Now

        HabilitarDeshabilitarControles(False)
        configuracionBotones()

        If pNaveId <> 0 And cmbNave.Items.Count > 0 Then
            cmbNave.SelectedValue = pNaveId
            If pPatronId <> 0 And cmbEmpresa.Items.Count > 0 Then
                cmbEmpresa.SelectedValue = pPatronId
                If pEstatusId <> 0 Then
                    cmbEstatus.SelectedValue = pEstatusId
                End If
                cargarListado()
            End If
        End If
    End Sub

    Private Sub configuracionBotones()
        If PermisosUsuarioBU.ConsultarPermiso("CONSOLBAJA_CONTA", "SOL_VERFINIQUITO") Then
            pnlVerFiniquito.Visible = True
        Else
            pnlVerFiniquito.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("CONSOLBAJA_CONTA", "SOL_GENERARTXT") Then
            pnlDescargarTXT.Visible = True
        Else
            pnlDescargarTXT.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("CONSOLBAJA_CONTA", "SOL_ACEPTARRECHAZAR") Then
            pnlAceptado.Visible = True
            pnlRechazado.Visible = True
        Else
            pnlAceptado.Visible = False
            pnlRechazado.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("CONSOLBAJA_CONTA", "SOL_CALCULAFINIQUITO") Then
            pnlCalcularFiniquito.Visible = True
        Else
            pnlCalcularFiniquito.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("CONSOLBAJA_CONTA", "SOL_IMPRIMIRLISTADO") Then
            pnlImprimirListado.Visible = True
        Else
            pnlImprimirListado.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("CONSOLBAJA_CONTA", "SOL_EXPORTARLISTADO") Then
            pnlExportarListado.Visible = True
        Else
            pnlExportarListado.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("CONSOLBAJA_CONTA", "SOL_CONSULTAREPORTE") Then
            pnlConsultaReporte.Visible = True
        Else
            pnlConsultaReporte.Visible = False
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub CargarGrid()
        Dim LNaveID As Integer = cmbNave.SelectedValue
        Dim LEmpresa As Integer = cmbEmpresa.SelectedValue
        Dim LEstatus As Integer = cmbEstatus.SelectedValue
        Dim LNombre As String = txtNombre.Text
        Dim LEsFechaBaja As Boolean = rdoFechaBaja.Checked
        Dim LEsFechaSolicitud As Boolean = rdoFechaSolicitud.Checked
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
        NaveID = LNaveID
        EmpresaID = LEmpresa

        grdSolicitudesBaja.DataSource = Nothing
        If IsNothing(grdSolicitudesBaja.DataSource) Then
            gridDiseno(grdSolicitudesBaja)
        End If

        Dim objSolicitudesBaja As New Contabilidad.Negocios.SolicitudBajaBU
        grdSolicitudesBaja.DataSource = objSolicitudesBaja.ConsultaSolicitudesBaja(LNaveID, LEmpresa, LEstatus, LNombre, LEsFechaBaja, LEsFechaTRango, LFechaInicio.ToShortDateString + " 00:00:00", LFechaFin.ToShortDateString + " 11:59", LPeriodoId, LFiltroFechas)
    End Sub


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


        AgregarColumna(grid, " ", " ", False, True, Nothing, 100)
        AgregarColumna(grid, "APaterno", "A PATERNO", False, True, Nothing, 100)
        AgregarColumna(grid, "AMaterno", "A MATERNO", False, True, Nothing, 100)
        AgregarColumna(grid, "Nombre", "NOMBRE", False, True, Nothing, 100)
        AgregarColumna(grid, "NSS", "NSS", False, True, Nothing, 100)
        AgregarColumna(grid, "FechaBaja", "FECHA BAJA", False, True, Nothing, 100)
        AgregarColumna(grid, "FechaSolicitud", "FECHA SOLICITUD", False, True, Nothing, 100)
        AgregarColumna(grid, "fechaAutorizacion", "FECHA AUTORIZACION", False, True, Nothing, 100)

        ''15052019 Se agrega la fecha de aplicación y el usuario que aplica
        AgregarColumna(grid, "fechaAplicacion", "FECHA APLICACIÓN", False, True, Nothing, 100)
        AgregarColumna(grid, "usuarioAplico", "USUARIO APLICA", False, True, Nothing, 100)

        AgregarColumna(grid, "TotalFiniquito", "TOTAL FINIQUITO", False, False, Nothing, 100, True, , HAlign.Right)
        AgregarColumna(grid, "BajaIMSS", "BAJA IMSS", True, True, Nothing, 100)
        AgregarColumna(grid, "EstatusID", "EstatusID", True, True, Nothing, 100)
        AgregarColumna(grid, "ColaboradorID", "ColaboradorID", True, True, Nothing, 100)
        AgregarColumna(grid, "FiniquitoFiscalID", "FiniquitoFiscalID", True, True, Nothing, 100)
        AgregarColumna(grid, "labo_naveid", "labo_naveid", True, True, Nothing, 100)
        AgregarColumna(grid, "baim_patronid", "baim_patronid", True, True, Nothing, 100)

        grid.DisplayLayout.Bands(0).Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

        grid.DisplayLayout.Bands(0).Columns(" ").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns(" ").Width = 20

    End Sub

    Private Sub grdSolicitudesBaja_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdSolicitudesBaja.ClickCell
        If e.Cell.IsFilterRowCell = False Then
            If e.Cell.Column.Key = " " Then
                If e.Cell.Value Then
                    e.Cell.Value = False
                Else
                    e.Cell.Value = True
                End If
            End If
        End If


        Dim EstatusSolicitud As Integer = 0
        Dim TotalFiniquito As Double = 0
        Dim row As UltraGridRow = grdSolicitudesBaja.ActiveRow
        If row.IsFilterRow Then Return
        EstatusSolicitud = CInt(row.Cells("EstatusID").Value())
        TotalFiniquito = CInt(row.Cells("TotalFiniquito").Value())
        btnEditarFiniquito.Enabled = True

        'Habilitar bonton de subir alta acepatda y  rechazo

        'If EstatusSolicitud = 106 Or EstatusSolicitud = 109 Then
        '    btnAceptado.Enabled = True
        '    btnRechazado.Enabled = True
        'Else
        '    btnAceptado.Enabled = False
        '    btnRechazado.Enabled = False
        'End If

        'If EstatusSolicitud = 108 Then
        '    btnAceptado.Enabled = False
        '    btnRechazado.Enabled = False
        'End If

        'If EstatusSolicitud = 106 Or EstatusSolicitud = 109 Or EstatusSolicitud = 108 Then
        '    btnDescargartxt.Enabled = True
        'Else
        '    btnDescargartxt.Enabled = False
        'End If


        If EstatusSolicitud = 105 Then  '105 SOLICITADO
            btnEditarFiniquito.Enabled = True
            btnDescargartxt.Enabled = False
            btnAceptado.Enabled = False
            btnRechazado.Enabled = False
            btnCalcularFiniquito.Enabled = False

        ElseIf EstatusSolicitud = 106 Then ' 106 AUTORIZADO
            btnEditarFiniquito.Enabled = True
            btnDescargartxt.Enabled = True
            btnAceptado.Enabled = True
            btnRechazado.Enabled = True
            If TotalFiniquito = 0 Then
                btnCalcularFiniquito.Enabled = True
            Else
                btnCalcularFiniquito.Enabled = False
            End If


        ElseIf EstatusSolicitud = 107 Then '107 RECHAZADO
            btnEditarFiniquito.Enabled = True
            btnDescargartxt.Enabled = False
            btnAceptado.Enabled = False
            btnRechazado.Enabled = False
            btnCalcularFiniquito.Enabled = False


        ElseIf EstatusSolicitud = 108 Then ' 108 ACEPTADO
            btnEditarFiniquito.Enabled = True
            btnDescargartxt.Enabled = False
            btnAceptado.Enabled = False
            btnRechazado.Enabled = False
            btnCalcularFiniquito.Enabled = False

        ElseIf EstatusSolicitud = 109 Then ' 109 RECHAADO IDSE
            btnEditarFiniquito.Enabled = True
            btnDescargartxt.Enabled = True
            btnAceptado.Enabled = True
            btnRechazado.Enabled = True
            btnCalcularFiniquito.Enabled = False
        End If


        'If EstatusSolicitud = 106 Or EstatusSolicitud = 108 Or EstatusSolicitud = 109 Then
        '    btnDescargartxt.Enabled = True
        'Else
        '    btnDescargartxt.Enabled = False
        'End If

        '---------------------------------------------------------------

        'If EstatusSolicitud = 106 And TotalFiniquito = 0 Then
        '    btnCalcularFiniquito.Enabled = True
        'Else
        '    If EstatusSolicitud = 106 Or EstatusSolicitud = 107 Then
        '        btnEditarFiniquito.Enabled = True
        '    Else
        '        btnEditarFiniquito.Enabled = False
        '    End If

        '    btnCalcularFiniquito.Enabled = False
        'End If




    End Sub

    Private Sub btnEditarFiniquito_Click(sender As Object, e As EventArgs) Handles btnEditarFiniquito.Click
        Dim SolicitudBaja As Integer = 0
        Dim EstatusSolicitud As Integer = 0
        Dim ColaboradorID As Integer = 0
        Dim TotalFiniquito As Double = 0
        Dim FechaBaja As Date
        Dim FiniquitoFiscalId As Integer = -1
        Dim CalcularFiniquito As New CalculoFiniquitoForm
        Dim row As UltraGridRow = grdSolicitudesBaja.ActiveRow
        If row.IsFilterRow Then Return
        SolicitudBaja = CInt(row.Cells("BajaIMSS").Value())
        EstatusSolicitud = CInt(row.Cells("EstatusID").Value())
        ColaboradorID = CInt(row.Cells("ColaboradorID").Value())
        TotalFiniquito = CInt(row.Cells("TotalFiniquito").Value())
        FechaBaja = CDate(row.Cells("FechaBaja").Value())
        If IsDBNull(row.Cells("FiniquitoFiscalID").Value()) = False Then
            FiniquitoFiscalId = CInt(row.Cells("FiniquitoFiscalID").Value())
        Else
            FiniquitoFiscalId = -1
        End If


        'If EstatusSolicitud = 106 Or EstatusSolicitud = 107 Then
        '    CalcularFiniquito.ColaboradorID = ColaboradorID
        '    CalcularFiniquito.FechaBaja = FechaBaja
        '    CalcularFiniquito.FinquitoFiscalID = FiniquitoFiscalId
        '    'CalcularFiniquito.MdiParent = Me.MdiParent
        '    CalcularFiniquito.Show()
        'End If

        CalcularFiniquito.ColaboradorID = ColaboradorID
        CalcularFiniquito.FechaBaja = FechaBaja
        CalcularFiniquito.FinquitoFiscalID = FiniquitoFiscalId
        CalcularFiniquito.EstatusSolicitud = EstatusSolicitud
        'CalcularFiniquito.MdiParent = Me.MdiParent
        CalcularFiniquito.Show()


    End Sub


    Private Sub btnCalcularFiniquito_Click(sender As Object, e As EventArgs) Handles btnCalcularFiniquito.Click
        Dim SolicitudBaja As Integer = 0
        Dim EstatusSolicitud As Integer = 0
        Dim ColaboradorID As Integer = 0
        Dim TotalFiniquito As Double = 0
        Dim FechaBaja As Date
        Dim CalcularFiniquito As New CalculoFiniquitoForm
        Dim row As UltraGridRow = grdSolicitudesBaja.ActiveRow
        If row.IsFilterRow Then Return
        SolicitudBaja = CInt(row.Cells("BajaIMSS").Value())
        EstatusSolicitud = CInt(row.Cells("EstatusID").Value())
        ColaboradorID = CInt(row.Cells("ColaboradorID").Value())
        TotalFiniquito = CInt(row.Cells("TotalFiniquito").Value())
        FechaBaja = CDate(row.Cells("FechaBaja").Value())

        If EstatusSolicitud = 106 And TotalFiniquito = 0 Then
            CalcularFiniquito.ColaboradorID = ColaboradorID
            CalcularFiniquito.FechaBaja = FechaBaja
            CalcularFiniquito.SolicitudBajaID = SolicitudBaja
            CalcularFiniquito.EstatusSolicitud = -1
            'CalcularFiniquito.MdiParent = Me.MdiParent
            CalcularFiniquito.Show()
        End If



    End Sub

    Public Sub cargarListado()

        If cmbNave.SelectedIndex > 0 Then
            If chkFiltroFechas.Checked = True Then
                If rdoRango.Checked = True Then
                    If dtmRangoFechaDel.Value > dtmRangoFechaAl.Value Then
                        show_message("Advertencia", "La fecha de inicio del rango no puede ser mayor a la fecha fin del rango.")
                        Return
                    End If
                End If
            End If
            CargarGrid()
            btnEditarFiniquito.Enabled = False
            btnDescargartxt.Enabled = False
            btnAceptado.Enabled = False
            btnRechazado.Enabled = False
            btnCalcularFiniquito.Enabled = False
            btnImprimir.Enabled = True
            btnExportarExcel.Enabled = True
            btnReporte.Enabled = True
            lblNave.ForeColor = Color.Black
        Else
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = "No se ha seleccionado una nave"
            advertencia.ShowDialog()
            lblNave.ForeColor = Color.Red
            grdSolicitudesBaja.DataSource = Nothing
        End If

    End Sub


    Private Sub btnMostrar_Click_1(sender As Object, e As EventArgs) Handles btnMostrar.Click

        If cmbNave.SelectedIndex > 0 Then
            If chkFiltroFechas.Checked = True Then
                If rdoRango.Checked = True Then
                    If dtmRangoFechaDel.Value > dtmRangoFechaAl.Value Then
                        show_message("Advertencia", "La fecha de inicio del rango no puede ser mayor a la fecha fin del rango.")
                        Return
                    End If
                End If
            End If
            CargarGrid()
            btnEditarFiniquito.Enabled = False
            btnDescargartxt.Enabled = False
            btnAceptado.Enabled = False
            btnRechazado.Enabled = False
            btnCalcularFiniquito.Enabled = False
            btnImprimir.Enabled = True
            btnExportarExcel.Enabled = True
            btnReporte.Enabled = True
            lblNave.ForeColor = Color.Black
        Else
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = "No se ha seleccionado una nave"
            advertencia.ShowDialog()
            lblNave.ForeColor = Color.Red
            grdSolicitudesBaja.DataSource = Nothing
        End If



    End Sub

    Private Sub HabilitarDeshabilitarControles(ByVal Activar As Boolean)
        btnEditarFiniquito.Enabled = Activar
        btnDescargartxt.Enabled = Activar
        btnAceptado.Enabled = Activar
        btnRechazado.Enabled = Activar
        btnCalcularFiniquito.Enabled = Activar
        btnImprimir.Enabled = Activar
        btnExportarExcel.Enabled = Activar
        btnReporte.Enabled = Activar
    End Sub


    Private Sub CargarNAves()
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNave.Items.Count = 2 Then
            cmbNave.SelectedIndex = 1
        End If

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


        'Dim altpoliBU As New Negocios.AltaPolizaBU
        'Dim cbempresasContpaq As New DataTable
        'Dim cbtipoPoliza As New DataTable
        ''Cargamos combos
        'cbempresasContpaq = altpoliBU.CargaEmpresaCONTPAQ(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString)
        'cbempresasContpaq.Rows.InsertAt(cbempresasContpaq.NewRow(), 0)
        'cmbEmpresa.DataSource = cbempresasContpaq

        'cmbEmpresa.ValueMember = "essc_sayid"
        'cmbEmpresa.DisplayMember = "RazonSocial"
    End Sub


    Private Sub CargarEstatusBaja()
        Dim objSolicitudesBaja As New Contabilidad.Negocios.SolicitudBajaBU

        cmbEstatus.DataSource = objSolicitudesBaja.ConsultaEstatusSolicitudBaja()

        cmbEstatus.ValueMember = "EstatusID"
        cmbEstatus.DisplayMember = "Estatus"


        cmbEstatus.SelectedValue = 106 '106 Aceptado

    End Sub


    Private Sub CargarPeriodosNominaFicales()
        Dim objutl As New Contabilidad.Negocios.UtileriasBU()
        cmbPeriodo.DataSource = Nothing
        If cmbNave.SelectedValue.GetType() = GetType(Integer) Then
            If cmbNave.SelectedValue > 0 Then
                cmbPeriodo.DataSource = objutl.ConsultarPeriodosNomina(cmbNave.SelectedValue)
                cmbPeriodo.ValueMember = "PeriodoNominaFiscalID"
                cmbPeriodo.DisplayMember = "Descripcion"
            End If
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If grdSolicitudesBaja.Rows.Count > 0 Then
            exportarExcel(grdSolicitudesBaja)
        Else
            show_message("Advertencia", "No hay información para exportar.")
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

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim GenerarFiniquito As New GenerarReporteFiniquitoForm
        GenerarFiniquito.MdiParent = Me.MdiParent
        If cmbNave.SelectedIndex > 0 Then
            GenerarFiniquito.NaveId = cmbNave.SelectedValue
        End If
        GenerarFiniquito.Show()

    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        CargarEmpresas()
        CargarPeriodosNominaFicales()
        btnEditarFiniquito.Enabled = False
        btnDescargartxt.Enabled = False
        btnAceptado.Enabled = False
        btnRechazado.Enabled = False
        btnCalcularFiniquito.Enabled = False
        btnImprimir.Enabled = False
        btnExportarExcel.Enabled = False
        btnReporte.Enabled = False
    End Sub


    Private Sub btnDescargartxt_Click(sender As Object, e As EventArgs) Handles btnDescargartxt.Click
        Dim objSolicitud As New Contabilidad.Negocios.SolicitudBajaBU
        Dim DTInfoIDSE As DataTable
        Dim fecha As String = Date.Now.ToString("ddMMyyyHmm")
        Dim SolicitudBaja As Integer = 0
        Dim EstatusSolicitud As Integer = 0
        Dim ColaboradorID As Integer = 0
        Dim FiniquitoFiscalId As Integer = -1

        Dim archivoTXT As String = String.Empty
        Dim informacion As String = String.Empty
        Dim informacionIdse As New Entidades.InformacionIDSE_SUA
        Dim objBU As New Negocios.ModificacionSalarioBU
        Dim RutaDescarga As String = String.Empty
        Dim row As UltraGridRow = grdSolicitudesBaja.ActiveRow
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Dim idsSolicitudes() As Integer
        Dim regSeleccionado As Int32 = 0
        Dim contIdse As Int32 = 0
        Dim countexisteArchivo As Int32 = 0
        Dim advertencia As New AdvertenciaForm
        Dim contGeneradas As Int32 = 0
        Dim ruta As String = String.Empty

        Dim dtSua As New DataTable
        dtSua.Columns.Add("NoPatron")
        dtSua.Columns.Add("NSS")
        dtSua.Columns.Add("TipoMovimiento")
        dtSua.Columns.Add("FechaMovimiento")

        Try
            'With fbdUbicacionArchivo
            '    .Reset()
            '    .Description = " Seleccione una carpeta "
            '    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            '    .ShowNewFolderButton = True
            '    Dim ret As DialogResult = .ShowDialog
            '    If ret = Windows.Forms.DialogResult.OK Then
            '        RutaDescarga = .SelectedPath
            '    Else
            '        RutaDescarga = String.Empty
            '    End If

            '    .Dispose()
            'End With

            ''agregado
            For Each rowGr As UltraGridRow In grdSolicitudesBaja.Rows
                If CBool(rowGr.Cells(" ").Value) = True Then
                    ReDim Preserve idsSolicitudes(regSeleccionado)
                    idsSolicitudes(regSeleccionado) = rowGr.Cells("BajaIMSS").Value
                    regSeleccionado += 1

                End If
            Next

            If regSeleccionado > 0 Then


                For item As Integer = 0 To idsSolicitudes.Length - 1
                    DTInfoIDSE = objSolicitud.ObtenerInformacionDocumentoIDSE(0, idsSolicitudes(item))
                    If DTInfoIDSE.Rows.Count > 0 Then
                        contIdse += 1

                        RutaDescarga = DTInfoIDSE.Rows(0).Item("rutaDescarga").ToString
                        archivoTXT = RutaDescarga & "\bajaIDSE_" & DTInfoIDSE.Rows(0).Item("NSS") & "_" & DTInfoIDSE.Rows(0).Item("idBaja") & ".dat"
                        If existeArchivo(archivoTXT) Then
                            countexisteArchivo += 1
                        End If
                    End If
                Next

                If contIdse = regSeleccionado Then
                    If countexisteArchivo > 0 Then
                        Dim mensajeConfirmar As New ConfirmarForm
                        mensajeConfirmar.mensaje = "Ya existen archivos para " + countexisteArchivo.ToString + " de los registros seleccionados, ¿Desea remplazarlos? "
                        If mensajeConfirmar.ShowDialog = DialogResult.OK Then
                            For item As Integer = 0 To idsSolicitudes.Length - 1
                                DTInfoIDSE = objSolicitud.ObtenerInformacionDocumentoIDSE(0, idsSolicitudes(item))
                                informacion = DTInfoIDSE.Rows(0).Item("NoPatron")
                                informacion &= DTInfoIDSE.Rows(0).Item("NSS")
                                informacion &= DTInfoIDSE.Rows(0).Item("APaterno")
                                informacion &= DTInfoIDSE.Rows(0).Item("AMaterno")
                                informacion &= DTInfoIDSE.Rows(0).Item("Nombre")
                                informacion &= "               " 'Filler            
                                informacion &= DTInfoIDSE.Rows(0).Item("FechaMovimiento")
                                informacion &= "     " 'Filler
                                informacion &= DTInfoIDSE.Rows(0).Item("TipoMovimiento")
                                informacion &= guia
                                informacion &= DTInfoIDSE.Rows(0).Item("ClaveTrabajador")
                                informacion &= DTInfoIDSE.Rows(0).Item("CausaBaja")
                                informacion &= "                  " 'Filler
                                informacion &= DTInfoIDSE.Rows(0).Item("IdentificadorFormato")
                                informacion &= vbCrLf

                                archivoTXT = RutaDescarga & "\bajaIDSE_" & DTInfoIDSE.Rows(0).Item("NSS") & "_" & DTInfoIDSE.Rows(0).Item("idBaja") & ".dat"
                                File.WriteAllText(archivoTXT, informacion.ToUpper)
                                contGeneradas += 1

                                Dim rowSua As DataRow = dtSua.NewRow
                                rowSua.Item("NoPatron") = DTInfoIDSE.Rows(0).Item("NoPatron")
                                rowSua.Item("NSS") = DTInfoIDSE.Rows(0).Item("NSS")
                                rowSua.Item("TipoMovimiento") = DTInfoIDSE.Rows(0).Item("TipoMovimiento")
                                rowSua.Item("FechaMovimiento") = DTInfoIDSE.Rows(0).Item("FechaMovimiento")
                                dtSua.Rows.Add(rowSua)

                                ruta = DTInfoIDSE.Rows(0).Item("rutaDescarga").ToString
                            Next

                            If regSeleccionado = contGeneradas Then
                                If generarTxtSuaGlobal(dtSua, fecha, ruta) Then
                                    Dim exito As New ExitoForm
                                    exito.mensaje = "Los datos se exportaron correctamente"
                                    exito.ShowDialog()
                                End If


                            End If
                        End If
                    Else
                        For item As Integer = 0 To idsSolicitudes.Length - 1
                            DTInfoIDSE = objSolicitud.ObtenerInformacionDocumentoIDSE(0, idsSolicitudes(item))
                            informacion = DTInfoIDSE.Rows(0).Item("NoPatron")
                            informacion &= DTInfoIDSE.Rows(0).Item("NSS")
                            informacion &= DTInfoIDSE.Rows(0).Item("APaterno")
                            informacion &= DTInfoIDSE.Rows(0).Item("AMaterno")
                            informacion &= DTInfoIDSE.Rows(0).Item("Nombre")
                            informacion &= "               " 'Filler            
                            informacion &= DTInfoIDSE.Rows(0).Item("FechaMovimiento")
                            informacion &= "     " 'Filler
                            informacion &= DTInfoIDSE.Rows(0).Item("TipoMovimiento")
                            informacion &= guia
                            informacion &= DTInfoIDSE.Rows(0).Item("ClaveTrabajador")
                            informacion &= DTInfoIDSE.Rows(0).Item("CausaBaja")
                            informacion &= "                  " 'Filler
                            informacion &= DTInfoIDSE.Rows(0).Item("IdentificadorFormato")

                            archivoTXT = RutaDescarga & "\bajaIDSE_" & DTInfoIDSE.Rows(0).Item("NSS") & "_" & DTInfoIDSE.Rows(0).Item("idBaja") & ".dat"
                            If Not existeArchivo(IO.Path.GetDirectoryName(archivoTXT)) Then
                                crearCarpeta(IO.Path.GetDirectoryName(archivoTXT))
                            End If
                            File.WriteAllText(archivoTXT, informacion.ToUpper)
                            contGeneradas += 1

                            Dim rowSua As DataRow = dtSua.NewRow
                            rowSua.Item("NoPatron") = DTInfoIDSE.Rows(0).Item("NoPatron")
                            rowSua.Item("NSS") = DTInfoIDSE.Rows(0).Item("NSS")
                            rowSua.Item("TipoMovimiento") = DTInfoIDSE.Rows(0).Item("TipoMovimiento")
                            rowSua.Item("FechaMovimiento") = DTInfoIDSE.Rows(0).Item("FechaMovimiento")
                            dtSua.Rows.Add(rowSua)

                            ruta = DTInfoIDSE.Rows(0).Item("rutaDescarga").ToString
                        Next

                        If regSeleccionado = contGeneradas Then
                            If generarTxtSuaGlobal(dtSua, fecha, ruta) Then
                                Dim exito As New ExitoForm
                                exito.mensaje = "Los datos se exportaron correctamente"
                                exito.ShowDialog()
                            End If


                        End If
                    End If
                Else
                    advertencia.mensaje = "La consulta de la información para " + contIdse.ToString + " archivo(s) no arrojó ningún resultado, favor de revisar los datos."
                    advertencia.ShowDialog()
                End If

            End If



            'If RutaDescarga <> String.Empty Then

            '    If row.IsFilterRow Then Return
            '    SolicitudBaja = CInt(row.Cells("BajaIMSS").Value())
            '    EstatusSolicitud = CInt(row.Cells("EstatusID").Value())
            '    ColaboradorID = CInt(row.Cells("ColaboradorID").Value())
            '    If IsDBNull(row.Cells("FiniquitoFiscalID").Value()) = False Then
            '        FiniquitoFiscalId = CInt(row.Cells("FiniquitoFiscalID").Value())
            '    Else
            '        FiniquitoFiscalId = -1
            '    End If

            '    If FiniquitoFiscalId <> -1 Then
            '        DTInfoIDSE = objSolicitud.ObtenerInformacionDocumentoIDSE(ColaboradorID, FiniquitoFiscalId)
            '        informacion = DTInfoIDSE.Rows(0).Item("NoPatron")
            '        informacion &= DTInfoIDSE.Rows(0).Item("NSS")
            '        informacion &= DTInfoIDSE.Rows(0).Item("APaterno")
            '        informacion &= DTInfoIDSE.Rows(0).Item("AMaterno")
            '        informacion &= DTInfoIDSE.Rows(0).Item("Nombre")
            '        informacion &= "000000000000000" 'Filler            
            '        informacion &= DTInfoIDSE.Rows(0).Item("FechaMovimiento")
            '        informacion &= "     " 'Filler
            '        informacion &= DTInfoIDSE.Rows(0).Item("TipoMovimiento")
            '        informacion &= guia
            '        informacion &= DTInfoIDSE.Rows(0).Item("ClaveTrabajador")
            '        informacion &= DTInfoIDSE.Rows(0).Item("CausaBaja")
            '        informacion &= "                  " 'Filler
            '        informacion &= DTInfoIDSE.Rows(0).Item("IdentificadorFormato")

            '        'archivoTXT = "C:\Users\SISTEMAS16\Documents\Archivos IDSE\" & "bajaIDSE_" & DTInfoIDSE.Rows(0).Item("NSS") & "_" & fecha & ".txt"

            '        archivoTXT = RutaDescarga & "\bajaIDSE_" & DTInfoIDSE.Rows(0).Item("NSS") & "_" & fecha & ".dat"

            '        'If Not existeArchivo(IO.Path.GetDirectoryName(archivoTXT)) Then
            '        '    crearCarpeta(IO.Path.GetDirectoryName(archivoTXT))
            '        'End If


            '        ''  archivoTXT = DTInfoIDSE.Rows(0).Item("rutaDescarga")
            '        '' archivoTXT = archivoTXT & "bajaIDSE" & DTInfoIDSE.Rows(0).Item("NSS") & "_" & fecha & ".dat"

            '        'If Not existeArchivo(IO.Path.GetDirectoryName(archivoTXT)) Then
            '        '    crearCarpeta(IO.Path.GetDirectoryName(archivoTXT))
            '        'End If

            '        File.WriteAllText(archivoTXT, informacion.ToUpper)
            '        generarTxtSua(DTInfoIDSE, RutaDescarga & "\bajaSUA_" & DTInfoIDSE.Rows(0).Item("NSS") & "_" & fecha & ".txt")

            '        Dim exito As New ExitoForm
            '        exito.mensaje = "Los datos se exportaron correctamente"
            '        exito.ShowDialog()

            '    End If
            'End If

        Catch ex As Exception
            Dim exito As New ErroresForm
            exito.mensaje = "No se pudo generar el archivo"
            exito.ShowDialog()
        End Try

    End Sub


    Private Function generarTxtSua(ByVal infoIdse As DataTable, ByVal RutaDescarga As String) As Boolean
        Dim archivoTXT As String = String.Empty
        Dim informacion As String = String.Empty
        Dim informacionIdse As New Entidades.InformacionIDSE_SUA
        Dim objBU As New Negocios.ModificacionSalarioBU

        archivoTXT = RutaDescarga

        If Not existeArchivo(IO.Path.GetDirectoryName(archivoTXT)) Then
            crearCarpeta(IO.Path.GetDirectoryName(archivoTXT))
        End If

        informacion = infoIdse.Rows(0).Item("NoPatron")
        informacion &= infoIdse.Rows(0).Item("NSS")
        informacion &= infoIdse.Rows(0).Item("TipoMovimiento")
        informacion &= infoIdse.Rows(0).Item("FechaMovimiento")
        informacion &= "        " 'Espacio para Folio incapacidad (NO APLICA)
        informacion &= "00" 'Espacio para Dias de incidencia (NO APLICA)
        informacion &= "0000000" 'Espacion Salario Diario Integrado (NO APLICA)

        File.WriteAllText(archivoTXT, informacion.ToUpper)
        Return existeArchivo(archivoTXT)

    End Function

    Private Function generarTxtSuaGlobal(ByVal dtDatos As DataTable, ByVal fecha As String, ByVal rutaDescarga As String) As Boolean
        Dim archivoTXT As String = String.Empty
        Dim informacion As String = String.Empty
        Dim informacionIdse As New Entidades.InformacionIDSE_SUA
        Dim objBU As New Negocios.ModificacionSalarioBU

        archivoTXT = rutaDescarga & "\bajaSUA" & "_" & fecha & ".txt"

        If Not existeArchivo(IO.Path.GetDirectoryName(archivoTXT)) Then
            crearCarpeta(IO.Path.GetDirectoryName(archivoTXT))
        End If

        For Each rowDato As DataRow In dtDatos.Rows
            informacion &= rowDato("NoPatron").ToString
            informacion &= rowDato("NSS").ToString
            informacion &= rowDato("TipoMovimiento").ToString
            informacion &= rowDato("FechaMovimiento").ToString
            informacion &= "        " 'Espacio para Folio incapacidad (NO APLICA)
            informacion &= "00" 'Espacio para Dias de incidencia (NO APLICA)
            informacion &= "0000000" 'Espacion Salario Diario Integrado (NO APLICA)
            informacion &= vbCrLf
        Next


        File.WriteAllText(archivoTXT, informacion.ToUpper)
        Return existeArchivo(archivoTXT)
    End Function

    Private Sub chkFiltroFechas_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltroFechas.CheckedChanged
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
            rdoFechaBaja.Enabled = False
            rdoFechaSolicitud.Enabled = False
            rdoRango.Enabled = False
            rdoPeriodo.Enabled = False
            cmbPeriodo.Enabled = False
            dtmRangoFechaDel.Enabled = False
            dtmRangoFechaAl.Enabled = False

        End If
    End Sub

    Private Sub rdoPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPeriodo.CheckedChanged
        CargarPeriodosNominaFicales()
        dtmRangoFechaDel.Enabled = False
        dtmRangoFechaAl.Enabled = False
        cmbPeriodo.Enabled = True
    End Sub

    Private Sub rdoRango_CheckedChanged(sender As Object, e As EventArgs) Handles rdoRango.CheckedChanged
        dtmRangoFechaDel.Enabled = True
        dtmRangoFechaAl.Enabled = True
        cmbPeriodo.Enabled = False

    End Sub

    Private Sub btnAceptado_Click(sender As Object, e As EventArgs) Handles btnAceptado.Click
        Dim SolicitudBaja As Integer
        Dim ColaboradorId As Integer
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        'Dim row As UltraGridRow = grdSolicitudesBaja.ActiveRow
        'If row.IsFilterRow Then Return
        'SolicitudBaja = CInt(row.Cells("BajaIMSS").Value())
        'ColaboradorId = CInt(row.Cells("ColaboradorID").Value())

        Dim GuardoExito As Boolean = False
        Dim contSeleccionadas As Integer = 0

        For Each row As UltraGridRow In grdSolicitudesBaja.Rows
            If row.Cells(" ").Value Then
                contSeleccionadas += 1
                SolicitudBaja = CInt(row.Cells("BajaIMSS").Value())
                ColaboradorId = CInt(row.Cells("ColaboradorID").Value())

            End If
        Next

        If contSeleccionadas = 0 Then
            objMensajeAdv.mensaje = "Favor de selecionar un registro."
            objMensajeAdv.ShowDialog()
        ElseIf contSeleccionadas > 1 Then
            objMensajeAdv.mensaje = "Favor de selecionar solo un registro."
            objMensajeAdv.ShowDialog()
        Else
            Dim objBU As New Negocios.SolicitudBajaBU
            If objBU.validaTxtGenerado(SolicitudBaja) Then

                Dim FormSolicitudAceptada As New PDFAcuseMovimientoBajaIDSEForm
                FormSolicitudAceptada.solicitudId = SolicitudBaja
                FormSolicitudAceptada.colaboradorId = ColaboradorId
                FormSolicitudAceptada.movimiento = "Aceptar"
                FormSolicitudAceptada.ShowDialog()
                GuardoExito = FormSolicitudAceptada.guardado
                CargarGrid()

            Else
                objMensajeAdv.mensaje = "Es necesario Descargar txt antes de Aceptar la solicitud."
                objMensajeAdv.ShowDialog()

            End If
        End If

    End Sub

    Private Sub btnRechazado_Click(sender As Object, e As EventArgs) Handles btnRechazado.Click
        Dim SolicitudBaja As Integer
        Dim ColaboradorId As Integer
        'Dim row As UltraGridRow = grdSolicitudesBaja.ActiveRow
        'If row.IsFilterRow Then Return
        'SolicitudBaja = CInt(row.Cells("BajaIMSS").Value())
        'ColaboradorId = CInt(row.Cells("ColaboradorID").Value())
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim GuardoExito As Boolean = False
        Dim contSeleccionadas As Integer = 0

        For Each row As UltraGridRow In grdSolicitudesBaja.Rows
            If row.Cells(" ").Value Then
                contSeleccionadas += 1
                SolicitudBaja = CInt(row.Cells("BajaIMSS").Value())
                ColaboradorId = CInt(row.Cells("ColaboradorID").Value())

            End If
        Next

        If contSeleccionadas = 0 Then
            objMensajeAdv.mensaje = "Favor de selecionar un registro."
            objMensajeAdv.ShowDialog()
        ElseIf contSeleccionadas > 1 Then
            objMensajeAdv.mensaje = "Favor de selecionar solo un registro."
            objMensajeAdv.ShowDialog()
        Else
            Dim FormSolicitudAceptada As New PDFAcuseMovimientoBajaIDSEForm
            FormSolicitudAceptada.solicitudId = SolicitudBaja
            FormSolicitudAceptada.colaboradorId = ColaboradorId
            FormSolicitudAceptada.movimiento = "RECHAZADO IDSE"
            FormSolicitudAceptada.ShowDialog()
            GuardoExito = FormSolicitudAceptada.guardado
            CargarGrid()
        End If


    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

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
        HabilitarDeshabilitarControles(False)
        grdSolicitudesBaja.DataSource = Nothing


    End Sub


    Private Sub btnAbajo_Click_2(sender As Object, e As EventArgs) Handles btnAbajo.Click
        Panel3.Height = 163
        grbxFiltros.Height = 136
    End Sub

    Private Sub btnArriba_Click_2(sender As Object, e As EventArgs) Handles btnArriba.Click
        Panel3.Height = 28
        grbxFiltros.Height = 0
    End Sub



    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        'If grdSolicitudesBaja.Rows.Count > 0 Then
        '    imprimirReporte()
        'Else
        '    show_message("Advertencia", "No hay información para generar el reporte.")
        'End If
        imprimirReporteBajas()
    End Sub

    Public Sub imprimirReporteBajas()
        Dim periodo As String = String.Empty
        If grdSolicitudesBaja.Rows.Count > 0 Then

            If chkFiltroFechas.Checked = True Then
                periodo = "Del " & CDate(dtmRangoFechaDel.Text).ToString("dd/MM/yyyy") & " AL: " & CDate(dtmRangoFechaAl.Text).ToString("dd/MM/yyyy")
            Else
                periodo = Date.Now.ToString("yyyy")
            End If



            Dim objReporte As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            Dim reporte As New StiReport
            EntidadReporte = objReporte.LeerReporteporClave("REPORTE_BAJASNF")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & EntidadReporte.Pnombre & ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

            reporte.Load(archivo)
            reporte.Compile()

            Dim dtListado = New DataTable("dtBajas")
            With dtListado
                .Columns.Add("nombre")
                .Columns.Add("nss")
                .Columns.Add("fechaBaja")
                .Columns.Add("fechaSolicitud")
                .Columns.Add("totalFiniquito")
            End With

            For Each item As UltraGridRow In grdSolicitudesBaja.Rows
                dtListado.Rows.Add( _
                item.Cells("Apaterno").Value.ToString() & " " & item.Cells("Amaterno").Value.ToString() & " " & item.Cells("Nombre").Value.ToString(), _
                item.Cells("NSS").Value.ToString(), _
                item.Cells("fechaBaja").Value.ToString(), _
                item.Cells("fechaSolicitud").Value.ToString(), _
                item.Cells("totalFiniquito").Value.ToString()
                )
            Next

            reporte("Empresa") = cmbEmpresa.Text
            reporte("UserName") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            reporte("Periodo") = periodo

            reporte.RegData(dtListado)
            reporte.Show()
        End If


    End Sub

    Public Sub imprimirReporte()
        Dim ObjFiniquitoFiscal As New Contabilidad.Negocios.FiniquitoFiscalBU
        Dim objEntidadesFiniquito As Entidades.FiniquitoFiscal
        Dim FinquitoFiscal As Integer = 0
        Dim dtFiniquitoFiscal As New DataTable
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim entReporte As New Entidades.Reportes
        entReporte = objReporte.LeerReporteporClave("FINIQ_FISCAL")
        Dim DtInformacionEncabezado As DataTable

        dtFiniquitoFiscal.Columns.Add("CodigoEmpleado", Type.GetType("System.String"))
        dtFiniquitoFiscal.Columns.Add("Vacaciones", Type.GetType("System.Double"))
        dtFiniquitoFiscal.Columns.Add("PrimaVacacional", Type.GetType("System.Double"))
        dtFiniquitoFiscal.Columns.Add("Aguinaldo", Type.GetType("System.Double"))
        dtFiniquitoFiscal.Columns.Add("IndemizacionFiniquito", Type.GetType("System.Double"))
        dtFiniquitoFiscal.Columns.Add("RetencionISR", Type.GetType("System.Double"))
        dtFiniquitoFiscal.Columns.Add("NetoRecibir", Type.GetType("System.Double"))
        dtFiniquitoFiscal.Columns.Add("FirmaEmpleado", Type.GetType("System.String"))
        dtFiniquitoFiscal.Columns.Add("Nombre", Type.GetType("System.String"))

        DtInformacionEncabezado = ObjFiniquitoFiscal.ObtenerInformacionEmpresa(NaveID, 0, 0)

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


        For Each fila As UltraGridRow In grdSolicitudesBaja.Rows
            If IsDBNull(fila.Cells("FiniquitoFiscalID").Value) = False And IsNothing(fila.Cells("FiniquitoFiscalID").Value) = False Then
                FinquitoFiscal = fila.Cells("FiniquitoFiscalID").Value
                objEntidadesFiniquito = ObjFiniquitoFiscal.ObtenerFiniquitoFiscal(FinquitoFiscal)
                dtFiniquitoFiscal.Rows.Add(New Object() {objEntidadesFiniquito.InformacionColoaborador.IIClaveTrabajador, objEntidadesFiniquito.TotalVacaciones, objEntidadesFiniquito.PrimaVacacional, objEntidadesFiniquito.TotalAguinaldo, objEntidadesFiniquito.IndemizacionFiniquito, objEntidadesFiniquito.ISRRetenido, objEntidadesFiniquito.NetoRecibir, "", objEntidadesFiniquito.InformacionColoaborador.IINombreCompleto})
            End If
        Next

        reporte("NombreReporte") = "SAY: REPORTE FINIQUITOS FISCALES.mrt"
        reporte("UsuarioCreo") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString.ToUpper + " " + Date.Now.ToLongDateString()


        reporte.Dictionary.Clear()
        reporte.RegData(dtFiniquitoFiscal)
        reporte.Dictionary.Synchronize()
        reporte.Show()
        dtFiniquitoFiscal.Clear()


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

    'Private Sub grdSolicitudesBaja_DragDrop(sender As Object, e As DragEventArgs) Handles grdSolicitudesBaja.DragDrop
    '    Dim dropIndex As Integer

    '    'Get the position on the grid where the dragged row(s) are to be dropped. 
    '    'get the grid coordinates of the row (the drop zone) 
    '    Dim uieOver As UIElement = grdSolicitudesBaja.DisplayLayout.UIElement.ElementFromPoint(grdSolicitudesBaja.PointToClient(New Point(e.X, e.Y)))

    '    'get the row that is the drop zone/or where the dragged row is to be dropped 
    '    Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

    '    If ugrOver IsNot Nothing Then
    '        dropIndex = ugrOver.Index    'index/position of drop zone in grid 

    '        'get the dragged row(s)which are to be dragged to another position in the grid 
    '        Dim SelRows As SelectedRowsCollection = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)
    '        'get the count of selected rows and drop each starting at the dropIndex 
    '        For Each aRow As UltraGridRow In SelRows
    '            'move the selected row(s) to the drop zone 
    '            grdSolicitudesBaja.Rows.Move(aRow, dropIndex)
    '        Next
    '    End If
    'End Sub

    'Private Sub grdSolicitudesBaja_DragOver(sender As Object, e As DragEventArgs) Handles grdSolicitudesBaja.DragOver
    '    e.Effect = DragDropEffects.Move
    '    Dim grid As UltraGrid = TryCast(sender, UltraGrid)
    '    Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

    '    If pointInGridCoords.Y < 20 Then
    '        'Scroll up
    '        Me.grdSolicitudesBaja.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
    '    ElseIf pointInGridCoords.Y > grid.Height - 20 Then
    '        'Scroll down
    '        Me.grdSolicitudesBaja.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
    '    End If
    'End Sub

    'Private Sub grdSolicitudesBaja_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdSolicitudesBaja.SelectionDrag
    '    grdSolicitudesBaja.DoDragDrop(grdSolicitudesBaja.Selected.Rows, DragDropEffects.Move)
    'End Sub
End Class