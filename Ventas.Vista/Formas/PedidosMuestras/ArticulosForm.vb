Imports Programacion.Vista
Imports DevExpress.XtraEditors.Repository
Imports Tools

Public Class ArticulosForm
    Dim dtArticulos As DataTable
    Dim cerrar As Boolean

#Region "Metodos"
    Private Sub DiseñoGridSeleccionArticulos(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)

        Grid.OptionsView.ColumnAutoWidth = False
        Grid.OptionsView.BestFitMaxRowCount = -1

        If IsNothing(Grid.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            Grid.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler Grid.CustomUnboundColumnData, AddressOf grdVseleccionArticulos_CustomUnboundColumnData
            Grid.Columns.Item("#").VisibleIndex = 0
        End If
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
        Dim dt As DataTable
        Dim Negocios As New Ventas.Negocios.PedidosMuestrasBU
        dt = Negocios.ListaUnidadesDeMedida()
        Dim emptyEditor As New RepositoryItemLookUpEdit
        emptyEditor.DataSource = dt
        emptyEditor.DisplayMember = "Descripcion"
        emptyEditor.ValueMember = "id"
        emptyEditor.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        emptyEditor.DropDownRows = dt.Rows.Count
        emptyEditor.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
        emptyEditor.AutoSearchColumnIndex = 1
        emptyEditor.PopulateColumns()
        emptyEditor.Columns("id").Visible = False
        emptyEditor.ShowHeader = False
        Grid.Columns("unidadDeMedida").ColumnEdit = emptyEditor

        'Dim emptyEditorDate As New RepositoryItemDateEdit
        'emptyEditorDate.MinValue = "11/07/2017"
        'Grid.Columns("FechaEntregaCliente").ColumnEdit = emptyEditorDate
        'Grid.BestFitColumns()
        'Grid.Columns.ColumnByFieldName("Talla").Visible = False
        Grid.Columns.ColumnByFieldName("IdCliente").Visible = False

        'Grid.Columns.ColumnByFieldName("Cantidad").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        'Grid.Columns.ColumnByFieldName("Cantidad").DisplayFormat.FormatString = "N0"
        Grid.Columns.ColumnByFieldName("#").Width = 25
        Grid.Columns.ColumnByFieldName("Sel").Width = 25
        Grid.Columns.ColumnByFieldName("Precio").Width = 40
        Grid.Columns.ColumnByFieldName("Talla").Width = 40
        Grid.Columns.ColumnByFieldName("IdEstilo").Width = 45
        Grid.Columns.ColumnByFieldName("Modelo").Width = 45
        Grid.Columns.ColumnByFieldName("PielColor").Width = 120
        Grid.Columns.ColumnByFieldName("Corrida").Width = 60
        Grid.Columns.ColumnByFieldName("Familia").Width = 60
        Grid.Columns.ColumnByFieldName("Linea").Width = 80
        Grid.Columns.ColumnByFieldName("Corte").Width = 45
        Grid.Columns.ColumnByFieldName("Forro").Width = 80
        Grid.Columns.ColumnByFieldName("Suela").Width = 40
        Grid.Columns.ColumnByFieldName("Horma").Width = 60
        Grid.Columns.ColumnByFieldName("SICY").Width = 70
        Grid.Columns.ColumnByFieldName("Estatus").Width = 120



        Grid.Columns.ColumnByFieldName("unidadDeMedida").Caption = "U. Medida"
        Grid.Columns.ColumnByFieldName("FechaEntregaCliente").Caption = "F Entrega"
        Grid.Columns.ColumnByFieldName("Coleccion").Caption = "Colección"

        'Grid.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        'If IsNothing(Grid.Columns("Cantidad").Summary.FirstOrDefault(Function(x) x.FieldName = "Cantidad")) = True Then
        '    Grid.Columns("Cantidad").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:N0}")
        '    ' Create and setup the first summary item.
        '    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        '    item.FieldName = "Cantidad"
        '    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    item.DisplayFormat = "{0}"
        '    Grid.GroupSummary.Add(item)
        'End If

        Grid.Columns.ColumnByFieldName("#").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FechaEntregaCliente").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Marca").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Coleccion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("PielColor").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Corrida").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Familia").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Linea").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Corte").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Forro").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Suela").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Horma").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("SICY").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Estatus").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Precio").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Talla").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("IdEstilo").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Modelo").OptionsColumn.AllowEdit = False


        Grid.Columns.ColumnByFieldName("unidadDeMedida").AppearanceCell.BackColor = Color.Lavender
        Grid.Columns.ColumnByFieldName("Cantidad").AppearanceCell.BackColor = Color.Lavender

        Grid.BestFitColumns()

        'Grid.FocusedRowHandle = 10

        'Grid.FocusedColumn = Grid.VisibleColumns(4)


    End Sub
    Public Sub recibirDatos(ByVal Agente As Integer, ByVal Cliente As Integer, ByVal Modelo As String, ByVal idPedido As Integer)
        txtAgente.Text = Agente
        txtCliente.Text = Cliente
        txtModelo.Text = Modelo
        txtPedido.Text = idPedido
    End Sub
    Public Sub LlenarGridArticulos()
        Dim PedidosMuestrasNegocios As New Ventas.Negocios.PedidosMuestrasBU
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        dtArticulos = PedidosMuestrasNegocios.ListaArticulos(txtModelo.Text, txtAgente.Text, txtCliente.Text)
        grdSeleccionArticulos.DataSource = dtArticulos

        If grdVseleccionArticulos.RowCount > 0 Then
            DiseñoGridSeleccionArticulos(grdVseleccionArticulos)
        End If
    End Sub
    Private Sub ValidaSeleccion(ByVal mensaje As String)
        Dim form As New AdvertenciaForm
        form.mensaje = mensaje
        form.ShowDialog()
    End Sub

    Private Function ValidaAlta() As Boolean
        Dim NumeroFilas As Integer = 0
        Dim fila As Integer

        Dim Valida, sel As Boolean
        Cursor = Cursors.WaitCursor
        NumeroFilas = grdVseleccionArticulos.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1
            fila = index + 1
            If grdVseleccionArticulos.GetRowCellValue(index, "Sel") Then
                sel = True
                If grdVseleccionArticulos.GetListSourceRowCellValue(index, "unidadDeMedida").ToString <> "" Then
                    If grdVseleccionArticulos.GetRowCellValue(index, "Cantidad").ToString <> "" Then
                        If CInt(grdVseleccionArticulos.GetRowCellValue(index, "Cantidad")) > 0 Then
                            Valida = True
                        Else
                            ValidaSeleccion("La fila " & fila.ToString & " seleccionada debe contener una cantidad mayor a 0 capturada.")
                        End If
                    Else
                        ValidaSeleccion("La fila " & fila.ToString & " seleccionada no contiene cantidad capturada.")
                    End If
                Else
                    ValidaSeleccion("La fila " & fila.ToString & " seleccionada no contiene unidad de medida capturada.")
                End If
            End If
        Next
        If sel = False Then ValidaSeleccion("No se encuentraron filas seleccionadas.")
        Cursor = Cursors.Default
        Return Valida
    End Function
