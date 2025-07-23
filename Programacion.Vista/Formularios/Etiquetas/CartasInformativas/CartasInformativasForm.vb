Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Programacion.Negocios
Imports Tools

Public Class CartasInformativasForm
    Dim tablaPedidos = New DataTable
    Dim acciones As String
    Dim operacion As String
    Private Sub CartasInformativasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obj As New CartasInformativasBU
        Dim estatus As Integer = 0
        Dim dtestatus As New DataTable

        Me.Cursor = Cursors.WaitCursor
        dtestatus = obj.consultaEstatusCartas()
        dtestatus.Rows.InsertAt(dtestatus.NewRow, 0)
        cboEstatus.DataSource = dtestatus
        cboEstatus.ValueMember = "EstatusId"
        cboEstatus.DisplayMember = "EstatusNombre"
        chkFechas.Checked = True

        dtpFechaDel.Value = CDate("01/" + Date.Now.Month.ToString + "/" + Date.Now.Year.ToString)
        dtpFechaAl.Value = Date.Now

        'pnlSolicitarCarta.Hide()
        'pnlVerSolicitudes.Hide()
        'pnlVerFolios.Hide()

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("CARTAS_INFORMATIVAS", "SAC_REGISTRAR_CARTA") Then
            'pnlRegistrar.Enabled = True
            pnlRegistrar.Hide()
            pnlValPPCP.Hide()
            pnlSolicitarCarta.Hide()
            acciones = "REGISTRAR_ENVIAR"
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("CARTAS_INFORMATIVAS", "SAC_ENVIAR_PPCP") Then
            pnlEnvPPCP.Enabled = True
            pnlValPPCP.Hide()
            pnlSolicitarCarta.Hide()
            acciones = "REGISTRAR_ENVIAR"
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("CARTAS_INFORMATIVAS", "PPCP_VALIDAR") Then
            pnlValPPCP.Enabled = True
            pnlRegistrar.Hide()
            pnlEnvPPCP.Hide()
            acciones = "VALIDAR_SOLICITAR"
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("CARTAS_INFORMATIVAS", "PPCP_SOLICITAR_CARTA") Then
            pnlSolicitarCarta.Enabled = True
            pnlRegistrar.Hide()
            pnlEnvPPCP.Hide()
            acciones = "VALIDAR_SOLICITAR"
        End If


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("CARTAS_INFORMATIVAS", "REPORTE_FOLIOS") Then
            pnlVerFolios.Visible = True
        End If

        Me.WindowState = FormWindowState.Maximized


        tablaPedidos = obj.ConsultaPedidosPorEntregar(chkFechas.Checked, dtpFechaDel.Value, dtpFechaAl.Value, acciones, estatus)

        grdPedidos.DataSource = tablaPedidos
        If grdVPedidos.DataRowCount > 0 Then
            disenioGrid()
            lblTotalRegistros.Text = grdVPedidos.DataRowCount
            lblActualizacion.Text = Date.Now
        Else
            grdVPedidos.Columns.Clear()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub disenioGrid()

        Dim gridFormatRule As New GridFormatRule()
        Dim formatConditionRuleExpression As New DevExpress.XtraEditors.FormatConditionRuleExpression()

        grdVPedidos.IndicatorWidth = 40
        grdVPedidos.BestFitColumns()

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVPedidos.Columns
            col.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsColumn.AllowEdit = False
            If col.FieldName = "SEL" Then
                col.OptionsColumn.AllowEdit = True
                'Else
                '    col.OptionsColumn.AllowEdit = False
            End If
        Next
        grdVPedidos.Columns("SEL").Visible = True
        grdVPedidos.Columns("AGENTE_NOMBRE").Visible = False
        grdVPedidos.Columns("ESTATUSID").Visible = False
        grdVPedidos.Columns("PARES_CANCELADOS").Visible = False
        'grdVPedidos.Columns("F.PROGRAMACION").Visible = False
        grdVPedidos.Columns("PEDIDO_SAY").Caption = "PEDIDO" & vbCrLf & "SAY"
        grdVPedidos.Columns("PEDIDO_SICY").Caption = "PEDIDO" & vbCrLf & "SICY"
        grdVPedidos.Columns("PARES_PEDIDO").Caption = "PARES" & vbCrLf & "PEDIDO"
        grdVPedidos.Columns("PARES_ENTREGADOS").Caption = "PARES" & vbCrLf & "ENTREGADOS"
        grdVPedidos.Columns("PARES_CANCELADOS").Caption = "PARES" & vbCrLf & "CANCELADOS"
        grdVPedidos.Columns("ETIQUETAS_CAPTURADAS_SAC").Caption = "ETIQUETAS" & vbCrLf & "CAPTURADAS"

        'If acciones = "REGISTRAR_ENVIAR" Then
        grdVPedidos.Columns("ETIQUETAS_FALTANTES").Caption = "ETIQUETAS" & vbCrLf & "POR CAPTURAR"
        'End If

        For Each Col As DevExpress.XtraGrid.Columns.GridColumn In grdVPedidos.Columns
            If Col.FieldName.ToString = "PARES_PEDIDO" Or Col.FieldName.ToString = "PARES_ENTREGADOS" Or Col.FieldName.ToString = "PARES_CANCELADOS" Or
                Col.FieldName.ToString = "ETIQUETAS_CAPTURADAS_SAC" Or Col.FieldName.ToString = "ETIQUETAS_FALTANTES" Then
                Col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                Col.DisplayFormat.FormatString = "{0:N0}"
            End If
        Next

        grdVPedidos.OptionsView.EnableAppearanceEvenRow = True
        grdVPedidos.OptionsView.EnableAppearanceOddRow = True
        grdVPedidos.OptionsSelection.EnableAppearanceFocusedCell = True
        grdVPedidos.OptionsSelection.EnableAppearanceFocusedRow = True
        grdVPedidos.Appearance.SelectedRow.Options.UseBackColor = True
        grdVPedidos.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVPedidos.Appearance.EvenRow.BackColor = Color.White
        grdVPedidos.Appearance.OddRow.BackColor = SystemColors.ActiveCaption
        grdVPedidos.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVPedidos.Appearance.FocusedRow.ForeColor = Color.White

    End Sub

    Private Sub grdPedidos_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdVPedidos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub grdVPedidos_RowClick(sender As Object, e As Views.Grid.RowClickEventArgs) Handles grdVPedidos.RowClick
        Dim obj = New CartasInformativasBU
        Dim form As New CartasInformativasPedidosDetallesForm
        Dim estatus As Integer = 0
        If e.Clicks = 2 Then
            If acciones = "VALIDAR_SOLICITAR" Then
                estatus = grdVPedidos.GetRowCellValue(e.RowHandle, "ESTATUSID")
                If estatus = 410 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No es posible abrir el detalle si no ha recibido las etiquetas")
                Else
                    form.MdiParent = Me.MdiParent
                    form.Cliente = grdVPedidos.GetFocusedRowCellValue("CLIENTE")
                    form.Agente = grdVPedidos.GetFocusedRowCellValue("AGENTE_NOMBRE")
                    form.PedidoSAY = CInt(grdVPedidos.GetFocusedRowCellValue("PEDIDO_SAY"))
                    form.acciones = acciones
                    form.MdiParent = Me.MdiParent
                    form.Show()
                End If
            ElseIf acciones = "REGISTRAR_ENVIAR" Then
                form.MdiParent = Me.MdiParent
                form.Cliente = grdVPedidos.GetFocusedRowCellValue("CLIENTE")
                form.Agente = grdVPedidos.GetFocusedRowCellValue("AGENTE_NOMBRE")
                form.PedidoSAY = CInt(grdVPedidos.GetFocusedRowCellValue("PEDIDO_SAY"))
                form.acciones = acciones
                form.MdiParent = Me.MdiParent
                form.Show()
            End If
        End If
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        MessageBox.Show("Registrar")
    End Sub

    Private Sub btnEnviarPPCP_Click(sender As Object, e As EventArgs) Handles btnEnviarPPCP.Click
        Dim obj As New CartasInformativasBU
        Dim pedidos As String = String.Empty
        Dim pedidosSinRegistros As String = String.Empty
        Dim fechaEnvioAPPCP As DateTime = DateTime.Now
        Dim fila As Integer = grdVPedidos.DataRowCount
        Dim cont As Integer = 0

        Try
            Me.Cursor = Cursors.WaitCursor
            operacion = "EnviarAPPCP"
            For index As Integer = 0 To fila Step 1
                If grdVPedidos.GetRowCellValue(index, "SEL") = True Then
                    If pedidos = String.Empty Then
                        pedidos = grdVPedidos.GetRowCellValue(index, "PEDIDO_SAY")
                        If grdVPedidos.GetRowCellValue(index, "ESTATUS") = "" Then
                            pedidosSinRegistros = grdVPedidos.GetRowCellValue(index, "PEDIDO_SAY")
                            cont += 1
                        End If
                    Else
                        pedidos = pedidos & "," & grdVPedidos.GetRowCellValue(index, "PEDIDO_SAY")
                        If grdVPedidos.GetRowCellValue(index, "ESTATUS") = "" Then
                            pedidosSinRegistros = pedidosSinRegistros & "," & grdVPedidos.GetRowCellValue(index, "PEDIDO_SAY")
                            cont += 1
                        End If
                    End If
                End If
            Next

            If pedidos = String.Empty Then
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Seleccione almenos un registro.")
            Else
                If cont = 0 Then
                    obj.ActualizaEstatus(operacion, pedidos, fechaEnvioAPPCP)
                    tablaPedidos = obj.ConsultaPedidosPorEntregar(chkFechas.Checked, dtpFechaDel.Value, dtpFechaAl.Value, acciones, 0)
                    grdPedidos.DataSource = tablaPedidos
                    disenioGrid()
                    lblTotalRegistros.Text = grdVPedidos.DataRowCount
                    lblActualizacion.Text = Date.Now
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se ha enviado a PPCP correctamente")
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Existen pedidos sin etiquetas capturadas." & vbCrLf & "(" & pedidosSinRegistros & ")")
                End If

            End If

        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try


    End Sub

    Private Sub btnValidarPPCP_Click(sender As Object, e As EventArgs) Handles btnRecibirPPCP.Click
        Dim form = New CastasInformativasRecibirPPCPForm
        Dim obj As New CartasInformativasBU
        Dim confirmarDialog As New ConfirmarForm
        Dim pedidos As String = String.Empty
        Dim fila As Integer = grdVPedidos.DataRowCount

        Try
            Me.Cursor = Cursors.WaitCursor
            operacion = "RecibirPPCP"
            For index As Integer = 0 To fila Step 1
                If grdVPedidos.GetRowCellValue(index, "SEL") = True Then
                    If pedidos = String.Empty Then
                        pedidos = grdVPedidos.GetRowCellValue(index, "PEDIDO_SAY")
                    Else
                        pedidos = pedidos & "," & grdVPedidos.GetRowCellValue(index, "PEDIDO_SAY")
                    End If
                End If
            Next

            If pedidos = String.Empty Then
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Seleccione almenos un registro.")
            Else
                form.pedidos = pedidos
                form.Operacion = operacion
                form.ShowDialog()
                tablaPedidos = obj.ConsultaPedidosPorEntregar(0, dtpFechaDel.Value, dtpFechaAl.Value, acciones, 0)
                grdPedidos.DataSource = tablaPedidos
                disenioGrid()
                lblTotalRegistros.Text = grdVPedidos.DataRowCount
                lblActualizacion.Text = Date.Now
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnSolicitarCarta_Click(sender As Object, e As EventArgs) Handles btnSolicitarCarta.Click
        Dim frm As New CartasInformativasSolicitarForm
        frm.MdiParent = Me.MdiParent
        frm.Show()
    End Sub

    Private Sub btnVerSolicitudes_Click(sender As Object, e As EventArgs) Handles btnVerSolicitudes.Click
        Dim form As New CartasInformativasVerSolicitudesForm
        form.acciones = acciones
        form.MdiParent = Me.MdiParent
        form.Show()
    End Sub

    Private Sub chkFechaEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechas.CheckedChanged
        If chkFechas.Checked Then
            lblFechaDel.Enabled = True
            dtpFechaDel.Enabled = True
            lblFechaAl.Enabled = True
            dtpFechaAl.Enabled = True
        ElseIf chkFechas.Checked = False Then
            lblFechaDel.Enabled = False
            dtpFechaDel.Enabled = False
            lblFechaAl.Enabled = False
            dtpFechaAl.Enabled = False
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim obj As New CartasInformativasBU
        Dim estatus As Integer = 0
        Me.Cursor = Cursors.WaitCursor
        If IsDBNull(cboEstatus.SelectedValue) = False Then
            estatus = cboEstatus.SelectedValue
        Else
            estatus = 0
        End If

        lblTotalRegistros.Text = 0
        lblActualizacion.Text = "..."
        grdPedidos.DataSource = Nothing
        grdVPedidos.Columns.Clear()
        If chkFechas.Checked Then
            tablaPedidos = obj.ConsultaPedidosPorEntregar(1, dtpFechaDel.Value, dtpFechaAl.Value, acciones, estatus)
        Else
            tablaPedidos = obj.ConsultaPedidosPorEntregar(0, dtpFechaDel.Value, dtpFechaAl.Value, acciones, estatus)
        End If

        grdPedidos.DataSource = tablaPedidos
        If grdVPedidos.DataRowCount > 0 Then
            disenioGrid()
            ActualizarRegistrosyFecha()
        Else
            grdVPedidos.Columns.Clear()
            If estatus = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se encontraron registros.")
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se encontraron registros con estatus " & cboEstatus.Text)
            End If
            lblTotalRegistros.Text = "0"
            lblActualizacion.Text = Date.Now
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dtpFechaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaDel.ValueChanged
        dtpFechaAl.MinDate = dtpFechaDel.Value
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnVerFolios_Click(sender As Object, e As EventArgs) Handles btnVerFolios.Click
        Dim form As New CartasInformativasReporteFoliosForm
        form.MdiParent = Me.MdiParent
        form.Show()
    End Sub

    Private Sub ActualizarRegistrosyFecha()
        lblTotalRegistros.Text = grdVPedidos.DataRowCount.ToString("n0")
        lblActualizacion.Text = Date.Now
    End Sub


End Class