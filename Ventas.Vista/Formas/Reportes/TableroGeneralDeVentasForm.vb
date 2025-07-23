Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraPrinting

Public Class TableroGeneralDeVentasForm

    Dim listInicial As New List(Of String)
    Dim filtro_Agente As String = String.Empty
    Dim filtro_Marca As String = String.Empty
    Dim filtro_Cliente As String = String.Empty
    Dim filtro_FechaInicio As String = String.Empty
    Dim filtro_FechaFin As String = String.Empty
    Dim tipoReporte As Integer = 0
    Dim perfilId As Integer = 0
    Private Sub TableroGeneralDeVentasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objBu As New Negocios.TableroGeneralVentasBU
        Dim dtPerfilUsuario As DataTable

        'dtpFechaEntregaDel.MinDate = Date.Parse("01/01/2015")
        'dtpFechaEntregaAl.MinDate = Date.Parse("01/01/2015")
        'dtpFechaEntregaDel.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
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

        dtPerfilUsuario = objBu.consultaPerfilUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        If dtPerfilUsuario.Rows.Count > 0 Then

            perfilId = dtPerfilUsuario.Rows(0).Item("perfilId")

            If dtPerfilUsuario.Rows(0).Item("perfilId") = 44 Then
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

            End If            
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

        If perfilId = 44 Then
            listado.idUsuario = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser

            listado.tipo_busqueda = 7
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
        Else
            If perfilId = 74 Then
                listado.tipo_busqueda = 4
            Else
                listado.idUsuario = 0
                listado.tipo_busqueda = 2
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

        End If

        

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

        If perfilId = 74 Then
            If filtro_Agente <> "" And filtro_Cliente <> "" Then
                Return True
            Else
                show_message("Advertencia", "Es necesario seleccionar al menos un agente y un cliente")
                Return False
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

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 206
    End Sub

#End Region

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdReporte.DataSource = Nothing
        bgvReporte.Bands.Clear()
        bgvReporte.Columns.Clear()
        cmboxTipoReporte.SelectedIndex = 0
        If perfilId <> 44 Then
            grdAgentes.DataSource = listInicial
        End If
        grdMarcas.DataSource = listInicial
        grdClientes.DataSource = listInicial
        dtpFechaEntregaAl.Value = Date.Parse("31/12/" + Date.Now.Year.ToString())
        dtpFechaEntregaDel.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
        lblFechaUltimaActualización.Text = "-"
        btnAbajo_Click(sender, e)
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_TableroGeneral_Pedidos_V1.pdf")
            Process.Start("Descargas\Manuales\Ventas\COVE_MAUS_TableroGeneral_Pedidos_V1.pdf")
        Catch ex As Exception

        End Try

    End Sub

