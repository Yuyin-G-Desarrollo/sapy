Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmLimiteCapacidad

    Public Sub guardarConfiguracionesLimiteCapacidad()
        Dim objBU As New Negocios.LimiteCapacidadBU
        Dim entLimiteCap As New Entidades.LimiteCapacidad

        For Each rowGrd As UltraGridRow In grdLimiteCapacidad.Rows
            If rowGrd.Cells("lmtc_limiteCapacidadId").Value.ToString <> String.Empty Then
                If rowGrd.Cells("lmtc_limiteCapacidadId").Value > 0 Then
                    entLimiteCap = New Entidades.LimiteCapacidad
                    entLimiteCap.LimiteCapacidadID = rowGrd.Cells("lmtc_limiteCapacidadId").Value
                    entLimiteCap.SimulacionMaestroId = cmbSimulaciones.SelectedValue
                    entLimiteCap.LineaId = cmbLineas.SelectedValue
                    entLimiteCap.Anio = numAnio.Value
                    entLimiteCap.semana = rowGrd.Cells("SEMANA").Value.ToString.Trim.Replace("S", "")

                    If rowGrd.Cells("cantidad").Value > 0 And rowGrd.Cells("dias").Value > 0 Then
                        entLimiteCap.Cantidad = rowGrd.Cells("cantidad").Value
                        entLimiteCap.Dias = rowGrd.Cells("dias").Value
                        entLimiteCap.Porcentaje = rowGrd.Cells("porcentaje").Value
                        entLimiteCap.Activo = True
                    Else
                        entLimiteCap.Cantidad = 0
                        entLimiteCap.Dias = 0
                        entLimiteCap.Porcentaje = 0
                        entLimiteCap.Activo = False
                    End If
                    objBU.guardardarLimiteCapacidadLinea(entLimiteCap)
                Else
                    If rowGrd.Cells("cantidad").Value > 0 And rowGrd.Cells("dias").Value > 0 Then
                        entLimiteCap = New Entidades.LimiteCapacidad
                        entLimiteCap.LimiteCapacidadID = rowGrd.Cells("lmtc_limiteCapacidadId").Value
                        entLimiteCap.SimulacionMaestroId = cmbSimulaciones.SelectedValue
                        entLimiteCap.LineaId = cmbLineas.SelectedValue
                        entLimiteCap.Anio = numAnio.Value
                        entLimiteCap.semana = rowGrd.Cells("SEMANA").Value.ToString.Trim.Replace("S", "")
                        entLimiteCap.Cantidad = rowGrd.Cells("cantidad").Value
                        entLimiteCap.Dias = rowGrd.Cells("dias").Value
                        entLimiteCap.Porcentaje = rowGrd.Cells("porcentaje").Value
                        entLimiteCap.Activo = True
                        objBU.guardardarLimiteCapacidadLinea(entLimiteCap)
                    End If
                End If
            Else
                If rowGrd.Cells("cantidad").Value > 0 And rowGrd.Cells("dias").Value > 0 Then
                    entLimiteCap = New Entidades.LimiteCapacidad
                    entLimiteCap.LimiteCapacidadID = Nothing
                    entLimiteCap.SimulacionMaestroId = cmbSimulaciones.SelectedValue
                    entLimiteCap.LineaId = cmbLineas.SelectedValue
                    entLimiteCap.Anio = numAnio.Value
                    entLimiteCap.semana = rowGrd.Cells("SEMANA").Value.ToString.Trim.Replace("S", "")
                    entLimiteCap.Cantidad = rowGrd.Cells("cantidad").Value
                    entLimiteCap.Dias = rowGrd.Cells("dias").Value
                    entLimiteCap.Porcentaje = rowGrd.Cells("porcentaje").Value
                    entLimiteCap.Activo = True
                    objBU.guardardarLimiteCapacidadLinea(entLimiteCap)
                End If
            End If
        Next
        llenarTablaLimiteCapacidad(numAnio.Value, cmbLineas.SelectedValue, cmbSimulaciones.SelectedValue)
        Dim objMensajeExito As New Tools.ExitoForm
        objMensajeExito.mensaje = "Registro guardados con éxito"
        objMensajeExito.ShowDialog()
    End Sub

    Public Sub validarRangoAnios()
        Dim objProgBU As New Negocios.ProgramasBU
        Dim dtAnios As New DataTable

        dtAnios = objProgBU.consultaRangosFechaTodo

        If dtAnios.Rows.Count > 0 Then
            If dtAnios.Rows(0).Item(0).ToString <> "" And dtAnios.Rows(0).Item(1).ToString <> "" Then
                numAnio.Minimum = dtAnios.Rows(0).Item("eirf_anioinicio")
                numAnio.Maximum = dtAnios.Rows(0).Item("eirf_aniofin")
            End If
        End If
    End Sub

    Public Sub llenarTablaLimiteCapacidad(ByVal anio As Int32,
                                          ByVal idLinea As Int32,
                                          ByVal idSimulacion As Int32)
        Dim objBU As New Negocios.LimiteCapacidadBU
        Dim dt As New DataTable
        dt = objBU.consultaLineaLimiteCapacidadAnio(idLinea, anio, idSimulacion)

        grdLimiteCapacidad.DataSource = Nothing

        If dt.Rows.Count > 0 Then
           
            If anio = Date.Now.Year Then
                Dim semanaActual As Int32 = DatePart(DateInterval.WeekOfYear, Date.Now)

                If semanaActual = 53 Then
                    If DatePart(DateInterval.Month, semanaActual) = 12 Then
                        semanaActual = 52
                    ElseIf DatePart(DateInterval.Month, semanaActual) = 1 Then
                        semanaActual = 1
                    End If
                End If

                For i As Int32 = semanaActual - 1 To 1 Step -1
                    For Each rowDt As DataRow In dt.Rows
                        If rowDt.Item("SEMANA").ToString = "S" + i.ToString Then
                            dt.Rows.Remove(rowDt)
                            Exit For
                        End If
                    Next
                Next

               
            End If

            grdLimiteCapacidad.DataSource = dt
            formatoGridLimiteCapacidad()


        End If

    End Sub

    Public Sub formatoGridLimiteCapacidad()
        Dim banda As UltraGridBand = grdLimiteCapacidad.DisplayLayout.Bands(0)
        With banda
            .Columns("linp_linpID").Hidden = True
            .Columns("lmtc_limiteCapacidadId").Hidden = True
            .Columns("lmtc_lineaId").Hidden = True
            .Columns("lmtc_simulacionMaestroId").Hidden = True
            .Columns("lmtc_anio").Hidden = True
            .Columns("lmtc_semana").Hidden = True

            .Columns("SEMANA").Header.Caption = "Semana"
            .Columns("CapSemana").Header.Caption = "Cap. Semanal"
            .Columns("CapDia").Header.Caption = "Cap. DIa"
            .Columns("DiasNave").Header.Caption = "Días Nave"
            .Columns("Porcentaje").Header.Caption = "%"
            .Columns("cantidad").Header.Caption = "Cantidad"
            .Columns("lmtc_semana").Header.Caption = ""
            .Columns("lmtc_anio").Header.Caption = ""
            .Columns("dias").Header.Caption = "Días"
            .Columns("Total").Header.Caption = "Total"

            .Columns("SEMANA").CellActivation = Activation.NoEdit
            .Columns("CapSemana").CellActivation = Activation.NoEdit
            .Columns("CapDia").CellActivation = Activation.NoEdit
            .Columns("DiasNave").CellActivation = Activation.NoEdit
            .Columns("lmtc_semana").CellActivation = Activation.NoEdit
            .Columns("lmtc_anio").CellActivation = Activation.NoEdit
            .Columns("Total").CellActivation = Activation.NoEdit

            If CBool(cmbSimulaciones.SelectedItem("ProcSimMae_Estatus")) = True Then
                .Columns("cantidad").CellActivation = Activation.AllowEdit
                .Columns("dias").CellActivation = Activation.AllowEdit
                .Columns("Porcentaje").CellActivation = Activation.AllowEdit
            Else
                .Columns("cantidad").CellActivation = Activation.NoEdit
                .Columns("dias").CellActivation = Activation.NoEdit
                .Columns("Porcentaje").CellActivation = Activation.NoEdit
            End If

            .Columns("SEMANA").CellAppearance.TextHAlign = HAlign.Right
            .Columns("CapSemana").CellAppearance.TextHAlign = HAlign.Right
            .Columns("CapDia").CellAppearance.TextHAlign = HAlign.Right
            .Columns("DiasNave").CellAppearance.TextHAlign = HAlign.Right
            .Columns("lmtc_semana").CellAppearance.TextHAlign = HAlign.Right
            .Columns("lmtc_anio").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total").CellAppearance.TextHAlign = HAlign.Right

        End With

        For Each rowGrd As UltraGridRow In grdLimiteCapacidad.Rows
            rowGrd.Cells("SEMANA").Value = Replace(rowGrd.Cells("SEMANA").Value.ToString, "S", "")
            If rowGrd.Cells("DiasNave").Value <= 0 Then
                rowGrd.Cells("cantidad").Activation = Activation.NoEdit
                rowGrd.Cells("dias").Activation = Activation.NoEdit
            End If

            If rowGrd.Cells("dias").Value > rowGrd.Cells("DiasNave").Value And rowGrd.Cells("dias").Value > 0 Then
                rowGrd.Cells("SEMANA").Appearance.BackColor = Color.Red
            End If

        Next

        grdLimiteCapacidad.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdLimiteCapacidad.DisplayLayout.Override.RowSelectorWidth = 35
        grdLimiteCapacidad.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdLimiteCapacidad.Rows(0).Selected = True
        grdLimiteCapacidad.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdLimiteCapacidad.DisplayLayout.Bands(0).Columns("SEMANA").Width = 30

    End Sub

    Public Sub llenarComboLineas()
        Dim objBU As New Negocios.LineasProduccionBU
        Dim dt As New DataTable
        dt = objBU.comboLineas(1)

        If dt.Rows.Count > 0 Then

            dt.Rows.InsertAt(dt.NewRow, 0)
            cmbLineas.DataSource = dt
            cmbLineas.ValueMember = "ID"
            cmbLineas.DisplayMember = "Descripcion"

        End If

    End Sub

    Public Sub llenarComboSimulaciones()
        Dim objBU As New Negocios.SimulacionBU
        Dim dt As New DataTable
        dt = objBU.consultaSimulacionMaestro

        If dt.Rows.Count > 0 Then

            dt.Rows.InsertAt(dt.NewRow, 0)
            cmbSimulaciones.DataSource = dt
            cmbSimulaciones.ValueMember = "ProcSimMae_ProcSimuladorID"
            cmbSimulaciones.DisplayMember = "ProcSimMae_Descripcion"

        End If

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmLimiteCapacidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        llenarComboSimulaciones()
        llenarComboLineas()
        validarRangoAnios()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlValores.Visible = False
        grbNaves.Height = 40
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlValores.Visible = True
        grbNaves.Height = 130
    End Sub

    Private Sub cmbLineas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLineas.SelectedIndexChanged
        If cmbLineas.SelectedIndex > 0 And numAnio.Value > 0 And cmbSimulaciones.SelectedIndex > 0 Then
            llenarTablaLimiteCapacidad(numAnio.Value, cmbLineas.SelectedValue, cmbSimulaciones.SelectedValue)
            If CBool(cmbSimulaciones.SelectedItem("ProcSimMae_Estatus")) = True Then
                btnGuardar.Enabled = True
                lblGuardar.Enabled = True
                pnlValores.Enabled = True
            Else
                btnGuardar.Enabled = False
                lblGuardar.Enabled = False
                pnlValores.Enabled = False
            End If
        Else
            grdLimiteCapacidad.DataSource = Nothing
            'Dim objMensajeAdv As New Tools.AdvertenciaForm
            'objMensajeAdv.mensaje = "Seleccione un año y una linea validos."
            'objMensajeAdv.ShowDialog()
        End If
      
    End Sub

    Private Sub cmbSimulaciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSimulaciones.SelectedIndexChanged
        If cmbLineas.SelectedIndex > 0 And numAnio.Value > 0 And cmbSimulaciones.SelectedIndex > 0 Then
            llenarTablaLimiteCapacidad(numAnio.Value, cmbLineas.SelectedValue, cmbSimulaciones.SelectedValue)
            If CBool(cmbSimulaciones.SelectedItem("ProcSimMae_Estatus")) = True Then
                btnGuardar.Enabled = True
                lblGuardar.Enabled = True
                pnlValores.Enabled = True
            Else
                btnGuardar.Enabled = False
                lblGuardar.Enabled = False
                pnlValores.Enabled = False
            End If
        Else
            grdLimiteCapacidad.DataSource = Nothing
            btnGuardar.Enabled = False
            lblGuardar.Enabled = False
            pnlValores.Enabled = False
        End If
      
    End Sub

    Private Sub numAnio_ValueChanged(sender As Object, e As EventArgs) Handles numAnio.ValueChanged
        If cmbLineas.SelectedIndex > 0 And numAnio.Value > 0 And cmbSimulaciones.SelectedIndex > 0 Then
            llenarTablaLimiteCapacidad(numAnio.Value, cmbLineas.SelectedValue, cmbSimulaciones.SelectedValue)
        Else
            grdLimiteCapacidad.DataSource = Nothing
        End If
    End Sub

    Private Sub grdLimiteCapacidad_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdLimiteCapacidad.AfterCellUpdate
        If e.Cell.Column.ToString = "cantidad" Or e.Cell.Column.ToString = "dias" Or e.Cell.Column.ToString = "Porcentaje" Then
            Dim ValorValida As Double = 0
            If e.Cell.Row.Cells("Porcentaje").Value = False Then
                ValorValida = e.Cell.Row.Cells("cantidad").Value * e.Cell.Row.Cells("dias").Value
                ValorValida = Math.Floor(ValorValida)
                e.Cell.Row.Cells("Total").Value = ValorValida
            Else
                ValorValida = ((e.Cell.Row.Cells("cantidad").Value / 100) * e.Cell.Row.Cells("CapDia").Value) * e.Cell.Row.Cells("dias").Value
                ValorValida = Math.Floor(ValorValida)
                e.Cell.Row.Cells("Total").Value = ValorValida
            End If
        End If
    End Sub

    Private Sub grdLimiteCapacidad_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdLimiteCapacidad.BeforeCellUpdate
        If e.Cell.Column.ToString = "cantidad" Or e.Cell.Column.ToString = "dias" Then
            If IsNumeric(e.NewValue) Then

                If e.Cell.Column.ToString = "dias" Then
                    If e.NewValue Mod 0.5 = 0 Then
                        If e.NewValue < 0 Then
                            e.Cancel = True
                        ElseIf e.NewValue > e.Cell.Row.Cells("DiasNave").Value And e.Cell.Row.Cells("DiasNave").Value >= 0 Then
                            Dim objMsjAdv As New Tools.AdvertenciaForm
                            objMsjAdv.mensaje = "No puede ingresar mas días de los que estan configurados."
                            objMsjAdv.ShowDialog()
                            e.Cancel = True
                        Else
                            'If e.Cell.Row.Cells("Porcentaje").Value = False Then
                            Dim ValorValida As Double = 0
                            ValorValida = e.NewValue * e.Cell.Row.Cells("cantidad").Value
                            If ValorValida > e.Cell.Row.Cells("CapSemana").Value And e.Cell.Row.Cells("CapSemana").Value >= 0 Then
                                Dim objMsjAdv As New Tools.AdvertenciaForm
                                objMsjAdv.mensaje = "El resultado de los datos ingresados no puede ser mayor a la capacidad semanal de la línea de producción."
                                objMsjAdv.ShowDialog()
                            End If

                            'End If
                        End If
                    Else
                        Dim objMsjAdv As New Tools.AdvertenciaForm
                        objMsjAdv.mensaje = "Solo puede introducir """ + "Medios días" + """ (0.5)," + vbCrLf + " ""días enteros"" (1) o sin día (0)."
                        objMsjAdv.ShowDialog()
                        e.Cancel = True
                    End If
                End If

                If e.Cell.Column.ToString = "cantidad" Then
                    If e.NewValue < 0 Then
                        e.Cancel = True
                    ElseIf e.NewValue > e.Cell.Row.Cells("CapDia").Value Then
                        Dim objMsjAdv As New Tools.AdvertenciaForm
                        objMsjAdv.mensaje = "No puede ingresar una cantidad arriba de la capacidad diaria de la línea de producción."
                        objMsjAdv.ShowDialog()
                        e.Cancel = True
                    Else
                        If e.Cell.Row.Cells("Porcentaje").Value = False Then
                            Dim ValorValida As Double = 0
                            ValorValida = e.NewValue * e.Cell.Row.Cells("dias").Value
                            If ValorValida > e.Cell.Row.Cells("CapSemana").Value Then
                                Dim objMsjAdv As New Tools.AdvertenciaForm
                                objMsjAdv.mensaje = "El resultado de los datos ingresados no puede ser mayor a la capacidad semanal de la línea de producción."
                            End If
                        Else
                            If e.NewValue > 100 Then
                                Dim objMsjAdv As New Tools.AdvertenciaForm
                                objMsjAdv.mensaje = "Si el valor es calculado en porcentaje, no puede introducir una cantidad mayor al 100%."
                                objMsjAdv.ShowDialog()
                                e.Cancel = True
                                'Else
                                '    Dim ValorValida As Double = 0
                                '    ValorValida = ((e.NewValue / 100) * e.Cell.Row.Cells("CapDia").Value) * e.Cell.Row.Cells("dias").Value
                            End If
                        End If
                    End If
                End If

            Else
                e.Cancel = True
            End If

        End If
    End Sub

    Private Sub grdLimiteCapacidad_CellChange(sender As Object, e As CellEventArgs) Handles grdLimiteCapacidad.CellChange
        If e.Cell.Column.ToString = "Porcentaje" Then

            If e.Cell.Row.Cells("cantidad").Value > 100 And CBool(e.Cell.Text) = True Then
                e.Cell.CancelUpdate()
                Dim objMsjAdv As New Tools.AdvertenciaForm
                objMsjAdv.mensaje = "Si el valor es calculado en porcentaje, no puede introducir una cantidad mayor al 100%."
                objMsjAdv.ShowDialog()
            ElseIf CBool(e.Cell.Text) = True Then
                Dim ValorValida As Double = 0
                ValorValida = ((e.Cell.Row.Cells("cantidad").Value / 100) * e.Cell.Row.Cells("CapDia").Value) * e.Cell.Row.Cells("dias").Value
                ValorValida = Math.Floor(ValorValida)
                e.Cell.Row.Cells("Total").Value = ValorValida
            Else
                Dim ValorValida As Double = 0
                ValorValida = e.Cell.Row.Cells("cantidad").Value * e.Cell.Row.Cells("dias").Value
                ValorValida = Math.Floor(ValorValida)
                e.Cell.Row.Cells("Total").Value = ValorValida
            End If
        End If
    End Sub

    Private Sub grdLimiteCapacidad_Error(sender As Object, e As ErrorEventArgs) Handles grdLimiteCapacidad.Error
        e.Cancel = True
        Dim objMensaje As New Tools.AdvertenciaForm
        objMensaje.mensaje = "Los datos introducidos no son válidos, presione Escape para salir de la edición de la celda."
        objMensaje.ShowDialog()
    End Sub

    Private Sub grdLimiteCapacidad_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdLimiteCapacidad.InitializeLayout

    End Sub

    Private Sub grdLimiteCapacidad_KeyDown(sender As Object, e As KeyEventArgs) Handles grdLimiteCapacidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdLimiteCapacidad.PerformAction(UltraGridAction.ExitEditMode, False, False)
            Dim banda As UltraGridBand = grdLimiteCapacidad.DisplayLayout.Bands(0)
            If grdLimiteCapacidad.ActiveRow.HasNextSibling(True) Then
                Dim nextRow As UltraGridRow = grdLimiteCapacidad.ActiveRow.GetSibling(SiblingRow.Next, True)
                grdLimiteCapacidad.ActiveCell = nextRow.Cells(grdLimiteCapacidad.ActiveCell.Column)
                e.Handled = True
                grdLimiteCapacidad.PerformAction(UltraGridAction.EnterEditMode, False, False)
            End If
        End If
    End Sub

    Private Sub grdLimiteCapacidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdLimiteCapacidad.KeyPress

    End Sub

    Private Sub chkLlenarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkLlenarTodo.CheckedChanged
        Dim objMensaje As New Tools.ConfirmarForm
        objMensaje.mensaje = "Ejecutar esta acción modificará los datos de todas las filas. ¿Está seguro de continuar?"
        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            For Each rowGrd As UltraGridRow In grdLimiteCapacidad.Rows
                If chkLlenarTodo.Checked = True Then
                    If rowGrd.Cells("capDia").Value > 0 And rowGrd.Cells("DiasNave").Value > 0 Then
                        rowGrd.Cells("dias").Value = rowGrd.Cells("DiasNave").Value
                        If rowGrd.Cells("Porcentaje").Value = False Then
                            rowGrd.Cells("cantidad").Value = rowGrd.Cells("capDia").Value
                        Else
                            rowGrd.Cells("cantidad").Value = 100
                        End If
                    End If
                Else
                    rowGrd.Cells("cantidad").Value = 0
                    rowGrd.Cells("dias").Value = 0
                End If
            Next
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub chkPorcentaje_CheckedChanged(sender As Object, e As EventArgs) Handles chkPorcentaje.CheckedChanged
        Dim objMensaje As New Tools.ConfirmarForm
        objMensaje.mensaje = "Ejecutar esta acción modificará los datos de todas las filas. ¿Está seguro de continuar?"
        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            For Each rowGrd As UltraGridRow In grdLimiteCapacidad.Rows
                If rowGrd.Cells("capDia").Value > 0 And rowGrd.Cells("DiasNave").Value > 0 Then
                    rowGrd.Cells("Porcentaje").Value = chkPorcentaje.Checked
                    If chkLlenarTodo.Checked = True Then
                        If rowGrd.Cells("capDia").Value > 0 And rowGrd.Cells("DiasNave").Value > 0 Then
                            If chkPorcentaje.Checked = False Then
                                rowGrd.Cells("cantidad").Value = rowGrd.Cells("capDia").Value
                            Else
                                rowGrd.Cells("cantidad").Value = 100
                            End If
                        End If
                    Else
                        rowGrd.Cells("cantidad").Value = 0
                        rowGrd.Cells("dias").Value = 0
                    End If
                End If
            Next
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objMConf As New Tools.ConfirmarForm
        objMConf.mensaje = "¿Está seguro de actualizar los datos?"
        If objMConf.ShowDialog = Windows.Forms.DialogResult.OK Then
            guardarConfiguracionesLimiteCapacidad()
        End If
    End Sub


    Private Sub lblGuardar_Click(sender As Object, e As EventArgs) Handles lblGuardar.Click

    End Sub
End Class