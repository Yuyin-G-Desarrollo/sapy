Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports DevExpress.XtraGrid
Imports Tools
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views
Imports Stimulsoft.Report
Imports System.IO
Imports System.Xml
Imports System.Globalization
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.Security.Cryptography

Public Class VistaPreviaFacturacion_Form

#Region "VARIABLES GLOBALES"

    Public dtDatosCliente As DataTable
    Public porcentajeFacturacionCapturadoUsuario As Integer
    Public porcentajeRemisionCapturadoUsuario As Integer
    Public tipo_RazonSocial As String
    Public porcentajePorRazonsocial As String
    Public ordenesTrabajoSeleccionadas As String
    Public sesionFacturacionId As Integer
    Public generacionAutomatica As Integer  '0 = no, 1 = si
    Public descripcionEspecial As Boolean  '0 = no, 1 = si
    Public recuperacionSesion As Boolean = False
    Public tipoPantalla As Integer = 0
    Public ParidadDocumentoExtranjero As String = "1"
    Public facturacionAnticipada As Boolean '0 = no, 1 = si

    Dim objBU As New Negocios.VistaPreviaDocumentosBU
    Dim dtEncabezadosDocumentos As New DataTable()
    Dim dtDetallesDocumentos As New DataTable()
    Dim tiendaImprimir As Integer = 0
    Dim DocumentoTemporalID As Integer = 0
    Dim dtPermisoCambioPrecios As New DataTable()
    Dim porcentajeDescuento As Integer = 0
    Dim dtDetallesDocumentoActual As New DataTable()
    Dim tipoDocumentoActual As String
    Dim BanderaImprimir As Boolean = False
    Dim ClienteID As Integer = 0

    Private dtCeldasModificadasPrecio As New DataTable

    Dim cargoEnvioConIva As Double = 0
    Dim cargoEnvioSinIva As Double = 0
    Dim cargoEnvioSoloIva As Double = 0

    'Private listCeldasModificadasPrecio As New List(Of GridCell)()
    'Private listCeldasModificadasDescripcion As New List(Of GridCell)()

#End Region

#Region "CARGA INICIAL"

    Private Sub VistaPreviaFacturacion_Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim confirmar As New Tools.ConfirmarForm

        If BanderaImprimir = False Then
            confirmar.mensaje = "Los documentos mostrados en pantalla aún no se han guardado ¿Está seguro de cerrar la pantalla sin guardar los documentos?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then

                objBU.limpiarSesionFacturacion(sesionFacturacionId)

            Else
                e.Cancel = True
            End If

        End If


    End Sub


    Private Sub VistaPreviaFacturacion_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClienteID = dtDatosCliente.Rows(0).Item("ClienteID")
        mostrarEnvio(ClienteID)
        CargarInformacionCliente()
        CargarDescuentosCliente()
        dtPermisoCambioPrecios = objBU.consultarPermisoModificarPreciosManualmente()
        GenerarVistaPreviaDocumentosInicial()

        dtCeldasModificadasPrecio.Columns.Add("IdDocumento")
        dtCeldasModificadasPrecio.Columns("IdDocumento").DataType = GetType(Integer)

        dtCeldasModificadasPrecio.Columns.Add("Renglon")
        dtCeldasModificadasPrecio.Columns("Renglon").DataType = GetType(Integer)

        dtCeldasModificadasPrecio.Columns.Add("Columna")
        dtCeldasModificadasPrecio.Columns("Columna").DataType = GetType(String)

        pnPBar.Left = (Me.Width - pnPBar.Width) / 2
        pnPBar.Top = (Me.Height - pnPBar.Height) / 2


    End Sub

    Private Sub CargarInformacionCliente()

        If dtDatosCliente.Rows.Count > 0 Then
            lblNombreCliente.Text = dtDatosCliente.Rows(0).Item("Cliente")
            If IsDBNull(dtDatosCliente.Rows(0).Item("Restriccion")) = True Then
                lblRestriccion.Text = "---"
            Else
                lblRestriccion.Text = dtDatosCliente.Rows(0).Item("Restriccion")
            End If

            If IsDBNull(dtDatosCliente.Rows(0).Item("MontoMaximoFactura")) = True Then
                lblMontoMax.Text = "0.00"
            Else
                lblMontoMax.Text = Double.Parse(dtDatosCliente.Rows(0).Item("MontoMaximoFactura")).ToString("n2")
            End If

            If IsDBNull(dtDatosCliente.Rows(0).Item("FacturarPorMarca")) = True Then
                lblRestriccionMarca.Text = "---"
            Else
                lblRestriccionMarca.Text = dtDatosCliente.Rows(0).Item("FacturarPorMarca")
            End If

            If IsDBNull(dtDatosCliente.Rows(0).Item("Moneda")) = True Then
                lblMoneda.Text = "---"
            Else
                lblMoneda.Text = dtDatosCliente.Rows(0).Item("Moneda")
            End If

            If IsDBNull(dtDatosCliente.Rows(0).Item("Plazo")) = True Then
                lblDiasPlazo.Text = "--"
            Else
                lblDiasPlazo.Text = dtDatosCliente.Rows(0).Item("Plazo")
            End If

            If IsDBNull(dtDatosCliente.Rows(0).Item("Empresa")) = True Then
                lblRazonSocialEmisor.Text = "---"
            Else
                lblRazonSocialEmisor.Text = dtDatosCliente.Rows(0).Item("Empresa")
            End If

            If IsDBNull(dtDatosCliente.Rows(0).Item("EmpresaRFC")) = True Then
                lblRFCEmisor.Text = "---"
            Else
                lblRFCEmisor.Text = dtDatosCliente.Rows(0).Item("EmpresaRFC")
            End If

            If IsDBNull(dtDatosCliente.Rows(0).Item("ImprimirOC")) = True Then
                chkImprimirOC.Checked = False
            Else
                chkImprimirOC.Checked = dtDatosCliente.Rows(0).Item("ImprimirOC")

                If chkImprimirOC.Checked = True Then
                    txtOC.Enabled = True
                Else
                    txtOC.Enabled = False
                End If

            End If

            If IsDBNull(dtDatosCliente.Rows(0).Item("ImprimirTienda")) = True Then
                chkImprimirTienda.Checked = False
            Else
                chkImprimirTienda.Checked = dtDatosCliente.Rows(0).Item("ImprimirTienda")

                If chkImprimirTienda.Checked = True Then
                    'txtTienda.Enabled = True
                    If ClienteID <> 763 Then
                        btnBuscarTienda.Enabled = True
                    End If
                Else
                    'txtTienda.Enabled = False
                    btnBuscarTienda.Enabled = False
                End If

            End If

            If IsDBNull(dtDatosCliente.Rows(0).Item("IVA")) = True Then
                lblTipoIVA.Text = "IVA"
            Else
                If LTrim(RTrim(dtDatosCliente.Rows(0).Item("IVA"))) = "INCLUIDO" Then
                    lblTipoIVA.Text = "IVA (Incluido):"
                Else
                    lblTipoIVA.Text = "Más IVA:"
                End If
            End If
        End If

    End Sub

    Private Sub CargarDescuentosCliente()
        Dim dtDescuentos As New DataTable

        dtDescuentos = objBU.consultaDescuentosCliente(dtDatosCliente.Rows(0).Item("ClienteId"))

        If dtDescuentos.Rows.Count = 0 Then
            dtDescuentos = New DataTable
            dtDescuentos.Columns.Add(" ")
            dtDescuentos.Rows.Add("SIN DESCUENTOS EN DOCUMENTO")
        End If

        grdDescuentos.DataSource = dtDescuentos

    End Sub

    Private Sub GenerarVistaPreviaDocumentosInicial()

        dtEncabezadosDocumentos = objBU.obtenerEncabezadosDocumentosPorGenerar(dtDatosCliente.Rows(0).Item("ClienteID"), ordenesTrabajoSeleccionadas, porcentajeFacturacionCapturadoUsuario, porcentajeRemisionCapturadoUsuario, dtDatosCliente.Rows(0).Item("PorcentajeFacturacion"), dtDatosCliente.Rows(0).Item("PorcentajeRemision"), dtDatosCliente.Rows(0).Item("MontoMaximoFactura"), dtDatosCliente.Rows(0).Item("RestriccionID"), dtDatosCliente.Rows(0).Item("TipoIvaID"), dtDatosCliente.Rows(0).Item("MonedaID"), dtDatosCliente.Rows(0).Item("ImprimirOC"), dtDatosCliente.Rows(0).Item("ImprimirTienda"), tipo_RazonSocial, porcentajePorRazonsocial, dtDatosCliente.Rows(0).Item("EmpresaID"), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, sesionFacturacionId, generacionAutomatica)
        If recuperacionSesion = False Then
            dtDetallesDocumentos = objBU.obtenerDetallesDocumentosPorGenerar(dtDatosCliente.Rows(0).Item("ClienteID"), sesionFacturacionId)
        Else
            dtDetallesDocumentos = objBU.obtenerDetallesDocumentosPorGenerarRecuperarSesion(sesionFacturacionId)
        End If

        porcentajeDescuento = dtEncabezadosDocumentos.Rows(0).Item("PorcentajeDescuento")
        lblNumeroDocumentoActual.Text = "1"
        lblTotalDocumentos.Text = dtEncabezadosDocumentos.Rows.Count.ToString()

        cargarVistaPreviaDocumento(CInt(lblNumeroDocumentoActual.Text) - 1)

    End Sub

#End Region

