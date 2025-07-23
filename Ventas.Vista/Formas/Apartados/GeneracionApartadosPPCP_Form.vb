Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports System.Globalization

Public Class GeneracionApartadosPPCP_Form

    Public disponibleApartar As Integer = 0  '1 = Disponible generar apartados, 0 = Disponible solo para consulta
    Public filtrosGenerarApartados As Entidades.FiltrosGeneracionApartadosPPCP
    Public listRenglonesSeleccionados As New List(Of Integer)
    Public permitirIncluirExcluirPartidas As Integer = 1
    Public totalPartidasSeleccionadas As Integer = 0

    Public IndiceInicioRenglonArrastrado As Integer = 0
    Public IndiceFinRenglonArrastrado As Integer = 0

    Public pedidoDetalleIdModificarTallas As Integer = 0
    Public programaIdModificarTallas As Integer = 0
    Public naveIdModificarTallas As Integer = 0
    Public indiceRenglonModificarTallas As Integer = 0

    Public tipoDistribucion As Integer = 0 '0 primera distribución, 1 redistribución

    Dim ultimoApartadoAntesDeGenerar As Integer = 0
    Dim ultimoApartadoDespuesDeGenerar As Integer = 0

    Dim pedidosSeleccionados As String = String.Empty
    Dim pedidosDetallesSeleccionados As String = String.Empty
    Dim navesSeleccionadas As String = String.Empty
    Dim programasSeleccionados As String = String.Empty
    Dim apartadosGenerados As Integer = 0 ' 0 = no se han generado, 1 = ya se generaron
    Dim disponibilidadGeneradaAnteriormente As Integer = 0 ' 0 no se consultado la disponibilidad, 1 ya se consulto la disponibilidad

    Dim distribucionGeneradaAnteriormente As Integer = 0 '0= no, 1 = si

    Private Sub gridApartados_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdDatosGenerarApartados.InitializeLayout

    End Sub

    Private Sub GeneracionApartadosPPCP_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ObjBU As New Negocios.ApartadosBU
        Dim dtApartadosPorConfirmar As New DataTable
        Dim dtParesPorConfirmar As New DataTable
        'Dim tablaInventarioInicial As New DataTable
        'Dim tablaLotesAProgramas As New DataTable
        'Dim CodigosSICY As String = ""
        'Dim CorridasSICY As String = ""
        'Dim Corridas As String = ""
        'Dim Tallas As String = ""
        'Dim IdTallasSay As String = ""
        'Dim Pares As String = ""
        'Dim ProductosEstilos As String = ""
        'Dim Descripciones As String = ""
        'Dim contador As Integer = 0
        'Dim IdPedidos As String = ""
        'Dim IdPartidas As String = ""
        'Dim IdNaves As String = ""
        'Dim programalotes As String = ""
        'Dim estatusLotes As String = ""
        'Dim CantLotesAs As String = ""
        'Dim FechaProgramas As String = ""
        'Dim EstatusProgramas As String = ""
        'Dim LTS01 As String = ""
        'Dim LTS02 As String = ""
        'Dim LTS03 As String = ""
        'Dim LTS04 As String = ""
        'Dim LTS05 As String = ""
        'Dim LTS06 As String = ""
        'Dim LTS07 As String = ""
        'Dim LTS08 As String = ""
        'Dim LTS09 As String = ""
        'Dim LTS10 As String = ""
        'Dim LTS11 As String = ""
        'Dim LTS12 As String = ""
        'Dim LTS13 As String = ""
        'Dim LTS14 As String = ""
        'Dim LTS15 As String = ""
        'Dim LTS16 As String = ""
        'Dim LTS17 As String = ""
        'Dim LTS18 As String = ""
        'Dim LTS19 As String = ""
        'Dim LTS20 As String = ""
        'Dim TallaIds As String = ""
        'Dim CodigoSICY As String = ""
        Cursor = Cursors.WaitCursor
        Left = 0
        Top = 0
        Me.WindowState = FormWindowState.Maximized

        ObjBU.consultaGenerarVistaFiltrar(filtrosGenerarApartados)

        ObjBU.InsertarDatosLotesProgramas(filtrosGenerarApartados)

        '-----VERSION ANTERIOR DE INSERTAR DATOS LOTES PROGRAMAS
        'ObjBU.crearRespaldoLotesProgramasEnSAY()
        'ObjBU.SeleccionarDatosLotesProgramas(filtrosGenerarApartados)

        'contador = 0
        'For Each row As DataRow In tablaLotesAProgramas.Rows
        '    'If contador <> 0 Then
        '    '    IdPedidos += ","
        '    '    IdPartidas += ","
        '    '    IdNaves += ","
        '    '    programalotes += ","
        '    '    estatusLotes += ","
        '    '    CantLotesAs += ","
        '    '    FechaProgramas += ","
        '    '    EstatusProgramas += ","
        '    '    LTS01 += ","
        '    '    LTS02 += ","
        '    '    LTS03 += ","
        '    '    LTS04 += ","
        '    '    LTS05 += ","
        '    '    LTS06 += ","
        '    '    LTS07 += ","
        '    '    LTS08 += ","
        '    '    LTS09 += ","
        '    '    LTS10 += ","
        '    '    LTS11 += ","
        '    '    LTS12 += ","
        '    '    LTS13 += ","
        '    '    LTS14 += ","
        '    '    LTS15 += ","
        '    '    LTS16 += ","
        '    '    LTS17 += ","
        '    '    LTS18 += ","
        '    '    LTS19 += ","
        '    '    LTS20 += ","
        '    '    TallaIds += ","
        '    '    CodigoSICY += ","
        '    'End If
        '    'IdPedidos += row.Item("IdPedido").ToString()
        '    'IdPartidas += row.Item("IdPartida").ToString()
        '    'IdNaves += row.Item("IdNave").ToString()
        '    'programalotes += If(IsDBNull(row.Item("programalote")), "0", row.Item("programalote").ToString())
        '    'estatusLotes += row.Item("estatusLote").ToString()
        '    'CantLotesAs += row.Item("CantLotesA").ToString()
        '    'FechaProgramas += If(IsDBNull(row.Item("FechaPrograma").ToString()), "", row.Item("FechaPrograma").ToString())
        '    'EstatusProgramas += row.Item("EstatusPrograma").ToString()
        '    'LTS01 += row.Item("LT01").ToString()
        '    'LTS02 += row.Item("LT02").ToString()
        '    'LTS03 += row.Item("LT03").ToString()
        '    'LTS04 += row.Item("LT04").ToString()
        '    'LTS05 += row.Item("LT05").ToString()
        '    'LTS06 += row.Item("LT06").ToString()
        '    'LTS07 += row.Item("LT07").ToString()
        '    'LTS08 += row.Item("LT08").ToString()
        '    'LTS09 += row.Item("LT09").ToString()
        '    'LTS10 += row.Item("LT10").ToString()
        '    'LTS11 += row.Item("LT11").ToString()
        '    'LTS12 += row.Item("LT12").ToString()
        '    'LTS13 += row.Item("LT13").ToString()
        '    'LTS14 += row.Item("LT14").ToString()
        '    'LTS15 += row.Item("LT15").ToString()
        '    'LTS16 += row.Item("LT16").ToString()
        '    'LTS17 += row.Item("LT17").ToString()
        '    'LTS18 += row.Item("LT18").ToString()
        '    'LTS19 += row.Item("LT19").ToString()
        '    'LTS20 += row.Item("LT20").ToString()
        '    'TallaIds += row.Item("TallaId").ToString()
        '    'CodigoSICY += row.Item("CodigoSICY").ToString()
        '    contador += 1
        '    ObjBU.InsertarDatosLotesProgramas(Integer.Parse(row.Item("IdPedido").ToString()), Integer.Parse(row.Item("IdPartida").ToString()), Integer.Parse(row.Item("IdNave").ToString()), If(IsDBNull(row.Item("programalote")), 0, Integer.Parse(row.Item("programalote").ToString())), row.Item("estatusLote").ToString(), Integer.Parse(row.Item("CantLotesA").ToString()), If(IsDBNull(row.Item("FechaPrograma").ToString()), "", row.Item("FechaPrograma").ToString()), row.Item("EstatusPrograma").ToString(), Integer.Parse(row.Item("LT01").ToString()), Integer.Parse(row.Item("LT02").ToString()), Integer.Parse(row.Item("LT03").ToString()), Integer.Parse(row.Item("LT04").ToString()), Integer.Parse(row.Item("LT05").ToString()), Integer.Parse(row.Item("LT06").ToString()), Integer.Parse(row.Item("LT07").ToString()), Integer.Parse(row.Item("LT08").ToString()), Integer.Parse(row.Item("LT09").ToString()), Integer.Parse(row.Item("LT10").ToString()), Integer.Parse(row.Item("LT11").ToString()), Integer.Parse(row.Item("LT12").ToString()), Integer.Parse(row.Item("LT13").ToString()), Integer.Parse(row.Item("LT14").ToString()), Integer.Parse(row.Item("LT15").ToString()), Integer.Parse(row.Item("LT16").ToString()), Integer.Parse(row.Item("LT17").ToString()), Integer.Parse(row.Item("LT18").ToString()), Integer.Parse(row.Item("LT19").ToString()), Integer.Parse(row.Item("LT20").ToString()), row.Item("TallaId").ToString(), row.Item("CodigoSICY").ToString())
        'Next
        'ObjBU.InsertarDatosLotesProgramas(IdPedidos, IdPartidas, IdNaves, programalotes, estatusLotes, CantLotesAs, FechaProgramas, EstatusProgramas, LTS01, LTS02,
        ' LTS03, LTS04, LTS05, LTS06, LTS07, LTS08, LTS09, LTS10, LTS11, LTS12, LTS13, LTS14, LTS15, LTS16, LTS17, LTS18, LTS19, LTS20, TallaIds, CodigoSICY)
        '----- TERMINA VERSION ANTERIOR DE INSERTAR DATOS LOTES PROGRAMAS

        '--- INICIA VERSIONES ANTERIORES DE INSERTAR DATOS DE INVENTARIO INICIAL
        'ObjBU.crearInventarioInicialTemporal()
        'tablaInventarioInicial = ObjBU.seleccionarInventarioDisponibleInicial()
        'For Each row As DataRow In tablaInventarioInicial.Rows
        '    If contador <> 0 Then
        '        CodigosSICY += ","
        '        CorridasSICY += ","
        '        Corridas += ","
        '        Tallas += ","
        '        IdTallasSay += ","
        '        Pares += ","
        '        ProductosEstilos += ","
        '        Descripciones += ","
        '    End If
        '    CodigosSICY += row.Item("CodigoSICY").ToString()
        '    CorridasSICY += row.Item("IdCorridaSICY").ToString()
        '    Corridas += row.Item("corrida").ToString()
        '    Tallas += row.Item("Talla").ToString()
        '    IdTallasSay += row.Item("IdTallaSAY").ToString()
        '    Pares += row.Item("Pares").ToString()
        '    ProductosEstilos += row.Item("ProductoEstilo").ToString()
        '    Descripciones += row.Item("Descripcion").ToString()
        '    contador += 1
        '    'ObjBU.InsertarInventarioDisponibleInicial(row.Item("CodigoSICY").ToString(), row.Item("IdCorridaSICY").ToString(), row.Item("corrida").ToString(), row.Item("Talla").ToString(),
        '    '                                         Integer.Parse(row.Item("IdTallaSAY").ToString()), Integer.Parse(row.Item("Pares").ToString()), Integer.Parse(row.Item("ProductoEstilo").ToString()),
        '    '                                         row.Item("Descripcion").ToString())
        'Next
        'ObjBU.InsertarInventarioDisponibleInicial_V2(CodigosSICY, CorridasSICY, Corridas, Tallas, IdTallasSay, Pares, ProductosEstilos, Descripciones)
        '--- TERMINA VERSIONES ANTERIORES DE INSERTAR DATOS DE INVENTARIO INICIAL

        ObjBU.InsertarInventarioDisponibleInicial()

        grdDatosGenerarApartados.DataSource = ObjBU.consultaGenerarApartados(filtrosGenerarApartados)
        'ObjBU.actualizarTallasDesdeLotesA()
        gridPedidosDiseño(grdDatosGenerarApartados)
        lblTotalSeleccionados.Text = Format(grdDatosGenerarApartados.Rows.Count, "###,###,##0")
        totalPartidasSeleccionadas = grdDatosGenerarApartados.Rows.Count
        lblCantidadPartidasPorApartar.Text = Format(totalPartidasSeleccionadas, "###,###,##0")
        lblTiempoPartidasPorApartar.Text = " (" + Math.Round((totalPartidasSeleccionadas / 60), 2).ToString() + " m)"
        lblTotalTiempos.Text = "(" + Math.Round(Double.Parse(Replace(Replace(lblTiempoApartadosPorConfirmar.Text, "(", ""), " m)", "")) + Double.Parse(Replace(Replace(lblTiempoPartidasPorApartar.Text, "(", ""), " m)", "")), 2).ToString() + " m)"

        chboxSeleccionarTodo.Checked = True
        btnArriba_Click(sender, e)
        If grdDatosGenerarApartados.Rows.Count = 0 Then
            show_message("Aviso", "No hay datos para mostrar")
        Else
            dtApartadosPorConfirmar = ObjBU.obtenerTotalApartadosPorConfirmar(1)
            dtParesPorConfirmar = ObjBU.obtenerTotalParesPorConfirmar(1)
            lblCantidadPendientesPorConfirmar.Text = Format(Integer.Parse(dtApartadosPorConfirmar.Rows(0).Item("TotalApartados").ToString()), "###,###,##0")
            lblTotalParesApartadosPorConfirmar.Text = " -   " + Format(Integer.Parse(dtParesPorConfirmar.Rows(0).Item("ParesPendientes").ToString()), "###,###,##0") + " Prs."
            lblTiempoApartadosPorConfirmar.Text = " (" + (Math.Round(((Integer.Parse(dtApartadosPorConfirmar.Rows(0).Item("TotalApartados").ToString()) * 3) / 60), 2)).ToString() + " m)"
            lblCantidadPartidasPorApartar.Text = Format(Integer.Parse(grdDatosGenerarApartados.Rows.Count().ToString()), "###,###,##0")
            lblTiempoPartidasPorApartar.Text = " (" + Math.Round((grdDatosGenerarApartados.Rows.Count() / 60), 2).ToString() + " m)"
            lblTotalTiempos.Text = "(" + Math.Round((((Integer.Parse(dtApartadosPorConfirmar.Rows(0).Item("TotalApartados").ToString()) * 3) / 60) + (grdDatosGenerarApartados.Rows.Count() / 60)), 2).ToString() + " m)"
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnPrioridadClientes_Click(sender As Object, e As EventArgs) Handles btnPrioridadClientes.Click
        Dim ventanaPrioridadClientes As New PrioridadClientesApartadosForm()
        ventanaPrioridadClientes.MdiParent = Me.MdiParent
        Me.WindowState = FormWindowState.Minimized
        ventanaPrioridadClientes.Show()
    End Sub

    Private Sub GeneracionApartadosPPCP_Form_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub gridPedidosDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.Bands(0).Columns("ClienteID").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("ID").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Excluido").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("CantidadApartado").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("CantidadPorApartar").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("PrsApart").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("TiendaID").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Nave").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Programaid").Hidden = True


        grid.DisplayLayout.Bands(0).Columns("OK_renglonCompleto").Header.Caption = ""
        grid.DisplayLayout.Bands(0).Columns("OK_renglonCompleto").Style = ColumnStyle.CheckBox

        grid.DisplayLayout.Bands(0).Columns("Prio").Header.Caption = "Prio"
        grid.DisplayLayout.Bands(0).Columns("Prio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Prio").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Prio").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("PedidoSAY").Header.Caption = "Pedido SAY"
        grid.DisplayLayout.Bands(0).Columns("PedidoSAY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("PedidoSAY").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("PedidoSICY").Header.Caption = "Pedido SICY"
        grid.DisplayLayout.Bands(0).Columns("PedidoSICY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("PedidoSICY").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("OC").Header.Caption = "Orden Cliente"
        grid.DisplayLayout.Bands(0).Columns("OC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("OC").CharacterCasing = CharacterCasing.Upper
        grid.DisplayLayout.Bands(0).Columns("B3M").Header.Caption = "B3M"
        grid.DisplayLayout.Bands(0).Columns("B3M").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("B3M").CharacterCasing = CharacterCasing.Upper
        grid.DisplayLayout.Bands(0).Columns("Cliente").Header.Caption = "Cliente"
        grid.DisplayLayout.Bands(0).Columns("Cliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Cliente").CharacterCasing = CharacterCasing.Upper
        grid.DisplayLayout.Bands(0).Columns("Tienda").Header.Caption = "Tienda / Embarque / CEDIS"
        grid.DisplayLayout.Bands(0).Columns("Tienda").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Tienda").CharacterCasing = CharacterCasing.Upper
        grid.DisplayLayout.Bands(0).Columns("SProgr").Header.Caption = "SProgr"
        grid.DisplayLayout.Bands(0).Columns("SProgr").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("FechaEntregaProgramacion").Header.Caption = "FProgram"
        grid.DisplayLayout.Bands(0).Columns("FechaEntregaProgramacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("FechaEntregaCliente").Header.Caption = "FCliente"
        grid.DisplayLayout.Bands(0).Columns("FechaEntregaCliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("PartidaId").Header.Caption = "Partida"
        grid.DisplayLayout.Bands(0).Columns("PartidaId").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("PartidaId").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("Articulo").Header.Caption = "Artículo"
        grid.DisplayLayout.Bands(0).Columns("Articulo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Articulo").CharacterCasing = CharacterCasing.Upper
        grid.DisplayLayout.Bands(0).Columns("Temporada").Header.Caption = "Temporada"
        grid.DisplayLayout.Bands(0).Columns("Temporada").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Temporada").CharacterCasing = CharacterCasing.Upper
        grid.DisplayLayout.Bands(0).Columns("TipoNum").Header.Caption = "TipoN"
        grid.DisplayLayout.Bands(0).Columns("TipoNum").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("TipoNum").CharacterCasing = CharacterCasing.Upper

        grid.DisplayLayout.Bands(0).Columns("CantidadPedido").Header.Caption = "Prs Ped"
        grid.DisplayLayout.Bands(0).Columns("CantidadPedido").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("CantidadPedido").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("CantidadPedido").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("CantidadProg").Header.Caption = "Prs Progr"
        grid.DisplayLayout.Bands(0).Columns("CantidadProg").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("CantidadProg").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("CantidadProg").Format = "n0"

        grid.DisplayLayout.Bands(0).Columns("NombreNave").Header.Caption = "Nave"
        grid.DisplayLayout.Bands(0).Columns("NombreNave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("NombreNave").CharacterCasing = CharacterCasing.Upper

        grid.DisplayLayout.Bands(0).Columns("FechaPrograma").Header.Caption = "Programa"
        grid.DisplayLayout.Bands(0).Columns("FechaPrograma").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        'grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        'grid.DisplayLayout.GroupByBox.Hidden = False
        'grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"


        'grid.DisplayLayout.Bands(0).Columns("OK_renglonCompleto").Width = 20

        grid.DisplayLayout.Bands(0).Summaries.Clear()

        Dim summary1, summary2 As SummarySettings
        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("CantidadPedido"))
        summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Programar", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("CantidadProg"))
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right
        summary2.DisplayFormat = "{0:#,##0}"
        summary2.Appearance.TextHAlign = HAlign.Right


        'Dim width As Integer
        'For Each col As UltraGridColumn In grid.Rows.Band.Columns
        '    col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        '    If Not col.Hidden Then
        '        width += col.Width
        '    End If
        'Next

        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
            If renglon.Cells("B3M").Value.ToString() = "SI" Then
                renglon.Cells("B3M").Appearance.ForeColor = lblClienteBloqueado3Meses.ForeColor
                renglon.Cells("Cliente").Appearance.ForeColor = lblClienteBloqueado3Meses.ForeColor
            End If
            If renglon.Cells("Excluido").Value = 1 Then
                renglon.Appearance.BackColor = Color.LightGray
                renglon.Cells("OK_renglonCompleto").Value = 0
                renglon.Cells("OK_renglonCompleto").Hidden = True
            End If
        Next

        'If width > grid.Width Then
        '    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        'Else
        'grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'End If

        grid.DisplayLayout.Bands(0).Columns("OK_renglonCompleto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit

        grid.DisplayLayout.Bands(0).Columns("PedidoDetalleId").Hidden = True

        For Each col As UltraGridColumn In grid.DisplayLayout.Bands(0).Columns
            If col.Header.Caption = "TipoN" Or col.Header.Caption = "B3M" Or col.Header.Caption = "Prio" Then
                col.Width = 40
            Else
                If col.Header.Caption = "" Then
                    col.Width = 20
                Else
                    col.Width = col.CalculateAutoResizeWidth(PerformAutoSizeType.AllRowsInBand, True)
                End If
            End If
        Next

    End Sub


    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlDetallesPartida.Height = 216
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlDetallesPartida.Height = 28
    End Sub

    Private Sub btnActualizarDistribucion_Click(sender As Object, e As EventArgs) Handles btnActualizarDistribucion.Click
        Dim ventanaFiltros As New ParametrosApartadosPPCPForm
        ventanaFiltros.filtrosGenerarApartados = Me.filtrosGenerarApartados
        ventanaFiltros.ventanaOrigen = Me
        ventanaFiltros.StartPosition = FormStartPosition.CenterScreen
        ventanaFiltros.ShowDialog()
    End Sub

    Public Sub btnResumen_Click(sender As Object, e As EventArgs) Handles btnResumen.Click
        Dim ventanaResumenApartados As New ResumenApartadosPPCP_Form
        ventanaResumenApartados.StartPosition = FormStartPosition.CenterScreen
        ventanaResumenApartados.UltimaDistribucion = lblFechaUltimaDistribucion.Text
        ventanaResumenApartados.ApartadosGenerados = apartadosGenerados
        ventanaResumenApartados.Disponibilidad_Distribucion = If(btnActualizarDistribucion.Enabled = False And apartadosGenerados = 0, 0, 1)
        mostrarVentanaResumen(ventanaResumenApartados)
    End Sub

    Private Sub btnVerDisponibilidad_Click(sender As Object, e As EventArgs) Handles btnVerDisponibilidad.Click
        Dim objBU As New Negocios.ApartadosBU
        Dim dtTablaResultado As New DataTable()
        Dim confirmacion As New confirmarFormGrande
        Dim renglonesSeleccionados As Integer
        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
            If CBool(renglon.Cells("OK_RenglonCompleto").Value) Then
                renglonesSeleccionados += 1
            End If
        Next
        If renglonesSeleccionados > 0 Then
            'Se agrego para que el inventario no dier negativos
            objBU.Replicacion_TmpdocenasPares()

            If disponibilidadGeneradaAnteriormente = 0 Then
                confirmacion.mensaje = "El sistema realizará un respaldo del inventario disponible en Almacén para indicar la disponibilidad de pares en cada una de las partidas seleccionadas, esta acción puede tomar algunos minutos ¿Desea continuar?"

                If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    Dim detallesPedidoSeleccionados As String = String.Empty
                    Dim detallesNavesSeleccionadas As String = String.Empty
                    Dim detallesProgramasSeleccionados As String = String.Empty
                    Dim dtApartadosPorConfirmar As New DataTable
                    Dim dtParesPorConfirmar As New DataTable



                    validaDisponibilidadRealizarApartados(1)
                    If disponibleApartar = 1 Then
                        permitirIncluirExcluirPartidas = 0
                        lblHoraRespaldandoInventario.Text = "(" + DateTime.Now.ToShortDateString + " " + DateTime.Now.ToShortTimeString + ")"
                        lblHoraRespaldandoInventario.Visible = True
                        lblTextoRespaldandoInventario.Visible = True
                        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
                            If CBool(renglon.Cells("OK_renglonCompleto").Value) Then
                                'If detallesPedidoSeleccionados.Contains(renglon.Cells("PedidoDetalleId").Value.ToString()) = False And (detallesNavesSeleccionadas.Contains(renglon.Cells("Nave").Value.ToString()) = False Or detallesProgramasSeleccionados.Contains(renglon.Cells("ProgramaId").Value.ToString()) = False) Then
                                If detallesPedidoSeleccionados <> "" Then
                                    detallesPedidoSeleccionados += ","
                                    detallesNavesSeleccionadas += ","
                                    detallesProgramasSeleccionados += ","
                                End If
                                detallesPedidoSeleccionados += renglon.Cells("PedidoDetalleId").Value.ToString()
                                detallesNavesSeleccionadas += renglon.Cells("Nave").Value.ToString()
                                detallesProgramasSeleccionados += renglon.Cells("ProgramaId").Value.ToString()
                                'End If
                            End If
                        Next
                        objBU.verDisponibilidadGenerarApartado(detallesPedidoSeleccionados, detallesNavesSeleccionadas, detallesProgramasSeleccionados)
                        objBU.actualizarInventarioTotalesDisponibles()

                        'lblTextoTiempoPendientesPorConfirmar.Visible = False
                        'lblTextoTiempoPartidasApartar.Visible = False
                        'lblTiempoApartadosPorConfirmar.Visible = False
                        'lblTiempoPartidasPorApartar.Visible = False
                        'lblTotalTiempos.Visible = False
                        'lblCantidadPendientesPorConfirmar.Visible = False
                        'lblCantidadPartidasPorApartar.Visible = False
                        'lblTotalParesApartadosPorConfirmar.Visible = False

                        lblHoraRespaldandoInventario.Visible = False
                        lblTextoRespaldandoInventario.Visible = False
                        lblFechaUltimoRespaldoInventario.Text = DateTime.Now.ToShortDateString + " " + DateTime.Now.ToShortTimeString
                        lblTextoUltimoRespaldoInventario.Visible = False
                        lblFechaUltimoRespaldoInventario.Visible = False

                        objBU.actualizarApartadosPorGenerar(filtrosGenerarApartados)

                        objBU.asignarDisponibilidadSinDistribucionApartados()

                        objBU.actualizarTotalesDistribucionPartidasPorGenerarSinDistribucion()
                        dtTablaResultado = objBU.seleccionarPartidasConDistribucion(3)


                        lblFechaUltimaDistribucion.Text = DateTime.Now.ToShortDateString + " " + DateTime.Now.ToShortTimeString
                        lblTextoUltimaDistribucion.Visible = True
                        lblFechaUltimaDistribucion.Visible = True
                        chboxMostrarPartidasSinInventario.Visible = True
                        chboxMostrarPartidasExcluidas.Checked = True
                        grdDatosGenerarApartados.DataSource = Nothing
                        grdDatosGenerarApartados.DataSource = dtTablaResultado
                        gridPedidosDistribucionesDiseño(grdDatosGenerarApartados, 2)
                        'btnVerDisponibilidad.Enabled = False
                        'lblVerDisponibilidad.Enabled = False
                        chboxMostrarPartidasExcluidas.Visible = False


                        btnReordenar.Enabled = False
                        lblTextoReordenar.Enabled = False

                        chboxMostrarDistribucionPartida.Visible = False

                        btnGuardarApartado.Enabled = True
                        lblGuardarApartado.Enabled = True
                        btnGuardarCambioTotalTallas.Visible = True
                        lblTextoGuardarCambioTotalTallas.Visible = True
                        grpAcotaciones.Visible = True

                        btnResumen.Enabled = True
                        lblTextoResumen.Enabled = True

                        btnGenerarDistribucion.Enabled = True
                        lblGenerarDistribucion.Enabled = True

                        'INICIA ACTUALIZACIÓN DE CANTIDAD DE APARTADOS Y PARES POR CONFIRMAR

                        dtApartadosPorConfirmar = objBU.obtenerTotalApartadosPorConfirmar(2)
                        dtParesPorConfirmar = objBU.obtenerTotalParesPorConfirmar(2)
                        lblCantidadPendientesPorConfirmar.Text = Format(Integer.Parse(dtApartadosPorConfirmar.Rows(0).Item("TotalApartados").ToString()), "###,###,##0")
                        lblTotalParesApartadosPorConfirmar.Text = " -   " + Format(Integer.Parse(dtParesPorConfirmar.Rows(0).Item("ParesPendientes").ToString()), "###,###,##0") + " Prs."
                        lblTiempoApartadosPorConfirmar.Text = " (" + (Math.Round(((Integer.Parse(dtApartadosPorConfirmar.Rows(0).Item("TotalApartados").ToString()) * 3) / 60), 2)).ToString() + " m)"
                        lblCantidadPartidasPorApartar.Text = Format(Integer.Parse(Replace(lblTotalSeleccionados.Text, ",", "")), "###,###,##0")
                        lblTiempoPartidasPorApartar.Text = " (" + Math.Round((grdDatosGenerarApartados.Rows.Count() / 60), 2).ToString() + " m)"
                        lblTotalTiempos.Text = "(" + Math.Round((((Integer.Parse(dtApartadosPorConfirmar.Rows(0).Item("TotalApartados").ToString()) * 3) / 60) + (grdDatosGenerarApartados.Rows.Count() / 60)), 2).ToString() + " m)"

                        'TERMINA ACTUALIZACIÓN DE CANTIDAD DE APARTADOS Y PARES POR CONFIRMAR

                        disponibilidadGeneradaAnteriormente = 1
                    End If
                End If
            ElseIf disponibilidadGeneradaAnteriormente = 1 Then
                confirmacion.mensaje = "El sistema indicará la disponibilidad de pares en cada una de las partidas modificadas, esta acción puede tomar algunos minutos ¿Desea continuar?"
                If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    validaDisponibilidadRealizarApartados(1)
                    Dim dtApartadosPorConfirmar As New DataTable
                    Dim dtParesPorConfirmar As New DataTable
                    If disponibleApartar = 1 Then

                        objBU.reasignarDisponibilidadSinDistribucionApartados()

                        objBU.actualizarTotalesDistribucionPartidasPorGenerarSinDistribucion()
                        dtTablaResultado = objBU.seleccionarPartidasConDistribucion(4)

                        grdDatosGenerarApartados.DataSource = Nothing
                        grdDatosGenerarApartados.DataSource = dtTablaResultado
                        gridPedidosDistribucionesDiseño(grdDatosGenerarApartados, 2)

                        'INICIA ACTUALIZACIÓN DE CANTIDAD DE APARTADOS Y PARES POR CONFIRMAR

                        dtApartadosPorConfirmar = objBU.obtenerTotalApartadosPorConfirmar(2)
                        dtParesPorConfirmar = objBU.obtenerTotalParesPorConfirmar(2)
                        lblCantidadPendientesPorConfirmar.Text = Format(Integer.Parse(dtApartadosPorConfirmar.Rows(0).Item("TotalApartados").ToString()), "###,###,##0")
                        lblTotalParesApartadosPorConfirmar.Text = " -   " + Format(Integer.Parse(dtParesPorConfirmar.Rows(0).Item("ParesPendientes").ToString()), "###,###,##0") + " Prs."
                        lblTiempoApartadosPorConfirmar.Text = " (" + (Math.Round(((Integer.Parse(dtApartadosPorConfirmar.Rows(0).Item("TotalApartados").ToString()) * 3) / 60), 2)).ToString() + " m)"
                        lblCantidadPartidasPorApartar.Text = Format(Integer.Parse(Replace(lblTotalSeleccionados.Text, ",", "")), "###,###,##0")
                        lblTiempoPartidasPorApartar.Text = " (" + Math.Round((grdDatosGenerarApartados.Rows.Count() / 60), 2).ToString() + " m)"
                        lblTotalTiempos.Text = "(" + Math.Round((((Integer.Parse(dtApartadosPorConfirmar.Rows(0).Item("TotalApartados").ToString()) * 3) / 60) + (grdDatosGenerarApartados.Rows.Count() / 60)), 2).ToString() + " m)"

                        'TERMINA ACTUALIZACIÓN DE CANTIDAD DE APARTADOS Y PARES POR CONFIRMAR

                    End If
                End If
            End If
        Else
            show_message("Advertencia", "Debe seleccionar al menos una partida para ver disponibilidad")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub validaDisponibilidadRealizarApartados(ByVal estatusGenerandoApartado As Int32)
        'estatusGenerandoApartado -- 1 = Entrando, 2 salidendo
        Dim dtResultado As New DataTable
        Dim objBu As New Ventas.Negocios.ApartadosBU
        Dim mensajeDisponibilidad As String = String.Empty

        Dim usuario As New Entidades.Usuarios
        Dim idUsuario As Int32 = 0
        usuario = Entidades.SesionUsuario.UsuarioSesion
        If Not usuario Is Nothing Then
            idUsuario = usuario.PUserUsuarioid
            'DESCOMENTAR PARA VERIFICAR LA DISPONIBILIDAD DEL MODULO PARA APARTAR
            dtResultado = objBu.verificaDisponibilidadApartar(estatusGenerandoApartado, usuario.PUserUsername, "PPCP")

            If Not dtResultado Is Nothing Then
                If dtResultado.Rows.Count > 0 Then

                    For i As Int32 = 0 To dtResultado.Rows.Count - 1
                        mensajeDisponibilidad = dtResultado.Rows(i).Item("MensajeRespuesta").ToString()
                    Next

                Else
                End If
            Else
            End If

        End If

        If mensajeDisponibilidad <> "" And mensajeDisponibilidad <> "Solo es posible iniciar una sesión de apartados a la vez, verifique por favor." Then
            mensajeDisponibilidad = Replace(mensajeDisponibilidad, "Por favor ", " Para realizar esta acción ")
            show_message("Advertencia", Replace(mensajeDisponibilidad, " realizar apartados para poder completar esta acción.", " generar apartados."))
            disponibleApartar = 0
        Else
            disponibleApartar = 1
        End If

    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then

            Dim mensajeAdvertencia As New AdvertenciaFormGrande
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

    Private Sub GeneracionApartadosPPCP_Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'validaDisponibilidadRealizarApartados(0)
    End Sub

    Private Sub grdDatosGenerarApartados_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdDatosGenerarApartados.SelectionDrag
        If grdDatosGenerarApartados.Selected.Rows.Count() > 0 Then
            IndiceInicioRenglonArrastrado = grdDatosGenerarApartados.Selected.Rows(0).Index
            grdDatosGenerarApartados.DoDragDrop(grdDatosGenerarApartados.Selected.Rows, DragDropEffects.Move)
        End If
    End Sub

    Private Sub grdDatosGenerarApartados_DragDrop(sender As Object, e As DragEventArgs) Handles grdDatosGenerarApartados.DragDrop
        Try
            Dim dropIndex As Integer
            Dim pedidoDetallesId As String = ""
            Dim NavesId As String = ""
            Dim ProgramasId As String = ""
            Dim objBu As New Negocios.ApartadosBU

            'Get the position on the grid where the dragged row(s) are to be dropped. 
            'get the grid coordinates of the row (the drop zone) 
            Dim uieOver As UIElement = grdDatosGenerarApartados.DisplayLayout.UIElement.ElementFromPoint(grdDatosGenerarApartados.PointToClient(New Point(e.X, e.Y)))

            'get the row that is the drop zone/or where the dragged row is to be dropped 
            Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

            If ugrOver IsNot Nothing Then
                dropIndex = ugrOver.Index    'index/position of drop zone in grid 

                'get the dragged row(s)which are to be dragged to another position in the grid 
                Dim SelRows As SelectedRowsCollection = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)
                'get the count of selected rows and drop each starting at the dropIndex 
                For Each aRow As UltraGridRow In SelRows
                    'move the selected row(s) to the drop zone 
                    If dropIndex >= 0 And dropIndex <> aRow.Index And dropIndex < grdDatosGenerarApartados.Rows.Count - 1 Then
                        IndiceFinRenglonArrastrado = dropIndex
                        grdDatosGenerarApartados.Rows.Move(aRow, dropIndex)
                        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
                            If pedidoDetallesId = "" Then
                                pedidoDetallesId += renglon.Cells("PedidoDetalleId").Value.ToString()
                            Else
                                pedidoDetallesId += "," + renglon.Cells("PedidoDetalleId").Value.ToString
                            End If
                            If NavesId = "" Then
                                NavesId += renglon.Cells("Nave").Value.ToString()
                            Else
                                NavesId += "," + renglon.Cells("Nave").Value.ToString
                            End If
                            If ProgramasId = "" Then
                                ProgramasId += renglon.Cells("ProgramaId").Value.ToString()
                            Else
                                ProgramasId += "," + renglon.Cells("ProgramaId").Value.ToString
                            End If
                            'If renglon.Cells("OK_renglonCompleto").Hidden = False Then
                            'If renglon.Index >= dropIndex And renglon.Index < grdDatosGenerarApartados.Rows.Count - 1 Then
                            If (renglon.Index >= IndiceFinRenglonArrastrado And renglon.Index <= IndiceInicioRenglonArrastrado) Or (renglon.Index >= IndiceInicioRenglonArrastrado And renglon.Index <= IndiceFinRenglonArrastrado) Then
                                renglon.Cells("M").Value = "Or"
                                renglon.Cells("M").Appearance.BackColor = lblModificacionOrden.BackColor
                            End If
                            'End If
                        Next
                        objBu.ModificacionesPartidas(pedidoDetallesId, NavesId, ProgramasId, 1)
                        IndiceFinRenglonArrastrado = 0
                        IndiceInicioRenglonArrastrado = 0
                    End If
                Next

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdDatosGenerarApartados_DragOver(sender As Object, e As DragEventArgs) Handles grdDatosGenerarApartados.DragOver
        e.Effect = DragDropEffects.Move
        Dim grid As UltraGrid = TryCast(sender, UltraGrid)
        Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

        If pointInGridCoords.Y < 20 Then
            'Scroll up
            Me.grdDatosGenerarApartados.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
        ElseIf pointInGridCoords.Y > grid.Height - 20 Then
            'Scroll down
            Me.grdDatosGenerarApartados.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
        End If
    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Dim Seleccionados As Integer = 0
        Dim listaColumnas As New List(Of String)

        For Each col As UltraGridColumn In grdDatosGenerarApartados.DisplayLayout.Bands(0).Columns
            listaColumnas.Add(col.Header.Caption)
        Next

        If grdDatosGenerarApartados.Rows.Count > 0 Then
            If chboxSeleccionarTodo.Checked Then
                If permitirIncluirExcluirPartidas = 1 Then
                    For Each row As UltraGridRow In grdDatosGenerarApartados.Rows.GetFilteredInNonGroupByRows
                        If row.Cells("Excluido").Value = 0 Then
                            row.Cells("OK_renglonCompleto").Value = True
                            Seleccionados += 1
                        End If
                    Next
                Else
                    If listaColumnas.Contains("Norm") And listaColumnas.Contains("Norm") And listaColumnas.Contains("Punt") And listaColumnas.Contains("ANorm") And listaColumnas.Contains("APunt") And listaColumnas.Contains("PrsDest") Then
                        For Each row As UltraGridRow In grdDatosGenerarApartados.Rows.GetFilteredInNonGroupByRows
                            If row.Cells("OK_renglonCompleto").Hidden = False Then
                                If row.Cells("PrsApart").Value > 0 Or row.Cells("Norm").Value > 0 Or row.Cells("Punt").Value > 0 Or row.Cells("ANorm").Value > 0 Or row.Cells("APunt").Value > 0 Or row.Cells("PrsDest").Value > 0 Then
                                    row.Cells("OK_renglonCompleto").Value = True
                                    If chboxSeleccionarTodoParesDestallados.Enabled = True Then
                                        chboxSeleccionarTodoParesDestallados.Checked = True
                                    End If
                                    If chboxSeleccionarTodoAtadosPuntoDestallar.Enabled = True Then
                                        chboxSeleccionarTodoAtadosPuntoDestallar.Checked = True
                                    End If
                                    If chboxSeleccionarTodoAtadosNormalesCompletos.Enabled = True Then
                                        chboxSeleccionarTodoAtadosNormalesCompletos.Checked = True
                                    End If
                                    If chboxSeleccionarTodoAtadosPuntoCompletos.Enabled = True Then
                                        chboxSeleccionarTodoAtadosPuntoCompletos.Checked = True
                                    End If
                                    If chboxSeleccionarTodoAtadosNormalesDestallar.Enabled = True Then
                                        chboxSeleccionarTodoAtadosNormalesDestallar.Checked = True
                                    End If
                                    Seleccionados += 1
                                End If
                            End If
                        Next
                    Else
                        For Each row As UltraGridRow In grdDatosGenerarApartados.Rows.GetFilteredInNonGroupByRows
                            If row.Cells("OK_renglonCompleto").Hidden = False Then
                                row.Cells("OK_renglonCompleto").Value = True
                                Seleccionados += 1
                            End If
                        Next
                    End If

                End If
            Else
                Seleccionados = Integer.Parse(Replace(lblTotalSeleccionados.Text, ",", ""))
                If permitirIncluirExcluirPartidas = 1 Then
                    For Each row As UltraGridRow In grdDatosGenerarApartados.Rows.GetFilteredInNonGroupByRows
                        If row.Cells("Excluido").Value = 0 Then
                            If CBool(row.Cells("OK_renglonCompleto").Value) Then
                                row.Cells("OK_renglonCompleto").Value = False
                                Seleccionados -= 1
                            End If
                        End If
                    Next
                Else
                    If listaColumnas.Contains("Norm") And listaColumnas.Contains("Norm") And listaColumnas.Contains("Punt") And listaColumnas.Contains("ANorm") And listaColumnas.Contains("APunt") And listaColumnas.Contains("PrsDest") Then
                        For Each row As UltraGridRow In grdDatosGenerarApartados.Rows.GetFilteredInNonGroupByRows
                            If row.Cells("OK_renglonCompleto").Hidden = False Then
                                If row.Cells("PrsApart").Value > 0 Or row.Cells("Norm").Value > 0 Or row.Cells("Punt").Value > 0 Or row.Cells("ANorm").Value > 0 Or row.Cells("APunt").Value > 0 Or row.Cells("PrsDest").Value > 0 Then
                                    If CBool(row.Cells("OK_renglonCompleto").Value) Then
                                        row.Cells("OK_renglonCompleto").Value = False
                                        If chboxSeleccionarTodoParesDestallados.Enabled = True Then
                                            chboxSeleccionarTodoParesDestallados.Checked = False
                                        End If
                                        If chboxSeleccionarTodoAtadosPuntoDestallar.Enabled = True Then
                                            chboxSeleccionarTodoAtadosPuntoDestallar.Checked = False
                                        End If
                                        If chboxSeleccionarTodoAtadosNormalesCompletos.Enabled = True Then
                                            chboxSeleccionarTodoAtadosNormalesCompletos.Checked = False
                                        End If
                                        If chboxSeleccionarTodoAtadosPuntoCompletos.Enabled = True Then
                                            chboxSeleccionarTodoAtadosPuntoCompletos.Checked = False
                                        End If
                                        If chboxSeleccionarTodoAtadosNormalesDestallar.Enabled = True Then
                                            chboxSeleccionarTodoAtadosNormalesDestallar.Checked = False
                                        End If
                                        Seleccionados -= 1
                                    End If
                                End If
                            End If
                        Next
                    Else
                        For Each row As UltraGridRow In grdDatosGenerarApartados.Rows.GetFilteredInNonGroupByRows
                            If row.Cells("OK_renglonCompleto").Hidden = False Then
                                row.Cells("OK_renglonCompleto").Value = False
                                Seleccionados -= 1
                            End If
                        Next
                    End If
                End If
            End If
            lblTotalSeleccionados.Text = Format(Seleccionados, "###,###,##0")
            totalPartidasSeleccionadas = Seleccionados
            lblCantidadPartidasPorApartar.Text = Format(Seleccionados, "###,###,##0")
            lblTiempoPartidasPorApartar.Text = " (" + Math.Round((Seleccionados / 60), 2).ToString() + " m)"
            lblTotalTiempos.Text = "(" + Math.Round(Double.Parse(Replace(Replace(lblTiempoApartadosPorConfirmar.Text, "(", ""), " m)", "")) + Double.Parse(Replace(Replace(lblTiempoPartidasPorApartar.Text, "(", ""), " m)", "")), 2).ToString() + " m)"


            Cursor = Cursors.Default
        Else
            chboxSeleccionarTodo.Checked = False
        End If
    End Sub

    Private Sub ContarRegistrosSeleccionados()
        Try
            Dim Seleccionados As Integer = 0
            For Each row As UltraGridRow In grdDatosGenerarApartados.Rows.GetFilteredInNonGroupByRows
                If CBool(row.Cells("OK_renglonCompleto").Value) And row.Cells("OK_renglonCompleto").Hidden = False Then
                    Seleccionados += 1
                End If
            Next
            lblTotalSeleccionados.Text = Format(Seleccionados, "###,###,##0")
            totalPartidasSeleccionadas = Seleccionados

            lblCantidadPartidasPorApartar.Text = Format(Seleccionados, "###,###,##0")
            lblTiempoPartidasPorApartar.Text = " (" + Math.Round((Seleccionados / 60), 2).ToString() + " m)"
            lblTotalTiempos.Text = "(" + Math.Round(Double.Parse(Replace(Replace(lblTiempoApartadosPorConfirmar.Text, "(", ""), " m)", "")) + Double.Parse(Replace(Replace(lblTiempoPartidasPorApartar.Text, "(", ""), " m)", "")), 2).ToString() + " m)"

        Catch ex As Exception

        End Try
    End Sub


    'Private Sub grdDatosGenerarApartados_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdDatosGenerarApartados.AfterCellUpdate
    '    ContarRegistrosSeleccionados()
    'End Sub

    'Private Sub grdDatosGenerarApartados_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles grdDatosGenerarApartados.AfterRowFilterChanged
    '    ContarRegistrosSeleccionados()
    'End Sub

    Private Sub grdDatosGenerarApartados_CellChange(sender As Object, e As CellEventArgs) Handles grdDatosGenerarApartados.CellChange
        Try
            Dim Seleccionados As Integer = 0
            Dim objBu As New Negocios.ApartadosBU
            If e.Cell.Row.Index >= 0 Then
                If e.Cell.Column.ToString = "OK_renglonCompleto" And e.Cell.Hidden = False Then
                    If CBool(e.Cell.Value) Then
                        grdDatosGenerarApartados.ActiveRow.Cells("OK_renglonCompleto").Value = False
                    Else
                        grdDatosGenerarApartados.ActiveRow.Cells("OK_renglonCompleto").Value = True
                    End If
                    For Each row As UltraGridRow In grdDatosGenerarApartados.Rows.GetFilteredInNonGroupByRows
                        If CBool(row.Cells("OK_renglonCompleto").Value) And row.Cells("OK_renglonCompleto").Hidden = False Then
                            Seleccionados += 1
                        End If
                    Next
                    lblTotalSeleccionados.Text = Format(Seleccionados, "###,###,##0")
                    totalPartidasSeleccionadas = Seleccionados

                    lblCantidadPartidasPorApartar.Text = Format(Seleccionados, "###,###,##0")
                    lblTiempoPartidasPorApartar.Text = " (" + Math.Round((Seleccionados / 60), 2).ToString() + " m)"
                    lblTotalTiempos.Text = "(" + Math.Round(Double.Parse(Replace(Replace(lblTiempoApartadosPorConfirmar.Text, "(", ""), " m)", "")) + Double.Parse(Replace(Replace(lblTiempoPartidasPorApartar.Text, "(", ""), " m)", "")), 2).ToString() + " m)"

                End If
                If e.Cell.Column.ToString = "OK_Destallados" Then
                    If CBool(e.Cell.Value) Then
                        grdDatosGenerarApartados.ActiveRow.Cells("OK_Destallados").Value = False
                        If grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value > 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Appearance.ForeColor = Color.Red
                        End If
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsDest").Value - grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value - grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value - grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value + grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value - grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value

                        If grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value > 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "X"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                            objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 2)
                        Else
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                            objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 3)
                        End If

                    Else
                        grdDatosGenerarApartados.ActiveRow.Cells("OK_Destallados").Value = True
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Appearance.ForeColor = Nothing
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsDest").Value + grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value + grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value + grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value - grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value + grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                        If (grdDatosGenerarApartados.ActiveRow.Cells("OK_Normales").Hidden = False And grdDatosGenerarApartados.ActiveRow.Cells("OK_Normales").Value = 1 Or grdDatosGenerarApartados.ActiveRow.Cells("OK_Normales").Hidden = True) And
                            (grdDatosGenerarApartados.ActiveRow.Cells("OK_Punto").Hidden = False And grdDatosGenerarApartados.ActiveRow.Cells("OK_Punto").Value = 1 Or grdDatosGenerarApartados.ActiveRow.Cells("OK_Punto").Hidden = True) And
                            (grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosNormales").Hidden = False And grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosNormales").Value = 1 Or grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                            (grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosPunto").Hidden = False And grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosPunto").Value = 1 Or grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                            If grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "X" Then
                                grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                                grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                                objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 3)
                            End If
                        End If
                        If grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value = 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "X"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                            objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 2)
                        ElseIf grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value > 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                            objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 3)
                        End If
                    End If
                End If
                If e.Cell.Column.ToString = "OK_Normales" Then
                    If CBool(e.Cell.Value) Then
                        grdDatosGenerarApartados.ActiveRow.Cells("OK_Normales").Value = False
                        If grdDatosGenerarApartados.ActiveRow.Cells("Norm").Value > 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("Norm").Appearance.ForeColor = Color.Red
                        End If
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Norm").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Norm").Value - grdDatosGenerarApartados.ActiveRow.Cells("Norm").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("NormPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("NormPares").Value - grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value - grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value - grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value + grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value - grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                        If grdDatosGenerarApartados.ActiveRow.Cells("Norm").Value > 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "X"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                            objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 2)
                        Else
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                            objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 3)
                        End If
                    Else
                        grdDatosGenerarApartados.ActiveRow.Cells("OK_Normales").Value = True
                        grdDatosGenerarApartados.ActiveRow.Cells("Norm").Appearance.ForeColor = Nothing
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Norm").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Norm").Value + grdDatosGenerarApartados.ActiveRow.Cells("Norm").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("NormPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("NormPares").Value + grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value + grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value + grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value - grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value + grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                        If (grdDatosGenerarApartados.ActiveRow.Cells("OK_Destallados").Hidden = False And grdDatosGenerarApartados.ActiveRow.Cells("OK_Destallados").Value = 1 Or grdDatosGenerarApartados.ActiveRow.Cells("OK_Destallados").Hidden = True) And
                            (grdDatosGenerarApartados.ActiveRow.Cells("OK_Punto").Hidden = False And grdDatosGenerarApartados.ActiveRow.Cells("OK_Punto").Value = 1 Or grdDatosGenerarApartados.ActiveRow.Cells("OK_Punto").Hidden = True) And
                            (grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosNormales").Hidden = False And grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosNormales").Value = 1 Or grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                            (grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosPunto").Hidden = False And grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosPunto").Value = 1 Or grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                            If grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "X" Then
                                grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                                grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                                objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 3)
                            End If
                        End If
                        If grdDatosGenerarApartados.ActiveRow.Cells("Norm").Value = 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "X"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                            objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 2)
                        ElseIf grdDatosGenerarApartados.ActiveRow.Cells("Norm").Value > 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                            objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 3)
                        End If
                    End If
                End If
                If e.Cell.Column.ToString = "OK_Punto" Then
                    If CBool(e.Cell.Value) Then
                        grdDatosGenerarApartados.ActiveRow.Cells("OK_Punto").Value = False
                        If grdDatosGenerarApartados.ActiveRow.Cells("Punt").Value > 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("Punt").Appearance.ForeColor = Color.Red
                        End If
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Punt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Punt").Value - grdDatosGenerarApartados.ActiveRow.Cells("Punt").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PuntPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PuntPares").Value - grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value - grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value - grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value + grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value - grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                        If grdDatosGenerarApartados.ActiveRow.Cells("Punt").Value > 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "X"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                            objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 2)
                        Else
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                            objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 3)
                        End If
                    Else
                        grdDatosGenerarApartados.ActiveRow.Cells("OK_Punto").Value = True
                        grdDatosGenerarApartados.ActiveRow.Cells("Punt").Appearance.ForeColor = Nothing
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Punt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Punt").Value + grdDatosGenerarApartados.ActiveRow.Cells("Punt").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PuntPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PuntPares").Value + grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value + grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value + grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value - grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value + grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                        If (grdDatosGenerarApartados.ActiveRow.Cells("OK_Normales").Hidden = False And grdDatosGenerarApartados.ActiveRow.Cells("OK_Normales").Value = 1 Or grdDatosGenerarApartados.ActiveRow.Cells("OK_Normales").Hidden = True) And
                            (grdDatosGenerarApartados.ActiveRow.Cells("OK_Destallados").Hidden = False And grdDatosGenerarApartados.ActiveRow.Cells("OK_Destallados").Value = 1 Or grdDatosGenerarApartados.ActiveRow.Cells("OK_Destallados").Hidden = True) And
                            (grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosNormales").Hidden = False And grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosNormales").Value = 1 Or grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                            (grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosPunto").Hidden = False And grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosPunto").Value = 1 Or grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                            If grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "X" Then
                                grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                                grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                                objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 3)
                            End If
                        End If
                        If grdDatosGenerarApartados.ActiveRow.Cells("Punt").Value = 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "X"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                            objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 2)
                        ElseIf grdDatosGenerarApartados.ActiveRow.Cells("Punt").Value > 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                            objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 3)
                        End If
                    End If
                End If
                If e.Cell.Column.ToString = "OK_AtadosDestalladosNormales" Then
                    If CBool(e.Cell.Value) Then
                        grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosNormales").Value = False
                        If grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Value > 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Appearance.ForeColor = Color.Red
                        End If
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANorm").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANorm").Value - grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANormPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANormPares").Value - grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("ATotal").Value = grdDatosGenerarApartados.ActiveRow.Cells("ATotal").Value - grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsTotalAtDest").Value - grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value - grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value + grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value - grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value - grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Value

                        If grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Value > 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "X"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                            objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 2)
                        Else
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                            objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 3)
                        End If
                    Else
                        grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosNormales").Value = True
                        grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Appearance.ForeColor = Nothing
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANorm").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANorm").Value + grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANormPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANormPares").Value + grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("ATotal").Value = grdDatosGenerarApartados.ActiveRow.Cells("ATotal").Value + grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsTotalAtDest").Value + grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value + grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value - grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value + grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value + grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Value

                        If (grdDatosGenerarApartados.ActiveRow.Cells("OK_Normales").Hidden = False And grdDatosGenerarApartados.ActiveRow.Cells("OK_Normales").Value = 1 Or grdDatosGenerarApartados.ActiveRow.Cells("OK_Normales").Hidden = True) And
                            (grdDatosGenerarApartados.ActiveRow.Cells("OK_Punto").Hidden = False And grdDatosGenerarApartados.ActiveRow.Cells("OK_Punto").Value = 1 Or grdDatosGenerarApartados.ActiveRow.Cells("OK_Punto").Hidden = True) And
                            (grdDatosGenerarApartados.ActiveRow.Cells("OK_Destallados").Hidden = False And grdDatosGenerarApartados.ActiveRow.Cells("OK_Destallados").Value = 1 Or grdDatosGenerarApartados.ActiveRow.Cells("OK_Destallados").Hidden = True) And
                            (grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosPunto").Hidden = False And grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosPunto").Value = 1 Or grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                            If grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "X" And grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Value > 0 Then
                                grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                                grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                                objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 3)
                            End If
                        End If
                        If grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Value = 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "X"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                            objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 2)
                        ElseIf grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Value > 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                            objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 3)
                        End If
                    End If
                End If
                If e.Cell.Column.ToString = "OK_AtadosDestalladosPunto" Then
                    If CBool(e.Cell.Value) Then
                        grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosPunto").Value = False
                        If grdDatosGenerarApartados.ActiveRow.Cells("APunt").Value > 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("APunt").Appearance.ForeColor = Color.Red
                        End If
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APunt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APunt").Value - grdDatosGenerarApartados.ActiveRow.Cells("APunt").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APuntPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APuntPares").Value - grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("ATotal").Value = grdDatosGenerarApartados.ActiveRow.Cells("ATotal").Value - grdDatosGenerarApartados.ActiveRow.Cells("APunt").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsTotalAtDest").Value - grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value - grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value + grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value - grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value - grdDatosGenerarApartados.ActiveRow.Cells("APunt").Value

                        If grdDatosGenerarApartados.ActiveRow.Cells("APunt").Value > 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "X"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                            objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 2)
                        Else
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                            objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 3)
                        End If

                    Else
                        grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosPunto").Value = True
                        grdDatosGenerarApartados.ActiveRow.Cells("APunt").Appearance.ForeColor = Nothing
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APunt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APunt").Value + grdDatosGenerarApartados.ActiveRow.Cells("APunt").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APuntPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APuntPares").Value + grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("ATotal").Value = grdDatosGenerarApartados.ActiveRow.Cells("ATotal").Value + grdDatosGenerarApartados.ActiveRow.Cells("APunt").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsTotalAtDest").Value + grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value + grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                        grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value - grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value + grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value + grdDatosGenerarApartados.ActiveRow.Cells("APunt").Value

                        If (grdDatosGenerarApartados.ActiveRow.Cells("OK_Normales").Hidden = False And grdDatosGenerarApartados.ActiveRow.Cells("OK_Normales").Value = 1 Or grdDatosGenerarApartados.ActiveRow.Cells("OK_Normales").Hidden = True) And
                            (grdDatosGenerarApartados.ActiveRow.Cells("OK_Punto").Hidden = False And grdDatosGenerarApartados.ActiveRow.Cells("OK_Punto").Value = 1 Or grdDatosGenerarApartados.ActiveRow.Cells("OK_Punto").Hidden = True) And
                            (grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosNormales").Hidden = False And grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosNormales").Value = 1 Or grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                            (grdDatosGenerarApartados.ActiveRow.Cells("OK_Destallados").Hidden = False And grdDatosGenerarApartados.ActiveRow.Cells("OK_Destallados").Value = 1 Or grdDatosGenerarApartados.ActiveRow.Cells("OK_Destallados").Hidden = True) Then
                            If grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "X" Then
                                grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                                grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                                objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 3)
                            End If
                        End If
                        If grdDatosGenerarApartados.ActiveRow.Cells("APunt").Value = 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "X"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                            objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 2)
                        ElseIf grdDatosGenerarApartados.ActiveRow.Cells("APunt").Value > 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                            objBu.ModificacionesPartidas(grdDatosGenerarApartados.ActiveRow.Cells("PedidoDetalleId").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("Nave").Value.ToString(), grdDatosGenerarApartados.ActiveRow.Cells("ProgramaId").Value.ToString(), 3)
                        End If
                    End If
                End If


                If e.Cell.Column.ToString = "OK_renglonCompleto" And e.Cell.Hidden = False Then

                    If CBool(e.Cell.Value) = False Then
                        If grdDatosGenerarApartados.Rows(e.Cell.Row.Index).Cells("OK_Destallados").Hidden = False And CBool(grdDatosGenerarApartados.Rows(e.Cell.Row.Index).Cells("OK_Destallados").Value) Then
                            grdDatosGenerarApartados.ActiveRow.Cells("OK_Destallados").Value = False
                            If grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value > 0 Then
                                grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Appearance.ForeColor = Color.Red
                            End If
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsDest").Value - grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value - grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value - grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value + grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value - grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                        End If
                        If grdDatosGenerarApartados.Rows(e.Cell.Row.Index).Cells("OK_Normales").Hidden = False And CBool(grdDatosGenerarApartados.Rows(e.Cell.Row.Index).Cells("OK_Normales").Value) Then
                            grdDatosGenerarApartados.ActiveRow.Cells("OK_Normales").Value = False
                            If grdDatosGenerarApartados.ActiveRow.Cells("Norm").Value > 0 Then
                                grdDatosGenerarApartados.ActiveRow.Cells("Norm").Appearance.ForeColor = Color.Red
                            End If
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Norm").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Norm").Value - grdDatosGenerarApartados.ActiveRow.Cells("Norm").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("NormPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("NormPares").Value - grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value - grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value - grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value + grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value - grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                        End If
                        If grdDatosGenerarApartados.Rows(e.Cell.Row.Index).Cells("OK_Punto").Hidden = False And CBool(grdDatosGenerarApartados.Rows(e.Cell.Row.Index).Cells("OK_Punto").Value) Then
                            grdDatosGenerarApartados.ActiveRow.Cells("OK_Punto").Value = False
                            If grdDatosGenerarApartados.ActiveRow.Cells("Punt").Value > 0 Then
                                grdDatosGenerarApartados.ActiveRow.Cells("Punt").Appearance.ForeColor = Color.Red
                            End If
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Punt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Punt").Value - grdDatosGenerarApartados.ActiveRow.Cells("Punt").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PuntPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PuntPares").Value - grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value - grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value - grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value + grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value - grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                        End If
                        If grdDatosGenerarApartados.Rows(e.Cell.Row.Index).Cells("OK_AtadosDestalladosNormales").Hidden = False And CBool(grdDatosGenerarApartados.Rows(e.Cell.Row.Index).Cells("OK_AtadosDestalladosNormales").Value) Then
                            grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosNormales").Value = False
                            If grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Value > 0 Then
                                grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Appearance.ForeColor = Color.Red
                            End If
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANorm").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANorm").Value - grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANormPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANormPares").Value - grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("ATotal").Value = grdDatosGenerarApartados.ActiveRow.Cells("ATotal").Value - grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsTotalAtDest").Value - grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value - grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value + grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value - grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value - grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                        End If
                        If grdDatosGenerarApartados.Rows(e.Cell.Row.Index).Cells("OK_AtadosDestalladosPunto").Hidden = False And CBool(grdDatosGenerarApartados.Rows(e.Cell.Row.Index).Cells("OK_AtadosDestalladosPunto").Value) Then
                            grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosPunto").Value = False
                            If grdDatosGenerarApartados.ActiveRow.Cells("APunt").Value > 0 Then
                                grdDatosGenerarApartados.ActiveRow.Cells("APunt").Appearance.ForeColor = Color.Red
                            End If
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APunt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APunt").Value - grdDatosGenerarApartados.ActiveRow.Cells("APunt").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APuntPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APuntPares").Value - grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("ATotal").Value = grdDatosGenerarApartados.ActiveRow.Cells("ATotal").Value - grdDatosGenerarApartados.ActiveRow.Cells("APunt").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsTotalAtDest").Value - grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value - grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value + grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value - grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value - grdDatosGenerarApartados.ActiveRow.Cells("APunt").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                        End If

                        grdDatosGenerarApartados.ActiveRow.Cells("OK_Destallados").Hidden = True
                        grdDatosGenerarApartados.ActiveRow.Cells("OK_Normales").Hidden = True
                        grdDatosGenerarApartados.ActiveRow.Cells("OK_Punto").Hidden = True
                        grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosNormales").Hidden = True
                        grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosPunto").Hidden = True

                    Else

                        grdDatosGenerarApartados.ActiveRow.Cells("OK_Destallados").Hidden = False
                        grdDatosGenerarApartados.ActiveRow.Cells("OK_Normales").Hidden = False
                        grdDatosGenerarApartados.ActiveRow.Cells("OK_Punto").Hidden = False
                        grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosNormales").Hidden = False
                        grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosPunto").Hidden = False

                        If grdDatosGenerarApartados.Rows(e.Cell.Row.Index).Cells("OK_Destallados").Hidden = False And CBool(grdDatosGenerarApartados.Rows(e.Cell.Row.Index).Cells("OK_Destallados").Value) = False And grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value > 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("OK_Destallados").Value = True
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Appearance.ForeColor = Nothing
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsDest").Value + grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value + grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value + grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value - grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value + grdDatosGenerarApartados.ActiveRow.Cells("PrsDest").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                        End If
                        If grdDatosGenerarApartados.Rows(e.Cell.Row.Index).Cells("OK_Normales").Hidden = False And CBool(grdDatosGenerarApartados.Rows(e.Cell.Row.Index).Cells("OK_Normales").Value) = False And grdDatosGenerarApartados.ActiveRow.Cells("Norm").Value > 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("OK_Normales").Value = True
                            grdDatosGenerarApartados.ActiveRow.Cells("Norm").Appearance.ForeColor = Nothing
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Norm").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Norm").Value + grdDatosGenerarApartados.ActiveRow.Cells("Norm").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("NormPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("NormPares").Value + grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value + grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value + grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value - grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value + grdDatosGenerarApartados.ActiveRow.Cells("NormPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                        End If
                        If grdDatosGenerarApartados.Rows(e.Cell.Row.Index).Cells("OK_Punto").Hidden = False And CBool(grdDatosGenerarApartados.Rows(e.Cell.Row.Index).Cells("OK_Punto").Value) = False And grdDatosGenerarApartados.ActiveRow.Cells("Punt").Value > 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("OK_Punto").Value = True
                            grdDatosGenerarApartados.ActiveRow.Cells("Punt").Appearance.ForeColor = Nothing
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Punt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Punt").Value + grdDatosGenerarApartados.ActiveRow.Cells("Punt").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PuntPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PuntPares").Value + grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsTotal").Value + grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value + grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value - grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value + grdDatosGenerarApartados.ActiveRow.Cells("PuntPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                        End If
                        If grdDatosGenerarApartados.Rows(e.Cell.Row.Index).Cells("OK_AtadosDestalladosNormales").Hidden = False And CBool(grdDatosGenerarApartados.Rows(e.Cell.Row.Index).Cells("OK_AtadosDestalladosNormales").Value) = False And grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Value > 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosNormales").Value = True
                            grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Appearance.ForeColor = Nothing
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANorm").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANorm").Value + grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANormPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANormPares").Value + grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("ATotal").Value = grdDatosGenerarApartados.ActiveRow.Cells("ATotal").Value + grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsTotalAtDest").Value + grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value + grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value - grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value + grdDatosGenerarApartados.ActiveRow.Cells("ANormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value + grdDatosGenerarApartados.ActiveRow.Cells("ANorm").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                        End If
                        If grdDatosGenerarApartados.Rows(e.Cell.Row.Index).Cells("OK_AtadosDestalladosPunto").Hidden = False And CBool(grdDatosGenerarApartados.Rows(e.Cell.Row.Index).Cells("OK_AtadosDestalladosPunto").Value) = False And grdDatosGenerarApartados.ActiveRow.Cells("APunt").Value > 0 Then
                            grdDatosGenerarApartados.ActiveRow.Cells("OK_AtadosDestalladosPunto").Value = True
                            grdDatosGenerarApartados.ActiveRow.Cells("APunt").Appearance.ForeColor = Nothing
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APunt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APunt").Value + grdDatosGenerarApartados.ActiveRow.Cells("APunt").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APuntPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APuntPares").Value + grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("ATotal").Value = grdDatosGenerarApartados.ActiveRow.Cells("ATotal").Value + grdDatosGenerarApartados.ActiveRow.Cells("APunt").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsTotalAtDest").Value + grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsApart").Value + grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value = grdDatosGenerarApartados.ActiveRow.Cells("PrsFalt").Value - grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value + grdDatosGenerarApartados.ActiveRow.Cells("APuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value + grdDatosGenerarApartados.ActiveRow.Cells("APunt").Value
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Value = "No"
                            grdDatosGenerarApartados.ActiveRow.Cells("M3").Appearance.BackColor = Nothing
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdDatosGenerarApartados_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles grdDatosGenerarApartados.AfterRowFilterChanged
        ContarRegistrosSeleccionados()
    End Sub

    Private Sub btnGuardarApartado_Click(sender As Object, e As EventArgs) Handles btnGuardarApartado.Click
        Dim objApartadoPorGenerar As Entidades.ApartadoPorGenerar_PPCP
        Dim lstApartadosPorGenerar As New List(Of Entidades.ApartadoPorGenerar_PPCP)
        Dim pedidoEnLista As Integer = 0
        Dim objBu As New Negocios.ApartadosBU
        Try
            Dim solicitaConfirmacion As New Tools.ConfirmarForm
            solicitaConfirmacion.mensaje = "¿Está seguro que desea generar los apartados de las partidas seleccionadas? Una vez generado(s) el(los) apartado(s) no podrá(n) ser modificado(s)."
            If solicitaConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                ultimoApartadoAntesDeGenerar = Integer.Parse(objBu.obtenerUltimoApartadoGenerado().Rows(0).Item("UltimoApartado").ToString())
                For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
                    If CBool(renglon.Cells("OK_renglonCompleto").Value) Then

                        pedidosSeleccionados = If(pedidosSeleccionados = "", renglon.Cells("PedidoSAY").Value.ToString(), pedidosSeleccionados + "," + renglon.Cells("PedidoSAY").Value.ToString())
                        pedidosDetallesSeleccionados = If(pedidosDetallesSeleccionados = "", renglon.Cells("PedidoDetalleId").Value.ToString(), pedidosDetallesSeleccionados + "," + renglon.Cells("PedidoDetalleId").Value.ToString())
                        navesSeleccionadas = If(navesSeleccionadas = "", renglon.Cells("Nave").Value.ToString(), navesSeleccionadas + "," + renglon.Cells("Nave").Value.ToString())
                        programasSeleccionados = If(programasSeleccionados = "", renglon.Cells("ProgramaId").Value.ToString(), programasSeleccionados + "," + renglon.Cells("ProgramaId").Value.ToString())

                        If lstApartadosPorGenerar.Count > 0 Then
                            For Each PedidosApartar As Entidades.ApartadoPorGenerar_PPCP In lstApartadosPorGenerar
                                If PedidosApartar.PPedidoId = renglon.Cells("PedidoSAY").Value And Split(PedidosApartar.PIdDetallePedidoSAY, ",").Contains(renglon.Cells("PedidoDetalleId").Value.ToString()) = False Then
                                    PedidosApartar.PIdDetallePedidoSAY = If(PedidosApartar.PIdDetallePedidoSAY = "", renglon.Cells("PedidoDetalleId").Value.ToString(), PedidosApartar.PIdDetallePedidoSAY + "," + renglon.Cells("PedidoDetalleId").Value.ToString())
                                    PedidosApartar.PFechaPreparacionPedido = If(PedidosApartar.PFechaPreparacionPedido = "", Date.Parse(renglon.Cells("FCliente").Value.ToString()).ToShortDateString, PedidosApartar.PFechaPreparacionPedido + "," + Date.Parse(renglon.Cells("FCliente").Value.ToString()).ToShortDateString)
                                    'PedidosApartar.PIdCliente = If(PedidosApartar.PIdCliente = "", Integer.Parse(renglon.Cells("ClienteID").Value.ToString()), PedidosApartar.PIdCliente)
                                    'PedidosApartar.PUsuarioCapturaId
                                    PedidosApartar.PNaveSAYId = If(PedidosApartar.PNaveSAYId = "", renglon.Cells("Nave").Value.ToString(), PedidosApartar.PNaveSAYId + "," + renglon.Cells("Nave").Value.ToString())
                                    PedidosApartar.PProgramaId = If(PedidosApartar.PProgramaId = "", renglon.Cells("ProgramaId").Value.ToString(), PedidosApartar.PProgramaId + "," + renglon.Cells("ProgramaId").Value.ToString())
                                    PedidosApartar.PObservacionApartado = If(PedidosApartar.PObservacionApartado = "", "_", PedidosApartar.PObservacionApartado + ",_")
                                    PedidosApartar.PNapartados = If(PedidosApartar.PNapartados = "", renglon.Cells("PrsApart").Value.ToString(), PedidosApartar.PNapartados + "," + renglon.Cells("PrsApart").Value.ToString())
                                    pedidoEnLista = 1
                                End If
                            Next
                        End If

                        If pedidoEnLista = 0 Then
                            objApartadoPorGenerar = New Entidades.ApartadoPorGenerar_PPCP
                            objApartadoPorGenerar.PPedidoId = renglon.Cells("PedidoSAY").Value
                            objApartadoPorGenerar.PIdDetallePedidoSAY = renglon.Cells("PedidoDetalleId").Value.ToString()
                            objApartadoPorGenerar.PFechaPreparacionPedido = Date.Parse(renglon.Cells("FCliente").Value.ToString()).ToShortDateString
                            objApartadoPorGenerar.PIdCliente = Integer.Parse(renglon.Cells("ClienteID").Value.ToString())
                            objApartadoPorGenerar.PUsuarioCapturaId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                            objApartadoPorGenerar.PObservacionApartado = "_"
                            objApartadoPorGenerar.POrigenApartado = "PPCP"
                            objApartadoPorGenerar.PNaveSAYId = renglon.Cells("Nave").Value
                            objApartadoPorGenerar.PProgramaId = renglon.Cells("ProgramaId").Value
                            objApartadoPorGenerar.PConDisponibilidad = disponibilidadGeneradaAnteriormente
                            objApartadoPorGenerar.PConDistribucion = distribucionGeneradaAnteriormente
                            objApartadoPorGenerar.PNapartados = renglon.Cells("PrsApart").Value.ToString()
                            lstApartadosPorGenerar.Add(objApartadoPorGenerar)
                        End If
                        pedidoEnLista = 0
                    End If
                Next

                For Each apartadoGenerar As Entidades.ApartadoPorGenerar_PPCP In lstApartadosPorGenerar
                    Dim resultado = objBu.guardarApartadosPPCP(apartadoGenerar)
                    If resultado(0)(0) = "Exito" Then
                        objBu.CalculoApartados(apartadoGenerar, resultado(0)(2))
                    End If
                Next
                objBu.guardarApartadosSICY()
                objBu.descontarParesDeLotesA()
                ultimoApartadoDespuesDeGenerar = Integer.Parse(objBu.obtenerUltimoApartadoGenerado().Rows(0).Item("UltimoApartado").ToString())
                grpAcotaciones.Visible = False
                lblTextoApartadosGenerados.Visible = True
                lblValorApartadosGenerados.Text = (ultimoApartadoDespuesDeGenerar - ultimoApartadoAntesDeGenerar).ToString()
                lblValorApartadosGenerados.Visible = True
                objBu.separarPartidasApartadas(pedidosSeleccionados, pedidosDetallesSeleccionados, navesSeleccionadas, programasSeleccionados)
                apartadosGenerados = 1
                If ultimoApartadoDespuesDeGenerar - ultimoApartadoAntesDeGenerar > 1 Then
                    show_message("Exito", "Apartados generados correctamente.")
                Else
                    show_message("Exito", "Apartado generado correctamente.")
                End If
                btnResumen_Click(sender, e)
                btnGuardarApartado.Enabled = False
                lblGuardarApartado.Enabled = False
                btnActualizarDistribucion.Enabled = False
                lblTextoBotonActualizarDistribucion.Enabled = False
                btnGuardarCambioTotalTallas.Enabled = False
                lblTextoGuardarCambioTotalTallas.Enabled = False
            End If
        Catch ex As Exception
            show_message("Error", "Ocurrió un error al generar el(los) apartado(s).")
            btnGuardarApartado.Enabled = False
            lblGuardarApartado.Enabled = False
            btnActualizarDistribucion.Enabled = False
            lblTextoBotonActualizarDistribucion.Enabled = False
            btnGuardarCambioTotalTallas.Enabled = False
            lblTextoGuardarCambioTotalTallas.Enabled = False
        End Try
        Cursor = Cursors.Default

    End Sub

    Private Sub grdDatosGenerarApartados_MouseClick(sender As Object, e As MouseEventArgs) Handles grdDatosGenerarApartados.MouseClick
        Dim indiceRenglonApartadoSeleccionado As Integer = 0
        Dim renglonesConCheckMarcadoRenglonCompleto As Integer = 0
        Dim renglonesIncluidos As Integer = 0
        Dim renglonesExcluidos As Integer = 0
        Dim renglonesConCheckMarcadoNormales As Integer = 0
        Dim renglonesIncluidosNormales As Integer = 0
        Dim renglonesExcluidosNormales As Integer = 0
        Dim renglonesConCheckMarcadoPuntos As Integer = 0
        Dim renglonesIncluidosPunto As Integer = 0
        Dim renglonesExcluidosPunto As Integer = 0
        Dim renglonesConCheckMarcadoDestallados As Integer = 0
        Dim renglonesIncluidosDestallados As Integer = 0
        Dim renglonesExcluidosDestallados As Integer = 0
        Dim renglonesConCheckMarcadoNormalDestallar As Integer = 0
        Dim renglonesIncluidosNormalDestallar As Integer = 0
        Dim renglonesExcluidosNormalDestallar As Integer = 0
        Dim renglonesConCheckMarcadoPuntoDestallar As Integer = 0
        Dim renglonesIncluidosPuntoDestallar As Integer = 0
        Dim renglonesExcluidosPuntoDestallar As Integer = 0

        If e.Button = Windows.Forms.MouseButtons.Right Then
            listRenglonesSeleccionados.Clear()

            Dim renglonesSeleccionados As Integer = 0
            Dim celdasSeleccionadas As Integer = 0
            Dim celdaMarcarDesmarcar As String = ""
            Dim indexColumnaMarcada As Integer = 0

            For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
                If renglon.Activated Or renglon.Selected Then
                    For Each celda As UltraGridCell In renglon.Cells
                        If celda.Selected And celda.Column.Index >= 0 And celda.Column.Index < 28 Then
                            celdaMarcarDesmarcar = "OK_renglonCompleto"
                            'Exit For
                        ElseIf celda.Selected And celda.Column.Index >= 28 And celda.Column.Index < 30 And permitirIncluirExcluirPartidas = 0 Then
                            celdaMarcarDesmarcar = "OK_Normales"
                            'Exit For
                        ElseIf celda.Selected And celda.Column.Index >= 30 And celda.Column.Index < 34 And permitirIncluirExcluirPartidas = 0 Then
                            celdaMarcarDesmarcar = "OK_Punto"
                            ' Exit For
                        ElseIf celda.Selected And celda.Column.Index >= 34 And celda.Column.Index < 37 And permitirIncluirExcluirPartidas = 0 Then
                            celdaMarcarDesmarcar = "OK_Destallados"
                            ' Exit For
                        ElseIf celda.Selected And celda.Column.Index >= 37 And celda.Column.Index < 40 And permitirIncluirExcluirPartidas = 0 Then
                            celdaMarcarDesmarcar = "OK_AtadosDestalladosNormales"
                            'Exit For
                        ElseIf celda.Selected And celda.Column.Index >= 40 And celda.Column.Index < 43 And permitirIncluirExcluirPartidas = 0 Then
                            celdaMarcarDesmarcar = "OK_AtadosDestalladosPunto"
                            ' Exit For
                        Else
                            If celdaMarcarDesmarcar = "" Then
                                celdaMarcarDesmarcar = "OK_renglonCompleto"
                            End If
                        End If
                    Next
                    renglonesSeleccionados += 1
                    indiceRenglonApartadoSeleccionado = renglon.Index
                    listRenglonesSeleccionados.Add(renglon.Index)
                    If CBool(renglon.Cells(celdaMarcarDesmarcar).Value) Then
                        If celdaMarcarDesmarcar = "OK_renglonCompleto" Then
                            renglonesConCheckMarcadoRenglonCompleto += 1
                        ElseIf celdaMarcarDesmarcar = "OK_Normales" Then
                            renglonesConCheckMarcadoNormales += 1
                        ElseIf celdaMarcarDesmarcar = "OK_Punto" Then
                            renglonesConCheckMarcadoPuntos += 1
                        ElseIf celdaMarcarDesmarcar = "OK_Destallados" Then
                            renglonesConCheckMarcadoDestallados += 1
                        ElseIf celdaMarcarDesmarcar = "OK_AtadosDestalladosNormales" Then
                            renglonesConCheckMarcadoNormalDestallar += 1
                        ElseIf celdaMarcarDesmarcar = "OK_AtadosDestalladosPunto" Then
                            renglonesConCheckMarcadoPuntoDestallar += 1
                        End If
                    End If
                    If renglon.Cells(celdaMarcarDesmarcar).Hidden = True Then
                        If celdaMarcarDesmarcar = "OK_renglonCompleto" Then
                            renglonesExcluidos += 1
                        ElseIf celdaMarcarDesmarcar = "OK_Normales" Then
                            renglonesExcluidosNormales += 1
                        ElseIf celdaMarcarDesmarcar = "OK_Punto" Then
                            renglonesExcluidosPunto += 1
                        ElseIf celdaMarcarDesmarcar = "OK_Destallados" Then
                            renglonesExcluidosDestallados += 1
                        ElseIf celdaMarcarDesmarcar = "OK_AtadosDestalladosNormales" Then
                            renglonesExcluidosNormalDestallar += 1
                        ElseIf celdaMarcarDesmarcar = "OK_AtadosDestalladosPunto" Then
                            renglonesExcluidosPuntoDestallar += 1
                        End If
                    Else
                        If celdaMarcarDesmarcar = "OK_renglonCompleto" Then
                            renglonesIncluidos += 1
                        ElseIf celdaMarcarDesmarcar = "OK_Normales" Then
                            renglonesIncluidosNormales += 1
                        ElseIf celdaMarcarDesmarcar = "OK_Punto" Then
                            renglonesIncluidosPunto += 1
                        ElseIf celdaMarcarDesmarcar = "OK_Destallados" Then
                            renglonesIncluidosDestallados += 1
                        ElseIf celdaMarcarDesmarcar = "OK_AtadosDestalladosNormales" Then
                            renglonesIncluidosNormalDestallar += 1
                        ElseIf celdaMarcarDesmarcar = "OK_AtadosDestalladosPunto" Then
                            renglonesIncluidosPuntoDestallar += 1
                        End If
                    End If
                Else 'If renglon.Activated Then
                    For Each celda As UltraGridCell In renglon.Cells
                        If celda.Selected And celda.Column.Index >= 0 And celda.Column.Index < 28 Then
                            celdaMarcarDesmarcar = "OK_renglonCompleto"
                            'Exit For
                        ElseIf celda.Selected And celda.Column.Index >= 28 And celda.Column.Index < 30 And permitirIncluirExcluirPartidas = 0 Then
                            celdaMarcarDesmarcar = "OK_Normales"
                            'Exit For
                        ElseIf celda.Selected And celda.Column.Index >= 30 And celda.Column.Index < 34 And permitirIncluirExcluirPartidas = 0 Then
                            celdaMarcarDesmarcar = "OK_Punto"
                            ' Exit For
                        ElseIf celda.Selected And celda.Column.Index >= 34 And celda.Column.Index < 37 And permitirIncluirExcluirPartidas = 0 Then
                            celdaMarcarDesmarcar = "OK_Destallados"
                            ' Exit For
                        ElseIf celda.Selected And celda.Column.Index >= 37 And celda.Column.Index < 40 And permitirIncluirExcluirPartidas = 0 Then
                            celdaMarcarDesmarcar = "OK_AtadosDestalladosNormales"
                            'Exit For
                        ElseIf celda.Selected And celda.Column.Index >= 40 And celda.Column.Index < 43 And permitirIncluirExcluirPartidas = 0 Then
                            celdaMarcarDesmarcar = "OK_AtadosDestalladosPunto"
                            ' Exit For
                        Else
                            If celdaMarcarDesmarcar = "" Then
                                celdaMarcarDesmarcar = "OK_renglonCompleto"
                            End If
                        End If
                    Next
                    For Each celda As UltraGridCell In renglon.Cells
                        If celda.Selected Then
                            celdasSeleccionadas += 1
                            renglonesSeleccionados += 1
                            If renglon.Cells(celdaMarcarDesmarcar).Hidden = True Then
                                If celdaMarcarDesmarcar = "OK_renglonCompleto" Then
                                    renglonesExcluidos += 1
                                ElseIf celdaMarcarDesmarcar = "OK_Normales" Then
                                    renglonesExcluidosNormales += 1
                                ElseIf celdaMarcarDesmarcar = "OK_Punto" Then
                                    renglonesExcluidosPunto += 1
                                ElseIf celdaMarcarDesmarcar = "OK_Destallados" Then
                                    renglonesExcluidosDestallados += 1
                                ElseIf celdaMarcarDesmarcar = "OK_AtadosDestalladosNormales" Then
                                    renglonesExcluidosNormalDestallar += 1
                                ElseIf celdaMarcarDesmarcar = "OK_AtadosDestalladosPunto" Then
                                    renglonesExcluidosPuntoDestallar += 1
                                End If
                            Else
                                If CBool(renglon.Cells(celdaMarcarDesmarcar).Value) Then
                                    If celdaMarcarDesmarcar = "OK_renglonCompleto" Then
                                        renglonesConCheckMarcadoRenglonCompleto += 1
                                    ElseIf celdaMarcarDesmarcar = "OK_Normales" Then
                                        renglonesConCheckMarcadoNormales += 1
                                    ElseIf celdaMarcarDesmarcar = "OK_Punto" Then
                                        renglonesConCheckMarcadoPuntos += 1
                                    ElseIf celdaMarcarDesmarcar = "OK_Destallados" Then
                                        renglonesConCheckMarcadoDestallados += 1
                                    ElseIf celdaMarcarDesmarcar = "OK_AtadosDestalladosNormales" Then
                                        renglonesConCheckMarcadoNormalDestallar += 1
                                    ElseIf celdaMarcarDesmarcar = "OK_AtadosDestalladosPunto" Then
                                        renglonesConCheckMarcadoPuntoDestallar += 1
                                    End If
                                End If
                                If celdaMarcarDesmarcar = "OK_renglonCompleto" Then
                                    renglonesIncluidos += 1
                                ElseIf celdaMarcarDesmarcar = "OK_Normales" Then
                                    renglonesIncluidosNormales += 1
                                ElseIf celdaMarcarDesmarcar = "OK_Punto" Then
                                    renglonesIncluidosPunto += 1
                                ElseIf celdaMarcarDesmarcar = "OK_Destallados" Then
                                    renglonesIncluidosDestallados += 1
                                ElseIf celdaMarcarDesmarcar = "OK_AtadosDestalladosNormales" Then
                                    renglonesIncluidosNormalDestallar += 1
                                ElseIf celdaMarcarDesmarcar = "OK_AtadosDestalladosPunto" Then
                                    renglonesIncluidosPuntoDestallar += 1
                                End If
                            End If
                        End If
                    Next
                    If celdasSeleccionadas > 0 Then
                        indiceRenglonApartadoSeleccionado = renglon.Index
                        listRenglonesSeleccionados.Add(renglon.Index)
                        celdasSeleccionadas = 0
                    End If
                End If
            Next

            cmsOpcionesGenerales.Items(0).Visible = False
            cmsOpcionesGenerales.Items(1).Visible = False
            cmsOpcionesGenerales.Items(4).Visible = False
            cmsOpcionesGenerales.Items(5).Visible = False
            cmsOpcionesGenerales.Items(6).Visible = False
            cmsOpcionesGenerales.Items(7).Visible = False
            cmsOpcionesGenerales.Items(8).Visible = False
            cmsOpcionesGenerales.Items(9).Visible = False
            cmsOpcionesGenerales.Items(10).Visible = False
            cmsOpcionesGenerales.Items(11).Visible = False
            cmsOpcionesGenerales.Items(12).Visible = False
            cmsOpcionesGenerales.Items(13).Visible = False
            If permitirIncluirExcluirPartidas = 1 Then
                cmsOpcionesGenerales.Items(2).Visible = True
                cmsOpcionesGenerales.Items(3).Visible = True
            Else
                cmsOpcionesGenerales.Items(2).Visible = False
                cmsOpcionesGenerales.Items(3).Visible = False
            End If

            If celdaMarcarDesmarcar = "OK_renglonCompleto" Then
                If renglonesSeleccionados > 0 Or celdasSeleccionadas > 0 Then
                    If renglonesConCheckMarcadoRenglonCompleto = renglonesSeleccionados And renglonesExcluidos = 0 Then
                        cmsOpcionesGenerales.Items(0).Visible = False
                        cmsOpcionesGenerales.Items(1).Visible = True
                    End If
                    If renglonesConCheckMarcadoRenglonCompleto = 0 And renglonesExcluidos = 0 Then
                        cmsOpcionesGenerales.Items(0).Visible = True
                        cmsOpcionesGenerales.Items(1).Visible = False
                    End If
                    If renglonesConCheckMarcadoRenglonCompleto > 0 And renglonesConCheckMarcadoRenglonCompleto < renglonesSeleccionados And renglonesExcluidos = 0 Then
                        cmsOpcionesGenerales.Items(0).Visible = True
                        cmsOpcionesGenerales.Items(1).Visible = True
                    End If
                    If permitirIncluirExcluirPartidas = 1 Then
                        If renglonesIncluidos = renglonesSeleccionados Then
                            cmsOpcionesGenerales.Items(2).Visible = False
                            cmsOpcionesGenerales.Items(3).Visible = True
                        End If
                        If renglonesIncluidos = 0 Then
                            cmsOpcionesGenerales.Items(2).Visible = True
                            cmsOpcionesGenerales.Items(3).Visible = False
                        End If
                    End If
                    cmsOpcionesGenerales.Show(Control.MousePosition)
                End If
            End If

            If celdaMarcarDesmarcar = "OK_Normales" Then
                If renglonesSeleccionados > 0 Or celdasSeleccionadas > 0 Then
                    If renglonesConCheckMarcadoNormales = renglonesSeleccionados And renglonesExcluidosNormales = 0 Then
                        'cmsOpcionesGenerales.Items(0).Visible = False
                        'cmsOpcionesGenerales.Items(1).Visible = True
                        cmsOpcionesGenerales.Items(4).Visible = False
                        cmsOpcionesGenerales.Items(5).Visible = True
                    End If
                    If renglonesConCheckMarcadoNormales = 0 And renglonesExcluidosNormales = 0 Then
                        cmsOpcionesGenerales.Items(4).Visible = True
                        cmsOpcionesGenerales.Items(5).Visible = False
                        'cmsOpcionesGenerales.Items(0).Visible = True
                        'cmsOpcionesGenerales.Items(1).Visible = False
                    End If
                    If renglonesConCheckMarcadoNormales > 0 And renglonesConCheckMarcadoNormales < renglonesSeleccionados And renglonesExcluidosNormales = 0 Then
                        cmsOpcionesGenerales.Items(4).Visible = True
                        cmsOpcionesGenerales.Items(5).Visible = True
                        'cmsOpcionesGenerales.Items(0).Visible = True
                        'cmsOpcionesGenerales.Items(1).Visible = True
                    End If
                    cmsOpcionesGenerales.Show(Control.MousePosition)
                End If
            End If

            If celdaMarcarDesmarcar = "OK_Punto" Then
                If renglonesSeleccionados > 0 Or celdasSeleccionadas > 0 Then
                    If renglonesConCheckMarcadoPuntos = renglonesSeleccionados And renglonesExcluidosPunto = 0 Then
                        'cmsOpcionesGenerales.Items(0).Visible = False
                        'cmsOpcionesGenerales.Items(1).Visible = True
                        cmsOpcionesGenerales.Items(6).Visible = False
                        cmsOpcionesGenerales.Items(7).Visible = True
                    End If
                    If renglonesConCheckMarcadoPuntos = 0 And renglonesExcluidosPunto = 0 Then
                        cmsOpcionesGenerales.Items(6).Visible = True
                        cmsOpcionesGenerales.Items(7).Visible = False
                        'cmsOpcionesGenerales.Items(0).Visible = True
                        'cmsOpcionesGenerales.Items(1).Visible = False
                    End If
                    If renglonesConCheckMarcadoPuntos > 0 And renglonesConCheckMarcadoPuntos < renglonesSeleccionados And renglonesExcluidosPunto = 0 Then
                        cmsOpcionesGenerales.Items(6).Visible = True
                        cmsOpcionesGenerales.Items(7).Visible = True
                        'cmsOpcionesGenerales.Items(0).Visible = True
                        'cmsOpcionesGenerales.Items(1).Visible = True
                    End If
                    cmsOpcionesGenerales.Show(Control.MousePosition)
                End If
            End If

            If celdaMarcarDesmarcar = "OK_Destallados" Then
                If renglonesSeleccionados > 0 Or celdasSeleccionadas > 0 Then
                    If renglonesConCheckMarcadoDestallados = renglonesSeleccionados And renglonesExcluidosDestallados = 0 Then
                        'cmsOpcionesGenerales.Items(0).Visible = False
                        'cmsOpcionesGenerales.Items(1).Visible = True
                        cmsOpcionesGenerales.Items(8).Visible = False
                        cmsOpcionesGenerales.Items(9).Visible = True
                    End If
                    If renglonesConCheckMarcadoDestallados = 0 And renglonesExcluidosDestallados = 0 Then
                        cmsOpcionesGenerales.Items(8).Visible = True
                        cmsOpcionesGenerales.Items(9).Visible = False
                        'cmsOpcionesGenerales.Items(0).Visible = True
                        'cmsOpcionesGenerales.Items(1).Visible = False
                    End If
                    If renglonesConCheckMarcadoDestallados > 0 And renglonesConCheckMarcadoDestallados < renglonesSeleccionados And renglonesExcluidosDestallados = 0 Then
                        cmsOpcionesGenerales.Items(8).Visible = True
                        cmsOpcionesGenerales.Items(9).Visible = True
                        'cmsOpcionesGenerales.Items(0).Visible = True
                        'cmsOpcionesGenerales.Items(1).Visible = True
                    End If
                    cmsOpcionesGenerales.Show(Control.MousePosition)
                End If
            End If

            If celdaMarcarDesmarcar = "OK_AtadosDestalladosNormales" Then
                If renglonesSeleccionados > 0 Or celdasSeleccionadas > 0 Then
                    If renglonesConCheckMarcadoNormalDestallar = renglonesSeleccionados And renglonesExcluidosNormalDestallar = 0 Then
                        'cmsOpcionesGenerales.Items(0).Visible = False
                        'cmsOpcionesGenerales.Items(1).Visible = True
                        cmsOpcionesGenerales.Items(10).Visible = False
                        cmsOpcionesGenerales.Items(11).Visible = True
                    End If
                    If renglonesConCheckMarcadoNormalDestallar = 0 And renglonesExcluidosNormalDestallar = 0 Then
                        cmsOpcionesGenerales.Items(10).Visible = True
                        cmsOpcionesGenerales.Items(11).Visible = False
                        'cmsOpcionesGenerales.Items(0).Visible = True
                        'cmsOpcionesGenerales.Items(1).Visible = False
                    End If
                    If renglonesConCheckMarcadoNormalDestallar > 0 And renglonesConCheckMarcadoNormalDestallar < renglonesSeleccionados And renglonesExcluidosNormalDestallar = 0 Then
                        cmsOpcionesGenerales.Items(10).Visible = True
                        cmsOpcionesGenerales.Items(11).Visible = True
                        'cmsOpcionesGenerales.Items(0).Visible = True
                        'cmsOpcionesGenerales.Items(1).Visible = True
                    End If
                    cmsOpcionesGenerales.Show(Control.MousePosition)
                End If
            End If

            If celdaMarcarDesmarcar = "OK_AtadosDestalladosPunto" Then
                If renglonesSeleccionados > 0 Or celdasSeleccionadas > 0 Then
                    If renglonesConCheckMarcadoPuntoDestallar = renglonesSeleccionados And renglonesExcluidosPuntoDestallar = 0 Then
                        'cmsOpcionesGenerales.Items(0).Visible = False
                        'cmsOpcionesGenerales.Items(1).Visible = True
                        cmsOpcionesGenerales.Items(12).Visible = False
                        cmsOpcionesGenerales.Items(13).Visible = True
                    End If
                    If renglonesConCheckMarcadoPuntoDestallar = 0 And renglonesExcluidosPuntoDestallar = 0 Then
                        cmsOpcionesGenerales.Items(12).Visible = True
                        cmsOpcionesGenerales.Items(13).Visible = False
                        'cmsOpcionesGenerales.Items(0).Visible = True
                        'cmsOpcionesGenerales.Items(1).Visible = False
                    End If
                    If renglonesConCheckMarcadoPuntoDestallar > 0 And renglonesConCheckMarcadoPuntoDestallar < renglonesSeleccionados And renglonesExcluidosPuntoDestallar = 0 Then
                        cmsOpcionesGenerales.Items(12).Visible = True
                        cmsOpcionesGenerales.Items(13).Visible = True
                        'cmsOpcionesGenerales.Items(0).Visible = True
                        'cmsOpcionesGenerales.Items(1).Visible = True
                    End If
                    cmsOpcionesGenerales.Show(Control.MousePosition)
                End If
            End If

        End If

    End Sub

    Private Sub tsmiAgregarSeleccionGeneral_Click(sender As Object, e As EventArgs) Handles tsmiAgregarSeleccionGeneral.Click
        Dim listColumnas As New List(Of String)
        For Each col As UltraGridColumn In grdDatosGenerarApartados.DisplayLayout.Bands(0).Columns
            listColumnas.Add(col.Header.Caption)
        Next
        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
            If listRenglonesSeleccionados.Contains(renglon.Index) Then
                If renglon.Cells("OK_renglonCompleto").Value = 0 Then
                    totalPartidasSeleccionadas += 1
                End If
                renglon.Cells("OK_renglonCompleto").Value = 1


                If listColumnas.Contains("Prs Dest") Then
                    renglon.Cells("OK_Destallados").Hidden = False
                End If
                If listColumnas.Contains("Norm") Then
                    renglon.Cells("OK_Normales").Hidden = False
                End If
                If listColumnas.Contains("Punt") Then
                    renglon.Cells("OK_Punto").Hidden = False
                End If
                If listColumnas.Contains("A Norm") Then
                    renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False
                End If
                If listColumnas.Contains("A Punt") Then
                    renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False
                End If

                If listColumnas.Contains("Prs Dest") Then
                    If renglon.Cells("OK_Destallados").Hidden = False And CBool(renglon.Cells("OK_Destallados").Value) = False And renglon.Cells("PrsDest").Value > 0 Then
                        renglon.Cells("OK_Destallados").Value = True
                        renglon.Cells("PrsDest").Appearance.ForeColor = Nothing
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsDest").Value + renglon.Cells("PrsDest").Value
                        renglon.Cells("PrsTotal").Value = renglon.Cells("PrsTotal").Value + renglon.Cells("PrsDest").Value
                        renglon.Cells("PrsApart").Value = renglon.Cells("PrsApart").Value + renglon.Cells("PrsDest").Value
                        renglon.Cells("PrsFalt").Value = renglon.Cells("PrsFalt").Value - renglon.Cells("PrsDest").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - renglon.Cells("PrsDest").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + renglon.Cells("PrsDest").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value + renglon.Cells("PrsDest").Value
                        renglon.Cells("M3").Value = "No"
                        renglon.Cells("M3").Appearance.BackColor = Nothing
                    End If
                End If
                If listColumnas.Contains("Norm") Then
                    If renglon.Cells("OK_Normales").Hidden = False And CBool(renglon.Cells("OK_Normales").Value) = False And renglon.Cells("Norm").Value > 0 Then
                        renglon.Cells("OK_Normales").Value = True
                        renglon.Cells("Norm").Appearance.ForeColor = Nothing
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Norm").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Norm").Value + renglon.Cells("Norm").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("NormPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("NormPares").Value + renglon.Cells("NormPares").Value
                        renglon.Cells("PrsTotal").Value = renglon.Cells("PrsTotal").Value + renglon.Cells("NormPares").Value
                        renglon.Cells("PrsApart").Value = renglon.Cells("PrsApart").Value + renglon.Cells("NormPares").Value
                        renglon.Cells("PrsFalt").Value = renglon.Cells("PrsFalt").Value - renglon.Cells("NormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - renglon.Cells("NormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + renglon.Cells("NormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value + renglon.Cells("NormPares").Value
                        renglon.Cells("M3").Value = "No"
                        renglon.Cells("M3").Appearance.BackColor = Nothing
                    End If
                End If
                If listColumnas.Contains("Punt") Then
                    If renglon.Cells("OK_Punto").Hidden = False And CBool(renglon.Cells("OK_Punto").Value) = False And renglon.Cells("Punt").Value > 0 Then
                        renglon.Cells("OK_Punto").Value = True
                        renglon.Cells("Punt").Appearance.ForeColor = Nothing
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Punt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Punt").Value + renglon.Cells("Punt").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PuntPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PuntPares").Value + renglon.Cells("PuntPares").Value
                        renglon.Cells("PrsTotal").Value = renglon.Cells("PrsTotal").Value + renglon.Cells("PuntPares").Value
                        renglon.Cells("PrsApart").Value = renglon.Cells("PrsApart").Value + renglon.Cells("PuntPares").Value
                        renglon.Cells("PrsFalt").Value = renglon.Cells("PrsFalt").Value - renglon.Cells("PuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - renglon.Cells("PuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + renglon.Cells("PuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value + renglon.Cells("PuntPares").Value
                        renglon.Cells("M3").Value = "No"
                        renglon.Cells("M3").Appearance.BackColor = Nothing
                    End If
                End If
                If listColumnas.Contains("A Norm") Then
                    If renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And CBool(renglon.Cells("OK_AtadosDestalladosNormales").Value) = False And renglon.Cells("ANorm").Value > 0 Then
                        renglon.Cells("OK_AtadosDestalladosNormales").Value = True
                        renglon.Cells("ANorm").Appearance.ForeColor = Nothing
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANorm").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANorm").Value + renglon.Cells("ANorm").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANormPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANormPares").Value + renglon.Cells("ANormPares").Value
                        renglon.Cells("ATotal").Value = renglon.Cells("ATotal").Value + renglon.Cells("ANorm").Value
                        renglon.Cells("PrsTotalAtDest").Value = renglon.Cells("PrsTotalAtDest").Value + renglon.Cells("ANormPares").Value
                        renglon.Cells("PrsApart").Value = renglon.Cells("PrsApart").Value + renglon.Cells("ANormPares").Value
                        renglon.Cells("PrsFalt").Value = renglon.Cells("PrsFalt").Value - renglon.Cells("ANormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - renglon.Cells("ANormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + renglon.Cells("ANormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value + renglon.Cells("ANormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value + renglon.Cells("ANorm").Value
                        renglon.Cells("M3").Value = "No"
                        renglon.Cells("M3").Appearance.BackColor = Nothing
                    End If
                End If
                If listColumnas.Contains("A Punt") Then
                    If renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And CBool(renglon.Cells("OK_AtadosDestalladosPunto").Value) = False And renglon.Cells("APunt").Value > 0 Then
                        renglon.Cells("OK_AtadosDestalladosPunto").Value = True
                        renglon.Cells("APunt").Appearance.ForeColor = Nothing
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APunt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APunt").Value + renglon.Cells("APunt").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APuntPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APuntPares").Value + renglon.Cells("APuntPares").Value
                        renglon.Cells("ATotal").Value = renglon.Cells("ATotal").Value + renglon.Cells("APunt").Value
                        renglon.Cells("PrsTotalAtDest").Value = renglon.Cells("PrsTotalAtDest").Value + renglon.Cells("APuntPares").Value
                        renglon.Cells("PrsApart").Value = renglon.Cells("PrsApart").Value + renglon.Cells("APuntPares").Value
                        renglon.Cells("PrsFalt").Value = renglon.Cells("PrsFalt").Value - renglon.Cells("APuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - renglon.Cells("APuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + renglon.Cells("APuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value + renglon.Cells("APuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value + renglon.Cells("APunt").Value
                        renglon.Cells("M3").Value = "No"
                        renglon.Cells("M3").Appearance.BackColor = Nothing
                    End If
                End If

            End If
        Next
        lblTotalSeleccionados.Text = Format(totalPartidasSeleccionadas, "###,###,##0")
        lblCantidadPartidasPorApartar.Text = Format(totalPartidasSeleccionadas, "###,###,##0")
        lblTiempoPartidasPorApartar.Text = " (" + Math.Round((totalPartidasSeleccionadas / 60), 2).ToString() + " m)"
        lblTotalTiempos.Text = "(" + Math.Round(Double.Parse(Replace(Replace(lblTiempoApartadosPorConfirmar.Text, "(", ""), " m)", "")) + Double.Parse(Replace(Replace(lblTiempoPartidasPorApartar.Text, "(", ""), " m)", "")), 2).ToString() + " m)"

    End Sub

    Private Sub tsmiQuitarSeleccionGeneral_Click(sender As Object, e As EventArgs) Handles tsmiQuitarSeleccionGeneral.Click
        Dim listColumnas As New List(Of String)
        For Each col As UltraGridColumn In grdDatosGenerarApartados.DisplayLayout.Bands(0).Columns
            listColumnas.Add(col.Header.Caption)
        Next
        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
            If listRenglonesSeleccionados.Contains(renglon.Index) Then
                If renglon.Cells("OK_renglonCompleto").Value = 1 Then
                    totalPartidasSeleccionadas -= 1
                End If
                renglon.Cells("OK_renglonCompleto").Value = 0

                If permitirIncluirExcluirPartidas = 0 Then

                    If listColumnas.Contains("Prs Dest") Then
                        If renglon.Cells("OK_Destallados").Hidden = False And CBool(renglon.Cells("OK_Destallados").Value) Then
                            renglon.Cells("OK_Destallados").Value = False
                            If renglon.Cells("PrsDest").Value > 0 Then
                                renglon.Cells("PrsDest").Appearance.ForeColor = Color.Red
                            End If
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsDest").Value - renglon.Cells("PrsDest").Value
                            renglon.Cells("PrsTotal").Value = renglon.Cells("PrsTotal").Value - renglon.Cells("PrsDest").Value
                            renglon.Cells("PrsApart").Value = renglon.Cells("PrsApart").Value - renglon.Cells("PrsDest").Value
                            renglon.Cells("PrsFalt").Value = renglon.Cells("PrsFalt").Value + renglon.Cells("PrsDest").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + renglon.Cells("PrsDest").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - renglon.Cells("PrsDest").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value - renglon.Cells("PrsDest").Value
                            renglon.Cells("M3").Value = "No"
                            renglon.Cells("M3").Appearance.BackColor = Nothing
                        End If
                    End If
                    If listColumnas.Contains("Norm") Then
                        If renglon.Cells("OK_Normales").Hidden = False And CBool(renglon.Cells("OK_Normales").Value) Then
                            renglon.Cells("OK_Normales").Value = False
                            If renglon.Cells("Norm").Value > 0 Then
                                renglon.Cells("Norm").Appearance.ForeColor = Color.Red
                            End If
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Norm").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Norm").Value - renglon.Cells("Norm").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("NormPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("NormPares").Value - renglon.Cells("NormPares").Value
                            renglon.Cells("PrsTotal").Value = renglon.Cells("PrsTotal").Value - renglon.Cells("NormPares").Value
                            renglon.Cells("PrsApart").Value = renglon.Cells("PrsApart").Value - renglon.Cells("NormPares").Value
                            renglon.Cells("PrsFalt").Value = renglon.Cells("PrsFalt").Value + renglon.Cells("NormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + renglon.Cells("NormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - renglon.Cells("NormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value - renglon.Cells("NormPares").Value
                            renglon.Cells("M3").Value = "No"
                            renglon.Cells("M3").Appearance.BackColor = Nothing
                        End If
                    End If
                    If listColumnas.Contains("Punt") Then
                        If renglon.Cells("OK_Punto").Hidden = False And CBool(renglon.Cells("OK_Punto").Value) Then
                            renglon.Cells("OK_Punto").Value = False
                            If renglon.Cells("Punt").Value > 0 Then
                                renglon.Cells("Punt").Appearance.ForeColor = Color.Red
                            End If
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Punt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Punt").Value - renglon.Cells("Punt").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PuntPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PuntPares").Value - renglon.Cells("PuntPares").Value
                            renglon.Cells("PrsTotal").Value = renglon.Cells("PrsTotal").Value - renglon.Cells("PuntPares").Value
                            renglon.Cells("PrsApart").Value = renglon.Cells("PrsApart").Value - renglon.Cells("PuntPares").Value
                            renglon.Cells("PrsFalt").Value = renglon.Cells("PrsFalt").Value + renglon.Cells("PuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + renglon.Cells("PuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - renglon.Cells("PuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value - renglon.Cells("PuntPares").Value
                            renglon.Cells("M3").Value = "No"
                            renglon.Cells("M3").Appearance.BackColor = Nothing
                        End If
                    End If
                    If listColumnas.Contains("A Norm") Then
                        If renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And CBool(renglon.Cells("OK_AtadosDestalladosNormales").Value) Then
                            renglon.Cells("OK_AtadosDestalladosNormales").Value = False
                            If renglon.Cells("ANorm").Value > 0 Then
                                renglon.Cells("ANorm").Appearance.ForeColor = Color.Red
                            End If
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANorm").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANorm").Value - renglon.Cells("ANorm").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANormPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANormPares").Value - renglon.Cells("ANormPares").Value
                            renglon.Cells("ATotal").Value = renglon.Cells("ATotal").Value - renglon.Cells("ANorm").Value
                            renglon.Cells("PrsTotalAtDest").Value = renglon.Cells("PrsTotalAtDest").Value - renglon.Cells("ANormPares").Value
                            renglon.Cells("PrsApart").Value = renglon.Cells("PrsApart").Value - renglon.Cells("ANormPares").Value
                            renglon.Cells("PrsFalt").Value = renglon.Cells("PrsFalt").Value + renglon.Cells("ANormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + renglon.Cells("ANormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - renglon.Cells("ANormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value - renglon.Cells("ANormPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value - renglon.Cells("ANorm").Value
                            renglon.Cells("M3").Value = "No"
                            renglon.Cells("M3").Appearance.BackColor = Nothing
                        End If
                    End If
                    If listColumnas.Contains("A Punt") Then
                        If renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And CBool(renglon.Cells("OK_AtadosDestalladosPunto").Value) Then
                            renglon.Cells("OK_AtadosDestalladosPunto").Value = False
                            If renglon.Cells("APunt").Value > 0 Then
                                renglon.Cells("APunt").Appearance.ForeColor = Color.Red
                            End If
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APunt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APunt").Value - renglon.Cells("APunt").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APuntPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APuntPares").Value - renglon.Cells("APuntPares").Value
                            renglon.Cells("ATotal").Value = renglon.Cells("ATotal").Value - renglon.Cells("APunt").Value
                            renglon.Cells("PrsTotalAtDest").Value = renglon.Cells("PrsTotalAtDest").Value - renglon.Cells("APuntPares").Value
                            renglon.Cells("PrsApart").Value = renglon.Cells("PrsApart").Value - renglon.Cells("APuntPares").Value
                            renglon.Cells("PrsFalt").Value = renglon.Cells("PrsFalt").Value + renglon.Cells("APuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + renglon.Cells("APuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - renglon.Cells("APuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value - renglon.Cells("APuntPares").Value
                            grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value - renglon.Cells("APunt").Value
                            renglon.Cells("M3").Value = "No"
                            renglon.Cells("M3").Appearance.BackColor = Nothing
                        End If
                    End If

                    If listColumnas.Contains("Prs Dest") Then
                        renglon.Cells("OK_Destallados").Hidden = True
                    End If
                    If listColumnas.Contains("Norm") Then
                        renglon.Cells("OK_Normales").Hidden = True
                    End If
                    If listColumnas.Contains("Punt") Then
                        renglon.Cells("OK_Punto").Hidden = True
                    End If
                    If listColumnas.Contains("A Norm") Then
                        renglon.Cells("OK_AtadosDestalladosNormales").Hidden = True
                    End If
                    If listColumnas.Contains("A Punt") Then
                        renglon.Cells("OK_AtadosDestalladosPunto").Hidden = True
                    End If
                End If
            End If
        Next

        lblTotalSeleccionados.Text = Format(totalPartidasSeleccionadas, "###,###,##0")
        lblCantidadPartidasPorApartar.Text = Format(totalPartidasSeleccionadas, "###,###,##0")
        lblTiempoPartidasPorApartar.Text = " (" + Math.Round((totalPartidasSeleccionadas / 60), 2).ToString() + " m)"
        lblTotalTiempos.Text = "(" + Math.Round(Double.Parse(Replace(Replace(lblTiempoApartadosPorConfirmar.Text, "(", ""), " m)", "")) + Double.Parse(Replace(Replace(lblTiempoPartidasPorApartar.Text, "(", ""), " m)", "")), 2).ToString() + " m)"

    End Sub

    Private Sub tsmiIncluirSeleccionGeneral_Click(sender As Object, e As EventArgs) Handles tsmiIncluirSeleccionGeneral.Click
        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
            If listRenglonesSeleccionados.Contains(renglon.Index) Then
                renglon.Appearance.BackColor = Nothing
                If renglon.Cells("OK_renglonCompleto").Value = 0 Then
                    totalPartidasSeleccionadas += 1
                End If
                renglon.Cells("OK_renglonCompleto").Value = 1
                renglon.Cells("OK_renglonCompleto").Hidden = False
                renglon.Cells("Excluido").Value = 0
            End If
        Next
        lblTotalSeleccionados.Text = Format(totalPartidasSeleccionadas, "###,###,##0")
        lblCantidadPartidasPorApartar.Text = Format(totalPartidasSeleccionadas, "###,###,##0")
        lblTiempoPartidasPorApartar.Text = " (" + Math.Round((totalPartidasSeleccionadas / 60), 2).ToString() + " m)"
        lblTotalTiempos.Text = "(" + Math.Round(Double.Parse(Replace(Replace(lblTiempoApartadosPorConfirmar.Text, "(", ""), " m)", "")) + Double.Parse(Replace(Replace(lblTiempoPartidasPorApartar.Text, "(", ""), " m)", "")), 2).ToString() + " m)"

    End Sub

    Private Sub tsmiExcluirSeleccionGeneral_Click(sender As Object, e As EventArgs) Handles tsmiExcluirSeleccionGeneral.Click
        Dim solicitaConfirmacion As New Tools.ConfirmarForm
        solicitaConfirmacion.mensaje = "Esta acción excluirá las partidas seleccionadas del proceso de distribución de pares ¿Desea continuar?"
        If solicitaConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
                If listRenglonesSeleccionados.Contains(renglon.Index) Then
                    renglon.Appearance.BackColor = Color.LightGray
                    If renglon.Cells("OK_renglonCompleto").Value = 1 Then
                        totalPartidasSeleccionadas -= 1
                    End If
                    renglon.Cells("OK_renglonCompleto").Value = 0
                    renglon.Cells("OK_renglonCompleto").Hidden = True
                    renglon.Cells("Excluido").Value = 1
                End If
            Next
        End If
        lblTotalSeleccionados.Text = Format(totalPartidasSeleccionadas, "###,###,##0")
        lblCantidadPartidasPorApartar.Text = Format(totalPartidasSeleccionadas, "###,###,##0")
        lblTiempoPartidasPorApartar.Text = " (" + Math.Round((totalPartidasSeleccionadas / 60), 2).ToString() + " m)"
        lblTotalTiempos.Text = "(" + Math.Round(Double.Parse(Replace(Replace(lblTiempoApartadosPorConfirmar.Text, "(", ""), " m)", "")) + Double.Parse(Replace(Replace(lblTiempoPartidasPorApartar.Text, "(", ""), " m)", "")), 2).ToString() + " m)"

    End Sub

    Private Sub btnReordenar_Click(sender As Object, e As EventArgs) Handles btnReordenar.Click
        Dim dtPartidasGrid As New DataTable()
        Dim solicitaConfirmacion As New Tools.confirmarFormGrande
        solicitaConfirmacion.mensaje = "Esta acción reordenará las partidas del listado actual con base en la semana de programación y prioridad del cliente en apartados, independientemente de los movimientos realizados por el usuario ¿Desea reordenar?"
        If solicitaConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
            Cursor = Cursors.WaitCursor
            btnArriba_Click(sender, e)
            grdDetallesPartida.DataSource = Nothing
            lblPedidoSay.Text = "0"
            lblPedidoSICY.Text = "0"
            lblPartidaPedido.Text = "0"
            lblDescripcionProducto.Text = "-"
            dtPartidasGrid = grdDatosGenerarApartados.DataSource
            Dim dvPartidasGrid As New DataView(dtPartidasGrid)
            dvPartidasGrid.Sort = "Sprogr ASC, Prio ASC, Articulo ASC"
            dtPartidasGrid = dvPartidasGrid.ToTable()

            grdDatosGenerarApartados.DataSource = Nothing

            grdDatosGenerarApartados.DataSource = dtPartidasGrid
            gridPedidosDiseño(grdDatosGenerarApartados)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub chboxMostrarPartidasExcluidas_CheckedChanged(sender As Object, e As EventArgs) Handles chboxMostrarPartidasExcluidas.CheckedChanged
        If chboxMostrarPartidasExcluidas.Checked = False Then
            For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
                If renglon.Cells("Excluido").Value = 1 Then
                    renglon.Hidden = True
                End If
            Next
        ElseIf chboxMostrarPartidasExcluidas.Checked = True Then
            For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
                If renglon.Cells("Excluido").Value = 1 Then
                    renglon.Hidden = False
                End If
            Next
        End If
    End Sub

    Private Sub grdDatosGenerarApartados_BeforeCellActivate(sender As Object, e As CancelableCellEventArgs) Handles grdDatosGenerarApartados.BeforeCellActivate
        Dim objBU As New Negocios.ApartadosBU()
        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
            If renglon.Activated Then
                If permitirIncluirExcluirPartidas = 1 Then
                    'objBU.actualizarTallasDesdeLotesA(Integer.Parse(renglon.Cells("ID").Value.ToString()), Integer.Parse(renglon.Cells("PedidoSICY").Value.ToString()), Integer.Parse(renglon.Cells("PartidaId").Value.ToString()), Integer.Parse(renglon.Cells("Programaid").Value.ToString()), Integer.Parse(renglon.Cells("PedidoDetalleId").Value.ToString()))
                    grdDetallesPartida.DataSource = objBU.consultaParesTallasPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), 1)

                    lblPedidoSay.Text = renglon.Cells("PedidoSAY").Value.ToString()
                    lblPedidoSICY.Text = renglon.Cells("PedidoSICY").Value.ToString()
                    lblPartidaPedido.Text = renglon.Cells("PartidaId").Value.ToString()
                    lblDescripcionProducto.Text = renglon.Cells("Articulo").Value.ToString()
                    gridPartidasDiseño(grdDetallesPartida)
                Else

                    If renglon.Activated And renglon.Index < grdDatosGenerarApartados.Rows.Count() - 1 Then
                        grdDetallesPartida.DataSource = objBU.consultaParesTallasPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), 2)
                        pedidoDetalleIdModificarTallas = Integer.Parse(renglon.Cells("PedidoDetalleId").Value.ToString())
                        If pedidoDetalleIdModificarTallas > 0 Then
                            programaIdModificarTallas = Integer.Parse(renglon.Cells("ProgramaId").Value.ToString())
                            naveIdModificarTallas = Integer.Parse(renglon.Cells("Nave").Value.ToString())
                        End If
                        indiceRenglonModificarTallas = renglon.Index
                    End If
                    If permitirIncluirExcluirPartidas <> 1 And grdDistribucionPartida.Visible = True Then
                        If renglon.Activated And renglon.Index < grdDatosGenerarApartados.Rows.Count() - 1 Then
                            grdDistribucionPartida.DataSource = objBU.consultaParesDistribucionPartida(renglon.Cells("PedidoDetalleId").Value.ToString(), Integer.Parse(renglon.Cells("Nave").Value.ToString()), Integer.Parse(renglon.Cells("ProgramaId").Value.ToString()))
                            gridPartidasDistribucionDiseño(grdDistribucionPartida)
                        End If
                    Else
                        grdDistribucionPartida.DataSource = Nothing
                    End If
                    If renglon.Activated And renglon.Index < grdDatosGenerarApartados.Rows.Count() - 1 Then
                        gridPartidasDiseño(grdDetallesPartida)
                        lblPedidoSay.Text = renglon.Cells("PedidoSAY").Value.ToString()
                        lblPedidoSICY.Text = renglon.Cells("PedidoSICY").Value.ToString()
                        lblPartidaPedido.Text = renglon.Cells("PartidaId").Value.ToString()
                        lblDescripcionProducto.Text = renglon.Cells("Articulo").Value.ToString()
                    End If
                End If
            End If
        Next
        'btnAbajo_Click(sender, e)
    End Sub

    Private Sub gridPartidasDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        Dim ColumnaTotales As Integer = 0

        If grid.Rows.Band.Columns.Exists("Total") Then
            grid.Rows.Band.Columns.Remove("Total")
        End If
        grid.Rows.Band.Columns.Add("Total")
        grid.DisplayLayout.Bands(0).Columns("Total").DataType = System.Type.GetType("System.Int32")

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        'grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 0
        'grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.False
        'grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        'grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        'grid.DisplayLayout.GroupByBox.Hidden = False
        'grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"
        grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
        grid.DisplayLayout.Override.SelectTypeCol = SelectType.None

        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If

        For Each row In grid.Rows
            ColumnaTotales = 0
            For Each celda As UltraGridCell In row.Cells
                If celda.Column.Index = 0 Then
                    If celda.Value.ToString().Contains("5 ") Or celda.Value.ToString().Contains("6 ") Then
                        row.CellAppearance.BackColor = Color.SteelBlue
                        row.CellAppearance.ForeColor = Color.White
                    End If
                    celda.Value = Replace(celda.Value, "1 ", "")
                    celda.Value = Replace(celda.Value, "2 ", "")
                    celda.Value = Replace(celda.Value, "3 ", "")
                    celda.Value = Replace(celda.Value, "4 ", "")
                    celda.Value = Replace(celda.Value, "5 ", "")
                    celda.Value = Replace(celda.Value, "6 ", "")
                    celda.Value = Replace(celda.Value, "7 ", "")
                End If
                If celda.Column.Index < row.Band.Columns.Count - 1 Then
                    If IsDBNull(celda.Value) Or celda.Value.ToString() = "" Then
                        celda.Value = 0
                    End If
                    If celda.Column.Index > 0 Then
                        ColumnaTotales += celda.Value
                    End If
                End If
            Next
            If permitirIncluirExcluirPartidas = 1 Then
                If row.Index > 3 Then
                    row.Hidden = True
                End If
            Else
                If row.Index > 3 Then
                    row.Hidden = False
                End If
            End If
            If row.Index <> 6 Then
                row.Activation = Activation.NoEdit
            End If
            row.Cells("Total").Value = ColumnaTotales
            row.Cells("Total").Activation = Activation.NoEdit
        Next

        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If Not col.Hidden Then
                If col.Index > 0 Then
                    col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                    col.Format = "n0"
                End If
            End If
            If permitirIncluirExcluirPartidas = 0 Then
                If grid.Rows.Count > 0 Then
                    If grid.Rows(grid.Rows.Count - 1).Cells(col.Index).Value <> grid.Rows(grid.Rows.Count - 2).Cells(col.Index).Value And col.Index > 0 Then
                        grid.Rows(grid.Rows.Count - 1).Cells(col.Index).Appearance.ForeColor = Color.Red
                    End If
                End If
            End If
        Next

        ordenarColumnasTallas(grid)

    End Sub

    Private Sub grdDatosGenerarApartados_AfterRowActivate(sender As Object, e As EventArgs) Handles grdDatosGenerarApartados.AfterRowActivate
        Dim objBU As New Negocios.ApartadosBU()
        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
            If renglon.Activated And renglon.Index < grdDatosGenerarApartados.Rows.Count - 1 Then
                If permitirIncluirExcluirPartidas = 1 Then
                    'objBU.actualizarTallasDesdeLotesA(Integer.Parse(renglon.Cells("ID").Value.ToString()), Integer.Parse(renglon.Cells("PedidoSICY").Value.ToString()), Integer.Parse(renglon.Cells("PartidaId").Value.ToString()), Integer.Parse(renglon.Cells("Programaid").Value.ToString()), Integer.Parse(renglon.Cells("PedidoDetalleId").Value.ToString()))
                    grdDetallesPartida.DataSource = objBU.consultaParesTallasPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), 1)
                Else
                    grdDetallesPartida.DataSource = objBU.consultaParesTallasPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), 2)
                End If
                gridPartidasDiseño(grdDetallesPartida)
                lblPedidoSay.Text = renglon.Cells("PedidoSAY").Value.ToString()
                lblPedidoSICY.Text = renglon.Cells("PedidoSICY").Value.ToString()
                lblPartidaPedido.Text = renglon.Cells("PartidaId").Value.ToString()
                lblDescripcionProducto.Text = renglon.Cells("Articulo").Value.ToString()
            End If
        Next
        'btnAbajo_Click(sender, e)
    End Sub

    Public Sub gridPedidosDistribucionesDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid, tipo As Integer)
        Dim IndicePrimerColumna As Integer
        Dim Cantidad_Grupos As Integer = 0
        Dim Seleccionados As Integer = 0
        Dim TotalAtadosNormalesApartables As Integer = 0
        Dim TotalAtadoPuntoApartables As Integer = 0
        Dim TotalDestalladosApartables As Integer = 0
        Dim TotalNormalesDestallar As Integer = 0
        Dim TotalPuntoDestallar As Integer = 0
        Dim UltimaColumna As Integer = 0
        Dim listaColumnas As New List(Of String)

        For Each col As UltraGridColumn In grdDatosGenerarApartados.DisplayLayout.Bands(0).Columns
            listaColumnas.Add(col.Header.Caption)
        Next

        If tipo = 1 Then
            'GUARDAMOS EL DISEÑO Y LA BANDA EN VARIABLES PARA HACER REFERENCIA A ELLOS MAS FACIL 
            Dim Layout As UltraGridLayout = grid.DisplayLayout
            Dim rootBand As UltraGridBand = Layout.Bands(0)

            rootBand.RowLayoutStyle = RowLayoutStyle.GroupLayout

            'Validamos cuantas columnas de informacion hay en el grid, pasa despues determinar la cantidad de columnas de corridas
            IndicePrimerColumna = 14

            Cantidad_Grupos = rootBand.Columns.Count - IndicePrimerColumna

            'FOR PARA AGREGAR LOS RESPECTIVOS GRUPOS 
            For n = 3 To rootBand.Columns.Count - 1 Step 1

                'If tipoDistribucion = 0 Then
                UltimaColumna = 50
                'Else
                '    UltimaColumna = 47
                'End If

                If n <> 21 And (n <= 26 Or n > 43) And (n < 46 Or (n >= 48 And n < UltimaColumna)) Then
                    Dim grupo As UltraGridGroup = rootBand.Groups.Add(rootBand.Columns(n).Header.Caption, " ")
                    rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = grupo
                Else
                    If n > 26 And n < 36 Then
                        If n = 27 Then
                            Dim NombreColumna As String
                            NombreColumna = "Atados Completos"

                            Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                            rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                        Else
                            Dim Grupo As UltraGridGroup = rootBand.Groups("Atados Completos")
                            rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                        End If
                    ElseIf n >= 36 And n <= 43 Then
                        If n = 36 Then
                            Dim NombreColumna As String
                            NombreColumna = "Atados Por Destallar"

                            Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                            rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                        Else
                            Dim Grupo As UltraGridGroup = rootBand.Groups("Atados Por Destallar")
                            rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                        End If
                    End If

                    IndicePrimerColumna += 1
                End If
            Next

        End If

        grid.DisplayLayout.Bands(0).Columns("PedidoDetalleId").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("ClienteID").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("TiendaID").Hidden = True
        'If tipoDistribucion = 0 Then
        grid.DisplayLayout.Bands(0).Columns("MAnt").Hidden = True
        'Else
        'grid.DisplayLayout.Bands(0).Columns("MAnt").Hidden = False
        'End If
        If listaColumnas.Contains("NormPares") Then
            grid.DisplayLayout.Bands(0).Columns("NormPares").Hidden = True
        End If
        If listaColumnas.Contains("PuntPares") Then
            grid.DisplayLayout.Bands(0).Columns("PuntPares").Hidden = True
        End If
        If listaColumnas.Contains("ANormPares") Then
            grid.DisplayLayout.Bands(0).Columns("ANormPares").Hidden = True
        End If
        If listaColumnas.Contains("APuntPares") Then
            grid.DisplayLayout.Bands(0).Columns("APuntPares").Hidden = True
        End If
        grid.DisplayLayout.Bands(0).Columns("Nave").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("ProgramaId").Hidden = True


        grid.DisplayLayout.Bands(0).Columns("OK_renglonCompleto").Header.Caption = ""
        grid.DisplayLayout.Bands(0).Columns("OK_renglonCompleto").Style = ColumnStyle.CheckBox
        If listaColumnas.Contains("OK_Normales") Then
            grid.DisplayLayout.Bands(0).Columns("OK_Normales").Header.Caption = ""
            grid.DisplayLayout.Bands(0).Columns("OK_Normales").Style = ColumnStyle.CheckBox
        End If
        If listaColumnas.Contains("OK_Punto") Then
            grid.DisplayLayout.Bands(0).Columns("OK_Punto").Header.Caption = ""
            grid.DisplayLayout.Bands(0).Columns("OK_Punto").Style = ColumnStyle.CheckBox
        End If
        If listaColumnas.Contains("OK_Destallados") Then
            grid.DisplayLayout.Bands(0).Columns("OK_Destallados").Header.Caption = ""
            grid.DisplayLayout.Bands(0).Columns("OK_Destallados").Style = ColumnStyle.CheckBox
        End If
        If listaColumnas.Contains("OK_AtadosDestalladosNormales") Then
            grid.DisplayLayout.Bands(0).Columns("OK_AtadosDestalladosNormales").Header.Caption = ""
            grid.DisplayLayout.Bands(0).Columns("OK_AtadosDestalladosNormales").Style = ColumnStyle.CheckBox
        End If
        If listaColumnas.Contains("OK_AtadosDestalladosPunto") Then
            grid.DisplayLayout.Bands(0).Columns("OK_AtadosDestalladosPunto").Header.Caption = ""
            grid.DisplayLayout.Bands(0).Columns("OK_AtadosDestalladosPunto").Style = ColumnStyle.CheckBox
        End If

        grid.DisplayLayout.Bands(0).Columns("Prio").Header.Caption = "Prio"
        grid.DisplayLayout.Bands(0).Columns("Prio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Prio").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Prio").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("PedidoSAY").Header.Caption = "Pedido SAY"
        grid.DisplayLayout.Bands(0).Columns("PedidoSAY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("PedidoSAY").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("PedidoSICY").Header.Caption = "Pedido SICY"
        grid.DisplayLayout.Bands(0).Columns("PedidoSICY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("PedidoSICY").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("OC").Header.Caption = "Orden Cliente"
        grid.DisplayLayout.Bands(0).Columns("OC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("OC").CharacterCasing = CharacterCasing.Upper
        grid.DisplayLayout.Bands(0).Columns("B3M").Header.Caption = "B3M"
        grid.DisplayLayout.Bands(0).Columns("B3M").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Cliente").Header.Caption = "Cliente"
        grid.DisplayLayout.Bands(0).Columns("Cliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Cliente").CharacterCasing = CharacterCasing.Upper
        grid.DisplayLayout.Bands(0).Columns("Tienda").Header.Caption = "Tienda / Embarque / Cedis"
        grid.DisplayLayout.Bands(0).Columns("Tienda").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Tienda").CharacterCasing = CharacterCasing.Upper
        grid.DisplayLayout.Bands(0).Columns("SProgr").Header.Caption = "SProgr"
        grid.DisplayLayout.Bands(0).Columns("SProgr").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("FProgram").Header.Caption = "FProgram"
        grid.DisplayLayout.Bands(0).Columns("FProgram").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("FCliente").Header.Caption = "FCliente"
        grid.DisplayLayout.Bands(0).Columns("FCliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("PartidaId").Header.Caption = "Partida"
        grid.DisplayLayout.Bands(0).Columns("PartidaId").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("PartidaId").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("Articulo").Header.Caption = "Artículo"
        grid.DisplayLayout.Bands(0).Columns("Articulo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Articulo").CharacterCasing = CharacterCasing.Upper
        grid.DisplayLayout.Bands(0).Columns("Temporada").Header.Caption = "Temporada"
        grid.DisplayLayout.Bands(0).Columns("Temporada").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Temporada").CharacterCasing = CharacterCasing.Upper
        grid.DisplayLayout.Bands(0).Columns("TipoN").Header.Caption = "TipoN"
        grid.DisplayLayout.Bands(0).Columns("TipoN").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("TipoN").CharacterCasing = CharacterCasing.Upper

        grid.DisplayLayout.Bands(0).Columns("PrsPed").Header.Caption = "Prs Ped"
        grid.DisplayLayout.Bands(0).Columns("PrsPed").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("PrsPed").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("PrsPed").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("PrsProgr").Header.Caption = "Prs Progr"
        grid.DisplayLayout.Bands(0).Columns("PrsProgr").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("PrsProgr").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("PrsProgr").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("PrsDisp").Header.Caption = "Prs Disp"
        grid.DisplayLayout.Bands(0).Columns("PrsDisp").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("PrsDisp").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("PrsDisp").Format = "n0"

        grid.DisplayLayout.Bands(0).Columns("MAnt").Header.Caption = "M Ant"
        grid.DisplayLayout.Bands(0).Columns("MAnt").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("M").Header.Caption = "M"
        grid.DisplayLayout.Bands(0).Columns("M").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("AP").Header.Caption = "AP"
        grid.DisplayLayout.Bands(0).Columns("AP").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("PrsXApart").Header.Caption = "Prs X Apart"
        grid.DisplayLayout.Bands(0).Columns("PrsXApart").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("PrsXApart").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("PrsXApart").Format = "n0"

        If listaColumnas.Contains("Norm") Then
            grid.DisplayLayout.Bands(0).Columns("Norm").Header.Caption = "Norm"
            grid.DisplayLayout.Bands(0).Columns("Norm").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Norm").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Norm").Format = "n0"
        End If
        If listaColumnas.Contains("Punt") Then
            grid.DisplayLayout.Bands(0).Columns("Punt").Header.Caption = "Punt"
            grid.DisplayLayout.Bands(0).Columns("Punt").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Punt").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Punt").Format = "n0"
        End If
        If listaColumnas.Contains("PrsDest") Then
            grid.DisplayLayout.Bands(0).Columns("PrsDest").Header.Caption = "Prs Dest"
            grid.DisplayLayout.Bands(0).Columns("PrsDest").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("PrsDest").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("PrsDest").Format = "n0"
        End If

        If listaColumnas.Contains("PrsTotal") Then
            grid.DisplayLayout.Bands(0).Columns("PrsTotal").Header.Caption = "Prs Total"
            grid.DisplayLayout.Bands(0).Columns("PrsTotal").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("PrsTotal").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("PrsTotal").Format = "n0"
        End If

        If listaColumnas.Contains("ANorm") Then
            grid.DisplayLayout.Bands(0).Columns("ANorm").Header.Caption = "A Norm"
            grid.DisplayLayout.Bands(0).Columns("ANorm").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("ANorm").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("ANorm").Format = "n0"
        End If
        If listaColumnas.Contains("APunt") Then
            grid.DisplayLayout.Bands(0).Columns("APunt").Header.Caption = "A Punt"
            grid.DisplayLayout.Bands(0).Columns("APunt").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("APunt").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("APunt").Format = "n0"
        End If

        If listaColumnas.Contains("ATotal") Then
            grid.DisplayLayout.Bands(0).Columns("ATotal").Header.Caption = "A Total"
            grid.DisplayLayout.Bands(0).Columns("ATotal").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("ATotal").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("ATotal").Format = "n0"
        End If
        If listaColumnas.Contains("PrsTotalAtDest") Then
            grid.DisplayLayout.Bands(0).Columns("PrsTotalAtDest").Header.Caption = "Prs Total"
            grid.DisplayLayout.Bands(0).Columns("PrsTotalAtDest").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("PrsTotalAtDest").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("PrsTotalAtDest").Format = "n0"
        End If

        grid.DisplayLayout.Bands(0).Columns("PrsApart").Header.Caption = "Prs Apart"
        grid.DisplayLayout.Bands(0).Columns("PrsApart").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("PrsApart").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("PrsApart").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("PrsFalt").Header.Caption = "Prs Falt"
        grid.DisplayLayout.Bands(0).Columns("PrsFalt").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("PrsFalt").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("PrsFalt").Format = "n0"
        'grid.DisplayLayout.Bands(0).Columns("Programa").Header.Caption = "Programa"
        'grid.DisplayLayout.Bands(0).Columns("Programa").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        'grid.DisplayLayout.Bands(0).Columns("Programa").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
        'grid.DisplayLayout.Bands(0).Columns("Nave").Header.Caption = "Nave"
        'grid.DisplayLayout.Bands(0).Columns("Nave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        'grid.DisplayLayout.Bands(0).Columns("Nave").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left

        grid.DisplayLayout.Bands(0).Columns("NombreNave").Header.Caption = "Nave"
        grid.DisplayLayout.Bands(0).Columns("NombreNave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("NombreNave").CharacterCasing = CharacterCasing.Upper

        grid.DisplayLayout.Bands(0).Columns("FechaPrograma").Header.Caption = "Programa"
        grid.DisplayLayout.Bands(0).Columns("FechaPrograma").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit


        'grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
        grid.DisplayLayout.Override.SelectTypeCol = SelectType.None
        'grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        'grid.DisplayLayout.GroupByBox.Hidden = False
        'grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"

        'grid.DisplayLayout.Bands(0).Summaries.Clear()

        'Dim summary1, summary2, summary3, summary4, summary5, summary6, summary7, summary8, summary9, summary10, summary11, summary12, summary13 As SummarySettings
        'summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("PrsPed"))
        'summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Programar", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("PrsProgr"))
        'summary3 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Por Apartar", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("PrsXApart"))
        'summary4 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Atados Normales", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Norm"))
        'summary5 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Atados Punto", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Punt"))
        'summary6 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Destallados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("PrsDest"))
        'summary7 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Atados Completos", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("PrsTotal"))
        'summary8 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Atados Normales Deshacer", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("ANorm"))
        'summary9 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Atados Punto Deshacer", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("APunt"))
        'summary10 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Atados Destallados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("ATotal"))
        'summary11 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Atados Destallados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("PrsTotalAtDest"))
        'summary12 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Apartables", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("PrsApart"))
        'summary13 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Faltantes", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("PrsFalt"))
        'grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        'summary1.DisplayFormat = "{0:#,##0}"
        'summary1.Appearance.TextHAlign = HAlign.Right
        'summary2.DisplayFormat = "{0:#,##0}"
        'summary2.Appearance.TextHAlign = HAlign.Right
        'summary3.DisplayFormat = "{0:#,##0}"
        'summary3.Appearance.TextHAlign = HAlign.Right
        'summary4.DisplayFormat = "{0:#,##0}"
        'summary4.Appearance.TextHAlign = HAlign.Right
        'summary5.DisplayFormat = "{0:#,##0}"
        'summary5.Appearance.TextHAlign = HAlign.Right
        'summary6.DisplayFormat = "{0:#,##0}"
        'summary6.Appearance.TextHAlign = HAlign.Right
        'summary7.DisplayFormat = "{0:#,##0}"
        'summary7.Appearance.TextHAlign = HAlign.Right
        'summary8.DisplayFormat = "{0:#,##0}"
        'summary8.Appearance.TextHAlign = HAlign.Right
        'summary9.DisplayFormat = "{0:#,##0}"
        'summary9.Appearance.TextHAlign = HAlign.Right
        'summary10.DisplayFormat = "{0:#,##0}"
        'summary10.Appearance.TextHAlign = HAlign.Right
        'summary11.DisplayFormat = "{0:#,##0}"
        'summary11.Appearance.TextHAlign = HAlign.Right
        'summary12.DisplayFormat = "{0:#,##0}"
        'summary12.Appearance.TextHAlign = HAlign.Right
        'summary13.DisplayFormat = "{0:#,##0}"
        'summary13.Appearance.TextHAlign = HAlign.Right


        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If

        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
            If renglon.Cells("B3M").Value.ToString() = "SI" Then
                renglon.Cells("B3M").Appearance.ForeColor = lblClienteBloqueado3Meses.ForeColor
                renglon.Cells("Cliente").Appearance.ForeColor = lblClienteBloqueado3Meses.ForeColor
            End If
            If renglon.Cells("M").Value.ToString() = "Or" Then
                renglon.Cells("M").Appearance.BackColor = lblModificacionOrden.BackColor
            End If
            If renglon.Cells("M2").Value.ToString() = "Prs" Then
                renglon.Cells("M2").Appearance.BackColor = lblModificacionPares.BackColor
            End If
            If listaColumnas.Contains("M3") Then
                If renglon.Cells("M3").Value.ToString() = "X" Then
                    renglon.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                End If
            End If
            If renglon.Cells("AP").Value = "C" Then
                renglon.Cells("AP").Appearance.BackColor = lblAPPartidaCompleta.BackColor
            ElseIf renglon.Cells("AP").Value = "P" Then
                renglon.Cells("AP").Appearance.BackColor = lblAPPartidaParcial.BackColor
            End If

            If listaColumnas.Contains("Norm") Then
                If renglon.Cells("Norm").Value = 0 Then
                    renglon.Cells("OK_Normales").Value = False
                    'renglon.Cells("OK_Normales").Hidden = True
                End If
            End If

            If listaColumnas.Contains("Punt") Then
                If renglon.Cells("Punt").Value = 0 Then
                    renglon.Cells("OK_Punto").Value = False
                    'renglon.Cells("OK_Punto").Hidden = True
                End If
            End If
            If listaColumnas.Contains("PrsDest") Then
                If renglon.Cells("PrsDest").Value = 0 Then
                    renglon.Cells("OK_Destallados").Value = False
                    'renglon.Cells("OK_Destallados").Hidden = True
                End If
            End If
            If listaColumnas.Contains("ANorm") Then
                If renglon.Cells("ANorm").Value = 0 Then
                    renglon.Cells("OK_AtadosDestalladosNormales").Value = False
                    'renglon.Cells("OK_AtadosDestalladosNormales").Hidden = True
                End If
            End If
            If listaColumnas.Contains("APunt") Then
                If renglon.Cells("APunt").Value = 0 Then
                    renglon.Cells("OK_AtadosDestalladosPunto").Value = False
                    'renglon.Cells("OK_AtadosDestalladosPunto").Hidden = True
                End If
            End If
            If renglon.Cells("AP").Value = "" Then
                renglon.Appearance.ForeColor = Color.Gray
                renglon.Appearance.BackColor = Color.LightGray
                renglon.Cells("OK_renglonCompleto").Value = False
                renglon.Cells("OK_renglonCompleto").Hidden = True
            End If

            If renglon.Cells("PedidoSAY").Value = 0 Then

                renglon.Appearance.BackColor = Color.SteelBlue

                If listaColumnas.Contains("OK_Normales") Then
                    renglon.Cells("OK_Normales").Hidden = True
                End If
                If listaColumnas.Contains("OK_Punto") Then
                    renglon.Cells("OK_Punto").Hidden = True
                End If
                If listaColumnas.Contains("OK_Destallados") Then
                    renglon.Cells("OK_Destallados").Hidden = True
                End If
                If listaColumnas.Contains("OK_AtadosDestalladosNormales") Then
                    renglon.Cells("OK_AtadosDestalladosNormales").Hidden = True
                End If
                If listaColumnas.Contains("OK_AtadosDestalladosPunto") Then
                    renglon.Cells("OK_AtadosDestalladosPunto").Hidden = True
                End If
                renglon.Cells("OK_renglonCompleto").Hidden = True
                renglon.Cells("PedidoSAY").Hidden = True
                renglon.Cells("PartidaId").Hidden = True

                renglon.Cells("PrsPed").Appearance.BackColor = Color.White
                renglon.Cells("PrsProgr").Appearance.BackColor = Color.White
                renglon.Cells("PrsDisp").Appearance.BackColor = Color.White

                renglon.Cells("PrsXApart").Appearance.BackColor = Color.White

                If listaColumnas.Contains("Norm") Then
                    renglon.Cells("Norm").Appearance.BackColor = Color.White
                End If
                If listaColumnas.Contains("Punt") Then
                    renglon.Cells("Punt").Appearance.BackColor = Color.White
                End If
                If listaColumnas.Contains("PrsDest") Then
                    renglon.Cells("PrsDest").Appearance.BackColor = Color.White
                End If

                If listaColumnas.Contains("PrsTotal") Then
                    renglon.Cells("PrsTotal").Appearance.BackColor = Color.White
                End If

                If listaColumnas.Contains("ANorm") Then
                    renglon.Cells("ANorm").Appearance.BackColor = Color.White
                End If
                If listaColumnas.Contains("APunt") Then
                    renglon.Cells("APunt").Appearance.BackColor = Color.White
                End If

                If listaColumnas.Contains("ATotal") Then
                    renglon.Cells("ATotal").Appearance.BackColor = Color.White
                End If
                If listaColumnas.Contains("PrsTotalAtDest") Then
                    renglon.Cells("PrsTotalAtDest").Appearance.BackColor = Color.White
                End If
                renglon.Cells("PrsApart").Appearance.BackColor = Color.White
                renglon.Cells("PrsFalt").Appearance.BackColor = Color.White

                renglon.Cells("OK_renglonCompleto").Value = False
                If listaColumnas.Contains("OK_Normales") Then
                    renglon.Cells("OK_Normales").Value = False
                End If
                If listaColumnas.Contains("OK_Punto") Then
                    renglon.Cells("OK_Punto").Value = False
                End If
                If listaColumnas.Contains("OK_Destallados") Then
                    renglon.Cells("OK_Destallados").Value = False
                End If
                If listaColumnas.Contains("OK_AtadosDestalladosNormales") Then
                    renglon.Cells("OK_AtadosDestalladosNormales").Value = False
                End If
                If listaColumnas.Contains("OK_AtadosDestalladosPunto") Then
                    renglon.Cells("OK_AtadosDestalladosPunto").Value = False
                End If

                renglon.Cells("M").Hidden = True
                renglon.Cells("M2").Hidden = True
                If listaColumnas.Contains("M3") Then
                    renglon.Cells("M3").Hidden = True
                End If

            End If

            If CBool(renglon.Cells("OK_renglonCompleto").Value) = True Then
                Seleccionados += 1
            End If

            If listaColumnas.Contains("Norm") Then
                TotalAtadosNormalesApartables += renglon.Cells("Norm").Value
            End If
            If listaColumnas.Contains("Punt") Then
                TotalAtadoPuntoApartables += renglon.Cells("Punt").Value
            End If
            If listaColumnas.Contains("PrsDest") Then
                TotalDestalladosApartables += renglon.Cells("PrsDest").Value
            End If
            If listaColumnas.Contains("ANorm") Then
                TotalNormalesDestallar += renglon.Cells("ANorm").Value
            End If
            If listaColumnas.Contains("APunt") Then
                TotalPuntoDestallar += renglon.Cells("APunt").Value
            End If

        Next


        If listaColumnas.Contains("Norm") Then
            If TotalAtadosNormalesApartables = 0 Then
                chboxSeleccionarTodoAtadosNormalesCompletos.Checked = False
                'chboxSeleccionarTodoAtadosNormalesCompletos.Enabled = False
                'Else
                '    chboxSeleccionarTodoAtadosNormalesCompletos.Checked = True
                '    chboxSeleccionarTodoAtadosNormalesCompletos.Enabled = True
            End If
        End If
        If listaColumnas.Contains("Punt") Then
            If TotalAtadoPuntoApartables = 0 Then
                chboxSeleccionarTodoAtadosPuntoCompletos.Checked = False
                ' chboxSeleccionarTodoAtadosPuntoCompletos.Enabled = False
                'Else
                '    chboxSeleccionarTodoAtadosPuntoCompletos.Checked = True
                '    chboxSeleccionarTodoAtadosPuntoCompletos.Enabled = True
            End If
        End If
        If listaColumnas.Contains("PrsDest") Then
            If TotalDestalladosApartables = 0 Then
                chboxSeleccionarTodoParesDestallados.Checked = False
                'chboxSeleccionarTodoParesDestallados.Enabled = False
                'Else
                '    chboxSeleccionarTodoParesDestallados.Checked = True
                '    chboxSeleccionarTodoParesDestallados.Enabled = True
            End If
        End If
        If listaColumnas.Contains("ANorm") Then
            If TotalNormalesDestallar = 0 Then
                chboxSeleccionarTodoAtadosNormalesDestallar.Checked = False
                'chboxSeleccionarTodoAtadosNormalesDestallar.Enabled = False
                'Else
                '    chboxSeleccionarTodoAtadosNormalesDestallar.Checked = True
                '    chboxSeleccionarTodoAtadosNormalesDestallar.Enabled = True
            End If
        End If
        If listaColumnas.Contains("APunt") Then
            If TotalPuntoDestallar = 0 Then
                chboxSeleccionarTodoAtadosPuntoDestallar.Checked = False
                ' chboxSeleccionarTodoAtadosPuntoDestallar.Enabled = False
                'Else
                '    chboxSeleccionarTodoAtadosPuntoDestallar.Checked = True
                '    chboxSeleccionarTodoAtadosPuntoDestallar.Enabled = True
            End If
        End If


        grid.DisplayLayout.Bands(0).Columns("OK_renglonCompleto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        If listaColumnas.Contains("OK_Normales") Then
            grid.DisplayLayout.Bands(0).Columns("OK_Normales").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        End If
        If listaColumnas.Contains("OK_Punto") Then
            grid.DisplayLayout.Bands(0).Columns("OK_Punto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        End If
        If listaColumnas.Contains("OK_Destallados") Then
            grid.DisplayLayout.Bands(0).Columns("OK_Destallados").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        End If
        If listaColumnas.Contains("OK_AtadosDestalladosNormales") Then
            grid.DisplayLayout.Bands(0).Columns("OK_AtadosDestalladosNormales").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        End If
        If listaColumnas.Contains("OK_AtadosDestalladosPunto") Then
            grid.DisplayLayout.Bands(0).Columns("OK_AtadosDestalladosPunto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        End If


        For Each col As UltraGridColumn In grid.DisplayLayout.Bands(0).Columns
            If col.Header.Caption = "M" Or col.Header.Caption = "M2" Or col.Header.Caption = "M3" Or col.Header.Caption = "AP" Then
                col.Width = 30
            Else
                If col.Header.Caption = "TipoN" Or col.Header.Caption = "B3M" Or col.Header.Caption = "Prio" Then
                    col.Width = 40
                Else
                    If col.Header.Caption = "" Then
                        col.Width = 20
                    Else
                        col.Width = col.CalculateAutoResizeWidth(PerformAutoSizeType.AllRowsInBand, True)
                    End If
                End If
            End If
        Next

        lblTotalSeleccionados.Text = Format(Seleccionados, "###,###,##0")
        totalPartidasSeleccionadas = Seleccionados
        lblCantidadPartidasPorApartar.Text = Format(Seleccionados, "###,###,##0")
        lblTiempoPartidasPorApartar.Text = " (" + Math.Round((Seleccionados / 60), 2).ToString() + " m)"
        lblTotalTiempos.Text = "(" + Math.Round(Double.Parse(Replace(Replace(lblTiempoApartadosPorConfirmar.Text, "(", ""), " m)", "")) + Double.Parse(Replace(Replace(lblTiempoPartidasPorApartar.Text, "(", ""), " m)", "")), 2).ToString() + " m)"

    End Sub

#Region "Seleccionar Todo Distribuciones"

    Private Sub chboxSeleccionarTodoAtadosNormalesCompletos_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodoAtadosNormalesCompletos.CheckedChanged
        'Dim Seleccionados As Integer = 0
        Dim totalAtadosCompletosNormales As Integer = 0
        Dim objBu As New Negocios.ApartadosBU
        Cursor = Cursors.WaitCursor
        If chboxSeleccionarTodoAtadosNormalesCompletos.Checked Then
            For Each row As UltraGridRow In grdDatosGenerarApartados.Rows.GetFilteredInNonGroupByRows
                If row.Cells("OK_Normales").Hidden = False Then
                    row.Cells("OK_Normales").Value = True
                    row.Cells("Norm").Appearance.ForeColor = Color.Black
                    'Seleccionados += 1
                    totalAtadosCompletosNormales += row.Cells("Norm").Value

                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Norm").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Norm").Value + row.Cells("Norm").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("NormPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("NormPares").Value + row.Cells("NormPares").Value
                    row.Cells("PrsTotal").Value = row.Cells("PrsTotal").Value + row.Cells("NormPares").Value
                    row.Cells("PrsApart").Value = row.Cells("PrsApart").Value + row.Cells("NormPares").Value
                    row.Cells("PrsFalt").Value = row.Cells("PrsFalt").Value - row.Cells("NormPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - row.Cells("NormPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + row.Cells("NormPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value + row.Cells("NormPares").Value
                    'If (row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 1 Or row.Cells("OK_Normales").Hidden = True) And
                    '   (row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 1 Or row.Cells("OK_Punto").Hidden = True) And
                    '   (row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 1 Or row.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                    '   (row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 1 Or row.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                    If ((row.Cells("OK_Destallados").Hidden = False And row.Cells("OK_Destallados").Value = 1 And row.Cells("PrsDest").Value <> 0) Or (row.Cells("OK_Destallados").Hidden = False And row.Cells("OK_Destallados").Value = 0 And row.Cells("PrsDest").Value = 0) Or row.Cells("OK_Destallados").Hidden = True) And
                        ((row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 1 And row.Cells("Punt").Value <> 0) Or (row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 0 And row.Cells("Punt").Value = 0) Or row.Cells("OK_Punto").Hidden = True) And
                        ((row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 1 And row.Cells("ANorm").Value <> 0) Or (row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 0 And row.Cells("ANorm").Value = 0) Or row.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                        ((row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 1 And row.Cells("APunt").Value <> 0) Or (row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 0 And row.Cells("APunt").Value = 0) Or row.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                        If row.Cells("M3").Value = "X" Then
                            row.Cells("M3").Value = "No"
                            row.Cells("M3").Appearance.BackColor = Nothing
                            objBu.ModificacionesPartidas(row.Cells("PedidoDetalleId").Value.ToString(), row.Cells("Nave").Value.ToString(), row.Cells("ProgramaId").Value.ToString(), 3)
                        End If
                    End If
                    If row.Cells("Norm").Value = 0 Then
                        row.Cells("M3").Value = "X"
                        row.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                        objBu.ModificacionesPartidas(row.Cells("PedidoDetalleId").Value.ToString(), row.Cells("Nave").Value.ToString(), row.Cells("ProgramaId").Value.ToString(), 2)
                    End If
                End If
                If row.Cells("PedidoSAY").Value = 0 Then
                    row.Cells("Norm").Value = totalAtadosCompletosNormales
                End If
            Next
        Else
            'Seleccionados = Integer.Parse(Replace(lblTotalSeleccionados.Text, ",", ""))
            For Each row As UltraGridRow In grdDatosGenerarApartados.Rows.GetFilteredInNonGroupByRows
                If row.Cells("OK_Normales").Hidden = False Then
                    If CBool(row.Cells("OK_Normales").Value) Then
                        row.Cells("OK_Normales").Value = False
                        If row.Cells("Norm").Value > 0 Then
                            row.Cells("Norm").Appearance.ForeColor = Color.Red
                        End If
                        'Seleccionados -= 1

                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Norm").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Norm").Value - row.Cells("Norm").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("NormPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("NormPares").Value - row.Cells("NormPares").Value
                        row.Cells("PrsTotal").Value = row.Cells("PrsTotal").Value - row.Cells("NormPares").Value
                        row.Cells("PrsApart").Value = row.Cells("PrsApart").Value - row.Cells("NormPares").Value
                        row.Cells("PrsFalt").Value = row.Cells("PrsFalt").Value + row.Cells("NormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + row.Cells("NormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - row.Cells("NormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value - row.Cells("NormPares").Value

                        If row.Cells("Norm").Value > 0 Then
                            row.Cells("M3").Value = "X"
                            row.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                            objBu.ModificacionesPartidas(row.Cells("PedidoDetalleId").Value.ToString(), row.Cells("Nave").Value.ToString(), row.Cells("ProgramaId").Value.ToString(), 2)
                        Else
                            If ((row.Cells("OK_Destallados").Hidden = False And row.Cells("OK_Destallados").Value = 1 And row.Cells("PrsDest").Value = 0) Or (row.Cells("OK_Destallados").Hidden = False And row.Cells("OK_Destallados").Value = 0 And row.Cells("PrsDest").Value > 0) Or row.Cells("OK_Destallados").Hidden = True) And
                           ((row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 1 And row.Cells("Punt").Value = 0) Or (row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 0 And row.Cells("Punt").Value > 0) Or row.Cells("OK_Punto").Hidden = True) And
                           ((row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 1 And row.Cells("ANorm").Value = 0) Or (row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 0 And row.Cells("ANorm").Value > 0) Or row.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                           ((row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 1 And row.Cells("APunt").Value = 0) Or (row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 0 And row.Cells("APunt").Value > 0) Or row.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                                If row.Cells("M3").Value = "X" Then
                                    row.Cells("M3").Value = "No"
                                    row.Cells("M3").Appearance.BackColor = Nothing
                                    objBu.ModificacionesPartidas(row.Cells("PedidoDetalleId").Value.ToString(), row.Cells("Nave").Value.ToString(), row.Cells("ProgramaId").Value.ToString(), 2)
                                End If
                            End If
                        End If
                    End If
                End If
                If row.Cells("PedidoSAY").Value = 0 Then
                    row.Cells("Norm").Value = 0
                End If
            Next
        End If
        'lblTotalSeleccionados.Text = Format(Seleccionados, "###,###,##0")
        'totalPartidasSeleccionadas = Seleccionados

        Cursor = Cursors.Default
    End Sub

    Private Sub chboxSeleccionarTodoAtadosPuntoCompletos_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodoAtadosPuntoCompletos.CheckedChanged
        'Dim Seleccionados As Integer = 0
        Dim totalAtadosCompletosPunto As Integer = 0
        Dim objBu As New Negocios.ApartadosBU
        Cursor = Cursors.WaitCursor
        If chboxSeleccionarTodoAtadosPuntoCompletos.Checked Then
            For Each row As UltraGridRow In grdDatosGenerarApartados.Rows.GetFilteredInNonGroupByRows
                If row.Cells("OK_Punto").Hidden = False Then
                    row.Cells("OK_Punto").Value = True
                    row.Cells("Punt").Appearance.ForeColor = Nothing
                    'Seleccionados += 1
                    totalAtadosCompletosPunto += row.Cells("Punt").Value

                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Punt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Punt").Value + row.Cells("Punt").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PuntPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PuntPares").Value + row.Cells("PuntPares").Value
                    row.Cells("PrsTotal").Value = row.Cells("PrsTotal").Value + row.Cells("PuntPares").Value
                    row.Cells("PrsApart").Value = row.Cells("PrsApart").Value + row.Cells("PuntPares").Value
                    row.Cells("PrsFalt").Value = row.Cells("PrsFalt").Value - row.Cells("PuntPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - row.Cells("PuntPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + row.Cells("PuntPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value + row.Cells("PuntPares").Value
                    'If (row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 1 Or row.Cells("OK_Normales").Hidden = True) And
                    '   (row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 1 Or row.Cells("OK_Punto").Hidden = True) And
                    '   (row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 1 Or row.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                    '   (row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 1 Or row.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                    If ((row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 1 And row.Cells("Norm").Value <> 0) Or (row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 0 And row.Cells("Norm").Value = 0) Or row.Cells("OK_Normales").Hidden = True) And
                        ((row.Cells("OK_Destallados").Hidden = False And row.Cells("OK_Destallados").Value = 1 And row.Cells("PrsDest").Value <> 0) Or (row.Cells("OK_Destallados").Hidden = False And row.Cells("OK_Destallados").Value = 0 And row.Cells("PrsDest").Value = 0) Or row.Cells("OK_Destallados").Hidden = True) And
                        ((row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 1 And row.Cells("ANorm").Value <> 0) Or (row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 0 And row.Cells("ANorm").Value = 0) Or row.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                        ((row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 1 And row.Cells("APunt").Value <> 0) Or (row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 0 And row.Cells("APunt").Value = 0) Or row.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                        If row.Cells("M3").Value = "X" Then
                            row.Cells("M3").Value = "No"
                            row.Cells("M3").Appearance.BackColor = Nothing
                            objBu.ModificacionesPartidas(row.Cells("PedidoDetalleId").Value.ToString(), row.Cells("Nave").Value.ToString(), row.Cells("ProgramaId").Value.ToString(), 3)
                        End If
                    End If
                    If row.Cells("Punt").Value = 0 Then
                        row.Cells("M3").Value = "X"
                        row.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                        objBu.ModificacionesPartidas(row.Cells("PedidoDetalleId").Value.ToString(), row.Cells("Nave").Value.ToString(), row.Cells("ProgramaId").Value.ToString(), 2)
                    End If
                End If
                If row.Cells("PedidoSAY").Value = 0 Then
                    row.Cells("Punt").Value = totalAtadosCompletosPunto
                End If
            Next
        Else
            'Seleccionados = Integer.Parse(Replace(lblTotalSeleccionados.Text, ",", ""))
            For Each row As UltraGridRow In grdDatosGenerarApartados.Rows.GetFilteredInNonGroupByRows
                If row.Cells("OK_Punto").Hidden = False Then
                    If CBool(row.Cells("OK_Punto").Value) Then
                        row.Cells("OK_Punto").Value = False
                        If row.Cells("Punt").Value > 0 Then
                            row.Cells("Punt").Appearance.ForeColor = Color.Red
                        End If
                        'Seleccionados -= 1

                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Punt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Punt").Value - row.Cells("Punt").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PuntPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PuntPares").Value - row.Cells("PuntPares").Value
                        row.Cells("PrsTotal").Value = row.Cells("PrsTotal").Value - row.Cells("PuntPares").Value
                        row.Cells("PrsApart").Value = row.Cells("PrsApart").Value - row.Cells("PuntPares").Value
                        row.Cells("PrsFalt").Value = row.Cells("PrsFalt").Value + row.Cells("PuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + row.Cells("PuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - row.Cells("PuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value - row.Cells("PuntPares").Value

                        If row.Cells("Punt").Value > 0 Then
                            row.Cells("M3").Value = "X"
                            row.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                            objBu.ModificacionesPartidas(row.Cells("PedidoDetalleId").Value.ToString(), row.Cells("Nave").Value.ToString(), row.Cells("ProgramaId").Value.ToString(), 2)
                        Else
                            If ((row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 1 And row.Cells("Norm").Value = 0) Or (row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 0 And row.Cells("Norm").Value > 0) Or row.Cells("OK_Normales").Hidden = True) And
                           ((row.Cells("OK_Destallados").Hidden = False And row.Cells("OK_Destallados").Value = 1 And row.Cells("PrsDest").Value = 0) Or (row.Cells("OK_Destallados").Hidden = False And row.Cells("OK_Destallados").Value = 0 And row.Cells("PrsDest").Value > 0) Or row.Cells("OK_Destallados").Hidden = True) And
                           ((row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 1 And row.Cells("ANorm").Value = 0) Or (row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 0 And row.Cells("ANorm").Value > 0) Or row.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                           ((row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 1 And row.Cells("APunt").Value = 0) Or (row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 0 And row.Cells("APunt").Value > 0) Or row.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                                If row.Cells("M3").Value = "X" Then
                                    row.Cells("M3").Value = "No"
                                    row.Cells("M3").Appearance.BackColor = Nothing
                                    objBu.ModificacionesPartidas(row.Cells("PedidoDetalleId").Value.ToString(), row.Cells("Nave").Value.ToString(), row.Cells("ProgramaId").Value.ToString(), 2)
                                End If
                            End If
                        End If
                    End If
                End If
                If row.Cells("PedidoSAY").Value = 0 Then
                    row.Cells("Punt").Value = 0
                End If
            Next
        End If
        'lblTotalSeleccionados.Text = Format(Seleccionados, "###,###,##0")
        'totalPartidasSeleccionadas = Seleccionados

        Cursor = Cursors.Default
    End Sub

    Private Sub chboxSeleccionarTodoParesDestallados_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodoParesDestallados.CheckedChanged
        'Dim Seleccionados As Integer = 0
        Dim totalParesDestallados As Integer = 0
        Dim objBu As New Negocios.ApartadosBU
        Cursor = Cursors.WaitCursor
        If chboxSeleccionarTodoParesDestallados.Checked Then
            For Each row As UltraGridRow In grdDatosGenerarApartados.Rows.GetFilteredInNonGroupByRows
                If row.Cells("OK_Destallados").Hidden = False Then
                    row.Cells("OK_Destallados").Value = True
                    row.Cells("PrsDest").Appearance.ForeColor = Color.Black
                    totalParesDestallados += row.Cells("PrsDest").Value
                    'Seleccionados += 1
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsDest").Value + row.Cells("PrsDest").Value
                    row.Cells("PrsTotal").Value = row.Cells("PrsTotal").Value + row.Cells("PrsDest").Value
                    row.Cells("PrsApart").Value = row.Cells("PrsApart").Value + row.Cells("PrsDest").Value
                    row.Cells("PrsFalt").Value = row.Cells("PrsFalt").Value - row.Cells("PrsDest").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - row.Cells("PrsDest").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + row.Cells("PrsDest").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value + row.Cells("PrsDest").Value
                    'If (row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 1 Or row.Cells("OK_Normales").Hidden = True) And
                    '    (row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 1 Or row.Cells("OK_Punto").Hidden = True) And
                    '    (row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 1 Or row.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                    '    (row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 1 Or row.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                    If ((row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 1 And row.Cells("Norm").Value <> 0) Or (row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 0 And row.Cells("Norm").Value = 0) Or row.Cells("OK_Normales").Hidden = True) And
                        ((row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 1 And row.Cells("Punt").Value <> 0) Or (row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 0 And row.Cells("Punt").Value = 0) Or row.Cells("OK_Punto").Hidden = True) And
                        ((row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 1 And row.Cells("ANorm").Value <> 0) Or (row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 0 And row.Cells("ANorm").Value = 0) Or row.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                        ((row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 1 And row.Cells("APunt").Value <> 0) Or (row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 0 And row.Cells("APunt").Value = 0) Or row.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                        If row.Cells("M3").Value = "X" Then
                            row.Cells("M3").Value = "No"
                            row.Cells("M3").Appearance.BackColor = Nothing
                            objBu.ModificacionesPartidas(row.Cells("PedidoDetalleId").Value.ToString(), row.Cells("Nave").Value.ToString(), row.Cells("ProgramaId").Value.ToString(), 3)
                        End If
                    End If
                    If row.Cells("PrsDest").Value = 0 Then
                        row.Cells("M3").Value = "X"
                        row.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                        objBu.ModificacionesPartidas(row.Cells("PedidoDetalleId").Value.ToString(), row.Cells("Nave").Value.ToString(), row.Cells("ProgramaId").Value.ToString(), 2)
                    End If
                End If
                If row.Cells("PedidoSAY").Value = 0 Then
                    row.Cells("PrsDest").Value = totalParesDestallados
                End If
            Next
        Else
            'Seleccionados = Integer.Parse(Replace(lblTotalSeleccionados.Text, ",", ""))
            For Each row As UltraGridRow In grdDatosGenerarApartados.Rows.GetFilteredInNonGroupByRows
                If row.Cells("OK_Destallados").Hidden = False Then
                    If CBool(row.Cells("OK_Destallados").Value) Then
                        row.Cells("OK_Destallados").Value = False
                        If row.Cells("PrsDest").Value > 0 Then
                            row.Cells("PrsDest").Appearance.ForeColor = Color.Red
                        End If
                        'Seleccionados -= 1
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsDest").Value - row.Cells("PrsDest").Value
                        row.Cells("PrsTotal").Value = row.Cells("PrsTotal").Value - row.Cells("PrsDest").Value
                        row.Cells("PrsApart").Value = row.Cells("PrsApart").Value - row.Cells("PrsDest").Value
                        row.Cells("PrsFalt").Value = row.Cells("PrsFalt").Value + row.Cells("PrsDest").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + row.Cells("PrsDest").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - row.Cells("PrsDest").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value - row.Cells("PrsDest").Value

                        If row.Cells("PrsDest").Value > 0 Then
                            row.Cells("M3").Value = "X"
                            row.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                            objBu.ModificacionesPartidas(row.Cells("PedidoDetalleId").Value.ToString(), row.Cells("Nave").Value.ToString(), row.Cells("ProgramaId").Value.ToString(), 2)
                        Else
                            If ((row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 1 And row.Cells("Norm").Value = 0) Or (row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 0 And row.Cells("Norm").Value > 0) Or row.Cells("OK_Normales").Hidden = True) And
                          ((row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 1 And row.Cells("Punt").Value = 0) Or (row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 0 And row.Cells("Punt").Value > 0) Or row.Cells("OK_Punto").Hidden = True) And
                          ((row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 1 And row.Cells("ANorm").Value = 0) Or (row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 0 And row.Cells("ANorm").Value > 0) Or row.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                          ((row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 1 And row.Cells("APunt").Value = 0) Or (row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 0 And row.Cells("APunt").Value > 0) Or row.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                                If row.Cells("M3").Value = "X" Then
                                    row.Cells("M3").Value = "No"
                                    row.Cells("M3").Appearance.BackColor = Nothing
                                    objBu.ModificacionesPartidas(row.Cells("PedidoDetalleId").Value.ToString(), row.Cells("Nave").Value.ToString(), row.Cells("ProgramaId").Value.ToString(), 2)
                                End If
                            End If
                        End If
                    End If
                End If
                If row.Cells("PedidoSAY").Value = 0 Then
                    row.Cells("PrsDest").Value = 0
                End If
            Next
        End If
        'lblTotalSeleccionados.Text = Format(Seleccionados, "###,###,##0")
        'totalPartidasSeleccionadas = Seleccionados

        Cursor = Cursors.Default
    End Sub

    Private Sub chboxSeleccionarTodoAtadosNormalesDestallar_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodoAtadosNormalesDestallar.CheckedChanged
        'Dim Seleccionados As Integer = 0
        Dim totalAtadosNormalesDestallar As Integer = 0
        Dim objBu As New Negocios.ApartadosBU
        Cursor = Cursors.WaitCursor
        If chboxSeleccionarTodoAtadosNormalesDestallar.Checked Then
            For Each row As UltraGridRow In grdDatosGenerarApartados.Rows.GetFilteredInNonGroupByRows
                If row.Cells("OK_AtadosDestalladosNormales").Hidden = False Then
                    row.Cells("OK_AtadosDestalladosNormales").Value = True
                    row.Cells("ANorm").Appearance.ForeColor = Nothing
                    'Seleccionados += 1
                    totalAtadosNormalesDestallar += row.Cells("ANorm").Value

                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANorm").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANorm").Value + row.Cells("ANorm").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANormPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANormPares").Value + row.Cells("ANormPares").Value
                    row.Cells("ATotal").Value = row.Cells("ATotal").Value + row.Cells("ANorm").Value
                    row.Cells("PrsTotalAtDest").Value = row.Cells("PrsTotalAtDest").Value + row.Cells("ANormPares").Value
                    row.Cells("PrsApart").Value = row.Cells("PrsApart").Value + row.Cells("ANormPares").Value
                    row.Cells("PrsFalt").Value = row.Cells("PrsFalt").Value - row.Cells("ANormPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value + row.Cells("ANorm").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - row.Cells("ANormPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + row.Cells("ANormPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value + row.Cells("ANormPares").Value
                    'If (row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 1 Or row.Cells("OK_Normales").Hidden = True) And
                    '   (row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 1 Or row.Cells("OK_Punto").Hidden = True) And
                    '   (row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 1 Or row.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                    '   (row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 1 Or row.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                    If ((row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 1 And row.Cells("Norm").Value <> 0) Or (row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 0 And row.Cells("Norm").Value = 0) Or row.Cells("OK_Normales").Hidden = True) And
                        ((row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 1 And row.Cells("Punt").Value <> 0) Or (row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 0 And row.Cells("Punt").Value = 0) Or row.Cells("OK_Punto").Hidden = True) And
                        ((row.Cells("OK_Destallados").Hidden = False And row.Cells("OK_Destallados").Value = 1 And row.Cells("PrsDest").Value <> 0) Or (row.Cells("OK_Destallados").Hidden = False And row.Cells("OK_Destallados").Value = 0 And row.Cells("PrsDest").Value = 0) Or row.Cells("OK_Destallados").Hidden = True) And
                        ((row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 1 And row.Cells("APunt").Value <> 0) Or (row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 0 And row.Cells("APunt").Value = 0) Or row.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                        If row.Cells("M3").Value = "X" Then
                            row.Cells("M3").Value = "No"
                            row.Cells("M3").Appearance.BackColor = Nothing
                            objBu.ModificacionesPartidas(row.Cells("PedidoDetalleId").Value.ToString(), row.Cells("Nave").Value.ToString(), row.Cells("ProgramaId").Value.ToString(), 3)
                        End If
                    End If
                    If row.Cells("ANorm").Value = 0 Then
                        row.Cells("M3").Value = "X"
                        row.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                        objBu.ModificacionesPartidas(row.Cells("PedidoDetalleId").Value.ToString(), row.Cells("Nave").Value.ToString(), row.Cells("ProgramaId").Value.ToString(), 2)
                    End If
                End If
                If row.Cells("PedidoSAY").Value = 0 Then
                    row.Cells("ANorm").Value = totalAtadosNormalesDestallar
                End If
            Next
        Else
            'Seleccionados = Integer.Parse(Replace(lblTotalSeleccionados.Text, ",", ""))
            For Each row As UltraGridRow In grdDatosGenerarApartados.Rows.GetFilteredInNonGroupByRows
                If row.Cells("OK_AtadosDestalladosNormales").Hidden = False Then
                    If CBool(row.Cells("OK_AtadosDestalladosNormales").Value) Then
                        row.Cells("OK_AtadosDestalladosNormales").Value = False

                        If row.Cells("ANorm").Value > 0 Then
                            row.Cells("ANorm").Appearance.ForeColor = Color.Red
                        End If
                        'Seleccionados -= 1
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANorm").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANorm").Value - row.Cells("ANorm").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANormPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANormPares").Value - row.Cells("ANormPares").Value
                        row.Cells("ATotal").Value = row.Cells("ATotal").Value - row.Cells("ANorm").Value
                        row.Cells("PrsTotalAtDest").Value = row.Cells("PrsTotalAtDest").Value - row.Cells("ANormPares").Value
                        row.Cells("PrsApart").Value = row.Cells("PrsApart").Value - row.Cells("ANormPares").Value
                        row.Cells("PrsFalt").Value = row.Cells("PrsFalt").Value + row.Cells("ANormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value - row.Cells("ANorm").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + row.Cells("ANormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - row.Cells("ANormPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value - row.Cells("ANormPares").Value

                        If row.Cells("ANorm").Value > 0 Then
                            row.Cells("M3").Value = "X"
                            row.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                            objBu.ModificacionesPartidas(row.Cells("PedidoDetalleId").Value.ToString(), row.Cells("Nave").Value.ToString(), row.Cells("ProgramaId").Value.ToString(), 2)
                        Else
                            If ((row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 1 And row.Cells("Norm").Value = 0) Or (row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 0 And row.Cells("Norm").Value > 0) Or row.Cells("OK_Normales").Hidden = True) And
                          ((row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 1 And row.Cells("Punt").Value = 0) Or (row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 0 And row.Cells("Punt").Value > 0) Or row.Cells("OK_Punto").Hidden = True) And
                          ((row.Cells("OK_Destallados").Hidden = False And row.Cells("OK_Destallados").Value = 1 And row.Cells("PrsDest").Value = 0) Or (row.Cells("OK_Destallados").Hidden = False And row.Cells("OK_Destallados").Value = 0 And row.Cells("PrsDest").Value > 0) Or row.Cells("OK_Destallados").Hidden = True) And
                          ((row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 1 And row.Cells("APunt").Value = 0) Or (row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 0 And row.Cells("APunt").Value > 0) Or row.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                                If row.Cells("M3").Value = "X" Then
                                    row.Cells("M3").Value = "No"
                                    row.Cells("M3").Appearance.BackColor = Nothing
                                    objBu.ModificacionesPartidas(row.Cells("PedidoDetalleId").Value.ToString(), row.Cells("Nave").Value.ToString(), row.Cells("ProgramaId").Value.ToString(), 2)
                                End If
                            End If
                        End If
                    End If
                End If
                If row.Cells("PedidoSAY").Value = 0 Then
                    row.Cells("ANorm").Value = 0
                End If
            Next
        End If
        'lblTotalSeleccionados.Text = Format(Seleccionados, "###,###,##0")
        'totalPartidasSeleccionadas = Seleccionados

        Cursor = Cursors.Default
    End Sub

    Private Sub chboxSeleccionarTodoAtadosPuntoDestallar_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodoAtadosPuntoDestallar.CheckedChanged
        'Dim Seleccionados As Integer = 0
        Dim totalAtadosPuntoDestallar As Integer = 0
        Dim objBu As New Negocios.ApartadosBU
        Cursor = Cursors.WaitCursor
        If chboxSeleccionarTodoAtadosPuntoDestallar.Checked Then
            For Each row As UltraGridRow In grdDatosGenerarApartados.Rows.GetFilteredInNonGroupByRows
                If row.Cells("OK_AtadosDestalladosPunto").Hidden = False Then
                    row.Cells("OK_AtadosDestalladosPunto").Value = True
                    row.Cells("APunt").Appearance.ForeColor = Nothing
                    'Seleccionados += 1
                    totalAtadosPuntoDestallar += row.Cells("APunt").Value

                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APunt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APunt").Value + row.Cells("APunt").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APuntPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APuntPares").Value + row.Cells("APuntPares").Value
                    row.Cells("ATotal").Value = row.Cells("ATotal").Value + row.Cells("APunt").Value
                    row.Cells("PrsTotalAtDest").Value = row.Cells("PrsTotalAtDest").Value + row.Cells("APuntPares").Value
                    row.Cells("PrsApart").Value = row.Cells("PrsApart").Value + row.Cells("APuntPares").Value
                    row.Cells("PrsFalt").Value = row.Cells("PrsFalt").Value - row.Cells("APuntPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value + row.Cells("APunt").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - row.Cells("APuntPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + row.Cells("APuntPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value + row.Cells("APuntPares").Value
                    'If (row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 1 Or row.Cells("OK_Normales").Hidden = True) And
                    '   (row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 1 Or row.Cells("OK_Punto").Hidden = True) And
                    '   (row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 1 Or row.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                    '   (row.Cells("OK_AtadosDestalladosPunto").Hidden = False And row.Cells("OK_AtadosDestalladosPunto").Value = 1 Or row.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                    If ((row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 1 And row.Cells("Norm").Value <> 0) Or (row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 0 And row.Cells("Norm").Value = 0) Or row.Cells("OK_Normales").Hidden = True) And
                        ((row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 1 And row.Cells("Punt").Value <> 0) Or (row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 0 And row.Cells("Punt").Value = 0) Or row.Cells("OK_Punto").Hidden = True) And
                        ((row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 1 And row.Cells("ANorm").Value <> 0) Or (row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 0 And row.Cells("ANorm").Value = 0) Or row.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                        ((row.Cells("OK_Destallados").Hidden = False And row.Cells("OK_Destallados").Value = 1 And row.Cells("PrsDest").Value <> 0) Or (row.Cells("OK_Destallados").Hidden = False And row.Cells("OK_Destallados").Value = 0 And row.Cells("PrsDest").Value = 0) Or row.Cells("OK_Destallados").Hidden = True) Then
                        If row.Cells("M3").Value = "X" Then
                            row.Cells("M3").Value = "No"
                            row.Cells("M3").Appearance.BackColor = Nothing
                            objBu.ModificacionesPartidas(row.Cells("PedidoDetalleId").Value.ToString(), row.Cells("Nave").Value.ToString(), row.Cells("ProgramaId").Value.ToString(), 3)
                        End If
                    End If
                    If row.Cells("APunt").Value = 0 Then
                        row.Cells("M3").Value = "X"
                        row.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                        objBu.ModificacionesPartidas(row.Cells("PedidoDetalleId").Value.ToString(), row.Cells("Nave").Value.ToString(), row.Cells("ProgramaId").Value.ToString(), 2)
                    End If
                End If
                If row.Cells("PedidoSAY").Value = 0 Then
                    row.Cells("APunt").Value = totalAtadosPuntoDestallar
                End If
            Next
        Else
            'Seleccionados = Integer.Parse(Replace(lblTotalSeleccionados.Text, ",", ""))
            For Each row As UltraGridRow In grdDatosGenerarApartados.Rows.GetFilteredInNonGroupByRows
                If row.Cells("OK_AtadosDestalladosPunto").Hidden = False Then
                    If CBool(row.Cells("OK_AtadosDestalladosPunto").Value) Then
                        row.Cells("OK_AtadosDestalladosPunto").Value = False
                        If row.Cells("APunt").Value > 0 Then
                            row.Cells("APunt").Appearance.ForeColor = Color.Red
                        End If
                        'Seleccionados -= 1

                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APunt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APunt").Value - row.Cells("APunt").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APuntPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APuntPares").Value - row.Cells("APuntPares").Value
                        row.Cells("ATotal").Value = row.Cells("ATotal").Value - row.Cells("APunt").Value
                        row.Cells("PrsTotalAtDest").Value = row.Cells("PrsTotalAtDest").Value - row.Cells("APuntPares").Value
                        row.Cells("PrsApart").Value = row.Cells("PrsApart").Value - row.Cells("APuntPares").Value
                        row.Cells("PrsFalt").Value = row.Cells("PrsFalt").Value + row.Cells("APuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value - row.Cells("APunt").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + row.Cells("APuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - row.Cells("APuntPares").Value
                        grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value - row.Cells("APuntPares").Value
                        If row.Cells("APunt").Value > 0 Then
                            row.Cells("M3").Value = "X"
                            row.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                            objBu.ModificacionesPartidas(row.Cells("PedidoDetalleId").Value.ToString(), row.Cells("Nave").Value.ToString(), row.Cells("ProgramaId").Value.ToString(), 2)
                        Else
                            If ((row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 1 And row.Cells("Norm").Value = 0) Or (row.Cells("OK_Normales").Hidden = False And row.Cells("OK_Normales").Value = 0 And row.Cells("Norm").Value > 0) Or row.Cells("OK_Normales").Hidden = True) And
                          ((row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 1 And row.Cells("Punt").Value = 0) Or (row.Cells("OK_Punto").Hidden = False And row.Cells("OK_Punto").Value = 0 And row.Cells("Punt").Value > 0) Or row.Cells("OK_Punto").Hidden = True) And
                          ((row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 1 And row.Cells("ANorm").Value = 0) Or (row.Cells("OK_AtadosDestalladosNormales").Hidden = False And row.Cells("OK_AtadosDestalladosNormales").Value = 0 And row.Cells("ANorm").Value > 0) Or row.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                          ((row.Cells("OK_Destallados").Hidden = False And row.Cells("OK_Destallados").Value = 1 And row.Cells("PrsDest").Value = 0) Or (row.Cells("OK_Destallados").Hidden = False And row.Cells("OK_Destallados").Value = 0 And row.Cells("PrsDest").Value > 0) Or row.Cells("OK_Destallados").Hidden = True) Then
                                If row.Cells("M3").Value = "X" Then
                                    row.Cells("M3").Value = "No"
                                    row.Cells("M3").Appearance.BackColor = Nothing
                                    objBu.ModificacionesPartidas(row.Cells("PedidoDetalleId").Value.ToString(), row.Cells("Nave").Value.ToString(), row.Cells("ProgramaId").Value.ToString(), 2)
                                End If
                            End If
                        End If
                    End If
                End If
                If row.Cells("PedidoSAY").Value = 0 Then
                    row.Cells("APunt").Value = 0
                End If
            Next
        End If
        'lblTotalSeleccionados.Text = Format(Seleccionados, "###,###,##0")
        'totalPartidasSeleccionadas = Seleccionados

        Cursor = Cursors.Default
    End Sub

#End Region

    Private Sub chboxMostrarPartidasSinInventario_CheckedChanged(sender As Object, e As EventArgs) Handles chboxMostrarPartidasSinInventario.CheckedChanged
        Dim total_PrsPed As Integer = 0
        Dim total_PrsProgr As Integer = 0
        Dim total_PrsDisp As Integer = 0
        Dim total_PrsXApart As Integer = 0
        Dim total_Norm As Integer = 0
        Dim total_Punt As Integer = 0
        Dim total_PrsDest As Integer = 0
        Dim total_PrsTotal As Integer = 0
        Dim total_ANorm As Integer = 0
        Dim total_APunt As Integer = 0
        Dim total_ATotal As Integer = 0
        Dim total_PrsTotalAtDest As Integer = 0
        Dim total_PrsApart As Integer = 0
        Dim total_PrsFalt As Integer = 0
        Dim listaColumnas As New List(Of String)

        For Each col As UltraGridColumn In grdDatosGenerarApartados.DisplayLayout.Bands(0).Columns
            listaColumnas.Add(col.Key.ToString())
        Next

        If chboxMostrarPartidasSinInventario.Checked = False Then
            For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
                If renglon.Cells("PrsApart").Value = 0 Then
                    renglon.Hidden = True
                ElseIf renglon.Cells("PedidoSAY").Value <> 0 Then
                    total_PrsPed += renglon.Cells("PrsPed").Value
                    total_PrsProgr += renglon.Cells("PrsProgr").Value
                    total_PrsDisp += renglon.Cells("PrsDisp").Value
                    total_PrsXApart += renglon.Cells("PrsXApart").Value
                    If listaColumnas.Contains("Norm") Then
                        total_Norm += renglon.Cells("Norm").Value
                    End If
                    If listaColumnas.Contains("Punt") Then
                        total_Punt += renglon.Cells("Punt").Value
                    End If
                    If listaColumnas.Contains("PrsDest") Then
                        total_PrsDest += renglon.Cells("PrsDest").Value
                    End If
                    If listaColumnas.Contains("PrsTotal") Then
                        total_PrsTotal += renglon.Cells("PrsTotal").Value
                    End If
                    If listaColumnas.Contains("ANorm") Then
                        total_ANorm += renglon.Cells("ANorm").Value
                    End If
                    If listaColumnas.Contains("APunt") Then
                        total_APunt += renglon.Cells("APunt").Value
                    End If
                    If listaColumnas.Contains("ATotal") Then
                        total_ATotal += renglon.Cells("ATotal").Value
                    End If
                    If listaColumnas.Contains("PrsTotalAtDest") Then
                        total_PrsTotalAtDest += renglon.Cells("PrsTotalAtDest").Value
                    End If
                    total_PrsApart += renglon.Cells("PrsApart").Value
                    total_PrsFalt += renglon.Cells("PrsFalt").Value

                ElseIf renglon.Cells("PedidoSAY").Value = 0 Then
                    renglon.Cells("PrsPed").Value = total_PrsPed
                    renglon.Cells("PrsProgr").Value = total_PrsProgr
                    renglon.Cells("PrsDisp").Value = total_PrsDisp
                    renglon.Cells("PrsXApart").Value = total_PrsXApart
                    If listaColumnas.Contains("Norm") Then
                        renglon.Cells("Norm").Value = total_Norm
                    End If
                    If listaColumnas.Contains("Punt") Then
                        renglon.Cells("Punt").Value = total_Punt
                    End If
                    If listaColumnas.Contains("PrsDest") Then
                        renglon.Cells("PrsDest").Value = total_PrsDest
                    End If
                    If listaColumnas.Contains("PrsTotal") Then
                        renglon.Cells("PrsTotal").Value = total_PrsTotal
                    End If
                    If listaColumnas.Contains("ANorm") Then
                        renglon.Cells("ANorm").Value = total_ANorm
                    End If
                    If listaColumnas.Contains("APunt") Then
                        renglon.Cells("APunt").Value = total_APunt
                    End If
                    If listaColumnas.Contains("ATotal") Then
                        renglon.Cells("ATotal").Value = total_ATotal
                    End If
                    If listaColumnas.Contains("PrsTotalAtDest") Then
                        renglon.Cells("PrsTotalAtDest").Value = total_PrsTotalAtDest
                    End If
                    renglon.Cells("PrsApart").Value = total_PrsApart
                    renglon.Cells("PrsFalt").Value = total_PrsFalt
                End If
            Next
        ElseIf chboxMostrarPartidasSinInventario.Checked = True Then
            For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
                If renglon.Cells("PrsApart").Value = 0 Then
                    renglon.Hidden = False
                End If
                If renglon.Cells("PedidoSAY").Value <> 0 Then
                    total_PrsPed += renglon.Cells("PrsPed").Value
                    total_PrsProgr += renglon.Cells("PrsProgr").Value
                    total_PrsDisp += renglon.Cells("PrsDisp").Value
                    total_PrsXApart += renglon.Cells("PrsXApart").Value
                    If listaColumnas.Contains("Norm") Then
                        total_Norm += renglon.Cells("Norm").Value
                    End If
                    If listaColumnas.Contains("Punt") Then
                        total_Punt += renglon.Cells("Punt").Value
                    End If
                    If listaColumnas.Contains("PrsDest") Then
                        total_PrsDest += renglon.Cells("PrsDest").Value
                    End If
                    If listaColumnas.Contains("PrsTotal") Then
                        total_PrsTotal += renglon.Cells("PrsTotal").Value
                    End If
                    If listaColumnas.Contains("ANorm") Then
                        total_ANorm += renglon.Cells("ANorm").Value
                    End If
                    If listaColumnas.Contains("APunt") Then
                        total_APunt += renglon.Cells("APunt").Value
                    End If
                    If listaColumnas.Contains("ATotal") Then
                        total_ATotal += renglon.Cells("ATotal").Value
                    End If
                    If listaColumnas.Contains("PrsTotalAtDest") Then
                        total_PrsTotalAtDest += renglon.Cells("PrsTotalAtDest").Value
                    End If
                    total_PrsApart += renglon.Cells("PrsApart").Value
                    total_PrsFalt += renglon.Cells("PrsFalt").Value

                ElseIf renglon.Cells("PedidoSAY").Value = 0 Then
                    renglon.Cells("PrsPed").Value = total_PrsPed
                    renglon.Cells("PrsProgr").Value = total_PrsProgr
                    renglon.Cells("PrsDisp").Value = total_PrsDisp
                    renglon.Cells("PrsXApart").Value = total_PrsXApart
                    If listaColumnas.Contains("Norm") Then
                        renglon.Cells("Norm").Value = total_Norm
                    End If
                    If listaColumnas.Contains("Punt") Then
                        renglon.Cells("Punt").Value = total_Punt
                    End If
                    If listaColumnas.Contains("PrsDest") Then
                        renglon.Cells("PrsDest").Value = total_PrsDest
                    End If
                    If listaColumnas.Contains("PrsTotal") Then
                        renglon.Cells("PrsTotal").Value = total_PrsTotal
                    End If
                    If listaColumnas.Contains("ANorm") Then
                        renglon.Cells("ANorm").Value = total_ANorm
                    End If
                    If listaColumnas.Contains("APunt") Then
                        renglon.Cells("APunt").Value = total_APunt
                    End If
                    If listaColumnas.Contains("ATotal") Then
                        renglon.Cells("ATotal").Value = total_ATotal
                    End If
                    If listaColumnas.Contains("PrsTotalAtDest") Then
                        renglon.Cells("PrsTotalAtDest").Value = total_PrsTotalAtDest
                    End If
                    renglon.Cells("PrsApart").Value = total_PrsApart
                    renglon.Cells("PrsFalt").Value = total_PrsFalt
                End If
            Next
        End If
    End Sub

#Region "Opciones Clic Derecho"

    Private Sub tsmiAgregarSelecciónDestallados_Click(sender As Object, e As EventArgs) Handles tsmiAgregarSelecciónDestallados.Click
        Dim objBu As New Negocios.ApartadosBU
        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
            If listRenglonesSeleccionados.Contains(renglon.Index) Then
                If renglon.Cells("OK_Destallados").Value = 0 Then
                    renglon.Cells("OK_Destallados").Value = 1

                    renglon.Cells("PrsDest").Appearance.ForeColor = Nothing
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsDest").Value + renglon.Cells("PrsDest").Value
                    renglon.Cells("PrsTotal").Value = renglon.Cells("PrsTotal").Value + renglon.Cells("PrsDest").Value
                    renglon.Cells("PrsApart").Value = renglon.Cells("PrsApart").Value + renglon.Cells("PrsDest").Value
                    renglon.Cells("PrsFalt").Value = renglon.Cells("PrsFalt").Value - renglon.Cells("PrsDest").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - renglon.Cells("PrsDest").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + renglon.Cells("PrsDest").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value + renglon.Cells("PrsDest").Value
                    If ((renglon.Cells("OK_Normales").Hidden = False And renglon.Cells("OK_Normales").Value = 1 And renglon.Cells("Norm").Value <> 0) Or (renglon.Cells("OK_Normales").Hidden = False And renglon.Cells("OK_Normales").Value = 0 And renglon.Cells("Norm").Value = 0) Or renglon.Cells("OK_Normales").Hidden = True) And
                            ((renglon.Cells("OK_Punto").Hidden = False And renglon.Cells("OK_Punto").Value = 1 And renglon.Cells("pUNT").Value <> 0) Or (renglon.Cells("OK_Punto").Hidden = False And renglon.Cells("OK_Punto").Value = 0 And renglon.Cells("Punt").Value = 0) Or renglon.Cells("OK_Punto").Hidden = True) And
                            ((renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And renglon.Cells("OK_AtadosDestalladosNormales").Value = 1 And renglon.Cells("ANorm").Value <> 0) Or (renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And renglon.Cells("OK_AtadosDestalladosNormales").Value = 0 And renglon.Cells("ANorm").Value = 0) Or renglon.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                            ((renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And renglon.Cells("OK_AtadosDestalladosPunto").Value = 1 And renglon.Cells("APunt").Value <> 0) Or (renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And renglon.Cells("OK_AtadosDestalladosPunto").Value = 0 And renglon.Cells("APunt").Value = 0) Or renglon.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                        If renglon.Cells("M3").Value = "X" Then
                            renglon.Cells("M3").Value = "No"
                            renglon.Cells("M3").Appearance.BackColor = Nothing
                            objBu.ModificacionesPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), 3)
                        End If
                    End If
                    If renglon.Cells("PrsDest").Value = 0 Then
                        renglon.Cells("M3").Value = "X"
                        renglon.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                        objBu.ModificacionesPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), 2)
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub tsmiQuitarSelecciónDestallados_Click(sender As Object, e As EventArgs) Handles tsmiQuitarSelecciónDestallados.Click
        Dim objBu As New Negocios.ApartadosBU
        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
            If listRenglonesSeleccionados.Contains(renglon.Index) Then
                If renglon.Cells("OK_Destallados").Value = 1 Then
                    renglon.Cells("OK_Destallados").Value = 0
                    If renglon.Cells("PrsDest").Value > 0 Then
                        renglon.Cells("PrsDest").Appearance.ForeColor = Color.Red
                    End If
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsDest").Value - renglon.Cells("PrsDest").Value
                    renglon.Cells("PrsTotal").Value = renglon.Cells("PrsTotal").Value - renglon.Cells("PrsDest").Value
                    renglon.Cells("PrsApart").Value = renglon.Cells("PrsApart").Value - renglon.Cells("PrsDest").Value
                    renglon.Cells("PrsFalt").Value = renglon.Cells("PrsFalt").Value + renglon.Cells("PrsDest").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + renglon.Cells("PrsDest").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - renglon.Cells("PrsDest").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value - renglon.Cells("PrsDest").Value
                    If renglon.Cells("PrsDest").Value > 0 Then
                        renglon.Cells("M3").Value = "X"
                        renglon.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                        objBu.ModificacionesPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), 2)
                    Else
                        If ((renglon.Cells("OK_Normales").Hidden = False And renglon.Cells("OK_Normales").Value = 1 And renglon.Cells("Norm").Value = 0) Or (renglon.Cells("OK_Normales").Hidden = False And renglon.Cells("OK_Normales").Value = 0 And renglon.Cells("Norm").Value > 0) Or renglon.Cells("OK_Normales").Hidden = True) And
                           ((renglon.Cells("OK_Punto").Hidden = False And renglon.Cells("OK_Punto").Value = 1 And renglon.Cells("Punt").Value = 0) Or (renglon.Cells("OK_Punto").Hidden = False And renglon.Cells("OK_Punto").Value = 0 And renglon.Cells("Punt").Value > 0) Or renglon.Cells("OK_Punto").Hidden = True) And
                           ((renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And renglon.Cells("OK_AtadosDestalladosNormales").Value = 1 And renglon.Cells("ANorm").Value = 0) Or (renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And renglon.Cells("OK_AtadosDestalladosNormales").Value = 0 And renglon.Cells("ANorm").Value > 0) Or renglon.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                           ((renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And renglon.Cells("OK_AtadosDestalladosPunto").Value = 1 And renglon.Cells("APunt").Value = 0) Or (renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And renglon.Cells("OK_AtadosDestalladosPunto").Value = 0 And renglon.Cells("APunt").Value > 0) Or renglon.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                            If renglon.Cells("M3").Value = "X" Then
                                renglon.Cells("M3").Value = "No"
                                renglon.Cells("M3").Appearance.BackColor = Nothing
                                objBu.ModificacionesPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), 2)
                            End If
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub tsmiAgregarSeleccionAtadosPunto_Click(sender As Object, e As EventArgs) Handles tsmiAgregarSeleccionAtadosPunto.Click
        Dim objBu As New Negocios.ApartadosBU
        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
            If listRenglonesSeleccionados.Contains(renglon.Index) Then
                If renglon.Cells("OK_Punto").Value = 0 Then
                    renglon.Cells("OK_Punto").Value = 1
                    renglon.Cells("Punt").Appearance.ForeColor = Nothing
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Punt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Punt").Value + renglon.Cells("Punt").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PuntPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PuntPares").Value + renglon.Cells("PuntPares").Value
                    renglon.Cells("PrsTotal").Value = renglon.Cells("PrsTotal").Value + renglon.Cells("PuntPares").Value
                    renglon.Cells("PrsApart").Value = renglon.Cells("PrsApart").Value + renglon.Cells("PuntPares").Value
                    renglon.Cells("PrsFalt").Value = renglon.Cells("PrsFalt").Value - renglon.Cells("PuntPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - renglon.Cells("PuntPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + renglon.Cells("PuntPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value + renglon.Cells("PuntPares").Value
                    'If (renglon.Cells("OK_Normales").Hidden = False And renglon.Cells("OK_Normales").Value = 1 Or renglon.Cells("OK_Normales").Hidden = True) And
                    '        (renglon.Cells("OK_Punto").Hidden = False And renglon.Cells("OK_Punto").Value = 1 Or renglon.Cells("OK_Punto").Hidden = True) And
                    '        (renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And renglon.Cells("OK_AtadosDestalladosNormales").Value = 1 Or renglon.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                    '        (renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And renglon.Cells("OK_AtadosDestalladosPunto").Value = 1 Or renglon.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                    If ((renglon.Cells("OK_Normales").Hidden = False And renglon.Cells("OK_Normales").Value = 1 And renglon.Cells("Norm").Value <> 0) Or (renglon.Cells("OK_Normales").Hidden = False And renglon.Cells("OK_Normales").Value = 0 And renglon.Cells("Norm").Value = 0) Or renglon.Cells("OK_Normales").Hidden = True) And
                            ((renglon.Cells("OK_Destallados").Hidden = False And renglon.Cells("OK_Destallados").Value = 1 And renglon.Cells("PrsDest").Value <> 0) Or (renglon.Cells("PrsDest").Hidden = False And renglon.Cells("OK_Destallados").Value = 0 And renglon.Cells("PrsDest").Value = 0) Or renglon.Cells("OK_Destallados").Hidden = True) And
                            ((renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And renglon.Cells("OK_AtadosDestalladosNormales").Value = 1 And renglon.Cells("ANorm").Value <> 0) Or (renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And renglon.Cells("OK_AtadosDestalladosNormales").Value = 0 And renglon.Cells("ANorm").Value = 0) Or renglon.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                            ((renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And renglon.Cells("OK_AtadosDestalladosPunto").Value = 1 And renglon.Cells("APunt").Value <> 0) Or (renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And renglon.Cells("OK_AtadosDestalladosPunto").Value = 0 And renglon.Cells("APunt").Value = 0) Or renglon.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                        If renglon.Cells("M3").Value = "X" Then
                            renglon.Cells("M3").Value = "No"
                            renglon.Cells("M3").Appearance.BackColor = Nothing
                            objBu.ModificacionesPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), 3)
                        End If
                    End If
                    If renglon.Cells("Punt").Value = 0 Then
                        renglon.Cells("M3").Value = "X"
                        renglon.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                        objBu.ModificacionesPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), 2)
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub tsmiQuitarSeleccionAtadosPunto_Click(sender As Object, e As EventArgs) Handles tsmiQuitarSeleccionAtadosPunto.Click
        Dim objBu As New Negocios.ApartadosBU
        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
            If listRenglonesSeleccionados.Contains(renglon.Index) Then
                If renglon.Cells("OK_Punto").Value = 1 Then
                    renglon.Cells("OK_Punto").Value = 0
                    If renglon.Cells("Punt").Value > 0 Then
                        renglon.Cells("Punt").Appearance.ForeColor = Color.Red
                    End If
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Punt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Punt").Value - renglon.Cells("Punt").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PuntPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PuntPares").Value - renglon.Cells("PuntPares").Value
                    renglon.Cells("PrsTotal").Value = renglon.Cells("PrsTotal").Value - renglon.Cells("PuntPares").Value
                    renglon.Cells("PrsApart").Value = renglon.Cells("PrsApart").Value - renglon.Cells("PuntPares").Value
                    renglon.Cells("PrsFalt").Value = renglon.Cells("PrsFalt").Value + renglon.Cells("PuntPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + renglon.Cells("PuntPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - renglon.Cells("PuntPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value - renglon.Cells("PuntPares").Value

                    If renglon.Cells("Punt").Value > 0 Then
                        renglon.Cells("M3").Value = "X"
                        renglon.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                        objBu.ModificacionesPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), 2)
                    Else
                        If ((renglon.Cells("OK_Normales").Hidden = False And renglon.Cells("OK_Normales").Value = 1 And renglon.Cells("Norm").Value > 0) Or (renglon.Cells("OK_Normales").Hidden = False And renglon.Cells("OK_Normales").Value = 0 And renglon.Cells("Norm").Value > 0) Or renglon.Cells("OK_Normales").Hidden = True) And
                           ((renglon.Cells("OK_Destallados").Hidden = False And renglon.Cells("OK_Destallados").Value = 1 And renglon.Cells("PrsDest").Value > 0) Or (renglon.Cells("OK_Destallados").Hidden = False And renglon.Cells("OK_Destallados").Value = 0 And renglon.Cells("PrsDest").Value > 0) Or renglon.Cells("OK_Destallados").Hidden = True) And
                           ((renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And renglon.Cells("OK_AtadosDestalladosNormales").Value = 1 And renglon.Cells("ANorm").Value > 0) Or (renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And renglon.Cells("OK_AtadosDestalladosNormales").Value = 0 And renglon.Cells("ANorm").Value > 0) Or renglon.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                           ((renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And renglon.Cells("OK_AtadosDestalladosPunto").Value = 1 And renglon.Cells("APunt").Value > 0) Or (renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And renglon.Cells("OK_AtadosDestalladosPunto").Value = 0 And renglon.Cells("APunt").Value > 0) Or renglon.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                            If renglon.Cells("M3").Value = "X" Then
                                renglon.Cells("M3").Value = "No"
                                renglon.Cells("M3").Appearance.BackColor = Nothing
                                objBu.ModificacionesPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), 2)
                            End If
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub tsmiAgregarSelecciónDestallarNormales_Click(sender As Object, e As EventArgs) Handles tsmiAgregarSelecciónDestallarNormales.Click
        Dim objBu As New Negocios.ApartadosBU
        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
            If listRenglonesSeleccionados.Contains(renglon.Index) Then
                If renglon.Cells("OK_AtadosDestalladosNormales").Value = 0 Then
                    renglon.Cells("OK_AtadosDestalladosNormales").Value = 1
                    renglon.Cells("ANorm").Appearance.ForeColor = Nothing
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANorm").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANorm").Value + renglon.Cells("ANorm").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANormPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANormPares").Value + renglon.Cells("ANormPares").Value
                    renglon.Cells("ATotal").Value = renglon.Cells("ATotal").Value + renglon.Cells("ANorm").Value
                    renglon.Cells("PrsTotalAtDest").Value = renglon.Cells("PrsTotalAtDest").Value + renglon.Cells("ANormPares").Value
                    renglon.Cells("PrsApart").Value = renglon.Cells("PrsApart").Value + renglon.Cells("ANormPares").Value
                    renglon.Cells("PrsFalt").Value = renglon.Cells("PrsFalt").Value - renglon.Cells("ANormPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - renglon.Cells("ANormPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + renglon.Cells("ANormPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value + renglon.Cells("ANormPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value + renglon.Cells("ANorm").Value
                    'If (renglon.Cells("OK_Normales").Hidden = False And renglon.Cells("OK_Normales").Value = 1 Or renglon.Cells("OK_Normales").Hidden = True) And
                    '        (renglon.Cells("OK_Punto").Hidden = False And renglon.Cells("OK_Punto").Value = 1 Or renglon.Cells("OK_Punto").Hidden = True) And
                    '        (renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And renglon.Cells("OK_AtadosDestalladosNormales").Value = 1 Or renglon.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                    '        (renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And renglon.Cells("OK_AtadosDestalladosPunto").Value = 1 Or renglon.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                    If ((renglon.Cells("OK_Normales").Hidden = False And renglon.Cells("OK_Normales").Value = 1 And renglon.Cells("Norm").Value <> 0) Or (renglon.Cells("OK_Normales").Hidden = False And renglon.Cells("OK_Normales").Value = 0 And renglon.Cells("Norm").Value = 0) Or renglon.Cells("OK_Normales").Hidden = True) And
                            ((renglon.Cells("OK_Punto").Hidden = False And renglon.Cells("OK_Punto").Value = 1 And renglon.Cells("Punt").Value <> 0) Or (renglon.Cells("OK_Punto").Hidden = False And renglon.Cells("OK_Punto").Value = 0 And renglon.Cells("Punt").Value = 0) Or renglon.Cells("OK_Punto").Hidden = True) And
                            ((renglon.Cells("OK_Destallados").Hidden = False And renglon.Cells("OK_Destallados").Value = 1 And renglon.Cells("PrsDest").Value <> 0) Or (renglon.Cells("PrsDest").Hidden = False And renglon.Cells("OK_Destallados").Value = 0 And renglon.Cells("PrsDest").Value = 0) Or renglon.Cells("OK_Destallados").Hidden = True) And
                            ((renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And renglon.Cells("OK_AtadosDestalladosPunto").Value = 1 And renglon.Cells("APunt").Value <> 0) Or (renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And renglon.Cells("OK_AtadosDestalladosPunto").Value = 0 And renglon.Cells("APunt").Value = 0) Or renglon.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then

                        If renglon.Cells("M3").Value = "X" Then
                            renglon.Cells("M3").Value = "No"
                            renglon.Cells("M3").Appearance.BackColor = Nothing
                            objBu.ModificacionesPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), 3)
                        End If
                    End If
                    If renglon.Cells("Punt").Value = 0 Then
                        renglon.Cells("M3").Value = "X"
                        renglon.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                        objBu.ModificacionesPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), 2)
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub tsmiQuitarSelecciónDestallarNormales_Click(sender As Object, e As EventArgs) Handles tsmiQuitarSelecciónDestallarNormales.Click
        Dim objBu As New Negocios.ApartadosBU
        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
            If listRenglonesSeleccionados.Contains(renglon.Index) Then
                If renglon.Cells("OK_AtadosDestalladosNormales").Value = 1 Then
                    renglon.Cells("OK_AtadosDestalladosNormales").Value = 0
                    If renglon.Cells("ANorm").Value > 0 Then
                        renglon.Cells("ANorm").Appearance.ForeColor = Color.Red
                    End If
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANorm").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANorm").Value - renglon.Cells("ANorm").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANormPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ANormPares").Value - renglon.Cells("ANormPares").Value
                    renglon.Cells("ATotal").Value = renglon.Cells("ATotal").Value - renglon.Cells("ANorm").Value
                    renglon.Cells("PrsTotalAtDest").Value = renglon.Cells("PrsTotalAtDest").Value - renglon.Cells("ANormPares").Value
                    renglon.Cells("PrsApart").Value = renglon.Cells("PrsApart").Value - renglon.Cells("ANormPares").Value
                    renglon.Cells("PrsFalt").Value = renglon.Cells("PrsFalt").Value + renglon.Cells("ANormPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + renglon.Cells("ANormPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - renglon.Cells("ANormPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value - renglon.Cells("ANormPares").Value
                    'AGREGAR EL SIGUIENTE RENGLON A TODOS LOS CASOS DE QUITAR O AGREGAR ATADOS DESTALLADOS, PORQUE SOLO SE RESTAN Y SUMAN LOS PARES PERO NO LOS TOTALES DE ATADOS
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value - renglon.Cells("ANorm").Value
                    If renglon.Cells("ANorm").Value > 0 Then
                        renglon.Cells("M3").Value = "X"
                        renglon.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                        objBu.ModificacionesPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), 2)
                    Else
                        If ((renglon.Cells("OK_Normales").Hidden = False And renglon.Cells("OK_Normales").Value = 1 And renglon.Cells("Norm").Value = 0) Or (renglon.Cells("OK_Normales").Hidden = False And renglon.Cells("OK_Normales").Value = 0 And renglon.Cells("Norm").Value > 0) Or renglon.Cells("OK_Normales").Hidden = True) And
                           ((renglon.Cells("OK_Punto").Hidden = False And renglon.Cells("OK_Punto").Value = 1 And renglon.Cells("Punt").Value = 0) Or (renglon.Cells("OK_Punto").Hidden = False And renglon.Cells("OK_Punto").Value = 0 And renglon.Cells("Punt").Value > 0) Or renglon.Cells("OK_Punto").Hidden = True) And
                           ((renglon.Cells("OK_Destallados").Hidden = False And renglon.Cells("OK_Destallados").Value = 1 And renglon.Cells("PrsDest").Value = 0) Or (renglon.Cells("OK_Destallados").Hidden = False And renglon.Cells("OK_Destallados").Value = 0 And renglon.Cells("PrsDest").Value > 0) Or renglon.Cells("OK_Destallados").Hidden = True) And
                           ((renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And renglon.Cells("OK_AtadosDestalladosPunto").Value = 1 And renglon.Cells("APunt").Value = 0) Or (renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And renglon.Cells("OK_AtadosDestalladosPunto").Value = 0 And renglon.Cells("APunt").Value > 0) Or renglon.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                            If renglon.Cells("M3").Value = "X" Then
                                renglon.Cells("M3").Value = "No"
                                renglon.Cells("M3").Appearance.BackColor = Nothing
                                objBu.ModificacionesPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), 2)
                            End If
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub tsmiAgregarSelecciónDestallarPunto_Click(sender As Object, e As EventArgs) Handles tsmiAgregarSelecciónDestallarPunto.Click
        Dim objBu As New Negocios.ApartadosBU
        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
            If listRenglonesSeleccionados.Contains(renglon.Index) Then
                If renglon.Cells("OK_AtadosDestalladosPunto").Value <> 1 Then
                    renglon.Cells("OK_AtadosDestalladosPunto").Value = 1
                    renglon.Cells("APunt").Appearance.ForeColor = Nothing
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APunt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APunt").Value + renglon.Cells("APunt").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APuntPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APuntPares").Value + renglon.Cells("APuntPares").Value
                    renglon.Cells("ATotal").Value = renglon.Cells("ATotal").Value + renglon.Cells("APunt").Value
                    renglon.Cells("PrsTotalAtDest").Value = renglon.Cells("PrsTotalAtDest").Value + renglon.Cells("APuntPares").Value
                    renglon.Cells("PrsApart").Value = renglon.Cells("PrsApart").Value + renglon.Cells("APuntPares").Value
                    renglon.Cells("PrsFalt").Value = renglon.Cells("PrsFalt").Value - renglon.Cells("APuntPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - renglon.Cells("APuntPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + renglon.Cells("APuntPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value + renglon.Cells("APuntPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value + renglon.Cells("APunt").Value
                    'If (renglon.Cells("OK_Normales").Hidden = False And renglon.Cells("OK_Normales").Value = 1 Or renglon.Cells("OK_Normales").Hidden = True) And
                    '        (renglon.Cells("OK_Punto").Hidden = False And renglon.Cells("OK_Punto").Value = 1 Or renglon.Cells("OK_Punto").Hidden = True) And
                    '        (renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And renglon.Cells("OK_AtadosDestalladosNormales").Value = 1 Or renglon.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                    '        (renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And renglon.Cells("OK_AtadosDestalladosPunto").Value = 1 Or renglon.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                    If ((renglon.Cells("OK_Normales").Hidden = False And renglon.Cells("OK_Normales").Value = 1 And renglon.Cells("Norm").Value <> 0) Or (renglon.Cells("OK_Normales").Hidden = False And renglon.Cells("OK_Normales").Value = 0 And renglon.Cells("Norm").Value = 0) Or renglon.Cells("OK_Normales").Hidden = True) And
                        ((renglon.Cells("OK_Punto").Hidden = False And renglon.Cells("OK_Punto").Value = 1 And renglon.Cells("Punt").Value <> 0) Or (renglon.Cells("OK_Punto").Hidden = False And renglon.Cells("OK_Punto").Value = 0 And renglon.Cells("Punt").Value = 0) Or renglon.Cells("OK_Punto").Hidden = True) And
                        ((renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And renglon.Cells("OK_AtadosDestalladosNormales").Value = 1 And renglon.Cells("ANorm").Value <> 0) Or (renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And renglon.Cells("OK_AtadosDestalladosNormales").Value = 0 And renglon.Cells("ANorm").Value = 0) Or renglon.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                        ((renglon.Cells("OK_Destallados").Hidden = False And renglon.Cells("OK_Destallados").Value = 1 And renglon.Cells("PrsDest").Value <> 0) Or (renglon.Cells("PrsDest").Hidden = False And renglon.Cells("OK_Destallados").Value = 0 And renglon.Cells("PrsDest").Value = 0) Or renglon.Cells("OK_Destallados").Hidden = True) Then
                        If renglon.Cells("M3").Value = "X" Then
                            renglon.Cells("M3").Value = "No"
                            renglon.Cells("M3").Appearance.BackColor = Nothing
                            objBu.ModificacionesPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), 3)
                        End If
                    End If
                    If renglon.Cells("APunt").Value = 0 Then
                        renglon.Cells("M3").Value = "X"
                        renglon.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                        objBu.ModificacionesPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), 2)
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub tsmiQuitarSelecciónDestallarPunto_Click(sender As Object, e As EventArgs) Handles tsmiQuitarSelecciónDestallarPunto.Click
        Dim objBu As New Negocios.ApartadosBU
        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
            If listRenglonesSeleccionados.Contains(renglon.Index) Then
                If renglon.Cells("OK_AtadosDestalladosPunto").Value <> 0 Then
                    renglon.Cells("OK_AtadosDestalladosPunto").Value = 0
                    If renglon.Cells("APunt").Value > 0 Then
                        renglon.Cells("APunt").Appearance.ForeColor = Color.Red
                    End If
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APunt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APunt").Value - renglon.Cells("APunt").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APuntPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("APuntPares").Value - renglon.Cells("APuntPares").Value
                    renglon.Cells("ATotal").Value = renglon.Cells("ATotal").Value - renglon.Cells("APunt").Value
                    renglon.Cells("PrsTotalAtDest").Value = renglon.Cells("PrsTotalAtDest").Value - renglon.Cells("APuntPares").Value
                    renglon.Cells("PrsApart").Value = renglon.Cells("PrsApart").Value - renglon.Cells("APuntPares").Value
                    renglon.Cells("PrsFalt").Value = renglon.Cells("PrsFalt").Value + renglon.Cells("APuntPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + renglon.Cells("APuntPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - renglon.Cells("APuntPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotalAtDest").Value - renglon.Cells("APuntPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("ATotal").Value - renglon.Cells("APunt").Value
                    If renglon.Cells("APunt").Value > 0 Then
                        renglon.Cells("M3").Value = "X"
                        renglon.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                        objBu.ModificacionesPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), 2)
                    Else
                        If ((renglon.Cells("OK_Normales").Hidden = False And renglon.Cells("OK_Normales").Value = 1 And renglon.Cells("Norm").Value = 0) Or (renglon.Cells("OK_Normales").Hidden = False And renglon.Cells("OK_Normales").Value = 0 And renglon.Cells("Norm").Value > 0) Or renglon.Cells("OK_Normales").Hidden = True) And
                           ((renglon.Cells("OK_Punto").Hidden = False And renglon.Cells("OK_Punto").Value = 1 And renglon.Cells("Punt").Value = 0) Or (renglon.Cells("OK_Punto").Hidden = False And renglon.Cells("OK_Punto").Value = 0 And renglon.Cells("Punt").Value > 0) Or renglon.Cells("OK_Punto").Hidden = True) And
                           ((renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And renglon.Cells("OK_AtadosDestalladosNormales").Value = 1 And renglon.Cells("ANorm").Value = 0) Or (renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And renglon.Cells("OK_AtadosDestalladosNormales").Value = 0 And renglon.Cells("ANorm").Value > 0) Or renglon.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                           ((renglon.Cells("OK_Destallados").Hidden = False And renglon.Cells("OK_Destallados").Value = 1 And renglon.Cells("PrsDest").Value = 0) Or (renglon.Cells("OK_Destallados").Hidden = False And renglon.Cells("OK_Destallados").Value = 0 And renglon.Cells("PrsDest").Value > 0) Or renglon.Cells("OK_Destallados").Hidden = True) Then
                            If renglon.Cells("M3").Value = "X" Then
                                renglon.Cells("M3").Value = "No"
                                renglon.Cells("M3").Appearance.BackColor = Nothing
                                objBu.ModificacionesPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), 2)
                            End If
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub tsmiQuitarSeleccionAtadosNormales_Click(sender As Object, e As EventArgs) Handles tsmiQuitarSeleccionAtadosNormales.Click
        Dim objBu As New Negocios.ApartadosBU
        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
            If listRenglonesSeleccionados.Contains(renglon.Index) Then
                If renglon.Cells("OK_Normales").Value = 1 Then
                    renglon.Cells("OK_Normales").Value = 0
                    If renglon.Cells("Norm").Value > 0 Then
                        renglon.Cells("Norm").Appearance.ForeColor = Color.Red
                    End If
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Norm").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Norm").Value - renglon.Cells("Norm").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("NormPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("NormPares").Value - renglon.Cells("NormPares").Value
                    renglon.Cells("PrsTotal").Value = renglon.Cells("PrsTotal").Value - renglon.Cells("NormPares").Value
                    renglon.Cells("PrsApart").Value = renglon.Cells("PrsApart").Value - renglon.Cells("NormPares").Value
                    renglon.Cells("PrsFalt").Value = renglon.Cells("PrsFalt").Value + renglon.Cells("NormPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value + renglon.Cells("NormPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value - renglon.Cells("NormPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value - renglon.Cells("NormPares").Value
                    If renglon.Cells("Norm").Value > 0 Then
                        renglon.Cells("M3").Value = "X"
                        renglon.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                        objBu.ModificacionesPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), 2)
                    Else
                        If ((renglon.Cells("OK_Destallados").Hidden = False And renglon.Cells("OK_Destallados").Value = 1 And renglon.Cells("PrsDest").Value = 0) Or (renglon.Cells("OK_Destallados").Hidden = False And renglon.Cells("OK_Destallados").Value = 0 And renglon.Cells("PrsDest").Value > 0) Or renglon.Cells("OK_Destallados").Hidden = True) And
                           ((renglon.Cells("OK_Punto").Hidden = False And renglon.Cells("OK_Punto").Value = 1 And renglon.Cells("Punt").Value = 0) Or (renglon.Cells("OK_Punto").Hidden = False And renglon.Cells("OK_Punto").Value = 0 And renglon.Cells("Punt").Value > 0) Or renglon.Cells("OK_Punto").Hidden = True) And
                           ((renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And renglon.Cells("OK_AtadosDestalladosNormales").Value = 1 And renglon.Cells("ANorm").Value = 0) Or (renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And renglon.Cells("OK_AtadosDestalladosNormales").Value = 0 And renglon.Cells("ANorm").Value > 0) Or renglon.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                           ((renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And renglon.Cells("OK_AtadosDestalladosPunto").Value = 1 And renglon.Cells("APunt").Value = 0) Or (renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And renglon.Cells("OK_AtadosDestalladosPunto").Value = 0 And renglon.Cells("APunt").Value > 0) Or renglon.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                            If renglon.Cells("M3").Value = "X" Then
                                renglon.Cells("M3").Value = "No"
                                renglon.Cells("M3").Appearance.BackColor = Nothing
                                objBu.ModificacionesPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), 2)
                            End If
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub tsmiAgregarAtadosNormales_Click(sender As Object, e As EventArgs) Handles tsmiAgregarAtadosNormales.Click
        Dim objBu As New Negocios.ApartadosBU
        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
            If listRenglonesSeleccionados.Contains(renglon.Index) Then
                If renglon.Cells("OK_Normales").Value = 0 Then
                    renglon.Cells("OK_Normales").Value = 1
                    renglon.Cells("Norm").Appearance.ForeColor = Nothing
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Norm").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("Norm").Value + renglon.Cells("Norm").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("NormPares").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("NormPares").Value + renglon.Cells("NormPares").Value
                    renglon.Cells("PrsTotal").Value = renglon.Cells("PrsTotal").Value + renglon.Cells("NormPares").Value
                    renglon.Cells("PrsApart").Value = renglon.Cells("PrsApart").Value + renglon.Cells("NormPares").Value
                    renglon.Cells("PrsFalt").Value = renglon.Cells("PrsFalt").Value - renglon.Cells("NormPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsFalt").Value - renglon.Cells("NormPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsApart").Value + renglon.Cells("NormPares").Value
                    grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value = grdDatosGenerarApartados.Rows(grdDatosGenerarApartados.Rows.Count - 1).Cells("PrsTotal").Value + renglon.Cells("NormPares").Value
                    'If (renglon.Cells("OK_Normales").Hidden = False And renglon.Cells("OK_Normales").Value = 1 Or renglon.Cells("OK_Normales").Hidden = True) And
                    '        (renglon.Cells("OK_Punto").Hidden = False And renglon.Cells("OK_Punto").Value = 1 Or renglon.Cells("OK_Punto").Hidden = True) And
                    '        (renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And renglon.Cells("OK_AtadosDestalladosNormales").Value = 1 Or renglon.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                    '        (renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And renglon.Cells("OK_AtadosDestalladosPunto").Value = 1 Or renglon.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                    If ((renglon.Cells("OK_Destallados").Hidden = False And renglon.Cells("OK_Destallados").Value = 1 And renglon.Cells("PrsDest").Value <> 0) Or (renglon.Cells("PrsDest").Hidden = False And renglon.Cells("OK_Destallados").Value = 0 And renglon.Cells("PrsDest").Value = 0) Or renglon.Cells("OK_Destallados").Hidden = True) And
                            ((renglon.Cells("OK_Punto").Hidden = False And renglon.Cells("OK_Punto").Value = 1 And renglon.Cells("Punt").Value <> 0) Or (renglon.Cells("OK_Punto").Hidden = False And renglon.Cells("OK_Punto").Value = 0 And renglon.Cells("Punt").Value = 0) Or renglon.Cells("OK_Punto").Hidden = True) And
                            ((renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And renglon.Cells("OK_AtadosDestalladosNormales").Value = 1 And renglon.Cells("ANorm").Value <> 0) Or (renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False And renglon.Cells("OK_AtadosDestalladosNormales").Value = 0 And renglon.Cells("ANorm").Value = 0) Or renglon.Cells("OK_AtadosDestalladosNormales").Hidden = True) And
                            ((renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And renglon.Cells("OK_AtadosDestalladosPunto").Value = 1 And renglon.Cells("Apunt").Value <> 0) Or (renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False And renglon.Cells("OK_AtadosDestalladosPunto").Value = 0 And renglon.Cells("APunt").Value = 0) Or renglon.Cells("OK_AtadosDestalladosPunto").Hidden = True) Then
                        If renglon.Cells("M3").Value = "X" Then
                            renglon.Cells("M3").Value = "No"
                            renglon.Cells("M3").Appearance.BackColor = Nothing
                            objBu.ModificacionesPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), 3)
                        End If
                    End If
                    If renglon.Cells("Norm").Value = 0 Then
                        renglon.Cells("M3").Value = "X"
                        renglon.Cells("M3").Appearance.BackColor = lblModificacionDistribucion.BackColor
                        objBu.ModificacionesPartidas(renglon.Cells("PedidoDetalleId").Value.ToString(), renglon.Cells("Nave").Value.ToString(), renglon.Cells("ProgramaId").Value.ToString(), 2)
                    End If
                End If
            End If
        Next
    End Sub

#End Region

    Private Sub gridPartidasDistribucionDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        'Dim ColumnaTotales As Integer = 0
        If grid.Rows.Band.Columns.Exists("Total") Then
            grid.Rows.Band.Columns.Remove("Total")
        End If
        'grid.Rows.Band.Columns.Add("Total")

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        'grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 0
        'grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.False
        'grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        'grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        'grid.DisplayLayout.GroupByBox.Hidden = False
        'grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"
        grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
        grid.DisplayLayout.Override.SelectTypeCol = SelectType.None


        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If Not col.Hidden Then
                If col.Index > 0 Then
                    col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                    col.Format = "n0"
                End If
                width += col.Width
            End If
        Next

        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If

        For Each row In grid.Rows
            'ColumnaTotales = 0
            For Each celda As UltraGridCell In row.Cells
                If celda.Column.Index = 0 Then
                    celda.Value = Replace(celda.Value, "91 ", "")
                    celda.Value = Replace(celda.Value, "1 ", "")
                    celda.Value = Replace(celda.Value, "2 ", "")
                    celda.Value = Replace(celda.Value, "3 ", "")
                    celda.Value = Replace(celda.Value, "4 ", "")
                    celda.Value = Replace(celda.Value, "5 ", "")
                    celda.Value = Replace(celda.Value, "6 ", "")
                    celda.Value = Replace(celda.Value, "7 ", "")
                    celda.Value = Replace(celda.Value, "8 ", "")
                    celda.Value = Replace(celda.Value, "9 ", "")
                End If
                If celda.Column.Index < row.Band.Columns.Count - 1 Then
                    If IsDBNull(celda.Value) Or celda.Value.ToString() = "" Then
                        celda.Value = 0
                    End If
                    'If celda.Column.Index > 0 Then
                    '    ColumnaTotales += celda.Value
                    'End If
                End If
            Next
            row.Activation = Activation.NoEdit
            'row.Cells("Total").Value = ColumnaTotales
        Next

        ordenarColumnasTallas(grid)

    End Sub

    Private Sub chboxMostrarDistribucionPartida_CheckedChanged(sender As Object, e As EventArgs) Handles chboxMostrarDistribucionPartida.CheckedChanged
        If chboxMostrarDistribucionPartida.Checked = True Then
            grdDistribucionPartida.Visible = True
        Else
            grdDistribucionPartida.Visible = False
        End If
    End Sub

    Private Sub btnGuardarCambioTotalTallas_Click(sender As Object, e As EventArgs) Handles btnGuardarCambioTotalTallas.Click
        Dim PedidoDetalleId As Integer
        Dim NaveId As Integer
        Dim ProgramaId As Integer
        Dim Tallas As String = ""
        Dim TotalTallas As String = ""
        Dim objBu As New Negocios.ApartadosBU
        Dim TotalTallasModificadas As Integer = 0
        Dim TotalTallasModificadasDatosIncorrectos As Integer = 0

        PedidoDetalleId = pedidoDetalleIdModificarTallas
        NaveId = naveIdModificarTallas
        ProgramaId = programaIdModificarTallas

        For Each col As UltraGridColumn In grdDetallesPartida.Rows.Band.Columns
            If col.Index <> 0 And col.Index < grdDetallesPartida.Rows.Band.Columns.Count - 1 Then
                If grdDetallesPartida.Rows(grdDetallesPartida.Rows.Count - 1).Cells(col.Header.Caption.ToString()).Value < grdDetallesPartida.Rows(grdDetallesPartida.Rows.Count - 2).Cells(col.Header.Caption.ToString()).Value Or (grdDetallesPartida.Rows(grdDetallesPartida.Rows.Count - 1).Cells(col.Header.Caption.ToString()).Value = grdDetallesPartida.Rows(grdDetallesPartida.Rows.Count - 2).Cells(col.Header.Caption.ToString()).Value And grdDetallesPartida.Rows(grdDetallesPartida.Rows.Count - 1).Cells(col.Header.Caption.ToString()).Appearance.ForeColor = Color.Red) Then
                    TotalTallasModificadas += 1
                ElseIf grdDetallesPartida.Rows(grdDetallesPartida.Rows.Count - 1).Cells(col.Header.Caption.ToString()).Value > grdDetallesPartida.Rows(grdDetallesPartida.Rows.Count - 2).Cells(col.Header.Caption.ToString()).Value Then
                    'grdDetallesPartida.Rows(grdDetallesPartida.Rows.Count - 1).Cells(col.Header.Caption.ToString()).Value = grdDetallesPartida.Rows(grdDetallesPartida.Rows.Count - 2).Cells(col.Header.Caption.ToString()).Value
                    TotalTallasModificadasDatosIncorrectos += 1
                End If
            End If
        Next

        If TotalTallasModificadas > 0 Then

            For Each col As UltraGridColumn In grdDetallesPartida.Rows.Band.Columns
                If col.Index <> 0 And col.Index < grdDetallesPartida.Rows.Band.Columns.Count - 1 Then
                    If Tallas = "" Then
                        Tallas += col.Header.Caption.ToString()
                        If grdDetallesPartida.Rows(grdDetallesPartida.Rows.Count - 1).Cells(col.Header.Caption.ToString()).Value < grdDetallesPartida.Rows(grdDetallesPartida.Rows.Count - 2).Cells(col.Header.Caption.ToString()).Value Then
                            TotalTallas += Replace(grdDetallesPartida.Rows(grdDetallesPartida.Rows.Count - 1).Cells(col.Header.Caption.ToString()).Value.ToString, ",", "")
                        Else
                            TotalTallas += Replace(grdDetallesPartida.Rows(grdDetallesPartida.Rows.Count - 2).Cells(col.Header.Caption.ToString()).Value.ToString, ",", "")
                        End If
                    Else
                        Tallas += "," + col.Header.Caption.ToString()
                        If grdDetallesPartida.Rows(grdDetallesPartida.Rows.Count - 1).Cells(col.Header.Caption.ToString()).Value < grdDetallesPartida.Rows(grdDetallesPartida.Rows.Count - 2).Cells(col.Header.Caption.ToString()).Value Then
                            TotalTallas += "," + Replace(grdDetallesPartida.Rows(grdDetallesPartida.Rows.Count - 1).Cells(col.Header.Caption.ToString()).Value.ToString, ",", "")
                        Else
                            TotalTallas += "," + Replace(grdDetallesPartida.Rows(grdDetallesPartida.Rows.Count - 2).Cells(col.Header.Caption.ToString()).Value.ToString, ",", "")
                        End If
                    End If
                End If
            Next

            objBu.modificarTotalesTallasPartidas(PedidoDetalleId, Tallas, TotalTallas, NaveId, ProgramaId)

            grdDetallesPartida.DataSource = objBu.consultaParesTallasPartidas(PedidoDetalleId, programaIdModificarTallas, naveIdModificarTallas, 2)
            gridPartidasDiseño(grdDetallesPartida)

            grdDatosGenerarApartados.Rows(indiceRenglonModificarTallas).Cells("M2").Value = "Prs"
            grdDatosGenerarApartados.Rows(indiceRenglonModificarTallas).Cells("M2").Appearance.BackColor = lblModificacionPares.BackColor

        Else
            If TotalTallasModificadasDatosIncorrectos > 0 Then
                show_message("Advertencia", "Los pares a apartar no pueden ser mayores a la disponibilidad, verifique por favor.")
            Else
                show_message("Advertencia", "No hay cambios para guardar.")
            End If
        End If
    End Sub

    Private Sub mostrarVentanaResumen(Resumen As ResumenApartadosPPCP_Form)
        Resumen.ShowDialog()
        If Resumen.DialogResult = Windows.Forms.DialogResult.OK Then
            mostrarVentanaResumen(Resumen)
        End If
    End Sub

    Private Sub ordenarColumnasTallas(grid As UltraGrid)
        Dim NombresColumnas As New List(Of String)
        Dim contador As Integer = 1

        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If col.Header.Caption <> "Concepto" And col.Header.Caption <> "Total" And col.Header.Caption <> "TotalAt" And col.Header.Caption <> "TotalPrs" Then
                NombresColumnas.Add(col.Header.Caption)
            End If
        Next

        NombresColumnas.Sort()

        For Each talla As String In NombresColumnas
            grid.DisplayLayout.Bands(0).Columns(talla).Header.VisiblePosition = contador
            contador += 1
        Next
    End Sub


    Private Sub btnGenerarDistribucion_Click(sender As Object, e As EventArgs) Handles btnGenerarDistribucion.Click
        Dim confirmacion As New confirmarFormGrande
        Dim partidasDescartarDeApartados As String = String.Empty

        Dim renglonesSeleccionados As Integer
        For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
            If CBool(renglon.Cells("OK_RenglonCompleto").Value) Then
                renglonesSeleccionados += 1
            End If
        Next

        If renglonesSeleccionados > 0 Then

            confirmacion.mensaje = "El sistema realizará un respaldo del inventario disponible en Almacén para indicar la disponibilidad de pares en cada una de las partidas seleccionadas, esta acción puede tomar algunos minutos ¿Desea continuar?"
            Dim dtTablaResultado As New DataTable()
            If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                Dim detallesPedidoSeleccionados As String = String.Empty
                Dim objBU As New Negocios.ApartadosBU

                'Se agrego para que el inventario no dier negativos
                objBU.Replicacion_TmpdocenasPares()

                validaDisponibilidadRealizarApartados(1)
                If disponibleApartar = 1 Then
                    permitirIncluirExcluirPartidas = 0
                    lblHoraRespaldandoInventario.Text = "(" + DateTime.Now.ToShortDateString + " " + DateTime.Now.ToShortTimeString + ")"
                    lblHoraRespaldandoInventario.Visible = True
                    lblTextoRespaldandoInventario.Visible = True
                    For Each renglon As UltraGridRow In grdDatosGenerarApartados.Rows
                        If CBool(renglon.Cells("OK_renglonCompleto").Value) Then
                            If detallesPedidoSeleccionados.Contains(renglon.Cells("PedidoDetalleId").Value.ToString()) = False Then
                                If detallesPedidoSeleccionados <> "" Then
                                    detallesPedidoSeleccionados += ","
                                End If
                                detallesPedidoSeleccionados += renglon.Cells("PedidoDetalleId").Value.ToString()
                            End If
                        End If
                    Next
                    'objBU.verDisponibilidadGenerarApartado(detallesPedidoSeleccionados)

                    For Each row As UltraGridRow In grdDatosGenerarApartados.Rows
                        If row.Index < grdDatosGenerarApartados.Rows.Count - 1 Then
                            If CBool(row.Cells("OK_RenglonCompleto").Value) = False Then
                                If partidasDescartarDeApartados <> "" Then
                                    partidasDescartarDeApartados += ","
                                End If
                                partidasDescartarDeApartados += "'" + row.Cells("PedidoDetalleId").Value.ToString() + "-" + row.Cells("Nave").Value.ToString() + "-" + row.Cells("ProgramaId").Value.ToString() + "'"
                            End If
                        End If
                    Next

                    If partidasDescartarDeApartados <> "" Then
                        objBU.descartarPartidasDeDistribucion(partidasDescartarDeApartados)
                    End If

                    objBU.generarInventarioDisponible()

                    lblTextoTiempoPendientesPorConfirmar.Visible = False
                    lblTextoTiempoPartidasApartar.Visible = False
                    lblTiempoApartadosPorConfirmar.Visible = False
                    lblTiempoPartidasPorApartar.Visible = False
                    lblTotalTiempos.Visible = False
                    lblCantidadPendientesPorConfirmar.Visible = False
                    lblCantidadPartidasPorApartar.Visible = False
                    lblTotalParesApartadosPorConfirmar.Visible = False

                    lblHoraRespaldandoInventario.Visible = False
                    lblTextoRespaldandoInventario.Visible = False
                    lblFechaUltimoRespaldoInventario.Text = DateTime.Now.ToShortDateString + " " + DateTime.Now.ToShortTimeString
                    lblTextoUltimoRespaldoInventario.Visible = True
                    lblFechaUltimoRespaldoInventario.Visible = True

                    objBU.generarDistribucionApartados()

                    grdDatosGenerarApartados.DataSource = Nothing


                    If Integer.Parse(objBU.verificarDistribucionApartadosPorConfirmar().Rows(0).Item("ApartadosMalDistribuidos").ToString) = 0 Then


                        Dim ventanaParametros As New ParametrosApartadosPPCPForm
                        ventanaParametros.ventanaOrigen = Me
                        ventanaParametros.filtrosGenerarApartados = filtrosGenerarApartados
                        ventanaParametros.btnActualizarDistribucion_Click(sender, e)

                        'btnActualizarDistribucion_Click(sender, e)
                        'objBU.actualizarApartadosPorGenerar(filtrosGenerarApartados)
                        'objBU.distribucionApartadosPorGenerar(filtrosGenerarApartados)
                        'objBU.actualizarTotalesDistribucionPartidasPorGenerar()
                        'dtTablaResultado = objBU.seleccionarPartidasConDistribucion(1)
                        lblFechaUltimaDistribucion.Text = DateTime.Now.ToShortDateString + " " + DateTime.Now.ToShortTimeString
                        lblTextoUltimaDistribucion.Visible = True
                        lblFechaUltimaDistribucion.Visible = True
                        chboxMostrarPartidasSinInventario.Visible = True
                        'chboxMostrarPartidasExcluidas.Checked = True
                        'grdDatosGenerarApartados.DataSource = Nothing
                        'grdDatosGenerarApartados.DataSource = dtTablaResultado
                        'gridPedidosDistribucionesDiseño(grdDatosGenerarApartados, 1)
                        btnGenerarDistribucion.Enabled = False
                        lblGenerarDistribucion.Enabled = False
                        chboxMostrarPartidasExcluidas.Visible = False

                        chboxSeleccionarTodoAtadosPuntoDestallar.Visible = True
                        chboxSeleccionarTodoAtadosNormalesDestallar.Visible = True
                        lblTextoCheckboxAtadosDestallar.Visible = True
                        chboxSeleccionarTodoParesDestallados.Visible = True
                        chboxSeleccionarTodoAtadosPuntoCompletos.Visible = True
                        chboxSeleccionarTodoAtadosNormalesCompletos.Visible = True
                        lblTextoCheckboxAtadosCompletos.Visible = True


                        btnActualizarDistribucion.Enabled = True
                        lblTextoBotonActualizarDistribucion.Enabled = True

                        btnReordenar.Enabled = False
                        lblTextoReordenar.Enabled = False

                        chboxMostrarDistribucionPartida.Visible = True

                        btnGuardarApartado.Enabled = True
                        lblGuardarApartado.Enabled = True
                        btnGuardarCambioTotalTallas.Visible = True
                        lblTextoGuardarCambioTotalTallas.Visible = True
                        grpAcotaciones.Visible = True

                        btnResumen.Enabled = True
                        lblTextoResumen.Enabled = True

                        btnVerDisponibilidad.Enabled = False
                        lblVerDisponibilidad.Enabled = False

                        distribucionGeneradaAnteriormente = 1
                    Else
                        show_message("Error", "Ocurrió un error al generar la distribución de los apartados por confirmar, contacte al área de TI")
                    End If
                End If
            End If
        Else
            show_message("Advertencia", "Debe seleccionar al menos una partida para ver disponibilidad")
        End If
        Cursor = Cursors.Default
    End Sub
End Class