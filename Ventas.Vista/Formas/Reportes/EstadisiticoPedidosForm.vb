Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraPrinting
Imports System.IO

Public Class EstadisiticoPedidosForm

    Dim listInicial As New List(Of String)
    Dim filtro_Agente As String = String.Empty
    Dim filtro_Marca As String = String.Empty
    Dim filtro_Cliente As String = String.Empty
    Dim filtro_FechaInicio As String = String.Empty
    Dim filtro_FechaFin As String = String.Empty
    Dim conFiltros As Boolean = False
    Dim perfilId As Integer = 0

    Private Sub EstadisiticoPedidosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objBU As New Negocios.EstadisticoPedidosBU
        Dim dtResultadoPerfil As New DataTable
        Dim objResumenVentasBU As New Negocios.ResumenVentasSemanalBU

        'dtpFechaEntregaDel.MinDate = Date.Parse("01/01/2015")
        'dtpFechaEntregaAl.MinDate = Date.Parse("01/01/2015")
        'dtpFechaEntregaDel.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
        ''dtpFechaEntregaAl.Value = Date.Parse("31/12/" + Date.Now.Year.ToString())
        'dtpFechaEntregaAl.Value = New Negocios.ResumenVentasSemanalBU().ConsultarFechaFinEstadVentas_Semanal()
        dtpFechaEntregaDel.Value = objResumenVentasBU.ConsultarFechaInicioEstadVentas_Semanal()
        dtpFechaEntregaAl.Value = objResumenVentasBU.ConsultarFechaFinEstadVentas_Semanal()

        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized
        cmboxTipoReporte.SelectedIndex = 0
        grdAgentes.DataSource = listInicial
        grdMarcas.DataSource = listInicial
        grdClientes.DataSource = listInicial

        dtResultadoPerfil = objBU.consultaPerfilUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        If dtResultadoPerfil.Rows.Count > 0 Then

            For Each row As DataRow In dtResultadoPerfil.Rows

                perfilId = row("perfilId")

                If row("perfilId") = 44 Then



                    GroupBox2.Enabled = False
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
            Next

        End If

    End Sub

