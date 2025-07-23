Imports DevExpress
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win.UltraWinGrid
Imports Programacion.Negocios
Imports Tools

Public Class CartasInformativasPedidosDetallesForm
    Public Cliente As String
    Public Agente As String
    Public PedidoSAY As Integer
    Public acciones As String = String.Empty
    Dim cambios As Boolean = False
    Dim Usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
    Dim SeleccionarTodo As Boolean = False
    Dim verT As Boolean = False
    Dim selTP As Boolean = False
    Dim seleccionados As Boolean = False

    Private WithEvents repositorio As New RepositoryItemTextEdit

    Private Sub CartasInformativasPedidosDetallesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        Me.WindowState = FormWindowState.Maximized
        txtObservaciones.CharacterCasing = CharacterCasing.Upper
        txtObservaciones.ScrollBars = Windows.Forms.ScrollBars.Both
        txtCliente.Text = Cliente
        txtAgente.Text = Agente
        txtPedidoSAY.Text = CStr(PedidoSAY)
        dtpFechaCaptura.Value = Date.Now
        CargarPartidas(PedidoSAY, acciones)
        SplitContainer1.Panel2.Visible = False
        SplitContainer1.SplitterDistance = SplitContainer1.Width - 1
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub CargarPartidas(ByVal PedidoSAY As Integer, ByVal acciones As String)
        Dim obj As New CartasInformativasBU
        Dim dtPartidas As New DataTable
        Dim obs As String = String.Empty
        dtPartidas = obj.ConsultaPartidasDelPedido(PedidoSAY, acciones)
        grdPartidas.DataSource = dtPartidas
        obs = grdVPartidas.GetRowCellValue(0, "OBSERVACIONES")
        If obs <> String.Empty Then
            txtObservaciones.Text = grdVPartidas.GetRowCellValue(0, "OBSERVACIONES")
        End If

        disenioPartidas()
        calcularTotalesPartida()

    End Sub

