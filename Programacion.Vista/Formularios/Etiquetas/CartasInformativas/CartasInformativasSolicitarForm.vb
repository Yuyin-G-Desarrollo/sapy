Imports DevExpress.XtraGrid
Imports Programacion.Negocios
Imports Tools
Public Class CartasInformativasSolicitarForm
    Dim objBU As New Tools.Correo
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub CartasInformativasSolicitarForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        llenarCombo()
    End Sub

    Private Sub llenarCombo()
        cboNaves = Tools.Controles.ComboNavesSegunUsuario(cboNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim obj As New CartasInformativasBU
        Dim naveId As Integer = 0
        Dim dtSolicitud As New DataTable
        Dim fechaPrograma As Date

        Try
            Me.Cursor = Cursors.WaitCursor
            grdCartas.DataSource = Nothing
            grdVCartas.Columns.Clear()
            naveId = cboNaves.SelectedValue

            'If naveId > 0 Then
            fechaPrograma = dtpFechaPrograma.Value
                dtSolicitud = obj.ConsultaLotesConEtiquetasFaltantes(naveId, fechaPrograma)
                If dtSolicitud.Rows.Count > 0 Then
                    'If (dtSolicitud.AsEnumerable().Where(Function(x) x.Item("FALTANTE_ETIQUETAS") > 0).Count()) > 0 Then
                    grdCartas.DataSource = dtSolicitud
                    disenioGrid()
                    ActualizarRegistrosyFecha()
                Else
                    lblActualizacion.Text = Date.Now
                    grdVCartas.Columns.Clear()
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontraron informacion para solicitar carta")
                End If
            'Else
            '    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Es necesario seleccionar una nave")
            'End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ActualizarRegistrosyFecha()
        lblTotalRegistros.Text = grdVCartas.DataRowCount.ToString("n0")
        lblActualizacion.Text = Date.Now
    End Sub


    Private Sub disenioGrid()
        Dim gridFormatRule As New GridFormatRule()
        Dim formatConditionRuleExpression As New DevExpress.XtraEditors.FormatConditionRuleExpression()

        grdVCartas.IndicatorWidth = 40
        grdVCartas.BestFitColumns()

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVCartas.Columns
            col.OptionsColumn.AllowEdit = False
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName = "SEL" Or col.FieldName = "OBSERVACIONES" Or col.FieldName = "FALTANTE_ETIQUETAS" Then
                col.OptionsColumn.AllowEdit = True
            ElseIf col.FieldName = "NaveId" Then
                col.Visible = False
            End If
        Next

        grdVCartas.Columns("FALTANTE_ETIQUETAS").Caption = "FALTANTE" & vbCrLf & "ETIQUETAS"

        grdVCartas.OptionsView.EnableAppearanceEvenRow = True
        grdVCartas.OptionsView.EnableAppearanceOddRow = True
        grdVCartas.OptionsSelection.EnableAppearanceFocusedCell = True
        grdVCartas.OptionsSelection.EnableAppearanceFocusedRow = True
        grdVCartas.Appearance.SelectedRow.Options.UseBackColor = True
        grdVCartas.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVCartas.Appearance.EvenRow.BackColor = Color.White
        grdVCartas.Appearance.OddRow.BackColor = SystemColors.ActiveCaption
        grdVCartas.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVCartas.Appearance.FocusedRow.ForeColor = Color.White
    End Sub

    Private Sub grdVCartas_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdVCartas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnSolicitarCarta_Click(sender As Object, e As EventArgs) Handles btnSolicitarCarta.Click
        Dim obj As New CartasInformativasBU
        Dim filas As Integer = 0
        Dim lotes As String = String.Empty
        Dim folio As Integer = 0

        filas = grdVCartas.DataRowCount
        If filas > 0 Then
            For index As Integer = 0 To filas - 1 Step 1
                If grdVCartas.GetRowCellValue(index, "SEL") = True Then
                    If lotes = String.Empty Then
                        lotes = grdVCartas.GetRowCellValue(index, "LOTE")
                    Else
                        lotes = lotes & "," & grdVCartas.GetRowCellValue(index, "LOTE")
                    End If
                End If
            Next

            If lotes <> String.Empty Then
                folio = CInt(obj.obtenerFolioCarta())
                GuardarFolio(folio)
                Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se ha solicitado la carta informativa.")
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleccione al menos un lote para solicitar la carta informativa.")
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No existen registros para solicitar carta.")
        End If
    End Sub

    Private Sub GuardarFolio(ByVal Folio As Integer)
        Dim obj As New CartasInformativasBU
        Dim tblCarta As New DataTable
        Dim filas As Integer = 0

        Try
            filas = grdVCartas.DataRowCount - 1
            For index As Integer = 0 To filas Step 1
                If grdVCartas.GetRowCellValue(index, "SEL") = True Then
                    obj.GuardarFolioCarta(Folio,
                                      grdVCartas.GetRowCellValue(index, "NAVE"),
                                      CInt(grdVCartas.GetRowCellValue(index, "NaveId")),
                                      CInt(grdVCartas.GetRowCellValue(index, "LOTE")),
                                      CInt(grdVCartas.GetRowCellValue(index, "PARES")),
                                      CInt(grdVCartas.GetRowCellValue(index, "FALTANTE_ETIQUETAS")),
                                      grdVCartas.GetRowCellValue(index, "MODELO"),
                                      grdVCartas.GetRowCellValue(index, "CORRIDA"),
                                      grdVCartas.GetRowCellValue(index, "PIEL COLOR"),
                                      CInt(grdVCartas.GetRowCellValue(index, "PEDIDO SICY")),
                                      CInt(grdVCartas.GetRowCellValue(index, "PEDIDO SAY")),
                                      grdVCartas.GetRowCellValue(index, "CLIENTE"),
                                      CDate(grdVCartas.GetRowCellValue(index, "FECHA PROGRAMA")),
                                      grdVCartas.GetRowCellValue(index, "OBSERVACIONES"),
                                      414,
                                      CInt(grdVCartas.GetRowCellValue(index, "PARTIDA")),
                                      Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal
                                      )
                End If
            Next


        Catch ex As Exception

        End Try

    End Sub

End Class