#Region "Filtros"

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

        If perfilId = 44 Then
            listado.idUsuario = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser
            listado.tipo_busqueda = 9

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
        Else
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
        End If
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametrosReportesForm
        If perfilId <> 44 And perfilId <> 74 Then
            listado.tipo_busqueda = 2
        Else
            listado.tipo_busqueda = 4
        End If

        listado.idUsuario = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser

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

    Private Sub grdAgentes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdAgentes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdMarcas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdMarcas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdClientes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
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

    Private Function obtenerFiltros() As Boolean
        filtro_Agente = ""
        filtro_Marca = ""
        filtro_Cliente = ""
        conFiltros = False


        filtro_FechaInicio = dtpFechaEntregaDel.Value.ToShortDateString()
        filtro_FechaFin = dtpFechaEntregaAl.Value.ToShortDateString()

        For Each Row As UltraGridRow In grdAgentes.Rows
            If filtro_Agente <> "" Then
                filtro_Agente += ","
            End If
            filtro_Agente += Row.Cells("Parametro").Value.ToString()
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

        If filtro_Agente <> "" Or filtro_Marca <> "" Or filtro_Cliente <> "" Then
            conFiltros = True
        End If


        If perfilId = 74 Then
            If filtro_Agente = "" Or filtro_Cliente = "" Then
                show_message("Advertencia", "Es necesario seleccionar al menos un agente y un cliente")
                Return False
            Else
                Return True
            End If
        End If
        Return True
    End Function

    Private Sub btnLimpiarFiltroAgente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroAgente.Click
        grdAgentes.DataSource = listInicial
    End Sub

    Private Sub btnLimpiarFiltroMarca_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroMarca.Click
        grdMarcas.DataSource = listInicial
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdClientes.DataSource = listInicial
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

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click

        Cursor = Cursors.WaitCursor

        EstadisticoPedidos(cmboxTipoReporte.SelectedIndex + 1)

        Cursor = Cursors.Default

    End Sub

    Private Sub diseñoGridResultado(ByVal spid As Integer)
        Dim objBu As New Negocios.EstadisticoPedidosBU
        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim listBandsTextos As New List(Of String)
        Dim listBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)

        Dim dtEncabezados As New DataTable

        dtEncabezados = objBu.reporteEstadisticoPedidosObtenerEncabezadosTabla(spid)

        dtEncabezados.Rows.Add("-", "TOTAL")


        bgvReportePedidos.OptionsView.AllowCellMerge = True
        bgvReportePedidos.Columns.Clear()
        bgvReportePedidos.Bands.Clear()

        For Each row As DataRow In dtEncabezados.Rows
            If listBandsTextos.Contains(row.Item("Mes").ToString()) = False Then
                listBandsTextos.Add(row.Item("Mes").ToString())

                band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                band.Caption = row.Item("Mes").ToString()
                listBands.Add(band)
            End If

            For Each gridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In listBands
                If gridBand.Caption = "" Then
                    If IsNothing(bgvReportePedidos.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
                        bgvReportePedidos.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
                        bgvReportePedidos.Columns.ColumnByFieldName("#").OwnerBand = gridBand
                        AddHandler bgvReportePedidos.CustomUnboundColumnData, AddressOf bgvReportePedidos_CustomUnboundColumnData
                        bgvReportePedidos.Columns.Item("#").VisibleIndex = 0
                    End If
                End If
                If row("Mes").ToString() = gridBand.Caption Then
                    bgvReportePedidos.Columns.AddField(row.Item("SemanaDia").ToString().ToUpper)
                    bgvReportePedidos.Columns.ColumnByFieldName(row.Item("SemanaDia").ToString().ToUpper).OwnerBand = gridBand
                    bgvReportePedidos.Columns.ColumnByFieldName(row.Item("SemanaDia").ToString().ToUpper).Visible = True
                    If row.Item("SemanaDia").ToString().ToUpper <> "MARCA" And row.Item("SemanaDia").ToString().ToUpper <> "AGENTE" And row.Item("SemanaDia").ToString().ToUpper <> "CLIENTE" And row.Item("SemanaDia").ToString().ToUpper <> "RUTA" Then
                        bgvReportePedidos.Columns.ColumnByFieldName(row.Item("SemanaDia").ToString().ToUpper).OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                    End If
                    If row.Item("SemanaDia").ToString().ToUpper <> "MARCA" And row.Item("SemanaDia").ToString().ToUpper <> "INDICADOR" And row.Item("SemanaDia").ToString().ToUpper <> "AGENTE" And row.Item("SemanaDia").ToString().ToUpper <> "CLIENTE" And row.Item("SemanaDia").ToString().ToUpper <> "RUTA" Then
                        bgvReportePedidos.Columns.ColumnByFieldName(row.Item("SemanaDia").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                        bgvReportePedidos.Columns.ColumnByFieldName(row.Item("SemanaDia").ToString().ToUpper).DisplayFormat.FormatString = "N0"
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
            bgvReportePedidos.Bands.Add(gridBand)
        Next
        For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In bgvReportePedidos.Bands
            gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        bgvReportePedidos.Bands(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        bgvReportePedidos.ColumnPanelRowHeight = 40

        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvReportePedidos.Columns
            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'Col.BestFit()
            If Col.FieldName = "#" Then
                Col.Width = 30
            End If
            If Col.FieldName.Contains(",") Then
                Col.Caption = Col.FieldName.Split(",")(0).ToString + vbCrLf + Col.FieldName.Split(",")(1).ToString
                Col.Width = 80
            End If
            If Col.FieldName = "INDICADOR" Then
                Col.Width = 175
            End If
            If Col.FieldName = "MARCA" Then
                Col.Width = 100
            End If
            If Col.FieldName = "TOTAL" Then
                Col.Width = 100
            End If
            If Col.FieldName = "AGENTE" Then
                Col.Width = 170
            End If
            If Col.FieldName = "CLIENTE" Then
                Col.Width = 180
            End If
            If Col.FieldName = "RUTA" Then
                Col.Width = 120
            End If
        Next


    End Sub

    Private Sub bgvReportePedidos_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = bgvReportePedidos.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub bgvReportePedidos_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles bgvReportePedidos.CustomDrawCell

        Dim currentView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)

        Try
            'Cursor = Cursors.WaitCursor
            If e.Column.FieldName <> "MARCA" And e.Column.FieldName <> "INDICADOR" And e.Column.FieldName <> "#" And e.Column.FieldName <> "AGENTE" And e.Column.FieldName <> "CLIENTE" And e.Column.FieldName <> "RUTA" Then
                If IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Or IsNothing(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                    currentView.SetRowCellValue(e.RowHandle, e.Column.FieldName, 0)
                    e.DisplayText = "0"
                End If
                If currentView.GetRowCellValue(e.RowHandle, "INDICADOR").ToString().Contains("%") Then
                    e.Appearance.BackColor = ObtenerColorCelda(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                    e.Appearance.ForeColor = ObtenerColorLetra(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                    e.DisplayText = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.DisplayText.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
                End If
            End If

            'Cursor = Cursors.Default
        Catch ex As Exception
            'Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
        'End If


    End Sub

#Region "Tipos Reporte"

    Private Sub EstadisticoPedidos(ByVal TipoReporte As Integer)
        Dim objBU As New Negocios.EstadisticoPedidosBU
        Dim dtResultadoReporte As New DataTable
        Dim spid As Integer = 0

        If obtenerFiltros() Then
            If conFiltros = True Then
                dtResultadoReporte = objBU.reporteEstadisticoPedidosConFiltros(filtro_FechaInicio, filtro_FechaFin, filtro_Agente, filtro_Marca, filtro_Cliente, TipoReporte)
            Else
                dtResultadoReporte = objBU.reporteEstadisticoPedidosSinFiltros(filtro_FechaInicio, filtro_FechaFin, TipoReporte)
            End If

            If dtResultadoReporte.Rows.Count > 0 Then

                'lblNumRegistros.Text = Integer.Parse(grvReportePedidos.RowCount.ToString()).ToString("n0")
                lblFechaUltimaActualización.Text = DateTime.Now.ToString()

                spid = Integer.Parse(dtResultadoReporte.Rows(0).Item("spid").ToString())

                grdReportePedidos.DataSource = Nothing

                diseñoGridResultado(spid)

                dtResultadoReporte.Rows(dtResultadoReporte.Rows.Count - 1).Item("TOTAL") = dtResultadoReporte.Rows(dtResultadoReporte.Rows.Count - 1).Item(dtResultadoReporte.Columns(dtResultadoReporte.Columns.Count - 2).ColumnName.ToString())

                grdReportePedidos.DataSource = dtResultadoReporte

                btnArriba_Click(Nothing, Nothing)
            Else
                grdReportePedidos.DataSource = Nothing
                bgvReportePedidos.Bands.Clear()
                bgvReportePedidos.Columns.Clear()
                show_message("Aviso", "No hay datos para mostrar.")
            End If
        End If
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

#End Region

#Region "EXPORTAR EXCEL"

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If bgvReportePedidos.DataRowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty
            Dim nombreReporteParaExportacion As String = String.Empty
            Dim objBU As New Negocios.EstadisticoPedidosBU

            Try

                Select Case cmboxTipoReporte.SelectedIndex + 1
                    Case 1
                        nombreReporte = "\Estadistico_Pedidos_"
                        nombreReporteParaExportacion = "ESTADÍSTICO PEDIDOS"
                    Case 2
                        nombreReporte = "\Pedidos_Agente_"
                        nombreReporteParaExportacion = "PEDIDOS AGENTE"
                    Case 3
                        nombreReporte = "\Pedidos_Cliente_"
                        nombreReporteParaExportacion = "PEDIDOS CLIENTE"
                    Case 4
                        nombreReporte = "\Pedidos_Ruta_"
                        nombreReporteParaExportacion = "PEDIDOS RUTA"

                End Select

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If bgvReportePedidos.GroupCount > 0 Then
                            bgvReportePedidos.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell


                            grdReportePedidos.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)

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

        Try
            If e.RowHandle > 0 Then
                If e.ColumnFieldName <> "MARCA" And e.ColumnFieldName <> "INDICADOR" And e.ColumnFieldName <> "#" And e.ColumnFieldName <> "AGENTE" And e.ColumnFieldName <> "CLIENTE" And e.ColumnFieldName <> "RUTA" Then
                    If IsDBNull(bgvReportePedidos.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) Or IsNothing(bgvReportePedidos.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) Then
                        bgvReportePedidos.SetRowCellValue(e.RowHandle, e.ColumnFieldName, 0)
                        e.Value = 0
                    End If
                    If bgvReportePedidos.GetRowCellValue(e.RowHandle, "INDICADOR").ToString().Contains("%") Then
                        e.Formatting.BackColor = ObtenerColorCelda(bgvReportePedidos.GetRowCellValue(e.RowHandle, e.ColumnFieldName))
                        e.Formatting.Font.Color = ObtenerColorLetra(bgvReportePedidos.GetRowCellValue(e.RowHandle, e.ColumnFieldName))
                        e.Value = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.Value.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
                    End If
                End If
            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

        e.Handled = True
    End Sub

#End Region

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        If perfilId = 0 Or perfilId <> 44 Then
            grdAgentes.DataSource = listInicial
        End If
        grdReportePedidos.DataSource = Nothing
        bgvReportePedidos.Bands.Clear()
        bgvReportePedidos.Columns.Clear()
        cmboxTipoReporte.SelectedIndex = 0
        grdMarcas.DataSource = listInicial
        grdClientes.DataSource = listInicial
        dtpFechaEntregaAl.Value = Date.Parse("31/12/" + Date.Now.Year.ToString())
        dtpFechaEntregaDel.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
        lblFechaUltimaActualización.Text = "-"
        btnAbajo_Click(sender, e)
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        'Try
        '    Dim pdf As Byte() = My.Resources.COVE_MAUS_Estadistico_Ventas_V1
        '    Using tmp As New FileStream("COVE_MAUS_Estadistico_Pedidos_V1.pdf", FileMode.Create)
        '        tmp.Write(pdf, 0, pdf.Length)
        '    End Using
        '    Process.Start("COVE_MAUS_Estadistico_Pedidos_V1.pdf")
        'Catch ex As Exception

        'End Try
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_Estadistico_Ventas_V1.pdf")
            Process.Start("Descargas\Manuales\Ventas\COVE_MAUS_Estadistico_Ventas_V1.pdf")
        Catch ex As Exception

        End Try

    End Sub

End Class