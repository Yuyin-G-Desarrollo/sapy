Imports System.Globalization
Imports Programacion.Vista
Imports Tools

Public Class CancelarPedidosMuestraForm

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()

    End Sub

    Private Sub DiseñoGridPedidosMuestrasDetalles(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)

        Grid.OptionsView.ColumnAutoWidth = True
        Grid.OptionsView.BestFitMaxRowCount = -1
        Dim ci As New CultureInfo("en-us")
        If IsNothing(Grid.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            Grid.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler Grid.CustomUnboundColumnData, AddressOf grdVpedidosMuestrasDetalles_CustomUnboundColumnData
            Grid.Columns.Item("#").VisibleIndex = 0
        End If

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsColumn.AllowEdit = False
        Next
        'Grid.Columns.ColumnByFieldName("ProductoEstiloId").Visible = False
        Grid.Columns.ColumnByFieldName("UDM").Visible = False
        Grid.Columns.ColumnByFieldName("pdtem_pedidomuestradetalleid").Visible = False

        Grid.Columns.ColumnByFieldName("Sel").OptionsFilter.AllowAutoFilter = False
        Grid.Columns.ColumnByFieldName("Sel").OptionsColumn.AllowEdit = True
        ''Grid.Columns.ColumnByFieldName("Talla").Visible = False


        'Grid.Columns.ColumnByFieldName("Precio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ''Grid.Columns.ColumnByFieldName("Confirmados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ''Grid.Columns.ColumnByFieldName("PorConfirmar").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ''Grid.Columns.ColumnByFieldName("Cancelados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        'Grid.Columns.ColumnByFieldName("Precio").DisplayFormat.FormatString = "N0"
        ''Grid.Columns.ColumnByFieldName("Precio").DisplayFormat.FormatString = "c2"
        ''Grid.Columns.ColumnByFieldName("Confirmados").DisplayFormat.FormatString = "N0"
        ''Grid.Columns.ColumnByFieldName("PorConfirmar").DisplayFormat.FormatString = "N0"
        ''Grid.Columns.ColumnByFieldName("Cancelados").DisplayFormat.FormatString = "N0"

        ''Grid.Columns.ColumnByFieldName("#").Width = 30
        ''Grid.Columns.ColumnByFieldName("Sel").Width = 20
        ''Grid.Columns.ColumnByFieldName("Folio").Width = 40
        ''Grid.Columns.ColumnByFieldName("Modelo").Width = 60
        'Grid.Columns.ColumnByFieldName("ProductoEstiloId").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("UnidadMedidaId").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Marca").OptionsColumn.AllowEdit = False
        ''Grid.Columns.ColumnByFieldName("Coleccion").Width = 80
        'Grid.Columns.ColumnByFieldName("Modelo").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Corrida").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Precio").OptionsColumn.AllowEdit = False
        ''Grid.Columns.ColumnByFieldName("PielColor").Width = 120
        'Grid.Columns.ColumnByFieldName("UDM").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Cantidad").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Estatus").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("FechaCaptura").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("FechaEntregaCliente").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("FechaEnvio").OptionsColumn.AllowEdit = False


        'Grid.Columns.ColumnByFieldName("FechaCaptura").Caption = "F Captura"
        'Grid.Columns.ColumnByFieldName("FechaEntregaCliente").Caption = "F Entrega"
        'Grid.Columns.ColumnByFieldName("Coleccion").Caption = "Colección"
        'Grid.Columns.ColumnByFieldName("FechaEnvio").Caption = "F Envió"


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


        'If IsNothing(Grid.Columns("Precio").Summary.FirstOrDefault(Function(x) x.FieldName = "Precio")) = True Then
        '    Grid.Columns("Precio").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Precio", "{0:N0}")
        '    ' Create and setup the first summary item.
        '    Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
        '    item2.FieldName = "Precio"
        '    item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    item2.DisplayFormat = "{0}"
        '    Grid.GroupSummary.Add(item2)
        'End If




        'Grid.Columns.ColumnByFieldName("#").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Folio").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("ProductoEstiloId").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("UnidadMedidaId").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Marca").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Coleccion").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Modelo").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Corrida").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Precio").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("PielColor").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("UDM").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Cantidad").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Estatus").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("FechaCaptura").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("FechaEntregaCliente").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("FechaEnvio").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Talla").OptionsColumn.AllowEdit = False

        'Grid.Columns.ColumnByFieldName("FechaCitaEntrega").DisplayFormat.FormatString = "dd/mm/yyyy HH:mm:ss"
        'grdVentas.Columns.ColumnByFieldName("DiasFaltantes").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        'Grid.Columns.ColumnByFieldName("MotivoCancelacion").Visible = False

        Grid.BestFitColumns()



    End Sub
    Private Sub LlenarGrid()
        Try
            Dim objNeg As New Negocios.PedidosMuestrasBU
            Dim dt As DataTable
            'Dim dtCedisValidacion As New DataTable
            Dim mensaje As New AdvertenciaForm
            Dim Modelo As String
            'Dim cedisNaveId As Integer = 0
            ' If cboxNaveCedis.Text <> "" Then
            Modelo = txtBuscarModelo.Text
            'cedisNaveId = cboxNaveCedis.SelectedValue
            If txtBuscarModelo.Text <> "" Then
                'dtCedisValidacion = objNeg.obtenerValidacionCedisOriginal(Modelo)
                'If dtCedisValidacion.Rows.Count = 0 Then '' NO TIENE CEDIS RELACIONADO, POR LO TANTO SI VA A DEJAR OBTENER RESUMEN
                dt = objNeg.ListaModelosCancelar(Modelo)
                grdModelos.DataSource = dt
                'Else
                'If dtCedisValidacion.Rows(0).Item(0) = cedisNaveId Then ''CEDIS RECUPERADO ES IGUAL AL SELECCIONADO
                'dt = objNeg.ListaModelosCancelar(Modelo)
                'grdModelos.DataSource = dt
                'Else
                '    If dtCedisValidacion.Rows(0).Item(0) <> cedisNaveId Then
                '        mensaje.mensaje = "El pedido o modelo no corresponde al cedis de: " + cboxNaveCedis.Text + " favor de verificar." '' CEDIS ES DIFERENTE AL ORIGINAL
                '        mensaje.ShowDialog()
                '        grdModelos.DataSource = Nothing
                '        grdVmodelos.Columns.Clear()
                '        Return
                '    End If
                'End If
                'End If
                'Else
                ' dt = objNeg.ListaModelosCancelar(Modelo, cedisNaveId)
                'grdModelos.DataSource = dt
            End If
            If grdVmodelos.RowCount > 0 Then
                    DiseñoGridPedidosMuestrasDetalles(grdVmodelos)
                End If
            '  Else
            'mensaje.mensaje = "Es necesario seleccionar un cedis para realizar la consulta."
            '    mensaje.ShowDialog()
            '    grdModelos.DataSource = Nothing
            '    grdVmodelos.Columns.Clear()
            'End If
        Catch ex As Exception
            MsgBox(" Debe seleccionar un registro.")
        End Try
    End Sub



    Private Sub btnBuscarSeg_Click(sender As Object, e As EventArgs) Handles btnBuscarSeg.Click
        LlenarGrid()
    End Sub
    Private Sub grdVpedidosMuestrasDetalles_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = grdVmodelos.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub CancelarPedidosMuestraForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        'cargaNavesCedis()
    End Sub

    Private Sub ValidaSeleccion()
        Dim mensaje As New AdvertenciaForm
        mensaje.mensaje = "No se encontraron registros seleccionados. Favor de corroborar la selección"
        mensaje.ShowDialog()
    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dim NumeroFilas As Integer = 0
        Dim PedidosMuestrasNegocios As New Ventas.Negocios.PedidosMuestrasBU
        Dim arreglo As New ArrayList
        Dim ListaInt As New List(Of Integer)
        Dim UsuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVmodelos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If grdVmodelos.GetRowCellValue(index, "Sel") Then
                    ListaInt.Add(index)
                End If
            Next
            If ListaInt.Count > 0 Then
                Dim objMensajeQ As New ConfirmarForm
                objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
                If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                    For Each index As Integer In ListaInt
                        'PedidosMuestrasNegocios.CancelarMuestra(grdVmodelos.GetRowCellValue(index, "Pedido"),
                        '                                                           grdVmodelos.GetRowCellValue(index, "Articulo"),
                        '                                                           grdVmodelos.GetRowCellValue(index, "UDM"),
                        '                                                           grdVmodelos.GetRowCellValue(index, "Talla"), UsuarioID)
                        PedidosMuestrasNegocios.CancelarMuestra(grdVmodelos.GetRowCellValue(index, "Pedido"),
                                                                                   grdVmodelos.GetRowCellValue(index, "pdtem_pedidomuestradetalleid"), UsuarioID)
                    Next
                    Dim mensaje As New ExitoForm
                    mensaje.mensaje = "El registro se realizó con éxito."
                    mensaje.ShowDialog()
                Else
                End If
            Else
                ValidaSeleccion()
            End If
            LlenarGrid()
            Cursor = Cursors.Default
        Catch ex As Exception
            Dim mensaje As New ErroresForm
            mensaje.mensaje = ex.Message.ToString
            mensaje.ShowDialog()
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVmodelos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                grdVmodelos.SetRowCellValue(grdVmodelos.GetVisibleRowHandle(index), "Sel", chboxSeleccionarTodo.Checked)
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub
    'Private Sub cargaNavesCedis()
    '    Dim objNeg As New Negocios.PedidosMuestrasBU
    '    Dim dtRegistrosCancelar As DataTable
    '    dtRegistrosCancelar = objNeg.obtenerCedisNaves
    '    dtRegistrosCancelar.Rows.InsertAt(dtRegistrosCancelar.NewRow, 0)
    '    cboxNaveCedis.DataSource = dtRegistrosCancelar
    '    If dtRegistrosCancelar.Rows.Count > 0 Then
    '        cboxNaveCedis.DisplayMember = "cedis"
    '        cboxNaveCedis.ValueMember = "naveId"
    '    End If
    'End Sub
End Class