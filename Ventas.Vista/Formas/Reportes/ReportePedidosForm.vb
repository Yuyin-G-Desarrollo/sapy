Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Ventas.Negocios
Imports Tools
Imports System.IO
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports DevExpress.Export
Imports Infragistics.Documents.Excel

Public Class ReportePedidosForm

    Dim listEncabezados As List(Of String)
    Dim listInicial As New List(Of String)
    Private SELECCION_CLIENTES_TALLAS As Integer = -1

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 206
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAgente_Click(sender As Object, e As EventArgs) Handles btnAgente.Click
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

    Private Sub btnMarcas_Click(sender As Object, e As EventArgs) Handles btnMarcas.Click

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

    Private Sub grdMarcas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdMarcas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdMarcas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMarcas.InitializeLayout
        grid_diseño(grdMarcas)
        grdMarcas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Marca"
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
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
        Dim lClientes As String = String.Empty
        Dim lFamilias As String = String.Empty
        Dim lColecciones As String = String.Empty
        Dim ConDetalle As Integer = 0

        FechaInicioProgramacion = dtpFechaEntregaDel.Value.ToShortDateString()
        FechaFinProgramacion = dtpFechaEntregaAl.Value.ToShortDateString()
        Agrupamiento = cmboxAgrupamiento.SelectedIndex + 1

        For Each row As UltraGridRow In grdAgentes.Rows
            If row.Index = 0 Then
                lAgentes += "" + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                lAgentes += "," + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next
        For Each row As UltraGridRow In grdMarcas.Rows
            If row.Index = 0 Then
                lMarcas += "" + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                lMarcas += "," + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next

        For Each row As UltraGridRow In grdClientes.Rows
            If row.Index = 0 Then
                lClientes += "" + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                lClientes += "," + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next
        For Each row As UltraGridRow In grdFamilias.Rows
            If row.Index = 0 Then
                lFamilias += "" + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                lFamilias += "," + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next

        For Each Row As UltraGridRow In grdColecciones.Rows
            If Row.Index = 0 Then
                lColecciones += "" + Replace(Row.Cells(0).Text, ",", "") + ""
            Else
                lColecciones += "," + Replace(Row.Cells(0).Text, ",", "") + ""
            End If
        Next

        grdReportePedidos.DataSource = Nothing
        'dtTablaResultado.Columns("Cancelado").DataType = System.Type.GetType("System.Int32")
        'dtTablaResultado.Columns("ParesFacturados").DataType = System.Type.GetType("System.Int32")
        'dtTablaResultado.Columns("CantidadPartida").DataType = System.Type.GetType("System.Int32")
        dtTablaResultado = objBU.consultaReportePedidosV2(FechaInicioProgramacion, FechaFinProgramacion, lAgentes, lMarcas, lClientes, lFamilias, Agrupamiento, lColecciones)

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
        btnArriba_Click(sender, e)
        Cursor = Cursors.Default
    End Sub

    Private Sub diseñoGridReporte(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        Dim listTotales As New List(Of SummarySettings)

        grid.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True

        grid.DisplayLayout.Bands(0).Columns("Agente").Header.Caption = "Agente"
        grid.DisplayLayout.Bands(0).Columns("Agente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Cliente").Header.Caption = "Cliente"
        grid.DisplayLayout.Bands(0).Columns("Cliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Marca").Header.Caption = "Marca"
        grid.DisplayLayout.Bands(0).Columns("Marca").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        If listEncabezados.Contains("Coleccion") Then
            grid.DisplayLayout.Bands(0).Columns("Coleccion").Header.Caption = "Colección"
            grid.DisplayLayout.Bands(0).Columns("Coleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        End If
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

        If listEncabezados.Contains("SemanaProgramacion") Then
            grid.DisplayLayout.Bands(0).Columns("SemanaProgramacion").Header.Caption = "Semana" & vbCrLf & "Programación"
            grid.DisplayLayout.Bands(0).Columns("SemanaProgramacion").PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        End If
        'grid.DisplayLayout.Bands(0).Columns("Fprog").Header.Caption = "Fprog"
        'grid.DisplayLayout.Bands(0).Columns("Fprog").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("SemanaEntrega").Header.Caption = "Semana Solicita"
        grid.DisplayLayout.Bands(0).Columns("SemanaEntrega").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("TotalFacturados").Header.Caption = "Total Pares facturados"
        grid.DisplayLayout.Bands(0).Columns("TotalFacturados").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("TotalFacturados").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("TotalFacturados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("ParesFacturados").Header.Caption = "Pares facturados"
        grid.DisplayLayout.Bands(0).Columns("ParesFacturados").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("ParesFacturados").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("ParesFacturados").CellAppearance.TextHAlign = HAlign.Right
        'grid.DisplayLayout.Bands(0).Columns("FechaEnvioFac").Header.Caption = "Fecha Envio Fac."
        'grid.DisplayLayout.Bands(0).Columns("FechaEnvioFac").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        'grid.DisplayLayout.Bands(0).Columns("SemanaEnvioFac").Header.Caption = "Semana Envio Fac."
        'grid.DisplayLayout.Bands(0).Columns("SemanaEnvioFac").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("ParesPedidos").Header.Caption = "Pares pedidos"
        grid.DisplayLayout.Bands(0).Columns("ParesPedidos").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("ParesPedidos").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("ParesPedidos").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Cancelados").Header.Caption = "Cancelado"
        grid.DisplayLayout.Bands(0).Columns("Cancelados").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Cancelados").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Cancelados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("PFactAt").Header.Caption = "Por Facturar Atrasado"
        grid.DisplayLayout.Bands(0).Columns("PFactAt").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("PFactAt").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("PFactAt").CellAppearance.TextHAlign = HAlign.Right
        If listEncabezados.Contains("PFacturar") Then
            grid.DisplayLayout.Bands(0).Columns("PFacturar").Header.Caption = "Por Facturar"
            grid.DisplayLayout.Bands(0).Columns("PFacturar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("PFacturar").Format = "n0"
            grid.DisplayLayout.Bands(0).Columns("PFacturar").CellAppearance.TextHAlign = HAlign.Right
        End If
        'grid.DisplayLayout.Bands(0).Columns("SCancelado").Header.Caption = "SCancelado"
        'grid.DisplayLayout.Bands(0).Columns("SCancelado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        'grid.DisplayLayout.Bands(0).Columns("SCancelado").Hidden = True
        'grid.DisplayLayout.Bands(0).Columns("FechaEnvioFac").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("FechaEntrega").Hidden = True

        'grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grid.DisplayLayout.GroupByBox.Hidden = False
        grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"

        grid.DisplayLayout.Bands(0).Columns("Agente").Width = 40
        If listEncabezados.Contains("idPartida") Then
            grid.DisplayLayout.Bands(0).Columns("idPartida").Width = 45
        End If
        grid.DisplayLayout.Bands(0).Columns("SemanaEntrega").Width = 60
        grid.DisplayLayout.Bands(0).Columns("ParesPedidos").Width = 60
        grid.DisplayLayout.Bands(0).Columns("TotalFacturados").Width = 70
        grid.DisplayLayout.Bands(0).Columns("PFactAt").Width = 60
        If grid.DisplayLayout.Bands(0).Columns.Contains("PFacturar") Then
            grid.DisplayLayout.Bands(0).Columns("PFacturar").Width = 60
        End If
        grid.DisplayLayout.Bands(0).Columns("Cancelados").Width = 70
        If listEncabezados.Contains("Despues") Then
            grid.DisplayLayout.Bands(0).Columns("Despues").Width = 65
        End If
        If listEncabezados.Contains("Cliente") Then
            grid.DisplayLayout.Bands(0).Columns("Cliente").Width = 200
        End If
        If listEncabezados.Contains("Coleccion") Then
            grid.DisplayLayout.Bands(0).Columns("Coleccion").Width = 155
        End If
        If listEncabezados.Contains("Familia") Then
            grid.DisplayLayout.Bands(0).Columns("Familia").Width = 155
        End If
        If listEncabezados.Contains("Modelo") Then
            grid.DisplayLayout.Bands(0).Columns("Modelo").Width = 80
        End If
        If listEncabezados.Contains("Piel") Then
            grid.DisplayLayout.Bands(0).Columns("Piel").Width = 130
        End If
        If listEncabezados.Contains("Color") Then
            grid.DisplayLayout.Bands(0).Columns("Color").Width = 130
        End If
        If listEncabezados.Contains("Corrida") Then
            grid.DisplayLayout.Bands(0).Columns("Corrida").Width = 80
        End If

        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            col.CharacterCasing = CharacterCasing.Upper
            col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            If Not col.Hidden Then
                width += col.Width
            End If
            If col.Header.Caption <> "Agente" And col.Header.Caption <> "Cliente" And col.Header.Caption <> "Marca" And col.Header.Caption <> "Colección" And col.Header.Caption <> "Familia" And col.Header.Caption <> "Modelo" And col.Header.Caption <> "Pedido" And col.Header.Caption <> "Partida" And col.Header.Caption <> "Semana Entrega" And col.Header.Caption <> "Pares pedidos" And col.Header.Caption <> "Pares facturados" And col.Header.Caption <> "Total Pares facturados" And col.Header.Caption <> "Cancelado" And col.Header.Caption <> "Cancelado" And col.Header.Caption <> "Por Facturar" And col.Header.Caption <> "SCancelado" And col.Header.Caption <> "Piel" And col.Header.Caption <> "Color" And col.Header.Caption <> "Corrida" And col.Header.Caption <> "FechaEnvioFac" And col.Header.Caption <> "Fprog" And col.Header.Caption <> "FechaEntrega" Then
                For Each row As UltraGridRow In grdReportePedidos.Rows
                    If IsDBNull(row.Cells(col).Value) Then
                        row.Cells(col).Value = 0
                    End If
                Next
                grid.DisplayLayout.Bands(0).Columns(col.Key).Format = "n0"
                grid.DisplayLayout.Bands(0).Columns(col.Key).CellAppearance.TextHAlign = HAlign.Right
                listTotales.Add(grid.DisplayLayout.Bands(0).Summaries.Add("Total" + col.Header.Caption, SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns(col.Key)))

            End If
        Next

        Dim summary1, summary2, summary3, summary4, summary5, summary6 As New SummarySettings
        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares facturados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("TotalFacturados"))
        summary6 = grid.DisplayLayout.Bands(0).Summaries.Add("Pares facturados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("ParesFacturados"))
        summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Partidas", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("ParesPedidos"))
        summary3 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Cancelado", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Cancelados"))
        'summary4 = grid.DisplayLayout.Bands(0).Summaries.Add("Total PorFacturarAtrasado", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("PFactAt"))
        If listEncabezados.Contains("PFacturar") Then
            summary5 = grid.DisplayLayout.Bands(0).Summaries.Add("Total PorFacturar", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("PFacturar"))
        End If
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right
        summary2.DisplayFormat = "{0:#,##0}"
        summary2.Appearance.TextHAlign = HAlign.Right
        summary3.DisplayFormat = "{0:#,##0}"
        summary3.Appearance.TextHAlign = HAlign.Right
        summary6.DisplayFormat = "{0:#,##0}"
        summary6.Appearance.TextHAlign = HAlign.Right

        ' summary4.DisplayFormat = "{0:#,##0}"
        'summary4.Appearance.TextHAlign = HAlign.Right
        If listEncabezados.Contains("PFacturar") Then
            summary5.DisplayFormat = "{0:#,##0}"
            summary5.Appearance.TextHAlign = HAlign.Right
        End If

        For Each tot As SummarySettings In listTotales
            tot.DisplayFormat = "{0:#,##0}"
            tot.Appearance.TextHAlign = HAlign.Right
        Next

        For Each renglon As UltraGridRow In grid.Rows
            If IsDBNull(renglon.Cells("TotalFacturados").Value) Then
                renglon.Cells("TotalFacturados").Value = 0
            End If
            If listEncabezados.Contains("PFactAt") Then
                If IsDBNull(renglon.Cells("PFactAt").Value) Then
                    renglon.Cells("PFactAt").Value = 0
                End If
            End If
            If listEncabezados.Contains("PFacturar") Then
                If IsDBNull(renglon.Cells("PFacturar").Value) Then
                    renglon.Cells("PFacturar").Value = 0
                End If
            End If
            If listEncabezados.Contains("Cancelados") Then
                If IsDBNull(renglon.Cells("Cancelados").Value) Then
                    renglon.Cells("Cancelados").Value = 0
                End If
            End If
            'If renglon.Cells("SCancelado").Value.ToString() <> "Cancelado" Then
            '    renglon.Cells("PorFacturar").Value = renglon.Cells("CantidadPartida").Value - renglon.Cells("ParesFacturados").Value - renglon.Cells("Cancelado").Value
            'Else
            '    renglon.Cells("PorFacturar").Value = 0
            'End If

            'If renglon.Cells("PorFacturar").Value < 0 Then
            '    renglon.Cells("PorFacturar").Value = 0
            'End If


            If listEncabezados.Contains("PFacturar") Then
                If listEncabezados.Contains("PFactAt") Then
                    renglon.Cells("Total").Value = renglon.Cells("TotalFacturados").Value + renglon.Cells("PFactAt").Value + renglon.Cells("PFacturar").Value
                Else
                    renglon.Cells("Total").Value = renglon.Cells("TotalFacturados").Value + renglon.Cells("PFacturar").Value
                End If
            Else
                If listEncabezados.Contains("PFactAt") Then
                    renglon.Cells("Total").Value = renglon.Cells("TotalFacturados").Value + renglon.Cells("PFactAt").Value
                Else
                    renglon.Cells("Total").Value = renglon.Cells("TotalFacturados").Value
                End If

            End If
        Next


        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If

        grid.DisplayLayout.Bands(0).Columns("Total").Header.VisiblePosition = grid.DisplayLayout.Bands(0).Columns().Count + 1

        'If listEncabezados.Contains("PFacturar") Then
        '    grid.DisplayLayout.Bands(0).Columns("PFacturar").Header.VisiblePosition = grid.DisplayLayout.Bands(0).Columns("Total").Index - 1
        'End If

        'If listEncabezados.Contains("PFactAt") Then
        '    If listEncabezados.Contains("PFacturar") Then
        '        grid.DisplayLayout.Bands(0).Columns("PFactAt").Header.VisiblePosition = grid.DisplayLayout.Bands(0).Columns("PFacturar").Index - 1
        '    Else
        '        grid.DisplayLayout.Bands(0).Columns("PFactAt").Header.VisiblePosition = grid.DisplayLayout.Bands(0).Columns("Total").Index - 1
        '    End If
        'End If

        'If listEncabezados.Contains("Cancelados") Then
        '    If listEncabezados.Contains("PFactAt") Then
        '        grid.DisplayLayout.Bands(0).Columns("Cancelados").Header.VisiblePosition = grid.DisplayLayout.Bands(0).Columns("PFactAt").Index - 1
        '    Else
        '        If listEncabezados.Contains("PFacturar") Then
        '            grid.DisplayLayout.Bands(0).Columns("Cancelados").Header.VisiblePosition = grid.DisplayLayout.Bands(0).Columns("PFacturar").Index - 1
        '        Else
        '            grid.DisplayLayout.Bands(0).Columns("Cancelados").Header.VisiblePosition = grid.DisplayLayout.Bands(0).Columns("Total").Index - 1
        '        End If
        '    End If
        'End If

        'If listEncabezados.Contains("TotalFacturados") Then
        '    If listEncabezados.Contains("Cancelados") Then
        '        grid.DisplayLayout.Bands(0).Columns("TotalFacturados").Header.VisiblePosition = grid.DisplayLayout.Bands(0).Columns("Cancelados").Index - 1
        '    Else
        '        If listEncabezados.Contains("PFactAt") Then
        '            grid.DisplayLayout.Bands(0).Columns("TotalFacturados").Header.VisiblePosition = grid.DisplayLayout.Bands(0).Columns("PFactAt").Index - 1
        '        Else
        '            If listEncabezados.Contains("PFacturar") Then
        '                grid.DisplayLayout.Bands(0).Columns("TotalFacturados").Header.VisiblePosition = grid.DisplayLayout.Bands(0).Columns("PFacturar").Index - 1
        '            Else
        '                grid.DisplayLayout.Bands(0).Columns("TotalFacturados").Header.VisiblePosition = grid.DisplayLayout.Bands(0).Columns("Total").Index - 1
        '            End If
        '        End If
        '    End If
        'End If

        'If listEncabezados.Contains("Anterior") Then
        '    grid.DisplayLayout.Bands(0).Columns("Anterior").Header.VisiblePosition = grid.DisplayLayout.Bands(0).Columns("ParesPedidos").Index + 1
        'End If
        'If listEncabezados.Contains("Despues") Then
        '    grid.DisplayLayout.Bands(0).Columns("Despues").Header.VisiblePosition = grid.DisplayLayout.Bands(0).Columns("TotalFacturados").Index - 1
        'End If
    End Sub


    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 24
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

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
        End With
    End Sub

    Private Sub btnFamilia_Click(sender As Object, e As EventArgs) Handles btnFamilia.Click
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

    Private Sub grdClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        grid_diseño(grdClientes)
        grdClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub grdFamilias_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFamilias.InitializeLayout
        grid_diseño(grdFamilias)
        grdFamilias.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Familia"
    End Sub

    Private Sub grdClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdClientes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdFamilias_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFamilias.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub ReportePedidosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objResumenVentasBU As New Negocios.ResumenVentasSemanalBU
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_CONSVTAS_REPORTEGENERALPEDIDOS", "VENT_ADMIN_TI_FPROG") Then
            btnMostrar.Visible = True
            lblAceptar.Visible = True
            lblAcept.Visible = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_CONSVTAS_REPORTEGENERALPEDIDOS", "VENT_REPORT_IC") Then
            btnexportarINT.Visible = True
            lblreporteic.Visible = True
        End If

        'dtpFechaEntregaDel.Value = Date.Parse("02/01/" + Date.Now.Year.ToString())
        dtpFechaEntregaDel.Value = objResumenVentasBU.ConsultarFechaInicioEstadVentas_Semanal()
        dtpFechaEntregaAl.Value = DateTime.Now
        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized
        cmboxAgrupamiento.SelectedIndex = 0
        grdAgentes.DataSource = If(seleccionarAgenteVentas().Rows.Count = 0, listInicial, seleccionarAgenteVentas())
        grdMarcas.DataSource = listInicial
        grdClientes.DataSource = listInicial
        grdFamilias.DataSource = listInicial
        grdColecciones.DataSource = listInicial
        If grdAgentes.Rows.Count > 0 Then
            grdAgentes.Enabled = False
            btnAgente.Enabled = False
            With grdAgentes
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Agente de Ventas"
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
            End With
        End If
        lblNotas.Text = "Facturados: Rango de fechas" & vbCrLf & "de facturación" & vbCrLf & "Por Facturar: Rango de fechas" & vbCrLf & "de Entrega de pedidos"

        SELECCION_CLIENTES_TALLAS = cmboxAgrupamiento.Items.Count - 1
    End Sub

    Private Sub dtpFechaEntregaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaEntregaDel.ValueChanged
        dtpFechaEntregaAl.MinDate = dtpFechaEntregaDel.Value
    End Sub

    Private Sub grdReportePedidos_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles grdReportePedidos.AfterRowFilterChanged
        lblNumRegistros.Text = grdReportePedidos.Rows.GetFilteredInNonGroupByRows.Count().ToString("##,##0")
    End Sub

    Private Sub btnExportarExcelApartados_Click(sender As Object, e As EventArgs) Handles btnExportarExcelApartados.Click
        Dim filename As String
        Try
            Dim grid As New UltraGrid
            Dim Agrupamiento As Integer = 0
            grid = grdReportePedidos
            Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter

            Agrupamiento = cmboxAgrupamiento.SelectedIndex + 1


            If Agrupamiento = 4 Then
                If GridView1.DataRowCount > 0 Then

                    Dim SaveFileDialog As New SaveFileDialog()
                    SaveFileDialog.DefaultExt = "xls"
                    SaveFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
                    'SaveFileDialog.FilterIndex = 2
                    'SaveFileDialog.RestoreDirectory = True

                    Dim result As DialogResult = SaveFileDialog.ShowDialog()
                    Dim fileName2 As String = SaveFileDialog.FileName
                    If result = Windows.Forms.DialogResult.OK Then
                        Try

                            Dim workbook As New Workbook
                            Dim worksheet As Worksheet = workbook.Worksheets.Add("Datos")

                            Dim inicio As Integer = 0
                            Dim columnas As Integer = GridView1.Columns.Count - 1

                            worksheet.Rows.Item(inicio).Cells.Item(0).Value = GridView1.Columns(0).FieldName.ToString()
                            worksheet.Rows.Item(inicio).Cells.Item(1).Value = GridView1.Columns(1).FieldName.ToString()
                            worksheet.Rows.Item(inicio).Cells.Item(2).Value = GridView1.Columns(2).FieldName.ToString()
                            worksheet.Rows.Item(inicio).Cells.Item(3).Value = GridView1.Columns(3).FieldName.ToString()
                            worksheet.Rows.Item(inicio).Cells.Item(4).Value = GridView1.Columns(4).FieldName.ToString()
                            worksheet.Rows.Item(inicio).Cells.Item(5).Value = GridView1.Columns(5).FieldName.ToString()
                            worksheet.Rows.Item(inicio).Cells.Item(6).Value = GridView1.Columns(6).FieldName.ToString()
                            worksheet.Rows.Item(inicio).Cells.Item(7).Value = GridView1.Columns(7).FieldName.ToString()
                            worksheet.Rows.Item(inicio).Cells.Item(8).Value = GridView1.Columns(8).FieldName.ToString()
                            worksheet.Rows.Item(inicio).Cells.Item(9).Value = GridView1.Columns(9).FieldName.ToString()
                            worksheet.Rows.Item(inicio).Cells.Item(10).Value = GridView1.Columns(10).FieldName.ToString()
                            worksheet.Rows.Item(inicio).Cells.Item(11).Value = GridView1.Columns(12).FieldName.ToString()
                            worksheet.Rows.Item(inicio).Cells.Item(12).Value = "Semana Solicita"
                            worksheet.Rows.Item(inicio).Cells.Item(13).Value = GridView1.Columns(13).FieldName.ToString()
                            worksheet.Rows.Item(inicio).Cells.Item(14).Value = GridView1.Columns(14).FieldName.ToString()
                            worksheet.Rows.Item(inicio).Cells.Item(columnas).Value = GridView1.Columns(15).FieldName.ToString()

                            For r As Integer = (15) To GridView1.Columns.Count - 2

                                worksheet.Rows.Item(inicio).Cells.Item(r).Value = GridView1.Columns(r + 1).FieldName.ToString()



                            Next


                            For i As Int16 = inicio To inicio Step 1
                                For j As Int16 = 0 To GridView1.Columns.Count - 1 Step 1
                                    worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.RoyalBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                                    worksheet.Rows(i).Cells(j).CellFormat.Alignment = VerticalCellAlignment.Center
                                    worksheet.Rows(i).Cells(j).CellFormat.Alignment = HorizontalCellAlignment.Center
                                    worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.White)
                                Next
                            Next

                            For r As Integer = (0) To GridView1.RowCount - 1

                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = GridView1.GetRowCellValue(r, GridView1.Columns(0).FieldName.ToString())
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(1).Value = GridView1.GetRowCellValue(r, GridView1.Columns(1).FieldName.ToString())
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = GridView1.GetRowCellValue(r, GridView1.Columns(2).FieldName.ToString())
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(3).Value = GridView1.GetRowCellValue(r, GridView1.Columns(3).FieldName.ToString())
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(4).Value = GridView1.GetRowCellValue(r, GridView1.Columns(4).FieldName.ToString())
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(5).Value = GridView1.GetRowCellValue(r, GridView1.Columns(5).FieldName.ToString())
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = GridView1.GetRowCellValue(r, GridView1.Columns(6).FieldName.ToString())
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(7).Value = GridView1.GetRowCellValue(r, GridView1.Columns(7).FieldName.ToString())
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(8).Value = GridView1.GetRowCellValue(r, GridView1.Columns(8).FieldName.ToString())
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(9).Value = GridView1.GetRowCellValue(r, GridView1.Columns(9).FieldName.ToString())
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(10).Value = GridView1.GetRowCellValue(r, GridView1.Columns(10).FieldName.ToString())
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(11).Value = GridView1.GetRowCellValue(r, GridView1.Columns(12).FieldName.ToString())
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(12).Value = GridView1.GetRowCellValue(r, GridView1.Columns(11).FieldName.ToString())
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(13).Value = GridView1.GetRowCellValue(r, GridView1.Columns(13).FieldName.ToString())
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = GridView1.GetRowCellValue(r, GridView1.Columns(14).FieldName.ToString())
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(columnas).Value = GridView1.GetRowCellValue(r, GridView1.Columns(15).FieldName.ToString())
                            Next

                            For j As Int16 = 15 To GridView1.Columns.Count - 2 Step 1

                                For r As Integer = (0) To GridView1.RowCount - 1


                                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(j).Value = GridView1.GetRowCellValue(r, GridView1.Columns(j + 1).FieldName.ToString())

                                Next
                            Next


                            workbook.Save(fileName2)

                            Dim objMensajeExito As New ExitoForm
                            objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                            objMensajeExito.mensaje = "Los datos se exportaron correctamente en la ubicación " + fileName2 + "."
                            objMensajeExito.ShowDialog()
                            Process.Start(fileName2)
                        Catch ex As Exception
                            Dim objMensajeError As New ErroresForm With {
                            .StartPosition = FormStartPosition.CenterScreen,
                            .mensaje = ex.Message
                        }
                            objMensajeError.ShowDialog()
                        End Try
                    End If


                    'If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                    '    filename = SaveFileDialog.FileName
                    '    grdExportarExcel.ExportToXlsx(filename)


                    '    Dim mensajeExito As New ExitoForm
                    '    Cursor = Cursors.Default
                    '    mensajeExito.mensaje = "Los datos se exportaron correctamente: " & filename
                    '    mensajeExito.ShowDialog()


                    '    If System.IO.File.Exists(filename) Then
                    '        Dim DialogResult As DialogResult = MessageBox.Show("El archivo ha sido exportado a " & filename & vbNewLine & "¿Quieres abrirlo ahora?", "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    '        If DialogResult = Windows.Forms.DialogResult.Yes Then
                    '            System.Diagnostics.Process.Start(filename)
                    '        End If
                    '    End If
                    'End If
                Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No existen registros para exportar")
                End If

            Else

                If grid.Rows.Count > 0 Then
                    Dim SaveFileDialog As New SaveFileDialog()
                    SaveFileDialog.Filter = "xlsx files|*.xlsx|CSV|*.csv"
                    SaveFileDialog.FilterIndex = 2
                    SaveFileDialog.RestoreDirectory = True

                    If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                        filename = SaveFileDialog.FileName
                        gridExcelExporter.Export(grid, filename)

                        Dim mensajeExito As New ExitoForm
                        Cursor = Cursors.Default
                        mensajeExito.mensaje = "Los datos se exportaron correctamente: " & filename
                        mensajeExito.ShowDialog()


                        If System.IO.File.Exists(filename) Then
                            Dim DialogResult As DialogResult = MessageBox.Show("El archivo ha sido exportado a " & filename & vbNewLine & "¿Quieres abrirlo ahora?", "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            If DialogResult = Windows.Forms.DialogResult.Yes Then
                                System.Diagnostics.Process.Start(filename)
                            End If
                        End If
                    End If
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No existen registros para exportar")
                End If
            End If
        Catch ex As Exception

        End Try
        'Cursor = Cursors.WaitCursor
        'Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        'Dim fbdUbicacionArchivo As New FolderBrowserDialog
        'Dim grid As New UltraGrid
        'Dim nombreDocumento As String = String.Empty
        'Dim advertencia As New AdvertenciaForm
        'Dim objBU As New Negocios.EstadisticoPedidosBU
        'Dim nombreExportar As String = "REPORTE GENERAL DE PEDIDOS"

        'grid = grdReportePedidos
        'If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 Then

        '    nombreDocumento = "\ReporteVentas"


        '    With fbdUbicacionArchivo

        '        .Reset()
        '        .Description = " Seleccione una carpeta "
        '        .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        '        .ShowNewFolderButton = True

        '        Dim ret As DialogResult = .ShowDialog

        '        If ret = Windows.Forms.DialogResult.OK Then

        '            Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
        '            gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
        '            Dim mensajeExito As New ExitoForm
        '            Cursor = Cursors.Default
        '            mensajeExito.mensaje = "Los datos se exportaron correctamente: " & .SelectedPath + nombreDocumento + fecha_hora + ".xlsx"
        '            mensajeExito.ShowDialog()

        '            objBU.bitacoraExportacionExcel(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "EXCEL", "SAY", nombreExportar, dtpFechaEntregaDel.Value.ToShortDateString(), dtpFechaEntregaAl.Value.ToShortDateString())

        '            Process.Start(fbdUbicacionArchivo.SelectedPath + nombreDocumento + fecha_hora + ".xlsx")

        '        End If

        '        .Dispose()
        '    End With
        'Else
        '    Cursor = Cursors.Default
        '    advertencia.mensaje = "No hay datos para exportar "
        '    advertencia.ShowDialog()
        'End If
        'Cursor = Cursors.Default
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        'Try
        '    Dim pdf As Byte() = My.Resources.AyudaReportePedidos
        '    Using tmp As New FileStream("AyudaReportePedidos.pdf", FileMode.Create)
        '        tmp.Write(pdf, 0, pdf.Length)
        '    End Using
        '    Process.Start("AyudaReportePedidos.pdf")
        'Catch ex As Exception

        'End Try

        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_Reporte_General_Pedidos.pdf")
            Process.Start("Descargas\Manuales\Ventas\COVE_MAUS_Reporte_General_Pedidos.pdf")
        Catch ex As Exception

        End Try


    End Sub

    Private Function seleccionarAgenteVentas() As DataTable
        Dim dtAgenteConsulta As New DataTable
        Dim objBu As New Negocios.ReportePedidosFacturacionBU

        dtAgenteConsulta = objBu.obtenerAgentePorColaborador(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)

        Return dtAgenteConsulta

    End Function

    Private Sub btnColeccion_Click(sender As Object, e As EventArgs) Handles btnColeccion.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 23

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdColecciones.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColecciones.DataSource = listado.listParametros
        With grdColecciones
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True
            .DisplayLayout.Bands(0).Columns(6).Hidden = True
            .DisplayLayout.Bands(0).Columns(7).Hidden = True
            '.DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colecciones"
        End With
    End Sub

    Private Sub grdColecciones_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColecciones.InitializeLayout
        grid_diseño(grdColecciones)
        grdColecciones.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Colecciones"
    End Sub

    Private Sub btnLimpiarFiltroMarca_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroMarca.Click
        grdMarcas.DataSource = listInicial
    End Sub

    Private Sub btnLimpiarFiltroColeccion_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroColeccion.Click
        grdColecciones.DataSource = listInicial
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdClientes.DataSource = listInicial
    End Sub

    Private Sub btnLimpiarFiltroFamilia_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroFamilia.Click
        grdFamilias.DataSource = listInicial
    End Sub

    Private Sub btnLimpiarFiltroAgente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroAgente.Click
        grdAgentes.DataSource = listInicial
    End Sub

    Private Sub btnMostrarFechaEntrega_Click(sender As Object, e As EventArgs) Handles btnMostrarFechaEntrega.Click
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
        Dim lClientes As String = String.Empty
        Dim lFamilias As String = String.Empty
        Dim lColecciones As String = String.Empty
        Dim ConDetalle As Integer = 0

        FechaInicioProgramacion = dtpFechaEntregaDel.Value.ToShortDateString()
        FechaFinProgramacion = dtpFechaEntregaAl.Value.ToShortDateString()
        Agrupamiento = cmboxAgrupamiento.SelectedIndex + 1

        For Each row As UltraGridRow In grdAgentes.Rows
            If row.Index = 0 Then
                lAgentes += "" + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                lAgentes += "," + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next
        For Each row As UltraGridRow In grdMarcas.Rows
            If row.Index = 0 Then
                lMarcas += "" + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                lMarcas += "," + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next

        For Each row As UltraGridRow In grdClientes.Rows
            If row.Index = 0 Then
                lClientes += "" + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                lClientes += "," + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next
        For Each row As UltraGridRow In grdFamilias.Rows
            If row.Index = 0 Then
                lFamilias += "" + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                lFamilias += "," + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next

        For Each Row As UltraGridRow In grdColecciones.Rows
            If Row.Index = 0 Then
                lColecciones += "" + Replace(Row.Cells(0).Text, ",", "") + ""
            Else
                lColecciones += "," + Replace(Row.Cells(0).Text, ",", "") + ""
            End If
        Next

        grdReportePedidos.DataSource = Nothing
        'dtTablaResultado.Columns("Cancelado").DataType = System.Type.GetType("System.Int32")
        'dtTablaResultado.Columns("ParesFacturados").DataType = System.Type.GetType("System.Int32")
        'dtTablaResultado.Columns("CantidadPartida").DataType = System.Type.GetType("System.Int32")
        If Agrupamiento = SELECCION_CLIENTES_TALLAS + 1 Then
            dtTablaResultado = objBU.ConsultarClientesTallas(FechaInicioProgramacion, FechaFinProgramacion, lClientes, lFamilias)
            If dtTablaResultado.Rows.Count > 0 Then
                grdReportePedidos.DataSource = dtTablaResultado
            End If
        Else
            If Agrupamiento = 4 Then
                Dim dtConsultareporte As DataTable
                Dim grdreporte As New UltraGrid

                dtConsultareporte = objBU.ConsultaReportePedidos_FEntregaCliente(FechaInicioProgramacion, FechaFinProgramacion, lAgentes, lMarcas, lClientes, lFamilias, Agrupamiento, lColecciones)
                grdExportarExcel.DataSource = dtConsultareporte
                For Each col As DataColumn In dtTablaResultado.Columns
                    listEncabezados.Add(col.ColumnName)
                Next
                DisenioGrid()

            End If

            dtTablaResultado = objBU.ConsultaReportePedidos_FEntregaCliente(FechaInicioProgramacion, FechaFinProgramacion, lAgentes, lMarcas, lClientes, lFamilias, Agrupamiento, lColecciones)
            If dtTablaResultado.Rows.Count > 0 Then
                grdReportePedidos.DataSource = dtTablaResultado
                For Each col As DataColumn In dtTablaResultado.Columns
                    listEncabezados.Add(col.ColumnName)
                Next
                diseñoGridReporte(grdReportePedidos)
            End If
        End If


        If dtTablaResultado.Rows.Count = 0 Then
            objMensajeInfo.mensaje = "No hay datos para mostrar"
            objMensajeInfo.ShowDialog()
        End If

        lblNumRegistros.Text = grdReportePedidos.Rows.Count().ToString("##,##0")
        btnArriba_Click(sender, e)
        Cursor = Cursors.Default
    End Sub



    '    vwReporteExcel.OptionsCustomization.AllowSort = True
    '    '  vwReporteExcel.OptionsCustomization.AllowFilter = True
    '    vwReporteExcel.IndicatorWidth = 30
    '    '   vwReporteExcel.OptionsView.ShowAutoFilterRow = True
    ''For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporteExcel.Columns
    ''    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    '    col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains

    Private Sub DisenioGrid()
        Dim facturados As Integer = 0
        Dim pfactat As Integer = 0
        Dim pfacturar As Integer = 0
        Dim total As Integer = 0
        If GridView1.GroupSummary.Count() = 0 Then


            For Each col As DevExpress.XtraGrid.Columns.GridColumn In GridView1.Columns
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
                col.OptionsColumn.AllowEdit = False

            Next
            For i = 0 To GridView1.RowCount - 1
                If GridView1.Columns.Contains(GridView1.Columns.ColumnByFieldName("PFacturar")) Then
                    If GridView1.Columns.Contains(GridView1.Columns.ColumnByFieldName("PFactAt")) Then
                        facturados = IIf(IsDBNull(GridView1.GetRowCellValue(i, "TotalFacturados")), 0, GridView1.GetRowCellValue(i, "TotalFacturados"))
                        pfactat = IIf(IsDBNull(GridView1.GetRowCellValue(i, "PFactAt")), 0, GridView1.GetRowCellValue(i, "PFactAt"))
                        pfacturar = IIf(IsDBNull(GridView1.GetRowCellValue(i, "PFacturar")), 0, GridView1.GetRowCellValue(i, "PFacturar"))
                        total = facturados + pfactat + pfacturar
                        GridView1.SetRowCellValue(i, "Total", total) '= total
                    Else
                        facturados = IIf(IsDBNull(GridView1.GetRowCellValue(i, "TotalFacturados")), 0, GridView1.GetRowCellValue(i, "TotalFacturados"))
                        pfacturar = IIf(IsDBNull(GridView1.GetRowCellValue(i, "PFacturar")), 0, GridView1.GetRowCellValue(i, "PFacturar"))
                        total = facturados + pfacturar
                        'GridView1.GetFocusedDataRow("Total") = total
                        GridView1.SetRowCellValue(i, "Total", total) '= total
                    End If
                    If GridView1.Columns.Contains(GridView1.Columns.ColumnByFieldName("PFactAt")) Then
                        facturados = IIf(IsDBNull(GridView1.GetRowCellValue(i, "TotalFacturados")), 0, GridView1.GetRowCellValue(i, "TotalFacturados"))
                        pfactat = IIf(IsDBNull(GridView1.GetRowCellValue(i, "PFactAt")), 0, GridView1.GetRowCellValue(i, "PFactAt"))
                        total = facturados + pfactat
                        'GridView1.GetFocusedDataRow("Total") = total
                        GridView1.SetRowCellValue(i, "Total", total) '= total
                    Else
                        facturados = IIf(IsDBNull(GridView1.GetRowCellValue(i, "TotalFacturados")), 0, GridView1.GetRowCellValue(i, "TotalFacturados"))
                        total = facturados
                        'GridView1.GetFocusedDataRow("Total") = total
                        GridView1.SetRowCellValue(i, "Total", total) '= total

                    End If
                End If
            Next



        End If





    End Sub



    Private Sub btnexportarINT_Click(sender As Object, e As EventArgs) Handles btnexportarINT.Click
        Dim punto As Point
        punto.X = btnexportarINT.Location.X + btnexportarINT.Width
        punto.Y = btnexportarINT.Location.Y + btnexportarINT.Height
        cmsReportesInteligencia.Show(punto)
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

        Try
            imprmirReporteInteligenciaPedidos(2018)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub imprmirReporteInteligenciaVentas(ByVal año As Integer)
        Cursor = Cursors.WaitCursor
        Dim objBU As New ReportePedidosFacturacionBU
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New AdvertenciaForm


        Dim datos = objBU.InteligencciaComercial_Reportes_Ventas(año)
        vwModelos.Columns.Clear()
        grdModelos.DataSource = datos
        'DiseñoGrid.DiseñoBaseGrid(vwModelos)

        If datos.Rows.Count > 0 Then

            nombreDocumento = "\ReporteInteligenciaVentas_"


            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                Dim exportOptions = New XlsxExportOptionsEx()
                AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                exportOptions.ExportType = ExportType.Default

                If ret = Windows.Forms.DialogResult.OK Then

                    grdModelos.ExportToXlsx(.SelectedPath + nombreDocumento + fecha_hora + ".xlsx", exportOptions)

                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & nombreDocumento & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                End If
            End With
        Else
            Cursor = Cursors.Default
            advertencia.mensaje = "No hay datos para exportar "
            advertencia.ShowDialog()
        End If
        Cursor = Cursors.Default


    End Sub

    Private Sub imprmirReporteInteligenciaPedidos(ByVal año As Integer)
        Cursor = Cursors.WaitCursor
        Dim objBU As New ReportePedidosFacturacionBU
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New AdvertenciaForm


        Dim datos = objBU.InteligenciaComercial_Reportes_Pedidos(año)

        vwModelos.Columns.Clear()
        grdModelos.DataSource = datos
        'DiseñoGrid.DiseñoBaseGrid(vwModelos)

        If datos.Rows.Count > 0 Then

            nombreDocumento = "\ReporteInteligenciaPedidos"


            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                Dim exportOptions = New XlsxExportOptionsEx()
                AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                exportOptions.ExportType = ExportType.Default

                If ret = Windows.Forms.DialogResult.OK Then

                    grdModelos.ExportToXlsx(.SelectedPath + nombreDocumento + fecha_hora + ".xlsx", exportOptions)

                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & nombreDocumento & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                End If
            End With
        Else
            Cursor = Cursors.Default
            advertencia.mensaje = "No hay datos para exportar "
            advertencia.ShowDialog()
        End If
        Cursor = Cursors.Default



    End Sub

    Private Sub imprmirReporteInteligenciaDevoluciones(ByVal año As Integer)
        Cursor = Cursors.WaitCursor
        Dim objBU As New ReportePedidosFacturacionBU
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New AdvertenciaForm


        Dim datos = objBU.InteligencciaComercial_Reportes_Devolucion(año)

        vwModelos.Columns.Clear()
        grdModelos.DataSource = datos
        'DiseñoGrid.DiseñoBaseGrid(vwModelos)

        If datos.Rows.Count > 0 Then

            nombreDocumento = "\ReporteInteligenciaPedidos"


            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                Dim exportOptions = New XlsxExportOptionsEx()
                AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                exportOptions.ExportType = ExportType.Default

                If ret = Windows.Forms.DialogResult.OK Then

                    grdModelos.ExportToXlsx(.SelectedPath + nombreDocumento + fecha_hora + ".xlsx", exportOptions)

                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & nombreDocumento & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                End If
            End With
        Else
            Cursor = Cursors.Default
            advertencia.mensaje = "No hay datos para exportar "
            advertencia.ShowDialog()
        End If
        Cursor = Cursors.Default



    End Sub


    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Try
            imprmirReporteInteligenciaPedidos(2019)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        Try
            imprmirReporteInteligenciaVentas(2019)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        Try
            imprmirReporteInteligenciaVentas(2020)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Try
            imprmirReporteInteligenciaPedidos(2020)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        Try
            imprmirReporteInteligenciaVentas(2018)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

    End Sub

    Private Sub cmboxAgrupamiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmboxAgrupamiento.SelectedIndexChanged
        Dim i = cmboxAgrupamiento.SelectedIndex

        If i = SELECCION_CLIENTES_TALLAS Then
            grdAgentes.Enabled = False
            GroupBox2.Enabled = False
            gboxCorrida.Enabled = False
            GroupBox1.Enabled = False
            GroupBox3.Text = "Fecha de Venta"
        Else
            grdAgentes.Enabled = True
            GroupBox2.Enabled = True
            gboxCorrida.Enabled = True
            GroupBox1.Enabled = True
            GroupBox4.Enabled = True
            GroupBox5.Enabled = True
            GroupBox3.Text = "Fecha Solicita Cliente"
        End If
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        Try
            imprmirReporteInteligenciaPedidos(2017)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        Try
            imprmirReporteInteligenciaDevoluciones(2019)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        Try
            imprmirReporteInteligenciaDevoluciones(2020)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        Try
            imprmirReporteInteligenciaPedidos(2021)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        Try
            imprmirReporteInteligenciaVentas(2021)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        Try
            imprmirReporteInteligenciaDevoluciones(2021)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        Try
            imprmirReporteDetalladoFacturacion(2019)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        Try
            imprmirReporteDetalladoFacturacion(2020)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs)
    '    Try
    '        imprmirReporteDetalladoFacturacion(2021)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Private Sub imprmirReporteDetalladoFacturacion(ByVal anio As Integer)
        Cursor = Cursors.WaitCursor
        Dim objBU As New ReportePedidosFacturacionBU
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New AdvertenciaForm


        Dim datos = objBU.ReporteDetalladoFcturacion(anio)

        vwModelos.Columns.Clear()
        grdModelos.DataSource = datos
        'DiseñoGrid.DiseñoBaseGrid(vwModelos)

        If datos.Rows.Count > 0 Then

            nombreDocumento = "\ReporteDetalladoFacturacion"


            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                Dim exportOptions = New XlsxExportOptionsEx()
                AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                exportOptions.ExportType = ExportType.Default

                If ret = Windows.Forms.DialogResult.OK Then

                    grdModelos.ExportToXlsx(.SelectedPath + nombreDocumento + fecha_hora + ".xlsx", exportOptions)

                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & nombreDocumento & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                End If
            End With
        Else
            Cursor = Cursors.Default
            advertencia.mensaje = "No hay datos para exportar "
            advertencia.ShowDialog()
        End If
        Cursor = Cursors.Default



    End Sub

    Private Sub ToolStripMenuItem16_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click
        Try
            imprmirReporteDetalladoFacturacion(2021)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem17_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem17.Click
        Try
            imprmirReporteInteligenciaPedidos(2022)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem18_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem18.Click
        Try
            imprmirReporteInteligenciaVentas(2022)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem19_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem19.Click
        Try
            imprmirReporteInteligenciaDevoluciones(2022)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem20_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem20.Click
        Try
            imprmirReporteDetalladoFacturacion(2022)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class