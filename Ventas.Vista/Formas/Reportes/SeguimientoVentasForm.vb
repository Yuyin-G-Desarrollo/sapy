Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns

Public Class SeguimientoVentasForm

    Dim listInicial As New List(Of String)
    Dim filtro_Agente As String = String.Empty
    Dim filtro_familia As String = String.Empty
    Dim filtro_Marca As String = String.Empty
    Dim filtro_Cliente As String = String.Empty
    Dim filtro_FechaInicio As String = String.Empty
    Dim filtro_FechaFin As String = String.Empty
    Dim tipoReporte As Integer = 0
    Dim perfilUsuario As Integer = 0
    Dim ListaColumnasGrid As New List(Of String)
    Dim dtEncabezadoAgente As DataTable
    Dim dtEncabezadoFrecuenciaCompra As DataTable

    Private colClasifiacion As DevExpress.XtraGrid.Columns.GridColumn = New DevExpress.XtraGrid.Columns.GridColumn


    Private Sub SeguimientoVentasPorAgenteForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtResultadoPerfil As New DataTable
        Dim objBU As New Negocios.EstadisticaVentasFamiliaBU

        'dtpFechaEntregaDel.MinDate = Date.Parse("01/01/2012")
        'dtpFechaEntregaAl.MinDate = Date.Parse("01/01/2012")
        'dtpFechaEntregaDel.Value = Date.Parse("02/01/" + Date.Now.Year.ToString())
        ''dtpFechaEntregaAl.Value = Date.Parse("31/12/" + Date.Now.Year.ToString())
        'dtpFechaEntregaAl.Value = New Negocios.ResumenVentasSemanalBU().ConsultarFechaFinEstadVentas_Semanal()

        Dim objResumenVentasBU As New Negocios.ResumenVentasSemanalBU
        dtpFechaEntregaDel.Value = objResumenVentasBU.ConsultarFechaInicioEstadVentas_Semanal()
        dtpFechaEntregaAl.Value = objResumenVentasBU.ConsultarFechaFinEstadVentas_Semanal()

        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized
        cmboxTipoReporte.SelectedIndex = 0
        grdAgentes.DataSource = listInicial
        grdMarcas.DataSource = listInicial
        grdClientes.DataSource = listInicial
        grdFamilias.DataSource = listInicial

        lblFactorFrecuenciaCompra.Visible = False
        spinFactorFrecuencia.Visible = False
        spinFactorFrecuencia.Value = 4
        spinFactorFrecuencia.Properties.Increment = 1

        dtResultadoPerfil = objBU.reporteEstadisticaFamliasObtenerPerfilUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        If dtResultadoPerfil.Rows.Count > 0 Then
            perfilUsuario = dtResultadoPerfil.Rows(0).Item("IdPerfil")
            If dtResultadoPerfil.Rows(0).Item("IdPerfil") = 44 Then
                grpboxagente.Enabled = False
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


        grpbxFiltroFechas.Text = "Fecha de Programación de Pedidos"
        lblTextoPedidos.Text = "Pedidos: Rango de fechas de programación de pedidos"
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 206
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdReporte.DataSource = Nothing
        grdReporteResumen.DataSource = Nothing
        grdFamilias.DataSource = listInicial
        bgvReporte.Bands.Clear()
        bgvReporte.Columns.Clear()
        vwReporteResumen.Columns.Clear()
        cmboxTipoReporte.SelectedIndex = 0
        If perfilUsuario <> 44 Then
            grdAgentes.DataSource = listInicial
        End If
        grdMarcas.DataSource = listInicial
        grdClientes.DataSource = listInicial
        dtpFechaEntregaAl.Value = Date.Parse("31/12/" + Date.Now.Year.ToString())
        dtpFechaEntregaDel.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
        lblFechaUltimaActualización.Text = "-"
        spinFactorFrecuencia.Value = 4
        btnAbajo_Click(sender, e)
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
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdAgentes.DataSource = listado.listParametros
        With grdAgentes
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Agente de Ventas"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With

    End Sub

    Private Sub btnMarcas_Click(sender As Object, e As EventArgs) Handles btnMarcas.Click
        Dim listado As New ListadoParametrosReportesForm
        listado.tipo_busqueda = 3

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdMarcas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdMarcas.DataSource = listado.listParametros
        With grdMarcas()
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Marca"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
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
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
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

    Private Sub btnLimpiarFiltroAgente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroAgente.Click
        grdAgentes.DataSource = listInicial
    End Sub

    Private Sub btnLimpiarFiltroMarca_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroMarca.Click
        grdMarcas.DataSource = listInicial
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdClientes.DataSource = listInicial
    End Sub

    Private Sub grdAgentes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdAgentes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdClientes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
    Private Sub grdFamilias_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFamilias.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdMarcas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdMarcas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdAgentes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAgentes.InitializeLayout
        grid_diseño(grdAgentes)
        grdAgentes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Agente de Ventas"
    End Sub

    Private Sub grdClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        grid_diseño(grdClientes)
        grdClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub grdMarcas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMarcas.InitializeLayout
        grid_diseño(grdMarcas)
        grdMarcas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Marca"
    End Sub
    Private Sub grdFamilias_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFamilias.InitializeLayout
        grid_diseño(grdFamilias)
        grdFamilias.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Familias"
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

    Private Sub dtpFechaEntregaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaEntregaDel.ValueChanged
        If dtpFechaEntregaAl.MinDate > "31/12/" + dtpFechaEntregaDel.Value.Year.ToString() Then
            dtpFechaEntregaAl.MinDate = dtpFechaEntregaDel.Value
            dtpFechaEntregaAl.MaxDate = "31/12/" + dtpFechaEntregaDel.Value.Year.ToString()
        Else
            dtpFechaEntregaAl.MaxDate = "31/12/" + dtpFechaEntregaDel.Value.Year.ToString()
            dtpFechaEntregaAl.MinDate = dtpFechaEntregaDel.Value
        End If
    End Sub



    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Cursor = Cursors.WaitCursor
        tipoReporte = cmboxTipoReporte.SelectedIndex + 1
        ListaColumnasGrid.Clear()
        SeguimientoVentas(tipoReporte)

        Cursor = Cursors.Default
    End Sub


    Private Sub SeguimientoVentas(ByVal TipoReporte As Integer)
        Dim objBU As New Negocios.SeguimientoVentasBU
        Dim spid As Integer = 0
        Dim dtResultadoReporte As New DataTable

        If obtenerFiltros() = False Then
            Return
        End If

        dtResultadoReporte = objBU.ReportesSeguimientoVentas(filtro_FechaInicio, filtro_FechaFin, filtro_Agente, filtro_Marca, filtro_Cliente, TipoReporte, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, spinFactorFrecuencia.Value, filtro_familia)

        If dtResultadoReporte.Rows.Count > 0 Then

            'lblNumRegistros.Text = Integer.Parse(grvReportePedidos.RowCount.ToString()).ToString("n0")
            lblFechaUltimaActualización.Text = DateTime.Now.ToString()

            grdReporte.DataSource = Nothing
            grdReporteResumen.DataSource = Nothing

            If TipoReporte = 2 Then
                spid = Integer.Parse(dtResultadoReporte.Rows(0).Item("spid").ToString())
                diseñoGridResultadoFrecuenciaCompra(spid)
                grdReporteResumen.Visible = False
                grdReporte.Visible = True
            ElseIf TipoReporte = 1 Then
                spid = Integer.Parse(dtResultadoReporte.Rows(0).Item("spid").ToString())
                diseñoGridResultado(spid)
                grdReporteResumen.Visible = False
                grdReporte.Visible = True
            ElseIf TipoReporte = 4 Then
                spid = Integer.Parse(dtResultadoReporte.Rows(0).Item("spid").ToString())

                diseñoGridResultadoFrecuenciaPedidosCliente(spid)
                grdReporteResumen.Visible = False
                grdReporte.Visible = True
                AgruparPorClasificacionReporteFrecuenciaPedidos()
            Else
                grdReporte.Visible = False
                grdReporteResumen.Visible = True

            End If

            'dtResultadoReporte.Rows(dtResultadoReporte.Rows.Count - 1).Item("TOTAL") = dtResultadoReporte.Rows(dtResultadoReporte.Rows.Count - 1).Item(dtResultadoReporte.Columns(dtResultadoReporte.Columns.Count - 2).ColumnName.ToString())

            If TipoReporte = 3 Then
                grdReporteResumen.DataSource = dtResultadoReporte
                diseñoGridResumen()
                'reporteTotales()
            Else
                grdReporte.DataSource = dtResultadoReporte

                For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvReporte.Columns
                    If Col.FieldName <> "RUTA" AndAlso Col.FieldName <> "CLIENTE" AndAlso Col.FieldName <> "CIUDAD" AndAlso Col.FieldName <> "EDO" AndAlso Col.FieldName <> "CLASIF" AndAlso Col.FieldName <> "TDAS" Then

                        Col.BestFit()

                        If Col.FieldName.Contains("TOTAL") = True Then
                            Col.Width = 70
                        End If
                    End If

                    If Col.FieldName = "TDAS" Then
                        Col.BestFit()
                    End If

                    If TipoReporte = 2 Then
                        If Col.FieldName <> "RUTA" AndAlso Col.FieldName <> "CLIENTE" AndAlso Col.FieldName <> "CIUDAD" AndAlso Col.FieldName <> "EDO" AndAlso Col.FieldName <> "CLASIF" AndAlso Col.FieldName <> "TDAS" Then
                            Col.Width = Col.Width + 10
                        End If
                    End If
                Next

                btnArriba_Click(Nothing, Nothing)

            End If

            'For Each Columna As String In ListaColumnasGrid

            '    If Columna <> "RUTA" AndAlso Columna <> "CLIENTE" AndAlso Columna <> "CIUDAD" AndAlso Columna <> "EDO" AndAlso Columna <> "CLASIF" AndAlso Columna <> "TDAS" Then
            '        bgvReporte.Columns(Columna).BestFit()
            '    End If
            'Next

            'Ajustar el tamño de la oclumna en base al contenido
            'bgvReporte.Columns("CLIENTE").BestFit()
            'bgvReporte.Columns("CIUDAD").BestFit()
            'bgvReporte.Columns("EDO").BestFit()

        Else
            grdReporte.DataSource = Nothing
            bgvReporte.Bands.Clear()
            bgvReporte.Columns.Clear()
            show_message("Aviso", "No hay datos para mostrar.")
        End If
    End Sub
    Private Sub diseñoGridResumen()
        vwReporteResumen.GroupSummary.Clear()

        For Each Col As DevExpress.XtraGrid.Columns.GridColumn In vwReporteResumen.Columns
            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            If Col.FieldName = "Agente" Then
                Col.Width = 250
            End If
            If Col.FieldName = "ParesPedidos" Then
                Col.Summary.Clear()
                Col.Width = 150
                Col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                Col.DisplayFormat.FormatString = "N0"
                Col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, Col.FieldName, "{0:N0}")
            End If
        Next
    End Sub

    Private Sub reporteTotales()
        vwReporteResumen.GroupSummary.Clear()

        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem
        For Each vColumna As DevExpress.XtraGrid.Columns.GridColumn In vwReporteResumen.Columns

            If vColumna.FieldName = "ParesPedidos" Then
                vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                item = New DevExpress.XtraGrid.GridGroupSummaryItem
                item.FieldName = vColumna.FieldName
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0}"
                vwReporteResumen.GroupSummary.Add(item)
                vColumna.OptionsFilter.AllowFilter = False
            End If
        Next

    End Sub

    Private Sub vwReporteResumen_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwReporteResumen.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub vwReporteResumen_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles vwReporteResumen.RowStyle
        Dim view As GridView = sender

        If e.RowHandle >= 0 Then
            If (e.RowHandle Mod 2 > 0) Then
                e.Appearance.BackColor = Color.LightSteelBlue
            End If
        End If

    End Sub

    'Private Sub vwReporteResumen_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles vwReporteResumen.CustomSummaryCalculate
    '    Dim vE As DevExpress.Data.CustomSummaryEventArgs = e
    '    Dim vTotal As Decimal = 0
    '    Dim NumeroFilas As Integer = 0

    '    If dtResultadoReporte.Rows.Count > 0 Then
    '        vTotal = 0

    '        If e.Item.FieldName = "ParesPedidos" Then
    '            NumeroFilas = vwReporteResumen.DataRowCount
    '            If NumeroFilas > 0 Then
    '                For index As Integer = 0 To NumeroFilas Step 1
    '                    vTotal += vwReporteResumen.GetRowCellValue(vwReporteResumen.GetVisibleRowHandle(index), e.Item.FieldName)
    '                Next
    '                e.TotalValue = vTotal
    '            End If
    '        End If
    '    End If
    'End Sub



    Private Sub diseñoGridResultadoFrecuenciaCompra(ByVal spid As Integer)
        Dim objBu As New Negocios.SeguimientoVentasBU
        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim listBandsTextos As New List(Of String)
        Dim listBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        Dim listBandsMarcas As New List(Of String)
        'Dim bandMarca As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim BandaAux As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim dtEncabezados As New DataTable

        dtEncabezados = objBu.SeguimientoVentasObtenerEncabezadosTabla(spid)


        If IsNothing(dtEncabezadoFrecuenciaCompra) = True Then
            dtEncabezadoFrecuenciaCompra = dtEncabezados.Copy()
        Else
            dtEncabezadoFrecuenciaCompra = Nothing
            dtEncabezadoFrecuenciaCompra = dtEncabezados.Copy()
        End If

        bgvReporte.OptionsView.AllowCellMerge = True
        bgvReporte.OptionsView.ColumnAutoWidth = False
        bgvReporte.Columns.Clear()
        bgvReporte.Bands.Clear()

        grdReporte.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        grdReporte.LookAndFeel.UseDefaultLookAndFeel = False

        'Primer Nivel Cuatrimestre

        Dim ListaBandaCuatrimestre = dtEncabezados.AsEnumerable().Select(Function(x) x.Item("Cuatrimestre")).Distinct.ToList

        Dim cadenas As String = ""
        For Each item As String In ListaBandaCuatrimestre

            listBandsTextos.Add(item.Trim())
            band = bgvReporte.Bands.Add
            band.AppearanceHeader.Options.UseBackColor = True

            If item = "CUATRIMESTRE 1" Then
                band.AppearanceHeader.BackColor = Color.FromArgb(216, 228, 188)
            ElseIf item = "CUATRIMESTRE 2" Then
                band.AppearanceHeader.BackColor = Color.FromArgb(255, 255, 204)
            ElseIf item = "CUATRIMESTRE 3" Then
                band.AppearanceHeader.BackColor = Color.FromArgb(220, 230, 241)

            End If


            band.Caption = item.Trim()
            listBands.Add(band)

            ''Marcas asociadas al cuatrimestre
            'Dim ListaBandaMarcas = dtEncabezados.AsEnumerable().Where(Function(x) x.Item("Cuatrimestre") = item.Trim()).Select(Function(y) y.Item("Marca")).Distinct.ToList


            'For Each itemmarca As String In ListaBandaMarcas
            '    bandMarca = band.Children.Add()
            '    bandMarca.Caption = itemmarca.Trim
            '    bandMarca.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            '    listBands.Add(bandMarca)
            'Next

        Next




        For Each row As DataRow In dtEncabezados.Rows

            BandaAux = listBands.AsEnumerable().FirstOrDefault(Function(x) x.Caption = row.Item("Cuatrimestre"))

            bgvReporte.Columns.AddField(row.Item("ColumnaOrigen").ToString().ToUpper)
            bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).OwnerBand = BandaAux
            bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).Visible = True
            bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen")).Caption = row.Item("NombreColumna")

            If row.Item("ColumnaOrigen").ToString().ToUpper <> "MARCA" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "AGENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "CLIENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "RUTA" Then
                bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            End If
            If row.Item("ColumnaOrigen").ToString().ToUpper <> "MARCA" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "INDICADOR" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "AGENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "CLIENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "RUTA" Then
                bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).DisplayFormat.FormatString = "N0"
            End If

        Next

        For Each gridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In listBands
            If gridBand.Caption = "" Then
                gridBand.Caption = "Última actualización: " + lblFechaUltimaActualización.Text
            End If
            If gridBand.Caption = "-" Then
                gridBand.Caption = ""
            End If
            'If gridBand.Caption.ToUpper.Contains("TOTAL") Then
            '    gridBand.Caption = ""
            'End If
        Next

        For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In bgvReporte.Bands
            gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        bgvReporte.Bands(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        bgvReporte.ColumnPanelRowHeight = 50



        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvReporte.Columns
            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'Col.BestFit()
            If Col.FieldName = "#" Then
                Col.Width = 30
            End If

            If Col.FieldName = "INDICADOR" Then
                If tipoReporte <> 4 And tipoReporte <> 6 Then
                    Col.Width = 175
                Else
                    Col.Width = 185
                End If
            End If
            If Col.FieldName = "MARCA" Then
                If tipoReporte <> 4 And tipoReporte <> 6 Then
                    Col.Width = 100
                Else
                    Col.Width = 90
                End If
            End If
            If Col.FieldName = "TOTAL" Then
                Col.Width = 100
            End If
            If Col.FieldName = "AGENTE" Then
                If tipoReporte <> 4 And tipoReporte <> 6 Then
                    Col.Width = 170
                Else
                    Col.Width = 185
                End If
            End If
            If Col.FieldName = "CLIENTE" Then
                Col.Width = 180

            End If

            If Col.FieldName = "CIUDAD" Then
                Col.Width = 140
                'Col.BestFit()
            End If

            If Col.FieldName = "RUTA" Then
                Col.Width = 120
            End If

            If Col.FieldName = "TDAS" Then
                Col.Width = 45
            End If

            If Col.FieldName = "CLASIF" Then
                Col.Width = 45
            End If

            If Col.FieldName = "EDO" Then
                Col.Width = 45
            End If
        Next


    End Sub

    Private Sub diseñoGridResultado(ByVal spid As Integer)
        Dim objBu As New Negocios.SeguimientoVentasBU
        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim listBandsTextos As New List(Of String)
        Dim listBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        Dim listBandsMarcas As New List(Of String)
        Dim bandMarca As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim BandaAux As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim dtEncabezados As New DataTable
        Dim filaVacia As Boolean = False

        dtEncabezados = objBu.SeguimientoVentasObtenerEncabezadosTabla(spid)

        If IsNothing(dtEncabezadoAgente) = True Then
            dtEncabezadoAgente = dtEncabezados.Copy()
        Else
            dtEncabezadoAgente = Nothing
            dtEncabezadoAgente = dtEncabezados.Copy()
        End If



        bgvReporte.OptionsView.AllowCellMerge = True
        bgvReporte.OptionsView.ColumnAutoWidth = False
        bgvReporte.Columns.Clear()
        bgvReporte.Bands.Clear()

        grdReporte.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        grdReporte.LookAndFeel.UseDefaultLookAndFeel = False

        'Primer Nivel Cuatrimestre

        Dim ListaBandaCuatrimestre = dtEncabezados.AsEnumerable().Select(Function(x) x.Item("Cuatrimestre")).Distinct.ToList

        Dim cadenas As String = ""
        For Each item As String In ListaBandaCuatrimestre

            listBandsTextos.Add(item.Trim())

            band = bgvReporte.Bands.Add
            band.AppearanceHeader.Options.UseBackColor = True


            If item = "CUATRIMESTRE 1" Then
                band.AppearanceHeader.BackColor = Color.FromArgb(216, 228, 188)
            ElseIf item = "CUATRIMESTRE 2" Then
                band.AppearanceHeader.BackColor = Color.FromArgb(255, 255, 204)
            ElseIf item = "CUATRIMESTRE 3" Then
                band.AppearanceHeader.BackColor = Color.FromArgb(220, 230, 241)
            End If

            band.Caption = item.Trim()

            'Marcas asociadas al cuatrimestre

            Dim ListaBandaMarcas = dtEncabezados.AsEnumerable().Where(Function(x) x.Item("Cuatrimestre") = item.Trim()).Select(Function(y) y.Item("Marca")).Distinct.ToList

            For Each itemmarca As String In ListaBandaMarcas
                bandMarca = band.Children.Add()
                bandMarca.Caption = itemmarca.Trim
                bandMarca.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                listBands.Add(bandMarca)
            Next
        Next

        For Each row As DataRow In dtEncabezados.Rows
            ListaColumnasGrid.Add(row.Item("ColumnaOrigen").ToString())

            BandaAux = listBands.AsEnumerable().FirstOrDefault(Function(x) x.Caption = row.Item("Marca") And x.ParentBand.Caption = row.Item("Cuatrimestre"))

            bgvReporte.Columns.AddField(row.Item("ColumnaOrigen").ToString().ToUpper)
            bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).OwnerBand = BandaAux
            bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).Visible = True
            bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString.ToUpper).Caption = row.Item("NombreColumna")

            If row.Item("ColumnaOrigen").ToString().ToUpper <> "MARCA" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "AGENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "CLIENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "RUTA" Then
                bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            End If
            If row.Item("ColumnaOrigen").ToString().ToUpper <> "MARCA" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "INDICADOR" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "AGENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "CLIENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "RUTA" Then
                bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).DisplayFormat.FormatString = "N0"
            End If

        Next

        For Each gridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In listBands
            If gridBand.Caption = "" Then
                gridBand.Caption = "Última actualización: " + lblFechaUltimaActualización.Text
            End If
            If gridBand.Caption = "-" Then
                gridBand.Caption = ""
            End If

            'If gridBand.Caption.ToUpper.Contains("TOTAL") Then
            '    gridBand.Caption = ""
            'End If
        Next



        For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In bgvReporte.Bands
            gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            gridband.AppearanceHeader.Options.UseBackColor = True
            If gridband.Caption = "CUATRIMESTRE 1" Then
                gridband.AppearanceHeader.BackColor = Color.FromArgb(216, 228, 188)
            ElseIf gridband.Caption = "CUATRIMESTRE 2" Then
                gridband.AppearanceHeader.BackColor = Color.FromArgb(255, 255, 204)
            ElseIf gridband.Caption = "CUATRIMESTRE 3" Then
                gridband.AppearanceHeader.BackColor = Color.FromArgb(220, 230, 241)
            End If

        Next

        bgvReporte.Bands(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        bgvReporte.ColumnPanelRowHeight = 50



        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvReporte.Columns
            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'Col.BestFit()
            If Col.FieldName = "#" Then
                Col.Width = 30
            End If

            If Col.FieldName = "INDICADOR" Then
                If tipoReporte <> 4 And tipoReporte <> 6 Then
                    Col.Width = 175
                Else
                    Col.Width = 185
                End If
            End If
            If Col.FieldName = "MARCA" Then
                If tipoReporte <> 4 And tipoReporte <> 6 Then
                    Col.Width = 100
                Else
                    Col.Width = 90
                End If
            End If
            If Col.FieldName = "TOTAL" Then
                Col.Width = 100
            End If
            If Col.FieldName = "AGENTE" Then
                If tipoReporte <> 4 And tipoReporte <> 6 Then
                    Col.Width = 170
                Else
                    Col.Width = 185
                End If
            End If
            If Col.FieldName = "CLIENTE" Then
                Col.Width = 180

            End If

            If Col.FieldName = "CIUDAD" Then
                Col.Width = 140
                'Col.BestFit()
            End If

            If Col.FieldName = "RUTA" Then
                Col.Width = 120
            End If

            If Col.FieldName = "TDAS" Then
                Col.Width = 45
            End If

            If Col.FieldName = "CLASIF" Then
                Col.Width = 45
            End If

            If Col.FieldName = "EDO" Then
                Col.Width = 45
            End If

        Next

    End Sub

    Private Sub bgvReporte_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = bgvReporte.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub diseñoGridResultadoSinBand(ByVal dtResultadoReporte As DataTable)
        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim listBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)

        bgvReporte.OptionsView.AllowCellMerge = False
        bgvReporte.OptionsView.ColumnAutoWidth = True
        bgvReporte.Columns.Clear()
        bgvReporte.Bands.Clear()

        band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        band.Caption = "Última actualización: " + lblFechaUltimaActualización.Text
        bgvReporte.Bands.Add(band)

        If IsNothing(bgvReporte.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            bgvReporte.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            bgvReporte.Columns.ColumnByFieldName("#").OwnerBand = bgvReporte.Bands(0)
            AddHandler bgvReporte.CustomUnboundColumnData, AddressOf bgvReporte_CustomUnboundColumnData
            bgvReporte.Columns.Item("#").VisibleIndex = 0
        End If

        For Each col As DataColumn In dtResultadoReporte.Columns
            bgvReporte.Columns.AddField(col.ColumnName.ToString())
            bgvReporte.Columns.ColumnByFieldName(col.ColumnName.ToString()).OwnerBand = bgvReporte.Bands(0)
            bgvReporte.Columns.ColumnByFieldName(col.ColumnName.ToString()).Visible = True
            If col.ColumnName.ToUpper <> "DESCRIPCIÓN" And col.ColumnName.ToUpper <> "CLASIFICACIÓN" Then
                bgvReporte.Columns.ColumnByFieldName(col.ColumnName).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                If col.ColumnName.ToUpper = "PROPORCIÓN" Then
                    bgvReporte.Columns.ColumnByFieldName(col.ColumnName).DisplayFormat.FormatString = "N1"
                Else
                    bgvReporte.Columns.ColumnByFieldName(col.ColumnName).DisplayFormat.FormatString = "N0"
                End If
            End If

        Next



        bgvReporte.ColumnPanelRowHeight = 40

        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvReporte.Columns
            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'Col.BestFit()
            If Col.FieldName = "#" Then
                Col.Width = 30
            End If
            If Col.FieldName = "Agente" Then
                Col.Width = 180
            End If
        Next


    End Sub

    Private Function obtenerFiltros() As Boolean
        filtro_Agente = ""
        filtro_Marca = ""
        filtro_Cliente = ""
        filtro_familia = ""

        filtro_FechaInicio = dtpFechaEntregaDel.Value.ToShortDateString()
        filtro_FechaFin = dtpFechaEntregaAl.Value.ToShortDateString()

        For Each Row As UltraGridRow In grdAgentes.Rows
            If filtro_Agente <> "" Then
                filtro_Agente += ","
            End If
            filtro_Agente += Row.Cells("Parametro").Value.ToString()
        Next
        For Each row As UltraGridRow In grdFamilias.Rows
            If row.Index = 0 Then
                filtro_familia += "" + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                filtro_familia += "," + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next
        For Each Row As UltraGridRow In grdMarcas.Rows
            If filtro_Marca <> "" Then
                filtro_Marca += ","
            End If
            filtro_Marca += Row.Cells("Parametro").Value.ToString()
        Next
        For Each Row As UltraGridRow In grdClientes.Rows
            If filtro_Cliente <> "" Then
                filtro_Cliente += ","
            End If
            filtro_Cliente += Row.Cells("Parametro").Value.ToString()
        Next

        If perfilUsuario = 74 Then
            If filtro_Agente <> "" And filtro_Cliente <> "" Then
                Return True
            Else
                show_message("Advertencia", "Es necesario seleccionarl al menos un agente y un cliente")
                Return False
            End If
        End If

        Return True
    End Function

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

    Private Sub bgvReporte_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles bgvReporte.CustomDrawCell
        Dim currentView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)

        If e.Column.FieldName.ToString.Contains("%") Then
            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) = False Then
                If tipoReporte <> 4 Then
                    e.Appearance.BackColor = ObtenerColorCelda(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                    e.Appearance.ForeColor = ObtenerColorLetra(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                End If
                e.DisplayText = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.DisplayText.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
            Else
                currentView.SetRowCellValue(e.RowHandle, e.Column, 0)
                e.DisplayText = "0"
                'currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)
            End If
        End If

        If IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) = True Then
            If e.Column.FieldName <> "RUTA" AndAlso e.Column.FieldName <> "CLIENTE" AndAlso e.Column.FieldName <> "CIUDAD" AndAlso e.Column.FieldName <> "EDO" AndAlso e.Column.FieldName <> "CLASIF" AndAlso e.Column.FieldName <> "TDAS" Then
                e.DisplayText = "0"
            End If

        End If

        If e.Column.Caption.Contains("TOTAL") = True Then
            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) = False Then
                e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
            End If
        End If


    End Sub

    Private Function ObtenerColorCelda(ByVal Valor As Integer) As Color
        Dim TipoColor As Color = Color.Empty


        If Valor < 100 Then
            TipoColor = Color.Pink
        ElseIf Valor >= 100 And Valor <= 120 Then
            TipoColor = Color.LightGreen
        ElseIf Valor > 120 Then
            TipoColor = Color.Thistle
        End If

        Return TipoColor

    End Function

    Private Function ObtenerColorLetra(ByVal Valor As Integer) As Color
        Dim TipoColor As Color = Color.Empty


        If Valor < 100 Then
            TipoColor = Color.Red
        ElseIf Valor >= 100 And Valor <= 120 Then
            TipoColor = Color.Green
        ElseIf Valor > 120 Then
            TipoColor = Color.Purple
        End If

        Return TipoColor

    End Function

    Private Sub bgvReporte_CustomDrawColumnHeader(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs) Handles bgvReporte.CustomDrawColumnHeader
        'If e.Column IsNot Nothing Then

        '    e.Column.AppearanceHeader.Options.UseBackColor = True
        '    e.Column.AppearanceHeader.BackColor = Color.Green
        '    e.Column.AppearanceHeader.BackColor2 = Color.LightGreen


        '    Dim rect As Rectangle = e.Bounds
        '    ControlPaint.DrawBorder3D(e.Graphics, e.Bounds)
        '    'Dim brush As Brush = e.Cache.GetGradientBrush(rect, e.Column.AppearanceHeader.BackColor, e.Column.AppearanceHeader.BackColor2, )
        '    Dim brush As Brush = e.Cache.GetSolidBrush(Color.Yellow)

        '    rect.Inflate(-1, -1)
        '    ' Fill column headers with the specified colors.
        '    e.Graphics.FillRectangle(brush, rect)

        '    e.Appearance.DrawString(e.Cache, e.Info.Caption, e.Info.CaptionRect)
        '    ' Draw the filter and sort buttons.
        '    Dim I As Integer = 0
        '    For Each info As DevExpress.Utils.Drawing.DrawElementInfo In e.Info.InnerElements
        '        If I = 5 Then
        '            DevExpress.Utils.Drawing.ObjectPainter.DrawObject(e.Cache, info.ElementPainter, info.ElementInfo)
        '        End If
        '        I += 1

        '    Next info
        '    e.Handled = True

        '    e.Info.BackAppearance.BackColor = Color.YellowGreen

        '    'If e.Column.Caption = "CUATRIMESTRE 1" Then
        '    '    e.Info.BackAppearance.BackColor = Color.YellowGreen
        '    'ElseIf e.Column.Caption = "CUATRIMESTRE 2" Then
        '    '    e.Info.BackAppearance.BackColor = Color.LemonChiffon
        '    'ElseIf e.Column.Caption = "CUATRIMESTRE 3" Then
        '    '    e.Info.BackAppearance.BackColor = Color.LightSteelBlue
        '    'End If

        '    e.Handled = True
        'End If
    End Sub

    Private Sub cmboxTipoReporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmboxTipoReporte.SelectedIndexChanged
        If cmboxTipoReporte.SelectedIndex = 0 Then
            lblFactorFrecuenciaCompra.Visible = False
            spinFactorFrecuencia.Visible = False
            grpbxFiltroFechas.Text = "Fecha de Programación de Pedidos"
            lblTextoPedidos.Text = "Pedidos: Rango de fechas de programación de pedidos"
        ElseIf cmboxTipoReporte.SelectedIndex = 1 Then
            lblFactorFrecuenciaCompra.Visible = True
            spinFactorFrecuencia.Visible = True
            grpbxFiltroFechas.Text = "Fecha de Captura del Pedido"
            lblTextoPedidos.Text = "Pedidos: Rango de fechas de captura del pedido"
        End If

        If cmboxTipoReporte.SelectedIndex = 3 Then GroupBox5.Visible = False Else GroupBox5.Visible = True

    End Sub



    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If bgvReporte.DataRowCount > 0 Or vwReporteResumen.DataRowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty
            Dim nombreReporteParaExportacion As String = String.Empty
            Dim objBU As New Negocios.EstadisticoPedidosBU
            Dim exportOptions = New XlsxExportOptionsEx()
            Try



                Select Case cmboxTipoReporte.SelectedIndex + 1
                    Case 1
                        nombreReporte = "\SeguimientoAgente_"
                        nombreReporteParaExportacion = " SEGUIMIENTO DE VENTAS (SEGUIMIENTO DE VENTAS POR AGENTE)"
                        exportOptions.SheetName = "SeguimientoAgentes"
                    Case 2
                        nombreReporte = "\FrecuenciaCompra_"
                        nombreReporteParaExportacion = "SEGUIMIENTO DE VENTAS (FRECUENCIA DE COMPRA POR CLIENTE)"
                        exportOptions.SheetName = "FrecuenciaCompra"
                End Select

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If bgvReporte.GroupCount > 0 Then
                            bgvReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + "_V1.xlsx")
                        Else

                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                            If tipoReporte = 3 Then
                                grdReporteResumen.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + "_V1" + ".xlsx", exportOptions)
                            Else
                                grdReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + "_V1" + ".xlsx", exportOptions)
                            End If

                        End If

                        show_message("Exito", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & "_V1.xlsx")

                        .Dispose()

                        objBU.bitacoraExportacionExcel(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "EXCEL", "SAY", nombreReporteParaExportacion, dtpFechaEntregaDel.Value.ToShortDateString(), dtpFechaEntregaAl.Value.ToShortDateString())

                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + "_V1.xlsx")
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

        Try

            If tipoReporte = 1 Then
                If IsDBNull(e.Value) = False Then
                    If IsNumeric(e.Value) = False Then
                        If dtEncabezadoAgente.AsEnumerable().Where(Function(x) x.Item("ColumnaOrigen") = e.Value.ToString).Count > 0 Then
                            Dim NombreColumna = dtEncabezadoAgente.AsEnumerable().FirstOrDefault(Function(x) x.Item("ColumnaOrigen") = e.Value)
                            e.Value = NombreColumna.Item("NombreColumna")
                        End If
                    End If
                End If
            ElseIf tipoReporte = 2 Then
                If IsDBNull(e.Value) = False Then
                    If IsNumeric(e.Value) = False Then
                        If dtEncabezadoFrecuenciaCompra.AsEnumerable().Where(Function(x) x.Item("ColumnaOrigen") = e.Value.ToString).Count > 0 Then
                            Dim NombreColumna = dtEncabezadoFrecuenciaCompra.AsEnumerable().FirstOrDefault(Function(x) x.Item("ColumnaOrigen") = e.Value)
                            e.Value = NombreColumna.Item("NombreColumna")
                        End If
                    End If
                End If

            End If

            If IsDBNull(e.Value) = True Then
                If e.ColumnFieldName <> "RUTA" AndAlso e.ColumnFieldName <> "CLIENTE" AndAlso e.ColumnFieldName <> "CIUDAD" AndAlso e.ColumnFieldName <> "EDO" AndAlso e.ColumnFieldName <> "CLASIF" AndAlso e.ColumnFieldName <> "TDAS" Then
                    e.Value = "0"
                End If
            End If

            If e.ColumnFieldName.ToString.Contains("%") Then
                If IsDBNull(bgvReporte.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) = False Then
                    e.Formatting.BackColor = ObtenerColorCelda(bgvReporte.GetRowCellValue(e.RowHandle, e.ColumnFieldName))
                    e.Formatting.Font.Color = ObtenerColorLetra(bgvReporte.GetRowCellValue(e.RowHandle, e.ColumnFieldName))
                    If IsNumeric(e.Value) = True Then
                        e.Value = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.Value.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
                    End If

                End If
            End If

            If e.ColumnFieldName.Contains("TOTAL") = True Then
                If IsDBNull(bgvReporte.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) = False Then
                    e.Formatting.Font.Bold = True
                End If
            End If


            If IsDBNull(e.Value) = False Then
                If IsNumeric(e.Value) = False Then
                    If e.Value = "CUATRIMESTRE 1" Then
                        e.Formatting.BackColor = Color.FromArgb(216, 228, 188)
                    ElseIf e.Value = "CUATRIMESTRE 2" Then
                        e.Formatting.BackColor = Color.FromArgb(255, 255, 204)
                    ElseIf e.Value = "CUATRIMESTRE 3" Then
                        e.Formatting.BackColor = Color.FromArgb(220, 230, 241)
                    End If
                End If



            End If




        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try



        e.Handled = True
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_SeguimientoAgentes_V1.pdf")
            Process.Start("Descargas\Manuales\Ventas\COVE_MAUS_SeguimientoAgentes_V1.pdf")
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        grdFamilias.DataSource = listInicial
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 21
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFamilias.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFamilias.DataSource = listado.listParametros
        With grdFamilias
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Familia"
        End With
    End Sub

    '' Solo para el tipo de reporte 4 -- Frecuencia de Pedidos por Cliente
    Private Sub AgruparPorClasificacionReporteFrecuenciaPedidos()

        bgvReporte.AppearancePrint.FooterPanel.BackColor = Color.Green

        bgvReporte.Columns("RUTA").Group()

        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem
        Dim nombreColumna As String = String.Empty
        Dim nombreColumnaCaption As String = String.Empty

        bgvReporte.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        bgvReporte.GroupSummary.Clear()

        For index = 0 To bgvReporte.Columns.Count - 1
            nombreColumna = bgvReporte.Columns(index).Name
            nombreColumnaCaption = bgvReporte.Columns(index).Caption

            If nombreColumnaCaption.Equals("RUTA") Or nombreColumnaCaption.Equals("CLIENTE") Or nombreColumnaCaption.Equals("AGENTE") Or nombreColumnaCaption.Equals("CLASIF") Or nombreColumnaCaption.Equals("% VTA VS PROY") Then
                Continue For
            Else
                bgvReporte.Columns.ColumnByName(nombreColumna).Summary.Add(DevExpress.Data.SummaryItemType.Sum, nombreColumnaCaption, "{0:N0}")

                item = New DevExpress.XtraGrid.GridGroupSummaryItem
                item.FieldName = nombreColumnaCaption
                item.ShowInGroupColumnFooter = bgvReporte.Columns.ColumnByName(nombreColumna)
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:N0}"
                bgvReporte.GroupSummary.Add(item)
            End If
        Next

        RenombrarCuatrimestre()
        AjustarColumnas()
        bgvReporte.OptionsBehavior.AutoExpandAllGroups = True


    End Sub

    '' Solo para el tipo de reporte 4 -- Frecuencia de Pedidos por Cliente
    Private Sub RenombrarCuatrimestre()
        If Not bgvReporte.Columns("1") Is Nothing Then
            bgvReporte.Columns("1").Caption = "PROY " + "1C-" + DateTime.Today.Year.ToString
        End If
        If Not bgvReporte.Columns("2") Is Nothing Then
            bgvReporte.Columns("2").Caption = "PROY " + "2C-" + DateTime.Today.Year.ToString
        End If

        If Not bgvReporte.Columns("3") Is Nothing Then
            bgvReporte.Columns("3").Caption = "PROY " + "3C-" + DateTime.Today.Year.ToString
        End If

    End Sub


    Private Function EstaVaciaFila(listaBand As List(Of GridBand)) As Boolean
        Dim estaVacia As Boolean = True

        For index = 0 To listaBand.Count - 1
            If Not String.IsNullOrEmpty(listaBand(index).Caption) Then
                estaVacia = False
                Exit For
            End If
        Next

        Return estaVacia
    End Function

    Private Sub AjustarColumnas()
        bgvReporte.OptionsView.ColumnAutoWidth = False
        bgvReporte.Columns.ColumnByFieldName("CLIENTE").Width = 100
        bgvReporte.Columns.ColumnByFieldName("1").Width = 40
        bgvReporte.Columns.ColumnByFieldName("CLASIF").Width = 50
        bgvReporte.Columns.ColumnByFieldName("% VTA VS PROY").Width = 50
        bgvReporte.Columns.ColumnByFieldName("TDAS").Width = 50

    End Sub

    Private Sub bgvReporte_CustomDrawRowFooter(sender As Object, e As RowObjectCustomDrawEventArgs) Handles bgvReporte.CustomDrawRowFooter
        If tipoReporte = 4 Then
            e.Cache.FillRectangle(e.Cache.GetGradientBrush(e.Bounds, Color.FromArgb(176, 196, 222), Color.FromArgb(217, 225, 242), System.Drawing.Drawing2D.LinearGradientMode.Horizontal), e.Bounds)
            'Prevent default painting
            e.Handled = True
        End If
    End Sub

    Private Sub diseñoGridResultadoFrecuenciaPedidosCliente(ByVal spid As Integer)
        Dim objBu As New Negocios.SeguimientoVentasBU
        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim listBandsTextos As New List(Of String)
        Dim listBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        Dim listBandsMarcas As New List(Of String)
        Dim BandaAux As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim dtEncabezados As New DataTable
        Dim filaVacia As Boolean = False

        dtEncabezados = objBu.SeguimientoVentasObtenerEncabezadosTabla(spid)

        If IsNothing(dtEncabezadoAgente) = True Then
            dtEncabezadoAgente = dtEncabezados.Copy()
        Else
            dtEncabezadoAgente = Nothing
            dtEncabezadoAgente = dtEncabezados.Copy()
        End If

        bgvReporte.OptionsView.AllowCellMerge = True
        bgvReporte.OptionsView.ColumnAutoWidth = False
        bgvReporte.Columns.Clear()
        bgvReporte.Bands.Clear()

        grdReporte.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        grdReporte.LookAndFeel.UseDefaultLookAndFeel = False

        'Primer Nivel Cuatrimestre

        Dim ListaBandaCuatrimestre = dtEncabezados.AsEnumerable().Select(Function(x) x.Item("Cuatrimestre")).Distinct.ToList

        Dim cadenas As String = ""
        For Each item As String In ListaBandaCuatrimestre

            listBandsTextos.Add(item.Trim())

            band = bgvReporte.Bands.Add
            band.AppearanceHeader.Options.UseBackColor = True

            band.Caption = item.Trim()

            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            listBands.Add(band)
        Next

        For Each row As DataRow In dtEncabezados.Rows
            ListaColumnasGrid.Add(row.Item("ColumnaOrigen").ToString())

            BandaAux = listBands.AsEnumerable().FirstOrDefault(Function(x) x.Caption = row.Item("Cuatrimestre"))

            bgvReporte.Columns.AddField(row.Item("ColumnaOrigen").ToString().ToUpper)
            bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).OwnerBand = BandaAux
            bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).Visible = True
            bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString.ToUpper).Caption = row.Item("NombreColumna")

            If row.Item("ColumnaOrigen").ToString().ToUpper <> "MARCA" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "AGENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "CLIENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "RUTA" Then
                bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            End If
            If row.Item("ColumnaOrigen").ToString().ToUpper <> "MARCA" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "INDICADOR" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "AGENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "CLIENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "RUTA" Then
                bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).DisplayFormat.FormatString = "N0"
            End If

        Next

        bgvReporte.Bands(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        bgvReporte.ColumnPanelRowHeight = 50

    End Sub
End Class