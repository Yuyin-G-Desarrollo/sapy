Imports Ventas.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ReportegENPedidosForm

    Dim listEncabezados As List(Of String)
    Dim perfilUsuario As Integer = 0
    Dim listInicial As New List(Of String)

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 233
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Cursor = Cursors.WaitCursor
        Dim objBU As New ReportePedidosFacturacionBU
        Dim dtTablaResultado As New DataTable()
        Dim objMensajeInfo As New Tools.AvisoForm
        lblFechaUltimaActualización.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()
        listEncabezados = New List(Of String)

        Dim FechaInicioProgramacion As String = String.Empty
        Dim FechaFinProgramacion As String = String.Empty
        Dim Agrupamiento As Integer = 0
        Dim lAgentes As String = String.Empty
        Dim lMarcas As String = String.Empty
        Dim lSemanas As String = String.Empty
        Dim ConDetalle As Integer = 0
        Dim cedisUsuario As Integer = 0
        Dim lClientes As String = String.Empty

        FechaInicioProgramacion = dtpFechaEntregaDel.Value.ToShortDateString()
        FechaFinProgramacion = dtpFechaEntregaAl.Value.ToShortDateString()
        Agrupamiento = If(rdbAgrupamiento1.Checked, 1, (If(rdbAgrupamiento2.Checked, 2, (If(rdbAgrupamiento3.Checked, 3, (If(rdbAgrupamiento4.Checked, 4, 0)))))))

        For Each row As UltraGridRow In grdAgentes.Rows
            If row.Index = 0 Then
                lAgentes += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lAgentes += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next
        For Each row As UltraGridRow In grdMarcas.Rows
            If row.Index = 0 Then
                lMarcas += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lMarcas += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next
        For Each row As UltraGridRow In grdSemanas.Rows
            If row.Index = 0 Then
                lSemanas += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lSemanas += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        For Each row As UltraGridRow In grdClientes.Rows
            If row.Index = 0 Then
                lClientes += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lClientes += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        ConDetalle = If(chkSemanaFacturacion.Checked, 1, 0)
        cedisUsuario = cmbCEDIS.SelectedValue

        grdReportePedidos.DataSource = Nothing
        'dtTablaResultado.Columns("Cancelado").DataType = System.Type.GetType("System.Int32")
        'dtTablaResultado.Columns("ParesFacturados").DataType = System.Type.GetType("System.Int32")
        'dtTablaResultado.Columns("CantidadPartida").DataType = System.Type.GetType("System.Int32")
        dtTablaResultado = objBU.consultaReportePedidos(FechaInicioProgramacion, FechaFinProgramacion, lAgentes, lMarcas, lSemanas, lClientes, Agrupamiento, ConDetalle, cedisUsuario)

        If dtTablaResultado.Rows.Count = 0 Then
            objMensajeInfo.mensaje = "No hay datos para mostrar"
            objMensajeInfo.ShowDialog()
        Else
            grdReportePedidos.DataSource = dtTablaResultado
            For Each col As DataColumn In dtTablaResultado.Columns
                listEncabezados.Add(col.ColumnName)
            Next
            diseñoGridReporte(grdReportePedidos)
        End If
        lblNumRegistros.Text = grdReportePedidos.Rows.Count().ToString("##,##0")
        Cursor = Cursors.Default
    End Sub

    Private Sub btnVerSemanas_Click(sender As Object, e As EventArgs) Handles btnVerSemanas.Click
        Dim objBU As New Negocios.ReportePedidosFacturacionBU
        Dim FechaInicioProgramacion As String = String.Empty
        Dim FechaFinProgramacion As String = String.Empty
        Dim Agrupamiento As Integer = 0
        Dim lAgentes As String = String.Empty
        Dim lMarcas As String = String.Empty

        FechaInicioProgramacion = dtpFechaEntregaDel.Value.ToShortDateString()
        FechaFinProgramacion = dtpFechaEntregaAl.Value.ToShortDateString()
        Agrupamiento = If(rdbAgrupamiento1.Checked, 1, (If(rdbAgrupamiento2.Checked, 2, (If(rdbAgrupamiento3.Checked, 3, (If(rdbAgrupamiento4.Checked, 4, 0)))))))

        For Each row As UltraGridRow In grdAgentes.Rows
            If row.Index = 0 Then
                lAgentes += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lAgentes += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next
        For Each row As UltraGridRow In grdMarcas.Rows
            If row.Index = 0 Then
                lMarcas += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lMarcas += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next
        grdSemanas.DataSource = objBU.consultaSemanasPedidos(FechaInicioProgramacion, FechaFinProgramacion, lAgentes, lMarcas, Agrupamiento)
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 18

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

    Private Sub grdAgentes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdAgentes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdSemanas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdSemanas.InitializeLayout
        grid_diseño(grdSemanas)
        grdSemanas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Semanas"
    End Sub

    Private Sub grdSemanas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdSemanas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdMarcas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdMarcas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdMarcas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMarcas.InitializeLayout
        grid_diseño(grdMarcas)
        grdMarcas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Marcas"
    End Sub

    Private Sub grdClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        grid_diseño(grdClientes)
        grdClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Clientes"
    End Sub

    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btnTienda.Click

        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 19

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

    Private Sub diseñoGridReporte(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Bands(0).Columns("Agente").Header.Caption = "Agente"
        grid.DisplayLayout.Bands(0).Columns("Agente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Cliente").Header.Caption = "Cliente"
        grid.DisplayLayout.Bands(0).Columns("Cliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Marca").Header.Caption = "Marca"
        grid.DisplayLayout.Bands(0).Columns("Marca").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Coleccion").Header.Caption = "Colección"
        grid.DisplayLayout.Bands(0).Columns("Coleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        If listEncabezados.Contains("FamiliaProyeccion") Then
            grid.DisplayLayout.Bands(0).Columns("FamiliaProyeccion").Header.Caption = "Familia"
            grid.DisplayLayout.Bands(0).Columns("FamiliaProyeccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        End If
        If listEncabezados.Contains("IdModelo") Then
            grid.DisplayLayout.Bands(0).Columns("IdModelo").Header.Caption = "Modelo"
            grid.DisplayLayout.Bands(0).Columns("IdModelo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        End If
        If listEncabezados.Contains("IdPedido") Then
            grid.DisplayLayout.Bands(0).Columns("IdPedido").Header.Caption = "Pedido"
            grid.DisplayLayout.Bands(0).Columns("IdPedido").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        End If
        If listEncabezados.Contains("idPartida") Then
            grid.DisplayLayout.Bands(0).Columns("idPartida").Header.Caption = "Partida"
            grid.DisplayLayout.Bands(0).Columns("idPartida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        End If
        grid.DisplayLayout.Bands(0).Columns("Fprog").Header.Caption = "Fprog"
        grid.DisplayLayout.Bands(0).Columns("Fprog").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("SemanaProg").Header.Caption = "Semana Prog"
        grid.DisplayLayout.Bands(0).Columns("SemanaProg").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("ParesFacturados").Header.Caption = "Pares Facturados"
        grid.DisplayLayout.Bands(0).Columns("ParesFacturados").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("ParesFacturados").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("ParesFacturados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("FechaEnvioFac").Header.Caption = "Fecha Envio Fac."
        grid.DisplayLayout.Bands(0).Columns("FechaEnvioFac").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("SemanaEnvioFac").Header.Caption = "Semana Envio Fac."
        grid.DisplayLayout.Bands(0).Columns("SemanaEnvioFac").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("CantidadPartida").Header.Caption = "Cantidad Partida"
        grid.DisplayLayout.Bands(0).Columns("CantidadPartida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("CantidadPartida").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("CantidadPartida").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Cancelado").Header.Caption = "Cancelado"
        grid.DisplayLayout.Bands(0).Columns("Cancelado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Cancelado").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Cancelado").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("PorFacturar").Header.Caption = "Por Facturar"
        grid.DisplayLayout.Bands(0).Columns("PorFacturar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("PorFacturar").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("PorFacturar").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("SCancelado").Header.Caption = "SCancelado"
        grid.DisplayLayout.Bands(0).Columns("SCancelado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grid.DisplayLayout.GroupByBox.Hidden = False
        grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"

        Dim summary1, summary2, summary3, summary4 As SummarySettings
        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Facturados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("ParesFacturados"))
        summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Partidas", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("CantidadPartida"))
        summary3 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Cancelado", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Cancelado"))
        summary4 = grid.DisplayLayout.Bands(0).Summaries.Add("Total PorFacturar", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("PorFacturar"))
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right
        summary2.DisplayFormat = "{0:#,##0}"
        summary2.Appearance.TextHAlign = HAlign.Right
        summary3.DisplayFormat = "{0:#,##0}"
        summary3.Appearance.TextHAlign = HAlign.Right
        summary4.DisplayFormat = "{0:#,##0}"
        summary4.Appearance.TextHAlign = HAlign.Right

        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            col.CharacterCasing = CharacterCasing.Upper
            col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            If Not col.Hidden Then
                width += col.Width
            End If
            If IsNumeric(col.Header.Caption) Then
                grid.DisplayLayout.Bands(0).Columns(col.Header.Caption).Format = "n0"
                grid.DisplayLayout.Bands(0).Columns(col.Header.Caption).CellAppearance.TextHAlign = HAlign.Right
            End If
        Next

        For Each renglon As UltraGridRow In grid.Rows
            If IsDBNull(renglon.Cells("ParesFacturados").Value) Then
                renglon.Cells("ParesFacturados").Value = 0
            End If
            If renglon.Cells("SCancelado").Value.ToString() <> "Cancelado" Then
                renglon.Cells("PorFacturar").Value = renglon.Cells("CantidadPartida").Value - renglon.Cells("ParesFacturados").Value - renglon.Cells("Cancelado").Value
            Else
                renglon.Cells("PorFacturar").Value = 0
            End If

            If renglon.Cells("PorFacturar").Value < 0 Then
                renglon.Cells("PorFacturar").Value = 0
            End If
        Next

        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If
    End Sub

    Private Sub ReportePedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaEntregaDel.Value = DateTime.Now
        dtpFechaEntregaAl.Value = DateTime.Now
        Me.Top = 0
        Me.Left = 0

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_CONSVTAS_REPORTEGENERALPEDIDOS_ANT", "REP_FAMILIA_GRUPO") Then
            pnlReporteFamiliaGrupo.Visible = True
        End If

        Me.WindowState = FormWindowState.Maximized
        ObtenerCEDISUsuario()

        Dim dtResultadoPerfil As New DataTable
        Dim objBU As New Negocios.ReportePedidosFacturacionBU
        dtResultadoPerfil = objBU.reportePedidosFacturacionObtenerPerfilUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If dtResultadoPerfil.Rows.Count > 0 Then
            perfilUsuario = dtResultadoPerfil.Rows(0).Item("IdPerfil")
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnExportarExcelApartados_Click(sender As Object, e As EventArgs) Handles btnExportarExcelApartados.Click
        Cursor = Cursors.WaitCursor
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New AdvertenciaForm
        grid = grdReportePedidos
        If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 Then

            nombreDocumento = "\ReporteVentas"


            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog

                If ret = Windows.Forms.DialogResult.OK Then

                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                    gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                    Dim mensajeExito As New ExitoForm
                    Cursor = Cursors.Default
                    mensajeExito.mensaje = "Los datos se exportaron correctamente"
                    mensajeExito.ShowDialog()

                End If
                .Dispose()
            End With
        Else
            Cursor = Cursors.Default
            advertencia.mensaje = "No hay datos para exportar "
            advertencia.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub dtpFechaEntregaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaEntregaDel.ValueChanged
        dtpFechaEntregaAl.MinDate = dtpFechaEntregaDel.Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim ventana As New ProspectaForm()
        ventana.Show()
        Me.Hide()
    End Sub

    Private Sub btnPedidosFamGpo_Click(sender As Object, e As EventArgs) Handles btnPedidosFamGpo.Click
        Dim form As New PedidosConfirmadosFamiliaGrupoForm
        form.MdiParent = Me.MdiParent
        form.Show()
    End Sub

    Private Sub ObtenerCEDISUsuario()
        cmbCEDIS = Utilerias.ComboObtenerCEDISUsuario(cmbCEDIS)
    End Sub

    Private Sub btnClinetes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
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

    Private Sub btnLimpiarClientes_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdClientes.DataSource = listInicial
    End Sub

End Class