#Region "Reportes"

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click


        Cursor = Cursors.WaitCursor
        tipoReporte = cmboxTipoReporte.SelectedIndex + 1
        TableroGeneral(tipoReporte)

        Cursor = Cursors.Default

    End Sub


    Private Sub diseñoGridResultado(ByVal spid As Integer)
        Dim objBu As New Negocios.TableroGeneralVentasBU
        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim listBandsTextos As New List(Of String)
        Dim listBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)

        Dim dtEncabezados As New DataTable

        dtEncabezados = objBu.tableroGeneralVentasObtenerEncabezadosTabla(spid)

        'dtEncabezados.Rows.Add("-", "TOTAL")


        bgvReporte.OptionsView.AllowCellMerge = True
        bgvReporte.OptionsView.ColumnAutoWidth = False
        bgvReporte.Columns.Clear()
        bgvReporte.Bands.Clear()

        For Each row As DataRow In dtEncabezados.Rows
            If listBandsTextos.Contains(row.Item("Mes").ToString()) = False Then
                listBandsTextos.Add(row.Item("Mes").ToString())

                band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                band.Caption = row.Item("Mes").ToString()
                listBands.Add(band)
            End If

            For Each gridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In listBands
                If gridBand.Caption = "" Then
                    If IsNothing(bgvReporte.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
                        bgvReporte.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
                        bgvReporte.Columns.ColumnByFieldName("#").OwnerBand = gridBand
                        AddHandler bgvReporte.CustomUnboundColumnData, AddressOf bgvReporte_CustomUnboundColumnData
                        bgvReporte.Columns.Item("#").VisibleIndex = 0
                    End If
                End If
                If row("Mes").ToString() = gridBand.Caption Then
                    bgvReporte.Columns.AddField(row.Item("SemanaDia").ToString().ToUpper)
                    bgvReporte.Columns.ColumnByFieldName(row.Item("SemanaDia").ToString().ToUpper).OwnerBand = gridBand
                    bgvReporte.Columns.ColumnByFieldName(row.Item("SemanaDia").ToString().ToUpper).Visible = True
                    If row.Item("SemanaDia").ToString().ToUpper <> "MARCA" And row.Item("SemanaDia").ToString().ToUpper <> "AGENTE" And row.Item("SemanaDia").ToString().ToUpper <> "CLIENTE" And row.Item("SemanaDia").ToString().ToUpper <> "RUTA" Then
                        bgvReporte.Columns.ColumnByFieldName(row.Item("SemanaDia").ToString().ToUpper).OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                    End If
                    If row.Item("SemanaDia").ToString().ToUpper <> "MARCA" And row.Item("SemanaDia").ToString().ToUpper <> "INDICADOR" And row.Item("SemanaDia").ToString().ToUpper <> "AGENTE" And row.Item("SemanaDia").ToString().ToUpper <> "CLIENTE" And row.Item("SemanaDia").ToString().ToUpper <> "RUTA" Then
                        bgvReporte.Columns.ColumnByFieldName(row.Item("SemanaDia").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                        bgvReporte.Columns.ColumnByFieldName(row.Item("SemanaDia").ToString().ToUpper).DisplayFormat.FormatString = "N0"
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
            If gridBand.Caption.ToUpper.Contains("TOTAL") Then
                gridBand.Caption = ""
            End If
            bgvReporte.Bands.Add(gridBand)
        Next
        For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In bgvReporte.Bands
            gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        bgvReporte.Bands(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        bgvReporte.ColumnPanelRowHeight = 40

        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvReporte.Columns
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
            If Col.FieldName = "RUTA" Then
                Col.Width = 120
            End If
        Next


    End Sub

    Private Sub bgvReporte_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = bgvReporte.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub bgvReporte_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles bgvReporte.CustomDrawCell

        Dim currentView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)

        If tipoReporte = 1 Or tipoReporte = 4 Or tipoReporte = 6 Then
            Try
                'Cursor = Cursors.WaitCursor
                If e.Column.FieldName <> "INDICADOR" And e.Column.FieldName <> "#" And e.Column.FieldName <> "AGENTE" And e.Column.FieldName <> "DESCRIPCIÓN" And e.Column.FieldName <> "CLASIFICACIÓN" And e.Column.FieldName <> "MARCA" Then
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
                If e.Column.FieldName.Contains("TOTAL") = True Then
                    If IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) = False Then
                        e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                    End If
                End If


                'Cursor = Cursors.Default
            Catch ex As Exception
                'Cursor = Cursors.Default
                show_message("Error", ex.Message.ToString())
            End Try
            'End If

        Else

            Try
                'Cursor = Cursors.WaitCursor
                If e.Column.FieldName.ToUpper <> "DESCRIPCIÓN" And e.Column.FieldName <> "#" And e.Column.FieldName.ToUpper <> "CLASIFICACIÓN" Then
                    If IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Or IsNothing(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                        If currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName).ToString.ToUpper <> "TOTAL" Then
                            currentView.SetRowCellValue(e.RowHandle, e.Column.FieldName, 0)
                            e.DisplayText = "0"
                        End If
                    End If
                    If e.Column.FieldName.Contains("%") Or e.Column.FieldName.ToUpper = "PROPORCIÓN" Then
                        If e.Column.FieldName.ToUpper <> "PROPORCIÓN" Then
                            e.Appearance.BackColor = ObtenerColorCelda(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                            e.Appearance.ForeColor = ObtenerColorLetra(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                            e.DisplayText = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.DisplayText.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
                        Else
                            e.DisplayText = (RTrim(LTrim(Replace(Replace(e.DisplayText.ToString, ",", ""), "%", ""))) / 100).ToString("p1")
                        End If
                    End If
                End If
                If tipoReporte = 2 Then
                    If currentView.GetRowCellValue(e.RowHandle, "Descripción").ToString.ToUpper = "TOTAL" Then
                        If e.Column.FieldName.Contains("%") = False Then
                            e.Appearance.BackColor = Color.FromArgb(217, 217, 217)
                        End If
                        e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                    End If
                ElseIf tipoReporte = 5 Then
                    If currentView.GetRowCellValue(e.RowHandle, "Marca").ToString.ToUpper = "TOTAL" Then
                        If e.Column.FieldName.Contains("%") = False Then
                            e.Appearance.BackColor = Color.FromArgb(217, 217, 217)
                        End If
                        e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                    End If
                Else
                    If currentView.GetRowCellValue(e.RowHandle, "Agente").ToString.ToUpper = "TOTAL" Then
                        If e.Column.FieldName.Contains("%") = False Then
                            e.Appearance.BackColor = Color.FromArgb(217, 217, 217)
                        End If
                        e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                    End If
                End If


                'Cursor = Cursors.Default
            Catch ex As Exception
                'Cursor = Cursors.Default
                show_message("Error", ex.Message.ToString())
            End Try
            'End If

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


#End Region


#Region "Tipos Reporte"

    Private Sub TableroGeneral(ByVal TipoReporte As Integer)
        Dim objBU As New Negocios.TableroGeneralVentasBU
        Dim dtResultadoReporte As New DataTable
        Dim spid As Integer = 0

        If obtenerFiltros() = False Then
            Return
        End If
        dtResultadoReporte = objBU.reportesTableroGeneral(filtro_FechaInicio, filtro_FechaFin, filtro_Agente, filtro_Marca, filtro_Cliente, TipoReporte)


        If dtResultadoReporte.Rows.Count > 0 Then

            'lblNumRegistros.Text = Integer.Parse(grvReportePedidos.RowCount.ToString()).ToString("n0")
            lblFechaUltimaActualización.Text = DateTime.Now.ToString()

            grdReporte.DataSource = Nothing

            If TipoReporte = 2 Or TipoReporte = 3 Or TipoReporte = 5 Then
                diseñoGridResultadoSinBand(dtResultadoReporte)
            Else
                spid = Integer.Parse(dtResultadoReporte.Rows(0).Item("spid").ToString())
                diseñoGridResultado(spid)
            End If

            'dtResultadoReporte.Rows(dtResultadoReporte.Rows.Count - 1).Item("TOTAL") = dtResultadoReporte.Rows(dtResultadoReporte.Rows.Count - 1).Item(dtResultadoReporte.Columns(dtResultadoReporte.Columns.Count - 2).ColumnName.ToString())

            grdReporte.DataSource = dtResultadoReporte

            btnArriba_Click(Nothing, Nothing)
        Else
            grdReporte.DataSource = Nothing
            bgvReporte.Bands.Clear()
            bgvReporte.Columns.Clear()
            show_message("Aviso", "No hay datos para mostrar.")
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

    Private Function ObtenerColorCeldaDouble(ByVal Valor As Double) As Color
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

    Private Function ObtenerColorLetraDouble(ByVal Valor As Double) As Color
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
        If bgvReporte.DataRowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty
            Dim nombreReporteParaExportacion As String = String.Empty
            Dim objBU As New Negocios.EstadisticoPedidosBU

            Try

                Select Case cmboxTipoReporte.SelectedIndex + 1
                    Case 1
                        nombreReporte = "\IndicadorVentas_"
                        nombreReporteParaExportacion = "TABLERO GENERAL DE VENTAS (INDICADOR DE VENTAS)"
                    Case 2
                        nombreReporte = "\VentasClasificacionCliente_"
                        nombreReporteParaExportacion = "TABLERO GENERAL DE VENTAS (RESUMEN DE VENTAS POR CLASIFICACIÓN DE CLIENTE)"
                    Case 3
                        nombreReporte = "\VentasAgenteAparador_"
                        nombreReporteParaExportacion = "TABLERO GENERAL DE VENTAS (RESUMEN DE VENTAS POR AGENTE-APARADOR)"
                    Case 4
                        nombreReporte = "\IndicadorMarca_"
                        nombreReporteParaExportacion = "TABLERO GENERAL DE VENTAS (INDICADOR POR MARCA)"
                    Case 5
                        nombreReporte = "\ResumenMarca_"
                        nombreReporteParaExportacion = "TABLERO GENERAL DE VENTAS (RESUMEN POR MARCA)"
                    Case 6
                        nombreReporte = "\IndicadorAgenteMarca_"
                        nombreReporteParaExportacion = "TABLERO GENERAL DE VENTAS (INDICADOR AGENTE-MARCA)"

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
                            bgvReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell


                            grdReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)

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

        If tipoReporte = 1 Or tipoReporte = 4 Or tipoReporte = 6 Then
            Try
                If e.ColumnFieldName <> "MARCA" And e.ColumnFieldName <> "INDICADOR" And e.ColumnFieldName <> "#" And e.ColumnFieldName <> "AGENTE" And e.ColumnFieldName <> "CLIENTE" And e.ColumnFieldName <> "RUTA" Then
                    If IsDBNull(bgvReporte.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) Or IsNothing(bgvReporte.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) Then
                        If e.RowHandle > 0 Then
                            bgvReporte.SetRowCellValue(e.RowHandle, e.ColumnFieldName, 0)
                            e.Value = 0
                        End If
                    End If
                    If bgvReporte.GetRowCellValue(e.RowHandle, "INDICADOR").ToString().Contains("%") Then
                        e.Formatting.BackColor = ObtenerColorCelda(bgvReporte.GetRowCellValue(e.RowHandle, e.ColumnFieldName))
                        e.Formatting.Font.Color = ObtenerColorLetra(bgvReporte.GetRowCellValue(e.RowHandle, e.ColumnFieldName))
                        e.Value = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.Value.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
                    End If
                End If
                If e.ColumnFieldName.Contains("TOTAL") = True Then
                    If IsDBNull(bgvReporte.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) = False Then
                        e.Formatting.Font.Bold = True
                    End If
                End If

            Catch ex As Exception
                show_message("Error", ex.Message.ToString())
            End Try

        Else
            Try
                If e.ColumnFieldName.ToUpper <> "DESCRIPCIÓN" And e.ColumnFieldName <> "#" And e.ColumnFieldName.ToUpper <> "CLASIFICACIÓN" Then
                    If IsDBNull(bgvReporte.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) Or IsNothing(bgvReporte.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) Then
                        If e.RowHandle > 0 Then
                            If bgvReporte.GetRowCellValue(e.RowHandle, e.ColumnFieldName).ToString.ToUpper <> "TOTAL" Then
                                bgvReporte.SetRowCellValue(e.RowHandle, e.ColumnFieldName, 0)
                                e.Value = 0
                            End If
                        End If
                    End If
                    If e.ColumnFieldName.Contains("%") Or e.ColumnFieldName.ToUpper = "PROPORCIÓN" Then
                        If e.Value.ToString.ToUpper <> "PROPORCIÓN" And e.Value.ToString.Contains("%") = False Then
                            If e.ColumnFieldName.ToUpper <> "PROPORCIÓN" Then
                                e.Formatting.BackColor = ObtenerColorCelda(bgvReporte.GetRowCellValue(e.RowHandle, e.ColumnFieldName))
                                e.Formatting.Font.Color = ObtenerColorLetra(bgvReporte.GetRowCellValue(e.RowHandle, e.ColumnFieldName))
                                e.Value = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.Value.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
                            Else
                                e.Value = (RTrim(LTrim(Replace(Replace(e.Value.ToString, ",", ""), "%", ""))) / 100).ToString("p1")
                            End If
                        End If
                    End If
                End If

                If tipoReporte = 2 Then
                    If bgvReporte.GetRowCellValue(e.RowHandle, "Descripción").ToString.ToUpper = "TOTAL" Then
                        If e.ColumnFieldName.Contains("%") = False Then
                            e.Formatting.BackColor = Color.FromArgb(217, 217, 217)
                        End If
                        e.Formatting.Font.Bold = True
                    End If
                ElseIf tipoReporte = 5 Then
                    If bgvReporte.GetRowCellValue(e.RowHandle, "Marca").ToString.ToUpper = "TOTAL" Then
                        If e.ColumnFieldName.Contains("%") = False Then
                            e.Formatting.BackColor = Color.FromArgb(217, 217, 217)
                        End If
                        e.Formatting.Font.Bold = True
                    End If
                Else
                    If bgvReporte.GetRowCellValue(e.RowHandle, "Agente").ToString.ToUpper = "TOTAL" Then
                        If e.ColumnFieldName.Contains("%") = False Then
                            e.Formatting.BackColor = Color.FromArgb(217, 217, 217)
                        End If
                        e.Formatting.Font.Bold = True
                    End If
                End If

            Catch ex As Exception
                show_message("Error", ex.Message.ToString())
            End Try

        End If

        e.Handled = True
    End Sub

#End Region

End Class