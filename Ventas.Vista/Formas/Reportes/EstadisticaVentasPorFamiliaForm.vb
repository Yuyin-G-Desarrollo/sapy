Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraCharts

Public Class EstadisticaVentasPorFamiliaForm

    Dim listInicial As New List(Of String)
    Dim filtro_Cliente As String = String.Empty
    Dim filtro_Agente As String = String.Empty
    Dim filtro_FechaInicio As String = String.Empty
    Dim filtro_FechaFin As String = String.Empty
    Dim inicial As Integer = 0
    Dim conFiltros As Boolean = False
    Dim dtDatosGraficaConsultaAnual As New System.Data.DataTable
    Dim lstDatosGraficaConsultaPorMarca As New List(Of System.Data.DataTable)
    Dim perfilUsuario As Integer = 0

    Private Sub EstadisticaVentasPorFamiliaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objBU As New Negocios.EstadisticaVentasFamiliaBU
        Dim objResumenVentasBU As New Negocios.ResumenVentasSemanalBU
        Dim dtResultadoPerfil As New DataTable
        dtpFechaEntregaDel.MinDate = Date.Parse("01/01/2015")
        dtpFechaEntregaAl.MinDate = Date.Parse("01/01/2015")
        'dtpFechaEntregaDel.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
        'dtpFechaEntregaAl.Value = Date.Parse("31/12/" + Date.Now.Year.ToString())
        dtpFechaEntregaDel.Value = objResumenVentasBU.ConsultarFechaInicioEstadVentas_Semanal()
        dtpFechaEntregaAl.Value = objResumenVentasBU.ConsultarFechaFinEstadVentas_Semanal()

        dtpFechaInicioConsultas.MinDate = Date.Parse("01/01/2012")
        dtpFechaFinConsultas.MinDate = Date.Parse("01/01/" + (Date.Now.Year - 4).ToString())
        dtpFechaFinConsultas.Value = Date.Parse("31/12/" + (Date.Now.Year - 1).ToString())
        dtpFechaInicioConsultas.Value = Date.Parse("01/01/" + (Date.Now.Year - 5).ToString())

        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized
        grdClientes.DataSource = listInicial
        grdAgentes.DataSource = listInicial
        cmboxTipoReporte.SelectedIndex = 0

        dtResultadoPerfil = objBU.reporteEstadisticaFamliasObtenerPerfilUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        If dtResultadoPerfil.Rows.Count > 0 Then
            perfilUsuario = dtResultadoPerfil.Rows(0).Item("IdPerfil")
            If dtResultadoPerfil.Rows(0).Item("IdPerfil") = 44 Then
                grpBoxAgente.Enabled = False

                Dim objeBU As New Negocios.EstadisticoPedidosBU
                Dim Tabla_ListadoParametros As New DataTable

                Tabla_ListadoParametros = objeBU.ListadoParametrosReportes(8, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)
                grdAgentes.DataSource = Tabla_ListadoParametros

                With grdAgentes
                    .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Agente de Ventas"
                    .DisplayLayout.Bands(0).Columns(0).Hidden = True
                    .DisplayLayout.Bands(0).Columns(1).Hidden = True
                End With

                Exit Sub

            End If
        End If

    End Sub

#Region "Filtros"

    Private Sub dtpFechaEntregaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaEntregaDel.ValueChanged
        If dtpFechaEntregaAl.MinDate > "31/12/" + dtpFechaEntregaDel.Value.Year.ToString() Then
            dtpFechaEntregaAl.MinDate = dtpFechaEntregaDel.Value
            dtpFechaEntregaAl.MaxDate = "31/12/" + dtpFechaEntregaDel.Value.Year.ToString()
        Else
            dtpFechaEntregaAl.MaxDate = "31/12/" + dtpFechaEntregaDel.Value.Year.ToString()
            dtpFechaEntregaAl.MinDate = dtpFechaEntregaDel.Value
        End If
        txtAñoComparacion.Text = (dtpFechaEntregaDel.Value.Year - 1).ToString()
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametrosReportesForm
        If perfilUsuario <> 44 And perfilUsuario <> 74 Then
            listado.tipo_busqueda = 2
        Else
            listado.tipo_busqueda = 4
        End If

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = System.Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdClientes.DataSource = listado.listParametros
        With grdClientes
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
        End With
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdClientes.DataSource = listInicial
    End Sub

    Private Sub grdClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdClientes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        grid_diseño(grdClientes)
        grdClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub btnAgente_Click(sender As Object, e As EventArgs) Handles btnAgente.Click
        Dim listado As New ListadoParametrosReportesForm
        listado.tipo_busqueda = 1

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdAgentes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = System.Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdAgentes.DataSource = listado.listParametros
        With grdAgentes
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Agente de Ventas"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With

    End Sub

    Private Sub btnLimpiarFiltroAgente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroAgente.Click
        grdAgentes.DataSource = listInicial
    End Sub

    Private Sub grdAgentes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdAgentes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdAgentes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAgentes.InitializeLayout
        grid_diseño(grdAgentes)
        grdAgentes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Agente de Ventas"
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        'For Each row In grid.Rows
        '    row.Activation = Activation.NoEdit
        'Next

        asignaFormato_Columna(grid)

    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("String") Then

                If col.Header.Caption.Equals("Télefono") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("Extensión") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If

            End If
        Next
    End Sub

    Private Sub dtpFechaInicioConsultas_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicioConsultas.ValueChanged
        If inicial <> 0 Then
            dtpFechaFinConsultas.MinDate = "01/01/" + (dtpFechaInicioConsultas.Value.Year + 1).ToString()
        Else
            inicial = 1
        End If
    End Sub

#End Region

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 206
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdReporteEstadisticoFamilias.DataSource = Nothing
        bgvReporteEstadisticoFamilias.Bands.Clear()
        bgvReporteEstadisticoFamilias.Columns.Clear()

        grdConsultaAnual.DataSource = Nothing
        bgvConsultaAnual.Bands.Clear()
        bgvConsultaAnual.Columns.Clear()

        grdConsultaMarca.DataSource = Nothing
        bgvConsultaMarca.Bands.Clear()
        bgvConsultaMarca.Columns.Clear()

        chrConsultaAnual.Series.Clear()
        chrConsultaMarca.Series.Clear()

        grdClientes.DataSource = listInicial

        If perfilUsuario <> 44 Then
            grdAgentes.DataSource = listInicial
        End If
        dtpFechaEntregaAl.Value = Date.Parse("31/12/" + Date.Now.Year.ToString())
        dtpFechaEntregaDel.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())

        dtpFechaFinConsultas.Value = Date.Parse("31/12/" + (Date.Now.Year - 1).ToString())
        dtpFechaInicioConsultas.Value = Date.Parse("01/01/" + (Date.Now.Year - 5).ToString())

        cmboxTipoReporte.SelectedIndex = 0

        lblFechaUltimaActualización.Text = "-"
        btnAbajo_Click(sender, e)
    End Sub


    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Cursor = Cursors.WaitCursor



        Select Case cmboxTipoReporte.SelectedIndex
            Case 0

                ObtenerReporteEstadisticaVentasFamilia()

            Case 1

                chrConsultaAnual.Series.Clear()
                chrConsultaMarca.Series.Clear()

                ObtenerReporteCosultasAnualYMarcas(1)

                ObtenerReporteCosultasAnualYMarcas(2)

            Case 2

                ObtenerReporteEstadisticaPreVentasFamilia()

        End Select


        Cursor = Cursors.Default
    End Sub

