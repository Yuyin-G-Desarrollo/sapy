Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Programacion.Negocios
Imports Tools

Public Class Programacion_PlanFabricacion_CambiosFechaProgramacion
    Dim listaInicial As New List(Of String)
    Dim PartidasSeleccionadas As String = String.Empty
    Dim dtPedidosTmpCambiosFechaProgramacion As New DataTable
    Dim eventoActivo As Boolean = False
    Dim dtPoblarGridDetalles As New DataTable
    Dim ListaPedidoSAY As New List(Of String)
    Dim ParesSeleccionadosDetalles As Integer = 0


    Private Sub Programacion_PlanFabricacion_CambiosFechaProgramacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        lblUltimaActualizacion.Text = ""
        grdClientes.DataSource = listaInicial
        grdEstatus.DataSource = listaInicial
        grdPedidoSAY.DataSource = listaInicial
        'lblSemanaActual.Text = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        ConsultaPermisos()


        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.FixedPanel = FixedPanel.Panel1

        SplitContainer1.IsSplitterFixed = True
        SplitContainer1.Panel2Collapsed = True

    End Sub

    Private Sub ConsultaPermisos()  'Agregar el PERMISO 

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("CAM_PED_FEC_PROGR", "BTN_PENDIENTE_AUTORIZAR") Then
            pnlPendienteAutorizar.Visible = True
        Else
            pnlPendienteAutorizar.Visible = False
        End If
    End Sub

    Private Sub btnAgregarCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarCliente.Click
        Dim listado As New ListadoParametros_MovimientosColecciones
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 5

        For Each row As UltraGridRow In grdClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdClientes.DataSource = listado.listParametros
        With grdClientes
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Clientes"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimCliente_Click(sender As Object, e As EventArgs) Handles btnLimCliente.Click
        grdClientes.DataSource = listaInicial
    End Sub

    Private Sub grdClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        grid_diseño(grdClientes)
        grdClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Clientes"
    End Sub

    Private Sub grdClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles grdClientes.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdClientes.DeleteSelectedRows(False)
    End Sub

    Private Sub txtPedidoSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSAY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSAY.Text) Then Return
            ListaPedidoSAY.Add(txtPedidoSAY.Text)
            grdPedidoSAY.DataSource = Nothing
            grdPedidoSAY.DataSource = ListaPedidoSAY
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

    Private Sub grdEstatus_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdEstatus.InitializeLayout
        grid_diseño(grdEstatus)
        grdEstatus.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Estatus"
    End Sub

    Private Sub grdEstatus_KeyDown(sender As Object, e As KeyEventArgs) Handles grdEstatus.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdEstatus.DeleteSelectedRows(False)
    End Sub

    Private Sub btnAgregarEstatus_Click(sender As Object, e As EventArgs) Handles btnAgregarEstatus.Click
        Dim listado As New ListadoParametros_MovimientosColecciones
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 7

        For Each row As UltraGridRow In grdEstatus.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdEstatus.DataSource = listado.listParametros
        With grdEstatus
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Estatus"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimEstatus_Click(sender As Object, e As EventArgs) Handles btnLimEstatus.Click
        grdEstatus.DataSource = listaInicial
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
            End If

            If col.DataType.Name.ToString.Equals("String") Then
                col.CellAppearance.TextHAlign = HAlign.Left
            End If
        Next
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New PlanFabricacionBU
        Dim FPedidoSAY As String = String.Empty
        Dim FCliente As String = String.Empty
        Dim FClasificacion As String = String.Empty
        Dim FEstatus As String = String.Empty
        Dim MostrarClientesNOViables As Boolean = False

        Try
            Cursor = Cursors.WaitCursor

            vwCambiosFechaProgramacion.Columns.Clear()
            grdCambiosFechaProgramacion.DataSource = Nothing

            FCliente = ObtenerFiltrosGrid(grdClientes)
            FEstatus = ObtenerFiltrosGrid(grdEstatus)
            FPedidoSAY = ObtenerFiltrosGrid(grdPedidoSAY)

            If chkClientesNoViables.Checked = True Then
                MostrarClientesNOViables = True
            End If

            dtPedidosTmpCambiosFechaProgramacion = objBU.ObtieneTablaTemporal_CambioFechaProgramacion(FCliente, LTrim(RTrim(FPedidoSAY)), FEstatus, MostrarClientesNOViables)

            If dtPedidosTmpCambiosFechaProgramacion.Rows.Count > 0 Then
                grdCambiosFechaProgramacion.DataSource = dtPedidosTmpCambiosFechaProgramacion
                DisenioGrid()
                lblRegistros.Text = CDbl(vwCambiosFechaProgramacion.RowCount.ToString()).ToString("n0")
                lblUltimaActualizacion.Text = Date.Now
            Else
                show_message("Advertencia", "No hay información para mostrar.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub DisenioGridDetalles()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwMovimientosPares.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName <> " " Then
                col.OptionsColumn.AllowEdit = False
            Else
                col.OptionsColumn.AllowEdit = True
            End If
        Next

        vwMovimientosPares.Columns.ColumnByFieldName(" ").Width = 20
        vwMovimientosPares.Columns.ColumnByFieldName("Pedido SAY").Width = 60
        vwMovimientosPares.Columns.ColumnByFieldName("Pedido SICY").Width = 60
        vwMovimientosPares.Columns.ColumnByFieldName("Partida").Width = 60
        vwMovimientosPares.Columns.ColumnByFieldName("Semana").Width = 60
        vwMovimientosPares.Columns.ColumnByFieldName("Cliente").Width = 300
        vwMovimientosPares.Columns.ColumnByFieldName("Pares Partida").Width = 80
        vwMovimientosPares.Columns.ColumnByFieldName("Pares Colocados").Width = 80
        vwMovimientosPares.Columns.ColumnByFieldName("Fecha Entrega Cliente").Width = 80

        vwMovimientosPares.Columns("Pedido SAY").Caption = "Pedido" & vbCrLf & "SAY"
        vwMovimientosPares.Columns("Pedido SICY").Caption = "Pedido" & vbCrLf & "SICY"
        vwMovimientosPares.Columns("Fecha Entrega Cliente").Caption = "F Entrega" & vbCrLf & "Cliente"

        vwMovimientosPares.Columns("SemanaDetalleID").Visible = False
        vwMovimientosPares.Columns("ValidaCambioFP").Visible = False
        vwMovimientosPares.Columns("ValorOriginal").Visible = False
        vwMovimientosPares.Columns("NaveID").Visible = False


        vwMovimientosPares.Columns.ColumnByFieldName("Pares Partida").DisplayFormat.FormatString = "{0:n0}"
        vwMovimientosPares.Columns.ColumnByFieldName("Pares Colocados").DisplayFormat.FormatString = "{0:n0}"


        vwMovimientosPares.IndicatorWidth = 40

        DiseñoGrid.AlternarColorEnFilas(vwMovimientosPares)

    End Sub

    Private Sub DisenioGrid()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwCambiosFechaProgramacion.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName <> " " Then
                col.OptionsColumn.AllowEdit = False
            Else
                col.OptionsColumn.AllowEdit = True
            End If
        Next
        '
        vwCambiosFechaProgramacion.Columns.ColumnByFieldName(" ").Width = 20
        vwCambiosFechaProgramacion.Columns.ColumnByFieldName("Pedido SAY").Width = 60
        vwCambiosFechaProgramacion.Columns.ColumnByFieldName("Pedido SICY").Width = 60
        vwCambiosFechaProgramacion.Columns.ColumnByFieldName("Partida").Width = 60
        vwCambiosFechaProgramacion.Columns.ColumnByFieldName("Cliente").Width = 215
        vwCambiosFechaProgramacion.Columns.ColumnByFieldName("Pares Partida").Width = 80
        vwCambiosFechaProgramacion.Columns.ColumnByFieldName("Pares Colocados").Width = 80
        vwCambiosFechaProgramacion.Columns.ColumnByFieldName("Fecha Entrega Nueva").Width = 80
        vwCambiosFechaProgramacion.Columns.ColumnByFieldName("Fecha Entrega Cliente").Width = 80
        vwCambiosFechaProgramacion.Columns.ColumnByFieldName("Observaciones").Width = 160
        vwCambiosFechaProgramacion.Columns.ColumnByFieldName("Estatus").Width = 150

        vwCambiosFechaProgramacion.Columns("Pedido SAY").Caption = "Pedido" & vbCrLf & "SAY"
        vwCambiosFechaProgramacion.Columns("Pedido SICY").Caption = "Pedido" & vbCrLf & "SICY"

        vwCambiosFechaProgramacion.Columns("Fecha Entrega Cliente").Caption = "F Entrega" & vbCrLf & "Cliente"
        vwCambiosFechaProgramacion.Columns("Fecha Entrega Nueva").Caption = "F Entrega" & vbCrLf & "Nueva"

        vwCambiosFechaProgramacion.Columns("tmpID").Visible = False
        vwCambiosFechaProgramacion.Columns("FechaEntregaBuscar").Visible = False
        vwCambiosFechaProgramacion.Columns("NaveID").Visible = False
        vwCambiosFechaProgramacion.Columns("ValidaCambioFP").Visible = False
        vwCambiosFechaProgramacion.Columns("ValorOriginal").Visible = False

        vwCambiosFechaProgramacion.Columns.ColumnByFieldName("Pares Partida").DisplayFormat.FormatString = "{0:n0}"
        vwCambiosFechaProgramacion.Columns.ColumnByFieldName("Pares Colocados").DisplayFormat.FormatString = "{0:n0}"

        vwCambiosFechaProgramacion.IndicatorWidth = 30

        DiseñoGrid.AlternarColorEnFilas(vwCambiosFechaProgramacion)

    End Sub

    Private Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty
        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += "" + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                Resultado += "," + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next
        Return Resultado
    End Function


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
    End Sub


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlBotonesExpander.AutoSize = True
        pnlFiltros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlBotonesExpander.AutoSize = True
        pnlFiltros.Visible = True
    End Sub



    Private Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
        Dim objBU As New PlanFabricacionBU
        Dim NumeroFilas As Integer = 0
        Dim Confirmar As New ConfirmarForm
        Dim TmpID As Integer = 0
        Dim FechaEntregaBuscar As Date
        Dim NaveID As Integer = 0
        Dim listPedidoID As New List(Of Integer)
        Dim CantidadPares As Integer = 0

        If vwCambiosFechaProgramacion.RowCount > 0 Then

            Try
                Cursor = Cursors.WaitCursor

                NumeroFilas = vwCambiosFechaProgramacion.RowCount

                With vwCambiosFechaProgramacion
                    For index As Integer = 0 To NumeroFilas Step 1
                        If .GetRowCellValue(index, " ") Then
                            If listPedidoID.Contains(.GetRowCellValue(.GetVisibleRowHandle(index), "Pedido SAY").ToString()) = False Then
                                TmpID = .GetRowCellValue(index, "tmpID")
                                FechaEntregaBuscar = .GetRowCellValue(index, "FechaEntregaBuscar")
                                listPedidoID.Add(.GetRowCellValue(.GetVisibleRowHandle(index), "Pedido SAY").ToString())
                                NaveID = .GetRowCellValue(index, "NaveID")
                            End If
                            CantidadPares += .GetRowCellValue(index, "Pares Colocados")

                        End If
                    Next

                End With

                If listPedidoID.Count >= 2 Then
                    show_message("Advertencia", "Seleccione partidas de un solo pedido.")
                    Exit Sub
                End If


                dtPoblarGridDetalles = objBU.ObtenerSemanaMovimientoPares(TmpID, FechaEntregaBuscar, NaveID)

                If dtPoblarGridDetalles.Rows.Count > 0 Then

                    SplitContainer1.IsSplitterFixed = False
                    SplitContainer1.Panel2Collapsed = False
                    panelCantidadPares.Visible = True
                    pnlDetallesPares.Visible = True

                    vwMovimientosPares.Columns.Clear()
                    grdMovimientosPares.DataSource = Nothing

                    grdMovimientosPares.Visible = True
                    grdMovimientosPares.DataSource = dtPoblarGridDetalles
                    DisenioGridDetalles()

                    lblRegistros.Text = CDbl(vwCambiosFechaProgramacion.RowCount + vwMovimientosPares.RowCount).ToString("n0")
                    lblCantidadParesSeleccionados.Text = If(CantidadPares >= 1000, CantidadPares.ToString("##,###"), CantidadPares)

                    pnlBotonesExpander.AutoSize = True
                    pnlFiltros.Visible = False
                Else
                    show_message("Advertencia", "No hay información para mostrar.")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                Cursor = Cursors.Default
            End Try

        Else
            show_message("Advertencia", "Seleccione un registro")
        End If

    End Sub



    Private Sub btnPendienteAutorizar_Click(sender As Object, e As EventArgs) Handles btnPendienteAutorizar.Click
        Dim autorizacionMovimientos As New Programacion_PlanFabricacion_MovimientosManualesFechaProgramacion

        Try
            autorizacionMovimientos.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

        End Try


    End Sub


    Private Sub bntLimpiar_Click(sender As Object, e As EventArgs) Handles bntLimpiar.Click
        grdClientes.DataSource = listaInicial
        grdEstatus.DataSource = listaInicial
        grdPedidoSAY.DataSource = listaInicial
        vwCambiosFechaProgramacion.Columns.Clear()
        grdCambiosFechaProgramacion.DataSource = Nothing
        grdMovimientosPares.DataSource = Nothing
    End Sub


    Private Sub chSeleccionarTodo_CheckedChanged_1(sender As Object, e As EventArgs) Handles chSeleccionarTodo.CheckedChanged
        Dim activar = False
        If (chSeleccionarTodo.Checked) Then
            activar = True
        End If
        If (eventoActivo = False) Then
            eventoActivo = True
            For i As Integer = 0 To (vwCambiosFechaProgramacion.RowCount) Step 1
                vwCambiosFechaProgramacion.SetRowCellValue(i, " ", activar)
            Next
            eventoActivo = False
        End If
    End Sub

    Private Sub vwCambiosFechaProgramacion_CustomDrawRowIndicator_1(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwCambiosFechaProgramacion.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub vwMovimientosPares_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwMovimientosPares.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New PlanFabricacionBU
        Dim dtEnvioCambios As New DataTable
        Dim vXmlCeldasFechaProgramacion As XElement = New XElement("Celdas")
        Dim vXmlCeldasDetalles As XElement = New XElement("Celdas")
        Dim confirmar As New ConfirmarForm
        Dim dtResultadoSustitucion As New DataTable

        Dim UsuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        Try

            If vwCambiosFechaProgramacion.DataRowCount > 0 Then
                Cursor = Cursors.WaitCursor

                Dim DVFechaProgramacion As DataView = CType(vwCambiosFechaProgramacion.DataSource, DataView)
                Dim DTResultadoFechaProgramacion As DataTable = DVFechaProgramacion.Table.Copy()

                Dim DVDetalles As DataView = CType(vwMovimientosPares.DataSource, DataView)
                Dim DTResultadoDetalles As DataTable = DVDetalles.Table.Copy()

                If DTResultadoFechaProgramacion.Rows.Count > 0 And DTResultadoDetalles.Rows.Count > 0 Then

                    For Each item In DTResultadoFechaProgramacion.Rows
                        If item(" ").ToString = "True" Then
                            Dim vNodo As XElement = New XElement("Celda")
                            vNodo.Add(New XAttribute("TmpID", item("tmpID").ToString))
                            vXmlCeldasFechaProgramacion.Add(vNodo)
                        End If
                    Next


                    For Each item In DTResultadoDetalles.Rows
                        Dim VNodo As XElement = New XElement("Celda")
                        If item(" ").ToString = "True" Then
                            VNodo.Add(New XAttribute("SemanaDetalleID", item("SemanaDetalleID").ToString))

                            vXmlCeldasDetalles.Add(VNodo)
                        End If
                    Next

                    ParesSeleccionadosDetalles = CInt(lblCantidadParesDetalles.Text)

                    If CInt(ParesSeleccionadosDetalles) < CInt(lblCantidadParesSeleccionados.Text) Then
                        show_message("Advertencia", "Seleccione la misma o mayor cantidad de pares para realizar esta acción.")
                        Exit Sub
                    End If

                    confirmar.mensaje = "Se realizará el movimiento de " + ParesSeleccionadosDetalles.ToString + " pares, este proceso no se podrá revertir. ¿Desea continuar?  "
                    If confirmar.ShowDialog = DialogResult.OK Then
                        dtResultadoSustitucion = objBU.MovimientoPares_FechaEntregaProgramacion(vXmlCeldasFechaProgramacion.ToString(), vXmlCeldasDetalles.ToString(), UsuarioID)

                        If dtResultadoSustitucion.Rows(0).Item("respuesta").ToString() <> "ERROR" Then

                            show_message("Exito", "Datos almacenados correctamente")

                            btnMostrar_Click(Nothing, Nothing)

                            SplitContainer1.Dock = DockStyle.Fill
                            SplitContainer1.FixedPanel = FixedPanel.Panel1

                            SplitContainer1.IsSplitterFixed = True
                            SplitContainer1.Panel2Collapsed = True

                            lblCantidadParesSeleccionados.Text = "0"
                            panelCantidadPares.Visible = False
                            pnlDetallesPares.Visible = False

                        Else
                            show_message("Advertencia", "Ocurrió un error, intente nuevamente.")
                        End If
                    End If

                Else
                    show_message("Advertencia", "Seleccione un registro")
                End If
            Else
                show_message("Advertencia", "Seleccione un registro.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub chkClientesNoViables_CheckedChanged(sender As Object, e As EventArgs) Handles chkClientesNoViables.CheckedChanged

        Dim dtMovimientosPares = dtPoblarGridDetalles.AsEnumerable.Where(Function(x) x.Item("ValorOriginal") = 1)


        Try
            If chkClientesNoViables.Checked = True Then

                For Each fila As DataRow In dtMovimientosPares
                    fila("ValidaCambioFP") = "0"
                Next

            Else
                For Each fila As DataRow In dtMovimientosPares
                    fila("ValidaCambioFP") = "1"
                Next

            End If


            grdMovimientosPares.RefreshDataSource()


        Catch ex As Exception

        End Try

    End Sub

    Private Sub vwMovimientosPares_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles vwMovimientosPares.ShowingEditor
        Dim view As GridView = TryCast(sender, GridView)

        If vwMovimientosPares.FocusedColumn.FieldName.Contains(" ") Then
            If (view.GetRowCellDisplayText(view.FocusedRowHandle, "ValidaCambioFP").ToString() = "1") And (view.GetRowCellDisplayText(view.FocusedRowHandle, "ValorOriginal").ToString() = "1") Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub vwMovimientosPares_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles vwMovimientosPares.RowCellStyle
        Dim View As GridView = TryCast(sender, GridView)

        If e.RowHandle >= 0 Then
            Dim ValorOriginalMP As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ValorOriginal"))

            If e.Column.FieldName = "Cliente" Then
                If ValorOriginalMP = "1" Then
                    e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                    e.Appearance.ForeColor = Color.FromArgb(39, 55, 70)
                End If
            End If
        End If
    End Sub

    Private Sub vwCambiosFechaProgramacion_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles vwCambiosFechaProgramacion.RowCellStyle

        Dim View As GridView = TryCast(sender, GridView)


        If e.RowHandle >= 0 Then
            Dim ValorOriginalMP As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ValorOriginal"))

            If e.Column.FieldName = "Cliente" Then
                If ValorOriginalMP = "1" Then
                    e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                    e.Appearance.ForeColor = Color.FromArgb(39, 55, 70)

                End If
            End If
        End If
    End Sub

    Private Sub vwMovimientosPares_CellValueChanging(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles vwMovimientosPares.CellValueChanging
        If eventoActivo = False Then
            vwMovimientosPares.SetRowCellValue(e.RowHandle, " ", e.Value)

            validarChecksGrid()
        End If

    End Sub

    Private Sub validarChecksGrid()
        RemoveHandler vwMovimientosPares.RowCellStyle, AddressOf vwMovimientosPares_RowCellStyle

        Dim pares As Integer = 0
        Dim NumeroFilas As Integer = 0

        NumeroFilas = vwMovimientosPares.DataRowCount

        With vwMovimientosPares
            For index As Integer = 0 To NumeroFilas Step 1
                If .GetRowCellValue(index, " ") Then
                    pares += .GetRowCellValue(index, "Pares Colocados")
                End If
            Next

        End With

        lblCantidadParesDetalles.Text = If(pares >= 1000, pares.ToString("##,###"), pares)
    End Sub
End Class