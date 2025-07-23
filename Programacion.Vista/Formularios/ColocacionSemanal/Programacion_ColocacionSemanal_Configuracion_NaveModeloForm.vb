Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Programacion.Negocios
Imports Tools

Public Class Programacion_ColocacionSemanal_Configuracion_NaveModeloForm
    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objConfirmar As New Tools.ConfirmarForm
    Dim dtDatosNaves As New DataTable
    Dim objModelosForm As Programacion_ColocacionSemanal_Configuracion_ModelosForm
    Dim radioActivo As Integer
    Dim eventoActivo As Boolean = False
    Public Sub disenioGrid()
        vwReporte.OptionsView.ColumnAutoWidth = True
        vwReporte.OptionsView.EnableAppearanceEvenRow = True
        vwReporte.OptionsCustomization.AllowSort = True
        vwReporte.OptionsCustomization.AllowFilter = True
        'vwReporte.IndicatorWidth = 30
        vwReporte.OptionsView.ShowAutoFilterRow = True
        vwReporte.OptionsView.RowAutoHeight = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If (col.FieldName <> "Equivalencia" And col.FieldName <> " ") Then
                col.OptionsColumn.AllowEdit = False
            End If

        Next

        vwReporte.OptionsFilter.AllowFilterEditor = True
        vwReporte.Columns.ColumnByFieldName("ccna_naveidsay").Visible = False
        vwReporte.Columns.ColumnByFieldName("EquivalenciaOriginal").Visible = False

        vwReporte.BestFitColumns()

        If (radioActivo = 1) Then
            vwReporte.OptionsBehavior.Editable = True
            vwReporte.Columns.ColumnByFieldName("Equivalencia").Caption = "* Equivalencia"
        Else
            vwReporte.Columns.ColumnByFieldName("Equivalencia").OptionsColumn.AllowEdit = False
        End If

    End Sub
    Private Sub mostrarModelosNave()
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Programacion_ModeloNave_BU
            Dim dtConsultaModelos As New DataTable
            grdReporteOriginal.DataSource = Nothing
            grdReporte.DataSource = Nothing
            vwReporteOriginal.Columns.Clear()
            vwReporte.Columns.Clear()
            dtConsultaModelos = obj.ConsultarModelosAsignadosPorNave(cmbNaves.SelectedValue, radioActivo)
            If dtConsultaModelos.Rows.Count > 0 Then
                grdReporte.DataSource = dtConsultaModelos
                grdReporteOriginal.DataSource = dtConsultaModelos.Copy
                disenioGrid()
                chkSeleccionar.Checked = False
            Else
                btnGuardar.Enabled = False
                lblGuardar.Enabled = False
                objAdvertencia.mensaje = "No existen datos registrados."
                objAdvertencia.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
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
                    Dim EquivalenciaOriginal As String = .GetRowCellValue(index, "EquivalenciaOriginal").ToString
                    Dim prioridadModificado As String = .GetRowCellValue(index, "Equivalencia").ToString
                    If EquivalenciaOriginal <> prioridadModificado Then
                        lstRenglonesEditados.Add(index)
                    End If

                Next
            End With
        Catch ex As Exception

        End Try
        Return lstRenglonesEditados
    End Function

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
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
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo")
        End Try
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
            If (continuar = True) Then mostrarModelosNave()
        Else
            objAdvertencia.mensaje = "Debe seleccionar una nave"
            objAdvertencia.ShowDialog()
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
                    Dim obj As New Programacion_ModeloNave_BU
                    Cursor = Cursors.WaitCursor

                    Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
                    For Each item In lstRenglonesEditados
                        Dim activo = 1
                        Dim equivalencia = vwReporte.GetRowCellValue(item, "Equivalencia")
                        Dim vNodo As XElement = New XElement("Celda")
                        vNodo.Add(New XAttribute("NaveIdSAY", vwReporte.GetRowCellValue(item, "ccna_naveidsay")))
                        vNodo.Add(New XAttribute("ModeloIdSay", vwReporte.GetRowCellValue(item, "ModeloSAY")))
                        vNodo.Add(New XAttribute("Equivalencia", equivalencia))
                        vNodo.Add(New XAttribute("UsuarioModificoId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                        vXmlCeldasModificadas.Add(vNodo)
                    Next
                    obj.EditarModelosAsignadosPorNave(vXmlCeldasModificadas.ToString())
                    objExito.mensaje = "Datos guardados correctamente."
                    objExito.ShowDialog()
                    mostrarModelosNave()
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
        If (IIf(vwReporte.GetRowCellValue(e.RowHandle, "Equivalencia") Is DBNull.Value, 0, vwReporte.GetRowCellValue(e.RowHandle, "Equivalencia")) < 0) Then
            'Se entra a este if cuando el numero ingresado es menor a cero(lo de vuelve a su valor anterior)
            objAdvertencia.mensaje = "La prioridad debe ser mayor a 0"
            objAdvertencia.ShowDialog()
            vwReporte.SetRowCellValue(e.RowHandle, "Equivalencia", vwReporte.GetRowCellValue(e.RowHandle, "EquivalenciaOriginal"))
        End If
    End Sub

    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub Programacion_ColocacionSemanal_Configuracion_NaveModeloForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.Location = New Point(0, 0)
        Me.WindowState = FormWindowState.Maximized
        cmbNaves = Controles.ComboNavesSegunUsuario(cmbNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub Programacion_ColocacionSemanal_Configuracion_NaveModeloForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If obtenerRenglonesEditados().Count > 0 Then
            objConfirmar.mensaje = "Todos los datos no guardados se perderán ¿Desea continuar?"
            If objConfirmar.ShowDialog <> DialogResult.OK Then
                e.Cancel = True
            End If
        End If
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
                grdReporteOriginal.DataSource = Nothing
                vwReporteOriginal.Columns.Clear()
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
                grdReporteOriginal.DataSource = Nothing
                vwReporteOriginal.Columns.Clear()
            End If
            eventoActivo = False
        End If
    End Sub

    Private Sub chkActivarInactivar_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged
        Dim activar = False
        If (chkSeleccionar.Checked) Then
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

    Private Sub vwReporte_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles vwReporte.RowCellStyle
        Dim view As GridView = sender
        If (view Is Nothing) Then Return
        If (e.RowHandle >= 0) Then
            Dim EquivalenciaOriginal As Integer = IIf(vwReporte.GetRowCellValue(e.RowHandle, "EquivalenciaOriginal") Is DBNull.Value, 0, vwReporte.GetRowCellValue(e.RowHandle, "EquivalenciaOriginal"))
            Dim prioridadModificado As Integer = IIf(vwReporte.GetRowCellValue(e.RowHandle, "Equivalencia") Is DBNull.Value, 0, vwReporte.GetRowCellValue(e.RowHandle, "Equivalencia"))
            If e.Column.FieldName = "Equivalencia" Then
                If EquivalenciaOriginal <> prioridadModificado Then e.Appearance.ForeColor = Color.DarkViolet
            End If
        End If
    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        If vwReporte.RowCount > 0 Then
            Dim objModelosForm As New Programacion_ColocacionSemanal_Configuracion_ModelosForm
            Dim tablaModelos As New DataTable
            tablaModelos = grdReporte.DataSource()
            tablaModelos = tablaModelos.Copy
            tablaModelos.Rows.Clear()
            For i As Integer = 0 To vwReporte.RowCount Step 1
                If vwReporte.GetRowCellValue(i, " ") Then
                    tablaModelos.ImportRow(vwReporte.GetDataRow(i))
                End If
            Next
            If tablaModelos.Rows.Count > 0 Then
                objModelosForm.tabla = tablaModelos
                If objModelosForm.ShowDialog() = DialogResult.OK Then mostrarModelosNave()
            Else
                objAdvertencia.mensaje = "No se ha seleccionado ningún modelo"
                objAdvertencia.ShowDialog()
            End If
        Else
            objAdvertencia.mensaje = "No existen información."
            objAdvertencia.ShowDialog()
        End If
    End Sub
End Class