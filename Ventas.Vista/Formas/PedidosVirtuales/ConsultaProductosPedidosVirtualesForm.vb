Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Documents

Public Class ConsultaProductosPedidosVirtualesForm

    Public cliente As Entidades.Cliente
    Public tipoPedido As String
    Public idtipoPedido As Int32
    Public ListaPrecios As Entidades.ListaBase
    Public idCliente As Int32
    Public estatus As String
    Public departamento As Int32
    Dim objDA As New Negocios.PedidosVirtualesBU
    Public tablaProductos As New DataTable
    Dim banderaTabla As Boolean = False
    Public EncabezadoPedido As PedidoVirtualForm

    Private Sub ConsultaProductosPedidosVirtualesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Normal
        inicializarFormulario(False)
    End Sub

    Private Sub inicializarFormulario(ByVal bandera As Boolean)
        Dim listaMarcas As New List(Of Entidades.Marcas)
        txtCliente.Text = cliente.nombregenerico
        idCliente = cliente.clienteid
        txtListaPrecio.Text = ListaPrecios.PListaBaseNombre

        If departamento = 33 Then
            btnSeleccionar.Enabled = False
        End If

        chkMostrar.Checked = False
        If idtipoPedido = 5 Then
            txtModeloSAY.Visible = False
            txtModeloSICY.Visible = False
            lblModeloSay.Visible = False
            lblModeloSicy.Visible = False
            lblAviso2.Visible = True
            lblAviso1.Visible = False
            txtTipoPedido.Text = tipoPedido
            GroupBox3.Text = "Filtros: Proyeccion de ventas (Colección)"
        Else
            txtModeloSAY.Enabled = True
            txtModeloSICY.Enabled = True
            If idtipoPedido = 4 Then
                lblAviso2.Visible = True
                lblAviso1.Visible = False
                txtTipoPedido.Text = tipoPedido
                GroupBox3.Text = "Filtros: Borrador de cliente (Colección - Modelo)"
            Else
                lblAviso1.Visible = True
                lblAviso2.Visible = False
                txtTipoPedido.Text = tipoPedido
                GroupBox3.Text = "Filtros: Pedido no confirmado (Colección - Modelo - Piel - Color - Corrida)"
            End If
        End If

        If estatus = "CAPTURADO" Then
            btnSeleccionar.Enabled = True
        End If

        listaMarcas = objDA.ListaMarcasCliente(ListaPrecios.PListaBaseId)
        If listaMarcas.Count > 0 Then
            cmbMarcas.DataSource = listaMarcas
            cmbMarcas.ValueMember = "PMarcaId"
            cmbMarcas.DisplayMember = "PDescripcion"
        End If

        If tablaProductos Is Nothing Then
            tablaProductos = New DataTable
        End If
    End Sub

    Private Sub CargarListaColecciones()
        Dim lista As New List(Of Entidades.Coleccion)

        If cmbMarcas.SelectedIndex > 0 Then
            lista = objDA.ListaColeccionesMarcas(CInt(cmbMarcas.SelectedValue.ToString), ListaPrecios.PListaBaseId)
            cmbColeccion.DataSource = lista
            If lista.Count > 0 Then
                cmbColeccion.DataSource = lista
                cmbColeccion.ValueMember = "PColeID"
                cmbColeccion.DisplayMember = "PColeccionDescripcion"
            End If
        End If
    End Sub

    Private Sub generarFiltros()
        Dim marca, coleccion, modelosay, modelosicy, mostrar As Int32
        Dim articulos As New DataTable

        If cmbMarcas.SelectedIndex > 0 Then
            marca = CInt(cmbMarcas.SelectedValue.ToString)
        End If

        If cmbColeccion.SelectedIndex > 0 Then
            coleccion = CInt(cmbColeccion.SelectedValue.ToString)
        End If

        If txtModeloSAY.Text.Trim <> "" Then
            modelosay = txtModeloSAY.Text
        End If

        If txtModeloSICY.Text.Trim <> "" Then
            modelosicy = txtModeloSICY.Text
        End If

        If chkMostrar.Checked Then
            mostrar = 1
        End If
        articulos = objDA.ObtenerArticulos(ListaPrecios.PListaBaseId, marca, coleccion, modelosay, modelosicy, mostrar, idtipoPedido)

        If articulos.Rows.Count > 0 Then
            Dim ColeccionAnterior As Int32 = 0, contador As Int32 = 0
            Dim EstatusAnterior As String = "", EstatusActual As String = ""

            If idtipoPedido = 5 Then
                For Each row As DataRow In articulos.Rows
                    If CInt(row.Item("IdColeccionSAY").ToString) = ColeccionAnterior Then
                        EstatusActual = row.Item("Estatus")
                        row.Item("Estatus") = EstatusActual.ToString & ", " & EstatusAnterior.ToString
                        row.AcceptChanges()
                        articulos.Rows.Item(contador - 1).Delete()
                    Else
                        ColeccionAnterior = CInt(row.Item("IdColeccionSAY"))
                        EstatusAnterior = row.Item("Estatus")
                    End If
                    contador += 1
                Next
            End If
            

            grdArticulos.DataSource = articulos
            crearformatoGrid()
        Else
            grdArticulos.DataSource = Nothing
        End If
        chkSeleccionar.Checked = False
        SeleccionarRegistros()
    End Sub

    Public Sub limpiarCampos()
        grdArticulos.DataSource = Nothing
        If cmbMarcas.SelectedIndex > 0 Then
            cmbColeccion.SelectedIndex = 0
        End If
        chkSeleccionar.Checked = False
        lblContados.Text = "0"
        cmbMarcas.SelectedIndex = 0
        txtModeloSAY.Text = ""
        txtModeloSICY.Text = ""
        chkMostrar.Checked = False
    End Sub

    Private Sub copiarRenglon()

        If CInt(lblContados.Text) > 0 Then
            Dim CapturaPedido As New PedidoVirtualForm
            Dim renglon As DataRow
            Dim columnas, i, partida As Int32
            columnas = grdArticulos.DisplayLayout.Bands(0).Columns.Count

            If tablaProductos.Columns.Count < columnas Then
                For Each columna As UltraGridColumn In grdArticulos.DisplayLayout.Bands(0).Columns
                    tablaProductos.Columns.Add(columna.Key)
                Next
                partida = 0
            ElseIf tablaProductos.Rows.Count > 0 And EncabezadoPedido.operacion = "Editar" Then
                renglon = tablaProductos.Rows.Item(tablaProductos.Rows.Count - 1)
                'consultar la ultima partida del pedido
                partida = objDA.ObtenerPartida(CInt(EncabezadoPedido.txtPedido.Text))
            ElseIf tablaProductos.Rows.Count > 0 And EncabezadoPedido.operacion = "Alta" Then
                renglon = tablaProductos.Rows.Item(tablaProductos.Rows.Count - 1)
                'consultar la ultima partida del pedido
                partida = CInt(renglon.Item("Partida").ToString)
            Else
                partida = 0
            End If

            If tablaProductos.Columns.Count = columnas Then
                tablaProductos.Columns.Add("Pares", Type.GetType("System.Int32"))
                tablaProductos.Columns.Add("Partida")
            End If


            For Each row As UltraGridRow In grdArticulos.Rows.GetFilteredInNonGroupByRows
                If row.Cells("Seleccion").Value Then
                    partida += 1
                    renglon = tablaProductos.NewRow()
                    renglon.Item(0) = False
                    i = 1
                    While i < columnas
                        renglon.Item(i) = row.Cells(i).Value
                        i += 1
                    End While
                    renglon.Item(i) = 0
                    renglon.Item(i + 1) = partida
                    tablaProductos.Rows.Add(renglon)
                End If
            Next

            chkSeleccionar.Checked = False
            SeleccionarRegistros()
            'CapturaPedido.Enabled = True
            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "Los productos se copiaron correctamente"
            mensajeExito.ShowDialog()
        Else
            Dim confirmar As New AdvertenciaForm
            confirmar.mensaje = "Debe seleccionar al menos un articulo"
            confirmar.ShowDialog()
        End If
    End Sub

    Private Sub SeleccionarRegistros()
        Dim contadorSeleccion As Int32 = 0
        Dim bandera As Boolean

        bandera = chkSeleccionar.Checked

        For Each rowGR As UltraGridRow In grdArticulos.Rows.GetFilteredInNonGroupByRows
            rowGR.Cells("Seleccion").Value = bandera
            contadorSeleccion += 1
        Next

        If bandera = False Then
            contadorSeleccion = 0
        End If

        lblContados.Text = contadorSeleccion.ToString("N0")
    End Sub

    Private Sub seleccionarRegistroTabla(e As CellEventArgs)
        If e.Cell.Column.Key = "Seleccion" And e.Cell.Row.Index <> grdArticulos.Rows.FilterRow.Index Then
            Dim contadorSeleccion As Int32 = 0

            If CBool(e.Cell.Text) = False Then
                If 0 = e.Cell.Row.Index Mod 2 Then
                    e.Cell.Appearance.BackColor = Color.White
                Else
                    e.Cell.Appearance.BackColor = Color.LightSteelBlue
                End If
            End If

            If CBool(e.Cell.Text) = True Then
                lblContados.Text = CInt(lblContados.Text) + 1
            Else
                lblContados.Text = CInt(lblContados.Text) - 1
            End If
        End If
    End Sub

    Private Sub crearformatoGrid()
        grdArticulos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdArticulos.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        With grdArticulos.DisplayLayout.Bands(0)

            .Columns("Marca").CellActivation = Activation.NoEdit
            .Columns("Coleccion").CellActivation = Activation.NoEdit
            .Columns("Temporada").CellActivation = Activation.NoEdit
            .Columns("Estatus").CellActivation = Activation.NoEdit
            .Columns("Seleccion").Width = 40
            .Columns("Seleccion").Header.Caption = ""
            .Columns("Seleccion").Header.Appearance.Key = "Seleccion"
            .Columns("Coleccion").Header.Caption = "Colección"
            .Columns("Estatus").Header.Caption = "Status"
            .Columns("IdMarcaSAY").Hidden = True
            .Columns("IdColeccionSAY").Hidden = True

            If idtipoPedido = 4 Then
                .Columns("Temporada").Width = 250
                .Columns("Coleccion").Width = 200
                .Columns("Estatus").Width = 250
                .Columns("ProductoID").Hidden = True
                .Columns("ModeloSAY").CellActivation = Activation.NoEdit
                .Columns("ModeloSICY").CellActivation = Activation.NoEdit
            ElseIf idtipoPedido = 3 Then
                .Columns("IdPielSAY").Hidden = True
                .Columns("IdColorSAY").Hidden = True
                .Columns("IdTallaSAY").Hidden = True
                .Columns("ProductoID").Hidden = True
                .Columns("ProductoEstiloID").Hidden = True
                .Columns("Temporada").Width = 150
                .Columns("Coleccion").Width = 150
                .Columns("Color").Width = 120
                .Columns("Piel").Width = 150
                .Columns("ModeloSAY").CellActivation = Activation.NoEdit
                .Columns("ModeloSICY").CellActivation = Activation.NoEdit
                .Columns("Piel").CellActivation = Activation.NoEdit
                .Columns("Color").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
            ElseIf idtipoPedido = 5 Then
                .Columns("Marca").Width = 110
                .Columns("Temporada").Width = 250
                .Columns("Coleccion").Width = 200
                .Columns("Estatus").Width = 430
            End If
        End With
        grdArticulos.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grdArticulos.DisplayLayout.GroupByBox.Hidden = False
        grdArticulos.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"
    End Sub

    'Private Sub exportarExcel()
    '    Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
    '    Dim sfd As New SaveFileDialog
    '    Dim result As DialogResult
    '    Dim fileName As String
    '    Dim contador As Integer = 0, i As Int32
    '    Dim contenido As New DataTable
    '    Dim renglon As DataRow

    '    For Each columna As UltraGridColumn In grdArticulos.DisplayLayout.Bands(0).Columns
    '        If columna.Header.Caption.ToString <> "Seleccion" Then
    '            contenido.Columns.Add(columna.Header.Caption.ToString).Caption = ""
    '            contador += 1
    '        End If
    '    Next

    '    contenido.Columns.Add("Pares").Caption = ""
    '    contador += 1

    '    renglon = contenido.NewRow
    '    renglon.Item(0) = "Cliente"
    '    renglon.Item(1) = txtCliente.Text
    '    renglon.Item(5) = "Tipo Pedido"
    '    renglon.Item(6) = txtTipoPedido.Text.Substring(0, txtTipoPedido.Text.IndexOf("("))
    '    contenido.Rows.Add(renglon)

    '    renglon = contenido.NewRow
    '    renglon.Item(0) = "Lista de precios"
    '    renglon.Item(1) = txtListaPrecio.Text.Substring(txtListaPrecio.Text.IndexOf("*") + 4, txtListaPrecio.Text.Length - 53)
    '    renglon.Item(5) = "ID LP"
    '    renglon.Item(6) = ListaPrecios.PListaBaseId.ToString
    '    contenido.Rows.Add(renglon)

    '    renglon = contenido.NewRow
    '    contenido.Rows.Add(renglon)

    '    renglon = contenido.NewRow
    '    contenido.Rows.Add(renglon)

    '    renglon = contenido.NewRow
    '    i = 0
    '    For Each columna As UltraGridColumn In grdArticulos.DisplayLayout.Bands(0).Columns
    '        If columna.Header.Caption.ToString <> "Seleccion" Then
    '            renglon.Item(i) = columna.Header.Caption.ToString
    '            i += 1
    '        End If
    '    Next
    '    renglon.Item(i) = "Pares"
    '    contenido.Rows.Add(renglon)

    '    For Each row As UltraGridRow In grdArticulos.Rows.GetFilteredInNonGroupByRows
    '        renglon = contenido.NewRow
    '        renglon.Item(0) = False
    '        i = 0
    '        While i < (contador - 1)
    '            renglon.Item(i) = row.Cells(i + 1).Value
    '            i += 1
    '        End While
    '        contenido.Rows.Add(renglon)
    '    Next

    '    grdExportar.DataSource = contenido
    '    grdExportar.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

    '    With grdExportar.DisplayLayout.Bands(0)
    '        .Columns("IdMarcaSAY").Hidden = True
    '        .Columns("IdColeccionSAY").Hidden = True
    '        .Columns("ProductoID").Hidden = True
    '        .Columns("ProductoEstiloID").Hidden = True
    '        If idtipoPedido = 3 Then
    '            .Columns("IdPielSAY").Hidden = True
    '            .Columns("IdColorSAY").Hidden = True
    '            .Columns("IdTallaSAY").Hidden = True
    '        End If
    '    End With

    '    i = 0
    '    For Each row As UltraGridRow In grdExportar.Rows.GetFilteredInNonGroupByRows
    '        If i < 5 Then
    '            row.CellAppearance.BackColor = Color.White
    '            i += 1
    '        End If
    '    Next

    '    sfd.DefaultExt = "xlsx"
    '    sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
    '    result = sfd.ShowDialog()
    '    fileName = sfd.FileName
    '    If result = Windows.Forms.DialogResult.OK Then
    '        Try
    '            Me.Cursor = Cursors.WaitCursor
    '            gridExcelExporter.Export(Me.grdExportar, fileName)
    '            Process.Start(fileName)
    '            Me.Cursor = Cursors.Default

    '        Catch ex As Exception
    '            Me.Cursor = Cursors.Default
    '            MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
    '        End Try
    '    End If
    'End Sub

    Private Sub exportarExcel2()
        'Variables locales
        Dim oExcel As Object
        Dim objLibroExcel As Object
        Dim oSheet As Object
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim ret As DialogResult
        Dim fileName As String, fecha_hora As String
        Dim mensajeExito As New ExitoForm

        With fbdUbicacionArchivo
            .Reset()
            .Description = " Seleccione una carpeta "
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True

            ret = .ShowDialog

            If ret = Windows.Forms.DialogResult.OK Then
                fecha_hora = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                fileName = .SelectedPath + "\PV_" + txtCliente.Text.Replace(" ", "_") + "_" + fecha_hora + ".xlsx"

                Try
                    Me.Cursor = Cursors.WaitCursor
                    'Iniciar un nuevo libro en Excel 
                    oExcel = CreateObject("Excel.Application")
                    'Asi creas el Libro de Excel
                    objLibroExcel = oExcel.Workbooks.Add()
                    'Agregar datos a las celdas a la hoja "Resumen" del libro "Resumen 2014" 
                    oSheet = objLibroExcel.Worksheets(1)
                    'Esta celda contendrá el nombre del Cliente
                    'Coloca el nombre de las columnas para despues leerlas
                    oSheet.Range("A1").Value = "C1"
                    oSheet.Range("B1").Value = "C2"
                    oSheet.Range("C1").Value = "C3"
                    oSheet.Range("D1").Value = "C4"

                    If idtipoPedido = 3 Then
                        oSheet.Range("E1").Value = "C5"
                        oSheet.Range("F1").Value = "C6"
                        oSheet.Range("G1").Value = "C7"
                        oSheet.Range("H1").Value = "C8"
                        oSheet.Range("I1").Value = "C9"
                        oSheet.Range("J1").Value = "C10"
                    ElseIf idtipoPedido = 4 Then
                        oSheet.Range("E1").Value = "C5"
                        oSheet.Range("F1").Value = "C6"
                        oSheet.Range("G1").Value = "C7"
                    ElseIf idtipoPedido = 5 Then
                        oSheet.Range("E1").Value = "C5"
                    End If


                    'oSheet.Range("A1:E1").EntireColumn.Hidden = True

                    oSheet.Range("A2").Value = "Cliente"
                    oSheet.Range("A2").Font.Bold = True
                    oSheet.Range("B2").Merge()
                    oSheet.Range("B2").Value = txtCliente.Text

                    oSheet.Range("D2").Value = "Tipo Pedido"
                    oSheet.Range("D2").Font.Bold = True
                    'oSheet.Range("F2:H2").Merge()
                    oSheet.Range("E2").Value = txtTipoPedido.Text.Substring(0, txtTipoPedido.Text.IndexOf("(")).ToString

                    oSheet.Range("A3").Value = "Lista de precios"
                    oSheet.Range("A3").Font.Bold = True
                    'oSheet.Range("B3:D3").Merge()
                    oSheet.Range("B3").Value = txtListaPrecio.Text.Substring(txtListaPrecio.Text.IndexOf("*") + 4, txtListaPrecio.Text.Length - 53)

                    oSheet.Range("D3").Value = "ID LP"
                    oSheet.Range("D3").Font.Bold = True
                    oSheet.Range("E3").Value = ListaPrecios.PListaBaseId.ToString

                    'Encabezados de la tabla
                    oSheet.Range("A5").Value = "MARCA"
                    oSheet.Range("B5").Value = "COLECCION"
                    oSheet.Range("C5").Value = "TEMPORADA"
                    oSheet.Range("D5").Value = "ESTATUS"

                    If idtipoPedido = 3 Then
                        oSheet.Range("E5").Value = "MODELO SAY"
                        oSheet.Range("F5").Value = "MODELO SICY"
                        oSheet.Range("G5").Value = "PIEL"
                        oSheet.Range("H5").Value = "COLOR"
                        oSheet.Range("I5").Value = "CORRIDA"
                        oSheet.Range("J5").Value = "PARES"
                    ElseIf idtipoPedido = 4 Then
                        oSheet.Range("E5").Value = "MODELO SAY"
                        oSheet.Range("F5").Value = "MODELO SICY"
                        oSheet.Range("G5").Value = "PARES"
                    ElseIf idtipoPedido = 5 Then
                        oSheet.Range("E5").Value = "PARES"
                    End If

                    oSheet.Range("A5:J5").Font.Bold = True
                    oSheet.Range("A5:J5").AutoFilter(1, , VisibleDropDown:=True)

                    'Primero verificamos cuantas filas y cuántas columnas tiene DGV
                    Dim renglon As Integer = 6 'empezaremos en el libro de Excel a partir de la celda 5

                    For Each row As UltraGridRow In grdArticulos.Rows.GetFilteredInNonGroupByRows
                        'Estas son las columnas que usaremos y el contador nos ira cargando una a una cada fila
                        oSheet.Range("A" + renglon.ToString).Value = row.Cells(1).Value
                        oSheet.Range("B" + renglon.ToString).Value = row.Cells(2).Value
                        oSheet.Range("C" + renglon.ToString).Value = row.Cells(3).Value
                        oSheet.Range("D" + renglon.ToString).Value = row.Cells(4).Value

                        If idtipoPedido = 3 Then
                            oSheet.Range("E" + renglon.ToString).Value = row.Cells(5).Value
                            oSheet.Range("F" + renglon.ToString).Value = row.Cells(6).Value
                            oSheet.Range("G" + renglon.ToString).Value = row.Cells(7).Value
                            oSheet.Range("H" + renglon.ToString).Value = row.Cells(8).Value
                            oSheet.Range("I" + renglon.ToString).Value = row.Cells(9).Value
                            oSheet.Range("J" + renglon.ToString).Value = ""
                        ElseIf idtipoPedido = 4 Then
                            oSheet.Range("E" + renglon.ToString).Value = row.Cells(5).Value
                            oSheet.Range("F" + renglon.ToString).Value = row.Cells(6).Value
                            oSheet.Range("G" + renglon.ToString).Value = ""
                        ElseIf idtipoPedido = 5 Then
                            oSheet.Range("E" + renglon.ToString).Value = ""
                        End If
                        renglon = renglon + 1
                    Next
                    'Ajustar el ancho de las columnas
                    oSheet.Range("A3:J" + renglon.ToString).columns.AutoFit()
                    oSheet.Range("E2:F" + renglon.ToString).NumberFormat = "@"
                    'Bloquear el encabezado
                    oExcel.Range("A1:J3").Select()
                    oExcel.Selection.Locked = True

                    'Desbloquear la columna de pares
                    If idtipoPedido = 3 Then
                        oSheet.Range("A5:XFD" + renglon.ToString).Select()
                    ElseIf idtipoPedido = 4 Then
                        oSheet.Range("A5:XFD" + renglon.ToString).Select()
                    ElseIf idtipoPedido = 5 Then
                        oSheet.Range("A5:XFD" + renglon.ToString).Select()
                    End If
                    oExcel.Selection.Locked = False
                    'Bloquear la hoja de excel
                    oSheet.Activate()
                    oSheet.Protect("clave", True, True, True, False, False, False, False, False, False, False, False, True, False, True, False)
                    'oSheet.Protect("clave", True, True, True, False, False, False, False, False, False, Hipervinculos, eliminarCol, eliminarFilas, ordenar, autofiltro, False)

                    'Asi Guardas el Libro de Excel
                    objLibroExcel.Application.ActiveWorkbook.SaveAs(fileName)
                    oExcel.Workbooks.Close()
                    objLibroExcel = Nothing
                    Me.Cursor = Cursors.Default

                    mensajeExito.mensaje = "Los datos se exportaron correctamente"
                    mensajeExito.ShowDialog()
                    .Dispose()
                    'Process.Start(fileName)
                Catch ex As Exception
                    Me.Cursor = Cursors.Default
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Atención")
                End Try
            End If
        End With
    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        copiarRenglon()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        generarFiltros()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarCampos()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        EncabezadoPedido.Enabled = True
        EncabezadoPedido.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cmbMarcas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarcas.SelectedIndexChanged
        CargarListaColecciones()
    End Sub

    Private Sub grdArticulos_CellChange(sender As Object, e As CellEventArgs) Handles grdArticulos.CellChange
        seleccionarRegistroTabla(e)
    End Sub

    Private Sub chkSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged
        SeleccionarRegistros()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlDatos.Height = 30
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlDatos.Height = 165
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If grdArticulos.Rows.Count > 0 Then
            exportarExcel2()
        Else
            MsgBox("No hay registros que exportar", MsgBoxStyle.Information, "")
        End If
    End Sub
End Class