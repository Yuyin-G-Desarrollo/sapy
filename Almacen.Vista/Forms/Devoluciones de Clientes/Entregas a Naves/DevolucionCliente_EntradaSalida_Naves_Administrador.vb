Imports DevExpress.Utils
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class DevolucionCliente_EntradaSalida_Naves_Administrador
    Public negocios As New Negocios.DevolucionCliente_EntradaSalida_Nave_BU
    Public listaFiltroFoliosSalidas As New List(Of String)
    Public listaFiltroFoliosDevolucion As New List(Of String)
    Public listaFiltroFoliosClientes As New List(Of String)
    Public listaFiltroFoliosEstatus As New List(Of String)
    Public indexSeleccionado As Integer = -1

    Public Sub InicializarGrid(grid As UltraGrid)
        grid.DataSource = New List(Of String)
    End Sub
    Private Sub DevolucionCliente_EntradaSalida_Naves_Administrador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        PoblrGrid()
        InicializarGrid(grdStatus)
        InicializarGrid(grdFiltroFoliosSalida)
        InicializarGrid(grdFiltroFoliosDev)
        InicializarGrid(grdFiltroCliente)
    End Sub

    Public Sub SumarColumnas(columna As String, formato As String)
        If IsNothing(bgvFoliosSalidas.Columns(columna).Summary.FirstOrDefault(Function(x) x.FieldName = columna)) = True Then
            bgvFoliosSalidas.Columns(columna).Summary.Add(DevExpress.Data.SummaryItemType.Sum, columna, formato)

            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = columna
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = formato
            bgvFoliosSalidas.GroupSummary.Add(item)
        End If
    End Sub

    Public Sub FormatoGrid()
        Try
            bgvFoliosSalidas.OptionsView.ColumnAutoWidth = True

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvFoliosSalidas.Columns
                If col.FieldName <> " " Then
                    col.OptionsColumn.AllowEdit = False
                    col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
                End If
            Next

            bgvFoliosSalidas.Columns.ColumnByFieldName("EstatusID").Visible = False
            bgvFoliosSalidas.Columns.ColumnByFieldName("NaveID").Visible = False
            bgvFoliosSalidas.Columns.ColumnByFieldName("UsCapturaSalidaID").Visible = False
            bgvFoliosSalidas.Columns.ColumnByFieldName("UsCapturaEntradaID").Visible = False

            bgvFoliosSalidas.Columns.ColumnByFieldName("P Enviados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvFoliosSalidas.Columns.ColumnByFieldName("P Recibidos").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvFoliosSalidas.Columns.ColumnByFieldName("P Pendientes").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

            bgvFoliosSalidas.Columns.ColumnByFieldName("P Enviados").DisplayFormat.FormatString = "N0"
            bgvFoliosSalidas.Columns.ColumnByFieldName("P Recibidos").DisplayFormat.FormatString = "N0"
            bgvFoliosSalidas.Columns.ColumnByFieldName("P Pendientes").DisplayFormat.FormatString = "N0"

            bgvFoliosSalidas.Columns(" ").OptionsColumn.Printable = DefaultBoolean.False

            SumarColumnas("P Enviados", "{0:N0}")
            SumarColumnas("P Recibidos", "{0:N0}")
            SumarColumnas("P Pendientes", "{0:N0}")

            bgvFoliosSalidas.Columns.ColumnByFieldName("St").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            bgvFoliosSalidas.Columns.ColumnByFieldName("Nave").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            bgvFoliosSalidas.Columns.ColumnByFieldName("UsCapturaSalida").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

            bgvFoliosSalidas.Columns.ColumnByFieldName("F Salida").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            bgvFoliosSalidas.Columns.ColumnByFieldName("FEstimadaRec").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            bgvFoliosSalidas.Columns.ColumnByFieldName("F Recepción").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            bgvFoliosSalidas.IndicatorWidth = 40

            bgvFoliosSalidas.BestFitColumns()
            bgvFoliosSalidas.Columns.ColumnByFieldName("St").Width = 20
        Catch ex As Exception
            Tools.Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
        End Try
    End Sub

    Public Sub PoblrGrid()
        Dim folio As String = GenerarFiltros(grdFiltroFoliosSalida)
        Dim Estatus As String = GenerarFiltros(grdStatus)
        Dim Clientes As String = GenerarFiltros(grdFiltroCliente)
        Dim FoliosDev As String = GenerarFiltros(grdFiltroFoliosDev)
        Dim FiltroFecha As Boolean = IIf(chkFecha.Checked, 1, 0)
        Dim TipoFecha As String = IIf(rdbFechaEnvio.Checked, "E", "R")
        grdFoliosSalidas.DataSource = negocios.ConsultarSalidas(FiltroFecha, TipoFecha, dtpFechaInicio.Value.ToString, dtpFechaFin.Value.ToString, folio, Estatus, Clientes, FoliosDev)

        FormatoGrid()
    End Sub

    Public Function GenerarFiltros(grid As UltraGrid)
        Dim filtro As String = ""
        For Each row As UltraGridRow In grid.Rows
            If filtro.Length > 0 Then
                filtro += ","
            End If
            If grid.DisplayLayout.Bands(0).Columns.Exists("Parámetro") Then
                filtro += row.Cells("Parámetro").Value.ToString
            Else
                filtro += row.Cells(0).Value.ToString
            End If

        Next
        Return filtro
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        PoblrGrid()
    End Sub

    Private Sub bgvFoliosSalidas_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles bgvFoliosSalidas.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)

        If bgvFoliosSalidas.RowCount <= 0 Then Return
        Try
            If e.Column.FieldName = "St" Then
                Dim StatusDev As String = bgvFoliosSalidas.GetRowCellValue(e.RowHandle, "St").ToString
                If StatusDev = "ENVIADO A NAVE" Then
                    e.Appearance.BackColor = pnlEstatusEnviado.BackColor
                    e.Appearance.ForeColor = pnlEstatusEnviado.BackColor
                ElseIf StatusDev = "PARCIALMENTE RECIBIDO" Then
                    e.Appearance.BackColor = pnlEstatusParcialmenteRecibido.BackColor
                    e.Appearance.ForeColor = pnlEstatusParcialmenteRecibido.BackColor
                ElseIf StatusDev = "RECIBIDO" Then
                    e.Appearance.BackColor = pnlEstatusRecibido.BackColor
                    e.Appearance.ForeColor = pnlEstatusRecibido.BackColor
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub bgvFoliosSalidas_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles bgvFoliosSalidas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Public Sub DisenoGridFiltros(grid As UltraGrid, titulo As String)
        With grid.DisplayLayout.Bands(0)
            If .Columns.Count = 1 Then
                .Columns(0).Header.Caption = titulo
            End If
        End With

        With grid.DisplayLayout
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.False
            .Override.AllowAddNew = AllowAddNew.No
            .Override.AllowUpdate = DefaultableBoolean.False
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            .Override.SelectTypeRow = SelectType.Single
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With

        If grid.DisplayLayout.Bands(0).Columns.Exists(" ") Then
            grid.DisplayLayout.Bands(0).Columns(" ").Hidden = True
        End If

        If grid.DisplayLayout.Bands(0).Columns.Exists("Parámetro") Then
            grid.DisplayLayout.Bands(0).Columns("Parámetro").Hidden = True
        End If

    End Sub

    Private Sub grdStatus_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdStatus.InitializeLayout
        DisenoGridFiltros(grdStatus, "Estatus")
    End Sub

    Private Sub grdFiltroFoliosSalida_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroFoliosSalida.InitializeLayout
        DisenoGridFiltros(grdFiltroFoliosSalida, "Folio Salida")
    End Sub

    Private Sub grdFiltroFoliosDev_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroFoliosDev.InitializeLayout
        DisenoGridFiltros(grdFiltroFoliosDev, "Folio Dev")
    End Sub

    Private Sub grdFiltroCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroCliente.InitializeLayout
        DisenoGridFiltros(grdFiltroCliente, "Cliente")
    End Sub

    Private Sub btnLimpiarEstatus_Click(sender As Object, e As EventArgs) Handles btnLimpiarEstatus.Click
        InicializarGrid(grdStatus)
    End Sub

    Private Sub btnLimpiarFolioSalida_Click(sender As Object, e As EventArgs) Handles btnLimpiarFolioSalida.Click
        InicializarGrid(grdFiltroFoliosSalida)
    End Sub

    Private Sub btnLimpiarFoliosDev_Click(sender As Object, e As EventArgs) Handles btnLimpiarFoliosDev.Click
        InicializarGrid(grdFiltroFoliosDev)
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        InicializarGrid(grdFiltroCliente)
    End Sub

    Private Sub txtFoliosSalidas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFoliosSalidas.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFoliosSalidas.Text) Then Return
            listaFiltroFoliosSalidas.Add(txtFoliosSalidas.Text)
            grdFiltroFoliosSalida.DataSource = Nothing
            grdFiltroFoliosSalida.DataSource = listaFiltroFoliosSalidas
            txtFoliosSalidas.Text = String.Empty
            DisenoGridFiltros(grdFiltroFoliosSalida, "Folio Salida")
        End If
    End Sub

    Private Sub txtFolioDev_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolioDev.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFolioDev.Text) Then Return
            listaFiltroFoliosDevolucion.Add(txtFolioDev.Text)
            grdFiltroFoliosDev.DataSource = Nothing
            grdFiltroFoliosDev.DataSource = listaFiltroFoliosDevolucion
            txtFolioDev.Text = String.Empty
            DisenoGridFiltros(grdFiltroFoliosDev, "Folio Dev")
        End If
    End Sub

    Private Sub btnNuevaSalida_Click(sender As Object, e As EventArgs) Handles btnNuevaSalida.Click
        Dim formSalida As New DevolucionCliente_EntradaSalida_Naves
        formSalida.MdiParent = Me.MdiParent
        formSalida.operacion = 1
        formSalida.Show()
        Me.Close()
    End Sub

    Public Function ValidarSeleccion()
        Dim seleccionados As Int16 = 0
        indexSeleccionado = -1
        For index As Integer = 0 To bgvFoliosSalidas.DataRowCount Step 1
            If CBool(bgvFoliosSalidas.GetRowCellValue(bgvFoliosSalidas.GetVisibleRowHandle(index), " ")) = True Then
                seleccionados += 1

                If seleccionados > 1 Then
                    Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Hay más de un registro seleccionado. Esta operación solo se puede realizar con un registro a la vez")
                    Return False
                End If
                indexSeleccionado = index
            End If
        Next

        'If seleccionados = 0 Then
        '    Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Debe seleccionar un registro")
        '    Return False
        'End If
        Return True
    End Function

    Private Sub btnRecibirProducto_Click(sender As Object, e As EventArgs) Handles btnRecibirProducto.Click
        If bgvFoliosSalidas.SelectedRowsCount > 0 Then
            If ValidarSeleccion() = False Then Return
            Dim formSalida As New DevolucionCliente_EntradaSalida_Naves
            formSalida.MdiParent = Me.MdiParent
            formSalida.operacion = 0
            If indexSeleccionado <> -1 Then

                If bgvFoliosSalidas.GetRowCellValue(bgvFoliosSalidas.GetVisibleRowHandle(indexSeleccionado), "St").ToString = "RECIBIDO" Then
                    Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Los pares de esta salida ya fueron recibidos en su totalidad")
                    Exit Sub
                End If
                formSalida.folioSalida = CInt(bgvFoliosSalidas.GetRowCellValue(bgvFoliosSalidas.GetVisibleRowHandle(indexSeleccionado), "Folio"))
                formSalida.IdNave = CInt(bgvFoliosSalidas.GetRowCellValue(bgvFoliosSalidas.GetVisibleRowHandle(indexSeleccionado), "NaveID"))
                    formSalida.operadorNave = bgvFoliosSalidas.GetRowCellValue(bgvFoliosSalidas.GetVisibleRowHandle(indexSeleccionado), "OperadorNave").ToString
                    formSalida.fechaEnvio = bgvFoliosSalidas.GetRowCellValue(bgvFoliosSalidas.GetVisibleRowHandle(indexSeleccionado), "F Salida").ToString
                    formSalida.fechaEstimadaRecepcionas = bgvFoliosSalidas.GetRowCellValue(bgvFoliosSalidas.GetVisibleRowHandle(indexSeleccionado), "FEstimadaRec").ToString
                End If

                formSalida.Show()
            Me.Close()
        End If

    End Sub

    Private Sub btnVerDetallesArticulos_Click(sender As Object, e As EventArgs) Handles btnVerDetallesArticulos.Click
        If bgvFoliosSalidas.SelectedRowsCount > 0 Then
            If ValidarSeleccion() = False Then Return
            Dim formSalida As New DevolucionCliente_EntradaSalida_Naves
            formSalida.MdiParent = Me.MdiParent
            formSalida.operacion = 0
            If indexSeleccionado <> -1 Then
                formSalida.folioSalida = CInt(bgvFoliosSalidas.GetRowCellValue(bgvFoliosSalidas.GetVisibleRowHandle(indexSeleccionado), "Folio"))
                formSalida.IdNave = CInt(bgvFoliosSalidas.GetRowCellValue(bgvFoliosSalidas.GetVisibleRowHandle(indexSeleccionado), "NaveID"))
                formSalida.operadorNave = bgvFoliosSalidas.GetRowCellValue(bgvFoliosSalidas.GetVisibleRowHandle(indexSeleccionado), "OperadorNave").ToString
                formSalida.fechaEnvio = bgvFoliosSalidas.GetRowCellValue(bgvFoliosSalidas.GetVisibleRowHandle(indexSeleccionado), "F Salida").ToString
                formSalida.fechaEstimadaRecepcionas = bgvFoliosSalidas.GetRowCellValue(bgvFoliosSalidas.GetVisibleRowHandle(indexSeleccionado), "FEstimadaRec").ToString
                formSalida.soloLectura = True
            End If

            formSalida.Show()
            Me.Close()
        End If
    End Sub

    Private Sub grdStatus_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdStatus.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdFiltroFoliosSalida_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFiltroFoliosSalida.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdFiltroFoliosDev_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFiltroFoliosDev.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdFiltroCliente_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFiltroCliente.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
    Public Function GenerarListaSeleccionados(grid As UltraGrid)
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grid.Rows
            Dim parametro As String = row.Cells("Parámetro").Text
            listaParametroID.Add(parametro)
        Next
        Return listaParametroID
    End Function

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New DevolucionCliente_AdministradorDC_Parametros_Form
        listado.filtro = "CLIENTES"

        listado.listaParametroID = GenerarListaSeleccionados(grdFiltroCliente)
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroCliente.DataSource = listado.listParametros
        DisenoGridFiltros(grdFiltroCliente, "Cliente")
        With grdFiltroCliente
            .DisplayLayout.Bands(0).Columns("Clasificación").Hidden = True
            .DisplayLayout.Bands(0).Columns("Ranking").Hidden = True
            .DisplayLayout.Bands(0).Columns("Bloqueado").Hidden = True
        End With
    End Sub

    Private Sub chkFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkFecha.CheckedChanged
        grpbFecha.Enabled = chkFecha.Checked
    End Sub
End Class