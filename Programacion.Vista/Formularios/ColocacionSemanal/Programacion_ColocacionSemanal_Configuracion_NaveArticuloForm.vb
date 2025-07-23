Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Programacion.Negocios
Imports Tools

Public Class Programacion_ColocacionSemanal_Configuracion_NaveArticuloForm
    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objConfirmar As New Tools.ConfirmarForm
    Dim dtDatosNaves As New DataTable
    Dim objArticulosForm As Programacion_ColocacionSemanal_Configuracion_ArticulosForm
    Dim objArticulosFormMovimientoColecciones As Programacion_MovimientosPPCP_Articulos
    Dim radioActivo As Integer
    Dim eventoActivo As Boolean = False
    Public Sub disenioGrid()
        'vwReporte.OptionsView.ColumnAutoWidth = True
        'vwReporte.OptionsView.EnableAppearanceEvenRow = True
        vwReporte.OptionsCustomization.AllowSort = True
        vwReporte.OptionsCustomization.AllowFilter = True
        vwReporte.IndicatorWidth = 30
        vwReporte.OptionsView.ShowAutoFilterRow = True
        'vwReporte.OptionsView.RowAutoHeight = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If (col.FieldName <> "ccna_prioridad" And col.FieldName <> "ccna_activo" And col.FieldName <> " ") Then
                col.OptionsColumn.AllowEdit = False
            End If
        Next

        vwReporte.OptionsFilter.AllowFilterEditor = True
        vwReporte.Columns.ColumnByFieldName("ccna_naveidsay").Visible = False
        vwReporte.Columns.ColumnByFieldName("ccna_productoestiloid").Visible = False
        vwReporte.Columns.ColumnByFieldName("PrioridadOriginal").Visible = False
        vwReporte.Columns.ColumnByFieldName("ActivoOriginal").Visible = False
        vwReporte.Columns.ColumnByFieldName("SiguienteFechaAsignarOriginal").Visible = False
        vwReporte.Columns.ColumnByFieldName("ProgramarDesdeOriginal").Visible = False
        vwReporte.Columns.ColumnByFieldName("ccna_siguientefechaasignarusuario").Visible = False

        vwReporte.Columns.ColumnByFieldName("ccna_siguientefechaasignar").Caption = "Sig. Fecha Asignar"
        vwReporte.Columns.ColumnByFieldName("ccna_siguientesemanaasignar").Caption = "Sig. Semana Asignar"
        vwReporte.Columns.ColumnByFieldName("Modelo SAY").Caption = "Modelo" + vbCrLf + "SAY"
        vwReporte.Columns.ColumnByFieldName("Modelo SICY").Caption = "Modelo" + vbCrLf + "SICY"

        If radioActivo = 1 Then
            vwReporte.Columns.ColumnByFieldName("ccna_prioridad").Caption = "*Prioridad"
        Else
            vwReporte.Columns.ColumnByFieldName("ccna_prioridad").Caption = "Prioridad"
        End If
        vwReporte.Columns.ColumnByFieldName("ccna_activo").Caption = "*Activo"
        vwReporte.Columns.ColumnByFieldName("ccna_activo").OptionsFilter.AllowAutoFilter = False

        vwReporte.Columns.ColumnByFieldName(" ").Width = 50
        vwReporte.Columns.ColumnByFieldName("ccna_activo").Width = 50
        vwReporte.Columns.ColumnByFieldName("ccna_prioridad").Width = 70
        vwReporte.Columns.ColumnByFieldName("ccna_activo").OptionsColumn.AllowSize = False
        vwReporte.Columns.ColumnByFieldName("ccna_prioridad").OptionsColumn.AllowSize = False
        vwReporte.Columns.ColumnByFieldName("Prioridades").MinWidth = 150
        vwReporte.Columns.ColumnByFieldName("Prioridades").MaxWidth = 2000
        vwReporte.Columns.ColumnByFieldName("ccna_activo").Width = 60
        vwReporte.Columns.ColumnByFieldName("Modelo SAY").Width = 70
        vwReporte.Columns.ColumnByFieldName("Modelo SICY").Width = 70
        vwReporte.Columns.ColumnByFieldName("ccna_siguientesemanaasignar").Width = 70
        vwReporte.Columns.ColumnByFieldName("Colección").Width = 200
        vwReporte.Columns.ColumnByFieldName("Talla").Width = 60
        vwReporte.Columns.ColumnByFieldName("Piel").Width = 100
        vwReporte.Columns.ColumnByFieldName("Color").Width = 100
        vwReporte.Columns.ColumnByFieldName("Marca").Width = 80
        'vwReporte.BestFitColumns()

    End Sub
    Private Sub mostrarArticulosNave()
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Programacion_ArticuloNave_BU
            Dim dtConsultaFamilias As New DataTable
            grdReporteOriginal.DataSource = Nothing
            grdReporte.DataSource = Nothing
            vwReporteOriginal.Columns.Clear()
            vwReporte.Columns.Clear()
            If rdbActivo.Checked = True Then
                radioActivo = 1
            Else
                radioActivo = 0
            End If
            dtConsultaFamilias = obj.ConsultarArticulosAsignadasPorNave(cmbNaves.SelectedValue, radioActivo)
            If dtConsultaFamilias.Rows.Count > 0 Then
                chkSeleccionarTodo.Checked = False
                chkActivarInactivar.Checked = False
                grdReporte.DataSource = dtConsultaFamilias
                grdReporteOriginal.DataSource = dtConsultaFamilias.Copy
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
    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        If (e.RowHandle Mod 2 > 0) Then
            e.Formatting.BackColor = Color.LightSteelBlue
        End If

        e.Handled = True

    End Sub
    Private Function obtenerRenglonesEditados() As List(Of Integer)
        Dim NumeroFilas As Integer = vwReporte.DataRowCount
        Dim lstRenglonesEditados As New List(Of Integer)
        Dim tblOriginal As DataTable = grdReporte.DataSource

        Try
            With vwReporte
                For index As Integer = 0 To NumeroFilas Step 1
                    Dim activoOriginal As Boolean = .GetRowCellValue(index, "ActivoOriginal")
                    Dim activoModificado As Boolean = .GetRowCellValue(index, "ccna_activo")
                    Dim prioridadOriginal As Integer = .GetRowCellValue(index, "PrioridadOriginal")
                    Dim prioridadModificado As Integer = .GetRowCellValue(index, "ccna_prioridad")
                    Dim fechaOriginal As String = IIf(.GetRowCellValue(index, "SiguienteFechaAsignarOriginal") Is DBNull.Value, "", .GetRowCellValue(index, "SiguienteFechaAsignarOriginal"))
                    Dim fechaModificado As String = IIf(.GetRowCellValue(index, "ccna_siguientefechaasignar") Is DBNull.Value, "", .GetRowCellValue(index, "ccna_siguientefechaasignar"))
                    If activoOriginal <> activoModificado Or prioridadOriginal <> prioridadModificado Or fechaOriginal <> fechaModificado Then
                        lstRenglonesEditados.Add(index)
                    End If

                Next
            End With
        Catch ex As Exception

        End Try
        Return lstRenglonesEditados
    End Function
    Private Function obtenerRenglonesSeleccionados() As List(Of Integer)
        Dim NumeroFilas As Integer = vwReporte.DataRowCount
        Dim lstRenglones As New List(Of Integer)
        Dim tblOriginal As DataTable = grdReporte.DataSource

        Try
            With vwReporte
                For index As Integer = 0 To NumeroFilas Step 1
                    If .GetRowCellValue(index, " ") Then
                        lstRenglones.Add(index)
                    End If

                Next
            End With
        Catch ex As Exception

        End Try
        Return lstRenglones
    End Function


    Private Sub accionFormulario(ByVal accionForm As String)
        Dim asignar As Boolean = True
        If obtenerRenglonesEditados.Count > 0 Then
            objConfirmar.mensaje = "Todos los datos no guardados se perderán ¿Desea continuar?"
            If objConfirmar.ShowDialog = DialogResult.OK Then
                asignar = True
            Else
                asignar = False
            End If
        End If
        If asignar Then
            If (cmbNaves.SelectedValue >= 0 And cmbNaves.Text <> "") Then
                'Dim tablaArticulos As New DataTable
                'tablaArticulos = grdReporte.DataSource()
                'tablaArticulos = tablaArticulos.Copy
                'tablaArticulos.Rows.Clear()
                Dim productoEstiloSeleccionados As String = String.Empty

                For i As Integer = 0 To vwReporte.RowCount Step 1
                    If vwReporte.GetRowCellValue(i, " ") Then
                        If productoEstiloSeleccionados <> "" Then
                            productoEstiloSeleccionados += ","
                        End If
                        'tablaArticulos.ImportRow(vwReporte.GetDataRow(i))
                        productoEstiloSeleccionados += vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(i), "ccna_productoestiloid").ToString()

                    End If
                Next

                ' If tablaArticulos.Rows.Count > 0 Then
                If productoEstiloSeleccionados <> "" Then
                    If accionForm = "Editar Articulos" Then
                        Dim tablaArticulos As New DataTable
                        tablaArticulos = grdReporte.DataSource()
                        tablaArticulos = tablaArticulos.Copy
                        tablaArticulos.Rows.Clear()

                        For i As Integer = 0 To vwReporte.RowCount Step 1
                            If vwReporte.GetRowCellValue(i, " ") Then
                                tablaArticulos.ImportRow(vwReporte.GetDataRow(i))
                            End If
                        Next

                        objArticulosForm = New Programacion_ColocacionSemanal_Configuracion_ArticulosForm
                        objArticulosForm.IdNaveSay = cmbNaves.SelectedValue
                        objArticulosForm.NombreNave = cmbNaves.Text
                        objArticulosForm.accionForm = accionForm
                        objArticulosForm.tabla = tablaArticulos
                        objArticulosForm.Show()
                        mostrarArticulosNave()
                    Else

                        objArticulosFormMovimientoColecciones = New Programacion_MovimientosPPCP_Articulos
                        objArticulosFormMovimientoColecciones.IdNaveSay = cmbNaves.SelectedValue
                        objArticulosFormMovimientoColecciones.NombreNave = cmbNaves.Text
                        objArticulosFormMovimientoColecciones.accionForm = accionForm
                        objArticulosFormMovimientoColecciones.ProductoEstiloSeleccionados = productoEstiloSeleccionados
                        If objArticulosFormMovimientoColecciones.ShowDialog() = DialogResult.OK Then
                            'btnMostrar_Click(Nothing, Nothing)
                        End If
                        'mostrarArticulosNave()
                    End If
                    'objArticulosForm = New Programacion_ColocacionSemanal_Configuracion_ArticulosForm


                    'If objArticulosForm.ShowDialog() = DialogResult.OK Then mostrarArticulosNave()

                Else
                    objAdvertencia.mensaje = "No se han seleccionado articulos."
                    objAdvertencia.ShowDialog()
                End If
            Else
                'objAdvertencia.mensaje = "Debe seleccionar una nave"
                'objAdvertencia.ShowDialog()
            End If
            Cursor = Cursors.Default
        End If
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

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        btnGuardar.Enabled = True
        lblGuardar.Enabled = True
        Dim asignar As Boolean = True
        If obtenerRenglonesEditados.Count > 0 Then
            objConfirmar.mensaje = "Todos los datos no guardados se perderán ¿Desea continuar?"
            If objConfirmar.ShowDialog = DialogResult.OK Then
                asignar = True
            Else
                asignar = False
            End If
        End If
        If asignar Then
            'If (cmbNaves.SelectedValue >= 0 And cmbNaves.Text <> "") Then
            'objArticulosForm = New Programacion_ColocacionSemanal_Configuracion_ArticulosForm
            objArticulosFormMovimientoColecciones = New Programacion_MovimientosPPCP_Articulos
            '  objArticulosForm.IdNaveSay = cmbNaves.SelectedValue
            objArticulosFormMovimientoColecciones.NombreNave = cmbNaves.Text
            objArticulosFormMovimientoColecciones.accionForm = "Asignar Articulos"
            objArticulosFormMovimientoColecciones.ShowDialog()
            'btnMostrar_Click(Nothing, Nothing)

            ' If objArticulosForm.ShowDialog() = DialogResult.OK Then mostrarArticulosNave()
            'Else
            'objAdvertencia.mensaje = "Debe seleccionar una nave"
            'objAdvertencia.ShowDialog()
            'End If
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
            If (continuar = True) Then mostrarArticulosNave()
            lblNumFiltrados.Text = CDbl(vwReporte.RowCount.ToString()).ToString("n0")
            lblUltimaActualizacion.Text = Date.Now
        Else
            'objAdvertencia.mensaje = "Debe seleccionar una nave"
            'objAdvertencia.ShowDialog()
            btnGuardar.Enabled = False
            lblGuardar.Enabled = False
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 30
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 161
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim lstRenglonesEditados As List(Of Integer)
        Try
            lstRenglonesEditados = obtenerRenglonesEditados()

            If lstRenglonesEditados.Count > 0 Then

                objConfirmar.mensaje = "¿Está seguro de actualizar los datos?"
                If objConfirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim obj As New Programacion_ArticuloNave_BU
                    Cursor = Cursors.WaitCursor

                    Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
                    For Each item In lstRenglonesEditados
                        Dim activo = 1
                        Dim prioridad = vwReporte.GetRowCellValue(item, "ccna_prioridad")
                        If (vwReporte.GetRowCellValue(item, "ccna_activo") = False) Then
                            activo = 0
                            prioridad = 0
                        End If
                        Dim vNodo As XElement = New XElement("Celda")
                        vNodo.Add(New XAttribute("NaveIdSAY", vwReporte.GetRowCellValue(item, "ccna_naveidsay")))
                        vNodo.Add(New XAttribute("ProductoEstiloId", vwReporte.GetRowCellValue(item, "ccna_productoestiloid")))
                        vNodo.Add(New XAttribute("Prioridad", prioridad))
                        vNodo.Add(New XAttribute("SiguienteFechaAsignar",
                                                 IIf(vwReporte.GetRowCellValue(item, "ccna_siguientefechaasignar") Is DBNull.Value,
                                                     "",
                                                     vwReporte.GetRowCellValue(item, "ccna_siguientefechaasignar"))))
                        vNodo.Add(New XAttribute("Activo", activo))
                        vNodo.Add(New XAttribute("UsuarioModificoId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                        vNodo.Add(New XAttribute("PrioridadActual", vwReporte.GetRowCellValue(item, "PrioridadOriginal")))
                        vXmlCeldasModificadas.Add(vNodo)
                    Next
                    obj.EditarPrioridadArticulos(vXmlCeldasModificadas.ToString(), radioActivo)
                    objExito.mensaje = "Datos guardados correctamente."
                    objExito.ShowDialog()
                    mostrarArticulosNave()
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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If obtenerRenglonesEditados().Count > 0 Then
            objConfirmar.mensaje = "Todos los datos no guardados se perderán ¿Desea continuar?"
            If objConfirmar.ShowDialog = DialogResult.OK Then Me.Dispose()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub vwReporte_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles vwReporte.CellValueChanged
        If vwReporte.GetRowCellValue(e.RowHandle, "ccna_prioridad") < 0 Then
            'Se entra a este if cuando el numero ingresado es menor a cero(lo de vuelve a su valor anterior)
            objAdvertencia.mensaje = "La prioridad debe ser mayor a 0"
            objAdvertencia.ShowDialog()
            vwReporte.SetRowCellValue(e.RowHandle, "ccna_prioridad", vwReporte.GetRowCellValue(e.RowHandle, "PrioridadOriginal"))
        End If
    End Sub

    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub vwReporte_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles vwReporte.RowCellStyle
        Dim view As GridView = sender
        If (view Is Nothing) Then Return
        If (e.RowHandle >= 0) Then
            Dim activoOriginal As Boolean = vwReporte.GetRowCellValue(e.RowHandle, "ActivoOriginal")
            Dim activoModificado As Boolean = vwReporte.GetRowCellValue(e.RowHandle, "ccna_activo")
            Dim prioridadOriginal As Integer = vwReporte.GetRowCellValue(e.RowHandle, "PrioridadOriginal")
            Dim prioridadModificado As Integer = IIf(vwReporte.GetRowCellValue(e.RowHandle, "ccna_prioridad") Is DBNull.Value, 0, vwReporte.GetRowCellValue(e.RowHandle, "ccna_prioridad"))
            Dim fechaOriginal As String = IIf(vwReporte.GetRowCellValue(e.RowHandle, "SiguienteFechaAsignarOriginal") Is DBNull.Value, "", vwReporte.GetRowCellValue(e.RowHandle, "SiguienteFechaAsignarOriginal"))
            Dim fechaModificado As String = IIf(vwReporte.GetRowCellValue(e.RowHandle, "ccna_siguientefechaasignar") Is DBNull.Value, "", vwReporte.GetRowCellValue(e.RowHandle, "ccna_siguientefechaasignar"))
            If activoOriginal <> activoModificado Then
                e.Appearance.ForeColor = Color.DarkViolet
            ElseIf e.Column.FieldName = "ccna_prioridad" Then
                If prioridadOriginal <> prioridadModificado Then e.Appearance.ForeColor = Color.DarkViolet
            ElseIf e.Column.FieldName = "ccna_siguientefechaasignar" Or e.Column.FieldName = "ccna_siguientesemanaasignar" Then
                If fechaOriginal <> fechaModificado Then e.Appearance.ForeColor = Color.DarkViolet
            End If
        End If
    End Sub
    Private Sub Programacion_ColocacionSemanal_Configuracion_NaveArticuloForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.Location = New Point(0, 0)
        Me.WindowState = FormWindowState.Maximized
        cmbNaves = Controles.ComboNavesSegunUsuario(cmbNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub Programacion_ColocacionSemanal_Configuracion_NaveArticuloForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If obtenerRenglonesEditados().Count > 0 Then
            objConfirmar.mensaje = "Todos los datos no guardados se perderán ¿Desea continuar?"
            If objConfirmar.ShowDialog <> DialogResult.OK Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub rdbActivo_CheckedChanged(sender As Object, e As EventArgs)
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
                grdReporteOriginal.DataSource = Nothing
                vwReporteOriginal.Columns.Clear()
            End If
            eventoActivo = False
        End If
    End Sub

    Private Sub rdbInactivo_CheckedChanged(sender As Object, e As EventArgs)
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
                grdReporteOriginal.DataSource = Nothing
                vwReporteOriginal.Columns.Clear()
            End If
            eventoActivo = False
        End If
    End Sub

    Private Sub chkActivarInactivar_CheckedChanged(sender As Object, e As EventArgs) Handles chkActivarInactivar.CheckedChanged
        Dim activar = False
        If (chkActivarInactivar.Checked) Then
            activar = True
        End If
        If (eventoActivo = False) Then
            eventoActivo = True
            For i As Integer = 0 To (vwReporte.RowCount) Step 1
                vwReporte.SetRowCellValue(i, "ccna_activo", activar)
                If (activar = False) Then
                    vwReporte.SetRowCellValue(i, "ccna_prioridad", 0)
                Else
                    vwReporte.SetRowCellValue(i, "ccna_prioridad", vwReporteOriginal.GetRowCellValue(i, "ccna_prioridad"))
                End If
            Next
            eventoActivo = False
        End If
    End Sub

    Private Sub btnDesasignar_Click(sender As Object, e As EventArgs) Handles btnDesasignar.Click
        btnGuardar.Enabled = True
        lblGuardar.Enabled = True
        Dim Desasignar As Boolean = True
        If obtenerRenglonesEditados.Count > 0 Then
            objConfirmar.mensaje = "Todos los datos no guardados se perderán ¿Desea continuar?"
            If objConfirmar.ShowDialog = DialogResult.OK Then
                Desasignar = True
            Else
                Desasignar = False
            End If
        End If
        If Desasignar Then
            'If (cmbNaves.SelectedValue >= 0 And cmbNaves.Text <> "") Then
            'objArticulosForm = New Programacion_ColocacionSemanal_Configuracion_ArticulosForm
            objArticulosFormMovimientoColecciones = New Programacion_MovimientosPPCP_Articulos
            '  objArticulosForm.IdNaveSay = cmbNaves.SelectedValue
            objArticulosFormMovimientoColecciones.NombreNave = cmbNaves.Text
            objArticulosFormMovimientoColecciones.accionForm = "Desasignar Articulos"
            objArticulosFormMovimientoColecciones.ShowDialog()
            ' btnMostrar_Click(Nothing, Nothing)

            'If objArticulosForm.ShowDialog() = DialogResult.OK Then mostrarArticulosNave()
            'Else
            'objAdvertencia.mensaje = "Debe seleccionar una nave"
            'objAdvertencia.ShowDialog()
            'End If
            Cursor = Cursors.Default
        End If

    End Sub

    Private Sub btnTransferir_Click(sender As Object, e As EventArgs) Handles btnTransferir.Click
        btnGuardar.Enabled = True
        lblGuardar.Enabled = True
        Dim Transferir As Boolean = True
        If obtenerRenglonesEditados.Count > 0 Then
            objConfirmar.mensaje = "Todos los datos no guardados se perderán ¿Desea continuar?"
            If objConfirmar.ShowDialog = DialogResult.OK Then
                Transferir = True
            Else
                Transferir = False
            End If
        End If
        If Transferir Then
            'If (cmbNaves.SelectedValue >= 0 And cmbNaves.Text <> "") Then
            'objArticulosForm = New Programacion_ColocacionSemanal_Configuracion_ArticulosForm
            objArticulosFormMovimientoColecciones = New Programacion_MovimientosPPCP_Articulos
            '  objArticulosForm.IdNaveSay = cmbNaves.SelectedValue
            objArticulosFormMovimientoColecciones.NombreNave = cmbNaves.Text
            objArticulosFormMovimientoColecciones.accionForm = "Transferir Articulos"
            objArticulosFormMovimientoColecciones.ShowDialog()
            'btnMostrar_Click(Nothing, Nothing)

            ' If objArticulosForm.ShowDialog() = DialogResult.OK Then mostrarArticulosNave()
            'Else
            'objAdvertencia.mensaje = "Debe seleccionar una nave"
            'objAdvertencia.ShowDialog()
            'End If
            Cursor = Cursors.Default
        End If


    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        accionFormulario("Editar Articulos")
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        Dim activar = False
        If (chkSeleccionarTodo.Checked) Then
            activar = True
        End If
        If (eventoActivo = False) Then
            eventoActivo = True
            For i As Integer = 0 To (vwReporte.RowCount) Step 1
                vwReporte.SetRowCellValue(i, " ", activar)
            Next
            eventoActivo = False
        End If
    End Sub

    Private Sub btnAsignarFecha_Click(sender As Object, e As EventArgs)
        'Dim lstRenglonesSeleccionados As List(Of Integer)
        'lstRenglonesSeleccionados = obtenerRenglonesSeleccionados()
        'Dim fecha As Date = dtpSiguienteFecha.Value.ToShortDateString()

        'If lstRenglonesSeleccionados.Count > 0 Then
        '    For Each item In lstRenglonesSeleccionados
        '        With vwReporte
        '            .SetRowCellValue(item, "ccna_siguientefechaasignar", fecha)
        '            .SetRowCellValue(item, "ccna_siguientesemanaasignar", DatePart("ww", fecha))
        '        End With
        '    Next
        'Else
        '    objAdvertencia.mensaje = "No hay filas seleccionadas."
        '    objAdvertencia.ShowDialog()
        'End If
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        menuAyudaReportes.Show(btnAyuda, 0, btnAyuda.Height)
    End Sub

    Private Sub ManualDeUsuarioMovimientosColeccionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManualDeUsuarioMovimientosColeccionesToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/PPCP/", "Descargas\Manuales\PPCP", "COVE_MAUS_MovimientosColecciones.pdf")
            Process.Start("Descargas\Manuales\PPCP\COVE_MAUS_MovimientosColecciones.pdf")
        Catch ex As Exception

        End Try
    End Sub
End Class