#Region "Diseño de ambos Grid"
    Private Sub disenioPartidas()
        Dim gridFormatRule As New GridFormatRule()
        Dim formatConditionRuleExpression As New DevExpress.XtraEditors.FormatConditionRuleExpression()

        grdVPartidas.Columns("SEL").Width = 40
        grdVPartidas.Columns("PARTIDA").Width = 40

        grdVPartidas.IndicatorWidth = 40
        grdVPartidas.BestFitColumns()

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVPartidas.Columns
            col.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
            col.AppearanceHeader.TextOptions.HAlignment = Utils.HorzAlignment.Center
            If col.FieldName = "SEL" Then
                col.OptionsColumn.AllowEdit = True
                col.OptionsFilter.AllowAutoFilter = False
            ElseIf col.FieldName = "ETIQUETAS SAC" Then
                If acciones = "REGISTRAR_ENVIAR" Then
                    col.OptionsColumn.AllowEdit = False
                ElseIf acciones = "VALIDAR_SOLICITAR" Then
                    col.OptionsColumn.AllowEdit = False
                End If
            ElseIf col.FieldName = "ETIQUETAS PPCP" Then
                col.OptionsColumn.AllowEdit = False
            ElseIf col.FieldName = "OBSERVACIONES" Or col.FieldName = "ESTATUS" Then
                col.Visible = False
            Else
                col.OptionsColumn.AllowEdit = False
            End If
        Next

        For Each Col As DevExpress.XtraGrid.Columns.GridColumn In grdVPartidas.Columns
            If Col.FieldName.ToString = "PARES" Then
                Col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                Col.DisplayFormat.FormatString = "{0:N0}"
            End If
        Next

        grdVPartidas.OptionsView.EnableAppearanceEvenRow = True
        grdVPartidas.OptionsView.EnableAppearanceOddRow = True
        grdVPartidas.OptionsSelection.EnableAppearanceFocusedCell = True
        grdVPartidas.OptionsSelection.EnableAppearanceFocusedRow = True
        grdVPartidas.Appearance.SelectedRow.Options.UseBackColor = True
        grdVPartidas.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVPartidas.Appearance.EvenRow.BackColor = Color.White
        grdVPartidas.Appearance.OddRow.BackColor = SystemColors.ActiveCaption
        grdVPartidas.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVPartidas.Appearance.FocusedRow.ForeColor = Color.White

        grdVPartidas.Columns.ColumnByFieldName("ETIQUETAS SAC").ColumnEdit = repositorio
        If acciones = "VALIDAR_SOLICITAR" Then
            grdVPartidas.Columns.ColumnByFieldName("ETIQUETAS PPCP").ColumnEdit = repositorio
            grdVPartidas.Columns.ColumnByFieldName("ESTATUS").Visible = False
        End If

        grdVPartidas.OptionsView.ShowFooter = True

    End Sub
    Private Sub disenioTallas()
        Dim gridFormatRule As New GridFormatRule()
        Dim formatConditionRuleExpression As New DevExpress.XtraEditors.FormatConditionRuleExpression()

        grdVTallas.IndicatorWidth = 40
        grdVTallas.BestFitColumns()
        'grdVTallas.Columns("LOTE").Visible = False
        grdVTallas.Columns("NAVEID").Visible = False
        'grdVTallas.Columns("FPROGRAMACION").Visible = False
        grdVTallas.Columns("ESTATUS").Visible = False

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVTallas.Columns
            col.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
            col.AppearanceHeader.TextOptions.HAlignment = Utils.HorzAlignment.Center
            If acciones = "REGISTRAR_ENVIAR" Then
                If col.FieldName = "ETIQUETAS SAC" Then
                    col.OptionsColumn.AllowEdit = True
                Else
                    col.OptionsColumn.AllowEdit = False
                End If
            ElseIf acciones = "VALIDAR_SOLICITAR" Then
                If col.FieldName = "ETIQUETAS PPCP" Then
                    col.OptionsColumn.AllowEdit = True
                Else
                    col.OptionsColumn.AllowEdit = False
                End If
            End If
        Next

        'For Each Col As DevExpress.XtraGrid.Columns.GridColumn In grdVTallas.Columns
        '    If Col.FieldName.ToString = "PARES" Then
        '        Col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '        Col.DisplayFormat.FormatString = "{0:N0}"
        '    End If
        'Next

        grdVTallas.OptionsView.EnableAppearanceEvenRow = True
        grdVTallas.OptionsView.EnableAppearanceOddRow = True
        grdVTallas.OptionsSelection.EnableAppearanceFocusedCell = True
        grdVTallas.OptionsSelection.EnableAppearanceFocusedRow = True
        grdVTallas.Appearance.SelectedRow.Options.UseBackColor = True
        grdVTallas.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVTallas.Appearance.EvenRow.BackColor = Color.White
        grdVTallas.Appearance.OddRow.BackColor = SystemColors.ActiveCaption
        grdVTallas.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVTallas.Appearance.FocusedRow.ForeColor = Color.White

        grdVTallas.Columns.ColumnByFieldName("ETIQUETAS SAC").ColumnEdit = repositorio
        If acciones = "VALIDAR_SOLICITAR" Then
            grdVTallas.Columns.ColumnByFieldName("ETIQUETAS PPCP").ColumnEdit = repositorio
        End If

        grdVPartidas.OptionsView.ShowFooter = True

    End Sub
#End Region

#Region "Sumatorias ambos grid"
    Private Sub calcularTotalesPartida()

        If grdVPartidas.GroupSummary.Count() = 0 Then

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVPartidas.Columns
                col.Summary.Remove(col.SummaryItem)

                If col.FieldName.Contains("PARES") Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If
                If col.FieldName.Contains("ETIQUETAS SAC") Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If
                If col.FieldName.Contains("ETIQUETAS PPCP") Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If
            Next
        End If
    End Sub
    Private Sub calcularTotalesTallas()
        If grdVTallas.GroupSummary.Count() = 0 Then

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVTallas.Columns

                col.Summary.Remove(col.SummaryItem)

                If col.FieldName.Contains("PARES") Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If
                If col.FieldName.Contains("ETIQUETAS SAC") Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If
                If col.FieldName.Contains("ETIQUETAS PPCP") Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If
            Next
        End If
    End Sub
#End Region

#Region "Indicador de numero de registros ambos grid"
    Private Sub grdPartidas_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdVPartidas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub grdTallas_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdVTallas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
#End Region

