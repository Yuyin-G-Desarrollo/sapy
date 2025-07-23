Imports Ventas.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class AltaConfiguracionListaVentas
    Public idListaBase As Int32 = 0
    Public codigoLB As String = ""
    Public nombreLista As String = ""
    Public estatusListaid As Int32 = 0
    Public estatusListaCad As String = ""
    Public accionPantalla As String = ""
    Public vigenciaInicio As Date
    Public vigenciaFin As Date
    Public idListaVentas As Int32 = 0
    Dim modificarFacturacion As Boolean = False
    Dim modificarIva As Boolean = False
    Dim esTemporal As Boolean = False
    Dim incrementoInicio As Double = 0
    Dim porcentajeInicio As Boolean = False

    Public Sub llenarDatosListaVentas()
        Dim objLVBU As New ListaVentasBU
        Dim dtDatosListaVentas As New DataTable
        Dim dtClientesListaVentas As New DataTable

        dtDatosListaVentas = objLVBU.consutaListaVentasDetalle(idListaVentas)

        If dtDatosListaVentas.Rows(0).Item("lpba_estatus").ToString = 1 Then
            lblEstatus.Text = "ACTIVA"
            estatusListaid = 1
            estatusListaCad = "ACTIVA"
        ElseIf dtDatosListaVentas.Rows(0).Item("lpba_estatus").ToString = 2 Then
            lblEstatus.Text = "AUTORIZADA"
            estatusListaid = 2
            estatusListaCad = "AUTORIZADA"
        Else
            lblEstatus.Text = "INACTIVA"
            estatusListaid = 3
            estatusListaCad = "INACTIVA"
        End If

        idListaBase = dtDatosListaVentas.Rows(0).Item("lpba_listapreciosbaseid").ToString

        txtListaBase.Text = dtDatosListaVentas.Rows(0).Item("lpba_nombrelista").ToString

        Dim fechainicio As String = dtDatosListaVentas.Rows(0).Item("lpvt_vigenciainicio")
        Dim fechafin As String = dtDatosListaVentas.Rows(0).Item("lpvt_vigenciafin")

        txtDigitoLista.Text = dtDatosListaVentas.Rows(0).Item("lpvt_codigolistaventa").ToString
        txtDescripcion.Text = dtDatosListaVentas.Rows(0).Item("lpvt_descripcion").ToString
        txtIncrementoPar.Value = dtDatosListaVentas.Rows(0).Item("lpvt_incrementoporpar").ToString
        incrementoInicio = dtDatosListaVentas.Rows(0).Item("lpvt_incrementoporpar").ToString
        dttVigenciaInicio.Value = CDate(fechainicio).ToShortDateString
        dttVigenciaFin.Value = CDate(fechafin).ToShortDateString
        txtDescuentoInicio.Value = dtDatosListaVentas.Rows(0).Item("lpvt_descuentoinicio").ToString
        txtDescuentoFin.Value = dtDatosListaVentas.Rows(0).Item("lpvt_descuentofin").ToString
        txtFacturacionInicio.Value = dtDatosListaVentas.Rows(0).Item("lpvt_facturacioninicio").ToString
        txtFacturacionFin.Value = dtDatosListaVentas.Rows(0).Item("lpvt_facturacionfin").ToString
        esTemporal = CBool(dtDatosListaVentas.Rows(0).Item("lpvt_estemporal"))

        If dtDatosListaVentas.Rows(0).Item("lpvt_eventoid").ToString = "" Then
            cmbEvento.SelectedIndex = 0

            If CBool(dtDatosListaVentas.Rows(0).Item("lpvt_porcentaje").ToString) = True Then
                rdoPorcentaje.Checked = True
                rdoPesos.Checked = False
                porcentajeInicio = True
            Else
                rdoPesos.Checked = True
                rdoPorcentaje.Checked = False
                porcentajeInicio = False
            End If

            If esTemporal = True Then
                grpDatos.Enabled = False
                pnlBotonCambiar.Enabled = False
                btnGuardar.Enabled = False
                lblGuardar.Enabled = False
                dtClientesListaVentas = objLVBU.consultaListaVentaTemporal(idListaBase, estatusListaid)
                grdClientes.DataSource = dtClientesListaVentas
                lblContarConfiguracion.Text = dtClientesListaVentas.Rows.Count.ToString("N0")
                If grdClientes.Rows.Count > 0 Then
                    disenogridClientes()
                    grdClientes.DisplayLayout.Bands(0).Columns("Seleccion").CellActivation = Activation.NoEdit
                    If grdClientes.DisplayLayout.Bands(0).Columns.Exists("Configuracion") Then
                        grdClientes.DisplayLayout.Bands(0).Columns("configuracion").Hidden = True
                    End If
                End If
            Else
                ejecutarConsultaClientes()
            End If
            If grdClientes.Rows.Count > 0 Then
                If estatusListaid <> 1 Then
                    If grdClientes.DisplayLayout.Bands(0).Columns.Exists("Configuracion") Then
                        grdClientes.DisplayLayout.Bands(0).Columns("configuracion").Hidden = True
                    End If
                End If
            End If
        Else
            cmbEvento.SelectedValue = dtDatosListaVentas.Rows(0).Item("lpvt_eventoid").ToString
            pnlBotonCambiar.Enabled = False
            grdClientes.DataSource = Nothing
            cargarClientes()
            lblContarConfiguracion.Text = "0"
            pnlCargarClientes.Enabled = True
        End If

    End Sub

    Public Sub llenarTablaIvaFlete()
        Dim objLVBU As New ListaVentasBU
        Dim dtDatosIva As New DataTable
        Dim dtDatosFlete As New DataTable
        If accionPantalla = "ALTA" Then
            dtDatosIva = objLVBU.tipoIva("ALTA", 0)
            grdListaTipoIva.DataSource = dtDatosIva
            grdListaTipoIva.DisplayLayout.Bands(0).Columns.Add("SeleccionIva", "Seleccion")
            Dim colSeleccionIva As UltraGridColumn = grdListaTipoIva.DisplayLayout.Bands(0).Columns("SeleccionIva")
            colSeleccionIva.DefaultCellValue = False
            colSeleccionIva.Header.Caption = ""
            colSeleccionIva.Style = ColumnStyle.CheckBox
            dtDatosFlete = objLVBU.tipoFlete("ALTA", 0)
            grdTipoFlete.DataSource = dtDatosFlete
            grdTipoFlete.DisplayLayout.Bands(0).Columns.Add("SeleccionFlete", "Seleccion")
            Dim colSeleccionFlete As UltraGridColumn = grdTipoFlete.DisplayLayout.Bands(0).Columns("SeleccionFlete")
            colSeleccionFlete.DefaultCellValue = False
            colSeleccionFlete.Header.Caption = ""
            colSeleccionFlete.Style = ColumnStyle.CheckBox
            For Each rowI As UltraGridRow In grdListaTipoIva.Rows
                rowI.Cells("SeleccionIva").Value = False
            Next
            For Each rowF As UltraGridRow In grdTipoFlete.Rows
                rowF.Cells("SeleccionFlete").Value = False
            Next
        ElseIf accionPantalla = "EDITAR" Or accionPantalla = "CONSULTA" Then
            dtDatosIva = objLVBU.tipoIva("EDITAR", idListaVentas)
            grdListaTipoIva.DataSource = dtDatosIva
            Dim colSeleccionIva As UltraGridColumn = grdListaTipoIva.DisplayLayout.Bands(0).Columns("SeleccionIva")
            colSeleccionIva.Header.Caption = ""
            colSeleccionIva.Style = ColumnStyle.CheckBox
            dtDatosFlete = objLVBU.tipoFlete("EDITAR", idListaVentas)
            grdTipoFlete.DataSource = dtDatosFlete
            Dim colSeleccionFlete As UltraGridColumn = grdTipoFlete.DisplayLayout.Bands(0).Columns("SeleccionFlete")
            colSeleccionFlete.Header.Caption = ""
            colSeleccionFlete.Style = ColumnStyle.CheckBox
        End If
        disenosGrids()
    End Sub

    Public Sub disenosGrids()
        With grdListaTipoIva.DisplayLayout.Bands(0)
            .Columns("tiva_tipoivaid").Hidden = True
            .Columns("tiva_nombre").Header.Caption = "Tipo Iva"
            .Columns("tiva_nombre").CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        With grdTipoFlete.DisplayLayout.Bands(0)
            .Columns("tifl_tipofleteid").Hidden = True
            .Columns("tifl_nombre").Header.Caption = "Tipo Flete"
            .Columns("tifl_nombre").CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListaTipoIva.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListaTipoIva.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.VisibleIndex
        grdTipoFlete.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdTipoFlete.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.VisibleIndex
    End Sub

    Public Sub cargarClientes()
        Dim objListaClientes As New ListaVentasBU
        If txtDescuentoFin.Value >= txtDescuentoInicio.Value Then
            If txtFacturacionFin.Value >= txtFacturacionInicio.Value Then
                Dim contTipoIVA As Int32 = 0
                For Each rowGTI As UltraGridRow In grdListaTipoIva.Rows
                    If CBool(rowGTI.Cells("SeleccionIva").Value) = True Then
                        contTipoIVA += 1
                    End If
                Next
                If contTipoIVA > 0 Then
                    Dim contTipoFlete As Int32 = 0
                    For Each rowGTF As UltraGridRow In grdTipoFlete.Rows
                        If CBool(rowGTF.Cells("SeleccionFlete").Value) = True Then
                            contTipoFlete += 1
                        End If
                    Next
                    If contTipoFlete > 0 Then
                        ejecutarConsultaClientes()
                    Else
                        Dim objMensajeAd As New Tools.AdvertenciaForm
                        objMensajeAd.mensaje = "Debe seleccionar al menos un tipo de Flete."
                        objMensajeAd.ShowDialog()
                    End If
                Else
                    Dim objMensajeAd As New Tools.AdvertenciaForm
                    objMensajeAd.mensaje = "Debe seleccionar al menos un tipo de IVA."
                    objMensajeAd.ShowDialog()
                End If
            Else
                Dim objMensajeAd As New Tools.AdvertenciaForm
                objMensajeAd.mensaje = "La cantidad Facturación Fin no puede ser menor a la de Facturación inicio."
                objMensajeAd.ShowDialog()
            End If
        Else
            Dim objMensajeAd As New Tools.AdvertenciaForm
            objMensajeAd.mensaje = "La cantidad Descuento Fin no puede ser menor a la de Descuento inicio."
            objMensajeAd.ShowDialog()
        End If
    End Sub

    Public Sub ejecutarConsultaClientesSimularCambios()
        Dim OBJlvbu As New ListaVentasBU
        Dim cambioColorIVA As Boolean = False
        For Each rowGrid As UltraGridRow In grdClientes.Rows
            If rowGrid.Cells("Descuento").Value > txtDescuentoFin.Value Or rowGrid.Cells("Descuento").Value < txtDescuentoInicio.Value Or
                rowGrid.Cells("iccl_facturar").Value > txtFacturacionFin.Value Or rowGrid.Cells("iccl_facturar").Value < txtFacturacionInicio.Value Then
                rowGrid.Cells("Seleccion").Appearance.BackColor = Color.Red
            Else
                For Each rowIva As UltraGridRow In grdListaTipoIva.Rows
                    If rowGrid.Cells("IdIvaAntes").Value = rowIva.Cells(0).Value Then
                        If CBool(rowIva.Cells("SeleccionIva").Value) = False Then
                            rowGrid.Cells("Seleccion").Appearance.BackColor = Color.Red
                            cambioColorIVA = True
                        End If
                    End If
                Next
                If cambioColorIVA = False Then
                    If rowGrid.Index Mod 2 = 0 Then
                        rowGrid.Cells("Seleccion").Appearance.BackColor = Color.White
                    Else
                        rowGrid.Cells("Seleccion").Appearance.BackColor = Color.LightSteelBlue
                    End If
                End If

            End If
        Next
        Dim dtClientesAfectados As New DataTable
        Dim fletesQuitar As String = "", fletes As String = ""
        For Each rowGr As UltraGridRow In grdTipoFlete.Rows
            If CBool(rowGr.Cells(2).Value) = False Then
                fletesQuitar += rowGr.Cells(0).Value.ToString + ","
            ElseIf CBool(rowGr.Cells(2).Value) = True Then
                fletes += rowGr.Cells(0).Value.ToString + ","
            End If
        Next
        fletesQuitar = fletesQuitar + "0"
        fletes = fletes + "0"
        dtClientesAfectados = OBJlvbu.consultaClienteFleteCambioConf(fletesQuitar, fletes, idListaVentas)
        For Each rowDT As DataRow In dtClientesAfectados.Rows
            For Each rowGrd As UltraGridRow In grdClientes.Rows
                If rowDT.Item("iccl_clienteid") = rowGrd.Cells("clie_clienteid").Value And rowGrd.Cells("registroAnt").Value = 1 Then
                    rowGrd.Cells("Seleccion").Appearance.BackColor = Color.Red
                End If
            Next
        Next
    End Sub

    Public Sub ejecutarConsultaClientes()
        Dim dtDatosClientes As New DataTable
        Dim objLVBU As New Negocios.ListaVentasBU
        Dim tipoIvaCadena As String = ""
        Dim tipoFleteCadena As String = ""
        For Each rowGTI As UltraGridRow In grdListaTipoIva.Rows
            If CBool(rowGTI.Cells("SeleccionIva").Value) = True Then
                If tipoIvaCadena = "" Then
                    tipoIvaCadena += rowGTI.Cells("tiva_tipoivaid").Value.ToString
                Else
                    tipoIvaCadena += ", " + rowGTI.Cells("tiva_tipoivaid").Value.ToString
                End If

            End If
        Next
        For Each rowGTF As UltraGridRow In grdTipoFlete.Rows
            If CBool(rowGTF.Cells("SeleccionFlete").Value) = True Then
                If tipoFleteCadena = "" Then
                    tipoFleteCadena += rowGTF.Cells("tifl_tipofleteid").Value.ToString
                Else
                    tipoFleteCadena += ", " + rowGTF.Cells("tifl_tipofleteid").Value.ToString
                End If
            End If
        Next
        If accionPantalla = "ALTA" Then
            dtDatosClientes = objLVBU.listaClienteVentasSelect(txtDescuentoInicio.Value.ToString, txtDescuentoFin.Value.ToString, txtFacturacionInicio.Value.ToString, txtFacturacionFin.Value.ToString, tipoIvaCadena, tipoFleteCadena, idListaBase)
            If dtDatosClientes.Rows.Count > 0 Then
                grdClientes.DataSource = dtDatosClientes
                lblContarConfiguracion.Text = dtDatosClientes.Rows.Count.ToString("N0")
                If grdClientes.Rows.Count > 0 Then
                    disenogridClientes()
                End If
            End If
        ElseIf accionPantalla = "EDITAR" Or accionPantalla = "CONSULTA" Then
            dtDatosClientes = objLVBU.consultaListaVentaMasClientes(idListaVentas, txtDescuentoInicio.Value.ToString, txtDescuentoFin.Value.ToString, txtFacturacionInicio.Value.ToString, txtFacturacionFin.Value.ToString, tipoIvaCadena, tipoFleteCadena, idListaBase)
            If dtDatosClientes.Rows.Count > 0 Then
                grdClientes.DataSource = Nothing
                lblContarConfiguracion.Text = "0"
                If dtDatosClientes.Rows.Count > 0 Then
                    grdClientes.DataSource = dtDatosClientes
                    lblContarConfiguracion.Text = dtDatosClientes.Rows.Count.ToString("N0")
                    disenogridClientes()
                End If
            End If
        End If

    End Sub

    Public Sub disenogridClientes()
        Dim colSeleccion As UltraGridColumn = grdClientes.DisplayLayout.Bands(0).Columns("Seleccion")
        colSeleccion.Header.Caption = ""
        colSeleccion.Style = ColumnStyle.CheckBox
        colSeleccion.Header.VisiblePosition = 0
        If (accionPantalla = "EDITAR" Or accionPantalla = "CONSULTA") And estatusListaid = 1 Then
            Dim colConfiguracion As UltraGridColumn = grdClientes.DisplayLayout.Bands(0).Columns("Configuracion")
            colConfiguracion.Header.Caption = "Conf"
            colConfiguracion.Style = ColumnStyle.Image
        ElseIf (accionPantalla = "EDITAR" Or accionPantalla = "CONSULTA") And estatusListaid <> 1 Then
            grdClientes.DisplayLayout.Bands(0).Columns("Configuracion").Hidden = True
        End If
        If accionPantalla = "EDITAR" Or accionPantalla = "CONSULTA" Then
            Dim contadorSeleccion As Int32 = 0
            For Each rowGR As UltraGridRow In grdClientes.Rows
                If CBool(rowGR.Cells("Seleccion").Text) = True Then
                    contadorSeleccion += 1
                End If

                If rowGR.Cells("RegistroAnt").Text = 0 Then
                    rowGR.Cells("iccl_facturar").Activation = Activation.NoEdit
                    rowGR.Cells("tifl_nombre").Activation = Activation.NoEdit
                    rowGR.Cells("tiva_nombre").Activation = Activation.NoEdit
                    ''If grdClientes.DisplayLayout.Bands(0).Columns.Exists("LVCDESCRIPCION") Then
                    ''    rowGR.Cells("LVCDESCRIPCION").Activation = Activation.NoEdit
                    ''End If
                End If
            Next
            lblContClientes.Text = contadorSeleccion.ToString("N0")
        End If

        With grdClientes.DisplayLayout.Bands(0)
            .Columns("iccl_tipoivaid").Hidden = True
            .Columns("FacturarAntes").Hidden = True
            .Columns("IdIvaAntes").Hidden = True
            .Columns("iccl_tipoivaid").Hidden = True
            .Columns("RegistroAnt").Hidden = True
            .Columns("iccl_tipofleteid").Hidden = True
            .Columns("iccl_monedaid").Hidden = True
            If .Columns.Exists("LPVCS") Then
                .Columns("LPVCS").Hidden = True
            End If
            If .Columns.Exists("LISTAVENTACLIENTE") Then
                .Columns("LISTAVENTACLIENTE").Hidden = True
            End If
            If .Columns.Exists("LISTAVENTA") Then
                .Columns("LISTAVENTA").Hidden = True
            End If
            ' ''If .Columns.Exists("LVCDESCRIPCION") Then
            ' ''    .Columns("LVCDESCRIPCION").Header.Caption = "*Descripción"
            ' ''End If
            .Columns("clie_clienteid").Header.Caption = "Id SAY"
            .Columns("clie_idsicy").Header.Caption = "Id SICY"
            .Columns("clie_nombregenerico").Header.Caption = "Cliente"
            .Columns("tiva_nombre").Header.Caption = "*IVA"
            .Columns("iccl_facturar").Header.Caption = "*Facturación"
            .Columns("tifl_nombre").Header.Caption = "*Flete"
            .Columns("mone_nombre").Header.Caption = "Moneda"
            .Columns("Descuento").Header.Caption = "*Descuento"
            .Columns("lvAnterior").Header.Caption = "*LV Anterior"
            .Columns("clie_clienteid").CellActivation = Activation.NoEdit
            .Columns("clie_idsicy").CellActivation = Activation.NoEdit
            .Columns("clie_nombregenerico").CellActivation = Activation.NoEdit
            .Columns("mone_nombre").CellActivation = Activation.NoEdit
            .Columns("lvAnterior").CellActivation = Activation.NoEdit
            If accionPantalla = "ALTA" Then
                .Columns("iccl_facturar").CellActivation = Activation.NoEdit
                .Columns("tifl_nombre").CellActivation = Activation.NoEdit
                .Columns("tiva_nombre").CellActivation = Activation.NoEdit
            End If
            If estatusListaid = 1 Then
                Dim colFacturar As UltraGridColumn = grdClientes.DisplayLayout.Bands(0).Columns("iccl_facturar")
                colFacturar.DefaultCellValue = False
                colFacturar.Style = ColumnStyle.DoubleNonNegative
                colFacturar.MinValue = txtFacturacionInicio.Value
                colFacturar.MaxValue = txtFacturacionFin.Value
            Else
                .Columns("iccl_facturar").CellActivation = Activation.NoEdit
                .Columns("tifl_nombre").CellActivation = Activation.NoEdit
                .Columns("tiva_nombre").CellActivation = Activation.NoEdit
            End If
            .Columns("Descuento").CellActivation = Activation.NoEdit
            .Columns("clie_clienteid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("clie_idsicy").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("iccl_facturar").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Descuento").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("lvAnterior").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

            .Columns("clie_clienteid").Width = 50
            .Columns("clie_idsicy").Width = 50
            .Columns("Seleccion").Width = 50
            .Columns("clie_nombregenerico").Width = 300
        End With

        Dim dtIVA As New DataTable
        Dim dtFlete As New DataTable
        Dim listaValoresIva As New ValueList
        Dim listaValoresFlete As New ValueList
        Dim objLVBU As New ListaVentasBU
        dtIVA = objLVBU.tipoIva("EDITAR", idListaVentas)
        dtFlete = objLVBU.tipoFlete(idListaVentas)
        For Each rowDt As DataRow In dtIVA.Rows
            If rowDt.Item("SeleccionIva").ToString <> "0" Then
                listaValoresIva.ValueListItems.Add(rowDt.Item("tiva_tipoivaid"), rowDt.Item("tiva_nombre").ToString.Trim)
            End If
        Next

        For Each rowDt As DataRow In dtFlete.Rows
            If rowDt.Item("SeleccionFlete").ToString <> "0" Then
                listaValoresFlete.ValueListItems.Add(rowDt.Item("tifl_tipofleteid"), rowDt.Item("tifl_nombre").ToString.Trim)
            End If
        Next
        grdClientes.DisplayLayout.Bands(0).Columns("tiva_nombre").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        grdClientes.DisplayLayout.Bands(0).Columns("tiva_nombre").ValueList = listaValoresIva
        grdClientes.DisplayLayout.Bands(0).Columns("tifl_nombre").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        grdClientes.DisplayLayout.Bands(0).Columns("tifl_nombre").ValueList = listaValoresFlete
        If estatusListaid <> 1 Then
            grdClientes.DisplayLayout.Bands(0).Columns("tiva_nombre").CellActivation = Activation.NoEdit
            grdClientes.DisplayLayout.Bands(0).Columns("tifl_nombre").CellActivation = Activation.NoEdit
            grdClientes.DisplayLayout.Bands(0).Columns("tiva_nombre").CellActivation = Activation.NoEdit
        End If
        If accionPantalla = "CONSULTA" Then
            grdClientes.DisplayLayout.Bands(0).Columns("Seleccion").CellActivation = Activation.NoEdit
        End If
        grdClientes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdClientes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdClientes.DisplayLayout.Override.RowSelectorWidth = 35
        grdClientes.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdClientes.Rows(0).Selected = True
    End Sub

    Public Function validarDigito() As Boolean
        Dim objLVBU As New ListaVentasBU
        Dim dtValor As New DataTable
        Try
            If accionPantalla = "ALTA" Then
                If idListaBase > 0 And txtDigitoLista.Text.Length > 0 Then
                    dtValor = objLVBU.comprobarDigitoListaVenta(idListaBase, txtDigitoLista.Text, 0, "ALTA")
                    If dtValor.Rows(0).Item(0) > 0 Then
                        MsgBox("El digito " + txtDigitoLista.Text + " está siendo usado por otra lista de ventas en una misma lista de precios base.")
                        txtDigitoLista.Text = ""
                        Return False
                    Else
                        txtDescripcion.Focus()
                    End If
                Else
                    txtDigitoLista.Text = ""
                End If
            ElseIf accionPantalla = "EDITAR" Then
                If idListaBase > 0 And txtDigitoLista.Text.Length > 0 Then
                    dtValor = objLVBU.comprobarDigitoListaVenta(idListaBase, txtDigitoLista.Text, idListaVentas, "EDITAR")
                    If dtValor.Rows(0).Item(0) > 0 Then
                        MsgBox("El digito " + txtDigitoLista.Text + " está siendo usado por otra lista de ventas en una misma lista de precios base.")
                        txtDigitoLista.Text = ""
                        Return False
                    Else
                        txtDescripcion.Focus()
                    End If
                Else
                    txtDigitoLista.Text = ""
                End If
            Else
                txtDigitoLista.Text = ""
            End If
        Catch ex As Exception
            txtDigitoLista.Text = ""
        End Try
        Return True
    End Function

    Public Function validarFechasVigenciaHoy() As Boolean
        If dttVigenciaFin.Value.ToShortDateString < Date.Now Then
            lblVigenciaFin.ForeColor = Color.Red
            Return False
        Else
            lblVigenciaFin.ForeColor = Color.Black
        End If
        Return True
    End Function

    Public Function validarFechasVigencia() As Boolean
        If dttVigenciaInicio.Value > dttVigenciaFin.Value Then
            lblVigenciaInicio.ForeColor = Color.Red
            lblVigenciaFin.ForeColor = Color.Red
            Return False
        Else
            lblVigenciaInicio.ForeColor = Color.Black
            lblVigenciaFin.ForeColor = Color.Black
        End If
        Return True
    End Function

    Public Function validarDatosGeneralListaVnts() As Boolean
        Try
            If idListaBase = 0 Or txtDigitoLista.Text = "" Or txtDescripcion.Text = "" Or txtIncrementoPar.Value <= 0 Then
                If idListaBase = 0 Then
                    lblListaBase.ForeColor = Color.Red
                Else
                    lblListaBase.ForeColor = Color.Black
                End If

                If txtDigitoLista.Text.Trim = "" Then
                    lblListaVentas.ForeColor = Color.Red
                Else
                    lblListaVentas.ForeColor = Color.Black
                End If

                If txtDescripcion.Text.Trim = "" Then
                    lblDescripcion.ForeColor = Color.Red
                Else
                    lblDescripcion.ForeColor = Color.Black
                End If

                If txtIncrementoPar.Value <= 0 Then
                    lblIncrementoPar.ForeColor = Color.Red
                Else
                    lblIncrementoPar.ForeColor = Color.Black
                End If
                Return False
            Else
                lblListaBase.ForeColor = Color.Black
                lblListaVentas.ForeColor = Color.Black
                lblDescripcion.ForeColor = Color.Black
                lblIncrementoPar.ForeColor = Color.Black
                lblClientes.ForeColor = Color.Black
            End If
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function validarRangos() As Boolean
        Dim contIvas As Int32 = 0
        Dim contFletes As Int32 = 0
        For Each rowGi As UltraGridRow In grdListaTipoIva.Rows
            If CBool(rowGi.Cells("SeleccionIva").Value) = True Then
                contIvas += 1
            End If
        Next
        For Each rowGf As UltraGridRow In grdTipoFlete.Rows
            If CBool(rowGf.Cells("SeleccionFlete").Value) = True Then
                contFletes += 1
            End If
        Next
        If txtDescuentoInicio.Value > txtDescuentoFin.Value Or txtFacturacionInicio.Value > txtFacturacionFin.Value Or contIvas = 0 Or contFletes = 0 Then
            If txtDescuentoInicio.Value > txtDescuentoFin.Value Then
                lblRangoDescuento.ForeColor = Color.Red
            Else
                lblRangoDescuento.ForeColor = Color.Black
            End If
            If txtFacturacionInicio.Value > txtFacturacionFin.Value Then
                lblPorcentajeFactura.ForeColor = Color.Red
            Else
                lblPorcentajeFactura.ForeColor = Color.Black
            End If
            If contIvas = 0 Then
                lblTipoIva.ForeColor = Color.Red
            Else
                lblTipoIva.ForeColor = Color.Black
            End If
            If contFletes = 0 Then
                lblTipoFlete.ForeColor = Color.Red
            Else
                lblTipoFlete.ForeColor = Color.Black
            End If
            Return False
        Else
            lblRangoDescuento.ForeColor = Color.Black
            lblPorcentajeFactura.ForeColor = Color.Black
            lblTipoIva.ForeColor = Color.Black
            lblTipoFlete.ForeColor = Color.Black
        End If
        Return True
    End Function

    Public Sub guardarCambiosClientesListaVenta()
        Dim objLVBU As New ListaVentasBU
        '' ''If txtIncrementoPar.Value = incrementoInicio And CBool(rdoPorcentaje.Checked) = porcentajeInicio Then
        '' ''    objLVBU.editarEncabezadoListaVentas(txtDigitoLista.Text, txtDescripcion.Text, dttVigenciaInicio.Value.ToString, dttVigenciaFin.Value.ToString, idListaVentas, porcentajeInicio, incrementoInicio, False, True)
        '' ''Else
        '' ''    If estatusListaid = 2 Then
        '' ''        objLVBU.editarEncabezadoListaVentas(txtDigitoLista.Text, txtDescripcion.Text, dttVigenciaInicio.Value.ToString, dttVigenciaFin.Value.ToString, idListaVentas, CBool(rdoPorcentaje.Checked), txtIncrementoPar.Value, True, True)

        '' ''    ElseIf estatusListaid = 1 Then
        '' ''        objLVBU.editarEncabezadoListaVentas(txtDigitoLista.Text, txtDescripcion.Text, dttVigenciaInicio.Value.ToString, dttVigenciaFin.Value.ToString, idListaVentas, porcentajeInicio, incrementoInicio, False, True)
        '' ''    End If
        '' ''End If


        If txtIncrementoPar.Value = incrementoInicio And CBool(rdoPorcentaje.Checked) = porcentajeInicio Then
            objLVBU.editarEncabezadoListaVentas(txtDigitoLista.Text, txtDescripcion.Text, dttVigenciaInicio.Value.ToString, dttVigenciaFin.Value.ToString, idListaVentas, CBool(rdoPorcentaje.Checked), txtIncrementoPar.Value, False, True)
        Else
            If estatusListaid = 2 Then
                objLVBU.editarEncabezadoListaVentas(txtDigitoLista.Text, txtDescripcion.Text, dttVigenciaInicio.Value.ToString, dttVigenciaFin.Value.ToString, idListaVentas, CBool(rdoPorcentaje.Checked), txtIncrementoPar.Value, True, True)

            ElseIf estatusListaid = 1 Then
                objLVBU.editarEncabezadoListaVentas(txtDigitoLista.Text, txtDescripcion.Text, dttVigenciaInicio.Value.ToString, dttVigenciaFin.Value.ToString, idListaVentas, CBool(rdoPorcentaje.Checked), txtIncrementoPar.Value, False, True)
            End If
        End If

        For Each rowCL As UltraGridRow In grdClientes.Rows
            If CBool(rowCL.Cells("Seleccion").Value) = True And rowCL.Cells("registroAnt").Value = "0" Then
                objLVBU.registrarClienteListaVentas(idListaVentas, rowCL.Cells("clie_clienteid").Value.ToString, idListaBase)
            End If

            If CBool(rowCL.Cells("Seleccion").Text) = False And rowCL.Cells("registroAnt").Text = "1" Then
                objLVBU.inactivarRelacionClienteListaVenta(idListaBase, idListaVentas, rowCL.Cells("LISTAVENTACLIENTE").Value, rowCL.Cells("clie_clienteid").Value)

            End If
        Next

    End Sub

    Public Sub guardarListaVentas()
        Dim objLBBU As New ListaBaseBU
        Dim objLVBU As New ListaVentasBU
        Dim dtEstiloPrecio As New DataTable
        Dim evento As Int32 = 0
        If cmbEvento.SelectedIndex > 0 Then
            evento = cmbEvento.SelectedValue
        End If
        Dim dtIdListaNueva As DataTable = objLVBU.registrarDatosListaVentas(idListaBase, txtDigitoLista.Text, txtDescripcion.Text,
                                            txtIncrementoPar.Value.ToString, CBool(rdoPorcentaje.Checked), dttVigenciaInicio.Value.Date, dttVigenciaFin.Value.Date,
                                             txtFacturacionInicio.Value.ToString, txtFacturacionFin.Value.ToString, txtDescuentoInicio.Value.ToString, txtDescuentoFin.Value.ToString, evento)
        idListaVentas = CInt(dtIdListaNueva.Rows(0).Item(0).ToString)
        If idListaVentas <> 0 Then
            For Each rowDT As UltraGridRow In grdListaTipoIva.Rows
                If CBool(rowDT.Cells("SeleccionIva").Value) = True Then
                    objLVBU.registrarIvaFlete(idListaVentas, CInt(rowDT.Cells("tiva_tipoivaid").Value.ToString), "TIPOIVA")
                End If
            Next
            For Each rowGTF As UltraGridRow In grdTipoFlete.Rows
                If CBool(rowGTF.Cells("SeleccionFlete").Value) = True Then
                    objLVBU.registrarIvaFlete(idListaVentas, CInt(rowGTF.Cells("tifl_tipofleteid").Value.ToString), "TIPOFLETE")
                End If
            Next
            For Each rowCL As UltraGridRow In grdClientes.Rows
                If CBool(rowCL.Cells("Seleccion").Text) = True Then
                    objLVBU.registrarClienteListaVentas(idListaVentas, rowCL.Cells("clie_clienteid").Value.ToString, idListaBase)
                End If
            Next
        Else
            MsgBox("Error en el proceso.", MsgBoxStyle.Critical, "")
            Me.Close()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub guardarCambiosConfiguracion()
        Dim objLVBU As New Negocios.ListaVentasBU
        objLVBU.editarConfiguracionListaVentas(idListaVentas, txtFacturacionInicio.Value.ToString, txtFacturacionFin.Value.ToString, txtDescuentoInicio.Value.ToString, txtDescuentoFin.Value.ToString)
        For Each rowGrd As UltraGridRow In grdListaTipoIva.Rows
            If CBool(rowGrd.Cells("SeleccionIva").Value) = False Then
                objLVBU.inactivarCatalogosSimples("TIPOIVA", idListaVentas, rowGrd.Cells("tiva_tipoivaid").Value)
            ElseIf CBool(rowGrd.Cells("SeleccionIva").Value) = True Then
                objLVBU.registrarIvaFlete(idListaVentas, rowGrd.Cells("tiva_tipoivaid").Value, "TIPOIVA")
            End If
        Next
        For Each rowGr As UltraGridRow In grdTipoFlete.Rows
            If CBool(rowGr.Cells(2).Value) = True Then
                objLVBU.registrarIvaFlete(idListaVentas, rowGr.Cells("tifl_tipofleteid").Value, "TIPOFLETE")
            ElseIf CBool(rowGr.Cells(2).Value) = False Then
                objLVBU.inactivarCatalogosSimples("TIPOFLETE", idListaVentas, rowGr.Cells("tifl_tipofleteid").Value)
            End If
        Next
        For Each rowgrd As UltraGridRow In grdClientes.Rows
            If rowgrd.Cells("Seleccion").Appearance.BackColor = Color.Red And rowgrd.Cells("registroAnt").Value = 1 Then
                objLVBU.inactivarRelacionClienteListaVenta(idListaBase, idListaVentas, rowgrd.Cells("LISTAVENTACLIENTE").Value, rowgrd.Cells("clie_clienteid").Value)
            End If
        Next
    End Sub

    Public Sub llenarComboEventos()
        Dim objLVBU As New ListaVentasBU
        Dim dtEventos As New DataTable
        dtEventos = objLVBU.consultaEventos
        dtEventos.Rows.InsertAt(dtEventos.NewRow, 0)
        cmbEvento.DataSource = dtEventos
        cmbEvento.DisplayMember = "EVENTO"
        cmbEvento.ValueMember = "even_eventoid"
    End Sub

    Public Function validarExisteLVCPS() As Boolean
        Dim contRojos As Int32 = 0
        Dim contAmarillos As Int32 = 0

        For Each rowGrd As UltraGridRow In grdClientes.Rows
            If rowGrd.Cells("Seleccion").Appearance.BackColor = Color.Red Then
                contRojos += 1
            End If
        Next
        For Each rowGrd As UltraGridRow In grdClientes.Rows
            If rowGrd.Cells("LPVCS").Value > 0 And CBool(rowGrd.Cells("Seleccion").Value) = True And rowGrd.Cells("Seleccion").Appearance.BackColor = Color.Red Then
                contAmarillos += 1
            End If
        Next
        If contRojos > 0 And contAmarillos > 0 Then
            Return False
        End If
        Return True
    End Function

    Public Sub inactivarCambioIncrementoSiHayListasClientes()
        Dim contAmarillos As Int32 = 0
        For Each rowGrd As UltraGridRow In grdClientes.Rows
            If rowGrd.Cells("LPVCS").Value > 0 Then
                contAmarillos += 1
            End If
        Next
        If contAmarillos > 0 Then
            txtIncrementoPar.Enabled = False
        End If
    End Sub

    ' ''{----------------------------------- Metodos VB -----------------------------------------}'

    Private Sub AltaConfiguracionListaVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If accionPantalla = "ALTA" Then
            If codigoLB <> "" Then
                lblCodigoLB.Text = codigoLB + "-"
            End If
            txtListaBase.Text = nombreLista
            If estatusListaid = 1 Then
                lblEstatus.ForeColor = Color.DarkOrange
            ElseIf estatusListaid = 2 Then
                lblEstatus.ForeColor = Color.LimeGreen
                pctEngrane.Visible = False
                lblConfMensaje.Visible = False
            Else
                lblEstatus.ForeColor = Color.Red
                pctEngrane.Visible = False
                lblConfMensaje.Visible = False
            End If
            lblEstatus.Text = estatusListaCad
            dttVigenciaInicio.MaxDate = vigenciaFin
            dttVigenciaInicio.MinDate = vigenciaInicio.ToShortDateString
            dttVigenciaFin.MaxDate = vigenciaFin.ToShortDateString
            dttVigenciaFin.MinDate = vigenciaInicio.ToShortDateString
            dttVigenciaInicio.Value = vigenciaInicio.ToShortDateString
            dttVigenciaFin.Value = vigenciaFin.ToShortDateString
            llenarTablaIvaFlete()
            txtDigitoLista.Focus()
            pnlSimular.Enabled = False
            cmbEvento.Enabled = True
            llenarComboEventos()
        ElseIf accionPantalla = "EDITAR" And idListaVentas <> 0 Then
            Dim objLVBU As New ListaVentasBU
            Dim dtFechasConfLVCP As New DataTable
            Dim fechaMinLVCP As String = ""
            Dim fechaMaxLVCP As String = ""

            llenarComboEventos()
            llenarTablaIvaFlete()
            llenarDatosListaVentas()
            pnlConfiguracion.Enabled = False
            pnlConfiguracionGrids.Enabled = False
            pnlSimular.Enabled = False
            btnCambiarConfig.Visible = True
            lblCambiarConfiguracion.Visible = True
            If codigoLB <> "" Then
                lblCodigoLB.Text = codigoLB + "-"
            End If
            txtListaBase.Text = nombreLista
            If estatusListaid = 1 Then
                lblEstatus.ForeColor = Color.DarkOrange
            ElseIf estatusListaid = 2 Then
                lblEstatus.ForeColor = Color.LimeGreen
                pctEngrane.Visible = False
                lblConfMensaje.Visible = False
            Else
                lblEstatus.ForeColor = Color.Red
                pctEngrane.Visible = False
                lblConfMensaje.Visible = False
            End If
            lblEstatus.Text = estatusListaCad
            dttVigenciaInicio.MaxDate = vigenciaFin.ToShortDateString
            dttVigenciaInicio.MinDate = vigenciaInicio.ToShortDateString
            dttVigenciaFin.MaxDate = vigenciaFin.ToShortDateString
            dttVigenciaFin.MinDate = vigenciaInicio.ToShortDateString

            dtFechasConfLVCP = objLVBU.consultaminVigencias(idListaVentas)
            If dtFechasConfLVCP.Rows.Count > 0 Then
                If dtFechasConfLVCP.Rows(0).Item(0).ToString <> "" Then
                    fechaMinLVCP = dtFechasConfLVCP.Rows(0).Item(0).ToString
                    fechaMaxLVCP = dtFechasConfLVCP.Rows(1).Item(0).ToString
                    dttVigenciaInicio.MaxDate = CDate(fechaMinLVCP).ToShortDateString
                    dttVigenciaFin.MinDate = CDate(fechaMaxLVCP).ToShortDateString
                End If
            End If
            cmbEvento.Enabled = False
            pnlCargarClientes.Enabled = False
            If esTemporal = False Then
                inactivarCambioIncrementoSiHayListasClientes()
            End If
        ElseIf accionPantalla = "CONSULTA" And idListaVentas <> 0 Then
            llenarComboEventos()
            llenarTablaIvaFlete()
            llenarDatosListaVentas()
            pnlConfiguracion.Enabled = False
            pnlConfiguracionGrids.Enabled = False
            pnlSimular.Enabled = False
            btnCambiarConfig.Visible = True
            lblCambiarConfiguracion.Visible = True
            If codigoLB <> "" Then
                lblCodigoLB.Text = codigoLB + "-"
            End If
            txtListaBase.Text = nombreLista
            If estatusListaid = 1 Then
                lblEstatus.ForeColor = Color.DarkOrange
            ElseIf estatusListaid = 2 Then
                lblEstatus.ForeColor = Color.LimeGreen
                pctEngrane.Visible = False
                lblConfMensaje.Visible = False
            Else
                lblEstatus.ForeColor = Color.Red
                pctEngrane.Visible = False
                lblConfMensaje.Visible = False
            End If
            lblEstatus.Text = estatusListaCad
            dttVigenciaInicio.MaxDate = vigenciaFin.ToShortDateString
            dttVigenciaInicio.MinDate = vigenciaInicio.ToShortDateString
            dttVigenciaFin.MaxDate = vigenciaFin.ToShortDateString
            dttVigenciaFin.MinDate = vigenciaInicio.ToShortDateString
            cmbEvento.Enabled = False
            pnlCargarClientes.Enabled = False
            pnlBotonCambiar.Enabled = False
            btnGuardar.Enabled = False
            lblGuardar.Enabled = False
            If esTemporal = False Then
                inactivarCambioIncrementoSiHayListasClientes()
            End If
            Else
                Me.Close()
            End If
            txtDigitoLista.Focus()
    End Sub


    Private Sub btnCargarCliente_Click(sender As Object, e As EventArgs) Handles btnCargarCliente.Click
        cargarClientes()
        If grdClientes.Rows.Count = 0 Then
            Dim objMensajeAd As New Tools.AdvertenciaForm
            objMensajeAd.mensaje = "No existen clientes que cumplan con esta configuración de Lista de Ventas." + vbCrLf + " Los clientes recuperados son aquellos que cumplen con la configuración capturada y que NO se encuentran en otras Listas de Ventas."
            objMensajeAd.ShowDialog()
        End If
    End Sub

    Private Sub btnCambiarConfig_Click(sender As Object, e As EventArgs) Handles btnCambiarConfig.Click
        If accionPantalla = "ALTA" Then
            grdClientes.DataSource = Nothing
            lblContarConfiguracion.Text = "0"
            pnlContenedorConfiguracion.Enabled = True
            pnlBotonCambiar.Enabled = False
        Else
            Dim objMensajeExito As New Tools.ConfirmarForm
            objMensajeExito.mensaje = "Cambiar la configuración de la lista de ventas podría provocar que se elimine la relación entre la lista de ventas y algunos clientes." + vbCrLf + "¿Desea editar la configuración?"
            If objMensajeExito.ShowDialog = Windows.Forms.DialogResult.OK Then
                pnlBotones.Enabled = False
                ejecutarConsultaClientes()
                If estatusListaid <> 3 Then
                    pnlConfiguracion.Enabled = True
                    pnlConfiguracionGrids.Enabled = True
                    pnlSimular.Enabled = True
                    pnlCargarClientes.Enabled = False
                    pnlBotonCambiar.Enabled = False
                    For Each rowDg As UltraGridRow In grdClientes.Rows
                        rowDg.Activation = Activation.NoEdit
                        If rowDg.Index Mod 2 = 0 Then
                            rowDg.Appearance.BackColor = Color.White
                        Else
                            rowDg.Appearance.BackColor = Color.LightSteelBlue
                        End If
                    Next

                    lblContClientes.Text = "0"

                End If
            End If
        End If
    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If validarFechasVigenciaHoy() = True Then
            If validarFechasVigencia() = True Then
                If validarRangos() = True Then
                    If validarDatosGeneralListaVnts() = True Then
                        Try
                            Dim objMensajeExito As New Tools.ConfirmarForm
                            objMensajeExito.mensaje = "¿Está seguro de guardar la lista de ventas?"
                            If objMensajeExito.ShowDialog = Windows.Forms.DialogResult.OK Then
                                Dim objCaptcha As New Tools.frmCaptcha
                                objCaptcha.mensaje = ""
                                If objCaptcha.ShowDialog = Windows.Forms.DialogResult.OK Then
                                    If accionPantalla = "ALTA" Then
                                        guardarListaVentas()
                                        llenarDatosListaVentas()
                                        pnlConfiguracion.Enabled = False
                                        pnlConfiguracionGrids.Enabled = False
                                        pnlSimular.Enabled = False
                                        btnCambiarConfig.Visible = True
                                        lblCambiarConfiguracion.Visible = True
                                        lblEstatus.Text = estatusListaCad
                                        cmbEvento.Enabled = False
                                        pnlCargarClientes.Enabled = False
                                    ElseIf accionPantalla = "EDITAR" Then
                                        guardarCambiosClientesListaVenta()
                                        llenarDatosListaVentas()
                                    End If
                                    Dim objExito As New Tools.ExitoForm
                                    objExito.mensaje = "Registro Correcto."
                                    objExito.ShowDialog()
                                    accionPantalla = "EDITAR"
                                    llenarDatosListaVentas()
                                End If
                            End If
                        Catch ex As Exception
                            MsgBox("Error en el proceso.", MsgBoxStyle.Critical, "")
                            Me.Close()
                        End Try
                    Else
                        Dim objMensajeAlert As New Tools.AdvertenciaForm
                        objMensajeAlert.mensaje = "Debe completar los datos marcados en rojo."
                        objMensajeAlert.ShowDialog()
                    End If
                Else
                    Dim objMensajeAlert As New Tools.AdvertenciaForm
                    objMensajeAlert.mensaje = "Debe completar los datos marcados en rojo."
                    objMensajeAlert.ShowDialog()
                End If
            Else
                Dim objMensajeAlert As New Tools.AdvertenciaForm
                objMensajeAlert.mensaje = "Vigencia Invalida."
                objMensajeAlert.ShowDialog()
            End If
        Else
            Dim objMensajeAlert As New Tools.AdvertenciaForm
            objMensajeAlert.mensaje = "No se pueden guardar cambios en la lista de ventas si la vigencia no es valida.."
            objMensajeAlert.ShowDialog()
        End If
    End Sub

    Private Sub txtDigitoLista_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDigitoLista.KeyDown
        If e.KeyCode = Keys.Enter Then
            validarDigito()
        End If
    End Sub

    Private Sub txtDigitoLista_LostFocus(sender As Object, e As EventArgs) Handles txtDigitoLista.LostFocus
        validarDigito()
    End Sub

    Private Sub txtDigitoLista_TextChanged(sender As Object, e As EventArgs) Handles txtDigitoLista.TextChanged

    End Sub

    Private Sub cmbListaBase_SelectedIndexChanged(sender As Object, e As EventArgs)
        txtDigitoLista.Text = ""
    End Sub

    Private Sub grdClientes_BeforeCellDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdClientes.BeforeCellDeactivate

    End Sub

    Private Sub grdClientes_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdClientes.BeforeCellUpdate
        If e.Cell.Row.IsFilterRow = False Then
            If e.Cell.Column.Key <> "Seleccion" And e.Cell.Column.Key <> "Flete" And e.Cell.Column.Key <> "Descuento" Then
                If (accionPantalla = "EDITAR" Or accionPantalla = "CONSULTA") And estatusListaid = 1 And modificarFacturacion = True Then
                    If e.Cell.Value.ToString.Trim <> e.Cell.Text Then
                        If MsgBox("¿Esta seguro de guardar los datos?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
                            modificarFacturacion = True
                        Else
                            modificarFacturacion = False
                            e.Cancel = True
                        End If
                    Else
                        Dim objAviso As New Tools.AvisoForm
                        objAviso.mensaje = "El dato que desea configurar es el mismo que existe en la actualidad."
                        objAviso.ShowDialog()
                        modificarFacturacion = False
                        e.Cancel = True
                    End If
                    ' ''ElseIf estatusListaid <> 3 And modificarFacturacion = True Then
                    ' ''    If e.Cell.Column.Key = "LVCDESCRIPCION" Then
                    ' ''        If MsgBox("¿Esta seguro de guardar cambios?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
                    ' ''            modificarFacturacion = True
                    ' ''        Else
                    ' ''            modificarFacturacion = False
                    ' ''            e.Cancel = True
                    ' ''        End If
                    ' ''    Else
                    ' ''        modificarFacturacion = False
                    ' ''        e.Cancel = True
                    ' ''    End If
                Else
                    modificarFacturacion = False
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub grdClientes_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdClientes.AfterCellUpdate
        If e.Cell.Row.IsFilterRow = False Then
            If (accionPantalla = "EDITAR" Or accionPantalla = "CONSULTA") And estatusListaid = 1 And modificarFacturacion = True Then
                Try
                    If e.Cell.Column.Key.ToString = "iccl_facturar" Then
                        If idListaVentas > 0 And grdClientes.Rows(e.Cell.Row.Index).Cells("clie_clienteid").Value > 0 And e.Cell.Value > 0 Then
                            Dim objLVBU As New ListaVentasBU
                            objLVBU.guardarClienteConfiguraionListaActiva(idListaVentas, grdClientes.Rows(e.Cell.Row.Index).Cells("clie_clienteid").Value, 0, e.Cell.Value.ToString, "FACTURACION")
                            modificarFacturacion = False
                            Dim objExito As New Tools.ExitoForm
                            objExito.mensaje = "Registro Correcto."
                            objExito.ShowDialog()
                        End If
                    ElseIf e.Cell.Column.Key.ToString = "tiva_nombre" Then
                        Dim objLVBU As New ListaVentasBU
                        objLVBU.guardarClienteConfiguraionListaActiva(idListaVentas, grdClientes.Rows(e.Cell.Row.Index).Cells("clie_clienteid").Value, e.Cell.Value.ToString, 0, "IVA")
                        modificarFacturacion = False
                        Dim objExito As New Tools.ExitoForm
                        objExito.mensaje = "Registro Correcto."
                        objExito.ShowDialog()
                    ElseIf e.Cell.Column.Key.ToString = "tifl_nombre" Then
                        Dim objLVBU As New ListaVentasBU
                        objLVBU.guardarClienteConfiguraionListaActiva(idListaVentas, grdClientes.Rows(e.Cell.Row.Index).Cells("clie_clienteid").Value, e.Cell.Value.ToString, 0, "FLETE")
                        modificarFacturacion = False
                        Dim objExito As New Tools.ExitoForm
                        objExito.mensaje = "Registro Correcto."
                        objExito.ShowDialog()
                        ''ElseIf e.Cell.Column.Key = "LVCDESCRIPCION" And
                        ''e.Cell.Value.ToString.Length > 0 And
                        ''grdClientes.Rows(e.Cell.Row.Index).Cells("LISTAVENTACLIENTE").Value > 0 Then
                        ''    Dim objLVBU As New ListaVentasBU
                        ''    objLVBU.guardarDescripcionListaCliente(grdClientes.Rows(e.Cell.Row.Index).Cells("LISTAVENTACLIENTE").Value, e.Cell.Value.ToString)
                        ''    modificarFacturacion = False
                        ''    Dim objExito As New Tools.ExitoForm
                        ''    objExito.mensaje = "Registro Correcto. Descripción"
                        ''    objExito.ShowDialog()

                    End If
                Catch ex As Exception

                End Try

                ''ElseIf estatusListaid <> 3 And modificarFacturacion = True Then
                ''    If e.Cell.Column.Key = "LVCDESCRIPCION" And
                ''        grdClientes.Rows(e.Cell.Row.Index).Cells("LISTAVENTACLIENTE").Value > 0 Then
                ''        Dim objLVBU As New ListaVentasBU
                ''        objLVBU.guardarDescripcionListaCliente(grdClientes.Rows(e.Cell.Row.Index).Cells("LISTAVENTACLIENTE").Value, e.Cell.Value.ToString)
                ''        modificarFacturacion = False
                ''        Dim objExito As New Tools.ExitoForm
                ''        objExito.mensaje = "Registro Correcto. Descripción"
                ''        objExito.ShowDialog()
                ''    End If
            End If
        End If
    End Sub


    Private Sub grdClientes_CellChange(sender As Object, e As CellEventArgs) Handles grdClientes.CellChange
        If e.Cell.Column.Key = "Seleccion" And e.Cell.Row.Index <> grdClientes.Rows.FilterRow.Index Then
            Dim contadorSeleccion As Int32 = 0

            If CBool(e.Cell.Text) = True Then
                e.Cell.Appearance.BackColor = Color.LimeGreen
            Else
                If 0 = e.Cell.Row.Index Mod 2 Then
                    e.Cell.Appearance.BackColor = Color.White
                Else
                    e.Cell.Appearance.BackColor = Color.LightSteelBlue
                End If
            End If
            If CBool(e.Cell.Text) = True Then
                lblContClientes.Text = CInt(lblContClientes.Text) + 1
            Else
                lblContClientes.Text = CInt(lblContClientes.Text) - 1
            End If
        End If
    End Sub

    Private Sub grdClientes_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdClientes.DoubleClickCell
        If e.Cell.Row.IsFilterRow = False Then
            If e.Cell.Column.Key <> "Configuracion" Then
                If estatusListaid = 1 Then
                    If e.Cell.Column.Key = "Flete" Then
                        Dim objLVBU As New ListaVentasBU
                        Dim objCats As New frmCatalogoMultiple
                        Dim dtFletes As New DataTable
                        Dim fletes As String = ""
                        For Each rowGrF As UltraGridRow In grdTipoFlete.Rows
                            If CBool(rowGrF.Cells(2).Value) = True Then
                                fletes += rowGrF.Cells(0).Value.ToString + ", "
                            End If
                        Next
                        fletes += "0"
                        dtFletes = objLVBU.consultaFletes(fletes)
                        objCats.tabla = dtFletes
                        objCats.idListaVentas = idListaVentas
                        objCats.idCliente = grdClientes.Rows(e.Cell.Row.Index).Cells("clie_clienteid").Value
                        objCats.accion = "FLETE"
                        objCats.ShowDialog()
                        If objCats.PidsResultado <> "" Then
                            e.Cell.Value = objCats.PidsResultado
                        End If
                    ElseIf e.Cell.Column.Key = "Descuento" Then
                        Dim objLVBU As New ListaVentasBU
                        Dim objCats As New frmCatalogoMultiple
                        Dim dtDescuentos As New DataTable
                        dtDescuentos = objLVBU.consultaDescuentos
                        objCats.tabla = dtDescuentos
                        objCats.idListaVentas = idListaVentas
                        objCats.idCliente = grdClientes.Rows(e.Cell.Row.Index).Cells("clie_clienteid").Value
                        objCats.accion = "DESCUENTO"
                        objCats.valorMaximo = txtDescuentoFin.Value.ToString
                        objCats.valorMinimo = txtDescuentoInicio.Value.ToString
                        objCats.ShowDialog()
                        If objCats.PidsResultado <> "" Then
                            e.Cell.Value = Format(CDbl(objCats.PidsResultado), "000.00")
                        End If
                    End If
                End If
            ElseIf e.Cell.Column.Key = "Configuracion" Then
                If e.Cell.Value > 0 Then
                    Dim objListaConfCLiente As New ListaConfiguracionListaVentas
                    objListaConfCLiente.idClienteSAY = grdClientes.Rows(e.Cell.Row.Index).Cells("clie_clienteid").Value
                    objListaConfCLiente.idClienteSICY = grdClientes.Rows(e.Cell.Row.Index).Cells("clie_idsicy").Value
                    objListaConfCLiente.idListaVentas = idListaVentas
                    objListaConfCLiente.ShowDialog()
                End If
            End If
        End If
    End Sub

    Private Sub grdClientes_Error(sender As Object, e As ErrorEventArgs) Handles grdClientes.Error

        If e.ErrorText = "Unable to update the data value: Input value does not satisfy minimum value constraint." Then
            e.Cancel = True
            MsgBox("El valor capturado es menor al valido.", MsgBoxStyle.Information, "Atención")
            modificarFacturacion = False
        ElseIf e.ErrorText = "Unable to update the data value: Input value does not satisfy maximum value constraint." Then
            e.Cancel = True
            MsgBox("El valor capturado es mayor al valido.", MsgBoxStyle.Information, "Atención")
            modificarFacturacion = False
        End If
    End Sub

    Private Sub grdClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        Me.grdClientes.DisplayLayout.GroupByBox.Prompt = "Arrastra para agrupar datos."
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

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub grdClientes_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles grdClientes.BeforeExitEditMode
        If grdClientes.ActiveRow.IsFilterRow = False Then
            If grdClientes.ActiveCell.Column.Key <> "Seleccion" Then
                If modificarFacturacion = False Then
                    grdClientes.ActiveCell.CancelUpdate()
                End If
            End If
        End If
    End Sub

    Private Sub btnSimularCambios_Click(sender As Object, e As EventArgs) Handles btnSimularCambios.Click
       
        Dim objListaClientes As New ListaVentasBU
        If txtDescuentoFin.Value >= txtDescuentoInicio.Value Then
            If txtFacturacionFin.Value >= txtFacturacionInicio.Value Then
                Dim contTipoIVA As Int32 = 0
                For Each rowGTI As UltraGridRow In grdListaTipoIva.Rows
                    If CBool(rowGTI.Cells("SeleccionIva").Value) = True Then
                        contTipoIVA += 1
                    End If
                Next
                If contTipoIVA > 0 Then
                    Dim contTipoFlete As Int32 = 0
                    For Each rowGTF As UltraGridRow In grdTipoFlete.Rows
                        If CBool(rowGTF.Cells("SeleccionFlete").Value) = True Then
                            contTipoFlete += 1
                        End If
                    Next
                    If contTipoFlete > 0 Then
                        If accionPantalla = "EDITAR" Then
                            ejecutarConsultaClientesSimularCambios()
                            Dim objMensajeTermino As New Tools.ExitoForm
                            objMensajeTermino.mensaje = "Simulación Terminada."
                            objMensajeTermino.ShowDialog()
                        End If
                    Else
                        MsgBox("Debe seleccionar al menos un tipo de Flete.", MsgBoxStyle.Information, "")
                    End If
                Else
                    MsgBox("Debe seleccionar al menos un tipo de IVA.", MsgBoxStyle.Information, "")
                End If
            Else
                MsgBox("La cantidad Facturación Fin no puede ser menor a la de Facturación inicio.", MsgBoxStyle.Information, "")
            End If
        Else
            MsgBox("La cantidad Descuento Fin no puede ser menor a la de Descuento inicio.", MsgBoxStyle.Information, "")
        End If
    End Sub

    Private Sub btnGuardarDatos_Click(sender As Object, e As EventArgs) Handles btnGuardarDatos.Click
        Dim objListaClientes As New ListaVentasBU
        ejecutarConsultaClientesSimularCambios()
        If validarExisteLVCPS() = True Then
            If txtDescuentoFin.Value >= txtDescuentoInicio.Value Then
                If txtFacturacionFin.Value >= txtFacturacionInicio.Value Then
                    Dim contTipoIVA As Int32 = 0
                    For Each rowGTI As UltraGridRow In grdListaTipoIva.Rows
                        If CBool(rowGTI.Cells("SeleccionIva").Value) = True Then
                            contTipoIVA += 1
                        End If
                    Next
                    If contTipoIVA > 0 Then
                        Dim contTipoFlete As Int32 = 0
                        For Each rowGTF As UltraGridRow In grdTipoFlete.Rows
                            If CBool(rowGTF.Cells("SeleccionFlete").Value) = True Then
                                contTipoFlete += 1
                            End If
                        Next
                        If contTipoFlete > 0 Then
                            Dim objMensajeExito As New Tools.ConfirmarForm
                            objMensajeExito.mensaje = "¿Está seguro de guardar la lista de ventas?"
                            If objMensajeExito.ShowDialog = Windows.Forms.DialogResult.OK Then
                                Dim objCaptcha As New Tools.frmCaptcha
                                objCaptcha.mensaje = ""
                                If objCaptcha.ShowDialog = Windows.Forms.DialogResult.OK Then
                                    lblContarConfiguracion.Text = "0"
                                    guardarCambiosConfiguracion()
                                    grdClientes.DataSource = Nothing
                                    Dim contExistenAfectados As Int32 = 0
                                    Dim cadenaMensajeExisto As String = "Registro Exitoso."
                                    For Each rowgrd As UltraGridRow In grdClientes.Rows
                                        If rowgrd.Cells("Seleccion").Appearance.BackColor = Color.Red And rowgrd.Cells("registroAnt").Value = 1 Then
                                            contExistenAfectados += 1
                                        End If
                                    Next
                                    If contExistenAfectados > 0 Then
                                        cadenaMensajeExisto += " Los clientes afectados por el cambio serán enviados a la lista de ventas temporal."
                                    End If

                                    ejecutarConsultaClientes()
                                    pnlBotones.Enabled = True
                                    pnlConfiguracion.Enabled = False
                                    pnlConfiguracionGrids.Enabled = False
                                    pnlSimular.Enabled = False
                                    If accionPantalla = "ALTA" Then
                                        pnlCargarClientes.Enabled = True
                                    End If
                                    pnlBotonCambiar.Enabled = True
                                    Dim objExito As New Tools.ExitoForm
                                    objExito.mensaje = cadenaMensajeExisto
                                    objExito.ShowDialog()
                                End If
                            End If
                        Else
                            Dim objMensajeAlert As New Tools.AdvertenciaForm
                            objMensajeAlert.mensaje = "Debe seleccionar al menos un tipo de Flete."
                            objMensajeAlert.ShowDialog()
                        End If
                    Else
                        Dim objMensajeAlert As New Tools.AdvertenciaForm
                        objMensajeAlert.mensaje = "Debe seleccionar al menos un tipo de IVA."
                        objMensajeAlert.ShowDialog()
                    End If
                Else
                    Dim objMensajeAlert As New Tools.AdvertenciaForm
                    objMensajeAlert.mensaje = "La cantidad Facturación Fin no puede ser menor a la de Facturación inicio."
                    objMensajeAlert.ShowDialog()
                End If
            Else
                Dim objMensajeAlert As New Tools.AdvertenciaForm
                objMensajeAlert.mensaje = "La cantidad Descuento Fin no puede ser menor a la de Descuento inicio."
                objMensajeAlert.ShowDialog()
            End If
        Else
            Dim objMensajeAlert As New Tools.AdvertenciaForm
            objMensajeAlert.mensaje = "Cuando los clientes tienen al menos una lista de precios de cliente configurada, los datos no pueden modificarse de forma que el cliente quede fuera."
            objMensajeAlert.ShowDialog()
        End If
    End Sub

    Private Sub grdClientes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdClientes.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) And grdClientes.ActiveRow.Index <> grdClientes.Rows.FilterRow.Index Then
            If IsNothing(grdClientes.ActiveRow) Then Return
            modificarFacturacion = True
            Dim NextRowIndex As Integer = grdClientes.ActiveRow.Index + 1
            Try
                If NextRowIndex <= grdClientes.Rows.Count Then
                    grdClientes.DisplayLayout.Rows(NextRowIndex).Activated = True
                    grdClientes.DisplayLayout.Rows(NextRowIndex).Selected = True
                Else
                    grdClientes.DisplayLayout.Rows(0).Activated = True
                    grdClientes.DisplayLayout.Rows(0).Selected = True
                End If

            Catch ex As Exception
                grdClientes.ActiveRow.Activated = False
            End Try
        End If
    End Sub

    Private Sub btnCancelarCambios_Click(sender As Object, e As EventArgs) Handles btnCancelarCambios.Click

        llenarComboEventos()
        llenarTablaIvaFlete()
        llenarDatosListaVentas()
        pnlConfiguracion.Enabled = False
        pnlConfiguracionGrids.Enabled = False
        pnlSimular.Enabled = False
        btnCambiarConfig.Visible = True
        lblCambiarConfiguracion.Visible = True
        If codigoLB <> "" Then
            lblCodigoLB.Text = codigoLB + "-"
        End If
        txtListaBase.Text = nombreLista
        If estatusListaid = 1 Then
            lblEstatus.ForeColor = Color.DarkOrange
        ElseIf estatusListaid = 2 Then
            lblEstatus.ForeColor = Color.LimeGreen
            pctEngrane.Visible = False
            lblConfMensaje.Visible = False
        Else
            lblEstatus.ForeColor = Color.Red
            pctEngrane.Visible = False
            lblConfMensaje.Visible = False
        End If
        lblEstatus.Text = estatusListaCad
        dttVigenciaInicio.MaxDate = vigenciaFin.ToShortDateString
        dttVigenciaInicio.MinDate = vigenciaInicio.ToShortDateString
        dttVigenciaFin.MaxDate = vigenciaFin.ToShortDateString
        dttVigenciaFin.MinDate = vigenciaInicio.ToShortDateString
        cmbEvento.Enabled = False
        pnlCargarClientes.Enabled = False
        pnlBotones.Enabled = True
        pnlBotonCambiar.Enabled = True
    End Sub

    Private Sub grdClientes_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdClientes.InitializeRow
        If estatusListaid = 1 Then
            If e.Row.Cells.Exists("Configuracion") Then
                If e.Row.Cells("Configuracion").Value > 0 Then
                    e.Row.Cells("Configuracion").Appearance.ImageBackground = Global.Ventas.Vista.My.Resources.Resources.conflv
                Else
                    e.Row.Cells("Configuracion").Value = ""
                End If
            End If
        End If
        If e.Row.Cells.Exists("LPVCS") Then
            If e.Row.Cells("LPVCS").Value > 0 Then
                e.Row.Cells("Seleccion").Activation = Activation.NoEdit
                e.Row.Cells("clie_clienteid").Appearance.BackColor = Color.Gold
            End If
        End If
    End Sub

    Private Sub grdListaTipoIva_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListaTipoIva.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdListaTipoIva_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaTipoIva.InitializeLayout

    End Sub

    Private Sub grdTipoFlete_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdTipoFlete.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdTipoFlete_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdTipoFlete.InitializeLayout

    End Sub

    Private Sub btnGuardarIncremento_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbEvento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEvento.SelectedIndexChanged
        If accionPantalla = "ALTA" Then
            If cmbEvento.SelectedIndex = 0 Then
                pnlConfiguracion.Enabled = True
                pnlConfiguracionGrids.Enabled = True
                txtDescuentoInicio.Value = 0
                txtDescuentoFin.Value = 0
                txtFacturacionInicio.Value = 0
                txtFacturacionFin.Value = 0

                For Each rowIVA As UltraGridRow In grdListaTipoIva.Rows
                    rowIVA.Cells("SeleccionIva").Value = False
                Next
                For Each rowFlete As UltraGridRow In grdTipoFlete.Rows
                    rowFlete.Cells("SeleccionFlete").Value = False
                Next
               pnlCargarClientes.Enabled = True
            Else
                Dim objLVBU As New ListaVentasBU
                Dim contValEvent As Int32 = 0
                contValEvent = objLVBU.validarListaVentasEvento(idListaBase, cmbEvento.SelectedValue)
                If contValEvent = 0 Then
                    pnlConfiguracion.Enabled = False
                    pnlConfiguracionGrids.Enabled = False
                    txtDescuentoInicio.Value = 0
                    txtDescuentoFin.Value = 100
                    txtFacturacionInicio.Value = 0
                    txtFacturacionFin.Value = 100
                    For Each rowIVA As UltraGridRow In grdListaTipoIva.Rows
                        rowIVA.Cells("SeleccionIva").Value = True
                    Next
                    For Each rowFlete As UltraGridRow In grdTipoFlete.Rows
                        rowFlete.Cells("SeleccionFlete").Value = True
                    Next
                    grdClientes.DataSource = Nothing
                    lblContarConfiguracion.Text = "0"
                    pnlCargarClientes.Enabled = False
                Else
                    cmbEvento.SelectedIndex = 0
                    Dim objMensaje As New Tools.AdvertenciaForm
                    objMensaje.mensaje = "El evento ya tiene una Lista de Ventas Asignada"
                    objMensaje.ShowDialog()
                End If

            End If
        End If
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlContenedor.Visible = True
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlContenedor.Visible = False
    End Sub

    Private Sub chkSeleccionarFiltrados_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarFiltrados.CheckedChanged
        Dim contadorSeleccion As Int32 = 0
        For Each rowGR As UltraGridRow In grdClientes.Rows.GetFilteredInNonGroupByRows
            If chkSeleccionarFiltrados.Checked = True Then
                rowGR.Cells("Seleccion").Value = True
            Else
                rowGR.Cells("Seleccion").Value = False
            End If
        Next
        For Each rowGR As UltraGridRow In grdClientes.Rows
            If CBool(rowGR.Cells("Seleccion").Text) = True Then
                contadorSeleccion += 1
            End If
            If CBool(rowGR.Cells("Seleccion").Text) = True Then
                rowGR.Cells("Seleccion").Appearance.BackColor = Color.LimeGreen
            Else
                If 0 = rowGR.Index Mod 2 Then
                    rowGR.Cells("Seleccion").Appearance.BackColor = Color.White
                Else
                    rowGR.Cells("Seleccion").Appearance.BackColor = Color.LightSteelBlue
                End If
            End If
        Next
        lblContClientes.Text = contadorSeleccion.ToString("N0")
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtIncrementoPar.Focus()
        End If
    End Sub

    Private Sub txtIncrementoPar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIncrementoPar.KeyDown
        If e.KeyCode = Keys.Enter Then
            dttVigenciaInicio.Focus()
        End If
    End Sub

    Private Sub dttVigenciaInicio_KeyDown(sender As Object, e As KeyEventArgs) Handles dttVigenciaInicio.KeyDown
        If e.KeyCode = Keys.Enter Then
            dttVigenciaFin.Focus()
        End If
    End Sub

    Private Sub dttVigenciaFin_KeyDown(sender As Object, e As KeyEventArgs) Handles dttVigenciaFin.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDescuentoInicio.Focus()
        End If
    End Sub

    Private Sub txtDescuentoInicio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescuentoInicio.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDescuentoFin.Focus()
        End If
    End Sub

    Private Sub txtDescuentoFin_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescuentoFin.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtFacturacionInicio.Focus()
        End If
    End Sub

    Private Sub txtFacturacionInicio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFacturacionInicio.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtFacturacionFin.Focus()
        End If
    End Sub

    Private Sub txtFacturacionFin_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFacturacionFin.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnCargarCliente.Focus()
        End If
    End Sub

End Class