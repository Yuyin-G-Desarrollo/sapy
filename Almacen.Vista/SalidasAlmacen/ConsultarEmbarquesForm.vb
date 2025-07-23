Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Stimulsoft.Report
Imports Tools

Public Class ConsultarEmbarquesForm

    Dim listPedidos As New List(Of String)
    Dim listInicial As New List(Of String)
    Dim listFolios As New List(Of String)
    Dim listOrdenesTrabajo As New List(Of String)
    Dim listCorridas As New List(Of String)

    Private Sub ConsultarEmbarquesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        'Me.WindowState = 2
        gridClientes.DataSource = listInicial
        gridPedidos.DataSource = listPedidos
        gridFoliosEmbarque.DataSource = listFolios
        gridOrdenesTrabajo.DataSource = listOrdenesTrabajo
        gridMensajeria.DataSource = listInicial
        gridCorrida.DataSource = listCorridas

        cboxStatusEmbarque.SelectedIndex = 1

        lblSalidaDel.Enabled = False
        lblSalidaAl.Enabled = False
        dtpFechaSalidaDel.Enabled = False
        dtpFechaSalidaAl.Enabled = False

        lblEmbarqueDel.Enabled = False
        lblEmbarqueAl.Enabled = False
        dtpFechaEmbarqueDel.Enabled = False
        dtpFechaEmbarqueAl.Enabled = False

        chboxSepararTienda.Checked = False
        lblNumFiltrados.Text = "0"

        dtpFechaEmbarqueAl.MinDate = dtpFechaEmbarqueDel.Value
        dtpFechaSalidaAl.MinDate = dtpFechaSalidaDel.Value

        gridEmbarques.DataSource = Nothing

        chkSeleccionarTodo.Enabled = False
        chkSeleccionarTodo.Checked = False

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_SAL_GENEMBARQUES", "ALM_SAL_GENERAR_EMBARQUES") Then
            btnImprimirEmbarque.Enabled = True
            lblImprimirEmbarque.Enabled = True
            btnGenerarSalida.Enabled = True
            lblGenerarSalida.Enabled = True
            btnCancelarSalida.Enabled = True
            lblCancelarSalida.Enabled = True
            btnImprimirEmbarque.Enabled = True
            lblImprimirEmbarque.Enabled = True
            btnEditarEmbarque.Enabled = True
            lblEditarEmbarque.Enabled = True
            chkSeleccionarTodo.Visible = True
        Else
            btnImprimirEmbarque.Enabled = False
            lblImprimirEmbarque.Enabled = False
            btnGenerarSalida.Enabled = False
            lblGenerarSalida.Enabled = False
            btnCancelarSalida.Enabled = False
            lblCancelarSalida.Enabled = False
            btnImprimirEmbarque.Enabled = False
            lblImprimirEmbarque.Enabled = False
            btnEditarEmbarque.Enabled = False
            lblEditarEmbarque.Enabled = False
            chkSeleccionarTodo.Visible = False
        End If

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

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 24
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 235
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
        gridEmbarques.DataSource = Nothing
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
            gridEmbarques.DataSource = Nothing

            txtPedido.Text = String.Empty

        End If
    End Sub

    Private Sub gridPedidos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridPedidos.InitializeLayout
        grid_simple_diseño(gridPedidos)
        gridPedidos.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido"
    End Sub

    Private Sub gridPedidos_KeyDown(sender As Object, e As KeyEventArgs) Handles gridPedidos.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridPedidos.DeleteSelectedRows(False)
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

    Private Sub gridFoliosEmbarque_KeyDown(sender As Object, e As KeyEventArgs) Handles gridFoliosEmbarque.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridFoliosEmbarque.DeleteSelectedRows(False)
    End Sub

    Private Sub gridOrdenesTrabajo_KeyDown(sender As Object, e As KeyEventArgs) Handles gridOrdenesTrabajo.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridOrdenesTrabajo.DeleteSelectedRows(False)
    End Sub

    Private Sub gridMensajeria_KeyDown(sender As Object, e As KeyEventArgs) Handles gridMensajeria.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridMensajeria.DeleteSelectedRows(False)
    End Sub

    Private Sub txtFolio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolio.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFolio.Text) Then Return

            listFolios.Add(txtFolio.Text)
            gridFoliosEmbarque.DataSource = Nothing
            gridFoliosEmbarque.DataSource = listFolios
            gridEmbarques.DataSource = Nothing

            txtFolio.Text = String.Empty

        End If
    End Sub

    Private Sub gridOrdenesTrabajo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridOrdenesTrabajo.InitializeLayout
        grid_simple_diseño(gridOrdenesTrabajo)
        gridOrdenesTrabajo.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Orden de Trabajo"
    End Sub

    Private Sub txtOrdenTrabajo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrdenTrabajo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtOrdenTrabajo.Text) Then Return

            listOrdenesTrabajo.Add(txtOrdenTrabajo.Text)
            gridOrdenesTrabajo.DataSource = Nothing
            gridOrdenesTrabajo.DataSource = listOrdenesTrabajo
            gridEmbarques.DataSource = Nothing

            txtOrdenTrabajo.Text = String.Empty

        End If
    End Sub

    Private Sub gridMensajeria_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridMensajeria.InitializeLayout
        grid_simple_diseño(gridMensajeria)
        gridMensajeria.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Mensajería"
    End Sub

    Private Sub btnMensajeria_Click(sender As Object, e As EventArgs) Handles btnMensajeria.Click
        Dim listado As New ListadoParametroSalidasForm
        listado.tipo_busqueda = 1
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
        gridEmbarques.DataSource = Nothing
    End Sub

    Private Sub gridFoliosEmbarque_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridFoliosEmbarque.InitializeLayout
        grid_simple_diseño(gridFoliosEmbarque)
        gridFoliosEmbarque.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Folio"
    End Sub

    Private Sub btnIncidencias_Click(sender As Object, e As EventArgs) Handles btnIncidencias.Click
        If rbtnFolio.Checked = True Then
            Dim renglonesSeleccionados As Integer = 0
            Dim tipoConsultaMensaje As String
            tipoConsultaMensaje = String.Empty

            Dim tipoConsulta As Integer = 0 ' 1 Generar Incidencias; 2 Consultar Incidencias
            Dim idEmbarque As Integer = 0
            Dim cliente As String = String.Empty
            Dim fechaEmbarque As String = String.Empty
            Dim pares As Integer = 0
            Dim paresEmbarque As Integer = 0
            Dim paresEntregados As Integer = 0
            Dim paresFaltantes As Integer = 0
            Dim operador As Integer = 0

            For Each row As UltraGridRow In gridEmbarques.Rows.GetFilteredInNonGroupByRows
                If (CBool(row.Cells("seleccionar").Value) And row.Cells("seleccionar").Hidden = False) Or (row.Selected And row.Cells("seleccionar").Hidden = False) Then
                    idEmbarque = row.Cells("sade_embarqueid").Value
                    cliente = row.Cells("sade_nombrecadena_cliente").Value
                    fechaEmbarque = row.Cells("sade_fechaembarque").Value
                    If rbtnFolio.Checked = False Then
                        pares = row.Cells("Total_Pares").Value
                    Else
                        pares = row.Cells("Total_paresEmbarcados").Value
                    End If
                    paresEmbarque = row.Cells("Total_paresEmbarcados").Value
                    paresEntregados = row.Cells("paresEntregados").Value
                    paresFaltantes = (pares - paresEntregados)
                    operador = 0
                    renglonesSeleccionados += 1
                    tipoConsulta = 1
                End If
            Next
            If renglonesSeleccionados = 0 Then
                For Each row As UltraGridRow In gridEmbarques.Rows.GetFilteredInNonGroupByRows
                    If row.Selected Then
                        If row.Cells("sade_nombrecadena_cliente").Value <> "COPPEL" Then
                            idEmbarque = row.Cells("sade_embarqueid").Value
                            cliente = row.Cells("sade_nombrecadena_cliente").Value
                            fechaEmbarque = row.Cells("sade_fechaembarque").Value
                            If rbtnFolio.Checked = False Then
                                pares = row.Cells("Total_Pares").Value
                            Else
                                pares = row.Cells("Total_paresEmbarcados").Value
                            End If
                            paresEmbarque = row.Cells("Total_paresEmbarcados").Value
                            paresEntregados = row.Cells("paresEntregados").Value
                            paresFaltantes = (pares - paresEntregados)
                            operador = 0
                            renglonesSeleccionados += 1
                            tipoConsulta = 2
                        Else
                            show_message("Advertencia", "Incidencias no disponibles para COPPEL")
                            Exit Sub
                        End If
                    End If
                Next
            End If
            If renglonesSeleccionados > 0 And renglonesSeleccionados < 2 Then
                Dim objVentanaIncidencias As New IncidenciaSalidasForm(tipoConsulta, idEmbarque, cliente, fechaEmbarque, pares, paresEmbarque, paresEntregados, paresFaltantes, operador)
                objVentanaIncidencias.MdiParent = Me.MdiParent
                Me.WindowState = 1
                objVentanaIncidencias.Show()
            Else
                If rbtnOrdenTrabajo.Checked Then
                    tipoConsultaMensaje = "una Orden de trabajo"
                End If
                If rbtnFacturaDocumento.Checked Then
                    tipoConsultaMensaje = "una Factura / Documento"
                End If
                If rbtnPedidos.Checked Then
                    tipoConsultaMensaje = "un Pedido"
                End If
                If rbtnFolio.Checked Then
                    tipoConsultaMensaje = "un Embarque"
                End If
                Cursor = Cursors.Default
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_SAL_GENEMBARQUES", "ALM_SAL_GENERAR_EMBARQUES") Then
                    show_message("Advertencia", "Debe seleccionar " + tipoConsultaMensaje + " para generar o consultar incidencias")
                Else
                    show_message("Advertencia", "Debe seleccionar " + tipoConsultaMensaje + " para consultar incidencias")
                End If
            End If
        Else
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_SAL_GENEMBARQUES", "ALM_SAL_GENERAR_EMBARQUES") Then
                show_message("Advertencia", "Debe seleccionar el agrupamiento Folio de Embarque para generar o consultar incidencias")
            Else
                show_message("Advertencia", "Debe seleccionar el agrupamiento Folio de Embarque para consultar incidencias")
            End If
        End If
    End Sub

    Private Sub btnVerPares_Click(sender As Object, e As EventArgs) Handles btnVerPares.Click
        Dim idSalidasBuscarPares As String
        Dim renglonesSeleccionados As Integer = 0
        Dim idTienda As String
        idTienda = String.Empty
        idSalidasBuscarPares = String.Empty
        Cursor = Cursors.WaitCursor
        For Each row As UltraGridRow In gridEmbarques.Rows.GetFilteredInNonGroupByRows
            If (CBool(row.Cells("seleccionar").Value) And row.Cells("seleccionar").Hidden = False) Or (row.Selected = True) Then
                If idSalidasBuscarPares <> "" Then
                    idSalidasBuscarPares += ","
                End If
                idSalidasBuscarPares += row.Cells("IDSalidaDetalle").Value
                renglonesSeleccionados += 1
            End If
        Next
        If renglonesSeleccionados > 0 Then
            Dim objVentanaPares As New ConsultarParesSalidaAlmacenForm(idSalidasBuscarPares)
            Cursor = Cursors.Default
            objVentanaPares.MdiParent = Me.MdiParent
            objVentanaPares.Show()
        Else
            Cursor = Cursors.Default
            show_message("Advertencia", "Debe seleccionar al menos un registro")
        End If
    End Sub

    Private Sub btnGenerarSalida_Click(sender As Object, e As EventArgs) Handles btnGenerarSalida.Click
        Dim confirmacion As New ConfirmarForm
        Dim objBU As New Negocios.SalidasAlmacenBU
        Dim idSalidasGenerarSalida As String
        Dim idEmbarqueGenerarSalida As Integer = 0
        Dim idEmbarquesGenerarSalida As String
        Dim totalParesSeleccionados As Integer = 0
        Dim totalParesNoRecibidos As Integer = 0
        Dim totalPRenglonesSeleccionados As Integer = 0
        idSalidasGenerarSalida = String.Empty
        idEmbarquesGenerarSalida = String.Empty
        Dim indiceEmbarqueEnArreglo As Integer = -1

        Cursor = Cursors.WaitCursor
        For Each row As UltraGridRow In gridEmbarques.Rows.GetFilteredInNonGroupByRows
            If CBool(row.Cells("seleccionar").Value) And row.Cells("seleccionar").Hidden = False Then
                indiceEmbarqueEnArreglo = -1
                indiceEmbarqueEnArreglo = Array.IndexOf(Split(idEmbarquesGenerarSalida), row.Cells("sade_embarqueid").Value.ToString())
                If indiceEmbarqueEnArreglo = -1 Then
                    If idEmbarquesGenerarSalida <> "" Then
                        idEmbarquesGenerarSalida += ", "
                    End If
                    idEmbarquesGenerarSalida += row.Cells("sade_embarqueid").Value.ToString()
                End If
                idEmbarqueGenerarSalida = row.Cells("sade_embarqueid").Value
                If indiceEmbarqueEnArreglo = -1 Then
                    For Each rowEmbarque As UltraGridRow In gridEmbarques.Rows.GetFilteredInNonGroupByRows
                        If idEmbarqueGenerarSalida = rowEmbarque.Cells("sade_embarqueid").Value And rowEmbarque.Cells("seleccionar").Hidden = False Then
                            If idSalidasGenerarSalida <> "" Then
                                idSalidasGenerarSalida += ","
                            End If
                            idSalidasGenerarSalida += rowEmbarque.Cells("IDSalidaDetalle").Value
                            If rbtnFolio.Checked Then
                                totalParesSeleccionados += rowEmbarque.Cells("Total_ParesEmbarcados").Value
                            Else
                                totalParesSeleccionados += rowEmbarque.Cells("Total_Pares").Value
                            End If
                            totalParesNoRecibidos += rowEmbarque.Cells("paresNoRecibidos").Value
                        End If
                    Next
                End If
                totalPRenglonesSeleccionados += 1
            End If
        Next
        Dim mensajeMostrar As String = String.Empty
        If totalPRenglonesSeleccionados > 0 Then
            Dim totalEmbarquesSeleccionados As Integer = 0
            totalEmbarquesSeleccionados = Split(idEmbarquesGenerarSalida).Count
            If Split(idEmbarquesGenerarSalida).Count > 1 Then
                'mensajeMostrar = "los embarques " + idEmbarquesGenerarSalida.ToString + " seleccionados"
                mensajeMostrar = "los " + totalEmbarquesSeleccionados.ToString("#,##0") + " embarques seleccionados"
            Else
                'mensajeMostrar = "el embarque " + idEmbarquesGenerarSalida.ToString + " seleccionado"
                mensajeMostrar = "el embarque seleccionado"
            End If
            confirmacion.mensaje = "¿Desea generar la salida de los " + totalParesSeleccionados.ToString("#,##0") + " pares en " + mensajeMostrar + "?"
            If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                Dim resultadoGeneracionSalida As New DataTable
                Dim objGeneracionSalidas As New Entidades.GeneracionSalida
                objGeneracionSalidas.PUsuarioSalida = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                objGeneracionSalidas.PIdDetalleEntrega = idSalidasGenerarSalida
                objGeneracionSalidas.PCantidadParesSalida = totalParesSeleccionados
                objGeneracionSalidas.PCantidadParesNoRecibidos = totalParesNoRecibidos
                resultadoGeneracionSalida = objBU.generarSalida(objGeneracionSalidas)

                Dim ListaPedidosSICY = gridEmbarques.Rows.AsEnumerable().Where(Function(y) CBool(y.Cells("seleccionar").Value) = True).Select(Function(x) x.Cells("sade_idpedido").Value).Distinct().ToList
                Dim PedidosSICY As String = String.Join(",", ListaPedidosSICY)


                objBU.actualizarStatusOTSAYParesEntregado()
                objBU.ActualizarEstatusPedido(PedidosSICY)
                objBU.ReplicarEstatusPedidoSAY_SICY(PedidosSICY)

                Cursor = Cursors.Default
                gridEmbarques.DataSource = Nothing
                show_message(resultadoGeneracionSalida.Rows(0).Item("tipoResultado"), resultadoGeneracionSalida.Rows(0).Item("resultado"))
                btnAceptar_Click(sender, e)
            End If
        Else
            show_message("Advertencia", "No hay embarques seleccionados")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
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
            If rbtnOrdenTrabajo.Checked Then
                nombreDocumento = "\Embarques_OrdenesTrabajo"
            End If
            If rbtnFacturaDocumento.Checked Then
                nombreDocumento = "\Embarques_Factura"
            End If
            If rbtnPedidos.Checked Then
                nombreDocumento = "\Embarques_Pedido"
            End If
            If rbtnFolio.Checked Then
                nombreDocumento = "\Embarques_Folio"
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
                    mensajeExito.mensaje = "Los datos se exportaron correctamente"
                    mensajeExito.ShowDialog()

                End If
                .Dispose()
            End With
        Else
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

    Private Sub chboxFechaEmbarque_CheckedChanged(sender As Object, e As EventArgs) Handles chboxFechaEmbarque.CheckedChanged
        If chboxFechaEmbarque.Checked Then
            lblEmbarqueDel.Enabled = True
            lblEmbarqueAl.Enabled = True
            dtpFechaEmbarqueDel.Enabled = True
            dtpFechaEmbarqueAl.Enabled = True
        Else
            lblEmbarqueDel.Enabled = False
            lblEmbarqueAl.Enabled = False
            dtpFechaEmbarqueDel.Enabled = False
            dtpFechaEmbarqueAl.Enabled = False
        End If
    End Sub

    Private Sub chboxFechaSalida_CheckedChanged(sender As Object, e As EventArgs) Handles chboxFechaSalida.CheckedChanged
        If chboxFechaSalida.Checked Then
            lblSalidaDel.Enabled = True
            lblSalidaAl.Enabled = True
            dtpFechaSalidaDel.Enabled = True
            dtpFechaSalidaAl.Enabled = True
        Else
            lblSalidaDel.Enabled = False
            lblSalidaAl.Enabled = False
            dtpFechaSalidaDel.Enabled = False
            dtpFechaSalidaAl.Enabled = False
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        chkSeleccionarTodo.Enabled = False
        chkSeleccionarTodo.Checked = False
        cboxStatusEmbarque.SelectedIndex = 1
        chboxFechaEmbarque.Checked = False
        chboxFechaSalida.Checked = False
        dtpFechaSalidaDel.Value = Now.Date
        dtpFechaSalidaAl.Value = Now.Date
        chboxSepararTienda.Checked = False
        rbtnFolio.Checked = True
        lblNumFiltrados.Text = "0"

        listInicial = New List(Of String)
        listPedidos = New List(Of String)
        listFolios = New List(Of String)
        listOrdenesTrabajo = New List(Of String)

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_YISTI") Then

        Else
            gridClientes.DataSource = listInicial
        End If

        gridPedidos.DataSource = listPedidos
        gridFoliosEmbarque.DataSource = listFolios
        gridOrdenesTrabajo.DataSource = listOrdenesTrabajo
        gridMensajeria.DataSource = listInicial
        gridEmbarques.DataSource = Nothing

        dtpFechaEmbarqueDel.Value = Now.Date
        dtpFechaEmbarqueAl.Value = Now.Date
        dtpFechaSalidaDel.Value = Now.Date
        dtpFechaSalidaAl.Value = Now.Date

        txtFolio.Text = ""
        txtOrdenTrabajo.Text = ""
        txtPedido.Text = ""

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub dtpFechaEmbarqueDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaEmbarqueDel.ValueChanged
        If dtpFechaEmbarqueAl.Value < dtpFechaEmbarqueDel.Value Then
            dtpFechaEmbarqueAl.Value = dtpFechaEmbarqueDel.Value
        End If
        dtpFechaEmbarqueAl.MinDate = dtpFechaEmbarqueDel.Value
    End Sub

    Private Sub dtpFechaSalidaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaSalidaDel.ValueChanged
        If dtpFechaSalidaAl.Value < dtpFechaSalidaDel.Value Then
            dtpFechaSalidaAl.Value = dtpFechaSalidaDel.Value
        End If
        dtpFechaSalidaAl.MinDate = dtpFechaSalidaDel.Value
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Cursor = Cursors.WaitCursor
        gridEmbarques.DataSource = Nothing
        lblNumFiltrados.Text = "0"
        chkSeleccionarTodo.Checked = False
        chkSeleccionarTodo.Enabled = True
        Dim FiltrosSalidas As New Entidades.FiltrosSalidas
        Dim objBU As New Negocios.SalidasAlmacenBU
        Dim tabla_embarques As New DataTable
        Dim lCliente As String = String.Empty
        Dim lPedidoSiCY As String = String.Empty
        Dim lOrdenTrabajo As String = String.Empty
        Dim lMensajeria As String = String.Empty
        Dim lFolioEmbarque As String = String.Empty
        Dim lCorrida As String = String.Empty


        FiltrosSalidas.PTipoConsulta = 2
        FiltrosSalidas.PAgrupamiento = obtenerFiltroAgrupamiento()
        FiltrosSalidas.PSepararTienda = If(chboxSepararTienda.Checked, 1, 0)
        FiltrosSalidas.PStatus = If(cboxStatusEmbarque.SelectedIndex > 0, cboxStatusEmbarque.SelectedItem.ToString, "")
        FiltrosSalidas.PPrimeraFechaDel = If(chboxFechaEmbarque.Checked, dtpFechaEmbarqueDel.Value.ToShortDateString, "")
        FiltrosSalidas.PPrimeraFechaAl = If(chboxFechaEmbarque.Checked, dtpFechaEmbarqueAl.Value.ToShortDateString, "")
        FiltrosSalidas.PSegundaFechaDel = If(chboxFechaSalida.Checked, dtpFechaSalidaDel.Value.ToShortDateString, "")
        FiltrosSalidas.PSegundaFechaAl = If(chboxFechaSalida.Checked, dtpFechaSalidaAl.Value.ToShortDateString, "")

        For Each row As UltraGridRow In gridClientes.Rows
            If row.Index = 0 Then
                lCliente += Replace(row.Cells(0).Text, ",", "")
            Else
                lCliente += ", " + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        FiltrosSalidas.PCliente = lCliente

        For Each row As UltraGridRow In gridFoliosEmbarque.Rows
            If row.Index = 0 Then
                lFolioEmbarque += Replace(row.Cells(0).Text, ",", "")
            Else
                lFolioEmbarque += ", " + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        FiltrosSalidas.PFolioEmbarque = lFolioEmbarque

        For Each row As UltraGridRow In gridPedidos.Rows
            If row.Index = 0 Then
                lPedidoSiCY += Replace(row.Cells(0).Text, ",", "")
            Else
                lPedidoSiCY += ", " + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        FiltrosSalidas.PPedidoSiCY = lPedidoSiCY

        For Each row As UltraGridRow In gridOrdenesTrabajo.Rows
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

        For Each row As UltraGridRow In gridCorrida.Rows

            If row.Index = 0 Then
                lCorrida = "'" & Replace(row.Cells(0).Text, ",", "") & "'"
            Else
                lCorrida = lCorrida + ", '" + Replace(row.Cells(0).Text, ",", "") & "'"
            End If

            'If row.Index = 0 Then
            '    lCorrida += Replace(row.Cells(0).Text, ",", "")
            'Else
            '    lCorrida += ", '" + Replace(row.Cells(0).Text, ",", "")
            'End If
        Next

        FiltrosSalidas.PCorridas = lCorrida
        FiltrosSalidas.PMensajeria = lMensajeria

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_YISTI") Then
            FiltrosSalidas.PEsYISTI = True
        Else
            FiltrosSalidas.PEsYISTI = False
        End If

        FiltrosSalidas.PCedis = cboxNaveAlmacen.SelectedValue

        tabla_embarques = objBU.consultaGenerarEmbarques(FiltrosSalidas)

        gridEmbarques.DataSource = tabla_embarques

        gridEmbarquesDiseño(gridEmbarques)
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

        If rbtnFolio.Checked Then
            grid.DisplayLayout.Bands(0).Columns("sade_idordentrabajo").Header.Caption = "OT"
            grid.DisplayLayout.Bands(0).Columns("sade_idordentrabajo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("sade_idordentrabajo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("sade_idfactura").Header.Caption = "Factura"
            grid.DisplayLayout.Bands(0).Columns("sade_idfactura").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("sade_idfactura").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("sade_añodocumento").Header.Caption = "Año Docto"
            grid.DisplayLayout.Bands(0).Columns("sade_añodocumento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("sade_añodocumento").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("sade_iddocumento").Header.Caption = "Docto"
            grid.DisplayLayout.Bands(0).Columns("sade_iddocumento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("sade_iddocumento").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("sade_fechadocumento").Header.Caption = "F Docto"
            grid.DisplayLayout.Bands(0).Columns("sade_fechadocumento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("sade_fechadocumento").Format = "dd/MM/yyyy"
            grid.DisplayLayout.Bands(0).Columns("sade_unidadEmbarqueNombre").Header.Caption = "Unidad"
            grid.DisplayLayout.Bands(0).Columns("sade_unidadEmbarqueNombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        End If

        If rbtnOrdenTrabajo.Checked Then
            grid.DisplayLayout.Bands(0).Columns("sade_idordentrabajo").Header.Caption = "OT"
            grid.DisplayLayout.Bands(0).Columns("sade_idordentrabajo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("sade_idordentrabajo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        End If
        If rbtnFacturaDocumento.Checked Then
            grid.DisplayLayout.Bands(0).Columns("sade_idfactura").Header.Caption = "Factura"
            grid.DisplayLayout.Bands(0).Columns("sade_idfactura").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("sade_idfactura").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("sade_añodocumento").Header.Caption = "Año Docto"
            grid.DisplayLayout.Bands(0).Columns("sade_añodocumento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("sade_añodocumento").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("sade_iddocumento").Header.Caption = "Docto"
            grid.DisplayLayout.Bands(0).Columns("sade_iddocumento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("sade_iddocumento").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("sade_fechadocumento").Header.Caption = "F Docto"
            grid.DisplayLayout.Bands(0).Columns("sade_fechadocumento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("sade_fechadocumento").Format = "dd/MM/yyyy"
        End If
        grid.DisplayLayout.Bands(0).Columns("sade_nombrecadena_cliente").Header.Caption = "Cliente"
        grid.DisplayLayout.Bands(0).Columns("sade_nombrecadena_cliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        If rbtnFolio.Checked = False Then
            grid.DisplayLayout.Bands(0).Columns("sade_mensajeriafactura").Header.Caption = "Mensajería Factura"
            grid.DisplayLayout.Bands(0).Columns("sade_mensajeriafactura").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        End If
        grid.DisplayLayout.Bands(0).Columns("sade_mensajeriarealnombre").Header.Caption = "Mensajería Real"
        grid.DisplayLayout.Bands(0).Columns("sade_mensajeriarealnombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        If rbtnFolio.Checked Then
            grid.DisplayLayout.Bands(0).Columns("sade_mensajeriarealid").Hidden = True
        End If
        grid.DisplayLayout.Bands(0).Columns("sade_idpedido").Header.Caption = "Pedido"
        grid.DisplayLayout.Bands(0).Columns("sade_idpedido").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("sade_idpedido").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Total_ParesEmbarcados").Header.Caption = "PrsEmbarcados"
        grid.DisplayLayout.Bands(0).Columns("Total_ParesEmbarcados").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Total_ParesEmbarcados").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Total_ParesEmbarcados").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("paresSalida").Header.Caption = "PrsSalida"
        grid.DisplayLayout.Bands(0).Columns("paresSalida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("paresSalida").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("paresSalida").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("paresEnRuta").Header.Caption = "PrsEnRuta"
        grid.DisplayLayout.Bands(0).Columns("paresEnRuta").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("paresEnRuta").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("paresEnRuta").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("paresEntregados").Header.Caption = "PrsEntregados"
        grid.DisplayLayout.Bands(0).Columns("paresEntregados").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("paresEntregados").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("paresEntregados").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("paresNoRecibidos").Header.Caption = "PrsNoRecibidos"
        grid.DisplayLayout.Bands(0).Columns("paresNoRecibidos").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("paresNoRecibidos").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("paresNoRecibidos").Format = "n0"
        If rbtnFolio.Checked = False Then
            grid.DisplayLayout.Bands(0).Columns("Total_Pares").Header.Caption = "Pares"
            grid.DisplayLayout.Bands(0).Columns("Total_Pares").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Total_Pares").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Total_Pares").Format = "n0"
        End If
        If rbtnOrdenTrabajo.Checked Then
            grid.DisplayLayout.Bands(0).Columns("sade_usuarioconfirmacionordentrabajo").Header.Caption = "Capturó"
            grid.DisplayLayout.Bands(0).Columns("sade_usuarioconfirmacionordentrabajo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("sade_fechaconfirmacionordentrabajo").Header.Caption = "Captura"
            grid.DisplayLayout.Bands(0).Columns("sade_fechaconfirmacionordentrabajo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
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
        If rbtnFolio.Checked = False Then
            grid.DisplayLayout.Bands(0).Columns("sade_usuarioembarquenombre").Header.Caption = "Embarcó"
            grid.DisplayLayout.Bands(0).Columns("sade_usuarioembarquenombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        End If
        grid.DisplayLayout.Bands(0).Columns("sade_operadorembarque").Header.Caption = "Entregó"
        grid.DisplayLayout.Bands(0).Columns("sade_operadorembarque").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        If rbtnFolio.Checked = False Then
            grid.DisplayLayout.Bands(0).Columns("sade_fechasalida").Header.Caption = "Fecha Salida"
            grid.DisplayLayout.Bands(0).Columns("sade_fechasalida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("sade_fechasalida").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("sade_fechasalida").Format = "dd/MM/yyyy HH:mm:ss"
            grid.DisplayLayout.Bands(0).Columns("sade_salidaid").Header.Caption = "#Salida"
            grid.DisplayLayout.Bands(0).Columns("sade_salidaid").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("sade_salidaid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("sade_salidaid").Format = "n0"
            grid.DisplayLayout.Bands(0).Columns("sade_salidaid").Hidden = True
        End If

        grid.DisplayLayout.Bands(0).Columns("fechaSalida").Header.Caption = "Fecha Salida"
        grid.DisplayLayout.Bands(0).Columns("fechaSalida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("fechaSalida").Format = "dd/MM/yyyy HH:mm:ss"
        grid.DisplayLayout.Bands(0).Columns("IdSalida").Header.Caption = "#Salida"
        grid.DisplayLayout.Bands(0).Columns("IdSalida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("IdSalida").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("IdSalida").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("PedidoSAY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        'grid.DisplayLayout.Bands(0).Columns("Incidencias").Header.Caption = "Incidencias"
        'grid.DisplayLayout.Bands(0).Columns("Incidencias").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        'grid.DisplayLayout.Bands(0).Columns("Incidencias").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        'grid.DisplayLayout.Bands(0).Columns("Incidencias").Format = "n0"

        'grid.DisplayLayout.Bands(0).Columns("Cancelaciones").Header.Caption = "Cancelaciones"
        'grid.DisplayLayout.Bands(0).Columns("Cancelaciones").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        'grid.DisplayLayout.Bands(0).Columns("Cancelaciones").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        'grid.DisplayLayout.Bands(0).Columns("Cancelaciones").Format = "n0"

        grid.DisplayLayout.Bands(0).Columns("seleccionar").Width = 20
        grid.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
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
        If rbtnOrdenTrabajo.Checked Then
            grid.DisplayLayout.Bands(0).Columns("sade_fechaconfirmacionordentrabajo").Width = 65
        End If
        If rbtnFacturaDocumento.Checked Then
            grid.DisplayLayout.Bands(0).Columns("sade_fechadocumento").Width = 65
        End If
        grid.DisplayLayout.Bands(0).Columns("sade_fechaembarque").Width = 115
        If rbtnFolio.Checked = False Then
            grid.DisplayLayout.Bands(0).Columns("Total_Pares").Width = 45
        End If


        Dim summary1, summary2, summary3, summary4, summary5, summary6 As SummarySettings
        'Dim summary7 As SummarySettings
        If rbtnFolio.Checked = False Then
            summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Total_Pares"))
            summary1.DisplayFormat = "{0:#,##0}"
            summary1.Appearance.TextHAlign = HAlign.Right
        End If
        summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Embarcados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Total_ParesEmbarcados"))
        summary3 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Salida", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("paresSalida"))
        summary4 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares En Ruta", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("paresEnRuta"))
        summary5 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Entregados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("paresEntregados"))
        summary6 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares No Recibidos", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("paresNoRecibidos"))
        'summary7 = grid.DisplayLayout.Bands(0).Summaries.Add("Incidencias", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Incidencias"))
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        summary2.DisplayFormat = "{0:#,##0}"
        summary2.Appearance.TextHAlign = HAlign.Right
        summary3.DisplayFormat = "{0:#,##0}"
        summary3.Appearance.TextHAlign = HAlign.Right
        summary4.DisplayFormat = "{0:#,##0}"
        summary4.Appearance.TextHAlign = HAlign.Right
        summary5.DisplayFormat = "{0:#,##0}"
        summary5.Appearance.TextHAlign = HAlign.Right
        summary6.DisplayFormat = "{0:#,##0}"
        summary6.Appearance.TextHAlign = HAlign.Right
        'summary7.DisplayFormat = "{0:#,##0}"
        'summary7.Appearance.TextHAlign = HAlign.Right

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


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_SAL_GENEMBARQUES", "ALM_SAL_GENERAR_EMBARQUES") Then
            For Each row As UltraGridRow In grid.Rows
                If row.Cells("sade_statusembarque").Value <> "EN RUTA" Then
                    row.Cells("seleccionar").Hidden = True
                End If
            Next
        Else
            For Each row As UltraGridRow In grid.Rows
                row.Cells("seleccionar").Hidden = True
            Next
            grid.DisplayLayout.Bands(0).Columns("seleccionar").Hidden = True
        End If
    End Sub

    Private Function obtenerFiltroAgrupamiento()
        Dim tipoAgrupamiento As Integer = 0
        If rbtnOrdenTrabajo.Checked Then
            tipoAgrupamiento = 1 'Agrupamiento por orden de trabajo
        End If
        If rbtnFacturaDocumento.Checked Then
            tipoAgrupamiento = 2 'Agrupamiento por factura / documento
        End If
        If rbtnPedidos.Checked Then
            tipoAgrupamiento = 3 'Agrupamiento por pedido
        End If
        If rbtnFolio.Checked Then
            tipoAgrupamiento = 4
        End If

        Return tipoAgrupamiento
    End Function

    Private Sub gridEmbarques_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles gridEmbarques.AfterCellUpdate
        ContarRegistrosSeleccionados()
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

    Private Sub gridEmbarques_CellChange(sender As Object, e As CellEventArgs) Handles gridEmbarques.CellChange
        Try
            Dim Seleccionados As Integer = 0
            If e.Cell.Column.ToString = "seleccionar" And e.Cell.Hidden = False Then
                If CBool(e.Cell.Value) Then
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

    Private Sub btnEditarEmbarque_Click(sender As Object, e As EventArgs) Handles btnEditarEmbarque.Click
        'Dim listaRenglonesSeleccionados As New List(Of UltraGridRow)
        Dim dtRenglonesSeleccionados As New DataTable
        Dim tipoConsultaMensaje As String = String.Empty
        Dim tipoConsulta As Integer = 0
        Dim renglonTabla As New Object
        Dim contEmbarquesSeleccionados As Integer = 0
        Dim embarqueSeleccionado As Integer = 0
        Dim dtEmbarqueConSalidaCancelada As DataTable
        Dim objBu As New Negocios.SalidasAlmacenBU

        If rbtnFolio.Checked = True Then
            Cursor = Cursors.WaitCursor
            For Each row As UltraGridRow In gridEmbarques.Rows
                If (CBool(row.Cells("seleccionar").Value) And row.Cells("seleccionar").Hidden = False) Or (row.Selected And row.Cells("seleccionar").Hidden = False) Then
                    If contEmbarquesSeleccionados = 0 Then
                        embarqueSeleccionado = row.Cells("sade_embarqueid").Value
                    Else
                        If row.Cells("sade_embarqueid").Value <> embarqueSeleccionado Then
                            Cursor = Cursors.Default
                            show_message("Advertencia", "Debe seleccionar un embarque a editar a la vez")
                            Exit Sub
                        End If
                    End If
                    contEmbarquesSeleccionados += 1
                End If
            Next
            If contEmbarquesSeleccionados <> 0 Then
                dtEmbarqueConSalidaCancelada = objBu.seleccionarEmbarqueAEditar(embarqueSeleccionado)
                If dtEmbarqueConSalidaCancelada.Rows.Count > 0 Then
                    tipoConsulta = 5
                    dtRenglonesSeleccionados.Columns.Add("IDSalidaDetalle")
                    dtRenglonesSeleccionados.Columns.Add("Cliente")
                    If chboxSepararTienda.Checked Then
                        dtRenglonesSeleccionados.Columns.Add("Tienda")
                        dtRenglonesSeleccionados.Columns.Add("idTienda")
                    End If
                    dtRenglonesSeleccionados.Columns.Add("Pedido")
                    dtRenglonesSeleccionados.Columns.Add("Pares")

                    Dim contador As Integer = 0
                    For Each row As UltraGridRow In gridEmbarques.Rows.GetFilteredInNonGroupByRows
                        If (CBool(row.Cells("seleccionar").Value) And row.Cells("seleccionar").Hidden = False) Or (row.Selected And row.Cells("seleccionar").Hidden = False) Or (row.Cells("sade_embarqueid").Value = embarqueSeleccionado) Then
                            dtRenglonesSeleccionados.Rows.Add(renglonTabla)
                            dtRenglonesSeleccionados.Rows(contador).Item("IDSalidaDetalle") = row.Cells("IDSalidaDetalle").Value
                            dtRenglonesSeleccionados.Rows(contador).Item("Cliente") = row.Cells("sade_nombrecadena_cliente").Value
                            'dtRenglonesSeleccionados.Rows(contador).Item("Mensajeria_Factura") = row.Cells("sade_mensajeriafactura").Value
                            dtRenglonesSeleccionados.Rows(contador).Item("Pedido") = row.Cells("sade_idpedido").Value
                            If rbtnFolio.Checked = False Then
                                dtRenglonesSeleccionados.Rows(contador).Item("Pares") = row.Cells("Total_Pares").Value
                            Else
                                dtRenglonesSeleccionados.Rows(contador).Item("Pares") = row.Cells("Total_paresEmbarcados").Value
                            End If
                            If chboxSepararTienda.Checked Then
                                dtRenglonesSeleccionados.Rows(contador).Item("Tienda") = row.Cells("sade_nombredistribucion_tienda").Value
                            End If

                            contador += 1
                        End If
                    Next
                    If dtRenglonesSeleccionados.Rows.Count > 0 Then
                        Dim objVentanaEmbarques As New GenerarEntregaAlmacenForm(dtRenglonesSeleccionados, tipoConsulta, chboxSepararTienda.Checked, embarqueSeleccionado)
                        Cursor = Cursors.Default
                        gridEmbarques.DataSource = Nothing
                        objVentanaEmbarques.MdiParent = Me.MdiParent
                        Me.WindowState = 1
                        objVentanaEmbarques.Show()
                    Else
                        If rbtnFolio.Checked Then
                            tipoConsultaMensaje = "un Embarque"
                        End If
                        Cursor = Cursors.Default
                        show_message("Advertencia", "Debe seleccionar " + tipoConsultaMensaje + " a editar")
                    End If
                Else
                    Cursor = Cursors.Default
                    show_message("Advertencia", "Debe seleccionar un Embarque que haya sido cancelado anteriormente para editarlo")
                End If
            Else
                Cursor = Cursors.Default
                show_message("Advertencia", "Debe seleccionar Embarque a editar")
            End If
        Else
            show_message("Advertencia", "Debe seleccionar el agrupamiento Folio de Embarque para poder editar")
        End If
    End Sub

    Private Sub rbtnFolio_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnFolio.CheckedChanged
        If rbtnFolio.Checked Then
            btnImprimirEmbarque.Enabled = True
            lblImprimirEmbarque.Enabled = True
        Else
            btnImprimirEmbarque.Enabled = False
            lblImprimirEmbarque.Enabled = False
        End If
        gridEmbarques.DataSource = Nothing
    End Sub

    Private Sub btnImprimirEmbarque_Click(sender As Object, e As EventArgs) Handles btnImprimirEmbarque.Click
        Dim contEmbarquesSeleccionados As Integer = 0
        If gridEmbarques.Rows.Count > 0 Then
            For Each row As UltraGridRow In gridEmbarques.Rows.GetFilteredInNonGroupByRows
                If (CBool(row.Cells("seleccionar").Value) And row.Cells("seleccionar").Hidden = False) Or (row.Selected) Then
                    contEmbarquesSeleccionados += 1
                    'If row.Cells("sade_mensajeriarealnombre").Value <> "YUYIN (NOSOTROS MISMOS)" Then
                    '    show_message("Advertencia", "Únicamente se pueden imprimir embarques con mensajería ""YUYIN (NOSOTROS MISMOS)""")
                    '    Exit Sub
                    'End If
                    If row.Cells("sade_nombrecadena_cliente").Value = "COPPEL" Then
                        show_message("Advertencia", "La impresión de embarques no disponible para COPPEL")
                        Exit Sub
                    End If
                End If
            Next
            If contEmbarquesSeleccionados > 0 Then
                imprimirEmbarque()
            Else
                show_message("Advertencia", "Debe seleccionar al menos un embarque a imprimir")
            End If
        Else
            show_message("Advertencia", "No hay embarques a imprimir")
        End If
    End Sub

    Public Sub imprimirEmbarque()
        Dim dsOrdenesEmbarque As New DataSet("OrdenEmbarque")
        Dim Embarque As New DataTable("Embarque")
        Dim detalleEmbarque As New DataTable("Detalles")
        Dim Cliente As New DataTable("Cliente")
        Dim obj As New Negocios.SalidasAlmacenBU
        Dim objBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim idEmbarque As Integer = 0
        Dim totalPares As Integer = 0
        Dim idPedido As Integer = 0
        Dim orden As Integer = 0
        Dim embarquesSeleccionados As String = ""

        'With gridEmbarques
        '    If .ActiveRow Is Nothing Then Exit Sub
        '    If .ActiveRow.Index < 0 Then Exit Sub
        'End With

        For Each renglon As UltraGridRow In gridEmbarques.Rows.GetFilteredInNonGroupByRows
            If CBool(renglon.Cells("seleccionar").Value) = True Or (renglon.Selected = True) Then
                idEmbarque = renglon.Cells("sade_embarqueid").Value
                If embarquesSeleccionados = "" Then
                    embarquesSeleccionados += idEmbarque.ToString
                Else
                    embarquesSeleccionados += ", " + idEmbarque.ToString
                End If
            End If
        Next

        detalleEmbarque = obj.imprimirOrdenEmbarque(embarquesSeleccionados, 2)
        detalleEmbarque.TableName = "Detalles"
        Embarque = obj.imprimirOrdenEmbarque(embarquesSeleccionados, 1)
        Embarque.TableName = "Embarque"
        Cliente = obj.imprimirOrdenEmbarque(embarquesSeleccionados, 3)
        Cliente.TableName = "Cliente"
        dsOrdenesEmbarque.Tables.Add(Embarque)
        dsOrdenesEmbarque.Tables.Add(detalleEmbarque)
        dsOrdenesEmbarque.Tables.Add(Cliente)

        EntidadReporte = objBU.LeerReporteporClave("ALM_SAL_ORDEMBARQUE")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

        Dim reporte As New StiReport
        reporte.Load(archivo)

        reporte.Compile()
        reporte.Dictionary.Clear()
        reporte.RegData(dsOrdenesEmbarque)
        reporte.Dictionary.Synchronize()
        reporte.Show()

    End Sub

    Private Sub ConsultarEmbarquesForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.WindowState = 2
        btnAceptar_Click(sender, e)
    End Sub

    Private Sub btnVerParesNoRecibidos_Click(sender As Object, e As EventArgs) Handles btnVerParesNoRecibidos.Click
        Dim renglonesSeleccionados As Integer = 0
        Dim tipoConsultaMensaje As String
        tipoConsultaMensaje = String.Empty

        Dim idEmbarque As Integer = 0
        Dim cliente As String = String.Empty
        Dim fechaEmbarque As String = String.Empty
        Dim pares As Integer = 0
        Dim paresEmbarque As Integer = 0
        Dim paresEntregados As Integer = 0
        Dim paresFaltantes As Integer = 0
        Dim operador As Integer = 0
        Dim tipoConsulta As Integer = 0  '1 Modificación de pares devueltos, 2 Consulta de pares devueltos

        For Each row As UltraGridRow In gridEmbarques.Rows.GetFilteredInNonGroupByRows
            If (CBool(row.Cells("seleccionar").Value) And row.Cells("seleccionar").Hidden = False) Or (row.Selected And row.Cells("seleccionar").Hidden = False) Then
                idEmbarque = row.Cells("sade_embarqueid").Value
                cliente = row.Cells("sade_nombrecadena_cliente").Value
                fechaEmbarque = row.Cells("sade_fechaembarque").Value
                If rbtnFolio.Checked = False Then
                    pares = row.Cells("Total_Pares").Value
                Else
                    pares = row.Cells("Total_paresEmbarcados").Value
                End If
                paresEmbarque = row.Cells("Total_paresEmbarcados").Value
                paresEntregados = row.Cells("paresEntregados").Value
                paresFaltantes = (pares - paresEntregados)
                operador = 0
                renglonesSeleccionados += 1
                tipoConsulta = 2
            End If
        Next
        If renglonesSeleccionados = 0 Then
            For Each row As UltraGridRow In gridEmbarques.Rows.GetFilteredInNonGroupByRows
                If row.Selected Then
                    If row.Cells("sade_nombrecadena_cliente").Value <> "COPPEL" Then
                        idEmbarque = row.Cells("sade_embarqueid").Value
                        cliente = row.Cells("sade_nombrecadena_cliente").Value
                        fechaEmbarque = row.Cells("sade_fechaembarque").Value
                        If rbtnFolio.Checked = False Then
                            pares = row.Cells("Total_Pares").Value
                        Else
                            pares = row.Cells("Total_paresEmbarcados").Value
                        End If
                        paresEmbarque = row.Cells("Total_paresEmbarcados").Value
                        paresEntregados = row.Cells("paresEntregados").Value
                        paresFaltantes = (pares - paresEntregados)
                        operador = 0
                        renglonesSeleccionados += 1
                        tipoConsulta = 2
                    Else
                        show_message("Advertencia", "Pares devueltos no disponibles para COPPEL")
                        Exit Sub
                    End If
                End If

            Next
        End If
        If renglonesSeleccionados > 0 And renglonesSeleccionados < 2 Then
            Dim objVentanaDevoluciones As New DevolucionInformativaSalidaAlmacenForm(idEmbarque, cliente, fechaEmbarque, pares, paresEmbarque, paresEntregados, tipoConsulta)
            objVentanaDevoluciones.MdiParent = Me.MdiParent
            Me.WindowState = 1
            objVentanaDevoluciones.Show()
        Else
            If rbtnOrdenTrabajo.Checked Then
                tipoConsultaMensaje = "una Orden de trabajo"
            End If
            If rbtnFacturaDocumento.Checked Then
                tipoConsultaMensaje = "una Factura / Documento"
            End If
            If rbtnPedidos.Checked Then
                tipoConsultaMensaje = "un Pedido"
            End If
            If rbtnFolio.Checked Then
                tipoConsultaMensaje = "un Embarque"
            End If
            Cursor = Cursors.Default
            show_message("Advertencia", "Debe seleccionar " + tipoConsultaMensaje + " para ver los pares devueltos")
        End If
    End Sub

    Private Sub btnCancelarSalida_Click(sender As Object, e As EventArgs) Handles btnCancelarSalida.Click
        If rbtnFolio.Checked = True Then
            'If cboxStatusEmbarque.SelectedIndex <= 0 And gridClientes.Rows.Count = 0 And gridPedidos.Rows.Count = 0 And gridOrdenesTrabajo.Rows.Count = 0 Then
            If gridClientes.Rows.Count = 0 And gridPedidos.Rows.Count = 0 And gridOrdenesTrabajo.Rows.Count = 0 Then
                Dim confirmacion As New confirmarFormGrande
                Dim objBU As New Negocios.SalidasAlmacenBU
                Dim idSalidasGenerarSalida As String
                Dim idEmbarqueCancelarSalida As Integer = 0
                Dim idEmbarquesCancelarSalida As String
                Dim totalParesSeleccionados As Integer = 0
                Dim totalParesNoRecibidos As Integer = 0
                Dim totalPRenglonesSeleccionados As Integer = 0
                idSalidasGenerarSalida = String.Empty
                idEmbarquesCancelarSalida = String.Empty
                Dim indiceEmbarqueEnArreglo As Integer = -1

                For Each row As UltraGridRow In gridEmbarques.Rows.GetFilteredInNonGroupByRows
                    If row.Selected = True And row.Cells("seleccionar").Hidden = True And row.Cells("sade_statusembarque").Value = "ENTREGA COMPLETA" Then
                        If row.Cells("sade_fechadocumento").Value.year = Date.Now.Year And row.Cells("sade_fechadocumento").Value.month = Date.Now.Month Then
                            If row.Cells("sade_nombrecadena_cliente").Value <> "COPPEL" Then
                                indiceEmbarqueEnArreglo = -1
                                indiceEmbarqueEnArreglo = Array.IndexOf(Split(idEmbarquesCancelarSalida), row.Cells("sade_embarqueid").Value.ToString())
                                If indiceEmbarqueEnArreglo = -1 Then
                                    If idEmbarquesCancelarSalida <> "" Then
                                        idEmbarquesCancelarSalida += ", "
                                    End If
                                    idEmbarquesCancelarSalida += row.Cells("sade_embarqueid").Value.ToString()
                                End If
                                idEmbarqueCancelarSalida = row.Cells("sade_embarqueid").Value
                                If indiceEmbarqueEnArreglo = -1 Then
                                    For Each rowEmbarque As UltraGridRow In gridEmbarques.Rows.GetFilteredInNonGroupByRows
                                        If idEmbarqueCancelarSalida = rowEmbarque.Cells("sade_embarqueid").Value And rowEmbarque.Cells("seleccionar").Hidden = True And rowEmbarque.Cells("sade_statusembarque").Value = "ENTREGA COMPLETA" Then
                                            If rowEmbarque.Cells("sade_fechadocumento").Value.year = Date.Now.Year And rowEmbarque.Cells("sade_fechadocumento").Value.month = Date.Now.Month Then
                                                If rowEmbarque.Cells("sade_nombrecadena_cliente").Value <> "COPPEL" Then
                                                    If idSalidasGenerarSalida <> "" Then
                                                        idSalidasGenerarSalida += ","
                                                    End If
                                                    idSalidasGenerarSalida += rowEmbarque.Cells("IDSalidaDetalle").Value
                                                    totalParesSeleccionados += rowEmbarque.Cells("Total_ParesEmbarcados").Value
                                                    totalParesNoRecibidos += rowEmbarque.Cells("paresNoRecibidos").Value
                                                Else
                                                    show_message("Advertencia", "Las salidas de COPPEL no se pueden cancelar")
                                                    Exit Sub
                                                End If
                                            Else
                                                show_message("Advertencia", "Debe seleccionar embarques con fecha de documento del mes actual para cancelar")
                                                Exit Sub
                                            End If
                                        Else
                                            If (idEmbarqueCancelarSalida = rowEmbarque.Cells("sade_embarqueid").Value And rowEmbarque.Cells("seleccionar").Hidden = False) Or (idEmbarqueCancelarSalida = rowEmbarque.Cells("sade_embarqueid").Value And rowEmbarque.Cells("sade_statusembarque").Value <> "ENTREGA COMPLETA") Then
                                                show_message("Advertencia", "Debe seleccionar embarques con salidas asignadas y entregadas completamente para cancelar")
                                                Exit Sub
                                            End If
                                        End If
                                    Next
                                End If
                                totalPRenglonesSeleccionados += 1
                            Else
                                show_message("Advertencia", "Las salidas de COPPEL no se pueden cancelar")
                                Exit Sub
                            End If
                        Else
                            show_message("Advertencia", "Debe seleccionar embarques con fecha de documento del mes actual para cancelar")
                            Exit Sub
                        End If
                    Else
                        If (row.Selected = True And row.Cells("seleccionar").Hidden = False) Or (CBool(row.Cells("seleccionar").Value) = True) Or (row.Selected = True And row.Cells("sade_statusembarque").Value <> "ENTREGA COMPLETA") Then
                            show_message("Advertencia", "Debe seleccionar embarques con salidas asignadas y entregadas completamente para cancelar")
                            Exit Sub
                        End If
                    End If
                Next
                Dim mensajeMostrar As String = String.Empty
                Dim totalEmbarquesSeleccionados As Integer = 0
                totalEmbarquesSeleccionados = Split(idEmbarquesCancelarSalida).Count
                If totalPRenglonesSeleccionados > 0 Then
                    If Split(idEmbarquesCancelarSalida).Count > 1 Then
                        'mensajeMostrar = "los embarques " + idEmbarquesCancelarSalida.ToString + " seleccionados"
                        mensajeMostrar = "los " + totalEmbarquesSeleccionados.ToString("#,##0") + " embarques seleccionados"
                    Else
                        'mensajeMostrar = "el embarque " + idEmbarqueCancelarSalida.ToString + " seleccionado"
                        mensajeMostrar = "el embarque seleccionado"
                    End If
                    'confirmacion.mensaje = "¿Desea cancelar la salida de los " + totalParesSeleccionados.ToString("#,##0") + " pares en " + mensajeMostrar + "?"
                    If totalEmbarquesSeleccionados > 1 Then
                        confirmacion.mensaje = "¿Desea cancelar la salida de los " + totalEmbarquesSeleccionados.ToString("#,##0") + " embarques seleccionados por " + totalParesSeleccionados.ToString("#,##0") + " pares? (Únicamente puede cancelar salidas que se vayan a entregar nuevamente con las mismas facturas/documentos, en caso contrario debe cancelar la salida vía SICY; los pares quedarán con status EN RUTA hasta que se genere la salida nuevamente)"
                    Else
                        confirmacion.mensaje = "¿Desea cancelar la salida del embarque seleccionado por " + totalParesSeleccionados.ToString("#,##0") + " pares? (Únicamente puede cancelar salidas que se vayan a entregar nuevamente con las mismas facturas/documentos, en caso contrario debe cancelar la salida vía SICY; los pares quedarán con status EN RUTA hasta que se genere la salida nuevamente)"
                    End If
                    If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Cursor = Cursors.WaitCursor
                        gridEmbarques.DataSource = Nothing
                        Dim resultadoCancelarSalida As New DataTable
                        resultadoCancelarSalida = objBU.cancelarSalidas(idSalidasGenerarSalida)

                        Cursor = Cursors.Default
                        show_message(resultadoCancelarSalida.Rows(0).Item("tipoResultado"), resultadoCancelarSalida.Rows(0).Item("resultado"))
                        btnAceptar_Click(sender, e)
                    End If
                Else
                    show_message("Advertencia", "No hay embarques seleccionados")
                End If
            Else
                show_message("Advertencia", "Debe quitar los filtros: Cliente, Pedido SICY y Orden de trabajo. Para cancelar salidas")
            End If
        Else
            show_message("Advertencia", "Debe seleccionar el agrupamiento Folio de Embarque para cancelar salidas")
        End If
    End Sub

    Private Sub rbtnFacturaDocumento_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnFacturaDocumento.CheckedChanged
        gridEmbarques.DataSource = Nothing
    End Sub

    Private Sub rbtnOrdenTrabajo_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOrdenTrabajo.CheckedChanged
        gridEmbarques.DataSource = Nothing
    End Sub

    Private Sub rbtnPedidos_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnPedidos.CheckedChanged
        gridEmbarques.DataSource = Nothing
    End Sub

    Private Sub cboxStatusEmbarque_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxStatusEmbarque.SelectedIndexChanged
        gridEmbarques.DataSource = Nothing
    End Sub

    Private Sub btnBitacoraEmbarquesSalidas_Click(sender As Object, e As EventArgs) Handles btnBitacoraEmbarquesSalidas.Click
        Dim idBuscarEmbarques As String
        Dim renglonesSeleccionados As Integer = 0
        Dim idTienda As String
        idTienda = String.Empty
        idBuscarEmbarques = String.Empty
        If rbtnFolio.Checked Then
            Cursor = Cursors.WaitCursor
            For Each row As UltraGridRow In gridEmbarques.Rows.GetFilteredInNonGroupByRows
                If ((CBool(row.Cells("seleccionar").Value) And row.Cells("seleccionar").Hidden = False) Or (row.Selected = True)) And (row.Cells("sade_embarqueid").Value <> 0) Then
                    If idBuscarEmbarques <> "" Then
                        idBuscarEmbarques += ","
                    End If
                    idBuscarEmbarques += row.Cells("sade_embarqueid").Value.ToString()
                    renglonesSeleccionados += 1
                End If
            Next
            If renglonesSeleccionados > 0 Then
                Dim objVentanaPares As New BitacoraEmbarquesSalidas(idBuscarEmbarques)
                Cursor = Cursors.Default
                objVentanaPares.MdiParent = Me.MdiParent
                objVentanaPares.Show()
            Else
                Cursor = Cursors.Default
                show_message("Advertencia", "No hay embarques seleccionados")
            End If
        Else
            show_message("Advertencia", "Debe seleccionar el agrupamiento Folio de Embarque para ver la bitácora")
        End If
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

    Private Sub btnActualizarDatos_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnFiltro_Corrida_Click(sender As Object, e As EventArgs) Handles btnFiltro_Corrida.Click
        Dim listado As New ListadoParametroSalidasForm
        listado.tipo_busqueda = 7
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridCorrida.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridCorrida.DataSource = listado.listParametros
        With gridCorrida
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True

            .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Corrida"
        End With
        'gridCorrida.DataSource = Nothing
    End Sub

    Private Sub gridCorrida_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridCorrida.InitializeLayout
        grid_simple_diseño(gridCorrida)
        gridCorrida.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Corrida"
    End Sub

    Private Sub gridCorrida_KeyDown(sender As Object, e As KeyEventArgs) Handles gridCorrida.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridCorrida.DeleteSelectedRows(False)
    End Sub
End Class