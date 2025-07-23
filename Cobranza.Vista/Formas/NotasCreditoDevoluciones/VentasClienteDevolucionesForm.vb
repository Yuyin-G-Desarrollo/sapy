Imports System.ComponentModel
Imports System.Windows.Forms
Imports Cobranza.Negocios
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Entidades
Imports Tools

Public Class VentasClienteDevolucionesForm
    Public rfcClienid As Integer
    Public empresaId As Integer
    Public tipoNC As String
    Dim registroSeleccionado As Boolean = False
    Public concepto As String
    Public dtRegistros As New DataTable
    Public metodoPago As String
    Public formaPago As String
    Public rfcClienteEnviar As String
    Public rfcClienteIdEnviar As Integer
    Public rfcCliente As String
    Dim listaRFRCClientes As New List(Of String)
    Public facturasSeleccionadas As String
    Private Sub VentasClienteDevolucionesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarVentasCliente()
    End Sub
    Private Sub cargarVentasCliente()
        Dim cargarVentasClientes As New NotaCreditoDevolucionesBU
        Dim NCVentasCliente As New NotasCreditoDevoluciones
        Dim dtVentasCliente As New DataTable
        NCVentasCliente.NotaCreditoRFCClienteId = rfcClienid
        NCVentasCliente.NotaCreditoRazSocialId = empresaId
        NCVentasCliente.NotaCreditoTipo = tipoNC
        NCVentasCliente.NotaCreditoConcepto = concepto
        dtVentasCliente = cargarVentasClientes.obtenerVentasCliente(NCVentasCliente, facturasSeleccionadas) ', facturasSeleccionadas)
        If dtVentasCliente.Rows.Count > 0 Then
            grdVentasCliente.DataSource = dtVentasCliente
            If tipoNC = "F" Then
                metodoPago = dtVentasCliente.Rows(0).Item(10)
                formaPago = dtVentasCliente.Rows(0).Item(11)
            End If
            diseñoGridVentasCliente(wvVentasCliente)
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay información para mostrar.")
            Close()
        End If
    End Sub
    Private Sub diseñoGridVentasCliente(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Tools.DiseñoGrid.AlternarColorEnFilas(wvVentasCliente) '' pone color a las filas del gridview
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvVentasCliente.Columns
            If col.FieldName = "RAZÓN SOCIAL CLIENTE" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 105
            End If
            If col.FieldName = "FOLIO" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 35
            End If
            If col.FieldName = "FECHA REGISTRO" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 52
            End If
            If col.FieldName = "FACTURA" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 40
            End If
            If col.FieldName = "FECHA VENTA" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 50
            End If
            If col.FieldName = "FECHA VENCE" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 50
            End If
            If col.FieldName = "VENCIDO" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 40
            End If
            If col.FieldName = "SALDO" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 40
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "N2"
            End If
            If col.FieldName = "MARCAR" Then
                col.OptionsColumn.AllowEdit = True
                col.Width = 40
            End If
            If col.FieldName = "ANIO" Then
                col.OptionsColumn.AllowEdit = True
                col.Width = 40
                col.Visible = False
            End If
            If col.FieldName = "RFC_CLIENTEID" Then
                col.OptionsColumn.AllowEdit = True
                col.Width = 40
                col.Visible = False
            End If
            If col.FieldName = "Metodo Pago" Then
                col.Visible = False
            End If
            If col.FieldName = "Forma Pago" Then
                col.Visible = False
            End If
            If col.FieldName = "idrfccliente" Then
                col.Visible = False
            End If
            If col.FieldName = "RFC" Then
                col.Visible = False
            End If
        Next

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvVentasCliente.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvVentasCliente.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName.Contains("SALDO") Then
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "SALDO")) = True And col.FieldName = "SALDO" Then
                    col.Summary.Clear()
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
            End If
        Next
        Grid.IndicatorWidth = 30
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If validarRegistrosSeleccionadosCerrar() Then
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Todos los cambios no guardados se perderan ¿desea continuar?."
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Close()
            End If
        Else
            Close()
        End If
    End Sub
    Private Function validarRegistrosSeleccionadosCerrar()
        Dim numeroFilas As Integer = wvVentasCliente.DataRowCount
        For conta As Integer = 0 To numeroFilas
            If CBool(wvVentasCliente.GetRowCellValue(wvVentasCliente.GetVisibleRowHandle(conta), "MARCAR")) = True Then
                registroSeleccionado = True
                Exit For
            End If
        Next
        Return registroSeleccionado
    End Function
    Private Sub wvVentasCliente_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles wvVentasCliente.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        RegistrosSeleccionadosVentasCliente()
        Close()
    End Sub
    Private Sub RegistrosSeleccionadosVentasCliente()
        Dim factura As String = ""
        Dim saldo As Decimal
        Dim anio As Integer
        Dim rfcClienteId As Integer
        Dim remisionId As Integer
        Dim formaPago As String = ""
        Dim metodoPago As String = ""
        Dim fila As New DataColumn
        Dim row As DataRow
        Dim numeroFilas As Integer = wvVentasCliente.DataRowCount
        Dim objInsertaWork As New NotaCreditoDevolucionesBU
        Dim NotaCredito As New NotasCreditoDevoluciones

        fila = New DataColumn("Concepto", GetType(String))
        dtRegistros.Columns.Add(fila)
        fila = New DataColumn("anio", GetType(String))
        dtRegistros.Columns.Add(fila)
        fila = New DataColumn("Factura", GetType(String))
        dtRegistros.Columns.Add(fila)
        fila = New DataColumn("Agregar Devolucion", GetType(String))
        dtRegistros.Columns.Add(fila)
        fila = New DataColumn("Cantidad", GetType(Integer))
        dtRegistros.Columns.Add(fila)
        fila = New DataColumn("% Descuento", GetType(Decimal))
        dtRegistros.Columns.Add(fila)
        fila = New DataColumn("Precio", GetType(Decimal))
        dtRegistros.Columns.Add(fila)
        fila = New DataColumn("Importe", GetType(Decimal))
        dtRegistros.Columns.Add(fila)
        fila = New DataColumn("Folio Devolucion", GetType(String))
        dtRegistros.Columns.Add(fila)
        fila = New DataColumn("Observacion", GetType(String))
        dtRegistros.Columns.Add(fila)
        fila = New DataColumn("Saldo Factura", GetType(Decimal))
        dtRegistros.Columns.Add(fila)
        row = dtRegistros.NewRow()
        fila = New DataColumn("Rfc ClienteId", GetType(String))
        dtRegistros.Columns.Add(fila)
        row = dtRegistros.NewRow()
        fila = New DataColumn("Folio", GetType(Integer))
        dtRegistros.Columns.Add(fila)
        row = dtRegistros.NewRow()
        fila = New DataColumn("Metodo Pago", GetType(String))
        dtRegistros.Columns.Add(fila)
        row = dtRegistros.NewRow()
        fila = New DataColumn("Forma Pago", GetType(String))
        dtRegistros.Columns.Add(fila)
        row = dtRegistros.NewRow()
        fila = New DataColumn("Total NC", GetType(Decimal))
        dtRegistros.Columns.Add(fila)
        row = dtRegistros.NewRow()
        fila = New DataColumn("DetalleId", GetType(String))
        dtRegistros.Columns.Add(fila)
        row = dtRegistros.NewRow()
        fila = New DataColumn("Iva", GetType(Decimal))
        dtRegistros.Columns.Add(fila)
        row = dtRegistros.NewRow()

        For conta As Integer = 0 To numeroFilas
            If CBool(wvVentasCliente.GetRowCellValue(wvVentasCliente.GetVisibleRowHandle(conta), "MARCAR")) = True Then
                If tipoNC = "F" Then
                    factura = wvVentasCliente.GetRowCellValue(conta, "FACTURA")
                Else
                    factura = ""
                End If
                saldo = wvVentasCliente.GetRowCellValue(conta, "SALDO")
                anio = wvVentasCliente.GetRowCellValue(conta, "ANIO")
                rfcClienteId = wvVentasCliente.GetRowCellValue(conta, "idrfccliente")
                remisionId = wvVentasCliente.GetRowCellValue(conta, "FOLIO") ''remisionId
                metodoPago = wvVentasCliente.GetRowCellValue(conta, "Metodo Pago")
                formaPago = wvVentasCliente.GetRowCellValue(conta, "Forma Pago")

                row("concepto") = concepto
                row("anio") = anio
                row("factura") = factura
                row("agregar devolucion") = "AGREGAR" & " " & concepto
                row("% Descuento") = 0.00
                row("saldo factura") = saldo
                row("Rfc ClienteId") = rfcClienteId
                row("Folio") = remisionId
                row("Metodo Pago") = metodoPago
                row("Forma Pago") = formaPago
                dtRegistros.Rows.Add(row.ItemArray)

                NotaCredito.NotaCreditoBusqueda = "Documento"
                NotaCredito.NotaCreditoFolio = remisionId
                NotaCredito.NotaCredtioDocumento = factura
                NotaCredito.NotaCreditoId = 0
                NotaCredito.NotaCreditoTipo = tipoNC
            End If
        Next
        For x As Integer = 0 To numeroFilas
            If CBool(wvVentasCliente.GetRowCellValue(wvVentasCliente.GetVisibleRowHandle(x), "MARCAR")) = True Then
                rfcClienteEnviar = wvVentasCliente.GetRowCellValue(x, "RAZÓN SOCIAL CLIENTE")
                rfcClienteIdEnviar = wvVentasCliente.GetRowCellValue(x, "idrfccliente")
                rfcCliente = wvVentasCliente.GetRowCellValue(x, "RFC")
            End If
        Next

    End Sub
    Private Sub wvVentasCliente_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles wvVentasCliente.CellValueChanging
        If wvVentasCliente.FocusedColumn.FieldName = "MARCAR" Then
            Dim objObetenerSession As New NotaCreditoDevolucionesBU
            Dim dtSessionActiva As New DataTable
            Dim NotaCredito As New NotasCreditoDevoluciones
            Dim index As Integer = (e.RowHandle)
            Dim RFCCliente As String = ""
            Dim rfccorrecto As Boolean = True
            RFCCliente = (wvVentasCliente.GetRowCellValue(index, "RAZÓN SOCIAL CLIENTE"))
            Dim seleccion = wvVentasCliente.GetFocusedValue '' VALOR DE LA CASILLA "MARCAR" (FALSE O TRUE)
            If seleccion = True Then
                Dim poscisionindice = listaRFRCClientes.IndexOf(RFCCliente) '' saber en que indice se encuentra el rfc a borrar de la lista
                listaRFRCClientes.RemoveAt(poscisionindice) '' elimina el valor segun el indice encontrado
            Else
                listaRFRCClientes.Add(RFCCliente)
            End If
            If listaRFRCClientes.Count > 1 Then
                For i As Integer = 0 To listaRFRCClientes.Count - 1
                    If RFCCliente <> listaRFRCClientes.Item(i) Then
                        rfccorrecto = False
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se pueden seleccionar razónes sociales diferentes.")
                        Dim poscisionindice = listaRFRCClientes.IndexOf(RFCCliente) '' saber en que indice se encuentra el rfc a borrar de la lista
                        listaRFRCClientes.RemoveAt(poscisionindice) '' elimina el valor segun el indice encintrado
                        Dim view As ColumnView = CType(grdVentasCliente.FocusedView, ColumnView)
                        If view.IsEditing Then view.HideEditor()
                        view.CancelUpdateCurrentRow()
                        Exit For
                    End If
                Next
            End If

            If rfccorrecto = True Then
                NotaCredito.NotaCreditoBusqueda = "Documento"
                NotaCredito.NotaCreditoFolio = (wvVentasCliente.GetRowCellValue(index, "FOLIO"))
                If tipoNC = "F" Then
                    NotaCredito.NotaCredtioDocumento = (wvVentasCliente.GetRowCellValue(index, "FACTURA"))
                Else
                    NotaCredito.NotaCredtioDocumento = ""
                End If
                NotaCredito.NotaCreditoId = 0
                NotaCredito.NotaCreditoTipo = tipoNC
                dtSessionActiva = objObetenerSession.obtenerSessionActiva(NotaCredito)
                If dtSessionActiva.Rows.Count > 0 Then
                    Dim sessionOcupada As String = ""
                    sessionOcupada = dtSessionActiva.Rows(0).Item(2)
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, sessionOcupada)
                    '' no muestra el check si es true la condicion es TRUE
                    Dim view As ColumnView = CType(grdVentasCliente.FocusedView, ColumnView)
                    If view.IsEditing Then view.HideEditor()
                    view.CancelUpdateCurrentRow()
                End If
            End If
        End If
    End Sub

    Private Sub VentasClienteDevolucionesForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub
End Class