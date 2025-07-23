Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class SalidasCoppelForm
    Dim fecha As New DataTable
    Dim filtro As Boolean = False

    Public Sub cargarTiendas()
        Dim objBu = New Negocios.OTCoppelBU

        Dim dtComboDistribuciones As New DataTable
        If txtPedido.Text <> "" Then
            dtComboDistribuciones = objBu.RecuperaTiendasPedido(txtPedido.Text)
            dtComboDistribuciones.Rows.InsertAt(dtComboDistribuciones.NewRow, 0)
            cmbTienda.DataSource = dtComboDistribuciones
            cmbTienda.DisplayMember = "Nombre_Tienda"
            cmbTienda.ValueMember = "idtblTienda"
            fecha = objBu.RecuperaFechaEntrega(txtPedido.Text)
            If fecha.Rows.Count > 0 Then
                lblFechaE.Text = CDate(fecha.Rows(0).Item(0)).ToLongDateString
                lblFechaE.Visible = True
                lblFechaEntrega.Visible = True
            End If
        Else
            dtComboDistribuciones = objBu.geTiendaCoppel()
            dtComboDistribuciones.Rows.InsertAt(dtComboDistribuciones.NewRow, 0)
            cmbTienda.DataSource = dtComboDistribuciones
            cmbTienda.DisplayMember = "Nombre_Tienda"
            cmbTienda.ValueMember = "idtblTienda"
        End If
    End Sub

    Public Sub poblarGridSalidas()
        Dim estatus As String = ""
        Dim idTienda As Int32 = 0
        Dim idpedido As String = ""
        Dim objBU As New Negocios.OTCoppelBU
        Dim tablaSalidas As New DataTable
        Dim fechaInicio, FechaFin As DateTime
        grdSalidas.DataSource = Nothing
        If cmbEstatusSalida.SelectedIndex > 0 Then
            estatus = cmbEstatusSalida.SelectedItem
        Else
            estatus = ""
        End If

        If cmbTienda.SelectedIndex > 0 Then
            idTienda = cmbTienda.SelectedValue
        Else
            idTienda = 0
        End If

        If txtPedido.Text <> "" Then
            idpedido = txtPedido.Text
        Else
            idpedido = 0
        End If

        If chkFiltroFechas.Checked = True Then
            fechaInicio = dtpFechaInicio.Value.ToShortDateString
            FechaFin = dtpFechaFin.Value.ToShortDateString
            filtro = True

        Else
            filtro = False

        End If

        tablaSalidas = objBU.CargarSalidasCoppel(estatus, idpedido, idTienda, fechaInicio, FechaFin, filtro)
        If tablaSalidas.Rows.Count > 0 Then

            grdSalidas.DataSource = tablaSalidas
            formatoGridSalidas()
            If txtPedido.Text <> "" Then
                fecha = objBU.RecuperaFechaEntrega(txtPedido.Text)
                lblFechaE.Text = CDate(fecha.Rows(0).Item(0)).ToLongDateString
                lblFechaE.Visible = True
                lblFechaEntrega.Visible = True
            End If
        Else
            MostrarMesaje("Advertencia", "La consulta no devolvió resultados")

            lblFechaE.Visible = False
            lblFechaEntrega.Visible = False
        End If
        lblTotalRegistros.Text = Format(0, "###,###,##0")
    End Sub

    Public Sub validarSalidaPares()

        Dim confirmacion As New ConfirmarForm
        Dim list As New List(Of Entidades.SalidaDePares)
        Dim paresSalida As DataTable
        Dim objBU As New Negocios.OTCoppelBU
        Dim idOtCoppel As Int32
        Dim totalPares As Int32 = 0
        Dim ban As Integer = 0
        For Each row As UltraGridRow In grdSalidas.Rows.GetFilteredInNonGroupByRows
            If row.Cells("Seleccion").Value Then
                If row.Cells("estatus").Value = "E" Then
                    row.Cells("Seleccion").Value = False
                ElseIf row.Cells("estatus").Value = "C" Then
                    Dim salidaPares As New Entidades.SalidaDePares
                    idOtCoppel = row.Cells("Id OT").Value
                    totalPares += row.Cells("Pares").Value
                    paresSalida = objBU.ParesADarSalida(idOtCoppel)
                    salidaPares.pParesdeSalida = paresSalida
                    salidaPares.pidOTCoppel = idOtCoppel
                    list.Add(salidaPares)
                    ban += 1
                End If
            End If
        Next

        If ban > 0 Then
            confirmacion.mensaje = "¿Está seguro de generar la salida de " & ban & " OT seleccionadas por " & totalPares & " pares en total?"
            If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                For Each salidas As Entidades.SalidaDePares In list
                    DarSalidaPares(salidas.pParesdeSalida, salidas.pidOTCoppel)
                Next


                Dim ListaPedidosSICY = grdSalidas.Rows.AsEnumerable().Where(Function(x) CBool(x.Cells("Seleccion").Value) = True).Select(Function(y) y.Cells("Pedido").Value).Distinct.ToList

                For Each PedidoSICY As Integer In ListaPedidosSICY
                    objBU.ActualizarParesEntregadosPedido(PedidoSICY)
                    objBU.ReplicarEstatusPedidoSAY_SICY(PedidoSICY)
                Next




                poblarGridSalidas()
                Me.Cursor = Cursors.Default


            End If
        Else
            MostrarMesaje("Advertencia", "No se encontraron OT validas para generar salida.")
        End If
    End Sub

    Public Sub DarSalidaPares(ByVal pares As DataTable, ByVal idOTCoppel As Int32)
        Dim pos As Integer = 0
        Dim objBu As New Negocios.OTCoppelBU
        Dim cadenaPares As String = ""
        Me.Cursor = Cursors.WaitCursor
        For cont = 0 To pares.Rows.Count - 1
            cadenaPares = cadenaPares + "'" + pares.Rows(pos).Item(0).ToString + "' ,"
            pos = pos + 1
        Next
        cadenaPares = cadenaPares + "'0'"
        objBu.ActualizaEstatusParesTmpdocenaparesCoppel(cadenaPares, idOTCoppel)
        Me.Cursor = Cursors.Default
    End Sub
    Public Sub formatoGridSalidas()
        With grdSalidas.DisplayLayout.Bands(0)
            '.Columns("otco_idotcoppel").Hidden = True
            .Columns("otco_idtienda").Hidden = True
            .Columns("pares_salida").Hidden = True
            .Columns("estatus").Hidden = True
            .Columns("pares_Confirmados").Hidden = True
            .Columns("Seleccion").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Id OT").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Pedido").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Pares").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Seleccion").Style = ColumnStyle.CheckBox
            .Columns("Seleccion").Header.Caption = " "
            .Columns("Seleccion").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("seleccion").Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor
            .Columns("Entrega").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Pedido").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Tienda").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("PedidoSAY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("otco_totalpares").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("pares_Confirmados").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("pares_Correctos").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("pares_Externos").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Salida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Pares").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Id OT").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Confirmación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ' .Columns("otco_totalPares").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("pares_Confirmados").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("pares_Correctos").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("pares_Externos").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Confirmación").Format = "dd/MM/yy H:mm"
            .Columns("Salida").Format = "dd/MM/yy H:mm"
        End With


        grdSalidas.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdSalidas.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdSalidas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdSalidas.DisplayLayout.Override.RowSelectorWidth = 35
        grdSalidas.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grdSalidas.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grdSalidas.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grdSalidas.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grdSalidas.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdSalidas.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grdSalidas.DisplayLayout.GroupByBox.Hidden = False
        grdSalidas.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"

        grdSalidas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdSalidas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdSalidas.DisplayLayout.Override.RowSelectorWidth = 45
        grdSalidas.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdSalidas.Rows(0).Selected = True

        grdSalidas.DisplayLayout.Bands(0).Columns("Pares").Width = 35
        grdSalidas.DisplayLayout.Bands(0).Columns("pares_Correctos").Width = 35
        grdSalidas.DisplayLayout.Bands(0).Columns("pares_Externos").Width = 35
        grdSalidas.DisplayLayout.Bands(0).Columns("Id OT").Width = 18
        grdSalidas.DisplayLayout.Bands(0).Columns("Pedido").Width = 21
        grdSalidas.DisplayLayout.Bands(0).Columns("Usuario").Width = 40
        grdSalidas.DisplayLayout.Bands(0).Columns("Entrega").Width = 32
        grdSalidas.DisplayLayout.Bands(0).Columns("Salida").Width = 42
        grdSalidas.DisplayLayout.Bands(0).Columns("Confirmación").Width = 42
        'grdSalidas.DisplayLayout.Bands(0).Columns("otco_totalpares").Width = 30
        grdSalidas.DisplayLayout.Bands(0).Columns("seleccion").Width = 0.5
        grdSalidas.DisplayLayout.Bands(0).Columns("PedidoSAY").Width = 30

        grdSalidas.DisplayLayout.Bands(0).Columns("pares_Correctos").Header.Caption = "Correctos"
        grdSalidas.DisplayLayout.Bands(0).Columns("pares_Externos").Header.Caption = "Externos"


        Dim sumarPares As UltraGridColumn = grdSalidas.DisplayLayout.Bands(0).Columns("Pares")
        Dim sumarParesCorrectos As UltraGridColumn = grdSalidas.DisplayLayout.Bands(0).Columns("pares_Correctos")
        Dim sumarParesExternos As UltraGridColumn = grdSalidas.DisplayLayout.Bands(0).Columns("pares_Externos")
        Dim pares As SummarySettings = grdSalidas.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, sumarPares)
        pares.DisplayFormat = "{0:#,##0}"
        Dim paresCorrectos As SummarySettings = grdSalidas.DisplayLayout.Bands(0).Summaries.Add("Total Correctos", SummaryType.Sum, sumarParesCorrectos)
        paresCorrectos.DisplayFormat = "{0:#,##0}"
        Dim paresExternos As SummarySettings = grdSalidas.DisplayLayout.Bands(0).Summaries.Add("Total Externos", SummaryType.Sum, sumarParesExternos)
        paresExternos.DisplayFormat = "{0:#,##0}"

        pares.Appearance.TextHAlign = HAlign.Right
        paresCorrectos.Appearance.TextHAlign = HAlign.Right
        paresExternos.Appearance.TextHAlign = HAlign.Right
        grdSalidas.DisplayLayout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False
        'grdSalidas.DisplayLayout.Bands(0).SummaryFooterCaption = "Total"

        grdSalidas.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

    End Sub

    Public Sub limpiarVariables()
        txtPedido.Text = ""
        cmbTienda.DataSource = Nothing
        grdSalidas.DataSource = Nothing
        dtpFechaFin.Value = Now
        dtpFechaInicio.Value = Now
        chkFiltroFechas.Checked = False
        lblFechaEntrega.Visible = False
        lblFechaE.Visible = False
        pnlFiltroFecha.Visible = False
        pnlFiltroFecha.Enabled = False
        pnlFechas.Visible = False
        chkFiltroFechas.Checked = False
        cmbEstatusSalida.SelectedIndex = 0
        lblTotalRegistros.Text = 0
    End Sub
    Public Sub MostrarMesaje(ByVal tipo As String, ByVal mensaje As String)
        If tipo.ToString.Equals("Advertencia") Then
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = mensaje
            advertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("Aviso") Then
            Dim aviso As New AvisoForm
            aviso.mensaje = mensaje
            aviso.ShowDialog()
        End If

        If tipo.ToString.Equals("Exito") Then
            Dim exito As New ExitoForm
            exito.mensaje = mensaje
            exito.ShowDialog()
        End If

        If tipo.ToString.Equals("Error") Then
            Dim errores As New ErroresForm
            errores.mensaje = mensaje
            errores.ShowDialog()
        End If

    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grpParametros.Height = 128
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grpParametros.Height = 10
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim formaConfirmacion As New ConfirmarForm
        formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
        formaConfirmacion.mensaje = "¿Estas seguro que deseas salir?"
        If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub SalidasCoppelForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        pnlFechas.Visible = False
        lblFechaE.Visible = False
        lblFechaEntrega.Visible = False
        pnlFiltroFecha.Enabled = False
        pnlFiltroFecha.Visible = False
        Me.Top = 0
        Me.Left = 0
        cargarTiendas()
        'BackgroundWorker1.WorkerSupportsCancellation = True
        'BackgroundWorker1.WorkerReportsProgress = True
        'BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub cmbEstatusSalida_TextChanged(sender As Object, e As EventArgs) Handles cmbEstatusSalida.TextChanged
        If cmbEstatusSalida.SelectedItem = "CON SALIDA" Then
            pnlFechas.Visible = True
            pnlFiltroFecha.Visible = True
        Else
            pnlFechas.Visible = False
            chkFiltroFechas.Checked = False
            pnlFiltroFecha.Visible = False
            pnlFiltroFecha.Enabled = False
        End If
    End Sub

    Private Sub txtPedido_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPedido.KeyDown
        If (e.KeyValue = Keys.Enter) Then
            If cmbEstatusSalida.SelectedIndex > 0 Or txtPedido.Text <> "" Or cmbTienda.SelectedIndex > 0 Then
                poblarGridSalidas()
            Else
                MostrarMesaje("Advertencia", "Debes utilizar al menos uno de los filtros")
            End If
        End If
    End Sub

    Private Sub txtPedido_LostFocus(sender As Object, e As EventArgs) Handles txtPedido.LostFocus
        cargarTiendas()
    End Sub

    'Private Sub chkFiltroFechas_Click(sender As Object, e As EventArgs) Handles chkFiltroFechas.Click
    '    pnlFiltroFecha.Enabled = True
    '    pnlFiltroFecha.Visible = True
    'End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Me.Cursor = Cursors.WaitCursor
        If cmbEstatusSalida.SelectedIndex > 0 Or txtPedido.Text <> "" Or cmbTienda.SelectedIndex > 0 Then
            poblarGridSalidas()
        Else
            MostrarMesaje("Advertencia", "Debes utilizar al menos uno de los filtros")
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarVariables()
    End Sub

    Private Sub btnGenerarSalida_Click(sender As Object, e As EventArgs) Handles btnGenerarSalida.Click
        validarSalidaPares()
    End Sub

    Private Sub btnDetallesSalida_Click(sender As Object, e As EventArgs) Handles btnDetallesSalida.Click
        Dim list As List(Of Entidades.DetallesDeSalida) = getDetallesSalidas()

        Try
            If list.Count > 0 Then
                Dim formDetallesSalida As New DetalleSalidaCoppelForm
                With formDetallesSalida
                    .listDetallesDeSalida = list
                    .ShowDialog()
                End With
            End If
        Catch a As Exception
            MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function getDetallesSalidas() As List(Of Entidades.DetallesDeSalida)
        Me.Cursor = Cursors.WaitCursor

        Dim list As New List(Of Entidades.DetallesDeSalida)()
        For Each row As UltraGridRow In grdSalidas.Rows.GetFilteredInNonGroupByRows
            If CBool(row.Cells("Seleccion").Value) Then
                If row.Cells("estatus").ToString.Equals("C") Then
                    MostrarMesaje("Advertencia", "No es posible ver los detalles del pedido " & row.Cells("otco_idpedido").Value & ", aún no cuenta con salida.")
                Else
                    Dim detallesDeSalida As New Entidades.DetallesDeSalida
                    detallesDeSalida.pPedido = row.Cells("Pedido").Value.ToString
                    detallesDeSalida.pNombreTienda = row.Cells("Tienda").Value.ToString
                    detallesDeSalida.pFechaEntrega = row.Cells("Entrega").Value.ToString
                    detallesDeSalida.pFechaSalida = row.Cells("Salida").Value.ToString
                    detallesDeSalida.pIdotCoppel = row.Cells("Id OT").Value.ToString
                    list.Add(detallesDeSalida)
                End If
            End If
        Next
        Me.Cursor = Cursors.Default
        Return list
    End Function

    Private Sub grdSalidas_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdSalidas.AfterCellUpdate
        Dim num As Integer = 0
        For Each row As UltraGridRow In grdSalidas.Rows.GetFilteredInNonGroupByRows
            If CBool(row.Cells("Seleccion").Value) Then
                num += 1
            End If
        Next
        lblTotalRegistros.Text = "" & num
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged
        For Each row As UltraGridRow In grdSalidas.Rows
            row.Cells("Seleccion").Value = False
        Next
        If chkSeleccionar.Checked Then
            For Each row As UltraGridRow In grdSalidas.Rows.GetFilteredInNonGroupByRows
                row.Cells("Seleccion").Value = True
            Next
        Else
            For Each row As UltraGridRow In grdSalidas.Rows.GetFilteredInNonGroupByRows
                row.Cells("Seleccion").Value = False
            Next
        End If
    End Sub

    Private Sub grdSalidas_CellChange(sender As Object, e As CellEventArgs) Handles grdSalidas.CellChange
        ContarRegistrosSeleccionados(e)
    End Sub

    Private Sub ContarRegistrosSeleccionados(ByVal e As CellEventArgs)
        Try
            Dim Seleccionados As Integer = 0
            If e.Cell.Column.ToString = "seleccion" Then
                If CBool(e.Cell.Value) Then
                    grdSalidas.ActiveRow.Cells("seleccion").Value = False
                Else
                    grdSalidas.ActiveRow.Cells("seleccion").Value = True
                End If
                For Each row As UltraGridRow In grdSalidas.Rows.GetFilteredInNonGroupByRows
                    If CBool(row.Cells("Seleccion").Value) Then
                        Seleccionados += 1
                    End If
                Next
                lblTotalRegistros.Text = Format(Seleccionados, "###,###,##0")
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub grdSalidas_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdSalidas.ClickCell
        Try
            Dim Seleccionados As Integer = 0
            For Each row As UltraGridRow In grdSalidas.Rows.GetFilteredInNonGroupByRows
                If CBool(row.Cells("Seleccion").Value) Then
                    Seleccionados += 1
                End If
            Next
            lblTotalRegistros.Text = Format(Seleccionados, "###,###,##0")
        Catch ex As Exception

        End Try

    End Sub
    Dim Seleccionados2 As Integer = 0
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        'Try
        '    For Each row As UltraGridRow In grdSalidas.Rows.GetFilteredInNonGroupByRows
        '        If CBool(row.Cells("Seleccion").Value) Then
        '            Seleccionados2 += 1
        '        End If
        '    Next
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'Try
        '    If Not BackgroundWorker1.IsBusy Then
        '        lblTotalRegistros.Text = Format(Seleccionados2, "###,###,##0")
        '        Seleccionados2 = 0
        '        BackgroundWorker1.RunWorkerAsync()
        '    End If
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub SalidasCoppelForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'BackgroundWorker1.CancelAsync()
        'BackgroundWorker1.Dispose()
    End Sub

    Private Sub chkFiltroFechas_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltroFechas.CheckedChanged
        If chkFiltroFechas.Checked Then
            pnlFiltroFecha.Enabled = True
        Else
            pnlFiltroFecha.Enabled = False
        End If
    End Sub

    Private Sub grdSalidas_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles grdSalidas.AfterRowFilterChanged
        Try
            Dim Seleccionados As Integer = 0
            For Each row As UltraGridRow In grdSalidas.Rows.GetFilteredInNonGroupByRows
                If CBool(row.Cells("Seleccion").Value) Then
                    Seleccionados += 1
                End If
            Next
            lblTotalRegistros.Text = Format(Seleccionados, "###,###,##0")
        Catch ex As Exception

        End Try
    End Sub

End Class