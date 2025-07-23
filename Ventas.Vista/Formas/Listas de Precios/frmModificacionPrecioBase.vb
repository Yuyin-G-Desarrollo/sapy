Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class frmModificacionPrecioBase
    Public idListaBase As Int32
    Public idProductoEstilo As Int32
    Public dtDatosLVCPS As DataTable
    Public nombreListaBase As String
    Public descripcionArticulo As String
    Public precioAnterior As String
    Public precioNuevo As String
    Public estatusListaBase As String

    Dim esguardar As Boolean = False

    Public Sub guardarCambios()
        Dim objLPCLBU As New Negocios.ListaPreciosVentaClienteBU
        For Each rowGR As UltraGridRow In grdDatosProductos.Rows
            If CBool(rowGR.Cells("Seleccion").Value) = True Then
                objLPCLBU.guardarDatosListaPreciosClienteProductos(rowGR.Cells("lvcp_listaventasclienteprecioid").Value, idProductoEstilo, CDbl(precioNuevo), rowGR.Cells("lpcp_preciocalculado").Value, rowGR.Cells("lpcp_precio").Value, rowGR.Cells("lpcp_precioextranjero").Value, rowGR.Cells("lpcp_preciocalculadoextranjero").Value, rowGR.Cells("lpvt_listaprecioventaid").Value, rowGR.Cells("lvcp_monedaid").Value)
            End If
        Next
    End Sub


    Public Sub recalcularPrecios()
        Dim objLVBU As New Negocios.ListaVentasBU
        Dim objClienteBU As New Negocios.ClientesDatosBU
        Dim dtDescuentosConfigurados As New DataTable
        Dim contRecalculado As Int32 = 0
        For Each rowGrd As UltraGridRow In grdDatosProductos.Rows
            'If CBool(rowGrd.Cells("Seleccion").Value) = True Then

            If CBool(rowGrd.Cells("iccl_calcularpreciocondescuento").Value) = True And rowGrd.Cells("DESCUENTOS").Value > 0 Then
                dtDescuentosConfigurados = New DataTable
                dtDescuentosConfigurados = objLVBU.consultaConfiguracionDescuentoClienteLV(rowGrd.Cells("lpvt_listaprecioventaid").Value, rowGrd.Cells("clie_clienteid").Value)
            ElseIf CBool(rowGrd.Cells("iccl_calcularpreciocondescuento").Value) = True And rowGrd.Cells("DESCUENTOS").Value = 0 Then
                dtDescuentosConfigurados = New DataTable
                dtDescuentosConfigurados = objClienteBU.Datos_TablaDescuentosCliente(rowGrd.Cells("clie_clienteid").Value, 0)
            End If

            rowGrd.Cells("lpcp_preciobase").Value = lblNuevoPrecio.Text
            'If CBool(rowGrd.Cells("lpvt_porcentaje").Value) = True Then
            '    rowGrd.Cells("lpcp_preciocalculado").Value = CDbl(CDbl(lblNuevoPrecio.Text) + (CDbl(lblNuevoPrecio.Text) * (CDbl(rowGrd.Cells("lpvt_incrementoporpar").Value) / 100)))
            'Else
            '    rowGrd.Cells("lpcp_preciocalculado").Value = CDbl(CDbl(lblNuevoPrecio.Text) + CDbl(rowGrd.Cells("lpvt_incrementoporpar").Value))
            'End If

            If CBool(rowGrd.Cells("marc_decimales").Value) = True Then

                If CBool(rowGrd.Cells("lpvt_porcentaje").Value) = True Then
                    rowGrd.Cells("lpcp_preciocalculado").Value = Math.Round(CDbl(CDbl(lblNuevoPrecio.Text) + (CDbl(lblNuevoPrecio.Text) * (CDbl(rowGrd.Cells("lpvt_incrementoporpar").Value) / 100))), MidpointRounding.AwayFromZero)
                Else
                    rowGrd.Cells("lpcp_preciocalculado").Value = Math.Round(CDbl(CDbl(lblNuevoPrecio.Text) + CDbl(rowGrd.Cells("lpvt_incrementoporpar").Value)), MidpointRounding.AwayFromZero)
                End If

                If CBool(rowGrd.Cells("lpvt_porcentaje").Value) = True Then
                    rowGrd.Cells("lpcp_precio").Value = Math.Round(CDbl(CDbl(lblNuevoPrecio.Text) + (CDbl(lblNuevoPrecio.Text) * (CDbl(rowGrd.Cells("lpvt_incrementoporpar").Value) / 100))), MidpointRounding.AwayFromZero)
                Else
                    rowGrd.Cells("lpcp_precio").Value = Math.Round(CDbl(CDbl(lblNuevoPrecio.Text) + CDbl(rowGrd.Cells("lpvt_incrementoporpar").Value)), MidpointRounding.AwayFromZero)
                End If
            Else

                If CBool(rowGrd.Cells("lpvt_porcentaje").Value) = True Then
                    Dim toot As Double = CDbl(CDbl(lblNuevoPrecio.Text) + (CDbl(lblNuevoPrecio.Text) * (CDbl(rowGrd.Cells("lpvt_incrementoporpar").Value) / 100)))
                    rowGrd.Cells("lpcp_preciocalculado").Value = Math.Round(CDbl(CDbl(lblNuevoPrecio.Text) + (CDbl(lblNuevoPrecio.Text) * (CDbl(rowGrd.Cells("lpvt_incrementoporpar").Value) / 100))), MidpointRounding.AwayFromZero)
                Else
                    rowGrd.Cells("lpcp_preciocalculado").Value = Math.Round(CDbl(CDbl(lblNuevoPrecio.Text) + CDbl(rowGrd.Cells("lpvt_incrementoporpar").Value)), MidpointRounding.AwayFromZero)
                End If

                If CBool(rowGrd.Cells("lpvt_porcentaje").Value) = True Then
                    rowGrd.Cells("lpcp_precio").Value = Math.Round(CDbl(CDbl(lblNuevoPrecio.Text) + (CDbl(lblNuevoPrecio.Text) * (CDbl(rowGrd.Cells("lpvt_incrementoporpar").Value) / 100))), MidpointRounding.AwayFromZero)
                Else
                    rowGrd.Cells("lpcp_precio").Value = Math.Round(CDbl(CDbl(lblNuevoPrecio.Text) + CDbl(rowGrd.Cells("lpvt_incrementoporpar").Value)), MidpointRounding.AwayFromZero)
                End If
            End If

            If CBool(rowGrd.Cells("iccl_calcularpreciocondescuento").Value) = True And rowGrd.Cells("DESCUENTOS").Value > 0 And dtDescuentosConfigurados.Rows.Count > 0 Then

                For Each dtRow As DataRow In dtDescuentosConfigurados.Rows
                    If CBool(dtRow.Item("cdlv_porcentaje")) = True Then
                        rowGrd.Cells("lpcp_precio").Value = rowGrd.Cells("lpcp_precio").Value - (rowGrd.Cells("lpcp_precio").Value * (dtRow.Item("cdlv_cantidad") / 100))
                    Else
                        rowGrd.Cells("lpcp_precio").Value = rowGrd.Cells("lpcp_precio").Value - dtRow.Item("cdlv_cantidad")
                    End If
                Next

            ElseIf CBool(rowGrd.Cells("iccl_calcularpreciocondescuento").Value) = True And rowGrd.Cells("DESCUENTOS").Value = 0 And dtDescuentosConfigurados.Rows.Count > 0 Then
                For Each dtRow As DataRow In dtDescuentosConfigurados.Rows
                    If CBool(dtRow.Item("decl_descuentoenporcentaje")) = True Then
                        rowGrd.Cells("lpcp_precio").Value = rowGrd.Cells("lpcp_precio").Value - (rowGrd.Cells("lpcp_precio").Value * (dtRow.Item("decl_cantidaddescuento") / 100))
                        'Dim colPrecio As UltraGridColumn = grdModelos.DisplayLayout.Bands(0).Columns("Precio")
                        'colPrecio.MaskInput = "nnnn.nn"
                    Else
                        rowGrd.Cells("lpcp_precio").Value = rowGrd.Cells("lpcp_precio").Value - dtRow.Item("decl_cantidaddescuento")
                    End If
                Next
            End If


            If rowGrd.Cells("lvcp_monedaid").Value > 1 Then
                rowGrd.Cells("lpcp_preciocalculadoextranjero").Value = Math.Round(CDbl(rowGrd.Cells("lpcp_precio").Value / rowGrd.Cells("lvcp_paridad").Value), 1)
                'rowGrd.Cells("lpcp_preciocalculadoextranjero").Value = lblNuevoPrecio.Text / rowGrd.Cells("marc_decimales").Value
            Else
                rowGrd.Cells("lpcp_preciocalculadoextranjero").Value = "0"
                'rowGrd.Cells("lpcp_preciocalculadoextranjero").Value = "0"
            End If
            contRecalculado += 1
            'End If

        Next
        If contRecalculado = 0 Then
            Dim objMsjAdv As New Tools.AdvertenciaForm
            objMsjAdv.mensaje = "No se recalcularon los precios de ningún cliente."
            objMsjAdv.ShowDialog()
        End If
    End Sub

    Public Sub formatoGrid()
   
        With grdDatosProductos.DisplayLayout.Bands(0)
            .Columns("lpba_listapreciosbaseid").Hidden = True
            .Columns("pres_productoestiloid").Hidden = True
            '.Columns("DESCUENTOS").Hidden = True
            .Columns("lvcp_monedaid").Hidden = True
            .Columns("marc_decimales").Hidden = True
            .Columns("lpvt_porcentaje").Hidden = True
            .Columns("lpvt_listaprecioventaid").Hidden = True
            .Columns("lvcp_listaventasclienteprecioid").Hidden = True
            .Columns("lpba_nombrelista").Hidden = True

            .Columns("Seleccion").Header.Caption = ""
            .Columns("clie_clienteid").Header.Caption = "Id SAY"
            .Columns("clie_idsicy").Header.Caption = "Id SICY"
            .Columns("clie_nombregenerico").Header.Caption = "Cliente"
            .Columns("lvcp_descripcion").Header.Caption = "Lista Cliente"
            .Columns("lpcp_preciobase").Header.Caption = "P.Base"
            .Columns("lpcp_preciocalculado").Header.Caption = "P.Calculado"
            .Columns("lpcp_precio").Header.Caption = "Precio"
            .Columns("lpcp_precioextranjero").Header.Caption = "P.Paridad"
            .Columns("lpcp_preciocalculadoextranjero").Header.Caption = "P.Paridad Calculado"
            .Columns("lvcp_paridad").Header.Caption = "Paridad"
            .Columns("lpvt_incrementoporpar").Header.Caption = "IXP"
            .Columns("iccl_calcularpreciocondescuento").Header.Caption = "DA?"
            .Columns("DESCUENTOS").Header.Caption = "D"
            .Columns("PrecioAnterior").Header.Caption = "P.Anterior"
            .Columns("lvcp_descuento").Header.Caption = "%D"

            .Columns("lpba_nombrelista").CellActivation = Activation.NoEdit
            .Columns("clie_clienteid").CellActivation = Activation.NoEdit
            .Columns("clie_nombregenerico").CellActivation = Activation.NoEdit
            .Columns("clie_idsicy").CellActivation = Activation.NoEdit
            .Columns("lvcp_descripcion").CellActivation = Activation.NoEdit
            .Columns("lpcp_preciocalculado").CellActivation = Activation.NoEdit
            .Columns("lpcp_precioextranjero").CellActivation = Activation.NoEdit
            .Columns("lpcp_preciocalculadoextranjero").CellActivation = Activation.NoEdit
            .Columns("iccl_calcularpreciocondescuento").CellActivation = Activation.NoEdit
            .Columns("lpvt_incrementoporpar").CellActivation = Activation.NoEdit
            .Columns("lvcp_paridad").CellActivation = Activation.NoEdit
            .Columns("PrecioAnterior").CellActivation = Activation.NoEdit
            .Columns("DESCUENTOS").CellActivation = Activation.NoEdit
            .Columns("lvcp_descuento").CellActivation = Activation.NoEdit

            .Columns("clie_clienteid").CellAppearance.TextHAlign = HAlign.Right
            .Columns("clie_idsicy").CellAppearance.TextHAlign = HAlign.Right
            .Columns("lpcp_preciobase").CellAppearance.TextHAlign = HAlign.Right
            .Columns("lpcp_preciocalculado").CellAppearance.TextHAlign = HAlign.Right
            .Columns("lpcp_precio").CellAppearance.TextHAlign = HAlign.Right
            .Columns("lpcp_precioextranjero").CellAppearance.TextHAlign = HAlign.Right
            .Columns("lpcp_preciocalculadoextranjero").CellAppearance.TextHAlign = HAlign.Right
            .Columns("lvcp_paridad").CellAppearance.TextHAlign = HAlign.Right
            .Columns("lpvt_incrementoporpar").CellAppearance.TextHAlign = HAlign.Right
            .Columns("PrecioAnterior").CellAppearance.TextHAlign = HAlign.Right
            .Columns("lvcp_descuento").CellAppearance.TextHAlign = HAlign.Right

            .Columns("iccl_calcularpreciocondescuento").Style = ColumnStyle.CheckBox
            .Columns("DESCUENTOS").Style = ColumnStyle.Image
        End With

        grdDatosProductos.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdDatosProductos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdDatosProductos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDatosProductos.DisplayLayout.Override.RowSelectorWidth = 35
        grdDatosProductos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdDatosProductos.Rows(0).Selected = True
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objMsjConfirmar As New Tools.ConfirmarForm

        If CInt(lblTotalSeleccionados.Text) <= 0 Then
            Dim adv_msg As New Tools.AdvertenciaForm
            adv_msg.mensaje = "Debe seleccionar al menos un cliente para que se apliquen los cambios de precio en la listas del cliente"
            adv_msg.ShowDialog()
            Return
        End If


        Dim cadenaMensaje As String = "¿Está seguro de guardar la lista de precios de cliente?"
        objMsjConfirmar.mensaje = cadenaMensaje
        If objMsjConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
            guardarCambios()
            esguardar = True
            Dim objMensajeGuardar As New Tools.ExitoForm
            objMensajeGuardar.mensaje = "Registros Correctos"
            objMensajeGuardar.ShowDialog()
            Me.Close()
        End If
    End Sub

    Private Sub frmModificacionPrecioBase_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If esguardar = False Then
            Dim objMsjConfirmar As New Tools.ConfirmarForm
            Dim cadenaMensaje As String = "¿Está seguro de salir sin guardar cambios?. Si decide salir, NO se guardará el cambio de precio en ninguna Lista de Precios de Cliente."
            objMsjConfirmar.mensaje = cadenaMensaje
            If objMsjConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                ' ''Dim objMsjAdv As New Tools.AdvertenciaForm
                ' ''objMsjAdv.mensaje = "No se guardará el cambio de precio en ninguna lista de precios de cliente."
                ' ''objMsjAdv.ShowDialog()
            Else
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub frmModificacionPrecioBase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If dtDatosLVCPS.Rows.Count > 0 Then
            grdDatosProductos.DataSource = dtDatosLVCPS
            txtListaBase.Text = nombreListaBase
            txtArticulo.Text = descripcionArticulo
            lblPrecioAnterior.Text = precioAnterior
            lblNuevoPrecio.Text = precioNuevo
            lblEstatus.Text = estatusListaBase
            If lblEstatus.Text = "ACTIVA" Then
                lblEstatus.ForeColor = Color.DarkOrange
            ElseIf lblEstatus.Text = "AUTORIZADA" Then
                lblEstatus.ForeColor = Color.LimeGreen
            End If
            formatoGrid()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnRecalcular_Click(sender As Object, e As EventArgs) Handles btnRecalcular.Click
        recalcularPrecios()
        btnGuardar.Enabled = True
        lblGuardar.Enabled = True
    End Sub

    Private Sub grdDatosProductos_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdDatosProductos.AfterCellUpdate
        If e.Cell.Row.IsFilterRow = False Then
            If e.Cell.Column.ToString = "lpcp_precio" Then
                If grdDatosProductos.Rows(e.Cell.Row.Index).Cells("lvcp_monedaid").Value > 1 Then
                    If e.Cell.Value > 0 Then
                        grdDatosProductos.Rows(e.Cell.Row.Index).Cells("lpcp_precioextranjero").Value = Math.Round(e.Cell.Value / grdDatosProductos.Rows(e.Cell.Row.Index).Cells("lvcp_paridad").Value, 1)
                    Else
                        grdDatosProductos.Rows(e.Cell.Row.Index).Cells("lpcp_precioextranjero").Value = "0"
                    End If
                End If
                End If
            End If
    End Sub

    Private Sub grdDatosProductos_CellChange(sender As Object, e As CellEventArgs) Handles grdDatosProductos.CellChange
        If e.Cell.Column.Key = "Seleccion" And e.Cell.Row.Index <> grdDatosProductos.Rows.FilterRow.Index Then
            Dim contadorSeleccion As Int32 = 0
            If CBool(e.Cell.Text) = True Then
                lblTotalSeleccionados.Text = CInt(lblTotalSeleccionados.Text) + 1
            Else
                lblTotalSeleccionados.Text = CInt(lblTotalSeleccionados.Text) - 1
            End If
        End If
    End Sub

    Private Sub grdDatosProductos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdDatosProductos.InitializeLayout

    End Sub

    Private Sub grdDatosProductos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdDatosProductos.InitializeRow

        If e.Row.Cells.Exists("DESCUENTOS") Then
            If e.Row.Cells("DESCUENTOS").Value > 0 Then
                e.Row.Cells("DESCUENTOS").Appearance.ImageBackground = Global.Ventas.Vista.My.Resources.Resources.conflv
            Else
                e.Row.Cells("DESCUENTOS").Value = "0"
            End If
        End If

        If CBool(e.Row.Cells("marc_decimales").Value) = False Then
            e.Row.Cells("lpcp_precio").Style = ColumnStyle.Integer
        Else
            e.Row.Cells("lpcp_precio").Style = ColumnStyle.Double
        End If

    End Sub

    Private Sub chkSeleccionarFiltrados_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarFiltrados.CheckedChanged
        For Each rowGr As UltraGridRow In grdDatosProductos.Rows.GetFilteredInNonGroupByRows
            rowGr.Cells("Seleccion").Value = CBool(chkSeleccionarFiltrados.Checked)
        Next

        Dim contadorSeleccion As Int32 = 0
        For Each rowGR As UltraGridRow In grdDatosProductos.Rows
            If CBool(rowGR.Cells("Seleccion").Text) = True Then
                contadorSeleccion += 1
            End If
        Next
        lblTotalSeleccionados.Text = contadorSeleccion.ToString("N0")
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        'Dim objMsjAdv As New Tools.AdvertenciaForm
        'objMsjAdv.mensaje = "No se guardará el cambio de precio en ninguna lista de precios de cliente."
        'objMsjAdv.ShowDialog()
        esguardar = False
        Me.Close()
    End Sub

    Private Sub grdDatosProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles grdDatosProductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdDatosProductos.PerformAction(UltraGridAction.ExitEditMode, False, False)
            Dim banda As UltraGridBand = grdDatosProductos.DisplayLayout.Bands(0)
            If grdDatosProductos.ActiveRow.HasNextSibling(True) Then
                Dim nextRow As UltraGridRow = grdDatosProductos.ActiveRow.GetSibling(SiblingRow.Next, True)
                grdDatosProductos.ActiveCell = nextRow.Cells(grdDatosProductos.ActiveCell.Column)
                e.Handled = True
                grdDatosProductos.PerformAction(UltraGridAction.EnterEditMode, False, False)
            End If
        End If
    End Sub

End Class