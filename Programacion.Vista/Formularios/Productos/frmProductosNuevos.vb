Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmProductosNuevos
    Public Sub exportarExcel(ByVal grd As UltraGrid)
        Dim sfd As New SaveFileDialog
        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                exportExcelDetalle.Export(grd, fileName)
                Process.Start(fileName)
                Me.Cursor = Cursors.Default

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try
        End If
    End Sub


    Public Function validarFecha() As Boolean
        If dttFecha.Value.ToShortDateString < Date.Today Then
            Return False
        End If
        Return True
    End Function

    Public Sub guardarProductosNuevos()
        If validarFecha() = True Then
            Dim objBu As New Negocios.productosCapacidadBU
            Dim guardo As Boolean = False
            For Each rowGrd As UltraGridRow In grdProductosDisponibles.Rows
                If CBool(rowGrd.Cells("Sel").Value) = True Then
                    objBu.guardarProductoNuevo(rowGrd.Cells("idEst").Value, cmbNaves.SelectedValue, dttFecha.Value.ToShortDateString)
                    guardo = True
                End If
            Next
            If guardo = False Then
                Dim objMAdv As New Tools.AdvertenciaForm
                objMAdv.mensaje = "Seleccione al menos un artículo"
                objMAdv.ShowDialog()
            Else
                llenarTablaTodosLosArticulo()
                Dim objMAdv As New Tools.ExitoForm
                objMAdv.mensaje = "Registro exitoso"
                objMAdv.ShowDialog()
            End If
        Else
            Dim objMAdv As New Tools.AdvertenciaForm
            objMAdv.mensaje = "Seleccione una fecha valida"
            objMAdv.ShowDialog()
        End If
    End Sub

    Public Sub quitarProductosNuevos()
        If validarFecha() = True Then
            Dim objBu As New Negocios.productosCapacidadBU
            Dim guardo As Boolean = False
            For Each rowGrd As UltraGridRow In grdProductosNuevos.Rows
                If CBool(rowGrd.Cells("Sel").Value) = True Then
                    objBu.inactivarRegistroProductoNuevo(rowGrd.Cells("prnv_productonuevoid").Value)
                    guardo = True
                End If
            Next
            If guardo = False Then
                Dim objMAdv As New Tools.AdvertenciaForm
                objMAdv.mensaje = "Seleccione al menos un artículo"
                objMAdv.ShowDialog()
            Else
                llenarTablaTodosLosArticulo()
                Dim objMAdv As New Tools.ExitoForm
                objMAdv.mensaje = "Registro exitoso"
                objMAdv.ShowDialog()
            End If
        Else
            Dim objMAdv As New Tools.AdvertenciaForm
            objMAdv.mensaje = "Seleccione una fecha valida"
            objMAdv.ShowDialog()
        End If
    End Sub

    Public Sub cambiarFechaProductosNuevos()
        If validarFecha() = True Then
            Dim objBu As New Negocios.productosCapacidadBU
            Dim guardo As Boolean = False
            For Each rowGrd As UltraGridRow In grdProductosNuevos.Rows
                If CBool(rowGrd.Cells("Sel").Value) = True Then
                    objBu.cambiarFechaRegistroProductoNuevo(rowGrd.Cells("prnv_productonuevoid").Value, dttFecha.Value.ToString)
                    guardo = True
                End If
            Next
            If guardo = False Then
                Dim objMAdv As New Tools.AdvertenciaForm
                objMAdv.mensaje = "Seleccione al menos un artículo"
                objMAdv.ShowDialog()
            Else

                grdProductosNuevos.DataSource = Nothing
                Dim dtArtsNuevos As New DataTable
                If cmbNaves.SelectedIndex > 0 Then
                    dtArtsNuevos = objBu.consultaProductosNuevosAsignados(cmbNaves.SelectedValue)
                Else
                    dtArtsNuevos = objBu.consultaProductosNuevosAsignados(0)
                End If

                If dtArtsNuevos.Rows.Count > 0 Then
                    grdProductosNuevos.DataSource = dtArtsNuevos
                    formatoGridTablaProductosNuevos()
                End If

                Dim objMAdv As New Tools.ExitoForm
                objMAdv.mensaje = "Registro exitoso"
                objMAdv.ShowDialog()
            End If
        Else
            Dim objMAdv As New Tools.AdvertenciaForm
            objMAdv.mensaje = "Seleccione una fecha valida"
            objMAdv.ShowDialog()
        End If
    End Sub


    Public Sub llenarTablaTodosLosArticulo()
        grdProductosDisponibles.DataSource = Nothing
        grdProductosNuevos.DataSource = Nothing
        Dim objBU As New Negocios.productosCapacidadBU
        Dim dtArtsNOAsignados As New DataTable
        Dim dtArtsNuevos As New DataTable

        If cmbNaves.SelectedIndex > 0 Then
            dtArtsNOAsignados = objBU.consultaProductosNuevosNoAsignados(cmbNaves.SelectedValue)
            dtArtsNuevos = objBU.consultaProductosNuevosAsignados(cmbNaves.SelectedValue)

            If dtArtsNOAsignados.Rows.Count > 0 Then
                grdProductosDisponibles.DataSource = dtArtsNOAsignados
                formatoGridTablaArticulos()
            End If

            If dtArtsNuevos.Rows.Count > 0 Then
                grdProductosNuevos.DataSource = dtArtsNuevos
                formatoGridTablaProductosNuevos()
            End If
            pnlPasarArticulos.Enabled = True
        Else
            dtArtsNuevos = objBU.consultaProductosNuevosAsignados(0)
            If dtArtsNuevos.Rows.Count > 0 Then
                grdProductosNuevos.DataSource = dtArtsNuevos
                formatoGridTablaProductosNuevos()
            End If
            pnlPasarArticulos.Enabled = False
        End If

    End Sub



    Public Sub formatoGridTablaArticulos()

        Dim band As UltraGridBand = Me.grdProductosDisponibles.DisplayLayout.Bands(0)


        With grdProductosDisponibles.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
            .Columns("idEst").Hidden = True
            .Columns("idMarca").Hidden = True
            .Columns("idColeccion").Hidden = True
            .Columns("idTemporada").Hidden = True
            .Columns("idPiel").Hidden = True
            .Columns("idColor").Hidden = True
            .Columns("idTalla").Hidden = True
            .Columns("idFamilia").Hidden = True
            .Columns("idHorma").Hidden = True
            .Columns("idFamilia").Hidden = True
            .Columns("pres_activo").Hidden = True
            .Columns("temporada").Hidden = True
            .Columns("psEstatus").Hidden = True
            .Columns("fechaCreo").Hidden = True

            .Columns("Sel").Header.Caption = ""
            .Columns("codSICY").Header.Caption = "Cod. SICY"
            .Columns("Marca").Header.Caption = "Marca"
            .Columns("coleccion").Header.Caption = "Colección"
            .Columns("pielColor").Header.Caption = "Piel-Color"
            .Columns("coleccion").Header.Caption = "Colección"
            .Columns("talla").Header.Caption = "Talla"
            .Columns("Horma").Header.Caption = "Horma"
            .Columns("nomSts").Header.Caption = "Estatus"

            .Columns("SAY").CellActivation = Activation.NoEdit
            .Columns("SICY").CellActivation = Activation.NoEdit
            .Columns("codSICY").CellActivation = Activation.NoEdit
            .Columns("Marca").CellActivation = Activation.NoEdit
            .Columns("coleccion").CellActivation = Activation.NoEdit
            .Columns("pielColor").CellActivation = Activation.NoEdit
            .Columns("coleccion").CellActivation = Activation.NoEdit
            .Columns("talla").CellActivation = Activation.NoEdit
            .Columns("Horma").CellActivation = Activation.NoEdit
            .Columns("nomSts").CellActivation = Activation.NoEdit

            .Columns("talla").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        grdProductosDisponibles.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdProductosDisponibles.DisplayLayout.Override.RowSelectorWidth = 35
        grdProductosDisponibles.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdProductosDisponibles.Rows(0).Selected = True
        band.Columns("Sel").Width = 25
        grdProductosDisponibles.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn

    End Sub

    Public Sub formatoGridTablaProductosNuevos()

        Dim band As UltraGridBand = Me.grdProductosNuevos.DisplayLayout.Bands(0)

        With grdProductosNuevos.DisplayLayout.Bands(0)
            .Columns("prnv_productonuevoid").Hidden = True
            .Columns("ID").Hidden = True
            .Columns("idEst").Hidden = True
            .Columns("idMarca").Hidden = True
            .Columns("idColeccion").Hidden = True
            .Columns("idTemporada").Hidden = True
            .Columns("idPiel").Hidden = True
            .Columns("idColor").Hidden = True
            .Columns("idTalla").Hidden = True
            .Columns("idFamilia").Hidden = True
            .Columns("idHorma").Hidden = True
            .Columns("idFamilia").Hidden = True
            .Columns("pres_activo").Hidden = True
            .Columns("temporada").Hidden = True
            .Columns("psEstatus").Hidden = True
            .Columns("fechaCreo").Hidden = True
            .Columns("nave_naveid").Hidden = True

            .Columns("Sel").Header.Caption = ""
            .Columns("codSICY").Header.Caption = "Cod. SICY"
            .Columns("nave_nombre").Header.Caption = "Nave"
            .Columns("Marca").Header.Caption = "Marca"
            .Columns("coleccion").Header.Caption = "Colección"
            .Columns("pielColor").Header.Caption = "Piel-Color"
            .Columns("coleccion").Header.Caption = "Colección"
            .Columns("talla").Header.Caption = "Talla"
            .Columns("Horma").Header.Caption = "Horma"
            .Columns("nomSts").Header.Caption = "Estatus"
            .Columns("fechaProd").Header.Caption = "Fecha Producción"

            .Columns("codSICY").CellActivation = Activation.NoEdit
            .Columns("nave_nombre").CellActivation = Activation.NoEdit
            .Columns("SAY").CellActivation = Activation.NoEdit
            .Columns("SICY").CellActivation = Activation.NoEdit
            .Columns("Marca").CellActivation = Activation.NoEdit
            .Columns("coleccion").CellActivation = Activation.NoEdit
            .Columns("pielColor").CellActivation = Activation.NoEdit
            .Columns("coleccion").CellActivation = Activation.NoEdit
            .Columns("talla").CellActivation = Activation.NoEdit
            .Columns("Horma").CellActivation = Activation.NoEdit
            .Columns("nomSts").CellActivation = Activation.NoEdit
            .Columns("fechaProd").CellActivation = Activation.NoEdit

            .Columns("talla").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        grdProductosNuevos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdProductosNuevos.DisplayLayout.Override.RowSelectorWidth = 35
        grdProductosNuevos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdProductosNuevos.Rows(0).Selected = True
        band.Columns("Sel").Width = 25
        grdProductosNuevos.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
    End Sub

    Public Sub llenarComboNave()
        Dim objBU As New Negocios.NaveAuxBU
        Dim dtNaves As New DataTable
        dtNaves = objBU.tablaNavesAux
        If dtNaves.Rows.Count > 0 Then
            dtNaves.Rows.InsertAt(dtNaves.NewRow, 0)
            cmbNaves.DataSource = dtNaves
            cmbNaves.DisplayMember = "nave_nombre"
            cmbNaves.ValueMember = "nave_naveid"
        End If

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmProductosNuevos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        llenarComboNave()
    End Sub

    Private Sub cmbNaves_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNaves.SelectedIndexChanged
        llenarTablaTodosLosArticulo()
    End Sub

    Private Sub btnAgregarColeccion_Click(sender As Object, e As EventArgs) Handles btnAgregarColeccion.Click
        Dim objMs As New Tools.ConfirmarForm
        objMs.mensaje = "¿Está seguro de guardar los cambios?"
        If objMs.ShowDialog = Windows.Forms.DialogResult.OK Then
            guardarProductosNuevos()
        End If
    End Sub

    Private Sub btnQuitarColeccion_Click(sender As Object, e As EventArgs) Handles btnQuitarColeccion.Click
        Dim objMs As New Tools.ConfirmarForm
        objMs.mensaje = "¿Está seguro de inactivar los registros de productos nuevos?"
        If objMs.ShowDialog = Windows.Forms.DialogResult.OK Then
            quitarProductosNuevos()
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub chkSeleccionarArts_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarArts.CheckedChanged
        For Each rowGrd As UltraGridRow In grdProductosDisponibles.Rows.GetFilteredInNonGroupByRows
            rowGrd.Cells("Sel").Value = chkSeleccionarArts.Checked
        Next
    End Sub

    Private Sub chkSeleccionarProdsNvs_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarProdsNvs.CheckedChanged
        For Each rowGrd As UltraGridRow In grdProductosNuevos.Rows.GetFilteredInNonGroupByRows
            rowGrd.Cells("Sel").Value = chkSeleccionarProdsNvs.Checked
        Next
    End Sub

    Private Sub grdProductosDisponibles_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles grdProductosDisponibles.AfterSelectChange
        With grdProductosDisponibles
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        Try
            Me.Cursor = Cursors.WaitCursor

            For Each r In grdProductosDisponibles.Rows
                If r.Selected Then
                    r.Cells("Sel").Value = True
                Else
                    r.Cells("Sel").Value = False
                End If
            Next

            grdProductosDisponibles.EndUpdate()

        Catch ex As Exception
            ' naim.app.Errores.Mostrar(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
        If chkSeleccionarArts.Checked = True Then
            chkSeleccionarArts.Checked = False
        End If
    End Sub

    Private Sub grdProductosNuevos_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles grdProductosNuevos.AfterSelectChange
        With grdProductosNuevos
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        Try
            Me.Cursor = Cursors.WaitCursor

            For Each r In grdProductosNuevos.Rows
                If r.Selected Then
                    r.Cells("Sel").Value = True
                Else
                    r.Cells("Sel").Value = False
                End If
            Next

            grdProductosNuevos.EndUpdate()

        Catch ex As Exception
            ' naim.app.Errores.Mostrar(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
        If chkSeleccionarProdsNvs.Checked = True Then
            chkSeleccionarProdsNvs.Checked = False
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objMs As New Tools.ConfirmarForm
        objMs.mensaje = "¿Está seguro de guardar los cambios?"
        If objMs.ShowDialog = Windows.Forms.DialogResult.OK Then
            cambiarFechaProductosNuevos()
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        exportarExcel(grdProductosNuevos)
    End Sub

End Class