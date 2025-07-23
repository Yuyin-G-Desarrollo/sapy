Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports Tools
Imports DevExpress.XtraPrinting

Public Class MovimientosMuestrasForm
    Dim confirmarMuestrasFabricadas, EntregaMuestrasCliente, TransferenciaEntrada, TransferenciaSalida, Reingreso As Boolean
    Dim etiqueta As String
    Dim dtRow As DataTable
    Dim UltimaAccion As Integer = 1
    Dim cancel As Boolean

    Private Sub DiseñoGriEtiquetasMuestras(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        If IsNothing(Grid.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            Grid.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler Grid.CustomUnboundColumnData, AddressOf grdVEtiquetasMuestras_CustomUnboundColumnData
            Grid.Columns.Item("#").VisibleIndex = 0
        End If
        'Grid.OptionsView.ColumnAutoWidth = False
        'Grid.BestFitColumns()
        Tools.DiseñoGrid.AjustarAltoEncabezados(Grid)
        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(Grid)
        Tools.DiseñoGrid.AlternarColorEnFilas(Grid)
        Tools.DiseñoGrid.DeshabilitarEdicion(Grid)
        Tools.DiseñoGrid.FiltroContiene(Grid)
        Tools.DiseñoGrid.AjustarAnchoColumnas(Grid)



        Tools.DiseñoGrid.OcultarColumna(Grid, "EstatusId")
        Tools.DiseñoGrid.OcultarColumna(Grid, "FechaRecepción")
        Tools.DiseñoGrid.OcultarColumna(Grid, "EstatusProductoEstiloID")
        Tools.DiseñoGrid.OcultarColumna(Grid, "cedis_id")

        Grid.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        If IsNothing(Grid.Columns("Pieza").Summary.FirstOrDefault(Function(x) x.FieldName = "Pieza")) = True Then
            Grid.Columns("Pieza").Summary.Add(DevExpress.Data.SummaryItemType.Count, "Pieza", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pieza"
            item.SummaryType = DevExpress.Data.SummaryItemType.Count
            item.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item)
        End If

        Dim value As Object = cmbMovimiento.SelectedValue
        If (TypeOf value Is Integer) Then
            Select Case value
                Case 1
                    Grid.Columns.ColumnByFieldName("EntregaReal").Visible = False
                    Grid.Columns.ColumnByFieldName("ClienteOrigen").Visible = False
                Case 2
                    Grid.Columns.ColumnByFieldName("EntregaReal").Visible = False
                Case 3

                Case 4
                    Grid.Columns.ColumnByFieldName("EntregaReal").Visible = False
            End Select
        End If

    End Sub

    Private Sub grdVEtiquetasMuestras_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = grdVEtiquetasMuestras.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Function valida() As Boolean
        Try
            etiqueta = String.Empty
            etiqueta = txtEtiqueta.Text.Trim.ToString
            If etiqueta.Length = 0 Then
                Controles.Mensajes_Y_Alertas("ADVERTENCIA", "El campo etiqueta no puede ser vacio.")
                Return False
            End If

            If cboxNaveCedis.Text = "" Then
                Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Es necesario seleccionar un cedis.")
                Return False
            End If

            Dim NumeroFilas As Integer = 0
            Dim fila As Integer
            NumeroFilas = grdVEtiquetasMuestras.DataRowCount
            If NumeroFilas > 0 Then
                For index As Integer = 0 To NumeroFilas - 1
                    fila = index + 1
                    If CStr(grdVEtiquetasMuestras.GetRowCellValue(index, "Pieza").ToString.Trim) = CStr(etiqueta) Then
                        Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La fila " & fila.ToString & " capturada ya contiene la etiqueta " + etiqueta + ".")
                        Return False
                        Exit For
                    End If
                Next
            End If

            Dim objNeg As New Programacion.Negocios.MovimientoMuestrasBU
            dtRow = objNeg.tablaLayoutEtiquetasMuestras(etiqueta)
            If dtRow.Rows.Count > 0 Then
            Else
                Controles.Mensajes_Y_Alertas("ADVERTENCIA", "No se encuentra la etiqueta " + etiqueta + " o el modelo se encuentra en estatus NO AUTORIZADO.")
                Return False
            End If

            Dim cedisregistrado As Integer = 0
            For X = 0 To dtRow.Rows.Count - 1
                cedisregistrado = dtRow.Rows(X).Item(22) ''---> ceDIS_id con el cual se obtiene desde la BD
                If cedisregistrado <> 0 Then
                    If cedisregistrado <> cboxNaveCedis.SelectedValue Then
                        If cboxNaveCedis.Text = "COMERCIALIZADORA" Then
                            Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La etiqueta no corresponde al cedis de: " + cboxNaveCedis.Text + " favor de cambiar el cedis a REEDITION")
                            Return False
                        Else
                            Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La etiqueta no corresponde al cedis de: " + cboxNaveCedis.Text + " favor de cambiar el cedis a COMERCIALIZADORA")
                            Return False
                        End If

                    End If
                End If
            Next

            Dim value As Object
            value = cmbMovimiento.SelectedValue
            If (TypeOf value Is Integer) Then
                Dim estatus As Integer = CInt(dtRow.Rows(0).Item("EstatusId"))
                Dim statusEstilo As Integer = CInt(dtRow.Rows(0).Item("EstatusProductoEstiloID"))
                Dim fechaRecepcion As String = If(IsDBNull(dtRow.Rows(0).Item("FechaRecepción").ToString), "", dtRow.Rows(0).Item("FechaRecepción").ToString)
                Select Case value
                    'ENTREGA DE MUESTRAS A CLIENTE
                    Case 1
                        If statusEstilo = 7 Then
                            Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La etiqueta " + etiqueta + " con estatus " + dtRow.Rows(0).Item("Status").ToString + ", el modelo se encuentra en estatus NO AUTORIZADO.")
                        Else
                            If estatus = 139 Or estatus = 143 Then
                                Return True
                            Else
                                Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La etiqueta " + etiqueta + " con estatus " + dtRow.Rows(0).Item("Status").ToString + " no es válida para este movimiento")
                            End If
                        End If
                    'PASAR A DISPONIBLE
                    Case 2
                        If fechaRecepcion <> "" Then
                            If estatus = 139 Or estatus = 143 Then 'Or estatus = 141 Then
                                Return True
                            Else
                                Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La etiqueta " + etiqueta + " con estatus " + dtRow.Rows(0).Item("Status").ToString + " no es válida para este movimiento")
                            End If
                        End If
                        'REINGRESO
                    Case 3
                        If estatus = 140 Or estatus = 182 Then
                            Return True
                        Else
                            Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La etiqueta " + etiqueta + " con estatus " + dtRow.Rows(0).Item("Status").ToString + " no es válida para este movimiento")
                        End If
                    'SALIDA POR AJUSTE DE INVENTARIO
                    Case 4
                        If estatus = 143 Or estatus = 139 Or estatus = 142 Then
                            Return True
                        Else
                            Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La etiqueta " + etiqueta + " con estatus " + dtRow.Rows(0).Item("Status").ToString + " no es válida para este movimiento")
                        End If
                End Select
            End If



            'If accion = 1 Then
            '    Dim estatus As Integer = CInt(dtRow.Rows(0).Item("EstatusId"))
            '    If estatus = 140 Or estatus = 143 Or estatus = 139 Or estatus = 141 Then
            '        Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La etiqueta " + etiqueta + " ya se encuentra con estatus " + IIf(estatus = 140, "enviada a cliente.", IIf(estatus = 143, "confirmada.", "")).ToString)
            '        Return False
            '    End If
            'End If

            'If accion = 2 Then
            '    Dim estatus As Integer = CInt(dtRow.Rows(0).Item("EstatusId"))
            '    If estatus <> 143 Then
            '        Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La etiqueta " + etiqueta + " debe ser una recepcion confirmada.")
            '        Return False
            '    End If
            'End If

            valida = False
        Catch ex As Exception
            Throw ex
            valida = False
        End Try
    End Function

    Private Sub AgregarFilaGrid()
        Try

            If valida() Then
                Dim newRow As DataRow = (TryCast(grdEtiquetasMuestras.DataSource, DataTable)).NewRow()
                For Each col As DataColumn In dtRow.Columns
                    newRow(col.ColumnName) = dtRow.Rows(0).Item(col.ColumnName)
                Next
                TryCast(grdEtiquetasMuestras.DataSource, DataTable).Rows.Add(newRow)

            End If
        Catch ex As Exception
            Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
        Finally
            lblTotalRegistros.Text = grdVEtiquetasMuestras.RowCount.ToString
            grdEtiquetasMuestras.RefreshDataSource()
            DiseñoGriEtiquetasMuestras(grdVEtiquetasMuestras)
            txtEtiqueta.Text = Nothing
            Me.ActiveControl = txtEtiqueta
        End Try
    End Sub

    Private Sub MovimientosMuestrasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("MOVIMIENTOS_MUESTRAS", "CONFIRMAR_MUESTRAS_FABRICADAS") Then
        '    confirmarMuestrasFabricadas = True
        'End If

        'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("MOVIMIENTOS_MUESTRAS", "ENTREGAR_MUESTRAS_CLIENTE") Then
        '    EntregaMuestrasCliente = True
        'End If

        'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("MOVIMIENTOS_MUESTRAS", "TRANSFERENCIA_ENTRADA") Then
        '    TransferenciaEntrada = True
        'End If

        'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("MOVIMIENTOS_MUESTRAS", "TRANSFERENCIA_SALIDA") Then
        '    TransferenciaSalida = True
        'End If

        'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("MOVIMIENTOS_MUESTRAS", "REINGRESO") Then
        '    Reingreso = True
        'End If


        'Creo mi datatable y columnas
        Dim dtEstatus As New DataTable
        dtEstatus.Columns.Add("id", GetType(Integer))
        dtEstatus.Columns.Add("Descripcion")

        'Renglon es la variable que adicionara renglones a mi datatable
        Dim Renglon As DataRow = dtEstatus.NewRow()

        Renglon = dtEstatus.NewRow()
        Renglon("id") = 1
        Renglon("Descripcion") = "ENTREGA DE MUESTRAS A CLIENTE"
        dtEstatus.Rows.Add(Renglon)


        Renglon = dtEstatus.NewRow()
        Renglon("id") = 2
        Renglon("Descripcion") = "PASAR A DISPONIBLE"
        dtEstatus.Rows.Add(Renglon)



        Renglon = dtEstatus.NewRow()
        Renglon("id") = 3
        Renglon("Descripcion") = "REINGRESO"
        dtEstatus.Rows.Add(Renglon)


        Renglon = dtEstatus.NewRow()
        Renglon("id") = 4
        Renglon("Descripcion") = "SALIDA POR AJUSTE DE INVENTARIO"
        dtEstatus.Rows.Add(Renglon)


        cmbMovimiento.DataSource = dtEstatus
        cmbMovimiento.DisplayMember = "Descripcion"
        cmbMovimiento.ValueMember = "id"

        cmbMovimiento_SelectedIndexChanged(cmbMovimiento, e)
        cargaNavesCedis()
        LimpiarGrid()

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        AgregarFilaGrid()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        grdVEtiquetasMuestras.DeleteSelectedRows()
        lblTotalRegistros.Text = grdVEtiquetasMuestras.RowCount.ToString
        Me.ActiveControl = txtEtiqueta
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                Dim exportOptions = New XlsxExportOptionsEx()
                AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then
                    If grdVEtiquetasMuestras.GroupCount > 0 Then
                        grdVEtiquetasMuestras.ExportToXlsx(.SelectedPath + "\MovimientosDeMuestras_" + fecha_hora + ".xlsx", exportOptions)
                    Else
                        grdVEtiquetasMuestras.ExportToXlsx(.SelectedPath + "\MovimientosDeMuestras_" + fecha_hora + ".xlsx", exportOptions)
                    End If
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "MovimientosDeMuestras_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\MovimientosDeMuestras_" + fecha_hora + ".xlsx")

                End If
            End With

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub
    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim NumeroFilas As Integer = 0
        Dim idSalida As Integer = 0
        Dim Motivo As String = String.Empty
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim form As New MovimientosMuestrasForm_Motivo
        Try
            If grdVEtiquetasMuestras.DataRowCount > 0 Then
                Dim objMensajeQ As New ConfirmarForm
                objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
                If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim accion As Integer
                    Dim objNeg As New Programacion.Negocios.MovimientoMuestrasBU
                    accion = cmbMovimiento.SelectedValue
                    NumeroFilas = grdVEtiquetasMuestras.DataRowCount
                    If accion = 4 Then
                        form.Movimiento = cmbMovimiento.Text.Trim
                        form.Piezas = NumeroFilas
                        form.ShowDialog()
                        If form.Accion = "CERRAR" Then
                            Exit Sub
                        ElseIf form.Accion = "GUARDAR" Then
                            Motivo = form.Motivo
                            Dim dtId As DataTable
                            dtId = objNeg.InsertarSalidasInventario(NumeroFilas, Motivo, usuario)
                            If Not IsNothing(dtId) Then
                                If dtId.Rows.Count > 0 Then
                                    idSalida = dtId.Rows(0).Item("ID")
                                End If
                            End If
                        End If
                    End If
                    Cursor = Cursors.WaitCursor


                    For index As Integer = 0 To NumeroFilas - 1
                        objNeg.EditarPedidosMuestrasPiezas(CStr(grdVEtiquetasMuestras.GetRowCellValue(index, "Pieza")).Trim, accion, usuario, idSalida)
                        'objNeg.EditarPedidosMuestrasPiezas(CStr(grdVEtiquetasMuestras.GetRowCellValue(index, "Etiqueta")).Trim, accion)
                    Next
                    Controles.Mensajes_Y_Alertas("EXITO", "El registro se realizó con éxito.")
                End If
                LimpiarGrid()
            Else
                Controles.Mensajes_Y_Alertas("ADVERTENCIA", "No se encontraron registros en la lista.")
            End If
        Catch ex As Exception
            Controles.Mensajes_Y_Alertas("ERROR", ex.Message.ToString)
        Finally
            grdEtiquetasMuestras.RefreshDataSource()
            Cursor = Cursors.Default
            txtEtiqueta.Text = Nothing
            Me.ActiveControl = txtEtiqueta
        End Try
    End Sub



    Private Sub cmbMovimiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMovimiento.SelectedIndexChanged
        Dim value As Object
        value = cmbMovimiento.SelectedValue

        If (TypeOf value Is Integer) Then
            Select Case value
                Case 1
                    lblInfo.Text = "*Unicamente piezas en status RECEPCIÓN CONFIRMADA o APARTADA"
                Case 2
                    lblInfo.Text = "*Unicamente piezas en status RECEPCIÓN CONFIRMADA o APARTADA"
                Case 3
                    lblInfo.Text = "*Unicamente piezas en status ENVIADO CLIENTE o SALIDA POR AJUSTE DE INVENTARIO"
                Case 4
                    lblInfo.Text = "*Unicamente piezas en status RECEPCIÓN CONFIRMADA, APARTADA o DISPONIBLE"
            End Select
        End If
        LimpiarGrid()
        Me.ActiveControl = txtEtiqueta
    End Sub


    Private Sub grdEtiquetasMuestras_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles grdEtiquetasMuestras.ProcessGridKey
        If e.KeyData = Keys.Delete Then
            grdVEtiquetasMuestras.DeleteSelectedRows()
            lblTotalRegistros.Text = grdVEtiquetasMuestras.RowCount.ToString
            Me.ActiveControl = txtEtiqueta
            e.Handled = True
        End If
    End Sub

    Private Sub LimpiarGrid()
        Dim dtEtiquetasMuestras As DataTable
        Dim MovimientosMuestrasNegocio As New Programacion.Negocios.MovimientoMuestrasBU
        grdEtiquetasMuestras.DataSource = Nothing
        grdVEtiquetasMuestras.Columns.Clear()
        dtEtiquetasMuestras = MovimientosMuestrasNegocio.tablaLayoutEtiquetasMuestras
        grdEtiquetasMuestras.DataSource = dtEtiquetasMuestras
        DiseñoGriEtiquetasMuestras(grdVEtiquetasMuestras)
        lblTotalRegistros.Text = grdVEtiquetasMuestras.RowCount.ToString
    End Sub
    Private Sub cargaNavesCedis()
        'Dim objNeg As New Programacion.Negocios.MovimientoMuestrasBU
        'Dim dtRegistrosMov As DataTable
        'dtRegistrosMov = objNeg.obtenerCedisNaves
        'dtRegistrosMov.Rows.InsertAt(dtRegistrosMov.NewRow, 0)
        'cboxNaveCedis.DataSource = dtRegistrosMov
        'If dtRegistrosMov.Rows.Count > 0 Then
        '    cboxNaveCedis.DisplayMember = "cedis"
        '    cboxNaveCedis.ValueMember = "naveId"
        'End If
        Utilerias.ComboObtenerCEDISUsuario(cboxNaveCedis)
    End Sub
End Class