#Region "Reporte Estadistica Ventas Familia"

    Private Sub ObtenerReporteEstadisticaVentasFamilia()
        Dim objBU As New Negocios.EstadisticaVentasFamiliaBU
        Dim dtResultadoReporte As New System.Data.DataTable
        Dim spid As Integer = 0

        If obtenerFiltros() = False Then
            Return
        End If
        dtResultadoReporte = objBU.reporteEstadisticaVentasPorFamilia(filtro_FechaInicio, filtro_FechaFin, filtro_Cliente, filtro_Agente, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        If dtResultadoReporte.Rows.Count > 0 Then

            lblFechaUltimaActualización.Text = DateTime.Now.ToString()

            spid = Integer.Parse(dtResultadoReporte.Rows(0).Item("spid").ToString())

            grdReporteEstadisticoFamilias.DataSource = Nothing

            diseñoGridResultado(spid)

            'dtResultadoReporte.Rows(dtResultadoReporte.Rows.Count - 1).Item("TOTAL") = dtResultadoReporte.Rows(dtResultadoReporte.Rows.Count - 1).Item(dtResultadoReporte.Columns(dtResultadoReporte.Columns.Count - 2).ColumnName.ToString())

            grdReporteEstadisticoFamilias.DataSource = dtResultadoReporte

            btnArriba_Click(Nothing, Nothing)
        Else
            grdReporteEstadisticoFamilias.DataSource = Nothing
            bgvReporteEstadisticoFamilias.Bands.Clear()
            bgvReporteEstadisticoFamilias.Columns.Clear()
            show_message("Aviso", "No hay datos para mostrar.")
        End If
    End Sub

    Private Function obtenerFiltros() As Boolean
        filtro_Cliente = ""
        filtro_Agente = ""
        conFiltros = False

        If grpEstadisticaVentas.Visible = True Then
            filtro_FechaInicio = dtpFechaEntregaDel.Value.ToShortDateString()
            filtro_FechaFin = dtpFechaEntregaAl.Value.ToShortDateString()
        Else
            filtro_FechaInicio = dtpFechaInicioConsultas.Value.ToShortDateString()
            filtro_FechaFin = dtpFechaFinConsultas.Value.ToShortDateString()
        End If

        For Each Row As UltraGridRow In grdClientes.Rows
            If filtro_Cliente <> "" Then
                filtro_Cliente += ","
            End If
            filtro_Cliente += Row.Cells("Parametro").Value.ToString()
        Next
        For Each Row As UltraGridRow In grdAgentes.Rows
            If filtro_Agente <> "" Then
                filtro_Agente += ","
            End If
            filtro_Agente += Row.Cells("Parametro").Value.ToString()
        Next


        If perfilUsuario = 74 Then

            If filtro_Cliente <> "" And filtro_Agente <> "" Then
                Return True
            Else
                show_message("Advertencia", "Es necesario seleccionar al menos un agente y un cliente")
                Return False
            End If
        End If

        If filtro_Cliente <> "" Then
            conFiltros = True
        End If
        Return True
    End Function

    Private Sub diseñoGridResultado(ByVal spid As Integer)
        Dim objBu As New Negocios.EstadisticaVentasFamiliaBU
        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim listBandsTextos As New List(Of String)
        Dim listBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)

        Dim dtEncabezados As New System.Data.DataTable

        dtEncabezados = objBu.reporteEstadisticaFamliasObtenerEncabezadosTabla(spid)

        bgvReporteEstadisticoFamilias.OptionsView.AllowCellMerge = True
        bgvReporteEstadisticoFamilias.Columns.Clear()
        bgvReporteEstadisticoFamilias.Bands.Clear()

        grdReporteEstadisticoFamilias.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        grdReporteEstadisticoFamilias.LookAndFeel.UseDefaultLookAndFeel = False
        bgvReporteEstadisticoFamilias.Appearance.HeaderPanel.Options.UseBackColor = True

        For Each row As DataRow In dtEncabezados.Rows
            If listBandsTextos.Contains(row.Item("Semestre").ToString()) = False Then
                listBandsTextos.Add(row.Item("Semestre").ToString())

                band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                band.Caption = row.Item("Semestre").ToString()
                listBands.Add(band)
            End If

            For Each gridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In listBands
                If gridBand.Caption = "" Then
                    If IsNothing(bgvReporteEstadisticoFamilias.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
                        bgvReporteEstadisticoFamilias.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
                        bgvReporteEstadisticoFamilias.Columns.ColumnByFieldName("#").OwnerBand = gridBand
                        AddHandler bgvReporteEstadisticoFamilias.CustomUnboundColumnData, AddressOf bgvReporteEstadisticoFamilias_CustomUnboundColumnData
                        bgvReporteEstadisticoFamilias.Columns.Item("#").VisibleIndex = 0
                    End If
                End If
                If row("Semestre").ToString() = gridBand.Caption Then
                    bgvReporteEstadisticoFamilias.Columns.AddField(row.Item("Mes").ToString().ToUpper)
                    bgvReporteEstadisticoFamilias.Columns.ColumnByFieldName(row.Item("Mes").ToString().ToUpper).OwnerBand = gridBand
                    bgvReporteEstadisticoFamilias.Columns.ColumnByFieldName(row.Item("Mes").ToString().ToUpper).Visible = True
                    If row.Item("Mes").ToString().ToUpper <> "CLIENTE" And row.Item("Mes").ToString().ToUpper <> "AÑO" And row.Item("Mes").ToString().ToUpper <> "FAMILIA" Then
                        bgvReporteEstadisticoFamilias.Columns.ColumnByFieldName(row.Item("Mes").ToString().ToUpper).OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                    End If
                    If row.Item("Mes").ToString().ToUpper <> "CLIENTE" And row.Item("Mes").ToString().ToUpper <> "AÑO" And row.Item("Mes").ToString().ToUpper <> "FAMILIA" Then
                        bgvReporteEstadisticoFamilias.Columns.ColumnByFieldName(row.Item("Mes").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                        bgvReporteEstadisticoFamilias.Columns.ColumnByFieldName(row.Item("Mes").ToString().ToUpper).DisplayFormat.FormatString = "N0"
                    End If
                    If row.Item("Mes").ToString.ToUpper.Contains("TOTAL") Or row.Item("Mes").ToString.ToUpper.Contains("ART") Then
                        bgvReporteEstadisticoFamilias.Columns.ColumnByFieldName(row.Item("Mes").ToString().ToUpper).AppearanceCell.Font = New System.Drawing.Font(bgvReporteEstadisticoFamilias.Columns.ColumnByFieldName(row.Item("Mes").ToString().ToUpper).AppearanceCell.Font, FontStyle.Bold)
                    End If
                End If
            Next
        Next
        For Each gridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In listBands
            If gridBand.Caption = "" Then
                gridBand.Caption = "Última actualización: " + lblFechaUltimaActualización.Text
            End If
            If gridBand.Caption = "-" Then
                gridBand.Caption = ""
            End If
            bgvReporteEstadisticoFamilias.Bands.Add(gridBand)
        Next
        For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In bgvReporteEstadisticoFamilias.Bands
            gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            If gridband.Caption.ToString.ToUpper.Contains("1") And gridband.Caption.ToString.Contains("Última") = False Then
                gridband.AppearanceHeader.BackColor = Color.FromArgb(198, 224, 180)
            ElseIf gridband.Caption.ToString.ToUpper.Contains("2") And gridband.Caption.ToString.Contains("Última") = False Then
                gridband.AppearanceHeader.BackColor = Color.FromArgb(225, 242, 204)
            End If
        Next

        bgvReporteEstadisticoFamilias.Bands(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        'bgvReporteEstadisticoFamilias.ColumnPanelRowHeight = 40


        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvReporteEstadisticoFamilias.Columns
            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'Col.BestFit()
            If Col.FieldName = "#" Then
                Col.Width = 30
            End If
            If Col.FieldName = "CLIENTE" Then
                Col.Width = 150
            End If
            If Col.FieldName = "AÑO" Then
                Col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                Col.Width = 31
            End If
            If Col.FieldName = "FAMILIA" Then
                Col.Width = 162
            End If
            If Col.FieldName = "TOTAL ANUAL" Then
                Col.Width = 63
            End If
            If Col.FieldName.ToUpper.Contains("ART") Then
                Col.Width = 45
            End If
            If Col.FieldName <> "#" And Col.FieldName <> "CLIENTE" And Col.FieldName <> "FAMILIA" And Col.FieldName <> "TOTAL ANUAL" And Col.FieldName <> "AÑO" And Col.FieldName.ToUpper.Contains("ART") = False Then
                Col.Width = 58
            End If
            If Col.FieldName.Contains(" S1") Then
                Col.Caption = Col.FieldName.Replace(" S1", "")
            End If
            If Col.FieldName.Contains(" S2") Then
                Col.Caption = Col.FieldName.Replace(" S2", "")
            End If

        Next


    End Sub

    Private Sub bgvReporteEstadisticoFamilias_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = bgvReporteEstadisticoFamilias.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

#End Region

#Region "Reportes Consulta Anual y Marcas"

    Private Sub ObtenerReporteCosultasAnualYMarcas(ByVal TipoReporte As Integer)
        Dim objBU As New Negocios.EstadisticaVentasFamiliaBU
        Dim listEncabezados As New List(Of String)
        Dim dtResultadoReporte As New System.Data.DataTable

        If obtenerFiltros() = False Then
            Return
        End If

        dtResultadoReporte = objBU.reporteEstadisticaVentasPorFamiliaConsultaAnualYMarca(filtro_FechaInicio, filtro_FechaFin, filtro_Cliente, filtro_Agente, TipoReporte, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        If dtResultadoReporte.Rows.Count > 0 Then

            lblFechaUltimaActualización.Text = DateTime.Now.ToString()

            If TipoReporte = 1 Then 'Consulta anual

                grdConsultaAnual.DataSource = Nothing

                grdConsultaAnual.DataSource = dtResultadoReporte

                generarTablaGraficaConsultaAnual(dtResultadoReporte)
                generarGraficaConsultaAnual()

            Else 'Consulta Marca

                grdConsultaMarca.DataSource = Nothing

                grdConsultaMarca.DataSource = dtResultadoReporte

                generarTablasGraficaConsultaPorMarca(dtResultadoReporte)
                generarGraficaConsultaPorMarca()

            End If

            For Each col As DataColumn In dtResultadoReporte.Columns
                listEncabezados.Add(col.ColumnName)
            Next

            diseñoGridResultadoAnualYMarcas(listEncabezados, TipoReporte)

            btnArriba_Click(Nothing, Nothing)
        Else
            If TipoReporte = 1 Then 'Consulta anual

                grdConsultaAnual.DataSource = Nothing
                bgvConsultaAnual.Bands.Clear()
                bgvConsultaAnual.Columns.Clear()

            Else 'Consulta Marca

                grdConsultaMarca.DataSource = Nothing
                bgvConsultaMarca.Bands.Clear()
                bgvConsultaMarca.Columns.Clear()

            End If

            show_message("Aviso", "No hay datos para mostrar.")

        End If
    End Sub

    Private Sub diseñoGridResultadoAnualYMarcas(ByVal lstEncabezados As List(Of String), ByVal TipoReporte As Integer)
        Dim objBu As New Negocios.EstadisticaVentasFamiliaBU


        If TipoReporte = 1 Then
            bgvConsultaAnual.Columns.Clear()
            bgvConsultaAnual.Bands.Clear()

            bgvConsultaAnual.Bands.Add()
            bgvConsultaAnual.Bands.Add()

            bgvConsultaAnual.Bands(1).Caption = lblTextoUltimaActualizacion.Text + " " + lblFechaUltimaActualización.Text

            If IsNothing(bgvConsultaAnual.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
                bgvConsultaAnual.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
                bgvConsultaAnual.Columns.ColumnByFieldName("#").OwnerBand = bgvConsultaAnual.Bands(0)
                AddHandler bgvConsultaAnual.CustomUnboundColumnData, AddressOf bgvConsultaAnual_CustomUnboundColumnData
                bgvConsultaAnual.Columns.Item("#").VisibleIndex = 0
                bgvConsultaAnual.Columns.ColumnByFieldName("#").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                bgvConsultaAnual.Columns.ColumnByFieldName("#").Width = "30"
            End If

            For Each encabezado As String In lstEncabezados
                bgvConsultaAnual.Columns.AddField(encabezado)
                If encabezado <> "CLIENTE" Then
                    bgvConsultaAnual.Columns.ColumnByFieldName(encabezado).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                    bgvConsultaAnual.Columns.ColumnByFieldName(encabezado).DisplayFormat.FormatString = "N0"
                    bgvConsultaAnual.Columns.ColumnByFieldName(encabezado).OwnerBand = bgvConsultaAnual.Bands(1)
                Else
                    bgvConsultaAnual.Columns.ColumnByFieldName(encabezado).OwnerBand = bgvConsultaAnual.Bands(0)
                    If filtro_Cliente = "" Or filtro_Cliente.Contains(",") And encabezado = "CLIENTE" Then
                        bgvConsultaAnual.Columns.ColumnByFieldName(encabezado).Width = "90"
                    Else
                        bgvConsultaAnual.Columns.ColumnByFieldName(encabezado).Width = "150"
                    End If
                End If
                If encabezado <> "ORDEN" Then
                    bgvConsultaAnual.Columns.ColumnByFieldName(encabezado).Visible = True
                Else
                    bgvConsultaAnual.Columns.ColumnByFieldName(encabezado).Visible = False
                End If
                If encabezado = "TOTAL" Then
                    bgvConsultaAnual.Columns.ColumnByFieldName(encabezado).AppearanceCell.Font = New System.Drawing.Font(bgvConsultaAnual.Columns.ColumnByFieldName(encabezado).AppearanceCell.Font, FontStyle.Bold)
                End If
                bgvConsultaAnual.Columns.ColumnByFieldName(encabezado).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Next

            bgvConsultaAnual.Bands(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Else

            bgvConsultaMarca.Columns.Clear()
            bgvConsultaMarca.Bands.Clear()

            bgvConsultaMarca.Bands.Add()
            bgvConsultaMarca.Bands.Add()

            bgvConsultaMarca.Bands(1).Caption = lblTextoUltimaActualizacion.Text + " " + lblFechaUltimaActualización.Text

            If IsNothing(bgvConsultaMarca.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
                bgvConsultaMarca.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
                bgvConsultaMarca.Columns.ColumnByFieldName("#").OwnerBand = bgvConsultaMarca.Bands(0)
                AddHandler bgvConsultaMarca.CustomUnboundColumnData, AddressOf bgvConsultaMarca_CustomUnboundColumnData
                bgvConsultaMarca.Columns.Item("#").VisibleIndex = 0
                bgvConsultaMarca.Columns.ColumnByFieldName("#").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                bgvConsultaMarca.Columns.ColumnByFieldName("#").Width = "30"
            End If

            For Each encabezado As String In lstEncabezados
                bgvConsultaMarca.Columns.AddField(encabezado)
                If encabezado <> "MARCA" Then
                    bgvConsultaMarca.Columns.ColumnByFieldName(encabezado).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                    bgvConsultaMarca.Columns.ColumnByFieldName(encabezado).DisplayFormat.FormatString = "N0"
                    bgvConsultaMarca.Columns.ColumnByFieldName(encabezado).OwnerBand = bgvConsultaMarca.Bands(1)
                Else
                    bgvConsultaMarca.Columns.ColumnByFieldName(encabezado).OwnerBand = bgvConsultaMarca.Bands(0)
                    If encabezado = "MARCA" Then
                        bgvConsultaMarca.Columns.ColumnByFieldName(encabezado).Width = "90"
                    End If
                End If
                If encabezado <> "ORDEN" Then
                    bgvConsultaMarca.Columns.ColumnByFieldName(encabezado).Visible = True
                Else
                    bgvConsultaMarca.Columns.ColumnByFieldName(encabezado).Visible = False
                End If
                If encabezado = "TOTAL" Then
                    bgvConsultaMarca.Columns.ColumnByFieldName(encabezado).AppearanceCell.Font = New System.Drawing.Font(bgvConsultaMarca.Columns.ColumnByFieldName(encabezado).AppearanceCell.Font, FontStyle.Bold)
                End If
                bgvConsultaMarca.Columns.ColumnByFieldName(encabezado).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Next

            bgvConsultaMarca.Bands(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        End If

    End Sub

    Private Sub bgvConsultaAnual_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = bgvConsultaAnual.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub bgvConsultaMarca_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = bgvConsultaMarca.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub bgvConsultaAnual_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles bgvConsultaAnual.CustomDrawCell

        Dim currentView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)

        Try
            'Cursor = Cursors.WaitCursor
            If e.Column.FieldName <> "CLIENTE" And e.Column.FieldName <> "#" Then
                If IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Or IsNothing(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                    If currentView.GetRowCellValue(e.RowHandle, "CLIENTE").ToString().Contains("CRECIMIENTO") = False Then
                        currentView.SetRowCellValue(e.RowHandle, e.Column.FieldName, 0)
                        e.DisplayText = 0
                    End If
                End If
                If currentView.GetRowCellValue(e.RowHandle, "CLIENTE").ToString().Contains("CRECIMIENTO") Then
                    If e.Column.FieldName.Contains("TOTAL") = False And e.Column.FieldName.Contains(dtpFechaInicioConsultas.Value.Year.ToString) = False Then
                        If IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) = False Then
                            e.Appearance.BackColor = ObtenerColorCeldaValoresCrecimiento(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                            e.Appearance.ForeColor = ObtenerColorLetraValoresCrecimiento(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                            e.DisplayText = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.DisplayText.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
                            e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, FontStyle.Bold)
                        End If
                    End If
                End If
            Else
                If e.Column.FieldName = "CLIENTE" Then
                    If currentView.GetRowCellValue(e.RowHandle, "CLIENTE").ToString().Contains("CRECIMIENTO") Then
                        e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, FontStyle.Bold)
                    End If
                End If

            End If

            'Cursor = Cursors.Default
        Catch ex As Exception
            'Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
        'End If


    End Sub

    Private Sub bgvConsultaMarca_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles bgvConsultaMarca.CustomDrawCell

        Dim currentView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)

        Try
            'Cursor = Cursors.WaitCursor
            If e.Column.FieldName <> "MARCA" And e.Column.FieldName <> "#" Then
                If IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Or IsNothing(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                    currentView.SetRowCellValue(e.RowHandle, e.Column.FieldName, 0)
                    e.DisplayText = 0
                End If
                If e.Column.FieldName.Contains("TOTAL") Then
                    If IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) = False Then
                        e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, FontStyle.Bold)
                    End If
                End If
                If e.Column.FieldName.Contains("CREC") Then
                    e.Appearance.BackColor = ObtenerColorCeldaValoresCrecimiento(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                    e.Appearance.ForeColor = ObtenerColorLetraValoresCrecimiento(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                    e.DisplayText = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.DisplayText.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
                End If
            End If
            If currentView.GetRowCellValue(e.RowHandle, "MARCA").ToString().Contains("TOTAL") And e.Column.FieldName <> "#" Then
                e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, FontStyle.Bold)
            End If

            'Cursor = Cursors.Default
        Catch ex As Exception
            'Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
        'End If


    End Sub

    Private Sub generarTablaGraficaConsultaAnual(ByVal ResultadoReporte As System.Data.DataTable)
        dtDatosGraficaConsultaAnual = New System.Data.DataTable

        dtDatosGraficaConsultaAnual.Columns.Add("CLIENTE", GetType(String))
        dtDatosGraficaConsultaAnual.Columns.Add("Año", GetType(String))
        dtDatosGraficaConsultaAnual.Columns.Add("Valor", GetType(Int32))

        For Each col As DataColumn In ResultadoReporte.Columns
            If col.ColumnName <> "CLIENTE" And col.ColumnName.Contains("TOTAL") = False Then
                dtDatosGraficaConsultaAnual.Rows.Add(ResultadoReporte.Rows(0)(0), col.ColumnName, If(IsDBNull(ResultadoReporte.Rows(0)(col)), 0, ResultadoReporte.Rows(0)(col)))
            End If
        Next

    End Sub

    Private Sub generarGraficaConsultaAnual()

        chrConsultaAnual.Series.Clear()

        ' Create an empty Bar series and add it to the chart.
        Dim serie As New DevExpress.XtraCharts.Series(dtDatosGraficaConsultaAnual.Rows(0)(0), ViewType.Line)
        chrConsultaAnual.Series.Add(serie)

        ' Generate a data table and bind the series to it.
        serie.DataSource = dtDatosGraficaConsultaAnual

        ' Specify data members to bind the series.
        serie.ArgumentScaleType = ScaleType.Auto
        serie.ArgumentDataMember = "Año"
        serie.ValueScaleType = ScaleType.Numerical
        serie.ValueDataMembers.AddRange(New String() {"Valor"})
        serie.CrosshairLabelPattern = "{S} : {V:#,#}"

        ' Set some properties to get a nice-looking chart.
        CType(chrConsultaAnual.Diagram, XYDiagram).AxisY.Visibility = DevExpress.Utils.DefaultBoolean.True
        CType(chrConsultaAnual.Diagram, XYDiagram).AxisY.Label.TextPattern = "{V:#,#}"
        CType(chrConsultaAnual.Diagram, XYDiagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Year
        'CType(chrConsultaAnual.Diagram, XYDiagram).AxisX.Label.TextPattern = "{A}:{V:#,#}"
        chrConsultaAnual.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False

        'For Each Point As SeriesPoint In series.Points
        '    Dim annotation = Point.Annotations.AddTextAnnotation(Point.Argument, Point.Values(0).ToString("N0"))
        '    Dim position As New DevExpress.XtraCharts.RelativePosition()
        '    position.Angle = 0
        '    position.ConnectorLength = 0
        '    annotation.ShapePosition = position
        '    annotation.Border.Visibility = DevExpress.Utils.DefaultBoolean.False
        '    annotation.ConnectorStyle = AnnotationConnectorStyle.None
        '    annotation.BackColor = Color.Transparent

        'Next

    End Sub



    Private Sub generarTablasGraficaConsultaPorMarca(ByVal ResultadoReporte As System.Data.DataTable)

        lstDatosGraficaConsultaPorMarca = New List(Of System.Data.DataTable)

        For Each row As DataRow In ResultadoReporte.Rows
            If row.Item("MARCA").ToString.Contains("TOTAL") = False Then

                Dim dtDatosGraficaConsultaPorMarca As New System.Data.DataTable

                dtDatosGraficaConsultaPorMarca.Columns.Add("Marca", GetType(String))
                dtDatosGraficaConsultaPorMarca.Columns.Add("Año", GetType(String))
                dtDatosGraficaConsultaPorMarca.Columns.Add("Valor", GetType(Int32))

                For Each col As DataColumn In ResultadoReporte.Columns
                    If col.ColumnName <> "ORDEN" And col.ColumnName <> "MARCA" And col.ColumnName.Contains("TOTAL") = False And col.ColumnName.Contains("CREC") = False Then
                        dtDatosGraficaConsultaPorMarca.Rows.Add(row.Item("MARCA").ToString, col.ColumnName, If(IsDBNull(row.Item(col)), 0, row.Item(col)))
                    End If
                Next

                lstDatosGraficaConsultaPorMarca.Add(dtDatosGraficaConsultaPorMarca)

            End If
        Next

    End Sub

    Private Sub generarGraficaConsultaPorMarca()

        chrConsultaMarca.Series.Clear()

        For Each dt As System.Data.DataTable In lstDatosGraficaConsultaPorMarca

            ' Create an empty Bar series and add it to the chart.
            Dim serie As New DevExpress.XtraCharts.Series(dt.Rows(0)(0).ToString, ViewType.Line)
            chrConsultaMarca.Series.Add(serie)

            ' Generate a data table and bind the series to it.
            serie.DataSource = dt

            ' Specify data members to bind the series.
            serie.ArgumentScaleType = ScaleType.Auto
            serie.ArgumentDataMember = "Año"
            serie.ValueScaleType = ScaleType.Numerical
            serie.ValueDataMembers.AddRange(New String() {"Valor"})
            serie.CrosshairLabelPattern = "{S} : {V:#,#}"

            ' Set some properties to get a nice-looking chart.
            CType(chrConsultaMarca.Diagram, XYDiagram).AxisY.Visibility = DevExpress.Utils.DefaultBoolean.True
            CType(chrConsultaMarca.Diagram, XYDiagram).AxisY.Label.TextPattern = "{V:#,#}"
            CType(chrConsultaMarca.Diagram, XYDiagram).AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Year
            'chrConsultaMarca.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False

        Next

    End Sub


    Private Sub chrConsultaAnual_CustomDrawSeries(sender As Object, e As CustomDrawSeriesEventArgs) Handles chrConsultaAnual.CustomDrawSeries

        For Each Point As SeriesPoint In e.Series.Points

            Dim annotation = Point.Annotations.AddTextAnnotation(Point.Argument, Point.Values(0).ToString("N0"))
            Dim position As New DevExpress.XtraCharts.RelativePosition()
            position.Angle = 0
            position.ConnectorLength = 0
            annotation.ShapePosition = position
            annotation.Border.Visibility = DevExpress.Utils.DefaultBoolean.False
            annotation.ConnectorStyle = AnnotationConnectorStyle.None
            annotation.BackColor = Color.Transparent

        Next

    End Sub



#End Region

#Region "Reporte Estadistica Preventas Familia"

    Private Sub ObtenerReporteEstadisticaPreVentasFamilia()
        Dim objBU As New Negocios.EstadisticaVentasFamiliaBU
        Dim dtResultadoReporte As New System.Data.DataTable
        Dim spid As Integer = 0

        If obtenerFiltros() = False Then
            Return
        End If
        dtResultadoReporte = objBU.reporteEstadisticaPreventasPorFamilia(filtro_FechaInicio, filtro_FechaFin, filtro_Cliente, filtro_Agente, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        If dtResultadoReporte.Rows.Count > 0 Then

            lblFechaUltimaActualización.Text = DateTime.Now.ToString()

            spid = Integer.Parse(dtResultadoReporte.Rows(0).Item("SPID").ToString())

            grdReporteEstadisticoFamilias.DataSource = Nothing

            diseñoGridResultadoPreventas(spid)

            'dtResultadoReporte.Rows(dtResultadoReporte.Rows.Count - 1).Item("TOTAL") = dtResultadoReporte.Rows(dtResultadoReporte.Rows.Count - 1).Item(dtResultadoReporte.Columns(dtResultadoReporte.Columns.Count - 2).ColumnName.ToString())

            grdReporteEstadisticoFamilias.DataSource = dtResultadoReporte

            btnArriba_Click(Nothing, Nothing)
        Else
            grdReporteEstadisticoFamilias.DataSource = Nothing
            bgvReporteEstadisticoFamilias.Bands.Clear()
            bgvReporteEstadisticoFamilias.Columns.Clear()
            show_message("Aviso", "No hay datos para mostrar.")
        End If
    End Sub

    Private Sub diseñoGridResultadoPreventas(ByVal spid As Integer)

        Dim objBu As New Negocios.EstadisticaVentasFamiliaBU
        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim listBandsTextos As New List(Of String)
        Dim listBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        Dim nombreColumna As String = String.Empty
        Dim textoColumna As String = String.Empty

        Dim dtEncabezados As New System.Data.DataTable

        dtEncabezados = objBu.reporteEstadisticaPreventasFamliasObtenerEncabezadosTabla(spid)

        bgvReporteEstadisticoFamilias.OptionsView.AllowCellMerge = False
        bgvReporteEstadisticoFamilias.Columns.Clear()
        bgvReporteEstadisticoFamilias.Bands.Clear()

        For Each row As DataRow In dtEncabezados.Rows
            If listBandsTextos.Contains(row.Item("Año").ToString()) = False Then
                listBandsTextos.Add(row.Item("Año").ToString())

                band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                band.Caption = row.Item("Año").ToString()
                listBands.Add(band)
            End If
        Next

        For Each row As DataRow In dtEncabezados.Rows
            'If listBandsTextos.Contains(row.Item("Año").ToString()) = False Then
            '    listBandsTextos.Add(row.Item("Año").ToString())

            '    band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            '    band.Caption = row.Item("Año").ToString()
            '    listBands.Add(band)
            'End If

            For Each gridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In listBands
                If gridBand.Caption = "" Then
                    If IsNothing(bgvReporteEstadisticoFamilias.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
                        bgvReporteEstadisticoFamilias.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
                        bgvReporteEstadisticoFamilias.Columns.ColumnByFieldName("#").OwnerBand = gridBand
                        AddHandler bgvReporteEstadisticoFamilias.CustomUnboundColumnData, AddressOf bgvReporteEstadisticoFamilias_CustomUnboundColumnData
                        bgvReporteEstadisticoFamilias.Columns.Item("#").VisibleIndex = 0
                        bgvReporteEstadisticoFamilias.Columns("#").Width = "40"
                    End If
                End If
                If row("Año").ToString() = gridBand.Caption Then
                    nombreColumna = row.Item("Concepto").ToString().ToUpper
                    If row.Item("Concepto").ToString().ToUpper <> "FAMILIA" Then
                        textoColumna = Split(nombreColumna, ",")(1)
                    Else
                        textoColumna = Split(nombreColumna, ",")(0)
                    End If
                    bgvReporteEstadisticoFamilias.Columns.AddField(nombreColumna)
                    bgvReporteEstadisticoFamilias.Columns.ColumnByFieldName(nombreColumna).OwnerBand = gridBand
                    bgvReporteEstadisticoFamilias.Columns.ColumnByFieldName(nombreColumna).Visible = True
                    bgvReporteEstadisticoFamilias.Columns.ColumnByFieldName(nombreColumna).Caption = textoColumna
                    If nombreColumna <> "FAMILIA" Then
                        bgvReporteEstadisticoFamilias.Columns.ColumnByFieldName(nombreColumna).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                        bgvReporteEstadisticoFamilias.Columns.ColumnByFieldName(nombreColumna).DisplayFormat.FormatString = "N0"
                    Else
                        bgvReporteEstadisticoFamilias.Columns.ColumnByFieldName(nombreColumna).Width = 200
                    End If
                    If gridBand.Caption.Contains("TOTAL") Then
                        bgvReporteEstadisticoFamilias.Columns.ColumnByFieldName(nombreColumna).AppearanceCell.Font = New System.Drawing.Font(bgvReporteEstadisticoFamilias.Columns.ColumnByFieldName(nombreColumna).AppearanceCell.Font, FontStyle.Bold)
                    End If
                    bgvReporteEstadisticoFamilias.Columns.ColumnByFieldName(nombreColumna).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                End If
            Next
        Next
        For Each gridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In listBands
            If gridBand.Caption = "" Then
                gridBand.Caption = "Última actualización: " + lblFechaUltimaActualización.Text
            End If
            If gridBand.Caption = "-" Then
                gridBand.Caption = ""
            End If
            bgvReporteEstadisticoFamilias.Bands.Add(gridBand)
        Next
        For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In bgvReporteEstadisticoFamilias.Bands
            gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        bgvReporteEstadisticoFamilias.Bands(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        bgvReporteEstadisticoFamilias.ColumnPanelRowHeight = 40



    End Sub

#End Region


#Region "Otras Funciones"

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

    Private Function ObtenerColorCeldaValoresCrecimiento(ByVal Valor As Integer) As Color
        Dim TipoColor As Color = Color.Empty


        If Valor <= 0 Then
            TipoColor = Color.Pink
        ElseIf Valor > 0 Then
            TipoColor = Color.LightGreen
        End If

        Return TipoColor

    End Function

    Private Function ObtenerColorLetraValoresCrecimiento(ByVal Valor As Integer) As Color
        Dim TipoColor As Color = Color.Empty

        If Valor <= 0 Then
            TipoColor = Color.Red
        ElseIf Valor > 0 Then
            TipoColor = Color.Green
        End If

        Return TipoColor

    End Function

    Private Function ObtenerColorCeldaAñoYAcumulado(ByVal Valor As Integer) As Color
        Dim TipoColor As Color = Color.Empty

        If Valor.ToString() = txtAñoComparacion.Text Then
            TipoColor = Color.FromArgb(189, 215, 238)
        ElseIf Valor.ToString() = dtpFechaEntregaDel.Value.Year.ToString Then
            TipoColor = Color.FromArgb(153, 255, 204)
        End If

        Return TipoColor

    End Function

#End Region

    Private Sub bgvReporteEstadisticoFamilias_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles bgvReporteEstadisticoFamilias.CustomDrawCell

        If cmboxTipoReporte.SelectedIndex = 0 Then
            Dim currentView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)

            Try
                'Cursor = Cursors.WaitCursor
                If e.Column.FieldName <> "CLIENTE" And e.Column.FieldName <> "AÑO" And e.Column.FieldName <> "#" And e.Column.FieldName <> "FAMILIA" Then
                    If IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Or IsNothing(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                        If currentView.GetRowCellValue(e.RowHandle, "FAMILIA").ToString().Contains("CRECIMIENTO") = False And currentView.GetRowCellValue(e.RowHandle, "FAMILIA").ToString().Contains("ACUMULADO") = False Then
                            currentView.SetRowCellValue(e.RowHandle, e.Column.FieldName, 0)
                            e.DisplayText = 0
                        End If
                    End If
                    If currentView.GetRowCellValue(e.RowHandle, "FAMILIA").ToString().Contains("CRECIMIENTO") Then
                        If (e.Column.FieldName.Contains("TOTAL") = False Or (e.Column.FieldName.Contains("TOTAL") = True And e.Column.FieldName = "TOTAL ANUAL")) And e.Column.FieldName <> "CLIENTE" And e.Column.FieldName <> "AÑO" And e.Column.FieldName <> "FAMILIA" Then
                            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) = False Then
                                e.Appearance.BackColor = ObtenerColorCeldaValoresCrecimiento(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                                e.Appearance.ForeColor = ObtenerColorLetraValoresCrecimiento(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                                e.DisplayText = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.DisplayText.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
                                e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, FontStyle.Bold)
                            End If
                        End If
                        If e.Column.FieldName.Contains("TOTAL") Then
                            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                                e.Appearance.BackColor = Color.FromArgb(217, 217, 217)
                            End If
                        End If
                    End If
                ElseIf (e.Column.FieldName = "FAMILIA" And currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName).ToString.Contains("CRECIMIENTO")) Then
                    If e.Column.FieldName = "FAMILIA" Then
                        e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, FontStyle.Bold)
                        e.Appearance.BackColor = Color.FromArgb(217, 217, 217)
                    End If
                ElseIf e.Column.FieldName = "AÑO" Then
                    e.Appearance.BackColor = ObtenerColorCeldaAñoYAcumulado(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                End If


                If currentView.GetRowCellValue(e.RowHandle, "FAMILIA").ToString.Contains("TOTAL") And e.Column.FieldName <> "#" And e.Column.FieldName <> "CLIENTE" And e.Column.FieldName <> "AÑO" Then
                    e.Appearance.BackColor = Color.FromArgb(217, 217, 217)
                End If
                If currentView.GetRowCellValue(e.RowHandle, "FAMILIA").ToString.Contains("ACUMULADO") And e.Column.FieldName <> "#" And e.Column.FieldName <> "CLIENTE" Then
                    e.Appearance.BackColor = ObtenerColorCeldaAñoYAcumulado(currentView.GetRowCellValue(e.RowHandle, "AÑO"))
                End If

                'Cursor = Cursors.Default
            Catch ex As Exception
                'Cursor = Cursors.Default
                show_message("Error", ex.Message.ToString())
            End Try
            'End If

        ElseIf cmboxTipoReporte.SelectedIndex = 2 Then

            Dim currentView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)

            Try
                'Cursor = Cursors.WaitCursor
                If e.Column.FieldName <> "FAMILIA" And e.Column.FieldName <> "#" Then
                    If IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Or IsNothing(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                        currentView.SetRowCellValue(e.RowHandle, e.Column.FieldName, 0)
                        e.DisplayText = 0
                    End If
                    If e.Column.FieldName.Contains("CREC") Then
                        e.Appearance.BackColor = ObtenerColorCeldaValoresCrecimiento(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                        e.Appearance.ForeColor = ObtenerColorLetraValoresCrecimiento(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                        e.DisplayText = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.DisplayText.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
                    End If
                End If
                If currentView.GetRowCellValue(e.RowHandle, "FAMILIA").ToString().Contains("TOTAL") And e.Column.FieldName <> "#" Then
                    e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, FontStyle.Bold)
                End If

                'Cursor = Cursors.Default
            Catch ex As Exception
                'Cursor = Cursors.Default
                show_message("Error", ex.Message.ToString())
            End Try
            'End If

        End If

    End Sub

#Region "EXPORTAR EXCEL"

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click

        If cmboxTipoReporte.SelectedIndex = 0 Then
            exportarEstadisticaVentasPorFamilia()
        ElseIf cmboxTipoReporte.SelectedIndex = 1 Then
            show_message("Aviso", "El reporte ""Preventa (Anual y Por Marca)"" se exportará sin formato.")
            exportarEstadisticaPreventas()
        ElseIf cmboxTipoReporte.SelectedIndex = 2 Then
            exportarEstadisticaPreventasPorFamilia()
        End If

    End Sub

    Private Sub exportarEstadisticaVentasPorFamilia()

        If bgvReporteEstadisticoFamilias.DataRowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty
            Dim nombreReporteParaExportacion As String = String.Empty
            Dim objBU As New Negocios.EstadisticoPedidosBU

            Try

                nombreReporte = "\Estadistica_Familia_" + dtpFechaEntregaDel.Value.Year.ToString + "_" + txtAñoComparacion.Text + "_"
                nombreReporteParaExportacion = "ESTADÍSTICA DE VENTAS POR FAMILIA"

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = System.Windows.Forms.DialogResult.OK Then

                        If bgvReporteEstadisticoFamilias.GroupCount > 0 Then
                            bgvReporteEstadisticoFamilias.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell


                            grdReporteEstadisticoFamilias.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)

                        End If

                        show_message("Exito", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")

                        .Dispose()

                        objBU.bitacoraExportacionExcel(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "EXCEL", "SAY", nombreReporteParaExportacion, dtpFechaEntregaDel.Value.ToShortDateString(), dtpFechaEntregaAl.Value.ToShortDateString())

                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If



                End With
            Catch ex As Exception
                show_message("Error", ex.Message.ToString())
            End Try
        Else
            show_message("Aviso", "No hay datos para exportar.")
        End If

    End Sub

    Private Sub exportarEstadisticaPreventas()

        If bgvConsultaAnual.DataRowCount > 0 And bgvConsultaMarca.DataRowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty
            Dim nombreReporteParaExportacion As String = String.Empty
            Dim objBU As New Negocios.EstadisticoPedidosBU

            Try

                nombreReporte = "\PreventasAnualMarca_"
                nombreReporteParaExportacion = "ESTADÍSTICA DE VENTAS POR FAMILIA - PREVENTAS (ANUAL Y POR MARCA)"

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = System.Windows.Forms.DialogResult.OK Then

                        Dim exportOptions = New XlsxExportOptionsEx()
                        'exportOptions.ExportMode = XlsxExportMode.SingleFilePageByPage
                        AddHandler exportOptions.CustomizeCell, AddressOf exportOptionsAnualMarca_CustomizeCell

                        Dim ps As New PrintingSystem
                        Dim compositeLink As New DevExpress.XtraPrintingLinks.CompositeLink()
                        compositeLink.PrintingSystem = ps

                        Dim LinkAnual As New PrintableComponentLink
                        Dim LinkMarca As New PrintableComponentLink
                        Dim LinkGraficaAnual As New PrintableComponentLink
                        Dim LinkGraficaMarca As New PrintableComponentLink
                        LinkAnual.Component = grdConsultaAnual
                        LinkMarca.Component = grdConsultaMarca
                        LinkGraficaAnual.Component = chrConsultaAnual
                        LinkGraficaMarca.Component = chrConsultaMarca
                        compositeLink.Links.Add(LinkAnual)
                        compositeLink.Links.Add(LinkGraficaAnual)
                        compositeLink.Links.Add(LinkMarca)
                        compositeLink.Links.Add(LinkGraficaMarca)

                        compositeLink.CreateDocument()
                        compositeLink.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)

                        show_message("Exito", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")

                        .Dispose()

                        objBU.bitacoraExportacionExcel(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "EXCEL", "SAY", nombreReporteParaExportacion, dtpFechaEntregaDel.Value.ToShortDateString(), dtpFechaEntregaAl.Value.ToShortDateString())

                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If



                End With
            Catch ex As Exception
                show_message("Error", ex.Message.ToString())
            End Try
        Else
            show_message("Aviso", "No hay datos para exportar.")
        End If

    End Sub

    Private Sub exportarEstadisticaPreventasPorFamilia()

        If bgvReporteEstadisticoFamilias.DataRowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty
            Dim nombreReporteParaExportacion As String = String.Empty
            Dim objBU As New Negocios.EstadisticoPedidosBU

            Try

                nombreReporte = "\PreventasFamilia_"
                nombreReporteParaExportacion = "ESTADÍSTICA DE VENTAS POR FAMILIA - PREVENTAS (POR FAMILIA)"

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = System.Windows.Forms.DialogResult.OK Then

                        If bgvReporteEstadisticoFamilias.GroupCount > 0 Then
                            bgvReporteEstadisticoFamilias.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell


                            grdReporteEstadisticoFamilias.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)

                        End If

                        show_message("Exito", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")

                        .Dispose()

                        objBU.bitacoraExportacionExcel(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "EXCEL", "SAY", nombreReporteParaExportacion, dtpFechaEntregaDel.Value.ToShortDateString(), dtpFechaEntregaAl.Value.ToShortDateString())

                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If



                End With
            Catch ex As Exception
                show_message("Error", ex.Message.ToString())
            End Try
        Else
            show_message("Aviso", "No hay datos para exportar.")
        End If

    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

        If cmboxTipoReporte.SelectedIndex = 0 Then
            opcionesExportacionEstadisticaVentasFamilia(e)
        ElseIf cmboxTipoReporte.SelectedIndex = 1 Then
            opcionesExportacionEstadisticaConsultaAnualMarca(e)
        ElseIf cmboxTipoReporte.SelectedIndex = 2 Then
            opcionesExportacionEstadisticaPreventasFamilia(e)
        End If

    End Sub

    Private Sub exportOptionsAnualMarca_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

            opcionesExportacionEstadisticaConsultaAnualMarca(e)

    End Sub

    Private Sub opcionesExportacionEstadisticaVentasFamilia(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        Try


            If e.ColumnFieldName <> "CLIENTE" And e.ColumnFieldName <> "AÑO" And e.ColumnFieldName <> "#" And e.ColumnFieldName <> "FAMILIA" Then
                If IsDBNull(bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) Or IsNothing(bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) Then
                    If bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, "FAMILIA").ToString().Contains("CRECIMIENTO") = False And bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, "FAMILIA").ToString().Contains("ACUMULADO") = False Then
                        If e.RowHandle > 0 Then
                            bgvReporteEstadisticoFamilias.SetRowCellValue(e.RowHandle, e.ColumnFieldName, 0)
                            e.Value = 0
                        End If
                    End If
                End If
                If bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, "FAMILIA").ToString().Contains("CRECIMIENTO") Then
                    If (e.ColumnFieldName.Contains("TOTAL") = False Or (e.ColumnFieldName.Contains("TOTAL") = True And e.ColumnFieldName = "TOTAL ANUAL")) And e.ColumnFieldName <> "CLIENTE" And e.ColumnFieldName <> "AÑO" And e.ColumnFieldName <> "FAMILIA" Then
                        If IsDBNull(bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) = False Then
                            e.Formatting.BackColor = ObtenerColorCeldaValoresCrecimiento(bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, e.ColumnFieldName))
                            e.Formatting.Font.Color = ObtenerColorLetraValoresCrecimiento(bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, e.ColumnFieldName))
                            e.Value = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.Value.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
                            e.Formatting.Font.Bold = True
                        End If
                    End If
                    If e.ColumnFieldName.Contains("TOTAL") Then
                        If IsDBNull(bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) Then
                            e.Formatting.BackColor = Color.FromArgb(217, 217, 217)
                        End If
                    End If
                End If
            ElseIf (e.ColumnFieldName = "FAMILIA" And bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, e.ColumnFieldName).ToString.Contains("CRECIMIENTO")) Then
                If e.ColumnFieldName = "FAMILIA" Then
                    e.Formatting.Font.Bold = True
                    e.Formatting.BackColor = Color.FromArgb(217, 217, 217)
                End If
            ElseIf e.ColumnFieldName = "AÑO" Then
                e.Formatting.BackColor = ObtenerColorCeldaAñoYAcumulado(bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, e.ColumnFieldName))
            End If


            If bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, "FAMILIA").ToString.Contains("TOTAL") And e.ColumnFieldName <> "#" And e.ColumnFieldName <> "CLIENTE" And e.ColumnFieldName <> "AÑO" Then
                e.Formatting.BackColor = Color.FromArgb(217, 217, 217)
            End If
            If bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, "FAMILIA").ToString.Contains("ACUMULADO") And e.ColumnFieldName <> "#" And e.ColumnFieldName <> "CLIENTE" Then
                e.Formatting.BackColor = ObtenerColorCeldaAñoYAcumulado(bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, "AÑO"))
            End If

            If e.Value.ToString = "SEMESTRE 1" Then
                e.Formatting.BackColor = Color.FromArgb(198, 224, 180)
            End If
            If e.Value.ToString = "SEMESTRE 2" Then
                e.Formatting.BackColor = Color.FromArgb(225, 242, 204)
            End If
            If e.Value.ToString = "AÑO" Then
                e.Formatting.BackColor = Color.Empty
            End If



        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

        e.Handled = True
    End Sub

    Private Sub opcionesExportacionEstadisticaConsultaAnualMarca(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        Try

            'Cursor = Cursors.WaitCursor
            If e.ColumnFieldName <> "CLIENTE" And e.ColumnFieldName <> "#" Then
                If IsDBNull(bgvConsultaAnual.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) Or IsNothing(bgvConsultaAnual.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) Then
                    If bgvConsultaAnual.GetRowCellValue(e.RowHandle, "CLIENTE").ToString().Contains("CRECIMIENTO") = False Then
                        bgvConsultaAnual.SetRowCellValue(e.RowHandle, e.ColumnFieldName, 0)
                        e.Value = 0
                    End If
                End If
                If bgvConsultaAnual.GetRowCellValue(e.RowHandle, "CLIENTE").ToString().Contains("CRECIMIENTO") Then
                    If e.ColumnFieldName.Contains("TOTAL") = False And e.ColumnFieldName.Contains(dtpFechaInicioConsultas.Value.Year.ToString) = False Then
                        If IsDBNull(bgvConsultaAnual.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) = False Then
                            e.Formatting.BackColor = ObtenerColorCeldaValoresCrecimiento(bgvConsultaAnual.GetRowCellValue(e.RowHandle, e.ColumnFieldName))
                            e.Formatting.Font.Color = ObtenerColorLetraValoresCrecimiento(bgvConsultaAnual.GetRowCellValue(e.RowHandle, e.ColumnFieldName))
                            e.Value = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.Value, ",", ""), "%", "")))) / 100).ToString("p0")
                            e.Formatting.Font.Bold = True
                        End If
                    End If
                End If
            Else
                If e.ColumnFieldName = "CLIENTE" Then
                    If bgvConsultaAnual.GetRowCellValue(e.RowHandle, "CLIENTE").ToString().Contains("CRECIMIENTO") Then
                        e.Formatting.Font.Bold = True
                    End If
                End If

            End If


            'Cursor = Cursors.WaitCursor
            If e.ColumnFieldName <> "FAMILIA" And e.ColumnFieldName <> "#" Then
                If IsDBNull(bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) Or IsNothing(bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) Then
                    If e.RowHandle > 0 Then
                        bgvReporteEstadisticoFamilias.SetRowCellValue(e.RowHandle, e.ColumnFieldName, 0)
                        e.Value = 0
                    End If
                End If
                If e.ColumnFieldName.Contains("CREC") And IsNumeric(e.Value) Then
                    e.Formatting.BackColor = ObtenerColorCeldaValoresCrecimiento(bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, e.ColumnFieldName))
                    e.Formatting.Font.Color = ObtenerColorLetraValoresCrecimiento(bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, e.ColumnFieldName))
                    e.Value = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.Value.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
                End If
            End If
            If bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, "FAMILIA").ToString().Contains("TOTAL") And e.ColumnFieldName <> "#" Then
                e.Formatting.Font.Bold = True
            End If

            'Cursor = Cursors.Default


        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

        e.Handled = True
    End Sub


    Private Sub opcionesExportacionEstadisticaPreventasFamilia(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        Try
            'Cursor = Cursors.WaitCursor
            If e.ColumnFieldName <> "FAMILIA" And e.ColumnFieldName <> "#" Then
                If IsDBNull(bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) Or IsNothing(bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) Then
                    If e.RowHandle > 0 Then
                        bgvReporteEstadisticoFamilias.SetRowCellValue(e.RowHandle, e.ColumnFieldName, 0)
                        e.Value = 0
                    End If
                End If
                If e.ColumnFieldName.Contains("CREC") And IsNumeric(e.Value) Then
                    e.Formatting.BackColor = ObtenerColorCeldaValoresCrecimiento(bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, e.ColumnFieldName))
                    e.Formatting.Font.Color = ObtenerColorLetraValoresCrecimiento(bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, e.ColumnFieldName))
                    e.Value = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.Value.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
                End If
            End If
            If bgvReporteEstadisticoFamilias.GetRowCellValue(e.RowHandle, "FAMILIA").ToString().Contains("TOTAL") And e.ColumnFieldName <> "#" Then
                e.Formatting.Font.Bold = True
            End If

            'Cursor = Cursors.Default
        Catch ex As Exception
            'Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

        e.Handled = True
    End Sub


#End Region

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_Estadistica_Ventas_Familia_V1.pdf")
            Process.Start("Descargas\Manuales\Ventas\COVE_MAUS_Estadistica_Ventas_Familia_V1.pdf")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmboxTipoReporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmboxTipoReporte.SelectedIndexChanged
        If cmboxTipoReporte.SelectedIndex = 0 Then
            grpEstadisticaVentas.Visible = True
            grpReportesNoEstadisticoFamilia.Visible = False
            pnlConsultaAnualYMarca.Visible = False
        Else
            grpEstadisticaVentas.Visible = False
            grpReportesNoEstadisticoFamilia.Visible = True
            If cmboxTipoReporte.SelectedIndex = 1 Then
                pnlConsultaAnualYMarca.Visible = True
            Else
                pnlConsultaAnualYMarca.Visible = False
            End If
        End If
    End Sub


End Class