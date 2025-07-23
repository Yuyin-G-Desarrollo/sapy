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
Imports DevExpress.XtraEditors.Repository
Imports System
Imports System.ComponentModel
Imports DevExpress.XtraGrid.Columns



Public Class CancelacionPartidasForm

    Public PedidoSAYID As Integer = 0
    Dim objBU As New Ventas.Negocios.CancelacionPedidosBU
    Public CancelacionPedidosForm As CancelacionPedidosForm
    Dim CanceloPartidas As Boolean = False

    Dim emptyEditor As RepositoryItem

    Private Sub CancelacionPartidasForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If CanceloPartidas = True Then
            Try
                Cursor = Cursors.WaitCursor
                CancelacionPedidosForm.CargarPedidos()
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
                show_message("Error", "Ocurrio un error al mostrar la información.Intente de nuevo.")
            End Try

        End If
    End Sub

    Private Sub CancelacionPartidasForm_Load(sender As Object, e As EventArgs) Handles Me.Load        
        CargarPantalla()
        emptyEditor = New RepositoryItem()
        grdPartidas.RepositoryItems.Add(emptyEditor)


        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CargarPantalla()
        Try
            Cursor = Cursors.WaitCursor
            CargarInformacionPedido()
            ConsultarPartidas()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al cargar la información. vuelva a intentar.")
        End Try
    End Sub

    Private Sub ConsultarPartidas()
        grdPartidas.DataSource = objBU.ConsultarPartidasPedido(PedidoSAYID)
        DiseñoGrid()
        lblTotalSeleccionados.Text = "0"
        ViewPartidas.OptionsSelection.MultiSelect = True

        lblTotalSeleccionados.Text = CDbl(ViewPartidas.RowCount.ToString()).ToString("n0")

    End Sub

    Private Sub DiseñoGrid()
        ViewPartidas.OptionsView.ColumnAutoWidth = False
        ViewPartidas.OptionsView.BestFitMaxRowCount = -1

        'If IsNothing(ViewPartidas.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
        '    ViewPartidas.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        '    AddHandler ViewPartidas.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
        '    ViewPartidas.Columns.Item("#").VisibleIndex = 0
        'End If

        ViewPartidas.IndicatorWidth = 35

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In ViewPartidas.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        'ViewPartidas.OptionsView.ColumnAutoWidth = True

        'ViewPedidos.Columns.ColumnByFieldName("EstatusID").Visible = False
        ViewPartidas.Columns.ColumnByFieldName("Seleccionar").Caption = " "
        ViewPartidas.Columns.ColumnByFieldName("Partida").Caption = "Part."
        ViewPartidas.Columns.ColumnByFieldName("ParesInventario").Caption = "Inv"    
        ViewPartidas.Columns.ColumnByFieldName("NumeroLotes").Visible = False
        ViewPartidas.Columns.ColumnByFieldName("ParesSalidaApartado").Visible = False
        ViewPartidas.Columns.ColumnByFieldName("TotalParesApartado").Visible = False
        ViewPartidas.Columns.ColumnByFieldName("ParesSinProyectar").Visible = False
        ViewPartidas.Columns.ColumnByFieldName("ParesLotesA").Visible = False

        'ViewPartidas.Columns.ColumnByFieldName("#").Width = 35
        ViewPartidas.Columns.ColumnByFieldName("Seleccionar").Width = 30
        ViewPartidas.Columns.ColumnByFieldName("Partida").Width = 35

        ViewPartidas.Columns.ColumnByFieldName("Programa").Width = 100
        ViewPartidas.Columns.ColumnByFieldName("FCancelacion").Width = 100
        ViewPartidas.Columns.ColumnByFieldName("MotivoCancelacion").Width = 150
        ViewPartidas.Columns.ColumnByFieldName("TotalPares").Width = 60
        ViewPartidas.Columns.ColumnByFieldName("ParesCancelados").Width = 60
        ViewPartidas.Columns.ColumnByFieldName("Apartado").Width = 60
        ViewPartidas.Columns.ColumnByFieldName("Entregado").Width = 60
        ViewPartidas.Columns.ColumnByFieldName("FEntrega").Width = 80
        ViewPartidas.Columns.ColumnByFieldName("Estatus").Width = 100
        ViewPartidas.Columns.ColumnByFieldName("Apartados").Width = 80
        ViewPartidas.Columns.ColumnByFieldName("OT").Width = 80
        ViewPartidas.Columns.ColumnByFieldName("ParesOT").Width = 60
        ViewPartidas.Columns.ColumnByFieldName("Facturas").Width = 80
        ViewPartidas.Columns.ColumnByFieldName("Modelo").Width = 80
        ViewPartidas.Columns.ColumnByFieldName("Marca").Width = 80
        ViewPartidas.Columns.ColumnByFieldName("Coleccion").Width = 80
        ViewPartidas.Columns.ColumnByFieldName("Piel").Width = 80
        ViewPartidas.Columns.ColumnByFieldName("Color").Width = 80
        ViewPartidas.Columns.ColumnByFieldName("Corrida").Width = 80
        ViewPartidas.Columns.ColumnByFieldName("Tienda").Width = 120
        'ViewPartidas.Columns.ColumnByFieldName("Partida").Width = 80
        ViewPartidas.Columns.ColumnByFieldName("EstatusPartida").Width = 80
        ViewPartidas.Columns.ColumnByFieldName("TotalParesFacturados").Width = 60
        ViewPartidas.Columns.ColumnByFieldName("ParesSalidaApartado").Width = 60
        ViewPartidas.Columns.ColumnByFieldName("TotalParesApartado").Width = 60
        ViewPartidas.Columns.ColumnByFieldName("ParesProceso").Width = 60
        ViewPartidas.Columns.ColumnByFieldName("ParesInventario").Width = 60

        ViewPartidas.Columns.ColumnByFieldName("TotalPares").Caption = "Pares"
        ViewPartidas.Columns.ColumnByFieldName("ParesCancelados").Caption = "Cancelados"
        ViewPartidas.Columns.ColumnByFieldName("TotalParesFacturados").Caption = "Facturados"
        ViewPartidas.Columns.ColumnByFieldName("ParesProceso").Caption = "Proceso"
        ViewPartidas.Columns.ColumnByFieldName("ParesInventario").Caption = "Inv"
        ViewPartidas.Columns.ColumnByFieldName("Pendiente").Caption = "Pendiente"

        ViewPartidas.Columns.ColumnByFieldName("TotalPares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPartidas.Columns.ColumnByFieldName("ParesCancelados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPartidas.Columns.ColumnByFieldName("Apartado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPartidas.Columns.ColumnByFieldName("Pendiente").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPartidas.Columns.ColumnByFieldName("ParesOT").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPartidas.Columns.ColumnByFieldName("TotalParesFacturados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPartidas.Columns.ColumnByFieldName("ParesSalidaApartado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPartidas.Columns.ColumnByFieldName("TotalParesApartado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPartidas.Columns.ColumnByFieldName("ParesProceso").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPartidas.Columns.ColumnByFieldName("ParesInventario").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPartidas.Columns.ColumnByFieldName("ParesSinProyectar").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPartidas.Columns.ColumnByFieldName("ParesLotesA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPartidas.Columns.ColumnByFieldName("POTDesasignacion").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        ViewPartidas.Columns.ColumnByFieldName("TotalPares").DisplayFormat.FormatString = "N0"
        ViewPartidas.Columns.ColumnByFieldName("ParesCancelados").DisplayFormat.FormatString = "N0"
        ViewPartidas.Columns.ColumnByFieldName("Apartado").DisplayFormat.FormatString = "N0"
        ViewPartidas.Columns.ColumnByFieldName("Pendiente").DisplayFormat.FormatString = "N0"
        ViewPartidas.Columns.ColumnByFieldName("ParesOT").DisplayFormat.FormatString = "N0"
        ViewPartidas.Columns.ColumnByFieldName("TotalParesFacturados").DisplayFormat.FormatString = "N0"
        ViewPartidas.Columns.ColumnByFieldName("ParesSalidaApartado").DisplayFormat.FormatString = "N0"
        ViewPartidas.Columns.ColumnByFieldName("TotalParesApartado").DisplayFormat.FormatString = "N0"
        ViewPartidas.Columns.ColumnByFieldName("ParesProceso").DisplayFormat.FormatString = "N0"
        ViewPartidas.Columns.ColumnByFieldName("ParesInventario").DisplayFormat.FormatString = "N0"
        ViewPartidas.Columns.ColumnByFieldName("ParesSinProyectar").DisplayFormat.FormatString = "N0"
        ViewPartidas.Columns.ColumnByFieldName("ParesLotesA").DisplayFormat.FormatString = "N0"
        ViewPartidas.Columns.ColumnByFieldName("POTDesasignacion").DisplayFormat.FormatString = "N0"

        'ViewPedidos.Columns.ColumnByFieldName("FechaCaptura").DisplayFormat.FormatString = "dd/mm/yyyy HH:mm:ss"


        '   ViewPedidos.Columns.ColumnByFieldName("Cliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains


        ViewPartidas.Columns.ColumnByFieldName("Modelo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        ViewPartidas.Columns.ColumnByFieldName("Marca").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        ViewPartidas.Columns.ColumnByFieldName("Coleccion").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        ViewPartidas.Columns.ColumnByFieldName("Piel").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        ViewPartidas.Columns.ColumnByFieldName("Color").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        ViewPartidas.Columns.ColumnByFieldName("Corrida").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        ViewPartidas.Columns.ColumnByFieldName("Tienda").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains    
        ViewPartidas.Columns.ColumnByFieldName("ParesInventario").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        'ViewPartidas.Columns.ColumnByFieldName("#").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("Seleccionar").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("Programa").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("FCancelacion").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("MotivoCancelacion").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("ParesOT").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("TotalParesFacturados").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("ParesInventario").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("ParesSinProyectar").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("ParesLotesA").OptionsColumn.AllowSize = True


        ViewPartidas.Columns.ColumnByFieldName("ParesSalidaApartado").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("TotalParesApartado").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("ParesProceso").OptionsColumn.AllowSize = True

        'ViewPartidas.Columns.ColumnByFieldName("PedidoSICY").OptionsColumn.AllowSize = True
        'ViewPartidas.Columns.ColumnByFieldName("PedidoSAY").OptionsColumn.AllowSize = True
        'ViewPartidas.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowSize = True

        ViewPartidas.Columns.ColumnByFieldName("TotalPares").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("ParesCancelados").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("Apartado").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("Entregado").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("Pendiente").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("FEntrega").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("Estatus").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("Apartados").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("OT").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("Facturas").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("Modelo").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("Marca").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("Coleccion").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("Piel").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("Color").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("Corrida").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("Tienda").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("Partida").OptionsColumn.AllowSize = True
        ViewPartidas.Columns.ColumnByFieldName("POTDesasignacion").OptionsColumn.AllowSize = True

        'ViewPartidas.Columns.ColumnByFieldName("#").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("Programa").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("Seleccionar").OptionsColumn.AllowEdit = True
        ViewPartidas.Columns.ColumnByFieldName("FCancelacion").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("MotivoCancelacion").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("TotalParesFacturados").OptionsColumn.AllowEdit = False
        'ViewPartidas.Columns.ColumnByFieldName("PedidoSICY").OptionsColumn.AllowEdit = False
        'ViewPartidas.Columns.ColumnByFieldName("PedidoSAY").OptionsColumn.AllowEdit = False
        'ViewPartidas.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("TotalPares").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("ParesCancelados").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("Apartado").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("Entregado").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("Pendiente").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("FEntrega").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("Estatus").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("Apartados").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("OT").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("Facturas").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("Modelo").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("Marca").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("Coleccion").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("Piel").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("Color").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("Corrida").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("Tienda").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("Partida").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("ParesOT").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("ParesInventario").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("ParesSinProyectar").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("ParesLotesA").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("POTDesasignacion").OptionsColumn.AllowEdit = False

        ViewPartidas.Columns.ColumnByFieldName("ParesSalidaApartado").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("TotalParesApartado").OptionsColumn.AllowEdit = False
        ViewPartidas.Columns.ColumnByFieldName("ParesProceso").OptionsColumn.AllowEdit = False

        ViewPartidas.Columns.ColumnByFieldName("EstatusPartida").Visible = False
        ViewPartidas.Columns.ColumnByFieldName("FechaProgramaA").Visible = False

        ViewPartidas.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(ViewPartidas.Columns("POTDesasignacion").Summary.FirstOrDefault(Function(x) x.FieldName = "POTDesasignacion")) = True Then
            ViewPartidas.Columns("POTDesasignacion").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "POTDesasignacion", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "POTDesasignacion"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            ViewPartidas.GroupSummary.Add(item)
        End If

        If IsNothing(ViewPartidas.Columns("TotalPares").Summary.FirstOrDefault(Function(x) x.FieldName = "TotalPares")) = True Then
            ViewPartidas.Columns("TotalPares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalPares", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "TotalPares"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            ViewPartidas.GroupSummary.Add(item)
        End If

        If IsNothing(ViewPartidas.Columns("ParesCancelados").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesCancelados")) = True Then
            ViewPartidas.Columns("ParesCancelados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesCancelados", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "ParesCancelados"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            ViewPartidas.GroupSummary.Add(item2)
        End If

        If IsNothing(ViewPartidas.Columns("Apartado").Summary.FirstOrDefault(Function(x) x.FieldName = "Apartado")) = True Then
            ViewPartidas.Columns("Apartado").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Apartado", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "Apartado"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            ViewPartidas.GroupSummary.Add(item2)
        End If

        If IsNothing(ViewPartidas.Columns("ParesOT").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesOT")) = True Then
            ViewPartidas.Columns("ParesOT").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesOT", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "ParesOT"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            ViewPartidas.GroupSummary.Add(item2)
        End If

        If IsNothing(ViewPartidas.Columns("Entregado").Summary.FirstOrDefault(Function(x) x.FieldName = "Entregado")) = True Then
            ViewPartidas.Columns("Entregado").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Entregado", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "Entregado"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            ViewPartidas.GroupSummary.Add(item2)
        End If

        If IsNothing(ViewPartidas.Columns("Pendiente").Summary.FirstOrDefault(Function(x) x.FieldName = "Pendiente")) = True Then
            ViewPartidas.Columns("Pendiente").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pendiente", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "Pendiente"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            ViewPartidas.GroupSummary.Add(item2)
        End If

        If IsNothing(ViewPartidas.Columns("TotalParesFacturados").Summary.FirstOrDefault(Function(x) x.FieldName = "TotalParesFacturados")) = True Then
            ViewPartidas.Columns("TotalParesFacturados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalParesFacturados", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "TotalParesFacturados"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            ViewPartidas.GroupSummary.Add(item2)
        End If


        If IsNothing(ViewPartidas.Columns("ParesSalidaApartado").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesSalidaApartado")) = True Then
            ViewPartidas.Columns("ParesSalidaApartado").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesSalidaApartado", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "ParesSalidaApartado"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            ViewPartidas.GroupSummary.Add(item2)
        End If

        If IsNothing(ViewPartidas.Columns("TotalParesApartado").Summary.FirstOrDefault(Function(x) x.FieldName = "TotalParesApartado")) = True Then
            ViewPartidas.Columns("TotalParesApartado").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalParesApartado", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "TotalParesApartado"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            ViewPartidas.GroupSummary.Add(item2)
        End If

        If IsNothing(ViewPartidas.Columns("ParesProceso").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesProceso")) = True Then
            ViewPartidas.Columns("ParesProceso").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesProceso", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "ParesProceso"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            ViewPartidas.GroupSummary.Add(item2)
        End If

        If IsNothing(ViewPartidas.Columns("ParesInventario").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesInventario")) = True Then
            ViewPartidas.Columns("ParesInventario").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesInventario", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "ParesInventario"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            ViewPartidas.GroupSummary.Add(item2)
        End If



    End Sub

    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = ViewPartidas.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub


    Private Sub CargarInformacionPedido()
        Dim objent As New Entidades.CancelacionPedidos

        Try
            objent = objBU.ConsultaInformacionPedido(PedidoSAYID)
            lblTextoPedidoSAY.Text = objent.PedidoSAY
            lblTextoCliente.Text = objent.Cliente
            lblTextoEstatus.Text = objent.Estatus
            lblTextoFechaEntrega.Text = objent.FechaProgramacion
            'lblTextoMoneda.Text = objent.Moneda
            lblTextoPedidoSICY.Text = objent.PedidoSICY
            lblTextoAgente.Text = objent.Agente
            'lblTextoListaPrecios.Text = objent.ListraPrecioCliente
            lblTextoEntregaCliente.Text = objent.FechaCliente
            'lblTextoEnviara.Text = objent.EnviarA
            lblTextoOrden.Text = objent.OrdenCliente
            lblTextoMarca.Text = objent.Marca
            'lblTextoTipoApartado.Text = objent.TipoApartado
            'lblTextoNotasPedido.Text = objent.NotasPedido
            lblTextoObservaciones.Text = objent.Observaciones
            lblTextoCaptura.Text = objent.FechaCaptura.ToShortDateString() + " - " + objent.Capturo
            lblTextoRFC.Text = objent.RazonSocial + vbCrLf + " (" + objent.RFC + ")"
            'lblTextoPedido.Text = objent.Inicial
            'lblTextoRamo.Text = objent.Ramo
            'lblTextoVigencia.Text = objent.Vigencia
            'lblTextoRestriccionFactura.Text = objent.RestriccionFacturacion
        Catch ex As Exception
            show_message("Error", "Ocurrio un error al mostrar la información.V Vuelva a intentar nuevamente.")
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
       

        Me.Close()
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

    Private Sub ViewPartidas_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles ViewPartidas.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)        
        Dim FechaPrograma As Date
        Dim NumeroLotes As Integer = 0
        Dim FechaActual As Date
        Dim FechaNula As Date = Nothing
        Dim ParesProceso As Integer = 0
        Dim ParesSalidaApartado As Integer = 0
        Dim TotalParesApartado As Integer = 0
        Dim TotalParesFacturados As Integer = 0
        Dim TotalPares As Integer = 0
        Dim ParesCancelados As Integer = 0
        Dim Entregado As Integer = 0

        Try

            Dim Facturas As String = String.Empty
            Dim OT As String = String.Empty
            Dim Apartado As String = String.Empty


            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, "TotalParesFacturados")) = False Then
                TotalParesFacturados = currentView.GetRowCellValue(e.RowHandle, "TotalParesFacturados")
            End If

            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, "TotalPares")) = False Then
                TotalPares = currentView.GetRowCellValue(e.RowHandle, "TotalPares")
            End If

            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, "TotalPares")) = False Then
                TotalPares = currentView.GetRowCellValue(e.RowHandle, "TotalPares")
            End If

            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, "ParesCancelados")) = False Then
                ParesCancelados = currentView.GetRowCellValue(e.RowHandle, "ParesCancelados")
            End If

            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, "Entregado")) = False Then
                Entregado = currentView.GetRowCellValue(e.RowHandle, "Entregado")
            End If

            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, "ParesProceso")) = False Then
                ParesProceso = currentView.GetRowCellValue(e.RowHandle, "ParesProceso")
            End If

            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, "ParesSalidaApartado")) = False Then
                ParesSalidaApartado = currentView.GetRowCellValue(e.RowHandle, "ParesSalidaApartado")
            End If

            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, "TotalParesApartado")) = False Then
                TotalParesApartado = currentView.GetRowCellValue(e.RowHandle, "TotalParesApartado")
            End If

            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, "Facturas")) = False Then
                Facturas = currentView.GetRowCellValue(e.RowHandle, "Facturas")
            End If

            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, "OT")) = False Then
                OT = currentView.GetRowCellValue(e.RowHandle, "OT")
            End If

            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, "Apartado")) = False Then
                Apartado = currentView.GetRowCellValue(e.RowHandle, "Apartado")
            End If


            If e.Column.FieldName = "Facturas" And Facturas <> String.Empty Then
                e.Appearance.ForeColor = Color.Red
            End If

            If e.Column.FieldName = "OT" And OT <> String.Empty Then
                e.Appearance.ForeColor = Color.Red
            End If

            If e.Column.FieldName = "Apartados" And Apartado <> String.Empty Then
                e.Appearance.ForeColor = Color.Red
            End If


            FechaActual = Date.Now.ToShortDateString()

            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, currentView.Columns("Programa"))) = False Then
                FechaPrograma = currentView.GetRowCellValue(e.RowHandle, currentView.Columns("Programa"))
            Else
                FechaPrograma = Nothing
            End If

            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, currentView.Columns("NumeroLotes"))) = False Then
                NumeroLotes = currentView.GetRowCellValue(e.RowHandle, currentView.Columns("NumeroLotes"))
            Else
                NumeroLotes = 0
            End If


            If e.Column.FieldName = "Programa" Then
                If NumeroLotes > 0 Then
                    e.Appearance.ForeColor = Color.Red
                End If

                If FechaPrograma <> FechaNula Then
                    If NumeroLotes > 0 Then
                        e.Appearance.ForeColor = Color.Red
                    Else
                        If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                            e.Appearance.ForeColor = Color.Red
                        End If
                    End If
                End If
            End If
           

            If e.Column.FieldName = "NumeroLotes" Then
                If NumeroLotes > 0 Then
                    e.Appearance.ForeColor = Color.Red
                End If
            End If



        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub ViewPartidas_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ViewPartidas.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Try
                Cursor = Cursors.WaitCursor
                Dim Facturas As String = String.Empty
                Dim OT As String = String.Empty
                Dim Apartado As String = String.Empty
                Dim TotalParesFacturados As Integer = 0
                Dim ParesCancelados As Integer = 0
                Dim ParesPartida As Integer = 0
                Dim ParesEntregados As Integer = 0
                Dim FechaPrograma As Date
                Dim NumeroLotes As Integer = 0                
                Dim FechaNula As Date = Nothing
                Dim ParesOT As Integer = 0
                Dim ParesApartado As Integer = 0
                Dim Partida As Integer = 0
                Dim ParesProceso As Integer = 0
                Dim ParesSalidaApartado As Integer = 0
                Dim TotalParesApartado As Integer = 0
                Dim ParesLotesA As Integer = 0
                Dim ParesSinProyectar As Integer = 0
                Dim ParesOTDesasignacion As Integer = 0

                Dim EstatusPartida As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EstatusPartida"))

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("POTDesasignacion"))) = False Then
                    ParesOTDesasignacion = View.GetRowCellValue(e.RowHandle, View.Columns("POTDesasignacion"))
                Else
                    ParesOTDesasignacion = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("ParesLotesA"))) = False Then
                    ParesLotesA = View.GetRowCellValue(e.RowHandle, View.Columns("ParesLotesA"))
                Else
                    ParesLotesA = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("ParesSinProyectar"))) = False Then
                    ParesSinProyectar = View.GetRowCellValue(e.RowHandle, View.Columns("ParesSinProyectar"))
                Else
                    ParesSinProyectar = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("Partida"))) = False Then
                    Partida = View.GetRowCellValue(e.RowHandle, View.Columns("Partida"))
                Else
                    Partida = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("ParesOT"))) = False Then
                    ParesOT = View.GetRowCellValue(e.RowHandle, View.Columns("ParesOT"))
                Else
                    ParesOT = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("Programa"))) = False Then
                    FechaPrograma = View.GetRowCellValue(e.RowHandle, View.Columns("Programa"))
                Else
                    FechaPrograma = Nothing
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("NumeroLotes"))) = False Then
                    NumeroLotes = View.GetRowCellValue(e.RowHandle, View.Columns("NumeroLotes"))
                Else
                    NumeroLotes = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, "Apartado")) = False Then
                    ParesApartado = View.GetRowCellValue(e.RowHandle, "Apartado").ToString()
                Else
                    ParesApartado = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, "Apartados")) = False Then
                    Apartado = View.GetRowCellValue(e.RowHandle, "Apartados").ToString()
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("TotalParesFacturados"))) = False Then
                    TotalParesFacturados = View.GetRowCellValue(e.RowHandle, View.Columns("TotalParesFacturados"))
                Else
                    TotalParesFacturados = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("TotalPares"))) = False Then
                    ParesPartida = View.GetRowCellValue(e.RowHandle, View.Columns("TotalPares"))
                Else
                    ParesPartida = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("ParesCancelados"))) = False Then
                    ParesCancelados = View.GetRowCellValue(e.RowHandle, View.Columns("ParesCancelados"))
                Else
                    ParesCancelados = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("Entregado"))) = False Then
                    ParesEntregados = View.GetRowCellValue(e.RowHandle, View.Columns("Entregado"))
                Else
                    ParesEntregados = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("Facturas"))) = False Then
                    Facturas = View.GetRowCellValue(e.RowHandle, View.Columns("Facturas"))
                Else
                    Facturas = String.Empty
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("OT"))) = False Then
                    OT = View.GetRowCellValue(e.RowHandle, View.Columns("OT"))
                Else
                    OT = String.Empty
                End If


                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("ParesProceso"))) = False Then
                    ParesProceso = View.GetRowCellValue(e.RowHandle, View.Columns("ParesProceso"))
                Else
                    ParesProceso = 0
                End If


                If IsDBNull(View.GetRowCellValue(e.RowHandle, "ParesSalidaApartado")) = False Then
                    ParesSalidaApartado = View.GetRowCellValue(e.RowHandle, "ParesSalidaApartado").ToString()
                Else
                    ParesSalidaApartado = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, "TotalParesApartado")) = False Then
                    TotalParesApartado = View.GetRowCellValue(e.RowHandle, "TotalParesApartado").ToString()
                Else
                    TotalParesApartado = 0
                End If


                e.Appearance.BackColor = ObtenerColorFila(EstatusPartida, OT, Facturas, Apartado, TotalParesFacturados, ParesPartida, ParesCancelados, ParesEntregados, ParesOT, FechaPrograma, NumeroLotes, ParesApartado, ParesProceso, ParesSalidaApartado, TotalParesApartado, ParesLotesA, ParesSinProyectar, ParesOTDesasignacion)
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
                show_message("Error", ex.Message.ToString())
            End Try


        End If
    End Sub

    Private Function ObtenerColorFila(ByVal EstatusPartida As Integer, ByVal OT As String, ByVal Facturas As String, ByVal Apartado As String, ByVal TotalParesFacturados As Integer, ByVal ParesPartida As Integer, ByVal ParesCancelados As Integer, ByVal ParesEntregados As Integer, ByVal ParesOT As Integer, ByVal FechaPrograma As Date, ByVal NumeroLotes As Integer, ByVal ParesApartado As Integer, ByVal ParesProceso As Integer, ByVal ParesSalidaApartado As Integer, ByVal TotalParesApartado As Integer, ByVal ParesLotesA As Integer, ByVal ParesSinProyectar As Integer, ByVal ParesDesasignacion As Integer) As Color
        Dim TipoColor As Color = Color.Empty
        Dim FechaNula As Date = Nothing
        Dim FechaActual As Date

        FechaActual = Date.Now.ToShortDateString()

        If EstatusPartida = 14 Or EstatusPartida = 15 Then
            TipoColor = Color.LightGray
        End If

        If OT <> String.Empty Or Facturas <> String.Empty Then
            If Facturas <> String.Empty Then
                If TotalParesFacturados = ParesPartida - ParesCancelados Then
                    TipoColor = Color.LightGray
                End If
            End If

            If OT <> String.Empty Then
                TipoColor = Color.LightGray
            End If
        End If

        If Apartado <> String.Empty Then
            If ParesSalidaApartado <> TotalParesApartado Or ParesApartado <> 0 Then
                TipoColor = Color.LightGray
            End If
        End If

        If ParesProceso > 0 Then
            If ParesSinProyectar <> (ParesLotesA + ParesSalidaApartado - (ParesEntregados + ParesCancelados + ParesOT + ParesApartado)) Then
                If NumeroLotes > 0 Then
                    TipoColor = Color.LightGray
                End If

                If FechaPrograma <> FechaNula Then
                    If NumeroLotes > 0 Then
                        TipoColor = Color.LightGray
                    Else
                        If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                            TipoColor = Color.LightGray
                        End If
                    End If
                End If
            End If
        Else

            If NumeroLotes > 0 Then
                TipoColor = Color.LightGray
            End If

            If FechaPrograma <> FechaNula Then
                If NumeroLotes > 0 Then
                    TipoColor = Color.LightGray
                Else
                    If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                        TipoColor = Color.LightGray
                    End If
                End If
            End If

        End If


        If ParesPartida - ParesCancelados = ParesEntregados Then
            TipoColor = Color.LightGray
        End If

        If ParesPartida <= (ParesCancelados + ParesEntregados + ParesApartado + ParesOT) Then
            TipoColor = Color.LightGray
        End If

        If ParesDesasignacion > 0 Then
            TipoColor = Color.LightGray
        End If





        'If EstatusPartida = 14 Or EstatusPartida = 15 Then
        '    TipoColor = Color.LightGray
        'ElseIf OT <> String.Empty Or Facturas <> String.Empty Then

        '    If Facturas <> String.Empty Then
        '        If TotalParesFacturados = ParesPartida - ParesCancelados Then
        '            TipoColor = Color.LightGray
        '        End If

        '    End If

        '    If OT <> String.Empty Then
        '        TipoColor = Color.LightGray
        '    End If




        'ElseIf Apartado <> String.Empty Then

        '    If ParesSalidaApartado <> TotalParesApartado Or ParesApartado <> 0 Then
        '        TipoColor = Color.LightGray
        '    Else
        '        If ParesProceso = (ParesPartida - ParesCancelados - ParesEntregados) And ParesProceso > 0 Then

        '        Else
        '            If NumeroLotes > 0 Then
        '                TipoColor = Color.LightGray
        '            End If

        '            If FechaPrograma <> FechaNula Then
        '                If NumeroLotes > 0 Then
        '                    TipoColor = Color.LightGray
        '                Else
        '                    If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
        '                        TipoColor = Color.LightGray
        '                    End If
        '                End If
        '            End If

        '            If ParesPartida > 0 Then
        '                If (ParesOT + ParesCancelados + ParesEntregados + ParesApartado) = ParesPartida Then
        '                    TipoColor = Color.LightGray
        '                End If
        '            End If
        '        End If
        '    End If

        'Else
        '    If ParesProceso = (ParesPartida - ParesCancelados - ParesEntregados) And ParesProceso > 0 Then

        '    Else
        '        If NumeroLotes > 0 Then
        '            TipoColor = Color.LightGray
        '        End If

        '        If FechaPrograma <> FechaNula Then
        '            If NumeroLotes > 0 Then
        '                TipoColor = Color.LightGray
        '            Else
        '                If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
        '                    TipoColor = Color.LightGray
        '                End If
        '            End If
        '        End If

        '        If ParesPartida > 0 Then
        '            If (ParesOT + ParesCancelados + ParesEntregados + ParesApartado) = ParesPartida Then
        '                TipoColor = Color.LightGray
        '            End If
        '        End If
        '    End If




        'End If


        Return TipoColor

    End Function


    Private Function OcultarCheckBox(ByVal EstatusPartida As Integer, ByVal OT As String, ByVal Facturas As String, ByVal Apartado As String, ByVal TotalParesFacturados As Integer, ByVal ParesPartida As Integer, ByVal ParesCancelados As Integer, ByVal ParesEntregados As Integer, ByVal ParesOT As Integer, ByVal FechaPrograma As Date, ByVal NumeroLotes As Integer, ByVal ParesApartado As Integer, ByVal ParesProceso As Integer, ByVal ParesSalidaApartado As Integer, ByVal TotalParesApartado As Integer, ByVal ParesLotesA As Integer, ByVal ParesSinProyectar As Integer, ByVal ParesDesasignacion As Integer) As Boolean        
        Dim FechaNula As Date = Nothing
        Dim FechaActual As Date
        Dim MostrarCheckBox As Boolean = True

        FechaActual = Date.Now.ToShortDateString()

        If EstatusPartida = 14 Or EstatusPartida = 15 Then
            MostrarCheckBox = False
        End If

        If OT <> String.Empty Or Facturas <> String.Empty Then
            If Facturas <> String.Empty Then
                If TotalParesFacturados = ParesPartida - ParesCancelados Then
                    MostrarCheckBox = False
                End If
            End If

            If OT <> String.Empty Then
                MostrarCheckBox = False
            End If
        End If

        If Apartado <> String.Empty Then
            If ParesSalidaApartado <> TotalParesApartado Or ParesApartado <> 0 Then
                MostrarCheckBox = False
            End If
        End If

        If ParesProceso > 0 Then
            If ParesSinProyectar <> (ParesLotesA + ParesSalidaApartado - (ParesEntregados + ParesCancelados + ParesOT + ParesApartado)) Then
                If NumeroLotes > 0 Then
                    MostrarCheckBox = False
                End If

                If FechaPrograma <> FechaNula Then
                    If NumeroLotes > 0 Then
                        MostrarCheckBox = False
                    Else
                        If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                            MostrarCheckBox = False
                        End If
                    End If
                End If
            End If
        Else

            If NumeroLotes > 0 Then
                MostrarCheckBox = False
            End If

            If FechaPrograma <> FechaNula Then
                If NumeroLotes > 0 Then
                    MostrarCheckBox = False
                Else
                    If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                        MostrarCheckBox = False
                    End If
                End If
            End If

        End If


        If ParesPartida - ParesCancelados = ParesEntregados Then
            MostrarCheckBox = False
        End If

        If ParesPartida <= (ParesCancelados + ParesEntregados + ParesApartado + ParesOT) Then
            MostrarCheckBox = False
        End If

        If ParesDesasignacion > 0 Then
            MostrarCheckBox = False
        End If


        Return MostrarCheckBox

    End Function


    Private Sub ViewPartidas_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ViewPartidas.ShowingEditor
        Dim View As GridView = sender
        Dim Facturas As String = String.Empty
        Dim OT As String = String.Empty
        Dim Apartado As String = String.Empty
        Dim TotalParesFacturados As Integer = 0
        Dim ParesCancelados As Integer = 0
        Dim ParesPartida As Integer = 0
        Dim ParesApartado As Integer = 0
        Dim ParesEntregados As Integer = 0
        Dim FechaPrograma As Date
        Dim NumeroLotes As Integer = 0
        Dim FechaActual As Date
        Dim FechaNula As Date = Nothing
        Dim ParesOT As Integer = 0
        Dim ParesProceso As Integer = 0
        Dim ParesSalidaApartado As Integer = 0
        Dim TotalParesApartado As Integer = 0
        Dim EstatusPartidaID As Integer = 0
        Dim ParesLotesA As Integer = 0
        Dim ParesSinProyectar As Integer = 0
        Dim ParesOTDesasignacion As Integer = 0


        Try

            FechaActual = Date.Now.ToShortDateString()

            EstatusPartidaID = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("EstatusPartida"))

            If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("POTDesasignacion"))) = False Then
                ParesOTDesasignacion = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("POTDesasignacion"))
            Else
                ParesOTDesasignacion = 0
            End If

            If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("ParesLotesA"))) = False Then
                ParesLotesA = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("ParesLotesA"))
            Else
                ParesLotesA = 0
            End If

            If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("ParesSinProyectar"))) = False Then
                ParesSinProyectar = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("ParesSinProyectar"))
            Else
                ParesSinProyectar = 0
            End If

            If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("ParesProceso"))) = False Then
                ParesProceso = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("ParesProceso"))
            Else
                ParesProceso = 0
            End If

            If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("ParesSalidaApartado"))) = False Then
                ParesSalidaApartado = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("ParesSalidaApartado"))
            Else
                ParesSalidaApartado = 0
            End If

            If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("TotalParesApartado"))) = False Then
                TotalParesApartado = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("TotalParesApartado"))
            Else
                TotalParesApartado = 0
            End If

            If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("Entregado"))) = False Then
                ParesEntregados = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("Entregado"))
            Else
                ParesEntregados = 0
            End If

            If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("ParesOT"))) = False Then
                ParesOT = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("ParesOT"))
            Else
                ParesOT = 0
            End If

            If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("Programa"))) = False Then
                FechaPrograma = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("Programa"))
            Else
                FechaPrograma = Nothing
            End If

            If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("NumeroLotes"))) = False Then
                NumeroLotes = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("NumeroLotes"))
            Else
                NumeroLotes = 0
            End If

            If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("TotalParesFacturados"))) = False Then
                TotalParesFacturados = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("TotalParesFacturados"))
            Else
                TotalParesFacturados = 0
            End If

            If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("TotalPares"))) = False Then
                ParesPartida = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("TotalPares"))
            Else
                ParesPartida = 0
            End If

            If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("ParesCancelados"))) = False Then
                ParesCancelados = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("ParesCancelados"))
            Else
                ParesCancelados = 0
            End If


            'If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, "EstatusPartida")) = False Then
            '    Dim EstatusPartida As Integer = View.GetRowCellValue(View.FocusedRowHandle, "EstatusPartida").ToString()
            '    If EstatusPartida = 14 Or EstatusPartida = 15 Then e.Cancel = True
            'End If

            If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, "Facturas")) = False Then
                Facturas = View.GetRowCellValue(View.FocusedRowHandle, "Facturas").ToString()
            End If

            If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, "OT")) = False Then
                OT = View.GetRowCellValue(View.FocusedRowHandle, "OT").ToString()
            End If

            If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, "Apartado")) = False Then
                ParesApartado = View.GetRowCellValue(View.FocusedRowHandle, "Apartado").ToString()
            Else
                ParesApartado = 0
            End If

            If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, "Apartados")) = False Then
                Apartado = View.GetRowCellValue(View.FocusedRowHandle, "Apartados").ToString()
            End If


            If EstatusPartidaID = 14 Or EstatusPartidaID = 15 Then
                e.Cancel = True           
            End If

            If OT <> String.Empty Or Facturas <> String.Empty Then
                If Facturas <> String.Empty Then
                    If TotalParesFacturados = ParesPartida - ParesCancelados Then
                        e.Cancel = True
                    End If
                End If

                If OT <> String.Empty Then
                    e.Cancel = True
                End If
            End If

            If Apartado <> String.Empty Then
                If ParesSalidaApartado <> TotalParesApartado Or ParesApartado <> 0 Then
                    e.Cancel = True
                End If
            End If


            If ParesProceso > 0 Then
                If ParesSinProyectar <> (ParesLotesA + ParesSalidaApartado - (ParesEntregados + ParesCancelados + ParesOT + ParesApartado)) Then
                    If NumeroLotes > 0 Then
                        e.Cancel = True
                    End If

                    If FechaPrograma <> FechaNula Then
                        If NumeroLotes > 0 Then
                            e.Cancel = True
                        Else
                            If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                                e.Cancel = True
                            End If
                        End If
                    End If
                End If
            Else

                If NumeroLotes > 0 Then
                    e.Cancel = True
                End If

                If FechaPrograma <> FechaNula Then
                    If NumeroLotes > 0 Then
                        e.Cancel = True
                    Else
                        If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                            e.Cancel = True
                        End If
                    End If
                End If

            End If

            If ParesPartida - ParesCancelados = ParesEntregados Then
                e.Cancel = True
            End If

            If ParesPartida <= (ParesCancelados + ParesEntregados + ParesApartado + ParesOT) Then
                e.Cancel = True
            End If


            If ParesOTDesasignacion > 0 Then
                e.Cancel = True
            End If


            'If ParesProceso = (ParesPartida - ParesCancelados - ParesEntregados - ParesOT) And ParesProceso > 0 Then

            'Else
            '    If NumeroLotes > 0 Then
            '        e.Cancel = True
            '    End If

            '    If FechaPrograma <> FechaNula Then
            '        If NumeroLotes > 0 Then
            '            e.Cancel = True
            '        Else
            '            If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
            '                e.Cancel = True
            '            End If
            '        End If
            '    End If

            '    If ParesPartida > 0 Then
            '        If (ParesOT + ParesCancelados + ParesEntregados + ParesApartado) = ParesPartida Then
            '            e.Cancel = True
            '        End If
            '    End If
            'End If

            'If Facturas <> String.Empty Or OT <> String.Empty Or Apartado <> String.Empty Then

            '    If Facturas <> String.Empty Then
            '        If TotalParesFacturados = ParesPartida - ParesCancelados Then
            '            e.Cancel = True
            '        End If
            '    End If

            '    If OT <> String.Empty Then
            '        If (ParesOT + ParesCancelados + ParesEntregados + ParesApartado) = ParesPartida Then
            '            e.Cancel = True
            '        End If
            '    End If

            '    If ParesPartida > 0 Then
            '        If (ParesOT + ParesCancelados + ParesEntregados + ParesApartado) = ParesPartida Then
            '            e.Cancel = True
            '        End If
            '    End If

            'End If

            'If ParesPartida > 0 Then
            '    If (ParesOT + ParesCancelados + ParesEntregados + ParesApartado) = ParesPartida Then
            '        e.Cancel = True
            '    End If
            'End If

            'If NumeroLotes > 0 Then
            '    e.Cancel = True
            'End If

            'If FechaPrograma <> FechaNula Then
            '    If NumeroLotes > 0 Then
            '        e.Cancel = True
            '    Else
            '        If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
            '            e.Cancel = True
            '        End If
            '    End If
            'End If

        Catch ex As Exception
            show_message("Error", "Ocurrio un error al mostrar la información. Intentelo de nuevo.")
        End Try

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + "_" + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then

                    If GridView1.GroupCount > 0 Then
                        grdPartidas.ExportToXlsx(.SelectedPath + "\Datos_CancelacionPartidas_" + PedidoSAYID.ToString + "_" + fecha_hora + ".xlsx")
                    Else
                        Dim exportOptions = New XlsxExportOptionsEx()
                        
                        AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                        grdPartidas.ExportToXlsx(.SelectedPath + "\Datos_CancelacionPartidas_" + PedidoSAYID.ToString + "_" + fecha_hora + ".xlsx", exportOptions)

                    End If

                    show_message("Exito", "Los datos se exportaron correctamente: " & "Datos_CancelacionPartidas_" & PedidoSAYID.ToString + "_" & fecha_hora.ToString() & ".xlsx")

                    .Dispose()

                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_CancelacionPartidas_" & PedidoSAYID.ToString + "_" + fecha_hora + ".xlsx")
                End If



            End With
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

        Dim Facturas As String = String.Empty
        Dim OT As String = String.Empty
        Dim Apartado As String = String.Empty
        Dim FechaPrograma As Date
        Dim NumeroLotes As Integer = 0
        Dim FechaActual As Date
        Dim FechaNula As Date = Nothing

        Dim TotalParesFacturados As Integer = 0
        Dim ParesCancelados As Integer = 0
        Dim ParesPartida As Integer = 0
        Dim ParesEntregados As Integer = 0
        Dim ParesOT As Integer = 0
        Dim ParesApartado As Integer = 0
        Dim Partida As Integer = 0
        Dim ParesProceso As Integer = 0
        Dim ParesSalidaApartado As Integer = 0
        Dim TotalParesApartado As Integer = 0
        Dim ParesLotesA As Integer = 0
        Dim ParesSinProyectar As Integer = 0
        Dim ParesOTDesasignacion As Integer = 0

        Try
            Dim EstatusID As Integer = ViewPartidas.GetRowCellValue(e.RowHandle, "EstatusPartida")
            FechaActual = Date.Now.ToShortDateString()

            If IsDBNull(ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("POTDesasignacion"))) = False Then
                ParesOTDesasignacion = ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("POTDesasignacion"))
            Else
                ParesOTDesasignacion = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("ParesLotesA"))) = False Then
                ParesLotesA = ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("ParesLotesA"))
            Else
                ParesLotesA = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("ParesSinProyectar"))) = False Then
                ParesSinProyectar = ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("ParesSinProyectar"))
            Else
                ParesSinProyectar = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("ParesProceso"))) = False Then
                ParesProceso = ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("ParesProceso"))
            Else
                ParesProceso = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("ParesSalidaApartado"))) = False Then
                ParesSalidaApartado = ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("ParesSalidaApartado"))
            Else
                ParesSalidaApartado = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("TotalParesApartado"))) = False Then
                TotalParesApartado = ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("TotalParesApartado"))
            Else
                TotalParesApartado = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("Partida"))) = False Then
                Partida = ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("Partida"))
            Else
                Partida = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("ParesOT"))) = False Then
                ParesOT = ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("ParesOT"))
            Else
                ParesOT = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("Apartado"))) = False Then
                ParesApartado = ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("Apartado"))
            Else
                ParesApartado = 0
            End If


            If IsDBNull(ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("TotalPares"))) = False Then
                ParesPartida = ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("TotalPares"))
            Else
                ParesPartida = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("Entregado"))) = False Then
                ParesEntregados = ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("Entregado"))
            Else
                ParesEntregados = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("ParesCancelados"))) = False Then
                ParesCancelados = ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("ParesCancelados"))
            Else
                ParesCancelados = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("TotalParesFacturados"))) = False Then
                TotalParesFacturados = ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("TotalParesFacturados"))
            Else
                TotalParesFacturados = 0
            End If


            If IsDBNull(ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("Programa"))) = False Then
                FechaPrograma = ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("Programa"))
            Else
                FechaPrograma = Nothing
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("NumeroLotes"))) = False Then
                NumeroLotes = ViewPartidas.GetRowCellValue(e.RowHandle, ViewPartidas.Columns("NumeroLotes"))
            Else
                NumeroLotes = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(e.RowHandle, "Facturas")) = False Then
                Facturas = ViewPartidas.GetRowCellValue(e.RowHandle, "Facturas")
            Else
                Facturas = String.Empty
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(e.RowHandle, "OT")) = False Then
                OT = ViewPartidas.GetRowCellValue(e.RowHandle, "OT")
            Else
                OT = String.Empty
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(e.RowHandle, "Apartado")) = False Then
                Apartado = ViewPartidas.GetRowCellValue(e.RowHandle, "Apartado")
            Else
                Apartado = String.Empty
            End If



            If EstatusID = 14 Or EstatusID = 15 Then
                e.Formatting.BackColor = Color.LightGray
            End If

            If OT <> String.Empty Or Facturas <> String.Empty Then
                If Facturas <> String.Empty Then
                    If TotalParesFacturados = ParesPartida - ParesCancelados Then
                        e.Formatting.BackColor = Color.LightGray
                    End If
                End If

                If OT <> String.Empty Then
                    e.Formatting.BackColor = Color.LightGray
                End If
            End If

            If Apartado <> String.Empty Then
                If ParesSalidaApartado <> TotalParesApartado Or ParesApartado <> 0 Then
                    e.Formatting.BackColor = Color.LightGray
                End If
            End If


            If ParesProceso > 0 Then
                If ParesSinProyectar <> (ParesLotesA + ParesSalidaApartado - (ParesEntregados + ParesCancelados + ParesOT + ParesApartado)) Then
                    If NumeroLotes > 0 Then
                        e.Formatting.BackColor = Color.LightGray
                    End If

                    If FechaPrograma <> FechaNula Then
                        If NumeroLotes > 0 Then
                            e.Formatting.BackColor = Color.LightGray
                        Else
                            If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                                e.Formatting.BackColor = Color.LightGray
                            End If
                        End If
                    End If
                End If
            Else

                If NumeroLotes > 0 Then
                    e.Formatting.BackColor = Color.LightGray
                End If

                If FechaPrograma <> FechaNula Then
                    If NumeroLotes > 0 Then
                        e.Formatting.BackColor = Color.LightGray
                    Else
                        If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                            e.Formatting.BackColor = Color.LightGray
                        End If
                    End If
                End If

            End If

            If ParesPartida - ParesCancelados = ParesEntregados Then
                e.Formatting.BackColor = Color.LightGray
            End If

            If ParesPartida <= (ParesCancelados + ParesEntregados + ParesApartado + ParesOT) Then
                e.Formatting.BackColor = Color.LightGray
            End If

            If ParesOTDesasignacion > 0 Then
                e.Formatting.BackColor = Color.LightGray
            End If

            'If EstatusID = 14 Or EstatusID = 15 Then
            '    e.Formatting.BackColor = Color.LightGray
            'End If

            'If Facturas <> String.Empty Then
            '    If TotalParesFacturados = ParesPartida - ParesCancelados Then
            '        e.Formatting.BackColor = Color.LightGray
            '    End If
            'End If

            'If OT <> String.Empty Then
            '    e.Formatting.BackColor = Color.LightGray
            'End If


            'If e.ColumnFieldName = "Facturas" Then
            '    If Facturas <> String.Empty Then
            '        e.Formatting.Font.Color = Color.Red                
            '    End If
            'End If

            'If e.ColumnFieldName = "OT" Then
            '    If OT <> String.Empty Then
            '        e.Formatting.Font.Color = Color.Red
            '    End If
            'End If

            'If ParesPartida > 0 Then
            '    If (ParesOT + ParesCancelados + ParesEntregados + ParesApartado) = ParesPartida Then
            '        e.Formatting.BackColor = Color.LightGray
            '    End If
            'End If

            'If Apartado <> String.Empty Then
            '    If ParesSalidaApartado <> TotalParesApartado Or ParesApartado <> 0 Then
            '        e.Formatting.BackColor = Color.LightGray
            '    Else
            '        If NumeroLotes > 0 Then
            '            e.Formatting.BackColor = Color.LightGray
            '        End If

            '        If FechaPrograma <> FechaNula Then
            '            If NumeroLotes > 0 Then
            '                e.Formatting.BackColor = Color.LightGray
            '            Else
            '                If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
            '                    e.Formatting.BackColor = Color.LightGray
            '                End If
            '            End If
            '        End If
            '    End If
            'End If


            'If e.ColumnFieldName = "Apartados" Then
            '    If Apartado <> String.Empty Then
            '        e.Formatting.Font.Color = Color.Red
            '    End If
            'End If


            'If e.ColumnFieldName = "Programa" Then
            '    If NumeroLotes > 0 Then
            '        e.Formatting.Font.Color = Color.Red
            '    End If

            '    If FechaPrograma <> FechaNula Then
            '        If NumeroLotes > 0 Then
            '            e.Formatting.Font.Color = Color.Red
            '        Else
            '            If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
            '                e.Formatting.Font.Color = Color.Red
            '            End If
            '        End If
            '    End If
            'End If

            'If e.ColumnFieldName = "NumeroLotes" Then
            '    If NumeroLotes > 0 Then
            '        e.Formatting.Font.Color = Color.Red
            '    End If
            'End If
          


        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

        e.Handled = True
    End Sub


    Private Sub btnPedidoCompleto_Click(sender As Object, e As EventArgs) Handles btnPedidoCompleto.Click
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim confirmar As New Tools.ConfirmarForm
        Dim PartidasSeleccionadasID As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = ViewPartidas.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "Seleccionar")) = True Then
                    FilasSeleccionadas += 1
                    If PartidasSeleccionadasID = String.Empty Then
                        PartidasSeleccionadasID = ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "Partida").ToString()
                    Else
                        PartidasSeleccionadasID &= "," & ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "Partida").ToString()
                    End If

                End If
            Next

            If FilasSeleccionadas > 0 Then
                Dim CancelarPartidas As New MotivosCancelacionForm
                CancelarPartidas.PedidoSAYID = PedidoSAYID
                CancelarPartidas.Partidas = PartidasSeleccionadasID
                CancelarPartidas.CancelarPedidoCompleto = False
                CancelarPartidas.CancelacionPedidosForm = CancelacionPedidosForm
                If CancelarPartidas.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    CanceloPartidas = True
                End If
                CargarPantalla()
            Else
                show_message("Advertencia", "No se ha seleccionado una partida.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error la mostrar la información. Vuelva a intentar.")
        End Try

    End Sub

    Private Sub grdGeneralSinFeEspecial_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles ViewPartidas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

   
    Private Sub ViewPartidas_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles ViewPartidas.CustomRowCellEdit
        Dim View2 As GridView = sender        
        If (e.RowHandle >= 0) Then
            If e.Column.FieldName = "Seleccionar" Then
                If NeedToHideDiscontinuedCheckbox(View2, e.RowHandle) = False Then
                    e.RepositoryItem = emptyEditor
                End If

            End If
        End If
        

    End Sub

    Private Function NeedToHideDiscontinuedCheckbox(ByVal view As GridView, ByVal row As Int32) As Boolean
        Dim MostrarCheckBox As Boolean = True

        Try

            Dim Facturas As String = String.Empty
            Dim OT As String = String.Empty
            Dim Apartado As String = String.Empty
            Dim TotalParesFacturados As Integer = 0
            Dim ParesCancelados As Integer = 0
            Dim ParesPartida As Integer = 0
            Dim ParesEntregados As Integer = 0
            Dim FechaPrograma As Date
            Dim NumeroLotes As Integer = 0
            Dim FechaNula As Date = Nothing
            Dim ParesOT As Integer = 0
            Dim ParesApartado As Integer = 0
            Dim Partida As Integer = 0
            Dim ParesProceso As Integer = 0
            Dim ParesSalidaApartado As Integer = 0
            Dim TotalParesApartado As Integer = 0
            Dim ParesLotesA As Integer = 0
            Dim ParesSinProyectar As Integer = 0
            Dim ParesOTDesasignacion As Integer = 0



            Dim EstatusPartida As String = view.GetRowCellDisplayText(row, view.Columns("EstatusPartida"))

            If IsDBNull(view.GetRowCellValue(row, view.Columns("POTDesasignacion"))) = False And IsNothing(view.GetRowCellValue(row, "POTDesasignacion")) = False Then
                ParesOTDesasignacion = view.GetRowCellValue(row, view.Columns("POTDesasignacion"))
            Else
                ParesOTDesasignacion = 0
            End If

            If IsDBNull(view.GetRowCellValue(row, view.Columns("ParesLotesA"))) = False And IsNothing(view.GetRowCellValue(row, "ParesLotesA")) = False Then
                ParesLotesA = view.GetRowCellValue(row, view.Columns("ParesLotesA"))
            Else
                ParesLotesA = 0
            End If

            If IsDBNull(view.GetRowCellValue(row, view.Columns("ParesSinProyectar"))) = False And IsNothing(view.GetRowCellValue(row, "ParesSinProyectar")) = False Then
                ParesSinProyectar = view.GetRowCellValue(row, view.Columns("ParesSinProyectar"))
            Else
                ParesSinProyectar = 0
            End If

            If IsDBNull(view.GetRowCellValue(row, view.Columns("Partida"))) = False And IsNothing(view.GetRowCellValue(row, "Partida")) = False Then
                Partida = view.GetRowCellValue(row, view.Columns("Partida"))
            Else
                Partida = 0
            End If

            If IsDBNull(view.GetRowCellValue(row, view.Columns("ParesOT"))) = False And IsNothing(view.GetRowCellValue(row, "ParesOT")) = False Then
                ParesOT = view.GetRowCellValue(row, view.Columns("ParesOT"))
            Else
                ParesOT = 0
            End If

            If IsDBNull(view.GetRowCellValue(row, view.Columns("Programa"))) = False And IsNothing(view.GetRowCellValue(row, "Programa")) = False Then
                FechaPrograma = view.GetRowCellValue(row, view.Columns("Programa"))
            Else
                FechaPrograma = Nothing
            End If

            If IsDBNull(view.GetRowCellValue(row, view.Columns("NumeroLotes"))) = False And IsNothing(view.GetRowCellValue(row, "NumeroLotes")) = False Then
                NumeroLotes = view.GetRowCellValue(row, view.Columns("NumeroLotes"))
            Else
                NumeroLotes = 0
            End If

            If IsDBNull(view.GetRowCellValue(row, "Apartado")) = False And IsNothing(view.GetRowCellValue(row, "Apartado")) = False Then
                ParesApartado = view.GetRowCellValue(row, "Apartado").ToString()
            Else
                ParesApartado = 0
            End If

            If IsDBNull(view.GetRowCellValue(row, "Apartados")) = False And IsNothing(view.GetRowCellValue(row, "Apartados")) = False Then
                Apartado = view.GetRowCellValue(row, "Apartados").ToString()
            End If

            If IsDBNull(view.GetRowCellValue(row, view.Columns("TotalParesFacturados"))) = False And IsNothing(view.GetRowCellValue(row, "TotalParesFacturados")) = False Then
                TotalParesFacturados = view.GetRowCellValue(row, view.Columns("TotalParesFacturados"))
            Else
                TotalParesFacturados = 0
            End If

            If IsDBNull(view.GetRowCellValue(row, view.Columns("TotalPares"))) = False And IsNothing(view.GetRowCellValue(row, "TotalPares")) = False Then
                ParesPartida = view.GetRowCellValue(row, view.Columns("TotalPares"))
            Else
                ParesPartida = 0
            End If

            If IsDBNull(view.GetRowCellValue(row, view.Columns("ParesCancelados"))) = False And IsNothing(view.GetRowCellValue(row, "ParesCancelados")) = False Then
                ParesCancelados = view.GetRowCellValue(row, view.Columns("ParesCancelados"))
            Else
                ParesCancelados = 0
            End If

            If IsDBNull(view.GetRowCellValue(row, view.Columns("Entregado"))) = False And IsNothing(view.GetRowCellValue(row, "Entregado")) = False Then
                ParesEntregados = view.GetRowCellValue(row, view.Columns("Entregado"))
            Else
                ParesEntregados = 0
            End If

            If IsDBNull(view.GetRowCellValue(row, view.Columns("Facturas"))) = False And IsNothing(view.GetRowCellValue(row, "Facturas")) = False Then
                Facturas = view.GetRowCellValue(row, view.Columns("Facturas"))
            Else
                Facturas = String.Empty
            End If

            If IsDBNull(view.GetRowCellValue(row, view.Columns("OT"))) = False And IsNothing(view.GetRowCellValue(row, "OT")) = False Then
                OT = view.GetRowCellValue(row, view.Columns("OT"))
            Else
                OT = String.Empty
            End If


            If IsDBNull(view.GetRowCellValue(row, view.Columns("ParesProceso"))) = False And IsNothing(view.GetRowCellValue(row, "ParesProceso")) = False Then
                ParesProceso = view.GetRowCellValue(row, view.Columns("ParesProceso"))
            Else
                ParesProceso = 0
            End If


            If IsDBNull(view.GetRowCellValue(row, "ParesSalidaApartado")) = False And IsNothing(view.GetRowCellValue(row, "ParesSalidaApartado")) = False Then
                ParesSalidaApartado = view.GetRowCellValue(row, "ParesSalidaApartado").ToString()
            Else
                ParesSalidaApartado = 0
            End If

            If IsDBNull(view.GetRowCellValue(row, "TotalParesApartado")) = False And IsNothing(view.GetRowCellValue(row, "TotalParesApartado")) = False Then
                TotalParesApartado = view.GetRowCellValue(row, "TotalParesApartado").ToString()
            Else
                TotalParesApartado = 0
            End If


            MostrarCheckBox = OcultarCheckBox(EstatusPartida, OT, Facturas, Apartado, TotalParesFacturados, ParesPartida, ParesCancelados, ParesEntregados, ParesOT, FechaPrograma, NumeroLotes, ParesApartado, ParesProceso, ParesSalidaApartado, TotalParesApartado, ParesLotesA, ParesSinProyectar, ParesOTDesasignacion)

        Catch ex As Exception

            show_message("Error", ex.Message.ToString())
            MostrarCheckBox = False
        End Try


        Return MostrarCheckBox

    End Function

  
    Private Sub chkboxSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles chkboxSeleccionar.CheckedChanged
        Dim NumeroFilas As Integer = 0
        Dim Facturas As String = String.Empty
        Dim OT As String = String.Empty
        Dim Apartado As String = String.Empty
        Dim TotalParesFacturados As Integer = 0
        Dim ParesCancelados As Integer = 0
        Dim ParesPartida As Integer = 0
        Dim ParesEntregados As Integer = 0
        Dim FechaPrograma As Date
        Dim NumeroLotes As Integer = 0
        Dim FechaNula As Date = Nothing
        Dim ParesOT As Integer = 0
        Dim ParesApartado As Integer = 0
        Dim Partida As Integer = 0
        Dim ParesProceso As Integer = 0
        Dim ParesSalidaApartado As Integer = 0
        Dim TotalParesApartado As Integer = 0
        Dim ParesLotesA As Integer = 0
        Dim ParesSinProyectar As Integer = 0
        Dim ParesOTDesasignacion As Integer = 0
        Dim MostrarcheckBox As Boolean = True

        NumeroFilas = ViewPartidas.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1

            Dim EstatusPartida As String = ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "EstatusPartida")

            If IsDBNull(ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "POTDesasignacion")) = False Then
                ParesOTDesasignacion = ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "POTDesasignacion")
            Else
                ParesOTDesasignacion = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "ParesLotesA")) = False Then
                ParesLotesA = ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "ParesLotesA")
            Else
                ParesLotesA = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "ParesSinProyectar")) = False Then
                ParesSinProyectar = ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "ParesSinProyectar")
            Else
                ParesSinProyectar = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "Partida")) = False Then
                Partida = ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "Partida")
            Else
                Partida = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "ParesOT")) = False Then
                ParesOT = ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "ParesOT")
            Else
                ParesOT = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "Programa")) = False Then
                FechaPrograma = ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "Programa")
            Else
                FechaPrograma = Nothing
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "NumeroLotes")) = False Then
                NumeroLotes = ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "NumeroLotes")
            Else
                NumeroLotes = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "Apartado")) = False Then
                ParesApartado = ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "Apartado")
            Else
                ParesApartado = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "Apartados")) = False Then
                Apartado = ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "Apartados")
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "TotalParesFacturados")) = False Then
                TotalParesFacturados = ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "TotalParesFacturados")
            Else
                TotalParesFacturados = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "TotalPares")) = False Then
                ParesPartida = ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "TotalPares")
            Else
                ParesPartida = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "ParesCancelados")) = False Then
                ParesCancelados = ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "ParesCancelados")
            Else
                ParesCancelados = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "Entregado")) = False Then
                ParesEntregados = ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "Entregado")
            Else
                ParesEntregados = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "Facturas")) = False Then
                Facturas = ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "Facturas")
            Else
                Facturas = String.Empty
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "OT")) = False Then
                OT = ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "OT")
            Else
                OT = String.Empty
            End If


            If IsDBNull(ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "ParesProceso")) = False Then
                ParesProceso = ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "ParesProceso")
            Else
                ParesProceso = 0
            End If


            If IsDBNull(ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "ParesSalidaApartado")) = False Then
                ParesSalidaApartado = ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "ParesSalidaApartado")
            Else
                ParesSalidaApartado = 0
            End If

            If IsDBNull(ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "TotalParesApartado")) = False Then
                TotalParesApartado = ViewPartidas.GetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "TotalParesApartado")
            Else
                TotalParesApartado = 0
            End If


            MostrarCheckBox = OcultarCheckBox(EstatusPartida, OT, Facturas, Apartado, TotalParesFacturados, ParesPartida, ParesCancelados, ParesEntregados, ParesOT, FechaPrograma, NumeroLotes, ParesApartado, ParesProceso, ParesSalidaApartado, TotalParesApartado, ParesLotesA, ParesSinProyectar, ParesOTDesasignacion)

            If MostrarcheckBox = True Then
                ViewPartidas.SetRowCellValue(ViewPartidas.GetVisibleRowHandle(index), "Seleccionar", chkboxSeleccionar.Checked)
            End If


        Next
    End Sub

End Class
