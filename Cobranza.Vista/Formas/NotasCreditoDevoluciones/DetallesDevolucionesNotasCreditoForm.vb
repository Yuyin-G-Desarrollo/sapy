Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Cobranza.Negocios
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Entidades
Imports Tools

Public Class DetallesDevolucionesNotasCreditoForm
    Public remisionId As Integer
    Public rfcClienteId As Integer
    Public anio As Integer
    Public idempresa As Integer
    Public totalSaldoFactura As Decimal
    Public idCliente As Integer
    Public tipoNC As String
    Dim registroSeleccionado As Boolean = False
    Dim restaPares As Integer
    Dim dtTotalNC As New DataTable
    Public dtRegistrosSeleccionados As New DataTable
    Dim cantidadAntes As String
    Dim vuelta As Integer
    Dim sumaDevolucion As Decimal = 0.00
    Dim TotalNc As Decimal
    Public totalSumaCantidad As Integer
    Public totalSaldoDetalles As Decimal
    Public folioSeleccionados As String = String.Empty
    Public factura As String
    Public descuento As Decimal
    Public importeIva As Decimal
    Public totalnotacredito As Decimal = 0.00
    Public subtotal As Decimal = 0.00
    Public totalImportes As Decimal = 0.00
    Public totalSubtotal As Decimal = 0.00
    Public totalIva As Decimal = 0.00
    Public detallesBuscar As String
    Public clickCancelar As Boolean = False
    Public importeReemplazar As Decimal
    Public foliosReemplazar As String
    Public cantidadRecuperada As Integer
    Public detalleId As String
    Public seleccionMismaFila As Boolean ''''----> determina si se volvio abrir el formulario en la misma fila
    Public dtsesionId As Integer
    Public parEditado As Boolean
    Dim detalleIdEliminar As Integer
    Dim paraactualizar As Integer
    Dim agregarDocMismoDocumento As Boolean
    Public tieneReg As Boolean
    Dim clicBotonAgregar As Boolean = False
    Public totalParesAplicar As Int32 = 0
    Public actualizarDatosSession As Boolean
    Public accion As Boolean

    Private Sub DetallesDevolucionesNotasCreditoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        lblSaldoPasado.Visible = False
        cargarDetallesDevoluciones()
    End Sub
    Private Sub cargarDetallesDevoluciones()
        Dim objDetallesDevoluciones As New NotaCreditoDevolucionesBU
        Dim dtDetallesDevoluciones As New DataTable
        Dim NCdetalles As New NotasCreditoDevoluciones
        Dim StatusCode As String = String.Empty
        Dim parxaplicar As String = String.Empty
        Dim resta As String = String.Empty
        Dim code As String = String.Empty
        Dim totalnc As String = String.Empty
        Dim par As String = String.Empty
        Dim otraResta As String = String.Empty
        Dim parRestar As String = String.Empty
        Dim dtTableDetalles As New DataTable
        Dim objBU As New NotaCreditoDevolucionesBU
        Dim doc As String = String.Empty
        Dim detallesPegar As String = String.Empty

        NCdetalles.NotaCreditoRFCClienteId = rfcClienteId
        lblTotalRegistros.Text = 0
        NCdetalles.NotaCreditoClienteId = idCliente
        If tipoNC = "F" Then
            NCdetalles.NotaCreditoRazSocialId = idempresa
            dtDetallesDevoluciones = objDetallesDevoluciones.obtenerDetallesDevoluciones(NCdetalles, dtsesionId, factura, 1)
            tieneReg = False
        Else
            NCdetalles.NotaCreditoRazSocialId = 0
            dtDetallesDevoluciones = objDetallesDevoluciones.obtenerDetallesDevolucionesRemisiones(NCdetalles, dtsesionId, remisionId, 1)
            tieneReg = False
        End If

        'Dim var As Boolean = False
        dtTableDetalles = objBU.consultarFoliosDetallesActivos(dtsesionId)

        If dtTableDetalles.Rows.Count > 0 Then
            For y As Integer = 0 To dtTableDetalles.Rows.Count - 1
                ' If y = 0 Then
                code = dtTableDetalles.Rows(y).Item(2)
                par = dtTableDetalles.Rows(y).Item(0)
                totalnc = dtTableDetalles.Rows(y).Item(1)
                doc = dtTableDetalles.Rows(y).Item(3)
            Next
        End If

        If dtDetallesDevoluciones.Rows.Count > 0 Then
            grdDetallesDevoluciones.DataSource = dtDetallesDevoluciones
            diseñoGridDetalles(vwDetallesDevoluciones, dtTableDetalles)
            lblTotalRegistros.Text = dtDetallesDevoluciones.Rows.Count
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay información para mostrar.")
            Close()
        End If
    End Sub
    Private Sub diseñoGridDetalles(Grid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal dttable As DataTable)
        vwDetallesDevoluciones.BestFitColumns()
        ''Tools.DiseñoGrid.AlternarColorEnFilas(vwDetallesDevoluciones) '' pone color a las filas del gridview
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwDetallesDevoluciones.Columns
            If col.FieldName = "Folio Dev" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 60
                col.Fixed = Columns.FixedStyle.Left
            End If
            If col.FieldName = "Fecha Registro" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 90
                col.Fixed = Columns.FixedStyle.Left
            End If
            If col.FieldName = "Marca" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 65
                col.Fixed = Columns.FixedStyle.Left
            End If
            If col.FieldName = "Colección" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 130
            End If
            If col.FieldName = "Modelo SAY" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 69
            End If
            If col.FieldName = "Modelo SICY" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 70
            End If
            If col.FieldName = "Piel" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 115
            End If
            If col.FieldName = "Color" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 80
            End If
            If col.FieldName = "Corrida" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 60
            End If
            If col.FieldName = "Cantidad Dev" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 80
            End If
            If col.FieldName = "Precio" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 40
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "N0"
            End If
            If col.FieldName = "Total Dev" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 60
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "N0"
            End If
            If col.FieldName = "Pares Aplicados" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 86
            End If
            If col.FieldName = "Pares Por Aplicar" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 94
            End If
            If col.FieldName = "Seleccionar" Then
                col.OptionsColumn.AllowEdit = True
                col.Width = 62
            End If
            If col.FieldName = "Pares a Aplicar" Then
                col.OptionsColumn.AllowEdit = True
                col.Width = 80
            End If
            If col.FieldName = "Total NC" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 70
                col.DisplayFormat.FormatString = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "{0:C2}"
            End If
            If col.FieldName = "Descuento" Then
                col.Visible = False
            End If
            If col.FieldName = "Producto Estilo" Then
                col.Visible = False
            End If
            If col.FieldName = "Clave Sat" Then
                col.Visible = False
            End If
            If col.FieldName = "Descripcion Articulo" Then
                col.Visible = False
            End If
            If col.FieldName = "detalleDevolucionId" Then
                col.Visible = False
            End If
            If col.FieldName = "ImporteIva" Then
                col.Visible = False
            End If
            If col.FieldName = "Subtotal" Then
                col.Visible = False
            End If
            If col.FieldName = "Cantidad" Then
                col.Visible = False
            End If

            If col.FieldName = "OtrosDoc" Then
                If dttable.Rows.Count > 0 Then
                    col.OptionsColumn.AllowEdit = False
                    col.Width = 80
                    col.Visible = True
                Else
                    col.Visible = False
                End If
            End If
        Next
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwDetallesDevoluciones.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
        Grid.IndicatorWidth = 30
        lbltotalSD.Text = "$" & " " & Format(totalSaldoFactura, "##,##0.00")

        Dim sumaotrosdoc As Decimal = 0.00
        If dttable.Rows.Count > 0 Then
            For vb As Integer = 0 To dttable.Rows.Count - 1
                sumaotrosdoc += dttable.Rows(vb).Item(1)
            Next
            lbltotalotrosdoc.Visible = True
            lblttotalotrosdoc.Visible = True
            lblttotalotrosdoc.Text = "$" & " " & Format(sumaotrosdoc, "##,##0.00")
            lbltDocActual.Text = factura
            lblDocActual.Visible = True
            lbltDocActual.Visible = True
        Else
            lbltotalotrosdoc.Visible = False
            lblttotalotrosdoc.Visible = False
            lblDocActual.Visible = False
            lbltDocActual.Visible = False
        End If
    End Sub
    Private Sub vwDetallesDevoluciones_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwDetallesDevoluciones.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        clickCancelar = True
        Me.Close()
    End Sub
    ''' <summary>
    ''' Evento de validacion en la edicion de una celda, valida que la cantidad pares aplicar no sea a mayor a la cantidad de pares por aplicar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub vwDetallesDevoluciones_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles vwDetallesDevoluciones.ValidatingEditor
        Dim devolucion As New NotasCreditoDevoluciones
        Dim dtSessionFolioActivo As DataTable
        Dim objSession As New NotaCreditoDevolucionesBU
        Dim folioDev As Integer = 0
        Dim precioUnit As Decimal = 0.00
        Dim paresaplicar As Integer = 0
        Dim prodcutoEstilo As String = String.Empty
        Dim porcentaje As Decimal = 0.00
        Dim documentoId As Integer = 0
        Dim claveSat As String = String.Empty
        Dim descripcion As String = String.Empty
        Dim detalleDevolucionId As Integer = 0
        Dim importeTotalNC As Decimal = 0.00

        Dim clickeado As Boolean = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Seleccionar")
        If vwDetallesDevoluciones.FocusedRowHandle >= 0 Then
            If clickeado = True Then
                vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Seleccionar", False) '' valida que no este clickeado
                lblSaldoPasado.Visible = False
                btnAgregar.Enabled = True
            End If

            vuelta = 0

            If Not IsDBNull(e.Value) AndAlso e.Value.ToString.Trim = "" Then
                e.Valid = True
                Dim resta As Decimal = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Total NC")
                Dim totalDevolucion As Decimal = lblresultadotd.Text
                Dim TotalrestaDevolucion As Decimal
                vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Total NC", "")
                vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "IVA", "0.00")
                vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Descuento", "0.00")
                TotalrestaDevolucion = totalDevolucion - resta
                lblresultadotd.Text = "$" & " " & Format(TotalrestaDevolucion, "##,##0.00")
            Else
                If IsNumeric(e.Value) Then
                    If vwDetallesDevoluciones.FocusedColumn.FieldName = "Pares a Aplicar" Then
                        ''valida folios ocupados x otros usuarios
                        devolucion.NotaCreditoFolio = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Folio Dev")
                        dtSessionFolioActivo = objSession.obtenerSessionActivaFolioDevolucion(devolucion)

                        If dtSessionFolioActivo.Rows.Count > 0 Then
                            Dim sessionOcupada As String = ""
                            sessionOcupada = dtSessionFolioActivo.Rows(0).Item(1)
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, sessionOcupada)
                            '' no muestra el check si es true la condicion es TRUE
                            Dim view As ColumnView = CType(grdDetallesDevoluciones.FocusedView, ColumnView)
                            If view.IsEditing Then view.HideEditor()
                            view.CancelUpdateCurrentRow()
                        Else
                            Dim totalParesPorAplicar As Int32 = 0
                            Dim documentosExist As String = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "OtrosDoc")
                            If documentosExist <> "" Then
                                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Este folio ya contiene un documento.")
                                Dim view As ColumnView = CType(grdDetallesDevoluciones.FocusedView, ColumnView)
                                If view.IsEditing Then view.HideEditor()
                                view.CancelUpdateCurrentRow()
                            Else
                                totalParesAplicar = e.Value
                                totalParesPorAplicar = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Pares Por Aplicar")
                                'If totalParesAplicar = 0 Then
                                'e.Valid = False
                                ' e.ErrorText = "Esta cantidad no puede ser 0"
                                'Else
                                If totalParesAplicar > totalParesPorAplicar Then
                                    e.Valid = False
                                    e.ErrorText = "Esta cantidad no puede ser mayor al valor de la columna ""Pares Por Aplicar"" "
                                Else
                                    e.Valid = True
                                    Dim objDescuento As New NotaCreditoDevolucionesBU
                                    paraactualizar = e.Value
                                    devolucion.NotaCreditoPrecioDevolucion = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Precio")
                                    devolucion.NotaCreditoClienteId = idCliente
                                    devolucion.NotaCreditoTipo = tipoNC
                                    devolucion.NotaCreditoParesAplicar = e.Value
                                    folioDev = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Folio Dev")
                                    prodcutoEstilo = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Producto Estilo")
                                    porcentaje = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Descuento")
                                    claveSat = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Clave Sat")
                                    descripcion = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Descripcion Articulo")
                                    detalleDevolucionId = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "detalleDevolucionId")
                                    dtTotalNC = objDescuento.obtenerTotalNC(devolucion)
                                    If dtTotalNC.Rows.Count > 0 Then
                                        If dtTotalNC.Rows.Count = 1 Then
                                            If tipoNC = "F" Then
                                                subtotal = dtTotalNC.Rows(0).Item(0).ToString
                                                importeIva = dtTotalNC.Rows(0).Item(2).ToString
                                                TotalNc = dtTotalNC.Rows(0).Item(3).ToString
                                                descuento = dtTotalNC.Rows(0).Item(4).ToString
                                                vuelta = 1
                                                vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Total NC", TotalNc)
                                                vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "ImporteIva", importeIva)
                                                vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Descuento", descuento)
                                                vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Subtotal", subtotal)
                                                vuelta = 2
                                                If actualizarDatosSession = False Then
                                                    objSession.insertaSesionDetallesUsuario(dtsesionId, folioDev, totalParesAplicar, factura, devolucion.NotaCreditoPrecioDevolucion, prodcutoEstilo, porcentaje, claveSat, descripcion, subtotal, importeIva, TotalNc, detalleDevolucionId, remisionId, anio)
                                                End If
                                                If actualizarDatosSession = True Then
                                                    objSession.actualizaParSessionDetalle(dtsesionId, factura, subtotal, importeIva, TotalNc, totalParesAplicar, detalleDevolucionId, folioDev, devolucion.NotaCreditoPrecioDevolucion, prodcutoEstilo, porcentaje, claveSat, descripcion, remisionId, anio)
                                                End If
                                            Else
                                                subtotal = dtTotalNC.Rows(0).Item(0).ToString
                                                TotalNc = dtTotalNC.Rows(0).Item(1).ToString
                                                descuento = dtTotalNC.Rows(0).Item(2).ToString
                                                vuelta = 1
                                                vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Total NC", TotalNc)
                                                vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Descuento", descuento)
                                                vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Subtotal", subtotal)
                                                vuelta = 2
                                                If actualizarDatosSession = False Then
                                                    objSession.insertaSesionDetallesUsuario(dtsesionId, folioDev, totalParesAplicar, factura, devolucion.NotaCreditoPrecioDevolucion, prodcutoEstilo, porcentaje, claveSat, descripcion, subtotal, importeIva, TotalNc, detalleDevolucionId, remisionId, anio)
                                                End If
                                                If actualizarDatosSession = True Then
                                                    objSession.actualizaParSessionDetalle(dtsesionId, factura, subtotal, importeIva, TotalNc, totalParesAplicar, detalleDevolucionId, folioDev, devolucion.NotaCreditoPrecioDevolucion, prodcutoEstilo, porcentaje, claveSat, descripcion, remisionId, anio)
                                                End If
                                            End If

                                        Else
                                            TotalNc = dtTotalNC.Rows(0).Item(0)
                                            descuento = dtTotalNC.Rows(0).Item(1)
                                            importeIva = dtTotalNC.Rows(0).Item(2).ToString
                                            vuelta = 1
                                            vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Total NC", TotalNc)
                                            vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Descuento", descuento)
                                            vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "ImporteIva", importeIva)
                                            vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Subtotal", descuento)
                                            vuelta = 2
                                            If actualizarDatosSession = False Then
                                                objSession.insertaSesionDetallesUsuario(dtsesionId, folioDev, totalParesAplicar, factura, devolucion.NotaCreditoPrecioDevolucion, prodcutoEstilo, porcentaje, claveSat, descripcion, subtotal, importeIva, TotalNc, detalleDevolucionId, remisionId, anio)
                                            End If
                                            If actualizarDatosSession = True Then
                                                objSession.actualizaParSessionDetalle(dtsesionId, factura, subtotal, importeIva, TotalNc, totalParesAplicar, detalleDevolucionId, folioDev, devolucion.NotaCreditoPrecioDevolucion, prodcutoEstilo, porcentaje, claveSat, descripcion, remisionId, anio)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                            'End If
                            'End If
                        End If
                    End If
                Else
                    e.Valid = False
                    e.ErrorText = "El valor ingresado debe ser numérico"
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' al darle click a columna 'Seleccion', pasa el valor de la columna "pares por aplicar" a la columna "pares a aplicar"
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub vwDetallesDevoluciones_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles vwDetallesDevoluciones.CellValueChanging
        Dim index As Integer = (e.RowHandle)

        Dim objDescuento As New NotaCreditoDevolucionesBU
        Dim dtTotalNC As New DataTable
        Dim devolucion As New NotasCreditoDevoluciones
        Dim TotalNc As Decimal
        Dim sumaDevolucion As Decimal
        Dim sumaDev As Decimal
        Dim sumaTotal As Decimal
        Dim TotalrestaDevolucion As Decimal
        Dim dtSessionFolioActivo As DataTable
        Dim parxaplicar As Integer = (vwDetallesDevoluciones.GetRowCellValue(index, "Pares Por Aplicar"))
        Dim folioDev As Integer = 0
        Dim precioUnit As Decimal = 0.00
        Dim paresaplicar As Integer = 0
        Dim prodcutoEstilo As String = String.Empty
        Dim porcentaje As Decimal = 0.00
        Dim documentoId As Integer = 0
        Dim claveSat As String = String.Empty
        Dim descripcion As String = String.Empty
        Dim detalleDevolucionId As Integer = 0
        Dim importeTotalNC As Decimal = 0.00
        If vwDetallesDevoluciones.FocusedColumn.FieldName = "Seleccionar" Then

            ''valida folios ocupados x otros usuarios
            devolucion.NotaCreditoFolio = (vwDetallesDevoluciones.GetRowCellValue(index, "Folio Dev"))
            dtSessionFolioActivo = objDescuento.obtenerSessionActivaFolioDevolucion(devolucion)

            If dtSessionFolioActivo.Rows.Count > 0 Then
                Dim sessionOcupada As String = ""
                sessionOcupada = dtSessionFolioActivo.Rows(0).Item(1)
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, sessionOcupada)
                '' no muestra el check si es true la condicion es TRUE
                Dim view As ColumnView = CType(grdDetallesDevoluciones.FocusedView, ColumnView)
                If view.IsEditing Then view.HideEditor()
                view.CancelUpdateCurrentRow()
            Else
                Dim valorCasilla = vwDetallesDevoluciones.GetFocusedValue
                If valorCasilla = True Then
                    vwDetallesDevoluciones.SetFocusedValue(False)
                    accion = False
                Else
                    vwDetallesDevoluciones.SetFocusedValue(True)
                    accion = True
                End If
                If accion = True Then
                    '' valida que la seleccion no corresponda a tra factura
                    Dim otroDoc As String = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "OtrosDoc")
                    If otroDoc <> "" Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Este folio ya contiene un documento.")
                        Dim view As ColumnView = CType(grdDetallesDevoluciones.FocusedView, ColumnView)
                        If view.IsEditing Then view.HideEditor()
                        view.CancelUpdateCurrentRow()
                    Else
                        vwDetallesDevoluciones.SetRowCellValue(index, "Pares a Aplicar", parxaplicar)
                        devolucion.NotaCreditoPrecioDevolucion = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Precio")
                        devolucion.NotaCreditoClienteId = idCliente
                        devolucion.NotaCreditoTipo = tipoNC
                        devolucion.NotaCreditoParesAplicar = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Pares Por Aplicar")
                        folioDev = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Folio Dev")
                        prodcutoEstilo = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Producto Estilo")
                        porcentaje = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Descuento")
                        claveSat = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Clave Sat")
                        descripcion = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Descripcion Articulo")
                        detalleDevolucionId = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "detalleDevolucionId")
                        dtTotalNC = objDescuento.obtenerTotalNC(devolucion)
                        If dtTotalNC.Rows.Count > 0 Then
                            If dtTotalNC.Rows.Count = 1 Then
                                agregarDocMismoDocumento = True
                                If tipoNC = "F" Then
                                    subtotal = dtTotalNC.Rows(0).Item(0)
                                    TotalNc = dtTotalNC.Rows(0).Item(3)
                                    importeIva = dtTotalNC.Rows(0).Item(2).ToString
                                    descuento = dtTotalNC.Rows(0).Item(4).ToString
                                    vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Total NC", TotalNc)
                                    vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "ImporteIva", importeIva)
                                    vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Descuento", descuento)
                                    vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Subtotal", subtotal)
                                    objDescuento.insertaSesionDetallesUsuario(dtsesionId, folioDev, parxaplicar, factura, devolucion.NotaCreditoPrecioDevolucion, prodcutoEstilo, porcentaje, claveSat, descripcion, subtotal, importeIva, TotalNc, detalleDevolucionId, remisionId, anio)
                                Else
                                    subtotal = dtTotalNC.Rows(0).Item(0)
                                    TotalNc = dtTotalNC.Rows(0).Item(1)
                                    descuento = dtTotalNC.Rows(0).Item(2).ToString
                                    vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Total NC", TotalNc)
                                    vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Subtotal", subtotal)
                                    vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Descuento", descuento)
                                    objDescuento.insertaSesionDetallesUsuario(dtsesionId, folioDev, totalParesAplicar, factura, devolucion.NotaCreditoPrecioDevolucion, prodcutoEstilo, porcentaje, claveSat, descripcion, subtotal, importeIva, TotalNc, detalleDevolucionId, remisionId, anio)
                                End If

                            Else
                                TotalNc = dtTotalNC.Rows(0).Item(0)
                                importeIva = dtTotalNC.Rows(0).Item(2).ToString
                                vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Total NC", TotalNc)
                                vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "ImporteIva", importeIva)
                                descuento = dtTotalNC.Rows(0).Item(1)
                                vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Descuento", descuento)
                                objDescuento.insertaSesionDetallesUsuario(dtsesionId, folioDev, totalParesAplicar, factura, devolucion.NotaCreditoPrecioDevolucion, prodcutoEstilo, porcentaje, claveSat, descripcion, subtotal, importeIva, TotalNc, detalleDevolucionId, remisionId, anio)
                            End If

                            sumaDevolucion = TotalNc + lblresultadotd.Text
                            lblresultadotd.Text = "$" & " " & Format(sumaDevolucion, "##,##0.00")
                            sumaDev = lblresultadotd.Text
                            sumaTotal = lbltotalSD.Text
                            If sumaDev > sumaTotal Then
                                lblSaldoPasado.Visible = True
                                btnAgregar.Enabled = False
                                lblagregar.Enabled = False
                            End If
                        End If
                    End If
                Else
                    vwDetallesDevoluciones.SetRowCellValue(index, "Pares a Aplicar", "0")
                    Dim totalSaldoDocumento As Decimal = lbltotalSD.Text
                    Dim totalDevolucion As Decimal = lblresultadotd.Text
                    Dim resta As Decimal = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Total NC")
                    TotalrestaDevolucion = totalDevolucion - resta
                    lblresultadotd.Text = "$" & " " & Format(TotalrestaDevolucion, "##,##0.00")
                    vwDetallesDevoluciones.SetRowCellValue(index, "Total NC", "")
                    vwDetallesDevoluciones.SetRowCellValue(index, "Descuento", "0.00")
                    devolucion.NotaCreditoPrecioDevolucion = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Precio")
                    devolucion.NotaCreditoParesAplicar = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Pares Por Aplicar")
                    folioDev = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Folio Dev")
                    prodcutoEstilo = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Producto Estilo")
                    porcentaje = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Descuento")
                    claveSat = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Clave Sat")
                    descripcion = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Descripcion Articulo")
                    detalleDevolucionId = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "detalleDevolucionId")
                    TotalNc = resta
                    If TotalrestaDevolucion <= totalSaldoDocumento Then
                        lblSaldoPasado.Visible = False
                        btnAgregar.Enabled = True
                        lblagregar.Enabled = True
                    End If
                    objDescuento.actualizaParSessionDetalle(dtsesionId, factura, subtotal, importeIva, TotalNc, totalParesAplicar, detalleDevolucionId, folioDev, devolucion.NotaCreditoPrecioDevolucion, prodcutoEstilo, porcentaje, claveSat, descripcion, remisionId, anio)
                End If
            End If
        End If
    End Sub
    Private Sub CboxAplicaTodo_CheckedChanged(sender As Object, e As EventArgs) Handles CboxAplicaTodo.CheckedChanged
        Dim numeroFilas = vwDetallesDevoluciones.DataRowCount
        Dim dtTotalNC As New DataTable
        Dim devolucion As New NotasCreditoDevoluciones
        Dim objTotalSeleccioTodo As New NotaCreditoDevolucionesBU
        Dim sumaDevolucion As Decimal
        Dim sumaDev As Decimal
        Dim sumaTotal As Decimal
        If numeroFilas = 0 Then Return
        Dim TotalNc As Decimal
        Dim paresxaplicar As Integer = 0
        Dim cantidadVentas As Integer
        If CboxAplicaTodo.Checked = True Then
            For index As Integer = 0 To numeroFilas Step 1
                cantidadVentas = (vwDetallesDevoluciones.GetRowCellValue(index, "Cantidad"))
                If cantidadVentas <> 0 Then '' devoluciones que no tiene venta
                    vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.GetVisibleRowHandle(index), "Seleccionar", True)
                    paresxaplicar = (vwDetallesDevoluciones.GetRowCellValue(index, "Pares Por Aplicar"))
                    vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.GetVisibleRowHandle(index), "Pares a Aplicar", paresxaplicar)
                    devolucion.NotaCreditoPrecioDevolucion = (vwDetallesDevoluciones.GetRowCellValue(index, "Precio"))
                    devolucion.NotaCreditoClienteId = idCliente
                    devolucion.NotaCreditoTipo = tipoNC
                    devolucion.NotaCreditoParesAplicar = (vwDetallesDevoluciones.GetRowCellValue(index, "Pares Por Aplicar"))
                    dtTotalNC = objTotalSeleccioTodo.obtenerTotalNC(devolucion)

                    If dtTotalNC.Rows.Count > 0 Then
                        If tipoNC = "F" Then
                            subtotal = dtTotalNC.Rows(0).Item(0)
                            TotalNc = dtTotalNC.Rows(0).Item(3)
                            importeIva = dtTotalNC.Rows(0).Item(2)
                            descuento = dtTotalNC.Rows(0).Item(4)
                            vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.GetVisibleRowHandle(index), "Total NC", TotalNc)
                            vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.GetVisibleRowHandle(index), "ImporteIva", importeIva)
                            vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.GetVisibleRowHandle(index), "Descuento", descuento)
                            vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.GetVisibleRowHandle(index), "Subtotal", subtotal)
                        Else
                            subtotal = dtTotalNC.Rows(0).Item(0)
                            TotalNc = dtTotalNC.Rows(0).Item(1)
                            descuento = dtTotalNC.Rows(0).Item(2)
                            vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.GetVisibleRowHandle(index), "Total NC", TotalNc)
                            vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.GetVisibleRowHandle(index), "Descuento", descuento)
                            vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.GetVisibleRowHandle(index), "Subtotal", subtotal)
                        End If
                        sumaDevolucion = TotalNc + lblresultadotd.Text
                        lblresultadotd.Text = "$" & " " & Format(sumaDevolucion, "##,##0.00")
                        sumaDev = lblresultadotd.Text
                        sumaTotal = lbltotalSD.Text
                        If sumaDev > sumaTotal Then
                            lblSaldoPasado.Visible = True
                            btnAgregar.Enabled = False
                            lblagregar.Enabled = False
                        End If
                    End If
                End If
            Next
        Else
            For index As Integer = 0 To numeroFilas Step 1
                vwDetallesDevoluciones.SetRowCellValue(vwDetallesDevoluciones.GetVisibleRowHandle(index), "Seleccionar", False)
                vwDetallesDevoluciones.SetRowCellValue(index, "Pares a Aplicar", "")
                vwDetallesDevoluciones.SetRowCellValue(index, "Total NC", "0.00")
                vwDetallesDevoluciones.SetRowCellValue(index, "Descuento", "0.00")
                vwDetallesDevoluciones.SetRowCellValue(index, "ImporteIva", "0.00")
                vwDetallesDevoluciones.SetRowCellValue(index, "Subtotal", "0.00")
                lblresultadotd.Text = "0"
                lblSaldoPasado.Visible = False
                btnAgregar.Enabled = True
                lblagregar.Enabled = True
            Next
        End If
    End Sub
    Private Sub vwDetallesDevoluciones_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles vwDetallesDevoluciones.CellValueChanged
        If vwDetallesDevoluciones.FocusedColumn.FieldName = "Pares a Aplicar" Then
            Dim cantidad As String
            If vuelta = 2 Then ''indica la vuelta, vuelta 1 no realiza esta accion, para que no sume dos veces
                If dtTotalNC.Rows.Count > 0 Then
                    cantidad = e.Value
                    ResultadoSumaNC(cantidad)
                End If
            End If
        End If
    End Sub
    Private Sub ResultadoSumaNC(ByVal cantidad As String)
        Dim totalFinal As Decimal
        Dim totalsubtotal As Decimal
        Dim total_total As Decimal
        For i As Integer = 0 To vwDetallesDevoluciones.DataRowCount - 1
            If CStr(vwDetallesDevoluciones.GetRowCellValue(i, "Total NC").ToString()) <> "" Then
                Dim totalNC = CStr(vwDetallesDevoluciones.GetRowCellValue(i, "Total NC").ToString())
                totalFinal += totalNC
            End If
        Next i
        lblresultadotd.Text = "$" & " " & Format(totalFinal, "##,##0.00")
        totalsubtotal = lblresultadotd.Text
        total_total = lbltotalSD.Text
        If totalsubtotal > total_total Then
            lblSaldoPasado.Visible = True
            btnAgregar.Enabled = False
            lblagregar.Enabled = False
        Else
            lblSaldoPasado.Visible = False
            btnAgregar.Enabled = True
            lblagregar.Enabled = True
        End If
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        llenarInformacionNotaCredito()
        clicBotonAgregar = True
        Close()
    End Sub
    Private Sub llenarInformacionNotaCredito()
        Dim totalCantidad As Integer = 0
        Dim folio As String
        Dim separacion
        Dim existe As Boolean = False
        Dim folioDev As Integer = 0
        Dim precioUnit As Decimal = 0.00
        Dim paresaplicar As Integer = 0
        Dim prodcutoEstilo As String = String.Empty
        Dim porcentaje As Decimal = 0.00
        Dim documentoId As Integer = 0
        Dim claveSat As String = String.Empty
        Dim descripcion As String = String.Empty
        Dim detalleDevolucionId As Integer = 0
        Dim importeTotalNC As Decimal = 0.00
        Dim descuento As Decimal = 0.00
        Dim iva As Decimal = 0.00
        Dim resultadoIvaTotal As Decimal = 0.00
        Dim resultadoPrecioUnit As Decimal = 0.00
        Dim sumaTotalNC As Decimal = 0.00
        Dim sum As String = String.Empty
        Dim dtExistentes As New DataTable
        Dim devolucionBuscar As String = String.Empty

        For index As Integer = 0 To vwDetallesDevoluciones.DataRowCount - 1
            If vwDetallesDevoluciones.GetRowCellValue(index, "Pares a Aplicar").ToString() <> "" Then
                Dim cantidad = CInt(vwDetallesDevoluciones.GetRowCellValue(index, "Pares a Aplicar").ToString())
                totalCantidad += cantidad
            End If
        Next index
        totalSumaCantidad = totalCantidad

        If parEditado = False Then
            For indexFolios As Integer = 0 To vwDetallesDevoluciones.DataRowCount - 1
                If CBool(vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.GetVisibleRowHandle(indexFolios), "Seleccionar")) = True Or (vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.GetVisibleRowHandle(indexFolios), "Pares a Aplicar")) >= 0.00 Or (vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.GetVisibleRowHandle(indexFolios), "Pares a Aplicar")) > 0 Then
                    If folioSeleccionados = String.Empty Then
                        folioSeleccionados = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.GetVisibleRowHandle(indexFolios), "Folio Dev").ToString()
                    Else
                        folio = vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.GetVisibleRowHandle(indexFolios), "Folio Dev").ToString()
                        separacion = Split(folioSeleccionados, ",")
                        For Each clave As String In separacion ''verifica que los folios seleccionados no sean los mismos
                            If clave = folio Then
                                existe = True
                            Else
                                existe = False
                            End If
                        Next
                        If existe = False Then
                            folioSeleccionados = folioSeleccionados & "," & vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.GetVisibleRowHandle(indexFolios), "Folio Dev").ToString()
                        End If
                    End If

                    folioDev = vwDetallesDevoluciones.GetRowCellValue(indexFolios, "Folio Dev")
                    precioUnit = vwDetallesDevoluciones.GetRowCellValue(indexFolios, "Precio")
                    paresaplicar = vwDetallesDevoluciones.GetRowCellValue(indexFolios, "Pares a Aplicar")
                    prodcutoEstilo = vwDetallesDevoluciones.GetRowCellValue(indexFolios, "Producto Estilo")
                    porcentaje = vwDetallesDevoluciones.GetRowCellValue(indexFolios, "Descuento")
                    claveSat = vwDetallesDevoluciones.GetRowCellValue(indexFolios, "Clave Sat")
                    descripcion = vwDetallesDevoluciones.GetRowCellValue(indexFolios, "Descripcion Articulo")
                    detalleDevolucionId = vwDetallesDevoluciones.GetRowCellValue(indexFolios, "detalleDevolucionId")
                    importeTotalNC = vwDetallesDevoluciones.GetRowCellValue(indexFolios, "Subtotal")
                    iva = vwDetallesDevoluciones.GetRowCellValue(indexFolios, "ImporteIva")
                    descuento = vwDetallesDevoluciones.GetRowCellValue(indexFolios, "Descuento")
                    sum = IsDBNull(vwDetallesDevoluciones.GetRowCellValue(indexFolios, "Total NC"))
                    sumaTotalNC = importeTotalNC + iva
                End If
            Next

            totalIva = resultadoIvaTotal
            totalSubtotal = totalImportes
            totalnotacredito = lblresultadotd.Text
            folioSeleccionados = folioSeleccionados
        End If
        parEditado = False
    End Sub
    Private Sub vwDetallesDevoluciones_RowStyle(sender As Object, e As RowStyleEventArgs) Handles vwDetallesDevoluciones.RowStyle
        If e.RowHandle > 0 Or e.RowHandle = 0 Then
            Dim cantidad As Integer
            Dim parporaplicar As Integer
            cantidad = vwDetallesDevoluciones.GetRowCellValue(e.RowHandle, "Cantidad")
            parporaplicar = vwDetallesDevoluciones.GetRowCellValue(e.RowHandle, "Pares Por Aplicar")
            If cantidad = 0 Then
                e.Appearance.BackColor = Color.FromArgb(255, 0, 0)
            End If
            If parporaplicar = 0 Then
                e.Appearance.BackColor = Color.FromArgb(249, 157, 77)
            End If
        End If
    End Sub
    Private Sub vwDetallesDevoluciones_ShowingEditor(sender As Object, e As CancelEventArgs) Handles vwDetallesDevoluciones.ShowingEditor
        Dim cantidad As Integer
        'Dim paresaplicados As Integer
        cantidad = Convert.ToInt32(vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Cantidad"))
        'paresaplicados = Convert.ToInt32(vwDetallesDevoluciones.GetRowCellValue(vwDetallesDevoluciones.FocusedRowHandle, "Pares Por Aplicar"))
        If cantidad = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub DetallesDevolucionesNotasCreditoForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub DetallesDevolucionesNotasCreditoForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If clicBotonAgregar = False Then
            clickCancelar = True
            e.Cancel = False
        Else
            clickCancelar = False
            e.Cancel = False
            clicBotonAgregar = False
        End If
    End Sub

End Class