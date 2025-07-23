Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools

Public Class ConsultaDetallesDocumentosGuardados_Form

#Region "VARIABLES GLOBALES"

    Public IdDocumento As Integer = 0

    Dim objBu As New Negocios.AdministradorDocumentosBU
    Dim TipoDocumentoActual As String = String.Empty
    Dim var_Cliente As String = String.Empty

#End Region

    Private Sub ConsultaDetallesDocumentosGuardados_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dtDatosEncabezado As New DataTable
        Dim dtDescuentos As New DataTable
        Dim dtDetalles As New DataTable

        dtDatosEncabezado = objBu.consultaEncabezadoPantallaVerDetalles(IdDocumento)
        dtDescuentos = objBu.consultaDescuentosPantallaVerDetalles(IdDocumento)
        dtDetalles = objBu.consultaDetallesDocumentoPantallaVerDetalles(IdDocumento)

        grdDescuentos.DataSource = dtDescuentos
        grdDetallesDocumento.DataSource = dtDetalles

        TipoDocumentoActual = dtDatosEncabezado.Rows(0).Item("TipoDocumento")
        lblNombreCliente.Text = dtDatosEncabezado.Rows(0).Item("Cliente")
        lblRazonSocialReceptor.Text = dtDatosEncabezado.Rows(0).Item("RazonSocialReceptor")
        lblRFCReceptor.Text = dtDatosEncabezado.Rows(0).Item("RFCReceptor")
        lblUsoCFDI.Text = dtDatosEncabezado.Rows(0).Item("UsoCFDI")
        lblMoneda.Text = dtDatosEncabezado.Rows(0).Item("Moneda")
        lblDiasPlazo.Text = If(IsDBNull(dtDatosEncabezado.Rows(0).Item("DiasPlazo")), 0, dtDatosEncabezado.Rows(0).Item("DiasPlazo"))
        lblRestriccion.Text = dtDatosEncabezado.Rows(0).Item("Restriccion")
        lblRestriccionMarca.Text = If(IsDBNull(dtDatosEncabezado.Rows(0).Item("FacturarPorMarca")), "", dtDatosEncabezado.Rows(0).Item("FacturarPorMarca"))
        lblMontoMax.Text = dtDatosEncabezado.Rows(0).Item("MaxFacturacion")
        lblRazonSocialEmisor.Text = dtDatosEncabezado.Rows(0).Item("Emisor")
        lblRFCEmisor.Text = dtDatosEncabezado.Rows(0).Item("RFCEmisor")
        lblFolioFactura.Text = dtDatosEncabezado.Rows(0).Item("Factura")
        txtNumCajas.Text = dtDatosEncabezado.Rows(0).Item("NumCajas")
        txtObservaciones.Text = If(IsDBNull(dtDatosEncabezado.Rows(0).Item("ObservacionesGeneracion")), "", dtDatosEncabezado.Rows(0).Item("ObservacionesGeneracion"))
        txtMensaje.Text = If(IsDBNull(dtDatosEncabezado.Rows(0).Item("MensajeGeneracion")), "", dtDatosEncabezado.Rows(0).Item("MensajeGeneracion"))
        chkImprimirOC.Checked = CBool(dtDatosEncabezado.Rows(0).Item("ImprimirOC"))
        txtOC.Text = dtDatosEncabezado.Rows(0).Item("OC")
        chkImprimirTienda.Checked = CBool(dtDatosEncabezado.Rows(0).Item("ImprimirTienda"))
        txtTienda.Text = If(IsDBNull(dtDatosEncabezado.Rows(0).Item("Tienda")), "", dtDatosEncabezado.Rows(0).Item("Tienda"))
        txtSubTotal.Text = Double.Parse(dtDatosEncabezado.Rows(0).Item("Subtotal").ToString()).ToString("n2")
        txt_CargoAdicional.Text = Double.Parse(dtDatosEncabezado.Rows(0).Item("CargoAdicional").ToString()).ToString("n2")
        txtDescuentoTotal.Text = Double.Parse(dtDatosEncabezado.Rows(0).Item("Descuento").ToString()).ToString("n2")
        lblTipoIVA.Text = dtDatosEncabezado.Rows(0).Item("TipoIVA")
        txtIVA.Text = dtDatosEncabezado.Rows(0).Item("IVA")
        txtTotal.Text = Double.Parse(dtDatosEncabezado.Rows(0).Item("Monto").ToString()).ToString("n2")
        lblCantidadLetra.Text = dtDatosEncabezado.Rows(0).Item("CantidadLetra")
        lblIdDocumento.Text = If(IsDBNull(dtDatosEncabezado.Rows(0).Item("RemisionId")), 0, dtDatosEncabezado.Rows(0).Item("RemisionId"))
        var_Cliente = dtDatosEncabezado.Rows(0).Item("Cliente")

        If TipoDocumentoActual = "R" Then
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
            lblTextoFactura.Visible = False
            lblFolioFactura.Visible = False
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
            lblTextoFactura.Visible = True
            lblFolioFactura.Visible = True
        End If

        mostrarCargoEnvio(var_Cliente)

        DiseñoGridDetallesDocumento()

    End Sub


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


        bgvDetallesDocumento.Columns.ColumnByFieldName("ClaveSAT").Caption = "Clave SAT"
        bgvDetallesDocumento.Columns.ColumnByFieldName("Descripcion").Caption = "Descripción"

        bgvDetallesDocumento.Columns.ColumnByFieldName("ClaveSAT").OptionsColumn.AllowEdit = False
        bgvDetallesDocumento.Columns.ColumnByFieldName("Descripcion").OptionsColumn.AllowEdit = False
        bgvDetallesDocumento.Columns.ColumnByFieldName("Piel").OptionsColumn.AllowEdit = False
        bgvDetallesDocumento.Columns.ColumnByFieldName("Color").OptionsColumn.AllowEdit = False
        bgvDetallesDocumento.Columns.ColumnByFieldName("Corrida").OptionsColumn.AllowEdit = False
        bgvDetallesDocumento.Columns.ColumnByFieldName("Pares").OptionsColumn.AllowEdit = False
        bgvDetallesDocumento.Columns.ColumnByFieldName("Precio").OptionsColumn.AllowEdit = False
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

        bgvDetallesDocumento.Columns.ColumnByFieldName("Descripcion").Width = 150
        bgvDetallesDocumento.Columns.ColumnByFieldName("Piel").Width = 90

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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objVistaPrevia As New Ventas.Negocios.VistaPreviaDocumentosBU
        Try
            Cursor = Cursors.WaitCursor
            If txtNumCajas.Text <> String.Empty Then
                If IsNumeric(txtNumCajas.Text) = True Then
                    If Integer.Parse(txtNumCajas.Text) > 0 Then
                        objVistaPrevia.ActualizarNumeroCajas(IdDocumento, Integer.Parse(txtNumCajas.Text.ToString()))
                        show_message("Exito", "Se ha actualizado el número de cajas.")
                    Else
                        show_message("Advertencia", "El número de cajas tiene que ser mayor a 0.")
                    End If
                Else
                    show_message("Advertencia", "El número de cajas tiene un formato invalido.")
                End If
            Else
                show_message("Advertencia", "El número de cajas no puede estar vacío.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub



    'Imports Tools
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

    Private Sub mostrarCargoEnvio(ByVal NombreCliente As String)
        If NombreCliente = "E-COMMERCE" Then
            lbl_CargoAdicional.Visible = True
            txt_CargoAdicional.Visible = True
        Else
            lbl_CargoAdicional.Visible = False
            txt_CargoAdicional.Visible = False
        End If
    End Sub

End Class