Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Entidades
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Produccion.Negocios
Imports Tools.modMensajes

Public Class Produccion_Suelas_ConsultaAvancesProduccionForm
#Region "Variables Globales"
    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim lstMaquinas As New List(Of String)
    Dim lstTarjetas As New List(Of String)
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objConfirmar As New Tools.ConfirmarForm
    Dim naveId_Colaborador As Integer

#End Region
#Region "Diseño Grid"
    Private Sub disenioGrid()
        vwReporteResumen.Appearance.Row.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
        vwReporteResumen.OptionsBehavior.Editable = False

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporteResumen.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If (col.FieldName = "Pares" Or col.FieldName = "ParesTerminados") Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "{0:N0}"
            End If
        Next
        If cmbTipoReporte.Text = "Avance Tarjeta de Producción" Then
            vwReporteResumen.Columns.ColumnByFieldName("Maquina").Caption = "Máquina"
            vwReporteResumen.Columns.ColumnByFieldName("idNaves").Visible = False

            vwReporteResumen.OptionsView.ShowAutoFilterRow = True
            vwReporteResumen.IndicatorWidth = 35
            vwReporteResumen.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways
        End If
        If (vwReporteResumen.Columns.Count > 2) Then
            If IsNothing(vwReporteResumen.Columns("Pares").Summary.FirstOrDefault(Function(x) x.FieldName = "Pares")) = True Then
                vwReporteResumen.Columns("Pares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares", "{0:N0}")
                Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
                item.FieldName = "Pares"
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0}"
                vwReporteResumen.GroupSummary.Add(item)
            End If
        End If
        If cmbTipoReporte.Text <> "Avance Tarjeta de Producción" Then
            If IsNothing(vwReporteResumen.Columns("ParesTerminados").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesTerminados")) = True Then
                vwReporteResumen.Columns("ParesTerminados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesTerminados", "{0:N0}")
                Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
                item.FieldName = "ParesTerminados"
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0}"
                vwReporteResumen.GroupSummary.Add(item)
            End If
        End If
        If cmbTipoReporte.Text = "Inventario Produccion Por Nave" Then
            vwReporteResumen.Columns.ColumnByFieldName("Avance").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            vwReporteResumen.Columns.ColumnByFieldName("Avance").DisplayFormat.FormatString = "{0:f1} %"
            If IsNothing(vwReporteResumen.Columns("Avance").Summary.FirstOrDefault(Function(x) x.FieldName = "Avance")) = True Then
                vwReporteResumen.Columns("Avance").Summary.Add(DevExpress.Data.SummaryItemType.Average, "Avance", "{0:n2}%")
            End If
        End If

        vwReporteResumen.OptionsView.AllowCellMerge = False
        'If cmbTipoReporte.Text = "Avance Produccion Por Operador" Then
        '    'Agrupamiento por columna
        '    vwReporteResumen.OptionsView.AllowCellMerge = True
        '    vwReporteResumen.Columns.ColumnByFieldName("Operador").VisibleIndex = 0
        'End If

        'Diseño Grid
        vwReporteResumen.OptionsView.EnableAppearanceEvenRow = True
        vwReporteResumen.OptionsView.ColumnAutoWidth = True
        vwReporteResumen.OptionsSelection.EnableAppearanceFocusedCell = False
        vwReporteResumen.OptionsSelection.EnableAppearanceFocusedRow = True
        vwReporteResumen.Appearance.SelectedRow.Options.UseBackColor = True
        vwReporteResumen.BestFitColumns()
    End Sub
    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
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

    'Asigna formato a columnas de ultragrid
    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

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

    Public Sub limpiarGrid(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DataSource = Nothing
    End Sub
#End Region
    Private Sub txtPedidoSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMaquina.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim insertar = True
            For Each maquina In lstMaquinas
                If (maquina = (LTrim(txtMaquina.Text.ToString))) Then insertar = False
            Next
            If insertar Then
                grdMaquinas.DataSource = Nothing
                grdMaquinas.DataSource = lstMaquinas
                lstMaquinas.Add(LTrim(txtMaquina.Text.ToString))
                txtMaquina.Text = String.Empty
            Else
                objAdvertencia.mensaje = "La máquina ya se encuentra en la lista."
                objAdvertencia.ShowDialog()
            End If
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub grdMaquinas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMaquinas.InitializeLayout
        grid_diseño(grdMaquinas)
        grdMaquinas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Máquina"
    End Sub

    Private Sub btnLimpiarFiltroAgente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroMaquina.Click
        grdMaquinas.DataSource = Nothing
        lstMaquinas = New List(Of String)
    End Sub

    Private Sub btnMarcas_Click(sender As Object, e As EventArgs) Handles btnMarcas.Click
        Dim listado As New ListadoParametrosSuelaForm
        listado.tipo_busqueda = 4

        Dim listaParametroID As New List(Of String)

        For Each row As UltraGridRow In grdNaves.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdNaves.DataSource = listado.listaParametros
        grid_diseño(grdNaves)
        With grdNaves
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametrosSuelaForm
        listado.tipo_busqueda = 5

        Dim listaParametroID As New List(Of String)

        For Each row As UltraGridRow In grdSuelas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdSuelas.DataSource = listado.listaParametros
        grid_diseño(grdSuelas)
        With grdSuelas
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Suelas"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim listado As New ListadoParametrosSuelaForm
        listado.tipo_busqueda = 6
        listado.naveId_Colaborador = naveId_Colaborador
        Dim listaParametroID As New List(Of String)

        For Each row As UltraGridRow In grdOperadores.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdOperadores.DataSource = listado.listaParametros
        grid_diseño(grdOperadores)
        With grdSuelas
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Operadores"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimpiarFiltroMarca_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroNave.Click
        limpiarGrid(grdNaves)
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroSuela.Click
        limpiarGrid(grdSuelas)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroOperador.Click
        limpiarGrid(grdOperadores)
    End Sub

    Private Sub Produccion_Suelas_ConsultaAvancesProduccionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obj As New TarjetaProduccionSuelasBU
        Dim colaboradorId = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser
        naveId_Colaborador = obj.ObtenerIdNavePorColaborador(colaboradorId)
        dtpFechaAvanceInicio.Value = Date.Now
        dtpFechaAvanceFin.Value = DateAdd(DateInterval.Day, 3, dtpFechaAvanceInicio.Value)
        dtpFechaProgramaInicio.Value = Date.Now
        dtpFechaProgramaFin.Value = DateAdd(DateInterval.Day, 3, dtpFechaAvanceInicio.Value)
        cmbTipoReporte.SelectedIndex = 0
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Me.Cursor = Cursors.WaitCursor
        lblFechaUltimaActualización.Text = "-"
        If chkFechaAvance.Checked Or chkFechaPrograma.Checked Then
            Dim objEntidad As New AvanceProduccionSuelas
            objEntidad.AP_FechaAvanceInicio = dtpFechaAvanceInicio.Value.ToShortDateString()
            objEntidad.AP_FechaAvanceFin = dtpFechaAvanceFin.Value.ToShortDateString()
            objEntidad.AP_FechaProgramaInicio = dtpFechaProgramaInicio.Value.ToShortDateString()
            objEntidad.AP_FechaProgramaFin = dtpFechaProgramaFin.Value.ToShortDateString()
            objEntidad.AP_TipoReporteFecha = verificarChecks()
            objEntidad.AP_MaquinasID = ObtenerFiltrosGrid(grdMaquinas)
            objEntidad.AP_SuelasID = ObtenerFiltrosGrid(grdSuelas)
            objEntidad.AP_NavesID = ObtenerFiltrosGrid(grdNaves)
            objEntidad.AP_OperadoresID = ObtenerFiltrosGrid(grdOperadores)
            objEntidad.AP_FolioTarjetas = ObtenerFiltrosGrid(grdTarjetas)
            grdReporteResumen.DataSource = Nothing
            vwReporteResumen.Columns.Clear()
            Try
                Dim dtConsulta As DataTable
                Dim obj As New TarjetaProduccionSuelasBU
                If cmbTipoReporte.SelectedIndex = 0 Or cmbTipoReporte.Text = "Avance Tarjeta de Producción" Then
                    objEntidad.AP_TipoReporte = 1
                    'ElseIf cmbTipoReporte.SelectedIndex = 1 Or cmbTipoReporte.Text = "Inventario Produccion" Then
                    '    objEntidad.AP_TipoReporte = 2
                ElseIf cmbTipoReporte.Text = "Inventario Produccion Por Nave" Then
                    objEntidad.AP_TipoReporte = 3
                ElseIf cmbTipoReporte.Text = "Avance Produccion Por maquina" Then
                    objEntidad.AP_TipoReporte = 4
                ElseIf cmbTipoReporte.Text = "Avance Produccion Por Nave" Then
                    objEntidad.AP_TipoReporte = 5
                ElseIf cmbTipoReporte.Text = "Avance Produccion Por Operador" Then
                    objEntidad.AP_TipoReporte = 6
                End If
                dtConsulta = obj.ConsultaAvanceProduccionSuelas(objEntidad)
                If dtConsulta.Rows.Count > 0 Then
                    grdReporteResumen.DataSource = dtConsulta
                    lblFechaUltimaActualización.Text = Date.Now.ToString
                    disenioGrid()
                Else
                    objAdvertencia.mensaje = "No se encontro información"
                    objAdvertencia.ShowDialog()
                End If
            Catch ex As Exception
                objAdvertencia.mensaje = ex.Message
                objAdvertencia.ShowDialog()
            End Try

        Else
            objAdvertencia.mensaje = "Al menos se debe de seleccionar un filtro de tipo fecha."
            objAdvertencia.ShowDialog()
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Function verificarChecks() As String
        If chkFechaAvance.Checked And chkFechaPrograma.Checked Then
            Return "General"
        ElseIf chkFechaAvance.Checked Then
            Return "SinPrograma"
        ElseIf chkFechaPrograma.Checked Then
            Return "SinAvance"
        End If
        Return ""
    End Function
    Public Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty
        If grid.Rows.Count = 0 Then Resultado = "0"
        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += Replace(row.Cells(0).Text, ",", "")
            Else
                Resultado += "," + Replace(row.Cells(0).Text, ",", "")
            End If
        Next
        Return Resultado
    End Function

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            'CargarReporteParaExcel()
            If vwReporteResumen.DataRowCount > 0 Then
                nombreReporte = "Produccion_Suelas_Avance de Producción_"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If vwReporteResumen.GroupCount > 0 Then
                            vwReporteResumen.ExportToXlsx(.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                            vwReporteResumen.ExportToXlsx(.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx", exportOptions)
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

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        vwReporteResumen.Columns.Clear()
        grdReporteResumen.DataSource = Nothing
        grdMaquinas.DataSource = Nothing
        grdNaves.DataSource = Nothing
        grdOperadores.DataSource = Nothing
        grdSuelas.DataSource = Nothing
        txtMaquina.Text = String.Empty
        chkFechaAvance.Checked = True
        chkFechaPrograma.Checked = True
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 30
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 206
    End Sub

    Private Sub vwReporteResumen_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwReporteResumen.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnMaquinas_Click(sender As Object, e As EventArgs) Handles btnMaquinas.Click
        Dim listado As New ListadoParametrosSuelaForm
        listado.tipo_busqueda = 7

        Dim listaParametroID As New List(Of String)

        For Each row As UltraGridRow In grdMaquinas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdMaquinas.DataSource = listado.listaParametros
        grid_diseño(grdMaquinas)
        With grdMaquinas
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Máquinas"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub txtTarjeta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTarjeta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If LTrim(txtTarjeta.Text.ToString).Length = 12 Then
                Dim insertar = True
                For Each tarjeta In lstTarjetas
                    If (tarjeta = (LTrim(txtTarjeta.Text.ToString))) Then insertar = False
                Next
                If insertar Then
                    grdTarjetas.DataSource = Nothing
                    lstTarjetas.Add(LTrim(txtTarjeta.Text.ToString))
                    txtTarjeta.Text = String.Empty
                    grdTarjetas.DataSource = lstTarjetas
                Else
                    objAdvertencia.mensaje = "El codigo de la tarjeta ya se encuentra en la lista."
                    objAdvertencia.ShowDialog()
                End If
            Else
                objAdvertencia.mensaje = "Código invalido."
                objAdvertencia.ShowDialog()
            End If
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub grdTarjetas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdTarjetas.InitializeLayout
        grid_diseño(grdTarjetas)
        grdTarjetas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Tarjeta"
    End Sub

    Private Sub grdTarjetas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdTarjetas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdMaquinas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdMaquinas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdNaves_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdNaves.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdSuelas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdSuelas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdOperadores_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdOperadores.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub btnLimpiarFiltroTarjeta_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroTarjeta.Click
        grdTarjetas.DataSource = Nothing
        lstTarjetas = New List(Of String)
    End Sub

    Private Sub vwReporteResumen_CellMerge(sender As Object, e As CellMergeEventArgs) Handles vwReporteResumen.CellMerge
        Dim view1 As GridView = sender
        e.Handled = True
        'sirve para hacer las divbisiones tomando en cuenta una columna (+1) en este caso toma a la columna de Lote como referencia
        'para todas las demás columnas



        If e.Column.FieldName = ("Operador") Then
            Dim view = sender
            Dim previousCol As Object

            previousCol = view.Columns(view.Columns.IndexOf(e.Column) + 1).FieldName
            'get the previous column
            If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                e.Handled = True
            End If
        End If
    End Sub
End Class