Imports System.Drawing
Imports System.Windows.Forms
Imports Framework.Negocios
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class CatalogoTablasTarifasForm

    Private Sub CatalogoTablasTarifasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        validaPermisos()
        cmbTipo.Text = "SEMANAL"
    End Sub

    Private Sub validaPermisos()
        pnlAltas.Visible = PermisosUsuarioBU.ConsultarPermiso("NF_TARIFAS", "ALTA")
        pnlDesactivar.Visible = PermisosUsuarioBU.ConsultarPermiso("NF_TARIFAS", "DESACTIVAR")
        pnlEditar.Visible = PermisosUsuarioBU.ConsultarPermiso("NF_TARIFAS", "EDITAR")
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        cargarDatos()
    End Sub

    Public Sub cargarDatos()
        Dim advertencia As New AdvertenciaForm
        Dim tipo As String = String.Empty
        Dim activo As Boolean = True

        Dim objBu As New Negocios.TablasTarifasBU
        Dim dtColaboAlta As New DataTable

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        tipo = cmbTipo.Text
        activo = rdoActivo.Checked

        dtColaboAlta = objBu.consultaTarifas(tipo, activo)

        If Not dtColaboAlta Is Nothing Then
            If dtColaboAlta.Rows.Count > 0 Then
                grdTarifas.DataSource = Nothing
                grdTarifas.DataSource = dtColaboAlta
                formatoGrid()
            End If
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Public Sub formatoGrid()
        grdTarifas.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        With grdTarifas.DisplayLayout.Bands(0)

            .Columns("tarifaid").Hidden = True
            .Columns("fechamodificacion").Hidden = rdoActivo.Checked
            .Columns("Estatus").Hidden = True

            .Columns("Seleccion").Header.Caption = "Selección"
            .Columns("liminferior").Header.Caption = "Límite Inferior"
            .Columns("limsuperior").Header.Caption = "Límite Superior"
            .Columns("cuotafija").Header.Caption = "Cuota Fija"
            .Columns("tipo").Header.Caption = "Tipo"
            .Columns("fechamodificacion").Header.Caption = "Fecha Inactivación"
            .Columns("excedente").Header.Caption = "% Excedente"


            .Columns("liminferior").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("limsuperior").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("cuotafija").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("tipo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fechamodificacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("excedente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit


            .Columns("liminferior").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("limsuperior").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("cuotafija").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("excedente").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center

            .Columns("liminferior").Format = "###,###,##0.00"
            .Columns("limsuperior").Format = "###,###,##0.00"
            .Columns("cuotafija").Format = "###,###,##0.00"
            .Columns("excedente").Format = "P"

            .Columns("Seleccion").Header.VisiblePosition = 0
            .Columns("Seleccion").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

            .Columns("Seleccion").AllowRowFiltering = DefaultableBoolean.False

            grdTarifas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Columns("Seleccion").Width = 45


            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

        End With

        'grdTarifas.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdTarifas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdTarifas.DisplayLayout.Override.RowSelectorWidth = 35
        grdTarifas.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdTarifas.Rows(0).Selected = True

        grdTarifas.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub
    Private Sub grdRecibos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdTarifas.InitializeLayout
        Me.grdTarifas.DisplayLayout.Override.HeaderCheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor
        Me.grdTarifas.DisplayLayout.Override.HeaderCheckBoxAlignment = HeaderCheckBoxAlignment.Right
        Me.grdTarifas.DisplayLayout.Override.HeaderCheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbFiltros.Visible = False
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbFiltros.Visible = True
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim objForm As New AltaEdicion_TablasTarifasForm
        If Not CheckForm(objForm) Then

            Dim formaAltas As New AltaEdicion_TablasTarifasForm
            formaAltas.editar = False
            formaAltas.ShowDialog()

            If formaAltas.guardado Then
                cargarDatos()
            End If
        End If
    End Sub

    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Sub btndesactivar_Click(sender As Object, e As EventArgs) Handles btndesactivar.Click
        Dim seleccion As Integer = 0
        Dim msjAdv As New Tools.AdvertenciaForm
        Dim tarifaDesactivar As Integer = 0
        Dim desactivadas As Integer = 0

        For Each rowSel As UltraGridRow In grdTarifas.Rows
            If CBool(rowSel.Cells("Seleccion").Value) = True Then
                seleccion += 1
            End If
        Next

        If seleccion = 0 Then
            msjAdv.mensaje = "Debe seleccionar un registro para editar."
            msjAdv.Show()
        ElseIf seleccion > 0 Then
            Dim objBu As New Negocios.TablasTarifasBU
            For Each row As UltraGridRow In grdTarifas.Rows
                If CBool(row.Cells("Seleccion").Value) = True Then
                    tarifaDesactivar = CInt(row.Cells("tarifaid").Value)
                    If objBu.desactivarTarifas(tarifaDesactivar) = "EXITO" Then
                        desactivadas += 1
                    End If
                End If
            Next

            If desactivadas = seleccion Then
                Dim mensajeExito As New Tools.ExitoForm
                mensajeExito.mensaje = "Se desactivaron los registros correctamente."
                mensajeExito.Show()
            Else
                Dim mensajeError As New Tools.ErroresForm
                mensajeError.mensaje = "Algunos registros no fueron desactivados."
                mensajeError.Show()
            End If

            cargarDatos()
        End If

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel()
    End Sub

    Private Sub exportarExcel()
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm

        If grdTarifas.Rows.Count > 0 Then
            Try
                'Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
                Dim fbdUbicacionArchivo As New FolderBrowserDialog
                Dim archivo As String = String.Empty

                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    If ret = Windows.Forms.DialogResult.OK Then

                        Dim fecha_hora As String = Date.Now.ToString("yyyyMMdd_Hmmss")

                        archivo = "Tablas_y_Tarifas_" & fecha_hora & ".xlsx"

                        grdTarifas.DisplayLayout.Bands(0).Columns("Seleccion").Hidden = True
                        grdTarifas.DisplayLayout.Bands(0).Columns("Estatus").Hidden = False
                        'gridExcelExporter.Export(grdTarifas, .SelectedPath & "\" & archivo)
                        Me.UltraGridExcelExporter1.Export(grdTarifas, .SelectedPath & "\" & archivo)

                        cargarDatos()

                        objMensajeExito.mensaje = "Los datos se exportaron correctamente al archivo " & archivo
                        objMensajeExito.ShowDialog()
                        Try
                            Process.Start(.SelectedPath & "\" & archivo)
                        Catch ex As Exception
                        End Try

                    End If
                    .Dispose()
                End With

            Catch ex As Exception
                objMensajeError.mensaje = "Error al exportar."
                objMensajeError.ShowDialog()
            Finally
                cargarDatos()
            End Try
        Else
            objMensajeAdv.mensaje = "No hay información para exportar."
            objMensajeAdv.ShowDialog()
        End If

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim seleccion As Integer = 0
        Dim msjAdv As New Tools.AdvertenciaForm

        For Each rowSel As UltraGridRow In grdTarifas.Rows
            If CBool(rowSel.Cells("Seleccion").Value) = True Then
                seleccion += 1
            End If

        Next

        If seleccion = 0 Then
            msjAdv.mensaje = "Debe seleccionar un registro para editar."
            msjAdv.Show()
        ElseIf seleccion > 1 Then
            msjAdv.mensaje = "Debe seleccionar solamente un registro para editar."
            msjAdv.Show()
        Else
            Dim idTarifa As Integer = 0

            For Each row As UltraGridRow In grdTarifas.Rows
                If CBool(row.Cells("Seleccion").Value) = True Then
                    idTarifa = CInt(row.Cells("tarifaid").Value)
                End If
            Next

            If idTarifa > 0 Then
                Dim objForm As New AltaEdicion_TablasTarifasForm
                If Not CheckForm(objForm) Then

                    Dim formaAltas As New AltaEdicion_TablasTarifasForm
                    formaAltas.editar = True
                    formaAltas.idtarifa = idTarifa
                    formaAltas.ShowDialog()

                    If formaAltas.guardado Then
                        Dim msjExito As New Tools.ExitoForm
                        msjExito.mensaje = "Se guardó correctamente la información."
                        msjExito.Show()
                        cargarDatos()
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged, rdoInactivo.CheckedChanged
        If sender.Checked Then
            cargarDatos()
        End If

        If pnlDesactivar.Visible Then
            pnlDesactivar.Enabled = rdoActivo.Checked
        End If

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        rdoActivo.Checked = True
        grdTarifas.DataSource = Nothing
        cmbTipo.Text = "SEMANAL"
    End Sub

    Private Sub UltraGridExcelExporter1_InitializeColumn(sender As Object, e As ExcelExport.InitializeColumnEventArgs) Handles UltraGridExcelExporter1.InitializeColumn
        If e.Column.Index = 5 Then
            e.ExcelFormatStr = " 0.00'%"
        Else
            e.ExcelFormatStr = e.Column.Format
        End If

    End Sub
End Class