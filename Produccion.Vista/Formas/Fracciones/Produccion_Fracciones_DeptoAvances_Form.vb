Imports Entidades
Imports Produccion.Negocios
Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports DevExpress.Export

Public Class Produccion_Fracciones_DeptoAvances_Form
    Dim objUsuarioSesion As Usuarios
    Dim listaDeps As New List(Of DepartamentosProduccion)
    Dim Departamentos As New List(Of DepartamentosProduccion)

    Dim usuarioId As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    Dim colaboradorId As Int32 = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser
    Dim objEntidades As Entidades.FraccionesPorPuesto
    Dim obj As New ProduccionBU
    Dim tablaNaves As New DataTable
    Dim tablaDeptos As New DataTable
    Public listarFracciones As New DataTable
    Dim nave As Integer
    Dim depto As Integer
    Dim editar As Boolean = False
    Dim FracXNave As DataTable
    Dim estatus As Boolean
    Dim Insertado As DataTable

    Private Sub Produccion_Fracciones_DeptoAvances_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = FormWindowState.Maximized
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        If rdoAsignar.Checked = True Then
            cmbNave.Enabled = True
            chboxSeleccionarTodo.Visible = True
            iniciar()
        ElseIf rdoConsultar.Checked = True Then
            cmbDeptoAvance.Enabled = True
            cmbDeptoAvance.Text = ""
        End If

    End Sub

    Public Sub iniciar()
        Try
            objUsuarioSesion = SesionUsuario.UsuarioSesion
            cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, objUsuarioSesion.PUserUsuarioid)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        Dim obj As New ProduccionBU
        If cmbNave.SelectedIndex > 0 Then
            tablaDeptos = obj.DepartamentosPorNave(cmbNave.SelectedValue)
            tablaDeptos.Rows.InsertAt(tablaDeptos.NewRow, 0)
            cmbDeptoAvance.DataSource = tablaDeptos
            cmbDeptoAvance.ValueMember = "IdDepto"
            cmbDeptoAvance.DisplayMember = "Departamento"
        Else
            If cmbNave.Text = Nothing Then
                cmbDeptoAvance.SelectedValue = 0
            End If
        End If
    End Sub

    Private Sub cmbDeptoAvance_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDeptoAvance.SelectedIndexChanged
        'If cmbDeptoAvance.SelectedIndex > 0 Then
        '    btnAsignar.Visible = True
        '    lblAsignar.Visible = True
        'Hola
        'Else
        '    btnAsignar.Visible = False
        '    lblAsignar.Visible = False
        'End If
    End Sub

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


    Private Sub rdoConsultar_CheckedChanged(sender As Object, e As EventArgs) Handles rdoConsultar.CheckedChanged
        If rdoConsultar.Checked = True Then
            grdFracciones.DataSource = Nothing
            grdVFracciones.Columns.Clear()
            cmbDeptoAvance.Enabled = False
            cmbDeptoAvance.Text = ""
            btnAsignar.Visible = False
            lblAsignar.Visible = False
            rdoActivo.Visible = True
            RdoInactivo.Visible = True
        End If
    End Sub

    Private Sub rdoAsignar_CheckedChanged(sender As Object, e As EventArgs) Handles rdoAsignar.CheckedChanged
        If rdoAsignar.Checked = True Then
            grdFracciones.DataSource = Nothing
            grdVFracciones.Columns.Clear()
            cmbDeptoAvance.Enabled = True
            cmbDeptoAvance.Text = ""
            btnEditar.Visible = False
            lblEditar.Visible = False
            rdoActivo.Visible = False
            RdoInactivo.Visible = False
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New ProduccionBU
        Cursor = Cursors.WaitCursor

        Try
            grdVFracciones.Columns.Clear()
            grdFracciones.DataSource = Nothing

            If rdoAsignar.Checked = True And cmbNave.Text = Nothing Then
                show_message("Advertencia", "Seleccione la nave")
            ElseIf rdoAsignar.Checked = True And cmbNave.SelectedIndex > 0 And cmbDeptoAvance.SelectedIndex = Nothing Then
                show_message("Advertencia", "Seleccione el departamento")
            ElseIf rdoAsignar.Checked = True And cmbNave.SelectedIndex > 0 And cmbDeptoAvance.SelectedIndex > 0 Then
                obtenerFracciones()
                btnAsignar.Visible = True
                lblAsignar.Visible = True
                If grdVFracciones.RowCount > 0 Then
                    btnGuardar.Enabled = True
                    lblGuardar.Enabled = True
                End If
            ElseIf rdoConsultar.Checked = True And cmbNave.Text = Nothing Then
                show_message("Advertencia", "Seleccione la nave a consultar")
            Else
                If rdoActivo.Checked = True Then
                    estatus = True
                    consultarporNave(estatus)
                Else
                    estatus = False
                    consultarporNave(estatus)
                End If

                If grdVFracciones.RowCount > 0 Then
                    disenioGridConsultar()
                    btnEditar.Visible = True
                    lblEditar.Visible = True
                Else
                    grdVFracciones.Columns.Clear()
                    grdFracciones.DataSource = Nothing
                    show_message("Aviso", "No existen registros en la nave seleccionada")
                End If
            End If
        Catch ex As Exception

        End Try
        Cursor = Cursors.Default

    End Sub

    Public Sub obtenerFracciones()
        Dim obj As New ProduccionBU

        listarFracciones = obj.listarFraccionesAvanceDepto(cmbNave.SelectedValue)

        grdFracciones.DataSource = listarFracciones
        disenioGridAsignar()
    End Sub

    Public Sub disenioGridAsignar()

        Dim gridFormatRule As New GridFormatRule()
        Dim formatConditionRuleExpression As New DevExpress.XtraEditors.FormatConditionRuleExpression()

        grdVFracciones.IndicatorWidth = 40

        grdVFracciones.Columns("NaveId").Visible = False
        grdVFracciones.Columns("DepartamentoId").Visible = False
        grdVFracciones.Columns("Nave").Visible = False
        grdVFracciones.Columns("Activo").Visible = False

        grdVFracciones.Columns(" ").OptionsColumn.AllowEdit = True
        grdVFracciones.Columns("ID").OptionsColumn.AllowEdit = False
        grdVFracciones.Columns("Fracción").OptionsColumn.AllowEdit = False
        grdVFracciones.Columns("Departamento").OptionsColumn.AllowEdit = False

        grdVFracciones.Columns("ID").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVFracciones.Columns("Fracción").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVFracciones.Columns("Departamento").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        grdVFracciones.Columns(" ").Width = 40
        grdVFracciones.Columns("ID").Width = 40
        grdVFracciones.Columns("Fracción").Width = 250
        grdVFracciones.Columns("Departamento").Width = 250

        grdVFracciones.Columns.ColumnByFieldName("ID").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVFracciones.Columns.ColumnByFieldName("Fracción").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVFracciones.Columns.ColumnByFieldName("Departamento").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

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


    End Sub

    Public Sub disenioGridConsultar()

        Dim gridFormatRule As New GridFormatRule()
        Dim formatConditionRuleExpression As New DevExpress.XtraEditors.FormatConditionRuleExpression()

        grdVFracciones.IndicatorWidth = 40

        grdVFracciones.Columns(" ").Visible = False
        grdVFracciones.Columns("IdTabla").Visible = False
        grdVFracciones.Columns("IdDepto").Visible = False
        grdVFracciones.Columns("IdNave").Visible = False
        grdVFracciones.Columns("FechaCreacion").Visible = False
        grdVFracciones.Columns("ColaboradorCreo").Visible = False
        grdVFracciones.Columns("UsuarioCreo").Visible = False
        grdVFracciones.Columns("Activo").Visible = False

        grdVFracciones.Columns("Departamento").OptionsColumn.AllowEdit = False
        grdVFracciones.Columns("IdFracción").OptionsColumn.AllowEdit = False
        grdVFracciones.Columns("Fracción").OptionsColumn.AllowEdit = False
        grdVFracciones.Columns("Activo").OptionsColumn.AllowEdit = False

        grdVFracciones.Columns("Departamento").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVFracciones.Columns("IdFracción").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVFracciones.Columns("Fracción").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVFracciones.Columns("Activo").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        grdVFracciones.Columns(" ").Width = 30
        grdVFracciones.Columns("IdFracción").Width = 80
        grdVFracciones.Columns("Fracción").Width = 210
        grdVFracciones.Columns("Departamento").Width = 210

        grdVFracciones.Columns.ColumnByFieldName(" ").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVFracciones.Columns.ColumnByFieldName("IdFracción").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVFracciones.Columns.ColumnByFieldName("Fracción").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVFracciones.Columns.ColumnByFieldName("Departamento").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

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

    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Try
            Dim naveid = CInt(cmbNave.SelectedValue)
            Dim deptoid As Integer = CInt(cmbDeptoAvance.SelectedValue)

            Dim nave As String = cmbNave.Text
            Dim depto As String = cmbDeptoAvance.Text

            If grdVFracciones.RowCount > 0 Then
                If ValidarLotesSeleccionados() = False Then
                    show_message("Advertencia", "Seleccione al menos una fracción")
                Else
                    For index As Integer = 0 To grdVFracciones.RowCount Step 1
                        If grdVFracciones.GetRowCellValue(index, " ") = True Then
                            grdVFracciones.SetRowCellValue(index, "NaveId", naveid)
                            If editar = False Then
                                grdVFracciones.SetRowCellValue(index, "DepartamentoId", deptoid)
                            Else
                                grdVFracciones.SetRowCellValue(index, "IdDepto", deptoid)
                            End If

                            grdVFracciones.GetRowCellValue(index, "Nave")
                            grdVFracciones.SetRowCellValue(index, "Departamento", depto)
                        End If
                    Next
                    btnGuardar.Enabled = True
                    lblGuardar.Enabled = True
                End If
            Else
                show_message("Advertencia", "Es necesario mostrar la lista de fracciones para asignar")
            End If
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try

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

    Private Sub grdVFracciones_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdVFracciones.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBu As New ProduccionBU
        Dim NumeroFilas As Integer
        Dim tabla As New DataTable
        Me.Cursor = Cursors.WaitCursor

        Try
            NumeroFilas = grdVFracciones.DataRowCount
            If editar = False Then
                For index As Integer = 0 To NumeroFilas Step 1
                    If grdVFracciones.GetRowCellValue(index, "Departamento") <> Nothing Then

                        objEntidades = New Entidades.FraccionesPorPuesto
                        objEntidades.FraccionId = grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "ID")
                        objEntidades.NaveSICYid = CInt(grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "NaveId"))
                        objEntidades.DepartamentoId = CInt(grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "DepartamentoId"))
                        objEntidades.Departamento = grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "Departamento")
                        objEntidades.Activo = CBool(grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "Activo"))
                        objEntidades.ColaboradorCreoId = colaboradorId
                        objEntidades.UsuarioCreoId = usuarioId

                        Insertado = obj.FraccionesDeptoAvance(objEntidades)

                    End If
                    
                Next
                show_message("Exito", "Se han asignado las fracciones al departamento de avance")
            End If
            If editar = True Then
                For index As Integer = 0 To NumeroFilas Step 1
                    If grdVFracciones.GetRowCellValue(index, " ") = True Then
                        tabla = FracXNave
                        objEntidades = New Entidades.FraccionesPorPuesto
                        objEntidades.idTabla = CInt(grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "IdTabla"))
                        objEntidades.DepartamentoId = CInt(grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "IdDepto"))
                        objEntidades.Departamento = grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "Departamento")
                        objEntidades.Activo = CBool(grdVFracciones.GetRowCellValue(grdVFracciones.GetVisibleRowHandle(index), "Activo"))
                        objEntidades.UsuarioModificoId = usuarioId

                        Insertado = obj.Ediar_FraccionesDeptoAvanceXNave(objEntidades)

                    End If
                Next
                show_message("Exito", "Se ha modificado la fracción correctamente")
                If rdoActivo.Checked = True Then
                    estatus = True
                    consultarporNave(estatus)
                Else
                    estatus = False
                    consultarporNave(estatus)
                End If
                If grdVFracciones.RowCount > 0 Then
                    disenioGridConsultar()
                    btnEditar.Visible = True
                    lblEditar.Visible = True
                Else
                    grdVFracciones.Columns.Clear()
                    grdFracciones.DataSource = Nothing
                    show_message("Aviso", "No existen registros en la nave seleccionada")
                End If
            End If
            editar = False
            'cmbNave.SelectedValue = 0
            'cmbNave.Text = Nothing
            'cmbDeptoAvance.Enabled = True
            'cmbDeptoAvance.SelectedValue = 0
            'cmbDeptoAvance.Text = ""
            'grdFracciones.DataSource = Nothing
            'grdVFracciones.Columns.Clear()
            'btnAsignar.Visible = False
            'lblAsignar.Visible = False
            'btnEditar.Visible = False
            'lblEditar.Visible = False
            'btnGuardar.Enabled = False
            'lblGuardar.Enabled = False
            'rdoAsignar.Checked = True
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try

        Me.Cursor = Cursors.Default

    End Sub

    Public Sub consultarporNave(ByVal estatus As Boolean)
        Dim objN As New ProduccionBU


        Try
            FracXNave = objN.Consulta_FraccionesDeptoAvanceXNave(cmbNave.SelectedValue, estatus)
            grdFracciones.DataSource = FracXNave
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim filename As String

        Try
            If grdVFracciones.RowCount > 0 Then
                'Ask the user where to save the file to
                Dim SaveFileDialog As New SaveFileDialog()
                SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
                SaveFileDialog.FilterIndex = 2
                SaveFileDialog.RestoreDirectory = True
                If SaveFileDialog.ShowDialog() = DialogResult.OK Then

                    'This is required so that excel doesn't make all the grids very small. This will export all grids space out evenly
                    grdVFracciones.OptionsPrint.AutoWidth = True
                    grdVFracciones.OptionsPrint.EnableAppearanceEvenRow = True
                    grdVFracciones.OptionsPrint.PrintPreview = True
                    'Set the selected file as the filename
                    filename = SaveFileDialog.FileName

                    Dim exportOptions = New XlsxExportOptionsEx()
                    'AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                    'Export the file via inbuild function
                    DevExpress.Export.ExportSettings.DefaultExportType = ExportType.Default
                    grdVFracciones.ExportToXlsx(filename, exportOptions)

                    'If the file exists (i.e. export worked), then open it
                    If System.IO.File.Exists(filename) Then
                        Dim DialogResult As DialogResult = MessageBox.Show("El archivo ha sido exportado a " & filename & vbNewLine & "¿Quieres abrirlo ahora?", "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If DialogResult = Windows.Forms.DialogResult.Yes Then
                            System.Diagnostics.Process.Start(filename)
                        End If
                    End If
                End If
            Else
                show_message("Aviso", "No existen registros para exportar")
            End If
            
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        editar = True
        grdVFracciones.Columns(" ").Visible = True
        grdVFracciones.Columns(" ").OptionsColumn.AllowEdit = True
        grdVFracciones.Columns("Activo").Visible = True
        grdVFracciones.Columns("Activo").OptionsColumn.AllowEdit = True
        cmbDeptoAvance.Enabled = True
        btnAsignar.Visible = True
        lblAsignar.Visible = True
        btnGuardar.Enabled = True
        lblGuardar.Enabled = True
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        editar = False
        cmbNave.SelectedValue = 0
        cmbNave.Text = Nothing
        cmbDeptoAvance.Enabled = False
        cmbDeptoAvance.SelectedValue = 0
        cmbDeptoAvance.Text = ""
        grdFracciones.DataSource = Nothing
        grdVFracciones.Columns.Clear()
        btnAsignar.Visible = False
        lblAsignar.Visible = False
        btnEditar.Visible = False
        lblEditar.Visible = False
        btnGuardar.Enabled = False
        lblGuardar.Enabled = False
        rdoAsignar.Checked = True
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class