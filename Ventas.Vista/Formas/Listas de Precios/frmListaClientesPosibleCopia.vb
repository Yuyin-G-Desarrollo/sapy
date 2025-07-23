Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmListaClientesPosibleCopia
    Public idListaBase As Int32 = 0
    Public idListaVentasClienteProd As Int32 = 0
    Public idListaVentas As Int32 = 0
    Public idCliente As Int32 = 0
    Public nombreCliente As String = ""
    Public vigenciaInicio As Date
    Public vigenciaFin As Date
    Public modificado As Date
    Public usuarioModifico As String = ""
    Public estatusCad As String = ""
    Public estatusLB As String = ""
    Public nombreListaCliente As String = ""
    Public idEstatus As Int32 = 0
    Public cantArticulos As Int32 = 0

    Public Sub llenarTablaClientesPosibles()
        Dim objLVC As New Negocios.ListaPreciosVentaClienteBU
        Dim dtDatosLVC As New DataTable

        txtListaVentasCliente.Text = objLVC.consultaNombreListaCopia(idListaVentasClienteProd)

        dtDatosLVC = objLVC.consultaClientesPosibleCopia(idListaBase, idCliente, idListaVentasClienteProd)
        If dtDatosLVC.Rows.Count > 0 Then
            grdClientes.DataSource = dtDatosLVC
            formatoGridsgrdClientes()
        Else
            grdClientes.DataSource = Nothing
        End If
    End Sub

    Public Sub llenarTablaClientesNoCopia()
        Dim objLVC As New Negocios.ListaPreciosVentaClienteBU
        Dim dtDatosLVC As New DataTable
        dtDatosLVC = objLVC.consultaClientesNoCopia(idListaBase, idCliente, idListaVentasClienteProd)
        If dtDatosLVC.Rows.Count > 0 Then
            grdClientesNoCopia.DataSource = dtDatosLVC
            formatoGridsgrdClientesNoCopia()
        Else
            grdClientesNoCopia.DataSource = Nothing
        End If
    End Sub

    Public Sub formatoGridsgrdClientes()
        With grdClientes.DisplayLayout.Bands(0)
            .Columns("clie_statuscliente").Hidden = True
            .Columns("clie_ranking").Hidden = True
            .Columns("clie_personaidcliente").Hidden = True
            .Columns("clie_clasificacionpersonaid").Hidden = True
            .Columns("clie_comentarios").Hidden = True
            .Columns("clie_empresaid").Hidden = True
            .Columns("clie_tipoclienteid").Hidden = True
            .Columns("clie_precioespecial").Hidden = True
            .Columns("clie_condicionespecial").Hidden = True
            .Columns("lpvt_listaprecioventaid").Hidden = True
            .Columns("lvcl_listaventasclienteid").Hidden = True
            .Columns("clie_razonsocial").Hidden = True
            .Columns("nuevaListaID").Hidden = True
            .Columns("porcent").Hidden = True
            .Columns("iccl_monedaid").Hidden = True
            .Columns("iccl_facturar").Hidden = True
            .Columns("ccla_facturar").Hidden = True
            .Columns("iccl_tipofleteid").Hidden = True
            .Columns("ccla_tipofleteid").Hidden = True
            .Columns("iccl_tipoivaid").Hidden = True
            .Columns("ccla_tipoivaid").Hidden = True
            If estatusLB <> "ACTIVA" Then
                .Columns("descConf").Hidden = True
            End If
            .Columns("Listas").Hidden = True
            ' ''.Columns("ESTATUS").Hidden = True

            .Columns("Seleccion").Header.Caption = ""
            .Columns("clie_clienteid").Header.Caption = "Id SAY"
            .Columns("clie_idsicy").Header.Caption = "Id SICY"
            .Columns("clie_nombregenerico").Header.Caption = "Cliente"
            .Columns("clie_razonsocial").Header.Caption = "RFC"
            .Columns("LV").Header.Caption = "Lista de Ventas"
            .Columns("incremento").Header.Caption = "% IXP"
            .Columns("descuento").Header.Caption = "%D"
            .Columns("descConf").Header.Caption = "%D Conf"
            .Columns("calculaDesc").Header.Caption = "DA?"
            .Columns("ESTATUS").Header.Caption = "Estatus"

            .Columns("incremento").CellActivation = Activation.NoEdit
            .Columns("descuento").CellActivation = Activation.NoEdit
            .Columns("LV").CellActivation = Activation.NoEdit
            .Columns("descConf").CellActivation = Activation.NoEdit
            .Columns("calculaDesc").CellActivation = Activation.NoEdit
            .Columns("Copia").CellActivation = Activation.NoEdit
            .Columns("ESTATUS").CellActivation = Activation.NoEdit

            .Columns("clie_clienteid").CellActivation = Activation.NoEdit
            .Columns("clie_idsicy").CellActivation = Activation.NoEdit
            .Columns("clie_nombregenerico").CellActivation = Activation.NoEdit
            .Columns("clie_razonsocial").CellActivation = Activation.NoEdit
            .Columns("clie_clienteid").CellAppearance.TextHAlign = HAlign.Right
            .Columns("clie_idsicy").CellAppearance.TextHAlign = HAlign.Right
            .Columns("incremento").CellAppearance.TextHAlign = HAlign.Right
            .Columns("descuento").CellAppearance.TextHAlign = HAlign.Right
            .Columns("descConf").CellAppearance.TextHAlign = HAlign.Right
            .Columns("descConf").CellAppearance.TextHAlign = HAlign.Right

            .Columns("Copia").CellAppearance.BackColor = Color.White

            .Columns("descuento").MaskInput = "nnn"
            .Columns("descConf").MaskInput = "nnn"

        End With
        Dim colSeleccion As UltraGridColumn = grdClientes.DisplayLayout.Bands(0).Columns("Seleccion")
        colSeleccion.DefaultCellValue = False
        colSeleccion.Header.Caption = ""
        colSeleccion.Style = ColumnStyle.CheckBox
        grdClientes.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdClientes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdClientes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdClientes.DisplayLayout.Override.RowSelectorWidth = 35
        grdClientes.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdClientes.Rows(0).Selected = True

        grdClientes.DisplayLayout.Bands(0).Columns("clie_nombregenerico").Width = 380
        grdClientes.DisplayLayout.Bands(0).Columns("incremento").Width = 50
        grdClientes.DisplayLayout.Bands(0).Columns("descuento").Width = 50
        grdClientes.DisplayLayout.Bands(0).Columns("calculaDesc").Width = 30
        grdClientes.DisplayLayout.Bands(0).Columns("ESTATUS").Width = 100
        grdClientes.DisplayLayout.Bands(0).Columns("Seleccion").Width = 40
    End Sub

    Public Sub formatoGridsgrdClientesNoCopia()
        With grdClientesNoCopia.DisplayLayout.Bands(0)
            .Columns("clie_clienteid").Header.Caption = "Id SAY"
            .Columns("clie_idsicy").Header.Caption = "Id SICY"
            .Columns("clie_nombregenerico").Header.Caption = "Cliente"
            .Columns("Razon").Header.Caption = "Razón"

            .Columns("clie_clienteid").CellActivation = Activation.NoEdit
            .Columns("clie_idsicy").CellActivation = Activation.NoEdit
            .Columns("Razon").CellActivation = Activation.NoEdit
            .Columns("clie_nombregenerico").CellActivation = Activation.NoEdit
            .Columns("clie_clienteid").CellAppearance.TextHAlign = HAlign.Right
            .Columns("clie_idsicy").CellAppearance.TextHAlign = HAlign.Right

        End With
        grdClientesNoCopia.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdClientesNoCopia.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdClientesNoCopia.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdClientesNoCopia.DisplayLayout.Override.RowSelectorWidth = 35
        grdClientesNoCopia.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdClientesNoCopia.Rows(0).Selected = True
    End Sub

    Public Sub guardarCopias()
        Dim objLVCBU As New Negocios.ListaPreciosVentaClienteBU
        Dim idRegNuevaListaCopiada As Int32 = 0
        Dim dtArticulos As New DataTable
        Dim contCopiadosTotal As Int32 = 0

        dtArticulos = objLVCBU.consultaArticulosListaPrecioCliente(idListaVentasClienteProd, idListaBase)

        Dim contTotal As Int32 = 0
        Dim contCopiados As Int32 = 0
        For Each rowGrcolor As UltraGridRow In grdClientes.Rows
            If CBool(rowGrcolor.Cells("Seleccion").Value) = True And rowGrcolor.Cells("nuevaListaID").Value.ToString = "" Then
                contTotal += 1
                lblClientesCopiadosCont.Text = "0/" + contTotal.ToString
            End If
        Next

        For Each rowGr As UltraGridRow In grdClientes.Rows
            idRegNuevaListaCopiada = 0
            If CBool(rowGr.Cells("Seleccion").Value) = True And rowGr.Cells("nuevaListaID").Value.ToString = "" Then
                rowGr.Cells("Copia").Appearance.BackColor = Color.Gold

                If estatusLB = "AUTORIZADA" Then
                    idRegNuevaListaCopiada = objLVCBU.copiarListaClienteProductos(idListaVentas, idListaVentasClienteProd, rowGr.Cells("lvcl_listaventasclienteid").Value,
                                                        rowGr.Cells("Descuento").Value, rowGr.Cells("iccl_facturar").Value,
                                                        rowGr.Cells("iccl_tipofleteid").Value, rowGr.Cells("iccl_tipoivaid").Value,
                                                        rowGr.Cells("incremento").Value, rowGr.Cells("porcent").Value)
                    If idRegNuevaListaCopiada > 0 Then
                        contCopiadosTotal += 1
                        rowGr.Cells("nuevaListaID").Value = idRegNuevaListaCopiada.ToString
                        rowGr.Cells("ESTATUS").Value = "CAPTURADA"

                        If CBool(rowGr.Cells("calculaDesc").Value) = False Then
                            Dim precioFinal As Int32 = 0
                            For Each rowDT As DataRow In dtArticulos.Rows
                                precioFinal = 0
                                precioFinal = Math.Round((rowDT.Item("lpbp_preciobase") + (rowDT.Item("lpbp_preciobase") * (rowGr.Cells("incremento").Value) / 100)), MidpointRounding.AwayFromZero)
                                objLVCBU.guardarDatosListaPreciosClienteProductos(idRegNuevaListaCopiada, rowDT.Item("lpcp_productoestiloid"), rowDT.Item("lpbp_preciobase"), precioFinal, precioFinal, 0, 0, rowGr.Cells("lpvt_listaprecioventaid").Value, 1)
                            Next
                        Else
                            Dim precioFinal As Int32 = 0
                            Dim precioDesc As Double = 0
                            Dim dtDatosDescuentos As New DataTable
                            Dim objClientesDDA As New Negocios.ClientesDatosBU
                            dtDatosDescuentos = objClientesDDA.Datos_TablaDescuentosCliente(rowGr.Cells("clie_clienteid").Value, 0)
                            For Each rowDT As DataRow In dtArticulos.Rows
                                precioFinal = 0
                                precioDesc = 0
                                precioFinal = Math.Round((rowDT.Item("lpbp_preciobase") + (rowDT.Item("lpbp_preciobase") * (rowGr.Cells("incremento").Value / 100))), MidpointRounding.AwayFromZero)
                                If precioFinal > 0 Then
                                    precioDesc = precioFinal
                                    For Each dtRow As DataRow In dtDatosDescuentos.Rows
                                        If CBool(dtRow.Item("decl_descuentoenporcentaje")) = True Then
                                            precioDesc = precioDesc - (precioFinal * (dtRow.Item("decl_cantidaddescuento") / 100))
                                        Else
                                            precioDesc = precioDesc - dtRow.Item("decl_cantidaddescuento")
                                        End If
                                    Next
                                End If
                                objLVCBU.guardarDatosListaPreciosClienteProductos(idRegNuevaListaCopiada, rowDT.Item("lpcp_productoestiloid"), rowDT.Item("lpbp_preciobase"), precioFinal, precioDesc, 0, 0, rowGr.Cells("lpvt_listaprecioventaid").Value, 1)
                            Next
                        End If
                    End If
                ElseIf estatusLB = "ACTIVA" Then
                    Dim descuentoDt As Double = 0.0
                    Dim facturarIdDt As Int32 = 0
                    Dim tipoFleteid As Int32 = 0
                    Dim tipoivaId As Int32 = 0

                    If rowGr.Cells("descConf").Value.ToString <> "" Then
                        descuentoDt = rowGr.Cells("descConf").Value
                    Else
                        If rowGr.Cells("Descuento").Value.ToString = "" Then
                            descuentoDt = 0
                        Else
                            descuentoDt = rowGr.Cells("Descuento").Value
                        End If
                    End If

                    If rowGr.Cells("ccla_facturar").Value.ToString <> "" Then
                        facturarIdDt = rowGr.Cells("ccla_facturar").Value
                    Else
                        facturarIdDt = rowGr.Cells("iccl_facturar").Value
                    End If

                    If rowGr.Cells("ccla_tipofleteid").Value.ToString <> "" Then
                        tipoFleteid = rowGr.Cells("ccla_tipofleteid").Value
                    Else
                        tipoFleteid = rowGr.Cells("iccl_tipofleteid").Value
                    End If

                    If rowGr.Cells("ccla_tipoivaid").Value.ToString <> "" Then
                        tipoivaId = rowGr.Cells("ccla_tipoivaid").Value
                    Else
                        tipoivaId = rowGr.Cells("iccl_tipoivaid").Value
                    End If

                    idRegNuevaListaCopiada = objLVCBU.copiarListaClienteProductos(idListaVentas, idListaVentasClienteProd, rowGr.Cells("lvcl_listaventasclienteid").Value,
                                                                                           descuentoDt, facturarIdDt, tipoFleteid, tipoivaId,
                                                                                            rowGr.Cells("incremento").Value, rowGr.Cells("porcent").Value)
                    If idRegNuevaListaCopiada > 0 Then
                        contCopiadosTotal += 1
                        rowGr.Cells("nuevaListaID").Value = idRegNuevaListaCopiada.ToString
                        rowGr.Cells("ESTATUS").Value = "CAPTURADA"

                        If CBool(rowGr.Cells("calculaDesc").Value) = False Then
                            Dim precioFinal As Int32 = 0
                            For Each rowDT As DataRow In dtArticulos.Rows
                                precioFinal = 0
                                precioFinal = Math.Round((rowDT.Item("lpbp_preciobase") + (rowDT.Item("lpbp_preciobase") * (rowGr.Cells("incremento").Value / 100))), MidpointRounding.AwayFromZero)
                                objLVCBU.guardarDatosListaPreciosClienteProductos(idRegNuevaListaCopiada, rowDT.Item("lpcp_productoestiloid"), rowDT.Item("lpbp_preciobase"), precioFinal, precioFinal, 0, 0, rowGr.Cells("lpvt_listaprecioventaid").Value, 1)
                            Next
                        Else
                            Dim objListaVBU As New Negocios.ListaVentasBU
                            Dim dtDescuentoConfigurado As New DataTable
                            Dim totalDescuento As Double = 0.0
                            Dim precioFinal As Int32 = 0
                            Dim precioDesc As Double = 0
                            Dim objClientesDDA As New Negocios.ClientesDatosBU

                            dtDescuentoConfigurado = objListaVBU.consultaConfiguracionDescuentoClienteLV(rowGr.Cells("lpvt_listaprecioventaid").Value, rowGr.Cells("clie_clienteid").Value)
                            If dtDescuentoConfigurado.Rows.Count > 0 Then
                                For Each rowDT As DataRow In dtArticulos.Rows
                                    precioFinal = 0
                                    precioDesc = 0
                                    precioFinal = Math.Round((rowDT.Item("lpbp_preciobase") + (rowDT.Item("lpbp_preciobase") * (rowGr.Cells("incremento").Value / 100))), MidpointRounding.AwayFromZero)
                                    If precioFinal > 0 Then
                                        precioDesc = precioFinal
                                        For Each dtRow As DataRow In dtDescuentoConfigurado.Rows
                                            If CBool(dtRow.Item("cdlv_porcentaje")) = True Then
                                                precioDesc = precioDesc - (precioFinal * (dtRow.Item("cdlv_cantidad") / 100))
                                            Else
                                                precioDesc = precioDesc - dtRow.Item("cdlv_cantidad")
                                            End If
                                        Next
                                    End If
                                    objLVCBU.guardarDatosListaPreciosClienteProductos(idRegNuevaListaCopiada, rowDT.Item("lpcp_productoestiloid"), rowDT.Item("lpbp_preciobase"), precioFinal, precioDesc, 0, 0, rowGr.Cells("lpvt_listaprecioventaid").Value, 1)
                                Next

                            Else
                                Dim dtDatosDescuentos As New DataTable
                                dtDatosDescuentos = objClientesDDA.Datos_TablaDescuentosCliente(rowGr.Cells("clie_clienteid").Value, 0)
                                For Each rowDT As DataRow In dtArticulos.Rows
                                    precioFinal = 0
                                    precioDesc = 0
                                    precioFinal = CDbl(rowDT.Item("lpbp_preciobase") + (rowDT.Item("lpbp_preciobase") * (rowGr.Cells("incremento").Value / 100))).ToString("N2")
                                    If precioFinal > 0 Then
                                        precioDesc = precioFinal
                                        For Each dtRow As DataRow In dtDatosDescuentos.Rows
                                            If CBool(dtRow.Item("decl_descuentoenporcentaje")) = True Then
                                                precioDesc = precioDesc - (precioFinal * (dtRow.Item("decl_cantidaddescuento") / 100))
                                            Else
                                                precioDesc = precioDesc - dtRow.Item("decl_cantidaddescuento")
                                            End If
                                        Next
                                    End If
                                    objLVCBU.guardarDatosListaPreciosClienteProductos(idRegNuevaListaCopiada, rowDT.Item("lpcp_productoestiloid"), rowDT.Item("lpbp_preciobase"), precioFinal, precioDesc, 0, 0, rowGr.Cells("lpvt_listaprecioventaid").Value, 1)
                                Next
                            End If
                        End If
                    End If
                End If
                    rowGr.Cells("Copia").Appearance.BackColor = Color.LimeGreen
                    contCopiados += 1
                lblClientesCopiadosCont.Text = contCopiados.ToString + "/" + contTotal.ToString
            End If
        Next
        chkSeleccionarFiltrados.Checked = False

        For Each rowGR As UltraGridRow In grdClientes.Rows.GetFilteredInNonGroupByRows
            rowGR.Cells("Seleccion").Value = False
        Next
        lblContClientes.Text = "0"
        lblEstatusCont.Text = "0"

        If contCopiadosTotal = 0 Then

            Me.Cursor = Cursors.Default
            Dim objMensajeGuardar As New Tools.AdvertenciaForm
            objMensajeGuardar.mensaje = "No se realizó ninguna copia."
            objMensajeGuardar.ShowDialog()
        Else
            Me.Cursor = Cursors.Default
            btnCambiarEstatus.Enabled = True
            lblCambiarEstatus.Enabled = True
            Dim objMensajeGuardar As New Tools.ExitoFormGrande
            objMensajeGuardar.mensaje = "Copias generadas exitosamente. (Todas las listas copiadas se encuentran en estatus CAPTURADA. Puede convertirlas en ACEPTADAS seleccionando al cliente del listado y dando click cn CAMBIAR A ACEPTADAS, sin cerrar esta ventana)."
            objMensajeGuardar.ShowDialog()
        End If
    End Sub

    Public Sub cambiarEstatus()
        Dim objLVCL As New Negocios.ListaPreciosVentaClienteBU
        For Each rowGR As UltraGridRow In grdClientes.Rows.GetFilteredInNonGroupByRows
            If rowGR.Cells("Seleccion").Value = True And rowGR.Cells("nuevaListaID").Value.ToString <> "" Then
                objLVCL.cambiarEstatusListaPreciosCLiente(rowGR.Cells("nuevaListaID").Value, 26)
                lblEstatusCont.Text = CInt(lblEstatusCont.Text) - 1
                rowGR.Cells("ESTATUS").Value = "ACEPTADA"
                rowGR.Cells("Seleccion").Value = False
                rowGR.Cells("Seleccion").Activation = Activation.NoEdit
            End If
        Next
    End Sub

    Public Function validarFechaCambiarEstatus(ByVal nombreCliente As String, ByVal listaventasclienteid As Int32, ByVal listaventasclienteprecioid As Int32) As Boolean
        Dim objLVCBU As New Negocios.ListaPreciosVentaClienteBU
        Dim dt As New DataTable
        dt = objLVCBU.consultaValidarVigenciaPorListaCliente(listaventasclienteid, listaventasclienteprecioid)
        Dim FechaMinima As Date
        Dim FechaMaxima As Date
        If dt.Rows.Count > 0 Then
            FechaMinima = CDate(dt.Rows(0).Item("lvcp_vigenciainicio").ToString)
            FechaMaxima = CDate(dt.Rows(0).Item("lvcp_vigenciafin").ToString)
            If (CDate(dttVigenciaInicio.Value.ToShortDateString) <= FechaMinima And CDate(dttVigenciaFin.Value.ToShortDateString) <= FechaMinima) Or (CDate(dttVigenciaInicio.Value.ToShortDateString) >= FechaMaxima And CDate(dttVigenciaFin.Value.ToShortDateString) >= FechaMaxima) Then
                Return True
            Else
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim contTotal As Int32 = 0
        For Each rowGrcolor As UltraGridRow In grdClientes.Rows
            If CBool(rowGrcolor.Cells("Seleccion").Value) = True And rowGrcolor.Cells("nuevaListaID").Value.ToString = "" Then
                contTotal += 1
            End If
        Next
        If contTotal > 0 Then
            Dim objMsjConfirmar As New Tools.confirmarFormGrande
            Dim cadenaMensaje As String = "Las listas copiadas se generarán con la misma descripción y vigencia de la lista original," +
                " en caso necesario modifique esta información antes de realizar la copia, ya que una vez copiadas deberá modificar" +
                " las listas una a una.¿ Está seguro de copiar la lista del cliente " + txtCliente.Text +
                " (" + txtListaVentasCliente.Text +
                ") a los " + contTotal.ToString +
                " clientes seleccionados ? (Una vez iniciado el proceso de copia no se puede cancelar, este proceso puede tardar varios minutos)"
            lblClientesCopiadosCont.Text = "0/" + contTotal.ToString
            objMsjConfirmar.mensaje = cadenaMensaje
            If objMsjConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim objCaptcha As New Tools.frmCaptcha
                objCaptcha.mensaje = "Copias por generar: " + contTotal.ToString
                If objCaptcha.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.Cursor = Cursors.WaitCursor
                    guardarCopias()
                    Me.Cursor = Cursors.Default
                Else
                    lblClientesCopiadosCont.Text = "0/0"
                End If
            Else
                lblClientesCopiadosCont.Text = "0/0"
            End If
        Else
            lblClientesCopiadosCont.Text = "0/0"
            Dim objMensajeGuardar As New Tools.AdvertenciaForm
            objMensajeGuardar.mensaje = "No selecciono clientes disponibles para la copia."
            objMensajeGuardar.ShowDialog()
        End If
    End Sub

    Public Function validarCerrar() As Boolean

        Dim contCopiadas As Int32 = 0
        For Each rowGR As UltraGridRow In grdClientes.Rows
            If rowGR.Cells("ESTATUS").Value.ToString = "CAPTURADA" Then
                contCopiadas += 1
            End If
        Next
        If contCopiadas > 0 Then
            Return False
        End If
        Return True
    End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grpDatos.Height = 110
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grpDatos.Height = 42
    End Sub

    Private Sub frmListaClientesPosibleCopia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing


        If validarCerrar() = False Then
            Dim objMensajeGuardar As New Tools.confirmarFormGrande
            objMensajeGuardar.mensaje = "Se generaron copias de listas de precios, pero no se modificaron al status ACEPTADA ¿Está seguro de cerrar esta pantalla sin hacer el cambio de estatus? '(Si no desea cambiarlo en este momento, podrá hacerlo posteriormente con el botón ""Cambiar Status"" de la pantalla  ""Consulta - Lista de Precios de Cliente""."
            If objMensajeGuardar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Else
                e.Cancel = True
            End If
        End If
        'Se generaron copias de listas de precios, pero no se modificaron al status ACEPTADA ¿ Está seguro de cerrar esta pantalla sin hacer el cambio de status ?
        '(Si no desea cambiarlo en este momento, podrá hacerlo posteriormente con el botón “Cambiar Status” de la pantalla  "Consulta - Lista de Precios de Cliente".)

    End Sub

    Private Sub frmListaClientesPosibleCopia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCliente.Text = nombreCliente
        dttVigenciaInicio.Value = vigenciaInicio
        dttVigenciaFin.Value = vigenciaFin
        txtNumArts.Text = CDbl(cantArticulos).ToString("N0")
        txtUsuarioModifico.Text = usuarioModifico
        txtFechaModifico.Text = modificado
        txtListaVentasCliente.Text = nombreListaCliente

        If estatusCad = "ACEPTADA" Then
            lblEstatus.Text = "ACEPTADA"
            lblEstatus.ForeColor = Color.LimeGreen
        ElseIf estatusCad = "CERRADA" Then
            lblEstatus.Text = "CERRADA"
            lblEstatus.ForeColor = Color.Peru
        Else
            lblEstatus.Text = "ESTATUS"
        End If

        llenarTablaClientesPosibles()
        llenarTablaClientesNoCopia()
    End Sub

    Private Sub chkSeleccionarFiltrados_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarFiltrados.CheckedChanged
        Dim contadorSeleccion As Int32 = 0
        Dim contadorSelEsts As Int32 = 0
        For Each rowGR As UltraGridRow In grdClientes.Rows.GetFilteredInNonGroupByRows
            If rowGR.Cells("nuevaListaID").Value.ToString = "" Then
                If chkSeleccionarFiltrados.Checked = True Then
                    rowGR.Cells("Seleccion").Value = True
                    rowGR.Cells("Copia").Appearance.BackColor = Color.Red
                    contadorSeleccion += 1
                Else
                    rowGR.Cells("Seleccion").Value = False
                    rowGR.Cells("Copia").Appearance.BackColor = Color.White
                End If
            Else
                If rowGR.Cells("ESTATUS").Value.ToString = "CAPTURADA" Then
                    If chkSeleccionarFiltrados.Checked = True Then
                        rowGR.Cells("Seleccion").Value = True
                        contadorSelEsts += 1
                    Else
                        rowGR.Cells("Seleccion").Value = False
                    End If
                End If
                rowGR.Cells("Copia").Appearance.BackColor = Color.RoyalBlue
            End If
        Next
        lblContClientes.Text = contadorSeleccion.ToString("N0")
        lblEstatusCont.Text = contadorSelEsts.ToString
    End Sub

    Private Sub grdClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdClientes.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdClientes_CellChange(sender As Object, e As CellEventArgs) Handles grdClientes.CellChange
        If e.Cell.Column.Key = "Seleccion" And e.Cell.Row.Index <> grdClientes.Rows.FilterRow.Index Then
            Dim contadorSeleccion As Int32 = 0
            If e.Cell.Row.Cells("nuevaListaID").Value.ToString = "" Then
                If CBool(e.Cell.Text) = True Then
                    lblContClientes.Text = CInt(lblContClientes.Text) + 1
                    e.Cell.Row.Cells("Copia").Appearance.BackColor = Color.Red
                Else
                    lblContClientes.Text = CInt(lblContClientes.Text) - 1
                    e.Cell.Row.Cells("Copia").Appearance.BackColor = Color.White
                End If
            Else
                If e.Cell.Row.Cells("ESTATUS").Value.ToString = "CAPTURADA" Then
                    If CBool(e.Cell.Text) = True Then
                        lblEstatusCont.Text = CInt(lblEstatusCont.Text) + 1
                    Else
                        lblEstatusCont.Text = CInt(lblEstatusCont.Text) - 1
                    End If
                End If
                e.Cell.Row.Cells("Copia").Appearance.BackColor = Color.RoyalBlue
            End If
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

    Private Sub btnCambiarEstatus_Click(sender As Object, e As EventArgs) Handles btnCambiarEstatus.Click
        For Each rowGR As UltraGridRow In grdClientes.Rows
            If CBool(rowGR.Cells("Seleccion").Value) = True And rowGR.Cells("nuevaListaID").Value.ToString <> "" Then
                If validarFechaCambiarEstatus(rowGR.Cells("clie_nombregenerico").Value.ToString, rowGR.Cells("lvcl_listaventasclienteid").Value, rowGR.Cells("nuevaListaID").Value) = False Then
                    rowGR.Cells("Seleccion").Value = False
                    rowGR.Cells("Seleccion").Activation = Activation.NoEdit
                    Dim objMensajeGuardar As New Tools.AdvertenciaForm
                    objMensajeGuardar.mensaje = "La lista del cliente " + rowGR.Cells("clie_nombregenerico").Value.ToString + " no puede cambiar de estatus debido a que tiene otra lista de precios de cliente con una vigencia que se traslapa y debe modificarse directamente."
                    objMensajeGuardar.ShowDialog()
                End If
            End If
        Next


        Dim contTotal As Int32 = 0
        For Each rowGrcolor As UltraGridRow In grdClientes.Rows
            If CBool(rowGrcolor.Cells("Seleccion").Value) = True And rowGrcolor.Cells("nuevaListaID").Value.ToString <> "" Then
                contTotal += 1
            End If
        Next
        If contTotal > 0 Then
            Dim objMsjConfirmar As New Tools.confirmarFormGrande
            Dim cadenaMensaje As String = "Recuerde que una vez ACEPTADA una lista ya no la puede modificar, si no desea cambiar el estatus de alguna de las listas generadas, elimine la selección del cliente en el listado. ¿ Está seguro de cambiar a ACEPTADA las listas de los " + contTotal.ToString + " clientes seleccionados ? (Una vez iniciado el proceso de actualización no se puede cancelar, este proceso puede tardar varios minutos)"
            objMsjConfirmar.mensaje = cadenaMensaje
            If objMsjConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim objCaptcha As New Tools.frmCaptcha
                objCaptcha.mensaje = "Listas actualizadas: " + contTotal.ToString
                If objCaptcha.ShowDialog = Windows.Forms.DialogResult.OK Then
                    cambiarEstatus()
                Else
                    Dim objMensajeGuardar As New Tools.ExitoForm
                    objMensajeGuardar.mensaje = "Listas actualizadas con éxito"
                    objMensajeGuardar.ShowDialog()
                End If
            End If
        Else
            Dim objMensajeGuardar As New Tools.AdvertenciaForm
            objMensajeGuardar.mensaje = "Debe seleccionar al menos una lista de precios de cliente con estatus CAPTURADA."
            objMensajeGuardar.ShowDialog()
        End If
    End Sub

    Private Sub lblContClientes_TextChanged(sender As Object, e As EventArgs) Handles lblContClientes.TextChanged
        If CInt(lblContClientes.Text) > 0 Then
            btnGuardar.Enabled = True
            lblGuardar.Enabled = True
            'btnCambiarEstatus.Enabled = True
            'lblCambiarEstatus.Enabled = True
        Else
            btnGuardar.Enabled = False
            lblGuardar.Enabled = False
            'btnCambiarEstatus.Enabled = False
            'lblCambiarEstatus.Enabled = False
        End If
    End Sub

    Private Sub lblEstatusCont_TextChanged(sender As Object, e As EventArgs) Handles lblEstatusCont.TextChanged
        If CInt(lblEstatusCont.Text) > 0 Then
            btnCambiarEstatus.Enabled = True
            lblCambiarEstatus.Enabled = True
        Else
            btnCambiarEstatus.Enabled = False
            lblCambiarEstatus.Enabled = False
        End If
    End Sub

    Private Sub grdClientesNoCopia_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientesNoCopia.InitializeLayout
        Me.grdClientesNoCopia.DisplayLayout.GroupByBox.Prompt = "Arrastra para agrupar datos."
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
End Class