#Region "DISEÑO"

    Private Sub grdDescuentos_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdDescuentos.InitializeLayout
        grid_diseño(grdDescuentos)
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.None
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.AllowDelete = DefaultableBoolean.False
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

    'Asigna formato a columnas de ultragrid
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

    Private Sub DiseñoGridDetallesDocumento()

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvDetallesDocumento.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        bgvDetallesDocumento.Columns.ColumnByFieldName("ProductoEstiloID").Visible = False
        bgvDetallesDocumento.Columns.ColumnByFieldName("DetalleID").Visible = False
        bgvDetallesDocumento.Columns.ColumnByFieldName("DocumentoID").Visible = False

        bgvDetallesDocumento.Columns.ColumnByFieldName("ClaveSAT").Caption = "Clave SAT"
        bgvDetallesDocumento.Columns.ColumnByFieldName("Descripcion").Caption = "Descripción"

        bgvDetallesDocumento.Columns.ColumnByFieldName("ClaveSAT").OptionsColumn.AllowEdit = False
        If descripcionEspecial = False Then
            bgvDetallesDocumento.Columns.ColumnByFieldName("Descripcion").OptionsColumn.AllowEdit = False
        Else
            bgvDetallesDocumento.Columns.ColumnByFieldName("Descripcion").OptionsColumn.AllowEdit = True
        End If
        bgvDetallesDocumento.Columns.ColumnByFieldName("Piel").OptionsColumn.AllowEdit = False
        bgvDetallesDocumento.Columns.ColumnByFieldName("Color").OptionsColumn.AllowEdit = False
        bgvDetallesDocumento.Columns.ColumnByFieldName("Corrida").OptionsColumn.AllowEdit = False
        bgvDetallesDocumento.Columns.ColumnByFieldName("Pares").OptionsColumn.AllowEdit = False
        If CBool(dtPermisoCambioPrecios.Rows(0).Item("opci_valor_booleano")) = False Or tipoDocumentoActual = "F" Then
            bgvDetallesDocumento.Columns.ColumnByFieldName("Precio").OptionsColumn.AllowEdit = False
        Else
            bgvDetallesDocumento.Columns.ColumnByFieldName("Precio").OptionsColumn.AllowEdit = True
        End If
        bgvDetallesDocumento.Columns.ColumnByFieldName("Subtotal").OptionsColumn.AllowEdit = False
        bgvDetallesDocumento.Columns.ColumnByFieldName("Descuento").OptionsColumn.AllowEdit = False
        bgvDetallesDocumento.Columns.ColumnByFieldName("Importe").OptionsColumn.AllowEdit = False

        bgvDetallesDocumento.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvDetallesDocumento.Columns.ColumnByFieldName("Precio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvDetallesDocumento.Columns.ColumnByFieldName("Subtotal").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvDetallesDocumento.Columns.ColumnByFieldName("Descuento").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvDetallesDocumento.Columns.ColumnByFieldName("Importe").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        bgvDetallesDocumento.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatString = "n0"
        bgvDetallesDocumento.Columns.ColumnByFieldName("Precio").DisplayFormat.FormatString = "n2"
        bgvDetallesDocumento.Columns.ColumnByFieldName("Subtotal").DisplayFormat.FormatString = "n2"
        bgvDetallesDocumento.Columns.ColumnByFieldName("Descuento").DisplayFormat.FormatString = "n2"
        bgvDetallesDocumento.Columns.ColumnByFieldName("Importe").DisplayFormat.FormatString = "n2"

        'bgvDetallesDocumento.Columns.ColumnByFieldName("Pares").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        'bgvDetallesDocumento.Columns.ColumnByFieldName("Precio").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        'bgvDetallesDocumento.Columns.ColumnByFieldName("Subtotal").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        'bgvDetallesDocumento.Columns.ColumnByFieldName("Descuento").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        'bgvDetallesDocumento.Columns.ColumnByFieldName("Importe").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

        bgvDetallesDocumento.Columns.ColumnByFieldName("Descripcion").Width = 150
        bgvDetallesDocumento.Columns.ColumnByFieldName("Piel").Width = 90
        bgvDetallesDocumento.Columns.ColumnByFieldName("Color").Width = 90

        bgvDetallesDocumento.IndicatorWidth = 25

        If IsNothing(bgvDetallesDocumento.Columns("Pares").Summary.FirstOrDefault(Function(x) x.FieldName = "Pares")) = True Then
            bgvDetallesDocumento.Columns("Pares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pares"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            bgvDetallesDocumento.GroupSummary.Add(item)
        End If
        If IsNothing(bgvDetallesDocumento.Columns("Subtotal").Summary.FirstOrDefault(Function(x) x.FieldName = "Subtotal")) = True Then
            bgvDetallesDocumento.Columns("Subtotal").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Subtotal", "{0:N2}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Subtotal"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0:N2}"
            bgvDetallesDocumento.GroupSummary.Add(item)
        End If
        If IsNothing(bgvDetallesDocumento.Columns("Descuento").Summary.FirstOrDefault(Function(x) x.FieldName = "Descuento")) = True Then
            bgvDetallesDocumento.Columns("Descuento").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Descuento", "{0:N2}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Descuento"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0:N2}"
            bgvDetallesDocumento.GroupSummary.Add(item)
        End If
        If IsNothing(bgvDetallesDocumento.Columns("Importe").Summary.FirstOrDefault(Function(x) x.FieldName = "Importe")) = True Then
            bgvDetallesDocumento.Columns("Importe").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Importe", "{0:N2}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Importe"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0:N2}"
            bgvDetallesDocumento.GroupSummary.Add(item)
        End If


    End Sub

    Private Sub bgvOts_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles bgvDetallesDocumento.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

#End Region

#Region "MOSTRAR VISTAS PREVIAS"

    Public Sub cargarVistaPreviaDocumento(ByVal numeroDocumento As Integer)
        dtDetallesDocumentoActual = New DataTable()
        Dim Tipo As String = ""
        Dim RazonSocialReceptor As String = ""
        Dim RfcReceptor As String = ""
        Dim UsoCFDI As String = ""
        DocumentoTemporalID = 0
        Dim SubTotal As Double = 0
        Dim Descuento As Double = 0
        Dim IVA As Double = 0
        Dim Total As Double = 0
        Dim OC As String = String.Empty
        Dim Tienda As String = String.Empty
        Dim CantidadLetra As String = String.Empty
        Dim NumCaja As Integer = 0
        Dim Mensaje As String = String.Empty
        Dim Observacion As String = String.Empty


        If CInt(lblTotalDocumentos.Text) > CInt(lblNumeroDocumentoActual.Text) Then
            btnSiguiente.Enabled = True
            lblTextoSiguiente.Enabled = True
        Else
            btnSiguiente.Enabled = False
            lblTextoSiguiente.Enabled = False
        End If

        If CInt(lblNumeroDocumentoActual.Text) > 1 Then
            btnAnterior.Enabled = True
            lblTextoAnterior.Enabled = True
        Else
            btnAnterior.Enabled = False
            lblTextoAnterior.Enabled = False
        End If

        Tipo = dtEncabezadosDocumentos.Rows(numeroDocumento).Item("TipoDocumento")
        tipoDocumentoActual = Tipo
        RazonSocialReceptor = dtEncabezadosDocumentos.Rows(numeroDocumento).Item("Receptor")
        RfcReceptor = dtEncabezadosDocumentos.Rows(numeroDocumento).Item("RFCReceptor")
        UsoCFDI = dtEncabezadosDocumentos.Rows(numeroDocumento).Item("UsoCFDI")
        DocumentoTemporalID = dtEncabezadosDocumentos.Rows(numeroDocumento).Item("DocumentoID")
        SubTotal = dtEncabezadosDocumentos.Rows(numeroDocumento).Item("Subtotal")
        IVA = dtEncabezadosDocumentos.Rows(numeroDocumento).Item("IVA")
        Total = dtEncabezadosDocumentos.Rows(numeroDocumento).Item("Total")
        OC = If(IsDBNull(dtEncabezadosDocumentos.Rows(numeroDocumento).Item("OC")), "", dtEncabezadosDocumentos.Rows(numeroDocumento).Item("OC"))
        tiendaImprimir = If(IsDBNull(dtEncabezadosDocumentos.Rows(numeroDocumento).Item("TiendaID")), 0, dtEncabezadosDocumentos.Rows(numeroDocumento).Item("TiendaID"))
        Tienda = If(IsDBNull(dtEncabezadosDocumentos.Rows(numeroDocumento).Item("Tienda")), "", dtEncabezadosDocumentos.Rows(numeroDocumento).Item("Tienda"))
        CantidadLetra = dtEncabezadosDocumentos.Rows(numeroDocumento).Item("CantidadLetra")
        Descuento = dtEncabezadosDocumentos.Rows(numeroDocumento).Item("Descuento")
        NumCaja = If(IsDBNull(dtEncabezadosDocumentos.Rows(numeroDocumento).Item("Cajas")), 0, dtEncabezadosDocumentos.Rows(numeroDocumento).Item("Cajas"))
        Mensaje = If(IsDBNull(dtEncabezadosDocumentos.Rows(numeroDocumento).Item("Mensaje")), "", dtEncabezadosDocumentos.Rows(numeroDocumento).Item("Mensaje"))
        Observacion = If(IsDBNull(dtEncabezadosDocumentos.Rows(numeroDocumento).Item("Observacion")), "", dtEncabezadosDocumentos.Rows(numeroDocumento).Item("Observacion"))
        cargoEnvioConIva = dtEncabezadosDocumentos.Rows(numeroDocumento).Item("CargoAdicional")
        If cargoEnvioConIva > 0 Then
            cargoEnvioSinIva = Format((cargoEnvioConIva / 1.16), "#.##")
            cargoEnvioSoloIva = Format((cargoEnvioSinIva * 0.16), "#.##")
        End If

        'MsgBox("Cargo de Envio con IVA: " & cargoEnvioConIva & vbCrLf & "Cargo de Envio  sin IVA: " & cargoEnvioSinIva & vbCrLf & "Cargo de Envio solo IVA: " & cargoEnvioSoloIva)
        If cargoEnvioConIva <> 0 Then
            txtEnvio.Text = cargoEnvioSinIva.ToString()
        Else
            txtEnvio.Text = "0.00"
        End If

        lblRazonSocialReceptor.Text = Tipo + "-" + RazonSocialReceptor
        lblRFCReceptor.Text = RfcReceptor
        lblUsoCFDI.Text = UsoCFDI
        txtSubTotal.Text = SubTotal.ToString("n2")
        txtIVA.Text = IVA.ToString("n2")
        txtTotal.Text = Total.ToString("n2")


        'If CDbl(txtEnvio.Text) > 0 Then
        '    txtSubTotal.Text = (SubTotal + cargoEnvioSinIva).ToString("n2")
        '    txtIVA.Text = (IVA + cargoEnvioSoloIva).ToString("n2")
        '    'txtTotal.Text = (((CDbl(txtSubTotal.Text)) + (CDbl(txtIVA.Text) + cargoEnvioSinIva)) - Descuento).ToString("n2")
        '    txtTotal.Text = CDbl(Total.ToString("n2") + cargoEnvioConIva).ToString("n2")
        'Else
        '    txtSubTotal.Text = SubTotal.ToString("n2")
        '    txtIVA.Text = IVA.ToString("n2")
        '    txtTotal.Text = Total.ToString("n2")
        'End If

        txtDescuentoTotal.Text = Descuento.ToString("n2")
        txtOC.Text = OC
        'If chkImprimirOC.Checked Then
        '    txtOC.Text = OC
        'End If
        If chkImprimirTienda.Checked Then
            txtTienda.Text = Tienda
        End If
        lblCantidadLetra.Text = CantidadLetra
        txtNumCajas.Text = NumCaja.ToString()
        txtMensaje.Text = Mensaje.ToString()
        txtObservaciones.Text = Observacion.ToString()


        If Tipo = "R" Then
            lblTextoMensaje.Visible = True
            txtMensaje.Visible = True
            lblRFCEmisor.Visible = False
            lblTextoRFCEmisor.Visible = False
            lblRFCReceptor.Visible = False
            lblTextoRFCReceptor.Visible = False
            lblTipoIVA.Visible = False
            txtIVA.Visible = False
            lblTipoDocumento.Text = "REMISIÓN"
            lblTipoDocumento.ForeColor = Color.Purple
            If CBool(dtPermisoCambioPrecios.Rows(0).Item("opci_valor_booleano")) = True Then
                lblPreciosModificados.Visible = True
            End If
        Else
            lblTextoMensaje.Visible = False
            txtMensaje.Visible = False
            lblRFCEmisor.Visible = True
            lblTextoRFCEmisor.Visible = True
            lblRFCReceptor.Visible = True
            lblTextoRFCReceptor.Visible = True
            lblTipoIVA.Visible = True
            txtIVA.Visible = True
            lblTipoDocumento.Text = "FACTURA"
            lblTipoDocumento.ForeColor = Color.Green
            lblPreciosModificados.Visible = False
        End If

        For Each col As DataColumn In dtDetallesDocumentos.Columns
            If col.ColumnName = "Precio" Or col.ColumnName = "Subtotal" Or col.ColumnName = "Descuento" Or col.ColumnName = "Importe" Then
                dtDetallesDocumentoActual.Columns.Add(col.ColumnName, GetType(Double))
            ElseIf col.ColumnName = "Pares" Then
                dtDetallesDocumentoActual.Columns.Add(col.ColumnName, GetType(Integer))
            Else
                dtDetallesDocumentoActual.Columns.Add(col.ColumnName)
            End If
        Next

        For Each row As DataRow In dtDetallesDocumentos.Rows
            If row.Item("DocumentoID") = DocumentoTemporalID Then
                dtDetallesDocumentoActual.Rows.Add(row.Item("ProductoEstiloID"), row.Item("DetalleId"), row.Item("DocumentoID"), row.Item("ClaveSAT"), row.Item("Descripcion"), row.Item("Piel"), row.Item("Color"), row.Item("Corrida"), Integer.Parse(row.Item("Pares")), Double.Parse(row.Item("Precio")), Double.Parse(row.Item("Subtotal")), Double.Parse(row.Item("Descuento")), Double.Parse(row.Item("Importe")))
            End If
        Next

        If descripcionEspecial = True Then
            lblDescripcionModificada.Visible = True
        Else
            lblDescripcionModificada.Visible = False
        End If

        'For Each col As DataColumn In dtDetallesDocumentos.Columns
        '    If col.ColumnName = "Precio" Or col.ColumnName = "Subtotal" Or col.ColumnName = "Descuento" Or col.ColumnName = "Importe" Then
        '        For Each row As DataRow In dtDetallesDocumentoActual.Rows
        '            row.Item(col.ColumnName) = Math.Round(Double.Parse(row.Item(col.ColumnName)), 2).ToString
        '        Next
        '    End If
        'Next

        grdDetallesDocumento.DataSource = Nothing
        grdDetallesDocumento.DataSource = dtDetallesDocumentoActual
        DiseñoGridDetallesDocumento()
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        lblNumeroDocumentoActual.Text = (CInt(lblNumeroDocumentoActual.Text) + 1).ToString("n0")
        cargarVistaPreviaDocumento(CInt(lblNumeroDocumentoActual.Text) - 1)
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        lblNumeroDocumentoActual.Text = (CInt(lblNumeroDocumentoActual.Text) - 1).ToString("n0")
        cargarVistaPreviaDocumento(CInt(lblNumeroDocumentoActual.Text) - 1)
    End Sub

#End Region

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscarTienda_Click(sender As Object, e As EventArgs) Handles btnBuscarTienda.Click
        Dim listado As New ListadoTiendasImprimirFacturacion_Form
        Dim listaParametroID As New List(Of Integer)
        Dim parametro As Integer = tiendaImprimir
        Dim listResultadoParametro As New DataTable
        listaParametroID.Add(parametro)
        listado.listaParametroID = listaParametroID
        listado.clienteId = dtDatosCliente.Rows(0).Item("ClienteID")
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        'If listado.listParametros.Rows.Count = 0 Then Return
        listResultadoParametro = listado.listParametros
        tiendaImprimir = If(listResultadoParametro.Rows.Count > 0, listResultadoParametro.Rows(0).Item("Parámetro"), 0)
        txtTienda.Text = If(listResultadoParametro.Rows.Count > 0, listResultadoParametro.Rows(0).Item("Tiendas / Embarques / CEDIS").ToString(), "")
        Cursor = Cursors.WaitCursor
        objBU.actualizaTiendaPorDocumento(DocumentoTemporalID, tiendaImprimir, txtOC.Text)
        actualizarTiendaYOCEnPantalla(tiendaImprimir, txtTienda.Text, txtOC.Text, DocumentoTemporalID)
        Cursor = Cursors.Default
    End Sub

    Private Sub txtOC_Leave(sender As Object, e As EventArgs) Handles txtOC.Leave
        Cursor = Cursors.WaitCursor
        If txtOC.Text <> "" Then
            objBU.actualizaTiendaPorDocumento(DocumentoTemporalID, tiendaImprimir, txtOC.Text)
            actualizarTiendaYOCEnPantalla(tiendaImprimir, txtTienda.Text, txtOC.Text, DocumentoTemporalID)
            btnImprimir.Enabled = True
            lblOC.ForeColor = Color.Black
        Else
            show_message("Advertencia", "El dato OC no puede quedar vacío.")
            btnImprimir.Enabled = False
            lblOC.ForeColor = Color.Red
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub actualizarTiendaYOCEnPantalla(ByVal TiendaId As Integer, ByVal TiendaNombre As String, ByVal OC As String, ByVal DocumentoId As Integer)

        For Each row As DataRow In dtEncabezadosDocumentos.Rows
            If row.Item("DocumentoID") = DocumentoId Then
                row.Item("TiendaID") = TiendaId
                row.Item("Tienda") = TiendaNombre
                row.Item("OC") = OC
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

    Private Sub bgvDetallesDocumento_CellValueChanging(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles bgvDetallesDocumento.CellValueChanging
        If e.Column.FieldName = "Precio" Then
            If e.Value = "" Then
                bgvDetallesDocumento.SetRowCellValue(e.RowHandle, "Precio", 0)
            End If
        End If
    End Sub

    Private Sub actualizarDescripcionEnPantalla(ByVal DetalleID As Integer, ByVal Descripcion As String)

        For Each row As DataRow In dtDetallesDocumentos.Rows
            If row.Item("DetalleID") = DetalleID Then
                row.Item("Descripcion") = Descripcion
            End If
        Next

    End Sub


    Private Sub bgvDetallesDocumento_CellValueChanged(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles bgvDetallesDocumento.CellValueChanged
        If e.Column.FieldName = "Descripcion" Then
            If e.Value <> "" Then
                objBU.actualizaDescripcionDetalleDocumentoPorGenerar(bgvDetallesDocumento.GetRowCellValue(e.RowHandle, "DetalleID"), e.Value)
                actualizarDescripcionEnPantalla(bgvDetallesDocumento.GetRowCellValue(e.RowHandle, "DetalleID"), e.Value)
                If (Not ExisteCelda(bgvDetallesDocumento.GetDataSourceRowIndex(e.RowHandle), e.Column)) Then
                    'listCeldasModificadasDescripcion.Add(New GridCell(bgvDetallesDocumento.GetDataSourceRowIndex(e.RowHandle), e.Column))
                    dtCeldasModificadasPrecio.Rows.Add(DocumentoTemporalID, bgvDetallesDocumento.GetDataSourceRowIndex(e.RowHandle), e.Column.FieldName)
                End If
            End If
        End If
        If e.Column.FieldName = "Precio" Then
            If e.Value.ToString() <> "" Then
                bgvDetallesDocumento.SetRowCellValue(e.RowHandle, "Subtotal", e.Value * bgvDetallesDocumento.GetRowCellValue(e.RowHandle, "Pares"))
                bgvDetallesDocumento.SetRowCellValue(e.RowHandle, "Descuento", bgvDetallesDocumento.GetRowCellValue(e.RowHandle, "Subtotal") * porcentajeDescuento / 100)
                bgvDetallesDocumento.SetRowCellValue(e.RowHandle, "Importe", bgvDetallesDocumento.GetRowCellValue(e.RowHandle, "Subtotal") - bgvDetallesDocumento.GetRowCellValue(e.RowHandle, "Descuento"))
                actualizarPrecioEnPantallas(bgvDetallesDocumento.GetRowCellValue(e.RowHandle, "DetalleID"), e.Value)
                If (Not ExisteCelda(bgvDetallesDocumento.GetDataSourceRowIndex(e.RowHandle), e.Column)) Then
                    'listCeldasModificadasPrecio.Add(New GridCell(bgvDetallesDocumento.GetDataSourceRowIndex(e.RowHandle), e.Column))
                    dtCeldasModificadasPrecio.Rows.Add(DocumentoTemporalID, bgvDetallesDocumento.GetDataSourceRowIndex(e.RowHandle), e.Column.FieldName)
                    dtCeldasModificadasPrecio.Rows.Add(DocumentoTemporalID, bgvDetallesDocumento.GetDataSourceRowIndex(e.RowHandle), "Subtotal")
                    dtCeldasModificadasPrecio.Rows.Add(DocumentoTemporalID, bgvDetallesDocumento.GetDataSourceRowIndex(e.RowHandle), "Descuento")
                    dtCeldasModificadasPrecio.Rows.Add(DocumentoTemporalID, bgvDetallesDocumento.GetDataSourceRowIndex(e.RowHandle), "Importe")
                End If
            End If
        End If

    End Sub

    Private Sub actualizarPrecioEnPantallas(ByVal DetalleID As Integer, ByVal Precio As Double)
        Dim Subtotal As Double = 0
        Dim Descuento As Double = 0
        Dim Importe As Double = 0
        Dim TotalSubtotal As Double = 0
        Dim TotalDescuento As Double = 0
        Dim Total As Double = 0
        Dim TotalIVA As Double = 0
        Dim dtResultadoActualizarPrecio As New DataTable()

        For Each row As DataRow In dtDetallesDocumentoActual.Rows
            If row.Item("DetalleID") = DetalleID Then
                row.Item("Precio") = Precio
                row.Item("Subtotal") = Precio * row.Item("Pares")
                Subtotal = row.Item("Subtotal")
                row.Item("Descuento") = row.Item("Subtotal") * porcentajeDescuento / 100
                Descuento = row.Item("Descuento")
                row.Item("Importe") = row.Item("Subtotal") - row.Item("Descuento")
                Importe = row.Item("Importe")
            End If
            TotalSubtotal += row.Item("Subtotal")
            TotalDescuento += row.Item("Descuento")
        Next

        For Each row As DataRow In dtDetallesDocumentos.Rows
            If row.Item("DetalleID") = DetalleID Then
                row.Item("Precio") = Precio
                row.Item("Subtotal") = Precio * row.Item("Pares")
                row.Item("Descuento") = row.Item("Subtotal") * porcentajeDescuento / 100
                row.Item("Importe") = row.Item("Subtotal") - row.Item("Descuento")
            End If
        Next

        If tipoDocumentoActual = "R" Then
            Total = TotalSubtotal - TotalDescuento
        Else
            TotalIVA = (TotalSubtotal - TotalDescuento) * 0.16
            Total = (TotalSubtotal - TotalDescuento) + TotalIVA
        End If

        txtSubTotal.Text = TotalSubtotal.ToString("n2")
        txtDescuentoTotal.Text = TotalDescuento.ToString("n2")
        txtIVA.Text = TotalIVA.ToString("n2")
        txtTotal.Text = Total.ToString("n2")

        dtResultadoActualizarPrecio = objBU.actualizaPrecioDocumentoPorGenerar(DetalleID, Precio, Subtotal, Descuento, Importe, TotalSubtotal, TotalDescuento, Total, TotalIVA)

        For Each row As DataRow In dtEncabezadosDocumentos.Rows
            If row.Item("DocumentoID") = DocumentoTemporalID Then
                row.Item("Subtotal") = TotalSubtotal
                row.Item("Descuento") = TotalDescuento
                row.Item("IVA") = TotalIVA
                row.Item("Total") = Total
                row.Item("CantidadLetra") = dtResultadoActualizarPrecio.Rows(0).Item("CantidadLetra")
            End If
        Next

        lblCantidadLetra.Text = dtResultadoActualizarPrecio.Rows(0).Item("CantidadLetra")

    End Sub

    Private Sub txtNumCajas_Leave(sender As Object, e As EventArgs) Handles txtNumCajas.Leave
        actualizarCajasYMensajes(If(txtNumCajas.Text = "", 0, Integer.Parse(txtNumCajas.Text)), txtMensaje.Text, txtObservaciones.Text, DocumentoTemporalID)
        If txtNumCajas.Text = "" Then
            txtNumCajas.Text = "0"
        End If
    End Sub

    Private Sub actualizarCajasYMensajes(ByVal Cajas As Integer, ByVal Mensaje As String, ByVal Observaciones As String, ByVal DocumentoId As Integer)

        For Each row As DataRow In dtEncabezadosDocumentos.Rows
            If row.Item("DocumentoID") = DocumentoId Then
                row.Item("Cajas") = Cajas
                row.Item("Mensaje") = Mensaje
                row.Item("Observacion") = Observaciones
            End If
        Next

        objBU.actualizaCajasYMensajesDocumentoPorGenerar(DocumentoId, Cajas, Mensaje, Observaciones)

    End Sub

    Private Sub txtNumCajas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumCajas.KeyPress
        If Not Char.IsNumber(e.KeyChar) And e.KeyChar <> Microsoft.VisualBasic.ChrW(8) And e.KeyChar <> Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtObservaciones_Leave(sender As Object, e As EventArgs) Handles txtObservaciones.Leave
        actualizarCajasYMensajes(Integer.Parse(txtNumCajas.Text), txtMensaje.Text, txtObservaciones.Text, DocumentoTemporalID)
    End Sub

    Private Sub txtMensaje_Leave(sender As Object, e As EventArgs) Handles txtMensaje.Leave
        actualizarCajasYMensajes(Integer.Parse(txtNumCajas.Text), txtMensaje.Text, txtObservaciones.Text, DocumentoTemporalID)
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Dim DocumentoID As Integer = 0
        Dim DocumentoIdTMP As Integer = 0
        Dim EsEncadenado As Boolean = False
        Dim dtdocumento As DataTable
        Dim EsDocumentoCorrrecto As Boolean = True
        Dim ListaDocumentos As New List(Of String)
        Dim DocumentosGenerados As String = String.Empty
        Dim Folio As String = String.Empty
        Dim Serie As String = String.Empty
        Dim Remision As String = String.Empty
        Dim AñoRemision As String = String.Empty
        Dim EmpresaDocumentoId As Integer = 0
        Dim TipoDocumento As String = String.Empty
        Dim dtInformacionDocumentosSession As DataTable
        Dim ListaFacturas As New List(Of String)
        Dim ListaRemisiones As New List(Of String)
        Dim ListaDocumentosRemisionGenerado As New List(Of String)
        Dim ListaDocumentosFacturaGenerado As New List(Of String)
        Dim confirmar As New Tools.ConfirmarForm
        Dim ClienteID As Integer = 0
        Dim DiasPlazo As Integer = 0
        Dim SeTimbroCorrectamenteFactura As Boolean = False
        Dim SeGeneroPDFCorrectamenteFactura As Boolean = False
        Dim RutaPDFFactura As String = String.Empty
        Dim DocumentosTimbrados As Integer = 0
        Dim DocumentosErrorTimbrado As Integer = 0
        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim CorreosNoEnviados As Integer = 0
        Dim DocumentoNoTimbrados As String = String.Empty
        Dim dtRemisionGenerada As New DataTable
        Dim RemisionID As String = String.Empty
        Dim index As Integer = 0
        Dim FormProgreso As New BarraProgresoFacturacionForm
        Dim ListaDocumentosPDFFacturas As New List(Of String)
        Dim ListaDocumentosRemisiones As New List(Of String)
        Dim entCliente As Entidades.Cliente
        Dim objAdministradorOTBU As New Negocios.AdministradorOTFacturacionBU


        Try
            ClienteID = dtDatosCliente.Rows(0).Item("ClienteID")

            entCliente = objAdministradorOTBU.ObtenerInfomracionCliente(ClienteID)

            If ClienteID = 763 Then
                Dim ValidarCapturaCajas = dtEncabezadosDocumentos.AsEnumerable.Where(Function(x) x.Item("Cajas") = 0).Count()
                If ValidarCapturaCajas > 0 Then
                    show_message("Advertencia", "Hay algunos documentos con número de cajas igual 0, asegurese que todos los documentos tengan al menos una caja capturada.")
                    Return
                End If
            End If


            confirmar.mensaje = "Se van a generar, timbrar e imprimir " & lblTotalDocumentos.Text.ToString & "  documentos, una vez realizada esta acción no podrá realizar cambios ¿Desea continuar?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                pnPBar.Visible = True
                pBar.Minimum = 0
                pBar.ForeColor = Color.Blue
                System.Windows.Forms.Application.DoEvents()

                pBar.Maximum = CInt(lblTotalDocumentos.Text)

                dtInformacionDocumentosSession = objBU.ObtenerInformaciondocumentoSession(sesionFacturacionId)
                ClienteID = dtDatosCliente.Rows(0).Item("ClienteID")
                Cursor = Cursors.WaitCursor

                ' FormProgreso.NumeroDocumentos = lblTotalDocumentos.Text
                'FormProgreso.DocumentoProcesado = 1
                index = 1
                'FormProgreso.StatusProgreso = "Iniciando"
                'FormProgreso.Show()

                lblInfo.Text = "Iniciando...."
                System.Windows.Forms.Application.DoEvents()
                lblNumeroDocumentos.Text = lblTotalDocumentos.Text

                For Each Fila As DataRow In dtEncabezadosDocumentos.Rows

                    Try
                        SeTimbroCorrectamenteFactura = False
                        SeGeneroPDFCorrectamenteFactura = False
                        RutaPDFFactura = String.Empty
                        EmpresaDocumentoId = 0
                        TipoDocumento = String.Empty
                        DocumentoTemporalID = Fila.Item("DocumentoID")
                        Dim qempresa = dtInformacionDocumentosSession.AsEnumerable().Where(Function(x) x.Item("fcdc_documentoid") = DocumentoTemporalID).FirstOrDefault

                        EmpresaDocumentoId = qempresa.Item("fcdc_empresaid")
                        TipoDocumento = qempresa.Item("fcdc_tipodocumento")

                        If EsDocumentoCorrrecto = True Then
                            DocumentoIdTMP = DocumentoTemporalID
                            If IsNumeric(lblDiasPlazo.Text) = True Then
                                DiasPlazo = Integer.Parse(lblDiasPlazo.Text)
                            Else
                                DiasPlazo = 0
                            End If

                            lblInfo.Text = "Guardando información de factura en el SAY..."

                            System.Windows.Forms.Application.DoEvents()
                            'FormProgreso.DibujarBarra(index, "Guardando información de factura en el SAY.")

                            'dtdocumento = objBU.EnviarDocumentosSAY(sesionFacturacionId, DocumentoIdTMP, DiasPlazo, Fila.Item("CantidadLetra").ToString(), CDbl(ParidadDocumentoExtranjero)) 'Encabezado
                            dtdocumento = objBU.EnviarDocumentosSAY(sesionFacturacionId, DocumentoIdTMP, DiasPlazo, Fila.Item("CantidadLetra").ToString(), CDbl(ParidadDocumentoExtranjero), cargoEnvioConIva, cargoEnvioSinIva, cargoEnvioSoloIva) 'Encabezado


                            If dtdocumento.Rows.Count > 0 Then
                                DocumentoID = dtdocumento.Rows(0).Item(0)
                                ListaDocumentos.Add(DocumentoID)

                                'If TipoDocumento = "F" And entCliente.tipocliente.tipoclienteid <> 2 Then 'Brincar validacion si el documento es externo
                                '    'If objBUTimbrado.ValidarMontosDocumento(DocumentoID, "FACTURACALZADO") = False Then
                                '    '    objBUTimbrado.RecalcularMontos(DocumentoID)
                                '    'End If

                                'End If

                                If TipoDocumento = "F" Then
                                    ListaDocumentosFacturaGenerado.Add(DocumentoID.ToString())
                                ElseIf TipoDocumento = "R" Then
                                    ListaDocumentosRemisionGenerado.Add(DocumentoID.ToString())
                                End If

                                For Each FilaDescuento As UltraGridRow In grdDescuentos.Rows
                                    If FilaDescuento.Cells.Exists("Motivo") = True And FilaDescuento.Cells.Exists("%") = True And FilaDescuento.Cells.Exists("Encadenado") = True Then
                                        EsEncadenado = False
                                        If FilaDescuento.Cells("Encadenado").Value = "SI" Then
                                            EsEncadenado = True
                                        ElseIf FilaDescuento.Cells("Encadenado").Value = "NO" Then
                                            EsEncadenado = False
                                        End If
                                        objBU.InsertarDescuentoClienteDocumento(DocumentoID, FilaDescuento.Cells("Motivo").Value, FilaDescuento.Cells("%").Value, EsEncadenado) 'Insertar descuentos
                                    End If
                                Next

                                'Actualizar los pares facturados OT y Pedido
                                'FormProgreso.DibujarBarra(index, "Actualizando los pares facturados en la OT.")
                                lblInfo.Text = "Actualizando los pares facturados en la OT..."
                                System.Windows.Forms.Application.DoEvents()
                                If facturacionAnticipada Or ClienteID = 763 Or ClienteID = 1181 Then
                                    objBU.ActualizarParesFacturadosCOPPEL(DocumentoID)
                                    objBU.ActualizarStatusPedido(DocumentoID)
                                Else
                                    ' Actualiza la informacion de las OTs y Pedidos con los pares facturados y por facturar
                                    objBU.ActualizarParesFacturados(DocumentoID)
                                    objBU.ActualizarStatusOT(DocumentoID)
                                    objBU.ActualizarStatusPedido(DocumentoID)
                                    objBU.ActualizarStatusPedidoSICY(DocumentoID)
                                End If

                                'Replicar informacion al SICY
                                lblInfo.Text = "Enviando la información al SICY..."
                                'FormProgreso.DibujarBarra(index, "Enviando la información al SICY.")
                                dtRemisionGenerada = objBU.ReplicarDocumentos_SAY_SICY(DocumentoID, CDbl(ParidadDocumentoExtranjero))
                                System.Windows.Forms.Application.DoEvents()
                                If dtRemisionGenerada.Rows.Count > 0 Then
                                    RemisionID = dtRemisionGenerada.Rows(0).Item(0)
                                Else
                                    RemisionID = "0"
                                End If

                                If Remision <> "0" And entCliente.tipocliente.tipoclienteid <> 2 Then 'BRINCAR VALIDACION SI EL CLIENTE ES EXTRANJERO
                                    'Timbrado de la Factura
                                    If TipoDocumento = "F" Then
                                        'FormProgreso.DibujarBarra(index, "Generando la información del timbrado.")
                                        lblInfo.Text = "Generando la información del timbrado..."
                                        System.Windows.Forms.Application.DoEvents()
                                        objBUTimbrado.GenerarInformacionTimbrado(DocumentoID, TipoDocumento)

                                        'FormProgreso.DibujarBarra(index, "Timbrando documento.")
                                        lblInfo.Text = "Timbrando documento..."
                                        System.Windows.Forms.Application.DoEvents()
                                        '-------------------------------------------

                                        SeTimbroCorrectamenteFactura = objBUTimbrado.TimbrarFactura(DocumentoID, EmpresaDocumentoId, "FACTURACALZADO")

                                        If SeTimbroCorrectamenteFactura = True Then
                                            'Obtener la lista de los documentos timbrados correctamente
                                            If DocumentosGenerados = String.Empty Then
                                                DocumentosGenerados = DocumentoID
                                            Else
                                                DocumentosGenerados &= "," & DocumentoID
                                            End If

                                            'Si es COPPEL Agregar Addenda 
                                            If ClienteID = 763 Then
                                                'FormProgreso.DibujarBarra(index, "Generando Addenda.")
                                                lblInfo.Text = "Generando Addenda..."
                                                System.Windows.Forms.Application.DoEvents()
                                                objBUTimbrado.GenerarAddendaCOPPEL(DocumentoID, "FACTURACALZADO")
                                            Else
                                                objBU.GeneraRegistgrosSalidaDocumento(DocumentoID)
                                            End If
                                            'Generar PDF
                                            DocumentosTimbrados = DocumentosTimbrados + 1
                                            'FormProgreso.DibujarBarra(index, "Generando PDF.")
                                            lblInfo.Text = "Generando PDF..."
                                            System.Windows.Forms.Application.DoEvents()
                                            SeGeneroPDFCorrectamenteFactura = objBUTimbrado.GenerarPDFFactura(DocumentoID, "FACTURACALZADO")
                                            'SeGeneroPDFCorrectamenteFactura = objBU.GenerarPDFFactura(DocumentoID, "FACTURACALZADO")
                                            If SeGeneroPDFCorrectamenteFactura = True Then
                                                RutaPDFFactura = objBUTimbrado.ConsultarRutaPDFFactura(DocumentoID)
                                                'AbrirPDFFactura(RutaPDFFactura)
                                                ListaDocumentosPDFFacturas.Add(RutaPDFFactura)
                                                'Dim ListaDocumentosPDFFacturas As New List(Of String)
                                                'Dim ListaDocumentosRemisiones As New List(Of String)
                                                'FormProgreso.DibujarBarra(index, "Enviando correo.")
                                                lblInfo.Text = "Enviando correo...."
                                                System.Windows.Forms.Application.DoEvents()
                                                If enviarCorreoFacturacionCliente(DocumentoID) = False Then
                                                    CorreosNoEnviados += 1
                                                End If
                                            End If
                                        Else
                                            If DocumentoNoTimbrados = String.Empty Then
                                                DocumentoNoTimbrados = DocumentoID.ToString()
                                            Else
                                                DocumentoNoTimbrados &= "," & DocumentoID.ToString()
                                            End If
                                            DocumentosErrorTimbrado += 1
                                        End If
                                    Else
                                        'FormProgreso.DibujarBarra(index, "Generando PDF.")
                                        lblInfo.Text = "Generando PDF..."
                                        System.Windows.Forms.Application.DoEvents()
                                        'objBUTimbrado.ImprimirRemision(DocumentoID)
                                        ListaDocumentosRemisiones.Add(DocumentoID)
                                    End If

                                Else
                                    If DocumentoNoTimbrados = String.Empty Then
                                        DocumentoNoTimbrados = DocumentoID.ToString()
                                    Else
                                        DocumentoNoTimbrados &= "," & DocumentoID.ToString()
                                    End If
                                    DocumentosErrorTimbrado += 1
                                    objBUTimbrado.InsertarErrorAlTimbrar(DocumentoID, "FACTURACALZADO", "NA", "No se genero un número de remisión.")

                                End If
                                ' DocumentosErrorTimbrado += 1
                            Else
                                EsDocumentoCorrrecto = False
                            End If

                        End If
                    Catch ex As Exception
                        If DocumentoNoTimbrados = String.Empty Then
                            DocumentoNoTimbrados = DocumentoID.ToString()
                        Else
                            DocumentoNoTimbrados &= "," & DocumentoID.ToString()
                        End If
                        DocumentosErrorTimbrado += 1
                        objBUTimbrado.InsertarErrorAlTimbrar(DocumentoID, "FACTURACALZADO", "NA", ex.Message.ToString())
                    End Try
                    lblDocumentosFacturados.Text = index.ToString()
                    pBar.Value = index
                    index += 1
                Next

                System.Windows.Forms.Application.DoEvents()
                ' FormProgreso.Close()

                pnPBar.Visible = False

                'Abrir PDFs Facturas
                For Each fila As String In ListaDocumentosPDFFacturas
                    AbrirPDFFactura(fila)
                Next

                For Each fila As String In ListaDocumentosRemisiones
                    objBUTimbrado.ImprimirRemision(fila)
                Next


                Dim Mensaje As String = String.Empty
                Mensaje = ObtenerMensajeFacturacion(DocumentosGenerados, DocumentosErrorTimbrado, CorreosNoEnviados)
                btnImprimir.Enabled = False
                lblImprimir.Enabled = False
                BanderaImprimir = True

                Dim DocumentoTimbrado As String = String.Empty
                'Envia la informacion a un historico de timbrado
                For Each FilaTimbrado As Integer In ListaDocumentos
                    If DocumentoTimbrado = String.Empty Then
                        DocumentoTimbrado = FilaTimbrado
                    Else
                        DocumentoTimbrado &= "," & FilaTimbrado
                    End If
                Next


                'Mostrar los documentos no timbrados
                If DocumentosErrorTimbrado > 0 Then
                    Dim form As New ErroresTimbradoForm
                    form.DocumentoID = DocumentoNoTimbrados
                    form.TipoComprobante = "FACTURACALZADO"
                    form.Show()
                End If


                'objBU.EnviarHistoricoTimbrado(DocumentoTimbrado)
                show_message("Exito", "Se generaron exitosamente " & (ListaDocumentos.Count).ToString & " documentos: " & vbCrLf & Mensaje)
                objBU.limpiarSesionFacturacion(sesionFacturacionId)
                Cursor = Cursors.Default

            End If

        Catch ex As Exception
            show_message("Error", "Ocurrio un error al generar el documento.")
            ' BorrarDocumentos(ListaDocumentos)
            Cursor = Cursors.Default
        End Try

        ListaDocumentos.Clear()

    End Sub

    Private Function ObtenerMensajeFacturacion(ByVal DocumentosGeneradosID As String, ByVal ErroresTimbrado As Integer, ByVal CorreoNoEnviado As Integer) As String
        Dim Mensaje As String = String.Empty
        Dim Facturas As String = String.Empty
        Dim Remisiones As String = String.Empty
        Dim dtMensajeria As DataTable
        Dim NumeroRemisionesFacturas As Integer = 0
        Dim NumeroResmisiones As Integer = 0
        Dim NumeroFacturas As Integer = 0

        dtMensajeria = objBU.ConsultarFoliosFacturasYRemisiones(DocumentosGeneradosID)

        If dtMensajeria.Rows.Count > 0 Then
            Facturas = dtMensajeria.Rows(0).Item("Facturas")
            Remisiones = dtMensajeria.Rows(0).Item("Remisiones")
            NumeroRemisionesFacturas = dtMensajeria.Rows(0).Item("NumeroRemisionesFacturas")
            NumeroResmisiones = dtMensajeria.Rows(0).Item("NumeroRemisiones")
            NumeroFacturas = dtMensajeria.Rows(0).Item("NumeroFacturas")
        End If



        If NumeroRemisionesFacturas > 10 Then
            If NumeroFacturas > 0 Then
                Mensaje = "Facturas: " & NumeroFacturas.ToString()
            End If

            If NumeroResmisiones > 0 Then
                Mensaje &= "Remisiones: " & NumeroResmisiones.ToString()
            End If
        Else
            If Facturas.Trim() <> String.Empty Then
                Mensaje = "Facturas: " & Facturas.Trim & vbCrLf
            End If

            If Remisiones.Trim() <> String.Empty Then
                Mensaje &= "Remisiones: " & Remisiones.Trim()
            End If
        End If

        If ErroresTimbrado > 0 Then
            Mensaje &= "Documentos no Timbrados: " & ErroresTimbrado.ToString() & vbCrLf
        End If

        If CorreoNoEnviado > 0 Then
            Mensaje &= " Correos no enviados : " & CorreoNoEnviado.ToString()
        End If


        Return Mensaje

    End Function


    'Private Function ObtenerMensajeFacturacion(ByVal ListaFacturas As List(Of String), ByVal ListaRemisiones As List(Of String)) As String
    '    Dim Mensaje As String = String.Empty
    '    Dim Facturas As String = String.Empty
    '    Dim Remisiones As String = String.Empty

    '    If (ListaFacturas.Count + ListaRemisiones.Count) <= 10 Then
    '        For Each fila As String In ListaFacturas
    '            If Facturas = String.Empty Then
    '                Facturas = fila
    '            Else
    '                Facturas &= ", " & fila
    '            End If
    '        Next

    '        For Each Fila As String In ListaRemisiones
    '            If Remisiones = String.Empty Then
    '                Remisiones = Fila
    '            Else
    '                Remisiones &= "," & Fila
    '            End If
    '        Next
    '    End If

    '    If (ListaFacturas.Count + ListaRemisiones.Count) > 10 Then
    '        If ListaFacturas.Count > 0 Then
    '            Mensaje = "Facturas: " & ListaFacturas.Count.ToString & vbCrLf
    '        End If

    '        If ListaRemisiones.Count > 0 Then
    '            Mensaje &= "Remisiones: " & ListaRemisiones.Count.ToString
    '        End If
    '    Else
    '        If ListaFacturas.Count > 0 Then
    '            Mensaje = "Facturas: " & Facturas & vbCrLf
    '        End If

    '        If ListaRemisiones.Count > 0 Then
    '            Mensaje &= "Remisiones: " & Remisiones
    '        End If

    '    End If




    '    Return Mensaje
    'End Function

    Private Sub BorrarDocumentos(ByVal ListaDocumentos As List(Of String))
        For Each Fila As String In ListaDocumentos
            DocumentoTemporalID = Fila
            objBU.BorrarDatosDocumento(Fila)
        Next
    End Sub

    Private Function ExisteCelda(ByVal sourceRowIndex As Integer, ByVal col As GridColumn) As Boolean
        'Dim Resultado As GridCell = listCeldasModificadasPrecio.Where(Function(c) c.Column Is col AndAlso c.RowHandle = sourceRowIndex).FirstOrDefault()
        'Return Resultado IsNot Nothing
        Dim respuesta As Boolean = False
        'Dim Celda As GridCell = New GridCell(sourceRowIndex, col)

        For Each renglon As DataRow In dtCeldasModificadasPrecio.Rows
            If renglon.Item("IdDocumento") = DocumentoTemporalID Then
                If renglon.Item("Renglon") = sourceRowIndex And renglon.Item("Columna") = col.FieldName Then
                    respuesta = True
                End If
            End If
        Next

        Return respuesta
    End Function

    Private Sub bgvDetallesDocumento_RowCellStyle(sender As Object, e As Grid.RowCellStyleEventArgs) Handles bgvDetallesDocumento.RowCellStyle
        If e.Column.FieldName = "Descripcion" Then
            If ExisteCelda(bgvDetallesDocumento.GetDataSourceRowIndex(e.RowHandle), e.Column) Then
                e.Appearance.ForeColor = lblDescripcionModificada.ForeColor
                e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
            End If
        Else
            If ExisteCelda(bgvDetallesDocumento.GetDataSourceRowIndex(e.RowHandle), e.Column) Then
                e.Appearance.ForeColor = lblPreciosModificados.ForeColor
                e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
            End If
        End If
    End Sub

    Private Sub txtNumCajas_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumCajas.KeyDown
        If e.KeyValue = 13 Then
            actualizarCajasYMensajes(If(txtNumCajas.Text = "", 0, Integer.Parse(txtNumCajas.Text)), txtMensaje.Text, txtObservaciones.Text, DocumentoTemporalID)
            If txtNumCajas.Text = "" Then
                txtNumCajas.Text = "0"
            End If
        End If
    End Sub

    Private Sub txtOC_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOC.KeyDown
        If e.KeyValue = 13 Then
            Cursor = Cursors.WaitCursor
            If txtOC.Text <> "" Then
                objBU.actualizaTiendaPorDocumento(DocumentoTemporalID, tiendaImprimir, txtOC.Text)
                actualizarTiendaYOCEnPantalla(tiendaImprimir, txtTienda.Text, txtOC.Text, DocumentoTemporalID)
                btnImprimir.Enabled = True
                lblOC.ForeColor = Color.Black
            Else
                show_message("Advertencia", "El dato OC no puede quedar vacío.")
                btnImprimir.Enabled = False
                lblOC.ForeColor = Color.Red
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ImprimirRemision(ByVal DocumentoID As Integer)
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim dtRemision As New DataSet("dtRemision")
        Dim ReporteRemision As New StiReport
        Dim dtInformacionPares As New DataTable
        Dim tool As New Tools.Controles
        Dim entReporte As New Entidades.Reportes
        Dim dtInformacionParesAux As New DataTable
        Dim dtInformacionEncabezado As DataTable
        Dim Docenas As String = String.Empty
        Dim Pares As String = String.Empty
        Dim SubTotal As String = String.Empty
        Dim Descuento As String = String.Empty
        Dim Total As String = String.Empty
        Dim RemissionId As String = String.Empty
        Dim Cliente As String = String.Empty
        Dim OrdenTrabajo As String = String.Empty
        Dim Notas As String = String.Empty
        Dim MensajeImportante As String = String.Empty

        Dim DocumentoValido As Boolean = False
        Try

            Cursor = Cursors.WaitCursor

            With dtInformacionPares
                .Columns.Add("Cantidad")
                .Columns.Add("Descripcion")
                .Columns.Add("Descripcion2")
                .Columns.Add("Corrida")
                .Columns.Add("Estilo")
                .Columns.Add("Precio")
                .Columns.Add("Importe")
            End With

            entReporte = objReporte.LeerReporteporClave("FACT_REMISION")

            dtInformacionParesAux = objBU.ObtenerInformacionParesImpresion(DocumentoID)
            dtInformacionEncabezado = objBU.ObtenerInformacionEncabezadoImpresion(DocumentoID)


            If IsNothing(dtInformacionEncabezado) = False Then
                If dtInformacionEncabezado.Rows.Count > 0 Then
                    Docenas = Double.Parse(dtInformacionEncabezado.Rows(0).Item("Docenas")).ToString("F2")
                    Pares = dtInformacionEncabezado.Rows(0).Item("Pares")
                    SubTotal = dtInformacionEncabezado.Rows(0).Item("SubTotal")
                    Descuento = dtInformacionEncabezado.Rows(0).Item("Descuento")
                    Total = dtInformacionEncabezado.Rows(0).Item("Total")
                    RemissionId = dtInformacionEncabezado.Rows(0).Item("RemisionID")
                    Cliente = dtInformacionEncabezado.Rows(0).Item("Cliente")
                    OrdenTrabajo = dtInformacionEncabezado.Rows(0).Item("OrdenTrabajo")
                    Notas = dtInformacionEncabezado.Rows(0).Item("Notas")
                    MensajeImportante = dtInformacionEncabezado.Rows(0).Item("Mensaje")
                    DocumentoValido = True
                End If
            End If

            If DocumentoValido = True Then
                For Each Fila As DataRow In dtInformacionParesAux.Rows
                    dtInformacionPares.Rows.Add(Fila.Item("Cantidad"), Fila.Item("Descripcion"), Fila.Item("PielColor"), Fila.Item("Corrida"), Fila.Item("Estilo"), Fila.Item("Precio"), Fila.Item("Importe"))
                Next

                dtInformacionPares.TableName = "dtContenidoRemision"
                dtRemision.Tables.Add(dtInformacionPares)

                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)

                Dim Fecha As String = String.Empty



                ReporteRemision.Load(archivo)
                ReporteRemision.Compile()
                ReporteRemision.RegData(dtRemision)
                'reporteUnaTiendaConCita("RutaImagen") = Tools.Controles.ObtenerLogoNave(43)
                ReporteRemision("Docenas") = Docenas
                ReporteRemision("Orden") = OrdenTrabajo
                ReporteRemision("SubTotal") = SubTotal
                ReporteRemision("Descuento") = Descuento
                ReporteRemision("Pares") = Pares
                ReporteRemision("Total") = Total
                ReporteRemision("Fecha") = FormatoFechaImpresion()
                ReporteRemision("IdRemision") = RemissionId
                ReporteRemision("Nota") = Notas
                ReporteRemision("MensajeImportante") = MensajeImportante
                ReporteRemision("Nombre") = Cliente
                ReporteRemision.Dictionary.Clear()
                ReporteRemision.Dictionary.Synchronize()
                'ReporteRemision.Render()
                ReporteRemision.Show()

            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Function FormatoFechaImpresion() As String
        Dim FormatoFecha As String = String.Empty
        FormatoFecha = Date.Now.Day.ToString & "-" & ObtenerMes(Date.Now.Month) & "-" & Date.Now.Year.ToString
        Return FormatoFecha
    End Function

    Private Function ObtenerMes(ByVal Mes As Integer)
        Dim NombreMes As String = String.Empty
        Select Case Mes
            Case 1
                NombreMes = "Ene"
            Case 2
                NombreMes = "Feb"
            Case 3
                NombreMes = "Mar"
            Case 4
                NombreMes = "Abr"
            Case 5
                NombreMes = "May"
            Case 6
                NombreMes = "Jun"
            Case 7
                NombreMes = "Jul"
            Case 8
                NombreMes = "Ago"
            Case 9
                NombreMes = "Sep"
            Case 10
                NombreMes = "Oct"
            Case 11
                NombreMes = "Nov"
            Case 12
                NombreMes = "Dic"
        End Select

        Return NombreMes

    End Function

    Private Function GenerarAddendaCOPPEL(ByVal DocumentoID As Integer) As String
        Dim Resultado As String = String.Empty
        Dim result As String = String.Empty
        Dim dtAddendaEncabezado As DataTable
        Dim ListaDetallesAddenda As List(Of Entidades.AddendaDetalles)
        Dim myXmlTextWriter As XmlTextWriter
        dtAddendaEncabezado = objBU.ObtenerEncabezadoAddenda(DocumentoID)
        ListaDetallesAddenda = objBU.ObtenerDetalleAddenda(DocumentoID)



        Dim index As Integer = 0

        Try
            If System.IO.Directory.Exists("C:\Arc_Sync\") = False Then
                System.IO.Directory.CreateDirectory("C:\Arc_Sync\")
            End If

            myXmlTextWriter = New XmlTextWriter("C:\Arc_Sync\addenda2.xml", System.Text.Encoding.UTF8)
            myXmlTextWriter.Formatting = System.Xml.Formatting.Indented
            myXmlTextWriter.WriteStartDocument(False)

            myXmlTextWriter.WriteStartElement("NewDataSet")

            myXmlTextWriter.WriteStartElement("cfdi:Complemento")
            myXmlTextWriter.WriteElementString("gtin", "")
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.WriteStartElement("cfdi:Addenda")

            AgregarFilaItem(myXmlTextWriter, ListaDetallesAddenda)

            myXmlTextWriter.WriteEndElement()
            myXmlTextWriter.WriteEndElement()
            myXmlTextWriter.Flush()
            myXmlTextWriter.Close()


        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
            myXmlTextWriter.Flush()
            myXmlTextWriter.Close()
        End Try


        Return Resultado
    End Function

    Private Sub AgregarFilaItem(ByRef XML As XmlTextWriter, ByVal ListaItems As List(Of Entidades.AddendaDetalles))

        Dim Fila As Integer = 0


        For Each Item As Entidades.AddendaDetalles In ListaItems
            Fila += 1


            XML.WriteStartElement("lineItem")
            XML.WriteAttributeString("type", "SimpleInvoiceLineItemType")
            XML.WriteAttributeString("number", Fila.ToString())

            XML.WriteStartElement("tradeItemIdentification")
            XML.WriteElementString("gtin", "")
            XML.WriteEndElement()

            XML.WriteStartElement("alternateTradeItemIdentification")
            XML.WriteAttributeString("type", "BUYER_ASSIGNED")
            XML.WriteEndElement()


            'XML.WriteElementString("alternateTradeItemIdentification", "")
            'XML.WriteAttributeString("type", "BUYER_ASSIGNED")



            XML.WriteStartElement("codigoTallaInternoCop")
            XML.WriteElementString("codigo", Item.Codigo.ToString)
            XML.WriteElementString("talla", Item.Calce.ToString)
            XML.WriteEndElement()

            XML.WriteStartElement("tradeItemDescriptionInformation")
            XML.WriteElementString("longText", "----")
            XML.WriteEndElement()

            XML.WriteStartElement("invoicedQuantity")
            XML.WriteAttributeString("unitOfMeasure", "CA")
            XML.WriteEndElement()


            'XML.WriteElementString("invoicedQuantity", "----")
            'XML.WriteAttributeString("unitOfMeasure", "CA")

            XML.WriteStartElement("grossPrice")
            XML.WriteElementString("Amount", "----")
            XML.WriteEndElement()

            XML.WriteStartElement("netPrice")
            XML.WriteElementString("Amount", "----")
            XML.WriteEndElement()

            XML.WriteStartElement("tradeItemTaxInformation")
            XML.WriteElementString("taxTypeDescription", "VAT")

            XML.WriteStartElement("tradeItemTaxAmount")
            XML.WriteElementString("taxPercentage", "----")
            XML.WriteElementString("taxAmount", "----")
            XML.WriteEndElement()
            XML.WriteEndElement()


            XML.WriteStartElement("palletInformation")
            XML.WriteElementString("description", "----")
            XML.WriteStartElement("transport")
            XML.WriteElementString("methodOfPayment", "----")
            XML.WriteElementString("prepactCant", "----")
            XML.WriteEndElement()
            XML.WriteEndElement()



            XML.WriteStartElement("allowanceCharge")
            XML.WriteAttributeString("allowanceChargeType", "ALLOWANCE_GLOBAL")
            XML.WriteElementString("specialServicesType", "----")
            XML.WriteStartElement("monetaryAmountOrPercentage")
            XML.WriteElementString("percentagePerUnit", "----")
            XML.WriteStartElement("ratePerUnit")
            XML.WriteElementString("amountPerUnit", "----")
            XML.WriteEndElement()
            XML.WriteEndElement()
            XML.WriteEndElement()

            XML.WriteStartElement("totalLineAmount")
            XML.WriteStartElement("grossAmount")
            XML.WriteElementString("Amount", "----")
            XML.WriteEndElement()
            XML.WriteStartElement("netAmount")
            XML.WriteElementString("Amount", "----")
            XML.WriteEndElement()
            XML.WriteEndElement()


            XML.WriteEndElement()
        Next



    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)
        '  GenerarAddendaCOPPEL(323)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        'Dim doc As New XmlDocument()
        'doc.Load("C:\Arc_Sync\addenda2.xml")
        'Dim xmlmanager As System.Xml.XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)
        'xmlmanager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
        'xmlmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
        'Dim Fila As Integer = 0
        'Dim nodo As XmlNode = doc.SelectSingleNode("/NewDataSet", xmlmanager)
        'Dim item As XmlElement = doc.CreateElement("cfdi:Addenda", xmlmanager.LookupNamespace("cfdi"))
        'Dim ListaItems As New List(Of Entidades.AddendaDetalles)
        'ListaItems = objBU.ObtenerDetalleAddenda(208)

        'Dim requestForPayment As XmlElement = doc.CreateElement("requestForPayment")
        'requestForPayment.SetAttribute("type", "SimpleInvoiceType")
        'requestForPayment.SetAttribute("contentVersion", "1.0")
        'requestForPayment.SetAttribute("documentStructureVersion", "CPLR1.0")
        'requestForPayment.SetAttribute("documentStatus", "ORIGINAL")
        'requestForPayment.SetAttribute("DeliveryDate", "20170821") 'Modifcar

        'Dim requestForPaymentIdentification As XmlElement = doc.CreateElement("requestForPaymentIdentification")
        'Dim entityType As XmlElement = doc.CreateElement("entityType")
        'entityType.InnerText = "INVOICE"
        'Dim uniqueCreatorIdentification As XmlElement = doc.CreateElement("uniqueCreatorIdentification")
        'uniqueCreatorIdentification.InnerText = "AA41259" 'Modificar

        'requestForPaymentIdentification.AppendChild(entityType)
        'requestForPaymentIdentification.AppendChild(uniqueCreatorIdentification)

        'requestForPayment.AppendChild(requestForPaymentIdentification)

        'Dim specialInstruction As XmlElement = doc.CreateElement("specialInstruction")
        'specialInstruction.SetAttribute("code", "ZZZ")

        'Dim text As XmlElement = doc.CreateElement("text")
        'text.InnerText = "-------------------" ' Modificar

        'specialInstruction.AppendChild(text)
        'requestForPayment.AppendChild(specialInstruction)


        'Dim orderIdentification As XmlElement = doc.CreateElement("orderIdentification")

        'Dim referenceIdentification As XmlElement = doc.CreateElement("referenceIdentification")
        'referenceIdentification.SetAttribute("type", "ON")
        'referenceIdentification.InnerText = "------" 'Modifcar

        'orderIdentification.AppendChild(referenceIdentification)
        'requestForPayment.AppendChild(orderIdentification)

        'Dim AdditionalInformation As XmlElement = doc.CreateElement("AdditionalInformation")

        'Dim AdditionalreferenceIdentification As XmlElement = doc.CreateElement("referenceIdentification")
        'AdditionalreferenceIdentification.SetAttribute("type", "ON")
        'AdditionalreferenceIdentification.InnerText = "---" 'Modificar

        'AdditionalInformation.AppendChild(AdditionalreferenceIdentification)
        'requestForPayment.AppendChild(AdditionalInformation)

        'Dim buyer As XmlElement = doc.CreateElement("buyer")
        'Dim gln As XmlElement = doc.CreateElement("gln")
        'gln.InnerText = "---" 'Modifcar

        'buyer.AppendChild(gln)
        'requestForPayment.AppendChild(buyer)

        'Dim seller As XmlElement = doc.CreateElement("seller")
        'Dim sellergln As XmlElement = doc.CreateElement("gln")
        'sellergln.InnerText = "----" 'Modifcar
        'Dim selleralternatePartyIdentification As XmlElement = doc.CreateElement("alternatePartyIdentification")
        'selleralternatePartyIdentification.SetAttribute("type", "SELLER_ASSIGNED_IDENTIFIER_FOR_A_PARTY")
        'selleralternatePartyIdentification.InnerText = "----" 'Modifcar

        'Dim sellerIndentificaTipoProv As XmlElement = doc.CreateElement("IndentificaTipoProv")
        'sellerIndentificaTipoProv.InnerText = "----" 'Modificar

        'seller.AppendChild(sellergln)
        'seller.AppendChild(selleralternatePartyIdentification)
        'seller.AppendChild(sellerIndentificaTipoProv)

        'requestForPayment.AppendChild(seller)

        'Dim shipTo As XmlElement = doc.CreateElement("shipTo")
        'Dim shipTogln As XmlElement = doc.CreateElement("gln")
        'shipTogln.InnerText = "---" 'Modificar

        'Dim shipTonameAndAddress As XmlElement = doc.CreateElement("nameAndAddress")
        'Dim shipToname As XmlElement = doc.CreateElement("name")
        'Dim shipTostreetAddressOne As XmlElement = doc.CreateElement("streetAddressOne")
        'Dim shipTostreetcity As XmlElement = doc.CreateElement("city")
        'Dim shipTopostalCode As XmlElement = doc.CreateElement("postalCode")
        'Dim shipTobodegaEnt As XmlElement = doc.CreateElement("bodegaEnt")
        'shipTobodegaEnt.InnerText = "21" 'Modifcar

        'shipTonameAndAddress.AppendChild(shipToname)
        'shipTonameAndAddress.AppendChild(shipTostreetAddressOne)
        'shipTonameAndAddress.AppendChild(shipTostreetcity)
        'shipTonameAndAddress.AppendChild(shipTopostalCode)
        'shipTonameAndAddress.AppendChild(shipTobodegaEnt)

        'shipTo.AppendChild(shipTogln)
        'shipTo.AppendChild(shipTonameAndAddress)
        'requestForPayment.AppendChild(shipTo)

        'Dim currency As XmlElement = doc.CreateElement("currency")
        'currency.SetAttribute("currencyISOCode", "MXN")

        'Dim currencyFunction As XmlElement = doc.CreateElement("currencyFunction")
        'currencyFunction.InnerText = "PAYMENT_CURRENCY"
        'Dim rateOfChange As XmlElement = doc.CreateElement("rateOfChange")
        'rateOfChange.InnerText = "13" 'Modificar

        'currency.AppendChild(currencyFunction)
        'currency.AppendChild(rateOfChange)
        'requestForPayment.AppendChild(currency)

        'Dim TotalLotes As XmlElement = doc.CreateElement("TotalLotes")
        'Dim TotalLotescantidad As XmlElement = doc.CreateElement("cantidad")
        'TotalLotescantidad.InnerText = "---" 'Modificar

        'TotalLotes.AppendChild(TotalLotescantidad)
        'requestForPayment.AppendChild(TotalLotes)

        'For Each ItemAddenda As Entidades.AddendaDetalles In ListaItems
        '    Fila += 1
        '    Dim lineItem As XmlElement = doc.CreateElement("lineItem")
        '    lineItem.SetAttribute("type", "SimpleInvoiceLineItemType")
        '    lineItem.SetAttribute("number", Fila.ToString())

        '    Dim tItemIdentificador As XmlElement = doc.CreateElement("tradeItemIdentification")
        '    Dim tItemIdentificadorgtin As XmlElement = doc.CreateElement("gtin")
        '    tItemIdentificadorgtin.InnerText = ""

        '    tItemIdentificador.AppendChild(tItemIdentificadorgtin)
        '    lineItem.AppendChild(tItemIdentificador)

        '    Dim alternateTradeItemIdentification As XmlElement = doc.CreateElement("alternateTradeItemIdentification")
        '    alternateTradeItemIdentification.SetAttribute("type", "BUYER_ASSIGNED")
        '    lineItem.AppendChild(alternateTradeItemIdentification)

        '    Dim codigoTallaInternoCop As XmlElement = doc.CreateElement("codigoTallaInternoCop")
        '    Dim codigo As XmlElement = doc.CreateElement("codigo")
        '    codigo.InnerText = "----"
        '    Dim talla As XmlElement = doc.CreateElement("talla")
        '    talla.InnerText = "----"
        '    codigoTallaInternoCop.AppendChild(codigo)
        '    codigoTallaInternoCop.AppendChild(talla)

        '    lineItem.AppendChild(codigoTallaInternoCop)

        '    Dim tradeItemDescriptionInformation As XmlElement = doc.CreateElement("tradeItemDescriptionInformation")
        '    Dim longText As XmlElement = doc.CreateElement("longText")
        '    longText.InnerText = "--"
        '    tradeItemDescriptionInformation.AppendChild(longText)
        '    lineItem.AppendChild(tradeItemDescriptionInformation)

        '    Dim invoicedQuantity As XmlElement = doc.CreateElement("invoicedQuantity")
        '    invoicedQuantity.SetAttribute("unitOfMeasure", "CA")
        '    invoicedQuantity.InnerText = "---"
        '    lineItem.AppendChild(invoicedQuantity)

        '    Dim grossPrice As XmlElement = doc.CreateElement("grossPrice")
        '    Dim grossPriceAmount As XmlElement = doc.CreateElement("Amount")
        '    grossPriceAmount.InnerText = "---"
        '    grossPrice.AppendChild(grossPriceAmount)
        '    lineItem.AppendChild(grossPrice)

        '    Dim netPrice As XmlElement = doc.CreateElement("netPrice")
        '    Dim netPriceAmount As XmlElement = doc.CreateElement("Amount")
        '    netPriceAmount.InnerText = "---"
        '    netPrice.AppendChild(netPriceAmount)
        '    lineItem.AppendChild(netPrice)

        '    Dim tradeItemTaxInformation As XmlElement = doc.CreateElement("tradeItemTaxInformation")
        '    Dim taxTypeDescription As XmlElement = doc.CreateElement("taxTypeDescription")
        '    taxTypeDescription.InnerText = "VAT"
        '    tradeItemTaxInformation.AppendChild(taxTypeDescription)

        '    Dim tradeItemTaxAmount As XmlElement = doc.CreateElement("tradeItemTaxAmount")
        '    Dim taxPercentage As XmlElement = doc.CreateElement("taxPercentage")
        '    taxPercentage.InnerText = "---"
        '    Dim taxAmount As XmlElement = doc.CreateElement("taxAmount")
        '    taxAmount.InnerText = "---"
        '    tradeItemTaxAmount.AppendChild(taxPercentage)
        '    tradeItemTaxAmount.AppendChild(taxAmount)
        '    tradeItemTaxInformation.AppendChild(tradeItemTaxAmount)
        '    lineItem.AppendChild(tradeItemTaxInformation)


        '    Dim palletInformation As XmlElement = doc.CreateElement("palletInformation")
        '    Dim palletInformationdescription As XmlElement = doc.CreateElement("description")
        '    palletInformationdescription.SetAttribute("type", "BOX")
        '    palletInformationdescription.InnerText = "----"
        '    Dim transport As XmlElement = doc.CreateElement("transport")
        '    Dim methodOfPayment As XmlElement = doc.CreateElement("methodOfPayment")
        '    methodOfPayment.InnerText = "---"
        '    Dim prepactCant As XmlElement = doc.CreateElement("prepactCant")
        '    prepactCant.InnerText = "---"
        '    transport.AppendChild(methodOfPayment)
        '    transport.AppendChild(prepactCant)
        '    palletInformation.AppendChild(palletInformationdescription)
        '    palletInformation.AppendChild(transport)

        '    lineItem.AppendChild(palletInformation)

        '    Dim allowanceCharge As XmlElement = doc.CreateElement("allowanceCharge")
        '    allowanceCharge.SetAttribute("allowanceChargeType", "ALLOWANCE_GLOBAL")

        '    Dim specialServicesType As XmlElement = doc.CreateElement("specialServicesType")
        '    specialServicesType.InnerText = "----"
        '    allowanceCharge.AppendChild(specialServicesType)

        '    Dim monetaryAmountOrPercentage As XmlElement = doc.CreateElement("monetaryAmountOrPercentage")

        '    Dim percentagePerUnit As XmlElement = doc.CreateElement("percentagePerUnit")
        '    percentagePerUnit.InnerText = "---"

        '    monetaryAmountOrPercentage.AppendChild(percentagePerUnit)

        '    Dim ratePerUnit As XmlElement = doc.CreateElement("ratePerUnit")
        '    Dim amountPerUnit As XmlElement = doc.CreateElement("amountPerUnit")
        '    amountPerUnit.InnerText = "---"


        '    ratePerUnit.AppendChild(amountPerUnit)            
        '    monetaryAmountOrPercentage.AppendChild(ratePerUnit)
        '    allowanceCharge.AppendChild(monetaryAmountOrPercentage)
        '    lineItem.AppendChild(allowanceCharge)


        '    Dim totalLineAmount As XmlElement = doc.CreateElement("totalLineAmount")
        '    Dim grossAmount As XmlElement = doc.CreateElement("grossAmount")
        '    Dim grossAmountAmount As XmlElement = doc.CreateElement("grossAmount")
        '    grossAmountAmount.InnerText = "---"
        '    grossAmount.AppendChild(grossAmountAmount)
        '    Dim netAmount As XmlElement = doc.CreateElement("netAmount")
        '    Dim netAmountAmount As XmlElement = doc.CreateElement("Amount")
        '    netAmountAmount.InnerText = "---"
        '    netAmount.AppendChild(netAmountAmount)
        '    totalLineAmount.AppendChild(grossAmount)
        '    totalLineAmount.AppendChild(netAmount)


        '    lineItem.AppendChild(totalLineAmount)            
        '    requestForPayment.AppendChild(lineItem)


        'Next

        'item.AppendChild(requestForPayment)        
        'nodo.AppendChild(item)
        'doc.Save("C:\Arc_Sync\addenda2.xml")



    End Sub

    Private Sub GenerarAddendaCOPPEL(ByVal DocumentoID As Integer, ByVal TipoComprobante As String)

        'Dim doc As New XmlDocument()
        'Dim RutaXML As String = String.Empty
        'RutaXML = objBU.ObtenerRutaXMLFactura(DocumentoID)
        'doc.Load(RutaXML)
        'Dim xmlmanager As System.Xml.XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)
        'xmlmanager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
        'xmlmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
        'Dim Fila As Integer = 0
        'Dim nodo As XmlNode = doc.SelectSingleNode("/cfdi:Comprobante", xmlmanager)
        'Dim item As XmlElement = doc.CreateElement("cfdi:Addenda", xmlmanager.LookupNamespace("cfdi"))
        'Dim ListaItems As New List(Of Entidades.AddendaDetalles)
        'Dim objAddendaEnc As New Entidades.Addenda
        'Dim FechaVacia As Date = Nothing

        'ListaItems = objBU.ObtenerDetalleAddenda(DocumentoID)
        'objAddendaEnc = objBU.ConsultarEncabezadoAddendaCOPPEL(DocumentoID)

        'Dim requestForPayment As XmlElement = doc.CreateElement("requestForPayment")
        'requestForPayment.SetAttribute("type", "SimpleInvoiceType")
        'requestForPayment.SetAttribute("contentVersion", "1.0")
        'requestForPayment.SetAttribute("documentStructureVersion", "CPLR1.0")
        'requestForPayment.SetAttribute("documentStatus", "ORIGINAL")

        'Dim MesDocumento As String = ""
        'Dim DiaDocumento As String = ""

        'If objAddendaEnc.FechaCaptura = FechaVacia Then
        '    requestForPayment.SetAttribute("DeliveryDate", "------") 'Modifcar
        'Else
        '    If Month(objAddendaEnc.FechaCaptura) <= 9 Then
        '        MesDocumento = "0" + Month(objAddendaEnc.FechaCaptura).ToString()
        '    Else
        '        MesDocumento = Month(objAddendaEnc.FechaCaptura).ToString()
        '    End If

        '    If objAddendaEnc.FechaCaptura.Day <= 9 Then
        '        DiaDocumento = "0" + objAddendaEnc.FechaCaptura.Day.ToString()
        '    Else
        '        DiaDocumento = objAddendaEnc.FechaCaptura.Day.ToString()
        '    End If
        '    requestForPayment.SetAttribute("DeliveryDate", Year(objAddendaEnc.FechaCaptura).ToString + MesDocumento + DiaDocumento) 'Modifcar
        'End If



        'Dim requestForPaymentIdentification As XmlElement = doc.CreateElement("requestForPaymentIdentification")
        'Dim entityType As XmlElement = doc.CreateElement("entityType")
        'entityType.InnerText = "INVOICE"
        'Dim uniqueCreatorIdentification As XmlElement = doc.CreateElement("uniqueCreatorIdentification")
        'uniqueCreatorIdentification.InnerText = objAddendaEnc.SerieFactura.ToString() + objAddendaEnc.FolioFactura.ToString()

        'requestForPaymentIdentification.AppendChild(entityType)
        'requestForPaymentIdentification.AppendChild(uniqueCreatorIdentification)

        'requestForPayment.AppendChild(requestForPaymentIdentification)

        'Dim specialInstruction As XmlElement = doc.CreateElement("specialInstruction")
        'specialInstruction.SetAttribute("code", "ZZZ")

        'Dim text As XmlElement = doc.CreateElement("text")
        'text.InnerText = objAddendaEnc.MontoTotalLetra.Trim()

        'specialInstruction.AppendChild(text)
        'requestForPayment.AppendChild(specialInstruction)


        'Dim orderIdentification As XmlElement = doc.CreateElement("orderIdentification")

        'Dim referenceIdentification As XmlElement = doc.CreateElement("referenceIdentification")
        'referenceIdentification.SetAttribute("type", "ON")
        'referenceIdentification.InnerText = objAddendaEnc.OrdenCompra.ToString()

        'orderIdentification.AppendChild(referenceIdentification)
        'requestForPayment.AppendChild(orderIdentification)

        'Dim AdditionalInformation As XmlElement = doc.CreateElement("AdditionalInformation")

        'Dim AdditionalreferenceIdentification As XmlElement = doc.CreateElement("referenceIdentification")
        'AdditionalreferenceIdentification.SetAttribute("type", "ON")
        'AdditionalreferenceIdentification.InnerText = objAddendaEnc.OrdenCompra


        'AdditionalInformation.AppendChild(AdditionalreferenceIdentification)
        'requestForPayment.AppendChild(AdditionalInformation)

        'Dim buyer As XmlElement = doc.CreateElement("buyer")
        'Dim gln As XmlElement = doc.CreateElement("gln")
        'gln.InnerText = "7504004086006"

        'buyer.AppendChild(gln)
        'requestForPayment.AppendChild(buyer)

        'Dim seller As XmlElement = doc.CreateElement("seller")
        'Dim sellergln As XmlElement = doc.CreateElement("gln")
        'sellergln.InnerText = "7501234567890"
        'Dim selleralternatePartyIdentification As XmlElement = doc.CreateElement("alternatePartyIdentification")
        'selleralternatePartyIdentification.SetAttribute("type", "SELLER_ASSIGNED_IDENTIFIER_FOR_A_PARTY")
        'selleralternatePartyIdentification.InnerText = "38679"

        'Dim sellerIndentificaTipoProv As XmlElement = doc.CreateElement("IndentificaTipoProv")
        'sellerIndentificaTipoProv.InnerText = "2"

        'seller.AppendChild(sellergln)
        'seller.AppendChild(selleralternatePartyIdentification)
        'seller.AppendChild(sellerIndentificaTipoProv)

        'requestForPayment.AppendChild(seller)

        'Dim shipTo As XmlElement = doc.CreateElement("shipTo")
        'Dim shipTogln As XmlElement = doc.CreateElement("gln")
        'shipTogln.InnerText = "0"

        'Dim shipTonameAndAddress As XmlElement = doc.CreateElement("nameAndAddress")
        'Dim shipToname As XmlElement = doc.CreateElement("name")
        'Dim shipTostreetAddressOne As XmlElement = doc.CreateElement("streetAddressOne")
        'Dim shipTostreetcity As XmlElement = doc.CreateElement("city")
        'Dim shipTopostalCode As XmlElement = doc.CreateElement("postalCode")
        'Dim shipTobodegaEnt As XmlElement = doc.CreateElement("bodegaEnt")
        'shipTobodegaEnt.InnerText = objAddendaEnc.CodigoTienda.ToString()

        'shipTonameAndAddress.AppendChild(shipToname)
        'shipTonameAndAddress.AppendChild(shipTostreetAddressOne)
        'shipTonameAndAddress.AppendChild(shipTostreetcity)
        'shipTonameAndAddress.AppendChild(shipTopostalCode)
        'shipTonameAndAddress.AppendChild(shipTobodegaEnt)

        'shipTo.AppendChild(shipTogln)
        'shipTo.AppendChild(shipTonameAndAddress)
        'requestForPayment.AppendChild(shipTo)

        'Dim currency As XmlElement = doc.CreateElement("currency")
        'currency.SetAttribute("currencyISOCode", "MXN")

        'Dim currencyFunction As XmlElement = doc.CreateElement("currencyFunction")
        'currencyFunction.InnerText = "PAYMENT_CURRENCY"
        'Dim rateOfChange As XmlElement = doc.CreateElement("rateOfChange")
        'rateOfChange.InnerText = objAddendaEnc.NumeroCajas.ToString()

        'currency.AppendChild(currencyFunction)
        'currency.AppendChild(rateOfChange)
        'requestForPayment.AppendChild(currency)

        'Dim TotalLotes As XmlElement = doc.CreateElement("TotalLotes")
        'Dim TotalLotescantidad As XmlElement = doc.CreateElement("cantidad")
        'TotalLotescantidad.InnerText = objAddendaEnc.NumeroCajas.ToString()

        'TotalLotes.AppendChild(TotalLotescantidad)
        'requestForPayment.AppendChild(TotalLotes)

        'For Each ItemAddenda As Entidades.AddendaDetalles In ListaItems
        '    Fila += 1
        '    Dim lineItem As XmlElement = doc.CreateElement("lineItem")
        '    lineItem.SetAttribute("type", "SimpleInvoiceLineItemType")
        '    lineItem.SetAttribute("number", Fila.ToString())

        '    Dim tItemIdentificador As XmlElement = doc.CreateElement("tradeItemIdentification")
        '    Dim tItemIdentificadorgtin As XmlElement = doc.CreateElement("gtin")
        '    'tItemIdentificadorgtin.InnerText = ""

        '    tItemIdentificador.AppendChild(tItemIdentificadorgtin)
        '    lineItem.AppendChild(tItemIdentificador)

        '    Dim alternateTradeItemIdentification As XmlElement = doc.CreateElement("alternateTradeItemIdentification")
        '    alternateTradeItemIdentification.SetAttribute("type", "BUYER_ASSIGNED")
        '    lineItem.AppendChild(alternateTradeItemIdentification)

        '    Dim codigoTallaInternoCop As XmlElement = doc.CreateElement("codigoTallaInternoCop")
        '    Dim codigo As XmlElement = doc.CreateElement("codigo")
        '    codigo.InnerText = ItemAddenda.SKU
        '    Dim talla As XmlElement = doc.CreateElement("talla")
        '    talla.InnerText = ItemAddenda.FormatoTalla
        '    codigoTallaInternoCop.AppendChild(codigo)
        '    codigoTallaInternoCop.AppendChild(talla)

        '    lineItem.AppendChild(codigoTallaInternoCop)

        '    Dim tradeItemDescriptionInformation As XmlElement = doc.CreateElement("tradeItemDescriptionInformation")
        '    Dim longText As XmlElement = doc.CreateElement("longText")
        '    longText.InnerText = ItemAddenda.DescripcionCte.Trim()
        '    tradeItemDescriptionInformation.AppendChild(longText)
        '    lineItem.AppendChild(tradeItemDescriptionInformation)

        '    Dim invoicedQuantity As XmlElement = doc.CreateElement("invoicedQuantity")
        '    invoicedQuantity.SetAttribute("unitOfMeasure", "CA")
        '    invoicedQuantity.InnerText = ItemAddenda.CantidadPares.ToString()
        '    lineItem.AppendChild(invoicedQuantity)

        '    Dim grossPrice As XmlElement = doc.CreateElement("grossPrice")
        '    Dim grossPriceAmount As XmlElement = doc.CreateElement("Amount")
        '    grossPriceAmount.InnerText = ItemAddenda.PrecioBruto.ToString()
        '    grossPrice.AppendChild(grossPriceAmount)
        '    lineItem.AppendChild(grossPrice)

        '    Dim netPrice As XmlElement = doc.CreateElement("netPrice")
        '    Dim netPriceAmount As XmlElement = doc.CreateElement("Amount")
        '    netPriceAmount.InnerText = ItemAddenda.PrecioNeto.ToString()
        '    netPrice.AppendChild(netPriceAmount)
        '    lineItem.AppendChild(netPrice)

        '    Dim tradeItemTaxInformation As XmlElement = doc.CreateElement("tradeItemTaxInformation")
        '    Dim taxTypeDescription As XmlElement = doc.CreateElement("taxTypeDescription")
        '    taxTypeDescription.InnerText = "VAT"
        '    tradeItemTaxInformation.AppendChild(taxTypeDescription)

        '    Dim tradeItemTaxAmount As XmlElement = doc.CreateElement("tradeItemTaxAmount")
        '    Dim taxPercentage As XmlElement = doc.CreateElement("taxPercentage")
        '    taxPercentage.InnerText = ItemAddenda.PorcentajeIVA
        '    Dim taxAmount As XmlElement = doc.CreateElement("taxAmount")
        '    taxAmount.InnerText = ItemAddenda.MontoIVA 'Porcentaje IVA
        '    tradeItemTaxAmount.AppendChild(taxPercentage)
        '    tradeItemTaxAmount.AppendChild(taxAmount)
        '    tradeItemTaxInformation.AppendChild(tradeItemTaxAmount)
        '    lineItem.AppendChild(tradeItemTaxInformation)


        '    Dim palletInformation As XmlElement = doc.CreateElement("palletInformation")
        '    Dim palletInformationdescription As XmlElement = doc.CreateElement("description")
        '    palletInformationdescription.SetAttribute("type", "BOX")
        '    palletInformationdescription.InnerText = "EMPAQUETADO"
        '    Dim transport As XmlElement = doc.CreateElement("transport")
        '    Dim methodOfPayment As XmlElement = doc.CreateElement("methodOfPayment")
        '    methodOfPayment.InnerText = "PAID_BY_BUYER"
        '    Dim prepactCant As XmlElement = doc.CreateElement("prepactCant")
        '    prepactCant.InnerText = ItemAddenda.CantidadEmpacado.ToString()
        '    transport.AppendChild(methodOfPayment)
        '    transport.AppendChild(prepactCant)
        '    palletInformation.AppendChild(palletInformationdescription)
        '    palletInformation.AppendChild(transport)

        '    lineItem.AppendChild(palletInformation)

        '    Dim allowanceCharge As XmlElement = doc.CreateElement("allowanceCharge")
        '    allowanceCharge.SetAttribute("allowanceChargeType", "ALLOWANCE_GLOBAL")

        '    Dim specialServicesType As XmlElement = doc.CreateElement("specialServicesType")
        '    specialServicesType.InnerText = "EAB"
        '    allowanceCharge.AppendChild(specialServicesType)

        '    Dim monetaryAmountOrPercentage As XmlElement = doc.CreateElement("monetaryAmountOrPercentage")

        '    Dim percentagePerUnit As XmlElement = doc.CreateElement("percentagePerUnit")
        '    percentagePerUnit.InnerText = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", ItemAddenda.PorcentajeDescuento.ToString) 'ItemAddenda.PorcentajeDescuento.ToString

        '    monetaryAmountOrPercentage.AppendChild(percentagePerUnit)

        '    Dim ratePerUnit As XmlElement = doc.CreateElement("ratePerUnit")
        '    Dim amountPerUnit As XmlElement = doc.CreateElement("amountPerUnit")
        '    amountPerUnit.InnerText = ItemAddenda.Descuento.ToString

        '    ratePerUnit.AppendChild(amountPerUnit)
        '    monetaryAmountOrPercentage.AppendChild(ratePerUnit)
        '    allowanceCharge.AppendChild(monetaryAmountOrPercentage)
        '    lineItem.AppendChild(allowanceCharge)

        '    Dim totalLineAmount As XmlElement = doc.CreateElement("totalLineAmount")
        '    Dim grossAmount As XmlElement = doc.CreateElement("grossAmount")
        '    Dim grossAmountAmount As XmlElement = doc.CreateElement("grossAmount")
        '    grossAmountAmount.InnerText = ItemAddenda.MontoBruto
        '    grossAmount.AppendChild(grossAmountAmount)
        '    Dim netAmount As XmlElement = doc.CreateElement("netAmount")
        '    Dim netAmountAmount As XmlElement = doc.CreateElement("Amount")
        '    netAmountAmount.InnerText = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", ItemAddenda.PrecioNeto * ItemAddenda.CantidadPares)
        '    netAmount.AppendChild(netAmountAmount)
        '    totalLineAmount.AppendChild(grossAmount)
        '    totalLineAmount.AppendChild(netAmount)

        '    lineItem.AppendChild(totalLineAmount)
        '    requestForPayment.AppendChild(lineItem)

        'Next


        'Dim totalAmount As XmlElement = doc.CreateElement("totalAmount")
        'Dim Amount As XmlElement = doc.CreateElement("Amount")

        'Amount.InnerText = objAddendaEnc.Importe.ToString
        'totalAmount.AppendChild(Amount)
        'requestForPayment.AppendChild(totalAmount)


        'Dim TotalAllowanceCharge As XmlElement = doc.CreateElement("TotalAllowanceCharge")
        'TotalAllowanceCharge.SetAttribute("allowanceOrChargeType", "ALLOWANCE")

        'Dim PspecialServicesType As XmlElement = doc.CreateElement("specialServicesType")
        'PspecialServicesType.InnerText = "EAB"

        'Dim TotalAllowanceChargeAmount As XmlElement = doc.CreateElement("Amount")
        'TotalAllowanceChargeAmount.InnerText = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", objAddendaEnc.Descuento)

        'TotalAllowanceCharge.AppendChild(PspecialServicesType)
        'TotalAllowanceCharge.AppendChild(TotalAllowanceChargeAmount)
        'requestForPayment.AppendChild(TotalAllowanceCharge)

        'Dim baseAmount As XmlElement = doc.CreateElement("baseAmount")
        'Dim baseAmountAmount As XmlElement = doc.CreateElement("Amount")
        'baseAmountAmount.InnerText = objAddendaEnc.Importe.ToString()

        'baseAmount.AppendChild(baseAmountAmount)
        'requestForPayment.AppendChild(baseAmount)

        'Dim tax As XmlElement = doc.CreateElement("tax")
        'tax.SetAttribute("type", "VAT")

        'Dim PtaxPercentage As XmlElement = doc.CreateElement("taxPercentage")
        'PtaxPercentage.InnerText = "16.00"

        'Dim PtaxAmount As XmlElement = doc.CreateElement("taxAmount")
        'PtaxAmount.InnerText = objAddendaEnc.TotalIVA.ToString()

        'tax.AppendChild(PtaxPercentage)
        'tax.AppendChild(PtaxAmount)
        'requestForPayment.AppendChild(tax)

        'Dim payableAmount As XmlElement = doc.CreateElement("payableAmount")
        'Dim payableAmountAmount As XmlElement = doc.CreateElement("Amount")
        'payableAmountAmount.InnerText = objAddendaEnc.MontoTotal.ToString()
        'payableAmount.AppendChild(payableAmountAmount)
        'requestForPayment.AppendChild(payableAmount)

        'item.AppendChild(requestForPayment)
        'nodo.AppendChild(item)
        'doc.Save(RutaXML)
        ''doc.Save("C:\Arc_Sync\addendaPrueba_" & DocumentoID.ToString() & ".xml")

    End Sub

    Private Sub Timbrado()
        Dim cadena As String = "Hola Mundo"
        Dim CadenaBase64 As String = String.Empty
        Dim CadenaDecodificada As String = String.Empty
        Dim CadenaOriginal As Byte()

        CadenaBase64 = Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(cadena))
        CadenaDecodificada = System.Text.Encoding.Default.GetString(Convert.FromBase64String(CadenaBase64))

        Dim reader As StreamReader = New StreamReader("")
        Dim myXpathDoc As XPathDocument = New XPathDocument(reader)

        Dim myXSLTrans As XslCompiledTransform = New XslCompiledTransform()
        myXSLTrans.Load("")

        Dim str As StringWriter = New StringWriter()
        Dim myWriter As XmlTextWriter = New XmlTextWriter(str)

        myXSLTrans.Transform(myXpathDoc, Nothing, myWriter)

        Dim result As String = str.ToString()

        '-----------------------------------------------

        CadenaOriginal = System.Text.Encoding.Default.GetBytes(cadena)

        Dim sha As New SHA1CryptoServiceProvider()
        Dim resul() As Byte
        resul = sha.ComputeHash(CadenaOriginal)

    End Sub


    'Private Sub btnBase64_Click(sender As Object, e As EventArgs) Handles btnBase64.Click
    '    'Timbrado()
    'End Sub

    Private Sub AbrirPDFFactura(ByVal RutaPDF As String)
        Try
            'Dim objFTP As New Tools.TransferenciaFTP
            'objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_Carga_Proyeccion_V1.pdf")
            Process.Start(RutaPDF)
        Catch ex As Exception
        End Try
    End Sub





    Private Function enviarCorreoFacturacionCliente(ByVal IdDocumento As Integer) As Boolean
        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String = String.Empty
        Dim dtResultadoDatosCorreos As New DataTable
        Dim remitente As String = String.Empty
        Dim correo As New Tools.Correo
        Dim cadenaCorreo As String = String.Empty
        Dim asuntoCorreo As String = String.Empty
        Dim entCorreo As New Entidades.DatosCorreo

        Dim dtDatosDocumento As New DataTable()
        Dim folioFactura As String = String.Empty
        Dim nombreCliente As String = String.Empty
        Dim rutaArchivoPDF As String = String.Empty
        Dim rutaArchivoXML As String = String.Empty
        Dim correoCliente As String = String.Empty
        Dim lstArchivoAdjuntos As New List(Of System.Net.Mail.Attachment)
        Dim archivoAdjunto As System.Net.Mail.Attachment
        Dim CorreoEnviado As String = String.Empty
        Dim objTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim entDatosFactura As New Entidades.DatosFactura
        Dim Correoexitoso As Boolean = False


        Try
            dtResultadoDatosCorreos = objBU.consultaCorreosEnvioFactura("ENVIO_FACTURAS_CLIENTES")
            dtDatosDocumento = objBU.consultaDatosDocumentoEnvioFactura(IdDocumento)


            folioFactura = dtDatosDocumento.Rows(0).Item("FolioFactura")
            nombreCliente = dtDatosDocumento.Rows(0).Item("NombreCliente")
            rutaArchivoPDF = If(IsDBNull(dtDatosDocumento.Rows(0).Item("RutaPDF")), "", dtDatosDocumento.Rows(0).Item("RutaPDF"))
            rutaArchivoXML = If(IsDBNull(dtDatosDocumento.Rows(0).Item("RutaXML")), "", dtDatosDocumento.Rows(0).Item("RutaXML"))
            correoCliente = dtDatosDocumento.Rows(0).Item("CorreoReceptor")

            remitente = dtResultadoDatosCorreos.Rows(0).Item("CorreoEnvia").ToString()
            destinatarios = dtResultadoDatosCorreos.Rows(0).Item("Destinatarios").ToString()

            'rutaArchivoPDF = "\\192.168.2.2\bin\TASFE\MafraMCV0902263W7\FACTURAS33\PDF\112017\MCV0902263W7F1FAC42781.pdf"
            'archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoPDF)
            'lstArchivoAdjuntos.Add(archivoAdjunto)

            If rutaArchivoPDF <> String.Empty Then
                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoPDF)
                lstArchivoAdjuntos.Add(archivoAdjunto)
            End If

            If rutaArchivoXML <> String.Empty Then
                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoXML)
                lstArchivoAdjuntos.Add(archivoAdjunto)
            End If

            If correoCliente <> String.Empty Then
                If destinatarios <> String.Empty Then
                    destinatarios = destinatarios & "," & correoCliente
                Else
                    destinatarios = correoCliente
                End If
            End If

            asuntoCorreo = "FACTURA " + folioFactura + " CLIENTE " + nombreCliente + ""
            cadenaCorreo = "<html> " +
                           " <head>" +
                           " </head>"
            cadenaCorreo += " <body> "
            cadenaCorreo += " <br><p>Estimado Cliente: Anexo encontrará su CFDI en formato PDF y XML.</p>"
            cadenaCorreo += " <p> Le sugerimos tomar en cuenta las siguientes consideraciones en cuanto a cancelaciones:<br>"
            cadenaCorreo += " <ol>" +
                            "<li> Cualquier cambio en facturación, ya sea por Razón Social, Domicilio Fiscal, Forma de Pago, Importe máximo de facturación etc. se realizará UNICAMENTE dentro de los primeros 7 días posteriores a la expedición de la factura; pasando este lapso de días no se harán cambios. </li>" +
                            "<li> En caso de errores en el domicilio fiscal solo verá reflejados los cambios en el archivo PDF, ya que de acuerdo a disposición del SAT en el archivo XML estos campos ya no existen. </li>" +
                            "<li> No se podrá hacer cancelaciones de facturas que ya hayan sido pagadas. </li>" +
                            "<li> No procederá la cancelación de un CFDI que se haya facturado conforme a los datos proporcionados por usted al momento de hacer su pedido. </li>" +
                            "<li> De acuerdo a lo establecido en la guía del llenado de los comprobantes fiscales del ""Anexo 20 SAT"" cuando la clave de uso registrada en el CFDI es incorrecta no será motivo de cancelación ni afectará para deducción o acreditamiento. Sin embargo, se recomienda que en el momento que se percaten del error soliciten su corrección para la siguiente facturación.</li>" +
                            "<li> No procederá hacer cancelaciones de cambios en la Clave del producto ya que está es asignada por la empresa que emite el CFDI, por lo tanto es nuestra responsabilidad que este indicada correctamente.</li>" +
                            "</ol>" +
                            "</p>"
            cadenaCorreo += " <p> Atentamente: Grupo Yuyin </p>"
            cadenaCorreo += " </body> " +
                            " </html> "

            entCorreo = correo.EnviarCorreoFacturasHtmlVariosArchivosAdjuntos(destinatarios, remitente, asuntoCorreo, cadenaCorreo, lstArchivoAdjuntos)

            Correoexitoso = entCorreo.CorreoEnviado

            If entCorreo.CorreoEnviado = True Then
                CorreoEnviado = "S"
            Else
                CorreoEnviado = "N"
            End If
            'Obtiene los datos de la factura
            entDatosFactura = objTimbrado.ConsultarInformacionDocumentoFactura(IdDocumento)

            'Actualizar Status Correo Enviado SAY
            objBU.ActualizarStatusCorreoEnviadoSAY(IdDocumento, entCorreo.CorreoEnviado)

            'Insettar los datos de envio en el SICY
            If rutaArchivoPDF <> String.Empty Then
                objBU.InsertarDatosCorreoEnviadoSICY(destinatarios, CorreoEnviado, "AUTOMATICO", asuntoCorreo, entCorreo.DescripcionStatusCorreo, entDatosFactura.RemisionID, "PDF", False)
            End If

            If rutaArchivoXML <> String.Empty Then
                objBU.InsertarDatosCorreoEnviadoSICY(destinatarios, CorreoEnviado, "AUTOMATICO", asuntoCorreo, entCorreo.DescripcionStatusCorreo, entDatosFactura.RemisionID, "XML", False)
            End If

        Catch ex As Exception
            Correoexitoso = False
        End Try

        Return Correoexitoso
    End Function


    Private Sub Button3_Click(sender As Object, e As EventArgs)
        enviarCorreoFacturacionCliente(525)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        enviarCorreoFacturacionCliente(197)
    End Sub

    Private Sub mostrarEnvio(ByVal clienteId As Integer)
        If clienteId = 1198 Then
            lblEnvio.Visible = True
            txtEnvio.Visible = True
        Else
            lblEnvio.Visible = False
            txtEnvio.Visible = False
        End If
    End Sub

End Class