Imports System.Drawing
Imports System.Windows.Forms
Imports System.Xml
Imports Cobranza.Negocios
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports Entidades
Imports Framework.Negocios
Imports Tools
Imports ToolServicios

Public Class NotasCreditoDevolucionForm
    Dim terminaLoad As Boolean = False
    Dim terminaCargaCliente As Boolean = False
    Dim terminaCargaRFC As Boolean = False
    Dim documento As Boolean = False
    Dim NCDevoluciones As New NotasCreditoDevoluciones
    Dim checkFactura As Boolean = False
    Dim checkRemision As Boolean = False
    Dim dtRegistros As New DataTable
    Dim factura As Integer
    Dim remision As Integer
    Dim rowHandle As Integer = 0
    Dim formaPago As String
    Dim metodoPago As String
    Dim dtRegDetalles As New DataTable
    Dim rfcCliente As String = String.Empty
    Public idNotaCreditoGenerado As Integer
    '' VARIABLES PARA PRUEBAS
    Dim pruebas As Boolean = False
    Dim local As Boolean = False
    Dim listaFilas As New DataTable
    Dim dtSession As New DataTable
    Dim tieneReg As Boolean = False

    Private Sub NotasCreditoDevolucionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblidempresa.Text = 0
        lblidCliente.Text = 0
        cargaRazonesSocialesNotaCredito()
        cargaTipoMoneda()
        inhabilitarCampos()
        terminaLoad = True
        btnGuardar.Enabled = False
        lblguardar.Enabled = False
        btnlEliminarFila.Enabled = False
        lbleliminarfila.Enabled = False
        dtRegDetalles.Clear()
    End Sub
    Private Sub cargaRazonesSocialesNotaCredito()
        Dim objObtenerRazSociales As New NotaCreditoDevolucionesBU
        Dim dtRazonesSociales As DataTable
        dtRazonesSociales = objObtenerRazSociales.obtenerRazonesSociales
        dtRazonesSociales.Rows.InsertAt(dtRazonesSociales.NewRow, 0)
        cmbRazonSocial.DataSource = dtRazonesSociales
        If dtRazonesSociales.Rows.Count > 1 Then
            cmbRazonSocial.ValueMember = "iddocumento"
            cmbRazonSocial.DisplayMember = "razonsocial"
        End If
        cmbRazonSocial.AutoCompleteMode = AutoCompleteMode.Suggest
        cmbRazonSocial.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub
    Private Sub cargaConceptosNotaCreditoDevoluciones(ByVal NCDevoluciones As NotasCreditoDevoluciones)
        Dim objConceptos As New NotaCreditoDevolucionesBU
        Dim dtConceptos As New DataTable
        dtConceptos = objConceptos.obtenerConceptos(NCDevoluciones)
        dtConceptos.Rows.InsertAt(dtConceptos.NewRow, 0)
        CmbConcepto.DataSource = dtConceptos
        If dtConceptos.Rows.Count > 1 Then
            CmbConcepto.ValueMember = "idconcepto"
            CmbConcepto.DisplayMember = "concepto"
        End If
    End Sub
    Private Sub cargaTipoMoneda()
        Dim objTipoMoneda As New NotaCreditoDevolucionesBU
        Dim dtMoneda As New DataTable
        dtMoneda = objTipoMoneda.obtenerTipoMoneda
        cmbMoneda.DataSource = dtMoneda
        If dtMoneda.Rows.Count > 0 Then
            cmbMoneda.ValueMember = "moneda Id"
            cmbMoneda.DisplayMember = "moneda"
        End If
    End Sub
    Private Sub inhabilitarCampos()
        cmbRazonSocial.Enabled = False
        CmbConcepto.Enabled = False
        btnCargaDocumentos.Enabled = False
        txtiva.Text = "0.16"
        txtDescuentoCXC.Text = "0.00"
        CmbConcepto.Enabled = False
        lblCargarDocumentos.Enabled = False
        lblTSubtotal.Visible = False
        lblTIva.Visible = False
        lblTTotal.Visible = False
    End Sub
    Private Sub rdRemision_CheckedChanged(sender As Object, e As EventArgs) Handles rdRemision.CheckedChanged
        cmbRazonSocial.Text = ""
        cmbRazonSocial.Enabled = False
        CmbConcepto.Enabled = True
        remision = 1
        limpiarFormularioNotaCredito()
        checkFactura = False
        checkRemision = True
        NCDevoluciones.NotaCreditoConcepto = "F"
        cargaConceptosNotaCreditoDevoluciones(NCDevoluciones)
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dim objBU As New NotaCreditoDevolucionesBU
        If validaInformacionExistenteAntesCerrar() Then
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Todos los cambios no guardados se perderan ¿desea continuar?."
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                objBU.EliminarSesionUsuario(lblidclienteSICY.Text, dtSession.Rows(0).Item(0))
                Me.Close()
            End If
        Else
            If wvNotasCreditoCliente.RowCount > 0 Then
                objBU.EliminarSesionUsuario(lblidclienteSICY.Text, dtSession.Rows(0).Item(0))
                Me.Close()
            Else
                Me.Close()
            End If
        End If
    End Sub
    Private Sub CmbConcepto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbConcepto.SelectedIndexChanged
        habilitarCampos()
    End Sub
    Private Sub habilitarCampos()
        NCDevoluciones.NotaCreditoTipo = ""
        If rdFactura.Checked = True Then
            If CmbConcepto.SelectedValue.ToString <> "" Then
                cmbRazonSocial.Enabled = True
                If terminaLoad = True Then
                    NCDevoluciones.NotaCreditoTipo = "F"
                End If
            End If
        Else
            If CmbConcepto.SelectedValue.ToString <> "" Then
                If terminaLoad = True Then
                    NCDevoluciones.NotaCreditoTipo = "R"
                End If
            End If
        End If
    End Sub
    Private Sub rdFactura_CheckedChanged(sender As Object, e As EventArgs) Handles rdFactura.CheckedChanged
        CmbConcepto.Enabled = True
        factura = 1
        limpiarFormularioNotaCredito()
        checkFactura = True
        checkRemision = False
        NCDevoluciones.NotaCreditoConcepto = "F"
        cargaConceptosNotaCreditoDevoluciones(NCDevoluciones)
        habilitarCampos()
    End Sub
    Private Sub cmbRazonSocial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRazonSocial.SelectedIndexChanged
        Dim objId As New NotaCreditoDevolucionesBU
        Dim dtId As New DataTable
        If terminaLoad = True Then
            btnCargaDocumentos.Enabled = True
            lblCargarDocumentos.Enabled = True
            NCDevoluciones.NotaCreditoRazonSocial = cmbRazonSocial.Text
            If IsDBNull(cmbRazonSocial.SelectedValue) Then
                NCDevoluciones.NotaCreditoRazSocialId = 0
            Else
                NCDevoluciones.NotaCreditoRazSocialId = cmbRazonSocial.SelectedValue
            End If
        End If
        If CmbConcepto.Text <> "" Then
            dtId = objId.obtenerIdRazonSocial(NCDevoluciones)
            If dtId.Rows.Count > 0 Then
                lblidempresa.Text = dtId.Rows(0).Item(0)
            End If
        End If
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Dim objBU As New NotaCreditoDevolucionesBU
        factura = 0
        remision = 0
        If wvNotasCreditoCliente.RowCount > 0 Then
            objBU.EliminarSesionUsuario(lblidclienteSICY.Text, dtSession.Rows(0).Item(0))
        End If
        limpiarFormularioNotaCredito()
        habilitarCamposNotaCredito()
        btnlEliminarFila.Enabled = False
        lbleliminarfila.Enabled = False
    End Sub
    Private Sub limpiarFormularioNotaCredito()
        terminaCargaCliente = False
        terminaCargaRFC = False
        dtpFechaInicio.Value = Today
        CmbConcepto.Text = ""
        cmbMoneda.Text = ""
        txtiva.Text = "0.16"
        txtDescuentoCXC.Text = "0.00"
        cmbRazonSocial.Text = ""
        btnCargaDocumentos.Enabled = False
        lblCargarDocumentos.Enabled = False
        cmbRazonSocial.Enabled = False
        NCDevoluciones.NotaCreditoTipo = ""
        lblCliente.ForeColor = Color.Black
        lblRFCCliente.ForeColor = Color.Black
        cargaTipoMoneda()
        lblSerie.Text = ""
        lblSerie.Visible = False
        lblFolio.Text = ""
        lblFolio.Visible = False
        grdNotasCreditoCliente.DataSource = Nothing
        lblidempresa.Text = 0
        lblidCliente.Text = 0
        lblTSubtotal.Text = 0
        lblTSubtotal.Visible = False
        lblTIva.Text = 0
        lblTIva.Visible = False
        lblTTotal.Text = 0
        lblTTotal.Visible = False
        btnGuardar.Enabled = False
        lblguardar.Enabled = False
        txtrazonSocialCliente.Text = ""
        txtClientes.Text = ""
        lblidclienteSICY.Text = 0
        cmbRazonSocial.Enabled = False
        txtRFCCliente.Text = ""
        wvNotasCreditoCliente.Columns.Clear()
        dtRegDetalles.Clear()
        tieneReg = False
        lbl_cliente_sicy.Text = ""
    End Sub
    Private Sub habilitarCamposNotaCredito()
        rdFactura.Enabled = True
        rdRemision.Enabled = True
        CmbConcepto.Enabled = True
        cmbRazonSocial.Enabled = True
    End Sub
    Private Sub consultarDescuentoCXC()
        Dim objDescuento As New NotaCreditoDevolucionesBU
        Dim dtDescuento As New DataTable
        NCDevoluciones.NotaCreditoClienteId = lblidclienteSICY.Text
        dtDescuento = objDescuento.obtenerDescuentoCxC(NCDevoluciones)
        txtDescuentoCXC.Text = dtDescuento.Rows(0).Item(2)
        If checkRemision = True Then
            btnCargaDocumentos.Enabled = True
            lblCargarDocumentos.Enabled = True
        End If
    End Sub
    Private Sub consultaDocumentosNCRazonSocial()
        Dim objDocumento As New NotaCreditoDevolucionesBU
        Dim dtDocumento As New DataTable
        If IsDBNull(cmbRazonSocial.SelectedValue) Then
            NCDevoluciones.NotaCreditoRazSocialId = 0
        Else
            NCDevoluciones.NotaCreditoRazSocialId = cmbRazonSocial.SelectedValue
            dtDocumento = objDocumento.obtenerDocumentosRazonSocial(NCDevoluciones)
            If dtDocumento.Rows.Count < 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No existen documentos, para esta razón social.")
            Else
                documento = True
                NCDevoluciones.NotaCreditoCertificadoId = dtDocumento.Rows(0).Item(42)
                NCDevoluciones.NotaCreditoSerie = dtDocumento.Rows(0).Item(56)
                consultarUltimoFolio(NCDevoluciones)
            End If
        End If

    End Sub
    Private Sub consultarUltimoFolio(ByVal NCDevoluciones As NotasCreditoDevoluciones)
        Dim objUltimoFolio As New NotaCreditoDevolucionesBU
        Dim dtUltimoFolio As New DataTable
        dtUltimoFolio = objUltimoFolio.obtenerUltimoFolio(NCDevoluciones)
        If dtUltimoFolio.Rows.Count <> 0 Then
            lblSerie.Text = dtUltimoFolio.Rows(0).Item(1)
            lblFolio.Text = dtUltimoFolio.Rows(0).Item(0)
            lblSerie.Visible = True
            lblFolio.Visible = True
        End If
    End Sub
    Private Sub btnCargaDocumentos_Click(sender As Object, e As EventArgs) Handles btnCargaDocumentos.Click
        obtenerVentasCliente()
    End Sub
    Private Sub obtenerVentasCliente()
        Dim objCargaVentasNC As New VentasClienteDevolucionesForm
        Dim concepto As String = ""
        Dim factura As String = ""
        Dim agregaDev As String = ""
        Dim descuento As String = ""
        Dim saldoFac As String = ""
        Dim anio As String = ""
        Dim rfcCliente As String = ""
        Dim folio As String = ""
        Dim mp As String = ""
        Dim fp As String = ""
        If validaCamposCompletos() Then
            objCargaVentasNC.rfcClienid = lblidclienteSICY.Text
            objCargaVentasNC.concepto = CmbConcepto.Text
            If rdFactura.Checked = True Then
                objCargaVentasNC.empresaId = cmbRazonSocial.SelectedValue
                objCargaVentasNC.tipoNC = "F"
            Else
                objCargaVentasNC.empresaId = 0
                objCargaVentasNC.tipoNC = "R"
            End If
            If wvNotasCreditoCliente.Columns.Count = 0 Then
                objCargaVentasNC.facturasSeleccionadas = ""
            Else
                objCargaVentasNC.facturasSeleccionadas = obtenerFacturasSeleccionadas()
            End If
            objCargaVentasNC.ShowDialog(Me)
            dtRegistros = objCargaVentasNC.dtRegistros
            objCargaVentasNC.facturasSeleccionadas = ""
            If wvNotasCreditoCliente.RowCount > 0 Then '' VALIDA QUE TENGA INFORMACION PARA NO SER REMPLAZADA
                For x As Integer = 0 To dtRegistros.Rows.Count - 1
                    Dim FilaSiguiente As Integer = wvNotasCreditoCliente.RowCount
                    wvNotasCreditoCliente.AddNewRow()
                    concepto = dtRegistros.Rows(x).Item(0)
                    factura = dtRegistros.Rows(x).Item(2)
                    agregaDev = dtRegistros.Rows(x).Item(3)
                    descuento = dtRegistros.Rows(x).Item(5)
                    saldoFac = dtRegistros.Rows(x).Item(10)
                    anio = dtRegistros.Rows(x).Item(1)
                    rfcCliente = dtRegistros.Rows(x).Item(11)
                    folio = dtRegistros.Rows(x).Item(12)
                    mp = IsDBNull(dtRegistros.Rows(x).Item(13))
                    fp = IsDBNull(dtRegistros.Rows(x).Item(14))
                    If mp = True And fp = True Then
                        mp = ""
                        fp = ""
                    End If
                    wvNotasCreditoCliente.SetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(FilaSiguiente), "Concepto", concepto)
                    wvNotasCreditoCliente.SetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(FilaSiguiente), "Factura", factura)
                    wvNotasCreditoCliente.SetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(FilaSiguiente), "Agregar Devolucion", agregaDev)
                    wvNotasCreditoCliente.SetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(FilaSiguiente), "% Descuento", descuento)
                    wvNotasCreditoCliente.SetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(FilaSiguiente), "Saldo Factura", saldoFac)
                    wvNotasCreditoCliente.SetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(FilaSiguiente), "anio", anio)
                    wvNotasCreditoCliente.SetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(FilaSiguiente), "Rfc ClienteId", rfcCliente)
                    wvNotasCreditoCliente.SetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(FilaSiguiente), "Folio", folio)
                    wvNotasCreditoCliente.SetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(FilaSiguiente), "Metodo Pago", mp)
                    wvNotasCreditoCliente.SetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(FilaSiguiente), "Forma Pago", fp)
                Next
                tieneReg = True
            Else '' PEGA INFORMACION SIEMPRE EN LA PRIMERA FILA
                If dtRegistros.Rows.Count > 0 Then
                    grdNotasCreditoCliente.DataSource = dtRegistros
                    diseñoGridNotasCredito(wvNotasCreditoCliente)
                    metodoPago = objCargaVentasNC.metodoPago
                    formaPago = objCargaVentasNC.formaPago
                    btnGuardar.Enabled = True
                    lblguardar.Enabled = True
                    txtrazonSocialCliente.Text = objCargaVentasNC.rfcClienteEnviar
                    txtRFCCliente.Text = objCargaVentasNC.rfcCliente
                    lblrfcidcliente.Text = objCargaVentasNC.rfcClienteIdEnviar
                    inhabilitaCamposNotaCredito()
                    btnlEliminarFila.Enabled = True
                    lbleliminarfila.Enabled = True

                    Dim objBU As New NotaCreditoDevolucionesBU
                    dtSession = objBU.CrearSesionUsuario(lblidclienteSICY.Text)
                End If
            End If
        End If
    End Sub
    Private Function obtenerFacturasSeleccionadas()
        Dim numeroFilas As Integer = 0
        Dim facturasIds As String = String.Empty
        numeroFilas = wvNotasCreditoCliente.DataRowCount - 1
        For index As Integer = 0 To numeroFilas Step 1
            If index = 0 Then
                facturasIds += (wvNotasCreditoCliente.GetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(index), "Factura")).ToString()
            Else
                facturasIds += "," + (wvNotasCreditoCliente.GetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(index), "Factura")).ToString()
            End If

        Next
        Return facturasIds
    End Function
    Private Sub inhabilitaCamposNotaCredito()
        rdFactura.Enabled = False
        rdRemision.Enabled = False
        CmbConcepto.Enabled = False
        cmbRazonSocial.Enabled = False
    End Sub
    Private Function validaCamposCompletos()
        Dim camposValidados As Boolean = True
        If txtClientes.Text.Trim = "" Then
            lblCliente.ForeColor = Color.Red
            camposValidados = False
        Else
            lblCliente.ForeColor = Color.Black
        End If
        Return camposValidados
    End Function

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlAcciones.Height = 32
    End Sub
    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlAcciones.Height = 205
    End Sub
    Private Sub diseñoGridNotasCredito(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Tools.DiseñoGrid.AlternarColorEnFilas(wvNotasCreditoCliente) '' pone color a las filas del gridview
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvNotasCreditoCliente.Columns
            If col.FieldName = "Concepto" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 115
            End If

            If rdFactura.Checked = False Then
                If col.FieldName = "Factura" Then
                    col.Visible = False
                End If
            Else
                If col.FieldName = "Factura" Then
                    col.OptionsColumn.AllowEdit = False
                    col.Width = 60
                    col.Visible = True
                End If
                If col.FieldName = "Folio" Then
                    col.Visible = False
                End If
            End If

            If col.FieldName = "Agregar Devolucion" Then
                col.OptionsColumn.AllowEdit = True
                col.Width = 140
            End If
            If col.FieldName = "Cantidad" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 50
            End If
            If col.FieldName = "% Descuento" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 74
            End If
            If col.FieldName = "Precio" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 70
                col.Visible = False
            End If
            If col.FieldName = "Importe" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 70
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "{0:N2}"
            End If
            If col.FieldName = "Folio Devolucion" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 115
            End If
            If col.FieldName = "Saldo Factura" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 85
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "{0:N2}"
            End If
            If col.FieldName = "anio" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 30
                col.Visible = False
            End If
            If col.FieldName = "Rfc ClienteId" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 30
                col.Visible = False
            End If

            If rdRemision.Checked = True Then
                If col.FieldName = "Folio" Then
                    col.OptionsColumn.AllowEdit = False
                    col.Width = 30
                    col.Visible = True
                End If
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
            If col.FieldName = "Total NC" Then
                col.Visible = False
            End If
            If col.FieldName = "DetalleId" Then
                col.Visible = False
            End If
            If col.FieldName = "Iva" Then
                col.Visible = False
            End If
        Next
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvNotasCreditoCliente.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
        Grid.IndicatorWidth = 30
        agregarbotonVerDetalles() '' agrega boton en una columna en especifico dentro del gridview
    End Sub
    Private Sub agregarbotonVerDetalles()
        Dim inplaceButtonEdit As RepositoryItemButtonEdit = New RepositoryItemButtonEdit()
        inplaceButtonEdit.Buttons.Clear()
        Dim VerDetalles As EditorButton = New EditorButton(ButtonPredefines.Glyph)
        VerDetalles.Caption = "Ver"
        VerDetalles.Width = 20
        inplaceButtonEdit.Buttons.Add(VerDetalles)
        wvNotasCreditoCliente.Columns("Agregar Devolucion").ColumnEdit = inplaceButtonEdit
        wvNotasCreditoCliente.GridControl.RepositoryItems.Add(inplaceButtonEdit)
        AddHandler inplaceButtonEdit.ButtonClick, AddressOf InplaceButtonEdit_ButtonClick ''---> crea el evento click al boton dentro del grdiview
    End Sub
    Private Sub InplaceButtonEdit_ButtonClick(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)
        Dim editor As ButtonEdit = TryCast(sender, ButtonEdit)
        Dim objCargaDetalles As New DetallesDevolucionesNotasCreditoForm
        Dim remisionId = TryCast(wvNotasCreditoCliente.GetFocusedRow(), DataRowView).Row.Item(12)
        Dim rfcClienteId = TryCast(wvNotasCreditoCliente.GetFocusedRow(), DataRowView).Row.Item(11)
        Dim anio = TryCast(wvNotasCreditoCliente.GetFocusedRow(), DataRowView).Row.Item(1)
        Dim saldoFactura = TryCast(wvNotasCreditoCliente.GetFocusedRow(), DataRowView).Row.Item(10)
        Dim factura = TryCast(wvNotasCreditoCliente.GetFocusedRow(), DataRowView).Row.Item(2)
        Dim cantidad = TryCast(wvNotasCreditoCliente.GetFocusedRow(), DataRowView).Row.Item(4)
        Dim importe = TryCast(wvNotasCreditoCliente.GetFocusedRow(), DataRowView).Row.Item(7)
        Dim foliosDev = TryCast(wvNotasCreditoCliente.GetFocusedRow(), DataRowView).Row.Item(8)
        Dim detalleEliminar = TryCast(wvNotasCreditoCliente.GetFocusedRow(), DataRowView).Row.Item(16)
        Dim totalNc = TryCast(wvNotasCreditoCliente.GetFocusedRow(), DataRowView).Row.Item("Total NC")
        Dim ResumenIva = TryCast(wvNotasCreditoCliente.GetFocusedRow(), DataRowView).Row.Item("Iva")
        Dim sumaCatidadDetalles As Integer = 0
        Dim totalDetalles As Decimal = 0.00
        Dim foliosSeleccionadosDetalles As String = String.Empty
        Dim ivaTotal As Decimal = 0.00
        Dim SumaTotal As Decimal = 0.00
        Dim sumaSubtotal As Decimal = 0.00
        Dim sumaIva As Decimal = 0.00
        Dim porcentajes As String = String.Empty
        Dim productoEstilo As String = String.Empty
        Dim precioUnitario As String = String.Empty
        Dim paresAplicados As String = String.Empty
        Dim totalPrecios_Subtotal As Decimal = 0.00
        Dim subtotalDetallesNc As Decimal = 0.00
        Dim importeNC As Decimal = 0.00
        Dim total As Decimal = 0.00
        Dim Confirmar As New ConfirmarForm
        Dim cantidadVacia As Boolean
        Dim mismaFilas As Boolean = False
        Dim IVA As String = String.Empty

        Dim file = wvNotasCreditoCliente.FocusedRowHandle
        objCargaDetalles.remisionId = remisionId
        objCargaDetalles.rfcClienteId = rfcClienteId
        objCargaDetalles.anio = anio
        objCargaDetalles.idempresa = lblidempresa.Text
        objCargaDetalles.idCliente = lblidCliente.Text
        objCargaDetalles.totalSaldoFactura = saldoFactura
        objCargaDetalles.factura = factura
        objCargaDetalles.tieneReg = tieneReg

        If rdFactura.Checked = True Then
            objCargaDetalles.tipoNC = "F"
        Else
            objCargaDetalles.tipoNC = "R"
        End If

        If IsDBNull(cantidad) Then
            cantidadVacia = 0
        Else
            cantidadVacia = 1
        End If

        If cantidadVacia = True Then
            Confirmar.mensaje = "Se va a sustituir la información que anteriormente se seleccionó ¿desea continuar?"
            mismaFilas = True
        End If

        If cantidadVacia = True And IsDBNull(cantidad) Or Not IsDBNull(cantidad) Or Not IsDBNull(totalNc) Then
            If cantidad > 0 Then
                If Confirmar.ShowDialog() = DialogResult.OK Then
                    objCargaDetalles.dtsesionId = dtSession.Rows(0).Item(0)
                    objCargaDetalles.seleccionMismaFila = mismaFilas
                    objCargaDetalles.detallesBuscar = detalleEliminar
                    objCargaDetalles.tieneReg = False
                    objCargaDetalles.actualizarDatosSession = True '' identificar si las cantidades se van a editar
                    objCargaDetalles.ShowDialog(Me)
                    mismaFilas = False
                End If
            End If
        Else
            objCargaDetalles.dtsesionId = dtSession.Rows(0).Item(0)
            objCargaDetalles.tieneReg = tieneReg
            objCargaDetalles.actualizarDatosSession = False
            objCargaDetalles.ShowDialog(Me)
        End If

        Dim objBU As New NotaCreditoDevolucionesBU
        Dim dtDetallesSesion As New DataTable
        Dim dtSumatorias As New DataTable
        Dim doc As String = factura
        Dim dtSubtotal As Decimal = 0.00
        Dim dtIva As Decimal = 0.00
        Dim dtTotal As Decimal = 0.00

        If objCargaDetalles.clickCancelar <> True Then
            dtDetallesSesion = objBU.consultarDetallesSessionUsuario(objCargaDetalles.dtsesionId, doc)
            dtSumatorias = objBU.consultarDetallesSessionUsuario(objCargaDetalles.dtsesionId, "")
            If dtDetallesSesion.Rows.Count > 0 And dtDetallesSesion.Rows(0).Item(0) <> 0 And dtDetallesSesion.Rows(0).Item(1) <> 0.00 Then
                TerminaCompletarInformacionNotaCredito(dtDetallesSesion.Rows(0).Item("pares"), dtDetallesSesion.Rows(0).Item("importe"), dtDetallesSesion.Rows(0).Item("FolioDev"), dtDetallesSesion.Rows(0).Item("TotalNC"), file, dtDetallesSesion.Rows(0).Item("detallesIds"), dtDetallesSesion.Rows(0).Item("Iva"))
            Else
                If dtDetallesSesion.Rows(0).Item(0) = 0 Then
                    wvNotasCreditoCliente.DeleteRow(wvNotasCreditoCliente.FocusedRowHandle)
                End If
            End If

            dtSubtotal = dtSumatorias.Rows(0).Item(0)
            dtIva = dtSumatorias.Rows(0).Item(2)
            dtTotal = dtSubtotal + dtIva

            lblTSubtotal.Text = "$" & " " & Format(dtSubtotal, "##,##0.00")
            lblTSubtotal.Visible = True
            lblTIva.Text = "$" & " " & Format(dtIva, "##,##0.00")
            lblTIva.Visible = True
            lblTTotal.Text = "$" & " " & Format(dtTotal, "##,##0.00")
            lblTTotal.Visible = True
        End If
        objCargaDetalles.clickCancelar = False
    End Sub
    Private Sub wvNotasCreditoCliente_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles wvNotasCreditoCliente.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub TerminaCompletarInformacionNotaCredito(ByVal sumaTotalCantidad As Integer, ByVal totalDetalles As Decimal, ByVal foliosSeleccionados As String, ByVal TOTAL As String, ByVal fila As Integer, ByVal detalleid As String, ByVal IVA As String)
        wvNotasCreditoCliente.SetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(fila), "Cantidad", sumaTotalCantidad)
        wvNotasCreditoCliente.SetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(fila), "Importe", totalDetalles)
        wvNotasCreditoCliente.SetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(fila), "Folio Devolucion", foliosSeleccionados)
        wvNotasCreditoCliente.SetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(fila), "Total NC", TOTAL)
        wvNotasCreditoCliente.SetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(fila), "DetalleId", detalleid)
        wvNotasCreditoCliente.SetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(fila), "Iva", IVA)
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        guardarInformacionNC()
    End Sub
    Private Sub guardarInformacionNC()
        Dim objBU As New NotaCreditoDevolucionesBU
        If validarCamposCompletosGridView() Then
            InsertarInformacionNotaCredito()
            Me.Close()
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Falta Información por llenar, favor de revisar.")
        End If
    End Sub
    Private Function validarCamposCompletosGridView()
        Dim valida As Boolean = True
        For index As Integer = 0 To wvNotasCreditoCliente.DataRowCount - 1
            If IsDBNull(wvNotasCreditoCliente.GetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(index), "Cantidad")) And
                IsDBNull(wvNotasCreditoCliente.GetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(index), "Importe")) And
                IsDBNull(wvNotasCreditoCliente.GetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(index), "Folio Devolucion")) Then
                valida = False
                Exit For
            End If
        Next
        Return valida
    End Function
    Private Function validaInformacionExistenteAntesCerrar()
        Dim registros As Boolean = False
        Dim valida = False
        Dim numeroFilas As Integer = wvNotasCreditoCliente.DataRowCount - 1
        For x As Integer = 0 To numeroFilas
            If IsDBNull(wvNotasCreditoCliente.GetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(x), "Cantidad")) And
               IsDBNull(wvNotasCreditoCliente.GetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(x), "Importe")) And
               IsDBNull(wvNotasCreditoCliente.GetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(x), "Folio Devolucion")) Then
                valida = False
            Else
                valida = True
                Exit For
            End If
        Next
        Return valida
    End Function

    Private Sub InsertarInformacionNotaCredito()
        Dim objInsertaEncabezado As New NotaCreditoDevolucionesBU
        Dim nc As New NotasCreditoDevoluciones
        Dim dtInsercionEncabezado As DataTable
        Dim notaCreditoId As Integer = 0
        Dim rfcClienteIdEnviar As New VentasClienteDevolucionesForm
        Dim Confirmar As New ConfirmarForm
        Try
            Confirmar.mensaje = "¿Desea generar la nota de crédito?"
            If Confirmar.ShowDialog() = DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                If rdFactura.Checked = True Then
                    nc.NotaCreditoTipo = "F"
                Else
                    nc.NotaCreditoTipo = "R"
                End If
                nc.NotaCreditoRazSocialId = lblidempresa.Text
                ' nc.NotaCreditoRazSocialId = 19 '' ------- PRUEBA
                nc.NotaCreditoConcepto = CmbConcepto.Text
                nc.NotaCreditoClienteId = lblidCliente.Text
                nc.NotaCreditoRFCCliente = txtrazonSocialCliente.Text
                nc.NotaCreditoDescuento = 0
                nc.NotaCreditoRFCClienteId = lblrfcidcliente.Text
                nc.NotaCreditoClienteId_SICY = lbl_cliente_sicy.Text
                If nc.NotaCreditoTipo = "F" Then
                    nc.NotaCreditoSubtotal = lblTSubtotal.Text
                    nc.NotaCreditoIvaTotal = lblTIva.Text
                    nc.NotaCreditoTotal = lblTTotal.Text
                Else
                    nc.NotaCreditoSubtotal = lblTSubtotal.Text
                    nc.NotaCreditoIvaTotal = 0.00
                    nc.NotaCreditoTotal = lblTSubtotal.Text
                End If
                ' nc.NotaCreditoTextoConcepto = TxtConcepto.Text

                If nc.NotaCreditoTipo = "F" Then
                    nc.NotaCreditoEstatus = "POR TIMBRAR"
                Else
                    nc.NotaCreditoEstatus = ""
                End If
                If nc.NotaCreditoTipo = "F" Then
                    nc.NotaCreditoFormaPago = formaPago
                    nc.NotaCreditoMetodoPago = metodoPago
                Else
                    nc.NotaCreditoFormaPago = ""
                    nc.NotaCreditoMetodoPago = ""
                End If
                nc.NotaCreditoMonedaId = cmbMoneda.SelectedValue
                dtInsercionEncabezado = objInsertaEncabezado.insertaEncabezadoNotaCredito(nc)
                If dtInsercionEncabezado.Rows.Count > 0 Then
                    If dtInsercionEncabezado.Rows(0).Item(1) = "Registros Insertados Correctamente" Then
                        notaCreditoId = dtInsercionEncabezado.Rows(0).Item(0)
                        InsertaDetallesNotaCredito(notaCreditoId, nc.NotaCreditoTipo, dtSession.Rows(0).Item(0))
                        generarFacturaCFDI(notaCreditoId) ''TIMBRADO                       
                        'Me.Dispose()
                    End If
                End If
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
        End Try

    End Sub
    Private Sub InsertaDetallesNotaCredito(ByVal notaCreditoId As Integer, ByVal TIPOnc As String, ByVal sessionId As Integer)
        Dim objDetalles As New NotasCreditoDevoluciones
        Dim detalles As New NotaCreditoDevolucionesBU
        Dim dtdetallesNC As New DataTable
        Dim numeroFilas As Integer = dtRegDetalles.Rows.Count
        Dim fecha As Date = dtpFechaInicio.Text
        Dim anio = fecha.Year
        Dim total As Decimal = 0.00
        Dim iva As Decimal = 0.00
        Dim subtotal As Decimal = 0.00

        dtdetallesNC = detalles.obtenerDetallesSesionesDevoluciones(sessionId)
        If dtdetallesNC.Rows.Count > 0 Then
            Dim vXmlCeldasDetalles As XElement = New XElement("Celdas")
            For Each row As DataRow In dtdetallesNC.Rows
                Dim vNodo As XElement = New XElement("Celda")
                vNodo.Add(New XAttribute("notacreditoId", notaCreditoId))
                vNodo.Add(New XAttribute("folioDevolucion", row.Item("FolioDev").ToString()))
                vNodo.Add(New XAttribute("factura", row.Item("Factura").ToString()))
                vNodo.Add(New XAttribute("documentoId", row.Item("documentoId").ToString()))
                vNodo.Add(New XAttribute("descripcion", row.Item("Descripcion").ToString()))
                vNodo.Add(New XAttribute("anio", row.Item("anio").ToString()))
                vNodo.Add(New XAttribute("conceptoId", 53))
                vNodo.Add(New XAttribute("porcentaje", row.Item("Porcentaje").ToString()))
                vNodo.Add(New XAttribute("cantidad", row.Item("ParesAplicar").ToString()))
                vNodo.Add(New XAttribute("precioUnitario", row.Item("PrecioUnit").ToString()))
                vNodo.Add(New XAttribute("importe", row.Item("ImporteTotalNC").ToString()))
                vNodo.Add(New XAttribute("subtotal", row.Item("ImporteTotalNC").ToString()))
                If TIPOnc = "F" Then
                    vNodo.Add(New XAttribute("iva", row.Item("Iva").ToString()))
                Else
                    vNodo.Add(New XAttribute("iva", "0.00"))
                End If
                subtotal = row.Item("ImporteTotalNC").ToString()
                iva = row.Item("Iva").ToString()
                total = subtotal + iva
                vNodo.Add(New XAttribute("total", total))
                vNodo.Add(New XAttribute("observaciones", ""))
                vNodo.Add(New XAttribute("unidad", "PARES"))
                vNodo.Add(New XAttribute("productoestiloid", row.Item("Producto Estilo").ToString()))
                vNodo.Add(New XAttribute("detalledevolucionId", row.Item("DetalleDevolucionId").ToString()))
                vXmlCeldasDetalles.Add(vNodo)
            Next
            detalles.insertaDetallesNotaCredito(vXmlCeldasDetalles.ToString())
        End If
    End Sub
    Private Sub generarFacturaCFDI(ByVal notaCreditoId As Integer)
        Dim objInsertaFactura As New NotaCreditoDevolucionesBU
        Dim nc As New NotasCreditoDevoluciones
        Dim dtFactura As New DataTable

        Dim fecha As Date = dtpFechaInicio.Text
        Dim facturaId As Integer = 0
        Dim mensaje As String = String.Empty
        Dim dtResultado As New DataTable
        Dim dtparesAplicar As DataTable
        Dim timbradas As Boolean = False
        Dim errorMsg As String = String.Empty
        Dim strResultado As String
        If rdFactura.Checked = True Then
            nc.NotaCreditoTipo = "F"
        Else
            nc.NotaCreditoTipo = "R"
        End If
        nc.NotaCreditoId = notaCreditoId
        nc.NotaCreditoAnio = fecha.Year
        nc.NotaCreditoRazSocialId = lblidempresa.Text
        'nc.NotaCreditoRazSocialId = 19
        nc.NotaCreditoClienteId = lblidCliente.Text
        nc.NotaCreditoRFCClienteId = lblrfcidcliente.Text
        nc.NotaCreditoRFCCliente = txtrazonSocialCliente.Text
        nc.NotaCreditoSubtotal = lblTSubtotal.Text
        nc.NotaCreditoIvaTotal = lblTIva.Text
        nc.NotaCreditoTotal = lblTTotal.Text
        If nc.NotaCreditoTipo = "F" Then
            nc.NotaCreditoFormaPago = formaPago
            nc.NotaCreditoMetodoPago = metodoPago
        Else
            nc.NotaCreditoFormaPago = ""
            nc.NotaCreditoMetodoPago = ""
        End If
        nc.NotaCreditoMonedaId = cmbMoneda.SelectedValue
        nc.NotaCreditoDescuento = 0.00
        nc.NotaCreditoCliente = txtClientes.Text.Trim
        nc.NotaCreditoRFCCliente = txtrazonSocialCliente.Text
        For i As Integer = 0 To wvNotasCreditoCliente.RowCount - 1
            nc.NotaCreditoParesFacturados += CInt(wvNotasCreditoCliente.GetRowCellValue(i, "Cantidad").ToString())
        Next
        dtFactura = objInsertaFactura.InsertarFacturarNotaCredito(nc)
        If dtFactura.Rows.Count > 0 Then
            mensaje = dtFactura.Rows(0).Item(1)
            If mensaje = "Exito" Then
                facturaId = dtFactura.Rows(0).Item(0)
                insertaDetallesFacturaNotaCredito(facturaId, nc.NotaCreditoTipo, dtSession.Rows(0).Item(0))
                If nc.NotaCreditoTipo = "F" Then
                    dtResultado = objInsertaFactura.generaInformacionTimbrado(nc) '' GENERA INFORMACION PARA EL TIMBRADO
                    If dtResultado.Rows(0).Item(0) = "EXITO" Then
                        strResultado = TimbrarFacturasNotasCredito(nc) '' timbra la facura
                        If strResultado.Equals("EXITO") Then
                            dtparesAplicar = objInsertaFactura.obtenerDetallesSesionesDevoluciones(dtSession.Rows(0).Item(0))
                            If dtparesAplicar.Rows.Count > 0 Then '' aplica los pares
                                For aw As Integer = 0 To dtparesAplicar.Rows.Count - 1
                                    objInsertaFactura.ActualizaParAplicado(dtparesAplicar.Rows(aw).Item(2), dtparesAplicar.Rows(aw).Item(1), dtparesAplicar.Rows(aw).Item(5), dtparesAplicar.Rows(aw).Item(12))
                                Next
                            End If
                            objInsertaFactura.replicaNotasCreditoSay_Sicy(nc) '' REPLICA INFORMACION A SICY
                            objInsertaFactura.EliminarSesionUsuario(lblidclienteSICY.Text, dtSession.Rows(0).Item(0))
                            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "La nota de credito se generó correctamente.")
                            limpiarFormularioNotaCredito()
                            idNotaCreditoGenerado = notaCreditoId
                            'ActualizaSaldoFactura() '' ACTUALIZA EL SALDO DE LA FACTURA
                        Else
                            errorMsg = errorMsg & "No se pudo timbrar la nota de crédito "
                        End If
                    Else
                        errorMsg = errorMsg & "DoctoId: " & nc.NotaCreditoId.ToString() & "- Al generar información para timbrar." '& strResultado & vbCrLf
                    End If
                Else
                    objInsertaFactura.EliminarSesionUsuario(lblidclienteSICY.Text, dtSession.Rows(0).Item(0))
                    limpiarFormularioNotaCredito()
                    'ActualizaSaldoFactura() '' REMISIONES TAMBIEN ACTUALIZA EL SALDO DE LA FACTURA
                End If
            End If
        End If
    End Sub
    Private Sub insertaDetallesFacturaNotaCredito(ByVal facturaId As Integer, ByVal TIPOnc As String, ByVal sessionId As Integer)
        Dim objDetallesFactura As New NotasCreditoDevoluciones
        Dim detallesFactura As New NotaCreditoDevolucionesBU
        Dim dtdetallesFacturaNC As New DataTable
        Dim numeroFilas As Integer = dtRegDetalles.Rows.Count
        Dim subtotal As Decimal = 0.00
        Dim iva As Decimal = 0.00
        Dim total As Decimal = 0.00

        dtdetallesFacturaNC = detallesFactura.obtenerDetallesSesionesDevoluciones(sessionId)
        If dtdetallesFacturaNC.Rows.Count > 0 Then
            Dim vXmlCeldasDetallesFactura As XElement = New XElement("Celdas")
            For Each row As DataRow In dtdetallesFacturaNC.Rows
                Dim vNodo As XElement = New XElement("Celda")
                vNodo.Add(New XAttribute("documentoId", facturaId))
                vNodo.Add(New XAttribute("productoEstiloId", row.Item("Producto Estilo").ToString()))
                vNodo.Add(New XAttribute("clavesat", row.Item("Clave Sat").ToString()))
                vNodo.Add(New XAttribute("descripcion", row.Item("Descripcion").ToString()))
                vNodo.Add(New XAttribute("paresfacturados", row.Item("ParesAplicar").ToString()))
                vNodo.Add(New XAttribute("claveunidad", "PR"))
                vNodo.Add(New XAttribute("precio", row.Item("PrecioUnit").ToString()))
                vNodo.Add(New XAttribute("descuento", 0.00))
                vNodo.Add(New XAttribute("impuesto", "002"))
                vNodo.Add(New XAttribute("tipofactor", "Tasa"))
                vNodo.Add(New XAttribute("tasacuota", "0.160000"))
                vNodo.Add(New XAttribute("importe", row.Item("ImporteTotalNC").ToString()))
                vNodo.Add(New XAttribute("base", row.Item("ImporteTotalNC").ToString()))
                vNodo.Add(New XAttribute("subtotal", row.Item("ImporteTotalNC").ToString()))
                If TIPOnc = "F" Then
                    vNodo.Add(New XAttribute("iva", row.Item("Iva").ToString()))
                Else
                    vNodo.Add(New XAttribute("iva", 0.00))
                End If
                subtotal = row.Item("ImporteTotalNC").ToString()
                iva = row.Item("Iva").ToString()
                total = subtotal + iva
                vNodo.Add(New XAttribute("total", total))
                vNodo.Add(New XAttribute("foliodevolucion", row.Item("FolioDev").ToString()))
                vNodo.Add(New XAttribute("facturasNC", row.Item("Factura").ToString()))
                vXmlCeldasDetallesFactura.Add(vNodo)
            Next
            detallesFactura.insertaDetallesFacturaNotaCredito(vXmlCeldasDetallesFactura.ToString())
        End If
    End Sub
    Private Sub wvNotasCreditoCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles wvNotasCreditoCliente.KeyDown
        If (e.KeyCode = Keys.Delete) Then
            eliminaFilaSeleccionada()
        End If
    End Sub
    Private Sub ActualizaSaldoFactura()
        Dim objNotaCredito As New NotasCreditoDevoluciones
        Dim objactualiza As New NotaCreditoDevolucionesBU
        For i As Integer = 0 To wvNotasCreditoCliente.RowCount - 1
            objNotaCredito.NotaCreditoSaldoFactura = (wvNotasCreditoCliente.GetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(i), "Saldo Factura"))
            'objNotaCredito.NotaCreditoRFCClienteId = cmbRFCCliente.SelectedValue
            objNotaCredito.NotaCreditoAnio = (wvNotasCreditoCliente.GetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(i), "anio"))
            objNotaCredito.NotaCreditoRemisionId = (wvNotasCreditoCliente.GetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(i), "Folio"))
            objNotaCredito.NotaCreditoImporte = (wvNotasCreditoCliente.GetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(i), "Total NC"))
            objactualiza.actualizaSaldoFactura(objNotaCredito)
        Next
    End Sub
    Private Function TimbrarFacturasNotasCredito(ByVal notaCredito As NotasCreditoDevoluciones) As String
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String '' = IIf(local, ServidorRestPruebas, ServidorRest)
        ' Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        'Dim objUtilerias As New TransferenciaFTP("ftp://192.168.2.4", "ftpaccess", "Yuyin2017""")
        Dim resultado As String = String.Empty
        'Rutas
        Dim RutaRest As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim tipoComprbante = "NOTACREDITODEVOLUCION"
        Dim rutaXMLEnviar As String = String.Empty
        Dim mes As String = ""
        Dim anio As String = ""

        ' "&EmpresaID=19" & notaCredito.NotaCreditoRazSocialId &
        'Servidor = "http://localhost:7639/"
        Servidor = "http://192.168.2.4:8037/"
        llamarServicio.url = Servidor & "NotasCreditoDevoluciones/Timbrado" &
                            "?DocumentoID=" & notaCredito.NotaCreditoId &
                            "&EmpresaID=19" &
                            "&TipoComprobante=" & tipoComprbante &
                            "&TimbradoPrueba=" & pruebas.ToString
        llamarServicio.metodo = "GET"
        Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

        If Respuesta.respuesta = 1 Then
            RutaRest = Respuesta.mensaje(0)
            RutaServidorSICY = Respuesta.mensaje(1)
            RutaCliente = Respuesta.mensaje(2)

            'mes = Month(Now)
            'anio = Year(Now)

            'If notaCredito.NotaCreditoRazSocialId = 19 Then
            '    objUtilerias.EnviarArchivo("inetpub\wwwroot\ftpNotascreditodevoluciones\EMPRESAPRUEBAS\XML\0" + mes + anio, RutaRest)
            '    'objUtilerias.EnviarArchivo(RutaCliente, RutaRest)

            'End If

            'objUtilerias.CrearDirectorio(RutaCliente)
            'objUtilerias.CrearDirectorio(RutaServidorSICY)
            'objUtilerias.CopiarArchivoSICY(RutaRest, RutaServidorSICY, RutaCliente, True) ''pruebas)
            'rutaXMLEnviar = RutaServidorSICY
            'rutaXMLEnviar = RutaRest
            GenerarPDF(notaCredito.NotaCreditoId, rutaXMLEnviar, notaCredito.NotaCreditoRazSocialId)
            resultado = "EXITO"
        Else
            resultado = Respuesta.aviso & "(" & notaCredito.NotaCreditoId.ToString & ")"
            Try
                'Dim objBUAdmon As New AdmonDoctosComprasPT_BU
                'objBUAdmon.ActualizarMtvoSinTimbrarFacturaPIDocumento(documentoId, resultado)
            Catch ex As Exception
            End Try
        End If

        Return resultado
    End Function

    Private Sub GenerarPDF(ByVal documentoId As Integer, ByVal rutaXMLEnviar As String, ByVal empresaId As Integer)
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String ''= IIf(local, ServidorRestPruebas, ServidorRest)
        ' Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        'Dim objUtilerias As New TransferenciaFTP
        'Rutas
        Dim RutaRest As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim objCorreoEnviar As New NotaCreditoDevolucionesBU
        Dim dtCorreoEnviar As New DataTable
        Dim tipoComprbante = "NOTACREDITODEVOLUCION"
        'Dim mes As String = ""
        ' Dim anio As String = ""

        ' Servidor = "http://localhost:7639/"
        Servidor = "http://192.168.2.4:8037/"
        llamarServicio.url = Servidor & "NotasCreditoDevoluciones/GeneraPDF" &
                            "?DocumentoID=" & documentoId &
                            "&TipoComprobante=" & tipoComprbante &
                             "&bPruebas=" & pruebas.ToString
        llamarServicio.metodo = "GET"
        Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

        If Respuesta.respuesta = 1 Then
            RutaRest = Respuesta.mensaje(0)
            RutaServidorSICY = Respuesta.mensaje(1)
            RutaCliente = Respuesta.mensaje(2)

            'objUtilerias.EnviarArchivo("NOTACREDITODEVOLUCIONES33",)
            'objUtilerias.CrearDirectorio(RutaCliente)
            'objUtilerias.CrearDirectorio(RutaServidorSICY)
            'objUtilerias.CopiarArchivoSICY(RutaRest, RutaServidorSICY, RutaCliente, True) ''local ---> true es prueba)

            'mes = Month(Now)
            'anio = Year(Now)

            'If empresaId = 19 Then
            '    'objUtilerias.EnviarArchivo("bin/TASFE/EMPRESAPRUEBAS/NOTACREDITODEVOLUCIONES33/PDF/0" + mes + anio, RutaRest)
            '    objUtilerias.EnviarArchivo("C:\inetpub\wwwroot\ftpNotascreditodevoluciones\EMPRESAPRUEBAS\XML" + mes + anio, RutaRest)
            'End If

            dtCorreoEnviar = objCorreoEnviar.consultarCorreoFacturacionEnviar(documentoId)
            If dtCorreoEnviar.Rows.Count > 0 And dtCorreoEnviar.Rows(0).Item(0) <> "" Then
                'enviarCorreoNotasCreditoDevolucion(documentoId, dtCorreoEnviar.Rows(0).Item(0), rutaXMLEnviar, RutaServidorSICY) '' envia correo automaticamente
            End If
        End If
    End Sub
    Private Function enviarCorreoNotasCreditoDevolucion(ByVal documentoId As Integer, CorreosDestinatario As String, rutaArchivoXML As String, rutaArchivoPDF As String) As Boolean
        Dim enviosCorreoBU As New EnviosCorreoBU
        Dim notacredito As New NotasCreditoDevoluciones
        Dim dtResultadoDatosCorreos As New DataTable
        Dim remitente As String = String.Empty
        Dim correo As New Tools.Correo
        Dim cadenaCorreo As String = String.Empty
        Dim asuntoCorreo As String = String.Empty
        Dim entCorreo As New Entidades.DatosCorreo
        Dim objBU As New NotaCreditoDevolucionesBU
        Dim lstArchivoAdjuntos As New List(Of System.Net.Mail.Attachment)
        Dim archivoAdjunto As System.Net.Mail.Attachment
        Dim CorreoEnviado As String = String.Empty
        Dim StatusCorreo As Boolean = False
        Cursor = Cursors.WaitCursor

        Try
            dtResultadoDatosCorreos = objBU.consultarCorreosRemitentes
            remitente = dtResultadoDatosCorreos.Rows(0).Item(0).ToString()
            If rutaArchivoPDF <> String.Empty Then
                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoPDF)
                lstArchivoAdjuntos.Add(archivoAdjunto)
            End If

            If rutaArchivoXML <> String.Empty Then
                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoXML)
                lstArchivoAdjuntos.Add(archivoAdjunto)
            End If
            asuntoCorreo = "Asunto: CFDI de Nota de Credito"
            cadenaCorreo = "<html> " +
                           " <head>" +
                           " </head>"
            cadenaCorreo += " <body> "
            cadenaCorreo += " <br><p>Estimado Cliente: Anexo encontrará su CFDI de recibo de Nota de Crédito en formato PDF y XML.</p>"
            'cadenaCorreo += " <p> Le sugerimos tomar en cuenta las siguientes consideraciones en cuanto a cancelaciones:<br>"
            'cadenaCorreo += " <ol>" +
            '                "<li> Cualquier cambio en el recibo de pago, en caso de que este proceda se realizará Únicamente dentro de los primeros 7 días posteriores a la expedición del comprobante; pasando este lapso de días no se harán cambios.</li>" +
            '                "<li> No Procederá la cancelación de un CFDI de recibo de pago (CRP) que se haya facturado conforme a los datos proporcionados por usted mismo. </li>" +
            '                "<li> Los documentos relacionados que se tomarán en cuenta para realizar el CFDI de pago son aquellos que usted nos proporcionó en la notificación de pago, de no recibir la notificación el pago se aplicará a los CFDI pendientes de pago más antiguos de acuerdo a lo estipulado en la regla 2.7.1.35 de la RMF.</li>" +
            '                "<li> El recibo de pago (CRP) fue emitido solo con los datos obligatorios que actualmente se encuentran regulados por el SAT (Guía de llenado del ""Complemento para recepción de Pagos"") . Por lo tanto en el recibo no verán reflejados los datos bancarios (NumOperacion, RfcEmisorCtaOrd, CtaOrdenante, RfcEmisorCtaBen, CtaBeneficiario, TipoCadPago, CertPago, CadPago, SelloPago)</li>" +
            '                "</ol>" +
            '                "</p>"
            cadenaCorreo += " <p> Atentamente: Grupo Yuyin </p>"
            cadenaCorreo += " </body> " +
                            " </html> "
            CorreosDestinatario = "ddesarrollo.ti@grupoyuyin.com.mx,ge_proyectos@villagonti.com"
            If lstArchivoAdjuntos.Count > 0 Then
                entCorreo = correo.EnviarCorreoFacturasHtmlVariosArchivosAdjuntos(CorreosDestinatario, remitente, asuntoCorreo, cadenaCorreo, lstArchivoAdjuntos)
                If entCorreo.CorreoEnviado = True Then
                    CorreoEnviado = "SI"
                    StatusCorreo = True
                Else
                    CorreoEnviado = "NO"
                    StatusCorreo = False
                End If
                objBU.actualizaEstadoEnviosCorreos(documentoId)
                objBU.registraBitacoraEnvioCorreos(documentoId, CorreoEnviado)
            End If

        Catch ex As Exception
            StatusCorreo = False
        End Try

        Return StatusCorreo

        Cursor = Cursors.Default
    End Function
    Private Sub NotasCreditoDevolucionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            obtenerClientes()
        End If
        If e.KeyCode = Keys.F3 Then
            obtenerVentasCliente()
        End If
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub
    Private Sub obtenerClientes()
        Dim frmClientes As New MuestrarioClientesform
        Dim dtIdCliente As New NotaCreditoDevolucionesBU
        Dim dtId As New DataTable
        If rdFactura.Checked = True Then '' seleccion tipo factura
            If CmbConcepto.Text <> "" Then '' seleccion concepto
                If cmbRazonSocial.Text <> "" Then '' seleccion de razon social
                    frmClientes.razonSocialId = cmbRazonSocial.SelectedValue
                    If rdFactura.Checked = True Then
                        frmClientes.tipoNC = "F"
                    Else
                        frmClientes.tipoNC = "R"
                    End If
                    txtClientes.Text = ""
                    If txtClientes.Text <> "" Then
                        dtIdCliente.EliminarSesionUsuario(lblidclienteSICY.Text, dtSession.Rows(0).Item(0))
                        limpiarFormularioNotaCredito()
                    End If
                    frmClientes.ShowDialog()
                    Dim dtResultado = dtIdCliente.ConsultaSesionUsuario(frmClientes.clienteidSAY) ''consulta la session del cliente
                    If dtResultado.Rows.Count = 0 Then
                        txtClientes.Text = frmClientes.nombreCliente
                        lblidclienteSICY.Text = frmClientes.clienteidSAY
                        NCDevoluciones.NotaCreditoCliente = txtClientes.Text
                        lbl_cliente_sicy.Text = frmClientes.clienteIdSICY
                        dtId = dtIdCliente.obtenerIdCliente(NCDevoluciones)
                        If dtId.Rows.Count > 0 Then
                            lblidCliente.Text = dtId.Rows(0).Item(0)
                            consultarDescuentoCXC()
                        End If
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El cliente: " + frmClientes.nombreCliente + " ya esta siendo ocupando por el usuario: " + dtResultado(0)("USUARIO"))
                    End If
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Falta seleccionar una razón social.")
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Falta seleccionar el tipo de concepto.")
            End If
        Else
            If CmbConcepto.Text <> "" Then '' seleccion concepto
                frmClientes.razonSocialId = 0
                frmClientes.tipoNC = "R"
                frmClientes.ShowDialog()
                lblidclienteSICY.Text = frmClientes.clienteidSAY
                txtClientes.Text = frmClientes.nombreCliente
                NCDevoluciones.NotaCreditoCliente = txtClientes.Text
                dtId = dtIdCliente.obtenerIdCliente(NCDevoluciones)
                If dtId.Rows.Count > 0 Then
                    lblidCliente.Text = dtId.Rows(0).Item(0)
                    consultarDescuentoCXC()
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Falta seleccionar el tipo de concepto.")
            End If
        End If
    End Sub

    Private Sub btnlEliminarFila_Click(sender As Object, e As EventArgs) Handles btnlEliminarFila.Click
        eliminaFilaSeleccionada()
    End Sub
    Private Sub eliminaFilaSeleccionada()
        Dim fila = wvNotasCreditoCliente.FocusedRowHandle
        Dim objElimnarFila As New NotaCreditoDevolucionesBU
        Dim dtTable As New DataTable
        Dim dtSumatorias As New DataTable
        Dim detalleEliminar As String = String.Empty
        Dim tieneDetalles
        Dim detalleId As String = String.Empty
        Dim separador
        Dim dtSubtotal As Decimal = 0.00
        Dim dtIva As Decimal = 0.00
        Dim dtTotal As Decimal = 0.00
        Dim factura As String = String.Empty
        Dim tipo As String = String.Empty
        Dim documentoId As Integer

        If wvNotasCreditoCliente.RowCount > 0 Then
            tieneDetalles = IsDBNull(wvNotasCreditoCliente.GetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(fila), "DetalleId"))
            factura = IsDBNull(wvNotasCreditoCliente.GetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(fila), "Factura"))
            If rdFactura.Checked = True Then
                tipo = "F"
            Else
                tipo = "R"
                documentoId = IsDBNull(wvNotasCreditoCliente.GetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(fila), "Folio"))
            End If

            If tieneDetalles = False And factura = False Then
                detalleEliminar = (wvNotasCreditoCliente.GetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(fila), "DetalleId"))
                factura = (wvNotasCreditoCliente.GetRowCellValue(wvNotasCreditoCliente.GetVisibleRowHandle(fila), "Factura"))
                separador = Split(detalleEliminar, ",")
                For x = 0 To UBound(separador)
                    detalleId = Replace(separador(x), " ", "")
                    If tipo = "F" Then
                        objElimnarFila.eliminarFilaDetalleDevolucion(dtSession.Rows(0).Item(0), detalleId, factura, tipo, 0)
                    Else
                        objElimnarFila.eliminarFilaDetalleDevolucion(dtSession.Rows(0).Item(0), detalleId, "", tipo, documentoId)
                    End If
                Next
                wvNotasCreditoCliente.DeleteRow(wvNotasCreditoCliente.FocusedRowHandle)
                dtSumatorias = objElimnarFila.consultarDetallesSessionUsuario(dtSession.Rows(0).Item(0), "")
                dtSubtotal = dtSumatorias.Rows(0).Item(0)
                dtIva = dtSumatorias.Rows(0).Item(2)
                dtTotal = dtSubtotal + dtIva

                lblTSubtotal.Text = "$" & " " & Format(dtSubtotal, "##,##0.00")
                lblTSubtotal.Visible = True
                lblTIva.Text = "$" & " " & Format(dtIva, "##,##0.00")
                lblTIva.Visible = True
                lblTTotal.Text = "$" & " " & Format(dtTotal, "##,##0.00")
                lblTTotal.Visible = True
            Else
                wvNotasCreditoCliente.DeleteRow(wvNotasCreditoCliente.FocusedRowHandle)
            End If
        End If
    End Sub
    Private Sub NotasCreditoDevolucionForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim objBU As New NotaCreditoDevolucionesBU
        If validaInformacionExistenteAntesCerrar() Then
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Todos los cambios no guardados se perderan ¿desea continuar?."
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                objBU.EliminarSesionUsuario(lblidclienteSICY.Text, dtSession.Rows(0).Item(0))
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

End Class


