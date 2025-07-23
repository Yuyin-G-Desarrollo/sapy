Imports System.Globalization
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class DevolucionCliente_CapturaGeneral_DetallesArticulo_Articulos_Form
    Public idCliente As Int16
    Public pedidosSeleccionados As String
    Public documentosSeleccionados As String
    Public articulosSeleccionados As DataTable
    Public listaColumnasAutoajustadas As New List(Of String)
    Public listaSeleccionados As DataTable
    Public numGrid As Int16
    Public idMotivoDevolucion As Integer
    Public idUnidadMedida As Int16

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Public Sub GenerarLista()
        listaColumnasAutoajustadas.Add("Tipo")
        listaColumnasAutoajustadas.Add("RazónSocial")
        listaColumnasAutoajustadas.Add("RFC")
        listaColumnasAutoajustadas.Add("Marca")
        listaColumnasAutoajustadas.Add("Piel")
        listaColumnasAutoajustadas.Add("Color")
        listaColumnasAutoajustadas.Add("Coleccion")
        listaColumnasAutoajustadas.Add("Temporada")
        listaColumnasAutoajustadas.Add("StatusArtículo")
    End Sub
    Private Sub DevolucionCliente_CapturaGeneral_DetallesArticulo_Articulos_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GenerarLista()
        Dim objBU As New Negocios.DevolucionClientesBU
        grdDocumentos.DataSource = objBU.ListaDocumentosFacturas(documentosSeleccionados)
        grdListaPedidos.DataSource = objBU.ListaPedidosFacturados(pedidosSeleccionados)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Public Sub SumarColumnas(grid As UltraGrid, columna As String, tipoSuma As Int16)
        If grid.Rows.Count > 0 And grid.DisplayLayout.Bands(0).Columns.Exists(columna) Then
            With grid.DisplayLayout.Bands(0)
                .Columns(columna).AllowRowSummaries = AllowRowSummaries.True
                Dim configuracionDeSuma As SummarySettings = .Summaries.Add(tipoSuma, grid.DisplayLayout.Bands(0).Columns(columna))

                If .Columns(columna).DataType.Name.ToString.Equals("Int32") Or .Columns(columna).DataType.Name.ToString.Equals("Int16") Then
                    configuracionDeSuma.DisplayFormat = "{0:###,###,##0.##}"
                ElseIf .Columns(columna).DataType.Name.ToString.Equals("Decimal") Then
                    configuracionDeSuma.DisplayFormat = "{0:###,###,##0.#0}"
                End If
                'configuracionDeSuma.DisplayFormat = "{0}"
                configuracionDeSuma.Appearance.TextHAlign = HAlign.Right
                .SummaryFooterCaption = "Total:"
                'MsgBox(grdArticulos.Rows.SummaryValues(configuracionDeSuma).Value)
            End With
        End If
    End Sub

    Public Sub OcultarColumnas(grid As UltraGrid, columna As String)
        If grid.DisplayLayout.Bands(0).Columns.Exists(columna) Then
            grid.DisplayLayout.Bands(0).Columns(columna).Hidden = True
        End If
    End Sub

    Public Sub FormatoGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid, numGrid As Int16)
        With grid.DisplayLayout
            If numGrid = 1 Then
                .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            Else
                .AutoFitStyle = AutoFitStyle.None
            End If

            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
            .Override.AllowUpdate = DefaultableBoolean.False
            .Scrollbars = Scrollbars.Both
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            .Override.SelectTypeRow = SelectType.Single

            SumarColumnas(grdArticulos, "ParesPedido", 1)
            SumarColumnas(grdArticulos, "ParesFacturados", 1)

            For Each columna As UltraGridColumn In .Bands(0).Columns
                For Each elemento As String In listaColumnasAutoajustadas
                    If columna.Key = elemento Then
                        columna.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
                    End If
                Next
            Next

            For Each row As UltraGridRow In grdArticulos.Rows
                If grid.DisplayLayout.Bands(0).Columns.Exists("ActivoModelo") Then
                    If row.Cells("ActivoModelo").Value = "NO" Then
                        row.Appearance.ForeColor = Color.Red
                    End If
                End If

                If grid.DisplayLayout.Bands(0).Columns.Exists("ActivoArtículo") Then
                    If row.Cells("ActivoArtículo").Value = "NO" Then
                        row.Appearance.ForeColor = Color.Red
                    End If
                End If
                If grid.DisplayLayout.Bands(0).Columns.Exists("StatusArtículo") Then
                    If row.Cells("StatusArtículo").Value = "DESCONTINUADO PARA VENTA" Then
                        row.Appearance.ForeColor = Color.Red
                    End If
                End If
            Next

            If grid.Rows.Count > 0 Then
                .Bands(0).Columns(0).Width = 30
            End If

            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.FilterUIType = FilterUIType.FilterRow
        End With

    End Sub

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
                If col.Header.Caption.Equals("TELÉFONO") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("EXTENSIÓN") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If
            End If
        Next
    End Sub

    Public Sub seleccionarFila(grid As Infragistics.Win.UltraWinGrid.UltraGrid,
                               etiqueta As Label,
                               boton As Button)
        If Not grid.ActiveRow.IsDataRow Then Return
        If IsNothing(grid.ActiveRow) Then Return
        If grid.ActiveRow.Cells(" ").Value Then
            grid.ActiveRow.Cells(" ").Value = False
        Else
            grid.ActiveRow.Cells(" ").Value = True
        End If

        Dim marcados As Integer
        For Each row As UltraGridRow In grid.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        etiqueta.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
        If marcados > 0 Then
            boton.Enabled = True
        Else
            boton.Enabled = False
        End If

    End Sub

    Public Sub GenerarFiltros(grid As UltraGrid,
                              index As Int16,
                              numConsulta As Int16)
        Dim filtro As String = ""
        If grid IsNot Nothing And grid.Rows.Count > 0 Then
            For Each elemento As UltraGridRow In grid.Rows
                If elemento.Cells(0).Value Then
                    filtro += elemento.Cells(index).Value.ToString + ","
                End If
            Next
            filtro = filtro.Substring(0, filtro.Length - 1)
            Dim devolucionesBU As New Negocios.DevolucionClientesBU
            grdArticulos.DataSource = Nothing
            grdArticulos.DataSource = devolucionesBU.ListaArticulos(filtro, numConsulta, "", "")

            If grdArticulos.Rows.Count > 0 Then
                chkSeleccionarTodos.Enabled = True
            Else
                chkSeleccionarTodos.Enabled = False
            End If
        End If
    End Sub

    Public Sub MostrarTodos()
        Dim devolucionesBU As New Negocios.DevolucionClientesBU
        grdArticulos.DataSource = devolucionesBU.ListaArticulos("", 3, txtMarca.Text, txtColeccion.Text)
        FormatoGrid(grdArticulos, numGrid)
    End Sub

    Private Sub btnMostrarPorPedidos_Click(sender As Object, e As EventArgs) Handles btnMostrarPorPedidos.Click
        Cursor = Cursors.WaitCursor
        numGrid = 1
        GenerarFiltros(grdListaPedidos, 1, 1)
        Cursor = Cursors.Default
    End Sub

    Private Sub btnMostrarPorDocumentos_Click(sender As Object, e As EventArgs) Handles btnMostrarPorDocumentos.Click
        Cursor = Cursors.WaitCursor
        numGrid = 2
        GenerarFiltros(grdDocumentos, 2, 2)
        Cursor = Cursors.Default
    End Sub

    Private Sub btnMostrarTodo_Click(sender As Object, e As EventArgs) Handles btnMostrarTodo.Click
        Cursor = Cursors.WaitCursor
        numGrid = 1
        MostrarTodos()
        Cursor = Cursors.Default
    End Sub

    Private Sub grdArticulos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdArticulos.InitializeLayout
        FormatoGrid(grdArticulos, numGrid)
        asignaFormato_Columna(grdArticulos)
        If grdArticulos.Rows.Count > 0 Then
            chkSeleccionarTodos.Enabled = True
        Else
            chkSeleccionarTodos.Enabled = False
        End If
        OcultarColumnas(grdArticulos, "StatusArtículo")
        OcultarColumnas(grdArticulos, "ActivoModelo")
        OcultarColumnas(grdArticulos, "ActivoArtículo")
        OcultarColumnas(grdArticulos, "ProductoEstiloID")
        With grdArticulos.DisplayLayout
            .Bands(0).ColHeaderLines = 2
            .Bands(0).Columns("FolioFactura").Header.Caption = "Factura"
            .Bands(0).Columns("ParesFacturados").Header.Caption = "Pares" + vbCrLf + "Facturados"
            .Bands(0).Columns("ParesFacturados").Format = String.Format("N0")
            .Bands(0).Columns("fechafactura").Header.Caption = "FDocto"
            .PerformAutoResizeColumns(True, AutoResizeColumnWidthOptions.IncludeCells)
        End With

    End Sub

    Private Sub grdDocumentos_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdDocumentos.ClickCell
        If grdDocumentos.Rows.Count > 0 Then
            seleccionarFila(grdDocumentos, lblDocumentosSeleccionados, btnMostrarPorDocumentos)
        End If
    End Sub

    Private Sub grdListaPedidos_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListaPedidos.ClickCell
        If grdListaPedidos.Rows.Count > 0 Then
            seleccionarFila(grdListaPedidos, lblPedidosSeleccionados, btnMostrarPorPedidos)
            btnMostrarPorPedidos.Enabled = False
        End If
    End Sub

    Private Sub grdArticulos_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdArticulos.ClickCell
        If grdArticulos.Rows.Count > 0 Then
            seleccionarFila(grdArticulos, lblNumFiltrados, btnAceptar)
        End If
    End Sub

    Private Sub chkSeleccionarTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodos.CheckedChanged
        If chkSeleccionarTodos.Checked Then
            For Each row In grdArticulos.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = True
            Next
        Else
            For Each row As UltraGridRow In grdArticulos.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = False
            Next
        End If
        Dim marcados As Integer
        For Each row As UltraGridRow In grdArticulos.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
        If marcados > 0 Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    Private Sub grdListaPedidos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaPedidos.InitializeLayout
        FormatoGrid(grdListaPedidos, 1)
        grdListaPedidos.DisplayLayout.Scrollbars = Scrollbars.None
        grdListaPedidos.DisplayLayout.Scrollbars = Scrollbars.Vertical
        asignaFormato_Columna(grdListaPedidos)
        If grdListaPedidos.DisplayLayout.Bands(0).Columns.Exists("FechaÚltimoDocto") Then
            grdListaPedidos.DisplayLayout.Bands(0).Columns("FechaÚltimoDocto").Header.Caption = "FÚltimoDocto"
        End If
        If grdListaPedidos.Rows.Count > 0 Then
            grdListaPedidos.DisplayLayout.Bands(0).Columns(0).Hidden = True
        End If

    End Sub

    Private Sub grdDocumentos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdDocumentos.InitializeLayout
        If (grdDocumentos.Rows.Count > 0) Then
            FormatoGrid(grdDocumentos, 2)
            asignaFormato_Columna(grdDocumentos)
            SumarColumnas(grdDocumentos, "Pares", 1)
            If grdDocumentos.DisplayLayout.Bands(0).Columns.Exists("FolioFactura") Then
                grdDocumentos.DisplayLayout.Bands(0).Columns("FolioFactura").Header.Caption = "Factura"
            End If
            If grdDocumentos.DisplayLayout.Bands(0).Columns.Exists("FechaDocumento") Then
                grdDocumentos.DisplayLayout.Bands(0).Columns("FechaDocumento").Header.Caption = "FDocto"
            End If
            If grdDocumentos.DisplayLayout.Bands(0).Columns.Exists("DoctoSeleccionado") Then
                grdDocumentos.DisplayLayout.Bands(0).Columns("DoctoSeleccionado").Hidden = True
            End If

            If grdDocumentos.DisplayLayout.Bands(0).Columns.Exists("fcdd_productoestiloid") Then
                grdDocumentos.DisplayLayout.Bands(0).Columns("fcdd_productoestiloid").Hidden = True
            End If

            If grdDocumentos.DisplayLayout.Bands(0).Columns.Exists("Total") Then
                grdDocumentos.DisplayLayout.Bands(0).Columns("Total").Format = String.Format("n2")
            End If

            If grdDocumentos.DisplayLayout.Bands(0).Columns.Exists("Pares") Then
                grdDocumentos.DisplayLayout.Bands(0).Columns("Pares").Format = String.Format("N0")
            End If
            chkBoxTodosDocumentos.Enabled = True
            grdDocumentos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If

        'For Each row As UltraGridRow In grdDocumentos.Rows
        'row.Cells(" ").Value = 0
        'Next
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim obj As New Negocios.DevolucionClientesBU
            Dim listAtributosFactura As New List(Of String)
            Dim xmlArticulos As XElement = New XElement("Articulos")
            For Each row As UltraGridRow In grdArticulos.Rows
                If row.Cells(" ").Value = True Then
                    listAtributosFactura = row.Cells("FolioFactura").Value.ToString.Split("-").ToList
                    Dim vNodo As XElement = New XElement("Articulo")
                    vNodo.Add(New XAttribute("devolucionclienteid", CInt(lblFolioDev.Text)))
                    vNodo.Add(New XAttribute("productoestiloid", row.Cells("ProductoEstiloID").Value))
                    vNodo.Add(New XAttribute("motivodevolucion_statusid", idMotivoDevolucion))
                    vNodo.Add(New XAttribute("cantidad", row.Cells("ParesFacturados").Value))
                    vNodo.Add(New XAttribute("unidadid", idUnidadMedida))
                    vNodo.Add(New XAttribute("listaprecio", row.Cells("FolioFactura").Value))
                    vNodo.Add(New XAttribute("preciolista", row.Cells("PrecioDev").Value))
                    vNodo.Add(New XAttribute("preciodevolucion", row.Cells("PrecioDev").Value))
                    vNodo.Add(New XAttribute("pedidoid", row.Cells("PedidoSAY").Value))
                    vNodo.Add(New XAttribute("pedidosicyid", row.Cells("PedidoSICY").Value))
                    vNodo.Add(New XAttribute("partidaid", row.Cells("Partida").Value))
                    vNodo.Add(New XAttribute("pedido_capturageneral", 1))
                    vNodo.Add(New XAttribute("documentoid", row.Cells("DoctoSAY").Value))
                    vNodo.Add(New XAttribute("remisionid", row.Cells("Documento").Value))
                    vNodo.Add(New XAttribute("añodocumento", row.Cells("Año").Value))
                    If listAtributosFactura.Count >= 2 Then
                        vNodo.Add(New XAttribute("seriefactura", listAtributosFactura(0)))
                        vNodo.Add(New XAttribute("foliofactura", listAtributosFactura(1)))
                    End If
                    vNodo.Add(New XAttribute("documento_capturageneral", 1))
                    vNodo.Add(New XAttribute("lecturacodigos", 0))
                    vNodo.Add(New XAttribute("usuariocreoid", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                    xmlArticulos.Add(vNodo)
                    row.Cells(" ").Value = False
                End If
            Next
            obj.GuardarDetalles(xmlArticulos.ToString())
            chkSeleccionarTodos.Checked = False
            lblNumFiltrados.Text = "0"
            Dim ventana As New Tools.ExitoForm
            ventana.mensaje = "Artículos Agregados"
            ventana.ShowDialog()

        Catch ex As Exception
            Dim ventanaError As New Tools.ErroresForm
            ventanaError.mensaje = "Ocurrió un error al guardar " + vbCrLf + ex.Message
            ventanaError.ShowDialog()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub txtMarca_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMarca.KeyDown
        If e.KeyCode = Keys.Enter Then
            numGrid = 1
            MostrarTodos()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtColeccion.Text = ""
        txtMarca.Text = ""
        grdArticulos.DataSource = Nothing
        chkSeleccionarTodos.Checked = False
        lblNumFiltrados.Text = "0"
        btnAceptar.Enabled = False
    End Sub

    Private Sub txtColeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtColeccion.KeyDown
        If e.KeyCode = Keys.Enter Then
            numGrid = 1
            MostrarTodos()
        End If
    End Sub

    Private Sub chkBoxTodosPedidos_CheckedChanged(sender As Object, e As EventArgs) Handles chkBoxTodosPedidos.CheckedChanged
        If chkBoxTodosPedidos.Checked Then
            For Each row In grdListaPedidos.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = True
            Next
        Else
            For Each row As UltraGridRow In grdListaPedidos.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = False
            Next
        End If
    End Sub

    Private Sub chkBoxTodosDocumentos_CheckedChanged(sender As Object, e As EventArgs) Handles chkBoxTodosDocumentos.CheckedChanged
        If chkBoxTodosDocumentos.Checked Then
            Dim cantidad As Int64 = 0
            For Each row In grdDocumentos.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = True
                cantidad += 1
            Next
            btnMostrarPorDocumentos.Enabled = True
            lblDocumentosSeleccionados.Text = cantidad
        Else
            For Each row As UltraGridRow In grdDocumentos.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = False
            Next
            btnMostrarPorDocumentos.Enabled = False
            lblDocumentosSeleccionados.Text = 0
        End If
    End Sub
End Class