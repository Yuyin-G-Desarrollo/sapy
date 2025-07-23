Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Programacion.Negocios
Imports Entidades
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Tools.modMensajes
Imports DevExpress.XtraGrid

Public Class Programacion_ColocacionSemanal_BitacoraPartidasCanceladas

    Dim listPedidoSAY As New List(Of String)
    Dim listPedidoSICY As New List(Of String)

    Private Sub grdReporte_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub chkSeleccionar_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnNave_Click(sender As Object, e As EventArgs) Handles btnNave.Click
        Dim listado As New ListaNaveAsignada


        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdNaves.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdNaves.DataSource = listado.listParametros

        With grdNaves
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(2).Header.Caption = pHeader
        End With
    End Sub

    Private Sub grdNaves_KeyDown(sender As Object, e As KeyEventArgs) Handles grdNaves.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdNaves.DeleteSelectedRows(False)
    End Sub

    Private Sub grdNaves_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdNaves.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdNave_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdNaves.InitializeLayout
        grid_diseño(grdNaves)
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next
        asignaFormato_Columna(grid)

    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
                col.Format = "N0"
            End If
            If col.DataType.Name.ToString.Equals("Decimal") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right
            End If
            If col.DataType.Name.ToString.Equals("String") Then
                If col.Header.Caption.Equals("Télefono") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("Extensión") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If
            End If
        Next
    End Sub

    Private Sub Programacion_ColocacionSemanal_BitacoraPartidasCanceladas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaCancelacionInicio.Value = Date.Now
        dtpFechaCancelacionFin.Value = Date.Now

        chkFechaCancelación.Checked = True

        WindowState = FormWindowState.Maximized
        nudSemanaLiberadaAñoInicio.Value = DatePart(DateInterval.Year, Now)
        nudSemanaLiberadaSemanaInicio.Value = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
        nudSemanaLiberadaSemanaFin.Value = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
        nudSemanaLiberadaSemanaFin.TextAlign = HorizontalAlignment.Center
        nudSemanaLiberadaSemanaInicio.TextAlign = HorizontalAlignment.Center

    End Sub

    Private Sub txtPedidoSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSAY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSAY.Text) Then Return

            listPedidoSAY.Add(txtPedidoSAY.Text)
            grdPedidoSAY.DataSource = Nothing
            grdPedidoSAY.DataSource = listPedidoSAY

            txtPedidoSAY.Text = String.Empty

        End If
    End Sub

    Private Sub grdPedidoSAY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSAY.InitializeLayout
        grid_diseño(grdPedidoSAY)
        grdPedidoSAY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdPedidoSAY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSAY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSAY.DeleteSelectedRows(False)
    End Sub

    Private Sub btnLimpiarFiltroNave_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroNave.Click
        grdNaves.DataSource = Nothing
    End Sub

    Private Sub btnLimpiarFiltroPedidoSAY_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroPedidoSAY.Click
        grdPedidoSAY.DataSource = Nothing
        listPedidoSAY.Clear()
    End Sub

    Private Sub btnLimpiarFiltroPedidoSICY_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroPedidoSICY.Click
        grdPedidoSICY.DataSource = Nothing
        listPedidoSICY.Clear()
    End Sub

    Private Sub txtPedidoSICY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSICY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSICY.Text) Then Return

            listPedidoSICY.Add(txtPedidoSICY.Text)
            grdPedidoSICY.DataSource = Nothing
            grdPedidoSICY.DataSource = listPedidoSICY

            txtPedidoSICY.Text = String.Empty

        End If
    End Sub

    Private Sub grdPedidoSICY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSICY.InitializeLayout
        grid_diseño(grdPedidoSICY)
        grdPedidoSICY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SICY"
    End Sub

    Private Sub grdPedidoSICY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSICY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSICY.DeleteSelectedRows(False)
    End Sub

    Private Sub chkFechaCancelación_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechaCancelación.CheckedChanged
        If chkFechaCancelación.Checked = False Then
            grpCancelación.Enabled = False
        Else
            grpCancelación.Enabled = True
        End If
    End Sub

    Private Sub dtpFechaCancelacionInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaCancelacionInicio.ValueChanged
        If dtpFechaCancelacionInicio.Value > dtpFechaCancelacionFin.Value Then
            dtpFechaCancelacionFin.MinDate = dtpFechaCancelacionInicio.Value
        End If
    End Sub

    Private Sub dtpFechaCancelacionFin_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaCancelacionFin.ValueChanged
        If dtpFechaCancelacionFin.Value < dtpFechaCancelacionInicio.Value Then
            dtpFechaCancelacionInicio.MaxDate = dtpFechaCancelacionFin.Value
        End If
    End Sub


    Private Sub consultaUltimaSemanaDelAñoInicio(ByVal añoSeleccionado As Integer)
        Dim obj As New Programacion_MapaOcupacionBU
        Try
            Dim maximoSemana As Integer = obj.ConsultarUltimaSemanaAño(añoSeleccionado)
            nudSemanaLiberadaSemanaInicio.Maximum = maximoSemana
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub consultaUltimaSemanaDelAñoFin(ByVal añoSeleccionado As Integer)
        Dim obj As New Programacion_MapaOcupacionBU
        Try
            Dim maximoSemana As Integer = obj.ConsultarUltimaSemanaAño(añoSeleccionado)
            nudSemanaLiberadaSemanaFin.Maximum = maximoSemana
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
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

    Private Sub nudSemanaLiberadaSemanaInicio_ValueChanged(sender As Object, e As EventArgs) Handles nudSemanaLiberadaSemanaInicio.ValueChanged
        If (nudSemanaLiberadaSemanaInicio.Value > nudSemanaLiberadaSemanaFin.Value And nudSemanaLiberadaAñoInicio.Value = nudSemanaLiberadaAñoFin.Value) Then
            nudSemanaLiberadaSemanaFin.Value = nudSemanaLiberadaSemanaInicio.Value
        End If
    End Sub

    Private Sub nudSemanaLiberadaSemanaFin_ValueChanged(sender As Object, e As EventArgs) Handles nudSemanaLiberadaSemanaFin.ValueChanged
        If (nudSemanaLiberadaSemanaInicio.Value > nudSemanaLiberadaSemanaFin.Value And nudSemanaLiberadaAñoInicio.Value = nudSemanaLiberadaAñoFin.Value) Then
            nudSemanaLiberadaSemanaInicio.Value = nudSemanaLiberadaSemanaFin.Value
        End If
    End Sub

    Private Sub nudSemanaLiberadaAñoInicio_ValueChanged(sender As Object, e As EventArgs) Handles nudSemanaLiberadaAñoInicio.ValueChanged
        If nudSemanaLiberadaAñoInicio.Value > nudSemanaLiberadaAñoFin.Value Then
            nudSemanaLiberadaAñoFin.Value = nudSemanaLiberadaAñoInicio.Value
        End If
        If (nudSemanaLiberadaSemanaInicio.Value > nudSemanaLiberadaSemanaFin.Value And nudSemanaLiberadaAñoInicio.Value = nudSemanaLiberadaAñoFin.Value) Then
            If nudSemanaLiberadaSemanaInicio.Value <= nudSemanaLiberadaSemanaFin.Maximum Then
                nudSemanaLiberadaSemanaFin.Value = nudSemanaLiberadaSemanaInicio.Value
            Else
                nudSemanaLiberadaSemanaFin.Value = nudSemanaLiberadaSemanaFin.Maximum
            End If
        End If
        consultaUltimaSemanaDelAñoInicio(nudSemanaLiberadaAñoInicio.Value)
    End Sub

    Private Sub nudSemanaLiberadaAñoFin_ValueChanged(sender As Object, e As EventArgs) Handles nudSemanaLiberadaAñoFin.ValueChanged
        If nudSemanaLiberadaAñoInicio.Value > nudSemanaLiberadaAñoFin.Value Then
            nudSemanaLiberadaAñoInicio.Value = nudSemanaLiberadaAñoFin.Value
        End If
        If (nudSemanaLiberadaSemanaInicio.Value > nudSemanaLiberadaSemanaFin.Value And nudSemanaLiberadaAñoInicio.Value = nudSemanaLiberadaAñoFin.Value) Then
            If nudSemanaLiberadaSemanaFin.Value <= nudSemanaLiberadaSemanaInicio.Maximum Then
                nudSemanaLiberadaSemanaInicio.Value = nudSemanaLiberadaSemanaFin.Value
            Else
                nudSemanaLiberadaSemanaInicio.Value = nudSemanaLiberadaSemanaInicio.Maximum
            End If
        End If
        consultaUltimaSemanaDelAñoFin(nudSemanaLiberadaAñoFin.Value)
    End Sub

    Private Sub chkSemanaLiberada_CheckedChanged(sender As Object, e As EventArgs) Handles chkSemanaLiberada.CheckedChanged
        If chkSemanaLiberada.Checked = False Then
            grpSemanaLiberada.Enabled = False
        Else
            grpSemanaLiberada.Enabled = True
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Cursor = Cursors.WaitCursor

        Dim objBU As New Programacion_MapaOcupacionBU
        Dim filtrosCancelaciones As New BitacoraCancelaciones
        Dim dtResultados As New DataTable

        filtrosCancelaciones.filtroFechaCancelacion = chkFechaCancelación.Checked
        filtrosCancelaciones.filtroSemanas = chkSemanaLiberada.Checked

        filtrosCancelaciones.fechaCancelacionDe = dtpFechaCancelacionInicio.Value.ToShortDateString
        filtrosCancelaciones.fechaCancelacionA = dtpFechaCancelacionFin.Value.ToShortDateString

        filtrosCancelaciones.añoSemanaLiberadaDe = nudSemanaLiberadaAñoInicio.Value
        filtrosCancelaciones.semanaLiberadaDe = nudSemanaLiberadaSemanaInicio.Value

        filtrosCancelaciones.añoSemanaLiberadaA = nudSemanaLiberadaAñoFin.Value
        filtrosCancelaciones.semanaLiberadaA = nudSemanaLiberadaSemanaFin.Value

        filtrosCancelaciones.naveIdSAY = Filtros(grdNaves)
        filtrosCancelaciones.pedidoIdSAY = Filtros(grdPedidoSAY)
        filtrosCancelaciones.pedidoIdSICY = Filtros(grdPedidoSICY)


        dtResultados = objBU.consultarBitacoraCancelaciones(filtrosCancelaciones)

        grdReporte.DataSource = dtResultados

        lblNumFiltrados.Text = dtResultados.Rows.Count().ToString()

        disenoGrid()

        btnArriba_Click(Nothing, Nothing)

        Cursor = Cursors.Default

    End Sub

    Private Function Filtros(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim vDatosFiltrados As String = String.Empty
        For Each Row As UltraGridRow In grid.Rows
            If vDatosFiltrados <> Nothing Then
                vDatosFiltrados += ","
            End If
            vDatosFiltrados += Row.Cells("Parametro").Value.ToString()
        Next
        Return vDatosFiltrados
    End Function

    Private Sub disenoGrid()
        vwReporte.OptionsView.EnableAppearanceEvenRow = True
        vwReporte.OptionsSelection.EnableAppearanceFocusedRow = True
        vwReporte.IndicatorWidth = 40
        vwReporte.OptionsView.ShowAutoFilterRow = True
        vwReporte.OptionsView.RowAutoHeight = True
        vwReporte.OptionsClipboard.AllowCopy = True


        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
            col.Summary.Clear()
            If col.FieldName.Contains("Pares Cancelados") Then
                col.Caption = col.FieldName.Replace("Pares Cancelados", "")
                col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
            End If
            'If col.FieldName.Contains("ParesColocados") Then
            '    col.Caption = col.FieldName.Replace("ParesColocados", "")
            '    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
            'End If
            'If col.FieldName.Contains("ParesPartida") Then
            '    col.Caption = col.FieldName.Replace("ParesPartida", "")
            '    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
            'End If
        Next


        vwReporte.BestFitColumns()
    End Sub


    Private Sub vwReporte_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles vwReporte.RowCellStyle
        If (e.RowHandle Mod 2 > 0) Then
            e.Appearance.BackColor = Color.LightSteelBlue
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If vwReporte.DataRowCount > 0 Then
                nombreReporte = "Mapa_Ocupacion_Bitacora_Partidas_Canceladas_"
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

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        If (e.RowHandle Mod 2 > 0) Then
            e.Formatting.BackColor = Color.LightSteelBlue
        End If
        e.Handled = True
    End Sub

    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1

        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 162
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class