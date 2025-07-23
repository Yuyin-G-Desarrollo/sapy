Imports DevExpress
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class AdministradorFoliosCancelacion_Form
#Region "Variables"
    Private tamanioPanelFiltro As Integer = 0
    Private lstInicial As List(Of String)
    Private listPedidoSAY As New List(Of String)
    Private listPedidoSICY As New List(Of String)
    Private listadoFiltro As New ListadoParametrosProyeccionEntregasForm
    Private objBu As New Negocios.FolioCancelacionBU
    Private WithEvents repositorioChkSeleccionar As New RepositoryItemCheckEdit
#End Region

    Private Sub AdministradorFoliosCancelacion_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tamanioPanelFiltro = pnlFiltros.Height
        dtpFechaInicio.Value = Now
        dtpFechaFin.Value = Now
        chkBuscarPorFecha.Checked = False
        ActualizarBusquedaFecha()
    End Sub

#Region "Acciones Botones Arriba Abajo"
    Private Sub OcultarFiltros()
        pnlFiltros.Height = 0
    End Sub

    Private Sub MostrarFiltros()
        pnlFiltros.Height = tamanioPanelFiltro
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        OcultarFiltros()
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        MostrarFiltros()
    End Sub
#End Region

#Region "Acciones Filtros"
    Private Sub reiniciarGrid(grdFiltro As UltraGrid)
        grdFiltro.DataSource = lstInicial
    End Sub

    Private Sub abrirSeleccionFiltro(grdFiltro As UltraGrid, tipoBusqueda As Integer)
        listadoFiltro.tipo_busqueda = tipoBusqueda
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFiltro.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listadoFiltro.listaParametroID = listaParametroID
        listadoFiltro.ShowDialog(Me)
        If Not listadoFiltro.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listadoFiltro.listParametros.Rows.Count = 0 Then Return

        grdFiltro.DataSource = listadoFiltro.listParametros

        For i = 0 To grdFiltro.DisplayLayout.Bands(0).Columns.Count - 1
            grdFiltro.DisplayLayout.Bands(0).Columns(IIf(i <> 2, i, 0)).Hidden = True
        Next
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        If dtpFechaFin.Value < dtpFechaInicio.Value Then
            dtpFechaFin.Value = dtpFechaInicio.Value
        End If
        dtpFechaFin.MinDate = dtpFechaInicio.Value
    End Sub

    Private Sub chkBuscarPorFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkBuscarPorFecha.CheckedChanged
        ActualizarBusquedaFecha()
    End Sub

    Private Sub btnLimpiarFiltroEstatusPedido_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroEstatusPedido.Click
        reiniciarGrid(grdEstatusPedido)
    End Sub

    Private Sub btnAgregarFiltroEstatusPedido_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroEstatusPedido.Click
        abrirSeleccionFiltro(grdEstatusPedido, 11)
    End Sub

    Private Sub txtPedidoSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSAY.KeyPress

        If e.KeyChar = ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSAY.Text) Then Return

            listPedidoSAY.Add(txtPedidoSAY.Text)
            grdPedidoSAY.DataSource = Nothing
            grdPedidoSAY.DataSource = listPedidoSAY

            txtPedidoSAY.Text = String.Empty

        End If

    End Sub

    Private Sub btnLimpiarFiltroPedidoSAY_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroPedidoSAY.Click
        reiniciarGrid(grdPedidoSAY)
        listPedidoSAY.Clear()
    End Sub

    Private Sub txtPedidoSICY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSICY.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSICY.Text) Then Return

            listPedidoSICY.Add(txtPedidoSICY.Text)
            grdPedidoSICY.DataSource = Nothing
            grdPedidoSICY.DataSource = listPedidoSICY

            txtPedidoSICY.Text = String.Empty

        End If
    End Sub

    Private Sub btnLimpiarFiltroPedidoSICY_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroPedidoSICY.Click
        reiniciarGrid(grdPedidoSICY)
        listPedidoSICY.Clear()
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        reiniciarGrid(grdCliente)
    End Sub

    Private Sub btnAgregarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroCliente.Click
        abrirSeleccionFiltro(grdCliente, 1)
    End Sub


    Private Sub grdEstatusPedido_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdEstatusPedido.InitializeLayout
        grid_diseño(grdEstatusPedido)
        grdEstatusPedido.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Estatus Pedido"
    End Sub

    Private Sub grdPedidoSAY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSAY.InitializeLayout
        grid_diseño(grdPedidoSAY)
        grdPedidoSAY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "P SAY"
    End Sub

    Private Sub grdPedidoSICY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSICY.InitializeLayout
        grid_diseño(grdPedidoSICY)
        grdPedidoSICY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "P SICY"
    End Sub

    Private Sub grdCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        grid_diseño(grdCliente)
        grdCliente.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub grdEstatusPedido_KeyDown(sender As Object, e As KeyEventArgs) Handles grdEstatusPedido.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdEstatusPedido.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPedidoSAY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSAY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSAY.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPedidoSICY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSICY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSICY.DeleteSelectedRows(False)
    End Sub

    Private Sub grdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
    End Sub
