Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section

Public Class AltaConfiguracionListaPreciosCliente
    Public ftc As Boolean = False
    Public idClienteFTC As Int32 = 0
    Public idListaBase As Int32
    Public nombreListaBase As String
    Public idListaPreciosVentas As Int32
    Public nombreListaPreciosVentas As String
    Public idListaVentasCliente As Int32
    Public nombreCliente As String
    Public estatusLB As String
    Public accionPantalla As String
    Public idListaVentasClientePrecio As Int32
    Public fechaMax As String
    Public fechaMin As String
    Public tipoClienteId As Int32
    Public incrementoListaVentas As Double
    Public idListaVentasClientePrecioCOPIA As Int32
    Public idListaPreciosVentasCOPIA As Int32
    Public inactiva As Boolean = False


    Dim endEdit As Boolean = True
    Dim idListaCliente As Int32 = 0
    Dim idFlete As Int32 = 0
    Dim idIva As Int32 = 0
    Dim idMoneda As Int32 = 0
    Dim incremento As Double = 0
    Dim porcentaje As Boolean = True
    Dim contConfiguracion As Int32 = 0
    Dim primerEstatus As Int32
    Dim PermiteEdicion As Boolean = False

    Dim fechaInicioListaBase As String
    Dim fechaFinListaBase As String

    Public Sub llenarComboListasPrecios()
        Dim objLPVC As New Negocios.ListaPreciosVentaClienteBU
        Dim dtDatosListaPrecios As New DataTable
        dtDatosListaPrecios = objLPVC.consultasDatosListasBaseCliente(idClienteFTC, 0)
        If dtDatosListaPrecios.Rows.Count > 0 Then
            cmbListasBase.DataSource = dtDatosListaPrecios
            cmbListasBase.DisplayMember = "LISTABASE"
            cmbListasBase.ValueMember = "lpba_listapreciosbaseid"
        End If
        cmbListasBase.SelectedValue = idListaBase
    End Sub

    Public Sub BloquearCamposListaInactiva()
        grpDatos.Enabled = False
        GroupBox5.Enabled = False
        grpMovimientoParidadOLoriginal.Enabled = False
        grpOperaciones.Enabled = False
        grbQuitarArticulo.Enabled = False
        chkSeleccionArticulos.Enabled = False
        chkTodosLosArticulos.Enabled = False
        btnGuardar.Enabled = False
    End Sub

    'Public Sub llenarComboListaVentasCliente(ByVal idListaBase As Int32)
    '    Dim objLVC As New Negocios.ListaPreciosVentaClienteBU
    '    Dim dtDatosListaVentas As New DataTable
    '    If cmbClientes.SelectedIndex > 0 Then
    '        dtDatosListaVentas = objLVC.consultaListaVentasCliente(idListaBase, cmbClientes.SelectedValue)
    '        If dtDatosListaVentas.Rows.Count > 0 Then
    '            cmbListaVentas.DataSource = dtDatosListaVentas
    '            cmbListaVentas.DisplayMember = "LISTAVENTAS"
    '            cmbListaVentas.ValueMember = "lvcl_listaventasclienteid"
    '            cmbListaVentas.SelectedIndex = 0
    '            idListaCliente = dtDatosListaVentas.Rows(0).Item("lvcl_listaventasclienteid").ToString
    '            verModelosListaPrecioCliente(idListaCliente)
    '            lblMensajeSinListaVentas.Text = ""
    '        Else
    '            cmbListaVentas.DataSource = Nothing
    '            grdModelos.DataSource = Nothing
    '            idListaCliente = 0
    '            lblMensajeSinListaVentas.Text = "El cliente no tiene asignada una lista de ventas en la lista base " + lblEstatus.Text
    '            verModelosListaPrecioCliente(0)
    '        End If
    '    Else
    '        MsgBox("Seleccione un cliente", MsgBoxStyle.Information, "Atención")
    '    End If
    'End Sub

    'Public Sub llenarComboListaClientes()
    '    Dim objLVC As New Negocios.ListaVentasBU
    '    Dim dtDatosListaClientes As New DataTable
    '    dtDatosListaClientes = objLVC.consultaListaVentasClienteSimple()
    '    Dim newRow As DataRow = dtDatosListaClientes.NewRow
    '    dtDatosListaClientes.Rows.InsertAt(newRow, 0)
    '    cmbClientes.DataSource = dtDatosListaClientes
    '    cmbClientes.DisplayMember = "clie_nombregenerico"
    '    cmbClientes.ValueMember = "clie_clienteid"
    'End Sub


    Private Sub PermisosUsuario()
        Dim DTInformacionUsuario As New DataTable

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VE_LP_PRECIOSCLIENTE", "ADD_UPD_LPC") Then
            PermiteEdicion = True

            txtDescripcionLista.Enabled = True
            If tipoClienteId = 2 Then
                cmbIncoterms.Enabled = True
            End If

            dttInicioVigenciaLVC.Enabled = True
            dttFinVigenciaLVC.Enabled = True
            cmbEstatusLVCP.Enabled = True
            grpAccion.Enabled = True
            chkSeleccionarFiltrados.Enabled = True
            chkTodosLosArticulos.Enabled = True
            chkSeleccionArticulos.Enabled = True
            GroupBox3.Enabled = True
            GroupBox1.Enabled = True
            btnGuardar.Enabled = True
            btnRegresarACapturada.Enabled = True
            lblListaVentas.Enabled = True

        Else
            Dim colSeleccion As UltraGridColumn = grdModelos.DisplayLayout.Bands(0).Columns("Seleccion")
            colSeleccion.CellActivation = Activation.NoEdit
        End If


    End Sub

    Public Sub llenarComboIncoterms()
        Dim objIMC As New Negocios.IncotermsBU
        Dim dtDatosIncoterms As New DataTable
        dtDatosIncoterms = objIMC.ListadoIncoterms
        If dtDatosIncoterms.Rows.Count > 0 Then
            Dim newRow As DataRow = dtDatosIncoterms.NewRow
            dtDatosIncoterms.Rows.InsertAt(newRow, 0)
            cmbIncoterms.DataSource = dtDatosIncoterms
            cmbIncoterms.ValueMember = "inco_incotermsid"
            cmbIncoterms.DisplayMember = "inco_nombre"
        End If
    End Sub

    Public Sub llenarComboEstatus(ByVal estatus As String)
        Dim objLVCP As New Negocios.ListaPreciosVentaClienteBU
        Dim dtEstatusLVCP As New DataTable
        dtEstatusLVCP = objLVCP.consultaEstatusListaVentasClientePrecios(estatus)
        Dim newRow As DataRow = dtEstatusLVCP.NewRow
        dtEstatusLVCP.Rows.InsertAt(newRow, 0)
        cmbEstatusLVCP.DataSource = dtEstatusLVCP
        cmbEstatusLVCP.DisplayMember = "esta_nombre"
        cmbEstatusLVCP.ValueMember = "esta_estatusid"
    End Sub

    Public Sub llenarTablaModelos(ByVal idListaBase As Int32, ByVal idCliente As Int32,
                                  ByVal listaVentasClientePrecioid As Int32, ByVal todosArt As Boolean)
        Dim objLB As New Ventas.Negocios.ListaBaseBU
        Dim objListaVBU As New Negocios.ListaVentasBU
        Dim objCliente As New Negocios.ClientesBU
        Dim dtDatosModelos As New DataTable
        Dim dtListaModelosGenerales As New DataTable
        Dim verModelosGenerales As Boolean = False
        Me.Cursor = Cursors.WaitCursor
        grdModelos.DataSource = Nothing
        Dim contArticulosCPrecio As Int32 = 0
        Dim dtModelosDistintos As New DataTable

        verModelosGenerales = objCliente.verModelosGenerales(idCliente)

        dtDatosModelos = objLB.verDetallesListaPreciosCliente(idListaBase, idCliente, listaVentasClientePrecioid,
                                                              todosArt, idListaPreciosVentas,
                                                              0)

        If verModelosGenerales = True Then
            dtListaModelosGenerales = objLB.verDetallesListaPreciosCliente(idListaBase, 0, 0,
                                                                           todosArt, idListaPreciosVentas,
                                                                           listaVentasClientePrecioid)
            If dtListaModelosGenerales.Rows.Count > 0 Then
                dtDatosModelos.Merge(dtListaModelosGenerales)

                dtModelosDistintos = dtDatosModelos.DefaultView.ToTable(True)
            Else
                dtModelosDistintos = dtDatosModelos
            End If
        Else
            dtModelosDistintos = dtDatosModelos
        End If

        If dtModelosDistintos.Rows.Count > 0 Then

            If (chkDescuentoIncluido.Checked) = True Then

                Dim dtDescuentoConfigurado As New DataTable
                Dim totalDescuento As Double = 0.0

                If estatusLB = "ACTIVA" Then
                    dtDescuentoConfigurado = objListaVBU.consultaConfiguracionDescuentoClienteLV(idListaPreciosVentas, idCliente)
                End If

                If estatusLB = "ACTIVA" And dtDescuentoConfigurado.Rows.Count > 0 Then
                    lblDescuentos.Visible = True
                    picConfDescuento.Visible = True
                    For Each dtRow As DataRow In dtDescuentoConfigurado.Rows
                        If CBool(dtRow.Item("cdlv_porcentaje")) = True Then
                            For Each dtModRow As DataRow In dtModelosDistintos.Rows
                                If CBool(dtModRow.Item("SeleccionArticulos").ToString) = False Then
                                    dtModRow.Item("Precio") = dtModRow.Item("Precio") - (dtModRow.Item("Precio") * (dtRow.Item("cdlv_cantidad") / 100))
                                End If
                            Next
                        Else
                            For Each dtModRow As DataRow In dtModelosDistintos.Rows
                                If CBool(dtModRow.Item("SeleccionArticulos").ToString) = False Then
                                    dtModRow.Item("Precio") = dtModRow.Item("Precio") - dtRow.Item("cdlv_cantidad")
                                End If
                            Next
                        End If
                    Next
                Else
                    Dim dtDatosDescuentos As New DataTable
                    Dim objClientesDDA As New Negocios.ClientesDatosBU
                    dtDatosDescuentos = objClientesDDA.Datos_TablaDescuentosCliente(idClienteFTC, 0)
                    For Each dtRow As DataRow In dtDatosDescuentos.Rows
                        If CBool(dtRow.Item("decl_descuentoenporcentaje")) = True Then
                            For Each dtModRow As DataRow In dtModelosDistintos.Rows
                                If CBool(dtModRow.Item("SeleccionArticulos").ToString) = False Then
                                    dtModRow.Item("Precio") = dtModRow.Item("Precio") - (dtModRow.Item("Precio") * (dtRow.Item("decl_cantidaddescuento") / 100))
                                End If
                            Next
                        Else
                            For Each dtModRow As DataRow In dtModelosDistintos.Rows
                                If CBool(dtModRow.Item("SeleccionArticulos").ToString) = False Then
                                    dtModRow.Item("Precio") = dtModRow.Item("Precio") - dtRow.Item("decl_cantidaddescuento")
                                End If
                            Next
                        End If
                    Next
                End If
            End If
            grdModelos.DataSource = dtModelosDistintos
            lblContLB.Text = dtModelosDistintos.Rows.Count.ToString("N0")
            For Each rowDt As DataRow In dtModelosDistintos.Rows
                If rowDt.Item("PrecioAnterior") > 0 Then
                    contArticulosCPrecio += 1
                End If
            Next
            formatosGrid()
            endEdit = False
        Else
            lblContLB.Text = "0"
        End If
    End Sub

    Public Sub formatosGrid()
        Dim contSeleccionArt As Int32 = 0
        With grdModelos.DisplayLayout.Bands(0)
            .Columns("lpbp_listapreciosbaseid").Hidden = True
            .Columns("lpbp_listapreciobaseproductoid").Hidden = True
            .Columns("pres_productoestiloid").Hidden = True
            .Columns("cole_coleccionid").Hidden = True
            .Columns("marc_marcaid").Hidden = True
            .Columns("piel_pielid").Hidden = True
            .Columns("color_colorid").Hidden = True
            .Columns("talla_tallaid").Hidden = True
            .Columns("pres_activo").Hidden = True
            .Columns("fami_familiaid").Hidden = True
            .Columns("linea_lineaid").Hidden = True
            .Columns("stpr_productoStatusId").Hidden = True
            .Columns("PrecioPrimero").Hidden = True
            .Columns("marc_decimales").Hidden = True
            .Columns("prod_descripcion").Hidden = True
            .Columns("pres_codSicy").Hidden = True
            .Columns("prod_descripcion").Hidden = True
            .Columns("prod_codigo").Header.Caption = "Modelo SAY"
            .Columns("prod_descripcion").Header.Caption = "Descripción"
            .Columns("cole_descripcion").Header.Caption = "Colección"
            .Columns("marc_descripcion").Header.Caption = "Marca"
            .Columns("piel_descripcion").Header.Caption = "Piel"
            .Columns("color_descripcion").Header.Caption = "Color"
            .Columns("talla_descripcion").Header.Caption = "Corrida"
            .Columns("pres_codSicy").Header.Caption = "SICY"
            .Columns("fami_descripcion").Header.Caption = "Familia"
            .Columns("linea_descripcion").Header.Caption = "Linea"
            .Columns("stpr_descripcion").Header.Caption = "Estatus"
            .Columns("precioBase").Header.Caption = "P. Base"
            .Columns("prod_modelo").Header.Caption = "Modelo SICY"
            .Columns("prod_codigo").CellActivation = Activation.NoEdit
            .Columns("prod_modelo").CellActivation = Activation.NoEdit
            .Columns("prod_descripcion").CellActivation = Activation.NoEdit
            .Columns("cole_descripcion").CellActivation = Activation.NoEdit
            .Columns("marc_descripcion").CellActivation = Activation.NoEdit
            .Columns("piel_descripcion").CellActivation = Activation.NoEdit
            .Columns("color_descripcion").CellActivation = Activation.NoEdit
            .Columns("talla_descripcion").CellActivation = Activation.NoEdit
            .Columns("pres_codSicy").CellActivation = Activation.NoEdit
            .Columns("fami_descripcion").CellActivation = Activation.NoEdit
            .Columns("linea_descripcion").CellActivation = Activation.NoEdit
            .Columns("stpr_descripcion").CellActivation = Activation.NoEdit
            .Columns("precioBase").CellActivation = Activation.NoEdit
            .Columns("prod_codigo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("talla_descripcion").CellAppearance.TextHAlign = HAlign.Right
            .Columns("precioBase").CellAppearance.TextHAlign = HAlign.Right
            .Columns("prod_modelo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("marc_descripcion").Header.VisiblePosition = 0
            .Columns("cole_descripcion").Header.VisiblePosition = 1
            .Columns("prod_codigo").Header.VisiblePosition = 2
            .Columns("prod_modelo").Header.VisiblePosition = 3
            .Columns("talla_descripcion").Header.VisiblePosition = 4
            .Columns("piel_descripcion").Header.VisiblePosition = 5
            .Columns("color_descripcion").Header.VisiblePosition = 6
            .Columns("fami_descripcion").Header.VisiblePosition = 7
            .Columns("linea_descripcion").Header.VisiblePosition = 8
            .Columns("stpr_descripcion").Header.VisiblePosition = 9
            .Columns("precioBase").MaskInput = "nnnn.nn"
        End With

        If accionPantalla = "CONSULTA" Then

        End If

        grdModelos.DisplayLayout.Bands(0).Columns.Add("Seleccion", "Seleccion")
        Dim colSeleccion As UltraGridColumn = grdModelos.DisplayLayout.Bands(0).Columns("Seleccion")
        colSeleccion.DefaultCellValue = False
        colSeleccion.Header.Caption = ""
        colSeleccion.Header.VisiblePosition = 0
        colSeleccion.Style = ColumnStyle.CheckBox
        colSeleccion.Width = 50
        If inactiva = True Then
            colSeleccion.CellActivation = Activation.NoEdit
        End If

        If accionPantalla = "CONSULTA" Then
            grdModelos.DisplayLayout.Bands(0).Columns("Seleccion").Hidden = True
        End If

        grdModelos.DisplayLayout.Bands(0).Columns.Add("Estado", "Estado")
        Dim colEstado As UltraGridColumn = grdModelos.DisplayLayout.Bands(0).Columns("Estado")
        colEstado.DefaultCellValue = False
        colEstado.CellAppearance.TextHAlign = HAlign.Center
        colEstado.Header.VisiblePosition = 1
        colEstado.Header.Caption = ""
        colEstado.CellActivation = Activation.NoEdit

        Dim colPrecioAntes As UltraGridColumn = grdModelos.DisplayLayout.Bands(0).Columns("PrecioAnterior")
        colPrecioAntes.MaskInput = "nnnn.nn"
        colPrecioAntes.CellAppearance.TextHAlign = HAlign.Right
        colPrecioAntes.Header.Caption = "P. Calculado"
        colPrecioAntes.FilterOperandStyle = FilterOperandStyle.Edit
        colPrecioAntes.CellActivation = Activation.NoEdit

        Dim colPrecio As UltraGridColumn = grdModelos.DisplayLayout.Bands(0).Columns("Precio")
        'If chkDescuentoIncluido.Checked = False Then
        '    colPrecio.MaskInput = "nnnn"
        'Else
        '    colPrecio.MaskInput = "nnnn.nn"
        'End If
        colPrecio.MaskInput = "nnnn.nn"
        colPrecio.Header.Caption = "*P. Final"
        colPrecio.CellAppearance.TextHAlign = HAlign.Right
        colPrecio.FilterOperandStyle = FilterOperandStyle.Edit
        If primerEstatus = 26 Or primerEstatus = 27 Or primerEstatus = 28 Or inactiva = True Then
            colPrecio.CellActivation = Activation.NoEdit
            grpOperaciones.Enabled = False
        End If

        Dim colPrecioParidad As UltraGridColumn = grdModelos.DisplayLayout.Bands(0).Columns("PrecioParidad")
        colPrecioParidad.MaskInput = "nnnn.nn"
        colPrecioParidad.CellAppearance.TextHAlign = HAlign.Right
        colPrecioParidad.Header.Caption = "P. Parid. c/Desc."
        colPrecioParidad.FilterOperandStyle = FilterOperandStyle.Edit
        colPrecioParidad.CellActivation = Activation.NoEdit

        Dim colPrecioCalcParidad As UltraGridColumn = grdModelos.DisplayLayout.Bands(0).Columns("PrecioParidadCalculado")
        colPrecioCalcParidad.MaskInput = "nnnn.nn"
        colPrecioCalcParidad.CellAppearance.TextHAlign = HAlign.Right
        colPrecioCalcParidad.Header.Caption = "P. Paridad Calc"
        colPrecioCalcParidad.FilterOperandStyle = FilterOperandStyle.Edit
        colPrecioCalcParidad.CellActivation = Activation.NoEdit


        Dim colSeleccionArticulos As UltraGridColumn = grdModelos.DisplayLayout.Bands(0).Columns("SeleccionArticulos")
        colSeleccionArticulos.DefaultCellValue = False
        colSeleccionArticulos.Header.Caption = "S. Articulos"
        colSeleccionArticulos.Style = ColumnStyle.CheckBox
        colSeleccionArticulos.Width = 50
        If primerEstatus = 26 Or primerEstatus = 27 Or primerEstatus = 28 Or inactiva = True Then
            colSeleccionArticulos.CellActivation = Activation.NoEdit
        End If

        grdModelos.DisplayLayout.Bands(0).Columns.Add("ArticulosGuardados", "ArticulosGuardados")
        Dim colArticulosGuardados As UltraGridColumn = grdModelos.DisplayLayout.Bands(0).Columns("ArticulosGuardados")
        colArticulosGuardados.DefaultCellValue = False
        colArticulosGuardados.Hidden = True

        For Each rowgr As UltraGridRow In grdModelos.Rows
            ''If rowgr.Cells("SeleccionArticulos").Value = False And idMoneda > 1 Then
            ''    rowgr.Cells("Precio").Value = rowgr.Cells("Precio").Value
            ''End If

            If rowgr.Cells("SeleccionArticulos").Value = False And idMoneda > 1 Then
                rowgr.Cells("PrecioParidad").Value = Math.Round(rowgr.Cells("Precio").Value / lblValorParidadPesos.Text, 1)
            End If

            If CBool(rowgr.Cells("SeleccionArticulos").Value) = True Then
                If accionPantalla <> "COPIAR" Then

                    rowgr.Cells("ArticulosGuardados").Value = 1
                    rowgr.Cells("SeleccionArticulos").Activation = Activation.NoEdit
                    rowgr.Cells("SeleccionArticulos").Appearance.BackColor = Color.LimeGreen

                Else
                    rowgr.Cells("SeleccionArticulos").Activation = Activation.AllowEdit
                    rowgr.Cells("SeleccionArticulos").Appearance.BackColor = Color.Gold
                End If
                contSeleccionArt += 1
            Else
                rowgr.Cells("ArticulosGuardados").Value = 0
                rowgr.Cells("SeleccionArticulos").Activation = Activation.AllowEdit
            End If
        Next
        lblContArtsGuardar.Text = contSeleccionArt.ToString("N0")
        lblPrecioModificado.Text = "0"
        lblSinPrecio.Text = "0"
        lblConPrecio.Text = "0"
        For Each rowGR As UltraGridRow In grdModelos.Rows
            rowGR.Cells("Seleccion").Value = False
            If rowGR.Cells("Precio").Value <> rowGR.Cells("PrecioAnterior").Value Then
                If rowGR.Cells("Precio").Value > 0 Then
                    rowGR.Cells("Estado").Appearance.BackColor = Color.Lime
                    rowGR.Cells("Estado").Value = "D"
                    If rowGR.Cells("Precio").Value < rowGR.Cells("precioBase").Value Then
                        rowGR.Cells("Precio").Appearance.ForeColor = Color.Red
                        rowGR.Cells("Precio").Appearance.FontData.Bold = DefaultableBoolean.True
                    End If
                    If CBool(rowGR.Cells("SeleccionArticulos").Value) = True Then
                        lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) + 1).ToString("N0")
                    End If
                ElseIf rowGR.Cells("Precio").Value = 0 Then
                    rowGR.Cells("Estado").Appearance.BackColor = Color.Red
                    rowGR.Cells("Estado").Value = "N"
                    If rowGR.Cells("Precio").Value < rowGR.Cells("precioBase").Value Then
                        rowGR.Cells("Precio").Appearance.ForeColor = Color.Red
                        rowGR.Cells("Precio").Appearance.FontData.Bold = DefaultableBoolean.True
                    End If
                    If CBool(rowGR.Cells("SeleccionArticulos").Value) = True Then
                        lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")
                    End If
                End If
            Else
                If rowGR.Cells("Precio").Value = 0 Then
                    rowGR.Cells("Estado").Appearance.BackColor = Color.Red
                    rowGR.Cells("Estado").Value = "N"
                    If CBool(rowGR.Cells("SeleccionArticulos").Value) = True Then
                        lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")
                    End If
                ElseIf rowGR.Cells("Precio").Value > 0 Then
                    rowGR.Cells("Estado").Appearance.BackColor = Color.DodgerBlue
                    rowGR.Cells("Estado").Value = "P"
                    If CBool(rowGR.Cells("SeleccionArticulos").Value) = True Then
                        lblConPrecio.Text = (CInt(lblConPrecio.Text) + 1).ToString("N0")
                    End If
                End If
            End If
        Next
        'esconde o se muestra
        If idMoneda > 1 Then
            For Each rowGR As UltraGridRow In grdModelos.Rows
                If rowGR.Cells("SeleccionArticulos").Value = False And idMoneda > 1 Then
                    rowGR.Cells("PrecioParidadCalculado").Value = Math.Round(rowGR.Cells("PrecioAnterior").Value / lblValorParidadPesos.Text, 1)
                End If
            Next
        Else
            colPrecioParidad.Hidden = True
            colPrecioCalcParidad.Hidden = True
        End If

        grdModelos.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdModelos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdModelos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdModelos.DisplayLayout.Override.RowSelectorWidth = 35
        grdModelos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdModelos.Rows(0).Selected = True
        grdModelos.DisplayLayout.Bands(0).Columns("Estado").Width = 30
        grdModelos.DisplayLayout.Bands(0).Columns("Seleccion").Width = 30
    End Sub

    Public Sub consultaincrementoCliente(ByVal idCliente As Int32)
        Dim objLCBU As New Negocios.ListaPreciosVentaClienteBU
        Dim dtIncrementoFleteIVA As New DataTable
        Dim dtDescuento As New DataTable
        Dim dtMoneda As New DataTable


        dtIncrementoFleteIVA = objLCBU.consultaIncrementoFacturarIVAFleteCliente(idCliente)
        dtDescuento = objLCBU.consultaDescuentoCliente(idCliente)
        If dtIncrementoFleteIVA.Rows.Count > 0 Then

            If dtIncrementoFleteIVA.Rows(0).Item("iccl_incrementopar_porcent").ToString <> "" Or dtIncrementoFleteIVA.Rows(0).Item("iccl_incrementopar_monto").ToString <> "" Then
                If CDbl(dtIncrementoFleteIVA.Rows(0).Item("iccl_incrementopar_porcent")) > 0 Then
                    'lblIncrementoPar.Text = dtIncrementoFleteIVA.Rows(0).Item("iccl_incrementopar_porcent").ToString
                    'lblSimboloIXP.Text = "%"
                    lblFacturacion.Text = dtIncrementoFleteIVA.Rows(0).Item("iccl_facturar").ToString
                    incremento = dtIncrementoFleteIVA.Rows(0).Item("iccl_incrementopar_porcent")
                    porcentaje = True
                ElseIf CDbl(dtIncrementoFleteIVA.Rows(0).Item("iccl_incrementopar_monto")) > 0 Then
                    'lblIncrementoPar.Text = dtIncrementoFleteIVA.Rows(0).Item("iccl_incrementopar_monto").ToString
                    'lblSimboloIXP.Text = "$"
                    lblFacturacion.Text = dtIncrementoFleteIVA.Rows(0).Item("iccl_facturar").ToString
                    incremento = dtIncrementoFleteIVA.Rows(0).Item("iccl_incrementopar_porcent")
                    porcentaje = False
                Else
                    lblFacturacion.Text = dtIncrementoFleteIVA.Rows(0).Item("iccl_facturar").ToString
                    incremento = 0
                    porcentaje = False
                End If
            Else
                lblFacturacion.Text = dtIncrementoFleteIVA.Rows(0).Item("iccl_facturar").ToString
                incremento = 0
                porcentaje = False
            End If
            lblFlete.Text = dtIncrementoFleteIVA.Rows(0).Item("tifl_nombre").ToString.Trim
            idFlete = dtIncrementoFleteIVA.Rows(0).Item("iccl_tipofleteid")
            lblIVA.Text = dtIncrementoFleteIVA.Rows(0).Item("tiva_nombre").ToString.Trim
            idIva = dtIncrementoFleteIVA.Rows(0).Item("iccl_tipoivaid")
            chkDescuentoIncluido.Checked = CBool(dtIncrementoFleteIVA.Rows(0).Item("iccl_calcularpreciocondescuento"))
        Else
            'lblIncrementoPar.Text = "0"
            lblSimboloIXP.Text = "%"
            lblFacturacion.Text = "0"
            incremento = "0"
            porcentaje = True
            lblFlete.Text = "---"
            idFlete = 0
            lblIVA.Text = "---"
            idIva = 0
        End If


        If dtDescuento.Rows(0).Item("DESCUENTO").ToString.Length > 0 Then
            lblDescuento.Text = CDbl(dtDescuento.Rows(0).Item("DESCUENTO")).ToString("N2")
        Else
            lblDescuento.Text = "0.0"
        End If

        If estatusLB = "ACTIVA" Then

            Dim objListaVBU As New Negocios.ListaVentasBU
            Dim dtDescuentoConfigurado As New DataTable
            Dim dtIvaFleteFacturacionConfigurado As New DataTable
            Dim totalDescuento As Double = 0.0

            dtDescuentoConfigurado = objListaVBU.consultaConfiguracionDescuentoClienteLV(idListaPreciosVentas, idCliente)
            dtIvaFleteFacturacionConfigurado = objListaVBU.consultaConfiguracionClienteLV(idListaPreciosVentas, idCliente)
            If dtDescuentoConfigurado.Rows.Count > 0 Or dtIvaFleteFacturacionConfigurado.Rows.Count > 0 Then
                picConfiguracion.Visible = True
            Else
                picConfiguracion.Visible = False
            End If

            If dtDescuentoConfigurado.Rows.Count > 0 Then
                For Each dtRow As DataRow In dtDescuentoConfigurado.Rows
                    totalDescuento = totalDescuento + dtRow.Item("cdlv_cantidad")
                Next
            End If

            If totalDescuento > 0 Then
                lblDescuento.Text = CDbl(totalDescuento).ToString("N2")
            End If

            If dtIvaFleteFacturacionConfigurado.Rows.Count > 0 Then

                If dtIvaFleteFacturacionConfigurado.Rows(0).Item("ccla_tipofleteid").ToString.Trim <> "" Then
                    lblFlete.Text = dtIvaFleteFacturacionConfigurado.Rows(0).Item("tifl_nombre").ToString.Trim
                    idFlete = dtIvaFleteFacturacionConfigurado.Rows(0).Item("ccla_tipofleteid")
                End If

                If dtIvaFleteFacturacionConfigurado.Rows(0).Item("ccla_tipoivaid").ToString.Trim <> "" Then
                    lblIVA.Text = dtIvaFleteFacturacionConfigurado.Rows(0).Item("tiva_nombre").ToString.Trim
                    idIva = dtIvaFleteFacturacionConfigurado.Rows(0).Item("ccla_tipoivaid")
                End If

                If dtIvaFleteFacturacionConfigurado.Rows(0).Item("ccla_facturar").ToString.Trim <> "" Then
                    lblFacturacion.Text = (CDbl(dtIvaFleteFacturacionConfigurado.Rows(0).Item("ccla_facturar"))).ToString("N2")
                End If

            End If
        Else
            picConfiguracion.Visible = False
        End If

        dtMoneda = objLCBU.consultaMonedaCliente(idCliente)

        If dtMoneda.Rows.Count > 0 Then

            idMoneda = dtMoneda.Rows(0).Item("mone_monedaid")

            lblNombreMoneda.Text = dtMoneda.Rows(0).Item("mone_nombre").ToString.Trim
            If accionPantalla = "ALTA" Then
                lblMonedaActual.Text = dtMoneda.Rows(0).Item("mone_nombre").ToString.Trim
                txtParidadActual.Text = (CDbl(dtMoneda.Rows(0).Item("paca_paridadpesos"))).ToString("N2")
            End If
            lblValorParidadPesos.Text = (CDbl(dtMoneda.Rows(0).Item("paca_paridadpesos"))).ToString("N2")
            lblSimboloMoneda.Text = dtMoneda.Rows(0).Item("mone_simbolo").ToString
            lblFechaAltaParidad.Text = dtMoneda.Rows(0).Item("paca_fechacreacion").ToString
        Else
            idMoneda = 1
            lblNombreMoneda.Text = "PESOS"
            If accionPantalla = "ALTA" Then
                lblMonedaActual.Text = "PESOS"
                txtParidadActual.Text = "1"
            End If
            lblValorParidadPesos.Text = "1"
            lblSimboloMoneda.Text = "$"
            lblFechaAltaParidad.Text = ""
        End If

    End Sub

    Public Sub consultaDatosListaBase(ByVal idListaBase As Int32)
        Dim objLBBU As New Negocios.ListaBaseBU
        Dim dtDatosListaBase As New DataTable
        dtDatosListaBase = objLBBU.verListaPBase(idListaBase)
        If dtDatosListaBase.Rows.Count > 0 Then
            If dtDatosListaBase.Rows(0).Item("lpba_estatus") = 1 Then
                lblEstatus.Text = "ACTIVA"
                lblEstatus.ForeColor = Color.DarkOrange
            ElseIf dtDatosListaBase.Rows(0).Item("lpba_estatus") = 2 Then
                lblEstatus.Text = "AUTORIZADA"
                lblEstatus.ForeColor = Color.LimeGreen
            Else
                lblEstatus.Text = "INACTIVA"
                lblEstatus.ForeColor = Color.Red
            End If
        End If
    End Sub

    Public Sub asignarPrecios()
        If txtPrecioMultiple.Value > 0 Then
            Dim contFilasCambio As Int32 = 0
            For Each rowGR As UltraGridRow In grdModelos.Rows.GetFilteredInNonGroupByRows
                If CBool(rowGR.Cells("Seleccion").Text) = True Then
                    contFilasCambio += 1
                End If
            Next
            If contFilasCambio > 0 Then
                Dim objCaptcha As New Tools.frmCaptcha
                objCaptcha.mensaje = "Registros por actualizar: " + contFilasCambio.ToString("N0")

                If objCaptcha.ShowDialog = Windows.Forms.DialogResult.OK Then
                    For Each rowLB As UltraGridRow In grdModelos.Rows.GetFilteredInNonGroupByRows
                        If CBool(rowLB.Cells("Seleccion").Text) = True Then
                            rowLB.Cells("precio").Value = txtPrecioMultiple.Value
                        End If
                    Next
                    Dim contadorPrecio As Int32 = 0
                    For Each rowGR As UltraGridRow In grdModelos.Rows
                        If rowGR.Cells("Precio").Value <> rowGR.Cells("PrecioAnterior").Value Then
                            contadorPrecio += 1
                        End If
                    Next
                    lblPrecioModificado.Text = contadorPrecio.ToString("N0")
                    chkSeleccionarFiltrados.Checked = False
                    For Each rowGr As UltraGridRow In grdModelos.Rows
                        rowGr.Cells("Seleccion").Value = False
                    Next
                    lblTotalSeleccionados.Text = "0"
                End If
            Else
                MsgBox("Debe seleccionar al menos un registro", MsgBoxStyle.Information, "Atención")
            End If
        End If
    End Sub

    Public Sub asignarCalcularPrecios()
        If txtCantidadMultiple.Value > 0 Then
            Dim contFilasCambio As Int32 = 0
            For Each rowGR As UltraGridRow In grdModelos.Rows.GetFilteredInNonGroupByRows
                If CBool(rowGR.Cells("Seleccion").Text) = True Then
                    contFilasCambio += 1
                End If
            Next
            If contFilasCambio > 0 Then
                Dim objCaptcha As New Tools.frmCaptcha
                objCaptcha.mensaje = "Registros por actualizar: " + contFilasCambio.ToString("N0")

                If objCaptcha.ShowDialog = Windows.Forms.DialogResult.OK Then
                    For Each rowLB As UltraGridRow In grdModelos.Rows.GetFilteredInNonGroupByRows
                        If CBool(rowLB.Cells("Seleccion").Text) = True Then
                            Dim valorCalculado As Double = 0
                            If grdDatosConf.Checked = True Then
                                If rdoPorcentaje.Checked = True Then
                                    valorCalculado = rowLB.Cells("precio").Value + (rowLB.Cells("precio").Value * (txtCantidadMultiple.Value / 100))
                                ElseIf rdoCantidad.Checked = True Then
                                    valorCalculado = rowLB.Cells("precio").Value + txtCantidadMultiple.Value
                                End If
                            ElseIf rdoRestar.Checked = True Then
                                If rdoPorcentaje.Checked = True Then
                                    valorCalculado = rowLB.Cells("precio").Value - (rowLB.Cells("precio").Value * (txtCantidadMultiple.Value / 100))
                                ElseIf rdoCantidad.Checked = True Then
                                    valorCalculado = rowLB.Cells("precio").Value - txtCantidadMultiple.Value
                                End If
                            End If
                            If valorCalculado > 0 Then
                                rowLB.Cells("Seleccion").Value = False
                                rowLB.Cells("precio").Value = valorCalculado
                            End If
                        End If
                    Next

                    Dim contadorPrecio As Int32 = 0
                    For Each rowGR As UltraGridRow In grdModelos.Rows
                        If rowGR.Cells("Precio").Value <> rowGR.Cells("PrecioAnterior").Value Then
                            contadorPrecio += 1
                        End If
                    Next
                    lblPrecioModificado.Text = contadorPrecio.ToString("N0")
                    Dim contseleccionados As Int32
                    For Each rowGr As UltraGridRow In grdModelos.Rows
                        If rowGr.Cells("Seleccion").Value = True Then
                            contseleccionados += 1
                        End If
                    Next
                    If contseleccionados > 0 Then
                        MsgBox("No se modificaron algunos de los valores debido a que el cálculo resultaba en cero.", MsgBoxStyle.Information, "")
                        lblTotalSeleccionados.Text = contseleccionados.ToString("N0")
                    Else
                        chkSeleccionarFiltrados.Checked = False
                        lblTotalSeleccionados.Text = "0"
                    End If

                End If
            Else
                MsgBox("Debe seleccionar al menos un registro", MsgBoxStyle.Information, "Atención")
            End If
        End If
    End Sub

    Public Function validarDatosGuardar() As Boolean
        If cmbListaVentas.SelectedIndex <= 0 Then

            If cmbListaVentas.SelectedIndex = 0 Then
                lblListaVentas.ForeColor = Color.Red
            Else
                lblListaVentas.ForeColor = Color.Black
            End If
        End If
        Return True
    End Function

    Public Sub guardarListaPreciosCliente()
        Dim objLPCLBU As New Negocios.ListaPreciosVentaClienteBU
        Dim dtListaPreciosCliente As New DataTable
        Dim dtDatosListaPreciosCLiente As New DataTable
        Me.Cursor = Cursors.WaitCursor
        Dim dtDatosListaVentasClienteReg As New DataTable
        Dim esalta As Boolean
        Dim idLVCP As Int32 = 0
        Dim idEstatusLVCP As Int32 = 0

        Dim dtLitasCopias As New DataTable

        If accionPantalla = "ALTA" Or accionPantalla = "COPIAR" Then
            esalta = True
            idLVCP = 0
        ElseIf accionPantalla = "EDITAR" Then
            esalta = False
            idLVCP = idListaVentasClientePrecio
            If cmbEstatusLVCP.SelectedIndex > 0 Then
                idEstatusLVCP = cmbEstatusLVCP.SelectedValue
            End If
        End If
        Dim fechaParidad As String
        If lblFechaAltaParidad.Text <> "" Then
            fechaParidad = CDate(lblFechaAltaParidad.Text).ToShortDateString
        Else
            fechaParidad = ""
        End If
        Dim incoterm As Int32 = 0
        If tipoClienteId = 2 Then
            incoterm = cmbIncoterms.SelectedValue
        End If

        Dim porcentajeBit As Boolean = True
        If lblSimboloIXP.Text = "$" Then
            porcentajeBit = False
        End If
        Dim valorParidad As String = ""
        If cmbEstatusLVCP.SelectedValue = "25" Then
            valorParidad = lblValorParidadPesos.Text
        Else
            valorParidad = txtParidadActual.Text
        End If

        dtDatosListaVentasClienteReg = objLPCLBU.guardarListaVentasClientePrecio(idLVCP, idListaVentasCliente, txtDescripcionLista.Text, dttInicioVigenciaLVC.Value.ToShortDateString,
                                                                                 dttFinVigenciaLVC.Value.ToShortDateString, incoterm, valorParidad, fechaParidad, lblDescuento.Text,
                                                                                 lblFacturacion.Text, idFlete, idIva, idMoneda, 0, esalta, idEstatusLVCP, lblIncrementoPar.Text, porcentajeBit, chkLigarListaOriginal.Checked)
        If dtDatosListaVentasClienteReg.Rows.Count > 0 Then
            If CInt(dtDatosListaVentasClienteReg.Rows(0).Item("idLVCP")) > 0 Then
                idListaVentasClientePrecio = CInt(dtDatosListaVentasClienteReg.Rows(0).Item("idLVCP"))
            End If
        End If

        If idListaVentasClientePrecio > 0 Then

            dtLitasCopias = objLPCLBU.consultaListaPreciosCopia(idListaVentasClientePrecio)

            For Each rowGR As UltraGridRow In grdModelos.Rows
                If CBool(rowGR.Cells("SeleccionArticulos").Value) = True And (rowGR.Cells("Precio").Value <> rowGR.Cells("PrecioPrimero").Value Or accionPantalla = "COPIAR") Then
                    If idMoneda > 1 Then
                        objLPCLBU.guardarDatosListaPreciosClienteProductos(idListaVentasClientePrecio, rowGR.Cells("pres_productoestiloid").Value, rowGR.Cells("precioBase").Value, rowGR.Cells("PrecioAnterior").Value, rowGR.Cells("Precio").Value, rowGR.Cells("PrecioParidad").Value, rowGR.Cells("PrecioParidadCalculado").Value, idListaPreciosVentas, idMoneda)
                    Else
                        objLPCLBU.guardarDatosListaPreciosClienteProductos(idListaVentasClientePrecio, rowGR.Cells("pres_productoestiloid").Value, rowGR.Cells("precioBase").Value, rowGR.Cells("PrecioAnterior").Value, rowGR.Cells("Precio").Value, 0, 0, idListaPreciosVentas, idMoneda)

                        If dtLitasCopias.Rows.Count > 0 Then
                            Dim precioCopia As Double = 0
                            Dim precioCopiaDesc As Double = 0
                            For Each rowDt As DataRow In dtLitasCopias.Rows
                                If CBool(rowDt.Item("lpvt_porcentaje")) = True Then
                                    'midpointing
                                    precioCopia = Math.Round(rowGR.Cells("precioBase").Value + (rowGR.Cells("precioBase").Value * (rowDt.Item("lpvt_incrementoporpar") / 100)), MidpointRounding.AwayFromZero)
                                    precioCopiaDesc = precioCopia
                                Else
                                    precioCopia = rowGR.Cells("precioBase").Value + rowDt.Item("lpvt_incrementoporpar")
                                    precioCopiaDesc = precioCopia
                                End If
                                If CBool(rowDt.Item("iccl_calcularpreciocondescuento")) = True Then
                                    Dim dtDatosDescuentos As New DataTable
                                    Dim objClientesDDA As New Negocios.ClientesDatosBU
                                    dtDatosDescuentos = objClientesDDA.Datos_TablaDescuentosCliente(rowDt.Item("clie_clienteid"), 0)
                                    For Each dtRow As DataRow In dtDatosDescuentos.Rows
                                        If CBool(dtRow.Item("decl_descuentoenporcentaje")) = True Then
                                            precioCopiaDesc = precioCopia - (precioCopia * (dtRow.Item("decl_cantidaddescuento") / 100))
                                        Else
                                            precioCopiaDesc = precioCopia - dtRow.Item("decl_cantidaddescuento")
                                        End If
                                    Next
                                End If
                                objLPCLBU.guardarDatosListaPreciosClienteProductos(rowDt.Item("lvcp_listaventasclienteprecioid"), rowGR.Cells("pres_productoestiloid").Value, rowGR.Cells("precioBase").Value, precioCopia, precioCopiaDesc, 0, 0, rowDt.Item("lpvt_listaprecioventaid"), idMoneda)
                            Next
                        End If



                    End If
                End If
            Next
            For Each rowgr As UltraGridRow In grdModelos.Rows
                If CBool(rowgr.Cells("SeleccionArticulos").Value) = True Then
                    rowgr.Cells("ArticulosGuardados").Value = 1
                    rowgr.Cells("SeleccionArticulos").Activation = Activation.NoEdit
                Else
                    rowgr.Cells("ArticulosGuardados").Value = 0
                    rowgr.Cells("SeleccionArticulos").Activation = Activation.AllowEdit
                End If
            Next
            If cmbEstatusLVCP.SelectedValue = "25" Then
                llenarComboEstatus("25, 26, 27")
                cmbEstatusLVCP.SelectedValue = "25"
            ElseIf cmbEstatusLVCP.SelectedValue = "26" Then
                llenarComboEstatus("26, 28")
                cmbEstatusLVCP.SelectedValue = "26"
            ElseIf cmbEstatusLVCP.SelectedValue = "27" Or cmbEstatusLVCP.SelectedValue = "28" Then
                Dim valorIdenEst As String = cmbEstatusLVCP.SelectedValue
                llenarComboEstatus("")
                cmbEstatusLVCP.SelectedValue = valorIdenEst
                cmbEstatusLVCP.Enabled = False
                grpDatos.Enabled = False
                btnGuardar.Enabled = False
                lblGuardar.Enabled = False
                grpOperaciones.Enabled = False
                btnRecalcular.Enabled = False
                lblRecalcular.Enabled = False
            End If
        Else
            MsgBox("Sin Registro.")
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Public Function valiarVacios() As Boolean
        Dim contadorSeleccionArt As Int32 = 0
        For Each rowGR As UltraGridRow In grdModelos.Rows
            If CBool(rowGR.Cells("SeleccionArticulos").Value) = True Then
                contadorSeleccionArt += 1
            End If
        Next
        If contadorSeleccionArt = 0 Or (cmbIncoterms.SelectedIndex <= 0 And tipoClienteId = 2) Or txtDescripcionLista.Text = "" Or cmbEstatusLVCP.SelectedIndex <= 0 Then
            If cmbIncoterms.SelectedIndex <= 0 And tipoClienteId = 2 Then
                lblIncoterms.ForeColor = Color.Red
            Else
                lblIncoterms.ForeColor = Color.Black
            End If

            If txtDescripcionLista.Text = "" Then
                lblDescripcionLista.ForeColor = Color.Red
            Else
                lblDescripcionLista.ForeColor = Color.Black
            End If

            If cmbEstatusLVCP.SelectedIndex <= 0 Then
                lblEstatusLP.ForeColor = Color.Red
            Else
                lblEstatusLP.ForeColor = Color.Black
            End If

            If contadorSeleccionArt = 0 Then
                MsgBox("Seleccione al menos un modelo.", MsgBoxStyle.Information, "")
            End If


            Return False
        Else
            lblIncoterms.ForeColor = Color.Black
            lblDescripcionLista.ForeColor = Color.Black
            lblEstatusLP.ForeColor = Color.Black
        End If
        Return True
    End Function

    Public Sub quitarArticulo(ByVal productoestiloid As Int32)
        Dim objLCBU As New Negocios.ListaPreciosVentaClienteBU
        Dim dtLitasCopias As New DataTable
        dtLitasCopias = objLCBU.consultaListaPreciosCopia(idListaVentasClientePrecio)
        objLCBU.inactivarArticuloListaCliente(idListaVentasClientePrecio, productoestiloid)
        For Each rowDt As DataRow In dtLitasCopias.Rows
            objLCBU.inactivarArticuloListaCliente(rowDt.Item("lvcp_listaventasclienteprecioid"), productoestiloid)
        Next
    End Sub

    Public Sub verModelosListaPrecioCliente(ByVal ListaClienteid As Int32)
        If ListaClienteid > 0 Then
            Dim objLCBU As New Negocios.ListaPreciosVentaClienteBU
            Dim dtDatosListaPreciosCLiente As New DataTable
            'Dim contListasRelacionadas As Int32 = 0
            Dim dtListaModelos As New DataTable

            dtDatosListaPreciosCLiente = objLCBU.consultaListaPreciosClienteExiste(ListaClienteid)

            If dtDatosListaPreciosCLiente.Rows.Count > 0 Then
                contConfiguracion = objLCBU.consultaTotalRegistroListaClienteProducto(ListaClienteid)
            Else
                grdModelos.DataSource = Nothing
                MsgBox("El cliente no tiene una lista de ventas asignada.")
                Me.Close()
            End If
        End If
    End Sub

    Public Sub abrirConfiguracionLP()
        Try
            Dim objLPCBU As New Negocios.ListaPreciosVentaClienteBU
            Dim objLVBU As New Negocios.ListaVentasBU
            Dim objListaVentas As New AltaConfiguracionListaVentas
            Dim dtIdListaVentas As New DataTable
            Dim dtDatosListaVentas As New DataTable
            dtDatosListaVentas = objLVBU.consutaListaVentasDetalle(idListaPreciosVentas)
            objListaVentas.idListaBase = idListaBase
            objListaVentas.idListaVentas = idListaPreciosVentas
            objListaVentas.accionPantalla = "CONSULTA"
            objListaVentas.codigoLB = dtDatosListaVentas.Rows(0).Item("lpba_codigolistabase").ToString
            objListaVentas.nombreLista = dtDatosListaVentas.Rows(0).Item("lpvt_descripcion")
            objListaVentas.estatusListaid = dtDatosListaVentas.Rows(0).Item("lpba_estatus")
            If dtDatosListaVentas.Rows(0).Item("lpba_estatus") = "1" Then
                objListaVentas.estatusListaCad = "ACTIVA"
            ElseIf dtDatosListaVentas.Rows(0).Item("lpba_estatus") = "2" Then
                objListaVentas.estatusListaCad = "AUTORIZADA"
            Else
                objListaVentas.estatusListaCad = "INACTIVA"
            End If
            objListaVentas.vigenciaInicio = dtDatosListaVentas.Rows(0).Item("lpvt_vigenciainicio")
            objListaVentas.vigenciaFin = dtDatosListaVentas.Rows(0).Item("lpvt_vigenciafin")
            objListaVentas.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub llenarEncabezadoConfiguracion(ByVal idListaVentasPrecioClienteEncabezado As Int32)
        Dim objLVCP As New Negocios.ListaPreciosVentaClienteBU
        Dim dtDatosEncabezado As New DataTable
        dtDatosEncabezado = objLVCP.datosListaVentasPrecioClienteEncabezado(idListaVentasPrecioClienteEncabezado)
        If dtDatosEncabezado.Rows.Count > 0 Then
            txtDescripcionLista.Text = dtDatosEncabezado.Rows(0).Item("lvcp_descripcion").ToString.Trim
            If accionPantalla <> "COPIAR" Then
                Dim COSA As String = CDate(CDate(dtDatosEncabezado.Rows(0).Item("lvcp_vigenciainicio").ToString))
                Dim COSADOS As String = dttInicioVigenciaLVC.MinDate
                dttInicioVigenciaLVC.Value = CDate(dtDatosEncabezado.Rows(0).Item("lvcp_vigenciainicio").ToString)
                dttFinVigenciaLVC.Value = dtDatosEncabezado.Rows(0).Item("lvcp_vigenciafin").ToString
                '''''------24/09/2015 AVV - Cambio solicitado por Eli, poder ampliar la vigencia de algunas listas a una
                'fecha superior al fin de la lista base (sólo para algunos clientes, TI actualiza la fecha de fin de vigencia en 
                'bd directamente pero para poder consultarla se programa esto pues anteriormente al superar el maxDate 
                'del control de fin de vigencia marca error

                '28/03/2017 se quitó la restricción de fechas para la lista de precios cliente, ya que eli solicitó que así se para poder
                'crear las listas con los rangos de forma libre.
                '
                'If CDate(fechaMax).ToShortDateString < CDate(dttFinVigenciaLVC.Value.ToShortDateString) Then
                '    dttFinVigenciaLVC.Enabled = False
                'Else
                '    dttFinVigenciaLVC.Enabled = True
                '    dttFinVigenciaLVC.MaxDate = CDate(fechaMax).ToShortDateString
                'End If
                '''' fin 28/03/2017 
                ''''Fin 24/09/2015-----
            End If
            If dtDatosEncabezado.Rows(0).Item("lvcp_incotermsid").ToString <> "" And tipoClienteId = 2 Then
                cmbIncoterms.SelectedValue = dtDatosEncabezado.Rows(0).Item("lvcp_incotermsid").ToString
            End If
            lblDescuento.Text = CDbl(dtDatosEncabezado.Rows(0).Item("lvcp_descuento")).ToString("N2")
            lblFacturacion.Text = CDbl(dtDatosEncabezado.Rows(0).Item("lvcp_facturacion")).ToString("N2")
            lblFlete.Text = dtDatosEncabezado.Rows(0).Item("tifl_nombre").ToString.Trim
            lblIVA.Text = dtDatosEncabezado.Rows(0).Item("tiva_nombre").ToString.Trim
            lblMonedaActual.Text = dtDatosEncabezado.Rows(0).Item("mone_nombre").ToString.Trim
            idMoneda = dtDatosEncabezado.Rows(0).Item("lvcp_monedaid").ToString
            idFlete = dtDatosEncabezado.Rows(0).Item("lvcp_fleteid").ToString
            idIva = dtDatosEncabezado.Rows(0).Item("lvcp_ivaid").ToString
            txtUsuarioModifico.Text = dtDatosEncabezado.Rows(0).Item("user_username").ToString.Trim
            txtParidadActual.Text = dtDatosEncabezado.Rows(0).Item("lvcp_paridad").ToString
            primerEstatus = CInt(dtDatosEncabezado.Rows(0).Item("lvcp_estatusid"))
            dttUltimaModificacion.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
            dttUltimaModificacion.Value = dtDatosEncabezado.Rows(0).Item("fechamodifico").ToString
            If txtParidadActual.Text = lblValorParidadPesos.Text Then
                grpMovimientoParidadOLoriginal.Enabled = False
            End If
            'If idMoneda = 1 Then
            '    grpParidad.Visible = False
            'End If
            If dtDatosEncabezado.Rows(0).Item("lvcp_estatusid").ToString = "25" Then
                llenarComboEstatus("25, 26, 27")
                cmbEstatusLVCP.SelectedValue = dtDatosEncabezado.Rows(0).Item("lvcp_estatusid").ToString
            ElseIf dtDatosEncabezado.Rows(0).Item("lvcp_estatusid").ToString = "26" Then
                llenarComboEstatus("26, 28")
                cmbEstatusLVCP.SelectedValue = dtDatosEncabezado.Rows(0).Item("lvcp_estatusid").ToString
            ElseIf dtDatosEncabezado.Rows(0).Item("lvcp_estatusid").ToString = "27" Or dtDatosEncabezado.Rows(0).Item("lvcp_estatusid").ToString = "28" Then
                llenarComboEstatus("")
                cmbEstatusLVCP.SelectedValue = dtDatosEncabezado.Rows(0).Item("lvcp_estatusid").ToString
                cmbEstatusLVCP.Enabled = False
                grpDatos.Enabled = False
                btnGuardar.Enabled = False
                lblGuardar.Enabled = False
                grpOperaciones.Enabled = False
                btnRecalcular.Enabled = False
                lblRecalcular.Enabled = False
            End If
            If dtDatosEncabezado.Rows(0).Item("lvcp_listaventasclienteprecioid_original").ToString() <> "" Then
                grpMovimientoParidadOLoriginal.Text = "Lista de Precios Original"
                grpMovimientoParidadOLoriginal.Visible = True
                grpMovimientoParidadOLoriginal.Enabled = True
                chkLigarListaOriginal.Visible = True
                Label15.Visible = False
                lblNombreMoneda.Visible = False
                lblFechaAltaParidad.Visible = False
                Label20.Visible = False

                lblSimboloMoneda.Visible = False
                Label17.Visible = False
                Label35.Visible = False
                lblValorParidadPesos.Visible = False
                btnRecalcular.Visible = False
                lblRecalcular.Visible = False
                lblListadePreciosOriginal.Visible = True
                Dim objLvBU As New Negocios.ListaPreciosVentaClienteBU
                Dim dt As New DataTable
                lblListadePreciosOriginal.Text = objLvBU.consultaNombreCortoListaCopia(dtDatosEncabezado.Rows(0).Item("lvcp_listaventasclienteprecioid_original"))

                chkLigarListaOriginal.Checked = CBool(dtDatosEncabezado.Rows(0).Item("lvcp_ligarlistaoriginal"))
            Else
                lblListadePreciosOriginal.Visible = False
                chkLigarListaOriginal.Visible = False
            End If

        End If
    End Sub

    'Public Sub verDescuentosClientes()
    '    Dim objClientesDDA As New Negocios.ClientesDatosBU
    '    If (chkDescuentoIncluido.Checked) = True Then
    '        Dim dtDatosDescuentos As New DataTable
    '        dtDatosDescuentos = objClientesDDA.Datos_TablaDescuentosCliente(idClienteFTC, 0)
    '        For Each dtRow As DataRow In dtDatosDescuentos.Rows
    '            If CBool(dtRow.Item("decl_descuentoenporcentaje")) = True Then
    '                For Each grRow As UltraGridRow In grdModelos.Rows
    '                    grRow.Cells("Precio").Value = grRow.Cells("Precio").Value - (grRow.Cells("Precio").Value * (dtRow.Item("decl_cantidaddescuento") / 100))
    '                    Dim colPrecio As UltraGridColumn = grdModelos.DisplayLayout.Bands(0).Columns("Precio")
    '                    colPrecio.MaskInput = "nnnn.nn"
    '                Next
    '            Else
    '                For Each grRow As UltraGridRow In grdModelos.Rows
    '                    grRow.Cells("Precio").Value = grRow.Cells("Precio").Value - dtRow.Item("decl_cantidaddescuento")
    '                Next
    '            End If
    '        Next
    '    Else
    '        llenarTablaModelos(idListaBase, idClienteFTC, idListaVentasClientePrecio, 0)
    '    End If
    'End Sub

    'consultaLimiteFechaListasVentasCliente
    Public Function validarVigenciaComparar() As Boolean
        Dim objLPVC As New Negocios.ListaPreciosVentaClienteBU
        Dim dtfechaMax As New DataTable
        If accionPantalla = "ALTA" Or accionPantalla = "COPIA" Then
            dtfechaMax = objLPVC.consultaLimiteFechaListasVentasClienteLB(idClienteFTC, idListaBase, idListaVentasClientePrecio)
        Else
            dtfechaMax = objLPVC.consultaLimiteFechaListasVentasClienteLB(idClienteFTC, idListaBase, idListaVentasClientePrecio)
        End If

        If dtfechaMax.Rows.Count > 0 Then
            Dim FechaMaxima As String, FechaMinima As String

            If dtfechaMax.Rows(0).Item(0).ToString <> "" And dtfechaMax.Rows(1).Item(0).ToString <> "" Then
                FechaMaxima = CDate(dtfechaMax.Rows(0).Item(0).ToString).ToShortDateString
                FechaMinima = CDate(dtfechaMax.Rows(1).Item(0).ToString).ToShortDateString

                If (CDate(dttInicioVigenciaLVC.Value.ToShortDateString) <= CDate(FechaMinima) And CDate(dttFinVigenciaLVC.Value.ToShortDateString) <= CDate(FechaMinima)) Or (CDate(dttInicioVigenciaLVC.Value.ToShortDateString) >= CDate(FechaMaxima) And CDate(dttFinVigenciaLVC.Value.ToShortDateString) >= CDate(FechaMaxima)) Then
                    lblInicioVigenciaLV.ForeColor = Color.Black
                    Return True
                Else
                    lblInicioVigenciaLV.ForeColor = Color.Red
                    Return False
                End If
            End If
        End If
        lblFinVigenciaLV.ForeColor = Color.Black
        Return True
    End Function

    Public Function validarVigencia() As Boolean
        If dttFinVigenciaLVC.Value < dttInicioVigenciaLVC.Value Then
            lblFinVigenciaLV.ForeColor = Color.Red
            Return False
        End If

        lblFinVigenciaLV.ForeColor = Color.Black
        Return True
    End Function

    Public Function validarListasAceptadas() As Boolean
        Dim objLBBU As New Negocios.ListaPreciosVentaClienteBU
        Dim contListasAceptadas As Int32 = 0
        If primerEstatus <> 26 And cmbEstatusLVCP.SelectedValue = 26 Then
            contListasAceptadas = objLBBU.consultaValidaLVCPAceptadas(idListaVentasCliente)
            If contListasAceptadas >= 2 Then
                Return False
            End If
        End If
        Return True
    End Function

    Public Function aceptarCambiosParidad() As Boolean
        If primerEstatus = 25 Then
            If idMoneda > 1 And txtParidadActual.Text <> lblValorParidadPesos.Text Then
                Dim objMensaje As New Tools.ConfirmarForm
                objMensaje.mensaje = "Si guarda los cambios la paridad se actualizará para todos los artículos en esta lista de precios de cliente. ¿Desea continuar?"
                Dim resultado As DialogResult = objMensaje.ShowDialog
                If resultado = Windows.Forms.DialogResult.OK Then
                    If cmbEstatusLVCP.SelectedValue = 25 Then
                        recalcularPreciosParidad()
                    End If
                ElseIf resultado = Windows.Forms.DialogResult.Cancel Then
                    Return False
                End If
            End If
        End If

        Return True
    End Function

    Public Sub recalcularPreciosParidad()
        For Each rowGrd As UltraGridRow In grdModelos.Rows
            rowGrd.Cells("PrecioParidad").Value = Math.Round(rowGrd.Cells("Precio").Value / lblValorParidadPesos.Text, 1)
            rowGrd.Cells("PrecioParidadCalculado").Value = Math.Round(rowGrd.Cells("PrecioAnterior").Value / lblValorParidadPesos.Text, 1)
        Next
    End Sub

    Public Sub llenarDatosInicio()
        Me.Cursor = Cursors.WaitCursor
        If ftc = False Then
            Me.Top = 0
            Me.Left = 0
        End If
        fechaInicioListaBase = CDate(fechaMin).ToShortDateString
        fechaFinListaBase = CDate(fechaMax).ToShortDateString

        lblMensajeSinListaVentas.Text = ""
        lblContLB.Text = "0"
        txtListaBase.Text = nombreListaBase
        txtListaDeVentas.Text = nombreListaPreciosVentas
        txtNombreCliente.Text = nombreCliente

        '28/03/2017 se documentó la restricción de fechas, eli solicitó el cambio
        'dttInicioVigenciaLVC.MinDate = CDate(fechaMin).ToShortDateString
        'dttInicioVigenciaLVC.MaxDate = CDate(fechaMax).ToShortDateString
        'dttFinVigenciaLVC.MinDate = CDate(fechaMin).ToShortDateString
        'fin 28/03/2017

        ' dttFinVigenciaLVC.Enabled = True
        'dttInicioVigenciaLVC.Enabled = True
        '24/09/2015 linea comentada para ampliar vigencia
        '''''------24/09/2015 AVV - Cambio solicitado por Eli, poder ampliar la vigencia de algunas listas a una
        'fecha superior al fin de la lista base (sólo para algunos clientes, TI actualiza la fecha de fin de vigencia en 
        'bd directamente pero para poder consultarla se programa esto pues anteriormente al superar el maxDate 
        'del control de fin de vigencia marca error

        '28/03/2017
        'If accionPantalla = "ALTA" Then
        '    dttFinVigenciaLVC.MaxDate = CDate(fechaMax).ToShortDateString
        'End If
        '28/03/2017


        'es para saber el estatus de la lista base que se seleccionó
        lblIncrementoPar.Text = CDbl(incrementoListaVentas).ToString("N0")
        lblEstatus.Text = estatusLB
        If estatusLB = "ACTIVA" Then
            lblEstatus.ForeColor = Color.DarkOrange
        ElseIf estatusLB = "AUTORIZADA" Then
            lblEstatus.ForeColor = Color.LimeGreen
        Else
            lblEstatus.Text = "INACTIVA"
            lblEstatus.ForeColor = Color.Red
        End If

        llenarComboIncoterms()
        If idClienteFTC > 0 Then
            consultaincrementoCliente(idClienteFTC)

            If accionPantalla = "ALTA" Then
                dttInicioVigenciaLVC.Value = CDate(fechaMin).ToShortDateString
                dttFinVigenciaLVC.Value = CDate(fechaMax).ToShortDateString
                chkTodosLosArticulos.Visible = False
                lblPrecioModificado.Text = "0"
                lblSinPrecio.Text = "0"
                lblConPrecio.Text = "0"
                txtUsuarioModifico.Text = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                llenarComboEstatus("")
                cmbEstatusLVCP.SelectedIndex = 1
                cmbEstatusLVCP.Enabled = False
                llenarTablaModelos(idListaBase, idClienteFTC, 0, True)
                Me.Cursor = Cursors.WaitCursor

            ElseIf accionPantalla = "EDITAR" Then
                llenarEncabezadoConfiguracion(idListaVentasClientePrecio)
                llenarTablaModelos(idListaBase, idClienteFTC, idListaVentasClientePrecio, 0)
                Me.Cursor = Cursors.WaitCursor

            ElseIf accionPantalla = "CONSULTA" Then

                llenarEncabezadoConfiguracion(idListaVentasClientePrecio)
                llenarTablaModelos(idListaBase, idClienteFTC, idListaVentasClientePrecio, 0)
                grpDatos.Enabled = False
                grpOperaciones.Visible = False
                grbQuitarArticulo.Visible = False
                chkTodosLosArticulos.Visible = False
                chkSeleccionArticulos.Visible = False
                grpMovimientoParidadOLoriginal.Visible = False
                btnGuardar.Visible = False
                lblGuardar.Visible = False

            ElseIf accionPantalla = "COPIAR" Then

                chkTodosLosArticulos.Visible = False
                cmbListasBase.Visible = True
                llenarComboListasPrecios()
                Me.Cursor = Cursors.WaitCursor
                txtUsuarioModifico.Text = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                llenarComboEstatus("")
                cmbEstatusLVCP.SelectedIndex = 1
                cmbEstatusLVCP.Enabled = False

                If tipoClienteId = 2 Then
                    Dim objLVCP As New Negocios.ListaPreciosVentaClienteBU
                    Dim dtDatosEncabezado As New DataTable
                    dtDatosEncabezado = objLVCP.datosListaVentasPrecioClienteEncabezado(idListaVentasClientePrecio)
                    If dtDatosEncabezado.Rows.Count > 0 And tipoClienteId = 2 Then
                        If dtDatosEncabezado.Rows(0).Item("lvcp_incotermsid").ToString <> "" Then
                            cmbIncoterms.SelectedValue = dtDatosEncabezado.Rows(0).Item("lvcp_incotermsid").ToString
                        End If
                    End If
                End If

                llenarTablaModelos(idListaBase, idClienteFTC, 0, True)

                Dim cosa As String = idListaVentasClientePrecio.ToString
                Dim objLB As New Ventas.Negocios.ListaBaseBU
                Dim dtDatosModelos As New DataTable
                Dim contArticulosCPrecio As Int32 = 0
                dtDatosModelos = objLB.verDetallesListaPreciosCliente(idListaBase, idClienteFTC,
                                                                      idListaVentasClientePrecioCOPIA, 0,
                                                                      idListaPreciosVentasCOPIA, 0)

                For Each rowDT As DataRow In dtDatosModelos.Rows
                    For Each rowGrd As UltraGridRow In grdModelos.Rows
                        If rowDT.Item("pres_productoestiloid").ToString = rowGrd.Cells("pres_productoestiloid").Value.ToString Then
                            '' ''rowGrd.Cells("Precio").Value = rowDT.Item("Precio").ToString
                            '' ''rowGrd.Cells("PrecioParidad").Value = rowDT.Item("PrecioParidad").ToString
                            rowGrd.Cells("SeleccionArticulos").Value = True
                            rowGrd.Cells("SeleccionArticulos").Appearance.BackColor = Color.Gold
                            lblContArtsGuardar.Text = CInt(CInt(lblContArtsGuardar.Text) + 1).ToString("N0")
                            Exit For
                        End If
                    Next
                Next

                Dim contadorSeleccion As Int32 = 0
                For Each rowGr As UltraGridRow In grdModelos.Rows
                    If CBool(rowGr.Cells("SeleccionArticulos").Value) = True Then
                        contadorSeleccion += 1
                        If rowGr.Cells("Estado").Value = "N" Then
                            lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")
                        ElseIf rowGr.Cells("Estado").Value = "P" Then
                            lblConPrecio.Text = (CInt(lblConPrecio.Text) + 1).ToString("N0")
                        ElseIf rowGr.Cells("Estado").Value = "D" Then
                            lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) + 1).ToString("N0")
                        End If
                    Else
                        'If rowGr.Cells("Estado").Value = "N" Then
                        '    lblSinPrecio.Text = (CInt(lblSinPrecio.Text) - 1).ToString("N0")
                        'ElseIf rowGr.Cells("Estado").Value = "P" Then
                        '    lblConPrecio.Text = (CInt(lblConPrecio.Text) - 1).ToString("N0")
                        'ElseIf rowGr.Cells("Estado").Value = "D" Then
                        '    lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) - 1).ToString("N0")
                        'End If
                    End If
                Next
            End If
        End If

        If primerEstatus = 26 Or primerEstatus = 27 Or primerEstatus = 28 Then
            btnRecalcular.Enabled = False
            lblRecalcular.Enabled = False
            chkSeleccionArticulos.Enabled = False
        End If

        If tipoClienteId <> 2 Then
            cmbIncoterms.Enabled = False
        End If

        If primerEstatus = 27 Or primerEstatus = 28 Then
            grpMovimientoParidadOLoriginal.Visible = False
        End If

        If idMoneda = 1 And grpMovimientoParidadOLoriginal.Text = "Paridad" Then
            grpMovimientoParidadOLoriginal.Visible = False
        End If

        If PermiteEdicion = True Then
            If estatusLB = "AUTORIZADA" Then
                btnRegresarACapturada.Enabled = True
            Else
                btnRegresarACapturada.Enabled = False
            End If
        End If


        Me.Cursor = Cursors.Default

    End Sub

    Public Sub exportarPDF()
        Dim sfd As New SaveFileDialog
        Dim ugde As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter()
        sfd.DefaultExt = "pdf"
        sfd.Filter = "PDF files (*.pdf)|*.pdf"
        Dim result As DialogResult = sfd.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            Dim fileName As String = sfd.FileName
            ugde.AutoSize = Infragistics.Win.UltraWinGrid.DocumentExport.AutoSize.SizeColumnsToContent
            ugde.TargetPaperOrientation = PageOrientation.Portrait
            ugde.TargetPaperSize = PageSizes.A4
            Dim r As Report = New Report()

            Dim sec As ISection = r.AddSection()
            Dim img As Infragistics.Documents.Reports.Graphics.Image = New Infragistics.Documents.Reports.Graphics.Image(Global.Ventas.Vista.My.Resources.Resources.yuyin)

            Dim sectionHeader As Infragistics.Documents.Reports.Report.Section.ISectionHeader = sec.AddHeader()
            sectionHeader.Repeat = True
            sectionHeader.Height = 100

            Dim sectionHeaderImg As Infragistics.Documents.Reports.Report.IImage = sectionHeader.AddImage(img, 0, 0)
            sectionHeaderImg.Paddings.All = 10

            Dim sectionHeaderText As Infragistics.Documents.Reports.Report.Text.IText = sectionHeader.AddText(0, 0)
            sectionHeaderText.Paddings.Top = 60
            sectionHeaderText.Alignment = New TextAlignment(Alignment.Center)
            sectionHeaderText.AddContent("Listas")

            Dim sectionHeaderDate As Infragistics.Documents.Reports.Report.Text.IText = sectionHeader.AddText(0, 0)
            sectionHeaderDate.Paddings.Top = 60
            sectionHeaderDate.Alignment = New TextAlignment(Alignment.Left)
            sectionHeaderDate.AddContent(DateTime.Now.ToString("d"))

            Dim sectionFooter As Infragistics.Documents.Reports.Report.Section.ISectionFooter = sec.AddFooter()
            sectionFooter.Repeat = True
            sectionFooter.Height = 60

            Dim sectionFooterText As Infragistics.Documents.Reports.Report.Text.IText = sectionFooter.AddText(0, 0)
            sectionFooterText.Alignment = New TextAlignment(Alignment.Left)
            sectionFooterText.AddContent("Página: ")
            sectionFooterText.AddPageNumber(PageNumberFormat.Decimal)
            ugde.Export(grdModelos, sec)

            Me.Cursor = Cursors.Default
            MsgBox("Se exportó correctamente.", MsgBoxStyle.Information, "")
            Try
                r.Publish(fileName, FileFormat.PDF)
                Process.Start(fileName)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento PDF " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try

        End If
    End Sub

    Public Sub exportarExcel()
        Dim sfd As New SaveFileDialog
        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        Dim gr As New UltraGrid
        If result = Windows.Forms.DialogResult.OK Then
            Try
                gr = grdModelos
                gr.DisplayLayout.Bands(0).Columns("Seleccion").Hidden = True
                gr.DisplayLayout.Bands(0).Columns("Estado").Hidden = True
                Me.Cursor = Cursors.WaitCursor
                exportExcelDetalle.Export(gr, fileName)
                Me.Cursor = Cursors.Default
                gr.DisplayLayout.Bands(0).Columns("Seleccion").Hidden = False
                gr.DisplayLayout.Bands(0).Columns("Estado").Hidden = False
                Me.Cursor = Cursors.WaitCursor
                Process.Start(fileName)
                Me.Cursor = Cursors.Default

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try
        End If
    End Sub

    '{----------------------------------- Metodos VB -----------------------------------------}'

    Private Sub AltaConfiguracionListaPreciosCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsuarioModifico.Text = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        llenarDatosInicio()
        PermisosUsuario()
        If inactiva = True Then
            BloquearCamposListaInactiva()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objLVPC As New Negocios.ListaPreciosVentaClienteBU
        Dim objFormAltaLVC As New AltaConfiguracionListaPreciosCliente

        Dim contLVCP As Int32 = 0
        If accionPantalla = "COPIAR" Then
            contLVCP = objLVPC.consultaValidarListasCapturadas(idListaVentasCliente)
        End If

        If contLVCP <= 1 Then
            If validarVigenciaComparar() = True Then
                If validarVigencia() = True Then
                    If validarListasAceptadas() = True Then
                        If valiarVacios() = True Then

                            Try
                                If aceptarCambiosParidad() = True Then
                                    'valido que la fecha fin de la nueva lista sea mayor a la fecha fin lista base
                                    If dttFinVigenciaLVC.Value > fechaFinListaBase Then
                                        Dim objMsjConfirmar As New Tools.confirmarFormGrande
                                        Dim cadenaMensaje As String = "La lista base ''" + txtListaBase.Text + "'' termina su vigencia el " + fechaFinListaBase + " ¿Desea asignar como fecha de fin el " + dttFinVigenciaLVC.Value + " a la lista de precios del cliente " + txtNombreCliente.Text + " a pesar de estar fuera de la vigencia de la lista base? (Este cambio aplicará a los pedidos que se capturen de ahora en adelante, los pedidos ya capturados no se modificarán, una vez realizada esta acción no se podrá revertir)"
                                        objMsjConfirmar.mensaje = cadenaMensaje
                                        If objMsjConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                                            Dim objCaptcha As New Tools.frmCaptcha
                                            objCaptcha.mensaje = ""
                                            If objCaptcha.ShowDialog = Windows.Forms.DialogResult.OK Then

                                                guardarListaPreciosCliente()
                                                Dim objMensajeGuardar As New Tools.ExitoForm
                                                objMensajeGuardar.mensaje = "Registros Correctos"
                                                objMensajeGuardar.ShowDialog()
                                                Me.Close()

                                            End If
                                        End If
                                        'valido que la fecha fin de la nueva lista sea menor a la fecha inicio de lista base
                                    ElseIf dttFinVigenciaLVC.Value < fechaInicioListaBase Then
                                        Dim objMsjConfirmar As New Tools.confirmarFormGrande
                                        Dim cadenaMensaje As String = "La lista base ''" + txtListaBase.Text + "'' inicia su vigencia el " + fechaInicioListaBase + " ¿Desea asignar como fecha de fin el " + dttFinVigenciaLVC.Value + " a la lista de precios del cliente " + txtNombreCliente.Text + " a pesar de estar fuera de la vigencia de la lista base? (Este cambio aplicará a los pedidos que se capturen de ahora en adelante, los pedidos ya capturados no se modificarán, una vez realizada esta acción no se podrá revertir)"
                                        objMsjConfirmar.mensaje = cadenaMensaje
                                        If objMsjConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                                            Dim objCaptcha As New Tools.frmCaptcha
                                            objCaptcha.mensaje = ""
                                            If objCaptcha.ShowDialog = Windows.Forms.DialogResult.OK Then

                                                guardarListaPreciosCliente()
                                                Dim objMensajeGuardar As New Tools.ExitoForm
                                                objMensajeGuardar.mensaje = "Registros Correctos"
                                                objMensajeGuardar.ShowDialog()
                                                Me.Close()

                                            End If
                                        End If
                                        'entra a las demás opciones de fecha
                                    Else
                                        Dim objMsjConfirmar As New Tools.ConfirmarForm
                                        Dim cadenaMensaje As String = "¿Está seguro de guardar la lista de precios de cliente?"
                                        objMsjConfirmar.mensaje = cadenaMensaje
                                        If objMsjConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                                            Dim objCaptcha As New Tools.frmCaptcha
                                            objCaptcha.mensaje = ""
                                            If objCaptcha.ShowDialog = Windows.Forms.DialogResult.OK Then

                                                guardarListaPreciosCliente()
                                                Dim objMensajeGuardar As New Tools.ExitoForm
                                                objMensajeGuardar.mensaje = "Registros Correctos"
                                                objMensajeGuardar.ShowDialog()
                                                Me.Close()

                                            End If
                                        End If
                                    End If

                                    'Dim objMsjConfirmar As New Tools.ConfirmarForm
                                    'Dim cadenaMensaje As String = "¿Está seguro de guardar la lista de precios de cliente?"
                                    '' ''If CInt(lblClientesCopiados.Text) > 0 Then
                                    '' ''    cadenaMensaje = "Los datos se agregaran a las listas copia."
                                    '' ''End If
                                    'objMsjConfirmar.mensaje = cadenaMensaje
                                    'If objMsjConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                                    'If objCaptcha.ShowDialog = Windows.Forms.DialogResult.OK Then

                                    '    guardarListaPreciosCliente()
                                    '    Dim objMensajeGuardar As New Tools.ExitoForm
                                    '    objMensajeGuardar.mensaje = "Registros Correctos"
                                    '    objMensajeGuardar.ShowDialog()
                                    '    Me.Close()

                                    'End If
                                    'End If
                                End If

                            Catch ex As Exception
                                Me.Cursor = Cursors.Default
                                MsgBox("Error en el prceso.", MsgBoxStyle.Critical, "")
                                Me.Close()
                            End Try
                        End If
                    Else
                        Dim objMsjAdv As New Tools.AdvertenciaForm
                        objMsjAdv.mensaje = "No pueden existir mas de dos listas de precios de cliente en estatus ACEPTADA en una misma lista de ventas de cliente"
                        objMsjAdv.ShowDialog()
                    End If


                Else
                    Dim objMsjAdv As New Tools.AdvertenciaForm
                    objMsjAdv.mensaje = "La vigencia fin no puede ser menos a la vigencia de inicio"
                    objMsjAdv.ShowDialog()
                End If
            Else
                Dim objMsjAdv As New Tools.AdvertenciaForm
                objMsjAdv.mensaje = "La vigencia de esta lista de precios no puede iniciar en la fecha capturada, alguna otra lista del cliente se encontrará vigente. Cambie la vigencia de esta lista de precios o modifique la vigencia de la otra lista."
                objMsjAdv.ShowDialog()
            End If
        Else
            Dim objAdMensaje As New Tools.AdvertenciaForm
            objAdMensaje.mensaje = "El cliente no puede tener mas de 2 listas en estatus ACEPTADA-CAPTURADA."
            objAdMensaje.ShowDialog()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnCargarClientes_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub cmbEstatusLista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListasBase.SelectedIndexChanged
        Try

            Dim datoValidar As Int32 = cmbListasBase.SelectedValue
            idListaBase = cmbListasBase.SelectedValue
            consultaincrementoCliente(idClienteFTC)

            txtUsuarioModifico.Text = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            llenarComboEstatus("")
            cmbEstatusLVCP.SelectedIndex = 1
            cmbEstatusLVCP.Enabled = False

            Dim objLPVC As New Negocios.ListaPreciosVentaClienteBU
            Dim objLPVent As New Negocios.ListaVentasBU
            Dim dtDatosListaPrecios As New DataTable
            Dim dtFechasVigListaVtas As New DataTable
            dtDatosListaPrecios = objLPVC.consultasDatosListasBaseCliente(idClienteFTC, idListaBase)
            nombreListaBase = dtDatosListaPrecios.Rows(0).Item("LISTABASE").ToString
            idListaPreciosVentas = dtDatosListaPrecios.Rows(0).Item("lpvt_listaprecioventaid").ToString
            nombreListaPreciosVentas = dtDatosListaPrecios.Rows(0).Item("lpvt_descripcion").ToString
            incrementoListaVentas = dtDatosListaPrecios.Rows(0).Item("lpvt_incrementoporpar").ToString
            idListaVentasCliente = dtDatosListaPrecios.Rows(0).Item("lvcl_listaventasclienteid").ToString
            dtFechasVigListaVtas = objLPVent.consultaminVigencias(idListaPreciosVentas)

            If dtFechasVigListaVtas.Rows(0).Item(0).ToString <> "" And dtFechasVigListaVtas.Rows(1).Item(0).ToString <> "" Then
                'fechaMin = CDate(dtFechasVigListaVtas.Rows(0).Item(0).ToString).ToShortDateString
                'fechaMax = CDate(dtFechasVigListaVtas.Rows(1).Item(0).ToString).ToShortDateString

                'dttInicioVigenciaLVC.MinDate = CDate(fechaMin).ToShortDateString
                'dttInicioVigenciaLVC.MaxDate = CDate(fechaMax).ToShortDateString
                'dttFinVigenciaLVC.MinDate = CDate(fechaMin).ToShortDateString
                'dttFinVigenciaLVC.MaxDate = CDate(fechaMax).ToShortDateString
            End If
            If dtDatosListaPrecios.Rows(0).Item("lpba_estatus").ToString = "1" Then
                estatusLB = "ACTIVA"
                lblEstatus.Text = "ACTIVA"
                lblEstatus.ForeColor = Color.DarkOrange
            ElseIf dtDatosListaPrecios.Rows(0).Item("lpba_estatus").ToString = "2" Then
                estatusLB = "AUTORIZADA"
                lblEstatus.Text = "AUTORIZADA"
                lblEstatus.ForeColor = Color.LimeGreen
            Else
                lblEstatus.Text = "ESTATUS"
                lblEstatus.ForeColor = Color.Black
            End If


            lblMensajeSinListaVentas.Text = ""
            lblContLB.Text = "0"
            txtListaBase.Text = nombreListaBase
            txtListaDeVentas.Text = nombreListaPreciosVentas

            'dttInicioVigenciaLVC.MinDate = fechaMin
            'dttFinVigenciaLVC.MaxDate = fechaMax
            lblIncrementoPar.Text = CDbl(incrementoListaVentas).ToString("N0")
            lblEstatus.Text = estatusLB

            If tipoClienteId = 2 Then
                Dim objLVCP As New Negocios.ListaPreciosVentaClienteBU
                Dim dtDatosEncabezado As New DataTable
                dtDatosEncabezado = objLVCP.datosListaVentasPrecioClienteEncabezado(idListaVentasClientePrecio)
                If dtDatosEncabezado.Rows.Count > 0 And tipoClienteId = 2 Then
                    If dtDatosEncabezado.Rows(0).Item("lvcp_incotermsid").ToString <> "" Then
                        cmbIncoterms.SelectedValue = dtDatosEncabezado.Rows(0).Item("lvcp_incotermsid").ToString
                    End If
                End If
            End If
            llenarTablaModelos(idListaBase, idClienteFTC, 0, True)
            Dim cosa As String = idListaVentasClientePrecio.ToString
            Dim objLB As New Ventas.Negocios.ListaBaseBU
            Dim dtDatosModelos As New DataTable
            Dim contArticulosCPrecio As Int32 = 0
            dtDatosModelos = objLB.verDetallesListaPreciosCliente(idListaBase, idClienteFTC,
                                                                  idListaVentasClientePrecioCOPIA, 0,
                                                                  idListaPreciosVentasCOPIA, 0)

            For Each rowDT As DataRow In dtDatosModelos.Rows
                For Each rowGrd As UltraGridRow In grdModelos.Rows
                    If rowDT.Item("pres_productoestiloid").ToString = rowGrd.Cells("pres_productoestiloid").Value.ToString Then
                        rowGrd.Cells("Precio").Value = rowDT.Item("Precio").ToString
                        rowGrd.Cells("PrecioParidad").Value = rowDT.Item("PrecioParidad").ToString
                        rowGrd.Cells("SeleccionArticulos").Value = True
                        rowGrd.Cells("SeleccionArticulos").Appearance.BackColor = Color.Gold
                        lblContArtsGuardar.Text = CInt(lblContArtsGuardar.Text) + 1
                        Exit For
                    End If
                Next
            Next

            Me.Cursor = Cursors.Default
            If idMoneda = 1 Then
                grpMovimientoParidadOLoriginal.Visible = False
            End If



            Dim objLVPC As New Negocios.ListaPreciosVentaClienteBU
            Dim contLVCP As Int32 = 0
            contLVCP = objLVPC.consultaValidarListasCapturadas(dtDatosListaPrecios.Rows(0).Item("lvcl_listaventasclienteid").ToString)
            If contLVCP <= 1 Then
                btnGuardar.Enabled = True
                lblGuardar.Enabled = True
            Else
                btnGuardar.Enabled = False
                lblGuardar.Enabled = False
                Dim objAdMensaje As New Tools.AdvertenciaForm
                objAdMensaje.mensaje = "El cliente no puede tener mas de 2 listas en estatus ACEPTADA-CAPTURADA."
                objAdMensaje.ShowDialog()
            End If

        Catch ex As Exception

        End Try

    End Sub


    Private Sub cmbClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClientes.SelectedIndexChanged
        lblTotalSeleccionados.Text = "0"
        lblContArtsGuardar.Text = "0"
        lblIncrementoPar.Text = "0.0"
        lblDescuento.Text = "0.0"
        lblFacturacion.Text = "0.0"
        ''lblClientesCopiados.Text = "0"
        lblFlete.Text = "---"
        lblIVA.Text = "---"
        lblListaOriginalCliente.Text = ""
        lblConPrecio.Text = "0"
        lblSinPrecio.Text = "0"
        lblPrecioModificado.Text = "0"
        lblMensajeSinListaVentas.Text = ""
        lblContLB.Text = "0"
        idFlete = 0
        idIva = 0
        incremento = 0
        porcentaje = False
        idListaCliente = 0
        grdModelos.DataSource = Nothing
        If Not cmbListasBase.DataSource Is Nothing Then
            If cmbClientes.SelectedIndex > 0 Then
                Me.Cursor = Cursors.WaitCursor
                consultaincrementoCliente(cmbClientes.SelectedValue)
                cmbListasBase.SelectedIndex = 1
                If cmbListasBase.SelectedIndex > 0 Then
                    Dim idListaBase As Int32 = cmbListasBase.SelectedValue
                    consultaDatosListaBase(idListaBase)
                    'llenarComboListaVentasCliente(idListaBase)
                Else
                    cmbListaVentas.DataSource = Nothing
                    cmbListaVentas.Items.Clear()
                    grdModelos.DataSource = Nothing
                    lblEstatus.Text = "ESTATUS"
                End If
                chkSeleccionarFiltrados.Checked = False
                chkSeleccionarFiltrados.Enabled = True
                chkSeleccionArticulos.Checked = False
                chkSeleccionArticulos.Enabled = True
                Me.Cursor = Cursors.Default
            End If
        Else
            lblMensajeSinListaVentas.Text = "No existe una lista de precios base."
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnCargarPrecioMultiple_Click(sender As Object, e As EventArgs) Handles btnCargarPrecioMultiple.Click
        If rdoCambiar.Checked = True Then
            asignarPrecios()
        Else
            asignarCalcularPrecios()
        End If
    End Sub

    Private Sub grdModelos_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdModelos.AfterCellUpdate
        If endEdit = False Then
            If (e.Cell.Column.ToString = "Precio" And e.Cell.Row.Index <> grdModelos.Rows.FilterRow.Index) Then
                If e.Cell.Value.ToString = "" Then
                    e.Cell.Value = 0
                ElseIf e.Cell.Value > 9999 Then
                    e.Cell.Value = 0
                End If
            End If
        End If
        If (e.Cell.Column.ToString = "Precio" And e.Cell.Row.Index <> grdModelos.Rows.FilterRow.Index) Then
            Dim PrecioAnterior As String = e.Cell.OriginalValue.ToString
            Dim contAnt As Int32 = 0
            Dim contNuevo As Int32 = 0

            If grdModelos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value <> e.Cell.Value Then
                grdModelos.Rows(e.Cell.Row.Index).Cells("Estado").Appearance.BackColor = Color.Lime
                grdModelos.Rows(e.Cell.Row.Index).Cells("Estado").Value = "D"
                If e.Cell.Value > 0 Then
                    If PrecioAnterior = "0" Then
                        If CBool(grdModelos.Rows(e.Cell.Row.Index).Cells("SeleccionArticulos").Value) = True Then
                            lblSinPrecio.Text = (CInt(lblSinPrecio.Text) - 1).ToString("N0")
                            lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) + 1).ToString("N0")
                        End If
                    ElseIf PrecioAnterior = grdModelos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value Then
                        If CBool(grdModelos.Rows(e.Cell.Row.Index).Cells("SeleccionArticulos").Value) = True Then
                            lblConPrecio.Text = (CInt(lblConPrecio.Text) - 1).ToString("N0")
                            lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) + 1).ToString("N0")
                        End If
                    End If
                End If
                If grdModelos.Rows(e.Cell.Row.Index).Cells("precioBase").Value > e.Cell.Value Then
                    e.Cell.Appearance.ForeColor = Color.Red
                    e.Cell.Appearance.FontData.Bold = DefaultableBoolean.True
                Else
                    e.Cell.Appearance.ForeColor = Color.Black
                    e.Cell.Appearance.FontData.Bold = DefaultableBoolean.False
                End If
                If idMoneda > 1 Then
                    grdModelos.Rows(e.Cell.Row.Index).Cells("PrecioParidad").Value = Math.Round(e.Cell.Value / lblValorParidadPesos.Text, 1)
                End If
            Else
                If e.Cell.Value = 0 Then
                    grdModelos.Rows(e.Cell.Row.Index).Cells("Estado").Appearance.BackColor = Color.Red
                    grdModelos.Rows(e.Cell.Row.Index).Cells("Estado").Value = "N"
                    If PrecioAnterior = grdModelos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value Then
                        If CBool(grdModelos.Rows(e.Cell.Row.Index).Cells("SeleccionArticulos").Value) = True Then
                            lblConPrecio.Text = (CInt(lblConPrecio.Text) - 1).ToString("N0")
                            lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")
                        End If
                    ElseIf PrecioAnterior <> grdModelos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value Then
                        If CBool(grdModelos.Rows(e.Cell.Row.Index).Cells("SeleccionArticulos").Value) = True Then
                            lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) - 1).ToString("N0")
                            lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")
                        End If
                    End If
                    If grdModelos.Rows(e.Cell.Row.Index).Cells("precioBase").Value > e.Cell.Value Then
                        e.Cell.Appearance.ForeColor = Color.Red
                        e.Cell.Appearance.FontData.Bold = DefaultableBoolean.True
                    Else
                        e.Cell.Appearance.ForeColor = Color.Black
                        e.Cell.Appearance.FontData.Bold = DefaultableBoolean.False
                    End If
                    If idMoneda > 1 Then
                        grdModelos.Rows(e.Cell.Row.Index).Cells("PrecioParidad").Value = "0"
                    End If
                ElseIf e.Cell.Value > 0 Then
                    grdModelos.Rows(e.Cell.Row.Index).Cells("Estado").Appearance.BackColor = Color.DodgerBlue
                    grdModelos.Rows(e.Cell.Row.Index).Cells("Estado").Value = "P"
                    If PrecioAnterior = "0" Then
                        If CInt(lblSinPrecio.Text) > 0 Then
                            If CBool(grdModelos.Rows(e.Cell.Row.Index).Cells("SeleccionArticulos").Value) = True Then
                                lblSinPrecio.Text = (CInt(lblSinPrecio.Text) - 1).ToString("N0")
                            End If
                        End If
                        If CBool(grdModelos.Rows(e.Cell.Row.Index).Cells("SeleccionArticulos").Value) = True Then
                            lblConPrecio.Text = (CInt(lblConPrecio.Text) + 1).ToString("N0")
                        End If
                    ElseIf PrecioAnterior <> grdModelos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value Then
                        If CBool(grdModelos.Rows(e.Cell.Row.Index).Cells("SeleccionArticulos").Value) = True Then
                            lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) - 1).ToString("N0")
                            lblConPrecio.Text = (CInt(lblConPrecio.Text) + 1).ToString("N0")
                        End If
                    End If
                    If grdModelos.Rows(e.Cell.Row.Index).Cells("precioBase").Value > e.Cell.Value Then
                        e.Cell.Appearance.ForeColor = Color.Red
                        e.Cell.Appearance.FontData.Bold = DefaultableBoolean.True
                    Else
                        e.Cell.Appearance.ForeColor = Color.Black
                        e.Cell.Appearance.FontData.Bold = DefaultableBoolean.False
                    End If
                    If idMoneda > 1 Then
                        grdModelos.Rows(e.Cell.Row.Index).Cells("PrecioParidad").Value = Math.Round(e.Cell.Value / lblValorParidadPesos.Text, 1)
                    End If
                End If
            End If
            If PrecioAnterior <> "" Then
                If e.Cell.Value = 0 Then
                    grdModelos.Rows(e.Cell.Row.Index).Cells("Estado").Appearance.BackColor = Color.Red
                    grdModelos.Rows(e.Cell.Row.Index).Cells("Estado").Value = "N"
                    If PrecioAnterior = grdModelos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value Then
                        If CBool(grdModelos.Rows(e.Cell.Row.Index).Cells("SeleccionArticulos").Value) = True Then
                            lblConPrecio.Text = (CInt(lblConPrecio.Text) - 1).ToString("N0")
                            lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")
                        End If
                    ElseIf PrecioAnterior <> grdModelos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value Then
                        If CBool(grdModelos.Rows(e.Cell.Row.Index).Cells("SeleccionArticulos").Value) = True Then
                            lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) - 1).ToString("N0")
                            lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")
                        End If
                    End If
                    If grdModelos.Rows(e.Cell.Row.Index).Cells("precioBase").Value > e.Cell.Value Then
                        e.Cell.Appearance.ForeColor = Color.Red
                        e.Cell.Appearance.FontData.Bold = DefaultableBoolean.True
                    Else
                        e.Cell.Appearance.ForeColor = Color.Black
                        e.Cell.Appearance.FontData.Bold = DefaultableBoolean.False
                    End If
                    If idMoneda > 1 Then
                        grdModelos.Rows(e.Cell.Row.Index).Cells("PrecioParidad").Value = "0"
                    End If
                End If
            Else
                e.Cell.CancelUpdate()
            End If
        End If

    End Sub

    Private Sub grdModelos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdModelos.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdModelos_CellChange(sender As Object, e As CellEventArgs) Handles grdModelos.CellChange
        If e.Cell.Column.Key = "Seleccion" And e.Cell.Row.Index <> grdModelos.Rows.FilterRow.Index Then
            Dim contadorSeleccion As Int32 = 0
            For Each rowGR As UltraGridRow In grdModelos.Rows
                If CBool(rowGR.Cells("Seleccion").Text) = True Then
                    contadorSeleccion += 1
                    'MsgBox("cuenta")
                End If
            Next
            lblTotalSeleccionados.Text = contadorSeleccion.ToString("N0")
        End If
        If e.Cell.Column.Key = "SeleccionArticulos" And e.Cell.Row.Index <> grdModelos.Rows.FilterRow.Index Then
            Dim contadorSeleccion As Int32 = 0
            If CBool(e.Cell.Text) = True Then
                If e.Cell.Appearance.BackColor <> Color.Red Then
                    e.Cell.Appearance.BackColor = Color.Gold
                End If
                lblContArtsGuardar.Text = CInt(CInt(lblContArtsGuardar.Text) + 1).ToString("N0")

                If grdModelos.Rows(e.Cell.Row.Index).Cells("Estado").Value = "N" Then
                    lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")
                ElseIf grdModelos.Rows(e.Cell.Row.Index).Cells("Estado").Value = "P" Then
                    lblConPrecio.Text = (CInt(lblConPrecio.Text) + 1).ToString("N0")
                ElseIf grdModelos.Rows(e.Cell.Row.Index).Cells("Estado").Value = "D" Then
                    lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) + 1).ToString("N0")
                End If
            Else
                If e.Cell.Appearance.BackColor <> Color.Red Then
                    If e.Cell.Row.Index Mod 2 = 0 Then
                        e.Cell.Appearance.BackColor = Color.White
                    Else
                        e.Cell.Appearance.BackColor = Color.LightSteelBlue
                    End If
                End If
                lblContArtsGuardar.Text = CInt(CInt(lblContArtsGuardar.Text) - 1).ToString("N0")

                If grdModelos.Rows(e.Cell.Row.Index).Cells("Estado").Value = "N" Then
                    lblSinPrecio.Text = (CInt(lblSinPrecio.Text) - 1).ToString("N0")
                ElseIf grdModelos.Rows(e.Cell.Row.Index).Cells("Estado").Value = "P" Then
                    lblConPrecio.Text = (CInt(lblConPrecio.Text) - 1).ToString("N0")
                ElseIf grdModelos.Rows(e.Cell.Row.Index).Cells("Estado").Value = "D" Then
                    lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) - 1).ToString("N0")
                End If
            End If
        End If

    End Sub

    Private Sub grdModelos_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdModelos.ClickCell
        If primerEstatus = 25 Then
            If e.Cell.Column.Key = "SeleccionArticulos" And e.Cell.Row.Index <> grdModelos.Rows.FilterRow.Index Then
                If PermiteEdicion Then
                    If e.Cell.Value = 1 And grdModelos.Rows(e.Cell.Row.Index).Cells("ArticulosGuardados").Value = 1 Then
                        grbQuitarArticulo.Enabled = True
                    Else
                        grbQuitarArticulo.Enabled = False
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub grdModelos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdModelos.InitializeLayout
        Me.grdModelos.DisplayLayout.GroupByBox.Prompt = "Arrastra para agrupar datos."
        Dim valueList As ValueList = e.Layout.FilterOperatorsValueList
        Dim item As ValueListItem
        For Each item In valueList.ValueListItems
            Dim filterOperator As FilterComparisionOperator = DirectCast(item.DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Contains = filterOperator Then
                item.DisplayText = "CONTIENE"
            ElseIf FilterComparisionOperator.DoesNotEndWith = filterOperator Then
                item.DisplayText = "NO TERMINA CON"
            ElseIf FilterComparisionOperator.DoesNotStartWith = filterOperator Then
                item.DisplayText = "NO COMIENZA CON"
            ElseIf FilterComparisionOperator.EndsWith = filterOperator Then
                item.DisplayText = "TERMINA CON"
            ElseIf FilterComparisionOperator.Equals = filterOperator Then
                item.DisplayText = "IGUAL"
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                item.DisplayText = "MAYOR QUE"
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                item.DisplayText = "MAYOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                item.DisplayText = "MENOR QUE"
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                item.DisplayText = "MENOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.NotEquals = filterOperator Then
                item.DisplayText = "DIFERENTE A"
            ElseIf FilterComparisionOperator.StartsWith = filterOperator Then
                item.DisplayText = "COMIENZA CON"
            End If
        Next

        Dim cont As Integer
        For cont = valueList.ValueListItems.Count - 1 To 0 Step -1
            Dim filterOperator As FilterComparisionOperator = DirectCast(valueList.ValueListItems.Item(cont).DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Custom = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotContain = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotMatch = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Like = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Match = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.NotLike = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            End If
        Next
    End Sub

    Private Sub grdClientesCopia_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs)
        e.Cancel = True
    End Sub

    Private Sub btnCambiarCliente_Click(sender As Object, e As EventArgs) Handles btnCambiarCliente.Click
        If idListaCliente > 0 Then
            lblPrecioModificado.Text = "0"
            lblSinPrecio.Text = "0"
            lblConPrecio.Text = "0"
            llenarTablaModelos(cmbListasBase.SelectedValue, cmbClientes.SelectedValue, idListaCliente, True)
        Else
            MsgBox("El cliente no tiene una lista de ventas asignada.", MsgBoxStyle.Exclamation, "Atención")
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub chkSeleccionarFiltrados_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarFiltrados.CheckedChanged
        For Each rowGr As UltraGridRow In grdModelos.Rows.GetFilteredInNonGroupByRows
            rowGr.Cells("Seleccion").Value = CBool(chkSeleccionarFiltrados.Checked)
        Next

        Dim contadorSeleccion As Int32 = 0
        For Each rowGR As UltraGridRow In grdModelos.Rows
            If CBool(rowGR.Cells("Seleccion").Text) = True Then
                contadorSeleccion += 1
            End If
        Next
        lblTotalSeleccionados.Text = contadorSeleccion.ToString("N0")
    End Sub

    Private Sub grdModelos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdModelos.InitializeRow
        If CBool(e.Row.Cells("marc_decimales").Value) = False And chkDescuentoIncluido.Checked = False Then
            e.Row.Cells("Precio").Style = ColumnStyle.Integer
        ElseIf CBool(e.Row.Cells("marc_decimales").Value) = True Or chkDescuentoIncluido.Checked = True Then
            e.Row.Cells("Precio").Style = ColumnStyle.Double
        End If
    End Sub

    Private Sub grdModelos_KeyDown(sender As Object, e As KeyEventArgs) Handles grdModelos.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdModelos.PerformAction(UltraGridAction.ExitEditMode, False, False)
            Dim banda As UltraGridBand = grdModelos.DisplayLayout.Bands(0)
            If grdModelos.ActiveRow.HasNextSibling(True) Then
                Dim nextRow As UltraGridRow = grdModelos.ActiveRow.GetSibling(SiblingRow.Next, True)
                grdModelos.ActiveCell = nextRow.Cells(grdModelos.ActiveCell.Column)
                e.Handled = True
                grdModelos.PerformAction(UltraGridAction.EnterEditMode, False, False)
            End If
        End If
    End Sub

    Private Sub chkSeleccionArticulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionArticulos.CheckedChanged

        Dim contPrecio As Int32 = 0
        Dim contSinPrecio As Int32 = 0
        Dim contPrecioDif As Int32 = 0

        Dim contadorSeleccion As Int32 = 0
        For Each rowGr As UltraGridRow In grdModelos.Rows.GetFilteredInNonGroupByRows
            If rowGr.Cells("ArticulosGuardados").Value = 0 Then
                rowGr.Cells("SeleccionArticulos").Value = CBool(chkSeleccionArticulos.Checked)
                If CBool(chkSeleccionArticulos.Checked) = True Then
                    rowGr.Cells("SeleccionArticulos").Appearance.BackColor = Color.Gold
                Else
                    If rowGr.Cells("SeleccionArticulos").Appearance.BackColor <> Color.Red Then
                        If rowGr.Cells("SeleccionArticulos").Row.Index Mod 2 = 0 Then
                            rowGr.Cells("SeleccionArticulos").Appearance.BackColor = Color.White
                        Else
                            rowGr.Cells("SeleccionArticulos").Appearance.BackColor = Color.LightSteelBlue
                        End If
                    End If
                End If
            End If
        Next

        For Each rowGr As UltraGridRow In grdModelos.Rows
            If CBool(rowGr.Cells("SeleccionArticulos").Text) = True Then
                contadorSeleccion += 1
                If rowGr.Cells("Estado").Value = "N" Then
                    contSinPrecio += 1
                ElseIf rowGr.Cells("Estado").Value = "P" Then
                    contPrecio += 1
                ElseIf rowGr.Cells("Estado").Value = "D" Then
                    contPrecioDif += 1
                End If
            End If
        Next
        lblSinPrecio.Text = contSinPrecio.ToString("N0")
        lblConPrecio.Text = contPrecio.ToString("N0")
        lblPrecioModificado.Text = contPrecioDif.ToString("N0")

        lblContArtsGuardar.Text = contadorSeleccion.ToString("N0")
    End Sub

    Private Sub rdoCambiar_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCambiar.CheckedChanged
        txtPrecioMultiple.Value = 0.0
        txtPrecioMultiple.Enabled = True
        txtCantidadMultiple.Text = 0.0
        txtCantidadMultiple.Enabled = False
        btnCargarPrecioMultiple.Enabled = False
    End Sub

    Private Sub rdoSumar_CheckedChanged(sender As Object, e As EventArgs) Handles grdDatosConf.CheckedChanged
        txtCantidadMultiple.Value = 0.0
        txtCantidadMultiple.Enabled = True
        txtPrecioMultiple.Value = 0.0
        txtPrecioMultiple.Enabled = False
        btnCargarPrecioMultiple.Enabled = False
    End Sub

    Private Sub rdoRestar_CheckedChanged(sender As Object, e As EventArgs) Handles rdoRestar.CheckedChanged
        txtCantidadMultiple.Value = 0.0
        txtCantidadMultiple.Enabled = True
        txtPrecioMultiple.Value = 0.0
        txtPrecioMultiple.Enabled = False
        btnCargarPrecioMultiple.Enabled = False
    End Sub

    Private Sub txtPrecioMultiple_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioMultiple.KeyDown
        If e.KeyCode = Keys.Enter Then
            If rdoCambiar.Checked = True Then
                asignarPrecios()
            End If
        End If
    End Sub

    Private Sub txtPrecioMultiple_ValueChanged(sender As Object, e As EventArgs) Handles txtPrecioMultiple.ValueChanged
        If txtPrecioMultiple.Value > 0 Then
            btnCargarPrecioMultiple.Enabled = True
        Else
            btnCargarPrecioMultiple.Enabled = False
        End If
    End Sub

    Private Sub txtCantidadMultiple_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadMultiple.KeyDown
        If e.KeyCode = Keys.Enter Then
            If rdoCambiar.Checked = True Then
                asignarCalcularPrecios()
            End If
        End If
    End Sub

    Private Sub txtCantidadMultiple_ValueChanged(sender As Object, e As EventArgs) Handles txtCantidadMultiple.ValueChanged
        If txtCantidadMultiple.Value > 0 Then
            btnCargarPrecioMultiple.Enabled = True
        Else
            btnCargarPrecioMultiple.Enabled = False
        End If
    End Sub

    Private Sub btnQuitarArticulo_Click(sender As Object, e As EventArgs) Handles btnQuitarArticulo.Click
        Dim objconf As New Tools.ConfirmarForm
        If grdModelos.ActiveRow.IsFilterRow = False Then
            If idListaVentasClientePrecio > 0 Then
                Try
                    Dim mensajeConf As String = "¿Está seguro de quitar el artículo de la lista de cliente?"

                    objconf.mensaje = mensajeConf
                    If objconf.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Dim idPrestilo As Int32 = 0

                        idPrestilo = grdModelos.ActiveRow.Cells("pres_productoestiloid").Value

                        quitarArticulo(idPrestilo)
                        grdModelos.ActiveRow.Cells("ArticulosGuardados").Value = 0
                        grdModelos.ActiveRow.Cells("SeleccionArticulos").Value = False
                        grdModelos.ActiveRow.Cells("SeleccionArticulos").Appearance.BackColor = Color.Red
                        grdModelos.ActiveRow.Cells("SeleccionArticulos").Activation = Activation.AllowEdit
                        grbQuitarArticulo.Enabled = False
                        lblListaOriginalCliente.Text = ""
                    End If
                Catch ex As Exception

                End Try

            End If

        End If
    End Sub

    Private Sub btnFormClientes_Click(sender As Object, e As EventArgs)
        If contConfiguracion <= 0 Then
            MsgBox("Para copiar la lista de precios a otros clientes es necesario guardarla primero.", MsgBoxStyle.Information, "Atención")
        ElseIf idListaCliente > 0 Then
            Dim objCopClientes As New altaCopiaClienteListaPrecio
            Dim objLCBU As New Negocios.ListaPreciosVentaClienteBU
            Dim dtDatosListaPreciosCLiente As New DataTable
            Dim contListasRelacionadas As Int32 = 0
            Try

                dtDatosListaPreciosCLiente = objLCBU.consultaListaPreciosClienteExiste(idListaCliente)
                If dtDatosListaPreciosCLiente.Rows.Count > 0 Then
                    objCopClientes.idListaVentas = dtDatosListaPreciosCLiente.Rows(0).Item("lvcl_listaprecioventasid").ToString
                    objCopClientes.idListaCliente = idListaCliente
                    objCopClientes.idCliente = cmbClientes.SelectedValue
                    objCopClientes.nombreGenerico = cmbClientes.Text.Trim
                    objCopClientes.listaventasdescripcion = cmbListaVentas.Text.Trim
                    objCopClientes.ShowDialog()
                    ' ''contListasRelacionadas = objLCBU.consultarContadorRelacionListaCliente(idListaCliente)
                    ' ''lblClientesCopiados.Text = contListasRelacionadas.ToString("N0")
                End If
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub lblListaVentas_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblListaVentas.LinkClicked
        abrirConfiguracionLP()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlDatos.Height = 25
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlDatos.Height = 220
    End Sub

    Private Sub chkTodosLosArticulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosLosArticulos.CheckedChanged
        If idListaVentasClientePrecio > 0 Then

            lblPrecioModificado.Text = "0"
            lblSinPrecio.Text = "0"
            lblConPrecio.Text = "0"
            llenarTablaModelos(idListaBase, idClienteFTC, idListaVentasClientePrecio, CBool(chkTodosLosArticulos.Checked))
            Me.Cursor = Cursors.Default
            Me.grdModelos.DisplayLayout.Override.FixedRowStyle = FixedRowStyle.Top

        End If

    End Sub

    Private Sub cmbListaVentas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListaVentas.SelectedIndexChanged

    End Sub


    Private Sub btnMostrarArticulos_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnRecalcular_Click(sender As Object, e As EventArgs) Handles btnRecalcular.Click
        If idMoneda > 1 And txtParidadActual.Text <> lblValorParidadPesos.Text Then
            Dim objMensaje As New Tools.ConfirmarForm
            objMensaje.mensaje = "Se recalcularán los precios con la paridad actual. ¿Desea continuar?"
            Dim resultado As DialogResult = objMensaje.ShowDialog
            If resultado = Windows.Forms.DialogResult.OK Then
                recalcularPreciosParidad()
            End If
        End If
    End Sub

    Private Sub chkDescuentoIncluido_CheckedChanged(sender As Object, e As EventArgs) Handles chkDescuentoIncluido.CheckedChanged
        ' ''verDescuentosClientes()
    End Sub

    Private Sub grdModelos_TextChanged(sender As Object, e As EventArgs) Handles grdModelos.TextChanged

    End Sub

    Private Sub btnExpPDF_Click(sender As Object, e As EventArgs) Handles btnExpPDF.Click
        If grdModelos.Rows.Count > 0 Then
            exportarPDF()
        Else
            MsgBox("No hay registros que exportar", MsgBoxStyle.Information, "")
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If grdModelos.Rows.Count > 0 Then
            exportarExcel()
        Else
            MsgBox("No hay registros que exportar", MsgBoxStyle.Information, "")
        End If
    End Sub

    Private Sub btnRegresarACapturada_Click(sender As Object, e As EventArgs) Handles btnRegresarACapturada.Click
        Dim objLCBU As New Negocios.ListaPreciosVentaClienteBU
        objLCBU.RegresarListaA_Capturada(idListaVentasCliente)
        llenarComboEstatus("")
    End Sub
End Class