Imports System.Drawing
Imports System.Windows.Forms
Imports Framework.Negocios
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class CatalogoTablasSubsidioEmpleoForm

    Private Sub CatalogoTablasSubsidioEmpleoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        validaPermisos()
        cmbTipo.Text = "SEMANAL"
    End Sub

    Private Sub validaPermisos()
        pnlAltas.Visible = PermisosUsuarioBU.ConsultarPermiso("TABLAS_SPE", "ALTA")
        pnlDesactivar.Visible = PermisosUsuarioBU.ConsultarPermiso("TABLAS_SPE", "DESACTIVAR")
        pnlEditar.Visible = PermisosUsuarioBU.ConsultarPermiso("TABLAS_SPE", "EDITAR")
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        cargarDatos()
    End Sub

    Private Sub cargarDatos()
        Dim tipo As String = String.Empty
        Dim activo As Boolean = True
        Dim objBu As New Negocios.TablasSPEBU

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        tipo = cmbTipo.Text
        activo = rdoActivo.Checked

        Dim dtSPe As New DataTable
        dtSPe = objBu.consultarTablaSPE(cmbTipo.Text, rdoActivo.Checked)

        If Not dtSPe Is Nothing AndAlso dtSPe.Rows.Count > 0 Then
            grdTablaSPE.DataSource = Nothing
            grdTablaSPE.DataSource = dtSPe
            formatoGrid()
        Else
            Dim mensajeAdv As New Tools.AdvertenciaForm
            mensajeAdv.mensaje = "No se encontró información."
            mensajeAdv.Show()
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub formatoGrid()
        grdTablaSPE.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        With grdTablaSPE.DisplayLayout.Bands(0)

            .Columns("subsidioid").Hidden = True
            .Columns("fechamodificacion").Hidden = rdoActivo.Checked
            .Columns("Estatus").Hidden = True

            .Columns("Seleccion").Header.Caption = "Selección"
            .Columns("limiteinferior").Header.Caption = "Límite Inferior"
            .Columns("limitesuperior").Header.Caption = "Límite Superior"
            .Columns("spemensual").Header.Caption = "Subsidio"
            .Columns("tipo").Header.Caption = "Tipo"
            .Columns("fechamodificacion").Header.Caption = "Fecha Inactivación"

            .Columns("limiteinferior").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("limitesuperior").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("spemensual").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("tipo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fechamodificacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Estatus").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("limiteinferior").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("limitesuperior").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("spemensual").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("limiteinferior").Format = "###,###,##0.00"
            .Columns("limitesuperior").Format = "###,###,##0.00"
            .Columns("spemensual").Format = "###,###,##0.00"

            .Columns("Seleccion").Header.VisiblePosition = 0
            .Columns("Seleccion").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

            .Columns("Seleccion").AllowRowFiltering = DefaultableBoolean.False

            grdTablaSPE.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Columns("Seleccion").Width = 45

        End With

        grdTablaSPE.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdTablaSPE.DisplayLayout.Override.RowSelectorWidth = 35
        grdTablaSPE.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdTablaSPE.Rows(0).Selected = True

        grdTablaSPE.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Private Sub grdTablaSPE_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdTablaSPE.InitializeLayout
        Me.grdTablaSPE.DisplayLayout.Override.HeaderCheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor
        Me.grdTablaSPE.DisplayLayout.Override.HeaderCheckBoxAlignment = HeaderCheckBoxAlignment.Right
        Me.grdTablaSPE.DisplayLayout.Override.HeaderCheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim objForm As New AltaEdicion_TablasSPEForm
        If Not CheckForm(objForm) Then

            Dim formaAltas As New AltaEdicion_TablasSPEForm
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

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim seleccion As Integer = 0
        Dim msjAdv As New Tools.AdvertenciaForm

        For Each rowSel As UltraGridRow In grdTablaSPE.Rows
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
            Dim idSubsidio As Integer = 0

            For Each row As UltraGridRow In grdTablaSPE.Rows
                If CBool(row.Cells("Seleccion").Value) = True Then
                    idSubsidio = CInt(row.Cells("subsidioid").Value)
                End If
            Next

            If idSubsidio > 0 Then
                Dim objForm As New AltaEdicion_TablasSPEForm
                If Not CheckForm(objForm) Then

                    Dim formaAltas As New AltaEdicion_TablasSPEForm
                    formaAltas.editar = True
                    formaAltas.idsubsidio = idSubsidio
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

    Private Sub btndesactivar_Click(sender As Object, e As EventArgs) Handles btndesactivar.Click
        Dim seleccion As Integer = 0
        Dim msjAdv As New Tools.AdvertenciaForm
        Dim idDesactivar As Integer = 0
        Dim desactivados As Integer = 0

        For Each rowSel As UltraGridRow In grdTablaSPE.Rows
            If CBool(rowSel.Cells("Seleccion").Value) = True Then
                seleccion += 1
            End If
        Next

        If seleccion = 0 Then
            msjAdv.mensaje = "Debe seleccionar un registro para editar."
            msjAdv.Show()
        ElseIf seleccion > 0 Then
            Dim objBu As New Negocios.TablasSPEBU
            For Each row As UltraGridRow In grdTablaSPE.Rows
                If CBool(row.Cells("Seleccion").Value) = True Then
                    idDesactivar = CInt(row.Cells("subsidioid").Value)
                    If objBu.desactivarSubsidio(idDesactivar) = "EXITO" Then
                        desactivados += 1
                    End If
                End If
            Next

            If desactivados = seleccion Then
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

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        rdoActivo.Checked = True
        grdTablaSPE.DataSource = Nothing
        cmbTipo.Text = "SEMANAL"
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbFiltros.Visible = False
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbFiltros.Visible = True
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel()
    End Sub

    Private Sub exportarExcel()
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm

        If grdTablaSPE.Rows.Count > 0 Then
            Try
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

                        archivo = "Tablas_SPE_" & fecha_hora & ".xlsx"

                        grdTablaSPE.DisplayLayout.Bands(0).Columns("Seleccion").Hidden = True
                        grdTablaSPE.DisplayLayout.Bands(0).Columns("Estatus").Hidden = False
                        UltraGridExcelExporter1.Export(grdTablaSPE, .SelectedPath & "\" & archivo)

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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged, rdoInactivo.CheckedChanged
        cargarDatos()

        If pnlDesactivar.Visible Then
            pnlDesactivar.Enabled = rdoActivo.Checked
        End If
    End Sub

    Private Sub UltraGridExcelExporter1_InitializeColumn(sender As Object, e As ExcelExport.InitializeColumnEventArgs) Handles UltraGridExcelExporter1.InitializeColumn
        e.ExcelFormatStr = e.Column.Format
    End Sub
End Class