#End Region

#Region "Eventos"

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ExportarExcel()
    End Sub

    Private Sub btnVerDetalle_Click(sender As Object, e As EventArgs) Handles btnVerDetalle.Click
        AbrirFormDetalle()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Mostrar()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        reiniciarGridTodos()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub
#End Region

#Region "Metodos"
    Private Sub reiniciarGridTodos()
        reiniciarGrid(grdEstatusPedido)
        reiniciarGrid(grdPedidoSAY)
        reiniciarGrid(grdPedidoSICY)
        reiniciarGrid(grdCliente)

        chkBuscarPorFecha.Checked = False
        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now
    End Sub

    Private Sub ActualizarBusquedaFecha()
        Dim activo = chkBuscarPorFecha.Checked
        dtpFechaInicio.Enabled = activo
        dtpFechaFin.Enabled = activo
    End Sub

    Private Function RecuperarFiltroGrid(grid As UltraGrid) As String
        Dim resultado As String = String.Empty
        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                resultado += " " + Replace(row.Cells(0).Text, ",", "")
            Else
                resultado += ", " + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        Return resultado
    End Function

    Private Sub ActualizarConteoyFechaConsulta()
        lblRegistros.Text = grdDatosFolios.RowCount.ToString("n0")
        lblUltimaActualizacion.Text = Now()
    End Sub

    Private Sub Mostrar()
        Dim dtResultado As New DataTable()
        Dim buscarPorFecha As Boolean = False
        Dim fechaInicio As New DateTime
        Dim fechaFin As New DateTime
        Dim filtroEstatus As String = String.Empty
        Dim filtroPedidoSAY As String = String.Empty
        Dim filtroPedidoSICY As String = String.Empty
        Dim filtroCliente As String = String.Empty

        grdFolios.DataSource = Nothing

        buscarPorFecha = chkBuscarPorFecha.Checked
        fechaInicio = dtpFechaInicio.Value
        fechaFin = dtpFechaFin.Value

        'Estatus Pedido
        filtroEstatus = RecuperarFiltroGrid(grdEstatusPedido)

        'Pedidos
        filtroPedidoSAY = RecuperarFiltroGrid(grdPedidoSAY)

        ' Pedido SICY
        filtroPedidoSICY = RecuperarFiltroGrid(grdPedidoSICY)

        ' Cliente
        filtroCliente = RecuperarFiltroGrid(grdCliente)

        Try
            Cursor = Cursors.WaitCursor

            dtResultado = objBu.ConsultarFoliosCancelacion(buscarPorFecha, fechaInicio, fechaFin, filtroEstatus, filtroPedidoSAY, filtroPedidoSICY, filtroCliente)

            If dtResultado.Rows.Count > 0 Then
                dtResultado.DefaultView.Sort = "pedidoSAY DESC"
                grdFolios.DataSource = dtResultado
                DisenioGrid()
                OcultarFiltros()
                chkSeleccionarTodo.Checked = False
            Else
                Tools.MostrarMensaje(Tools.Mensajes.Notice, "No se encontraron resultados.")
            End If

            ActualizarConteoyFechaConsulta()

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub AbrirFormDetalle()
        Dim fila As Integer = 0
        Dim folioCancelacionId As String = String.Empty
        Dim contador As Integer = 0

        For index = 0 To grdDatosFolios.RowCount - 1
            If CBool(grdDatosFolios.GetRowCellValue(index, "seleccionar")) Then
                folioCancelacionId += "," + grdDatosFolios.GetRowCellValue(index, "folioCancelacion").ToString
            End If
        Next

        If folioCancelacionId <> String.Empty Then
            folioCancelacionId = folioCancelacionId.Substring(1)

            Dim vistaDetalle As New AdministradorFoliosCancelacionDetalle_Form
            vistaDetalle.AsignarFolioCancelacionId(folioCancelacionId)
            vistaDetalle.ShowDialog()
        Else
            Tools.MostrarMensaje(Tools.Mensajes.Notice, "No se ha seleccionado ningún folio.")
        End If
    End Sub

    Private Sub AbrirFormDetalleDobleClic(fila As Integer)
        Dim folioCancelacionId As String = String.Empty

        folioCancelacionId = "," + grdDatosFolios.GetRowCellValue(fila, "folioCancelacion").ToString

        If folioCancelacionId <> String.Empty Then
            folioCancelacionId = folioCancelacionId.Substring(1)

            Dim vistaDetalle As New AdministradorFoliosCancelacionDetalle_Form
            vistaDetalle.AsignarFolioCancelacionId(folioCancelacionId)
            vistaDetalle.ShowDialog()
        Else
            Tools.MostrarMensaje(Tools.Mensajes.Notice, "No se ha seleccionado ningún folio.")
        End If
    End Sub

    Private Sub ExportarExcel()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            If grdDatosFolios.RowCount > 0 Then
                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If grdDatosFolios.RowCount > 0 Then

                            'ESTO ES NECESARIO PARA QUE EL EXCEL NO HAGA QUE TODAS LAS CUADRICULAS SEAN MUY PEQUEÑAS.
                            'ESTO EXPORTARÁ TODAS LAS CUADRICULAS ESPACIADAS UNIFORMENTE.
                            grdDatosFolios.OptionsPrint.AutoWidth = False
                            grdDatosFolios.OptionsPrint.UsePrintStyles = False

                            Dim FileName As String = .SelectedPath + "\Datos_FoliosCancelacion_" + fecha_hora + ".xlsx"

                            Export.ExportSettings.DefaultExportType = Export.ExportType.WYSIWYG
                            grdDatosFolios.ExportToXlsx(FileName)

                            Tools.MostrarMensaje(Tools.Mensajes.Success, "Los datos se exportaron correctamente.")

                            Process.Start(FileName)

                        Else
                            Tools.MostrarMensaje(Tools.Mensajes.Notice, "No hay registros para exportar.")
                        End If
                    End If
                End With
            Else
                Tools.MostrarMensaje(Tools.Mensajes.Notice, "No hay datos para exportar")
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Tools.Mensajes.Fault, "No se pudo exportar los datos: " + ex.Message.ToString())
        End Try
    End Sub
