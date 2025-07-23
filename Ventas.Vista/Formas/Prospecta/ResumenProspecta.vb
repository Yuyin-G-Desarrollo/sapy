Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Ventas.Negocios
Imports Framework.Negocios
Imports Tools

Public Class ResumenProspecta


    Dim dtApartadosProspecta As New DataTable()
    Dim dtProduccion As New DataTable()
    Dim dtBloqueados As New DataTable()
    Dim dtReproceso As New DataTable()
    Public tipoConsulta As Integer = 0
    Public ProspectaID As Integer = 0
    Public FechaInicioProspecta As Date
    Public FechaFinProspecta As Date

    Dim apartadosPriorizables As String
    Dim renglonesSeleccionados As Integer
    Dim renglonesNoPriorizables As Integer


    Private Sub ResumenProspecta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Top = 0
        'Me.Left = 0
        Dim ubicacionTitulo As New System.Drawing.Point(lblTitulo.Location.X - 140, lblTitulo.Location.Y)

        If tipoConsulta = 0 Then
            CargarApartados()
            CargarEnProceso()
            CargarBloqueados()
            CargarReproceso()
            TabControl1.SelectedIndex = 0
            lblNumFiltrados.Text = grdApartado.Rows.Count()
        ElseIf tipoConsulta = 1 Then

            Me.Text = "Apartados Pendientes de Confirmar"
            lblTitulo.Text = "Apartados Pendientes de Confirmar"
            lblTitulo.Location = ubicacionTitulo
            CargarApartados()
            TabControl1.SelectedIndex = 0
            TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(TabPage3)
            TabControl1.TabPages.Remove(TabPage4)
            lblNumFiltrados.Text = grdApartado.Rows.Count()
            pnlEstatusActivo.Visible = True
            pnlEstatusEnEjecucion.Visible = True
            pnlEstatusParcialmenteConfirmado.Visible = True
            lblStActivo.Visible = True
            lblStEjecucion.Visible = True
            lblStParcialmenteConfirmado.Visible = True
        ElseIf tipoConsulta = 2 Then
            Me.Text = "Pares en Proceso"
            lblTitulo.Text = "Pares en Proceso"
            CargarEnProceso()
            TabControl1.SelectedIndex = 1
            TabControl1.TabPages.Remove(TabPage1)
            TabControl1.TabPages.Remove(TabPage3)
            TabControl1.TabPages.Remove(TabPage4)
            lblNumFiltrados.Text = grdProduccion.Rows.Count()
            pnlEstatusActivo.Visible = False
            pnlEstatusEnEjecucion.Visible = False
            pnlEstatusParcialmenteConfirmado.Visible = False
            lblStActivo.Visible = False
            lblStEjecucion.Visible = False
            lblStParcialmenteConfirmado.Visible = False
        ElseIf tipoConsulta = 3 Then
            Me.Text = "Pares Bloqueados"
            lblTitulo.Text = "Pares Bloqueados"
            CargarBloqueados()
            TabControl1.SelectedIndex = 2
            TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(TabPage1)
            TabControl1.TabPages.Remove(TabPage4)
            lblNumFiltrados.Text = grdBloqueados.Rows.Count()
            pnlEstatusActivo.Visible = False
            pnlEstatusEnEjecucion.Visible = False
            pnlEstatusParcialmenteConfirmado.Visible = False
            lblStActivo.Visible = False
            lblStEjecucion.Visible = False
            lblStParcialmenteConfirmado.Visible = False
        ElseIf tipoConsulta = 4 Then
            Me.Text = "Pares en Reproceso"
            lblTitulo.Text = "Pares en Reproceso"
            CargarReproceso()
            TabControl1.SelectedIndex = 3
            TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(TabPage3)
            TabControl1.TabPages.Remove(TabPage1)
            lblNumFiltrados.Text = grdReproceso.Rows.Count()
            pnlEstatusActivo.Visible = False
            pnlEstatusEnEjecucion.Visible = False
            pnlEstatusParcialmenteConfirmado.Visible = False
            lblStActivo.Visible = False
            lblStEjecucion.Visible = False
            lblStParcialmenteConfirmado.Visible = False
        End If

        lblFechaUltimaActualizacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()

    End Sub


    Public Sub CargarApartados()
        Dim objProspecta As New ProspectaBU
        grdApartado.DataSource = Nothing
        DiseñoApartado(grdApartado)
        grdApartado.DataSource = objProspecta.ConsultarParesPendientesDeConfirmar(ProspectaID)

    End Sub

    Public Sub CargarEnProceso()
        Dim objProspecta As New ProspectaBU
        grdProduccion.DataSource = Nothing
        DiseñoProceso(grdProduccion)
        grdProduccion.DataSource = objProspecta.ConsultaParesEnProceso(ProspectaID, FechaInicioProspecta, FechaFinProspecta)

    End Sub

    Public Sub CargarBloqueados()
        Dim objProspecta As New ProspectaBU
        grdBloqueados.DataSource = Nothing
        DiseñoBloqueados(grdBloqueados)
        grdBloqueados.DataSource = objProspecta.ConsultaParesBloqueados(ProspectaID)

    End Sub

    Public Sub CargarReproceso()
        Dim objProspecta As New ProspectaBU
        grdReproceso.DataSource = Nothing
        DiseñoEnReproceso(grdReproceso)
        grdReproceso.DataSource = objProspecta.ConsultaParesEnReProceso(ProspectaID)

    End Sub

    Private Sub DiseñoApartado(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText

        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard

        AgregarColumna(grid, "clie_nombregenerico", "Cliente", False, True, Nothing, 240, , False, HAlign.Left)
        AgregarColumna(grid, "apar_pedidosayid", "Pedido" & vbCrLf & "SAY", False, True, Nothing, 60, False, False, HAlign.Right)
        AgregarColumna(grid, "pedi_pedidoidsicy", "Pedido" & vbCrLf & "SICY", False, True, Nothing, 60, , False, HAlign.Right)
        AgregarColumna(grid, "apar_apartadoid", "Apartado" & vbCrLf & "SAY", False, True, Nothing, 60, , False, HAlign.Right)
        AgregarColumna(grid, "apar_apartadoidsicy", "Apartado" & vbCrLf & "SICY", False, True, Nothing, 70, , False, HAlign.Right)
        AgregarColumna(grid, "PRIORIDAD", "Prioridad", False, True, Nothing, 50, , False, HAlign.Right)
        AgregarColumna(grid, "Prioridad Nueva", "Nueva" & vbCrLf & "Prioridad", True, True, Nothing, 50, , False, HAlign.Right)
        AgregarColumna(grid, "F PREPARACIÓN", "Fecha" & vbCrLf & "Preparación", False, True, Nothing, 65, , False, HAlign.Left)
        AgregarColumna(grid, "ST", "ST", False, True, Nothing, 20, , False, HAlign.Left)
        AgregarColumna(grid, "apar_totalpares", "Total " & vbCrLf & "Apartado", False, True, Nothing, 60, True, False, HAlign.Right)
        AgregarColumna(grid, "apar_paresconfirmados", "Confirmado", False, True, Nothing, 70, True, False, HAlign.Right)
        AgregarColumna(grid, "apar_paresporconfirmar", "Pendiente", False, True, Nothing, 70, True, False, HAlign.Right)
        AgregarColumna(grid, "clie_clienteid", "clie_clienteid", True, True, Nothing, 10)

        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub DiseñoProceso(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
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

        AgregarColumna(grid, "Cliente", "   CLIENTE", False, True, Nothing, 220, , False, HAlign.Left)
        AgregarColumna(grid, "PedidoSayID", "PEDIDO" & vbCrLf & " SAY", False, True, Nothing, 60, , False, HAlign.Right)
        AgregarColumna(grid, "PedidoSicyId", "PEDIDO" & vbCrLf & " SICY", False, True, Nothing, 60, , , HAlign.Right)
        AgregarColumna(grid, "Nave", "NAVE", False, True, Nothing, 80, , , HAlign.Left)
        AgregarColumna(grid, "NaveIdSicy", "NaveIdSicy", True, True, Nothing, 10, , False, HAlign.Right)
        AgregarColumna(grid, "LoteID", "LOTE", False, True, Nothing, 50, , , HAlign.Right)
        AgregarColumna(grid, "IdPrograma", "IdPrograma", True, True, Nothing, 10, , False, HAlign.Right)
        AgregarColumna(grid, "FechaPrograma", "PROGRAMA", False, True, Nothing, 60, , False, HAlign.Left)
        AgregarColumna(grid, "ClienteSicy", "ClienteSicy", True, True, Nothing, 10, , False, HAlign.Right)
        AgregarColumna(grid, "TotalParesProceso", "PARES EN" & vbCrLf & " PROCESO", False, True, Nothing, 60, True, False, HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "Atraso", "DÍAS DE" & vbCrLf & " ATRASO", False, False, Nothing, 60, False, False, HAlign.Right, , , , , "n1")


        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2

        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns


    End Sub


    Private Sub DiseñoBloqueados(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
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


        AgregarColumna(grid, "Cliente", "CLIENTE", False, True, Nothing, 220, , False, HAlign.Left)
        AgregarColumna(grid, "PedidoSay", "PEDIDO" & vbCrLf & " SAY", False, True, Nothing, 70, , False, HAlign.Right)
        AgregarColumna(grid, "PedidoSicy", "PEDIDO" & vbCrLf & " SICY", False, True, Nothing, 70, , False, HAlign.Right)
        AgregarColumna(grid, "ID_Docena", "ATADO", False, True, Nothing, 70, , , HAlign.Right)
        AgregarColumna(grid, "ID_Par", "PAR", False, True, Nothing, 70, True, False, HAlign.Right, , , , SummaryType.Count)
        AgregarColumna(grid, "Descripcion", "DESCRIPCIÓN", False, True, Nothing, 200, , , HAlign.Left)
        AgregarColumna(grid, "idtblPedido", "idtblPedido", True, True, Nothing, 100, , False, HAlign.Right)

        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2

        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

    End Sub


    Private Sub DiseñoEnReproceso(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
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

        'grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns


        AgregarColumna(grid, "Cliente", "CLIENTE", False, True, Nothing, 200, False, False, HAlign.Left)
        AgregarColumna(grid, "PedidoSay", "PEDIDO " & vbCrLf & "SAY", False, True, Nothing, 60, , , HAlign.Right)
        AgregarColumna(grid, "PedidoSicy", "PEDIDO " & vbCrLf & "SICY", False, True, Nothing, 60, , False, HAlign.Right)
        AgregarColumna(grid, "idtbllote", "LOTE", False, True, Nothing, 78, True, False, HAlign.Right, , , , SummaryType.Count)
        AgregarColumna(grid, "Nave", "NAVE", False, True, Nothing, 78, False, False, HAlign.Left)
        AgregarColumna(grid, "idtblaño", "AÑO", False, True, Nothing, 78, False, False, HAlign.Right)
        AgregarColumna(grid, "ID_Docena", "ATADO", False, True, Nothing, 78, , False, HAlign.Right)
        AgregarColumna(grid, "Causa", "CAUSA", True, True, Nothing, 100, , False, HAlign.Left)
        AgregarColumna(grid, "FechaCaptura", "FECHA " & vbCrLf & " CAPTURA", False, True, Nothing, 100, , False, HAlign.Left)
        AgregarColumna(grid, "ParesReproceso", "PARES " & vbCrLf & " REPROCESO", False, False, Nothing, 100, True, False, HAlign.Right, , , , SummaryType.Sum)


        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2

        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

    End Sub




    'Private Sub gridReprocesoDiseño(grid As UltraGrid)

    '    grid.DisplayLayout.Bands(0).Columns("FechaReproceso").Header.Caption = "F Reproceso"

    '    grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
    '    grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    '    grid.DisplayLayout.Override.RowSelectorWidth = 20
    '    grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
    '    'grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    '    grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
    '    grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '    grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
    '    grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
    '    grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
    '    grid.DisplayLayout.GroupByBox.Hidden = False
    '    grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"

    '    Dim summary1 As SummarySettings
    '    summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Count, grid.DisplayLayout.Bands(0).Columns("Par"))
    '    grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
    '    summary1.DisplayFormat = "{0:#,##0}"
    '    summary1.Appearance.TextHAlign = HAlign.Right

    '    Dim width As Integer
    '    For Each col As UltraGridColumn In grid.Rows.Band.Columns
    '        col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
    '        If Not col.Hidden Then
    '            width += col.Width
    '        End If
    '    Next
    '    If width < grid.Width Then
    '        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    '    End If

    'End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            lblNumFiltrados.Text = grdApartado.Rows.Count()
        ElseIf TabControl1.SelectedIndex = 1 Then
            lblNumFiltrados.Text = grdProduccion.Rows.Count
        ElseIf TabControl1.SelectedIndex = 2 Then
            lblNumFiltrados.Text = grdBloqueados.Rows.Count
        ElseIf TabControl1.SelectedIndex = 3 Then
            lblNumFiltrados.Text = grdReproceso.Rows.Count
        End If
    End Sub


    Private Sub AgregarColumna(ByRef grid As UltraGrid, ByVal Key As String, ByVal NombreColumna As String, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, ByVal ColorColumna As Color, Optional ByVal Width As Integer = -1, Optional ByVal SumarizarColumna As Boolean = False, Optional ByVal Edicion As Boolean = False, Optional ByVal Alineacion As HAlign = Nothing, Optional ByVal NEgrita As Boolean = False, Optional ByVal EsPorcentaje As Boolean = False, Optional ByVal Tooltip As String = "", Optional ByVal Operacion As SummaryType = SummaryType.Sum, Optional ByVal Formato As String = "")
        With grid
            .DisplayLayout.Bands(0).Columns.Add(Key, NombreColumna)
            FormatoColumna(.DisplayLayout.Bands(0).Columns(Key), Ocultar, EsCadena, Width, EsPorcentaje)
            If IsNothing(ColorColumna) Then
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = Color.Black
            Else
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = ColorColumna
            End If
            If SumarizarColumna = True Then
                SumarizarColumnaGrid(grid, Key, "Sumarizar " + Key, Operacion)
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

            If Formato <> "" Then
                .DisplayLayout.Bands(0).Columns(Key).Format = Formato
            End If

        End With
    End Sub

    Private Sub FormatoColumna(ByRef columna As UltraGridColumn, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, Optional ByVal Width As Integer = -1, Optional ByVal EsPorcentaje As Boolean = False)
        Dim FormatoNumero As String = "###,###,##0"
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

    Private Sub SumarizarColumnaGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal NombreColumna As String, ByVal Key As String, ByVal Operacion As SummaryType)
        Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns(NombreColumna)
        Dim summary As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add(Key, Operacion, columnToSummarize)
        summary.DisplayFormat = "{0:###,###,##0}"
        summary.Appearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
    End Sub


    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel()
    End Sub

    Public Sub exportarExcel()
        Dim sfd As New SaveFileDialog
        Dim grd As UltraGrid
        Dim tabSeleccionada As TabPage

        tabSeleccionada = TabControl1.SelectedTab
        If tabSeleccionada.Text = "Apartados" Then
            grd = grdApartado
        ElseIf tabSeleccionada.Text = "Producción" Then
            grd = grdProduccion
        ElseIf tabSeleccionada.Text = "Bloqueados" Then
            grd = grdBloqueados
        ElseIf tabSeleccionada.Text = "Reproceso" Then
            grd = grdReproceso
        End If


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

    Private Sub grdApartado_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdApartado.InitializeRow
        e.Row.Cells("ST").Appearance.ForeColor = Color.Transparent

        Select Case e.Row.Cells("ST").Value
            Case "AC"
                e.Row.Cells("ST").Appearance.BackColor = pnlEstatusActivo.BackColor
            Case "EJ"
                e.Row.Cells("ST").Appearance.BackColor = pnlEstatusEnEjecucion.BackColor
            Case "PA"
                e.Row.Cells("ST").Appearance.BackColor = pnlEstatusParcialmenteConfirmado.BackColor
        End Select

    End Sub

    Private Sub grdApartado_MouseClick(sender As Object, e As MouseEventArgs) Handles grdApartado.MouseClick
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMON_APARTADOS", "VENT_ADMON_APARTADOS_VENTAS") Then
            If e.Button = Windows.Forms.MouseButtons.Right Then

                apartadosPriorizables = ""

                Dim indiceRenglonApartadoSeleccionado As Integer = 0

                renglonesSeleccionados = 0
                renglonesNoPriorizables = 0
                Dim celdasSeleccionadas As Integer = 0

                For Each renglon As UltraGridRow In grdApartado.Rows
                    'If renglon.Selected Then
                    '    renglonesSeleccionados += 1
                    '    If renglon.Cells("ST").Value <> "AC" Then
                    '        renglonesNoPriorizables += 1
                    '    End If
                    '    If apartadosPriorizables = "" Then
                    '        apartadosPriorizables = renglon.Cells("apar_apartadoid").Value.ToString()
                    '    End If
                    'Else
                    If renglon.Selected Then
                        renglonesSeleccionados += 1
                        If renglon.Cells("ST").Value <> "AC" Then
                            renglonesNoPriorizables += 1
                        End If
                        If apartadosPriorizables = "" Then
                            apartadosPriorizables = renglon.Cells("apar_apartadoid").Value.ToString()
                        End If
                    End If
                Next

                cmsPriorizar.Show(Control.MousePosition)

            End If
        End If
    End Sub

    Private Sub tsmiAsignarPrioridad_Click(sender As Object, e As EventArgs) Handles tsmiAsignarPrioridad.Click
        If renglonesNoPriorizables < renglonesSeleccionados Then
            Dim objApartados As New Negocios.ApartadosBU
            Dim dtResultadoPrioridad As New DataTable

            dtResultadoPrioridad = objApartados.priorizarApartadosProspecta(apartadosPriorizables)

            CargarApartados()

            'For Each renglon As UltraGridRow In grdApartado.Rows
            '    If renglon.Cells("apar_apartadoid").Value.ToString = apartadosPriorizables Then
            '        renglon.Cells("Prioridad Nueva").Value = Integer.Parse(dtResultadoPrioridad.Rows(0).Item("PrioridadNueva").ToString())
            '    End If
            'Next
        Else
            show_message("Advertencia", "Unicamente se pueden priorizar apartados activos.")
        End If
    End Sub
End Class