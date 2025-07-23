Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Data
Imports System.Data.DataTable
Imports System.Data.DataSet
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports Stimulsoft.Report
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.ReportGeneration
Imports System.IO
Imports System.Xml


Public Class ConsultaInventarioProcesoForm

    Dim OBJBU As New Ventas.Negocios.inventarioBU
    Dim ListaPuntos As New List(Of String)
    Dim ListaPedidoSAY As New List(Of String)
    Dim ListaPedidoSICY As New List(Of String)
    Dim ListaLote As New List(Of String)

    Private Sub ConsultaInventarioProcesoForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.WindowState = FormWindowState.Maximized
        ListaPuntos.Add("T1")
        ListaPuntos.Add("T2")
        ListaPuntos.Add("T3")
        ListaPuntos.Add("T4")
        ListaPuntos.Add("T5")
        ListaPuntos.Add("T6")
        ListaPuntos.Add("T7")
        ListaPuntos.Add("T8")
        ListaPuntos.Add("T9")
        ListaPuntos.Add("T10")
        ListaPuntos.Add("T11")
        ListaPuntos.Add("T12")
        ListaPuntos.Add("T13")
        ListaPuntos.Add("T14")
        ListaPuntos.Add("T15")
        ListaPuntos.Add("T16")
        ListaPuntos.Add("T17")
        ListaPuntos.Add("T18")
        ListaPuntos.Add("T19")
        ListaPuntos.Add("T20")
        ListaPuntos.Add("T21")
        ListaPuntos.Add("T22")
        ListaPuntos.Add("T23")
        ListaPuntos.Add("T24")
        ListaPuntos.Add("T25")
        ListaPuntos.Add("T26")
        ListaPuntos.Add("T27")
        ListaPuntos.Add("T28")
        ListaPuntos.Add("T29")
        ListaPuntos.Add("T30")
        ListaPuntos.Add("T31")
        ListaPuntos.Add("T32")
        ListaPuntos.Add("T33")
        ListaPuntos.Add("T34")
        ListaPuntos.Add("T35")
        ListaPuntos.Add("T36")
        ListaPuntos.Add("T37")

        Utilerias.ComboObtenerCEDISUsuario(cboxNaveAlmacen)

    End Sub


    Private Sub CargarInventarioProceso()
        Dim dtInformacion As New DataTable
        Dim dtParesProceso As New DataTable
        Dim TipoReporte As Integer = 0
        Dim Cedis As Integer = 0
        Dim FiltroPedidoSAY As String = String.Empty
        Dim FiltroPedidoSICY As String = String.Empty
        Dim FiltroLote As String = String.Empty
        Dim FiltroCliente As String = String.Empty
        Dim FiltroColeccion As String = String.Empty
        Dim FiltroModelo As String = String.Empty
        Dim FiltroStatusPedido As String = String.Empty
        Dim FiltroStatusPar As String = String.Empty

        Try

            Cursor = Cursors.WaitCursor

            FiltroPedidoSAY = ObtenerFiltrosGrid(grdFiltroPedidoSAY)
            FiltroPedidoSICY = ObtenerFiltrosGrid(grdFiltroPedidoSICY)
            FiltroLote = ObtenerFiltrosGrid(grdFiltroLote)
            FiltroCliente = ObtenerFiltrosGrid(grdFiltroCliente)
            FiltroColeccion = ObtenerFiltrosGrid(grdFiltroColeccion)
            FiltroModelo = ObtenerFiltrosGrid(grdFiltroModelo)
            FiltroStatusPedido = ObtenerFiltrosGrid(grdStatusPedido)
            'If cmboxStatusPedido.SelectedIndex > 0 Then
            '    FiltroStatusPedido = cmboxStatusPedido.SelectedValue.ToString
            'End If

            'If cmbEstatusPar.SelectedIndex > 0 Then
            '    FiltroStatusPar = cmbEstatusPar.SelectedValue.ToString
            'End If

            btnArriba_Click(Nothing, Nothing)
            TipoReporte = ObtenerTipoConsulta()

            Cedis = cboxNaveAlmacen.SelectedValue

            dtInformacion = OBJBU.ConsultarInventarioProceso(TipoReporte, FiltroStatusPedido, FiltroStatusPar, FiltroCliente, FiltroPedidoSICY, FiltroLote, FiltroColeccion, FiltroModelo, FiltroPedidoSAY, Cedis)
            dtParesProceso = OBJBU.ConsultarTotalParesProceso()

            If TipoReporte = 1 Then
                'grdMaterial.DataSource = dtInformacion
                grdMaterialPedido.DataSource = dtInformacion
            ElseIf TipoReporte = 2 Then
                'grdMaterialPedido.DataSource = dtInformacion
                grdMaterialPedidoLote.DataSource = dtInformacion
            ElseIf TipoReporte = 3 Then
                'grdMaterialPedidoPartida.DataSource = dtInformacion
            ElseIf TipoReporte = 4 Then
                'grdMaterialPedidoLote.DataSource = dtInformacion
            ElseIf TipoReporte = 5 Then
                'grdMaterialPedidoLoteAtado.DataSource = dtInformacion
            ElseIf TipoReporte = 6 Then
                'grdDetallados.DataSource = dtInformacion
            End If
            DiseñoGrid(TipoReporte)
            lblTotalParesProceso.Text = CDbl(dtParesProceso.Rows(0).Item(0).ToString()).ToString("N0")
            'lblTotalParesProceso.Text = CDbl(dtInformacion.Rows.Count).ToString("N0")
            Cursor = Cursors.Default
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Function ObtenerTipoConsulta() As Integer
        Dim TipoConsulta As Integer = 0
        TipoConsulta = tabInventario.SelectedIndex

        Return TipoConsulta + 1
    End Function


    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        CargarInventarioProceso()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 190
    End Sub

    Private Sub tabInventario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabInventario.SelectedIndexChanged
        Dim TipoConsulta As Integer = 0
        TipoConsulta = ObtenerTipoConsulta()
        'If TipoConsulta = 1 Then
        '    lblTotalParesProceso.Text = CDbl(vwMaterialPedido.DataRowCount.ToString()).ToString("N0")
        'ElseIf TipoConsulta = 2 Then
        '    lblTotalParesProceso.Text = CDbl(vwMaterialPedidoLote.DataRowCount.ToString()).ToString("N0")
        'End If
    End Sub


    Private Sub DiseñoGrid(ByVal TipoReporte As Integer)
        Dim gridview As New DevExpress.XtraGrid.Views.Grid.GridView

        If TipoReporte = 1 Then
            'gridview = vwMaterial
            gridview = vwMaterialPedido
        ElseIf TipoReporte = 2 Then
            'gridview = vwMaterialPedido
            gridview = vwMaterialPedidoLote
        ElseIf TipoReporte = 3 Then
            'gridview = vwMaterialPedidoPartida
        ElseIf TipoReporte = 4 Then
            'gridview = vwMaterialPedidoLote
        ElseIf TipoReporte = 5 Then
            'gridview = vwMaterialPedidoLoteAtado
        ElseIf TipoReporte = 6 Then
            'gridview = vwDetallado
        End If

        'gridview.OptionsView.ColumnAutoWidth = True


        'grdVentas.OptionsView.BestFitMaxRowCount = -1


        'If IsNothing(gridview.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
        '    gridview.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        '    AddHandler gridview.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
        '    gridview.Columns.Item("#").VisibleIndex = 0
        'End If


        For Each col As DevExpress.XtraGrid.Columns.GridColumn In gridview.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next


        If TipoReporte = 1 Or TipoReporte = 2 Then
            gridview.Columns.ColumnByFieldName("Cliente").Visible = True
            gridview.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowSize = True
            gridview.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowEdit = False
            gridview.Columns.ColumnByFieldName("Cliente").Caption = "Cliente"
            gridview.Columns.ColumnByFieldName("Cliente").Width = 230

            gridview.Columns.ColumnByFieldName("idtblPedido").Visible = True
            gridview.Columns.ColumnByFieldName("idtblPedido").OptionsColumn.AllowSize = True
            gridview.Columns.ColumnByFieldName("idtblPedido").OptionsColumn.AllowEdit = False
            gridview.Columns.ColumnByFieldName("idtblPedido").Caption = "Pedido"


        End If

        If TipoReporte = 2 Then
            gridview.Columns.ColumnByFieldName("idtblnave").Visible = False

            gridview.Columns.ColumnByFieldName("idtbllote").Visible = True
            gridview.Columns.ColumnByFieldName("idtbllote").OptionsColumn.AllowSize = True
            gridview.Columns.ColumnByFieldName("idtbllote").OptionsColumn.AllowEdit = False
            gridview.Columns.ColumnByFieldName("idtbllote").Caption = "Lote"
            gridview.Columns.ColumnByFieldName("idtbllote").Width = 100

            gridview.Columns.ColumnByFieldName("Nave").Visible = True
            gridview.Columns.ColumnByFieldName("Nave").OptionsColumn.AllowSize = True
            gridview.Columns.ColumnByFieldName("Nave").OptionsColumn.AllowEdit = False
            gridview.Columns.ColumnByFieldName("Nave").Caption = "Nave"
            gridview.Columns.ColumnByFieldName("Nave").Width = 100

            gridview.Columns.ColumnByFieldName("FechaProduccion").Visible = True
            gridview.Columns.ColumnByFieldName("FechaProduccion").OptionsColumn.AllowSize = True
            gridview.Columns.ColumnByFieldName("FechaProduccion").OptionsColumn.AllowEdit = False
            gridview.Columns.ColumnByFieldName("FechaProduccion").Caption = "Fecha Prod."
            gridview.Columns.ColumnByFieldName("FechaProduccion").Width = 80
        End If




        gridview.Columns.ColumnByFieldName("IdCodigo").Width = 100
        gridview.Columns.ColumnByFieldName("IdCodigo").Visible = True

        gridview.Columns.ColumnByFieldName("IdModelo").Visible = False
        gridview.Columns.ColumnByFieldName("IdCombinacion").Visible = False
        gridview.Columns.ColumnByFieldName("IdLinea").Visible = False
        gridview.Columns.ColumnByFieldName("Color").Visible = False
        gridview.Columns.ColumnByFieldName("Coleccion").Visible = False
        gridview.Columns.ColumnByFieldName("Descripcion").Visible = False
        gridview.Columns.ColumnByFieldName("Foto").Visible = False
        gridview.Columns.ColumnByFieldName("Disponible").Visible = False
        gridview.Columns.ColumnByFieldName("Minimo").Visible = False
        gridview.Columns.ColumnByFieldName("Maximo").Visible = False
        gridview.Columns.ColumnByFieldName("Existencia").Visible = False
        gridview.Columns.ColumnByFieldName("ExistenciaN").Visible = False
        gridview.Columns.ColumnByFieldName("ExistenciaE").Visible = False
        gridview.Columns.ColumnByFieldName("eUnidaddeMedida").Visible = False
        gridview.Columns.ColumnByFieldName("Talla").Visible = True
        gridview.Columns.ColumnByFieldName("idtblProducto").Visible = False
        gridview.Columns.ColumnByFieldName("idtblTalla").Visible = False
        gridview.Columns.ColumnByFieldName("T1").Visible = True
        gridview.Columns.ColumnByFieldName("T2").Visible = True
        gridview.Columns.ColumnByFieldName("T3").Visible = True
        gridview.Columns.ColumnByFieldName("T4").Visible = True
        gridview.Columns.ColumnByFieldName("T5").Visible = True
        gridview.Columns.ColumnByFieldName("T6").Visible = True
        gridview.Columns.ColumnByFieldName("T7").Visible = True
        gridview.Columns.ColumnByFieldName("T8").Visible = True
        gridview.Columns.ColumnByFieldName("T9").Visible = True
        gridview.Columns.ColumnByFieldName("T10").Visible = True
        gridview.Columns.ColumnByFieldName("T11").Visible = True
        gridview.Columns.ColumnByFieldName("T12").Visible = True
        gridview.Columns.ColumnByFieldName("T13").Visible = True
        gridview.Columns.ColumnByFieldName("T14").Visible = True
        gridview.Columns.ColumnByFieldName("T15").Visible = True
        gridview.Columns.ColumnByFieldName("T16").Visible = True
        gridview.Columns.ColumnByFieldName("T17").Visible = True
        gridview.Columns.ColumnByFieldName("T18").Visible = True
        gridview.Columns.ColumnByFieldName("T19").Visible = True
        gridview.Columns.ColumnByFieldName("T20").Visible = True
        gridview.Columns.ColumnByFieldName("T21").Visible = True
        gridview.Columns.ColumnByFieldName("T22").Visible = True
        gridview.Columns.ColumnByFieldName("T23").Visible = True
        gridview.Columns.ColumnByFieldName("T24").Visible = True
        gridview.Columns.ColumnByFieldName("T25").Visible = True
        gridview.Columns.ColumnByFieldName("T26").Visible = True
        gridview.Columns.ColumnByFieldName("T27").Visible = True
        gridview.Columns.ColumnByFieldName("T28").Visible = True
        gridview.Columns.ColumnByFieldName("T29").Visible = True
        gridview.Columns.ColumnByFieldName("T30").Visible = True
        gridview.Columns.ColumnByFieldName("T31").Visible = True
        gridview.Columns.ColumnByFieldName("T32").Visible = True
        gridview.Columns.ColumnByFieldName("T33").Visible = True
        gridview.Columns.ColumnByFieldName("T34").Visible = True
        gridview.Columns.ColumnByFieldName("T35").Visible = True
        gridview.Columns.ColumnByFieldName("T36").Visible = True
        gridview.Columns.ColumnByFieldName("T37").Visible = True
        gridview.Columns.ColumnByFieldName("T38").Visible = True
        gridview.Columns.ColumnByFieldName("Total").Visible = True
        gridview.Columns.ColumnByFieldName("STPedidos").Visible = False

        gridview.Columns.ColumnByFieldName("IdCodigo").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("pedidoSayID").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("StatusPedido").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("IdModelo").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("IdCombinacion").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("IdLinea").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("Color").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("Coleccion").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("Descripcion").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("Foto").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("Disponible").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("Minimo").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("Maximo").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("Existencia").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("ExistenciaN").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("ExistenciaE").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("eUnidaddeMedida").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("Talla").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("idtblProducto").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("idtblTalla").OptionsColumn.AllowSize = True

        gridview.Columns.ColumnByFieldName("T1").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T2").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T3").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T4").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T5").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T6").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T7").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T8").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T9").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T10").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T11").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T12").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T13").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T14").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T15").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T16").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T17").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T18").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T19").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T20").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T21").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T22").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T23").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T24").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T25").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T26").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T27").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T28").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T29").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T30").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T31").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T32").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T33").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T34").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T35").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T36").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T37").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("T38").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("Total").OptionsColumn.AllowSize = True
        gridview.Columns.ColumnByFieldName("STPedidos").OptionsColumn.AllowSize = True


        gridview.Columns.ColumnByFieldName("IdCodigo").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("pedidoSayID").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("StatusPedido").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("IdModelo").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("IdCombinacion").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("IdLinea").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("Color").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("Coleccion").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("Descripcion").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("Foto").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("Disponible").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("Minimo").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("Maximo").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("Existencia").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("ExistenciaN").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("ExistenciaE").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("eUnidaddeMedida").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("Talla").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("idtblProducto").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("idtblTalla").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T1").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T2").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T3").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T4").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T5").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T6").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T7").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T8").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T9").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T10").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T11").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T12").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T13").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T14").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T15").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T16").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T17").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T18").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T19").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T20").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T21").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T22").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T23").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T24").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T25").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T26").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T27").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T28").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T29").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T30").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T31").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T32").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T33").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T34").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T35").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T36").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T37").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("T38").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("Total").OptionsColumn.AllowEdit = False
        gridview.Columns.ColumnByFieldName("STPedidos").OptionsColumn.AllowEdit = False


        gridview.Columns.ColumnByFieldName("IdCodigo").Caption = "Material"
        gridview.Columns.ColumnByFieldName("pedidoSayID").Caption = "Pedido SAY"
        gridview.Columns.ColumnByFieldName("StatusPedido").Caption = "Status Pedido"
        gridview.Columns.ColumnByFieldName("IdModelo").Caption = "IdModelo"
        gridview.Columns.ColumnByFieldName("IdCombinacion").Caption = "IdCombinacion"
        gridview.Columns.ColumnByFieldName("IdLinea").Caption = "IdLinea"
        gridview.Columns.ColumnByFieldName("Color").Caption = "Color"
        gridview.Columns.ColumnByFieldName("Coleccion").Caption = "Coleccion"
        gridview.Columns.ColumnByFieldName("Descripcion").Caption = "Descripcion"
        gridview.Columns.ColumnByFieldName("Foto").Caption = "Foto"
        gridview.Columns.ColumnByFieldName("Disponible").Caption = "Disponible"
        gridview.Columns.ColumnByFieldName("Minimo").Caption = "Minimo"
        gridview.Columns.ColumnByFieldName("Maximo").Caption = "Maximo"
        gridview.Columns.ColumnByFieldName("Existencia").Caption = "Existencia"
        gridview.Columns.ColumnByFieldName("ExistenciaN").Caption = "ExistenciaN"
        gridview.Columns.ColumnByFieldName("ExistenciaE").Caption = "ExistenciaE"
        gridview.Columns.ColumnByFieldName("eUnidaddeMedida").Caption = "eUnidaddeMedida"
        gridview.Columns.ColumnByFieldName("Talla").Caption = "Talla"
        gridview.Columns.ColumnByFieldName("idtblProducto").Caption = "idtblProducto"
        gridview.Columns.ColumnByFieldName("idtblTalla").Caption = "idtblTalla"
        gridview.Columns.ColumnByFieldName("T1").Caption = "12"
        gridview.Columns.ColumnByFieldName("T2").Caption = "12½"
        gridview.Columns.ColumnByFieldName("T3").Caption = "13"
        gridview.Columns.ColumnByFieldName("T4").Caption = "13½"
        gridview.Columns.ColumnByFieldName("T5").Caption = "14"
        gridview.Columns.ColumnByFieldName("T6").Caption = "14½"
        gridview.Columns.ColumnByFieldName("T7").Caption = "15"
        gridview.Columns.ColumnByFieldName("T8").Caption = "15½"
        gridview.Columns.ColumnByFieldName("T9").Caption = "16"
        gridview.Columns.ColumnByFieldName("T10").Caption = "16½"
        gridview.Columns.ColumnByFieldName("T11").Caption = "17"
        gridview.Columns.ColumnByFieldName("T12").Caption = "17½"
        gridview.Columns.ColumnByFieldName("T13").Caption = "18"
        gridview.Columns.ColumnByFieldName("T14").Caption = "18½"
        gridview.Columns.ColumnByFieldName("T15").Caption = "19"
        gridview.Columns.ColumnByFieldName("T16").Caption = "19½"
        gridview.Columns.ColumnByFieldName("T17").Caption = "20"
        gridview.Columns.ColumnByFieldName("T18").Caption = "20½"
        gridview.Columns.ColumnByFieldName("T19").Caption = "21"
        gridview.Columns.ColumnByFieldName("T20").Caption = "21½"
        gridview.Columns.ColumnByFieldName("T21").Caption = "22"
        gridview.Columns.ColumnByFieldName("T22").Caption = "22½"
        gridview.Columns.ColumnByFieldName("T23").Caption = "23"
        gridview.Columns.ColumnByFieldName("T24").Caption = "23½"
        gridview.Columns.ColumnByFieldName("T25").Caption = "24"
        gridview.Columns.ColumnByFieldName("T26").Caption = "24½"
        gridview.Columns.ColumnByFieldName("T27").Caption = "25"
        gridview.Columns.ColumnByFieldName("T28").Caption = "25½"
        gridview.Columns.ColumnByFieldName("T29").Caption = "26"
        gridview.Columns.ColumnByFieldName("T30").Caption = "26½"
        gridview.Columns.ColumnByFieldName("T31").Caption = "27"
        gridview.Columns.ColumnByFieldName("T32").Caption = "27½"
        gridview.Columns.ColumnByFieldName("T33").Caption = "28"
        gridview.Columns.ColumnByFieldName("T34").Caption = "28½"
        gridview.Columns.ColumnByFieldName("T35").Caption = "29"
        gridview.Columns.ColumnByFieldName("T36").Caption = "29½"
        gridview.Columns.ColumnByFieldName("T37").Caption = "30"
        gridview.Columns.ColumnByFieldName("T38").Caption = "30½"
        gridview.Columns.ColumnByFieldName("Total").Caption = "Total"
        gridview.Columns.ColumnByFieldName("STPedidos").Caption = "STPedidos"

        gridview.Columns.ColumnByFieldName("StatusPedido").Width = 100
        gridview.Columns.ColumnByFieldName("T1").Width = 50
        gridview.Columns.ColumnByFieldName("T2").Width = 50
        gridview.Columns.ColumnByFieldName("T3").Width = 50
        gridview.Columns.ColumnByFieldName("T4").Width = 50
        gridview.Columns.ColumnByFieldName("T5").Width = 50
        gridview.Columns.ColumnByFieldName("T6").Width = 50
        gridview.Columns.ColumnByFieldName("T7").Width = 50
        gridview.Columns.ColumnByFieldName("T8").Width = 50
        gridview.Columns.ColumnByFieldName("T9").Width = 50
        gridview.Columns.ColumnByFieldName("T10").Width = 50
        gridview.Columns.ColumnByFieldName("T11").Width = 50
        gridview.Columns.ColumnByFieldName("T12").Width = 50
        gridview.Columns.ColumnByFieldName("T13").Width = 50
        gridview.Columns.ColumnByFieldName("T14").Width = 50
        gridview.Columns.ColumnByFieldName("T15").Width = 50
        gridview.Columns.ColumnByFieldName("T16").Width = 50
        gridview.Columns.ColumnByFieldName("T17").Width = 50
        gridview.Columns.ColumnByFieldName("T18").Width = 50
        gridview.Columns.ColumnByFieldName("T19").Width = 50
        gridview.Columns.ColumnByFieldName("T20").Width = 50
        gridview.Columns.ColumnByFieldName("T21").Width = 50
        gridview.Columns.ColumnByFieldName("T22").Width = 50
        gridview.Columns.ColumnByFieldName("T23").Width = 50
        gridview.Columns.ColumnByFieldName("T24").Width = 50
        gridview.Columns.ColumnByFieldName("T25").Width = 50
        gridview.Columns.ColumnByFieldName("T26").Width = 50
        gridview.Columns.ColumnByFieldName("T27").Width = 50
        gridview.Columns.ColumnByFieldName("T28").Width = 50
        gridview.Columns.ColumnByFieldName("T29").Width = 50
        gridview.Columns.ColumnByFieldName("T30").Width = 50
        gridview.Columns.ColumnByFieldName("T31").Width = 50
        gridview.Columns.ColumnByFieldName("T32").Width = 50
        gridview.Columns.ColumnByFieldName("T33").Width = 50
        gridview.Columns.ColumnByFieldName("T34").Width = 50
        gridview.Columns.ColumnByFieldName("T35").Width = 50
        gridview.Columns.ColumnByFieldName("T36").Width = 50
        gridview.Columns.ColumnByFieldName("T37").Width = 50
        gridview.Columns.ColumnByFieldName("T38").Width = 50

        gridview.Columns.ColumnByFieldName("T1").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T2").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T3").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T4").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T5").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T6").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T7").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T8").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T9").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T10").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T11").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T12").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T13").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T14").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T15").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T16").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T17").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T18").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T19").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T20").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T21").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T22").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T23").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T24").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T25").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T26").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T27").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T28").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T29").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T30").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T31").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T32").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T33").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T34").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T35").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T36").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T37").DisplayFormat.FormatString = "N0"
        gridview.Columns.ColumnByFieldName("T38").DisplayFormat.FormatString = "N0"

        For Each elemento As String In ListaPuntos
            If IsNothing(gridview.Columns(elemento).Summary.FirstOrDefault(Function(x) x.FieldName = elemento)) = True Then
                gridview.Columns(elemento).Summary.Add(DevExpress.Data.SummaryItemType.Sum, elemento, "{0:N0}")
                Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
                item.FieldName = elemento
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0}"
                gridview.GroupSummary.Add(item)
            End If
        Next


    End Sub


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




    Private Sub vwMaterialPedido_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles vwMaterialPedido.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        Dim Valor As Integer = 0


        Try
            Cursor = Cursors.WaitCursor
            If ListaPuntos.Exists(Function(x) x = e.Column.FieldName) = True Then
                Valor = currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)
                If Valor > 0 Then
                    e.Appearance.BackColor = Color.LightSalmon
                End If

            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub vwDetallado_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs)
        Dim currentView As GridView = CType(sender, GridView)
        Dim Valor As Integer = 0


        Try
            Cursor = Cursors.WaitCursor
            If ListaPuntos.Exists(Function(x) x = e.Column.FieldName) = True Then
                Valor = currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)
                If Valor > 0 Then
                    e.Appearance.BackColor = Color.LightSalmon
                End If

            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub vwMaterialPedidoLote_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles vwMaterialPedidoLote.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        Dim Valor As Integer = 0


        Try
            Cursor = Cursors.WaitCursor
            If ListaPuntos.Exists(Function(x) x = e.Column.FieldName) = True Then
                Valor = currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)
                If Valor > 0 Then
                    e.Appearance.BackColor = Color.LightSalmon
                End If

            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub vwMaterialPedidoLoteAtado_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs)
        Dim currentView As GridView = CType(sender, GridView)
        Dim Valor As Integer = 0


        Try
            Cursor = Cursors.WaitCursor
            If ListaPuntos.Exists(Function(x) x = e.Column.FieldName) = True Then
                Valor = currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)
                If Valor > 0 Then
                    e.Appearance.BackColor = Color.LightSalmon
                End If

            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub vwMaterialPedidoPartida_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs)
        Dim currentView As GridView = CType(sender, GridView)
        Dim Valor As Integer = 0


        Try
            Cursor = Cursors.WaitCursor
            If ListaPuntos.Exists(Function(x) x = e.Column.FieldName) = True Then
                Valor = currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)
                If Valor > 0 Then
                    e.Appearance.BackColor = Color.LightSalmon
                End If

            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnExportarInventarioProceso_Click(sender As Object, e As EventArgs) Handles btnExportarInventarioProceso.Click
        Try
            Cursor = Cursors.WaitCursor
            ExportarExcel(ObtenerTipoConsulta())
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub ExportarExcel(ByVal TipoReporte As Integer)
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim NombreArchivo As String = String.Empty

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then
                    Dim exportOptions = New XlsxExportOptionsEx()
                    If TipoReporte = 1 Then
                        ' AddHandler ExportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                        NombreArchivo = .SelectedPath + "\Datos_MaterialPedido_" + fecha_hora + ".xlsx"
                        'grdMaterialPedido.ExportToXlsx(NombreArchivo, exportOptions)
                        grdMaterialPedido.ExportToXlsx(NombreArchivo)
                        show_message("Exito", "Los datos se exportaron correctamente: " & "Datos_MaterialPedido_" & fecha_hora.ToString() & ".xlsx")
                    ElseIf TipoReporte = 2 Then
                        'AddHandler ExportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                        NombreArchivo = .SelectedPath + "\Datos_MaterialPedidoLote_" + fecha_hora + ".xlsx"
                        'grdMaterialPedidoLote.ExportToXlsx(NombreArchivo, exportOptions)
                        grdMaterialPedidoLote.ExportToXlsx(NombreArchivo)
                        show_message("Exito", "Los datos se exportaron correctamente: " & "Datos_MaterialPedidoLote_" & fecha_hora.ToString() & ".xlsx")
                    End If
                    .Dispose()
                    Process.Start(NombreArchivo)
                End If
            End With
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

        Dim TipoReporte As Integer = 0
        Dim currentView As New GridView
        Dim TotalParesProceso As Integer = 0

        Try
            'TipoReporte = ObtenerTipoConsulta()
            'If TipoReporte = 1 Then
            '    currentView = vwMaterialPedido
            'ElseIf TipoReporte = 2 Then
            '    currentView = vwMaterialPedidoLote
            'End If


            'If ListaPuntos.Exists(Function(x) x = e.ColumnFieldName) = True Then
            '    TotalParesProceso = currentView.GetRowCellValue(e.RowHandle, e.ColumnFieldName)
            '    If TotalParesProceso > 0 Then
            '        e.Formatting.BackColor = Color.LightSalmon
            '    End If
            'End If

        Catch ex As Exception

        End Try

        e.Handled = True

    End Sub

    Public Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                Resultado += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        Return Resultado
    End Function

    Private Sub btnAgregarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroCliente.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 1
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFiltroCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroCliente.DataSource = listado.listParametros
        With grdFiltroCliente
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
        End With
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdFiltroCliente.DataSource = Nothing
    End Sub

    Private Sub grdFiltroCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroCliente.InitializeLayout
        grid_diseño(grdFiltroCliente)
        grdFiltroCliente.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub grdFiltroCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFiltroCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFiltroCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        asignaFormato_Columna(grid)

    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive
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

    Private Sub btnAgregarFiltroColeccion_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroColeccion.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 6
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFiltroColeccion.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroColeccion.DataSource = listado.listParametros
        With grdFiltroColeccion
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colección"
        End With
    End Sub

    Private Sub btnAgregarFiltroModelo_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroModelo.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 7
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFiltroModelo.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroModelo.DataSource = listado.listParametros
        With grdFiltroModelo
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Modelo"
        End With
    End Sub

    Private Sub btnLimpiarFiltroColeccion_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroColeccion.Click
        grdFiltroColeccion.DataSource = Nothing
    End Sub

    Private Sub btnLimpiarFiltroModelo_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroModelo.Click
        grdFiltroColeccion.DataSource = Nothing
    End Sub

    Private Sub grdFiltroColeccion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroColeccion.InitializeLayout
        grid_diseño(grdFiltroColeccion)
        grdFiltroColeccion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Colección"
    End Sub

    Private Sub grdFiltroColeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFiltroColeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFiltroColeccion.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFiltroModelo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroModelo.InitializeLayout
        grid_diseño(grdFiltroModelo)
        grdFiltroModelo.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Modelo"
    End Sub

    Private Sub grdFiltroModelo_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFiltroModelo.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFiltroModelo.DeleteSelectedRows(False)
    End Sub

    Private Sub txtLote_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLote.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtLote.Text) Then Return

            ListaLote.Add(txtLote.Text)
            grdFiltroLote.DataSource = Nothing
            grdFiltroLote.DataSource = ListaLote

            txtLote.Text = String.Empty
        End If
    End Sub

    Private Sub txtPedidoSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSAY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSAY.Text) Then Return

            ListaPedidoSAY.Add(txtPedidoSAY.Text)
            grdFiltroPedidoSAY.DataSource = Nothing
            grdFiltroPedidoSAY.DataSource = ListaPedidoSAY

            txtPedidoSAY.Text = String.Empty
        End If
    End Sub

    Private Sub txtPedidoSICY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSICY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSICY.Text) Then Return

            ListaPedidoSICY.Add(txtPedidoSICY.Text)
            grdFiltroPedidoSICY.DataSource = Nothing
            grdFiltroPedidoSICY.DataSource = ListaPedidoSICY

            txtPedidoSICY.Text = String.Empty
        End If
    End Sub

    Private Sub grdFiltroPedidoSAY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroPedidoSAY.InitializeLayout
        grid_diseño(grdFiltroPedidoSAY)
        grdFiltroPedidoSAY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdFiltroPedidoSICY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroPedidoSICY.InitializeLayout
        grid_diseño(grdFiltroPedidoSICY)
        grdFiltroPedidoSICY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SICY"
    End Sub

    Private Sub grdFiltroLote_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroLote.InitializeLayout
        grid_diseño(grdFiltroLote)
        grdFiltroLote.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Lote"
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdFiltroPedidoSAY.DataSource = Nothing
        grdFiltroPedidoSICY.DataSource = Nothing
        grdFiltroLote.DataSource = Nothing
        grdFiltroCliente.DataSource = Nothing
        grdFiltroColeccion.DataSource = Nothing
        grdFiltroModelo.DataSource = Nothing
        ListaLote.Clear()
        ListaPedidoSAY.Clear()
        ListaPedidoSICY.Clear()
    End Sub

    Private Sub grdFiltroPedidoSAY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFiltroPedidoSAY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFiltroPedidoSAY.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFiltroPedidoSICY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFiltroPedidoSICY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFiltroPedidoSICY.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFiltroLote_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFiltroLote.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFiltroLote.DeleteSelectedRows(False)
    End Sub

    Private Sub btnLimpiarFiltroStatus_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroStatus.Click
        grdStatusPedido.DataSource = Nothing
    End Sub

    Private Sub grdStatusPedido_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdStatusPedido.InitializeLayout
        grid_diseño(grdStatusPedido)
        grdStatusPedido.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Status Pedido"
    End Sub

    Private Sub grdStatusPedido_KeyDown(sender As Object, e As KeyEventArgs) Handles grdStatusPedido.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdStatusPedido.DeleteSelectedRows(False)
    End Sub

    Private Sub btnAgregarStatus_Click(sender As Object, e As EventArgs) Handles btnAgregarStatus.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 11

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdStatusPedido.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdStatusPedido.DataSource = listado.listParametros
        With grdStatusPedido
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Status"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class