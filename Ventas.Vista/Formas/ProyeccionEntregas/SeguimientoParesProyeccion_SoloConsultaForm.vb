Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Ventas.Negocios
Imports Framework.Negocios
Imports Tools
Public Class SeguimientoParesProyeccion_SoloConsultaForm
    Dim dtApartadosProspecta As New DataTable()
    Dim dtProduccion As New DataTable()
    Dim dtBloqueados As New DataTable()
    Dim dtReproceso As New DataTable()
    Public tipoConsulta As Integer = 0
    Public SesionID As Integer = 0
    Public FechaInicioProspecta As Date
    Public FechaFinProspecta As Date
    Const EsModoConsulta As Boolean = True

    Dim apartadosPriorizables As String
    Dim renglonesSeleccionados As Integer
    Dim renglonesNoPriorizables As Integer


    Private Sub SeguimientoParesProyeccionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ubicacionTitulo As New System.Drawing.Point(lblTitulo.Location.X - 140, lblTitulo.Location.Y)
        lblAbreviaturas1.Visible = False
        lblAbreviaturas2.Visible = False

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
            TabControl1.TabPages.Remove(TabPage5)
            TabControl1.TabPages.Remove(TabPage6)
            lblNumFiltrados.Text = CDbl(grdApartado.Rows.Count().ToString()).ToString("N0")
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
            TabControl1.TabPages.Remove(TabPage5)
            TabControl1.TabPages.Remove(TabPage6)
            lblNumFiltrados.Text = CDbl(grdProduccion.Rows.Count().ToString()).ToString("N0")
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
            TabControl1.TabPages.Remove(TabPage5)
            TabControl1.TabPages.Remove(TabPage6)
            lblNumFiltrados.Text = CDbl(grdBloqueados.Rows.Count().ToString()).ToString("N0")
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
            TabControl1.TabPages.Remove(TabPage5)
            TabControl1.TabPages.Remove(TabPage6)
            lblNumFiltrados.Text = CDbl(grdReproceso.Rows.Count().ToString()).ToString("N0")
            pnlEstatusActivo.Visible = False
            pnlEstatusEnEjecucion.Visible = False
            pnlEstatusParcialmenteConfirmado.Visible = False
            lblStActivo.Visible = False
            lblStEjecucion.Visible = False
            lblStParcialmenteConfirmado.Visible = False
        ElseIf tipoConsulta = 5 Then
            Me.Text = "Clientes Bloqueados"
            lblTitulo.Text = "Clientes Bloqueados"
            CargarClientesBloqueados()
            TabControl1.SelectedIndex = 4
            TabControl1.TabPages.Remove(TabPage1)
            TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(TabPage3)
            TabControl1.TabPages.Remove(TabPage4)
            TabControl1.TabPages.Remove(TabPage6)
            lblNumFiltrados.Text = CDbl(grdClientesBloqueados.Rows.Count().ToString()).ToString("N0")
            pnlEstatusActivo.Visible = False
            pnlEstatusEnEjecucion.Visible = False
            pnlEstatusParcialmenteConfirmado.Visible = False
            lblStActivo.Visible = False
            lblStEjecucion.Visible = False
            lblStParcialmenteConfirmado.Visible = False
            'Me.Width = 700
            lblAbreviaturas1.Visible = True
            lblAbreviaturas2.Visible = True

        ElseIf tipoConsulta = 6 Then
            Me.Text = "Programación / Programado"
            lblTitulo.Text = "Programación / Programado"
            CargarParesProgamadosProgramacion()
            TabControl1.SelectedIndex = 5
            TabControl1.TabPages.Remove(TabPage1)
            TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(TabPage3)
            TabControl1.TabPages.Remove(TabPage4)
            TabControl1.TabPages.Remove(TabPage5)
            lblNumFiltrados.Text = CDbl(grdParesProgramadosProduccion.Rows.Count().ToString()).ToString("N0")
            pnlEstatusActivo.Visible = False
            pnlEstatusEnEjecucion.Visible = False
            pnlEstatusParcialmenteConfirmado.Visible = False
            lblStActivo.Visible = False
            lblStEjecucion.Visible = False
            lblStParcialmenteConfirmado.Visible = False
            'Me.Width = 700
            lblAbreviaturas1.Visible = False
            lblAbreviaturas2.Visible = False

        End If

        lblFechaUltimaActualizacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()

    End Sub

    Public Sub CargarApartados()
        Dim objBU As New ProyeccionEntregasBU
        grdApartado.DataSource = Nothing
        DiseñoApartado(grdApartado)
        grdApartado.DataSource = objBU.ConsultaParesApartadosPorConfirmar(SesionID, EsModoConsulta)

    End Sub

    Private Sub CargarParesProgamadosProgramacion()
        Dim objBU As New ProyeccionEntregasBU
        grdApartado.DataSource = Nothing
        DiseñoProgramadoProgramacion(grdParesProgramadosProduccion)
        grdParesProgramadosProduccion.DataSource = objBU.ConsultaParesProgramacionProgramado(SesionID, EsModoConsulta)
    End Sub


    Public Sub CargarEnProceso()
        Dim objBU As New ProyeccionEntregasBU
        grdProduccion.DataSource = Nothing
        DiseñoProceso(grdProduccion)
        grdProduccion.DataSource = objBU.ConsultaParesEnProceso_SoloConsulta(SesionID)
    End Sub

    Public Sub CargarBloqueados()
        Dim objBU As New ProyeccionEntregasBU
        grdBloqueados.DataSource = Nothing
        DiseñoBloqueados(grdBloqueados)
        grdBloqueados.DataSource = objBU.ConsultaParesBloquedos_SoloConsulta(SesionID)
    End Sub


    Public Sub CargarReproceso()
        Dim objBU As New ProyeccionEntregasBU
        grdReproceso.DataSource = Nothing
        DiseñoEnReproceso(grdReproceso)
        grdReproceso.DataSource = objBU.ConsultaParesEnReproceso_SoloConsulta(SesionID)
    End Sub

    Public Sub CargarClientesBloqueados()
        Dim objBU As New ProyeccionEntregasBU
        grdClientesBloqueados.DataSource = Nothing
        DiseñoClientesBloqueados(grdClientesBloqueados)
        grdClientesBloqueados.DataSource = objBU.ConsultaClientesBloqueados(SesionID, EsModoConsulta)
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


    Private Sub DiseñoProgramadoProgramacion(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        '        grid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText

        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard

        AgregarColumna(grid, "Cliente", "Cliente", False, True, Nothing, 220, , False, HAlign.Left)
        AgregarColumna(grid, "PedidoSayID", "Pedido" & vbCrLf & " SAY", False, True, Nothing, 60, False, False, HAlign.Right)
        AgregarColumna(grid, "PedidoSicyID", "Pedido" & vbCrLf & " SICY", False, True, Nothing, 60, False, False, HAlign.Right)
        AgregarColumna(grid, "Partida", "Partida", False, True, Nothing, 50, , , HAlign.Right)
        AgregarColumna(grid, "Descripcion", "Descripción", False, True, Nothing, 200, , False, HAlign.Left)
        AgregarColumna(grid, "TotalParesProgramacion", "PRG", False, True, Nothing, 60, True, False, HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "TotalParesProgramados", "PRO", False, True, Nothing, 60, True, False, HAlign.Right, , , , SummaryType.Sum)


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

        AgregarColumna(grid, "Cliente", "   Cliente", False, True, Nothing, 220, , False, HAlign.Left)
        AgregarColumna(grid, "PedidoSayID", "Pedido" & vbCrLf & " SAY", False, True, Nothing, 60, , False, HAlign.Right)
        AgregarColumna(grid, "PedidoSicyId", "Pedido" & vbCrLf & " SICY", False, True, Nothing, 60, , , HAlign.Right)
        AgregarColumna(grid, "Nave", "Nave", False, True, Nothing, 80, , , HAlign.Left)
        AgregarColumna(grid, "NaveIdSicy", "NaveIdSicy", True, True, Nothing, 10, , False, HAlign.Right)
        AgregarColumna(grid, "LoteID", "Lote", False, True, Nothing, 50, , , HAlign.Right)
        AgregarColumna(grid, "IdPrograma", "IdPrograma", True, True, Nothing, 10, , False, HAlign.Right)
        AgregarColumna(grid, "FechaPrograma", "Programa", False, True, Nothing, 60, , False, HAlign.Left)
        AgregarColumna(grid, "ClienteSicy", "ClienteSicy", True, True, Nothing, 10, , False, HAlign.Right)
        'AgregarColumna(grid, "TotalParesProgramacion", "PRO", False, True, Nothing, 60, False, False, HAlign.Right, , , , SummaryType.Sum)
        'AgregarColumna(grid, "TotalParesProgramados", "PRG", False, True, Nothing, 60, False, False, HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "TotalParesProceso", "Pares en" & vbCrLf & " Proceso", False, True, Nothing, 60, True, False, HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "Atraso", "Atraso", False, True, Nothing, 60, False, False, HAlign.Right, , , , )


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


        AgregarColumna(grid, "Cliente", "Cliente", False, True, Nothing, 220, , False, HAlign.Left)
        AgregarColumna(grid, "PedidoSay", "Pedido" & vbCrLf & " SAY", False, True, Nothing, 70, , False, HAlign.Right)
        AgregarColumna(grid, "PedidoSicy", "Pedido" & vbCrLf & " SICY", False, True, Nothing, 70, , False, HAlign.Right)
        AgregarColumna(grid, "ID_Docena", "Atado", False, True, Nothing, 70, , , HAlign.Right)
        AgregarColumna(grid, "ID_Par", "Par", False, True, Nothing, 70, True, False, HAlign.Right, , , , SummaryType.Count)
        AgregarColumna(grid, "Descripcion", "Descripción", False, True, Nothing, 200, , , HAlign.Left)
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


        AgregarColumna(grid, "Cliente", "Cliente", False, True, Nothing, 200, False, False, HAlign.Left)
        AgregarColumna(grid, "PedidoSay", "Pedido " & vbCrLf & "SAY", False, True, Nothing, 60, , , HAlign.Right)
        AgregarColumna(grid, "PedidoSicy", "Pedido " & vbCrLf & "SICY", False, True, Nothing, 60, , False, HAlign.Right)
        AgregarColumna(grid, "idtbllote", "Lote", False, True, Nothing, 78, True, False, HAlign.Right, , , , SummaryType.Count)
        AgregarColumna(grid, "Nave", "Nave", False, True, Nothing, 78, False, False, HAlign.Left)
        AgregarColumna(grid, "idtblaño", "Año", False, True, Nothing, 78, False, False, HAlign.Right)
        AgregarColumna(grid, "ID_Docena", "Atado", False, True, Nothing, 78, , False, HAlign.Right)
        AgregarColumna(grid, "Causa", "Causa", True, True, Nothing, 100, , False, HAlign.Left)
        AgregarColumna(grid, "FechaCaptura", "Fecha " & vbCrLf & " Captura", False, True, Nothing, 100, , False, HAlign.Left)
        AgregarColumna(grid, "ParesReproceso", "Pares " & vbCrLf & " Reproceso", False, True, Nothing, 100, True, False, HAlign.Right, , , , SummaryType.Sum)


        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2

        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

    End Sub



    Private Sub DiseñoClientesBloqueados(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
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


        AgregarColumna(grid, "Cliente", "Cliente", False, True, Nothing, 220, False, False, HAlign.Left)
        AgregarColumna(grid, "Cap", "CAP", False, False, Nothing, 20, False, False, HAlign.Right)
        AgregarColumna(grid, "Pro", "PRO", False, False, Nothing, 20, False, False, HAlign.Right)
        AgregarColumna(grid, "Ent", "ENT", False, False, Nothing, 20, False, False, HAlign.Right)
        AgregarColumna(grid, "Cont", "CONT", False, False, Nothing, 20, False, False, HAlign.Right)
        AgregarColumna(grid, "PorEntregar", "Por Entregar", False, False, Nothing, 80, True, False, HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "MontoPorEntregar", "Monto " & vbCrLf & "Por Entregar", False, False, Nothing, 80, True, False, HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "Inventario", "Inventario", False, False, Nothing, 100, True, False, HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "Proceso", "Proceso", False, False, Nothing, 100, True, False, HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "LimiteCredito", "Crédito Disponible", False, False, Nothing, 100, False, False, HAlign.Right)
        AgregarColumna(grid, "DiasPlazo", "Días de Plazo", False, False, Nothing, 100, False, False, HAlign.Right)

        'MontoPorEntregar
        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2

        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            lblNumFiltrados.Text = CDbl(grdApartado.Rows.Count().ToString()).ToString("N0")
        ElseIf TabControl1.SelectedIndex = 1 Then
            lblNumFiltrados.Text = CDbl(grdProduccion.Rows.Count().ToString()).ToString("N0")
        ElseIf TabControl1.SelectedIndex = 2 Then
            lblNumFiltrados.Text = CDbl(grdBloqueados.Rows.Count().ToString()).ToString("N0")
        ElseIf TabControl1.SelectedIndex = 3 Then
            lblNumFiltrados.Text = CDbl(grdReproceso.Rows.Count().ToString()).ToString("N0")
        End If
    End Sub


    Private Sub AgregarColumna(ByRef grid As UltraGrid, ByVal Key As String, ByVal NombreColumna As String, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, ByVal ColorColumna As Color, Optional ByVal Width As Integer = -1, Optional ByVal SumarizarColumna As Boolean = False, Optional ByVal Edicion As Boolean = False, Optional ByVal Alineacion As HAlign = Nothing, Optional ByVal NEgrita As Boolean = False, Optional ByVal EsPorcentaje As Boolean = False, Optional ByVal Tooltip As String = "", Optional ByVal Operacion As SummaryType = SummaryType.Sum)
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
        Dim grd As UltraGrid = Nothing
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
        ElseIf tabSeleccionada.Text = "Clientes Bloqueados" Then
            grd = grdClientesBloqueados
        ElseIf tabSeleccionada.Text = "Programación / Programado" Then
            grd = grdParesProgramadosProduccion
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

    End Sub
End Class