Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class altaCopiaClienteListaPrecio
    Public idListaVentas As Int32
    Public idCliente As Int32
    Public nombreGenerico As String
    Public listaventasdescripcion As String
    Public idListaCliente As Int32
    Dim dtDatosListaClienteProductos As DataTable

    Public Sub llenarTablaClientes()
        Dim objLCBU As New Negocios.ListaPreciosVentaClienteBU
        Dim dtDatosCLiente As New DataTable
        If idListaVentas > 0 And idCliente > 0 Then

            txtClienteOriginal.Text = nombreGenerico
            txtListaVentas.Text = listaventasdescripcion
            dtDatosCLiente = objLCBU.verClientesProspectoCopia(idListaVentas, idCliente, idListaCliente)
            If dtDatosCLiente.Rows.Count > 0 Then
                grdClientesCopia.DataSource = dtDatosCLiente
                formatoGridClientes()
            End If
        Else
            Me.Close()
        End If

        dtDatosListaClienteProductos = objLCBU.verModelosPreciosListaCliente(idListaCliente)
    End Sub

    Public Sub formatoGridClientes()
        'lv.lpvt_listaprecioventaid,
        'lc.lvcl_listaventasclienteid,
        'lc.lvcl_clienteid,
        'cl.clie_idsicy,
        'cl.clie_nombregenerico

        With grdClientesCopia.DisplayLayout.Bands(0)
            .Columns("lpvt_listaprecioventaid").Hidden = True
            .Columns("lvcl_listaventasclienteid").Hidden = True
            .Columns("Existia").Hidden = True
            .Columns("iccl_monedaid").Hidden = True
            .Columns("lvcl_clienteid").Header.Caption = "ID SAY"
            .Columns("clie_idsicy").Header.Caption = "ID SICY"
            .Columns("clie_nombregenerico").Header.Caption = "Cliente"
            .Columns("lvcl_clienteid").CellActivation = Activation.NoEdit
            .Columns("clie_idsicy").CellActivation = Activation.NoEdit
            .Columns("clie_nombregenerico").CellActivation = Activation.NoEdit
            .Columns("lvcl_clienteid").Width = 50
            .Columns("clie_idsicy").Width = 50
            .Columns("lvcl_clienteid").CellAppearance.TextHAlign = HAlign.Right
            .Columns("clie_idsicy").CellAppearance.TextHAlign = HAlign.Right
        End With

        ' ''grdClientesCopia.DisplayLayout.Bands(0).Columns.Add("Seleccion", "Seleccion")
        Dim colSeleccion As UltraGridColumn = grdClientesCopia.DisplayLayout.Bands(0).Columns("Seleccion")
        colSeleccion.DefaultCellValue = False
        colSeleccion.Header.Caption = "Seleccion"
        colSeleccion.Header.VisiblePosition = 0
        colSeleccion.Style = ColumnStyle.CheckBox
        colSeleccion.Width = 50

        grdClientesCopia.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
        grdClientesCopia.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.VisibleIndex

        ' ''For Each rowGR As UltraGridRow In grdClientesCopia.Rows
        ' ''    rowGR.Cells("Seleccion").Value = False
        ' ''Next

    End Sub

    Public Sub guardarListaPreciosCliente()
        Dim objLPCLBU As New Negocios.ListaPreciosVentaClienteBU
        Dim dtListaPreciosCliente As New DataTable
        Dim dtDatosListaPreciosCLiente As New DataTable
        If idListaCliente > 0 Then

            For Each rowGR As UltraGridRow In grdClientesCopia.Rows
                If CBool(rowGR.Cells("Seleccion").Value) = True And CBool(rowGR.Cells("Existia").Value) = False Then

                    objLPCLBU.relacionarCopiaListaVentasClienteProducto(idListaCliente, rowGR.Cells("lvcl_listaventasclienteid").Value)

                    For Each dtRow As DataRow In dtDatosListaClienteProductos.Rows
                        If rowGR.Cells("iccl_monedaid").Value > 1 Then
                            objLPCLBU.guardarDatosListaPreciosClienteProductos(rowGR.Cells("lvcl_listaventasclienteid").Value, dtRow.Item("lpcp_productoestiloid"), dtRow.Item("lpcp_preciobase"),
                                                                               dtRow.Item("lpcp_preciocalculado"), dtRow.Item("lpcp_precio"), dtRow.Item("lpcp_precioextranjero"), dtRow.Item("lpcp_preciocalculadoextranjero"), idListaVentas, rowGR.Cells("iccl_monedaid").Value)
                        Else
                            objLPCLBU.guardarDatosListaPreciosClienteProductos(rowGR.Cells("lvcl_listaventasclienteid").Value, dtRow.Item("lpcp_productoestiloid"), dtRow.Item("lpcp_preciobase"),
                                                   dtRow.Item("lpcp_preciocalculado"), dtRow.Item("lpcp_precio"), 0, 0, idListaVentas, rowGR.Cells("iccl_monedaid").Value)

                        End If
                    Next

                    'ElseIf CBool(rowGR.Cells("Seleccion").Value) = False And CBool(rowGR.Cells("Existia").Value) = True Then
                    '    objLPCLBU.inactivarCopiaListaVentasClienteProducto(rowGR.Cells("lvcl_listaventasclienteid").Value)
                End If
            Next

        Else
            MsgBox("Sin Registro.")
        End If
    End Sub
    '''-------------------------------------------------------------------------------------------

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim objMsjConfirmar As New Tools.ConfirmarForm
            objMsjConfirmar.mensaje = "¿Está seguro de guardar la lista de precios de cliente?"
            If objMsjConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                guardarListaPreciosCliente()
                Dim objMensajeGuardar As New Tools.ExitoForm
                objMensajeGuardar.mensaje = "Registros Correctos"
                objMensajeGuardar.ShowDialog()
                llenarTablaClientes()
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox("Sucedio algo inesperado.")
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub altaCopiaClienteListaPrecio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        llenarTablaClientes()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click_1(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub chkSeleccionarFiltrados_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarFiltrados.CheckedChanged
        Dim cont As Int32 = 0
        For Each rowGR As UltraGridRow In grdClientesCopia.Rows
            If chkSeleccionarFiltrados.Checked = True Then
                rowGR.Cells("Seleccion").Value = True
                cont += 1
            Else
                rowGR.Cells("Seleccion").Value = False
            End If
        Next

        lblContClientes.Text = cont.ToString("N0")
    End Sub

    Private Sub grdClientesCopia_CellChange(sender As Object, e As CellEventArgs) Handles grdClientesCopia.CellChange
        If e.Cell.Column.Key = "Seleccion" And e.Cell.Row.Index <> grdClientesCopia.Rows.FilterRow.Index Then
            Dim contadorSeleccion As Int32 = 0
            If CBool(e.Cell.Text) = True Then
                lblContClientes.Text = CInt(lblContClientes.Text) + 1
            Else
                lblContClientes.Text = CInt(lblContClientes.Text) - 1
            End If
        End If
    End Sub

    Private Sub grdClientesCopia_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientesCopia.InitializeLayout
        Me.grdClientesCopia.DisplayLayout.GroupByBox.Prompt = "Arrastra para agrupar datos."
        Dim valueList As ValueList = e.Layout.FilterOperatorsValueList
        Dim item As ValueListItem
        For Each item In valueList.ValueListItems
            Dim filterOperator As FilterComparisionOperator = DirectCast(item.DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Contains = filterOperator Then
                item.DisplayText = "CONTIENE"
            ElseIf FilterComparisionOperator.DoesNotEndWith = filterOperator Then
                item.DisplayText = "NO TERMINA CON"
            ElseIf FilterComparisionOperator.DoesNotStartWith = filterOperator Then
                item.DisplayText = "NO COMIENZA CON"
            ElseIf FilterComparisionOperator.EndsWith = filterOperator Then
                item.DisplayText = "TERMINA CON"
            ElseIf FilterComparisionOperator.Equals = filterOperator Then
                item.DisplayText = "IGUAL"
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                item.DisplayText = "MAYOR QUE"
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                item.DisplayText = "MAYOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                item.DisplayText = "MENOR QUE"
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                item.DisplayText = "MENOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.NotEquals = filterOperator Then
                item.DisplayText = "DIFERENTE A"
            ElseIf FilterComparisionOperator.StartsWith = filterOperator Then
                item.DisplayText = "COMIENZA CON"
            End If
        Next

        Dim cont As Integer
        For cont = valueList.ValueListItems.Count - 1 To 0 Step -1
            Dim filterOperator As FilterComparisionOperator = DirectCast(valueList.ValueListItems.Item(cont).DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Custom = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotContain = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotMatch = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Like = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Match = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.NotLike = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            End If
        Next
    End Sub
End Class