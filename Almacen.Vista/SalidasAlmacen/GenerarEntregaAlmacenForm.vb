Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class GenerarEntregaAlmacenForm

    Private renglonesSeleccionados As DataTable
    Private tipoConsultaEmbarque As Integer = 0
    Private agrupadoTienda As Boolean
    Private IdSalidasAEmbarcar As String = String.Empty
    Private var_IdEmbarque As Integer = 0

    Sub New(seleccion As DataTable, ByVal tipoConsulta As Integer, ByVal conTienda As Boolean, ByVal idEmbarque As Integer)
        InitializeComponent()
        renglonesSeleccionados = seleccion
        'Tipo de consulta
        '1 - Por orden de trabajo
        '2 - Por factura / documento
        '3 - Por Pedido
        tipoConsultaEmbarque = tipoConsulta
        agrupadoTienda = conTienda
        var_IdEmbarque = idEmbarque
    End Sub



    Private Sub GenerarEntregaAlmacenForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objBU As New Negocios.SalidasAlmacenBU
        Dim Tabla_ListadoParametros As New DataTable

        Tabla_ListadoParametros = objBU.LlenarCombosGenerarEntrega(1)
        Tabla_ListadoParametros.Rows.InsertAt(Tabla_ListadoParametros.NewRow, 0)
        cmbMensajeriaReal.DataSource = Tabla_ListadoParametros
        cmbMensajeriaReal.DisplayMember = "Nombre"
        cmbMensajeriaReal.ValueMember = "ID"
        Tabla_ListadoParametros = objBU.LlenarCombosGenerarEntrega(2)
        Tabla_ListadoParametros.Rows.InsertAt(Tabla_ListadoParametros.NewRow, 0)
        cmbOperador.DataSource = Tabla_ListadoParametros
        cmbOperador.DisplayMember = "Operador"
        cmbOperador.ValueMember = "ID"
        Tabla_ListadoParametros = objBU.LlenarCombosGenerarEntrega(3)
        Tabla_ListadoParametros.Rows.InsertAt(Tabla_ListadoParametros.NewRow, 0)
        cmbUnidad.DataSource = Tabla_ListadoParametros
        cmbUnidad.DisplayMember = "Unidad"
        cmbUnidad.ValueMember = "ID"
        lblNumFiltrados.Text = "0"

        grdListaSalidas.DataSource = renglonesSeleccionados

        gridSalidasDiseño(grdListaSalidas)


        For Each row As UltraGridRow In grdListaSalidas.Rows.GetFilteredInNonGroupByRows
            If IdSalidasAEmbarcar <> "" Then
                IdSalidasAEmbarcar += ","
            End If
            IdSalidasAEmbarcar += row.Cells("IDSalidaDetalle").Value
        Next
        cmbOperador.Enabled = False
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim confirmacion As New ConfirmarForm
        Dim objBU As New Negocios.SalidasAlmacenBU
        Dim objGeneracionEmbarque As New Entidades.GeneracionEmbarque
        If cmbMensajeriaReal.SelectedIndex > 0 Then
            If (cmbUnidad.Enabled = True And cmbUnidad.SelectedIndex > 0) Or cmbUnidad.Enabled = False Then
                If (cmbOperador.Enabled = True And cmbOperador.SelectedIndex > 0) Or cmbOperador.Enabled = False Then
                    confirmacion.mensaje = "¿Desea generar el embarque de " + lblNumFiltrados.Text + " pares?"
                    If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Cursor = Cursors.WaitCursor
                        objGeneracionEmbarque.PIdDetalleEntrega = IdSalidasAEmbarcar

                        objGeneracionEmbarque.PMensajeriaRealId = cmbMensajeriaReal.SelectedValue
                        objGeneracionEmbarque.PMensajeriaRealNombre = RTrim(LTrim(cmbMensajeriaReal.SelectedItem(1).ToString()))
                        objGeneracionEmbarque.POperadorEmbarqueId = 0
                        objGeneracionEmbarque.POperadorEmbarqueNombre = ""
                        If cmbOperador.SelectedIndex > 0 Then
                            objGeneracionEmbarque.POperadorEmbarqueId = cmbOperador.SelectedValue
                            objGeneracionEmbarque.POperadorEmbarqueNombre = RTrim(LTrim(cmbOperador.SelectedItem(1).ToString()))
                        End If
                        objGeneracionEmbarque.PUsuarioEmbarque = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        objGeneracionEmbarque.PUnidadEmbarqueId = 0
                        objGeneracionEmbarque.PUnidadEmbarqueNombre = ""
                        If cmbUnidad.SelectedIndex > 0 Then
                            objGeneracionEmbarque.PUnidadEmbarqueId = cmbUnidad.SelectedValue
                            objGeneracionEmbarque.PUnidadEmbarqueNombre = RTrim(LTrim(cmbUnidad.SelectedItem(1).ToString()))
                        End If
                        objGeneracionEmbarque.PCantidadParesEmbarque = lblNumFiltrados.Text

                        objGeneracionEmbarque.PIdEmbarque = var_IdEmbarque

                        Dim resultadoGeneracionEmbarque As New DataTable
                        If tipoConsultaEmbarque <> 5 Then
                            resultadoGeneracionEmbarque = objBU.generarEmbarques(objGeneracionEmbarque)
                        Else
                            resultadoGeneracionEmbarque = objBU.editarEmbarques(objGeneracionEmbarque)
                        End If

                        If cmbOperador.Enabled = False And cmbUnidad.Enabled = True Then
                            Dim objGeneracionSalida As New Entidades.GeneracionSalida
                            objGeneracionSalida.PIdDetalleEntrega = IdSalidasAEmbarcar
                            objGeneracionSalida.PUsuarioSalida = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                            objGeneracionSalida.PCantidadParesSalida = lblNumFiltrados.Text
                            objGeneracionSalida.PCantidadParesNoRecibidos = 0

                            Dim resultadoGeneracionSalida As New DataTable
                            resultadoGeneracionSalida = objBU.generarSalida(objGeneracionSalida)

                            Dim ListaPedidosSICY = renglonesSeleccionados.AsEnumerable().Select(Function(x) x.Item("Pedido")).Distinct.ToList()
                            Dim PedidosSICY As String = String.Join(",", ListaPedidosSICY)

                            objBU.actualizarStatusOTSAYParesEnRuta()
                            objBU.actualizarStatusOTSAYParesEntregado()
                            objBU.ActualizarEstatusPedido(PedidosSICY)
                            objBU.ReplicarEstatusPedidoSAY_SICY(PedidosSICY)

                        Else

                            Dim ListaPedidosSICY = renglonesSeleccionados.AsEnumerable().Select(Function(x) x.Item("Pedido")).Distinct.ToList()
                            Dim PedidosSICY As String = String.Join(",", ListaPedidosSICY)

                            objBU.actualizarStatusOTSAYParesEnRuta()
                            objBU.ActualizarEstatusPedido(PedidosSICY)
                            objBU.ReplicarEstatusPedidoSAY_SICY(PedidosSICY)


                        End If

                        Cursor = Cursors.Default
                        show_message(resultadoGeneracionEmbarque.Rows(0).Item("tipoResultado"), resultadoGeneracionEmbarque.Rows(0).Item("resultado"))
                        If resultadoGeneracionEmbarque.Rows(0).Item("tipoResultado") = "Exito" Then
                            Me.Close()
                        End If
                    End If
                Else
                    Cursor = Cursors.Default
                    show_message("Advertencia", "Debe seleccionar un operador")
                End If
            Else
                Cursor = Cursors.Default
                show_message("Advertencia", "Debe seleccionar una unidad")
            End If

        Else
            Cursor = Cursors.Default
            show_message("Advertencia", "Debe seleccionar una paquetería")
        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlCampos.Height = 26
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlCampos.Height = 142
    End Sub

    Private Sub btnDetalles_Click(sender As Object, e As EventArgs) Handles btnDetalles.Click
        Cursor = Cursors.WaitCursor
        Dim idSalidasBuscarPares As String
        Dim idTienda As String
        idTienda = String.Empty
        idSalidasBuscarPares = String.Empty
        idSalidasBuscarPares = IdSalidasAEmbarcar
        Dim objVentanaPares As New ConsultarParesSalidaAlmacenForm(idSalidasBuscarPares)
        objVentanaPares.MdiParent = Me.MdiParent
        'Cursor = Cursors.Default
        objVentanaPares.Show()
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

    Private Sub gridSalidasDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        Dim totalPares As Integer = 0

        grid.DisplayLayout.Bands(0).Columns("IDSalidaDetalle").Hidden = True
        If tipoConsultaEmbarque = 1 Then
            grid.DisplayLayout.Bands(0).Columns("OT").Header.Caption = "OT"
            grid.DisplayLayout.Bands(0).Columns("OT").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("OT").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        End If
        If tipoConsultaEmbarque = 2 Then
            grid.DisplayLayout.Bands(0).Columns("Documento").Header.Caption = "Documento"
            grid.DisplayLayout.Bands(0).Columns("Documento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Documento").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Año_documento").Header.Caption = "Año Documento"
            grid.DisplayLayout.Bands(0).Columns("Año_documento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Año_documento").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Factura").Header.Caption = "Factura"
            grid.DisplayLayout.Bands(0).Columns("Factura").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Factura").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        End If
        If tipoConsultaEmbarque = 3 Then
            grid.DisplayLayout.Bands(0).Columns("Pedido").Header.Caption = "Pedido"
            grid.DisplayLayout.Bands(0).Columns("Pedido").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Pedido").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Cliente").Header.Caption = "Cliente"
            grid.DisplayLayout.Bands(0).Columns("Cliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Mensajeria_Factura").Header.Caption = "Mensajeria Factura"
            grid.DisplayLayout.Bands(0).Columns("Mensajeria_Factura").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Else
            grid.DisplayLayout.Bands(0).Columns("Cliente").Header.Caption = "Cliente"
            grid.DisplayLayout.Bands(0).Columns("Cliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            If agrupadoTienda Then
                grid.DisplayLayout.Bands(0).Columns("Tienda").Header.Caption = "Tienda"
                grid.DisplayLayout.Bands(0).Columns("Tienda").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                grid.DisplayLayout.Bands(0).Columns("idTienda").Hidden = True
            End If
            If tipoConsultaEmbarque <> 5 Then
                grid.DisplayLayout.Bands(0).Columns("Mensajeria_Factura").Header.Caption = "Mensajeria Factura"
                grid.DisplayLayout.Bands(0).Columns("Mensajeria_Factura").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            grid.DisplayLayout.Bands(0).Columns("Pedido").Header.Caption = "Pedido"
            grid.DisplayLayout.Bands(0).Columns("Pedido").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Pedido").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            'grid.DisplayLayout.Bands(0).Columns("Pares").Header.Caption = "Pares"
            'grid.DisplayLayout.Bands(0).Columns("Pares").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            'grid.DisplayLayout.Bands(0).Columns("Pares").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            'grid.DisplayLayout.Bands(0).Columns("Pares").Format = "n0"
        End If

        If agrupadoTienda Then
            grid.DisplayLayout.Bands(0).Columns("Tienda").Header.Caption = "Tienda"
            grid.DisplayLayout.Bands(0).Columns("Tienda").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("idTienda").Hidden = True
        End If

        grid.DisplayLayout.Bands(0).Columns("Pares").Header.Caption = "Pares"
        grid.DisplayLayout.Bands(0).Columns("Pares").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Pares").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Pares").Format = "n0"

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grid.DisplayLayout.GroupByBox.Hidden = False
        grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"

        Dim summary1 As SummarySettings
        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Pares"))
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
            totalPares += row.Cells("Pares").Value
        Next

        lblNumFiltrados.Text = totalPares.ToString("#,##0")

    End Sub

    Private Sub grdListaSalidas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaSalidas.InitializeLayout
        grid_diseño(grdListaSalidas)
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

    Private Sub cmbMensajeriaReal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMensajeriaReal.SelectedIndexChanged
        If RTrim(LTrim(cmbMensajeriaReal.SelectedItem(1).ToString())) = "YUYIN (NOSOTROS MISMOS)" Then
            cmbOperador.Enabled = True
            cmbOperador.SelectedIndex = -1
            cmbUnidad.Enabled = True
            cmbUnidad.SelectedIndex = -1
        Else
            cmbOperador.Enabled = False
            cmbOperador.SelectedIndex = -1
            If RTrim(LTrim(cmbMensajeriaReal.SelectedItem(1).ToString())) = "CLIENTE (RECOGE)" Then
                cmbUnidad.Enabled = False
                cmbUnidad.SelectedIndex = -1
            Else
                cmbUnidad.Enabled = True
                cmbUnidad.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub GenerarEntregaAlmacenForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Cursor = Cursors.Default
    End Sub
End Class