#End Region
#Region "Eventos"
    Private Sub ArticulosForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not cerrar Then
            ' Cancelamos el cierre del formulario
            e.Cancel = True
        End If
    End Sub
    Private Sub ArticulosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarGridArticulos()
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        cerrar = True
        Me.Close()
    End Sub
    Private Sub grdVseleccionArticulos_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = grdVseleccionArticulos.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub
    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVseleccionArticulos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                grdVseleccionArticulos.SetRowCellValue(grdVseleccionArticulos.GetVisibleRowHandle(index), "Sel", chboxSeleccionarTodo.Checked)
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub
#End Region
    Private Sub btnAltaPedidoDetalle_Click(sender As Object, e As EventArgs) Handles btnAltaPedidoDetalle.Click
        Dim NumeroFilas As Integer = 0

        Dim arreglo As New ArrayList
        Dim ListaInt As New List(Of Integer)
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Try

            If ValidaAlta() Then

                Dim objMensajeQ As New ConfirmarForm
                objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
                If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor

                    NumeroFilas = grdVseleccionArticulos.DataRowCount
                    For index As Integer = 0 To NumeroFilas Step 1

                        If grdVseleccionArticulos.GetRowCellValue(index, "Sel") Then
                            Dim PedidosMuestrasNegocios As New Negocios.PedidosMuestrasBU
                            Dim EntidadPedidoMuestraDetalle As New Entidades.PedidoMuestraDetalle
                            EntidadPedidoMuestraDetalle.pdetm_pedidoid = CInt(txtPedido.Text.Trim)
                            EntidadPedidoMuestraDetalle.pdetm_productoestiloid = grdVseleccionArticulos.GetRowCellValue(index, "IdEstilo")
                            EntidadPedidoMuestraDetalle.pdetm_unidadmedidaid = CInt(grdVseleccionArticulos.GetListSourceRowCellValue(index, "unidadDeMedida"))
                            EntidadPedidoMuestraDetalle.pdetm_estatusid = 136
                            EntidadPedidoMuestraDetalle.pdetm_talla = grdVseleccionArticulos.GetRowCellValue(index, "Talla")
                            EntidadPedidoMuestraDetalle.pdetm_cantidad = grdVseleccionArticulos.GetRowCellValue(index, "Cantidad")
                            EntidadPedidoMuestraDetalle.pdetm_costo = grdVseleccionArticulos.GetRowCellValue(index, "Precio")
                            EntidadPedidoMuestraDetalle.pdetm_fechaentregacliente = grdVseleccionArticulos.GetRowCellValue(index, "FechaEntregaCliente")
                            EntidadPedidoMuestraDetalle.pdetm_fechacreacion = DateTime.Now
                            EntidadPedidoMuestraDetalle.pdetm_usuariocreoid = usuario
                            PedidosMuestrasNegocios.AltaPedidoMuestraDetalles(EntidadPedidoMuestraDetalle)

                        End If

                    Next
                    Dim mensaje As New ExitoForm
                    mensaje.mensaje = "El registro se realizó con éxito."
                    mensaje.ShowDialog()
                    Cursor = Cursors.Default
                End If
                LlenarGridArticulos()
            End If
        Catch ex As Exception
            Dim mensaje As New ErroresForm
            mensaje.mensaje = ex.Message.ToString
            mensaje.ShowDialog()
            LlenarGridArticulos()
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub grdSeleccionArticulos_DoubleClick(sender As Object, e As EventArgs) Handles grdSeleccionArticulos.DoubleClick
        Try
            If grdVseleccionArticulos.GetFocusedRowCellValue("unidadDeMedida").ToString <> "" Then
                If grdVseleccionArticulos.GetFocusedRowCellValue("Cantidad").ToString <> "" Then
                    If grdVseleccionArticulos.GetFocusedRowCellValue("Cantidad") <> 0 Then
                        Dim objMensajeQ As New ConfirmarForm
                        objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
                        If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then

                            Dim PedidosMuestrasNegocios As New Negocios.PedidosMuestrasBU
                            Dim EntidadPedidoMuestraDetalle As New Entidades.PedidoMuestraDetalle
                            Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

                            EntidadPedidoMuestraDetalle.pdetm_pedidoid = CInt(txtPedido.Text.Trim)
                            EntidadPedidoMuestraDetalle.pdetm_productoestiloid = grdVseleccionArticulos.GetFocusedRowCellValue("IdEstilo")
                            EntidadPedidoMuestraDetalle.pdetm_unidadmedidaid = grdVseleccionArticulos.GetFocusedRowCellValue("unidadDeMedida")
                            EntidadPedidoMuestraDetalle.pdetm_estatusid = 133
                            EntidadPedidoMuestraDetalle.pdetm_talla = grdVseleccionArticulos.GetFocusedRowCellValue("Talla")
                            EntidadPedidoMuestraDetalle.pdetm_cantidad = grdVseleccionArticulos.GetFocusedRowCellValue("Cantidad")
                            EntidadPedidoMuestraDetalle.pdetm_costo = grdVseleccionArticulos.GetFocusedRowCellValue("Precio")
                            EntidadPedidoMuestraDetalle.pdetm_fechaentregacliente = grdVseleccionArticulos.GetFocusedRowCellValue("FechaEntregaCliente")
                            EntidadPedidoMuestraDetalle.pdetm_fechacreacion = DateTime.Now
                            EntidadPedidoMuestraDetalle.pdetm_usuariocreoid = usuario
                            PedidosMuestrasNegocios.AltaPedidoMuestraDetalles(EntidadPedidoMuestraDetalle)
                            Dim mensaje As New ExitoForm
                            mensaje.mensaje = "El registro se realizó con éxito."
                            mensaje.ShowDialog()
                            btnCerrar_Click(sender, e)
                        End If
                    Else
                        ValidaSeleccion("La fila seleccionada debe contener una cantidad mayor a 0.")
                    End If
                Else
                    ValidaSeleccion("La fila seleccionada no contiene cantidad capturada.")
                End If
            Else
                ValidaSeleccion("La fila seleccionada no contiene unidad de medida capturada.")
            End If
        Catch ex As Exception
            MsgBox(" Debe seleccionar un registro.")
        End Try
    End Sub
End Class