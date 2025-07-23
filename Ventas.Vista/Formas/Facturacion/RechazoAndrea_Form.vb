Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports Tools

Public Class RechazoAndrea_Form

#Region "VARIABLES GLOBALES"

    Public CantidadOTSeleccionadas As Integer
    Public OrdenTrabajoId As String
    Public OTSay As Integer = 0
    Public PedidoSAYId As Integer = 0
    Public PedidoSICYId As Integer = 0
    Public OrdenClienteSeleccion As String = 0

    Dim objBU As New Negocios.AdministradorOTFacturacionBU
    Dim lstPartidasSeleccionadasVerPares As New List(Of Integer)
    Dim lstPartidasSeleccionadasRechazarPares As New List(Of Integer)
    Dim lstParesSeleccionadosRechazar As New List(Of String)
    Dim dtResultadoConsultaPares As New DataTable()

#End Region


    Private Sub RechazoAndrea_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Cursor = Cursors.WaitCursor

        Dim dtResultadoConsultaPartidas As New DataTable()

        If CantidadOTSeleccionadas > 1 Then
            lblTextoTotalOTSeleccionadas.Visible = True
            lblTotalOTSeleccionadas.Visible = False
            lblTextoOTSAY.Visible = False
            lblOTSAY.Visible = False
            lblTextoPedidoSAY.Visible = False
            lblIdPedidoSAY.Visible = False
            lblTextoPedidoSICY.Visible = False
            lblIdPedidoSICY.Visible = False
            lblTextoOrdenCliente.Visible = False
            lblOrdenCliente.Visible = False
            lblTotalOTSeleccionadas.Visible = True
            lblTotalOTSeleccionadas.Text = CantidadOTSeleccionadas.ToString()
        Else
            lblTextoTotalOTSeleccionadas.Visible = False
            lblTotalOTSeleccionadas.Visible = True
            lblTextoOTSAY.Visible = True
            lblOTSAY.Visible = True
            lblOTSAY.Text = OrdenTrabajoId
            lblTextoPedidoSAY.Visible = True
            lblIdPedidoSAY.Visible = True
            lblIdPedidoSAY.Text = PedidoSAYId.ToString()
            lblTextoPedidoSICY.Visible = True
            lblIdPedidoSICY.Visible = True
            lblIdPedidoSICY.Text = PedidoSICYId.ToString()
            lblTextoOrdenCliente.Visible = True
            lblOrdenCliente.Visible = True
            lblOrdenCliente.Text = OrdenClienteSeleccion.ToString()
            lblTotalOTSeleccionadas.Visible = False
        End If

        dtResultadoConsultaPartidas = objBU.consultarPartidasRechazarAndrea(OrdenTrabajoId)
        grdPartidasOT.DataSource = dtResultadoConsultaPartidas
        DiseñoGridPartidas()
        dtResultadoConsultaPares = objBU.consultarParesPartidasRechazarAndrea(OrdenTrabajoId)

        splPartidasPares.SplitterDistance = splPartidasPares.Width

        Cursor = Cursors.Default

    End Sub

