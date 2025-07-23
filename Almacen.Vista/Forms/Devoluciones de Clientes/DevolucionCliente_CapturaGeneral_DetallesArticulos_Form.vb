Imports System.Globalization
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid

Public Class DevolucionCliente_CapturaGeneral_DetallesArticulos

    Public idCliente As Int16
    Public pedidosSeleccionados As String
    Public documentosSeleccionados As String
    Public idMotivoDevolucion As Int16
    Public motivoDevolucion As String
    Public tipoMotivo As Int16 ' 1 => Ventas, 2=> Almacén
    Public tipoDevolucion As String 'Mayoreo / Menudeo
    Public cantidad As Integer = 0
    Public cajas As Integer = 0
    Public total As Double = 0
    Public unidadMedida As String
    Public idUnidadMedida As Int16
    Public dtPedidosSeleccionados As DataTable
    Public dtDocumentosSeleccionados As DataTable
    Public edicion_almacen As Boolean = False
    Public edicion_ventas As Boolean = False
    Public edicion_precio As Boolean = False
    Public objDevolucion As New Entidades.DevolucionCliente
    Public renglonSeleccionado As Integer = 0
    Public objPermisos As New Entidades.DevolucionCliente_PermisosPantallas
    Public variosFolios As Boolean = False
    Public FoliosDev As String = ""
    Public paresaplicados As Integer = 0
    Public paresxplicar As Integer = 0

    Public negocios As New Negocios.DevolucionClientesBU
    Public dtDetallesOriginal As New DataTable

    Private columnaEditada As Integer = 1
    Private renglonEditado As Integer = 0
    Private registroErroneoFila As New List(Of Integer)
    Private validadoParaCerrarForm As Boolean = False

    Public Sub buscarArticulo()
        Dim lista As New DataTable
        lista = negocios.ListaArtiulos_ModeloSAY(IIf(rdbModeloSAY.Checked = True, "SAY", "SICY"), (txtModeloSAY.Text), idCliente, tipoDevolucion)
        If lista.Rows.Count > 0 Then
            Dim newRow As DataRow = lista.NewRow
            'lista.Rows.InsertAt(newRow, 0)
            cmbArticulos.DataSource = lista
            cmbArticulos.DisplayMember = "Articulo"
            cmbArticulos.ValueMember = "ProductoEstiloId"
            lblModeloEncontrado.Visible = False
            cmbArticulos.DroppedDown = True
        Else
            cmbArticulos.DataSource = Nothing
            lblModeloEncontrado.Visible = True

        End If
        txtModeloSAY.Text = ""
        txtModeloSAY.Select()
    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then
                col.Style = ColumnStyle.DoublePositive
                col.Format = String.Format("N2")
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

    Public Function sumarColumnas(grid As UltraGrid, columna As String)
        Dim suma As Double = 0
        With grid.DisplayLayout
            If .Bands(0).Columns.Exists(columna) Then
                With .Bands(0)
                    '.Columns(columna).AllowRowSummaries = AllowRowSummaries.True
                    Dim configuracionDeSuma As SummarySettings = .Summaries.Add(SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns(columna))
                    If .Columns(columna).DataType.Name.ToString.Equals("Int32") Or .Columns(columna).DataType.Name.ToString.Equals("Int16") Then
                        configuracionDeSuma.DisplayFormat = "{0:###,###,##0.##}"
                    ElseIf .Columns(columna).DataType.Name.ToString.Equals("Decimal") Then
                        configuracionDeSuma.DisplayFormat = "{0:###,###,##0.#0}"
                    End If

                    configuracionDeSuma.Appearance.TextHAlign = HAlign.Right
                    .SummaryFooterCaption = "Total:"
                    suma = grid.Rows.SummaryValues(configuracionDeSuma).Value
                End With
            End If
        End With
        Return suma
    End Function

    Public Sub FormatoGrid()
        asignaFormato_Columna(grdArticulosSeleccionados)
        With grdArticulosSeleccionados.DisplayLayout
            .PerformAutoResizeColumns(True, AutoResizeColumnWidthOptions.IncludeCells)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.CellSelect
            .Override.AllowAddNew = AllowAddNew.No
            .Override.AllowUpdate = DefaultableBoolean.True
            .Scrollbars = Scrollbars.Both
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            .Override.SelectTypeRow = SelectType.Single
            .Bands(0).ColHeaderLines = 2

            For Each row As UltraGridRow In grdArticulosSeleccionados.Rows
                If grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns.Exists("ActivoModelo") Then
                    If row.Cells("ActivoModelo").Value = "NO" Then
                        row.Appearance.ForeColor = Color.Red
                    End If
                End If

                If grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns.Exists("ActivoArtículo") Then
                    If row.Cells("ActivoArtículo").Value = "NO" Then
                        row.Appearance.ForeColor = Color.Red
                    End If
                End If
            Next

            OcultarColumna("StatusArtículo", grdArticulosSeleccionados)
            grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("StatusArtículo").Hidden = True
            grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("ListaPrecio").Hidden = True
            grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("ActivoModelo").Hidden = True
            grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("ActivoArtículo").Hidden = True
            grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("ProductoEstiloID").Hidden = True
            grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("IdDetalle").Hidden = True
            grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("Precio_CapturadoCobranza").Hidden = True

            'grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("PrecioDev").Hidden = True
            'grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("Total").Hidden = True
            'grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("LecturaCodigos").Hidden = True
            grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("Docto").Hidden = True
            'grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("Importe").Hidden = True
            grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("IdMotivoDev").Hidden = True
            grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("Clasificación").Hidden = True

            grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("ModeloSAY").Header.Caption = "Modelo" + vbCrLf + "SAY"
            grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("ModeloSICY").Header.Caption = "Modelo" + vbCrLf + "SICY"
            grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("PrecioCobranza").Header.Caption = "Precio" + vbCrLf + "Cobranza"
            grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("LecturaCodigos").Header.Caption = "Lectura" + vbCrLf + "Códigos"
            grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("LecturaCodigos").Header.Caption = "Lectura" + vbCrLf + "Códigos"
            grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("PedidoSAY").Header.Caption = "Pedido" + vbCrLf + "SAY"

            .Bands(0).Columns("Cantidad").Header.Caption = "* Cantidad"
            .Bands(0).Columns("Cantidad").Format = String.Format("N0")
            .Bands(0).Columns(0).Width = 30
            .Bands(0).Columns("* Clasificación").CellAppearance.TextHAlign = HAlign.Left
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.FilterUIType = FilterUIType.FilterRow

            If pnlBtnAgregarArticulo.Visible = True Then
                If .Bands(0).Columns.Exists("* Clasificación") Then
                    .Bands(0).Columns("* Clasificación").CellActivation = Activation.AllowEdit
                End If

                If .Bands(0).Columns.Exists("Lote") Then
                    .Bands(0).Columns("Lote").CellActivation = Activation.AllowEdit
                End If
            Else
                If .Bands(0).Columns.Exists("* Clasificación") Then
                    .Bands(0).Columns("* Clasificación").CellActivation = Activation.NoEdit
                End If

                If .Bands(0).Columns.Exists("Lote") Then
                    .Bands(0).Columns("Lote").CellActivation = Activation.NoEdit
                End If

                If .Bands(0).Columns.Exists("Nave") Then
                    .Bands(0).Columns("Nave").CellActivation = Activation.NoEdit
                End If

                If .Bands(0).Columns.Exists("Procede") Then
                    .Bands(0).Columns("Procede").CellActivation = Activation.NoEdit
                End If
            End If

            If objPermisos.VerMontos = False Then
                .Bands(0).Columns("Precio").Hidden = True
                .Bands(0).Columns("PrecioCobranza").Hidden = True
                .Bands(0).Columns("Total").Hidden = True
            End If

            If objPermisos.Area = "COBRANZA" Then
                .Bands(0).Columns("Precio").Hidden = True
            End If

            If objPermisos.Area = "VENTAS" Then
                .Bands(0).Columns("PrecioCobranza").Hidden = True
            End If
        End With
    End Sub

    Public Sub OcultarColumna(columna As String, grid As UltraGrid)
        If grid.DisplayLayout.Bands(0).Columns.Exists(columna) Then
            grid.DisplayLayout.Bands(0).Columns(columna).Hidden = True
        End If
    End Sub

    Public Sub ColocarArticuloEnGrid(productoEstiloID As Integer)
        Dim datos As New DataTable

        datos = negocios.ConsultaArticuloSeleccionado(productoEstiloID, objDevolucion.Clienteid)

        Try
            Cursor = Cursors.WaitCursor
            Dim xmlArticulos As XElement = New XElement("Articulos")
            For Each row As DataRow In datos.Rows
                Dim vNodo As XElement = New XElement("Articulo")
                vNodo.Add(New XAttribute("devolucionclienteid", CInt(lblFolioDevolucion.Text)))
                vNodo.Add(New XAttribute("productoestiloid", row("ProductoEstiloID").ToString))
                vNodo.Add(New XAttribute("motivodevolucion_statusid", idMotivoDevolucion))
                vNodo.Add(New XAttribute("cantidad", 0))
                vNodo.Add(New XAttribute("unidadid", idUnidadMedida))
                vNodo.Add(New XAttribute("nave", row("NaveId").ToString))
                vNodo.Add(New XAttribute("listaprecio", row("ListaPrecio").ToString))
                vNodo.Add(New XAttribute("preciolista", row("Precio").ToString))
                vNodo.Add(New XAttribute("precionetodevolucion", row("PrecioNeto").ToString))
                vNodo.Add(New XAttribute("preciodevolucion", row("Precio").ToString))
                vNodo.Add(New XAttribute("pedidoid", row("PedidoSAY").ToString))
                vNodo.Add(New XAttribute("pedidosicyid", ""))
                vNodo.Add(New XAttribute("partidaid", ""))
                vNodo.Add(New XAttribute("pedido_capturageneral", 0))
                vNodo.Add(New XAttribute("documentoid", ""))
                vNodo.Add(New XAttribute("remisionid", ""))
                vNodo.Add(New XAttribute("añodocumento", ""))
                vNodo.Add(New XAttribute("seriefactura", ""))
                vNodo.Add(New XAttribute("foliofactura", ""))
                vNodo.Add(New XAttribute("documento_capturageneral", 0))
                vNodo.Add(New XAttribute("lecturacodigos", 0))
                vNodo.Add(New XAttribute("usuariocreoid", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                xmlArticulos.Add(vNodo)

            Next
            negocios.GuardarDetalles(xmlArticulos.ToString())
            Dim ventana As New Tools.ExitoForm
            ventana.mensaje = "Artículos Agregados"
            'ventana.ShowDialog()

        Catch ex As Exception
            Dim ventanaError As New Tools.ErroresForm
            ventanaError.mensaje = "Ocurrió un error al guardar " + vbCrLf + ex.Message
            ventanaError.ShowDialog()
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        'Me.Dispose()
        ValidarCerrarForm()
    End Sub

    Public Sub poblarGrid()
        Cursor = Cursors.WaitCursor

        If variosFolios = False Then
            dtDetallesOriginal = negocios.ConsultaDetalles_Devolucion(CInt(lblFolioDevolucion.Text), "")
        Else
            dtDetallesOriginal = negocios.ConsultaDetalles_Devolucion(0, FoliosDev)
        End If
        grdArticulosSeleccionados.DataSource = dtDetallesOriginal
        ActualizarCantidades()

        FocusEnCeldaGrid()

        Cursor = Cursors.Default
    End Sub

    Private Sub FocusEnCeldaGrid()
        If grdArticulosSeleccionados.Rows.Count > 0 Then
            grdArticulosSeleccionados.ActiveCell = grdArticulosSeleccionados.Rows(renglonEditado).Cells(columnaEditada)
            'grdArticulosSeleccionados.Rows(renglonEditado).Cells(columnaEditada).Selected = True
            grdArticulosSeleccionados.ActiveCell.Activate()
            grdArticulosSeleccionados.ActiveCell.Selected = True
            grdArticulosSeleccionados.Focus()
        End If

        renglonEditado = 0
        columnaEditada = 1
    End Sub

    Private Sub btnCodigosCliente_Click(sender As Object, e As EventArgs) Handles btnCodigosCliente.Click
        Dim FormLeerCodigos As New DevolucionCliente_CapturaGeneral_LecturaCodigoEtiquetas_Form

        renglonEditado = 0
        columnaEditada = 1
        'FormLeerCodigos.lblCliente.Text = lblCliente.Text
        'FormLeerCodigos.idCliente = idCliente
        'FormLeerCodigos.pedidosSeleccionados = pedidosSeleccionados
        'FormLeerCodigos.documentosSeleccionados = documentosSeleccionados
        'FormLeerCodigos.dtDocumentosSeleccionados = dtDocumentosSeleccionados
        'FormLeerCodigos.dtPedidosSeleccionados = dtPedidosSeleccionados
        'FormLeerCodigos.motivoDevolucion = motivoDevolucion
        'FormLeerCodigos.lblMotivo.Text = motivoDevolucion
        'FormLeerCodigos.idMotivoDevolucion = idMotivoDevolucion
        'FormLeerCodigos.tipoMotivo = tipoMotivo
        'FormLeerCodigos.tipoDevolucion = tipoDevolucion
        'FormLeerCodigos.lblFolioDev.Text = lblFolioDevolucion.Text
        'FormLeerCodigos.lblUnidad.Text = unidadMedida
        'FormLeerCodigos.lblCantidad.Text = cantidad
        If tipoMotivo = 1 Then
            FormLeerCodigos.lblMotivo.Text = "Motivo Ventas:"
        Else
            FormLeerCodigos.lblMotivo.Text = "Motivo Almacén:"
        End If
        FormLeerCodigos.objDevolucion = objDevolucion
        FormLeerCodigos.StartPosition = FormStartPosition.CenterScreen
        FormLeerCodigos.ShowDialog(Me)
        poblarGrid()
    End Sub

    Private Sub txtModeloSAY_KeyDown(sender As Object, e As KeyEventArgs) Handles txtModeloSAY.KeyDown
        If e.KeyCode = Keys.Enter And txtModeloSAY.Text.ToString.Length > 0 Then
            Cursor = Cursors.WaitCursor
            buscarArticulo()
            Cursor = Cursors.Default
        End If
    End Sub

    Public Sub ActualizarCantidades()
        Dim dtCantidades As New DataTable
        dtCantidades = negocios.ConsultaMonto_Cantidad(objDevolucion.Devolucionclienteid)
        ' Se hace la conversión 'CDbl' para dar formato y separación de miles
        If dtCantidades.Rows.Count > 0 Then
            lblParesCapturados.Text = CDbl(dtCantidades.Rows(0).Item(0)).ToString("N0")
            lblMonto.Text = CDbl(dtCantidades.Rows(0).Item(1)).ToString("N2")
        End If

    End Sub

    Private Sub btnAgregarArticulo_Click(sender As Object, e As EventArgs) Handles btnAgregarArticulo.Click
        If objDevolucion.IdentificadorDocumentos IsNot Nothing Then
            If objDevolucion.IdentificadorDocumentos.ToString.Trim.Length = 0 Then
                Dim ventanaAdvertencia As New Tools.AdvertenciaForm
                ventanaAdvertencia.mensaje = "Ventas no ha indicado documentos relacionados con la devolución " + objDevolucion.Devolucionclienteid.ToString + ", puede agregar detalles a la devolución con la lectura de códigos o desde el catálogo de artículos"
                ventanaAdvertencia.ShowDialog()
                Return
            End If
        Else
            Dim ventanaAdvertencia As New Tools.AdvertenciaForm
            ventanaAdvertencia.mensaje = "Ventas no ha indicado documentos relacionados con la devolución " + objDevolucion.Devolucionclienteid.ToString + ", puede agregar detalles a la devolución con la lectura de códigos o desde el catálogo de artículos"
            ventanaAdvertencia.ShowDialog()
            Return
        End If

        Dim FormAgregarArticulos As New DevolucionCliente_CapturaGeneral_DetallesArticulo_Articulos_Form
        FormAgregarArticulos.lblCliente.Text = objDevolucion.NombreCliente
        FormAgregarArticulos.idCliente = objDevolucion.Clienteid
        FormAgregarArticulos.pedidosSeleccionados = objDevolucion.PedidosSAY
        FormAgregarArticulos.documentosSeleccionados = objDevolucion.IdentificadorDocumentos
        FormAgregarArticulos.lblFolioDev.Text = objDevolucion.Devolucionclienteid
        FormAgregarArticulos.idUnidadMedida = objDevolucion.Unidadid
        FormAgregarArticulos.idMotivoDevolucion = idMotivoDevolucion
        FormAgregarArticulos.StartPosition = FormStartPosition.CenterScreen
        FormAgregarArticulos.ShowDialog(Me)
        poblarGrid()
    End Sub

    Private Sub txtModeloSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtModeloSAY.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnAgregarArticulos_Click(sender As Object, e As EventArgs) Handles btnAgregarArticulos.Click
        If cmbArticulos.SelectedValue Then
            pgrsPnlCargando.ContentAlignment = ContentAlignment.MiddleCenter
            pgrsPnlCargando.Top = (Me.Height - pgrsPnlCargando.Height) / 2
            pgrsPnlCargando.Left = (Me.Width - pgrsPnlCargando.Width) / 2
            pgrsPnlCargando.Show()
            pgrsPnlCargando.Refresh()
            'For Each row As UltraGridRow In grdArticulosSeleccionados.Rows
            '    If cmbArticulos.SelectedValue = row.Cells("ProductoEstiloID").Value.ToString And row.Cells("LecturaCodigos").Value.ToString = "NO" Then
            '        Dim ventanaAdvertencia As New Tools.AdvertenciaForm
            '        ventanaAdvertencia.mensaje = "El artículo seleccionado ya existé"
            '        ventanaAdvertencia.ShowDialog()
            '        pgrsPnlCargando.Hide()
            '        Return
            '    End If
            'Next
            Cursor = Cursors.WaitCursor
            If grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns.Exists("decd_productoestiloid") Then
                grdArticulosSeleccionados.DataSource = Nothing
            End If
            ColocarArticuloEnGrid(CInt(cmbArticulos.SelectedValue))
            poblarGrid()
            pgrsPnlCargando.Hide()

        Else
            Dim Ventana As New Tools.AdvertenciaForm
            Ventana.mensaje = "Debe seleccionar un artículo"
            Ventana.ShowDialog()
        End If
    End Sub

    Public Sub Permisos()
        pnlBtnAgregarArticulo.Visible = objPermisos.BtnArticulosDocumentos
        pnlBtnEliminar.Visible = objPermisos.BtnEliminarDetalle
        btnAgregarArticulos.Visible = objPermisos.BtnArticulosDocumentos
        txtModeloSAY.Visible = objPermisos.BtnArticulosDocumentos
        pnlSeleccionModelos.Visible = objPermisos.BtnArticulosDocumentos
        cmbArticulos.Visible = objPermisos.BtnArticulosDocumentos
        Label20.Visible = objPermisos.BtnArticulosDocumentos
        lblEtiquetaBtnAgregarArticulo.Visible = objPermisos.BtnArticulosDocumentos
        lblEtiquetaMonto.Visible = objPermisos.VerMontos
        lblMonto.Visible = objPermisos.VerMontos
    End Sub

    Public Sub GenerarCombo_Grid(combo As UltraCombo, tabla As DataTable, etiqueta As String, valor As String)
        combo.BindingContext = Me.BindingContext
        combo.DataSource = tabla
        combo.ValueMember = valor
        combo.DisplayMember = etiqueta
        combo.BorderStyle = UIElementBorderStyle.Solid
        combo.DisplayLayout.Bands(0).Columns(0).Hidden = True
        combo.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid
        combo.DropDownStyle = UltraComboStyle.DropDownList
        combo.DisplayLayout.Bands(0).ColHeadersVisible = False

    End Sub

    Private Sub DevolucionCliente_CapturaGeneral_DetallesArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable

        Dim dtNaves As DataTable
        Dim row As DataRow

        dtNaves = (New Negocios.DevolucionCliente_EntradaSalida_Nave_BU).ConsultaNaves()

        row = dtNaves.NewRow()
        row("IdNave") = 0
        row("Nave") = ""
        dtNaves.Rows.InsertAt(row, 0)

        tabla.Columns.Add(New DataColumn("Valor", GetType(Int16)))
        tabla.Columns.Add(New DataColumn("Procede", GetType(String)))

        tabla.Rows.Add(1, "PROCEDE")
        tabla.Rows.Add(0, "NO PROCEDE")

        If Not IsDBNull(objDevolucion.Devolucionclienteid) And objDevolucion.Devolucionclienteid <> 0 Then

            If Not IsDBNull(objDevolucion.Motivoventas_statusid) And Not IsNothing(objDevolucion.Motivoventas_statusid) Then
                If objDevolucion.Motivoventas_statusid.ToString.Length > 0 And objDevolucion.Motivoventas_statusid <> 0 Then
                    idMotivoDevolucion = objDevolucion.Motivoventas_statusid
                Else
                    idMotivoDevolucion = objDevolucion.Motivoinicialalmacen_statusid
                End If
            Else
                idMotivoDevolucion = objDevolucion.Motivoinicialalmacen_statusid
            End If

            lblCantidad.Text = objDevolucion.Cantidad_inicial.ToString("N0", CultureInfo.InvariantCulture)
            lblCajas.Text = objDevolucion.Cajas.ToString("N0", CultureInfo.InvariantCulture)
            lblFolioDevolucion.Text = objDevolucion.Devolucionclienteid
            lblCliente.Text = objDevolucion.NombreCliente
            lblUnidadMedida.Text = objDevolucion.Unidad

            objPermisos = negocios.ValidaPermisosPantallas(objDevolucion.Devolucionclienteid, "CONSULTA_DETALLES", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            Permisos()

            poblarGrid()

            GenerarCombo_Grid(cmbClasificacion_UC, negocios.ConsultaClasificacion_Detalles(), "esta_nombre", "esta_estatusid")
            GenerarCombo_Grid(cmbNave_UC, dtNaves, "Nave", "IdNave")
            GenerarCombo_Grid(cmbProcede_UC, tabla, "Procede", "Valor")

            cantidad = CInt(sumarColumnas(grdArticulosSeleccionados, "Cantidad"))

            paresaplicados = CInt(sumarColumnas(grdArticulosSeleccionados, "Aplicados"))
            paresxplicar = CInt(sumarColumnas(grdArticulosSeleccionados, "Por Aplicar"))

            total = sumarColumnas(grdArticulosSeleccionados, "Total")
            txtModeloSAY.Select()

            lblParesCapturados.Text = cantidad.ToString("N0", CultureInfo.InvariantCulture)
            lblMonto.Text = total.ToString("N0", CultureInfo.InvariantCulture)
        ElseIf variosFolios = True Then
            'lblCantidad.Text = objDevolucion.Cantidad_inicial.ToString("N0", CultureInfo.InvariantCulture)
            'lblCajas.Text = objDevolucion.Cajas.ToString("N0", CultureInfo.InvariantCulture)
            'lblFolioDevolucion.Text = objDevolucion.Devolucionclienteid
            'lblCliente.Text = objDevolucion.NombreCliente
            objPermisos = negocios.ValidaPermisosPantallas(objDevolucion.Devolucionclienteid, "CONSULTA_DETALLES", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            Permisos()

            txtModeloSAY.Enabled = False
            pnlSeleccionModelos.Enabled = False
            cmbArticulos.Enabled = False
            btnAgregarArticulo.Enabled = False
            btnAgregarArticulos.Enabled = False
            btnCodigosCliente.Enabled = False
            btnEliminar.Enabled = False

            poblarGrid()

            ' Configuración para que en el campo línea aparezca un combo box

            GenerarCombo_Grid(cmbClasificacion_UC, negocios.ConsultaClasificacion_Detalles(), "esta_nombre", "esta_estatusid")
            GenerarCombo_Grid(cmbNave_UC, dtNaves, "nave_nombre", "nave_naveid")
            GenerarCombo_Grid(cmbProcede_UC, tabla, "Procede", "Valor")

            cantidad = CInt(sumarColumnas(grdArticulosSeleccionados, "Cantidad"))
            paresaplicados = CInt(sumarColumnas(grdArticulosSeleccionados, "Aplicados"))
            paresxplicar = CInt(sumarColumnas(grdArticulosSeleccionados, "Por Aplicar"))
            total = sumarColumnas(grdArticulosSeleccionados, "Total")
            txtModeloSAY.Select()

            lblParesCapturados.Text = cantidad.ToString("N0", CultureInfo.InvariantCulture)
            lblMonto.Text = total.ToString("N0", CultureInfo.InvariantCulture)
            'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_DCTE_NUEVADEV", "EDICION_PRECIO") Then
            '    edicion_precio = True
            'End If
        End If

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub grdArticulosSeleccionados_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdArticulosSeleccionados.InitializeLayout
        FormatoGrid()

        e.Layout.Bands(0).Columns("* Clasificación").EditorComponent = cmbClasificacion_UC
        'e.Layout.Bands(0).Columns("Nave").AutoCompleteMode = AutoCompleteMode.Append
        e.Layout.Bands(0).Columns("Nave").EditorComponent = cmbNave_UC
        e.Layout.Bands(0).Columns("Procede").EditorComponent = cmbProcede_UC

        e.Layout.Bands(0).Columns("Nave").FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains
        'e.Layout.Bands(0).Columns("Motivo").EditorComponent = cmbMotivo_uc
        total = 0
        cantidad = 0

        For Each row As UltraGridRow In grdArticulosSeleccionados.Rows
            total += CDbl(row.Cells("Total").Value.ToString)
            cantidad += CDbl(row.Cells("Cantidad").Value.ToString)
        Next

        If Not IsDBNull(objDevolucion.Tipodevolucion) And Not IsNothing(objDevolucion.Tipodevolucion) Then
            If objDevolucion.Motivoinicialalmacen_statusid <> 372 Then
                'If objDevolucion.Motivoinicialalmacen_statusid <> 374 Then Para pruebas
                grdArticulosSeleccionados.DisplayLayout.Bands(0).Columns("Motivo").Hidden = True
            End If
        End If
        lblParesCapturados.Text = cantidad.ToString("N0", CultureInfo.InvariantCulture)
        lblMonto.Text = total.ToString("N0", CultureInfo.InvariantCulture)

        If grdArticulosSeleccionados.Rows.Count > 0 And variosFolios = False Then
            btnEliminar.Enabled = objPermisos.BtnEliminarDetalle
        End If

    End Sub


    Private Sub grdArticulosSeleccionados_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdArticulosSeleccionados.ClickCell

        If Not grdArticulosSeleccionados.ActiveRow.IsDataRow Then Return
        If IsNothing(grdArticulosSeleccionados.ActiveRow) Then Return
        If e.Cell.Column.ToString = " " Then
            If grdArticulosSeleccionados.ActiveRow.Cells(" ").Value Then
                grdArticulosSeleccionados.ActiveRow.Cells(" ").Value = False
            Else
                grdArticulosSeleccionados.ActiveRow.Cells(" ").Value = True
            End If

            Dim marcados As Integer
            For Each row As UltraGridRow In grdArticulosSeleccionados.Rows
                If CBool(row.Cells(" ").Value) Then
                    marcados += 1
                End If
            Next
            lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)

            If marcados > 0 Then
                btnEliminar.Enabled = objPermisos.BtnEliminarDetalle
            Else
                btnEliminar.Enabled = False
            End If
        Else
            MostrarParesPorTalla()
        End If

        If e.Cell.Column.ToString = "Precio" Then
            If objPermisos.EdicionPrecio = True Then
                If CDbl(e.Cell.Value.ToString) = 0 Or dtDetallesOriginal.Rows(grdArticulosSeleccionados.ActiveRow.Index).Item("Precio_CapturadoCobranza") = True Then
                    grdArticulosSeleccionados.PerformAction(UltraGridAction.EnterEditMode, False, False)
                Else
                    Dim ventanaAdvertencia As New Tools.AdvertenciaForm
                    ventanaAdvertencia.mensaje = "Solo se pueden modificar los registros con precio $0.00 o aquellos que hayan sido modificados por cobranza"
                    ventanaAdvertencia.ShowDialog()
                End If
                'If (CDbl(e.Cell.Value.ToString) = 0 And objPermisos.EdicionPrecio = True) Or (CDbl(e.Cell.Value.ToString) <> 0 And dtDetallesOriginal.Rows(grdArticulosSeleccionados.ActiveRow.Index).Item("Precio_CapturadoCobranza") = True) Then

                'Else
                '    Dim ventanaAdvertencia As New Tools.AdvertenciaForm
                '    ventanaAdvertencia.mensaje = "Solo se pueden modificar los registros con precio $0.00 o aquellos que hayan sido modificados por cobranza"
                '    ventanaAdvertencia.ShowDialog()
            End If
        ElseIf e.Cell.Column.Header.Caption = "* Cantidad" Then 'grdArticulosSeleccionados.Rows(grdArticulosSeleccionados.ActiveRow.Index).Cells("LecturaCodigos").Value = False 
            MostrarParesPorTalla()
        ElseIf e.Cell.Column.Header.Caption = "* Clasificación" Or e.Cell.Column.Header.Caption = "Nave" Or e.Cell.Column.Header.Caption = "Procede" Then
            If grdArticulosSeleccionados.ActiveRow.Cells("LecturaCodigos").Value = "SI" Then
                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Los detalles generados por lectura de códigos no se pueden modificar")
                My.Computer.Keyboard.SendKeys("{ESC}", False)
                Exit Sub
            End If
            grdArticulosSeleccionados.PerformAction(UltraGridAction.ActivateCell, False, False)
        ElseIf e.Cell.Column.ToString = "Lote" Then
            If grdArticulosSeleccionados.ActiveRow.Cells("LecturaCodigos").Value = "SI" Then
                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Los detalles generados por lectura de códigos no se pueden modificar")
                My.Computer.Keyboard.SendKeys("{ESC}", False)
                Exit Sub
            End If

            If objPermisos.Area.ToString.ToUpper = "ALMACÉN" Then
                grdArticulosSeleccionados.PerformAction(UltraGridAction.EnterEditMode, False, False)
            End If

        ElseIf e.Cell.Column.ToString = "Motivo" Then
            If grdArticulosSeleccionados.ActiveRow.Cells("LecturaCodigos").Value = "SI" Then
                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Los detalles generados por lectura de códigos no se pueden modificar")
                My.Computer.Keyboard.SendKeys("{ESC}", False)
                Exit Sub
            End If
            If objPermisos.Area.ToString.ToUpper = "ALMACÉN" Then
                grdArticulosSeleccionados.PerformAction(UltraGridAction.EnterEditMode, False, False)
            End If
        End If
    End Sub

    Private Sub chkSeleccionarTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodos.CheckedChanged
        If chkSeleccionarTodos.Checked Then
            For Each row As UltraGridRow In grdArticulosSeleccionados.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = True
            Next
            btnEliminar.Enabled = objPermisos.BtnEliminarDetalle
        Else
            For Each row As UltraGridRow In grdArticulosSeleccionados.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = False
            Next
            btnEliminar.Enabled = False
        End If
        Dim marcados As Integer
        For Each row As UltraGridRow In grdArticulosSeleccionados.Rows
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
        txtModeloSAY.Select()
    End Sub

    Public Sub ExportarGrid(grid As UltraGrid)
        Cursor = Cursors.WaitCursor
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New Tools.AdvertenciaForm

        If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 Then

            nombreDocumento = "\Devoluciones_Detalles_"

            With fbdUbicacionArchivo
                .Reset()
                .Description = " Seleccione una carpeta"
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog

                If ret = Windows.Forms.DialogResult.OK Then

                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                    gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")

                    Dim mensajeExito As New Tools.ExitoForm
                    Cursor = Cursors.Default
                    mensajeExito.mensaje = "Los datos se exportaron correctamente"
                    mensajeExito.ShowDialog()
                    Process.Start(.SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                End If
                .Dispose()
            End With
        Else
            Cursor = Cursors.Default
            advertencia.mensaje = "No hay datos para exportar "
            advertencia.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ExportarGrid(grdArticulosSeleccionados)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim detallesSeleccionados As String = ""

        If grdArticulosSeleccionados.Rows.Count <= 0 Then
            Dim ventanaAlerta As New Tools.AdvertenciaForm
            ventanaAlerta.mensaje = "Aún no se ha ingresado ningun detalle"
            ventanaAlerta.ShowDialog()
            Return
        End If

        If CInt(lblNumFiltrados.Text.ToString) > 0 Then
            Dim ventanaConfirmacion As New Tools.ConfirmarForm
            ventanaConfirmacion.mensaje = "Los detalles seleccionados se eliminarán. Si el detalle incluye lectura de códigos, los códigos capturados también se eliminarán " + vbCrLf + "¿Desea continuar?"
            ventanaConfirmacion.ShowDialog()

            If ventanaConfirmacion.DialogResult = Windows.Forms.DialogResult.OK Then
                For index = grdArticulosSeleccionados.Rows.Count - 1 To 0 Step -1
                    If grdArticulosSeleccionados.Rows(index).Cells(" ").Value = True Then
                        If detallesSeleccionados.Length > 0 Then
                            detallesSeleccionados += ","
                        End If
                        detallesSeleccionados += grdArticulosSeleccionados.Rows(index).Cells("IdDetalle").Value.ToString
                        grdArticulosSeleccionados.Rows(index).Delete(False)
                    End If
                Next

                lblNumFiltrados.Text = "0"
                txtModeloSAY.Select()

                If detallesSeleccionados.Length > 0 Then
                    negocios.EliminarDetallesDev(detallesSeleccionados)
                    poblarGrid()

                    Dim ventanExito As New Tools.ExitoForm
                    ventanExito.mensaje = "Los detalles seleccionados se eliminaron correctamente"
                    ventanExito.ShowDialog()
                    chkSeleccionarTodos.Checked = False
                    ActualizarCantidades()
                    grdParesPorTalla.Visible = False
                    lblNumRenglonGrid.Text = ""
                End If

            End If
        Else
            Dim ventanaAdvertencia As New Tools.AdvertenciaForm
            ventanaAdvertencia.mensaje = "No se ha seleccionado ningún detalle"
            ventanaAdvertencia.ShowDialog()
        End If

    End Sub

    Private Sub grdParesPorTalla_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdParesPorTalla.InitializeLayout
        For Each col In grdParesPorTalla.DisplayLayout.Bands(0).Columns
            col.Style = ColumnStyle.DoublePositive
            col.Format = String.Format("N0")
            col.CellAppearance.TextHAlign = HAlign.Right
        Next

        With grdParesPorTalla.DisplayLayout
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorWidth = 35
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
            '.Override.AllowUpdate = DefaultableBoolean.False
            '            .Scrollbars = Scrollbars.Both
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            .Override.SelectTypeRow = SelectType.Single
        End With
        For Each row As UltraGridRow In grdParesPorTalla.Rows
            row.Appearance.BackColor = Color.LightSteelBlue
        Next
        If grdParesPorTalla.DisplayLayout.Bands(0).Columns.Exists("ProductoEstiloID") Then
            grdParesPorTalla.DisplayLayout.Bands(0).Columns("ProductoEstiloID").Hidden = True
        End If

        If grdParesPorTalla.DisplayLayout.Bands(0).Columns.Exists("Descripción") Then
            grdParesPorTalla.DisplayLayout.Bands(0).Columns("Descripción").Hidden = True
        End If
    End Sub

    Private Sub grdArticulosSeleccionados_KeyDown(sender As Object, e As KeyEventArgs) Handles grdArticulosSeleccionados.KeyDown
        Dim grid As UltraGrid = sender
        If e.KeyCode = Keys.Enter Then
            Dim cell As UltraGridCell = grid.ActiveCell
            Dim currentRow As Integer = grid.ActiveRow.Index
            Dim col As Integer = cell.Column.Index
            'grid.Rows(currentRow + 1).Cells(col).Activate()

            If grdArticulosSeleccionados.Rows(currentRow).Cells("LecturaCodigos").Value = "NO" And cell.Column.Header.Caption = "* Cantidad" Then
                If objPermisos.EdicionTallas = False Then Return

                Dim formdetallesPorTalla As New DevolucionCliente_CapturaGeneral_DetallesArticulo_Tallas_Form
                Dim index As Integer = grid.Rows(currentRow).Cells(col).Activate()
                formdetallesPorTalla.DetalleID = CInt(grdArticulosSeleccionados.Rows(currentRow).Cells("IdDetalle").Value.ToString)
                formdetallesPorTalla.FolioDev = objDevolucion.Devolucionclienteid
                formdetallesPorTalla.ProductoEstiloID = CInt(grdArticulosSeleccionados.Rows(currentRow).Cells("ProductoEstiloID").Value.ToString)
                formdetallesPorTalla.StartPosition = FormStartPosition.CenterScreen
                formdetallesPorTalla.ShowDialog()
                poblarGrid()

                grid.Focus()
                grid.Rows(currentRow).Cells(col).Activate()
                grid.PerformAction(UltraGridAction.ToggleCellSel, False, False)
                grid.PerformAction(UltraGridAction.ActivateCell, False, False)
                MostrarParesPorTalla()
                'MostrarParesPorTalla()
            ElseIf cell.Column.Header.Caption = "Precio" Then
                If objPermisos.EdicionPrecio = True Then ' --And CDbl(dtDetallesOriginal.Rows(currentRow).Item("Precio").ToString) = 0 Then
                    'txtModeloSAY.Select()
                    grdArticulosSeleccionados.PerformAction(UltraGridAction.ExitEditMode, False, False)
                    grdArticulosSeleccionados_AfterCellUpdate()
                    My.Computer.Keyboard.SendKeys("{ESC}", False)
                ElseIf objPermisos.EdicionPrecio = False Then
                    Dim ventanaAdvertencias As New Tools.AdvertenciaForm
                    ventanaAdvertencias.mensaje = "El usuario no tiene permisos suficientes para cambiar el precio"
                    ventanaAdvertencias.ShowDialog()
                End If
            ElseIf cell.Column.Header.Caption = "Lote" Then
                If objPermisos.Area.ToString.ToUpper = "ALMACÉN" Then ' --And CDbl(dtDetallesOriginal.Rows(currentRow).Item("Precio").ToString) = 0 Then
                    grdArticulosSeleccionados.PerformAction(UltraGridAction.ExitEditMode, False, False)
                    grdArticulosSeleccionados_AfterCellUpdate()
                    My.Computer.Keyboard.SendKeys("{ESC}", False)
                End If
            ElseIf grdArticulosSeleccionados.Rows(currentRow).Cells("LecturaCodigos").Value = "SI" Then
                Dim advertencia As New Tools.AdvertenciaForm
                advertencia.mensaje = "Los detalles generados por lectura de códigos no se pueden modificar"
                advertencia.ShowDialog()
            End If
        End If
    End Sub

    Private Sub grdArticulosSeleccionados_AfterCellUpdate()
        Dim cell As UltraGridCell = grdArticulosSeleccionados.ActiveCell
        Dim currentRow As Integer = grdArticulosSeleccionados.ActiveRow.Index
        Dim detalle As Integer = CInt(grdArticulosSeleccionados.Rows(currentRow).Cells("IdDetalle").Value.ToString)

        Dim ventanaConfirmacion As New Tools.ConfirmarForm
        If cell.Column.Header.Caption = "Lote" Then
            Dim lote As String = grdArticulosSeleccionados.Rows(currentRow).Cells("Lote").Value.ToString
            If lote = "" Or lote = "0" Or lote = "0.00" Then
                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "No se puede realizar la modificación, asegúrese de que el campo NO esté vacío y el lote sea diferente de 0")
                grdArticulosSeleccionados.Rows(currentRow).Cells("Lote").Value = 0
                SendKeys.Send("ESC")
                Return
            End If
            'ventanaConfirmacion.mensaje = "¿Desea modificar el lote seleccionado?"
            'ventanaConfirmacion.ShowDialog()
            'If ventanaConfirmacion.DialogResult <> DialogResult.OK Then Return
            negocios.ActualizarLote(detalle, CDbl(lote), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            'Tools.Controles.Mensajes_Y_Alertas("EXITO", "Lote actualizado correctamente")
        Else
            Dim precio As String = grdArticulosSeleccionados.Rows(currentRow).Cells("Precio").Value.ToString
            If precio = "" Or precio = "0" Or precio = "0.00" Then
                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "No se puede realizar la modificación, asegúrese de que el campo NO esté vacío y el precio sea mayor a 0")
                grdArticulosSeleccionados.Rows(currentRow).Cells("Precio").Value = 0.00
                SendKeys.Send("ESC")
                Return
            End If
            ventanaConfirmacion.mensaje = "¿Desea modificar el precio del detalle?"
            ventanaConfirmacion.ShowDialog()
            If ventanaConfirmacion.DialogResult <> DialogResult.OK Then Return
            negocios.ActualizarPrecio(detalle, CDbl(precio), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            Tools.Controles.Mensajes_Y_Alertas("EXITO", "Precio actualizado correctamente")
        End If

        poblarGrid()

    End Sub

    Private Sub grdArticulosSeleccionados_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdArticulosSeleccionados.KeyPress
        Try
            Dim grid As UltraGrid = sender
            Dim cell As UltraGridCell = grid.ActiveCell

            renglonEditado = cell.Row.Index
            columnaEditada = cell.Column.Index

            If Char.IsLetter(e.KeyChar) And cell.Column.Header.Caption <> "* Clasificación" And cell.Column.Header.Caption <> "Nave" Then
                e.Handled = True
            End If
            If cell.Column.Header.Caption = "Nave" And e.KeyChar = ChrW(Keys.Space) Then
                cell.DroppedDown = True
            ElseIf cell.Column.Header.Caption = "Motivo" And e.KeyChar = ChrW(Keys.Space) Then
                AbrirPanelMotivo()
                'cmbNave_UC.ToggleDropdown()
            ElseIf cell.Column.Header.Caption = "* Clasificación" And e.KeyChar = ChrW(Keys.Space) Then
                cell.DroppedDown = True
            ElseIf cell.Column.Header.Caption = "Procede" And e.KeyChar = ChrW(Keys.Space) Then
                cell.DroppedDown = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub cambiarValoresComboGrid(Columna As String, valor As String)
        Try
            Dim filaActual As UltraGridRow = grdArticulosSeleccionados.ActiveRow

            If valor = "" Or valor = "0" Then Return
            If valor = dtDetallesOriginal.Rows(filaActual.Index).Item(Columna) Then Return

            'Dim ventanaConfirmacion As New Tools.ConfirmarForm
            'ventanaConfirmacion.mensaje = "¿Desea aplicar los cambios a todos los detalles?" + vbCrLf + "(Al presionar 'NO' solo cambiará el valor del registro seleccionado"
            'ventanaConfirmacion.ShowDialog()

            Cursor = Cursors.WaitCursor
            Dim vXMLClasificacion As XElement = New XElement("ClasificacionNaveXML")
            txtModeloSAY.Select()

            'If ventanaConfirmacion.DialogResult = DialogResult.OK Then
            '    For Each row As UltraGridRow In grdArticulosSeleccionados.Rows
            '        Dim vNodo As XElement = New XElement("ClasificacionNave")
            '        'Con este atributo se define si lo que se va a modificar es la nave o la clasificación
            '        vNodo.Add(New XAttribute("tipo", Columna))
            '        vNodo.Add(New XAttribute("detalleId", row.Cells("IdDetalle").Value))
            '        vNodo.Add(New XAttribute("valorNuevo", valor))
            '        vNodo.Add(New XAttribute("usuario", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
            '        vXMLClasificacion.Add(vNodo)
            '    Next

            '    negocios.ModificarClasificacion_Detalles(vXMLClasificacion.ToString)

            '    Dim ventana As New Tools.ExitoForm
            '    ventana.mensaje = "Se modificaron los valores de todos los detalles"
            '    ventana.ShowDialog()
            '    poblarGrid()
            'ElseIf ventanaConfirmacion.DialogResult = DialogResult.Cancel Then
            Dim vNodo As XElement = New XElement("ClasificacionNave")
            'Con este atributo se define si lo que se va a modificar es la nave o la clasificación
            vNodo.Add(New XAttribute("tipo", Columna))
            vNodo.Add(New XAttribute("detalleId", filaActual.Cells("IdDetalle").Value))
            vNodo.Add(New XAttribute("valorNuevo", valor))
            vNodo.Add(New XAttribute("usuario", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
            vXMLClasificacion.Add(vNodo)

            negocios.ModificarClasificacion_Detalles(vXMLClasificacion.ToString)

            'Dim ventana As New Tools.ExitoForm
            'ventana.mensaje = "Se modificaron los valores del detalle seleccionado"
            'ventana.ShowDialog()
            poblarGrid()
            'End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Dim ventanaError As New Tools.ErroresForm
            ventanaError.mensaje = "Ocurrió un error al guardar" + vbCrLf + ex.Message
            ventanaError.ShowDialog()
            Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub MostrarParesPorTalla()
        Dim paresPorTallas As New DataTable

        Dim currentRow As Integer = grdArticulosSeleccionados.ActiveRow.Index
        renglonSeleccionado = currentRow
        lblNumRenglonGrid.Text = renglonSeleccionado + 1

        Dim DetalleID As Integer = CInt(grdArticulosSeleccionados.Rows(currentRow).Cells("IdDetalle").Value.ToString)
        Dim ProductoEstiloID As Integer = CInt(grdArticulosSeleccionados.Rows(currentRow).Cells("ProductoEstiloID").Value.ToString)
        paresPorTallas = negocios.ConsultarParesPorTalla(DetalleID, ProductoEstiloID, 2)

        grdParesPorTalla.DataSource = paresPorTallas

        grdParesPorTalla.Visible = True
    End Sub


    Private Sub grdArticulosSeleccionados_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdArticulosSeleccionados.DoubleClickCell
        If e.Cell.Column.Header.Caption = "Motivo" Then
            'Dim frmMotivosCalidad As New DevolucionCliente_CapturaGeneral_BusquedaMotivosCalidad
            'Dim filaActual As Int64 = grdArticulosSeleccionados.ActiveRow.Index
            'frmMotivosCalidad.StartPosition = FormStartPosition.CenterScreen
            'frmMotivosCalidad.idDetalle = grdArticulosSeleccionados.Rows(filaActual).GetCellValue("IdDetalle")
            ''frmMotivosCalidad.idDetalle =
            'frmMotivosCalidad.ShowDialog()
            'poblarGrid()
            AbrirPanelMotivo()
        End If
    End Sub

    Private Sub AbrirPanelMotivo()
        Dim frmMotivosCalidad As New DevolucionCliente_CapturaGeneral_BusquedaMotivosCalidad
        Dim filaActual As Int64 = grdArticulosSeleccionados.ActiveRow.Index
        frmMotivosCalidad.StartPosition = FormStartPosition.CenterScreen
        frmMotivosCalidad.idDetalle = grdArticulosSeleccionados.Rows(filaActual).GetCellValue("IdDetalle")
        'frmMotivosCalidad.idDetalle =
        frmMotivosCalidad.ShowDialog()
        poblarGrid()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        poblarGrid()
    End Sub

    Private Sub cmbNave_uc_AfterCloseUp(sender As Object, e As EventArgs) Handles cmbNave_UC.AfterCloseUp
        If String.IsNullOrEmpty(cmbNave_UC.Value) Then Return
        Dim Nave As String = cmbNave_UC.Value.ToString
        If Nave.ToString.Length > 0 And Nave.ToString <> "" And Nave.ToString <> "0" Then
            cambiarValoresComboGrid("Nave", Nave)
        End If
    End Sub

    Private Sub btnEtiquetas_Click(sender As Object, e As EventArgs) Handles btnEtiquetas.Click
        If variosFolios = True Then
            grdInfoEtiquetas.DataSource = negocios.ConsultaDetallesDevolucion_Etiquetas(FoliosDev)
        Else
            grdInfoEtiquetas.DataSource = negocios.ConsultaDetallesDevolucion_Etiquetas(objDevolucion.Devolucionclienteid)
        End If

        grdInfoEtiquetas.DisplayLayout.Bands(0).Columns(0).Format = "dd/MM/yyyy"
        ExportarGrid(grdInfoEtiquetas)
    End Sub

    Private Sub grdInfoEtiquetas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdInfoEtiquetas.InitializeLayout
        asignaFormato_Columna(grdInfoEtiquetas)
        With grdInfoEtiquetas.DisplayLayout
            .PerformAutoResizeColumns(True, AutoResizeColumnWidthOptions.IncludeCells)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.CellSelect
            .Override.AllowAddNew = AllowAddNew.No
            .Scrollbars = Scrollbars.Both
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            .Override.SelectTypeRow = SelectType.Single
        End With
    End Sub

    Private Sub cmbClasificacion_UC_AfterCloseUp(sender As Object, e As EventArgs) Handles cmbClasificacion_UC.AfterCloseUp
        Dim clasificacion As String = cmbClasificacion_UC.Value.ToString
        If clasificacion.ToString.Length > 0 And clasificacion.ToString <> "" And clasificacion.ToString <> "0" Then
            cambiarValoresComboGrid("* Clasificación", clasificacion)
        End If
    End Sub

    Private Sub cmbProcede_UC_ValueChanged(sender As Object, e As EventArgs) Handles cmbProcede_UC.AfterCloseUp
        Try
            Dim procede As Boolean = cmbProcede_UC.Value
            cambiarValoresComboGrid("Procede", procede)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DevolucionCliente_CapturaGeneral_DetallesArticulos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ValidarCerrarForm()
        If Not validadoParaCerrarForm Then
            e.Cancel = True
        End If
    End Sub

    'Private Sub ObtenerArticuloAgregado(productoEstilo As String)
    '    articulosAgregados.Add(productoEstilo)
    'End Sub

    'Private Sub ObtenerFilaAgregada()
    '    If grdArticulosSeleccionados.Rows(grdArticulosSeleccionados.Rows.Count - 1).GetCellValue("ProductoEstiloID").ToString = articulosAgregados(articulosAgregados.Count - 1) Then
    '        filasAgregadas.Add((grdArticulosSeleccionados.Rows.Count - 1).ToString)
    '    End If
    'End Sub

    Private Sub ValidarCerrarForm()
        If validadoParaCerrarForm = False Then
            If ValidarCampos() = False Then
                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Algunos artículos tienen datos incompletos.")

                If registroErroneoFila.Count > 0 Then
                    For index = 0 To registroErroneoFila.Count - 1
                        grdArticulosSeleccionados.Rows(registroErroneoFila(index)).CellAppearance.ForeColor = Color.Red
                    Next
                End If

            Else
                validadoParaCerrarForm = True
                Me.Dispose()
            End If
        End If

    End Sub

    Private Function ValidarCampos() As Boolean
        Dim validado As Boolean = True
        registroErroneoFila.Clear()

        If objDevolucion.Tipodevolucion = "MENUDEO" Then
            If grdArticulosSeleccionados.Rows.Count > 0 Then
                For index = 0 To grdArticulosSeleccionados.Rows.Count - 1
                    validado = False
                    If grdArticulosSeleccionados.Rows(index).GetCellValue("Cantidad").ToString > 0 Then
                        If Not String.IsNullOrEmpty(grdArticulosSeleccionados.Rows(index).GetCellValue("Motivo").ToString) Or objDevolucion.Motivoinicialalmacen_statusid <> 372 Then
                            If Not String.IsNullOrEmpty(grdArticulosSeleccionados.Rows(index).GetCellValue("Nave").ToString) Then
                                If grdArticulosSeleccionados.Rows(index).GetCellValue("Nave").ToString <> "0" Then
                                    validado = True
                                End If
                            End If
                        End If
                    End If

                    If validado = False Then
                        registroErroneoFila.Add(index)
                    End If
                Next
            End If
        End If

        If registroErroneoFila.Count > 0 Then
            validado = False
        End If

        Return validado
    End Function


End Class