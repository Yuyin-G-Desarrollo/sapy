Imports Ventas.Negocios
Imports Tools
Imports DevExpress.XtraGrid.Columns

Public Class ModificacionesEspecialesForm
    Public cliente As String
    Public clienteId As Integer
    Public pedidoOrigen As Integer
    Public PedidoSAY As Integer
    Public PedidoSICY As Integer
    Public Tipo As String
    Public Ots As String
    Public OC As String

    Dim value As Object
    Dim value2 As Object
    Dim Usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
    Dim UsuarioId As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    Dim rfcbloqueado As Boolean = True
    Dim tblRFC As New DataTable
    Dim rfcSICYNuevo As Integer
    Dim listData As New List(Of Integer)
    Private Sub ModificacionesEspecialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obj = New Negocios.OrdenTrabajoBU
        Dim estatusPedido As Integer = 0




        txtCliente.Text = cliente
        txtPedidoOrigen.Text = pedidoOrigen.ToString()
        txtPedidoSAY.Text = PedidoSAY.ToString()
        txtPedidoSICY.Text = PedidoSICY.ToString()
        lblOTs.Text = Ots
        lblTipo.Text = Tipo
        estatusPedido = obj.ValidarestatusPedido(PedidoSAY)
        txtOC.Text = OC
        ' estatusPedido = 0
        If estatusPedido = 11 Or estatusPedido = 12 Or estatusPedido = 13 Or estatusPedido = 14 Then
            'CargarComboRFCActual()
            'CargarComboTienda(cboRFC.SelectedValue)
            chkCamcioRFC.Enabled = False
            CargarComboRFCActual()
            rfcbloqueado = True
        Else
            'CargarComboRFC()
            rfcbloqueado = False
            CargarComboRFCActual()
            CargarComboTienda(cboRFC.SelectedValue)
        End If

        cboRFC.Enabled = False

        'btnGuardar.Enabled = False
        'lblGuardar.Enabled = False

        CargarPartidas()

    End Sub

    Private Sub CargarComboRFC()
        Dim obj = New Negocios.OrdenTrabajoBU
        'Dim tblRFC As New DataTable
        tblRFC = obj.ConsultaRFCCliente(clienteId, rfcbloqueado, PedidoSAY)
        cboRFC.DataSource = tblRFC
        cboRFC.ValueMember = "RFCIdSAY"
        cboRFC.DisplayMember = "RFC"
        rfcSICYNuevo = tblRFC.AsEnumerable().Where(Function(y) y.Item("RFCIdSAY").ToString = cboRFC.SelectedValue).Select(Function(x) x.Item("RFCIdSICY")).FirstOrDefault()
        CargarComboTienda(cboRFC.SelectedValue)
    End Sub

    Private Sub CargarComboRFCActual()
        Dim obj = New Negocios.OrdenTrabajoBU
        Dim tblRFC As New DataTable
        tblRFC = obj.ConsultaRFCCliente(clienteId, 1, PedidoSAY)
        cboRFC.DataSource = tblRFC
        cboRFC.ValueMember = "RFCIdSAY"
        cboRFC.DisplayMember = "RFC"
        rfcSICYNuevo = tblRFC.AsEnumerable().Where(Function(y) y.Item("RFCIdSAY").ToString = cboRFC.SelectedValue).Select(Function(x) x.Item("RFCIdSICY")).FirstOrDefault()
        CargarComboTienda(cboRFC.SelectedValue)
    End Sub
    Private Sub CargarComboTienda(ByVal rfc As Integer)
        Dim obj = New Negocios.OrdenTrabajoBU
        Dim tblTienda As New DataTable
        value2 = cboRFC.SelectedValue
        If TypeOf value2 Is Integer Then
            listData.Clear()
            tblTienda = obj.ConsultaTiendasRFC(clienteId, rfc)
            'tblTienda.Rows.InsertAt(tblTienda.NewRow, 0)
            If tblTienda.Rows.Count > 0 Then
                cboTienda.Enabled = True
                cboTienda.DataSource = tblTienda
                cboTienda.ValueMember = "TECEDIS"
                cboTienda.DisplayMember = "TIENDA"
                For i As Integer = 0 To tblTienda.Rows.Count - 1
                    listData.Add(tblTienda.Rows(i).Item("TECEDIS"))
                Next
            Else
                cboTienda.Text = ""
                cboTienda.SelectedValue = 0
                cboTienda.Enabled = False
            End If

        End If

    End Sub

    Private Sub cboRFC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRFC.SelectedIndexChanged
        value = cboRFC.SelectedValue
        If TypeOf value Is Integer Then
            CargarComboTienda(cboRFC.SelectedValue)
            rfcSICYNuevo = tblRFC.AsEnumerable().Where(Function(y) y.Item("RFCIdSAY").ToString = cboRFC.SelectedValue).Select(Function(x) x.Item("RFCIdSICY")).FirstOrDefault()
            For index As Integer = 0 To grdVWPartidas.RowCount - 1
                'grdVWPartidas.SetRowCellValue(index,"Tienda",cboRFC.Text)
                grdVWPartidas.SetRowCellValue(index, "RFCNuevo", "")
                grdVWPartidas.SetRowCellValue(index, "TECedisIdNuevo", "")
            Next
            grdVWPartidas.Focus()
        End If
    End Sub

    Private Sub CargarPartidas()
        Dim obj = New Negocios.OrdenTrabajoBU
        Dim dtPartidas As New DataTable

        grdPartidas.DataSource = Nothing
        grdVWPartidas.Columns.Clear()
        dtPartidas = obj.ConultaDetallePedido(PedidoSAY, Ots)

        If dtPartidas.Rows.Count > 0 Then
            grdPartidas.DataSource = dtPartidas
            disenioGrid()
        End If

        lblTotalRegistros.Text = dtPartidas.Rows.Count
        lblActualizacion.Text = Date.Now

    End Sub

    Private Sub disenioGrid()

        grdVWPartidas.IndicatorWidth = 40
        grdVWPartidas.BestFitColumns()

        grdVWPartidas.Columns("RFCActual").Visible = False
        grdVWPartidas.Columns("TECedisId").Visible = False
        grdVWPartidas.Columns("RFCNuevo").Visible = False
        grdVWPartidas.Columns("TECedisIdNuevo").Visible = False
        grdVWPartidas.Columns("Modificado").Visible = False
        grdVWPartidas.Columns("OC").Visible = False

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVWPartidas.Columns
            If col.FieldName = "PedidoSAY" Then
                col.Caption = "PEDIDO SAY"
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "PedidoSICY" Then
                col.Caption = "PEDIDO SICY"
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Partida" Then
                col.Caption = "PARTIDA"
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "OT" Then
                col.Caption = "OT"
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Articulo" Then
                col.Caption = "ARTICULO"
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Tienda" Then
                col.Caption = "TIENDA"
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Pares" Then
                col.Caption = "PARES"
                col.OptionsColumn.AllowEdit = False
            End If
            If col.FieldName = "Modificado" Then
                col.Caption = "MODIFICADO"
                col.OptionsColumn.AllowEdit = False
            End If
            col.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        Next

        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(grdVWPartidas)
        Tools.DiseñoGrid.AlternarColorEnFilasTenue(grdVWPartidas)

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVWPartidas.Columns
            col.Summary.Remove(col.SummaryItem)
            If col.FieldName.Contains("#") Or col.FieldName.Contains("Pares") Then
                col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
            End If
        Next



    End Sub

    Private Sub grdVWPartidas_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdVWPartidas.CustomDrawRowIndicator
        If (e.RowHandle >= 0) Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Dim filas As Integer = grdVWPartidas.DataRowCount
        Dim partidas As String = String.Empty
        Try
            For i As Integer = 0 To filas Step 1
                If grdVWPartidas.GetRowCellValue(i, "SEL") = True Then
                    If partidas <> String.Empty Then
                        partidas = partidas & "," & grdVWPartidas.GetRowCellValue(i, "Partida")
                    Else
                        partidas = grdVWPartidas.GetRowCellValue(i, "Partida")
                    End If
                End If
            Next
            If partidas <> String.Empty Then
                If cboTienda.Text = "" Then
                    Tools.MostrarMensaje(Mensajes.Notice, "Seleccione una tienda.")
                Else
                    For i As Integer = 0 To filas Step 1
                        If grdVWPartidas.GetRowCellValue(i, "SEL") Then
                            grdVWPartidas.SetRowCellValue(i, "TECedisIdNuevo", cboTienda.SelectedValue)
                            grdVWPartidas.SetRowCellValue(i, "Tienda", cboTienda.Text)
                            grdVWPartidas.SetRowCellValue(i, "RFCNuevo", cboRFC.SelectedValue)
                        End If
                    Next
                End If
                btnGuardar.Enabled = True
                lblGuardar.Enabled = True
            Else
                Tools.MostrarMensaje(Mensajes.Notice, "Seleccione al menos una partida para asignar.")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim obj = New Negocios.OrdenTrabajoBU
        Dim confirmarDialog As New ConfirmarForm
        Dim resultadoDialog As New DialogResult
        Dim rfcN As String = String.Empty
        Dim rfcAux As String = String.Empty
        Dim rfcDiferente As Integer
        Dim TECN As String = String.Empty
        Dim filas As Integer = grdVWPartidas.DataRowCount
        Dim PedidoSAY, PedidoSICY, Ot, RFCAnterior, RFCNuevo, TECedisIdAnterior, TIECNuevo As Integer
        Dim PartidaId As String
        Dim RFCActual As Integer
        Dim cont As Integer = 0
        Dim modificado As Integer
        Dim ocAnterior As String
        Dim ocNuevo As String

        Try
            Me.Cursor = Cursors.WaitCursor

            If chkOC.Checked Then
                cont += 1
            End If

            If validarRFCyTienda() > 0 Then
                Tools.MostrarMensaje(Mensajes.Notice, "Algunas tiendas no corresponden al RFC seleccionado.")
                Return
            End If


            'confirmarDialog.mensaje = "¿Desea guardar los cambios realizados?"
            'resultadoDialog = confirmarDialog.ShowDialog
            'If resultadoDialog = DialogResult.OK Then
            For i As Integer = 0 To grdVWPartidas.DataRowCount - 1
                RFCNuevo = 0
                TIECNuevo = 0
                PedidoSAY = grdVWPartidas.GetRowCellValue(i, "PedidoSAY")
                PedidoSICY = grdVWPartidas.GetRowCellValue(i, "PedidoSICY")
                Ot = grdVWPartidas.GetRowCellValue(i, "OT")
                PartidaId = grdVWPartidas.GetRowCellValue(i, "Partida")
                RFCAnterior = grdVWPartidas.GetRowCellValue(i, "RFCActual")
                TECedisIdAnterior = grdVWPartidas.GetRowCellValue(i, "TECedisId")

                If grdVWPartidas.GetRowCellValue(i, "RFCNuevo").ToString() <> "" Then
                    RFCNuevo = grdVWPartidas.GetRowCellValue(i, "RFCNuevo")
                End If
                If grdVWPartidas.GetRowCellValue(i, "TECedisIdNuevo") <> "" Then
                    cont += 1
                    TIECNuevo = grdVWPartidas.GetRowCellValue(i, "TECedisIdNuevo")
                End If
                modificado = 1
                ocAnterior = grdVWPartidas.GetRowCellValue(i, "OC")
                ocNuevo = RTrim(LTrim(txtOC.Text))
                'rfcSICYNuevo = tblRFC.AsEnumerable().Where(Function(y) y.Item("RFCIdSAY").ToString = cboRFC.SelectedValue).Select(Function(x) x.Item("RFCIdSICY")).FirstOrDefault()
                Console.WriteLine(rfcSICYNuevo)
                If cont > 0 Then
                    If TIECNuevo <> 0 And RFCNuevo <> 0 Then
                        obj.CambioDeTiendaPartidasPedido(RFCNuevo, PedidoSAY, PedidoSICY, PartidaId, TIECNuevo, rfcSICYNuevo, ocNuevo)
                        obj.GuardarRespaldo(PedidoSAY, PedidoSICY, Ot, PartidaId, RFCAnterior, RFCNuevo, TECedisIdAnterior, TIECNuevo, UsuarioId, rfcSICYNuevo, modificado, ocAnterior, ocNuevo)
                        Console.WriteLine("Cambio Realizado")

                    End If
                End If

            Next

            If chkOC.Checked Then
                ocNuevo = RTrim(LTrim(txtOC.Text))
                'ocNuevo, PedidoSAY, PedidoSICY
                obj.ActualizarOCcliente(CInt(lblOTs.Text), ocNuevo)
            End If


            If cont > 0 Then
                Tools.MostrarMensaje(Mensajes.Success, "Se han realizado los cambios correctamente.")
                CargarPartidas()
            Else
                Tools.MostrarMensaje(Mensajes.Notice, "No se ha realizado cabios para guardar.")
            End If

            'Else
            '    Exit Sub
            'End If

            chkSeleccionarTodo.Checked = False


        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        Dim NumeroFilas As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVWPartidas.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                grdVWPartidas.SetRowCellValue(grdVWPartidas.GetVisibleRowHandle(index), "SEL", chkSeleccionarTodo.Checked)
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub chkCamcioRFC_CheckedChanged(sender As Object, e As EventArgs) Handles chkCamcioRFC.CheckedChanged
        Try
            Me.Cursor = Cursors.WaitCursor
            If chkCamcioRFC.Checked Then
                ' If ValidaOtFacturadas() = 0 Then
                cboRFC.Enabled = True
                Tools.MostrarMensaje(Mensajes.Notice, "Al realizar el cambio de RFC, es cesesario cambiar las tiendas de las partidas.")
                CargarComboRFC()
                'Else
                '    Tools.MostrarMensaje(Mensajes.Notice, "Existen OT's facturadas en el pedido, no es posible realizar el cambio de RFC.")
                '    chkCamcioRFC.Checked = False

                'End If
            Else
                cboRFC.Enabled = False
                CargarComboRFCActual()
                CargarPartidas()
                'btnGuardar.Enabled = False
                'lblGuardar.Enabled = False
            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Function validarRFCyTienda() As Integer
        Dim diferentes As Integer = 0

        Dim tienda As Integer = 0
        Dim tiendaNueva As Integer = 0
        'listData = tblRFC.AsEnumerable().Select(Function(x) x.Item("RFCIdSAY")).FirstOrDefault()
        For index As Integer = 0 To grdVWPartidas.RowCount - 1
            tienda = grdVWPartidas.GetRowCellValue(index, "TECedisId")
            If grdVWPartidas.GetRowCellValue(index, "TECedisIdNuevo") <> "" Then
                tiendaNueva = grdVWPartidas.GetRowCellValue(index, "TECedisIdNuevo")
            Else
                tiendaNueva = tienda
                'diferentes += 1
            End If

            If listData.Contains(tienda) Then
                Console.WriteLine("SI existe la tienda " & tienda)
            ElseIf listData.Contains(tiendaNueva) Then
                Console.WriteLine("SI existe la tienda " & tiendaNueva)
            Else
                Console.WriteLine("No existe la tienda " & tienda)
                diferentes += 1
            End If
        Next

        Return diferentes
    End Function

    Private Function ValidaOtFacturadas() As Integer
        Dim obj = New Negocios.OrdenTrabajoBU
        Dim tbl = New DataTable
        Dim respuesta As Integer

        tbl = obj.ValidaExistenOtFacturadasEnPedido(PedidoSAY)

        respuesta = tbl.Rows(0).Item("Respuesta")

        Return respuesta
    End Function

    Private Sub grdVWPartidas_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grdVWPartidas.RowStyle
        Dim tienda As Integer = 0
        Dim tiendaNueva As Integer = 0
        tienda = grdVWPartidas.GetRowCellValue(e.RowHandle, "TECedisId")
        If grdVWPartidas.GetRowCellValue(e.RowHandle, "TECedisIdNuevo") <> "" Then
            tiendaNueva = grdVWPartidas.GetRowCellValue(e.RowHandle, "TECedisIdNuevo")
        Else
            tiendaNueva = 0
        End If

        If listData.Contains(tienda) Then
            Console.WriteLine("SI existe la tienda " & tienda)
            e.Appearance.ForeColor = Color.Black
        ElseIf listData.Contains(tiendaNueva) Then
            Console.WriteLine("SI existe la tienda " & tienda)
            e.Appearance.ForeColor = Color.Black
        Else
            Console.WriteLine("No existe la tienda " & tienda)
            e.Appearance.ForeColor = Color.DarkOrange
        End If

        'If Not listData.Contains(grdVWPartidas.GetRowCellValue(e.RowHandle, "TECedisId")) Then
        '    e.Appearance.ForeColor = Color.Orange
        'Else
        '    e.Appearance.ForeColor = Color.Black
        'End If

        If IsDBNull(grdVWPartidas.GetRowCellValue(e.RowHandle, "Modificado")) = False Then
            If grdVWPartidas.GetRowCellValue(e.RowHandle, "Modificado") = 1 Then
                e.Appearance.ForeColor = Color.DarkViolet
            End If

        End If

    End Sub

    Private Sub chkOC_CheckedChanged(sender As Object, e As EventArgs) Handles chkOC.CheckedChanged
        If chkOC.Checked Then
            txtOC.Enabled = True
        ElseIf chkOC.Checked = False Then
            txtOC.Enabled = False
        End If
    End Sub
End Class