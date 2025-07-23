Imports Tools

Partial Class FichaTecnicaClienteForm

    Private Sub ListaClientes()
        Try


            Controles.ComboNombreComercialCliente(cboxClienteCliente, 0)

            'Dim objClientesBU As New Ventas.Negocios.ClientesBU
            'Dim tabla As New DataTable

            'tabla = objClientesBU.buscarClientesNombreComercial(0)
            'tabla.Rows.InsertAt(tabla.NewRow, 0)


            'Dim strCol As New AutoCompleteStringCollection

            'For Each row As DataRow In tabla.Rows
            '    strCol.Add(row("clie_nombregenerico").ToString)
            'Next


            'cboxClienteCliente.AutoCompleteCustomSource = strCol
            'cboxClienteCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            'cboxClienteCliente.AutoCompleteSource = AutoCompleteSource.CustomSource

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ListaListaDePecios(ByVal combo As ComboBox, ByVal IdCliente As Integer, ByVal NoAsignadas As Boolean, ByVal LVAsignada As Boolean)
        Try

            Controles.ComboListasDePrecios(combo, IdCliente, NoAsignadas, LVAsignada)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ListaVendedor()

        'Try
        '    Controles.ComboNombreVendedorSegunCliente(cboxClienteVendedor)
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub ListaAtnCliente()

        Try
            Controles.ComboAtnCliente(cboxClienteAtnClientes)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ListaClasificacionCliente()

        Try
            Controles.ComboClasificacionCliente(cboxClienteClasificacion)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ListaPais(ByVal comboEntrada As System.Windows.Forms.ComboBox)

        Try
            Controles.ComboPaisesMayusculas(comboEntrada)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ListaEstado(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal paisID As Integer)

        Try
            Controles.ComboEstados(comboEntrada, paisID)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ListaCiudad(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal estadoID As Integer)
        comboEntrada.DataSource = Nothing
        If estadoID = 0 Then Return
        Try
            Controles.ComboCiudadesMayusculas(comboEntrada, estadoID)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ListaPoblacion(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal ciudadID As Integer)

        Try
            Controles.ComboPoblaciones(comboEntrada, ciudadID)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ListaEmpresas()
        Try
            Controles.ComboEmpresaActiva(cboxVentasEmpresa)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ListaTipoCliente(ByVal comboEntrada As System.Windows.Forms.ComboBox)
        Try
            Controles.ComboTipoCliente(comboEntrada)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ListaValidadorVentas(usuarioID As Integer, tipoValidacion As Integer)
        Try
            Controles.ComboColaboradorValidador(cboxVentasValidador, usuarioID, tipoValidacion)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaTipoIVA(ByVal combo As ComboBox)
        Try
            Controles.ComboTipoIVA(combo)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaMonedas(ByVal combo As ComboBox)
        Try
            Controles.ComboTipoMoneda(combo)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaRutas(ByVal comboEntrada As System.Windows.Forms.ComboBox)
        Try
            Controles.ComboRutas(comboEntrada)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaRamos(ByVal comboEntrada As System.Windows.Forms.ComboBox)
        Try
            Controles.ComboRamos(comboEntrada)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaTipoTiendas(comboEntrada As ComboBox)
        Try
            Controles.ComboTipoTiendas(comboEntrada)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaClienteRFC(ByVal comboEntrada As System.Windows.Forms.ComboBox, clienteID As Integer)
        Try
            Controles.ComboClienteRFCSegunCliente(comboEntrada, clienteID)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaTECClienteRFC(ByVal comboEntrada As System.Windows.Forms.ComboBox, clienteRFCID As Integer)
        Try
            Controles.ComboTECClienteRFC(comboEntrada, clienteRFCID)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaTipoFlete(ByVal comboEntrada As System.Windows.Forms.ComboBox)
        Try
            Controles.ComboTipoFlete(comboEntrada)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaTipoValor(ByVal comboEntrada As System.Windows.Forms.ComboBox)
        Try
            Controles.ComboTipoValor(comboEntrada)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaTipoEmpaque(ByVal comboEntrada As System.Windows.Forms.ComboBox)
        Try
            Controles.ComboTipoEmpaque(comboEntrada)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaTamanoEmpaque(ByVal comboEntrada As System.Windows.Forms.ComboBox)
        Try
            Controles.ComboTamanoEmpaque(comboEntrada)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaFormaPago(ByVal comboEntrada As System.Windows.Forms.ComboBox)
        Try
            Controles.ComboFormaPago(comboEntrada)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ListaFormaPago_NotaCredito(ByVal comboEntrada As ComboBox)
        Try
            Controles.ComboFormaPago_NotaCredito(comboEntrada)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaValidadorCobranza(usuarioID As Integer, tipoValidacion As Integer)
        Try
            Controles.ComboColaboradorValidador(cboxCobranzaValidador, usuarioID, tipoValidacion)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaMetodoPago(ByVal comboEntrada As System.Windows.Forms.ComboBox)
        Try
            Controles.ComboMetodoPago(comboEntrada)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaMetodoPago_NotaCredito(ByVal comboEntrada As ComboBox)
        Try
            Controles.ComboMetodoPago_NotaCredito(comboEntrada)
        Catch ex As Exception

        End Try
    End Sub

    Private Function seleccionarIDCombos_NotaCredito(clienteID As Integer)
        Dim datos As New DataTable
        Try
            datos = Controles.CombosCobranzaNotaCredito(clienteID)
        Catch ex As Exception

        End Try
        Return datos
    End Function

    Private Sub ListaAlmacen(ByVal comboEntrada As System.Windows.Forms.ComboBox)
        Try
            Controles.ComboAlmacen(comboEntrada)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaTipoFleje(ByVal comboEntrada As System.Windows.Forms.ComboBox)
        Try
            Controles.ComboTipoFleje(comboEntrada)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaProtectorFleje(ByVal comboEntrada As System.Windows.Forms.ComboBox)
        Try
            Controles.ComboProtectorFleje(comboEntrada)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaUnidadDeVenta(ByVal comboEntrada As System.Windows.Forms.ComboBox)
        Try
            Controles.ComboUnidadVenta(comboEntrada)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaLugarEntrega(ByVal comboEntrada As System.Windows.Forms.ComboBox)
        Try
            Controles.ComboLugarEntrega(comboEntrada)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaRestriccionesFacturacion(ByVal comboEntrada As System.Windows.Forms.ComboBox)
        Try
            Controles.ComboRestriccionesFacturacion(comboEntrada)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaTipoEtiqueta(ByVal comboEntrada As System.Windows.Forms.ComboBox)
        Try
            Controles.ComboTipoEtiqueta(comboEntrada)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaNivelSocioEconomico(ByVal comboEntrada As System.Windows.Forms.ComboBox)
        Try
            Controles.ComboNivelSocioEconomico(comboEntrada)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaClienteRFCFactura(ByVal comboEntrada As System.Windows.Forms.ComboBox, clienteID As Integer)
        Try
            Controles.ComboClienteRFCSegunClienteFactura(comboEntrada, clienteID)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaIncoterms(ByVal comboEntrada As System.Windows.Forms.ComboBox)
        Try
            Controles.ComboIncoterms(comboEntrada)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaRFC_Sicy(ByVal comboEntrada As System.Windows.Forms.ComboBox, clienteID_Sicy As Integer, rfc_sicyID As Integer, editando As Boolean)
        Try
            Controles.Combo_RFC_Sicy(comboEntrada, clienteID_Sicy, rfc_sicyID, editando)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListaTEC_Sicy(ByVal comboEntrada As System.Windows.Forms.ComboBox, clienteID_Sicy As Integer, distribucion_sicyID As Integer, editando As Boolean)
        Try
            Controles.Combo_ListaTEC_Sicy(comboEntrada, clienteID_Sicy, distribucion_sicyID, editando)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub ListaClienteNacional_Extranjero(ByVal ComboEntrada As ComboBox, ByVal IdCliente As Integer)
        Try
            Controles.ComboClienteNacional_Extranjero(ComboEntrada, IdCliente)
        Catch ex As Exception

        End Try

    End Sub

End Class
