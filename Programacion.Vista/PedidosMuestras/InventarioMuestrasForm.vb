Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports Tools

Public Class InventarioMuestrasForm

    Dim Accion As Integer = 0

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub rdoConfirmados_CheckedChanged(sender As Object, e As EventArgs) Handles rdoConfirmados.CheckedChanged
        If rdoConfirmados.Checked Then
            Accion = 1
        End If
    End Sub

    Private Sub rdoEntregados_CheckedChanged(sender As Object, e As EventArgs) Handles rdoEntregados.CheckedChanged
        If rdoEntregados.Checked Then
            Accion = 2
        End If
    End Sub

    Private Sub rdoDisponibles_CheckedChanged(sender As Object, e As EventArgs) Handles rdoDisponibles.CheckedChanged
        If rdoDisponibles.Checked Then
            Accion = 3
        End If
    End Sub

    Private Sub InventarioMuestrasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        rdoConfirmados.Checked = True
        chboxSeleccionarTodo.Checked = False
    End Sub



    Private Sub LlenarGrid()
        Try
            Dim objNeg As New Negocios.PedidosMuestrasOP
            Dim dt As DataTable
            Dim Modelo As String
            If Accion > 0 Then
                Modelo = txtModelo.Text
                dt = objNeg.consultaInventarioMuestras(Accion, Modelo)
                grdInventario.DataSource = dt
                If grdVinventario.RowCount > 0 Then
                    DiseñoGridInventarioMuestras(grdVinventario)
                    pintarCheckBox()
                End If
            End If
            chkCaja.Checked = False
            chkSuela.Checked = False
            chkColgante.Checked = False
        Catch ex As Exception
            MsgBox(" Debe seleccionar un registro.")
        End Try

    End Sub

    Public Sub pintarCheckBox()
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVinventario.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                grdVinventario.SetRowCellValue(grdVinventario.GetVisibleRowHandle(index), "Sel", False)
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub DiseñoGridInventarioMuestras(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)

        Grid.OptionsView.ColumnAutoWidth = True
        Grid.OptionsView.BestFitMaxRowCount = -1


        If IsNothing(Grid.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            Grid.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler Grid.CustomUnboundColumnData, AddressOf grdVInventarioMuestras_CustomUnboundColumnData
            Grid.Columns.Item("#").VisibleIndex = 0
        End If

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        Grid.Columns.ColumnByFieldName("Pedido").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("PedidoActual").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Etiqueta").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Cantidad").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Agente").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Asunto").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Modelo").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Marca").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Coleccion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("PielColor").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("UDM").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Talla").OptionsColumn.AllowEdit = False


        'Grid.Columns.ColumnByFieldName("ClaveCitaEntrega").Visible = False


        ' Grid.Columns.ColumnByFieldName("Capturados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric



        'Grid.Columns.ColumnByFieldName("Capturados").DisplayFormat.FormatString = "N0"

        'Grid.Columns.ColumnByFieldName("#").Width = 25
        'Grid.Columns.ColumnByFieldName("ColorEstatus").Width = 25


        'Grid.Columns.ColumnByFieldName("Apartados").OptionsColumn.AllowEdit = False


        'Grid.Columns.ColumnByFieldName("Partida").Width = 55


        'Grid.Columns.ColumnByFieldName("OT").Caption = "OT " & vbCrLf & "SAY"
        'Grid.Columns.ColumnByFieldName("OTSICY").Caption = "OT " & vbCrLf & "SICY"
        'Grid.Columns.ColumnByFieldName("PedidoSAY").Caption = "Pedido " & vbCrLf & "SAY"
        'Grid.Columns.ColumnByFieldName("PedidoSICY").Caption = "Pedido " & vbCrLf & "SICY"
        'Grid.Columns.ColumnByFieldName("FechaEntregaProgramacion").Caption = "F Entrega"
        'Grid.Columns.ColumnByFieldName("FechaPreparacion").Caption = "F Preparación"

        'Grid.Columns.ColumnByFieldName("OTSICY").Visible = False

        'If TipoPerfil = 1 Then
        '    Grid.Columns.ColumnByFieldName("UsuarioCaptura").Caption = "Capturó"
        '    Grid.Columns.ColumnByFieldName("OperadorAsignado").Visible = False
        '    Grid.Columns.ColumnByFieldName("OperadorConfirmo").Visible = False
        'Else
        '    Grid.Columns.ColumnByFieldName("UsuarioCaptura").Caption = "Proyectó"
        '    Grid.Columns.ColumnByFieldName("OperadorAsignado").Visible = True
        '    Grid.Columns.ColumnByFieldName("OperadorConfirmo").Visible = True
        'End If


        'Grid.Columns.ColumnByFieldName("FechaCreacion").Caption = "F Captura"

        'Grid.Columns.ColumnByFieldName("Cantidad").Width = 60



        Grid.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(Grid.Columns("Cantidad").Summary.FirstOrDefault(Function(x) x.FieldName = "Cantidad")) = True Then
            Grid.Columns("Cantidad").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Capturados"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item)
        End If


        ''Grid.Columns.ColumnByFieldName("Sel").OptionsColumn.AllowEdit = True
        'Grid.Columns.ColumnByFieldName("Folio").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowEdit = False
        ''Grid.Columns.ColumnByFieldName("FechaConfirmo").DisplayFormat.FormatString = "dd/mm/yyyy HH:mm:ss"
        'Grid.Columns.ColumnByFieldName("FechaCreacion").OptionsColumn.AllowEdit = False

        'Grid.Columns.ColumnByFieldName("FechaCitaEntrega").DisplayFormat.FormatString = "dd/mm/yyyy HH:mm:ss"
        'grdVentas.Columns.ColumnByFieldName("DiasFaltantes").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Grid.BestFitColumns()

    End Sub

    Private Sub grdVInventarioMuestras_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = grdVinventario.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub btnBuscarDisponibles_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        LlenarGrid()
    End Sub

    Private Sub btnImprimirEtiquetas_Click(sender As Object, e As EventArgs) Handles btnImprimirEtiquetas.Click
        Dim NumeroFilas As Integer = 0
        Dim ListaStr As New List(Of String)
        Dim tbl_DatosEtiquetas As New DataTable
        Dim Contador As Integer = 0
        Dim ContadorEtiquetas As Integer = 0
        Dim TipoEtiqueta As String = String.Empty

        tbl_DatosEtiquetas.Columns.Add("Etiqueta")
        tbl_DatosEtiquetas.Columns.Add("Coleccion")
        tbl_DatosEtiquetas.Columns.Add("UDM")
        tbl_DatosEtiquetas.Columns.Add("TipoImpresion")
        tbl_DatosEtiquetas.Columns.Add("Etiquetas")

        If chkColgante.Checked = False And chkCaja.Checked = False And chkSuela.Checked = False Then
            Dim form As New AdvertenciaForm
            form.mensaje = "Selecciona al menos un tipo de etiqueta."
            form.ShowDialog()
        Else
            If chkCaja.Checked And chkSuela.Checked Then
                TipoEtiqueta = "Caja y Suela"
            ElseIf chkCaja.Checked Then
                TipoEtiqueta = "Caja"
            ElseIf chkSuela.Checked Then
                TipoEtiqueta = "Suela"
            ElseIf chkColgante.Checked Then
                TipoEtiqueta = "Colgante"
            End If


            Try
                Cursor = Cursors.WaitCursor
                Dim form As New ImprimirEtiquetasForm
                NumeroFilas = grdVinventario.DataRowCount
                If NumeroFilas > 0 Then
                    For index As Integer = 0 To NumeroFilas - 1
                        If grdVinventario.GetRowCellValue(index, "Sel") Then
                            tbl_DatosEtiquetas.Rows.Add(New Object() {grdVinventario.GetRowCellValue(index, "Etiqueta"), grdVinventario.GetRowCellValue(index, "Coleccion"), grdVinventario.GetRowCellValue(index, "UDM"), cmbImpresion.Text, TipoEtiqueta})
                            'ListaStr.Add(CStr(grdVinventario.GetRowCellValue(index, "Etiqueta")))
                        End If
                    Next
                    form.Tbl_EtiquetasImprimir = tbl_DatosEtiquetas
                    form.ImpresionPorEtiqueta = True
                    'form.ListaStr = ListaStr
                    form.ShowDialog()
                Else
                    Dim mensaje As New AdvertenciaForm
                    mensaje.mensaje = "No se encontraron registros seleccionados. Favor de corroborar la selección para la impresión."
                    mensaje.ShowDialog()
                End If
                LlenarGrid()
                Cursor = Cursors.Default

            Catch ex As Exception
                Dim mensaje As New AdvertenciaForm
                mensaje.mensaje = ex.Message
                mensaje.ShowDialog()
                LlenarGrid()
                Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub chkColgante_CheckedChanged(sender As Object, e As EventArgs) Handles chkColgante.CheckedChanged
        If chkColgante.Checked Then
            chkCaja.Checked = False
            chkSuela.Checked = False
        End If
    End Sub

    Private Sub chkCaja_CheckedChanged(sender As Object, e As EventArgs) Handles chkCaja.CheckedChanged
        If chkCaja.Checked Then
            chkColgante.Checked = False
        End If
    End Sub

    Private Sub chkSuela_CheckedChanged(sender As Object, e As EventArgs) Handles chkSuela.CheckedChanged
        If chkSuela.Checked Then
            chkColgante.Checked = False
        End If
    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Dim NumeroFilas As Integer = 0
        Dim var_VariableChecadora As Boolean = False

        If chboxSeleccionarTodo.Checked = True Then
            var_VariableChecadora = True
        Else
            var_VariableChecadora = False
        End If

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVinventario.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                grdVinventario.SetRowCellValue(grdVinventario.GetVisibleRowHandle(index), "Sel", var_VariableChecadora)
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btn_EscaneoMultiple_Click(sender As Object, e As EventArgs) Handles btn_EscaneoMultiple.Click
        Dim AbrirEscaneoMasivo_Form As New EscaneoMasivoEtiquetasForm
        AbrirEscaneoMasivo_Form.Show()
    End Sub
End Class