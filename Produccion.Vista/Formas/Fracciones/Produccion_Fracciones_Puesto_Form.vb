Imports Framework.Vista
Imports Entidades
Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports Tools.modMensajes

Public Class Produccion_Fracciones_Puesto_Form

    Dim usuarioId As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    Dim colaboradorId As Int32 = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser
    Public listarFracciones As New DataTable
    Dim objEntidades As Entidades.FraccionesPorPuesto
    Dim nave As Int32 = 0
    Dim Area As Int32 = 0
    Dim Depto As Int32 = 0
    Dim accion As Integer = 0
    Dim objConfirmar As New Tools.ConfirmarForm

    Private Sub Produccion_Fracciones_Puesto_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        cmboxNave = Tools.Controles.ComboNavesSegunUsuario(cmboxNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If rbtConsultar.Checked Then
            btnExportar.Visible = True
            lblExportar.Visible = True
        Else
            btnExportar.Visible = False
            lblExportar.Visible = False
        End If
    End Sub

    Private Sub cmboxNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmboxNave.SelectedIndexChanged
        'Dim nave As Int32 = 0

        If cmboxNave.SelectedIndex > 0 Then
            nave = CInt(cmboxNave.SelectedValue)
            If rbtConsultar.Checked = True Then
                cmboxArea.Enabled = False
            Else
                cmboxArea.Enabled = True
            End If
        End If
        cmboxArea = Tools.Controles.ComboAreaSegunNave(cmboxArea, nave)

    End Sub

    Private Sub cmboxArea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmboxArea.SelectedIndexChanged
        'Dim Area As Int32 = 0

        If cmboxArea.SelectedIndex > 0 Then
            Area = CInt(cmboxArea.SelectedValue)
            cmboxDepto.Enabled = True
        End If

        cmboxDepto = Tools.Controles.ComboDepatamentoSegunArea(cmboxDepto, Area)
    End Sub

    Private Sub cmboxDepto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmboxDepto.SelectedIndexChanged
        'Dim Depto As Int32 = 0

        If cmboxDepto.SelectedIndex > 0 Then
            Depto = CInt(cmboxDepto.SelectedValue)
            cmboxPuesto.Enabled = True

        End If

        cmboxPuesto = Tools.Controles.ComboPuestosSegunDepartamento(cmboxPuesto, Depto)

    End Sub

    Private Sub cmboxPuesto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmboxPuesto.SelectedIndexChanged
        If cmboxPuesto.SelectedIndex > 0 Then
            btnAsignar.Visible = True
            Label2.Visible = True
            btnAsignar.Enabled = True
            Label2.Enabled = True
        Else
            btnAsignar.Visible = False
            Label2.Visible = False
            btnAsignar.Enabled = False
            Label2.Enabled = False
        End If


    End Sub

    Private Sub rbtConsultar_CheckedChanged(sender As Object, e As EventArgs) Handles rbtConsultar.CheckedChanged
        If rbtConsultar.Checked Then
            btnExportar.Visible = True
            lblExportar.Visible = True
            grdFracciones.DataSource = Nothing
            cmboxNave.Enabled = True
            cmboxNave.Text = Nothing
            cmboxArea.Text = Nothing
            cmboxArea.Enabled = False
            cmboxDepto.Text = Nothing
            cmboxDepto.Enabled = False
            cmboxPuesto.Text = Nothing
            cmboxPuesto.Enabled = False
            btnAsignar.Enabled = False
            Label2.Enabled = False
            chboxSeleccionarTodo.Enabled = False
            btnGuardar.Enabled = False
            Label1.Enabled = False
            accion = 1
            btnEditar.Enabled = True
            lblEditar.Enabled = True
            btnEliminar.Enabled = True
            lblEliminar.Enabled = True
        Else
            btnExportar.Visible = False
            lblExportar.Visible = False
            grdFracciones.DataSource = Nothing
            grpAgregar.Enabled = False
            cmboxNave.Text = Nothing
            cmboxArea.Text = Nothing
            cmboxArea.Enabled = False
            cmboxDepto.Text = Nothing
            cmboxDepto.Enabled = False
            cmboxPuesto.Text = Nothing
            cmboxPuesto.Enabled = False
            btnAsignar.Enabled = False
            Label2.Enabled = False
            chboxSeleccionarTodo.Enabled = True
            accion = 0
            btnEditar.Enabled = False
            lblEditar.Enabled = False
            btnEliminar.Enabled = False
            lblEliminar.Enabled = False
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim tabla As DataTable
        Dim objBU As New ProduccionBU
        Cursor = Cursors.WaitCursor

        lblAccion.Visible = False
        lblAccion.Text = "..."
        If rbtConsultar.Checked = True And cmboxNave.Text = Nothing Then
            show_message("Advertencia", "Seleccione la nave")
            'ElseIf accion = 1 And cmboxNave.SelectedIndex > 0 Then
            '    accion = 0
        ElseIf rbtConsultar.Checked = True And ((cmboxNave.SelectedIndex > 0 And accion = 1) Or (cmboxNave.SelectedIndex > 0 And accion = 2)) Then
            Try
                grdVFracciones.Columns.Clear()
                grdFracciones.DataSource = Nothing
                nave = cmboxNave.SelectedValue
                tabla = objBU.DestajosFraccionesPorPuestoPorNave(nave)
                grdFracciones.DataSource = tabla

                If grdVFracciones.RowCount > 0 Then
                    disenioGridPorNave()
                Else
                    grdVFracciones.Columns.Clear()
                    show_message("Advertencia", "No hay datos por mostrar")
                End If

            Catch ex As Exception
                show_message("Error", ex.Message)
            End Try
            cmboxArea.Enabled = False
            cmboxDepto.Enabled = False
            cmboxPuesto.Enabled = False
            cmboxArea.Text = Nothing
            cmboxDepto.Text = Nothing
            cmboxPuesto.Text = Nothing
        Else
            grdVFracciones.Columns.Clear()
            grdFracciones.DataSource = Nothing

            obtenerFracciones()
        End If

        Cursor = Cursors.Default
    End Sub

    Public Sub obtenerFracciones()
        Dim obj As New ProduccionBU
        grdFracciones.DataSource = Nothing
        grdVFracciones.Columns.Clear()

        listarFracciones = obj.listarFracciones
        grdFracciones.DataSource = listarFracciones
        disenioGrid()

    End Sub

    Private Sub disenioGrid()

        Dim gridFormatRule As New GridFormatRule()
        Dim formatConditionRuleExpression As New DevExpress.XtraEditors.FormatConditionRuleExpression()

        grdVFracciones.IndicatorWidth = 40

        grdVFracciones.Columns("NaveId").Visible = False
        grdVFracciones.Columns("ÁreaId").Visible = False
        grdVFracciones.Columns("DepartamentoId").Visible = False
        grdVFracciones.Columns("PuestoId").Visible = False
        grdVFracciones.Columns("Activo").Visible = False

        grdVFracciones.Columns(" ").OptionsColumn.AllowEdit = True
        grdVFracciones.Columns("ID").OptionsColumn.AllowEdit = False
        grdVFracciones.Columns("Fracción").OptionsColumn.AllowEdit = False
        grdVFracciones.Columns("Nave").OptionsColumn.AllowEdit = False
        grdVFracciones.Columns("Área").OptionsColumn.AllowEdit = False
        grdVFracciones.Columns("Departamento").OptionsColumn.AllowEdit = False
        grdVFracciones.Columns("Puesto").OptionsColumn.AllowEdit = False

        grdVFracciones.Columns("ID").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVFracciones.Columns("Fracción").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVFracciones.Columns("Nave").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVFracciones.Columns("Área").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVFracciones.Columns("Departamento").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVFracciones.Columns("Puesto").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        grdVFracciones.Columns(" ").Width = 40
        grdVFracciones.Columns("ID").Width = 40
        grdVFracciones.Columns("Fracción").Width = 250
        grdVFracciones.Columns("Nave").Width = 250
        grdVFracciones.Columns("Área").Width = 250
        grdVFracciones.Columns("Departamento").Width = 250
        grdVFracciones.Columns("Puesto").Width = 245

        grdVFracciones.OptionsView.EnableAppearanceEvenRow = True
        grdVFracciones.OptionsView.EnableAppearanceOddRow = True
        grdVFracciones.OptionsSelection.EnableAppearanceFocusedCell = True
        grdVFracciones.OptionsSelection.EnableAppearanceFocusedRow = True
        grdVFracciones.Appearance.SelectedRow.Options.UseBackColor = True

        grdVFracciones.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)

        grdVFracciones.Appearance.EvenRow.BackColor = Color.White
        grdVFracciones.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        grdVFracciones.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVFracciones.Appearance.FocusedRow.ForeColor = Color.White

        grdVFracciones.Columns.ColumnByFieldName("ID").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVFracciones.Columns.ColumnByFieldName("Fracción").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVFracciones.Columns.ColumnByFieldName("Nave").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVFracciones.Columns.ColumnByFieldName("Área").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVFracciones.Columns.ColumnByFieldName("Departamento").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVFracciones.Columns.ColumnByFieldName("Puesto").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

    End Sub

    Private Sub disenioGridPorNave()

        grdVFracciones.IndicatorWidth = 40
        Dim formatConditionRuleExpression As New DevExpress.XtraEditors.FormatConditionRuleExpression()

        grdVFracciones.Columns("identidad").Visible = False
        grdVFracciones.Columns(" ").Visible = False
        grdVFracciones.Columns("areaId").Visible = False
        grdVFracciones.Columns("departamentoId").Visible = False
        grdVFracciones.Columns("puestoId").Visible = False
        grdVFracciones.Columns("naveId").Visible = False
        grdVFracciones.Columns("Nave").Visible = False

        grdVFracciones.Columns("IdFracción").OptionsColumn.AllowEdit = False
        grdVFracciones.Columns("Fracción").OptionsColumn.AllowEdit = False
        grdVFracciones.Columns("Área").OptionsColumn.AllowEdit = False
        grdVFracciones.Columns("Departamento").OptionsColumn.AllowEdit = False
        grdVFracciones.Columns("Puesto").OptionsColumn.AllowEdit = False

        grdVFracciones.Columns("IdFracción").Width = 100
        grdVFracciones.Columns("Fracción").Width = 250
        grdVFracciones.Columns("Área").Width = 250
        grdVFracciones.Columns("Departamento").Width = 250
        grdVFracciones.Columns("Puesto").Width = 250

        grdVFracciones.Columns("IdFracción").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVFracciones.Columns("Fracción").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVFracciones.Columns("Área").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVFracciones.Columns("Departamento").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVFracciones.Columns("Puesto").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        grdVFracciones.OptionsView.EnableAppearanceEvenRow = True
        grdVFracciones.OptionsView.EnableAppearanceOddRow = True
        grdVFracciones.OptionsSelection.EnableAppearanceFocusedCell = True
        grdVFracciones.OptionsSelection.EnableAppearanceFocusedRow = True
        grdVFracciones.Appearance.SelectedRow.Options.UseBackColor = True

        grdVFracciones.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)

        grdVFracciones.Appearance.EvenRow.BackColor = Color.White
        grdVFracciones.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        grdVFracciones.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVFracciones.Appearance.FocusedRow.ForeColor = Color.White

        grdVFracciones.Columns.ColumnByFieldName("IdFracción").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVFracciones.Columns.ColumnByFieldName("Fracción").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVFracciones.Columns.ColumnByFieldName("Área").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVFracciones.Columns.ColumnByFieldName("Departamento").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVFracciones.Columns.ColumnByFieldName("Puesto").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

    End Sub

    Private Sub rbtAsignar_CheckedChanged(sender As Object, e As EventArgs) Handles rbtAsignar.CheckedChanged
        If rbtAsignar.Checked = True Then
            grpAgregar.Enabled = True
            Panel6.Visible = True
            chboxSeleccionarTodo.Visible = True
            accion = 0
            lblAccion.Visible = False
            lblAccion.Text = "..."
        End If
    End Sub


    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Try


            Dim naveid = CInt(cmboxNave.SelectedValue)
            Dim areaid As Integer = CInt(cmboxArea.SelectedValue)
            Dim deptoid As Integer = CInt(cmboxDepto.SelectedValue)
            Dim puestoid As Integer = CInt(cmboxPuesto.SelectedValue)

            Dim nave As String = cmboxNave.Text
            Dim area As String = cmboxArea.Text
            Dim depto As String = cmboxDepto.Text
            Dim puesto As String = cmboxPuesto.Text

            If grdVFracciones.RowCount > 0 Then

                If ValidarLotesSeleccionados() = False Then
                    show_message("Advertencia", "Seleccione al menos una fracción")
                Else
                    If accion = 0 Then
                        For index As Integer = 0 To grdVFracciones.RowCount Step 1
                            If grdVFracciones.GetRowCellValue(index, " ") = True Then
                                grdVFracciones.SetRowCellValue(index, "NaveId", naveid)
                                grdVFracciones.SetRowCellValue(index, "ÁreaId", areaid)
                                grdVFracciones.SetRowCellValue(index, "DepartamentoId", deptoid)
                                grdVFracciones.SetRowCellValue(index, "PuestoId", puestoid)

                                grdVFracciones.SetRowCellValue(index, "Nave", nave)
                                grdVFracciones.SetRowCellValue(index, "Área", area)
                                grdVFracciones.SetRowCellValue(index, "Departamento", depto)
                                grdVFracciones.SetRowCellValue(index, "Puesto", puesto)

                            End If
                        Next
                    End If
                    If accion = 1 Then
                        For index As Integer = 0 To grdVFracciones.RowCount Step 1
                            If grdVFracciones.GetRowCellValue(index, " ") = True Then
                                grdVFracciones.SetRowCellValue(index, "areaId", areaid)
                                grdVFracciones.SetRowCellValue(index, "departamentoId", deptoid)
                                grdVFracciones.SetRowCellValue(index, "puestoId", puestoid)

                                grdVFracciones.SetRowCellValue(index, "Área", area)
                                grdVFracciones.SetRowCellValue(index, "Departamento", depto)
                                grdVFracciones.SetRowCellValue(index, "Puesto", puesto)

                            End If
                        Next
                    End If
                End If

                btnGuardar.Enabled = True
                Label1.Enabled = True
            Else
                show_message("Advertencia", "Es necesario mostrar la lista de fracciones para asignar")

            End If

        Catch ex As Exception
            show_message("Advertencia", ex.Message)
        End Try


    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged

        Dim NumeroFilas As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVFracciones.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                grdVFracciones.SetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), " ", chboxSeleccionarTodo.Checked)
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        If rbtConsultar.Checked = True And cmboxNave.SelectedIndex > 0 Then
            grdVFracciones.Columns.Clear()
            grdFracciones.DataSource = Nothing
            lblAccion.Visible = False
            lblAccion.Text = "..."
        Else
            grdVFracciones.Columns.Clear()
            grdFracciones.DataSource = Nothing
            obtenerFracciones()
            btnGuardar.Enabled = False
            Label1.Enabled = False
            lblAccion.Visible = False
            lblAccion.Text = "..."
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBu = New ProduccionBU
        Dim NumeroFilas As Integer


        Me.Cursor = Cursors.WaitCursor
        Try
            NumeroFilas = grdVFracciones.DataRowCount
            If accion = 0 Then
                For index As Integer = 0 To NumeroFilas Step 1
                    If grdVFracciones.GetRowCellValue(index, "Nave") <> Nothing And grdVFracciones.GetRowCellValue(index, "Área") <> Nothing And
                        grdVFracciones.GetRowCellValue(index, "Departamento") <> Nothing And grdVFracciones.GetRowCellValue(index, "Puesto") <> Nothing Then

                        objEntidades = New Entidades.FraccionesPorPuesto
                        objEntidades.FraccionId = grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "ID")
                        objEntidades.NaveSayid = CInt(grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "NaveId"))
                        objEntidades.AreaId = CInt(grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "ÁreaId"))
                        objEntidades.DepartamentoId = CInt(grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "DepartamentoId"))
                        objEntidades.PuestoId = CInt(grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "PuestoId"))
                        objEntidades.Activo = CBool(grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "Activo"))
                        objEntidades.ColaboradorCreoId = colaboradorId
                        objEntidades.UsuarioCreoId = usuarioId

                        objBu.DestajosFraccionesPuesto(objEntidades)

                    End If

                Next
            End If
            If accion = 1 Then
                objConfirmar.mensaje = "Se modificaran las fracciones seleccionadas, ¿Quiere continuar el proceso?"
                If objConfirmar.ShowDialog = DialogResult.OK Then
                    For index As Integer = 0 To NumeroFilas Step 1
                        If grdVFracciones.GetRowCellValue(index, " ") = True Then
                            objEntidades = New Entidades.FraccionesPorPuesto
                            objEntidades.idTabla = CInt(grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "identidad"))
                            objEntidades.NaveSayid = CInt(grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "naveId"))
                            objEntidades.FraccionId = CInt(grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "IdFracción"))
                            objEntidades.AreaId = CInt(grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "areaId"))
                            objEntidades.DepartamentoId = CInt(grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "departamentoId"))
                            objEntidades.PuestoId = CInt(grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "puestoId"))
                            objEntidades.ColaboradorModificoId = colaboradorId
                            objEntidades.UsuarioModificoId = usuarioId

                            objBu.DestajosFraccionesPuesto_editar(objEntidades, accion)

                        End If
                    Next
                End If
            End If
            If accion = 2 Then
                objConfirmar.mensaje = "Se eliminaran las fracciones seleccionadas, ¿Quiere continuar el proceso?"
                If objConfirmar.ShowDialog = DialogResult.OK Then
                    For index As Integer = 0 To NumeroFilas Step 1
                        If grdVFracciones.GetRowCellValue(index, " ") = True Then
                            objEntidades = New Entidades.FraccionesPorPuesto
                            objEntidades.idTabla = CInt(grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "identidad"))
                            objEntidades.NaveSayid = CInt(grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "naveId"))
                            objEntidades.FraccionId = CInt(grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "IdFracción"))
                            objEntidades.ColaboradorModificoId = colaboradorId
                            objEntidades.UsuarioModificoId = usuarioId

                            objBu.DestajosFraccionesPuesto_editar(objEntidades, accion)

                        End If
                    Next
                Else
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            cmboxNave.Text = Nothing
            cmboxArea.Text = Nothing
            cmboxArea.Enabled = False
            cmboxDepto.Text = Nothing
            cmboxDepto.Enabled = False
            cmboxPuesto.Text = Nothing
            cmboxPuesto.Enabled = False
            btnAsignar.Enabled = False
            Label2.Enabled = False
            btnGuardar.Enabled = False
            Label1.Enabled = False
            chboxSeleccionarTodo.Checked = False
            obtenerFracciones()
            rbtAsignar.Checked = True
            lblAccion.Visible = False
            lblAccion.Text = "..."
            show_message("Exito", "Se han guardado los datos correctemente")

        Catch ex As Exception
            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = ex.Message
            mensajeError.ShowDialog()
        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Function ValidarLotesSeleccionados() As Boolean
        Dim NumeroFilas As Integer = 0
        Dim HayLotesSeleccionados As Boolean = False
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVFracciones.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                If grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), " ") = True Then
                    HayLotesSeleccionados = True
                End If
            Next

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Throw ex
        End Try
        Return HayLotesSeleccionados
    End Function

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New Tools.AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New Tools.AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New Tools.ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub


    Private Sub grdVFracciones_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdVFracciones.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If grdVFracciones.RowCount > 0 Then
            Dim objMensaje As New Tools.ConfirmarForm
            objMensaje.mensaje = "¿Esta saseguro de salir de ésta ventana sin guardar cambios?"
            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If


    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim tabla As New DataTable
        Dim objBU As New ProduccionBU

        accion = 1
        If grdVFracciones.RowCount > 0 Then
            grdVFracciones.Columns(" ").Visible = True
            cmboxArea.Enabled = True
            btnGuardar.Enabled = False
            lblAccion.Visible = True
            lblAccion.Text = "Editando Fracciones."
            grdVFracciones.Columns.Clear()
            grdFracciones.DataSource = Nothing

            tabla = objBU.DestajosFraccionesPorPuestoPorNave(nave)
            grdFracciones.DataSource = tabla

            If tabla.Rows.Count > 0 Then
                disenioGridPorNave()
            End If
            grdVFracciones.Columns(" ").Visible = True
        Else
            show_message("Advertencia", "Es necesario mostrar la lista de fracciones para editar")
        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        Dim tabla As New DataTable
        Dim objBU As New ProduccionBU

        accion = 2
        If grdVFracciones.RowCount > 0 Then
            cmboxArea.Enabled = False
            cmboxArea.Text = Nothing
            cmboxDepto.Enabled = False
            cmboxDepto.Text = Nothing
            cmboxPuesto.Enabled = False
            cmboxPuesto.Text = Nothing
            btnAsignar.Visible = False
            btnGuardar.Enabled = True
            lblAccion.Visible = True
            lblAccion.Text = "Eliminando Fracciones."

            grdVFracciones.Columns.Clear()
            grdFracciones.DataSource = Nothing

            tabla = objBU.DestajosFraccionesPorPuestoPorNave(nave)
            grdFracciones.DataSource = tabla

            If tabla.Rows.Count > 0 Then
                disenioGridPorNave()
            End If
            grdVFracciones.Columns(" ").Visible = True

        Else
            show_message("Advertencia", "Es necesario mostrar la lista de fracciones para eliminar")
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If grdVFracciones.DataRowCount > 0 Then


                nombreReporte = "Fracciones_por_puesto_"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        grdVFracciones.Columns("Nave").Visible = True
                        If grdVFracciones.GroupCount > 0 Then
                            grdVFracciones.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            'AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                            grdVFracciones.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Tools.modMensajes.Mensajes.Warning, "No se encontró el archivo")
        End Try
    End Sub
End Class