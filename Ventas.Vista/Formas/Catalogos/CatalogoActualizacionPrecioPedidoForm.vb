Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools

Public Class CatalogoActualizacionPrecioPedidoForm
    Dim OBJBU As New Ventas.Negocios.CatalogoActualizacionPrecioPedidoBU
    Dim datos As New DataTable
    Dim datos2 As New DataTable
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If txtpedidosay.Text = String.Empty And txtpedidosicy.Text = String.Empty Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Ingresa un codigo para buscar el pedido")
        Else
            BuscarPedido()
        End If

    End Sub


    Private Sub BuscarPedido()
        Try
            Cursor = Cursors.WaitCursor
            datos = OBJBU.ConsultarDetallesPedido(txtpedidosay.Text, txtpedidosicy.Text)
            grddetallepedido.DataSource = Nothing
            vdetallepedido.Columns.Clear()
            grddetallepedido.DataSource = datos
            DiseñoGrid.DiseñoBaseGrid(vdetallepedido)
            vdetallepedido.IndicatorWidth = 35
            DiseñoGrid.EstiloColumna(vdetallepedido, "Impuesto", "Impuesto", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 200, False, Nothing, "")
            DiseñoGrid.EstiloColumna(vdetallepedido, "Precio", "Precio", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 100, False, Nothing, "")
            DiseñoGrid.EstiloColumna(vdetallepedido, "Salto", "Saldo", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, False, Nothing, "")
            DiseñoGrid.EstiloColumna(vdetallepedido, "ImporteTotal", "Importe Total", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, False, Nothing, "")
            DiseñoGrid.EstiloColumna(vdetallepedido, "ImporteImpuesto", "Importe Impuesto", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, False, Nothing, "")
            DiseñoGrid.EstiloColumna(vdetallepedido, "DetalleID", "DetalleID", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, False, Nothing, "")
            DiseñoGrid.EstiloColumna(vdetallepedido, "CodigoSICY", "CodigoSICY", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, False, Nothing, "")
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In vdetallepedido.Columns
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
                If (col.FieldName <> "Partida" And col.FieldName <> "Pedido" And col.FieldName <> "DetalleID" And col.FieldName <> "CodigoSICY" And col.FieldName <> "Impuesto" And col.FieldName <> "Precio" And col.FieldName <> "ModeloSAY" And col.FieldName <> "ModeloSICY" And col.FieldName <> "Pares" And col.FieldName <> "Articulo" And col.FieldName <> "Tienda" And col.FieldName <> "Estatus") Then
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:n0}"
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If
            Next
            lbltotalpartidas.Text = datos.Rows.Count
            Cursor = Cursors.Default
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        modificarPrecios()
    End Sub

    Private Sub modificarPrecios()
        Dim contAC As Integer = 0
        Dim contAT As Integer = 0
        datos2 = OBJBU.ConsultarDetallesPedido(txtpedidosay.Text, txtpedidosicy.Text)
        Try
            If datos.Rows.Count = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Busca primero un pedido")
            Else
                For index = 0 To datos.Rows.Count - 1
                    Dim precioAnterior = datos2.Rows(index)("Precio")
                    Dim precioActual = vdetallepedido.GetRowCellValue(index, "Precio")
                    If precioAnterior <> precioActual Then

                        contAT = contAT + 1
                        Dim resultadoSAY = OBJBU.ActualiazarPrecioDetalle(vdetallepedido.GetRowCellValue(index, "DetalleID"), vdetallepedido.GetRowCellValue(index, "Precio"))
                        Dim resultadoSICY = OBJBU.ActualiazarPrecioDetalleSICY(vdetallepedido.GetRowCellValue(index, "CodigoSICY"), vdetallepedido.GetRowCellValue(index, "Precio"), vdetallepedido.GetRowCellValue(index, "Partida"))

                        If resultadoSAY(0)("Respuesta") = 1 And resultadoSICY(0)("Respuesta") = 1 Then
                            contAC = contAC + 1
                        End If
                    End If
                Next
                If contAC <> 0 Then
                    If contAT = contAC Then
                        Dim resultadoSAY = OBJBU.ActualiazarEncabezadoPedido(vdetallepedido.GetRowCellValue(0, "Pedido"))
                        Dim resultadoSICY = OBJBU.ActualiazarEncabezadoPedidoSICY(vdetallepedido.GetRowCellValue(0, "CodigoSICY"))
                        If resultadoSAY(0)("Respuesta") = 1 And resultadoSICY(0)("Respuesta") = 1 Then
                            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Exito")
                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "ERROR!!!" + " " + ex.Message.ToString())
        End Try


    End Sub

    Private Sub viewInventario_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vdetallepedido.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grddetallepedido.DataSource = Nothing
        txtpedidosay.Text = ""
        txtpedidosicy.Text = ""
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grpTiposDeTienda.Height = 101
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grpTiposDeTienda.Height = 37
    End Sub
End Class