#Region "DISEÑO"
    Private Sub DiseñoGridPartidas()

        bgvPartidas.OptionsView.ColumnAutoWidth = True


        bgvPartidas.Columns.ColumnByFieldName("OrdenTrabajoDetalleID").Visible = False
        bgvPartidas.Columns.ColumnByFieldName("ClienteSAYID").Visible = False
        If CantidadOTSeleccionadas = 1 Then
            bgvPartidas.Columns.ColumnByFieldName("OrdenTrabajoSAYID").Visible = False
        End If

        bgvPartidas.Columns.ColumnByFieldName("OrdenTrabajoSAYID").Caption = "OT"
        bgvPartidas.Columns.ColumnByFieldName("TotalPares").Caption = "Total"
        bgvPartidas.Columns.ColumnByFieldName("OrdenCliente").Caption = "OC"
        bgvPartidas.Columns.ColumnByFieldName("Articulo").Caption = "Artículo"

        bgvPartidas.Columns.ColumnByFieldName("TotalPares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        bgvPartidas.Columns.ColumnByFieldName("TotalPares").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvPartidas.Columns.ColumnByFieldName("OrdenTrabajoSAYID").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvPartidas.Columns.ColumnByFieldName("Partida").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvPartidas.Columns.ColumnByFieldName("OrdenCliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvPartidas.Columns.ColumnByFieldName("Tienda").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvPartidas.Columns.ColumnByFieldName("Articulo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        bgvPartidas.Columns.ColumnByFieldName("TotalPares").DisplayFormat.FormatString = "N0"

        bgvPartidas.Columns.ColumnByFieldName(" ").OptionsFilter.AllowFilter = False
        bgvPartidas.Columns.ColumnByFieldName("Tienda").OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        bgvPartidas.Columns.ColumnByFieldName("Articulo").OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList

        bgvPartidas.Columns.ColumnByFieldName(" ").Width = 30
        If CantidadOTSeleccionadas > 1 Then
            bgvPartidas.Columns.ColumnByFieldName("OrdenTrabajoSAYID").Width = 60
        End If
        bgvPartidas.Columns.ColumnByFieldName("Partida").Width = 60
        bgvPartidas.Columns.ColumnByFieldName("TotalPares").Width = 60
        bgvPartidas.Columns.ColumnByFieldName("OrdenCliente").Width = 60
        bgvPartidas.Columns.ColumnByFieldName("Tienda").Width = 200
        bgvPartidas.Columns.ColumnByFieldName("Articulo").Width = 250

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvPartidas.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            If col.FieldName <> " " Then
                col.OptionsColumn.AllowEdit = False
            Else
                col.OptionsColumn.AllowEdit = True
            End If
        Next

        bgvPartidas.IndicatorWidth = 40

        bgvPartidas.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        If IsNothing(bgvPartidas.Columns("TotalPares").Summary.FirstOrDefault(Function(x) x.FieldName = "TotalPares")) = True Then
            bgvPartidas.Columns("TotalPares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalPares", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "TotalPares"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            bgvPartidas.GroupSummary.Add(item)
        End If

    End Sub

    Private Sub bgvPartidas_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles bgvPartidas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub DiseñoGridPares()

        'bgvPares.OptionsView.ColumnAutoWidth = True

        bgvPares.Columns.ColumnByFieldName("OrdenTrabajoDetalleID").Visible = False
        If CantidadOTSeleccionadas = 1 Then
            bgvPares.Columns.ColumnByFieldName("OrdenTrabajoSAYID").Visible = False
        End If

        bgvPares.Columns.ColumnByFieldName("OrdenTrabajoSAYID").Caption = "OT"
        bgvPares.Columns.ColumnByFieldName("CodigoAtado").Caption = "Atado"
        bgvPares.Columns.ColumnByFieldName("CodigoPar").Caption = "Par"
        bgvPares.Columns.ColumnByFieldName("Calce").Caption = "Talla"
        bgvPares.Columns.ColumnByFieldName("Articulo").Caption = "Artículo"

        bgvPares.Columns.ColumnByFieldName("OrdenTrabajoSAYID").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvPares.Columns.ColumnByFieldName("Partida").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvPares.Columns.ColumnByFieldName("CodigoAtado").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvPares.Columns.ColumnByFieldName("CodigoPar").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvPares.Columns.ColumnByFieldName("Articulo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvPares.Columns.ColumnByFieldName("Calce").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvPares.Columns.ColumnByFieldName("Lote").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvPares.Columns.ColumnByFieldName("Nave").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvPares.Columns.ColumnByFieldName("Año").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals

        bgvPares.Columns.ColumnByFieldName(" ").OptionsFilter.AllowFilter = False
        bgvPares.Columns.ColumnByFieldName("Articulo").OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList

        bgvPares.Columns.ColumnByFieldName(" ").Width = 40
        If CantidadOTSeleccionadas > 1 Then
            bgvPares.Columns.ColumnByFieldName("OrdenTrabajoSAYID").Width = 60
        End If
        bgvPares.Columns.ColumnByFieldName("Partida").Width = 60
        bgvPares.Columns.ColumnByFieldName("CodigoAtado").Width = 80
        bgvPares.Columns.ColumnByFieldName("CodigoPar").Width = 80
        bgvPares.Columns.ColumnByFieldName("Articulo").Width = 300
        bgvPares.Columns.ColumnByFieldName("Calce").Width = 60
        bgvPares.Columns.ColumnByFieldName("Lote").Width = 60
        bgvPares.Columns.ColumnByFieldName("Nave").Width = 60
        bgvPares.Columns.ColumnByFieldName("Año").Width = 60

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvPares.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            If col.FieldName <> " " Then
                col.OptionsColumn.AllowEdit = False
            Else
                col.OptionsColumn.AllowEdit = True
            End If
        Next

        bgvPares.IndicatorWidth = 40

        bgvPares.OptionsView.ShowFooter = GroupFooterShowMode.Hidden

    End Sub

    Private Sub bgvPares_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles bgvPares.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub MostrarParesPorPartida()

        Dim detallesOrdentrabajoSeleccionadas As String = String.Empty
        Dim dtParesMostrar As New DataTable

        'For Each detalle As Integer In lstPartidasSeleccionadasVerPares
        'If detallesOrdentrabajoSeleccionadas <> "" Then
        'detallesOrdentrabajoSeleccionadas += ","
        'End If
        'detallesOrdentrabajoSeleccionadas += detalle.ToString()
        'Next

        grdPares.DataSource = Nothing

        For Each col As DataColumn In dtResultadoConsultaPares.Columns
            dtParesMostrar.Columns.Add(col.ColumnName, col.DataType)
        Next



        For Each detalle As DataRow In dtResultadoConsultaPares.Rows
            If lstPartidasSeleccionadasVerPares.Contains(detalle.Item("OrdenTrabajoDetalleID")) Then
                dtParesMostrar.ImportRow(detalle)
            End If
        Next

        grdPares.DataSource = dtParesMostrar
        DiseñoGridPares()

    End Sub

#End Region

    Private Sub bgvPartidas_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles bgvPartidas.CellValueChanging

        Cursor = Cursors.WaitCursor

        If e.Column.FieldName = " " Then
            If CBool(e.Value) = True Then

                'lblTotalPartidasSeleccionadas.Text = (CInt(Replace(lblTotalPartidasSeleccionadas.Text, ",", "")) + 1).ToString()
                If lstPartidasSeleccionadasVerPares.Contains(bgvPartidas.GetRowCellValue(e.RowHandle, "OrdenTrabajoDetalleID")) = False Then
                    lstPartidasSeleccionadasVerPares.Add(bgvPartidas.GetRowCellValue(e.RowHandle, "OrdenTrabajoDetalleID"))
                End If

                bgvPartidas.SetRowCellValue(e.RowHandle, " ", True)
            Else

                'lblTotalPartidasSeleccionadas.Text = If(CInt(Replace(lblTotalPartidasSeleccionadas.Text, ",", "")) - 1 > 0, CInt(Replace(lblTotalPartidasSeleccionadas.Text, ",", "")) - 1, 0).ToString()
                If lstPartidasSeleccionadasVerPares.Contains(bgvPartidas.GetRowCellValue(e.RowHandle, "OrdenTrabajoDetalleID")) = True Then
                    lstPartidasSeleccionadasVerPares.Remove(bgvPartidas.GetRowCellValue(e.RowHandle, "OrdenTrabajoDetalleID"))
                End If

                bgvPartidas.SetRowCellValue(e.RowHandle, " ", False)

            End If

            lblTotalPartidasSeleccionadas.Text = lstPartidasSeleccionadasVerPares.Count.ToString("n0")

            If lstPartidasSeleccionadasVerPares.Count > 0 Then
                MostrarParesPorPartida()
                splPartidasPares.SplitterDistance = splPartidasPares.Width / 2
                pnlRechazarPares.Visible = True
                pnlRechazarPares.Location = New Point(splPartidasPares.Width / 2, pnlRechazarPares.Location.Y)
            Else
                grdPares.DataSource = Nothing
                splPartidasPares.SplitterDistance = splPartidasPares.Width
                pnlRechazarPares.Visible = False
            End If

        End If

        Cursor = Cursors.Default

    End Sub

    Private Sub chboxSeleccionarTodoPartidas_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodoPartidas.CheckedChanged
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = bgvPartidas.DataRowCount
            lblTotalPartidasSeleccionadas.Text = "0"
            lstPartidasSeleccionadasVerPares = New List(Of Integer)

            For index As Integer = 0 To NumeroFilas Step 1
                bgvPartidas.SetRowCellValue(bgvPartidas.GetVisibleRowHandle(index), " ", chboxSeleccionarTodoPartidas.Checked)
                If index > 0 Then
                    If chboxSeleccionarTodoPartidas.Checked = True Then
                        lblTotalPartidasSeleccionadas.Text = (CInt(Replace(lblTotalPartidasSeleccionadas.Text, ",", "")) + 1).ToString("n0")

                        If lstPartidasSeleccionadasVerPares.Contains(bgvPartidas.GetRowCellValue(bgvPartidas.GetVisibleRowHandle(index), "OrdenTrabajoDetalleID")) = False Then
                            lstPartidasSeleccionadasVerPares.Add(bgvPartidas.GetRowCellValue(bgvPartidas.GetVisibleRowHandle(index), "OrdenTrabajoDetalleID"))
                        End If
                    Else
                        lblTotalPartidasSeleccionadas.Text = If(CInt(Replace(lblTotalPartidasSeleccionadas.Text, ",", "")) - 1 > 0, CInt(Replace(lblTotalPartidasSeleccionadas.Text, ",", "")) - 1, 0).ToString("n0")

                        If lstPartidasSeleccionadasVerPares.Contains(bgvPartidas.GetRowCellValue(bgvPartidas.GetVisibleRowHandle(index), "OrdenTrabajoDetalleID")) = True Then
                            lstPartidasSeleccionadasVerPares.Remove(bgvPartidas.GetRowCellValue(bgvPartidas.GetVisibleRowHandle(index), "OrdenTrabajoDetalleID"))
                        End If
                    End If

                End If

            Next

            If lstPartidasSeleccionadasVerPares.Count > 0 Then
                MostrarParesPorPartida()
                splPartidasPares.SplitterDistance = splPartidasPares.Width / 2
                pnlRechazarPares.Visible = True
                pnlRechazarPares.Location = New Point(splPartidasPares.Width / 2, pnlRechazarPares.Location.Y)
            Else
                grdPares.DataSource = Nothing
                splPartidasPares.SplitterDistance = splPartidasPares.Width
                pnlRechazarPares.Visible = False
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub chboxSeleccionarTodoPares_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodoPares.CheckedChanged
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = bgvPares.DataRowCount - 1
            lblTotalParesSeleccionados.Text = "0"
            lstParesSeleccionadosRechazar = New List(Of String)
            lstPartidasSeleccionadasRechazarPares = New List(Of Integer)

            For index As Integer = 0 To NumeroFilas Step 1
                bgvPares.SetRowCellValue(bgvPares.GetVisibleRowHandle(index), " ", chboxSeleccionarTodoPares.Checked)
                ' If index > 0 Then
                If chboxSeleccionarTodoPares.Checked = True Then
                    lblTotalParesSeleccionados.Text = (CInt(Replace(lblTotalParesSeleccionados.Text, ",", "")) + 1).ToString("n0")

                    If lstParesSeleccionadosRechazar.Contains(bgvPares.GetRowCellValue(bgvPares.GetVisibleRowHandle(index), "CodigoPar")) = False Then
                        lstParesSeleccionadosRechazar.Add(bgvPares.GetRowCellValue(bgvPares.GetVisibleRowHandle(index), "CodigoPar"))
                    End If
                    If lstPartidasSeleccionadasRechazarPares.Contains(bgvPares.GetRowCellValue(bgvPares.GetVisibleRowHandle(index), "OrdenTrabajoDetalleID")) = False Then
                        lstPartidasSeleccionadasRechazarPares.Add(bgvPares.GetRowCellValue(bgvPares.GetVisibleRowHandle(index), "OrdenTrabajoDetalleID"))
                    End If
                Else
                    lblTotalParesSeleccionados.Text = If(CInt(Replace(lblTotalParesSeleccionados.Text, ",", "")) - 1 > 0, CInt(Replace(lblTotalParesSeleccionados.Text, ",", "")) - 1, 0).ToString("n0")

                    If lstParesSeleccionadosRechazar.Contains(bgvPares.GetRowCellValue(bgvPares.GetVisibleRowHandle(index), "CodigoPar")) = True Then
                        lstParesSeleccionadosRechazar.Remove(bgvPares.GetRowCellValue(bgvPares.GetVisibleRowHandle(index), "CodigoPar"))
                    End If
                    If lstPartidasSeleccionadasRechazarPares.Contains(bgvPares.GetRowCellValue(bgvPares.GetVisibleRowHandle(index), "OrdenTrabajoDetalleID")) = True Then
                        lstPartidasSeleccionadasRechazarPares.Remove(bgvPares.GetRowCellValue(bgvPares.GetVisibleRowHandle(index), "OrdenTrabajoDetalleID"))
                    End If
                End If

                'End If

            Next

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnRechazarPartidas_Click(sender As Object, e As EventArgs) Handles btnRechazarPartidas.Click

        Dim detallesOTSeleccionados As String = String.Empty
        Dim dtResultadoRechazo As New DataTable()
        Dim dtResultadoConsultaPartidas As New DataTable()
        Dim confirmacion As New ConfirmarForm

        Try

            If lstPartidasSeleccionadasVerPares.Count > 0 Then

                If lstPartidasSeleccionadasVerPares.Count = 1 Then
                    confirmacion.mensaje = "¿Desea rechazar la partida seleccionada?"
                Else
                    confirmacion.mensaje = "¿Desea rechazar las " + lstPartidasSeleccionadasVerPares.Count.ToString() + " partidas seleccionadas?"
                End If

                If confirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    For Each detalle As Integer In lstPartidasSeleccionadasVerPares
                        If detallesOTSeleccionados <> "" Then
                            detallesOTSeleccionados += ","
                        End If
                        detallesOTSeleccionados += detalle.ToString()
                    Next

                    dtResultadoRechazo = objBU.rechazarPartidasAndrea(detallesOTSeleccionados)

                    show_message(dtResultadoRechazo.Rows(0).Item("Resultado"), dtResultadoRechazo.Rows(0).Item("ResultadoTexto"))

                    chboxSeleccionarTodoPartidas.Checked = False
                    chboxSeleccionarTodoPartidas.Checked = False

                    grdPartidasOT.DataSource = Nothing
                    dtResultadoConsultaPartidas = objBU.consultarPartidasRechazarAndrea(OrdenTrabajoId)
                    grdPartidasOT.DataSource = dtResultadoConsultaPartidas
                    DiseñoGridPartidas()
                    dtResultadoConsultaPares = objBU.consultarParesPartidasRechazarAndrea(OrdenTrabajoId)
                    pnlRechazarPares.Visible = False

                    splPartidasPares.SplitterDistance = splPartidasPares.Width
                End If

            Else
                show_message("Advertencia", "No hay partidas seleccionadas para rechazar.")
            End If

        Catch ex As Exception
            show_message("Error", "Ocurrió un error, intente de nuevo")
        End Try

    End Sub

    Private Sub bgvPares_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles bgvPares.CellValueChanging

        Cursor = Cursors.WaitCursor

        If e.Column.FieldName = " " Then
            If CBool(e.Value) = True Then

                'lblTotalPartidasSeleccionadas.Text = (CInt(Replace(lblTotalPartidasSeleccionadas.Text, ",", "")) + 1).ToString()
                If lstParesSeleccionadosRechazar.Contains(bgvPares.GetRowCellValue(e.RowHandle, "CodigoPar")) = False Then
                    lstParesSeleccionadosRechazar.Add(bgvPares.GetRowCellValue(e.RowHandle, "CodigoPar"))
                End If
                If lstPartidasSeleccionadasRechazarPares.Contains(bgvPares.GetRowCellValue(e.RowHandle, "OrdenTrabajoDetalleID")) = False Then
                    lstPartidasSeleccionadasRechazarPares.Add(bgvPares.GetRowCellValue(e.RowHandle, "OrdenTrabajoDetalleID"))
                End If

                bgvPares.SetRowCellValue(e.RowHandle, " ", True)
            Else

                'lblTotalPartidasSeleccionadas.Text = If(CInt(Replace(lblTotalPartidasSeleccionadas.Text, ",", "")) - 1 > 0, CInt(Replace(lblTotalPartidasSeleccionadas.Text, ",", "")) - 1, 0).ToString()
                If lstParesSeleccionadosRechazar.Contains(bgvPares.GetRowCellValue(e.RowHandle, "CodigoPar")) = True Then
                    lstParesSeleccionadosRechazar.Remove(bgvPares.GetRowCellValue(e.RowHandle, "CodigoPar"))
                End If
                If lstPartidasSeleccionadasRechazarPares.Contains(bgvPares.GetRowCellValue(e.RowHandle, "OrdenTrabajoDetalleID")) = True Then
                    lstPartidasSeleccionadasRechazarPares.Remove(bgvPares.GetRowCellValue(e.RowHandle, "OrdenTrabajoDetalleID"))
                End If

                bgvPares.SetRowCellValue(e.RowHandle, " ", False)

            End If

            lblTotalParesSeleccionados.Text = lstParesSeleccionadosRechazar.Count.ToString("n0")

        End If

        Cursor = Cursors.Default

    End Sub


    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub


    Private Sub btnRechazarPares_Click(sender As Object, e As EventArgs) Handles btnRechazarPares.Click

        Dim detallesOTSeleccionados As String = String.Empty
        Dim paresSeleccionados As String = String.Empty
        Dim dtResultadoRechazo As New DataTable()
        Dim dtResultadoConsultaPartidas As New DataTable()
        Dim confirmacion As New Tools.ConfirmarForm

        Try

            If lstParesSeleccionadosRechazar.Count > 0 And lstPartidasSeleccionadasRechazarPares.Count > 0 Then

                If lstParesSeleccionadosRechazar.Count = 1 Then
                    confirmacion.mensaje = "¿Desea rechazar el par seleccionado?"
                Else
                    confirmacion.mensaje = "¿Desea rechazar los " + lstParesSeleccionadosRechazar.Count.ToString() + " pares seleccionados?"
                End If

                If confirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    For Each par As String In lstParesSeleccionadosRechazar
                        If paresSeleccionados <> "" Then
                            paresSeleccionados += ","
                        End If
                        paresSeleccionados += par.ToString()
                    Next
                    For Each detalle As Integer In lstPartidasSeleccionadasRechazarPares
                        If detallesOTSeleccionados <> "" Then
                            detallesOTSeleccionados += ","
                        End If
                        detallesOTSeleccionados += detalle.ToString()
                    Next

                    dtResultadoRechazo = objBU.rechazarParesAndrea(detallesOTSeleccionados, paresSeleccionados)

                    show_message(dtResultadoRechazo.Rows(0).Item("Resultado"), dtResultadoRechazo.Rows(0).Item("ResultadoTexto"))

                    chboxSeleccionarTodoPartidas.Checked = False
                    chboxSeleccionarTodoPartidas.Checked = False

                    grdPartidasOT.DataSource = Nothing
                    dtResultadoConsultaPartidas = objBU.consultarPartidasRechazarAndrea(OrdenTrabajoId)
                    grdPartidasOT.DataSource = dtResultadoConsultaPartidas
                    DiseñoGridPartidas()
                    dtResultadoConsultaPares = objBU.consultarParesPartidasRechazarAndrea(OrdenTrabajoId)
                    pnlRechazarPares.Visible = False

                    splPartidasPares.SplitterDistance = splPartidasPares.Width

                End If

            Else
                show_message("Advertencia", "No hay pares seleccionadas para rechazar.")
            End If

        Catch ex As Exception
            show_message("Error", "Ocurrió un error, intente de nuevo")
        End Try


    End Sub

End Class