#Region "Validacion de Enteros en campo ETIQUETAS SAC y PPCP"
    Public Sub ValidarNumerico(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles repositorio.KeyPress
        If (e.KeyChar) = vbBack Then
            e.Handled = False
        ElseIf Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
#End Region
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim resultadoDialog As DialogResult
        Dim confirmarDialog As New ConfirmarForm
        Dim diferentes As Integer = 0
        Dim pares As Integer = 0
        Dim etiquetasSac As Integer = 0

        For index As Integer = 0 To grdVTallas.RowCount
            pares = CInt(grdVTallas.GetRowCellValue(index, "PARES"))
            etiquetasSac = CInt(grdVTallas.GetRowCellValue(index, "ETIQUETAS SAC"))
            If pares <> etiquetasSac Then
                diferentes += 1
            End If
        Next

        If cambios Then
            If diferentes > 0 Then
                confirmarDialog.mensaje = "Existen cantidades diferentes en las tallas, " & vbCrLf & "¿Desea Salir?"
                resultadoDialog = confirmarDialog.ShowDialog
                If resultadoDialog = DialogResult.OK Then
                    Me.Close()
                Else
                    Exit Sub
                End If
            Else
                Me.Close()
            End If

        Else
            confirmarDialog.mensaje = "No se guardaran los cambios realizados " & vbCrLf & "¿Desea continuar?"
            resultadoDialog = confirmarDialog.ShowDialog
            If resultadoDialog = DialogResult.OK Then
                Me.Close()
            Else
                Exit Sub
            End If
        End If

    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        Dim filas As Integer = grdVPartidas.DataRowCount
        Dim dtPartidas = New DataTable
        Dim ValorCasilla = grdVPartidas.GetFocusedValue()
        Dim i As Integer = 0
        Dim partidas As String = String.Empty

        Me.Cursor = Cursors.WaitCursor
        dtPartidas = grdPartidas.DataSource
        SeleccionarTodo = True

        For i = 0 To grdVPartidas.RowCount - 1 Step 1
            grdVPartidas.SetRowCellValue(i, "SEL", chkSeleccionarTodo.Checked)
            If chkSeleccionarTodo.Checked Then
                If partidas = String.Empty Then
                    partidas = grdVPartidas.GetRowCellValue(i, "PARTIDA")
                Else
                    partidas = partidas & "," & grdVPartidas.GetRowCellValue(i, "PARTIDA")
                End If

            Else
                partidas = String.Empty
            End If

        Next
        If partidas <> String.Empty Then
            consultarPartidasDetalleChk(partidas)
            SplitContainer1.Panel2.Visible = True
            SplitContainer1.SplitterDistance = SplitContainer1.Width / 2
            For index As Integer = 0 To grdVPartidas.DataRowCount Step 1
                If acciones = "REGISTRAR_ENVIAR" Then
                    If CInt(grdVPartidas.GetRowCellValue(index, "ETIQUETAS SAC")) = 0 Then
                        grdVPartidas.SetRowCellValue(index, "ETIQUETAS SAC", grdVPartidas.GetRowCellValue(index, "PARES"))
                    End If
                ElseIf acciones = "VALIDAR_SOLICITAR" Then
                    If CInt(grdVPartidas.GetRowCellValue(index, "ETIQUETAS PPCP")) = 0 Then
                        grdVPartidas.SetRowCellValue(index, "ETIQUETAS PPCP", grdVPartidas.GetRowCellValue(index, "ETIQUETAS SAC"))
                    End If
                End If
            Next
            seleccionados = True
        Else
            grdTallas.DataSource = Nothing
            grdVTallas.Columns.Clear()
            SplitContainer1.Panel2.Visible = False
            SplitContainer1.SplitterDistance = SplitContainer1.Width
            verT = False
            chkVerTallas.Checked = False
            seleccionados = False
            cambiarSinSeleccion()
            'For index As Integer = 0 To grdVPartidas.DataRowCount Step 1
            '    If acciones = "REGISTRAR_ENVIAR" Then
            '        If CInt(grdVPartidas.GetRowCellValue(index, "ETIQUETAS SAC")) > 0 And grdVTallas.RowCount = 0 Then
            '            grdVPartidas.SetRowCellValue(index, "ETIQUETAS SAC", 0)
            '        Else
            '            grdVPartidas.SetRowCellValue(index, "ETIQUETAS SAC", 0)
            '        End If
            '    ElseIf acciones = "VALIDAR_SOLICITAR" Then
            '        If CInt(grdVPartidas.GetRowCellValue(index, "ETIQUETAS PPCP")) > 0 And CInt(grdVPartidas.GetRowCellValue(index, "ESTATUS")) = 411 Then
            '            grdVPartidas.SetRowCellValue(index, "ETIQUETAS PPCP", 0)
            '        End If
            '    End If
            'Next
        End If

        SeleccionarTodo = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim obj As New CartasInformativasBU
        Dim resultadoDialog As DialogResult
        Dim confirmarDialog As New ConfirmarForm
        Dim diferentes As Integer = 0
        Dim pares As Integer = 0
        Dim EtiquetasSAC As Integer = 0
        Dim EtiquetasPPCP As Integer = 0
        Dim estatus As Integer
        Dim dtPartidas As New DataTable

        Try


            diferentes = validarCompleto()

            If diferentes = 0 Then
                If acciones = "REGISTRAR_ENVIAR" Then
                    estatus = 410
                ElseIf acciones = "VALIDAR_SOLICITAR" Then
                    estatus = 413
                End If
                Guardar(estatus)
            Else
                confirmarDialog.mensaje = "Existen cantidades diferentes " & vbCrLf & "¿Desea continuar?"
                resultadoDialog = confirmarDialog.ShowDialog
                If resultadoDialog = DialogResult.OK Then
                    If acciones = "REGISTRAR_ENVIAR" Then
                        estatus = 417
                    ElseIf acciones = "VALIDAR_SOLICITAR" Then
                        estatus = 412
                    End If
                    Guardar(estatus)
                Else
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

            End If

            Me.Cursor = Cursors.WaitCursor

            actualizarGridPartidas()
            Dim obs As String = String.Empty
            dtPartidas = obj.ConsultaPartidasDelPedido(PedidoSAY, acciones)
            grdPartidas.DataSource = dtPartidas
            obs = grdVPartidas.GetRowCellValue(0, "OBSERVACIONES")
            If obs <> String.Empty Then
                txtObservaciones.Text = grdVPartidas.GetRowCellValue(0, "OBSERVACIONES")
            End If
            chkVerTallas.Checked = False

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Guardar(ByVal estatus As Integer)
        Dim obj As New CartasInformativasBU
        Dim exito As New ExitoForm
        Dim diferentes As Integer = 0
        Dim pares As Integer = 0
        Dim Etiquetas As Integer = 0
        Dim PartidaP As Integer = 0
        Dim PartidaT As Integer = 0
        Dim ModeloSAY As String = String.Empty
        Dim PielColor As String = String.Empty
        Dim Corrida As String = String.Empty
        Dim Talla As String = String.Empty
        Dim Observaciones As String
        Dim lote As Integer = 0
        Dim naveId As Integer = 0

        'Try
        Me.Cursor = Cursors.WaitCursor

        cambios = True

        For index As Integer = 0 To grdVPartidas.DataRowCount
            Observaciones = txtObservaciones.Text
            If grdVPartidas.GetRowCellValue(index, "SEL") = True Then
                PartidaP = CInt(grdVPartidas.GetRowCellValue(index, "PARTIDA"))
                ModeloSAY = grdVPartidas.GetRowCellValue(index, "MODELO SAY")
                PielColor = grdVPartidas.GetRowCellValue(index, "PIEL COLOR")
                Corrida = grdVPartidas.GetRowCellValue(index, "CORRIDA")

                For filat As Integer = 0 To grdVTallas.DataRowCount
                    PartidaT = grdVTallas.GetRowCellValue(filat, "PARTIDA")
                    If PartidaP = PartidaT Then
                        Talla = grdVTallas.GetRowCellValue(filat, "TALLA")
                        If acciones = "REGISTRAR_ENVIAR" Then
                            Etiquetas = grdVTallas.GetRowCellValue(filat, "ETIQUETAS SAC")
                        ElseIf acciones = "VALIDAR_SOLICITAR" Then
                            Etiquetas = grdVTallas.GetRowCellValue(filat, "ETIQUETAS PPCP")
                        End If
                        'lote = CInt(grdVTallas.GetRowCellValue(filat, "LOTE"))
                        If IsDBNull(grdVTallas.GetRowCellValue(filat, "NAVEID")) = False Then
                            naveId = CInt(grdVTallas.GetRowCellValue(filat, "NAVEID"))
                        Else
                            naveId = 0
                        End If
                        'naveId = CInt(grdVTallas.GetRowCellValue(filat, "NAVEID"))
                        'fechaPrograma = grdVTallas.GetRowCellValue(filat, "FPROGRAMACION")
                        'obj.RegistrarEtiquetas(PedidoSAY, Cliente, PartidaP, ModeloSAY, PielColor, Corrida, Talla, Etiquetas, Usuario, estatus, acciones, Observaciones, lote, naveId, fechaPrograma)
                        'obj.RegistrarEtiquetas(PedidoSAY, Cliente, PartidaP, ModeloSAY, PielColor, Corrida, Talla, Etiquetas, Usuario, estatus, acciones, Observaciones, naveId, fechaPrograma)
                        obj.RegistrarEtiquetas(PedidoSAY, Cliente, PartidaP, ModeloSAY, PielColor, Corrida, Talla, Etiquetas, Usuario, estatus, acciones, Observaciones, naveId)
                        'MsgBox("Partida:" & PartidaP & " FilaTalla: " & PartidaT)
                    End If
                Next

            End If
        Next

        If acciones = "REGISTRAR_ENVIAR" Then
            obj.InsertarTablaFaltantes(PedidoSAY)
        End If



        chkSeleccionarTodo.Checked = False
        selTP = False
        If estatus = 410 Then
            exito.mensaje = "Etiquetas completas. " & vbCrLf & "Se ha envíado a PPCP correctamente."
            exito.ShowDialog()
        Else
            exito.mensaje = "Se ha registrado correctamente."
            exito.ShowDialog()
        End If
        Me.Cursor = Cursors.Default
        'Catch ex As Exception
        '    Me.Cursor = Cursors.Default
        'End Try

    End Sub

    Private Sub grdVPartidas_CellValueChanging(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles grdVPartidas.CellValueChanging
        Dim obj As New CartasInformativasBU
        Dim filas As Integer = 0

        If SeleccionarTodo = False Then

            filas = grdVPartidas.DataRowCount

            Try
                Me.Cursor = Cursors.WaitCursor

                Dim ValorCasilla = grdVPartidas.GetFocusedValue()
                consultarPartidasDetalle(filas)

                Me.Cursor = Cursors.Default
            Catch ex As Exception
                Me.Cursor = Cursors.Default
            End Try

        End If
    End Sub

    Private Sub chkVerTallas_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerTallas.CheckedChanged
        Dim advertencia As New AdvertenciaForm
        Dim dtPartidas As DataTable
        dtPartidas = grdPartidas.DataSource

        If chkVerTallas.Checked Then
            verT = True
        Else
            verT = False
        End If

        If chkSeleccionarTodo.Checked Then
            selTP = True
        Else
            selTP = False
        End If

        If selTP = False And verT = True And seleccionados = False Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Seleccione almenos un registro.")
            chkVerTallas.Checked = False
        ElseIf selTP And seleccionados And verT = False Then
            SplitContainer1.Panel2.Visible = True
            SplitContainer1.SplitterDistance = SplitContainer1.Width
        ElseIf selTP = False And verT And seleccionados Then
            SplitContainer1.Panel2.Visible = True
            SplitContainer1.SplitterDistance = SplitContainer1.Width / 2
        ElseIf selTP = False And verT = False And seleccionados Then
            SplitContainer1.Panel2.Visible = False
            SplitContainer1.SplitterDistance = SplitContainer1.Width
        ElseIf selTP And seleccionados And verT = False Then
            SplitContainer1.Panel2.Visible = False
            SplitContainer1.SplitterDistance = SplitContainer1.Width
        ElseIf selTP And seleccionados And verT Then
            SplitContainer1.Panel2.Visible = True
            SplitContainer1.SplitterDistance = SplitContainer1.Width / 2
        ElseIf selTP And verT And seleccionados = False Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Seleccione almenos un registro.")
            chkVerTallas.Checked = False
            chkSeleccionarTodo.Checked = False
        End If

    End Sub

    Private Sub actualizarGridPartidas()
        Dim obj As New CartasInformativasBU
        Dim dtPartidas As New DataTable
        grdPartidas.DataSource = Nothing
        grdVPartidas.Columns.Clear()
        dtPartidas = obj.ConsultaPartidasDelPedido(PedidoSAY, acciones)
        grdPartidas.DataSource = dtPartidas
        disenioPartidas()
        calcularTotalesPartida()
        SplitContainer1.Panel2.Visible = True
        SplitContainer1.SplitterDistance = SplitContainer1.Width
    End Sub

    Private Sub consultarPartidasDetalle(ByVal filas As Integer)
        Dim obj As New CartasInformativasBU
        Dim partidas As String = String.Empty
        Dim paresPartida As Integer = 0
        Dim tablaTallas As New DataTable
        Dim ParesTalla As Integer = 0
        Dim ValorCasilla = grdVPartidas.GetFocusedValue()
        Dim estatus As Integer = 0
        Dim etiCapSac As Integer = 0
        Dim etiCapPPCP As Integer = 0

        If ValorCasilla = True Then
            grdVPartidas.SetFocusedValue(False)
        Else
            grdVPartidas.SetFocusedValue(True)
        End If

        For index As Integer = 0 To filas Step 1

            If IsDBNull(grdVPartidas.GetRowCellValue(index, "ESTATUS")) = False Then
                estatus = CInt(grdVPartidas.GetRowCellValue(index, "ESTATUS"))
            End If

            If grdVPartidas.GetRowCellValue(index, "SEL") = True Then
                If acciones = "REGISTRAR_ENVIAR" Then
                    If partidas = String.Empty Then
                        partidas = grdVPartidas.GetRowCellValue(index, "PARTIDA")
                        paresPartida = CInt(grdVPartidas.GetRowCellValue(index, "PARES"))
                        If CInt(grdVPartidas.GetRowCellValue(index, "ETIQUETAS SAC")) = 0 And (estatus <> 409 And estatus <> 410 And estatus <> 411 And estatus <> 412 And estatus <> 413 And estatus <> 414 And estatus <> 415 And estatus <> 416) Then
                            grdVPartidas.SetRowCellValue(index, "ETIQUETAS SAC", paresPartida)
                        End If
                        chkSeleccionarTodo.Focus()
                    Else
                        partidas = partidas & "," & grdVPartidas.GetRowCellValue(index, "PARTIDA")
                        paresPartida = CInt(grdVPartidas.GetRowCellValue(index, "PARES"))
                        If CInt(grdVPartidas.GetRowCellValue(index, "ETIQUETAS SAC")) = 0 And (estatus <> 409 And estatus <> 410 And estatus <> 411 And estatus <> 412 And estatus <> 413 And estatus <> 414 And estatus <> 415 And estatus <> 416) Then
                            grdVPartidas.SetRowCellValue(index, "ETIQUETAS SAC", paresPartida)
                        End If
                        chkSeleccionarTodo.Focus()
                    End If
                ElseIf acciones = "VALIDAR_SOLICITAR" Then
                    If partidas = String.Empty Then
                        partidas = grdVPartidas.GetRowCellValue(index, "PARTIDA")
                        paresPartida = CInt(grdVPartidas.GetRowCellValue(index, "ETIQUETAS SAC"))
                        If CInt(grdVPartidas.GetRowCellValue(index, "ETIQUETAS PPCP")) = 0 And (estatus = 411 Or estatus = 412) Then
                            grdVPartidas.SetRowCellValue(index, "ETIQUETAS PPCP", paresPartida)
                            chkSeleccionarTodo.Focus()
                        End If
                    Else
                        partidas = partidas & "," & grdVPartidas.GetRowCellValue(index, "PARTIDA")
                        paresPartida = CInt(grdVPartidas.GetRowCellValue(index, "ETIQUETAS SAC"))
                        If CInt(grdVPartidas.GetRowCellValue(index, "ETIQUETAS PPCP")) = 0 And (estatus = 411 Or estatus = 412) Then
                            grdVPartidas.SetRowCellValue(index, "ETIQUETAS PPCP", paresPartida)
                            chkSeleccionarTodo.Focus()
                        End If
                    End If
                End If
            Else
                If acciones = "REGISTRAR_ENVIAR" Then
                    If grdVPartidas.GetRowCellValue(index, "ETIQUETAS SAC") > 0 And estatus = 0 Then
                        grdVPartidas.SetRowCellValue(index, "ETIQUETAS SAC", 0)
                    End If
                ElseIf acciones = "VALIDAR_SOLICITAR" Then
                    If grdVPartidas.GetRowCellValue(index, "ETIQUETAS PPCP") > 0 And estatus = 411 Then
                        grdVPartidas.SetRowCellValue(index, "ETIQUETAS PPCP", 0)
                    End If
                End If
            End If
        Next

        If partidas <> String.Empty Then
            tablaTallas = obj.ConsultaPartidasTallaDelPedido(PedidoSAY, partidas, acciones)
            grdTallas.DataSource = tablaTallas
            disenioTallas()
            calcularTotalesTallas()
            seleccionados = True

            If acciones = "REGISTRAR_ENVIAR" Then
                For filaTalla As Integer = 0 To grdVTallas.RowCount
                    If IsDBNull(grdVTallas.GetRowCellValue(filaTalla, "ESTATUS")) = False Then
                        estatus = CInt(grdVTallas.GetRowCellValue(filaTalla, "ESTATUS"))
                    End If
                    etiCapSac = CInt(grdVTallas.GetRowCellValue(filaTalla, "ETIQUETAS SAC"))
                    If etiCapSac = 0 And (estatus <> 409 And estatus <> 410 And estatus <> 411 And estatus <> 412 And estatus <> 413 And estatus <> 414 And estatus <> 415 And estatus <> 416 And estatus <> 417) Then
                        ParesTalla = CInt(grdVTallas.GetRowCellValue(filaTalla, "PARES"))
                        grdVTallas.SetRowCellValue(filaTalla, "ETIQUETAS SAC", CStr(ParesTalla))
                    End If
                Next
            End If

            If acciones = "VALIDAR_SOLICITAR" Then
                For filaTalla As Integer = 0 To grdVTallas.RowCount
                    ParesTalla = CInt(grdVTallas.GetRowCellValue(filaTalla, "PARES"))
                    etiCapSac = CInt(grdVTallas.GetRowCellValue(filaTalla, "ETIQUETAS SAC"))
                    etiCapPPCP = CInt(grdVTallas.GetRowCellValue(filaTalla, "ETIQUETAS PPCP"))
                    estatus = CInt(grdVTallas.GetRowCellValue(filaTalla, "ESTATUS"))
                    If estatus = 410 Or estatus = 411 Then
                        ParesTalla = CInt(grdVTallas.GetRowCellValue(filaTalla, "ETIQUETAS SAC"))
                        grdVTallas.SetRowCellValue(filaTalla, "ETIQUETAS PPCP", CStr(ParesTalla))
                    End If
                Next
            End If
        Else
            seleccionados = False
            SplitContainer1.Panel2.Visible = True
            SplitContainer1.SplitterDistance = SplitContainer1.Width
            chkVerTallas.Checked = False
            chkSeleccionarTodo.Checked = False
            cambiarSinSeleccion()
        End If
    End Sub

    Private Sub consultarPartidasDetalleChk(ByVal partidas As String)
        Dim obj As New CartasInformativasBU
        Dim tablaDet As New DataTable
        Dim ParesTalla As Integer = 0
        grdTallas.DataSource = Nothing
        grdVTallas.Columns.Clear()
        tablaDet = obj.ConsultaPartidasTallaDelPedido(PedidoSAY, partidas, acciones)
        If tablaDet.Rows.Count > 0 Then
            grdTallas.DataSource = tablaDet
            If acciones = "REGISTRAR_ENVIAR" Then
                Dim estatus As Integer = 0
                Dim etiCapSac As Integer = 0
                For filaTalla As Integer = 0 To grdVTallas.RowCount
                    If IsDBNull(grdVTallas.GetRowCellValue(filaTalla, "ESTATUS")) = False Then
                        estatus = CInt(grdVTallas.GetRowCellValue(filaTalla, "ESTATUS"))
                    End If
                    etiCapSac = CInt(grdVTallas.GetRowCellValue(filaTalla, "ETIQUETAS SAC"))
                    If etiCapSac = 0 And (estatus <> 409 And estatus <> 410 And estatus <> 411 And estatus <> 412 And estatus <> 413 And estatus <> 414 And estatus <> 415 And estatus <> 416) Then
                        ParesTalla = CInt(grdVTallas.GetRowCellValue(filaTalla, "PARES"))
                        grdVTallas.SetRowCellValue(filaTalla, "ETIQUETAS SAC", CStr(ParesTalla))
                    End If
                Next
            ElseIf acciones = "VALIDAR_SOLICITAR" Then
                Dim estatus As Integer = 0
                Dim etiqCapSac As Integer = 0
                For filaTalla As Integer = 0 To grdVTallas.DataRowCount
                    estatus = CInt(grdVTallas.GetRowCellValue(filaTalla, "ESTATUS"))
                    etiqCapSac = CInt(grdVTallas.GetRowCellValue(filaTalla, "ETIQUETAS SAC"))
                    If estatus = 411 Then
                        grdVTallas.SetRowCellValue(filaTalla, "ETIQUETAS PPCP", etiqCapSac)
                    End If
                Next
            End If
            disenioTallas()
            calcularTotalesTallas()
        End If
    End Sub

    Private Sub cambiarSinSeleccion()
        For index As Integer = 0 To grdVPartidas.DataRowCount Step 1
            Dim estatus As Integer
            If IsDBNull(grdVPartidas.GetRowCellValue(index, "ESTATUS")) = False Then
                estatus = grdVPartidas.GetRowCellValue(index, "ESTATUS")
            End If
            If acciones = "REGISTRAR_ENVIAR" Then
                If CInt(grdVPartidas.GetRowCellValue(index, "ETIQUETAS SAC")) > 0 And estatus = 0 Then
                    grdVPartidas.SetRowCellValue(index, "ETIQUETAS SAC", 0)
                Else
                    '    grdVPartidas.SetRowCellValue(index, "ETIQUETAS SAC", 0)
                End If
            ElseIf acciones = "VALIDAR_SOLICITAR" Then
                If CInt(grdVPartidas.GetRowCellValue(index, "ETIQUETAS PPCP")) > 0 And CInt(grdVPartidas.GetRowCellValue(index, "ESTATUS")) = 411 Then
                    grdVPartidas.SetRowCellValue(index, "ETIQUETAS PPCP", 0)
                End If
            End If
        Next
    End Sub

    Private Function validarCompleto() As Integer
        Dim diferentes As Integer = 0
        Dim partidaP As Integer = 0
        Dim paresP As Integer = 0
        Dim etiquetasSACP As Integer = 0
        Dim paresT As Integer = 0
        Dim etiquetasSACT As Integer = 0
        Dim etiquetasPPCPP As Integer = 0
        Dim etiquetasPPCPT As Integer = 0
        Dim estaus As Integer = 0
        Dim partidaT As Integer = 0
        Dim partidaPAux As Integer = 0

        For index As Integer = 0 To grdVPartidas.RowCount - 1
            If IsDBNull(grdVPartidas.GetRowCellValue(index, "ESTATUS")) = False Then
                estaus = grdVPartidas.GetRowCellValue(index, "ESTATUS")
            End If
            partidaP = grdVPartidas.GetRowCellValue(index, "PARTIDA")
            paresP = grdVPartidas.GetRowCellValue(index, "PARES")
            etiquetasSACP = grdVPartidas.GetRowCellValue(index, "ETIQUETAS SAC")
            If acciones = "REGISTRAR_ENVIAR" Then
                For fila As Integer = 0 To grdVTallas.RowCount - 1
                    'If paresP <> etiquetasSACP And estaus = 417 Then
                    '    diferentes += 1
                    'End If
                    partidaT = grdVTallas.GetRowCellValue(fila, "PARTIDA")
                    If paresP <> etiquetasSACP Then
                        If partidaP <> partidaPAux Then
                            diferentes += 1
                            partidaPAux = partidaP
                        End If
                    End If

                    If partidaP = partidaT Then
                        paresT = grdVTallas.GetRowCellValue(fila, "PARES")
                        etiquetasSACT = grdVTallas.GetRowCellValue(fila, "ETIQUETAS SAC")
                        If paresT <> etiquetasSACT Then
                            'If (partidaP = partidaT) And ((paresP <> etiquetasSACP) Or (paresT <> etiquetasSACT)) And (estaus = 417 Or estaus = Nothing) Then
                            '    diferentes += 1
                            'Else
                            diferentes += 1
                        End If

                    End If

                Next
            End If

            If acciones = "VALIDAR_SOLICITAR" Then
                etiquetasPPCPP = grdVPartidas.GetRowCellValue(index, "ETIQUETAS PPCP")
                For fila As Integer = 0 To grdVTallas.RowCount - 1
                    'If paresP <> etiquetasSACP Or etiquetasSACP <> EtiquetasPPCPP And estaus = 411 Then
                    '    diferentes += 1
                    'End If
                    partidaT = grdVTallas.GetRowCellValue(fila, "PARTIDA")
                    If partidaP = partidaT Then
                        paresT = grdVTallas.GetRowCellValue(fila, "PARES")
                        etiquetasSACT = grdVTallas.GetRowCellValue(fila, "ETIQUETAS SAC")
                        etiquetasPPCPT = grdVTallas.GetRowCellValue(fila, "ETIQUETAS PPCP")
                        'If paresT <> etiquetasSACT And etiquetasSACT <> EtiquetasPPCPT Then
                        If (paresT <> etiquetasSACT And etiquetasSACT <> etiquetasPPCPT) Or
                            (paresT <> etiquetasSACT And etiquetasSACT = etiquetasPPCPT) Or
                            (paresT = etiquetasSACT And etiquetasSACT <> etiquetasPPCPT) Then
                            diferentes += 1
                        End If
                    End If
                Next

            End If
        Next
        Return diferentes
    End Function

End Class