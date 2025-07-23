Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Programacion.Negocios
Imports Tools

Public Class Programacion_ColocacionSemanal_Configuracion_NaveFamiliaForm
    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objConfirmar As New Tools.ConfirmarForm
    Dim dtDatosNaves As New DataTable
    Dim objFamiliasForm As Programacion_ColocacionSemanal_Configuracion_FamiliasForm
    Dim radioActivo As Integer
    Dim eventoActivo As Boolean = False

    Private Sub Programacion_ColocacionSemanal_Configuracion_NaveFamiliaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.Location = New Point(0, 0)
        rdbActivo.Checked = True
        radioActivo = 1
        cmbNaves = Controles.ComboNavesSegunUsuario(cmbNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub
    Private Sub rdbConsultar_CheckedChanged(sender As Object, e As EventArgs)
        btnAsignar.Enabled = False
        lblAsignar.Enabled = False
        rdbActivo.Visible = True
        rdbInactivo.Visible = True
        'pnlBotonAsignar.Visible = False
        pnlBotonMostrar.Visible = True
    End Sub

    Private Sub rdbAsignacion_CheckedChanged(sender As Object, e As EventArgs)
        rdbActivo.Visible = False
        rdbInactivo.Visible = False
        pnlBotonMostrar.Visible = False
        'pnlBotonAsignar.Visible = True
    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        btnGuardar.Enabled = True
        lblGuardar.Enabled = True
        Dim asignar As Boolean = False
        If obtenerRenglonesEditados.Count > 0 Then
            objConfirmar.mensaje = "Todos los datos no guardados se perderán ¿Desea continuar?"
            If objConfirmar.ShowDialog = DialogResult.OK Then
                asignar = True
            End If
        Else asignar = True
        End If
        If asignar Then
            If (cmbNaves.SelectedValue >= 0 And cmbNaves.Text <> "") Then
                objFamiliasForm = New Programacion_ColocacionSemanal_Configuracion_FamiliasForm
                objFamiliasForm.IdNaveSay = cmbNaves.SelectedValue
                objFamiliasForm.NombreNave = cmbNaves.Text
                If objFamiliasForm.ShowDialog() = DialogResult.OK Then mostrarColeccionesFamilia()
            Else
                objAdvertencia.mensaje = "Debe seleccionar una nave"
                objAdvertencia.ShowDialog()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If (cmbNaves.SelectedValue >= 0 And cmbNaves.Text <> "") Then
            btnGuardar.Enabled = True
            lblGuardar.Enabled = True
            Dim continuar As Boolean = True
            If obtenerRenglonesEditados().Count > 0 Then
                objConfirmar.mensaje = "Todos los datos no guardados se perderán ¿Desea continuar?"
                If objConfirmar.ShowDialog = DialogResult.OK Then
                    continuar = True
                Else
                    continuar = False
                End If
            End If
            If (continuar = True) Then mostrarColeccionesFamilia()
        Else
            objAdvertencia.mensaje = "Debe seleccionar una nave"
            objAdvertencia.ShowDialog()
            btnGuardar.Enabled = False
            lblGuardar.Enabled = False
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim lstRenglonesEditados As List(Of Integer)
        Try
            lstRenglonesEditados = obtenerRenglonesEditados()

            If lstRenglonesEditados.Count > 0 Then

                objConfirmar.mensaje = "¿Está seguro de actualizar los datos?"
                If objConfirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim obj As New Programacion_FamiliaNave_BU
                    Cursor = Cursors.WaitCursor

                    Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
                    For Each item In lstRenglonesEditados
                        Dim activo = 1
                        If (vwReporte.GetRowCellValue(item, "ccnf_activo") = False) Then activo = 0
                        Dim vNodo As XElement = New XElement("Celda")
                        vNodo.Add(New XAttribute("NaveIdSAY", vwReporte.GetRowCellValue(item, "ccnf_naveidsay")))
                        vNodo.Add(New XAttribute("FamiliaIdSay", vwReporte.GetRowCellValue(item, "ccnf_familiaproyeccionidsay")))
                        vNodo.Add(New XAttribute("PorcentajeMaximo", vwReporte.GetRowCellValue(item, "ccnf_porcentajemaximocolocacion")))
                        vNodo.Add(New XAttribute("Activo", activo))
                        vNodo.Add(New XAttribute("UsuarioModificoId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                        vXmlCeldasModificadas.Add(vNodo)
                    Next
                    obj.EditarFamiliasAsignadasPorNave(vXmlCeldasModificadas.ToString())
                    objExito.mensaje = "Datos guardados correctamente."
                    objExito.ShowDialog()
                    mostrarColeccionesFamilia()
                End If
            Else
                objAdvertencia.mensaje = "No hay datos para actualizar."
                objAdvertencia.ShowDialog()
            End If

        Catch ex As Exception
            objErrores.mensaje = "Ocurrió un error al guardar, intente de nuevo."
            objErrores.ShowDialog()
        End Try
        Cursor = Cursors.Default
    End Sub
    Public Sub disenioGrid()
        vwReporte.OptionsView.ColumnAutoWidth = True
        vwReporte.OptionsView.EnableAppearanceEvenRow = True
        vwReporte.OptionsCustomization.AllowSort = True
        vwReporte.OptionsView.ShowAutoFilterRow = True

        vwReporte.IndicatorWidth = 30
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains

        Next

        vwReporte.Columns.ColumnByFieldName("ccnf_porcentajemaximocolocacion").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("ccnf_porcentajemaximocolocacion").DisplayFormat.FormatString = "#.00;[#.0];Zero"

        vwReporte.Columns.ColumnByFieldName("ccnf_naveidsay").Visible = False
        vwReporte.Columns.ColumnByFieldName("ccnf_familiaproyeccionidsay").Visible = False
        vwReporte.Columns.ColumnByFieldName("MaximoOriginal").Visible = False
        vwReporte.Columns.ColumnByFieldName("ActivoOriginal").Visible = False

        vwReporte.OptionsFilter.AllowFilterEditor = True
        If radioActivo = 1 Then
            vwReporte.Columns.ColumnByFieldName("ccnf_porcentajemaximocolocacion").Caption = "*% Máximo"
        Else
            vwReporte.Columns.ColumnByFieldName("ccnf_porcentajemaximocolocacion").Caption = "% Máximo"
        End If
        vwReporte.Columns.ColumnByFieldName("ccnf_activo").Caption = "*Activo"
        vwReporte.Columns.ColumnByFieldName("ccnf_activo").OptionsFilter.AllowAutoFilter = False
        vwReporte.BestFitColumns()

        vwReporte.Columns.ColumnByFieldName("ccnf_activo").Width = 50

        If (radioActivo = 1) Then
            vwReporte.OptionsBehavior.Editable = True
            vwReporte.Columns.ColumnByFieldName("Familia").OptionsColumn.AllowEdit = False
        Else
            vwReporte.Columns.ColumnByFieldName("Familia").OptionsColumn.AllowEdit = False
            vwReporte.Columns.ColumnByFieldName("ccnf_porcentajemaximocolocacion").OptionsColumn.AllowEdit = False
        End If
    End Sub
    Private Sub mostrarColeccionesFamilia()
        chkActivarInactivar.Checked = True
        If (radioActivo = 0) Then chkActivarInactivar.Checked = False
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Programacion_FamiliaNave_BU
            Dim dtConsultaFamilias As New DataTable
            grdReporte.DataSource = Nothing
            vwReporte.Columns.Clear()

            dtConsultaFamilias = obj.ConsultarFamiliasAsignadasPorNave(cmbNaves.SelectedValue, radioActivo)
            If dtConsultaFamilias.Rows.Count > 0 Then
                grdReporte.DataSource = dtConsultaFamilias
                disenioGrid()
            Else
                btnGuardar.Enabled = False
                lblGuardar.Enabled = False
                objAdvertencia.mensaje = "No existen datos registrados."
                objAdvertencia.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub rdbActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbActivo.CheckedChanged
        If rdbActivo.Checked And eventoActivo = False Then
            eventoActivo = True
            Dim continuar = False
            If obtenerRenglonesEditados.Count > 0 Then
                objConfirmar.mensaje = "Todos los datos no guardados se perderán ¿Desea continuar?"
                If objConfirmar.ShowDialog = DialogResult.OK Then
                    continuar = True
                Else
                    rdbActivo.Checked = False
                    rdbInactivo.Checked = True
                End If
            Else
                continuar = True
            End If
            If (continuar = True) Then
                radioActivo = 1
                grdReporte.DataSource = Nothing
                vwReporte.Columns.Clear()
            End If
            eventoActivo = False
        End If
    End Sub

    Private Sub rdbInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbInactivo.CheckedChanged
        If rdbInactivo.Checked And eventoActivo = False Then
            eventoActivo = True
            Dim continuar = False
            If obtenerRenglonesEditados.Count > 0 Then
                objConfirmar.mensaje = "Todos los datos no guardados se perderán ¿Desea continuar?"
                If objConfirmar.ShowDialog = DialogResult.OK Then
                    continuar = True
                Else
                    rdbInactivo.Checked = False
                    rdbActivo.Checked = True
                End If
            Else
                continuar = True
            End If
            If (continuar = True) Then
                radioActivo = 0
                grdReporte.DataSource = Nothing
                vwReporte.Columns.Clear()
            End If
            eventoActivo = False
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If obtenerRenglonesEditados().Count > 0 Then
            objConfirmar.mensaje = "Todos los datos no guardados se perderán ¿Desea continuar?"
            If objConfirmar.ShowDialog = DialogResult.OK Then Me.Dispose()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Function obtenerRenglonesEditados() As List(Of Integer)
        Dim NumeroFilas As Integer = vwReporte.DataRowCount
        Dim lstRenglonesEditados As New List(Of Integer)
        Dim tblOriginal As DataTable = grdReporte.DataSource

        Try

            For index As Integer = 0 To NumeroFilas Step 1
                Dim activoOriginal As Boolean = vwReporte.GetRowCellValue(index, "ActivoOriginal")
                Dim activoModificado As Boolean = vwReporte.GetRowCellValue(index, "ccnf_activo")
                Dim maximoOriginal As Double = IIf(vwReporte.GetRowCellValue(index, "MaximoOriginal") Is DBNull.Value, 0, vwReporte.GetRowCellValue(index, "MaximoOriginal"))
                Dim maximoModificado As Double = IIf(vwReporte.GetRowCellValue(index, "ccnf_porcentajemaximocolocacion") Is DBNull.Value, 0, vwReporte.GetRowCellValue(index, "ccnf_porcentajemaximocolocacion"))
                If activoOriginal <> activoModificado Or maximoOriginal <> maximoModificado Then
                    lstRenglonesEditados.Add(index)
                End If

            Next

        Catch ex As Exception

        End Try
        Return lstRenglonesEditados
    End Function

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 161
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 30
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            'CargarReporteParaExcel()
            If vwReporte.DataRowCount > 0 Then
                nombreReporte = "Colocacion_Semanal_Configuracion_de_" & cmbNaves.Text & "_"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If vwReporte.GroupCount > 0 Then
                            vwReporte.ExportToXlsx(.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                            vwReporte.ExportToXlsx(.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        'show_message("Exito", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
                'show_message("Advertencia", "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo")
            'show_message("Advertencia", "No se encontro el archivo")
        End Try
    End Sub
    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        If (e.RowHandle Mod 2 > 0) Then
            e.Formatting.BackColor = Color.LightSteelBlue
        End If

        e.Handled = True

    End Sub

    Private Sub vwReporte_CellValueChanged(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles vwReporte.CellValueChanged
        If (eventoActivo = False) Then
            eventoActivo = True
            Try
                Dim maximo As Double = IIf(vwReporte.GetRowCellValue(e.RowHandle, "ccnf_porcentajemaximocolocacion") Is DBNull.Value, 0, vwReporte.GetRowCellValue(e.RowHandle, "ccnf_porcentajemaximocolocacion"))
                If (maximo > 100) Then
                    objAdvertencia.mensaje = "El procentaje máximo de ser menor a 100"
                    objAdvertencia.ShowDialog()
                    vwReporte.SetRowCellValue(e.RowHandle, "ccnf_porcentajemaximocolocacion", "")
                End If
            Catch ex As Exception

            End Try
            eventoActivo = False
        End If
    End Sub

    Private Sub vwReporte_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles vwReporte.RowCellStyle
        Dim view As GridView = sender
        If (view Is Nothing) Then Return
        If (e.RowHandle >= 0) Then
            Dim activoOriginal As Boolean = view.GetRowCellValue(e.RowHandle, "ActivoOriginal")
            Dim activoModificado As Boolean = view.GetRowCellValue(e.RowHandle, "ccnf_activo")
            Dim maximoOriginal As Double = IIf(view.GetRowCellValue(e.RowHandle, "MaximoOriginal") Is DBNull.Value, 0, view.GetRowCellValue(e.RowHandle, "MaximoOriginal"))
            Dim maximoModificado As Double = IIf(view.GetRowCellValue(e.RowHandle, "ccnf_porcentajemaximocolocacion") Is DBNull.Value, 0, view.GetRowCellValue(e.RowHandle, "ccnf_porcentajemaximocolocacion"))
            If activoOriginal <> activoModificado Then
                e.Appearance.ForeColor = Color.DarkViolet
            ElseIf (e.Column.FieldName = "ccnf_porcentajemaximocolocacion") Then
                If maximoOriginal <> maximoModificado Then e.Appearance.ForeColor = Color.DarkViolet

            End If
        End If
    End Sub

    Private Sub chkActivarInactivar_CheckedChanged(sender As Object, e As EventArgs) Handles chkActivarInactivar.CheckedChanged
        Dim activar = False
        If (chkActivarInactivar.Checked) Then
            activar = True
        End If
        For i As Integer = 0 To (vwReporte.RowCount) Step 1
            vwReporte.SetRowCellValue(i, "ccnf_activo", activar)
        Next
    End Sub
    Private Sub Programacion_ColocacionSemanal_Configuracion_NaveFamiliaForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If obtenerRenglonesEditados().Count > 0 Then
            objConfirmar.mensaje = "Todos los datos no guardados se perderán ¿Desea continuar?"
            If objConfirmar.ShowDialog <> DialogResult.OK Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub cmbNaves_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNaves.SelectedIndexChanged
        grdReporte.DataSource = Nothing
        vwReporte.Columns.Clear()
    End Sub

    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
End Class