#End Region

#Region "Disenio"
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

    Public Sub asignaFormato_Columna(ByVal grid As UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("String") Then

                If col.Header.Caption.Equals("Télefono") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("Extensión") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If
            End If

        Next
    End Sub

    Private Sub DisenioGrid()
        Tools.DiseñoGrid.DiseñoBaseGridSinBestFit(grdDatosFolios)

        grdDatosFolios.Columns(0).OptionsColumn.AllowEdit = True

        repositorioChkSeleccionar.DisplayValueChecked = "Sí"
        repositorioChkSeleccionar.DisplayValueUnchecked = "No"
        grdDatosFolios.Columns("seleccionar").Caption = " "
        grdDatosFolios.Columns("seleccionar").BestFit()
        grdDatosFolios.Columns("folioCancelacion").Caption = "Folio" + vbCrLf + "Cancelación"
        grdDatosFolios.Columns("folioCancelacion").Width = 80
        grdDatosFolios.Columns("cliente").Caption = "Cliente"
        grdDatosFolios.Columns("cliente").BestFit()
        grdDatosFolios.Columns("pedidoSAY").Caption = "Pedido" + vbCrLf + "SAY"
        grdDatosFolios.Columns("pedidoSAY").Width = 80
        grdDatosFolios.Columns("pedidoSICY").Caption = "Pedido" + vbCrLf + "SICY"
        grdDatosFolios.Columns("usuarioCancelo").Caption = "Usuario" + vbCrLf + "Canceló"
        grdDatosFolios.Columns("fechaCreacion").Caption = "F Cancelación"
        grdDatosFolios.Columns("solicita").Caption = "Solicita"
        grdDatosFolios.Columns("motivoCancelacion").Caption = "Motivo" + vbCrLf + "Cancelación"
        grdDatosFolios.Columns("pares").Caption = "Pares"
        grdDatosFolios.Columns("observacion").Caption = "Observación"
        grdDatosFolios.Columns("ordenTrabajo").Caption = "Orden" + vbCrLf + "Trabajo"

        grdDatosFolios.Columns("pares").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosFolios.Columns("pares").DisplayFormat.FormatString = "n0"

        CrearSummarAlPiePantalla()

        grdDatosFolios.Columns("seleccionar").ColumnEdit = repositorioChkSeleccionar

        grdDatosFolios.Columns("motivoCancelacion").BestFit()
        grdDatosFolios.Columns("solicita").BestFit()
        grdDatosFolios.Columns("observacion").Width = 200
    End Sub

    Private Sub CrearSummarAlPiePantalla()
        Dim item As GridGroupSummaryItem
        Dim str As String = String.Empty

        grdDatosFolios.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        grdDatosFolios.GroupSummary.Clear()

        For index = 0 To grdDatosFolios.Columns.Count - 1
            If grdDatosFolios.Columns(index).DisplayFormat.FormatType = Utils.FormatType.Numeric Then
                item = New GridGroupSummaryItem

                str = grdDatosFolios.Columns(index).Name.Replace("col", "")

                grdDatosFolios.Columns(index).Summary.Clear()
                grdDatosFolios.Columns(index).Summary.Add(Data.SummaryItemType.Sum, str, "{0:" + grdDatosFolios.Columns(index).DisplayFormat.FormatString + "}")

                item.FieldName = str
                item.ShowInGroupColumnFooter = grdDatosFolios.Columns("c")
                item.SummaryType = Data.SummaryItemType.Sum
                item.DisplayFormat = "Total {0:N}"
                grdDatosFolios.GroupSummary.Add(item)
            End If
        Next

    End Sub

    Private Sub grdEstatusPedido_KeyDown_1(sender As Object, e As KeyEventArgs) Handles grdEstatusPedido.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdEstatusPedido.DeleteSelectedRows(False)
    End Sub

    Private Sub grdDatosFolios_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdDatosFolios.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        Dim checked As Boolean = chkSeleccionarTodo.Checked

        For index = 0 To grdDatosFolios.RowCount - 1
            grdDatosFolios.SetRowCellValue(index, "seleccionar", checked)
        Next
    End Sub

    Private Sub grdDatosFolios_RowClick(sender As Object, e As RowClickEventArgs) Handles grdDatosFolios.RowClick
        If e.Clicks > 1 Then
            AbrirFormDetalleDobleClic(e.RowHandle)
        End If
    End Sub
#End Region
End Class