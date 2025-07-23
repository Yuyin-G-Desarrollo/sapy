Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class GenerarEmbarqueSalidasAlmacénForm

    Dim listPedidos As New List(Of String)
    Dim listOrdenesTrabajo As New List(Of String)
    Dim listInicial As New List(Of String)

    Dim global_mensajeUltimaActualizacion As String = String.Empty
    Dim global_statusProceso As String = String.Empty

    Private Sub chboxMostrarTodo_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub GenerarEmbarqueSalidasAlmacénForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.Location = New Point(0, 0)
        'Me.WindowState = 2
        cboxStatus.SelectedIndex = 1

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_SAL_GENEMBARQUES", "ALM_SAL_GENERAR_EMBARQUES") Then
            'btnGenerarEmbarque.Enabled = True
            'lblBtnGenerarEmbarques.Enabled = True
            pnlGenerarEmbarque.Visible = True
            chkSeleccionarTodo.Visible = True

            'btnActualizarDatos.Visible = True
            'lblActualizarDatos.Visible = True
            pnlActualizarDatos.Visible = True
            pnlCorregirErrores.Visible = True
        Else
            'btnGenerarEmbarque.Enabled = False
            'lblBtnGenerarEmbarques.Enabled = False
            pnlGenerarEmbarque.Visible = False
            chkSeleccionarTodo.Visible = False

            'btnActualizarDatos.Visible = False
            'lblActualizarDatos.Visible = False
            btnActualizarDatos.Visible = False
            pnlCorregirErrores.Visible = False
        End If



        gridPedidos.DataSource = listPedidos
        gridClientes.DataSource = listInicial
        gridOrdenTrabajo.DataSource = listOrdenesTrabajo
        gridMensajeria.DataSource = listInicial
        lblConfirmacionOTDel.Enabled = False
        lblConfirmacionOTAl.Enabled = False
        dtpConfirmacionDel.Enabled = False
        dtpConfirmacionAl.Enabled = False
        dtpConfirmacionDel.Value = Date.Now.AddDays(-7)
        dtpConfirmacionAl.Value = Date.Now
        lblFacturacionDel.Enabled = False
        lblFacturacionAl.Enabled = False
        dtpFacturacionDel.Enabled = False
        dtpFacturacionAl.Enabled = False
        dtpFacturacionDel.Value = Date.Now.AddDays(-7)
        dtpFacturacionAl.Value = Date.Now
        chboxSepararTienda.Checked = False
        lblNumFiltrados.Text = "0"
        dtpConfirmacionAl.MinDate = dtpConfirmacionDel.Value
        dtpFacturacionAl.MinDate = dtpFacturacionDel.Value
        gridEmbarques.DataSource = Nothing

        chkSeleccionarTodo.Enabled = False
        chkSeleccionarTodo.Checked = False

        Utilerias.ComboObtenerCEDISUsuario(cboxNaveAlmacen)

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_YISTI") Then
            gboxClientes.Enabled = False
            gridClientes.DataSource = CargarClienteYISTI()
            With gridClientes
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
                .DisplayLayout.Bands(0).Columns(2).Hidden = True
                .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Cliente"
            End With
        End If

        btnAceptar_Click(sender, e)
    End Sub

    Private Function CargarClienteYISTI() As DataTable
        Dim dtInformacion As New DataTable
        dtInformacion.Columns.Add("Parámetro", GetType(Integer))
        dtInformacion.Columns.Add("", GetType(Boolean))
        dtInformacion.Columns.Add("Cadena", GetType(String))
        dtInformacion.Columns.Add("Nombre", GetType(String))

        dtInformacion.Rows.Add(1363, True, 1363, "FUNDACION YISTI SOCIETY A.C.")


        Return dtInformacion
    End Function

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 239
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 24
    End Sub

    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click

        Dim listado As New ListadoParametroSalidasForm
        listado.tipo_busqueda = 2
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridClientes.DataSource = listado.listParametros
        With gridClientes
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True

            .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Clientes"
        End With
    End Sub

    Private Sub gridClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridClientes.InitializeLayout
        grid_diseño(gridClientes)
        gridClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        'asignaFormato_Columna(grid)

    End Sub

    'Asigna formato a columnas de ultragrid
    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

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

    Private Sub gridClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles gridClientes.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridClientes.DeleteSelectedRows(False)
    End Sub

    Private Sub txtPedido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedido.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedido.Text) Then Return

            listPedidos.Add(txtPedido.Text)
            gridPedidos.DataSource = Nothing
            gridPedidos.DataSource = listPedidos

            txtPedido.Text = String.Empty

        End If
    End Sub

    Private Sub gridPedidos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridPedidos.InitializeLayout
        grid_simple_diseño(gridPedidos)
        gridPedidos.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido"
    End Sub

    Private Sub grid_simple_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
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

    End Sub

    Private Sub gridPedidos_KeyDown(sender As Object, e As KeyEventArgs) Handles gridPedidos.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridPedidos.DeleteSelectedRows(False)
    End Sub

    Private Sub txtOrdenTrabajo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrdenTrabajo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtOrdenTrabajo.Text) Then Return

            listOrdenesTrabajo.Add(txtOrdenTrabajo.Text)
            gridOrdenTrabajo.DataSource = Nothing
            gridOrdenTrabajo.DataSource = listOrdenesTrabajo

            txtOrdenTrabajo.Text = String.Empty

        End If
    End Sub

    Private Sub gridOrdenTrabajo_KeyDown(sender As Object, e As KeyEventArgs) Handles gridOrdenTrabajo.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridOrdenTrabajo.DeleteSelectedRows(False)
    End Sub

    Private Sub gridOrdenTrabajo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridOrdenTrabajo.InitializeLayout
        grid_simple_diseño(gridOrdenTrabajo)
        gridOrdenTrabajo.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Orden de Trabajo"
    End Sub

    Private Sub chboxFiltrarFechaConfirmacionOT_CheckedChanged(sender As Object, e As EventArgs) Handles chboxFiltrarFechaConfirmacionOT.CheckedChanged
        If chboxFiltrarFechaConfirmacionOT.Checked Then
            lblConfirmacionOTDel.Enabled = True
            lblConfirmacionOTAl.Enabled = True
            dtpConfirmacionDel.Enabled = True
            dtpConfirmacionAl.Enabled = True
        Else
            lblConfirmacionOTDel.Enabled = False
            lblConfirmacionOTAl.Enabled = False
            dtpConfirmacionDel.Enabled = False
            dtpConfirmacionAl.Enabled = False
        End If
    End Sub

    Private Sub chboxFiltarFechaFacturacion_CheckedChanged(sender As Object, e As EventArgs) Handles chboxFiltrarFechaFacturacion.CheckedChanged
        If chboxFiltrarFechaFacturacion.Checked Then
            lblFacturacionDel.Enabled = True
            lblFacturacionAl.Enabled = True
            dtpFacturacionDel.Enabled = True
            dtpFacturacionAl.Enabled = True
        Else
            lblFacturacionDel.Enabled = False
            lblFacturacionAl.Enabled = False
            dtpFacturacionDel.Enabled = False
            dtpFacturacionAl.Enabled = False
        End If
    End Sub

    Private Sub btnMensajerias_Click(sender As Object, e As EventArgs) Handles btnMensajerias.Click
        Dim listado As New ListadoParametroSalidasForm
        listado.tipo_busqueda = 3
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridMensajeria.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridMensajeria.DataSource = listado.listParametros
        With gridMensajeria
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True

            .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Mensajería"
        End With
    End Sub

    Private Sub gridMensajeria_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridMensajeria.InitializeLayout
        grid_diseño(gridMensajeria)
        gridMensajeria.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Mensajería"
    End Sub

    Private Sub gridMensajeria_KeyDown(sender As Object, e As KeyEventArgs) Handles gridMensajeria.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridMensajeria.DeleteSelectedRows(False)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Cursor = Cursors.WaitCursor
        listOrdenesTrabajo = New List(Of String)
        listPedidos = New List(Of String)

        chkSeleccionarTodo.Enabled = False
        chkSeleccionarTodo.Checked = False

        gridPedidos.DataSource = listPedidos
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_YISTI") Then
        Else
            gridClientes.DataSource = listInicial
        End If

        gridOrdenTrabajo.DataSource = listOrdenesTrabajo
        gridMensajeria.DataSource = listInicial
        gridEmbarques.DataSource = Nothing

        chboxFiltrarFechaFacturacion.Checked = False
        chboxFiltrarFechaConfirmacionOT.Checked = False
        chboxSepararTienda.Checked = False
        cboxStatus.SelectedIndex = 1
        rbtnOrdenesTrabajo.Checked = True
        dtpConfirmacionDel.Value = Now.Date
        dtpConfirmacionAl.Value = Now.Date
        dtpFacturacionDel.Value = Now.Date
        dtpFacturacionAl.Value = Now.Date
        gridEmbarques.DataSource = Nothing
        lblNumFiltrados.Text = "0"

        txtOrdenTrabajo.Text = ""
        txtPedido.Text = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Cursor = Cursors.WaitCursor
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New AdvertenciaForm
        grid = gridEmbarques
        If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 Then
            With grid.DisplayLayout.Bands(0)
                .Columns("seleccionar").Hidden = True
            End With
            If rbtnOrdenesTrabajo.Checked Then
                nombreDocumento = "\Embarques_Salidas_OrdenesTrabajo"
            End If
            If rbtnFacturasDocumentos.Checked Then
                nombreDocumento = "\Embarques_Salidas_Facturas"
            End If
            If rbtnPedidos.Checked Then
                nombreDocumento = "\Embarques_Salidas_Pedido"
            End If



            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog

                If ret = Windows.Forms.DialogResult.OK Then

                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                    gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                    With grid.DisplayLayout.Bands(0)
                        .Columns("seleccionar").Hidden = False
                    End With
                    Dim mensajeExito As New ExitoForm
                    Cursor = Cursors.Default
                    mensajeExito.mensaje = "Los datos se exportaron correctamente"
                    mensajeExito.ShowDialog()

                End If
                .Dispose()
            End With
        Else
            Cursor = Cursors.Default
            advertencia.mensaje = "No hay datos para exportar "
            advertencia.ShowDialog()
        End If
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

    Private Sub btnVerPares_Click(sender As Object, e As EventArgs) Handles btnVerPares.Click
        Dim idSalidasBuscarPares As String
        Dim renglonesSeleccionados As Integer = 0
        Dim idTienda As String
        Dim tipoConsultaMensaje As String = String.Empty
        idTienda = String.Empty
        idSalidasBuscarPares = String.Empty
        Cursor = Cursors.WaitCursor
        For Each row As UltraGridRow In gridEmbarques.Rows.GetFilteredInNonGroupByRows
            If (CBool(row.Cells("seleccionar").Value) And row.Cells("seleccionar").Hidden = False) Or (row.Selected = True) Then
                If row.Cells("IDSalidaDetalle").Value <> "" Then
                    If idSalidasBuscarPares <> "" Then
                        idSalidasBuscarPares += ","
                    End If
                    idSalidasBuscarPares += row.Cells("IDSalidaDetalle").Value
                    renglonesSeleccionados += 1
                Else
                    If rbtnOrdenesTrabajo.Checked Then
                        tipoConsultaMensaje = "Una de las Ordenes de trabajo seleccionadas"
                    End If
                    If rbtnFacturasDocumentos.Checked Then
                        tipoConsultaMensaje = "Una de las Facturas / Documentos seleccionados"
                    End If
                    If rbtnPedidos.Checked Then
                        tipoConsultaMensaje = "Uno de los Pedidos seleccionados"
                    End If
                    Cursor = Cursors.Default
                    show_message("Advertencia", "" + tipoConsultaMensaje + " no tiene datos completos. Comuníquelo a sistemas")
                    Exit Sub
                End If
            End If
        Next
        If renglonesSeleccionados > 0 Then
            Dim objVentanaPares As New ConsultarParesSalidaAlmacenForm(idSalidasBuscarPares)
            'Cursor = Cursors.Default
            objVentanaPares.MdiParent = Me.MdiParent
            objVentanaPares.Show()
        Else
            Cursor = Cursors.Default
            show_message("Advertencia", "Debe seleccionar al menos un registro")
        End If

    End Sub

    Private Sub btnGenerarEmbarque_Click(sender As Object, e As EventArgs) Handles btnGenerarEmbarque.Click
        'Dim listaRenglonesSeleccionados As New List(Of UltraGridRow)
        Dim dtRenglonesSeleccionados As New DataTable
        Dim tipoConsultaMensaje As String = String.Empty
        Dim tipoConsulta As Integer = 0
        Dim renglonTabla As New Object
        Cursor = Cursors.WaitCursor
        dtRenglonesSeleccionados.Columns.Add("IDSalidaDetalle")
        If rbtnOrdenesTrabajo.Checked Then
            dtRenglonesSeleccionados.Columns.Add("OT")
            tipoConsulta = 1
        End If
        If rbtnFacturasDocumentos.Checked Then
            dtRenglonesSeleccionados.Columns.Add("Documento")
            dtRenglonesSeleccionados.Columns.Add("Año_documento")
            dtRenglonesSeleccionados.Columns.Add("Factura")
            tipoConsulta = 2
        End If
        If rbtnPedidos.Checked Then
            dtRenglonesSeleccionados.Columns.Add("Pedido")
            dtRenglonesSeleccionados.Columns.Add("Cliente")
            If chboxSepararTienda.Checked Then
                dtRenglonesSeleccionados.Columns.Add("Tienda")
                dtRenglonesSeleccionados.Columns.Add("idTienda")
            End If
            dtRenglonesSeleccionados.Columns.Add("Mensajeria_Factura")
            dtRenglonesSeleccionados.Columns.Add("Pares", Type.GetType("System.Int32"))
            tipoConsulta = 3
        Else
            dtRenglonesSeleccionados.Columns.Add("Cliente")
            If chboxSepararTienda.Checked Then
                dtRenglonesSeleccionados.Columns.Add("Tienda")
                dtRenglonesSeleccionados.Columns.Add("idTienda")
            End If
            dtRenglonesSeleccionados.Columns.Add("Mensajeria_Factura")
            dtRenglonesSeleccionados.Columns.Add("Pedido")
            dtRenglonesSeleccionados.Columns.Add("Pares", Type.GetType("System.Int32"))
        End If
        Dim contador As Integer = 0
        For Each row As UltraGridRow In gridEmbarques.Rows.GetFilteredInNonGroupByRows
            If (CBool(row.Cells("seleccionar").Value) And row.Cells("seleccionar").Hidden = False) Or (row.Selected And row.Cells("seleccionar").Hidden = False) Then
                dtRenglonesSeleccionados.Rows.Add(renglonTabla)
                If row.Cells("IDSalidaDetalle").Value <> "" Then
                    dtRenglonesSeleccionados.Rows(contador).Item("IDSalidaDetalle") = row.Cells("IDSalidaDetalle").Value
                    If rbtnOrdenesTrabajo.Checked Then
                        dtRenglonesSeleccionados.Rows(contador).Item("OT") = row.Cells("sade_idordentrabajo").Value
                    End If
                    If rbtnFacturasDocumentos.Checked Then
                        dtRenglonesSeleccionados.Rows(contador).Item("Documento") = row.Cells("sade_iddocumento").Value
                        dtRenglonesSeleccionados.Rows(contador).Item("Año_documento") = row.Cells("sade_añodocumento").Value
                        dtRenglonesSeleccionados.Rows(contador).Item("Factura") = row.Cells("sade_idfactura").Value
                    End If
                    dtRenglonesSeleccionados.Rows(contador).Item("Cliente") = row.Cells("sade_nombrecadena_cliente").Value
                    dtRenglonesSeleccionados.Rows(contador).Item("Mensajeria_Factura") = row.Cells("sade_mensajeriafactura").Value
                    dtRenglonesSeleccionados.Rows(contador).Item("Pedido") = row.Cells("sade_idpedido").Value
                    dtRenglonesSeleccionados.Rows(contador).Item("Pares") = row.Cells("Total_Pares").Value

                    If chboxSepararTienda.Checked Then
                        dtRenglonesSeleccionados.Rows(contador).Item("Tienda") = row.Cells("sade_nombredistribucion_tienda").Value
                    End If

                    contador += 1
                Else
                    If rbtnOrdenesTrabajo.Checked Then
                        tipoConsultaMensaje = "Una de las Ordenes de trabajo"
                    End If
                    If rbtnFacturasDocumentos.Checked Then
                        tipoConsultaMensaje = "Una de las Facturas / Documentos"
                    End If
                    If rbtnPedidos.Checked Then
                        tipoConsultaMensaje = "Uno de los Pedidos"
                    End If
                    Cursor = Cursors.Default
                    show_message("Advertencia", "" + tipoConsultaMensaje + " a embarcar no tiene datos completos. Comuníquelo a sistemas")
                    Exit Sub
                End If
            End If
        Next
        If dtRenglonesSeleccionados.Rows.Count > 0 Then
            Dim objVentanaEmbarques As New GenerarEntregaAlmacenForm(dtRenglonesSeleccionados, tipoConsulta, chboxSepararTienda.Checked, 0)
            Cursor = Cursors.Default
            gridEmbarques.DataSource = Nothing
            objVentanaEmbarques.MdiParent = Me.MdiParent
            Me.WindowState = 1
            objVentanaEmbarques.Show()
        Else
            If rbtnOrdenesTrabajo.Checked Then
                tipoConsultaMensaje = "una Orden de trabajo"
            End If
            If rbtnFacturasDocumentos.Checked Then
                tipoConsultaMensaje = "una Factura / Documento"
            End If
            If rbtnPedidos.Checked Then
                tipoConsultaMensaje = "un Pedido"
            End If
            Cursor = Cursors.Default
            show_message("Advertencia", "Debe seleccionar al menos " + tipoConsultaMensaje + " a embarcar")
        End If
    End Sub

    Private Sub dtpConfirmacionDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpConfirmacionDel.ValueChanged
        If dtpConfirmacionAl.Value < dtpConfirmacionDel.Value Then
            dtpConfirmacionAl.Value = dtpConfirmacionDel.Value
        End If
        dtpConfirmacionAl.MinDate = dtpConfirmacionDel.Value
    End Sub

    Private Sub dtpFacturacionDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFacturacionDel.ValueChanged
        If dtpFacturacionAl.Value < dtpFacturacionDel.Value Then
            dtpFacturacionAl.Value = dtpFacturacionDel.Value
        End If
        dtpFacturacionAl.MinDate = dtpFacturacionDel.Value
    End Sub

    Public Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Cursor = Cursors.WaitCursor
        lblNumFiltrados.Text = "0"
        gridEmbarques.DataSource = Nothing

        chkSeleccionarTodo.Enabled = True
        chkSeleccionarTodo.Checked = False

        Dim FiltrosSalidas As New Entidades.FiltrosSalidas
        Dim objBU As New Negocios.SalidasAlmacenBU
        Dim tabla_embarques As New DataTable
        Dim lCliente As String = String.Empty
        Dim lPedidoSiCY As String = String.Empty
        Dim lOrdenTrabajo As String = String.Empty
        Dim lMensajeria As String = String.Empty
        Dim Cedis As Integer = 0

        FiltrosSalidas.PTipoConsulta = 1
        FiltrosSalidas.PAgrupamiento = obtenerFiltroAgrupamiento()
        FiltrosSalidas.PSepararTienda = If(chboxSepararTienda.Checked, 1, 0)
        FiltrosSalidas.PStatus = If(cboxStatus.SelectedIndex > 0, cboxStatus.SelectedItem.ToString, "")
        FiltrosSalidas.PPrimeraFechaDel = If(chboxFiltrarFechaConfirmacionOT.Checked, dtpConfirmacionDel.Value.ToShortDateString(), "")
        FiltrosSalidas.PPrimeraFechaAl = If(chboxFiltrarFechaConfirmacionOT.Checked, dtpConfirmacionAl.Value.ToShortDateString(), "")
        FiltrosSalidas.PSegundaFechaDel = If(chboxFiltrarFechaFacturacion.Checked, dtpFacturacionDel.Value.ToShortDateString(), "")
        FiltrosSalidas.PSegundaFechaAl = If(chboxFiltrarFechaFacturacion.Checked, dtpFacturacionAl.Value.ToShortDateString(), "")

        For Each row As UltraGridRow In gridClientes.Rows
            If row.Index = 0 Then
                lCliente += Replace(row.Cells(0).Text, ",", "")
            Else
                lCliente += ", " + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        FiltrosSalidas.PCliente = lCliente

        For Each row As UltraGridRow In gridPedidos.Rows
            If row.Index = 0 Then
                lPedidoSiCY += Replace(row.Cells(0).Text, ",", "")
            Else
                lPedidoSiCY += ", " + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        FiltrosSalidas.PPedidoSiCY = lPedidoSiCY

        For Each row As UltraGridRow In gridOrdenTrabajo.Rows
            If row.Index = 0 Then
                lOrdenTrabajo += Replace(row.Cells(0).Text, ",", "")
            Else
                lOrdenTrabajo += ", " + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        FiltrosSalidas.POrdenTrabajo = lOrdenTrabajo

        For Each row As UltraGridRow In gridMensajeria.Rows
            If row.Index = 0 Then
                lMensajeria += Replace(row.Cells(0).Text, ",", "")
            Else
                lMensajeria += ", " + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        FiltrosSalidas.PMensajeria = lMensajeria

        FiltrosSalidas.PFolioEmbarque = ""

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_YISTI") Then
            FiltrosSalidas.PEsYISTI = True
        Else
            FiltrosSalidas.PEsYISTI = False
        End If

        FiltrosSalidas.PCedis = cboxNaveAlmacen.SelectedValue

        tabla_embarques = objBU.consultaGenerarEmbarques(FiltrosSalidas)

        gridEmbarques.DataSource = tabla_embarques

        gridEmbarquesDiseño(gridEmbarques)
        cargarFechaUltimaActualización()

        Cursor = Cursors.Default
    End Sub

    Private Sub gridEmbarquesDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        'asignaFormato_Columna(grid)
        grid.DisplayLayout.Bands(0).Columns("IDSalidaDetalle").Hidden = True

        'grid.DisplayLayout.Bands(0).Columns("seleccionar").Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor
        'grid.DisplayLayout.Bands(0).Columns("seleccionar").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
        'grid.DisplayLayout.Bands(0).Columns("seleccionar").Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection

        grid.DisplayLayout.Bands(0).Columns("Tipo Empaque").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("seleccionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("seleccionar").Style = ColumnStyle.CheckBox
        grid.DisplayLayout.Bands(0).Columns("seleccionar").DefaultCellValue = False
        grid.DisplayLayout.Bands(0).Columns("seleccionar").AllowRowFiltering = DefaultableBoolean.False

        grid.DisplayLayout.Bands(0).Columns("seleccionar").Header.Caption = ""
        If rbtnOrdenesTrabajo.Checked Then
            grid.DisplayLayout.Bands(0).Columns("sade_idordentrabajo").Header.Caption = "OT"
            grid.DisplayLayout.Bands(0).Columns("sade_idordentrabajo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("sade_idordentrabajo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        End If
        If rbtnFacturasDocumentos.Checked Then
            grid.DisplayLayout.Bands(0).Columns("sade_iddocumento").Header.Caption = "Docto"
            grid.DisplayLayout.Bands(0).Columns("sade_iddocumento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("sade_iddocumento").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("sade_añodocumento").Header.Caption = "Año Docto"
            grid.DisplayLayout.Bands(0).Columns("sade_añodocumento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("sade_añodocumento").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("sade_idfactura").Header.Caption = "Factura"
            grid.DisplayLayout.Bands(0).Columns("sade_idfactura").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("sade_idfactura").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("sade_fechadocumento").Header.Caption = "F Docto"
            grid.DisplayLayout.Bands(0).Columns("sade_fechadocumento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("sade_fechadocumento").Format = "dd/MM/yyyy"
        End If
        grid.DisplayLayout.Bands(0).Columns("sade_nombrecadena_cliente").Header.Caption = "Cliente"
        grid.DisplayLayout.Bands(0).Columns("sade_nombrecadena_cliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sade_mensajeriafactura").Header.Caption = "Mensajería Factura"
        grid.DisplayLayout.Bands(0).Columns("sade_mensajeriafactura").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sade_mensajeriarealnombre").Header.Caption = "Mensajería Real"
        grid.DisplayLayout.Bands(0).Columns("sade_mensajeriarealnombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sade_idpedido").Header.Caption = "Pedido"
        grid.DisplayLayout.Bands(0).Columns("sade_idpedido").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sade_idpedido").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Total_Pares").Header.Caption = "Pares"
        grid.DisplayLayout.Bands(0).Columns("Total_Pares").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Total_Pares").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Total_Pares").Format = "n0"
        If rbtnOrdenesTrabajo.Checked Then
            grid.DisplayLayout.Bands(0).Columns("sade_usuarioconfirmacionordentrabajo").Header.Caption = "Capturó"
            grid.DisplayLayout.Bands(0).Columns("sade_usuarioconfirmacionordentrabajo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("sade_fechaconfirmacionordentrabajo").Header.Caption = "Captura"
            grid.DisplayLayout.Bands(0).Columns("sade_fechaconfirmacionordentrabajo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            'grid.DisplayLayout.Bands(0).Columns("sade_fechaconfirmacionordentrabajo").Format = "dd/MM/yyyy HH:mm:ss"
        End If
        If chboxSepararTienda.Checked Then
            grid.DisplayLayout.Bands(0).Columns("sade_nombredistribucion_tienda").Header.Caption = "Tienda"
            grid.DisplayLayout.Bands(0).Columns("sade_nombredistribucion_tienda").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            grid.DisplayLayout.Bands(0).Columns("sade_iddistribucion_tienda").Hidden = True
        End If
        grid.DisplayLayout.Bands(0).Columns("sade_statusembarque").Header.Caption = "Status"
        grid.DisplayLayout.Bands(0).Columns("sade_statusembarque").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sade_embarqueid").Header.Caption = "#Embarque"
        grid.DisplayLayout.Bands(0).Columns("sade_embarqueid").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sade_embarqueid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("sade_fechaembarque").Header.Caption = "Embarque"
        grid.DisplayLayout.Bands(0).Columns("sade_fechaembarque").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sade_fechaembarque").Format = "dd/MM/yyyy HH:mm:ss"
        grid.DisplayLayout.Bands(0).Columns("sade_usuarioembarquenombre").Header.Caption = "Embarcó"
        grid.DisplayLayout.Bands(0).Columns("sade_usuarioembarquenombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sade_operadorembarque").Header.Caption = "Entregó"
        grid.DisplayLayout.Bands(0).Columns("sade_operadorembarque").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sade_fechasalida").Header.Caption = "Fecha Salida"
        grid.DisplayLayout.Bands(0).Columns("sade_fechasalida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sade_fechasalida").Format = "dd/MM/yyyy HH:mm:ss"
        grid.DisplayLayout.Bands(0).Columns("sade_salidaid").Header.Caption = "#Salida"
        grid.DisplayLayout.Bands(0).Columns("sade_salidaid").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sade_salidaid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right


        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grid.DisplayLayout.GroupByBox.Hidden = False
        grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"


        grid.DisplayLayout.Bands(0).Columns("seleccionar").Width = 20
        If rbtnOrdenesTrabajo.Checked Then
            grid.DisplayLayout.Bands(0).Columns("sade_fechaconfirmacionordentrabajo").Width = 65
        End If
        If rbtnFacturasDocumentos.Checked Then
            grid.DisplayLayout.Bands(0).Columns("sade_fechadocumento").Width = 65
        End If
        grid.DisplayLayout.Bands(0).Columns("sade_fechaembarque").Width = 115
        grid.DisplayLayout.Bands(0).Columns("Total_Pares").Width = 45

        Dim summary1 As SummarySettings
        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Total_Pares"))
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right

        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If

        For Each row As UltraGridRow In grid.Rows
            If row.Cells("sade_statusembarque").Value <> "ACTIVA" Then
                row.Cells("seleccionar").Hidden = True
            End If
        Next

    End Sub


    Private Sub ContarRegistrosSeleccionados()
        Try
            Dim Seleccionados As Integer = 0
            For Each row As UltraGridRow In gridEmbarques.Rows.GetFilteredInNonGroupByRows
                If CBool(row.Cells("seleccionar").Value) And row.Cells("seleccionar").Hidden = False Then
                    Seleccionados += 1
                End If
            Next
            lblNumFiltrados.Text = Format(Seleccionados, "###,###,##0")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridEmbarques_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles gridEmbarques.AfterRowFilterChanged
        ContarRegistrosSeleccionados()
    End Sub

    Private Sub gridEmbarques_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridEmbarques.ClickCell
        '    If gridEmbarques.ActiveRow.Cells("seleccionar").Value Then
        '        gridEmbarques.ActiveRow.Cells("seleccionar").Value = False
        '    Else
        '        gridEmbarques.ActiveRow.Cells("seleccionar").Value = True
        '    End If
        'ContarRegistrosSeleccionados()
    End Sub

    Private Sub gridEmbarques_CellChange(sender As Object, e As CellEventArgs) Handles gridEmbarques.CellChange
        Try
            Dim Seleccionados As Integer = 0
            If e.Cell.Column.ToString = "seleccionar" And e.Cell.Hidden = False Then
                If e.Cell.Value Then
                    gridEmbarques.ActiveRow.Cells("seleccionar").Value = False
                Else
                    gridEmbarques.ActiveRow.Cells("seleccionar").Value = True
                End If
                For Each row As UltraGridRow In gridEmbarques.Rows.GetFilteredInNonGroupByRows
                    If CBool(row.Cells("seleccionar").Value) And row.Cells("seleccionar").Hidden = False Then
                        Seleccionados += 1
                    End If
                Next
                lblNumFiltrados.Text = Format(Seleccionados, "###,###,##0")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridEmbarques_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles gridEmbarques.AfterCellUpdate
        ContarRegistrosSeleccionados()
    End Sub

    Private Function obtenerFiltroAgrupamiento()
        Dim tipoAgrupamiento As Integer = 0
        If rbtnOrdenesTrabajo.Checked Then
            tipoAgrupamiento = 1 'Agrupamiento por orden de trabajo
        End If
        If rbtnFacturasDocumentos.Checked Then
            tipoAgrupamiento = 2 'Agrupamiento por factura / documento
        End If
        If rbtnPedidos.Checked Then
            tipoAgrupamiento = 3 'Agrupamiento por pedido
        End If
        Return tipoAgrupamiento
    End Function

    Private Sub rbtnOrdenesTrabajo_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOrdenesTrabajo.CheckedChanged
        gridEmbarques.DataSource = Nothing
    End Sub

    Private Sub rbtnFacturasDocumentos_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnFacturasDocumentos.CheckedChanged
        gridEmbarques.DataSource = Nothing
    End Sub

    Private Sub rbtnPedidos_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnPedidos.CheckedChanged
        gridEmbarques.DataSource = Nothing
    End Sub

    Private Sub GenerarEmbarqueSalidasAlmacénForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.WindowState = 2
        btnAceptar_Click(sender, e)
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        If gridEmbarques.Rows.Count > 0 Then
            Cursor = Cursors.WaitCursor
            If chkSeleccionarTodo.Checked Then
                For Each row As UltraGridRow In gridEmbarques.Rows.GetFilteredInNonGroupByRows
                    row.Cells("Seleccionar").Value = True
                Next
            Else
                For Each row As UltraGridRow In gridEmbarques.Rows.GetFilteredInNonGroupByRows
                    row.Cells("Seleccionar").Value = False
                Next
            End If
            Cursor = Cursors.Default
        Else
            chkSeleccionarTodo.Checked = False
        End If
    End Sub

    Private Sub btnActualizarDatos_Click(sender As Object, e As EventArgs) Handles btnActualizarDatos.Click
        Dim confirmacion As New confirmarFormGrande
        Dim objBU As New Negocios.SalidasAlmacenBU
        Dim minutosRestantes As Integer = 0
        Dim horaActual As Integer = 0
        Dim minutoActual As Integer = 0
        btnActualizarDatos.Enabled = False
        lblActualizarDatos.Enabled = False
        cargarFechaUltimaActualización()
        'confirmacion.mensaje = "¿Desea actualizar los datos de mercancia a embarcar?"
        minutoActual = Date.Now.Minute

        minutosRestantes = 60 - minutoActual
        If global_statusProceso = "EN EJECUCIÓN" Then
            show_message("Aviso", "Hay una actualización en curso, intente más tarde")
        Else

            confirmacion.mensaje = "Los datos de facturación fueron actualizados el " + global_mensajeUltimaActualizacion + ", ¿Está seguro de iniciar la actualización de datos en este momento (la duración de este proceso dependerá de la cantidad de datos por actualizar)?"
            confirmacion.mensaje += " (La siguiente actualización se hará automáticamente en " + minutosRestantes.ToString() + " minutos)"

            If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                If objBU.actualizarDatosSAY() Then
                    show_message("Exito", "Datos actualizados correctamente")
                    Cursor = Cursors.Default
                Else
                    show_message("Error", "Los datos no pudieron ser actualizados, intente de nuevo")
                End If
            End If
        End If
        btnActualizarDatos.Enabled = True
        lblActualizarDatos.Enabled = True
        btnAceptar_Click(sender, e)
    End Sub

    Public Function cargarFechaUltimaActualización()
        Dim objBU As New Negocios.SalidasAlmacenBU
        Dim tablaUltimaActualizacion As New DataTable

        tablaUltimaActualizacion = objBU.obtenerFechaUltimaActualizacionDatosSAY()

        global_mensajeUltimaActualizacion = tablaUltimaActualizacion.Rows(0).Item("fechaMostrar").ToString()
        global_statusProceso = tablaUltimaActualizacion.Rows(0).Item("StatusProceso").ToString()

        lblMensajeUltimaActualizacion.Text = global_mensajeUltimaActualizacion
        If global_statusProceso = "EN EJECUCIÓN" Then
            lblStatusProceso.Visible = True
            lblStatusProceso.Text = global_statusProceso
            btnActualizarDatos.Enabled = False
            lblActualizarDatos.Enabled = False
        Else
            lblStatusProceso.Visible = False
            btnActualizarDatos.Enabled = True
            lblActualizarDatos.Enabled = True
        End If

    End Function

    Private Sub btnCodigosConErrores_Click(sender As Object, e As EventArgs) Handles btnCodigosConErrores.Click
        Try
            Dim objBU As New Negocios.SalidasAlmacenBU
            objBU.CorregirErrores()
            Tools.Controles.Mensajes_Y_Alertas("EXITO", "Se hicieron los ajustes necesarios")
        Catch ex As Exception
            Tools.Controles.Mensajes_Y_Alertas("ERROR", "Error: " + ex.Message)
        End Try
    End Sub
End Class