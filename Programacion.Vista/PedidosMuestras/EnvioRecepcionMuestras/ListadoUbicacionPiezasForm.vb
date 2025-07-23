Imports Tools
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
'Imports XtraReportSerialization
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.ReportGeneration
Imports System.IO
Imports System.Xml

Public Class ListadoUbicacionPiezasForm

    Public DtListadoUbicacionPiezas As DataTable
    Public EntidadFiltros As New Entidades.FiltrosEnvioRecepcionMuestras

    Private Sub ListadoUbicacionPiezasForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Cursor = Cursors.WaitCursor
            Me.WindowState = FormWindowState.Maximized
            grdUbicacionPiezas.DataSource = Nothing
            grdUbicacionPiezas.DataSource = DtListadoUbicacionPiezas
            DiseñoGrid()
            'CargarGrid()
            lblNumeroPiezas.Text = CDbl(viewUbicacionPiezas.RowCount.ToString()).ToString("N0")
            lblFechaUltimaActualizacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DiseñoGrid()
        viewUbicacionPiezas.OptionsView.ColumnAutoWidth = False
        viewUbicacionPiezas.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

        If IsNothing(viewUbicacionPiezas.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            viewUbicacionPiezas.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler viewUbicacionPiezas.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
            viewUbicacionPiezas.Columns.Item("#").VisibleIndex = 0
        End If

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In viewUbicacionPiezas.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        viewUbicacionPiezas.Columns.ColumnByFieldName("TipoUbicacion").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("D").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("A").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Estiba").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Operador").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("[FUbicación(Hr)]").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Pieza").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("FolioEnvio").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Entrega").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEnvio(Hr)").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Envió").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("FRecepción(Hr)").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Recibió").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEntregaCliente").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEntregaNave").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("MarcaSAY").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("ColeccionSAY").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("ModeloSAY").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("ModeloSICY").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Piel").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Color").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Corrida").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Talla").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("UDM").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("PedidoOrigen").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("ClienteOrigen").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("OrdenProd").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Año").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("PedidoActual").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("ClienteActual").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("SATC").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("EATN").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("FUbicación").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEnvio").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("FRecepcion").Visible = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Status").Visible = True

        '        viewUbicacionPiezas.Columns.ColumnByFieldName("Cantidad").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        viewUbicacionPiezas.Columns.ColumnByFieldName("TipoUbicacion").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("D").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("A").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("Estiba").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("Operador").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'viewUbicacionPiezas.Columns.ColumnByFieldName("FUbicación(Hr)").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("Pieza").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("Nave").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("FolioEnvio").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("Entrega").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'viewUbicacionPiezas.Columns.ColumnByFieldName("FEnvio(Hr)").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("Envió").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'viewUbicacionPiezas.Columns.ColumnByFieldName("FRecepción(Hr)").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("Recibió").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'viewUbicacionPiezas.Columns.ColumnByFieldName("FEntregaCliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'viewUbicacionPiezas.Columns.ColumnByFieldName("FEntregaNave").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("MarcaSAY").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("ColeccionSAY").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("ModeloSAY").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("ModeloSICY").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("Piel").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("Color").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("Corrida").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("Talla").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("UDM").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("PedidoOrigen").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("ClienteOrigen").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("OrdenProd").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("Año").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("PedidoActual").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("ClienteActual").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("SATC").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("EATN").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'viewUbicacionPiezas.Columns.ColumnByFieldName("FUbicación").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'viewUbicacionPiezas.Columns.ColumnByFieldName("FEnvio").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'viewUbicacionPiezas.Columns.ColumnByFieldName("FRecepcion").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewUbicacionPiezas.Columns.ColumnByFieldName("Status").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains


        viewUbicacionPiezas.Columns.ColumnByFieldName("TipoUbicacion").Caption = "P/E"
        viewUbicacionPiezas.Columns.ColumnByFieldName("D").Caption = "D "
        viewUbicacionPiezas.Columns.ColumnByFieldName("A").Caption = "A"
        viewUbicacionPiezas.Columns.ColumnByFieldName("Estiba").Caption = "Estiba"
        viewUbicacionPiezas.Columns.ColumnByFieldName("Operador").Caption = "Operador"
        viewUbicacionPiezas.Columns.ColumnByFieldName("[FUbicación(Hr)]").Caption = "F Ubicación (Hr)"
        viewUbicacionPiezas.Columns.ColumnByFieldName("Pieza").Caption = "Pieza"
        viewUbicacionPiezas.Columns.ColumnByFieldName("FolioEnvio").Caption = "Folio " & vbCrLf & " Envío"
        viewUbicacionPiezas.Columns.ColumnByFieldName("Entrega").Caption = "Entrega"
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEnvio(Hr)").Caption = "F Envio (Hr)"
        viewUbicacionPiezas.Columns.ColumnByFieldName("Envió").Caption = "Envió"
        viewUbicacionPiezas.Columns.ColumnByFieldName("FRecepción(Hr)").Caption = "F Recepción (Hr)"
        viewUbicacionPiezas.Columns.ColumnByFieldName("Recibió").Caption = "Recibió"
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEntregaCliente").Caption = "F Entrega " & vbCrLf & " Cliente"
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEntregaNave").Caption = "F Entrega " & vbCrLf & " Nave"
        viewUbicacionPiezas.Columns.ColumnByFieldName("MarcaSAY").Caption = "Marca"
        viewUbicacionPiezas.Columns.ColumnByFieldName("ColeccionSAY").Caption = "Colección"
        viewUbicacionPiezas.Columns.ColumnByFieldName("ModeloSAY").Caption = "Modelo "
        viewUbicacionPiezas.Columns.ColumnByFieldName("ModeloSICY").Caption = "Modelo " & vbCrLf & " SICY"
        viewUbicacionPiezas.Columns.ColumnByFieldName("Piel").Caption = "Piel"
        viewUbicacionPiezas.Columns.ColumnByFieldName("Color").Caption = "Color"
        viewUbicacionPiezas.Columns.ColumnByFieldName("Corrida").Caption = "Corrida"
        viewUbicacionPiezas.Columns.ColumnByFieldName("Talla").Caption = "Talla"
        viewUbicacionPiezas.Columns.ColumnByFieldName("UDM").Caption = "UDM"
        viewUbicacionPiezas.Columns.ColumnByFieldName("PedidoOrigen").Caption = "Pedido " & vbCrLf & " Origen"
        viewUbicacionPiezas.Columns.ColumnByFieldName("ClienteOrigen").Caption = "Cliente  Origen"
        viewUbicacionPiezas.Columns.ColumnByFieldName("OrdenProd").Caption = "Orden " & vbCrLf & "Prod"
        viewUbicacionPiezas.Columns.ColumnByFieldName("Año").Caption = "Año"
        viewUbicacionPiezas.Columns.ColumnByFieldName("PedidoActual").Caption = "Pedido " & vbCrLf & " Actual"
        viewUbicacionPiezas.Columns.ColumnByFieldName("ClienteActual").Caption = "Cliente Actual"
        viewUbicacionPiezas.Columns.ColumnByFieldName("SATC").Caption = "SATC"
        viewUbicacionPiezas.Columns.ColumnByFieldName("EATN").Caption = "EATN"
        viewUbicacionPiezas.Columns.ColumnByFieldName("FUbicación").Caption = "F Ubicación"
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEnvio").Caption = "F Envío"
        viewUbicacionPiezas.Columns.ColumnByFieldName("FRecepcion").Caption = "F Recepción"
        viewUbicacionPiezas.Columns.ColumnByFieldName("Status").Caption = "Status"


        viewUbicacionPiezas.Columns.ColumnByFieldName("TipoUbicacion").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("D").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("A").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Estiba").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Operador").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("[FUbicación(Hr)]").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Pieza").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Nave").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("FolioEnvio").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Entrega").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("FRecepción(Hr)").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Recibió").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEnvio(Hr)").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Envió").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEntregaCliente").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEntregaNave").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("MarcaSAY").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("ColeccionSAY").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("ModeloSAY").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("ModeloSICY").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Piel").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Color").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Corrida").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Talla").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("UDM").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("PedidoOrigen").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("ClienteOrigen").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("OrdenProd").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Año").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("PedidoActual").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("ClienteActual").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("SATC").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("EATN").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("FUbicación").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEnvio").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("FRecepcion").OptionsColumn.AllowSize = True
        viewUbicacionPiezas.Columns.ColumnByFieldName("Status").OptionsColumn.AllowSize = True

        viewUbicacionPiezas.Columns.ColumnByFieldName("TipoUbicacion").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("D").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("A").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("Estiba").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("Operador").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("[FUbicación(Hr)]").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("Pieza").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("Nave").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("FolioEnvio").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("Entrega").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEnvio(Hr)").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("Envió").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("FRecepción(Hr)").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("Recibió").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEntregaCliente").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEntregaNave").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("MarcaSAY").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("ColeccionSAY").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("ModeloSAY").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("ModeloSICY").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("Piel").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("Color").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("Corrida").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("Talla").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("UDM").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("PedidoOrigen").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("ClienteOrigen").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("OrdenProd").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("Año").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("PedidoActual").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("ClienteActual").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("SATC").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("EATN").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("FUbicación").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEnvio").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("FRecepcion").OptionsColumn.AllowEdit = False
        viewUbicacionPiezas.Columns.ColumnByFieldName("Status").OptionsColumn.AllowEdit = False

        viewUbicacionPiezas.Columns.ColumnByFieldName("#").Width = 15
        viewUbicacionPiezas.Columns.ColumnByFieldName("TipoUbicacion").Width = 35
        viewUbicacionPiezas.Columns.ColumnByFieldName("D").Width = 30
        viewUbicacionPiezas.Columns.ColumnByFieldName("A").Width = 30
        viewUbicacionPiezas.Columns.ColumnByFieldName("Estiba").Width = 80
        viewUbicacionPiezas.Columns.ColumnByFieldName("Operador").Width = 200
        viewUbicacionPiezas.Columns.ColumnByFieldName("[FUbicación(Hr)]").Width = 120
        viewUbicacionPiezas.Columns.ColumnByFieldName("Pieza").Width = 70
        viewUbicacionPiezas.Columns.ColumnByFieldName("FolioEnvio").Width = 50
        viewUbicacionPiezas.Columns.ColumnByFieldName("Entrega").Width = 60
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEnvio(Hr)").Width = 120
        viewUbicacionPiezas.Columns.ColumnByFieldName("Envió").Width = 60
        viewUbicacionPiezas.Columns.ColumnByFieldName("FRecepción(Hr)").Width = 120
        viewUbicacionPiezas.Columns.ColumnByFieldName("Recibió").Width = 100
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEntregaCliente").Width = 80
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEntregaNave").Width = 80
        viewUbicacionPiezas.Columns.ColumnByFieldName("MarcaSAY").Width = 70
        viewUbicacionPiezas.Columns.ColumnByFieldName("ColeccionSAY").Width = 130
        viewUbicacionPiezas.Columns.ColumnByFieldName("ModeloSAY").Width = 60
        viewUbicacionPiezas.Columns.ColumnByFieldName("ModeloSICY").Width = 60
        viewUbicacionPiezas.Columns.ColumnByFieldName("Piel").Width = 80
        viewUbicacionPiezas.Columns.ColumnByFieldName("Color").Width = 60
        viewUbicacionPiezas.Columns.ColumnByFieldName("Corrida").Width = 60
        viewUbicacionPiezas.Columns.ColumnByFieldName("Talla").Width = 40
        viewUbicacionPiezas.Columns.ColumnByFieldName("UDM").Width = 40
        viewUbicacionPiezas.Columns.ColumnByFieldName("PedidoOrigen").Width = 60
        viewUbicacionPiezas.Columns.ColumnByFieldName("ClienteOrigen").Width = 180
        viewUbicacionPiezas.Columns.ColumnByFieldName("OrdenProd").Width = 70
        viewUbicacionPiezas.Columns.ColumnByFieldName("Año").Width = 50
        viewUbicacionPiezas.Columns.ColumnByFieldName("PedidoActual").Width = 60
        viewUbicacionPiezas.Columns.ColumnByFieldName("ClienteActual").Width = 180
        viewUbicacionPiezas.Columns.ColumnByFieldName("SATC").Width = 45
        viewUbicacionPiezas.Columns.ColumnByFieldName("EATN").Width = 45
        viewUbicacionPiezas.Columns.ColumnByFieldName("FUbicación").Width = 120
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEnvio").Width = 80
        viewUbicacionPiezas.Columns.ColumnByFieldName("FRecepcion").Width = 80
        viewUbicacionPiezas.Columns.ColumnByFieldName("Status").Width = 160

        viewUbicacionPiezas.Columns.ColumnByFieldName("[FUbicación(Hr)]").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        viewUbicacionPiezas.Columns.ColumnByFieldName("FRecepción(Hr)").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        viewUbicacionPiezas.Columns.ColumnByFieldName("FEnvio(Hr)").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

        'Ajustar el ancho de la columna al contenido
        viewUbicacionPiezas.Columns.ColumnByFieldName("Operador").BestFit()
        viewUbicacionPiezas.Columns.ColumnByFieldName("Nave").BestFit()
        viewUbicacionPiezas.Columns.ColumnByFieldName("ClienteOrigen").BestFit()
        viewUbicacionPiezas.Columns.ColumnByFieldName("ClienteActual").BestFit()
        viewUbicacionPiezas.Columns.ColumnByFieldName("Status").BestFit()

        viewUbicacionPiezas.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        If IsNothing(viewUbicacionPiezas.Columns("Pieza").Summary.FirstOrDefault(Function(x) x.FieldName = "Pieza")) = True Then
            viewUbicacionPiezas.Columns("Pieza").Summary.Add(DevExpress.Data.SummaryItemType.Count, "Pieza", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pieza"
            item.SummaryType = DevExpress.Data.SummaryItemType.Count
            item.DisplayFormat = "{0}"
            viewUbicacionPiezas.GroupSummary.Add(item)
        End If

    End Sub

    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = viewUbicacionPiezas.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub CargarGrid()
        Dim objBu As New Programacion.Negocios.EnvioRecepcionMuestrasBU
        grdUbicacionPiezas.DataSource = Nothing
        DtListadoUbicacionPiezas = objBu.ConsultarUbicacionPiezas(EntidadFiltros)
        grdUbicacionPiezas.DataSource = DtListadoUbicacionPiezas
        DiseñoGrid()

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Try
            Cursor = Cursors.WaitCursor
            CargarGrid()
            lblNumeroPiezas.Text = CDbl(viewUbicacionPiezas.RowCount.ToString()).ToString("N0")
            lblFechaUltimaActualizacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub viewUbicacionPiezas_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles viewUbicacionPiezas.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        Dim ValorCelda As String = String.Empty
        Dim FechaEntregaNave As Date
        Dim FechaEntregaCliente As Date
        Dim FechaRecepcionNave As Date
        'If (e.RowHandle = currentView.FocusedRowHandle) Then Return

        If e.RowHandle < 0 Then
            Return
        End If
        Try
            Cursor = Cursors.WaitCursor
            If e.Column.FieldName = "TipoUbicacion" Then
                ValorCelda = currentView.GetRowCellValue(e.RowHandle, "TipoUbicacion")
                If ValorCelda = "P" Then
                    e.Appearance.BackColor = lblColorPieza.BackColor
                ElseIf ValorCelda = "E" Then
                    e.Appearance.BackColor = lblColorError.BackColor
                End If
            End If

            If e.Column.FieldName = "D" Then
                ValorCelda = currentView.GetRowCellValue(e.RowHandle, "D")
                If ValorCelda = "1" Then
                    e.Appearance.BackColor = lblColorDisponible.BackColor
                End If
            End If

            If e.Column.FieldName = "A" Then
                ValorCelda = currentView.GetRowCellValue(e.RowHandle, "A")
                If ValorCelda = "1" Then
                    e.Appearance.BackColor = lblColorAsignada.BackColor
                End If
            End If

            If e.Column.FieldName = "FEntregaCliente" Then
                If IsDBNull(currentView.GetRowCellValue(e.RowHandle, "FEntregaCliente")) = False Then
                    FechaEntregaCliente = CDate(currentView.GetRowCellValue(e.RowHandle, "FEntregaCliente")).ToShortDateString
                    FechaEntregaNave = CDate(currentView.GetRowCellValue(e.RowHandle, "FEntregaNave")).ToShortDateString
                    If FechaEntregaNave > FechaEntregaCliente Then
                        e.Appearance.ForeColor = Color.Red
                    End If
                End If
            End If


            If e.Column.FieldName = "FEntregaNave" Then
                If IsDBNull(currentView.GetRowCellValue(e.RowHandle, "FRecepción(Hr)")) = False Then
                    FechaRecepcionNave = CDate(currentView.GetRowCellValue(e.RowHandle, "FRecepción(Hr)")).ToShortDateString()
                    FechaEntregaNave = CDate(currentView.GetRowCellValue(e.RowHandle, "FEntregaNave")).ToShortDateString
                    If FechaRecepcionNave > FechaEntregaNave Then
                        e.Appearance.ForeColor = Color.Red
                    End If
                End If

            End If

            If e.Column.FieldName = "SATC" Then
                ValorCelda = currentView.GetRowCellValue(e.RowHandle, "SATC")
                If ValorCelda = "SI" Then
                    e.Appearance.ForeColor = Color.Green
                ElseIf ValorCelda = "NO" Then
                    e.Appearance.ForeColor = Color.Red
                End If
            End If

            If e.Column.FieldName = "EATN" Then
                ValorCelda = currentView.GetRowCellValue(e.RowHandle, "EATN")
                If ValorCelda = "SI" Then
                    e.Appearance.ForeColor = Color.Green
                ElseIf ValorCelda = "NO" Then
                    e.Appearance.ForeColor = Color.Red
                End If
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

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

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then

                    If GridView1.GroupCount > 0 Then
                        grdUbicacionPiezas.ExportToXlsx(.SelectedPath + "\LocalizacionUbicacionesMuestras_" + fecha_hora + ".xlsx")
                    Else
                        Dim exportOptions = New XlsxExportOptionsEx()
                        AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                        grdUbicacionPiezas.ExportToXlsx(.SelectedPath + "\LocalizacionUbicacionesMuestras_" + fecha_hora + ".xlsx", exportOptions)

                    End If
                    show_message("Exito", "Los datos se exportaron correctamente: " & "LocalizacionUbicacionesMuestras_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\LocalizacionUbicacionesMuestras_" + fecha_hora + ".xlsx")
                End If
            End With
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        If e.RowHandle < 0 Then Return

        Dim TotalIncidencias As Integer = 0
        Dim index As Integer = 0
        Try
            Dim TipoUbicacion As String = viewUbicacionPiezas.GetRowCellValue(e.RowHandle, "TipoUbicacion")
            Dim D As String = viewUbicacionPiezas.GetRowCellValue(e.RowHandle, "D")
            Dim FechaEntregaCliente As String = (viewUbicacionPiezas.GetRowCellValue(e.RowHandle, "FEntregaCliente")).ToString
            Dim FechaEntregaNave As String = (viewUbicacionPiezas.GetRowCellValue(e.RowHandle, "FEntregaNave")).ToString

            Dim SATC As String = viewUbicacionPiezas.GetRowCellValue(e.RowHandle, "SATC")
            Dim EATN As String = viewUbicacionPiezas.GetRowCellValue(e.RowHandle, "EATN")
            Dim A As String = viewUbicacionPiezas.GetRowCellValue(e.RowHandle, "A")

            Dim FechaRecepcion As String = Nothing

            If IsDBNull(viewUbicacionPiezas.GetRowCellValue(e.RowHandle, "FRecepción(Hr)")) = False Then
                FechaRecepcion = CDate(viewUbicacionPiezas.GetRowCellValue(e.RowHandle, "FRecepción(Hr)"))
            End If

            If e.ColumnFieldName = "TipoUbicacion" Then
                If TipoUbicacion = "P" Then
                    e.Formatting.BackColor = lblColorPieza.BackColor
                ElseIf TipoUbicacion = "E" Then
                    e.Formatting.BackColor = lblColorError.BackColor
                End If
            End If

            If e.ColumnFieldName = "D" Then
                If D = "1" Then
                    e.Formatting.BackColor = lblColorDisponible.BackColor
                End If
            End If

            If e.ColumnFieldName = "A" Then
                If A = "1" Then
                    e.Formatting.BackColor = lblColorAsignada.BackColor
                End If
            End If


            If e.ColumnFieldName = "FEntregaCliente" Then
                If IsNothing(FechaEntregaCliente) = False Then
                    If FechaEntregaNave > FechaEntregaCliente Then
                        e.Formatting.Font.Color = Color.Red
                    End If
                End If
            End If

            If e.ColumnFieldName = "FEntregaNave" Then
                If IsNothing(FechaRecepcion) = False Then
                    If FechaRecepcion > FechaEntregaNave Then
                        e.Formatting.Font.Color = Color.Red
                    End If
                End If

            End If

            If e.ColumnFieldName = "SATC" Then
                If SATC = "SI" Then
                    e.Formatting.Font.Color = Color.Green
                ElseIf SATC = "NO" Then
                    e.Formatting.Font.Color = Color.Red
                End If
            End If

            If e.ColumnFieldName = "EATN" Then
                If EATN = "SI" Then
                    e.Formatting.Font.Color = Color.Green
                ElseIf EATN = "NO" Then
                    e.Formatting.Font.Color = Color.Red
                End If
            End If


        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

        e.Handled = True
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class

