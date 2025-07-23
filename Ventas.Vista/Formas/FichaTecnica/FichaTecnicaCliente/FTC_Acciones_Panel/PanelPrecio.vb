Imports Infragistics.Win.UltraWinGrid
Imports System.Globalization
Imports Tools.Controles
Imports Infragistics.Win

Partial Public Class FichaTecnicaClienteForm

    Dim panelPrecio_CamposVacios As Boolean = False
    Dim PanerPrecio_RangosIncorrectos As Boolean = False
    Dim IdMonedaCliente As Integer
    Public PermitirCambioListaMoneda As Boolean ''TRUE PARA PERMITIR, FALSE PARA NEGAR

    Private Sub Recuperar_Valores_De_Lista_De_Precios(ByVal Id_Lista_De_Precio As Integer, ByVal Actual_o_Nueva As Boolean)
        Dim objPrecioBU As New Negocios.PrecioBU

        Dim dtTablaRecuperarParametros As New DataTable

        dtTablaRecuperarParametros = objPrecioBU.Recuperar_Valores_De_Lista_De_Precios(Id_Lista_De_Precio)

        For Each row As DataRow In dtTablaRecuperarParametros.Rows
            If Actual_o_Nueva = True Then
                numPrecioIncrementoParActual.Value = row.Item("Incremento")
                numPrecioIncrementoPar.Value = row.Item("Incremento")
                If row.Item("Porcentaje o moneda") Then
                    rdoPrecioPorcentajeActual.Checked = True
                    rdoPrecioIncrementoPorcentaje.Checked = True
                    rdoPrecioPesosActual.Checked = False
                    rdoPrecioIncrementoPeso.Checked = False
                Else
                    rdoPrecioPorcentajeActual.Checked = False
                    rdoPrecioIncrementoPorcentaje.Checked = False
                    rdoPrecioPesosActual.Checked = True
                    rdoPrecioIncrementoPeso.Checked = True
                End If
                numPrecioRangoFacturacionActualInicial.Value = row.Item("Facturación Inicio")
                numPrecioRangoFacturacionActualFinal.Value = row.Item("Facturación Fin")
                numPrecioRangoDescuentoActualInicial.Value = row.Item("Descuento Inicio")
                numPrecioRangoDescuentoActualFinal.Value = row.Item("Descuento Fin")

                PoblarGridIva_ListadePrecios(grdPrecioListaTipoIvaActual, cboxPrecioListaActual.SelectedValue)
                PoblarGridFlete_ListadePrecios(grdPrecioTipoFleteActual, cboxPrecioListaActual.SelectedValue)
            Else
                numPrecioIncrementoParAsignar.Value = row.Item("Incremento")
                If row.Item("Porcentaje o moneda") Then
                    rdoPrecioPorcentajeAsignar.Checked = True
                    rdoPrecioPesosAsignar.Checked = False
                Else
                    rdoPrecioPesosAsignar.Checked = True
                    rdoPrecioPorcentajeAsignar.Checked = False
                End If
                numPrecioRangoFacturacionAsignarInicial.Value = row.Item("Facturación Inicio")
                numPrecioRangoFacturacionAsignarFinal.Value = row.Item("Facturación Fin")
                numPrecioRangoDescuentoAsignarInicial.Value = row.Item("Descuento Inicio")
                numPrecioRangoDescuentoAsignarFinal.Value = row.Item("Descuento Fin")

                PoblarGridIva_ListadePrecios(grdPrecioListaTipoIvaAsignar, cboxPrecioListaNueva.SelectedValue)
                PoblarGridFlete_ListadePrecios(grdPrecioTipoFleteAsignar, cboxPrecioListaNueva.SelectedValue)
            End If
        Next

    End Sub

    Private Sub btnEditarPrecio_Click(sender As Object, e As EventArgs) Handles btnEditarPrecio.Click
        asignaStatusControles(gboxPrecioListasDeVentas, False)
        asignaStatusControles(gboxMonedaInformacionConfiguracionListaPrecios, True)
        asignaStatusControles(gboxPrecioDescuentos, True)
        asignaStatusControles(pnlBotonesPrecio, True)

        btnPrecioAsignarListadeVentas.Enabled = False

        btnEditarPrecio.Enabled = False
        cboxPrecioListaActual.Enabled = False
        numPrecioRemisionar.Enabled = False
        rdoPrecioIncrementoPorcentaje.Enabled = False
        rdoPrecioIncrementoPeso.Enabled = False
        numPrecioIncrementoPar.Enabled = False
        grdPrecioDescuentos.Enabled = True
        cmbNacionalExtranjero.Enabled = False


        If PermitirCambioListaMoneda = False Then
            cboxPrecioMoneda.Enabled = False
        End If

    End Sub

    Private Sub gboxPrecioDescuentos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gboxPrecioDescuentos.MouseDoubleClick
        If gboxPrecioDescuentos.Dock = DockStyle.Fill Then
            gboxPrecioDescuentos.Dock = DockStyle.None
            gboxMonedaInformacionConfiguracionListaPrecios.Dock = DockStyle.None
            gboxMonedaInformacionConfiguracionListaPrecios.Text = "Información para configurar la Lista de Precios"
            gboxPrecioListasDeVentas.Visible = True
        Else
            gboxPrecioDescuentos.Dock = DockStyle.Fill
            gboxMonedaInformacionConfiguracionListaPrecios.Dock = DockStyle.Fill
            gboxMonedaInformacionConfiguracionListaPrecios.Text = ""
            gboxPrecioListasDeVentas.Visible = False
        End If
    End Sub

    Private Sub recuperar_Informacion_Cliente_Para_Configurar_Lista_Precios()
        Dim objBU As New Negocios.ClientesBU
        Dim dtInformacionConfiguracionCliente As New DataTable

        dtInformacionConfiguracionCliente = objBU.recuperar_Informacion_Cliente_Para_LP(CInt(LTrim(RTrim(lblClienteSAYID_Int.Text))))
        For Each row As DataRow In dtInformacionConfiguracionCliente.Rows
            If IsDBNull(row.Item("iccl_facturar")) = False Then
                numPrecioFacturar.Value = row.Item("iccl_facturar")
                numPrecioRemisionar.Value = 100 - row.Item("iccl_facturar")
            Else
                numPrecioFacturar.Value = 0
                numPrecioFacturar.Value = 0
            End If

            cboxPrecioFlete.SelectedValue = row.Item("iccl_tipofleteid")
            cboxPrecioIva.SelectedValue = row.Item("iccl_tipoivaid")
            cboxPrecioMoneda.SelectedValue = row.Item("iccl_monedaid")
            IdMonedaCliente = row.Item("iccl_monedaid")
            If IsDBNull(row.Item("IDINCOTERM")) = False Then
                cmbINCOTERM.SelectedValue = row.Item("IDINCOTERM")
            End If
            If IsDBNull(row.Item("iccl_calcularpreciocondescuento")) = True Then
                chkCalcularConDescuentoAplicado.Checked = False
            Else
                chkCalcularConDescuentoAplicado.Checked = row.Item("iccl_calcularpreciocondescuento")
            End If
            If row.Item("porcentaje_cantidad") = "%" Then
                rdoPrecioIncrementoPorcentaje.Checked = True
                If IsDBNull(row.Item("iccl_incrementopar_porcent")) = False Then
                    numPrecioIncrementoPar.Value = row.Item("iccl_incrementopar_porcent")
                Else
                    numPrecioIncrementoPar.Value = 0
                End If
            Else
                rdoPrecioIncrementoPeso.Checked = True
                If IsDBNull(row.Item("iccl_incrementopar_monto")) = False Then
                    numPrecioIncrementoPar.Value = row.Item("iccl_incrementopar_monto")
                Else
                    numPrecioIncrementoPar.Value = 0
                End If

            End If

        Next


    End Sub

    Private Sub cboxPrecioListaNueva_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboxPrecioListaNueva.SelectedValueChanged
        If cboxPrecioListaNueva.SelectedIndex <= 0 Then
            btnPrecioAsignarListadeVentas.Enabled = False
            lblPrecioFacturar.ForeColor = Color.Black
            lblPrecioRemisionar.ForeColor = Color.Black
            lblPrecioMoneda.ForeColor = Color.Black
            lblPrecioFlete.ForeColor = Color.Black
            lblPrecioIva.ForeColor = Color.Black
            gboxPrecioDescuentos.ForeColor = Color.Black

            numPrecioIncrementoParAsignar.Value = 0
            numPrecioRangoDescuentoAsignarInicial.Value = 0
            numPrecioRangoDescuentoAsignarFinal.Value = 0
            numPrecioRangoFacturacionAsignarInicial.Value = 0
            numPrecioRangoFacturacionAsignarFinal.Value = 0

            grdPrecioTipoFleteAsignar.DataSource = Nothing
            grdPrecioListaTipoIvaAsignar.DataSource = Nothing

            Return
        End If

        Recuperar_Valores_De_Lista_De_Precios(cboxPrecioListaNueva.SelectedValue, False)

        valdiar_Lista_De_Precios_Nueva_Dentro_Del_Rango()

        If PanerPrecio_RangosIncorrectos = True Then
            btnPrecioAsignarListadeVentas.Enabled = False
            Return
        Else

            If lista_RecuperadA.Length = 3 Then
                btnPrecioAsignarListadeVentas.Enabled = False
            Else
                btnPrecioAsignarListadeVentas.Enabled = True
            End If
         

        End If
    End Sub

    Private Sub valdiar_Lista_De_Precios_Nueva_Dentro_Del_Rango()
        Dim lTiposIVA As New List(Of String)
        Dim lTiposFlete As New List(Of String)

        ''Validacion de Facturar
        If numPrecioFacturar.Value < numPrecioRangoFacturacionAsignarInicial.Value Or _
            numPrecioFacturar.Value > numPrecioRangoFacturacionAsignarFinal.Value Then
            PanerPrecio_RangosIncorrectos = True
            lblPrecioFacturar.ForeColor = Color.Red
            lblPrecioRemisionar.ForeColor = Color.Red
        Else
            PanerPrecio_RangosIncorrectos = False
            lblPrecioFacturar.ForeColor = Color.Black
            lblPrecioRemisionar.ForeColor = Color.Black
        End If

        ''Validacion de Tipo de IVA
        For Each row As UltraGridRow In grdPrecioListaTipoIvaAsignar.Rows
            lTiposIVA.Add(LTrim(RTrim(row.Cells(1).Value)))
        Next

        If lTiposIVA.Contains(LTrim(RTrim(cboxPrecioIva.Text))) Then
            If PanerPrecio_RangosIncorrectos = True Then
                PanerPrecio_RangosIncorrectos = True
            Else
                PanerPrecio_RangosIncorrectos = False
            End If
            lblPrecioIva.ForeColor = Color.Black
        Else
            PanerPrecio_RangosIncorrectos = True
            lblPrecioIva.ForeColor = Color.Red
        End If

        ''Validacion de Tipo de flete
        For Each row As UltraGridRow In grdPrecioTipoFleteAsignar.Rows
            lTiposFlete.Add(LTrim(RTrim(row.Cells(1).Value)))
        Next

        If lTiposFlete.Contains(LTrim(RTrim(cboxPrecioFlete.Text))) Then
            If PanerPrecio_RangosIncorrectos = True Then
                PanerPrecio_RangosIncorrectos = True
            Else
                PanerPrecio_RangosIncorrectos = False
            End If
            lblPrecioFlete.ForeColor = Color.Black
        Else
            PanerPrecio_RangosIncorrectos = True
            lblPrecioFlete.ForeColor = Color.Red
        End If

        ''Validacion Descuentos
        Dim totaldescuentos As Double

        For Each row As UltraGridRow In grdPrecioDescuentos.Rows
            totaldescuentos = totaldescuentos + row.Cells("decl_cantidaddescuento").Value
        Next

        If totaldescuentos < numPrecioRangoDescuentoAsignarInicial.Value Or totaldescuentos > numPrecioRangoDescuentoAsignarFinal.Value Then
            PanerPrecio_RangosIncorrectos = True
            gboxPrecioDescuentos.ForeColor = Color.Red
        Else
            If PanerPrecio_RangosIncorrectos = True Then
                PanerPrecio_RangosIncorrectos = True
            Else
                PanerPrecio_RangosIncorrectos = False
            End If
            gboxPrecioDescuentos.ForeColor = Color.Black
        End If

    End Sub

    Private Sub numPrecioFacturar_ValueChanged(sender As Object, e As EventArgs) Handles numPrecioFacturar.ValueChanged
        numPrecioRemisionar.Value = 100 - numPrecioFacturar.Value
    End Sub

    Private Sub btnGuardarPrecio_Click(sender As Object, e As EventArgs) Handles btnGuardarPrecio.Click

        Dim objExitoForm As New Tools.ExitoForm
        Dim objAviso As New Tools.AvisoForm
        Dim objAdvertencia As New Tools.AdvertenciaForm


        'DESACTIVAMOS LA FILA ACTIVA DEL GRID POR SI SE HISO ALGUN CAMBIO Y NO DIERON ENTER PARA GUARDAR
        If IsNothing(grdPrecioDescuentos.ActiveRow) = False Then
            'grdPrecioDescuentos.ActiveRow.DataChanged = True
            grdPrecioDescuentos.ActiveRow.Activated = False
        End If

        Dim resultado_Operacion As String
        validarCamposVacios_PanelPrecio()

        If panelPrecio_CamposVacios = True Then Return

        Validar_campos_Dentro_Del_Rango_De_Lista_De_Precios()

        If PanerPrecio_RangosIncorrectos = True Then Return


        If IdMonedaCliente <> cboxPrecioMoneda.SelectedValue Then
            Dim objCaptcha As New Tools.frmCaptcha
            objCaptcha.mensaje = "Se actualizara el tipo de moneda para el cliente."
            objCaptcha.Tamaño_Letra = 11

            objCaptcha.StartPosition = FormStartPosition.CenterScreen

            If objCaptcha.ShowDialog = Windows.Forms.DialogResult.OK Then
                objAviso.mensaje = "Este proceso puede tardar, dependiendo de la cantidad de estilos encontrados en la lista de precios del cliente."
                objAviso.StartPosition = FormStartPosition.CenterScreen
                objAviso.ShowDialog()
                Me.Cursor = Cursors.WaitCursor
                resultado_Operacion = Guardar_Valores_de_Lista_de_Precios()
            End If
        Else
            Me.Cursor = Cursors.WaitCursor
            resultado_Operacion = Guardar_Valores_de_Lista_de_Precios()
        End If

        If resultado_Operacion = "EXITO" Then
            Acciones_Cancelar()
            txtnota.Text = LlenarDetalleNotaListaPrecio(CInt(cboxPrecioListaActual.SelectedValue), CInt(LTrim(RTrim(lblClienteSAYID_Int.Text))))

        End If

        chkCalcularConDescuentoAplicado.ForeColor = Color.Black

        Me.Cursor = Cursors.Default

    End Sub

    Private Function Guardar_Valores_de_Lista_de_Precios() As String
        Dim objBUPrecio As New Negocios.PrecioBU
        Dim TotalDescuentos As Double = 0
        Dim dtResultadoOperacion As New DataTable
        Dim resultado_Operacion As String
        Dim incoterm As Integer

        If cmbINCOTERM.SelectedValue > 0 Then
            incoterm = cmbINCOTERM.SelectedValue
        Else
            incoterm = 0
        End If

        For Each row As UltraGridRow In grdPrecioDescuentos.Rows
            TotalDescuentos = TotalDescuentos + row.Cells("decl_cantidaddescuento").Value
        Next

        dtResultadoOperacion = objBUPrecio.Guardar_Valores_de_Lista_de_Precios(CInt(lblClienteSAYID_Int.Text), cboxPrecioListaActual.SelectedValue, TotalDescuentos, _
                                                        numPrecioFacturar.Value, cboxPrecioFlete.SelectedValue, cboxPrecioIva.SelectedValue, _
                                                        cboxPrecioMoneda.SelectedValue, incoterm, chkCalcularConDescuentoAplicado.Checked)

        resultado_Operacion = dtResultadoOperacion.Rows(0).Item(0)

        If resultado_Operacion = "EXITO" Then
            Dim MensajeExito As New Tools.ExitoForm
            MensajeExito.mensaje = "Los datos se actualizaron correctamente."
            MensajeExito.StartPosition = FormStartPosition.CenterScreen
            MensajeExito.ShowDialog()
        Else
            Dim MensajeError As New Tools.ErroresForm
            MensajeError.mensaje = "Ocurrio un error, por favor vuelve a presionar 'Guardar'."
            MensajeError.StartPosition = FormStartPosition.CenterScreen
            MensajeError.ShowDialog()
        End If

        Return resultado_Operacion
    End Function

    Private Sub Validar_campos_Dentro_Del_Rango_De_Lista_De_Precios()
        Dim lTiposIVA As New List(Of String)
        Dim lTiposFlete As New List(Of String)

        Dim advertencia As New Tools.AdvertenciaForm
        advertencia.StartPosition = FormStartPosition.CenterScreen
        advertencia.Tamaño_Letra = 9.5

        ''Validacion de Facturar
        If numPrecioFacturar.Value < numPrecioRangoFacturacionActualInicial.Value Or _
            numPrecioFacturar.Value > numPrecioRangoFacturacionActualFinal.Value Then
            advertencia.mensaje = "ALERTA: El valor del campo FACTURAR no se encuentra dentro del rango" +
                " configurado en la lista de ventas" + cboxListaDePreciosEncabezado.Text + ". Si desea capturar este valor, " +
                "asigne al cliente la LISTA DE VENTAS TEMPORAL, cambie el valor del campo y asigne una nueva lista de precios."
            advertencia.ShowDialog()
            PanerPrecio_RangosIncorrectos = True
        Else
            PanerPrecio_RangosIncorrectos = False
        End If

        ''Validacion de Tipo de IVA
        For Each row As UltraGridRow In grdPrecioListaTipoIvaActual.Rows
            lTiposIVA.Add(LTrim(RTrim(row.Cells(1).Value)))
        Next

        If lTiposIVA.Contains(LTrim(RTrim(cboxPrecioIva.Text))) Then
            If PanerPrecio_RangosIncorrectos = True Then
                PanerPrecio_RangosIncorrectos = True
            Else
                PanerPrecio_RangosIncorrectos = False
            End If
        Else
            PanerPrecio_RangosIncorrectos = True
            advertencia.mensaje = "ALERTA: El IVA seleccionado no se encuentra dentro del listado configurado en la lista de ventas" +
                " " + cboxListaDePreciosEncabezado.Text + ". Si desea capturar este valor, asigne al cliente la LISTA DE VENTAS TEMPORAL," +
                " cambie el valor del campo y asigne una nueva lista de precios."
            advertencia.ShowDialog()
        End If

        ''Validacion de Tipo de flete
        For Each row As UltraGridRow In grdPrecioTipoFleteActual.Rows
            lTiposFlete.Add(LTrim(RTrim(row.Cells(1).Value)))
        Next

        If lTiposFlete.Contains(LTrim(RTrim(cboxPrecioFlete.Text))) Then
            If PanerPrecio_RangosIncorrectos = True Then
                PanerPrecio_RangosIncorrectos = True
            Else
                PanerPrecio_RangosIncorrectos = False
            End If
        Else
            PanerPrecio_RangosIncorrectos = True
            advertencia.mensaje = "ALERTA: El FLETE seleccionado no se encuentra dentro del listado configurado en la lista de ventas" +
                " " + cboxListaDePreciosEncabezado.Text + ". Si desea capturar este valor, asigne al cliente la LISTA DE VENTAS TEMPORAL," +
                " cambie el valor del campo y asigne una nueva lista de precios."
            advertencia.ShowDialog()
        End If
    End Sub

    Private Sub validarCamposVacios_PanelPrecio()
        If cboxPrecioMoneda.SelectedIndex <= 0 And cboxPrecioFlete.SelectedIndex <= 0 And cboxPrecioIva.SelectedIndex <= 0 Then
            lblPrecioMoneda.ForeColor = Color.Red
            lblPrecioFlete.ForeColor = Color.Red
            lblPrecioIva.ForeColor = Color.Red
            panelPrecio_CamposVacios = True
        ElseIf cboxPrecioMoneda.SelectedIndex <= 0 And cboxPrecioFlete.SelectedIndex <= 0 Then
            lblPrecioMoneda.ForeColor = Color.Red
            lblPrecioFlete.ForeColor = Color.Red
            lblPrecioIva.ForeColor = Color.Black
            panelPrecio_CamposVacios = True
        ElseIf cboxPrecioMoneda.SelectedIndex <= 0 And cboxPrecioIva.SelectedIndex <= 0 Then
            lblPrecioMoneda.ForeColor = Color.Red
            lblPrecioFlete.ForeColor = Color.Black
            lblPrecioIva.ForeColor = Color.Red
            panelPrecio_CamposVacios = True
        ElseIf cboxPrecioFlete.SelectedIndex <= 0 And cboxPrecioIva.SelectedIndex <= 0 Then
            lblPrecioMoneda.ForeColor = Color.Black
            lblPrecioFlete.ForeColor = Color.Red
            lblPrecioIva.ForeColor = Color.Red
            panelPrecio_CamposVacios = True
        ElseIf cboxPrecioMoneda.SelectedIndex <= 0 Then
            lblPrecioMoneda.ForeColor = Color.Red
            lblPrecioIva.ForeColor = Color.Black
            lblPrecioFlete.ForeColor = Color.Black
            panelPrecio_CamposVacios = True
        ElseIf cboxPrecioFlete.SelectedIndex <= 0 Then
            lblPrecioMoneda.ForeColor = Color.Black
            lblPrecioIva.ForeColor = Color.Black
            lblPrecioFlete.ForeColor = Color.Red
            panelPrecio_CamposVacios = True
        ElseIf cboxPrecioIva.SelectedIndex <= 0 Then
            lblPrecioMoneda.ForeColor = Color.Red
            lblPrecioIva.ForeColor = Color.Black
            lblPrecioFlete.ForeColor = Color.Red
            panelPrecio_CamposVacios = True
        Else
            lblPrecioMoneda.ForeColor = Color.Black
            lblPrecioIva.ForeColor = Color.Black
            lblPrecioFlete.ForeColor = Color.Black
            panelPrecio_CamposVacios = False
        End If

    End Sub

    Private Sub btnCancelarPrecio_Click(sender As Object, e As EventArgs) Handles btnCancelarPrecio.Click
        If Mensajes_Y_Alertas("CONFIRMACION", "Los cambios realizados no se han guardado ¿Desea cancelar los cambios?") Then
            Acciones_Cancelar()
        End If
    End Sub

    Private Sub Acciones_Cancelar()
        asignaStatusControles(gboxPrecioListasDeVentas, True)
        asignaStatusControles(gboxPrecioValoresdeConfiguracionActual, False)
        asignaStatusControles(gboxPrecioValoresdeConfiguracionAsignar, False)
        btnPrecioAsignarListadeVentas.Enabled = False

        asignaStatusControles(gboxMonedaInformacionConfiguracionListaPrecios, False)
        asignaStatusControles(gboxPrecioDescuentos, False)

        asignaStatusControles(pnlBotonesPrecio, False)
        btnEditarPrecio.Enabled = True

        'RECUPERA LOS PARAMETROS DE LA LISTA DE PRECIOS PARA ASIGNARLA A LA SECCION DE LA LISTA SELECCIONADA
        Recuperar_Valores_De_Lista_De_Precios(cboxPrecioListaActual.SelectedValue, True)
        grdPrecioDescuentos.Enabled = False
        recuperar_Informacion_Cliente_Para_Configurar_Lista_Precios()

        cboxPrecioListaNueva.SelectedIndex = 0
        cboxPrecioListaActual.Enabled = False
        lblPrecioIva.ForeColor = Color.Black
        lblPrecioFlete.ForeColor = Color.Black
        lblPrecioMoneda.ForeColor = Color.Black

        If lista_RecuperadA.Length < 3 Then
            btnListadoPreciosPanelPrecio.Enabled = False
            btnImprimir.Enabled = False
        Else
            btnPrecioAsignarListadeVentas.Enabled = False
        End If
    End Sub

    Private Sub cboxPrecioMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxPrecioMoneda.SelectedIndexChanged
        Dim dtParidadMoneda As New DataTable

        If cboxPrecioMoneda.SelectedIndex <= 0 Then Return

        dtParidadMoneda = Recuperar_Paridad_Moneda()

        If dtParidadMoneda.Rows.Count = 0 Then
            lblParidadFecha.Text = ""
            lblCambioPesos.Text = "$ 1 = $ 1.00"
        Else
            For Each row As DataRow In dtParidadMoneda.Rows
                Dim pesos As Double = CStr(row.Item(3))
                lblParidadFecha.Text = (row.Item(4))
                lblCambioPesos.Text = "1 " + (row.Item(2)) + " = $ " + pesos.ToString("0,0.00", CultureInfo.InvariantCulture)
            Next
        End If

    End Sub

    Private Function Recuperar_Paridad_Moneda() As DataTable
        Dim objBUPrecio As New Negocios.PrecioBU
        Recuperar_Paridad_Moneda = objBUPrecio.Recuperar_Paridad_Moneda(cboxPrecioMoneda.SelectedValue)
        Return Recuperar_Paridad_Moneda
    End Function

    Private Sub btnListadoPreciosPanelPrecio_Click(sender As Object, e As EventArgs) Handles btnListadoPreciosPanelPrecio.Click
        Dim objListaVentas As New Ventas.Vista.AltaConfiguracionListaPreciosCliente
        Dim objPrecioBU As New Negocios.PrecioBU
        Dim dtDatosLVCP As New DataTable

        Dim NombreListaVentaClientePrecio = lista_RecuperadA(2)

        dtDatosLVCP = objPrecioBU.RecuperarInformacionListaVentaClientePrecio(CInt(lblClienteSAYID_Int.Text), cboxListaDePreciosEncabezado.SelectedValue, lista_RecuperadA(2))

        objListaVentas.idListaBase = dtDatosLVCP.Rows(0).Item("idListaBase")
        objListaVentas.nombreListaBase = dtDatosLVCP.Rows(0).Item("ListaBase")

        objListaVentas.idListaPreciosVentas = dtDatosLVCP.Rows(0).Item("idListaVentas")
        objListaVentas.nombreListaPreciosVentas = dtDatosLVCP.Rows(0).Item("ListaVentas")
        objListaVentas.incrementoListaVentas = dtDatosLVCP.Rows(0).Item("inxpar")

        objListaVentas.idListaVentasCliente = dtDatosLVCP.Rows(0).Item("idListaVentasCliente")
        objListaVentas.nombreCliente = dtDatosLVCP.Rows(0).Item("Cliente")

        objListaVentas.tipoClienteId = dtDatosLVCP.Rows(0).Item("tipoCliente")
        objListaVentas.idClienteFTC = dtDatosLVCP.Rows(0).Item("idsay")
        objListaVentas.idListaVentasClientePrecio = dtDatosLVCP.Rows(0).Item("idListaVentasClientePrecio")
        objListaVentas.fechaMin = dtDatosLVCP.Rows(0).Item("lpvt_vigenciainicio")
        objListaVentas.fechaMax = dtDatosLVCP.Rows(0).Item("lpvt_vigenciafin")
        objListaVentas.accionPantalla = "CONSULTA"

        If dtDatosLVCP.Rows(0).Item("lpba_estatus") = 1 Then
            objListaVentas.estatusLB = "ACTIVA"
        ElseIf dtDatosLVCP.Rows(0).Item("lpba_estatus") = 2 Then
            objListaVentas.estatusLB = "AUTORIZADA"
        Else
            objListaVentas.estatusLB = "INACTIVA"
        End If

        objListaVentas.ftc = True

        'idListaBase = recuperar_Id_Lista_Base()
        objListaVentas.StartPosition = FormStartPosition.CenterScreen
        objListaVentas.idClienteFTC = CInt(lblClienteSAYID_Int.Text)
        objListaVentas.ShowDialog()

    End Sub

    Private Function recuperar_Id_Lista_Base() As Integer
        Dim objBUPrecio As New Negocios.PrecioBU
        Dim dtListaBase As New DataTable
        dtListaBase = objBUPrecio.recuperar_Id_Lista_Base(cboxListaDePreciosEncabezado.SelectedValue)
        recuperar_Id_Lista_Base = dtListaBase.Rows(0).Item(0)
        Return recuperar_Id_Lista_Base

    End Function

    Private Sub btnPrecioAsignarListadeVentas_Click(sender As Object, e As EventArgs) Handles btnPrecioAsignarListadeVentas.Click
        AsignarListaDeVentas()
    End Sub

    Private Sub AsignarListaDeVentas()
        Dim objCaptcha As New Tools.frmCaptcha
        objCaptcha.mensaje = "Se actualizara la lista de ventas para el cliente."
        objCaptcha.StartPosition = FormStartPosition.CenterScreen
        objCaptcha.Tamaño_Letra = 12
        If objCaptcha.ShowDialog = Windows.Forms.DialogResult.OK Then


            Dim resultadoAsignacion As String

            Dim objAviso As New Tools.AvisoForm
            objAviso.mensaje = "Este proceso puede tardar, dependiendo de la cantidad de estilos econtrados en la lista de precios del cliente."
            objAviso.StartPosition = FormStartPosition.CenterScreen
            objAviso.ShowDialog()
            Me.Cursor = Cursors.WaitCursor
            resultadoAsignacion = Asignar_Nueva_Lista_De_Precios_A_Cliente()

            If resultadoAsignacion = "EXITO" Then
                Dim MensajeExito As New Tools.ExitoForm
                MensajeExito.mensaje = "La lista de precios se asignó correctamente."
                MensajeExito.StartPosition = FormStartPosition.CenterScreen
                MensajeExito.ShowDialog()

                ''RECUPERAMOS LOS VALORES DE LA LISTA DE PRECIOS ACTUAL ASIGNADA Y LA MOSTRAMOS SUS VALORES EN LOS CAMPOS CORRESPONDIENTES
                ListaListaDePecios(cboxListaDePreciosEncabezado, CInt(LTrim(RTrim(lblClienteSAYID_Int.Text))), False, False) ''Cabecera
                ListaListaDePecios(cboxPrecioListaActual, CInt(LTrim(RTrim(lblClienteSAYID_Int.Text))), False, True) ''Actual
                ListaListaDePecios(cboxPrecioListaNueva, CInt(LTrim(RTrim(lblClienteSAYID_Int.Text))), True, False) ''Nueva
                Recuperar_Valores_De_Lista_De_Precios(cboxPrecioListaActual.SelectedValue, True)
                recuperar_Informacion_Cliente_Para_Configurar_Lista_Precios()
            Else
                Dim MensajeError As New Tools.ErroresForm
                MensajeError.mensaje = "Ocurrio un error al momento de cambiar la lista de precios, por favor vuelve a presionar guardar."
                MensajeError.StartPosition = FormStartPosition.CenterScreen
                MensajeError.ShowDialog()
                Return
            End If

            Me.Cursor = Cursors.Default

        End If

    End Sub


    Private Function Asignar_Nueva_Lista_De_Precios_A_Cliente() As String
        Dim objBUPrecio As New Negocios.PrecioBU
        Dim dtResultado As New DataTable

        dtResultado = objBUPrecio.Asignar_Nueva_Lista_De_Precios_A_Cliente(cboxPrecioListaActual.SelectedValue, cboxPrecioListaNueva.SelectedValue, _
                                                                           cboxPrecioMoneda.SelectedValue, CInt(lblClienteSAYID_Int.Text))

        Return dtResultado.Rows(0).Item(0)
    End Function

    'Private Sub rbtnPrecioIncrementoCantidad_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnPrecioIncrementoCantidad.CheckedChanged

    '    If rbtnPrecioIncrementoCantidad.Checked Then
    '        numPrecioIncrementoXParCantidad.Enabled = True
    '        numPrecioIncrementoXParPorcentaje.Enabled = False
    '    ElseIf rbtnPrecioIncrementoPorcentaje.Checked Then
    '        numPrecioIncrementoXParPorcentaje.Enabled = True
    '        numPrecioIncrementoXParCantidad.Enabled = False
    '    End If

    'End Sub

    'Private Sub btnGuardarPanelPrecio_Click(sender As Object, e As EventArgs) Handles btnGuardarPrecio.Click

    '    Try
    '        editar_Precio_Cobranza_InfoCliente()
    '        editar_Precio_Cliente_Clientes()
    '        'editar_Precio_Cliente_ClienteRFC()
    '    Catch ex As Exception
    '        show_message("Error", "Algo falló en la operación")
    '        Exit Sub
    '    End Try
    '    show_message("Exito", "Datos guardados con éxito")
    '    recuperar_datos_Panel_Precio(CInt(lblContabilidadRFCPersonaID_Int.Text))
    'End Sub



    'Public Sub editar_Precio_Cobranza_InfoCliente()

    '    Dim clientesDatosBU As New Negocios.ClientesDatosBU
    '    Dim InfoClienteCobranza As New Entidades.InformacionClienteCobranza
    '    Dim cliente As New Entidades.Cliente
    '    Dim moneda As New Entidades.Moneda
    '    Dim tipoIVA As New Entidades.TipoIVA


    'If rbtnPrecioIncrementoCantidad.Checked Then
    '    InfoClienteCobranza.incrementoparporcent = Decimal.Zero
    '    InfoClienteCobranza.incrementoparmonto = numPrecioIncrementoXParCantidad.Value
    'ElseIf rbtnPrecioIncrementoPorcentaje.Checked Then
    '    InfoClienteCobranza.incrementoparporcent = numPrecioIncrementoXParPorcentaje.Value
    '    InfoClienteCobranza.incrementoparmonto = Decimal.Zero

    'End If



    'moneda.monedaid = cboxTipoMoneda.SelectedValue
    'InfoClienteCobranza.moneda = moneda
    'tipoIVA.tipoivaid = cboxTipoIVA.SelectedValue
    'InfoClienteCobranza.tipoiva = tipoIVA

    '    cliente.clienteid = cboxClienteCliente.SelectedValue
    '    InfoClienteCobranza.cliente = cliente

    '    Try
    '        clientesDatosBU.editarCobranzaInfoCliente(InfoClienteCobranza, 2)
    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Public Sub editar_Precio_Cliente_Clientes()

    '    Dim clienteBU As New Negocios.ClientesBU
    '    Dim cliente As New Entidades.Cliente
    '    Dim empresas As New Entidades.Empresa
    '    Dim tipoCliente As New Entidades.TipoCliente

    '    'cliente.clienteespecial = CBool(chboxPrecioClienteEspecial.CheckState)
    '    cliente.precioespecial = CBool(cboxPrecioPrecioEspecial.CheckState)
    '    cliente.clienteid = CInt(lblClienteSAYID_Int.Text)

    '    Try
    '        clienteBU.editarCliente(cliente, Nothing, 3)
    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Public Sub recuperar_datos_Panel_Precio(personaID As Integer)

    '    limpiarControles(pnlFormPrecio)
    '    asignaStatusControles(pnlFormPrecio, False)

    '    'lblPrecioRFCPersonaID.Text = "0"

    '    'If Not Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
    '    '    If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
    '    '        btnEditarPrecio.Enabled = False
    '    '    Else
    '    '        btnEditarPrecio.Enabled = True
    '    '    End If
    '    'End If

    '    If rbtnClienteStatusInactivo.Checked Then
    '        btnEditarPrecio.Enabled = False
    '    Else
    '        If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
    '            btnEditarPrecio.Enabled = True
    '        Else
    '            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
    '                btnEditarPrecio.Enabled = True
    '            Else
    '                btnEditarPrecio.Enabled = False
    '            End If
    '        End If
    '    End If


    '    Dim politicaPago As New DataTable
    '    Dim infoClienteVentas As New DataTable
    '    Dim InfoClienteCobranza As New DataTable
    '    Dim PoliticaPagoBU As New Negocios.PoliticaPagoBU
    '    Dim clientesDatosBU As New Negocios.ClientesDatosBU

    '    Dim ClientesBU As New Ventas.Negocios.ClientesBU
    '    Dim Cliente As New DataTable

    '    Dim clienteID As String = CInt(lblClienteSAYID_Int.Text)


    '    ''CLIENTE CLIENTE
    '    Cliente = ClientesBU.Datos_TablaCliente(clienteID)

    '    'If Cliente.Rows.Count > 0 Then

    '    '    If IsDBNull(Cliente.Rows(0).Item("clie_clienteespecial")) Then
    '    '        chboxPrecioClienteEspecial.Checked = False
    '    '    Else
    '    '        chboxPrecioClienteEspecial.Checked = CBool(Cliente.Rows(0).Item("clie_clienteespecial"))
    '    '    End If

    '    '    If IsDBNull(Cliente.Rows(0).Item("clie_precioespecial")) Then
    '    '        cboxPrecioPrecioEspecial.Checked = False
    '    '    Else
    '    '        cboxPrecioPrecioEspecial.Checked = CBool(Cliente.Rows(0).Item("clie_precioespecial"))
    '    '    End If

    '    'End If


    '    ''COBRANZA INFO CLIENTE
    '    InfoClienteCobranza = clientesDatosBU.Datos_TablaCobranzaInfoCliente(clienteID)
    '    If InfoClienteCobranza.Rows.Count > 0 Then


    '        If IsDBNull(InfoClienteCobranza.Rows(0).Item("iccl_incrementopar_porcent")) Then
    '            rbtnPrecioIncrementoPorcentaje.Checked = False
    '        Else
    '            If CDec(InfoClienteCobranza.Rows(0).Item("iccl_incrementopar_porcent")) = Decimal.Zero Then
    '                rbtnPrecioIncrementoPorcentaje.Checked = False
    '            Else
    '                rbtnPrecioIncrementoPorcentaje.Checked = True
    '            End If
    '            numPrecioIncrementoXParPorcentaje.Value = CDec(InfoClienteCobranza.Rows(0).Item("iccl_incrementopar_porcent"))
    '            numPrecioIncrementoXParPorcentaje.Enabled = False
    '        End If

    '        If IsDBNull(InfoClienteCobranza.Rows(0).Item("iccl_incrementopar_monto")) Then
    '            rbtnPrecioIncrementoCantidad.Checked = False
    '        Else
    '            If CDec(InfoClienteCobranza.Rows(0).Item("iccl_incrementopar_monto")) = Decimal.Zero Then
    '                rbtnPrecioIncrementoCantidad.Checked = False
    '            Else
    '                rbtnPrecioIncrementoCantidad.Checked = True
    '            End If
    '            numPrecioIncrementoXParCantidad.Value = CDec(InfoClienteCobranza.Rows(0).Item("iccl_incrementopar_monto"))
    '            numPrecioIncrementoXParCantidad.Enabled = False
    '        End If

    '    End If

    'End Sub

    Public Function LlenarDetalleNotaListaPrecio(ByVal IdListaVentas As Integer, ByVal IdClienteSay As Integer)
        ''CInt(cboxPrecioListaActual.SelectedValue), CInt(LTrim(RTrim(lblClienteSAYID_Int.Text))))

        Dim NotaDescuentos As String = ""
        Dim dtdescuentos As New DataTable
        Dim clientesBU As New Negocios.ClientesDatosBU
        Dim clientes2BU As New Negocios.ClientesBU
        Dim objPrecioBU As New Negocios.PrecioBU

        Dim dtInformacionConfiguracionCliente As New DataTable
        Dim dtInformacionCliente As New DataTable

        dtInformacionConfiguracionCliente = objPrecioBU.recuperar_Informacion_Cliente_Para_Configurar_Lista_Precios(IdListaVentas, IdClienteSay)
        dtInformacionCliente = clientes2BU.recuperar_Informacion_Cliente_Para_LP(IdClienteSay)


        If dtInformacionConfiguracionCliente.Rows(0).Item("ID_TIPOCLIENTE") > 1 Then
            NotaDescuentos = "Precios " + LTrim(RTrim(dtInformacionConfiguracionCliente.Rows(0).Item("INCOTERM").ToString)) + " León, Guanajuato, México en " +
                dtInformacionConfiguracionCliente.Rows(0).Item("MONEDA AV") + "." + vbCrLf

            dtdescuentos = clientesBU.Datos_TablaDescuentosCliente(IdClienteSay, AreaOperativa)

            If dtdescuentos.Rows.Count > 0 Then
                For Each row As DataRow In dtdescuentos.Rows
                    If row.Item("lude_nombre") <> "DOCUMENTO" Then
                        If row.Item("decl_descuentoenporcentaje") = True Then
                            If NotaDescuentos.Contains("Descuento") Then
                                NotaDescuentos += ", descuento del " + Format(row.Item("decl_cantidaddescuento"), "###,##0.00") + " % por " + (row.Item("mode_nombre")).tolower
                            Else
                                NotaDescuentos += "Descuento del " + Format(row.Item("decl_cantidaddescuento"), "###,###") + " % por " + (row.Item("mode_nombre")).tolower
                            End If

                            If row.Item("decl_diasplazo") > 0 Then
                                NotaDescuentos += " a " + CStr(row.Item("decl_diasplazo")) + " días"
                            End If
                        End If
                    End If
                Next
                If NotaDescuentos.Contains("escuento del") Then
                    NotaDescuentos += "." + vbCrLf
                Else
                    NotaDescuentos += vbCrLf
                End If

            End If
        Else
            If LTrim(RTrim(dtInformacionCliente.Rows(0).Item("tiva_nombre").ToString)) = "MÁS IVA" Then
                NotaDescuentos += "Precios más IVA." + vbCrLf
            ElseIf LTrim(RTrim(dtInformacionCliente.Rows(0).Item("tiva_nombre").ToString)) = "INCLUIDO" And
                dtInformacionCliente.Rows(0).Item("iccl_facturar").ToString = "100" Then
                NotaDescuentos += "Precios con IVA incluido." + vbCrLf
            End If

            ''RECUPERAR DESCUENTOSCLIENTE
            dtdescuentos = clientesBU.Datos_TablaDescuentosCliente(IdClienteSay, AreaOperativa)

            If dtdescuentos.Rows.Count > 0 Then
                For Each row As DataRow In dtdescuentos.Rows
                    If row.Item("decl_descuentoenporcentaje") = True Then
                        If NotaDescuentos.Contains("Descuento") Then
                            NotaDescuentos += ", descuento del " + Format(row.Item("decl_cantidaddescuento"), "###,##0.00") + " % por " + (row.Item("mode_nombre")).tolower
                        Else
                            NotaDescuentos += "Descuento del " + Format(row.Item("decl_cantidaddescuento"), "###,##0.00") + " % por " + (row.Item("mode_nombre")).tolower
                        End If

                        If row.Item("decl_diasplazo") > 0 Then
                            NotaDescuentos += " a " + CStr(row.Item("decl_diasplazo")) + " días"
                        End If
                    End If
                Next
                If NotaDescuentos.Contains("escuento del") Then
                    NotaDescuentos += "." + vbCrLf
                Else
                    NotaDescuentos += vbCrLf
                End If
            End If

            ''PARTE DE LA NOTA EN DURO
            NotaDescuentos += "Su plazo de pago comienza a partir de la fecha de entrega y se estima por medio del sistema "

            If dtdescuentos.Rows.Count > 0 Then
                NotaDescuentos += ", el descuento no se podrá aplicar si excede su plazo de pago." + vbCrLf
            Else
                NotaDescuentos += vbCrLf
            End If

            ''FLETE
            If LTrim(RTrim(dtInformacionCliente.Rows(0).Item("tifl_nombre").ToString)) = "POR COBRAR DESTINATARIO" Then
                NotaDescuentos += "Flete por cobrar."
            Else
                NotaDescuentos += "Flete pagado."
            End If
        End If

        Return NotaDescuentos

    End Function

    Private Sub txtnota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnota.KeyPress
        Return
    End Sub

    Private Sub ValidarPermitirCambioLP_y_Moneda(ByVal IdListaPrecioVenta As Integer, ByVal IdClienteSAY As Integer)
        Dim objPrecioBU As New Negocios.PrecioBU
        Dim dtTiposLVCP As New DataTable

        dtTiposLVCP = objPrecioBU.ValidarPermitirCambioLP_y_Moneda(IdListaPrecioVenta, IdClienteSAY)

        If dtTiposLVCP.Rows.Count = 0 Then
            PermitirCambioListaMoneda = True
        Else
            PermitirCambioListaMoneda = True

            For Each row As DataRow In dtTiposLVCP.Rows
                If row.Item("ESTATUS") = "CAPTURADA" Or row.Item("ESTATUS") = "ACEPTADA" Then
                    PermitirCambioListaMoneda = False
                End If
            Next
        End If


        If PermitirCambioListaMoneda = False Then
            btnPrecioAsignarListadeVentas.Visible = True
            btnPrecioAsignarListadeVentas.Enabled = False
        End If

    End Sub


    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Me.Cursor = Cursors.WaitCursor

        Dim objReporte As New ListaPreciosClienteAlta
        Dim objPrecioBU As New Negocios.PrecioBU
        Dim objBU As New Negocios.ClientesBU
        Dim dtDatosLVCP As New DataTable
        Dim dtTablaRecuperarParametros As New DataTable

        ''''===================================TEMPORAL===============================================
        Dim dtinformacionListaPreciosCapturada As New DataTable
        If lista_RecuperadA.Length = 2 Then
            dtinformacionListaPreciosCapturada = objBU.RecuperarInformacion_ListaVEntasClienteCapturada(CInt(lblClienteSAYID_Int.Text))
            If dtinformacionListaPreciosCapturada.Rows.Count = 0 Then
                Mensajes_Y_Alertas("ADVERTENCIA", "Este cliente no cuenta con ninguna lista de clientes.")
                Exit Sub
            Else
                dtDatosLVCP = objPrecioBU.RecuperarInformacionListaVentaClientePrecio(CInt(lblClienteSAYID_Int.Text), cboxListaDePreciosEncabezado.SelectedValue, dtinformacionListaPreciosCapturada.Rows(0).Item(3))
            End If
            ''===============================================================================================
        Else
            dtDatosLVCP = objPrecioBU.RecuperarInformacionListaVentaClientePrecio(CInt(lblClienteSAYID_Int.Text), cboxListaDePreciosEncabezado.SelectedValue, lista_RecuperadA(2))
        End If

        Dim codigoParidad As String

        If dtDatosLVCP.Rows(0).Item("lvcp_monedaid") > 1 Then
            codigoParidad = dtDatosLVCP.Rows(0).Item("lpba_codigolistabase") + "-" + dtDatosLVCP.Rows(0).Item("lpvt_codigolistaventa") + "-" + CStr(dtDatosLVCP.Rows(0).Item("lvcp_paridad")) + "TC"
        Else
            codigoParidad = dtDatosLVCP.Rows(0).Item("lpba_codigolistabase") + "-" + dtDatosLVCP.Rows(0).Item("lpvt_codigolistaventa")
        End If
        objReporte.RecuperarInformacionLVCP_ImPrimirReporteExterno(CInt(lblClienteSAYID_Int.Text),
                                                                   dtDatosLVCP.Rows(0).Item("idListaVentas"),
                                                                   dtDatosLVCP.Rows(0).Item("lvcp_vigenciainicio"),
                                                                   cboxClienteCliente.Text, codigoParidad,
                                                                   dtDatosLVCP.Rows(0).Item("idListaVentasClientePrecio"),
                                                                   dtDatosLVCP.Rows(0).Item("lvcp_monedaid"),
                                                                   dtDatosLVCP.Rows(0).Item("lvcp_paridad"))

        Me.Cursor = Cursors.Default
    End Sub


    Private Sub validarPermisosListaVentas()
        If VerPanelListaVentas = False Then
            gboxPrecioValoresdeConfiguracionActual.Visible = False
            gboxPrecioValoresdeConfiguracionAsignar.Visible = False
            cboxPrecioListaNueva.Visible = False
            lblPrecioListaNueva.Visible = False
            btnPrecioAsignarListadeVentas.Enabled = False
            btnListadoPreciosPanelPrecio.Enabled = False
        End If

    End Sub


    Private Sub btn_Agregar_PrecioDescuento_Click(sender As Object, e As EventArgs) Handles btn_Agregar_PrecioDescuento.Click

        Dim objDescuentos As New AgregarEditarDescuentosForm
        Dim TotalDescuentos As Double

        For Each Fila As UltraGridRow In grdPrecioDescuentos.Rows
            TotalDescuentos = TotalDescuentos + Fila.Cells("decl_cantidaddescuento").Value
        Next

        objDescuentos.SumatoriaDescuentos = TotalDescuentos
        objDescuentos.ValorMinimoDescuento = numPrecioRangoDescuentoActualInicial.Value
        objDescuentos.valorMaximoDescuento = numPrecioRangoDescuentoActualFinal.Value
        objDescuentos.IdCliente = CInt(lblClienteSAYID_Int.Text)
        objDescuentos.StartPosition = FormStartPosition.CenterScreen
        objDescuentos.ShowDialog()

        poblar_gridPrecioDescuento(CInt(cboxClienteCliente.SelectedValue))
    End Sub


#Region "GRIDS"


    Private Sub grdPrecioDescuentos_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdPrecioDescuentos.DoubleClickCell
        If grdPrecioDescuentos.ActiveRow.IsDataRow Then
            Dim objDescuentos As New AgregarEditarDescuentosForm
            objDescuentos.IdCliente = CInt(lblClienteSAYID_Int.Text)

            objDescuentos.StartPosition = FormStartPosition.CenterScreen

            Dim TotalDescuentos As Double = 0

            For Each row In grdPrecioDescuentos.Selected.Rows

                For Each Fila As UltraGridRow In grdPrecioDescuentos.Rows
                    If Fila.Cells(0).Text <> row.Cells(0).Text Then
                        TotalDescuentos = TotalDescuentos + Fila.Cells("decl_cantidaddescuento").Value
                    End If
                Next

                objDescuentos.IdCliente = CInt(lblClienteSAYID_Int.Text)
                objDescuentos.IdDescuento = CInt(row.Cells(0).Text)
                objDescuentos.IdMotivo = CInt(row.Cells(1).Text)
                objDescuentos.IdLugar = CInt(row.Cells(3).Text)
                objDescuentos.Porcentaje = CBool(row.Cells(5).Text)
                objDescuentos.Cantidad = CDbl(row.Cells(6).Text)
                objDescuentos.Dias = CInt(row.Cells(7).Text)
                objDescuentos.Encadenado = CBool(row.Cells(8).Text)
                objDescuentos.Activo = CBool(row.Cells(10).Text)
                objDescuentos.SumatoriaDescuentos = TotalDescuentos
                objDescuentos.ValorMinimoDescuento = numPrecioRangoDescuentoActualInicial.Value
                objDescuentos.valorMaximoDescuento = numPrecioRangoDescuentoActualFinal.Value
                objDescuentos.ShowDialog()
            Next

            poblar_gridPrecioDescuento(CInt(cboxClienteCliente.SelectedValue))

        End If
    End Sub

    'PRECIOS DESCUENTOS
    Public Sub poblar_gridPrecioDescuento(clienteID As Integer)

        grdPrecioDescuentos.DataSource = Nothing

        Dim clientesBU As New Negocios.ClientesDatosBU
        Dim motivoDescuento As New DataTable
        Dim lugarDescuento As New DataTable
        Dim descuento As New DataTable

        Dim vlmotivoDescuento As New Infragistics.Win.ValueList
        Dim vllugarDescuento As New Infragistics.Win.ValueList

        descuento = clientesBU.Datos_TablaDescuentosCliente(clienteID, AreaOperativa)

        motivoDescuento = clientesBU.Datos_TablaMotivoDescuento()

        lugarDescuento = clientesBU.Datos_TablaLugarDescuento()

        For Each fila As DataRow In motivoDescuento.Rows
            vlmotivoDescuento.ValueListItems.Add(fila.Item("mode_motivodescuentoid"), fila.Item("mode_nombre"))
        Next

        For Each fila As DataRow In lugarDescuento.Rows
            vllugarDescuento.ValueListItems.Add(fila.Item("lude_lugardescuentoid"), fila.Item("lude_nombre"))
        Next

        grdPrecioDescuentos.DataSource = descuento
        grdPrecioDescuentos.DisplayLayout.Bands(0).Columns(2).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        grdPrecioDescuentos.DisplayLayout.Bands(0).Columns(2).ValueList = vlmotivoDescuento
        grdPrecioDescuentos.DisplayLayout.Bands(0).Columns(4).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        grdPrecioDescuentos.DisplayLayout.Bands(0).Columns(4).ValueList = vllugarDescuento

        grdPrecioDescuentosDiseno(grdPrecioDescuentos)

    End Sub

    Private Sub grdPrecioDescuentosDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)


        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(1).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(3).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(9).Hidden = True

        grid.DisplayLayout.Bands(0).Columns(2).Header.Caption = "MOTIVO"
        grid.DisplayLayout.Bands(0).Columns(4).Header.Caption = "LUGAR"
        grid.DisplayLayout.Bands(0).Columns(5).Header.Caption = "%"
        grid.DisplayLayout.Bands(0).Columns(5).Style = ColumnStyle.CheckBox
        grid.DisplayLayout.Bands(0).Columns(6).Header.Caption = "CANTIDAD"
        grid.DisplayLayout.Bands(0).Columns(6).Style = ColumnStyle.DoublePositive

        grid.DisplayLayout.Bands(0).Columns(7).Header.Caption = "DÍAS"
        grid.DisplayLayout.Bands(0).Columns(8).Header.Caption = "ENCADENADO"


        grid.DisplayLayout.Bands(0).Columns(2).Width = 120
        grid.DisplayLayout.Bands(0).Columns(4).Width = 120
        grid.DisplayLayout.Bands(0).Columns(5).Width = 40
        grid.DisplayLayout.Bands(0).Columns(6).Width = 90
        grid.DisplayLayout.Bands(0).Columns(7).Width = 90
        grid.DisplayLayout.Bands(0).Columns(8).Width = 90

        asignaFormato_Columna(grid)

        'grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        Dim ColumnaSumar As UltraGridColumn = grdPrecioDescuentos.DisplayLayout.Bands(0).Columns(6)
        Dim sumaPares As SummarySettings = grdPrecioDescuentos.DisplayLayout.Bands(0).Summaries.Add("TOTAL", SummaryType.Sum, ColumnaSumar)
        grdPrecioDescuentos.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        sumaPares.DisplayFormat = "{0:###,###,###,###0.00}"
        sumaPares.Appearance.TextHAlign = HAlign.Right


    End Sub

    Private Sub grdPrecioDescuentos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdPrecioDescuentos.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdPrecioDescuentos_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles grdPrecioDescuentos.DoubleClickHeader

        If Me.grdPrecioDescuentos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.grdPrecioDescuentos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.grdPrecioDescuentos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.grdPrecioDescuentos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.grdPrecioDescuentos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.grdPrecioDescuentos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.grdPrecioDescuentos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If

    End Sub

    Private Sub grdPrecioDescuentos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdPrecioDescuentos.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            grdPrecioDescuentos.ActiveRow.Activated = False
        End If
        If e.KeyChar = ChrW(Keys.Escape) Then
            'AgregarOEditarGrid = False
            poblar_gridPrecioDescuento(CInt(cboxClienteCliente.SelectedValue))
            grdPrecioDescuentos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        End If

    End Sub

    'Private Sub gridPrecioDescuentos_MouseClick(sender As Object, e As MouseEventArgs) Handles grdPrecioDescuentos.MouseClick

    '    If rbtnClienteStatusInactivo.Checked Then Return

    '    'If AgregarOEditarGrid = False Then

    '    Dim mainElement As UIElement
    '    Dim element As UIElement
    '    Dim screenPoint As Point
    '    Dim clientPoint As Point
    '    Dim row As UltraGridRow
    '    Dim cell As UltraGridCell

    '    mainElement = Me.grdPrecioDescuentos.DisplayLayout.UIElement
    '    screenPoint = Control.MousePosition
    '    clientPoint = Me.grdPrecioDescuentos.PointToClient(screenPoint)
    '    element = mainElement.ElementFromPoint(clientPoint)


    '    If element Is Nothing Then Return

    '    row = element.GetContext(GetType(UltraGridRow))

    '    If Not row Is Nothing Then
    '        cell = element.GetContext(GetType(UltraGridCell))

    '        If Not cell Is Nothing Then

    '            If e.Button <> Windows.Forms.MouseButtons.Right Then Return
    '            Dim cms = New ContextMenuStrip
    '            Dim item1 = cms.Items.Add("Nuevo descuento")
    '            item1.Tag = 1
    '            AddHandler item1.Click, AddressOf gridPrecioDescuentos_menuChoice

    '            Dim item2 = cms.Items.Add("Editar descuento")
    '            item2.Tag = 2
    '            AddHandler item2.Click, AddressOf gridPrecioDescuentos_menuChoice

    '            If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
    '                cms.Show(Control.MousePosition)
    '            Else
    '                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
    '                    cms.Show(Control.MousePosition)
    '                End If
    '            End If

    '        End If
    '    End If


    'End Sub

    'Private Sub gridPrecioDescuentos_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim item = CType(sender, ToolStripMenuItem)
    '    Dim selection = CInt(item.Tag)

    '    If selection = 1 Then ''AGREGAR NUEVO DESCUENTI
    '        Dim objDescuentos As New AgregarEditarDescuentosForm
    '        Dim TotalDescuentos As Double

    '        For Each Fila As UltraGridRow In grdPrecioDescuentos.Rows
    '            TotalDescuentos = TotalDescuentos + Fila.Cells("decl_cantidaddescuento").Value
    '        Next

    '        objDescuentos.SumatoriaDescuentos = TotalDescuentos
    '        objDescuentos.ValorMinimoDescuento = numPrecioRangoDescuentoActualInicial.Value
    '        objDescuentos.valorMaximoDescuento = numPrecioRangoDescuentoActualFinal.Value
    '        objDescuentos.IdCliente = CInt(lblClienteSAYID_Int.Text)
    '        objDescuentos.StartPosition = FormStartPosition.CenterScreen
    '        objDescuentos.ShowDialog()

    '    ElseIf selection = 2 Then ''EDITAR HORARIO ACTUAL
    '        Dim objDescuentos As New AgregarEditarDescuentosForm
    '        objDescuentos.IdCliente = CInt(lblClienteSAYID_Int.Text)

    '        objDescuentos.StartPosition = FormStartPosition.CenterScreen

    '        Dim TotalDescuentos As Double = 0

    '        For Each row In grdPrecioDescuentos.Selected.Rows

    '            For Each Fila As UltraGridRow In grdPrecioDescuentos.Rows
    '                If Fila.Cells(0).Text <> row.Cells(0).Text Then
    '                    TotalDescuentos = TotalDescuentos + Fila.Cells("decl_cantidaddescuento").Value
    '                End If
    '            Next





    '            objDescuentos.IdCliente = CInt(lblClienteSAYID_Int.Text)
    '            objDescuentos.IdDescuento = CInt(row.Cells(0).Text)
    '            objDescuentos.IdMotivo = CInt(row.Cells(1).Text)
    '            objDescuentos.IdLugar = CInt(row.Cells(3).Text)
    '            objDescuentos.Porcentaje = CBool(row.Cells(5).Text)
    '            objDescuentos.Cantidad = CDbl(row.Cells(6).Text)
    '            objDescuentos.Dias = CInt(row.Cells(7).Text)
    '            objDescuentos.Encadenado = CBool(row.Cells(8).Text)
    '            objDescuentos.Activo = CBool(row.Cells(10).Text)
    '            objDescuentos.SumatoriaDescuentos = TotalDescuentos
    '            objDescuentos.ValorMinimoDescuento = numPrecioRangoDescuentoActualInicial.Value
    '            objDescuentos.valorMaximoDescuento = numPrecioRangoDescuentoActualFinal.Value
    '            objDescuentos.ShowDialog()
    '        Next
    '        'AgregarOEditarGrid = True
    '    End If

    '    poblar_gridPrecioDescuento(CInt(cboxClienteCliente.SelectedValue))

    'End Sub




    'Private Sub grdPrecioDescuentos_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdPrecioDescuentos.BeforeRowDeactivate

    '    If grdPrecioDescuentos.ActiveRow.IsFilterRow Then Return
    '    AgregarOEditarGrid = False
    '    If grdPrecioDescuentos.ActiveRow.DataChanged Then

    '        


    '        AgregarOEditarGrid = False
    '    End If

    '    grdPrecioDescuentos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

    'End Sub


    ''PRECIOS LISTA DE PRECIOS

    Private Sub PoblarGridFlete_ListadePrecios(ByVal grid As UltraGrid, ByVal ListaDePreciosId As Integer)
        Dim objBUListaPrecio As New Negocios.PrecioBU
        Dim dtFleteTipo As New DataTable

        dtFleteTipo = objBUListaPrecio.Recuperar_Lista_Tipos_Flete(ListaDePreciosId)

        grid.DataSource = Nothing
        grid.DataSource = dtFleteTipo

        gridListaDePreciosFleteDiseno(grid)

    End Sub

    Private Sub gridListaDePreciosFleteDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True

        grid.DisplayLayout.Bands(0).Columns(1).Header.Caption = "TIPO FLETE"


        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

    End Sub

    Private Sub PoblarGridIva_ListadePrecios(ByVal grid As UltraGrid, ByVal IdListaDePrecios As Integer)
        Dim objBUListaPrecio As New Negocios.PrecioBU
        Dim dtIvaLP As New DataTable

        dtIvaLP = objBUListaPrecio.Recuperar_Lista_Tipos_Iva(IdListaDePrecios)

        grid.DataSource = Nothing
        grid.DataSource = dtIvaLP

        gridListaDePreciosIvaDiseno(grid)

    End Sub

    Private Sub gridListaDePreciosIvaDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True

        grid.DisplayLayout.Bands(0).Columns(1).Header.Caption = "TIPO IVA"

        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

    End Sub

#End Region

End Class
