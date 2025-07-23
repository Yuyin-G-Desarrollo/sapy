Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Entidades

Public Class VincularPedidoVirtualconRealForm

    Public pedido As Entidades.PedidoVirtual
    Public admin As AdministradorPedidosVirtualesForm
    Dim objDA As New Negocios.PedidosVirtualesBU

    Private Sub VincularPedidoVirtualconRealForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Normal
        inicializarFormulario()
    End Sub

    Private Sub inicializarFormulario()
        grbDatos.Enabled = False

        txtIdPedido.Text = pedido.id
        txtTipoPedido.Text = pedido.tipo
        txtEstatus.Text = pedido.estatus
        txtCliente.Text = pedido.cliente.nombregenerico
        txtOrdenCliente.Text = pedido.orden
        dtpFechaSolicitada.Value = pedido.FechasolicitadaCliente
        txtSemanaSolicitada.Text = "S " & DatePart("ww", dtpFechaSolicitada.Value.Date) & "-" & dtpFechaSolicitada.Value.Year
        If pedido.fechaEntregaProg.Date.Year = 1 Then
            dtpFechaProgramada.Visible = False
            txtSemanaProgramacion.Visible = False
        Else
            dtpFechaProgramada.Value = pedido.fechaEntregaProg.Date
            txtSemanaProgramacion.Text = "S " & DatePart("ww", dtpFechaProgramada.Value.Date) & "-" & dtpFechaProgramada.Value.Year
        End If

        txtPares.Text = pedido.cantidadpares.ToString("N0")
        txtObservaciones.Text = pedido.observaciones

        Dim tabla, tabla2 As DataTable
        Dim renglon As DataRow

        tabla = objDA.obtenerPedidosReales(pedido.cliente.clienteid)
        tabla2 = New DataTable
        tabla2.Columns.Add("P SAY")
        tabla2.Columns.Add("P SICY")
        tabla2.Columns.Add("O C")
        tabla2.Columns.Add("Pares", Type.GetType("System.Int32"))

        For Each row As DataRow In tabla.Rows
            If row.Item("Pedidos Virtuales").ToString.Contains(pedido.id.ToString) Then
                renglon = tabla2.NewRow()
                renglon.Item("P SAY") = row.Item("Pedido SAY").ToString
                renglon.Item("P SICY") = row.Item("Pedido SICY").ToString
                renglon.Item("O C") = row.Item("Orden Cliente").ToString
                renglon.Item("Pares") = row.Item("Pares").ToString
                row.Delete()
                tabla2.Rows.Add(renglon)
            End If
        Next


        grdPedidosReales.DataSource = tabla
        grdPedidosVinculados.DataSource = tabla2
        pintarGrids()
    End Sub

    Private Sub pintarGrids()

        grdPedidosReales.DisplayLayout.Bands(0).Columns("Seleccion").Header.Caption = ""

        For Each columna As UltraGridColumn In grdPedidosReales.DisplayLayout.Bands(0).Columns
            If columna.Key <> "Seleccion" Then
                grdPedidosReales.DisplayLayout.Bands(0).Columns(columna.Header.Caption.ToString).CellActivation = Activation.NoEdit
            End If
        Next

        For Each columna As UltraGridColumn In grdPedidosVinculados.DisplayLayout.Bands(0).Columns
            grdPedidosVinculados.DisplayLayout.Bands(0).Columns(columna.Header.Caption.ToString).CellActivation = Activation.NoEdit
        Next

        grdPedidosReales.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdPedidosVinculados.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

        grdPedidosReales.DisplayLayout.Bands(0).Columns("Pares").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grdPedidosReales.DisplayLayout.Bands(0).Columns("Pares").Format = "##,##0"
        grdPedidosReales.DisplayLayout.Bands(0).Columns("Pedido SAY").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grdPedidosReales.DisplayLayout.Bands(0).Columns("Pedidos Virtuales").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grdPedidosReales.DisplayLayout.Bands(0).Columns("Pedido SICY").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grdPedidosReales.DisplayLayout.Bands(0).Columns("Pedido SICY").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grdPedidosVinculados.DisplayLayout.Bands(0).Columns("Pares").Format = "##,##0"
        grdPedidosVinculados.DisplayLayout.Bands(0).Columns("Pares").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grdPedidosVinculados.DisplayLayout.Bands(0).Columns("P SAY").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grdPedidosVinculados.DisplayLayout.Bands(0).Columns("P SICY").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grdPedidosReales.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grdPedidosReales.DisplayLayout.GroupByBox.Hidden = False
        grdPedidosReales.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"
        grdPedidosReales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdPedidosVinculados.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub seleccionarRegistroTabla(e As CellEventArgs)
        If e.Cell.Column.Key = "Seleccion" And e.Cell.Row.Index <> grdPedidosReales.Rows.FilterRow.Index Then
            Dim contadorSeleccion As Int32 = 0

            If CBool(e.Cell.Text) = False Then
                If 0 = e.Cell.Row.Index Mod 2 Then
                    e.Cell.Appearance.BackColor = Color.White
                Else
                    e.Cell.Appearance.BackColor = Color.LightSteelBlue
                End If
            End If

            If CBool(e.Cell.Text) = True Then
                lblPedidosSeleccionados.Text = CInt(lblPedidosSeleccionados.Text) + 1
                lblTotalPares.Text = (CInt(lblTotalPares.Text) + CInt(e.Cell.Row.Cells("Pares").Value)).ToString("N0")
            Else
                lblPedidosSeleccionados.Text = CInt(lblPedidosSeleccionados.Text) - 1
                lblTotalPares.Text = (CInt(lblTotalPares.Text) - CInt(e.Cell.Row.Cells("Pares").Value)).ToString("N0")
            End If
        End If
    End Sub

    Private Sub guardarVinculo()
        Dim confirmar As New ConfirmarForm
        Dim mensaje As String = ""
        Dim pedidosReales As String = ""
        Dim contador As Int32 = 0

        If CInt(lblPedidosSeleccionados.Text) > 1 Then
            mensaje = "¿Está seguro de relacionar el pedido virtual #" & pedido.id.ToString & " con los pedidos reales seleccionados?"
        Else
            mensaje = "¿Está seguro de relacionar el pedido virtual #" & pedido.id.ToString & " con el pedido real seleccionado?"
        End If

        mensaje += "(Una vez realizada esta acción no se podrá revertir)"
        confirmar.mensaje = mensaje
        If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
            'insertar en tabla de relacion
            'actualizar el estatus del pedido virtual a pedido real
            'mandar mensaje de exito
            For Each row As UltraGridRow In grdPedidosReales.Rows.GetFilteredInNonGroupByRows
                If row.Cells("Seleccion").Value Then
                    pedidosReales += row.Cells("Pedido SAY").Value & ","
                    contador += 1
                End If
            Next
            objDA.vincularPedidoVirtual(pedido.id, pedidosReales, SesionUsuario.UsuarioSesion.PUserUsuarioid, contador)

            Dim exito As New ExitoForm
            exito.mensaje = "Se relacionó con éxito el pedido virtual con los pedidos reales "
            exito.ShowDialog()
            Me.Close()
            admin.Enabled = True
            admin.Consultafiltros()
            admin.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        guardarVinculo()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        admin.Enabled = True
        admin.Consultafiltros()
        admin.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnArriba_Click_1(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlDatos.Height = 40
    End Sub

    Private Sub btnAbajo_Click_1(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlDatos.Height = 200
    End Sub

    Private Sub grdPedidosReales_CellChange(sender As Object, e As CellEventArgs) Handles grdPedidosReales.CellChange
        seleccionarRegistroTabla(e)
    End Sub

End Class